using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using SisUvex.Catalogos.GTIN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Catalogos.GTIN_UPC
{
    internal partial class FrmGtinCat : Form
    {
        ClsGTIN cls;
        public FrmGtinCat(ClsGTIN clsClass)
        {
            InitializeComponent();
            cls = clsClass;
        }

        private void FrmGtinCat_Load(object sender, EventArgs e)
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

        private void chbRemoved_CheckedChanged(object sender, EventArgs e)
        {
            cls.ChbRemovedChecked();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            cls.BtnSearch();
        }
    }
}
