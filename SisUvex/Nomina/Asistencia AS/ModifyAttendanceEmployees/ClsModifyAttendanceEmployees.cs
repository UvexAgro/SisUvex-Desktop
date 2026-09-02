using System.Data;
using System.Drawing;
using System.Globalization;
using System.Media;
using System.Text;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Extentions;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Configuracion;
using SisUvex.Nomina.Asistencia_AS;
using static SisUvex.Catalogos.Metods.ClsObject;
using Color = System.Drawing.Color;
using ColorTranslator = System.Drawing.ColorTranslator;

namespace SisUvex.Nomina.Asistencia_AS.ModifyAttendanceEmployees;

/// <summary>
/// Lógica de la modificación masiva de asistencias/inasistencias de uno o varios empleados, en uno o
/// varios días a la vez. Los empleados y el rango de fechas llegan desde
/// <see cref="Comedores.DiningReports.AbsenceReport.FrmAbsenceReport"/> mediante <see cref="Open"/>.
/// Los cambios sólo se aplican en memoria (staging) hasta presionar "Guardar".
/// </summary>
internal class ClsModifyAttendanceEmployees
{
    public FrmModifyAttendanceEmployees frm = null!;

    private static readonly CultureInfo CultureEs = CultureInfo.GetCultureInfo("es-MX");

    private const string ColCodigo = "Código";
    private const string ColNombre = "Nombre completo";
    private const string ColLp = "LP";
    private const string ColTotal = "Total";
    private const string ValueAsistencia = "A";
    private const string DayColumnPrefix = "D_";

    private static readonly Color ColorAsistencia = Color.FromArgb(0xC5, 0xDF, 0xB4); // verde claro
    private static readonly Color ColorPendiente = Color.FromArgb(0xFF, 0xE1, 0x99); // resalte de celdas sin guardar

    private List<(string Code, string FullName, string Lp)> _employees = new();
    private DateTime _date1;
    private DateTime _date2;
    private List<DateTime> _days = new();
    /// <summary>id_attendanceType con el que debe preseleccionarse cboDefaultType (viene, p. ej., del cboAttendenceType del reporte). Null = usar el primero de la lista.</summary>
    private string? _initialDefaultTypeId;

    private DataTable _dtPivot = null!;
    private DataTable? _dtOriginalSnapshot;
    /// <summary>Mapa prefijo → apariencia (color + estilo de letra), tomado del catálogo de tipos de asistencia.</summary>
    private readonly Dictionary<string, AttendanceStyle> _stylesByPrefix = new(StringComparer.OrdinalIgnoreCase);

    /// <summary>Asistencias reales (nomhojas/nomhojas_temp), clave (código, día). 1 = hubo importe pagado.</summary>
    private Dictionary<(string Code, DateTime Date), int> _asistenciaLookup = new();
    /// <summary>Inasistencias explícitas ya registradas en Nom_Attendance_AS, clave (código, día) → prefijo.</summary>
    private Dictionary<(string Code, DateTime Date), string> _inasistenciaLookup = new();
    /// <summary>Comentario (v_comments) de la inasistencia ya registrada en Nom_Attendance_AS, clave (código, día).</summary>
    private Dictionary<(string Code, DateTime Date), string> _commentsLookup = new();

    /// <summary>Cambios pendientes de guardar, clave (código empleado, día).</summary>
    private readonly Dictionary<(string Code, DateTime Date), EAttendanceEdit> _pendingEdits = new();

    /// <summary>Se dispara cada vez que se guarda uno o más cambios exitosamente (ver <see cref="BtnSave"/>).</summary>
    public event Action? ChangesSaved;

    // ── Punto de entrada desde FrmAbsenceReport / FrmAsistenciaASConsulta ─

    /// <param name="defaultAttendanceTypeId">
    /// id_attendanceType con el que debe iniciar seleccionado cboDefaultType (por ejemplo, el que esté
    /// elegido en cboAttendenceType del reporte que abre este formulario). Si es null, se selecciona el
    /// primero de la lista.
    /// </param>
    /// <returns>
    /// La instancia de <see cref="ClsModifyAttendanceEmployees"/> recién creada (para poder suscribirse a
    /// <see cref="ChangesSaved"/>), o null si no se abrió el formulario (sin permiso o sin empleados).
    /// </returns>
    public static ClsModifyAttendanceEmployees? Open(
        List<(string Code, string FullName, string Lp)> employees,
        DateTime date1,
        DateTime date2,
        string? defaultAttendanceTypeId = null)
    {
        if (!User.HasCreateRecordsPermission())
            return null;

        if (employees == null || employees.Count == 0)
        {
            SystemSounds.Exclamation.Play();
            MessageBox.Show("No hay empleados para modificar.", "Modificar asistencias",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return null;
        }

        FrmModifyAttendanceEmployees frm = new();
        ClsModifyAttendanceEmployees cls = new()
        {
            frm = frm,
            _employees = employees,
            _date1 = date1.Date,
            _date2 = date2.Date,
            _initialDefaultTypeId = defaultAttendanceTypeId,
        };
        frm.cls = cls;

        FrmMenu.FrmMenuInstance.AbrirVentanaHijo(frm);

        return cls;
    }

    // ── Inicio del formulario ──────────────────────────────────────────────

    public void BeginForm()
    {
        if (!ValidateConnectionSettings())
        {
            frm.Close();
            return;
        }

        LoadAttendanceTypeCombo();
        frm.lblPeriodo.Text = $"Periodo: {_date1:dd/MM/yyyy} al {_date2:dd/MM/yyyy}    ·    {_employees.Count} empleado(s)";
        UpdatePendingSummary();

        try
        {
            LoadPivot();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Error al cargar asistencias", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private bool ValidateConnectionSettings()
    {
        bool incompleta =
            string.IsNullOrWhiteSpace(ClsConfig.Server) ||
            string.IsNullOrWhiteSpace(ClsConfig.DbWrite) ||
            string.IsNullOrWhiteSpace(ClsConfig.UserWrite) ||
            string.IsNullOrWhiteSpace(ClsConfig.DbEmployees);

        if (incompleta)
        {
            MessageBox.Show(
                "La configuración de conexión está incompleta (servidor, base de datos principal o " +
                "base de datos de empleados). Verifica la configuración antes de continuar.",
                "Configuración de conexión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        return !incompleta;
    }

    // ── Combos de tipo de asistencia ───────────────────────────────────────
    // cboApplyType: para aplicar manualmente a la selección (incluye "Asistencia" como opción real).
    // cboDefaultType: sólo indica qué prefijo se muestra por defecto en los días sin dato (no se guarda solo).

    /// <summary>
    /// Carga los tipos de asistencia a través de la caché estándar de catálogos (ClsComboBoxFiles),
    /// usando la consulta centralizada <see cref="AttendanceType.QueryCbo"/> y mostrando sólo los activos.
    /// Nom_AttendanceType no tiene registro en Pack_TablesUpdates, por lo que ClsAttendanceType invalida
    /// manualmente esa caché tras cualquier alta/modificación/cambio de estatus, para que aquí siempre se
    /// refleje el dato más reciente.
    /// </summary>
    private void LoadAttendanceTypeCombo()
    {
        DataTable dtTypes = ClsComboBoxFiles.GetCboCatalogDataTable(AttendanceType.Cbo);

        if (dtTypes.Columns.Contains(Column.active))
            dtTypes.DefaultView.RowFilter = $"{Column.active} = '1'";
        dtTypes.DefaultView.Sort = Column.name;
        dtTypes = dtTypes.DefaultView.ToTable();

        _stylesByPrefix.Clear();
        _stylesByPrefix[ValueAsistencia] = new AttendanceStyle(ColorAsistencia, FontStyle.Regular, isAbsence: false);
        foreach (DataRow row in dtTypes.Rows)
        {
            string prefix = row[AttendanceType.ColumnPrefix]?.ToString()?.Trim() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(prefix) || _stylesByPrefix.ContainsKey(prefix)) continue;

            Color color = ParseDbColor(row[AttendanceType.ColumnColor]?.ToString(), Color.LightPink);
            FontStyle fontStyle = dtTypes.Columns.Contains(AttendanceType.ColumnFontStyle)
                ? ParseFontStyle(row[AttendanceType.ColumnFontStyle])
                : FontStyle.Regular;
            bool isAbsence = dtTypes.Columns.Contains(AttendanceType.ColumncIsAbsence)
                && (row[AttendanceType.ColumncIsAbsence]?.ToString()?.Trim() ?? string.Empty) == "1";
            _stylesByPrefix[prefix] = new AttendanceStyle(color, fontStyle, isAbsence);
        }

        DataTable dtApply = dtTypes.Copy();
        DataRow sentinel = dtApply.NewRow();
        sentinel[Column.id] = string.Empty;
        sentinel[Column.name] = "Asistencia (quitar falta)";
        sentinel[AttendanceType.ColumnPrefix] = ValueAsistencia;
        dtApply.Rows.InsertAt(sentinel, 0);

        frm.cboApplyType.DataSource = dtApply;
        frm.cboApplyType.DisplayMember = Column.name;
        frm.cboApplyType.ValueMember = Column.id;
        frm.cboApplyType.SelectedIndex = 0;

        frm.cboDefaultType.DataSource = dtTypes;
        frm.cboDefaultType.DisplayMember = Column.name;
        frm.cboDefaultType.ValueMember = Column.id;

        if (dtTypes.Rows.Count == 0) return;

        int matchIndex = -1;
        if (!string.IsNullOrWhiteSpace(_initialDefaultTypeId))
        {
            for (int i = 0; i < dtTypes.Rows.Count; i++)
            {
                if (string.Equals(dtTypes.Rows[i][Column.id]?.ToString()?.Trim(), _initialDefaultTypeId, StringComparison.OrdinalIgnoreCase))
                {
                    matchIndex = i;
                    break;
                }
            }
        }

        frm.cboDefaultType.SelectedIndex = matchIndex >= 0 ? matchIndex : 0;
    }

    /// <summary>Prefijo (v_prefix) del tipo por defecto seleccionado en cboDefaultType.</summary>
    private string GetSelectedDefaultPrefix()
    {
        if (frm.cboDefaultType.SelectedIndex < 0) return string.Empty;
        return frm.cboDefaultType.GetColumnValue(AttendanceType.ColumnPrefix)?.ToString()?.Trim() ?? string.Empty;
    }

    private static Color ParseDbColor(string? raw, Color fallback)
    {
        if (string.IsNullOrWhiteSpace(raw)) return fallback;
        string value = raw.Trim();
        try
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(value, "^[0-9A-Fa-f]{6}$"))
                value = "#" + value;
            return ColorTranslator.FromHtml(value);
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

    // ── Carga del pivote (asistencias + inasistencias) ────────────────────

    private void LoadPivot()
    {
        _days = EachDayInclusive(_date1, _date2).ToList();
        List<string> codes = _employees.Select(e => e.Code).Distinct(StringComparer.OrdinalIgnoreCase).ToList();

        DataTable dtAsistencias = FetchAsistenciasQuery(codes, _date1, _date2);
        DataTable dtInasistencias = FetchInasistenciasQuery(codes, _date1, _date2);

        _asistenciaLookup = dtAsistencias.AsEnumerable()
            .GroupBy(r => (
                Code: r["Codigo"]?.ToString()?.Trim() ?? string.Empty,
                Date: NormalizeDate(r["Fecha"])))
            .ToDictionary(g => g.Key, g => Convert.ToInt32(g.First()["ASISTENCIA"]));

        _inasistenciaLookup = dtInasistencias.AsEnumerable()
            .GroupBy(r => (
                Code: r["id_employee"]?.ToString()?.Trim() ?? string.Empty,
                Date: NormalizeDate(r["d_attendance"])))
            .ToDictionary(g => g.Key, g => g.First()["v_prefix"]?.ToString()?.Trim() ?? string.Empty);

        _commentsLookup = dtInasistencias.AsEnumerable()
            .GroupBy(r => (
                Code: r["id_employee"]?.ToString()?.Trim() ?? string.Empty,
                Date: NormalizeDate(r["d_attendance"])))
            .ToDictionary(g => g.Key, g => g.First()["v_comments"]?.ToString()?.Trim() ?? string.Empty);

        _dtPivot = BuildPivotTable();
        _pendingEdits.Clear();
        ShowPivot();

        // El relleno con el tipo por defecto se aplica después de mostrar la grilla, y su snapshot
        // (usado por "Descartar") ya incluye ese relleno porque no se considera un cambio manual.
        RebuildPivotDisplay();
        _dtOriginalSnapshot = _dtPivot.Copy();
    }

    private DataTable FetchAsistenciasQuery(List<string> employeeCodes, DateTime date1, DateTime date2)
    {
        var parameters = new Dictionary<string, object>
        {
            ["@date1"] = date1,
            ["@date2"] = date2,
        };
        string inClause = BuildInClause(employeeCodes, "emp", parameters);

        string query = $@"
            USE [{ClsConfig.DbEmployees}];
            SELECT Fecha, Codigo, IMPORTE, ASISTENCIA FROM
            (
                SELECT d_fecha_cpn FECHA, c_codigo_emp CODIGO, SUM(n_importe_hoj) IMPORTE, CASE WHEN SUM(n_importe_hoj) > 0 THEN 1 ELSE 0 END AS ASISTENCIA FROM nomhojas GROUP BY d_fecha_cpn, c_codigo_emp
                UNION
                SELECT d_fecha_cpn FECHA, c_codigo_emp CODIGO, SUM(n_importe_hoj) IMPORTE, CASE WHEN SUM(n_importe_hoj) > 0 THEN 1 ELSE 0 END AS ASISTENCIA FROM nomhojas_temp GROUP BY d_fecha_cpn, c_codigo_emp
            ) NomHojas
            WHERE CODIGO IN {inClause} AND FECHA BETWEEN @date1 AND @date2
            ORDER BY CODIGO, FECHA;";

        return ClsQuerysDB.ExecuteParameterizedQuery(query, parameters);
    }

    private DataTable FetchInasistenciasQuery(List<string> employeeCodes, DateTime date1, DateTime date2)
    {
        var parameters = new Dictionary<string, object>
        {
            ["@date1"] = date1,
            ["@date2"] = date2,
        };
        string inClause = BuildInClause(employeeCodes, "emp", parameters);

        string query = $@"
            SELECT att.id_employee, att.d_attendance, att.id_attendanceType, att.v_comments, typ.v_prefix, typ.v_name
            FROM Nom_Attendance_AS att
            LEFT JOIN Nom_AttendanceType typ ON typ.id_attendanceType = att.id_attendanceType
            WHERE att.id_employee IN {inClause} AND att.d_attendance BETWEEN @date1 AND @date2
            ORDER BY att.id_employee, att.d_attendance;";

        return ClsQuerysDB.ExecuteParameterizedQuery(query, parameters);
    }

    private static string BuildInClause(List<string> values, string paramPrefix, Dictionary<string, object> parameters)
    {
        var names = new List<string>();
        for (int i = 0; i < values.Count; i++)
        {
            string pname = $"@{paramPrefix}{i}";
            names.Add(pname);
            parameters[pname] = values[i];
        }
        return "(" + string.Join(", ", names) + ")";
    }

    private DataTable BuildPivotTable()
    {
        var table = new DataTable();
        table.Columns.Add(ColCodigo, typeof(string));
        table.Columns.Add(ColNombre, typeof(string));
        table.Columns.Add(ColLp, typeof(string));
        table.Columns.Add(ColTotal, typeof(int));
        foreach (DateTime day in _days)
            table.Columns.Add(BuildDayColumnName(day), typeof(string));

        foreach (var emp in _employees)
        {
            DataRow newRow = table.NewRow();
            newRow[ColCodigo] = emp.Code;
            newRow[ColNombre] = emp.FullName;
            newRow[ColLp] = emp.Lp;
            newRow[ColTotal] = 0;
            foreach (DateTime day in _days)
                newRow[BuildDayColumnName(day)] = string.Empty;

            table.Rows.Add(newRow);
        }

        return table;
    }

    /// <summary>
    /// Recalcula el valor mostrado en cada celda de días a partir de las consultas cargadas y del
    /// prefijo seleccionado en <c>cboDefaultType</c>, respetando (sin tocar) las celdas ya modificadas
    /// manualmente (<see cref="_pendingEdits"/>). Igual que en el reporte de sólo lectura: el prefijo
    /// por defecto no se aplica en domingo salvo que sí haya asistencia real ese día.
    /// </summary>
    private void RebuildPivotDisplay()
    {
        string defaultPrefix = GetSelectedDefaultPrefix();

        foreach (DataRow row in _dtPivot.Rows)
        {
            string code = row[ColCodigo]?.ToString()?.Trim() ?? string.Empty;
            int total = 0;

            foreach (DateTime day in _days)
            {
                string colName = BuildDayColumnName(day);

                if (_pendingEdits.ContainsKey((code, day)))
                {
                    if (string.Equals(row[colName]?.ToString(), ValueAsistencia, StringComparison.OrdinalIgnoreCase))
                        total++;
                    continue; // no se sobreescribe un cambio manual
                }

                bool hasAsistencia = _asistenciaLookup.TryGetValue((code, day), out int asis) && asis == 1;
                bool hasInasistencia = _inasistenciaLookup.TryGetValue((code, day), out string? prefijo) && !string.IsNullOrWhiteSpace(prefijo);

                string value = string.Empty;
                if (hasAsistencia) value = ValueAsistencia;
                if (hasInasistencia) value = prefijo!;
                if (!hasAsistencia && !hasInasistencia && day.DayOfWeek != DayOfWeek.Sunday)
                    value = defaultPrefix;

                if (string.Equals(value, ValueAsistencia, StringComparison.OrdinalIgnoreCase))
                    total++;

                row[colName] = value;
            }

            row[ColTotal] = total;
        }

        frm.dgvPivot.Refresh();
    }

    /// <summary>Se llama al cambiar la selección de cboDefaultType.</summary>
    public void CboDefaultType_SelectedIndexChanged()
    {
        if (_dtPivot == null) return;
        RebuildPivotDisplay();
    }

    private static string BuildDayColumnName(DateTime day) => DayColumnPrefix + day.ToString("yyyy-MM-dd");

    private static bool TryParseDayColumn(string columnName, out DateTime day)
    {
        day = DateTime.MinValue;
        if (string.IsNullOrEmpty(columnName) || !columnName.StartsWith(DayColumnPrefix, StringComparison.Ordinal))
            return false;

        return DateTime.TryParseExact(
            columnName[DayColumnPrefix.Length..], "yyyy-MM-dd",
            CultureInfo.InvariantCulture, DateTimeStyles.None, out day);
    }

    private static IEnumerable<DateTime> EachDayInclusive(DateTime rangeStart, DateTime rangeEnd)
    {
        DateTime start = rangeStart.Date;
        DateTime end = rangeEnd.Date;
        if (start > end) yield break;

        for (DateTime day = start; day <= end; day = day.AddDays(1))
            yield return day;
    }

    private static DateTime NormalizeDate(object? value)
    {
        if (value == null || value == DBNull.Value) return DateTime.MinValue;
        if (value is DateTime dt) return dt.Date;
        return DateTime.Parse(value.ToString()!, CultureInfo.InvariantCulture).Date;
    }

    // ── Mostrar el pivote en el DGV ─────────────────────────────────────────

    private void ShowPivot()
    {
        frm.dgvPivot.ReadOnly = true; // la edición sólo se hace vía "Aplicar a selección"
        frm.dgvPivot.SelectionMode = DataGridViewSelectionMode.CellSelect;
        frm.dgvPivot.MultiSelect = true;
        frm.dgvPivot.AutoGenerateColumns = true;
        frm.dgvPivot.DataSource = null;
        frm.dgvPivot.DataSource = _dtPivot;

        ApplyDayColumnHeaders();
        frm.dgvPivot.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
    }

    private void ApplyDayColumnHeaders()
    {
        foreach (DataGridViewColumn col in frm.dgvPivot.Columns)
        {
            if (TryParseDayColumn(col.Name, out DateTime day))
            {
                string monthAbbr = day.ToString("MMM", CultureEs).Replace(".", string.Empty).ToLower(CultureEs);
                string dayAbbr = RemoveDiacritics(day.ToString("ddd", CultureEs)).Replace(".", string.Empty).ToLower(CultureEs);
                col.HeaderText = $"{monthAbbr}-{day:dd}{Environment.NewLine}{dayAbbr}";
                col.ToolTipText = day.ToString("dddd dd 'de' MMMM 'de' yyyy", CultureEs);
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
    }

    private static string RemoveDiacritics(string text)
    {
        string normalized = text.Normalize(NormalizationForm.FormD);
        var sb = new StringBuilder();
        foreach (char c in normalized)
        {
            if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                sb.Append(c);
        }
        return sb.ToString().Normalize(NormalizationForm.FormC);
    }

    // ── Aplicar tipo seleccionado a las celdas seleccionadas (staging) ────

    public void BtnApplyToSelection()
    {
        if (frm.dgvPivot.SelectedCells.Count == 0)
        {
            SystemSounds.Exclamation.Play();
            MessageBox.Show(
                "Selecciona una o más celdas de días en la tabla (arrastrando con el mouse, o con Ctrl/Shift+clic) antes de aplicar.",
                "Aplicar asistencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (frm.cboApplyType.SelectedIndex < 0) return;

        string selectedId = frm.cboApplyType.SelectedValue?.ToString() ?? string.Empty;
        string selectedPrefix = frm.cboApplyType.GetColumnValue(AttendanceType.ColumnPrefix)?.ToString()?.Trim() ?? string.Empty;
        bool isAsistencia = string.IsNullOrEmpty(selectedId);
        string displayValue = isAsistencia ? ValueAsistencia : selectedPrefix;
        string? comments = string.IsNullOrWhiteSpace(frm.txbComments.Text) ? null : frm.txbComments.Text.Trim();

        var touchedRows = new HashSet<int>();

        foreach (DataGridViewCell cell in frm.dgvPivot.SelectedCells)
        {
            string colName = frm.dgvPivot.Columns[cell.ColumnIndex].Name;
            if (!TryParseDayColumn(colName, out DateTime day)) continue; // ignora columnas fijas (Código, Nombre, LP, Total)

            if (frm.dgvPivot.Rows[cell.RowIndex].DataBoundItem is not DataRowView drv) continue;

            string code = drv[ColCodigo]?.ToString()?.Trim() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(code)) continue;

            drv[colName] = displayValue;

            _pendingEdits[(code, day)] = new EAttendanceEdit
            {
                IdEmployee = code,
                Date = day,
                IdAttendanceType = isAsistencia ? null : selectedId,
                Comments = comments,
                Prefix = displayValue,
            };

            touchedRows.Add(cell.RowIndex);
        }

        foreach (int rowIndex in touchedRows)
            RecalculateTotal(rowIndex);

        frm.dgvPivot.Refresh();
        UpdatePendingSummary();
    }

    private void RecalculateTotal(int rowIndex)
    {
        if (frm.dgvPivot.Rows[rowIndex].DataBoundItem is not DataRowView drv) return;

        int total = 0;
        foreach (DateTime day in _days)
        {
            string value = drv[BuildDayColumnName(day)]?.ToString() ?? string.Empty;
            if (string.Equals(value, ValueAsistencia, StringComparison.OrdinalIgnoreCase))
                total++;
        }
        drv[ColTotal] = total;
    }

    // ── Coloreado + resalte de celdas pendientes ──────────────────────────

    public void DgvPivot_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

        string colName = frm.dgvPivot.Columns[e.ColumnIndex].Name;
        if (!TryParseDayColumn(colName, out DateTime day)) return;

        string value = e.Value?.ToString()?.Trim() ?? string.Empty;

        bool isPending = frm.dgvPivot.Rows[e.RowIndex].DataBoundItem is DataRowView drv
            && _pendingEdits.ContainsKey((drv[ColCodigo]?.ToString()?.Trim() ?? string.Empty, day));

        Color? color = null;
        FontStyle fontStyle = FontStyle.Regular;
        if (string.Equals(value, ValueAsistencia, StringComparison.OrdinalIgnoreCase))
            color = ColorAsistencia;
        else if (!string.IsNullOrWhiteSpace(value) && _stylesByPrefix.TryGetValue(value, out AttendanceStyle mapped))
        {
            color = mapped.Color;
            fontStyle = mapped.FontStyle;
        }

        if (isPending)
            color = ColorPendiente;

        if (color.HasValue)
        {
            e.CellStyle.BackColor = color.Value;
            e.CellStyle.SelectionBackColor = ControlPaint.Dark(color.Value, 0.1f);
        }

        // Las celdas con cambios sin guardar siempre se marcan en negrita (indicador de "pendiente"),
        // combinándose con el resto del estilo guardado (cursiva/subrayado/tachado) si lo tuviera.
        if (isPending)
            fontStyle |= FontStyle.Bold;
        if (fontStyle != FontStyle.Regular)
            e.CellStyle.Font = new Font(frm.dgvPivot.Font, fontStyle);
    }

    // ── Comentarios de las faltas (tooltip + marcador visual + precarga) ──

    /// <summary>Muestra el comentario de la falta (guardada o pendiente) como tooltip al pasar el mouse por la celda.</summary>
    public void DgvPivot_CellToolTipTextNeeded(object? sender, DataGridViewCellToolTipTextNeededEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

        string colName = frm.dgvPivot.Columns[e.ColumnIndex].Name;
        if (!TryParseDayColumn(colName, out DateTime day)) return;

        string? comment = GetCellComment(e.RowIndex, day);
        if (!string.IsNullOrWhiteSpace(comment))
            e.ToolTipText = comment;
    }

    /// <summary>Dibuja un pequeño marcador (triángulo, como en Excel) en la esquina de las celdas que tienen comentario.</summary>
    public void DgvPivot_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

        string colName = frm.dgvPivot.Columns[e.ColumnIndex].Name;
        if (!TryParseDayColumn(colName, out DateTime day)) return;

        string? comment = GetCellComment(e.RowIndex, day);
        if (string.IsNullOrWhiteSpace(comment)) return;

        e.Paint(e.CellBounds, DataGridViewPaintParts.All);
        DrawCommentMarker(e.Graphics!, e.CellBounds);
        e.Handled = true;
    }

    /// <summary>
    /// Al seleccionar una única celda de día, precarga su comentario existente (guardado o pendiente)
    /// en <c>txbComments</c> para poder revisarlo/editarlo antes de reaplicar un cambio. Si se seleccionan
    /// varias celdas se deja el texto tal cual, para no interrumpir la captura de un comentario en lote.
    /// </summary>
    public void DgvPivot_SelectionChanged()
    {
        if (frm.dgvPivot.SelectedCells.Count != 1) return;

        DataGridViewCell cell = frm.dgvPivot.SelectedCells[0];
        string colName = frm.dgvPivot.Columns[cell.ColumnIndex].Name;
        if (!TryParseDayColumn(colName, out DateTime day))
        {
            frm.txbComments.Text = string.Empty;
            return;
        }

        string code = GetRowCode(cell.RowIndex);
        frm.txbComments.Text = string.IsNullOrWhiteSpace(code) ? string.Empty : GetCellComment(cell.RowIndex, day) ?? string.Empty;
    }

    /// <summary>Comentario (guardado o pendiente de guardar) para la fila y el día indicados, si existe.</summary>
    private string? GetCellComment(int rowIndex, DateTime day)
    {
        string code = GetRowCode(rowIndex);
        if (string.IsNullOrWhiteSpace(code)) return null;

        var key = (code, day);
        if (_pendingEdits.TryGetValue(key, out EAttendanceEdit? edit))
            return string.IsNullOrWhiteSpace(edit.Comments) ? null : edit.Comments;

        return _commentsLookup.TryGetValue(key, out string? comment) && !string.IsNullOrWhiteSpace(comment)
            ? comment
            : null;
    }

    private string GetRowCode(int rowIndex)
    {
        if (frm.dgvPivot.Rows[rowIndex].DataBoundItem is not DataRowView drv) return string.Empty;
        return drv[ColCodigo]?.ToString()?.Trim() ?? string.Empty;
    }

    /// <summary>Dibuja un triángulo pequeño en la esquina superior derecha de la celda, similar al indicador de comentarios de Excel.</summary>
    private static void DrawCommentMarker(Graphics g, Rectangle bounds)
    {
        const int size = 6;
        Point p1 = new(bounds.Right - size, bounds.Top);
        Point p2 = new(bounds.Right, bounds.Top);
        Point p3 = new(bounds.Right, bounds.Top + size);
        using SolidBrush brush = new(Color.FromArgb(220, 40, 40, 40));
        g.FillPolygon(brush, new[] { p1, p2, p3 });
    }

    // ── Guardar / descartar cambios ────────────────────────────────────────

    public void BtnSave()
    {
        if (_pendingEdits.Count == 0)
        {
            MessageBox.Show("No hay cambios pendientes por guardar.", "Guardar cambios",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        DialogResult confirm = MessageBox.Show(
            $"¿Guardar {_pendingEdits.Count} cambio(s) de asistencia?",
            "Guardar cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (confirm != DialogResult.Yes) return;

        SQLControl sql = new();
        try
        {
            sql.BeginTransaction();

            foreach (EAttendanceEdit edit in _pendingEdits.Values)
                edit.Save(sql);

            sql.CommitTransaction();

            // Refleja lo recién guardado en los lookups, para que un futuro cambio de "tipo por
            // defecto" no borre estas celdas ya confirmadas.
            foreach (EAttendanceEdit edit in _pendingEdits.Values)
            {
                var key = (edit.IdEmployee, edit.Date);
                if (edit.IdAttendanceType == null)
                {
                    _inasistenciaLookup.Remove(key);
                    _asistenciaLookup[key] = 1;
                    _commentsLookup.Remove(key);
                }
                else
                {
                    _inasistenciaLookup[key] = edit.Prefix;
                    _asistenciaLookup.Remove(key);
                    _commentsLookup[key] = edit.Comments ?? string.Empty;
                }
            }

            int count = _pendingEdits.Count;
            _pendingEdits.Clear();
            _dtOriginalSnapshot = _dtPivot.Copy();
            frm.dgvPivot.Refresh();
            UpdatePendingSummary();

            MessageBox.Show($"Se guardaron {count} cambio(s) correctamente.", "Guardar cambios",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Como el formulario ya no es modal (se abre como ventana hija de FrmMenu), se notifica aquí
            // para que quien lo abrió (p. ej. el reporte de FrmAsistenciaASConsulta) pueda refrescarse
            // de inmediato, sin tener que esperar a que esta ventana se cierre.
            ChangesSaved?.Invoke();
        }
        catch (Exception ex)
        {
            sql.RollbackTransaction();
            MessageBox.Show(ex.ToString(), "Error al guardar cambios", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public void BtnDiscard()
    {
        if (_pendingEdits.Count == 0) return;

        DialogResult confirm = MessageBox.Show(
            "¿Descartar todos los cambios pendientes sin guardar?",
            "Descartar cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (confirm != DialogResult.Yes) return;

        _dtPivot = _dtOriginalSnapshot!.Copy();
        _pendingEdits.Clear();
        ShowPivot();
        UpdatePendingSummary();
    }

    /// <summary>Se llama desde el evento FormClosing para confirmar la pérdida de cambios sin guardar.</summary>
    public bool ConfirmCloseIfPending()
    {
        if (_pendingEdits.Count == 0) return true;

        DialogResult r = MessageBox.Show(
            "Hay cambios sin guardar. ¿Deseas cerrar de todas formas y perderlos?",
            "Cambios sin guardar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        return r == DialogResult.Yes;
    }

    private void UpdatePendingSummary()
    {
        frm.lblPending.Text = _pendingEdits.Count > 0
            ? $"{_pendingEdits.Count} cambio(s) sin guardar"
            : string.Empty;
        frm.lblPending.ForeColor = Color.DarkOrange;
    }
}
