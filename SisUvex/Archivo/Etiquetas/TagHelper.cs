using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace SisUvex.Archivo.Etiquetas
{
    internal class TagHelper
    {
        SQLControl conn = new SQLControl();
        


        string voicePickCode,  vPC1, vPC2;


        public string GetVoicePickCode(String idWorkPlan)
        {
            try
            {
                conn.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("SELECT c_voicePickCode FROM Pack_WorkPlan WHERE id_workPlan = " + idWorkPlan, conn.cnn);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    voicePickCode = dr[0].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo Id siguiente");
            }
            finally
            {
                conn.CloseConectionRead();
            }
            return voicePickCode;
        }

        public DataTable GetWorkPlan(String WorkGroup)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM vw_PackContractorCat ORDER BY Activo desc, Código", conn.cnn);
                da.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo eliminados");
                return dt;
            }
            finally
            {
                conn.CloseConectionWrite();
            }
        }
    }
}
