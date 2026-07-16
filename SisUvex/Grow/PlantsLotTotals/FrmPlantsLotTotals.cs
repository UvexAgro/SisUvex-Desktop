using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Grow.PlantsLotTotals
{
    public partial class FrmPlantsLotTotals : Form
    {
        ClsPlantsLotTotals cls;
        public FrmPlantsLotTotals()
        {
            InitializeComponent();
        }

        private void FrmPlantsLotTotals_Load(object sender, EventArgs e)
        {
            cls ??= new();
            cls.frm = this;

            cls.BeginFormCat();
        }

        private void btnLoadPlantsLot_Click(object sender, EventArgs e)
        {

            cls.BtnLoadDgv();
        }
    }
}
