using SisUvex.Catalogos.Metods;
using SisUvex.Usuarios;
using System.Data;
using System.Data.SqlClient;
using SisUvex.Catalogos.Metods.ComboBoxes;

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
            string result = ClsQuerysUsuarios.GetData("SELECT RIGHT('00' + CAST(ISNULL(MAX(CAST([id_role] AS INT)), 0) + 1 AS VARCHAR(2)), 2) FROM [Conf_Role]");

            return string.IsNullOrEmpty(result) ? "01" : result;
        }
        /* ========================= GET ========================= */
        private static int CharFlagToInt(object? value)
        {
            if (value == null || value == DBNull.Value)
                return 0;
            string? s = value.ToString();
            if (string.IsNullOrEmpty(s))
                return 0;
            return s == "1" ? 1 : 0;
        }

        public void GetRole(string? idRole)
        {
            if (idRole == null)
                idRole = "0";

            SQLControl sql = new SQLControl();
            try
            {
                sql.OpenConectionRead();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Conf_Role WHERE id_role = @idRole", sql.cnn);
                cmd.Parameters.AddWithValue("@idRole", idRole);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    this.idRole = dr["id_role"].ToString();
                    roleName = dr["v_roleName"].ToString();

                    active = CharFlagToInt(dr["c_active"]);
                    printLabels = CharFlagToInt(dr["c_printLabels"]);
                    viewCatalogs = CharFlagToInt(dr["c_viewCatalogs"]);
                    editCatalogs = CharFlagToInt(dr["c_editCatalogs"]);
                    createRecords = CharFlagToInt(dr["c_createRecords"]);
                    productionReports = CharFlagToInt(dr["c_productionReports"]);
                    costReports = CharFlagToInt(dr["c_costReports"]);
                    audit = CharFlagToInt(dr["c_audit"]);
                    ownFilter = CharFlagToInt(dr["c_ownFilter"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo de roles");
            }
            finally
            {
                sql.CloseConectionRead();
            }
        }

        /* ========================= ADD ========================= */
        public (bool, string?) AddProcedure()
        {
            SQLControl sql = new SQLControl();
            try
            {
                sql.OpenConectionRead();

                SqlCommand cmd = new SqlCommand("sp_ConfRoleExecute", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@action", "ADD");
                cmd.Parameters.AddWithValue("@v_roleName", roleName);
                cmd.Parameters.AddWithValue("@c_active", active == 1 ? "1" : "0");
                cmd.Parameters.AddWithValue("@c_printLabels", printLabels == 1 ? "1" : "0");
                cmd.Parameters.AddWithValue("@c_viewCatalogs", viewCatalogs == 1 ? "1" : "0");
                cmd.Parameters.AddWithValue("@c_editCatalogs", editCatalogs == 1 ? "1" : "0");
                cmd.Parameters.AddWithValue("@c_createRecords", createRecords == 1 ? "1" : "0");
                cmd.Parameters.AddWithValue("@c_productionReports", productionReports == 1 ? "1" : "0");
                cmd.Parameters.AddWithValue("@c_costReports", costReports == 1 ? "1" : "0");
                cmd.Parameters.AddWithValue("@c_audit", audit == 1 ? "1" : "0");
                cmd.Parameters.AddWithValue("@c_ownFilter", ownFilter == 1 ? "1" : "0");
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
                sql.CloseConectionRead();
            }
        }

        /* ========================= MODIFY ========================= */
        public (bool, string?) ModifyProcedure()
        {
            SQLControl sql = new SQLControl();
            try
            {
                sql.OpenConectionRead();

                SqlCommand cmd = new SqlCommand("sp_ConfRoleExecute", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@action", "MODIFY");
                cmd.Parameters.AddWithValue("@id_role", idRole);
                cmd.Parameters.AddWithValue("@v_roleName", roleName);
                cmd.Parameters.AddWithValue("@c_active", active == 1 ? "1" : "0");
                cmd.Parameters.AddWithValue("@c_printLabels", printLabels == 1 ? "1" : "0");
                cmd.Parameters.AddWithValue("@c_viewCatalogs", viewCatalogs == 1 ? "1" : "0");
                cmd.Parameters.AddWithValue("@c_editCatalogs", editCatalogs == 1 ? "1" : "0");
                cmd.Parameters.AddWithValue("@c_createRecords", createRecords == 1 ? "1" : "0");
                cmd.Parameters.AddWithValue("@c_productionReports", productionReports == 1 ? "1" : "0");
                cmd.Parameters.AddWithValue("@c_costReports", costReports == 1 ? "1" : "0");
                cmd.Parameters.AddWithValue("@c_audit", audit == 1 ? "1" : "0");
                cmd.Parameters.AddWithValue("@c_ownFilter", ownFilter == 1 ? "1" : "0");
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
                sql.CloseConectionRead();
            }
        }

        /* ========================= STATUS ========================= */
        public static bool ActiveProcedure(string id, string active)
        {
            SQLControl sql = new SQLControl();
            try
            {
                sql.OpenConectionRead();

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
                sql.CloseConectionRead();
            }
        }

        public static void CboLoadActives(ComboBox cbo)
        {
            string qry = $"SELECT id_role AS [{ClsObject.Column.id}], v_roleName [{ClsObject.Column.name}], c_active AS [{ClsObject.Column.active}] FROM Conf_Role";

            DataTable dt = ClsQuerysUsuarios.GetDataTable(qry);
            if (dt.Rows.Count == 0)
                return;

            if (dt.Columns.Contains(ClsObject.Column.active))
                dt.DefaultView.RowFilter = $"{ClsObject.Column.active} = '1'";

            ClsComboBoxes.LoadComboBoxDataSource(cbo, dt);
        }
    }
}