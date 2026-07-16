using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.Querys;
using static SisUvex.Catalogos.Metods.Values.ClsValues;

namespace SisUvex.Assets.Vehicle.Vehicle
{
    internal class EVehicle
    {
        public string? idVehicle { get; set; }
        public string? idVehicleType { get; set; }
        public string? active { get; set; }
        public string? prefix { get; set; }
        public string? ecoNumber { get; set; }
        public string? serialNumber { get; set; }
        public string? plate { get; set; }
        public string? make { get; set; }
        public string? model { get; set; }
        public string? year { get; set; }
        public string? comments { get; set; }
        public string? idGrower { get; set; }

        public static string GetNextId()
        {
            return ClsQuerysDB.GetData("SELECT FORMAT(COALESCE(MAX(id_vehicle), 0) +1, '0000') FROM Ast_Vehicle");
        }
        public static DataTable? GetDtPrefix()
        {
            return ClsQuerysDB.GetDataTable($" SELECT DISTINCT v_prefix FROM Ast_vehicle  ");
        }

        private void ValidateVehicle()
        {
            if (string.IsNullOrEmpty(idVehicle) || string.IsNullOrEmpty(idVehicleType) ||
                string.IsNullOrEmpty(active) || string.IsNullOrEmpty(prefix) ||
                string.IsNullOrEmpty(ecoNumber))
            {
                throw new Exception("Faltan datos obligatorios del vehículo.");
            }
        }

        public void GetVehicle(string id)
        {
            SQLControl sql = new SQLControl();
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Ast_Vehicle WHERE id_vehicle = @id", sql.cnn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    idVehicle = dr.GetValue(dr.GetOrdinal("id_vehicle")).ToString();
                    idVehicleType = dr.GetValue(dr.GetOrdinal("id_vehicleType")).ToString();
                    active = dr.GetValue(dr.GetOrdinal("c_active")).ToString();
                    prefix = dr.GetValue(dr.GetOrdinal("v_prefix")).ToString();
                    ecoNumber = dr.GetValue(dr.GetOrdinal("v_ecoNumber")).ToString();
                    serialNumber = dr.GetValue(dr.GetOrdinal("v_serialNumber")).ToString();
                    plate = dr.GetValue(dr.GetOrdinal("v_plate")).ToString();
                    make = dr.GetValue(dr.GetOrdinal("v_make")).ToString();
                    model = dr.GetValue(dr.GetOrdinal("v_model")).ToString();
                    year = dr.GetValue(dr.GetOrdinal("c_year")).ToString();
                    comments = dr.GetValue(dr.GetOrdinal("v_comments")).ToString();
                    idGrower = dr.GetValue(dr.GetOrdinal("id_grower")).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Obtener vehículo");
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
                SqlCommand cmd = new SqlCommand("sp_AstVehicleAdd", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idVehicleType", idVehicleType);
                cmd.Parameters.AddWithValue("@active", active);
                cmd.Parameters.AddWithValue("@prefix", prefix);
                cmd.Parameters.AddWithValue("@ecoNumber", ecoNumber);
                cmd.Parameters.AddWithValue("@serialNumber", IfEmptyToDBNull(serialNumber));
                cmd.Parameters.AddWithValue("@plate", IfEmptyToDBNull(plate));
                cmd.Parameters.AddWithValue("@make", IfEmptyToDBNull(make));
                cmd.Parameters.AddWithValue("@model", IfEmptyToDBNull(model));
                cmd.Parameters.AddWithValue("@year", IfEmptyToDBNull(year));
                cmd.Parameters.AddWithValue("@comments", IfEmptyToDBNull(comments));
                cmd.Parameters.AddWithValue("@idGrower", IfEmptyToDBNull(idGrower));
                cmd.Parameters.AddWithValue("@user", User.GetUserName());

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string id = dr.GetValue(dr.GetOrdinal("id_vehicle")).ToString();
                    return (true, id);
                }
                return (false, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Añadir vehículo");
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
                SqlCommand cmd = new SqlCommand("sp_AstVehicleModify", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idVehicle", idVehicle);
                cmd.Parameters.AddWithValue("@idVehicleType", idVehicleType);
                cmd.Parameters.AddWithValue("@active", active);
                cmd.Parameters.AddWithValue("@prefix", prefix);
                cmd.Parameters.AddWithValue("@ecoNumber", ecoNumber);
                cmd.Parameters.AddWithValue("@serialNumber", IfEmptyToDBNull(serialNumber));
                cmd.Parameters.AddWithValue("@plate", IfEmptyToDBNull(plate));
                cmd.Parameters.AddWithValue("@make", IfEmptyToDBNull(make));
                cmd.Parameters.AddWithValue("@model", IfEmptyToDBNull(model));
                cmd.Parameters.AddWithValue("@year", IfEmptyToDBNull(year));
                cmd.Parameters.AddWithValue("@comments", IfEmptyToDBNull(comments));
                cmd.Parameters.AddWithValue("@idGrower", IfEmptyToDBNull(idGrower));
                cmd.Parameters.AddWithValue("@user", User.GetUserName());

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string id = dr.GetValue(dr.GetOrdinal("id_vehicle")).ToString();
                    return (true, id);
                }
                return (false, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Modificar vehículo");
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
                SqlCommand cmd = new SqlCommand("sp_AstVehicleActive", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@active", active);
                cmd.Parameters.AddWithValue("@user", User.GetUserName());
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Cambiar estado vehículo");
                return false;
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
    }
}