using ClosedXML.Excel;
using SisUvex.Catalogos.Metods.ExcelLoad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SisUvex.Nomina.CONTRATO.PayrollPack_BoxPerNumber.BoxPerEmployeeReport
{
    internal class ClsPayrollBoxPerEmployeeReportExcel
    {
        private readonly XLColor colorHeader = XLColor.FromHtml("#538DD5");
        private readonly XLColor colorTableHeader = XLColor.FromHtml("#8DB4E2");
        private readonly XLColor colorValueCell = XLColor.FromHtml("#c5dfb4");
        private readonly XLColor colorGroupHeader = XLColor.FromHtml("#D9E1F2");
        private readonly XLColor colorEmptyRow = XLColor.FromHtml("#ff7c80");

        private readonly XLColor colorTabReport = XLColor.FromHtml("#00B050");
        private readonly XLColor colorTabData = XLColor.FromHtml("#BCE292");

        public string DataSheetName { get; set; } = "DATA";
        public string ReportSheetName { get; set; } = "REPORTE";

        private static CultureInfo CultureEs => CultureInfo.GetCultureInfo("es-MX");

        public const string ColNumero = "NUMERO";
        public const string ColCodigo = "CODIGO";
        public const string ColNombre = "NOMBRE";
        public const string ColLp = "LP";

        public DataTable BuildPreviewDataTable(DataTable? data, DateTime rangeStart, DateTime rangeEnd)
        {
            var preview = new DataTable();
            preview.Columns.Add(ColNumero, typeof(string));
            preview.Columns.Add(ColCodigo, typeof(string));
            preview.Columns.Add(ColNombre, typeof(string));
            preview.Columns.Add(ColLp, typeof(string));

            if (data == null || data.Rows.Count == 0)
                return preview;

            var colKeys = BuildDateEmpaqueColumns(data, rangeStart, rangeEnd);
            foreach (var col in colKeys)
                preview.Columns.Add(col.Display, typeof(string));

            foreach (var group in BuildGroups(data))
            {
                DataRow groupRow = preview.NewRow();
                groupRow[ColNombre] = $"CONTRATISTA: {group.Key.Contratista} | CUADRILLA: {group.Key.Cuadrilla} | ANOTADOR: {group.Key.Anotador}";
                preview.Rows.Add(groupRow);

                foreach (var emp in group.Employees)
                {
                    DataRow r = preview.NewRow();
                    r[ColNumero] = emp.Numero;
                    r[ColCodigo] = emp.Codigo;
                    r[ColNombre] = emp.Nombre;
                    r[ColLp] = emp.Lp;

                    foreach (var col in colKeys)
                    {
                        decimal val = group.GetValue(emp, col);
                        r[col.Display] = FormatBoxes(val);
                    }

                    preview.Rows.Add(r);
                }

                preview.Rows.Add(preview.NewRow());
            }

            return preview;
        }

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

            using var workbook = new XLWorkbook();
            AddRawDataSheet(workbook, reportData, DataSheetName, colorTabData);
            CreateReportWorksheet(workbook, reportData, rangeStart, rangeEnd, season, contractor, workGroup, user, dateRange);
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

        private static void AddRawDataSheet(XLWorkbook workbook, DataTable dataTable, string sheetName, XLColor tabColor)
        {
            var ws = workbook.Worksheets.Add(dataTable, SanitizeSheetName(sheetName));
            ws.TabColor = tabColor;
            ws.Tables.First().ShowAutoFilter = true;
            ws.Columns().AdjustToContents();
        }

        private IXLWorksheet CreateReportWorksheet(
            XLWorkbook workbook,
            DataTable data,
            DateTime rangeStart,
            DateTime rangeEnd,
            string season,
            string contractor,
            string workGroup,
            string user,
            string dateRange)
        {
            string sheetName = SanitizeSheetName(ReportSheetName);
            if (string.Equals(sheetName, DataSheetName, StringComparison.OrdinalIgnoreCase))
                sheetName = "Reporte";

            var ws = workbook.Worksheets.Add(sheetName);
            ws.TabColor = colorTabReport;

            var groups = BuildGroups(data);
            var colKeys = BuildDateEmpaqueColumns(data, rangeStart, rangeEnd);
            int fixedCols = 4;
            int totalCols = fixedCols + colKeys.Count;

            int row = 1;
            int startCol = 2;

            string filtersText = BuildFiltersText(season, contractor, workGroup, user, dateRange);
            if (!string.IsNullOrWhiteSpace(filtersText))
            {
                ws.Cell(row, startCol).Value = filtersText;
                ws.Range(row, startCol, row, startCol + totalCols - 1).Merge();
                ws.Cell(row, startCol).Style.Font.SetBold();
                ws.Cell(row, startCol).Style.Fill.SetBackgroundColor(colorHeader);
                ws.Cell(row, startCol).Style.Font.FontColor = XLColor.White;
                ws.Cell(row, startCol).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left);
                row += 2;
            }
            else
            {
                row += 1;
            }

            foreach (var g in groups)
            {
                // Encabezado de grupo (Contratista / Cuadrilla / Anotador)
                string groupTitle = $"{g.Key.Contratista} - {g.Key.Cuadrilla} ({g.Key.Anotador})";
                ws.Cell(row, startCol).Value = groupTitle;
                ws.Range(row, startCol, row, startCol + totalCols - 1).Merge();
                ws.Cell(row, startCol).Style.Font.SetBold();
                ws.Cell(row, startCol).Style.Fill.SetBackgroundColor(colorGroupHeader);
                row++;

                int headerRowDate = row;
                int headerRowEmpaque = row + 1;

                ws.Cell(headerRowDate, startCol).Value = "No.";
                ws.Range(headerRowDate, startCol, headerRowEmpaque, startCol).Merge();

                ws.Cell(headerRowDate, startCol + 1).Value = "Código";
                ws.Range(headerRowDate, startCol + 1, headerRowEmpaque, startCol + 1).Merge();

                ws.Cell(headerRowDate, startCol + 2).Value = "Nombre";
                ws.Range(headerRowDate, startCol + 2, headerRowEmpaque, startCol + 2).Merge();

                ws.Cell(headerRowDate, startCol + 3).Value = "LP";
                ws.Range(headerRowDate, startCol + 3, headerRowEmpaque, startCol + 3).Merge();

                ws.Range(headerRowDate, startCol, headerRowEmpaque, startCol + 3).Style
                    .Font.SetBold()
                    .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                    .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                    .Fill.SetBackgroundColor(colorTableHeader);

                int col = startCol + fixedCols;
                foreach (var c in colKeys)
                {
                    ws.Cell(headerRowDate, col).Value = c.Fecha;
                    ws.Cell(headerRowDate, col).Style.DateFormat.Format = "dd-MMM";
                    ws.Cell(headerRowEmpaque, col).Value = c.EmpaqueDisplay;
                    col++;
                }

                var headRange = ws.Range(headerRowDate, startCol + fixedCols, headerRowEmpaque, startCol + totalCols - 1);
                headRange.Style.Font.SetBold();
                headRange.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                headRange.Style.Fill.SetBackgroundColor(colorTableHeader);
                headRange.Style.Border.OutsideBorder = XLBorderStyleValues.Medium;
                headRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                // Cuerpo
                row = headerRowEmpaque + 1;
                foreach (var emp in g.Employees)
                {
                    int dataRow = row;
                    ws.Cell(dataRow, startCol).Value = emp.Numero;
                    ws.Cell(dataRow, startCol + 1).Value = emp.Codigo;
                    ws.Cell(dataRow, startCol + 2).Value = emp.Nombre;
                    ws.Cell(dataRow, startCol + 3).Value = emp.Lp;

                    decimal rowTotal = 0m;
                    col = startCol + fixedCols;
                    foreach (var c in colKeys)
                    {
                        decimal val = g.GetValue(emp, c);
                        var cell = ws.Cell(dataRow, col);
                        if (val != 0m)
                        {
                            ClsExcel.SetCellValue(cell, val);
                            cell.Style.Fill.SetBackgroundColor(colorValueCell);
                            rowTotal += val;
                        }

                        col++;
                    }

                    if (rowTotal == 0m)
                    {
                        ws.Range(dataRow, startCol, dataRow, startCol + totalCols - 1)
                            .Style.Fill.SetBackgroundColor(colorEmptyRow);
                    }

                    row++;
                }

                var bodyRange = ws.Range(headerRowDate, startCol, row - 1, startCol + totalCols - 1);
                bodyRange.Style.Border.OutsideBorder = XLBorderStyleValues.Medium;
                bodyRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                bodyRange.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                ws.Columns(startCol + 2, startCol + 2).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left);

                row += 2;
            }

            ws.Columns().AdjustToContents();
            return ws;
        }

        private static string BuildFiltersText(string season, string contractor, string workGroup, string user, string dateRange)
        {
            var parts = new List<string>();
            if (!string.IsNullOrWhiteSpace(dateRange)) parts.Add($"Fechas: {dateRange}");
            if (!string.IsNullOrWhiteSpace(season)) parts.Add($"Temporada: {season}");
            if (!string.IsNullOrWhiteSpace(contractor)) parts.Add($"Contratista: {contractor}");
            if (!string.IsNullOrWhiteSpace(workGroup)) parts.Add($"Cuadrilla: {workGroup}");
            if (!string.IsNullOrWhiteSpace(user)) parts.Add($"Anotador: {user}");
            return string.Join(" | ", parts);
        }

        private static List<DateEmpaqueColumnKey> BuildDateEmpaqueColumns(DataTable data, DateTime rangeStart, DateTime rangeEnd)
        {
            var rows = data.AsEnumerable().ToList();

            var distinctByDay = rows
                .Where(r => r.Table.Columns.Contains(ClsPayrollBoxPerEmployeeReport.Columns.Fecha))
                .Select(r => new
                {
                    Fecha = NormalizeDate(r[ClsPayrollBoxPerEmployeeReport.Columns.Fecha]),
                    IdPrice = r.Table.Columns.Contains(ClsPayrollBoxPerEmployeeReport.Columns.IdPrice)
                        ? (r[ClsPayrollBoxPerEmployeeReport.Columns.IdPrice] == DBNull.Value ? string.Empty : r[ClsPayrollBoxPerEmployeeReport.Columns.IdPrice].ToString()?.Trim() ?? string.Empty)
                        : string.Empty,
                    Empaque = r[ClsPayrollBoxPerEmployeeReport.Columns.Empaque] == DBNull.Value ? string.Empty : r[ClsPayrollBoxPerEmployeeReport.Columns.Empaque].ToString()?.Trim() ?? string.Empty,
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

        private static List<GroupTableModel> BuildGroups(DataTable data)
        {
            var groups = data.Rows.Cast<DataRow>()
                .GroupBy(r => new GroupKey(
                    (r[ClsPayrollBoxPerEmployeeReport.Columns.Contratista] == DBNull.Value ? string.Empty : r[ClsPayrollBoxPerEmployeeReport.Columns.Contratista].ToString()?.Trim() ?? string.Empty),
                    (r[ClsPayrollBoxPerEmployeeReport.Columns.Cuadrilla] == DBNull.Value ? string.Empty : r[ClsPayrollBoxPerEmployeeReport.Columns.Cuadrilla].ToString()?.Trim() ?? string.Empty),
                    (data.Columns.Contains(ClsPayrollBoxPerEmployeeReport.Columns.Anotador)
                        ? (r[ClsPayrollBoxPerEmployeeReport.Columns.Anotador] == DBNull.Value ? string.Empty : r[ClsPayrollBoxPerEmployeeReport.Columns.Anotador].ToString()?.Trim() ?? string.Empty)
                        : string.Empty),
                    (r[ClsPayrollBoxPerEmployeeReport.Columns.IdUser] == DBNull.Value ? string.Empty : r[ClsPayrollBoxPerEmployeeReport.Columns.IdUser].ToString()?.Trim() ?? string.Empty)
                ))
                .OrderBy(g => g.Key.Contratista, StringComparer.OrdinalIgnoreCase)
                .ThenBy(g => g.Key.Cuadrilla, StringComparer.OrdinalIgnoreCase)
                .ThenBy(g => g.Key.Anotador, StringComparer.OrdinalIgnoreCase)
                .ThenBy(g => g.Key.IdUser, StringComparer.OrdinalIgnoreCase)
                .ToList();

            var result = new List<GroupTableModel>();
            foreach (var g in groups)
            {
                var model = new GroupTableModel(g.Key);
                foreach (DataRow r in g)
                    model.AddRow(r);
                model.SortEmployees();
                result.Add(model);
            }

            return result;
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
            string reportName = "Reporte cajas por empleado";
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
                return "REPORTE";

            string sanitized = System.Text.RegularExpressions.Regex.Replace(name, @"[\\\/\?\*\[\]]", "-");
            if (sanitized.Length > 31)
                sanitized = sanitized[..31];

            return sanitized.Trim();
        }
    }

    internal readonly record struct GroupKey(string Contratista, string Cuadrilla, string Anotador, string IdUser);

    internal readonly record struct EmployeeKey(string Numero, string Codigo, string Nombre, string Lp, string OrdenNum);

    internal readonly record struct DateEmpaqueColumnKey(DateTime Fecha, string Empaque, string IdPrice)
    {
        public string EmpaqueDisplay => string.IsNullOrWhiteSpace(Empaque) ? string.Empty : Empaque;
        public string Display => $"{Fecha:dd-MMM} {EmpaqueDisplay}".Trim();
    }

    internal sealed class GroupTableModel
    {
        public GroupKey Key { get; }
        public List<EmployeeKey> Employees { get; } = new();

        private readonly Dictionary<(EmployeeKey Emp, DateTime Fecha, string Empaque), decimal> _values = new();

        public GroupTableModel(GroupKey key)
        {
            Key = key;
        }

        public void AddRow(DataRow row)
        {
            string numero = row[ClsPayrollBoxPerEmployeeReport.Columns.Numero] == DBNull.Value ? string.Empty : row[ClsPayrollBoxPerEmployeeReport.Columns.Numero].ToString()?.Trim() ?? string.Empty;
            string codigo = row[ClsPayrollBoxPerEmployeeReport.Columns.Codigo] == DBNull.Value ? string.Empty : row[ClsPayrollBoxPerEmployeeReport.Columns.Codigo].ToString()?.Trim() ?? string.Empty;
            string nombre = row[ClsPayrollBoxPerEmployeeReport.Columns.Nombre] == DBNull.Value ? string.Empty : row[ClsPayrollBoxPerEmployeeReport.Columns.Nombre].ToString()?.Trim() ?? string.Empty;
            string lp = row.Table.Columns.Contains(ClsPayrollBoxPerEmployeeReport.Columns.Lp) && row[ClsPayrollBoxPerEmployeeReport.Columns.Lp] != DBNull.Value
                ? row[ClsPayrollBoxPerEmployeeReport.Columns.Lp].ToString()?.Trim() ?? string.Empty
                : string.Empty;
            string ordenNum = row.Table.Columns.Contains(ClsPayrollBoxPerEmployeeReport.Columns.OrdenNum) && row[ClsPayrollBoxPerEmployeeReport.Columns.OrdenNum] != DBNull.Value
                ? row[ClsPayrollBoxPerEmployeeReport.Columns.OrdenNum].ToString()?.Trim() ?? string.Empty
                : string.Empty;

            var emp = new EmployeeKey(numero, codigo, nombre, lp, ordenNum);
            if (!Employees.Contains(emp))
                Employees.Add(emp);

            DateTime fecha = NormalizeDate(row[ClsPayrollBoxPerEmployeeReport.Columns.Fecha]);
            string empaque = row[ClsPayrollBoxPerEmployeeReport.Columns.Empaque] == DBNull.Value ? string.Empty : row[ClsPayrollBoxPerEmployeeReport.Columns.Empaque].ToString()?.Trim() ?? string.Empty;
            decimal cajas = ToDecimal(row[ClsPayrollBoxPerEmployeeReport.Columns.Cajas]);

            if (fecha == DateTime.MinValue)
                return;

            var key = (emp, fecha.Date, empaque);
            _values.TryGetValue(key, out decimal current);
            _values[key] = current + cajas;
        }

        public void SortEmployees()
        {
            Employees.Sort((a, b) =>
            {
                int ordA = TryParseInt(a.OrdenNum);
                int ordB = TryParseInt(b.OrdenNum);
                int cmp = ordA.CompareTo(ordB);
                if (cmp != 0) return cmp;

                int numA = TryParseInt(a.Numero);
                int numB = TryParseInt(b.Numero);
                cmp = numA.CompareTo(numB);
                if (cmp != 0) return cmp;

                return string.Compare(a.Codigo, b.Codigo, StringComparison.OrdinalIgnoreCase);
            });
        }

        public decimal GetValue(EmployeeKey employee, DateEmpaqueColumnKey col)
        {
            if (col.Fecha == DateTime.MinValue)
                return 0m;

            return _values.TryGetValue((employee, col.Fecha.Date, col.Empaque), out decimal val) ? val : 0m;
        }

        private static int TryParseInt(string value)
            => int.TryParse(value?.Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out int n) ? n : int.MaxValue;

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
    }
}

