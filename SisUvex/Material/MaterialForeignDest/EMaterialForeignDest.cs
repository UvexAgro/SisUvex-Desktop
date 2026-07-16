using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Catalogos.Metods.Values;

namespace SisUvex.Material.MaterialForeignDest
{
    internal class EMaterialForeignDest
    {
        public string idForeignDest { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postalCode { get; set; }

        public static string GetNextId()
        {
            return ClsQuerysDB.GetData("SELECT FORMAT(COALESCE(MAX(CAST([id_foreignDest] AS INT)), 0) +1, '0000') FROM [Pack_ForeignDest]").ToString();
        }

        public void GetForeignDest(string? idForeignDest)
        {
            if (string.IsNullOrEmpty(idForeignDest))
                idForeignDest = "0";

            SQLControl sql = new SQLControl();
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Pack_ForeignDest WHERE id_foreignDest = @idForeignDest", sql.cnn);
                cmd.Parameters.AddWithValue("@idForeignDest", idForeignDest);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    this.idForeignDest = dr.GetValue(dr.GetOrdinal("id_foreignDest")).ToString();
                    address = dr.GetValue(dr.GetOrdinal("v_address")).ToString();
                    city = dr.GetValue(dr.GetOrdinal("v_city")).ToString();
                    state = dr.GetValue(dr.GetOrdinal("v_state")).ToString();
                    postalCode = dr.GetValue(dr.GetOrdinal("c_codigoPost")).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo de destinos externo");
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
                SqlCommand cmd = new SqlCommand("sp_PackForeignDestAdd", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@city", ClsValues.IfEmptyToDBNull(city));
                cmd.Parameters.AddWithValue("@state", ClsValues.IfEmptyToDBNull(state));
                cmd.Parameters.AddWithValue("@postalCode", ClsValues.IfEmptyToDBNull(postalCode));
                cmd.Parameters.AddWithValue("@user", User.GetUserName());

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string idForeignDest = dr.GetValue(dr.GetOrdinal("id_foreignDest")).ToString();
                    return (true, idForeignDest);
                }
                return (false, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Añadir destino externo");
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
                SqlCommand cmd = new SqlCommand("sp_PackForeignDestModify", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", idForeignDest);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@city", ClsValues.IfEmptyToDBNull(city));
                cmd.Parameters.AddWithValue("@state", ClsValues.IfEmptyToDBNull(state));
                cmd.Parameters.AddWithValue("@postalCode", ClsValues.IfEmptyToDBNull(postalCode));
                cmd.Parameters.AddWithValue("@user", User.GetUserName());
                cmd.ExecuteNonQuery();
                return (true, idForeignDest);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Modificar destino externo");
                return (false, null);
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
    }
}
