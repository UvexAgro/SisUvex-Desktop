using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SisUvex.Catalogos.Metods;

namespace SisUvex.Material.MaterialCatalog
{
    internal partial class FrmMaterialCatalog : Form
    {
        public ClsMaterialCatalog cls;
        public FrmMaterialCatalog()
        {
            InitializeComponent();
        }

        private void FrmMaterialCatalog_Load(object sender, EventArgs e)
        {
            cls ??= new ClsMaterialCatalog();
            cls._frmCat = this;

            cls.BeginFormCat();
        }

        private void chbRemoved_CheckedChanged(object sender, EventArgs e)
        {
            cls.ChbRemovedProcedure();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvCatalog.SelectedRows.Count != 0)
            {
                cls.BtnActiveProcedure(dgvCatalog.Rows[dgvCatalog.SelectedRows[0].Index].Cells[ClsObject.Column.id].Value.ToString(), "0");
            }
            else
                SystemSounds.Exclamation.Play();
        }

        private void btnRecover_Click(object sender, EventArgs e)
        {
            if (dgvCatalog.SelectedRows.Count != 0)
            {
                cls.BtnActiveProcedure(dgvCatalog.Rows[dgvCatalog.SelectedRows[0].Index].Cells[ClsObject.Column.id].Value.ToString(), "1");
            }
            else
                SystemSounds.Exclamation.Play();
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

        private void dgvCatalog_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
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

            cls.OpenFrmModify(dgvCatalog.Rows[dgvCatalog.SelectedRows[0].Index].Cells[ClsObject.Column.id].Value.ToString());

            if (cls.IsModifyUpdate)
            {
                cls.ModifyRowByIdInDGVCatalog();
            }
        }

        private void btnFilterMaterialCatalog_Click(object sender, EventArgs e)
        {
            cls.BtnFilterDtCatalog();
        }
    }
}
