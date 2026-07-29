using ClosedXML.Excel;
using SisUvex.Catalogos.Metods.ExcelLoad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;

namespace SisUvex.Nomina.CONTRATO.PayrollPack_BoxPerNumber.BoxPerEmployeeReport
{
    /// <summary>
    /// Reporte: Cajas por Cuadrilla.
    /// Agrupa bloques por Contratista → Cuadrilla (sin distinción de anotador).
    /// Cajas se suman por (Empleado, Fecha, Empaque) independientemente del anotador.
    /// El NUMERO y ORDEN_NUM de cada empleado se resuelven tomando el día más reciente
    /// en que el empleado aparece con un único número; si en todos los días hay varios,
    /// se toma el primer registro del día más reciente.
    /// </summary>
    internal sealed class ClsExcelReportPorCuadrilla
    {
        public const string SheetName = "Cajas por Cuadrilla";
        private static readonly XLColor TabColor = XLColor.FromHtml("#E46C0A");

        private const int StartCol  = 2;
        private const int FixedCols = 4; // No. | Código | Nombre | LP

        // ── Hoja de Excel ─────────────────────────────────────────────────────

        public IXLWorksheet WriteSheet(
            IXLWorkbook workbook,
            DataTable data,
            DateTime rangeStart,
            DateTime rangeEnd,
            string filtersText)
        {
            var ws = workbook.Worksheets.Add(
                ClsPayrollBoxPerEmployeeReportExcel.SanitizeSheetName(SheetName));
            ws.TabColor = TabColor;

            var groups  = BuildGroups(data);
            var colKeys = ClsPayrollBoxPerEmployeeReportExcel.BuildDateEmpaqueColumns(data, rangeStart, rangeEnd);
            int totalCols = FixedCols + colKeys.Count;

            int row = 1;
            row = WriteFiltersHeader(ws, row, filtersText, totalCols);

            foreach (var g in groups)
            {
                row = WriteGroupBlock(ws, row, g, colKeys, totalCols);
                row += 2;
            }

            ws.Columns().AdjustToContents();
            return ws;
        }

        // ── Escritura de bloques ──────────────────────────────────────────────

        private static int WriteFiltersHeader(IXLWorksheet ws, int row, string filtersText, int totalCols)
        {
            if (!string.IsNullOrWhiteSpace(filtersText))
            {
                ws.Cell(row, StartCol).Value = filtersText;
                ws.Range(row, StartCol, row, StartCol + totalCols - 1).Merge();
                var style = ws.Cell(row, StartCol).Style;
                style.Font.SetBold();
                style.Fill.SetBackgroundColor(ClsPayrollBoxPerEmployeeReportExcel.ColorHeader);
                style.Font.FontColor = XLColor.White;
                style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left);
                row += 2;
            }
            else
            {
                row += 1;
            }
            return row;
        }

        private static int WriteGroupBlock(
            IXLWorksheet ws,
            int row,
            GroupTableModelCuadrilla group,
            List<DateEmpaqueColumnKey> colKeys,
            int totalCols)
        {
            // Título del grupo (sin anotador)
            ws.Cell(row, StartCol).Value = $"{group.Key.Contratista} - {group.Key.Cuadrilla}";
            ws.Range(row, StartCol, row, StartCol + totalCols - 1).Merge();
            ws.Cell(row, StartCol).Style.Font.SetBold();
            ws.Cell(row, StartCol).Style.Fill.SetBackgroundColor(ClsPayrollBoxPerEmployeeReportExcel.ColorGroupHeader);
            row++;

            int headerRowDate    = row;
            int headerRowEmpaque = row + 1;

            // Encabezados fijos (fusionados en las 2 filas de header)
            string[] fixedHeaders = { "No.", "Código", "Nombre", "LP" };
            for (int i = 0; i < FixedCols; i++)
            {
                ws.Cell(headerRowDate, StartCol + i).Value = fixedHeaders[i];
                ws.Range(headerRowDate, StartCol + i, headerRowEmpaque, StartCol + i).Merge();
            }

            ws.Range(headerRowDate, StartCol, headerRowEmpaque, StartCol + FixedCols - 1).Style
                .Font.SetBold()
                .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                .Fill.SetBackgroundColor(ClsPayrollBoxPerEmployeeReportExcel.ColorTableHeader);

            // Encabezados dinámicos Fecha / Empaque
            int col = StartCol + FixedCols;
            foreach (var c in colKeys)
            {
                ws.Cell(headerRowDate, col).Value = c.Fecha;
                ws.Cell(headerRowDate, col).Style.DateFormat.Format = "dd-MMM";
                ws.Cell(headerRowEmpaque, col).Value = c.EmpaqueDisplay;
                col++;
            }

            ws.Range(headerRowDate, StartCol + FixedCols, headerRowEmpaque, StartCol + totalCols - 1).Style
                .Font.SetBold()
                .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                .Fill.SetBackgroundColor(ClsPayrollBoxPerEmployeeReportExcel.ColorTableHeader)
                .Border.SetOutsideBorder(XLBorderStyleValues.Medium)
                .Border.SetInsideBorder(XLBorderStyleValues.Thin);

            // Filas de datos
            row = headerRowEmpaque + 1;
            foreach (var emp in group.Employees)
            {
                ws.Cell(row, StartCol).Value     = emp.Numero;
                ws.Cell(row, StartCol + 1).Value = emp.Codigo;
                ws.Cell(row, StartCol + 2).Value = emp.Nombre;
                ws.Cell(row, StartCol + 3).Value = emp.Lp;

                decimal rowTotal = 0m;
                col = StartCol + FixedCols;
                foreach (var c in colKeys)
                {
                    decimal val = group.GetValue(emp.Codigo, c);
                    if (val != 0m)
                    {
                        var cell = ws.Cell(row, col);
                        ClsExcel.SetCellValue(cell, val);
                        cell.Style.Fill.SetBackgroundColor(ClsPayrollBoxPerEmployeeReportExcel.ColorValueCell);
                        rowTotal += val;
                    }
                    col++;
                }

                if (rowTotal == 0m)
                    ws.Range(row, StartCol, row, StartCol + totalCols - 1)
                      .Style.Fill.SetBackgroundColor(ClsPayrollBoxPerEmployeeReportExcel.ColorEmptyRow);

                row++;
            }

            // Bordes del bloque completo
            ws.Range(headerRowDate, StartCol, row - 1, StartCol + totalCols - 1).Style
                .Border.SetOutsideBorder(XLBorderStyleValues.Medium)
                .Border.SetInsideBorder(XLBorderStyleValues.Thin)
                .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

            // Columna Nombre: alineación izquierda
            ws.Column(StartCol + 2).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left);

            return row;
        }

        // ── Construcción de grupos ────────────────────────────────────────────

        private static List<GroupTableModelCuadrilla> BuildGroups(DataTable data)
        {
            var grouped = data.Rows.Cast<DataRow>()
                .GroupBy(r => new GroupKeyCuadrilla(
                    ClsPayrollBoxPerEmployeeReportExcel.SafeStr(r, ClsPayrollBoxPerEmployeeReport.Columns.Contratista),
                    ClsPayrollBoxPerEmployeeReportExcel.SafeStr(r, ClsPayrollBoxPerEmployeeReport.Columns.Cuadrilla)
                ))
                .OrderBy(g => g.Key.Contratista, StringComparer.OrdinalIgnoreCase)
                .ThenBy(g => g.Key.Cuadrilla,    StringComparer.OrdinalIgnoreCase);

            var result = new List<GroupTableModelCuadrilla>();
            foreach (var g in grouped)
                result.Add(new GroupTableModelCuadrilla(g.Key, g.ToList()));

            return result;
        }
    }

    // ── Modelos internos ──────────────────────────────────────────────────────

    internal readonly record struct GroupKeyCuadrilla(string Contratista, string Cuadrilla);

    internal sealed class EmployeeModelCuadrilla
    {
        public string Numero   { get; set; } = string.Empty;
        public string OrdenNum { get; set; } = string.Empty;
        public string Codigo   { get; set; } = string.Empty;
        public string Nombre   { get; set; } = string.Empty;
        public string Lp       { get; set; } = string.Empty;
    }

    internal sealed class GroupTableModelCuadrilla
    {
        public GroupKeyCuadrilla        Key       { get; }
        public List<EmployeeModelCuadrilla> Employees { get; } = new();

        // (Codigo, Fecha, Empaque) → suma de cajas (sin importar NUMERO/anotador)
        private readonly Dictionary<(string Codigo, DateTime Fecha, string Empaque), decimal> _values = new();

        public GroupTableModelCuadrilla(GroupKeyCuadrilla key, IList<DataRow> rows)
        {
            Key = key;

            foreach (var empGroup in rows.GroupBy(r =>
                ClsPayrollBoxPerEmployeeReportExcel.SafeStr(r, ClsPayrollBoxPerEmployeeReport.Columns.Codigo)))
            {
                string codigo = empGroup.Key;
                if (string.IsNullOrWhiteSpace(codigo)) continue;

                var firstRow = empGroup.First();
                var (numero, ordenNum) = ResolveNumero(empGroup);

                Employees.Add(new EmployeeModelCuadrilla
                {
                    Codigo   = codigo,
                    Nombre   = ClsPayrollBoxPerEmployeeReportExcel.SafeStr(firstRow, ClsPayrollBoxPerEmployeeReport.Columns.Nombre),
                    Lp       = ClsPayrollBoxPerEmployeeReportExcel.SafeStr(firstRow, ClsPayrollBoxPerEmployeeReport.Columns.Lp),
                    Numero   = numero,
                    OrdenNum = ordenNum,
                });

                // Agregar cajas sumadas por (Codigo, Fecha, Empaque)
                foreach (DataRow row in empGroup)
                {
                    DateTime fecha  = ClsPayrollBoxPerEmployeeReportExcel.NormalizeDate(row[ClsPayrollBoxPerEmployeeReport.Columns.Fecha]);
                    string   empaque = ClsPayrollBoxPerEmployeeReportExcel.SafeStr(row, ClsPayrollBoxPerEmployeeReport.Columns.Empaque);
                    decimal  cajas  = ClsPayrollBoxPerEmployeeReportExcel.ToDecimal(row[ClsPayrollBoxPerEmployeeReport.Columns.Cajas]);

                    if (fecha == DateTime.MinValue) continue;

                    var vKey = (codigo, fecha.Date, empaque);
                    _values.TryGetValue(vKey, out decimal current);
                    _values[vKey] = current + cajas;
                }
            }

            SortEmployees();
        }

        public decimal GetValue(string codigo, DateEmpaqueColumnKey col)
        {
            if (col.Fecha == DateTime.MinValue) return 0m;
            return _values.TryGetValue((codigo, col.Fecha.Date, col.Empaque), out decimal val) ? val : 0m;
        }

        private void SortEmployees()
        {
            Employees.Sort((a, b) =>
            {
                int cmp = ParseInt(a.Numero).CompareTo(ParseInt(b.Numero));
                if (cmp != 0) return cmp;
                cmp = ParseInt(a.OrdenNum).CompareTo(ParseInt(b.OrdenNum));
                if (cmp != 0) return cmp;
                return string.Compare(a.Codigo, b.Codigo, StringComparison.OrdinalIgnoreCase);
            });
        }

        /// <summary>
        /// Devuelve el NUMERO y ORDEN_NUM correspondiente al empleado:
        /// se toma el día más reciente en que aparece con un único número.
        /// Si todos los días tienen varios números, se usa el primero del día más reciente.
        /// </summary>
        private static (string Numero, string OrdenNum) ResolveNumero(IEnumerable<DataRow> employeeRows)
        {
            var byDate = employeeRows
                .GroupBy(r => ClsPayrollBoxPerEmployeeReportExcel.NormalizeDate(r[ClsPayrollBoxPerEmployeeReport.Columns.Fecha]))
                .Where(g => g.Key != DateTime.MinValue)
                .OrderByDescending(g => g.Key)
                .ToList();

            foreach (var dayGroup in byDate)
            {
                var numeros = dayGroup
                    .Select(r => (
                        Numero:   ClsPayrollBoxPerEmployeeReportExcel.SafeStr(r, ClsPayrollBoxPerEmployeeReport.Columns.Numero),
                        OrdenNum: ClsPayrollBoxPerEmployeeReportExcel.SafeStr(r, ClsPayrollBoxPerEmployeeReport.Columns.OrdenNum)
                    ))
                    .Distinct()
                    .ToList();

                if (numeros.Count == 1)
                    return numeros[0];
            }

            // Fallback: primer registro del día más reciente
            if (byDate.Count > 0)
            {
                DataRow r = byDate[0].First();
                return (
                    ClsPayrollBoxPerEmployeeReportExcel.SafeStr(r, ClsPayrollBoxPerEmployeeReport.Columns.Numero),
                    ClsPayrollBoxPerEmployeeReportExcel.SafeStr(r, ClsPayrollBoxPerEmployeeReport.Columns.OrdenNum)
                );
            }

            return (string.Empty, string.Empty);
        }

        private static int ParseInt(string v)
            => int.TryParse(v?.Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out int n)
                ? n : int.MaxValue;
    }
}
