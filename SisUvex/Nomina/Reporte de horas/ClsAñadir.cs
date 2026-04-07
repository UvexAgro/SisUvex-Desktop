using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using NPOI.SS.Formula.Functions;
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

		public int IdWorkTime { get; set; }

		public DateTime WorkDate { get; set; }

		public DateTime HourBeginNormal { get; set; }
		public DateTime HourEndNormal { get; set; }

		public DateTime HourBeginExtra { get; set; }
		public DateTime HourEndExtra { get; set; }

		public decimal OverTime { get; set; }

		public string UserCreate { get; set; }
		public DateTime DateCreate { get; set; }

		public string UserUpdate { get; set; }
		public DateTime? DateUpdate { get; set; }
		
		public void SetWorkTime(int IdWorkTime)
		{
			try
			{
				sql.OpenConectionWrite();

				SqlCommand cmd = new SqlCommand(
					"SELECT * FROM dbo.WorkTimeConfig WHERE id_workTime = @id",
					sql.cnn
				);

				cmd.Parameters.AddWithValue("@id", IdWorkTime);

				SqlDataReader dr = cmd.ExecuteReader();

				if (dr.Read())
				{
					IdWorkTime = dr.GetInt32(dr.GetOrdinal("id_workTime"));

					WorkDate = dr.GetDateTime(dr.GetOrdinal("d_workTime"));

					HourBeginNormal = dr.GetDateTime(dr.GetOrdinal("d_dateHourBeginNormal"));
					HourEndNormal = dr.GetDateTime(dr.GetOrdinal("d_dateHourEndNormal"));

					HourBeginExtra = dr.GetDateTime(dr.GetOrdinal("d_dateHourBeginExtra"));
					HourEndExtra = dr.GetDateTime(dr.GetOrdinal("d_dateHourEndExtra"));

					OverTime = dr.GetDecimal(dr.GetOrdinal("c_overtime"));

					UserCreate = dr["userCreate"].ToString();
					DateCreate = dr.GetDateTime(dr.GetOrdinal("d_create"));

					UserUpdate = dr["userUpdate"].ToString();

					
					if (dr["d_update"] != DBNull.Value)
						DateUpdate = dr.GetDateTime(dr.GetOrdinal("d_update"));
					else
						DateUpdate = null;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Error al obtener WorkTime");
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}
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
				frmA= new FrmAñadir(frmPacki, this);
				frmA.Text = "Modificar horario de empaque";
				frmA.lblTitle.Text = "Modificar horario de empaque";
				frmA.IsAddModify = false;

				frmA.idModify = frmPacki.dgvHoras.SelectedRows[0].Cells[ClsObject.Column.id].Value.ToString();

				frmA.ShowDialog();
			}
			else
				SystemSounds.Exclamation.Play();
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

				SqlCommand cmd = new SqlCommand($@"
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
				sql.OpenConectionWrite();

				SqlCommand cmd = new SqlCommand("sp_Add_WorkTimeConfig", sql.cnn);
				cmd.CommandType = CommandType.StoredProcedure;

				
				DateTime fecha = frmA.dtpDay.Value.Date;

				DateTime inicioNormal = fecha.Add(frmA.dtpBeginNormal.Value.TimeOfDay);
				DateTime finNormal = fecha.Add(frmA.dtpEndNormal.Value.TimeOfDay);
				DateTime inicioExtra = fecha.Add(frmA.dtpEndNormal.Value.TimeOfDay);
				DateTime finExtra = fecha.Add(frmA.dtpEndExtra.Value.TimeOfDay);

			
				if (finNormal <= inicioNormal)
				{
					MessageBox.Show("La hora final debe ser mayor a la inicial");
					return;
				}

			
				cmd.Parameters.AddWithValue("@WorkDate", fecha);
				cmd.Parameters.AddWithValue("@HourBeginNormal", inicioNormal);
				cmd.Parameters.AddWithValue("@HourEndNormal", finNormal);
				cmd.Parameters.AddWithValue("@HourBeginExtra", inicioExtra);
				cmd.Parameters.AddWithValue("@HourEndExtra", finExtra);
				cmd.Parameters.AddWithValue("@OverTime", frmA.nudOvertime.Value);
				cmd.Parameters.AddWithValue("@UserCreate", User.GetUserName());

				cmd.ExecuteNonQuery();

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
				sql.OpenConectionWrite();

				SqlCommand cmd = new SqlCommand("sp_Update_WorkTimeConfig", sql.cnn);
				cmd.CommandType = CommandType.StoredProcedure;

				DateTime fecha = frmA.dtpDay.Value.Date;

				DateTime inicioNormal = fecha.Add(frmA.dtpBeginNormal.Value.TimeOfDay);
				DateTime finNormal = fecha.Add(frmA.dtpEndNormal.Value.TimeOfDay);
				DateTime inicioExtra = fecha.Add(frmA.dtpEndNormal.Value.TimeOfDay);
				DateTime finExtra = fecha.Add(frmA.dtpEndExtra.Value.TimeOfDay);

				cmd.Parameters.AddWithValue("@IdWorkTime", frmA.idModify);
				cmd.Parameters.AddWithValue("@WorkDate", fecha);
				cmd.Parameters.AddWithValue("@HourBeginNormal", inicioNormal);
				cmd.Parameters.AddWithValue("@HourEndNormal", finNormal);
				cmd.Parameters.AddWithValue("@HourBeginExtra", inicioExtra);
				cmd.Parameters.AddWithValue("@HourEndExtra", finExtra);
				cmd.Parameters.AddWithValue("@OverTime", frmA.nudOvertime.Value);
				cmd.Parameters.AddWithValue("@UserUpdate", User.GetUserName());

				cmd.ExecuteNonQuery();

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
	
		public void ActualizarFecha(DateTimePicker dtp)
		{
			DateTime nuevaFecha = frmA.dtpDay.Value.Date;
			TimeSpan hora = dtp.Value.TimeOfDay;

			dtp.Value = nuevaFecha.Add(hora);
		}
		private void EstiloDGV(DataGridView dgv)
		{
			dgv.BorderStyle = BorderStyle.None;

			// 🔥 LÍNEAS VERTICALES + HORIZONTALES
			dgv.CellBorderStyle = DataGridViewCellBorderStyle.Single;
			dgv.GridColor = DrawingColor.FromArgb(220, 220, 220);

			dgv.RowHeadersVisible = false;

			dgv.BackgroundColor = DrawingColor.FromArgb(250, 250, 250);

			// 🔷 ENCABEZADO
			dgv.EnableHeadersVisualStyles = false;

			dgv.ColumnHeadersDefaultCellStyle.BackColor = DrawingColor.FromArgb(45, 62, 80); // ✅ corregido
			dgv.ColumnHeadersDefaultCellStyle.ForeColor = DrawingColor.White;
			dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

			// 🚫 NO selección en encabezado
			dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = dgv.ColumnHeadersDefaultCellStyle.BackColor;
			dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = dgv.ColumnHeadersDefaultCellStyle.ForeColor;

			// 🔹 CELDAS
			dgv.DefaultCellStyle.BackColor = DrawingColor.White;
			dgv.DefaultCellStyle.ForeColor = DrawingColor.FromArgb(40, 40, 40);
			dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);

			// 🔵 SELECCIÓN (solo filas)
			dgv.DefaultCellStyle.SelectionBackColor = DrawingColor.FromArgb(0, 120, 215);
			dgv.DefaultCellStyle.SelectionForeColor = DrawingColor.White;

			// 🔸 FILAS ALTERNAS
			dgv.AlternatingRowsDefaultCellStyle.BackColor = DrawingColor.FromArgb(245, 247, 250);

			// ⚙️ CONFIGURACIÓN
			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgv.MultiSelect = false;
			dgv.ReadOnly = true;
			dgv.AllowUserToAddRows = false;

			// 🔥 QUITAR selección inicial
			dgv.ClearSelection();

			// 🔥 EVITAR que el header se quede seleccionado
			dgv.ColumnHeaderMouseClick += (s, e) =>
			{
				dgv.ClearSelection();
			};
		}
	}

}
