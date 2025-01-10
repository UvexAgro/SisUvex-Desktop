using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Usuarios;
using System.Data;
using System.Data.SqlClient;

namespace SisUvex.Catalogos.LineaTransporte
{
    internal class ClsLineaTransporte : ClsCatalogos
    {
        SQLControl sql = new SQLControl();

        private DataTable CatalogoActivos()
        {
            DataTable dt = new DataTable();
            try
            {
                sql.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM vw_PackTransportLineCat WHERE Activo = '1' ORDER BY Código", sql.cnn);
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
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM vw_PackTransportLineCat ORDER BY Código", sql.cnn);
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
        public void EliminarLineaTransporte(string id)
        {

            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackTransportLineDelete", sql.cnn);
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

        public void AñadirLineaTransporte(string nombre, string activo, string direccion, string ciudad, string rfc, string telefono, string scac, string scaat)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackTransportLineAdd", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nameTransportLine", nombre);
                cmd.Parameters.AddWithValue("@address", ValorNull(direccion));
                cmd.Parameters.AddWithValue("@city ", ValorNull(ciudad));
                cmd.Parameters.AddWithValue("@RFC", ValorNull(rfc));
                cmd.Parameters.AddWithValue("@phoneNumber", ValorNull(telefono));
                cmd.Parameters.AddWithValue("@SCAC", ValorNull(scac));
                cmd.Parameters.AddWithValue("@SCAAT", ValorNull(scaat));
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

        public void ModificarLineaTransporte(string id, string activo, string nombre, string direccion, string ciudad, string rfc, string telefono, string scac, string scaat)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackTransportLineModify", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@active", activo);
                cmd.Parameters.AddWithValue("@nameTransportLine", nombre);
                cmd.Parameters.AddWithValue("@address", ValorNull(direccion));
                cmd.Parameters.AddWithValue("@city ", ValorNull(ciudad));
                cmd.Parameters.AddWithValue("@RFC", ValorNull(rfc));
                cmd.Parameters.AddWithValue("@phoneNumber", ValorNull(telefono));
                cmd.Parameters.AddWithValue("@SCAC", ValorNull(scac));
                cmd.Parameters.AddWithValue("@SCAAT", ValorNull(scaat));
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

        public void RecuperarLineaTransporte(string id)
        {

            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackTransportLineRecover", sql.cnn);
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

        public string SiguienteLineaTransporte()
        {
            return ClsQuerysDB.GetData("SELECT FORMAT(COALESCE(MAX(id_transportLine), 0) + 1, '000') FROM Pack_TransportLine");
        }
    }
}
