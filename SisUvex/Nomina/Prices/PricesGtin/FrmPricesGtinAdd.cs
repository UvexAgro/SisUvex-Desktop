using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.TextBoxes;

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
            InitializeControls();
            cls.BeginFormAdd();
        }

        private void InitializeControls()
        {
            ClsComboBoxes.CboLoadActives(cboCrop, Catalogos.Metods.ClsObject.Crop.Cbo);
            ClsComboBoxes.CboLoadActives(cboVariety, Catalogos.Metods.ClsObject.Variety.Cbo);
            ClsComboBoxes.CboLoadActives(cboContainer, Catalogos.Metods.ClsObject.Container.Cbo);
            ClsComboBoxes.CboLoadActives(cboPresentation, Catalogos.Metods.ClsObject.Presentation.Cbo);
            ClsComboBoxes.CboLoadActives(cboDistributor, Catalogos.Metods.ClsObject.Distributor.Cbo);
            ClsTextBoxes.TxbApplyKeyPressEventDecimal(txbLbs);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            cls.SavePricesGtin();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            cls.ApplyFilterAdd();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cls.MoveRowLeftToRight();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cls.MoveRowRightToLeft();
        }
    }
}
