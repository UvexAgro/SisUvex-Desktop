using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.SS.Formula.Functions;

namespace SisUvex.Nomina.Nom_Consulta_de_Actividad_por_empleado
{
	public class ClsConsulta
	{
		public FrmConsulta frm;
		public void CargarSemanas()
		{
			SQLControl sql = new SQLControl();

			string query = @"
			SELECT
				c_sequence_per,
				d_startDate_per,
				d_endDate_per
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

			// El ComboBox SOLO mostrará c_sequence_per
			frm.cboSemana.DataSource = null;

			frm.cboSemana.DisplayMember = "c_sequence_per";
			frm.cboSemana.ValueMember = "c_sequence_per";

			frm.cboSemana.DataSource = dt;
			// AQUÍ SE HACE LA REFERENCIA
			frm.cboSemana.SelectedIndexChanged += (s, e) =>
			{
				CargarFechasSemana();
			};

			// Seleccionar la semana actual
			SeleccionarSemanaActual(dt);
		}
		private void SeleccionarSemanaActual(DataTable dt)
		{
			DateTime fechaActual = DateTime.Today;

			foreach (DataRow row in dt.Rows)
			{
				DateTime fechaInicio =
					Convert.ToDateTime(row["d_startDate_per"]).Date;

				DateTime fechaFin =
					Convert.ToDateTime(row["d_endDate_per"]).Date;

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
		private void CargarFechasSemana()
		{
			if (frm.cboSemana.SelectedIndex < 0)
				return;

			if (frm.cboSemana.SelectedItem == null)
				return;

			DataRowView fila =
				frm.cboSemana.SelectedItem as DataRowView;

			if (fila == null)
				return;

			frm.dtpInicio.Value =
				Convert.ToDateTime(fila["d_startDate_per"]).Date;

			frm.dtpFinal.Value =
				Convert.ToDateTime(fila["d_endDate_per"]).Date;
		}
		public DataTable ConsultarEmpleado(string codigo)
		{
			SQLControl sql = new SQLControl();

			DataTable dt = new DataTable();

			string query = @"
			SELECT
				id_employee AS Codigo,
				LTRIM(RTRIM(
					ISNULL(v_lastNamePat, '') + ' ' +
					ISNULL(v_lastNameMat, '') + ' ' +
					ISNULL(v_name, '')
				)) AS Nombre,
				id_paymentPlace AS LugarPago
			FROM SisUvex.dbo.Nom_Employees
			WHERE id_employee = @Empleado;";

			try
			{
				sql.OpenConectionWrite();

				using (SqlCommand cmd = new SqlCommand(query, sql.cnn))
				{
					cmd.Parameters.AddWithValue("@Empleado", codigo);

					using (SqlDataAdapter da = new SqlDataAdapter(cmd))
					{
						da.Fill(dt);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error al consultar el empleado:\n" + ex.Message,
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			finally
			{
				sql.CloseConectionWrite();
			}

			return dt;
		}
		public void Empleado()
		{
			string codigo = frm.txbCodigo.Text.Trim();

			if (string.IsNullOrWhiteSpace(codigo))
			{
				MessageBox.Show(
					"Capture el código del empleado.",
					"Consulta de empleado",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				frm.txbCodigo.Focus();
				return;
			}

			DataTable dt = ConsultarEmpleado(codigo);

			if (dt == null || dt.Rows.Count == 0)
			{
				frm.lblCodigo.Text = "-";
				frm.lblNombre.Text = "-";
				frm.lblLugardePago.Text = "-";

				MessageBox.Show(
					"No se encontró el empleado.",
					"Consulta de empleado",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				frm.txbCodigo.SelectAll();
				frm.txbCodigo.Focus();

				return;
			}

			DataRow row = dt.Rows[0];

			// Código
			frm.lblCodigo.Text = row["Codigo"].ToString();

			// Apellidos primero y después nombre
			frm.lblNombre.Text = row["Nombre"].ToString();

			// Lugar de pago
			frm.lblLugardePago.Text = row["LugarPago"].ToString();

			frm.txbCodigo.Clear();
		}
		public DataSet ConsultarActividadesEmpleado(string semana, string empleado)
		{
			SQLControl sql = new SQLControl();
			DataSet ds = new DataSet();

			try
			{
				sql.OpenConectionWrite();

				using (SqlCommand cmd = new SqlCommand(
					"dbo.sp_ConsultaActividadesEmpleado",
					sql.cnn))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue("@Semana", semana);
					cmd.Parameters.AddWithValue("@Empleado", empleado);

					using (SqlDataAdapter da = new SqlDataAdapter(cmd))
					{
						da.Fill(ds);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error al consultar las actividades:\n" + ex.Message,
					"Consulta",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			finally
			{
				sql.CloseConectionWrite();
			}

			return ds;
		}
		public void CargarActividadesEmpleado(string empleado)
		{
			if (string.IsNullOrWhiteSpace(empleado) || empleado == "-")
				return;

			if (frm.cboSemana.SelectedIndex < 0)
				return;

			string semana = frm.cboSemana.SelectedValue.ToString();

			DataSet ds = ConsultarActividadesEmpleado(
				semana,
				empleado);

			if (ds == null || ds.Tables.Count == 0)
			{
				frm.dgvNomina.DataSource = null;
				return;
			}

			// Copiar el detalle
			DataTable dt = ds.Tables[0].Copy();

			// =========================================================
			// AGREGAR RESUMEN
			// =========================================================

			if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
			{
				DataRow resumen = ds.Tables[1].Rows[0];

				// IMPORTE
				DataRow filaImporte = dt.NewRow();

				filaImporte["ACTIVIDAD"] = "IMPORTE";
				filaImporte["IMPORTE"] = resumen["IMPORTE"];

				dt.Rows.Add(filaImporte);


				// DESCUENTO
				DataRow filaDescuento = dt.NewRow();

				filaDescuento["ACTIVIDAD"] = "DESCUENTO";
				filaDescuento["IMPORTE"] = resumen["DESCUENTO"];

				dt.Rows.Add(filaDescuento);


				// TOTAL A PAGAR
				DataRow filaTotal = dt.NewRow();

				filaTotal["ACTIVIDAD"] = "TOTAL A PAGAR";
				filaTotal["IMPORTE"] = resumen["TOTAL_A_PAGAR"];

				dt.Rows.Add(filaTotal);
			}


			// =========================================================
			// CARGAR DGV
			// =========================================================

			frm.dgvNomina.DataSource = dt;

			// Aplicar diseño DESPUÉS de cargar
			DiseñarDgvNomina();
		}
		private void DiseñarDgvNomina()
		{
			DataGridView dgv = frm.dgvNomina;

			if (dgv.Columns.Count == 0)
				return;


			// =========================================================
			// CONFIGURACIÓN GENERAL
			// =========================================================

			dgv.AutoSizeColumnsMode =
				DataGridViewAutoSizeColumnsMode.Fill;

			dgv.AutoSizeRowsMode =
				DataGridViewAutoSizeRowsMode.None;

			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToDeleteRows = false;
			dgv.AllowUserToResizeRows = false;

			dgv.ReadOnly = true;

			dgv.SelectionMode =
				DataGridViewSelectionMode.FullRowSelect;

			dgv.MultiSelect = false;

			dgv.RowHeadersVisible = false;

			dgv.BorderStyle = BorderStyle.FixedSingle;

			dgv.CellBorderStyle =
				DataGridViewCellBorderStyle.SingleHorizontal;

			dgv.GridColor =
				Color.FromArgb(210, 220, 230);

			dgv.BackgroundColor =
				Color.White;

			dgv.EnableHeadersVisualStyles = false;


			// =========================================================
			// ENCABEZADOS
			// =========================================================

			dgv.ColumnHeadersDefaultCellStyle.BackColor =
				Color.FromArgb(38, 111, 157);

			dgv.ColumnHeadersDefaultCellStyle.ForeColor =
				Color.White;

			dgv.ColumnHeadersDefaultCellStyle.Font =
				new Font("Segoe UI", 9F, FontStyle.Bold);

			dgv.ColumnHeadersDefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			// Evitar cambio de color al seleccionar encabezado
			dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor =
				Color.FromArgb(38, 111, 157);

			dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor =
				Color.White;

			dgv.ColumnHeadersHeight = 32;


			// =========================================================
			// FILAS
			// =========================================================

			dgv.DefaultCellStyle.Font =
				new Font("Segoe UI", 9F);

			dgv.DefaultCellStyle.ForeColor =
				Color.FromArgb(35, 50, 65);

			dgv.DefaultCellStyle.BackColor =
				Color.White;

			dgv.DefaultCellStyle.SelectionBackColor =
				Color.FromArgb(220, 235, 245);

			dgv.DefaultCellStyle.SelectionForeColor =
				Color.FromArgb(20, 55, 80);

			dgv.DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleLeft;

			dgv.DefaultCellStyle.Padding =
				new Padding(4, 0, 4, 0);

			dgv.RowTemplate.Height = 38;


			// Filas alternadas
			dgv.AlternatingRowsDefaultCellStyle.BackColor =
				Color.FromArgb(245, 248, 251);


			// =========================================================
			// FORZAR ALTURA DE LAS FILAS EXISTENTES
			// =========================================================

			foreach (DataGridViewRow fila in dgv.Rows)
			{
				if (!fila.IsNewRow)
				{
					fila.Height = 36;
				}
			}


			// =========================================================
			// FECHA
			// =========================================================

			if (dgv.Columns.Contains("FECHA"))
			{
				dgv.Columns["FECHA"].HeaderText = "FECHA";

				dgv.Columns["FECHA"]
					.DefaultCellStyle.Format = "dd/MM/yyyy";

				dgv.Columns["FECHA"]
					.DefaultCellStyle.Alignment =
						DataGridViewContentAlignment.MiddleCenter;
			}


			// =========================================================
			// LOTE
			// =========================================================

			if (dgv.Columns.Contains("LOTE"))
			{
				dgv.Columns["LOTE"].HeaderText = "LOTE";

				dgv.Columns["LOTE"]
					.DefaultCellStyle.Alignment =
						DataGridViewContentAlignment.MiddleLeft;
			}


			// =========================================================
			// ACTIVIDAD
			// =========================================================

			if (dgv.Columns.Contains("ACTIVIDAD"))
			{
				dgv.Columns["ACTIVIDAD"]
					.HeaderText = "ACTIVIDAD";

				dgv.Columns["ACTIVIDAD"]
					.DefaultCellStyle.Alignment =
						DataGridViewContentAlignment.MiddleLeft;
			}


			// =========================================================
			// LUGAR DE PAGO
			// =========================================================

			if (dgv.Columns.Contains("LP"))
			{
				dgv.Columns["LP"].Visible = false;
			}


			// =========================================================
			// IMPORTE
			// =========================================================

			if (dgv.Columns.Contains("IMPORTE"))
			{
				dgv.Columns["IMPORTE"]
					.HeaderText = "IMPORTE";

				dgv.Columns["IMPORTE"]
					.DefaultCellStyle.Format = "C2";

				dgv.Columns["IMPORTE"]
					.DefaultCellStyle.Alignment =
						DataGridViewContentAlignment.MiddleRight;
			}


			// =========================================================
			// OCULTAR COLUMNAS
			// =========================================================

			if (dgv.Columns.Contains("ID_LOTE"))
				dgv.Columns["ID_LOTE"].Visible = false;

			if (dgv.Columns.Contains("ID_ACTIVIDAD"))
				dgv.Columns["ID_ACTIVIDAD"].Visible = false;


			// =========================================================
			// ORDEN DE COLUMNAS
			// =========================================================

			if (dgv.Columns.Contains("FECHA"))
				dgv.Columns["FECHA"].DisplayIndex = 0;

			if (dgv.Columns.Contains("LOTE"))
				dgv.Columns["LOTE"].DisplayIndex = 1;

			if (dgv.Columns.Contains("ACTIVIDAD"))
				dgv.Columns["ACTIVIDAD"].DisplayIndex = 2;

			if (dgv.Columns.Contains("IMPORTE"))
				dgv.Columns["IMPORTE"].DisplayIndex = 3;


			// =========================================================
			// NO PERMITIR ORDENAR
			// =========================================================

			foreach (DataGridViewColumn columna in dgv.Columns)
			{
				columna.SortMode =
					DataGridViewColumnSortMode.NotSortable;
			}


			// =========================================================
			// FORMATO DEL RESUMEN
			// =========================================================

			foreach (DataGridViewRow fila in dgv.Rows)
			{
				if (fila.IsNewRow)
					continue;

				string actividad = "";

				if (fila.Cells["ACTIVIDAD"].Value != null)
				{
					actividad =
						fila.Cells["ACTIVIDAD"].Value.ToString().Trim();
				}


				// =====================================================
				// IMPORTE
				// =====================================================

				if (actividad == "IMPORTE")
				{
					fila.DefaultCellStyle.Font =
						new Font("Segoe UI", 9F, FontStyle.Bold);

					fila.DefaultCellStyle.BackColor =
						Color.FromArgb(220, 235, 245);

					fila.DefaultCellStyle.ForeColor =
						Color.FromArgb(20, 55, 80);

					fila.DefaultCellStyle.SelectionBackColor =
						Color.FromArgb(220, 235, 245);

					fila.DefaultCellStyle.SelectionForeColor =
						Color.FromArgb(20, 55, 80);

					fila.Height = 38;
				}


				// =====================================================
				// DESCUENTO
				// =====================================================

				if (actividad == "DESCUENTO")
				{
					fila.DefaultCellStyle.Font =
						new Font("Segoe UI", 9F, FontStyle.Bold);

					fila.DefaultCellStyle.BackColor =
						Color.FromArgb(252, 230, 230);

					fila.DefaultCellStyle.ForeColor =
						Color.FromArgb(190, 40, 40);

					fila.DefaultCellStyle.SelectionBackColor =
						Color.FromArgb(252, 230, 230);

					fila.DefaultCellStyle.SelectionForeColor =
						Color.FromArgb(190, 40, 40);

					fila.Height = 38;
				}


				// =====================================================
				// TOTAL A PAGAR
				// =====================================================

				if (actividad == "TOTAL A PAGAR")
				{
					fila.DefaultCellStyle.Font =
						new Font("Segoe UI", 9F, FontStyle.Bold);

					fila.DefaultCellStyle.BackColor =
						Color.FromArgb(190, 220, 238);

					fila.DefaultCellStyle.ForeColor =
						Color.FromArgb(0, 82, 145);

					fila.DefaultCellStyle.SelectionBackColor =
						Color.FromArgb(190, 220, 238);

					fila.DefaultCellStyle.SelectionForeColor =
						Color.FromArgb(0, 82, 145);

					fila.Height = 38;
				}
			}
		}
	}
}