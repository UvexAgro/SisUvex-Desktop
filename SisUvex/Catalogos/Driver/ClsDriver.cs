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

namespace SisUvex.Catalogos.Driver
{
    internal class ClsDriver
    {
        ClsControls controlList;
        public FrmDriverAdd _frmAdd;
        public FrmDriverCat _frmCat;
        public EDriver entity;
        private string queryCatalog = $" SELECT cat.*, cat.[{Column.active}] AS [{Column.active + "2"}] FROM vw_PackDriverCat cat ";
        private string queryJoin = $"  LEFT JOIN Pack_Driver dri ON dri.id_driver = cat.[Código] LEFT JOIN Pack_TransportLine tln ON tln.id_transportLine = dri.id_transportLine ";
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
                _frmAdd.txbId.Text = EDriver.GetNextId();
            }
            else
            {
                LoadControlsModify();
            }
        }

        private void AddControlsToList()
        {
            controlList = new ClsControls();

            controlList.ChangeHeadMessage("Para dar de alta un chofer debe:\n");
            controlList.Add(_frmAdd.txbId, "Ingresar el código del chofer.");
            controlList.Add(_frmAdd.txbIdTransportLine, "Seleccionar la línea de transporte.");
            controlList.Add(_frmAdd.txbName, "Ingresar el nombre del chofer.");
            controlList.Add(_frmAdd.txbLastNames, "Ingresar los apellidos del chofer.");
        }

        private void LoadControls()
        {
            _frmAdd.dtpBirthday.Checked = false; // Inicialmente no seleccionado

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
            _frmAdd.Text = "Añadir chofer";
            _frmAdd.lblTitle.Text = "Añadir chofer";
            _frmAdd.ShowDialog();
        }

        public void OpenFrmModify(string? idModify)
        {
            IsAddOrModify = false;
            IsModifyUpdate = false;
            if (string.IsNullOrEmpty(idModify))
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("No se ha seleccionado un chofer para modificar.", "Modificar chofer");
                return;
            }

            idAddModify = idModify;
            _frmAdd = new();
            _frmAdd.cls = this;
            _frmAdd.Text = "Modificar chofer";
            _frmAdd.lblTitle.Text = "Modificar chofer";
            _frmAdd.ShowDialog();
        }

        private void LoadControlsModify()
        {
            entity = new();
            entity.GetDriver(idAddModify);

            _frmAdd.txbId.Text = entity.idDriver;
            _frmAdd.txbName.Text = entity.nameDriver;
            _frmAdd.txbLastNames.Text = entity.lastNameDriver;
            _frmAdd.txbLicense.Text = entity.license;
            _frmAdd.dtpBirthday.Value = entity.birthday ?? DateTime.Now;
            _frmAdd.txbVisa.Text = entity.visa;
            _frmAdd.cboActive.SelectedIndex = entity.active;
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboTransportLine, entity.idTransportLine);

            if (entity.birthday != null)
                _frmAdd.dtpBirthday.Checked = true;
            else
                _frmAdd.dtpBirthday.Checked = false; // Si la fecha de nacimiento es nula, desmarcar el DateTimePicker
        }

        private EDriver SetEntity()
        {
            entity = new();
            entity.idDriver = _frmAdd.txbId.Text;
            entity.nameDriver = _frmAdd.txbName.Text;
            entity.lastNameDriver = _frmAdd.txbLastNames.Text;
            entity.license = _frmAdd.txbLicense.Text;
            entity.birthday = _frmAdd.dtpBirthday.Checked ? _frmAdd.dtpBirthday.Value : (DateTime?)null;
            entity.visa = _frmAdd.txbVisa.Text;
            entity.active = _frmAdd.cboActive.SelectedIndex;
            entity.idTransportLine = _frmAdd.txbIdTransportLine.Text;

            return entity;
        }

        public void AddProcedure()
        {
            EDriver addEntity = new();
            addEntity = SetEntity();
            var result = addEntity.AddProcedure();
            IsAddUpdate = result.Item1;
            idAddModify = result.Item2;
        }

        public void ModifyProcedure()
        {
            EDriver modifyEntity = new();
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
                    MessageBox.Show($"Se ha agregado el chofer con código: {idAddModify}", "Añadir chofer");
                    _frmAdd.Close();
                }
                else
                {
                    SystemSounds.Exclamation.Play();
                    MessageBox.Show("No se pudo agregar el chofer.", "Añadir chofer");
                }
            }
            else
            {
                ModifyProcedure();

                if (IsModifyUpdate)
                {
                    MessageBox.Show($"Se ha modificado el chofer con el código: {idAddModify}", "Modificar chofer");
                    _frmAdd.Close();
                }
                else
                {
                    SystemSounds.Exclamation.Play();
                    MessageBox.Show("No se pudo modificar el chofer.", "Modificar chofer");
                }
            }
        }

        public void CloseFrmAddModify()
        {
            _frmAdd.Close();
        }

        public void BtnActiveProcedure(string id, string activeValue)
        {
            bool result = EDriver.ActiveProcedure(id, activeValue);

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
            string qry = queryCatalog + queryJoin + " WHERE 1 = 1 AND  tln.c_active = '1'";

            if (_frmCat.chbDriverTransportLineRemoved.Checked)
                qry = queryCatalog;

            dtCatalog = ClsQuerysDB.GetDataTable(qry);
            dgv = new ClsDGVCatalog(_frmCat.dgvCatalog, dtCatalog);

            //SE MANEJA DIFERENTE POR EL FILTRO DE CHOFERES POR LINEA DE TRANSPORTE ACTIVA

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