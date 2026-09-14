using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Color = System.Drawing.Color;

namespace SisUvex.Nomina.Asistencia_AS
{
    /// <summary>
    /// Vista "calendario" del reporte de asistencias/inasistencias: por cada empleado, uno o más bloques
    /// de mes con los días acomodados como un calendario real (semanas × día de la semana, empezando en
    /// domingo). Se usa tanto para mostrarla en <c>dgvReport</c> (alternativa a la vista lineal de
    /// <see cref="ClsAsistenciaASConsulta"/>) como para agregar la hoja "Calendario" al reporte de Excel
    /// generado por <see cref="ClsExcelAsistenciaASConsulta"/>, sin mezclar código en ninguna de esas dos clases.
    /// </summary>
    internal sealed class ClsAsistenciaASCalendario
    {
        /// <summary>Un mes dentro del rango del reporte, con su cuadrícula [semana, día de la semana] → fecha (o null si esa celda no aplica).</summary>
        internal sealed class MonthBlock
        {
            public int Year;
            public int Month;
            /// <summary>Si debe mostrarse el año junto al nombre del mes (primer mes del reporte, o cuando cambia respecto al mes anterior).</summary>
            public bool ShowYear;
            public DateTime?[,] Grid = null!;
        }

        // ── Columnas de la tabla de la vista calendario (DGV) ──────────────────
        private const string ColKind      = "__Kind";
        private const string KindNum      = "N";
        private const string KindVal      = "V";
        private const string KindMonth    = "M";
        private const string KindWeekday  = "W";
        private const string ColAsist     = "Asist.";
        private const string ColFaltas    = "Faltas";
        private const string ColFaltas30  = "Faltas 30d";
        /// <summary>Tamaño de la ventana de "últimos N días" usada por <see cref="ColFaltas30"/>.</summary>
        private const int Faltas30Dias = ClsAsistenciaASConsulta.Faltas30Dias;
        private const string SlotPrefix   = "CD_";
        private const string ColorPrefix  = "CV_";
        private const string GapPrefix    = "GAP_";

        /// <summary>D, L, M, M, J, V, S — en el mismo orden que <see cref="DayOfWeek"/> (0 = domingo).</summary>
        private static readonly string[] DayLetters = { "D", "L", "M", "M", "J", "V", "S" };

        /// <summary>Un color distinto por cada mes del año (enero..diciembre), igual al del Excel de referencia.</summary>
        private static readonly Color[] MonthColors =
        {
            ColorTranslator.FromHtml("#1A6FB8"), // Enero
            ColorTranslator.FromHtml("#158DC5"), // Febrero
            ColorTranslator.FromHtml("#56AF40"), // Marzo
            ColorTranslator.FromHtml("#A4BE1C"), // Abril
            ColorTranslator.FromHtml("#FAC223"), // Mayo
            ColorTranslator.FromHtml("#F6A812"), // Junio
            ColorTranslator.FromHtml("#EA6A06"), // Julio
            ColorTranslator.FromHtml("#E14617"), // Agosto
            ColorTranslator.FromHtml("#EC2518"), // Septiembre
            ColorTranslator.FromHtml("#A91E4C"), // Octubre
            ColorTranslator.FromHtml("#733999"), // Noviembre
            ColorTranslator.FromHtml("#412BB4"), // Diciembre
        };

        /// <summary>Fondo del título y de la fila de encabezados (CÓDIGO/.../día de la semana) — Texto1 con 25% de tinte, como en el Excel de referencia.</summary>
        private static readonly Color ColorHeaderDark = ColorTranslator.FromHtml("#404040");

        private const string FontHeader   = "Arial";        // título, nombre de mes, encabezado fijo/día de semana
        private const string FontData     = "Aptos Narrow";  // código/nombre/lp/asist/faltas y número de día
        private const string FontLegend   = "Calibri";
        private const string FontValue    = "Arial";         // prefijo de asistencia (celda grande)

        private static readonly XLColor BorderBlack = XLColor.Black;

        /// <summary>Convierte un ancho en píxeles al ancho de columna de Excel (unidades de carácter).</summary>
        private static double PxToColumnWidth(double pixels) => Math.Round((pixels - 5.0) / 7.0, 2);

        public List<MonthBlock> Blocks { get; private set; } = new();
        public int WeeksPerBlock { get; private set; }

        private static readonly Pen BorderPen = new(Color.Black);
        private static readonly Dictionary<int, Pen> MaskPens = new();
        private readonly Dictionary<(string Text, int Width, float Size), Font> _fittingFonts = new();

        // ── Cálculo de los bloques de mes (compartido por la vista DGV y la hoja de Excel) ─────

        private static (List<MonthBlock> Blocks, int WeeksPerBlock) BuildBlocks(List<DateTime> days)
        {
            var months = days
                .Select(d => (d.Year, d.Month))
                .Distinct()
                .OrderBy(t => t.Year).ThenBy(t => t.Month)
                .ToList();

            var blocks = new List<MonthBlock>();
            int prevYear = int.MinValue;
            foreach (var (year, month) in months)
            {
                blocks.Add(new MonthBlock { Year = year, Month = month, ShowYear = year != prevYear });
                prevYear = year;
            }

            int weeksPerBlock = blocks.Count == 0 ? 0 : blocks.Max(b => WeeksNeeded(b.Year, b.Month));

            var daySet = new HashSet<DateTime>(days.Select(d => d.Date));
            foreach (MonthBlock block in blocks)
            {
                var grid = new DateTime?[weeksPerBlock, 7];
                DateTime first = new(block.Year, block.Month, 1);
                int offset = (int)first.DayOfWeek; // 0 = domingo
                int daysInMonth = DateTime.DaysInMonth(block.Year, block.Month);

                for (int day = 1; day <= daysInMonth; day++)
                {
                    int idx = offset + day - 1;
                    DateTime date = new(block.Year, block.Month, day);
                    if (daySet.Contains(date))
                        grid[idx / 7, idx % 7] = date;
                }

                block.Grid = grid;
            }

            return (blocks, weeksPerBlock);
        }

        private static int WeeksNeeded(int year, int month)
        {
            int offset = (int)new DateTime(year, month, 1).DayOfWeek;
            int daysInMonth = DateTime.DaysInMonth(year, month);
            return (int)Math.Ceiling((offset + daysInMonth) / 7.0);
        }

        private static string SlotName(int blockIndex, int weekday)      => $"{SlotPrefix}{blockIndex}_{weekday}";
        private static string SlotColorName(int blockIndex, int weekday) => $"{ColorPrefix}{blockIndex}_{weekday}";
        private static string GapName(int blockIndex)                   => $"{GapPrefix}{blockIndex}";

        private static bool TryParseSlot(string columnName, out int blockIndex, out int weekday)
        {
            blockIndex = -1; weekday = -1;
            if (!columnName.StartsWith(SlotPrefix, StringComparison.Ordinal)) return false;

            string[] parts = columnName[SlotPrefix.Length..].Split('_');
            return parts.Length == 2
                && int.TryParse(parts[0], out blockIndex)
                && int.TryParse(parts[1], out weekday);
        }

        /// <summary>"Nombre de mes AÑO" (ej. "Enero 2026"), siempre con el año, para los encabezados de mes.</summary>
        private static string MonthYearLabel(MonthBlock block)
        {
            string name = new DateTime(block.Year, block.Month, 1)
                .ToString("MMMM", ClsAsistenciaASConsulta.CultureEs);
            return $"{name} {block.Year}";
        }

        // ── Vista en el DataGridView (dgvReport) ────────────────────────────────

        /// <summary>Construye la tabla en formato calendario a partir de la misma tabla del reporte lineal.</summary>
        public DataTable BuildCalendarTable(
            DataTable reportData,
            List<DateTime> days,
            Dictionary<string, AttendanceStyle> stylesByPrefix,
            Action<int, int>? onProgress = null)
        {
            (Blocks, WeeksPerBlock) = BuildBlocks(days);

            var table = new DataTable();
            table.Columns.Add(ColKind, typeof(string));
            table.Columns.Add(ClsAsistenciaASConsulta.ReportColCodigo, typeof(string));
            table.Columns.Add(ClsAsistenciaASConsulta.ReportColNombre, typeof(string));
            table.Columns.Add(ClsAsistenciaASConsulta.ReportColLp, typeof(string));
            table.Columns.Add(ColAsist, typeof(string));
            table.Columns.Add(ColFaltas, typeof(string));
            table.Columns.Add(ColFaltas30, typeof(string));

            for (int bi = 0; bi < Blocks.Count; bi++)
            {
                for (int wd = 0; wd < 7; wd++)
                {
                    table.Columns.Add(SlotName(bi, wd), typeof(string));
                    table.Columns.Add(SlotColorName(bi, wd), typeof(string));
                }
                table.Columns.Add(GapName(bi), typeof(string));
            }

            if (Blocks.Count == 0 || WeeksPerBlock == 0) return table;

            int empCount = reportData.Rows.Count;
            int weekCount = Math.Max(1, WeeksPerBlock);
            int totalUnits = Math.Max(1, empCount * weekCount);
            int doneUnits = 0;

            foreach (DataRow empRow in reportData.Rows)
            {
                string codigo = SafeStr(empRow, ClsAsistenciaASConsulta.ReportColCodigo);
                string nombre = SafeStr(empRow, ClsAsistenciaASConsulta.ReportColNombre);
                string lp     = SafeStr(empRow, ClsAsistenciaASConsulta.ReportColLp);
                (int asistencias, int faltas, int faltas30) = CountAsistenciasYFaltas(empRow, days, stylesByPrefix);

                // Fila de nombre de mes y fila de encabezados (Código/.../Faltas + D L M M J V S), repetidas
                // para cada empleado igual que en la hoja de Excel, ya que en el DGV no se pueden combinar celdas.
                DataRow monthRow    = table.NewRow();
                DataRow weekdayRow  = table.NewRow();
                monthRow[ColKind]   = KindMonth;
                weekdayRow[ColKind] = KindWeekday;

                weekdayRow[ClsAsistenciaASConsulta.ReportColCodigo] = "CÓDIGO";
                weekdayRow[ClsAsistenciaASConsulta.ReportColNombre] = "NOMBRE COMPLETO";
                weekdayRow[ClsAsistenciaASConsulta.ReportColLp]     = "LP";
                weekdayRow[ColAsist]  = "ASIST.";
                weekdayRow[ColFaltas] = "FALTAS";
                weekdayRow[ColFaltas30] = "FALTAS 30D";

                for (int bi = 0; bi < Blocks.Count; bi++)
                {
                    MonthBlock block = Blocks[bi];
                    monthRow[SlotName(bi, 3)] = MonthYearLabel(block).ToUpper(ClsAsistenciaASConsulta.CultureEs);
                    for (int wd = 0; wd < 7; wd++)
                        weekdayRow[SlotName(bi, wd)] = DayLetters[wd];

                    monthRow[GapName(bi)]   = string.Empty;
                    weekdayRow[GapName(bi)] = string.Empty;
                }

                table.Rows.Add(monthRow);
                table.Rows.Add(weekdayRow);

                for (int week = 0; week < WeeksPerBlock; week++)
                {
                    DataRow numRow = table.NewRow();
                    DataRow valRow = table.NewRow();
                    numRow[ColKind] = KindNum;
                    valRow[ColKind] = KindVal;

                    if (week == 0)
                    {
                        numRow[ClsAsistenciaASConsulta.ReportColCodigo] = codigo;
                        numRow[ClsAsistenciaASConsulta.ReportColNombre] = nombre;
                        numRow[ClsAsistenciaASConsulta.ReportColLp]     = lp;
                        numRow[ColAsist]  = asistencias.ToString();
                        numRow[ColFaltas] = faltas.ToString();
                        numRow[ColFaltas30] = faltas30.ToString();
                    }

                    for (int bi = 0; bi < Blocks.Count; bi++)
                    {
                        MonthBlock block = Blocks[bi];
                        for (int wd = 0; wd < 7; wd++)
                        {
                            DateTime? date = block.Grid[week, wd];
                            string slot  = SlotName(bi, wd);
                            string slotC = SlotColorName(bi, wd);

                            string value = date.HasValue
                                ? SafeStr(empRow, ClsAsistenciaASConsulta.BuildDayColumnName(date.Value))
                                : string.Empty;

                            numRow[slot]  = date.HasValue ? date.Value.Day.ToString() : string.Empty;
                            valRow[slot]  = value;
                            numRow[slotC] = value;
                            valRow[slotC] = value;
                        }

                        numRow[GapName(bi)] = string.Empty;
                        valRow[GapName(bi)] = string.Empty;
                    }

                    table.Rows.Add(numRow);
                    table.Rows.Add(valRow);
                    doneUnits++;
                    onProgress?.Invoke(doneUnits, totalUnits);
                }
            }

            return table;
        }

        /// <summary>
        /// Columnas ocultas, anchos y congelado de las columnas fijas del DGV. El encabezado de columnas
        /// del control se oculta por completo: el nombre de mes y "D L M M J V S" ahora se muestran como
        /// filas del propio calendario (una vez por empleado), igual que en la hoja de Excel.
        /// </summary>
        public void ApplyHeadersAndFormatting(DataGridView dgv, Action<int, int>? onProgress = null)
        {
            dgv.ColumnHeadersVisible = false;

            // AllCells autoajustaría cada columna al contenido más ancho (por ejemplo, el nombre completo
            // del mes guardado en una de las columnas de día para poder "pintarlo" encima), descuadrando
            // el ancho uniforme de las columnas de día. En esta vista los anchos se fijan manualmente.
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            foreach (Font font in _fittingFonts.Values)
                font.Dispose();
            _fittingFonts.Clear();

            int total = Math.Max(1, dgv.Columns.Count + dgv.Rows.Count);
            int done = 0;

            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;

                if (col.Name == ColKind || col.Name.StartsWith(ColorPrefix, StringComparison.Ordinal))
                {
                    col.Visible = false;
                    done++;
                    onProgress?.Invoke(done, total);
                    continue;
                }

                if (col.Name.StartsWith(GapPrefix, StringComparison.Ordinal))
                {
                    col.Width = 12;
                    done++;
                    onProgress?.Invoke(done, total);
                    continue;
                }

                if (TryParseSlot(col.Name, out _, out _))
                {
                    col.Width = 34;
                    done++;
                    onProgress?.Invoke(done, total);
                    continue;
                }

                // Código / Nombre completo / LP / Asist. / Faltas: quedan visibles al desplazarse horizontalmente.
                col.Frozen = true;

                col.Width = col.Name switch
                {
                    ClsAsistenciaASConsulta.ReportColCodigo => 66,
                    ClsAsistenciaASConsulta.ReportColLp     => 50,
                    ColAsist                                 => 55,
                    ColFaltas                                 => 55,
                    ColFaltas30                               => 70,
                    _ => col.Width,
                };
                done++;
                onProgress?.Invoke(done, total);
            }

            // Nombre completo: se ajusta al texto más largo entre los empleados (o al del propio
            // encabezado "NOMBRE COMPLETO"), con un mínimo razonable para que no quede muy angosta.
            if (dgv.Columns.Contains(ClsAsistenciaASConsulta.ReportColNombre))
            {
                DataGridViewColumn nombreCol = dgv.Columns[ClsAsistenciaASConsulta.ReportColNombre];
                dgv.AutoResizeColumn(nombreCol.Index, DataGridViewAutoSizeColumnMode.AllCellsExceptHeader);
                if (nombreCol.Width < 220) nombreCol.Width = 220;
            }

            // Filas de nombre de mes y de encabezados (Código/.../Faltas + D L M M J V S): un poco más altas,
            // igual que en el Excel, para que se distingan de las filas de datos. El resto queda en alto fijo
            // (sin AutoSizeRows) para no medir cada celda al hacer scroll.
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.DataBoundItem is not DataRowView drv || !TryGetKind(drv, out string kind))
                {
                    done++;
                    onProgress?.Invoke(done, total);
                    continue;
                }
                if (kind == KindMonth) row.Height = 26;
                else if (kind == KindWeekday) row.Height = 30;
                else row.Height = 22;
                done++;
                onProgress?.Invoke(done, total);
            }
        }

        /// <summary>
        /// Obtiene el valor de <see cref="ColKind"/> de la fila, sin lanzar excepción si la tabla enlazada
        /// en ese momento no es la del calendario (por ejemplo, durante el intercambio de <c>DataSource</c>
        /// al cambiar de vista, cuando aún pueden llegar eventos de formato para la tabla anterior).
        /// </summary>
        private static bool TryGetKind(DataRowView drv, out string kind)
        {
            kind = string.Empty;
            if (!drv.Row.Table.Columns.Contains(ColKind)) return false;
            kind = drv[ColKind]?.ToString() ?? string.Empty;
            return true;
        }

        /// <summary>
        /// Colorea las filas/celdas de la vista calendario: fondo gris oscuro para la fila de encabezados
        /// (Código/.../Faltas + D L M M J V S), fondo por mes para la fila del nombre del mes, y el mismo
        /// color/estilo de letra por prefijo que la vista lineal para las celdas de día/valor.
        /// </summary>
        public void CellFormatting(
            DataGridViewCellFormattingEventArgs e,
            DataGridView dgv,
            Dictionary<string, AttendanceStyle> stylesByPrefix,
            Color colorAsistencia)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dgv.Rows[e.RowIndex].DataBoundItem is not DataRowView drv) return;
            if (!TryGetKind(drv, out string kind)) return;

            string colName = dgv.Columns[e.ColumnIndex].Name;

            if (kind == KindWeekday)
            {
                if (colName.StartsWith(GapPrefix, StringComparison.Ordinal)) return;
                e.CellStyle.BackColor          = ColorHeaderDark;
                e.CellStyle.SelectionBackColor = ColorHeaderDark;
                e.CellStyle.ForeColor          = Color.White;
                e.CellStyle.SelectionForeColor = Color.White;
                e.CellStyle.Font = DgvAsistenciaASPerf.GetStyledFont(dgv.Font, FontStyle.Bold);
                e.CellStyle.Alignment = colName.StartsWith(SlotPrefix, StringComparison.Ordinal)
                    ? DataGridViewContentAlignment.MiddleCenter
                    : e.CellStyle.Alignment;
                return;
            }

            if (kind == KindMonth)
            {
                if (TryParseSlot(colName, out int blockIndex, out _) && blockIndex >= 0 && blockIndex < Blocks.Count)
                {
                    Color monthColor = MonthColors[Blocks[blockIndex].Month - 1];
                    e.CellStyle.BackColor          = monthColor;
                    e.CellStyle.SelectionBackColor = monthColor;
                    e.CellStyle.ForeColor          = Color.White;
                    e.CellStyle.SelectionForeColor = Color.White;
                }
                return;
            }

            if (!colName.StartsWith(SlotPrefix, StringComparison.Ordinal)) return;

            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            string colorKeyCol = ColorPrefix + colName[SlotPrefix.Length..];
            if (!drv.Row.Table.Columns.Contains(colorKeyCol)) return;

            string value = drv[colorKeyCol]?.ToString()?.Trim() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(value)) return;

            Color color;
            FontStyle fontStyle = FontStyle.Regular;
            if (string.Equals(value, ClsAsistenciaASConsulta.ValueAsistencia, StringComparison.OrdinalIgnoreCase))
                color = colorAsistencia;
            else if (stylesByPrefix.TryGetValue(value, out AttendanceStyle style))
            {
                color = style.Color;
                fontStyle = style.FontStyle;
            }
            else
                return;

            e.CellStyle.BackColor          = color;
            e.CellStyle.SelectionBackColor = ControlPaint.Dark(color, 0.1f);

            bool isValueRow = string.Equals(drv[ColKind]?.ToString(), KindVal, StringComparison.Ordinal);
            if (isValueRow && fontStyle != FontStyle.Regular)
                e.CellStyle.Font = DgvAsistenciaASPerf.GetStyledFont(dgv.Font, fontStyle);
        }

        /// <summary>
        /// Simula la celda combinada del nombre del mes (7 columnas del bloque) dibujando manualmente sobre
        /// las columnas siguientes desde la primera, ya que <see cref="DataGridView"/> no soporta combinar
        /// celdas de forma nativa. Debe conectarse al evento <c>CellPainting</c> del DGV.
        /// </summary>
        public void CellPainting(DataGridViewCellPaintingEventArgs e, DataGridView dgv)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || e.Graphics == null) return;
            if (dgv.Rows[e.RowIndex].DataBoundItem is not DataRowView drv) return;
            if (!TryGetKind(drv, out string kind)) return;

            if (kind == KindNum || kind == KindVal)
            {
                PaintDaySlotBorder(e, dgv, kind);
                return;
            }

            if (kind != KindMonth) return;

            string colName = dgv.Columns[e.ColumnIndex].Name;
            if (!TryParseSlot(colName, out int blockIndex, out int weekday)) return;

            // El nombre del mes ya se pintó como parte del bloque de la primera columna (weekday == 0);
            // las demás columnas del mismo bloque no deben repintar nada encima.
            if (weekday != 0)
            {
                e.Handled = true;
                return;
            }

            if (blockIndex < 0 || blockIndex >= Blocks.Count) return;

            string monthLabel = SafeStr(drv.Row, SlotName(blockIndex, 3));
            Color bg = MonthColors[Blocks[blockIndex].Month - 1];

            // Se calcula el ancho combinado sumando el de las 7 columnas de día del bloque, buscándolas por
            // NOMBRE (no por índice relativo: entre cada columna "CD_" visible hay una columna "CV_" oculta
            // con el color, así que e.ColumnIndex + wd terminaba cayendo sobre esas columnas ocultas en vez
            // de las siguientes columnas de día, dando un ancho incorrecto y el texto descentrado).
            int width = 0;
            for (int wd = 0; wd < 7; wd++)
            {
                string wdColName = SlotName(blockIndex, wd);
                width += dgv.Columns.Contains(wdColName) ? dgv.Columns[wdColName].Width : e.CellBounds.Width;
            }

            Rectangle union = new(e.CellBounds.X, e.CellBounds.Y, width, e.CellBounds.Height);

            Region oldClip = e.Graphics.Clip;
            e.Graphics.SetClip(union);
            using (var brush = new SolidBrush(bg))
                e.Graphics.FillRectangle(brush, union);
            const TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine | TextFormatFlags.NoPadding;
            Font font = GetFittingFont(monthLabel, dgv.Font, FontStyle.Bold, union.Width);
            TextRenderer.DrawText(e.Graphics, monthLabel, font, union, Color.White, flags);
            e.Graphics.Clip = oldClip;

            e.Handled = true;
        }

        /// <summary>
        /// Dibuja el contorno negro de la celda del número de día y la del prefijo (fila "N" y fila "V" de
        /// la misma columna de día) como si fueran una sola celda: borde arriba/izquierda/derecha en la fila
        /// del número, abajo/izquierda/derecha en la del prefijo, y sin línea entre ambas. Las columnas que
        /// no son de día (separador entre meses, Código/Nombre/LP/Asist/Faltas) conservan el borde normal.
        /// </summary>
        private void PaintDaySlotBorder(DataGridViewCellPaintingEventArgs e, DataGridView dgv, string kind)
        {
            string colName = dgv.Columns[e.ColumnIndex].Name;
            if (!colName.StartsWith(SlotPrefix, StringComparison.Ordinal)) return;

            e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.ContentBackground
                | DataGridViewPaintParts.ContentForeground | DataGridViewPaintParts.SelectionBackground);

            Rectangle b = e.CellBounds;

            // La línea que comparten estas dos celdas (abajo de "N", arriba de "V") se repinta primero con
            // el mismo color de fondo de la celda (coincide en ambas filas, ya que usan el mismo prefijo)
            // para tapar cualquier línea de cuadrícula residual de otro color que el DataGridView dibuje ahí.
            Pen maskPen = GetMaskPen(e.CellStyle.BackColor);
            if (kind == KindNum)
                e.Graphics!.DrawLine(maskPen, b.Left, b.Bottom - 1, b.Right - 1, b.Bottom - 1);
            else
                e.Graphics!.DrawLine(maskPen, b.Left, b.Top, b.Right - 1, b.Top);

            e.Graphics!.DrawLine(BorderPen, b.Left, b.Top, b.Left, b.Bottom - 1);
            e.Graphics.DrawLine(BorderPen, b.Right - 1, b.Top, b.Right - 1, b.Bottom - 1);
            if (kind == KindNum)
                e.Graphics.DrawLine(BorderPen, b.Left, b.Top, b.Right - 1, b.Top);
            else
                e.Graphics.DrawLine(BorderPen, b.Left, b.Bottom - 1, b.Right - 1, b.Bottom - 1);

            e.Handled = true;
        }

        /// <summary>
        /// Cuenta asistencias/faltas/faltas de los últimos <see cref="Faltas30Dias"/> días usando el mismo
        /// criterio que el reporte lineal (<see cref="ClsAsistenciaASConsulta.CountsAsAsistencia"/>), para
        /// que "ASIST."/"FALTAS" coincidan exactamente entre la vista lineal y la de calendario.
        /// </summary>
        private static (int Asistencias, int Faltas, int Faltas30) CountAsistenciasYFaltas(
            DataRow empRow, List<DateTime> days, Dictionary<string, AttendanceStyle> stylesByPrefix)
        {
            var last30Days = new HashSet<DateTime>(days.TakeLast(Faltas30Dias));

            int asistencias = 0, faltas = 0, faltas30 = 0;
            foreach (DateTime day in days)
            {
                string value = SafeStr(empRow, ClsAsistenciaASConsulta.BuildDayColumnName(day));

                if (ClsAsistenciaASConsulta.CountsAsAsistencia(value, day.DayOfWeek, stylesByPrefix))
                    asistencias++;
                else
                {
                    faltas++;
                    if (last30Days.Contains(day)) faltas30++;
                }
            }
            return (asistencias, faltas, faltas30);
        }

        private static string SafeStr(DataRow row, string col)
            => row.Table.Columns.Contains(col) && row[col] != DBNull.Value
                ? row[col].ToString()?.Trim() ?? string.Empty
                : string.Empty;

        private static Pen GetMaskPen(Color color)
        {
            int key = color.ToArgb();
            if (!MaskPens.TryGetValue(key, out Pen? pen))
            {
                pen = new Pen(color);
                MaskPens[key] = pen;
            }
            return pen;
        }

        /// <summary>
        /// Devuelve una fuente basada en <paramref name="baseFont"/> cuyo tamaño se reduce (hasta un mínimo)
        /// para que <paramref name="text"/> quepa dentro de <paramref name="maxWidth"/> px. El resultado se
        /// cachea: CellPainting se dispara en cada scroll y no debe crear/destruir Font en cada llamada.
        /// </summary>
        private Font GetFittingFont(string text, Font baseFont, FontStyle style, int maxWidth)
        {
            var key = (text, maxWidth, baseFont.Size);
            if (_fittingFonts.TryGetValue(key, out Font? cached))
                return cached;

            const float minSize = 6.5f;
            const TextFormatFlags measureFlags = TextFormatFlags.NoPadding | TextFormatFlags.SingleLine;

            float size = baseFont.Size;
            Font chosen;
            while (true)
            {
                using var candidate = new Font(baseFont.FontFamily, size, style);
                int textWidth = TextRenderer.MeasureText(text, candidate, Size.Empty, measureFlags).Width;
                if (textWidth <= maxWidth || size <= minSize)
                {
                    chosen = new Font(baseFont.FontFamily, size, style);
                    break;
                }
                size -= 0.5f;
            }

            _fittingFonts[key] = chosen;
            return chosen;
        }

        // ── Hoja "Calendario" del reporte de Excel ──────────────────────────────

        /// <summary>
        /// Agrega al libro <paramref name="wb"/> la hoja "Calendario": mismos datos que la hoja lineal,
        /// pero acomodados como un calendario real (mes/semana/día) por cada empleado.
        /// </summary>
        public static void AddCalendarSheet(
            IXLWorkbook wb,
            DataTable reportData,
            List<DateTime> days,
            Dictionary<string, AttendanceStyle> stylesByPrefix,
            Color colorAsistencia,
            string dateRange,
            string legend)
        {
            if (wb == null || reportData == null || reportData.Rows.Count == 0 || days == null || days.Count == 0)
                return;

            (List<MonthBlock> blocks, int weeksPerBlock) = BuildBlocks(days);
            if (blocks.Count == 0 || weeksPerBlock == 0) return;

            var ws = wb.Worksheets.Add("Calendario");
            ws.TabColor = XLColor.FromHtml("#7030A0"); // morado

            const int startCol  = 2;
            const int fixedCols = 6; // CÓDIGO | NOMBRE COMPLETO | LP | ASIST. | FALTAS | FALTAS 30D
            int dayColStart = startCol + fixedCols + 1; // +1 columna de separación antes de los meses
            int totalCols   = (dayColStart - startCol) + blocks.Count * 8 - 1; // 7 días + 1 separador por mes (sin el último)
            int lastDayCol  = dayColStart + blocks.Count * 8 - 2;

            // ── Anchos de columna ──
            ws.Column(1).Width               = 2;
            ws.Column(startCol).Width        = PxToColumnWidth(66);      // CÓDIGO
            ws.Column(startCol + 2).Width    = PxToColumnWidth(40);      // LP
            ws.Column(startCol + 3).Width    = 7.664375;                 // ASIST.
            ws.Column(startCol + 4).Width    = 10.38;                    // FALTAS
            ws.Column(startCol + 5).Width    = 11;                       // FALTAS 30D
            ws.Column(startCol + 6).Width    = 1.4143750000000002;       // separador antes de los meses
            for (int bi = 0; bi < blocks.Count; bi++)
            {
                int blockStart = dayColStart + bi * 8;
                for (int wd = 0; wd < 7; wd++)
                    ws.Column(blockStart + wd).Width = 6.664375;
                ws.Column(blockStart + 7).Width = 2.289375; // separador entre meses
            }

            const int filtersRow = 1;
            ws.Row(filtersRow).Height = 15;
            ws.Cell(filtersRow, startCol).Value = $"Reporte de asistencias / inasistencias (calendario)  |  Fechas: {dateRange}";
            ws.Range(filtersRow, startCol, filtersRow, startCol + totalCols - 1).Merge();
            var filtersStyle = ws.Cell(filtersRow, startCol).Style;
            filtersStyle.Font.SetFontName(FontHeader);
            filtersStyle.Font.SetFontSize(12);
            filtersStyle.Fill.SetBackgroundColor(XLColor.FromColor(ColorHeaderDark));
            filtersStyle.Font.FontColor = XLColor.White;
            filtersStyle.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left);
            filtersStyle.Alignment.SetVertical(XLAlignmentVerticalValues.Top);

            int legendRow = filtersRow + 2;
            if (!string.IsNullOrWhiteSpace(legend))
            {
                ws.Cell(legendRow, startCol).Value = legend;
                var legendStyle = ws.Cell(legendRow, startCol).Style;
                legendStyle.Font.SetFontName(FontLegend);
                legendStyle.Font.SetFontSize(9);
                legendStyle.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left);
            }

            int row = legendRow + 2;

            foreach (DataRow empRow in reportData.Rows)
            {
                int monthHeaderRow = row;
                int weekdayRow      = row + 1;
                ws.Row(monthHeaderRow).Height = 15.75;
                ws.Row(weekdayRow).Height     = 23.25;

                string[] fixedHeaders = { "CÓDIGO", "NOMBRE COMPLETO", "LP", "ASIST.", "FALTAS", "FALTAS 30D" };
                for (int i = 0; i < fixedHeaders.Length; i++)
                    ws.Cell(weekdayRow, startCol + i).Value = fixedHeaders[i];

                int col = dayColStart;
                for (int bi = 0; bi < blocks.Count; bi++)
                {
                    MonthBlock block = blocks[bi];
                    int blockStart = col;
                    int blockEnd   = col + 6;

                    ws.Range(monthHeaderRow, blockStart, monthHeaderRow, blockEnd).Merge();
                    var monthCell = ws.Cell(monthHeaderRow, blockStart);
                    monthCell.Value = MonthYearLabel(block).ToUpper(ClsAsistenciaASConsulta.CultureEs); // siempre con el año, en todos los meses
                    monthCell.Style.Font.SetFontName(FontHeader);
                    monthCell.Style.Font.SetFontSize(12);
                    monthCell.Style.Font.SetBold();
                    monthCell.Style.Font.FontColor = XLColor.White;
                    monthCell.Style.Fill.SetBackgroundColor(XLColor.FromColor(MonthColors[block.Month - 1]));
                    monthCell.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left);
                    monthCell.Style.Alignment.SetVertical(XLAlignmentVerticalValues.Bottom);

                    for (int wd = 0; wd < 7; wd++)
                        ws.Cell(weekdayRow, blockStart + wd).Value = DayLetters[wd];

                    col = blockEnd + 2; // 7 días + 1 columna de separación
                }

                // Encabezados fijos (CÓDIGO/.../FALTAS) e iniciales de día de cada mes: fondo gris oscuro.
                // Las columnas separadoras (antes del primer mes y entre un mes y otro) se dejan sin color.
                ws.Range(weekdayRow, startCol, weekdayRow, lastDayCol).Style
                    .Font.SetFontName(FontHeader)
                    .Font.SetFontSize(12)
                    .Font.SetFontColor(XLColor.White)
                    .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                    .Alignment.SetVertical(XLAlignmentVerticalValues.Center);

                ws.Range(weekdayRow, startCol, weekdayRow, startCol + fixedCols - 1).Style
                    .Fill.SetBackgroundColor(XLColor.FromColor(ColorHeaderDark));
                for (int bi = 0; bi < blocks.Count; bi++)
                {
                    int blockStart = dayColStart + bi * 8;
                    ws.Range(weekdayRow, blockStart, weekdayRow, blockStart + 6).Style
                        .Fill.SetBackgroundColor(XLColor.FromColor(ColorHeaderDark));
                }

                string codigo = SafeStr(empRow, ClsAsistenciaASConsulta.ReportColCodigo);
                (int asistencias, int faltas, int faltas30) = CountAsistenciasYFaltas(empRow, days, stylesByPrefix);

                int dataRowsStart = weekdayRow + 1;
                for (int week = 0; week < weeksPerBlock; week++)
                {
                    int numRow = dataRowsStart + week * 2;
                    int valRow = numRow + 1;
                    ws.Row(numRow).Height = 14.25;
                    ws.Row(valRow).Height = 23.25;

                    ws.Range(numRow, startCol, numRow, lastDayCol).Style.Font.SetFontName(FontData).Font.SetFontSize(11);
                    ws.Range(valRow, startCol, valRow, lastDayCol).Style.Font.SetFontName(FontValue).Font.SetFontSize(18);

                    if (week == 0)
                    {
                        ws.Cell(numRow, startCol).Value     = codigo;
                        ws.Cell(numRow, startCol + 1).Value = SafeStr(empRow, ClsAsistenciaASConsulta.ReportColNombre);
                        ws.Cell(numRow, startCol + 2).Value = SafeStr(empRow, ClsAsistenciaASConsulta.ReportColLp);
                        ws.Cell(numRow, startCol + 3).Value = asistencias;
                        ws.Cell(numRow, startCol + 4).Value = faltas;
                        ws.Cell(numRow, startCol + 5).Value = faltas30;
                        ws.Range(numRow, startCol + 2, numRow, startCol + 5).Style
                            .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                        // Contorno negro (línea simple) en cada celda de datos del empleado (Código/Nombre/LP/Asist./Faltas/Faltas 30d).
                        for (int i = 0; i <= 5; i++)
                        {
                            ws.Cell(numRow, startCol + i).Style
                                .Border.SetTopBorder(XLBorderStyleValues.Thin).Border.SetTopBorderColor(BorderBlack)
                                .Border.SetBottomBorder(XLBorderStyleValues.Thin).Border.SetBottomBorderColor(BorderBlack)
                                .Border.SetLeftBorder(XLBorderStyleValues.Thin).Border.SetLeftBorderColor(BorderBlack)
                                .Border.SetRightBorder(XLBorderStyleValues.Thin).Border.SetRightBorderColor(BorderBlack);
                        }
                    }

                    col = dayColStart;
                    for (int bi = 0; bi < blocks.Count; bi++)
                    {
                        MonthBlock block = blocks[bi];
                        for (int wd = 0; wd < 7; wd++)
                        {
                            DateTime? date = block.Grid[week, wd];
                            var numCell = ws.Cell(numRow, col + wd);
                            var valCell = ws.Cell(valRow, col + wd);

                            // Contorno negro (línea simple) alrededor de cada "día" completo: la celda del número
                            // (arriba) y la del prefijo (abajo) se tratan como una sola, sin borde entre ambas.
                            // Se aplica a toda la cuadrícula del mes, incluyendo los días en blanco del inicio/fin
                            // de semana que no pertenecen al mes, para que se perciban como parte del calendario.
                            numCell.Style.Border.SetTopBorder(XLBorderStyleValues.Thin).Border.SetTopBorderColor(BorderBlack)
                                .Border.SetLeftBorder(XLBorderStyleValues.Thin).Border.SetLeftBorderColor(BorderBlack)
                                .Border.SetRightBorder(XLBorderStyleValues.Thin).Border.SetRightBorderColor(BorderBlack);
                            valCell.Style.Border.SetBottomBorder(XLBorderStyleValues.Thin).Border.SetBottomBorderColor(BorderBlack)
                                .Border.SetLeftBorder(XLBorderStyleValues.Thin).Border.SetLeftBorderColor(BorderBlack)
                                .Border.SetRightBorder(XLBorderStyleValues.Thin).Border.SetRightBorderColor(BorderBlack);

                            Color? bg = null;
                            FontStyle fontStyle = FontStyle.Regular;
                            if (date.HasValue)
                            {
                                numCell.Value = date.Value.Day;

                                string value = SafeStr(empRow, ClsAsistenciaASConsulta.BuildDayColumnName(date.Value));
                                if (!string.IsNullOrWhiteSpace(value))
                                {
                                    valCell.Value = value;
                                    valCell.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                                    if (string.Equals(value, ClsAsistenciaASConsulta.ValueAsistencia, StringComparison.OrdinalIgnoreCase))
                                        bg = colorAsistencia;
                                    else if (stylesByPrefix.TryGetValue(value, out AttendanceStyle style))
                                    {
                                        bg = style.Color;
                                        fontStyle = style.FontStyle;
                                    }

                                    if (fontStyle != FontStyle.Regular)
                                    {
                                        valCell.Style.Font.Bold          = fontStyle.HasFlag(FontStyle.Bold);
                                        valCell.Style.Font.Italic        = fontStyle.HasFlag(FontStyle.Italic);
                                        valCell.Style.Font.Strikethrough = fontStyle.HasFlag(FontStyle.Strikeout);
                                        if (fontStyle.HasFlag(FontStyle.Underline))
                                            valCell.Style.Font.Underline = XLFontUnderlineValues.Single;
                                    }
                                }
                            }

                            // Días del mes sin valor de asistencia/inasistencia, y días en blanco que no
                            // pertenecen al mes: fondo blanco explícito.
                            var xlBg = bg.HasValue ? XLColor.FromColor(bg.Value) : XLColor.White;
                            numCell.Style.Fill.SetBackgroundColor(xlBg);
                            valCell.Style.Fill.SetBackgroundColor(xlBg);
                        }

                        col += 8;
                    }
                }

                int lastRowOfBlock = dataRowsStart + weeksPerBlock * 2 - 1;
                row = lastRowOfBlock + 2; // fila en blanco de separación antes del siguiente empleado
            }

            // NOMBRE COMPLETO: se ajusta al texto más largo, con 300px como ancho mínimo por defecto.
            ws.Column(startCol + 1).AdjustToContents();
            double minNameWidth = PxToColumnWidth(300);
            if (ws.Column(startCol + 1).Width < minNameWidth)
                ws.Column(startCol + 1).Width = minNameWidth;

            ws.SheetView.FreezeColumns(startCol + 2); // Código, Nombre completo y LP
        }
    }
}
