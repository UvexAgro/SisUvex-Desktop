using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Office.Word;
using NPOI.SS.Formula.Functions;
using SisUvex.Catalogos.Metods.Values;
using SisUvex.Nomina.Reporte_de_Emp_UVA;
using static SisUvex.Catalogos.Metods.ClsObject;

namespace SisUvex.Nomina.NomCampoAgregarListados
{

	public class ClsAgregar
	{
		public FrmAgregar frmA;
		public string LugarPago { get; set; }
		public string IdLugarPago { get; set; }
		private DataTable dtActividades = new DataTable();
		public class DiaRegistro
		{
			public string Nombre { get; set; }
			public DateTime Fecha { get; set; }

			public string Texto
			{
				get
				{
					return $"{Nombre} {Fecha:dd/MM/yyyy}";
				}
			}
		}
		public DataTable ObtenerActividades()
		{
			SQLControl sql = new SQLControl();
			DataTable dt = new DataTable();
			try
			{
				sql.OpenConectionWrite();

				string query = @"
				SELECT c_codigo_tab, v_descripcion_tab 
				FROM dbo.Nom_Tabulador
				ORDER BY c_codigo_tab";

				SqlCommand cmd = new SqlCommand(query, sql.cnn);

				SqlDataAdapter da = new SqlDataAdapter(cmd);
				da.Fill(dt);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				sql.CloseConectionWrite();
			}

			return dt;
		}
		public void FiltrarActividades(string texto)
		{
			if (frmA.bsActividades.DataSource == null)
				return;

			texto = texto.Replace("'", "''");

			if (string.IsNullOrWhiteSpace(texto))
			{
				frmA.bsActividades.RemoveFilter();
			}
			else
			{
				frmA.bsActividades.Filter =
					$"c_codigo_tab LIKE '%{texto}%' " +
					$"OR v_descripcion_tab LIKE '%{texto}%'";
			}
		}
		public void CargarDiasRegistro(DateTime fechaInicio)
		{
			frmA.cboFecha.Items.Clear();

			frmA.cboFecha.Items.Add(
				new DiaRegistro { Nombre = "VIERNES", Fecha = fechaInicio });

			frmA.cboFecha.Items.Add(
				new DiaRegistro { Nombre = "SÁBADO", Fecha = fechaInicio.AddDays(1) });

			frmA.cboFecha.Items.Add(
				new DiaRegistro { Nombre = "DOMINGO", Fecha = fechaInicio.AddDays(2) });

			frmA.cboFecha.Items.Add(
				new DiaRegistro { Nombre = "LUNES", Fecha = fechaInicio.AddDays(3) });

			frmA.cboFecha.Items.Add(
				new DiaRegistro { Nombre = "MARTES", Fecha = fechaInicio.AddDays(4) });

			frmA.cboFecha.Items.Add(
				new DiaRegistro { Nombre = "MIÉRCOLES", Fecha = fechaInicio.AddDays(5) });

			frmA.cboFecha.Items.Add(
				new DiaRegistro { Nombre = "JUEVES", Fecha = fechaInicio.AddDays(6) });

			frmA.cboFecha.DisplayMember = "Texto";
			frmA.cboFecha.SelectedIndex = -1;
		}
		public void CargarEmpleadosSeleccionados(List<string> empleados)
		{
			if (empleados == null || empleados.Count == 0)
				return;

			// Pasar los códigos al textbox
			frmA.txbCodigo.Text = string.Join(", ", empleados);

			// Utilizar el mismo método que ya tienes
			// para agregar varios empleados
			btnAgregarVariosEmpleados();

			// Limpiar el textbox después de agregarlos
			frmA.txbCodigo.Clear();
		}
		public bool GuardarActividadLote()
		{
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				// Determinar el día seleccionado
				int diferenciaDias =
					(frmA.FechaSeleccionada.Date - frmA.FechaInicio.Date).Days;

				string sufijoDia;

				switch (diferenciaDias)
				{
					case 0:
						sufijoDia = "vie";
						break;

					case 1:
						sufijoDia = "sab";
						break;

					case 2:
						sufijoDia = "dom";
						break;

					case 3:
						sufijoDia = "lun";
						break;

					case 4:
						sufijoDia = "mar";
						break;

					case 5:
						sufijoDia = "mie";
						break;

					case 6:
						sufijoDia = "jue";
						break;

					default:
						MessageBox.Show(
							"El día seleccionado no pertenece a la semana.",
							"Fecha",
							MessageBoxButtons.OK,
							MessageBoxIcon.Warning);

						return false;
				}

				// Obtener valores seleccionados
				string cuadrilla = frmA.IdCuadrilla?.Trim();
				string secuencia = frmA.SecuenciaSemana?.Trim();

				string actividad =
					frmA.cboActividad.SelectedValue?.ToString().Trim();

				string lote =
					frmA.cboLote.SelectedValue?.ToString().Trim();

				if (string.IsNullOrWhiteSpace(cuadrilla))
				{
					MessageBox.Show(
						"No se encontró la cuadrilla seleccionada.",
						"Cuadrilla",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);

					return false;
				}

				if (string.IsNullOrWhiteSpace(actividad))
				{
					MessageBox.Show(
						"No se encontró la actividad seleccionada.",
						"Actividad",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);

					return false;
				}

				if (string.IsNullOrWhiteSpace(lote))
				{
					MessageBox.Show(
						"No se encontró el lote seleccionado.",
						"Lote",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);

					return false;
				}

				// Columnas correspondientes al día
				string columnaCuadrilla =
					$"id_workGroup_{sufijoDia}";

				string columnaActividad =
					$"id_activity_{sufijoDia}";

				string columnaLote =
					$"id_lot_{sufijoDia}";

				// Actualizar empleados de la lista
				foreach (DataGridViewRow fila in frmA.dgvListadoAgregar.Rows)
				{
					if (fila.IsNewRow)
						continue;

					string empleado =
						fila.Cells["Codigo"].Value?.ToString().Trim();

					if (string.IsNullOrWhiteSpace(empleado))
						continue;

					string query = $@"
                UPDATE [SisUvex].[dbo].[Nom_EmployeeAttendanceWeekly]
                SET
                    {columnaCuadrilla} = @Cuadrilla,
                    {columnaActividad} = @Actividad,
                    {columnaLote} = @Lote,
                    d_update = GETDATE(),
                    userUpdate = @Usuario
                WHERE
                    id_employee = @Empleado
                    AND c_sequence_per = @Secuencia
                    AND d_startDate_per = @FechaInicio
                    AND d_endDate_per = @FechaFin";

					using (SqlCommand cmd =
						new SqlCommand(query, sql.cnn))
					{
						cmd.Parameters.Add(
							"@Cuadrilla",
							SqlDbType.Char,
							4).Value = cuadrilla;

						cmd.Parameters.Add(
							"@Actividad",
							SqlDbType.Char,
							4).Value = actividad;

						cmd.Parameters.Add(
							"@Lote",
							SqlDbType.Char,
							4).Value = lote;

						cmd.Parameters.Add(
							"@Empleado",
							SqlDbType.Char,
							6).Value = empleado;

						cmd.Parameters.Add(
							"@Secuencia",
							SqlDbType.Char,
							2).Value = secuencia;

						cmd.Parameters.Add(
							"@FechaInicio",
							SqlDbType.Date).Value =
							frmA.FechaInicio.Date;

						cmd.Parameters.Add(
							"@FechaFin",
							SqlDbType.Date).Value =
							frmA.FechaFin.Date;

						cmd.Parameters.Add(
							"@Usuario",
							SqlDbType.VarChar,
							100).Value =
							User.GetUserName();

						cmd.ExecuteNonQuery();
					}
				}

				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error al guardar lote y actividad:\n\n" +
					ex.Message,
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);

				return false;
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}
		public void CargarComboLotes()
		{
			DataTable dtLotes = ObtenerLotes();

			dtLotes.Columns.Add("LoteCompleto");

			foreach (DataRow row in dtLotes.Rows)
			{
				row["LoteCompleto"] =
					row["c_codigo_lot"] + " - " +
					row["v_nameLot"] + " - " +
					row["NombreVariedad"];
			}

			frmA.cboLote.DataSource = dtLotes;
			frmA.cboLote.DisplayMember = "LoteCompleto";
			frmA.cboLote.ValueMember = "id_lot";

			frmA.cboLote.DropDownStyle = ComboBoxStyle.DropDown;
			frmA.cboLote.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			frmA.cboLote.AutoCompleteSource = AutoCompleteSource.ListItems;

			frmA.cboLote.SelectedIndex = -1;
			frmA.cboLote.Text = "";
		}
		public DataTable ObtenerLotes()
		{
			SQLControl sql = new SQLControl();
			DataTable dt = new DataTable();
			try
			{
				sql.OpenConectionWrite();
				string query = @"
				SELECT 
				L.id_lot,
				L.c_codigo_lot,
				L.v_nameLot,
				L.id_variety,
				V.v_nameComercial AS NombreVariedad
			FROM Pack_Lot L
			LEFT JOIN Pack_Variety V
				ON L.id_variety = V.id_variety
			WHERE L.c_active = '1'
			  AND NULLIF(LTRIM(RTRIM(L.c_codigo_lot)), '') IS NOT NULL
			ORDER BY L.c_codigo_lot ";

				sql.OpenConectionWrite();

				SqlCommand cmd = new SqlCommand(query, sql.cnn);

				SqlDataAdapter da = new SqlDataAdapter(cmd);
				da.Fill(dt);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				sql.CloseConectionWrite();
			}

			return dt;
		}

		public void btnAgregarVariosEmpleados()
		{
			string textoCodigos = frmA.txbCodigo.Text.Trim();

			// VALIDAR CÓDIGOS

			if (string.IsNullOrWhiteSpace(textoCodigos))
			{
				MessageBox.Show(
					"Ingrese al menos un código de empleado.",
					"Empleados",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				frmA.txbCodigo.Focus();
				return;
			}

			// SEPARAR CÓDIGOS

			string[] codigos = textoCodigos
				.Split(
					new char[] { '\r', '\n', ',', ' ', ';', '\t' },
					StringSplitOptions.RemoveEmptyEntries)
				.Select(x => x.Trim())
				.Distinct()
				.ToArray();

			if (codigos.Length == 0)
			{
				MessageBox.Show(
					"No se encontraron códigos válidos.",
					"Empleados",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return;
			}

			// BUSCAR EMPLEADOS

			foreach (string codigo in codigos)
			{
				DataTable dt =
					BuscarEmpleadoPorCodigo(codigo);

				if (dt.Rows.Count == 0)
				{
					MessageBox.Show(
						"No se encontró el empleado con código: " + codigo,
						"Empleado no encontrado",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);

					continue;
				}

				DataRow row = dt.Rows[0];

				// EVITAR DUPLICADOS

				bool existe = false;

				foreach (DataGridViewRow fila
					in frmA.dgvListadoAgregar.Rows)
				{
					if (fila.IsNewRow)
						continue;

					if (fila.Cells["Codigo"].Value?.ToString()
						== codigo)
					{
						existe = true;
						break;
					}
				}

				if (existe)
					continue;

				// AGREGAR AL DGV

				frmA.dgvListadoAgregar.Rows.Add(
					codigo,
					row["Empleado"].ToString(),
					row["IdLugarPago"] == DBNull.Value
						? ""
						: row["IdLugarPago"].ToString() + " - " +
						  row["LugarPago"].ToString(),

					row["IdLugarPago"] == DBNull.Value
						? ""
						: row["IdLugarPago"].ToString()
				);
			}

			frmA.txbCodigo.Clear();
			frmA.txbCodigo.Focus();
		}
		public void CargarDatosEmpleadoModificar(string idEmpleado)
		{
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				using (SqlCommand cmd = new SqlCommand(
					"sp_ModifyEmployeeWeeklyList",
					sql.cnn))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue(
						"@c_sequence_per",
						frmA.SecuenciaSemana);

					cmd.Parameters.AddWithValue(
						"@d_startDate_per",
						frmA.FechaInicio.Date);

					cmd.Parameters.AddWithValue(
						"@d_endDate_per",
						frmA.FechaFin.Date);

					cmd.Parameters.AddWithValue(
						"@id_employee",
						idEmpleado);

					cmd.Parameters.AddWithValue(
						"@id_workGroup",
						frmA.IdCuadrilla);

					using (SqlDataReader dr = cmd.ExecuteReader())
					{
						if (!dr.Read())
						{
							MessageBox.Show(
								"No se encontró el empleado en la lista semanal.",
								"Empleado",
								MessageBoxButtons.OK,
								MessageBoxIcon.Information);

							return;
						}

						// CÓDIGO
						frmA.txbCodigo.Text =
							dr["id_employee"].ToString();

						// LUGAR DE PAGO
						LugarPago =
							dr["LugarPago"] == DBNull.Value
								? ""
								: dr["LugarPago"].ToString();

						// ID LUGAR DE PAGO
						IdLugarPago =
							dr["id_paymentPlace"] == DBNull.Value
								? ""
								: dr["id_paymentPlace"].ToString();

						// ACTIVIDAD
						if (dr["id_activity"] != DBNull.Value)
						{
							frmA.cboActividad.SelectedValue =
								dr["id_activity"].ToString();
						}

						// LOTE
						if (dr["id_lot"] != DBNull.Value)
						{
							frmA.cboLote.SelectedValue =
								dr["id_lot"].ToString();
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					ex.Message,
					"Error al cargar empleado",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}

		private DataTable BuscarEmpleadoPorCodigo(string codigo)
		{
			SQLControl sql = new SQLControl();

			DataTable dt = new DataTable();

			try
			{
				sql.OpenConectionWrite();

				string query = @"
			SELECT
				E.id_employee,

				E.v_lastNamePat + ' ' +
				E.v_lastNameMat + ' ' +
				E.v_name AS Empleado,

				RIGHT(
					'0000' + CAST(E.id_paymentPlace AS VARCHAR(4)),
					4
				) AS IdLugarPago,

				P.v_namePlace AS LugarPago

			FROM dbo.Nom_Employees E

			LEFT JOIN dbo.Nom_PlacePayment P
				ON P.id_placePayment = E.id_paymentPlace

			WHERE E.id_employee = @codigo;
		";

				using (SqlCommand cmd =
					new SqlCommand(query, sql.cnn))
				{
					cmd.Parameters.AddWithValue(
						"@codigo",
						codigo);

					using (SqlDataAdapter da =
						new SqlDataAdapter(cmd))
					{
						da.Fill(dt);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					ex.Message,
					"Error al buscar empleado",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			finally
			{
				sql.CloseConectionWrite();
			}

			return dt;
		}


		public void EstiloDgvListadoAgregar()
		{
			DataGridView dgv = frmA.dgvListadoAgregar;

			// GENERAL

			dgv.BackgroundColor = System.Drawing.Color.White;
			dgv.BorderStyle = BorderStyle.None;

			dgv.CellBorderStyle =
				DataGridViewCellBorderStyle.SingleHorizontal;

			dgv.GridColor =
				System.Drawing.Color.FromArgb(225, 228, 235);

			dgv.EnableHeadersVisualStyles = false;

			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToResizeRows = false;
			dgv.AllowUserToResizeColumns = false;

			dgv.ReadOnly = true;

			dgv.SelectionMode =
				DataGridViewSelectionMode.FullRowSelect;

			dgv.MultiSelect = false;

			dgv.RowHeadersVisible = false;

			// ENCABEZADO

			dgv.ColumnHeadersDefaultCellStyle.BackColor =
				System.Drawing.Color.FromArgb(42, 67, 128);

			dgv.ColumnHeadersDefaultCellStyle.ForeColor =
				System.Drawing.Color.White;

			dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor =
				System.Drawing.Color.FromArgb(42, 67, 128);

			dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor =
				System.Drawing.Color.White;

			dgv.ColumnHeadersDefaultCellStyle.Font =
				new Font(
					"Segoe UI",
					9F,
					FontStyle.Bold);

			dgv.ColumnHeadersDefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			dgv.ColumnHeadersHeight = 36;

			// FILAS

			dgv.DefaultCellStyle.Font =
				new Font("Segoe UI", 9F);

			dgv.DefaultCellStyle.ForeColor =
				System.Drawing.Color.FromArgb(45, 45, 55);

			dgv.DefaultCellStyle.BackColor =
				System.Drawing.Color.White;

			dgv.DefaultCellStyle.SelectionBackColor =
				System.Drawing.Color.FromArgb(220, 229, 250);

			dgv.DefaultCellStyle.SelectionForeColor =
				System.Drawing.Color.FromArgb(30, 45, 80);

			dgv.DefaultCellStyle.Padding =
				new Padding(6, 0, 6, 0);

			dgv.RowTemplate.Height = 32;

			// FILAS ALTERNADAS

			dgv.AlternatingRowsDefaultCellStyle.BackColor =
				System.Drawing.Color.FromArgb(247, 249, 253);

			// COLUMNAS

			dgv.AutoSizeColumnsMode =
				DataGridViewAutoSizeColumnsMode.Fill;

			dgv.Columns["Codigo"].FillWeight = 15;

			dgv.Columns["Nombre"].FillWeight = 50;

			dgv.Columns["LugarPago"].FillWeight = 35;

			// ALINEACIÓN

			dgv.Columns["Codigo"].DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			dgv.Columns["Nombre"].DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleLeft;

			dgv.Columns["LugarPago"].DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleLeft;
		}
	}
}
