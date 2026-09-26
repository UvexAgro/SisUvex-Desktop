using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Catalogos.Metods.Values;
using SisUvex.Configuracion;

namespace SisUvex.Nomina.Nom_SemAutomaticaCampo
{
	public class ClsNomina
	{
		public FrmNomina frm;
		private bool cargando = false;
		public class CuadrillaItem
		{
			public string ID { get; set; }
			public string Codigo { get; set; }
			public string Nombre { get; set; }

			public override string ToString()
			{
				return $"{Codigo} - {Nombre}";
			}
		}
		public void CargarCuadrillaCampoCheck(ClsListaCuadrillas lista)
		{
			cargando = true;

			try
			{
				DataTable dt =
					CboCuadrillaCampo();

				lista.Limpiar();

				foreach (DataRow row in dt.Rows)
				{
					CuadrillaItem cuadrilla =
						new CuadrillaItem
						{
							ID =
								row["ID"].ToString(),

							Codigo =
								row["Código"].ToString(),

							Nombre =
								row["Nombre"].ToString()
						};

					lista.AgregarCuadrilla(
						cuadrilla);
				}
			}
			finally
			{
				cargando = false;
			}
		}

		public void CargarCuadrillaCampo(ComboBox combo)
		{
			cargando = true;

			try
			{
				DataTable dt = CboCuadrillaCampo();

				DataRow dr = dt.NewRow();
				dr["ID"] = "";
				dr["Código"] = "";
				dr["Nombre"] = " ------ Selecciona ------ ";

				dt.Rows.InsertAt(dr, 0);

				combo.DataSource = dt.Copy();
				combo.DisplayMember = "Nombre";
				combo.ValueMember = "ID";
				combo.SelectedIndex = 0;
			}
			finally
			{
				cargando = false;
			}
		}
		public DataTable CboCuadrillaCampo()
		{
			SQLControl sql = new SQLControl();
			DataTable dt = new DataTable();

			sql.OpenConectionWrite();

			string query = @"
			SELECT 
				g.id_workGroup AS ID,
				g.c_order AS Código,
				g.v_nameWorkGroup AS Nombre
			FROM Nom_WorkGroup g
			WHERE g.c_active = 1
			ORDER BY
				CASE 
					WHEN g.c_order IS NULL OR g.c_order = '' THEN 1
					ELSE 0
				END,
				g.c_order,
				g.id_workGroup";

			SqlCommand cmd =
				new SqlCommand(query, sql.cnn);

			SqlDataAdapter da =
				new SqlDataAdapter(cmd);

			da.Fill(dt);

			sql.CloseConectionWrite();

			return dt;
		}
		public List<string> ObtenerIdsCuadrillasSeleccionadas()
		{
			return frm.cuadrillasSeleccionadas
				.Cast<CuadrillaItem>()
				.Select(x => x.ID)
				.ToList();
		}
		public void ConsultarNomina()
		{
			SQLControl sql = new SQLControl();

			try
			{
				DateTime fecha =
					frm.dtpFecha.Value.Date;

				// =====================================================
				// OBTENER CUADRILLAS SELECCIONADAS
				// =====================================================

				List<string> idsCuadrillas =
					ObtenerIdsCuadrillasSeleccionadas();

				// =====================================================
				// VALIDAR QUE HAYA SELECCIÓN
				// =====================================================

				if (idsCuadrillas.Count == 0)
				{
					MessageBox.Show(
						"Seleccione al menos una cuadrilla.",
						"Cuadrillas",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information
					);

					return;
				}

				// =====================================================
				// VALIDAR TODAS LAS CUADRILLAS
				// =====================================================

				foreach (string idCuadrilla in idsCuadrillas)
				{
					bool datosCompletos =
						ValidarLoteYActividad(
							fecha,
							idCuadrilla
						);

					if (!datosCompletos)
					{
						return;
					}
				}

				// =====================================================
				// ABRIR CONEXIÓN
				// =====================================================

				sql.OpenConectionWrite();

				DataTable dtFinal =
					new DataTable();

				// =====================================================
				// CONSULTAR CADA CUADRILLA
				// =====================================================

				foreach (string idCuadrilla in idsCuadrillas)
				{
					using (SqlCommand cmd =
						new SqlCommand(
							"sp_ReporteNominadeCampo",
							sql.cnn))
					{
						cmd.CommandType =
							CommandType.StoredProcedure;

						cmd.Parameters.Add(
							"@FechaNomina",
							SqlDbType.Date
						).Value = fecha;

						cmd.Parameters.Add(
							"@IdWorkGroup",
							SqlDbType.VarChar,
							3
						).Value = idCuadrilla;

						using (SqlDataAdapter da =
							new SqlDataAdapter(cmd))
						{
							DataTable dt =
								new DataTable();

							da.Fill(dt);

							// =========================================
							// AGREGAR RESULTADOS
							// =========================================

							if (dtFinal.Columns.Count == 0)
							{
								dtFinal = dt.Clone();

								// Columna interna para saber a qué cuadrilla pertenece cada registro
								dtFinal.Columns.Add(
									"id_workGroup_CSV",
									typeof(string));
							}

							foreach (DataRow row in dt.Rows)
							{
								dtFinal.ImportRow(row);

								// Guardar el ID real de la cuadrilla
								dtFinal.Rows[dtFinal.Rows.Count - 1]["id_workGroup_CSV"] =
									idCuadrilla;
							}
						}
					}
				}

				// =====================================================
				// MOSTRAR RESULTADO
				// =====================================================

				frm.dgvNomina.DataSource =
					dtFinal;

				ConfigurarDgvNomina();

				frm.dgvNomina.ClearSelection();
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error al consultar la nómina:\n" +
					ex.Message,
					"Consulta de nómina",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}
		private void ConfigurarDgvNomina()
		{
			DataGridView dgv = frm.dgvNomina;

			dgv.AutoGenerateColumns = true;
			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToDeleteRows = false;
			dgv.ReadOnly = true;

			// Fondo
			dgv.BackgroundColor = Color.White;
			dgv.BorderStyle = BorderStyle.None;

			// Filas
			dgv.RowHeadersVisible = false;
			dgv.RowTemplate.Height = 32;

			// Selección
			dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgv.MultiSelect = false;

			// ENCABEZADO
			dgv.EnableHeadersVisualStyles = false;

			dgv.ColumnHeadersDefaultCellStyle.BackColor =
				Color.FromArgb(47, 117, 163);

			dgv.ColumnHeadersDefaultCellStyle.ForeColor =
				Color.White;

			dgv.ColumnHeadersDefaultCellStyle.Font =
				new Font("Segoe UI", 9F, FontStyle.Bold);

			dgv.ColumnHeadersDefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			// IMPORTANTE:
			// Mantiene el encabezado azul aunque selecciones una columna
			dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor =
				Color.FromArgb(47, 117, 163);

			dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor =
				Color.White;

			dgv.ColumnHeadersHeight = 38;

			// Filas normales
			dgv.DefaultCellStyle.Font =
				new Font("Segoe UI", 9F);

			dgv.DefaultCellStyle.ForeColor =
				Color.FromArgb(35, 55, 77);

			dgv.DefaultCellStyle.BackColor =
				Color.White;

			// Filas alternadas
			dgv.AlternatingRowsDefaultCellStyle.BackColor =
				Color.FromArgb(241, 247, 252);

			// Selección
			dgv.DefaultCellStyle.SelectionBackColor =
				Color.FromArgb(31, 111, 170);

			dgv.DefaultCellStyle.SelectionForeColor =
				Color.White;

			// Líneas
			dgv.GridColor =
				Color.FromArgb(220, 230, 238);

			dgv.CellBorderStyle =
				DataGridViewCellBorderStyle.SingleHorizontal;

			// Ajuste de columnas
			dgv.AutoSizeColumnsMode =
				DataGridViewAutoSizeColumnsMode.Fill;
		}
		public void GenerarArchivoCsv()
		{
			DataTable dt = GetDtCSV();

			if (dt == null || dt.Rows.Count == 0)
				return;

			string separador =
				CultureInfo.CurrentCulture.TextInfo.ListSeparator;

			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Filter = "Archivo CSV (*.csv)|*.csv";

			DateTime fechaNomina =
				Convert.ToDateTime(dt.Rows[0]["Fecha"]);

			sfd.FileName =
				$"Nomina{fechaNomina:yyyy-MM-dd}.csv";

			if (sfd.ShowDialog() != DialogResult.OK)
				return;

			// =====================================================
			// GENERAR ARCHIVO CSV
			// =====================================================

			using (StreamWriter sw = new StreamWriter(
				sfd.FileName,
				false,
				Encoding.UTF8))
			{
				foreach (DataRow row in dt.Rows)
				{
					string[] campos = row.ItemArray.Select(campo =>
					{
						string valor = campo?.ToString() ?? "";

						if (valor.Contains(separador) ||
							valor.Contains("\""))
						{
							valor = valor.Replace("\"", "\"\"");
							valor = $"\"{valor}\"";
						}

						return valor;

					}).ToArray();

					sw.WriteLine(
						string.Join(separador, campos));
				}
			}

			// =====================================================
			// VERIFICAR QUE EL ARCHIVO SE HAYA CREADO
			// =====================================================

			if (!File.Exists(sfd.FileName))
			{
				MessageBox.Show(
					$"El archivo no se pudo guardar:\n{sfd.FileName}",
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);

				return;
			}

			// =====================================================
			// OBTENER CUADRILLAS DEL DGV
			// =====================================================

			DataTable dtNomina =
				frm.dgvNomina.DataSource as DataTable;

			if (dtNomina == null ||
				!dtNomina.Columns.Contains("id_workGroup_CSV"))
			{
				MessageBox.Show(
					"El listado de nómina no contiene el ID de las cuadrillas.",
					"CSV",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return;
			}

			List<string> idsCuadrillas =
				dtNomina.AsEnumerable()
					.Select(r =>
						r["id_workGroup_CSV"]
							?.ToString()
							.Trim())
					.Where(x =>
						!string.IsNullOrWhiteSpace(x))
					.Distinct()
					.ToList();

			// =====================================================
			// REGISTRAR CSV GENERADO
			// =====================================================

			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				foreach (string idCuadrilla in idsCuadrillas)
				{
					using (SqlCommand cmd =
						new SqlCommand(
							"sp_AddCsvGenerated",
							sql.cnn))
					{
						cmd.CommandType =
							CommandType.StoredProcedure;

						cmd.Parameters.Add(
							"@IdWorkGroup",
							SqlDbType.Char,
							3
						).Value = idCuadrilla;

						cmd.Parameters.Add(
							"@FechaNomina",
							SqlDbType.Date
						).Value = fechaNomina.Date;

						cmd.ExecuteNonQuery();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"El CSV se generó correctamente, pero no se pudo registrar " +
					"el estado de las cuadrillas:\n\n" +
					ex.Message,
					"Registro de CSV",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);
			}
			finally
			{
				sql.CloseConectionWrite();
			}

			// =====================================================
			// MENSAJE FINAL
			// =====================================================

			DialogResult result = MessageBox.Show(
				"Reporte en CSV generado correctamente.\n\n" +
				"¿Deseas abrir el archivo?",
				"Reporte generado",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Information);

			if (result == DialogResult.Yes)
			{
				System.Diagnostics.Process.Start(
					new System.Diagnostics.ProcessStartInfo
					{
						FileName = "notepad.exe",
						Arguments = $"\"{sfd.FileName}\"",
						UseShellExecute = true
					});
			}
		}
		private DataTable GetDtCSV()
		{
			DataTable dtNomina = frm.dgvNomina.DataSource as DataTable;

			if (dtNomina == null || dtNomina.Rows.Count == 0)
			{
				MessageBox.Show(
					"No hay datos para generar.",
					"Reporte CSV",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				return null;
			}

			foreach (DataColumn col in dtNomina.Columns)
			{
				Console.WriteLine(col.ColumnName);
			}

			// Valores de los TextBox
			string referencia = frm.txbReferencia.Text;
			string jornada = frm.txbJornada.Text;
			string destajo = frm.txbDestajo.Text;

			DataTable dtCsv = new DataTable();

			dtCsv.Columns.Add("Fecha", typeof(string));
			dtCsv.Columns.Add("Referencia", typeof(string));
			dtCsv.Columns.Add("Codigo", typeof(string));
			dtCsv.Columns.Add("Sueldo", typeof(string));
			dtCsv.Columns.Add("Lote", typeof(string));
			dtCsv.Columns.Add("Actividad", typeof(string));
			dtCsv.Columns.Add("TotalCajas", typeof(string));
			dtCsv.Columns.Add("HorasTrabajadas", typeof(string));

			foreach (DataRow dr in dtNomina.Rows)
			{
				string fechaFormateada =
					Convert.ToDateTime(dr["Fecha"])
					.ToString("yyyy/MM/dd");

				string sueldo =
					ClsValues.FormatZeros(
						dr["Total"].ToString(),
						"0000.00");

				dtCsv.Rows.Add(
					fechaFormateada,       // Fecha
					referencia,            // Referencia
					dr["Código Empleado"], // Codigo
					sueldo,                // Sueldo
					dr["Código Lote"],     // Lote
					dr["Código Actividad"],// Actividad
					destajo,               // TotalCajas
					jornada                // HorasTrabajadas
				);
			}

			return dtCsv;
		}
		public void CargarLugarPago(ComboBox combo)
		{
			cargando = true;

			DataTable dt = CboLugarPago();

			DataRow dr = dt.NewRow();
			dr["Código"] = "";
			dr["Nombre"] = " ------ selecciona ------ ";
			dt.Rows.InsertAt(dr, 0);

			combo.DataSource = dt.Copy();
			combo.DisplayMember = "Nombre";
			combo.ValueMember = "Código";
			combo.SelectedIndex = 0;

			cargando = false;
		}
		public DataTable CboLugarPago()
		{
			SQLControl sql = new SQLControl();
			DataTable dt = new DataTable();

			sql.OpenConectionWrite();

			string query = @"
			SELECT 
				p.id_placePayment AS Código,
				p.id_placePayment + ' - ' + p.v_namePlace AS Nombre
			FROM Nom_PlacePayment p
			WHERE p.c_activePlace = 1
			ORDER BY p.id_placePayment";

			SqlCommand cmd = new SqlCommand(query, sql.cnn);

			SqlDataAdapter da = new SqlDataAdapter(cmd);
			da.Fill(dt);

			sql.CloseConectionWrite();

			return dt;
		}
		public void CargarSemanas()
		{
			SQLControl sql = new SQLControl();

			string query = @"
		SELECT
			id_period,
			c_sequence_per,
			d_startDate_per,
			d_endDate_per,
			v_name_per
		FROM dbo.Payroll_AttendancePeriod
		WHERE c_active = '1'
		ORDER BY d_startDate_per DESC";

			DataTable dt = new DataTable();

			try
			{
				sql.OpenConectionWrite();

				using (SqlCommand cmd = new SqlCommand(query, sql.cnn))
				using (SqlDataAdapter da = new SqlDataAdapter(cmd))
				{
					da.Fill(dt);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error al cargar las semanas:\n" + ex.Message,
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			finally
			{
				sql.CloseConectionWrite();
			}

			// Crear texto que se mostrará en el ComboBox
			if (!dt.Columns.Contains("SemanaMostrar"))
			{
				dt.Columns.Add("SemanaMostrar", typeof(string));
			}

			foreach (DataRow row in dt.Rows)
			{
				DateTime fechaInicio =
					Convert.ToDateTime(row["d_startDate_per"]).Date;

				DateTime fechaFin =
					Convert.ToDateTime(row["d_endDate_per"]).Date;

				row["SemanaMostrar"] =
					"Semana " + row["c_sequence_per"].ToString().Trim() +
					" | " +
					fechaInicio.ToString("dd/MM/yyyy") +
					" - " +
					fechaFin.ToString("dd/MM/yyyy");
			}

			frm.cboSemana.DataSource = null;

			frm.cboSemana.DisplayMember = "SemanaMostrar";
			frm.cboSemana.ValueMember = "c_sequence_per";

			frm.cboSemana.DataSource = dt;

			SeleccionarSemanaActual(dt);
		}

		private void SeleccionarSemanaActual(DataTable dt)
		{
			DateTime fechaActual = DateTime.Today;

			foreach (DataRow row in dt.Rows)
			{
				DateTime fechaInicio =
					Convert.ToDateTime(
						row["d_startDate_per"]).Date;

				DateTime fechaFin =
					Convert.ToDateTime(
						row["d_endDate_per"]).Date;

				if (fechaActual >= fechaInicio &&
					fechaActual <= fechaFin)
				{
					frm.cboSemana.SelectedValue =
						row["c_sequence_per"].ToString().Trim();

					return;
				}
			}

			frm.cboSemana.SelectedIndex = -1;
		}
		public DataTable ConsultarNominaSemana()
		{
			string semana = frm.cboSemana.SelectedValue?.ToString().Trim() ?? "";
			string lugarPago = "";
			string cuadrilla = "";

			if (frm.cboLugarPago.SelectedIndex > 0)
			{
				lugarPago = frm.cboLugarPago.SelectedValue?.ToString().Trim() ?? "";
			}
			else if (frm.cboCuadrillaRevisar.SelectedIndex > 0)
			{
				cuadrilla = frm.cboCuadrillaRevisar.SelectedValue?.ToString().Trim() ?? "";
			}

			var parameters = new Dictionary<string, object>
			{
				["@Semana"] = semana,
				["@LugarPago"] = lugarPago,
				["@Cuadrilla"] = cuadrilla
			};

			string query = @"
			 USE [SisUvex];

			EXEC dbo.sp_RevisarNomina
            @Semana,
            @LugarPago,
            @Cuadrilla;";

			return ClsQuerysDB.ExecuteParameterizedQuery(query, parameters);
		}
		private bool ValidarLoteYActividad(DateTime fecha, string idCuadrilla)
		{
			List<string> empleadosConError = new List<string>();

			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				// =====================================================
				// OBTENER LA SEMANA CORRESPONDIENTE A LA FECHA
				// =====================================================

				string querySemana = @"
			SELECT TOP 1
				c_sequence_per
			FROM dbo.Payroll_AttendancePeriod
			WHERE @Fecha BETWEEN d_startDate_per AND d_endDate_per
			  AND c_active = 1
			ORDER BY d_startDate_per DESC;
		";

				string semana = "";

				using (SqlCommand cmdSemana =
					new SqlCommand(querySemana, sql.cnn))
				{
					cmdSemana.Parameters.Add(
						"@Fecha",
						SqlDbType.Date).Value = fecha;

					object resultado =
						cmdSemana.ExecuteScalar();

					if (resultado != null &&
						resultado != DBNull.Value)
					{
						semana =
							resultado.ToString().Trim();
					}
				}

				if (string.IsNullOrWhiteSpace(semana))
				{
					MessageBox.Show(
						"No se encontró una semana para la fecha seleccionada.",
						"Validación",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);

					return false;
				}


				// =====================================================
				// DETERMINAR EL PREFIJO SEGÚN EL DÍA
				// =====================================================

				string prefijo;

				switch (fecha.DayOfWeek)
				{
					case DayOfWeek.Friday:
						prefijo = "vie";
						break;

					case DayOfWeek.Saturday:
						prefijo = "sab";
						break;

					case DayOfWeek.Sunday:
						prefijo = "dom";
						break;

					case DayOfWeek.Monday:
						prefijo = "lun";
						break;

					case DayOfWeek.Tuesday:
						prefijo = "mar";
						break;

					case DayOfWeek.Wednesday:
						prefijo = "mie";
						break;

					case DayOfWeek.Thursday:
						prefijo = "jue";
						break;

					default:
						return false;
				}


				// =====================================================
				// CONSULTA DE VALIDACIÓN
				// =====================================================

				string query = $@"

			SELECT
				aw.id_employee,

				emp.v_lastNamePat,
				emp.v_lastNameMat,
				emp.v_name,

				aw.id_activity_{prefijo},
				aw.id_lot_{prefijo},

				-- ID REAL DE LA CUADRILLA
				aw.id_workGroup_{prefijo} AS id_workGroup,

				-- DATOS DE LA CUADRILLA
				wg.c_order,
				wg.v_nameWorkGroup

			FROM dbo.Nom_EmployeeAttendanceWeekly aw

			LEFT JOIN dbo.Nom_Employees emp
				ON emp.id_employee = aw.id_employee

			LEFT JOIN dbo.Nom_WorkGroup wg
				ON wg.id_workGroup =
				   aw.id_workGroup_{prefijo}

			WHERE TRY_CONVERT(INT, aw.c_sequence_per) =
				  TRY_CONVERT(INT, @Semana)

			  AND aw.b_{prefijo} = 1
		";


				// =====================================================
				// SI SE SELECCIONÓ CUADRILLA
				// =====================================================

				if (!string.IsNullOrWhiteSpace(idCuadrilla))
				{
					query += $@"

				AND aw.id_workGroup_{prefijo} =
					@IdWorkGroup
			";
				}


				// =====================================================
				// EJECUTAR CONSULTA
				// =====================================================

				DataTable dtValidacion =
					new DataTable();

				using (SqlCommand cmd =
					new SqlCommand(query, sql.cnn))
				{
					cmd.Parameters.Add(
						"@Semana",
						SqlDbType.VarChar,
						4).Value = semana;

					if (!string.IsNullOrWhiteSpace(idCuadrilla))
					{
						cmd.Parameters.Add(
							"@IdWorkGroup",
							SqlDbType.VarChar,
							4).Value =
								idCuadrilla;
					}

					using (SqlDataAdapter da =
						new SqlDataAdapter(cmd))
					{
						da.Fill(dtValidacion);
					}
				}


				// =====================================================
				// REVISAR EMPLEADOS
				// =====================================================

				foreach (DataRow row in dtValidacion.Rows)
				{
					// =================================================
					// EMPLEADO
					// =================================================

					string folio =
						row["id_employee"]?
						.ToString()
						.Trim() ?? "";

					string nombre =
						(
							row["v_lastNamePat"]?
							.ToString()
							.Trim() + " " +

							row["v_lastNameMat"]?
							.ToString()
							.Trim() + " " +

							row["v_name"]?
							.ToString()
							.Trim()
						).Trim();


					// =================================================
					// ACTIVIDAD
					// =================================================

					string actividad =
						row[$"id_activity_{prefijo}"]?
						.ToString()
						.Trim() ?? "";


					// =================================================
					// LOTE
					// =================================================

					string lote =
						row[$"id_lot_{prefijo}"]?
						.ToString()
						.Trim() ?? "";


					// =================================================
					// CUADRILLA
					// =================================================

					string codigoCuadrilla =
						row["c_order"]?
						.ToString()
						.Trim() ?? "";

					string nombreCuadrilla =
						row["v_nameWorkGroup"]?
						.ToString()
						.Trim() ?? "";

					string cuadrilla =
						$"{codigoCuadrilla} - {nombreCuadrilla}";


					// =================================================
					// VALIDAR
					// =================================================

					bool faltaActividad =
						string.IsNullOrWhiteSpace(actividad);

					bool faltaLote =
						string.IsNullOrWhiteSpace(lote);


					if (faltaActividad ||
						faltaLote)
					{
						string faltante;

						if (faltaActividad &&
							faltaLote)
						{
							faltante =
								"Actividad y Lote";
						}
						else if (faltaActividad)
						{
							faltante =
								"Actividad";
						}
						else
						{
							faltante =
								"Lote";
						}


						// =================================================
						// AGREGAR EMPLEADO CON ERROR
						// =================================================

						empleadosConError.Add(
							$"{folio} - {nombre} " +
							$"→ Cuadrilla: {cuadrilla} " +
							$"→ Falta {faltante}"
						);
					}
				}


				// =====================================================
				// SI HAY ERRORES
				// =====================================================

				if (empleadosConError.Count > 0)
				{
					StringBuilder mensaje =
						new StringBuilder();

					mensaje.AppendLine(
						"NO SE PUEDE GENERAR LA NÓMINA."
					);

					mensaje.AppendLine();

					mensaje.AppendLine(
						$"Fecha: {fecha:dd/MM/yyyy}"
					);

					mensaje.AppendLine();

					mensaje.AppendLine(
						"Los siguientes empleados no tienen " +
						"Lote y/o Actividad:"
					);

					mensaje.AppendLine();


					foreach (string empleado
						in empleadosConError)
					{
						mensaje.AppendLine(
							"• " + empleado);
					}


					MessageBox.Show(
						mensaje.ToString(),
						"Información incompleta",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);

					return false;
				}


				// =====================================================
				// TODO CORRECTO
				// =====================================================

				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error al validar Lote y Actividad:\n" +
					ex.Message,
					"Validación",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);

				return false;
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}
		public void CargarCuadrillasConCsv(ListBox ckbCSV,DateTime fecha)
		{
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				string query = @"
			SELECT DISTINCT
				wg.c_order,
				wg.v_nameWorkGroup
			FROM Nom_CsvGenerated cg
			INNER JOIN Nom_WorkGroup wg
				ON cg.id_workGroup = wg.id_workGroup
			WHERE CONVERT(date, cg.d_fechaNomina) = @Fecha
			ORDER BY wg.c_order";

				using (SqlCommand cmd =
					new SqlCommand(query, sql.cnn))
				{
					cmd.Parameters.Add(
						"@Fecha",
						SqlDbType.Date).Value =
						fecha.Date;

					using (SqlDataReader dr =
						cmd.ExecuteReader())
					{
						ckbCSV.Items.Clear();

						while (dr.Read())
						{
							string codigo =
								dr["c_order"]?.ToString()?.Trim() ?? "";

							string nombre =
								dr["v_nameWorkGroup"]?.ToString()?.Trim() ?? "";

							ckbCSV.Items.Add(
								$"{codigo} - {nombre}");
						}
					}
				}
				frm.pnlCSV.Visible = ckbCSV.Items.Count > 0;

				frm.lblCuadrillas.Text =ckbCSV.Items.Count.ToString();
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}
	}
}