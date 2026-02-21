using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.IdentityModel.Tokens;
using SisUvex.Catalogos.Metods.Forms.SelectionForms;
using SisUvex.Nomina.Asistencia_de_empaque;

namespace SisUvex.Nomina.Ingresos_Diversos
{
	public partial class FrmIngresosDiversos : Form
	{

		ClsIngresosDiversos cls;
		public FrmMenu frmMenu;
		public string abrir = "No";
		public string diaValor;
		public string empleadoValor;

		public FrmIngresosDiversos(FrmMenu frmMenu)
		{
			InitializeComponent();
			this.frmMenu = frmMenu;
		}

		private void btnDia_Click(object sender, EventArgs e)
		{
			diaValor = dtpDia.Value.ToString("yyyy-MM-dd");
			cls.AbrirFrmAsistenciaEmpaque("Dia");
			this.Close();
		}

		private void btnEmpleado_Click(object sender, EventArgs e)
		{
			empleadoValor = txbEmpleado.Text;
			cls.AbrirFrmAsistenciaEmpaque("Asistencia");
			this.Close();
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

		private void FrmIngresosDiversos_Load(object sender, EventArgs e)
		{
			cls ??= new();
			cls.frmIngresos ??= this;
			cls.frmMenu ??= frmMenu;
		}
	}
}
