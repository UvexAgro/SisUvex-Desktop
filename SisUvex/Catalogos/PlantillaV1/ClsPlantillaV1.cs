using SisUvex.Usuarios;
using System.ComponentModel;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SisUvex.Catalogos.PlantillaV1
{
    internal class ClsPlantillaV1 : ClsCatalogos
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
        public void AñadirPlantillaV1(string activo, string id)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackDriverAdd", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@active", activo);
                cmd.Parameters.AddWithValue("@idTransportLine", id);
                cmd.Parameters.AddWithValue("@nameDriver", id);
                cmd.Parameters.AddWithValue("@lastNameDriver", id);
                cmd.Parameters.AddWithValue("@license", id);
                cmd.Parameters.AddWithValue("@birthday", id);
                cmd.Parameters.AddWithValue("@visa", id);
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

        public void ModificarPlantillaV1(string id, string activo)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackDriverModify", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@active", activo);
                cmd.Parameters.AddWithValue("@idTransportLine", id);
                cmd.Parameters.AddWithValue("@nameDriver", id);
                cmd.Parameters.AddWithValue("@lastNameDriver", id);
                cmd.Parameters.AddWithValue("@license", id);
                cmd.Parameters.AddWithValue("@birthday", id);
                cmd.Parameters.AddWithValue("@visa", id);
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

        public void RecuperarPlantillaV1(string id)
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

        public void EliminarPlantillaV1(string id)
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

        public string SiguientePlantillaV1()
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("SELECT FORMAT(MAX(id_driver)+1,'000') as 'Id' FROM Pack_Driver", sql.cnn);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return dr["Id"].ToString();
                }
                return "001";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo Id siguiente");
                return "000";
            }
            finally
            {
                sql.CloseConectionRead();
            }

        }

        public void LlenarFormulario(string dgvId, TextBox id, TextBox idLinea)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Pack_Driver WHERE id_driver = '{dgvId}'", sql.cnn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    //activo.Text = dr.GetValue(dr.GetOrdinal("c_active")).ToString();
                    id.Text = dr.GetValue(dr.GetOrdinal("id_driver")).ToString(); //cambiar a que se seleccione el index del activo
                    idLinea.Text = dr.GetValue(dr.GetOrdinal("id_transportLine")).ToString();
                    //object valorColumna1 = reader.GetValue(reader.GetOrdinal("v_nameDriver"));
                    //object valorColumna2 = reader.GetValue(reader.GetOrdinal("v_lastNameDriver"));
                    //object valorColumna3 = reader.GetValue(reader.GetOrdinal("v_license"));
                    //object valorColumna3 = reader.GetValue(reader.GetOrdinal("d_birthday"));
                    //object valorColumna3 = reader.GetValue(reader.GetOrdinal("v_visa"));
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