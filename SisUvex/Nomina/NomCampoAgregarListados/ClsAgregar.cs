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

namespace SisUvex.Nomina.NomCampoAgregarListados
{

	public class ClsAgregar
	{
		public FrmAgregar frmA;
		public string LugarPago { get; set; }
		public string IdLugarPago { get; set; }

		public void CargarComboActividades()
		{
			DataTable dtActividades = ObtenerActividades();

			dtActividades.Columns.Add("ActividadCompleta");

			foreach (DataRow row in dtActividades.Rows)
			{
				row["ActividadCompleta"] = row["c_codigo_tab"] + " - " + row["v_descripcion_tab"];
			}

			frmA.cboActividad.DataSource = dtActividades;
			frmA.cboActividad.DisplayMember = "ActividadCompleta";
			frmA.cboActividad.ValueMember = "c_codigo_tab";

			frmA.cboActividad.DropDownStyle = ComboBoxStyle.DropDown;
			frmA.cboActividad.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			frmA.cboActividad.AutoCompleteSource = AutoCompleteSource.ListItems;

			frmA.cboActividad.SelectedIndex = -1;
			frmA.cboActividad.Text = "";
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
		public void ActualizarEmpleadoModificar(string secuenciaSemana,DateTime fechaInicio,DateTime fechaFin,string idCuadrilla,DataGridView dgvEmpleados)
		{
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				if (dgvEmpleados.Rows.Count == 0)
					return;

				DataGridViewRow row = dgvEmpleados.Rows[0];

				string idEmpleado =
					row.Cells["Codigo"].Value?.ToString();

				string idActividad =
					row.Cells["IdActividad"].Value?.ToString();

				string idLote =
					row.Cells["IdLote"].Value?.ToString();

				if (string.IsNullOrWhiteSpace(idEmpleado))
				{
					MessageBox.Show(
						"No se encontró el código del empleado.",
						"Modificar empleado",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);

					return;
				}

				using (SqlCommand cmd = new SqlCommand(
					"sp_UpdateEmployeeWeeklyList",
					sql.cnn))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue(
						"@c_sequence_per",
						secuenciaSemana);

					cmd.Parameters.AddWithValue(
						"@d_startDate_per",
						fechaInicio.Date);

					cmd.Parameters.AddWithValue(
						"@d_endDate_per",
						fechaFin.Date);

					cmd.Parameters.AddWithValue(
						"@id_employee",
						idEmpleado);

					cmd.Parameters.AddWithValue(
						"@id_workGroup",
						idCuadrilla);

					cmd.Parameters.AddWithValue(
						"@id_activity",
						idActividad);

					cmd.Parameters.AddWithValue(
						"@id_lot",
						idLote);

					cmd.Parameters.AddWithValue(
						"@userUpdate",
						User.GetUserName());

					cmd.ExecuteNonQuery();
				}

				MessageBox.Show(
					"Empleado actualizado correctamente.",
					"Modificar empleado",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					ex.Message,
					"Error al actualizar empleado",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}
		public void btnAgregarVariosEmpleados()
		{
			string textoCodigos = frmA.txbCodigo.Text.Trim();

			// -----------------------------------------
			// VALIDAR CÓDIGOS
			// -----------------------------------------

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

			// -----------------------------------------
			// VALIDAR ACTIVIDAD
			// -----------------------------------------

			if (frmA.cboActividad.SelectedIndex < 0)
			{
				MessageBox.Show(
					"Seleccione una actividad.",
					"Actividad",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				frmA.cboActividad.Focus();
				return;
			}
			// -----------------------------------------
			// VALIDAR LOTE
			// -----------------------------------------

			if (frmA.cboLote.SelectedIndex < 0)
			{
				MessageBox.Show(
					"Seleccione un lote.",
					"Lote",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				frmA.cboLote.Focus();
				return;
			}

			// -----------------------------------------
			// OBTENER ACTIVIDAD
			// -----------------------------------------

			string actividad =
				frmA.cboActividad.Text.Trim();

			string idActividad =
				frmA.cboActividad.SelectedValue?.ToString();

			string lote =
				frmA.cboLote.Text.Trim();

			string idLote =
				frmA.cboLote.SelectedValue?.ToString();

			// -----------------------------------------
			// SEPARAR CÓDIGOS
			// -----------------------------------------

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

			// -----------------------------------------
			// BUSCAR EMPLEADOS
			// -----------------------------------------

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

				// -----------------------------------------
				// EVITAR DUPLICADOS
				// -----------------------------------------

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

				// -----------------------------------------
				// AGREGAR AL DGV
				// -----------------------------------------

				frmA.dgvListadoAgregar.Rows.Add(
					codigo,
					row["Empleado"].ToString(),
					row["IdLugarPago"].ToString() + " - " +
					row["LugarPago"].ToString(),
					actividad,
					lote,
					row["IdLugarPago"].ToString(),
					idActividad,
					idLote
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

						// NOMBRE
						frmA.txbEmpleado.Text =
							dr["Empleado"] == DBNull.Value
								? ""
								: dr["Empleado"].ToString();

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
		public void ModificarEmpleado()
		{
			if (string.IsNullOrWhiteSpace(frmA.txbCodigo.Text))
			{
				MessageBox.Show(
					"Ingrese un código de empleado.",
					"Empleado",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				frmA.txbCodigo.Focus();
				return;
			}

			// VALIDAR ACTIVIDAD
			if (frmA.cboActividad.SelectedIndex < 0)
			{
				MessageBox.Show(
					"Seleccione una actividad.",
					"Actividad",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				frmA.cboActividad.Focus();
				return;
			}

			// VALIDAR LOTE
			if (frmA.cboLote.SelectedIndex < 0)
			{
				MessageBox.Show(
					"Seleccione un lote.",
					"Lote",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				frmA.cboLote.Focus();
				return;
			}

			// OBTENER DATOS
			string codigo =
				frmA.txbCodigo.Text.Trim();

			string empleado =
				frmA.txbEmpleado.Text.Trim();

			string actividad =
				frmA.cboActividad.Text.Trim();

			string idActividad =
				frmA.cboActividad.SelectedValue?.ToString();

			string lote =
				frmA.cboLote.Text.Trim();

			string idLote =
				frmA.cboLote.SelectedValue?.ToString();

			// MOSTRAR EN EL DGV
			frmA.dgvListadoAgregar.Rows.Clear();

			frmA.dgvListadoAgregar.Rows.Add(
				codigo,
				empleado,
				LugarPago,
				actividad,
				lote,
				IdLugarPago,
				idActividad,
				idLote
			);
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

			// -----------------------------
			// GENERAL
			// -----------------------------
			dgv.BackgroundColor = Color.White;
			dgv.BorderStyle = BorderStyle.None;
			dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
			dgv.GridColor = Color.FromArgb(225, 228, 235);

			dgv.EnableHeadersVisualStyles = false;

			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToResizeRows = false;
			dgv.ReadOnly = true;

			dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgv.MultiSelect = false;

			dgv.RowHeadersVisible = false;


			// -----------------------------
			// ENCABEZADO
			// -----------------------------
			dgv.ColumnHeadersDefaultCellStyle.BackColor =
				Color.FromArgb(42, 67, 128);

			dgv.ColumnHeadersDefaultCellStyle.ForeColor =
				Color.White;

			// IMPORTANTE:
			// Evita que el encabezado se ponga blanco
			// cuando se selecciona una columna.
			dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor =
				Color.FromArgb(42, 67, 128);

			dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor =
				Color.White;

			dgv.ColumnHeadersDefaultCellStyle.Font =
				new Font("Segoe UI", 9F, FontStyle.Bold);

			dgv.ColumnHeadersDefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			dgv.ColumnHeadersHeight = 36;


			// -----------------------------
			// FILAS
			// -----------------------------
			dgv.DefaultCellStyle.Font =
				new Font("Segoe UI", 9F);

			dgv.DefaultCellStyle.ForeColor =
				Color.FromArgb(45, 45, 55);

			dgv.DefaultCellStyle.BackColor =
				Color.White;

			dgv.DefaultCellStyle.SelectionBackColor =
				Color.FromArgb(220, 229, 250);

			dgv.DefaultCellStyle.SelectionForeColor =
				Color.FromArgb(30, 45, 80);

			dgv.DefaultCellStyle.Padding =
				new Padding(6, 0, 6, 0);

			dgv.RowTemplate.Height = 32;


			// -----------------------------
			// FILAS ALTERNADAS
			// -----------------------------
			dgv.AlternatingRowsDefaultCellStyle.BackColor =
				Color.FromArgb(247, 249, 253);


			// -----------------------------
			// AJUSTE DE COLUMNAS
			// -----------------------------
			dgv.AutoSizeColumnsMode =
				DataGridViewAutoSizeColumnsMode.Fill;

			dgv.Columns[0].FillWeight = 12; // Código
			dgv.Columns[1].FillWeight = 30; // Empleado
			dgv.Columns[2].FillWeight = 20; // Lugar de pago
			dgv.Columns[3].FillWeight = 18; // Actividad
			dgv.Columns[4].FillWeight = 20; // Lote


			// -----------------------------
			// ALINEACIÓN
			// -----------------------------
			dgv.Columns[0].DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			dgv.Columns[1].DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleLeft;

			dgv.Columns[2].DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleLeft;

			dgv.Columns[3].DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleLeft;

			dgv.Columns[4].DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleLeft;
		}
	}
}
