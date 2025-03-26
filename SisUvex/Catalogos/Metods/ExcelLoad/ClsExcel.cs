using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelDataReader;

namespace SisUvex.Catalogos.Metods.ExcelLoad
{
    internal class ClsExcel
    {
        public string? path { get; set; }
        public List<string?>? sheetsName { get; set; }
        public DataSet? sheetsData { get; set; }

        public void OpenFileDialog()
        {
            try
            {
                // Configuración de ventana para seleccionar un archivo
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Excel Workbook|*.xlsx";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    path = openFileDialog.FileName;

                    LoadListSheetNames();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void LoadListSheetNames()
        {
            try
            {
                if (string.IsNullOrEmpty(path))
                {
                    throw new InvalidOperationException("El path del archivo no está establecido.");
                }

                sheetsName = new List<string?>();

                using (FileStream fsSource = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                    using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(fsSource))
                    {
                        do
                        {
                            sheetsName.Add(reader.Name); // Solo obtiene el nombre de la hoja
                        } while (reader.NextResult()); // Pasa a la siguiente hoja
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public DataSet? LoadSheetData(string? sheetName)
        {
            try
            {
                if (string.IsNullOrEmpty(path))
                {
                    throw new InvalidOperationException("El path del archivo no está establecido.");
                }

                using (FileStream fsSource = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                    using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(fsSource))
                    {
                        sheetsData = reader.AsDataSet(new ExcelDataSetConfiguration()
                        {
                            ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                            {
                                UseHeaderRow = true
                            }
                        });

                        return sheetsData.Tables.Contains(sheetName) ? sheetsData.Tables[sheetName].DataSet : null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public DataTable? LoadSheetData(ComboBox cbo)
        {
            try
            {
                if (string.IsNullOrEmpty(path))
                {
                    throw new InvalidOperationException("El path del archivo no está establecido.");
                }

                using (FileStream fsSource = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                    using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(fsSource))
                    {
                        sheetsData = reader.AsDataSet(new ExcelDataSetConfiguration()
                        {
                            ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                            {
                                UseHeaderRow = true
                            }
                        });

                        string sheetName = cbo.SelectedItem.ToString();

                        if (sheetsData.Tables.Contains(sheetName))
                        {
                            return sheetsData.Tables[sheetName];
                        }
                        else
                            return null;
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public void LoadSheetsIntoComboBox(ComboBox comboBox)
        {
            if (sheetsName == null || sheetsName.Count == 0)
            {
                throw new InvalidOperationException("No hay nombres de hojas cargados.");
            }

            comboBox.Items.Clear();
            foreach (var sheet in sheetsName)
            {
                comboBox.Items.Add(sheet);
            }
        }
    }
}
