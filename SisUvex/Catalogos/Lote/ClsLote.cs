using SisUvex.Usuarios;
using System.Data;
using System.Data.SqlClient;

namespace SisUvex.Catalogos.Lote
{
    internal class ClsLote : ClsCatalogos
    {
        SQLControl sql = new SQLControl();
        private DataTable CatalogoActivos()
        {
            DataTable dt = new DataTable();
            try
            {
                sql.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM vw_PackLotCat WHERE Activo = 1", sql.cnn);
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
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM vw_PackLotCat", sql.cnn);
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
        public void EliminarLote(string id)
        {

            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackLotDelete", sql.cnn);
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

        public void AñadirLote(string id, string nombre, string activo, string idVariedad, string ha, string año)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackLotAdd", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", float.Parse(id).ToString("0000"));
                cmd.Parameters.AddWithValue("@name", nombre);
                cmd.Parameters.AddWithValue("@idVariety", idVariedad);
                cmd.Parameters.AddWithValue("@ha", ha);
                cmd.Parameters.AddWithValue("@year", año);
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

        public void ModificarLote(string id, string nombre, string activo, string idVariedad, float ha, string año)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackLotModify", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", nombre);
                cmd.Parameters.AddWithValue("@idVariety", idVariedad);
                cmd.Parameters.AddWithValue("@ha", ha);
                cmd.Parameters.AddWithValue("@year", año);
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

        public void RecuperarLote(string id)
        {

            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackLotRecover", sql.cnn);
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

        public string SiguienteLote()
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("SELECT ISNULL(FORMAT(MAX(id_lot) + 1,'0000'), '0001') AS 'Id' FROM Pack_Lot ", sql.cnn);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return dr["Id"].ToString();
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo Id siguiente");
                return string.Empty;
            }
            finally
            {
                sql.CloseConectionRead();
            }
        }

        public bool ComprobarId(string idLot, string idVariety)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand($"SELECT COUNT(id_lot) 'Id' FROM Pack_Lot WHERE id_lot = '{idLot}' AND id_variety  = '{idVariety}'", sql.cnn);

                int count = (int)cmd.ExecuteScalar();

                return count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo comprobar id existente");
                return false;
            }
            finally
            {
                sql.CloseConectionRead();
            }
        }
    }
}
