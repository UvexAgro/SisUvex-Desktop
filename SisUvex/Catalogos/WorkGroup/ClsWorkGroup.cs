using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.DataGridViews;
using SisUvex.Catalogos.Metods.Querys;
using System.Data.SqlClient;
using System.Data;
using System.Media;
using SisUvex.Catalogos.Metods.CheckBoxes;
using SisUvex.Catalogos.Metods.Forms.SelectionForms;
using Microsoft.IdentityModel.Tokens;

namespace SisUvex.Catalogos.WorkGroup
{
    internal class ClsWorkGroup
    {
        SQLControl sql = new SQLControl();
        ClsControls controlList;
        public FrmWorkGroupAdd _frmAdd;
        public FrmWorkGroupCat _frmCat;
        public EWorkGroup eWorkGroup;
        public ClsDataGridViewCatalogs dgv = new ClsDataGridViewCatalogs();
        private string queryCatalogo = "SELECT * FROM vw_PackWorkGroupCat";
        public DataTable dtCatalogo;
        public DataTable dtCatalogoActivos;
        public void BeginFormAdd()
        {
            AddControlsToList();

            CargarComboBoxes();

            if (_frmAdd.IsAddModify)
            {
                _frmAdd.chbActive.Checked = true;
                _frmAdd.txbId.Text = ClsQuerysDB.GetData("SELECT FORMAT(COALESCE(MAX(id_workGroup), 0) +1, '00') FROM Pack_WorkGroup").ToString();
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

            controlList.ChangeHeadMessage("Para dar de alta una cuadrilla debe:\n");
            controlList.Add(_frmAdd.txbId, "Ingresar un número de cuadrilla.");
            controlList.Add(_frmAdd.txbIdContractor, "Seleccionar un contratista.");
            controlList.Add(_frmAdd.txbIdSeason, "Seleccionar una temporada.");
        }
        private void CargarComboBoxes()
        {
            ClsComboBoxes.CboLoadActives(_frmAdd.cboContractor, ClsObject.Contractor.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboSeason, ClsObject.Season.Cbo); //FALTA AÑADIR LA TEMPORADA

            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboContractor, _frmAdd.txbIdContractor);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboSeason, _frmAdd.txbIdSeason);

            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboContractor, _frmAdd.chbActiveContractor);
        }

        public void OpenFrmAdd()
        {
            _frmAdd = new FrmWorkGroupAdd();
            _frmAdd.cls = this;
            _frmAdd.Text = "Añadir cuadrilla";
            _frmAdd.lblTitle.Text = "Añadir cuadrilla";
            _frmAdd.IsAddModify = true;

            _frmAdd.ShowDialog();

            dgv.UpdateCatalogAfterAddModify(_frmAdd.AddIsUpdate);
        }

        public void OpenFrmModify()
        {
            if (_frmCat.dgvCatalog.SelectedRows.Count != 0)
            {
                _frmAdd = new FrmWorkGroupAdd();
                _frmAdd.Text = "Modificar cuadrilla";
                _frmAdd.lblTitle.Text = "Modificar cuadrilla";
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
            eWorkGroup = new EWorkGroup();

            eWorkGroup.SetWorkGroup(_frmAdd.idModify);

            _frmAdd.txbId.Text = eWorkGroup.IdWorkGroup;
            _frmAdd.txbName.Text = eWorkGroup.NameWorkGroup;
            _frmAdd.txbIdContractor.Text = eWorkGroup.IdContractor;
            _frmAdd.txbIdSeason.Text = eWorkGroup.IdSeason;
            _frmAdd.chbActive.Checked = eWorkGroup.Active == 1;

            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboContractor, _frmAdd.txbIdContractor);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboSeason, _frmAdd.txbIdSeason);
        }

        public void AddProcedure()
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackWorkGroupAdd", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", _frmAdd.txbId.Text);
                cmd.Parameters.AddWithValue("@active", ClsCheckBoxes.GetCheckedValue(_frmAdd.chbActive));
                cmd.Parameters.AddWithValue("@name", _frmAdd.txbName.Text);
                cmd.Parameters.AddWithValue("@idContractor", _frmAdd.txbIdContractor.Text);
                cmd.Parameters.AddWithValue("@idSeason", _frmAdd.txbIdSeason.Text);
                cmd.Parameters.AddWithValue("@userCreate", User.GetUserName());

                cmd.ExecuteNonQuery();

                MessageBox.Show("Se agregó la cuadrilla: " + _frmAdd.txbId.Text, "Catálogo añadir", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                SqlCommand cmd = new SqlCommand("sp_PackWorkGroupModify", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", _frmAdd.txbId.Text);
                cmd.Parameters.AddWithValue("@active", ClsCheckBoxes.GetCheckedValue(_frmAdd.chbActive));
                cmd.Parameters.AddWithValue("@name", _frmAdd.txbName.Text);
                cmd.Parameters.AddWithValue("@idContractor", _frmAdd.txbIdContractor.Text);
                cmd.Parameters.AddWithValue("@idSeason", _frmAdd.txbIdSeason.Text);
                cmd.Parameters.AddWithValue("@userUpdate", User.GetUserName());

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
            dgv.ProcedureRemove("sp_PackWorkGroupRemove");
        }

        public void RecoverProcedure()
        {
            dgv.ProcedureRecover("sp_PackWorkGroupRecover");
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

        public void btnSearchContractor()
        {
            ClsSelectionForm sel = new ClsSelectionForm();

            sel.OpenSelectionForm("Contractor", "Código");

            if (!sel.SelectedValue.IsNullOrEmpty())
            {
                _frmAdd.txbIdContractor.Text = sel.SelectedValue;

                ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboContractor, _frmAdd.txbIdContractor);
            }
        }
    }
}
