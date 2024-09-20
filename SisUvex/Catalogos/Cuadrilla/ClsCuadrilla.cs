using SisUvex.Catalogos.Metods.Values;
using SisUvex.Usuarios;
using System.Data;
using System.Data.SqlClient;

namespace SisUvex.Catalogos.Cuadrilla
{
    internal class ClsCuadrilla : ClsCatalogos
    {
        SQLControl sql = new SQLControl();

        public DataTable CatalogoActivos()
        {
            DataTable dt = new DataTable();
            try
            {
                sql.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM vw_PackWorkGroupCat", sql.cnn);
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
        public void AñadirCuadrilla(string id, string idContractor, string name)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackWorkGroupAdd", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@idContractor", idContractor);
                cmd.Parameters.AddWithValue("@name", ClsValues.IfEmptyToDBNull(name));
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

        public void ModificarCuadrilla(string id, string idContractor, string name)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackWorkGroupModify", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@idContractor", idContractor);
                cmd.Parameters.AddWithValue("@name", ClsValues.IfEmptyToDBNull(name));
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

        public void RecuperarCuadrilla(string id)
        {

            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackSizeRecover", sql.cnn);
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

        public string SiguienteCuadrilla()
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("SELECT COALESCE( (SELECT TOP 1 RIGHT('0' + CAST(CAST(id_workGroup AS int) + 1 AS varchar(2)), 2) AS ID_Disponible FROM Pack_WorkGroup WHERE NOT EXISTS ( SELECT * FROM Pack_WorkGroup AS T2 WHERE CAST(T2.id_workGroup AS int) = CAST(Pack_WorkGroup.id_workGroup AS int) + 1 ) ORDER BY id_workGroup ASC), '01' ) AS Id;", sql.cnn);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return dr["Id"].ToString();
                }
                return "01";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo Id siguiente");
                return "00";
            }
            finally
            {
                sql.CloseConectionRead();
            }

        }

        public bool IdDisponible(string id)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(id_workGroup) 'Id' FROM Pack_WorkGroup WHERE id_workGroup = @id", sql.cnn);
                cmd.Parameters.AddWithValue("@id", int.Parse(id).ToString("00"));
                int count = (int)cmd.ExecuteScalar();
                if (count > 0)
                {
                    MessageBox.Show("El valor existe en la columna ID de la tabla.");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo Id siguiente");
                return false;
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
    }
}
