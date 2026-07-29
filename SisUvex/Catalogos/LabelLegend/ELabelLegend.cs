using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Catalogos.Metods.Values;

namespace SisUvex.Catalogos.LabelLegend;

internal class ELabelLegend
{
    public string? IdLabelLegend { get; set; }
    /// <summary>Índice 0 = No, 1 = Sí (<c>c_active</c>).</summary>
    public int Active { get; set; }
    public string? LabelLegend { get; set; }
    public string? LabelLegend2 { get; set; }
    public string? Description { get; set; }

    public static string GetNextId()
    {
        string result = ClsQuerysDB.GetData(
            "SELECT RIGHT('000' + CAST(ISNULL(MAX(CAST(id_labelLegend AS INT)), 0) + 1 AS VARCHAR(3)), 3) FROM Pack_LabelLegend");

        return string.IsNullOrEmpty(result) ? "001" : result;
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
        return value.ToString() == "1" ? 1 : 0;
    }

    public void GetLabelLegend(string? idLabelLegend)
    {
        if (string.IsNullOrWhiteSpace(idLabelLegend))
            return;

        SQLControl sql = new();
        try
        {
            sql.OpenConectionWrite();
            SqlCommand cmd = new("SELECT * FROM Pack_LabelLegend WHERE id_labelLegend = @id", sql.cnn);
            cmd.Parameters.AddWithValue("@id", idLabelLegend.Trim());

            using SqlDataReader dr = cmd.ExecuteReader();
            if (!dr.Read())
                return;

            IdLabelLegend = ReadField(dr, "id_labelLegend");
            LabelLegend = ReadField(dr, "v_labelLegend");
            LabelLegend2 = ReadField(dr, "v_labelLegend2");
            Description = ReadField(dr, "v_description");
            Active = CharActiveToInt(dr["c_active"]);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Obtener leyenda de etiqueta");
        }
        finally
        {
            sql.CloseConectionWrite();
        }
    }

    private void AddExecuteParameters(SqlCommand cmd, string action, string? id)
    {
        cmd.Parameters.AddWithValue("@action", action);
        cmd.Parameters.AddWithValue("@id", string.IsNullOrWhiteSpace(id) ? DBNull.Value : id.Trim());
        cmd.Parameters.AddWithValue("@active", Active == 1 ? "1" : "0");
        cmd.Parameters.AddWithValue("@labelLegend", LabelLegend);
        cmd.Parameters.AddWithValue("@labelLegend2", ClsValues.IfEmptyToDBNull(LabelLegend2));
        cmd.Parameters.AddWithValue("@description", ClsValues.IfEmptyToDBNull(Description));
        cmd.Parameters.AddWithValue("@user", User.GetUserName());
    }

    public (bool success, string? id) AddProcedure()
    {
        SQLControl sql = new();
        try
        {
            sql.OpenConectionWrite();
            SqlCommand cmd = new("sp_PackLabelLegendExecute", sql.cnn)
            {
                CommandType = CommandType.StoredProcedure
            };
            AddExecuteParameters(cmd, "ADD", null);

            using SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string? id = ReadField(dr, "id_labelLegend");
                return (true, id);
            }

            return (false, null);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Añadir leyenda de etiqueta");
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
            SqlCommand cmd = new("sp_PackLabelLegendExecute", sql.cnn)
            {
                CommandType = CommandType.StoredProcedure
            };
            AddExecuteParameters(cmd, "MODIFY", IdLabelLegend);

            using SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string? id = ReadField(dr, "id_labelLegend");
                return (true, id ?? IdLabelLegend);
            }

            return (false, null);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Modificar leyenda de etiqueta");
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
            SqlCommand cmd = new("sp_PackLabelLegendExecute", sql.cnn)
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
            MessageBox.Show(ex.ToString(), "Activar/Desactivar leyenda de etiqueta");
            return false;
        }
        finally
        {
            sql.CloseConectionWrite();
        }
    }
}
