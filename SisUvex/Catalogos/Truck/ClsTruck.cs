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
using System.Media;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods;

namespace SisUvex.Catalogos.Truck
{
    internal class ClsTruck
    {
        ClsControls controlList;
        public FrmTruckAdd _frmAdd;
        public FrmTruckCat _frmCat;
        public ETruck entity;
        private string queryCatalog = $" SELECT cat.*, cat.[{Column.active}] AS [{Column.active + "2"}] FROM vw_PackTruckCat cat ";
        private string queryJoin = $" LEFT JOIN Pack_Truck tru ON tru.id_truck = cat.[Código] LEFT JOIN Pack_TransportLine tln ON tln.id_transportLine = tru.id_transportLine ";
        ClsDGVCatalog? dgv;
        DataTable dtCatalog;
        public bool IsAddOrModify = true, IsAddUpdate = false, IsModifyUpdate = false;
        public string? idAddModify;

        public void BeginFormCat()
        {
            _frmCat ??= new();
            _frmCat.cls ??= this;

            dtCatalog = ClsQuerysDB.GetDataTable(queryCatalog + queryJoin + " WHERE 1 = 1 AND tln.c_active = '1' ");
            dgv = new ClsDGVCatalog(_frmCat.dgvCatalog, dtCatalog);

            ClsComboBoxes.CboLoadActives(_frmCat.cboTransportLine, ClsObject.TransportLine.Cbo);
            ClsComboBoxes.CboApplyClickEvent(_frmCat.cboTransportLine, _frmCat.chbTransportLineRemoved);
        }

        public void BeginFormAdd()
        {
            AddControlsToList();
            LoadControls();

            if (IsAddOrModify)
            {
                _frmAdd.cboActive.SelectedIndex = 1;
                _frmAdd.txbId.Text = ETruck.GetNextId();
            }
            else
            {
                LoadControlsModify();
            }
        }

        private void AddControlsToList()
        {
            controlList = new ClsControls();

            controlList.ChangeHeadMessage("Para dar de alta un troque debe:\n");
            controlList.Add(_frmAdd.txbId, "Ingresar el código del troque.");
            controlList.Add(_frmAdd.txbIdTransportLine, "Seleccionar la línea de transporte.");
            controlList.Add(_frmAdd.txbEcoNumber, "Ingresar el número económico.");
        }

        private void LoadControls()
        {
            ClsComboBoxes.CboLoadActives(_frmAdd.cboTransportLine, ClsObject.TransportLine.Cbo);
            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboTransportLine, _frmAdd.chbTransportLineRemoved);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboTransportLine, _frmAdd.txbIdTransportLine);
        }

        public void OpenFrmAdd()
        {
            IsAddOrModify = true;
            IsAddUpdate = false;
            idAddModify = null;
            _frmAdd = new();
            _frmAdd.cls = this;
            _frmAdd.Text = "Añadir troque";
            _frmAdd.lblTitle.Text = "Añadir troque";
            _frmAdd.ShowDialog();
        }

        public void OpenFrmModify(string? idModify)
        {
            IsAddOrModify = false;
            IsModifyUpdate = false;
            if (string.IsNullOrEmpty(idModify))
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("No se ha seleccionado un troque para modificar.", "Modificar troque");
                return;
            }

            idAddModify = idModify;
            _frmAdd = new();
            _frmAdd.cls = this;
            _frmAdd.Text = "Modificar troque";
            _frmAdd.lblTitle.Text = "Modificar troque";
            _frmAdd.ShowDialog();
        }

        private void LoadControlsModify()
        {
            entity = new();
            entity.GetTruck(idAddModify);

            _frmAdd.txbId.Text = entity.idTruck;
            _frmAdd.txbEcoNumber.Text = entity.ecoNumber;
            _frmAdd.txbPlateUS.Text = entity.plateUS;
            _frmAdd.txbPlateMX.Text = entity.plateMX;
            _frmAdd.txbYear.Text = entity.year;
            _frmAdd.txbBrand.Text = entity.brand;
            _frmAdd.txbVinNumber.Text = entity.vinNumber;
            _frmAdd.txbColor.Text = entity.color;
            _frmAdd.cboActive.SelectedIndex = entity.active;
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboTransportLine, entity.idTransportLine);
        }

        private ETruck SetEntity()
        {
            entity = new();
            entity.idTruck = _frmAdd.txbId.Text;
            entity.ecoNumber = _frmAdd.txbEcoNumber.Text;
            entity.plateUS = _frmAdd.txbPlateUS.Text;
            entity.plateMX = _frmAdd.txbPlateMX.Text;
            entity.year = _frmAdd.txbYear.Text;
            entity.brand = _frmAdd.txbBrand.Text;
            entity.vinNumber = _frmAdd.txbVinNumber.Text;
            entity.color = _frmAdd.txbColor.Text;
            entity.active = _frmAdd.cboActive.SelectedIndex;
            entity.idTransportLine = _frmAdd.txbIdTransportLine.Text;

            return entity;
        }

        public void AddProcedure()
        {
            ETruck addEntity = new();
            addEntity = SetEntity();
            var result = addEntity.AddProcedure();
            IsAddUpdate = result.Item1;
            idAddModify = result.Item2;
        }

        public void ModifyProcedure()
        {
            ETruck modifyEntity = new();
            modifyEntity = SetEntity();
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
                    MessageBox.Show($"Se ha agregado el troque con código: {idAddModify}", "Añadir troque");
                    _frmAdd.Close();
                }
                else
                {
                    SystemSounds.Exclamation.Play();
                    MessageBox.Show("No se pudo agregar el troque.", "Añadir troque");
                }
            }
            else
            {
                ModifyProcedure();

                if (IsModifyUpdate)
                {
                    MessageBox.Show($"Se ha modificado el troque con el código: {idAddModify}", "Modificar troque");
                    _frmAdd.Close();
                }
                else
                {
                    SystemSounds.Exclamation.Play();
                    MessageBox.Show("No se pudo modificar el troque.", "Modificar troque");
                }
            }
        }

        public void CloseFrmAddModify()
        {
            _frmAdd.Close();
        }

        public void BtnActiveProcedure(string id, string activeValue)
        {
            bool result = ETruck.ActiveProcedure(id, activeValue);

            if (result)
                dgv.ChangeActiveCell(id, activeValue);
        }

        public void AddNewRowByIdInDGVCatalog()
        {
            DataTable newIdRow = ClsQuerysDB.GetDataTable(queryCatalog + $" WHERE [{Column.id}] = '{idAddModify}'");
            dgv.AddNewRowToDGV(newIdRow);
        }

        public void ModifyRowByIdInDGVCatalog()
        {
            DataTable newIdRow = ClsQuerysDB.GetDataTable(queryCatalog + $" WHERE [{Column.id}] = '{idAddModify}'");
            dgv.ModifyIdRowInDGV(newIdRow);
        }

        public void ChbRemovedFilter()
        {
            string qry = queryCatalog + queryJoin + " WHERE 1 = 1 AND tln.c_active = '1'";

            if (_frmCat.chbTruckTransportLineRemoved.Checked)
                qry = queryCatalog;

            dtCatalog = ClsQuerysDB.GetDataTable(qry);
            dgv = new ClsDGVCatalog(_frmCat.dgvCatalog, dtCatalog);

            if (_frmCat.chbRemoved.Checked)
                dgv.SetFilterNull();
            else
            {
                dgv.CopyActiveValuesToHiddenColumn();
                dgv.SetFilterActivesOnly();
            }
        }

        public void BtnTransportLineFilter()
        {
            if (_frmCat.cboTransportLine.SelectedIndex > 0)
            {
                string qry = queryCatalog + queryJoin + "WHERE tln.id_transportLine = @idTransportLine";
                Dictionary<string, object> parameters = new()
                {
                    { "@idTransportLine", _frmCat.cboTransportLine.SelectedValue }
                };

                dtCatalog = ClsQuerysDB.ExecuteParameterizedQuery(qry, parameters);
                dgv = new ClsDGVCatalog(_frmCat.dgvCatalog, dtCatalog);
            }
            else
            {
                ChbRemovedFilter();
            }
        }
    }
}