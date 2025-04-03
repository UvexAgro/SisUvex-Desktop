using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.DataGridViews;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.Querys;

namespace SisUvex.Material.MaterialRegister.Entry
{
    internal class ClsMaterialRegisterEntry
    {
        SQLControl sql = new SQLControl();
        ClsControls? controlListEntry;
        ClsControls? controlListMaterial;
        DataTable? dtUnit;

        public FrmMaterialRegisterEntry _frmAdd;
        //public FrmWorkGroupCat _frmCat;
        //public EWorkGroup eWorkGroup;
        //public ClsDataGridViewCatalogs dgv = new ClsDataGridViewCatalogs();
        //private string queryCatalogo = "SELECT * FROM vw_PackWorkGroupCat";
        //public DataTable dtCatalogo;
        //public DataTable dtCatalogoActivos;


        public void BeginFormAdd()
        {
            AddControlsToListEntry();
            LoadComboBoxes();
            //if (_frmAdd.IsAddModify)
            //{
            //    _frmAdd.chbActive.Checked = true;
            //    _frmAdd.txbId.Text = ClsQuerysDB.GetData("SELECT FORMAT(COALESCE(MAX(id_workGroup), 0) +1, '00') FROM Pack_WorkGroup").ToString();
            //}
            //else
            //{
            //    LoadControlsModify();
            //}
        }
        private void AddControlsToListEntry()
        {
            controlListEntry = new ClsControls();
            controlListEntry.ChangeHeadMessage("Para registrar una entrada debe:\n");
            controlListEntry.Add(_frmAdd.txbId, "Ingresar un número de entrada.");
            controlListEntry.Add(_frmAdd.txbInvoice, "Ingresar un folio de entrada.");
            controlListEntry.Add(_frmAdd.txbIdTransportLine, "Seleccionar una línea de transporte.");
            controlListEntry.Add(_frmAdd.txbIdFreightContainer, "Seleccionar una caja.");
            controlListEntry.Add(_frmAdd.dgvMaterialList, "Agregar materiales al listado.");

            controlListMaterial = new ClsControls();
            controlListMaterial.ChangeHeadMessage("Para agregar un material al listado debe:\n");
            controlListMaterial.Add(_frmAdd.txbId, "Seleccionar un material.");
            controlListMaterial.Add(_frmAdd.txbInvoice, "Ingresar la cantidad.");
        }
        private void LoadComboBoxes()
        {
            dtUnit = ClsQuerysDB.GetDataTable(ClsObject.Unit.QueryCbo);

            //ALMACEN
            //PROVEEDOR
            ClsComboBoxes.CboLoadActives(_frmAdd.cboDistributor, ClsObject.Distributor.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboGrower, ClsObject.Grower.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboCategory, ClsObject.Category.Cbo);
            //MATERIAL
            ClsComboBoxes.CboLoadActives(_frmAdd.cboTransportLine, ClsObject.TransportLine.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboFreightContainer, ClsObject.FreightContainer.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboDriver, ClsObject.Driver.Cbo);


            //ALMACEN
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboDistributor, _frmAdd.txbIdDistributor);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboGrower, _frmAdd.txbIdGrower);

            List<Tuple<ComboBox, CheckBox?, string>> cboCategoryDepends = new List<Tuple<ComboBox, CheckBox?, string>>();
            cboCategoryDepends.Add(new Tuple<ComboBox, CheckBox?, string>(_frmAdd.cboMaterial, _frmAdd.chbMaterialRemoved, ClsObject.Category.ColumnId));
            ClsComboBoxes.CboApplyEventCboSelectedValueChangedWithCboDependensColumn(_frmAdd.cboCategory, cboCategoryDepends, _frmAdd.txbIdCategory);

            _frmAdd.cboMaterial.SelectedIndexChanged += (s, e) =>
            {
                _frmAdd.txbIdMaterial.Text = _frmAdd.cboMaterial.SelectedValue?.ToString();

                if (_frmAdd.cboMaterial.SelectedIndex >= 0)
                {
                    var selectedIdUnit = _frmAdd.cboMaterial.SelectedValue?.ToString();
                    var unitRow = dtUnit?.AsEnumerable().FirstOrDefault(row => row[0].ToString() == selectedIdUnit);
                    _frmAdd.txbUnit.Text = unitRow?[1].ToString() ?? string.Empty;
                }
                else
                {
                    _frmAdd.txbUnit.Text = string.Empty;
                }
            };

            List<Tuple<ComboBox, CheckBox?, string>> cboTransportLineDepends = new List<Tuple<ComboBox, CheckBox?, string>>();
            cboTransportLineDepends.Add(new Tuple<ComboBox, CheckBox?, string>(_frmAdd.cboDriver, _frmAdd.chbDriverRemoved, ClsObject.TransportLine.ColumnId));
            cboTransportLineDepends.Add(new Tuple<ComboBox, CheckBox?, string>(_frmAdd.cboFreightContainer, _frmAdd.chbFreightContainerRemoved, ClsObject.TransportLine.ColumnId));
            ClsComboBoxes.CboApplyEventCboSelectedValueChangedWithCboDependensColumn(_frmAdd.cboTransportLine, cboTransportLineDepends, _frmAdd.txbIdTransportLine);
        }
    }
}
