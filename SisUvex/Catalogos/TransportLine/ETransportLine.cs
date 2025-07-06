using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Catalogos.Metods.Values;
using System.Data.SqlClient;
using System.Data;
using System.Media;


namespace SisUvex.Catalogos.TransportLine
{
    internal class ETransportLine
    {
        public string idTransportLine { get; set; }
        public string nameTransportLine { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string RFC { get; set; }
        public string phoneNumber { get; set; }
        public string SCAC { get; set; }
        public string SCAAT { get; set; }
        public int active { get; set; }

        public static string GetNextId()
        {
            return ClsQuerysDB.GetData("SELECT FORMAT(COALESCE(MAX([id_transportLine]), 0) +1, '000') FROM [Pack_TransportLine]").ToString();
        }

        public void GetTransportLine(string? idTransportLine)
        {
            if (string.IsNullOrEmpty(idTransportLine))
                idTransportLine = "0";

            SQLControl sql = new SQLControl();
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Pack_TransportLine WHERE id_transportLine = @idTransportLine", sql.cnn);
                cmd.Parameters.AddWithValue("@idTransportLine", idTransportLine);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    this.idTransportLine = dr.GetValue(dr.GetOrdinal("id_transportLine")).ToString();
                    nameTransportLine = dr.GetValue(dr.GetOrdinal("v_nameTransportLine")).ToString();
                    address = dr.GetValue(dr.GetOrdinal("v_address")).ToString();
                    city = dr.GetValue(dr.GetOrdinal("v_city")).ToString();
                    RFC = dr.GetValue(dr.GetOrdinal("v_RFC")).ToString();
                    phoneNumber = dr.GetValue(dr.GetOrdinal("c_phoneNumber")).ToString();
                    SCAC = dr.GetValue(dr.GetOrdinal("c_SCAC")).ToString();
                    SCAAT = dr.GetValue(dr.GetOrdinal("c_SCAAT")).ToString();
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
                SqlCommand cmd = new SqlCommand("sp_PackTransportLineAdd", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nameTransportLine", nameTransportLine);
                cmd.Parameters.AddWithValue("@address", ClsValues.IfEmptyToDBNull(address));
                cmd.Parameters.AddWithValue("@city", ClsValues.IfEmptyToDBNull(city));
                cmd.Parameters.AddWithValue("@RFC", ClsValues.IfEmptyToDBNull(RFC));
                cmd.Parameters.AddWithValue("@phoneNumber", ClsValues.IfEmptyToDBNull(phoneNumber));
                cmd.Parameters.AddWithValue("@SCAC", ClsValues.IfEmptyToDBNull(SCAC));
                cmd.Parameters.AddWithValue("@CAAT", ClsValues.IfEmptyToDBNull(SCAAT));
                cmd.Parameters.AddWithValue("@active", active);
                cmd.Parameters.AddWithValue("@user", User.GetUserName());

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string idTransportLine = dr.GetValue(dr.GetOrdinal("id_transportLine")).ToString();
                    return (true, idTransportLine);
                }
                return (false, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Añadir línea de transporte");
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
                SqlCommand cmd = new SqlCommand("sp_PackTransportLineModify", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", idTransportLine);
                cmd.Parameters.AddWithValue("@active", active);
                cmd.Parameters.AddWithValue("@nameTransportLine", nameTransportLine);
                cmd.Parameters.AddWithValue("@address", ClsValues.IfEmptyToDBNull(address));
                cmd.Parameters.AddWithValue("@city", ClsValues.IfEmptyToDBNull(city));
                cmd.Parameters.AddWithValue("@RFC", ClsValues.IfEmptyToDBNull(RFC));
                cmd.Parameters.AddWithValue("@phoneNumber", ClsValues.IfEmptyToDBNull(phoneNumber));
                cmd.Parameters.AddWithValue("@SCAC", ClsValues.IfEmptyToDBNull(SCAC));
                cmd.Parameters.AddWithValue("@SCAAT", ClsValues.IfEmptyToDBNull(SCAAT));
                cmd.Parameters.AddWithValue("@user", User.GetUserName());
                cmd.ExecuteNonQuery();
                return (true, idTransportLine);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Modificar línea de transporte");
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
                SqlCommand cmd = new SqlCommand("sp_PackTransportLineActive", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@active", active);
                cmd.Parameters.AddWithValue("@user", User.GetUserName());
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Activos línea de transporte");
                return false;
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
    }
}
