using System.Data;
using System.Data.SqlClient;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Catalogos.Metods.Values;

namespace SisUvex.Catalogos.WorkGroup;

internal class EWorkGroup
{
    public string? IdWorkGroup { get; set; }
    public int Active { get; set; }
    public string? NameWorkGroup { get; set; }
    public string? IdContractor { get; set; }
    public string? IdSeason { get; set; }

    /// <summary>Siguiente <c>id_workGroup</c> sugerido (el alta real lo asigna <c>sp_PackWorkGroupExecute</c>).</summary>
    public static string GetNextId()
    {
        string result = ClsQuerysDB.GetData(
            "SELECT RIGHT('0000' + CAST(ISNULL(MAX(CAST(id_workGroup AS INT)), 0) + 1 AS VARCHAR(4)), 4) FROM Pack_WorkGroup");

        return string.IsNullOrEmpty(result) ? "0001" : result;
    }

    private static string? ReadField(SqlDataReader dr, string column)
    {
        int o = dr.GetOrdinal(column);
        if (dr.IsDBNull(o))
            return null;
        return dr.GetValue(o).ToString();
    }

    private static int CharActiveToInt(object? value)
    {
        if (value == null || value == DBNull.Value)
            return 0;
        string? s = value.ToString();
        return s == "1" ? 1 : 0;
    }

    public void GetWorkGroup(string? idWorkGroup)
    {
        if (string.IsNullOrWhiteSpace(idWorkGroup))
            return;

        SQLControl sql = new();
        try
        {
            sql.OpenConectionWrite();
            SqlCommand cmd = new("SELECT * FROM Pack_WorkGroup WHERE id_workGroup = @id", sql.cnn);
            cmd.Parameters.AddWithValue("@id", idWorkGroup.Trim());

            using SqlDataReader dr = cmd.ExecuteReader();
            if (!dr.Read())
                return;

            IdWorkGroup = ReadField(dr, "id_workGroup");
            NameWorkGroup = ReadField(dr, "v_nameWorkGroup");
            IdContractor = ReadField(dr, "id_contractor");
            IdSeason = ReadField(dr, "id_season");
            Active = CharActiveToInt(dr["c_active"]);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Obtener cuadrilla");
        }
        finally
        {
            sql.CloseConectionWrite();
        }
    }

    public (bool success, string? id) AddProcedure()
    {
        SQLControl sql = new();
        try
        {
            sql.OpenConectionWrite();
            SqlCommand cmd = new("sp_PackWorkGroupExecute", sql.cnn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@action", "ADD");
            cmd.Parameters.AddWithValue("@id", DBNull.Value);
            cmd.Parameters.AddWithValue("@active", Active == 1 ? "1" : "0");
            cmd.Parameters.AddWithValue("@name", NameWorkGroup?.Trim() ?? string.Empty);
            cmd.Parameters.AddWithValue("@idContractor", IdContractor?.Trim() ?? string.Empty);
            cmd.Parameters.AddWithValue("@idSeason", IdSeason?.Trim() ?? string.Empty);
            cmd.Parameters.AddWithValue("@user", User.GetUserName());

            using SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string? id = ReadField(dr, "id_workGroup");
                return (true, id);
            }

            return (false, null);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Añadir cuadrilla");
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
            SqlCommand cmd = new("sp_PackWorkGroupExecute", sql.cnn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@action", "MODIFY");
            cmd.Parameters.AddWithValue("@id", IdWorkGroup?.Trim() ?? string.Empty);
            cmd.Parameters.AddWithValue("@active", Active == 1 ? "1" : "0");
            cmd.Parameters.AddWithValue("@name", NameWorkGroup?.Trim() ?? string.Empty);
            cmd.Parameters.AddWithValue("@idContractor", IdContractor?.Trim() ?? string.Empty);
            cmd.Parameters.AddWithValue("@idSeason", IdSeason?.Trim() ?? string.Empty);
            cmd.Parameters.AddWithValue("@user", User.GetUserName());

            using SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string? id = ReadField(dr, "id_workGroup");
                return (true, id);
            }

            return (false, null);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Modificar cuadrilla");
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
            SqlCommand cmd = new("sp_PackWorkGroupExecute", sql.cnn)
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
            MessageBox.Show(ex.ToString(), "Activar/Desactivar cuadrilla");
            return false;
        }
        finally
        {
            sql.CloseConectionWrite();
        }
    }
}
