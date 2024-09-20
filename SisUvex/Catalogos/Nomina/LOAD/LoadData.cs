using Microsoft.Data.SqlClient;
using SisUvex.Nomina;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SisUvex.Catalogos.Nomina.LOAD
{

    internal class LoadData
    {
        SQLControl sqlControl = new SQLControl();
        private UExcel form;

        public LoadData(UExcel form)
        {
            this.form = form;
        }

        public bool DataLoad(DataTable tbData)
        {
            bool result = false;
            int totalRows = tbData.Rows.Count;
            int currentRow = 0;

            try
            {
                sqlControl.OpenConectionWrite();

                using (SqlConnection conn = new SqlConnection(sqlControl.cnn.ConnectionString))
                {
                    conn.Open();
                    SqlBulkCopy bulk = new SqlBulkCopy(conn)
                    {
                        DestinationTableName = "Nom_Employees"
                    };

                    bulk.ColumnMappings.Add("ID", "id_employee");
                    bulk.ColumnMappings.Add("COMEDOR", "id_dinerProvider");
                    //bulk.ColumnMappings.Add("STATUS", "c_active");

                    foreach (DataRow row in tbData.Rows)
                    {
                        // Obtener los valores de la fila actual
                        string id = Convert.ToString(row["ID"]).PadLeft(6, '0');
                        string comedor = Convert.ToString(row["COMEDOR"]).PadLeft(3, '0');
                        //string status = Convert.ToString(row["STATUS"]);

                        // Actualizar el valor de la ProgressBar
                        int progress = (int)Math.Round((double)currentRow / totalRows * 100);
                        form.UpdateProgress(progress);

                        // Verificar si la clave primaria existe en la base de datos
                        bool existe = verifyPrimaryKey(conn, id);

                        if (!existe)
                        {
                            // Realizar la operación de inserción
                            InsertRecord(conn, id, comedor/*status*/);
                        }
                        else
                        {
                            // Realizar la operación de actualización
                            updateRecord(conn, id, comedor/*status*/);
                        }

                        currentRow++;
                    }
                    result = true;
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return result;
        }

        private bool verifyPrimaryKey(SqlConnection cn, string id)
        {
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Nom_Employees WHERE id_employee = @ID", cn))
            {
                cmd.Parameters.AddWithValue("@ID", id);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        private void InsertRecord(SqlConnection cn, string id, string comedor/*string status*/)
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Nom_Employees (id_employee, id_dinerProvider, d_changeFoodServed) VALUES (@ID, @COMEDOR, GETDATE())", cn))
            {
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@COMEDOR", comedor);
                //cmd.Parameters.AddWithValue("@STATUS", status);
                cmd.ExecuteNonQuery();
            }
        }

        private void updateRecord(SqlConnection cn, string id, string comedor/*string status*/)
        {
            using (SqlCommand cmd = new SqlCommand("UPDATE Nom_Employees SET id_dinerProvider = @COMEDOR, d_changeFoodServed = GETDATE() WHERE id_employee = @ID", cn))
            {
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@COMEDOR", comedor);
                //cmd.Parameters.AddWithValue("@STATUS", status);
                cmd.ExecuteNonQuery();
            }
        }

    }
}
