using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Wordprocessing;
using SisUvex.Catalogos.Metods.DataGridViews;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Nomina.Conceptos_Ingresos_Diversos;

namespace SisUvex.Nomina.Cat_Departamentos
{
	public class ClsDepartamento
	{
		public FrmAgregar frmAdd;
		public FrmDepartamento frm;
		public bool IsAddOrModify = true, IsAddUpdate = false, IsModifyUpdate = false;
		public string idAddModify;
		DataTable dtDepartamento;
		ClsDGVCatalog? dgv;
		public string id_department { get; set; }
		public string c_code { get; set; }
		public string c_name { get; set; }
		public bool b_active { get; set; }
		public string queryCatalog = @"
			SELECT 
				id_department AS [Código],
				c_code AS [Nombre Corto],
				c_name AS [Nombre de departamento],
				CASE 
					WHEN b_active = 1 THEN 'Activa'
					ELSE 'Inactiva'
				END AS [Estado],
				d_create AS [Fecha]
				FROM Cat_Departament";
		public void OpenFrmAdd()
		{
			IsAddOrModify = true;
			idAddModify = null;

			frmAdd = new();
			frmAdd.cls = this;

			frmAdd.Text = "AGREGAR DEPARTAMENTO ";
			frmAdd.lblTitulo.Text = "AGREGAR DEPARTAMENTO ";
			frmAdd.lblSubtitulo.Text = "Capture la informacion del nuevo departamento.";
			frmAdd.ShowDialog();
		}
		public void OpenFrmModify(string id)
		{
			if (string.IsNullOrEmpty(id))
			{
				MessageBox.Show("Selecciona un departamento");
				return;
			}

			IsAddOrModify = false;
			idAddModify = id;

			frmAdd = new();
			frmAdd.cls = this;

			frmAdd.Text = "MODIFICAR DEPARTAMENTO ";
			frmAdd.lblTitulo.Text = "MODIFICAR DEPARTAMENTO ";
			frmAdd.lblSubtitulo.Text = "Modifique la información del departamento.";

			frmAdd.ShowDialog();
		}
		public void AddNewRowByIdInDGVCatalog()
		{
			DataTable newIdRow = ClsQuerysDB.GetDataTable(queryCatalog + $" WHERE [id_department] = '{idAddModify}'"
			);


			dgv.AddNewRowToDGV(newIdRow);
		}
		public void BeginFormCat()
		{
			dtDepartamento = ClsQuerysDB.GetDataTable(
				queryCatalog + @"
				ORDER BY id_department"
			);

			dgv = new ClsDGVCatalog(frm.dgvDepartamento, dtDepartamento);

			EstiloGrid();
		}
		public void ModifyRowByIdInDGVCatalog()
		{
			DataTable newIdRow = ClsQuerysDB.GetDataTable(
				queryCatalog + $" WHERE [id_department] = '{idAddModify}'"
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
				"¿Desea eliminar el departamento seleccionado?",
				"Eliminar",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question);

			if (r == DialogResult.No)
				return;

			id_department = id;

			bool result = DeleteDepartamento();

			if (result)
			{
				MessageBox.Show("Departamento eliminado correctamente");

				dgv.DeleteRowInDGV(id);
			}
			else
			{
				MessageBox.Show("No se pudo eliminar el departamento");
			}
		}
		public bool DeleteDepartamento()
		{
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				using (SqlCommand cmd = new SqlCommand("sp_DeleteCatDepartament", sql.cnn))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@id_department", SqlDbType.Char, 3).Value = id_department;
					cmd.Parameters.Add("@userUpdate", SqlDbType.VarChar).Value = User.GetUserName();

					cmd.ExecuteNonQuery();

					return true;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Eliminar Departamento");
				return false;
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}
		public void AddProcedure()
		{
			var result = AddDepartamento();

			IsAddUpdate = result.Item1;
			idAddModify = result.Item2;
		}
		public void ModifyProcedure()
		{
			id_department = idAddModify;

			IsModifyUpdate = UpdateDepartamento();
		}
		public void BtnAccept()
		{
			if (string.IsNullOrWhiteSpace(frmAdd.txbDepartamento.Text))
			{
				MessageBox.Show("Debe capturar el nombre del departamento.");
				frmAdd.txbDepartamento.Focus();
				return;
			}

			SetEntity();

			if (IsAddOrModify)
			{
				AddProcedure();

				if (IsAddUpdate)
				{
					frmAdd.Close();
				}
				else
				{
					MessageBox.Show("No se pudo agregar el departamento");
				}
			}
			else
			{
				ModifyProcedure();

				if (IsModifyUpdate)
				{
					frmAdd.Close();
				}
				else
				{
					MessageBox.Show("No se pudo modificar el departamento");
				}
			}
		}
		private void SetEntity()
		{
			c_name = frmAdd.txbDepartamento.Text.Trim();

			c_code = frmAdd.txbCorto.Text.Trim();

			b_active = frmAdd.chkActivo.Checked;
		}
		public (bool, string?) AddDepartamento()
		{
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				using (SqlCommand cmd = new SqlCommand(
					"sp_AddCatDepartament", sql.cnn))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@c_code", SqlDbType.VarChar, 20)
						.Value = c_code;

					cmd.Parameters.Add("@c_name", SqlDbType.VarChar, 100)
						.Value = c_name;

					cmd.Parameters.Add("@b_active", SqlDbType.Bit)
						.Value = b_active;

					cmd.Parameters.Add("@userCreate", SqlDbType.VarChar)
						.Value = User.GetUserName();

					object result = cmd.ExecuteScalar();

					if (result != null)
					{
						id_department = result.ToString();

						return (true, id_department);
					}

					return (false, null);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					ex.Message,
					"Agregar Departamento");

				return (false, null);
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}
		public bool UpdateDepartamento()
		{
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				using (SqlCommand cmd = new SqlCommand(
					"sp_UpdateCatDepartament", sql.cnn))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@id_department", SqlDbType.Char, 3)
						.Value = id_department;

					cmd.Parameters.Add("@c_code", SqlDbType.VarChar, 20)
						.Value = c_code;

					cmd.Parameters.Add("@c_name", SqlDbType.VarChar, 100)
						.Value = c_name;

					cmd.Parameters.Add("@b_active", SqlDbType.Bit)
						.Value = b_active;

					cmd.Parameters.Add("@userUpdate", SqlDbType.VarChar)
						.Value = User.GetUserName();

					cmd.ExecuteNonQuery();

					return true;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					ex.Message,
					"Modificar Departamento");

				return false;
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}
		public void CargarDatosModificar()
		{
			try
			{
				string query = $@"
        SELECT 
            c_code,
            c_name,
            b_active
        FROM Cat_Departament
        WHERE id_department = '{idAddModify}'";

				DataTable dt = ClsQuerysDB.GetDataTable(query);

				if (dt.Rows.Count == 0)
				{
					MessageBox.Show(
						"No se encontró el departamento.",
						"Modificar Departamento",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning
					);

					return;
				}

				DataRow row = dt.Rows[0];

				frmAdd.txbDepartamento.Text =
					row["c_name"].ToString();

				frmAdd.txbDepartamento.ForeColor =
					System.Drawing.Color.Black;

				frmAdd.txbCorto.Text =
					row["c_code"].ToString();

				frmAdd.txbCorto.ForeColor =
					System.Drawing.Color.Black;

				frmAdd.chkActivo.Checked =
					Convert.ToInt32(row["b_active"]) == 1;
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					ex.Message,
					"Cargar Departamento",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);
			}
		}
		private void EstiloGrid()
		{
			DataGridView dgv = frm.dgvDepartamento;

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

			// Nombre corto
			dgv.Columns[1].FillWeight = 20;
			dgv.Columns[1].DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			// Nombre de departamento
			dgv.Columns[2].FillWeight = 35;

			// Estado
			dgv.Columns[3].FillWeight = 15;
			dgv.Columns[3].DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			// Fecha de creación
			dgv.Columns[4].FillWeight = 15;
			dgv.Columns[4].DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			// Formato de fecha
			dgv.Columns[4].DefaultCellStyle.Format =
				"dd/MM/yyyy";

			dgv.CellPainting += DgvDepartamento_CellPainting;
		}
		private void DgvDepartamento_CellPainting(
	object sender,
	DataGridViewCellPaintingEventArgs e)
		{
			DataGridView dgv = (DataGridView)sender;

			// La columna Estado es la 3
			if (e.RowIndex < 0 || e.ColumnIndex != 3)
				return;

			if (e.Value == null)
				return;

			e.PaintBackground(e.CellBounds, true);

			string estado = e.Value.ToString().Trim();

			System.Drawing.Color colorPunto =
				estado == "Activa"
				? System.Drawing.Color.FromArgb(34, 177, 76)
				: System.Drawing.Color.FromArgb(220, 53, 69);

			// Punto de estado
			using (var brush =
				new System.Drawing.SolidBrush(colorPunto))
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

			// Texto del estado
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
