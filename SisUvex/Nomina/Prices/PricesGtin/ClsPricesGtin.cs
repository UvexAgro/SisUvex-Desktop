using SisUvex.Catalogos.Metods.Controls;
using System.Data;
using System.Data.SqlClient;
using SisUvex.Catalogos.Metods.Querys;
using System.Media;
using static SisUvex.Catalogos.Metods.ClsObject;

namespace SisUvex.Nomina.Prices.PricesGtin
{
    internal class ClsPricesGtin
    {
        SQLControl sql = new SQLControl();
        ClsControls controlList;
        public FrmPricesGtinAdd _frmAdd;
        public FrmPricesGtinCat _frmCat;
        public EPricesGtin ePriceGtin;
        private string queryCatalogPrices = $"SELECT id_price AS '{Column.id}', v_descriptionPrice AS '{Price.ColumnName}', n_priceFieldNormal AS 'P. Campo normal', n_priceFieldOver AS 'P. Campo extra', n_priceFacilityNormal AS 'P. Empaque normal', n_priceFacilityOver AS 'P. Empaque extra'  FROM Pack_Price";
        private string queryCatalogGtin = $"SELECT gtn.id_price AS '{Price.ColumnId}',gtn.id_price AS '{Price.ColumnName} ', cat.* FROM vw_PackGTINCat cat JOIN Pack_GTIN gtn ON gtn.id_GTIN = cat.Código";
        public DataTable dtCatalogPrices, dtCatalogGtin;

        public ClsPricesGtin()
        {
            _frmCat = new FrmPricesGtinCat();

            _frmCat.cls = this;
        }



        public void BeginFormCat()
        {
            dtCatalogPrices = ClsQuerysDB.GetDataTable(queryCatalogPrices);
            dtCatalogGtin = ClsQuerysDB.GetDataTable(queryCatalogGtin);

            _frmCat.dgvCatalogPrices.DataSource = dtCatalogPrices;
            _frmCat.dgvCatalogGtin.DataSource = dtCatalogGtin;
            _frmCat.dgvCatalogGtin.Columns[Price.ColumnId].Visible = false;
        }

        public void SelectPriceFrmCat()
        {
            if (_frmCat.dgvCatalogPrices.Rows.Count > 0)
            {
                dtCatalogGtin.DefaultView.RowFilter = $"{Price.ColumnId} = {_frmCat.dgvCatalogPrices.CurrentRow.Cells[Column.id].Value}";
            }
        }
        public void OpenFrmAdd()
        {
            if ( _frmCat.dgvCatalogPrices.SelectedRows.Count != 0 )
            {
                _frmAdd = new FrmPricesGtinAdd();
                _frmAdd.cls = this;
                _frmAdd.Text = "Seleccionar precios por GTIN";
                _frmAdd.lblTitle.Text = "Seleccionar precios por GTIN";
                //_frmAdd.IsAddModify = true;
                _frmAdd.idPrice = _frmCat.dgvCatalogPrices.SelectedRows[0].Cells[Column.id].Value.ToString();


                _frmAdd.ShowDialog();
            }
            else
                SystemSounds.Exclamation.Play();
        }

        public void BeginFormAdd()
        {
            LoadControlsAdd();

            LoadDataGridViewAdd();
        }

        public void LoadDataGridViewAdd()
        {
            string id = _frmAdd.idPrice;
            DataTable dt = ClsQuerysDB.GetDataTable(queryCatalogGtin);

            // Add a new column called "Seleccionado"
            DataGridViewCheckBoxColumn checkboxColumn = new DataGridViewCheckBoxColumn();
            checkboxColumn.Name = "Seleccionado";
            checkboxColumn.HeaderText = "Seleccionado";
            checkboxColumn.TrueValue = true;
            checkboxColumn.FalseValue = false;
            checkboxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            _frmAdd.dgvPricesGtinAdd.Columns.Add(checkboxColumn);

            _frmAdd.dgvPricesGtinAdd.DataSource = dt;

            checkboxColumn.DataPropertyName = Price.ColumnId;

            // Set the checkbox value based on the "Código" column value
            foreach (DataGridViewRow row in _frmAdd.dgvPricesGtinAdd.Rows)
            {
                string codigo = row.Cells[Price.ColumnId].Value.ToString();
                bool isSelected = (codigo == id);
                row.Cells["Seleccionado"].Value = isSelected;
            }

            foreach (DataGridViewColumn column in _frmAdd.dgvPricesGtinAdd.Columns)
            {
                column.ReadOnly = true;
            }
            _frmAdd.dgvPricesGtinAdd.Columns["Seleccionado"].ReadOnly = false;

            _frmAdd.dgvPricesGtinAdd.Columns[Price.ColumnId].Visible = false;
        }

        private void LoadControlsAdd()
        {
            ePriceGtin = new EPricesGtin();
            ePriceGtin.SetPricesGtin(_frmAdd.idPrice);

            _frmAdd.txbId.Text = ePriceGtin.idPrice;
            _frmAdd.txbDescription.Text = ePriceGtin.descriptionPrice;
            _frmAdd.txbFieldNormal.Text = ePriceGtin.priceFieldNormal;
            _frmAdd.txbFieldOver.Text = ePriceGtin.priceFieldOver;
            _frmAdd.txbFacilityNormal.Text = ePriceGtin.priceFacilityNormal;
            _frmAdd.txbFacilityOver.Text = ePriceGtin.priceFacilityOver;
        }

        public void SavePricesGtin()
        {
            List<string> list = new List<string>();

            foreach (DataGridViewRow row in _frmAdd.dgvPricesGtinAdd.Rows)
            {
                if (row.Cells["Seleccionado"].Value != null && bool.TryParse(row.Cells["Seleccionado"].Value.ToString(), out bool isSelected) && isSelected)
                    list.Add(row.Cells[Column.id].Value.ToString());
            }

            if (list.Count > 0)
            {
                try
                {
                    string idPrice = _frmAdd.idPrice;

                    sql.OpenConectionWrite();
                    string stringList = string.Join("', '", list);
                    string query = $"UPDATE Pack_GTIN SET id_price = '{idPrice}' WHERE id_GTIN IN ('{stringList}') UPDATE Pack_GTIN SET id_price = NULL WHERE id_price = '001' AND id_GTIN NOT IN ('{stringList}')";

                    SqlCommand cmd = new SqlCommand(query, sql.cnn);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show($"Se agregaron correctamente los GTIN: {stringList}\n con el precio ({idPrice}) {ePriceGtin.descriptionPrice}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Catálogo añadir");
                }
                finally
                {
                    sql.CloseConectionWrite();
                }
            }
            else
                SystemSounds.Exclamation.Play();
        }
    }
}