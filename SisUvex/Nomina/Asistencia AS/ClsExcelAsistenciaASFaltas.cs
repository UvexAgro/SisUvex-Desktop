using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SisUvex.Nomina.Asistencia_AS
{
    /// <summary>
    /// Hoja Excel "Inasistencias": una fila por empleado y una columna por cada fecha en la que
    /// al menos un empleado tuvo falta. En cada cruce se muestra cuántas faltas tuvo ese empleado
    /// en la ventana de <see cref="RangoDiasFaltas"/> días, pero solo si él mismo faltó ese día;
    /// si la columna existe por la falta de otro trabajador, su celda queda en blanco.
    /// El criterio de falta es el mismo que el del reporte lineal
    /// (<see cref="ClsAsistenciaASConsulta.CountsAsAsistencia"/>).
    /// </summary>
    internal sealed class ClsExcelAsistenciaASFaltas
    {
        /// <summary>Ventana de días a contar a partir de la fecha de la falta (inclusive). 30 = fecha + 29 días.</summary>
        internal const int RangoDiasFaltas = 30;

        /// <summary>Faltas permitidas dentro de <see cref="RangoDiasFaltas"/>. Si el conteo es mayor, la celda se pinta de rojo.</summary>
        internal const int FaltasMaximasEnRango = 3;

        private static readonly XLColor TabColor         = XLColor.FromHtml("#C65911");
        private static readonly XLColor ColorHeader      = XLColor.FromHtml("#538DD5");
        private static readonly XLColor ColorTableHeader = XLColor.FromHtml("#8DB4E2");
        private static readonly XLColor ColorMonthBand   = XLColor.FromHtml("#D9E1F2");
        private static readonly XLColor ColorOverLimit   = XLColor.FromHtml("#F76F65");

        private const int StartCol  = 2;
        private const int FixedCols = 4; // CÓDIGO | NOMBRE COMPLETO | LP | TOTAL

        public static void AddFaltasSheet(
            IXLWorkbook wb,
            DataTable reportData,
            List<DateTime> days,
            Dictionary<string, AttendanceStyle> stylesByPrefix,
            string dateRange)
        {
            if (wb == null || reportData == null || reportData.Rows.Count == 0)
                return;

            days ??= new List<DateTime>();
            stylesByPrefix ??= new Dictionary<string, AttendanceStyle>(StringComparer.OrdinalIgnoreCase);

            var empAbsences = new List<(DataRow Row, HashSet<DateTime> Faltas)>();
            var columnDates = new SortedSet<DateTime>();

            foreach (DataRow empRow in reportData.Rows)
            {
                var faltas = new HashSet<DateTime>();
                foreach (DateTime day in days)
                {
                    string value = SafeStr(empRow, ClsAsistenciaASConsulta.BuildDayColumnName(day));
                    if (ClsAsistenciaASConsulta.CountsAsAsistencia(value, day.DayOfWeek, stylesByPrefix))
                        continue;

                    faltas.Add(day.Date);
                    columnDates.Add(day.Date);
                }
                empAbsences.Add((empRow, faltas));
            }

            List<DateTime> faltaDates = columnDates.ToList();
            int extraDays = Math.Max(faltaDates.Count, 1);
            int lastCol = StartCol + FixedCols + extraDays - 1;

            var ws = wb.Worksheets.Add("Inasistencias");
            ws.TabColor = TabColor;

            const int filtersRow = 1;
            ws.Cell(filtersRow, StartCol).Value = $"Reporte de inasistencias  |  Fechas: {dateRange}";
            ws.Range(filtersRow, StartCol, filtersRow, lastCol).Merge();
            var filtersStyle = ws.Cell(filtersRow, StartCol).Style;
            filtersStyle.Font.SetBold();
            filtersStyle.Fill.SetBackgroundColor(ColorHeader);
            filtersStyle.Font.FontColor = XLColor.White;
            filtersStyle.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left);

            int noteRow = filtersRow + 2;
            int offsetDias = RangoDiasFaltas - 1;
            ws.Cell(noteRow, StartCol).Value =
                $"Rango de faltas: {RangoDiasFaltas} días (fecha + {offsetDias})  |  Máximo permitido en el rango: {FaltasMaximasEnRango}";
            ws.Cell(noteRow, StartCol).Style.Font.SetFontSize(9);

            int monthRow     = noteRow + 2;
            int startDateRow = monthRow + 1;
            int endDateRow   = startDateRow + 1;
            int dataStartRow = endDateRow + 1;
            int dayColStart  = StartCol + FixedCols;

            string[] fixedHeaders = { "CÓDIGO", "NOMBRE COMPLETO", "LP", "TOTAL" };
            for (int i = 0; i < fixedHeaders.Length; i++)
            {
                int col = StartCol + i;
                ws.Range(monthRow, col, endDateRow, col).Merge();
                ws.Cell(monthRow, col).Value = fixedHeaders[i];
            }
            ws.Range(monthRow, StartCol, endDateRow, StartCol + FixedCols - 1).Style
                .Font.SetBold()
                .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                .Fill.SetBackgroundColor(ColorTableHeader);

            if (faltaDates.Count > 0)
            {
                int col = dayColStart;
                foreach (var monthGroup in faltaDates.GroupBy(d => new { d.Year, d.Month }))
                {
                    var groupDays = monthGroup.ToList();
                    int groupColStart = col;
                    int groupColEnd   = col + groupDays.Count - 1;

                    ws.Range(monthRow, groupColStart, monthRow, groupColEnd).Merge();
                    var monthCell = ws.Cell(monthRow, groupColStart);
                    monthCell.Value = new DateTime(monthGroup.Key.Year, monthGroup.Key.Month, 1);
                    monthCell.Style.DateFormat.Format = "MMMM yyyy";
                    monthCell.Style.Font.SetBold();
                    monthCell.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    monthCell.Style.Fill.SetBackgroundColor(ColorMonthBand);

                    foreach (DateTime start in groupDays)
                    {
                        DateTime end = start.AddDays(offsetDias);

                        var startCell = ws.Cell(startDateRow, col);
                        startCell.Value = start;
                        startCell.Style.DateFormat.Format = "dd mmm";
                        startCell.Style.Font.SetBold();
                        startCell.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        startCell.Style.Fill.SetBackgroundColor(ColorTableHeader);

                        var endCell = ws.Cell(endDateRow, col);
                        endCell.Value = end;
                        endCell.Style.DateFormat.Format = "dd mmm";
                        endCell.Style.Font.SetBold();
                        endCell.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        endCell.Style.Fill.SetBackgroundColor(ColorTableHeader);

                        col++;
                    }
                }
            }

            ws.Range(monthRow, StartCol, endDateRow, lastCol).Style
                .Border.SetOutsideBorder(XLBorderStyleValues.Medium)
                .Border.SetInsideBorder(XLBorderStyleValues.Thin);

            int row = dataStartRow;
            foreach (var (empRow, faltas) in empAbsences)
            {
                ws.Cell(row, StartCol).Value     = SafeStr(empRow, ClsAsistenciaASConsulta.ReportColCodigo);
                ws.Cell(row, StartCol + 1).Value = SafeStr(empRow, ClsAsistenciaASConsulta.ReportColNombre);
                ws.Cell(row, StartCol + 2).Value = SafeStr(empRow, ClsAsistenciaASConsulta.ReportColLp);

                var totalCell = ws.Cell(row, StartCol + 3);
                totalCell.Value = faltas.Count;
                totalCell.Style.Font.SetBold();
                totalCell.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                int col = dayColStart;
                foreach (DateTime start in faltaDates)
                {
                    // Solo se cuenta la ventana de 30 días si ESTE empleado faltó en la fecha de la
                    // columna. Si la columna existe por la falta de otro trabajador, la celda se deja
                    // en blanco aunque este empleado tenga faltas después.
                    if (faltas.Contains(start))
                    {
                        DateTime end = start.AddDays(offsetDias);
                        int count = 0;
                        foreach (DateTime falta in faltas)
                        {
                            if (falta >= start && falta <= end)
                                count++;
                        }

                        var cell = ws.Cell(row, col);
                        cell.Value = count;
                        cell.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        if (count > FaltasMaximasEnRango)
                            cell.Style.Fill.SetBackgroundColor(ColorOverLimit);
                    }

                    col++;
                }

                row++;
            }

            if (row > dataStartRow)
            {
                ws.Range(dataStartRow, StartCol, row - 1, lastCol).Style
                    .Border.SetOutsideBorder(XLBorderStyleValues.Medium)
                    .Border.SetInsideBorder(XLBorderStyleValues.Thin);
            }

            ws.SheetView.FreezeRows(endDateRow);
            ws.SheetView.FreezeColumns(StartCol + FixedCols - 1);

            ws.Column(1).Width = 2;
            ws.Column(StartCol).Width     = 7.57;   // CÓDIGO
            ws.Column(StartCol + 1).AdjustToContents();
            if (ws.Column(StartCol + 1).Width < 33.43)
                ws.Column(StartCol + 1).Width = 33.43;
            ws.Column(StartCol + 2).Width = 4.29;   // LP
            ws.Column(StartCol + 3).Width = 5.86;   // TOTAL
            for (int c = dayColStart; c <= lastCol; c++)
                ws.Column(c).Width = 7.14;
        }

        private static string SafeStr(DataRow row, string col)
            => row.Table.Columns.Contains(col) && row[col] != DBNull.Value
                ? row[col].ToString()?.Trim() ?? string.Empty
                : string.Empty;
    }
}
