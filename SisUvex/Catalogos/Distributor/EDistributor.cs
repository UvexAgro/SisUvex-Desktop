using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Catalogos.Metods.Values;

namespace SisUvex.Catalogos.Distributor;

internal class EDistributor
{
    public string? IdDistributor { get; set; }
    /// <summary>Índice 0 = No, 1 = Sí (<c>c_active</c>).</summary>
    public int Active { get; set; }
    public string? NameDistributor { get; set; }
    public string? ShortName { get; set; }
    public string? IdUSAgency { get; set; }
    public string? IdMXAgency { get; set; }
    public string? IdGrower { get; set; }
    public string? MarketTarget { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? RFC { get; set; }
    public string? PhoneNumber { get; set; }
    public string? IdCityCrossPoint { get; set; }
    public string? IdCityDestiny { get; set; }
    public string? Country { get; set; }

    public static string GetNextId()
    {
        string result = ClsQuerysDB.GetData(
            "SELECT RIGHT('00' + CAST(ISNULL(MAX(CAST(id_distributor AS INT)), 0) + 1 AS VARCHAR(2)), 2) FROM Pack_Distributor");

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

    public void GetDistributor(string? idDistributor)
    {
        if (string.IsNullOrWhiteSpace(idDistributor))
            return;

        SQLControl sql = new();
        try
        {
            sql.OpenConectionWrite();
            SqlCommand cmd = new("SELECT * FROM Pack_Distributor WHERE id_distributor = @id", sql.cnn);
            cmd.Parameters.AddWithValue("@id", idDistributor.Trim());

            using SqlDataReader dr = cmd.ExecuteReader();
            if (!dr.Read())
                return;

            IdDistributor = ReadField(dr, "id_distributor");
            NameDistributor = ReadField(dr, "v_nameDistributor");
            IdUSAgency = ReadField(dr, "id_USAgencyTrade");
            IdMXAgency = ReadField(dr, "id_MXAgencyTrade");
            IdGrower = ReadField(dr, "id_grower");
            MarketTarget = ReadField(dr, "c_marketTarget");
            Address = ReadField(dr, "v_address");
            City = ReadField(dr, "v_city");
            RFC = ReadField(dr, "v_RFC");
            PhoneNumber = ReadField(dr, "c_phoneNumber")?.Trim();
            IdCityCrossPoint = ReadField(dr, "id_cityCrossPoint");
            IdCityDestiny = ReadField(dr, "id_cityDestiny");
            Country = ReadField(dr, "v_Country");
            ShortName = ReadField(dr, "v_nameDistShort");
            Active = CharActiveToInt(dr["c_active"]);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Obtener distribuidor");
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
            SqlCommand cmd = new("sp_PackDistributorExecute", sql.cnn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@action", "ADD");
            cmd.Parameters.AddWithValue("@id", DBNull.Value);
            cmd.Parameters.AddWithValue("@active", Active == 1 ? "1" : "0");
            cmd.Parameters.AddWithValue("@nameDistributor", NameDistributor?.Trim() ?? string.Empty);
            cmd.Parameters.AddWithValue("@idUSAgency", ClsValues.IfEmptyToDBNull(IdUSAgency?.Trim()));
            cmd.Parameters.AddWithValue("@idMXAgency", ClsValues.IfEmptyToDBNull(IdMXAgency?.Trim()));
            cmd.Parameters.AddWithValue("@idGrower", ClsValues.IfEmptyToDBNull(IdGrower?.Trim()));
            cmd.Parameters.AddWithValue("@marketTarget", MarketTarget?.Trim().Length >= 1 ? MarketTarget.Trim()[..1] : DBNull.Value);
            cmd.Parameters.AddWithValue("@address", Address?.Trim() ?? string.Empty);
            cmd.Parameters.AddWithValue("@city", City?.Trim() ?? string.Empty);
            cmd.Parameters.AddWithValue("@RFC", RFC?.Trim() ?? string.Empty);
            cmd.Parameters.AddWithValue("@phoneNumber", PhoneNumber?.Trim() ?? string.Empty);
            cmd.Parameters.AddWithValue("@idCityCrossPoint", ClsValues.IfEmptyToDBNull(IdCityCrossPoint?.Trim()));
            cmd.Parameters.AddWithValue("@idCityDestiny", ClsValues.IfEmptyToDBNull(IdCityDestiny?.Trim()));
            cmd.Parameters.AddWithValue("@country", Country?.Trim() ?? string.Empty);
            cmd.Parameters.AddWithValue("@shortName", ShortName?.Trim() ?? string.Empty);
            cmd.Parameters.AddWithValue("@user", User.GetUserName());

            using SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string? id = ReadField(dr, "id_distributor");
                return (true, id);
            }

            return (false, null);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Añadir distribuidor");
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
            SqlCommand cmd = new("sp_PackDistributorExecute", sql.cnn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@action", "MODIFY");
            cmd.Parameters.AddWithValue("@id", IdDistributor?.Trim() ?? string.Empty);
            cmd.Parameters.AddWithValue("@active", Active == 1 ? "1" : "0");
            cmd.Parameters.AddWithValue("@nameDistributor", NameDistributor?.Trim() ?? string.Empty);
            cmd.Parameters.AddWithValue("@idUSAgency", ClsValues.IfEmptyToDBNull(IdUSAgency?.Trim()));
            cmd.Parameters.AddWithValue("@idMXAgency", ClsValues.IfEmptyToDBNull(IdMXAgency?.Trim()));
            cmd.Parameters.AddWithValue("@idGrower", ClsValues.IfEmptyToDBNull(IdGrower?.Trim()));
            cmd.Parameters.AddWithValue("@marketTarget", MarketTarget?.Trim().Length >= 1 ? MarketTarget.Trim()[..1] : DBNull.Value);
            cmd.Parameters.AddWithValue("@address", Address?.Trim() ?? string.Empty);
            cmd.Parameters.AddWithValue("@city", City?.Trim() ?? string.Empty);
            cmd.Parameters.AddWithValue("@RFC", RFC?.Trim() ?? string.Empty);
            cmd.Parameters.AddWithValue("@phoneNumber", PhoneNumber?.Trim() ?? string.Empty);
            cmd.Parameters.AddWithValue("@idCityCrossPoint", ClsValues.IfEmptyToDBNull(IdCityCrossPoint?.Trim()));
            cmd.Parameters.AddWithValue("@idCityDestiny", ClsValues.IfEmptyToDBNull(IdCityDestiny?.Trim()));
            cmd.Parameters.AddWithValue("@country", Country?.Trim() ?? string.Empty);
            cmd.Parameters.AddWithValue("@shortName", ShortName?.Trim() ?? string.Empty);
            cmd.Parameters.AddWithValue("@user", User.GetUserName());

            using SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string? id = ReadField(dr, "id_distributor");
                return (true, id);
            }

            return (false, null);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Modificar distribuidor");
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
            SqlCommand cmd = new("sp_PackDistributorExecute", sql.cnn)
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
            MessageBox.Show(ex.ToString(), "Activar/Desactivar distribuidor");
            return false;
        }
        finally
        {
            sql.CloseConectionWrite();
        }
    }
}
