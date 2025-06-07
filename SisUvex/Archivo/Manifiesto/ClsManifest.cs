using SisUvex.Catalogos.Metods.DataGridViews;
using SisUvex.Catalogos.Metods.ComboBoxes;
using System.Data;
using System.Data.SqlClient;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Catalogos.Metods.Values;
using System.Media;
using Microsoft.IdentityModel.Tokens;
using SisUvex.Catalogos.Metods.TextBoxes;
using SisUvex.Archivo.Manifiesto.ConfManifest;
using SisUvex.Catalogos.Distribuidor;
using SisUvex.Catalogos.Productor;
using SisUvex.Catalogos.Metods.Extentions;
using System.Web;
using SisUvex.Catalogos.Metods.Controls;

namespace SisUvex.Archivo.Manifiesto
{
    internal class ClsManifest
    {
        SQLControl sql = new SQLControl();
        ClsControls controlList;
        public FrmManifestAdd _frmAdd;
        public FrmManifestCat _frmCat;
        public EManifest eManifest;
        public ClsDataGridViewCatalogs dgv = new ClsDataGridViewCatalogs();
        ClsManifestPalletList clsPallets = new ClsManifestPalletList();

        private string queryCatalogo = $" SELECT vw.Activo, vw.Manifiesto, vw.Fecha, vw.Hora, vw.Distribuidor, vw.Consignatario, vw.Productor, vw.[Agencia nacional], vw.[Agencia extranjera], CONCAT(vw.[Ciudad destino],' ',vw.[ctDe Estado]) AS [Ciudad destino], CONCAT(vw.[Ciudad cruce],' ',vw.[ctCrv Estado]) AS [Ciudad cruce], vw.Orden, vw.Booking, vw.Fitosanitario, vw.[Linea de transporte], vw.[tru Num eco] AS 'Troque', vw.[tru Placas US] AS 'Placas US', vw.[tru Placas MX] AS 'Placas MX', vw.[fco Num eco] AS 'Caja', vw.[fco Placas US] AS 'Placas US', vw.[fco Placas MX] AS 'Placas MX', vw.Conductor, vw.Embarcador FROM vw_PackManifestAllDetails vw ";
        private string queryCatalogOrderBy = " ORDER BY Manifiesto Desc ";
        public DataTable dtCatalogo;
        public DataTable dtCatalogoActivos;

        public void BeginFormCat()
        {
            dgv.idColumn = "Manifiesto";
            dgv.activeColumn = "Activo";
            dgv.dgvCatalog = _frmCat.dgvCatalog;
            dgv.btnRemoved = _frmCat.btnRemoved;

            SetDgvCatalog();

            ClsDataGridViewCatalogs.DgvApplyCellFormattingEvent(_frmCat.dgvCatalog);

            ClsComboBoxes.CboLoadActives(_frmCat.cboDistributor, ClsObject.Distributor.Cbo);
            ClsComboBoxes.CboLoadActives(_frmCat.cboGrower, ClsObject.Grower.Cbo);
            ClsComboBoxes.CboLoadActives(_frmCat.cboDestination, ClsObject.City.Cbo);/////
            ClsComboBoxes.CboLoadActives(_frmCat.cboConsignee, ClsObject.Consignee.Cbo);/////
        }

        public void SetDgvCatalog()
        {
            dgv.queryCatalog = SetStringQueryWithFilter();
            dgv.LoadDataTableCatalog();
            _frmCat.dgvCatalog.DataSource = dgv.GetDataTableCatalogActives();
        }

        private string SetStringQueryWithFilter()
        {
            string qry = queryCatalogo + $" WHERE vw.Fecha BETWEEN '{_frmCat.dtpDate1.Value.ToString("yyyy-MM-dd")}' AND '{_frmCat.dtpDate2.Value.ToString("yyyy-MM-dd")}' ";

            if (_frmCat.cboDistributor.SelectedIndex > 0)
            {
                qry += $" AND vw.idDis = '{_frmCat.cboDistributor.SelectedValue}' ";
            }

            if (_frmCat.cboGrower.SelectedIndex > 0)
            {
                qry += $" AND vw.idGro = '{_frmCat.cboGrower.SelectedValue}' ";
            }

            if (_frmCat.cboConsignee.SelectedIndex > 0)
            {
                qry += $" AND vw.idCons = '{_frmCat.cboConsignee.SelectedValue}' ";
            }

            if (_frmCat.cboDestination.SelectedIndex > 0)
            {
                qry += $" AND vw.idCitDE = '{_frmCat.cboDestination.SelectedValue}' ";
            }

            return qry + " OR Fecha IS NULL " + queryCatalogOrderBy;
        }

        public void btnSearchManifest(string idManifest)
        {
            string qry;

            if (int.TryParse(idManifest, out int manifestId))
            {
                idManifest = manifestId.ToString("D4");

                qry = queryCatalogo + $" WHERE vw.Manifiesto = 'E{idManifest}' OR vw.Manifiesto = 'N{idManifest}' ";
            }
            else
            {
                qry = queryCatalogo + $" WHERE vw.Manifiesto = '{idManifest}' ";
            }

            _frmCat.dgvCatalog.DataSource = ClsQuerysDB.GetDataTable(qry);
        }

        public void btnShowRemoved()
        {
            dgv.UpdateCatalogButtonActivesDeletes();
        }

        public void btnRemoveProcedure()
        {
            dgv.ProcedureRemove("sp_PackManifestRemove");
        }

        public void btnRecoverProcedure()
        {
            dgv.ProcedureRecover("sp_PackManifestRecover");
        }

        public void OpenFrmAdd()
        {
            _frmAdd = new FrmManifestAdd();
            _frmAdd.cls = this;
            _frmAdd.Text = "Añadir manifiesto";
            _frmAdd.lblTitle.Text = "Añadir manifiesto";
            _frmAdd.IsAddModify = true;

            _frmAdd.ShowDialog();

            dgv.UpdateCatalogAfterAddModify(_frmAdd.AddIsUpdate);
        }

        public void OpenFrmModify()
        {
            if (_frmCat.dgvCatalog.SelectedRows.Count != 0)
            {
                _frmAdd = new FrmManifestAdd();
                _frmAdd.Text = "Modificar manifiesto";
                _frmAdd.lblTitle.Text = "Modificar manifiesto";
                _frmAdd.IsAddModify = false;

                _frmAdd.idModify = _frmCat.dgvCatalog.SelectedRows[0].Cells["Manifiesto"].Value.ToString();
                _frmAdd.ShowDialog();

                dgv.UpdateCatalogAfterAddModify(_frmAdd.AddIsUpdate);
            }
            else
            {
                SystemSounds.Exclamation.Play();
            }
        }

        public void BeginFormAdd()
        {
            clsPallets.dataGridView = _frmAdd.dgvPalletList;
            clsPallets.AddColumnsToDGVPalletList();
            AddControlsToList(); //////////POR MIENTRAS NO porque no hay obligatorios

            CargarComboBoxes();

            if (_frmAdd.IsAddModify)
            {
                ClsConfigManifest clsConfManifest = new ClsConfigManifest();
                clsConfManifest.GetParameters();
                _frmAdd.txbTemperature.Text = clsConfManifest.temperature.ToString();
                _frmAdd.cboTemperatureUnit.Text = clsConfManifest.temperatureUnit;
                _frmAdd.cboTransportVehicle.Text = clsConfManifest.transportVehicle;
                _frmAdd.cboTransportType.Text = clsConfManifest.transportTransportType;

                _frmAdd.txbIdSeason.Text = clsConfManifest.idSeason;
                ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboSeason, clsConfManifest.idSeason);

                _frmAdd.cboActive.SelectedIndex = 1;

                _frmAdd.spnHour.Text = DateTime.Now.AddMinutes((15 - DateTime.Now.Minute % 15) % 15).ToString("HH:mm");

                _frmAdd.cboMarket.SelectedIndexChanged += (sender, e) =>
                {
                    if (_frmAdd.cboMarket.SelectedIndex > 0)
                    {
                        string prefixMarket = (string)_frmAdd.cboMarket.GetColumnValue(ClsObject.Market.ColumnPrefix); ;
                        _frmAdd.txbId.Text = GetIdNextManifest(prefixMarket);
                    }
                    else
                        _frmAdd.txbId.Text = string.Empty;
                };

                ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboMarket, clsConfManifest.idMarket);

            }
            else
            {
                _frmAdd.cboMarket.Enabled = false;

                LoadControlsModify();
            }

            _frmAdd.txbPalletPosition.Text = clsPallets.GetNextPalletPosition().ToString();
        }
        private void AddControlsToList()
        {
            controlList = new();

            controlList.ChangeHeadMessage("Para registrar un manifiesto debe:\n");
            controlList.Add(_frmAdd.txbId, "Ingresar el código del manifiesto.");
            controlList.Add(_frmAdd.txbIdMarket, "Seleccionar el mercado.");
        }
        private void CargarComboBoxes()
        {
            ClsComboBoxes.CboLoadActives(_frmAdd.cboDistributor, ClsObject.Distributor.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboConsignee, ClsObject.Consignee.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboGrower, ClsObject.Grower.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboAgencyMX, ClsObject.AgencyTradeMX.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboAgencyUS, ClsObject.AgencyTradeUS.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboCityCrossPoint, ClsObject.City.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboCityDestination, ClsObject.City.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboTransportLine, ClsObject.TransportLine.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboDriver, ClsObject.Driver.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboTruck, ClsObject.Truck.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboFreightContainer, ClsObject.FreightContainer.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboSeason, ClsObject.Season.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboTemplate, ClsObject.ManifestTemplate.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboMarket, ClsObject.Market.Cbo);

            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboDistributor, _frmAdd.txbIdDistributor);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboConsignee, _frmAdd.txbIdConsignee);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboGrower, _frmAdd.txbIdGrower);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboAgencyUS, _frmAdd.txbIdAgencyUS);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboAgencyMX, _frmAdd.txbIdAgencyMX);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboCityCrossPoint, _frmAdd.txbIdCityCrossPoint);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboCityDestination, _frmAdd.txbIdCityDestination);
            //ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboTransportLine, _frmAdd.txbIdTransportLine);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboDriver, _frmAdd.txbIdDriver);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboTruck, _frmAdd.txbIdTruck);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboFreightContainer, _frmAdd.txbIdFreightContainer);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboSeason, _frmAdd.txbIdSeason);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboTemplate, _frmAdd.txbIdTemplate);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboMarket, _frmAdd.txbIdMarket);

            // Diccionario para asignar columnas del DataTable del cmbPrincipal a cada ComboBox secundario
            Dictionary<ComboBox, string> columnasRelacionadas = new Dictionary<ComboBox, string>
            {
                { _frmAdd.cboDistributor, ClsObject.Distributor.ColumnId },
                { _frmAdd.cboConsignee, ClsObject.Consignee.ColumnId },
                { _frmAdd.cboGrower, ClsObject.Grower.ColumnId },
                { _frmAdd.cboAgencyUS, ClsObject.AgencyTradeUS.ColumnId },
                { _frmAdd.cboAgencyMX, ClsObject.AgencyTradeMX.ColumnId },
                { _frmAdd.cboCityCrossPoint, ClsObject.City.ColumnIdCrossPoint },
                { _frmAdd.cboCityDestination, ClsObject.City.ColumnIdDestiny }
            };
            ClsComboBoxes.CboApplyEventCboSelectedValueChangedWithCboDependensColumnTemplates(_frmAdd.cboTemplate, columnasRelacionadas, _frmAdd.txbIdTemplate);

            List<Tuple<ComboBox, CheckBox?, string>> cboTransportLineDepends = new List<Tuple<ComboBox, CheckBox?, string>>();
            cboTransportLineDepends.Add(new Tuple<ComboBox, CheckBox?, string>(_frmAdd.cboDriver, _frmAdd.chbRemovedDriver, ClsObject.TransportLine.ColumnId));
            cboTransportLineDepends.Add(new Tuple<ComboBox, CheckBox?, string>(_frmAdd.cboTruck, _frmAdd.chbRemovedTruck, ClsObject.TransportLine.ColumnId));
            cboTransportLineDepends.Add(new Tuple<ComboBox, CheckBox?, string>(_frmAdd.cboFreightContainer, _frmAdd.chbRemovedFreightContainer, ClsObject.TransportLine.ColumnId));

            ClsComboBoxes.CboApplyEventCboSelectedValueChangedWithCboDependensColumn(_frmAdd.cboTransportLine, cboTransportLineDepends, _frmAdd.txbIdTransportLine);

            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboDistributor, _frmAdd.chbRemovedDistributor);
            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboConsignee, _frmAdd.chbRemovedConsignee);
            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboGrower, _frmAdd.chbRemovedGrower);
            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboAgencyUS, _frmAdd.chbRemovedAgencyUS);
            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboAgencyMX, _frmAdd.chbRemovedAgencyMX);
            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboCityCrossPoint, _frmAdd.chbRemovedCityCrossPoint);
            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboCityDestination, _frmAdd.chbRemovedCityDestination);
            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboTransportLine, _frmAdd.chbRemovedTransportLine);
            //ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboDriver, _frmAdd.chbRemovedDriver);
            //ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboTruck, _frmAdd.chbRemovedTruck);
            //ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboFreightContainer, _frmAdd.chbRemovedFreightContainer);
            ClsComboBoxes.CboApplyChbClickEventWithCboDependensColumn(_frmAdd.cboDriver, _frmAdd.chbRemovedDriver, ClsObject.TransportLine.ColumnId, _frmAdd.txbIdTransportLine);
            ClsComboBoxes.CboApplyChbClickEventWithCboDependensColumn(_frmAdd.cboTruck, _frmAdd.chbRemovedTruck, ClsObject.TransportLine.ColumnId, _frmAdd.txbIdTransportLine);
            ClsComboBoxes.CboApplyChbClickEventWithCboDependensColumn(_frmAdd.cboFreightContainer, _frmAdd.chbRemovedFreightContainer, ClsObject.TransportLine.ColumnId, _frmAdd.txbIdTransportLine);

            ClsTextBoxes.TxbApplyKeyPressEventNumericWithLimit(_frmAdd.txbDieselLiters, 9, 2);
            ClsTextBoxes.TxbApplyKeyPressEventInt(_frmAdd.txbTermoPosition);
            ClsTextBoxes.TxbApplyKeyPressEventInt(_frmAdd.txbTemperature);
        }

        public string GetIdNextManifest(string? market)
        {
            if (string.IsNullOrWhiteSpace(market))
                return string.Empty;

            string qry = $" SELECT '{market}' + FORMAT(COALESCE(MAX(CAST(RIGHT(id_manifest, 4) AS INT)) + 1, 1), '0000') AS 'Id' FROM Pack_Manifest WHERE id_manifest LIKE '{market}%' "; 

            return ClsQuerysDB.GetData(qry);
        }

        private void LoadControlsModify()
        {
            eManifest = new EManifest();

            eManifest.SetManifest(_frmAdd.idModify);

            _frmAdd.txbId.Text = eManifest.idManifest;
            _frmAdd.cboActive.SelectedIndex = eManifest.active ?? 1;
            _frmAdd.dtpDate.Value = eManifest.shipmentDate ?? DateTime.Now;
            _frmAdd.spnHour.Text = eManifest.shipmentHour;
            _frmAdd.txbPurchaseOrder.Text = eManifest.purchaseOrder;
            _frmAdd.txbBooking.Text = eManifest.booking;
            _frmAdd.txbPhytosanitary.Text = eManifest.phytosanitary;
            _frmAdd.cboTransportVehicle.Text = eManifest.transportVehicle;
            _frmAdd.cboTransportType.Text = eManifest.transportType;
            _frmAdd.txbTermograph.Text = eManifest.termograph;
            _frmAdd.txbTermoPosition.Text = eManifest.termoPosition;
            _frmAdd.txbTemperature.Text = eManifest.temperature;
            _frmAdd.cboTemperatureUnit.Text = eManifest.temperatureUnit;
            _frmAdd.txbSeal1.Text = eManifest.seal1;
            _frmAdd.txbSeal2.Text = eManifest.seal2;
            _frmAdd.txbSeal3.Text = eManifest.seal3;
            _frmAdd.txbDieselInvoice.Text = eManifest.dieselInvoice;
            _frmAdd.txbDieselLiters.Text = eManifest.dieselLts;
            _frmAdd.txbNameShipper.Text = eManifest.nameShipper;
            _frmAdd.txbNameOperator.Text = eManifest.nameOperator;
            _frmAdd.chbRejected.Checked = eManifest.rejected == "1";
            _frmAdd.txbObservations.Text = eManifest.observations;

            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboSeason, eManifest.idSeason);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboDistributor, eManifest.idDistributor);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboConsignee, eManifest.idConsignee);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboGrower, eManifest.idGrower);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboAgencyUS, eManifest.idUSAgencyTrade);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboAgencyMX, eManifest.idMXAgencyTrade);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboCityCrossPoint, eManifest.idCityCrossPoint);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboCityDestination, eManifest.idCityDestiny);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboTransportLine, eManifest.idTransportLine);
            ClsComboBoxes.CboSelectIndexWithTextInValueMemberKeepingFilter(_frmAdd.cboDriver, eManifest.idDriver);
            ClsComboBoxes.CboSelectIndexWithTextInValueMemberKeepingFilter(_frmAdd.cboTruck, eManifest.idTruck);
            ClsComboBoxes.CboSelectIndexWithTextInValueMemberKeepingFilter(_frmAdd.cboFreightContainer, eManifest.idFreightContainer);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboMarket, eManifest.idMarket);

            clsPallets.AddManifestPalletsToDGVPalletList(eManifest.idManifest);
        }

        public void BtnAddPallet()
        {
            if(!int.TryParse(_frmAdd.txbPalletPosition.Text, out int position))
            {
                System.Media.SystemSounds.Beep.Play();
                return;
            }
            else if (position == 0)
            {
                position = clsPallets.GetNextPalletPosition();
            }

            bool isPalletAdd = clsPallets.AddPalletToDGVPalletList(ClsValues.FormatZeros(_frmAdd.txbIdPallet.Text,"00000"), position);

            if (isPalletAdd)
            {
                _frmAdd.txbPalletPosition.Text = clsPallets.GetNextPalletPosition().ToString();
            }

            _frmAdd.txbIdPallet.Focus();
            _frmAdd.txbIdPallet.SelectAll();
        }

        public void BtnRemovePallet()
        {
            clsPallets.RemovePalletFromDGVPalletList();

            _frmAdd.txbPalletPosition.Text = clsPallets.GetNextPalletPosition().ToString();
        }

        public void BtnMovePalletUp()
        {
            clsPallets.MoveUpSelectedPalletPosition();

            _frmAdd.dgvPalletList.Sort(_frmAdd.dgvPalletList.Columns["Posicion"], System.ComponentModel.ListSortDirection.Ascending);

            _frmAdd.txbPalletPosition.Text = clsPallets.GetNextPalletPosition().ToString();
        }

        public void BtnMovePalletDown()
        {
            clsPallets.MoveDownSelectedPalletPosition();

            _frmAdd.dgvPalletList.Sort(_frmAdd.dgvPalletList.Columns["Posicion"], System.ComponentModel.ListSortDirection.Ascending);

            _frmAdd.txbPalletPosition.Text = clsPallets.GetNextPalletPosition().ToString();
        }

        public void btnAcceptAddModify()
        {
            if (!controlList.ValidateControls())
                return;

            if (_frmAdd.IsAddModify)
                AddProcedures();
            else
                ModifyProcedures();

            //if (_frmAdd.AddIsUpdate)
            //    _frmAdd.Close();

            _frmAdd.cboMarket.Enabled = false;
        }

        public void AddProcedures()
        {
            try
            {
                sql.BeginTransaction();

                string? idManifest = AddDetailsToNewManifest();

                if (idManifest.IsNullOrEmpty())
                    throw new Exception("No se pudo agregar el manifiesto");

                AddPalletsToManifestPart(idManifest);

                sql.CommitTransaction();

                _frmAdd.txbId.Text = idManifest;

                MessageBox.Show("Se agregó el manifiesto: " + idManifest, "Catálogo añadir", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _frmAdd.AddIsUpdate = true;

                _frmAdd.IsAddModify = false;
            }
            catch (Exception ex)
            {
                sql.RollbackTransaction();
                MessageBox.Show(ex.ToString(), "Catálogo añadir");
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }

        public void ModifyProcedures()
        {
            try
            {
                sql.BeginTransaction();

                ModifyDetailsToManifest();

                RemovePalletsForManifest(_frmAdd.txbId.Text);

                AddPalletsToManifestPart(_frmAdd.txbId.Text);

                sql.CommitTransaction();

                MessageBox.Show("Se modificó el manifiesto: " + _frmAdd.txbId.Text, "Catálogo añadir", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _frmAdd.AddIsUpdate = true;
            }
            catch (Exception ex)
            {
                sql.RollbackTransaction();
                MessageBox.Show(ex.ToString(), "Catálogo añadir");
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }

        private string AddDetailsToNewManifest()
        {
            SqlCommand cmd = new ("sp_PackManifestAdd", sql.cnn, sql.transaction);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@active", _frmAdd.cboActive.SelectedIndex);
            cmd.Parameters.AddWithValue("@idMarket", ClsValues.IfEmptyToDBNull(_frmAdd.txbIdMarket.Text));
            cmd.Parameters.AddWithValue("@idDistributor", ClsValues.IfEmptyToDBNull(_frmAdd.txbIdDistributor.Text));
            cmd.Parameters.AddWithValue("@idConsignee", ClsValues.IfEmptyToDBNull(_frmAdd.txbIdConsignee.Text));
            cmd.Parameters.AddWithValue("@idGrower", ClsValues.IfEmptyToDBNull(_frmAdd.txbIdGrower.Text));
            cmd.Parameters.AddWithValue("@idUSAgencyTrade", ClsValues.IfEmptyToDBNull(_frmAdd.txbIdAgencyUS.Text));
            cmd.Parameters.AddWithValue("@idMXAgencyTrade", ClsValues.IfEmptyToDBNull(_frmAdd.txbIdAgencyMX.Text));
            cmd.Parameters.AddWithValue("@idTransportLine", ClsValues.IfEmptyToDBNull(_frmAdd.txbIdTransportLine.Text));
            cmd.Parameters.AddWithValue("@idTruck", ClsValues.IfEmptyToDBNull(_frmAdd.txbIdTruck.Text));
            cmd.Parameters.AddWithValue("@idFreightContainer", ClsValues.IfEmptyToDBNull(_frmAdd.txbIdFreightContainer.Text));
            cmd.Parameters.AddWithValue("@idDriver", ClsValues.IfEmptyToDBNull(_frmAdd.txbIdDriver.Text));
            cmd.Parameters.AddWithValue("@idCityCrossPoint", ClsValues.IfEmptyToDBNull(_frmAdd.txbIdCityCrossPoint.Text));
            cmd.Parameters.AddWithValue("@idCityDestiny", ClsValues.IfEmptyToDBNull(_frmAdd.txbIdCityDestination.Text));
            cmd.Parameters.AddWithValue("@seal1", ClsValues.IfEmptyToDBNull(_frmAdd.txbSeal1.Text));
            cmd.Parameters.AddWithValue("@seal2", ClsValues.IfEmptyToDBNull(_frmAdd.txbSeal2.Text));
            cmd.Parameters.AddWithValue("@seal3", ClsValues.IfEmptyToDBNull(_frmAdd.txbSeal3.Text));
            cmd.Parameters.AddWithValue("@termograph", ClsValues.IfEmptyToDBNull(_frmAdd.txbTermograph.Text));
            cmd.Parameters.AddWithValue("@purchaseOrder", ClsValues.IfEmptyToDBNull(_frmAdd.txbPurchaseOrder.Text));
            cmd.Parameters.AddWithValue("@booking", ClsValues.IfEmptyToDBNull(_frmAdd.txbBooking.Text));
            cmd.Parameters.AddWithValue("@dShipment", _frmAdd.dtpDate.Value.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@cShipment", _frmAdd.spnHour.Text);
            cmd.Parameters.AddWithValue("@temperature", ClsValues.IfEmptyToDBNull(_frmAdd.txbTemperature.Text));
            cmd.Parameters.AddWithValue("@temperatureUnit", ClsValues.IfEmptyToDBNull(_frmAdd.cboTemperatureUnit.Text));
            cmd.Parameters.AddWithValue("@nameOperator", ClsValues.IfEmptyToDBNull(_frmAdd.txbNameOperator.Text));
            cmd.Parameters.AddWithValue("@nameShipper", ClsValues.IfEmptyToDBNull(_frmAdd.txbNameShipper.Text));
            cmd.Parameters.AddWithValue("@transportVehicle", ClsValues.IfEmptyToDBNull(_frmAdd.cboTransportVehicle.Text));
            cmd.Parameters.AddWithValue("@transportType", ClsValues.IfEmptyToDBNull(_frmAdd.cboTransportType.Text));
            cmd.Parameters.AddWithValue("@rejected", ClsValues.IfEmptyToDBNull(_frmAdd.chbRejected.Checked ? "1" : "0"));
            cmd.Parameters.AddWithValue("@observations", ClsValues.IfEmptyToDBNull(_frmAdd.txbObservations.Text));
            cmd.Parameters.AddWithValue("@termoPosition", ClsValues.IfEmptyToDBNull(_frmAdd.txbTermoPosition.Text));
            cmd.Parameters.AddWithValue("@dieselInvoice", ClsValues.IfEmptyToDBNull(_frmAdd.txbDieselInvoice.Text));
            cmd.Parameters.AddWithValue("@dieselLiters", ClsValues.IfEmptyToDBNull(_frmAdd.txbDieselLiters.Text));
            cmd.Parameters.AddWithValue("@phytosanitary", ClsValues.IfEmptyToDBNull(_frmAdd.txbPhytosanitary.Text));
            cmd.Parameters.AddWithValue("@idSeason", ClsValues.IfEmptyToDBNull(_frmAdd.txbIdSeason.Text));

            cmd.Parameters.AddWithValue("@userCreate", User.GetUserName());

            SqlDataReader dr = cmd.ExecuteReader();

            string idManifest = string.Empty;

            if (dr.Read())
            {
                idManifest = (string)dr["id_manifest"];

                dr.Close();
            }

            return idManifest;
        }

        public void ModifyDetailsToManifest()
        {
            SqlCommand cmd = new SqlCommand("sp_PackManifestModify", sql.cnn, sql.transaction);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@active", _frmAdd.cboActive.SelectedIndex);
            cmd.Parameters.AddWithValue("@idManifest", _frmAdd.txbId.Text);
            cmd.Parameters.AddWithValue("@idDistributor", ClsValues.IfEmptyToDBNull(_frmAdd.txbIdDistributor.Text));
            cmd.Parameters.AddWithValue("@idConsignee", ClsValues.IfEmptyToDBNull(_frmAdd.txbIdConsignee.Text));
            cmd.Parameters.AddWithValue("@idGrower", ClsValues.IfEmptyToDBNull(_frmAdd.txbIdGrower.Text));
            cmd.Parameters.AddWithValue("@idUSAgencyTrade", ClsValues.IfEmptyToDBNull(_frmAdd.txbIdAgencyUS.Text));
            cmd.Parameters.AddWithValue("@idMXAgencyTrade", ClsValues.IfEmptyToDBNull(_frmAdd.txbIdAgencyMX.Text));
            cmd.Parameters.AddWithValue("@idTransportLine", ClsValues.IfEmptyToDBNull(_frmAdd.txbIdTransportLine.Text));
            cmd.Parameters.AddWithValue("@idTruck", ClsValues.IfEmptyToDBNull(_frmAdd.txbIdTruck.Text));
            cmd.Parameters.AddWithValue("@idFreightContainer", ClsValues.IfEmptyToDBNull(_frmAdd.txbIdFreightContainer.Text));
            cmd.Parameters.AddWithValue("@idDriver", ClsValues.IfEmptyToDBNull(_frmAdd.txbIdDriver.Text));
            cmd.Parameters.AddWithValue("@idCityCrossPoint", ClsValues.IfEmptyToDBNull(_frmAdd.txbIdCityCrossPoint.Text));
            cmd.Parameters.AddWithValue("@idCityDestiny", ClsValues.IfEmptyToDBNull(_frmAdd.txbIdCityDestination.Text));
            cmd.Parameters.AddWithValue("@seal1", ClsValues.IfEmptyToDBNull(_frmAdd.txbSeal1.Text));
            cmd.Parameters.AddWithValue("@seal2", ClsValues.IfEmptyToDBNull(_frmAdd.txbSeal2.Text));
            cmd.Parameters.AddWithValue("@seal3", ClsValues.IfEmptyToDBNull(_frmAdd.txbSeal3.Text));
            cmd.Parameters.AddWithValue("@termograph", ClsValues.IfEmptyToDBNull(_frmAdd.txbTermograph.Text));
            cmd.Parameters.AddWithValue("@purchaseOrder", ClsValues.IfEmptyToDBNull(_frmAdd.txbPurchaseOrder.Text));
            cmd.Parameters.AddWithValue("@booking", ClsValues.IfEmptyToDBNull(_frmAdd.txbBooking.Text));
            cmd.Parameters.AddWithValue("@dShipment", _frmAdd.dtpDate.Value.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@cShipment", _frmAdd.spnHour.Text);
            cmd.Parameters.AddWithValue("@temperature", ClsValues.IfEmptyToDBNull(_frmAdd.txbTemperature.Text));
            cmd.Parameters.AddWithValue("@temperatureUnit", ClsValues.IfEmptyToDBNull(_frmAdd.cboTemperatureUnit.Text));
            cmd.Parameters.AddWithValue("@nameOperator", ClsValues.IfEmptyToDBNull(_frmAdd.txbNameOperator.Text));
            cmd.Parameters.AddWithValue("@nameShipper", ClsValues.IfEmptyToDBNull(_frmAdd.txbNameShipper.Text));
            cmd.Parameters.AddWithValue("@transportVehicle", ClsValues.IfEmptyToDBNull(_frmAdd.cboTransportVehicle.Text));
            cmd.Parameters.AddWithValue("@transportType", ClsValues.IfEmptyToDBNull(_frmAdd.cboTransportType.Text));
            cmd.Parameters.AddWithValue("@rejected", ClsValues.IfEmptyToDBNull(_frmAdd.chbRejected.Checked ? "1" : "0"));
            cmd.Parameters.AddWithValue("@observations", ClsValues.IfEmptyToDBNull(_frmAdd.txbObservations.Text));
            cmd.Parameters.AddWithValue("@termoPosition", ClsValues.IfEmptyToDBNull(_frmAdd.txbTermoPosition.Text));
            cmd.Parameters.AddWithValue("@dieselInvoice", ClsValues.IfEmptyToDBNull(_frmAdd.txbDieselInvoice.Text));
            cmd.Parameters.AddWithValue("@dieselLiters", ClsValues.IfEmptyToDBNull(_frmAdd.txbDieselLiters.Text));
            cmd.Parameters.AddWithValue("@phytosanitary", ClsValues.IfEmptyToDBNull(_frmAdd.txbPhytosanitary.Text));
            cmd.Parameters.AddWithValue("@idMarket", ClsValues.IfEmptyToDBNull(_frmAdd.txbIdMarket.Text));
            cmd.Parameters.AddWithValue("@idSeason", ClsValues.IfEmptyToDBNull(_frmAdd.txbIdSeason.Text));

            cmd.Parameters.AddWithValue("@userUpdate", User.GetUserName());

            cmd.ExecuteNonQuery();
        }

        private void AddPalletsToManifestPart(string idManifest)
        {
            foreach (DataGridViewRow row in _frmAdd.dgvPalletList.Rows)
            {
                SqlCommand cmd = new SqlCommand("sp_PackManifestAddPallet", sql.cnn, sql.transaction);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idManifest", idManifest);
                cmd.Parameters.AddWithValue("@idPallet", row.Cells["Pallet"].Value.ToString());
                cmd.Parameters.AddWithValue("@position", row.Cells["Posicion"].Value.ToString());
                cmd.Parameters.AddWithValue("@userUpdate", User.GetUserName());

                cmd.ExecuteNonQuery();
            }
        }

        public void RemovePalletsForManifest(string idManifest)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Pack_Pallet SET c_position = NULL, id_manifest = NULL, userUpdate = @userUpdate, d_update = CONVERT(DATE, SYSDATETIME()) WHERE id_manifest = @idManifest", sql.cnn, sql.transaction);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@idManifest", idManifest);
            cmd.Parameters.AddWithValue("@userUpdate", User.GetUserName());

            cmd.ExecuteNonQuery();
        }

        public void BtnPrintManifestFrmAdd()
        {
            PrintManifest(_frmAdd.txbId.Text);
        }

        public void BtnPrintManifestFrmCat()
        {
            if (_frmCat.dgvCatalog.Rows.Count > 0 && _frmCat.dgvCatalog.SelectedRows.Count != 0)
            {
                PrintManifest(_frmCat.dgvCatalog.SelectedRows[0].Cells["Manifiesto"].Value.ToString());
            }
            else
            {
                SystemSounds.Exclamation.Play();
            }
        }

        private void PrintManifest(string idManifest)
        {
            try
            {
                if (!idManifest.IsNullOrEmpty())
                {
                    bool isPrint = false;

                    ClsConfigManifest conf = new ClsConfigManifest();
                    conf.GetParameters();

                    if (conf.printManifest)
                    {
                        ClsPruebaManifiesto pdf = new ClsPruebaManifiesto();
                        pdf.desktopPath = conf.manifestFolderPath;
                        pdf.CreatePDFManifest(idManifest);

                        isPrint = true;
                    }


                    //if (conf.printManifest)
                    //{
                    //    ClsPDFManifiesto pdf = new ClsPDFManifiesto();
                    //    pdf.desktopPath = conf.manifestFolderPath;
                    //    pdf.CreatePDFManifest(idManifest);
                    //}

                    if (conf.printMaping)
                    {
                        ClsPDFLoadingMap pdfMap = new ClsPDFLoadingMap();
                        pdfMap.desktopPath = conf.manifestFolderPath;
                        pdfMap.CreatePDFMaping(idManifest);

                        isPrint = true;
                    }

                    //ClsPDFManifiesto pdf = new ClsPDFManifiesto();

                    if (conf.printPackingList)
                    {
                        ClsPDFPackingList pdfPacking = new ClsPDFPackingList();
                        pdfPacking.desktopPath = conf.manifestFolderPath;
                        pdfPacking.CreatePDFPackingList(idManifest);

                        isPrint = true;
                    }

                    if (isPrint)
                        OpenManifestFolderPath(idManifest);
                }
                else
                {
                    MessageBox.Show("Debe guardar el manifiesto antes de imprimirlo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void OpenManifestFolderPath(string idManifest)
        {
            string distributorShortName = ClsQuerysDB.GetData($"SELECT v_nameDistShort FROM Pack_Distributor WHERE id_distributor = (SELECT id_distributor FROM Pack_Manifest WHERE id_manifest = '{idManifest}')");

            string manifestFolderPath = Properties.Settings.Default.ManifestsFolderPath;

            string path = Path.Combine(manifestFolderPath, "Manifiestos", distributorShortName, $"{idManifest}");

            DialogResult result = MessageBox.Show($"Archivos guardados en: {path}\n\n¿Desea abrir la carpeta?",
                "Ruta de la carpeta", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start("explorer.exe", path);
            }
        }
    }
}
