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
    internal partial class FrmPricesAdd : Form
    {
        ClsPrices cls;
        FrmPricesCat frmCat;
        public bool IsAddModify = true, AddIsUpdate = false;
        public string? idModify;
        public FrmPricesAdd(FrmPricesCat frmCatalog, ClsPrices clsPrices)
        {
            InitializeComponent();
            cls = clsPrices;
            frmCat = frmCatalog;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            cls.btnAcceptAddModify();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmPricesAdd_Load(object sender, EventArgs e)
        {
            cls.BeginFormAdd();
        }
    }
}
