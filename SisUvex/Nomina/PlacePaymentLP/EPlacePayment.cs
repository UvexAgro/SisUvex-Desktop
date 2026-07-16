using System.Data;
using System.Data.SqlClient;
using SisUvex.Catalogos.Metods.Values;

namespace SisUvex.Nomina.PlacePaymentLP;

internal class EPlacePayment
{
    public string? IdPlacePayment { get; set; }
    /// <summary>Nombre (<c>v_namePlace</c>); el SP <c>MODIFY</c> actual no lo actualiza.</summary>
    public string? NamePlace { get; set; }
    public int Active { get; set; }
    public string? IdContractor { get; set; }
    public string? IdWorkGroup { get; set; }
    public string? IdGrower { get; set; }
    public string? SisName { get; set; }
    public int OrderList { get; set; }

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

    public void GetPlacePayment(string? idPlacePayment)
    {
        if (string.IsNullOrWhiteSpace(idPlacePayment))
            return;

        SQLControl sql = new();
        try
        {
            sql.OpenConectionWrite();
            SqlCommand cmd = new("SELECT * FROM Nom_PlacePayment WHERE id_placePayment = @id", sql.cnn);
            cmd.Parameters.AddWithValue("@id", idPlacePayment.Trim());

            using SqlDataReader dr = cmd.ExecuteReader();
            if (!dr.Read())
                return;

            IdPlacePayment = ReadField(dr, "id_placePayment");
            NamePlace = ReadField(dr, "v_namePlace");
            IdContractor = ReadField(dr, "id_contractor");
            IdWorkGroup = ReadField(dr, "id_workGroup");
            IdGrower = ReadField(dr, "id_grower");
            SisName = ReadField(dr, "v_sisName");
            Active = CharActiveToInt(dr["c_activePlace"]);
            object? o = dr["i_orderList"];
            if (o == null || o == DBNull.Value)
                OrderList = 0;
            else
                OrderList = Convert.ToInt32(o);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Obtener lugar de pago");
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
            SqlCommand cmd = new("sp_NomPlacePayment_Execute", sql.cnn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@action", "MODIFY");
            cmd.Parameters.AddWithValue("@id", IdPlacePayment?.Trim() ?? string.Empty);
            cmd.Parameters.AddWithValue("@active", Active == 1 ? "1" : "0");
            cmd.Parameters.AddWithValue("@id_contractor", ClsValues.IfEmptyToDBNull(IdContractor?.Trim()));
            cmd.Parameters.AddWithValue("@id_workGroup", ClsValues.IfEmptyToDBNull(IdWorkGroup?.Trim()));
            cmd.Parameters.AddWithValue("@user", User.GetUserName());
            cmd.Parameters.AddWithValue("@id_grower", ClsValues.IfEmptyToDBNull(IdGrower?.Trim()));
            cmd.Parameters.AddWithValue("@v_sisName", ClsValues.IfEmptyToDBNull(SisName?.Trim()));
            cmd.Parameters.AddWithValue("@i_orderList", OrderList);

            using SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string? id = ReadField(dr, "id_placePayment");
                return (true, id);
            }

            return (false, null);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Modificar lugar de pago");
            return (false, null);
        }
        finally
        {
            sql.CloseConectionWrite();
        }
    }

    /// <summary>Solo envía los parámetros que usa el bloque <c>STATUS</c>; el resto queda <c>NULL</c> por defecto en el SP.</summary>
    public static bool ActiveProcedure(string id, string active)
    {
        SQLControl sql = new();
        try
        {
            sql.OpenConectionWrite();
            SqlCommand cmd = new("sp_NomPlacePayment_Execute", sql.cnn)
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
            MessageBox.Show(ex.ToString(), "Activar/Desactivar lugar de pago");
            return false;
        }
        finally
        {
            sql.CloseConectionWrite();
        }
    }

    /// <summary>Solo envía <c>@action</c>, <c>@id</c> y <c>@i_orderList</c>; el resto usa <c>NULL</c> por defecto en el SP.</summary>
    public static bool OrderProcedure(string id, int orderList)
    {
        SQLControl sql = new();
        try
        {
            sql.OpenConectionWrite();
            SqlCommand cmd = new("sp_NomPlacePayment_Execute", sql.cnn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@action", "ORDER");
            cmd.Parameters.AddWithValue("@id", id.Trim());
            cmd.Parameters.AddWithValue("@i_orderList", orderList);

            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Orden lugar de pago");
            return false;
        }
        finally
        {
            sql.CloseConectionWrite();
        }
    }
}
