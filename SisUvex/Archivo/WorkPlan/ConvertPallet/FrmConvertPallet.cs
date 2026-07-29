using DocumentFormat.OpenXml.Office2010.PowerPoint;
using static SisUvex.Catalogos.Metods.ClsObject;

namespace SisUvex.Archivo.WorkPlan.ConvertPallet
{
    internal partial class FrmConvertPallet : Form
    {
        public ClsConvertPallet cls;
        public FrmConvertPallet()
        {
            InitializeComponent();
        }

        private void btnAddPallet_Click(object sender, EventArgs e)
        {
            cls.BtnAddPallet();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            cls.BtnQuitPallet();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            cls.BtnAccept();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cls.BtnClear();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            cls.BtnImprimirPalletEtiquetaSeleccionado();
        }

        private void FrmConvertPallet_Load(object sender, EventArgs e)
        {
            cls.BeginForm();
        }

        private void txbIdPallet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                cls.BtnAddPallet();
        }

        private void btnDuplicar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txbWorkPlan.Text))
            {
                System.Media.SystemSounds.Beep.Play();
                return;
            }

            lblWorkGroupDuplicate.Visible = true;
            cboWorkGroupDuplicate.Visible = true;

            btnClone.Visible = true;
        }

        private void btnClone_Click(object sender, EventArgs e)
        {
            cls.BtnCloneWorkPlan();
        }
    }
}
