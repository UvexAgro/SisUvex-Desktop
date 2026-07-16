using System.Data.SqlClient;
using System.Data;
using SisUvex.Catalogos.Metods;

namespace SisUvex.Archivo.Etiquetas.PrintLabels
{
    internal class ClsPalletCreate
    {
        static SQLControl sql = new SQLControl();

        public static string InsertPallet(int boxes, string workPlan, DateTime date, string paperWork)
        {
            string idPallet = string.Empty;
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackPalletAdd", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@boxes", boxes);
                cmd.Parameters.AddWithValue("@idWorkPlan", workPlan);
                cmd.Parameters.AddWithValue("@dPacked", date.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@userCreate", User.GetUserName());
                cmd.Parameters.AddWithValue("@invoice", paperWork);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                    idPallet = reader[0].ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                sql.CloseConectionWrite();
            }
            return idPallet;
        }

        public static string UpdatePallet(string idPallet, int boxes)
        {
            try
            {
                sql.OpenConectionWrite();

                SqlCommand cmd = new SqlCommand("sp_PackPalletUpdate", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idPallet", idPallet);
                cmd.Parameters.AddWithValue("@boxes", boxes);
                cmd.Parameters.AddWithValue("@user", User.GetUserName());

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                    idPallet = reader[0].ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                sql.CloseConectionWrite();
            }
            return idPallet;
        }
    }
}