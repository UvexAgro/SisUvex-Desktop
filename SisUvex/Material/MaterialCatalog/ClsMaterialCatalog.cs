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
using SisUvex.Catalogos.Metods.Images;

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
        private string queryCatalog = $" SELECT vw.* FROM vw_PackMaterialCatalogCat AS [vw] ";

        ClsDGVCatalog dgv;
        DataTable? dtCatalog;
        public bool IsAddOrModify = true, IsAddUpdate = false, IsModifyUpdate = false;
        public string? idAddModify;
        private string? imagesPathCatalogFolder = "\\\\SVRCAMPOSANAN\\Inventum\\MATERIALES";

        private SingleImageManager? frontImageManager, backImageManager, downImageManager, upImageManager;

        public void BeginFormCat()
        {
            _frmCat ??= new FrmMaterialCatalog();
            _frmCat.cls ??= this;

            dtCatalog = ClsQuerysDB.GetDataTable(queryCatalog);
            dgv = new ClsDGVCatalog(_frmCat.dgvCatalog, dtCatalog);

            ClsComboBoxes.CboLoadActives(_frmCat.cboDistributor, Distributor.Cbo);
            ClsComboBoxes.CboLoadAll(_frmCat.cboMaterialType, MaterialType.Cbo);
            ClsComboBoxes.CboLoadAll(_frmCat.cboColor, ClsObject.Color.Cbo);
            ClsComboBoxes.CboLoadActives(_frmCat.cboCategory, Category.Cbo);
        }

        public void BeginFormAdd()
        {
            AddControlsToList();

            LoadControlsEvents();

            if (IsAddOrModify)
            {
                _frmAdd.cboActive.SelectedIndex = 1;
                _frmAdd.txbId.Text = string.Empty; //SE CAMBIA AL SELECCIONAR UN TIPO DE MATERIAL

                InicializateImagesManagers();
            }
            else
            {
                LoadControlsModify();

                LoadAllImages(entityFrm.idMaterialCatalog);
            }

            _frmAdd.txbIdMaterialType.TextChanged += (s, e) => //CAMBIAR ID DEL MATERIAL SEGUN EL TIPO, AQUÍ DESPUÉS DEL DE CARGAR CONTROLES MODIFICAR
            {
                if (_frmAdd.txbIdMaterialType.Text.IsNullOrEmpty())
                    _frmAdd.txbId.Text = string.Empty;
                else
                    _frmAdd.txbId.Text = EMaterialCatalog.GetNextId(_frmAdd.txbIdMaterialType.Text);
            };
        }

        private void AddControlsToList()
        {
            controlList = new ClsControls();

            controlList.ChangeHeadMessage("Para dar de alta un material debe:\n");
            controlList.Add(_frmAdd.txbIdMaterialType, "Seleccionar un tipo de material.");
            controlList.Add(_frmAdd.txbId, "Ingresar el código del material.");
            controlList.Add(_frmAdd.txbName, "Ingresar un concepto para el material.");
            controlList.Add(_frmAdd.txbIdUnit, "Seleccionar una unidad.");
            controlList.Add(_frmAdd.txbIdDistributor, "Seleccionar un distribuidor.");
        }

        private void LoadControlsEvents()
        {
            ClsComboBoxes.CboLoadAll(_frmAdd.cboMaterialType, MaterialType.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboCategory, Category.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboDistributor, Distributor.Cbo);
            ClsComboBoxes.CboLoadAll(_frmAdd.cboUnit, Unit.Cbo);
            ClsComboBoxes.CboLoadAll(_frmAdd.cboColor, ClsObject.Color.Cbo);

            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboMaterialType, _frmAdd.txbIdMaterialType);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboUnit, _frmAdd.txbIdUnit);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboColor, _frmAdd.txbIdColor);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboCategory, _frmAdd.txbIdCategory);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboDistributor, _frmAdd.txbIdDistributor);

            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboDistributor, _frmAdd.chbDistributorRemoved);
            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboCategory, _frmAdd.chbCategoryRemoved);
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
                MessageBox.Show("No se ha seleccionado un material para modificar.", "Modificar material");
                return;
            }

            idAddModify = idModify;
            _frmAdd = new FrmMaterialAdd();
            _frmAdd.cls = this;
            _frmAdd.Text = "Modificar materil";
            _frmAdd.lblTitle.Text = "Modificar material";
            _frmAdd.ShowDialog();
        }
        private void LoadControlsModify()
        {
            entityFrm = new EMaterialCatalog();
            entityFrm.GetMaterialCatalog(idAddModify ?? "0");

            _frmAdd.txbId.Text = entityFrm.idMaterialCatalog;
            _frmAdd.txbName.Text = entityFrm.nameMaterialCatalog;
            _frmAdd.txbQuant.Text = entityFrm.quantity.ToString();
            _frmAdd.cboActive.SelectedIndex = entityFrm.active;

            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboMaterialType, entityFrm.idMaterialType);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboUnit, entityFrm.idUnit);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboColor, entityFrm.idColor);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboCategory, entityFrm.idCategory);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboDistributor, entityFrm.idDistributor);
        }

        private EMaterialCatalog SetMaterialCatalogEntity()
        {
            entityFrm = new EMaterialCatalog();
            entityFrm.idMaterialCatalog = _frmAdd.txbId.Text;
            entityFrm.nameMaterialCatalog = _frmAdd.txbName.Text;
            entityFrm.idMaterialType = _frmAdd.txbIdMaterialType.Text;
            entityFrm.idUnit = _frmAdd.txbIdUnit.Text;
            entityFrm.idColor = _frmAdd.txbIdColor.Text;
            entityFrm.idCategory = _frmAdd.txbIdCategory.Text;
            entityFrm.idDistributor = _frmAdd.txbIdDistributor.Text;
            entityFrm.idCategory = _frmAdd.txbIdCategory.Text;
            entityFrm.active = _frmAdd.cboActive.SelectedIndex;

            if (_frmAdd.txbQuant.Text.IsNullOrEmpty())
                entityFrm.quantity = 0;
            else
                entityFrm.quantity = Convert.ToInt32(_frmAdd.txbQuant.Text);

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

                    UpdateAllImagesMaterial();

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

                    UpdateAllImagesMaterial();

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

        private void InicializateImagesManagers()
        {
            frontImageManager = new SingleImageManager(imagesPathCatalogFolder);
            backImageManager = new SingleImageManager(imagesPathCatalogFolder);
            downImageManager = new SingleImageManager(imagesPathCatalogFolder);
            upImageManager = new SingleImageManager(imagesPathCatalogFolder);
        }

        private void LoadAllImages(string idMaterial)
        {
            InicializateImagesManagers();

            frontImageManager.LoadImage($"{idMaterial}_Front");
            backImageManager.LoadImage($"{idMaterial}_Back");
            upImageManager.LoadImage($"{idMaterial}_Up");
            downImageManager.LoadImage($"{idMaterial}_Down");

            ChbImagesClic(_frmAdd.chbImageFront);
        }



        public void BtnLoadNewImage()
        {
            if (_frmAdd.chbImageFront.Checked)
            {
                frontImageManager.LoadNewImageFromFile();
                _frmAdd.pbxMaterial.Image = frontImageManager.CurrentImage;
            }
            else if (_frmAdd.chbImageBack.Checked)
            {
                backImageManager.LoadNewImageFromFile();
                _frmAdd.pbxMaterial.Image = backImageManager.CurrentImage;
            }
            else if (_frmAdd.chbImageDown.Checked)
            {
                downImageManager.LoadNewImageFromFile();
                _frmAdd.pbxMaterial.Image = downImageManager.CurrentImage;
            }
            else if (_frmAdd.chbImageUp.Checked)
            {
                upImageManager.LoadNewImageFromFile();
                _frmAdd.pbxMaterial.Image = upImageManager.CurrentImage;
            }
        }

        public void BtnResetAllImages()
        {
            if (!_frmAdd.txbId.Text.IsNullOrEmpty())
                LoadAllImages(_frmAdd.txbId.Text);
        }

        public void ChbImagesClic(CheckBox chb)
        {
            _frmAdd.chbImageFront.Checked = false;
            _frmAdd.chbImageBack.Checked = false;
            _frmAdd.chbImageDown.Checked = false;
            _frmAdd.chbImageUp.Checked = false;
            chb.Checked = true;

            if (chb == _frmAdd.chbImageFront)
                _frmAdd.pbxMaterial.Image = frontImageManager.CurrentImage;
            else if (chb == _frmAdd.chbImageBack)
                _frmAdd.pbxMaterial.Image = backImageManager.CurrentImage;
            else if (chb == _frmAdd.chbImageDown)
                _frmAdd.pbxMaterial.Image = downImageManager.CurrentImage;
            else if (chb == _frmAdd.chbImageUp)
                _frmAdd.pbxMaterial.Image = upImageManager.CurrentImage;
        }

        public void BtnDeleteTemporalImage()
        {
            if (_frmAdd.chbImageFront.Checked)
            {
                frontImageManager.ClearNew();
                _frmAdd.pbxMaterial.Image = frontImageManager.CurrentImage;
            }
            else if (_frmAdd.chbImageBack.Checked)
            {
                backImageManager.ClearNew();
                _frmAdd.pbxMaterial.Image = backImageManager.CurrentImage;
            }
            else if (_frmAdd.chbImageDown.Checked)
            {
                downImageManager.ClearNew();
                _frmAdd.pbxMaterial.Image = downImageManager.CurrentImage;
            }
            else if (_frmAdd.chbImageUp.Checked)
            {
                upImageManager.ClearNew();
                _frmAdd.pbxMaterial.Image = upImageManager.CurrentImage;
            }
        }

        private void UpdateAllImagesMaterial()
        {
            frontImageManager.SaveImage($"{idAddModify}_Front");
            backImageManager.SaveImage($"{idAddModify}_Back");
            downImageManager.SaveImage($"{idAddModify}_Down");
            upImageManager.SaveImage($"{idAddModify}_Up");
        }

        public void Dispose() //PARA QUE FUNCIONE CON EL DISPOSE DEL FORM
        {
            frontImageManager?.Dispose();
            backImageManager?.Dispose();
            downImageManager?.Dispose();
            upImageManager?.Dispose();
        }

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
            dgv = new ClsDGVCatalog(_frmCat.dgvCatalog, dtCatalog);
        }

        public void BtnSearchMaterialWithId(string idMaterial)
        {
            Dictionary<string, object> parameters = new();
            parameters.Add("@idMaterial", idMaterial);

            string w = $" WHERE vw.[{Column.id}] = @idMaterial ";

            Clipboard.SetText(queryCatalog + w);
            dtCatalog = ClsQuerysDB.ExecuteParameterizedQuery(queryCatalog + w, parameters);
            dgv = new ClsDGVCatalog(_frmCat.dgvCatalog, dtCatalog);
        }
    }
}
