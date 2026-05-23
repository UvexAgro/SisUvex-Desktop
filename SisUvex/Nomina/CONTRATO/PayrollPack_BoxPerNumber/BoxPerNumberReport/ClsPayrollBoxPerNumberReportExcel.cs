using ClosedXML.Excel;
using SisUvex.Catalogos.Metods.ExcelLoad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SisUvex.Nomina.CONTRATO.PayrollPack_BoxPerNumber.BoxPerNumberReport
{
    internal class ClsPayrollBoxPerNumberReportExcel
    {
        private readonly XLColor colorHeader = XLColor.FromHtml("#538DD5");
        private readonly XLColor colorTableHeader = XLColor.FromHtml("#8DB4E2");
        private readonly XLColor colorValueCell = XLColor.FromHtml("#c5dfb4");
        private readonly XLColor colorEmptyRow = XLColor.FromHtml("#ff7c80");
        private readonly XLColor colorGrandTotal = XLColor.FromHtml("#FFC000");

        private readonly XLColor colorTabCajas = XLColor.FromHtml("#00B050");
        private readonly XLColor colorTabCajasData = XLColor.FromHtml("#BCE292");
        private readonly XLColor colorTabBoletas = XLColor.FromHtml("#0070C0");
        private readonly XLColor colorTabBoletasData = XLColor.FromHtml("#81C9FF");

        /// <summary>Fila inicial de las tablas en la hoja de reporte (1-based).</summary>
        public int ReportSheetStartRow { get; set; } = 2;

        /// <summary>Columna inicial de la primera tabla en la hoja de reporte (1-based).</summary>
        public int ReportSheetStartCol { get; set; } = 2;

        /// <summary>Columnas vacías entre tablas de cuadrilla en la misma hoja.</summary>
        public int TablesGapColumns { get; set; } = 1;

        /// <summary>Nombre de la hoja con datos crudos de cajas.</summary>
        public string CajasDataSheetName { get; set; } = "CAJAS_DATA";

        /// <summary>Nombre de la hoja con tablas por cuadrilla (cajas).</summary>
        public string CajasReportSheetName { get; set; } = "CAJAS";

        /// <summary>Nombre de la hoja con datos crudos de boletas.</summary>
        public string BoletasDataSheetName { get; set; } = "BOLETAS_DATA";

        /// <summary>Nombre de la hoja con tablas por cuadrilla (boletas).</summary>
        public string BoletasReportSheetName { get; set; } = "BOLETAS";

        private static CultureInfo CultureEs => CultureInfo.GetCultureInfo("es-MX");

        public const string ColCuadrillaLabel = "Cuadrilla";
        public const string ColFecha = "FECHA";
        public const string ColFolio = "FOLIO";
        public const string ColTotal = "TOTAL";

        /// <summary>
        /// Vista previa en rejilla: tablas por cuadrilla apiladas verticalmente (misma lógica que Excel, legible en DGV).
        /// </summary>
        public DataTable BuildPreviewDataTable(DataTable? data, DateTime rangeStart, DateTime rangeEnd)
        {
            var preview = new DataTable();
            preview.Columns.Add(ColCuadrillaLabel, typeof(string));
            preview.Columns.Add(ColFecha, typeof(string));

            if (data == null || data.Rows.Count == 0)
                return preview;

            var cuadrillaTables = BuildCuadrillaTables(data, rangeStart, rangeEnd);
            var priceColumns = new List<string>();

            foreach (CuadrillaTableModel table in cuadrillaTables)
            {
                foreach (string precio in table.PrecioColumns)
                {
                    if (!priceColumns.Contains(precio))
                        priceColumns.Add(precio);
                }
            }

            foreach (string precio in priceColumns)
                preview.Columns.Add(precio, typeof(string));

            preview.Columns.Add(ColTotal, typeof(string));

            foreach (CuadrillaTableModel table in cuadrillaTables)
            {
                DataRow titleRow = preview.NewRow();
                titleRow[ColCuadrillaLabel] = $"Cuadrilla: {table.CuadrillaName}";
                preview.Rows.Add(titleRow);

                DataRow headerRow = preview.NewRow();
                headerRow[ColFecha] = ColFecha;
                foreach (string precio in table.PrecioColumns)
                    headerRow[precio] = precio;
                headerRow[ColTotal] = ColTotal;
                preview.Rows.Add(headerRow);

                foreach (DateTime fecha in table.Fechas)
                {
                    DataRow dataRow = preview.NewRow();
                    dataRow[ColFecha] = fecha.ToString("dd/MM/yyyy", CultureEs);

                    decimal rowTotal = 0m;
                    foreach (string precio in table.PrecioColumns)
                    {
                        decimal val = table.GetValue(fecha, precio);
                        dataRow[precio] = FormatBoxes(val);
                        rowTotal += val;
                    }

                    dataRow[ColTotal] = FormatBoxes(rowTotal);
                    preview.Rows.Add(dataRow);
                }

                DataRow totalRow = preview.NewRow();
                totalRow[ColFecha] = ColTotal;
                decimal grandTotal = 0m;

                foreach (string precio in table.PrecioColumns)
                {
                    decimal colTotal = table.GetColumnTotal(precio);
                    totalRow[precio] = FormatBoxes(colTotal);
                    grandTotal += colTotal;
                }

                totalRow[ColTotal] = FormatBoxes(grandTotal);
                preview.Rows.Add(totalRow);

                preview.Rows.Add(preview.NewRow());
            }

            return preview;
        }

        public void GenerateExcelReport(
            DataTable? cajasData,
            DataTable? boletasData,
            DateTime rangeStart,
            DateTime rangeEnd,
            string contractor,
            string workGroup,
            string dateRange)
        {
            bool hasCajas = cajasData != null && cajasData.Rows.Count > 0;
            bool hasBoletas = boletasData != null && boletasData.Rows.Count > 0;

            if (!hasCajas && !hasBoletas)
            {
                MessageBox.Show("No hay datos para generar el reporte.", "Reporte cajas por número",
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
                    "Reporte cajas por número",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            using var workbook = new XLWorkbook();

            if (hasCajas)
            {
                AddRawDataSheet(workbook, cajasData!, CajasDataSheetName, colorTabCajasData);
                CreateCajasReportWorksheet(workbook, cajasData!, rangeStart, rangeEnd, contractor, workGroup, dateRange);
            }

            if (hasBoletas)
            {
                AddRawDataSheet(workbook, boletasData!, BoletasDataSheetName, colorTabBoletasData);
                CreateBoletasReportWorksheet(workbook, boletasData!, rangeStart, rangeEnd, contractor, workGroup, dateRange);
            }

            workbook.SaveAs(filePath);

            DialogResult result = MessageBox.Show(
                "Reporte en excel generado correctamente.\n\n¿Deseas abrir el archivo?",
                "Reporte cajas por número",
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

        private static void AddRawDataSheet(XLWorkbook workbook, DataTable dataTable, string sheetName, XLColor tabColor)
        {
            var ws = workbook.Worksheets.Add(dataTable, SanitizeSheetName(sheetName));
            ws.TabColor = tabColor;
            ws.Tables.First().ShowAutoFilter = true;
            ws.Columns().AdjustToContents();
        }

        private IXLWorksheet CreateCajasReportWorksheet(
            XLWorkbook workbook,
            DataTable dataTable,
            DateTime rangeStart,
            DateTime rangeEnd,
            string contractor,
            string workGroup,
            string dateRange)
        {
            string sheetName = SanitizeSheetName(CajasReportSheetName);
            if (string.Equals(sheetName, CajasDataSheetName, StringComparison.OrdinalIgnoreCase))
                sheetName = "ReporteCajas";

            var ws = workbook.Worksheets.Add(sheetName);
            ws.TabColor = colorTabCajas;

            int infoRow = 1;
            int infoCol = ReportSheetStartCol;

            void AddInfo(string title, string value)
            {
                if (string.IsNullOrWhiteSpace(value)) return;
                ws.Cell(infoRow, infoCol).Value = title;
                ws.Cell(infoRow, infoCol).Style.Font.SetBold();
                ws.Cell(infoRow, infoCol + 1).Value = value;
                infoRow++;
            }

            AddInfo("Fechas:", dateRange);
            AddInfo("Contratista:", contractor);
            AddInfo("Cuadrilla:", workGroup);

            int tablesStartRow = infoRow < ReportSheetStartRow ? ReportSheetStartRow : infoRow + 1;
            int currentCol = ReportSheetStartCol;

            foreach (CuadrillaTableModel table in BuildCuadrillaTables(dataTable, rangeStart, rangeEnd))
            {
                int tableWidth = WriteCuadrillaTable(ws, tablesStartRow, currentCol, table);
                currentCol += tableWidth + TablesGapColumns;
            }

            ws.Columns().AdjustToContents();
            return ws;
        }

        /// <summary>
        /// Escribe una tabla de cuadrilla en la posición indicada.
        /// </summary>
        /// <returns>Ancho de la tabla en columnas.</returns>
        public int WriteCuadrillaTable(IXLWorksheet ws, int startRow, int startCol, CuadrillaTableModel table)
        {
            int colCount = table.PrecioColumns.Count + 2;
            int lastCol = startCol + colCount - 1;
            int totalCol = lastCol;

            ws.Cell(startRow, startCol - 1).Value = "Cuadrilla:";
            ws.Cell(startRow, startCol - 1).Style.Font.SetBold();
            ws.Cell(startRow, startCol).Value = table.CuadrillaName;
            ws.Cell(startRow, startCol).Style.Font.SetBold();

            int headerRow = startRow + 1;
            int col = startCol;

            ws.Cell(headerRow, col).Value = ColFecha;
            col++;

            foreach (string precio in table.PrecioColumns)
            {
                ws.Cell(headerRow, col).Value = precio;
                col++;
            }

            ws.Cell(headerRow, col).Value = ColTotal;

            int dataStartRow = headerRow + 1;
            int row = dataStartRow;

            foreach (DateTime fecha in table.Fechas)
            {
                col = startCol;
                var fechaCell = ws.Cell(row, col);
                fechaCell.Value = fecha;
                fechaCell.Style.DateFormat.Format = "dd/MM/yyyy";
                col++;

                decimal rowTotal = 0m;

                foreach (string precio in table.PrecioColumns)
                {
                    decimal val = table.GetValue(fecha, precio);
                    var cell = ws.Cell(row, col);

                    if (val != 0m)
                    {
                        ClsExcel.SetCellValue(cell, val);
                        cell.Style.Fill.SetBackgroundColor(colorValueCell);
                    }

                    rowTotal += val;
                    col++;
                }

                var totalCell = ws.Cell(row, col);
                totalCell.Style.Font.SetBold();

                if (rowTotal == 0m)
                {
                    fechaCell.Style.Fill.SetBackgroundColor(colorEmptyRow);
                    totalCell.Style.Fill.SetBackgroundColor(colorEmptyRow);
                }
                else
                {
                    ClsExcel.SetCellValue(totalCell, rowTotal);
                    totalCell.Style.Fill.SetBackgroundColor(colorValueCell);
                }

                row++;
            }

            int totalRow = row;
            col = startCol;
            ws.Cell(totalRow, col).Value = ColTotal;
            ws.Cell(totalRow, col).Style.Font.SetBold();
            col++;

            decimal grandTotal = 0m;

            foreach (string precio in table.PrecioColumns)
            {
                decimal colTotal = table.GetColumnTotal(precio);
                var cell = ws.Cell(totalRow, col);
                ClsExcel.SetCellValue(cell, colTotal);
                cell.Style.Font.SetBold();
                grandTotal += colTotal;
                col++;
            }

            var grandCell = ws.Cell(totalRow, totalCol);
            ClsExcel.SetCellValue(grandCell, grandTotal);
            grandCell.Style.Font.SetBold();
            grandCell.Style.Fill.SetBackgroundColor(colorGrandTotal);

            var headerRange = ws.Range(headerRow, startCol, headerRow, lastCol);
            headerRange.Style.Font.SetBold();
            headerRange.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            headerRange.Style.Fill.SetBackgroundColor(colorTableHeader);
            headerRange.Style.Border.OutsideBorder = XLBorderStyleValues.Medium;
            headerRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

            var tableBodyRange = ws.Range(headerRow, startCol, totalRow, lastCol);
            tableBodyRange.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

            if (totalRow > dataStartRow)
            {
                var dataRange = ws.Range(dataStartRow, startCol, totalRow, lastCol);
                dataRange.Style.Border.OutsideBorder = XLBorderStyleValues.Medium;
                dataRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
            }

            return colCount;
        }

        /// <summary>Vista previa boletas: tablas por cuadrilla apiladas verticalmente.</summary>
        public DataTable BuildBoletasPreviewDataTable(DataTable? data, DateTime rangeStart, DateTime rangeEnd)
        {
            var preview = new DataTable();
            preview.Columns.Add(ColCuadrillaLabel, typeof(string));
            preview.Columns.Add(ColFecha, typeof(string));
            preview.Columns.Add(ColFolio, typeof(string));

            if (data == null || data.Rows.Count == 0)
                return preview;

            var cuadrillaTables = BuildBoletasCuadrillaTables(data, rangeStart, rangeEnd);
            var empaqueColumns = new List<string>();

            foreach (BoletasCuadrillaTableModel table in cuadrillaTables)
            {
                foreach (string empaque in table.EmpaqueColumns)
                {
                    if (!empaqueColumns.Contains(empaque))
                        empaqueColumns.Add(empaque);
                }
            }

            foreach (string empaque in empaqueColumns)
                preview.Columns.Add(empaque, typeof(string));

            preview.Columns.Add(ColTotal, typeof(string));

            foreach (BoletasCuadrillaTableModel table in cuadrillaTables)
            {
                DataRow titleRow = preview.NewRow();
                titleRow[ColCuadrillaLabel] = $"Cuadrilla: {table.CuadrillaName}";
                preview.Rows.Add(titleRow);

                DataRow headerRow = preview.NewRow();
                headerRow[ColFecha] = ColFecha;
                headerRow[ColFolio] = ColFolio;
                foreach (string empaque in table.EmpaqueColumns)
                    headerRow[empaque] = empaque;
                headerRow[ColTotal] = ColTotal;
                preview.Rows.Add(headerRow);

                foreach (BoletaRowKey rowKey in table.Rows)
                {
                    DataRow dataRow = preview.NewRow();
                    dataRow[ColFecha] = rowKey.Fecha.ToString("dd/MM/yyyy", CultureEs);
                    dataRow[ColFolio] = rowKey.Folio;

                    decimal rowTotal = 0m;
                    foreach (string empaque in table.EmpaqueColumns)
                    {
                        decimal val = table.GetValue(rowKey, empaque);
                        dataRow[empaque] = FormatBoxes(val);
                        rowTotal += val;
                    }

                    dataRow[ColTotal] = FormatBoxes(rowTotal);
                    preview.Rows.Add(dataRow);
                }

                DataRow totalRow = preview.NewRow();
                totalRow[ColFecha] = ColTotal;
                decimal grandTotal = 0m;

                foreach (string empaque in table.EmpaqueColumns)
                {
                    decimal colTotal = table.GetColumnTotal(empaque);
                    totalRow[empaque] = FormatBoxes(colTotal);
                    grandTotal += colTotal;
                }

                totalRow[ColTotal] = FormatBoxes(grandTotal);
                preview.Rows.Add(totalRow);
                preview.Rows.Add(preview.NewRow());
            }

            return preview;
        }

        private IXLWorksheet CreateBoletasReportWorksheet(
            XLWorkbook workbook,
            DataTable dataTable,
            DateTime rangeStart,
            DateTime rangeEnd,
            string contractor,
            string workGroup,
            string dateRange)
        {
            string sheetName = SanitizeSheetName(BoletasReportSheetName);
            if (string.Equals(sheetName, BoletasDataSheetName, StringComparison.OrdinalIgnoreCase))
                sheetName = "ReporteBoletas";

            var ws = workbook.Worksheets.Add(sheetName);
            ws.TabColor = colorTabBoletas;

            int infoRow = 1;
            int infoCol = ReportSheetStartCol;

            void AddInfo(string title, string value)
            {
                if (string.IsNullOrWhiteSpace(value)) return;
                ws.Cell(infoRow, infoCol).Value = title;
                ws.Cell(infoRow, infoCol).Style.Font.SetBold();
                ws.Cell(infoRow, infoCol + 1).Value = value;
                infoRow++;
            }

            AddInfo("Fechas:", dateRange);
            AddInfo("Contratista:", contractor);
            AddInfo("Cuadrilla:", workGroup);

            int tablesStartRow = infoRow < ReportSheetStartRow ? ReportSheetStartRow : infoRow + 1;
            int currentCol = ReportSheetStartCol;

            foreach (BoletasCuadrillaTableModel table in BuildBoletasCuadrillaTables(dataTable, rangeStart, rangeEnd))
            {
                int tableWidth = WriteBoletasCuadrillaTable(ws, tablesStartRow, currentCol, table);
                currentCol += tableWidth + TablesGapColumns;
            }

            ws.Columns().AdjustToContents();
            return ws;
        }

        public int WriteBoletasCuadrillaTable(IXLWorksheet ws, int startRow, int startCol, BoletasCuadrillaTableModel table)
        {
            int colCount = table.EmpaqueColumns.Count + 3;
            int lastCol = startCol + colCount - 1;
            int totalCol = lastCol;

            ws.Cell(startRow, startCol - 1).Value = "Cuadrilla:";
            ws.Cell(startRow, startCol - 1).Style.Font.SetBold();
            ws.Cell(startRow, startCol).Value = table.CuadrillaName;
            ws.Cell(startRow, startCol).Style.Font.SetBold();

            int headerRow = startRow + 1;
            int col = startCol;

            ws.Cell(headerRow, col).Value = ColFecha;
            col++;
            ws.Cell(headerRow, col).Value = ColFolio;
            col++;

            foreach (string empaque in table.EmpaqueColumns)
            {
                ws.Cell(headerRow, col).Value = empaque;
                col++;
            }

            ws.Cell(headerRow, col).Value = ColTotal;

            int dataStartRow = headerRow + 1;
            int row = dataStartRow;

            foreach (BoletaRowKey rowKey in table.Rows)
            {
                col = startCol;
                var fechaCell = ws.Cell(row, col);
                fechaCell.Value = rowKey.Fecha;
                fechaCell.Style.DateFormat.Format = "dd/MM/yyyy";
                col++;

                var folioCell = ws.Cell(row, col);
                if (!string.IsNullOrEmpty(rowKey.Folio))
                    folioCell.Value = rowKey.Folio;
                col++;

                decimal rowTotal = 0m;

                foreach (string empaque in table.EmpaqueColumns)
                {
                    decimal val = table.GetValue(rowKey, empaque);
                    var cell = ws.Cell(row, col);

                    if (val != 0m)
                    {
                        ClsExcel.SetCellValue(cell, val);
                        cell.Style.Fill.SetBackgroundColor(colorValueCell);
                    }

                    rowTotal += val;
                    col++;
                }

                var totalCell = ws.Cell(row, col);
                totalCell.Style.Font.SetBold();

                if (rowTotal == 0m)
                {
                    fechaCell.Style.Fill.SetBackgroundColor(colorEmptyRow);
                    totalCell.Style.Fill.SetBackgroundColor(colorEmptyRow);
                }
                else
                {
                    ClsExcel.SetCellValue(totalCell, rowTotal);
                    totalCell.Style.Fill.SetBackgroundColor(colorValueCell);
                }

                row++;
            }

            int totalRow = row;
            col = startCol;
            ws.Cell(totalRow, col).Value = ColTotal;
            ws.Cell(totalRow, col).Style.Font.SetBold();
            col++;
            col++;

            decimal grandTotal = 0m;

            foreach (string empaque in table.EmpaqueColumns)
            {
                decimal colTotal = table.GetColumnTotal(empaque);
                var cell = ws.Cell(totalRow, col);
                ClsExcel.SetCellValue(cell, colTotal);
                cell.Style.Font.SetBold();
                grandTotal += colTotal;
                col++;
            }

            var grandCell = ws.Cell(totalRow, totalCol);
            ClsExcel.SetCellValue(grandCell, grandTotal);
            grandCell.Style.Font.SetBold();
            grandCell.Style.Fill.SetBackgroundColor(colorGrandTotal);

            var headerRange = ws.Range(headerRow, startCol, headerRow, lastCol);
            headerRange.Style.Font.SetBold();
            headerRange.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            headerRange.Style.Fill.SetBackgroundColor(colorTableHeader);
            headerRange.Style.Border.OutsideBorder = XLBorderStyleValues.Medium;
            headerRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

            var tableBodyRange = ws.Range(headerRow, startCol, totalRow, lastCol);
            tableBodyRange.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

            if (totalRow > dataStartRow)
            {
                var dataRange = ws.Range(dataStartRow, startCol, totalRow, lastCol);
                dataRange.Style.Border.OutsideBorder = XLBorderStyleValues.Medium;
                dataRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
            }

            return colCount;
        }

        public static List<BoletasCuadrillaTableModel> BuildBoletasCuadrillaTables(
            DataTable data,
            DateTime rangeStart,
            DateTime rangeEnd)
        {
            var tables = new List<BoletasCuadrillaTableModel>();

            if (data == null || data.Rows.Count == 0)
                return tables;

            var groups = data.Rows.Cast<DataRow>()
                .GroupBy(r => r[ClsPayrollBoxPerNumberReport.BoletasColumns.Cuadrilla]?.ToString()?.Trim() ?? string.Empty)
                .OrderBy(g => g.Key, StringComparer.OrdinalIgnoreCase);

            foreach (var g in groups)
            {
                var table = new BoletasCuadrillaTableModel(g.Key);

                var empaqueOrder = g
                    .Select(r => r[ClsPayrollBoxPerNumberReport.BoletasColumns.Empaque]?.ToString()?.Trim() ?? string.Empty)
                    .Where(name => !string.IsNullOrEmpty(name))
                    .Distinct(StringComparer.OrdinalIgnoreCase)
                    .OrderBy(name => name, StringComparer.OrdinalIgnoreCase)
                    .ToList();

                table.EmpaqueColumns.AddRange(empaqueOrder);

                foreach (DataRow row in g)
                {
                    var key = new BoletaRowKey(
                        NormalizeDate(row[ClsPayrollBoxPerNumberReport.BoletasColumns.Fecha]),
                        row[ClsPayrollBoxPerNumberReport.BoletasColumns.Folio]?.ToString()?.Trim() ?? string.Empty);
                    string empaque = row[ClsPayrollBoxPerNumberReport.BoletasColumns.Empaque]?.ToString()?.Trim() ?? string.Empty;
                    decimal cajas = ToDecimal(row[ClsPayrollBoxPerNumberReport.BoletasColumns.Cajas]);
                    table.AddValue(key, empaque, cajas);
                }

                var foliosByDate = g
                    .Select(r => new BoletaRowKey(
                        NormalizeDate(r[ClsPayrollBoxPerNumberReport.BoletasColumns.Fecha]),
                        r[ClsPayrollBoxPerNumberReport.BoletasColumns.Folio]?.ToString()?.Trim() ?? string.Empty))
                    .Where(k => k.Fecha != DateTime.MinValue && !string.IsNullOrEmpty(k.Folio))
                    .GroupBy(k => k.Fecha.Date)
                    .ToDictionary(
                        grp => grp.Key,
                        grp => grp
                            .Select(k => k.Folio)
                            .Distinct(StringComparer.OrdinalIgnoreCase)
                            .OrderBy(f => f, StringComparer.OrdinalIgnoreCase)
                            .ToList());

                foreach (DateTime fecha in EachDayInclusive(rangeStart, rangeEnd))
                {
                    if (foliosByDate.TryGetValue(fecha.Date, out List<string>? folios) && folios.Count > 0)
                    {
                        foreach (string folio in folios)
                            table.Rows.Add(new BoletaRowKey(fecha, folio));
                    }
                    else
                    {
                        table.Rows.Add(new BoletaRowKey(fecha, string.Empty));
                    }
                }

                tables.Add(table);
            }

            return tables;
        }

        public static List<CuadrillaTableModel> BuildCuadrillaTables(
            DataTable data,
            DateTime rangeStart,
            DateTime rangeEnd)
        {
            var tables = new List<CuadrillaTableModel>();

            if (data == null || data.Rows.Count == 0)
                return tables;

            var groups = data.Rows.Cast<DataRow>()
                .GroupBy(r => new
                {
                    Id = r[ClsPayrollBoxPerNumberReport.Columns.IdWorkGroup]?.ToString()?.Trim() ?? string.Empty,
                    Name = r[ClsPayrollBoxPerNumberReport.Columns.Cuadrilla]?.ToString()?.Trim() ?? string.Empty,
                })
                .OrderBy(g => g.Key.Name, StringComparer.OrdinalIgnoreCase);

            foreach (var g in groups)
            {
                var table = new CuadrillaTableModel(g.Key.Name);

                var priceOrder = g
                    .Select(r => (
                        Id: r[ClsPayrollBoxPerNumberReport.Columns.IdPrice]?.ToString()?.Trim() ?? string.Empty,
                        Name: r[ClsPayrollBoxPerNumberReport.Columns.Precio]?.ToString()?.Trim() ?? string.Empty))
                    .Where(p => !string.IsNullOrEmpty(p.Name))
                    .Distinct()
                    .OrderBy(p => p.Id, StringComparer.OrdinalIgnoreCase)
                    .ThenBy(p => p.Name, StringComparer.OrdinalIgnoreCase)
                    .Select(p => p.Name)
                    .ToList();

                table.PrecioColumns.AddRange(priceOrder);
                table.Fechas.AddRange(EachDayInclusive(rangeStart, rangeEnd));

                foreach (DataRow row in g)
                {
                    DateTime fecha = NormalizeDate(row[ClsPayrollBoxPerNumberReport.Columns.Fecha]);
                    string precio = row[ClsPayrollBoxPerNumberReport.Columns.Precio]?.ToString()?.Trim() ?? string.Empty;
                    decimal cajas = ToDecimal(row[ClsPayrollBoxPerNumberReport.Columns.Cajas]);
                    table.AddValue(fecha, precio, cajas);
                }

                tables.Add(table);
            }

            return tables;
        }

        private static IEnumerable<DateTime> EachDayInclusive(DateTime rangeStart, DateTime rangeEnd)
        {
            DateTime start = rangeStart.Date;
            DateTime end = rangeEnd.Date;

            if (start > end)
                yield break;

            for (DateTime day = start; day <= end; day = day.AddDays(1))
                yield return day;
        }

        private static DateTime NormalizeDate(object? value)
        {
            if (value == null || value == DBNull.Value)
                return DateTime.MinValue;

            if (value is DateTime dt)
                return dt.Date;

            return DateTime.Parse(value.ToString()!, CultureInfo.InvariantCulture).Date;
        }

        private static decimal ToDecimal(object? value)
        {
            if (value == null || value == DBNull.Value)
                return 0m;

            return Convert.ToDecimal(value, CultureInfo.InvariantCulture);
        }

        private static string FormatBoxes(decimal value)
            => value == 0m ? string.Empty : value.ToString("0.##", CultureEs);

        private string GetFileReportName(string dateRange)
        {
            string reportName = "Reporte cajas por número";
            if (!string.IsNullOrWhiteSpace(dateRange))
                reportName += " " + System.Text.RegularExpressions.Regex.Replace(dateRange, @"[\\\/\?\*\[\]]", "-");

            return reportName + ".xlsx";
        }

        private string? GetFolderPath(string fileReportName)
        {
            using var saveFileDialog = new SaveFileDialog
            {
                Title = "Guardar reporte de Excel",
                FileName = fileReportName,
                Filter = "Archivo de Excel (*.xlsx)|*.xlsx|Archivo de Excel 97-2003 (*.xls)|*.xls|Todos los archivos (*.*)|*.*",
                FilterIndex = 1,
                AddExtension = true,
                DefaultExt = "xlsx",
                OverwritePrompt = true,
            };

            return saveFileDialog.ShowDialog() == DialogResult.OK ? saveFileDialog.FileName : null;
        }

        private static bool IsFileLocked(string filePath)
        {
            if (!File.Exists(filePath))
                return false;

            try
            {
                using var stream = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                return true;
            }

            return false;
        }

        private static string SanitizeSheetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return "CAJAS";

            string sanitized = System.Text.RegularExpressions.Regex.Replace(name, @"[\\\/\?\*\[\]]", "-");
            if (sanitized.Length > 31)
                sanitized = sanitized[..31];

            return sanitized.Trim();
        }
    }

    /// <summary>Modelo de tabla pivote por cuadrilla (fecha × precio → cajas).</summary>
    internal sealed class CuadrillaTableModel
    {
        public string CuadrillaName { get; }
        public List<string> PrecioColumns { get; } = new();
        public List<DateTime> Fechas { get; } = new();

        private readonly Dictionary<(DateTime Fecha, string Precio), decimal> _values = new();

        public CuadrillaTableModel(string cuadrillaName)
        {
            CuadrillaName = cuadrillaName;
        }

        public void AddValue(DateTime fecha, string precio, decimal cajas)
        {
            if (fecha == DateTime.MinValue || string.IsNullOrWhiteSpace(precio))
                return;

            var key = (fecha.Date, precio);
            _values.TryGetValue(key, out decimal current);
            _values[key] = current + cajas;
        }

        public decimal GetValue(DateTime fecha, string precio)
            => _values.TryGetValue((fecha.Date, precio), out decimal val) ? val : 0m;

        public decimal GetColumnTotal(string precio)
            => Fechas.Sum(f => GetValue(f, precio));
    }

    internal readonly record struct BoletaRowKey(DateTime Fecha, string Folio);

    internal sealed class BoletasCuadrillaTableModel
    {
        public string CuadrillaName { get; }
        public List<string> EmpaqueColumns { get; } = new();
        public List<BoletaRowKey> Rows { get; } = new();

        private readonly Dictionary<(DateTime Fecha, string Folio, string Empaque), decimal> _values = new();

        public BoletasCuadrillaTableModel(string cuadrillaName)
        {
            CuadrillaName = cuadrillaName;
        }

        public void AddValue(BoletaRowKey rowKey, string empaque, decimal cajas)
        {
            if (rowKey.Fecha == DateTime.MinValue || string.IsNullOrWhiteSpace(rowKey.Folio) || string.IsNullOrWhiteSpace(empaque))
                return;

            var key = (rowKey.Fecha.Date, rowKey.Folio, empaque);
            _values.TryGetValue(key, out decimal current);
            _values[key] = current + cajas;
        }

        public decimal GetValue(BoletaRowKey rowKey, string empaque)
            => _values.TryGetValue((rowKey.Fecha.Date, rowKey.Folio, empaque), out decimal val) ? val : 0m;

        public decimal GetColumnTotal(string empaque)
            => Rows.Sum(r => GetValue(r, empaque));
    }
}
