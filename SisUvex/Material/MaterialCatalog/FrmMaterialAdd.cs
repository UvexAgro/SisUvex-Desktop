using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SisUvex.Catalogos.Metods.Images;

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
            cls.BtnLoadNewImage();
        }

        private void txbIdMaterialType_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRefreshImages_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txbId.Text))
                cls.BtnResetAllImages();
        }

        private void chbImageFront_Click(object sender, EventArgs e)
        {
            cls.ChbImagesClic(chbImageFront);
        }

        private void chbImageBack_Click(object sender, EventArgs e)
        {
            cls.ChbImagesClic(chbImageBack);
        }

        private void chbImageDown_Click(object sender, EventArgs e)
        {
            cls.ChbImagesClic(chbImageDown);
        }

        private void chbImageUp_Click(object sender, EventArgs e)
        {
            cls.ChbImagesClic(chbImageUp);
        }

        private void btnDeleteImage_Click(object sender, EventArgs e)
        {
            cls.BtnDeleteTemporalImage();
        }
    }
}
