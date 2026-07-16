using System.Data.SqlClient;
using static SisUvex.Catalogos.Metods.ClsObject;

namespace SisUvex.Nomina.Prices.Prices
{
    internal class EPrices
    {
        SQLControl sql = new SQLControl();
        public string idPrice { get; set; }
        public string description { get; set; }
        public decimal priceFieldNormal { get; set; }
        public decimal priceFieldOver { get; set; }
        public decimal priceFacilityNormal { get; set; }
        public decimal priceFacilityOver { get; set; }

        public void SetPrice(string IdPrice)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Pack_Price WHERE id_price = '{IdPrice}'", sql.cnn);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    idPrice = dr.GetValue(dr.GetOrdinal("id_price")).ToString();
                    description = dr.GetValue(dr.GetOrdinal("v_descriptionPrice")).ToString();

                    if (decimal.TryParse(dr.GetValue(dr.GetOrdinal("n_priceFieldNormal")).ToString(), out decimal price1))
                        priceFieldNormal = price1;

                    if (decimal.TryParse(dr.GetValue(dr.GetOrdinal("n_priceFieldOver")).ToString(), out decimal price2))
                        priceFieldOver = price2;

                    if (decimal.TryParse(dr.GetValue(dr.GetOrdinal("n_priceFacilityNormal")).ToString(), out decimal price3))
                        priceFacilityNormal = price3;

                    if (decimal.TryParse(dr.GetValue(dr.GetOrdinal("n_priceFacilityOver")).ToString(), out decimal price4))
                        priceFacilityOver = price4;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo añadir");
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
    }
    
}
