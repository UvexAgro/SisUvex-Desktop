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

        private void txbIdEmployee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                e.SuppressKeyPress = true;
                cls.BtnAddEmployee();
                return;
            }

            if ((e.Control && e.KeyCode == Keys.V) || (e.Shift && e.KeyCode == Keys.Insert))
            {
                e.SuppressKeyPress = true;
                cls.PasteEmployeeCodesAsPlainText();
            }
        }

        // ── Eventos del TabControl ────────────────────────────────────────────

        private void tabReport_SelectedIndexChanged(object sender, EventArgs e)
            => cls.TabReport_SelectedIndexChanged();

        // ── Eventos CellFormatting por DGV ────────────────────────────────────

        private void dgvListado_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) { }

        private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void dgvDetalle_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
            => cls.DgvDetalle_CellFormatting(sender, e);

        private void dgvDetalle_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
            => cls.DgvDetalle_RowPostPaint(sender, e);

        private void dgvResumen_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
            => cls.DgvResumen_CellFormatting(sender, e);

        private void dgvCajasEmpleado_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
            => cls.DgvCajasEmpleado_CellFormatting(sender, e);
    }
}
