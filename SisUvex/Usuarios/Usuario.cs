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
    }

    public static void SetUserInfo(string user)
    {
        SQLControl sql = new SQLControl();

        try
        {
            sql.OpenConectionRead();

            SqlCommand cmd = new SqlCommand(@"SELECT * FROM Usuarios WHERE c_codigo_usu = @user", sql.cnn);

            cmd.Parameters.AddWithValue("@user", user);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                // 🔹 Datos básicos
                username = dr["c_codigo_usu"].ToString();
                SetUserName(dr["v_nombre_usu"].ToString());
                SetAccessLevel(Convert.ToInt32(dr["c_accesibilidad_usu"]));
                currentDate = DateTime.Now.Date;
                idWorkGroup = dr["id_workGroup"].ToString();
                idContractor = dr["id_contractor"].ToString();
                idEmployee = dr["id_employee"].ToString();
                idRole = dr["id_role"].ToString();
                active = dr["c_active"].ToString();

                // 🔹 Permisos
                Permission.PrintLabels = ToBool(dr["PrintLabels"]);
                Permission.ViewCatalogs = ToBool(dr["ViewCatalogs"]);
                Permission.EditCatalogs = ToBool(dr["EditCatalogs"]);
                Permission.CreateRecords = ToBool(dr["CreateRecords"]);
                Permission.ProductionReports = ToBool(dr["ProductionReports"]);
                Permission.CostReports = ToBool(dr["CostReports"]);
                Permission.Audit = ToBool(dr["Audit"]);
                Permission.OwnFilter = ToBool(dr["OwnFilter"]);
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

    public static void SetProductDay()
    {
        SQLControl sql = new SQLControl();

        try
        {
            sql.OpenConectionWrite();
            SqlCommand cmd = new SqlCommand("SELECT d_productionDay 'Day' FROM Pack_ProductionDay", sql.cnn);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                DateTime productionDay = Convert.ToDateTime(dr["Day"]);
                SetDate(productionDay);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Obtener día de producción");
        }
        finally
        {
            sql.CloseConectionRead();
        }
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
}
