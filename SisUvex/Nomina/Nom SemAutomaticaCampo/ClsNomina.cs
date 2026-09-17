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
		public bool PuedeGenerarReporte { get; private set; } = false;
		public void CargarCuadrillaCampo(ComboBox combo)
		{
			cargando = true;

			DataTable dt = CboCuadrillaCampo();

			DataRow dr = dt.NewRow();
			dr["Código"] = "";
			dr["Nombre"] = " ------ Selecciona ------ ";
			dt.Rows.InsertAt(dr, 0);

			combo.DataSource = dt.Copy();
			combo.DisplayMember = "Nombre";
			combo.ValueMember = "Código";
			combo.SelectedIndex = 0;

			cargando = false;
		}
		public DataTable CboCuadrillaCampo()
		{
			SQLControl sql = new SQLControl();
			DataTable dt = new DataTable();

			sql.OpenConectionWrite();

			string query = @"
			SELECT 
				g.id_workGroup AS Código,
				g.id_workGroup + ' - ' + g.v_nameWorkGroup AS Nombre
			FROM Nom_WorkGroup g
			WHERE g.c_active = 1
			ORDER BY g.id_workGroup";

			SqlCommand cmd = new SqlCommand(query, sql.cnn);

			SqlDataAdapter da = new SqlDataAdapter(cmd);
			da.Fill(dt);

			sql.CloseConectionWrite();

			return dt;
		}
		public void ConsultarNomina()
		{
			SQLControl sql = new SQLControl();

			try
			{
				DateTime fecha = frm.dtpFecha.Value.Date;

				string idCuadrilla = null;

				if (frm.cboCuadrilla.SelectedIndex > 0)
				{
					idCuadrilla =
						frm.cboCuadrilla.SelectedValue?.ToString().Trim();

					if (string.IsNullOrWhiteSpace(idCuadrilla))
						idCuadrilla = null;
				}


				bool datosCompletos =
					ValidarLoteYActividad(fecha, idCuadrilla);

				// SI FALTA LOTE O ACTIVIDAD, NO CONTINÚA
				if (!datosCompletos)
				{
					return;
				}


				sql.OpenConectionWrite();

				using (SqlCommand cmd = new SqlCommand(
					"sp_ReporteNominadeCampo",
					sql.cnn))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add(
						"@FechaNomina",
						SqlDbType.Date).Value = fecha;

					cmd.Parameters.Add(
						"@IdWorkGroup",
						SqlDbType.VarChar,
						3).Value =
						(object)idCuadrilla ?? DBNull.Value;


					DataTable dt = new DataTable();

					using (SqlDataAdapter da =
						   new SqlDataAdapter(cmd))
					{
						da.Fill(dt);
					}


					frm.dgvNomina.DataSource = dt;

					ConfigurarDgvNomina();

					frm.dgvNomina.ClearSelection();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error al consultar la nómina:\n" +
					ex.Message,
					"Consulta de nómina",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
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

			if (!File.Exists(sfd.FileName))
			{
				MessageBox.Show(
					$"El archivo no se pudo guardar:\n{sfd.FileName}",
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);

				return;
			}

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

				using (SqlCommand cmdSemana = new SqlCommand(querySemana, sql.cnn))
				{
					cmdSemana.Parameters.Add("@Fecha", SqlDbType.Date).Value = fecha;

					object resultado = cmdSemana.ExecuteScalar();

					if (resultado != null && resultado != DBNull.Value)
						semana = resultado.ToString().Trim();
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
				// DETERMINAR LAS COLUMNAS SEGÚN EL DÍA
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
					aw.id_lot_{prefijo}

				FROM dbo.Nom_EmployeeAttendanceWeekly aw

				LEFT JOIN dbo.Nom_Employees emp
					ON emp.id_employee = aw.id_employee

				WHERE TRY_CONVERT(INT, aw.c_sequence_per) =
					  TRY_CONVERT(INT, @Semana)

				  AND aw.b_{prefijo} = 1";

				// =====================================================
				// SI SE SELECCIONÓ CUADRILLA
				// =====================================================

				if (!string.IsNullOrWhiteSpace(idCuadrilla))
				{
					query += $@"
                AND aw.id_workGroup_{prefijo} = @IdWorkGroup";
				}


				DataTable dtValidacion = new DataTable();

				using (SqlCommand cmd = new SqlCommand(query, sql.cnn))
				{
					cmd.Parameters.Add("@Semana", SqlDbType.VarChar, 4)
						.Value = semana;

					if (!string.IsNullOrWhiteSpace(idCuadrilla))
					{
						cmd.Parameters.Add(
							"@IdWorkGroup",
							SqlDbType.VarChar,
							4).Value = idCuadrilla;
					}

					using (SqlDataAdapter da = new SqlDataAdapter(cmd))
					{
						da.Fill(dtValidacion);
					}
				}


				// =====================================================
				// REVISAR EMPLEADOS
				// =====================================================

				foreach (DataRow row in dtValidacion.Rows)
				{
					string folio =
						row["id_employee"]?
						.ToString()
						.Trim() ?? "";

					string nombre =
						(
							row["v_lastNamePat"]?.ToString().Trim() + " " +
							row["v_lastNameMat"]?.ToString().Trim() + " " +
							row["v_name"]?.ToString().Trim()
						).Trim();

					string actividad =
						row[$"id_activity_{prefijo}"]?
						.ToString()
						.Trim() ?? "";

					string lote =
						row[$"id_lot_{prefijo}"]?
						.ToString()
						.Trim() ?? "";


					bool faltaActividad =
						string.IsNullOrWhiteSpace(actividad);

					bool faltaLote =
						string.IsNullOrWhiteSpace(lote);


					if (faltaActividad || faltaLote)
					{
						string faltante;

						if (faltaActividad && faltaLote)
							faltante = "Actividad y Lote";
						else if (faltaActividad)
							faltante = "Actividad";
						else
							faltante = "Lote";

						empleadosConError.Add(
							$"{folio} - {nombre} → Falta {faltante}"
						);
					}
				}


				// =====================================================
				// SI HAY ERRORES
				// =====================================================

				if (empleadosConError.Count > 0)
				{
					StringBuilder mensaje = new StringBuilder();

					mensaje.AppendLine(
						"NO SE PUEDE GENERAR LA NÓMINA."
					);

					mensaje.AppendLine();

					mensaje.AppendLine(
						$"Fecha: {fecha:dd/MM/yyyy}"
					);

					mensaje.AppendLine();

					mensaje.AppendLine(
						"Los siguientes empleados no tienen Lote y/o Actividad:"
					);

					mensaje.AppendLine();

					foreach (string empleado in empleadosConError)
					{
						mensaje.AppendLine("• " + empleado);
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
	}
}