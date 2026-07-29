using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Catalogos.Metods.Values;

namespace SisUvex.Catalogos.Variety;

internal class EVariety
{
    public string? IdVariety { get; set; }
    /// <summary>Índice 0 = No, 1 = Sí (<c>c_active</c>).</summary>
    public int Active { get; set; }
    public string? NameScientis { get; set; }
    public string? NameComercial { get; set; }
    public string? ShortName { get; set; }
    public string? PatentLegend { get; set; }
    public string? Trademark { get; set; }
    public string? IdColor { get; set; }
    public string? IdCrop { get; set; }
    public string? IdGrower { get; set; }
    /// <summary>0 = No, 1 = Sí (<c>c_useFacility</c>).</summary>
    public int UseFacility { get; set; }

    public static string GetNextId()
    {
        string result = ClsQuerysDB.GetData(
            "SELECT RIGHT('00' + CAST(ISNULL(MAX(CAST(id_variety AS INT)), 0) + 1 AS VARCHAR(2)), 2) FROM Pack_Variety");

        return string.IsNullOrEmpty(result) ? "01" : result;
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

    public void GetVariety(string? idVariety)
    {
        if (string.IsNullOrWhiteSpace(idVariety))
            return;

        SQLControl sql = new();
        try
        {
            sql.OpenConectionWrite();
            SqlCommand cmd = new("SELECT * FROM Pack_Variety WHERE id_variety = @id", sql.cnn);
            cmd.Parameters.AddWithValue("@id", idVariety.Trim());

            using SqlDataReader dr = cmd.ExecuteReader();
            if (!dr.Read())
                return;

            IdVariety = ReadField(dr, "id_variety");
            NameScientis = ReadField(dr, "v_nameScientis");
            NameComercial = ReadField(dr, "v_nameComercial");
            ShortName = ReadField(dr, "v_shortName");
            PatentLegend = ReadField(dr, "v_patentLegend");
            Trademark = ReadField(dr, "v_trademark");
            IdColor = ReadField(dr, "id_color");
            IdCrop = ReadField(dr, "id_crop");
            IdGrower = ReadField(dr, "id_grower");
            UseFacility = CharActiveToInt(dr["c_useFacility"]);
            Active = CharActiveToInt(dr["c_active"]);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Obtener variedad");
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
            SqlCommand cmd = new("sp_PackVarietyExecute", sql.cnn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@action", "ADD");
            cmd.Parameters.AddWithValue("@id", DBNull.Value);
            cmd.Parameters.AddWithValue("@active", Active == 1 ? "1" : "0");
            cmd.Parameters.AddWithValue("@nameScientis", ClsValues.IfEmptyToDBNull(NameScientis?.Trim()));
            cmd.Parameters.AddWithValue("@nameComercial", NameComercial?.Trim() ?? string.Empty);
            cmd.Parameters.AddWithValue("@idColor", IdColor?.Trim() ?? string.Empty);
            cmd.Parameters.AddWithValue("@idCrop", IdCrop?.Trim() ?? string.Empty);
            cmd.Parameters.AddWithValue("@idGrower", ClsValues.IfEmptyToDBNull(IdGrower?.Trim()));
            cmd.Parameters.AddWithValue("@useFacility", UseFacility == 1 ? "1" : "0");
            cmd.Parameters.AddWithValue("@shortName", ClsValues.IfEmptyToDBNull(ShortName?.Trim()));
            cmd.Parameters.AddWithValue("@patentLegend", ClsValues.IfEmptyToDBNull(PatentLegend?.Trim()));
            cmd.Parameters.AddWithValue("@trademark", ClsValues.IfEmptyToDBNull(Trademark?.Trim()));
            cmd.Parameters.AddWithValue("@user", User.GetUserName());

            using SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string? id = ReadField(dr, "id_variety");
                return (true, id);
            }

            return (false, null);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Añadir variedad");
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
            SqlCommand cmd = new("sp_PackVarietyExecute", sql.cnn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@action", "MODIFY");
            cmd.Parameters.AddWithValue("@id", IdVariety?.Trim() ?? string.Empty);
            cmd.Parameters.AddWithValue("@active", Active == 1 ? "1" : "0");
            cmd.Parameters.AddWithValue("@nameScientis", ClsValues.IfEmptyToDBNull(NameScientis?.Trim()));
            cmd.Parameters.AddWithValue("@nameComercial", NameComercial?.Trim() ?? string.Empty);
            cmd.Parameters.AddWithValue("@idColor", IdColor?.Trim() ?? string.Empty);
            cmd.Parameters.AddWithValue("@idCrop", IdCrop?.Trim() ?? string.Empty);
            cmd.Parameters.AddWithValue("@idGrower", ClsValues.IfEmptyToDBNull(IdGrower?.Trim()));
            cmd.Parameters.AddWithValue("@useFacility", UseFacility == 1 ? "1" : "0");
            cmd.Parameters.AddWithValue("@shortName", ClsValues.IfEmptyToDBNull(ShortName?.Trim()));
            cmd.Parameters.AddWithValue("@patentLegend", ClsValues.IfEmptyToDBNull(PatentLegend?.Trim()));
            cmd.Parameters.AddWithValue("@trademark", ClsValues.IfEmptyToDBNull(Trademark?.Trim()));
            cmd.Parameters.AddWithValue("@user", User.GetUserName());

            using SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string? id = ReadField(dr, "id_variety");
                return (true, id);
            }

            return (false, null);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Modificar variedad");
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
            SqlCommand cmd = new("sp_PackVarietyExecute", sql.cnn)
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
            MessageBox.Show(ex.ToString(), "Activar/Desactivar variedad");
            return false;
        }
        finally
        {
            sql.CloseConectionWrite();
        }
    }
}
