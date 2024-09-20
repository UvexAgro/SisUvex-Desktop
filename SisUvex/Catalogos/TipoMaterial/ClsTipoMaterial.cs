using SisUvex.Usuarios;
using System.Data;
using System.Data.SqlClient;

namespace SisUvex.Catalogos.TipoMaterial
{
    internal class ClsTipoMaterial : ClsCatalogos
    {
        SQLControl sql = new SQLControl();

        //ESTA ES DIFERENTE A LAS OTRAS CLASES YA QUE NO TIENE ACTIVOS O INACTIVOS.
        public DataTable CatalogoActivos()
        {
            DataTable dt = new DataTable();
            try
            {
                sql.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM vw_PackMaterialTypeCat", sql.cnn);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo activos");
                return dt;
            }

            finally
            {
                sql.CloseConectionWrite();
            }
        }
        public void AñadirTipoMaterial(string id, string nombre, string lbs, string categoría)
        {
            try
            {
                sql.OpenConectionWrite();

                SqlCommand comId = new SqlCommand($"SELECT COUNT(id_matType) 'Id' FROM Pack_MaterialType WHERE id_matType = '{id}'", sql.cnn);
                SqlDataReader reader = comId.ExecuteReader();

                if (reader.Read())
                {

                    if (reader["Id"].ToString() == "0")
                    {
                        sql.CloseConectionWrite();
                        sql.OpenConectionWrite();

                        SqlCommand cmd = new SqlCommand("sp_PackMaterialTypeAdd", sql.cnn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@nameMatType", nombre);
                        cmd.Parameters.AddWithValue("@lbs", FormatoCeros(ValorCero(lbs),"00000.00"));
                        cmd.Parameters.AddWithValue("@bigCategory", ValorNull(categoría));
                        cmd.Parameters.AddWithValue("@userCreate", User.GetUserName());

                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        MessageBox.Show($"El código {id} ya está registrado", "Catálogo añadir" + reader["Id"].ToString());
                    } 
                }
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

        public void ModificarTipoMaterial( string id, string nombre, string lbs, string categoría)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackMaterialTypeModify", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@nameMatType", nombre);
                cmd.Parameters.AddWithValue("@lbs", ValorCero(lbs));
                cmd.Parameters.AddWithValue("@bigCategory", ValorNull(categoría));

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
        public void CboCategoria(string letra, ComboBox c)
        {
            letra = letra.ToUpper();
            for (int i = 0; i < c.Items.Count; i++)
            {
                string valor = c.GetItemText(c.Items[i]);
                if (valor.StartsWith(letra))
                {
                    c.SelectedIndex = i;
                    break;
                }
            }
        }
    }
}
