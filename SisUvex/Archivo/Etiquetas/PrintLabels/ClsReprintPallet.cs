using SisUvex.Catalogos.Metods;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;

namespace SisUvex.Archivo.Etiquetas.PrintLabels
{
    internal  class ClsReprintPallet
    {
        /// <summary>
        /// Fila única del pallet en <c>vw_PackPalletCon</c> (todas las columnas actuales de la vista).
        /// </summary>
        public static DataTable GetPalletPackConTable(string idPallet)
        {
            DataTable dt = new DataTable();
            SQLControl sql = new SQLControl();
            try
            {
                sql.OpenConectionWrite();
                using SqlCommand cmd = new SqlCommand("SELECT * FROM vw_PackPalletCon WHERE Pallet = @idPallet", sql.cnn);
                cmd.Parameters.AddWithValue("@idPallet", idPallet);
                using SqlDataAdapter da = new SqlDataAdapter(cmd)
                {
                    MissingSchemaAction = MissingSchemaAction.Add
                };
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Consulta pallet");
            }
            finally
            {
                sql.CloseConectionWrite();
            }

            return dt;
        }

        /// <summary>
        /// Todas las filas y columnas de <c>vw_PackPalletCon</c> para la estiba indicada (solo referencia en UI).
        /// El orden respeta Mix numérico cuando la vista incluye esa columna.
        /// </summary>
        public static DataTable GetEstibaPalletSummary(DataTable schemaFromView, object? estiba)
        {
            DataTable empty = new DataTable();
            if (estiba == null || estiba == DBNull.Value)
                return empty;

            if (!ColumnExists(schemaFromView, "Estiba"))
                return empty;

            bool hasMix = ColumnExists(schemaFromView, "Mix");
            bool hasPallet = ColumnExists(schemaFromView, "Pallet");
            string order = hasMix
                ? "ORDER BY TRY_CAST(LTRIM(RTRIM(CAST([Mix] AS NVARCHAR(50)))) AS INT), [Mix]"
                    + (hasPallet ? ", [Pallet]" : string.Empty)
                : hasPallet
                    ? "ORDER BY [Pallet]"
                    : string.Empty;

            string sqlText = $"SELECT * FROM vw_PackPalletCon WHERE [Estiba] = @estiba {order}".TrimEnd();

            DataTable dt = new DataTable();
            SQLControl sql = new SQLControl();
            try
            {
                sql.OpenConectionWrite();
                using SqlCommand cmd = new SqlCommand(sqlText, sql.cnn);
                cmd.Parameters.AddWithValue("@estiba", estiba);
                using SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Pallets en estiba");
            }
            finally
            {
                sql.CloseConectionWrite();
            }

            return dt;
        }

        public static bool ColumnExists(DataTable? table, string columnName)
        {
            if (table == null) return false;
            return table.Columns.Cast<DataColumn>().Any(c =>
                string.Equals(c.ColumnName, columnName, StringComparison.OrdinalIgnoreCase));
        }

        public static object? GetColumnValue(DataRow row, string columnName)
        {
            if (row.Table.Columns.Contains(columnName))
                return row[columnName];
            DataColumn? col = row.Table.Columns.Cast<DataColumn>().FirstOrDefault(c =>
                string.Equals(c.ColumnName, columnName, StringComparison.OrdinalIgnoreCase));
            return col == null ? null : row[col];
        }

        public static string FormatViewCellValue(object? value)
        {
            if (value == null || value == DBNull.Value)
                return string.Empty;
            if (value is DateTime dt)
                return dt.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            if (value is decimal dec)
                return dec.ToString(CultureInfo.InvariantCulture);
            if (value is double dbl)
                return dbl.ToString(CultureInfo.InvariantCulture);
            if (value is float fl)
                return fl.ToString(CultureInfo.InvariantCulture);
            return Convert.ToString(value, CultureInfo.InvariantCulture) ?? string.Empty;
        }

        public static void ReprintPalletTag(string idPallet, int copies, bool reverseOrientation, bool showDate)
        {
            if (!TryGetPalletPrintData(idPallet, out string workPlan, out int palletBoxes))
            {
                MessageBox.Show("No se encontró el pallet", "Error");
                return;
            }

            ETagInfo eTagInfo = new ETagInfo();
            eTagInfo.SetTagInfo(workPlan);
            eTagInfo.showDate = showDate;

            ClsPrintPtiTag print = new();
            print.SendToPrintPalletTag(idPallet, eTagInfo, copies, palletBoxes, reverseOrientation, true);
        }

        public static bool TryGetPalletPrintData(string idPallet, out string workPlan, out int palletBoxes)
        {
            workPlan = string.Empty;
            palletBoxes = 0;
            SQLControl sql = new SQLControl();

            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("SELECT [Plan de Trabajo], Cajas FROM vw_PackPalletCon WHERE Pallet = @idPallet", sql.cnn);
                cmd.Parameters.AddWithValue("@idPallet", idPallet);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    workPlan = reader[0].ToString() ?? string.Empty;
                    palletBoxes = Convert.ToInt32(reader[1].ToString());
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
    }
}
