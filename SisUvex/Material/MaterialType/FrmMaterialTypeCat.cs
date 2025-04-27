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

namespace SisUvex.Material.MaterialType
{
    internal partial class FrmMaterialTypeCat : Form
    {
        public ClsMaterialType cls;
        public FrmMaterialTypeCat()
        {
            InitializeComponent();
        }

        private void FrmMaterialTypeCat_Load(object sender, EventArgs e)
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
                cls.ModifyRowByIdInDGVCatalog();
        }
    }
}
