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

        private void FrmConvertPallet_Load(object sender, EventArgs e)
        {
            cls.BeginForm();
        }

        private void txbIdPallet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                cls.BtnAddPallet();
        }
    }
}
