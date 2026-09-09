using System;
using System.Data;
using System.Data.SqlClient;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Catalogos.Metods.Values;

namespace SisUvex.Assets.Vehicle.VehicleType
{
    internal class EVehicleType
    {
        public string? idVehicleType { get; set; }
        public string? nameVehicleType { get; set; }
        public string? implements { get; set; }
        public string? prefix { get; set; }
        public string? meterType { get; set; }

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
                    prefix = dr.GetValue(dr.GetOrdinal("v_prefix")).ToString();
                    meterType = dr.GetValue(dr.GetOrdinal("c_meterType")).ToString();
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

                SqlParameter idOut = new("@id_out", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(idOut);
                cmd.Parameters.AddWithValue("@v_name", ClsValues.IfEmptyToDBNull(nameVehicleType));
                cmd.Parameters.AddWithValue("@v_implements", ClsValues.IfEmptyToDBNull(implements));
                cmd.Parameters.AddWithValue("@v_prefix", ClsValues.IfEmptyToDBNull(prefix));
                cmd.Parameters.AddWithValue("@c_meterType", ClsValues.IfEmptyToDBNull(meterType));
                cmd.Parameters.AddWithValue("@userCreate", User.GetUserName());

                cmd.ExecuteNonQuery();

                if (idOut.Value != null && idOut.Value != DBNull.Value)
                    return (true, idOut.Value.ToString());

                return (false, null);
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
                cmd.Parameters.AddWithValue("@id_vehicleType", idVehicleType);
                cmd.Parameters.AddWithValue("@v_name", ClsValues.IfEmptyToDBNull(nameVehicleType));
                cmd.Parameters.AddWithValue("@v_implements", ClsValues.IfEmptyToDBNull(implements));
                cmd.Parameters.AddWithValue("@v_prefix", ClsValues.IfEmptyToDBNull(prefix));
                cmd.Parameters.AddWithValue("@c_meterType", ClsValues.IfEmptyToDBNull(meterType));
                cmd.Parameters.AddWithValue("@userUpdate", User.GetUserName());

                cmd.ExecuteNonQuery();
                return (true, idVehicleType);
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
