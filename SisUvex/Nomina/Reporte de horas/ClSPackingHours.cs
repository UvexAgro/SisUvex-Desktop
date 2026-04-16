using System;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.ComboBoxes;
using static SisUvex.Catalogos.Metods.ClsObject;


namespace SisUvex.Nomina.Reporte_de_horas
{
	internal class ClSPackingHours
	{
		public FrmPackingHours frmPacki;

		public void CargarPeriodos()
		{
			// Cargar combos
			ClsComboBoxes.CboLoadActives(frmPacki.cboSemana, Payroll_AttendancePeriod.Cbo);
			ClsComboBoxes.CboLoadActives(frmPacki.cboFinal, Payroll_AttendancePeriod.Cbo);

			DateTime hoy = DateTime.Today;

			for (int i = 0; i < frmPacki.cboSemana.Items.Count; i++)
			{
				DataRowView row = (DataRowView)frmPacki.cboSemana.Items[i];

				if (row[Payroll_AttendancePeriod.ColumnStartDate] == DBNull.Value ||
					row[Payroll_AttendancePeriod.ColumnEndDate] == DBNull.Value)
				{
					continue;
				}

				DateTime fechaInicio = Convert.ToDateTime(row[Payroll_AttendancePeriod.ColumnStartDate]);
				DateTime fechaFin = Convert.ToDateTime(row[Payroll_AttendancePeriod.ColumnEndDate]);

				if (hoy >= fechaInicio && hoy <= fechaFin)
				{
					frmPacki.cboSemana.SelectedIndex = i;
					frmPacki.cboFinal.SelectedIndex = i; 
					break;
				}
			}
		}
		public void CargarTemporada()
		{
			ClsComboBoxes.CboLoadActives(frmPacki.cboTemporada, Season.CboWithDates);
			
			DateTime hoy = DateTime.Today;

			for (int i = 0; i < frmPacki.cboTemporada.Items.Count; i++)
			{
				DataRowView row = frmPacki.cboTemporada.Items[i] as DataRowView;

				if (row == null)
					continue;

				if (!row.Row.Table.Columns.Contains(Season.ColumnStartDate) ||
					!row.Row.Table.Columns.Contains(Season.ColumnEndDate))
					continue;

				if (row[Season.ColumnStartDate] == DBNull.Value ||
					row[Season.ColumnEndDate] == DBNull.Value)
					continue;

				DateTime fechaInicio = Convert.ToDateTime(row[Season.ColumnStartDate]);
				DateTime fechaFin = Convert.ToDateTime(row[Season.ColumnEndDate]);

				if (hoy >= fechaInicio && hoy <= fechaFin)
				{
					frmPacki.cboTemporada.SelectedIndex = i;
					return;
				}
			}
		}

		public void ExportarDGVHorasExcel(DataGridView dgv)
		{
			if (dgv.Rows.Count == 0)
			{
				MessageBox.Show("No hay datos para exportar");
				return;
			}

			using (SaveFileDialog sfd = new SaveFileDialog())
			{
				sfd.Filter = "Excel (*.xlsx)|*.xlsx";
				sfd.FileName = "Reporte_Horarios.xlsx";

				if (sfd.ShowDialog() != DialogResult.OK)
					return;

				string ruta = sfd.FileName;

				using (XLWorkbook wb = new XLWorkbook())
				{
					var ws = wb.Worksheets.Add("Horarios");

					//  SOLO COLUMNAS VISIBLES
					var columnas = dgv.Columns
						.Cast<DataGridViewColumn>()
						.Where(c => c.Visible)
						.ToList();

					int fila = 1;

					//  TITULO
					ws.Cell(fila, 1).Value = "REGISTRO DE HORAS TRABAJADAS";
					ws.Range(fila, 1, fila, columnas.Count).Merge();
					ws.Cell(fila, 1).Style.Font.Bold = true;
					ws.Cell(fila, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

					fila++;
					ws.Cell(fila, 1).Value = "UVEX AGRO INTERNACIONAL";
					ws.Range(fila, 1, fila, columnas.Count).Merge();
					ws.Cell(fila, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

					fila += 2;

					//  COLORES (los mismos del grid)
					var colorComida = XLColor.FromArgb(200, 225, 255);
					var colorCena = XLColor.FromArgb(220, 235, 255);
					var colorDescanso = XLColor.FromArgb(240, 245, 255);

					//  ENCABEZADOS AGRUPADOS
					int col = 4;


					ws.Range(fila, col, fila, col + 3).Merge();

					// COMIDA
					ws.Range(fila, col, fila, col + 2).Merge().Value = "COMIDA";
					ws.Range(fila, col, fila, col + 2).Style.Fill.BackgroundColor = colorComida;
					col += 3;

					// CENA
					ws.Range(fila, col, fila, col + 2).Merge().Value = "CENA";
					ws.Range(fila, col, fila, col + 2).Style.Fill.BackgroundColor = colorCena;
					col += 3;

					// DESCANSO
					ws.Range(fila, col, fila, col + 2).Merge().Value = "DESCANSO";
					ws.Range(fila, col, fila, col + 2).Style.Fill.BackgroundColor = colorDescanso;
					col += 3;

			
					ws.Range(fila, col, fila, col + 3).Merge();

					ws.Range(fila, 1, fila, columnas.Count).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
					ws.Range(fila, 1, fila, columnas.Count).Style.Font.Bold = true;

					fila++;

					//  SUBENCABEZADOS (los reales del grid)
					for (int i = 0; i < columnas.Count; i++)
					{
						var colName = columnas[i].Name;
						var cell = ws.Cell(fila, i + 1);

						cell.Value = columnas[i].HeaderText;
						cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

						if (colName.Contains("Comida"))
							cell.Style.Fill.BackgroundColor = colorComida;
						else if (colName.Contains("Cena"))
							cell.Style.Fill.BackgroundColor = colorCena;
						else if (colName.Contains("Descanso"))
							cell.Style.Fill.BackgroundColor = colorDescanso;
					}

					fila++;

					//  DATOS
					for (int i = 0; i < dgv.Rows.Count; i++)
					{
						if (dgv.Rows[i].IsNewRow) continue;

						for (int j = 0; j < columnas.Count; j++)
						{
							var colGrid = columnas[j];
							var valor = dgv.Rows[i].Cells[colGrid.Name].Value;
							var cell = ws.Cell(fila, j + 1);

							// FECHA FORMATO
							if (colGrid.Name == "Fecha" && valor != null)
							{
								cell.Value = Convert.ToDateTime(valor);
								cell.Style.DateFormat.Format = "dd/MM/yyyy";
							}
							else
							{
								cell.Value = valor?.ToString();
							}

							cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

							// COLOR POR GRUPO
							if (colGrid.Name.Contains("Comida"))
								cell.Style.Fill.BackgroundColor = colorComida;
							else if (colGrid.Name.Contains("Cena"))
								cell.Style.Fill.BackgroundColor = colorCena;
							else if (colGrid.Name.Contains("Descanso"))
								cell.Style.Fill.BackgroundColor = colorDescanso;
						}

						fila++;
					}

					//  BORDES
					var rango = ws.Range(5, 1, fila - 1, columnas.Count);
					rango.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
					rango.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

					//  AJUSTE
					ws.Column(1).Width = 35; // Cuadrilla
					ws.Column(2).Width = 12; // Fecha
					ws.Column(3).Width = 22; // Inicio Normal

					for (int i = 4; i <= 12; i++)
						ws.Column(i).Width = 10;

					ws.Column(13).Width = 20;
					ws.Column(14).Width = 20;
					ws.Column(15).Width = 20;
					ws.Column(16).Width = 12;
					ws.Column(13).AdjustToContents();
					ws.Column(14).AdjustToContents();
					ws.Column(15).AdjustToContents();

					int colInicio = columnas.Count + 2; 
					int filaInicio = 6;
					int filaDatosInicio = fila; 
					AgregarTablaComprobacion(ws, dgv, colInicio, filaInicio);

					if (File.Exists(ruta))
					{
						try
						{
							File.Delete(ruta);
						}
						catch
						{
							MessageBox.Show("Cierra el archivo de Excel antes de generar uno nuevo.");
							return;
						}
					}

					wb.SaveAs(ruta);
				}

				DialogResult result = MessageBox.Show(
					"Excel generado correctamente.\n¿Deseas abrirlo?",
					"Abrir archivo",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question
				);

				if (result == DialogResult.Yes)
				{
					Process.Start(new ProcessStartInfo()
					{
						FileName = ruta,
						UseShellExecute = true
					});
				}
			}
		}
		private TimeSpan CalcularHoras(object inicio, object fin)
		{
			if (inicio == null || fin == null)
				return TimeSpan.Zero;

			//  Intentar como DateTime
			if (DateTime.TryParse(inicio.ToString(), out DateTime i) &&
				DateTime.TryParse(fin.ToString(), out DateTime f))
			{
				if (f > i)
					return f - i;
			}

			//  Intentar como TimeSpan (ej: "01:00:00")
			if (TimeSpan.TryParse(inicio.ToString(), out TimeSpan ti) &&
				TimeSpan.TryParse(fin.ToString(), out TimeSpan tf))
			{
				if (tf > ti)
					return tf - ti;
			}

			return TimeSpan.Zero;
		}
		private TimeSpan ObtenerHoras(object valor)
		{
			if (valor == null) return TimeSpan.Zero;

			double horas;

			if (double.TryParse(valor.ToString(), out horas))
			{
				return TimeSpan.FromHours(horas);
			}

			return TimeSpan.Zero;
		}
		private void AgregarTablaComprobacion(IXLWorksheet ws, DataGridView dgv, int colInicio, int filaInicio)
		{
			//  TITULO
			ws.Cell(filaInicio - 2, colInicio).Value = "COMPROBACION";
			ws.Range(filaInicio - 2, colInicio, filaInicio - 2, colInicio + 4).Merge();
			ws.Cell(filaInicio - 2, colInicio).Style.Font.Bold = true;
			ws.Cell(filaInicio - 2, colInicio).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
			ws.Cell(filaInicio - 2, colInicio).Style.Fill.BackgroundColor = XLColor.MidnightBlue;
			ws.Cell(filaInicio - 2, colInicio).Style.Font.FontColor = XLColor.White;

			//  ENCABEZADOS
			string[] headers = { "TOTAL", "COMIDA", "CENA", "DESCANSO", "JORNADA REAL" };

			for (int i = 0; i < headers.Length; i++)
			{
				var cell = ws.Cell(filaInicio - 1, colInicio + i);
				cell.Value = headers[i];
				cell.Style.Fill.BackgroundColor = XLColor.MidnightBlue;
				cell.Style.Font.FontColor = XLColor.White;
				cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
				cell.Style.Font.Bold = true;
			}

			int filaExcel = filaInicio;

			foreach (DataGridViewRow row in dgv.Rows)
			{
				if (row.IsNewRow) continue;

				//  NORMAL
				TimeSpan normal = CalcularHoras(
					row.Cells["InicioNormal"].Value,
					row.Cells["FinNormal"].Value
				);

				//  EXTRA
				TimeSpan extra = CalcularHoras(
					row.Cells["InicioExtra"].Value,
					row.Cells["FinExtra"].Value
				);

				//  TOTAL
				TimeSpan total = normal + extra;

				//  COMIDA / CENA / DESCANSO
				TimeSpan comida = ObtenerHoras(row.Cells["HorasComida"].Value);
				TimeSpan cena = ObtenerHoras(row.Cells["HorasCena"].Value);
				TimeSpan descanso = ObtenerHoras(row.Cells["HorasDescanso"].Value);

				//  JORNADA REAL
				TimeSpan jornada = total - comida - cena - descanso;

				//  VALIDACIÓN
				if (jornada < TimeSpan.Zero)
					jornada = TimeSpan.Zero;

				//  INSERTAR EN EXCEL (FORMA CORRECTA)
				ws.Cell(filaExcel, colInicio).Value = total.TotalDays;
				ws.Cell(filaExcel, colInicio + 1).Value = comida.TotalDays;
				ws.Cell(filaExcel, colInicio + 2).Value = cena.TotalDays;
				ws.Cell(filaExcel, colInicio + 3).Value = descanso.TotalDays;
				ws.Cell(filaExcel, colInicio + 4).Value = jornada.TotalDays;

				//  FORMATO
				for (int i = 0; i < 5; i++)
				{
					var cell = ws.Cell(filaExcel, colInicio + i);
					cell.Style.NumberFormat.Format = "[hh]:mm"; // 🔥 clave
					cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
				}

				filaExcel++;
			}

			//  BORDES
			var rango = ws.Range(filaInicio - 1, colInicio, filaExcel - 1, colInicio + 4);
			rango.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
			rango.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

			//  ANCHO (evita ####)
			for (int i = 0; i < 5; i++)
			{
				ws.Column(colInicio + i).Width = 12;
				ws.Column(colInicio + 4).AdjustToContents();
			}
		}
	}
}
