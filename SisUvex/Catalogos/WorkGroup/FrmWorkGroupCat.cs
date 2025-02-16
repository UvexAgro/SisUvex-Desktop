namespace SisUvex.Catalogos.WorkGroup
{
    public partial class FrmWorkGroupCat : Form
    {
        ClsWorkGroup cls;

        public FrmWorkGroupCat()
        {
            InitializeComponent();

            cls ??= new ClsWorkGroup();
            cls._frmCat ??= this;
        }

        private void FrmWorkGroupCat_Load(object sender, EventArgs e)
        {
            cls.BeginFormCat();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            cls.RemoveProcedure();
        }

        private void btnRecover_Click(object sender, EventArgs e)
        {
            cls.RecoverProcedure();
        }

        private void btnRemoved_Click(object sender, EventArgs e)
        {
            cls.dgv.UpdateCatalogButtonActivesDeletes();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cls.OpenFrmAdd();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            cls.OpenFrmModify();
        }
    }
}
