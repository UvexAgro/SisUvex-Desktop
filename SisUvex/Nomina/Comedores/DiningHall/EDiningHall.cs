using System.Data.SqlClient;
namespace SisUvex.Nomina.Comedores.DiningHall
{
    internal class EDiningHall
    {
        private string idDiningHall;
        private string nameDiningHall;
        private string idDinerProvider;
        private int active;

        public string IdDiningHall
        {
            get { return idDiningHall; }
            set { idDiningHall = value; }
        }

        public string NameDiningHall
        {
            get { return nameDiningHall; }
            set { nameDiningHall = value; }
        }

        public string IdDinerProvider
        {
            get { return idDinerProvider; }
            set { idDinerProvider = value; }
        }

        public int Active
        {
            get { return active; }
            set { active = value; }
        }

        public void SetDiningHall(string idDiningHall)
        {
            try
            {
                SQLControl sql = new SQLControl();
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Nom_DiningHall WHERE id_dinningHall = '{idDiningHall}'", sql.cnn);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    IdDiningHall = dr.GetValue(dr.GetOrdinal("id_dinningHall")).ToString();
                    NameDiningHall = dr.GetValue(dr.GetOrdinal("v_nameDiningHall")).ToString();
                    IdDinerProvider = dr.GetValue(dr.GetOrdinal("id_dinerProvider")).ToString();
                    Active = int.Parse(dr.GetValue(dr.GetOrdinal("c_active")).ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
