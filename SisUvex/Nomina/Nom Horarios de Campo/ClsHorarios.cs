using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.SS.Formula.Functions;
using SisUvex.Nomina.NomCuadrillasCampo;
using SisUvex.Nomina.Reporte_de_horas;

namespace SisUvex.Nomina.Nom_Horarios_de_Campo
{
	public class ClsHorarios
	{

		public FrmHorarios frm;

		public void CargarGrupos()
		{
			DataTable dt = new DataTable();
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				using (SqlCommand cmd = new SqlCommand(
					"sp_GetWorkGroups",
					sql.cnn))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					using (SqlDataAdapter da =
						new SqlDataAdapter(cmd))
					{
						da.Fill(dt);
					}
				}

				sql.CloseConectionWrite();

				frm.cboGrupos.DataSource = dt;
				frm.cboGrupos.DisplayMember = "Grupo";
				frm.cboGrupos.ValueMember = "id_workGroup";

				frm.cboGrupos.SelectedIndex = -1;
			}
			catch (Exception ex)
			{
				try
				{
					sql.CloseConectionWrite();
				}
				catch
				{
				}

				MessageBox.Show(
					"Error al cargar los grupos.\n\n" + ex.Message,
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}
		public void CargarCuadrillasDisponibles()
		{
			DataTable dt = new DataTable();
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				using (SqlCommand cmd = new SqlCommand(
					"sp_GetWorkGroupsDisponibles",
					sql.cnn))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					using (SqlDataAdapter da =
						new SqlDataAdapter(cmd))
					{
						da.Fill(dt);
					}
				}

				sql.CloseConectionWrite();

				frm.dgvCuadrillaDisponible.DataSource = dt;
			}
			catch (Exception ex)
			{
				try
				{
					sql.CloseConectionWrite();
				}
				catch
				{
				}

				MessageBox.Show(
					"Error al cargar las cuadrillas disponibles.\n\n" + ex.Message,
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);
			}
		}
		public void ConfigurarDgvCuadrillaDisponible()
		{
			DataGridView dgv = frm.dgvCuadrillaDisponible;

			dgv.AutoGenerateColumns = true;
			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

			dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgv.MultiSelect = false;
			dgv.ReadOnly = true;

			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToDeleteRows = false;
			dgv.AllowUserToResizeRows = false;

			dgv.RowHeadersVisible = false;

			// Fuente
			dgv.Font = new Font("Segoe UI", 9F);

			// Encabezado
			dgv.EnableHeadersVisualStyles = false;

			dgv.ColumnHeadersDefaultCellStyle.BackColor =
				Color.FromArgb(18, 59, 114);

			dgv.ColumnHeadersDefaultCellStyle.ForeColor =
				Color.White;

			dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor =
				Color.FromArgb(18, 59, 114);

			dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor =
				Color.White;

			dgv.ColumnHeadersDefaultCellStyle.Font =
				new Font("Segoe UI", 9F, FontStyle.Bold);

			dgv.ColumnHeadersDefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			dgv.ColumnHeadersHeight = 35;

			// Celdas
			dgv.DefaultCellStyle.Font =
				new Font("Segoe UI", 9F);

			dgv.DefaultCellStyle.ForeColor =
				Color.FromArgb(40, 40, 40);

			dgv.DefaultCellStyle.BackColor =
				Color.White;

			dgv.DefaultCellStyle.SelectionBackColor =
				Color.FromArgb(30, 115, 190);

			dgv.DefaultCellStyle.SelectionForeColor =
				Color.White;

			dgv.DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			dgv.RowTemplate.Height = 30;

			// Líneas
			dgv.CellBorderStyle =
				DataGridViewCellBorderStyle.SingleHorizontal;

			dgv.GridColor =
				Color.FromArgb(220, 225, 230);

			dgv.BackgroundColor =
				Color.White;

			// Columnas
			if (dgv.Columns.Count >= 3)
			{
				dgv.Columns[0].FillWeight = 25;
				dgv.Columns[1].FillWeight = 100;
				dgv.Columns[2].FillWeight = 40;

				dgv.Columns[0].DefaultCellStyle.Alignment =
					DataGridViewContentAlignment.MiddleCenter;

				dgv.Columns[1].DefaultCellStyle.Alignment =
					DataGridViewContentAlignment.MiddleLeft;

				dgv.Columns[2].DefaultCellStyle.Alignment =
					DataGridViewContentAlignment.MiddleCenter;
			}
		}
		public void CargarCuadrillasAsignadas()
		{
			if (frm.cboGrupos.SelectedIndex == -1)
				return;

			DataTable dt = new DataTable();
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				using (SqlCommand cmd = new SqlCommand(
					"sp_GetCuadrillasAsignadas",
					sql.cnn))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue(
						"@id_workGroup",
						frm.cboGrupos.SelectedValue.ToString());

					using (SqlDataAdapter da =
						new SqlDataAdapter(cmd))
					{
						da.Fill(dt);
					}
				}

				sql.CloseConectionWrite();

				frm.dgvCuadrillaAsignada.DataSource = dt;
			}
			catch (Exception ex)
			{
				try
				{
					sql.CloseConectionWrite();
				}
				catch
				{
				}

				MessageBox.Show(
					"Error al cargar las cuadrillas asignadas.\n\n" + ex.Message,
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);
			}
		}
		public void ConfigurarDgvCuadrillaAsignada()
		{
			DataGridView dgv = frm.dgvCuadrillaAsignada;

			dgv.AutoGenerateColumns = true;
			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

			dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgv.MultiSelect = false;
			dgv.ReadOnly = true;

			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToDeleteRows = false;
			dgv.AllowUserToResizeRows = false;

			dgv.RowHeadersVisible = false;

			// Fuente
			dgv.Font = new Font("Segoe UI", 9F);

			// Encabezado
			dgv.EnableHeadersVisualStyles = false;

			dgv.ColumnHeadersDefaultCellStyle.BackColor =
				Color.FromArgb(18, 59, 114);

			dgv.ColumnHeadersDefaultCellStyle.ForeColor =
				Color.White;

			dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor =
				Color.FromArgb(18, 59, 114);

			dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor =
				Color.White;

			dgv.ColumnHeadersDefaultCellStyle.Font =
				new Font("Segoe UI", 9F, FontStyle.Bold);

			dgv.ColumnHeadersDefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			dgv.ColumnHeadersHeight = 35;

			// Celdas
			dgv.DefaultCellStyle.Font =
				new Font("Segoe UI", 9F);

			dgv.DefaultCellStyle.ForeColor =
				Color.FromArgb(40, 40, 40);

			dgv.DefaultCellStyle.BackColor =
				Color.White;

			dgv.DefaultCellStyle.SelectionBackColor =
				Color.FromArgb(30, 115, 190);

			dgv.DefaultCellStyle.SelectionForeColor =
				Color.White;

			dgv.DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			dgv.RowTemplate.Height = 30;

			// Líneas
			dgv.CellBorderStyle =
				DataGridViewCellBorderStyle.SingleHorizontal;

			dgv.GridColor =
				Color.FromArgb(220, 225, 230);

			dgv.BackgroundColor =
				Color.White;

			// Columnas
			if (dgv.Columns.Count >= 2)
			{
				dgv.Columns[0].FillWeight = 25;
				dgv.Columns[1].FillWeight = 100;

				dgv.Columns[0].DefaultCellStyle.Alignment =
					DataGridViewContentAlignment.MiddleCenter;

				dgv.Columns[1].DefaultCellStyle.Alignment =
					DataGridViewContentAlignment.MiddleLeft;
			}

			// Mantener encabezados azules aunque se seleccione una columna
			foreach (DataGridViewColumn columna in dgv.Columns)
			{
				columna.HeaderCell.Style.BackColor =
					Color.FromArgb(18, 59, 114);

				columna.HeaderCell.Style.ForeColor =
					Color.White;

				columna.HeaderCell.Style.SelectionBackColor =
					Color.FromArgb(18, 59, 114);

				columna.HeaderCell.Style.SelectionForeColor =
					Color.White;
			}
		}
		public void GuardarGrupo()
		{
			if (frm.cboGrupos.SelectedIndex == -1)
			{
				MessageBox.Show(
					"Seleccione un grupo de horario.",
					"Aviso",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return;
			}

			string idGrupo =
				frm.cboGrupos.SelectedValue.ToString();

			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				using (SqlTransaction transaccion =
					sql.cnn.BeginTransaction())
				{
					try
					{
						// Eliminar las asignaciones anteriores
						using (SqlCommand cmdDelete = new SqlCommand(
							@"DELETE FROM Cat_WorkGroupTeam
					  WHERE id_workGroup = @id_workGroup",
							sql.cnn,
							transaccion))
						{
							cmdDelete.Parameters.AddWithValue(
								"@id_workGroup",
								idGrupo);

							cmdDelete.ExecuteNonQuery();
						}

						// Guardar las cuadrillas que quedaron asignadas
						foreach (DataGridViewRow fila
							in frm.dgvCuadrillaAsignada.Rows)
						{
							if (fila.IsNewRow)
								continue;

							string idCuadrillaTexto =
								fila.Cells["ID"].Value?.ToString();

							if (string.IsNullOrWhiteSpace(idCuadrillaTexto))
								continue;

							int idCuadrilla =
								Convert.ToInt32(idCuadrillaTexto);

							using (SqlCommand cmdInsert = new SqlCommand(
								@"INSERT INTO Cat_WorkGroupTeam
						  (
							id_workGroup,
							id_workTeam,
							v_userCreate,
							d_create
						  )
						  VALUES
						  (
							@id_workGroup,
							@id_workTeam,
							@v_userCreate,
							GETDATE()
						  )",
								sql.cnn,
								transaccion))
							{
								cmdInsert.Parameters.AddWithValue(
									"@id_workGroup",
									idGrupo);

								cmdInsert.Parameters.AddWithValue(
									"@id_workTeam",
									idCuadrilla);

								cmdInsert.Parameters.AddWithValue(
									"@v_userCreate",
									User.GetUserName());

								cmdInsert.ExecuteNonQuery();
							}
						}

						transaccion.Commit();
					}
					catch
					{
						transaccion.Rollback();
						throw;
					}
				}

				sql.CloseConectionWrite();
				CargarCuadrillasDisponibles();
				CargarCuadrillasAsignadas();
				CargarHorarios();

				MessageBox.Show(
					"Grupo guardado correctamente.",
					"Información",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				try
				{
					sql.CloseConectionWrite();
				}
				catch
				{
				}

				MessageBox.Show(
					"Error al guardar el grupo.\n\n" + ex.Message,
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}
		public void CargarHorarios()
		{
			DataTable dt = new DataTable();
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				using (SqlCommand cmd = new SqlCommand(
					"sp_GetWorkGroupHorarios",
					sql.cnn))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					using (SqlDataAdapter da =
						new SqlDataAdapter(cmd))
					{
						da.Fill(dt);
					}
				}

				sql.CloseConectionWrite();

				frm.dgvHorarios.DataSource = dt;

				ConfigurarDgvHorarios();
			}
			catch (Exception ex)
			{
				try
				{
					sql.CloseConectionWrite();
				}
				catch
				{
				}

				MessageBox.Show(
					"Error al cargar los horarios.\n\n" + ex.Message,
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}
		public void ConfigurarDgvHorarios()
		{
			DataGridView dgv = frm.dgvHorarios;

			dgv.AutoGenerateColumns = true;
			dgv.AutoSizeColumnsMode =
				DataGridViewAutoSizeColumnsMode.Fill;

			dgv.SelectionMode =
				DataGridViewSelectionMode.FullRowSelect;

			dgv.MultiSelect = false;
			dgv.ReadOnly = true;

			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToDeleteRows = false;
			dgv.AllowUserToResizeRows = false;

			dgv.RowHeadersVisible = false;

			// Fuente
			dgv.Font = new Font("Segoe UI", 9F);

			// Encabezado
			dgv.EnableHeadersVisualStyles = false;

			dgv.ColumnHeadersDefaultCellStyle.BackColor =
				Color.FromArgb(18, 59, 114);

			dgv.ColumnHeadersDefaultCellStyle.ForeColor =
				Color.White;

			dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor =
				Color.FromArgb(18, 59, 114);

			dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor =
				Color.White;

			dgv.ColumnHeadersDefaultCellStyle.Font =
				new Font("Segoe UI", 9F, FontStyle.Bold);

			dgv.ColumnHeadersDefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			dgv.ColumnHeadersHeight = 35;

			// Celdas
			dgv.DefaultCellStyle.Font =
				new Font("Segoe UI", 9F);

			dgv.DefaultCellStyle.ForeColor =
				Color.FromArgb(40, 40, 40);

			dgv.DefaultCellStyle.BackColor =
				Color.White;

			dgv.DefaultCellStyle.SelectionBackColor =
				Color.FromArgb(30, 115, 190);

			dgv.DefaultCellStyle.SelectionForeColor =
				Color.White;

			dgv.DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			dgv.RowTemplate.Height = 30;

			// Líneas
			dgv.CellBorderStyle =
				DataGridViewCellBorderStyle.SingleHorizontal;

			dgv.GridColor =
				Color.FromArgb(220, 225, 230);

			dgv.BackgroundColor =
				Color.White;

			// Columnas
			if (dgv.Columns.Count >= 6)
			{
				dgv.Columns[0].FillWeight = 110;
				dgv.Columns[1].FillWeight = 70;
				dgv.Columns[2].FillWeight = 130;
				dgv.Columns[3].FillWeight = 80;
				dgv.Columns[4].FillWeight = 80;
				dgv.Columns[5].FillWeight = 80;

				dgv.Columns[0].DefaultCellStyle.Alignment =
					DataGridViewContentAlignment.MiddleLeft;

				dgv.Columns[1].DefaultCellStyle.Alignment =
					DataGridViewContentAlignment.MiddleCenter;

				dgv.Columns[2].DefaultCellStyle.Alignment =
					DataGridViewContentAlignment.MiddleLeft;

				dgv.Columns[3].DefaultCellStyle.Alignment =
					DataGridViewContentAlignment.MiddleCenter;

				dgv.Columns[4].DefaultCellStyle.Alignment =
					DataGridViewContentAlignment.MiddleCenter;

				dgv.Columns[5].DefaultCellStyle.Alignment =
					DataGridViewContentAlignment.MiddleCenter;
			}

			// Encabezados siempre azules
			foreach (DataGridViewColumn columna in dgv.Columns)
			{
				columna.HeaderCell.Style.BackColor =
					Color.FromArgb(18, 59, 114);

				columna.HeaderCell.Style.ForeColor =
					Color.White;

				columna.HeaderCell.Style.SelectionBackColor =
					Color.FromArgb(18, 59, 114);

				columna.HeaderCell.Style.SelectionForeColor =
					Color.White;
			}
		}
	}
}