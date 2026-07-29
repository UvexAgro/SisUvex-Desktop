using System.Media;
using SisUvex.Catalogos.Metods;

namespace SisUvex.Archivo.WorkPlan
{
    internal partial class FrmWorkPlanCat : Form
    {
        public ClsWorkPlan cls = null!;

        public FrmWorkPlanCat()
        {
            InitializeComponent();
        }

        private void FrmWorkPlanCat_Load(object sender, EventArgs e)
        {
            cls ??= new();
            cls._frmCat ??= this;
            cls.BeginFormCat();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cls.OpenFrmAdd();

            if (cls.IsAddUpdate)
                cls.AddNewRowByIdInDGVCatalog();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            OpenFrmModifyFromCat();
        }

        private void OpenFrmModifyFromCat()
        {
            if (dgvCatalog.SelectedRows.Count == 0)
            {
                SystemSounds.Exclamation.Play();
                return;
            }

            string idModify = dgvCatalog.SelectedRows[0].Cells[ClsObject.Column.id].Value.ToString()!;

            cls.OpenFrmModify(idModify);

            if (cls.IsModifyUpdate)
                cls.ModifyRowByIdInDGVCatalog();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            cls.RemoveProcedure();
        }

        private void btnRecover_Click(object sender, EventArgs e)
        {
            cls.RecoverProcedure();
        }

        private void dgvCatalog_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenFrmModifyFromCat();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            cls.BtnSearch();
        }

        public void chbRemoved_CheckedChanged(object sender, EventArgs e)
        {
            cls.ChbRemovedChecked();
        }

        private void btnClone_Click(object sender, EventArgs e)
        {
            if (dgvCatalog.SelectedRows.Count == 0)
            {
                SystemSounds.Exclamation.Play();
                return;
            }

            string idClone = dgvCatalog.SelectedRows[0].Cells[ClsObject.Column.id].Value.ToString()!;

            cls.OpenFrmClone(idClone);

            if (cls.IsAddUpdate)
                cls.AddNewRowByIdInDGVCatalog();
        }
    }
}
