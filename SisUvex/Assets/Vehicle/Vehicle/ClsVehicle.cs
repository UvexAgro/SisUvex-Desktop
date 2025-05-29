using System;
using System.Collections.Generic;
using System.Data;
using System.Media;
using System.Windows.Forms;
using static SisUvex.Catalogos.Metods.ClsObject;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.DataGridViews;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Catalogos.Metods;

namespace SisUvex.Assets.Vehicle.Vehicle
{
    internal class ClsVehicle
    {
        ClsControls controlList;
        public FrmVehicleAdd _frmAdd;
        public FrmVehicleCat _frmCat;
        public EVehicle entity;
        private string queryCatalog = $"SELECT cat.*, cat.[{Column.active}] AS [{Column.active + "2"}] FROM vw_AstVehicleCat cat ";
        private string queryJoin = $" LEFT JOIN Ast_Vehicle veh ON veh.id_vehicle = cat.[Código] LEFT JOIN Ast_VehicleType typ ON typ.id_vehicleType = veh.id_vehicleType LEFT JOIN Pack_Grower AS gro ON gro.id_grower = veh.id_grower ";
        ClsDGVCatalog? dgv;
        DataTable dtCatalog;
        public bool IsAddOrModify = true, IsAddUpdate = false, IsModifyUpdate = false;
        public string? idAddModify;

        public void BeginFormCat()
        {
            _frmCat ??= new FrmVehicleCat();
            _frmCat.cls ??= this;

            dtCatalog = ClsQuerysDB.GetDataTable(queryCatalog);
            dgv = new ClsDGVCatalog(_frmCat.dgvCatalog, dtCatalog);

            ClsComboBoxes.CboLoadAll(_frmCat.cboVehicleType, ClsObject.VehicleType.Cbo);
        }

        public void BeginFormAdd()
        {
            AddControlsToList();
            LoadComboBoxes();

            if (IsAddOrModify)
            {
                _frmAdd.cboActive.SelectedIndex = 1; // Activo por defecto
                _frmAdd.txbId.Text = EVehicle.GetNextId();
            }
            else
            {
                LoadControlsModify();
            }
        }

        private void AddControlsToList()
        {
            controlList = new ClsControls();
            controlList.ChangeHeadMessage("Para dar de alta un vehículo debe:\n");
            controlList.Add(_frmAdd.txbId, "Ingresar el código del vehículo.");
            controlList.Add(_frmAdd.txbIdVehicleType, "Seleccionar el tipo de vehículo.");
            controlList.Add(_frmAdd.txbEcoNumber, "Ingresar el número económico.");
            controlList.Add(_frmAdd.cboPrefix, "Ingresar el prefijo del vehículo válido.");
        }

        private void LoadComboBoxes()
        {
            _frmAdd.cboPrefix.Tag = "text";
            _frmAdd.cboPrefix.DataSource = EVehicle.GetDtPrefix();
            _frmAdd.cboPrefix.DisplayMember = "v_prefix";
            _frmAdd.cboPrefix.SelectedIndex = -1;

            ClsComboBoxes.CboLoadActives(_frmAdd.cboVehicleType, ClsObject.VehicleType.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboGrower, Grower.Cbo);

            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboVehicleType, _frmAdd.txbIdVehicleType);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboGrower, _frmAdd.txbIdGrower);
        }

        public void OpenFrmAdd()
        {
            IsAddOrModify = true;
            IsAddUpdate = false;
            idAddModify = null;

            _frmAdd = new FrmVehicleAdd();
            _frmAdd.cls = this;
            _frmAdd.Text = "Añadir vehículo";
            _frmAdd.lblTitle.Text = "Añadir vehículo";
            _frmAdd.ShowDialog();
        }

        public void OpenFrmModify(string? idModify)
        {
            IsAddOrModify = false;
            IsModifyUpdate = false;

            if (string.IsNullOrEmpty(idModify))
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("No se ha seleccionado un vehículo para modificar.", "Modificar vehículo");
                return;
            }

            idAddModify = idModify;
            _frmAdd = new FrmVehicleAdd();
            _frmAdd.cls = this;
            _frmAdd.Text = "Modificar vehículo";
            _frmAdd.lblTitle.Text = "Modificar vehículo";
            _frmAdd.ShowDialog();
        }

        private void LoadControlsModify()
        {
            entity = new EVehicle();
            entity.GetVehicle(idAddModify ?? "0");

            _frmAdd.txbId.Text = entity.idVehicle;
            _frmAdd.cboPrefix.Text = entity.prefix;
            _frmAdd.txbEcoNumber.Text = entity.ecoNumber;
            _frmAdd.txbSerialNumber.Text = entity.serialNumber;
            _frmAdd.txbPlates.Text = entity.plate;
            _frmAdd.txbMake.Text = entity.make;
            _frmAdd.txbModel.Text = entity.model;
            _frmAdd.txbYear.Text = entity.year;
            _frmAdd.txbComments.Text = entity.comments;
            _frmAdd.cboActive.SelectedIndex = entity.active == "1" ? 1 : 0;

            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboVehicleType, entity.idVehicleType);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboGrower, entity.idGrower);
        }

        private EVehicle SetEntity()
        {
            entity = new EVehicle
            {
                idVehicle = _frmAdd.txbId.Text,
                idVehicleType = _frmAdd.txbIdVehicleType.Text,
                active = _frmAdd.cboActive.SelectedIndex == 1 ? "1" : "0",
                prefix = _frmAdd.cboPrefix.Text,
                ecoNumber = _frmAdd.txbEcoNumber.Text,
                serialNumber = _frmAdd.txbSerialNumber.Text,
                plate = _frmAdd.txbPlates.Text,
                make = _frmAdd.txbMake.Text,
                model = _frmAdd.txbModel.Text,
                year = _frmAdd.txbYear.Text,
                comments = _frmAdd.txbComments.Text,
                idGrower = _frmAdd.txbIdGrower.Text
            };

            return entity;
        }

        public void AddProcedure()
        {
            EVehicle addEntity = SetEntity();
            var result = addEntity.AddProcedure();
            IsAddUpdate = result.Item1;
            idAddModify = result.Item2;
        }

        public void ModifyProcedure()
        {
            EVehicle modifyEntity = SetEntity();
            var result = modifyEntity.ModifyProcedure();
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
                    MessageBox.Show($"Se ha agregado el vehículo con código: {idAddModify}", "Añadir vehículo");
                    _frmAdd.Close();
                }
                else
                {
                    SystemSounds.Exclamation.Play();
                    MessageBox.Show("No se pudo agregar el vehículo.", "Añadir vehículo");
                }
            }
            else
            {
                ModifyProcedure();
                if (IsModifyUpdate)
                {
                    MessageBox.Show($"Se ha modificado el vehículo con código: {idAddModify}", "Modificar vehículo");
                    _frmAdd.Close();
                }
                else
                {
                    SystemSounds.Exclamation.Play();
                    MessageBox.Show("No se pudo modificar el vehículo.", "Modificar vehículo");
                }
            }
        }

        public void CloseFrmAddModify()
        {
            _frmAdd?.Close();
        }

        public void BtnActiveProcedure(string id, string activeValue)
        {
            bool result = EVehicle.ActiveProcedure(id, activeValue);
            if (result)
                dgv?.ChangeActiveCell(id, activeValue);
        }

        public void AddNewRowByIdInDGVCatalog()
        {
            DataTable newIdRow = ClsQuerysDB.GetDataTable(queryCatalog + $" WHERE [{Column.id}] = '{idAddModify}'");
            dgv?.AddNewRowToDGV(newIdRow);
        }

        public void ModifyRowByIdInDGVCatalog()
        {
            DataTable newIdRow = ClsQuerysDB.GetDataTable(queryCatalog + $" WHERE [{Column.id}] = '{idAddModify}'");
            dgv?.ModifyIdRowInDGV(newIdRow);
        }

        public void ChbRemovedFilter()
        {
            if (_frmCat.chbRemoved.Checked)
                dgv.SetFilterNull();
            else
            {
                dgv.CopyActiveValuesToHiddenColumn();
                dgv.SetFilterActivesOnly();
            }
        }

        public void BtnVehicleTypeFilter()
        {
            if (_frmCat.cboVehicleType.SelectedIndex > 0)
            {
                string qry = queryCatalog + queryJoin + " WHERE typ.id_vehicleType = @idVehicleType";
                var parameters = new Dictionary<string, object>
                {
                    { "@idVehicleType", _frmCat.cboVehicleType.SelectedValue }
                };

                dtCatalog = ClsQuerysDB.ExecuteParameterizedQuery(qry, parameters);
                dgv = new ClsDGVCatalog(_frmCat.dgvCatalog, dtCatalog);
            }
            else
            {
                dtCatalog = ClsQuerysDB.GetDataTable(queryCatalog);
                dgv = new ClsDGVCatalog(_frmCat.dgvCatalog, dtCatalog);
                ChbRemovedFilter();
            }
        }
    }
}