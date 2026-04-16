using System.Data;
using System.Data.SqlClient;

namespace SisUvex.Usuarios;

/// <summary>
/// Consultas contra la base configurada en <c>dbConn</c> (misma que login y tabla de usuarios),
/// no contra <c>dbWrite</c> de la aplicación.
/// </summary>
internal static class ClsQuerysUsuarios
{
    public static DataTable GetDataTable(string query)
    {
        DataTable dataTable = new();
        SQLControl sql = new();
        try
        {
            sql.OpenConectionRead();
            SqlDataAdapter dataAdapter = new(query, sql.cnn);
            dataAdapter.Fill(dataTable);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Consulta (base de usuarios)");
        }
        finally
        {
            sql.CloseConectionRead();
        }

        return dataTable;
    }

    public static string GetData(string query)
    {
        string dato = string.Empty;
        SQLControl sql = new();
        try
        {
            sql.OpenConectionRead();
            SqlCommand cmd = new(query, sql.cnn);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                if (!reader.IsDBNull(0))
                    dato = reader[0].ToString() ?? string.Empty;
            }

            reader.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Consulta (base de usuarios)");
            return string.Empty;
        }
        finally
        {
            sql.CloseConectionRead();
        }

        return dato;
    }
}
