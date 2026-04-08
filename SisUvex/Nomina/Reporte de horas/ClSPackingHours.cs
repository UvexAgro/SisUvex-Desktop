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

			if (sfd.ShowDialog() == DialogResult.OK)
			{
				string ruta = sfd.FileName;

				using (XLWorkbook wb = new XLWorkbook())
				{
					var ws = wb.Worksheets.Add("Horarios");

					int fila = 1;

					//  TÍTULO
					ws.Cell(fila, 1).Value = "REPORTE DE HORARIOS";
					ws.Range(fila, 1, fila, dgv.Columns.Count).Merge();
					ws.Cell(fila, 1).Style.Font.Bold = true;
					ws.Cell(fila, 1).Style.Font.FontSize = 16;
					ws.Cell(fila, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

					fila += 2;

					//  ENCABEZADOS
					for (int i = 0; i < dgv.Columns.Count; i++)
					{
						var cell = ws.Cell(fila, i + 1);
						cell.Value = dgv.Columns[i].HeaderText;

						cell.Style.Font.Bold = true;
						cell.Style.Font.FontColor = XLColor.Black;
						cell.Style.Fill.BackgroundColor = XLColor.FromHtml("#34495E"); // oscuro
						cell.Style.Font.FontColor = XLColor.White; // letras blancas
						cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
					}

					fila++;

					//  DATOS
					for (int i = 0; i < dgv.Rows.Count; i++)
					{
						if (dgv.Rows[i].IsNewRow) continue;

						for (int j = 0; j < dgv.Columns.Count; j++)
						{
							var valor = dgv.Rows[i].Cells[j].Value;
							var cell = ws.Cell(fila, j + 1);

							//  FORMATO FECHA
							if (dgv.Columns[j].Name == "Fecha" && valor != null)
							{
								DateTime fecha = Convert.ToDateTime(valor);
								cell.Value = fecha;
								cell.Style.DateFormat.Format = "dd/MM/yyyy";
							}
							else
							{
								cell.Value = valor?.ToString();
							}

							cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
						}

						fila++;
					}

					//  BORDES
					var rango = ws.Range(3, 1, fila - 1, dgv.Columns.Count);
					rango.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
					rango.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

					//  AJUSTAR COLUMNAS
					ws.Columns().AdjustToContents();

					wb.SaveAs(ruta);
				}

				//  PREGUNTAR SI ABRIR
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
	}
}
}