using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Usuarios;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace SisUvex.Catalogos.Troque
{
    internal class ClsTroque : ClsCatalogos
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
                SqlDataAdapter da = new SqlDataAdapter($"SELECT * FROM vw_PackTruckCat WHERE Activo != '{activo}'", sql.cnn);
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
        public void AñadirTroque(string activo, string idLinea, string numEco, string placasUS, string placasMX, string modelo, string marca, string VIN, string color)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackTruckAdd", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@active", activo);
                cmd.Parameters.AddWithValue("@idTransportLine", idLinea);
                cmd.Parameters.AddWithValue("@ecoNumber", numEco);
                cmd.Parameters.AddWithValue("@plateUS", ValorNull(placasUS));
                cmd.Parameters.AddWithValue("@plateMX", ValorNull(placasMX));
                cmd.Parameters.AddWithValue("@year", ValorNull(modelo));
                cmd.Parameters.AddWithValue("@brand", ValorNull(marca));
                cmd.Parameters.AddWithValue("@vinNumber", ValorNull(VIN));
                cmd.Parameters.AddWithValue("@color", ValorNull(color));
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

        public void ModificarTroque(string id, string activo, string idLinea, string numEco, string placasUS, string placasMX, string modelo, string marca, string VIN, string color)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackTruckModify", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@active", activo);
                cmd.Parameters.AddWithValue("@idTransportLine", idLinea);
                cmd.Parameters.AddWithValue("@ecoNumber", numEco);
                cmd.Parameters.AddWithValue("@plateUS", ValorNull(placasUS));
                cmd.Parameters.AddWithValue("@plateMX", ValorNull(placasMX));
                cmd.Parameters.AddWithValue("@year", ValorNull(modelo));
                cmd.Parameters.AddWithValue("@brand", ValorNull(marca));
                cmd.Parameters.AddWithValue("@vinNumber", ValorNull(VIN));
                cmd.Parameters.AddWithValue("@color", ValorNull(color));
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

        public void RecuperarTroque(string id)
        {

            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackTruckRecover", sql.cnn);
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

        public void EliminarTroque(string id)
        {

            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackTruckDelete", sql.cnn);
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

        public string SiguienteTroque()
        {
            return ClsQuerysDB.GetData("SELECT FORMAT(COALESCE(MAX(id_truck), 0) + 1, '000') FROM Pack_Truck");
        }

        public void LlenarFormulario(string dgvId, TextBox id, ComboBox activo, TextBox idLinea, TextBox numEco, TextBox placasUS, TextBox placasMX, TextBox modelo, TextBox marca, TextBox VIN, TextBox color)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Pack_Truck WHERE id_truck = '{dgvId}'", sql.cnn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    activo.SelectedIndex = int.Parse(dr.GetValue(dr.GetOrdinal("c_active")).ToString());
                    id.Text = dr.GetValue(dr.GetOrdinal("id_truck")).ToString();
                    idLinea.Text = dr.GetValue(dr.GetOrdinal("id_transportLine")).ToString();
                    numEco.Text = dr.GetValue(dr.GetOrdinal("v_ecoNumber")).ToString();
                    placasUS.Text = dr.GetValue(dr.GetOrdinal("v_plateUS")).ToString();
                    placasMX.Text = dr.GetValue(dr.GetOrdinal("v_plateMX")).ToString();
                    modelo.Text = dr.GetValue(dr.GetOrdinal("c_year")).ToString();
                    marca.Text = dr.GetValue(dr.GetOrdinal("v_brand")).ToString();
                    VIN.Text = dr.GetValue(dr.GetOrdinal("v_vinNumber")).ToString();
                    color.Text = dr.GetValue(dr.GetOrdinal("v_color")).ToString();
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