using SisUvex.Catalogos.Metods.Querys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SisUvex.Archivo.Manifiesto.ConfManifest
{
    internal class ClsConfigManifest
    {
        public string? idSeason { get; set; }
        public string? idMarket { get; set; }
        public int? temperature { get; set; }
        public string? temperatureUnit { get; set; }
        public bool printManifest { get; set; }
        public bool printMaping { get; set; }
        public bool printPackingList { get; set; }
        public bool printManifestPerFarm { get; set; }
        public bool printShowSize { get; set; }
        public bool printExcelLayout { get; set; }
        public string? transportVehicle { get; set; }
        public string? transportTransportType { get; set; }
        public string? manifestFolderPath { get; set; }

        // Archivo fijo en AppData\Roaming\SisUvex\ — no se borra al actualizar la app.
        private static readonly string AppDataFolder =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SisUvex");
        private static readonly string ManifestPathFile =
            Path.Combine(AppDataFolder, "manifest_folder_path.txt");

        public ClsConfigManifest()
        {
            manifestFolderPath = LoadManifestFolderPath();
        }

        /// <summary>
        /// Lee la ruta guardada. Orden de prioridad:
        ///   1. Archivo en AppData\Roaming\SisUvex\ (persiste entre actualizaciones).
        ///   2. Properties.Settings (versión anterior antes de migrar).
        ///   3. Escritorio como valor por defecto.
        /// </summary>
        private string LoadManifestFolderPath()
        {
            // 1. Archivo persistente
            if (File.Exists(ManifestPathFile))
            {
                string saved = File.ReadAllText(ManifestPathFile).Trim();
                if (!string.IsNullOrEmpty(saved))
                    return saved;
            }

            // 2. Migrar desde Properties.Settings si tiene algo guardado
            string settingsPath = Properties.Settings.Default.ManifestsFolderPath;
            if (!string.IsNullOrEmpty(settingsPath))
            {
                PersistManifestFolderPath(settingsPath);
                return settingsPath;
            }

            // 3. Valor por defecto: escritorio
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            PersistManifestFolderPath(desktop);
            return desktop;
        }

        /// <summary>
        /// Guarda la ruta en el archivo persistente de AppData y en Properties.Settings.
        /// </summary>
        private static void PersistManifestFolderPath(string path)
        {
            try
            {
                Directory.CreateDirectory(AppDataFolder);
                File.WriteAllText(ManifestPathFile, path);
            }
            catch { }

            try
            {
                Properties.Settings.Default.ManifestsFolderPath = path;
                Properties.Settings.Default.Save();
            }
            catch { }
        }

        public void SetManifestPath(string path)
        {
            if (Directory.Exists(path))
                PersistManifestFolderPath(path);
        }

        public void GetParameters()
        {
            string qry = "SELECT * FROM Pack_ConfManifest";

            DataTable dt = ClsQuerysDB.GetDataTable(qry);

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                idSeason = dr["id_season"].ToString();
                idMarket = dr["id_market"].ToString();
                temperature = Convert.ToInt32(dr["i_temperature"]);
                temperatureUnit = dr["c_temperatureUnit"].ToString();
                printManifest = dr["c_printManifest"].ToString() == "1";
                printMaping = dr["c_printMaping"].ToString() == "1";
                printPackingList = dr["c_printPackingList"].ToString() == "1";
                printManifestPerFarm = dr["c_printManifestPerField"].ToString() == "1";
                printShowSize = dr["c_printShowSize"].ToString() == "1";
                printExcelLayout = dr["c_printExcelLayout"].ToString() == "1";
                transportVehicle = dr["v_transportVehicle"].ToString();
                transportTransportType = dr["v_transportType"].ToString();
            }
        }

        public bool SetParameters()
        {
            string qryConfirm = "SELECT COUNT(*) FROM Pack_ConfManifest";

            DataTable dt = ClsQuerysDB.GetDataTable(qryConfirm);

            var parameters = new Dictionary<string, object>
                {
                    { "@idSeason", idSeason ?? (object)DBNull.Value },
                    { "@idMarket", idMarket ?? (object)DBNull.Value },
                    { "@temperature", temperature ?? (object)DBNull.Value },
                    { "@temperatureUnit", temperatureUnit ?? (object)DBNull.Value },
                    { "@printManifest", printManifest ? "1" : "0" },
                    { "@printMaping", printMaping ? "1" : "0" },
                    { "@printPackingList", printPackingList ? "1" : "0" },
                    { "@manifestPerField", printManifestPerFarm ? "1" : "0" },
                    { "@showSize", printShowSize ? "1" : "0" },
                    { "@excelLayout", printExcelLayout ? "1" : "0" },
                    { "@transportVehicle", transportVehicle ?? (object)DBNull.Value },
                    { "@transportTransportType", transportTransportType ?? (object)DBNull.Value }
                };

            if (dt.Rows.Count == 0 || (int)dt.Rows[0][0] == 0)
            {
                string qry = @"INSERT INTO Pack_ConfManifest ( 
                                 id_season, 
                                 id_market, 
                                 i_temperature, 
                                 c_temperatureUnit, 
                                 c_printManifest, 
                                 c_printMaping, 
                                 c_printPackingList,
                                 c_printManifestPerField,
                                 c_printShowSize,
                                 c_printExcelLayout,
                                 v_transportVehicle, 
                                 v_transportType) 
                                 VALUES (
                                 @idSeason, 
                                 @idMarket, 
                                 @temperature, 
                                 @temperatureUnit, 
                                 @printManifest, 
                                 @printMaping, 
                                 @printPackingList,
                                 @manifestPerField, 
                                 @showSize, 
                                 @excelLayout, 
                                 @transportVehicle, 
                                 @transportTransportType)";
                
                return ClsQuerysDB.GetBoolExecuteParameterizedQuery(qry, parameters);
            }
            else
            {
                string qry = @"UPDATE Pack_ConfManifest SET 
                                id_season = @idSeason, 
                                id_market = @idMarket, 
                                i_temperature = @temperature, 
                                c_temperatureUnit = @temperatureUnit, 
                                c_printManifest = @printManifest, 
                                c_printMaping = @printMaping, 
                                c_printPackingList = @printPackingList, 
                                c_printManifestPerField = @manifestPerField, 
                                c_printShowSize = @showSize, 
                                c_printExcelLayout = @excelLayout, 
                                v_transportVehicle = @transportVehicle, 
                                v_transportType = @transportTransportType";

                return ClsQuerysDB.GetBoolExecuteParameterizedQuery(qry, parameters);
            }
        }
    }
}
