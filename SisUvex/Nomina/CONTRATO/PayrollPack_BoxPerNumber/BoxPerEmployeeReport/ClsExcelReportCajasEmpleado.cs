using ClosedXML.Excel;
using SisUvex.Catalogos.Metods.ExcelLoad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SisUvex.Nomina.CONTRATO.PayrollPack_BoxPerNumber.BoxPerEmployeeReport
{
    /// <summary>
    /// Reporte: Cajas por empleado (resumen simplificado).
    /// Una sola tabla con una fila por empleado (CODIGO + NOMBRE).
    /// Columnas dinámicas: una por tipo de empaque.
    /// Columna DÍAS: días distintos con registros del empleado.
    /// Columna TOTAL: suma de todas las cajas del empleado.
    /// Sin columnas de Contratista, Cuadrilla ni Número.
    /// </summary>
    internal sealed class ClsExcelReportCajasEmpleado
    {
        public const string SheetName = "Cajas empleado";
        private static readonly XLColor TabColor = XLColor.FromHtml("#BDD7EE"); // azul bajito

        private const int StartCol  = 1;
        private const int FixedCols = 2; // CODIGO | NOMBRE
        // Luego siguen los empaques, luego DÍAS y TOTAL

        // ── Estilos ──────────────────────────────────────────────────────────
        private static readonly XLColor ColorFilters    = XLColor.FromHtml("#538DD5");
        private static readonly XLColor ColorHeaderRow  = XLColor.FromHtml("#1F3864");
        private static readonly XLColor ColorHeaderFont = XLColor.White;
        private static readonly XLColor ColorOddRow     = XLColor.FromHtml("#FFFFFF");
        private static readonly XLColor ColorEvenRow    = XLColor.FromHtml("#E8F0F7");
        private static readonly XLColor ColorValueCell  = XLColor.FromHtml("#C5DFB4");
        private static readonly XLColor ColorDiasCell   = XLColor.FromHtml("#8DB4E2");
        private static readonly XLColor ColorTotalRow   = XLColor.FromHtml("#FFC000");

        // ── Punto de entrada ─────────────────────────────────────────────────

        public IXLWorksheet WriteSheet(
            IXLWorkbook workbook,
            DataTable data,
            string filtersText)
        {
            var ws = workbook.Worksheets.Add(
                ClsPayrollBoxPerEmployeeReportExcel.SanitizeSheetName(SheetName));
            ws.TabColor = TabColor;

            // Empaques únicos ordenados
            var empaques = data.AsEnumerable()
                .Select(r => ClsPayrollBoxPerEmployeeReportExcel.SafeStr(r, ClsPayrollBoxPerEmployeeReport.Columns.Empaque))
                .Where(e => !string.IsNullOrWhiteSpace(e))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .OrderBy(e => e, StringComparer.OrdinalIgnoreCase)
                .ToList();

            int totalCols = FixedCols + empaques.Count + 2; // +2 = DÍAS + TOTAL

            // ── Fila 1: Filtros ──────────────────────────────────────────────
            ws.Cell(1, StartCol).Value = filtersText;
            var filterRange = ws.Range(1, StartCol, 1, StartCol + totalCols - 1);
            filterRange.Merge();
            filterRange.Style
                .Font.SetBold()
                .Font.SetFontColor(XLColor.White)
                .Fill.SetBackgroundColor(ColorFilters)
                .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left);

            // ── Fila 3: Encabezados ──────────────────────────────────────────
            WriteHeaders(ws, 3, empaques, totalCols);

            // ── Filas de datos (desde fila 4) ────────────────────────────────
            var rows = BuildRows(data, empaques);
            int excelRow = 4;

            foreach (var row in rows)
            {
                bool isEven = (excelRow % 2 == 0);
                XLColor rowBg = isEven ? ColorEvenRow : ColorOddRow;

                ws.Cell(excelRow, StartCol).Value     = row.Codigo;
                ws.Cell(excelRow, StartCol + 1).Value = row.Nombre;

                ws.Range(excelRow, StartCol, excelRow, StartCol + FixedCols - 1)
                    .Style.Fill.SetBackgroundColor(rowBg);

                // Columnas de empaque
                for (int i = 0; i < empaques.Count; i++)
                {
                    decimal val = row.CajasPorEmpaque.TryGetValue(empaques[i], out decimal v) ? v : 0m;
                    var cell = ws.Cell(excelRow, StartCol + FixedCols + i);
                    if (val > 0)
                    {
                        ClsExcel.SetCellValue(cell, val);
                        cell.Style.Fill.SetBackgroundColor(ColorValueCell);
                    }
                    else
                    {
                        cell.Style.Fill.SetBackgroundColor(rowBg);
                    }
                }

                // DÍAS
                var diasCell = ws.Cell(excelRow, StartCol + FixedCols + empaques.Count);
                if (row.Dias > 0)
                {
                    diasCell.Value = row.Dias;
                    diasCell.Style.Fill.SetBackgroundColor(ColorDiasCell);
                }
                else
                {
                    diasCell.Style.Fill.SetBackgroundColor(rowBg);
                }

                // TOTAL
                var totalCell = ws.Cell(excelRow, StartCol + FixedCols + empaques.Count + 1);
                ClsExcel.SetCellValue(totalCell, row.TotalCajas);
                totalCell.Style.Font.SetBold();
                totalCell.Style.Fill.SetBackgroundColor(ColorTotalRow);

                // Bordes de toda la fila
                ws.Range(excelRow, StartCol, excelRow, StartCol + totalCols - 1).Style
                    .Border.SetInsideBorder(XLBorderStyleValues.Thin)
                    .Border.SetOutsideBorder(XLBorderStyleValues.Thin);

                excelRow++;
            }

            // ── Fila de totales generales ────────────────────────────────────
            WriteTotalsRow(ws, excelRow, empaques, rows, totalCols);

            ws.Columns().AdjustToContents();
            return ws;
        }

        // ── Encabezados ───────────────────────────────────────────────────────

        private static void WriteHeaders(IXLWorksheet ws, int headerRow, List<string> empaques, int totalCols)
        {
            ws.Cell(headerRow, StartCol).Value     = "CÓDIGO";
            ws.Cell(headerRow, StartCol + 1).Value = "NOMBRE";

            for (int i = 0; i < empaques.Count; i++)
                ws.Cell(headerRow, StartCol + FixedCols + i).Value = empaques[i];

            ws.Cell(headerRow, StartCol + FixedCols + empaques.Count).Value     = "DÍAS";
            ws.Cell(headerRow, StartCol + FixedCols + empaques.Count + 1).Value = "TOTAL";

            ws.Range(headerRow, StartCol, headerRow, StartCol + totalCols - 1).Style
                .Font.SetBold()
                .Font.SetFontColor(ColorHeaderFont)
                .Fill.SetBackgroundColor(ColorHeaderRow)
                .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                .Border.SetOutsideBorder(XLBorderStyleValues.Medium)
                .Border.SetInsideBorder(XLBorderStyleValues.Thin);
        }

        // ── Fila de totales generales ─────────────────────────────────────────

        private static void WriteTotalsRow(
            IXLWorksheet ws, int row,
            List<string> empaques,
            IReadOnlyList<EmployeeRow> rows,
            int totalCols)
        {
            ws.Cell(row, StartCol).Value = "TOTAL GENERAL";

            for (int i = 0; i < empaques.Count; i++)
            {
                decimal colSum = rows.Sum(r =>
                    r.CajasPorEmpaque.TryGetValue(empaques[i], out decimal v) ? v : 0m);
                var cell = ws.Cell(row, StartCol + FixedCols + i);
                ClsExcel.SetCellValue(cell, colSum);
            }

            decimal diasSum  = rows.Sum(r => r.Dias);
            decimal totalSum = rows.Sum(r => r.TotalCajas);

            ClsExcel.SetCellValue(ws.Cell(row, StartCol + FixedCols + empaques.Count),     diasSum);
            ClsExcel.SetCellValue(ws.Cell(row, StartCol + FixedCols + empaques.Count + 1), totalSum);

            ws.Range(row, StartCol, row, StartCol + totalCols - 1).Style
                .Font.SetBold()
                .Fill.SetBackgroundColor(ColorTotalRow)
                .Border.SetOutsideBorder(XLBorderStyleValues.Medium)
                .Border.SetInsideBorder(XLBorderStyleValues.Thin);
        }

        // ── Construcción de filas ─────────────────────────────────────────────

        private static List<EmployeeRow> BuildRows(DataTable data, List<string> empaques)
        {
            var groups = data.AsEnumerable()
                .GroupBy(r => (
                    Codigo: ClsPayrollBoxPerEmployeeReportExcel.SafeStr(r, ClsPayrollBoxPerEmployeeReport.Columns.Codigo),
                    Nombre: ClsPayrollBoxPerEmployeeReportExcel.SafeStr(r, ClsPayrollBoxPerEmployeeReport.Columns.Nombre)))
                .OrderBy(g => g.Key.Nombre, StringComparer.OrdinalIgnoreCase)
                .ThenBy(g => g.Key.Codigo,  StringComparer.OrdinalIgnoreCase);

            var result = new List<EmployeeRow>();

            foreach (var g in groups)
            {
                var cajasPorEmpaque = g
                    .GroupBy(r => ClsPayrollBoxPerEmployeeReportExcel.SafeStr(r, ClsPayrollBoxPerEmployeeReport.Columns.Empaque))
                    .Where(eg => !string.IsNullOrWhiteSpace(eg.Key))
                    .ToDictionary(
                        eg => eg.Key,
                        eg => eg.Sum(r => ClsPayrollBoxPerEmployeeReportExcel.ToDecimal(r[ClsPayrollBoxPerEmployeeReport.Columns.Cajas])),
                        StringComparer.OrdinalIgnoreCase);

                int dias = g
                    .Select(r => ClsPayrollBoxPerEmployeeReportExcel.NormalizeDate(r[ClsPayrollBoxPerEmployeeReport.Columns.Fecha]))
                    .Where(d => d != DateTime.MinValue)
                    .Distinct()
                    .Count();

                decimal totalCajas = cajasPorEmpaque.Values.Sum();

                result.Add(new EmployeeRow(
                    Codigo:          g.Key.Codigo,
                    Nombre:          g.Key.Nombre,
                    CajasPorEmpaque: cajasPorEmpaque,
                    Dias:            dias,
                    TotalCajas:      totalCajas));
            }

            return result;
        }

        // ── Modelo de fila ────────────────────────────────────────────────────

        private sealed record EmployeeRow(
            string Codigo,
            string Nombre,
            Dictionary<string, decimal> CajasPorEmpaque,
            int Dias,
            decimal TotalCajas);
    }
}
