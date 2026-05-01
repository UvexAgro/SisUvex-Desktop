using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Presentation;
using SisUvex.Catalogos;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.DataGridViews;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Nomina.Asistencia_de_empaque;
using SisUvex.Nomina.Conceptos_Ingresos_Diversos;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static SisUvex.Catalogos.Metods.ClsObject;


namespace SisUvex.Nomina.Ingresos_Diversos
{
	public class ClsIngresosDiversos 
	{
		ClsIngresosDiversos cls;
		public FrmMenu frmMenu;
		public FrmListaAsitencia frmDia;
		public FrmAddIngresos frmAdd;
		public FrmDeducciones frmDeu;
		public List<string> IdsAttendence { get; set; }
		string query = @"SELECT  
						lst.id_attendence,      
						CONVERT(DATE, lst.d_attendence) AS Fecha,
						lst.id_employee AS Empleado,
						emp.v_lastNamePat AS 'Apellido paterno',
						emp.v_lastNameMat AS 'Apellido materno',
						emp.v_name AS Nombre,
						lst.c_codigo_tab AS Actividad,
						tab.v_descripcion_tab AS 'Descripción actividad',
						con.id_concept AS id_concept,
						con.v_concept AS Concepto,
						con.n_unit AS Horas,
						mi.n_amount AS Monto,
						mi.id_Deductions,
						ded.v_descripcion_ded AS 'Descripción Deducción',
						mi.n_importefijo_ded AS 'Descuento'
						FROM Nom_AttendenceList lst
						JOIN Nom_Employees emp 
						ON emp.id_employee = lst.id_employee
						JOIN Nom_Tabulador tab 
						ON tab.c_codigo_tab = lst.c_codigo_tab
						LEFT JOIN Nom_MiscellaneousIncome mi 
						ON mi.id_attendence = lst.id_attendence
						LEFT JOIN Nom_concept con 
						ON con.id_concept = mi.id_concept
						LEFT JOIN Nom_Deductions ded 
						ON ded.id_Deductions = mi.id_Deductions ";
		string queryOrder = "ORDER BY emp.v_lastNamePat, emp.v_lastNameMat, emp.v_name ";

		public void ObtenerAsistenciaEmpaqueDia()
		{
			string fecha = frmDia.dtpDia.Value.ToString("yyyy-MM-dd");

			// 🔹 OBTENER ACTIVIDAD DEL COMBO
			string actividad = "";

			if (frmDia.cboActividad.SelectedValue != null
				&& frmDia.cboActividad.SelectedValue is string)
			{
				actividad = frmDia.cboActividad.SelectedValue.ToString();
			}

			// 🔹 CREAR FILTRO
			string filtroActividad = "";

			if (!string.IsNullOrEmpty(actividad))
			{
				filtroActividad = $" AND lst.c_codigo_tab = '{actividad}'";
			}

			// 🔹 QUERY FINAL
			string queryFinal = $@" {query} WHERE CONVERT(DATE, lst.d_attendence) = '{fecha}'{filtroActividad} {queryOrder}";

			frmDia.dgvLista.DataSource = ClsQuerysDB.GetDataTable(queryFinal);

			if (frmDia.dgvLista.Columns.Contains("id_attendence"))
				frmDia.dgvLista.Columns["id_attendence"].Visible = false;

			if (frmDia.dgvLista.Columns.Contains("id_concept"))
				frmDia.dgvLista.Columns["id_concept"].Visible = false;

			if (frmDia.dgvLista.Columns.Contains("id_Deductions"))
				frmDia.dgvLista.Columns["id_Deductions"].Visible = false;

			if (!frmDia.dgvLista.Columns.Contains("Seleccionar"))
			{
				DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
				chk.Name = "Seleccionar";
				chk.HeaderText = "✔";
				chk.Width = 40;

				frmDia.dgvLista.Columns.Insert(0, chk);
			}
		}
		public void ObtenerAsistenciaEmpaquePorEmpleadoYFecha()
		{
			string fecha = frmDia.dtpDia.Value.ToString("yyyy-MM-dd");
			string idEmpleado = frmDia.txbEmpleado.Text.Trim();

			if (string.IsNullOrEmpty(idEmpleado))
			{
				MessageBox.Show("Ingrese un empleado");
				return;
			}

			string queryFinal = $"{query} WHERE CONVERT(DATE, lst.d_attendence) = '{fecha}'AND lst.id_employee = '{idEmpleado}'{ queryOrder}";

			frmDia.dgvLista.DataSource = ClsQuerysDB.GetDataTable(queryFinal);

			if (frmDia.dgvLista.Columns.Contains("id_attendence"))
				frmDia.dgvLista.Columns["id_attendence"].Visible = false;

			if (frmDia.dgvLista.Columns.Contains("id_concept"))
				frmDia.dgvLista.Columns["id_concept"].Visible = false;

			if (frmDia.dgvLista.Columns.Contains("id_Deductions"))
				frmDia.dgvLista.Columns["id_Deductions"].Visible = false;
		}

		public void CboConceptos()
		{
			DataTable dtcbo = ClsQuerysDB.GetDataTable($"SELECT id_concept AS [" + Column.id + "], " +
														"v_concept AS [" + Column.name + "], " +
														"ISNULL(n_amount, 0) AS Monto, " +
														"ISNULL(n_unit, 0) AS HorasExtras " +
														"FROM Nom_concept");
			ClsComboBoxes.LoadComboBoxDataSource(frmAdd.cboConceptos, dtcbo);
		}
		public void InsertarIngreso()
		{
			object val = frmAdd.cboConceptos.SelectedValue;

			if (val == null || val is DataRowView)
			{
				MessageBox.Show("Seleccione un concepto válido");
				return;
			}

			string idConcepto = val.ToString();

			decimal monto;

			if (!string.IsNullOrWhiteSpace(frmAdd.txbMmodificar.Text))
			{
				if (!decimal.TryParse(frmAdd.txbMmodificar.Text, out monto))
				{
					MessageBox.Show("Monto modificado inválido");
					return;
				}
			}
			else
			{
				if (!decimal.TryParse(frmAdd.txbMonto.Text, out monto))
				{
					MessageBox.Show("El concepto no tiene monto válido");
					return;
				}
			}

		
			var lista = frmAdd.IdsAttendence ?? new List<string> { frmAdd.IdAttendence };

			int insertados = 0;
			int omitidos = 0;

			foreach (var idAttendence in lista)
			{
				if (string.IsNullOrEmpty(idAttendence))
					continue;

				if (ExisteConceptoEnAsistencia(idAttendence))
				{
					omitidos++;
					continue;
				}

				string query = $@"
				EXEC sp_Nom_MiscellaneousIncome_Insert
				'{idAttendence}',
				'{idConcepto}',
				{monto},
				'SYSTEM'";

				ClsQuerysDB.ExecuteQuery(query);
				insertados++;
			}

			MessageBox.Show($"Insertados: {insertados}\nOmitidos (ya existían): {omitidos}");
		}

		public void ActualizarIngreso()
		{

			string idConceptoNuevo = frmAdd.cboConceptos.SelectedValue?.ToString();

			if (string.IsNullOrWhiteSpace(idConceptoNuevo))
			{
				MessageBox.Show("Debe seleccionar un concepto válido");
				return;
			}


			DataTable dt = ClsQuerysDB.GetDataTable(
				$"SELECT 1 FROM Nom_Concept WHERE id_concept = '{idConceptoNuevo}'");

			if (dt.Rows.Count == 0)
			{
				MessageBox.Show("Seleccione un concepto válido");
				return;
			}


			decimal monto;

			if (!string.IsNullOrWhiteSpace(frmAdd.txbMmodificar.Text))
			{
				if (!decimal.TryParse(frmAdd.txbMmodificar.Text, out monto))
				{
					MessageBox.Show("Monto modificado inválido");
					return;
				}
			}
			else
			{
				if (!decimal.TryParse(frmAdd.txbMonto.Text, out monto))
				{
					MessageBox.Show("El concepto no tiene monto válido");
					return;
				}
			}


			string query = $@"
			EXEC sp_Nom_MiscellaneousIncome_Update
			'{frmAdd.IdAttendence}',
			'{frmAdd.IdConcepto}',
			'{idConceptoNuevo}',
			{monto},
			'SYSTEM'";

			ClsQuerysDB.ExecuteQuery(query);
		}
		public void EliminarIngreso(string idAttendence, string idConcepto)
		{
			string query = $@"
			EXEC sp_Nom_MiscellaneousIncome_Delete
			'{idAttendence}',
			'{idConcepto}'";

			ClsQuerysDB.ExecuteQuery(query);
		}
		public void EliminarIngresoDesdeGrid(DataGridView dgv)
		{
			if (dgv.CurrentRow == null)
			{
				MessageBox.Show("Seleccione un registro");
				return;
			}

			if (dgv.CurrentRow.Cells["id_concept"].Value == DBNull.Value)
			{
				MessageBox.Show("Esta asistencia no tiene ingreso para eliminar");
				return;
			}

			string idAttendence = dgv.CurrentRow.Cells["id_attendence"].Value.ToString();
			string idConcepto = dgv.CurrentRow.Cells["id_concept"].Value.ToString();

			if (MessageBox.Show("¿Desea eliminar el ingreso seleccionado?",
				"Confirmar",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question) == DialogResult.No)
				return;

			string query = $@"
			EXEC sp_Nom_MiscellaneousIncome_Delete
			'{idAttendence}',
			'{idConcepto}'";

			ClsQuerysDB.ExecuteQuery(query);

			ObtenerAsistenciaEmpaqueDia();
		}
		private bool ExisteConceptoEnAsistencia(string idAttendence)
		{
			string query = $@"
			SELECT COUNT(*) 
			FROM Nom_MiscellaneousIncome
			WHERE id_attendence = '{idAttendence}' and id_concept is not null ";

			object result = ClsQuerysDB.GetData(query);

			return Convert.ToInt32(result) > 0;
		}
		public void CargarComboActividades()
		{
			DataTable dtActividades = ObtenerActividades();

			dtActividades.Columns.Add("ActividadCompleta");

			foreach (DataRow row in dtActividades.Rows)
			{
				row["ActividadCompleta"] = row["c_codigo_tab"] + " - " + row["v_descripcion_tab"];
			}

			frmDia.cboActividad.DataSource = dtActividades;
			frmDia.cboActividad.DisplayMember = "ActividadCompleta";
			frmDia.cboActividad.ValueMember = "c_codigo_tab";

			frmDia.cboActividad.DropDownStyle = ComboBoxStyle.DropDown;
			frmDia.cboActividad.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			frmDia.cboActividad.AutoCompleteSource = AutoCompleteSource.ListItems;

			frmDia.cboActividad.SelectedIndex = -1;
			frmDia.cboActividad.Text = "";
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
	}
}