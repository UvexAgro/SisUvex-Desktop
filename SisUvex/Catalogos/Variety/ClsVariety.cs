using System.Data;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.DataGridViews;
using SisUvex.Catalogos.Metods.Extentions;
using SisUvex.Catalogos.Metods.Querys;
using static SisUvex.Catalogos.Metods.ClsObject;
using static SisUvex.Catalogos.Metods.Extentions.ComboBoxExtensions;
using VarietyInfo = SisUvex.Catalogos.Metods.ClsObject.Variety;

namespace SisUvex.Catalogos.Variety;

internal class ClsVariety
{
    ClsControls controlList = null!;
    public FrmVarietyAdd _frmAdd = null!;
    public FrmVarietyCat _frmCat = null!;
    public EVariety entity = null!;

    private readonly string queryCatalog = " SELECT cat.* FROM vw_PackVarietyCat cat ";

    ClsDGVCatalog? dgv;
    DataTable dtCatalog = null!;

    public bool IsAddOrModify = true;
    public bool IsAddUpdate;
    public bool IsModifyUpdate;
    public string? idAddModify;

    private void BindDgvCatalog(DataGridView dgvCatalog)
    {
        dgv = new ClsDGVCatalog(dgvCatalog, dtCatalog);
        dgv.AddHideColumn(Metods.ClsObject.Color.ColumnId);
        dgv.AddHideColumn(Crop.ColumnId);
        dgv.AddHideColumn(Grower.ColumnId);
        dgv.HideColumnsList();

        dgv.CopyActiveValuesToHiddenColumn();
        dgv.SetFilterActivesOnly();

        if (dgvCatalog.Columns.Contains(VarietyInfo.ColumnUseFacility))
            ClsDGVCatalog.ConvertToCheckBoxColumn(dgvCatalog, VarietyInfo.ColumnUseFacility);
    }

    private void WireCatalogFilterEvents()
    {
        _frmCat.cboCrop.SelectedIndexChanged += (_, _) => ApplyCatalogRowFilter();
        _frmCat.cboColor.SelectedIndexChanged += (_, _) => ApplyCatalogRowFilter();
    }

    public void BeginFormCat()
    {
        _frmCat ??= new();
        _frmCat.cls ??= this;

        ClsComboBoxes.CboLoadActives(_frmCat.cboCrop, Crop.Cbo);
        ClsComboBoxes.CboLoadActives(_frmCat.cboColor, Metods.ClsObject.Color.Cbo);

        dtCatalog = ClsQuerysDB.GetDataTable(queryCatalog + " WHERE 1 = 1 ");
        BindDgvCatalog(_frmCat.dgvCatalog);

        WireCatalogFilterEvents();
    }

    static string ActiveHideColumnName => $"{Column.active}2";

    /// <summary>Filtros sobre <see cref="dtCatalog"/> (sin nueva consulta), combinados con activos/eliminados.</summary>
    public void ApplyCatalogRowFilter()
    {
        if (dtCatalog == null)
            return;

        List<string> filters = new();

        if (!_frmCat.chbRemoved.Checked && dtCatalog.Columns.Contains(ActiveHideColumnName))
            filters.Add($"[{ActiveHideColumnName}] = '1'");

        if (_frmCat.cboCrop.TryGetValue(out string cropValue))
            filters.Add($"[{Crop.ColumnId}] = '{cropValue.Replace("'", "''")}'");

        if (_frmCat.cboColor.TryGetValue(out string colorValue))
            filters.Add($"[{Metods.ClsObject.Color.ColumnId}] = '{colorValue.Replace("'", "''")}'");

        dtCatalog.DefaultView.RowFilter = filters.Count > 0 ? string.Join(" AND ", filters) : string.Empty;
    }

    public void ChbRemovedFilter()
    {
        if (!_frmCat.chbRemoved.Checked)
            dgv!.CopyActiveValuesToHiddenColumn();

        ApplyCatalogRowFilter();
    }

    public void BeginFormAdd()
    {
        AddControlsToList();
        LoadControls();

        if (IsAddOrModify)
        {
            _frmAdd.cboActive.SelectedIndex = 1;
            _frmAdd.tglUseFacility.Checked = false;
            _frmAdd.txbId.Text = EVariety.GetNextId();
        }
        else
        {
            _frmAdd.txbNameComercial.Font = new Font(_frmAdd.txbNameComercial.Font, FontStyle.Bold);
            LoadControlsModify();
        }
    }

    private void AddControlsToList()
    {
        controlList = new ClsControls();

        controlList.ChangeHeadMessage("Para dar de alta una variedad debe:\n");
        controlList.Add(_frmAdd.txbNameComercial, "Ingresar el nombre comercial.");
        controlList.Add(_frmAdd.cboActive, "Seleccionar si la variedad está activa.");
        controlList.Add(_frmAdd.cboColor, "Seleccionar un color.");
        controlList.Add(_frmAdd.cboCrop, "Seleccionar un cultivo.");
    }

    private void LoadControls()
    {
        ClsComboBoxes.CboLoadActives(_frmAdd.cboColor, Metods.ClsObject.Color.Cbo);
        ClsComboBoxes.CboLoadActives(_frmAdd.cboCrop, Crop.Cbo);
        ClsComboBoxes.CboLoadActives(_frmAdd.cboGrower, ClsObject.Grower.Cbo);
    }

    private void LoadControlsModify()
    {
        entity = new();
        entity.GetVariety(idAddModify);

        _frmAdd.txbId.Text = entity.IdVariety ?? "";
        _frmAdd.txbNameScientis.Text = entity.NameScientis ?? "";
        _frmAdd.txbNameComercial.Text = entity.NameComercial ?? "";
        _frmAdd.txbShortName.Text = entity.ShortName ?? "";
        _frmAdd.txbPatentLegend.Text = entity.PatentLegend ?? "";
        _frmAdd.txbTrademark.Text = entity.Trademark ?? "";
        _frmAdd.cboActive.SelectedIndex = entity.Active;

        ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboColor, entity.IdColor);
        ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboCrop, entity.IdCrop);
        ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboGrower, entity.IdGrower);
        _frmAdd.tglUseFacility.Checked = entity.UseFacility == 1;
    }

    private EVariety SetEntity()
    {
        entity = new();
        entity.IdVariety = _frmAdd.txbId.Text.Trim();
        entity.NameScientis = _frmAdd.txbNameScientis.Text.Trim();
        entity.NameComercial = _frmAdd.txbNameComercial.Text.Trim();
        entity.ShortName = _frmAdd.txbShortName.Text.Trim();
        entity.PatentLegend = _frmAdd.txbPatentLegend.Text.Trim();
        entity.Trademark = _frmAdd.txbTrademark.Text.Trim();
        entity.Active = _frmAdd.cboActive.SelectedIndex;

        entity.IdColor = _frmAdd.cboColor.ComboValueOrNull();
        entity.IdCrop = _frmAdd.cboCrop.ComboValueOrNull();
        entity.IdGrower = _frmAdd.cboGrower.ComboValueOrNull();
        entity.UseFacility = _frmAdd.tglUseFacility.Checked ? 1 : 0;

        return entity;
    }

    public void OpenFrmAdd()
    {
        IsAddOrModify = true;
        IsAddUpdate = false;
        idAddModify = null;
        _frmAdd = new();
        _frmAdd.cls = this;
        _frmAdd.Text = "Añadir variedad";
        _frmAdd.lblTitulo.Text = "Añadir variedad";
        _frmAdd.ShowDialog();
    }

    public void OpenFrmModify(string? idModify)
    {
        IsAddOrModify = false;
        IsModifyUpdate = false;
        if (string.IsNullOrEmpty(idModify))
        {
            SystemSounds.Exclamation.Play();
            MessageBox.Show("No se ha seleccionado una variedad para modificar.", "Modificar variedad");
            return;
        }

        idAddModify = idModify;
        _frmAdd = new();
        _frmAdd.cls = this;
        _frmAdd.Text = "Modificar variedad";
        _frmAdd.lblTitulo.Text = "Modificar variedad";
        _frmAdd.ShowDialog();
    }

    public void BtnAccept()
    {
        if (!controlList.ValidateControls())
            return;

        if (IsAddOrModify)
        {
            EVariety addEntity = SetEntity();
            var result = addEntity.AddProcedure();
            IsAddUpdate = result.success;
            idAddModify = result.id;

            if (IsAddUpdate)
            {
                string nombre = string.IsNullOrWhiteSpace(addEntity.NameComercial)
                    ? idAddModify ?? ""
                    : addEntity.NameComercial.Trim();
                MessageBox.Show($"Se ha agregado la variedad {nombre} con código: {idAddModify}.", "Añadir variedad");
                _frmAdd.Close();
            }
            else
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("No se pudo agregar la variedad.", "Añadir variedad");
            }
        }
        else
        {
            EVariety modifyEntity = SetEntity();
            var result = modifyEntity.ModifyProcedure();
            IsModifyUpdate = result.success;
            idAddModify = result.id;

            if (IsModifyUpdate)
            {
                string nombre = string.IsNullOrWhiteSpace(modifyEntity.NameComercial)
                    ? idAddModify ?? ""
                    : modifyEntity.NameComercial.Trim();
                MessageBox.Show($"Se ha modificado la variedad {nombre} con código: {idAddModify}.", "Modificar variedad");
                _frmAdd.Close();
            }
            else
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("No se pudo modificar la variedad.", "Modificar variedad");
            }
        }
    }

    public void BtnActiveProcedure(string id, string activeValue)
    {
        bool ok = EVariety.ActiveProcedure(id, activeValue);
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
}
