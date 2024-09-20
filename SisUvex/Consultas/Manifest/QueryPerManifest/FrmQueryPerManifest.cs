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
        public FrmQueryPerManifest()
        {
            InitializeComponent();
        }

        private void FrmQueryPerManifest_Load(object sender, EventArgs e)
        {
            cls = new ClsQueryPerManifest();
            cls.frm = this;
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

        private void dgvQuery_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvQuery.Columns[e.ColumnIndex].Name == "Manifiesto")
            {
                if (e.RowIndex > 0 && dgvQuery.Rows[e.RowIndex - 1].Cells["Manifiesto"].Value.ToString() == e.Value.ToString())
                {
                    for (int i = 0; i < dgvQuery.Columns.Count; i++)
                    {
                        dgvQuery.Rows[e.RowIndex].Cells[i].Style.Font = new Font(dgvQuery.Font, FontStyle.Regular);
                    }
                }
                else
                {
                    for (int i = 0; i < dgvQuery.Columns.Count; i++)
                    {
                        dgvQuery.Rows[e.RowIndex].Cells[i].Style.Font = new Font(dgvQuery.Font, FontStyle.Bold);
                    }
                }
            }
        }
    }
}
