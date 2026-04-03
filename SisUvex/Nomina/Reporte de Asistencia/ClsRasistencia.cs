using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SisUvex.Catalogos;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.WorkGroup;
using static SisUvex.Catalogos.Metods.ClsObject;
using System.Drawing;
using DrawingColor = System.Drawing.Color;



namespace SisUvex.Nomina.Reporte_de_Asistencia
{
	internal class ClsRasistencia
	{
		public FrmAsistenciaR frmR;
		bool bloqueando = false;
		bool cargando = false;
		bool navegando = false;
		bool seleccionando = false;
		private DataTable dtEmpleados;
		private DataTable dtDgvEmpleados;

		public void CargarPeriodos()
		{
			cargando = true;
			// Cargar combos
			ClsComboBoxes.CboLoadActives(frmR.cboSemanaInicial, Payroll_AttendancePeriod.Cbo);
			ClsComboBoxes.CboLoadActives(frmR.cboSemanaFinal, Payroll_AttendancePeriod.Cbo);

			DateTime hoy = DateTime.Today;

			for (int i = 0; i < frmR.cboSemanaInicial.Items.Count; i++)
			{
				DataRowView row = (DataRowView)frmR.cboSemanaInicial.Items[i];

				if (row[Payroll_AttendancePeriod.ColumnStartDate] == DBNull.Value ||
					row[Payroll_AttendancePeriod.ColumnEndDate] == DBNull.Value)
				{
					continue;
				}

				DateTime fechaInicio = Convert.ToDateTime(row[Payroll_AttendancePeriod.ColumnStartDate]);
				DateTime fechaFin = Convert.ToDateTime(row[Payroll_AttendancePeriod.ColumnEndDate]);

				if (hoy >= fechaInicio && hoy <= fechaFin)
				{
					if (i < frmR.cboSemanaInicial.Items.Count)
					{
						frmR.cboSemanaInicial.SelectedIndex = i;
					}

					if (i < frmR.cboSemanaFinal.Items.Count)
					{
						frmR.cboSemanaFinal.SelectedIndex = i;
					}
					break;
				}
			}
					cargando = false;
			
		}
		public void CargarCuadrillas()
		{
			cargando = true;

			ClsCatalogos cls = new ClsCatalogos();
			DataTable dt = cls.CboCuadrilla("");

			frmR.cboCuadrilla.DataSource = dt;
			frmR.cboCuadrilla.DisplayMember = "Nombre";
			frmR.cboCuadrilla.ValueMember = "Código";

			if (dt.Rows.Count > 0)
			{
				frmR.cboCuadrilla.SelectedIndex = 0;
			}

			cargando = false;
		}
		public void CargarAsistencia()
		{
			SQLControl sql = new SQLControl();
			DataTable dt = new DataTable();

			try
			{
				
				if (frmR.cboCuadrilla.SelectedValue == null)
				{
					MessageBox.Show("Selecciona una cuadrilla");
					return;
				}

				
				if (frmR.cboSemanaInicial.SelectedItem == null || frmR.cboSemanaFinal.SelectedItem == null)
				{
					MessageBox.Show("Selecciona las semanas");
					return;
				}

				DataRowView rowInicio = (DataRowView)frmR.cboSemanaInicial.SelectedItem;
				DataRowView rowFin = (DataRowView)frmR.cboSemanaFinal.SelectedItem;

				
				if (rowInicio[Payroll_AttendancePeriod.ColumnStartDate] == DBNull.Value ||
					rowFin[Payroll_AttendancePeriod.ColumnEndDate] == DBNull.Value)
				{
					MessageBox.Show("Las semanas seleccionadas no son válidas");
					return;
				}

				DateTime fechaInicio = Convert.ToDateTime(rowInicio[Payroll_AttendancePeriod.ColumnStartDate]);
				DateTime fechaFin = Convert.ToDateTime(rowFin[Payroll_AttendancePeriod.ColumnEndDate]);

				
				if (fechaInicio > fechaFin)
				{
					MessageBox.Show("La semana inicial no puede ser mayor a la final");
					return;
				}

				sql.OpenConectionWrite();

				string cuadrilla = frmR.cboCuadrilla.SelectedValue.ToString().PadLeft(2, '0');

				string query = @"
				SELECT *
				FROM dbo.fn_attendancebyCrew(@FechaInicio, @FechaFin, @Cuadrilla)
				ORDER BY Nombre ASC";

				SqlCommand cmd = new SqlCommand(query, sql.cnn);

				cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
				cmd.Parameters.AddWithValue("@FechaFin", fechaFin);
				cmd.Parameters.AddWithValue("@Cuadrilla", cuadrilla);

				SqlDataAdapter da = new SqlDataAdapter(cmd);
				da.Fill(dt);
				if (dt.Rows.Count == 0)
				{
					frmR.dgvEmployee.DataSource = null; 
					MessageBox.Show("La cuadrilla seleccionada no tiene asistencia en el periodo indicado.");
					return;
				}


				frmR.dgvEmployee.DataSource = null;
				frmR.dgvEmployee.DataSource = dt;

				EstiloDGV(frmR.dgvEmployee);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		private void EstiloDGV(DataGridView dgv)
		{
			// Quitar bordes
			dgv.BorderStyle = BorderStyle.None;
			dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
			dgv.RowHeadersVisible = false;

			// Colores generales
			dgv.BackgroundColor = DrawingColor.White;
			dgv.GridColor = DrawingColor.LightGray;

			// Encabezados
			dgv.EnableHeadersVisualStyles = false;
			dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

			dgv.ColumnHeadersDefaultCellStyle.BackColor = DrawingColor.FromArgb(220, 230, 241);
			dgv.ColumnHeadersDefaultCellStyle.ForeColor = DrawingColor.Black;
			dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
			dgv.ColumnHeadersHeight = 35;

			// Filas
			dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);
			dgv.DefaultCellStyle.BackColor = DrawingColor.White;
			dgv.DefaultCellStyle.ForeColor = DrawingColor.Black;
			dgv.DefaultCellStyle.SelectionBackColor = DrawingColor.White;
			dgv.DefaultCellStyle.SelectionForeColor = DrawingColor.Black;

			// Filas alternadas
			dgv.AlternatingRowsDefaultCellStyle.BackColor = DrawingColor.FromArgb(245, 245, 245);
			dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = DrawingColor.FromArgb(245, 245, 245);
			dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = DrawingColor.Black;

			dgv.RowsDefaultCellStyle.SelectionBackColor = DrawingColor.White;
			dgv.RowsDefaultCellStyle.SelectionForeColor = DrawingColor.Black;

			// Ajuste automático
			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

			// Altura de filas
			dgv.RowTemplate.Height = 30;

			// Quitar selección visual de fila
			dgv.SelectionMode = DataGridViewSelectionMode.CellSelect;
			dgv.MultiSelect = false;

			// Opcional: solo lectura
			dgv.ReadOnly = true;

			dgv.ClearSelection();
		}
		public DataTable ObtenerEmpleados()
		{
			SQLControl sql = new SQLControl();
			DataTable dt = new DataTable();

			try
			{
				sql.OpenConectionWrite();

				string query = @"
			SELECT 
				id_employee,
				RIGHT('000000' + CAST(id_employee AS VARCHAR), 6) + ' - ' +
				UPPER(v_lastNamePat + ' ' + v_lastNameMat + ' ' + v_name) AS NombreCompleto
			FROM Nom_Employees";

				SqlDataAdapter da = new SqlDataAdapter(query, sql.cnn);
				da.Fill(dt);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			return dt;
		}
		public void CargarCombo()
		{
			dtEmpleados = ObtenerEmpleados();

			frmR.cboEmployee.DataSource = dtEmpleados;
			frmR.cboEmployee.DisplayMember = "NombreCompleto";
			frmR.cboEmployee.ValueMember = "id_employee";
			frmR.cboEmployee.DropDownStyle = ComboBoxStyle.DropDown;
			frmR.cboEmployee.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			frmR.cboEmployee.AutoCompleteSource = AutoCompleteSource.CustomSource;

			AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();

			foreach (DataRow row in dtEmpleados.Rows)
			{
				string id = row["id_employee"].ToString().PadLeft(6, '0');
				string nombreCompleto = row["NombreCompleto"].ToString();

				string[] partes = nombreCompleto.Split('-');
				string soloNombre = partes.Length > 1 ? partes[1].Trim() : nombreCompleto;

				coleccion.Add(id + " - " + soloNombre);
				coleccion.Add(soloNombre + " - " + id);
			}

			frmR.cboEmployee.AutoCompleteCustomSource = coleccion;

			frmR.cboEmployee.SelectedIndex = -1;
			frmR.cboEmployee.Text = "";
		}
		public void InicializarTablaEmpleadosAgregados()
		{
			if (dtDgvEmpleados != null) return;

			dtDgvEmpleados = new DataTable();
			dtDgvEmpleados.Columns.Add("Empleado");
			dtDgvEmpleados.Columns.Add("id_employee");
			dtDgvEmpleados.Columns.Add("id_workGroup");
		}
		public void MostrarTablaEmpleadosAgregados()
		{
			if (dtDgvEmpleados == null)
				InicializarTablaEmpleadosAgregados();

			frmR.dgvEmployee.AutoGenerateColumns = true;
			frmR.dgvEmployee.DataSource = dtDgvEmpleados;

			if (frmR.dgvEmployee.Columns.Contains("id_employee"))
				frmR.dgvEmployee.Columns["id_employee"].Visible = false;

			if (frmR.dgvEmployee.Columns.Contains("id_workGroup"))
				frmR.dgvEmployee.Columns["id_workGroup"].Visible = false;
		}
		public DataTable ObtenerEmpleadoPorId(string idEmpleado)
		{
			SQLControl sql = new SQLControl();
			DataTable dt = new DataTable();

			try
			{
				sql.OpenConectionWrite();

				string query = @"
        SELECT 
            CAST(id_employee AS VARCHAR(20)) + ' - ' +
            UPPER(v_lastNamePat + ' ' + v_lastNameMat + ' ' + v_name) AS Empleado,
            id_employee,
            id_workGroup
        FROM Nom_Employees
        WHERE CAST(id_employee AS VARCHAR(20)) = @id_employee";

				SqlCommand cmd = new SqlCommand(query, sql.cnn);
				cmd.Parameters.AddWithValue("@id_employee", idEmpleado);

				SqlDataAdapter da = new SqlDataAdapter(cmd);
				da.Fill(dt);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			return dt;
		}
		public string ObtenerIdEmpleadoSeleccionado()
		{
			if (frmR.cboEmployee.SelectedValue != null && frmR.cboEmployee.SelectedIndex >= 0)
				return frmR.cboEmployee.SelectedValue.ToString();

			string texto = frmR.cboEmployee.Text.Trim().ToUpper();

			if (string.IsNullOrWhiteSpace(texto))
				return null;

			if (texto.Contains("-"))
			{
				string[] partes = texto.Split('-');

				foreach (string parte in partes)
				{
					string valor = parte.Trim();

					if (!string.IsNullOrWhiteSpace(valor) && valor.All(char.IsDigit))
						return valor;
				}
			}

			foreach (DataRow row in dtEmpleados.Rows)
			{
				string id = row["id_employee"].ToString().Trim().ToUpper();
				string nombre = row["NombreCompleto"].ToString().Trim().ToUpper();

				if (nombre.Contains(texto) || texto.Contains(nombre) || id == texto)
					return id;
			}

			return null;
		}
		public void CargarEmpleadoEnDgv()
		{
			if (dtDgvEmpleados == null)
				InicializarTablaEmpleadosAgregados();

			MostrarTablaEmpleadosAgregados();

			string idEmpleado = ObtenerIdEmpleadoSeleccionado();

		
			DateTime fechaInicial = ObtenerFechaDesdeSemana(frmR.cboSemanaInicial.Text, true);
			DateTime fechaFinal = ObtenerFechaDesdeSemana(frmR.cboSemanaFinal.Text, false);

			if (string.IsNullOrWhiteSpace(idEmpleado))
			{
				MessageBox.Show("Seleccione un empleado.");
				return;
			}

			var resultado = ValidarEmpleado(idEmpleado, fechaInicial, fechaFinal);

			if (!resultado.tieneCuadrilla && !resultado.tieneAsistencia)
			{
				MessageBox.Show("El empleado no tiene ni cuadrilla ni asistencia.");
				return;
			}

			if (!resultado.tieneCuadrilla)
			{
				MessageBox.Show("El empleado no tiene cuadrilla.");
				return;
			}

			if (!resultado.tieneAsistencia)
			{
				MessageBox.Show("El empleado no tiene asistencia .");
				return;
			}
			

			DataTable dtEmpleado = ObtenerEmpleadoPorId(idEmpleado);

			if (dtEmpleado.Rows.Count == 0)
			{
				MessageBox.Show("No se encontró el empleado.");
				return;
			}

			string empleado = dtEmpleado.Rows[0]["Empleado"].ToString();
			string id = dtEmpleado.Rows[0]["id_employee"].ToString();
			string idWorkGroup = dtEmpleado.Rows[0]["id_workGroup"].ToString();

			//foreach (DataRow row in dtDgvEmpleados.Rows)
			//{
			//	if (row["id_employee"].ToString() == id)
			//	{
			//		MessageBox.Show("El empleado ya fue agregado.");
			//		return;
			//	}
			//}

			dtDgvEmpleados.Rows.Add(empleado, id, idWorkGroup);
		}
		public DateTime ObtenerFechaDesdeSemana(string texto, bool esInicio)
		{
			try
			{
				string[] partes = texto.Split('-');

				if (partes.Length < 2)
					return DateTime.Now;

				string rango = partes[1].Trim();

				string[] fechas = rango.Split('a');

				if (fechas.Length < 2)
					return DateTime.Now;

				DateTime fechaInicio = DateTime.Parse(fechas[0].Trim());
				DateTime fechaFin = DateTime.Parse(fechas[1].Trim());

				return esInicio ? fechaInicio : fechaFin;
			}
			catch
			{
				return DateTime.Now;
			}
		}
		public (bool tieneCuadrilla, bool tieneAsistencia) ValidarEmpleado(string idEmpleado, DateTime inicio, DateTime fin)
		{
			SQLControl sql = new SQLControl();

			bool tieneCuadrilla = false;
			bool tieneAsistencia = false;

			try
			{
				sql.OpenConectionWrite();

				//  VALIDAR CUADRILLA
				string queryCuadrilla = $@"
				SELECT COUNT(*)
				FROM Nom_Employees
				WHERE id_employee = @id_employee
				  AND id_workGroup IS NOT NULL";

				SqlCommand cmd1 = new SqlCommand(queryCuadrilla, sql.cnn);
				cmd1.Parameters.AddWithValue("@id_employee", idEmpleado);

				tieneCuadrilla = Convert.ToInt32(cmd1.ExecuteScalar()) > 0;

				//  VALIDAR ASISTENCIA
				string queryAsistencia = $@"
				SELECT COUNT(*)
				FROM Nom_AttendenceList
				WHERE id_employee = @id_employee
				  AND CAST(d_attendence AS DATE) BETWEEN @inicio AND @fin";

				SqlCommand cmd2 = new SqlCommand(queryAsistencia, sql.cnn);
				cmd2.Parameters.AddWithValue("@id_employee", idEmpleado);
				cmd2.Parameters.AddWithValue("@inicio", inicio);
				cmd2.Parameters.AddWithValue("@fin", fin);

				tieneAsistencia = Convert.ToInt32(cmd2.ExecuteScalar()) > 0;

				sql.CloseConectionWrite();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			return (tieneCuadrilla, tieneAsistencia);
		}
		public void EstiloTabla(DataGridView dgv)
		{
			dgv.BorderStyle = BorderStyle.None;
			dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
			dgv.BackgroundColor = DrawingColor.White;
			dgv.GridColor = DrawingColor.FromArgb(230, 230, 230);

			dgv.EnableHeadersVisualStyles = false;
			dgv.ColumnHeadersDefaultCellStyle.BackColor = DrawingColor.FromArgb(210, 230, 250);
			dgv.ColumnHeadersDefaultCellStyle.ForeColor = DrawingColor.Black;
			dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
			dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dgv.ColumnHeadersHeight = 35;

			dgv.DefaultCellStyle.BackColor = DrawingColor.White;
			dgv.DefaultCellStyle.ForeColor = DrawingColor.Black;
			dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);

			dgv.DefaultCellStyle.SelectionBackColor = DrawingColor.White;
			dgv.DefaultCellStyle.SelectionForeColor = DrawingColor.Black;

			dgv.RowsDefaultCellStyle.SelectionBackColor = DrawingColor.White;
			dgv.RowsDefaultCellStyle.SelectionForeColor = DrawingColor.Black;

			dgv.AlternatingRowsDefaultCellStyle.BackColor = DrawingColor.FromArgb(245, 247, 249);
			dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = DrawingColor.FromArgb(245, 247, 249);
			dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = DrawingColor.Black;

			dgv.RowHeadersVisible = false;
			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToResizeRows = false;
			dgv.MultiSelect = false;
			dgv.SelectionMode = DataGridViewSelectionMode.CellSelect;
			dgv.ReadOnly = true;

			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
		}
		public void ValidarRangoSemanas()
		{
			if (frmR.cboSemanaInicial.SelectedItem == null || frmR.cboSemanaFinal.SelectedItem == null)
				return;

			DataRowView rowInicio = (DataRowView)frmR.cboSemanaInicial.SelectedItem;
			DataRowView rowFin = (DataRowView)frmR.cboSemanaFinal.SelectedItem;

			if (rowInicio[Payroll_AttendancePeriod.ColumnStartDate] == DBNull.Value ||
				rowFin[Payroll_AttendancePeriod.ColumnStartDate] == DBNull.Value)
			{
				return;
			}

			DateTime inicio = Convert.ToDateTime(rowInicio[Payroll_AttendancePeriod.ColumnStartDate]);
			DateTime fin = Convert.ToDateTime(rowFin[Payroll_AttendancePeriod.ColumnStartDate]);

			if (fin < inicio)
			{
				frmR.cboSemanaFinal.SelectedIndex = frmR.cboSemanaInicial.SelectedIndex;
			}
		}
	}
	
}
