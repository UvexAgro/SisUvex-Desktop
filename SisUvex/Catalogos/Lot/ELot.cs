using SisUvex.Catalogos.Metods.Querys;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisUvex.Catalogos.Lot
{
    internal class ELot
    {
        public string? idLot { get; set; }
        public string? idVariety { get; set; }
        public string? nameLot { get; set; }
        public int? active { get; set; }
        public decimal ha { get; set; }
        public DateTime date { get; set; }

        public void SetLot(string idLot, string idVariety)
        {
            string qry = "SELECT * FROM Pack_Lot WHERE id_lot = @idLot AND id_variety = @idVariety";

            Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@idLot", idLot },
                    { "@idVariety", idVariety }
                };

            DataTable dt = ClsQuerysDB.ExecuteParameterizedQuery(qry, parameters);

            if (dt.Rows.Count > 0 && !string.IsNullOrEmpty(dt.Rows[0][0].ToString()))
            {
                DataRow dr = dt.Rows[0];
                this.idLot = dr["id_lot"].ToString();
                this.idVariety = dr["id_variety"].ToString();
                nameLot = dr["v_nameLot"].ToString();
                active = int.Parse(dr["c_active"].ToString());
                ha = decimal.Parse(dr["n_ha"].ToString());
                date = DateTime.Parse(dr["d_year"].ToString());
            }
        }
    }
}
