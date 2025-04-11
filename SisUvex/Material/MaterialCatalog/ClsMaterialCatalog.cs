using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.DataGridViews;
using System.Data;
using static SisUvex.Catalogos.Metods.ClsObject;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Material.MaterialWarehouses;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods;
using SisUvex.Material.Warehouses;
using Microsoft.IdentityModel.Tokens;
using System.Media;

namespace SisUvex.Material.MaterialCatalog
{
    internal class ClsMaterialCatalog
    {
        //PARA QUE NO TARDE TANTO EN CARGAR EL CATALOGO DE LOS MATERIALES, SE DEJARÁ CADA QUE CARGUE UNA BUSQUEDA, COMO CONSULTA DIRECTA DE LA BD
        SQLControl sql = new SQLControl();
        ClsControls controlList;
        public FrmMaterialAdd _frmAdd;
        public FrmMaterialCatalog _frmCat;
        private EMaterialCatalog entityFrm;
        private string queryCatalog = $" SELECT *, [{Column.active}] AS [{Column.active + "2"}] FROM vw_PackMaterialCatalogCat AS [vw] ";
        ClsDGVCatalog dgv;
        DataTable dtCatalog;
        public bool IsAddOrModify = true, IsAddUpdate = false, IsModifyUpdate = false;
        public string? idAddModify;

        public void BtnFilterDtCatalog()
        {
            string where = $" LEFT JOIN Pack_MaterialCatalog matC ON matC.id_matCatalog = vw.[{Column.id}] WHERE 1=1 ";

            Dictionary<string, object> parameters = new();

            if (_frmCat.cboDistributor.SelectedIndex > 0)
            {
                where += $" AND matC.id_distributor = @idDistributor ";
                parameters.Add("@idDistributor", _frmCat.cboDistributor.SelectedValue.ToString());
            }

            if (_frmCat.cboMaterialType.SelectedIndex > 0)
            {
                where += $" AND matC.id_matType = @idMaterialType ";
                parameters.Add("@idMaterialType", _frmCat.cboMaterialType.SelectedValue.ToString());
            }

            if (_frmCat.cboCategory.SelectedIndex > 0)
            {
                where += $" AND matC.id_category = @idCategory ";
                parameters.Add("@idCategory", _frmCat.cboCategory.SelectedValue.ToString());
            }

            if (_frmCat.cboColor.SelectedIndex > 0)
            {
                where += $" AND matC.id_color = @idColor ";
                parameters.Add("@idColor", _frmCat.cboColor.SelectedValue.ToString());
            }

            dtCatalog = ClsQuerysDB.ExecuteParameterizedQuery(queryCatalog + where, parameters);

            dgv.LoadDGVCatalogWithActiveColumn2();
        }

        public void BeginFormCat()
        {
            _frmCat ??= new FrmMaterialCatalog();
            _frmCat.cls ??= this;

            dtCatalog = ClsQuerysDB.GetDataTable(queryCatalog);
            dgv = new ClsDGVCatalog();
            dgv.dtCatalog = dtCatalog;

            _frmCat.dgvCatalog.DataSource = dtCatalog;
            dgv.dgvCatalog = _frmCat.dgvCatalog;
            dgv.LoadDGVCatalogWithActiveColumn2();

            ClsComboBoxes.CboLoadActives(_frmCat.cboDistributor, Distributor.Cbo);
            ClsComboBoxes.CboLoadAll(_frmCat.cboMaterialType, MaterialType.Cbo);
            ClsComboBoxes.CboLoadAll(_frmCat.cboColor, ClsObject.Color.Cbo);
            ClsComboBoxes.CboLoadActives(_frmCat.cboCategory, Category.Cbo);
        }

        public void BeginFormAdd()
        {
            AddControlsToList();

            LoadComboBoxes();

            if (IsAddOrModify)
            {
                _frmAdd.cboActive.SelectedIndex = 1;
                _frmAdd.txbId.Text = string.Empty; //SE CAMBIA AL SELECCIONAR UN TIPO DE MATERIAL
            }
            else
            {
                LoadControlsModify();
            }
        }

        private void AddControlsToList()
        {
            controlList = new ClsControls();

            controlList.ChangeHeadMessage("Para dar de alta un material debe:\n");
            controlList.Add(_frmAdd.txbIdMaterialType, "Seleccionar un tipo de material.");
            controlList.Add(_frmAdd.txbId, "Ingresar el código del material.");
            controlList.Add(_frmAdd.txbName, "Ingresar un nombre para el almacén.");
            controlList.Add(_frmAdd.txbIdUnit, "Seleccionar una unidad.");
        }

        private void LoadComboBoxes()
        {
            ClsComboBoxes.CboLoadAll(_frmAdd.cboMaterialType, MaterialType.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboCategory, Category.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboDistributor, Distributor.Cbo);
            ClsComboBoxes.CboLoadAll(_frmAdd.cboUnit, Unit.Cbo);
            ClsComboBoxes.CboLoadAll(_frmAdd.cboColor, ClsObject.Color.Cbo);
        }

        public void OpenFrmAdd()
        {
            IsAddOrModify = true;

            _frmAdd = new FrmMaterialAdd();
            _frmAdd.cls = this;
            _frmAdd.Text = "Añadir material";
            _frmAdd.lblTitle.Text = "Añadir material";
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
            _frmAdd = new FrmMaterialAdd();
            _frmAdd.cls = this;
            _frmAdd.Text = "Modificar almacén";
            _frmAdd.lblTitle.Text = "Modificar almacén";
            _frmAdd.ShowDialog();
        }
        private void LoadControlsModify()
        {
            entityFrm = new EMaterialCatalog();
            entityFrm.GetMaterialCatalog(idAddModify ?? "0");

            _frmAdd.txbId.Text = entityFrm.idMaterialCatalog;
            _frmAdd.txbName.Text = entityFrm.nameMaterialCatalog;
            _frmAdd.txbIdMaterialType.Text = entityFrm.idMaterialType;
            _frmAdd.txbIdUnit.Text = entityFrm.idUnit;
            _frmAdd.txbIdColor.Text = entityFrm.idColor;
            _frmAdd.txbIdCategory.Text = entityFrm.idCategory;
            _frmAdd.txbIdDistributor.Text = entityFrm.idDistributor;
            _frmAdd.cboActive.SelectedIndex = entityFrm.active;
        }

        private EMaterialCatalog SetMaterialCatalogEntity()
        {
            entityFrm = new EMaterialCatalog();
            entityFrm.idMaterialCatalog = _frmAdd.txbId.Text;
            entityFrm.nameMaterialCatalog = _frmAdd.txbName.Text;
            entityFrm.idMaterialType = _frmAdd.txbIdMaterialType.Text;
            entityFrm.quantity = Convert.ToInt32(_frmAdd.txbQuant.Text);
            entityFrm.idUnit = _frmAdd.txbIdUnit.Text;
            entityFrm.idColor = _frmAdd.txbIdColor.Text;
            entityFrm.idCategory = _frmAdd.txbIdCategory.Text;
            entityFrm.idDistributor = _frmAdd.txbIdDistributor.Text;
            entityFrm.idCategory = _frmAdd.txbIdCategory.Text;
            entityFrm.active = _frmAdd.cboActive.SelectedIndex;

            return entityFrm;
        }
        public void AddProcedure()
        {
            EMaterialCatalog addEntity = new();
            addEntity = SetMaterialCatalogEntity();
            var result = addEntity.AddProcedure();
            IsAddUpdate = result.Item1;
            idAddModify = result.Item2;
        }

        public void ModifyProcedure()
        {
            EMaterialCatalog modifyEntity = new();
            modifyEntity = SetMaterialCatalogEntity();
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
                    MessageBox.Show($"Se ha agregado el material con código: {idAddModify}", "Añadir material");

                    _frmAdd.Close();
                }
                else
                {
                    SystemSounds.Exclamation.Play();
                    MessageBox.Show("No se pudo agregar el material.", "Añadir material");
                }
            }
            else
            {
                ModifyProcedure();

                if (IsModifyUpdate)
                {
                    MessageBox.Show($"Se ha modificado el material con el código: {idAddModify}", "Modificar material");

                    _frmAdd.Close();
                }
                else
                {
                    SystemSounds.Exclamation.Play();
                    MessageBox.Show("No se pudo modificar el material.", "Modificar material");
                }
            }
        }

        public void CloseFrmAddModify()
        {
            _frmAdd.Close();
        }

        public void BtnActiveProcedure(string id, string activeValue)
        {
            bool result = EMaterialCatalog.ActiveProcedure(id, activeValue);

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
    }
}
