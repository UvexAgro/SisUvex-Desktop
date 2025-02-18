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

        public static DataTable ExecuteParameterizedQuery(string query, Dictionary<string, object> parameters)
        {
            DataTable dataTable = new DataTable();

            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand(query, sql.cnn);

                foreach (var param in parameters)
                {
                    cmd.Parameters.AddWithValue(param.Key, param.Value);
                }

                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ejecutar consulta parametrizada.");
            }
            finally
            {
                sql.CloseConectionWrite();
            }

            return dataTable;
        }

        public static string GetStringExecuteParameterizedQuery(string query, Dictionary<string, object> parameters)
        {
            string result = string.Empty;

            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand(query, sql.cnn);

                foreach (var param in parameters)
                {
                    cmd.Parameters.AddWithValue(param.Key, param.Value);
                }

                object queryResult = cmd.ExecuteScalar();
                if (queryResult != null && queryResult != DBNull.Value)
                {
                    result = queryResult.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ejecutar consulta parametrizada.");
            }
            finally
            {
                sql.CloseConectionWrite();
            }

            return result;
        }

        public static DataTable GetEmployees(string lastNamePat, string lastNameMat, string name, string line, string workGroup, string paymentPlace)
        {
            string query = @"SELECT id_employee AS 'Código', v_lastNamePat AS 'A. paterno', v_lastNameMat AS 'A. materno', v_name AS 'Nombre', 
                             id_paymentPlace AS 'LP', id_workGroup AS 'Cuadrilla', id_productionLine AS 'Línea', dpr.v_nameDinerProvider AS 'Comedor', 
                             FORMAT(emp.d_dateBirth, 'yyyy-MM-dd') AS 'F. nacimiento' 
                             FROM Nom_Employees emp 
                             LEFT JOIN Nom_DinerProvider AS dpr ON dpr.id_dinerProvider = emp.id_dinerProvider 
                             WHERE CONCAT_WS(' ', v_lastNamePat, v_lastNameMat, v_name, id_employee) LIKE @searchTerm
                             AND id_productionLine LIKE @line
                             AND id_workGroup LIKE @workGroup
                             AND id_paymentPlace LIKE @paymentPlace";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@searchTerm", $"%{lastNamePat} {lastNameMat} {name}%" },
                { "@line", $"%{line}%" },
                { "@workGroup", $"%{workGroup}%" },
                { "@paymentPlace", $"%{paymentPlace}%" }
            };

            return ClsQuerysDB.ExecuteParameterizedQuery(query, parameters);
        }
    }
}
