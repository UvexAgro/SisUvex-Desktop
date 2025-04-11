using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisUvex.Catalogos.Metods.Querys;
using System.Data.SqlClient;
using System.Data;
using SisUvex.Catalogos.Metods.Values;

namespace SisUvex.Material.MaterialCatalog
{
    internal class EMaterialCatalog
    {
        public string idMaterialCatalog { get; set; }
        public string idDistributor { get; set; }
        public string nameMaterialCatalog { get; set; }
        public string idColor { get; set; }
        public string idCategory { get; set; }
        public int quantity { get; set; }
        public string idUnit { get; set; }
        public string idMaterialType { get; set; }
        public int active { get; set; }

        public static string GetNextId(string idMatType)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@idMaterialType", idMatType);

            return ClsQuerysDB.GetStringExecuteParameterizedQuery("SELECT CONCAT(@idMaterialType, FORMAT(COALESCE(MAX(RIGHT(id_matCatalog,4)), 0) +1, '0000')) FROM Pack_MaterialCatalog WHERE LEFT(id_matCatalog,2) = @idMaterialType", parameters);
        }

        private void ValidateMaterialCatalog()
        {
            if (string.IsNullOrEmpty(idMaterialCatalog) || string.IsNullOrEmpty(nameMaterialCatalog) || active > 1)
                throw new Exception("Faltan datos del catálogo de materiales.");
        }

        public void GetMaterialCatalog(string idMaterialCatalog)
        {
            SQLControl sql = new SQLControl();
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Pack_MaterialCatalog WHERE id_matCatalog = @idMaterialCatalog", sql.cnn);
                cmd.Parameters.AddWithValue("@idMaterialCatalog", idMaterialCatalog);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    this.idMaterialCatalog = dr.GetValue(dr.GetOrdinal("id_matCatalog")).ToString();
                    idDistributor = dr.GetValue(dr.GetOrdinal("id_distributor")).ToString();
                    nameMaterialCatalog = dr.GetValue(dr.GetOrdinal("v_nameMatCatalog")).ToString();
                    idColor = dr.GetValue(dr.GetOrdinal("id_color")).ToString();
                    idCategory = dr.GetValue(dr.GetOrdinal("id_category")).ToString();
                    quantity = Convert.ToInt32(dr.GetValue(dr.GetOrdinal("i_quantity")));
                    idUnit = dr.GetValue(dr.GetOrdinal("id_unit")).ToString();
                    idMaterialType = dr.GetValue(dr.GetOrdinal("id_materialType")).ToString();
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

        public (bool, string?) AddProcedure()
        {
            SQLControl sql = new SQLControl();
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackMaterialCatalogAdd", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idDistributor", idDistributor);
                cmd.Parameters.AddWithValue("@nameMaterialCatalog", nameMaterialCatalog);
                cmd.Parameters.AddWithValue("@idColor", ClsValues.IfEmptyToDBNull(idColor));
                cmd.Parameters.AddWithValue("@idCategory", ClsValues.IfEmptyToDBNull(idCategory));
                cmd.Parameters.AddWithValue("@quantity", ClsValues.IfEmptyToDBNull(quantity.ToString()));
                cmd.Parameters.AddWithValue("@idUnit", ClsValues.IfEmptyToDBNull(idUnit));
                cmd.Parameters.AddWithValue("@idMaterialType", ClsValues.IfEmptyToDBNull(idMaterialType));
                cmd.Parameters.AddWithValue("@active", active);
                cmd.Parameters.AddWithValue("@user", User.GetUserName());

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string idMaterialCatalog = dr.GetValue(dr.GetOrdinal("id_matCatalog")).ToString();
                    return (true, idMaterialCatalog);
                }
                return (false, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Añadir material");
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
                SqlCommand cmd = new SqlCommand("sp_PackMaterialCatalogModify", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", idMaterialCatalog);
                cmd.Parameters.AddWithValue("@idDistributor", idDistributor);
                cmd.Parameters.AddWithValue("@nameMaterialCatalog", nameMaterialCatalog);
                cmd.Parameters.AddWithValue("@idColor", ClsValues.IfEmptyToDBNull(idColor));
                cmd.Parameters.AddWithValue("@idCategory", ClsValues.IfEmptyToDBNull(idCategory));
                cmd.Parameters.AddWithValue("@quantity", ClsValues.IfEmptyToDBNull(quantity.ToString()));
                cmd.Parameters.AddWithValue("@idUnit", ClsValues.IfEmptyToDBNull(idUnit));
                cmd.Parameters.AddWithValue("@idMaterialType", ClsValues.IfEmptyToDBNull(idMaterialType));
                cmd.Parameters.AddWithValue("@active", active);
                cmd.Parameters.AddWithValue("@user", User.GetUserName());
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string idMaterialCatalog = dr.GetValue(dr.GetOrdinal("id_matCatalog")).ToString();
                    return (true, idMaterialCatalog);
                }
                return (false, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Modificar material");
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
                SqlCommand cmd = new SqlCommand("sp_PackMaterialCatalogActive", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@active", active);
                cmd.Parameters.AddWithValue("@user", User.GetUserName());
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Activar material");
                return false;
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
    }
}
