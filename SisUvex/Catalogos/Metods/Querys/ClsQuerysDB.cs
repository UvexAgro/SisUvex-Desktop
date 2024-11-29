using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SisUvex.Catalogos.Metods.Querys
{
    internal static class ClsQuerysDB
    {
        private static SQLControl sql = new SQLControl();
        public static DataTable GetDataTable(string query)
        {
            DataTable dataTable = new DataTable();

            try
            {
                sql.OpenConectionWrite();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, sql.cnn);
                dataAdapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Obtener tabla de consulta.");
            }
            finally
            {
                sql.CloseConectionWrite();
            }

            return dataTable;
        }
        public static string GetData(string query)
        {
            string dato = string.Empty;

            try
            {
                sql.OpenConectionWrite();

                SqlCommand cmd = new SqlCommand(query, sql.cnn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                    {
                        dato = reader[0].ToString();
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Obtener dato de consulta.");
                return string.Empty;
            }
            finally
            {
                sql.CloseConectionWrite();
            }

            return dato;
        }
        public static bool ExecuteQuery(string query)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand(query, sql.cnn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ejecutar consulta.");
                return false;
            }
            finally
            {
                sql.CloseConectionWrite();
            }
            return true;
        }
    }
}
