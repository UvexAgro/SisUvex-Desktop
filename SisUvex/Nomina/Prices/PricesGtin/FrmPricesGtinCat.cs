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
    internal partial class FrmPricesGtinCat : Form
    {
        public ClsPricesGtin cls;
        public FrmPricesGtinCat()
        {
            InitializeComponent();

        }

        private void FrmPricesGtinCat_Load(object sender, EventArgs e)
        {
            cls.BeginFormCat();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            cls.SelectPriceFrmCat();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            cls.OpenFrmAdd();
        }
    }
}
