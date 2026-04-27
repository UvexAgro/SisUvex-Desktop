using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Facility.FaciIityPackagingTracking.Catalog
{
    internal partial class FrmFaciIityPackagingTrackingCat : Form
    {
        public ClsFaciIityPackagingTracking cls = null!;
        public FrmFaciIityPackagingTrackingCat()
        {
            InitializeComponent();
        }

        private void FrmFaciIityPackagingTrackingCat_Load(object sender, EventArgs e)
        {
            cls ??= new();
            cls._frmCat ??= this;
            cls.BeginFormCat();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cls.OpenFrmAdd();
            if (cls.IsAddUpdate)
                cls.BeginFormCat();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            Modify();
        }

        private void dgvCatalog_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Modify();
        }

        private void chbRemoved_CheckedChanged(object sender, EventArgs e)
        {
            cls.ChbRemovedFilter();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            cls.BtnRemove();
        }

        private void btnRecover_Click(object sender, EventArgs e)
        {
            cls.BtnRecover();
        }

        private void Modify()
        {
            string? id = dgvCatalog?.CurrentRow?.Cells[SisUvex.Catalogos.Metods.ClsObject.Column.id]?.Value?.ToString();
            cls.OpenFrmModify(id);
            if (cls.IsModifyUpdate)
                cls.BeginFormCat();
        }
    }
}
