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

namespace SisUvex.Material.MaterialForeignDest
{
    internal class ClsMaterialForeignDest
    {
        ClsControls controlList;
        public FrmMaterialForeignDestAdd _frmAdd;
        public FrmMaterialForeignDestCat _frmCat;
        public EMaterialForeignDest? entity;
        private string queryCatalogo = $" SELECT cat.* FROM vw_PackForeignDestCat AS cat ";
        ClsDGVCatalog dgv;
        DataTable dtCatalog;
        public bool IsAddOrModify = true, IsAddUpdate = false, IsModifyUpdate = false;
        public string? idAddModify;

        public void BeginFormCat()
        {
            _frmCat ??= new FrmMaterialForeignDestCat();
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
                _frmAdd.txbId.Text = EMaterialForeignDest.GetNextId();
            }
            else
            {
                LoadControlsModify();
            }
        }
        private void AddControlsToList()
        {
            controlList = new ClsControls();

            controlList.ChangeHeadMessage("Para dar de alta un destino externo debe:\n");
            controlList.Add(_frmAdd.txbId, "Ingresar el código del destino externo.");
            controlList.Add(_frmAdd.txbName, "Ingresar la dirección del destino externo.");
        }
        public void OpenFrmAdd()
        {
            idAddModify = null;
            entity = null;
            IsAddOrModify = true;
            IsAddUpdate = false;

            _frmAdd = new();
            _frmAdd.cls = this;
            _frmAdd.Text = "Añadir destino externo";
            _frmAdd.lblTitle.Text = "Añadir destino externo";
            _frmAdd.ShowDialog();
        }
        public void OpenFrmModify(string? idModify)
        {
            IsAddOrModify = false;
            IsModifyUpdate = false;

            if (string.IsNullOrEmpty(idModify))
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("No se ha seleccionado un destino externo para modificar.", "Modificar destino externo");
                return;
            }

            idAddModify = idModify;
            _frmAdd = new();
            _frmAdd.cls = this;
            _frmAdd.Text = "Modificar destino externo";
            _frmAdd.lblTitle.Text = "Modificar destino externo";
            _frmAdd.ShowDialog();
        }

        private void LoadControlsModify()
        {
            entity = new();
            entity.GetForeignDest(idAddModify);

            _frmAdd.txbId.Text = entity.idForeignDest;
            _frmAdd.txbName.Text = entity.address;
            _frmAdd.txbCity.Text = entity.city;
            _frmAdd.txbState.Text = entity.state;
        }

        private EMaterialForeignDest SetEntity()
        {
            entity = new()
            {
                idForeignDest = _frmAdd.txbId.Text,
                address = _frmAdd.txbName.Text,
                city = _frmAdd.txbCity.Text,
                state = _frmAdd.txbState.Text,
                postalCode = _frmAdd.txbPostalCode.Text
            };
            return entity;
        }

        public void AddProcedure()
        {
            EMaterialForeignDest add = new();
            add = SetEntity();
            var result = add.AddProcedure();
            IsAddUpdate = result.Item1;
            idAddModify = result.Item2;
        }

        public void ModifyProcedure()
        {
            EMaterialForeignDest modify = new();
            modify = SetEntity();
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
                    MessageBox.Show($"Se ha agregado el destino externo con código: {idAddModify}", "Añadir destino externo");

                    _frmAdd.Close();
                }
                else
                {
                    SystemSounds.Exclamation.Play();
                    MessageBox.Show("No se pudo agregar el destino externo.", "Añadir destino externo");
                }
            }
            else
            {
                ModifyProcedure();

                if (IsModifyUpdate)
                {
                    MessageBox.Show($"Se ha modificado el destino externo con el código: {idAddModify}", "Modificar destino externo");

                    _frmAdd.Close();
                }
                else
                {
                    SystemSounds.Exclamation.Play();
                    MessageBox.Show("No se pudo modificar el destino externo.", "Modificar destino externo");
                }
            }
        }

        public void CloseFrmAddModify()
        {
            _frmAdd.Close();
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
    }
}
