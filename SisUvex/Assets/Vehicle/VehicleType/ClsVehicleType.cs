using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using static SisUvex.Catalogos.Metods.ClsObject;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.DataGridViews;
using System.Media;
using SisUvex.Catalogos.Metods.Querys;

namespace SisUvex.Assets.Vehicle.VehicleType
{
    internal class ClsVehicleType
    {
        ClsControls controlList;
        public FrmVehicleTypeAdd _frmAdd;
        public FrmVehicleTypeCat _frmCat;
        public EVehicleType entity;
        private string queryCatalogo = $" SELECT id_vehicleType AS [{Column.id}], v_nameVehicleType AS [{Column.name}], v_implements AS [Implementos] FROM Ast_VehicleType ";
        ClsDGVCatalog dgv;
        DataTable dtCatalog;
        public bool IsAddOrModify = true, IsAddUpdate = false, IsModifyUpdate = false;
        public string? idAddModify;

        public void BeginFormCat()
        {
            _frmCat ??= new();
            _frmCat.cls ??= this;
            dtCatalog = ClsQuerysDB.GetDataTable(queryCatalogo);
            dgv = new ClsDGVCatalog(_frmCat.dgvCatalog, dtCatalog);
        }

        public void BeginFormAdd()
        {
            AddControlsToList();

            _frmAdd.txbId.Text = EVehicleType.GetNextId();

            if (!IsAddOrModify)
            {
                LoadControlsModify();
            }
        }

        private void AddControlsToList()
        {
            controlList = new ClsControls();

            controlList.ChangeHeadMessage("Para dar de alta un tipo de vehículo debe:\n");
            controlList.Add(_frmAdd.txbId, "Ingresar el código del vehículo.");
        }

        public void OpenFrmAdd()
        {
            IsAddOrModify = true;

            _frmAdd = new();
            _frmAdd.cls = this;
            _frmAdd.Text = "Añadir tipo de vehículo";
            _frmAdd.lblTitle.Text = "Añadir tipo de vehículo";
            _frmAdd.ShowDialog();
        }

        public void OpenFrmModify(string? idModify)
        {
            IsAddOrModify = false;

            if (string.IsNullOrEmpty(idModify))
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("No se ha seleccionado un tipo de vehículo para modificar.", "Modificar tipo de vehículo");
                return;
            }

            idAddModify = idModify;
            _frmAdd = new();
            _frmAdd.cls = this;
            _frmAdd.Text = "Modificar tipo de vehículo";
            _frmAdd.lblTitle.Text = "Modificar tipo de vehículo";
            _frmAdd.ShowDialog();
        }

        private void LoadControlsModify()
        {
            entity = new();
            entity.GetVehicleType(idAddModify ?? "0");
            _frmAdd.txbId.Enabled = false;
            _frmAdd.txbId.Text = entity.idVehicleType;
            _frmAdd.txbName.Text = entity.nameVehicleType;
            _frmAdd.txbImplements.Text = entity.implements;
        }

        private EVehicleType SetVehicleTypeEntity()
        {
            entity = new();
            entity.idVehicleType = _frmAdd.txbId.Text;
            entity.nameVehicleType = _frmAdd.txbName.Text;
            entity.implements = _frmAdd.txbImplements.Text;

            return entity;
        }

        public void AddProcedure()
        {
            EVehicleType add = SetVehicleTypeEntity();
            var result = add.AddProcedure();
            IsAddUpdate = result.Item1;
            idAddModify = result.Item2;
        }

        public void ModifyProcedure()
        {
            EVehicleType modify = SetVehicleTypeEntity();
            var result = modify.ModifyProcedure();
            IsModifyUpdate = result.Item1;
            idAddModify = result.Item2;
        }

        public void BtnAccept()
        {
            if (!controlList.ValidateControls())
                return;

            if (string.IsNullOrWhiteSpace(_frmAdd.txbName.Text) &&
                string.IsNullOrWhiteSpace(_frmAdd.txbImplements.Text))
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("Debe ingresar al menos el nombre o los implementos del vehículo.",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (IsAddOrModify)
            {
                AddProcedure();
                if (IsAddUpdate)
                {
                    _frmAdd.txbId.Text = idAddModify;
                    MessageBox.Show($"Se ha agregado el tipo de vehículo con código: {idAddModify}",
                                  "Añadir tipo de vehículo");
                    _frmAdd.Close();
                }
                else
                {
                    SystemSounds.Exclamation.Play();
                    MessageBox.Show("No se pudo agregar el tipo de vehículo.", "Añadir tipo de vehículo");
                }
            }
            else
            {
                ModifyProcedure();
                if (IsModifyUpdate)
                {
                    MessageBox.Show($"Se ha modificado el tipo de vehículo con el código: {idAddModify}",
                                  "Modificar tipo de vehículo");
                    _frmAdd.Close();
                }
                else
                {
                    SystemSounds.Exclamation.Play();
                    MessageBox.Show("No se pudo modificar el tipo de vehículo.", "Modificar tipo de vehículo");
                }
            }
        }

        public void CloseFrmAddModify()
        {
            _frmAdd?.Close();
        }

        public void AddNewRowByIdInDGVCatalog()
        {
            DataTable newIdRow = ClsQuerysDB.GetDataTable(queryCatalogo + $" WHERE id_vehicleType = '{idAddModify}'");
            dgv.AddNewRowToDGV(newIdRow);
        }

        public void ModifyRowByIdInDGVCatalog()
        {
            DataTable newIdRow = ClsQuerysDB.GetDataTable(queryCatalogo + $" WHERE id_vehicleType = '{idAddModify}'");
            dgv.ModifyIdRowInDGV(newIdRow);
        }
    }
}