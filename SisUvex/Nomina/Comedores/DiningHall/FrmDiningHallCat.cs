using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Nomina.Comedores.DiningHall
{
    internal partial class FrmDiningHallCat : Form
    {
        public ClsDiningHall cls;
        public FrmDiningHallCat()
        {
            InitializeComponent();
        }

        private void FrmDiningHallCat_Load(object sender, EventArgs e)
        {
            cls.BeginFormCat();
        }

        private void btnRemoved_Click(object sender, EventArgs e)
        {
            cls.dgv.UpdateCatalogButtonActivesDeletes();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            cls.RemoveProcedure();
        }

        private void btnRecover_Click(object sender, EventArgs e)
        {
            cls.RecoverProcedure();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cls.OpenFrmAdd();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            cls.OpenFrmModify();
        }

        private void dgvCatalog_DoubleClick(object sender, EventArgs e)
        {
            cls.OpenFrmModify();
        }
    }
}
