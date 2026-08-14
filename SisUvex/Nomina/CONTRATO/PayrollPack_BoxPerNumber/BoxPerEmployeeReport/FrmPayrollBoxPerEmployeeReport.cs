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

        private void btnLoadReport_Click(object sender, EventArgs e)
            => cls?.BtnLoadReport();

        private void btnExcel_Click(object sender, EventArgs e)
            => cls?.BtnGenerateExcelReport();

        private void btnAddEmployee_Click(object sender, EventArgs e)
            => cls?.BtnAddEmployee();

        private void btnSearchEmployee_Click(object sender, EventArgs e)
            => cls?.BtnSearchEmployee();

        private void btnAddList_Click(object sender, EventArgs e)
            => cls?.BtnAddList();

        private void btnClearList_Click(object sender, EventArgs e)
            => cls?.BtnClearList();

        private void chbShowEmployees_CheckedChanged(object sender, EventArgs e)
            => cls?.ChbShowEmployees_CheckedChanged();

        private void chbShowReport_CheckedChanged(object sender, EventArgs e)
            => cls?.ChbShowReport_CheckedChanged();

        private void txbIdEmployee_KeyDown(object sender, KeyEventArgs e)
            => cls?.TxbIdEmployee_KeyDown(e);
    }
}
