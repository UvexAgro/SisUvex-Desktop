using DocumentFormat.OpenXml.Bibliography;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.DataGridViews;
using SisUvex.Catalogos.Metods.Forms;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Catalogos.WorkGroup;
using System.Data;
using System.Media;
using static SisUvex.Catalogos.Metods.ClsObject;

namespace SisUvex.Archivo.WorkPlan
{
    internal class ClsWorkPlan : ClsWorkPlanEventsControls
    {
        ClsControls controlList;
        public FrmWorkPlanAdd _frmAdd;
        public FrmWorkPlanCat _frmCat;
        public EworkPlan eWorkPlan;
        public DataTable dtCatalog = new DataTable();
        public string filter;

        private readonly string queryCatalog = ClsObject.WorkPlan.QueryDgvCatalog;
        public ClsDGVCatalog? dgv;

        public bool IsAddOrModify = true;
        public bool IsAddUpdate;
        public bool IsModifyUpdate;
        public string? idAddModify;


        public ClsWorkPlan()
        {
            clsWP = this;
        }

        public void BeginFormCat()
        {
            _frmCat.dtpDate1.Value = DateTime.Now;
            _frmCat.dtpDate2.Value = DateTime.Now;
            _frmCat.WindowState = FormWindowState.Maximized;

            ClsComboBoxes.CboLoadActives(_frmCat.cboDistribuidor, ClsObject.Distributor.Cbo);
            ClsComboBoxes.CboLoadActives(_frmCat.cboPresentacion, Presentation.Cbo);
            ClsComboBoxes.CboLoadActives(_frmCat.cboVariety, Variety.Cbo);
            ClsComboBoxes.CboLoadActives(_frmCat.cboContainer, Container.Cbo);
            ClsComboBoxes.CboLoadActives(_frmCat.cboLot, Lot.Cbo);
            ClsComboBoxes.CboLoadActives(_frmCat.cboSeason, Season.Cbo);
            ClsComboBoxes.CboLoadActives(_frmCat.cboWorkGroup, WorkGroup.Cbo);
            ClsComboBoxes.CboLoadActives(_frmCat.cboFarm, Farm.Cbo);

            List<(ComboBox Cbo, string IdColumnFilter)> lsWGDep = new();
            lsWGDep.Add((_frmCat.cboSeason, Season.ColumnId));
            ClsComboBoxes.Events.CboApplyEventFilterAllForOne(_frmCat.cboWorkGroup, null, lsWGDep);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmCat.cboSeason, "08"); //<-- temporada uva 2026

            List<(ComboBox Cbo, string IdColumnFilter)> lsLotDep = new();
            lsLotDep.Add((_frmCat.cboFarm, Farm.ColumnId));
            ClsComboBoxes.Events.CboApplyEventFilterAllForOne(_frmCat.cboLot, null, lsLotDep);

            LoadDataGridViewCatalog();
        }

        public void BindDgvCatalog()
        {
            dgv = new ClsDGVCatalog(_frmCat.dgvCatalog, dtCatalog);
            dgv.AddHideColumn(ClsObject.WorkPlan.ColumnId);
            dgv.AddHideColumn(ClsObject.WorkPlan.ColumnActive);
            dgv.AddHideColumn(ClsObject.WorkPlan.ColumnDate);
            dgv.HideColumnsList();

            if (!_frmCat.chbRemoved.Checked)
            {
                dgv.CopyActiveValuesToHiddenColumn();
                dgv.SetFilterActivesOnly();
            }
            else
                dgv.SetFilterNull();
        }

        public void AddNewRowByIdInDGVCatalog()
        {
            string esc = idAddModify?.Replace("'", "''") ?? "";
            DataTable newIdRow = ClsQuerysDB.GetDataTable(queryCatalog + $" WHERE w.id_workPlan = '{esc}'");
            dgv!.AddNewRowToDGV(newIdRow);
        }

        public void ModifyRowByIdInDGVCatalog()
        {
            string esc = idAddModify?.Replace("'", "''") ?? "";
            DataTable newIdRow = ClsQuerysDB.GetDataTable(queryCatalog + $" WHERE w.id_workPlan = '{esc}'");
            dgv!.ModifyIdRowInDGV(newIdRow);
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
            IsAddOrModify = true;
            IsAddUpdate = false;
            idAddModify = null;
            _frmAdd = new(FormMode.Add);
            _frmAdd.cls = this;
            _frmAdd.Text = "Añadir plan de trabajo";
            _frmAdd.lblTitle.Text = "Añadir plan de trabajo";
            _frmAdd.IsAddModify = true; //porque si añadirá uno nuevo, no se está modificando uno existente
            _frmAdd.ShowDialog();
        }
        public void OpenFrmClone(string idClone)
        {
            IsAddOrModify = true;
            IsAddUpdate = false;
            idAddModify = null;
            _frmAdd = new(FormMode.Clone);
            _frmAdd.cls = this;
            _frmAdd.Text = "Añadir plan de trabajo (duplicar)";
            _frmAdd.lblTitle.Text = "Añadir plan de trabajo (duplicar)";
            _frmAdd.IsAddModify = true;
            _frmAdd.idModify = idClone;

            _frmAdd.ShowDialog();
        }
        public void BeginFormAdd()
        {
            AddControlsToList();
            SetControls();

            switch (_frmAdd._mode)
            {
                case FormMode.Add:
                    _frmAdd.chbActive.Checked = true;
                    _frmAdd.txbId.Text = EworkPlan.GetNextId();
                    break;

                case FormMode.Modify:
                    LoadControlsModify();
                    break;

                case FormMode.Clone:
                    LoadControlsModify(); // carga datos del anterior

                    _frmAdd.chbActive.Checked = true;
                    _frmAdd.txbId.Text = EworkPlan.GetNextId(); // reemplaza por nuevo ID
                    break;
            }

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
            controlList.Add(_frmAdd.txbIdTypeBox, "Seleccionar una caja.");
        }
        private void SetControls()
        {
            ClsComboBoxes.CboLoadActives(_frmAdd.cboSeason, Season.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboWorkGroup, WorkGroup.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboLot, Lot.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboSize, ClsObject.Size.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboVariety, Variety.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboDistributor, ClsObject.Distributor.Cbo);
            ClsComboBoxes.CboLoadAll(_frmAdd.cboTypeBox, TypeBox.Cbo);

            List<(ComboBox Cbo, string IdColumnFilter)> lsWGDep = new();
            lsWGDep.Add((_frmAdd.cboSeason, Season.ColumnId));
            ClsComboBoxes.Events.CboApplyEventFilterAllForOne(_frmAdd.cboWorkGroup, _frmAdd.chbWorkGroupActives, lsWGDep);

            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboSeason, _frmAdd.txbIdSeason);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboSeason, "08"); //<-- preseleccionar la temporada uva 2026

            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboWorkGroup, _frmAdd.txbIdWorkGroup);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboSize, _frmAdd.txbIdSize);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboTypeBox, _frmAdd.txbIdTypeBox);
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
            ClsDataGridViewCatalogs.SetColorRow(_frmAdd.dgvGTIN, "Post etiqueta", "-", System.Drawing.Color.Yellow);

        }

        private void LoadControlsModify()
        {
            eWorkPlan = new EworkPlan();

            eWorkPlan.SetWorkPlan(_frmAdd.idModify);
            _frmAdd.txbId.Text = eWorkPlan.IdWorkPlan;
            _frmAdd.dtpDateWorkPlan.Value = eWorkPlan.WorkDay;
            _frmAdd.chbActive.Checked = eWorkPlan.Active == 1;

            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboSize, eWorkPlan.Size);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboWorkGroup, eWorkPlan.IdWorkGroup);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboVariety, eWorkPlan.IdVariety);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboLot, eWorkPlan.IdLot + "|" + eWorkPlan.IdVariety);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboTypeBox, eWorkPlan.IdTypeBox);

            _frmAdd.txbIdGTIN.Text = eWorkPlan.IdGtin;
            _frmAdd.txbVPC.Text = eWorkPlan.VPC;

            SetDgvFilterGTINBeginModify();
        }

        public void OpenFrmModify(string idModify)
        {
            IsAddOrModify = false;
            IsModifyUpdate = false;
            idAddModify = idModify;
            _frmAdd = new(FormMode.Modify);
            _frmAdd.cls = this;
            _frmAdd.Text = "Modificar plan de trabajo";
            _frmAdd.lblTitle.Text = "Modificar plan de trabajo";
            _frmAdd.IsAddModify = false;
            _frmAdd.idModify = idModify;
            _frmAdd.ShowDialog();
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

        private EworkPlan SetEntity()
        {
            eWorkPlan = new();
            eWorkPlan.IdWorkPlan = _frmAdd.txbId.Text;
            eWorkPlan.WorkDay = _frmAdd.dtpDateWorkPlan.Value;
            eWorkPlan.Active = _frmAdd.chbActive.Checked ? 1 : 0;
            eWorkPlan.IdWorkGroup = _frmAdd.txbIdWorkGroup.Text;
            eWorkPlan.IdLot = _frmAdd.txbIdLot.Text.Substring(0, 4);
            eWorkPlan.IdVariety = _frmAdd.txbIdLot.Text.Substring(5, 2);
            eWorkPlan.IdGtin = _frmAdd.txbIdGTIN.Text;
            eWorkPlan.VPC = _frmAdd.txbVPC.Text;
            eWorkPlan.Size = _frmAdd.txbIdSize.Text;
            eWorkPlan.IdTypeBox = _frmAdd.txbIdTypeBox.Text;

            return eWorkPlan;
        }

        public void btnAcceptAddModify()
        {
            if (!controlList.ValidateControls())
                return;

            EworkPlan entity = SetEntity();

            string? excludeWorkPlanId = IsAddOrModify ? null : _frmAdd.txbId.Text;
            if (!entity.IsWorkPlanAvailable(excludeWorkPlanId))
                return;

            if (IsAddOrModify)
            {
                var result = entity.AddProcedure();
                IsAddUpdate = result.success;
                idAddModify = result.id;

                if (IsAddUpdate)
                {
                    MessageBox.Show($"Se agregó el plan de trabajo: {idAddModify}.", "Añadir plan de trabajo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _frmAdd.Close();
                }
                else
                {
                    SystemSounds.Exclamation.Play();
                    MessageBox.Show("No se pudo agregar el plan de trabajo.", "Añadir plan de trabajo");
                }
            }
            else
            {
                var result = entity.ModifyProcedure();
                IsModifyUpdate = result.success;
                idAddModify = result.id;

                if (IsModifyUpdate)
                {
                    MessageBox.Show($"Se ha modificado el plan de trabajo con código: {idAddModify}.", "Modificar plan de trabajo");
                    _frmAdd.Close();
                }
                else
                {
                    SystemSounds.Exclamation.Play();
                    MessageBox.Show("No se pudo modificar el plan de trabajo.", "Modificar plan de trabajo");
                }
            }
        }

        public void BtnSearch()
        {
            LoadDataGridViewCatalog();
        }
    }
}
