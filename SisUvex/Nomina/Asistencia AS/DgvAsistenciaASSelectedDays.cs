namespace SisUvex.Nomina.Asistencia_AS;

/// <summary>
/// Cuenta los días seleccionados en un <see cref="DataGridView"/> de asistencias.
/// En el reporte lineal usa columnas <c>D_yyyy-MM-dd</c>; en el calendario agrupa
/// número y prefijo del mismo día. Pensado para reutilizarlo en cualquier formulario
/// llamando <see cref="UpdateLabel"/> desde <c>SelectionChanged</c>.
/// </summary>
internal static class DgvAsistenciaASSelectedDays
{
    /// <summary>
    /// Actualiza <paramref name="label"/> con el total de celdas de día seleccionadas
    /// en <paramref name="dgv"/> (por ejemplo <c>10</c>, <c>4</c>, <c>56</c>).
    /// </summary>
    public static void UpdateLabel(Label? label, DataGridView? dgv)
    {
        if (label == null || label.IsDisposed) return;
        label.Text = CountSelectedDayCells(dgv).ToString();
    }

    /// <summary>
    /// Total de días seleccionados. En el reporte lineal cada celda de día cuenta 1;
    /// en el calendario el número y el prefijo del mismo día cuentan juntos como 1.
    /// </summary>
    public static int CountSelectedDayCells(DataGridView? dgv)
    {
        if (dgv == null || dgv.IsDisposed || dgv.SelectedCells.Count == 0)
            return 0;

        if (ClsAsistenciaASCalendario.IsCalendarGrid(dgv))
            return ClsAsistenciaASCalendario.CountSelectedDays(dgv);

        int count = 0;
        foreach (DataGridViewCell cell in dgv.SelectedCells)
        {
            if (cell.RowIndex < 0 || cell.ColumnIndex < 0 || cell.ColumnIndex >= dgv.Columns.Count)
                continue;

            if (ClsAsistenciaASConsulta.TryParseDayColumn(dgv.Columns[cell.ColumnIndex].Name, out _))
                count++;
        }

        return count;
    }
}
