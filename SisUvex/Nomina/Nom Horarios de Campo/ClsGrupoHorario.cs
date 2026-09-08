using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SisUvex.Nomina.Nom_Horarios_de_Campo
{
	public class ClsGrupoHorario
	{
		public FrmHorarios frm;
		private string idGrupoModificar = "";
		public void GuardarHorario()
		{
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				using (SqlCommand cmd = new SqlCommand(
					"sp_Insert_WorkGroup",
					sql.cnn))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue(
						"@workGroupName",
						frm.txbNombre.Text.Trim());

					cmd.Parameters.AddWithValue(
						"@entryTime",
						frm.dtpHoraEntrada.Value.TimeOfDay);

					cmd.Parameters.AddWithValue(
						"@entryMinutesBefore",
						Convert.ToInt32(frm.nudAntesEntrada.Value));

					cmd.Parameters.AddWithValue(
						"@entryMinutesAfter",
						Convert.ToInt32(frm.nudDespuesEntrada.Value));

					cmd.Parameters.AddWithValue(
						"@exitTime",
						frm.dtpHoraSalida.Value.TimeOfDay);

					cmd.Parameters.AddWithValue(
						"@exitMinutesBefore",
						Convert.ToInt32(frm.nudSalidaAntes.Value));

					cmd.Parameters.AddWithValue(
						"@exitMinutesAfter",
						Convert.ToInt32(frm.nudSalidaDespues.Value));

					cmd.Parameters.AddWithValue(
						"@active",
						frm.ckbActivo.Checked);

					cmd.Parameters.AddWithValue(
						"@v_userCreate",
						User.GetUserName());

					cmd.ExecuteNonQuery();
				}

				sql.CloseConectionWrite();

				// Actualizar la DGV
				CargarDgvGrupo();
				DeshabilitarCampos();

				MessageBox.Show(
					"Horario guardado correctamente.",
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
					"Error al guardar el horario.\n\n" + ex.Message,
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}
		public void AñadirHorario()
		{
			frm.txbNombre.Clear();

			frm.dtpHoraEntrada.Value = DateTime.Today;
			frm.nudAntesEntrada.Value = 0;
			frm.nudDespuesEntrada.Value = 0;

			frm.dtpHoraSalida.Value = DateTime.Today;
			frm.nudSalidaAntes.Value = 0;
			frm.nudSalidaDespues.Value = 0;

			frm.ckbActivo.Checked = true;

			frm.txbNombre.Enabled = true;

			frm.dtpHoraEntrada.Enabled = true;
			frm.nudAntesEntrada.Enabled = true;
			frm.nudDespuesEntrada.Enabled = true;

			frm.dtpHoraSalida.Enabled = true;
			frm.nudSalidaAntes.Enabled = true;
			frm.nudSalidaDespues.Enabled = true;

			frm.ckbActivo.Enabled = true;

			frm.btnGuardar.Enabled = true;
			frm.btnCancelar.Enabled = true;

			frm.txbNombre.Focus();
		}
		public void DeshabilitarCampos()
		{
			frm.txbNombre.Enabled = false;

			frm.dtpHoraEntrada.Enabled = false;
			frm.nudAntesEntrada.Enabled = false;
			frm.nudDespuesEntrada.Enabled = false;

			frm.dtpHoraSalida.Enabled = false;
			frm.nudSalidaAntes.Enabled = false;
			frm.nudSalidaDespues.Enabled = false;

			frm.ckbActivo.Enabled = false;

			frm.btnGuardar.Enabled = false;
			frm.btnCancelar.Enabled = false;
		}
		public void CargarDgvGrupo()
		{
			DataTable dt = new DataTable();
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				using (SqlCommand cmd = new SqlCommand(
					"sp_GetDgvGrupos",
					sql.cnn))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					using (SqlDataAdapter da = new SqlDataAdapter(cmd))
					{
						da.Fill(dt);
					}
				}

				sql.CloseConectionWrite();

				frm.dgvGrupo.DataSource = dt;

				ConfigurarDgvGrupo();
			}
			catch (Exception ex)
			{
				try { sql.CloseConectionWrite(); } catch { }

				MessageBox.Show(
					"Error al cargar los grupos.\n\n" + ex.Message,
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}
		public bool ValidarHorario()
		{
			if (string.IsNullOrWhiteSpace(frm.txbNombre.Text))
			{
				MessageBox.Show(
					"Debe ingresar el nombre del grupo.",
					"Datos incompletos",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				frm.txbNombre.Focus();
				return false;
			}

			if (frm.nudAntesEntrada.Value < 0)
			{
				MessageBox.Show(
					"Debe ingresar los minutos antes de entrada.",
					"Datos incompletos",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				frm.nudAntesEntrada.Focus();
				return false;
			}

			if (frm.nudDespuesEntrada.Value < 0)
			{
				MessageBox.Show(
					"Debe ingresar los minutos después de entrada.",
					"Datos incompletos",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				frm.nudDespuesEntrada.Focus();
				return false;
			}

			if (frm.nudSalidaAntes.Value < 0)
			{
				MessageBox.Show(
					"Debe ingresar los minutos antes de salida.",
					"Datos incompletos",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				frm.nudSalidaAntes.Focus();
				return false;
			}

			if (frm.nudSalidaDespues.Value < 0)
			{
				MessageBox.Show(
					"Debe ingresar los minutos después de salida.",
					"Datos incompletos",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				frm.nudSalidaDespues.Focus();
				return false;
			}

			return true;
		}
		public void ConfigurarDgvGrupo()
		{
			DataGridView dgv = frm.dgvGrupo;

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
			frm.dgvGrupo.CellPainting += DgvGrupo_CellPainting;
		}
		private void DgvGrupo_CellPainting(
	object sender,
	DataGridViewCellPaintingEventArgs e)
		{
			if (e.RowIndex < 0)
				return;

			if (frm.dgvGrupo.Columns[e.ColumnIndex].Name != "Estado")
				return;

			if (e.Value == null)
				return;

			string estado = e.Value.ToString().Trim();

			if (estado != "Activo")
				return;

			// Pintar fondo y bordes normales
			e.PaintBackground(e.CellBounds, true);
			e.Paint(
				e.CellBounds,
				DataGridViewPaintParts.Border);

			// Punto verde
			using (Brush brochaVerde =
				new SolidBrush(Color.Green))
			{
				e.Graphics.DrawString(
					"●",
					new Font(
						"Segoe UI",
						10F,
						FontStyle.Bold),
					brochaVerde,
					e.CellBounds.X + 15,
					e.CellBounds.Y + 5);
			}

			// Texto negro
			using (Brush brochaNegra =
				new SolidBrush(Color.Black))
			{
				e.Graphics.DrawString(
					"Activo",
					new Font(
						"Segoe UI",
						9F,
						FontStyle.Bold),
					brochaNegra,
					e.CellBounds.X + 35,
					e.CellBounds.Y + 6);
			}

			e.Handled = true;
		}
		public void CargarDatosGrupo()
		{
			if (frm.dgvGrupo.CurrentRow == null)
				return;

			string idGrupo =
			frm.dgvGrupo.CurrentRow.Cells[0].Value?.ToString();

			if (string.IsNullOrWhiteSpace(idGrupo))
				return;

			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				using (SqlCommand cmd = new SqlCommand(
					"sp_GetWorkGroupById",
					sql.cnn))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue(
						"@id_workGroup",
						idGrupo);

					using (SqlDataReader dr = cmd.ExecuteReader())
					{
						if (dr.Read())
						{
							frm.txbNombre.Text =
								dr["workGroupName"].ToString();

							frm.dtpHoraEntrada.Value =
								DateTime.Today.Add(
									(TimeSpan)dr["entryTime"]);

							frm.nudAntesEntrada.Value =
								Convert.ToDecimal(
									dr["entryMinutesBefore"]);

							frm.nudDespuesEntrada.Value =
								Convert.ToDecimal(
									dr["entryMinutesAfter"]);

							frm.dtpHoraSalida.Value =
								DateTime.Today.Add(
									(TimeSpan)dr["exitTime"]);

							frm.nudSalidaAntes.Value =
								Convert.ToDecimal(
									dr["exitMinutesBefore"]);

							frm.nudSalidaDespues.Value =
								Convert.ToDecimal(
									dr["exitMinutesAfter"]);

							frm.ckbActivo.Checked =
								Convert.ToBoolean(dr["active"]);
						}
					}
				}

				sql.CloseConectionWrite();
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
					"Error al cargar los datos del grupo.\n\n" + ex.Message,
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}
		public void ModificarHorario()
		{
			if (frm.dgvGrupo.CurrentRow == null)
			{
				MessageBox.Show(
					"Seleccione un grupo de horario.",
					"Aviso",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return;
			}

			string idGrupo =
				frm.dgvGrupo.CurrentRow.Cells["ID"].Value?.ToString();

			if (string.IsNullOrWhiteSpace(idGrupo))
				return;

			// Guardamos el ID que se va a modificar
			idGrupoModificar = idGrupo;

			// Habilitar campos
			frm.txbNombre.Enabled = true;

			frm.dtpHoraEntrada.Enabled = true;
			frm.nudAntesEntrada.Enabled = true;
			frm.nudDespuesEntrada.Enabled = true;

			frm.dtpHoraSalida.Enabled = true;
			frm.nudSalidaAntes.Enabled = true;
			frm.nudSalidaDespues.Enabled = true;

			frm.ckbActivo.Enabled = true;

			frm.btnGuardar.Enabled = true;
			frm.btnCancelar.Enabled = true;

			frm.txbNombre.Focus();
		}
		public void ActualizarHorario()
		{
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				using (SqlCommand cmd = new SqlCommand(
					"sp_Update_WorkGroup",
					sql.cnn))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue(
						"@id_workGroup",
						idGrupoModificar);

					cmd.Parameters.AddWithValue(
						"@workGroupName",
						frm.txbNombre.Text.Trim());

					cmd.Parameters.AddWithValue(
						"@entryTime",
						frm.dtpHoraEntrada.Value.TimeOfDay);

					cmd.Parameters.AddWithValue(
						"@entryMinutesBefore",
						Convert.ToInt32(frm.nudAntesEntrada.Value));

					cmd.Parameters.AddWithValue(
						"@entryMinutesAfter",
						Convert.ToInt32(frm.nudDespuesEntrada.Value));

					cmd.Parameters.AddWithValue(
						"@exitTime",
						frm.dtpHoraSalida.Value.TimeOfDay);

					cmd.Parameters.AddWithValue(
						"@exitMinutesBefore",
						Convert.ToInt32(frm.nudSalidaAntes.Value));

					cmd.Parameters.AddWithValue(
						"@exitMinutesAfter",
						Convert.ToInt32(frm.nudSalidaDespues.Value));

					cmd.Parameters.AddWithValue(
						"@active",
						frm.ckbActivo.Checked);

					cmd.Parameters.AddWithValue(
						"@v_userUpdate",
						User.GetUserName());

					cmd.ExecuteNonQuery();
				}

				sql.CloseConectionWrite();

				// Actualizar la DGV
				CargarDgvGrupo();

				// Deshabilitar nuevamente
				DeshabilitarCampos();

				MessageBox.Show(
					"Horario modificado correctamente.",
					"Información",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				idGrupoModificar = "";
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
					"Error al modificar el horario.\n\n" + ex.Message,
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}
		public void CancelarHorario()
		{
			idGrupoModificar = "";
			frm.modificando = false;

			DeshabilitarCampos();
		}
		public void EliminarHorario()
		{
			if (frm.dgvGrupo.CurrentRow == null)
			{
				MessageBox.Show(
					"Seleccione un grupo de horario.",
					"Aviso",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return;
			}

			string idGrupo =
				frm.dgvGrupo.CurrentRow.Cells["ID"].Value?
				.ToString()
				.Trim();

			string nombreGrupo =
				frm.dgvGrupo.CurrentRow.Cells["Nombre del grupo"].Value?
				.ToString()
				.Trim();

			if (string.IsNullOrWhiteSpace(idGrupo))
				return;

			DialogResult resultado = MessageBox.Show(
				"¿Está seguro de eliminar el grupo de horario \"" +
				nombreGrupo + "\"?",
				"Confirmar eliminación",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question);

			if (resultado != DialogResult.Yes)
				return;

			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				using (SqlCommand cmd = new SqlCommand(
					"dbo.sp_Delete_WorkGroup",
					sql.cnn))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add(
						"@id_workGroup",
						SqlDbType.Char,
						3).Value = idGrupo;

					cmd.Parameters.Add(
						"@v_userUpdate",
						SqlDbType.VarChar,
						50).Value = User.GetUserName();

					cmd.ExecuteNonQuery();
				}

				sql.CloseConectionWrite();

				// Actualizar dgvGrupo
				CargarDgvGrupo();

				// Limpiar y deshabilitar los campos
				DeshabilitarCampos();

				MessageBox.Show(
					"Grupo de horario eliminado correctamente.",
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
					"Error al eliminar el grupo de horario.\n\n" +
					ex.Message,
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}
	}
}