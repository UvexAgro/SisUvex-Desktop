using ClosedXML.Excel;
using SisUvex.Catalogos.Metods.ExcelLoad;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace SisUvex.Nomina.Asistencia_contrato.Consulta
{
    internal class ClsExcelPayrollAttendance
    {
        private readonly XLColor colorHeader = XLColor.FromHtml("#538DD5");
        private readonly XLColor colorTableHeader = XLColor.FromHtml("#8DB4E2");

        public void GenerateExcelReport(DataTable attendanceTable, string period, string contractor, string workGroup, string paymentPlace)
        {
            if (attendanceTable == null || attendanceTable.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para generar el reporte de asistencia.", "Asistencia contrato",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string fileName = GetFileReportName(period);
            string? filePath = GetFolderPath(fileName);

            if (filePath == null)
                return;

            if (IsFileLocked(filePath))
            {
                MessageBox.Show($"El archivo '{filePath}' está abierto.\n\nCiérralo antes de generar el reporte.","Asistencia contrato",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            using (var workbook = new XLWorkbook())
            {
                var ws = CreateWorksheet(workbook, attendanceTable, period, contractor, workGroup, paymentPlace);
                workbook.SaveAs(filePath);
            }

            DialogResult result = MessageBox.Show("Reporte de asistencia en excel generado correctamente.\n\n¿Deseas abrir el archivo?", "Asistencia contrato", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = filePath,
                    UseShellExecute = true
                });
            }
        }

        private IXLWorksheet CreateWorksheet(XLWorkbook workbook, DataTable attendanceTable, string period, string contractor, string workGroup, string paymentPlace)
        {
            string sheetName = SanitizeSheetName(string.IsNullOrWhiteSpace(period) ? "Asistencia" : period);
            var ws = workbook.Worksheets.Add(sheetName);

            int infoStartRow = 2;
            int infoStartCol = 2; // Columna B
            int currentRow = infoStartRow;
            int filterStarCol = infoStartCol + 1; // Para mover la tablita a la derecha y dejar espacio para el título

            // Tabla de filtros aplicados (solo los que tienen valor)
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
            AddInfoRow("Contratista", contractor);
            AddInfoRow("Cuadrilla", workGroup);
            AddInfoRow("Lugar de pago", paymentPlace);

            int infoEndRow = currentRow - 1;

            // Aplicar formato a la tabla de filtros si al menos hay una fila
            if (infoEndRow >= infoStartRow)
            {
                var infoRange = ws.Range(infoStartRow, filterStarCol, infoEndRow, filterStarCol + 1);
                infoRange.Style.Border.OutsideBorder = XLBorderStyleValues.Medium;
                infoRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                infoRange.Columns(1, 1).Style.Fill.SetBackgroundColor(colorHeader);
                infoRange.Columns(1, 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);
            }

            // Espacio entre la tablita y la tabla principal
            int tableStartRow = (infoEndRow >= infoStartRow ? infoEndRow + 2 : infoStartRow);
            int tableStartCol = infoStartCol;

            // Encabezados de la tabla principal
            int headerRow = tableStartRow;
            int currentCol = tableStartCol;

            foreach (DataColumn col in attendanceTable.Columns)
            {
                ws.Cell(headerRow, currentCol).Value = col.ColumnName;
                currentCol++;
            }

            int lastCol = currentCol - 1;

            // Datos
            int dataStartRow = headerRow + 1;
            int rowIndex = dataStartRow;

            foreach (DataRow row in attendanceTable.Rows)
            {
                currentCol = tableStartCol;
                foreach (DataColumn col in attendanceTable.Columns)
                {
                    object? value = row[col.ColumnName];
                    ClsExcel.SetCellValue(ws.Cell(rowIndex, currentCol), value);
                    currentCol++;
                }
                rowIndex++;
            }

            int lastDataRow = rowIndex - 1;

            // Formato encabezados tabla principal
            var headerRange = ws.Range(headerRow, tableStartCol, headerRow, lastCol);
            headerRange.Style.Border.OutsideBorder = XLBorderStyleValues.Medium;
            headerRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
            headerRange.Style.Font.SetBold();
            headerRange.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            headerRange.Style.Fill.SetBackgroundColor(colorTableHeader);

            // Formato datos
            if (lastDataRow >= dataStartRow)
            {
                var dataRange = ws.Range(dataStartRow, tableStartCol, lastDataRow, lastCol);
                dataRange.Style.Border.OutsideBorder = XLBorderStyleValues.Medium;
                dataRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
            }

            ws.Columns().AdjustToContents();

            return ws;
        }

        private string GetFileReportName(string period)
        {
            string reportName = "Reporte Asistencia";
            if (!string.IsNullOrWhiteSpace(period))
                reportName += " " + System.Text.RegularExpressions.Regex.Replace(period, @"[\\\/\?\*\[\]]", "-");

            reportName += $".xlsx";
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
                using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                    stream.Close();
                }
            }
            catch (IOException)
            {
                return true;
            }

            return false;
        }

        private string SanitizeSheetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return "Asistencia";

            string sanitized = System.Text.RegularExpressions.Regex.Replace(name, @"[\\\/\?\*\[\]]", "-");

            if (sanitized.Length > 31)
                sanitized = sanitized.Substring(0, 31);

            return sanitized.Trim();
        }
    }
}
