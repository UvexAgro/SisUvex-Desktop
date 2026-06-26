using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Catalogos.Metods.Values;

namespace SisUvex.Catalogos.CONTRATO.SeasonActivities;

internal class ESeasonActivities
{
    public string? IdSeasonActivity { get; set; }
    public string? NameActivities { get; set; }
    public string? IdSeasonType { get; set; }
    public string? IdUnit { get; set; }

    public static string GetNextId()
    {
        string result = ClsQuerysDB.GetData(
            "SELECT CAST(ISNULL(MAX(id_SeasonActivity), 0) + 1 AS VARCHAR(20)) FROM Payroll_SeasonActivities");

        return string.IsNullOrEmpty(result) ? "1" : result;
    }

    private static string? ReadField(SqlDataReader dr, string column)
    {
        int o = dr.GetOrdinal(column);
        if (dr.IsDBNull(o))
            return null;
        return dr.GetValue(o).ToString();
    }

    public void GetSeasonActivity(string? idSeasonActivity)
    {
        if (string.IsNullOrWhiteSpace(idSeasonActivity))
            return;

        SQLControl sql = new();
        try
        {
            sql.OpenConectionWrite();
            SqlCommand cmd = new("SELECT * FROM Payroll_SeasonActivities WHERE id_SeasonActivity = @id", sql.cnn);
            cmd.Parameters.AddWithValue("@id", idSeasonActivity.Trim());

            using SqlDataReader dr = cmd.ExecuteReader();
            if (!dr.Read())
                return;

            IdSeasonActivity = ReadField(dr, "id_SeasonActivity");
            NameActivities = ReadField(dr, "v_nameActivities");
            IdSeasonType = ReadField(dr, "id_seasonType");
            IdUnit = ReadField(dr, "id_unit");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Obtener actividad de temporada");
        }
        finally
        {
            sql.CloseConectionWrite();
        }
    }

    private void AddExecuteParameters(SqlCommand cmd, string action, string? id)
    {
        cmd.Parameters.AddWithValue("@action", action);
        cmd.Parameters.AddWithValue("@id", string.IsNullOrWhiteSpace(id) ? DBNull.Value : int.Parse(id.Trim()));
        cmd.Parameters.AddWithValue("@nameActivities", NameActivities);
        cmd.Parameters.AddWithValue("@idSeasonType", IdSeasonType);
        cmd.Parameters.AddWithValue("@idUnit", IdUnit);
        cmd.Parameters.AddWithValue("@user", User.GetUserName());
    }

    public (bool success, string? id) AddProcedure()
    {
        SQLControl sql = new();
        try
        {
            sql.OpenConectionWrite();
            SqlCommand cmd = new("sp_PayrollSeasonActivitiesExecute", sql.cnn)
            {
                CommandType = CommandType.StoredProcedure
            };
            AddExecuteParameters(cmd, "ADD", null);

            using SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string? id = ReadField(dr, "id_SeasonActivity");
                return (true, id);
            }

            return (false, null);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Añadir actividad de temporada");
            return (false, null);
        }
        finally
        {
            sql.CloseConectionWrite();
        }
    }

    public (bool success, string? id) ModifyProcedure()
    {
        SQLControl sql = new();
        try
        {
            sql.OpenConectionWrite();
            SqlCommand cmd = new("sp_PayrollSeasonActivitiesExecute", sql.cnn)
            {
                CommandType = CommandType.StoredProcedure
            };
            AddExecuteParameters(cmd, "MODIFY", IdSeasonActivity);

            using SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string? id = ReadField(dr, "id_SeasonActivity");
                return (true, id ?? IdSeasonActivity);
            }

            return (false, null);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Modificar actividad de temporada");
            return (false, null);
        }
        finally
        {
            sql.CloseConectionWrite();
        }
    }
}
