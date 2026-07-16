using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using ClosedXML.Excel;

namespace SisUvex.Catalogos.Metods.ExcelLoad
{
    public class ExcelDocument : IDisposable
    {
        private readonly XLWorkbook _workbook;
        private readonly string _filePath;
        private readonly List<ExcelSheet> _sheets;

        public string FileName { get; }
        public string FullPath => Path.Combine(_filePath, FileName);
        public IReadOnlyList<ExcelSheet> Sheets => _sheets.AsReadOnly();

        public ExcelDocument(string fileName, string filePath = "")
        {
            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentException("El nombre del archivo no puede estar vacío");

            FileName = fileName.EndsWith(".xlsx") ? fileName : $"{fileName}.xlsx";
            _filePath = string.IsNullOrWhiteSpace(filePath) ?
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop) :
                filePath;

            _workbook = new XLWorkbook();
            _sheets = new List<ExcelSheet>();
        }

        public ExcelSheet AddSheet(string sheetName, DataTable data = null, bool createTable = true)
        {
            if (string.IsNullOrWhiteSpace(sheetName))
                throw new ArgumentException("El nombre de la hoja no puede estar vacío");

            var worksheet = _workbook.Worksheets.Add(sheetName);
            var excelSheet = new ExcelSheet(worksheet, sheetName);

            if (data != null)
            {
                if (createTable)
                {
                    excelSheet.AddTable(data);
                }
                else
                {
                    excelSheet.AddData(data);
                }
            }

            _sheets.Add(excelSheet);
            return excelSheet;
        }

        public void Save()
        {
            Directory.CreateDirectory(_filePath);
            _workbook.SaveAs(FullPath);
        }

        public void SaveAs(string newFileName, string newFilePath = null)
        {
            var actualPath = string.IsNullOrWhiteSpace(newFilePath) ? _filePath : newFilePath;
            var fullPath = Path.Combine(actualPath,
                newFileName.EndsWith(".xlsx") ? newFileName : $"{newFileName}.xlsx");

            Directory.CreateDirectory(actualPath);
            _workbook.SaveAs(fullPath);
        }

        public void Dispose()
        {
            _workbook?.Dispose();
            GC.SuppressFinalize(this);
        }
    }

    public class ExcelSheet
    {
        private readonly IXLWorksheet _worksheet;
        public string Name { get; }
        public List<ExcelTable> Tables { get; }
        public List<ExcelCell> CustomCells { get; }

        internal ExcelSheet(IXLWorksheet worksheet, string name)
        {
            _worksheet = worksheet;
            Name = name;
            Tables = new List<ExcelTable>();
            CustomCells = new List<ExcelCell>();
        }

        public ExcelSheet AddData(DataTable data)
        {
            if (data == null) return this;

            // Escribir encabezados
            for (int col = 0; col < data.Columns.Count; col++)
            {
                _worksheet.Cell(1, col + 1).Value = data.Columns[col].ColumnName;
            }

            // Escribir datos
            for (int row = 0; row < data.Rows.Count; row++)
            {
                for (int col = 0; col < data.Columns.Count; col++)
                {
                    var cell = _worksheet.Cell(row + 2, col + 1);
                    cell.Value = ConvertToXLCellValue(data.Rows[row][col]);
                    ApplyAutoFormat(cell, data.Rows[row][col]);
                }
            }

            return this;
        }

        public ExcelTable AddTable(DataTable data, string tableName = null)
        {
            if (data == null) return null;

            // Determinar posición
            var firstRow = Tables.Count == 0 ? 1 : Tables[^1].Range.LastRow().RowNumber() + 3;

            // Escribir datos
            AddData(data);

            // Crear rango y tabla
            var range = _worksheet.Range(
                firstRow, 1,
                firstRow + data.Rows.Count, data.Columns.Count);

            var table = range.CreateTable(tableName ?? $"Tabla{Tables.Count + 1}");

            // Guardar referencia
            var excelTable = new ExcelTable(table, range);
            Tables.Add(excelTable);

            return excelTable;
        }

        public ExcelSheet AddCell(int row, int column, object value, string format = null)
        {
            var cell = _worksheet.Cell(row, column);
            cell.Value = ConvertToXLCellValue(value);

            if (!string.IsNullOrWhiteSpace(format))
            {
                cell.Style.NumberFormat.Format = format;
            }
            else
            {
                ApplyAutoFormat(cell, value);
            }

            CustomCells.Add(new ExcelCell(row, column, value, format));
            return this;
        }

        public ExcelSheet SetColumnFormat(int column, string format)
        {
            _worksheet.Column(column).Style.NumberFormat.Format = format;
            return this;
        }

        public ExcelSheet AutoFitColumns()
        {
            _worksheet.Columns().AdjustToContents();
            return this;
        }

        private XLCellValue ConvertToXLCellValue(object value)
        {
            if (value == null || value == DBNull.Value)
                return Blank.Value;

            switch (value)
            {
                case string s:
                    return s;
                case int i:
                    return i;
                case double d:
                    return d;
                case decimal dec:
                    return (double)dec;
                case float f:
                    return f;
                case bool b:
                    return b;
                case DateTime dt:
                    return dt;
                case TimeSpan ts:
                    return ts.ToString();
                case IConvertible convertible:
                    return convertible.ToString(CultureInfo.InvariantCulture);
                default:
                    return value.ToString();
            }
        }

        private void ApplyAutoFormat(IXLCell cell, object value)
        {
            if (value == null || value == DBNull.Value)
                return;

            switch (Type.GetTypeCode(value.GetType()))
            {
                case TypeCode.DateTime:
                    cell.Style.DateFormat.Format = "dd/MM/yyyy";
                    break;
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    cell.Style.NumberFormat.Format = "#,##0.00";
                    break;
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    cell.Style.NumberFormat.Format = "0";
                    break;
            }
        }
    }

    public class ExcelTable
    {
        public IXLTable Table { get; }
        public IXLRange Range { get; }
        public string Name => Table.Name;

        internal ExcelTable(IXLTable table, IXLRange range)
        {
            Table = table;
            Range = range;
        }

        public ExcelTable SetStyle(ExcelTableStyle style)
        {
            Table.ShowHeaderRow = true;
            Table.Theme = XLTableTheme.FromName(style.ToString());
            return this;
        }
    }

    public class ExcelCell
    {
        public int Row { get; }
        public int Column { get; }
        public object Value { get; }
        public string Format { get; }

        internal ExcelCell(int row, int column, object value, string format)
        {
            Row = row;
            Column = column;
            Value = value;
            Format = format;
        }
    }

    public enum ExcelTableStyle
    {
        Light1,
        Light2,
        Medium1,
        Medium2,
        Dark1,
        Dark2
    }
}
