using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SisUvex.Nomina.Asistencia_AS
{
    /// <summary>
    /// Reporte Excel de asistencias/inasistencias.
    /// Hojas:
    ///   1. "Reporte Asistencias" – Código, Nombre completo, LP, Total + 1 columna por día
    ///      (encabezado con fila de mes/año fusionada y fila de día "dd").
    ///   2. "DATA" – datos crudos de la tabla del reporte.
    /// </summary>
    internal sealed class ClsExcelAsistenciaASConsulta
    {
        private static readonly XLColor TabColorReport = XLColor.FromHtml("#1F3864");
        private static readonly XLColor TabColorData    = XLColor.FromHtml("#BCE292");

        private static readonly XLColor ColorHeader      = XLColor.FromHtml("#538DD5");
        private static readonly XLColor ColorTableHeader = XLColor.FromHtml("#8DB4E2");
        private static readonly XLColor ColorMonthBand   = XLColor.FromHtml("#D9E1F2");

        private const int StartCol  = 2;
        private const int FixedCols = 4; // CÓDIGO | NOMBRE COMPLETO | LP | TOTAL

        // ── Punto de entrada ──────────────────────────────────────────────────

        public void GenerateExcelReport(
            DataTable reportData,
            List<DateTime> days,
            Dictionary<string, Color> attendanceColorsByPrefix,
            Color colorAsistencia,
            string dateRange)
        {
            if (reportData == null || reportData.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para generar el reporte.", "Reporte de inasistencias",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string fileName = "Reporte inasistencias " +
                System.Text.RegularExpressions.Regex.Replace(dateRange ?? string.Empty, @"[\\\/\?\*\[\]]", "-") + ".xlsx";

            using var dlg = new SaveFileDialog
            {
                Title           = "Guardar reporte de Excel",
                FileName        = fileName,
                Filter          = "Archivo de Excel (*.xlsx)|*.xlsx|Todos los archivos (*.*)|*.*",
                FilterIndex     = 1,
                AddExtension    = true,
                DefaultExt      = "xlsx",
                OverwritePrompt = true,
            };

            if (dlg.ShowDialog() != DialogResult.OK) return;
            string filePath = dlg.FileName;

            if (IsFileLocked(filePath))
            {
                MessageBox.Show(
                    $"El archivo '{filePath}' está abierto. Ciérralo e inténtalo de nuevo.",
                    "Archivo bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var wb = new XLWorkbook();

            var wsReport = CreateReportSheet(wb, reportData, days ?? new List<DateTime>(), attendanceColorsByPrefix, colorAsistencia, dateRange);

            AddRawDataSheet(wb, reportData);

            wsReport.SetTabActive();
            wb.SaveAs(filePath);

            DialogResult res = MessageBox.Show(
                "Reporte de inasistencias generado correctamente.\n\n¿Deseas abrir el archivo?",
                "Reporte de inasistencias",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);

            if (res == DialogResult.Yes)
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    { FileName = filePath, UseShellExecute = true });
        }

        // ── Hoja "Reporte Asistencias" ─────────────────────────────────────────

        private IXLWorksheet CreateReportSheet(
            IXLWorkbook wb,
            DataTable reportData,
            List<DateTime> days,
            Dictionary<string, Color> attendanceColorsByPrefix,
            Color colorAsistencia,
            string dateRange)
        {
            var ws = wb.Worksheets.Add("Reporte Asistencias");
            ws.TabColor = TabColorReport;

            int totalCols = FixedCols + Math.Max(days.Count, 1);

            // Fila de filtros
            const int filtersRow = 1;
            ws.Cell(filtersRow, StartCol).Value = $"Reporte de asistencias / inasistencias  |  Fechas: {dateRange}";
            ws.Range(filtersRow, StartCol, filtersRow, StartCol + totalCols - 1).Merge();
            var filtersStyle = ws.Cell(filtersRow, StartCol).Style;
            filtersStyle.Font.SetBold();
            filtersStyle.Fill.SetBackgroundColor(ColorHeader);
            filtersStyle.Font.FontColor = XLColor.White;
            filtersStyle.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left);

            int monthRow      = filtersRow + 2;
            int dayRow        = monthRow + 1;
            int dataStartRow  = dayRow + 1;
            int dayColStart   = StartCol + FixedCols;

            // Encabezados fijos, fusionados verticalmente (monthRow:dayRow) al no tener banda de mes
            string[] fixedHeaders = { "CÓDIGO", "NOMBRE COMPLETO", "LP", "TOTAL" };
            for (int i = 0; i < fixedHeaders.Length; i++)
            {
                int col = StartCol + i;
                ws.Range(monthRow, col, dayRow, col).Merge();
                ws.Cell(monthRow, col).Value = fixedHeaders[i];
            }
            ws.Range(monthRow, StartCol, dayRow, StartCol + fixedHeaders.Length - 1).Style
                .Font.SetBold()
                .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                .Fill.SetBackgroundColor(ColorTableHeader);

            // Encabezados de fecha: banda de mes/año fusionada + fila de día ("dd")
            int col2 = dayColStart;
            foreach (var monthGroup in days.GroupBy(d => new { d.Year, d.Month }))
            {
                var groupDays = monthGroup.ToList();
                int groupColStart = col2;
                int groupColEnd   = col2 + groupDays.Count - 1;

                ws.Range(monthRow, groupColStart, monthRow, groupColEnd).Merge();
                var monthCell = ws.Cell(monthRow, groupColStart);
                monthCell.Value = new DateTime(monthGroup.Key.Year, monthGroup.Key.Month, 1);
                monthCell.Style.DateFormat.Format = "MMMM yyyy";
                monthCell.Style.Font.SetBold();
                monthCell.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                monthCell.Style.Fill.SetBackgroundColor(ColorMonthBand);

                foreach (DateTime day in groupDays)
                {
                    var dayCell = ws.Cell(dayRow, col2);
                    dayCell.Value = day;
                    dayCell.Style.DateFormat.Format = "dd";
                    dayCell.Style.Font.SetBold();
                    dayCell.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    dayCell.Style.Fill.SetBackgroundColor(ColorTableHeader);
                    if (day.DayOfWeek == DayOfWeek.Sunday)
                        dayCell.Style.Font.FontColor = XLColor.Red;
                    col2++;
                }
            }

            int lastDayCol = dayColStart + Math.Max(days.Count, 1) - 1;

            ws.Range(monthRow, StartCol, dayRow, lastDayCol).Style
                .Border.SetOutsideBorder(XLBorderStyleValues.Medium)
                .Border.SetInsideBorder(XLBorderStyleValues.Thin);

            // Filas de datos (una por empleado)
            int row = dataStartRow;
            foreach (DataRow r in reportData.Rows)
            {
                ws.Cell(row, StartCol).Value     = SafeStr(r, ClsAsistenciaASConsulta.ReportColCodigo);
                ws.Cell(row, StartCol + 1).Value = SafeStr(r, ClsAsistenciaASConsulta.ReportColNombre);
                ws.Cell(row, StartCol + 2).Value = SafeStr(r, ClsAsistenciaASConsulta.ReportColLp);

                var totalCell = ws.Cell(row, StartCol + 3);
                totalCell.Value = ToInt(r[ClsAsistenciaASConsulta.ReportColTotal]);
                totalCell.Style.Font.SetBold();
                totalCell.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                int col = dayColStart;
                foreach (DateTime day in days)
                {
                    string value = SafeStr(r, ClsAsistenciaASConsulta.BuildDayColumnName(day));
                    var cell = ws.Cell(row, col);

                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        cell.Value = value;
                        cell.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                        Color? bg = null;
                        if (string.Equals(value, ClsAsistenciaASConsulta.ValueAsistencia, StringComparison.OrdinalIgnoreCase))
                            bg = colorAsistencia;
                        else if (attendanceColorsByPrefix.TryGetValue(value, out Color prefixColor))
                            bg = prefixColor;

                        if (bg.HasValue)
                            cell.Style.Fill.SetBackgroundColor(XLColor.FromColor(bg.Value));
                    }

                    col++;
                }

                row++;
            }

            if (row > dataStartRow)
            {
                ws.Range(dataStartRow, StartCol, row - 1, lastDayCol).Style
                    .Border.SetOutsideBorder(XLBorderStyleValues.Medium)
                    .Border.SetInsideBorder(XLBorderStyleValues.Thin);
            }

            ws.SheetView.FreezeRows(dayRow);
            ws.SheetView.FreezeColumns(StartCol + fixedHeaders.Length - 1);

            ws.Columns().AdjustToContents();
            ws.Column(1).Width = 2;

            return ws;
        }

        // ── Hoja DATA ─────────────────────────────────────────────────────────

        private void AddRawDataSheet(IXLWorkbook wb, DataTable data)
        {
            var ws = wb.Worksheets.Add(data, "DATA");
            ws.TabColor = TabColorData;
            ws.Tables.First().ShowAutoFilter = true;
            ws.Columns().AdjustToContents();
        }

        // ── Utilidades estáticas ──────────────────────────────────────────────

        private static string SafeStr(DataRow row, string col)
            => row.Table.Columns.Contains(col) && row[col] != DBNull.Value
                ? row[col].ToString()?.Trim() ?? string.Empty
                : string.Empty;

        private static int ToInt(object? value)
            => value == null || value == DBNull.Value ? 0 : Convert.ToInt32(value);

        private static bool IsFileLocked(string path)
        {
            if (!File.Exists(path)) return false;
            try { using var s = new FileStream(path, FileMode.Open, FileAccess.ReadWrite, FileShare.None); }
            catch (IOException) { return true; }
            return false;
        }
    }
}
