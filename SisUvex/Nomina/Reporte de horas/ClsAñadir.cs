using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Vml.Office;
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
		private DateTime HoraOCero(object valor)
		{
			if (valor == null || valor == DBNull.Value)
				return DateTime.Today; // 00:00

			if (valor is TimeSpan ts)
				return DateTime.Today.Add(ts);

			if (valor is DateTime dt)
				return DateTime.Today.Add(dt.TimeOfDay);

			if (TimeSpan.TryParse(valor.ToString(), out TimeSpan t))
				return DateTime.Today.Add(t);

			return DateTime.Today;
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

				// INICIO NORMAL
				frmA.dtpBeginNormal.Value = Convert.ToDateTime(row.Cells["InicioNormal"].Value);

				// FIN NORMAL (depende si hay horas extra)
				if (row.Cells["InicioExtra"].Value != DBNull.Value)
				{
					frmA.dtpEndNormal.Value = Convert.ToDateTime(row.Cells["InicioExtra"].Value);
				}
				else
				{
					frmA.dtpEndNormal.Value = Convert.ToDateTime(row.Cells["FinNormal"].Value);
				}

				// FIN EXTRA
				if (row.Cells["FinExtra"].Value != DBNull.Value)
				{
					frmA.dtpEndExtra.Value = Convert.ToDateTime(row.Cells["FinExtra"].Value);
				}
				// HORAS EXTRA
				decimal horas = 0;

				if (row.Cells["HorasExtras"].Value != DBNull.Value)
					horas = Convert.ToDecimal(row.Cells["HorasExtras"].Value);

				if (horas > frmA.nudOvertime.Maximum || horas < frmA.nudOvertime.Minimum)
				{
					MessageBox.Show(
						$"Las horas extras ({horas}) están fuera del rango permitido.\n" +
						$"Debe estar entre {frmA.nudOvertime.Minimum} y {frmA.nudOvertime.Maximum}.",
						"Valor fuera de rango",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning
					);

					horas = Math.Max(frmA.nudOvertime.Minimum, horas);
					horas = Math.Min(frmA.nudOvertime.Maximum, horas);
				}
				CargarBloques(frmA, row);

				frmA.nudOvertime.Value = horas;
				//  DESCANSO
				frmA.dtpDescansoInicial.Value = HoraOCero(row.Cells["InicioDescanso"].Value);
				frmA.dtpDescansoFinal.Value = HoraOCero(row.Cells["FinDescanso"].Value);

				frmA.nudHorasDescanso.Value = row.Cells["HorasDescanso"].Value != DBNull.Value
					? Convert.ToDecimal(row.Cells["HorasDescanso"].Value)
					: 0;

				//  DESCANSO2
				frmA.dtpD2.Value = HoraOCero(row.Cells["InicioDescanso2"].Value);
				frmA.dtpDf2.Value = HoraOCero(row.Cells["FinDescanso2"].Value);

				frmA.nudD2.Value = row.Cells["HorasDescanso2"].Value != DBNull.Value
					? Convert.ToDecimal(row.Cells["HorasDescanso2"].Value)
					: 0;

				//  COMIDA
				frmA.dtpComidaInicial.Value = HoraOCero(row.Cells["InicioComida"].Value);
				frmA.dtpComidaFinal.Value = HoraOCero(row.Cells["FinComida"].Value);

				frmA.nudComidaHora.Value = row.Cells["HorasComida"].Value != DBNull.Value
					? Convert.ToDecimal(row.Cells["HorasComida"].Value)
					: 0;

				//  CENA
				frmA.dtpCenaInicial.Value = HoraOCero(row.Cells["InicioCena"].Value);
				frmA.dtpCenaFinal.Value = HoraOCero(row.Cells["FinCena"].Value);

				frmA.nudCenaHora.Value = row.Cells["HorasCena"].Value != DBNull.Value
					? Convert.ToDecimal(row.Cells["HorasCena"].Value)
					: 0;

				// LIMPIAR CHECKLIST
				for (int i = 0; i < frmA.clbCuadrilla.Items.Count; i++)
				{
					frmA.clbCuadrilla.SetItemChecked(i, false);
				}

				// MARCAR CUADRILLA
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
		private void CargarBloques(FrmAñadir frmA, DataGridViewRow row)
		{
			// DESCANSO
			SetDtpFromDb(frmA.dtpDescansoInicial, row.Cells["InicioDescanso"].Value);
			SetDtpFromDb(frmA.dtpDescansoFinal, row.Cells["FinDescanso"].Value);
			SetNudFromDb(
				frmA.nudHorasDescanso,
				row.Cells["HorasDescanso"].Value,
				frmA.dtpDescansoInicial,
				frmA.dtpDescansoFinal
			);

			// DESCANSO 2
			SetDtpFromDb(frmA.dtpD2, row.Cells["InicioDescanso2"].Value);
			SetDtpFromDb(frmA.dtpDf2, row.Cells["FinDescanso2"].Value);
			SetNudFromDb(
				frmA.nudD2,
				row.Cells["HorasDescanso2"].Value,
				frmA.dtpD2,
				frmA.dtpDf2
			);

			// COMIDA
			SetDtpFromDb(frmA.dtpComidaInicial, row.Cells["InicioComida"].Value);
			SetDtpFromDb(frmA.dtpComidaFinal, row.Cells["FinComida"].Value);
			SetNudFromDb(
				frmA.nudComidaHora,
				row.Cells["HorasComida"].Value,
				frmA.dtpComidaInicial,
				frmA.dtpComidaFinal
			);

			// CENA
			SetDtpFromDb(frmA.dtpCenaInicial, row.Cells["InicioCena"].Value);
			SetDtpFromDb(frmA.dtpCenaFinal, row.Cells["FinCena"].Value);
			SetNudFromDb(
				frmA.nudCenaHora,
				row.Cells["HorasCena"].Value,
				frmA.dtpCenaInicial,
				frmA.dtpCenaFinal
			);

			// 🔥 ACTUALIZA UI
			ActualizarControles();
		}
		public void ActualizarControles()
		{
			// TODO SIEMPRE HABILITADO
			frmA.dtpComidaFinal.Enabled = true;
			frmA.nudComidaHora.Enabled = true;

			frmA.dtpCenaFinal.Enabled = true;
			frmA.nudCenaHora.Enabled = true;

			frmA.dtpDescansoFinal.Enabled = true;
			frmA.nudHorasDescanso.Enabled = true;

			frmA.dtpDf2.Enabled = true;
			frmA.nudD2.Enabled = true;
		}
	
		private void SetDtpFromDb(DateTimePicker dtp, object value)
		{
			if (value != DBNull.Value && value != null &&
				DateTime.TryParse(value.ToString(), out DateTime dt))
			{
				dtp.Value = dt;
			}
			else
			{
				dtp.Value = DateTime.Now;
			}
		}

		private void SetNudFromDb(NumericUpDown nud, object value, DateTimePicker dtpInicial, DateTimePicker dtpFinal)
		{
			if (value == DBNull.Value || value == null)
			{
				nud.Value = 0;
				dtpInicial.Checked = false;
				dtpFinal.Checked = false;
				return;
			}

			decimal horas = Convert.ToDecimal(value);

			if (horas > 0)
			{
				nud.Value = horas;

				
				dtpInicial.Checked = true;
				dtpFinal.Checked = true;
			}
			else
			{
				nud.Value = 0;

				dtpInicial.Checked = false;
				dtpFinal.Checked = false;
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
						frmPacki.dgvHoras.Columns[col].Visible = false;
				}

				//  FORMATOS
				var cultura = new System.Globalization.CultureInfo("en-US");

				frmPacki.dgvHoras.Columns["InicioNormal"].DefaultCellStyle.Format = "dd/MM/yyyy hh:mm tt";
				frmPacki.dgvHoras.Columns["InicioNormal"].DefaultCellStyle.FormatProvider = cultura;

				frmPacki.dgvHoras.Columns["FinNormal"].DefaultCellStyle.Format = "dd/MM/yyyy hh:mm tt";
				frmPacki.dgvHoras.Columns["FinNormal"].DefaultCellStyle.FormatProvider = cultura;

				frmPacki.dgvHoras.Columns["InicioExtra"].DefaultCellStyle.Format = "dd/MM/yyyy hh:mm tt";
				frmPacki.dgvHoras.Columns["InicioExtra"].DefaultCellStyle.FormatProvider = cultura;

				frmPacki.dgvHoras.Columns["FinExtra"].DefaultCellStyle.Format = "dd/MM/yyyy hh:mm tt";
				frmPacki.dgvHoras.Columns["FinExtra"].DefaultCellStyle.FormatProvider = cultura;

				// HEADERS
				if (frmPacki.dgvHoras.Columns.Contains("Cuadrilla"))
					frmPacki.dgvHoras.Columns["Cuadrilla"].HeaderText = "Cuadrilla";

				if (frmPacki.dgvHoras.Columns.Contains("Fecha"))
					frmPacki.dgvHoras.Columns["Fecha"].HeaderText = "Fecha";

				if (frmPacki.dgvHoras.Columns.Contains("InicioNormal"))
					frmPacki.dgvHoras.Columns["InicioNormal"].HeaderText = "Inicio Normal";

				if (frmPacki.dgvHoras.Columns.Contains("FinNormal"))
					frmPacki.dgvHoras.Columns["FinNormal"].HeaderText = "Fin Normal";

				if (frmPacki.dgvHoras.Columns.Contains("HorasExtras"))
					frmPacki.dgvHoras.Columns["HorasExtras"].HeaderText = "Horas Extra";

				// COMIDA
				frmPacki.dgvHoras.Columns["InicioComida"].DefaultCellStyle.BackColor = frmPacki.colorComida;
				frmPacki.dgvHoras.Columns["InicioComida"].DefaultCellStyle.Format = "hh:mm tt";

				frmPacki.dgvHoras.Columns["FinComida"].DefaultCellStyle.BackColor = frmPacki.colorComida;
				frmPacki.dgvHoras.Columns["FinComida"].DefaultCellStyle.Format = "hh:mm tt";

				frmPacki.dgvHoras.Columns["HorasComida"].DefaultCellStyle.BackColor = frmPacki.colorComida;


				// CENA
				frmPacki.dgvHoras.Columns["InicioCena"].DefaultCellStyle.BackColor = frmPacki.colorCena;
				frmPacki.dgvHoras.Columns["InicioCena"].DefaultCellStyle.Format = "hh:mm tt";

				frmPacki.dgvHoras.Columns["FinCena"].DefaultCellStyle.BackColor = frmPacki.colorCena;
				frmPacki.dgvHoras.Columns["FinCena"].DefaultCellStyle.Format = "hh:mm tt";

				frmPacki.dgvHoras.Columns["HorasCena"].DefaultCellStyle.BackColor = frmPacki.colorCena;


				// DESCANSO
				frmPacki.dgvHoras.Columns["InicioDescanso"].DefaultCellStyle.BackColor = frmPacki.colorDescanso;
				frmPacki.dgvHoras.Columns["InicioDescanso"].DefaultCellStyle.Format = "hh:mm tt";

				frmPacki.dgvHoras.Columns["FinDescanso"].DefaultCellStyle.BackColor = frmPacki.colorDescanso;
				frmPacki.dgvHoras.Columns["FinDescanso"].DefaultCellStyle.Format = "hh:mm tt";

				frmPacki.dgvHoras.Columns["HorasDescanso"].DefaultCellStyle.BackColor = frmPacki.colorDescanso;


				// DESCANSO 2
				frmPacki.dgvHoras.Columns["InicioDescanso2"].DefaultCellStyle.BackColor = frmPacki.colorDescanso2;
				frmPacki.dgvHoras.Columns["InicioDescanso2"].DefaultCellStyle.Format = "hh:mm tt";

				frmPacki.dgvHoras.Columns["FinDescanso2"].DefaultCellStyle.BackColor = frmPacki.colorDescanso2;
				frmPacki.dgvHoras.Columns["FinDescanso2"].DefaultCellStyle.Format = "hh:mm tt";

				frmPacki.dgvHoras.Columns["HorasDescanso2"].DefaultCellStyle.BackColor = frmPacki.colorDescanso2;


				sql.CloseConectionWrite();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		public void PintarEncabezadosAgrupados(DataGridView dgv, DataGridViewCellPaintingEventArgs e)
		{
			// SOLO encabezados
			if (e.RowIndex != -1 || e.ColumnIndex < 0)
				return;

			var grupos = new[]
			{
				new { Nombre = "Comida", Inicio = "InicioComida", Fin = "FinComida", Horas = "HorasComida", Color = frmPacki.colorComida },
				new { Nombre = "Cena", Inicio = "InicioCena", Fin = "FinCena", Horas = "HorasCena", Color = frmPacki.colorCena },
				new { Nombre = "Descanso", Inicio = "InicioDescanso", Fin = "FinDescanso", Horas = "HorasDescanso", Color = frmPacki.colorDescanso },
				new { Nombre = "Descanso2", Inicio = "InicioDescanso2", Fin = "FinDescanso2", Horas = "HorasDescanso2", Color = frmPacki.colorDescanso2 }
			};

			foreach (var g in grupos)
			{
				if (!dgv.Columns.Contains(g.Inicio) ||
					!dgv.Columns.Contains(g.Fin) ||
					!dgv.Columns.Contains(g.Horas))
					continue;

				int colInicio = dgv.Columns[g.Inicio].Index;
				int colFin = dgv.Columns[g.Fin].Index;
				int colHoras = dgv.Columns[g.Horas].Index;

				//  DIBUJAR ENCABEZADO GRANDE SOLO UNA VEZ
				if (e.ColumnIndex == colInicio)
				{
					Rectangle rectTotal = new Rectangle(
						e.CellBounds.Left,
						e.CellBounds.Top,
						dgv.Columns[g.Inicio].Width +
						dgv.Columns[g.Fin].Width +
						dgv.Columns[g.Horas].Width,
						e.CellBounds.Height
					);

					// Fondo completo
					using (SolidBrush brush = new SolidBrush(System.Drawing.Color.WhiteSmoke))
						e.Graphics.FillRectangle(brush, rectTotal);

					// Parte superior (grupo)
					Rectangle rectTop = new Rectangle(
						rectTotal.Left,
						rectTotal.Top,
						rectTotal.Width,
						rectTotal.Height / 2
					);

					using (SolidBrush brush = new SolidBrush(g.Color))
						e.Graphics.FillRectangle(brush, rectTop);

					// Texto grupo
					using (StringFormat sf = new StringFormat()
					{
						Alignment = StringAlignment.Center,
						LineAlignment = StringAlignment.Center
					})
					{
						e.Graphics.DrawString(g.Nombre,
							dgv.ColumnHeadersDefaultCellStyle.Font,
							Brushes.Black,
							rectTop,
							sf);
					}

					// Bordes
					e.Graphics.DrawRectangle(Pens.Gray, rectTotal);

					e.Handled = true;
				}

				//  SUBENCABEZADOS
				if (e.ColumnIndex == colInicio ||
					e.ColumnIndex == colFin ||
					e.ColumnIndex == colHoras)
				{
					Rectangle rectBottom = new Rectangle(
						e.CellBounds.Left,
						e.CellBounds.Top + e.CellBounds.Height / 2,
						e.CellBounds.Width,
						e.CellBounds.Height / 2
					);

				
					using (SolidBrush brush = new SolidBrush(g.Color))
						e.Graphics.FillRectangle(brush, rectBottom);

					string texto = dgv.Columns[e.ColumnIndex].HeaderText;

					using (StringFormat sf = new StringFormat()
					{
						Alignment = StringAlignment.Center,
						LineAlignment = StringAlignment.Center
					})
					{
						e.Graphics.DrawString(texto,
							dgv.ColumnHeadersDefaultCellStyle.Font,
							Brushes.Black,
							rectBottom,
							sf);
					}

					e.Graphics.DrawRectangle(Pens.LightGray, rectBottom);

					e.Handled = true;
				}
			}
		}
		public void AjustarEncabezados()
		{
			frmPacki.dgvHoras.Columns["InicioComida"].HeaderText = "Inicio";
			frmPacki.dgvHoras.Columns["FinComida"].HeaderText = "Fin";
			frmPacki.dgvHoras.Columns["HorasComida"].HeaderText = "Horas";

			frmPacki.dgvHoras.Columns["InicioCena"].HeaderText = "Inicio";
			frmPacki.dgvHoras.Columns["FinCena"].HeaderText = "Fin";
			frmPacki.dgvHoras.Columns["HorasCena"].HeaderText = "Horas";

			frmPacki.dgvHoras.Columns["InicioDescanso"].HeaderText = "Inicio";
			frmPacki.dgvHoras.Columns["FinDescanso"].HeaderText = "Fin";
			frmPacki.dgvHoras.Columns["HorasDescanso"].HeaderText = "Horas";

			frmPacki.dgvHoras.Columns["InicioDescanso2"].HeaderText = "Inicio";
			frmPacki.dgvHoras.Columns["FinDescanso2"].HeaderText = "Fin";
			frmPacki.dgvHoras.Columns["HorasDescanso2"].HeaderText = "Horas";
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

				DateTime inicioNormal = frmA.dtpBeginNormal.Value.SinMs();
				DateTime finNormal = frmA.dtpEndNormal.Value.SinMs();

				//  SI CRUZA DE DÍA (NOCTURNO)
				if (finNormal <= inicioNormal)
					finNormal = finNormal.AddDays(1);

				//  EXTRA
				DateTime inicioExtra = finNormal;
				DateTime finExtra = frmA.dtpEndExtra.Value.SinMs();

				bool tieneExtra = frmA.nudOvertime.Value > 0;

				if (tieneExtra)
				{
					if (finExtra <= inicioExtra)
						finExtra = finExtra.AddDays(1);
				}

				sql.OpenConectionWrite();

				foreach (ItemCuadrilla item in frmA.clbCuadrilla.CheckedItems)
				{
					if (ExisteHorario(item.Id, fecha, 0))
					{
						MessageBox.Show($"Ya existe un horario para la cuadrilla {item.Id} en esa fecha");
						continue;
					}

					using (SqlCommand cmd = new SqlCommand("sp_Add_WorkTimeConfig", sql.cnn))
					{
						cmd.CommandType = CommandType.StoredProcedure;

						cmd.Parameters.Add("@WorkDate", SqlDbType.DateTime).Value = fecha;
						cmd.Parameters.Add("@HourBeginNormal", SqlDbType.DateTime).Value = inicioNormal;
						cmd.Parameters.Add("@HourEndNormal", SqlDbType.DateTime).Value = finNormal;

						cmd.Parameters.Add("@HourBeginExtra", SqlDbType.DateTime)
							.Value = tieneExtra ? inicioExtra : (object)DBNull.Value;

						cmd.Parameters.Add("@HourEndExtra", SqlDbType.DateTime)
							.Value = tieneExtra ? finExtra : (object)DBNull.Value;

						cmd.Parameters.Add("@OverTime", SqlDbType.Decimal).Value = frmA.nudOvertime.Value;

						//  BREAK
						cmd.Parameters.Add("@BreakStart", SqlDbType.Time).Value = GetTimeOrNull(frmA.dtpDescansoInicial);
						cmd.Parameters.Add("@BreakEnd", SqlDbType.Time).Value = GetTimeOrNull(frmA.dtpDescansoFinal);
						cmd.Parameters.Add("@BreakHours", SqlDbType.Decimal).Value =
						frmA.dtpDescansoInicial.Checked ? frmA.nudHorasDescanso.Value : (object)DBNull.Value;


						//  LUNCH
						cmd.Parameters.Add("@LunchStart", SqlDbType.Time).Value = GetTimeOrNull(frmA.dtpComidaInicial);
						cmd.Parameters.Add("@LunchEnd", SqlDbType.Time).Value = GetTimeOrNull(frmA.dtpComidaFinal);
						cmd.Parameters.Add("@LunchHours", SqlDbType.Decimal).Value =
						frmA.dtpComidaInicial.Checked ? frmA.nudComidaHora.Value : (object)DBNull.Value;

						// DINNER
						cmd.Parameters.Add("@DinnerStart", SqlDbType.Time).Value = GetTimeOrNull(frmA.dtpCenaInicial);
						cmd.Parameters.Add("@DinnerEnd", SqlDbType.Time).Value = GetTimeOrNull(frmA.dtpCenaFinal);
						cmd.Parameters.Add("@DinnerHours", SqlDbType.Decimal).Value =
						frmA.dtpCenaInicial.Checked ? frmA.nudCenaHora.Value : (object)DBNull.Value;

						//  BREAK 2 
						cmd.Parameters.Add("@BreakStart2", SqlDbType.Time).Value = GetTimeOrNull(frmA.dtpD2);
						cmd.Parameters.Add("@BreakEnd2", SqlDbType.Time).Value = GetTimeOrNull(frmA.dtpDf2);
						cmd.Parameters.Add("@BreakHours2", SqlDbType.Decimal).Value =
						frmA.dtpD2.Checked ? frmA.nudD2.Value : (object)DBNull.Value;

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
				DateTime fecha = frmA.dtpDay.Value.Date;

				DateTime inicioNormal = frmA.dtpBeginNormal.Value.SinMs();
				DateTime finNormal = frmA.dtpEndNormal.Value.SinMs();

				// CRUCE DE DÍA
				if (finNormal <= inicioNormal)
					finNormal = finNormal.AddDays(1);

				// EXTRA
				DateTime inicioExtra = finNormal;
				DateTime finExtra = frmA.dtpEndExtra.Value.SinMs();

				bool tieneExtra = frmA.nudOvertime.Value > 0;

				if (tieneExtra)
				{
					if (finExtra <= inicioExtra)
						finExtra = finExtra.AddDays(1);
				}

				sql.OpenConectionWrite();

				using (SqlCommand cmd = new SqlCommand("sp_Update_WorkTimeConfig", sql.cnn))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@IdWorkTime", SqlDbType.Int).Value = frmA.idModify;

					cmd.Parameters.Add("@WorkDate", SqlDbType.DateTime).Value = fecha;
					cmd.Parameters.Add("@HourBeginNormal", SqlDbType.DateTime).Value = inicioNormal;
					cmd.Parameters.Add("@HourEndNormal", SqlDbType.DateTime).Value = finNormal;

					cmd.Parameters.Add("@HourBeginExtra", SqlDbType.DateTime)
						.Value = tieneExtra ? inicioExtra : (object)DBNull.Value;

					cmd.Parameters.Add("@HourEndExtra", SqlDbType.DateTime)
						.Value = tieneExtra ? finExtra : (object)DBNull.Value;

					cmd.Parameters.Add("@OverTime", SqlDbType.Decimal).Value = frmA.nudOvertime.Value;

					// BREAK
					cmd.Parameters.Add("@BreakStart", SqlDbType.Time).Value = GetTimeOrNull(frmA.dtpDescansoInicial);
					cmd.Parameters.Add("@BreakEnd", SqlDbType.Time).Value = GetTimeOrNull(frmA.dtpDescansoFinal);
					cmd.Parameters.Add("@BreakHours", SqlDbType.Decimal).Value =
						frmA.dtpDescansoInicial.Checked ? frmA.nudHorasDescanso.Value : (object)DBNull.Value;

					// BREAK 2
					cmd.Parameters.Add("@BreakStart2", SqlDbType.Time).Value = GetTimeOrNull(frmA.dtpD2);
					cmd.Parameters.Add("@BreakEnd2", SqlDbType.Time).Value = GetTimeOrNull(frmA.dtpDf2);
					cmd.Parameters.Add("@BreakHours2", SqlDbType.Decimal).Value =
						frmA.dtpD2.Checked ? frmA.nudD2.Value : (object)DBNull.Value;

					// LUNCH
					cmd.Parameters.Add("@LunchStart", SqlDbType.Time).Value = GetTimeOrNull(frmA.dtpComidaInicial);
					cmd.Parameters.Add("@LunchEnd", SqlDbType.Time).Value = GetTimeOrNull(frmA.dtpComidaFinal);
					cmd.Parameters.Add("@LunchHours", SqlDbType.Decimal).Value =
						frmA.dtpComidaInicial.Checked ? frmA.nudComidaHora.Value : (object)DBNull.Value;

					// DINNER
					cmd.Parameters.Add("@DinnerStart", SqlDbType.Time).Value = GetTimeOrNull(frmA.dtpCenaInicial);
					cmd.Parameters.Add("@DinnerEnd", SqlDbType.Time).Value = GetTimeOrNull(frmA.dtpCenaFinal);
					cmd.Parameters.Add("@DinnerHours", SqlDbType.Decimal).Value =
						frmA.dtpCenaInicial.Checked ? frmA.nudCenaHora.Value : (object)DBNull.Value;

					cmd.Parameters.Add("@UserUpdate", SqlDbType.VarChar).Value = User.GetUserName();
					cmd.Parameters.Add("@id_workGroup", SqlDbType.VarChar).Value = ((ItemCuadrilla)frmA.clbCuadrilla.CheckedItems[0]).Id;

					cmd.ExecuteNonQuery();
				}

				frmA.AddIsUpdate = true;
				CargarHorasInicial();
				frmA.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "modificar");
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}
		private object GetTimeOrNull(DateTimePicker dtp)
		{

			return dtp.Checked
				? dtp.Value.TimeOfDay   
				: (object)DBNull.Value;
		}
		public void FormatearColumnasHora(DataGridView dgv)
		{
			var cultura = new System.Globalization.CultureInfo("es-MX");

			string[] columnasHora =
			{
				"Comida Inicio", "Comida Fin",
				"Cena Inicio", "Cena Fin",
				"Break Inicio", "Break Fin",
				"Break2 Inicio", "Break2 Fin"
			};

			foreach (string col in columnasHora)
			{
				if (dgv.Columns.Contains(col))
				{
					dgv.Columns[col].DefaultCellStyle.Format = "hh:mm tt";
					dgv.Columns[col].DefaultCellStyle.FormatProvider = cultura;
				}
			}
		}
		public void CalcularHoras(DateTimePicker inicio, DateTimePicker fin, NumericUpDown nud)
		{
			if (inicio.Checked && fin.Checked)
			{
				TimeSpan diff = fin.Value - inicio.Value;

				if (diff.TotalMinutes >= 0)
				{
					decimal horas = Math.Round((decimal)diff.TotalHours, 2);

					if (horas > nud.Maximum)
						nud.Value = nud.Maximum;
					else if (horas < nud.Minimum)
						nud.Value = nud.Minimum;
					else
						nud.Value = horas;
				}
				else
				{
					nud.Value = 0;
				}
			}
			else
			{
				nud.Value = 0;
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
		private TimeSpan SHMS(DateTime dt)
		{
			return new TimeSpan(dt.Hour, dt.Minute, 0);
		}
	}

}
public static class DateTimeExtensions
{
	// Quita milisegundos
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