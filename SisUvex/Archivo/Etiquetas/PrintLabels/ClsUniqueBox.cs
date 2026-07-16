using System.Media;
using System.Data.SqlClient;
using System.Data;


namespace SisUvex.Archivo.Etiquetas.PrintLabels
{
    internal static class ClsUniqueBox
    {
        public static string CreateNewBox(string? idWorkPlan)
        {
            string? idUniqueBox = null;

            SQLControl sql = new SQLControl();

            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackedUniqueBoxAdd", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_workPlan", idWorkPlan);
                cmd.Parameters.AddWithValue("@id_userCreate", User.GetUserName());

                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    idUniqueBox = rd["UniqueBox"].ToString();
                }
            }
            catch (Exception ex)
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show(ex.ToString(), "Fallo al crear caja para el plan de trabajo");
            }
            finally
            {
                sql.CloseConectionWrite();
            }

            return idUniqueBox;
        }
    }
}
