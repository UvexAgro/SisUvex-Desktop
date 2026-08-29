using System.Drawing;

namespace SisUvex.Nomina.Asistencia_AS;

/// <summary>
/// Apariencia visual (color de fondo + estilo de letra) asociada a un prefijo de tipo de asistencia
/// (<c>Nom_AttendanceType.v_color</c> / <c>Nom_AttendanceType.n_fontStyle</c>). Se usa tanto en el reporte de
/// consulta como en el de modificación y en la exportación a Excel, para que los tres se vean consistentes.
/// </summary>
internal readonly struct AttendanceStyle
{
    public Color Color { get; }
    public FontStyle FontStyle { get; }

    public AttendanceStyle(Color color, FontStyle fontStyle)
    {
        Color = color;
        FontStyle = fontStyle;
    }
}
