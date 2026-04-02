using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.DataGridViews;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Catalogos.Metods.TextBoxes;
using System.Data;
using System.Data.SqlClient;
using System.Media;
using static SisUvex.Catalogos.Metods.ClsObject;
using static SisUvex.Catalogos.Metods.Extentions.ComboBoxExtensions;
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
        public bool isModifyUpdate = false;

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
            //DataTables y DataGridViews
            dtCatalogPrices = ClsQuerysDB.GetDataTable(queryCatalogPrices);
            dtCatalogGtin = ClsQuerysDB.GetDataTable(GetQueryDgvGtinCatalog());
            dtCatalogSize = ClsQuerysDB.GetDataTable(GetQueryDgvSizeCatalog() + "WHERE pps.id_price is not null ");

            _frmCat.dgvCatalogGtin.DataSource = dtCatalogGtin;
            _frmCat.dgvCatalogPrices.DataSource = dtCatalogPrices;
            _frmCat.dgvCatalogSize.DataSource = dtCatalogSize;
            //Ocultar columnas ID
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
                dtCatalogGtin.DefaultView.RowFilter = $"{Price.ColumnId} = {_frmCat.dgvCatalogPrices.CurrentRow.Cells[Column.id].Value}";
        }
        public void OpenFrmModify(PricingType pricingType)
        {
            if (_frmCat.dgvCatalogPrices.SelectedRows.Count != 0)
            {   _frmAdd = new();
                _frmAdd.cls = this;
                _frmAdd.idPrice = _frmCat.dgvCatalogPrices.SelectedRows[0].Cells[Column.id].Value.ToString();

                CurrentPricingType = pricingType;

                if (CurrentPricingType == PricingType.Gtin)
                {   _frmAdd.Text = "Precios por Gtin";
                    _frmAdd.lblTitle.Text = "Precios por Gtin";
                }
                else
                {   _frmAdd.Text = "Precios por Gtin y Tamaño";
                    _frmAdd.lblTitle.Text = "Precios por Gtin y Tamaño";
                }
                _frmAdd.ShowDialog();
            }
            else
                SystemSounds.Exclamation.Play();
        }
        public void BeginFormAdd()
        {
            LoadControlsAdd();
            LoadDataGridViewsModify();
        }
        public void LoadDataGridViewsModify()
        {
            string idPrice = _frmAdd.idPrice;
            string query;
            DataTable dtLeft = new();
            DataTable dtRight = new();

            if (CurrentPricingType == PricingType.Gtin) //Cargar dgvs dependiendo del tipo de precio
            {
                dtLeft = ClsQuerysDB.GetDataTable(GetQueryDgvGtinCatalog() + $" WHERE gtn.id_price != '{idPrice}' OR gtn.id_price is null");
                dtRight = ClsQuerysDB.GetDataTable(GetQueryDgvGtinCatalog() + $" WHERE gtn.id_price = '{idPrice}'");
            }
            else //GtinAndSize si ocupa mostrar todos los gtin siempre, por si se quiere agregar otro tamaño diferente para ese mismo gtin
            {
                dtLeft = ClsQuerysDB.GetDataTable(GetQueryDgvGtinCatalog());
                dtRight = ClsQuerysDB.GetDataTable(GetQueryDgvSizeCatalog() + $" WHERE pps.id_price = '{idPrice}'");
            }

            // Cargar los DataGridViews
            _frmAdd.dgvPricesLeft.DataSource = dtLeft;
            HideIdColumnsGtin(_frmAdd.dgvPricesLeft);

            _frmAdd.dgvPricesRight.DataSource = dtRight;
            HideIdColumnsGtin(_frmAdd.dgvPricesRight);
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
                    {
                        SaveGtinPrices();
                    }
                    break;
                case PricingType.GtinAndSize:
                    {
                        SaveGtinAndSizePrices();
                    }
                    break;
            }
        }

        private void SaveGtinPrices()
        {
            string idPrice = _frmAdd.idPrice;

            try
            {
                sql.OpenConectionWrite();

                if (_frmAdd.lsPricesEndGtinOrSize.Count > 0)
                {
                    // Asignar el precio a los GTINs seleccionados
                    string stringList = string.Join("', '", _frmAdd.lsPricesEndGtinOrSize.Select(x => x.Item1)); //Solo primer valor de GTIN    
                    string query = $"UPDATE Pack_GTIN SET id_price = '{idPrice}' WHERE id_GTIN IN ('{stringList}'); " +
                                 $"UPDATE Pack_GTIN SET id_price = NULL, userUpdate = '{User.GetUserName()}', d_update = CONVERT(DATE, GETDATE() ) WHERE id_price = '{idPrice}' AND id_GTIN NOT IN ('{stringList}')";

                    SqlCommand cmd = new SqlCommand(query, sql.cnn);
                    cmd.ExecuteNonQuery();

                    isModifyUpdate = true;
                    MessageBox.Show($"Se actualizaron correctamente los GTIN con el precio ({idPrice}) {ePriceGtin.descriptionPrice}");
                }
                else
                {
                    // Si no hay GTINs seleccionados, limpiar todos los que tengan este precio
                    string query = $"UPDATE Pack_GTIN SET id_price = NULL, userUpdate = '{User.GetUserName()}', d_update = CONVERT(DATE, GETDATE() ) WHERE id_price = '{idPrice}'";

                    SqlCommand cmd = new SqlCommand(query, sql.cnn);
                    cmd.ExecuteNonQuery();

                    isModifyUpdate = true;
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
                                UPDATE Pack_PricePerSize SET id_price = '{idPrice}', userUpdate = '{User.GetUserName()}', d_update = CAST(GETDATE() AS DATE) 
                                WHERE id_GTIN = '{idGtin}' AND id_size = '{idSize}'
                            ELSE
                                INSERT INTO Pack_PricePerSize (id_price, id_GTIN, id_size, userCreate, d_create)
                                VALUES ('{idPrice}', '{idGtin}', '{idSize}', '{User.GetUserName()}', CAST(GETDATE() AS DATE))";

                        SqlCommand cmd = new SqlCommand(query, sql.cnn);
                        cmd.ExecuteNonQuery();

                    }

                    // Limpiar los registros que no están en la lista seleccionada
                    string queryCleanup = $@"
                        UPDATE Pack_PricePerSize 
                        SET id_price = NULL, userUpdate = '{User.GetUserName()}', d_update = CAST(GETDATE() AS DATE)
                        WHERE id_price = '{idPrice}' 
                        AND CONCAT(id_GTIN, id_size) NOT IN ({concatValues})";

                    SqlCommand cmdCleanup = new SqlCommand(queryCleanup, sql.cnn);
                    cmdCleanup.ExecuteNonQuery();

                    isModifyUpdate = true;

                    MessageBox.Show($"Se actualizaron correctamente los tamaños con el precio ({idPrice}) {ePriceGtin.descriptionPrice}");
                }
                else if (_frmAdd.lsPricesStartGtinOrSize.Count > 0)
                {
                    // Si no hay combinaciones seleccionadas, limpiar todos los registros con este precio
                    string query = $@"
                        UPDATE Pack_PricePerSize 
                        SET id_price = NULL, userUpdate = '{User.GetUserName()}', d_update = CAST(GETDATE() AS DATE)
                        WHERE id_price = '{idPrice}'";

                    SqlCommand cmd = new SqlCommand(query, sql.cnn);
                    cmd.ExecuteNonQuery();

                    isModifyUpdate = true;
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
        public void InsertSizeColumnsInModifyLeftDgv()
        {

        }
        public void MoveLeftToRightGtinAndSize()
        {

        }
        public int CopySelectedRowToTarget(DataGridView dgvSource, DataGridView dgvTarget)
        {
            if (dgvSource == null || dgvTarget == null)
                return -1;

            if (dgvSource.SelectedRows.Count <= 0)
                return -1;

            if (dgvTarget.DataSource is not DataTable dtTarget)
                return -1;

            DataGridViewRow selectedRow = dgvSource.SelectedRows[0];

            if (selectedRow.DataBoundItem is not DataRowView drv)
                return -1;

            DataRow sourceRow = drv.Row;

            // Crear nueva fila en el destino
            DataRow newRow = dtTarget.NewRow();

            // Copiar por nombre de columna, ignorando las que no existan
            foreach (DataColumn dc in dtTarget.Columns)
            {
                if (sourceRow.Table.Columns.Contains(dc.ColumnName))
                {
                    newRow[dc.ColumnName] = sourceRow[dc.ColumnName];
                }
            }

            dtTarget.Rows.Add(newRow);

            int insertedRowIndex = dtTarget.Rows.Count - 1;

            // Posicionar CurrentCell en la primera columna visible
            if (dgvTarget.Rows.Count > insertedRowIndex)
            {
                DataGridViewCell? visibleCell = null;

                foreach (DataGridViewColumn column in dgvTarget.Columns)
                {
                    if (column.Visible &&
                        column.Index < dgvTarget.Rows[insertedRowIndex].Cells.Count)
                    {
                        visibleCell = dgvTarget.Rows[insertedRowIndex].Cells[column.Index];
                        break;
                    }
                }

                if (visibleCell != null)
                {
                    dgvTarget.CurrentCell = visibleCell;
                }
            }

            return insertedRowIndex;
        }
        public bool RemoveSelectedRow(DataGridView dgvSource)
        {
            if (dgvSource == null)
                return false;

            if (dgvSource.SelectedRows.Count <= 0)
                return false;

            if (dgvSource.DataSource is not DataTable dtSource)
                return false;

            DataGridViewRow selectedRow = dgvSource.SelectedRows[0];

            if (selectedRow.DataBoundItem is not DataRowView drv)
                return false;

            DataRow sourceRow = drv.Row;

            for (int i = dtSource.Rows.Count - 1; i >= 0; i--)
            {
                if (dtSource.Rows[i] == sourceRow)
                {
                    dtSource.Rows.RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

        public void InsertSizeInNewRowRight(int indexNewRowRight)
        {
            string idSize = string.Empty;
            string valueSize = string.Empty;

            if (!_frmAdd.cboSize.TryGetValue(out string id))
                return;

            idSize = id;
            valueSize = _frmAdd.cboSize.GetColumnValue(ClsObject.Size.ColumnName)?.ToString() ?? string.Empty;

            DataGridView dgv = _frmAdd.dgvPricesRight;

            // Verificar que el índice exista
            if (indexNewRowRight < 0 || indexNewRowRight >= dgv.Rows.Count)
                return;

            DataGridViewRow row = dgv.Rows[indexNewRowRight];

            // Asignar valores si las columnas existen
            if (dgv.Columns.Contains(ClsObject.Size.ColumnId))
                row.Cells[ClsObject.Size.ColumnId].Value = idSize;

            if (dgv.Columns.Contains(ClsObject.Size.ColumnName))
                row.Cells[ClsObject.Size.ColumnName].Value = valueSize;
        }
        public bool ValidateGtinAndSizeInRight(string idGtin, string idSize)
        {
            DataGridView dgv = _frmAdd.dgvPricesRight;

            if (dgv == null || dgv.Rows.Count == 0)
                return true;

            if (!dgv.Columns.Contains(ClsObject.Column.id))
                return true;

            if (!dgv.Columns.Contains(ClsObject.Size.ColumnId))
                return true;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow)
                    continue;

                string currentIdGtin = row.Cells[ClsObject.Column.id].Value?.ToString() ?? string.Empty;
                string currentIdSize = row.Cells[ClsObject.Size.ColumnId].Value?.ToString() ?? string.Empty;

                if (currentIdGtin == idGtin && currentIdSize == idSize)
                {
                    return false;
                }
            }

            return true;
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

        public void ModifyDgvGtinCatalog()
        {
            List<(string?, string?)> gtins = _frmAdd.lsPricesEndGtinOrSize.Concat(_frmAdd.lsPricesStartGtinOrSize).ToList(); //juntar las tablas por si acaso, son los mismos gtin
            gtins = gtins.DistinctBy(x => x.Item1).ToList(); //quitar duplicados por si acaso

            string query = GetQueryDgvGtinCatalog() + " WHERE gtn.id_GTIN IN (" + string.Join(", ", gtins.Select(x => $"'{x.Item1}'")) + ")"; //Solo primer valor de GTIN    

            DataTable dtGtins = ClsQuerysDB.GetDataTable(query);
            ClsDGVCatalog.Metods.ModifyIdRowInDGV(dtGtins, dtCatalogGtin, Column.id, null);
        }

        public void ModifyDgvGtinAndSizeCatalog()
        {
            List<(string?, string?)> gtinsAndSizes = _frmAdd.lsPricesEndGtinOrSize.Concat(_frmAdd.lsPricesStartGtinOrSize).ToList(); //juntar las tablas por si acaso, son los mismos gtin+size
            gtinsAndSizes = gtinsAndSizes.DistinctBy(x => (x.Item1, x.Item2)).ToList(); //quitar duplicados por si acaso

            string query = GetQueryDgvSizeCatalog() + " WHERE CONCAT(gtn.id_GTIN, pps.id_size) IN (" + string.Join(", ", gtinsAndSizes.Select(x => $"CONCAT('{x.Item1}', '{x.Item2}')")) + ")";

            DataTable dtGtinsAndSizes = ClsQuerysDB.GetDataTable(query);

            ClsDGVCatalog.Metods.ModifyIdRowInDGV_With2Ids(dtGtinsAndSizes, dtCatalogSize, Column.id, SizeInfo.ColumnId, null);
        }
    }
}