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

namespace SisUvex.Material.MaterialType
{
    internal class ClsMaterialType
    {
        ClsControls controlList;
        public FrmMaterialTypeAdd _frmAdd;
        public FrmMaterialTypeCat _frmCat;
        public EMaterialType entity;
        private string queryCatalogo = $" SELECT id_matType AS [{Column.id}], v_nameMatType AS [{Column.name}] FROM Pack_MaterialType ";
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

            _frmAdd.txbId.Text = EMaterialType.GetNextId();
            //LoadComboBoxes(); //No tiene cbo para cargar

            if (IsAddOrModify)
            {
                //_frmAdd.txbId.Text = EMaterialType.GetNextId(); //La id se escribe, no se enumera
            }
            else
            {
                LoadControlsModify();
            }
        }

        private void AddControlsToList()
        {
            controlList = new();

            controlList.ChangeHeadMessage("Para dar de alta un tipo de material debe:\n");
            controlList.Add(_frmAdd.txbId, "Ingresar el código del material.");
            controlList.Add(_frmAdd.txbName, "Ingresar el nombre del tipo de material.");
        }

        public void OpenFrmAdd()
        {
            IsAddOrModify = true;

            _frmAdd = new();
            _frmAdd.cls = this;
            _frmAdd.Text = "Añadir tipo de material";
            _frmAdd.lblTitle.Text = "Añadir tipo de material";
            _frmAdd.ShowDialog();
        }

        public void OpenFrmModify(string? idModify)
        {
            IsAddOrModify = false;

            if (idModify.IsNullOrEmpty())
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("No se ha seleccionado un tipo de material para modificar.", "Modificar tipo de material");
                return;
            }

            idAddModify = idModify;
            _frmAdd = new();
            _frmAdd.cls = this;
            _frmAdd.Text = "Modificar tipo de material";
            _frmAdd.lblTitle.Text = "Modificar tipo de material";
            _frmAdd.ShowDialog();
        }

        private void LoadControlsModify()
        {
            entity = new();
            entity.GetMaterialType(idAddModify ?? "0");
            _frmAdd.txbId.Enabled = false;
            _frmAdd.txbId.Text = entity.idMaterialType;
            _frmAdd.txbName.Text = entity.nameMaterialType;
        }

        private EMaterialType SetMaterialTypeEntity()
        {
            entity = new();
            entity.idMaterialType = _frmAdd.txbId.Text;
            entity.nameMaterialType = _frmAdd.txbName.Text;

            return entity;
        }

        public void AddProcedure()
        {
            EMaterialType add = new();
            add = SetMaterialTypeEntity();
            var result = add.AddProcedure();
            IsAddUpdate = result.Item1;
            idAddModify = result.Item2;
        }
        public void ModifyProcedure()
        {
            EMaterialType modify = new();
            modify = SetMaterialTypeEntity();
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
                    MessageBox.Show($"Se ha agregado el tipo de material con código: {idAddModify}", "Añadir tipo de material");

                    _frmAdd.Close();
                }
                else
                {
                    SystemSounds.Exclamation.Play();
                    MessageBox.Show("No se pudo agregar el tipo de material.", "Añadir tipo de material");
                }
            }
            else
            {
                ModifyProcedure();

                if (IsModifyUpdate)
                {
                    MessageBox.Show($"Se ha modificado el tipo de material con el código: {idAddModify}", "Modificar tipo de material");

                    _frmAdd.Close();
                }
                else
                {
                    SystemSounds.Exclamation.Play();
                    MessageBox.Show("No se pudo modificar el tipo de material.", "Modificar tipo de material");
                }
            }
        }
        public void CloseFrmAddModify()
        {
            _frmAdd.Close();
        }

        public void AddNewRowByIdInDGVCatalog()
        {
            DataTable newIdRow = ClsQuerysDB.GetDataTable(queryCatalogo + $" WHERE id_matType = '{idAddModify}'");
            Clipboard.SetText(queryCatalogo + $" WHERE [{Column.id}] = '{idAddModify}'");
            dgv.AddNewRowToDGV(newIdRow);
        }

        public void ModifyRowByIdInDGVCatalog()
        {
            DataTable newIdRow = ClsQuerysDB.GetDataTable(queryCatalogo + $" WHERE id_matType = '{idAddModify}'");

            dgv.ModifyIdRowInDGV(newIdRow);
        }
    }
}
