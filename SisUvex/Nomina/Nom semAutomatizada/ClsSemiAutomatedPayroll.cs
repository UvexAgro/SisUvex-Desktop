using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
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
using static SisUvex.Nomina.Nom_semAutomatizada.FrmNominaExistente;
namespace SisUvex.Nomina.Nom_semAutomatizada

{
	internal class ClsSemiAutomatedPayroll
	{
		public FrmSemiAutomatedPayroll frm;
		ClsControls controlList;
		DataTable dtNomina;
		public string TipoNomina = "E";
		ClsFestivo clsF;
		ClsCierre clsC;
		ClsEstiloNomina clsEstilo;
	
		public void BeginForm()
		{
			clsF = new ClsFestivo();
			clsF.frm = frm;
			clsF.cls = this;

			clsC = new ClsCierre(); 
			clsC.frm = frm; 
			clsC.cls = this;

			clsEstilo = new ClsEstiloNomina();
			clsEstilo.frm = frm;
			clsEstilo.TipoNomina = TipoNomina;


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

			if (HayCambiosSueldos())
			{
				MessageBox.Show(
					"Se detectaron cambios en los sueldos.\n\n" +
					"Antes de generar el archivo CSV, haga clic en el botón 'Actualizar Sueldo' para guardar los cambios.",
					"Cambios sin guardar",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				return;
			}

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
				string sueldo = ClsValues.FormatZeros(dr["SueldoTotal"].ToString(), "0000.00");
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

			// Usuario que inició sesión
			string usuario = User.GetUserName(); 
			// Validar selección
			if (!frm.rbtEsparrago.Checked && !frm.rbtUva.Checked)
			{
				MessageBox.Show("Seleccione un tipo de nómina.");
				return "";
			}

			// ESPÁRRAGO
			if (frm.rbtEsparrago.Checked)
			{
				TipoNomina = "E";
				return $"EXEC dbo.sp_ReporteNomina_Esparrago '{fecha}', '{usuario}'";
			}

			// UVA
			if (frm.rbtUva.Checked)
			{
				TipoNomina = "U";
				return $"EXEC dbo.sp_ReporteNomina_Uva '{fecha}', '{usuario}'";
			}

			return "";
		}
		public void BtnCargarDatos()
		{
			TipoNomina = frm.rbtEsparrago.Checked ? "E" : "U";

			if (!ValidarTipoNomina(frm.dtpFecha.Value, TipoNomina))
				return;
			DateTime fecha = frm.dtpFecha.Value;

			bool existeNomina = ExisteNominaDiaria(fecha);
			bool esFestivo = clsF.EsFestivo(fecha);
			// YA EXISTE UNA NÓMINA
			if (existeNomina)
			{
				FrmNominaExistente frmExiste = new FrmNominaExistente();

				if (esFestivo)
					frmExiste.ConfigurarModo(ModoNomina.NominaFestivaExistente);
				else
					frmExiste.ConfigurarModo(ModoNomina.NominaExistente);

				frmExiste.CargarDatos(TipoNomina, fecha);

				// Verificar si la semana ACTUAL está cerrada
				DataTable dt = clsC.ObtenerInfoCierreSemana(fecha);

				if (dt.Rows.Count > 0)
				{
					bool cerrada = clsC.SemanaCerrada(
						dt.Rows[0]["id_season"].ToString(),
						dt.Rows[0]["c_sequence_per"].ToString(),
						TipoNomina);

					if (cerrada)
					{
						// No permite recalcular
						frmExiste.BloquearRecalculo();
					}
				}

				DialogResult r = frmExiste.ShowDialog();

				if (r == DialogResult.Cancel)
					return;

				// Mostrar Nómina
				if (r == DialogResult.No)
				{
					string fechaTexto = fecha.ToString("yyyy-MM-dd");

					string query = TipoNomina == "E"
						? $"EXEC sp_GetReporteNominaDiaria_Esparrago '{fechaTexto}'"
						: $"EXEC sp_GetReporteNominaDiaria_Uva '{fechaTexto}'";

					dtNomina = ClsQuerysDB.GetDataTable(query);

					frm.lblTipoProceso.Visible = false;
				}

				else if (r == DialogResult.Yes)
				{
					// Recalcular nómina normal
					string query = GetQueryNom();

					if (string.IsNullOrEmpty(query))
						return;

					dtNomina = ClsQuerysDB.GetDataTable(query);

					frm.lblTipoProceso.Visible = false;
				}
				else if (r == DialogResult.Retry)
				{
					// Recalcular nómina festiva
					FrmFestivo frmFestivo = new FrmFestivo();

					if (frmFestivo.ShowDialog() != DialogResult.OK)
						return;

					frm.TipoFestivoSeleccionado = frmFestivo.TipoSeleccionado;

					dtNomina = clsF.ObtenerNominaFestiva();

					frm.lblTipoProceso.Text =
						clsF.ObtenerDescripcionFestivo(frm.TipoFestivoSeleccionado);

					frm.lblTipoProceso.Visible = true;
				}
			}
			// NO EXISTE NÓMINa
			else
			{
				// Es festivo
				if (esFestivo)
				{
					FrmNominaExistente frmFestivo = new FrmNominaExistente();

					frmFestivo.ConfigurarModo(ModoNomina.FestivoInicial);
					frmFestivo.CargarDatos(TipoNomina, fecha);

					DialogResult r = frmFestivo.ShowDialog();

					if (r == DialogResult.Cancel)
						return;

					// Generar Normal
					if (r == DialogResult.No)
					{
						string query = GetQueryNom();

						if (string.IsNullOrEmpty(query))
							return;

						dtNomina = ClsQuerysDB.GetDataTable(query);

						frm.lblTipoProceso.Visible = false;
					}

					// Generar Festiva
					else if (r == DialogResult.Yes)
					{
						FrmFestivo frmTipo = new FrmFestivo();

						if (frmTipo.ShowDialog() != DialogResult.OK)
							return;

						frm.TipoFestivoSeleccionado = frmTipo.TipoSeleccionado;

						dtNomina = clsF.ObtenerNominaFestiva();

						frm.lblTipoProceso.Text =
							clsF.ObtenerDescripcionFestivo(frm.TipoFestivoSeleccionado);

						frm.lblTipoProceso.Visible = true;
					}
				}

				// No es festivo
				else
				{
					string query = GetQueryNom();

					if (string.IsNullOrEmpty(query))
						return;

					dtNomina = ClsQuerysDB.GetDataTable(query);

					frm.lblTipoProceso.Visible = false;
				}
			}
			// MOSTRAR DATOS
			if (dtNomina == null || dtNomina.Rows.Count == 0)
			{
				MessageBox.Show(
					"No existen registros para la fecha seleccionada.",
					"Sistema",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);
				return;
			}

			frm.dgvEmployee.Visible = false;
			frm.dgvEmployee.DataSource = dtNomina;

			clsEstilo.AplicarColores(TipoNomina);

			ActualizarResumen();

			foreach (DataGridViewColumn col in frm.dgvEmployee.Columns)
				col.ReadOnly = true;

			frm.dgvEmployee.Columns["SueldoTotal"].ReadOnly = false;

			GuardarSueldosOriginales();

			foreach (DataGridViewRow row in frm.dgvEmployee.Rows)
			{
				if (!row.IsNewRow)
					row.Cells["SueldoTotal"].Tag = row.Cells["SueldoTotal"].Value;
			}

			clsEstilo.ActivarEstiloGrid(frm.dgvEmployee);
			frm.dgvEmployee.Visible = true;
			clsC.ValidarSemanaCerrada();
		}
		public bool ValidarTipoNomina(DateTime fecha, string tipoNomina)
		{
			SQLControl sql = new SQLControl();

			sql.OpenConectionWrite();

			string query = @"
			SELECT COUNT(*)
			FROM Nom_AttendenceList
			WHERE CAST(d_attendence AS DATE) = @Fecha
			AND c_payrollType = @TipoNomina";

			SqlCommand cmd = new SqlCommand(query, sql.cnn);
			cmd.Parameters.AddWithValue("@Fecha", fecha.Date);
			cmd.Parameters.AddWithValue("@TipoNomina", tipoNomina);

			int total = Convert.ToInt32(cmd.ExecuteScalar());

			sql.CloseConectionWrite();

			if (total == 0)
			{
				MessageBox.Show(
					$"No existe asistencia de {(tipoNomina == "E" ? "Espárrago" : "Uva")} para la fecha seleccionada.",
					"Sistema",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				return false;
			}

			return true;
		}
		public DataTable ObtenerInfoNomina(DateTime fecha, string tipo)
		{
			SQLControl sql = new SQLControl();

			sql.OpenConectionWrite();

			SqlCommand cmd = new SqlCommand("sp_GetInfoNomina", sql.cnn);
			cmd.CommandType = CommandType.StoredProcedure;

			cmd.Parameters.AddWithValue("@Fecha", fecha.Date);
			cmd.Parameters.AddWithValue("@Tipo", tipo);

			SqlDataAdapter da = new SqlDataAdapter(cmd);
			DataTable dt = new DataTable();
			da.Fill(dt);

			sql.CloseConectionWrite();

			return dt;
		}
		public void GuardarSueldosOriginales()
		{
			foreach (DataGridViewRow row in frm.dgvEmployee.Rows)
			{
				if (row.IsNewRow)
					continue;

				row.Cells["SueldoTotal"].Tag = row.Cells["SueldoTotal"].Value;
			}
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
		
		public bool HayCambiosSueldos()
		{
			foreach (DataGridViewRow row in frm.dgvEmployee.Rows)
			{
				if (row.IsNewRow)
					continue;

				decimal original = Convert.ToDecimal(row.Cells["SueldoTotal"].Tag);
				decimal actual = Convert.ToDecimal(row.Cells["SueldoTotal"].Value);

				if (original != actual)
					return true;
			}

			return false;
		}
		public bool GuardarCambiosSueldos()
		{
			try
			{
				SQLControl sql = new SQLControl();
				sql.OpenConectionWrite();

				bool huboCambios = false;

				// Seleccionar el procedimiento según la nómina
				string procedimiento = TipoNomina == "E"
				   ? "sp_UpdateHistNominaSueldoEsparrago"
				   : "sp_UpdateHistNominaSueldoUva";

				foreach (DataGridViewRow row in frm.dgvEmployee.Rows)
				{
					if (row.IsNewRow)
						continue;

					decimal sueldoOriginal = Convert.ToDecimal(row.Cells["SueldoTotal"].Tag);
					decimal sueldoNuevo = Convert.ToDecimal(row.Cells["SueldoTotal"].Value);

					// Si no cambió el sueldo, continúa
					if (sueldoOriginal == sueldoNuevo)
						continue;

					using (System.Data.SqlClient.SqlCommand cmd =
						new System.Data.SqlClient.SqlCommand(procedimiento, sql.cnn))
					{
						cmd.CommandType = CommandType.StoredProcedure;

						cmd.Parameters.AddWithValue("@Fecha",
							Convert.ToDateTime(row.Cells["Fecha"].Value));

						cmd.Parameters.AddWithValue("@IdEmpleado",
							Convert.ToInt32(row.Cells["Codigo"].Value));

						cmd.Parameters.AddWithValue("@CodigoActividad",
							row.Cells["CodigoActividad"].Value.ToString());

						cmd.Parameters.AddWithValue("@Sueldo",
							sueldoNuevo);
						cmd.Parameters.AddWithValue("@Usuario", User.GetUserName());

						cmd.ExecuteNonQuery();

						row.Cells["SueldoTotal"].Tag = sueldoNuevo;

						DataGridViewCell cell = row.Cells["SueldoTotal"];

						cell.Style.BackColor = System.Drawing.Color.White;
						cell.Style.SelectionBackColor = frm.dgvEmployee.DefaultCellStyle.SelectionBackColor;

						cell.Style.ForeColor = System.Drawing.Color.Black;
						cell.Style.SelectionForeColor = frm.dgvEmployee.DefaultCellStyle.SelectionForeColor;

						cell.Style.Font = frm.dgvEmployee.Font;
					}

					// Actualizar el Tag para indicar que ya fue guardado
					row.Cells["SueldoTotal"].Tag = sueldoNuevo;

					huboCambios = true;
				}

				sql.CloseConectionWrite();

				if (huboCambios)
				{
					MessageBox.Show(
						"Los cambios de sueldo se guardaron correctamente.",
						"Sistema",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information);
				}
				else
				{
					MessageBox.Show(
						"No existen cambios para guardar.",
						"Sistema",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information);
				}

				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Guardar cambios");
				return false;
			}
		}
		public bool ExisteNominaDiaria(DateTime fecha)
		{
			string tabla = TipoNomina == "E"
				? "HistNom_ReporteDiarioEsparrago"
				: "HistNom_ReporteDiarioUva";

			string query = $@"
			SELECT COUNT(*)
			FROM {tabla}
			WHERE Fecha = '{fecha:yyyy-MM-dd}'";

			int registros = Convert.ToInt32(ClsQuerysDB.GetData(query));

			return registros > 0;
		}
		public void MostrarEstadoCierre()
		{
			string tipoNomina =
				frm.rbtEsparrago.Checked ? "E" : "U";

			DataRow semana =
				clsC.ObtenerSemanaPendiente(
					frm.dtpFecha.Value,
					tipoNomina);

			if (semana != null)
			{
				DateTime inicio =
					Convert.ToDateTime(
						semana["d_startDate_per"]);

				DateTime fin =
					Convert.ToDateTime(
						semana["d_endDate_per"]);

				frm.lblAvisoCierre.Text =
					$"⚠ Debe cerrar la semana del " +
					$"{inicio:dd/MM/yyyy} al {fin:dd/MM/yyyy}";

				frm.lblAvisoCierre.Visible = true;

				frm.btncargar.Enabled = false;
			}
			else
			{
				frm.lblAvisoCierre.Visible = false;

				frm.btncargar.Enabled = true;
			}
			MostrarEstadoNomina();
		}
		public void MostrarEstadoNomina()
		{
			string tipoNomina =
				frm.rbtEsparrago.Checked ? "E" : "U";

			DataTable dt =
				clsC.ObtenerInfoCierreSemana(frm.dtpFecha.Value);

			if (dt.Rows.Count == 0)
			{
				frm.lblEstado.Text = "SIN INFORMACIÓN";
				frm.lblEstado.ForeColor = System.Drawing.Color.Gray;
				frm.pbCirculo.Image = null;

				return;
			}

			DataRow row = dt.Rows[0];

			bool cerrada = clsC.SemanaCerrada(
				row["id_season"].ToString(),
				row["c_sequence_per"].ToString(),
				tipoNomina);

			ActualizarEstadoNomina(cerrada);
		}

		private void ActualizarEstadoNomina(bool cerrada)
		{
			if (cerrada)
			{
				frm.lblEstado.Text = "CERRADA";
				frm.lblEstado.ForeColor =
					System.Drawing.Color.FromArgb(255, 100, 100);

				frm.pbCirculo.Image =
					Properties.Resources.circuloRojo;
			}
			else
			{
				frm.lblEstado.Text = "ABIERTA";
				frm.lblEstado.ForeColor =
					System.Drawing.Color.FromArgb(110, 230, 130);

				frm.pbCirculo.Image =
					Properties.Resources.circuloVerde;
			}
		}
		private void ActualizarResumen()
		{
			if (frm.dgvEmployee == null)
				return;

			int totalEmpleados = 0;
			decimal totalCajas = 0;

			foreach (DataGridViewRow fila in frm.dgvEmployee.Rows)
			{
				if (fila.IsNewRow)
					continue;

				totalEmpleados++;

				decimal cajas = 0;

				decimal.TryParse(
					Convert.ToString(
						fila.Cells["TotalCajas"].Value),
					out cajas);

				totalCajas += cajas;
			}

			// Mostrar empleados
			frm.lblEmpleados.Text =
				totalEmpleados.ToString("N0");

			// Mostrar cajas
			frm.lblCajas.Text =
				totalCajas.ToString("N0");
		}
	}
}



