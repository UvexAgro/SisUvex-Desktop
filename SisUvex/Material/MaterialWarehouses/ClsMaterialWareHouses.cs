using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.DataGridViews;
using static SisUvex.Catalogos.Metods.ClsObject;
using System.Data;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Material.Warehouses;
using Microsoft.IdentityModel.Tokens;
using System.Media;
using SisUvex.Material.MaterialProvider;
using SisUvex.Catalogos.Metods.Values;

namespace SisUvex.Material.MaterialWarehouses
{
    internal class ClsMaterialWareHouses
    {
        SQLControl sql = new SQLControl();
        ClsControls controlList;
        public FrmMaterialWarehousesAdd _frmAdd;
        public FrmMaterialWareHousesCat _frmCat;
        public EMaterialWareHouse? eWareHouse;
        private string queryCatalogo = $" SELECT *, [{Column.active}] AS [{Column.active + "2"}] FROM vw_PackWareHousesCat ";
        ClsDGVCatalog dgv;
        DataTable dtCatalog;
        public bool IsAddOrModify = true, IsAddUpdate = false, IsModifyUpdate = false;
        public string? idAddModify;
        DataTable? dtProvider;

        public void BeginFormCat()
        {
            _frmCat ??= new FrmMaterialWareHousesCat();
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
                _frmAdd.txbId.Text = EMaterialWareHouse.GetNextId();
            }
            else
            {
                LoadControlsModify();
            }
        }
        private void AddControlsToList()
        {
            controlList = new ClsControls();

            controlList.ChangeHeadMessage("Para dar de alta un almacén debe:\n");
            controlList.Add(_frmAdd.txbId, "Ingresar el código del almacén.");
            controlList.Add(_frmAdd.txbName, "Ingresar un nombre para el almacén.");
        }
        public void OpenFrmAdd()
        {
            IsAddOrModify = true;
            idAddModify = null;
            eWareHouse = null;
            IsAddUpdate = false;

            _frmAdd = new FrmMaterialWarehousesAdd();
            _frmAdd.cls = this;
            _frmAdd.Text = "Añadir almacén";
            _frmAdd.lblTitle.Text = "Añadir almacén";
            _frmAdd.ShowDialog();
        }
        public void OpenFrmModify(string? idModify)
        {
            IsAddOrModify = false;

            if (idModify.IsNullOrEmpty())
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("No se ha seleccionado un almacén para modificar.", "Modificar almacén");
                return;
            }

            idAddModify = idModify;
            _frmAdd = new FrmMaterialWarehousesAdd();
            _frmAdd.cls = this;
            _frmAdd.Text = "Modificar almacén";
            _frmAdd.lblTitle.Text = "Modificar almacén";
            _frmAdd.ShowDialog();
        }

        private void LoadControlsModify()
        {
            eWareHouse = new EMaterialWareHouse();
            eWareHouse.GetWareHouse(idAddModify ?? "0");

            _frmAdd.txbId.Text = eWareHouse.idWareHouse;
            _frmAdd.txbName.Text = eWareHouse.nameWareHouse;
            _frmAdd.txbIdEmployee.Text = eWareHouse.idEmployee;
            _frmAdd.cboActive.SelectedIndex = eWareHouse.active;

            if (!eWareHouse.idEmployee.IsNullOrEmpty())
                GetEmployeeName(eWareHouse.idEmployee);
        }

        private EMaterialWareHouse SetWareHouseEntity()
        {
            eWareHouse = new EMaterialWareHouse();
            eWareHouse.idWareHouse = _frmAdd.txbId.Text;
            eWareHouse.nameWareHouse = _frmAdd.txbName.Text;
            eWareHouse.idEmployee = _frmAdd.txbIdEmployee.Text;
            eWareHouse.active = _frmAdd.cboActive.SelectedIndex;

            return eWareHouse;
        }

        public void AddProcedure()
        {
            EMaterialWareHouse addWareHouse = new();
            addWareHouse = SetWareHouseEntity();
            var result = addWareHouse.AddProcedure();
            IsAddUpdate = result.Item1;
            idAddModify = result.Item2;
        }

        public void ModifyProcedure()
        {
            EMaterialWareHouse modifyWareHouse = new();
            modifyWareHouse = SetWareHouseEntity();
            var result = modifyWareHouse.ModifyProcedure();
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
                    MessageBox.Show($"Se ha agregado el almacén con código: {idAddModify}", "Añadir almacén");

                    _frmAdd.Close();
                }
                else
                {
                    SystemSounds.Exclamation.Play();
                    MessageBox.Show("No se pudo agregar el almacén.", "Añadir almacén");
                }
            }
            else
            {
                ModifyProcedure();

                if (IsModifyUpdate)
                {
                    MessageBox.Show($"Se ha modificado el almacén con el código: {idAddModify}", "Modificar almacén");

                    _frmAdd.Close();
                }
                else
                {
                    SystemSounds.Exclamation.Play();
                    MessageBox.Show("No se pudo modificar el almacén.", "Modificar almacén");
                }
            }
        }
        public void CloseFrmAddModify()
        {
            _frmAdd.Close();
        }
        public void BtnActiveProcedure(string idWareHouse, string activeValue)
        {
            bool result = EMaterialWareHouse.ActiveProcedure(idWareHouse, activeValue);

            if (result)
                dgv.ChangeActiveCell(idWareHouse, activeValue);
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

        public void GetEmployeeName(string idEmployee)
        {
            if (int.TryParse(idEmployee, out var employeeId))
            {
                idEmployee = ClsValues.FormatZeros(idEmployee, "000000");

                Dictionary<string, object> parameter = new Dictionary<string, object>();
                parameter.Add("@idEmployee", idEmployee);

                string? nameEmployee = ClsQuerysDB.GetStringExecuteParameterizedQuery($" SELECT CONCAT_WS(' ',v_name, v_lastnamePat, v_lastnameMat) FROM nom_employees WHERE id_employee = @idEmployee ", parameter);

                if (!nameEmployee.IsNullOrEmpty())
                {
                    _frmAdd.txbIdEmployee.Text = idEmployee;
                    _frmAdd.txbEmployeeName.Text = nameEmployee;
                    return;
                }
            }

            SystemSounds.Exclamation.Play();
            MessageBox.Show("No se ha encontrado el empleado " + idEmployee + ".", "Empleado");
        }
    }
}
