using SisUvex.Catalogos.WorkGroup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Archivo.Manifiesto
{
    internal partial class FrmManifestAdd : Form
    {
        public ClsManifest cls;
        public bool IsAddModify = true, AddIsUpdate = false;
        public string? idModify;
        public FrmManifestAdd()
        {
            InitializeComponent();

            cls ??= new ClsManifest();
            cls._frmAdd ??= this;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        private void FrmManifestAdd_Load(object sender, EventArgs e)
        {

        }

        private void chbRemovedDistributor_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
