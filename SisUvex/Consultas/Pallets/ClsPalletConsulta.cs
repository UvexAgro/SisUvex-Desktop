using System.Data.SqlClient;
using System.Data;
using SisUvex.Catalogos;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.Querys;
using DocumentFormat.OpenXml.Presentation;

namespace SisUvex.Consultas.Pallets
{
    internal partial class ClsPalletConsulta : ClsCatalogos
    {
        SQLControl sql = new SQLControl();
        public FrmPalletConsulta frm;

        string viewPalletCon = " vw_PackPalletCon ";
        string viewPackPalletConWithShrinkage = " vw_PackPalletConWithShrinkage ";

        public ClsPalletConsulta()
        {
            sql = new SQLControl();
        }

        public void Consulta()
        {
            string f1 = frm.dtpFecha1.Value.ToString("yyyy-MM-dd");
            string f2 = frm.dtpFecha2.Value.ToString("yyyy-MM-dd");
            string query = $"SELECT * FROM vw_PackPalletCon WHERE Fecha BETWEEN '{f1}' AND '{f2}'";

            DataTable dt = new DataTable();
            try
            {
                sql.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter(query, sql.cnn);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo activos");
            }
            finally
            {
                sql.CloseConectionWrite();
            }

            TamañoCeldasDgv();
        }

        public void ConsultaDisPre()
        {

            string f1 = frm.dtpFecha1.Value.ToString("yyyy-MM-dd");
            string f2 = frm.dtpFecha2.Value.ToString("yyyy-MM-dd");
            string viewName = GetViewName();
            string query = $" SELECT * FROM {viewName} WHERE Fecha BETWEEN '{f1}' AND '{f2}' ";

            if (frm.cboDistribuidor.SelectedIndex > 0)
                query += $" AND '{frm.cboDistribuidor.SelectedValue}' IN (SELECT gtn.id_distributor FROM gtn WHERE gtn.id_GTIN = {viewName}.Programa) ";

            if (frm.cboPresentacion.SelectedIndex > 0)
                query += $" AND '{frm.cboPresentacion.SelectedValue}' IN (SELECT gtn.id_presentation FROM gtn WHERE gtn.id_GTIN = {viewName}.Programa) ";

            if (frm.cboVariety.SelectedIndex > 0)
                query += $" AND '{frm.cboVariety.SelectedValue}' IN (SELECT gtn.id_variety FROM gtn WHERE gtn.id_GTIN = {viewName}.Programa) ";

            if (frm.cboContainer.SelectedIndex > 0)
                query += $" AND '{frm.cboContainer.SelectedValue}' IN (SELECT gtn.id_container FROM gtn WHERE gtn.id_GTIN = {viewName}.Programa) ";

            if (!frm.chbShipped.Checked)
                query += " AND Manifiesto IS NULL ";

            if (!frm.chbRacked.Checked)
                query += " AND Rack IS NULL ";

            if (frm.chbRegected.Checked)
                query += " AND Rechazado IS NOT NULL ";


            frm.dgvConsulta.DataSource = ClsQuerysDB.GetDataTable(query);

            TamañoCeldasDgv();
        }

        public void ConsultaManifiesto(string manifiesto)
        {
            
            DataTable dt = new DataTable();

            if (manifiesto.Length == 5)
            {
                string viewName = GetViewName();

                string query = $" SELECT * FROM {viewName} WHERE Manifiesto  = @manifiesto ORDER BY Posicion, Mix ";
    
                try
                {
                    sql.OpenConectionWrite();
                    SqlCommand cmd = new SqlCommand(query, sql.cnn);
                    cmd.Parameters.Add("@manifiesto", SqlDbType.Char, 5).Value = manifiesto;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    da.Fill(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Catálogo pallets en manifiesto");
                }
                finally
                {
                    sql.CloseConectionWrite();
                }
            }

            frm.dgvConsulta.DataSource = dt;

            TamañoCeldasDgv();
        }

        public void ConsultaPallet(string pallet)
        {
            DataTable dt = new DataTable();

            if (pallet.Length > 0)
            {
                string viewName = GetViewName();

                string id = FormatoCeros(pallet, "00000");
                string query = $" SELECT* FROM {viewName} WHERE Estiba = (SELECT Estiba FROM {viewName} WHERE Pallet = '{id}') OR Pallet = '{id}' ";

                try
                {
                    sql.OpenConectionWrite();
                    SqlDataAdapter da = new SqlDataAdapter(query, sql.cnn);
                    da.Fill(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Catálogo pallets");
                }
                finally
                {
                    sql.CloseConectionWrite();
                }
            }
            else
                System.Media.SystemSounds.Hand.Play();

            frm.dgvConsulta.DataSource = dt;

            TamañoCeldasDgv();
        }
        public void EliminarPallet(string id)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackPalletDelete", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@userUpdate", User.GetUserName());

                cmd.ExecuteNonQuery();

                MessageBox.Show("Se eliminó el pallet: " + id, "Eliminar pallet");

                Consulta();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo eliminar pallet");
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
        public void ConsultaPapeleta(string papeleta)
        {
            DataTable dt = new DataTable();

            if (papeleta.Length > 0)
            {
                string viewName = GetViewName();

                string query = $" SELECT * FROM {viewName} WHERE Papeleta  = @pepeleta";

                try
                {
                    sql.OpenConectionWrite();
                    SqlCommand cmd = new SqlCommand(query, sql.cnn);
                    cmd.Parameters.Add("@pepeleta", SqlDbType.Char, 5).Value = papeleta;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    da.Fill(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Catálogo en papeleta");
                }
                finally
                {
                    sql.CloseConectionWrite();
                }
            }
            frm.dgvConsulta.DataSource = dt;

            TamañoCeldasDgv();
        }
        private void TamañoCeldasDgv()
        {
            //if (frm.dgvConsulta.Rows.Count == 0)
            //    frm.dgvConsulta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //else
            //    frm.dgvConsulta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
        }
        private string GetViewName()
        {
            string viewName = viewPalletCon;

            if (frm.chbRestowing.Checked || frm.chbRegected.Checked)
            {
                viewName = viewPackPalletConWithShrinkage;
                frm.dgvConsulta.DataSource = null;
            }

            return viewName;
        }
    }
}