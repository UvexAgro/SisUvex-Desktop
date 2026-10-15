using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.SS.Formula.Functions;

namespace SisUvex.Nomina.Reloj_Checador_de_Campo
{
	internal class ClsReloj
	{
		public FrmReloj frm;
		public (bool Encontrado, string? Nombre, string? LugarPago, string? Cuadrilla) ObtenerEmpleado(string codigo, string idPeriodo, string numeroSemana)
		{
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				using (SqlCommand cmd = new SqlCommand(@"
            SELECT
                LTRIM(RTRIM(CONCAT(
                    e.v_name, ' ',
                    e.v_lastNamePat, ' ',
                    e.v_lastNameMat
                ))) AS Nombre,

                MAX(
                    CASE
                        WHEN pp.id_placePayment IS NOT NULL THEN
                            CONCAT(
                                LTRIM(RTRIM(pp.id_placePayment)),
                                ' - ',
                                LTRIM(RTRIM(pp.v_namePlace))
                            )
                    END
                ) AS LugarPago,

                COALESCE(
                    STRING_AGG(
                        CAST(
                            CONCAT(
                                LTRIM(RTRIM(wg.c_order)),
                                ' - ',
                                LTRIM(RTRIM(wg.v_nameWorkGroup))
                            ) AS VARCHAR(MAX)
                        ),
                        ', '
                    ),
                    'Sin cuadrilla'
                ) AS Cuadrilla

            FROM dbo.Nom_Employees e

            LEFT JOIN dbo.Nom_EmployeeAttendenceList ea
                ON ea.id_employee = e.id_employee
                AND ea.id_period = @IdPeriodo
                AND ea.c_sequence_per = @NumeroSemana

            LEFT JOIN dbo.Nom_PlacePayment pp
                ON pp.id_placePayment = ea.id_paymentPlace

            LEFT JOIN dbo.Nom_WorkGroup wg
                ON wg.id_workGroup = ea.id_workGroup
                AND wg.c_active = '1'

            WHERE e.id_employee = @Codigo

            GROUP BY
                e.id_employee,
                e.v_name,
                e.v_lastNamePat,
                e.v_lastNameMat;",
					sql.cnn))
				{
					cmd.Parameters.Add("@Codigo", SqlDbType.VarChar, 6)
						.Value = codigo.Trim().PadLeft(6, '0');

					cmd.Parameters.Add("@IdPeriodo", SqlDbType.Char, 2)
						.Value = idPeriodo.Trim();

					cmd.Parameters.Add("@NumeroSemana", SqlDbType.Char, 2)
						.Value = numeroSemana.Trim();

					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						if (reader.Read())
						{
							return (
								true,
								reader["Nombre"]?.ToString(),
								reader["LugarPago"] == DBNull.Value
									? null
									: reader["LugarPago"].ToString(),
								reader["Cuadrilla"]?.ToString() ?? "Sin cuadrilla"
							);
						}
					}

					return (false, null, null, null);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					ex.Message,
					"Buscar empleado",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);

				return (false, null, null, null);
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}
		public DataTable ObtenerChecadas(
	string? codigoEmpleado,
	DateTime fechaInicio,
	DateTime fechaFin)
		{
			SQLControl sql = new SQLControl();
			DataTable dt = new DataTable();

			try
			{
				sql.OpenConectionWrite();

				using (SqlCommand cmd = new SqlCommand(@"
            SELECT
                RIGHT(
                    '000000' + LTRIM(RTRIM(
                        CAST(h.id_employee AS VARCHAR(20))
                    )), 6
                ) AS Codigo,

                LTRIM(RTRIM(CONCAT(
                    e.v_lastNamePat, ' ',
                    e.v_lastNameMat, ' ',
                    e.v_name
                ))) AS Empleado,

                CAST(h.d_date AS DATE) AS Fecha,

                MIN(CAST(h.d_time AS TIME))
                    AS [Primera Checada],

                MAX(CAST(h.d_time AS TIME))
                    AS [Última Checada]

            FROM dbo.Nom_HikvisionIVMS h

            LEFT JOIN dbo.Nom_Employees e
                ON RIGHT('000000' + LTRIM(RTRIM(
                    CAST(e.id_employee AS VARCHAR(20))
                )), 6)
                =
                RIGHT('000000' + LTRIM(RTRIM(
                    CAST(h.id_employee AS VARCHAR(20))
                )), 6)

            WHERE
                h.d_date >= @FechaInicio
                AND h.d_date < DATEADD(DAY, 1, @FechaFin)

                AND (
                    @Codigo IS NULL
                    OR RIGHT('000000' + LTRIM(RTRIM(
                        CAST(h.id_employee AS VARCHAR(20))
                    )), 6) = @Codigo
                )

            GROUP BY
                h.id_employee,
                e.v_lastNamePat,
                e.v_lastNameMat,
                e.v_name,
                CAST(h.d_date AS DATE)

            ORDER BY
                e.v_lastNamePat,
                e.v_lastNameMat,
                e.v_name,
                CAST(h.d_date AS DATE);",
					sql.cnn))
				{
					string codigo = codigoEmpleado?.Trim() ?? "";

					cmd.Parameters.Add("@Codigo", SqlDbType.VarChar, 6)
						.Value = string.IsNullOrWhiteSpace(codigo)
							? DBNull.Value
							: codigo.PadLeft(6, '0');

					cmd.Parameters.Add("@FechaInicio", SqlDbType.Date)
						.Value = fechaInicio.Date;

					cmd.Parameters.Add("@FechaFin", SqlDbType.Date)
						.Value = fechaFin.Date;

					using (SqlDataAdapter da = new SqlDataAdapter(cmd))
					{
						da.Fill(dt);
					}
				}

				return dt;
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					ex.Message,
					"Consultar checadas",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);

				return dt;
			}
			finally
			{
				sql.CloseConectionWrite();
			}
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
				{
					using (SqlDataAdapter da = new SqlDataAdapter(cmd))
					{
						da.Fill(dt);
					}
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

			// Crear texto para mostrar en el ComboBox
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
					"Semana " +
					row["c_sequence_per"].ToString().Trim() +
					" | " +
					fechaInicio.ToString("dd/MM/yyyy") +
					" - " +
					fechaFin.ToString("dd/MM/yyyy");
			}

			// Cargar ComboBox
			frm.cboSemana.DataSource = null;
			frm.cboSemana.DisplayMember = "SemanaMostrar";
			frm.cboSemana.ValueMember = "c_sequence_per";
			frm.cboSemana.DataSource = dt;
			SeleccionarSemanaActual(dt);
		}
		public DataTable CrearVistaSemanal(
	DataTable checadas,
	DateTime fechaInicio,
	DateTime fechaFin)
		{
			DataTable resultado = new DataTable();

			fechaInicio = fechaInicio.Date;
			fechaFin = fechaFin.Date;

			if (fechaInicio > fechaFin)
				return resultado;

			resultado.Columns.Add("Codigo", typeof(string));
			resultado.Columns.Add("Empleado", typeof(string));

			CultureInfo cultura = new CultureInfo("es-MX");

			// Crear una sola columna por cada día
			for (DateTime fecha = fechaInicio;
				 fecha <= fechaFin;
				 fecha = fecha.AddDays(1))
			{
				string dia = fecha.ToString("ddd", cultura).ToUpper();
				string fechaTexto = fecha.ToString("dd/MM");

				resultado.Columns.Add($"{dia} {fechaTexto}", typeof(string));
			}

			// Ordenar las checadas por empleado y fecha
			var registrosOrdenados = checadas.AsEnumerable()
				.Where(r =>
				{
					DateTime fecha = Convert.ToDateTime(r["Fecha"]).Date;
					return fecha >= fechaInicio && fecha <= fechaFin;
				})
				.OrderBy(r => r["Empleado"]?.ToString())
				.ThenBy(r => Convert.ToDateTime(r["Fecha"]).Date);

			foreach (DataRow registro in registrosOrdenados)
			{
				string codigo = registro["Codigo"]?.ToString() ?? "";
				string empleado = registro["Empleado"]?.ToString() ?? "";

				DataRow? fila = resultado.AsEnumerable()
					.FirstOrDefault(r =>
						r["Codigo"].ToString() == codigo);

				if (fila == null)
				{
					fila = resultado.NewRow();

					fila["Codigo"] = codigo;
					fila["Empleado"] = empleado;

					// Inicializar todos los días sin checadas
					foreach (DataColumn columna in resultado.Columns)
					{
						if (columna.ColumnName != "Codigo" &&
							columna.ColumnName != "Empleado")
						{
							fila[columna.ColumnName] = "--";
						}
					}

					resultado.Rows.Add(fila);
				}

				DateTime fechaRegistro =
					Convert.ToDateTime(registro["Fecha"]).Date;

				string dia = fechaRegistro.ToString("ddd", cultura).ToUpper();
				string fechaTexto = fechaRegistro.ToString("dd/MM");
				string nombreColumna = $"{dia} {fechaTexto}";

				if (resultado.Columns.Contains(nombreColumna))
				{
					string entrada =
						FormatearHora(registro["Primera Checada"]);

					string salida =
						FormatearHora(registro["Última Checada"]);

					fila[nombreColumna] =
						$"{entrada}{Environment.NewLine}{salida}";
				}
			}

			return resultado;
		}
	
	
		public void ConfigurarColumnasSemanales()
		{
			DataGridView dgv = frm.dgvLista;

			// No usar Fill porque puede distribuir los anchos de forma desigual
			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

			// Columnas fijas
			if (dgv.Columns.Contains("Codigo"))
			{
				dgv.Columns["Codigo"].Width = 80;
				dgv.Columns["Codigo"].Frozen = true;
			}

			if (dgv.Columns.Contains("Empleado"))
			{
				dgv.Columns["Empleado"].Width = 230;
				dgv.Columns["Empleado"].Frozen = true;

				dgv.Columns["Empleado"].DefaultCellStyle.Alignment =
					DataGridViewContentAlignment.MiddleLeft;
			}

			// Calcular espacio disponible para los días
			int anchoCodigo = dgv.Columns.Contains("Codigo")
				? dgv.Columns["Codigo"].Width : 0;

			int anchoEmpleado = dgv.Columns.Contains("Empleado")
				? dgv.Columns["Empleado"].Width : 0;

			int cantidadDias = dgv.Columns.Count - 2;

			if (cantidadDias > 0)
			{
				int anchoDisponible = dgv.ClientSize.Width
					- anchoCodigo
					- anchoEmpleado
					- SystemInformation.VerticalScrollBarWidth
					- 4;

				int anchoDia = Math.Max(65, anchoDisponible / cantidadDias);

				foreach (DataGridViewColumn columna in dgv.Columns)
				{
					if (columna.Name != "Codigo" &&
						columna.Name != "Empleado")
					{
						columna.Width = anchoDia;

						columna.DefaultCellStyle.Alignment =
							DataGridViewContentAlignment.MiddleCenter;
					}
				}
			}

			dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
			dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			dgv.ScrollBars = ScrollBars.Both;
		}


		private string FormatearHora(object valor)
		{
			if (valor == null || valor == DBNull.Value)
				return "--";

			if (valor is TimeSpan hora)
				return hora.ToString(@"hh\:mm");

			if (valor is DateTime fecha)
				return fecha.ToString("HH:mm");

			string texto = valor.ToString() ?? "";

			if (TimeSpan.TryParse(texto, out TimeSpan horaConvertida))
				return horaConvertida.ToString(@"hh\:mm");

			return texto;
		}
		public void ConsultarAsistencia(DateTime fechaInicio, DateTime fechaFin)
		{
			ClsReloj reloj = new ClsReloj();

			string codigo = frm.txbCodigo.Text.Trim();

			// Validar rango de fechas
			if (fechaInicio.Date > fechaFin.Date)
			{
				MessageBox.Show(
					"La fecha inicial no puede ser mayor que la fecha final.",
					"Rango de fechas",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);
				return;
			}

			// Si se escribió un código, buscar sus datos
			if (!string.IsNullOrWhiteSpace(codigo))
			{
				codigo = codigo.PadLeft(6, '0');

				if (frm.cboSemana.SelectedItem is not DataRowView semana)
				{
					MessageBox.Show("Selecciona una semana.");
					return;
				}

				string idPeriodo = semana["id_period"].ToString()!.Trim();
				string numeroSemana = semana["c_sequence_per"].ToString()!.Trim();

				var empleado = reloj.ObtenerEmpleado(
					codigo,
					idPeriodo,
					numeroSemana);

				if (!empleado.Encontrado)
				{
					frm.txbEmpleado.Clear();
					frm.txbLugardePago.Clear();
					frm.txbCuadrilla.Clear();

					MessageBox.Show("No se encontró el empleado.");

					frm.txbCodigo.Focus();
					frm.txbCodigo.SelectAll();
					return;
				}

				frm.txbEmpleado.Text = empleado.Nombre ?? "";
				frm.txbLugardePago.Text = empleado.LugarPago ?? "";
				frm.txbCuadrilla.Text = empleado.Cuadrilla ?? "Sin cuadrilla";
			}
			else
			{
				// Sin código, consultar a todos los empleados
				frm.txbEmpleado.Clear();
				frm.txbLugardePago.Clear();
				frm.txbCuadrilla.Clear();
			}

			// Consultar checadas por rango de fechas
			DataTable checadas = reloj.ObtenerChecadas(
				string.IsNullOrWhiteSpace(codigo) ? null : codigo,
				fechaInicio,
				fechaFin);

			// Convertir los datos al formato de columnas por día
			DataTable vista = reloj.CrearVistaSemanal(
				checadas,
				fechaInicio,
				fechaFin);

			frm.dgvLista.DataSource = vista;

			ConfigurarGridReloj();
			ConfigurarColumnasSemanales();

			if (vista.Rows.Count == 0)
			{
				MessageBox.Show(
					"No se encontraron checadas para las fechas seleccionadas.",
					"Consulta de asistencia",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);
			}
		}
		private void SeleccionarSemanaActual(DataTable dt)
		{
			DateTime hoy = DateTime.Today;

			for (int i = 0; i < dt.Rows.Count; i++)
			{
				DateTime fechaInicio =
					Convert.ToDateTime(dt.Rows[i]["d_startDate_per"]).Date;

				DateTime fechaFin =
					Convert.ToDateTime(dt.Rows[i]["d_endDate_per"]).Date;

				if (hoy >= fechaInicio && hoy <= fechaFin)
				{
					frm.cboSemana.SelectedIndex = i;
					return;
				}
			}

			// Si hoy no pertenece a ninguna semana activa
			frm.cboSemana.SelectedIndex = -1;
		}
		
		public void ConfigurarGridReloj()
		{
			DataGridView dgv = frm.dgvLista;

			dgv.ReadOnly = true;
			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToDeleteRows = false;
			dgv.AllowUserToResizeRows = false;
			dgv.MultiSelect = false;
			dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgv.RowHeadersVisible = false;
			dgv.AutoGenerateColumns = true;

			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

			// Permitir entrada y salida en dos líneas
			dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
			dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			dgv.RowTemplate.Height = 40;

			// Encabezados: azul de nómina
			dgv.EnableHeadersVisualStyles = false;

			dgv.ColumnHeadersDefaultCellStyle.BackColor =
				Color.FromArgb(47, 117, 163);

			dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

			dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor =
				Color.FromArgb(47, 117, 163);

			dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;

			dgv.ColumnHeadersDefaultCellStyle.Font =
				new Font("Segoe UI", 9F, FontStyle.Bold);

			dgv.ColumnHeadersDefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			dgv.ColumnHeadersHeight = 38;

			// Filas normales
			dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9F);

			dgv.DefaultCellStyle.ForeColor =
				Color.FromArgb(35, 55, 77);

			dgv.DefaultCellStyle.BackColor = Color.White;

			// Filas alternadas
			dgv.AlternatingRowsDefaultCellStyle.BackColor =
				Color.FromArgb(241, 247, 252);

			// Selección
			dgv.DefaultCellStyle.SelectionBackColor =
				Color.FromArgb(31, 111, 170);

			dgv.DefaultCellStyle.SelectionForeColor = Color.White;

			dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor =
				Color.FromArgb(31, 111, 170);

			dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor =
				Color.White;

			// Alineación
			dgv.DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			// Bordes y fondo
			dgv.BorderStyle = BorderStyle.None;

			dgv.CellBorderStyle =
				DataGridViewCellBorderStyle.SingleHorizontal;

			dgv.GridColor = Color.FromArgb(220, 230, 238);

			dgv.BackgroundColor = Color.White;
		}
	}
}
