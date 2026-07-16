using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iText.Kernel.Geom;
using NPOI.OpenXmlFormats.Spreadsheet;
using NPOI.SS.Formula.Functions;
using SisUvex.Catalogos;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Forms.SelectionForms;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Catalogos.WorkGroup;
using static NPOI.HSSF.Util.HSSFColor;
using static SisUvex.Catalogos.Metods.ClsObject;
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

			//  Crear fila "Seleccionar"
			DataRow dr = dt.NewRow();
			dr["Nombre"] = " ------ Seleccionar ------ ";
			dr["Código"] = DBNull.Value;

			dt.Rows.InsertAt(dr, 0); // Insertar al inicio

			frmR.cboCuadrilla.DataSource = dt;
			frmR.cboCuadrilla.DisplayMember = "Nombre";
			frmR.cboCuadrilla.ValueMember = "Código";

			frmR.cboCuadrilla.SelectedIndex = 0;

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
					MessageBox.Show("La cuadrilla seleccionada no tiene asistencia en el periodo indicado.");
					return;
				}

				foreach (DataRow row in dt.Rows)
				{
					frmR.dtEmpleados.ImportRow(row);
				}

				
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
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
			if (bloqueando) return;

			if (frmR.cboSemanaInicial.SelectedItem == null || frmR.cboSemanaFinal.SelectedItem == null)
				return;

			DataRowView rowInicio = (DataRowView)frmR.cboSemanaInicial.SelectedItem;
			DataRowView rowFin = (DataRowView)frmR.cboSemanaFinal.SelectedItem;

			if (rowInicio[Payroll_AttendancePeriod.ColumnStartDate] == DBNull.Value ||
				rowFin[Payroll_AttendancePeriod.ColumnEndDate] == DBNull.Value)
			{
				return;
			}

			DateTime inicio = Convert.ToDateTime(rowInicio[Payroll_AttendancePeriod.ColumnStartDate]);
			DateTime fin = Convert.ToDateTime(rowFin[Payroll_AttendancePeriod.ColumnEndDate]);

			if (fin < inicio)
			{
				bloqueando = true; //  evitar rebote

				frmR.cboSemanaFinal.SelectedIndex = frmR.cboSemanaInicial.SelectedIndex;

				bloqueando = false;
			}
		}
		public void Empleado(string idEmpleado, DateTime? fechaInicio, DateTime? fechaFin)
		{ 
			if (fechaInicio == null || fechaFin == null)
			{
					MessageBox.Show("Fechas no Validas");
					return;
			}

				string query = $@"SELECT top (1)
				e.id_employee AS Codigo,
				e.v_name + ' ' + e.v_lastNamePat + ' ' + e.v_lastNameMat AS Nombre,
				e.id_workGroup,
				a.d_attendence
			FROM dbo.Nom_Employees e
			INNER JOIN dbo.Nom_AttendenceList a 
				ON e.id_employee = a.id_employee
			WHERE
				e.id_employee = @id_Empleado
				AND a.d_attendence BETWEEN @FechaInicio AND @FechaFin
			ORDER BY Codigo; ";

			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "@FechaInicio", fechaInicio },
				{ "@FechaFin", fechaFin },
				{ "@id_Empleado", idEmpleado }
			};

			DataTable dt = ClsQuerysDB.ExecuteParameterizedQuery(query, parameters);

			if (dt.Rows.Count > 0)
			{
				if (dt.Rows[0]["id_workGroup"] == DBNull.Value)
				{
					MessageBox.Show("El empleado no tiene cuadrilla");
					return;
				}
				string name = dt.Rows[0]["Nombre"].ToString();
				string codigo = dt.Rows[0]["Codigo"].ToString();

				frmR.txbCodigo.Text = codigo;
				frmR.txbEmpleado.Text = name;
				frmR.dtEmpleados.Rows.Add(codigo, name);
			}
			else
			{
				MessageBox.Show("El empleado no tiene Asistencia");
				return;
			}		
		}
		public DateTime? GetFechaInicio()
		{

			DataRowView rowInicio = (DataRowView)frmR.cboSemanaInicial.SelectedItem;


			if (rowInicio[Payroll_AttendancePeriod.ColumnStartDate] == DBNull.Value)
			{
				MessageBox.Show("Las semanas seleccionadas no son válidas");
				return null;
			}

			DateTime fechaInicio = Convert.ToDateTime(rowInicio[Payroll_AttendancePeriod.ColumnStartDate]);
			return fechaInicio;
		}
		public DateTime? GetFechaFin()
		{
			DataRowView rowFin = (DataRowView)frmR.cboSemanaFinal.SelectedItem;


			if (rowFin[Payroll_AttendancePeriod.ColumnEndDate] == DBNull.Value)
			{
				MessageBox.Show("Las semanas seleccionadas no son válidas");
				return null;
			}

			DateTime fechaFin = Convert.ToDateTime(rowFin[Payroll_AttendancePeriod.ColumnEndDate]);
			return fechaFin;
		}
	}
}
