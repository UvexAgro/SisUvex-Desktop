using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Catalogos.Metods.Values;
using System.Data.SqlClient;
using System.Data;

namespace SisUvex.Catalogos.Driver
{
    internal class EDriver
    {
        public string? idDriver { get; set; }
        public string? idTransportLine { get; set; }
        public string? nameDriver { get; set; }
        public string? lastNameDriver { get; set; }
        public string? license { get; set; }
        public DateTime? birthday { get; set; }
        public string? visa { get; set; }
        public int active { get; set; }

        public static string GetNextId()
        {
            return ClsQuerysDB.GetData("SELECT FORMAT(COALESCE(MAX([id_driver]), 0) +1, '000') FROM [Pack_Driver]").ToString();
        }

        public void GetDriver(string? idDriver)
        {
            if (idDriver == null)
                idDriver = "0";

            SQLControl sql = new SQLControl();
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Pack_Driver WHERE id_driver = @idDriver", sql.cnn);
                cmd.Parameters.AddWithValue("@idDriver", idDriver);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    this.idDriver = dr.GetValue(dr.GetOrdinal("id_driver")).ToString();
                    idTransportLine = dr.GetValue(dr.GetOrdinal("id_transportLine")).ToString();
                    nameDriver = dr.GetValue(dr.GetOrdinal("v_nameDriver")).ToString();
                    lastNameDriver = dr.GetValue(dr.GetOrdinal("v_lastNameDriver")).ToString();
                    license = dr.GetValue(dr.GetOrdinal("v_license")).ToString();

                    if (!dr.IsDBNull(dr.GetOrdinal("d_birthday")))
                    {
                        birthday = dr.GetDateTime(dr.GetOrdinal("d_birthday"));
                    }

                    visa = dr.GetValue(dr.GetOrdinal("v_visa")).ToString();
                    active = Convert.ToInt32(dr.GetValue(dr.GetOrdinal("c_active")));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo de choferes");
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }

        private void ValidateDriver()
        {
            if (string.IsNullOrEmpty(idDriver) ||
                string.IsNullOrEmpty(nameDriver) ||
                string.IsNullOrEmpty(lastNameDriver) ||
                active > 1)
            {
                throw new Exception("Faltan datos del chofer.");
            }
        }

        public (bool, string?) AddProcedure()
        {
            SQLControl sql = new SQLControl();
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackDriverAdd", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@active", active);
                cmd.Parameters.AddWithValue("@idTransportLine", idTransportLine);
                cmd.Parameters.AddWithValue("@nameDriver", nameDriver);
                cmd.Parameters.AddWithValue("@lastNameDriver", lastNameDriver);
                cmd.Parameters.AddWithValue("@license", ClsValues.IfEmptyToDBNull(license));
                cmd.Parameters.AddWithValue("@birthday", birthday.HasValue ? (object)birthday.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@visa", ClsValues.IfEmptyToDBNull(visa));
                cmd.Parameters.AddWithValue("@user", User.GetUserName());

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string? idDriver = dr.GetValue(dr.GetOrdinal("id_driver")).ToString();
                    return (true, idDriver);
                }
                return (false, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Añadir chofer");
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
                SqlCommand cmd = new SqlCommand("sp_PackDriverModify", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", idDriver);
                cmd.Parameters.AddWithValue("@active", active);
                cmd.Parameters.AddWithValue("@idTransportLine", idTransportLine);
                cmd.Parameters.AddWithValue("@nameDriver", nameDriver);
                cmd.Parameters.AddWithValue("@lastNameDriver", lastNameDriver);
                cmd.Parameters.AddWithValue("@license", ClsValues.IfEmptyToDBNull(license));
                cmd.Parameters.AddWithValue("@birthday", birthday.HasValue ? (object)birthday.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@visa", ClsValues.IfEmptyToDBNull(visa));
                cmd.Parameters.AddWithValue("@user", User.GetUserName());

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string? idDriver = dr.GetValue(dr.GetOrdinal("id_driver")).ToString();
                    return (true, idDriver);
                }
                return (false, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Modificar chofer");
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
                SqlCommand cmd = new SqlCommand("sp_PackDriverActive", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@active", active);
                cmd.Parameters.AddWithValue("@user", User.GetUserName());
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Activar/Desactivar chofer");
                return false;
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
    }
}
