using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SisUvex.Catalogos.Metods.Forms.SelectionForms;
using SisUvex.Nomina.Asistencia_de_empaque;
using SisUvex.Nomina.Conceptos_Ingresos_Diversos;
using Microsoft.IdentityModel.Tokens;


namespace SisUvex.Nomina.Ingresos_Diversos
{
	public partial class FrmListaAsitencia : Form
	{
		public FrmMenu frmMenu;

		ClsIngresosDiversos cls;
		ClsDeducciones clsDeu;


		public string empleadoValor;

		public FrmListaAsitencia(FrmMenu frmMenu)
		{
			InitializeComponent();
			this.frmMenu = frmMenu;

			cls = new ClsIngresosDiversos();
			cls.frmMenu = this.frmMenu;
			cls.frmDia = this;

			clsDeu = new ClsDeducciones();
		}

		private void FrmListaAsitencia_Load(object sender, EventArgs e)
		{
			cls ??= new ClsIngresosDiversos();
			cls.frmDia ??= this;
			cls.ObtenerAsistenciaEmpaqueDia();
		}

		private void btnBuscar_Click(object sender, EventArgs e)
		{
			cls.ObtenerAsistenciaEmpaqueDia();
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			if (dgvLista.CurrentRow == null)
			{
				MessageBox.Show("Seleccione una asistencia");
				return;
			}

			string idAttendence = dgvLista.CurrentRow.Cells["id_attendence"].Value.ToString();

			FrmAddIngresos frm = new FrmAddIngresos(idAttendence);

			if (frm.ShowDialog() == DialogResult.OK)
			{
				cls.ObtenerAsistenciaEmpaqueDia();
			}
		}

		private void btnModify_Click(object sender, EventArgs e)
		{
			if (dgvLista.CurrentRow == null)
			{
				MessageBox.Show("Seleccione un registro");
				return;
			}

			if (dgvLista.CurrentRow.Cells["id_concept"].Value == DBNull.Value)
			{
				MessageBox.Show("Esta asistencia no tiene ingreso para modificar");
				return;
			}

			string idAttendence = dgvLista.CurrentRow.Cells["id_attendence"].Value.ToString();
			string idConcepto = dgvLista.CurrentRow.Cells["id_concept"].Value.ToString();
			decimal monto = Convert.ToDecimal(dgvLista.CurrentRow.Cells["Monto"].Value);

			FrmAddIngresos frm = new FrmAddIngresos(idAttendence, idConcepto, monto);

			if (frm.ShowDialog() == DialogResult.OK)
			{
				cls.ObtenerAsistenciaEmpaqueDia();
			}
		}

		private void btnEliminar_Click(object sender, EventArgs e)
		{
			cls.EliminarIngresoDesdeGrid(dgvLista);
		}

		private void btnAñadirD_Click(object sender, EventArgs e)
		{
			if (dgvLista.CurrentRow == null)
			{
				MessageBox.Show("Seleccione una asistencia");
				return;
			}

			string idAttendence = dgvLista.CurrentRow.Cells["id_attendence"].Value.ToString();

			FrmDeducciones frm = new FrmDeducciones(idAttendence);

			if (frm.ShowDialog() == DialogResult.OK)
			{
				cls.ObtenerAsistenciaEmpaqueDia();
			}
		}

		private void btnModificarDed_Click(object sender, EventArgs e)
		{
			if (dgvLista.CurrentRow == null)
			{
				MessageBox.Show("Seleccione un registro");
				return;
			}

			if (dgvLista.CurrentRow.Cells["id_Deductions"].Value == DBNull.Value)
			{
				MessageBox.Show("Esta asistencia no tiene ingreso para modificar");
				return;
			}

			string idAttendence = dgvLista.CurrentRow.Cells["id_attendence"].Value.ToString();
			string IdDeductions = dgvLista.CurrentRow.Cells["id_Deductions"].Value.ToString();
			decimal montoD = dgvLista.CurrentRow.Cells["Descuento"].Value == DBNull.Value
			? 0
			: Convert.ToDecimal(dgvLista.CurrentRow.Cells["Descuento"].Value);

			FrmDeducciones frm = new FrmDeducciones(idAttendence, IdDeductions, montoD);

			if (frm.ShowDialog() == DialogResult.OK)
			{
				cls.ObtenerAsistenciaEmpaqueDia();
			}
		}

		private void EliminarD_Click(object sender, EventArgs e)
		{
			clsDeu.EliminarDeduccionDesdeGrid(dgvLista, cls);
		}

		private void btnEmpleado_Click(object sender, EventArgs e)
		{
			empleadoValor = txbEmpleado.Text;
			cls.ObtenerAsistenciaEmpaquePorEmpleadoYFecha();
			//this.Close();
		}

		private void btnFrmSearchEmployeeId_Click(object sender, EventArgs e)
		{
			ClsSelectionForm sel = new ClsSelectionForm();

			sel.OpenSelectionForm("EmployeeBasic", "Código");

			if (!sel.SelectedValue.IsNullOrEmpty())
				txbEmpleado.Text = sel.SelectedValue;

			txbEmpleado.Focus();

			txbEmpleado.SelectAll();
		}
	}

}
