using System.Windows.Forms;

namespace SisUvex.Nomina.Asistencia_AS.ModifyAttendanceEmployees
{
    public partial class FrmModifyAttendanceEmployees : Form
    {
        internal ClsModifyAttendanceEmployees cls = null!;

        public FrmModifyAttendanceEmployees()
        {
            InitializeComponent();
        }

        private void FrmModifyAttendanceEmployees_Load(object sender, EventArgs e)
        {
            cls.BeginForm();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            cls.BtnApplyToSelection();
        }

        private void cboDefaultType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cls.CboDefaultType_SelectedIndexChanged();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            cls.BtnSave();
        }

        private void btnDiscard_Click(object sender, EventArgs e)
        {
            cls.BtnDiscard();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvPivot_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            cls.DgvPivot_CellFormatting(sender, e);
        }

        private void dgvPivot_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            cls.DgvPivot_CellPainting(sender, e);
        }

        private void dgvPivot_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            cls.DgvPivot_CellToolTipTextNeeded(sender, e);
        }

        private void dgvPivot_SelectionChanged(object sender, EventArgs e)
        {
            cls.DgvPivot_SelectionChanged();
        }

        private void FrmModifyAttendanceEmployees_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!cls.ConfirmCloseIfPending())
                e.Cancel = true;
        }
    }
}
