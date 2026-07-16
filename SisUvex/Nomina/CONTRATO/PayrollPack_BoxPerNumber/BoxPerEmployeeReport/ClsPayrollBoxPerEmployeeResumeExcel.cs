using ClosedXML.Excel;
using SisUvex.Catalogos.Metods.ExcelLoad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;

namespace SisUvex.Nomina.CONTRATO.PayrollPack_BoxPerNumber.BoxPerEmployeeReport
{
    /// <summary>
    /// Reporte: Resumen de cajas por empleado.
    /// Una sola tabla con una fila por (Empleado + Cuadrilla + Contratista).
    /// Columnas fijas: CONTRATISTA, CUADRILLA, NUMERO, CODIGO, NOMBRE.
    /// Columnas dinámicas: una por cada tipo de empaque distinto.
    /// Columna DIAS: días distintos trabajados por esa combinación.
    /// Columna TOTAL: suma de todas las cajas de la fila.
    /// </summary>
    internal sealed class ClsPayrollBoxPerEmployeeResumeExcel
    {
        public const string SheetName = "RESUMEN";
        private static readonly XLColor TabColor = XLColor.FromHtml("#7030A0"); // morado

        private const int StartCol   = 1;  // Columna A
        private const int FixedCols  = 5;  // CONTRATISTA | CUADRILLA | NUMERO | CODIGO | NOMBRE
        // Luego siguen los empaques, luego DIAS y TOTAL

        // ── Estilos ──────────────────────────────────────────────────────────
        private static readonly XLColor ColorFilters     = XLColor.FromHtml("#538DD5");
        private static readonly XLColor ColorHeaderRow   = XLColor.FromHtml("#1F3864");
        private static readonly XLColor ColorHeaderFont  = XLColor.White;
        private static readonly XLColor ColorOddRow      = XLColor.FromHtml("#FFFFFF");
        private static readonly XLColor ColorEvenRow     = XLColor.FromHtml("#E8F0F7");
        private static readonly XLColor ColorTotalRow    = XLColor.FromHtml("#FFC000");
        private static readonly XLColor ColorValueCell   = XLColor.FromHtml("#C5DFB4");
        private static readonly XLColor ColorDiasCell    = XLColor.FromHtml("#8DB4E2");

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

            int totalCols = FixedCols + empaques.Count + 2; // +2 = DIAS + TOTAL

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
            var rows = BuildSummaryRows(data, empaques);
            int excelRow = 4;

            foreach (var summaryRow in rows)
            {
                bool isEven = (excelRow % 2 == 0);
                XLColor rowBg = isEven ? ColorEvenRow : ColorOddRow;

                ws.Cell(excelRow, StartCol).Value         = summaryRow.Contratista;
                ws.Cell(excelRow, StartCol + 1).Value     = summaryRow.Cuadrilla;
                ws.Cell(excelRow, StartCol + 2).Value     = summaryRow.Numero;
                ws.Cell(excelRow, StartCol + 3).Value     = summaryRow.Codigo;
                ws.Cell(excelRow, StartCol + 4).Value     = summaryRow.Nombre;

                // Columnas de empaque
                for (int i = 0; i < empaques.Count; i++)
                {
                    decimal val = summaryRow.CajasPorEmpaque.TryGetValue(empaques[i], out decimal v) ? v : 0m;
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

                // DIAS
                var diasCell = ws.Cell(excelRow, StartCol + FixedCols + empaques.Count);
                if (summaryRow.Dias > 0)
                {
                    diasCell.Value = summaryRow.Dias;
                    diasCell.Style.Fill.SetBackgroundColor(ColorDiasCell);
                }
                else
                {
                    diasCell.Style.Fill.SetBackgroundColor(rowBg);
                }

                // TOTAL
                var totalCell = ws.Cell(excelRow, StartCol + FixedCols + empaques.Count + 1);
                ClsExcel.SetCellValue(totalCell, summaryRow.TotalCajas);
                totalCell.Style.Font.SetBold();
                totalCell.Style.Fill.SetBackgroundColor(ColorTotalRow);

                // Fondo de las columnas fijas
                ws.Range(excelRow, StartCol, excelRow, StartCol + FixedCols - 1)
                    .Style.Fill.SetBackgroundColor(rowBg);

                // Bordes de toda la fila
                ws.Range(excelRow, StartCol, excelRow, StartCol + totalCols - 1).Style
                    .Border.SetInsideBorder(XLBorderStyleValues.Thin)
                    .Border.SetOutsideBorder(XLBorderStyleValues.Thin);

                excelRow++;
            }

            // ── Fila de totales generales ────────────────────────────────────
            WriteTotalsRow(ws, excelRow, empaques, rows, totalCols);

            // ── Ajuste de anchos ─────────────────────────────────────────────
            ws.Columns().AdjustToContents();

            return ws;
        }

        // ── Encabezados (fila 3) ──────────────────────────────────────────────

        private static void WriteHeaders(IXLWorksheet ws, int headerRow, List<string> empaques, int totalCols)
        {
            string[] fixedHeaders = { "CONTRATISTA", "CUADRILLA", "NÚMERO", "CÓDIGO", "NOMBRE" };
            for (int i = 0; i < FixedCols; i++)
                ws.Cell(headerRow, StartCol + i).Value = fixedHeaders[i];

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
            IReadOnlyList<SummaryRow> rows,
            int totalCols)
        {
            ws.Cell(row, StartCol).Value = "TOTAL GENERAL";
            ws.Cell(row, StartCol).Style.Font.SetBold();

            for (int i = 0; i < empaques.Count; i++)
            {
                decimal colSum = rows.Sum(r =>
                    r.CajasPorEmpaque.TryGetValue(empaques[i], out decimal v) ? v : 0m);
                var cell = ws.Cell(row, StartCol + FixedCols + i);
                ClsExcel.SetCellValue(cell, colSum);
                cell.Style.Font.SetBold();
            }

            decimal diasSum  = rows.Sum(r => r.Dias);
            decimal totalSum = rows.Sum(r => r.TotalCajas);

            var diasCell  = ws.Cell(row, StartCol + FixedCols + empaques.Count);
            var totalCell = ws.Cell(row, StartCol + FixedCols + empaques.Count + 1);
            ClsExcel.SetCellValue(diasCell,  diasSum);
            ClsExcel.SetCellValue(totalCell, totalSum);

            ws.Range(row, StartCol, row, StartCol + totalCols - 1).Style
                .Font.SetBold()
                .Fill.SetBackgroundColor(ColorTotalRow)
                .Border.SetOutsideBorder(XLBorderStyleValues.Medium)
                .Border.SetInsideBorder(XLBorderStyleValues.Thin);
        }

        // ── Construcción de filas del resumen ─────────────────────────────────

        private static List<SummaryRow> BuildSummaryRows(DataTable data, List<string> empaques)
        {
            // Agrupar por (CONTRATISTA, CUADRILLA, CODIGO, NOMBRE)
            var groups = data.AsEnumerable()
                .GroupBy(r => (
                    Contratista: ClsPayrollBoxPerEmployeeReportExcel.SafeStr(r, ClsPayrollBoxPerEmployeeReport.Columns.Contratista),
                    Cuadrilla:   ClsPayrollBoxPerEmployeeReportExcel.SafeStr(r, ClsPayrollBoxPerEmployeeReport.Columns.Cuadrilla),
                    Codigo:      ClsPayrollBoxPerEmployeeReportExcel.SafeStr(r, ClsPayrollBoxPerEmployeeReport.Columns.Codigo),
                    Nombre:      ClsPayrollBoxPerEmployeeReportExcel.SafeStr(r, ClsPayrollBoxPerEmployeeReport.Columns.Nombre)))
                .OrderBy(g => g.Key.Contratista, StringComparer.OrdinalIgnoreCase)
                .ThenBy(g => g.Key.Cuadrilla,    StringComparer.OrdinalIgnoreCase)
                .ThenBy(g => g.Key.Nombre,        StringComparer.OrdinalIgnoreCase)
                .ThenBy(g => g.Key.Codigo,        StringComparer.OrdinalIgnoreCase);

            var result = new List<SummaryRow>();

            foreach (var g in groups)
            {
                // NUMERO: el registrado en el último día con datos
                string numero = ResolveNumero(g);

                // Suma de cajas por empaque
                var cajasPorEmpaque = g
                    .GroupBy(r => ClsPayrollBoxPerEmployeeReportExcel.SafeStr(r, ClsPayrollBoxPerEmployeeReport.Columns.Empaque))
                    .Where(eg => !string.IsNullOrWhiteSpace(eg.Key))
                    .ToDictionary(
                        eg => eg.Key,
                        eg => eg.Sum(r => ClsPayrollBoxPerEmployeeReportExcel.ToDecimal(r[ClsPayrollBoxPerEmployeeReport.Columns.Cajas])),
                        StringComparer.OrdinalIgnoreCase);

                // DIAS: cantidad de fechas distintas con registros
                int dias = g
                    .Select(r => ClsPayrollBoxPerEmployeeReportExcel.NormalizeDate(r[ClsPayrollBoxPerEmployeeReport.Columns.Fecha]))
                    .Where(d => d != DateTime.MinValue)
                    .Distinct()
                    .Count();

                decimal totalCajas = cajasPorEmpaque.Values.Sum();

                result.Add(new SummaryRow(
                    Contratista:     g.Key.Contratista,
                    Cuadrilla:       g.Key.Cuadrilla,
                    Numero:          numero,
                    Codigo:          g.Key.Codigo,
                    Nombre:          g.Key.Nombre,
                    CajasPorEmpaque: cajasPorEmpaque,
                    Dias:            dias,
                    TotalCajas:      totalCajas));
            }

            return result;
        }

        /// <summary>
        /// Resuelve el NUMERO del empleado tomando el del último día con registros.
        /// Si en ese día hay varios números distintos, toma el del primer registro.
        /// </summary>
        private static string ResolveNumero(IGrouping<(string, string, string, string), DataRow> g)
        {
            // Obtener la fecha más reciente del grupo
            DateTime lastDate = g
                .Select(r => ClsPayrollBoxPerEmployeeReportExcel.NormalizeDate(r[ClsPayrollBoxPerEmployeeReport.Columns.Fecha]))
                .Where(d => d != DateTime.MinValue)
                .DefaultIfEmpty(DateTime.MinValue)
                .Max();

            if (lastDate == DateTime.MinValue)
                return string.Empty;

            // Filas del último día
            var lastDayRows = g
                .Where(r => ClsPayrollBoxPerEmployeeReportExcel.NormalizeDate(r[ClsPayrollBoxPerEmployeeReport.Columns.Fecha]) == lastDate)
                .ToList();

            // ¿Hay un único número en ese día?
            var numeros = lastDayRows
                .Select(r => ClsPayrollBoxPerEmployeeReportExcel.SafeStr(r, ClsPayrollBoxPerEmployeeReport.Columns.Numero))
                .Where(n => !string.IsNullOrWhiteSpace(n))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();

            if (numeros.Count == 1)
                return numeros[0];

            // Si hay varios en el último día, retroceder día a día hasta encontrar uno único
            var allDates = g
                .Select(r => ClsPayrollBoxPerEmployeeReportExcel.NormalizeDate(r[ClsPayrollBoxPerEmployeeReport.Columns.Fecha]))
                .Where(d => d != DateTime.MinValue && d < lastDate)
                .Distinct()
                .OrderByDescending(d => d);

            foreach (var day in allDates)
            {
                var dayNums = g
                    .Where(r => ClsPayrollBoxPerEmployeeReportExcel.NormalizeDate(r[ClsPayrollBoxPerEmployeeReport.Columns.Fecha]) == day)
                    .Select(r => ClsPayrollBoxPerEmployeeReportExcel.SafeStr(r, ClsPayrollBoxPerEmployeeReport.Columns.Numero))
                    .Where(n => !string.IsNullOrWhiteSpace(n))
                    .Distinct(StringComparer.OrdinalIgnoreCase)
                    .ToList();

                if (dayNums.Count == 1)
                    return dayNums[0];
            }

            // Fallback: primer número disponible del día más reciente
            return numeros.FirstOrDefault() ?? string.Empty;
        }

        // ── Modelo de fila ────────────────────────────────────────────────────

        private sealed record SummaryRow(
            string Contratista,
            string Cuadrilla,
            string Numero,
            string Codigo,
            string Nombre,
            Dictionary<string, decimal> CajasPorEmpaque,
            int Dias,
            decimal TotalCajas);
    }

    // ── Helper mínimo para SetCellValue en este contexto ─────────────────────
    // (usa el helper ya existente en el namespace)
}
