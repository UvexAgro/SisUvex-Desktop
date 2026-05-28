using System.Data.SqlClient;
using System.Data;
using SisUvex.Catalogos.Metods.CheckBoxes;
using SisUvex.Nomina.Conceptos_Ingresos_Diversos;
using SisUvex.Catalogos.Metods.Querys;
using System.Media;

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
        private string idTypeBox;
        private string idNewWorkPlan; //Para se duplicada uno con el metodo DuplicateWorkPlan

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
        public string IdTypeBox
        {
            get { return idTypeBox; }
            set { idTypeBox = value; }
        }
        public bool IsWorkPlanAvailable()
        {
            string query = $"SELECT id_workPlan AS 'Count' FROM Pack_WorkPlan wpl JOIN Pack_GTIN gtn ON gtn.id_GTIN = wpl.id_GTIN JOIN Pack_Lot lot ON lot.id_lot = wpl.id_lot AND gtn.id_variety = lot.id_variety WHERE wpl.id_lot = '{idLot}' AND wpl.id_GTIN = '{idGtin}' AND wpl.d_workDay = '{workDay.ToString("yyyy-MM-dd")}' AND wpl.id_workGroup = '{idWorkGroup}' AND wpl.id_size = '{size}' AND gtn.id_variety = '{idVariety}' AND wpl.id_typeBox = '{idTypeBox}'";
            Clipboard.SetText(query);
            string result = ClsQuerysDB.GetData(query);

            if (result.Length == 0)
                return true;

            SystemSounds.Exclamation.Play();
            MessageBox.Show($"Ya existe un Plan de trabajo para esa combinación.\nPlan de trabajo: {result}", "Plan de trabajo ya existe", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
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
                    IdTypeBox = dr.GetValue(dr.GetOrdinal("id_typeBox")).ToString();
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
        public bool AddProcedure()
        {
            bool result = false;
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackWorkPlanAdd", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@active", active.ToString());
                cmd.Parameters.AddWithValue("@idLot", idLot);
                cmd.Parameters.AddWithValue("@idWorkGroup", IdWorkGroup);
                cmd.Parameters.AddWithValue("@idGtin", IdGtin);
                cmd.Parameters.AddWithValue("@voicePickCode", vpc);
                cmd.Parameters.AddWithValue("@workDay", workDay.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@idSize", size);
                cmd.Parameters.AddWithValue("@userCreate", User.GetUserName());
                cmd.Parameters.AddWithValue("@idTypeBox", idTypeBox);

                string id = cmd.ExecuteScalar().ToString();

                result = true;

                MessageBox.Show("Se agregó el plan de trabajo: " + id, "Catálogo añadir", MessageBoxButtons.OK, MessageBoxIcon.Information);

                idWorkPlan = id;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo añadir");
            }
            finally
            {
                sql.CloseConectionWrite();
            }

            return result;
        }

        public static string DuplicateWorkPlan(string idWorkPlan, string idWorkGroup)
        {
            EworkPlan eWorkPlan = new();

            eWorkPlan.SetWorkPlan(idWorkPlan);
            eWorkPlan.IdWorkGroup = idWorkGroup; //CAMBIARLE CUADRILLA AQUI.

            if (!eWorkPlan.IsWorkPlanAvailable()) //VALIDAR SI YA EXISTE
                return string.Empty;

            if (eWorkPlan.AddProcedure())
                return eWorkPlan.IdWorkPlan; //SI SE CREA, DEVUELVE EL ID NUEVO
            else
                return string.Empty;
        }
    }
}
