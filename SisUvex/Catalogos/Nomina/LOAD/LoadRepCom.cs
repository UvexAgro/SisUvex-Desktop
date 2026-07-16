using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SisUvex.Catalogos.Nomina.LOAD
{
    internal class LoadRepCom
    {
        private SQLControl sql = new SQLControl();

        public DataTable TablaRepCom(DateTime fechaInicio, DateTime fechaFin)
        {
            DataTable dt = new DataTable();
            try
            {
                sql.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter("SELECT id_foodRecord as 'TOTAL COMIDAS', c_codigo_emp AS 'EMPLEADO', c_dinnertype AS 'TIPO DE COMIDA', d_datetime as 'FECHA', id_dinningHall 'LUGAR', d_time 'HORA', id_dinerProvider 'COMEDOR' FROM Nom_FoodRegister WHERE d_datetime BETWEEN @FechaInicio AND @FechaFin", sql.cnn);
                da.SelectCommand.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                da.SelectCommand.Parameters.AddWithValue("@FechaFin", fechaFin);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo activos");
                return dt;
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }



    }
}
