using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Catalogos.Metods.Values;

namespace SisUvex.Catalogos.Lot
{
    internal class ELot
    {
        public string? idLot { get; set; }
        public string? idVariety { get; set; }
        public string? nameLot { get; set; }
        public int? active { get; set; }
        public decimal ha { get; set; }
        public DateTime date { get; set; }
        public string? idFarm { get; set; }
        public string? rowAxis { get; set; }

        public void SetLot(string idLot, string idVariety)
        {
            string qry = "SELECT * FROM Pack_Lot WHERE id_lot = @idLot AND id_variety = @idVariety";

            Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@idLot", idLot },
                    { "@idVariety", idVariety }
                };

            DataTable dt = ClsQuerysDB.ExecuteParameterizedQuery(qry, parameters);

            if (dt.Rows.Count > 0 && !string.IsNullOrEmpty(dt.Rows[0][0].ToString()))
            {
                DataRow dr = dt.Rows[0];
                this.idLot = dr["id_lot"].ToString();
                this.idVariety = dr["id_variety"].ToString();
                nameLot = dr["v_nameLot"].ToString();
                active = int.Parse(dr["c_active"].ToString());
                ha = decimal.Parse(dr["n_ha"].ToString());
                date = DateTime.Parse(dr["d_year"].ToString());
                idFarm = dr["id_farm"].ToString();
                rowAxis = dr["c_rowAxis"] == DBNull.Value ? null : dr["c_rowAxis"].ToString();
            }
        }

        /// <summary>
        /// Orientación de surcos hardcodeada (no hay catálogo): índice 0 ---Seleccionar---, NS y EW.
        /// </summary>
        public static void LoadRowAxisCombo(ComboBox cbo)
        {
            DataTable dt = new();
            dt.Columns.Add(ClsObject.Column.id, typeof(string));
            dt.Columns.Add(ClsObject.Column.name, typeof(string));

            dt.Rows.Add(string.Empty, ClsComboBoxes.textSelect);
            dt.Rows.Add("NS", "Norte-Sur (NS)");
            dt.Rows.Add("EW", "Este-Oeste (EW)");

            cbo.DataSource = dt;
            cbo.DisplayMember = ClsObject.Column.name;
            cbo.ValueMember = ClsObject.Column.id;
            cbo.SelectedIndex = 0;
        }

        private void AddExecuteParameters(SqlCommand cmd, string action)
        {
            cmd.Parameters.AddWithValue("@action", action);
            cmd.Parameters.AddWithValue("@id", idLot);
            cmd.Parameters.AddWithValue("@name", nameLot);
            cmd.Parameters.AddWithValue("@idVariety", idVariety);
            cmd.Parameters.AddWithValue("@ha", ha);
            cmd.Parameters.AddWithValue("@year", date.Date);
            cmd.Parameters.AddWithValue("@active", active == 1 ? "1" : "0");
            cmd.Parameters.AddWithValue("@idFarm", ClsValues.IfEmptyToDBNull(idFarm));
            cmd.Parameters.AddWithValue("@rowAxis", ClsValues.IfEmptyToDBNull(rowAxis));
            cmd.Parameters.AddWithValue("@user", User.GetUserName());
        }

        public (bool success, string? id) AddProcedure()
        {
            SQLControl sql = new();
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new("sp_PackLotExecute", sql.cnn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                AddExecuteParameters(cmd, "ADD");

                using SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                    return (true, dr["id_lot"].ToString());

                return (false, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Añadir lote");
                return (false, null);
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }

        public (bool success, string? id) ModifyProcedure()
        {
            SQLControl sql = new();
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new("sp_PackLotExecute", sql.cnn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                AddExecuteParameters(cmd, "MODIFY");

                using SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                    return (true, dr["id_lot"].ToString());

                return (false, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Modificar lote");
                return (false, null);
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }

        public static bool ActiveProcedure(string idLot, string idVariety, string active)
        {
            SQLControl sql = new();
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new("sp_PackLotExecute", sql.cnn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@action", "STATUS");
                cmd.Parameters.AddWithValue("@id", idLot);
                cmd.Parameters.AddWithValue("@idVariety", idVariety);
                cmd.Parameters.AddWithValue("@active", active);
                cmd.Parameters.AddWithValue("@user", User.GetUserName());

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Activar/Desactivar lote");
                return false;
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
    }
}
