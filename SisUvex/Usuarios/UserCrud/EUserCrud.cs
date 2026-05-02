using System.Data;
using System.Data.SqlClient;

namespace SisUvex.Usuarios.UserCrud;

internal class EUserCrud
{
    public string? IdUser { get; set; }
    public string? UserDisplayName { get; set; }
    public string? PasswordHash { get; set; }
    public int Accesibilidad { get; set; }
    public string? IdWorkGroup { get; set; }
    public string? IdContractor { get; set; }
    public string? IdEmployee { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? IdRole { get; set; }
    public int Active { get; set; }
    public static string GetNextId()
    {
        string result = ClsQuerysUsuarios.GetData("select ISNULL(MAX(c_codigo_usu),0) + 1 AS [Id] from usuario ");

        return string.IsNullOrEmpty(result) ? "1" : result;
    }
    private static int CharFlagToInt(object? value)
    {
        if (value == null || value == DBNull.Value)
            return 0;
        string? s = value.ToString();
        if (string.IsNullOrEmpty(s))
            return 0;
        return s == "1" ? 1 : 0;
    }

    private static string? ReadField(SqlDataReader dr, string column)
    {
        int o = dr.GetOrdinal(column);
        if (dr.IsDBNull(o))
            return null;
        return dr.GetValue(o).ToString();
    }

    /// <summary>Consulta <c>sp_userExist</c> (<c>@usuario</c>) para validar que el nombre de usuario no se repita.</summary>
    public static bool UserExists(string userName)
    {
        if (string.IsNullOrWhiteSpace(userName))
            return false;

        userName = userName.ToUpper().Trim(); // Normalizar para evitar problemas de mayúsculas/minúsculas y espacios.

        SQLControl sql = new();
        try
        {
            sql.OpenConectionRead();
            SqlCommand cmd = new("sp_userExist", sql.cnn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@usuario", userName);
            using SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                int n = dr.GetInt32(0);
                return n > 0;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Usuario existente");
        }
        finally
        {
            sql.CloseConectionRead();
        }

        return false;
    }

    /// <param name="userCode"><c>c_codigo_usu</c> (coincide con la columna Código del catálogo).</param>
    public void GetUser(string? userCode)
    {
        if (string.IsNullOrWhiteSpace(userCode))
            return;

        SQLControl sql = new();
        try
        {
            sql.OpenConectionRead();
            SqlCommand cmd = new("SELECT * FROM usuario WHERE c_codigo_usu = @c_codigo_usu", sql.cnn);
            cmd.Parameters.AddWithValue("@c_codigo_usu", userCode.Trim());

            using SqlDataReader dr = cmd.ExecuteReader();
            if (!dr.Read())
                return;

            IdUser = ReadField(dr, "c_codigo_usu");
            UserDisplayName = ReadField(dr, "v_nombre_usu")?.Trim().ToUpper();
            Accesibilidad = int.TryParse(ReadField(dr, "c_accesibilidad_usu"), out int acc) ? acc : 0;
            IdWorkGroup = ReadField(dr, "id_workGroup");
            IdContractor = ReadField(dr, "id_contractor");
            IdEmployee = ReadField(dr, "id_employee");
            Name = ReadField(dr, "v_name");
            Email = ReadField(dr, "v_email");
            PhoneNumber = ReadField(dr, "v_phoneNumber");
            IdRole = ReadField(dr, "id_role");
            Active = CharFlagToInt(dr["c_active"]);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Obtener usuario");
        }
        finally
        {
            sql.CloseConectionRead();
        }
    }

    public (bool success, string? id) AddProcedure()
    {
        SQLControl sql = new();
        try
        {
            sql.OpenConectionRead();
            SqlCommand cmd = new("sp_UserExecute", sql.cnn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@action", "ADD");
            cmd.Parameters.AddWithValue("@c_codigo_usu", (object)(IdUser?.Trim() ?? string.Empty));
            cmd.Parameters.AddWithValue("@v_nombre_usu", (object)(UserDisplayName?.Trim().ToUpper() ?? string.Empty));
            cmd.Parameters.AddWithValue("@v_passwo_usu", (object)(PasswordHash ?? string.Empty));
            cmd.Parameters.AddWithValue("@c_accesibilidad_usu", Accesibilidad.ToString());
            cmd.Parameters.AddWithValue("@id_workGroup", string.IsNullOrWhiteSpace(IdWorkGroup) ? (object)DBNull.Value : IdWorkGroup.Trim());
            cmd.Parameters.AddWithValue("@id_contractor", string.IsNullOrWhiteSpace(IdContractor) ? (object)DBNull.Value : IdContractor.Trim());
            cmd.Parameters.AddWithValue("@id_employee", string.IsNullOrWhiteSpace(IdEmployee) ? (object)DBNull.Value : IdEmployee.Trim());
            cmd.Parameters.AddWithValue("@v_name", string.IsNullOrWhiteSpace(Name) ? (object)DBNull.Value : Name.Trim());
            cmd.Parameters.AddWithValue("@v_email", string.IsNullOrWhiteSpace(Email) ? (object)DBNull.Value : Email.Trim());
            cmd.Parameters.AddWithValue("@v_phoneNumber", string.IsNullOrWhiteSpace(PhoneNumber) ? (object)DBNull.Value : PhoneNumber.Trim());
            cmd.Parameters.AddWithValue("@id_role", string.IsNullOrWhiteSpace(IdRole) ? (object)DBNull.Value : IdRole.Trim());
            cmd.Parameters.AddWithValue("@c_active", Active == 1 ? "1" : "0");
            cmd.Parameters.AddWithValue("@user", User.GetUserName());

            using SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string? id = ReadField(dr, "c_codigo_usu");
                return (true, id);
            }

            return (false, null);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Añadir usuario");
            return (false, null);
        }
        finally
        {
            sql.CloseConectionRead();
        }
    }

    public (bool success, string? id) ModifyProcedure()
    {
        SQLControl sql = new();
        try
        {
            sql.OpenConectionRead();
            SqlCommand cmd = new("sp_UserExecute", sql.cnn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@action", "MODIFY");
            cmd.Parameters.AddWithValue("@c_codigo_usu", (object)(IdUser?.Trim() ?? string.Empty));
            cmd.Parameters.AddWithValue("@v_nombre_usu", (object)(UserDisplayName?.Trim().ToUpper() ?? string.Empty));
            cmd.Parameters.AddWithValue("@v_passwo_usu", DBNull.Value);
            cmd.Parameters.AddWithValue("@c_accesibilidad_usu", Accesibilidad.ToString());
            cmd.Parameters.AddWithValue("@id_workGroup", string.IsNullOrWhiteSpace(IdWorkGroup) ? (object)DBNull.Value : IdWorkGroup.Trim());
            cmd.Parameters.AddWithValue("@id_contractor", string.IsNullOrWhiteSpace(IdContractor) ? (object)DBNull.Value : IdContractor.Trim());
            cmd.Parameters.AddWithValue("@id_employee", string.IsNullOrWhiteSpace(IdEmployee) ? (object)DBNull.Value : IdEmployee.Trim());
            cmd.Parameters.AddWithValue("@v_name", string.IsNullOrWhiteSpace(Name) ? (object)DBNull.Value : Name.Trim());
            cmd.Parameters.AddWithValue("@v_email", string.IsNullOrWhiteSpace(Email) ? (object)DBNull.Value : Email.Trim());
            cmd.Parameters.AddWithValue("@v_phoneNumber", string.IsNullOrWhiteSpace(PhoneNumber) ? (object)DBNull.Value : PhoneNumber.Trim());
            cmd.Parameters.AddWithValue("@id_role", string.IsNullOrWhiteSpace(IdRole) ? (object)DBNull.Value : IdRole.Trim());
            cmd.Parameters.AddWithValue("@c_active", Active == 1 ? "1" : "0");
            cmd.Parameters.AddWithValue("@user", User.GetUserName());

            using SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string? id = ReadField(dr, "c_codigo_usu");
                return (true, id);
            }

            return (false, null);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Modificar usuario");
            return (false, null);
        }
        finally
        {
            sql.CloseConectionRead();
        }
    }

    public static bool ActiveProcedure(string id, string active)
    {
        SQLControl sql = new();
        try
        {
            sql.OpenConectionRead();
            SqlCommand cmd = new("sp_UserExecute", sql.cnn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@action", "STATUS");
            cmd.Parameters.AddWithValue("@c_codigo_usu", id.Trim());
            cmd.Parameters.AddWithValue("@c_active", active);
            cmd.Parameters.AddWithValue("@user", User.GetUserName());

            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Activar/Desactivar usuario");
            return false;
        }
        finally
        {
            sql.CloseConectionRead();
        }
    }

    /// <summary>Solo actualiza contraseña (hash BCrypt); demás columnas sin cambio vía COALESCE en el SP.</summary>
    public static bool ChangePasswordProcedure(string idUser, string passwordHash)
    {
        SQLControl sql = new();
        try
        {
            sql.OpenConectionRead();
            SqlCommand cmd = new("sp_UserExecute", sql.cnn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@action", "PASSWORD");
            cmd.Parameters.AddWithValue("@c_codigo_usu", idUser.Trim());
            cmd.Parameters.AddWithValue("@v_passwo_usu", passwordHash);
            cmd.Parameters.AddWithValue("@user", User.GetUserName());

            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Cambiar contraseña");
            return false;
        }
        finally
        {
            sql.CloseConectionRead();
        }
    }
}
