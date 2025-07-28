using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel; // Para xlsx
using NPOI.HSSF.UserModel; // Para xls

namespace SisUvex.Catalogos.Metods.ExcelLoad
{
    internal class ClsExcel
    {
        public string? path { get; set; }
        public List<string>? sheetsName { get; set; }
        public DataSet? sheetsData { get; set; }

        public void OpenFileDialog()
        {
            try
            {
                var openFileDialog = new OpenFileDialog
                {
                    Filter = "Excel Files|*.xls;*.xlsx"
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    path = openFileDialog.FileName;
                    LoadListSheetNames();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el archivo: {ex.Message}");
            }
        }

        public void LoadListSheetNames()
        {
            try
            {
                if (string.IsNullOrEmpty(path))
                    throw new InvalidOperationException("Ruta del archivo no establecida");

                sheetsName = new List<string>();

                using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    IWorkbook workbook;

                    // Determinar si es xls o xlsx
                    if (path.EndsWith(".xlsx"))
                        workbook = new XSSFWorkbook(fileStream);
                    else
                        workbook = new HSSFWorkbook(fileStream);

                    for (int i = 0; i < workbook.NumberOfSheets; i++)
                    {
                        sheetsName.Add(workbook.GetSheetName(i));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar nombres de hojas: {ex.Message}");
            }
        }

        public DataTable? LoadSheetData(string sheetName)
        {
            try
            {
                if (string.IsNullOrEmpty(path))
                    throw new InvalidOperationException("Ruta del archivo no establecida");

                using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    IWorkbook workbook;

                    if (path.EndsWith(".xlsx"))
                        workbook = new XSSFWorkbook(fileStream);
                    else
                        workbook = new HSSFWorkbook(fileStream);

                    ISheet sheet = workbook.GetSheet(sheetName);
                    if (sheet == null) return null;

                    return WorksheetToDataTable(sheet);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos de la hoja: {ex.Message}");
                return null;
            }
        }

        public DataTable? LoadSheetData(ComboBox cbo)
        {
            if (cbo.SelectedItem == null) return null;
            return LoadSheetData(cbo.SelectedItem.ToString());
        }

        private DataTable WorksheetToDataTable(ISheet sheet)
        {
            DataTable dt = new DataTable(sheet.SheetName);

            // Crear columnas basadas en la primera fila (encabezados)
            IRow headerRow = sheet.GetRow(0);
            if (headerRow != null)
            {
                for (int i = 0; i < headerRow.LastCellNum; i++)
                {
                    ICell cell = headerRow.GetCell(i);
                    dt.Columns.Add(cell?.ToString() ?? $"Columna{i}");
                }
            }

            // Llenar filas
            for (int rowIndex = 1; rowIndex <= sheet.LastRowNum; rowIndex++)
            {
                IRow row = sheet.GetRow(rowIndex);
                if (row == null) continue;

                DataRow dataRow = dt.NewRow();

                for (int colIndex = 0; colIndex < dt.Columns.Count; colIndex++)
                {
                    ICell cell = row.GetCell(colIndex);
                    dataRow[colIndex] = cell?.ToString() ?? string.Empty;
                }

                dt.Rows.Add(dataRow);
            }

            return dt;
        }

        public DataSet? LoadAllSheetsData()
        {
            try
            {
                if (string.IsNullOrEmpty(path))
                    throw new InvalidOperationException("Ruta del archivo no establecida");

                sheetsData = new DataSet();

                using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    IWorkbook workbook;

                    if (path.EndsWith(".xlsx"))
                        workbook = new XSSFWorkbook(fileStream);
                    else
                        workbook = new HSSFWorkbook(fileStream);

                    for (int i = 0; i < workbook.NumberOfSheets; i++)
                    {
                        ISheet sheet = workbook.GetSheetAt(i);
                        DataTable dt = WorksheetToDataTable(sheet);
                        sheetsData.Tables.Add(dt);
                    }
                }

                return sheetsData;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar todas las hojas: {ex.Message}");
                return null;
            }
        }

        public void LoadSheetsIntoComboBox(ComboBox comboBox)
        {
            if (sheetsName == null || sheetsName.Count == 0)
                throw new InvalidOperationException("No hay nombres de hojas cargados");

            comboBox.Items.Clear();
            comboBox.Items.AddRange(sheetsName.ToArray());
        }

        // METODOS PARA GUARDAR EXCELES

    }
}