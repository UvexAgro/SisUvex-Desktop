using SisUvex.Catalogos.Metods;
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

namespace SisUvex.Configuracion.Parameters
{
    internal partial class FrmParametersCat : Form
    {
        public ClsParameters cls;
        public FrmParametersCat()
        {
            InitializeComponent();
        }

        private void FrmParametersCat_Load(object sender, EventArgs e)
        {
            cls ??= new();
            cls._frmCat ??= this;

            cls.BeginFormCat();
        }

        private void btnTypeFilter_Click(object sender, EventArgs e)
        {
            cls.SetFilterDGVCatalog();
        }

        private void dgvCatalog_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void chbRemoved_CheckedChanged(object sender, EventArgs e)
        {
            cls.ChbRemovedFilter();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            cls.BtnActiveProcedure("0");
        }

        private void btnRecover_Click(object sender, EventArgs e)
        {
            cls.BtnActiveProcedure("1");
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

            string id = dgvCatalog.Rows[dgvCatalog.SelectedRows[0].Index].Cells[ClsObject.Column.id].Value.ToString();
            string id2 = dgvCatalog.Rows[dgvCatalog.SelectedRows[0].Index].Cells[ClsParameters.queryColumnIdTypeParameter].Value.ToString();

            cls.OpenFrmModify(id, id2);

            if (cls.IsModifyUpdate)
                cls.ModifyRowByIdInDGVCatalog();
        }
    }
}
