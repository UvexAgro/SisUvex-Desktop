using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Nomina.Prices.PricesGtin
{
    internal partial class FrmPricesGtinAdd : Form
    {
        public ClsPricesGtin cls;
        public string idPrice;
        public FrmPricesGtinAdd()
        {
            InitializeComponent();
        }

        private void FrmPricesGtinAdd_Load(object sender, EventArgs e)
        {
            cls.BeginFormAdd();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            cls.SavePricesGtin();
        }
    }
}
