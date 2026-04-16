using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ClosedXML.Excel;
using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using MathNet.Numerics.RootFinding;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Nomina.Nom_semAutomatizada;
using static SisUvex.Catalogos.Metods.ClsObject;
using SisUvex.Catalogos.Metods.Extentions;

namespace SisUvex.Nomina.Reporte_de_Empacador
{
	internal class ClsPackersReport
	{
		public FrmPackersReport frmPack;
		ClsControls controlList;
		public void LineadeProduccion()
		{

			ClsComboBoxes.CboLoadActives(frmPack.cboLineas, ClsObject.ProductionLine.Cbo);

		}
		public void ObtenerPackersReport()
		{
			try
			{
				string idEmpleado = frmPack.txbCodigo.Text.Trim();
				string linea = frmPack.cboLineas.SelectedValue?.ToString();

				if (string.IsNullOrEmpty(idEmpleado))
				{
					MessageBox.Show("Ingrese un empleado");
					frmPack.txbCodigo.Focus();
					return;
				}

				if (string.IsNullOrEmpty(linea))
				{
					MessageBox.Show("Seleccione una línea");
					return;
				}

				if (frmPack.cboSemana.SelectedItem == null)
				{
					MessageBox.Show("Seleccione una semana.");
					return;
				}

				DataRowView row = (DataRowView)frmPack.cboSemana.SelectedItem;

				DateTime fechaInicio = Convert.ToDateTime(row[Payroll_AttendancePeriod.ColumnStartDate]);
				DateTime fechaFin = Convert.ToDateTime(row[Payroll_AttendancePeriod.ColumnEndDate]);

				string query = $@"
				SELECT *
				FROM dbo.fn_PackersReport(
				'{fechaInicio:yyyy-MM-dd}',
				'{fechaFin:yyyy-MM-dd}',
				'{linea}',
				'{idEmpleado}')
				ORDER BY CodigoEmpleado, Fecha";

				DataTable dt = ClsQuerysDB.GetDataTable(query);

				frmPack.dgvEmployee.DataSource = dt;

				if (dt.Rows.Count > 0)
				{
					frmPack.txbNombre.Text = dt.Rows[0]["NombreCompleto"].ToString();
				}
				else
				{
					frmPack.txbNombre.Text = "";
					MessageBox.Show("No se encontraron registros.");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error al obtener datos:\n" + ex.Message);
			}
		}
		public void CargarPeriodos()
		{
			ClsComboBoxes.CboLoadActives(frmPack.cboSemana, Payroll_AttendancePeriod.Cbo);

			DateTime hoy = DateTime.Today;

			for (int i = 0; i < frmPack.cboSemana.Items.Count; i++)
			{
				DataRowView row = (DataRowView)frmPack.cboSemana.Items[i];

				if (row[Payroll_AttendancePeriod.ColumnStartDate] == DBNull.Value ||
					row[Payroll_AttendancePeriod.ColumnEndDate] == DBNull.Value)
				{
					continue;
				}

				DateTime fechaInicio = Convert.ToDateTime(row[Payroll_AttendancePeriod.ColumnStartDate]);
				DateTime fechaFin = Convert.ToDateTime(row[Payroll_AttendancePeriod.ColumnEndDate]);

				if (hoy >= fechaInicio && hoy <= fechaFin)
				{
					frmPack.cboSemana.SelectedIndex = i;
					break;
				}
			}
		}
		public void ExportarPdfPorEmpacador()
		{
			try
			{
				// Obtener datos del reporte desde el DataGridView
				DataTable dt = frmPack.dgvEmployee.DataSource as DataTable;

				if (dt == null || dt.Rows.Count == 0)
				{
					MessageBox.Show("No hay datos para exportar.");
					return;
				}

				string codigo = frmPack.txbCodigo.Text.Trim();
				string nombre = frmPack.txbNombre.Text.Trim();

				// Obtener fechas desde el ComboBox de semanas
				DataRowView row = (DataRowView)frmPack.cboSemana.SelectedItem;

				DateTime fechaInicio = Convert.ToDateTime(row[Payroll_AttendancePeriod.ColumnStartDate]);
				DateTime fechaFin = Convert.ToDateTime(row[Payroll_AttendancePeriod.ColumnEndDate]);

				string nombreArchivo = $"Reporte {codigo} {nombre} {fechaInicio:dd-MM-yyyy} al {fechaFin:dd-MM-yyyy}.pdf";

				using (SaveFileDialog sfd = new SaveFileDialog())
				{
					sfd.Filter = "PDF (*.pdf)|*.pdf";
					sfd.FileName = nombreArchivo;

					if (sfd.ShowDialog() != DialogResult.OK)
						return;

					// Obtener días del reporte
					var dias = dt.AsEnumerable()
						.Where(r => r["Fecha"] != DBNull.Value)
						.Select(r => Convert.ToDateTime(r["Fecha"]).Date)
						.Distinct()
						.OrderBy(d => d)
						.ToList();

					PdfWriter writer = new PdfWriter(sfd.FileName);
					PdfDocument pdf = new PdfDocument(writer);
					Document document = new Document(pdf);

					PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
					PdfFont fontBold = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

					int totalColumnas = dias.Count + 4;

					float[] columnWidths = new float[totalColumnas];
					for (int i = 0; i < totalColumnas; i++)
						columnWidths[i] = 1;

					Table table = new Table(columnWidths);
					table.SetWidth(UnitValue.CreatePercentValue(100));

					// ===== EMPLEADO =====
					table.AddCell(
						new Cell(1, totalColumnas)
						.Add(new Paragraph($"Empleado: {codigo} - {nombre}").SetFont(fontBold))
						.SetBackgroundColor(ColorConstants.LIGHT_GRAY)
						.SetTextAlignment(TextAlignment.CENTER)
					);

					// ===== PERIODO =====
					table.AddCell(
						new Cell(1, totalColumnas)
						.Add(new Paragraph($"Periodo: {fechaInicio:dd/MM/yyyy} al {fechaFin:dd/MM/yyyy}").SetFont(font))
						.SetTextAlignment(TextAlignment.CENTER)
					);

					// ===== ENCABEZADOS =====
					table.AddCell(new Paragraph("Tamaño").SetFont(fontBold));
					table.AddCell(new Paragraph("Presentación").SetFont(fontBold));
					table.AddCell(new Paragraph("Tipo").SetFont(fontBold));

					foreach (var dia in dias)
					{
						string nombreDia = dia
							.ToString("ddd", new System.Globalization.CultureInfo("es-MX"))
							.ToUpper();

						table.AddCell(
							new Cell()
							.Add(new Paragraph(nombreDia).SetFont(fontBold))
							.SetTextAlignment(TextAlignment.CENTER));
					}

					table.AddCell(
						new Cell()
						.Add(new Paragraph("TOTAL").SetFont(fontBold))
						.SetTextAlignment(TextAlignment.CENTER));

					// ===== AGRUPAR DATOS =====
					var datosAgrupados = dt.AsEnumerable()
						.GroupBy(r => new
						{
							Tamaño = r["Tamaño"].ToString(),
							Presentacion = r["Presentacion"].ToString()
						})
						.ToList();

					foreach (var grupo in datosAgrupados)
					{
						table.AddCell(new Paragraph(grupo.Key.Tamaño).SetFont(font));
						table.AddCell(new Paragraph(grupo.Key.Presentacion).SetFont(font));
						table.AddCell(new Paragraph("Normal").SetFont(font));

						int totalNormal = 0;

						foreach (var dia in dias)
						{
							int normal = grupo
								.Where(r => Convert.ToDateTime(r["Fecha"]).Date == dia)
								.Sum(r => r["CajasNormal"] == DBNull.Value ? 0 : Convert.ToInt32(r["CajasNormal"]));

							table.AddCell(
								new Cell()
								.Add(new Paragraph(normal == 0 ? "" : normal.ToString()).SetFont(font))
								.SetTextAlignment(TextAlignment.CENTER));

							totalNormal += normal;
						}

						table.AddCell(
							new Cell()
							.Add(new Paragraph(totalNormal.ToString()).SetFont(fontBold))
							.SetTextAlignment(TextAlignment.CENTER));

						int totalExtraGrupo = grupo.Sum(r => r["CajasExtra"] == DBNull.Value ? 0 : Convert.ToInt32(r["CajasExtra"]));

						if (totalExtraGrupo > 0)
						{
							table.AddCell("");
							table.AddCell("");
							table.AddCell(new Paragraph("Extra").SetFont(font));

							int totalExtra = 0;

							foreach (var dia in dias)
							{
								int extra = grupo
									.Where(r => Convert.ToDateTime(r["Fecha"]).Date == dia)
									.Sum(r => r["CajasExtra"] == DBNull.Value ? 0 : Convert.ToInt32(r["CajasExtra"]));

								table.AddCell(
									new Cell()
									.Add(new Paragraph(extra == 0 ? "" : extra.ToString()).SetFont(font))
									.SetTextAlignment(TextAlignment.CENTER));

								totalExtra += extra;
							}

							table.AddCell(
								new Cell()
								.Add(new Paragraph(totalExtra.ToString()).SetFont(fontBold))
								.SetTextAlignment(TextAlignment.CENTER));
						}
					}

					document.Add(table);
					document.Close();

					if (MessageBox.Show("PDF generado correctamente.\n¿Desea abrirlo?",
						"Abrir archivo",
						MessageBoxButtons.YesNo,
						MessageBoxIcon.Question) == DialogResult.Yes)
					{
						Process.Start(new ProcessStartInfo(sfd.FileName)
						{
							UseShellExecute = true
						});
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error al generar el PDF:\n" + ex.Message);
			}
		}
		public void ExportarPdfPorLinea()
		{
			string linea = frmPack.cboLineas.SelectedValue?.ToString();

			string lineaSql = "NULL";

			if (!string.IsNullOrEmpty(linea) && linea != "0")
			{
				lineaSql = $"'{linea}'";
			}

			// Obtener semana y fechas desde el ComboBox
			DateTime fechaInicio = Convert.ToDateTime(frmPack.cboSemana.GetColumnValue(Payroll_AttendancePeriod.ColumnStartDate));
			DateTime fechaFin = Convert.ToDateTime(frmPack.cboSemana.GetColumnValue(Payroll_AttendancePeriod.ColumnEndDate));

			string query = $@"
			SELECT *
			FROM dbo.fn_PackersReport(
			'{fechaInicio:yyyy-MM-dd}',
			'{fechaFin:yyyy-MM-dd}',
			{lineaSql},
			NULL)
			ORDER BY CodigoEmpleado, Fecha";

			DataTable dt = ClsQuerysDB.GetDataTable(query);

			if (dt.Rows.Count == 0)
			{
				MessageBox.Show("No hay datos para exportar.");
				return;
			}

			string nombreArchivo =
			$"Reporte Linea {linea} {fechaInicio:yyyy-MM-dd} al {fechaFin:yyyy-MM-dd}.pdf";

			using (SaveFileDialog sfd = new SaveFileDialog())
			{
				sfd.Filter = "PDF (*.pdf)|*.pdf";
				sfd.FileName = nombreArchivo;

				if (sfd.ShowDialog() == DialogResult.OK)
				{
					try
					{
						PdfWriter writer = new PdfWriter(sfd.FileName);
						PdfDocument pdf = new PdfDocument(writer);
						Document document = new Document(pdf);

						PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
						PdfFont fontBold = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

						var empleados = dt.AsEnumerable()
						.GroupBy(r => new
						{
							Codigo = r["CodigoEmpleado"].ToString(),
							Nombre = r["NombreCompleto"].ToString()
						})
						.ToList();

						for (int i = 0; i < empleados.Count; i++)
						{
							var emp = empleados[i];

							var dias = emp
							.Select(r => Convert.ToDateTime(r["Fecha"]).Date)
							.Distinct()
							.OrderBy(d => d)
							.ToList();

							int totalColumnas = dias.Count + 4;

							float[] columnas = new float[totalColumnas];
							for (int c = 0; c < totalColumnas; c++)
								columnas[c] = 1;

							Table table = new Table(columnas);
							table.SetWidth(UnitValue.CreatePercentValue(100));

							// ===== EMPLEADO =====
							table.AddCell(
							new Cell(1, totalColumnas)
							.Add(new Paragraph($"Empleado: {emp.Key.Codigo} - {emp.Key.Nombre}")
							.SetFont(fontBold))
							.SetBackgroundColor(ColorConstants.LIGHT_GRAY)
							.SetTextAlignment(TextAlignment.CENTER));

							// ===== PERIODO =====
							table.AddCell(
							new Cell(1, totalColumnas)
							.Add(new Paragraph($"Periodo: {fechaInicio:dd/MM/yyyy} al {fechaFin:dd/MM/yyyy}")
							.SetFont(font))
							.SetTextAlignment(TextAlignment.CENTER));

							// ===== ENCABEZADOS =====
							table.AddCell(new Paragraph("Tamaño").SetFont(fontBold));
							table.AddCell(new Paragraph("Presentación").SetFont(fontBold));
							table.AddCell(new Paragraph("Tipo").SetFont(fontBold));

							foreach (var dia in dias)
							{
								string nombreDia = dia
								.ToString("ddd", new System.Globalization.CultureInfo("es-MX"))
								.ToUpper();

								table.AddCell(
								new Cell()
								.Add(new Paragraph(nombreDia).SetFont(fontBold))
								.SetTextAlignment(TextAlignment.CENTER));
							}

							table.AddCell(
							new Cell()
							.Add(new Paragraph("TOTAL").SetFont(fontBold))
							.SetTextAlignment(TextAlignment.CENTER));

							// ===== DATOS =====
							var datosAgrupados = emp
							.GroupBy(r => new
							{
								Tamaño = r["Tamaño"].ToString(),
								Presentacion = r["Presentacion"].ToString()
							})
							.ToList();

							foreach (var grupo in datosAgrupados)
							{
								table.AddCell(new Paragraph(grupo.Key.Tamaño).SetFont(font));
								table.AddCell(new Paragraph(grupo.Key.Presentacion).SetFont(font));
								table.AddCell(new Paragraph("Normal").SetFont(font));

								int totalNormal = 0;

								foreach (var dia in dias)
								{
									int normal = grupo
									.Where(r => Convert.ToDateTime(r["Fecha"]).Date == dia)
									.Sum(r => Convert.ToInt32(r["CajasNormal"]));

									table.AddCell(
									new Cell()
									.Add(new Paragraph(normal == 0 ? "" : normal.ToString()).SetFont(font))
									.SetTextAlignment(TextAlignment.CENTER));

									totalNormal += normal;
								}

								table.AddCell(
								new Cell()
								.Add(new Paragraph(totalNormal.ToString()).SetFont(fontBold))
								.SetTextAlignment(TextAlignment.CENTER));

								int totalExtraGrupo = grupo.Sum(r => Convert.ToInt32(r["CajasExtra"]));

								if (totalExtraGrupo > 0)
								{
									table.AddCell("");
									table.AddCell("");
									table.AddCell(new Paragraph("Extra").SetFont(font));

									int totalExtra = 0;

									foreach (var dia in dias)
									{
										int extra = grupo
										.Where(r => Convert.ToDateTime(r["Fecha"]).Date == dia)
										.Sum(r => Convert.ToInt32(r["CajasExtra"]));

										table.AddCell(
										new Cell()
										.Add(new Paragraph(extra == 0 ? "" : extra.ToString()).SetFont(font))
										.SetTextAlignment(TextAlignment.CENTER));

										totalExtra += extra;
									}

									table.AddCell(
									new Cell()
									.Add(new Paragraph(totalExtra.ToString()).SetFont(fontBold))
									.SetTextAlignment(TextAlignment.CENTER));
								}
							}

							document.Add(table);

							// ===== 2 EMPLEADOS POR HOJA =====
							if (i % 2 == 0)
							{
								Paragraph espacio = new Paragraph("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
								document.Add(espacio);
							}
							else
							{
								document.Add(new AreaBreak());
							}
						}

						document.Close();
					}
					catch
					{
						MessageBox.Show("Error al generar el PDF.");
						return;
					}

					if (MessageBox.Show("Reporte generado correctamente.\n¿Desea abrirlo?",
					"Abrir archivo",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question) == DialogResult.Yes)
					{
						Process.Start(new ProcessStartInfo(sfd.FileName)
						{
							UseShellExecute = true
						});
					}
				}
			}
		}
	}
}
