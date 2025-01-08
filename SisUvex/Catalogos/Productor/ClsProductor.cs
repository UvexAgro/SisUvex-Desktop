using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Usuarios;
using System.Data;
using System.Data.SqlClient;

namespace SisUvex.Catalogos.Productor
{
    internal class ClsProductor : ClsCatalogos
    {
        SQLControl sql = new SQLControl();
        string queryActivos = " SELECT c_active 'Activo', id_grower 'Código', v_nameGrower 'Nombre',  v_shortName 'Diminutivo', v_address 'Dirección', v_city 'Ciudad', v_RFC 'RFC', c_phoneNumber 'Telefono', v_GGN 'GGN', v_logo 'Logo', v_regPat 'Registro patronal' FROM Pack_Grower ";

        private DataTable CatalogoActivos()
        {
            DataTable dt = new DataTable();
            try
            {
                string query = queryActivos + " WHERE c_active = '1' ORDER BY id_grower";

                sql.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter(query, sql.cnn);
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
                string query = queryActivos + " ORDER BY id_grower";

                sql.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter(query, sql.cnn);
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

        public DataTable CatalogoActualizar(bool Status)
        {
            DataTable dt = new DataTable();

            if (Status)
                dt = CatalogoActivos();
            else
                dt = CatalogoConInactivos();

            return dt;
        }
        public string SiguienteProductor()
        {
            return ClsQuerysDB.GetData("SELECT FORMAT(COALESCE(MAX(id_grower), 0) + 1, '00') FROM Pack_Grower");
        }
        public void AñadirProductor(string nombre, string activo, string direccion, string ciudad, string rfc, string telefono, string ggn, string logo, string shortName, string regPat)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackGrowerAdd", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nameGrower", nombre);
                cmd.Parameters.AddWithValue("@active", activo);
                cmd.Parameters.AddWithValue("@address", ValorNull(direccion));
                cmd.Parameters.AddWithValue("@city", ValorNull(ciudad));
                cmd.Parameters.AddWithValue("@RFC", ValorNull(rfc));
                cmd.Parameters.AddWithValue("@phoneNumber", ValorNull(telefono));
                cmd.Parameters.AddWithValue("@ggn", ValorNull(ggn));
                cmd.Parameters.AddWithValue("@logo", ValorNull(logo));
                cmd.Parameters.AddWithValue("@shortName", shortName);
                cmd.Parameters.AddWithValue("@regPat", ValorNull(regPat));
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

        public void ModificarProductor(string id, string activo, string nombre, string direccion, string ciudad, string rfc, string telefono, string ggn, string logo, string shortName, string regPat)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackGrowerModify", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@nameGrower", nombre);
                cmd.Parameters.AddWithValue("@active", activo);
                cmd.Parameters.AddWithValue("@address", ValorNull(direccion));
                cmd.Parameters.AddWithValue("@city", ValorNull(ciudad));
                cmd.Parameters.AddWithValue("@RFC", ValorNull(rfc));
                cmd.Parameters.AddWithValue("@phoneNumber", ValorNull(telefono));
                cmd.Parameters.AddWithValue("@ggn", ValorNull(ggn));
                cmd.Parameters.AddWithValue("@logo", ValorNull(logo));
                cmd.Parameters.AddWithValue("@shortName", shortName);
                cmd.Parameters.AddWithValue("@regPat", ValorNull(regPat));
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
        public void EliminarProductor(string id)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackGrowerDelete", sql.cnn);
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

        public void RecuperarProductor(string id)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackGrowerRecover", sql.cnn);
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
    }
}
