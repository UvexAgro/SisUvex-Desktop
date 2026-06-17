using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SisUvex.Nomina.CONTRATO.PayrollPack_BoxPerNumber.BoxPerEmployeeReport
{
    /// <summary>
    /// Orquestador del Excel de "Cajas por empleado".
    /// Crea el workbook, delega cada hoja a su clase de reporte y expone
    /// utilidades estáticas compartidas por todos los reportes.
    /// Para agregar un nuevo reporte: crea una clase ClsExcelReport{Nombre},
    /// instánciala aquí y llama a WriteSheet(workbook, ...).
    /// </summary>
    internal class ClsPayrollBoxPerEmployeeReportExcel
    {
        // ── Colores compartidos (accesibles por las clases de reporte) ─────────
        internal static readonly XLColor ColorHeader      = XLColor.FromHtml("#538DD5");
        internal static readonly XLColor ColorTableHeader = XLColor.FromHtml("#8DB4E2");
        internal static readonly XLColor ColorValueCell   = XLColor.FromHtml("#c5dfb4");
        internal static readonly XLColor ColorGroupHeader = XLColor.FromHtml("#D9E1F2");
        internal static readonly XLColor ColorEmptyRow    = XLColor.FromHtml("#ff7c80");

        private static readonly XLColor ColorTabData = XLColor.FromHtml("#BCE292");

        public string DataSheetName { get; set; } = "DATA";

        internal static CultureInfo CultureEs { get; } = CultureInfo.GetCultureInfo("es-MX");

        // ── Vista previa DGV: usa el primer reporte (por anotador) ────────────
        public DataTable BuildPreviewDataTable(DataTable? data, DateTime rangeStart, DateTime rangeEnd)
            => new ClsExcelReportPorAnotador().BuildPreviewDataTable(data, rangeStart, rangeEnd);

        // ── Generación del Excel completo ─────────────────────────────────────
        public void GenerateExcelReport(
            DataTable? reportData,
            DateTime rangeStart,
            DateTime rangeEnd,
            string season,
            string contractor,
            string workGroup,
            string user,
            string dateRange)
        {
            if (reportData == null || reportData.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para generar el reporte.", "Reporte cajas por empleado",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string fileName = GetFileReportName(dateRange);
            string? filePath = GetFolderPath(fileName);
            if (filePath == null)
                return;

            if (IsFileLocked(filePath))
            {
                MessageBox.Show(
                    $"El archivo '{filePath}' está abierto.\n\nCiérralo antes de generar el reporte.",
                    "Reporte cajas por empleado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string filtersText = BuildFiltersText(season, contractor, workGroup, user, dateRange);

            using var workbook = new XLWorkbook();

            // ── Hojas de reporte primero (la primera quedará activa al abrir) ──
            var firstSheet = new ClsExcelReportPorAnotador()
                .WriteSheet(workbook, reportData, rangeStart, rangeEnd, filtersText);

            new ClsExcelReportPorCuadrilla()
                .WriteSheet(workbook, reportData, rangeStart, rangeEnd, filtersText);

            new ClsExcelReportConcentradoCuadrillas()
                .WriteSheet(workbook, reportData, rangeStart, rangeEnd, filtersText);

            new ClsPayrollBoxPerEmployeeResumeExcel()
                .WriteSheet(workbook, reportData, filtersText);

            // ── Hoja de datos al final ─────────────────────────────────────────
            AddRawDataSheet(workbook, reportData, DataSheetName, ColorTabData);

            // Activar la primera hoja de reporte al abrir el archivo
            firstSheet.SetTabActive();

            workbook.SaveAs(filePath);

            DialogResult result = MessageBox.Show(
                "Reporte en excel generado correctamente.\n\n¿Deseas abrir el archivo?",
                "Reporte cajas por empleado",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = filePath,
                    UseShellExecute = true
                });
            }
        }

        // ── Utilidades estáticas compartidas ──────────────────────────────────

        private static void AddRawDataSheet(XLWorkbook workbook, DataTable dataTable, string sheetName, XLColor tabColor)
        {
            var ws = workbook.Worksheets.Add(dataTable, SanitizeSheetName(sheetName));
            ws.TabColor = tabColor;
            ws.Tables.First().ShowAutoFilter = true;
            ws.Columns().AdjustToContents();
        }

        /// <summary>
        /// Construye la lista ordenada de columnas dinámicas (Fecha + Empaque)
        /// que aparecerán en el reporte, cubriendo todos los días del rango.
        /// </summary>
        internal static List<DateEmpaqueColumnKey> BuildDateEmpaqueColumns(
            DataTable data, DateTime rangeStart, DateTime rangeEnd)
        {
            var distinctByDay = data.AsEnumerable()
                .Where(r => r.Table.Columns.Contains(ClsPayrollBoxPerEmployeeReport.Columns.Fecha))
                .Select(r => new
                {
                    Fecha = NormalizeDate(r[ClsPayrollBoxPerEmployeeReport.Columns.Fecha]),
                    IdPrice = SafeStr(r, ClsPayrollBoxPerEmployeeReport.Columns.IdPrice),
                    Empaque = SafeStr(r, ClsPayrollBoxPerEmployeeReport.Columns.Empaque),
                })
                .Where(x => x.Fecha != DateTime.MinValue)
                .ToList();

            var empaquesPorFecha = distinctByDay
                .GroupBy(x => x.Fecha.Date)
                .ToDictionary(
                    g => g.Key,
                    g => g
                        .Where(x => !string.IsNullOrWhiteSpace(x.Empaque))
                        .Select(x => (x.IdPrice, x.Empaque))
                        .Distinct()
                        .OrderBy(x => x.IdPrice, StringComparer.OrdinalIgnoreCase)
                        .ThenBy(x => x.Empaque, StringComparer.OrdinalIgnoreCase)
                        .ToList());

            var result = new List<DateEmpaqueColumnKey>();
            foreach (DateTime day in EachDayInclusive(rangeStart, rangeEnd))
            {
                if (!empaquesPorFecha.TryGetValue(day.Date, out var list) || list.Count == 0)
                {
                    result.Add(new DateEmpaqueColumnKey(day.Date, string.Empty, string.Empty));
                    continue;
                }

                foreach (var item in list)
                    result.Add(new DateEmpaqueColumnKey(day.Date, item.Empaque, item.IdPrice));
            }

            return result;
        }

        internal static IEnumerable<DateTime> EachDayInclusive(DateTime rangeStart, DateTime rangeEnd)
        {
            DateTime start = rangeStart.Date;
            DateTime end   = rangeEnd.Date;
            if (start > end) yield break;

            for (DateTime day = start; day <= end; day = day.AddDays(1))
                yield return day;
        }

        internal static DateTime NormalizeDate(object? value)
        {
            if (value == null || value == DBNull.Value) return DateTime.MinValue;
            if (value is DateTime dt) return dt.Date;
            return DateTime.Parse(value.ToString()!, CultureInfo.InvariantCulture).Date;
        }

        internal static decimal ToDecimal(object? value)
        {
            if (value == null || value == DBNull.Value) return 0m;
            return Convert.ToDecimal(value, CultureInfo.InvariantCulture);
        }

        internal static string FormatBoxes(decimal value)
            => value == 0m ? string.Empty : value.ToString("0.##", CultureEs);

        internal static string BuildFiltersText(
            string season, string contractor, string workGroup, string user, string dateRange)
        {
            var parts = new List<string>();
            if (!string.IsNullOrWhiteSpace(dateRange))  parts.Add($"Fechas: {dateRange}");
            if (!string.IsNullOrWhiteSpace(season))     parts.Add($"Temporada: {season}");
            if (!string.IsNullOrWhiteSpace(contractor)) parts.Add($"Contratista: {contractor}");
            if (!string.IsNullOrWhiteSpace(workGroup))  parts.Add($"Cuadrilla: {workGroup}");
            if (!string.IsNullOrWhiteSpace(user))       parts.Add($"Anotador: {user}");
            return string.Join(" | ", parts);
        }

        internal static string SanitizeSheetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return "REPORTE";
            string s = System.Text.RegularExpressions.Regex.Replace(name, @"[\\\/\?\*\[\]]", "-");
            if (s.Length > 31) s = s[..31];
            return s.Trim();
        }

        /// <summary>Obtiene el valor de una columna como string limpio; vacío si no existe o es nulo.</summary>
        internal static string SafeStr(DataRow row, string col)
            => row.Table.Columns.Contains(col) && row[col] != DBNull.Value
                ? row[col].ToString()?.Trim() ?? string.Empty
                : string.Empty;

        // ── Helpers privados de archivo ───────────────────────────────────────

        private string GetFileReportName(string dateRange)
        {
            string name = "Reporte cajas por empleado";
            if (!string.IsNullOrWhiteSpace(dateRange))
                name += " " + System.Text.RegularExpressions.Regex.Replace(dateRange, @"[\\\/\?\*\[\]]", "-");
            return name + ".xlsx";
        }

        private string? GetFolderPath(string fileReportName)
        {
            using var dlg = new SaveFileDialog
            {
                Title          = "Guardar reporte de Excel",
                FileName       = fileReportName,
                Filter         = "Archivo de Excel (*.xlsx)|*.xlsx|Archivo de Excel 97-2003 (*.xls)|*.xls|Todos los archivos (*.*)|*.*",
                FilterIndex    = 1,
                AddExtension   = true,
                DefaultExt     = "xlsx",
                OverwritePrompt = true,
            };
            return dlg.ShowDialog() == DialogResult.OK ? dlg.FileName : null;
        }

        private static bool IsFileLocked(string filePath)
        {
            if (!File.Exists(filePath)) return false;
            try
            {
                using var stream = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException) { return true; }
            return false;
        }
    }

    // ── Modelo compartido entre todos los reportes ────────────────────────────

    /// <summary>Clave de columna dinámica: fecha + tipo de empaque.</summary>
    internal readonly record struct DateEmpaqueColumnKey(DateTime Fecha, string Empaque, string IdPrice)
    {
        public string EmpaqueDisplay => string.IsNullOrWhiteSpace(Empaque) ? string.Empty : Empaque;
        public string Display        => $"{Fecha:dd-MMM} {EmpaqueDisplay}".Trim();
    }
}
