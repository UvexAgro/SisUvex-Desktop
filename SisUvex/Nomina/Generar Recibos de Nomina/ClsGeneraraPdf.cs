using System;
using System.Data;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace SisUvex.Nomina.Generar_Recibos_de_Nomina
{
	public class ClsGeneraraPdf
	{
		public FrmRecibos frm;
		public ClsRecibos cls = new ClsRecibos();
		DeviceRgb grisPagoNeto = new DeviceRgb(190, 190, 190);

		public void GenerarPDF()
		{
			try
			{
				var filas = frm.dgvRecibo.Rows
					.Cast<DataGridViewRow>()
					.Where(f =>
						!f.IsNewRow &&
						f.Cells["Codigo"].Value != null &&
						!string.IsNullOrWhiteSpace(
							f.Cells["Codigo"].Value.ToString()))
					.OrderBy(f =>
						f.Cells["CodigoLugarPago"].Value?.ToString().Trim())
					.ThenBy(f =>
						f.Cells["NombreCompleto"].Value?.ToString().Trim())
					.ToList();

				if (filas.Count == 0)
				{
					MessageBox.Show("No hay recibos para generar.",
						"Recibos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				if (!frm.rbCfdi.Checked && !frm.rbNormal.Checked)
				{
					MessageBox.Show("Selecciona el tipo de recibo.",
						"Recibos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				bool esCfdi = frm.rbCfdi.Checked;

				using (SaveFileDialog guardar = new SaveFileDialog())
				{
					guardar.Filter = "Archivo PDF (*.pdf)|*.pdf";

					string nombreArchivo = ObtenerNombreArchivo(filas);

					guardar.FileName = esCfdi
						? $"{nombreArchivo}_CFDI.pdf"
						: $"{nombreArchivo}_Normal.pdf";

					guardar.Title = "Guardar recibos";

					if (guardar.ShowDialog() != DialogResult.OK)
						return;

					using (PdfWriter writer = new PdfWriter(guardar.FileName))
					using (PdfDocument pdf = new PdfDocument(writer))
					using (Document documento = new Document(pdf, PageSize.LETTER))
					{
						documento.SetMargins(0, 0, 0, 0);

						string ultimoLugarPago = null;
						int recibosEnPagina = 0;

						for (int i = 0; i < filas.Count; i++)
						{
							string lugarPago = filas[i]
								.Cells["CodigoLugarPago"]
								.Value?.ToString()
								.Trim() ?? "";

							// Nueva hoja cuando cambia el lugar de pago
							if (ultimoLugarPago != null &&
								!string.Equals(
									ultimoLugarPago,
									lugarPago,
									StringComparison.OrdinalIgnoreCase))
							{
								documento.Add(
									new AreaBreak(AreaBreakType.NEXT_PAGE));

								recibosEnPagina = 0;
							}
							// Máximo dos recibos por hoja
							else if (recibosEnPagina >= 2)
							{
								documento.Add(
									new AreaBreak(AreaBreakType.NEXT_PAGE));

								recibosEnPagina = 0;
							}

							float alturaRecibo = esCfdi ? 391 : 380;

							Div recibo = new Div()
								.SetWidth(UnitValue.CreatePercentValue(100))
								.SetHeight(alturaRecibo)
								.SetMinHeight(alturaRecibo)
								.SetMaxHeight(alturaRecibo)
								.SetMargin(0)
								.SetPadding(esCfdi ? 2 : 3)
								.SetBorder(new SolidBorder(
									new DeviceRgb(65, 65, 65), 0.5f));

							if (esCfdi)
								CrearReciboCFDI(recibo, filas[i]);
							else
								CrearReciboNormal(recibo, filas[i]);

							documento.Add(recibo);

							recibosEnPagina++;
							ultimoLugarPago = lugarPago;
						}
					}

					Process.Start(new ProcessStartInfo
					{
						FileName = guardar.FileName,
						UseShellExecute = true
					});
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error al generar el PDF:\n" + ex.Message,
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		private string ObtenerNombreArchivo(List<DataGridViewRow> filas)
		{
			// Si es un solo empleado, utilizar su código
			if (filas.Count == 1)
			{
				string codigo = filas[0].Cells["Codigo"].Value?.ToString().Trim();

				return $"Recibo_{codigo}";
			}

			// Buscar la columna del lugar de pago
			string[] columnasLugar =
			{
				"LugarPago",
				"Lugar de pago",
				"c_codigo_lug"
			};

			string nombreColumna = columnasLugar.FirstOrDefault(
				c => frm.dgvRecibo.Columns.Contains(c));

			if (nombreColumna != null)
			{
				var lugares = filas
					.Select(f => f.Cells[nombreColumna].Value?.ToString().Trim())
					.Where(v => !string.IsNullOrWhiteSpace(v))
					.Distinct()
					.ToList();

				if (lugares.Count == 1)
					return $"Recibos_{lugares[0]}";
			}

			return "Recibos_Varios_Lugares";
		}


		private iText.Layout.Element.Image CrearFranjaCurva()
		{
			using (System.Drawing.Bitmap bitmap =
				new System.Drawing.Bitmap(1200, 100))
			using (System.Drawing.Graphics g =
				System.Drawing.Graphics.FromImage(bitmap))
			using (System.IO.MemoryStream ms =
				new System.IO.MemoryStream())
			{
				g.SmoothingMode =
					System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

				g.Clear(System.Drawing.Color.White);

				using (System.Drawing.Drawing2D.LinearGradientBrush fondo =
					new System.Drawing.Drawing2D.LinearGradientBrush(
						new System.Drawing.Rectangle(0, 0, 1200, 100),
						System.Drawing.Color.FromArgb(245, 245, 245),
						System.Drawing.Color.FromArgb(190, 190, 190),
						System.Drawing.Drawing2D.LinearGradientMode.Vertical))
				{
					using (System.Drawing.Drawing2D.GraphicsPath curva =
						new System.Drawing.Drawing2D.GraphicsPath())
					{
						curva.AddBezier(
							0, 15,
							250, 80,
							350, 0,
							600, 35);

						curva.AddBezier(
							600, 35,
							850, 70,
							1000, 0,
							1200, 15);

						curva.AddLine(1200, 100, 0, 100);
						curva.CloseFigure();

						g.FillPath(fondo, curva);
					}
				}

				using (System.Drawing.Pen linea =
					new System.Drawing.Pen(
						System.Drawing.Color.FromArgb(100, 100, 100), 3))
				{
					g.DrawBezier(
						linea,
						0, 70,
						250, 100,
						400, 10,
						650, 35);
				}

				bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

				iText.Layout.Element.Image imagen =
					new iText.Layout.Element.Image(
						iText.IO.Image.ImageDataFactory.Create(ms.ToArray()));

				imagen.SetWidth(
					iText.Layout.Properties.UnitValue.CreatePercentValue(100));

				imagen.SetHeight(24);

				return imagen;
			}
		}



		private void AgregarEncabezado(Div contenedor,PdfFont bold,DeviceRgb negro,DeviceRgb grisOscuro,bool esNormal = false)
		{
			float alturaLogo = esNormal ? 60 : 55;
			float alturaFranja = esNormal ? 12 : 12;

			Table encabezado = new Table(
				UnitValue.CreatePercentArray(new float[] { 16, 84 }))
				.UseAllAvailableWidth();

			encabezado.AddCell(
				CeldaLogo(grisOscuro)
					.SetHeight(alturaLogo));

			encabezado.AddCell(
				new Cell()
					.Add(new Paragraph("UVEX AGRO INTERNACIONAL")
						.SetFont(bold)
						.SetFontSize(17)
						.SetFontColor(negro)
						.SetTextAlignment(TextAlignment.CENTER)
						.SetMargin(0))
					.SetVerticalAlignment(VerticalAlignment.MIDDLE)
					.SetBorder(Border.NO_BORDER));

			contenedor.Add(encabezado);

			contenedor.Add(
				CrearFranjaCurva()
					.SetHeight(alturaFranja)
					.SetMarginTop(0)
					.SetMarginBottom(1));
		}






		private void CrearReciboCFDI(
			Div contenedor,
			DataGridViewRow fila)
		{
			PdfFont bold = PdfFontFactory.CreateFont(
				StandardFonts.HELVETICA_BOLD);

			PdfFont regular = PdfFontFactory.CreateFont(
				StandardFonts.HELVETICA);

			DeviceRgb negro = new DeviceRgb(25, 25, 25);
			DeviceRgb gris = new DeviceRgb(215, 215, 215);
			DeviceRgb grisOscuro = new DeviceRgb(55, 55, 55);
			DeviceRgb blanco = new DeviceRgb(255, 255, 255);

			contenedor.SetPadding(2);

			// =========================================
			// ENCABEZADO
			// =========================================

			AgregarEncabezado(
				contenedor, bold, negro, grisOscuro);

			// =========================================
			// DATOS DEL EMPLEADO
			// =========================================

			Table datos = new Table(
				UnitValue.CreatePercentArray(
					new float[] { 20, 30, 20, 30 }))
				.UseAllAvailableWidth();

			AgregarDato(datos, "Registro Patronal:",
				Valor(fila, "RegistroPatronal"), bold, regular);

			AgregarDato(datos, "Semana:",
				Valor(fila, "Semana"), bold, regular);

			AgregarDato(datos, "Código:",
				Valor(fila, "Codigo"), bold, regular);

			AgregarDato(datos, "Del:",
				ObtenerFecha(frm.dtpFechaInicial.Value), bold, regular);

			AgregarDato(datos, "Empleado:",
				Valor(fila, "NombreCompleto"), bold, regular);

			string codigoLugar = Valor(fila, "CodigoLugarPago");
			string nombreLugar = Valor(fila, "LugarPago");

			AgregarDato(datos, "Lugar de Pago:",
				$"{codigoLugar} - {nombreLugar}", bold, regular);

			AgregarDato(datos, "al:",
				ObtenerFecha(frm.dtpFechaFinal.Value), bold, regular);

			AgregarDato(datos, "Días de Salario:",
				Valor(fila, "DiasTrabajados"), bold, regular);

			AgregarCeldaVacia(datos);
			AgregarCeldaVacia(datos);

			contenedor.Add(datos);

			AgregarLinea(contenedor, negro, 1, 4);

			// =========================================
			// TABLA PRINCIPAL
			// =========================================

			Table principal = new Table(
				UnitValue.CreatePercentArray(
					new float[] { 52, 48 }))
				.UseAllAvailableWidth();

			// =========================================
			// PERCEPCIONES
			// =========================================

			Table percepciones = new Table(
				UnitValue.CreatePercentArray(
					new float[] { 72, 28 }))
				.UseAllAvailableWidth();

			EncabezadoSeccion(
				percepciones, "PERCEPCIONES", gris, bold);

			AgregarConcepto(
				percepciones,
				"Sueldo Ordinario:",
				Valor(fila, "SueldoOrdinario"),
				regular, bold);

			AgregarConcepto(
				percepciones,
				"Séptimo Día:",
				Valor(fila, "SeptimoDia"),
				regular, bold);

			AgregarConcepto(
				percepciones,
				"Horas Extras:",
				Valor(fila, "HorasExtras"),
				regular, bold);

			AgregarConcepto(
				percepciones,
				"Domingo:",
				Valor(fila, "Domingo"),
				regular, bold);

			AgregarConcepto(
				percepciones,
				"Prima Dominical:",
				Valor(fila, "PrimaDominical"),
				regular, bold);

			AgregarConcepto(
				percepciones,
				"Productividad:",
				Valor(fila, "Productividad"),
				regular, bold);

			AgregarTotal(
				percepciones,
				"Total Percepciones:",
				Valor(fila, "TotalPercepciones"),
				bold,
				gris);

			// =========================================
			// DEDUCCIONES
			// =========================================

			Table deducciones = new Table(
				UnitValue.CreatePercentArray(
					new float[] { 72, 28 }))
				.UseAllAvailableWidth();

			EncabezadoSeccion(
				deducciones, "DEDUCCIONES", gris, bold);

			decimal totalDeducciones = 0;

			// =========================================
			// OBTENER DESCUENTOS
			// =========================================

			DataTable dtDeducciones =
				cls.ObtenerDesgloseDeducciones(
					Valor(fila, "Codigo"),
					Valor(fila, "Semana"));

			// =========================================
			// MOSTRAR DESCUENTOS
			// =========================================

			if (dtDeducciones != null)
			{
				foreach (DataRow descuento in dtDeducciones.Rows)
				{
					string concepto =
						descuento["Concepto"].ToString().Trim();

					decimal importe = 0;

					decimal.TryParse(
						descuento["Importe"].ToString(),
						NumberStyles.Any,
						CultureInfo.InvariantCulture,
						out importe);

					AgregarConcepto(
						deducciones,
						concepto,
						importe.ToString("N2"),
						regular,
						bold);

					totalDeducciones += importe;
				}
			}

			// =========================================
			// TOTAL DE DEDUCCIONES
			// =========================================

			AgregarTotal(
				deducciones,
				"Total Deducción:",
				totalDeducciones.ToString("N2"),
				bold,
				gris);

			// =========================================
			// INFORMACIÓN DE PRÉSTAMOS
			// =========================================

			Table informacionPrestamos = new Table(
				UnitValue.CreatePercentArray(
					new float[] { 72, 28 }))
				.UseAllAvailableWidth()
				.SetMarginTop(7);

			bool tienePrestamos = false;

			if (dtDeducciones != null &&
				dtDeducciones.Columns.Contains("SaldoPendiente"))
			{
				foreach (DataRow descuento in dtDeducciones.Rows)
				{
					decimal saldoPendiente = 0;

					decimal.TryParse(
						descuento["SaldoPendiente"].ToString(),
						NumberStyles.Any,
						CultureInfo.InvariantCulture,
						out saldoPendiente);

					if (saldoPendiente > 0)
					{
						if (!tienePrestamos)
						{
							EncabezadoSeccion(
								informacionPrestamos,
								"INFORMACIÓN DE PRÉSTAMOS",
								gris,
								bold);

							tienePrestamos = true;
						}

						string concepto =
							descuento["Concepto"].ToString().Trim();

						AgregarConcepto(
						informacionPrestamos,
						"Saldo pendiente:",
						saldoPendiente.ToString("N2"),
						regular,
						bold);
					}
				}
			}

			// =========================================
			// COLUMNA DERECHA
			// =========================================

			Div columnaDerecha = new Div();

			columnaDerecha.Add(deducciones);

			if (tienePrestamos)
			{
				columnaDerecha.Add(informacionPrestamos);
			}

			// =========================================
			// PAGO NETO
			// =========================================

			Table neto = CrearTablaPagoNeto(
				"PAGO NETO:",
				Valor(fila, "ImporteNeto"),
				bold,
				blanco,
				grisPagoNeto);

			neto.SetMarginTop(12);

			columnaDerecha.Add(neto);

			// =========================================
			// DISTRIBUCIÓN DE LAS DOS COLUMNAS
			// =========================================

			principal.AddCell(
				new Cell()
					.Add(percepciones)
					.SetBorder(Border.NO_BORDER)
					.SetPaddingRight(7));

			principal.AddCell(
				new Cell()
					.Add(columnaDerecha)
					.SetBorderLeft(
						new SolidBorder(grisOscuro, 0.8f))
					.SetBorderTop(Border.NO_BORDER)
					.SetBorderRight(Border.NO_BORDER)
					.SetBorderBottom(Border.NO_BORDER)
					.SetPaddingLeft(7));

			contenedor.Add(principal);

			// =========================================
			// TEXTO LEGAL
			// =========================================

			contenedor.Add(new Div().SetHeight(12));

			contenedor.Add(
				new Paragraph(
					"RECIBÍ DE LA EMPRESA ARRIBA MENCIONADA LA CANTIDAD NETA A QUE ESTE DOCUMENTO SE REFIERE. " +
					"ESTA LIQUIDACIÓN ES REALIZADA SOBRE LA BASE DEL SALARIO INTEGRADO CON LOS CONCEPTOS A QUE SE REFIERE " +
					"EL ART. 84 DE LA LEY FEDERAL DEL TRABAJO, INCLUYENDO VACACIONES, PRIMA VACACIONAL, AGUINALDO Y REPARTO DE UTILIDADES.")
					.SetFont(regular)
					.SetFontSize(5.5f)
					.SetFixedLeading(6)
					.SetTextAlignment(TextAlignment.JUSTIFIED)
					.SetMarginTop(2)
					.SetMarginBottom(1)
					.SetKeepTogether(true));

			// =========================================
			// ESPACIO ANTES DE LAS FIRMAS
			// =========================================

			contenedor.Add(new Div().SetHeight(12));

			AgregarFirmas(contenedor, bold);
		}



		private string ObtenerFecha(DateTime fecha)
		{
			return fecha.ToString("dd/MM/yyyy");
		}






		private void CrearReciboNormal(
			Div contenedor,
			DataGridViewRow fila)
		{
			PdfFont bold = PdfFontFactory.CreateFont(
				StandardFonts.HELVETICA_BOLD);

			PdfFont regular = PdfFontFactory.CreateFont(
				StandardFonts.HELVETICA);

			DeviceRgb negro = new DeviceRgb(25, 25, 25);
			DeviceRgb gris = new DeviceRgb(215, 215, 215);
			DeviceRgb grisOscuro = new DeviceRgb(55, 55, 55);
			DeviceRgb blanco = new DeviceRgb(255, 255, 255);

			contenedor.SetPadding(3);

			// =========================================
			// ENCABEZADO
			// =========================================

			AgregarEncabezado(
				contenedor, bold, negro, grisOscuro, true);

			// =========================================
			// DATOS DEL EMPLEADO
			// =========================================

			Table datos = new Table(
				UnitValue.CreatePercentArray(
					new float[] { 20, 30, 20, 30 }))
				.UseAllAvailableWidth()
				.SetMarginTop(3)
				.SetMarginBottom(3);

			AgregarDato(datos, "Registro Patronal:",
				Valor(fila, "RegistroPatronal"), bold, regular);

			AgregarDato(datos, "Semana:",
				Valor(fila, "Semana"), bold, regular);

			AgregarDato(datos, "Empleado:",
				Valor(fila, "NombreCompleto"), bold, regular);

			AgregarDato(datos, "Desde:",
				ObtenerFecha(frm.dtpFechaInicial.Value), bold, regular);

			string codigoLugar = Valor(fila, "CodigoLugarPago");
			string nombreLugar = Valor(fila, "LugarPago");

			string lugarPago = $"{codigoLugar} - {nombreLugar}";

			AgregarDato(datos, "Lugar de Pago:",
				lugarPago, bold, regular);

			AgregarDato(datos, "Hasta:",
				ObtenerFecha(frm.dtpFechaFinal.Value), bold, regular);

			AgregarDato(datos, "No. Afiliación al IMSS:",
				Valor(fila, "NumeroIMSS"), bold, regular);

			AgregarCeldaVacia(datos);
			AgregarCeldaVacia(datos);

			contenedor.Add(datos);

			AgregarLinea(contenedor, negro, 1, 5);

			// =========================================
			// CUERPO: DOS COLUMNAS
			// =========================================

			Table cuerpo = new Table(
				UnitValue.CreatePercentArray(
					new float[] { 51, 49 }))
				.UseAllAvailableWidth();

			// =========================================
			// PERCEPCIONES DIARIAS
			// =========================================

			Table diarias = new Table(
				UnitValue.CreatePercentArray(
					new float[] { 65, 35 }))
				.UseAllAvailableWidth();

			EncabezadoSeccion(
				diarias, "PERCEPCIONES DIARIAS", gris, bold);

			string[] dias =
			{
		"Miércoles", "Jueves", "Viernes",
		"Sábado", "Domingo", "Lunes", "Martes"
	};

			string[] columnas =
			{
		"Miercoles", "Jueves", "Viernes",
		"Sabado", "Domingo", "Lunes", "Martes"
	};

			for (int i = 0; i < dias.Length; i++)
			{
				AgregarConcepto(
					diarias,
					dias[i] + ":",
					Valor(fila, columnas[i]),
					regular,
					bold);
			}

			AgregarTotal(
				diarias,
				"Total Percepciones:",
				Valor(fila, "TotalPercepciones"),
				bold,
				gris);

			// =========================================
			// DEDUCCIONES
			// =========================================

			Table deducciones = new Table(
				UnitValue.CreatePercentArray(
					new float[] { 72, 28 }))
				.UseAllAvailableWidth();

			EncabezadoSeccion(
				deducciones, "DEDUCCIONES", gris, bold);

			DataTable dtDeducciones =
				cls.ObtenerDesgloseDeducciones(
					Valor(fila, "Codigo"),
					Valor(fila, "Semana"));

			// =========================================
			// MOSTRAR DESCUENTOS
			// =========================================

			if (dtDeducciones != null)
			{
				foreach (DataRow descuento in dtDeducciones.Rows)
				{
					string concepto =
						descuento["Concepto"].ToString().Trim();

					decimal importe = 0;

					decimal.TryParse(
						descuento["Importe"].ToString(),
						NumberStyles.Any,
						CultureInfo.InvariantCulture,
						out importe);

					AgregarConcepto(
						deducciones,
						concepto,
						importe.ToString("N2"),
						regular,
						bold);
				}
			}

			// =========================================
			// TOTAL DE DEDUCCIONES
			// =========================================

			AgregarTotal(
				deducciones,
				"Total Descuentos:",
				Valor(fila, "TotalDeducciones"),
				bold,
				gris);

			// =========================================
			// INFORMACIÓN DE PRÉSTAMOS
			// =========================================

			Table informacionPrestamos = new Table(
				UnitValue.CreatePercentArray(
					new float[] { 72, 28 }))
				.UseAllAvailableWidth()
				.SetMarginTop(7);

			bool tienePrestamos = false;

			if (dtDeducciones != null &&
				dtDeducciones.Columns.Contains("SaldoPendiente"))
			{
				foreach (DataRow descuento in dtDeducciones.Rows)
				{
					decimal saldoPendiente = 0;

					decimal.TryParse(
						descuento["SaldoPendiente"].ToString(),
						NumberStyles.Any,
						CultureInfo.InvariantCulture,
						out saldoPendiente);

					if (saldoPendiente > 0)
					{
						if (!tienePrestamos)
						{
							EncabezadoSeccion(
								informacionPrestamos,
								"INFORMACIÓN DE PRÉSTAMOS",
								gris,
								bold);

							tienePrestamos = true;
						}

						string concepto =
							descuento["Concepto"].ToString().Trim();

						AgregarConcepto(
						informacionPrestamos,
						"Saldo pendiente:",
						saldoPendiente.ToString("N2"),
						regular,
						bold);
					}
				}
			}

			// =========================================
			// COLUMNA DERECHA
			// =========================================

			Div columnaDerecha = new Div();

			columnaDerecha.Add(deducciones);

			if (tienePrestamos)
			{
				columnaDerecha.Add(informacionPrestamos);
			}

			// =========================================
			// PAGO NETO
			// =========================================

			Table neto = CrearTablaPagoNeto(
				"PAGO NETO:",
				Valor(fila, "ImporteNeto"),
				bold,
				blanco,
				grisPagoNeto);

			neto.SetMarginTop(12);

			columnaDerecha.Add(neto);

			// =========================================
			// DISTRIBUCIÓN DE LAS DOS COLUMNAS
			// =========================================

			cuerpo.AddCell(
				new Cell()
					.Add(diarias)
					.SetBorder(Border.NO_BORDER)
					.SetPaddingRight(7));

			cuerpo.AddCell(
				new Cell()
					.Add(columnaDerecha)
					.SetBorderLeft(
						new SolidBorder(grisOscuro, 0.8f))
					.SetBorderTop(Border.NO_BORDER)
					.SetBorderRight(Border.NO_BORDER)
					.SetBorderBottom(Border.NO_BORDER)
					.SetPaddingLeft(7));

			contenedor.Add(cuerpo);

			// =========================================
			// FIRMAS
			// =========================================

			AgregarFirmas(contenedor, bold);
		}



		private void AgregarFirmas(Div contenedor, PdfFont bold)
		{
			Table firmas = new Table(
				UnitValue.CreatePercentArray(new float[] { 50, 50 }))
				.UseAllAvailableWidth()
				.SetMarginTop(8)
				.SetMarginBottom(0)
				.SetKeepTogether(true);

			firmas.AddCell(CrearCeldaFirma(
				"Firma del Trabajador", bold));

			firmas.AddCell(CrearCeldaFirma(
				"Firma del Empleador", bold));

			contenedor.Add(firmas);
		}

		private Cell CrearCeldaFirma(string texto, PdfFont bold)
		{
			return new Cell()
				.Add(new Paragraph("____________________________")
					.SetFont(bold)
					.SetFontSize(8)
					.SetTextAlignment(TextAlignment.CENTER)
					.SetMarginBottom(2)
					.SetMarginTop(0))
				.Add(new Paragraph(texto)
					.SetFont(bold)
					.SetFontSize(8)
					.SetTextAlignment(TextAlignment.CENTER)
					.SetMargin(0))
				.SetBorder(Border.NO_BORDER)
				.SetPadding(2);
		}


		private void AgregarLinea(
			Div contenedor,
			DeviceRgb color,
			float grosor,
			float margenInferior)
		{
			contenedor.Add(
				new Paragraph(" ")
					.SetBorderBottom(new SolidBorder(color, grosor))
					.SetMarginTop(1)
					.SetMarginBottom(margenInferior)
					.SetFixedLeading(1));
		}


		private string Valor(DataGridViewRow fila, params string[] columnas)
		{
			foreach (string columna in columnas)
			{
				if (frm.dgvRecibo.Columns.Contains(columna))
				{
					object valor = fila.Cells[columna].Value;

					if (valor != null && valor != DBNull.Value)
						return valor.ToString().Trim();
				}
			}

			return "";
		}

		private string Dinero(string valor)
		{
			if (decimal.TryParse(valor, out decimal cantidad))
				return cantidad.ToString("N2");

			return "0.00";
		}


		private void AgregarDato(
	Table tabla,
	string etiqueta,
	string valor,
	PdfFont bold,
	PdfFont regular)
		{
			tabla.AddCell(
				new Cell()
					.Add(new Paragraph(etiqueta)
						.SetFont(bold)
						.SetFontSize(7.5f)
						.SetMargin(0))
					.SetBorder(Border.NO_BORDER)
					.SetPaddingTop(3)
					.SetPaddingBottom(3)
					.SetPaddingLeft(3)
					.SetPaddingRight(2));

			tabla.AddCell(
				new Cell()
					.Add(new Paragraph(valor ?? "")
						.SetFont(regular)
						.SetFontSize(7.5f)
						.SetMargin(0))
					.SetBorder(Border.NO_BORDER)
					.SetPaddingTop(3)
					.SetPaddingBottom(3)
					.SetPaddingLeft(2)
					.SetPaddingRight(3));
		}

		private void AgregarCeldaVacia(Table tabla)
		{
			tabla.AddCell(
				new Cell()
					.Add(new Paragraph(" ").SetFontSize(7))
					.SetBorder(Border.NO_BORDER)
					.SetPadding(1));
		}


		private void EncabezadoSeccion(
	Table tabla,
	string titulo,
	DeviceRgb gris,
	PdfFont bold)
		{
			tabla.AddHeaderCell(
				new Cell(1, 2)
					.Add(new Paragraph(titulo)
						.SetFont(bold)
						.SetFontSize(9.5f)
						.SetFontColor(new DeviceRgb(35, 35, 35))
						.SetTextAlignment(TextAlignment.CENTER)
						.SetMargin(0))
					.SetBackgroundColor(gris)
					.SetBorder(Border.NO_BORDER)
					.SetPaddingTop(7)
					.SetPaddingBottom(7)
					.SetPaddingLeft(5)
					.SetPaddingRight(5));
		}




		private void AgregarConcepto(
	Table tabla,
	string concepto,
	string importe,
	PdfFont regular,
	PdfFont bold)
		{
			DeviceRgb linea = new DeviceRgb(220, 220, 220);

			tabla.AddCell(
				new Cell()
					.Add(new Paragraph(concepto)
						.SetFont(regular)
						.SetFontSize(8)
						.SetFixedLeading(10)
						.SetMargin(0))
					.SetBorderBottom(new SolidBorder(linea, 0.5f))
					.SetBorderLeft(Border.NO_BORDER)
					.SetBorderRight(Border.NO_BORDER)
					.SetBorderTop(Border.NO_BORDER)
					.SetPaddingTop(3)
					.SetPaddingBottom(3)
					.SetPaddingLeft(4)
					.SetPaddingRight(3));

			tabla.AddCell(
				new Cell()
					.Add(new Paragraph(Dinero(importe))
						.SetFont(regular)
						.SetFontSize(8)
						.SetFixedLeading(10)
						.SetTextAlignment(TextAlignment.RIGHT)
						.SetMargin(0))
					.SetBorderBottom(new SolidBorder(linea, 0.5f))
					.SetBorderLeft(Border.NO_BORDER)
					.SetBorderRight(Border.NO_BORDER)
					.SetBorderTop(Border.NO_BORDER)
					.SetPaddingTop(3)
					.SetPaddingBottom(3)
					.SetPaddingLeft(3)
					.SetPaddingRight(4));
		}


		private void AgregarTotal(
		Table tabla,
		string concepto,
		string importe,
		PdfFont bold,
		DeviceRgb gris)
		{
			tabla.AddCell(
				new Cell()
					.Add(new Paragraph(concepto)
						.SetFont(bold)
						.SetFontSize(8.5f)
						.SetMargin(0))
					.SetBackgroundColor(gris)
					.SetBorder(Border.NO_BORDER)
					.SetPaddingTop(6)
					.SetPaddingBottom(6)
					.SetPaddingLeft(5)
					.SetPaddingRight(3));

			tabla.AddCell(
				new Cell()
					.Add(new Paragraph(Dinero(importe))
						.SetFont(bold)
						.SetFontSize(8.5f)
						.SetTextAlignment(TextAlignment.RIGHT)
						.SetMargin(0))
					.SetBackgroundColor(gris)
					.SetBorder(Border.NO_BORDER)
					.SetPaddingTop(6)
					.SetPaddingBottom(6)
					.SetPaddingLeft(3)
					.SetPaddingRight(5));
		}

		private Cell CeldaLogo(DeviceRgb fondo)
		{
			byte[] imagenBytes;

			using (MemoryStream ms = new MemoryStream())
			{
				Properties.Resources.logo.Save(
					ms, ImageFormat.Png);

				imagenBytes = ms.ToArray();
			}

			iText.Layout.Element.Image logo =
				new iText.Layout.Element.Image(
					ImageDataFactory.Create(imagenBytes));

			logo.ScaleToFit(48, 43);

			return new Cell()
				.Add(logo)
				.SetWidth(58)
				.SetHeight(48)
				.SetBackgroundColor(
					new DeviceRgb(255, 255, 255))
				.SetBorder(Border.NO_BORDER)
				.SetPadding(2)
				.SetVerticalAlignment(
					VerticalAlignment.MIDDLE)
				.SetTextAlignment(
					TextAlignment.LEFT);
		}


		private Table CrearTablaPagoNeto(
			string titulo,
			string importe,
			PdfFont bold,
			DeviceRgb blanco,
			DeviceRgb grisOscuro)
		{
			Table neto = new Table(
				UnitValue.CreatePercentArray(new float[] { 55, 45 }))
				.UseAllAvailableWidth()
				.SetMarginTop(5);

			neto.AddCell(
				new Cell()
					.Add(new Paragraph(titulo)
						.SetFont(bold)
						.SetFontSize(12)
						.SetFontColor(blanco)
						.SetTextAlignment(TextAlignment.CENTER)
						.SetMargin(0))
					.SetBackgroundColor(grisOscuro)
					.SetVerticalAlignment(VerticalAlignment.MIDDLE)
					.SetBorder(Border.NO_BORDER)
					.SetPadding(6));

			neto.AddCell(
				new Cell()
					.Add(new Paragraph("$ " + Dinero(importe))
						.SetFont(bold)
						.SetFontSize(15)
						.SetFontColor(blanco)
						.SetTextAlignment(TextAlignment.CENTER)
						.SetMargin(0))
					.SetBackgroundColor(new DeviceRgb(105, 105, 105))
					.SetVerticalAlignment(VerticalAlignment.MIDDLE)
					.SetBorder(Border.NO_BORDER)
					.SetPadding(6));

			return neto;
		}


		public void GenerarPDFParaImprimir()
		{
			try
			{
				var filas = frm.dgvRecibo.Rows
					.Cast<DataGridViewRow>()
					.Where(f =>
						!f.IsNewRow &&
						f.Cells["Codigo"].Value != null &&
						!string.IsNullOrWhiteSpace(
							f.Cells["Codigo"].Value.ToString()))
					.OrderBy(f =>
						f.Cells["CodigoLugarPago"].Value?.ToString().Trim())
					.ThenBy(f =>
						f.Cells["NombreCompleto"].Value?.ToString().Trim())
					.ToList();

				if (filas.Count == 0)
				{
					MessageBox.Show(
						"No hay recibos para imprimir.",
						"Recibos",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);
					return;
				}

				if (!frm.rbCfdi.Checked && !frm.rbNormal.Checked)
				{
					MessageBox.Show("Selecciona el tipo de recibo.");
					return;
				}

				bool esCfdi = frm.rbCfdi.Checked;

				string carpeta = System.IO.Path.Combine(
					System.IO.Path.GetTempPath(),
					"SisUvex_Impresiones");

				System.IO.Directory.CreateDirectory(carpeta);

				string nombre = $"Recibos_{Guid.NewGuid():N}.pdf";
				string ruta = System.IO.Path.Combine(carpeta, nombre);

				using (PdfWriter writer = new PdfWriter(ruta))
				using (PdfDocument pdf = new PdfDocument(writer))
				using (Document documento = new Document(pdf, PageSize.LETTER))
				{
					documento.SetMargins(0, 0, 0, 0);

					string ultimoLugarPago = null;
					int recibosEnPagina = 0;

					for (int i = 0; i < filas.Count; i++)
					{
						string lugarPago = filas[i]
							.Cells["CodigoLugarPago"]
							.Value?.ToString()
							.Trim() ?? "";

						// Si cambia el lugar de pago, iniciar otra hoja
						if (ultimoLugarPago != null &&
							!string.Equals(
								ultimoLugarPago,
								lugarPago,
								StringComparison.OrdinalIgnoreCase))
						{
							documento.Add(
								new AreaBreak(AreaBreakType.NEXT_PAGE));

							recibosEnPagina = 0;
						}
						// Máximo dos recibos por hoja
						else if (recibosEnPagina >= 2)
						{
							documento.Add(
								new AreaBreak(AreaBreakType.NEXT_PAGE));

							recibosEnPagina = 0;
						}

						float altura = esCfdi ? 391 : 380;

						Div recibo = new Div()
							.SetWidth(UnitValue.CreatePercentValue(100))
							.SetHeight(altura)
							.SetMinHeight(altura)
							.SetMaxHeight(altura)
							.SetMargin(0)
							.SetPadding(esCfdi ? 2 : 3)
							.SetBorder(new SolidBorder(
								new DeviceRgb(65, 65, 65), 0.5f));

						if (esCfdi)
							CrearReciboCFDI(recibo, filas[i]);
						else
							CrearReciboNormal(recibo, filas[i]);

						documento.Add(recibo);

						recibosEnPagina++;
						ultimoLugarPago = lugarPago;
					}
				}

				Process.Start(new ProcessStartInfo
				{
					FileName = ruta,
					UseShellExecute = true
				});
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error al preparar los recibos:\n" + ex.Message,
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}
	}
}
