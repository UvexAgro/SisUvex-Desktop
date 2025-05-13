using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using static SisUvex.Catalogos.Metods.ClsObject;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.DataGridViews;
using SisUvex.Material.MaterialRegister.Entry;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.Querys;

namespace SisUvex.Material.MaterialRegister.Exit
{
    internal class ClsMaterialRegisterExit
    {
        ClsControls? controlListInbound;
        ClsControls? controlListMaterial;
        DataTable? dtUnit;
        private SingleImageManager? frontImageManager, backImageManager, downImageManager, upImageManager;
        private string? imagesPathCatalogFolder = string.Empty;
        public FrmMaterialRegisterExit _frmAdd;
        public FrmMaterialRegisterExitCat _frmCat;
        public EMaterialRegisterExit entity;
        private string queryCatalog = "SELECT cat.* FROM vw_PackMatInbondEntryCat AS cat ";
        private string queryCatalogExists = "WHERE EXISTS (SELECT 1 FROM Pack_MatInbound inb " +
                                          "JOIN Pack_MatInboundMaterials mat ON mat.id_matInbound = inb.id_matInbound " +
                                          "JOIN Pack_MaterialCatalog matC ON matC.id_matCatalog = mat.id_matCatalog " +
                                          "LEFT JOIN Pack_MaterialType matT ON matT.id_matType = matC.id_matType " +
                                          "WHERE inb.id_matInbound = cat.[Código] ";
        ClsDGVCatalog dgv;
        DataTable? dtCatalog, dtInboundMaterials, dtEmployees;
        public bool IsAddOrModify = true, IsAddUpdate = false, IsModifyUpdate = false;
        public string? idAddModify;
        private string employeeCboQuery = $" SELECT DISTINCT emp.id_employee AS [{Column.id}], CONCAT_WS(' ',emp.v_lastNamePat, emp.v_lastNameMat, emp.v_name) AS [{Column.name}] FROM Nom_Employees emp ";
        private string employeeCboQueryJoin = $" JOIN Pack_MatInbound mat ON mat.id_employee = emp.id_employee ";

        public void BeginFormCat()
        {
            _frmCat ??= new FrmMaterialRegisterExitCat();
            _frmCat.cls ??= this;

            //dtCatalog = SearchFilter();
            dgv = new ClsDGVCatalog(_frmCat.dgvCatalog, dtCatalog); //Para agregar las Filas

            LoadComboBoxesCatalog();
        }

        private void LoadComboBoxesCatalog()
        {
            //LoadSearchByCbo();

            ClsComboBoxes.CboLoadActives(_frmCat.cboDistributor, Distributor.Cbo);
            ClsComboBoxes.CboLoadActives(_frmCat.cboWareHouse, MaterialWarehouse.Cbo);
            ClsComboBoxes.CboLoadActives(_frmCat.cboTransportLine, TransportLine.Cbo);
            ClsComboBoxes.CboLoadActives(_frmCat.cboFreightContainer, FreightContainer.Cbo);
            ClsComboBoxes.CboLoadActives(_frmCat.cboGrower, Grower.Cbo);
            ClsComboBoxes.CboLoadAll(_frmCat.cboMaterialType, ClsObject.MaterialType.Cbo);
            ClsComboBoxes.CboLoadActives(_frmCat.cboProvider, ClsObject.MaterialProvider.Cbo);

            //Material/Tipo material
            List<Tuple<ComboBox, CheckBox?, string>> cboMaterialTypeDepends = new List<Tuple<ComboBox, CheckBox?, string>>();
            cboMaterialTypeDepends.Add(new Tuple<ComboBox, CheckBox?, string>(_frmCat.cboMaterial, _frmCat.chbMaterialRemoved, ClsObject.MaterialType.ColumnId));
            ClsComboBoxes.CboApplyEventCboSelectedValueChangedWithCboDependensColumn(_frmCat.cboMaterialType, cboMaterialTypeDepends, null);

            _frmCat.cboMaterialType.SelectedIndexChanged += (s, e) =>
            {
                if (_frmCat.cboMaterial.Items.Count == 0)
                    ClsComboBoxes.CboLoadActives(_frmCat.cboMaterial, ClsObject.MaterialCatalog.Cbo);

                ClsComboBoxes.Metod_CboSelectedValueChangedWithCboDependensColumn(_frmCat.cboMaterialType, cboMaterialTypeDepends);
            };

            //Línea de transporte/Caja
            List<Tuple<ComboBox, CheckBox?, string>> cboTransportLineDepends = new List<Tuple<ComboBox, CheckBox?, string>>();
            cboTransportLineDepends.Add(new Tuple<ComboBox, CheckBox?, string>(_frmCat.cboFreightContainer, _frmCat.chbFreightContainerRemoved, TransportLine.ColumnId));
            ClsComboBoxes.CboApplyEventCboSelectedValueChangedWithCboDependensColumn(_frmCat.cboTransportLine, cboTransportLineDepends, null);

            //CHECKBOXES
            ClsComboBoxes.CboApplyClickEvent(_frmCat.cboDistributor, _frmCat.chbDistributorRemoved);
            ClsComboBoxes.CboApplyClickEvent(_frmCat.cboWareHouse, _frmCat.chbWareHouseRemoved);
            ClsComboBoxes.CboApplyClickEvent(_frmCat.cboGrower, _frmCat.chbGrowerRemoved);
            ClsComboBoxes.CboApplyClickEvent(_frmCat.cboProvider, _frmCat.chbProviderRemoved);
            ClsComboBoxes.CboApplyClickEvent(_frmCat.cboTransportLine, _frmCat.chbTransportLineRemoved);
            ClsComboBoxes.CboApplyChbClickEventWithCboDependensColumn(_frmCat.cboFreightContainer, _frmCat.chbFreightContainerRemoved, TransportLine.ColumnId, _frmCat.cboTransportLine);
            ClsComboBoxes.CboApplyChbClickEventWithCboDependensColumn(_frmCat.cboMaterial, _frmCat.chbMaterialRemoved, ClsObject.MaterialType.ColumnId, _frmCat.cboMaterialType);
        }

        public void BeginFormAdd()
        {
            AddControlsToListExit();
            //LoadControlsAddModify();
            //InitializeDtInboundMaterials();

            if (IsAddOrModify)
            {
                //_frmAdd.chbActive.Checked = true; //NO LLEVA
                _frmAdd.txbId.Text = ClsQuerysDB.GetData("SELECT FORMAT(COALESCE(MAX(id_matInbound), 0) +1, '000000000000000') AS [Id] FROM Pack_MatInbound").ToString();
            }
            else
            {
                //LoadControlsModify();
            }
        }

        private void AddControlsToListExit()
        {
            controlListInbound = new ClsControls();
            controlListInbound.ChangeHeadMessage("Para registrar una salida debe:\n");
            controlListInbound.Add(_frmAdd.txbId, "Seleccionar un tipo de salida.");
            controlListInbound.Add(_frmAdd.txbIdWarehouse, "Seleccionar un almacén de salida.");
            controlListInbound.Add(_frmAdd.txbIdWarehouse, "Ingresar dirección de destino.");
            controlListInbound.Add(_frmAdd.txbIdTransportLine, "Seleccionar una línea de transporte.");
            controlListInbound.Add(_frmAdd.txbIdFreightContainer, "Seleccionar una caja.");
            controlListInbound.Add(_frmAdd.dgvMaterialList, "Agregar materiales al listado.");

            controlListMaterial = new ClsControls();
            controlListMaterial.ChangeHeadMessage("Para agregar un material al listado debe:\n");
            controlListMaterial.Add(_frmAdd.txbInvoice, "Introducir folio/remisión/factura.");
            controlListMaterial.Add(_frmAdd.txbIdMaterial, "Seleccionar un material.");
            controlListMaterial.Add(_frmAdd.txbQuant, "Ingresar la cantidad.");
            controlListMaterial.Add(_frmAdd.txbUSD, "Ser un núméro válido");
            controlListMaterial.Add(_frmAdd.txbMXN, "Ser un núméro válido");
        }
    }
}
