using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Material.MaterialCatalog
{
    internal partial class FrmMaterialAdd : Form
    {
        public ClsMaterialCatalog cls;
        public FrmMaterialAdd()
        {
            InitializeComponent();
        }

        private void FrmMaterialAdd_Load(object sender, EventArgs e)
        {
            cls ??= new ClsMaterialCatalog();
            cls._frmAdd = this;
            cls.BeginFormAdd();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            cls.BtnAccept();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPictureAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
