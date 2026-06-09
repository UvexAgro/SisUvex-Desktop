using ClosedXML.Excel;
using SisUvex.Catalogos.Metods.ExcelLoad;
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
    /// Reporte Excel: Detalle por empleado.
    /// Hojas:
    ///   1. "Reporte Detalle"  – una tabla por empleado (Fecha×Empaque)
    ///   2. "LISTADO EMP."     – empleados seleccionados del listado
    ///   3. "DATA"             – datos crudos de la consulta
    /// </summary>
    internal sealed class ClsExcelReportDetalleEmpleado
    {
        private static readonly XLColor TabColorReport   = XLColor.FromHtml("#7030A0");
        private static readonly XLColor TabColorListado  = XLColor.FromHtml("#FF9900");
        private static readonly XLColor TabColorData     = XLColor.FromHtml("#BCE292");

        private static readonly XLColor ColorHeader      = XLColor.FromHtml("#538DD5");
        private static readonly XLColor ColorTableHeader = XLColor.FromHtml("#8DB4E2");
        private static readonly XLColor ColorValueCell   = XLColor.FromHtml("#c5dfb4");
        private static readonly XLColor ColorEmptyRow    = XLColor.FromHtml("#ffc7ce");
        private static readonly XLColor ColorTotalRow    = XLColor.FromHtml("#FFC000");
        private static readonly XLColor ColorGroupTitle  = XLColor.FromHtml("#D9E1F2");

        private const int StartCol  = 2;

        // ── Punto de entrada ──────────────────────────────────────────────────

        public void GenerateExcelReport(
            DataTable rawData,
            DataTable selectedEmployees,
            DateTime rangeStart,
            DateTime rangeEnd,
            string dateRange)
        {
            string fileName = "Reporte detalle empleado " +
                System.Text.RegularExpressions.Regex.Replace(dateRange, @"[\\\/\?\*\[\]]", "-") + ".xlsx";

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

            // 1. Hoja de reporte (primera → se abre al abrir el archivo)
            var wsReport = CreateReportSheet(wb, rawData, rangeStart, rangeEnd, dateRange);

            // 2. Hoja de listado de empleados
            CreateListadoSheet(wb, selectedEmployees);

            // 3. Hoja DATA
            AddRawDataSheet(wb, rawData);

            wsReport.SetTabActive();
            wb.SaveAs(filePath);

            DialogResult res = MessageBox.Show(
                "Reporte generado correctamente.\n\n¿Deseas abrir el archivo?",
                "Reporte detalle empleado",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);

            if (res == DialogResult.Yes)
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    { FileName = filePath, UseShellExecute = true });
        }

        // ── Hoja REPORTE DETALLE ──────────────────────────────────────────────

        private IXLWorksheet CreateReportSheet(
            IXLWorkbook wb,
            DataTable rawData,
            DateTime rangeStart,
            DateTime rangeEnd,
            string dateRange)
        {
            var ws = wb.Worksheets.Add("Reporte Detalle");
            ws.TabColor = TabColorReport;

            // Empaques únicos (columnas dinámicas)
            var empaques = rawData.AsEnumerable()
                .Select(r => (
                    Id:   SafeStr(r, ClsPayrollBoxPerEmployeeDetailReport.ReportColumns.Empaque),
                    Name: SafeStr(r, ClsPayrollBoxPerEmployeeDetailReport.ReportColumns.Empaque)))
                .Where(e => !string.IsNullOrWhiteSpace(e.Name))
                .Select(e => e.Name)
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .OrderBy(e => e, StringComparer.OrdinalIgnoreCase)
                .ToList();

            // Número de columnas: Fecha + Cuadrilla + (empaques) + Total
            int fixedCols = 2; // Fecha | Cuadrilla
            int totalCols = fixedCols + empaques.Count + 1; // +1 = TOTAL

            int row = 1;

            // Fila de filtros
            string filtersText = $"Reporte detalle por empleado  |  Fechas: {dateRange}";
            ws.Cell(row, StartCol).Value = filtersText;
            ws.Range(row, StartCol, row, StartCol + totalCols - 1).Merge();
            var hdrStyle = ws.Cell(row, StartCol).Style;
            hdrStyle.Font.SetBold();
            hdrStyle.Fill.SetBackgroundColor(ColorHeader);
            hdrStyle.Font.FontColor = XLColor.White;
            hdrStyle.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left);
            row += 2;

            // Agrupar datos por empleado
            var byEmployee = rawData.AsEnumerable()
                .GroupBy(r => SafeStr(r, ClsPayrollBoxPerEmployeeDetailReport.ReportColumns.Codigo))
                .OrderBy(g => g.Key, StringComparer.OrdinalIgnoreCase);

            foreach (var empGroup in byEmployee)
            {
                string codigo = empGroup.Key;
                string nombre = SafeStr(empGroup.First(), ClsPayrollBoxPerEmployeeDetailReport.ReportColumns.Nombre);
                string lp     = SafeStr(empGroup.First(), ClsPayrollBoxPerEmployeeDetailReport.ReportColumns.Lp);

                // Título del empleado
                ws.Cell(row, StartCol).Value = $"{codigo}  –  {nombre}  –  LP: {lp}";
                ws.Range(row, StartCol, row, StartCol + totalCols - 1).Merge();
                var titleStyle = ws.Cell(row, StartCol).Style;
                titleStyle.Font.SetBold();
                titleStyle.Fill.SetBackgroundColor(ColorGroupTitle);
                row++;

                int headerRow = row;

                // Encabezados de columna
                ws.Cell(headerRow, StartCol).Value     = "FECHA";
                ws.Cell(headerRow, StartCol + 1).Value = "CUADRILLA";
                for (int i = 0; i < empaques.Count; i++)
                    ws.Cell(headerRow, StartCol + fixedCols + i).Value = empaques[i];
                ws.Cell(headerRow, StartCol + fixedCols + empaques.Count).Value = "TOTAL";

                ws.Range(headerRow, StartCol, headerRow, StartCol + totalCols - 1).Style
                    .Font.SetBold()
                    .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                    .Fill.SetBackgroundColor(ColorTableHeader)
                    .Border.SetOutsideBorder(XLBorderStyleValues.Medium)
                    .Border.SetInsideBorder(XLBorderStyleValues.Thin);

                row++;
                int dataStartRow = row;

                // Precalcular datos (Fecha, Cuadrilla, Empaque) → suma cajas
                var cellData = empGroup
                    .GroupBy(r => (
                        Fecha:     NormalizeDate(r[ClsPayrollBoxPerEmployeeDetailReport.ReportColumns.Fecha]),
                        Cuadrilla: SafeStr(r, ClsPayrollBoxPerEmployeeDetailReport.ReportColumns.Cuadrilla),
                        Empaque:   SafeStr(r, ClsPayrollBoxPerEmployeeDetailReport.ReportColumns.Empaque)))
                    .ToDictionary(
                        g => g.Key,
                        g => g.Sum(r => ToDecimal(r[ClsPayrollBoxPerEmployeeDetailReport.ReportColumns.Cajas])));

                // Combinaciones únicas (Fecha, Cuadrilla) ordenadas
                var rowKeys = cellData.Keys
                    .Select(k => (k.Fecha, k.Cuadrilla))
                    .Distinct()
                    .OrderBy(k => k.Fecha)
                    .ThenBy(k => k.Cuadrilla, StringComparer.OrdinalIgnoreCase)
                    .ToList();

                // Expandir a todos los días del rango
                var allDays = ClsPayrollBoxPerEmployeeReportExcel
                    .EachDayInclusive(rangeStart, rangeEnd)
                    .SelectMany(day =>
                    {
                        var cuads = rowKeys.Where(k => k.Fecha == day).Select(k => k.Cuadrilla).Distinct().ToList();
                        return cuads.Count > 0
                            ? cuads.Select(c => (Fecha: day, Cuadrilla: c))
                            : new List<(DateTime, string)> { (day, string.Empty) };
                    }).ToList();

                decimal[] colTotals = new decimal[empaques.Count];

                foreach (var (fecha, cuadrilla) in allDays)
                {
                    var fechaCell = ws.Cell(row, StartCol);
                    fechaCell.Value = fecha;
                    fechaCell.Style.DateFormat.Format = "dd-MMM";

                    ws.Cell(row, StartCol + 1).Value = cuadrilla;

                    decimal rowTotal = 0m;
                    bool hasData = false;

                    for (int i = 0; i < empaques.Count; i++)
                    {
                        var key = (Fecha: fecha, Cuadrilla: cuadrilla, Empaque: empaques[i]);
                        decimal val = cellData.TryGetValue(key, out decimal v) ? v : 0m;

                        if (val != 0m)
                        {
                            var cell = ws.Cell(row, StartCol + fixedCols + i);
                            ClsExcel.SetCellValue(cell, val);
                            cell.Style.Fill.SetBackgroundColor(ColorValueCell);
                            hasData = true;
                            rowTotal += val;
                        }

                        colTotals[i] += val;
                    }

                    var totalCell = ws.Cell(row, StartCol + fixedCols + empaques.Count);
                    if (rowTotal != 0m)
                    {
                        ClsExcel.SetCellValue(totalCell, rowTotal);
                        totalCell.Style.Font.SetBold();
                        totalCell.Style.Fill.SetBackgroundColor(ColorValueCell);
                    }

                    if (!hasData)
                        ws.Range(row, StartCol, row, StartCol + totalCols - 1)
                            .Style.Fill.SetBackgroundColor(ColorEmptyRow);

                    row++;
                }

                // Fila de totales del empleado
                ws.Cell(row, StartCol).Value = "TOTAL";
                ws.Cell(row, StartCol).Style.Font.SetBold();

                decimal grandTotal = 0m;
                for (int i = 0; i < empaques.Count; i++)
                {
                    var cell = ws.Cell(row, StartCol + fixedCols + i);
                    ClsExcel.SetCellValue(cell, colTotals[i]);
                    cell.Style.Font.SetBold();
                    grandTotal += colTotals[i];
                }

                var grandCell = ws.Cell(row, StartCol + fixedCols + empaques.Count);
                ClsExcel.SetCellValue(grandCell, grandTotal);
                grandCell.Style.Font.SetBold();
                grandCell.Style.Fill.SetBackgroundColor(ColorTotalRow);

                ws.Range(row, StartCol, row, StartCol + totalCols - 1)
                    .Style.Fill.SetBackgroundColor(ColorTotalRow)
                    .Border.SetOutsideBorder(XLBorderStyleValues.Medium);

                // Bordes del bloque completo (header + datos + total)
                ws.Range(headerRow, StartCol, row, StartCol + totalCols - 1).Style
                    .Border.SetOutsideBorder(XLBorderStyleValues.Medium)
                    .Border.SetInsideBorder(XLBorderStyleValues.Thin)
                    .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                // Fecha y Cuadrilla alineadas a la izquierda
                ws.Range(dataStartRow, StartCol, row, StartCol + 1)
                    .Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left);

                row += 3;
            }

            ws.Columns().AdjustToContents();
            return ws;
        }

        // ── Hoja LISTADO EMP. ─────────────────────────────────────────────────

        private void CreateListadoSheet(IXLWorkbook wb, DataTable selectedEmployees)
        {
            if (selectedEmployees == null || selectedEmployees.Rows.Count == 0)
            {
                var wsEmpty = wb.Worksheets.Add("LISTADO EMP.");
                wsEmpty.TabColor = TabColorListado;
                wsEmpty.Cell(1, 1).Value = "Sin empleados seleccionados";
                return;
            }

            var ws = wb.Worksheets.Add(selectedEmployees, "LISTADO EMP.");
            ws.TabColor = TabColorListado;
            ws.Tables.First().ShowAutoFilter = true;
            ws.Columns().AdjustToContents();
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

        private static DateTime NormalizeDate(object? value)
        {
            if (value == null || value == DBNull.Value) return DateTime.MinValue;
            if (value is DateTime dt) return dt.Date;
            return DateTime.Parse(value.ToString()!, CultureInfo.InvariantCulture).Date;
        }

        private static decimal ToDecimal(object? value)
        {
            if (value == null || value == DBNull.Value) return 0m;
            return Convert.ToDecimal(value, CultureInfo.InvariantCulture);
        }

        private static bool IsFileLocked(string path)
        {
            if (!File.Exists(path)) return false;
            try { using var s = new FileStream(path, FileMode.Open, FileAccess.ReadWrite, FileShare.None); }
            catch (IOException) { return true; }
            return false;
        }
    }
}
