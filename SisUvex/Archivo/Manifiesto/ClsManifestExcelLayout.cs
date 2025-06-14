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
        string? filePath;
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

        public void SetFilePath(string IdManifest)
        {
            idManifest = IdManifest;

            if (string.IsNullOrEmpty(idManifest))
                return;

            ClsConfigManifest conf = new ClsConfigManifest();
            conf.GetParameters();
            ManifestFolderPath = conf.manifestFolderPath;

            string distributor = ClsQuerysDB.GetStringExecuteParameterizedQuery("SELECT dis.v_nameDistShort FROM PACK_MANIFEST man JOIN Pack_Distributor dis ON dis.id_distributor = man.id_distributor WHERE man.id_manifest = @IdManifest", new Dictionary<string, object> { { "@IdManifest", idManifest } });

            if (!string.IsNullOrEmpty(distributor))
            {
                ManifestFolderPath = Path.Combine(ManifestFolderPath, "Manifiestos", distributor, idManifest);

                if (!Directory.Exists(ManifestFolderPath))
                {
                    Directory.CreateDirectory(ManifestFolderPath);
                }

                filePath = Path.Combine(ManifestFolderPath, $"{distributor} {layoutName} {IdManifest}.xlsx");
            }
        }

        public bool CreateExcelLayout()
        {
            if (string.IsNullOrEmpty(idManifest))
                return false;

            return CreateExcelLayout(idManifest);
        }


        public bool CreateExcelLayout(string IdManifest)
        {
            try
            {
                idManifest = IdManifest;
                // 1. Validar y obtener datos
                if (string.IsNullOrEmpty(filePath))
                    SetFilePath(idManifest);

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
