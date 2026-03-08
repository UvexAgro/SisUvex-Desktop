using SisUvex.Catalogos.Metods.Controls;
using System.Data;
using System.Data.SqlClient;
using SisUvex.Catalogos.Metods.Querys;
using System.Media;
using static SisUvex.Catalogos.Metods.ClsObject;
using static SisUvex.Catalogos.Metods.Extentions.ComboBoxExtensions;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.TextBoxes;
using SisUvex.Catalogos.Metods;
using SizeInfo = SisUvex.Catalogos.Metods.ClsObject.Size;

namespace SisUvex.Nomina.Prices.PricesGtin
{
    public enum PricingType
    {
        Gtin,
        GtinAndSize
    }

    internal class ClsPricesGtin
    {
        SQLControl sql = new SQLControl();
        ClsControls controlList;
        public FrmPricesGtinAdd _frmAdd;
        public FrmPricesGtinCat _frmCat;
        public EPricesGtin ePriceGtin;
        public PricingType CurrentPricingType { get; set; } = PricingType.Gtin;
        private string queryCatalogPrices = $"SELECT id_price AS '{Column.id}', v_descriptionPrice AS '{Price.ColumnName}', n_priceFieldNormal AS 'P. Campo normal', n_priceFieldOver AS 'P. Campo extra', n_priceFacilityNormal AS 'P. Empaque normal', n_priceFacilityOver AS 'P. Empaque extra'  FROM Pack_Price";
        public DataTable dtCatalogPrices, dtCatalogGtin, dtCatalogSize;

        public void BeginFormCat()
        {

            //Controles
            ClsComboBoxes.CboLoadActives(_frmCat.cboCrop, Crop.Cbo);
            ClsComboBoxes.CboLoadActives(_frmCat.cboVariety, Variety.Cbo);
            ClsComboBoxes.CboLoadActives(_frmCat.cboContainer, Container.Cbo);
            ClsComboBoxes.CboLoadActives(_frmCat.cboPresentation, Presentation.Cbo);
            ClsComboBoxes.CboLoadActives(_frmCat.cboDistributor, Distributor.Cbo);
            ClsComboBoxes.CboLoadActives(_frmCat.cboSize, SizeInfo.Cbo);
            //Controles+Eventos
            ClsComboBoxes.Events.CboApplyEventFilterAllForOne(_frmCat.cboVariety, null /*no lleva chb*/, new List<(ComboBox Cbo, string IdColumnFilter)> { (_frmCat.cboCrop, Crop.ColumnId) });
            ClsTextBoxes.TxbApplyKeyPressEventDecimal(_frmCat.txbLbs);

            dtCatalogPrices = ClsQuerysDB.GetDataTable(queryCatalogPrices);
            dtCatalogGtin = ClsQuerysDB.GetDataTable(GetQueryDgvGtinCatalog());
            dtCatalogSize = ClsQuerysDB.GetDataTable(GetQueryDgvSizeCatalog());

            _frmCat.dgvCatalogGtin.DataSource = dtCatalogGtin;
            _frmCat.dgvCatalogPrices.DataSource = dtCatalogPrices;
            _frmCat.dgvCatalogSize.DataSource = dtCatalogSize;

            HideIdColumnsGtin(_frmCat.dgvCatalogGtin);
            HideIdColumnsGtin(_frmCat.dgvCatalogSize);
        }

        public void BtnSearchFilter()
        {
            dtCatalogGtin.DefaultView.RowFilter = GetRowFilterGtin();
        }

        public void BtnSearchFilterSize()
        {
            dtCatalogSize.DefaultView.RowFilter = GetRowFilterSize();
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
            if (_frmCat.dgvCatalogPrices.SelectedRows.Count != 0)
            {
                _frmAdd = new FrmPricesGtinAdd();
                _frmAdd.cls = this;
                _frmAdd.Text = "Precios por Gtin y Tamaño";
                _frmAdd.lblTitle.Text = "Precios por Gtin y Tamaño";
                _frmAdd.idPrice = _frmCat.dgvCatalogPrices.SelectedRows[0].Cells[Column.id].Value.ToString();

                _frmAdd.ShowDialog();
            }
            else
                SystemSounds.Exclamation.Play();
        }

        public void BeginFormAdd()
        {
            LoadControlsAdd();
            LoadDataGridViewsAdd();
        }

        public void LoadDataGridViewsAdd()
        {
            string idPrice = _frmAdd.idPrice;

            DataTable dtLeft = ClsQuerysDB.GetDataTable(GetQueryDgvGtinCatalog());
            DataTable dtRight = GetAssignedGtinsDataTable(idPrice);

            LoadDgvPricesLeft(dtLeft);
            LoadDgvPricesRight(dtRight);
        }

        private DataTable GetAssignedGtinsDataTable(string idPrice)
        {
            string query = $@"SELECT
		                gtn.id_price					'{Price.ColumnId}',
		                prc.v_descriptionPrice			'{Price.ColumnName}',
		                gtn.c_active					'{Column.active}',
		                gtn.id_GTIN						'{Column.id}',
		                gtn.id_container				'{Container.ColumnId}',
		                con.v_nameContainer				'{Container.ColumnName}',
		                gtn.n_lbs						'Libras',
		                gtn.v_preLabel					'Pre etiqueta',
		                gtn.id_presentation				'{Presentation.ColumnId}',
		                pre.v_namePresentation			'{Presentation.ColumnName}',
		                gtn.id_variety					'{Variety.ColumnId}',
		                [var].v_nameComercial			'{Variety.ColumnName}',
		                [var].id_crop					'{Crop.ColumnId}',
		                gtn.v_postLabel					'Post etiqueta',
		                gtn.id_distributor				'{Distributor.ColumnId}',
		                dis.v_nameDistributor			'{Distributor.ColumnName}',
		                gtn.i_palletBoxes				'Cajas por pallet'
	                FROM Pack_GTIN gtn
		                LEFT JOIN	Pack_Presentation	pre		ON	pre.id_presentation	=	gtn.id_presentation
		                LEFT JOIN	Pack_Container		con		ON	con.id_container	=	gtn.id_container
		                LEFT JOIN	Pack_Variety		[var]	ON	[var].id_variety	=	gtn.id_variety
		                LEFT JOIN	Pack_Distributor	dis		ON	dis.id_distributor	=	gtn.id_distributor
		                LEFT JOIN	Pack_Price			prc		ON	prc.id_price		=	gtn.id_price
		                LEFT JOIN	Pack_PtiType		pti		ON	pti.id_pti			=	gtn.id_pti
                    WHERE gtn.id_price = '{idPrice}'
                    ";
            return ClsQuerysDB.GetDataTable(query);
        }

        private void LoadDgvPricesLeft(DataTable dt)
        {
            _frmAdd.dgvPricesLeft.DataSource = dt;
            _frmAdd.dgvPricesLeft.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            HideIdColumnsGtin(_frmAdd.dgvPricesLeft);

            foreach (DataGridViewColumn column in _frmAdd.dgvPricesLeft.Columns)
            {
                column.ReadOnly = true;
            }
        }

        private void LoadDgvPricesRight(DataTable dt)
        {
            _frmAdd.dgvPricesRight.DataSource = dt;
            _frmAdd.dgvPricesRight.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            HideIdColumnsGtin(_frmAdd.dgvPricesRight);

            foreach (DataGridViewColumn column in _frmAdd.dgvPricesRight.Columns)
            {
                column.ReadOnly = true;
            }
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
            switch (CurrentPricingType)
            {
                case PricingType.Gtin:
                    SaveGtinPrices();
                    break;
                case PricingType.GtinAndSize:
                    SaveGtinAndSizePrices();
                    break;
            }
        }

        private void SaveGtinPrices()
        {
            List<string> listRight = GetGtinsFromDataGridView(_frmAdd.dgvPricesRight);
            string idPrice = _frmAdd.idPrice;

            try
            {
                sql.OpenConectionWrite();

                if (listRight.Count > 0)
                {
                    // Asignar el precio a los GTINs seleccionados
                    string stringList = string.Join("', '", listRight);
                    string query = $"UPDATE Pack_GTIN SET id_price = '{idPrice}' WHERE id_GTIN IN ('{stringList}'); " +
                                 $"UPDATE Pack_GTIN SET id_price = NULL WHERE id_price = '{idPrice}' AND id_GTIN NOT IN ('{stringList}')";

                    SqlCommand cmd = new SqlCommand(query, sql.cnn);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show($"Se actualizaron correctamente los GTIN con el precio ({idPrice}) {ePriceGtin.descriptionPrice}");
                }
                else
                {
                    // Si no hay GTINs seleccionados, limpiar todos los que tengan este precio
                    string query = $"UPDATE Pack_GTIN SET id_price = NULL WHERE id_price = '{idPrice}'";

                    SqlCommand cmd = new SqlCommand(query, sql.cnn);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show($"Se limpió el precio ({idPrice}) {ePriceGtin.descriptionPrice} de todos los GTINs.");
                }

                _frmAdd.Close();
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

        private void SaveGtinAndSizePrices()
        {
            List<(string idGtin, string idSize)> listRight = GetGtinsAndSizesFromDataGridView(_frmAdd.dgvPricesRight);
            string idPrice = _frmAdd.idPrice;

            try
            {
                sql.OpenConectionWrite();

                if (listRight.Count > 0)
                {
                    // Insertar o actualizar los registros de tamaño seleccionados
                    string concatValues = string.Join(",", listRight.Select(x => $"CONCAT('{x.idGtin}', '{x.idSize}')"));

                    foreach (var (idGtin, idSize) in listRight)
                    {
                        string query = $@"
                            IF EXISTS (SELECT 1 FROM Pack_PricePerSize WHERE id_GTIN = '{idGtin}' AND id_size = '{idSize}')
                                UPDATE Pack_PricePerSize SET id_price = '{idPrice}', userUpdate = '{GetCurrentUser()}', d_update = CAST(GETDATE() AS DATE) 
                                WHERE id_GTIN = '{idGtin}' AND id_size = '{idSize}'
                            ELSE
                                INSERT INTO Pack_PricePerSize (id_price, id_GTIN, id_size, userCreate, d_create)
                                VALUES ('{idPrice}', '{idGtin}', '{idSize}', '{GetCurrentUser()}', CAST(GETDATE() AS DATE))";

                        SqlCommand cmd = new SqlCommand(query, sql.cnn);
                        cmd.ExecuteNonQuery();
                    }

                    // Limpiar los registros que no están en la lista seleccionada
                    string queryCleanup = $@"
                        UPDATE Pack_PricePerSize 
                        SET id_price = NULL, userUpdate = '{GetCurrentUser()}', d_update = CAST(GETDATE() AS DATE)
                        WHERE id_price = '{idPrice}' 
                        AND CONCAT(id_GTIN, id_size) NOT IN ({concatValues})";

                    SqlCommand cmdCleanup = new SqlCommand(queryCleanup, sql.cnn);
                    cmdCleanup.ExecuteNonQuery();

                    MessageBox.Show($"Se actualizaron correctamente los tamaños con el precio ({idPrice}) {ePriceGtin.descriptionPrice}");
                }
                else
                {
                    // Si no hay combinaciones seleccionadas, limpiar todos los registros con este precio
                    string query = $@"
                        UPDATE Pack_PricePerSize 
                        SET id_price = NULL, userUpdate = '{GetCurrentUser()}', d_update = CAST(GETDATE() AS DATE)
                        WHERE id_price = '{idPrice}'";

                    SqlCommand cmd = new SqlCommand(query, sql.cnn);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show($"Se limpió el precio ({idPrice}) {ePriceGtin.descriptionPrice} de todos los tamaños.");
                }

                _frmAdd.Close();
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

        private string GetCurrentUser()
        {
            return Environment.UserName;
        }

        private List<(string idGtin, string idSize)> GetGtinsAndSizesFromDataGridView(DataGridView dgv)
        {
            List<(string, string)> list = new List<(string, string)>();
            foreach (DataGridViewRow row in dgv.Rows)
            {
                string idGtin = row.Cells[Column.id].Value?.ToString();
                string idSize = row.Cells[SizeInfo.ColumnId].Value?.ToString();
                if (!string.IsNullOrEmpty(idGtin) && !string.IsNullOrEmpty(idSize))
                    list.Add((idGtin, idSize));
            }
            return list;
        }

        private List<string> GetGtinsFromDataGridView(DataGridView dgv)
        {
            List<string> list = new List<string>();
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells[Column.id].Value != null)
                    list.Add(row.Cells[Column.id].Value.ToString());
            }
            return list;
        }

        public void MoveRowLeftToRight()
        {
            if (_frmAdd.dgvPricesLeft.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = _frmAdd.dgvPricesLeft.SelectedRows[0];
                DataTable dtRight = (DataTable)_frmAdd.dgvPricesRight.DataSource;

                if (dtRight == null)
                {
                    dtRight = new DataTable();
                    CloneDataTableStructure(dtRight, (DataTable)_frmAdd.dgvPricesLeft.DataSource);
                    _frmAdd.dgvPricesRight.DataSource = dtRight;
                }

                // Copiar valores de la fila seleccionada al DataTable derecho
                DataRow newRow = dtRight.NewRow();
                foreach (DataGridViewCell cell in selectedRow.Cells)
                {
                    if (cell.ColumnIndex < dtRight.Columns.Count)
                        newRow[cell.ColumnIndex] = cell.Value ?? DBNull.Value;
                }
                dtRight.Rows.Add(newRow);

                int newRowIndex = dtRight.Rows.Count - 1;
                
                // Encontrar la primera columna visible para establecer como CurrentCell
                if (_frmAdd.dgvPricesRight.Rows.Count > newRowIndex)
                {
                    DataGridViewCell visibleCell = null;
                    foreach (DataGridViewColumn column in _frmAdd.dgvPricesRight.Columns)
                    {
                        if (column.Visible && column.Index < _frmAdd.dgvPricesRight.Rows[newRowIndex].Cells.Count)
                        {
                            visibleCell = _frmAdd.dgvPricesRight.Rows[newRowIndex].Cells[column.Index];
                            break;
                        }
                    }

                    if (visibleCell != null)
                    {
                        _frmAdd.dgvPricesRight.CurrentCell = visibleCell;
                    }
                }

                // Remover de la izquierda usando el índice de la fila en el DataGridView
                DataTable dtLeft = (DataTable)_frmAdd.dgvPricesLeft.DataSource;
                
                // Obtener el DataRow real del DataGridView
                try
                {
                    if (selectedRow.DataBoundItem is DataRowView drv)
                    {
                        DataRow rowToRemove = drv.Row;
                        // Buscar y remover por referencia directa
                        for (int i = dtLeft.Rows.Count - 1; i >= 0; i--)
                        {
                            if (dtLeft.Rows[i] == rowToRemove)
                            {
                                dtLeft.Rows.RemoveAt(i);
                                break;
                            }
                        }
                    }
                }
                catch
                {
                    // Si falla, encontrar por el valor del ID (Column.id)
                    object idValue = selectedRow.Cells[Column.id].Value;
                    for (int i = dtLeft.Rows.Count - 1; i >= 0; i--)
                    {
                        if (dtLeft.Rows[i][Column.id].Equals(idValue))
                        {
                            dtLeft.Rows.RemoveAt(i);
                            break;
                        }
                    }
                }
            }
        }

        public void MoveRowRightToLeft()
        {
            if (_frmAdd.dgvPricesRight.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = _frmAdd.dgvPricesRight.SelectedRows[0];
                DataTable dtLeft = (DataTable)_frmAdd.dgvPricesLeft.DataSource;

                // Copiar valores de la fila seleccionada al DataTable izquierdo
                DataRow newRow = dtLeft.NewRow();
                foreach (DataGridViewCell cell in selectedRow.Cells)
                {
                    if (cell.ColumnIndex < dtLeft.Columns.Count)
                        newRow[cell.ColumnIndex] = cell.Value ?? DBNull.Value;
                }
                dtLeft.Rows.Add(newRow);

                int newRowIndex = dtLeft.Rows.Count - 1;
                
                // Encontrar la primera columna visible para establecer como CurrentCell
                if (_frmAdd.dgvPricesLeft.Rows.Count > newRowIndex)
                {
                    DataGridViewCell visibleCell = null;
                    foreach (DataGridViewColumn column in _frmAdd.dgvPricesLeft.Columns)
                    {
                        if (column.Visible && column.Index < _frmAdd.dgvPricesLeft.Rows[newRowIndex].Cells.Count)
                        {
                            visibleCell = _frmAdd.dgvPricesLeft.Rows[newRowIndex].Cells[column.Index];
                            break;
                        }
                    }

                    if (visibleCell != null)
                    {
                        _frmAdd.dgvPricesLeft.CurrentCell = visibleCell;
                    }
                }

                // Remover de la derecha usando el índice de la fila en el DataGridView
                DataTable dtRight = (DataTable)_frmAdd.dgvPricesRight.DataSource;
                
                // Obtener el DataRow real del DataGridView
                try
                {
                    if (selectedRow.DataBoundItem is DataRowView drv)
                    {
                        DataRow rowToRemove = drv.Row;
                        // Buscar y remover por referencia directa
                        for (int i = dtRight.Rows.Count - 1; i >= 0; i--)
                        {
                            if (dtRight.Rows[i] == rowToRemove)
                            {
                                dtRight.Rows.RemoveAt(i);
                                break;
                            }
                        }
                    }
                }
                catch
                {
                    // Si falla, encontrar por el valor del ID (Column.id)
                    object idValue = selectedRow.Cells[Column.id].Value;
                    for (int i = dtRight.Rows.Count - 1; i >= 0; i--)
                    {
                        if (dtRight.Rows[i][Column.id].Equals(idValue))
                        {
                            dtRight.Rows.RemoveAt(i);
                            break;
                        }
                    }
                }
            }
        }

        private void CloneDataTableStructure(DataTable target, DataTable source)
        {
            foreach (DataColumn column in source.Columns)
            {
                target.Columns.Add(new DataColumn(column.ColumnName, column.DataType));
            }
        }

        public void ApplyFilterAdd()
        {
            DataTable dt = (DataTable)_frmAdd.dgvPricesLeft.DataSource;
            if (dt != null)
            {
                dt.DefaultView.RowFilter = GetRowFilterAdd();
            }
        }

        private string GetRowFilterAdd()
        {
            List<string> filters = new List<string>();

            if (_frmAdd.cboCrop.TryGetValue(out string cropValue))
                filters.Add($"[{Crop.ColumnId}] = '{cropValue}'");

            if (_frmAdd.cboVariety.TryGetValue(out string varietyValue))
                filters.Add($"[{Variety.ColumnId}] = '{varietyValue}'");

            if (_frmAdd.cboContainer.TryGetValue(out string containerValue))
                filters.Add($"[{Container.ColumnId}] = '{containerValue}'");

            if (_frmAdd.cboPresentation.TryGetValue(out string presentationValue))
                filters.Add($"[{Presentation.ColumnId}] = '{presentationValue}'");

            if (_frmAdd.cboDistributor.TryGetValue(out string distributorValue))
                filters.Add($"[{Distributor.ColumnId}] = '{distributorValue}'");

            if (!string.IsNullOrWhiteSpace(_frmAdd.txbLbs.Text))
                filters.Add($"[Libras] = {_frmAdd.txbLbs.Text}");

            return string.Join(" AND ", filters);
        }

        private string GetQueryDgvGtinCatalog()
        {
            return $@"SELECT
		                gtn.id_price					'{Price.ColumnId}',
		                prc.v_descriptionPrice			'{Price.ColumnName}',
		                gtn.c_active					'{Column.active}',
		                gtn.id_GTIN						'{Column.id}',
		                gtn.id_container				'{Container.ColumnId}',
		                con.v_nameContainer				'{Container.ColumnName}',
		                gtn.n_lbs						'Libras',
		                gtn.v_preLabel					'Pre etiqueta',
		                gtn.id_presentation				'{Presentation.ColumnId}',
		                pre.v_namePresentation			'{Presentation.ColumnName}',
		                gtn.id_variety					'{Variety.ColumnId}',
		                [var].v_nameComercial			'{Variety.ColumnName}',
		                [var].id_crop					'{Crop.ColumnId}',
		                gtn.v_postLabel					'Post etiqueta',
		                gtn.id_distributor				'{Distributor.ColumnId}',
		                dis.v_nameDistributor			'{Distributor.ColumnName}',
		                gtn.i_palletBoxes				'Cajas por pallet'
	                FROM Pack_GTIN gtn
		                LEFT JOIN	Pack_Presentation	pre		ON	pre.id_presentation	=	gtn.id_presentation
		                LEFT JOIN	Pack_Container		con		ON	con.id_container	=	gtn.id_container
		                LEFT JOIN	Pack_Variety		[var]	ON	[var].id_variety	=	gtn.id_variety
		                LEFT JOIN	Pack_Distributor	dis		ON	dis.id_distributor	=	gtn.id_distributor
		                LEFT JOIN	Pack_Price			prc		ON	prc.id_price		=	gtn.id_price
		                LEFT JOIN	Pack_PtiType		pti		ON	pti.id_pti			=	gtn.id_pti
                    ";
        }

        private string GetQueryDgvSizeCatalog()
        {
            return $@"SELECT
		                pps.id_price					'{Price.ColumnId}',
		                prc.v_descriptionPrice			'{Price.ColumnName}',
		                pps.id_GTIN						'{Column.id}',
		                gtn.id_container				'{Container.ColumnId}',
		                con.v_nameContainer				'{Container.ColumnName}',
		                gtn.n_lbs						'Libras',
		                pps.id_size						'{SizeInfo.ColumnId}',
		                ps.v_sizeValue					'{SizeInfo.ColumnName}',
		                gtn.id_presentation				'{Presentation.ColumnId}',
		                pre.v_namePresentation			'{Presentation.ColumnName}',
		                gtn.id_variety					'{Variety.ColumnId}',
		                [var].v_nameComercial			'{Variety.ColumnName}',
		                [var].id_crop					'{Crop.ColumnId}',
		                gtn.id_distributor				'{Distributor.ColumnId}',
		                dis.v_nameDistributor			'{Distributor.ColumnName}'
	                FROM Pack_PricePerSize pps
		                LEFT JOIN	Pack_GTIN			gtn		ON	gtn.id_GTIN			=	pps.id_GTIN
		                LEFT JOIN	Pack_Size			ps		ON	ps.id_size			=	pps.id_size
		                LEFT JOIN	Pack_Presentation	pre		ON	pre.id_presentation	=	gtn.id_presentation
		                LEFT JOIN	Pack_Container		con		ON	con.id_container	=	gtn.id_container
		                LEFT JOIN	Pack_Variety		[var]	ON	[var].id_variety	=	gtn.id_variety
		                LEFT JOIN	Pack_Distributor	dis		ON	dis.id_distributor	=	gtn.id_distributor
		                LEFT JOIN	Pack_Price			prc		ON	prc.id_price		=	pps.id_price
                    WHERE pps.id_price IS NOT NULL
                    ";
        }
        private string GetRowFilterGtin()
        {
            List<string> filters = new List<string>();

            if (_frmCat.cboCrop.TryGetValue(out string cropValue))
                filters.Add($"[{Crop.ColumnId}] = '{cropValue}'");

            if (_frmCat.cboVariety.TryGetValue(out string varietyValue))
                filters.Add($"[{Variety.ColumnId}] = '{varietyValue}'");

            if (_frmCat.cboContainer.TryGetValue(out string containerValue))
                filters.Add($"[{Container.ColumnId}] = '{containerValue}'");

            if (_frmCat.cboPresentation.TryGetValue(out string presentationValue))
                filters.Add($"[{Presentation.ColumnId}] = '{presentationValue}'");

            if (_frmCat.cboDistributor.TryGetValue(out string distributorValue))
                filters.Add($"[{Distributor.ColumnId}] = '{distributorValue}'");

            if (!string.IsNullOrWhiteSpace(_frmCat.txbLbs.Text))
                filters.Add($"[Libras] = {_frmCat.txbLbs.Text}");

            return string.Join(" AND ", filters);
        }

        private string GetRowFilterSize()
        {
            List<string> filters = new List<string>();

            if (_frmCat.cboCrop.TryGetValue(out string cropValue))
                filters.Add($"[{Crop.ColumnId}] = '{cropValue}'");

            if (_frmCat.cboVariety.TryGetValue(out string varietyValue))
                filters.Add($"[{Variety.ColumnId}] = '{varietyValue}'");

            if (_frmCat.cboContainer.TryGetValue(out string containerValue))
                filters.Add($"[{Container.ColumnId}] = '{containerValue}'");

            if (_frmCat.cboPresentation.TryGetValue(out string presentationValue))
                filters.Add($"[{Presentation.ColumnId}] = '{presentationValue}'");

            if (_frmCat.cboDistributor.TryGetValue(out string distributorValue))
                filters.Add($"[{Distributor.ColumnId}] = '{distributorValue}'");

            if (_frmCat.cboSize.TryGetValue(out string sizeValue))
                filters.Add($"[{SizeInfo.ColumnId}] = '{sizeValue}'");

            if (!string.IsNullOrWhiteSpace(_frmCat.txbLbs.Text))
                filters.Add($"[Libras] = {_frmCat.txbLbs.Text}");

            return string.Join(" AND ", filters);
        }
        public void HideIdColumnsGtin(DataGridView dgv)
        {
            if (dgv.Columns.Contains(Price.ColumnId))
                dgv.Columns[Price.ColumnId].Visible = false;

            if (dgv.Columns.Contains(Crop.ColumnId))
                dgv.Columns[Crop.ColumnId].Visible = false;

            if (dgv.Columns.Contains(Variety.ColumnId))
                dgv.Columns[Variety.ColumnId].Visible = false;

            if (dgv.Columns.Contains(Container.ColumnId))
                dgv.Columns[Container.ColumnId].Visible = false;

            if (dgv.Columns.Contains(Presentation.ColumnId))
                dgv.Columns[Presentation.ColumnId].Visible = false;

            if (dgv.Columns.Contains(Distributor.ColumnId))
                dgv.Columns[Distributor.ColumnId].Visible = false;

            if (dgv.Columns.Contains(SizeInfo.ColumnId))
                dgv.Columns[SizeInfo.ColumnId].Visible = false;
        }
    }
}