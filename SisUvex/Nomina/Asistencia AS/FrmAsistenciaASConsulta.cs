using System;
using System.Windows.Forms;

namespace SisUvex.Nomina.Asistencia_AS
{
    public partial class FrmAsistenciaASConsulta : Form
    {
        private readonly ClsAsistenciaASConsulta cls;

        public FrmAsistenciaASConsulta()
        {
            InitializeComponent();
            cls = new ClsAsistenciaASConsulta { frm = this };
        }

        private void FrmAsistenciaASConsulta_Load(object sender, EventArgs e)
            => cls.BeginFormCat();

        private void btnSearchEmployee_Click(object sender, EventArgs e)
            => cls.BtnSearchEmployee();

        private void btnAddEmployee_Click(object sender, EventArgs e)
            => cls.BtnAddEmployee();

        private void btnAddList_Click(object sender, EventArgs e)
            => cls.BtnAddList();

        private void btnClearList_Click(object sender, EventArgs e)
            => cls.BtnClearList();

        private void chbShowEmployees_CheckedChanged(object sender, EventArgs e)
            => cls.ChbShowEmployees_CheckedChanged();

        private void chbShowReport_CheckedChanged(object sender, EventArgs e)
            => cls.ChbShowReport_CheckedChanged();

        private void btnLoadReport_Click(object sender, EventArgs e)
            => cls.BtnLoadReport();

        private void btnExcel_Click(object sender, EventArgs e)
            => cls.BtnGenerateExcelReport();

        private void dgvReport_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
            => cls.DgvReport_CellFormatting(sender, e);

        private void txbIdEmployee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                e.SuppressKeyPress = true;
                cls.BtnAddEmployee();
                return;
            }

            // Ctrl+V / Shift+Insert: forzar pegado como texto plano (sin formato de Excel).
            if ((e.Control && e.KeyCode == Keys.V) || (e.Shift && e.KeyCode == Keys.Insert))
            {
                e.SuppressKeyPress = true;
                cls.PasteEmployeeCodesAsPlainText();
            }
        }
    }
}
