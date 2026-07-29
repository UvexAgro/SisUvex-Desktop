using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Bibliography;
using SisUvex.Archivo.Manifiesto.ConfManifest;
using SisUvex.Catalogos.Metods.ExcelLoad;
using SisUvex.Catalogos.Metods.Querys;

namespace SisUvex.Archivo.Manifiesto
{
    internal class ClsManifestExcelLayout
    {
        string? ManifestFolderPath;
        string? idManifest;
        string? distributor;
        string? filePath = null;
        const string? layoutName = "Layout";
        public ClsManifestExcelLayout()
        {
            idManifest = null;
            ManifestFolderPath = null;
            filePath = null;
        }
        public ClsManifestExcelLayout(string? idManifest)
        {
            this.idManifest = idManifest;
        }

        private DataTable? GetDtLayout()
        {
            if (string.IsNullOrEmpty(idManifest))
                return null;

            return ClsQuerysDB.ExecuteParameterizedQuery("SELECT * FROM vw_PackOppyLayout WHERE BL = @IdManifest", new Dictionary<string, object> { { "@IdManifest", idManifest } });
        }

        public void SetFilePath(string IdManifest, string folderPath)
        {
            idManifest = IdManifest;

            if (string.IsNullOrEmpty(idManifest))
                return;

            
        }

        public bool CreateExcelLayout(string IdManifest, string distributorShortName, string folderPath)
        {
            try
            {
                idManifest = IdManifest;
                distributor = distributorShortName;
                ManifestFolderPath = folderPath;
                filePath = Path.Combine(ManifestFolderPath, $"{distributor} {layoutName} {IdManifest}.xlsx");

                DataTable dtLayout = GetDtLayout();
                if (dtLayout == null || dtLayout.Rows.Count == 0)
                    return false;

                // 2. Crear documento Excel
                using (var excelDoc = new ExcelDocument(Path.GetFileName(filePath), Path.GetDirectoryName(filePath)))
                {
                    var sheet = excelDoc.AddSheet("Layout", dtLayout, createTable: true);

                    for (int i = 0; i < dtLayout.Columns.Count; i++)
                    {
                        Type colType = dtLayout.Columns[i].DataType;

                        if (colType == typeof(DateTime))
                        {
                            sheet.SetColumnFormat(i + 1, "yyyy-MM-dd");
                        }
                        else if (colType == typeof(decimal) || colType == typeof(double))
                        {
                            sheet.SetColumnFormat(i + 1, "#,##0.00");
                        }
                    }

                    sheet.AutoFitColumns();

                    excelDoc.Save();
                }

                return File.Exists(filePath);
            }
            catch (Exception ex)
            {
                // Registrar el error según tu sistema de logs
                Console.WriteLine($"Error al crear el layout Excel: {ex.Message}");
                return false;
            }
        }
    }
}
