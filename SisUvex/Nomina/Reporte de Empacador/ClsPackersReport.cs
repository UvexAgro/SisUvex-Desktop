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
			string nombreLimpio = Regex.Replace(nombre, @"[^\w\s]", "").Replace(" ", "_");
			string fechaHora = DateTime.Now.ToString("yyyyMMdd_HHmmss");

			string nombreArchivo = $"Reporte_{codigo}_{nombreLimpio}.xlsx";

			using (SaveFileDialog sfd = new SaveFileDialog())
			{
				sfd.Filter = "Excel (*.xlsx)|*.xlsx";
				sfd.FileName = nombreArchivo;

				if (sfd.ShowDialog() == DialogResult.OK)
				{
					using (XLWorkbook wb = new XLWorkbook())
					{
						var ws = wb.Worksheets.Add("Reporte");


						ws.Cell("A1").Value = "REPORTE DE EMPACADOR";
						ws.Range("A1:D1").Merge();
						ws.Range("A1").Style.Font.Bold = true;
						ws.Range("A1").Style.Font.FontSize = 16;
						ws.Range("A1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;


						ws.Cell("A3").Value = "Empleado:";
						ws.Cell("B3").Value = $"{codigo} - {nombre}";

						ws.Cell("A4").Value = "Periodo:";
						ws.Cell("B4").Value = $"{frmPack.dtpFecha1.Value:dd/MM/yyyy} al {frmPack.dtpFecha2.Value:dd/MM/yyyy}";


						DataTable dtOriginal = (DataTable)frmPack.dgvEmployee.DataSource;
						DataTable dt = dtOriginal.Copy();

						if (dt.Columns.Contains("CodigoEmpleado"))
							dt.Columns.Remove("CodigoEmpleado");

						if (dt.Columns.Contains("NombreCompleto"))
							dt.Columns.Remove("NombreCompleto");

						int fila = 6;
						int totalGeneral = 0;

						var datosAgrupados = dt.AsEnumerable()
							.GroupBy(r => Convert.ToDateTime(r["Fecha"]).ToString("dd/MM/yyyy"))
							.OrderBy(g => g.Key);

						foreach (var grupo in datosAgrupados)
						{

							ws.Cell(fila, 1).Value = $"Fecha: {grupo.Key}";
							ws.Range(fila, 1, fila, 4).Merge();
							ws.Cell(fila, 1).Style.Font.Bold = true;
							ws.Cell(fila, 1).Style.Fill.BackgroundColor = XLColor.LightGray;
							fila++;


							ws.Cell(fila, 1).Value = "Presentación";
							ws.Cell(fila, 2).Value = "Normal";
							ws.Cell(fila, 3).Value = "Extra";
							ws.Cell(fila, 4).Value = "Total";

							ws.Range(fila, 1, fila, 4).Style.Font.Bold = true;
							ws.Range(fila, 1, fila, 4).Style.Fill.BackgroundColor = XLColor.FromHtml("#D9E1F2");
							ws.Range(fila, 1, fila, 4).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

							fila++;

							int totalDia = 0;

							foreach (var row in grupo)
							{
								ws.Cell(fila, 1).Value = row["Presentacion"].ToString();
								ws.Cell(fila, 2).Value = Convert.ToInt32(row["CajasNormal"]);
								ws.Cell(fila, 3).Value = Convert.ToInt32(row["CajasExtra"]);
								ws.Cell(fila, 4).Value = Convert.ToInt32(row["TotalCajas"]);

								ws.Cell(fila, 2).Style.NumberFormat.Format = "#,##0";
								ws.Cell(fila, 3).Style.NumberFormat.Format = "#,##0";
								ws.Cell(fila, 4).Style.NumberFormat.Format = "#,##0";

								ws.Range(fila, 1, fila, 4).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

								totalDia += Convert.ToInt32(row["TotalCajas"]);
								fila++;
							}


							ws.Cell(fila, 3).Value = "Total Día:";
							ws.Cell(fila, 4).Value = totalDia;

							ws.Cell(fila, 3).Style.Font.Bold = true;
							ws.Cell(fila, 4).Style.Font.Bold = true;

							ws.Range(fila, 3, fila, 4).Style.Fill.BackgroundColor = XLColor.LightGray;

							totalGeneral += totalDia;
							fila += 2;
						}


						ws.Cell(fila, 3).Value = "TOTAL GENERAL:";
						ws.Cell(fila, 4).Value = totalGeneral;

						ws.Cell(fila, 3).Style.Font.Bold = true;
						ws.Cell(fila, 4).Style.Font.Bold = true;

						ws.Range(fila, 3, fila, 4).Style.Fill.BackgroundColor = XLColor.Gray;
						ws.Range(fila, 3, fila, 4).Style.Font.FontColor = XLColor.White;

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

			string fecha = $"{fechaInicio:yyyy-MM-dd}_{fechaFin:yyyy-MM-dd}";
			string nombreArchivo = $"Reporte_Linea_{linea}_{fecha}.xlsx";

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
							});

						foreach (var emp in empleados)
						{
							string nombreHoja = emp.Key.Codigo;

							var ws = wb.Worksheets.Add(nombreHoja);


							ws.Cell("A1").Value = "REPORTE DE EMPACADOR";
							ws.Range("A1:D1").Merge();
							ws.Cell("A1").Style.Font.Bold = true;
							ws.Cell("A1").Style.Font.FontSize = 16;
							ws.Cell("A1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

							ws.Cell("A3").Value = "Empleado:";
							ws.Cell("B3").Value = $"{emp.Key.Codigo} - {emp.Key.Nombre}";

							ws.Cell("A4").Value = "Periodo:";
							ws.Cell("B4").Value = $"{fechaInicio:dd/MM/yyyy} al {fechaFin:dd/MM/yyyy}";

							int fila = 6;
							int totalGeneral = 0;

							var datosPorFecha = emp
								.GroupBy(r => Convert.ToDateTime(r["Fecha"]).ToString("dd/MM/yyyy"))
								.OrderBy(g => g.Key);

							foreach (var grupoFecha in datosPorFecha)
							{
								ws.Cell(fila, 1).Value = $"Fecha: {grupoFecha.Key}";
								ws.Range(fila, 1, fila, 4).Merge();
								ws.Cell(fila, 1).Style.Font.Bold = true;
								ws.Cell(fila, 1).Style.Fill.BackgroundColor = XLColor.LightGray;
								fila++;

								ws.Cell(fila, 1).Value = "Presentación";
								ws.Cell(fila, 2).Value = "Normal";
								ws.Cell(fila, 3).Value = "Extra";
								ws.Cell(fila, 4).Value = "Total";

								ws.Range(fila, 1, fila, 4).Style.Font.Bold = true;
								ws.Range(fila, 1, fila, 4).Style.Fill.BackgroundColor = XLColor.FromHtml("#D9E1F2");
								fila++;

								int totalDia = 0;

								foreach (var row in grupoFecha)
								{
									ws.Cell(fila, 1).Value = row["Presentacion"].ToString();
									ws.Cell(fila, 2).Value = Convert.ToInt32(row["CajasNormal"]);
									ws.Cell(fila, 3).Value = Convert.ToInt32(row["CajasExtra"]);
									ws.Cell(fila, 4).Value = Convert.ToInt32(row["TotalCajas"]);

									ws.Cell(fila, 2).Style.NumberFormat.Format = "#,##0";
									ws.Cell(fila, 3).Style.NumberFormat.Format = "#,##0";
									ws.Cell(fila, 4).Style.NumberFormat.Format = "#,##0";

									totalDia += Convert.ToInt32(row["TotalCajas"]);
									fila++;
								}

								ws.Cell(fila, 3).Value = "Total Día:";
								ws.Cell(fila, 4).Value = totalDia;
								ws.Cell(fila, 3).Style.Font.Bold = true;
								ws.Cell(fila, 4).Style.Font.Bold = true;

								totalGeneral += totalDia;
								fila += 2;
							}

							ws.Cell(fila, 3).Value = "TOTAL GENERAL:";
							ws.Cell(fila, 4).Value = totalGeneral;

							ws.Cell(fila, 3).Style.Font.Bold = true;
							ws.Cell(fila, 4).Style.Font.Bold = true;
							ws.Range(fila, 3, fila, 4).Style.Fill.BackgroundColor = XLColor.Gray;
							ws.Range(fila, 3, fila, 4).Style.Font.FontColor = XLColor.White;

							ws.Columns().AdjustToContents();
						}

						wb.SaveAs(sfd.FileName);
					}

					DialogResult result = MessageBox.Show(
					"Reporte por línea generado correctamente.\n\n¿Desea abrirlo?",
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
	}
}
		

	







