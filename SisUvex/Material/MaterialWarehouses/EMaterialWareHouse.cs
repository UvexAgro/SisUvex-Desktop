using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SisUvex.Catalogos.Metods.Querys;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using SisUvex.Catalogos.Metods.Values;

namespace SisUvex.Material.MaterialWarehouses
{
    internal class EMaterialWareHouse
    {
        public string idWareHouse { get; set; }
        public string nameWareHouse { get; set; }
        public int active { get; set; }
        public string idEmployee { get; set; }

        public static string GetNextId()
        {
            return ClsQuerysDB.GetData("SELECT FORMAT(COALESCE(MAX([id_warehouses]), 0) +1, '0000') FROM [Pack_Warehouses]").ToString();
        }
        public void GetWareHouse(string idWareHouse)
        {
            SQLControl sql = new SQLControl();
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Pack_Warehouses WHERE id_warehouses = @idWareHouse", sql.cnn);
                cmd.Parameters.AddWithValue("@idWareHouse", idWareHouse);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    this.idWareHouse = dr.GetValue(dr.GetOrdinal("id_warehouses")).ToString();
                    nameWareHouse = dr.GetValue(dr.GetOrdinal("v_namewarehouses")).ToString();
                    idEmployee = dr.GetValue(dr.GetOrdinal("id_employee")).ToString();
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

        private void ValidateWareHouse()
        {
            if (string.IsNullOrEmpty(idWareHouse) || string.IsNullOrEmpty(nameWareHouse) || active > 1)
                throw new Exception("Faltan datos de almacén.");
        }

        public (bool, string?) AddProcedure()
        {
            SQLControl sql = new SQLControl();
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackWareHousesAdd", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nameWareHouse", nameWareHouse);
                cmd.Parameters.AddWithValue("@idEmployee", ClsValues.IfEmptyToDBNull(idEmployee));
                cmd.Parameters.AddWithValue("@active", active);
                cmd.Parameters.AddWithValue("@user", User.GetUserName());

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string idWareHouse = dr.GetValue(dr.GetOrdinal("id_warehouses")).ToString();
                    return (true, idWareHouse);
                }
                return (false, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Añadir almacén");
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
                SqlCommand cmd = new SqlCommand("sp_PackWareHousesModify", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idWareHouse", idWareHouse);
                cmd.Parameters.AddWithValue("@nameWareHouse", nameWareHouse);
                cmd.Parameters.AddWithValue("@idEmployee", ClsValues.IfEmptyToDBNull(idEmployee));
                cmd.Parameters.AddWithValue("@active", active);
                cmd.Parameters.AddWithValue("@user", User.GetUserName());
                cmd.ExecuteNonQuery();
                return (true, idWareHouse);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Modificar almacén");
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
                SqlCommand cmd = new SqlCommand("sp_PackWareHousesActive", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@active", active);
                cmd.Parameters.AddWithValue("@user", User.GetUserName());
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Activos almacén");
                return false;
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
    }
}
