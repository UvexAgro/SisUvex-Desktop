using SisUvex.Nomina;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace SisUvex.Catalogos.Nomina.LOAD
{

    internal class LoadData
    {
        SQLControl sql = new SQLControl();
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
                if (HasDuplicateIDs(tbData))
                    throw new Exception("Tiene un ID de empleado duplicado en la columna de ID.\n");

                sql.BeginTransaction();

                SqlBulkCopy bulk = new SqlBulkCopy(sql.cnn, SqlBulkCopyOptions.Default, sql.transaction)
                {
                    DestinationTableName = "Nom_Employees"
                };

                bulk.ColumnMappings.Add("ID", "id_employee");
                bulk.ColumnMappings.Add("COMEDOR", "id_dinerProvider");

                foreach (DataRow row in tbData.Rows)
                {
                    string id = Convert.ToString(row["ID"]).PadLeft(6, '0');
                    string comedor = Convert.ToString(row["COMEDOR"]).PadLeft(3, '0');

                    // Actualizar el valor de la ProgressBar
                    int progress = (int)Math.Round((double)currentRow / totalRows * 100);
                    form.UpdateProgress(progress);

                    bool existeEmpleado = verifyPrimaryKey(id);
                    bool existeComedor = verifyDinerProviderKey(comedor);

                    if (existeEmpleado && existeComedor)
                        updateRecord(id, comedor);
                    else
                        throw new Exception($"Empleado con ID {id} o Comedor con ID {comedor} no existe.");

                    currentRow++;

                }
                sql.CommitTransaction();
                result = true;
            }
            catch (Exception ex)
            {
                sql.RollbackTransaction();
                MessageBox.Show($"Error: {ex.Message}");

                if(currentRow != 0)
                form.dgvDatos.Rows[currentRow].Selected = true;
            }
            finally
            {
                sql.CloseConectionWrite();
            }

            return result;
        }

        private bool HasDuplicateIDs(DataTable tbData)
        {
            HashSet<string> ids = new HashSet<string>();
            for (int i = 0; i < tbData.Rows.Count; i++)
            {
                string id = Convert.ToString(tbData.Rows[i]["ID"]).PadLeft(6, '0');
                if (ids.Contains(id))
                {
                    form.dgvDatos.Rows[i].Selected = true;
                    return true;
                }
                ids.Add(id);
            }
            return false;
        }

        private bool verifyPrimaryKey(string id)
        {
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(id_employee) FROM Nom_Employees WHERE id_employee = @ID", sql.cnn, sql.transaction))
            {
                cmd.Parameters.AddWithValue("@ID", id);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        private bool verifyDinerProviderKey(string id)
        {
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(id_dinerProvider) FROM Nom_DinerProvider WHERE id_dinerProvider = @ID", sql.cnn, sql.transaction))
            {
                cmd.Parameters.AddWithValue("@ID", id);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        private void updateRecord(string id, string comedor)
        {
            using (SqlCommand cmd = new SqlCommand("UPDATE Nom_Employees SET id_dinerProvider = @COMEDOR, d_changeFoodServed = GETDATE() WHERE id_employee = @ID", sql.cnn, sql.transaction))
            {
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@COMEDOR", comedor);
                cmd.ExecuteNonQuery();
            }
        }

        public bool DataLoadSingleRecord(string employeeId, string dinerProviderId)
        {
            bool result = false;

            string id = employeeId.PadLeft(6, '0');
            string comedor = dinerProviderId.PadLeft(3, '0');

            try
            {
                sql.BeginTransaction();

                using (SqlConnection conn = new SqlConnection(sql.cnn.ConnectionString))
                {
                    conn.Open();

                    // Verificar si la clave primaria existe en la base de datos
                    bool existeEmpleado = verifyPrimaryKey(id);
                    bool existeComedor = verifyDinerProviderKey(comedor);

                    if (existeEmpleado && existeComedor)
                        updateRecord(id, comedor);
                    else
                        throw new Exception($"Empleado con ID {id} o Comedor con ID {comedor} no existe.");

                    sql.CommitTransaction();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                sql.RollbackTransaction();
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                sql.CloseConectionWrite();
            }

            return result;
        }
    }
}
