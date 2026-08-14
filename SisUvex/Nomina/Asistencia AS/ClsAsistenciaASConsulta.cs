using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Extentions;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Configuracion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;
using static SisUvex.Catalogos.Metods.ClsObject;
using Color = System.Drawing.Color;

namespace SisUvex.Nomina.Asistencia_AS
{
    internal class ClsAsistenciaASConsulta
    {
        public FrmAsistenciaASConsulta? frm = null;

        // ── Columnas del listado de empleados (vw_Employees_Info) ────────────
        private const string ColSel    = "Sel.";
        private const string ColCodigo = Column.id; // Alias de id_employee

        /// <summary>Columna cruda que se repite por el SELECT * de vw_Employees_Info y debe ocultarse en el DGV.</summary>
        private const string ColRawIdEmployee = "id_employee";

        // ── Columnas ocultas en el DGV del listado ────────────────────────────
        private readonly List<string> _columnsToHideInDgv = new()
        {
            ColRawIdEmployee,
        };

        // ── Columnas del reporte de asistencias/inasistencias (visibles también para ClsExcelAsistenciaASConsulta) ──
        internal const string ReportColCodigo  = ColCodigo;
        internal const string ReportColNombre  = "Nombre completo";
        internal const string ReportColLp      = "LP";
        internal const string ReportColTotal   = "Total";
        internal const string ValueAsistencia  = "A";
        internal const string DayColumnPrefix  = "D_";

        internal static readonly CultureInfo CultureEs = CultureInfo.GetCultureInfo("es-MX");
        private static readonly Color ColorAsistencia = Color.FromArgb(0xC5, 0xDF, 0xB4); // verde claro

        // ── Estado interno ────────────────────────────────────────────────────
        /// <summary>Tabla maestra del listado de empleados (con columna "Sel." checkbox).</summary>
        private DataTable _dtEmployeeList = BuildEmptyEmployeeListTable();

        /// <summary>Tabla del reporte de asistencias/inasistencias generada por <see cref="BtnLoadReport"/>.</summary>
        private DataTable? _dtReportPreview;
        private List<DateTime> _reportDays = new();
        private Dictionary<string, Color> _attendanceColorsByPrefix = new(StringComparer.OrdinalIgnoreCase);
        private bool _showingReport;

        // ── Inicio del formulario ─────────────────────────────────────────────

        public void BeginFormCat()
        {
            if (frm == null) return;

            SetControls();
            frm.lblEmployeeAdvice.Text = string.Empty;
            ShowEmployeeList();
        }

        private void SetControls()
        {
            if (frm == null) return;

            ClsComboBoxes.CboLoadActives(frm.cboAttendenceType, AttendanceType.Cbo);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(frm.cboAttendenceType, "04"); //<-- falta injustificada

            ClsComboBoxes.CboLoadActives(frm.cboLP, PlacePayment.Cbo);

            ClsComboBoxes.CboLoadActives(frm.cboSeason, Season.CboWithDates);

            frm.cboSeason.SelectedIndexChanged += CboSeason_SelectedIndexChanged;
        }

        // ── Evento temporada → fechas ─────────────────────────────────────────
        // La temporada sólo se usa para proponer el rango de fechas del reporte,
        // no filtra los empleados agregados al listado.

        public void CboSeason_SelectedIndexChanged(object? sender, EventArgs e)
            => ApplySeasonDatesToDatePickers();

        /// <summary>
        /// dtpDate1 = fecha inicio de la temporada.
        /// dtpDate2 = si hoy está dentro del rango → hoy; si hoy ya pasó la fecha fin → fecha fin.
        /// Si no hay temporada seleccionada, no modifica los pickers.
        /// </summary>
        private void ApplySeasonDatesToDatePickers()
        {
            if (frm == null || frm.cboSeason.SelectedIndex < 1) return;
            if (frm.cboSeason.SelectedItem is not DataRowView drv) return;

            DataTable tbl = drv.Row.Table;
            if (!tbl.Columns.Contains(Season.ColumnStartDate) || !tbl.Columns.Contains(Season.ColumnEndDate)) return;
            if (drv.Row[Season.ColumnStartDate] is DBNull || drv.Row[Season.ColumnEndDate] is DBNull) return;

            DateTime seasonStart = Convert.ToDateTime(drv.Row[Season.ColumnStartDate]).Date;
            DateTime seasonEnd   = Convert.ToDateTime(drv.Row[Season.ColumnEndDate]).Date;
            DateTime today       = DateTime.Today;

            frm.dtpDate1.Value = seasonStart;
            frm.dtpDate2.Value = today <= seasonEnd ? today : seasonEnd;
        }

        // ── Buscar empleado ───────────────────────────────────────────────────

        public void BtnSearchEmployee()
        {
            if (frm == null) return;

            string id = ParseEmployeeCodes(frm.txbIdEmployee.Text).FirstOrDefault() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(id)) return;

            try
            {
                DataTable dt = FetchEmployeeByCode(id);

                if (dt.Rows.Count == 0)
                {
                    SetAdvice($"No se encontró el empleado {id}.", isError: true);
                    return;
                }

                string nombre = dt.Rows[0]["Nombre"]?.ToString()?.Trim() ?? string.Empty;
                SetAdvice($"Empleado: {id} – {nombre}", isError: false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al buscar empleado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Agregar empleado(s) — soporta pegar múltiples códigos ────────────

        public void BtnAddEmployee()
        {
            if (frm == null) return;

            List<string> codes = ParseEmployeeCodes(frm.txbIdEmployee.Text).ToList();
            if (codes.Count == 0)
            {
                SetAdvice("Ingresa o pega uno o más códigos de empleado.", isError: true);
                return;
            }

            if (codes.Count == 1)
            {
                AddSingleEmployee(codes[0]);
            }
            else
            {
                AddMultipleEmployees(codes);
            }
        }

        private void AddSingleEmployee(string id)
        {
            DataRow? existing = FindEmployeeInList(id);
            if (existing != null)
            {
                existing[ColSel] = "1";
                RefreshEmployeeDgv();
                SetAdvice($"⚠ El empleado {id} ya está en el listado.", isError: true);
                return;
            }

            try
            {
                DataTable dt = FetchEmployeeByCode(id);
                if (dt.Rows.Count == 0)
                {
                    SetAdvice($"No se encontró el empleado {id}.", isError: true);
                    return;
                }

                AddRowsToEmployeeList(dt);
                RefreshEmployeeDgv();
                SetAdvice($"Empleado {id} agregado correctamente.", isError: false);
                frm!.txbIdEmployee.Clear();
                ShowEmployeeList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al agregar empleado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddMultipleEmployees(List<string> codes)
        {
            int added    = 0;
            int repeated = 0;
            var notFound = new List<string>();

            foreach (string id in codes)
            {
                try
                {
                    DataRow? existing = FindEmployeeInList(id);
                    if (existing != null)
                    {
                        existing[ColSel] = "1";
                        repeated++;
                        continue;
                    }

                    DataTable dt = FetchEmployeeByCode(id);
                    if (dt.Rows.Count == 0)
                    {
                        notFound.Add(id);
                        continue;
                    }

                    AddRowsToEmployeeList(dt);
                    added++;
                }
                catch
                {
                    notFound.Add(id);
                }
            }

            RefreshEmployeeDgv();
            ShowEmployeeList();

            var summary = new System.Text.StringBuilder();
            summary.Append($"{added} agregado(s)");
            if (repeated > 0) summary.Append($",  {repeated} ya existía(n)");
            if (notFound.Count > 0) summary.Append($",  no encontrado(s): {string.Join(", ", notFound)}");
            SetAdvice(summary.ToString(), isError: notFound.Count > 0);

            frm!.txbIdEmployee.Clear();
        }

        /// <summary>
        /// Parsea el texto del RichTextBox y devuelve códigos de empleado únicos, no vacíos y normalizados.
        /// Compatible con copia de celdas de Excel (separadas por saltos de línea o tabuladores) y con
        /// captura manual usando Shift+Enter, que en un RichTextBox inserta un salto de línea "suave" (\v)
        /// en lugar de \r\n.
        /// </summary>
        private static IEnumerable<string> ParseEmployeeCodes(string input)
        {
            return input
                .Split(new[] { '\r', '\n', '\t', '\v' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Trim())
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Select(NormalizeEmployeeCode)
                .Distinct(StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Si el código es completamente numérico y tiene menos de 6 dígitos, lo rellena con ceros a la izquierda
        /// (ej. "38" → "000038"). Los códigos alfanuméricos (ej. "MD0099") se dejan sin cambios.
        /// </summary>
        private static string NormalizeEmployeeCode(string code)
        {
            string trimmed = code.Trim();

            if (trimmed.Length > 0 && trimmed.Length < 6 && trimmed.All(char.IsDigit))
                return trimmed.PadLeft(6, '0');

            return trimmed;
        }

        /// <summary>
        /// Pega el contenido del portapapeles como texto plano (sin formato/colores de Excel),
        /// reemplazando tabuladores por saltos de línea para que cada código de empleado quede en su propia línea.
        /// </summary>
        public void PasteEmployeeCodesAsPlainText()
        {
            if (frm == null || !Clipboard.ContainsText()) return;

            string text = Clipboard.GetText(TextDataFormat.UnicodeText);
            if (string.IsNullOrEmpty(text))
                text = Clipboard.GetText(TextDataFormat.Text);
            if (string.IsNullOrEmpty(text)) return;

            text = text.Replace("\t", Environment.NewLine);

            frm.txbIdEmployee.SelectedText = text;
        }

        /// <summary>Busca un empleado por código en vw_Employees_Info.</summary>
        private DataTable FetchEmployeeByCode(string codigo)
        {
            var p = new Dictionary<string, object> { ["@codigo"] = codigo };

            return ClsQuerysDB.ExecuteParameterizedQuery(
                $"SELECT '1' AS [{ColSel}], id_employee AS [{ColCodigo}], * FROM vw_Employees_Info WHERE id_employee = @codigo ORDER BY Nombre;",
                p);
        }

        // ── Agregar listado por filtro de lugar de pago (LP) ──────────────────

        public void BtnAddList()
        {
            if (frm == null) return;

            try
            {
                string? idPaymentPlace = frm.cboLP.ComboValueOrNull();

                DataTable dt = FetchEmployeeListByPaymentPlace(idPaymentPlace);

                if (dt.Rows.Count == 0)
                {
                    SetAdvice("No se encontraron empleados con los filtros seleccionados.", isError: true);
                    return;
                }

                int added = AddRowsToEmployeeList(dt);
                RefreshEmployeeDgv();
                SetAdvice($"{added} empleado(s) agregado(s) al listado.", isError: false);
                ShowEmployeeList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al agregar listado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Trae los empleados de vw_Employees_Info, filtrando (opcionalmente) por el lugar de pago
        /// (Nom_Employees.id_paymentPlace) cuando el usuario seleccionó uno en cboLP.
        /// </summary>
        private DataTable FetchEmployeeListByPaymentPlace(string? idPaymentPlace)
        {
            var p = new Dictionary<string, object>
            {
                ["@idPaymentPlace"] = (object?)idPaymentPlace ?? DBNull.Value,
            };

            return ClsQuerysDB.ExecuteParameterizedQuery(
                $@"SELECT '1' AS [{ColSel}], vw.id_employee AS [{ColCodigo}], vw.*
                   FROM vw_Employees_Info vw
                   LEFT JOIN Nom_Employees emp ON emp.id_employee = vw.id_employee
                   WHERE (@idPaymentPlace IS NULL OR emp.id_paymentPlace = @idPaymentPlace)
                   ORDER BY Nombre;",
                p);
        }

        // ── Limpiar listado ───────────────────────────────────────────────────

        public void BtnClearList()
        {
            _dtEmployeeList = BuildEmptyEmployeeListTable();
            RefreshEmployeeDgv();
            ShowEmployeeList();
            if (frm != null) frm.lblEmployeeAdvice.Text = string.Empty;
        }

        // ── Alternar vista DGV ────────────────────────────────────────────────

        public void ChbShowEmployees_CheckedChanged()
        {
            if (frm == null) return;
            if (frm.chbShowEmployees.Checked)
                ShowEmployeeList();
        }

        public void ChbShowReport_CheckedChanged()
        {
            if (frm == null) return;
            if (!frm.chbShowReport.Checked) return;

            if (_dtReportPreview == null || _dtReportPreview.Rows.Count == 0)
            {
                SystemSounds.Exclamation.Play();
                frm.chbShowReport.Checked = false;
                frm.chbShowEmployees.Checked = true;
                SetAdvice("No hay reporte cargado. Usa \"Cargar reporte\" primero.", isError: true);
                return;
            }

            ShowReport();
        }

        // ── Cargar reporte de asistencias/inasistencias ────────────────────────

        public void BtnLoadReport()
        {
            if (frm == null) return;

            DateTime date1 = frm.dtpDate1.Value.Date;
            DateTime date2 = frm.dtpDate2.Value.Date;

            if (date2 < date1)
            {
                MessageBox.Show("La fecha final no puede ser menor a la fecha inicial.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<string> employeeCodes = GetCheckedEmployeeCodes();
            if (employeeCodes.Count == 0)
            {
                SetAdvice("Marca (check) al menos un empleado en el listado antes de cargar el reporte.", isError: true);
                return;
            }

            string defaultPrefix = GetSelectedAttendancePrefix();
            if (string.IsNullOrWhiteSpace(defaultPrefix))
            {
                SetAdvice("Selecciona un tipo de inasistencia por defecto en \"Innasistencia por defecto\".", isError: true);
                return;
            }

            if (!ValidateConnectionSettings()) return;

            try
            {
                DataTable dtAsistencias   = FetchAsistenciasQuery(employeeCodes, date1, date2);
                DataTable dtInasistencias = FetchInasistenciasQuery(employeeCodes, date1, date2);

                if (dtAsistencias.Rows.Count == 0 && dtInasistencias.Rows.Count == 0)
                {
                    SystemSounds.Exclamation.Play();
                    SetAdvice("No se encontraron datos de asistencia para el rango y empleados seleccionados.", isError: true);
                    return;
                }

                DataTable dtEmployeeInfo = FetchEmployeeInfoQuery(employeeCodes);

                _attendanceColorsByPrefix = GetAttendanceTypeColorsByPrefix();
                _reportDays = EachDayInclusive(date1, date2).ToList();
                _dtReportPreview = BuildReportTable(
                    employeeCodes, dtEmployeeInfo, dtAsistencias, dtInasistencias, defaultPrefix);

                ShowReport();
                SetAdvice(string.Empty, isError: false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error al cargar reporte", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Generar reporte en Excel ───────────────────────────────────────────

        public void BtnGenerateExcelReport()
        {
            if (_dtReportPreview == null || _dtReportPreview.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para generar el reporte (usa \"Cargar reporte\" antes).",
                    "Reporte de inasistencias", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string dateRange = $"{frm!.dtpDate1.Value:dd/MM/yyyy} al {frm.dtpDate2.Value:dd/MM/yyyy}";

            new ClsExcelAsistenciaASConsulta().GenerateExcelReport(
                _dtReportPreview,
                _reportDays,
                _attendanceColorsByPrefix,
                ColorAsistencia,
                dateRange);
        }

        // ── Coloreado de celdas del reporte (evento CellFormatting) ───────────

        public void DgvReport_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (!_showingReport || frm == null) return;
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string colName = frm.dgvReport.Columns[e.ColumnIndex].Name;
            if (!TryParseDayColumn(colName, out _)) return;

            string? value = e.Value?.ToString()?.Trim();
            if (string.IsNullOrWhiteSpace(value)) return;

            Color color;
            if (string.Equals(value, ValueAsistencia, StringComparison.OrdinalIgnoreCase))
                color = ColorAsistencia;
            else if (!_attendanceColorsByPrefix.TryGetValue(value, out color))
                return;

            e.CellStyle.BackColor          = color;
            e.CellStyle.SelectionBackColor = ControlPaint.Dark(color, 0.1f);
        }

        // ── Validaciones y datos auxiliares ────────────────────────────────────

        /// <summary>Códigos de los empleados marcados (Sel.=1) en el listado.</summary>
        private List<string> GetCheckedEmployeeCodes()
        {
            if (!_dtEmployeeList.Columns.Contains(ColSel) || !_dtEmployeeList.Columns.Contains(ColCodigo))
                return new List<string>();

            return _dtEmployeeList.AsEnumerable()
                .Where(r => r[ColSel]?.ToString() == "1")
                .Select(r => r[ColCodigo]?.ToString()?.Trim() ?? string.Empty)
                .Where(c => !string.IsNullOrWhiteSpace(c))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();
        }

        /// <summary>
        /// Valida que la configuración de conexión (servidor, base de datos principal y base de datos
        /// de empleados) esté completa antes de intentar las consultas del reporte.
        /// </summary>
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
                    "base de datos de empleados). Verifica la configuración antes de generar el reporte.",
                    "Configuración de conexión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return !incompleta;
        }

        /// <summary>Prefijo (v_prefix) del tipo de asistencia seleccionado en cboAttendenceType.</summary>
        private string GetSelectedAttendancePrefix()
        {
            if (frm == null) return string.Empty;
            object? value = frm.cboAttendenceType.GetColumnValue(AttendanceType.ColumnPrefix);
            return value?.ToString()?.Trim() ?? string.Empty;
        }

        /// <summary>
        /// Mapa prefijo → color, construido desde la misma tabla que llena cboAttendenceType
        /// (columna <see cref="AttendanceType.ColumnColor"/>).
        /// </summary>
        private Dictionary<string, Color> GetAttendanceTypeColorsByPrefix()
        {
            var map = new Dictionary<string, Color>(StringComparer.OrdinalIgnoreCase);
            if (frm?.cboAttendenceType.DataSource is not DataTable dt) return map;
            if (!dt.Columns.Contains(AttendanceType.ColumnPrefix) || !dt.Columns.Contains(AttendanceType.ColumnColor))
                return map;

            foreach (DataRow row in dt.Rows)
            {
                string prefix = row[AttendanceType.ColumnPrefix]?.ToString()?.Trim() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(prefix) || map.ContainsKey(prefix)) continue;

                string rawColor = row[AttendanceType.ColumnColor]?.ToString()?.Trim() ?? string.Empty;
                map[prefix] = ParseDbColor(rawColor, Color.LightPink);
            }

            return map;
        }

        /// <summary>Convierte un color guardado en BD (nombre HTML o hex, con o sin '#') a <see cref="Color"/>.</summary>
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

        // ── Consultas del reporte ──────────────────────────────────────────────

        /// <summary>
        /// Asistencias/inasistencias calculadas desde nomhojas / nomhojas_temp, en la base de datos de
        /// otro sistema (<see cref="ClsConfig.DbEmployees"/>). ASISTENCIA=1 si hubo importe pagado ese día.
        /// </summary>
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

        /// <summary>Inasistencias explícitas (permisos, vacaciones, faltas, etc.) de la BD principal.</summary>
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

        /// <summary>Información básica (nombre, LP) de los empleados marcados, de la BD principal.</summary>
        private DataTable FetchEmployeeInfoQuery(List<string> employeeCodes)
        {
            var parameters = new Dictionary<string, object>();
            string inClause = BuildInClause(employeeCodes, "emp", parameters);

            string query = $@"
                SELECT id_employee, v_name, v_lastNamePat, v_lastNameMat, id_paymentPlace
                FROM Nom_Employees
                WHERE id_employee IN {inClause};";

            return ClsQuerysDB.ExecuteParameterizedQuery(query, parameters);
        }

        /// <summary>Construye "(@p0, @p1, ...)" y agrega los parámetros correspondientes al diccionario.</summary>
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

        // ── Construcción de la tabla unificada del reporte ────────────────────

        private DataTable BuildReportTable(
            List<string> employeeCodes,
            DataTable dtEmployeeInfo,
            DataTable dtAsistencias,
            DataTable dtInasistencias,
            string defaultPrefix)
        {
            var table = new DataTable();
            table.Columns.Add(ReportColCodigo, typeof(string));
            table.Columns.Add(ReportColNombre, typeof(string));
            table.Columns.Add(ReportColLp, typeof(string));
            table.Columns.Add(ReportColTotal, typeof(int));
            foreach (DateTime day in _reportDays)
                table.Columns.Add(BuildDayColumnName(day), typeof(string));

            var infoByCode = dtEmployeeInfo.AsEnumerable()
                .GroupBy(r => r["id_employee"]?.ToString()?.Trim() ?? string.Empty)
                .ToDictionary(g => g.Key, g => g.First(), StringComparer.OrdinalIgnoreCase);

            var asistenciaLookup = dtAsistencias.AsEnumerable()
                .GroupBy(r => (
                    Codigo: r["Codigo"]?.ToString()?.Trim() ?? string.Empty,
                    Fecha: NormalizeDate(r["Fecha"])))
                .ToDictionary(g => g.Key, g => Convert.ToInt32(g.First()["ASISTENCIA"]));

            var inasistenciaLookup = dtInasistencias.AsEnumerable()
                .GroupBy(r => (
                    Codigo: r["id_employee"]?.ToString()?.Trim() ?? string.Empty,
                    Fecha: NormalizeDate(r["d_attendance"])))
                .ToDictionary(g => g.Key, g => g.First()["v_prefix"]?.ToString()?.Trim() ?? string.Empty);

            foreach (string codigo in employeeCodes)
            {
                DataRow newRow = table.NewRow();
                newRow[ReportColCodigo] = codigo;

                string nombreCompleto = codigo;
                string lp = string.Empty;
                if (infoByCode.TryGetValue(codigo, out DataRow? infoRow) && infoRow != null)
                {
                    string nombre = infoRow["v_name"]?.ToString()?.Trim() ?? string.Empty;
                    string apPat  = infoRow["v_lastNamePat"]?.ToString()?.Trim() ?? string.Empty;
                    string apMat  = infoRow["v_lastNameMat"]?.ToString()?.Trim() ?? string.Empty;
                    string full   = string.Join(" ", new[] { apPat, apMat, nombre }.Where(s => !string.IsNullOrWhiteSpace(s)));
                    if (!string.IsNullOrWhiteSpace(full)) nombreCompleto = full;
                    lp = infoRow["id_paymentPlace"]?.ToString()?.Trim() ?? string.Empty;
                }

                newRow[ReportColNombre] = nombreCompleto;
                newRow[ReportColLp]     = lp;

                int totalAsistencias = 0;
                foreach (DateTime day in _reportDays)
                {
                    // Por defecto, todo día se marca con el prefijo seleccionado (haya o no dato en las
                    // consultas), excepto domingo, que se deja en blanco salvo que sí haya asistencia.
                    string value = day.DayOfWeek == DayOfWeek.Sunday ? string.Empty : defaultPrefix;

                    if (asistenciaLookup.TryGetValue((codigo, day), out int asistencia) && asistencia == 1)
                        value = ValueAsistencia; // asistencia real: se muestra siempre, incluso en domingo

                    if (inasistenciaLookup.TryGetValue((codigo, day), out string? prefijo) && !string.IsNullOrWhiteSpace(prefijo))
                        value = prefijo; // la inasistencia explícita siempre sobreescribe

                    if (string.Equals(value, ValueAsistencia, StringComparison.OrdinalIgnoreCase))
                        totalAsistencias++;

                    newRow[BuildDayColumnName(day)] = value;
                }

                newRow[ReportColTotal] = totalAsistencias;
                table.Rows.Add(newRow);
            }

            return table;
        }

        internal static string BuildDayColumnName(DateTime day) => DayColumnPrefix + day.ToString("yyyy-MM-dd");

        internal static bool TryParseDayColumn(string columnName, out DateTime day)
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
            DateTime end   = rangeEnd.Date;
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

        // ── Mostrar el reporte en el DGV ───────────────────────────────────────

        private void ShowReport()
        {
            if (frm == null || _dtReportPreview == null) return;

            _showingReport = true;

            frm.dgvReport.ReadOnly = true;
            frm.dgvReport.AutoGenerateColumns = true;
            frm.dgvReport.DataSource = null;
            frm.dgvReport.DataSource = _dtReportPreview;

            ApplyDayColumnHeaders();

            // El encabezado de fecha usa 2 líneas (mes-día / día de semana); se necesita más alto
            // y sin la reserva de espacio de la flecha de "ordenar" para aprovechar más celdas en pantalla.
            frm.dgvReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            frm.chbShowReport.Checked = true;
            frm.chbShowEmployees.Checked = false;
        }

        /// <summary>
        /// Muestra "mes-día" + día de la semana (ej. "ene-02" / "vie") en 2 líneas en el encabezado de cada
        /// columna de fecha del DGV, deshabilitando además el orden por esa columna para ahorrar espacio
        /// (sin la flecha de "ordenar") y poder ver más columnas en pantalla.
        /// </summary>
        private void ApplyDayColumnHeaders()
        {
            if (frm == null) return;
            foreach (DataGridViewColumn col in frm.dgvReport.Columns)
            {
                if (TryParseDayColumn(col.Name, out DateTime day))
                {
                    string monthAbbr = day.ToString("MMM", CultureEs).Replace(".", string.Empty).ToLower(CultureEs);
                    string dayAbbr   = RemoveDiacritics(day.ToString("ddd", CultureEs)).Replace(".", string.Empty).ToLower(CultureEs);
                    col.HeaderText   = $"{monthAbbr}-{day:dd}{Environment.NewLine}{dayAbbr}";
                    col.ToolTipText  = day.ToString("dddd dd 'de' MMMM 'de' yyyy", CultureEs);
                    col.SortMode     = DataGridViewColumnSortMode.NotSortable;
                }
            }
        }

        /// <summary>Quita acentos/diacríticos (ej. "mié" → "mie") para mostrar abreviaturas de días sin tilde.</summary>
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

        // ── Helpers DGV ──────────────────────────────────────────────────────

        private void ShowEmployeeList()
        {
            if (frm == null) return;

            _showingReport = false;

            frm.dgvReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            frm.dgvReport.ReadOnly = false;
            frm.dgvReport.AutoGenerateColumns = true;
            frm.dgvReport.DataSource = null;
            frm.dgvReport.DataSource = _dtEmployeeList;
            ApplyCheckBoxColumnToSel();
            HideColumnsInDgv(_columnsToHideInDgv);

            frm.chbShowEmployees.Checked = true;
            frm.chbShowReport.Checked = false;
        }

        /// <summary>
        /// Oculta en el DGV las columnas cuyo nombre esté en <paramref name="columnsToHide"/>.
        /// Se ignoran nombres de columna que no existan (comprobación previa con Columns.Contains).
        /// </summary>
        private void HideColumnsInDgv(IEnumerable<string> columnsToHide)
        {
            if (frm == null) return;
            foreach (string col in columnsToHide)
            {
                if (frm.dgvReport.Columns.Contains(col))
                    frm.dgvReport.Columns[col].Visible = false;
            }
        }

        private void RefreshEmployeeDgv()
        {
            if (frm == null) return;
            ShowEmployeeList();
        }

        /// <summary>
        /// Convierte la columna "Sel." en una columna de checkboxes en el DGV.
        /// </summary>
        private void ApplyCheckBoxColumnToSel()
        {
            if (frm == null) return;
            if (!frm.dgvReport.Columns.Contains(ColSel)) return;

            var col = frm.dgvReport.Columns[ColSel];
            if (col is DataGridViewCheckBoxColumn) return;

            int ordinal = col.Index;
            frm.dgvReport.Columns.Remove(col);

            var chkCol = new DataGridViewCheckBoxColumn
            {
                Name             = ColSel,
                HeaderText       = ColSel,
                DataPropertyName = ColSel,
                TrueValue        = "1",
                FalseValue       = "0",
                Width            = 45,
                DisplayIndex     = ordinal,
            };
            frm.dgvReport.Columns.Insert(ordinal, chkCol);
        }

        // ── Helpers listado ───────────────────────────────────────────────────

        private static DataTable BuildEmptyEmployeeListTable()
        {
            var dt = new DataTable();
            dt.Columns.Add(ColSel, typeof(string));
            return dt;
        }

        private DataRow? FindEmployeeInList(string codigo)
        {
            if (!_dtEmployeeList.Columns.Contains(ColCodigo)) return null;
            return _dtEmployeeList.AsEnumerable()
                .FirstOrDefault(r => string.Equals(
                    r[ColCodigo]?.ToString()?.Trim(),
                    codigo,
                    StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>Agrega filas al listado evitando duplicados. Devuelve cantidad agregada.</summary>
        private int AddRowsToEmployeeList(DataTable source)
        {
            foreach (DataColumn col in source.Columns)
            {
                if (!_dtEmployeeList.Columns.Contains(col.ColumnName))
                    _dtEmployeeList.Columns.Add(col.ColumnName, col.DataType);
            }

            int count = 0;
            foreach (DataRow srcRow in source.Rows)
            {
                string codigo = srcRow.Table.Columns.Contains(ColCodigo)
                    ? srcRow[ColCodigo]?.ToString()?.Trim() ?? string.Empty
                    : string.Empty;

                DataRow? existing = string.IsNullOrWhiteSpace(codigo) ? null : FindEmployeeInList(codigo);
                if (existing != null)
                {
                    existing[ColSel] = "1";
                    continue;
                }

                DataRow newRow = _dtEmployeeList.NewRow();
                foreach (DataColumn col in source.Columns)
                {
                    if (_dtEmployeeList.Columns.Contains(col.ColumnName))
                        newRow[col.ColumnName] = srcRow[col.ColumnName];
                }
                newRow[ColSel] = "1";
                _dtEmployeeList.Rows.Add(newRow);
                count++;
            }

            return count;
        }

        private DataTable GetSelectedEmployeeRows()
        {
            DataTable dt = _dtEmployeeList.Clone();
            foreach (DataRow row in _dtEmployeeList.Rows)
            {
                if (row[ColSel]?.ToString() == "1")
                    dt.ImportRow(row);
            }
            return dt;
        }

        private void SetAdvice(string text, bool isError)
        {
            if (frm == null) return;
            frm.lblEmployeeAdvice.Text      = text;
            frm.lblEmployeeAdvice.ForeColor = isError ? Color.Red : Color.Gray;
        }
    }
}
