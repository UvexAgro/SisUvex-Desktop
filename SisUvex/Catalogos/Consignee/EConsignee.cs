using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Catalogos.Metods.Values;

namespace SisUvex.Catalogos.Consignee;

internal class EConsignee
{
    public string? IdConsignee { get; set; }
    /// <summary>Índice 0 = No, 1 = Sí (<c>c_active</c>).</summary>
    public int Active { get; set; }
    public string? NameConsignee { get; set; }
    public string? IdDistributor { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
    public string? RFC { get; set; }
    public string? taxId { get; set; }
    public string? PhoneNumber { get; set; }

    public static string GetNextId()
    {
        string result = ClsQuerysDB.GetData(
            "SELECT RIGHT('00' + CAST(ISNULL(MAX(CAST(id_consignee AS INT)), 0) + 1 AS VARCHAR(2)), 2) FROM Pack_Consignee");

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

    public void GetConsignee(string? idConsignee)
    {
        if (string.IsNullOrWhiteSpace(idConsignee))
            return;

        SQLControl sql = new();
        try
        {
            sql.OpenConectionWrite();
            SqlCommand cmd = new("SELECT * FROM Pack_Consignee WHERE id_consignee = @id", sql.cnn);
            cmd.Parameters.AddWithValue("@id", idConsignee.Trim());

            using SqlDataReader dr = cmd.ExecuteReader();
            if (!dr.Read())
                return;

            IdConsignee = ReadField(dr, "id_consignee");
            NameConsignee = ReadField(dr, "v_nameConsignee");
            IdDistributor = ReadField(dr, "id_distributor");
            Address = ReadField(dr, "v_address");
            City = ReadField(dr, "v_city");
            Country = ReadField(dr, "v_country");
            RFC = ReadField(dr, "v_RFC");
            taxId = ReadField(dr, "v_taxId");
            PhoneNumber = ReadField(dr, "c_phoneNumer")?.Trim();
            Active = CharActiveToInt(dr["c_active"]);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Obtener consignatario");
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
            SqlCommand cmd = new("sp_PackConsigneeExecute", sql.cnn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@action", "ADD");
            cmd.Parameters.AddWithValue("@id", DBNull.Value);
            cmd.Parameters.AddWithValue("@active", Active == 1 ? "1" : "0");
            cmd.Parameters.AddWithValue("@nameConsignee", NameConsignee);
            cmd.Parameters.AddWithValue("@idDistributor", ClsValues.IfEmptyToDBNull(IdDistributor));
            cmd.Parameters.AddWithValue("@address", Address);
            cmd.Parameters.AddWithValue("@city", City);
            cmd.Parameters.AddWithValue("@country", Country);
            cmd.Parameters.AddWithValue("@RFC", RFC);
            cmd.Parameters.AddWithValue("@taxId", taxId);
            cmd.Parameters.AddWithValue("@phoneNumber", PhoneNumber);
            cmd.Parameters.AddWithValue("@user", User.GetUserName());

            using SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string? id = ReadField(dr, "id_consignee");
                return (true, id);
            }

            return (false, null);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Añadir consignatario");
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
            SqlCommand cmd = new("sp_PackConsigneeExecute", sql.cnn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@action", "MODIFY");
            cmd.Parameters.AddWithValue("@id", IdConsignee);
            cmd.Parameters.AddWithValue("@active", Active == 1 ? "1" : "0");
            cmd.Parameters.AddWithValue("@nameConsignee", NameConsignee);
            cmd.Parameters.AddWithValue("@idDistributor", ClsValues.IfEmptyToDBNull(IdDistributor));
            cmd.Parameters.AddWithValue("@address", Address);
            cmd.Parameters.AddWithValue("@city", City);
            cmd.Parameters.AddWithValue("@country", Country);
            cmd.Parameters.AddWithValue("@RFC", RFC);
            cmd.Parameters.AddWithValue("@taxId", taxId);
            cmd.Parameters.AddWithValue("@phoneNumber", PhoneNumber);
            cmd.Parameters.AddWithValue("@user", User.GetUserName());

            using SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string? id = ReadField(dr, "id_consignee");
                return (true, id);
            }

            return (false, null);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Modificar consignatario");
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
            SqlCommand cmd = new("sp_PackConsigneeExecute", sql.cnn)
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
            MessageBox.Show(ex.ToString(), "Activar/Desactivar consignatario");
            return false;
        }
        finally
        {
            sql.CloseConectionWrite();
        }
    }
}
