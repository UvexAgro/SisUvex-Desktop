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
					guardar.FileName = esCfdi
						? "Recibos_CFDI.pdf"
						: "Recibos_Normales.pdf";

					guardar.Title = "Guardar recibos";

					if (guardar.ShowDialog() != DialogResult.OK)
						return;

					using (PdfWriter writer = new PdfWriter(guardar.FileName))
					using (PdfDocument pdf = new PdfDocument(writer))
					using (Document documento = new Document(pdf, PageSize.LETTER))
					{
						// Sin margen vertical: dos mitades de 396 puntos
						documento.SetMargins(0, 0, 0, 0);

						for (int i = 0; i < filas.Count; i++)
						{
							if (i > 0 && i % 2 == 0)
							{
								documento.Add(
									new AreaBreak(AreaBreakType.NEXT_PAGE));
							}
							Div recibo = new Div()
								.SetWidth(UnitValue.CreatePercentValue(100))
								.SetHeight(391)
								.SetMinHeight(391)
								.SetMaxHeight(391)
								.SetMargin(0)
								.SetPadding(2)
								.SetBorder(new SolidBorder(
									new DeviceRgb(65, 65, 65), 0.5f));

							if (esCfdi)
								CrearReciboCFDI(recibo, filas[i]);
							else
								CrearReciboNormal(recibo, filas[i]);

							documento.Add(recibo);
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

			// ENCABEZADO
			AgregarEncabezado(
				contenedor, bold, negro, grisOscuro);

			// DATOS DEL EMPLEADO
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

			AgregarDato(datos, "al:",
				ObtenerFecha(frm.dtpFechaFinal.Value), bold, regular);

			AgregarDato(datos, "Días de Salario:",
				Valor(fila, "DiasTrabajados"), bold, regular);

			// Completar las cuatro columnas de la última fila
			AgregarCeldaVacia(datos);
			AgregarCeldaVacia(datos);

			contenedor.Add(datos);

			AgregarLinea(contenedor, negro, 1, 4);

			// TABLA PRINCIPAL
			Table principal = new Table(
				UnitValue.CreatePercentArray(new float[] { 52, 48 }))
				.UseAllAvailableWidth();

			// PERCEPCIONES
			Table percepciones = new Table(
				UnitValue.CreatePercentArray(new float[] { 72, 28 }))
				.UseAllAvailableWidth();

			EncabezadoSeccion(
				percepciones, "PERCEPCIONES", gris, bold);

			AgregarConcepto(percepciones, "Sueldo Ordinario:",
				Valor(fila, "SueldoOrdinario"), regular, bold);

			AgregarConcepto(percepciones, "Séptimo Día:",
				Valor(fila, "SeptimoDia"), regular, bold);

			AgregarConcepto(percepciones, "Propor. Aguinaldo:",
				Valor(fila, "ProporcionalAguinaldo"), regular, bold);

			AgregarConcepto(percepciones, "Propor. Vacaciones:",
				Valor(fila, "ProporcionalVacaciones"), regular, bold);

			AgregarConcepto(percepciones, "Prima Vacacional:",
				Valor(fila, "PrimaVacacional"), regular, bold);

			AgregarConcepto(percepciones, "Domingo:",
				Valor(fila, "Domingo"), regular, bold);

			AgregarConcepto(percepciones, "Prima Dominical:",
				Valor(fila, "PrimaDominical"), regular, bold);

			AgregarConcepto(percepciones, "Productividad:",
				Valor(fila, "Productividad"), regular, bold);

			AgregarConcepto(percepciones, "Asistencia:",
				Valor(fila, "Asistencia"), regular, bold);

			AgregarConcepto(percepciones, "Bonos:",
				Valor(fila, "Bonos"), regular, bold);

			AgregarTotal(percepciones, "Total Percepciones:",
				Valor(fila, "TotalPercepciones"), bold, gris);

			// DEDUCCIONES
			Table deducciones = new Table(
				UnitValue.CreatePercentArray(new float[] { 72, 28 }))
				.UseAllAvailableWidth();

			EncabezadoSeccion(
				deducciones, "DEDUCCIONES", gris, bold);

			AgregarConcepto(deducciones, "ISPT 4%:",
				Valor(fila, "ISPT"), regular, bold);

			AgregarConcepto(deducciones, "Deducciones:",
				Valor(fila, "OtrasDeducciones"), regular, bold);

			AgregarTotal(deducciones, "Total Deducción:",
				Valor(fila, "TotalDeducciones"), bold, gris);

			// PAGO NETO
			Table neto = CrearTablaPagoNeto(
				"PAGO NETO:",
				Valor(fila, "ImporteNeto"),
				bold,
				blanco,
				grisOscuro);

			deducciones.AddCell(
				new Cell(1, 2)
					.Add(neto)
					.SetBorder(Border.NO_BORDER)
					.SetPadding(0));

			// DISTRIBUCIÓN DE LAS DOS COLUMNAS
			principal.AddCell(
				new Cell()
					.Add(percepciones)
					.SetBorder(Border.NO_BORDER)
					.SetPaddingRight(7));

			principal.AddCell(
				new Cell()
					.Add(deducciones)
					.SetBorderLeft(
						new SolidBorder(grisOscuro, 0.8f))
					.SetBorderTop(Border.NO_BORDER)
					.SetBorderRight(Border.NO_BORDER)
					.SetBorderBottom(Border.NO_BORDER)
					.SetPaddingLeft(7));

			contenedor.Add(principal);

			// TEXTO LEGAL
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

			// FIRMAS
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

			contenedor.SetPadding(5);

			AgregarEncabezado(
			contenedor, bold, negro, grisOscuro, true);

			// DATOS DEL EMPLEADO
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

			AgregarDato(datos, "Lugar de Pago:",
				Valor(fila, "LugarPago"), bold, regular);

			AgregarDato(datos, "Hasta:",
				ObtenerFecha(frm.dtpFechaFinal.Value), bold, regular);

			AgregarDato(datos, "No. Afiliación al IMSS:",
				Valor(fila, "NumeroIMSS"), bold, regular);

			AgregarCeldaVacia(datos);
			AgregarCeldaVacia(datos);

			contenedor.Add(datos);

			AgregarLinea(contenedor, negro, 1, 4);

			// CUERPO
			Table cuerpo = new Table(
				UnitValue.CreatePercentArray(
					new float[] { 51, 49 }))
				.UseAllAvailableWidth();

			// PERCEPCIONES DIARIAS
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

			// TOTALES
			Table totales = new Table(
				UnitValue.CreatePercentArray(
					new float[] { 65, 35 }))
				.UseAllAvailableWidth();

			EncabezadoSeccion(
				totales, "TOTALES", gris, bold);

			AgregarConcepto(totales, "Total Percepciones:",
				Valor(fila, "TotalPercepciones"), regular, bold);

			AgregarConcepto(totales, "Descuentos:",
				Valor(fila, "TotalDeducciones"), regular, bold);

			Table neto = CrearTablaPagoNeto(
				"NETO A PAGAR:",
				Valor(fila, "ImporteNeto"),
				bold,
				blanco,
				grisOscuro);

			neto.SetMarginTop(22);

			totales.AddCell(
				new Cell(1, 2)
					.Add(neto)
					.SetBorder(Border.NO_BORDER)
					.SetPadding(0));

			// COLUMNAS
			cuerpo.AddCell(
				new Cell()
					.Add(diarias)
					.SetBorder(Border.NO_BORDER)
					.SetPaddingRight(7));

			cuerpo.AddCell(
				new Cell()
					.Add(totales)
					.SetBorderLeft(
						new SolidBorder(grisOscuro, 0.8f))
					.SetBorderTop(Border.NO_BORDER)
					.SetBorderRight(Border.NO_BORDER)
					.SetBorderBottom(Border.NO_BORDER)
					.SetPaddingLeft(7));

			contenedor.Add(cuerpo);

			// ESPACIO PARA DISTRIBUIR LAS FIRMAS
			contenedor.Add(
				new Div().SetHeight(65));

			// FIRMAS
			AgregarFirmas(contenedor, bold);
		}



		private void AgregarFirmas(Div contenedor, PdfFont bold)
		{
			Table firmas = new Table(
				UnitValue.CreatePercentArray(new float[] { 50, 50 }))
				.UseAllAvailableWidth()
				.SetMarginTop(5)
				.SetMarginBottom(0)
				.SetKeepTogether(true);

			firmas.AddCell(CrearCeldaFirma(
				"Firma del Trabajador", bold));

			firmas.AddCell(CrearCeldaFirma(
				"Firma del Patrón", bold));

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

	
		private void AgregarDato(Table tabla,string etiqueta,string valor,PdfFont bold,PdfFont regular)
		{
			tabla.AddCell(
				new Cell()
					.Add(new Paragraph(etiqueta)
						.SetFont(bold)
						.SetFontSize(7.5f)
						.SetMargin(0))
					.SetBorder(Border.NO_BORDER)
					.SetPadding(2));

			tabla.AddCell(
				new Cell()
					.Add(new Paragraph(valor ?? "")
						.SetFont(regular)
						.SetFontSize(7.5f)
						.SetMargin(0))
					.SetBorder(Border.NO_BORDER)
					.SetPadding(2));
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
						.SetFontSize(10)
						.SetFontColor(new DeviceRgb(35, 35, 35))
						.SetTextAlignment(TextAlignment.CENTER)
						.SetMargin(0))
					.SetBackgroundColor(gris)
					.SetBorder(Border.NO_BORDER)
					.SetPadding(5));
		}




		private void AgregarConcepto(
			Table tabla,
			string concepto,
			string importe,
			PdfFont regular,
			PdfFont bold)
		{
			DeviceRgb linea = new DeviceRgb(210, 210, 210);

			tabla.AddCell(
				new Cell()
					.Add(new Paragraph(concepto)
						.SetFont(regular)
						.SetFontSize(8)
						.SetFixedLeading(9)
						.SetMargin(0))
					.SetBorderBottom(new SolidBorder(linea, 0.5f))
					.SetBorderLeft(Border.NO_BORDER)
					.SetBorderRight(Border.NO_BORDER)
					.SetBorderTop(Border.NO_BORDER)
					.SetPadding(2));

			tabla.AddCell(
				new Cell()
					.Add(new Paragraph(Dinero(importe))
						.SetFont(regular)
						.SetFontSize(8)
						.SetFixedLeading(9)
						.SetTextAlignment(TextAlignment.RIGHT)
						.SetMargin(0))
					.SetBorderBottom(new SolidBorder(linea, 0.5f))
					.SetBorderLeft(Border.NO_BORDER)
					.SetBorderRight(Border.NO_BORDER)
					.SetBorderTop(Border.NO_BORDER)
					.SetPadding(2));
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
						.SetFontSize(9)
						.SetMargin(0))
					.SetBackgroundColor(gris)
					.SetBorder(Border.NO_BORDER)
					.SetPadding(5));

			tabla.AddCell(
				new Cell()
					.Add(new Paragraph(Dinero(importe))
						.SetFont(bold)
						.SetFontSize(9)
						.SetTextAlignment(TextAlignment.RIGHT)
						.SetMargin(0))
					.SetBackgroundColor(gris)
					.SetBorder(Border.NO_BORDER)
					.SetPadding(5));
		}

		private Cell CeldaLogo(DeviceRgb fondo)
		{
			byte[] imagenBytes;

			using (MemoryStream ms = new MemoryStream())
			{
				Properties.Resources.logoUvex.Save(
					ms, ImageFormat.Png);

				imagenBytes = ms.ToArray();
			}

			iText.Layout.Element.Image logo =
				new iText.Layout.Element.Image(
					ImageDataFactory.Create(imagenBytes));

			logo.ScaleToFit(48, 43);

			Table cuadroLogo = new Table(1)
				.SetWidth(58)
				.SetHeight(48);

			cuadroLogo.AddCell(
				new Cell()
					.Add(logo)
					.SetBackgroundColor(fondo)
					.SetTextAlignment(TextAlignment.CENTER)
					.SetVerticalAlignment(VerticalAlignment.MIDDLE)
					.SetPadding(2)
					.SetBorder(Border.NO_BORDER));

			return new Cell()
				.Add(cuadroLogo)
				.SetBorder(Border.NO_BORDER)
				.SetPadding(0)
				.SetVerticalAlignment(VerticalAlignment.MIDDLE)
				.SetTextAlignment(TextAlignment.LEFT);
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

	}
}
