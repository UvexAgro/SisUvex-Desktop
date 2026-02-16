using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Grow.PlantsRowLot
{
    public partial class FrmPlantsRowLotView : Form
    {
        ClsPlantsRowLotView cls;
        public FrmPlantsRowLotView()
        {
            InitializeComponent();
        }

        private void FrmPlantsRowLotView_Load(object sender, EventArgs e)
        {
            cls = new();
            cls.frm = this;
            cls.BeginFormCat();
        }

        private void cboField_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnLoadPlantsLot_Click(object sender, EventArgs e)
        {
            cls.BtnLoadPlantsLot();
        }

        private void chbHideOrShowColumns_CheckedChanged(object sender, EventArgs e)
        {
            cls.ShowOrHideColumns(chbShowOrHideColumns.Checked);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Próximamente...", "A te la creiste");
        }
    }
}
