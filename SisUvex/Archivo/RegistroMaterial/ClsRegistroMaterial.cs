using SisUvex.Usuarios;
using System.ComponentModel;
using System;
using System.Data;
using System.Data.SqlClient;
using SisUvex.Catalogos;
using System.Windows.Forms;
using iText.StyledXmlParser.Node;
using iText.Layout.Element;

namespace SisUvex.Catalogos.RegistroMaterial
{
    internal class ClsRegistroMaterial : ClsCatalogos
    {
        SQLControl sql = new SQLControl();
        public DataTable CatalogoActualizar(string Status, DateTime fecha1, DateTime fecha2)
        {
            DataTable dt = new DataTable();

            if (Status == "E")
                dt = CatalogoActivosFechas("S", fecha1, fecha2);
            else if (Status == "S")
                dt = CatalogoActivosFechas("E", fecha1, fecha2);
            else
                dt = CatalogoActivosFechas("T", fecha1, fecha2);

            return dt;
        }
        public DataTable CatalogoActivos(string inOut)
        {
            DataTable dt = new DataTable();
            try
            {
                sql.OpenConectionWrite();
                SqlCommand c = new SqlCommand("SELECT * FROM vw_PackMaterialRecordCat WHERE LEFT(Código, 1) != @inOut", sql.cnn);
                c.Parameters.AddWithValue("@inOut", inOut);
                SqlDataAdapter da = new SqlDataAdapter(c);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálago registro material");
                return dt;
            }

            finally
            {
                sql.CloseConectionWrite();
            }
        }
        public DataTable CatalogoActivosFechas(string activo, DateTime fecha1, DateTime fecha2)
        {
            if (activo == "E")
                activo = ("S");
            else if (activo == "S")
                activo = ("E");
            else
                activo = ("T");


            DataTable dt = new DataTable();
            try
            {
                sql.OpenConectionWrite();
                SqlCommand c = new SqlCommand("SELECT * FROM vw_PackMaterialRecordCat WHERE LEFT(Código, 1) != @Active AND Fecha BETWEEN CONVERT(DATE,@FechaInicio) AND CONVERT(DATE,@FechaFin)", sql.cnn);
                c.Parameters.AddWithValue("@Active", activo);
                c.Parameters.AddWithValue("@FechaInicio", fecha1);
                c.Parameters.AddWithValue("@FechaFin", fecha2);
                SqlDataAdapter da = new SqlDataAdapter(c);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálago registro material");
                return dt;
            }

            finally
            {
                sql.CloseConectionWrite();
            }
        }
        public void CargarComboBoxes(List<ComboBox> c)
        {
            //TIPO MATERIAL
            CboCargarEnBlanco(c[0], CboTipoMaterial(""));
            //MATERIAL
            CboCargarInicio(c[1], CboMaterial("", ""));
            //LOTE
            CboCargarEnBlanco(c[2], CboLote("", "*"));
            //PROVEEDOR
            c[3].DataSource = CboMatProveedor("");
            c[3].DisplayMember = "Nombre";
            c[3].SelectedIndex = -1;
            //LINEA DE TRANSPORTE
            c[4].DataSource = CboMatLineaTransporte("");
            c[4].DisplayMember = "Nombre";
            c[4].SelectedIndex = -1;
        }
        public void AñadirRegistroMaterial(string activo, string id)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackDriverAdd", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@active", activo);
                cmd.Parameters.AddWithValue("@idTransportLine", id);
                cmd.Parameters.AddWithValue("@nameDriver", id);
                cmd.Parameters.AddWithValue("@lastNameDriver", id);
                cmd.Parameters.AddWithValue("@license", id);
                cmd.Parameters.AddWithValue("@birthday", id);
                cmd.Parameters.AddWithValue("@visa", id);
                cmd.Parameters.AddWithValue("@userCreate", User.GetUserName());

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo añadir");
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }

        public void ModificarRegistroMaterial(string id, string activo)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackDriverModify", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@active", activo);
                cmd.Parameters.AddWithValue("@idTransportLine", id);
                cmd.Parameters.AddWithValue("@nameDriver", id);
                cmd.Parameters.AddWithValue("@lastNameDriver", id);
                cmd.Parameters.AddWithValue("@license", id);
                cmd.Parameters.AddWithValue("@birthday", id);
                cmd.Parameters.AddWithValue("@visa", id);
                cmd.Parameters.AddWithValue("@userUpdate", User.GetUserName());
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo modificar");
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
        public void EliminarRegistroMaterial(string id)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackMaterialRecordDelete", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo eliminar");
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }

        public string SiguienteRegistroMaterial(string inOut)
        {
            string id = string.Empty;
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand($"SELECT '{inOut}' + COALESCE(FORMAT(MAX(CAST(SUBSTRING(id_MaterialRecord, 2, LEN(id_MaterialRecord)) AS INT)) + 1, '0000'), '0001') AS 'Id' FROM Pack_MaterialRecord WHERE c_inOut = '{inOut}'", sql.cnn);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    id =  dr["Id"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo Id siguiente");
            }
            finally
            {
                sql.CloseConectionRead();
            }
            return id;

        }

        public string SiguienteItem(DataGridView dgv)
        {
            int maxItem = 0;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (int.TryParse(row.Cells["Item"].Value.ToString(), out int item))
                {
                    if (item > maxItem)
                    {
                        maxItem = item;
                    }
                }
            }

            string siguienteItem = (maxItem + 1).ToString("00");
            return siguienteItem;
        }

        public void LlenarDTGMateriales(string dgvIdCat, DataGridView dgvDestino, ref string UsrCreador, ref string FechaCreacion)
        {
            FechaCreacion = DateTime.Now.ToString("yyyy-MM-dd");
            UsrCreador = User.GetUserName();
            try
            {
                sql.OpenConectionWrite();
                SqlCommand c = new SqlCommand("SELECT * from vw_PackMaterialRecordCat WHERE Código = @id", sql.cnn);
                c.Parameters.AddWithValue("@id", dgvIdCat);
                SqlDataAdapter da = new SqlDataAdapter(c);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    FechaCreacion = dt.Rows[0]["Fecha creación"].ToString();
                    UsrCreador = dt.Rows[0]["Creado por"].ToString();
                }

                dgvDestino.Rows.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    object[] values = new object[dgvDestino.ColumnCount];
                    for (int i = 0; i < dgvDestino.ColumnCount; i++)
                    {
                        if (dgvDestino.Columns[i].Name == "Fecha")
                        {
                            DateTime fecha = Convert.ToDateTime(row[i]);
                            values[i] = fecha.ToString("yyyy-MM-dd");
                        }
                        else
                        {
                            values[i] = row[i];
                        }
                    }
                    dgvDestino.Rows.Add(values);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo modificar");
            }

            finally
            {
                sql.CloseConectionWrite();
            }
        }

        public void CambiarValoresColumnaId(DataGridView dgv, string inOut)
        {
            string id = SiguienteRegistroMaterial(inOut);


            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.Cells["Código"].Value = id;
            }
        }
        public void CambiarValoresColumnaFecha(DataGridView dgv, string fecha)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.Cells["FechaRegistro"].Value = fecha;
            }
        }

        public void BtnModificarSelRegistroMat(DataGridView dgv, TextBox id, TextBox item, DateTimePicker fecha, ComboBox campo, TextBox idlote,ComboBox lote , TextBox folio, ComboBox proveedor, ComboBox linea, TextBox chofer, TextBox caja, TextBox placas, TextBox idMaterial, ComboBox material, EventHandler materialTextChanged, TextBox cantidad, TextBox unidad, TextBox observaciones, TextBox idTipoMat, ComboBox tipoMat)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                tipoMat.Text = string.Empty;
                idTipoMat.Text = string.Empty;

                DataGridViewRow row = dgv.SelectedRows[0];

                id.Text = row.Cells["Código"].Value.ToString();
                item.Text = row.Cells["Item"].Value.ToString();
                fecha.Value = Convert.ToDateTime(row.Cells["FechaRegistro"].Value.ToString());
                campo.Text = row.Cells["Ubicacion"].Value.ToString();
                idlote.Text = row.Cells["idLote"].Value.ToString();
                folio.Text = row.Cells["Folio"].Value.ToString();
                proveedor.Text = row.Cells["Proveedor"].Value.ToString();
                linea.Text = row.Cells["Linea"].Value.ToString();
                chofer.Text = row.Cells["Chofer"].Value.ToString();
                caja.Text = row.Cells["Caja"].Value.ToString();
                placas.Text = row.Cells["Placas"].Value.ToString();
                idMaterial.Text = row.Cells["idMaterial"].Value.ToString();
                cantidad.Text = row.Cells["Cantidad"].Value.ToString();
                unidad.Text = row.Cells["Unidad"].Value.ToString();
                observaciones.Text = row.Cells["Observaciones"].Value.ToString();

                CboIndiceValue(lote, idlote);
                CboIndiceValueTextChanged(material, idMaterial, materialTextChanged);

            }
        }

        public void BorrarFilaConItem(DataGridView dataGridView, string valorCelda)
        {
            DataGridViewRow filaBorrar = null;

            foreach (DataGridViewRow fila in dataGridView.Rows)
            {
                if (fila.Cells["Item"].Value != null && fila.Cells["Item"].Value.ToString() == valorCelda)
                {
                    filaBorrar = fila;
                    break;
                }
            }
            if (filaBorrar != null)
            {
                dataGridView.Rows.Remove(filaBorrar);
            }
        }
    }
}