using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Catalogos.Container
{
    internal partial class FrmContainerAdd : Form
    {
        private ClsContainer cls;
        private FrmContainerCat frmCat;
        public bool IsAddModify, AddIsUpdate = false;
        public string? idContainerModify;

        public FrmContainerAdd(FrmContainerCat frmCatalog, ClsContainer clsContainer)
        {
            InitializeComponent();

            cls = clsContainer;
            frmCat = frmCatalog;
        }

        private void FrmContainerAdd_Load(object sender, EventArgs e)
        {
            cls.BeginFormAdd();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            cls.btnAceptAddModify();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
