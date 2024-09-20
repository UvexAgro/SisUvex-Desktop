using System.Data.SqlClient;
using static SisUvex.Catalogos.Metods.ClsObject;

namespace SisUvex.Nomina.Prices.PricesGtin
{
    internal class EPricesGtin
    {
        SQLControl sql = new SQLControl();
        public string idPrice { get; set; }
        public string descriptionPrice { get; set; }
        public string priceFieldNormal { get; set; }
        public string priceFieldOver { get; set; }
        public string priceFacilityNormal { get; set; }
        public string priceFacilityOver { get; set; }

        public void SetPricesGtin(string id)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Pack_Price WHERE id_price = '{id}'", sql.cnn);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    idPrice = dr.GetValue(dr.GetOrdinal("id_price")).ToString();
                    descriptionPrice = dr.GetValue(dr.GetOrdinal("v_descriptionPrice")).ToString();
                    priceFieldNormal = dr.GetValue(dr.GetOrdinal("n_priceFieldNormal")).ToString();
                    priceFieldOver = dr.GetValue(dr.GetOrdinal("n_priceFieldOver")).ToString();
                    priceFacilityNormal = dr.GetValue(dr.GetOrdinal("n_priceFacilityNormal")).ToString();
                    priceFacilityOver = dr.GetValue(dr.GetOrdinal("n_priceFacilityOver")).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo precios por GTIN");
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
    }
}
