using SisUvex.Usuarios;
using System.Data;
using System.Data.SqlClient;

namespace SisUvex.Catalogos.Material
{
    internal class ClsMaterial : ClsCatalogos
    {
        private SQLControl sql = new SQLControl();

        //ESTA ES DIFERENTE A LAS OTRAS CLASES YA QUE NO TIENE ACTIVOS O INACTIVOS.

        public DataTable CatalogoActivos()
        {
            DataTable dt = new DataTable();
            try
            {
                sql.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM vw_PackMaterialCat", sql.cnn);
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
        public void AñadirMaterial(string idTipoMat, string nombre, string nombreEtiqueta, string cantidad, string cantPorUnidad, string idDistribuidor, string idColor, string idUnidad)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackMaterialAdd", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idMatType", idTipoMat);
                cmd.Parameters.AddWithValue("@idColor", idColor);
                cmd.Parameters.AddWithValue("@idDistributor", Id00Null(idDistribuidor));
                cmd.Parameters.AddWithValue("@quantMat", ValorCero(cantidad));
                cmd.Parameters.AddWithValue("@nameMat", nombre);
                cmd.Parameters.AddWithValue("@nameMatLabel", nombreEtiqueta);
                cmd.Parameters.AddWithValue("@quantMatPerUnit", ValorCero(cantPorUnidad));
                cmd.Parameters.AddWithValue("@idunit", (idUnidad));
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
        public void ModificarMaterial(string id,string nombre, string nombreEtiqueta, string cantidad, string cantPorUnidad, string idDistribuidor, string idColor, string idUnidad)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackMaterialModify", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@nameMat", nombre);
                cmd.Parameters.AddWithValue("@nameMatLabel", nombreEtiqueta);
                cmd.Parameters.AddWithValue("@quantMat", ValorCero(cantidad));
                cmd.Parameters.AddWithValue("@quantMatPerUnit", ValorCero(cantPorUnidad));
                cmd.Parameters.AddWithValue("@idDistributor", idDistribuidor);
                cmd.Parameters.AddWithValue("@idColor", idColor);
                cmd.Parameters.AddWithValue("@idunit", (idUnidad));
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
        public void CargarComboBoxes(List<ComboBox> c)
        {
            //TIPO DE MATERIAL
            CboCargarInicio(c[0], CboTipoMaterial(""));

            //DISTRIBUIDOR
            CboCargarInicio(c[1], CboDistribuidor("","*"));
            
            //COLOR
            CboCargarInicio(c[2], CboColor(""));

            //UNIDAD
            CboCargarInicio(c[3], CboUnidad("")); 
        }

        public string SiguienteMaterial(string idMatTipo)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand($"SELECT CONCAT(id_matType,FORMAT(RIGHT(max(id_material),3)+1,'000')) 'Id' FROM Pack_Material WHERE id_matType = '{idMatTipo}' GROUP BY id_matType", sql.cnn);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (dr["Id"].ToString() != string.Empty)
                    {
                        return dr["Id"].ToString();
                    }
                }
                return idMatTipo+"001";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo Id siguiente");
                return "";
            }
            finally
            {
                sql.CloseConectionRead();
            }

        }
    }
}
