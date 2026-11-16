using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SisUvex.Nomina.Asistencia_AS
{
    /// <summary>
    /// Hoja Excel "Desglose inasistencias": un bloque por empleado. En cada bloque, una columna por
    /// cada fecha en la que ESE empleado faltó; debajo va la fecha + 29 días, el total de faltas en
    /// esa ventana y el listado de esas fechas (menor a mayor). Reutiliza
    /// <see cref="ClsExcelAsistenciaASFaltas.RangoDiasFaltas"/> y
    /// <see cref="ClsExcelAsistenciaASFaltas.FaltasMaximasEnRango"/>.
    /// </summary>
    internal sealed class ClsExcelAsistenciaASDesglose
    {
        private static readonly XLColor TabColor         = XLColor.FromHtml("#833C0C");
        private static readonly XLColor ColorHeader      = XLColor.FromHtml("#538DD5");
        private static readonly XLColor ColorTableHeader = XLColor.FromHtml("#8DB4E2");
        private static readonly XLColor ColorMonthBand   = XLColor.FromHtml("#D9E1F2");
        private static readonly XLColor ColorOverLimit   = XLColor.FromHtml("#F76F65");

        private const int StartCol    = 2; // B: CÓDIGO
        private const int NameCol     = 3;
        private const int LpCol       = 4;
        private const int LabelCol    = 5; // E: inicio / final / Faltas / índice
        private const int DayColStart = 6; // F: primera fecha

        public static void AddDesgloseSheet(
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

            int rango = ClsExcelAsistenciaASFaltas.RangoDiasFaltas;
            int offsetDias = rango - 1;
            int maxPermitidas = ClsExcelAsistenciaASFaltas.FaltasMaximasEnRango;

            var blocks = new List<EmployeeBlock>();
            foreach (DataRow empRow in reportData.Rows)
            {
                var faltas = new List<DateTime>();
                foreach (DateTime day in days)
                {
                    string value = SafeStr(empRow, ClsAsistenciaASConsulta.BuildDayColumnName(day));
                    if (!ClsAsistenciaASConsulta.CountsAsAsistencia(value, day.DayOfWeek, stylesByPrefix))
                        faltas.Add(day.Date);
                }

                if (faltas.Count > 0)
                    faltas.Sort();

                var windows = new List<List<DateTime>>(faltas.Count);
                foreach (DateTime start in faltas)
                {
                    DateTime end = start.AddDays(offsetDias);
                    windows.Add(faltas.Where(d => d >= start && d <= end).ToList());
                }

                blocks.Add(new EmployeeBlock
                {
                    Codigo = SafeStr(empRow, ClsAsistenciaASConsulta.ReportColCodigo),
                    Nombre = SafeStr(empRow, ClsAsistenciaASConsulta.ReportColNombre),
                    Lp     = SafeStr(empRow, ClsAsistenciaASConsulta.ReportColLp),
                    FaltaDates = faltas,
                    Windows = windows,
                });
            }

            int maxDateCols = blocks.Count == 0 ? 0 : blocks.Max(b => b.FaltaDates.Count);
            int lastCol = maxDateCols == 0 ? LabelCol : DayColStart + maxDateCols - 1;

            var ws = wb.Worksheets.Add("Desglose inasistencias");
            ws.TabColor = TabColor;

            const int filtersRow = 1;
            ws.Cell(filtersRow, StartCol).Value = $"Reporte de inasistencias desglosado  |  Fechas: {dateRange}";
            ws.Range(filtersRow, StartCol, filtersRow, lastCol).Merge();
            var titleStyle = ws.Cell(filtersRow, StartCol).Style;
            titleStyle.Font.SetBold();
            titleStyle.Fill.SetBackgroundColor(ColorHeader);
            titleStyle.Font.FontColor = XLColor.White;
            titleStyle.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left);

            int row = filtersRow + 2;
            foreach (EmployeeBlock block in blocks)
            {
                row = WriteEmployeeBlock(ws, row, block, offsetDias, maxPermitidas);
                row += 2; // separación entre bloques, como en el ejemplo
            }

            ws.Column(1).Width = 1.14;
            ws.Column(StartCol).Width = 7.57;
            ws.Column(NameCol).AdjustToContents();
            if (ws.Column(NameCol).Width < 32.29)
                ws.Column(NameCol).Width = 32.29;
            ws.Column(LpCol).Width    = 4.29;
            ws.Column(LabelCol).Width = 5.43;
            if (lastCol >= DayColStart)
            {
                ws.Column(DayColStart).Width = 10;
                for (int c = DayColStart + 1; c <= lastCol; c++)
                    ws.Column(c).Width = 6.14;
            }

            ws.SheetView.FreezeRows(filtersRow);
            ws.SheetView.FreezeColumns(LabelCol);
        }

        private static int WriteEmployeeBlock(
            IXLWorksheet ws,
            int startRow,
            EmployeeBlock block,
            int offsetDias,
            int maxPermitidas)
        {
            if (block.FaltaDates.Count == 0)
                return WriteEmployeeBlockSinFaltas(ws, startRow, block);

            int dateCount = block.FaltaDates.Count;
            int lastDayCol = DayColStart + dateCount - 1;
            int maxWindow = block.Windows.Max(w => w.Count);

            int monthRow     = startRow;
            int startDateRow = monthRow + 1;
            int endDateRow   = startDateRow + 1;
            int countRow     = endDateRow + 1;
            int firstDetail  = countRow + 1;
            int lastRow      = firstDetail + Math.Max(maxWindow, 1) - 1;

            int col = DayColStart;
            foreach (var monthGroup in block.FaltaDates.GroupBy(d => new { d.Year, d.Month }))
            {
                var groupDays = monthGroup.ToList();
                int groupStart = col;
                int groupEnd   = col + groupDays.Count - 1;
                ws.Range(monthRow, groupStart, monthRow, groupEnd).Merge();
                ApplyDateCell(ws.Cell(monthRow, groupStart), new DateTime(monthGroup.Key.Year, monthGroup.Key.Month, 1), "MMMM yyyy", ColorMonthBand);
                col += groupDays.Count;
            }

            ws.Cell(startDateRow, LabelCol).Value = "inicio";
            ws.Cell(endDateRow, LabelCol).Value   = "final";
            ws.Cell(countRow, LabelCol).Value     = "Faltas";
            ws.Cell(startDateRow, LabelCol).Style.Font.SetBold();
            ws.Cell(endDateRow, LabelCol).Style.Font.SetBold();
            ws.Cell(countRow, LabelCol).Style.Font.SetBold();
            ws.Cell(startDateRow, LabelCol).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            ws.Cell(endDateRow, LabelCol).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            ws.Cell(countRow, LabelCol).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            ws.Cell(startDateRow, LabelCol).Style.Fill.SetBackgroundColor(ColorTableHeader);
            ws.Cell(endDateRow, LabelCol).Style.Fill.SetBackgroundColor(ColorTableHeader);

            ws.Cell(endDateRow, StartCol).Value = "CÓDIGO";
            ws.Cell(endDateRow, NameCol).Value  = "NOMBRE COMPLETO";
            ws.Cell(endDateRow, LpCol).Value    = "LP";
            ws.Range(endDateRow, StartCol, endDateRow, LpCol).Style
                .Font.SetBold()
                .Fill.SetBackgroundColor(ColorTableHeader)
                .Alignment.SetVertical(XLAlignmentVerticalValues.Center);

            ws.Cell(countRow, StartCol).Value = block.Codigo;
            ws.Cell(countRow, NameCol).Value  = block.Nombre;
            ws.Cell(countRow, LpCol).Value    = block.Lp;

            for (int i = 0; i < dateCount; i++)
            {
                int dayCol = DayColStart + i;
                DateTime start = block.FaltaDates[i];
                DateTime end   = start.AddDays(offsetDias);
                List<DateTime> window = block.Windows[i];

                ApplyDateCell(ws.Cell(startDateRow, dayCol), start, "dd mmm", ColorTableHeader);
                ApplyDateCell(ws.Cell(endDateRow, dayCol), end, "dd mmm", ColorTableHeader);

                var countCell = ws.Cell(countRow, dayCol);
                countCell.Value = window.Count;
                countCell.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                if (window.Count > maxPermitidas)
                    countCell.Style.Fill.SetBackgroundColor(ColorOverLimit);

                for (int n = 0; n < window.Count; n++)
                    ApplyDateCell(ws.Cell(firstDetail + n, dayCol), window[n], "dd mmm", null);
            }

            for (int n = 0; n < maxWindow; n++)
            {
                var idx = ws.Cell(firstDetail + n, LabelCol);
                idx.Value = n + 1;
                idx.Style.Font.SetBold();
                idx.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            }

            ws.Range(monthRow, StartCol, lastRow, lastDayCol).Style
                .Border.SetOutsideBorder(XLBorderStyleValues.Medium)
                .Border.SetInsideBorder(XLBorderStyleValues.Thin);

            // Celdas vacías de CÓDIGO / NOMBRE / LP (arriba del encabezado y debajo del dato del
            // empleado): sin bordes interiores, para que se vean como un espacio blanco continuo.
            // El contorno del bloque y los bordes de las filas con dato se mantienen.
            if (startDateRow > monthRow)
            {
                ws.Range(monthRow, StartCol, startDateRow, LpCol).Style
                    .Border.SetInsideBorder(XLBorderStyleValues.None);
            }

            if (lastRow >= firstDetail)
            {
                ws.Range(firstDetail, StartCol, lastRow, LpCol).Style
                    .Border.SetInsideBorder(XLBorderStyleValues.None);
            }

            return lastRow;
        }

        /// <summary>
        /// Bloque compacto para empleados sin inasistencias: solo Código, Nombre, LP y Faltas = 0,
        /// sin columnas de fechas ni desglose.
        /// </summary>
        private static int WriteEmployeeBlockSinFaltas(IXLWorksheet ws, int startRow, EmployeeBlock block)
        {
            int headerRow = startRow;
            int dataRow   = startRow + 1;

            ws.Cell(headerRow, StartCol).Value = "CÓDIGO";
            ws.Cell(headerRow, NameCol).Value  = "NOMBRE COMPLETO";
            ws.Cell(headerRow, LpCol).Value    = "LP";
            ws.Cell(headerRow, LabelCol).Value = "Faltas";
            ws.Range(headerRow, StartCol, headerRow, LabelCol).Style
                .Font.SetBold()
                .Fill.SetBackgroundColor(ColorTableHeader)
                .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                .Alignment.SetVertical(XLAlignmentVerticalValues.Center);

            ws.Cell(dataRow, StartCol).Value = block.Codigo;
            ws.Cell(dataRow, NameCol).Value  = block.Nombre;
            ws.Cell(dataRow, LpCol).Value    = block.Lp;
            var faltasCell = ws.Cell(dataRow, LabelCol);
            faltasCell.Value = 0;
            faltasCell.Style.Font.SetBold();
            faltasCell.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

            ws.Range(headerRow, StartCol, dataRow, LabelCol).Style
                .Border.SetOutsideBorder(XLBorderStyleValues.Medium)
                .Border.SetInsideBorder(XLBorderStyleValues.Thin);

            return dataRow;
        }

        private static void ApplyDateCell(IXLCell cell, DateTime value, string format, XLColor? fill)
        {
            cell.Value = value;
            cell.Style.DateFormat.Format = format;
            cell.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            if (fill != null)
            {
                cell.Style.Font.SetBold();
                cell.Style.Fill.SetBackgroundColor(fill);
            }
        }

        private static string SafeStr(DataRow row, string col)
            => row.Table.Columns.Contains(col) && row[col] != DBNull.Value
                ? row[col].ToString()?.Trim() ?? string.Empty
                : string.Empty;

        private sealed class EmployeeBlock
        {
            public string Codigo = string.Empty;
            public string Nombre = string.Empty;
            public string Lp = string.Empty;
            public List<DateTime> FaltaDates = new();
            public List<List<DateTime>> Windows = new();
        }
    }
}
