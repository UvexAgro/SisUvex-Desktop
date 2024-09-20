using System.Data.SqlClient;
using System.Data;

namespace SisUvex.Archivo.WorkPlan
{
    internal class EworkPlan
    {
         SQLControl sql = new SQLControl();

        private string idWorkPlan;
        private string idLot;
        private string idVariety;
        private string idWorkGroup;
        private string vpc;
        private DateTime workDay;
        private string size;
        private int active;
        private string materialPallet;
        private string idGtin;

        public string IdWorkPlan
        {
            get { return idWorkPlan; }
            set { idWorkPlan = value; }
        }
        public string IdLot
        {
            get { return idLot; }
            set { idLot = value; }
        }
        public string IdVariety
        {
            get { return idVariety; }
            set { idVariety = value; }
        }
        public string IdWorkGroup
        {
            get { return idWorkGroup; }
            set { idWorkGroup = value; }
        }
        public string VPC
        {
            get { return vpc; }
            set { vpc = value; }
        }
        public DateTime WorkDay
        {
            get { return workDay; }
            set { workDay = value; }
        }
        public string Size
        {
            get { return size; }
            set { size = value; }
        }
        public int Active
        {
            get { return active; }
            set { active = value; }
        }
        public string MaterialPallet
        {
            get { return materialPallet; }
            set { materialPallet = value; }
        }
        public string IdGtin
        {
            get { return idGtin; }
            set { idGtin = value; }
        }

        public void SetWorkPlan(string idWorkPlan)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand($"SELECT wpl.*, gtn.id_variety FROM Pack_WorkPlan wpl JOIN Pack_GTIN gtn ON gtn.id_GTIN = wpl.id_GTIN WHERE wpl.id_workPLan = '{idWorkPlan}'", sql.cnn);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    IdWorkPlan = dr.GetValue(dr.GetOrdinal("id_workPlan")).ToString();
                    Active = int.Parse(dr.GetValue(dr.GetOrdinal("c_active")).ToString());
                    IdWorkGroup = dr.GetValue(dr.GetOrdinal("id_workGroup")).ToString();
                    IdLot = dr.GetValue(dr.GetOrdinal("id_lot")).ToString();
                    idVariety = dr.GetValue(dr.GetOrdinal("id_variety")).ToString();
                    IdGtin = dr.GetValue(dr.GetOrdinal("id_GTIN")).ToString();
                    VPC = dr.GetValue(dr.GetOrdinal("c_voicePickCode")).ToString();
                    WorkDay = DateTime.Parse(dr.GetValue(dr.GetOrdinal("d_workDay")).ToString());
                    Size = dr.GetValue(dr.GetOrdinal("id_size")).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo modificar");
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
    }
}
