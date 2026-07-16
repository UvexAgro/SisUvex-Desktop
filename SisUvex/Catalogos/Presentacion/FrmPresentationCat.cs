using DocumentFormat.OpenXml.Presentation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Catalogos.Presentacion
{
    internal partial class FrmPresentationCat : Form
    {
        ClsPresentation cls;
        public FrmPresentationCat(ClsPresentation clsClass)
        {
            InitializeComponent();
            cls = clsClass;
        }
        private void FrmPresentationCat_Load(object sender, EventArgs e)
        {
            cls.BeginFormCat();
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
        private void dgvCatalog_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            cls.OpenFrmModify();
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            cls.RemoveProcedure();
        }

        private void btnRecover_Click(object sender, EventArgs e)
        {
            cls.RecoverProcedure();
        }
    }
}
