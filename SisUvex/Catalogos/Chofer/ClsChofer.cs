using SisUvex.Usuarios;
using System.ComponentModel;
using System;
using System.Data;
using System.Data.SqlClient;
using SisUvex.Catalogos.Metods.Querys;

namespace SisUvex.Catalogos.Chofer
{
    internal class ClsChofer : ClsCatalogos
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
                SqlDataAdapter da = new SqlDataAdapter($"SELECT * FROM vw_PackDriverCat WHERE Activo != '{activo}'", sql.cnn);
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
        public void AñadirChofer(string activo, string idLinea, string nombre, string apellidos, string licencia, string visa, string fechaNacimiento)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackDriverAdd", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@active", activo);
                cmd.Parameters.AddWithValue("@idTransportLine", idLinea);
                cmd.Parameters.AddWithValue("@nameDriver", nombre);
                cmd.Parameters.AddWithValue("@lastNameDriver", apellidos);
                cmd.Parameters.AddWithValue("@license", ValorNull(licencia));
                cmd.Parameters.AddWithValue("@birthday", ValorNullFecha(fechaNacimiento));
                cmd.Parameters.AddWithValue("@visa", ValorNull(visa));
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

        public void ModificarChofer(string id, string activo, string idLinea, string nombre, string apellidos, string licencia, string visa, string fechaNacimiento)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackDriverModify", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@active", activo);
                cmd.Parameters.AddWithValue("@idTransportLine", idLinea);
                cmd.Parameters.AddWithValue("@nameDriver", nombre);
                cmd.Parameters.AddWithValue("@lastNameDriver", apellidos);
                cmd.Parameters.AddWithValue("@license", ValorNull(licencia));
                cmd.Parameters.AddWithValue("@birthday", ValorNullFecha(fechaNacimiento));
                cmd.Parameters.AddWithValue("@visa", ValorNull(visa));
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

        public void RecuperarChofer(string id)
        {

            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackDriverRecover", sql.cnn);
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

        public void EliminarChofer(string id)
        {

            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackDriverDelete", sql.cnn);
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

        public string SiguienteChofer()
        {
            return ClsQuerysDB.GetData("SELECT FORMAT(COALESCE(MAX(id_driver), 0) + 1, '000') FROM Pack_Driver");
        }

        public void LlenarFormulario(string dgvId,TextBox id, ComboBox activo, TextBox idLinea, TextBox nombre,TextBox apellidos, TextBox licencia, TextBox visa, MaskedTextBox fechaNacimiento)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Pack_Driver WHERE id_driver = '{dgvId}'", sql.cnn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    activo.SelectedIndex = int.Parse(dr.GetValue(dr.GetOrdinal("c_active")).ToString());
                    id.Text = dr.GetValue(dr.GetOrdinal("id_driver")).ToString(); //cambiar a que se seleccione el index del activo
                    idLinea.Text = dr.GetValue(dr.GetOrdinal("id_transportLine")).ToString();
                    nombre.Text = dr.GetValue(dr.GetOrdinal("v_nameDriver")).ToString();
                    apellidos.Text = dr.GetValue(dr.GetOrdinal("v_lastNameDriver")).ToString();
                    licencia.Text = dr.GetValue(dr.GetOrdinal("v_license")).ToString();
                    visa.Text = dr.GetValue(dr.GetOrdinal("v_visa")).ToString();
                    fechaNacimiento.Text = dr.GetValue(dr.GetOrdinal("d_birthday")).ToString();
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