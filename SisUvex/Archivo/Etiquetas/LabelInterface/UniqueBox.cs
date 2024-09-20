using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisUvex.Archivo.Etiquetas.LabelInterface
{
    internal class UniqueBox
    {
        SQLControl sql = new SQLControl();
        public string UniqueBoxqrCode { get; set; }


        public void CrearCajaEmpleado(string WorkPlan, string UserCreate)
        {
            try
            {
                sql.OpenConectionWrite();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("sp_PackedUniqueBoxAdd", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_workPlan",WorkPlan);
                cmd.Parameters.AddWithValue("@id_userCreate", User.GetUserName());

                //SqlDataAdapter da = new SqlDataAdapter(cmd);
                //DataTable ds = new DataTable();
                //da.Fill(dt);

                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    UniqueBoxqrCode = rd["UniqueBox"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fallo al crear caja para el plan de trabajo");
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
    }
}
