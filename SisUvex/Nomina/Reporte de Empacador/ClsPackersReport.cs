using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ClosedXML.Excel;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Nomina.Nom_semAutomatizada;
using static SisUvex.Catalogos.Metods.ClsObject;

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
			string fechaInicio = frmPack.dtpFecha1.Value.ToString("yyyy-MM-dd");
			string fechaFin = frmPack.dtpFecha2.Value.ToString("yyyy-MM-dd");
			string idEmpleado = frmPack.txbCodigo.Text.Trim();
			string linea = frmPack.cboLineas.SelectedValue.ToString();

			if (string.IsNullOrEmpty(idEmpleado))
			{
				MessageBox.Show("Ingrese un empleado");
				return;
			}

			string queryFinal = $@"
			SELECT *
			FROM dbo.fn_PackersReport(
			'{fechaInicio}',
			'{fechaFin}',
			'{linea}',
			'{idEmpleado}'
			)
			ORDER BY Fecha";

			DataTable dt = ClsQuerysDB.GetDataTable(queryFinal);

			frmPack.dgvEmployee.DataSource = dt;

			if (dt.Rows.Count > 0)
				frmPack.txbNombre.Text = dt.Rows[0]["NombreCompleto"].ToString();
			else
				frmPack.txbNombre.Text = "";
		}
		public void ExportarExcelPorEmpacador()
		{
			if (frmPack.dgvEmployee.Rows.Count == 0)
			{
				MessageBox.Show("No hay datos para exportar.");
				return;
			}

			string codigo = frmPack.txbCodigo.Text.Trim();
			string nombre = frmPack.txbNombre.Text.Trim();

			DateTime fechaInicio = frmPack.dtpFecha1.Value;
			DateTime fechaFin = frmPack.dtpFecha2.Value;

			string nombreArchivo = $"Reporte {codigo} {nombre} {fechaInicio:dd-MM-yyyy} al {fechaFin:dd-MM-yyyy}.xlsx";

			using (SaveFileDialog sfd = new SaveFileDialog())
			{
				sfd.Filter = "Excel (*.xlsx)|*.xlsx";
				sfd.FileName = nombreArchivo;

				if (sfd.ShowDialog() == DialogResult.OK)
				{
					using (XLWorkbook wb = new XLWorkbook())
					{
						var ws = wb.Worksheets.Add("Reporte");

						DataTable dt = (DataTable)frmPack.dgvEmployee.DataSource;

						var dias = dt.AsEnumerable()
							.Select(r => Convert.ToDateTime(r["Fecha"]).Date)
							.Distinct()
							.OrderBy(d => d)
							.ToList();

						int fila = 1;

						int totalColumnas = dias.Count + 4;

						// ===== EMPLEADO =====
						ws.Cell(fila, 1).Value = $"Empleado: {codigo} - {nombre}";
						ws.Range(fila, 1, fila, totalColumnas).Merge();
						ws.Range(fila, 1, fila, totalColumnas).Style.Font.Bold = true;
						ws.Range(fila, 1, fila, totalColumnas).Style.Fill.BackgroundColor = XLColor.LightGray;
						fila++;

						// ===== PERIODO =====
						ws.Cell(fila, 1).Value =
							$"Periodo: {frmPack.dtpFecha1.Value:dd/MM/yyyy} al {frmPack.dtpFecha2.Value:dd/MM/yyyy}";
						ws.Range(fila, 1, fila, totalColumnas).Merge();
						fila += 2;

						// ===== ENCABEZADOS =====
						ws.Cell(fila, 1).Value = "Tamaño";
						ws.Cell(fila, 2).Value = "Presentación";
						ws.Cell(fila, 3).Value = "Tipo";

						int col = 4;

						foreach (var dia in dias)
						{
							ws.Cell(fila, col).Value =
								dia.ToString("ddd", new System.Globalization.CultureInfo("es-MX")).ToUpper();
							col++;
						}

						ws.Cell(fila, col).Value = "TOTAL";

						ws.Range(fila, 1, fila, col).Style.Font.Bold = true;
						ws.Range(fila, 1, fila, col).Style.Fill.BackgroundColor = XLColor.FromHtml("#1F4E78");
						ws.Range(fila, 1, fila, col).Style.Font.FontColor = XLColor.White;
						ws.Range(fila, 1, fila, col).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

						fila++;

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
							// NORMAL
							ws.Cell(fila, 1).Value = grupo.Key.Tamaño;
							ws.Cell(fila, 2).Value = grupo.Key.Presentacion;
							ws.Cell(fila, 3).Value = "Normal";

							col = 4;
							int totalNormal = 0;

							foreach (var dia in dias)
							{
								int normal = grupo
									.Where(r => Convert.ToDateTime(r["Fecha"]).Date == dia)
									.Sum(r => Convert.ToInt32(r["CajasNormal"]));

								ws.Cell(fila, col).Value = normal == 0 ? "" : normal;
								ws.Cell(fila, col).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

								totalNormal += normal;
								col++;
							}

							ws.Cell(fila, col).Value = totalNormal;
							ws.Cell(fila, col).Style.Font.Bold = true;

							fila++;

							// EXTRA
							int totalExtraGrupo = grupo.Sum(r => Convert.ToInt32(r["CajasExtra"]));

							if (totalExtraGrupo > 0)
							{
								ws.Cell(fila, 3).Value = "Extra";

								col = 4;
								int totalExtra = 0;

								foreach (var dia in dias)
								{
									int extra = grupo
										.Where(r => Convert.ToDateTime(r["Fecha"]).Date == dia)
										.Sum(r => Convert.ToInt32(r["CajasExtra"]));

									ws.Cell(fila, col).Value = extra == 0 ? "" : extra;
									ws.Cell(fila, col).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

									totalExtra += extra;
									col++;
								}

								ws.Cell(fila, col).Value = totalExtra;
								ws.Cell(fila, col).Style.Font.Bold = true;

								fila++;
							}
						}

						ws.Columns().AdjustToContents();

						try
						{
							wb.SaveAs(sfd.FileName);
						}
						catch
						{
							MessageBox.Show("El archivo está abierto. Cierre Excel e intente nuevamente.");
							return;
						}
					}

					DialogResult result = MessageBox.Show(
						"Excel generado correctamente.\n\n¿Desea abrirlo?",
						"Abrir archivo",
						MessageBoxButtons.YesNo,
						MessageBoxIcon.Question);

					if (result == DialogResult.Yes)
					{
						Process.Start(new ProcessStartInfo(sfd.FileName)
						{
							UseShellExecute = true
						});
					}
				}
			}
		}
		public void ExportarExcelPorLinea()
		{
			string linea = frmPack.cboLineas.SelectedValue.ToString();
			DateTime fechaInicio = frmPack.dtpFecha1.Value;
			DateTime fechaFin = frmPack.dtpFecha2.Value;

			string query = $@"
			SELECT *
			FROM dbo.fn_PackersReport(
			'{fechaInicio:yyyy-MM-dd}',
			'{fechaFin:yyyy-MM-dd}',
			'{linea}',
			NULL
			)
			ORDER BY CodigoEmpleado, Fecha";

			DataTable dt = ClsQuerysDB.GetDataTable(query);

			if (dt.Rows.Count == 0)
			{
				MessageBox.Show("No hay datos para exportar.");
				return;
			}

			string fechaHora = DateTime.Now.ToString("yyyyMMdd");
			string nombreArchivo = $"Reporte Linea {linea} {fechaInicio:yyyy-MM-dd} al {fechaFin:yyyy-MM-dd}.xlsx";

			using (SaveFileDialog sfd = new SaveFileDialog())
			{
				sfd.Filter = "Excel (*.xlsx)|*.xlsx";
				sfd.FileName = nombreArchivo;

				if (sfd.ShowDialog() == DialogResult.OK)
				{
					using (XLWorkbook wb = new XLWorkbook())
					{
						var empleados = dt.AsEnumerable()
							.GroupBy(r => new
							{
								Codigo = r["CodigoEmpleado"].ToString(),
								Nombre = r["NombreCompleto"].ToString()
							})
							.ToList();

						
						for (int i = 0; i < empleados.Count; i += 3)
						{
							var ws = wb.Worksheets.Add($"Hoja_{(i / 2) + 1}");
							int fila = 1;

							void ImprimirEmpleado(IGrouping<dynamic, DataRow> emp)
							{
								var dias = emp
									.Select(r => Convert.ToDateTime(r["Fecha"]).Date)
									.Distinct()
									.OrderBy(d => d)
									.ToList();

								var datosAgrupados = emp
									.GroupBy(r => new
									{
										Tamaño = r["Tamaño"].ToString(),
										Presentacion = r["Presentacion"].ToString()
									})
									.ToList();

								int totalColumnas = dias.Count + 4;
								int inicioBloque = fila;

								// ===== ENCABEZADO EMPLEADO =====
								ws.Cell(fila, 1).Value =
									$"Empleado: {emp.Key.Codigo} - {emp.Key.Nombre}";
								ws.Range(fila, 1, fila, totalColumnas).Merge();
								ws.Range(fila, 1, fila, totalColumnas).Style.Font.Bold = true;
								ws.Range(fila, 1, fila, totalColumnas).Style.Fill.BackgroundColor =
									XLColor.FromHtml("#E7E6E6");
								fila++;

								// ===== PERIODO =====
								ws.Cell(fila, 1).Value =
									$"Periodo: {fechaInicio:dd/MM/yyyy} al {fechaFin:dd/MM/yyyy}";
								ws.Range(fila, 1, fila, totalColumnas).Merge();
								fila += 2;

								// ===== ENCABEZADOS TABLA =====
								ws.Cell(fila, 1).Value = "Tamaño";
								ws.Cell(fila, 2).Value = "Presentación";
								ws.Cell(fila, 3).Value = "Tipo";

								int col = 4;

								foreach (var dia in dias)
								{
									ws.Cell(fila, col).Value =
										dia.ToString("ddd", new System.Globalization.CultureInfo("es-MX")).ToUpper();
									col++;
								}

								ws.Cell(fila, col).Value = "TOTAL";

								ws.Range(fila, 1, fila, col).Style.Font.Bold = true;
								ws.Range(fila, 1, fila, col).Style.Fill.BackgroundColor =
									XLColor.FromHtml("#1F4E78");
								ws.Range(fila, 1, fila, col).Style.Font.FontColor = XLColor.White;
								ws.Range(fila, 1, fila, col).Style.Alignment.Horizontal =
									XLAlignmentHorizontalValues.Center;

								fila++;

								// ===== DATOS =====
								foreach (var grupo in datosAgrupados)
								{
									// NORMAL
									ws.Cell(fila, 1).Value = grupo.Key.Tamaño;
									ws.Cell(fila, 2).Value = grupo.Key.Presentacion;
									ws.Cell(fila, 3).Value = "Normal";

									col = 4;
									int totalNormal = 0;

									foreach (var dia in dias)
									{
										int normal = grupo
											.Where(r => Convert.ToDateTime(r["Fecha"]).Date == dia)
											.Sum(r => Convert.ToInt32(r["CajasNormal"]));

										ws.Cell(fila, col).Value = normal == 0 ? "" : normal;
										ws.Cell(fila, col).Style.Alignment.Horizontal =
											XLAlignmentHorizontalValues.Center;

										totalNormal += normal;
										col++;
									}

									ws.Cell(fila, col).Value = totalNormal;
									ws.Cell(fila, col).Style.Font.Bold = true;
									fila++;

									// EXTRA (solo si hay)
									int totalExtraGrupo =
										grupo.Sum(r => Convert.ToInt32(r["CajasExtra"]));

									if (totalExtraGrupo > 0)
									{
										ws.Cell(fila, 3).Value = "Extra";

										col = 4;
										int totalExtra = 0;

										foreach (var dia in dias)
										{
											int extra = grupo
												.Where(r => Convert.ToDateTime(r["Fecha"]).Date == dia)
												.Sum(r => Convert.ToInt32(r["CajasExtra"]));

											ws.Cell(fila, col).Value = extra == 0 ? "" : extra;
											ws.Cell(fila, col).Style.Alignment.Horizontal =
												XLAlignmentHorizontalValues.Center;

											totalExtra += extra;
											col++;
										}

										ws.Cell(fila, col).Value = totalExtra;
										ws.Cell(fila, col).Style.Font.Bold = true;
										fila++;
									}
								}

								// ===== BORDE SOLO EXTERIOR (SIN LINEAS INTERNAS) =====
								ws.Range(inicioBloque, 1, fila - 1, totalColumnas)
									.Style.Border.OutsideBorder = XLBorderStyleValues.Medium;

								fila = inicioBloque + 26; // Espacio entre empleados
							}

							ImprimirEmpleado(empleados[i]);

							if (i + 1 < empleados.Count)
								ImprimirEmpleado(empleados[i + 1]);

							//if (i + 2 < empleados.Count)
							//	ImprimirEmpleado(empleados[i + 2]);

							ws.Columns().AdjustToContents();
						}

						wb.SaveAs(sfd.FileName);

						try
						{
							wb.SaveAs(sfd.FileName);
						}
						catch
						{
							MessageBox.Show("El archivo está abierto. Cierre Excel e intente nuevamente.");
							return;
						}
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