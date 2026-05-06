using System.Data;
using System.Data.SqlClient;
using DocumentFormat.OpenXml.Presentation;
using SisUvex.Catalogos;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Nomina.Conceptos_Ingresos_Diversos;
using Font = System.Drawing.Font;

namespace SisUvex.Consultas.Pallets
{
    internal partial class ClsPalletConsulta : ClsCatalogos
    {
        SQLControl sql = new SQLControl();
        public FrmPalletConsulta frm;
        public FrmPapeleta frmP;

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
		public void btnBuscarPapeleta()
		{
			string invoice = frmP.txbInvoice.Text.Trim();
			DateTime fecha = frmP.dtpFecha.Value.Date;

			if (string.IsNullOrEmpty(invoice))
			{
				MessageBox.Show("Ingresa un Folio.");
				return;
			}

			string query = $@"
            SELECT 
                CAST(d_packed AS DATE) AS Fecha,
                id_pallet AS Pallet,
                v_invoice AS Papeleta,
                SUM(i_boxes) AS Cajas
            FROM SisUvex.dbo.Pack_Pallet
            WHERE v_invoice = '{invoice}'
            AND CAST(d_packed AS DATE) = '{fecha:yyyy-MM-dd}'
            GROUP BY 
                CAST(d_packed AS DATE),
                id_pallet,
                v_invoice
            ORDER BY 
                Fecha,
                id_pallet";

			frmP.dgvConsulta.DataSource = ClsQuerysDB.GetDataTable(query);

			AgregarCheckBox();
			EstiloDGV();


			frmP.dgvConsulta.ReadOnly = false;

			foreach (DataGridViewColumn col in frmP.dgvConsulta.Columns)
			{
				if (col.Name != "Seleccionar")
					col.ReadOnly = true;
			}
		}
		public void AgregarCheckBox()
		{
			if (!frmP.dgvConsulta.Columns.Contains("Seleccionar"))
			{
				DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
				chk.Name = "Seleccionar";
				chk.HeaderText = "✔";
				chk.Width = 50;

				chk.TrueValue = true;
				chk.FalseValue = false;
				chk.ThreeState = false;

				chk.DefaultCellStyle.NullValue = false;

				frmP.dgvConsulta.Columns.Insert(0, chk);
			}
		}
		public void btnActualizar()
		{
			List<int> palletsSeleccionados = new List<int>();

			foreach (DataGridViewRow row in frmP.dgvConsulta.Rows)
			{
				if (row.IsNewRow) continue;

				bool seleccionado = Convert.ToBoolean(row.Cells["Seleccionar"].Value); 

				if (seleccionado)
				{
					int idPallet = Convert.ToInt32(row.Cells["Pallet"].Value);
					palletsSeleccionados.Add(idPallet);
				}
			}

			if (palletsSeleccionados.Count == 0)
			{
				MessageBox.Show("Selecciona al menos un pallet.");
				return;
			}

			if (string.IsNullOrWhiteSpace(frmP.txbPapeleta.Text))
			{
				MessageBox.Show("Ingrese el nuevo folio.");
				return;
			}

			string ids = string.Join(",", palletsSeleccionados);

			string query = $@"
            UPDATE SisUvex.dbo.Pack_Pallet
            SET v_invoice = '{frmP.txbPapeleta.Text}'
            WHERE id_pallet IN ({ids})";

			ClsQuerysDB.ExecuteQuery(query);

			MessageBox.Show("Papeleta actualizada correctamente.");

			frmP.DialogResult = DialogResult.OK;
			frmP.Close();
		}
		private void EstiloDGV()
		{
			var dgv = frmP.dgvConsulta;

			//  Fondo general
			dgv.BorderStyle = BorderStyle.None;
			dgv.BackgroundColor = Color.White;
			dgv.EnableHeadersVisualStyles = false;

			//  Encabezados
			dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
			dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
			dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(70, 70, 70);
			dgv.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
			dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dgv.ColumnHeadersHeight = 32;

			//  Filas
			dgv.DefaultCellStyle.BackColor = Color.White;
			dgv.DefaultCellStyle.ForeColor = Color.FromArgb(60, 60, 60);
			dgv.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9);
			dgv.RowTemplate.Height = 26;

			//  Alternado suave
			dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250);

			//  Selección (gris elegante)
			dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(210, 210, 210);
			dgv.DefaultCellStyle.SelectionForeColor = Color.Black;

			//  BORDES COMPLETOS (filas + columnas)
			dgv.CellBorderStyle = DataGridViewCellBorderStyle.Single;
			dgv.GridColor = Color.FromArgb(220, 220, 220);

			//  Quitar encabezado lateral
			dgv.RowHeadersVisible = false;

			//  Ajuste automático
			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

			//  Comportamiento
			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToResizeRows = false;
			dgv.MultiSelect = false;

			//  Quitar selección inicial
			dgv.ClearSelection();
		}
	}
}