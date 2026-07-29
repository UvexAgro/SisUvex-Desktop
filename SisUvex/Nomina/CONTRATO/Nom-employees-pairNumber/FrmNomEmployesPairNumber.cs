using System;
using System.Windows.Forms;

namespace SisUvex.Nomina.CONTRATO.Nom_employees_pairNumber
{
    public partial class FrmNomEmployesPairNumber : Form
    {
        private ClsNomEmployesPairNumber? cls;

        public FrmNomEmployesPairNumber()
        {
            InitializeComponent();
        }

        private void FrmNomEmployesPairNumber_Load(object sender, EventArgs e)
        {
            cls = new ClsNomEmployesPairNumber();
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
