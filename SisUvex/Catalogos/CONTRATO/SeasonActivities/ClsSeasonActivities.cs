using System.Data;
using System.Drawing;
using System.Media;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.DataGridViews;
using SisUvex.Catalogos.Metods.Extentions;
using SisUvex.Catalogos.Metods.Querys;
using static SisUvex.Catalogos.Metods.ClsObject;

namespace SisUvex.Catalogos.CONTRATO.SeasonActivities;

internal class ClsSeasonActivities
{
    ClsControls controlList = null!;
    public FrmSeasonActivitiesAdd _frmAdd = null!;
    public FrmSeasonActivitiesCat _frmCat = null!;
    public ESeasonActivities entity = null!;

    private readonly string queryCatalog = $"{Metods.ClsObject.SeasonActivities.QueryDgvCatalog} ";

    ClsDGVCatalog? dgv;
    DataTable dtCatalog = null!;

    public bool IsAddOrModify = true;
    public bool IsAddUpdate;
    public bool IsModifyUpdate;
    public string? idAddModify;

    private void BindDgvCatalog(DataGridView dgvCatalog)
    {
        dgv = new ClsDGVCatalog(dgvCatalog, dtCatalog);
        dgv.AddHideColumn(SeasonType.ColumnId);
        dgv.AddHideColumn(Unit.ColumnId);
        dgv.HideColumnsList();
    }

    private void WireCatalogFilterEvents()
    {
        _frmCat.cboSeason.SelectedIndexChanged += (_, _) => ApplyCatalogRowFilter();
    }

    public void BeginFormCat()
    {
        _frmCat ??= new();
        _frmCat.cls ??= this;

        ClsComboBoxes.CboLoadAll(_frmCat.cboSeason, SeasonType.Cbo);

        dtCatalog = ClsQuerysDB.GetDataTable(queryCatalog + " WHERE 1 = 1 ");
        BindDgvCatalog(_frmCat.dgvCatalog);

        WireCatalogFilterEvents();
    }

    /// <summary>Filtro sobre <see cref="dtCatalog"/> (sin nueva consulta).</summary>
    public void ApplyCatalogRowFilter()
    {
        if (dtCatalog == null)
            return;

        List<string> filters = new();

        if (_frmCat.cboSeason.SelectedIndex > 0)
        {
            string seasonTypeValue = _frmCat.cboSeason.SelectedValue?.ToString()?.Replace("'", "''") ?? "";
            if (!string.IsNullOrEmpty(seasonTypeValue))
                filters.Add($"[{SeasonType.ColumnId}] = '{seasonTypeValue}'");
        }

        dtCatalog.DefaultView.RowFilter = filters.Count > 0 ? string.Join(" AND ", filters) : string.Empty;
    }

    public void BeginFormAdd()
    {
        AddControlsToList();
        LoadControls();

        if (IsAddOrModify)
            _frmAdd.txbId.Text = ESeasonActivities.GetNextId();
        else
        {
            _frmAdd.txbName.Font = new Font(_frmAdd.txbName.Font, FontStyle.Bold);
            LoadControlsModify();
        }
    }

    private void AddControlsToList()
    {
        controlList = new ClsControls();
        controlList.ChangeHeadMessage("Para dar de alta una actividad de temporada debe:\n");
        controlList.Add(_frmAdd.txbName, "Ingresar el nombre de la actividad.");
        controlList.Add(_frmAdd.txbIdSeason, "Seleccionar un tipo de temporada.");
        controlList.Add(_frmAdd.txbIdUnit, "Seleccionar una unidad.");
    }

    private void LoadControls()
    {
        ClsComboBoxes.CboLoadAll(_frmAdd.cboSeason, SeasonType.Cbo);
        ClsComboBoxes.CboLoadAll(_frmAdd.cboUnit, Unit.Cbo);

        ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboSeason, _frmAdd.txbIdSeason);
        ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboUnit, _frmAdd.txbIdUnit);
    }

    private void LoadControlsModify()
    {
        entity = new();
        entity.GetSeasonActivity(idAddModify);

        _frmAdd.txbId.Text = entity.IdSeasonActivity ?? "";
        _frmAdd.txbName.Text = entity.NameActivities ?? "";
        _frmAdd.txbIdSeason.Text = entity.IdSeasonType ?? "";
        _frmAdd.txbIdUnit.Text = entity.IdUnit ?? "";

        ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboSeason, _frmAdd.txbIdSeason);
        ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboUnit, _frmAdd.txbIdUnit);
    }

    private ESeasonActivities SetEntity()
    {
        entity = new();
        entity.IdSeasonActivity = string.IsNullOrWhiteSpace(_frmAdd.txbId.Text) ? null : _frmAdd.txbId.Text.Trim();
        entity.NameActivities = _frmAdd.txbName.Text.Trim();
        entity.IdSeasonType = _frmAdd.cboSeason.ComboValueOrNull();
        entity.IdUnit = _frmAdd.cboUnit.ComboValueOrNull();
        return entity;
    }

    public void OpenFrmAdd()
    {
        IsAddOrModify = true;
        IsAddUpdate = false;
        idAddModify = null;
        _frmAdd = new();
        _frmAdd.cls = this;
        _frmAdd.Text = "Añadir actividad de temporada";
        _frmAdd.lblTitle.Text = "Añadir actividad de temporada";
        _frmAdd.ShowDialog();
    }

    public void OpenFrmModify(string? idModify)
    {
        IsAddOrModify = false;
        IsModifyUpdate = false;
        if (string.IsNullOrEmpty(idModify))
        {
            SystemSounds.Exclamation.Play();
            MessageBox.Show("No se ha seleccionado una actividad para modificar.", "Modificar actividad de temporada");
            return;
        }

        idAddModify = idModify;
        _frmAdd = new();
        _frmAdd.cls = this;
        _frmAdd.Text = "Modificar actividad de temporada";
        _frmAdd.lblTitle.Text = "Modificar actividad de temporada";
        _frmAdd.ShowDialog();
    }

    public void BtnAccept()
    {
        if (!controlList.ValidateControls())
            return;

        if (IsAddOrModify)
        {
            ESeasonActivities addEntity = SetEntity();
            var result = addEntity.AddProcedure();
            IsAddUpdate = result.success;
            idAddModify = result.id;

            if (IsAddUpdate)
            {
                string nombre = string.IsNullOrWhiteSpace(addEntity.NameActivities) ? idAddModify ?? "" : addEntity.NameActivities;
                MessageBox.Show($"Se ha agregado la actividad {nombre} con código: {idAddModify}.", "Añadir actividad de temporada");
                _frmAdd.Close();
            }
            else
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("No se pudo agregar la actividad de temporada.", "Añadir actividad de temporada");
            }
        }
        else
        {
            ESeasonActivities modifyEntity = SetEntity();
            var result = modifyEntity.ModifyProcedure();
            IsModifyUpdate = result.success;
            idAddModify = result.id;

            if (IsModifyUpdate)
            {
                string nombre = string.IsNullOrWhiteSpace(modifyEntity.NameActivities) ? idAddModify ?? "" : modifyEntity.NameActivities;
                MessageBox.Show($"Se ha modificado la actividad {nombre} con código: {idAddModify}.", "Modificar actividad de temporada");
                _frmAdd.Close();
            }
            else
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("No se pudo modificar la actividad de temporada.", "Modificar actividad de temporada");
            }
        }
    }

    public void AddNewRowByIdInDGVCatalog()
    {
        string esc = idAddModify?.Replace("'", "''") ?? "";
        DataTable newIdRow = ClsQuerysDB.GetDataTable(queryCatalog + $" WHERE [{Column.id}] = '{esc}'");
        dgv!.AddNewRowToDGV(newIdRow);
        ApplyCatalogRowFilter();
    }

    public void ModifyRowByIdInDGVCatalog()
    {
        string esc = idAddModify?.Replace("'", "''") ?? "";
        DataTable newIdRow = ClsQuerysDB.GetDataTable(queryCatalog + $" WHERE [{Column.id}] = '{esc}'");
        dgv!.ModifyIdRowInDGV(newIdRow);
        ApplyCatalogRowFilter();
    }
}
