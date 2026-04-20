using System.Data;
using System.Drawing;
using System.Media;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.DataGridViews;
using SisUvex.Catalogos.Metods.Extentions;
using SisUvex.Catalogos.Metods.Forms.SelectionForms;
using SisUvex.Catalogos.Metods.Querys;
using static SisUvex.Catalogos.Metods.ClsObject;

namespace SisUvex.Catalogos.WorkGroup;

internal class ClsWorkGroup
{
    ClsControls controlList = null!;
    public FrmWorkGroupAdd _frmAdd = null!;
    public FrmWorkGroupCat _frmCat = null!;
    public EWorkGroup entity = null!;

    private readonly string queryCatalog = $" SELECT cat.* FROM vw_PackWorkGroupCat cat ";

    ClsDGVCatalog? dgv;
    DataTable dtCatalog = null!;

    public bool IsAddOrModify = true;
    public bool IsAddUpdate;
    public bool IsModifyUpdate;
    public string? idAddModify;
    private void SetFilterCatalog()
    {
        string filter = string.Empty;

        if (!_frmCat.chbRemoved.Checked)
            filter += $"{Column.active} = 1";

        if (_frmCat.cboContractor.SelectedIndex > 0)
        {
            if (filter != string.Empty)
                filter += " AND ";
            filter += $"{Contractor.ColumnId} = '{_frmCat.cboContractor.SelectedValue}' ";
        }

        if (_frmCat.cboSeason.SelectedIndex > 0)
        {
            if (filter != string.Empty)
                filter += " AND ";
            filter += $"{Season.ColumnId} = '{_frmCat.cboSeason.SelectedValue}'";
        }

        dtCatalog.DefaultView.RowFilter = filter;
    }


    public void BeginFormCat()
    {
        _frmCat ??= new();
        _frmCat.cls ??= this;

        ClsComboBoxes.CboLoadActives(_frmCat.cboContractor, Contractor.Cbo);
        ClsComboBoxes.CboLoadActives(_frmCat.cboSeason, Season.Cbo);

        dtCatalog = ClsQuerysDB.GetDataTable(queryCatalog + " WHERE 1 = 1 ");
        dgv = new ClsDGVCatalog(_frmCat.dgvCatalog, dtCatalog);
        dgv.AddHideColumn(Season.ColumnId);
        dgv.AddHideColumn(Contractor.ColumnId);
        dgv.HideColumnsList();

        _frmCat.cboContractor.SelectedIndexChanged += (sender, e) => { SetFilterCatalog(); };
        _frmCat.cboSeason.SelectedIndexChanged += (sender, e) => { SetFilterCatalog(); };
    }

    public void BeginFormAdd()
    {
        AddControlsToList();
        CargarComboBoxes();

        if (IsAddOrModify)
        {
            _frmAdd.cboActive.SelectedIndex = 1;
            _frmAdd.txbId.Text = EWorkGroup.GetNextId();
        }
        else
        {
            _frmAdd.txbName.Font = new Font(_frmAdd.txbName.Font, FontStyle.Bold);
            LoadControlsModify();
        }
    }

    private void AddControlsToList()
    {
        controlList = new ClsControls();

        controlList.ChangeHeadMessage("Para dar de alta una cuadrilla debe:\n");
        controlList.Add(_frmAdd.txbName, "Ingresar el nombre de la cuadrilla.");
        controlList.Add(_frmAdd.txbIdContractor, "Seleccionar un contratista.");
        controlList.Add(_frmAdd.txbIdSeason, "Seleccionar una temporada.");
        controlList.Add(_frmAdd.cboActive, "Seleccionar si la cuadrilla está activa.");
    }

    private void CargarComboBoxes()
    {
        ClsComboBoxes.CboLoadActives(_frmAdd.cboContractor, Contractor.Cbo);
        ClsComboBoxes.CboLoadActives(_frmAdd.cboSeason, Season.Cbo);
        ClsComboBoxes.CboLoadActives(_frmAdd.cboPlacePayment, PlacePayment.Cbo);

        ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboContractor, _frmAdd.txbIdContractor);
        ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboSeason, _frmAdd.txbIdSeason);
        ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboPlacePayment, _frmAdd.txbPlacePayment);

        ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboContractor, _frmAdd.chbActiveContractor);
    }

    private void LoadControlsModify()
    {
        entity = new();
        entity.GetWorkGroup(idAddModify);

        _frmAdd.txbId.Text = entity.IdWorkGroup ?? "";
        _frmAdd.txbName.Text = entity.NameWorkGroup ?? "";
        _frmAdd.txbIdContractor.Text = entity.IdContractor ?? "";
        _frmAdd.txbIdSeason.Text = entity.IdSeason ?? "";
        _frmAdd.txbPlacePayment.Text = entity.IdPlacePayment ?? "";
        _frmAdd.cboActive.SelectedIndex = entity.Active;

        ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboContractor, _frmAdd.txbIdContractor);
        ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboSeason, _frmAdd.txbIdSeason);
        ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboPlacePayment, _frmAdd.txbPlacePayment);
    }

    private EWorkGroup SetEntity()
    {
        entity = new();
        entity.IdWorkGroup = _frmAdd.txbId.Text.Trim();
        entity.NameWorkGroup = _frmAdd.txbName.Text.Trim();
        entity.IdContractor = _frmAdd.cboContractor.ComboValueOrNull();
        entity.IdSeason = _frmAdd.cboSeason.ComboValueOrNull();
        entity.IdPlacePayment = _frmAdd.cboPlacePayment.ComboValueOrNull();
        entity.Active = _frmAdd.cboActive.SelectedIndex;

        return entity;
    }

    public void OpenFrmAdd()
    {
        IsAddOrModify = true;
        IsAddUpdate = false;
        idAddModify = null;
        _frmAdd = new();
        _frmAdd.cls = this;
        _frmAdd.Text = "Añadir cuadrilla";
        _frmAdd.lblTitle.Text = "Añadir cuadrilla";
        _frmAdd.ShowDialog();
    }

    public void OpenFrmModify(string? idModify)
    {
        IsAddOrModify = false;
        IsModifyUpdate = false;
        if (string.IsNullOrEmpty(idModify))
        {
            SystemSounds.Exclamation.Play();
            MessageBox.Show("No se ha seleccionado una cuadrilla para modificar.", "Modificar cuadrilla");
            return;
        }

        idAddModify = idModify;
        _frmAdd = new();
        _frmAdd.cls = this;
        _frmAdd.Text = "Modificar cuadrilla";
        _frmAdd.lblTitle.Text = "Modificar cuadrilla";
        _frmAdd.ShowDialog();
    }

    public void BtnAccept()
    {
        if (!controlList.ValidateControls())
            return;

        if (IsAddOrModify)
        {
            EWorkGroup addEntity = SetEntity();
            var result = addEntity.AddProcedure();
            IsAddUpdate = result.success;
            idAddModify = result.id;

            if (IsAddUpdate)
            {
                string nombre = string.IsNullOrWhiteSpace(addEntity.NameWorkGroup)
                    ? idAddModify ?? ""
                    : addEntity.NameWorkGroup.Trim();
                MessageBox.Show($"Se ha agregado la cuadrilla {nombre} con código: {idAddModify}.", "Añadir cuadrilla");
                _frmAdd.Close();
            }
            else
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("No se pudo agregar la cuadrilla.", "Añadir cuadrilla");
            }
        }
        else
        {
            EWorkGroup modifyEntity = SetEntity();
            var result = modifyEntity.ModifyProcedure();
            IsModifyUpdate = result.success;
            idAddModify = result.id;

            if (IsModifyUpdate)
            {
                string nombre = string.IsNullOrWhiteSpace(modifyEntity.NameWorkGroup)
                    ? idAddModify ?? ""
                    : modifyEntity.NameWorkGroup.Trim();
                MessageBox.Show($"Se ha modificado la cuadrilla {nombre} con código: {idAddModify}.", "Modificar cuadrilla");
                _frmAdd.Close();
            }
            else
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("No se pudo modificar la cuadrilla.", "Modificar cuadrilla");
            }
        }
    }

    public void BtnActiveProcedure(string id, string activeValue)
    {
        bool ok = EWorkGroup.ActiveProcedure(id, activeValue);
        if (ok)
            dgv!.ChangeActiveCell(_frmCat.dgvCatalog, activeValue);
    }

    public void AddNewRowByIdInDGVCatalog()
    {
        string esc = idAddModify?.Replace("'", "''") ?? "";
        DataTable newIdRow = ClsQuerysDB.GetDataTable(queryCatalog + $" WHERE [{Column.id}] = '{esc}'");
        dgv!.AddNewRowToDGV(newIdRow);
    }

    public void ModifyRowByIdInDGVCatalog()
    {
        string esc = idAddModify?.Replace("'", "''") ?? "";
        DataTable newIdRow = ClsQuerysDB.GetDataTable(queryCatalog + $" WHERE [{Column.id}] = '{esc}'");
        dgv!.ModifyIdRowInDGV(newIdRow);
    }

    public void ChbRemovedFilter()
    {
        dtCatalog = ClsQuerysDB.GetDataTable(queryCatalog + " WHERE 1 = 1 ");
        dgv = new ClsDGVCatalog(_frmCat.dgvCatalog, dtCatalog);

        if (_frmCat.chbRemoved.Checked)
            dgv.SetFilterNull();
        else
        {
            dgv.CopyActiveValuesToHiddenColumn();
            dgv.SetFilterActivesOnly();
        }
    }

    public void BtnSearchContractor()
    {
        ClsSelectionForm sel = new();
        sel.OpenSelectionForm("Contractor", "Código");

        if (!string.IsNullOrEmpty(sel.SelectedValue))
        {
            _frmAdd.txbIdContractor.Text = sel.SelectedValue;
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboContractor, _frmAdd.txbIdContractor);
        }
    }
}
