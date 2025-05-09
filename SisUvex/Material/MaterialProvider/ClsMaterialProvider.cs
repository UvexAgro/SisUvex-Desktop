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
using OfficeOpenXml.FormulaParsing.Excel.Functions.Finance;
using Microsoft.IdentityModel.Tokens;

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
        private string queryCatalogo = $" SELECT *, [{Column.active}] AS [{Column.active + "2"}] FROM vw_PackProviderCat ";
        ClsDGVCatalog dgv;
        DataTable dtCatalog;
        public bool IsAddOrModify = true, IsAddUpdate = false, IsModifyUpdate = false;
        public string? idAddModify;
        DataTable? dtProvider;

        public void BeginFormCat()
        {
            _frmCat ??= new FrmMaterialProviderCat();
            _frmCat.cls ??= this;

            dtCatalog = ClsQuerysDB.GetDataTable(queryCatalogo);
            dgv = new ClsDGVCatalog(_frmCat.dgvCatalog, dtCatalog);
        }

        public void BeginFormAdd()
        {
            AddControlsToList();

            //LoadComboBoxes(); //No tiene cbo para cargar

            if (IsAddOrModify)
            {
                _frmAdd.cboActive.SelectedIndex = 1;
                _frmAdd.txbId.Text = EMaterialProvider.GetNextId();
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
            controlList.Add(_frmAdd.txbShortName, "Ingresar el nombre corto del proveedor.");
        }

        public void OpenFrmAdd()
        {
            IsAddOrModify = true;

            _frmAdd = new FrmMaterialProviderAdd();
            _frmAdd.cls = this;
            _frmAdd.Text = "Añadir proveedor";
            _frmAdd.lblTitle.Text = "Añadir proveedor";
            _frmAdd.ShowDialog();
        }

        public void OpenFrmModify(string? idModify)
        {
            IsAddOrModify = false;

            if (idModify.IsNullOrEmpty())
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("No se ha seleccionado un proveedor para modificar.", "Modificar proveedor");
                return;
            }

            idAddModify = idModify;
            _frmAdd = new FrmMaterialProviderAdd();
            _frmAdd.cls = this;
            _frmAdd.Text = "Modificar proveedor";
            _frmAdd.lblTitle.Text = "Modificar proveedor";
            _frmAdd.ShowDialog();
        }

        private void LoadControlsModify()
        {
            eProvider = new EMaterialProvider();
            eProvider.GetProvider(idAddModify ?? "0");

            _frmAdd.txbId.Text = eProvider.idProvider;
            _frmAdd.txbName.Text = eProvider.nameProvider;
            _frmAdd.txbCity.Text = eProvider.city;
            _frmAdd.txbPhoneNumber.Text = eProvider.phoneNumber;
            _frmAdd.txbEmail.Text = eProvider.email;
            _frmAdd.cboActive.SelectedIndex = eProvider.active;
            _frmAdd.txbShortName.Text = eProvider.shortNameProvider;
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
            eProvider.shortNameProvider = _frmAdd.txbShortName.Text;

            return eProvider;
        }

        public void AddProcedure()
        {
            EMaterialProvider addProvider = new();
            addProvider = SetProviderEntity();
            var result = addProvider.AddProcedure();
            IsAddUpdate = result.Item1;
            idAddModify = result.Item2;
        }

        public void ModifyProcedure()
        {
            EMaterialProvider modifyProvider = new();
            modifyProvider = SetProviderEntity();
            var result = modifyProvider.ModifyProcedure();
            IsModifyUpdate = result.Item1;
            idAddModify = result.Item2;
        }
        public void BtnAccept()
        {
            if (!controlList.ValidateControls())
                return;

            if (IsAddOrModify)
            {
                AddProcedure();
                if (IsAddUpdate)
                {
                    _frmAdd.txbId.Text = idAddModify;
                    MessageBox.Show($"Se ha agregado el proveedor con código: {idAddModify}", "Añadir proveedor");

                    _frmAdd.Close();
                }
                else
                {
                    SystemSounds.Exclamation.Play();
                    MessageBox.Show("No se pudo agregar el proveedor.", "Añadir proveedor");
                }
            }
            else
            {
                ModifyProcedure();

                if (IsModifyUpdate)
                {
                    MessageBox.Show($"Se ha modificado el proveedor con el código: {idAddModify}", "Modificar proveedor");

                    _frmAdd.Close();
                }
                else
                {
                    SystemSounds.Exclamation.Play();
                    MessageBox.Show("No se pudo modificar el proveedor.", "Modificar proveedor");
                }
            }
        }

        public void CloseFrmAddModify()
        {
            _frmAdd.Close();
        }

        public void BtnActiveProcedure(string idProvider, string activeValue)
        {
            bool result = EMaterialProvider.ActiveProcedure(idProvider, activeValue);

            if (result)
                dgv.ChangeActiveCell(idProvider, activeValue);
        }

        public void AddNewRowByIdInDGVCatalog()
        {
            DataTable newIdRow = ClsQuerysDB.GetDataTable(queryCatalogo + $" WHERE [{Column.id}] = '{idAddModify}'");

            dgv.AddNewRowToDGV(newIdRow);
        }

        public void ModifyRowByIdInDGVCatalog()
        {
            DataTable newIdRow = ClsQuerysDB.GetDataTable(queryCatalogo + $" WHERE [{Column.id}] = '{idAddModify}'");

            dgv.ModifyIdRowInDGV(newIdRow);
        }

        public void ChbRemovedProcedure()
        {
            if (_frmCat.chbRemoved.Checked)
                dgv.SetFilterNull();
            else
            {
                dgv.CopyActiveValuesToHiddenColumn();
                dgv.SetFilterActivesOnly();
            }
        }

    }
}