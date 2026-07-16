using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.Values;
using Microsoft.Win32.SafeHandles;
using iText.Commons.Utils;

namespace SisUvex.Material.MaterialRegister.Exit
{
    internal class EMaterialRegisterExit
    {
        //--[SON LAS MISMAS PARA LA SALIDA EXTERNA Y LA INTERNA (RegisterExit y RegisterFieldExit)]
        public string? idMatOutbound { get; set; }
        public string? idOutputType { get; set; }
        public DateTime dateOutbound { get; set; }
        public string? idFreightContainer { get; set; }
        public string? idDriver { get; set; }
        public string? idVehicle { get; set; }
        public string? idWarehouse { get; set; }
        public string? idLot { get; set; }
        public string? idVariety { get; set; }
        public string? idForeignDest { get; set; }
        public string? idEmployee { get; set; }
        public string? matDeliveryMan { get; set; }
        public string? idExitStatus { get; set; }
        public string? idTransportLine { get; set; }
        public DataTable? dtMaterials { get; set; }

        public const string cIdMatOutbound = "idMatOutbound";
        public const string cPosition = "Posición";
        public const string cIdOutputType = "idOutputType";
        public const string cIdExitStatus = "idExitStatus";

        public static DataTable? GetDTOutputType()
        {
            return ClsQuerysDB.GetDataTable($" SELECT id_outputType AS [{ClsObject.Column.id}], v_nameType AS [{ClsObject.Column.name}] FROM Pack_OutputType ");
        }

        public static DataTable? GetDTExitStatus()
        {
            return ClsQuerysDB.GetDataTable($" SELECT id_exitStatus AS [{ClsObject.Column.id}], v_nameStatus AS [{ClsObject.Column.name}]  from Pack_ExitStatus ");
        }

        public static string GetNextId()
        {
            return ClsQuerysDB.GetData("SELECT FORMAT(COALESCE(MAX(id_matOutbound), 0) +1, '000000000000000') AS [Id] FROM Pack_MatOutput").ToString();
        }
        public static DataTable? GetDTMatDeliveryMan()
        {
            return ClsQuerysDB.GetDataTable($" SELECT DISTINCT v_matDeliveryMan AS [{ClsObject.Column.name}] FROM Pack_MatOutput ");
        }

        public void GetMaterialOutbound(string idMaterialOutbound)
        {
            if (string.IsNullOrEmpty(idMaterialOutbound))
                idMaterialOutbound = "0";

            SQLControl sql = new SQLControl();
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Pack_MatOutput WHERE id_matOutbound = @idMatOutbound", sql.cnn);
                cmd.Parameters.AddWithValue("@idMatOutbound", idMaterialOutbound);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    this.idMatOutbound = dr.GetValue(dr.GetOrdinal("id_matOutbound")).ToString();
                    idOutputType = dr.GetValue(dr.GetOrdinal("id_outputType")).ToString();
                    dateOutbound = Convert.ToDateTime(dr.GetValue(dr.GetOrdinal("d_date")));
                    idFreightContainer = dr.GetValue(dr.GetOrdinal("id_freightContainer")).ToString();
                    idDriver = dr.GetValue(dr.GetOrdinal("id_driver")).ToString();
                    idVehicle = dr.GetValue(dr.GetOrdinal("id_vehiculos")).ToString();
                    idWarehouse = dr.GetValue(dr.GetOrdinal("id_warehouses")).ToString();
                    idLot = dr.GetValue(dr.GetOrdinal("id_lot")).ToString();
                    idVariety = dr.GetValue(dr.GetOrdinal("id_variety")).ToString();
                    idForeignDest = dr.GetValue(dr.GetOrdinal("id_foreignDest")).ToString();
                    idEmployee = dr.GetValue(dr.GetOrdinal("id_employee")).ToString();
                    matDeliveryMan = dr.GetValue(dr.GetOrdinal("v_matDeliveryMan")).ToString();
                    idExitStatus = dr.GetValue(dr.GetOrdinal("id_exitStatus")).ToString();
                    idTransportLine = dr.GetValue(dr.GetOrdinal("id_transportLine")).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo de salidas");
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }

        public void GetMaterialOutboundMaterials(string? idMatOutbound)
        {
            if (string.IsNullOrEmpty(idMatOutbound))
                idMatOutbound = "0";

            SQLControl sql = new SQLControl();
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM vw_PackMatOutputExitMaterials WHERE [{cIdMatOutbound}] = @idMatOutbound", sql.cnn);
                cmd.Parameters.AddWithValue("@idMatOutbound", idMatOutbound);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dtMaterials = new DataTable();
                da.Fill(dtMaterials);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Materiales de salida");
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }

        public (bool, string?) AddProcedure(SQLControl sql)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_PackMatOutputAdd", sql.cnn, sql.transaction);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idOutputType", idOutputType);
                cmd.Parameters.AddWithValue("@dateOutput", dateOutbound);
                cmd.Parameters.AddWithValue("@idFreightContainer", ClsValues.IfEmptyToDBNull(idFreightContainer));
                cmd.Parameters.AddWithValue("@idDriver", ClsValues.IfEmptyToDBNull(idDriver));
                cmd.Parameters.AddWithValue("@idVehicle", ClsValues.IfEmptyToDBNull(idVehicle));
                cmd.Parameters.AddWithValue("@idWarehouses", ClsValues.IfEmptyToDBNull(idWarehouse));
                cmd.Parameters.AddWithValue("@idLot", ClsValues.IfEmptyToDBNull(idLot));
                cmd.Parameters.AddWithValue("@idVariety", ClsValues.IfEmptyToDBNull(idVariety));
                cmd.Parameters.AddWithValue("@idForeignDest", ClsValues.IfEmptyToDBNull(idForeignDest));
                cmd.Parameters.AddWithValue("@idEmployee", ClsValues.IfEmptyToDBNull(idEmployee));
                cmd.Parameters.AddWithValue("@matDeliveryMan", ClsValues.IfEmptyToDBNull(matDeliveryMan));
                cmd.Parameters.AddWithValue("@user", User.GetUserName());
                cmd.Parameters.AddWithValue("@idExitStatus", ClsValues.IfEmptyToDBNull(idExitStatus));
                cmd.Parameters.AddWithValue("@idTransportLine", ClsValues.IfEmptyToDBNull(idTransportLine));

                SqlDataReader dr = cmd.ExecuteReader();
                string? idMatOutbound = null;
                if (dr.Read())
                {
                    idMatOutbound = dr.GetValue(dr.GetOrdinal("Id")).ToString();
                    this.idMatOutbound = idMatOutbound;
                }
                dr.Close();

                return idMatOutbound != null ? (true, idMatOutbound) : (false, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Añadir salida de material");
                return (false, null);
            }
        }

        public (bool, string?) AddProcedureWithMaterials()
        {
            SQLControl sql = new SQLControl();
            try
            {
                sql.OpenConectionWrite();
                sql.BeginTransaction();

                var (success, idMatOutbound) = AddProcedure(sql);
                if (!success || idMatOutbound == null)
                {
                    sql.transaction.Rollback();
                    return (false, null);
                }

                if (!AddMaterials(sql))
                {
                    sql.transaction.Rollback();
                    return (false, null);
                }

                sql.transaction.Commit();
                return (true, idMatOutbound);
            }
            catch (Exception ex)
            {
                sql.transaction?.Rollback();
                MessageBox.Show(ex.ToString(), "Añadir salida de material con materiales");
                return (false, null);
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }

        public (bool, string?) ModifyProcedureWithMaterials()
        {
            SQLControl sql = new SQLControl();
            try
            {
                sql.OpenConectionWrite();
                sql.BeginTransaction();

                var (success, idMatOutbound) = ModifyProcedure(sql);
                if (!success || idMatOutbound == null)
                {
                    sql.transaction.Rollback();
                    return (false, null);
                }

                if (!AddMaterials(sql))
                {
                    sql.transaction.Rollback();
                    return (false, null);
                }

                sql.transaction.Commit();
                return (true, idMatOutbound);
            }
            catch (Exception ex)
            {
                sql.transaction?.Rollback();
                MessageBox.Show(ex.ToString(), "Modificar salida de material con materiales");
                return (false, null);
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }

        private bool AddMaterials(SQLControl sql)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_PackMatOutputAddMaterials", sql.cnn, sql.transaction);
                cmd.CommandType = CommandType.StoredProcedure;

                int position = 0;

                foreach (DataRow row in dtMaterials.Rows)
                {
                    position++;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@idMatOutbound", idMatOutbound);
                    cmd.Parameters.AddWithValue("@position", position.ToString("00"));
                    cmd.Parameters.AddWithValue("@idDistributor", ClsValues.IfEmptyToDBNull(row["idDistributor"].ToString()));
                    cmd.Parameters.AddWithValue("@idGrower", ClsValues.IfEmptyToDBNull(row["idGrower"].ToString()));
                    cmd.Parameters.AddWithValue("@idMaterialCat", row["Código"]);
                    cmd.Parameters.AddWithValue("@quant", row["Cantidad"]);
                    cmd.Parameters.AddWithValue("@priceMX", ClsValues.GetDecimalOrNullDB(row["$MXN"].ToString()));
                    cmd.Parameters.AddWithValue("@priceUS", ClsValues.GetDecimalOrNullDB(row["$USD"].ToString()));
                    cmd.Parameters.AddWithValue("@invoice", ClsValues.IfEmptyToDBNull(row["Folio"].ToString()));
                    cmd.Parameters.AddWithValue("@user", User.GetUserName());

                    cmd.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error al añadir materiales de salida");
                return false;
            }
        }

        private (bool, string?) ModifyProcedure(SQLControl sql)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_PackMatOutputModify", sql.cnn, sql.transaction);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idMatOutbound", this.idMatOutbound);
                cmd.Parameters.AddWithValue("@idOutputType", idOutputType);
                cmd.Parameters.AddWithValue("@dateOutput", dateOutbound);
                cmd.Parameters.AddWithValue("@idFreightContainer", ClsValues.IfEmptyToDBNull(idFreightContainer));
                cmd.Parameters.AddWithValue("@idDriver", ClsValues.IfEmptyToDBNull(idDriver));
                cmd.Parameters.AddWithValue("@idVehicle", ClsValues.IfEmptyToDBNull(idVehicle));
                cmd.Parameters.AddWithValue("@idWarehouses", ClsValues.IfEmptyToDBNull(idWarehouse));
                cmd.Parameters.AddWithValue("@idLot", ClsValues.IfEmptyToDBNull(idLot));
                cmd.Parameters.AddWithValue("@idVariety", ClsValues.IfEmptyToDBNull(idVariety));
                cmd.Parameters.AddWithValue("@idForeignDest", ClsValues.IfEmptyToDBNull(idForeignDest));
                cmd.Parameters.AddWithValue("@idEmployee", ClsValues.IfEmptyToDBNull(idEmployee));
                cmd.Parameters.AddWithValue("@matDeliveryMan", ClsValues.IfEmptyToDBNull(matDeliveryMan));
                cmd.Parameters.AddWithValue("@user", User.GetUserName());
                cmd.Parameters.AddWithValue("@idExitStatus", ClsValues.IfEmptyToDBNull(idExitStatus));
                cmd.Parameters.AddWithValue("@idTransportLine", ClsValues.IfEmptyToDBNull(idTransportLine));

                SqlDataReader dr = cmd.ExecuteReader();
                string? idMatOutbound = null;
                if (dr.Read())
                {
                    idMatOutbound = dr.GetValue(dr.GetOrdinal("Id")).ToString();
                    this.idMatOutbound = idMatOutbound;
                }
                dr.Close();

                return idMatOutbound != null ? (true, idMatOutbound) : (false, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Modificar salida de material");
                return (false, null);
            }
        }

        public static bool DeleteProcedure(string idMatOutbound)
        {
            SQLControl sql = new SQLControl();
            try
            {
                sql.OpenConectionWrite();
                sql.BeginTransaction();
                SqlCommand cmd = new SqlCommand("sp_PackMatOutputDelete", sql.cnn, sql.transaction);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idMatOutbound", idMatOutbound);
                cmd.ExecuteNonQuery();
                sql.transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                sql.transaction?.Rollback();
                MessageBox.Show(ex.ToString(), "Eliminar salida de material");
                return false;
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
    }
}