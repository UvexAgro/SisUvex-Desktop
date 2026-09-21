using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Presentation;
using DocumentFormat.OpenXml.Wordprocessing;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using SisUvex.Catalogos.Metods.DataGridViews;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Nomina.Nom_Descuento_de_personal;
using System.Drawing;


namespace SisUvex.Nomina.NomCuadrillasCampo
{
	public class ClsCuadrillas
	{
		public FrmCuadrillas frm;
		public FrmAgregar frmAdd;
		public bool IsAddOrModify = true, IsAddUpdate = false, IsModifyUpdate = false;
		public string idAddModify;
		ClsDGVCatalog? dgv;
		DataTable dtCuadrilla;
		public string id_workGroup { get; set; }
		public string v_nameWorkGroup { get; set; }
		public string c_order { get; set; }
		public bool c_active { get; set; }
				public string queryCatalog = @"
		SELECT 
			id_workGroup AS [Código],
			c_order AS [Orden],
			v_nameWorkGroup AS [Nombre de cuadrilla],
			CASE 
				WHEN c_active = 1 THEN 'Activa'
				ELSE 'Inactiva'
			END AS [Estado],
			d_create AS [Fecha]
		FROM Nom_WorkGroup";

		public void BeginFormCat()
		{
			dtCuadrilla = ClsQuerysDB.GetDataTable(
				queryCatalog + @"
        ORDER BY 
            CASE 
                WHEN c_order IS NULL OR c_order = '' THEN 1 
                ELSE 0 
            END,
            c_order,
            id_workGroup"
			);

			dgv = new ClsDGVCatalog(frm.dgvCuadrillas, dtCuadrilla);

			EstiloGrid();
		}
		public (bool, string?) AddCuadrilla()
		{
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				using (SqlCommand cmd = new SqlCommand("sp_AddNomWorkGroup", sql.cnn))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@v_nameWorkGroup", SqlDbType.VarChar)
						.Value = v_nameWorkGroup;

					cmd.Parameters.Add("@c_active", SqlDbType.Bit)
						.Value = c_active;

					cmd.Parameters.Add("@c_order", SqlDbType.Char, 3)
						.Value = string.IsNullOrWhiteSpace(c_order)
							? DBNull.Value
							: c_order.Trim().PadLeft(3, '0');

					cmd.Parameters.Add("@userCreate", SqlDbType.VarChar)
						.Value = User.GetUserName();

					object result = cmd.ExecuteScalar();

					if (result != null)
					{
						id_workGroup = result.ToString();

						return (true, id_workGroup);
					}

					return (false, null);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Agregar Cuadrilla");
				return (false, null);
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}
		public bool UpdateCuadrilla()
		{
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				using (SqlCommand cmd = new SqlCommand("sp_UpdateNomWorkGroup", sql.cnn))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@id_workGroup", SqlDbType.Char, 3).Value = id_workGroup;
					cmd.Parameters.Add("@v_nameWorkGroup", SqlDbType.VarChar).Value = v_nameWorkGroup;
					cmd.Parameters.Add("@c_active", SqlDbType.Bit).Value = c_active;
					cmd.Parameters.Add("@c_order", SqlDbType.Char, 3).Value =
						string.IsNullOrWhiteSpace(c_order)
							? DBNull.Value
							: c_order.Trim().PadLeft(3, '0');

					cmd.Parameters.Add("@userUpdate", SqlDbType.VarChar).Value =
						User.GetUserName();

					cmd.ExecuteNonQuery();

					return true;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Modificar Cuadrilla");
				return false;
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}
		public bool DeleteCuadrilla()
		{
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				using (SqlCommand cmd = new SqlCommand("sp_DeleteNomWorkGroup", sql.cnn))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@id_workGroup", SqlDbType.Char, 3).Value = id_workGroup;
					cmd.Parameters.Add("@userUpdate", SqlDbType.VarChar).Value = User.GetUserName();

					cmd.ExecuteNonQuery();

					return true;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Eliminar Cuadrilla");
				return false;
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}
		public void OpenFrmAdd()
		{
			IsAddOrModify = true;
			idAddModify = null;

			frmAdd = new();
			frmAdd.cls = this;

			frmAdd.Text = "AGREGAR CUADRILLA ";
			frmAdd.lblTitulo.Text = "AGREGAR CUADRILLA ";
			frmAdd.lblSubtitulo.Text = "Capture la información de la nueva cuadrilla.";
			frmAdd.ShowDialog();
		}
		public void OpenFrmModify(string id)
		{
			if (string.IsNullOrEmpty(id))
			{
				MessageBox.Show("Seleccione una cuadrilla");
				return;
			}

			IsAddOrModify = false;
			idAddModify = id;

			frmAdd = new();
			frmAdd.cls = this;

			frmAdd.Text = "Modificar Cuadrilla";
			frmAdd.lblTitulo.Text = "Modificar Cuadrilla";
			frmAdd.lblSubtitulo.Text = "Modifique la información de la cuadrilla.";

			frmAdd.ShowDialog();
		}
		public void AddNewRowByIdInDGVCatalog()
		{
			DataTable newIdRow = ClsQuerysDB.GetDataTable(queryCatalog + $" WHERE [id_workGroup] = '{idAddModify}'"
			);

			
			dgv.AddNewRowToDGV(newIdRow);
		}
		public void ModifyRowByIdInDGVCatalog()
		{
			DataTable newIdRow = ClsQuerysDB.GetDataTable(queryCatalog + $" WHERE [id_workGroup] = '{idAddModify}'");
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
				"¿Desea eliminar el registro seleccionado?",
				"Eliminar",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question);

			if (r == DialogResult.No)
				return;

			id_workGroup = id;

			bool result = DeleteCuadrilla();

			if (result)
			{
				MessageBox.Show("Cuadrilla eliminada correctamente");

				dgv.DeleteRowInDGV(id);
			}
			else
			{
				MessageBox.Show("No se pudo eliminar la cuadrilla");
			}
		}
		public void BtnAccept()
		{
			if (string.IsNullOrWhiteSpace(frmAdd.txbCuadrilla.Text))
			{
				MessageBox.Show("Debe capturar el nombre de la cuadrilla.");
				frmAdd.txbCuadrilla.Focus();
				return;
			}

			SetEntity();

			if (IsAddOrModify)
			{
				AddProcedure();

				if (IsAddUpdate)
				{
					BeginFormCat();
					frmAdd.Close();
				}
				else
				{
					MessageBox.Show("No se pudo agregar");
				}
			}
			else
			{
				ModifyProcedure();

				if (IsModifyUpdate)
				{
					BeginFormCat();
					frmAdd.Close();
				}
				else
				{
					MessageBox.Show("No se pudo modificar");
				}
			}
		}
		public void AddProcedure()
		{
			var result = AddCuadrilla();

			IsAddUpdate = result.Item1;
			idAddModify = result.Item2;
		}
		public void ModifyProcedure()
		{
			id_workGroup = idAddModify;

			IsModifyUpdate = UpdateCuadrilla();
		}
		private void SetEntity()
		{
			v_nameWorkGroup = frmAdd.txbCuadrilla.Text.Trim();
			c_active = frmAdd.chkActivo.Checked;

			c_order = string.IsNullOrWhiteSpace(frmAdd.txbOrden.Text)
				? null
				: frmAdd.txbOrden.Text.Trim().PadLeft(3, '0');
		}
		public void CargarDatosModificar()
		{
			try
			{
				string query = $@"
            SELECT 
                v_nameWorkGroup,
                c_active
            FROM Nom_WorkGroup
            WHERE id_workGroup = '{idAddModify}'";

				DataTable dt = ClsQuerysDB.GetDataTable(query);

				if (dt.Rows.Count == 0)
				{
					MessageBox.Show(
						"No se encontró la cuadrilla.",
						"Modificar Cuadrilla",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning
					);

					return;
				}

				DataRow row = dt.Rows[0];

				frmAdd.txbCuadrilla.Text =
					row["v_nameWorkGroup"].ToString();

				frmAdd.txbCuadrilla.ForeColor = System.Drawing.Color.Black;

				frmAdd.chkActivo.Checked =
					Convert.ToInt32(row["c_active"]) == 1;
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					ex.Message,
					"Cargar Cuadrilla",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);
			}
		}
		private void EstiloGrid()
		{
			DataGridView dgv = frm.dgvCuadrillas;

			// Configuración general
			dgv.ReadOnly = true;
			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToDeleteRows = false;
			dgv.AllowUserToResizeRows = false;
			dgv.RowHeadersVisible = false;

			dgv.SelectionMode =
				DataGridViewSelectionMode.FullRowSelect;

			dgv.MultiSelect = false;

			// Tamaño
			dgv.RowTemplate.Height = 32;
			dgv.ColumnHeadersHeight = 38;

			// Ajuste de columnas
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
					System.Drawing.FontStyle.Bold
				);

			dgv.ColumnHeadersDefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			// Filas
			dgv.DefaultCellStyle.Font =
				new System.Drawing.Font(
					"Segoe UI",
					9F
				);

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

			// Código
			dgv.Columns[0].FillWeight = 15;
			dgv.Columns[0].DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			// orden
			dgv.Columns[1].FillWeight = 15;
			dgv.Columns[1].DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			// Nombre de cuadrilla
			dgv.Columns[2].FillWeight = 35;

			// Estado
			dgv.Columns[3].FillWeight = 20;
			dgv.Columns[3].DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			// Fecha de creación
			dgv.Columns[4].FillWeight = 30;
			dgv.Columns[4].DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			// Formato de fecha
			dgv.Columns[4].DefaultCellStyle.Format =
				"dd/MM/yyyy";

			dgv.CellPainting += Dgv_CellPainting;
		}
		private void Dgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
		{
			DataGridView dgv = (DataGridView)sender;

			if (e.RowIndex < 0 || e.ColumnIndex != 3)
				return;

			if (e.Value == null)
				return;

			e.PaintBackground(e.CellBounds, true);

			string estado = e.Value.ToString();

			System.Drawing.Color colorPunto =
				estado == "Activa"
				? System.Drawing.Color.FromArgb(34, 177, 76)
				: System.Drawing.Color.FromArgb(220, 53, 69);

			using (var brush = new System.Drawing.SolidBrush(colorPunto))
			{
				int diametro = 8;

				int x = e.CellBounds.Left + 10;
				int y = e.CellBounds.Top +
						(e.CellBounds.Height - diametro) / 2;

				e.Graphics.FillEllipse(
					brush,
					x,
					y,
					diametro,
					diametro
				);
			}

			using (var brushTexto =
				new System.Drawing.SolidBrush(
					System.Drawing.Color.FromArgb(50, 50, 50)))
			{
				using (var font =
					new System.Drawing.Font("Segoe UI", 9F))
				{
					e.Graphics.DrawString(
						estado,
						font,
						brushTexto,
						e.CellBounds.Left + 25,
						e.CellBounds.Top +
						(e.CellBounds.Height - font.Height) / 2
					);
				}
			}

			e.Handled = true;
		}
	}
}
