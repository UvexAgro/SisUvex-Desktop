using System.Media;
using System.Data;
using System.Windows.Forms;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.DataGridViews;
using SisUvex.Catalogos.Metods.Querys;
using static SisUvex.Catalogos.Metods.ClsObject;
using Color = System.Drawing.Color;
using ColorTranslator = System.Drawing.ColorTranslator;

namespace SisUvex.Nomina.Asistencia_AS.Nom_AttendanceType;

internal class ClsAttendanceType
{
    private static readonly Color DefaultColor = Color.White;

    ClsControls controlList = null!;
    public FrmAttendanceTypeAdd _frmAdd = null!;
    public FrmAttendanceTypeCat _frmCat = null!;
    public EAttendanceType entity = null!;

    private readonly string queryCatalog = AttendanceType.QueryDgvCatalog;

    ClsDGVCatalog? dgv;
    DataTable dtCatalog = null!;

    public bool IsAddOrModify = true;
    public bool IsAddUpdate;
    public bool IsModifyUpdate;
    public string? idAddModify;

    private void BindDgvCatalog(DataGridView dgvCatalog)
    {
        dgv = new ClsDGVCatalog(dgvCatalog, dtCatalog);
        dgv.CopyActiveValuesToHiddenColumn();
        dgv.SetFilterActivesOnly();
        dgv.SetColumnWidth(AttendanceType.ColumnColor, 70);

        ApplyColorColumnFormatting(dgvCatalog);
    }

    /// <summary>Muestra el color guardado como una celda coloreada en lugar de su código hexadecimal.</summary>
    private static void ApplyColorColumnFormatting(DataGridView dgvCatalog)
    {
        if (!dgvCatalog.Columns.Contains(AttendanceType.ColumnColor))
            return;

        dgvCatalog.CellFormatting += (sender, e) =>
        {
            if (dgvCatalog.Columns[e.ColumnIndex].Name != AttendanceType.ColumnColor)
                return;

            Color color = TryParseColor(e.Value?.ToString(), Color.White);
            e.CellStyle.BackColor = color;
            e.CellStyle.SelectionBackColor = color;
            e.Value = string.Empty;
            e.FormattingApplied = true;
        };
    }

    public void BeginFormCat()
    {
        _frmCat ??= new();
        _frmCat.cls ??= this;

        dtCatalog = ClsQuerysDB.GetDataTable(queryCatalog + " WHERE 1 = 1 ORDER BY id_attendanceType ");
        BindDgvCatalog(_frmCat.dgvCatalog);
    }

    public void BeginFormAdd()
    {
        AddControlsToList();

        if (IsAddOrModify)
        {
            _frmAdd.cboActive.SelectedIndex = 1;
            _frmAdd.txbId.Text = EAttendanceType.GetNextId();
            _frmAdd.cboIsAbsence.SelectedIndex = 0; // Asistencia por defecto
            SetColorPreview(DefaultColor);
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

        controlList.ChangeHeadMessage("Para dar de alta un tipo de asistencia debe:\n");
        controlList.Add(_frmAdd.txbName, "Ingresar el nombre del tipo de asistencia.");
        controlList.Add(_frmAdd.txbPrefix, "Ingresar el prefijo del tipo de asistencia.");
        controlList.Add(_frmAdd.cboIsAbsence, "Seleccionar el tipo (Asistencia o Inasistencia).");
        controlList.Add(_frmAdd.cboActive, "Seleccionar si el tipo de asistencia está activo.");
    }

    private void LoadControlsModify()
    {
        entity = new();
        entity.GetAttendanceType(idAddModify);

        _frmAdd.txbId.Text = entity.IdAttendanceType ?? "";
        _frmAdd.txbName.Text = entity.Name ?? "";
        _frmAdd.txbPrefix.Text = entity.Prefix ?? "";
        _frmAdd.cboActive.SelectedIndex = entity.Active;
        _frmAdd.cboIsAbsence.SelectedIndex = entity.IsAbsence ? 1 : 0;

        SetColorPreview(TryParseColor(entity.Color, DefaultColor));
    }

    private EAttendanceType SetEntity()
    {
        entity = new();
        entity.IdAttendanceType = _frmAdd.txbId.Text;
        entity.Name = _frmAdd.txbName.Text.Trim();
        entity.Prefix = _frmAdd.txbPrefix.Text.Trim();
        entity.IsAbsence = _frmAdd.cboIsAbsence.SelectedIndex == 1;
        entity.Active = _frmAdd.cboActive.SelectedIndex;
        entity.Color = string.IsNullOrWhiteSpace(_frmAdd.txbColor.Text)
            ? ColorTranslator.ToHtml(DefaultColor)
            : _frmAdd.txbColor.Text.Trim();

        return entity;
    }

    public void OpenFrmAdd()
    {
        IsAddOrModify = true;
        IsAddUpdate = false;
        idAddModify = null;
        _frmAdd = new();
        _frmAdd.cls = this;
        _frmAdd.Text = "Añadir tipo de asistencia";
        _frmAdd.lblTitulo.Text = "Añadir tipo de asistencia";
        _frmAdd.ShowDialog();
    }

    public void OpenFrmModify(string? idModify)
    {
        IsAddOrModify = false;
        IsModifyUpdate = false;
        if (string.IsNullOrEmpty(idModify))
        {
            SystemSounds.Exclamation.Play();
            MessageBox.Show("No se ha seleccionado un tipo de asistencia para modificar.", "Modificar tipo de asistencia");
            return;
        }

        idAddModify = idModify;
        _frmAdd = new();
        _frmAdd.cls = this;
        _frmAdd.Text = "Modificar tipo de asistencia";
        _frmAdd.lblTitulo.Text = "Modificar tipo de asistencia";
        _frmAdd.ShowDialog();
    }

    public void BtnAccept()
    {
        if (!controlList.ValidateControls())
            return;

        if (IsAddOrModify)
        {
            EAttendanceType addEntity = SetEntity();
            var result = addEntity.AddProcedure();
            IsAddUpdate = result.success;
            idAddModify = result.id;

            if (IsAddUpdate)
            {
                string nombre = string.IsNullOrWhiteSpace(addEntity.Name) ? idAddModify ?? "" : addEntity.Name;
                MessageBox.Show($"Se ha agregado el tipo de asistencia {nombre} con código: {idAddModify}.", "Añadir tipo de asistencia");
                _frmAdd.Close();
            }
            else
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("No se pudo agregar el tipo de asistencia.", "Añadir tipo de asistencia");
            }
        }
        else
        {
            EAttendanceType modifyEntity = SetEntity();
            var result = modifyEntity.ModifyProcedure();
            IsModifyUpdate = result.success;
            idAddModify = result.id;

            if (IsModifyUpdate)
            {
                string nombre = string.IsNullOrWhiteSpace(modifyEntity.Name) ? idAddModify ?? "" : modifyEntity.Name;
                MessageBox.Show($"Se ha modificado el tipo de asistencia {nombre} con código: {idAddModify}.", "Modificar tipo de asistencia");
                _frmAdd.Close();
            }
            else
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("No se pudo modificar el tipo de asistencia.", "Modificar tipo de asistencia");
            }
        }
    }

    public void BtnActiveProcedure(string id, string activeValue)
    {
        bool ok = EAttendanceType.ActiveProcedure(id, activeValue);
        if (ok)
            dgv!.ChangeActiveCell(_frmCat.dgvCatalog, activeValue);
    }

    public void AddNewRowByIdInDGVCatalog()
    {
        string esc = idAddModify?.Replace("'", "''") ?? "";
        DataTable newIdRow = ClsQuerysDB.GetDataTable(queryCatalog + $" WHERE id_attendanceType = '{esc}' ");
        dgv!.AddNewRowToDGV(newIdRow);
    }

    public void ModifyRowByIdInDGVCatalog()
    {
        string esc = idAddModify?.Replace("'", "''") ?? "";
        DataTable newIdRow = ClsQuerysDB.GetDataTable(queryCatalog + $" WHERE id_attendanceType = '{esc}' ");
        dgv!.ModifyIdRowInDGV(newIdRow);
    }

    public void ChbRemovedFilter()
    {
        if (_frmCat.chbRemoved.Checked)
            dgv!.SetFilterNull();
        else
        {
            dgv!.CopyActiveValuesToHiddenColumn();
            dgv!.SetFilterActivesOnly();
        }
    }

    public void BtnSelectColor()
    {
        using ColorDialog dlg = new() { Color = _frmAdd.pnlColor.BackColor, FullOpen = true };
        if (dlg.ShowDialog() == DialogResult.OK)
            SetColorPreview(dlg.Color);
    }

    private void SetColorPreview(Color color)
    {
        _frmAdd.pnlColor.BackColor = color;
        _frmAdd.txbColor.Text = ColorTranslator.ToHtml(color).ToUpperInvariant();
    }

    private static Color TryParseColor(string? raw, Color fallback)
    {
        if (string.IsNullOrWhiteSpace(raw))
            return fallback;

        try
        {
            return ColorTranslator.FromHtml(raw.Trim());
        }
        catch
        {
            return fallback;
        }
    }
}
