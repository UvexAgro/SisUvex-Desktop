using ClosedXML.Excel;
using SisUvex.Catalogos.Metods.ExcelLoad;
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

        private static CultureInfo CultureEs =>
            CultureInfo.GetCultureInfo("es-MX");

        /// <summary>
        /// Pivota los datos planos (una fila por fecha/empleado/categoría) a columnas por día del rango.
        /// Las columnas fijas siguen la definición de <see cref="ClsPayrollBoxPerNumberReport.Columns"/>.
        /// Nombre técnico de columnas día: yyyy-MM-dd; Caption: texto tipo "Viernes, 06".
        /// </summary>
        public DataTable BuildPivotDataTable(DataTable flat, DateTime rangeStart, DateTime rangeEnd)
        {
            DataTable result = CreateEmptyPivotSchema(rangeStart, rangeEnd);

            if (flat == null || flat.Rows.Count == 0)
                return result;

            foreach (IGrouping<RowKeyBoxPerNumber, DataRow> g in SortedGroups(flat))
            {
                DataRow outRow = result.NewRow();
                outRow[ClsPayrollBoxPerNumberReport.Columns.Contratista] = g.Key.Contratista;
                outRow[ClsPayrollBoxPerNumberReport.Columns.Cuadrilla] = g.Key.Cuadrilla;
                outRow[ClsPayrollBoxPerNumberReport.Columns.Numero] = g.Key.Numero ?? (object)DBNull.Value;
                outRow[ClsPayrollBoxPerNumberReport.Columns.IdEmpleado] = g.Key.IdEmpleado ?? (object)DBNull.Value;
                outRow[ClsPayrollBoxPerNumberReport.Columns.NombreEmpleado] = g.Key.NombreEmpleado;
                outRow[ClsPayrollBoxPerNumberReport.Columns.Categoria] = g.Key.Categoria;

                foreach (DateTime d in EachDayInclusive(rangeStart, rangeEnd))
                    outRow[DayColumnName(d)] = 0m;

                foreach (DataRow row in g)
                {
                    DateTime d = NormalizeWorkDay(row[ClsPayrollBoxPerNumberReport.Columns.Fecha]);
                    string dateCol = DayColumnName(d);

                    if (!result.Columns.Contains(dateCol))
                        continue;

                    decimal add = BoxesToDecimal(row[ClsPayrollBoxPerNumberReport.Columns.Cajas]);
                    decimal prev = (decimal)outRow[dateCol];
                    outRow[dateCol] = prev + add;
                }

                result.Rows.Add(outRow);
            }

            return result;
        }

        private static IEnumerable<DateTime> EachDayInclusive(DateTime rangeStart, DateTime rangeEnd)
        {
            DateTime a = rangeStart.Date;
            DateTime b = rangeEnd.Date;

            if (a > b)
                yield break;

            for (; a <= b; a = a.AddDays(1))
                yield return a;
        }

        private static IEnumerable<IGrouping<RowKeyBoxPerNumber, DataRow>> SortedGroups(DataTable flat)
        {
            return FlatRowsGrouped(flat)
                .OrderBy(g => g.Key.Contratista)
                .ThenBy(g => g.Key.Cuadrilla)
                .ThenBy(g => g.Key.Numero, StringComparer.Ordinal)
                .ThenBy(g => g.Key.IdEmpleado, StringComparer.Ordinal)
                .ThenBy(g => g.Key.NombreEmpleado)
                .ThenBy(g => g.Key.Categoria);
        }

        public void GenerateExcelReport(
            DataTable flatTable,
            DateTime rangeStart,
            DateTime rangeEnd,
            string period,
            string contractor,
            string workGroup,
            string paymentPlace,
            string dateRange)
        {
            if (flatTable == null || flatTable.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para generar el reporte.", "Reporte cajas por número",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataTable pivot = BuildPivotDataTable(flatTable, rangeStart, rangeEnd);

            string fileName = GetFileReportName(period, dateRange);
            string? filePath = GetFolderPath(fileName);

            if (filePath == null)
                return;

            if (IsFileLocked(filePath))
            {
                MessageBox.Show(
                    $"El archivo '{filePath}' está abierto.\n\nCiérralo antes de generar el reporte.",
                    "Reporte cajas por número",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            using (var workbook = new XLWorkbook())
            {
                // Hoja con datos crudos (origen), similar a Poda "DATOS"
                var wsDatos = workbook.Worksheets.Add(flatTable, "DATOS");
                wsDatos.Tables.First().ShowAutoFilter = true;
                wsDatos.Columns().AdjustToContents();

                CreatePivotWorksheet(workbook, pivot, period, contractor, workGroup, paymentPlace, dateRange);

                workbook.SaveAs(filePath);
            }

            DialogResult result = MessageBox.Show(
                "Reporte en excel generado correctamente.\n\n¿Deseas abrir el archivo?",
                "Reporte cajas por número",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information
            );

            if (result == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = filePath,
                    UseShellExecute = true
                });
            }
        }

        private sealed record RowKeyBoxPerNumber(
            string Contratista,
            string Cuadrilla,
            string? Numero,
            string? IdEmpleado,
            string NombreEmpleado,
            string Categoria);

        private static IEnumerable<IGrouping<RowKeyBoxPerNumber, DataRow>> FlatRowsGrouped(DataTable flat)
        {
            return flat.Rows.Cast<DataRow>().GroupBy(r => new RowKeyBoxPerNumber(
                r[ClsPayrollBoxPerNumberReport.Columns.Contratista]?.ToString()?.Trim() ?? string.Empty,
                r[ClsPayrollBoxPerNumberReport.Columns.Cuadrilla]?.ToString()?.Trim() ?? string.Empty,
                r[ClsPayrollBoxPerNumberReport.Columns.Numero]?.ToString()?.Trim(),
                r[ClsPayrollBoxPerNumberReport.Columns.IdEmpleado]?.ToString()?.Trim(),
                r[ClsPayrollBoxPerNumberReport.Columns.NombreEmpleado]?.ToString()?.Trim() ?? string.Empty,
                r[ClsPayrollBoxPerNumberReport.Columns.Categoria]?.ToString()?.Trim() ?? string.Empty));
        }

        private static DataTable CreateEmptyPivotSchema(DateTime rangeStart, DateTime rangeEnd)
        {
            var dt = new DataTable();

            void AddFixed(string name, Type type)
            {
                var dc = dt.Columns.Add(name, type);
                dc.Caption = name;
            }

            AddFixed(ClsPayrollBoxPerNumberReport.Columns.Contratista, typeof(string));
            AddFixed(ClsPayrollBoxPerNumberReport.Columns.Cuadrilla, typeof(string));
            AddFixed(ClsPayrollBoxPerNumberReport.Columns.Numero, typeof(object));
            AddFixed(ClsPayrollBoxPerNumberReport.Columns.IdEmpleado, typeof(object));
            AddFixed(ClsPayrollBoxPerNumberReport.Columns.NombreEmpleado, typeof(string));
            AddFixed(ClsPayrollBoxPerNumberReport.Columns.Categoria, typeof(string));

            DateTime cursor = rangeStart.Date;
            DateTime last = rangeEnd.Date;
            if (cursor > last)
                return dt;

            for (; cursor <= last; cursor = cursor.AddDays(1))
            {
                var dcDay = dt.Columns.Add(DayColumnName(cursor), typeof(decimal));
                dcDay.Caption = DayHeaderCaption(cursor);
            }

            return dt;
        }

        private static string DayColumnName(DateTime d) => d.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

        private static string DayHeaderCaption(DateTime d)
        {
            CultureInfo ci = CultureEs;
            string dayName = ci.TextInfo.ToTitleCase(d.ToString("dddd", ci));
            return dayName + ", " + d.Day.ToString(ci);
        }

        private static DateTime NormalizeWorkDay(object? value)
        {
            if (value == null || value == DBNull.Value)
                return DateTime.MinValue.Date;

            if (value is DateTime dto)
                return dto.Date;

            return DateTime.Parse(value.ToString()!, CultureInfo.InvariantCulture).Date;
        }

        private static decimal BoxesToDecimal(object? value)
        {
            if (value == null || value == DBNull.Value)
                return 0m;

            return Convert.ToDecimal(value, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Tabla pivote ya formateada como en asistencia: bloque filtros + encabezados + datos.
        /// </summary>
        private IXLWorksheet CreatePivotWorksheet(
            XLWorkbook workbook,
            DataTable pivotTable,
            string period,
            string contractor,
            string workGroup,
            string paymentPlace,
            string dateRange)
        {
            string sheetName = SanitizeSheetName(string.IsNullOrWhiteSpace(period) ? "Cajas por número" : period);
            if (string.Equals(sheetName, "DATOS", StringComparison.OrdinalIgnoreCase))
                sheetName = "Reporte";

            var ws = workbook.Worksheets.Add(sheetName);

            int infoStartRow = 2;
            int infoStartCol = 2;
            int currentRow = infoStartRow;
            int filterStarCol = infoStartCol + 1;

            void AddInfoRow(string title, string value)
            {
                if (string.IsNullOrWhiteSpace(value))
                    return;

                ws.Cell(currentRow, filterStarCol).Value = title;
                ws.Cell(currentRow, filterStarCol).Style.Font.SetBold();
                ws.Cell(currentRow, filterStarCol + 1).Value = value;
                currentRow++;
            }

            AddInfoRow("Semana", period);
            AddInfoRow("Fechas", dateRange);
            AddInfoRow("Contratista", contractor);
            AddInfoRow("Cuadrilla", workGroup);
            AddInfoRow("Lugar de pago", paymentPlace);

            int infoEndRow = currentRow - 1;

            if (infoEndRow >= infoStartRow)
            {
                var infoRange = ws.Range(infoStartRow, filterStarCol, infoEndRow, filterStarCol + 1);
                infoRange.Style.Border.OutsideBorder = XLBorderStyleValues.Medium;
                infoRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                infoRange.Columns(1, 1).Style.Fill.SetBackgroundColor(colorHeader);
                infoRange.Columns(1, 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);
            }

            int tableStartRow = (infoEndRow >= infoStartRow ? infoEndRow + 2 : infoStartRow);
            int tableStartCol = infoStartCol;

            int headerRow = tableStartRow;
            int colIdx = tableStartCol;

            foreach (DataColumn col in pivotTable.Columns)
            {
                ws.Cell(headerRow, colIdx).Value = ColumnHeaderDisplay(col);
                colIdx++;
            }

            int lastCol = colIdx - 1;

            int dataStartRow = headerRow + 1;
            int rowIndex = dataStartRow;

            foreach (DataRow row in pivotTable.Rows)
            {
                int cCell = tableStartCol;
                foreach (DataColumn col in pivotTable.Columns)
                {
                    object? cellVal = row[col.ColumnName];
                    bool isDecimal = col.DataType == typeof(decimal);

                    var cell = ws.Cell(rowIndex, cCell);
                    ClsExcel.SetCellValue(cell, cellVal ?? (isDecimal ? 0 : null));

                    if (isDecimal && cellVal != DBNull.Value && BoxesToDecimal(cellVal) == 0m)
                        cell.Clear(XLClearOptions.Contents);

                    cCell++;
                }
                rowIndex++;
            }

            int lastDataRow = rowIndex - 1;

            var headerRange = ws.Range(headerRow, tableStartCol, headerRow, lastCol);
            headerRange.Style.Border.OutsideBorder = XLBorderStyleValues.Medium;
            headerRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
            headerRange.Style.Font.SetBold();
            headerRange.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            headerRange.Style.Fill.SetBackgroundColor(colorTableHeader);

            if (lastDataRow >= dataStartRow)
            {
                var dataRange = ws.Range(dataStartRow, tableStartCol, lastDataRow, lastCol);
                dataRange.Style.Border.OutsideBorder = XLBorderStyleValues.Medium;
                dataRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
            }

            ws.Columns().AdjustToContents();
            return ws;
        }

        private static string ColumnHeaderDisplay(DataColumn col)
            => string.IsNullOrWhiteSpace(col.Caption) ? col.ColumnName : col.Caption;

        private string GetFileReportName(string period, string dateRange)
        {
            string reportName = "Reporte cajas por número";
            if (!string.IsNullOrWhiteSpace(period))
                reportName += " " + System.Text.RegularExpressions.Regex.Replace(period, @"[\\\/\?\*\[\]]", "-");
            else if (!string.IsNullOrWhiteSpace(dateRange))
                reportName += " " + System.Text.RegularExpressions.Regex.Replace(dateRange, @"[\\\/\?\*\[\]]", "-");

            reportName += ".xlsx";
            return reportName;
        }

        private string? GetFolderPath(string fileReportName)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Guardar reporte de Excel";
                saveFileDialog.FileName = fileReportName;

                saveFileDialog.Filter =
                    "Archivo de Excel (*.xlsx)|*.xlsx|" +
                    "Archivo de Excel 97-2003 (*.xls)|*.xls|" +
                    "Todos los archivos (*.*)|*.*";

                saveFileDialog.FilterIndex = 1;
                saveFileDialog.AddExtension = true;
                saveFileDialog.DefaultExt = "xlsx";
                saveFileDialog.OverwritePrompt = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return saveFileDialog.FileName;
                }
            }

            return null;
        }

        private bool IsFileLocked(string filePath)
        {
            if (!File.Exists(filePath))
                return false;

            try
            {
                using FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
                stream.Close();
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
                return "Cajas por número";

            string sanitized = System.Text.RegularExpressions.Regex.Replace(name, @"[\\\/\?\*\[\]]", "-");
            if (sanitized.Length > 31)
                sanitized = sanitized[..31];

            return sanitized.Trim();
        }
    }
}
