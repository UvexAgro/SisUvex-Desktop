using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisUvex.Catalogos.Metods.ComboBoxes;
using static SisUvex.Catalogos.Metods.ClsObject;
using System.Data.SqlClient;
using ClosedXML.Excel;
using System.Diagnostics;

namespace SisUvex.Nomina.Reporte_de_Emp_UVA
{
	public class ClsUva
	{
		public FrmUva frm;

		public void CargarHorasInicial()
		{
			try
			{

				DateTime fecha = frm.dtpFecha.Value.Date;

				DataTable dt = new DataTable();

				SQLControl sql = new SQLControl();
				sql.OpenConectionWrite();


				SqlCommand cmd = new SqlCommand("dbo.sp_ReporteEmpaqueDetallePorSemana", sql.cnn);
				cmd.CommandType = CommandType.StoredProcedure;

				cmd.Parameters.Add("@Fecha", SqlDbType.Date).Value = fecha;
				cmd.Parameters.Add("@idProductionLine", SqlDbType.Char).Value = DBNull.Value;

				SqlDataAdapter da = new SqlDataAdapter(cmd);
				da.Fill(dt);

				frm.dgvHoras.DataSource = dt;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}


		public void ExportarExcel(DataTable dt)
		{
			var wb = new XLWorkbook();

			var lineas = dt.AsEnumerable()
				.Where(r => r["LineaProduccion"] != DBNull.Value &&
							!string.IsNullOrWhiteSpace(r["LineaProduccion"].ToString()))
				.GroupBy(r => r["LineaProduccion"].ToString().Trim().PadLeft(3, '0'))
				.OrderBy(g => g.Key);

			foreach (var linea in lineas)
			{
				var ws = wb.Worksheets.Add($"LINEA {linea.Key}");

				int fila = 1;

				//  COLUMNAS DINÁMICAS
				var columnas = linea
					.GroupBy(x => new
					{
						Fecha = Convert.ToDateTime(x["Fecha"]),
						Categoria = x["CategoriaPrecio"] == DBNull.Value ? "" : x["CategoriaPrecio"].ToString()
					})
					.Select(g => new
					{
						g.Key.Fecha,
						g.Key.Categoria,
						Total = g.Sum(x => Convert.ToInt32(x["CajasNormales"]) + Convert.ToInt32(x["CajasExtras"]))
					})
					.Where(x => x.Total > 0)
					.OrderBy(x => x.Fecha)
					.ThenBy(x => x.Categoria)
					.ToList();

				int totalColumnas = 4 + (columnas.Count * 2) + 3;

				//  TITULOS
				ws.Range(fila, 1, fila, totalColumnas).Merge().Value = $"REPORTE DE CAJAS EMPACADAS - LINEA {linea.Key}";
				ws.Range(fila, 1, fila, totalColumnas).Style.Font.SetBold().Font.FontSize = 16;
				ws.Range(fila, 1, fila, totalColumnas).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
				fila++;

				ws.Range(fila, 1, fila, totalColumnas).Merge().Value = "UVEX AGRO INTERNACIONAL";
				ws.Range(fila, 1, fila, totalColumnas).Style.Font.SetBold().Font.FontSize = 12;
				ws.Range(fila, 1, fila, totalColumnas).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
				fila += 2;

				int filaEncabezado = fila;

				// ENCABEZADOS IZQUIERDOS
				int filasEncabezado = 3; // Fecha, Categoria, Normal/Extra

				ws.Range(fila, 1, fila + filasEncabezado - 1, 1).Merge().Value = "Codigo";
				ws.Range(fila, 2, fila + filasEncabezado - 1, 2).Merge().Value = "Nombre";
				ws.Range(fila, 3, fila + filasEncabezado - 1, 3).Merge().Value = "Actividad";
				ws.Range(fila, 4, fila + filasEncabezado - 1, 4).Merge().Value = "Nombre Actividad";

				//  ESTILO
				var header = ws.Range(fila, 1, fila + filasEncabezado - 1, 4);
				header.Style.Fill.BackgroundColor = XLColor.FromHtml("#002060");
				header.Style.Font.FontColor = XLColor.White;
				header.Style.Font.Bold = true;
				header.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
				header.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

				int col = 5;

				//  CATEGORIA ARRIBA
				foreach (var c in columnas)
				{
					var r = ws.Range(fila, col, fila, col + 1);
					r.Merge().Value = c.Categoria;
					r.Style.Fill.BackgroundColor = XLColor.FromHtml("#D9D9D9");
					r.Style.Font.Bold = true;
					r.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
					col += 2;
				}

				fila++;
				col = 5;

				//  FECHA 
				foreach (var c in columnas)
				{
					ws.Cell(fila, col).Value = c.Fecha.ToString("dd/MM/yyyy");
					ws.Cell(fila, col + 1).Value = c.Fecha.ToString("dd/MM/yyyy");

					var r = ws.Range(fila, col, fila, col + 1);
					r.Style.Fill.BackgroundColor = XLColor.FromHtml("#305496");
					r.Style.Font.FontColor = XLColor.White;
					r.Style.Font.Bold = true;
					r.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

					col += 2;
				}

				fila++;
				col = 5;

				// NORMAL / EXTRA
				foreach (var c in columnas)
				{
					var r = ws.Range(fila, col, fila, col + 1);
					ws.Cell(fila, col).Value = "NORMAL";
					ws.Cell(fila, col + 1).Value = "EXTRA";
					r.Style.Fill.BackgroundColor = XLColor.FromHtml("#BDD7EE");
					r.Style.Font.Bold = true;
					r.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
					col += 2;
				}

				int colTotalNormal = col;
				int colTotalExtra = col + 1;
				int colTotalGeneral = col + 2;

				ws.Cell(fila, colTotalNormal).Value = "T.NORMAL";
				ws.Cell(fila, colTotalExtra).Value = "T.EXTRA";
				ws.Cell(fila, colTotalGeneral).Value = "TOTAL";

				var totalHeader = ws.Range(fila, colTotalNormal, fila, colTotalGeneral);
				totalHeader.Style.Fill.BackgroundColor = XLColor.FromHtml("#A6A6A6");
				totalHeader.Style.Font.FontColor = XLColor.White;
				totalHeader.Style.Font.Bold = true;
				totalHeader.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

				fila++;

				int filaDatosInicio = fila;

				//  EMPLEADOS
				var empleados = linea
					.GroupBy(r => new
					{
						Codigo = Convert.ToInt32(r["Codigo"]),
						Nombre = r["Nombre"].ToString(),
						Actividad = r["Actividad"].ToString(),
						NombreActividad = r["NombreActividad"].ToString()
					})
					.Where(emp => emp.Sum(x => Convert.ToInt32(x["CajasNormales"]) + Convert.ToInt32(x["CajasExtras"])) > 0)
					.OrderBy(emp => emp.Key.Actividad)
					.ToList();

				foreach (var emp in empleados)
				{
					ws.Cell(fila, 1).Value = emp.Key.Codigo;
					ws.Cell(fila, 2).Value = emp.Key.Nombre;
					ws.Cell(fila, 3).Value = emp.Key.Actividad;
					ws.Cell(fila, 4).Value = emp.Key.NombreActividad;

					col = 5;

					int totalNormal = 0;
					int totalExtra = 0;

					foreach (var c in columnas)
					{
						var match = emp.FirstOrDefault(x =>
							Convert.ToDateTime(x["Fecha"]) == c.Fecha &&
							(x["CategoriaPrecio"] == DBNull.Value ? "" : x["CategoriaPrecio"].ToString()) == c.Categoria
						);

						int normales = match == null ? 0 : Convert.ToInt32(match["CajasNormales"]);
						int extras = match == null ? 0 : Convert.ToInt32(match["CajasExtras"]);

						ws.Cell(fila, col).Value = normales;
						ws.Cell(fila, col + 1).Value = extras;

						totalNormal += normales;
						totalExtra += extras;

						col += 2;
					}

					ws.Cell(fila, colTotalNormal).Value = totalNormal;
					ws.Cell(fila, colTotalExtra).Value = totalExtra;
					ws.Cell(fila, colTotalGeneral).Value = totalNormal + totalExtra;

					fila++;
				}

				//EMCABEZADO FILA
				var rango = ws.Range(filaDatosInicio - 3, 1, fila - 1, totalColumnas);
				rango.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
				rango.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

				rango.Style.Border.OutsideBorderColor = XLColor.Black;
				rango.Style.Border.InsideBorderColor = XLColor.Black;

				ws.Range(filaDatosInicio, 5, fila - 1, totalColumnas)
				  .Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

				//  AJUSTES
				ws.Columns(1, totalColumnas).AdjustToContents();

				ws.Column(2).Width = 35; // Nombre
				ws.Column(3).Width = 15; //  Actividad 
				ws.Column(4).Width = 25; // Nombre Actividad

				for (int i = 5; i <= totalColumnas; i++)
					ws.Column(i).Width = 10;

			}
			AgregarHojasHorarios(wb, dt);
			AgregarHojaActividadesGenerales(wb, dt);

			//  GUARDAR
			SaveFileDialog sfd = new SaveFileDialog();
			DateTime fecha = Convert.ToDateTime(dt.Rows[0]["Fecha"]);

			sfd.FileName = $"Reporte {fecha:yyyyMMdd}.xlsx";

			if (sfd.ShowDialog() == DialogResult.OK)
			{
				string ruta = sfd.FileName;
				try
				{
					wb.SaveAs(ruta);
				}
				catch (IOException)
				{
					MessageBox.Show(
						"El archivo ya está abierto.\n\nCiérralo antes de continuar.",
						"Archivo en uso",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning
					);
					return;
				}

				var result = MessageBox.Show(
					"Archivo guardado correctamente.\n\n¿Deseas abrirlo?",
					"Exportación completada",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question
				);

				if (result == DialogResult.Yes)
				{
					Process.Start(new ProcessStartInfo
					{
						FileName = ruta,
						UseShellExecute = true
					});
				}
			}
		}
		private void AgregarHojasHorarios(XLWorkbook wb, DataTable dt)
		{
			var lineas = dt.AsEnumerable()
				.Where(r =>
					r["LineaProduccion"] != DBNull.Value &&
					!string.IsNullOrWhiteSpace(r["LineaProduccion"].ToString()))
				.GroupBy(r => r["LineaProduccion"].ToString().Trim().PadLeft(3, '0'))
				.OrderBy(g => g.Key);

			foreach (var linea in lineas)
			{
				var wsH = wb.Worksheets.Add($"HORARIOS L{linea.Key}");

				int fila = 1;
				// TITULO
				wsH.Range(fila, 1, fila, 9).Merge().Value = $"HORARIOS - LINEA {linea.Key}";
				wsH.Range(fila, 1, fila, 9).Style.Font.Bold = true;
				wsH.Range(fila, 1, fila, 9).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
				fila++;

				// FECHA (nueva fila)
				var fecha = linea.First()["Fecha"] == DBNull.Value
					? ""
					: Convert.ToDateTime(linea.First()["Fecha"]).ToString("dd/MM/yyyy");

				wsH.Range(fila, 1, fila, 9).Merge().Value = $"FECHA: {fecha}";
				wsH.Range(fila, 1, fila, 9).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
				wsH.Range(fila, 1, fila, 9).Style.Font.Bold = true;

				fila += 2;

				// ENCABEZADOS
				wsH.Cell(fila, 1).Value = "Codigo";
				wsH.Cell(fila, 2).Value = "Nombre";
				wsH.Cell(fila, 3).Value = "Actividad";
				wsH.Cell(fila, 4).Value = "Nombre Actividad";
				wsH.Cell(fila, 5).Value = "Hora Inicio Normal";
				wsH.Cell(fila, 6).Value = "Hora Fin Normal";
				wsH.Cell(fila, 7).Value = "Hora Inicio Extra";
				wsH.Cell(fila, 8).Value = "Hora Fin Extra";
				wsH.Cell(fila, 9).Value = "Horas Extra";

				var header = wsH.Range(fila, 1, fila, 9);
				header.Style.Fill.BackgroundColor = XLColor.FromHtml("#002060");
				header.Style.Font.FontColor = XLColor.White;
				header.Style.Font.Bold = true;
				header.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

				fila++;

				int filaInicio = fila;

				var empleados = linea
				.Where(r =>
					r["HoraInicioNormal"] != DBNull.Value ||
					r["HoraInicioExtra"] != DBNull.Value)
				.GroupBy(r => new
				{
					Codigo = r["Codigo"],
					Nombre = r["Nombre"],
					Actividad = r["Actividad"],
					NombreActividad = r["NombreActividad"]
				});

				foreach (var emp in empleados)
				{
					var row = emp.First(); // 👈 tomamos solo uno

					wsH.Cell(fila, 1).Value = row["Codigo"]?.ToString() ?? "";
					wsH.Cell(fila, 2).Value = row["Nombre"]?.ToString() ?? "";
					wsH.Cell(fila, 3).Value = row["Actividad"]?.ToString() ?? "";
					wsH.Cell(fila, 4).Value = row["NombreActividad"]?.ToString() ?? "";

					wsH.Cell(fila, 5).Value = row["HoraInicioNormal"] == DBNull.Value ? "" : Convert.ToDateTime(row["HoraInicioNormal"]);
					wsH.Cell(fila, 6).Value = row["HoraFinNormal"] == DBNull.Value ? "" : Convert.ToDateTime(row["HoraFinNormal"]);
					wsH.Cell(fila, 7).Value = row["HoraInicioExtra"] == DBNull.Value ? "" : Convert.ToDateTime(row["HoraInicioExtra"]);
					wsH.Cell(fila, 8).Value = row["HoraFinExtra"] == DBNull.Value ? "" : Convert.ToDateTime(row["HoraFinExtra"]);
					wsH.Cell(fila, 9).Value = row["HorasExtra"] == DBNull.Value ? 0 : Convert.ToDecimal(row["HorasExtra"]);

					fila++;
				}

				// BORDES
				var rango = wsH.Range(filaInicio - 1, 1, fila - 1, 9);
				rango.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
				rango.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
				rango.Style.Border.OutsideBorderColor = XLColor.Black;
				rango.Style.Border.InsideBorderColor = XLColor.Black;

				// FORMATO HORA (PRO)
				wsH.Column(5).Style.DateFormat.Format = "HH:mm";
				wsH.Column(6).Style.DateFormat.Format = "HH:mm";
				wsH.Column(7).Style.DateFormat.Format = "HH:mm";
				wsH.Column(8).Style.DateFormat.Format = "HH:mm";

				wsH.Columns().AdjustToContents();
			}
		}
		private void AgregarHojaActividadesGenerales(XLWorkbook wb, DataTable dt)
		{
			var datos = dt.AsEnumerable()
				.Where(r =>
					r["LineaProduccion"] == DBNull.Value &&
					r["HoraInicioNormal"] == DBNull.Value &&
					r["HoraInicioExtra"] == DBNull.Value
				);

			if (!datos.Any())
				return;

			var ws = wb.Worksheets.Add("ACTIVIDADES GENERALES");

			int fila = 1;

			ws.Range(fila, 1, fila, 8).Merge().Value = "ACTIVIDADES GENERALES";
			ws.Range(fila, 1, fila, 8).Style.Font.Bold = true;
			ws.Range(fila, 1, fila, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
			fila += 2;

			ws.Cell(fila, 1).Value = "Fecha";
			ws.Cell(fila, 2).Value = "Codigo";
			ws.Cell(fila, 3).Value = "Nombre";
			ws.Cell(fila, 4).Value = "Actividad";
			ws.Cell(fila, 5).Value = "Nombre Actividad";
			ws.Cell(fila, 6).Value = "Concepto";
			ws.Cell(fila, 7).Value = "Nombre Concepto";
			ws.Cell(fila, 8).Value = "Unidades";

			var header = ws.Range(fila, 1, fila, 8);
			header.Style.Fill.BackgroundColor = XLColor.FromHtml("#002060");
			header.Style.Font.FontColor = XLColor.White;
			header.Style.Font.Bold = true;
			header.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

			fila++;

			int filaInicio = fila;

			foreach (var row in datos)
			{
				ws.Cell(fila, 1).Value = row["Fecha"] == DBNull.Value ? "" : Convert.ToDateTime(row["Fecha"]);
				ws.Cell(fila, 2).Value = row["Codigo"]?.ToString() ?? "";
				ws.Cell(fila, 3).Value = row["Nombre"]?.ToString() ?? "";
				ws.Cell(fila, 4).Value = row["Actividad"]?.ToString() ?? "";
				ws.Cell(fila, 5).Value = row["NombreActividad"]?.ToString() ?? "";
				ws.Cell(fila, 6).Value = row["Concepto"]?.ToString() ?? "";
				ws.Cell(fila, 7).Value = row["NombreConcepto"]?.ToString() ?? "";
				ws.Cell(fila, 8).Value = row["Unidades"] == DBNull.Value ? 0 : Convert.ToDecimal(row["Unidades"]);

				fila++;
			}

			ws.Column(1).Style.DateFormat.Format = "dd/MM/yyyy";

			var rango = ws.Range(filaInicio - 1, 1, fila - 1, 8);
			rango.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
			rango.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
			rango.Style.Border.OutsideBorderColor = XLColor.Black;
			rango.Style.Border.InsideBorderColor = XLColor.Black;

			ws.Columns().AdjustToContents();
		}
	}
}

