using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Usuarios;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace SisUvex.Catalogos.Caja
{
    internal class ClsCaja : ClsCatalogos
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
                SqlDataAdapter da = new SqlDataAdapter($"SELECT * FROM vw_PackFreightContainerCat WHERE Activo != '{activo}'", sql.cnn);
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
        public void AñadirCaja(string activo, string idLinea, string numEco, string placasUS, string placasMX, string modelo, string marca, string tipo, string tamaño)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackFreightContainerAdd", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@active", activo);
                cmd.Parameters.AddWithValue("@idTransportLine", idLinea);
                cmd.Parameters.AddWithValue("@ecoNumber", numEco);
                cmd.Parameters.AddWithValue("@plateUS", ValorNull(placasUS));
                cmd.Parameters.AddWithValue("@plateMX", ValorNull(placasMX));
                cmd.Parameters.AddWithValue("@year", ValorNull(modelo));
                cmd.Parameters.AddWithValue("@brand", ValorNull(marca));
                cmd.Parameters.AddWithValue("@typeContainer", ValorNull(tipo));
                cmd.Parameters.AddWithValue("@size", ValorNull(tamaño));
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

        public void ModificarCaja(string id, string activo, string idLinea, string numEco, string placasUS, string placasMX, string modelo, string marca, string tipo, string tamaño)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackFreightContainerModify", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@active", activo);
                cmd.Parameters.AddWithValue("@idTransportLine", idLinea);
                cmd.Parameters.AddWithValue("@ecoNumber", numEco);
                cmd.Parameters.AddWithValue("@plateUS", ValorNull(placasUS));
                cmd.Parameters.AddWithValue("@plateMX", ValorNull(placasMX));
                cmd.Parameters.AddWithValue("@year", ValorNull(modelo));
                cmd.Parameters.AddWithValue("@brand", ValorNull(marca));
                cmd.Parameters.AddWithValue("@typeContainer", ValorNull(tipo));
                cmd.Parameters.AddWithValue("@size", ValorNull(tamaño));
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

        public void RecuperarCaja(string id)
        {

            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackFreightContainerRecover", sql.cnn);
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

        public void EliminarCaja(string id)
        {

            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackFreightContainerDelete", sql.cnn);
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

        public string SiguienteCaja()
        {
            return ClsQuerysDB.GetData("SELECT FORMAT(COALESCE(MAX(id_freightContainer), 0) + 1, '000') FROM Pack_FreightContainer");
        }

        public void LlenarFormulario(string dgvId, TextBox id, ComboBox activo, TextBox idLinea, TextBox numEco, TextBox placasUS, TextBox placasMX, TextBox modelo, TextBox marca, ComboBox tipo, TextBox tamaño)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Pack_FreightContainer WHERE id_freightContainer = '{dgvId}'", sql.cnn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    activo.SelectedIndex = int.Parse(dr.GetValue(dr.GetOrdinal("c_active")).ToString());
                    id.Text         = dr.GetValue(dr.GetOrdinal("id_freightContainer")).ToString(); //cambiar a que se seleccione el index del activo
                    idLinea.Text    = dr.GetValue(dr.GetOrdinal("id_transportLine")).ToString();
                    numEco.Text     = dr.GetValue(dr.GetOrdinal("v_ecoNumber")).ToString();
                    placasUS.Text   = dr.GetValue(dr.GetOrdinal("v_plateUS")).ToString();
                    placasMX.Text   = dr.GetValue(dr.GetOrdinal("v_plateMX")).ToString();
                    modelo.Text     = dr.GetValue(dr.GetOrdinal("c_year")).ToString();
                    marca.Text      = dr.GetValue(dr.GetOrdinal("v_brand")).ToString();
                    tipo.Text       = dr.GetValue(dr.GetOrdinal("v_typeContainer")).ToString();
                    tamaño.Text     = dr.GetValue(dr.GetOrdinal("i_size")).ToString();
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