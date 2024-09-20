using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Usuarios;
using System.Data;
using System.Data.SqlClient;

namespace SisUvex.Catalogos.Variedad
{
    internal class ClsVariedad : ClsCatalogos
    {
        SQLControl sql = new SQLControl();
        private DataTable CatalogoActivos()
        {
            DataTable dt = new DataTable();
            try
            {
                sql.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter($"SELECT * FROM vw_PackVarietyCat WHERE Activo = '1'", sql.cnn);
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

        private DataTable CatalogoConInactivos()
        {
            DataTable dt = new DataTable();

            try
            {
                sql.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM vw_PackVarietyCat", sql.cnn);
                da.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo eliminados");
                return dt;
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }

        public void EliminarVariedad(string id)
        {

            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackVarietyDelete", sql.cnn);
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

        public void AñadirVariedad(string activo, string nomCien, string nomCom, string idColor, string idCultivo, string nomCorto)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackVarietyAdd", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@active", activo);
                cmd.Parameters.AddWithValue("@nameScientis", ValorNull(nomCien));
                cmd.Parameters.AddWithValue("@nameComercial", nomCom);
                cmd.Parameters.AddWithValue("@idColor", idColor);
                cmd.Parameters.AddWithValue("@idCrop", idCultivo);
                cmd.Parameters.AddWithValue("@shortName", nomCorto);
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

        public void ModificarVariedad(string id, string activo, string nomCien, string nomCom, string idColor, string idCultivo, string nomCorto)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackVarietyModify", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@Active", activo);
                cmd.Parameters.AddWithValue("@nameScientis", ValorNull(nomCien));
                cmd.Parameters.AddWithValue("@nameComercial", nomCom);
                cmd.Parameters.AddWithValue("@idColor", idColor);
                cmd.Parameters.AddWithValue("@idCrop", idCultivo);
                cmd.Parameters.AddWithValue("@shortName", nomCorto);
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

        public void RecuperarVariedad(string id)
        {

            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackVarietyRecover", sql.cnn);
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

        public DataTable CatalogoActualizar(bool Status)
        {
            DataTable dt = new DataTable();

            if (Status)
                dt = CatalogoActivos();
            else
                dt = CatalogoConInactivos();

            return dt;
        }

        public string SiguienteVariedad()
        {
            return ClsQuerysDB.GetData("SELECT FORMAT(COALESCE(MAX(id_variety), 0) + 1, '00') FROM Pack_Variety");
        }

        public void LlenarFormulario(string dgvId, ref TextBox id, ref ComboBox activo, ref TextBox nomCientifico, ref TextBox nomComercial, ref TextBox idColor, ref TextBox idCultivo, ref TextBox nomCorto)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Pack_Variety WHERE id_variety = '{dgvId}'", sql.cnn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    id.Text = dr.GetValue(dr.GetOrdinal("id_variety")).ToString();
                    activo.SelectedIndex = int.Parse(dr.GetValue(dr.GetOrdinal("c_active")).ToString());
                    nomCientifico.Text = dr.GetValue(dr.GetOrdinal("v_nameScientis")).ToString();
                    nomComercial.Text = dr.GetValue(dr.GetOrdinal("v_nameComercial")).ToString();
                    idColor.Text = dr.GetValue(dr.GetOrdinal("id_color")).ToString();
                    idCultivo.Text = dr.GetValue(dr.GetOrdinal("id_crop")).ToString();
                    nomCorto.Text = dr.GetValue(dr.GetOrdinal("v_shortName")).ToString();
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
