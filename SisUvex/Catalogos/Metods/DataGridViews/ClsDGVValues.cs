using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisUvex.Catalogos.Metods.DataGridViews
{
    internal class ClsDGVValues
    {
        public static List<string?> GetColumnValues(DataGridView dgv, string columnName)
        {
            List<string?> values = new();

            if (!dgv.Columns.Contains(columnName))
                throw new ArgumentException($"La columna '{columnName}' no existe.");

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (!row.IsNewRow)
                {
                    values.Add(row.Cells[columnName].Value?.ToString());
                }
            }

            return values;
        }
        public static List<string?> GetUniqueColumnValues(DataGridView dgv, string columnName)
        {
            List<string?> values = new();
            HashSet<string?> addedValues = new();

            if (!dgv.Columns.Contains(columnName))
                throw new ArgumentException($"La columna '{columnName}' no existe.");

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (!row.IsNewRow)
                {
                    string? value = row.Cells[columnName].Value?.ToString();

                    if (addedValues.Add(value))
                    {
                        values.Add(value);
                    }
                }
            }

            return values;
        }
    }
}
