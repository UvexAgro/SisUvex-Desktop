using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Extentions;
using SisUvex.Catalogos.Metods.Forms.SelectionForms;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Catalogos.Metods.TextBoxes;
using SisUvex.Configuracion;
using SisUvex.Nomina.Asistencia_AS.ModifyAttendanceEmployees;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
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
        internal const string ReportColFaltas   = "Faltas";
        internal const string ReportColFaltas30 = "Faltas 30 días";
        internal const string ValueAsistencia  = "A";
        /// <summary>Tamaño de la ventana de "últimos N días" usada por <see cref="ReportColFaltas30"/>.</summary>
        internal const int Faltas30Dias = 30;
        internal const string DayColumnPrefix  = "D_";

        internal static readonly CultureInfo CultureEs = CultureInfo.GetCultureInfo("es-MX");
        private static readonly Color ColorAsistencia = Color.FromArgb(0xC5, 0xDF, 0xB4); // verde claro

        // ── Estado interno ────────────────────────────────────────────────────
        /// <summary>Tabla maestra del listado de empleados (con columna "Sel." checkbox).</summary>
        private DataTable _dtEmployeeList = BuildEmptyEmployeeListTable();

        /// <summary>Tabla del reporte de asistencias/inasistencias generada por <see cref="BtnLoadReport"/>.</summary>
        private DataTable? _dtReportPreview;
        private List<DateTime> _reportDays = new();
        /// <summary>Mapa prefijo → apariencia (color + estilo de letra), tomado del catálogo de tipos de asistencia.</summary>
        private Dictionary<string, AttendanceStyle> _attendanceStylesByPrefix = new(StringComparer.OrdinalIgnoreCase);
        /// <summary>Comentario (v_comments) de la inasistencia explícita, clave (código, día).</summary>
        private Dictionary<(string Codigo, DateTime Fecha), string> _commentsByCodeAndDay = new();
        private bool _showingReport;
        private bool _showingCalendar;
        /// <summary>Evita que asignar Checked en los botones de vista reentre a Show* mientras se cambia de modo.</summary>
        private bool _updatingViewButtons;
        /// <summary>Estado del checkbox del encabezado "Sel." (seleccionar todos).</summary>
        private bool _headerSelChecked;
        /// <summary>Evita reentrada al marcar/desmarcar todos los checkboxes del listado.</summary>
        private bool _updatingSel;
        /// <summary>Profundidad de BeginProgress: EndProgress solo cierra la barra en el nivel más externo.</summary>
        private int _progressDepth;
        private readonly ClsAsistenciaASCalendario _calendarCls = new();

        // ── Inicio del formulario ─────────────────────────────────────────────

        public void BeginFormCat()
        {
            if (frm == null) return;

            SetControls();
            DgvAsistenciaASPerf.EnableDoubleBuffer(frm.dgvReport);
            DgvAsistenciaASPerf.PrepareForFastScroll(frm.dgvReport);
            frm.lblEmployeeAdvice.Text = string.Empty;
            ShowEmployeeList(showProgress: false);
        }

        private void SetControls()
        {
            if (frm == null) return;

            // Carga cboAttendenceType a través de la caché estándar de catálogos (ClsComboBoxFiles),
            // usando la consulta centralizada AttendanceType.QueryCbo y mostrando sólo los activos.
            // Nom_AttendanceType no tiene registro en Pack_TablesUpdates, por lo que ClsAttendanceType
            // invalida manualmente esa caché (ClsComboBoxFiles.InvalidateCache) tras cualquier alta,
            // modificación o cambio de estatus, para que aquí siempre se refleje el dato más reciente.
            ClsComboBoxes.CboLoadActives(frm.cboAttendenceType, AttendanceType.Cbo);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(frm.cboAttendenceType, "04"); //<-- falta injustificada

            ClsComboBoxes.CboLoadActives(frm.cboLP, PlacePayment.Cbo);

            ClsComboBoxes.CboLoadActives(frm.cboSeason, Season.CboWithDates);

            frm.txbLastDays.Clear();
            ClsTextBoxes.TxbApplyKeyPressEventInt(frm.txbLastDays);

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

        // ── Buscar empleado (formulario de selección visual) ──────────────────

        /// <summary>
        /// Abre el formulario de selección de empleados (igual que <c>button1_Click</c> de
        /// <see cref="Archivo.Etiquetas.CajaEmpleado.FrmCajaEmpleado"/>) y, si se selecciona uno,
        /// agrega su código a <c>txbIdEmployee</c>: si ya había texto, lo agrega en una línea nueva.
        /// </summary>
        public void BtnSearchEmployee()
        {
            if (frm == null) return;

            ClsSelectionForm sel = new();
            sel.OpenSelectionForm("EmployeeBasic", ColCodigo);

            if (string.IsNullOrWhiteSpace(sel.SelectedValue)) return;

            AppendEmployeeCodeToTextBox(NormalizeEmployeeCode(sel.SelectedValue.Trim()));
        }

        /// <summary>Agrega un código de empleado al final de txbIdEmployee, en una línea nueva si ya había texto.</summary>
        private void AppendEmployeeCodeToTextBox(string code)
        {
            if (frm == null) return;

            string current = frm.txbIdEmployee.Text;
            frm.txbIdEmployee.Text = string.IsNullOrWhiteSpace(current)
                ? code
                : current.TrimEnd('\r', '\n', '\v') + Environment.NewLine + code;

            frm.txbIdEmployee.SelectionStart = frm.txbIdEmployee.Text.Length;
            frm.txbIdEmployee.ScrollToCaret();
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

            BeginProgress();
            try
            {
                DataTable dt = FetchEmployeeByCode(id);
                AdvanceTo(400);
                if (dt.Rows.Count == 0)
                {
                    SetAdvice($"No se encontró el empleado {id}.", isError: true);
                    return;
                }

                AddRowsToEmployeeList(dt);
                AdvanceTo(650);
                RefreshEmployeeDgv();
                SetAdvice($"Empleado {id} agregado correctamente.", isError: false);
                frm!.txbIdEmployee.Clear();
                ShowEmployeeList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al agregar empleado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                EndProgress();
            }
        }

        private void AddMultipleEmployees(List<string> codes)
        {
            int added    = 0;
            int repeated = 0;
            var notFound = new List<string>();

            BeginProgress();
            try
            {
                for (int i = 0; i < codes.Count; i++)
                {
                    string id = codes[i];
                    try
                    {
                        DataRow? existing = FindEmployeeInList(id);
                        if (existing != null)
                        {
                            existing[ColSel] = "1";
                            repeated++;
                        }
                        else
                        {
                            DataTable dt = FetchEmployeeByCode(id);
                            if (dt.Rows.Count == 0)
                            {
                                notFound.Add(id);
                            }
                            else
                            {
                                AddRowsToEmployeeList(dt);
                                added++;
                            }
                        }
                    }
                    catch
                    {
                        notFound.Add(id);
                    }

                    ReportRange(i + 1, codes.Count, 0, 820);
                }

                RefreshEmployeeDgv();
                ShowEmployeeList();
            }
            finally
            {
                EndProgress();
            }

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

            BeginProgress();
            try
            {
                string? idPaymentPlace = frm.cboLP.ComboValueOrNull();

                DataTable dt = FetchEmployeeListByPaymentPlace(idPaymentPlace);
                AdvanceTo(220);

                if (dt.Rows.Count == 0)
                {
                    SetAdvice("No se encontraron empleados con los filtros seleccionados.", isError: true);
                    return;
                }

                int added = AddRowsToEmployeeList(dt, rangeFrom: 220, rangeTo: 820);
                AdvanceTo(820);
                RefreshEmployeeDgv();
                SetAdvice($"{added} empleado(s) agregado(s) al listado.", isError: false);
                ShowEmployeeList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al agregar listado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                EndProgress();
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
            if (frm == null || _updatingViewButtons) return;
            if (frm.chbShowEmployees.Checked)
                ShowEmployeeList();
        }

        public void ChbShowReport_CheckedChanged()
        {
            if (frm == null || _updatingViewButtons) return;
            if (!frm.chbShowReport.Checked) return;

            if (_dtReportPreview == null || _dtReportPreview.Rows.Count == 0)
            {
                SystemSounds.Exclamation.Play();
                SetViewButtons(employees: true, report: false, calendar: false);
                SetAdvice("No hay reporte cargado. Usa \"Cargar reporte\" primero.", isError: true);
                return;
            }

            ShowReport();
        }

        public void ChbShowReportCalendar_CheckedChanged()
        {
            if (frm == null || _updatingViewButtons) return;
            if (!frm.chbShowReportCalendar.Checked) return;

            if (_dtReportPreview == null || _dtReportPreview.Rows.Count == 0)
            {
                SystemSounds.Exclamation.Play();
                SetViewButtons(employees: true, report: false, calendar: false);
                SetAdvice("No hay reporte cargado. Usa \"Cargar reporte\" primero.", isError: true);
                return;
            }

            ShowReportCalendar();
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

            if (!TryGetLastDays(out int? lastDays)) return;

            bool hasListedEmployees = HasEmployeesInList();
            List<string>? listedCodes = null;
            if (hasListedEmployees)
            {
                listedCodes = GetCheckedEmployeeCodes();
                if (listedCodes.Count == 0)
                {
                    SetAdvice("Marca (check) al menos un empleado en el listado antes de cargar el reporte.", isError: true);
                    return;
                }
            }
            else if (lastDays == null)
            {
                SetAdvice("Agrega empleados al listado, o indica \"Últimos días\" para consultar quienes tuvieron importe en esa ventana.", isError: true);
                return;
            }

            string defaultPrefix = GetSelectedAttendancePrefix();
            if (string.IsNullOrWhiteSpace(defaultPrefix))
            {
                SetAdvice("Selecciona un tipo de inasistencia por defecto en \"Innasistencia por defecto\".", isError: true);
                return;
            }

            if (!ValidateConnectionSettings()) return;

            BeginProgress();
            try
            {
                List<string> employeeCodes;
                int omittedLastDays = 0;

                if (lastDays is int n)
                {
                    DateTime lastStart = date2.AddDays(-n);
                    HashSet<string> withImporte = FetchEmployeeCodesWithImporte(lastStart, date2, listedCodes);

                    if (listedCodes != null)
                    {
                        omittedLastDays = listedCodes.Count(c => !withImporte.Contains(c));
                        employeeCodes = listedCodes.Where(c => withImporte.Contains(c)).ToList();
                    }
                    else
                    {
                        employeeCodes = withImporte.ToList();
                    }

                    if (employeeCodes.Count == 0)
                    {
                        SystemSounds.Exclamation.Play();
                        SetAdvice(
                            $"Ningún empleado tuvo importe del {lastStart:dd/MM/yyyy} al {date2:dd/MM/yyyy} (últimos {n} día(s)).",
                            isError: true);
                        return;
                    }
                }
                else
                {
                    employeeCodes = listedCodes!;
                }

                DataTable dtAsistencias = FetchAsistenciasQuery(employeeCodes, date1, date2);
                AdvanceTo(140);
                DataTable dtInasistencias = FetchInasistenciasQuery(employeeCodes, date1, date2);
                AdvanceTo(280);

                HashSet<string> codesWithRecords = CollectEmployeeCodesWithAttendanceRecords(dtAsistencias, dtInasistencias);
                int omitted = employeeCodes.Count(c => !codesWithRecords.Contains(c));
                employeeCodes = employeeCodes.Where(c => codesWithRecords.Contains(c)).ToList();

                if (employeeCodes.Count == 0)
                {
                    SystemSounds.Exclamation.Play();
                    SetAdvice("No se encontraron datos de asistencia para el rango y empleados seleccionados.", isError: true);
                    return;
                }

                DataTable dtEmployeeInfo = FetchEmployeeInfoQuery(employeeCodes);
                AdvanceTo(360);

                _attendanceStylesByPrefix = GetAttendanceTypeStylesByPrefix();
                _reportDays = EachDayInclusive(date1, date2).ToList();
                AdvanceTo(400);

                _dtReportPreview = BuildReportTable(
                    employeeCodes, dtEmployeeInfo, dtAsistencias, dtInasistencias, defaultPrefix,
                    onProgress: (done, total) => ReportRange(done, total, 400, 820));

                ShowReport();

                var adviceParts = new List<string>();
                if (omittedLastDays > 0)
                    adviceParts.Add($"Se omitieron {omittedLastDays} empleado(s) sin importe en los últimos {lastDays} día(s).");
                if (omitted > 0)
                    adviceParts.Add($"Se omitieron {omitted} empleado(s) sin registros de asistencia ni de inasistencia en el rango.");
                SetAdvice(string.Join(" ", adviceParts), isError: false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error al cargar reporte", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                EndProgress();
            }
        }

        // ── Abrir modificación de asistencias con los empleados marcados ──────

        public void BtnModifyAttendance()
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
                SetAdvice("Marca (check) al menos un empleado en el listado antes de modificar asistencias.", isError: true);
                return;
            }

            if (!ValidateConnectionSettings()) return;

            try
            {
                DataTable dtEmployeeInfo = FetchEmployeeInfoQuery(employeeCodes);
                var infoByCode = dtEmployeeInfo.AsEnumerable()
                    .GroupBy(r => r["id_employee"]?.ToString()?.Trim() ?? string.Empty)
                    .ToDictionary(g => g.Key, g => g.First(), StringComparer.OrdinalIgnoreCase);

                var employees = new List<(string Code, string FullName, string Lp)>();
                foreach (string codigo in employeeCodes)
                {
                    string fullName = codigo;
                    string lp = string.Empty;
                    if (infoByCode.TryGetValue(codigo, out DataRow? infoRow) && infoRow != null)
                    {
                        string nombre = infoRow["v_name"]?.ToString()?.Trim() ?? string.Empty;
                        string apPat  = infoRow["v_lastNamePat"]?.ToString()?.Trim() ?? string.Empty;
                        string apMat  = infoRow["v_lastNameMat"]?.ToString()?.Trim() ?? string.Empty;
                        string full   = string.Join(" ", new[] { apPat, apMat, nombre }.Where(s => !string.IsNullOrWhiteSpace(s)));
                        if (!string.IsNullOrWhiteSpace(full)) fullName = full;
                        lp = infoRow["id_paymentPlace"]?.ToString()?.Trim() ?? string.Empty;
                    }
                    employees.Add((codigo, fullName, lp));
                }

                employees = ClsAsistenciaASConsulta.OrderEmployeesByName(employees);

                string? selectedTypeId = frm.cboAttendenceType.SelectedValue?.ToString();

                DataTable? seedReport = null;
                List<DateTime>? seedDays = null;
                Dictionary<(string Codigo, DateTime Fecha), string>? seedComments = null;
                if (_dtReportPreview != null
                    && _reportDays.Count > 0
                    && _reportDays[0].Date == date1
                    && _reportDays[^1].Date == date2)
                {
                    seedReport = _dtReportPreview;
                    seedDays = _reportDays;
                    seedComments = _commentsByCodeAndDay;
                    var inReport = new HashSet<string>(
                        _dtReportPreview.AsEnumerable()
                            .Select(r => r[ReportColCodigo]?.ToString()?.Trim() ?? string.Empty)
                            .Where(c => !string.IsNullOrWhiteSpace(c)),
                        StringComparer.OrdinalIgnoreCase);
                    employees = employees.Where(e => inReport.Contains(e.Code)).ToList();
                }

                if (employees.Count == 0)
                {
                    SetAdvice("No hay empleados con registros de asistencia o inasistencia en el rango para modificar.", isError: true);
                    return;
                }

                // El formulario de modificar se abre como ventana hija de FrmMenu (no modal), por lo que
                // en vez de esperar a que se cierre, se escucha su evento ChangesSaved para volver a cargar
                // el reporte (mismos empleados marcados y mismo rango de fechas) en cuanto se guarde algo.
                ClsModifyAttendanceEmployees? modifyCls = ClsModifyAttendanceEmployees.Open(
                    employees, date1, date2, selectedTypeId, seedReport, seedDays, seedComments);
                if (modifyCls != null)
                    modifyCls.ChangesSaved += BtnLoadReport;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error al abrir modificación de asistencias",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Generar reporte en Excel ───────────────────────────────────────────

        public void BtnGenerateExcelReport()
        {
            if (frm == null) return;

            if (_dtReportPreview == null || _dtReportPreview.Rows.Count == 0)
            {
                SystemSounds.Exclamation.Play();
                SetAdvice("No hay datos para generar el reporte. Usa \"Cargar reporte\" primero.", isError: true);
                return;
            }

            string dateRange = $"{frm.dtpDate1.Value:dd/MM/yyyy} al {frm.dtpDate2.Value:dd/MM/yyyy}";

            new ClsExcelAsistenciaASConsulta().GenerateExcelReport(
                _dtReportPreview,
                _reportDays,
                _attendanceStylesByPrefix,
                ColorAsistencia,
                dateRange,
                BuildAttendanceTypesLegend());
        }

        /// <summary>
        /// Construye la leyenda "PREFIJO Nombre | PREFIJO Nombre | ..." con los tipos de asistencia activos
        /// (c_active = '1') de Nom_AttendanceType, en el orden del catálogo (id_attendanceType), para
        /// mostrarla como referencia en el reporte de Excel.
        /// </summary>
        private static string BuildAttendanceTypesLegend()
        {
            DataTable dt = ClsQuerysDB.GetDataTable(
                "SELECT v_prefix, v_name FROM Nom_AttendanceType WHERE c_active = '1' ORDER BY id_attendanceType;");

            var parts = dt.AsEnumerable()
                .Select(r => (
                    Prefix: r["v_prefix"]?.ToString()?.Trim() ?? string.Empty,
                    Name: r["v_name"]?.ToString()?.Trim() ?? string.Empty))
                .Where(t => !string.IsNullOrWhiteSpace(t.Prefix))
                .Select(t => string.IsNullOrWhiteSpace(t.Name) ? t.Prefix : $"{t.Prefix} {t.Name}");

            return string.Join(" | ", parts);
        }

        // ── Coloreado de celdas del reporte (evento CellFormatting) ───────────

        public void DgvReport_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (frm == null) return;

            if (_showingCalendar)
            {
                _calendarCls.CellFormatting(e, frm.dgvReport, _attendanceStylesByPrefix, ColorAsistencia);
                return;
            }

            if (!_showingReport) return;
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string colName = frm.dgvReport.Columns[e.ColumnIndex].Name;
            if (!TryParseDayColumn(colName, out _)) return;

            string? value = e.Value?.ToString()?.Trim();
            if (string.IsNullOrWhiteSpace(value)) return;

            Color color;
            FontStyle fontStyle = FontStyle.Regular;
            if (string.Equals(value, ValueAsistencia, StringComparison.OrdinalIgnoreCase))
                color = ColorAsistencia;
            else if (_attendanceStylesByPrefix.TryGetValue(value, out AttendanceStyle style))
            {
                color = style.Color;
                fontStyle = style.FontStyle;
            }
            else
                return;

            e.CellStyle.BackColor          = color;
            e.CellStyle.SelectionBackColor = ControlPaint.Dark(color, 0.1f);
            if (fontStyle != FontStyle.Regular)
                e.CellStyle.Font = DgvAsistenciaASPerf.GetStyledFont(frm.dgvReport.Font, fontStyle);
        }

        // ── Comentarios de las faltas (tooltip + marcador visual) ─────────────

        /// <summary>Muestra el comentario de la falta (si existe) como tooltip al pasar el mouse por la celda.</summary>
        public void DgvReport_CellToolTipTextNeeded(object? sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (!_showingReport || frm == null) return;
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string colName = frm.dgvReport.Columns[e.ColumnIndex].Name;
            if (!TryParseDayColumn(colName, out DateTime day)) return;

            string? comment = GetCellComment(e.RowIndex, day);
            if (!string.IsNullOrWhiteSpace(comment))
                e.ToolTipText = comment;
        }

        /// <summary>Dibuja un pequeño marcador (triángulo, como en Excel) en la esquina de las celdas que tienen comentario.</summary>
        public void DgvReport_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (frm == null) return;

            if (_showingCalendar)
            {
                _calendarCls.CellPainting(e, frm.dgvReport);
                return;
            }

            if (!_showingReport && !_showingCalendar)
            {
                PaintSelHeaderCheckBox(e);
                return;
            }

            if (!_showingReport) return;
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string colName = frm.dgvReport.Columns[e.ColumnIndex].Name;
            if (!TryParseDayColumn(colName, out DateTime day)) return;

            string? comment = GetCellComment(e.RowIndex, day);
            if (string.IsNullOrWhiteSpace(comment)) return;

            e.Paint(e.CellBounds, DataGridViewPaintParts.All);
            DrawCommentMarker(e.Graphics!, e.CellBounds);
            e.Handled = true;
        }

        /// <summary>Comentario (v_comments) registrado para el empleado de la fila y el día indicados, si existe.</summary>
        private string? GetCellComment(int rowIndex, DateTime day)
        {
            if (frm == null) return null;
            if (frm.dgvReport.Rows[rowIndex].DataBoundItem is not DataRowView drv) return null;

            string codigo = drv[ReportColCodigo]?.ToString()?.Trim() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(codigo)) return null;

            return _commentsByCodeAndDay.TryGetValue((codigo, day), out string? comment) && !string.IsNullOrWhiteSpace(comment)
                ? comment
                : null;
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

        /// <summary>True si el listado tiene empleados agregados (no importa si están marcados).</summary>
        private bool HasEmployeesInList()
        {
            return _dtEmployeeList.Rows.Count > 0 && _dtEmployeeList.Columns.Contains(ColCodigo);
        }

        /// <summary>
        /// Lee txbLastDays: vacío = sin límite extra; un entero ≥ 0 = ventana de esos días respecto a dtpDate2.
        /// </summary>
        private bool TryGetLastDays(out int? lastDays)
        {
            lastDays = null;
            if (frm == null) return true;

            string raw = frm.txbLastDays.Text.Trim();
            if (string.IsNullOrWhiteSpace(raw)) return true;

            if (!int.TryParse(raw, out int n) || n < 0)
            {
                SetAdvice("\"Últimos días\" debe ser un número entero mayor o igual a 0, o dejarse vacío.", isError: true);
                return false;
            }

            lastDays = n;
            return true;
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
        /// Mapa prefijo → apariencia (color + estilo de letra), construido desde la misma tabla que llena
        /// cboAttendenceType (columnas <see cref="AttendanceType.ColumnColor"/> y <see cref="AttendanceType.ColumnFontStyle"/>).
        /// </summary>
        private Dictionary<string, AttendanceStyle> GetAttendanceTypeStylesByPrefix()
        {
            var map = new Dictionary<string, AttendanceStyle>(StringComparer.OrdinalIgnoreCase);
            if (frm?.cboAttendenceType.DataSource is not DataTable dt) return map;
            if (!dt.Columns.Contains(AttendanceType.ColumnPrefix) || !dt.Columns.Contains(AttendanceType.ColumnColor))
                return map;

            foreach (DataRow row in dt.Rows)
            {
                string prefix = row[AttendanceType.ColumnPrefix]?.ToString()?.Trim() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(prefix) || map.ContainsKey(prefix)) continue;

                string rawColor = row[AttendanceType.ColumnColor]?.ToString()?.Trim() ?? string.Empty;
                Color color = ParseDbColor(rawColor, Color.LightPink);
                FontStyle fontStyle = dt.Columns.Contains(AttendanceType.ColumnFontStyle)
                    ? ParseFontStyle(row[AttendanceType.ColumnFontStyle])
                    : FontStyle.Regular;
                bool isAbsence = dt.Columns.Contains(AttendanceType.ColumncIsAbsence)
                    && (row[AttendanceType.ColumncIsAbsence]?.ToString()?.Trim() ?? string.Empty) == "1";

                map[prefix] = new AttendanceStyle(color, fontStyle, isAbsence);
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

        /// <summary>Convierte el bitmask numérico guardado en <c>n_fontStyle</c> a <see cref="FontStyle"/>.</summary>
        private static FontStyle ParseFontStyle(object? raw)
        {
            if (raw == null || raw == DBNull.Value) return FontStyle.Regular;
            return byte.TryParse(raw.ToString(), out byte value) ? (FontStyle)value : FontStyle.Regular;
        }

        /// <summary>
        /// Determina si el valor mostrado en la celda de un día cuenta como asistencia (para las columnas
        /// "Total"/"Asist." y su complemento "Faltas"), usado tanto por el reporte lineal como por el de
        /// calendario para que ambos calculen exactamente lo mismo:
        /// <list type="bullet">
        /// <item>Asistencia real ("A") siempre cuenta.</item>
        /// <item>Un tipo de asistencia explícito (<c>Nom_Attendance_AS</c>) cuenta según su <c>c_isAbsence</c>:
        /// si NO es inasistencia, cuenta como asistencia aunque no sea "A".</item>
        /// <item>Domingo sin ningún registro (célula en blanco) cuenta como asistencia por defecto, ya que
        /// normalmente no se paga sueldo ese día pero sí se considera que el empleado está presente, salvo
        /// que se le haya marcado explícitamente un tipo de inasistencia.</item>
        /// <item>Cualquier otro caso (día entre semana sin dato, marcado con el prefijo por defecto, o un
        /// tipo explícito marcado como inasistencia) cuenta como falta.</item>
        /// </list>
        /// </summary>
        internal static bool CountsAsAsistencia(string value, DayOfWeek dayOfWeek, Dictionary<string, AttendanceStyle> stylesByPrefix)
        {
            if (string.Equals(value, ValueAsistencia, StringComparison.OrdinalIgnoreCase)) return true;
            if (string.IsNullOrWhiteSpace(value)) return dayOfWeek == DayOfWeek.Sunday;
            return stylesByPrefix.TryGetValue(value, out AttendanceStyle style) && !style.IsAbsence;
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

        /// <summary>
        /// Códigos con importe &gt; 0 en nomhojas / nomhojas_temp entre <paramref name="dateStart"/> y
        /// <paramref name="dateEnd"/>. Si <paramref name="restrictToCodes"/> no es null, se limita a esos códigos.
        /// </summary>
        private HashSet<string> FetchEmployeeCodesWithImporte(
            DateTime dateStart,
            DateTime dateEnd,
            List<string>? restrictToCodes)
        {
            var parameters = new Dictionary<string, object>
            {
                ["@date1"] = dateStart,
                ["@date2"] = dateEnd,
            };

            string codeFilter = string.Empty;
            if (restrictToCodes != null && restrictToCodes.Count > 0)
                codeFilter = $" AND CODIGO IN {BuildInClause(restrictToCodes, "emp", parameters)}";

            string query = $@"
                USE [{ClsConfig.DbEmployees}];
                SELECT DISTINCT Codigo FROM
                (
                    SELECT d_fecha_cpn FECHA, c_codigo_emp CODIGO, SUM(n_importe_hoj) IMPORTE
                    FROM nomhojas GROUP BY d_fecha_cpn, c_codigo_emp
                    UNION
                    SELECT d_fecha_cpn FECHA, c_codigo_emp CODIGO, SUM(n_importe_hoj) IMPORTE
                    FROM nomhojas_temp GROUP BY d_fecha_cpn, c_codigo_emp
                ) NomHojas
                WHERE FECHA BETWEEN @date1 AND @date2 AND IMPORTE > 0
                {codeFilter};";

            DataTable dt = ClsQuerysDB.ExecuteParameterizedQuery(query, parameters);
            var codes = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            if (!dt.Columns.Contains("Codigo")) return codes;

            foreach (DataRow row in dt.Rows)
            {
                string codigo = row["Codigo"]?.ToString()?.Trim() ?? string.Empty;
                if (!string.IsNullOrWhiteSpace(codigo))
                    codes.Add(codigo);
            }

            return codes;
        }

        /// <summary>
        /// Códigos con al menos un registro en nomhojas/nomhojas_temp o en Nom_Attendance_AS
        /// dentro del rango consultado. El resto no entra al reporte, al Excel ni a modificar asistencias.
        /// </summary>
        internal static HashSet<string> CollectEmployeeCodesWithAttendanceRecords(
            DataTable dtAsistencias,
            DataTable dtInasistencias)
        {
            var codes = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            if (dtAsistencias.Columns.Contains("Codigo"))
            {
                foreach (DataRow row in dtAsistencias.Rows)
                {
                    string codigo = row["Codigo"]?.ToString()?.Trim() ?? string.Empty;
                    if (!string.IsNullOrWhiteSpace(codigo))
                        codes.Add(codigo);
                }
            }

            if (dtInasistencias.Columns.Contains("id_employee"))
            {
                foreach (DataRow row in dtInasistencias.Rows)
                {
                    string codigo = row["id_employee"]?.ToString()?.Trim() ?? string.Empty;
                    if (!string.IsNullOrWhiteSpace(codigo))
                        codes.Add(codigo);
                }
            }

            return codes;
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
            string defaultPrefix,
            Action<int, int>? onProgress = null)
        {
            var table = new DataTable();
            table.Columns.Add(ReportColCodigo, typeof(string));
            table.Columns.Add(ReportColNombre, typeof(string));
            table.Columns.Add(ReportColLp, typeof(string));
            table.Columns.Add(ReportColTotal, typeof(int));
            table.Columns.Add(ReportColFaltas, typeof(int));
            table.Columns.Add(ReportColFaltas30, typeof(int));
            foreach (DateTime day in _reportDays)
                table.Columns.Add(BuildDayColumnName(day), typeof(string));

            // Ventana de "últimos 30 días" para ReportColFaltas30: termina en el último día del reporte;
            // si el rango elegido tiene menos de 30 días, la ventana queda acotada a esos mismos días.
            var last30Days = new HashSet<DateTime>(_reportDays.TakeLast(Faltas30Dias));

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

            _commentsByCodeAndDay = dtInasistencias.AsEnumerable()
                .GroupBy(r => (
                    Codigo: r["id_employee"]?.ToString()?.Trim() ?? string.Empty,
                    Fecha: NormalizeDate(r["d_attendance"])))
                .ToDictionary(g => g.Key, g => g.First()["v_comments"]?.ToString()?.Trim() ?? string.Empty);

            employeeCodes = OrderCodesByEmployeeName(employeeCodes, infoByCode);

            int dayCount = Math.Max(1, _reportDays.Count);
            int totalUnits = Math.Max(1, employeeCodes.Count * dayCount);
            int doneUnits = 0;

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
                int totalFaltas = 0;
                int totalFaltas30 = 0;
                foreach (DateTime day in _reportDays)
                {
                    // Por defecto, todo día se marca con el prefijo seleccionado (haya o no dato en las
                    // consultas), excepto domingo, que se deja en blanco salvo que sí haya asistencia.
                    string value = day.DayOfWeek == DayOfWeek.Sunday ? string.Empty : defaultPrefix;

                    if (asistenciaLookup.TryGetValue((codigo, day), out int asistencia) && asistencia == 1)
                        value = ValueAsistencia; // asistencia real: se muestra siempre, incluso en domingo

                    if (inasistenciaLookup.TryGetValue((codigo, day), out string? prefijo) && !string.IsNullOrWhiteSpace(prefijo))
                        value = prefijo; // la inasistencia explícita siempre sobreescribe

                    if (CountsAsAsistencia(value, day.DayOfWeek, _attendanceStylesByPrefix))
                        totalAsistencias++;
                    else
                    {
                        totalFaltas++;
                        if (last30Days.Contains(day)) totalFaltas30++;
                    }

                    newRow[BuildDayColumnName(day)] = value;
                    doneUnits++;
                    onProgress?.Invoke(doneUnits, totalUnits);
                }

                newRow[ReportColTotal] = totalAsistencias;
                newRow[ReportColFaltas] = totalFaltas;
                newRow[ReportColFaltas30] = totalFaltas30;
                table.Rows.Add(newRow);
            }

            return table;
        }

        internal static readonly StringComparer EmployeeNameComparer =
            StringComparer.Create(CultureEs, ignoreCase: true);

        /// <summary>Orden: apellido paterno, apellido materno, nombre, y al final el código.</summary>
        internal static string FormatEmployeeFullName(string? apPat, string? apMat, string? nombre, string fallback)
        {
            string full = string.Join(" ", new[] { apPat?.Trim(), apMat?.Trim(), nombre?.Trim() }
                .Where(s => !string.IsNullOrWhiteSpace(s)));
            return string.IsNullOrWhiteSpace(full) ? fallback : full;
        }

        internal static List<string> OrderCodesByEmployeeName(
            IEnumerable<string> codes,
            Dictionary<string, DataRow> infoByCode)
        {
            return codes
                .OrderBy(c =>
                {
                    if (!infoByCode.TryGetValue(c, out DataRow? row) || row == null)
                        return c;
                    return FormatEmployeeFullName(
                        row["v_lastNamePat"]?.ToString(),
                        row["v_lastNameMat"]?.ToString(),
                        row["v_name"]?.ToString(),
                        c);
                }, EmployeeNameComparer)
                .ThenBy(c => c, StringComparer.OrdinalIgnoreCase)
                .ToList();
        }

        internal static List<(string Code, string FullName, string Lp)> OrderEmployeesByName(
            IEnumerable<(string Code, string FullName, string Lp)> employees)
        {
            return employees
                .OrderBy(e => e.FullName ?? string.Empty, EmployeeNameComparer)
                .ThenBy(e => e.Code ?? string.Empty, StringComparer.OrdinalIgnoreCase)
                .ToList();
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

            bool ownProgress = _progressDepth == 0;
            int from = ownProgress ? 0 : _progressTarget;
            int to = ProgressScale;
            if (ownProgress) BeginProgress();
            try
            {
                _showingReport   = true;
                _showingCalendar = false;

                DataGridView dgv = frm.dgvReport;
                using (DgvAsistenciaASPerf.PausePainting(dgv))
                {
                    dgv.ColumnHeadersVisible = true;
                    dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                    dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                    dgv.ReadOnly = true;
                    dgv.AutoGenerateColumns = true;
                    dgv.DataSource = null;
                    dgv.DataSource = _dtReportPreview;
                    ReportRange(1, 4, from, to);

                    ApplyDayColumnHeaders();
                    ReportRange(2, 4, from, to);

                    // El encabezado de fecha usa 2 líneas (mes-día / día de semana); se necesita más alto
                    // y sin la reserva de espacio de la flecha de "ordenar" para aprovechar más celdas en pantalla.
                    dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

                    int colCount = dgv.Columns.Count;
                    for (int i = 0; i < colCount; i++)
                    {
                        DataGridViewColumn col = dgv.Columns[i];
                        if (TryParseDayColumn(col.Name, out _))
                            col.Width = 44;
                        else
                            dgv.AutoResizeColumn(col.Index, DataGridViewAutoSizeColumnMode.AllCells);

                        ReportRange(i + 1, colCount, LerpRange(from, to, 0.55), to);
                    }
                }

                SetViewButtons(employees: false, report: true, calendar: false);
                AdvanceTo(to);
            }
            finally
            {
                if (ownProgress) EndProgress();
            }
        }

        /// <summary>
        /// Muestra el mismo reporte cargado, pero en formato calendario (un bloque por mes, con los días
        /// acomodados por semana/día de la semana), delegando la construcción de la tabla y el formato a
        /// <see cref="ClsAsistenciaASCalendario"/> para no mezclar ese código con el de esta clase.
        /// </summary>
        private void ShowReportCalendar()
        {
            if (frm == null || _dtReportPreview == null) return;

            bool ownProgress = _progressDepth == 0;
            int from = ownProgress ? 0 : _progressTarget;
            int to = ProgressScale;
            if (ownProgress) BeginProgress();
            try
            {
                // _showingCalendar se activa hasta después de cambiar el DataSource: mientras se reemplaza,
                // el DGV puede seguir disparando eventos de formato/pintado para la tabla anterior (empleados
                // o reporte lineal), que no tiene las columnas del calendario.
                _showingReport   = false;
                _showingCalendar = false;

                int buildFrom = from;
                int buildTo   = LerpRange(from, to, 0.72);
                DataTable dtCalendar = _calendarCls.BuildCalendarTable(
                    _dtReportPreview, _reportDays, _attendanceStylesByPrefix,
                    onProgress: (done, total) => ReportRange(done, total, buildFrom, buildTo));
                AdvanceTo(buildTo);

                using (DgvAsistenciaASPerf.PausePainting(frm.dgvReport))
                {
                    frm.dgvReport.ReadOnly = true;
                    frm.dgvReport.AutoGenerateColumns = true;
                    frm.dgvReport.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                    frm.dgvReport.DataSource = null;
                    frm.dgvReport.DataSource = dtCalendar;
                    ReportRange(1, 2, buildTo, LerpRange(from, to, 0.80));

                    _showingCalendar = true;
                    int formatFrom = LerpRange(from, to, 0.80);
                    _calendarCls.ApplyHeadersAndFormatting(
                        frm.dgvReport,
                        onProgress: (done, total) => ReportRange(done, total, formatFrom, to));
                }

                SetViewButtons(employees: false, report: false, calendar: true);
                AdvanceTo(to);
            }
            finally
            {
                if (ownProgress) EndProgress();
            }
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

        private void ShowEmployeeList(bool showProgress = true)
        {
            if (frm == null) return;

            bool ownProgress = showProgress && _progressDepth == 0;
            int from = ownProgress ? 0 : _progressTarget;
            int to = ProgressScale;
            if (ownProgress) BeginProgress();
            try
            {
                _showingReport   = false;
                _showingCalendar = false;

                DataGridView dgv = frm.dgvReport;
                using (DgvAsistenciaASPerf.PausePainting(dgv))
                {
                    dgv.ColumnHeadersVisible = true;
                    dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                    dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                    dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                    dgv.ReadOnly = false;
                    dgv.AutoGenerateColumns = true;
                    dgv.DataSource = null;
                    dgv.DataSource = _dtEmployeeList;
                    ReportRange(1, 4, from, to);
                    ApplyCheckBoxColumnToSel();
                    HideColumnsInDgv(_columnsToHideInDgv);
                    ReportRange(2, 4, from, to);

                    int colCount = dgv.Columns.Count;
                    for (int i = 0; i < colCount; i++)
                    {
                        if (dgv.Columns[i].Visible)
                            dgv.AutoResizeColumn(i, DataGridViewAutoSizeColumnMode.DisplayedCells);
                        ReportRange(i + 1, Math.Max(1, colCount), LerpRange(from, to, 0.50), to);
                    }

                    if (dgv.Columns.Contains(ColSel))
                        dgv.Columns[ColSel].Width = 36;
                }

                SyncHeaderSelFromRows();

                SetViewButtons(employees: true, report: false, calendar: false);
                AdvanceTo(to);
            }
            finally
            {
                if (ownProgress) EndProgress();
            }
        }

        private void SetViewButtons(bool employees, bool report, bool calendar)
        {
            if (frm == null) return;

            _updatingViewButtons = true;
            try
            {
                frm.chbShowEmployees.Checked = employees;
                frm.chbShowReport.Checked = report;
                frm.chbShowReportCalendar.Checked = calendar;
            }
            finally
            {
                _updatingViewButtons = false;
            }
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
        /// Convierte la columna "Sel." en una columna de checkboxes en el DGV,
        /// con un checkbox en el encabezado para seleccionar o deseleccionar todos.
        /// </summary>
        private void ApplyCheckBoxColumnToSel()
        {
            if (frm == null) return;
            if (!frm.dgvReport.Columns.Contains(ColSel)) return;

            var col = frm.dgvReport.Columns[ColSel];
            if (col is DataGridViewCheckBoxColumn existing)
            {
                ConfigureSelCheckBoxColumn(existing);
                return;
            }

            int ordinal = col.Index;
            frm.dgvReport.Columns.Remove(col);

            var chkCol = new DataGridViewCheckBoxColumn
            {
                Name             = ColSel,
                DataPropertyName = ColSel,
                TrueValue        = "1",
                FalseValue       = "0",
                Width            = 36,
                DisplayIndex     = ordinal,
            };
            ConfigureSelCheckBoxColumn(chkCol);
            frm.dgvReport.Columns.Insert(ordinal, chkCol);
        }

        private static void ConfigureSelCheckBoxColumn(DataGridViewCheckBoxColumn chkCol)
        {
            chkCol.HeaderText = string.Empty;
            chkCol.SortMode = DataGridViewColumnSortMode.NotSortable;
            chkCol.Width = 36;
            chkCol.Resizable = DataGridViewTriState.False;
            chkCol.ToolTipText = "Seleccionar / deseleccionar todos";
            chkCol.HeaderCell.ToolTipText = "Seleccionar / deseleccionar todos";
        }

        private void PaintSelHeaderCheckBox(DataGridViewCellPaintingEventArgs e)
        {
            if (frm == null || e.RowIndex != -1 || e.ColumnIndex < 0) return;
            if (e.ColumnIndex >= frm.dgvReport.Columns.Count) return;
            if (frm.dgvReport.Columns[e.ColumnIndex].Name != ColSel) return;

            e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border);

            CheckBoxState state = _headerSelChecked
                ? CheckBoxState.CheckedNormal
                : CheckBoxState.UncheckedNormal;
            System.Drawing.Size glyph = CheckBoxRenderer.GetGlyphSize(e.Graphics, state);
            var location = new Point(
                e.CellBounds.X + Math.Max(0, (e.CellBounds.Width - glyph.Width) / 2),
                e.CellBounds.Y + Math.Max(0, (e.CellBounds.Height - glyph.Height) / 2));
            CheckBoxRenderer.DrawCheckBox(e.Graphics, location, state);
            e.Handled = true;
        }

        public void DgvReport_ColumnHeaderMouseClick(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (frm == null || _showingReport || _showingCalendar) return;
            if (e.ColumnIndex < 0 || e.ColumnIndex >= frm.dgvReport.Columns.Count) return;
            if (frm.dgvReport.Columns[e.ColumnIndex].Name != ColSel) return;

            SetAllEmployeeSelection(!_headerSelChecked);
        }

        public void DgvReport_CurrentCellDirtyStateChanged(object? sender, EventArgs e)
        {
            if (frm == null || _showingReport || _showingCalendar) return;
            if (!frm.dgvReport.IsCurrentCellDirty) return;
            if (frm.dgvReport.CurrentCell?.OwningColumn?.Name != ColSel) return;

            frm.dgvReport.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        public void DgvReport_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            if (_updatingSel || frm == null || _showingReport || _showingCalendar) return;
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (frm.dgvReport.Columns[e.ColumnIndex].Name != ColSel) return;

            SyncHeaderSelFromRows();
        }

        private void SetAllEmployeeSelection(bool selected)
        {
            if (frm == null || !_dtEmployeeList.Columns.Contains(ColSel)) return;

            DataGridView dgv = frm.dgvReport;
            _updatingSel = true;
            try
            {
                // La celda actual queda en modo edición y no refleja el cambio hasta que se sale de la fila.
                int? currentRow = dgv.CurrentCell?.RowIndex;
                int? currentCol = dgv.CurrentCell?.ColumnIndex;
                if (dgv.IsCurrentCellInEditMode)
                    dgv.CancelEdit();
                dgv.EndEdit();
                dgv.CurrentCell = null;

                string value = selected ? "1" : "0";
                foreach (DataRow row in _dtEmployeeList.Rows)
                    row[ColSel] = value;

                _headerSelChecked = selected;

                if (currentRow is >= 0 && currentCol is >= 0
                    && currentRow.Value < dgv.Rows.Count
                    && currentCol.Value < dgv.Columns.Count)
                {
                    dgv.CurrentCell = dgv.Rows[currentRow.Value].Cells[currentCol.Value];
                    dgv.RefreshEdit();
                }

                if (dgv.Columns.Contains(ColSel))
                    dgv.InvalidateColumn(dgv.Columns[ColSel].Index);
                dgv.Refresh();
            }
            finally
            {
                _updatingSel = false;
            }
        }

        private void SyncHeaderSelFromRows()
        {
            if (frm == null || !_dtEmployeeList.Columns.Contains(ColSel)) return;

            bool allChecked = _dtEmployeeList.Rows.Count > 0
                && _dtEmployeeList.AsEnumerable().All(r => r[ColSel]?.ToString() == "1");

            if (_headerSelChecked == allChecked) return;
            _headerSelChecked = allChecked;
            if (frm.dgvReport.Columns.Contains(ColSel))
                frm.dgvReport.InvalidateColumn(frm.dgvReport.Columns[ColSel].Index);
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
        private int AddRowsToEmployeeList(DataTable source, int rangeFrom = 0, int rangeTo = 0)
        {
            foreach (DataColumn col in source.Columns)
            {
                if (!_dtEmployeeList.Columns.Contains(col.ColumnName))
                    _dtEmployeeList.Columns.Add(col.ColumnName, col.DataType);
            }

            bool reportProgress = rangeTo > rangeFrom;
            int count = 0;
            int processed = 0;
            int total = Math.Max(1, source.Rows.Count);
            foreach (DataRow srcRow in source.Rows)
            {
                string codigo = srcRow.Table.Columns.Contains(ColCodigo)
                    ? srcRow[ColCodigo]?.ToString()?.Trim() ?? string.Empty
                    : string.Empty;

                DataRow? existing = string.IsNullOrWhiteSpace(codigo) ? null : FindEmployeeInList(codigo);
                if (existing != null)
                {
                    existing[ColSel] = "1";
                    processed++;
                    if (reportProgress) ReportRange(processed, total, rangeFrom, rangeTo);
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
                processed++;
                if (reportProgress) ReportRange(processed, total, rangeFrom, rangeTo);
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

        // ── ProgressBar pgrReport ─────────────────────────────────────────────

        private const int ProgressScale = 1000;
        private const int ProgressPaintMs = 20;
        private int _progressTarget;
        private int _lastPaintTick;

        private bool HasProgressBar => frm?.pgrReport != null;

        private void BeginProgress()
        {
            if (frm == null) return;
            _progressDepth++;
            if (_progressDepth > 1) return;

            frm.SetWaitCursor(true);
            frm.SetOperationBusy(true);
            if (!HasProgressBar) return;

            ProgressBar p = frm.pgrReport;
            p.Style = ProgressBarStyle.Continuous;
            p.Minimum = 0;
            if (p.Value > ProgressScale)
                p.Value = 0;
            p.Maximum = ProgressScale;
            p.Value = 0;
            _progressTarget = 0;
            _lastPaintTick = 0;
            p.Update();
        }

        /// <summary>Punto intermedio entre <paramref name="from"/> y <paramref name="to"/> (t de 0 a 1).</summary>
        private static int LerpRange(int from, int to, double t)
            => from + (int)Math.Round((to - from) * t);

        private void ReportRange(int done, int total, int from, int to)
        {
            if (total <= 0)
            {
                AdvanceTo(to);
                return;
            }

            int v = from + (int)((long)Math.Min(done, total) * (to - from) / total);
            AdvanceTo(v);
        }

        /// <summary>
        /// Mueve la barra hacia <paramref name="permille"/> (0–1000). Los saltos grandes se interpolan
        /// en varios frames; los avances chicos se pintan como máximo cada <see cref="ProgressPaintMs"/> ms.
        /// </summary>
        private void AdvanceTo(int permille)
        {
            if (!HasProgressBar) return;

            permille = Math.Clamp(permille, 0, ProgressScale);
            if (permille < _progressTarget)
                permille = _progressTarget;
            _progressTarget = permille;

            ProgressBar p = frm!.pgrReport;
            EnsureBarScale();

            int shown = p.Value;
            int gap = permille - shown;
            if (gap <= 0) return;

            int now = Environment.TickCount;
            bool force = permille >= ProgressScale;
            bool largeJump = gap >= 30;
            if (!force && !largeJump && _lastPaintTick != 0 && now - _lastPaintTick < ProgressPaintMs)
                return;

            if (largeJump)
            {
                int frames = Math.Clamp(gap / 12, 8, 18);
                for (int i = 1; i <= frames; i++)
                {
                    ApplyBarValue(shown + gap * i / frames);
                    p.Update();
                    Application.DoEvents();
                    if (i < frames)
                        System.Threading.Thread.Sleep(8);
                }
            }
            else
            {
                ApplyBarValue(permille);
                p.Update();
                Application.DoEvents();
            }

            _lastPaintTick = Environment.TickCount;
        }

        private void EnsureBarScale()
        {
            ProgressBar p = frm!.pgrReport;
            if (p.Style != ProgressBarStyle.Continuous)
                p.Style = ProgressBarStyle.Continuous;
            if (p.Minimum != 0)
                p.Minimum = 0;
            if (p.Maximum != ProgressScale)
            {
                if (p.Value > ProgressScale)
                    p.Value = ProgressScale;
                p.Maximum = ProgressScale;
            }
        }

        private void ApplyBarValue(int value)
        {
            EnsureBarScale();
            ProgressBar p = frm!.pgrReport;
            int max = p.Maximum;
            int v = Math.Clamp(value, 0, max);

            if (v >= max)
            {
                // WinForms no pinta el tope hasta rebasar Maximum; se sube uno y se deja Value en max
                // sin quedar Maximum alterado por si Application.DoEvents reentra.
                p.Maximum = max + 1;
                p.Value = max + 1;
                p.Value = max;
                p.Maximum = max;
                if (p.Value > max)
                    p.Value = max;
                return;
            }

            p.Value = v + 1;
            p.Value = v;
        }

        private void EndProgress()
        {
            if (_progressDepth <= 0)
            {
                RestoreIdleUi();
                return;
            }

            _progressDepth--;
            if (_progressDepth > 0) return;

            try
            {
                if (HasProgressBar)
                {
                    AdvanceTo(ProgressScale);
                    ProgressBar p = frm!.pgrReport;
                    p.Update();
                    p.Value = 0;
                    _progressTarget = 0;
                }
            }
            finally
            {
                RestoreIdleUi();
            }
        }

        private void RestoreIdleUi()
        {
            if (frm == null) return;
            frm.SetOperationBusy(false);
            frm.SetWaitCursor(false);
        }
    }

    /// <summary>
    /// Ajustes de rendimiento del <see cref="DataGridView"/> del reporte: doble búfer, pausa de pintado
    /// al cambiar de vista y caché de fuentes para no crear un <see cref="Font"/> por cada celda.
    /// </summary>
    internal static class DgvAsistenciaASPerf
    {
        private const int WmSetRedraw = 0x000B;

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        private static Font? _baseFont;
        private static readonly Dictionary<FontStyle, Font> FontsByStyle = new();

        public static void EnableDoubleBuffer(DataGridView dgv)
        {
            typeof(DataGridView).InvokeMember(
                "DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.SetProperty,
                binder: null,
                target: dgv,
                args: new object[] { true });
        }

        public static void PrepareForFastScroll(DataGridView dgv)
        {
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgv.RowTemplate.Height = 22;
        }

        public static IDisposable PausePainting(DataGridView dgv) => new PauseScope(dgv);

        public static Font GetStyledFont(Font baseFont, FontStyle style)
        {
            if (_baseFont == null
                || !string.Equals(_baseFont.FontFamily.Name, baseFont.FontFamily.Name, StringComparison.Ordinal)
                || Math.Abs(_baseFont.Size - baseFont.Size) > 0.01f)
            {
                foreach (Font font in FontsByStyle.Values)
                    font.Dispose();
                FontsByStyle.Clear();
                _baseFont = baseFont;
            }

            if (!FontsByStyle.TryGetValue(style, out Font? cached))
            {
                cached = new Font(baseFont, style);
                FontsByStyle[style] = cached;
            }
            return cached;
        }

        private sealed class PauseScope : IDisposable
        {
            private readonly DataGridView _dgv;

            public PauseScope(DataGridView dgv)
            {
                _dgv = dgv;
                _dgv.SuspendLayout();
                if (_dgv.IsHandleCreated)
                    SendMessage(_dgv.Handle, WmSetRedraw, IntPtr.Zero, IntPtr.Zero);
            }

            public void Dispose()
            {
                if (_dgv.IsHandleCreated)
                    SendMessage(_dgv.Handle, WmSetRedraw, new IntPtr(1), IntPtr.Zero);
                _dgv.ResumeLayout();
                _dgv.Invalidate();
            }
        }
    }
}
