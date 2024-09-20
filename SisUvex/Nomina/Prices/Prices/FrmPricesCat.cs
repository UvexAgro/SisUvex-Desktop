using SisUvex.Catalogos.GTIN_UPC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Nomina.Prices.Prices
{
    internal partial class FrmPricesCat : Form
    {
        ClsPrices cls;
        public FrmPricesCat(ClsPrices clsPrice)
        {
            InitializeComponent();
            cls = clsPrice;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cls.OpenFrmAdd();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            cls.OpenFrmModify();
        }

        private void FrmPricesCat_Load(object sender, EventArgs e)
        {
            cls.BeginFormCat();
        }
    }
}
