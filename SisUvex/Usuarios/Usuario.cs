using SisUvex;
using System;
using System.Data.SqlClient;
using SisUvex.Configuracion;
using System.Configuration;


public static class User
{
    private static string username = "SINUSUARIO";
    private static int accessLevel = 4;
    private static DateTime currentDate = DateTime.Now.Date;
    private static ClsConfig conf = new ClsConfig();
    private static string? idUser;
    private static string? idWorkGroup;
    private static string? idContractor;
    private static string? idEmployee;
    private static string? idRole;
    private static string? active;
    private static class Permission
    {
        public static bool PrintLabels { get; set; } = false;
        public static bool ViewCatalogs { get; set; } = false;
        public static bool EditCatalogs { get; set; } = false;
        public static bool CreateRecords { get; set; } = false;
        public static bool ProductionReports { get; set; } = false;
        public static bool CostReports { get; set; } = false;
        public static bool Audit { get; set; } = false;
        public static bool OwnFilter { get; set; } = false;
        public static bool SysAdmin { get; set; } = false;
    }

    public static void SetUserInfo(string userName)
    {
        SQLControl sql = new SQLControl();

        try
        {
            sql.OpenConectionRead();

            SqlCommand cmd = new SqlCommand(@"SELECT * FROM Usuario usu LEFT JOIN Conf_Role rol ON rol.id_role = usu.id_role WHERE v_nombre_usu = @user", sql.cnn);

            cmd.Parameters.AddWithValue("@user", userName);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                // 🔹 Datos básicos
                idUser = dr["c_codigo_usu"].ToString();
                SetUserName(dr["v_nombre_usu"].ToString());
                SetAccessLevel(Convert.ToInt32(dr["c_accesibilidad_usu"]));
                currentDate = DateTime.Now.Date;
                idWorkGroup = dr["id_workGroup"].ToString();
                idContractor = dr["id_contractor"].ToString();
                idEmployee = dr["id_employee"].ToString();
                idRole = dr["id_role"].ToString();
                active = dr["c_active"].ToString();

                // 🔹 Permisos
                Permission.PrintLabels = ToBool(dr["c_printLabels"]);
                Permission.ViewCatalogs = ToBool(dr["c_viewCatalogs"]);
                Permission.EditCatalogs = ToBool(dr["c_editCatalogs"]);
                Permission.CreateRecords = ToBool(dr["c_createRecords"]);
                Permission.ProductionReports = ToBool(dr["c_productionReports"]);
                Permission.CostReports = ToBool(dr["c_costReports"]);
                Permission.Audit = ToBool(dr["c_audit"]);
                Permission.OwnFilter = ToBool(dr["c_ownFilter"]);
                Permission.SysAdmin = ToBool(dr["c_sysAdmin"]);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Obtener información de usuario");
        }
        finally
        {
            sql.CloseConectionRead();
        }
    }

    public static bool HasPrintLabelsPermission()
    {
        return Permission.PrintLabels;
    }
    public static bool HasViewCatalogsPermission()
    {
        return Permission.ViewCatalogs;
    }
    public static bool HasEditCatalogsPermission()
    {
        return Permission.EditCatalogs;
    }
    public static bool HasCreateRecordsPermission()
    {
        return Permission.CreateRecords;
    }
    public static bool HasProductionReportsPermission()
    {
        return Permission.ProductionReports;
    }
    public static bool HasCostReportsPermission()
    {
        return Permission.CostReports;
    }
    public static bool HasAuditPermission()
    {
        return Permission.Audit;
    }
    public static bool HasOwnFilterPermission()
    {
        return Permission.OwnFilter;
    }
    public static bool HasSysAdminPermission()
    {
        return Permission.SysAdmin;
    }
    public static string? GetUserId()
    {
        return idUser;
    }

    private static bool ToBool(object value)
    {
        return value != null && value.ToString() == "1";
    }

    public static string GetUserName()
    {
        return username;
    }

    public static int GetAccessLevel()
    {
        return accessLevel;
    }

    public static DateTime GetDate()
    {
        return currentDate;
    }

    public static void SetUserName(string name)
    {
        username = name;
    }

    public static void SetAccessLevel(int level)
    {
        accessLevel = level;
    }

    public static void SetDate(DateTime date)
    {
        currentDate = date.Date;
    }

    public static void SetLastUser(string usuario)
    {

        if (ClsConfig.lastLogin == usuario)
            return;

        ClsConfig.lastLogin = usuario;
        ClsXmlArchivos xml = new ClsXmlArchivos();
        xml.PutInTempFile();
        conf.Guardar();
        xml.PutInConfFile();
    }
    public static string GetLastUser()
    {
        return ClsConfig.lastLogin;
    }
    public static bool ValidateUserPassword(string user, string password)
    {
        SQLControl sql = new SQLControl();
        bool isValid = false;
        try
        {
            sql.OpenConectionRead();
            SqlCommand cmd = new SqlCommand("sp_loginCrypt", sql.cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@usuario", user);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string dbUser = dr.GetString(0);
                string dbPass = dr.GetString(1);
                if (dbUser == user && BCrypt.Net.BCrypt.Verify(password, dbPass))
                {
                    isValid = true;
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Comparar usuario y contraseña");
        }
        finally
        {
            sql.CloseConectionRead();
        }
        return isValid;
    }
}
