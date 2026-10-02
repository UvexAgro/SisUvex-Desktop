using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisUvex.Catalogos.Metods.DataGridViews;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Nomina.Conceptos_Ingresos_Diversos;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace SisUvex.Nomina.Catalago_Costo_de_Cuadros
{
	internal class ClsCostos
	{
		public FrmCostos frm;
		public FrmAgregar frmA;
		public bool IsAddOrModify = true, IsAddUpdate = false, IsModifyUpdate = false;
		public string idAddModify;
		private string id_lot;
		private string c_nombreCuadro;
		private string v_lineas;
		private decimal m_costo;
		private decimal m_porcentajeLinea;
		DataTable dtCuadroCosto;
		ClsDGVCatalog? dgv;
		private string queryCatalog = @"
		SELECT
			id_lot,
			c_nombreCuadro,
			i_lineas,
			m_costo,
			m_porcentajeLinea,
			v_userCreate,
			d_create,
			v_userUpdate,
			d_update
		FROM Nom_CuadroCosto";
		public void BeginFormCat()
		{
			dtCuadroCosto = ClsQuerysDB.GetDataTable(
				queryCatalog + @"
        ORDER BY id_lot"
			);

			dgv = new ClsDGVCatalog(
				frm.dgvCuadroCosto,
				dtCuadroCosto
			);

			EstiloGrid();
		}

		public void OpenFrmAdd()
		{
			IsAddOrModify = true;
			idAddModify = null;

			frmA = new();
			frmA.cls = this;

			frmA.Text = "AGREGAR COSTO POR LOTE";
			frmA.lblTitulo.Text = "AGREGAR COSTO POR LOTE";
			frmA.lblSubtitulo.Text = "Capture la información del costo correspondiente al lote.";

			frmA.ShowDialog();
		}
		public void AddNewRowByIdInDGVCatalog()
		{
			DataTable newIdRow = ClsQuerysDB.GetDataTable(
				queryCatalog + $" WHERE [id_lot] = '{idAddModify}'"
			);

			dgv.AddNewRowToDGV(newIdRow);
		}
		public void OpenFrmModify(string id)
		{
			if (string.IsNullOrEmpty(id))
			{
				MessageBox.Show(
					"Selecciona un lote.",
					"Modificar costo",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning
				);

				return;
			}

			IsAddOrModify = false;
			idAddModify = id;

			frmA = new();
			frmA.cls = this;

			frmA.Text = "MODIFICAR COSTO POR LOTE";
			frmA.lblTitulo.Text = "MODIFICAR COSTO POR LOTE";
			frmA.lblSubtitulo.Text =
				"Modifique la información del costo correspondiente al lote.";

			frmA.ShowDialog();
		}
		public void ModifyRowByIdInDGVCatalog()
		{
			DataTable newIdRow = ClsQuerysDB.GetDataTable(
				queryCatalog + $" WHERE [id_lot] = '{idAddModify}'"
			);

			dgv.ModifyIdRowInDGV(newIdRow);
		}
		public void BtnDelete(string id)
		{
			if (string.IsNullOrEmpty(id))
			{
				MessageBox.Show("Seleccione un registro");
				return;
			}

			DialogResult r = MessageBox.Show(
				"¿Desea eliminar el costo del lote seleccionado?",
				"Eliminar",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question);

			if (r == DialogResult.No)
				return;

			idAddModify = id;

			bool result = DeleteCostoLote();

			if (result)
			{
				MessageBox.Show(
					"Costo por lote eliminado correctamente",
					"Eliminar",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				dgv.DeleteRowInDGV(id);
			}
			else
			{
				MessageBox.Show(
					"No se pudo eliminar el costo por lote",
					"Eliminar",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}
		public bool DeleteCostoLote()
		{
			try
			{
				string query = $@"
            DELETE FROM Nom_CuadroCosto
            WHERE id_lot = '{idAddModify}'";

				ClsQuerysDB.GetDataTable(query);

				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					ex.Message,
					"Eliminar costo por lote",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);

				return false;
			}
		}
		public void CargarLotes()
		{
			try
			{
				string query = @"
			SELECT 
				id_lot,
				v_nameLot,
				id_variety
			FROM Pack_Lot
			WHERE c_active = 1
			ORDER BY v_nameLot";

				DataTable dt = ClsQuerysDB.GetDataTable(query);

				frmA.cboLote.DataSource = null;

				if (dt.Rows.Count == 0)
				{
					frmA.cboLote.Items.Clear();
					return;
				}

				frmA.cboLote.DisplayMember = "v_nameLot";
				frmA.cboLote.ValueMember = "id_lot";
				frmA.cboLote.DataSource = dt;

				frmA.cboLote.SelectedIndex = -1;
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					ex.Message,
					"Cargar Lotes",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);
			}
		}
		private void SetEntity()
		{
			id_lot = frmA.cboLote.SelectedValue?.ToString().Trim();

			c_nombreCuadro = frmA.cboLote.Text.Trim();

			v_lineas = frmA.txbLineas.Text.Trim();

			decimal.TryParse(frmA.txbCosto.Text,out m_costo);

			decimal.TryParse(frmA.txbPorcentaje.Text,out m_porcentajeLinea);
		}
		public void AddProcedure()
		{
			var result = AddCostoLote();

			IsAddUpdate = result.Item1;
			idAddModify = result.Item2;
		}
		public (bool, string?) AddCostoLote()
		{
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				using (SqlCommand cmd = new SqlCommand(
					"sp_AddNomCuadroCosto", sql.cnn))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@id_lot", SqlDbType.Char, 4)
						.Value = id_lot;

					cmd.Parameters.Add("@c_nombreCuadro", SqlDbType.VarChar, 50)
						.Value = c_nombreCuadro;

					cmd.Parameters.Add("@i_lineas", SqlDbType.VarChar, 20)
						.Value = v_lineas;

					cmd.Parameters.Add("@m_costo", SqlDbType.Decimal)
						.Value = m_costo;

					cmd.Parameters.Add("@m_porcentajeLinea", SqlDbType.Decimal)
						.Value = m_porcentajeLinea;

					cmd.Parameters.Add("@v_userCreate", SqlDbType.VarChar, 50)
						.Value = User.GetUserName();

					object result = cmd.ExecuteScalar();

					if (result != null)
					{
						id_lot = result.ToString();

						return (true, id_lot);
					}

					return (false, null);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					ex.Message,
					"Agregar Costo por Lote");

				return (false, null);
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}
		public void ModifyProcedure()
		{
			id_lot = idAddModify;

			IsModifyUpdate = UpdateCostoLote();
		}
		public bool UpdateCostoLote()
		{
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				using (SqlCommand cmd = new SqlCommand(
					"sp_UpdateNomCuadroCosto", sql.cnn))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@id_lot", SqlDbType.Char, 4)
						.Value = id_lot;

					cmd.Parameters.Add("@c_nombreCuadro", SqlDbType.VarChar, 50)
						.Value = c_nombreCuadro;

					cmd.Parameters.Add("@i_lineas", SqlDbType.VarChar, 20)
						.Value = v_lineas;

					cmd.Parameters.Add("@m_costo", SqlDbType.Decimal)
						.Value = m_costo;

					cmd.Parameters.Add("@m_porcentajeLinea", SqlDbType.Decimal)
						.Value = m_porcentajeLinea;

					cmd.Parameters.Add("@userUpdate", SqlDbType.VarChar, 50)
						.Value = User.GetUserName();

					cmd.ExecuteNonQuery();

					return true;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					ex.Message,
					"Modificar Costo por Lote");

				return false;
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}
		public void BtnAccept()
		{
			if (frmA.cboLote.SelectedIndex == -1)
			{
				MessageBox.Show("Debe seleccionar un lote.");
				frmA.cboLote.Focus();
				return;
			}

			SetEntity();

			if (IsAddOrModify)
			{
				AddProcedure();

				if (IsAddUpdate)
				{
					frmA.Close();
				}
				else
				{
					MessageBox.Show("No se pudo agregar el costo por lote");
				}
			}
			else
			{
				ModifyProcedure();

				if (IsModifyUpdate)
				{
					frmA.Close();
				}
				else
				{
					MessageBox.Show("No se pudo modificar el costo por lote");
				}
			}
		}
		public void CargarDatosModificar()
		{
			try
			{
				string query = $@"
				SELECT 
					id_lot,
					c_nombreCuadro,
					i_lineas,
					m_costo,
					m_porcentajeLinea
				FROM Nom_CuadroCosto
				WHERE id_lot = '{idAddModify}'";

				DataTable dt = ClsQuerysDB.GetDataTable(query);

				if (dt.Rows.Count == 0)
				{
					MessageBox.Show(
						"No se encontró el costo del lote.",
						"Modificar Costo por Lote",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning
					);

					return;
				}

				DataRow row = dt.Rows[0];

				// ==========================================
				// LOTE
				// ==========================================

				frmA.cboLote.SelectedValue =
					row["id_lot"].ToString().Trim();

				// ==========================================
				// LÍNEAS
				// ==========================================

				frmA.txbLineas.Text =
					row["v_lineas"].ToString();

				frmA.txbLineas.ForeColor =
					System.Drawing.Color.Black;

				// ==========================================
				// COSTO
				// ==========================================

				frmA.txbCosto.Text =
					row["m_costo"].ToString();

				frmA.txbCosto.ForeColor =
					System.Drawing.Color.Black;

				// ==========================================
				// PORCENTAJE
				// ==========================================

				frmA.txbPorcentaje.Text =
					row["m_porcentajeLinea"].ToString();

				frmA.txbPorcentaje.ForeColor =
					System.Drawing.Color.Black;
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					ex.Message,
					"Cargar Costo por Lote",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);
			}
		}
		public void EstiloGrid()
		{
			DataGridView dgv = frm.dgvCuadroCosto;

			dgv.ReadOnly = true;
			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToDeleteRows = false;
			dgv.AllowUserToResizeRows = false;
			dgv.RowHeadersVisible = false;

			dgv.SelectionMode =
				DataGridViewSelectionMode.FullRowSelect;

			dgv.MultiSelect = false;

			dgv.RowTemplate.Height = 32;
			dgv.ColumnHeadersHeight = 38;

			dgv.AutoSizeColumnsMode =
				DataGridViewAutoSizeColumnsMode.Fill;

			// Fondo
			dgv.BackgroundColor =
				System.Drawing.Color.White;

			dgv.GridColor =
				System.Drawing.Color.FromArgb(225, 225, 225);

			// Encabezado
			dgv.EnableHeadersVisualStyles = false;

			dgv.ColumnHeadersDefaultCellStyle.BackColor =
				System.Drawing.Color.FromArgb(245, 247, 250);

			dgv.ColumnHeadersDefaultCellStyle.ForeColor =
				System.Drawing.Color.FromArgb(50, 50, 50);

			dgv.ColumnHeadersDefaultCellStyle.Font =
				new System.Drawing.Font(
					"Segoe UI",
					11F,
					System.Drawing.FontStyle.Bold);

			dgv.ColumnHeadersDefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			// Filas
			dgv.DefaultCellStyle.Font =
				new System.Drawing.Font("Segoe UI", 9F);

			dgv.DefaultCellStyle.ForeColor =
				System.Drawing.Color.FromArgb(50, 50, 50);

			dgv.DefaultCellStyle.BackColor =
				System.Drawing.Color.White;

			dgv.DefaultCellStyle.SelectionBackColor =
				System.Drawing.Color.FromArgb(225, 238, 252);

			dgv.DefaultCellStyle.SelectionForeColor =
				System.Drawing.Color.FromArgb(30, 30, 30);

			dgv.DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleLeft;

			// Lote
			dgv.Columns[0].FillWeight = 15;
			dgv.Columns[0].DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			// Nombre del lote
			dgv.Columns[1].FillWeight = 30;

			// Líneas
			dgv.Columns[2].FillWeight = 20;
			dgv.Columns[2].DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			// Costo
			dgv.Columns[3].FillWeight = 15;
			dgv.Columns[3].DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleRight;

			dgv.Columns[3].DefaultCellStyle.Format =
				"$#,##0.00";

			// Porcentaje
			dgv.Columns[4].FillWeight = 15;
			dgv.Columns[4].DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			dgv.Columns[4].DefaultCellStyle.Format =
				"0.00";

			// Fecha
			dgv.Columns[5].FillWeight = 15;
			dgv.Columns[5].DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			dgv.Columns[5].DefaultCellStyle.Format =
				"dd/MM/yyyy";
		}
	}
}
