using System.Data;
using System.Data.SqlClient;
using SisUvex.Catalogos.Metods.Values;

namespace SisUvex.Nomina.Asistencia_AS.ModifyAttendanceEmployees;

/// <summary>
/// Representa un cambio pendiente de aplicar a <c>Nom_Attendance_AS</c> para un empleado y un día
/// específicos. Si <see cref="IdAttendanceType"/> es <c>null</c> significa "Asistencia" (se debe
/// eliminar cualquier inasistencia previa registrada ese día, no insertar nada).
/// </summary>
internal class EAttendanceEdit
{
    public string IdEmployee { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    /// <summary>Null = Asistencia (sin falta). Con valor = id_attendanceType a guardar.</summary>
    public string? IdAttendanceType { get; set; }
    public string? Comments { get; set; }
    /// <summary>Prefijo mostrado en la celda ("A" o el v_prefix del tipo elegido), para refrescar los lookups tras guardar.</summary>
    public string Prefix { get; set; } = string.Empty;

    /// <summary>
    /// Aplica este cambio dentro de una transacción ya abierta (<paramref name="sql"/>.transaction).
    /// Si <see cref="IdAttendanceType"/> es null, borra cualquier registro existente ese día (marcar
    /// asistencia = quitar falta). En caso contrario, hace upsert vía <c>sp_Nom_Attendance_AS_Upsert</c>.
    /// </summary>
    public void Save(SQLControl sql)
    {
        if (string.IsNullOrWhiteSpace(IdAttendanceType))
        {
            SqlCommand cmdDelete = new(
                "DELETE FROM Nom_Attendance_AS WHERE id_employee = @idEmployee AND CAST(d_attendance AS date) = @date",
                sql.cnn, sql.transaction);
            cmdDelete.Parameters.AddWithValue("@idEmployee", IdEmployee);
            cmdDelete.Parameters.AddWithValue("@date", Date.Date);
            cmdDelete.ExecuteNonQuery();
            return;
        }

        SqlCommand cmd = new("sp_Nom_Attendance_AS_Upsert", sql.cnn, sql.transaction)
        {
            CommandType = CommandType.StoredProcedure
        };
        cmd.Parameters.AddWithValue("@idEmployee", IdEmployee);
        cmd.Parameters.AddWithValue("@date", Date.Date);
        cmd.Parameters.AddWithValue("@idAttendanceType", IdAttendanceType);
        cmd.Parameters.AddWithValue("@comments", ClsValues.IfEmptyToDBNull(Comments));
        cmd.Parameters.AddWithValue("@user", User.GetUserName());
        cmd.ExecuteNonQuery();
    }
}
