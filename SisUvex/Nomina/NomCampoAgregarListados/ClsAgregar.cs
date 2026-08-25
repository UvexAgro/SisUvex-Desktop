using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.SS.Formula.Functions;
using SisUvex.Catalogos.Metods.Values;
using SisUvex.Nomina.Reporte_de_Emp_UVA;

namespace SisUvex.Nomina.NomCampoAgregarListados
{

	public class ClsAgregar
	{
		public FrmAgregar frmA;

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
		public void CargarComboLugaresPago()
		{
			DataTable dt = ObtenerLugaresPago();

			if (dt == null || dt.Rows.Count == 0)
				return;

			dt.Columns.Add("LugarPagoCompleto");

			foreach (DataRow row in dt.Rows)
			{
				row["LugarPagoCompleto"] =
					row["IdLugarPago"].ToString()
					+ " - " +
					row["NombreLugarPago"].ToString();
			}

			frmA.cboLugarPago.DataSource = dt;

			frmA.cboLugarPago.DisplayMember =
				"LugarPagoCompleto";

			frmA.cboLugarPago.ValueMember =
				"IdLugarPago";

			frmA.cboLugarPago.DropDownStyle =
				ComboBoxStyle.DropDown;

			frmA.cboLugarPago.AutoCompleteMode =
				AutoCompleteMode.SuggestAppend;

			frmA.cboLugarPago.AutoCompleteSource =
				AutoCompleteSource.ListItems;

			frmA.cboLugarPago.SelectedIndex = -1;
			frmA.cboLugarPago.Text = "";
		}
		public DataTable ObtenerLugaresPago()
		{
			SQLControl sql = new SQLControl();
			DataTable dt = new DataTable();

			try
			{
				sql.OpenConectionWrite();

				string query = @"
            SELECT
                id_placePayment AS IdLugarPago,
                v_namePlace AS NombreLugarPago
            FROM Nom_PlacePayment
            WHERE c_activePlace = 1
            ORDER BY v_namePlace";

				using (SqlCommand cmd = new SqlCommand(query, sql.cnn))
				{
					SqlDataAdapter da = new SqlDataAdapter(cmd);
					da.Fill(dt);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					ex.Message,
					"Error al cargar lugares de pago",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
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
			// OBTENER ACTIVIDAD
			// -----------------------------------------

			string actividad =
				frmA.cboActividad.Text.Trim();

			string idActividad =
				frmA.cboActividad.SelectedValue?.ToString();

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
					row["IdLugarPago"].ToString(),
					idActividad
				);
			}

			// -----------------------------------------
			// LIMPIAR CÓDIGOS
			// -----------------------------------------

			frmA.txbCodigo.Clear();
			frmA.txbCodigo.Focus();
		}
		public void ModificarEmpleado()
		{
			// =========================
			// VALIDAR CÓDIGO
			// =========================

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

			// =========================
			// VALIDAR LUGAR DE PAGO
			// =========================

			if (frmA.cboLugarPago.SelectedIndex < 0)
			{
				MessageBox.Show(
					"Seleccione un lugar de pago.",
					"Lugar de pago",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				frmA.cboLugarPago.Focus();
				return;
			}

			// =========================
			// VALIDAR ACTIVIDAD
			// =========================

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

			// =========================
			// OBTENER DATOS
			// =========================

			string codigo =
				frmA.txbCodigo.Text.Trim();

			string empleado =
				frmA.txbEmpleado.Text.Trim();

			string lugarPago =
				frmA.cboLugarPago.Text.Trim();

			string actividad =
				frmA.cboActividad.Text.Trim();

			string idLugarPago =
				frmA.cboLugarPago.SelectedValue?.ToString();

			string idActividad =
				frmA.cboActividad.SelectedValue?.ToString();

			// =========================
			// MOSTRAR EN EL DGV
			// =========================

			frmA.dgvListadoAgregar.Rows.Clear();

			frmA.dgvListadoAgregar.Rows.Add(
				codigo,
				empleado,
				lugarPago,
				actividad,
				idLugarPago,
				idActividad
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

				E.v_name + ' ' +
				E.v_lastNamePat + ' ' +
				E.v_lastNameMat AS Empleado,

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

			dgv.Columns[0].FillWeight = 15; // Código
			dgv.Columns[1].FillWeight = 50; // Empleado
			dgv.Columns[2].FillWeight = 25; // Lugar de pago
			dgv.Columns[3].FillWeight = 25; // Actividad


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
		}
	}
}
