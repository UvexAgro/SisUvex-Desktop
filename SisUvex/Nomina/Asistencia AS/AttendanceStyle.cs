using System.Drawing;

namespace SisUvex.Nomina.Asistencia_AS;

/// <summary>
/// Apariencia visual (color de fondo + estilo de letra) asociada a un prefijo de tipo de asistencia
/// (<c>Nom_AttendanceType.v_color</c> / <c>Nom_AttendanceType.n_fontStyle</c>), junto con si ese tipo cuenta
/// como inasistencia (<c>Nom_AttendanceType.c_isAbsence</c>). Se usa tanto en el reporte de consulta como en
/// el de modificación y en la exportación a Excel, para que los tres se vean y calculen de forma consistente.
/// </summary>
internal readonly struct AttendanceStyle
{
    public Color Color { get; }
    public FontStyle FontStyle { get; }
    public bool IsAbsence { get; }

    public AttendanceStyle(Color color, FontStyle fontStyle, bool isAbsence = true)
    {
        Color = color;
        FontStyle = fontStyle;
        IsAbsence = isAbsence;
    }
}
