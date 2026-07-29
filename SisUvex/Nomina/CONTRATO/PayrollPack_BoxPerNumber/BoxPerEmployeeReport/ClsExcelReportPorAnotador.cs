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
    /// Reporte: Cajas por Anotador.
    /// Agrupa bloques por Contratista → Cuadrilla → Anotador.
    /// Cada fila es un empleado con sus cajas por Fecha/Empaque.
    /// </summary>
    internal sealed class ClsExcelReportPorAnotador
    {
        public const string SheetName = "Cajas por Anotador";
        private static readonly XLColor TabColor = XLColor.FromHtml("#0070C0");

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

        // ── Vista previa DGV ──────────────────────────────────────────────────

        public DataTable BuildPreviewDataTable(DataTable? data, DateTime rangeStart, DateTime rangeEnd)
        {
            var preview = new DataTable();
            preview.Columns.Add("NUMERO", typeof(string));
            preview.Columns.Add("CODIGO", typeof(string));
            preview.Columns.Add("NOMBRE", typeof(string));
            preview.Columns.Add("LP",     typeof(string));

            if (data == null || data.Rows.Count == 0)
                return preview;

            var colKeys = ClsPayrollBoxPerEmployeeReportExcel.BuildDateEmpaqueColumns(data, rangeStart, rangeEnd);
            foreach (var col in colKeys)
                preview.Columns.Add(col.Display, typeof(string));

            foreach (var group in BuildGroups(data))
            {
                DataRow groupRow = preview.NewRow();
                groupRow["NOMBRE"] = $"CONTRATISTA: {group.Key.Contratista} | " +
                                     $"CUADRILLA: {group.Key.Cuadrilla} | " +
                                     $"ANOTADOR: {group.Key.Anotador}";
                preview.Rows.Add(groupRow);

                foreach (var emp in group.Employees)
                {
                    DataRow r = preview.NewRow();
                    r["NUMERO"] = emp.Numero;
                    r["CODIGO"] = emp.Codigo;
                    r["NOMBRE"] = emp.Nombre;
                    r["LP"]     = emp.Lp;

                    foreach (var col in colKeys)
                        r[col.Display] = ClsPayrollBoxPerEmployeeReportExcel.FormatBoxes(group.GetValue(emp, col));

                    preview.Rows.Add(r);
                }

                preview.Rows.Add(preview.NewRow());
            }

            return preview;
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
            GroupTableModelAnotador group,
            List<DateEmpaqueColumnKey> colKeys,
            int totalCols)
        {
            // Título del grupo
            ws.Cell(row, StartCol).Value = $"{group.Key.Contratista} - {group.Key.Cuadrilla} ({group.Key.Anotador})";
            ws.Range(row, StartCol, row, StartCol + totalCols - 1).Merge();
            ws.Cell(row, StartCol).Style.Font.SetBold();
            ws.Cell(row, StartCol).Style.Fill.SetBackgroundColor(ClsPayrollBoxPerEmployeeReportExcel.ColorGroupHeader);
            row++;

            int headerRowDate   = row;
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
                    decimal val = group.GetValue(emp, c);
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

        private static List<GroupTableModelAnotador> BuildGroups(DataTable data)
        {
            var grouped = data.Rows.Cast<DataRow>()
                .GroupBy(r => new GroupKeyAnotador(
                    ClsPayrollBoxPerEmployeeReportExcel.SafeStr(r, ClsPayrollBoxPerEmployeeReport.Columns.Contratista),
                    ClsPayrollBoxPerEmployeeReportExcel.SafeStr(r, ClsPayrollBoxPerEmployeeReport.Columns.Cuadrilla),
                    data.Columns.Contains(ClsPayrollBoxPerEmployeeReport.Columns.Anotador)
                        ? ClsPayrollBoxPerEmployeeReportExcel.SafeStr(r, ClsPayrollBoxPerEmployeeReport.Columns.Anotador)
                        : string.Empty,
                    ClsPayrollBoxPerEmployeeReportExcel.SafeStr(r, ClsPayrollBoxPerEmployeeReport.Columns.IdUser)
                ))
                .OrderBy(g => g.Key.Contratista, StringComparer.OrdinalIgnoreCase)
                .ThenBy(g => g.Key.Cuadrilla,    StringComparer.OrdinalIgnoreCase)
                .ThenBy(g => g.Key.Anotador,     StringComparer.OrdinalIgnoreCase)
                .ThenBy(g => g.Key.IdUser,       StringComparer.OrdinalIgnoreCase);

            var result = new List<GroupTableModelAnotador>();
            foreach (var g in grouped)
            {
                var model = new GroupTableModelAnotador(g.Key);
                foreach (DataRow r in g) model.AddRow(r);
                model.SortEmployees();
                result.Add(model);
            }
            return result;
        }
    }

    // ── Modelos internos ──────────────────────────────────────────────────────

    internal readonly record struct GroupKeyAnotador(
        string Contratista, string Cuadrilla, string Anotador, string IdUser);

    internal readonly record struct EmployeeKey(
        string Numero, string Codigo, string Nombre, string Lp, string OrdenNum);

    internal sealed class GroupTableModelAnotador
    {
        public GroupKeyAnotador  Key       { get; }
        public List<EmployeeKey> Employees { get; } = new();

        private readonly Dictionary<(EmployeeKey, DateTime, string), decimal> _values = new();

        public GroupTableModelAnotador(GroupKeyAnotador key) { Key = key; }

        public void AddRow(DataRow row)
        {
            string numero   = ClsPayrollBoxPerEmployeeReportExcel.SafeStr(row, ClsPayrollBoxPerEmployeeReport.Columns.Numero);
            string codigo   = ClsPayrollBoxPerEmployeeReportExcel.SafeStr(row, ClsPayrollBoxPerEmployeeReport.Columns.Codigo);
            string nombre   = ClsPayrollBoxPerEmployeeReportExcel.SafeStr(row, ClsPayrollBoxPerEmployeeReport.Columns.Nombre);
            string lp       = ClsPayrollBoxPerEmployeeReportExcel.SafeStr(row, ClsPayrollBoxPerEmployeeReport.Columns.Lp);
            string ordenNum = ClsPayrollBoxPerEmployeeReportExcel.SafeStr(row, ClsPayrollBoxPerEmployeeReport.Columns.OrdenNum);

            var emp = new EmployeeKey(numero, codigo, nombre, lp, ordenNum);
            if (!Employees.Contains(emp))
                Employees.Add(emp);

            DateTime fecha  = ClsPayrollBoxPerEmployeeReportExcel.NormalizeDate(row[ClsPayrollBoxPerEmployeeReport.Columns.Fecha]);
            string   empaque = ClsPayrollBoxPerEmployeeReportExcel.SafeStr(row, ClsPayrollBoxPerEmployeeReport.Columns.Empaque);
            decimal  cajas  = ClsPayrollBoxPerEmployeeReportExcel.ToDecimal(row[ClsPayrollBoxPerEmployeeReport.Columns.Cajas]);

            if (fecha == DateTime.MinValue) return;

            var key = (emp, fecha.Date, empaque);
            _values.TryGetValue(key, out decimal current);
            _values[key] = current + cajas;
        }

        public decimal GetValue(EmployeeKey emp, DateEmpaqueColumnKey col)
        {
            if (col.Fecha == DateTime.MinValue) return 0m;
            return _values.TryGetValue((emp, col.Fecha.Date, col.Empaque), out decimal val) ? val : 0m;
        }

        public void SortEmployees()
        {
            Employees.Sort((a, b) =>
            {
                int cmp = ParseInt(a.OrdenNum).CompareTo(ParseInt(b.OrdenNum));
                if (cmp != 0) return cmp;
                cmp = ParseInt(a.Numero).CompareTo(ParseInt(b.Numero));
                if (cmp != 0) return cmp;
                return string.Compare(a.Codigo, b.Codigo, StringComparison.OrdinalIgnoreCase);
            });
        }

        private static int ParseInt(string v)
            => int.TryParse(v?.Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out int n)
                ? n : int.MaxValue;
    }
}
