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
    internal partial class FrmGtinAdd : Form
    {
        ClsGTIN cls;
        FrmGtinCat frmCat;
        public bool IsAddModify = true, AddIsUpdate = false;
        public string? idModify;
        public FrmGtinAdd(FrmGtinCat frmCatalog, ClsGTIN clsClass)
        {
            InitializeComponent();
            cls = clsClass;
            frmCat = frmCatalog;
        }

        private void FrmGtinAdd_Load(object sender, EventArgs e)
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
    }
}
