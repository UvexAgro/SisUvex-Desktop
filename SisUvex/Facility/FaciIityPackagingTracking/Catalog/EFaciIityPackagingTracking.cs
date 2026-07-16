using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Catalogos.Metods.Values;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace SisUvex.Facility.FaciIityPackagingTracking.Catalog
{
    internal class EFaciIityPackagingTracking
    {
        public string? idFacilityPackaging { get; set; }
        public string? facPackagingName { get; set; }
        public int active { get; set; }

        /// <summary>
        /// Colores seleccionados: (id_color, n_ratio). Se guarda una fila por color.
        /// </summary>
        public List<(string idColor, decimal ratio)> lsColors { get; set; } = new();

        public static string GetNextId()
        {
            object? o = ClsQuerysDB.GetData("SELECT FORMAT(COALESCE(MAX([id_facilityPackaging]), 0) + 1, '000') FROM [Pack_FacilityPackagingRatio]");
            return o?.ToString() ?? "001";
        }

        private static int CharActiveToInt(object? value)
        {
            if (value == null || value == DBNull.Value)
                return 0;
            return value.ToString() == "1" ? 1 : 0;
        }

        public void GetFacilityPackaging(string? idFacilityPackaging)
        {
            if (string.IsNullOrWhiteSpace(idFacilityPackaging))
                idFacilityPackaging = "0";

            SQLControl sql = new SQLControl();
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand(
                    "SELECT * FROM Pack_FacilityPackagingRatio WHERE id_facilityPackaging = @id ORDER BY id_color",
                    sql.cnn);
                cmd.Parameters.AddWithValue("@id", idFacilityPackaging);

                using SqlDataReader dr = cmd.ExecuteReader();
                bool first = true;
                lsColors = new();

                while (dr.Read())
                {
                    if (first)
                    {
                        this.idFacilityPackaging = dr["id_facilityPackaging"]?.ToString();
                        facPackagingName = dr["v_facPackagingName"]?.ToString();
                        active = CharActiveToInt(dr["c_active"]);
                        first = false;
                    }

                    string? idColor = dr["id_color"]?.ToString();
                    if (string.IsNullOrEmpty(idColor))
                        continue;

                    decimal ratio = 0m;
                    if (dr["n_ratio"] != DBNull.Value)
                        ratio = Convert.ToDecimal(dr["n_ratio"]);

                    lsColors.Add((idColor, ratio));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo relación tipo de empaque");
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }

        private void ValidateEntity()
        {
            if (string.IsNullOrWhiteSpace(facPackagingName) || string.IsNullOrWhiteSpace(idFacilityPackaging))
                throw new Exception("Faltan datos obligatorios del registro.");
            if (active is < 0 or > 1)
                throw new Exception("Valor de activo inválido.");
        }

        public (bool ok, string? id) AddProcedure()
        {
            ValidateEntity();

            SQLControl sql = new SQLControl();
            SqlTransaction? tx = null;
            try
            {
                sql.OpenConectionWrite();
                tx = sql.cnn.BeginTransaction();

                foreach (var (idColor, ratio) in lsColors)
                {
                    SqlCommand cmd = new SqlCommand("sp_PackFacilityPackagingRatioExecute", sql.cnn, tx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@action", "ADD");
                    cmd.Parameters.AddWithValue("@id_facilityPackaging", idFacilityPackaging);
                    cmd.Parameters.AddWithValue("@id_color", idColor);
                    cmd.Parameters.AddWithValue("@facPackagingName", facPackagingName);
                    cmd.Parameters.AddWithValue("@ratio", ratio);
                    cmd.Parameters.AddWithValue("@active", active == 1 ? "1" : "0");
                    cmd.Parameters.AddWithValue("@user", User.GetUserName());
                    cmd.ExecuteNonQuery();
                }

                tx.Commit();
                return (true, idFacilityPackaging);
            }
            catch (Exception ex)
            {
                try { tx?.Rollback(); } catch { }
                MessageBox.Show(ex.ToString(), "Añadir relación tipo de empaque");
                return (false, null);
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }

        public (bool ok, string? id) ModifyProcedure()
        {
            ValidateEntity();

            SQLControl sql = new SQLControl();
            SqlTransaction? tx = null;
            try
            {
                sql.OpenConectionWrite();
                tx = sql.cnn.BeginTransaction();

                // 1) Borra registros anteriores del mismo id (para soportar más/menos colores).
                {
                    SqlCommand cmd = new SqlCommand("sp_PackFacilityPackagingRatioExecute", sql.cnn, tx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@action", "DELETE");
                    cmd.Parameters.AddWithValue("@id_facilityPackaging", idFacilityPackaging);
                    cmd.Parameters.AddWithValue("@id_color", DBNull.Value);
                    cmd.Parameters.AddWithValue("@facPackagingName", DBNull.Value);
                    cmd.Parameters.AddWithValue("@ratio", DBNull.Value);
                    cmd.Parameters.AddWithValue("@active", DBNull.Value);
                    cmd.Parameters.AddWithValue("@user", User.GetUserName());
                    cmd.ExecuteNonQuery();
                }

                foreach (var (idColor, ratio) in lsColors)
                {
                    SqlCommand cmd = new SqlCommand("sp_PackFacilityPackagingRatioExecute", sql.cnn, tx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@action", "MODIFY");
                    cmd.Parameters.AddWithValue("@id_facilityPackaging", idFacilityPackaging);
                    cmd.Parameters.AddWithValue("@id_color", idColor);
                    cmd.Parameters.AddWithValue("@facPackagingName", facPackagingName);
                    cmd.Parameters.AddWithValue("@ratio", ratio);
                    cmd.Parameters.AddWithValue("@active", active == 1 ? "1" : "0");
                    cmd.Parameters.AddWithValue("@user", User.GetUserName());
                    cmd.ExecuteNonQuery();
                }

                tx.Commit();
                return (true, idFacilityPackaging);
            }
            catch (Exception ex)
            {
                try { tx?.Rollback(); } catch { }
                MessageBox.Show(ex.ToString(), "Modificar relación tipo de empaque");
                return (false, null);
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }

        public static bool ActiveProcedure(string id, string activeValue)
        {
            SQLControl sql = new SQLControl();
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackFacilityPackagingRatioExecute", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "STATUS");
                cmd.Parameters.AddWithValue("@id_facilityPackaging", id);
                cmd.Parameters.AddWithValue("@id_color", DBNull.Value);
                cmd.Parameters.AddWithValue("@facPackagingName", DBNull.Value);
                cmd.Parameters.AddWithValue("@ratio", DBNull.Value);
                cmd.Parameters.AddWithValue("@active", activeValue);
                cmd.Parameters.AddWithValue("@user", User.GetUserName());
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Activar/Desactivar relación tipo de empaque");
                return false;
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
    }
}
