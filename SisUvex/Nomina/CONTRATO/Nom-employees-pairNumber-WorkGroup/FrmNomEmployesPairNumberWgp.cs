using System;
using System.Windows.Forms;

namespace SisUvex.Nomina.CONTRATO.Nom_employees_pairNumber_WorkGroup
{
    public partial class FrmNomEmployesPairNumberWgp : Form
    {
        private ClsNomEmployesPairNumberWgp? cls;

        public FrmNomEmployesPairNumberWgp()
        {
            InitializeComponent();
        }

        private void FrmNomEmployesPairNumberWgp_Load(object sender, EventArgs e)
        {
            cls = new ClsNomEmployesPairNumberWgp();
            cls.frm = this;
            cls.BeginForm();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            cls?.BtnLoadReport();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            cls?.BtnGenerateExcelReport();
        }
    }
}
