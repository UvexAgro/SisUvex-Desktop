using System;
using System.Windows.Forms;

namespace SisUvex.Nomina.CONTRATO.PayrollPack_BoxPerNumber.BoxPerEmployeeReport
{
    public partial class FrmPayrollBoxPerEmployeeDetailReport : Form
    {
        private readonly ClsPayrollBoxPerEmployeeDetailReport cls;

        public FrmPayrollBoxPerEmployeeDetailReport()
        {
            InitializeComponent();
            cls = new ClsPayrollBoxPerEmployeeDetailReport { frm = this };
        }

        private void FrmPayrollBoxPerEmployeeDetailReport_Load(object sender, EventArgs e)
            => cls.BeginFormCat();

        private void btnSearchEmployee_Click(object sender, EventArgs e)
            => cls.BtnSearchEmployee();

        private void btnAddEmployee_Click(object sender, EventArgs e)
            => cls.BtnAddEmployee();

        private void btnAddList_Click(object sender, EventArgs e)
            => cls.BtnAddList();

        private void btnClearList_Click(object sender, EventArgs e)
            => cls.BtnClearList();

        private void btnLoadReport_Click(object sender, EventArgs e)
            => cls.BtnLoadReport();

        private void btnExcel_Click(object sender, EventArgs e)
            => cls.BtnGenerateExcelReport();

        private void chbShowEmployees_CheckedChanged(object sender, EventArgs e)
            => cls.ChbShowEmployees_CheckedChanged();

        private void chbShowReport_CheckedChanged(object sender, EventArgs e)
            => cls.ChbShowReport_CheckedChanged();

        private void txbIdEmployee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                e.SuppressKeyPress = true;
                cls.BtnAddEmployee();
            }
        }

        private void dgvReport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
