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

			//  obtener nombre
			string nombre = ObtenerNombreEmpleado(codigoFmt);

			if (string.IsNullOrEmpty(nombre))
			{
				MessageBox.Show("Empleado no encontrado");
				return;
			}

			//  texto del combo (YA incluye código + nombre)
			string actividadTexto = frm.cboActividad.Text;

			//  evitar duplicados
			foreach (DataGridViewRow row in frm.dgvAsistencia.Rows)
			{
				if (row.IsNewRow) continue;

				string codigoExistente = row.Cells["EMPLEADO"].Tag?.ToString() ?? "";

				if (codigoExistente == codigoFmt)
				{
					MessageBox.Show("El empleado ya está agregado");
					return;
				}
			}

			//  lo que se muestra
			string empleadoTexto = codigoFmt + " - " + nombre;
			string actividadMostrar = actividadTexto; 

			int rowIndex = frm.dgvAsistencia.Rows.Add(
				empleadoTexto,
				actividadMostrar,
				bandaFmt
			);

			//  datos reales (para SQL)
			frm.dgvAsistencia.Rows[rowIndex].Cells["EMPLEADO"].Tag = codigoFmt;
			frm.dgvAsistencia.Rows[rowIndex].Cells["ACTIVIDAD"].Tag = actividadFmt;
			frm.dgvAsistencia.Rows[rowIndex].Cells["BANDA"].Tag = bandaFmt;

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

			//  CREAR COLUMNAS
			frm.dgvAsistencia.Columns.Add("EMPLEADO", "Codigo");
			frm.dgvAsistencia.Columns.Add("ACTIVIDAD", "Actividad");
			frm.dgvAsistencia.Columns.Add("BANDA", "Banda");

			// Opcional (mejor vista)
			frm.dgvAsistencia.Columns["EMPLEADO"].Width = 250;
			frm.dgvAsistencia.Columns["ACTIVIDAD"].Width = 200;
			frm.dgvAsistencia.Columns["BANDA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
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

			//  encabezado
			dgv.EnableHeadersVisualStyles = false;
			dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

			dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 66, 91);
			dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
			dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
			dgv.ColumnHeadersHeight = 35;

			//  quitar sombreado encabezado
			dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = dgv.ColumnHeadersDefaultCellStyle.BackColor;
			dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = dgv.ColumnHeadersDefaultCellStyle.ForeColor;

			//  celdas
			dgv.DefaultCellStyle.BackColor = Color.White;
			dgv.DefaultCellStyle.ForeColor = Color.Black;
			dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);

			//  quitar sombreado selección
			dgv.DefaultCellStyle.SelectionBackColor = dgv.DefaultCellStyle.BackColor;
			dgv.DefaultCellStyle.SelectionForeColor = dgv.DefaultCellStyle.ForeColor;

			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgv.MultiSelect = false;
			dgv.AllowUserToAddRows = false;
		}
		public void ConvertirIdsANombres()
		{
			List<string> empleados = new List<string>();
			List<string> actividades = new List<string>();

			// Obtener IDs del grid
			foreach (DataGridViewRow row in frm.dgvAsistencia.Rows)
			{
				if (row.IsNewRow) continue;

				var emp = row.Cells["EMPLEADO"].Value?.ToString();
				var act = row.Cells["ACTIVIDAD"].Value?.ToString();

				if (!string.IsNullOrEmpty(emp))
					empleados.Add(emp);

				if (!string.IsNullOrEmpty(act))
					actividades.Add(act);
			}

			empleados = empleados.Distinct().ToList();
			actividades = actividades.Distinct().ToList();

			if (empleados.Count == 0 && actividades.Count == 0)
				return;

			// QUERIES CON TUS TABLAS REALES
			string queryEmpleados = $@"
			SELECT id_employee,
				    v_lastNamePat + ' ' + v_lastNameMat + ' ' + v_name AS Nombre
			FROM Nom_Employees
			WHERE id_employee IN ({string.Join(",", empleados.Select(x => $"'{x}'"))})";

					string queryActividades = $@"
			SELECT c_codigo_tab, v_descripcion_tab
			FROM Nom_Tabulador
			WHERE c_codigo_tab IN ({string.Join(",", actividades.Select(x => $"'{x}'"))})";

			Dictionary<string, string> dicEmpleados = new Dictionary<string, string>();
			Dictionary<string, string> dicActividades = new Dictionary<string, string>();

		
			sql.OpenConectionWrite();

			//  EMPLEADOS
			using (SqlCommand cmd = new SqlCommand(queryEmpleados, sql.cnn))
			{
				using (SqlDataReader dr = cmd.ExecuteReader())
				{
					while (dr.Read())
					{
						dicEmpleados[dr["id_employee"].ToString()] = dr["Nombre"].ToString();
					}
				}
			}

			//  ACTIVIDADES
			using (SqlCommand cmd = new SqlCommand(queryActividades, sql.cnn))
			{
				using (SqlDataReader dr = cmd.ExecuteReader())
				{
					while (dr.Read())
					{
						dicActividades[dr["c_codigo_tab"].ToString()] = dr["v_descripcion_tab"].ToString();
					}
				}
			}

			sql.CloseConectionWrite(); // si tienes método

			//  REEMPLAZAR EN EL GRID (ID + NOMBRE)
			foreach (DataGridViewRow row in frm.dgvAsistencia.Rows)
			{
				if (row.IsNewRow) continue;

				string idEmpleado = row.Cells["EMPLEADO"].Value?.ToString();
				string idActividad = row.Cells["ACTIVIDAD"].Value?.ToString();

				if (dicEmpleados.ContainsKey(idEmpleado))
					row.Cells["EMPLEADO"].Value = $"{idEmpleado} - {dicEmpleados[idEmpleado]}";

				if (dicActividades.ContainsKey(idActividad))
					row.Cells["ACTIVIDAD"].Value = $"{idActividad} - {dicActividades[idActividad]}";
			}
		}
	}
}
