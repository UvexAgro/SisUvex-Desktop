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

namespace SisUvex.Material.MaterialRegister.Entry
{ 
    internal class EMaterialRegisterEntry
    {
        public string? idMatInbound { get; set; }
        public DateTime date { get; set; }
        public string? idTransportLine { get; set; }
        public string? idFreightContainer { get; set; }
        public string? idDriver { get; set; }
        public string? idWarehouse { get; set; }
        public string? idEmployee { get; set; }
        public DataTable? dtMaterials { get; set; }

        public const string? cIdMatInbound = "idMatInbound";
        public const string? cPosition = "Posición";
        public static string GetNextId()
        {
            return ClsQuerysDB.GetData("SELECT FORMAT(COALESCE(MAX(id_matInbound), 0) +1, '000000000000000') AS [Id] FROM Pack_MatInbound").ToString();
        }

        public void GetMaterialEntry(string idMaterialInbound)
        {
            if (string.IsNullOrEmpty(idMaterialInbound))
                idMaterialInbound = "0";

            SQLControl sql = new SQLControl();
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Pack_MatInbound WHERE id_matInbound = @idMatInbound", sql.cnn);
                cmd.Parameters.AddWithValue("@idMatInbound", idMaterialInbound);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    this.idMatInbound = dr.GetValue(dr.GetOrdinal("id_matInbound")).ToString();
                    date = Convert.ToDateTime(dr.GetValue(dr.GetOrdinal("d_date")));
                    idTransportLine = dr.GetValue(dr.GetOrdinal("id_transportLine")).ToString();
                    idFreightContainer = dr.GetValue(dr.GetOrdinal("id_freightContainer")).ToString();
                    idDriver = dr.GetValue(dr.GetOrdinal("id_driver")).ToString();
                    idWarehouse = dr.GetValue(dr.GetOrdinal("id_warehouses")).ToString();
                    idEmployee = dr.GetValue(dr.GetOrdinal("id_employee")).ToString();
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

        public void GetMaterialEntryMaterials(string? idMatInbound)
        {
            if (string.IsNullOrEmpty(idMatInbound))
                idMatInbound = "0";

            SQLControl sql = new SQLControl();
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM vw_PackMatInbondEntryMaterials WHERE [{cIdMatInbound}] = @idMatInbound", sql.cnn);
                cmd.Parameters.AddWithValue("@idMatInbound", idMatInbound);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dtMaterials = new DataTable();
                da.Fill(dtMaterials);
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

        public (bool, string?) AddProcedure(SQLControl sql)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_PackMatInboundAdd", sql.cnn, sql.transaction);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@dateInbound", date);
                cmd.Parameters.AddWithValue("@idTransportLine", idTransportLine);
                cmd.Parameters.AddWithValue("@idFreightContainer", idFreightContainer);
                cmd.Parameters.AddWithValue("@idDriver", ClsValues.IfEmptyToDBNull(idDriver));
                cmd.Parameters.AddWithValue("@idWarehouses", idWarehouse);
                cmd.Parameters.AddWithValue("@idEmployee", ClsValues.IfEmptyToDBNull(idEmployee));
                cmd.Parameters.AddWithValue("@user", User.GetUserName());

                SqlDataReader dr = cmd.ExecuteReader();
                string? idMatInbound = null;
                if (dr.Read())
                {
                    idMatInbound = dr.GetValue(dr.GetOrdinal("Id")).ToString();
                    this.idMatInbound = idMatInbound;
                }
                dr.Close();

                return idMatInbound != null ? (true, idMatInbound) : (false, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Añadir entrada de material");
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

                var (success, idMatInbound) = AddProcedure(sql);
                if (!success || idMatInbound == null)
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
                return (true, idMatInbound);
            }
            catch (Exception ex)
            {
                sql.transaction?.Rollback();
                MessageBox.Show(ex.ToString(), "Añadir entrada de material con materiales");
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

                var (success, idMatInbound) = ModifyProcedure(sql);
                if (!success || idMatInbound == null)
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
                return (true, idMatInbound);
            }
            catch (Exception ex)
            {
                sql.transaction?.Rollback();
                MessageBox.Show(ex.ToString(), "Modificar entrada de material con materiales");
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
                SqlCommand cmd = new SqlCommand("sp_PackMatInboundAddMaterials", sql.cnn, sql.transaction);
                cmd.CommandType = CommandType.StoredProcedure;

                int position = 0;

                foreach (DataRow row in dtMaterials.Rows)
                {
                    position++;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@idMatInbound", idMatInbound);
                    cmd.Parameters.AddWithValue("@idInvoice", row["Folio"]);
                    cmd.Parameters.AddWithValue("@comments", ClsValues.IfEmptyToDBNull(row["Obs."].ToString()));
                    cmd.Parameters.AddWithValue("@idDistributor", ClsValues.IfEmptyToDBNull(row[ClsObject.Distributor.ColumnId].ToString()));
                    cmd.Parameters.AddWithValue("@idProvider", ClsValues.IfEmptyToDBNull(row[ClsObject.MaterialProvider.ColumnId].ToString()));
                    cmd.Parameters.AddWithValue("@idGrower", ClsValues.IfEmptyToDBNull(row[ClsObject.Grower.ColumnId].ToString()));
                    cmd.Parameters.AddWithValue("@idMatCatalog", row["Código"]);
                    cmd.Parameters.AddWithValue("@quant", row["Cantidad"]);
                    cmd.Parameters.AddWithValue("@priceMX", ClsValues.IfEmptyToDBNull(row["$MXN"].ToString()));
                    cmd.Parameters.AddWithValue("@priceUS", ClsValues.IfEmptyToDBNull(row["$USD"].ToString()));
                    cmd.Parameters.AddWithValue("@user", User.GetUserName());
                    cmd.Parameters.AddWithValue("@position", position.ToString("00"));

                    cmd.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error al añadir materiales");
                return false;
            }
        }

        private (bool, string?) ModifyProcedure(SQLControl sql)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_PackMatInboundModify", sql.cnn, sql.transaction);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idMatInbound", this.idMatInbound);
                cmd.Parameters.AddWithValue("@dateInbound", date);
                cmd.Parameters.AddWithValue("@idTransportLine", idTransportLine);
                cmd.Parameters.AddWithValue("@idFreightContainer", idFreightContainer);
                cmd.Parameters.AddWithValue("@idDriver", ClsValues.IfEmptyToDBNull(idDriver));
                cmd.Parameters.AddWithValue("@idWarehouses", idWarehouse);
                cmd.Parameters.AddWithValue("@idEmployee", ClsValues.IfEmptyToDBNull(idEmployee));
                cmd.Parameters.AddWithValue("@user", User.GetUserName());

                SqlDataReader dr = cmd.ExecuteReader();
                string? idMatInbound = null;
                if (dr.Read())
                {
                    idMatInbound = dr.GetValue(dr.GetOrdinal("Id")).ToString();
                    this.idMatInbound = idMatInbound;
                }
                dr.Close();

                return idMatInbound != null ? (true, idMatInbound) : (false, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Modificar entrada de material");
                return (false, null);
            }
        }

        public static bool DeleteProcedure(string idMatInbound)
        {
            SQLControl sql = new SQLControl();
            try
            {
                sql.OpenConectionWrite();
                sql.BeginTransaction();
                SqlCommand cmd = new SqlCommand("sp_PackMatInboundDelete", sql.cnn, sql.transaction);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idMatInbound", idMatInbound);
                cmd.ExecuteNonQuery();
                sql.transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                sql.transaction?.Rollback();
                MessageBox.Show(ex.ToString(), "Eliminar entrada de material");
                return false;
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
    }
}
