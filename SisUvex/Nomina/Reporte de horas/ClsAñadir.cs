using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using NPOI.SS.Formula.Functions;
using SisUvex.Catalogos;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.TextBoxes;
using SisUvex.Nomina.Conceptos_Ingresos_Diversos;
using SisUvex.Nomina.Work_time;
using static SisUvex.Catalogos.Metods.ClsObject;
using DrawingColor = System.Drawing.Color;

namespace SisUvex.Nomina.Reporte_de_horas
{
	public class ClsAñadir
	{
		public FrmAñadir frmA;
		public FrmPackingHours frmPacki;
		ClsControls controlList;
		
		SQLControl sql = new SQLControl();
		
		public void OpenFrmAdd()
		{
			frmA = new FrmAñadir(frmPacki, this);
			frmA.Text = "Añadir horario de empaque";
			frmA.lblTitle.Text = "Añadir horario de empaque";
			frmA.IsAddModify = true;

			frmA.ShowDialog();
		}
		public void OpenFrmModify()
		{
			if (frmPacki.dgvHoras.SelectedRows.Count != 0)
			{
				frmA = new FrmAñadir(frmPacki, this);

				frmA.Text = "Modificar horario de empaque";
				frmA.lblTitle.Text = "Modificar horario de empaque";
				frmA.IsAddModify = false;

				DataGridViewRow row = frmPacki.dgvHoras.SelectedRows[0];

				// ID
				frmA.idModify = row.Cells["id_workTime"].Value.ToString();

				// FECHA
				frmA.dtpDay.Value = Convert.ToDateTime(row.Cells["Fecha"].Value);

				// HORARIO NORMAL (REAL DESDE BD)
				frmA.dtpBeginNormal.Value = Convert.ToDateTime(row.Cells["InicioNormal"].Value);
				frmA.dtpEndNormal.Value = Convert.ToDateTime(row.Cells["FinNormal"].Value);
				// HORARIO EXTRA (REAL DESDE BD)
				if (row.Cells["FinExtra"].Value != DBNull.Value)
				{
					frmA.dtpEndExtra.Value = Convert.ToDateTime(row.Cells["FinExtra"].Value);
				}

				//  HORAS EXTRA
				decimal horas = 0;

				if (row.Cells["HorasExtras"].Value != DBNull.Value)
				{
					horas = Convert.ToDecimal(row.Cells["HorasExtras"].Value);
				}

				if (horas > frmA.nudOvertime.Maximum || horas < frmA.nudOvertime.Minimum)
				{
					MessageBox.Show(
						$"Las horas extras ({horas}) están fuera del rango permitido.\n" +
						$"Debe estar entre {frmA.nudOvertime.Minimum} y {frmA.nudOvertime.Maximum}.",
						"Valor fuera de rango",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning
					);

					// 🔒 Ajustar automáticamente al rango
					horas = Math.Max(frmA.nudOvertime.Minimum, horas);
					horas = Math.Min(frmA.nudOvertime.Maximum, horas);
				}

				// ✅ Ya no truena
				frmA.nudOvertime.Value = horas;

				//  LIMPIAR CHECKLIST
				for (int i = 0; i < frmA.clbCuadrilla.Items.Count; i++)
				{
					frmA.clbCuadrilla.SetItemChecked(i, false);
				}

				//  MARCAR CUADRILLA
				string idCuadrilla = row.Cells["CodigoCuadrilla"].Value.ToString();

				for (int i = 0; i < frmA.clbCuadrilla.Items.Count; i++)
				{
					ItemCuadrilla item = (ItemCuadrilla)frmA.clbCuadrilla.Items[i];

					if (item.Id == idCuadrilla)
					{
						frmA.clbCuadrilla.SetItemChecked(i, true);
						break;
					}
				}

				frmA.ShowDialog();
			}
			else
			{
				SystemSounds.Exclamation.Play();
			}
		}
		public void CargarHorasInicial()
		{
			try
			{
				if (frmPacki.cboTemporada.SelectedValue == null ||
					frmPacki.cboSemana.SelectedItem == null ||
					frmPacki.cboFinal.SelectedItem == null)
					return;

				DataRowView rowInicio = (DataRowView)frmPacki.cboSemana.SelectedItem;
				DataRowView rowFin = (DataRowView)frmPacki.cboFinal.SelectedItem;

				int temporada = Convert.ToInt32(frmPacki.cboTemporada.SelectedValue);
				int periodo = Convert.ToInt32(rowInicio[Payroll_AttendancePeriod.ColumnId]);
				int semanaInicio = Convert.ToInt32(rowInicio[Payroll_AttendancePeriod.ColumnSequence]);
				int semanaFin = Convert.ToInt32(rowFin[Payroll_AttendancePeriod.ColumnSequence]);

				DataTable dt = new DataTable();

				SQLControl sql = new SQLControl();
				sql.OpenConectionWrite();

				SqlCommand cmd = new SqlCommand(@"
				SELECT * 
				FROM dbo.fn_PackHorasEmpaque(
					@Temporada, 
					@Periodo, 
					@SemanaInicio, 
					@SemanaFin
				)", sql.cnn);

				cmd.Parameters.AddWithValue("@Temporada", temporada);
				cmd.Parameters.AddWithValue("@Periodo", periodo);
				cmd.Parameters.AddWithValue("@SemanaInicio", semanaInicio);
				cmd.Parameters.AddWithValue("@SemanaFin", semanaFin);

				SqlDataAdapter da = new SqlDataAdapter(cmd);
				da.Fill(dt);

				frmPacki.dgvHoras.DataSource = dt;

				//  OCULTAR COLUMNAS TÉCNICAS
				string[] columnasOcultar =
				{
					"id_workTime",
					"CodigoCuadrilla",
					"d_dateHourBeginNormal",
					"d_dateHourEndNormal",
					"d_dateHourBeginExtra",
					"d_dateHourEndExtra"
		};

				foreach (string col in columnasOcultar)
				{
					if (frmPacki.dgvHoras.Columns.Contains(col))
					{
						frmPacki.dgvHoras.Columns[col].Visible = false;
					}
				}

			
				string formato = "dd/MM/yyyy HH:mm";

				if (frmPacki.dgvHoras.Columns.Contains("InicioNormal"))
					frmPacki.dgvHoras.Columns["InicioNormal"].DefaultCellStyle.Format = "dd/MM/yyyy hh:mm tt";

				if (frmPacki.dgvHoras.Columns.Contains("FinNormal"))
					frmPacki.dgvHoras.Columns["FinNormal"].DefaultCellStyle.Format = "dd/MM/yyyy hh:mm tt";

				if (frmPacki.dgvHoras.Columns.Contains("InicioExtra"))
					frmPacki.dgvHoras.Columns["InicioExtra"].DefaultCellStyle.Format = "dd/MM/yyyy hh:mm tt";

				if (frmPacki.dgvHoras.Columns.Contains("FinExtra"))
					frmPacki.dgvHoras.Columns["FinExtra"].DefaultCellStyle.Format = "dd/MM/yyyy hh:mm tt";

				if (frmPacki.dgvHoras.Columns.Contains("Cuadrilla"))
					frmPacki.dgvHoras.Columns["Cuadrilla"].HeaderText = "Cuadrilla";

				if (frmPacki.dgvHoras.Columns.Contains("Fecha"))
					frmPacki.dgvHoras.Columns["Fecha"].HeaderText = "Fecha";

				if (frmPacki.dgvHoras.Columns.Contains("InicioNormal"))
					frmPacki.dgvHoras.Columns["InicioNormal"].HeaderText = "Inicio Normal";

				if (frmPacki.dgvHoras.Columns.Contains("FinNormal"))
					frmPacki.dgvHoras.Columns["FinNormal"].HeaderText = "Fin Normal";

				if (frmPacki.dgvHoras.Columns.Contains("InicioExtra"))
					frmPacki.dgvHoras.Columns["InicioExtra"].HeaderText = "Inicio Extra";

				if (frmPacki.dgvHoras.Columns.Contains("FinExtra"))
					frmPacki.dgvHoras.Columns["FinExtra"].HeaderText = "Fin Extra";

				if (frmPacki.dgvHoras.Columns.Contains("HorasExtras"))
					frmPacki.dgvHoras.Columns["HorasExtras"].HeaderText = "Horas Extra";

				//  CUADRILLA PRIMERO
				if (frmPacki.dgvHoras.Columns.Contains("Cuadrilla"))
					frmPacki.dgvHoras.Columns["Cuadrilla"].DisplayIndex = 0;

				EstiloDGV(frmPacki.dgvHoras);

				sql.CloseConectionWrite();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		public void AddProcedure()
		{
			try
			{
				if (frmA.clbCuadrilla.CheckedItems.Count == 0)
				{
					MessageBox.Show("Selecciona al menos una cuadrilla");
					return;
				}
				
				DateTime fecha = frmA.dtpDay.Value.Date;

				DateTime inicioNormal = (frmA.dtpBeginNormal.Value.SinMs());
				DateTime finNormal = (frmA.dtpEndNormal.Value.SinMs());
				DateTime inicioExtra = (frmA.dtpEndNormal.Value.SinMs());
				DateTime finExtra = (frmA.dtpEndExtra.Value.SinMs());

				sql.OpenConectionWrite();

				foreach (ItemCuadrilla item in frmA.clbCuadrilla.CheckedItems)
				{
					//  VALIDAR ANTES DE INSERTAR
					if (ExisteHorario(item.Id, fecha.Date, 0))
					{
						MessageBox.Show($"Ya existe un horario para la cuadrilla {item.Id} en esa fecha");
						continue; // salta solo esa cuadrilla
					}

					using (SqlCommand cmd = new SqlCommand("sp_Add_WorkTimeConfig", sql.cnn))
					{
						cmd.CommandType = CommandType.StoredProcedure;

						cmd.Parameters.Add("@WorkDate", SqlDbType.DateTime).Value = fecha;
						cmd.Parameters.Add("@HourBeginNormal", SqlDbType.DateTime).Value = inicioNormal;
						cmd.Parameters.Add("@HourEndNormal", SqlDbType.DateTime).Value = finNormal;
						cmd.Parameters.Add("@HourBeginExtra", SqlDbType.DateTime).Value = inicioExtra;
						cmd.Parameters.Add("@HourEndExtra", SqlDbType.DateTime).Value = finExtra;
						cmd.Parameters.Add("@OverTime", SqlDbType.Int).Value = frmA.nudOvertime.Value;
						cmd.Parameters.Add("@UserCreate", SqlDbType.VarChar).Value = User.GetUserName();
						cmd.Parameters.Add("@id_workGroup", SqlDbType.VarChar).Value = item.Id;

						cmd.ExecuteNonQuery();
					}
				}

				frmA.AddIsUpdate = true;
				CargarHorasInicial();
				frmA.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "añadir");
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}
		public void UpdateProcedure()
		{
			try
			{
				if (frmA.clbCuadrilla.CheckedItems.Count != 1)
				{
					MessageBox.Show("Selecciona solo una cuadrilla para editar");
					return;
				}

				ItemCuadrilla item = (ItemCuadrilla)frmA.clbCuadrilla.CheckedItems[0];
				string idCuadrilla = item.Id;

				int idActual = int.Parse(frmA.idModify);

				sql.OpenConectionWrite(); 
				if (ExisteHorario(idCuadrilla,frmA.dtpDay.Value, idActual))
				{
					MessageBox.Show("Ya existe un horario para esta cuadrilla en esa fecha");
					return;
				}

				using (SqlCommand cmd = new SqlCommand("sp_Update_WorkTimeConfig", sql.cnn))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@IdWorkTime", SqlDbType.Int).Value = idActual;
					cmd.Parameters.Add("@WorkDate", SqlDbType.DateTime).Value = frmA.dtpDay.Value;
					cmd.Parameters.Add("@HourBeginNormal", SqlDbType.DateTime).Value = frmA.dtpBeginNormal.Value;
					cmd.Parameters.Add("@HourEndNormal", SqlDbType.DateTime).Value = frmA.dtpEndNormal.Value; ;
					cmd.Parameters.Add("@HourBeginExtra", SqlDbType.DateTime).Value = frmA.dtpEndNormal.Value;
					cmd.Parameters.Add("@HourEndExtra", SqlDbType.DateTime).Value = frmA.dtpEndExtra.Value;
					cmd.Parameters.Add("@OverTime", SqlDbType.Decimal).Value = frmA.nudOvertime.Value;
					cmd.Parameters.Add("@UserUpdate", SqlDbType.VarChar).Value = User.GetUserName();
					cmd.Parameters.Add("@id_workGroup", SqlDbType.VarChar).Value = idCuadrilla;

					cmd.ExecuteNonQuery();
				}

				frmA.AddIsUpdate = true;
				CargarHorasInicial();
				frmA.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}

		public bool ExisteHorario(string idCuadrilla, DateTime fecha, int idActual)
		{
			try
			{
				string query = @"
				SELECT COUNT(*) 
				FROM WorkTimeConfig
				WHERE id_workGroup = @id
				AND d_workTime >= @fecha
				AND d_workTime < DATEADD(DAY, 1, @fecha)
				AND id_workTime <> @idActual";

				using (SqlCommand cmd = new SqlCommand(query, sql.cnn))
				{
					cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = idCuadrilla;
					cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = fecha.Date;
					cmd.Parameters.Add("@idActual", SqlDbType.Int).Value = idActual;

					int count = (int)cmd.ExecuteScalar();

					return count > 0;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return true;
			}
		}

		public void AjustarTurno(DateTimePicker inicio, DateTimePicker fin)
		{
			if (fin.Value <= inicio.Value)
			{
				fin.Value = fin.Value.AddDays(1);
			}
		}
		private void EstiloDGV(DataGridView dgv)
		{
			dgv.BorderStyle = BorderStyle.None;

			dgv.CellBorderStyle = DataGridViewCellBorderStyle.Single;
			dgv.GridColor = DrawingColor.FromArgb(220, 220, 220);

			dgv.RowHeadersVisible = false;

			dgv.BackgroundColor = DrawingColor.FromArgb(250, 250, 250);

			//  ENCABEZADO
			dgv.EnableHeadersVisualStyles = false;

			dgv.ColumnHeadersDefaultCellStyle.BackColor = DrawingColor.FromArgb(45, 62, 80); 
			dgv.ColumnHeadersDefaultCellStyle.ForeColor = DrawingColor.White;
			dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

			//  NO selección en encabezado
			dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = dgv.ColumnHeadersDefaultCellStyle.BackColor;
			dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = dgv.ColumnHeadersDefaultCellStyle.ForeColor;

			//  CELDAS
			dgv.DefaultCellStyle.BackColor = DrawingColor.White;
			dgv.DefaultCellStyle.ForeColor = DrawingColor.FromArgb(40, 40, 40);
			dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);

			//  SELECCIÓN (solo filas)
			dgv.DefaultCellStyle.SelectionBackColor = DrawingColor.FromArgb(0, 120, 215);
			dgv.DefaultCellStyle.SelectionForeColor = DrawingColor.White;

			//  FILAS ALTERNAS
			dgv.AlternatingRowsDefaultCellStyle.BackColor = DrawingColor.FromArgb(245, 247, 250);

			//  CONFIGURACIÓN
			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgv.MultiSelect = false;
			dgv.ReadOnly = true;
			dgv.AllowUserToAddRows = false;

			//  QUITAR selección inicial
			dgv.ClearSelection();

			//  EVITAR que el header se quede seleccionado
			dgv.ColumnHeaderMouseClick += (s, e) =>
			{
				dgv.ClearSelection();
			};
		}
		public class ItemCuadrilla
		{
			public string Id { get; set; }
			public string Nombre { get; set; }

			public override string ToString()
			{
				return Nombre; 
			}
		}
		public void CargarCuadrillasCheckList()
		{
			int temporada = Convert.ToInt32(frmPacki.cboTemporada.SelectedValue);

			DataTable dt = ClbCuadrilla(temporada);

			frmA.clbCuadrilla.Items.Clear();

			foreach (DataRow row in dt.Rows)
			{
				frmA.clbCuadrilla.Items.Add(new ItemCuadrilla
				{
					Id = row["Código"].ToString(),
					Nombre = row["Nombre"].ToString()
				});
			}

			frmA.clbCuadrilla.CheckOnClick = true;
		}
		public DataTable ClbCuadrilla(int temporada)
		{
			DataTable dt = new DataTable();

			sql.OpenConectionWrite();

			string query = @"
				SELECT 
					g.id_workGroup AS Código,
					g.v_nameWorkGroup + ' - ' + c.v_nameContractor AS Nombre
				FROM Pack_WorkGroup g
				INNER JOIN Pack_Contractor c 
					ON g.id_contractor = c.id_contractor
				WHERE g.id_season = @Temporada
				AND g.c_active = 1
				ORDER BY g.v_nameWorkGroup";

			SqlCommand cmd = new SqlCommand(query, sql.cnn);
			cmd.Parameters.AddWithValue("@Temporada", temporada);

			SqlDataAdapter da = new SqlDataAdapter(cmd);
			da.Fill(dt);

			sql.CloseConectionWrite();

			return dt;
		}
		public void DeleteProcedure()
		{
			try
			{
				
				if (frmPacki.dgvHoras.CurrentRow == null)
				{
					MessageBox.Show("Selecciona un registro");
					return;
				}

				DialogResult result = MessageBox.Show(
					"¿Eliminar este horario?",
					"Confirmar",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question,
					MessageBoxDefaultButton.Button2
				);

				if (result != DialogResult.Yes)
				{
					return;
				}

				sql.OpenConectionWrite();

			
				int id = Convert.ToInt32(frmPacki.dgvHoras.CurrentRow.Cells["id_workTime"].Value);

				SqlCommand cmd = new SqlCommand("sp_Delete_WorkTimeConfig", sql.cnn);
				cmd.CommandType = CommandType.StoredProcedure;

				cmd.Parameters.AddWithValue("@IdWorkTime", id);

				cmd.ExecuteNonQuery();

				MessageBox.Show("Horario eliminado correctamente");

				frmA.AddIsUpdate = true;

				CargarHorasInicial();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}
	}

}
public static class DateTimeExtensions
{
	public static DateTime SinMs(this DateTime fecha)
	{
		return new DateTime(
			fecha.Year,
			fecha.Month,
			fecha.Day,
			fecha.Hour,
			fecha.Minute,
			fecha.Second
		);
	}
}