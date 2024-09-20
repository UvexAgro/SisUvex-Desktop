using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Usuarios;
using System.Data;
using System.Data.SqlClient;

namespace SisUvex.Catalogos.Productor
{
    internal class ClsProductor : ClsCatalogos
    {
        SQLControl sql = new SQLControl();

        #region Vistas
        private DataTable CatalogoActivos()
        {
            DataTable dt = new DataTable();
            try
            {
                sql.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter("SELECT c_active 'Activo', id_grower 'Código', v_nameGrower 'Nombre', v_address 'Dirección', v_city 'Ciudad', v_RFC 'RFC', c_phoneNumber 'Telefono', d_create 'Fecha creación', userCreate 'Creado por', d_update 'Fecha modificado', userUpdate 'Modificado por' FROM Pack_Grower WHERE c_active = '1'", sql.cnn);
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
                SqlDataAdapter da = new SqlDataAdapter("SElECT c_active 'Activo', id_grower 'Código', v_nameGrower 'Nombre', v_address 'Dirección', v_city 'Ciudad', v_RFC 'RFC', c_phoneNumber 'Telefono', d_create 'Fecha creación', userCreate 'Creado por', d_update 'Fecha modificado', userUpdate 'Modificado por'  FROM Pack_Grower ORDER BY c_active DESC, id_grower", sql.cnn);
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
        #endregion

        #region CRUD
        public void AñadirProductor(string nombre, string activo, string direccion, string ciudad, string rfc, string telefono)
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

        public void ModificarProductor(string id, string activo, string nombre, string direccion, string ciudad, string rfc, string telefono)
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
        #endregion
        
    }
}
