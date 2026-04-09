using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Catalogos.Metods.Values;
using System.Data.SqlClient;
using System.Data;

namespace SisUvex.Usuarios.Role
{
    internal class EUserRole
    {
        public string? idRole { get; set; }
        public string? roleName { get; set; }
        public int active { get; set; }

        public int printLabels { get; set; }
        public int viewCatalogs { get; set; }
        public int editCatalogs { get; set; }
        public int createRecords { get; set; }
        public int productionReports { get; set; }
        public int costReports { get; set; }
        public int audit { get; set; }
        public int ownFilter { get; set; }
        public static string GetNextId()
        {
            object result = ClsQuerysDB.GetData("SELECT RIGHT('00' + CAST(ISNULL(MAX(CAST([id_role] AS INT)), 0) + 1 AS VARCHAR(2)), 2) FROM [Conf_Role]");

            return result?.ToString() ?? "01";
        }
        /* ========================= GET ========================= */
        public void GetRole(string? idRole)
        {
            if (idRole == null)
                idRole = "0";

            SQLControl sql = new SQLControl();
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Conf_Role WHERE id_role = @idRole", sql.cnn);
                cmd.Parameters.AddWithValue("@idRole", idRole);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    this.idRole = dr["id_role"].ToString();
                    roleName = dr["v_roleName"].ToString();

                    active = Convert.ToInt32(dr["c_active"]);
                    printLabels = Convert.ToInt32(dr["c_printLabels"]);
                    viewCatalogs = Convert.ToInt32(dr["c_viewCatalogs"]);
                    editCatalogs = Convert.ToInt32(dr["c_editCatalogs"]);
                    createRecords = Convert.ToInt32(dr["c_createRecords"]);
                    productionReports = Convert.ToInt32(dr["c_productionReports"]);
                    costReports = Convert.ToInt32(dr["c_costReports"]);
                    audit = Convert.ToInt32(dr["c_audit"]);
                    ownFilter = Convert.ToInt32(dr["c_ownFilter"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo de roles");
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }

        /* ========================= ADD ========================= */
        public (bool, string?) AddProcedure()
        {
            SQLControl sql = new SQLControl();
            try
            {
                sql.OpenConectionWrite();

                SqlCommand cmd = new SqlCommand("sp_ConfRoleExecute", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@action", "ADD");
                cmd.Parameters.AddWithValue("@v_roleName", roleName);
                cmd.Parameters.AddWithValue("@c_active", active);
                cmd.Parameters.AddWithValue("@c_printLabels", printLabels);
                cmd.Parameters.AddWithValue("@c_viewCatalogs", viewCatalogs);
                cmd.Parameters.AddWithValue("@c_editCatalogs", editCatalogs);
                cmd.Parameters.AddWithValue("@c_createRecords", createRecords);
                cmd.Parameters.AddWithValue("@c_productionReports", productionReports);
                cmd.Parameters.AddWithValue("@c_costReports", costReports);
                cmd.Parameters.AddWithValue("@c_audit", audit);
                cmd.Parameters.AddWithValue("@c_ownFilter", ownFilter);
                cmd.Parameters.AddWithValue("@user", User.GetUserName());

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string? id = dr["id_role"].ToString();
                    return (true, id);
                }

                return (false, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Añadir rol");
                return (false, null);
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }

        /* ========================= MODIFY ========================= */
        public (bool, string?) ModifyProcedure()
        {
            SQLControl sql = new SQLControl();
            try
            {
                sql.OpenConectionWrite();

                SqlCommand cmd = new SqlCommand("sp_ConfRoleExecute", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@action", "MODIFY");
                cmd.Parameters.AddWithValue("@id_role", idRole);
                cmd.Parameters.AddWithValue("@v_roleName", roleName);
                cmd.Parameters.AddWithValue("@c_active", active);
                cmd.Parameters.AddWithValue("@c_printLabels", printLabels);
                cmd.Parameters.AddWithValue("@c_viewCatalogs", viewCatalogs);
                cmd.Parameters.AddWithValue("@c_editCatalogs", editCatalogs);
                cmd.Parameters.AddWithValue("@c_createRecords", createRecords);
                cmd.Parameters.AddWithValue("@c_productionReports", productionReports);
                cmd.Parameters.AddWithValue("@c_costReports", costReports);
                cmd.Parameters.AddWithValue("@c_audit", audit);
                cmd.Parameters.AddWithValue("@c_ownFilter", ownFilter);
                cmd.Parameters.AddWithValue("@user", User.GetUserName());

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string? id = dr["id_role"].ToString();
                    return (true, id);
                }

                return (false, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Modificar rol");
                return (false, null);
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }

        /* ========================= STATUS ========================= */
        public static bool ActiveProcedure(string id, string active)
        {
            SQLControl sql = new SQLControl();
            try
            {
                sql.OpenConectionWrite();

                SqlCommand cmd = new SqlCommand("sp_ConfRoleExecute", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@action", "STATUS");
                cmd.Parameters.AddWithValue("@id_role", id);
                cmd.Parameters.AddWithValue("@c_active", active);
                cmd.Parameters.AddWithValue("@user", User.GetUserName());

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Activar/Desactivar rol");
                return false;
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
    }
}