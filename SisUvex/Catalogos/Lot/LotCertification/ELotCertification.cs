using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Catalogos.Metods.Values;

namespace SisUvex.Catalogos.Lot.LotCertification;

internal class ELotCertification
{
    public string? IdVariety { get; set; }
    public string? IdLot { get; set; }
    /// <summary>Índice 0 = No, 1 = Sí (<c>c_active</c>).</summary>
    public int Active { get; set; }

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

    public void GetLotCertification(string? idVariety)
    {
        if (string.IsNullOrWhiteSpace(idVariety))
            return;

        SQLControl sql = new();
        try
        {
            sql.OpenConectionWrite();
            SqlCommand cmd = new("SELECT * FROM Pack_LotCertification WHERE id_variety = @id", sql.cnn);
            cmd.Parameters.AddWithValue("@id", idVariety.Trim());

            using SqlDataReader dr = cmd.ExecuteReader();
            if (!dr.Read())
                return;

            IdVariety = ReadField(dr, "id_variety");
            IdLot = ReadField(dr, "id_lot");
            Active = CharActiveToInt(dr["c_active"]);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Obtener lote certificado");
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
            SqlCommand cmd = new("sp_PackLotCertificationExecute", sql.cnn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@action", "ADD");
            cmd.Parameters.AddWithValue("@idVariety", IdVariety?.Trim() ?? string.Empty);
            cmd.Parameters.AddWithValue("@idLot", ClsValues.IfEmptyToDBNull(IdLot?.Trim()));
            cmd.Parameters.AddWithValue("@active", Active == 1 ? "1" : "0");
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
            MessageBox.Show(ex.ToString(), "Añadir lote certificado");
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
            SqlCommand cmd = new("sp_PackLotCertificationExecute", sql.cnn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@action", "MODIFY");
            cmd.Parameters.AddWithValue("@idVariety", IdVariety?.Trim() ?? string.Empty);
            cmd.Parameters.AddWithValue("@idLot", ClsValues.IfEmptyToDBNull(IdLot?.Trim()));
            cmd.Parameters.AddWithValue("@active", Active == 1 ? "1" : "0");
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
            MessageBox.Show(ex.ToString(), "Modificar lote certificado");
            return (false, null);
        }
        finally
        {
            sql.CloseConectionWrite();
        }
    }

    public static bool ActiveProcedure(string idVariety, string active)
    {
        SQLControl sql = new();
        try
        {
            sql.OpenConectionWrite();
            SqlCommand cmd = new("sp_PackLotCertificationExecute", sql.cnn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@action", "STATUS");
            cmd.Parameters.AddWithValue("@idVariety", idVariety.Trim());
            cmd.Parameters.AddWithValue("@active", active);
            cmd.Parameters.AddWithValue("@user", User.GetUserName());

            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Activar/Desactivar lote certificado");
            return false;
        }
        finally
        {
            sql.CloseConectionWrite();
        }
    }
}

