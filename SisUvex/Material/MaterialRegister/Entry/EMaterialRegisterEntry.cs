using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SisUvex.Catalogos.Metods.Querys;

namespace SisUvex.Material.MaterialRegister.Entry
{ 
    internal class EMaterialRegisterEntry
    {
        public string idMatInbound { get; set; }
        public DateTime date { get; set; }
        public string idTransportLine { get; set; }
        public string idFreightContainer { get; set; }
        public string idDriver { get; set; }
        public string idWarehouse { get; set; }
        public string idEmployee { get; set; }
        public DataTable dtMaterials { get; set; }
        public static string GetNextId()
        {
            return ClsQuerysDB.GetData("SELECT FORMAT(COALESCE(MAX(id_matInbound), 0) +1, '000000000000000') AS [Id] FROM Pack_MatInbound").ToString();
        }
        public (bool, string?) AddProcedure()
        {
            SQLControl sql = new SQLControl();
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackMatInboundAdd", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@dateInbound", date);
                cmd.Parameters.AddWithValue("@idTransportLine", idTransportLine);
                cmd.Parameters.AddWithValue("@idFreightContainer", idFreightContainer);
                cmd.Parameters.AddWithValue("@idDriver", idDriver);
                cmd.Parameters.AddWithValue("@idWarehouses", idWarehouse);
                cmd.Parameters.AddWithValue("@idEmployee", idEmployee);
                cmd.Parameters.AddWithValue("@user", User.GetUserName());

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string idMatInbound = dr.GetValue(dr.GetOrdinal("Id")).ToString();
                    return (true, idMatInbound);
                }
                return (false, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Añadir entrada de material");
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
                SqlCommand cmd = new SqlCommand("sp_PackMatInboundModify", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idMatInbound", idMatInbound);
                cmd.Parameters.AddWithValue("@dateInbound", date);
                cmd.Parameters.AddWithValue("@idTransportLine", idTransportLine);
                cmd.Parameters.AddWithValue("@idFreightContainer", idFreightContainer);
                cmd.Parameters.AddWithValue("@idDriver", idDriver);
                cmd.Parameters.AddWithValue("@idWarehouses", idWarehouse);
                cmd.Parameters.AddWithValue("@idEmployee", idEmployee);
                cmd.Parameters.AddWithValue("@user", User.GetUserName());

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string idMatInbound = dr.GetValue(dr.GetOrdinal("Id")).ToString();
                    return (true, idMatInbound);
                }
                return (false, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Modificar entrada de material");
                return (false, null);
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
    }
}
