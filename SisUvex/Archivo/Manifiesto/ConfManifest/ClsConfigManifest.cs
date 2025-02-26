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
        public string? market { get; set; }
        public int? temperature { get; set; }
        public string? temperatureUnit { get; set; }

        public bool printManifest { get; set; }
        public bool printMaping { get; set; }
        public bool printPackingList { get; set; }
        public string? transportVehicle { get; set; }
        public string? transportTransportType { get; set; }

        public void GetParameters()
        {
            string qry = "SELECT * FROM Pack_ConfManifest";

            DataTable dt = ClsQuerysDB.GetDataTable(qry);

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                idSeason = dr["id_season"].ToString();
                market = dr["c_market"].ToString();
                temperature = Convert.ToInt32(dr["i_temperature"]);
                temperatureUnit = dr["c_temperatureUnit"].ToString();
                printManifest = dr["c_printManifest"].ToString() == "1";
                printMaping = dr["c_printMaping"].ToString() == "1";
                printPackingList = dr["c_printPackingList"].ToString() == "1";
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
                    { "@market", market ?? (object)DBNull.Value },
                    { "@temperature", temperature ?? (object)DBNull.Value },
                    { "@temperatureUnit", temperatureUnit ?? (object)DBNull.Value },
                    { "@printManifest", printManifest ? "1" : "0" },
                    { "@printMaping", printMaping ? "1" : "0" },
                    { "@printPackingList", printPackingList ? "1" : "0" },
                    { "@transportVehicle", transportVehicle ?? (object)DBNull.Value },
                    { "@transportTransportType", transportTransportType ?? (object)DBNull.Value }
                };

            if (dt.Rows.Count == 0 || (int)dt.Rows[0][0] == 0)
            {
                MessageBox.Show("0");
                string qry = @"INSERT INTO Pack_ConfManifest ( 
                                 id_season, 
                                 c_market, 
                                 i_temperature, 
                                 c_temperatureUnit, 
                                 c_printManifest, 
                                 c_printMaping, 
                                 c_printPackingList, 
                                 v_transportVehicle, 
                                 v_transportType) 
                                 VALUES (
                                 @idSeason, 
                                 @market, 
                                 @temperature, 
                                 @temperatureUnit, 
                                 @printManifest, 
                                 @printMaping, 
                                 @printPackingList, 
                                 @transportVehicle, 
                                 @transportTransportType)";
                
                return ClsQuerysDB.GetBoolExecuteParameterizedQuery(qry, parameters);
            }
            else
            {
                MessageBox.Show("+0");

                string qry = @"UPDATE Pack_ConfManifest SET 
                                id_season = @idSeason, 
                                c_market = @market, 
                                i_temperature = @temperature, 
                                c_temperatureUnit = @temperatureUnit, 
                                c_printManifest = @printManifest, 
                                c_printMaping = @printMaping, 
                                c_printPackingList = @printPackingList, 
                                v_transportVehicle = @transportVehicle, 
                                v_transportType = @transportTransportType";

                return ClsQuerysDB.GetBoolExecuteParameterizedQuery(qry, parameters);
            }
        }
    }
}
