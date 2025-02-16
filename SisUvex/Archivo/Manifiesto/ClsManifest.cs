using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.DataGridViews;
using SisUvex.Catalogos.Metods.ComboBoxes;
using System.Data;
using System.Data.SqlClient;
using SisUvex.Catalogos.Metods;
using System.Windows.Forms;
using SisUvex.Catalogos.Metods.Querys;
using Microsoft.Identity.Client;
using iText.Kernel.Pdf.Canvas.Wmf;
using SisUvex.Catalogos.WorkGroup;

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

        public void BeginFormAdd()
        {
            //AddControlsToList(); //////////POR MIENTRAS NO porque no hay obligatorios

            CargarComboBoxes();

            if (_frmAdd.IsAddModify)
            {
                _frmAdd.cboActive.SelectedIndex = 1;
                _frmAdd.txbId.Text = GetIdNextManifest("E");
            }
            else
            {
                LoadControlsModify();
            }
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

            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboDistributor, _frmAdd.txbIdDistributor);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboConsignee, _frmAdd.txbIdConsignee);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboGrower, _frmAdd.txbIdGrower);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboAgencyUS, _frmAdd.txbIdAgencyUS);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboAgencyMX, _frmAdd.txbIdAgencyMX);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboCityCrossPoint, _frmAdd.txbIdCityCrossPoint);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboCityDestination, _frmAdd.txbIdCityDestination);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboTransportLine, _frmAdd.txbIdTransportLine);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboDriver, _frmAdd.txbIdDriver);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboTruck, _frmAdd.txbIdTruck);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboFreightContainer, _frmAdd.txbIdFreightContainer);

            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboDistributor, _frmAdd.chbRemovedDistributor);
            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboConsignee, _frmAdd.chbRemovedConsignee);
            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboGrower, _frmAdd.chbRemovedGrower);
            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboAgencyUS, _frmAdd.chbRemovedAgencyUS);
            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboAgencyMX, _frmAdd.chbRemovedAgencyMX);
            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboCityCrossPoint, _frmAdd.chbRemovedCityCrossPoint);
            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboCityDestination, _frmAdd.chbRemovedCityDestination);
            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboTransportLine, _frmAdd.chbRemovedTransportLine);
            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboDriver, _frmAdd.chbRemovedDriver);
            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboTruck, _frmAdd.chbRemovedTruck);
            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboFreightContainer, _frmAdd.chbRemovedFreightContainer);
        }

        public string GetIdNextManifest(string market)
        {
            string qry = $" SELECT '{market}' + FORMAT(COALESCE(MAX(CAST(RIGHT(id_manifest, 4) AS INT)) + 1, 1), '0000') AS 'Id' FROM Pack_Manifest WHERE id_manifest LIKE '{market}%' "; 

            return ClsQuerysDB.GetData(qry);
        }

        private void LoadControlsModify()
        {
            eManifest = new EManifest();

            eManifest.SetManifest(_frmAdd.idModify);

            _frmAdd.txbId.Text = eManifest.idManifest;
            //_frmAdd.cboSeason = eManifest.idSeason;
            _frmAdd.cboActive.SelectedIndex = eManifest.active;
            _frmAdd.cboMarket.Text = eManifest.idManifest.Substring(0, 1);
            _frmAdd.dtpDate.Value = eManifest.shipmentDate;
            _frmAdd.spnHour.Text = eManifest.shipmentHour;
            _frmAdd.txbIdDistributor.Text = eManifest.idDistributor;
            _frmAdd.txbIdConsignee.Text = eManifest.idConsignee;
            _frmAdd.txbIdGrower.Text = eManifest.idGrower;
            _frmAdd.txbIdAgencyUS.Text = eManifest.idUSAgencyTrade;
            _frmAdd.txbIdAgencyMX.Text = eManifest.idMXAgencyTrade;
            _frmAdd.txbIdCityCrossPoint.Text = eManifest.idCityCrossPoint;
            _frmAdd.txbIdCityDestination.Text = eManifest.idCityDestiny;
            _frmAdd.txbPurchaseOrder.Text = eManifest.purchaseOrder;
            _frmAdd.txbBooking.Text = eManifest.booking;
            _frmAdd.txbPhytosanitary.Text = eManifest.phytosanitary;
            _frmAdd.txbIdTransportLine.Text = eManifest.idTransportLine;
            _frmAdd.txbIdDriver.Text = eManifest.idDriver;
            _frmAdd.txbIdTruck.Text = eManifest.idTruck;
            _frmAdd.txbIdFreightContainer.Text = eManifest.idFreightContainer;
            _frmAdd.cboTransportVehicle.Text = eManifest.transportVehicle;
            _frmAdd.cboTransportType.Text = eManifest.transportType;
            _frmAdd.txbTermograph.Text = eManifest.termograph;
            _frmAdd.txbTermoPosition.Text = eManifest.termoPosition.ToString();
            _frmAdd.txbTemperature.Text = eManifest.temperature.ToString();
            _frmAdd.cboTemperatureUnit.Text = eManifest.temperatureUnit;
            _frmAdd.txbSeal1.Text = eManifest.seal1;
            _frmAdd.txbSeal2.Text = eManifest.seal2;
            _frmAdd.txbSeal3.Text = eManifest.seal3;
            _frmAdd.txbDieselInvoice.Text = eManifest.dieselInvoice;
            _frmAdd.txbDieselLiters.Text = eManifest.dieselLts.ToString();
            _frmAdd.txbNameShipper.Text = eManifest.nameShipper;
            _frmAdd.txbNameOperator.Text = eManifest.nameOperator;
            _frmAdd.chbRejected.Checked = eManifest.rejected == "1";

            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboSeason, eManifest.idSeason);

            //ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboContractor, _frmAdd.txbIdContractor);
            //ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboSeason, _frmAdd.txbIdSeason);
        }
    }
}
