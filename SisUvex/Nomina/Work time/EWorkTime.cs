using System.Data;
using System.Data.SqlClient;
using static SisUvex.Catalogos.Metods.ClsObject;

namespace SisUvex.Nomina.Work_time
{
    internal class EWorkTime
    {
        SQLControl sql = new SQLControl();
        public string idWorkTime { get; set; }
        public string idProductionLine { get; set; }
        public DateTime dateWorkTime { get; set; }
        public string idWorkGroup { get; set; }
        public DateTime dateHourBeginNormal { get; set; }
        public DateTime dateHourEndNormal { get; set; }
        public DateTime dateHourBeginExtra { get; set; }
        public DateTime dateHourEndExtra { get; set; }
        public string workers { get; set; }

        public void SetWorkTime(string IdWorkTime)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Nom_WorkTime WHERE id_workTime = '{IdWorkTime}'", sql.cnn);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    idWorkTime = dr.GetValue(dr.GetOrdinal("id_workTime")).ToString();
                    idProductionLine = dr.GetValue(dr.GetOrdinal("id_ProductionLine")).ToString();
                    idWorkGroup = dr.GetValue(dr.GetOrdinal("id_workGroup")).ToString();
                    dateWorkTime = DateTime.Parse(dr.GetValue(dr.GetOrdinal("d_workTime")).ToString());
                    dateHourBeginNormal = DateTime.Parse(dr.GetValue(dr.GetOrdinal("d_dateHourBeginNormal")).ToString());
                    dateHourEndNormal = DateTime.Parse(dr.GetValue(dr.GetOrdinal("d_dateHourEndNormal")).ToString());
                    dateHourBeginExtra = DateTime.Parse(dr.GetValue(dr.GetOrdinal("d_dateHourBeginExtra")).ToString());
                    dateHourEndExtra = DateTime.Parse(dr.GetValue(dr.GetOrdinal("d_dateHourEndExtra")).ToString());
                    workers = dr.GetValue(dr.GetOrdinal("i_workers")).ToString();

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
