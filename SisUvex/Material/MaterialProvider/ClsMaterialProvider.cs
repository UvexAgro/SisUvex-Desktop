using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.DataGridViews;
using SisUvex.Catalogos.WorkGroup;
using System.Data;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods;
using System.Media;
using static SisUvex.Catalogos.Metods.ClsObject;
using SisUvex.Catalogos.Metods.CheckBoxes;

namespace SisUvex.Material.MaterialProvider
{
    internal class ClsMaterialProvider
    {
        //----[NOTAS]-----
        //--ESTA CLASE SE HIZO PENSANDO EN PODERL ABRIR LOS FORMULARIOS DE AÑADIR Y MODIFICAR DESDE ALGUN BOTON, Y NO SOLO DESDE EL CATALOGO.
        //--POR EJEMPLO DESDE EL FORMULARIO DE ENTRADAS DE MATERIAL.
        //--LA EJECUCION DE LOS PROCEDIMIENTOS SE CAMBIO A LA CLASE DE LA ENTIDAD (EMaterialProvider)
        SQLControl sql = new SQLControl();
        ClsControls controlList;
        public FrmMaterialProviderAdd _frmAdd;
        public FrmMaterialProviderCat _frmCat;
        public EMaterialProvider eProvider;
        private string queryCatalogo = $" SELECT *, [Activo] AS [{Column.active + "2"}] FROM vw_PackWorkGroupCat ";
        ClsDGVCatalog dgv;
        bool AddIsUpdate = false;
        bool ModifyIsUpdate = false;

        public void BeginFormCat()
        {
            _frmCat ??= new FrmMaterialProviderCat();
            _frmCat.cls ??= this;

            _frmCat.dgvCatalog.DataSource = ClsQuerysDB.GetDataTable(queryCatalogo);
            dgv = new ClsDGVCatalog();
            dgv.dgvCatalog = _frmCat.dgvCatalog;
            dgv.LoadDGVCatalog_ActiveColumn2();
        }
        public void BeginFormAdd()
        {
            AddControlsToList();

            if (_frmAdd.IsAddModify)
            {
                _frmAdd.cboActive.SelectedIndex = 1;
                _frmAdd.txbId.Text = ClsQuerysDB.GetData("SELECT FORMAT(COALESCE(MAX([id_provider]), 0) +1, '00') FROM [Pack_Provider]").ToString();
            }
            else
            {
                LoadControlsModify();
            }
        }
        private void AddControlsToList()
        {
            controlList = new ClsControls();

            controlList.ChangeHeadMessage("Para dar de alta un proveedor debe:\n");
            controlList.Add(_frmAdd.txbId, "Ingresar el código del proveedor.");
            controlList.Add(_frmAdd.txbName, "Ingresar el nombre del proveedor.");
        }
        public void OpenFrmAdd()
        {
            _frmAdd = new FrmMaterialProviderAdd();
            _frmAdd.cls = this;
            _frmAdd.Text = "Añadir proveedor";
            _frmAdd.lblTitle.Text = "Añadir proveedor";
            _frmAdd.IsAddModify = true;

            _frmAdd.ShowDialog();

           // dgv.UpdateCatalogAfterAddModify(_frmAdd.AddIsUpdate);
        }
        public void OpenFrmModify()
        {
            
            _frmAdd = new FrmMaterialProviderAdd();
                _frmAdd.Text = "Modificar proveedor";
                _frmAdd.lblTitle.Text = "Modificar proveedor";
                _frmAdd.IsAddModify = false;

                _frmAdd.idModify = _frmCat.dgvCatalog.SelectedRows[0].Cells[ClsObject.Column.id].Value.ToString();

                _frmAdd.ShowDialog();

                //dgv.UpdateCatalogAfterAddModify(_frmAdd.AddIsUpdate);
        }

        private EMaterialProvider SetProviderEntity()
        {
            eProvider = new EMaterialProvider();
            eProvider.idProvider = _frmAdd.txbId.Text;
            eProvider.nameProvider = _frmAdd.txbName.Text;
            eProvider.city = _frmAdd.txbCity.Text;
            eProvider.phoneNumber = _frmAdd.txbPhoneNumber.Text;
            eProvider.email = _frmAdd.txbEmail.Text;
            eProvider.active = _frmAdd.cboActive.SelectedIndex;

            return eProvider;
        }
        private void LoadControlsModify()
        {
            eProvider = new EMaterialProvider();
            eProvider.GetProvider(_frmAdd.idModify ?? "0");

            _frmAdd.txbId.Text = eProvider.idProvider;
            _frmAdd.txbName.Text = eProvider.nameProvider;
            _frmAdd.txbCity.Text = eProvider.city;
            _frmAdd.txbPhoneNumber.Text = eProvider.city;
            _frmAdd.txbEmail.Text = eProvider.email;
            _frmAdd.cboActive.SelectedIndex = eProvider.active;
        }

        public void BtnAddProcedure()
        {
            EMaterialProvider addProvider = new();
            addProvider = SetProviderEntity();
            var result = addProvider.AddProcedure();
            bool procedureTrue = result.Item1;
            string? idProvider = result.Item2;

            if (procedureTrue)
            {
                AddIsUpdate = true;

                MessageBox.Show($"Se ha agregado el proveedor: {addProvider.nameProvider} con el código: {idProvider}", "Añadir proveedor");

                _frmAdd.Close();
            }
            else
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("No se pudo agregar el proveedor.", "Añadir proveedor");
            }
        }

        public void BtnModifyProcedure()
        {
            EMaterialProvider modifyProvider = new();
            modifyProvider = SetProviderEntity();
            var result = modifyProvider.ModifyProcedure();

            bool procedureTrue = result.Item1;
            string? idProvider = result.Item2;

            if (procedureTrue)
            {
                ModifyIsUpdate = true;
                MessageBox.Show($"Se ha modificado el proveedor: {modifyProvider.nameProvider} con el código: {idProvider}", "Modificar proveedor");
                _frmAdd.Close();
            }
            else
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("No se pudo modificar el proveedor.", "Modificar proveedor");
            }
        }

        public void BtnActiveProcedure(string idProvider, string activeValue)
        {
            bool result = EMaterialProvider.ActiveProcedure(idProvider, activeValue);

            if (result)
                dgv.ChangeActiveColumn(idProvider, activeValue);

        }
    }
}
