using System.Data;
using System.Drawing;
using System.Media;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.DataGridViews;
using SisUvex.Catalogos.Metods.Extentions;
using SisUvex.Catalogos.Metods.Querys;
using static SisUvex.Catalogos.Metods.ClsObject;

namespace SisUvex.Nomina.PlacePaymentLP;

internal class ClsPlacePayment
{
    public const string ColumnOrder = "Orden";

    ClsControls controlList = null!;
    public FrmPlacePaymentAdd _frmAdd = null!;
    public FrmPlacePaymentCat _frmCat = null!;
    public EPlacePayment entity = null!;

    private readonly string queryCatalog = $" SELECT cat.*, cat.[{Column.active}] AS [{Column.active}2] FROM vw_NomPlacePaymentCat cat ";

    ClsDGVCatalog? dgv;
    DataTable dtCatalog = null!;
    private bool _suppressOrderDgvEvent;

    public bool IsModifyUpdate;
    public string? idAddModify;
    public void BeginFormCat()
    {
        _frmCat ??= new();
        _frmCat.cls ??= this;

        ClsComboBoxes.CboLoadActives(_frmCat.cboContractor, Contractor.Cbo);
        ClsComboBoxes.CboLoadActives(_frmCat.cboSeason, Season.Cbo);
        ClsComboBoxes.CboLoadActives(_frmCat.cboWorkGroup, WorkGroup.Cbo);

        ClsComboBoxes.CboApplyClickEvent(_frmCat.cboContractor, _frmCat.chbActiveContractor);
        ClsComboBoxes.CboApplyClickEvent(_frmCat.cboWorkGroup, _frmCat.chbActiveWorkGroup);

        List<(ComboBox Cbo, string IdColumnFilter)> deps = new()
        {
            (_frmCat.cboSeason, Season.ColumnId),
            (_frmCat.cboContractor, Contractor.ColumnId)
        };
        ClsComboBoxes.Events.CboApplyEventFilterAllForOne(_frmCat.cboWorkGroup, _frmCat.chbActiveWorkGroup, deps);

        _frmCat.cboContractor.SelectedIndexChanged += (_, _) => SetFilterCatalog();
        _frmCat.cboSeason.SelectedIndexChanged += (_, _) => SetFilterCatalog();
        _frmCat.cboWorkGroup.SelectedIndexChanged += (_, _) => SetFilterCatalog();

        LoadCatalogFromDatabase();
    }

    /// <summary>Carga inicial del catálogo desde BD y preparación del grid (una sola vez al abrir el formulario).</summary>
    private void LoadCatalogFromDatabase()
    {
        dtCatalog = ClsQuerysDB.GetDataTable(queryCatalog + " WHERE 1 = 1 ");
        dgv = new ClsDGVCatalog(_frmCat.dgvCatalog, dtCatalog);

        dgv.AddHideColumn(Contractor.ColumnId);
        dgv.AddHideColumn(WorkGroup.ColumnId);
        dgv.AddHideColumn(Grower.ColumnId);
        dgv.AddHideColumn(Season.ColumnId);
        dgv.HideColumnsList();

        FinishCatalogGridUi();
        SetFilterCatalog();
    }

    private void FinishCatalogGridUi()
    {// Configura el grid: convierte la columna a CheckBox,
     // deja solo esa columna editable y asigna los eventos necesarios.
        DataGridView g = _frmCat.dgvCatalog;
        if (!g.Columns.Contains(ColumnOrder))
            return;

        ClsDGVCatalog.ConvertToCheckBoxColumn(g, ColumnOrder);

        foreach (DataGridViewColumn col in g.Columns)
            col.ReadOnly = col.Name != ColumnOrder;

        g.CellValueChanged -= DgvCatalog_CellValueChanged_Order;
        g.CellValueChanged += DgvCatalog_CellValueChanged_Order;
        g.CurrentCellDirtyStateChanged -= DgvCatalog_CurrentCellDirtyStateChanged;
        g.CurrentCellDirtyStateChanged += DgvCatalog_CurrentCellDirtyStateChanged;
    }

    private void DgvCatalog_CurrentCellDirtyStateChanged(object? sender, EventArgs e)
    {// Fuerza que el cambio del CheckBox se aplique al instante
     // para que se dispare el CellValueChanged inmediatamente.
        DataGridView dgvCat = _frmCat.dgvCatalog;
        if (dgvCat.IsCurrentCellDirty && dgvCat.CurrentCell?.OwningColumn.Name == ColumnOrder)
            dgvCat.CommitEdit(DataGridViewDataErrorContexts.Commit);
    }

    private void DgvCatalog_CellValueChanged_Order(object? sender, DataGridViewCellEventArgs e)
    {// Cuando cambia el CheckBox:
     // obtiene el ID, convierte a 1/0, ejecuta el procedimiento
     // y actualiza el DataTable.
        if (_suppressOrderDgvEvent)
            return;
        if (e.RowIndex < 0 || e.ColumnIndex < 0)
            return;
        DataGridView g = _frmCat.dgvCatalog;
        if (g.Columns[e.ColumnIndex].Name != ColumnOrder)
            return;

        string? id = g.Rows[e.RowIndex].Cells[Column.id].Value?.ToString();
        if (string.IsNullOrEmpty(id))
            return;

        object? v = g.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
        int nuevo = v != null && v != DBNull.Value && (v.ToString() == "1" || Convert.ToInt32(v) == 1) ? 1 : 0;

        if (!EPlacePayment.OrderProcedure(id, nuevo))
            return;
    }

    public void BtnPriorizeOrderSelected()
    {
        if (_frmCat.dgvCatalog.SelectedRows.Count == 0)
        {
            SystemSounds.Exclamation.Play();
            return;
        }

        DataGridViewRow row = _frmCat.dgvCatalog.SelectedRows[0];
        string? id = row.Cells[Column.id].Value?.ToString();
        if (string.IsNullOrEmpty(id))
            return;

        object? v = row.Cells[ColumnOrder].Value;
        int cur = v != null && v != DBNull.Value && (v.ToString() == "1" || Convert.ToInt32(v) == 1) ? 1 : 0;
        int nuevo = cur == 1 ? 0 : 1;

        if (!EPlacePayment.OrderProcedure(id, nuevo))
            return;

        _suppressOrderDgvEvent = true;
        try
        {
            SetOrderCellValue(row, nuevo);
        }
        finally
        {
            _suppressOrderDgvEvent = false;
        }
    }

    /// <summary>
    /// Igual que el criterio de <see cref="ClsDGVCatalog.ChangeActiveCell(DataGridView?, string)"/>:
    /// solo toca la celda en el <see cref="DataGridView"/>; el <see cref="DataRow"/> enlazado se actualiza solo.
    /// </summary>
    private static void SetOrderCellValue(DataGridViewRow row, int orderUnoOCero)
    {
        DataGridView? dgv = row.DataGridView;
        if (dgv == null || !dgv.Columns.Contains(ColumnOrder))
            return;
        row.Cells[ColumnOrder].Value = orderUnoOCero == 1;
    }

    /// <summary>
    /// Filtro en memoria sobre <see cref="dtCatalog"/>: sin recargar desde BD.
    /// <see cref="FrmPlacePaymentCat.chbRemoved"/>: sin marcar = solo activos (<see cref="Column.active"/>2); marcado = también inactivos, manteniendo filtros de combos.
    /// </summary>
    private void SetFilterCatalog()
    {
        if (dtCatalog == null)
            return;

        List<string> parts = new();

        if (!_frmCat.chbRemoved.Checked)
            parts.Add($"[{dgv.activeColumn}2] = '1'");

        AppendFilterIfComboHasValue(parts, _frmCat.cboContractor, Contractor.ColumnId);
        AppendFilterIfComboHasValue(parts, _frmCat.cboSeason, Season.ColumnId);
        AppendFilterIfComboHasValue(parts, _frmCat.cboWorkGroup, WorkGroup.ColumnId);

        dtCatalog.DefaultView.RowFilter = parts.Count == 0 ? string.Empty : string.Join(" AND ", parts);
        //MessageBox.Show(dtCatalog.DefaultView.RowFilter);
    }

    /// <summary>Usa <see cref="ComboBoxExtensions.ComboValueOrNull"/> (índice &gt; 0 y valor real, no &quot;---&quot;).</summary>
    private static void AppendFilterIfComboHasValue(List<string> parts, ComboBox cbo, string columnId)
    {
        string? v = cbo.ComboValueOrNull();
        if (!string.IsNullOrEmpty(v))
            parts.Add($"[{columnId}] = '{Esc(v)}'");
    }

    private static string Esc(string s) => s.Replace("'", "''");

    public void BeginFormAdd()
    {
        AddControlsToList();
        CargarComboBoxes();

        _frmAdd.txbName.Font = new Font(_frmAdd.txbName.Font, FontStyle.Bold);
        LoadControlsModify();
    }

    private void AddControlsToList()
    {
        controlList = new ClsControls();

        controlList.ChangeHeadMessage("Para modificar un lugar de pago debe:\n");
        controlList.Add(_frmAdd.txbName, "Ingresar el nombre del lugar de pago.");
        //controlList.Add(_frmAdd.txbIdGrower, "Seleccionar un productor.");
        controlList.Add(_frmAdd.txbSisName, "Ingresar el nombre en sistema.");
        controlList.Add(_frmAdd.cboActive, "Seleccionar si el lugar está activo.");
    }

    private void CargarComboBoxes()
    {
        ClsComboBoxes.CboLoadActives(_frmAdd.cboContractor, Contractor.Cbo);
        ClsComboBoxes.CboLoadActives(_frmAdd.cboSeason, Season.Cbo);
        ClsComboBoxes.CboLoadActives(_frmAdd.cboWorkGroup, WorkGroup.Cbo);
        ClsComboBoxes.CboLoadActives(_frmAdd.cboGrower, Grower.Cbo);

        ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboContractor, _frmAdd.txbIdContractor);
        ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboSeason, _frmAdd.txbIdSeason);
        ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboWorkGroup, _frmAdd.txbIdWorkGroup);
        ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboGrower, _frmAdd.txbIdGrower);

        ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboContractor, _frmAdd.chbActiveContractor);
        ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboWorkGroup, _frmAdd.chbActiveWorkGroup);

        List<(ComboBox Cbo, string IdColumnFilter)> deps = new()
        {
            (_frmAdd.cboSeason, Season.ColumnId),
            (_frmAdd.cboContractor, Contractor.ColumnId)
        };
        ClsComboBoxes.Events.CboApplyEventFilterAllForOne(_frmAdd.cboWorkGroup, _frmAdd.chbActiveWorkGroup, deps);
    }

    private void LoadControlsModify()
    {
        entity = new();
        entity.GetPlacePayment(idAddModify);

        _frmAdd.txbId.Text = entity.IdPlacePayment ?? "";
        _frmAdd.txbName.Text = entity.NamePlace ?? "";
        _frmAdd.txbName.Enabled = false;
        _frmAdd.txbSisName.Text = entity.SisName ?? "";
        _frmAdd.txbIdContractor.Text = entity.IdContractor ?? "";
        _frmAdd.txbIdSeason.Text = "";
        _frmAdd.txbIdWorkGroup.Text = entity.IdWorkGroup ?? "";
        _frmAdd.txbIdGrower.Text = entity.IdGrower ?? "";
        _frmAdd.cboActive.SelectedIndex = entity.Active;
        _frmAdd.tgbOrderList.Checked = entity.OrderList == 1;

        ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboContractor, _frmAdd.txbIdContractor);
        ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboGrower, _frmAdd.txbIdGrower);

        if (!string.IsNullOrEmpty(entity.IdWorkGroup))
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboWorkGroup, _frmAdd.txbIdWorkGroup);
    }

    private EPlacePayment SetEntity()
    {
        entity = new();
        entity.IdPlacePayment = _frmAdd.txbId.Text.Trim();
        entity.Active = _frmAdd.cboActive.SelectedIndex;
        entity.IdContractor = _frmAdd.cboContractor.ComboValueOrNull();
        entity.IdWorkGroup = _frmAdd.cboWorkGroup.ComboValueOrNull();
        entity.IdGrower = _frmAdd.cboGrower.ComboValueOrNull();
        entity.SisName = _frmAdd.txbSisName.Text.Trim();
        entity.OrderList = _frmAdd.tgbOrderList.Checked ? 1 : 0;

        return entity;
    }

    // OpenFrmAdd — alta por SP no disponible por ahora (solo modificar).

    public void OpenFrmModify(string? idModify)
    {
        IsModifyUpdate = false;
        if (string.IsNullOrEmpty(idModify))
        {
            SystemSounds.Exclamation.Play();
            MessageBox.Show("No se ha seleccionado un lugar de pago para modificar.", "Modificar lugar de pago");
            return;
        }

        idAddModify = idModify;
        _frmAdd = new();
        _frmAdd.cls = this;
        _frmAdd.Text = "Modificar lugar de pago";
        _frmAdd.lblTitle.Text = "Modificar lugar de pago";
        _frmAdd.ShowDialog();
    }

    public void BtnAccept()
    {
        if (!controlList.ValidateControls())
            return;

        EPlacePayment modifyEntity = SetEntity();
        var result = modifyEntity.ModifyProcedure();
        IsModifyUpdate = result.success;
        idAddModify = result.id;

        if (IsModifyUpdate)
        {
            MessageBox.Show($"Se ha modificado el lugar de pago con código: {idAddModify}.", "Modificar lugar de pago");
            _frmAdd.Close();
        }
        else
        {
            SystemSounds.Exclamation.Play();
            MessageBox.Show("No se pudo modificar el lugar de pago.", "Modificar lugar de pago");
        }
    }

    public void BtnActiveProcedure(string id, string activeValue)
    {
        bool ok = EPlacePayment.ActiveProcedure(id, activeValue);
        if (ok)
            dgv!.ChangeActiveCell(_frmCat.dgvCatalog, activeValue);
    }

    // AddNewRowByIdInDGVCatalog — alta no disponible por ahora.

    public void ModifyRowByIdInDGVCatalog()
    {
        string esc = idAddModify?.Replace("'", "''") ?? "";
        DataTable newIdRow = ClsQuerysDB.GetDataTable(queryCatalog + $" WHERE [{Column.id}] = '{esc}'");
        dgv!.ModifyIdRowInDGV(newIdRow);
    }

    public void ChbRemovedFilter()
    {
        SetFilterCatalog();
    }
}
