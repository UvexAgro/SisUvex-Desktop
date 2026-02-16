using System;
using System.Collections.Generic;
using System.Data;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Microsoft.Data.SqlClient;
using NPOI.OpenXmlFormats.Spreadsheet;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.Extentions;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Catalogos.Metods.Values;
using SisUvex.Configuracion.Parameters;
using ZXing;
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
			dtCsv.Columns.Add("IdEmploye", typeof(string));     //1
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
			sfd.FileName = $"Nomina{frm.dtpFecha.Value:yyyy-MM-dd}.xlsx";

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


		public void EjecutarCalculoProduccion()
		{
			try
			{
				string fecha = frm.dtpFecha.Value.ToString("yyyy-MM-dd");

				if (!ValidarHorarioDeEmpaque(fecha))
				{
					MessageBox.Show($"No existe horario de empaque para la fecha {fecha}",
									"Sistema",
									MessageBoxButtons.OK,
									MessageBoxIcon.Warning);
					return;
				}

				if (YaHayRegistrosdeProduccion(fecha))
				{
					DialogResult respuesta = MessageBox.Show($"Ya tienes datos para la {fecha}.\n ¿Deseas sobreecribir los datos?",
														"Sistema",
														MessageBoxButtons.YesNo,
														MessageBoxIcon.Exclamation);
					if (respuesta == DialogResult.No)
					{
						return;
					}

				}

				if (!ValidarTabladeWorkTimeAndProductionTotal(fecha))
					return;

				string query = $@"EXEC sp_GuardarLibrasProductionLine '{fecha}'";

				bool result = ClsQuerysDB.ExecuteQuery(query);
				if (result)
				{
					MessageBox.Show("Producción actualizada correctamente",
									"Sistema",
									MessageBoxButtons.OK,
									MessageBoxIcon.Information);
				}
				else
				{
					MessageBox.Show("Error al actualizar la produccion",
														"Sistema",
														MessageBoxButtons.OK,
														MessageBoxIcon.Error);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		private bool YaHayRegistrosdeProduccion(string fecha)
		{
			int result;
			string count = ClsQuerysDB.GetData($"select count(d_workDay) from Nom_ProductionTotal where d_workDay = '{fecha}'");
			result = int.Parse(count);
			if (result == 0)
				return false;
			else
				return true;
		}
		private bool ValidarHorarioDeEmpaque(string fecha)
		{
			int result;
			string count = ClsQuerysDB.GetData($"select count(d_workTime) from Nom_WorkTime where d_workTime = '{fecha}'");
			result = int.Parse(count);
			if (result == 0)
				return false;
			else
				return true;
		}
		private DataTable ObtenerWorkTimeVsProduction(string fecha)
		{
			string query = $@"SELECT
			ISNULL(wt.id_productionLine, pt.id_productionLine) AS id_productionLine,
			ISNULL(CAST(wt.d_workTime AS DATE), CAST(pt.d_workDay AS DATE)) AS Fecha,

			CASE WHEN wt.id_productionLine IS NULL THEN 0 ELSE 1 END AS TieneWorkTime,
			CASE WHEN pt.id_productionLine IS NULL THEN 0 ELSE 1 END AS TieneProduction,

			ISNULL(pt.n_poundsNormalTime,0) + ISNULL(pt.n_poundsOvertime,0) AS TotalLibras

			FROM Nom_WorkTime wt
			FULL JOIN Nom_ProductionTotal pt
			ON wt.id_ProductionLine = pt.id_productionLine
			AND CAST(wt.d_workTime AS DATE) = CAST(pt.d_workDay AS DATE)

			WHERE CAST(ISNULL(wt.d_workTime,pt.d_workDay) AS DATE) = '{fecha}'";

			return ClsQuerysDB.GetDataTable(query);
		}
		private bool ValidarTabladeWorkTimeAndProductionTotal(string fecha)
		{
			DataTable dt = ObtenerWorkTimeVsProduction(fecha);

			bool error = false;
			bool warning = false;

			StringBuilder detalleError = new StringBuilder();
			StringBuilder detalleWarning = new StringBuilder();

			foreach (DataRow row in dt.Rows)
			{
				int linea = Convert.ToInt32(row["id_productionLine"]);
				bool tieneWT = Convert.ToInt32(row["TieneWorkTime"]) == 1;
				bool tienePT = Convert.ToInt32(row["TieneProduction"]) == 1;
				decimal total = Convert.ToDecimal(row["TotalLibras"]);

				// Coinciden
				if (tieneWT && tienePT)
				{
					if (total <= 0)
					{
						error = true;
						detalleError.AppendLine($"• Línea {linea}: producción en 0 o negativa");
					}
				}
				else if (!tieneWT)
				{
					warning = true;

					if (!tieneWT)
						detalleWarning.AppendLine($"• Línea {linea}: existe producción pero NO tiene horario");

					//if (!tienePT)
					//	detalleWarning.AppendLine($"• Línea {linea}: tiene horario pero NO tiene producción");
				}
			}

			if (error)
			{
				MessageBox.Show(
					"No es posible realizar el cálculo de producción.\n\n" +
					"Se detectaron líneas con producción incorrecta (0 o negativa).\n" +
					"Verifique la captura de datos antes de continuar.\n\n" +
					detalleError.ToString(),
					"Validación de Producción",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Exclamation);

				return false;
			}

		
		//	if (warning)
		//	{
		//		DialogResult r = MessageBox.Show(
		//			"Se encontraron diferencias entre horario y producción.\n\n" +
		//			"Revise la información antes de continuar.\n\n" +
		//			detalleWarning.ToString() +
		//			"\n¿Deseas continuar?",
		//			"Advertencia",
		//			MessageBoxButtons.OK,
		//			MessageBoxIcon.Warning);

		//		if (r == DialogResult.No)
		//			return false;
		//	}

		//	return true;
		//
		}


	}


}


