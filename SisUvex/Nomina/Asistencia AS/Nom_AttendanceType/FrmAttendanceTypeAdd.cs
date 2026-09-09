namespace SisUvex.Nomina.Asistencia_AS.Nom_AttendanceType
{
    internal partial class FrmAttendanceTypeAdd : Form
    {
        public ClsAttendanceType cls = null!;

        public FrmAttendanceTypeAdd()
        {
            InitializeComponent();
        }

        private void FrmAttendanceTypeAdd_Load(object sender, EventArgs e)
        {
            cls ??= new();
            cls._frmAdd ??= this;
            cls.BeginFormAdd();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            cls.BtnAccept();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSelectColor_Click(object sender, EventArgs e)
        {
            cls.BtnSelectColor();
        }

        private void chbStyle_CheckedChanged(object sender, EventArgs e)
        {
            cls.RefreshStylePreview();
        }

        private void txbPrefix_TextChanged(object sender, EventArgs e)
        {
            cls.RefreshStylePreview();
        }
    }
}
