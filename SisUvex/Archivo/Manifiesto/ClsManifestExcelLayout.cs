using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Bibliography;
using SisUvex.Archivo.Manifiesto.ConfManifest;
using SisUvex.Catalogos.Metods.Querys;

namespace SisUvex.Archivo.Manifiesto
{
    internal class ClsManifestExcelLayout
    {
        string? ManifestFolderPath;
        string? idManifest;
        string? filePath;

        ClsManifestExcelLayout(string? idManifest)
        {
            this.idManifest = idManifest;
        }

        private DataTable? GetDtLayout()
        {
            if (string.IsNullOrEmpty(idManifest))
                return null;

            return ClsQuerysDB.ExecuteParameterizedQuery("SELECT * FROM vw_PackOppyLayout WHERE BL = @IdManifest", new Dictionary<string, object> { { "@IdManifest", idManifest } });
        }

        public void SetFolderPath()
        {
            if (string.IsNullOrEmpty(idManifest))
                return;

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            ManifestFolderPath = desktopPath;

            ClsConfigManifest conf = new ClsConfigManifest();
            conf.GetParameters();
            ManifestFolderPath = conf.manifestFolderPath;

            string distributor = ClsQuerysDB.GetStringExecuteParameterizedQuery("SELECT dis.v_nameDistShort FROM PACK_MANIFEST man JOIN Pack_Distributor dis ON dis.id_distributor = man.id_distributor WHERE man.id_manifest = @IdManifest", new Dictionary<string, object> { { "@IdManifest", idManifest } });

            if (string.IsNullOrEmpty(distributor))
            {
                ManifestFolderPath = Path.Combine(ManifestFolderPath, "Manifiestos", distributor);
            }
        }
    }
}
