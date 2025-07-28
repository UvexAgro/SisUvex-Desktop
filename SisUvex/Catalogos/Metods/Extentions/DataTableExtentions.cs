using System;
using System.Data;

namespace SisUvex.Catalogos.Metods.Extentions
{
    public static class DataTableExtensions
    {
        public static object? GetValue(this DataTable? dataTable, string valueColumnName, string searchColumnName, object? searchValue)
        {
            if (dataTable == null || dataTable.Rows.Count == 0)
                return null;

            // Verificar que las columnas existan
            if (!dataTable.Columns.Contains(valueColumnName)
                || !dataTable.Columns.Contains(searchColumnName))
                return null;

            foreach (DataRow row in dataTable.Rows)
            {
                object? currentValue = row[searchColumnName];

                // Comparar los valores (manejando casos donde alguno es null)
                if ((currentValue == null && searchValue == null) ||
                    (currentValue != null && currentValue.Equals(searchValue)))
                {
                    return row[valueColumnName];
                }
            }

            return null;
        }

        public static void CopyDataFrom(this DataTable? targetTable, DataTable? sourceTable)
        {
            if (sourceTable == null || targetTable == null) return;

            targetTable.Clear();

            foreach (DataRow sourceRow in sourceTable.Rows)
            {
                DataRow newRow = targetTable.NewRow();

                foreach (DataColumn column in targetTable.Columns)
                {
                    if (sourceTable.Columns.Contains(column.ColumnName))
                    {
                        newRow[column.ColumnName] = sourceRow[column.ColumnName];
                    }
                }

                targetTable.Rows.Add(newRow);
            }
        }
    }
}