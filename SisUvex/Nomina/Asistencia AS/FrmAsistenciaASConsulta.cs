using SisUvex.Archivo.MixtearPallets;
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
        {
            cls.BeginFormCat();
        }

        private void btnSearchEmployee_Click(object sender, EventArgs e)
        {
            cls.BtnSearchEmployee();
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            cls.BtnAddEmployee();
        }

        private void btnAddList_Click(object sender, EventArgs e)
        {
            cls.BtnAddList();
        }

        private void btnClearList_Click(object sender, EventArgs e)
        {
            cls.BtnClearList();
        }

        private void chbShowEmployees_CheckedChanged(object sender, EventArgs e)
        {
            cls.ChbShowEmployees_CheckedChanged();
        }

        private void chbShowReport_CheckedChanged(object sender, EventArgs e)
        {
            cls.ChbShowReport_CheckedChanged();
        }

        private void chbShowReportCalendar_CheckedChanged(object sender, EventArgs e)
        {
            cls.ChbShowReportCalendar_CheckedChanged();
        }

        private void btnLoadReport_Click(object sender, EventArgs e)
        {
            cls.BtnLoadReport();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            cls.BtnGenerateExcelReport();
        }

        private void btnModifyAttendance_Click(object sender, EventArgs e)
        {
            cls.BtnModifyAttendance();
        }

        private void dgvReport_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            cls.DgvReport_CellFormatting(sender, e);
        }

        private void dgvReport_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            cls.DgvReport_CellToolTipTextNeeded(sender, e);
        }

        private void dgvReport_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            cls.DgvReport_CellPainting(sender, e);
        }

        private void dgvReport_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cls.DgvReport_ColumnHeaderMouseClick(sender, e);
        }

        private void dgvReport_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            cls.DgvReport_CurrentCellDirtyStateChanged(sender, e);
        }

        private void dgvReport_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            cls.DgvReport_CellValueChanged(sender, e);
        }

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

        private void btnOpenFrmAttendanceType_Click(object sender, EventArgs e)
        {
            if (!User.HasViewCatalogsPermission())
                return;

            Nom_AttendanceType.FrmAttendanceTypeCat frm = new();
            FrmMenu.FrmMenuInstance.AbrirVentanaHijo(frm);
        }

        private void cmsIdEmployee_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            tsmiUndo.Enabled = txbIdEmployee.CanUndo;
            tsmiCut.Enabled = txbIdEmployee.SelectionLength > 0;
            tsmiCopy.Enabled = txbIdEmployee.SelectionLength > 0;
            tsmiPaste.Enabled = Clipboard.ContainsText();
            tsmiDelete.Enabled = txbIdEmployee.SelectionLength > 0;
            tsmiSelectAll.Enabled = txbIdEmployee.TextLength > 0;
        }

        private void tsmiUndo_Click(object sender, EventArgs e)
        {
            txbIdEmployee.Undo();
        }

        private void tsmiCut_Click(object sender, EventArgs e)
        {
            txbIdEmployee.Cut();
        }

        private void tsmiCopy_Click(object sender, EventArgs e)
        {
            txbIdEmployee.Copy();
        }

        private void tsmiPaste_Click(object sender, EventArgs e)
        {
            cls.PasteEmployeeCodesAsPlainText();
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            txbIdEmployee.SelectedText = string.Empty;
        }

        private void tsmiSelectAll_Click(object sender, EventArgs e)
        {
            txbIdEmployee.SelectAll();
        }

        /// <summary>
        /// Bloquea filtros, botones y cambios de vista mientras hay una carga en curso,
        /// para que Application.DoEvents de la barra de progreso no reentre en esas acciones.
        /// </summary>
        internal void SetOperationBusy(bool busy)
        {
            bool enabled = !busy;
            gpbFilters.Enabled = enabled;
            bgpInfo.Enabled = enabled;
            btnClearList.Enabled = enabled;
            chbShowEmployees.Enabled = enabled;
            chbShowReport.Enabled = enabled;
            chbShowReportCalendar.Enabled = enabled;
            btnExcel.Enabled = enabled;
            btnModifyAttendance.Enabled = enabled;
            btnOpenFrmAttendanceType.Enabled = enabled;
        }

        /// <summary>
        /// Cursor de espera. Hay que restaurar también <see cref="Cursor.Current"/> y el del MDI:
        /// si no, tras Application.DoEvents el reloj se queda pegado aunque el formulario ya haya terminado.
        /// </summary>
        internal void SetWaitCursor(bool wait)
        {
            UseWaitCursor = wait;
            Cursor = wait ? Cursors.WaitCursor : Cursors.Default;
            Application.UseWaitCursor = wait;
            Cursor.Current = wait ? Cursors.WaitCursor : Cursors.Default;

            dgvReport.UseWaitCursor = wait;
            if (!wait)
                dgvReport.Cursor = Cursors.Default;

            if (MdiParent != null)
            {
                MdiParent.UseWaitCursor = wait;
                if (!wait)
                    MdiParent.Cursor = Cursors.Default;
            }
        }
    }
}
