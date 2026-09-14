using SisUvex.Nomina.Asistencia_AS;
using System.Windows.Forms;

namespace SisUvex.Nomina.Asistencia_AS.ModifyAttendanceEmployees
{
    public partial class FrmModifyAttendanceEmployees : Form
    {
        internal ClsModifyAttendanceEmployees cls = null!;
        private bool _beginFormQueued;

        public FrmModifyAttendanceEmployees()
        {
            InitializeComponent();
        }

        private void FrmModifyAttendanceEmployees_Load(object sender, EventArgs e)
        {
            DgvAsistenciaASPerf.EnableDoubleBuffer(dgvPivot);
            DgvAsistenciaASPerf.PrepareForFastScroll(dgvPivot);
        }

        private void FrmModifyAttendanceEmployees_Shown(object sender, EventArgs e)
        {
            if (_beginFormQueued) return;
            _beginFormQueued = true;
            // Load corre antes de que la ventana se pinte. Si aquí se arma el pivote (consultas + DGV),
            // el MDI se queda congelado sin mostrar este formulario. Se difiere al primer paint.
            BeginInvoke(new Action(() => cls.BeginForm()));
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
