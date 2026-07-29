using System;
using System.Windows.Forms;

namespace SisUvex.Nomina.CONTRATO.PayrollPack_BoxPerNumber.BoxPerEmployeeReport
{
    public partial class FrmPayrollBoxPerEmployeeReport : Form
    {
        private ClsPayrollBoxPerEmployeeReport? cls;

        public FrmPayrollBoxPerEmployeeReport()
        {
            InitializeComponent();
        }

        private void FrmPayrollBoxPerEmployeeReport_Load(object sender, EventArgs e)
        {
            cls = new ClsPayrollBoxPerEmployeeReport();
            cls.frm = this;
            cls.BeginFormCat();
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

