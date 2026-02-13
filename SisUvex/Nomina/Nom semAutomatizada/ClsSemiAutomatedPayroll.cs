using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.Extentions;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Catalogos.Metods.Values;
using SisUvex.Configuracion.Parameters;
using static SisUvex.Catalogos.Metods.ClsObject;
namespace SisUvex.Nomina.Nom_semAutomatizada
{
	internal class ClsSemiAutomatedPayroll
	{
		public FrmSemiAutomatedPayroll frm;
		ClsControls controlList;
		DataTable dtNomina;

		public void BeginForm()
		{
			SetTxbReferencia();
			ClsComboBoxes.CboLoadActives(frm.cboLote, ClsObject.Lot.CboOnlyNameLot);
			AddControlsToList();
		}
		public void SetTxbReferencia()
		{
			frm.txbReferencia.Text = frm.dtpFecha.Value.ToString("yyMMdd");
		}

		private void AddControlsToList()
		{
			frm.txbReferencia.Tag = "sixDigit";
			controlList = new ClsControls();
			controlList.ChangeHeadMessage("Para generar el archivo CSV debe:\n");
			controlList.Add(frm.dtpFecha, "Seleccione una fecha.");
			controlList.Add(frm.txbReferencia, "Introducir un folio de referencia (6).");
			controlList.Add(frm.cboLote, "Seleccionar un lote.");
		}
		public void BtnCsv()
		{
			if (!controlList.ValidateControls())
				return;

			//Metodo para generar el archivo CSV
			GenerarArchivoCsv();
		}
		private DataTable GetDtCSV()
		{
			string referencias = frm.txbReferencia.Text;
			string idLot = frm.cboLote.GetColumnValue(Column.id).ToString();
			string horasTrabajadas = EParameters.GetValue("016", "01");//Parametro Duracion de la jornada laboral
			string cajas = "0"; // Cajas Destajos (valor fijo)


			DataTable dtCsv = new();
			dtCsv.Columns.Add("Fecha", typeof(string));   //0
			dtCsv.Columns.Add("Referencia", typeof(string));
			dtCsv.Columns.Add("IdEmploye", typeof(string));		//1
			dtCsv.Columns.Add("Sueldo", typeof(string));    //6
			dtCsv.Columns.Add("Lote", typeof(string));
			dtCsv.Columns.Add("Actividad", typeof(string));    //3
			dtCsv.Columns.Add("Destajo", typeof(string));
			dtCsv.Columns.Add("HorasTrabajadas", typeof(string));

			foreach (DataRow dr in dtNomina.Rows)
			{
				string fechaFormateada = Convert.ToDateTime(dr[0]).ToString("yyyy/MM/dd");
				string sueldo = ClsValues.FormatZeros(dr[6].ToString(), "0000.00");
				//string empleado = ClsValues.FormatZeros(dr[1].ToString(), "000000")
				dtCsv.Rows.Add(
					fechaFormateada,
					referencias,
					dr[1],
					sueldo,
					idLot,
					dr[3],
					cajas,
					horasTrabajadas
				);
			}

		


			return dtCsv;
		}

		public void GenerarArchivoCsv()
		{
			DataTable dt = GetDtCSV();

			string separador = CultureInfo.CurrentCulture.TextInfo.ListSeparator;

			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Filter = "Archivo CSV (*.csv)|*.csv";

			DateTime fechaNomina = Convert.ToDateTime(dt.Rows[0][0]);
			sfd.FileName = $"Nomina{fechaNomina:yyyy-MM-dd}.csv";

			if (sfd.ShowDialog() == DialogResult.OK)
			{
				using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
				{
					foreach (DataRow row in dt.Rows)
					{
						string[] campos = row.ItemArray.Select(campo =>
						{
							string valor = campo.ToString();

							if (valor.Contains(separador) || valor.Contains("\""))
							{
								valor = valor.Replace("\"", "\"\"");
								valor = $"\"{valor}\"";
							}

							return valor;
						}).ToArray();

						sw.WriteLine(string.Join(separador, campos));
					}
				}

				MessageBox.Show($"CSV generado con separador '{separador}' ");
			}
		}

		public void ExportarExcel(DataTable dt)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Filter = "Archivo Excel (*.xlsx)|*.xlsx";
			sfd.FileName = $"Nomina_{frm.dtpFecha.Value:yyyyMMdd}.xlsx";

			if (sfd.ShowDialog() != DialogResult.OK)
				return;

			using (XLWorkbook wb = new XLWorkbook())
			{
				var hoja = wb.Worksheets.Add("Nomina");

				// Insertar DataTable completo
				hoja.Cell(1, 1).InsertTable(dt);

				// Ajustar tamaño columnas
				hoja.Columns().AdjustToContents();

				wb.SaveAs(sfd.FileName);
			}

			MessageBox.Show("Excel generado correctamente");
		}


		private string GetQueryNom()
		{
			string fecha = frm.dtpFecha.Value.ToString("yyyy-MM-dd");
			string query = $@"SELECT
								r.Fecha,
								r.IdEmpleado,
								r.NombreCompleto,
								r.CodigoActividad,
								t.v_descripcion_tab AS NombreActividad,   
								r.LineaProduccion,
								r.SueldoTotal
							FROM (
								SELECT DISTINCT
									al.d_attendence      AS Fecha,
									al.id_employee       AS IdEmpleado,
									al.c_codigo_tab      AS CodigoActividad,
									al.id_productionLine AS LineaProduccion
								FROM dbo.Nom_AttendenceList al
								WHERE al.d_attendence = '{fecha}'
							) x
							CROSS APPLY dbo.fn_salary_tab(
								x.Fecha,
								CAST(x.CodigoActividad AS VARCHAR(20)),
								x.LineaProduccion,
								x.IdEmpleado,
								'2'
							) r
							LEFT JOIN dbo.Nom_Tabulador t
								ON CAST(t.c_codigo_tab AS VARCHAR(20)) = r.CodigoActividad
							ORDER BY
								r.CodigoActividad,
								r.LineaProduccion,
								r.IdEmpleado;";
			return query;
		}
		public void BtnCargarDatos()
		{
			dtNomina = ClsQuerysDB.GetDataTable(GetQueryNom());

			frm.dgvEmployee.DataSource = dtNomina;
		}
	}

}
