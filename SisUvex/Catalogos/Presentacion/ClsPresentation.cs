using System.Data;
using System.Data.SqlClient;
using System.Media;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.CheckBoxes;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.DataGridViews;
using SisUvex.Catalogos.Metods;
using System.Windows.Forms;
using SisUvex.Catalogos.Metods.Querys;

namespace SisUvex.Catalogos.Presentacion
{

    internal class ClsPresentation : ClsCatalogos
    {
        SQLControl sql = new SQLControl();
        ClsControls controlList;
        private FrmPresentationAdd _frmAdd;
        public FrmPresentationCat _frmCat;
        public EPresentacion ePresentacion;
        public ClsDataGridViewCatalogs dgv = new ClsDataGridViewCatalogs();
        private string queryCatalogo = "SELECT * FROM vw_PackPresentationCat";
        public DataTable dtCatalogo;
        public DataTable dtCatalogoActivos;

        public ClsPresentation()
        {
            _frmCat = new FrmPresentationCat(this);

            _frmAdd = new FrmPresentationAdd(_frmCat, this);
        }
        public void BeginFormAdd()
        {
            AddControlsToList();

            CargarComboBoxes();

            if (_frmAdd.IsAddModify)
            {
                _frmAdd.chbActive.Checked = true;
                _frmAdd.txbId.Text = ClsQuerysDB.GetData("SELECT FORMAT(COALESCE(MAX(id_presentation), 0) +1, '0000') FROM Pack_Presentation").ToString();
            }
            else
            {
                LoadControlsModify();
            }
        }

        public void BeginFormCat()
        {
            dgv.queryCatalog = queryCatalogo;
            dgv.dgvCatalog = _frmCat.dgvCatalog;
            dgv.btnRemoved = _frmCat.btnRemoved;

            dgv.LoadDataTableCatalog();

            _frmCat.dgvCatalog.DataSource = dgv.GetDataTableCatalogActives();

            ClsDataGridViewCatalogs.DgvApplyCellFormattingEvent(_frmCat.dgvCatalog);
        }

        private void AddControlsToList()
        {
            controlList = new ClsControls();

            controlList.ChangeHeadMessage("Para dar de alta una presentación debe:\n");

            controlList.Add(_frmAdd.txbName, "Ingresar nombre de la presentación.");
            controlList.Add(_frmAdd.txbIdCategory, "Seleccionar una categoría.");
            controlList.Add(_frmAdd.txbIdCrop, "Seleccionar un cultivo.");
            controlList.Add(_frmAdd.txbIdColor, "Seleccionar un color.");
            controlList.Add(_frmAdd.cboMarket, "Seleccionar un mercado.");
        }

        private void CargarComboBoxes()
        {
            ClsComboBoxes.CboLoadActives(_frmAdd.cboCategory, ClsObject.Category.Cbo);
            ClsComboBoxes.CboLoadAll(_frmAdd.cboCrop, ClsObject.Crop.Cbo);
            ClsComboBoxes.CboLoadAll(_frmAdd.cboColor, ClsObject.Color.Cbo);

            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboCategory, _frmAdd.txbIdCategory);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboCrop, _frmAdd.txbIdCrop);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboColor, _frmAdd.txbIdColor);

            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboCategory, _frmAdd.chbActiveCategory);
        }

        

        public void OpenFrmAdd()
        {
            _frmAdd = new FrmPresentationAdd(_frmCat, this);
            _frmAdd.Text = "Añadir Presentación";
            _frmAdd.lblTitle.Text = "Añadir Presentación";
            _frmAdd.IsAddModify = true;

            _frmAdd.ShowDialog();

            dgv.UpdateCatalogAfterAddModify(_frmAdd.AddIsUpdate);
        }

        public void OpenFrmModify()
        {
            if (_frmCat.dgvCatalog.SelectedRows.Count != 0)
            {
                _frmAdd = new FrmPresentationAdd(_frmCat, this);
                _frmAdd.Text = "Modificar Presentación";
                _frmAdd.lblTitle.Text = "Modificar Presentación";
                _frmAdd.IsAddModify = false;

                _frmAdd.idModify = _frmCat.dgvCatalog.SelectedRows[0].Cells[ClsObject.Column.id].Value.ToString();

                _frmAdd.ShowDialog();

                dgv.UpdateCatalogAfterAddModify(_frmAdd.AddIsUpdate);
            }
            else
            {
                SystemSounds.Exclamation.Play();
            }
        }

        private void LoadControlsModify()
        {
            ePresentacion = new EPresentacion();

            ePresentacion.SetPresentation(_frmAdd.idModify);

            _frmAdd.txbId.Text = ePresentacion.IdPresentation;
            _frmAdd.txbName.Text = ePresentacion.NamePresentation;
            _frmAdd.txbIdCategory.Text = ePresentacion.IdCategory;
            _frmAdd.txbIdCrop.Text = ePresentacion.IdCrop;
            _frmAdd.txbIdColor.Text = ePresentacion.IdColor;
            _frmAdd.cboMarket.Text = ePresentacion.Market;
            _frmAdd.chbActive.Checked = ePresentacion.Active == 1;

            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboCategory, _frmAdd.txbIdCategory);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboCrop, _frmAdd.txbIdCrop);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboColor, _frmAdd.txbIdColor);
        }

        public void AddProcedure()
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackPresentationAdd", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", _frmAdd.txbName.Text);
                cmd.Parameters.AddWithValue("@idCategory", _frmAdd.txbIdCategory.Text);
                cmd.Parameters.AddWithValue("@idCrop", _frmAdd.txbIdCrop.Text);
                cmd.Parameters.AddWithValue("@idColor", _frmAdd.txbIdColor.Text);
                cmd.Parameters.AddWithValue("@userCreate", User.GetUserName());
                cmd.Parameters.AddWithValue("@marketTarget", _frmAdd.cboMarket.Text);
                cmd.Parameters.AddWithValue("@active", ClsCheckBoxes.GetCheckedValue(_frmAdd.chbActive));

                string id = cmd.ExecuteScalar().ToString();

                MessageBox.Show("Se agregó la presentación: " + id, "Catálogo añadir", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo añadir");
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }

        public void ModifyProcedure()
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackPresentationModify", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", _frmAdd.txbId.Text);
                cmd.Parameters.AddWithValue("@name", _frmAdd.txbName.Text);
                cmd.Parameters.AddWithValue("@idCategory", _frmAdd.txbIdCategory.Text);
                cmd.Parameters.AddWithValue("@idCrop", _frmAdd.txbIdCrop.Text);
                cmd.Parameters.AddWithValue("@idColor", _frmAdd.txbIdColor.Text);
                cmd.Parameters.AddWithValue("@userUpdate", User.GetUserName());
                cmd.Parameters.AddWithValue("@marketTarget", _frmAdd.cboMarket.Text);
                cmd.Parameters.AddWithValue("@active", ClsCheckBoxes.GetCheckedValue(_frmAdd.chbActive));

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo modificar");
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }

        public void RemoveProcedure()
        {
            dgv.ProcedureRemove("sp_PackPresentationRemove");
        }
        public void RecoverProcedure()
        {
            dgv.ProcedureRecover("sp_PackPresentationRecover");
        }

        public void btnAcceptAddModify()
        {
            if (!controlList.ValidateControls())
                return;
            
            if (_frmAdd.IsAddModify)
            {
                AddProcedure();
            }
            else
            {
                ModifyProcedure();
            }

            _frmAdd.AddIsUpdate = true;

            _frmAdd.Close();
        }
    }//ClsPresentacion
}//SisUvex.Catalogos.Presentacion