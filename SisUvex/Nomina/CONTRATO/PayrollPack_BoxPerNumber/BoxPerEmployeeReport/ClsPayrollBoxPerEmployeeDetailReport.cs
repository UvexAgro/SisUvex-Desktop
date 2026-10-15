using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Extentions;
using SisUvex.Catalogos.Metods.Querys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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

        // ── Colores del reporte ───────────────────────────────────────────────
        private static readonly Color ColorTitle      = Color.FromArgb(0xD9, 0xE1, 0xF2); // azul claro
        private static readonly Color ColorTotal      = Color.FromArgb(0xFF, 0xC0, 0x00); // amarillo
        private static readonly Color ColorEmptyDay   = Color.FromArgb(0xFF, 0xC7, 0xCE); // rosa
        private static readonly Color ColorValue      = Color.FromArgb(0xC5, 0xDF, 0xB4); // verde claro
        private static readonly Color ColorSeparator  = SystemColors.Control;

        private static readonly HashSet<string> FixedReportCols = new(StringComparer.OrdinalIgnoreCase)
        {
            "CODIGO / NOMBRE / LP", "FECHA", "CUADRILLA", "CONTRATISTA", "TOTAL",
        };

        private enum RowKind { Title, Total, EmptyDay, Data, Separator }
        private List<RowKind> _rowKinds = new();
        private Font? _boldFont;

        // ── Estado interno ────────────────────────────────────────────────────
        /// <summary>Tabla maestra del listado de empleados (con columna "Sel." checkbox).</summary>
        private DataTable _dtEmployeeList = BuildEmptyEmployeeListTable();
        /// <summary>Tabla del reporte pivot (Reporte Detalle) cargado por btnLoadReport.</summary>
        private DataTable? _dtReportPreview;
        /// <summary>Datos crudos de la última consulta (para generar tabs RESUMEN y Cajas empleado).</summary>
        private DataTable? _dtRawData;

        // Índice de la fila "TOTAL GENERAL" en los DGVs de resumen (–1 = no cargado)
        private int _resumeTotalRowIndex    = -1;
        private int _cajasEmpTotalRowIndex  = -1;

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

            frm.pgrReport.Visible = true;
            Application.DoEvents();

            try
            {
                DataTable rawData = FetchReportData();
                if (rawData.Rows.Count == 0)
                {
                    SystemSounds.Exclamation.Play();
                    SetAdvice("No se encontraron datos para el reporte.", isError: true);
                    return;
                }

                _dtRawData       = rawData;
                _dtReportPreview = BuildReportPreview(rawData,
                    frm.dtpDate1.Value.Date, frm.dtpDate2.Value.Date);

                // Invalidar caches de tabs de resumen
                _resumeTotalRowIndex   = -1;
                _cajasEmpTotalRowIndex = -1;

                // Cambiar al tab Reporte Detalle y cargarlo
                frm.tabReport.SelectedIndex = 1;
                ShowDetalle();
                SetAdvice(string.Empty, isError: false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error al cargar reporte", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                frm.pgrReport.Visible = false;
            }
        }

        // ── Generar Excel ─────────────────────────────────────────────────────

        public void BtnGenerateExcelReport()
        {
            if (frm == null) return;

            DataTable rawData;
            if (_dtRawData != null && _dtRawData.Rows.Count > 0)
            {
                rawData = _dtRawData;
            }
            else
            {
                try { rawData = FetchReportData(); }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error al consultar datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
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

        // ── Cambio de tab ─────────────────────────────────────────────────────

        public void TabReport_SelectedIndexChanged()
        {
            if (frm == null) return;
            switch (frm.tabReport.SelectedIndex)
            {
                case 0: ShowEmployeeList();   break;
                case 1: ShowDetalle();        break;
                case 2: ShowResumen();        break;
                case 3: ShowCajasEmpleado();  break;
            }
        }

        // ── Helpers DGV ──────────────────────────────────────────────────────

        private void ShowEmployeeList()
        {
            if (frm == null) return;

            frm.dgvListado.ReadOnly           = false;
            frm.dgvListado.AutoGenerateColumns = true;
            frm.dgvListado.DataSource         = null;
            frm.dgvListado.DataSource         = _dtEmployeeList;
            ApplyCheckBoxColumnToSel();
            HideColumnsInDgv(_columnsToHideInDgv);
        }

        private void HideColumnsInDgv(IEnumerable<string> columnsToHide)
        {
            if (frm == null) return;
            foreach (string col in columnsToHide)
                if (frm.dgvListado.Columns.Contains(col))
                    frm.dgvListado.Columns[col].Visible = false;
        }

        private void ShowDetalle()
        {
            if (frm == null) return;
            if (_dtReportPreview == null || _dtReportPreview.Rows.Count == 0)
            {
                SystemSounds.Exclamation.Play();
                frm.tabReport.SelectedIndex = 0;
                SetAdvice("No hay reporte cargado. Usa \"Cargar reporte\" primero.", isError: true);
                return;
            }

            ClassifyReportRows();
            frm.dgvDetalle.AutoGenerateColumns = true;
            frm.dgvDetalle.DataSource          = null;
            frm.dgvDetalle.DataSource          = _dtReportPreview;
        }

        private void ShowResumen()
        {
            if (frm == null) return;
            if (_dtRawData == null || _dtRawData.Rows.Count == 0)
            {
                SystemSounds.Exclamation.Play();
                frm.tabReport.SelectedIndex = 0;
                SetAdvice("No hay reporte cargado. Usa \"Cargar reporte\" primero.", isError: true);
                return;
            }

            DataTable dt = BuildResumePreviewDt(_dtRawData);
            _resumeTotalRowIndex = dt.Rows.Count - 1;
            frm.dgvResumen.AutoGenerateColumns = true;
            frm.dgvResumen.DataSource          = null;
            frm.dgvResumen.DataSource          = dt;
            SetColumnWidths(frm.dgvResumen, new Dictionary<string, int>
            {
                ["CONTRATISTA"] = 100,
                ["CUADRILLA"]   = 100,
                ["NÚMERO"]      = 65,
                ["CÓDIGO"]      = 50,
                ["NOMBRE"]      = 210,
                ["DÍAS"]        = 55,
                ["TOTAL"]       = 75,
            });
        }

        private void ShowCajasEmpleado()
        {
            if (frm == null) return;
            if (_dtRawData == null || _dtRawData.Rows.Count == 0)
            {
                SystemSounds.Exclamation.Play();
                frm.tabReport.SelectedIndex = 0;
                SetAdvice("No hay reporte cargado. Usa \"Cargar reporte\" primero.", isError: true);
                return;
            }

            DataTable dt = BuildCajasEmpleadoPreviewDt(_dtRawData);
            _cajasEmpTotalRowIndex = dt.Rows.Count - 1;
            frm.dgvCajasEmpleado.AutoGenerateColumns = true;
            frm.dgvCajasEmpleado.DataSource          = null;
            frm.dgvCajasEmpleado.DataSource          = dt;
            SetColumnWidths(frm.dgvCajasEmpleado, new Dictionary<string, int>
            {
                ["CÓDIGO"] = 50,
                ["NOMBRE"] = 210,
                ["DÍAS"]   = 55,
                ["TOTAL"]  = 75,
            });
        }

        private static void SetColumnWidths(DataGridView dgv, Dictionary<string, int> widths)
        {
            foreach (var (col, w) in widths)
                if (dgv.Columns.Contains(col))
                    dgv.Columns[col].Width = w;
        }

        private void ShowReport() => ShowDetalle();

        // ── CellFormatting por DGV ────────────────────────────────────────────

        // Columnas fijas de cada tab plano (no reciben color verde ni amarillo de datos)
        private static readonly HashSet<string> ResumenFixedCols = new(StringComparer.OrdinalIgnoreCase)
            { "CONTRATISTA", "CUADRILLA", "NÚMERO", "CÓDIGO", "NOMBRE", "DÍAS" };

        private static readonly HashSet<string> CajasEmpFixedCols = new(StringComparer.OrdinalIgnoreCase)
            { "CÓDIGO", "NOMBRE", "DÍAS" };

        public void DgvResumen_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (frm == null || e.RowIndex < 0 || e.ColumnIndex < 0) return;
            string colName = frm.dgvResumen.Columns[e.ColumnIndex].DataPropertyName
                          ?? frm.dgvResumen.Columns[e.ColumnIndex].Name;
            ApplyFlatDgvFormatting(e, _resumeTotalRowIndex, colName, ResumenFixedCols);
        }

        public void DgvCajasEmpleado_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (frm == null || e.RowIndex < 0 || e.ColumnIndex < 0) return;
            string colName = frm.dgvCajasEmpleado.Columns[e.ColumnIndex].DataPropertyName
                          ?? frm.dgvCajasEmpleado.Columns[e.ColumnIndex].Name;
            ApplyFlatDgvFormatting(e, _cajasEmpTotalRowIndex, colName, CajasEmpFixedCols);
        }

        /// <summary>
        /// Formato para las tablas planas (RESUMEN / Cajas empleado):
        /// – Fila TOTAL GENERAL: amarillo + negrita en toda la fila.
        /// – Columna TOTAL (datos): amarillo + negrita.
        /// – Columnas fijas de texto (CÓDIGO, NOMBRE, etc.): solo color de fila alternado.
        /// – Columnas de empaque con valor: verde.
        /// – Resto: color de fila alternado.
        /// </summary>
        private static void ApplyFlatDgvFormatting(
            DataGridViewCellFormattingEventArgs e,
            int totalRowIndex,
            string colName,
            HashSet<string> fixedCols)
        {
            var colorTotal    = Color.FromArgb(0xFF, 0xC0, 0x00);
            var colorValue    = Color.FromArgb(0xC5, 0xDF, 0xB4);
            var colorEvenRow  = Color.FromArgb(0xE8, 0xF0, 0xF7);
            var colorOddRow   = Color.White;

            bool isTotal = e.RowIndex == totalRowIndex;
            bool isEven  = (e.RowIndex % 2 == 0);
            Color rowBg  = isEven ? colorEvenRow : colorOddRow;

            // ── Fila TOTAL GENERAL ─────────────────────────────────────────
            if (isTotal)
            {
                e.CellStyle.BackColor          = colorTotal;
                e.CellStyle.SelectionBackColor = ControlPaint.Dark(colorTotal, 0.1f);
                e.CellStyle.Font               = new Font(e.CellStyle.Font ?? SystemFonts.DefaultFont, FontStyle.Bold);
                return;
            }

            // ── Columna TOTAL (datos) ─────────────────────────────────────
            if (string.Equals(colName, "TOTAL", StringComparison.OrdinalIgnoreCase))
            {
                e.CellStyle.BackColor          = colorTotal;
                e.CellStyle.SelectionBackColor = ControlPaint.Dark(colorTotal, 0.1f);
                e.CellStyle.Font               = new Font(e.CellStyle.Font ?? SystemFonts.DefaultFont, FontStyle.Bold);
                return;
            }

            // ── Columnas fijas de texto ───────────────────────────────────
            if (fixedCols.Contains(colName))
            {
                e.CellStyle.BackColor          = rowBg;
                e.CellStyle.SelectionBackColor = ControlPaint.Dark(rowBg, 0.05f);
                return;
            }

            // ── Columnas de empaque ───────────────────────────────────────
            string? val = e.Value?.ToString();
            if (!string.IsNullOrWhiteSpace(val))
            {
                e.CellStyle.BackColor          = colorValue;
                e.CellStyle.SelectionBackColor = ControlPaint.Dark(colorValue, 0.1f);
            }
            else
            {
                e.CellStyle.BackColor          = rowBg;
                e.CellStyle.SelectionBackColor = ControlPaint.Dark(rowBg, 0.05f);
            }
        }

        // ── Clasificación de filas para colorear el DGV ───────────────────────

        private void ClassifyReportRows()
        {
            _rowKinds.Clear();
            if (_dtReportPreview == null) return;

            var empaqueColNames = _dtReportPreview.Columns
                .Cast<DataColumn>()
                .Select(c => c.ColumnName)
                .Where(n => !FixedReportCols.Contains(n))
                .ToList();

            foreach (DataRow row in _dtReportPreview.Rows)
            {
                string codigoNombre = row["CODIGO / NOMBRE / LP"]?.ToString() ?? string.Empty;
                string fecha        = row["FECHA"]?.ToString() ?? string.Empty;

                if (!string.IsNullOrWhiteSpace(codigoNombre))
                {
                    _rowKinds.Add(RowKind.Title);
                }
                else if (fecha == "TOTAL")
                {
                    _rowKinds.Add(RowKind.Total);
                }
                else if (string.IsNullOrWhiteSpace(fecha))
                {
                    _rowKinds.Add(RowKind.Separator);
                }
                else
                {
                    bool hasValue = empaqueColNames.Any(col =>
                        !string.IsNullOrWhiteSpace(row[col]?.ToString()));
                    _rowKinds.Add(hasValue ? RowKind.Data : RowKind.EmptyDay);
                }
            }
        }

        // ── Colorear celdas del DGV reporte (evento CellFormatting) ──────────

        // Cuántas columnas fijas (de izquierda a derecha) se funden visualmente
        // en las filas de título del empleado:
        //   0: CODIGO / NOMBRE / LP  |  1: FECHA  |  2: CUADRILLA  |  3: CONTRATISTA
        private const int TitleMergeCount = 4;

        /// <summary>
        /// Simula celdas fusionadas en la fila de título del empleado usando RowPostPaint.
        /// Este evento se dispara DESPUÉS de pintar todas las celdas de la fila y su
        /// Graphics NO está restringido al ancho de una sola celda, por lo que podemos
        /// dibujar texto que abarque varias columnas sin ningún problema de clip.
        /// </summary>
        public void DgvDetalle_RowPostPaint(object? sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (frm == null || e.RowIndex < 0 || e.RowIndex >= _rowKinds.Count) return;
            if (_rowKinds[e.RowIndex] != RowKind.Title) return;

            var dgv = frm.dgvDetalle;

            // GetCellDisplayRectangle devuelve la posición real de la celda 0 en
            // coordenadas cliente del DGV (ya incluye desplazamiento por scroll y
            // por el encabezado de fila si está visible).
            var cell0 = dgv.GetCellDisplayRectangle(0, e.RowIndex, cutOverflow: false);
            if (cell0.Width == 0) return;

            // Ancho total de las columnas que se van a fusionar visualmente
            int mergedWidth = 0;
            for (int ci = 0; ci < TitleMergeCount && ci < dgv.Columns.Count; ci++)
                if (dgv.Columns[ci].Visible)
                    mergedWidth += dgv.Columns[ci].Width;

            var merged = new Rectangle(cell0.X, cell0.Y, mergedWidth, cell0.Height);

            // ── Fondo (sobreescribe lo que pintaron las celdas individuales) ──
            using var bg = new SolidBrush(ColorTitle);
            e.Graphics.FillRectangle(bg, merged);

            // ── Texto del empleado (negrita, sin restricción de clip de celda) ──
            string text = string.Empty;
            if (_dtReportPreview != null && e.RowIndex < _dtReportPreview.Rows.Count)
                text = _dtReportPreview.Rows[e.RowIndex]["CODIGO / NOMBRE / LP"]?.ToString() ?? string.Empty;

            Font font   = GetBoldFont() ?? dgv.DefaultCellStyle.Font ?? SystemFonts.DefaultFont;
            var  textRF = new RectangleF(merged.X + 5, merged.Y, merged.Width - 10, merged.Height);
            using var fgBrush = new SolidBrush(SystemColors.ControlText);
            using var sf = new System.Drawing.StringFormat
            {
                Alignment     = StringAlignment.Near,
                LineAlignment = StringAlignment.Center,
                Trimming      = StringTrimming.EllipsisCharacter,
                FormatFlags   = StringFormatFlags.NoWrap,
            };
            e.Graphics.DrawString(text, font, fgBrush, textRF, sf);

            // ── Borde derecho del bloque fusionado ──
            using var gridPen = new Pen(dgv.GridColor);
            e.Graphics.DrawLine(gridPen,
                merged.Right - 1, merged.Top,
                merged.Right - 1, merged.Bottom - 1);
        }

        public void DgvDetalle_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (frm == null || _dtReportPreview == null) return;
            if (e.RowIndex < 0 || e.RowIndex >= _rowKinds.Count || e.ColumnIndex < 0) return;

            string colName = frm.dgvDetalle.Columns[e.ColumnIndex].DataPropertyName ?? string.Empty;

            switch (_rowKinds[e.RowIndex])
            {
                case RowKind.Title:
                    e.CellStyle.BackColor          = ColorTitle;
                    e.CellStyle.SelectionBackColor = ControlPaint.Dark(ColorTitle, 0.1f);
                    e.CellStyle.Font               = GetBoldFont();
                    break;

                case RowKind.Total:
                    e.CellStyle.BackColor          = ColorTotal;
                    e.CellStyle.SelectionBackColor = ControlPaint.Dark(ColorTotal, 0.1f);
                    e.CellStyle.Font               = GetBoldFont();
                    break;

                case RowKind.EmptyDay:
                    e.CellStyle.BackColor          = ColorEmptyDay;
                    e.CellStyle.SelectionBackColor = ControlPaint.Dark(ColorEmptyDay, 0.1f);
                    break;

                case RowKind.Data:
                    // Columnas fijas: sin color especial
                    if (FixedReportCols.Contains(colName) && colName != "TOTAL") break;

                    string? val = _dtReportPreview.Rows[e.RowIndex][colName]?.ToString();
                    if (!string.IsNullOrWhiteSpace(val))
                    {
                        e.CellStyle.BackColor          = ColorValue;
                        e.CellStyle.SelectionBackColor = ControlPaint.Dark(ColorValue, 0.1f);
                    }
                    if (colName == "TOTAL")
                        e.CellStyle.Font = GetBoldFont();
                    break;

                case RowKind.Separator:
                    e.CellStyle.BackColor = ColorSeparator;
                    break;
            }
        }

        private Font GetBoldFont()
        {
            if (_boldFont != null) return _boldFont;
            var baseFont = frm?.dgvDetalle.DefaultCellStyle.Font ?? SystemFonts.DefaultFont;
            return _boldFont = new Font(baseFont, FontStyle.Bold);
        }

        private void RefreshEmployeeDgv()
        {
            if (frm == null) return;
            // Solo refrescar si el tab de Listado está activo
            if (frm.tabReport.SelectedIndex == 0)
                ShowEmployeeList();
        }

        /// <summary>
        /// Convierte la columna "Sel." en una columna de checkboxes en el DGV del listado.
        /// </summary>
        private void ApplyCheckBoxColumnToSel()
        {
            if (frm == null) return;
            if (!frm.dgvListado.Columns.Contains(ColSel)) return;

            var col = frm.dgvListado.Columns[ColSel];
            if (col is DataGridViewCheckBoxColumn) return;

            int ordinal = col.Index;
            frm.dgvListado.Columns.Remove(col);

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
            frm.dgvListado.Columns.Insert(ordinal, chkCol);
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

        // ── Vistas previas planas para RESUMEN y Cajas empleado ─────────────

        /// <summary>
        /// Construye la DataTable para el DGV "RESUMEN":
        /// CONTRATISTA | CUADRILLA | NÚMERO | CÓDIGO | NOMBRE | [empaques] | DÍAS | TOTAL
        /// Última fila = TOTAL GENERAL.
        /// </summary>
        private static DataTable BuildResumePreviewDt(DataTable rawData)
        {
            var empaques = GetEmpaques(rawData);
            var dt = new DataTable();
            dt.Columns.Add("CONTRATISTA", typeof(string));
            dt.Columns.Add("CUADRILLA",   typeof(string));
            dt.Columns.Add("NÚMERO",      typeof(string));
            dt.Columns.Add("CÓDIGO",      typeof(string));
            dt.Columns.Add("NOMBRE",      typeof(string));
            foreach (string emp in empaques) dt.Columns.Add(emp, typeof(string));
            dt.Columns.Add("DÍAS",  typeof(string));
            dt.Columns.Add("TOTAL", typeof(string));

            decimal[] colTotals = new decimal[empaques.Count];
            int totalDias = 0;
            decimal grandTotal = 0m;

            var groups = rawData.AsEnumerable()
                .GroupBy(r => (
                    Contratista: SafeStr(r, ReportColumns.Contratista),
                    Cuadrilla:   SafeStr(r, ReportColumns.Cuadrilla),
                    Codigo:      SafeStr(r, ReportColumns.Codigo),
                    Nombre:      SafeStr(r, ReportColumns.Nombre)))
                .OrderBy(g => g.Key.Contratista).ThenBy(g => g.Key.Cuadrilla)
                .ThenBy(g => g.Key.Nombre).ThenBy(g => g.Key.Codigo);

            foreach (var g in groups)
            {
                string numero = ResolveNumero(g.ToList(), rawData);
                DataRow row = dt.NewRow();
                row["CONTRATISTA"] = g.Key.Contratista;
                row["CUADRILLA"]   = g.Key.Cuadrilla;
                row["NÚMERO"]      = numero;
                row["CÓDIGO"]      = g.Key.Codigo;
                row["NOMBRE"]      = g.Key.Nombre;

                decimal rowTotal = 0m;
                for (int i = 0; i < empaques.Count; i++)
                {
                    decimal val = g.Where(r => SafeStr(r, ReportColumns.Empaque) == empaques[i])
                                   .Sum(r => ToDecimal(r[ReportColumns.Cajas]));
                    row[empaques[i]] = val == 0m ? string.Empty : val.ToString("0.##", ClsPayrollBoxPerEmployeeReportExcel.CultureEs);
                    colTotals[i] += val;
                    rowTotal += val;
                }

                int dias = g.Select(r => NormalizeDate(r[ReportColumns.Fecha]))
                             .Where(d => d != DateTime.MinValue).Distinct().Count();
                row["DÍAS"]  = dias.ToString();
                row["TOTAL"] = rowTotal.ToString("0.##", ClsPayrollBoxPerEmployeeReportExcel.CultureEs);
                totalDias += dias;
                grandTotal += rowTotal;
                dt.Rows.Add(row);
            }

            // Fila total general
            DataRow totRow = dt.NewRow();
            totRow["CONTRATISTA"] = "TOTAL GENERAL";
            for (int i = 0; i < empaques.Count; i++)
                totRow[empaques[i]] = colTotals[i] == 0m ? string.Empty
                    : colTotals[i].ToString("0.##", ClsPayrollBoxPerEmployeeReportExcel.CultureEs);
            totRow["DÍAS"]  = totalDias.ToString();
            totRow["TOTAL"] = grandTotal.ToString("0.##", ClsPayrollBoxPerEmployeeReportExcel.CultureEs);
            dt.Rows.Add(totRow);

            return dt;
        }

        /// <summary>
        /// Construye la DataTable para el DGV "Cajas empleado":
        /// CÓDIGO | NOMBRE | [empaques] | DÍAS | TOTAL
        /// Última fila = TOTAL GENERAL.
        /// </summary>
        private static DataTable BuildCajasEmpleadoPreviewDt(DataTable rawData)
        {
            var empaques = GetEmpaques(rawData);
            var dt = new DataTable();
            dt.Columns.Add("CÓDIGO", typeof(string));
            dt.Columns.Add("NOMBRE", typeof(string));
            foreach (string emp in empaques) dt.Columns.Add(emp, typeof(string));
            dt.Columns.Add("DÍAS",  typeof(string));
            dt.Columns.Add("TOTAL", typeof(string));

            decimal[] colTotals = new decimal[empaques.Count];
            int totalDias = 0;
            decimal grandTotal = 0m;

            var groups = rawData.AsEnumerable()
                .GroupBy(r => (
                    Codigo: SafeStr(r, ReportColumns.Codigo),
                    Nombre: SafeStr(r, ReportColumns.Nombre)))
                .OrderBy(g => g.Key.Nombre).ThenBy(g => g.Key.Codigo);

            foreach (var g in groups)
            {
                DataRow row = dt.NewRow();
                row["CÓDIGO"] = g.Key.Codigo;
                row["NOMBRE"] = g.Key.Nombre;

                decimal rowTotal = 0m;
                for (int i = 0; i < empaques.Count; i++)
                {
                    decimal val = g.Where(r => SafeStr(r, ReportColumns.Empaque) == empaques[i])
                                   .Sum(r => ToDecimal(r[ReportColumns.Cajas]));
                    row[empaques[i]] = val == 0m ? string.Empty : val.ToString("0.##", ClsPayrollBoxPerEmployeeReportExcel.CultureEs);
                    colTotals[i] += val;
                    rowTotal += val;
                }

                int dias = g.Select(r => NormalizeDate(r[ReportColumns.Fecha]))
                             .Where(d => d != DateTime.MinValue).Distinct().Count();
                row["DÍAS"]  = dias.ToString();
                row["TOTAL"] = rowTotal.ToString("0.##", ClsPayrollBoxPerEmployeeReportExcel.CultureEs);
                totalDias += dias;
                grandTotal += rowTotal;
                dt.Rows.Add(row);
            }

            DataRow totRow = dt.NewRow();
            totRow["CÓDIGO"] = "TOTAL GENERAL";
            for (int i = 0; i < empaques.Count; i++)
                totRow[empaques[i]] = colTotals[i] == 0m ? string.Empty
                    : colTotals[i].ToString("0.##", ClsPayrollBoxPerEmployeeReportExcel.CultureEs);
            totRow["DÍAS"]  = totalDias.ToString();
            totRow["TOTAL"] = grandTotal.ToString("0.##", ClsPayrollBoxPerEmployeeReportExcel.CultureEs);
            dt.Rows.Add(totRow);

            return dt;
        }

        // ── Helpers para los Build*PreviewDt ─────────────────────────────────

        private static List<string> GetEmpaques(DataTable rawData)
            => rawData.AsEnumerable()
                .Select(r => SafeStr(r, ReportColumns.Empaque))
                .Where(e => !string.IsNullOrWhiteSpace(e))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .OrderBy(e => e, StringComparer.OrdinalIgnoreCase)
                .ToList();

        private static string SafeStr(DataRow r, string col)
            => r.Table.Columns.Contains(col)
                ? r[col]?.ToString()?.Trim() ?? string.Empty
                : string.Empty;

        private static decimal ToDecimal(object? v)
            => v == null || v == DBNull.Value ? 0m : Convert.ToDecimal(v);

        private static string ResolveNumero(List<DataRow> rows, DataTable _)
        {
            DateTime lastDate = rows
                .Select(r => NormalizeDate(r[ReportColumns.Fecha]))
                .Where(d => d != DateTime.MinValue)
                .DefaultIfEmpty(DateTime.MinValue).Max();

            if (lastDate == DateTime.MinValue) return string.Empty;

            var lastDayNums = rows
                .Where(r => NormalizeDate(r[ReportColumns.Fecha]) == lastDate)
                .Select(r => SafeStr(r, "NUMERO"))
                .Where(n => !string.IsNullOrWhiteSpace(n))
                .Distinct(StringComparer.OrdinalIgnoreCase).ToList();

            if (lastDayNums.Count == 1) return lastDayNums[0];

            foreach (var day in rows
                .Select(r => NormalizeDate(r[ReportColumns.Fecha]))
                .Where(d => d != DateTime.MinValue && d < lastDate)
                .Distinct().OrderByDescending(d => d))
            {
                var dayNums = rows
                    .Where(r => NormalizeDate(r[ReportColumns.Fecha]) == day)
                    .Select(r => SafeStr(r, "NUMERO"))
                    .Where(n => !string.IsNullOrWhiteSpace(n))
                    .Distinct(StringComparer.OrdinalIgnoreCase).ToList();
                if (dayNums.Count == 1) return dayNums[0];
            }

            return lastDayNums.FirstOrDefault() ?? string.Empty;
        }

        // ── Vista previa del reporte para el DGV ─────────────────────────────

        private static DataTable BuildReportPreview(DataTable rawData, DateTime rangeStart, DateTime rangeEnd)
        {
            var preview = new DataTable();
            preview.Columns.Add("CODIGO / NOMBRE / LP", typeof(string));
            preview.Columns.Add("FECHA",       typeof(string));
            preview.Columns.Add("CUADRILLA",   typeof(string));
            preview.Columns.Add("CONTRATISTA", typeof(string));

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

                // Lookup (Fecha, Cuadrilla) → Contratista para este empleado
                var contratistaLookup = empGroup
                    .GroupBy(r => (
                        Fecha:     NormalizeDate(r[ReportColumns.Fecha]),
                        Cuadrilla: r[ReportColumns.Cuadrilla]?.ToString()?.Trim() ?? string.Empty))
                    .ToDictionary(
                        g => g.Key,
                        g => g.First()[ReportColumns.Contratista]?.ToString()?.Trim() ?? string.Empty);

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
                    dataRow["FECHA"]       = fecha.ToString("dd-MMM", ClsPayrollBoxPerEmployeeReportExcel.CultureEs);
                    dataRow["CUADRILLA"]   = cuadrilla;
                    contratistaLookup.TryGetValue((fecha, cuadrilla), out string? contratista);
                    dataRow["CONTRATISTA"] = contratista ?? string.Empty;

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
