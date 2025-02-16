using Microsoft.IdentityModel.Tokens;
using SisUvex.Catalogos.Metods.Forms.SelectionForms;

namespace SisUvex.Catalogos.WorkGroup
{
    internal partial class FrmWorkGroupAdd : Form
    {
        public ClsWorkGroup cls;
        public bool IsAddModify = true, AddIsUpdate = false;
        public string? idModify;

        public FrmWorkGroupAdd()
        {
            InitializeComponent();

            cls ??= new ClsWorkGroup();
            cls._frmAdd ??= this;
        }

        private void FrmWorkGroupAdd_Load(object sender, EventArgs e)
        {
            cls.BeginFormAdd();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            cls.btnAcceptAddModify();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearchContractor_Click(object sender, EventArgs e)
        {
            cls.btnSearchContractor();
        }
    }
}
