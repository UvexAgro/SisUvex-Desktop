using ExcelDataReader.Log;
using iText.StyledXmlParser.Jsoup.Nodes;
using iText.StyledXmlParser.Node;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.Win32;
using SisUvex.Archivo.RegistroMaterial;
using SisUvex.Catalogos;
using SisUvex.Nomina;
using SisUvex.Usuarios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using ZXing;

namespace SisUvex.Archivo.RegistroMaterial
{
    internal class LoadDataRegistroMaterial
    {

        private SQLControl sqlControl = new SQLControl();
        private ClsCatalogos cls = new ClsCatalogos();

        private FrmRegistroMaterial form;
        public LoadDataRegistroMaterial(FrmRegistroMaterial form)
        {
            this.form = form;
        }

        public void DataLoad(DataTable tbData)
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
                        DestinationTableName = "Pack_MaterialRecord"
                    };
                    bulk.ColumnMappings.Add("Código", "id_MaterialRecord");
                    bulk.ColumnMappings.Add("Item", "id_item");
                    bulk.ColumnMappings.Add("idMaterial", "id_material");
                    bulk.ColumnMappings.Add("Cantidad", "i_quant");
                    bulk.ColumnMappings.Add("Ubicación", "v_field");
                    bulk.ColumnMappings.Add("id lote", "id_lot");
                    bulk.ColumnMappings.Add("Folio", "v_invoice");
                    bulk.ColumnMappings.Add("Fecha", "d_record");
                    bulk.ColumnMappings.Add("Proveedor", "v_supplier");
                    bulk.ColumnMappings.Add("Línea", "v_transportLine");
                    bulk.ColumnMappings.Add("Chofer", "v_driver");
                    bulk.ColumnMappings.Add("Caja", "v_freightContainer");
                    bulk.ColumnMappings.Add("Placas", "v_plate");
                    bulk.ColumnMappings.Add("Observaciones", "v_note");

                    foreach (DataRow row in tbData.Rows)
                    {
                        // Obtener los valores de la fila actual
                        string id = Convert.ToString(row["Código"]);
                        string InOut = Convert.ToString(row["Código"]).Substring(0, 1);
                        string Item = Convert.ToString(row["Item"]);
                        string idMaterial = Convert.ToString(row["idMaterial"]);
                        string cantidad = Convert.ToString(row["Cantidad"]);
                        string Ubicación = Convert.ToString(row["Ubicación"]);
                        string idLote = Convert.ToString(row["id lote"]);
                        string Folio = Convert.ToString(row["Folio"]);
                        string FechaRegistro = Convert.ToString(row["Fecha"]);
                        string Proveedor = Convert.ToString(row["Proveedor"]);
                        string Línea = Convert.ToString(row["Línea"]);
                        string Chofer = Convert.ToString(row["Chofer"]);
                        string Caja = Convert.ToString(row["Caja"]);
                        string Placas = Convert.ToString(row["Placas"]);
                        string Observaciones = Convert.ToString(row["Observaciones"]);

                        InsertRecord(conn, id, Item, InOut, idMaterial, cantidad, Ubicación, idLote, Folio, FechaRegistro, Proveedor, Línea, Chofer, Caja, Placas, Observaciones);

                        //if (!existe)
                        //{
                        //    // Realizar la operación de inserción
                        //    InsertRecord(conn, id.ToString(), nombre);
                        //}
                        //else
                        //{
                        //    // Realizar la operación de actualización
                        //    updateRecord(conn, id.ToString(), nombre);
                        //}

                        //currentRow++;
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Agregar registros [LoadData]");
            }
        }
        private void InsertRecord(SqlConnection cn,string id, string item, string inOut, string idMaterial, string quant, string field, string idLot, string invoice, string dRecord, string supplier, string transportLine, string driver, string freightContainer, string plate, string note)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_PackMaterialRecordAdd", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@item", item);
                    cmd.Parameters.AddWithValue("@inOut", inOut);
                    cmd.Parameters.AddWithValue("@idMaterial", idMaterial);
                    cmd.Parameters.AddWithValue("@quant", quant);
                    cmd.Parameters.AddWithValue("@field", field);
                    cmd.Parameters.AddWithValue("@idLot", cls.ValorNull(idLot));
                    cmd.Parameters.AddWithValue("@invoice", invoice);
                    cmd.Parameters.AddWithValue("@dRecord", dRecord);
                    cmd.Parameters.AddWithValue("@supplier", cls.ValorNull(supplier));
                    cmd.Parameters.AddWithValue("@transportLine", cls.ValorNull(transportLine));
                    cmd.Parameters.AddWithValue("@driver", cls.ValorNull(driver));
                    cmd.Parameters.AddWithValue("@freightContainer", cls.ValorNull(freightContainer));
                    cmd.Parameters.AddWithValue("@plate", cls.ValorNull(plate));
                    cmd.Parameters.AddWithValue("@note", cls.ValorNull(note));
                    cmd.Parameters.AddWithValue("@userCreate", User.GetUserName());
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Agregar registros [LoadData:InsertRecord]");
            }
        }
        private void updateRecord(SqlConnection cn, string id, string nombre)
        {
            using (SqlCommand cmd = new SqlCommand("UPDATE Nom_FoodServed SET NOMBRE = @NOMBRE WHERE ID = @ID", cn))
            {
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@NOMBRE", nombre);
                cmd.ExecuteNonQuery();
            }
        }
        private bool verifyPrimaryKey(SqlConnection cn, string id)
        {
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Nom_FoodServed WHERE ID = @ID", cn))
            {
                cmd.Parameters.AddWithValue("@ID", id);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }
    }
}
