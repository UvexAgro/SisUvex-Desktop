using ClosedXML.Excel;
using SisUvex.Catalogos.Metods.ExcelLoad;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SisUvex.Nomina.CONTRATO.Nom_employees_pairNumber
{
    internal class ClsExcelNomEmployesPairNumber
    {
        private readonly XLColor colorHeader = XLColor.FromHtml("#538DD5");
        private readonly XLColor colorTableHeader = XLColor.FromHtml("#8DB4E2");

        public void GenerateExcelReport(DataTable reportTable, string contractor, string workGroup)
        {
            if (reportTable == null || reportTable.Rows.Count == 0)
            {
                MessageBox.Show(
                    "No hay datos para generar el reporte.",
                    "Empleados por número",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            string fileName = GetFileReportName(workGroup);
            string? filePath = GetFolderPath(fileName);

            if (filePath == null)
                return;

            if (IsFileLocked(filePath))
            {
                MessageBox.Show(
                    $"El archivo '{filePath}' está abierto.\n\nCiérralo antes de generar el reporte.",
                    "Empleados por número",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            using (var workbook = new XLWorkbook())
            {
                var (wsReport, focusCell) = CreateReportWorksheet(workbook, reportTable, contractor, workGroup);

                var wsDatos = workbook.Worksheets.Add(reportTable, "DATOS");
                wsDatos.Tables.First().ShowAutoFilter = true;
                wsDatos.Columns().AdjustToContents();

                wsReport.SetTabActive();
                (focusCell ?? wsReport.Cell(2, 4)).SetActive();
                workbook.SaveAs(filePath);
            }

            DialogResult result = MessageBox.Show(
                "Reporte en excel generado correctamente.\n\n¿Deseas abrir el archivo?",
                "Empleados por número",
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

        private (IXLWorksheet Worksheet, IXLCell? FocusCell) CreateReportWorksheet(
            XLWorkbook workbook,
            DataTable reportTable,
            string contractor,
            string workGroup)
        {
            string sheetName = SanitizeSheetName(string.IsNullOrWhiteSpace(workGroup) ? "Empleados" : workGroup);
            if (string.Equals(sheetName, "DATOS", StringComparison.OrdinalIgnoreCase))
                sheetName = "Reporte";

            var ws = workbook.Worksheets.Add(sheetName);
            IXLCell? focusCell = null;

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
                var valueCell = ws.Cell(currentRow, filterStarCol + 1);
                valueCell.Value = value;

                if (string.Equals(title, "Cuadrilla", StringComparison.OrdinalIgnoreCase))
                    focusCell = valueCell;

                currentRow++;
            }

            AddInfoRow("Contratista", contractor);
            AddInfoRow("Cuadrilla", workGroup);

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

            foreach (DataColumn col in reportTable.Columns)
            {
                ws.Cell(headerRow, colIdx).Value = col.ColumnName;
                colIdx++;
            }

            int lastCol = colIdx - 1;
            int dataStartRow = headerRow + 1;
            int rowIndex = dataStartRow;

            foreach (DataRow row in reportTable.Rows)
            {
                int cCell = tableStartCol;
                foreach (DataColumn col in reportTable.Columns)
                {
                    object? cellVal = row[col.ColumnName];
                    ClsExcel.SetCellValue(ws.Cell(rowIndex, cCell), cellVal);
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
            return (ws, focusCell);
        }

        private static string GetFileReportName(string workGroup)
        {
            string reportName = "Reporte empleados por número";
            if (!string.IsNullOrWhiteSpace(workGroup))
                reportName += " " + System.Text.RegularExpressions.Regex.Replace(workGroup, @"[\\\/\?\*\[\]]", "-");

            return reportName + ".xlsx";
        }

        private static string? GetFolderPath(string fileReportName)
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
                    return saveFileDialog.FileName;
            }

            return null;
        }

        private static bool IsFileLocked(string filePath)
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
                return "Empleados";

            string sanitized = System.Text.RegularExpressions.Regex.Replace(name, @"[\\\/\?\*\[\]]", "-");
            if (sanitized.Length > 31)
                sanitized = sanitized[..31];

            return sanitized.Trim();
        }
    }
}
