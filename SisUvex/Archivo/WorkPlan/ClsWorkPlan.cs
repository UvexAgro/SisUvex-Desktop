using System.Data;
using System.Data.SqlClient;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.DataGridViews;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.Querys;
using System.Media;
using static SisUvex.Catalogos.Metods.ClsObject;
using SisUvex.Catalogos.Metods.CheckBoxes;

namespace SisUvex.Archivo.WorkPlan
{
    internal  class ClsWorkPlan : ClsWorkPlanEventsControls
    {
        SQLControl sql = new SQLControl();
        ClsControls controlList;
        public FrmWorkPlanAdd _frmAdd;
        public FrmWorkPlanCat _frmCat;
        public EworkPlan eWorkPlan;
        //private string queryCatalog = "SELECT * FROM vw_PackWorkPlanCat";
        public DataTable dtCatalog = new DataTable();
        public string filter;

        public ClsWorkPlan()
        {
            _frmCat = new FrmWorkPlanCat(this);
            _frmAdd = new FrmWorkPlanAdd(_frmCat, this);
            clsWP = this;
        }
        public void BeginFormCat()
        {   
            _frmCat.dtpDate1.Value = DateTime.Now;
            _frmCat.dtpDate2.Value = DateTime.Now;
            _frmCat.WindowState = FormWindowState.Maximized;

            ClsComboBoxes.CboLoadActives(_frmCat.cboDistribuidor, Distributor.Cbo);
            ClsComboBoxes.CboLoadActives(_frmCat.cboPresentacion, Presentation.Cbo);
            ClsComboBoxes.CboLoadActives(_frmCat.cboVariety, Variety.Cbo);
            ClsComboBoxes.CboLoadActives(_frmCat.cboContainer, Container.Cbo);
            ClsComboBoxes.CboLoadActives(_frmCat.cboWorkGroup, WorkGroup.Cbo);
            ClsComboBoxes.CboLoadActives(_frmCat.cboLot, Lot.Cbo);

            LoadDataGridViewCatalog();
            ClsDataGridViewCatalogs.DgvApplyCellFormattingEvent(_frmCat.dgvCatalog);
        }
        public void RemoveProcedure()
        {
            ProcedureRemove("sp_PackWorkPlanRemove");
        }
        public void RecoverProcedure()
        {
            ProcedureRecover("sp_PackWorkPlanRecover");
        }
        public void OpenFrmAdd()
        {
            _frmAdd = new FrmWorkPlanAdd(_frmCat, this);
            _frmAdd.Text = "Añadir plan de trabajo";
            _frmAdd.lblTitle.Text = "Añadir plan de trabajo";
            _frmAdd.IsAddModify = true;
            _frmAdd.ShowDialog();
        }
        public void BeginFormAdd()
        {
            AddControlsToList();
            SetControls();
            if (_frmAdd.IsAddModify)
            {
                _frmAdd.chbActive.Checked = true;
                _frmAdd.txbId.Text = ClsQuerysDB.GetData("SELECT FORMAT(COALESCE(MAX(id_workPLan), 0) + 1, '0000') FROM Pack_WorkPlan").ToString();
            }
            else
                LoadControlsModify();
        }
        private void AddControlsToList()
        {
            controlList = new ClsControls();
            controlList.ChangeHeadMessage("Para dar de alta un plan de trabajo debe:\n");
            controlList.Add(_frmAdd.dtpDateWorkPlan, "Seleccione una fecha.");
            controlList.Add(_frmAdd.txbIdWorkGroup, "Seleccionar una cuadrilla.");
            controlList.Add(_frmAdd.txbIdLot, "Seleccionar un lote.");
            controlList.Add(_frmAdd.txbIdSize, "Seleccionar un tamaño.");
            controlList.Add(_frmAdd.txbIdGTIN, "Seleccionar un GTIN.");
            controlList.Add(_frmAdd.txbVPC, "Generar un voice pick code.");
        }
        private void SetControls()
        {
            ClsComboBoxes.CboLoadActives(_frmAdd.cboWorkGroup, WorkGroup.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboLot, Lot.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboSize, ClsObject.Size.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboVariety, Variety.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboDistributor, Distributor.Cbo);

            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboWorkGroup, _frmAdd.txbIdWorkGroup);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboSize, _frmAdd.txbIdSize);
            CboApplyTextChangedEventInWorkPlanForLot(_frmAdd.cboLot, _frmAdd.txbIdLot);
            CboApplyTextChangedEventInWorkPlanForVariety(_frmAdd.cboVariety, _frmAdd.txbIdVariety);
            CboApplyTextChangedEventInWorkPlanForDistributor(_frmAdd.cboDistributor, _frmAdd.txbIdDistributor);

            CboApplyClickEventChbLotInWorkPlanForLot(_frmAdd.cboLot, _frmAdd.chbLotActives);
            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboSize, _frmAdd.chbSizeActives);
            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboVariety, _frmAdd.chbVarietyActives);
            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboWorkGroup, _frmAdd.chbWorkGroupActives);
            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboDistributor, _frmAdd.chbDistributorActives);

            DgvLoadActives(_frmAdd.dgvGTIN, Gtin.DgvForWorkPlan);
            CboApplyClickEventChbGtinActivesForDgv(_frmAdd.chbGtinActives);

            CboApplyValueChangedEventDateTimePicker(_frmAdd.dtpDateWorkPlan);
        }

        private void LoadControlsModify()
        {
            eWorkPlan = new EworkPlan();

            eWorkPlan.SetWorkPlan(_frmAdd.idModify);
            _frmAdd.txbId.Text = eWorkPlan.IdWorkPlan;
            _frmAdd.txbIdVariety.Text = eWorkPlan.IdVariety;
            _frmAdd.txbIdLot.Text = eWorkPlan.IdLot + "|" + eWorkPlan.IdVariety;
            _frmAdd.txbIdWorkGroup.Text = eWorkPlan.IdWorkGroup;
            _frmAdd.txbIdSize.Text = eWorkPlan.Size;
            _frmAdd.dtpDateWorkPlan.Value = eWorkPlan.WorkDay;
            _frmAdd.chbActive.Checked = eWorkPlan.Active == 1;

            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboSize, _frmAdd.txbIdSize);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboWorkGroup, _frmAdd.txbIdWorkGroup);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboVariety, _frmAdd.txbIdVariety);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboLot, _frmAdd.txbIdLot);

            _frmAdd.txbIdGTIN.Text = eWorkPlan.IdGtin;
            _frmAdd.txbVPC.Text = eWorkPlan.VPC;

            SetDgvFilterGTINBeginModify();
        }

        public void OpenFrmModify()
        {
            if (_frmCat.dgvCatalog.SelectedRows.Count != 0)
            {
                _frmAdd = new FrmWorkPlanAdd(_frmCat, this);
                _frmAdd.Text = "Modificar plan de trabajo";
                _frmAdd.lblTitle.Text = "Modificar plan de trabajo";
                _frmAdd.IsAddModify = false;
                _frmAdd.idModify = _frmCat.dgvCatalog.SelectedRows[0].Cells[Column.id].Value.ToString();
                _frmAdd.ShowDialog();
            }
            else
                SystemSounds.Exclamation.Play();
        }

        public void SelectGTIN()
        {
            if (_frmAdd.dgvGTIN.SelectedRows.Count != 0)
            {
                _frmAdd.txbIdGTIN.Text = _frmAdd.dgvGTIN.SelectedRows[0].Cells[Column.id].Value.ToString();
                GenerarVoicePickCode();
            }
            else
                SystemSounds.Exclamation.Play();
        }

        private bool IsWorkPlanAvailable()
        {
            string idLot = _frmAdd.txbIdLot.Text.Substring(0,4);
            string idVariety = _frmAdd.txbIdLot.Text.Substring(5, 2);
            string query = $"SELECT id_workPlan AS 'Count' FROM Pack_WorkPlan wpl JOIN Pack_GTIN gtn ON gtn.id_GTIN = wpl.id_GTIN JOIN Pack_Lot lot ON lot.id_lot = wpl.id_lot AND gtn.id_variety = lot.id_variety WHERE wpl.id_lot = '{idLot}' AND wpl.id_GTIN = '{_frmAdd.txbIdGTIN.Text}' AND wpl.d_workDay = '{_frmAdd.dtpDateWorkPlan.Value.ToString("yyyy-MM-dd")}' AND wpl.id_workGroup = '{_frmAdd.txbIdWorkGroup.Text}' AND wpl.id_size = '{_frmAdd.txbIdSize.Text}' AND gtn.id_variety = '{idVariety}'";

            string result = ClsQuerysDB.GetData(query);

            if (result.Length == 0)
                return true;
            else if (!_frmAdd.IsAddModify && result == _frmAdd.txbId.Text)
                return true;

            SystemSounds.Exclamation.Play();
            MessageBox.Show($"Ya existe un Plan de trabajo para esa combinación.\n\tPlan de trabajo: {result}", "Plan de trabajo ya existe", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        public void btnAcceptAddModify()
        {
            if (!controlList.ValidateControls())
                return;

            if (!IsWorkPlanAvailable())
                return;

            if (_frmAdd.IsAddModify)
                AddProcedure();
            else
               ModifyProcedure();

            if (_frmAdd.AddIsUpdate)
            {
                LoadDataGridViewCatalog();
                _frmAdd.Close();
            }
        }
        public void AddProcedure()
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackWorkPlanAdd", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@active", ClsCheckBoxes.GetCheckedValue(_frmAdd.chbActive));
                cmd.Parameters.AddWithValue("@idLot", _frmAdd.txbIdLot.Text);
                cmd.Parameters.AddWithValue("@idWorkGroup", _frmAdd.txbIdWorkGroup.Text);
                cmd.Parameters.AddWithValue("@idGtin", _frmAdd.txbIdGTIN.Text);
                cmd.Parameters.AddWithValue("@voicePickCode", _frmAdd.txbVPC.Text);
                cmd.Parameters.AddWithValue("@workDay", _frmAdd.dtpDateWorkPlan.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@idSize", _frmAdd.txbIdSize.Text);
                cmd.Parameters.AddWithValue("@userCreate", User.GetUserName());

                string id = cmd.ExecuteScalar().ToString();

                _frmAdd.AddIsUpdate = true;

                MessageBox.Show("Se agregó el plan de trabajo: " + id, "Catálogo añadir", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                SqlCommand cmd = new SqlCommand("sp_PackWorkPlanModify", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", _frmAdd.txbId.Text);
                cmd.Parameters.AddWithValue("@active", ClsCheckBoxes.GetCheckedValue(_frmAdd.chbActive));
                cmd.Parameters.AddWithValue("@idLot", _frmAdd.txbIdLot.Text);
                cmd.Parameters.AddWithValue("@idWorkGroup", _frmAdd.txbIdWorkGroup.Text);
                cmd.Parameters.AddWithValue("@idGtin", _frmAdd.txbIdGTIN.Text);
                cmd.Parameters.AddWithValue("@voicePickCode", _frmAdd.txbVPC.Text);
                cmd.Parameters.AddWithValue("@workDay", _frmAdd.dtpDateWorkPlan.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@idSize", _frmAdd.txbIdSize.Text);

                cmd.Parameters.AddWithValue("@userUpdate", User.GetUserName());

                cmd.ExecuteNonQuery();

                _frmAdd.AddIsUpdate = true;
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

        public void BtnSearch()
        {
            LoadDataGridViewCatalog();
        }
    }
}
