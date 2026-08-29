using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Catalogos.Metods.Values;

namespace SisUvex.Nomina.Asistencia_AS.Nom_AttendanceType;

internal class EAttendanceType
{
    public string? IdAttendanceType { get; set; }
    /// <summary>Índice 0 = No, 1 = Sí (<c>c_active</c>).</summary>
    public int Active { get; set; }
    public string? Name { get; set; }
    public string? Prefix { get; set; }
    /// <summary><c>true</c> = Inasistencia, <c>false</c> = Asistencia (<c>c_isAbsence</c>).</summary>
    public bool IsAbsence { get; set; }
    /// <summary>Color en formato "#RRGGBB" (<c>v_color</c>).</summary>
    public string? Color { get; set; }
    /// <summary>
    /// Estilo de letra (negrita/cursiva/subrayado/tachado) del prefijo, guardado como el bitmask de
    /// <see cref="FontStyle"/> en <c>n_fontStyle</c>.
    /// </summary>
    public FontStyle FontStyle { get; set; } = FontStyle.Regular;

    public static string GetNextId()
    {
        string result = ClsQuerysDB.GetData(
            "SELECT RIGHT('00' + CAST(ISNULL(MAX(CAST(id_attendanceType AS INT)), 0) + 1 AS VARCHAR(2)), 2) FROM Nom_AttendanceType");

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

    public void GetAttendanceType(string? idAttendanceType)
    {
        if (string.IsNullOrWhiteSpace(idAttendanceType))
            return;

        SQLControl sql = new();
        try
        {
            sql.OpenConectionWrite();
            SqlCommand cmd = new("SELECT * FROM Nom_AttendanceType WHERE id_attendanceType = @id", sql.cnn);
            cmd.Parameters.AddWithValue("@id", idAttendanceType.Trim());

            using SqlDataReader dr = cmd.ExecuteReader();
            if (!dr.Read())
                return;

            IdAttendanceType = ReadField(dr, "id_attendanceType");
            Name = ReadField(dr, "v_name");
            Prefix = ReadField(dr, "v_prefix");
            IsAbsence = ReadField(dr, "c_isAbsence") == "1";
            Color = ReadField(dr, "v_color");
            Active = CharActiveToInt(dr["c_active"]);
            FontStyle = byte.TryParse(ReadField(dr, "n_fontStyle"), out byte fontStyleValue)
                ? (FontStyle)fontStyleValue
                : FontStyle.Regular;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Obtener tipo de asistencia");
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
            SqlCommand cmd = new("sp_Nom_AttendanceTypeExecute", sql.cnn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@action", "ADD");
            cmd.Parameters.AddWithValue("@id", DBNull.Value);
            cmd.Parameters.AddWithValue("@active", Active == 1 ? "1" : "0");
            cmd.Parameters.AddWithValue("@name", ClsValues.IfEmptyToDBNull(Name));
            cmd.Parameters.AddWithValue("@prefix", ClsValues.IfEmptyToDBNull(Prefix));
            cmd.Parameters.AddWithValue("@isAbsence", IsAbsence ? "1" : "0");
            cmd.Parameters.AddWithValue("@color", ClsValues.IfEmptyToDBNull(Color));
            cmd.Parameters.AddWithValue("@fontStyle", (byte)FontStyle);
            cmd.Parameters.AddWithValue("@user", User.GetUserName());

            using SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string? id = ReadField(dr, "id_attendanceType");
                return (true, id);
            }

            return (false, null);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Añadir tipo de asistencia");
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
            SqlCommand cmd = new("sp_Nom_AttendanceTypeExecute", sql.cnn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@action", "MODIFY");
            cmd.Parameters.AddWithValue("@id", IdAttendanceType);
            cmd.Parameters.AddWithValue("@active", Active == 1 ? "1" : "0");
            cmd.Parameters.AddWithValue("@name", ClsValues.IfEmptyToDBNull(Name));
            cmd.Parameters.AddWithValue("@prefix", ClsValues.IfEmptyToDBNull(Prefix));
            cmd.Parameters.AddWithValue("@isAbsence", IsAbsence ? "1" : "0");
            cmd.Parameters.AddWithValue("@color", ClsValues.IfEmptyToDBNull(Color));
            cmd.Parameters.AddWithValue("@fontStyle", (byte)FontStyle);
            cmd.Parameters.AddWithValue("@user", User.GetUserName());

            using SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string? id = ReadField(dr, "id_attendanceType");
                return (true, id);
            }

            return (false, null);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Modificar tipo de asistencia");
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
            SqlCommand cmd = new("sp_Nom_AttendanceTypeExecute", sql.cnn)
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
            MessageBox.Show(ex.ToString(), "Activar/Desactivar tipo de asistencia");
            return false;
        }
        finally
        {
            sql.CloseConectionWrite();
        }
    }
}
