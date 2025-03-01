using SisUvex.Catalogos.Lot;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.DataGridViews;
using SisUvex.Catalogos.Metods.Querys;

namespace SisUvex.Archivo.Manifiesto.ManifestTemplates
{
    internal class EManifestTemplate
    {
        public string? idManifestTemplate { get; set; }
        public string? nameManifestTemplate { get; set; }
        public string? description { get; set; }
        public string? idDistributor { get; set; }
        public string? idConsignee { get; set; }
        public string? idGrower { get; set; }
        public string? idUSAgencyTrade { get; set; }
        public string? idMXAgencyTrade { get; set; }
        public string? idCityCrossPoint { get; set; }
        public string? idCityDestiny { get; set; }

        public void SetManifestTemplate(string idTemplate)
        {
            string qry = "SELECT * FROM Pack_ManifestTemplates WHERE id_template = @idTemplate";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@idTemplate", idTemplate }
            };

            DataTable dt = ClsQuerysDB.ExecuteParameterizedQuery(qry, parameters);

            if (dt.Rows.Count > 0 && !string.IsNullOrEmpty(dt.Rows[0][0].ToString()))
            {
                DataRow dr = dt.Rows[0];
                this.idManifestTemplate = dr["id_template"].ToString();
                this.nameManifestTemplate = dr["v_nameTemplate"].ToString();
                this.description = dr["v_description"].ToString();
                this.idDistributor = dr["id_distributor"].ToString();
                this.idConsignee = dr["id_consignee"].ToString();
                this.idGrower = dr["id_grower"].ToString();
                this.idUSAgencyTrade = dr["id_USAgencyTrade"].ToString();
                this.idMXAgencyTrade = dr["id_MXAgencyTrade"].ToString();
                this.idCityCrossPoint = dr["id_cityCrossPoint"].ToString();
                this.idCityDestiny = dr["id_cityDestiny"].ToString();
            }
        }
    }
}
