using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisUvex.Catalogos.Metods.Extentions
{
    public static class ComboBoxExtensions
    {/// <summary>
     /// Gets the value of a specific column from the ComboBox's DataSource
     /// for the currently selected item.
     /// </summary>
     /// <param name="combo">ComboBox to get the value from</param>
     /// <param name="columnName">Name of the column to retrieve</param>
     /// <returns>The cell value or null if not found</returns>
        public static object GetColumnValue(this ComboBox combo, string columnName)
        {
            if (combo == null)
                throw new ArgumentNullException(nameof(combo));

            if (string.IsNullOrEmpty(columnName))
                throw new ArgumentNullException(nameof(columnName));

            if (combo.SelectedIndex == -1)
                return null;

            if (combo.DataSource is DataTable dataTable)
            {
                return GetValueFromDataSource(combo, dataTable, columnName);
            }

            if (combo.DataSource is BindingSource bindingSource && bindingSource.DataSource is DataTable dt)
            {
                return GetValueFromDataSource(combo, dt, columnName);
            }

            throw new InvalidOperationException("ComboBox's DataSource is not a DataTable or BindingSource with DataTable");
        }

        private static object GetValueFromDataSource(ComboBox combo, DataTable dataTable, string columnName)
        {
            if (!dataTable.Columns.Contains(columnName))
                throw new ArgumentException($"Column '{columnName}' doesn't exist in the ComboBox's DataSource");

            if (combo.SelectedItem is DataRowView selectedRowView)
            {
                return selectedRowView[columnName];
            }

            if (combo.SelectedItem is DataRow selectedRow)
            {
                return selectedRow[columnName];
            }

            return null;
        }

        /// <summary>
        /// Strongly-typed generic version
        /// </summary>
        public static T GetColumnValue<T>(this ComboBox combo, string columnName)
        {
            object value = combo.GetColumnValue(columnName);

            if (value == null || value == DBNull.Value)
                return default(T);

            try
            {
                return (T)Convert.ChangeType(value, typeof(T));
            }
            catch (InvalidCastException)
            {
                throw new InvalidCastException($"Cannot convert column '{columnName}' value to type {typeof(T).Name}");
            }
        }
    }
}
