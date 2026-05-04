using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
using System.Drawing;
namespace SisUvex.Nomina.Nom_semAutomatizada

{
	internal class ClsSemiAutomatedPayroll
	{
		public FrmSemiAutomatedPayroll frm;
		ClsControls controlList;
		DataTable dtNomina;
		public string TipoNomina = "E";
		public void BeginForm()
		{
			SetTxbReferencia();
			ClsComboBoxes.CboLoadActives(frm.cboLote, ClsObject.Lot.CboOnlyNameLotFacility);
			AddControlsToList();
			ClsComboBoxes.CboLoadActives(frm.cboLineas, ClsObject.ProductionLine.Cbo);
			frm.cboLineas.SelectedIndexChanged += (s, e) => dgvFiltrarBanda();
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

			DataTable dtNomina = (DataTable)frm.dgvEmployee.DataSource;


			if (dtNomina == null || dtNomina.Rows.Count == 0)
			{
				MessageBox.Show("No hay datos para generar.");
				return null;
			}

			DataTable dtCsv = new();
			dtCsv.Columns.Add("Fecha", typeof(string));   //0
			dtCsv.Columns.Add("Referencia", typeof(string));
			dtCsv.Columns.Add("Codigo", typeof(string));     //1
			dtCsv.Columns.Add("Sueldo", typeof(string));    //6
			dtCsv.Columns.Add("Lote", typeof(string));
			dtCsv.Columns.Add("Actividad", typeof(string));    //3
			dtCsv.Columns.Add("TotalCajas", typeof(string));
			dtCsv.Columns.Add("HorasTrabajadas", typeof(string));

			foreach (DataRow dr in dtNomina.Rows)
			{
				string fechaFormateada = Convert.ToDateTime(dr[0]).ToString("yyyy/MM/dd");
				string sueldo = ClsValues.FormatZeros(dr[7].ToString(), "0000.00");
				//string empleado = ClsValues.FormatZeros(dr[1].ToString(), "000000")
				dtCsv.Rows.Add(
					fechaFormateada,
					referencias,
					dr[1],
					sueldo,
					idLot,
					dr[3],
					dr[6],
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
			}

			if (!File.Exists(sfd.FileName))
			{
				MessageBox.Show($"El Archivo no se pudo Guardar {sfd.FileName}");
				return;
			}

			//Mensaje de todo bien y abrir archivo
			DialogResult result = MessageBox.Show(
				"Reporte en CSV generado correctamente.\n\n" +
				"¿Deseas abrir el archivo?",
				"Reporte generado",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Information
			);

			if (result == DialogResult.Yes)
			{
				System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
				{
					FileName = "notepad.exe",
					Arguments = $"\"{sfd.FileName}\"",
					UseShellExecute = true
				});
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


				if (IsFileLocked(sfd.FileName))
				{
					MessageBox.Show(
						$"El archivo '{sfd.FileName}' está abierto.\n\n" +
						"Ciérralo antes de generar el reporte.",
						"Archivo en uso",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning
					);
					return;
				}


				wb.SaveAs(sfd.FileName);
			}
			if (sfd.FileName == null)
				return;


			if (!File.Exists(sfd.FileName))
			{
				MessageBox.Show($"El Archivo no se pudo Guardar {sfd.FileName}");
				return;
			}

			//Mensaje de todo bien y abrir archivo
			DialogResult result = MessageBox.Show(
				"Reporte en excel generado correctamente.\n\n" +
				"¿Deseas abrir el archivo?",
				"Reporte generado",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Information
			);

			if (result == DialogResult.Yes)
			{
				System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
				{
					FileName = sfd.FileName,
					UseShellExecute = true
				});
			}
		}

		private string GetQueryNom()
		{
			string fecha = frm.dtpFecha.Value.ToString("yyyy-MM-dd");

			if (!ValidarHorasSemana(fecha))
				return "";

			//  Validar selección
			if (!frm.rbtEsparrago.Checked && !frm.rbtUva.Checked)
			{
				MessageBox.Show("Seleccione un tipo de nómina.");
				return "";
			}

			//  ESPÁRRAGO
			if (frm.rbtEsparrago.Checked)
			{
				TipoNomina = "E"; //  guardar tipo
				return $"EXEC dbo.sp_ReporteNomina_Esparrago '{fecha}'";
			}

			//  UVA
			if (frm.rbtUva.Checked)
			{
				TipoNomina = "U"; //  guardar tipo
				return $"EXEC dbo.sp_ReporteNomina_Uva '{fecha}'";
			}

			return "";
		}

		public void BtnCargarDatos()
		{
			string query = GetQueryNom();

			if (string.IsNullOrEmpty(query))
				return;

			dtNomina = ClsQuerysDB.GetDataTable(query);

			if (dtNomina.Rows.Count == 0)
			{
				MessageBox.Show("No existen registros para la fecha seleccionada.",
								"Sistema",
								MessageBoxButtons.OK,
								MessageBoxIcon.Information);
				return;
			}

			frm.dgvEmployee.DataSource = dtNomina;
			if (frm.dgvEmployee.Columns.Contains("Nw"))
			{
				frm.dgvEmployee.Columns["Nw"].Visible = false;
			}
			if (TipoNomina == "E") // esparrago
			{
				frm.pllCsv.BackColor = System.Drawing.Color.FromArgb(230, 245, 230);
			}
			else // uva
			{
				frm.pllCsv.BackColor = System.Drawing.Color.FromArgb(240, 230, 250);
			}

			//  aplicar estilo al grid
			ActivarEstiloGrid(frm.dgvEmployee);
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
				ValidarCajasSinAsistencia(fecha);

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
		private bool ValidarHorasSemana(string fecha)
		{
			string query = $@"
			SELECT MAX(Horas)
			FROM (
				SELECT wt.id_ProductionLine, SUM(wt.d_overtime) AS Horas
				FROM Nom_WorkTime wt
				INNER JOIN Payroll_AttendancePeriod sp
					ON '{fecha}' BETWEEN sp.d_startDate_per AND sp.d_endDate_per
				WHERE wt.d_workTime BETWEEN sp.d_startDate_per AND sp.d_endDate_per
				GROUP BY wt.id_ProductionLine
			) t";

			string result = ClsQuerysDB.GetData(query);

			decimal horas = 0;
			decimal.TryParse(result, out horas);

			if (horas > 13)
			{
				DialogResult r = MessageBox.Show(
					$"Una línea de producción tiene {horas} horas extra acumuladas.\n\n" +
					"Esto supera las 13 horas permitidas.\n\n" +
					"¿Deseas continuar con el cálculo?",
					"Advertencia de horas",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Warning
				);

				if (r == DialogResult.No)
					return false;
			}

			return true;
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


			if (warning)
			{
				DialogResult r = MessageBox.Show(
					"Se encontraron diferencias entre horario y producción.\n\n" +
					"Revise la información antes de continuar.\n\n" +
					detalleWarning.ToString() +
					"\n¿Deseas continuar?",
					"Advertencia",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				if (r == DialogResult.No)
					return false;
			}

			return true;
		}
		private void dgvFiltrarBanda()
		{
			if (dtNomina == null || dtNomina.Rows.Count < 1 || !dtNomina.Columns.Contains("LineaProduccion"))
			{ return; }

			string idBanda;
			if (frm.cboLineas.SelectedIndex < 1)
			{
				dtNomina.DefaultView.RowFilter = null;
				return;
			}

			idBanda = frm.cboLineas.SelectedValue.ToString();

			dtNomina.DefaultView.RowFilter = $" LineaProduccion = '{idBanda}' ";
		}
		private bool IsFileLocked(string filePath)
		{
			if (!File.Exists(filePath))
				return false;

			try
			{
				using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
				{
					stream.Close();
				}
			}
			catch (IOException)
			{
				return true;
			}

			return false;
		}
		private bool ValidarCajasSinAsistencia(string fecha)
		{
			string query = $@"
			SELECT DISTINCT
			p.id_employee,
			CONCAT(e.v_lastNamePat,' ',e.v_lastNameMat,' ',e.v_name) AS NombreEmpleado
			FROM vw_PackedUniqueBoxUnionBackUp p
			LEFT JOIN Nom_AttendenceList a
			ON a.id_employee = p.id_employee
			AND CAST(a.d_attendence AS DATE) = CAST(p.d_scan AS DATE)
			LEFT JOIN Nom_Employees e
			ON e.id_employee = p.id_employee
			WHERE 
			a.id_employee IS NULL
			and p.id_employee is not null
			AND CAST(p.d_scan AS DATE) = '{fecha}'";

			DataTable dt = ClsQuerysDB.GetDataTable(query);

			if (dt.Rows.Count == 0)
				return true;

			StringBuilder empleados = new StringBuilder();

			foreach (DataRow row in dt.Rows)
			{
				empleados.AppendLine($"{row["id_employee"]} - {row["NombreEmpleado"]}");
			}

			string listaEmpleados = empleados.ToString();

			DialogResult result = MessageBox.Show(
			"Los siguientes empleados tienen cajas pero no asistencia:\n\n" +
			listaEmpleados +
			"\n¿Deseas abrir la lista en Bloc de notas?",
			"Validación de asistencia",
			MessageBoxButtons.YesNo,
			MessageBoxIcon.Warning
			);

			if (result == DialogResult.Yes)
			{
				string rutaArchivo = Path.Combine(Path.GetTempPath(), "EmpleadosSinAsistencia.txt");

				File.WriteAllText(rutaArchivo, listaEmpleados);

				Process.Start(new ProcessStartInfo
				{
					FileName = "notepad.exe",
					Arguments = $"\"{rutaArchivo}\"",
					UseShellExecute = true
				});
			}

			return false;
		}
		private void PintarCeldaGrid(object sender, DataGridViewCellPaintingEventArgs e)
		{
			var dgv = sender as DataGridView;
			if (dgv == null) return;

			//  COLORES SEGÚN TIPO
			System.Drawing.Color colorHeader = TipoNomina == "E"
				? System.Drawing.Color.FromArgb(34, 139, 34)     //  verde fuerte
				: System.Drawing.Color.FromArgb(102, 0, 153);    //  morado fuerte

			System.Drawing.Color fondoBase = TipoNomina == "E"
				? System.Drawing.Color.FromArgb(240, 255, 240)   // verde suave
				: System.Drawing.Color.FromArgb(245, 240, 255);  // morado suave

			System.Drawing.Color colorLinea = TipoNomina == "E"
				? System.Drawing.Color.FromArgb(180, 220, 180)
				: System.Drawing.Color.FromArgb(210, 180, 230);

			// 🔵 HEADER
			if (e.RowIndex == -1 && e.ColumnIndex >= 0)
			{
				using (SolidBrush brush = new SolidBrush(colorHeader))
				{
					e.Graphics.FillRectangle(brush, e.CellBounds);
				}

				TextRenderer.DrawText(
					e.Graphics,
					e.FormattedValue?.ToString() ?? "",
					new Font("Segoe UI", 10, FontStyle.Bold),
					e.CellBounds,
					System.Drawing.Color.White,
					TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
				);

				// línea header
				using (Pen pen = new Pen(colorLinea))
				{
					e.Graphics.DrawLine(
						pen,
						e.CellBounds.Right - 1,
						e.CellBounds.Top,
						e.CellBounds.Right - 1,
						e.CellBounds.Bottom
					);
				}

				e.Handled = true;
				return;
			}

			//  CELDAS
			if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
			{
				//  alternado con color base
				System.Drawing.Color fondo = (e.RowIndex % 2 == 0)
					? fondoBase
					: System.Drawing.Color.White;

				//  SIN SELECCIÓN
				using (SolidBrush brush = new SolidBrush(fondo))
				{
					e.Graphics.FillRectangle(brush, e.CellBounds);
				}

				TextRenderer.DrawText(
					e.Graphics,
					e.FormattedValue?.ToString() ?? "",
					new Font("Segoe UI", 10),
					e.CellBounds,
					System.Drawing.Color.Black,
					TextFormatFlags.Left | TextFormatFlags.VerticalCenter
				);

				//  líneas
				using (Pen pen = new Pen(colorLinea))
				{
					// vertical
					e.Graphics.DrawLine(
						pen,
						e.CellBounds.Right - 1,
						e.CellBounds.Top,
						e.CellBounds.Right - 1,
						e.CellBounds.Bottom
					);

					// horizontal
					e.Graphics.DrawLine(
						pen,
						e.CellBounds.Left,
						e.CellBounds.Bottom - 1,
						e.CellBounds.Right,
						e.CellBounds.Bottom - 1
					);
				}

				e.Handled = true;
			}
		}
		public void ActivarEstiloGrid(DataGridView dgv)
		{
			if (dgv == null) return;

			dgv.EnableHeadersVisualStyles = false;
			dgv.RowHeadersVisible = false;
			dgv.BorderStyle = BorderStyle.None;
			dgv.BackgroundColor = System.Drawing.Color.White;
			dgv.ColumnHeadersHeight = 40;

			dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);

			dgv.DefaultCellStyle.SelectionBackColor = dgv.DefaultCellStyle.BackColor;
			dgv.DefaultCellStyle.SelectionForeColor = dgv.DefaultCellStyle.ForeColor;

			dgv.CellBorderStyle = DataGridViewCellBorderStyle.None;

			dgv.CellPainting -= PintarCeldaGrid;
			dgv.CellPainting += PintarCeldaGrid;

			dgv.SelectionChanged += (s, e) => dgv.ClearSelection();
		}
	}
}



