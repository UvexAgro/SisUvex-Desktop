using System.Data.SqlClient;

namespace SisUvex.Catalogos.WorkGroup
{
    internal class EWorkGroup
    {
        private string idWorkGroup { get; set; }
        private string idContractor { get; set; }
        private int active { get; set; }
        private string nameWorkGroup { get; set; }
        private string idSeason { get; set; }

        public string IdWorkGroup
        {
            get { return idWorkGroup; }
            set { idWorkGroup = value; }
        }
        public string IdContractor
        {
            get { return idContractor; }
            set { idContractor = value; }
        }
        public int Active
        {
            get { return active; }
            set { active = value; }
        }
        public string NameWorkGroup
        {
            get { return nameWorkGroup; }
            set { nameWorkGroup = value; }
        }
        public string IdSeason
        {
            get { return idSeason; }
            set { idSeason = value; }
        }

        public void SetWorkGroup(string idWorkGroup)
        {
            SQLControl sql = new SQLControl();

            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Pack_WorkGroup WHERE id_workGroup = @idWorkGroup", sql.cnn);
                cmd.Parameters.AddWithValue("@idWorkGroup", idWorkGroup);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    IdWorkGroup = dr.GetValue(dr.GetOrdinal("id_workGroup")).ToString();
                    IdContractor = dr.GetValue(dr.GetOrdinal("id_contractor")).ToString();
                    Active = int.Parse(dr.GetValue(dr.GetOrdinal("c_active")).ToString());
                    NameWorkGroup = dr.GetValue(dr.GetOrdinal("v_nameWorkGroup")).ToString();
                    IdSeason = dr.GetValue(dr.GetOrdinal("id_season")).ToString();
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
