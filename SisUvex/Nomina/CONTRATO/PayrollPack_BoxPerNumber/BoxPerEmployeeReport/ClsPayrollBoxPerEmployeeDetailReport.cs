using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Extentions;
using SisUvex.Catalogos.Metods.Querys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;
using static SisUvex.Catalogos.Metods.ClsObject;
using Color = System.Drawing.Color;

namespace SisUvex.Nomina.CONTRATO.PayrollPack_BoxPerNumber.BoxPerEmployeeReport
{
    internal class ClsPayrollBoxPerEmployeeDetailReport
    {
        public FrmPayrollBoxPerEmployeeDetailReport? frm = null;

        // ── Columnas de vw_Nom_EmployeeWorkGroupPair ──────────────────────────
        private const string ColSel        = "Sel.";
        private const string ColCodigo     = "CODIGO";
        private const string ColNombre     = "NOMBRE";
        private const string ColIdSeason   = "idSeason";
        private const string ColIdWorkGroup  = "idWorkGroup";
        private const string ColIdContractor = "idContractor";

        // ── Columnas de vw_PayrollPack_BoxPerNumberReport ─────────────────────
        internal static class ReportColumns
        {
            public const string Fecha      = "FECHA";
            public const string IdPrice    = "idPrice";
            public const string Empaque    = "EMPAQUE";
            public const string Codigo     = "CODIGO";
            public const string Nombre     = "NOMBRE";
            public const string Lp         = "LP";
            public const string Cuadrilla  = "CUADRILLA";
            public const string Contratista = "CONTRATISTA";
            public const string Cajas      = "CAJAS";
            public const string IdWorkGroup  = "idWorkGroup";
            public const string IdContractor = "idContractor";
            public const string IdSeason     = "idSeason";
        }

        // ── Columnas ocultas en el DGV del listado ────────────────────────────
        private readonly List<string> _columnsToHideInDgv = new()
        {
            "ORDEN_NUM",
            "idWorkGroup",
            "idContractor",
            "idUser",
            "idSeason",
        };

        // ── Estado interno ────────────────────────────────────────────────────
        /// <summary>Tabla maestra del listado de empleados (con columna "Sel." checkbox).</summary>
        private DataTable _dtEmployeeList = BuildEmptyEmployeeListTable();
        /// <summary>Tabla del reporte pivot cargado por btnLoadReport.</summary>
        private DataTable? _dtReportPreview;

        private bool _showingReport = false;

        // ── Inicio del formulario ─────────────────────────────────────────────

        public void BeginFormCat()
        {
            if (frm == null) return;

            frm.WindowState = FormWindowState.Maximized;
            SetControls();
            frm.lblEmployeeAdvice.Text = string.Empty;
            ShowEmployeeList();
        }

        private void SetControls()
        {
            if (frm == null) return;

            ClsComboBoxes.CboLoadActives(frm.cboSeason, Season.CboWithDates);
            ClsComboBoxes.CboLoadActives(frm.cboContractor, Contractor.Cbo);
            ClsComboBoxes.CboLoadActives(frm.cboWorkGroup, WorkGroup.Cbo);

            var workGroupFilters = new List<(ComboBox, string)>
            {
                (frm.cboContractor, Contractor.ColumnId),
                (frm.cboSeason, Season.ColumnId),
            };
            ClsComboBoxes.Events.CboApplyEventFilterAllForOne(frm.cboWorkGroup, null, workGroupFilters);

            frm.cboSeason.SelectedIndexChanged += CboSeason_SelectedIndexChanged;
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(frm.cboSeason, "08");
        }

        // ── Evento temporada → fechas ─────────────────────────────────────────

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

            // Sólo busca el primer código ingresado
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

                string nombre = dt.Rows[0]["NOMBRE"]?.ToString()?.Trim() ?? string.Empty;
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
        /// Parsea el texto del RichTextBox y devuelve códigos de empleado únicos y no vacíos.
        /// Compatible con copia de celdas de Excel (separadas por saltos de línea o tabuladores).
        /// </summary>
        private static IEnumerable<string> ParseEmployeeCodes(string input)
        {
            return input
                .Split(new[] { '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Trim())
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Distinct(StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Busca un empleado por código priorizando la temporada seleccionada en cboSeason.
        /// Si no hay resultados con esa temporada, consulta sin filtro de temporada.
        /// </summary>
        private DataTable FetchEmployeeByCode(string codigo)
        {
            string? selectedSeason = frm?.cboSeason.ComboValueOrNull();

            // Intento 1: con filtro de temporada (si hay una seleccionada)
            if (!string.IsNullOrWhiteSpace(selectedSeason))
            {
                var pSeason = new Dictionary<string, object>
                {
                    ["@codigo"]   = codigo,
                    ["@idSeason"] = selectedSeason,
                };
                DataTable dtSeason = ClsQuerysDB.ExecuteParameterizedQuery(
                    $"SELECT '1' AS [{ColSel}], * FROM dbo.vw_Nom_EmployeeWorkGroupPair " +
                    $"WHERE CODIGO = @codigo AND [{ColIdSeason}] = @idSeason " +
                    $"ORDER BY CUADRILLA, NUMERO, ORDEN_NUM;",
                    pSeason);

                if (dtSeason.Rows.Count > 0)
                    return dtSeason;
            }

            // Intento 2 (fallback): sin filtro de temporada
            var pAll = new Dictionary<string, object> { ["@codigo"] = codigo };
            return ClsQuerysDB.ExecuteParameterizedQuery(
                $"SELECT '1' AS [{ColSel}], * FROM dbo.vw_Nom_EmployeeWorkGroupPair " +
                $"WHERE CODIGO = @codigo ORDER BY CUADRILLA, NUMERO, ORDEN_NUM;",
                pAll);
        }

        // ── Agregar listado por filtros ────────────────────────────────────────

        public void BtnAddList()
        {
            if (frm == null) return;

            try
            {
                var parameters = new Dictionary<string, object>();
                var sb = new StringBuilder();
                sb.AppendLine($"SELECT '1' AS [{ColSel}], * FROM dbo.vw_Nom_EmployeeWorkGroupPair WHERE 1 = 1");

                AppendFilterIfSelected(sb, parameters, "@idSeason",   ColIdSeason,    frm.cboSeason.ComboValueOrNull());
                AppendFilterIfSelected(sb, parameters, "@idContractor", ColIdContractor, frm.cboContractor.ComboValueOrNull());
                AppendFilterIfSelected(sb, parameters, "@idWorkGroup", ColIdWorkGroup, frm.cboWorkGroup.ComboValueOrNull());

                sb.AppendLine("ORDER BY CUADRILLA, NUMERO, ORDEN_NUM, CODIGO;");

                DataTable dt = ClsQuerysDB.ExecuteParameterizedQuery(sb.ToString(), parameters);

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

        // ── Limpiar listado ───────────────────────────────────────────────────

        public void BtnClearList()
        {
            _dtEmployeeList = BuildEmptyEmployeeListTable();
            _dtReportPreview = null;
            RefreshEmployeeDgv();
            ShowEmployeeList();
            if (frm != null) frm.lblEmployeeAdvice.Text = string.Empty;
        }

        // ── Cargar reporte ────────────────────────────────────────────────────

        public void BtnLoadReport()
        {
            if (frm == null) return;

            if (frm.dtpDate2.Value.Date < frm.dtpDate1.Value.Date)
            {
                MessageBox.Show("La fecha final no puede ser menor a la fecha inicial.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataTable rawData = FetchReportData();
                if (rawData.Rows.Count == 0)
                {
                    SystemSounds.Exclamation.Play();
                    SetAdvice("No se encontraron datos para el reporte.", isError: true);
                    return;
                }

                _dtReportPreview = BuildReportPreview(rawData,
                    frm.dtpDate1.Value.Date, frm.dtpDate2.Value.Date);

                ShowReport();
                SetAdvice(string.Empty, isError: false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error al cargar reporte", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Generar Excel ─────────────────────────────────────────────────────

        public void BtnGenerateExcelReport()
        {
            if (frm == null) return;

            DataTable rawData;
            try
            {
                rawData = FetchReportData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error al consultar datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (rawData.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para generar el reporte (usa Cargar reporte antes).",
                    "Reporte detalle empleado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Empleados marcados (Sel.=1) para la hoja LISTADO EMP.
            DataTable dtSelectedEmployees = GetSelectedEmployeeRows();

            string dateRange = $"{frm.dtpDate1.Value:dd/MM/yyyy} al {frm.dtpDate2.Value:dd/MM/yyyy}";

            var excel = new ClsExcelReportDetalleEmpleado();
            excel.GenerateExcelReport(
                rawData,
                dtSelectedEmployees,
                frm.dtpDate1.Value.Date,
                frm.dtpDate2.Value.Date,
                dateRange);
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

        // ── Helpers DGV ──────────────────────────────────────────────────────

        private void ShowEmployeeList()
        {
            if (frm == null) return;

            _showingReport = false;

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
        /// Se ignoran nombres de columna que no existan. Solo aplica al listado (no al reporte).
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

        private void ShowReport()
        {
            if (frm == null || _dtReportPreview == null) return;

            _showingReport = true;

            frm.dgvReport.ReadOnly = true;
            frm.dgvReport.AutoGenerateColumns = true;
            frm.dgvReport.DataSource = null;
            frm.dgvReport.DataSource = _dtReportPreview;

            frm.chbShowReport.Checked = true;
            frm.chbShowEmployees.Checked = false;
        }

        private void RefreshEmployeeDgv()
        {
            if (frm == null || _showingReport) return;
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
            // Asegurar que el esquema del listado esté completo
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

        // ── Consulta del reporte ──────────────────────────────────────────────

        private DataTable FetchReportData()
        {
            if (frm == null) return new DataTable();

            var parameters = new Dictionary<string, object>
            {
                ["@date1"] = frm.dtpDate1.Value.Date,
                ["@date2"] = frm.dtpDate2.Value.Date,
            };

            var sb = new StringBuilder();
            sb.AppendLine("SELECT *");
            sb.AppendLine("FROM dbo.vw_PayrollPack_BoxPerNumberReport");
            sb.AppendLine("WHERE 1 = 1");
            sb.AppendLine($"  AND CAST([{ReportColumns.Fecha}] AS date) BETWEEN @date1 AND @date2");

            // Filtro por empleados del listado (los marcados; si ninguno, todos)
            List<string> selectedCodigos = GetSelectedCodigos();
            if (selectedCodigos.Count > 0)
            {
                sb.Append($"  AND [{ReportColumns.Codigo}] IN (");
                for (int i = 0; i < selectedCodigos.Count; i++)
                {
                    string pname = $"@emp{i}";
                    if (i > 0) sb.Append(", ");
                    sb.Append(pname);
                    parameters[pname] = selectedCodigos[i];
                }
                sb.AppendLine(")");
            }

            sb.AppendLine($"ORDER BY [{ReportColumns.Codigo}], [{ReportColumns.Fecha}], [{ReportColumns.Cuadrilla}], [{ReportColumns.Empaque}];");

            return ClsQuerysDB.ExecuteParameterizedQuery(sb.ToString(), parameters);
        }

        private List<string> GetSelectedCodigos()
        {
            if (!_dtEmployeeList.Columns.Contains(ColSel) ||
                !_dtEmployeeList.Columns.Contains(ColCodigo))
                return new List<string>();

            return _dtEmployeeList.AsEnumerable()
                .Where(r => r[ColSel]?.ToString() == "1")
                .Select(r => r[ColCodigo]?.ToString()?.Trim() ?? string.Empty)
                .Where(c => !string.IsNullOrWhiteSpace(c))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();
        }

        // ── Vista previa del reporte para el DGV ─────────────────────────────

        private static DataTable BuildReportPreview(DataTable rawData, DateTime rangeStart, DateTime rangeEnd)
        {
            var preview = new DataTable();
            preview.Columns.Add("CODIGO / NOMBRE / LP", typeof(string));
            preview.Columns.Add("FECHA",    typeof(string));
            preview.Columns.Add("CUADRILLA", typeof(string));

            // Columnas dinámicas de empaque
            var empaques = rawData.AsEnumerable()
                .Select(r => r[ReportColumns.Empaque]?.ToString()?.Trim() ?? string.Empty)
                .Where(e => !string.IsNullOrWhiteSpace(e))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .OrderBy(e => e, StringComparer.OrdinalIgnoreCase)
                .ToList();

            foreach (string emp in empaques)
                preview.Columns.Add(emp, typeof(string));

            preview.Columns.Add("TOTAL", typeof(string));

            // Agrupar por empleado
            var byEmployee = rawData.AsEnumerable()
                .GroupBy(r => r[ReportColumns.Codigo]?.ToString()?.Trim() ?? string.Empty)
                .OrderBy(g => g.Key, StringComparer.OrdinalIgnoreCase);

            foreach (var empGroup in byEmployee)
            {
                string codigo  = empGroup.Key;
                string nombre  = empGroup.First()[ReportColumns.Nombre]?.ToString()?.Trim() ?? string.Empty;
                string lp      = empGroup.First()[ReportColumns.Lp]?.ToString()?.Trim() ?? string.Empty;

                // Fila de título del empleado
                DataRow titleRow = preview.NewRow();
                titleRow["CODIGO / NOMBRE / LP"] = $"{codigo} – {nombre} – LP: {lp}";
                preview.Rows.Add(titleRow);

                // Agrupar celdas por (Fecha, Cuadrilla, Empaque)
                var cellData = empGroup
                    .GroupBy(r => (
                        Fecha:     NormalizeDate(r[ReportColumns.Fecha]),
                        Cuadrilla: r[ReportColumns.Cuadrilla]?.ToString()?.Trim() ?? string.Empty,
                        Empaque:   r[ReportColumns.Empaque]?.ToString()?.Trim() ?? string.Empty))
                    .ToDictionary(g => g.Key, g => g.Sum(r =>
                        r[ReportColumns.Cajas] == DBNull.Value ? 0m : Convert.ToDecimal(r[ReportColumns.Cajas])));

                var rowKeys = cellData.Keys
                    .Select(k => (k.Fecha, k.Cuadrilla))
                    .Distinct()
                    .OrderBy(k => k.Fecha)
                    .ThenBy(k => k.Cuadrilla, StringComparer.OrdinalIgnoreCase)
                    .ToList();

                // Agregar todos los días del rango, incluso sin datos
                var allDays = ClsPayrollBoxPerEmployeeReportExcel.EachDayInclusive(rangeStart, rangeEnd)
                    .SelectMany(day =>
                    {
                        var cuadrillas = rowKeys.Where(k => k.Fecha == day).Select(k => k.Cuadrilla).Distinct().ToList();
                        return cuadrillas.Count > 0
                            ? cuadrillas.Select(c => (Fecha: day, Cuadrilla: c))
                            : new List<(DateTime, string)> { (day, string.Empty) };
                    })
                    .ToList();

                decimal[] empColTotals = new decimal[empaques.Count];

                foreach (var (fecha, cuadrilla) in allDays)
                {
                    DataRow dataRow = preview.NewRow();
                    dataRow["FECHA"]     = fecha.ToString("dd-MMM", ClsPayrollBoxPerEmployeeReportExcel.CultureEs);
                    dataRow["CUADRILLA"] = cuadrilla;

                    decimal rowTotal = 0m;
                    for (int i = 0; i < empaques.Count; i++)
                    {
                        var k = (Fecha: fecha, Cuadrilla: cuadrilla, Empaque: empaques[i]);
                        decimal val = cellData.TryGetValue(k, out decimal v) ? v : 0m;
                        dataRow[empaques[i]] = val == 0m ? string.Empty : val.ToString("0.##", ClsPayrollBoxPerEmployeeReportExcel.CultureEs);
                        rowTotal += val;
                        empColTotals[i] += val;
                    }

                    dataRow["TOTAL"] = rowTotal == 0m ? string.Empty : rowTotal.ToString("0.##", ClsPayrollBoxPerEmployeeReportExcel.CultureEs);
                    preview.Rows.Add(dataRow);
                }

                // Fila de totales del empleado
                DataRow totalRow = preview.NewRow();
                totalRow["FECHA"] = "TOTAL";
                decimal grand = 0m;
                for (int i = 0; i < empaques.Count; i++)
                {
                    totalRow[empaques[i]] = empColTotals[i] == 0m ? string.Empty
                        : empColTotals[i].ToString("0.##", ClsPayrollBoxPerEmployeeReportExcel.CultureEs);
                    grand += empColTotals[i];
                }
                totalRow["TOTAL"] = grand.ToString("0.##", ClsPayrollBoxPerEmployeeReportExcel.CultureEs);
                preview.Rows.Add(totalRow);

                preview.Rows.Add(preview.NewRow());
            }

            return preview;
        }

        // ── Utilidades ────────────────────────────────────────────────────────

        private static DateTime NormalizeDate(object? value)
        {
            if (value == null || value == DBNull.Value) return DateTime.MinValue;
            if (value is DateTime dt) return dt.Date;
            return DateTime.Parse(value.ToString()!, System.Globalization.CultureInfo.InvariantCulture).Date;
        }

        private static void AppendFilterIfSelected(
            StringBuilder sb,
            Dictionary<string, object> parameters,
            string paramName, string colName, string? value)
        {
            if (string.IsNullOrWhiteSpace(value)) return;
            sb.AppendLine($"AND [{colName}] = {paramName}");
            parameters[paramName] = value.Trim();
        }

        private void SetAdvice(string text, bool isError)
        {
            if (frm == null) return;
            frm.lblEmployeeAdvice.Text      = text;
            frm.lblEmployeeAdvice.ForeColor = isError ? Color.Red : Color.Gray;
        }
    }
}
