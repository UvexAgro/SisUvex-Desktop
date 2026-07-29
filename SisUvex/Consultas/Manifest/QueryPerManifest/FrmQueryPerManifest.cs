using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Consultas.Manifest.QueryPerManifest
{
    public partial class FrmQueryPerManifest : Form
    {
        ClsQueryPerManifest cls;
        private static readonly Color ManifestHighlightColor = Color.FromArgb(220, 235, 252);

        public FrmQueryPerManifest()
        {
            InitializeComponent();
        }

        private void FrmQueryPerManifest_Load(object sender, EventArgs e)
        {
            cls = new ClsQueryPerManifest();
            cls.frm = this;
            dgvQuery.DataBindingComplete += dgvQuery_DataBindingComplete;
            cls.LoadForm();
        }

        private void btnSearch_Click(object sender, EventArgs e)
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
            ApplyManifestGroupStyles();
        }

        private void ApplyManifestGroupStyles()
        {
            if (!dgvQuery.Columns.Contains("Manifiesto")) return;

            int groupIndex = 0;
            string lastManifest = null;

            foreach (DataGridViewRow row in dgvQuery.Rows)
            {
                if (row.IsNewRow) continue;

                string manifest = row.Cells["Manifiesto"].Value?.ToString() ?? "";
                bool isNewGroup = manifest != lastManifest;

                if (isNewGroup && lastManifest != null)
                    groupIndex++;

                Color bgColor = (groupIndex % 2 == 0) ? Color.White : ManifestHighlightColor;

                row.DefaultCellStyle.BackColor = bgColor;

                lastManifest = manifest;
            }
        }
    }
}
