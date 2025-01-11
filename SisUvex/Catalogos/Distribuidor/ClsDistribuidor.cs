using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Usuarios;
using System.Data;
using System.Data.SqlClient;

namespace SisUvex.Catalogos.Distribuidor
{
    internal class ClsDistribuidor : ClsCatalogos 
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
        private DataTable CatalogoActivos(string activo)
        {
            DataTable dt = new DataTable();
            try
            {
                sql.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter($"SELECT * FROM vw_PackDistributorCat WHERE Activo != '{activo}'", sql.cnn);
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
        public void EliminarDistribuidor(string id)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackDistributorDelete", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@userUpdate", User.GetUserName());

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

        public void AñadirDistribuidor(string nombre, string activo, string mercado, string direccion, string ciudad, string rfc, string telefono, string idAgenciaUS, string idAgenciaMX, string idProductor, string idCiudadCruce, string idCiudadDestino, string nombreCorto, string pais)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackDistributorAdd", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nameDistributor", nombre);
                cmd.Parameters.AddWithValue("@active", activo);
                cmd.Parameters.AddWithValue("@idUSAgency", Id00Null(idAgenciaUS));
                cmd.Parameters.AddWithValue("@idMXAgency", Id00Null(idAgenciaMX));
                cmd.Parameters.AddWithValue("@idGrower", Id00Null(idProductor));
                cmd.Parameters.AddWithValue("@marketTarget", ValorNull(mercado));
                cmd.Parameters.AddWithValue("@addres", ValorNull(direccion));
                cmd.Parameters.AddWithValue("@city", ValorNull(ciudad));
                cmd.Parameters.AddWithValue("@RFC", ValorNull(rfc));
                cmd.Parameters.AddWithValue("@phoneNumber", ValorNull(telefono));
                cmd.Parameters.AddWithValue("@idCityCrossPoint", Id00Null(idCiudadCruce));
                cmd.Parameters.AddWithValue("@idCityDestiny", Id00Null(idCiudadDestino));
                cmd.Parameters.AddWithValue("@shortName", ValorNull(nombreCorto));
                cmd.Parameters.AddWithValue("@country", ValorNull(pais));
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

        public void ModificarDistribuidor(string id, string activo, string nombre, string mercado, string direccion, string ciudad, string rfc, string telefono, string idAgenciaUS, string idAgenciaMX, string idProductor, string idCiudadCruce, string idCiudadDestino, string nombreCorto, string pais)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackDistributorModify", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@nameDistributor", nombre);
                cmd.Parameters.AddWithValue("@active", activo);
                cmd.Parameters.AddWithValue("@idUSAgency", Id00Null(idAgenciaUS));
                cmd.Parameters.AddWithValue("@idMXAgency", Id00Null(idAgenciaMX));
                cmd.Parameters.AddWithValue("@idGrower", Id00Null(idProductor));
                cmd.Parameters.AddWithValue("@marketTarget", ValorNull(mercado));
                cmd.Parameters.AddWithValue("@addres", ValorNull(direccion));
                cmd.Parameters.AddWithValue("@city", ValorNull(ciudad));
                cmd.Parameters.AddWithValue("@RFC", ValorNull(rfc));
                cmd.Parameters.AddWithValue("@phoneNumber", ValorNull(telefono));
                cmd.Parameters.AddWithValue("@idCityCrossPoint", Id00Null(idCiudadCruce));
                cmd.Parameters.AddWithValue("@idCityDestiny", Id00Null(idCiudadDestino));
                cmd.Parameters.AddWithValue("@shortName", ValorNull(nombreCorto));
                cmd.Parameters.AddWithValue("@country", ValorNull(pais));
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

        public void RecuperarDistribuidor(string id)
        {

            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackDistributorRecover", sql.cnn);
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

        public string SiguienteDistribuidor()
        {
            return ClsQuerysDB.GetData("SELECT FORMAT(COALESCE(MAX(id_distributor), 0) + 1, '00') FROM Pack_Distributor");
        }
        public void CargarComboBoxes(List<ComboBox> c)
        {
            CboCargarInicio(c[0], CboAgenciaUS("", "*"));
            CboCargarInicio(c[1], CboAgenciaMX("", "*"));
            CboCargarInicio(c[2], CboProductor("","*"));
            CboCargarInicio(c[3], CboCiudad("","*"));
            CboCargarInicio(c[4], CboCiudad("","*"));
        }
        public void LlenarFormulario(string dgvId, TextBox id, ComboBox activo, ComboBox mercado, TextBox nombre, TextBox direccion, TextBox ciudad, TextBox RFC,  TextBox telefono, TextBox idAgenciaUS, TextBox idAgenciaMX, TextBox idProductor, TextBox idCiudadCruce, TextBox idCiudadDestino, TextBox nombreCorto, TextBox pais)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Pack_Distributor WHERE id_distributor = '{dgvId}'", sql.cnn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    activo.SelectedIndex = int.Parse(dr.GetValue(dr.GetOrdinal("c_active")).ToString());
                    id.Text = dr.GetValue(dr.GetOrdinal("id_distributor")).ToString();
                    mercado.Text = dr.GetValue(dr.GetOrdinal("c_marketTarget")).ToString();
                    nombre.Text = dr.GetValue(dr.GetOrdinal("v_nameDistributor")).ToString();
                    direccion.Text = dr.GetValue(dr.GetOrdinal("v_address")).ToString();
                    ciudad.Text = dr.GetValue(dr.GetOrdinal("v_city")).ToString();
                    RFC.Text = dr.GetValue(dr.GetOrdinal("v_RFC")).ToString();
                    telefono.Text = dr.GetValue(dr.GetOrdinal("c_phoneNumber")).ToString();
                    idAgenciaUS.Text = dr.GetValue(dr.GetOrdinal("id_USAgencyTrade")).ToString();
                    idAgenciaMX.Text = dr.GetValue(dr.GetOrdinal("id_MXAgencyTrade")).ToString();
                    idProductor.Text = dr.GetValue(dr.GetOrdinal("id_grower")).ToString();
                    idCiudadCruce.Text = dr.GetValue(dr.GetOrdinal("id_cityCrossPoint")).ToString();
                    idCiudadDestino.Text = dr.GetValue(dr.GetOrdinal("id_cityDestiny")).ToString();
                    nombreCorto.Text = dr.GetValue(dr.GetOrdinal("v_nameDistShort")).ToString();
                    pais.Text = dr.GetValue(dr.GetOrdinal("v_country")).ToString();
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
