using SisUvex.Catalogos.Metods.ComboBoxes;
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
    internal partial class FrmPresentationAdd : Form
    {
        private ClsPresentation cls;
        private FrmPresentationCat frmCat;
        public bool IsAddModify = true, AddIsUpdate = false;
        public string? idModify;

        public FrmPresentationAdd(FrmPresentationCat frmCatalog, ClsPresentation clsPresentacion)
        {
            InitializeComponent();

            cls = clsPresentacion;
            frmCat = frmCatalog;
        }

        private void FrmPresentationAdd_Load(object sender, EventArgs e)
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
