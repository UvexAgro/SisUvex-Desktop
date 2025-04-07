using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using SisUvex.Catalogos.Metods.CheckBoxes;
using SisUvex.Catalogos.Metods.Values;
using SisUvex.Catalogos.Metods.Querys;

namespace SisUvex.Material.MaterialProvider
{
    internal class EMaterialProvider
    {
        public string idProvider { get; set; }
        public string nameProvider { get; set; }
        public string city { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public int active { get; set; }

        public static string GetNextId()
        {
            return ClsQuerysDB.GetData("SELECT FORMAT(COALESCE(MAX([id_provider]), 0) +1, '00') FROM [Pack_Provider]").ToString();
        }

        public void GetProvider(string idProvider)
        {
            SQLControl sql = new SQLControl();
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Pack_Provider WHERE id_provider = @idProvider", sql.cnn);
                cmd.Parameters.AddWithValue("@idProvider", idProvider);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    this.idProvider = dr.GetValue(dr.GetOrdinal("id_provider")).ToString();
                    nameProvider = dr.GetValue(dr.GetOrdinal("v_nameProvider")).ToString();
                    city = dr.GetValue(dr.GetOrdinal("v_city")).ToString();
                    phoneNumber = dr.GetValue(dr.GetOrdinal("c_phoneNumber")).ToString();
                    email = dr.GetValue(dr.GetOrdinal("v_email")).ToString();
                    active = Convert.ToInt32(dr.GetValue(dr.GetOrdinal("c_active")));
                }
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

        private void ValidateProvider()
        {
            if (string.IsNullOrEmpty(idProvider) || string.IsNullOrEmpty(nameProvider) || active > 1)
                throw new Exception("Faltan datos de proveedor.");
        }

        public (bool, string?) AddProcedure()
        {
            //AQUÍ REGRESA EL VALOR EL ID Y EL TRUE SI SE PUDO AGREGAR EL PROVEEDOR

            SQLControl sql = new SQLControl();
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackProviderAdd", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@active", active);
                cmd.Parameters.AddWithValue("@nameProvider", nameProvider);
                cmd.Parameters.AddWithValue("@nameCity", ClsValues.IfEmptyToDBNull(city));
                cmd.Parameters.AddWithValue("@phoneNumber", ClsValues.IfEmptyToDBNull(phoneNumber));
                cmd.Parameters.AddWithValue("@email", ClsValues.IfEmptyToDBNull(email));
                cmd.Parameters.AddWithValue("@user", User.GetUserName());

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string idProvider = dr.GetValue(dr.GetOrdinal("id_provider")).ToString();
                    return (true, idProvider);
                }
                return (false, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Añadir proovedor");
                return (false, null);
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }

        public (bool, string?) ModifyProcedure()
        {
            //DAR VALORES A LOS CAMPOS ANTES DE EJECUTAR EL PROCEDIMIENTO
            SQLControl sql = new SQLControl();
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackProviderModify", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", idProvider);
                cmd.Parameters.AddWithValue("@active", active);
                cmd.Parameters.AddWithValue("@nameProvider", nameProvider);
                cmd.Parameters.AddWithValue("@nameCity", ClsValues.IfEmptyToDBNull(city));
                cmd.Parameters.AddWithValue("@phoneNumber", ClsValues.IfEmptyToDBNull(phoneNumber));
                cmd.Parameters.AddWithValue("@email", ClsValues.IfEmptyToDBNull(email));
                cmd.Parameters.AddWithValue("@user", User.GetUserName());
                cmd.ExecuteNonQuery();
                return (true, idProvider);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Modificar proovedor");
                return (false, null);
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }

        public static bool ActiveProcedure(string id, string active)
        {
            SQLControl sql = new SQLControl();
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackProviderActive", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@active", active);
                cmd.Parameters.AddWithValue("@user", User.GetUserName());
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Activos proveedor");
                return false;
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
    }
}
