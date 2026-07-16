using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Extentions;
using SisUvex.Catalogos.Metods.TextBoxes;
using SisUvex.Nomina.Conceptos_Ingresos_Diversos;
using System.Media;

namespace SisUvex.Nomina.Prices.PricesGtin
{
    internal partial class FrmPricesGtinAdd : Form
    {
        public ClsPricesGtin cls;
        public string idPrice;
        public List<(string?, string?)> lsPricesStartGtinOrSize; // (idGtin, idSize)
        public List<(string?, string?)> lsPricesEndGtinOrSize; // (idGtin, idSize)
        public FrmPricesGtinAdd()
        {
            InitializeComponent();
        }

        private void FrmPricesGtinAdd_Load(object sender, EventArgs e)
        {
            InitializeControls();
            cls.BeginFormAdd();

            lsPricesStartGtinOrSize = new();
            lsPricesEndGtinOrSize = new();
            cls.isModifyUpdate = false;
            if (cls.CurrentPricingType == PricingType.Gtin)
            {
                cboSize.Visible = false; //ocultar el tamaño porque no se necesita para este tipo de precio
                lblSize.Visible = false;
                SetLsPricesGtin(lsPricesStartGtinOrSize);
            }
            else
                SetLsPricesGtinSize(lsPricesStartGtinOrSize);
        }

        private void InitializeControls()
        {
            ClsComboBoxes.CboLoadActives(cboCrop, ClsObject.Crop.Cbo);
            ClsComboBoxes.CboLoadActives(cboVariety, ClsObject.Variety.Cbo);
            ClsComboBoxes.CboLoadActives(cboContainer, ClsObject.Container.Cbo);
            ClsComboBoxes.CboLoadActives(cboPresentation, ClsObject.Presentation.Cbo);
            ClsComboBoxes.CboLoadActives(cboDistributor, ClsObject.Distributor.Cbo);
            ClsComboBoxes.CboLoadActives(cboSize, ClsObject.Size.Cbo);
            ClsTextBoxes.TxbApplyKeyPressEventDecimal(txbLbs);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show(cls.isModifyUpdate.ToString());
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (cls.CurrentPricingType == PricingType.Gtin)
                SetLsPricesGtin(lsPricesEndGtinOrSize);
            else
                SetLsPricesGtinSize(lsPricesEndGtinOrSize);

            cls.SavePricesGtin();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            cls.ApplyFilterAdd();
        }

        private void btnAddToRigt_Click(object sender, EventArgs e)
        {
            if (cls.CurrentPricingType == PricingType.Gtin)
            {   cls.CopySelectedRowToTarget(dgvPricesLeft, dgvPricesRight);
                cls.RemoveSelectedRow(dgvPricesRight);
                return;
            }

            if (!cboSize.TryGetValue(out string id))
            {   SystemSounds.Exclamation.Play();
                return;
            }

            string idGtin = dgvPricesLeft.SelectedRows[0].Cells[ClsObject.Column.id].Value.ToString();

            if (!cls.ValidateGtinAndSizeInRight(idGtin, id))
            {   SystemSounds.Exclamation.Play();
                MessageBox.Show("El tamaño con ese GTIN ya está seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int indexNewRowRight = cls.CopySelectedRowToTarget(dgvPricesLeft, dgvPricesRight);
            cls.InsertSizeInNewRowRight(indexNewRowRight);
        }

        private void btnQuitRight_Click(object sender, EventArgs e)
        {
            if (cls.CurrentPricingType == PricingType.Gtin)
            {
                cls.CopySelectedRowToTarget(dgvPricesRight, dgvPricesLeft);
                cls.RemoveSelectedRow(dgvPricesRight);
            }
            else
                cls.RemoveSelectedRow(dgvPricesRight);
        }

        private void SetLsPricesGtin(List<(string?, string?)> lsGtin)
        {
            lsGtin.Clear();

            if (!dgvPricesRight.Columns.Contains(ClsObject.Column.id))
                return;

            foreach (DataGridViewRow row in dgvPricesRight.Rows)
            {
                if (row.Cells[ClsObject.Column.id].Value != null)
                {
                    string idGtin = row.Cells[ClsObject.Column.id].Value.ToString();
                    lsGtin.Add((idGtin, null));
                }
            }
        }
        private void SetLsPricesGtinSize(List<(string?, string?)> lsGtinSize)
        {
            lsGtinSize.Clear();

            if (!dgvPricesRight.Columns.Contains(ClsObject.Column.id) || !dgvPricesRight.Columns.Contains(ClsObject.Size.ColumnId))
                return;
            foreach (DataGridViewRow row in dgvPricesRight.Rows)
            {
                if (row.Cells[ClsObject.Column.id].Value != null)
                {
                    string idGtin = row.Cells[ClsObject.Column.id].Value.ToString();
                    string idSize = row.Cells[ClsObject.Size.ColumnId].Value.ToString();
                    lsGtinSize.Add((idGtin, idSize));
                }
            }
        }

    }
}
