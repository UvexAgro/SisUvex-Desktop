using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Usuarios;
using System.Data;
using System.Data.SqlClient;

namespace SisUvex.Catalogos.Consignatario
{
    internal class ClsConsignatario : ClsCatalogos
    {
        SQLControl sql = new SQLControl();
        public DataTable CatalogoActualizar(bool Status)
        {
            DataTable dt = new DataTable();

            if (Status)
                dt = CatalogoActivos("0");
            else
                dt = CatalogoActivos("*");

            return dt;
        }
        public DataTable CatalogoActivos(string activo)
        {
            DataTable dt = new DataTable();
            try
            {
                sql.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter($"SELECT * FROM vw_PackConsigneeCat WHERE Activo != '{activo}'", sql.cnn);
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
        public void AñadirConsignatario(string activo, string nombre, string idDistribuidor, string dirección, string ciudad, string país, string rfc, string telefono)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackConsigneeAdd", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nameConsignee", nombre);
                cmd.Parameters.AddWithValue("@idDistributor", Id00Null(idDistribuidor));
                cmd.Parameters.AddWithValue("@address", ValorNull(dirección));
                cmd.Parameters.AddWithValue("@city", ValorNull(ciudad));
                cmd.Parameters.AddWithValue("@country", ValorNull(país));
                cmd.Parameters.AddWithValue("@RFC", ValorNull(rfc));
                cmd.Parameters.AddWithValue("@phoneNumber", ValorNull(telefono));
                cmd.Parameters.AddWithValue("@active", activo);
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

        public void ModificarConsignatario(string id, string activo, string nombre, string idDistribuidor, string dirección, string ciudad, string país, string rfc, string telefono)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackConsigneeModify", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@nameConsignee", nombre);
                cmd.Parameters.AddWithValue("@idDistributor", Id00Null(idDistribuidor));
                cmd.Parameters.AddWithValue("@address", ValorNull(dirección));
                cmd.Parameters.AddWithValue("@city", ValorNull(ciudad));
                cmd.Parameters.AddWithValue("@country", ValorNull(país));
                cmd.Parameters.AddWithValue("@RFC", ValorNull(rfc));
                cmd.Parameters.AddWithValue("@phoneNumber", ValorNull(telefono));
                cmd.Parameters.AddWithValue("@active", activo);
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

        public void RecuperarConsignatario(string id)
        {

            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackConsigneeRecover", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@userUpdate", User.GetUserName());

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo recuperar");
            }
            finally
            {
                sql.CloseConectionWrite();
            }

        }

        public void EliminarConsignatario(string id)
        {

            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackConsigneeDelete", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@userUpdate", User.GetUserName());

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo recuperar");
            }
            finally
            {
                sql.CloseConectionWrite();
            }

        }

        public string SiguienteConsignatario()
        {
            return ClsQuerysDB.GetData("SELECT FORMAT(COALESCE(MAX(id_consignee), 0) + 1, '00') FROM Pack_Consignee");
        }

        public void LlenarFormulario(string dgvId, TextBox id, ComboBox activo, TextBox nombre, TextBox idDistribuidor, TextBox dirección, TextBox ciudad, TextBox país, TextBox rfc, TextBox telefono)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Pack_Consignee WHERE id_consignee = '{dgvId}'", sql.cnn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    id.Text = dr.GetValue(dr.GetOrdinal("id_consignee")).ToString();
                    nombre.Text = dr.GetValue(dr.GetOrdinal("v_nameConsignee")).ToString();
                    idDistribuidor.Text = dr.GetValue(dr.GetOrdinal("id_distributor")).ToString();
                    dirección.Text = dr.GetValue(dr.GetOrdinal("v_address")).ToString();
                    ciudad.Text = dr.GetValue(dr.GetOrdinal("v_city")).ToString();
                    país.Text = dr.GetValue(dr.GetOrdinal("v_country")).ToString();
                    rfc.Text = dr.GetValue(dr.GetOrdinal("v_RFC")).ToString();
                    telefono.Text = dr.GetValue(dr.GetOrdinal("c_phoneNumer")).ToString();
                    activo.SelectedIndex = int.Parse(dr.GetValue(dr.GetOrdinal("c_active")).ToString());


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
    }
}