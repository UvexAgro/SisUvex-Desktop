using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisUvex.Catalogos.Metods.Querys;
using System.Data.SqlClient;
using System.Data;
using SisUvex.Catalogos.Metods.Values;
using Org.BouncyCastle.Pqc.Crypto.Falcon;

namespace SisUvex.Material.MaterialType
{
    internal class EMaterialType
    {
        public string idMaterialType { get; set; }
        public string nameMaterialType { get; set; }

        public static bool ValidateMaterialType(string? idMaterialType)
        {
            if (string.IsNullOrEmpty(idMaterialType) || idMaterialType.Length != 2 || !idMaterialType.All(char.IsLetterOrDigit))
                return false;

            SQLControl sql = new SQLControl();
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Pack_MaterialType WHERE id_matType = @idMaterialType", sql.cnn);
                cmd.Parameters.AddWithValue("@idMaterialType", idMaterialType);
                int count = (int)cmd.ExecuteScalar();
                return count == 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Validar id");
                return false;
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
        public void GetMaterialType(string id)
        {
            SQLControl sql = new SQLControl();
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new($"SELECT * FROM Pack_MaterialType WHERE id_matType = @idMaterialType", sql.cnn);
                cmd.Parameters.AddWithValue("@idMaterialType", id);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    idMaterialType = dr.GetValue(dr.GetOrdinal("id_matType")).ToString().ToUpper();
                    nameMaterialType = dr.GetValue(dr.GetOrdinal("v_nameMatType")).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Tipo de material");
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }

        public (bool, string?) AddProcedure()
        {
            SQLControl sql = new SQLControl();

            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new("sp_PackMaterialTypeAdd", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idmatType", idMaterialType.ToUpper());
                cmd.Parameters.AddWithValue("@nameMatType", nameMaterialType);
                cmd.Parameters.AddWithValue("@user", User.GetUserName());

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string? id = dr.GetValue(dr.GetOrdinal("id_matType")).ToString();
                    return (true, id);
                }
                else
                {
                    return (false, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Añadir tipo de material");
                return (false, null);
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }

        public (bool, string?) ModifyProcedure()
        {
            SQLControl sql = new SQLControl();
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new("sp_PackMaterialTypeModify", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idmatType", idMaterialType.ToUpper());
                cmd.Parameters.AddWithValue("@nameMatType", nameMaterialType);
                cmd.Parameters.AddWithValue("@user", User.GetUserName());
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string? id = dr.GetValue(dr.GetOrdinal("id_matType")).ToString();
                    return (true, id);
                }
                else
                {
                    return (false, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Modificar tipo de material");
                return (false, null);
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
    }
}
