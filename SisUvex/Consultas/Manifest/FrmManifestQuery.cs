using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Consultas.Manifest
{
    public partial class FrmManifestQuery : Form
    {
        ClsManifestQuery cls;
        public FrmManifestQuery()
        {
            InitializeComponent();
        }

        private void FrmManifestQuery_Load(object sender, EventArgs e)
        {
            cls = new ClsManifestQuery();
            cls.frm = this;
            cls.LoadForm();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            cls.SetCatalogPresentationBeetweenDays();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            cls.BtnAll();
        }

        private void btnManifest_Click(object sender, EventArgs e)
        {
            cls.BtnManifest();
        }
    }
}
