using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisUvex.Archivo.Manifiesto
{
    internal class ClsQueryLoadingMap
    {
        SQLControl sql = new SQLControl();

        //Datos generales del Mapa de Carga

        public DataTable dtLaodingMap { get; set; }

        public ClsQueryLoadingMap()
        {
            dtLaodingMap = new DataTable();

        }


        public void GetLoadingMapData(string manifestNumber)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("SELECT * FROM vw_PackPalletsManifest WHERE Manifiesto = @manifestNumber ORDER BY Pos,Estiba", sql.cnn);
                cmd.Parameters.AddWithValue("@manifestNumber", manifestNumber);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtLaodingMap);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sql.CloseConectionWrite();
            }

        }

  

    }
}
