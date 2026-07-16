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
        private static readonly Color RowHighlightColor = Color.FromArgb(220, 235, 252);

        public FrmManifestQuery()
        {
            InitializeComponent();
        }

        private void FrmManifestQuery_Load(object sender, EventArgs e)
        {
            cls = new ClsManifestQuery();
            cls.frm = this;
            dgvQuery.DataBindingComplete += dgvQuery_DataBindingComplete;
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

        private void dgvQuery_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ApplyAlternatingRowColors();
        }

        private void ApplyAlternatingRowColors()
        {
            foreach (DataGridViewRow row in dgvQuery.Rows)
            {
                if (row.IsNewRow) continue;

                Color bgColor = (row.Index % 2 == 0) ? Color.White : RowHighlightColor;
                row.DefaultCellStyle.BackColor = bgColor;
            }
        }
    }
}
