using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Catalogos.Metods.Values;

namespace SisUvex.Catalogos.FreightContainer
{
    internal class EFreightContainer
    {
        public string? idFreightContainer { get; set; }
        public string? idTransportLine { get; set; }
        public string? ecoNumber { get; set; }
        public string? plateUS { get; set; }
        public string? plateMX { get; set; }
        public string? year { get; set; }
        public string? brand { get; set; }
        public string? typeContainer { get; set; }
        public int size { get; set; }
        public int active { get; set; }

        public static string GetNextId()
        {
            return ClsQuerysDB.GetData("SELECT FORMAT(COALESCE(MAX([id_freightContainer]), 0) +1, '000') FROM [Pack_FreightContainer]").ToString();
        }

        public void GetFreightContainer(string? idFreightContainer)
        {
            if (idFreightContainer == null)
                idFreightContainer = "0";

            SQLControl sql = new SQLControl();
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Pack_FreightContainer WHERE id_freightContainer = @idFreightContainer", sql.cnn);
                cmd.Parameters.AddWithValue("@idFreightContainer", idFreightContainer);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    this.idFreightContainer = dr.GetValue(dr.GetOrdinal("id_freightContainer")).ToString();
                    idTransportLine = dr.GetValue(dr.GetOrdinal("id_transportLine")).ToString();
                    ecoNumber = dr.GetValue(dr.GetOrdinal("v_ecoNumber")).ToString();
                    plateUS = dr.GetValue(dr.GetOrdinal("v_plateUS")).ToString();
                    plateMX = dr.GetValue(dr.GetOrdinal("v_plateMX")).ToString();
                    year = dr.GetValue(dr.GetOrdinal("c_year")).ToString();
                    brand = dr.GetValue(dr.GetOrdinal("v_brand")).ToString();
                    typeContainer = dr.GetValue(dr.GetOrdinal("v_typeContainer")).ToString();
                    size = Convert.ToInt32(dr.GetValue(dr.GetOrdinal("i_size")));
                    active = Convert.ToInt32(dr.GetValue(dr.GetOrdinal("c_active")));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo de cajas refrigeradas");
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }

        private void ValidateFreightContainer()
        {
            if (string.IsNullOrEmpty(idFreightContainer) ||
                string.IsNullOrEmpty(ecoNumber) ||
                string.IsNullOrEmpty(brand) ||
                active > 1)
            {
                throw new Exception("Faltan datos obligatorios de la caja refrigerada.");
            }
        }

        public (bool, string?) AddProcedure()
        {
            SQLControl sql = new SQLControl();
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackFreightContainerAdd", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@active", active);
                cmd.Parameters.AddWithValue("@idTransportLine", ClsValues.IfEmptyToDBNull(idTransportLine));
                cmd.Parameters.AddWithValue("@ecoNumber", ecoNumber);
                cmd.Parameters.AddWithValue("@plateUS", ClsValues.IfEmptyToDBNull(plateUS));
                cmd.Parameters.AddWithValue("@plateMX", ClsValues.IfEmptyToDBNull(plateMX));
                cmd.Parameters.AddWithValue("@year", ClsValues.IfEmptyToDBNull(year));
                cmd.Parameters.AddWithValue("@brand", brand);
                cmd.Parameters.AddWithValue("@typeContainer", ClsValues.IfEmptyToDBNull(typeContainer));
                cmd.Parameters.AddWithValue("@size", size);
                cmd.Parameters.AddWithValue("@user", User.GetUserName());

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string? idFreightContainer = dr.GetValue(dr.GetOrdinal("id_freightContainer")).ToString();
                    return (true, idFreightContainer);
                }
                return (false, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Añadir caja refrigerada");
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
                SqlCommand cmd = new SqlCommand("sp_PackFreightContainerModify", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", idFreightContainer);
                cmd.Parameters.AddWithValue("@active", active);
                cmd.Parameters.AddWithValue("@idTransportLine", ClsValues.IfEmptyToDBNull(idTransportLine));
                cmd.Parameters.AddWithValue("@ecoNumber", ecoNumber);
                cmd.Parameters.AddWithValue("@plateUS", ClsValues.IfEmptyToDBNull(plateUS));
                cmd.Parameters.AddWithValue("@plateMX", ClsValues.IfEmptyToDBNull(plateMX));
                cmd.Parameters.AddWithValue("@year", ClsValues.IfEmptyToDBNull(year));
                cmd.Parameters.AddWithValue("@brand", brand);
                cmd.Parameters.AddWithValue("@typeContainer", ClsValues.IfEmptyToDBNull(typeContainer));
                cmd.Parameters.AddWithValue("@size", size);
                cmd.Parameters.AddWithValue("@user", User.GetUserName());

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string? idFreightContainer = dr.GetValue(dr.GetOrdinal("id_freightContainer")).ToString();
                    return (true, idFreightContainer);
                }
                return (false, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Modificar caja refrigerada");
                return (false, null);
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }

        public static bool ActiveProcedure(string id, string activeValue)
        {
            SQLControl sql = new SQLControl();
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackFreightContainerActive", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@active", activeValue);
                cmd.Parameters.AddWithValue("@user", User.GetUserName());
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Activar/Desactivar caja refrigerada");
                return false;
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
    }
}