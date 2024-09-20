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
