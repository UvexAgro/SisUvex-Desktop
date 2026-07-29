using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Catalogos.Metods.Values;
using System.Data;
using System.Data.SqlClient;
using System.Media;
using System.Windows.Forms;
using static SisUvex.Catalogos.Metods.ClsObject;

namespace SisUvex.Archivo.WorkPlan
{
    internal class EworkPlan
    {
        SQLControl sql = new SQLControl();

        public string IdWorkPlan { get; set; } = string.Empty;
        public string IdLot { get; set; } = string.Empty;
        public string IdVariety { get; set; } = string.Empty;
        public string IdWorkGroup { get; set; } = string.Empty;
        public string VPC { get; set; } = string.Empty;
        public DateTime WorkDay { get; set; }
        public string Size { get; set; } = string.Empty;
        public int Active { get; set; }
        public string IdGtin { get; set; } = string.Empty;
        public string IdTypeBox { get; set; } = string.Empty;
        public string? IdLabelLegend { get; set; }

        public static string GetNextId()
        {
            return ClsQuerysDB.GetData("SELECT FORMAT(COALESCE(MAX(id_workPlan), 0) + 1, '0000') FROM Pack_WorkPlan").ToString();
        }

        private static string? ReadField(SqlDataReader dr, string column)
        {
            int o = dr.GetOrdinal(column);
            if (dr.IsDBNull(o))
                return null;
            return dr.GetValue(o).ToString();
        }

        public bool IsWorkPlanAvailable(string? excludeWorkPlanId = null)
        {
            string idLabelLegendFilter = string.IsNullOrEmpty(IdLabelLegend) ? "IS NULL" : $" = '{IdLabelLegend}'";


            string query = $"SELECT id_workPlan AS 'Count' FROM Pack_WorkPlan wpl JOIN Pack_GTIN gtn ON gtn.id_GTIN = wpl.id_GTIN JOIN Pack_Lot lot ON lot.id_lot = wpl.id_lot AND gtn.id_variety = lot.id_variety WHERE wpl.id_lot = '{IdLot}' AND wpl.id_GTIN = '{IdGtin}' AND wpl.d_workDay = '{WorkDay:yyyy-MM-dd}' AND wpl.id_workGroup = '{IdWorkGroup}' AND wpl.id_size = '{Size}' AND gtn.id_variety = '{IdVariety}' AND wpl.id_typeBox = '{IdTypeBox}' AND wpl.id_labelLegend {idLabelLegendFilter}";

            string result = ClsQuerysDB.GetData(query);
            Clipboard.SetText(query);
            if (result.Length == 0)
                return true;

            if (!string.IsNullOrEmpty(excludeWorkPlanId) && result == excludeWorkPlanId)
                return true;

            SystemSounds.Exclamation.Play();
            MessageBox.Show($"Ya existe un Plan de trabajo para esa combinación.\n\tPlan de trabajo: {result}", "Plan de trabajo ya existe", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        public void SetWorkPlan(string idWorkPlan)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new(
                    "SELECT wpl.*, gtn.id_variety FROM Pack_WorkPlan wpl JOIN Pack_GTIN gtn ON gtn.id_GTIN = wpl.id_GTIN WHERE wpl.id_workPlan = @id",
                    sql.cnn);
                cmd.Parameters.AddWithValue("@id", idWorkPlan);

                using SqlDataReader dr = cmd.ExecuteReader();
                if (!dr.Read())
                    return;

                IdWorkPlan = ReadField(dr, "id_workPlan") ?? string.Empty;
                Active = int.Parse(ReadField(dr, "c_active") ?? "0");
                IdWorkGroup = ReadField(dr, "id_workGroup") ?? string.Empty;
                IdLot = ReadField(dr, "id_lot") ?? string.Empty;
                IdVariety = ReadField(dr, "id_variety") ?? string.Empty;
                IdGtin = ReadField(dr, "id_GTIN") ?? string.Empty;
                VPC = ReadField(dr, "c_voicePickCode") ?? string.Empty;
                WorkDay = DateTime.Parse(ReadField(dr, "d_workDay") ?? DateTime.Today.ToString());
                Size = ReadField(dr, "id_size") ?? string.Empty;
                IdTypeBox = ReadField(dr, "id_typeBox") ?? string.Empty;
                IdLabelLegend = ReadField(dr, "id_labelLegend");
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

        private void AddExecuteParameters(SqlCommand cmd, string action, string? id)
        {
            cmd.Parameters.AddWithValue("@action", action);
            cmd.Parameters.AddWithValue("@id", string.IsNullOrWhiteSpace(id) ? DBNull.Value : id.Trim());
            cmd.Parameters.AddWithValue("@active", Active == 1 ? "1" : "0");
            cmd.Parameters.AddWithValue("@idLot", IdLot);
            cmd.Parameters.AddWithValue("@idWorkGroup", IdWorkGroup);
            cmd.Parameters.AddWithValue("@idGtin", IdGtin);
            cmd.Parameters.AddWithValue("@voicePickCode", VPC);
            cmd.Parameters.AddWithValue("@workDay", WorkDay.Date);
            cmd.Parameters.AddWithValue("@idSize", Size);
            cmd.Parameters.AddWithValue("@idTypeBox", ClsValues.IfEmptyToDBNull(IdTypeBox));
            cmd.Parameters.AddWithValue("@idLabelLegend", ClsValues.IfEmptyToDBNull(IdLabelLegend));
            cmd.Parameters.AddWithValue("@user", User.GetUserName());
        }

        public (bool success, string? id) AddProcedure()
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new("sp_PackWorkPlanExecute", sql.cnn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                AddExecuteParameters(cmd, "ADD", null);

                using SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string? id = ReadField(dr, "id_workPlan");
                    if (!string.IsNullOrEmpty(id))
                    {
                        IdWorkPlan = id;
                        return (true, id);
                    }
                }

                return (false, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo añadir");
                return (false, null);
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }

        public (bool success, string? id) ModifyProcedure()
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new("sp_PackWorkPlanExecute", sql.cnn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                AddExecuteParameters(cmd, "MODIFY", IdWorkPlan);

                using SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string? id = ReadField(dr, "id_workPlan");
                    return (true, id ?? IdWorkPlan);
                }

                return (false, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo modificar");
                return (false, null);
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }

        public static bool ActiveProcedure(string id, string active)
        {
            SQLControl sql = new();
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new("sp_PackWorkPlanExecute", sql.cnn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@action", "STATUS");
                cmd.Parameters.AddWithValue("@id", id.Trim());
                cmd.Parameters.AddWithValue("@active", active);
                cmd.Parameters.AddWithValue("@user", User.GetUserName());

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Activar/Desactivar plan de trabajo");
                return false;
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }

        public static string DuplicateWorkPlan(string idWorkPlan, string idWorkGroup)
        {
            EworkPlan eWorkPlan = new();
            eWorkPlan.SetWorkPlan(idWorkPlan);
            eWorkPlan.IdWorkGroup = idWorkGroup;

            if (!eWorkPlan.IsWorkPlanAvailable())
                return string.Empty;

            var result = eWorkPlan.AddProcedure();
            if (result.success)
                return result.id ?? string.Empty;

            return string.Empty;
        }
    }
}
