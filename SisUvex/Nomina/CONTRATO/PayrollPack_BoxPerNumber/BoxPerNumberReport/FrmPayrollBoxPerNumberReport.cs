using System;
using System.Windows.Forms;

namespace SisUvex.Nomina.CONTRATO.PayrollPack_BoxPerNumber.BoxPerNumberReport
{
    public partial class FrmPayrollBoxPerNumberReport : Form
    {
        private ClsPayrollBoxPerNumberReport cls;

        public FrmPayrollBoxPerNumberReport()
        {
            InitializeComponent();
        }

        private void FrmPayrollBoxPerNumberReport_Load(object sender, EventArgs e)
        {
            cls = new ClsPayrollBoxPerNumberReport();
            cls.frm = this;
            cls.BeginFormCat();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            cls.BtnLoadReport();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            cls.BtnGenerateExcelReport();
        }

        private void cboPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            cls.CboPeriodChanged();
        }
    }
}
