using System;
using System.Windows.Forms;

namespace SisUvex.Archivo.WorkPlan.ChangeDistributorPallet
{
    public partial class FrmChangeDistributorPallet : Form
    {
        ClsChangeDistributorPallet cls = null!;

        public FrmChangeDistributorPallet()
        {
            InitializeComponent();

            btnImprimir.Click    += (s, e) => cls?.BtnImprimir();
            btnLimpiar.Click     += (s, e) => cls?.BtnLimpiar();
            txbIdPallet.KeyDown  += txbIdPallet_KeyDown;
        }

        private void FrmChangeDistributorPallet_Load(object sender, EventArgs e)
        {
            cls ??= new();
            cls.frm = this;
            cls.BeginForm();

            chbAjustarColumnas.Checked = true;
        }

        private void btnAddPallet_Click(object sender, EventArgs e) =>
            cls.BtnAddPallet(txbIdPallet.Text);

        private void btnQuit_Click(object sender, EventArgs e) =>
            cls.BtnQuitPallet();

        private void btnAccept_Click(object sender, EventArgs e) =>
            cls.BtnAccept();

        private void txbIdPallet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                cls.BtnAddPallet(txbIdPallet.Text);
        }

        private void txbIdPallet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
                string clipText = Clipboard.GetText();

                // Si el texto pegado contiene separadores (viene de Excel u otra fuente múltiple)
                bool isMultiple = clipText.IndexOfAny(new[] { '\n', '\r', '\t', ',', ';' }) >= 0;
                if (isMultiple)
                    cls.PasteMultiplePallets(clipText);
                else
                    txbIdPallet.Text = clipText.Trim(); // pegado simple normal
            }
        }

        private void chbAjustarColumnas_CheckedChanged(object sender, EventArgs e)
        {
            dgvPallet.AutoSizeColumnsMode = chbAjustarColumnas.Checked
                ? DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
                : DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }
    }
}
