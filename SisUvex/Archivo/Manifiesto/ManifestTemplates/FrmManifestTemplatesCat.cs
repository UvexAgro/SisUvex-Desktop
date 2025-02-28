using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Archivo.Manifiesto.ManifestTemplates
{
    public partial class FrmManifestTemplatesCat : Form
    {
        ClsManifestTemplates cls;
        public FrmManifestTemplatesCat()
        {
            InitializeComponent();
        }

        private void FrmManifestTemplatesCat_Load(object sender, EventArgs e)
        {
            cls ??= new();
            cls._frmCat ??= this;

            cls.BeginFormCat();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cls.OpenFrmAdd();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            cls.OpenFrmModify();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            cls.BtnRemove();
        }
    }
}
