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
using SisUvex.Material.MaterialProvider;
using Microsoft.IdentityModel.Tokens;
using System.Media;

namespace SisUvex.Catalogos.TransportLine
{
    internal class ClsTransportLine
    {
        ClsControls controlList;
        public FrmTransportLineAdd _frmAdd;
        public FrmTransportLineCat _frmCat;
        public ETransportLine entity;
        private string queryCatalog = $" SELECT cat.*, cat.[{Column.active}] AS [{Column.active + "2"}] FROM vw_PackTransportLineCat cat ";
        ClsDGVCatalog? dgv;
        DataTable dtCatalog;
        public bool IsAddOrModify = true, IsAddUpdate = false, IsModifyUpdate = false;
        public string? idAddModify;

        public void BeginFormCat()
        {
            _frmCat ??= new();
            _frmCat.cls ??= this;

            dtCatalog = ClsQuerysDB.GetDataTable(queryCatalog);
            dgv = new ClsDGVCatalog(_frmCat.dgvCatalog, dtCatalog);
        }

        public void BeginFormAdd()
        {
            AddControlsToList();

            //LoadComboBoxes(); //No tiene cbo para cargar

            if (IsAddOrModify)
            {
                _frmAdd.cboActive.SelectedIndex = 1;
                _frmAdd.txbId.Text = ETransportLine.GetNextId();
            }
            else
            {
                LoadControlsModify();
            }
        }

        private void AddControlsToList()
        {
            controlList = new ClsControls();

            controlList.ChangeHeadMessage("Para dar de alta una línea de transporte debe:\n");
            controlList.Add(_frmAdd.txbId, "Ingresar el código de la línea de transporte.");
            controlList.Add(_frmAdd.txbName, "Ingresar el nombre de la línea de transporte.");
        }

        public void OpenFrmAdd()
        {
            IsAddOrModify = true;
            IsAddUpdate = false;
            idAddModify = null;
            _frmAdd = new();
            _frmAdd.cls = this;
            _frmAdd.Text = "Añadir línea de transporte";
            _frmAdd.lblTitle.Text = "Añadir línea de transporte";
            _frmAdd.ShowDialog();
        }

        public void OpenFrmModify(string? idModify)
        {
            IsAddOrModify = false;
            IsModifyUpdate = false;
            if (idModify.IsNullOrEmpty())
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("No se ha seleccionado una línea de transporte para modificar.", "Modificar línea de transporte");
                return;
            }

            idAddModify = idModify;
            _frmAdd = new();
            _frmAdd.cls = this;
            _frmAdd.Text = "Modificar línea de transporte";
            _frmAdd.lblTitle.Text = "Modificar línea de transporte";
            _frmAdd.ShowDialog();
        }
        private void LoadControlsModify()
        {
            entity = new();
            entity.GetTransportLine(idAddModify);

            _frmAdd.txbId.Text = entity.idTransportLine;
            _frmAdd.txbName.Text = entity.nameTransportLine;
            _frmAdd.txbAddress.Text = entity.address;
            _frmAdd.txbCity.Text = entity.city;
            _frmAdd.txbRFC.Text = entity.RFC;
            _frmAdd.txbPhoneNumber.Text = entity.phoneNumber;
            _frmAdd.txbSCAC.Text = entity.SCAC;
            _frmAdd.txbSCAAT.Text = entity.SCAAT;
            _frmAdd.cboActive.SelectedIndex = entity.active;
        }

        private ETransportLine SetEntity()
        {
            entity = new();
            entity.idTransportLine = _frmAdd.txbId.Text;
            entity.nameTransportLine = _frmAdd.txbName.Text;
            entity.address = _frmAdd.txbAddress.Text;
            entity.city = _frmAdd.txbCity.Text;
            entity.RFC = _frmAdd.txbRFC.Text;
            entity.phoneNumber = _frmAdd.txbPhoneNumber.Text;
            entity.SCAC = _frmAdd.txbSCAC.Text;
            entity.SCAAT = _frmAdd.txbSCAAT.Text;
            entity.active = _frmAdd.cboActive.SelectedIndex;

            return entity;
        }

        public void AddProcedure()
        {
            ETransportLine addEntity = new();
            addEntity = SetEntity();
            var result = addEntity.AddProcedure();
            IsAddUpdate = result.Item1;
            idAddModify = result.Item2;
        }

        public void ModifyProcedure()
        {
            ETransportLine modifyEntity = new();
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
                    MessageBox.Show($"Se ha agregado la línea de transporte con código: {idAddModify}", "Añadir línea de transporte");

                    _frmAdd.Close();
                }
                else
                {
                    SystemSounds.Exclamation.Play();
                    MessageBox.Show("No se pudo agregar la línea de transporte.", "Añadir proveelínea de transportedor");
                }
            }
            else
            {
                ModifyProcedure();

                if (IsModifyUpdate)
                {
                    MessageBox.Show($"Se ha modificado la línea de transporte con el código: {idAddModify}", "Modificar línea de transporte");

                    _frmAdd.Close();
                }
                else
                {
                    SystemSounds.Exclamation.Play();
                    MessageBox.Show("No se pudo modificar la línea de transporte.", "Modificar proveedor");
                }
            }
        }

        public void CloseFrmAddModify()
        {
            _frmAdd.Close();
        }

        public void BtnActiveProcedure(string id, string activeValue)
        {
            bool result = ETransportLine.ActiveProcedure(id, activeValue);

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
