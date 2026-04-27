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
        public decimal overTime { get; set; }
		// 🔹 BREAK
		public TimeSpan t_BreakStart { get; set; }
		public TimeSpan t_BreakEnd { get; set; }
		public decimal d_BreakHours { get; set; }

		// 🔹 LUNCH
		public TimeSpan t_LunchStart { get; set; }
		public TimeSpan t_LunchEnd { get; set; }
		public decimal d_LunchHours { get; set; }

		// 🔹 DINNER
		public TimeSpan t_DinnerStart { get; set; }
		public TimeSpan t_DinnerEnd { get; set; }
		public decimal d_DinnerHours { get; set; }

		// 🔹 BREAK2
		public TimeSpan t_BreakStart2 { get; set; }
		public TimeSpan t_BreakEnd2 { get; set; }
		public decimal d_BreakHours2 { get; set; }

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
                    overTime = decimal.Parse(dr["d_overtime"].ToString());
					//  BREAK
					t_BreakStart = dr["t_BreakStart"] != DBNull.Value ? (TimeSpan)dr["t_BreakStart"] : TimeSpan.Zero;
					t_BreakEnd = dr["t_BreakEnd"] != DBNull.Value ? (TimeSpan)dr["t_BreakEnd"] : TimeSpan.Zero;
					d_BreakHours = dr["d_BreakHours"] != DBNull.Value ? Convert.ToDecimal(dr["d_BreakHours"]) : 0;

					//  LUNCH
					t_LunchStart = dr["t_LunchStart"] != DBNull.Value ? (TimeSpan)dr["t_LunchStart"] : TimeSpan.Zero;
					t_LunchEnd = dr["t_LunchEnd"] != DBNull.Value ? (TimeSpan)dr["t_LunchEnd"] : TimeSpan.Zero;
					d_LunchHours = dr["d_LunchHours"] != DBNull.Value ? Convert.ToDecimal(dr["d_LunchHours"]) : 0;

					// DINNER
					t_DinnerStart = dr["t_DinnerStart"] != DBNull.Value ? (TimeSpan)dr["t_DinnerStart"] : TimeSpan.Zero;
					t_DinnerEnd = dr["t_DinnerEnd"] != DBNull.Value ? (TimeSpan)dr["t_DinnerEnd"] : TimeSpan.Zero;
					d_DinnerHours = dr["d_DinnerHours"] != DBNull.Value ? Convert.ToDecimal(dr["d_DinnerHours"]) : 0;

					// BREAK2
					t_BreakStart = dr["t_BreakStart2"] != DBNull.Value ? (TimeSpan)dr["t_BreakStart"] : TimeSpan.Zero;
					t_BreakEnd = dr["t_BreakEnd2"] != DBNull.Value ? (TimeSpan)dr["t_BreakEnd"] : TimeSpan.Zero;
					d_BreakHours = dr["d_BreakHours2"] != DBNull.Value ? Convert.ToDecimal(dr["d_BreakHours"]) : 0;


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
