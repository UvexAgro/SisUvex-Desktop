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
		public FrmAgregar frmA;

		public void OpenFrmAdd()
		{
			frmA = new FrmAgregar(frm, this);

			frmA.lblTitle.Text = "Añadir horario";
			frmA.lblSubtitulo.Text =
				"Define el horario y asígnalo a una o varias cuadrillas.";

			// AGREGAR
			frmA.IsAddOrModify = true;

			frmA.ShowDialog();

			CargarHorarios();
		}
		public void OpenFrmModify()
		{
			if (frm.dgvHorarios.CurrentRow == null)
			{
				MessageBox.Show(
					"Seleccione un horario para modificar.",
					"Aviso",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning
				);

				return;
			}

			int idHorario = Convert.ToInt32(
				frm.dgvHorarios.CurrentRow
					.Cells["id_workGroupHorario"]
					.Value
			);

			frmA = new FrmAgregar(frm, this);

			frmA.lblTitle.Text = "Modificar horario";
			frmA.lblSubtitulo.Text =
				"Modifica el horario asignado a la cuadrilla.";

			// MUY IMPORTANTE
			frmA.IsAddOrModify = false;

			// Guardar el ID que se va a modificar
			frmA.idAddModify = idHorario.ToString();

			// Cargar los datos actuales
			CargarHorarioModificar(idHorario);

			frmA.ShowDialog();

			CargarHorarios();
		}

		public void CargarHorarioModificar(int idHorario)
		{
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				string query = @"
			SELECT
				id_workGroupHorario,
				id_workGroup,
				d_fechaInicio,
				d_fechaFin,
				t_horaEntrada,
				t_horaSalida,
				b_cruzaMedianoche
			FROM dbo.Nom_WorkGroupHorario
			WHERE id_workGroupHorario = @idHorario";

				using (SqlCommand cmd = new SqlCommand(query, sql.cnn))
				{
					cmd.Parameters.Add("@idHorario", SqlDbType.Int)
						.Value = idHorario;

					using (SqlDataReader dr = cmd.ExecuteReader())
					{
						if (dr.Read())
						{
							// =========================
							// CUADRILLA
							// =========================

							string idCuadrilla =
								dr["id_workGroup"].ToString().Trim();


							// =========================
							// FECHA INICIO
							// =========================

							frmA.dtpFechaInicio.Value =
								Convert.ToDateTime(dr["d_fechaInicio"]);

							// =========================
							// FECHA FIN
							// =========================

							frmA.dtpFechaFin.ShowCheckBox = true;

							// Habilitar porque estamos modificando
							frmA.dtpFechaFin.Enabled = true;
							frmA.dtpFechaFin.Enabled = true;

							if (dr["d_fechaFin"] == DBNull.Value)
							{
								// No tiene fecha final
								frmA.dtpFechaFin.Checked = false;
							}
							else
							{
								// Sí tiene fecha final
								frmA.dtpFechaFin.Checked = true;

								frmA.dtpFechaFin.Value =
									Convert.ToDateTime(dr["d_fechaFin"]);
							}


							// =========================
							// HORA ENTRADA
							// =========================

							TimeSpan horaEntrada =
								(TimeSpan)dr["t_horaEntrada"];

							frmA.dtpEntrada.Value =
								DateTime.Today.Add(horaEntrada);


							// =========================
							// HORA SALIDA
							// =========================

							TimeSpan horaSalida =
								(TimeSpan)dr["t_horaSalida"];

							frmA.dtpSalida.Value =
								DateTime.Today.Add(horaSalida);


							// =========================
							// CRUZA MEDIANOCHE
							// =========================

							frmA.chkCruce.Checked =
								Convert.ToBoolean(
									dr["b_cruzaMedianoche"]
								);


							// =========================
							// SELECCIONAR CUADRILLA
							// =========================

							for (int i = 0;
								 i < frmA.clbCuadrilla.Items.Count;
								 i++)
							{
								WorkGroupItem item =
									(WorkGroupItem)frmA.clbCuadrilla.Items[i];

								if (item.Id == idCuadrilla)
								{
									frmA.clbCuadrilla.SetItemChecked(i, true);
									break;
								}
							}
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
					"Error al cargar el horario.\n\n" + ex.Message,
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);
			}
		}
		public class WorkGroupItem
		{
			public string Id { get; set; }
			public string Nombre { get; set; }

			public override string ToString()
			{
				return $"{Id} - {Nombre}";
			}
		}

		public DataTable Cuadrillas()
		{
			DataTable dt = new DataTable();
			SQLControl sql = new SQLControl();

			try
			{
				string query = @"
            SELECT
                id_workGroup,
                v_nameWorkGroup
            FROM dbo.Nom_WorkGroup
            WHERE c_active = 1
            ORDER BY id_workGroup";

				sql.OpenConectionWrite();

				using (SqlCommand cmd = new SqlCommand(query, sql.cnn))
				using (SqlDataAdapter da = new SqlDataAdapter(cmd))
				{
					da.Fill(dt);
				}

				sql.CloseConectionWrite();

				return dt;
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
					"Error al cargar las cuadrillas.\n\n" + ex.Message,
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);

				return null;
			}
		}
		public void CargarCuadrillas()
		{
			DataTable dt = Cuadrillas();

			if (dt == null)
				return;

			frmA.clbCuadrilla.Items.Clear();

			foreach (DataRow row in dt.Rows)
			{
				ClsHorarios.WorkGroupItem cuadrilla =
					new ClsHorarios.WorkGroupItem
					{
						Id = row["id_workGroup"].ToString().Trim(),
						Nombre = row["v_nameWorkGroup"].ToString().Trim()
					};

				frmA.clbCuadrilla.Items.Add(cuadrilla, false);
			}
		}
		public bool GuardarHorario(string idsCuadrillas, DateTime fechaInicio, DateTime? fechaFin,TimeSpan horaEntrada,TimeSpan horaSalida,bool cruzaMedianoche,string userCreate)
		{
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				using (SqlCommand cmd = new SqlCommand(
					"sp_AddWorkGroupHorario",
					sql.cnn))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@id_workGroups", SqlDbType.VarChar).Value =
						idsCuadrillas;

					cmd.Parameters.Add("@fechaInicio", SqlDbType.Date).Value =
						fechaInicio.Date;

					cmd.Parameters.Add("@fechaFin", SqlDbType.Date).Value =
						fechaFin.HasValue
							? (object)fechaFin.Value.Date
							: DBNull.Value;

					cmd.Parameters.Add("@horaEntrada", SqlDbType.Time).Value =
						horaEntrada;

					cmd.Parameters.Add("@horaSalida", SqlDbType.Time).Value =
						horaSalida;

					cmd.Parameters.Add("@cruzaMedianoche", SqlDbType.Bit).Value =
						cruzaMedianoche;

					cmd.Parameters.Add("@userCreate", SqlDbType.VarChar).Value =
						userCreate;

					cmd.ExecuteNonQuery();
				}

				sql.CloseConectionWrite();

				return true;
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
					MessageBoxIcon.Error
				);

				return false;
			}
		}
		public bool ValidarHorarioAbierto(List<string> cuadrillas, out string cuadrillasBloqueadas)
		{
			cuadrillasBloqueadas = "";

			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				string ids = string.Join(",", cuadrillas);

				string query = @"
            SELECT id_workGroup
            FROM dbo.Nom_WorkGroupHorario
            WHERE id_workGroup IN
            (
                SELECT LTRIM(RTRIM(value))
                FROM STRING_SPLIT(@idsCuadrillas, ',')
            )
            AND d_fechaFin IS NULL
            AND active = 1;
        ";

				List<string> bloqueadas = new List<string>();

				using (SqlCommand cmd = new SqlCommand(query, sql.cnn))
				{
					cmd.Parameters.Add("@idsCuadrillas", SqlDbType.VarChar).Value = ids;

					using (SqlDataReader dr = cmd.ExecuteReader())
					{
						while (dr.Read())
						{
							bloqueadas.Add(
								dr["id_workGroup"].ToString().Trim()
							);
						}
					}
				}

				sql.CloseConectionWrite();

				if (bloqueadas.Count > 0)
				{
					cuadrillasBloqueadas = string.Join(", ", bloqueadas);
					return false;
				}

				return true;
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
					"Error al validar los horarios.\n\n" + ex.Message,
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);

				return false;
			}
		}
		public void Guardar()
		{
			// Validar que haya al menos una cuadrilla
			if (frmA.clbCuadrilla.CheckedItems.Count == 0)
			{
				MessageBox.Show(
					"Debe seleccionar al menos una cuadrilla.",
					"Aviso",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning
				);

				return;
			}

			// Obtener las cuadrillas seleccionadas
			List<string> cuadrillas = new List<string>();

			foreach (var item in frmA.clbCuadrilla.CheckedItems)
			{
				ClsHorarios.WorkGroupItem cuadrilla =
					(ClsHorarios.WorkGroupItem)item;

				cuadrillas.Add(cuadrilla.Id);
			}

			string idsCuadrillas = string.Join(",", cuadrillas);

			// ========================================
			// VALIDAR HORARIO ABIERTO
			// ========================================

			string cuadrillasBloqueadas;

			if (frmA.IsAddOrModify)
			{
				// SOLO AL AGREGAR
				if (!ValidarHorarioAbierto(
					cuadrillas,
					out cuadrillasBloqueadas))
				{
					MessageBox.Show(
						"Las siguientes cuadrillas ya tienen un horario abierto:\n\n" +
						cuadrillasBloqueadas +
						"\n\nDebe cerrar el horario actual antes de agregar uno nuevo.",
						"Horario existente",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning
					);

					return;
				}
			}
			else
			{
				// AL MODIFICAR NO VALIDAMOS AQUÍ,
				// porque el horario actual ya está abierto.
			}

			// ========================================
			// FECHA DE INICIO
			// ========================================

			DateTime fechaInicio =
				frmA.dtpFechaInicio.Value.Date;

			// ========================================
			// FECHA DE FIN
			// ========================================

			DateTime? fechaFin = null;

			if (frmA.dtpFechaFin.Checked)
			{
				fechaFin = frmA.dtpFechaFin.Value.Date;

				if (fechaFin < fechaInicio)
				{
					MessageBox.Show(
						"La fecha final no puede ser menor que la fecha de inicio.",
						"Aviso",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning
					);

					return;
				}
			}

			// ========================================
			// HORAS
			// ========================================

			TimeSpan horaEntrada =
				frmA.dtpEntrada.Value.TimeOfDay;

			TimeSpan horaSalida =
				frmA.dtpSalida.Value.TimeOfDay;

			// ========================================
			// CRUZA MEDIANOCHE
			// ========================================

			bool cruzaMedianoche =
				frmA.chkCruce.Checked;

			// ========================================
			// USUARIO
			// ========================================

			string usuario =
				User.GetUserName();

			// ========================================
			// AGREGAR O MODIFICAR
			// ========================================

			bool guardado;

			if (frmA.IsAddOrModify)
			{
				// AGREGAR
				guardado = GuardarHorario(
					idsCuadrillas,
					fechaInicio,
					fechaFin,
					horaEntrada,
					horaSalida,
					cruzaMedianoche,
					usuario
				);
			}
			else
			{
				// MODIFICAR
				int idHorario =
					Convert.ToInt32(frmA.idAddModify);

				guardado = ModificarHorario(
					idHorario,
					fechaInicio,
					fechaFin,
					horaEntrada,
					horaSalida,
					cruzaMedianoche,
					usuario
				);
			}

			// ========================================
			// RESULTADO
			// ========================================

			if (guardado)
			{
				MessageBox.Show(
					frmA.IsAddOrModify
						? "Horario agregado correctamente."
						: "Horario modificado correctamente.",
					"Correcto",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information
				);

				CargarHorarios();

				frmA.Close();
			}
		}
		public bool ModificarHorario(int idHorario,DateTime fechaInicio, DateTime? fechaFin, TimeSpan horaEntrada, TimeSpan horaSalida, bool cruzaMedianoche, string userModify)
		{
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				string query = @"
			UPDATE dbo.Nom_WorkGroupHorario
			SET
				d_fechaInicio = @fechaInicio,
				d_fechaFin = @fechaFin,
				t_horaEntrada = @horaEntrada,
				t_horaSalida = @horaSalida,
				b_cruzaMedianoche = @cruzaMedianoche,
				userModify = @userModify,
				d_dateModify = GETDATE()
			WHERE id_workGroupHorario = @idHorario";

				using (SqlCommand cmd = new SqlCommand(query, sql.cnn))
				{
					cmd.Parameters.Add("@idHorario", SqlDbType.Int)
						.Value = idHorario;

					cmd.Parameters.Add("@fechaInicio", SqlDbType.Date)
						.Value = fechaInicio.Date;

					cmd.Parameters.Add("@fechaFin", SqlDbType.Date)
						.Value = fechaFin.HasValue
							? fechaFin.Value.Date
							: (object)DBNull.Value;

					cmd.Parameters.Add("@horaEntrada", SqlDbType.Time)
						.Value = horaEntrada;

					cmd.Parameters.Add("@horaSalida", SqlDbType.Time)
						.Value = horaSalida;

					cmd.Parameters.Add("@cruzaMedianoche", SqlDbType.Bit)
						.Value = cruzaMedianoche;

					cmd.Parameters.Add("@userModify", SqlDbType.VarChar)
						.Value = userModify;

					cmd.ExecuteNonQuery();
				}

				sql.CloseConectionWrite();

				return true;
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
					MessageBoxIcon.Error
				);

				return false;
			}
		}
		public bool EliminarHorario(int idHorario)
		{
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				string query = @"
			DELETE FROM dbo.Nom_WorkGroupHorario
			WHERE id_workGroupHorario = @idHorario";

				using (SqlCommand cmd = new SqlCommand(query, sql.cnn))
				{
					cmd.Parameters.Add("@idHorario", SqlDbType.Int)
						.Value = idHorario;

					cmd.ExecuteNonQuery();
				}

				sql.CloseConectionWrite();

				return true;
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
					"Error al eliminar el horario.\n\n" + ex.Message,
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);

				return false;
			}
		}
		public void Eliminar()
		{
			if (frm.dgvHorarios.CurrentRow == null)
			{
				MessageBox.Show(
					"Seleccione un horario para eliminar.",
					"Aviso",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning
				);

				return;
			}

			int idHorario = Convert.ToInt32(
				frm.dgvHorarios.CurrentRow
					.Cells["id_workGroupHorario"]
					.Value
			);

			DialogResult resultado = MessageBox.Show(
				"¿Está seguro de eliminar el horario seleccionado?",
				"Confirmar eliminación",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question
			);

			if (resultado != DialogResult.Yes)
				return;

			if (EliminarHorario(idHorario))
			{
				MessageBox.Show(
					"Horario eliminado correctamente.",
					"Correcto",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information
				);

				CargarHorarios();
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
					MessageBoxIcon.Error
				);
			}
		}
		public void ConfigurarDgvHorarios()
		{
			// =========================
			// CONFIGURACIÓN GENERAL
			// =========================

			frm.dgvHorarios.AutoGenerateColumns = true;
			frm.dgvHorarios.AllowUserToAddRows = false;
			frm.dgvHorarios.AllowUserToDeleteRows = false;
			frm.dgvHorarios.AllowUserToResizeRows = false;
			frm.dgvHorarios.ReadOnly = true;
			frm.dgvHorarios.MultiSelect = false;

			// Seleccionar la fila completa
			frm.dgvHorarios.SelectionMode =
				DataGridViewSelectionMode.FullRowSelect;


			// =========================
			// FONDO
			// =========================

			frm.dgvHorarios.BackgroundColor = Color.White;

			frm.dgvHorarios.BorderStyle =
				BorderStyle.None;


			// =========================
			// LÍNEAS
			// =========================

			frm.dgvHorarios.CellBorderStyle =
				DataGridViewCellBorderStyle.SingleHorizontal;

			frm.dgvHorarios.GridColor =
				Color.FromArgb(225, 225, 225);

			frm.dgvHorarios.RowHeadersBorderStyle =
				DataGridViewHeaderBorderStyle.None;

			frm.dgvHorarios.ColumnHeadersBorderStyle =
				DataGridViewHeaderBorderStyle.None;


			// =========================
			// FILAS
			// =========================

			frm.dgvHorarios.RowTemplate.Height = 32;

			frm.dgvHorarios.DefaultCellStyle.BackColor =
				Color.White;

			frm.dgvHorarios.DefaultCellStyle.ForeColor =
				Color.FromArgb(40, 40, 40);


			// =========================
			// SELECCIÓN
			// =========================

			frm.dgvHorarios.DefaultCellStyle.SelectionBackColor =
				Color.FromArgb(220, 235, 250);

			frm.dgvHorarios.DefaultCellStyle.SelectionForeColor =
				Color.FromArgb(40, 40, 40);

			// =========================
			// ENCABEZADO
			// =========================

			frm.dgvHorarios.EnableHeadersVisualStyles = false;

			frm.dgvHorarios.ColumnHeadersDefaultCellStyle.BackColor =
				Color.FromArgb(35, 75, 145);

			frm.dgvHorarios.ColumnHeadersDefaultCellStyle.ForeColor =
				Color.White;

			frm.dgvHorarios.ColumnHeadersDefaultCellStyle.SelectionBackColor =
				Color.FromArgb(35, 75, 145);

			frm.dgvHorarios.ColumnHeadersDefaultCellStyle.SelectionForeColor =
				Color.White;

			frm.dgvHorarios.ColumnHeadersDefaultCellStyle.Font =
				new Font("Segoe UI", 9F, FontStyle.Bold);

			frm.dgvHorarios.ColumnHeadersDefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			frm.dgvHorarios.ColumnHeadersHeight = 32;


			// =========================
			// OCULTAR COLUMNAS INTERNAS
			// =========================

			frm.dgvHorarios.Columns["id_workGroupHorario"].Visible = false;

			frm.dgvHorarios.Columns["active"].Visible = false;


			// =========================
			// ENCABEZADOS
			// =========================

			frm.dgvHorarios.Columns["id_workGroup"].HeaderText =
				"Cuadrilla";

			frm.dgvHorarios.Columns["v_nameWorkGroup"].HeaderText =
				"Descripción";

			frm.dgvHorarios.Columns["d_fechaInicio"].HeaderText =
				"Fecha inicio";

			frm.dgvHorarios.Columns["d_fechaFin"].HeaderText =
				"Fecha fin";

			frm.dgvHorarios.Columns["t_horaEntrada"].HeaderText =
				"Entrada";

			frm.dgvHorarios.Columns["t_horaSalida"].HeaderText =
				"Salida";

			frm.dgvHorarios.Columns["b_cruzaMedianoche"].HeaderText =
				"Cruza medianoche";


			// =========================
			// ALINEACIÓN
			// =========================

			frm.dgvHorarios.Columns["id_workGroup"]
				.DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			frm.dgvHorarios.Columns["v_nameWorkGroup"]
				.DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleLeft;

			frm.dgvHorarios.Columns["d_fechaInicio"]
				.DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			frm.dgvHorarios.Columns["d_fechaFin"]
				.DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			frm.dgvHorarios.Columns["t_horaEntrada"]
				.DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			frm.dgvHorarios.Columns["t_horaSalida"]
				.DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			frm.dgvHorarios.Columns["b_cruzaMedianoche"]
				.DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;


			// =========================
			// FORMATO DE FECHAS
			// =========================

			frm.dgvHorarios.Columns["d_fechaInicio"]
				.DefaultCellStyle.Format = "dd/MM/yyyy";

			frm.dgvHorarios.Columns["d_fechaFin"]
				.DefaultCellStyle.Format = "dd/MM/yyyy";


			// =========================
			// FORMATO DE HORAS
			// =========================

			frm.dgvHorarios.Columns["t_horaEntrada"]
				.DefaultCellStyle.Format = @"hh\:mm";

			frm.dgvHorarios.Columns["t_horaSalida"]
				.DefaultCellStyle.Format = @"hh\:mm";


			// =========================
			// ANCHO DE COLUMNAS
			// =========================

			frm.dgvHorarios.Columns["id_workGroup"].Width = 90;

			frm.dgvHorarios.Columns["v_nameWorkGroup"].Width = 145;

			frm.dgvHorarios.Columns["d_fechaInicio"].Width = 105;

			frm.dgvHorarios.Columns["d_fechaFin"].Width = 105;

			frm.dgvHorarios.Columns["t_horaEntrada"].Width = 85;

			frm.dgvHorarios.Columns["t_horaSalida"].Width = 85;

			frm.dgvHorarios.Columns["b_cruzaMedianoche"].Width = 130;


			// =========================
			// NO AUTOAJUSTAR COLUMNAS
			// =========================

			frm.dgvHorarios.AutoSizeColumnsMode =
				DataGridViewAutoSizeColumnsMode.None;
		}
	}
}