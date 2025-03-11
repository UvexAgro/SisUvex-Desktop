using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Usuarios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Catalogos.Ciudad
{
    internal class ClsCiudad : ClsCatalogos
    {
        SQLControl sql = new SQLControl();

        private DataTable CatalogoActivos()
        {
            DataTable dt = new DataTable();
            try
            {
                sql.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter("SELECT c_active 'Activo', id_city 'Código', v_nameCity 'Ciudad', v_state 'Estado',v_country 'País' FROM Pack_City WHERE c_active = '1'", sql.cnn);
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
                SqlDataAdapter da = new SqlDataAdapter("SELECT c_active 'Activo', id_city 'Código', v_nameCity 'Ciudad', v_state 'Estado',v_country 'País' FROM Pack_City ORDER BY id_city", sql.cnn);
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
        public void EliminarCiudad(string id)
        {

            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackCityDelete", sql.cnn);
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

        public void AñadirCiudad(string ciudad,string estado, string pais, string activo)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackCityAdd", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nameCity", ciudad);
                cmd.Parameters.AddWithValue("@state", ValorNull(estado));
                cmd.Parameters.AddWithValue("@country", ValorNull(pais));
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

        public void ModificarCiudad(string id, string activo,string ciudad, string estado, string pais)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackCityModify", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@nameCity", ciudad);
                cmd.Parameters.AddWithValue("@state", ValorNull(estado));
                cmd.Parameters.AddWithValue("@country", ValorNull(pais));
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

        public void RecuperarCiudad(string id)
        {

            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackCityRecover", sql.cnn);
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

        public string SiguienteCiudad()
        {
            return ClsQuerysDB.GetData("SELECT FORMAT(COALESCE(MAX(id_city), 0) + 1, '000') FROM Pack_City");
        }
    }
}
