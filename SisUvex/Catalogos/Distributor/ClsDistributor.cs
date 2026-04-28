using DocumentFormat.OpenXml.Presentation;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.DataGridViews;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SisUvex.Catalogos.Metods.ClsObject;

namespace SisUvex.Catalogos.Distributor
{
    internal class ClsDistributor
    {
        ClsControls controlList = null!;
        public FrmDistributorAdd _frmAdd = null!;
        public FrmDistributorCat _frmCat = null!;
        public EDistributor entity = null!;

        private readonly string queryCatalog = $" SELECT cat.* FROM vw_PackDistributorCat cat ";

        ClsDGVCatalog? dgv;
        DataTable dtCatalog = null!;

        public bool IsAddOrModify = true;
        public bool IsAddUpdate;
        public bool IsModifyUpdate;
        public string? idAddModify;
        private void AddControlsToList()
        {
            controlList = new ClsControls();

            controlList.ChangeHeadMessage("Para dar de alta un distribuidor debe:\n");
            controlList.Add(_frmAdd.txbId, "Ingresar el ID del distribuidor.");
            controlList.Add(_frmAdd.txbName, "Ingresar el nombre del distribuidor.");
            controlList.Add(_frmAdd.txbShortName, "Ingresar el nombre corto del distribuidor.");
            controlList.Add(_frmAdd.cboActive, "Seleccionar si el distribuidor está activo.");
        }

        private void LoadControls()
        {
            ClsComboBoxes.CboLoadActives(_frmAdd.cboAgencyUS, AgencyTradeUS.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboAgencyMX, AgencyTradeMX.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboGrower, Grower.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboCityCross, City.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboCityDestination, City.Cbo);

            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboAgencyUS, _frmAdd.chbAgencyUSRemoved);
            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboAgencyMX, _frmAdd.chbAgencyMXRemoved);
            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboGrower, _frmAdd.chbGrowerRemoved);
            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboCityCross, _frmAdd.chbCityCrossRemoved);
            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboCityDestination, _frmAdd.chbCityDestinationRemoved);
        }
        private void LoadControlsModify()
        {
            //AQUI LOS QUE DEBAN DE DISTRIBUTOR
            //entity = new();
            //entity.GetWorkGroup(idAddModify);

            //_frmAdd.txbId.Text = entity.IdWorkGroup ?? "";
            //_frmAdd.txbName.Text = entity.NameWorkGroup ?? "";
            //_frmAdd.txbIdContractor.Text = entity.IdContractor ?? "";
            //_frmAdd.txbIdSeason.Text = entity.IdSeason ?? "";
            //_frmAdd.cboActive.SelectedIndex = entity.Active;


            //PERO CARGAR LOS COMBOBOX ASI DISTRIBUTOR
            //ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboAgencyUS, entity.idAgencyUS);
            //Y ASI LOS DEMAS COMBOBOX
        }
    }
}
