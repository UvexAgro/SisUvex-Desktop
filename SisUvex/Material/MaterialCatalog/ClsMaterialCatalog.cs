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
using SisUvex.Catalogos.Metods.TextBoxes;

namespace SisUvex.Material.MaterialCatalog
{
    internal class ClsMaterialCatalog
    {
        //PARA QUE NO TARDE TANTO EN CARGAR EL CATALOGO DE LOS MATERIALES, SE DEJARÁ CADA QUE CARGUE UNA BUSQUEDA, COMO CONSULTA DIRECTA DE LA BD
        ClsControls controlList;
        public FrmMaterialAdd _frmAdd;
        public FrmMaterialCatalog _frmCat;
        private EMaterialCatalog entity;
        private string queryCatalog = $" SELECT vw.* FROM vw_PackMaterialCatalogCat AS [vw] ";

        ClsDGVCatalog dgv;
        DataTable? dtCatalog;
        public bool IsAddOrModify = true, IsAddUpdate = false, IsModifyUpdate = false;
        public string? idAddModify;
        private string? imagesPathCatalogFolder = string.Empty;

        private SingleImageManager? frontImageManager, backImageManager, downImageManager, upImageManager;

        public void BeginFormCat()
        {
            _frmCat ??= new();
            _frmCat.cls ??= this;

            dtCatalog = ClsQuerysDB.GetDataTable(queryCatalog);
            dgv = new ClsDGVCatalog(_frmCat.dgvCatalog, dtCatalog);

            ClsComboBoxes.CboLoadActives(_frmCat.cboDistributor, Distributor.Cbo);
            ClsComboBoxes.CboLoadAll(_frmCat.cboMaterialType, ClsObject.MaterialType.Cbo);
            ClsComboBoxes.CboLoadAll(_frmCat.cboColor, ClsObject.Color.Cbo);
            ClsComboBoxes.CboLoadActives(_frmCat.cboCategory, Category.Cbo);
        }

        public void BeginFormAdd()
        {
            AddControlsToList();

            LoadControlsEvents();

            imagesPathCatalogFolder = ClsQuerysDB.GetData("SELECT v_valueParameters FROM Conf_Parameters WHERE id_typeParameter = '02' AND id_parameter = '007'");

            if (IsAddOrModify)
            {
                _frmAdd.cboActive.SelectedIndex = 1;
                _frmAdd.txbId.Text = string.Empty; //SE CAMBIA AL SELECCIONAR UN TIPO DE MATERIAL
                TxbPrefixApplyEvents();
                InicializateImagesManagers();
            }
            else
            {
                LoadControlsModify();

                LoadAllImages(entity.idMaterialCatalog);
            }
        }

        private void AddControlsToList()
        {
            controlList = new();

            controlList.ChangeHeadMessage("Para dar de alta un material debe:\n");
            controlList.Add(_frmAdd.txbPrefix, "Ingresar un prefijo para él código de material.");
            controlList.Add(_frmAdd.txbId, "Ingresar el código del material.");
            controlList.Add(_frmAdd.txbIdMaterialType, "Seleccionar un tipo de material.");
            controlList.Add(_frmAdd.txbName, "Ingresar un concepto para el material.");
            controlList.Add(_frmAdd.txbIdUnit, "Seleccionar una unidad.");
            controlList.Add(_frmAdd.txbIdDistributor, "Seleccionar un distribuidor.");
        }

        private void LoadControlsEvents()
        {
            ClsComboBoxes.CboLoadAll(_frmAdd.cboMaterialType, ClsObject.MaterialType.Cbo);
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

            ClsTextBoxes.TxbApplyKeyPressEventInt(_frmAdd.txbQuant);
        }

        public void OpenFrmAdd()
        {
            idAddModify = null;
            entity = null;
            IsAddOrModify = true;
            IsAddUpdate = false;

            _frmAdd = new();
            _frmAdd.cls = this;
            _frmAdd.Text = "Añadir material";
            _frmAdd.lblTitle.Text = "Añadir material";
            _frmAdd.ShowDialog();
        }

        public void OpenFrmModify(string? idModify)
        {
            IsAddOrModify = false;
            IsModifyUpdate = false;

            if (idModify.IsNullOrEmpty())
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("No se ha seleccionado un material para modificar.", "Modificar material");
                return;
            }

            idAddModify = idModify;
            _frmAdd = new();
            _frmAdd.cls = this;
            _frmAdd.Text = "Modificar material";
            _frmAdd.lblTitle.Text = "Modificar material";
            _frmAdd.ShowDialog();
        }
        private void LoadControlsModify()
        {
            entity = new();
            entity.GetMaterialCatalog(idAddModify ?? "0");

            _frmAdd.cboMaterialType.Enabled = false;
            _frmAdd.txbPrefix.Text = entity.idMaterialCatalog?.Substring(0, 2);
            _frmAdd.txbId.Text = entity.idMaterialCatalog;
            _frmAdd.txbName.Text = entity.nameMaterialCatalog;
            _frmAdd.txbQuant.Text = entity.quantity.ToString();
            _frmAdd.cboActive.SelectedIndex = entity.active;

            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboMaterialType, entity.idMaterialType);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboUnit, entity.idUnit);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboColor, entity.idColor);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboCategory, entity.idCategory);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboDistributor, entity.idDistributor);
        }

        private EMaterialCatalog SetMaterialCatalogEntity()
        {
            entity = new();
            entity.prefix = _frmAdd.txbPrefix.Text;
            entity.idMaterialCatalog = _frmAdd.txbId.Text;
            entity.nameMaterialCatalog = _frmAdd.txbName.Text;
            entity.idMaterialType = _frmAdd.txbIdMaterialType.Text;
            entity.idUnit = _frmAdd.txbIdUnit.Text;
            entity.idColor = _frmAdd.txbIdColor.Text;
            entity.idCategory = _frmAdd.txbIdCategory.Text;
            entity.idDistributor = _frmAdd.txbIdDistributor.Text;
            entity.idCategory = _frmAdd.txbIdCategory.Text;
            entity.active = _frmAdd.cboActive.SelectedIndex;

            if (_frmAdd.txbQuant.Text.IsNullOrEmpty())
                entity.quantity = 0;
            else
                entity.quantity = Convert.ToInt32(_frmAdd.txbQuant.Text);

            return entity;
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
            if (!IsImagesFolderPathValide())
                return;

            frontImageManager = new SingleImageManager(imagesPathCatalogFolder);
            backImageManager = new SingleImageManager(imagesPathCatalogFolder);
            downImageManager = new SingleImageManager(imagesPathCatalogFolder);
            upImageManager = new SingleImageManager(imagesPathCatalogFolder);
        }

        private void LoadAllImages(string idMaterial)
        {
            if (!IsImagesFolderPathValideWithMessageBox())
                return;

            InicializateImagesManagers();

            frontImageManager.LoadImage($"{idMaterial}_Front");
            backImageManager.LoadImage($"{idMaterial}_Back");
            upImageManager.LoadImage($"{idMaterial}_Up");
            downImageManager.LoadImage($"{idMaterial}_Down");

            ChbImagesClic(_frmAdd.chbImageFront);
        }



        public void BtnLoadNewImage()
        {
            if (!IsImagesFolderPathValideWithMessageBox())
                return;

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
            if (!IsImagesFolderPathValideWithMessageBox())
                return;

            if (!_frmAdd.txbId.Text.IsNullOrEmpty())
                LoadAllImages(_frmAdd.txbId.Text);
        }

        public void ChbImagesClic(CheckBox chb)
        {
            if (!IsImagesFolderPathValideWithMessageBox())
                return;

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
            if (!IsImagesFolderPathValideWithMessageBox())
                return;

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
            if(!IsImagesFolderPathValideWithMessageBox())
                return;

            frontImageManager.SaveImage($"{idAddModify}_Front");
            backImageManager.SaveImage($"{idAddModify}_Back");
            downImageManager.SaveImage($"{idAddModify}_Down");
            upImageManager.SaveImage($"{idAddModify}_Up");
        }

        public void Dispose() //PARA QUE FUNCIONE CON EL DISPOSE DEL FORM
        {
            if (!IsImagesFolderPathValideWithMessageBox())
                return;

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

        private bool IsImagesFolderPathValideWithMessageBox()
        {
            if (string.IsNullOrEmpty(imagesPathCatalogFolder) || !Directory.Exists(imagesPathCatalogFolder))
            {
                MessageBox.Show("No se ha encontrado la carpeta de imágenes del catálogo de materiales.", "Carpeta imágenes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        private bool IsImagesFolderPathValide()
        {
            if (string.IsNullOrEmpty(imagesPathCatalogFolder) || !Directory.Exists(imagesPathCatalogFolder))
            {
                MessageBox.Show("No se ha encontrado la carpeta de imágenes del catálogo de materiales.", "Carpeta imágenes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }
        ////pfefijo

        private void TxbPrefixApplyEvents()
        {
            _frmAdd.txbPrefix.KeyPress += txbPrefix_KeyPress;
            _frmAdd.txbPrefix.TextChanged += txbPrefix_TextChanged;
            _frmAdd.txbPrefix.KeyDown += txbPrefix_KeyDown;
        }

        private void txbPrefix_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo letras y números
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

            // Convertir a mayúsculas automáticamente
            if (char.IsLetter(e.KeyChar))
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }

            // Limitar a 2 caracteres
            if (_frmAdd.txbPrefix.Text.Length >= 2 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txbPrefix_TextChanged(object sender, EventArgs e)
        {
            // Limpiar el ID si el prefijo no tiene exactamente 2 caracteres
            if (_frmAdd.txbPrefix.Text.Length != 2)
            {
                _frmAdd.txbId.Text = string.Empty;
                return;
            }

            // Validar y buscar el siguiente ID solo cuando tenga exactamente 2 caracteres válidos
            if (IsValidPrefix(_frmAdd.txbPrefix.Text))
            {
                _frmAdd.txbId.Text = EMaterialCatalog.GetNextId(_frmAdd.txbPrefix.Text);
            }
            else
            {
                _frmAdd.txbId.Text = string.Empty;
            }
        }

        private bool IsValidPrefix(string prefix)
        {
            // Validación adicional si necesitas asegurar que cumple con ciertas reglas
            return prefix.Length == 2 && prefix.All(c => char.IsLetterOrDigit(c));
        }

        // Para prevenir el pegado de texto no deseado
        private void txbPrefix_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;

                // Pegar solo si el texto es válido
                var clipboardText = Clipboard.GetText();
                if (clipboardText.Length >= 2 && clipboardText.All(c => char.IsLetterOrDigit(c)))
                {
                    var validText = new string(clipboardText.Where(c => char.IsLetterOrDigit(c)).Take(2).ToArray());
                    _frmAdd.txbPrefix.Text = validText.ToUpper();
                    _frmAdd.txbPrefix.SelectionStart = _frmAdd.txbPrefix.Text.Length;
                }
            }
        }
    }
}
