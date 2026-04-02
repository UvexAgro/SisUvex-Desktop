using SisUvex.Catalogos.Metods.DataGridViews;
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
        public ClsPricesGtin? cls;
        public FrmPricesGtinCat()
        {
            InitializeComponent();
        }

        private void FrmPricesGtinCat_Load(object sender, EventArgs e)
        {
            cls ??= new();
            cls._frmCat ??= this;

            cls.BeginFormCat();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            cls.SelectPriceFrmCat();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            cls.OpenFrmModify(PricingType.Gtin);

            if (cls.isModifyUpdate)
                cls.ModifyDgvGtinCatalog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            cls.BtnSearchFilter();

            cboSize.SelectedIndex = 0; //para quitarle el filtro de tamaño antes de
            cls.BtnSearchFilterSize();
        }

        private void btnSearchSize_Click(object sender, EventArgs e)
        {
            cls.BtnSearchFilter();

            cls.BtnSearchFilterSize();
        }

        private void btnSize_Click(object sender, EventArgs e)
        {
            cls.OpenFrmModify(PricingType.GtinAndSize);

            if (cls.isModifyUpdate)
                cls.ModifyDgvGtinAndSizeCatalog();
        }
    }
}
