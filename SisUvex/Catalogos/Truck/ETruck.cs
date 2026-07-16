using System;
using System.Data;
using System.Windows.Forms;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Catalogos.Metods.Values;
using System.Data.SqlClient;

namespace SisUvex.Catalogos.Truck
{
    internal class ETruck
    {
        public string? idTruck { get; set; }
        public string? idTransportLine { get; set; }
        public string? ecoNumber { get; set; }
        public string? plateUS { get; set; }
        public string? plateMX { get; set; }
        public string? year { get; set; }
        public string? brand { get; set; }
        public string? vinNumber { get; set; }
        public string? color { get; set; }
        public int active { get; set; }

        public static string GetNextId()
        {
            return ClsQuerysDB.GetData("SELECT FORMAT(COALESCE(MAX([id_truck]), 0) +1, '000') FROM [Pack_Truck]").ToString();
        }

        public void GetTruck(string? idTruck)
        {
            if (idTruck == null)
                idTruck = "0";

            SQLControl sql = new SQLControl();
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Pack_Truck WHERE id_truck = @idTruck", sql.cnn);
                cmd.Parameters.AddWithValue("@idTruck", idTruck);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    this.idTruck = dr.GetValue(dr.GetOrdinal("id_truck")).ToString();
                    idTransportLine = dr.GetValue(dr.GetOrdinal("id_transportLine")).ToString();
                    ecoNumber = dr.GetValue(dr.GetOrdinal("v_ecoNumber")).ToString();
                    plateUS = dr.GetValue(dr.GetOrdinal("v_plateUS")).ToString();
                    plateMX = dr.GetValue(dr.GetOrdinal("v_plateMX")).ToString();
                    year = dr.GetValue(dr.GetOrdinal("c_year")).ToString();
                    brand = dr.GetValue(dr.GetOrdinal("v_brand")).ToString();
                    vinNumber = dr.GetValue(dr.GetOrdinal("v_vinNumber")).ToString();
                    color = dr.GetValue(dr.GetOrdinal("v_color")).ToString();
                    active = Convert.ToInt32(dr.GetValue(dr.GetOrdinal("c_active")));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo de troques");
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }

        private void ValidateTruck()
        {
            if (string.IsNullOrEmpty(idTruck) ||
                string.IsNullOrEmpty(ecoNumber) ||
                string.IsNullOrEmpty(brand) ||
                active > 1)
            {
                throw new Exception("Faltan datos obligatorios del troque.");
            }
        }

        public (bool, string?) AddProcedure()
        {
            SQLControl sql = new SQLControl();
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackTruckAdd", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@active", active);
                cmd.Parameters.AddWithValue("@idTransportLine", ClsValues.IfEmptyToDBNull(idTransportLine));
                cmd.Parameters.AddWithValue("@ecoNumber", ecoNumber);
                cmd.Parameters.AddWithValue("@plateUS", ClsValues.IfEmptyToDBNull(plateUS));
                cmd.Parameters.AddWithValue("@plateMX", ClsValues.IfEmptyToDBNull(plateMX));
                cmd.Parameters.AddWithValue("@year", ClsValues.IfEmptyToDBNull(year));
                cmd.Parameters.AddWithValue("@brand", ClsValues.IfEmptyToDBNull(brand));
                cmd.Parameters.AddWithValue("@vinNumber", ClsValues.IfEmptyToDBNull(vinNumber));
                cmd.Parameters.AddWithValue("@color", ClsValues.IfEmptyToDBNull(color));
                cmd.Parameters.AddWithValue("@user", User.GetUserName());

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string idTruck = dr.GetValue(dr.GetOrdinal("id_truck")).ToString();
                    return (true, idTruck);
                }
                return (false, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Añadir troque");
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
                SqlCommand cmd = new SqlCommand("sp_PackTrockModify", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", idTruck);
                cmd.Parameters.AddWithValue("@active", active);
                cmd.Parameters.AddWithValue("@idTransportLine", ClsValues.IfEmptyToDBNull(idTransportLine));
                cmd.Parameters.AddWithValue("@ecoNumber", ecoNumber);
                cmd.Parameters.AddWithValue("@plateUS", ClsValues.IfEmptyToDBNull(plateUS));
                cmd.Parameters.AddWithValue("@plateMX", ClsValues.IfEmptyToDBNull(plateMX));
                cmd.Parameters.AddWithValue("@year", ClsValues.IfEmptyToDBNull(year));
                cmd.Parameters.AddWithValue("@brand", ClsValues.IfEmptyToDBNull(brand));
                cmd.Parameters.AddWithValue("@vinNumber", ClsValues.IfEmptyToDBNull(vinNumber));
                cmd.Parameters.AddWithValue("@color", ClsValues.IfEmptyToDBNull(color));
                cmd.Parameters.AddWithValue("@user", User.GetUserName());

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string idTruck = dr.GetValue(dr.GetOrdinal("id_truck")).ToString();
                    return (true, idTruck);
                }
                return (false, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Modificar troque");
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
                SqlCommand cmd = new SqlCommand("sp_PackTruckActive", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@active", activeValue);
                cmd.Parameters.AddWithValue("@user", User.GetUserName());
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Activar/Desactivar troque");
                return false;
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
    }
}