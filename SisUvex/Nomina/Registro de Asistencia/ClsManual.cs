using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.SS.Formula.Functions;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Values;

namespace SisUvex.Nomina.Registro_de_Asistencia
{
	public class ClsManual
	{
		public FrmRegistroA frm;
		SQLControl sql = new SQLControl();
		public void BeginForm()
		{
			ClsComboBoxes.CboLoadActives(frm.cboLinea, ClsObject.ProductionLine.Cbo);
		}
		public void CargarComboActividades()
		{
			DataTable dtActividades = ObtenerActividades();

			dtActividades.Columns.Add("ActividadCompleta");

			foreach (DataRow row in dtActividades.Rows)
			{
				row["ActividadCompleta"] = row["c_codigo_tab"] + " - " + row["v_descripcion_tab"];
			}

			frm.cboActividad.DataSource = dtActividades;
			frm.cboActividad.DisplayMember = "ActividadCompleta"; 
			frm.cboActividad.ValueMember = "c_codigo_tab";

			frm.cboActividad.DropDownStyle = ComboBoxStyle.DropDown;
			frm.cboActividad.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			frm.cboActividad.AutoCompleteSource = AutoCompleteSource.ListItems; 

			frm.cboActividad.SelectedIndex = -1;
			frm.cboActividad.Text = "";
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
				WHERE TRY_CAST(c_codigo_tab AS INT) BETWEEN 1501 AND 1524
				ORDER BY c_codigo_tab";

				SqlCommand cmd = new SqlCommand(query, sql.cnn);

				SqlDataAdapter da = new SqlDataAdapter(cmd);
				da.Fill(dt);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			return dt;
		}
		public DataRow ObtenerEmpleadoPorCodigo(string idEmpleado)
		{
			
			DataTable dt = new DataTable();

			try
			{
				sql.OpenConectionWrite();

				string query = @"
				SELECT 
					id_employee,
					v_lastNamePat + ' ' + v_lastNameMat + ' ' + v_name AS NombreCompleto
				FROM dbo.Nom_Employees
				WHERE id_employee = @id";

				SqlCommand cmd = new SqlCommand(query, sql.cnn);
				cmd.Parameters.AddWithValue("@id", idEmpleado);

				SqlDataAdapter da = new SqlDataAdapter(cmd);
				da.Fill(dt);

				if (dt.Rows.Count > 0)
					return dt.Rows[0];
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			return null;
		}
		public void btnAgregarEmpleado()
		{
			string idEmpleado = ClsValues.FormatZeros(frm.txbCodigo.Text, "000000");

			DataRow row = ObtenerEmpleadoPorCodigo(idEmpleado);

			if (row == null)
			{
				MessageBox.Show("Empleado no encontrado");
				return;
			}

			
			frm.txbCodigo.Text = row["id_employee"].ToString();
			frm.txbEmpleado.Text = row["NombreCompleto"].ToString();

			frm.txbCodigo.Focus();
			frm.txbCodigo.SelectAll();
		}
		public void AgregarADgv()
		{
			string codigo = frm.txbCodigo.Text.Trim();
			string actividad = frm.cboActividad.SelectedValue?.ToString();
			string banda = frm.cboLinea.SelectedValue?.ToString();

			if (string.IsNullOrEmpty(codigo))
			{
				MessageBox.Show("Ingrese un código");
				return;
			}

			if (string.IsNullOrEmpty(actividad))
			{
				MessageBox.Show("Seleccione actividad");
				return;
			}

			string codigoFmt = ClsValues.FormatZeros(codigo, "000000");
			string actividadFmt = ClsValues.FormatZeros(actividad, "0000");
			string bandaFmt = string.IsNullOrEmpty(banda) ? "" : banda.PadLeft(3, '0');

			// 🔎 obtener nombre
			string nombre = ObtenerNombreEmpleado(codigoFmt);

			if (string.IsNullOrEmpty(nombre))
			{
				MessageBox.Show("Empleado no encontrado");
				return;
			}

			// 🔎 texto del combo (YA incluye código + nombre)
			string actividadTexto = frm.cboActividad.Text;

			// 🚫 evitar duplicados
			foreach (DataGridViewRow row in frm.dgvAsistencia.Rows)
			{
				string codigoExistente = row.Cells["idEmpleado"].Tag?.ToString();

				if (codigoExistente == codigoFmt)
				{
					MessageBox.Show("El empleado ya está agregado");
					return;
				}
			}

			// 👇 lo que se muestra
			string empleadoTexto = codigoFmt + " - " + nombre;
			string actividadMostrar = actividadTexto; // 👈 SIN duplicar código

			int rowIndex = frm.dgvAsistencia.Rows.Add(
				empleadoTexto,
				actividadMostrar,
				bandaFmt
			);

			// 🔥 datos reales (para SQL)
			frm.dgvAsistencia.Rows[rowIndex].Cells["idEmpleado"].Tag = codigoFmt;
			frm.dgvAsistencia.Rows[rowIndex].Cells["idActividad"].Tag = actividadFmt;
			frm.dgvAsistencia.Rows[rowIndex].Cells["idBanda"].Tag = bandaFmt;

			// 🧹 limpiar
			frm.txbCodigo.Clear();
			frm.txbEmpleado.Clear();
			frm.cboActividad.SelectedIndex = -1;
			frm.cboLinea.SelectedIndex = -1;

			frm.txbCodigo.Focus();
		}
		public void InicializarDgv()
		{
			frm.dgvAsistencia.Columns.Clear();

			frm.dgvAsistencia.Columns.Add("idEmpleado", "Codigo");
			frm.dgvAsistencia.Columns.Add("idActividad", "Actividad");
			frm.dgvAsistencia.Columns.Add("idBanda", "Banda");

			// Opcional (mejor vista)
			frm.dgvAsistencia.Columns["idEmpleado"].Width = 250;
			frm.dgvAsistencia.Columns["idActividad"].Width = 200;
			frm.dgvAsistencia.Columns["idBanda"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		}
		public string ObtenerNombreEmpleado(string idEmpleado)
		{
			DataRow row = ObtenerEmpleadoPorCodigo(idEmpleado);

			if (row != null)
			{
				return row["NombreCompleto"].ToString();
			}

			return "";
		}
		public void EstiloDgv()
		{
			var dgv = frm.dgvAsistencia;

			dgv.BorderStyle = BorderStyle.None;
			dgv.CellBorderStyle = DataGridViewCellBorderStyle.Single;
			dgv.GridColor = Color.LightGray;
			dgv.RowHeadersVisible = false;

			// 🔹 encabezado
			dgv.EnableHeadersVisualStyles = false;
			dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

			dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 66, 91);
			dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
			dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
			dgv.ColumnHeadersHeight = 35;

			// ❌ quitar sombreado encabezado
			dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = dgv.ColumnHeadersDefaultCellStyle.BackColor;
			dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = dgv.ColumnHeadersDefaultCellStyle.ForeColor;

			// 🔹 celdas
			dgv.DefaultCellStyle.BackColor = Color.White;
			dgv.DefaultCellStyle.ForeColor = Color.Black;
			dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);

			// ❌ quitar sombreado selección
			dgv.DefaultCellStyle.SelectionBackColor = dgv.DefaultCellStyle.BackColor;
			dgv.DefaultCellStyle.SelectionForeColor = dgv.DefaultCellStyle.ForeColor;

			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgv.MultiSelect = false;
			dgv.AllowUserToAddRows = false;
		}
	}
}
