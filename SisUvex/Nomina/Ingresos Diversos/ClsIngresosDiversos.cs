using System;
using System.Collections.Generic;
using System.Data;
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
using static SisUvex.Catalogos.Metods.ClsObject;


namespace SisUvex.Nomina.Ingresos_Diversos
{
	public class ClsIngresosDiversos 
	{
		ClsIngresosDiversos cls;
		public FrmMenu frmMenu;
		public FrmAsistenciaEmpleado frmAsitencia;
		public FrmIngresosDiversos frmIngresos;
		public FrmListaAsitencia frmDia;
		public FrmAddIngresos frmAdd;
		public FrmDeducciones frmDeu;

		public void AbrirFrmAsistenciaEmpaque(string frmkey)
		{
			switch (frmkey)
			{
				case "Dia":
					frmDia = new();
					frmDia.dtpDia.Value = frmIngresos.dtpDia.Value;
					frmMenu.AbrirVentanaHijo(frmDia, 1);
					break;
				case "Asistencia":
					frmAsitencia = new();
					frmAsitencia.txbIdEmpleado.Text = frmIngresos.txbEmpleado.Text;
					frmMenu.AbrirVentanaHijo(frmAsitencia, 1);
					break;
				default:
					frmIngresos.Close();
					break;
			}
		}

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

			string queryFinal = $"{query} WHERE CONVERT(DATE, lst.d_attendence) = '{fecha}' {queryOrder}";

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


			if (ExisteConceptoEnAsistencia(frmAdd.IdAttendence))
			{
				MessageBox.Show("Este concepto ya fue agregado a esta asistencia");
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
			EXEC sp_Nom_MiscellaneousIncome_Insert
			'{frmAdd.IdAttendence}',
			'{idConcepto}',
			{monto},
			'SYSTEM'";

			ClsQuerysDB.ExecuteQuery(query);
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
	}
}