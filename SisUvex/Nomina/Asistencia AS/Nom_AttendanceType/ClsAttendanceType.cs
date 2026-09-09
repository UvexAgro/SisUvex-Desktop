using System.Media;
using System.Data;
using System.Windows.Forms;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.ComboBoxes;
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
        ApplyPrefixStyleFormatting(dgvCatalog);

        if (dgvCatalog.Columns.Contains(AttendanceType.ColumnFontStyle))
            dgvCatalog.Columns[AttendanceType.ColumnFontStyle].Visible = false; // dato crudo, se refleja en la columna de prefijo
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

    /// <summary>
    /// Aplica al prefijo del catálogo el mismo color de fondo y estilo de letra (negrita/cursiva/subrayado/
    /// tachado) con el que se verá en el reporte, para que el catálogo funcione también como vista previa.
    /// </summary>
    private static void ApplyPrefixStyleFormatting(DataGridView dgvCatalog)
    {
        if (!dgvCatalog.Columns.Contains(AttendanceType.ColumnPrefix))
            return;

        dgvCatalog.CellFormatting += (sender, e) =>
        {
            if (dgvCatalog.Columns[e.ColumnIndex].Name != AttendanceType.ColumnPrefix || e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvCatalog.Rows[e.RowIndex];

            if (dgvCatalog.Columns.Contains(AttendanceType.ColumnColor))
            {
                Color color = TryParseColor(row.Cells[AttendanceType.ColumnColor].Value?.ToString(), Color.White);
                e.CellStyle.BackColor = color;
                e.CellStyle.SelectionBackColor = color;
            }

            if (dgvCatalog.Columns.Contains(AttendanceType.ColumnFontStyle))
            {
                FontStyle style = ParseFontStyle(row.Cells[AttendanceType.ColumnFontStyle].Value);
                if (style != FontStyle.Regular)
                    e.CellStyle.Font = new Font(dgvCatalog.Font, style);
            }
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

        _frmAdd.chbBold.Checked = entity.FontStyle.HasFlag(FontStyle.Bold);
        _frmAdd.chbItalic.Checked = entity.FontStyle.HasFlag(FontStyle.Italic);
        _frmAdd.chbUnderline.Checked = entity.FontStyle.HasFlag(FontStyle.Underline);
        _frmAdd.chbStrikeout.Checked = entity.FontStyle.HasFlag(FontStyle.Strikeout);

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
        entity.FontStyle = GetSelectedFontStyle();

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
                ClsComboBoxFiles.InvalidateCache(AttendanceType.Cbo);
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
                ClsComboBoxFiles.InvalidateCache(AttendanceType.Cbo);
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
        {
            ClsComboBoxFiles.InvalidateCache(AttendanceType.Cbo);
            dgv!.ChangeActiveCell(_frmCat.dgvCatalog, activeValue);
        }
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
        RefreshStylePreview();
    }

    /// <summary>
    /// Actualiza <c>lblPreview</c> combinando el color seleccionado (<c>pnlColor</c>) y el estilo de letra
    /// elegido en los checkboxes, mostrando el prefijo capturado (o "Abc" si aún no se ha escrito ninguno).
    /// </summary>
    public void RefreshStylePreview()
    {
        if (_frmAdd == null) return;

        Color color = _frmAdd.pnlColor.BackColor;
        FontStyle style = GetSelectedFontStyle();

        _frmAdd.lblPreview.BackColor = color;
        _frmAdd.lblPreview.ForeColor = GetReadableForeColor(color);
        _frmAdd.lblPreview.Font = new Font(_frmAdd.lblPreview.Font, style);
        _frmAdd.lblPreview.Text = string.IsNullOrWhiteSpace(_frmAdd.txbPrefix.Text) ? "Abc" : _frmAdd.txbPrefix.Text.Trim();
    }

    /// <summary>Combina (OR) los checkboxes de estilo marcados en el bitmask de <see cref="FontStyle"/> correspondiente.</summary>
    private FontStyle GetSelectedFontStyle()
    {
        FontStyle style = FontStyle.Regular;
        if (_frmAdd.chbBold.Checked) style |= FontStyle.Bold;
        if (_frmAdd.chbItalic.Checked) style |= FontStyle.Italic;
        if (_frmAdd.chbUnderline.Checked) style |= FontStyle.Underline;
        if (_frmAdd.chbStrikeout.Checked) style |= FontStyle.Strikeout;
        return style;
    }

    /// <summary>Negro o blanco, según cuál se lea mejor sobre el color de fondo dado (luminancia relativa).</summary>
    private static Color GetReadableForeColor(Color background)
    {
        double luminance = (0.299 * background.R + 0.587 * background.G + 0.114 * background.B) / 255;
        return luminance > 0.6 ? Color.Black : Color.White;
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

    /// <summary>Convierte el bitmask numérico guardado en <c>n_fontStyle</c> a <see cref="FontStyle"/>.</summary>
    private static FontStyle ParseFontStyle(object? raw)
    {
        if (raw == null || raw == DBNull.Value) return FontStyle.Regular;
        return byte.TryParse(raw.ToString(), out byte value) ? (FontStyle)value : FontStyle.Regular;
    }
}
