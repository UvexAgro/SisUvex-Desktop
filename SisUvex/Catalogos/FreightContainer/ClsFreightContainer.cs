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

namespace SisUvex.Catalogos.FreightContainer
{
    internal class ClsFreightContainer
    {
        ClsControls controlList;
        public FrmFreightContainerAdd _frmAdd;
        public FrmFreightContainerCat _frmCat;
        public EFreightContainer entity;
        private string queryCatalog = $" SELECT cat.*, cat.[{Column.active}] AS [{Column.active + "2"}] FROM vw_PackFreightContainerCat cat ";
        private string queryJoin = $" LEFT JOIN Pack_FreightContainer frc ON frc.id_freightContainer = cat.[Código] LEFT JOIN Pack_TransportLine tln ON tln.id_transportLine = frc.id_transportLine ";
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
                _frmAdd.txbId.Text = EFreightContainer.GetNextId();
            }
            else
            {
                LoadControlsModify();
            }
        }

        private void AddControlsToList()
        {
            controlList = new ClsControls();

            controlList.ChangeHeadMessage("Para dar de alta una caja refrigerada debe:\n");
            controlList.Add(_frmAdd.txbId, "Ingresar el código de la caja.");
            controlList.Add(_frmAdd.txbIdTransportLine, "Seleccionar la línea de transporte.");
            controlList.Add(_frmAdd.txbEcoNumber, "Ingresar el número económico.");
            controlList.Add(_frmAdd.cboTypeContainer, "Ingresar la marca de la caja.");
        }

        private void LoadControls()
        {
            _frmAdd.cboTypeContainer.Tag = "text";
            ClsComboBoxes.CboLoadAllWithoutTextSelect(_frmAdd.cboTypeContainer, ClsObject.FreightContainer.CboTypeContainer);
            _frmAdd.cboTypeContainer.SelectedIndex = -1;

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
            _frmAdd.Text = "Añadir caja refrigerada";
            _frmAdd.lblTitle.Text = "Añadir caja refrigerada";
            _frmAdd.ShowDialog();
        }

        public void OpenFrmModify(string? idModify)
        {
            IsAddOrModify = false;
            IsModifyUpdate = false;
            if (string.IsNullOrEmpty(idModify))
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("No se ha seleccionado una caja para modificar.", "Modificar caja refrigerada");
                return;
            }

            idAddModify = idModify;
            _frmAdd = new();
            _frmAdd.cls = this;
            _frmAdd.Text = "Modificar caja refrigerada";
            _frmAdd.lblTitle.Text = "Modificar caja refrigerada";
            _frmAdd.ShowDialog();
        }

        private void LoadControlsModify()
        {
            entity = new();
            entity.GetFreightContainer(idAddModify);

            _frmAdd.txbId.Text = entity.idFreightContainer;
            _frmAdd.txbEcoNumber.Text = entity.ecoNumber;
            _frmAdd.txbPlateUS.Text = entity.plateUS;
            _frmAdd.txbPlateMX.Text = entity.plateMX;
            _frmAdd.txbYear.Text = entity.year;
            _frmAdd.txbBrand.Text = entity.brand;
            _frmAdd.cboTypeContainer.Text = entity.typeContainer;
            _frmAdd.txbSize.Text = entity.size.ToString();
            _frmAdd.cboActive.SelectedIndex = entity.active;
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboTransportLine, entity.idTransportLine);
        }

        private EFreightContainer SetEntity()
        {
            entity = new();
            entity.idFreightContainer = _frmAdd.txbId.Text;
            entity.ecoNumber = _frmAdd.txbEcoNumber.Text;
            entity.plateUS = _frmAdd.txbPlateUS.Text;
            entity.plateMX = _frmAdd.txbPlateMX.Text;
            entity.year = _frmAdd.txbYear.Text;
            entity.brand = _frmAdd.txbBrand.Text;
            entity.typeContainer = _frmAdd.cboTypeContainer.Text;
            entity.size = int.TryParse(_frmAdd.txbSize.Text, out int size) ? size : 0;
            entity.active = _frmAdd.cboActive.SelectedIndex;
            entity.idTransportLine = _frmAdd.txbIdTransportLine.Text;

            return entity;
        }

        public void AddProcedure()
        {
            EFreightContainer addEntity = new();
            addEntity = SetEntity();
            var result = addEntity.AddProcedure();
            IsAddUpdate = result.Item1;
            idAddModify = result.Item2;
        }

        public void ModifyProcedure()
        {
            EFreightContainer modifyEntity = new();
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
                    MessageBox.Show($"Se ha agregado la caja con código: {idAddModify}", "Añadir caja refrigerada");
                    _frmAdd.Close();
                }
                else
                {
                    SystemSounds.Exclamation.Play();
                    MessageBox.Show("No se pudo agregar la caja.", "Añadir caja refrigerada");
                }
            }
            else
            {
                ModifyProcedure();

                if (IsModifyUpdate)
                {
                    MessageBox.Show($"Se ha modificado la caja con el código: {idAddModify}", "Modificar caja refrigerada");
                    _frmAdd.Close();
                }
                else
                {
                    SystemSounds.Exclamation.Play();
                    MessageBox.Show("No se pudo modificar la caja.", "Modificar caja refrigerada");
                }
            }
        }

        public void CloseFrmAddModify()
        {
            _frmAdd.Close();
        }

        public void BtnActiveProcedure(string id, string activeValue)
        {
            bool result = EFreightContainer.ActiveProcedure(id, activeValue);

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

            if (_frmCat.chbFreightContainerTransportLineRemoved.Checked)
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
                SystemSounds.Exclamation.Play();
        }
    }
}