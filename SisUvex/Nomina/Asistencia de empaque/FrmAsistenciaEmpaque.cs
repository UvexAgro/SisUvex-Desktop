using Microsoft.IdentityModel.Tokens;
using SisUvex.Catalogos.Metods.Forms.SelectionForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Nomina.Asistencia_de_empaque
{
    public partial class FrmAsistenciaEmpaque : Form
    {
        ClsAsistenciaEmpaque cls;
        public FrmMenu frmMenu;
        public string abrir = "No";
        public string diaValor;
        public string empleadoValor;

        public FrmAsistenciaEmpaque()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            abrir = "Nuevo";
            this.Close();
        }

        private void btnDia_Click(object sender, EventArgs e)
        {
            abrir = "Día";
            diaValor = dtpDia.Value.ToString("yyyy-MM-dd");
            this.Close();
        }

        private void btnEmpleado_Click(object sender, EventArgs e)
        {
            abrir = "Empleado";
            empleadoValor = txbEmpleado.Text;
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
    }
}
