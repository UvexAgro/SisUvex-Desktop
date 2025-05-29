using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisUvex.Catalogos.Metods.Querys;
using System.Data.SqlClient;
using System.Data;
using SisUvex.Catalogos.Metods.Values;

namespace SisUvex.Assets.Vehicle.VehicleType
{
    internal class EVehicleType
    {
        public string? idVehicleType { get; set; }
        public string? nameVehicleType { get; set; }
        public string? implements { get; set; }

        public static string GetNextId()
        {
            return ClsQuerysDB.GetData("SELECT FORMAT(COALESCE(MAX(id_vehicleType), 0) +1, '00') AS [ID] FROM Ast_VehicleType");
        }

        public void GetVehicleType(string id)
        {
            SQLControl sql = new();
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new($"SELECT * FROM Ast_VehicleType WHERE id_vehicleType = @idVehicleType", sql.cnn);
                cmd.Parameters.AddWithValue("@idVehicleType", id);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    idVehicleType = dr.GetValue(dr.GetOrdinal("id_vehicleType")).ToString();
                    nameVehicleType = dr.GetValue(dr.GetOrdinal("v_nameVehicleType")).ToString();
                    implements = dr.GetValue(dr.GetOrdinal("v_implements")).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Tipo de vehículo");
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }

        public (bool, string?) AddProcedure()
        {
            SQLControl sql = new();

            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new("sp_AstVehicleTypeAdd", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nameVehicleType", ClsValues.IfEmptyToDBNull(nameVehicleType));
                cmd.Parameters.AddWithValue("@implements", ClsValues.IfEmptyToDBNull(implements));
                cmd.Parameters.AddWithValue("@user", User.GetUserName());

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string? id = dr.GetValue(dr.GetOrdinal("id_vehicleType")).ToString();
                    return (true, id);
                }
                else
                {
                    return (false, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Añadir tipo de vehículo");
                return (false, null);
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }

        public (bool, string?) ModifyProcedure()
        {
            SQLControl sql = new();
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new("sp_AstVehicleTypeModify", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", idVehicleType);
                cmd.Parameters.AddWithValue("@nameVehicleType", ClsValues.IfEmptyToDBNull(nameVehicleType));
                cmd.Parameters.AddWithValue("@implements", ClsValues.IfEmptyToDBNull(implements));
                cmd.Parameters.AddWithValue("@user", User.GetUserName());
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string? id = dr.GetValue(dr.GetOrdinal("id_vehicleType")).ToString();
                    return (true, id);
                }
                else
                {
                    return (false, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Modificar tipo de vehículo");
                return (false, null);
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
    }
}
