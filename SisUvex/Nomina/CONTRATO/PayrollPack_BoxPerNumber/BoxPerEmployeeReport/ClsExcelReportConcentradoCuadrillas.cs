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
    /// Reporte: Concentrado de cuadrillas.
    /// Misma lógica que "Cajas por Cuadrilla", pero en una sola tabla.
    /// Columnas fijas: CONTRATISTA, CUADRILLA, No., Código, Nombre, LP + Fecha/Empaque.
    /// </summary>
    internal sealed class ClsExcelReportConcentradoCuadrillas
    {
        public const string SheetName = "Concentrado de cuadrillas";
        private static readonly XLColor TabColor = XLColor.FromHtml("#548235"); // verde olivo

        private const int StartCol  = 2;
        private const int FixedCols = 6; // CONTRATISTA | CUADRILLA | No. | Código | Nombre | LP

        public IXLWorksheet WriteSheet(
            IXLWorkbook workbook,
            DataTable data,
            DateTime rangeStart,
            DateTime rangeEnd,
            string filtersText)
        {
            var ws = workbook.Worksheets.Add(GetUniqueSheetName(workbook, SheetName));
            ws.TabColor = TabColor;

            var groups  = BuildGroups(data);
            var colKeys = ClsPayrollBoxPerEmployeeReportExcel.BuildDateEmpaqueColumns(data, rangeStart, rangeEnd);
            int totalCols = FixedCols + colKeys.Count;

            int row = 1;
            row = WriteFiltersHeader(ws, row, filtersText, totalCols);
            row = WriteSingleTable(ws, row, groups, colKeys, totalCols);

            ws.Columns().AdjustToContents();
            return ws;
        }

        private static string GetUniqueSheetName(IXLWorkbook workbook, string desiredName)
        {
            string baseName = ClsPayrollBoxPerEmployeeReportExcel.SanitizeSheetName(desiredName);
            string name = baseName;
            int suffix = 2;

            while (workbook.Worksheets.Any(ws => string.Equals(ws.Name, name, StringComparison.OrdinalIgnoreCase)))
            {
                string suffixText = $" ({suffix++})";
                int maxBaseLen = Math.Max(1, 31 - suffixText.Length);
                name = baseName.Length > maxBaseLen
                    ? baseName[..maxBaseLen] + suffixText
                    : baseName + suffixText;
            }

            return name;
        }

        private static int WriteFiltersHeader(IXLWorksheet ws, int row, string filtersText, int totalCols)
        {
            if (!string.IsNullOrWhiteSpace(filtersText))
            {
                ws.Cell(row, StartCol).Value = filtersText;
                ws.Range(row, StartCol, row, StartCol + totalCols - 1).Merge();
                var style = ws.Cell(row, StartCol).Style;
                style.Font.SetBold();
                style.Fill.SetBackgroundColor(ClsPayrollBoxPerEmployeeReportExcel.ColorHeader);
                style.Font.FontColor = XLColor.White;
                style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left);
                row += 2;
            }
            else
            {
                row += 1;
            }

            return row;
        }

        private static int WriteSingleTable(
            IXLWorksheet ws,
            int row,
            List<GroupTableModelCuadrilla> groups,
            List<DateEmpaqueColumnKey> colKeys,
            int totalCols)
        {
            int headerRowDate    = row;
            int headerRowEmpaque = row + 1;

            string[] fixedHeaders = { "CONTRATISTA", "CUADRILLA", "No.", "Código", "Nombre", "LP" };
            for (int i = 0; i < FixedCols; i++)
            {
                ws.Cell(headerRowDate, StartCol + i).Value = fixedHeaders[i];
                ws.Range(headerRowDate, StartCol + i, headerRowEmpaque, StartCol + i).Merge();
            }

            ws.Range(headerRowDate, StartCol, headerRowEmpaque, StartCol + FixedCols - 1).Style
                .Font.SetBold()
                .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                .Fill.SetBackgroundColor(ClsPayrollBoxPerEmployeeReportExcel.ColorTableHeader);

            int col = StartCol + FixedCols;
            foreach (var c in colKeys)
            {
                ws.Cell(headerRowDate, col).Value = c.Fecha;
                ws.Cell(headerRowDate, col).Style.DateFormat.Format = "dd-MMM";
                ws.Cell(headerRowEmpaque, col).Value = c.EmpaqueDisplay;
                col++;
            }

            if (colKeys.Count > 0)
            {
                ws.Range(headerRowDate, StartCol + FixedCols, headerRowEmpaque, StartCol + totalCols - 1).Style
                    .Font.SetBold()
                    .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                    .Fill.SetBackgroundColor(ClsPayrollBoxPerEmployeeReportExcel.ColorTableHeader)
                    .Border.SetOutsideBorder(XLBorderStyleValues.Medium)
                    .Border.SetInsideBorder(XLBorderStyleValues.Thin);
            }

            row = headerRowEmpaque + 1;

            foreach (var group in groups)
            {
                foreach (var emp in group.Employees)
                {
                    ws.Cell(row, StartCol).Value     = group.Key.Contratista;
                    ws.Cell(row, StartCol + 1).Value = group.Key.Cuadrilla;
                    ws.Cell(row, StartCol + 2).Value = emp.Numero;
                    ws.Cell(row, StartCol + 3).Value = emp.Codigo;
                    ws.Cell(row, StartCol + 4).Value = emp.Nombre;
                    ws.Cell(row, StartCol + 5).Value = emp.Lp;

                    decimal rowTotal = 0m;
                    col = StartCol + FixedCols;
                    foreach (var c in colKeys)
                    {
                        decimal val = group.GetValue(emp.Codigo, c);
                        if (val != 0m)
                        {
                            var cell = ws.Cell(row, col);
                            ClsExcel.SetCellValue(cell, val);
                            cell.Style.Fill.SetBackgroundColor(ClsPayrollBoxPerEmployeeReportExcel.ColorValueCell);
                            rowTotal += val;
                        }

                        col++;
                    }

                    if (rowTotal == 0m)
                        ws.Range(row, StartCol, row, StartCol + totalCols - 1)
                            .Style.Fill.SetBackgroundColor(ClsPayrollBoxPerEmployeeReportExcel.ColorEmptyRow);

                    row++;
                }
            }

            ws.Range(headerRowDate, StartCol, row - 1, StartCol + totalCols - 1).Style
                .Border.SetOutsideBorder(XLBorderStyleValues.Medium)
                .Border.SetInsideBorder(XLBorderStyleValues.Thin)
                .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

            ws.Column(StartCol + 4).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left);

            return row;
        }

        private static List<GroupTableModelCuadrilla> BuildGroups(DataTable data)
        {
            var grouped = data.Rows.Cast<DataRow>()
                .GroupBy(r => new GroupKeyCuadrilla(
                    ClsPayrollBoxPerEmployeeReportExcel.SafeStr(r, ClsPayrollBoxPerEmployeeReport.Columns.Contratista),
                    ClsPayrollBoxPerEmployeeReportExcel.SafeStr(r, ClsPayrollBoxPerEmployeeReport.Columns.Cuadrilla)
                ))
                .OrderBy(g => g.Key.Contratista, StringComparer.OrdinalIgnoreCase)
                .ThenBy(g => g.Key.Cuadrilla, StringComparer.OrdinalIgnoreCase);

            var result = new List<GroupTableModelCuadrilla>();
            foreach (var g in grouped)
                result.Add(new GroupTableModelCuadrilla(g.Key, g.ToList()));

            return result;
        }
    }
}
