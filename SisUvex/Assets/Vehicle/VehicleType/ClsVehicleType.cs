using System.Data;
using System.Media;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.DataGridViews;
using SisUvex.Catalogos.Metods.Querys;
using static SisUvex.Catalogos.Metods.ClsObject;

namespace SisUvex.Assets.Vehicle.VehicleType
{
    internal class ClsVehicleType
    {
        ClsControls controlList;
        public FrmVehicleTypeAdd _frmAdd;
        public FrmVehicleTypeCat _frmCat;
        public EVehicleType entity;
        private string queryCatalogo = $" SELECT id_vehicleType AS [{Column.id}], v_nameVehicleType AS [{Column.name}], v_prefix AS [Prefijo], v_implements AS [Implementos], c_meterType AS [Tipo medidor] FROM Ast_VehicleType ";
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
            LoadComboBoxes();

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
            controlList.Add(_frmAdd.txbId, "Ingresar el código del tipo de vehículo.");
            controlList.Add(_frmAdd.txbName, "Ingresar el nombre del tipo de vehículo.");
            controlList.Add(_frmAdd.txbPrefix, "Ingresar el prefijo del tipo de vehículo.");
        }

        private void LoadComboBoxes()
        {
            DataTable dtMeter = new();
            dtMeter.Columns.Add(Column.id);
            dtMeter.Columns.Add(Column.name);
            dtMeter.Rows.Add("", ClsComboBoxes.textSelect);
            dtMeter.Rows.Add("H", "Horómetro");
            dtMeter.Rows.Add("K", "Kilometraje");

            _frmAdd.cboMeterType.DataSource = dtMeter;
            _frmAdd.cboMeterType.DisplayMember = Column.name;
            _frmAdd.cboMeterType.ValueMember = Column.id;
            _frmAdd.cboMeterType.SelectedIndex = 0;
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
            _frmAdd.txbPrefix.Text = entity.prefix;
            _frmAdd.txbImplements.Text = entity.implements;
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboMeterType, entity.meterType);
        }

        private EVehicleType SetVehicleTypeEntity()
        {
            entity = new();
            entity.idVehicleType = _frmAdd.txbId.Text;
            entity.nameVehicleType = _frmAdd.txbName.Text;
            entity.prefix = _frmAdd.txbPrefix.Text;
            entity.implements = _frmAdd.txbImplements.Text;
            entity.meterType = _frmAdd.cboMeterType.SelectedValue?.ToString();

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
