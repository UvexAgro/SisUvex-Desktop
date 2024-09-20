using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iText.Layout.Borders;

namespace SisUvex.Archivo.Manifiesto
{
    internal class ClsPDFPackingList
    {
        ClsQueryManifest queryManifest = new ClsQueryManifest();
        ClsQueryLoadingMap queryLoadingMap = new ClsQueryLoadingMap();
        ClsPDFManifiesto pdfManifest = new ClsPDFManifiesto();
        PdfFont font = PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN);
        PdfFont boldFont = PdfFontFactory.CreateFont(StandardFonts.TIMES_BOLD);
        Paragraph separator = new Paragraph("\n");
        string logoPath = "";
        DeviceRgb lightGreen = new DeviceRgb(190, 215, 219);

        int fontSizeHeader = 14;
        int fontSizeTitle = 12;
        int fontSizeSubtitle = 11;
        int fontSizeBody = 10;
        int fontPosition = 8;
        int fontMixSize = 6;
        int heightCell = 50;
        int heigthCarrier = 120;
        float maxWidthLogo = 72;
        float cellHeight = 68;
        int thermoPos = 0;

        public void CreatePDFPackingList(string manifestNumber)
        {
            queryManifest.GetManifestData(manifestNumber);
            queryManifest.GetManifestDetailData(manifestNumber);
            queryManifest.GetManifestTotalData(manifestNumber);
            queryLoadingMap.GetLoadingMapData(manifestNumber);

            // Crear un nuevo documento PDF
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string manifestDirectory = Path.Combine(desktopPath, "Manifiestos", queryManifest.distributorShortName, $"{manifestNumber}");
            if (!Directory.Exists(manifestDirectory))
            {
                Directory.CreateDirectory(manifestDirectory);
            }

            string manifestPath = Path.Combine(manifestDirectory, $"PAKING LIST {manifestNumber}.pdf");
            PdfWriter writer = new PdfWriter(manifestPath);
            PdfDocument pdf = new PdfDocument(writer);
            iText.Layout.Document document = new iText.Layout.Document(pdf);

            //Metodos que componen el diseño del PDF
            DesignPDFPackingListHeader(document, manifestNumber);
            // Cerrar el documento
            document.Close();
        }

        public void DesignPDFPackingListHeader(iText.Layout.Document document, string manifestNumber)
        {
            // Crear una tabla con 3 columnas
            Table tableHeader = new Table(3);
            tableHeader.SetWidth(UnitValue.CreatePercentValue(100));
            tableHeader.SetBorder(Border.NO_BORDER);


            // Cargar el logo
            if (queryManifest.shipperLogo != null)
            {

                logoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", queryManifest.shipperLogo + "Logo.png");
            }


            iText.Layout.Element.Image logo = new iText.Layout.Element.Image(ImageDataFactory.Create(logoPath));

            float scale = maxWidthLogo / logo.GetImageScaledHeight();
            logo.ScaleToFit(maxWidthLogo, logo.GetImageScaledHeight() * scale);

            logo.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.LEFT);

            // Agregar el logo a la primera celda de la tabla
            Cell logoCell = new Cell().Add(logo);
            logoCell.SetBorder(Border.NO_BORDER);
            logoCell.SetPaddingRight(0);
            tableHeader.AddCell(logoCell);

            // Crear un nuevo párrafo para el nombre del embarcador con un tamaño de fuente mayor
            Paragraph shipperNameParagraph = new Paragraph(queryManifest.shipperName)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetFontSize(fontSizeHeader) // Cambiar el tamaño de la fuente a 14
                .SetFont(boldFont);

            // Crear nuevos párrafos para la dirección, la ciudad y el RFC del embarcador con un tamaño de fuente menor
            Paragraph shipperAddressParagraph = new Paragraph(queryManifest.shipperAddress)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetFontSize(fontSizeBody) // Cambiar el tamaño de la fuente a 10
                .SetFont(font);

            Paragraph shipperCityParagraph = new Paragraph(queryManifest.shipperCity)
                .Add(" \n RFC: " + queryManifest.shipperRFC)
                .Add(" \n GGN: " + queryManifest.shipperGGN)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetFontSize(fontSizeBody) // Cambiar el tamaño de la fuente a 10
                .SetFont(font);

            // Agregar los párrafos a la celda
            Cell shipperCell = new Cell();
            shipperCell.Add(shipperNameParagraph);
            shipperCell.Add(shipperAddressParagraph);
            shipperCell.Add(shipperCityParagraph);
            shipperCell.SetBorder(Border.NO_BORDER);
            shipperCell.SetPaddingLeft(25); // Agregar relleno a la izquierda para separar el texto del margen
            shipperCell.SetPaddingRight(0);
            tableHeader.AddCell(shipperCell);


            // Crear un nuevo párrafo para el número de manifiesto
            Paragraph manifestParagraph = new Paragraph("PK LIST: ")
                .Add(new Text(queryManifest.manifestNumber).SetFontColor(ColorConstants.RED).SetFont(boldFont))
                .Add("\n")
                .Add(queryManifest.manifestDate.ToString("dd 'de' MMMM 'de' yyyy"))
                .Add("\n")
                .Add("Hora de salida: ")
                .Add(queryManifest.manifestShipmentTime.ToString())
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT)
                .SetFontSize(fontSizeBody)
                .SetFont(font);

            // Agregar condicionalmente la propiedad PO
            if (!string.IsNullOrEmpty(queryManifest.manifestPO))
            {
                manifestParagraph.Add("\n")
                    .Add("PO: ")
                    .Add(new Text(queryManifest.manifestPO).SetFontColor(ColorConstants.RED));
            }

            if (!string.IsNullOrEmpty(queryManifest.manifestBooking))
            {
                manifestParagraph.Add("\n")
                    .Add("Booking: ")
                    .Add(new Text(queryManifest.manifestBooking).SetFontColor(ColorConstants.RED));
            }

            // Agregar el párrafo a la tercera celda de la tabla
            Cell manifestCell = new Cell().Add(manifestParagraph);
            manifestCell.SetBorder(Border.NO_BORDER);
            manifestCell.SetPaddingLeft(0);
            tableHeader.AddCell(manifestCell);

            // Agregar la tabla al documento
            document.Add(tableHeader);

            // Crear un separador de línea
            LineSeparator ls = new LineSeparator(new SolidLine());
            document.Add(ls);

            // Crear un nuevo párrafo para el título de la tabla


        }

        public void DesignPDFGeneralTable(iText.Layout.Document document, string manifestNumber)
        {
            // Crear una tabla con 3 columnas
            Table table = new Table(2);
            table.SetWidth(UnitValue.CreatePercentValue(100));
            table.SetBorder(Border.NO_BORDER);

            // Crear un nuevo párrafo para el título de la tabla
            Paragraph titleParagraph = new Paragraph("PACKING LIST")
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetFontSize(fontSizeTitle)
                .SetFont(boldFont);

            // Agregar el párrafo a la primera celda de la tabla
            Cell titleCell = new Cell(1, 2).Add(titleParagraph);
            titleCell.SetBorder(Border.NO_BORDER);
            table.AddCell(titleCell);



            // Crear un nuevo párrafo para el encabezado de la tabla
            Paragraph headerParagraph = new Paragraph("LOAD")
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetFontSize(fontSizeSubtitle)
                .SetFont(boldFont);

            // Agregar el párrafo a la primera celda de la tabla
            Cell headerCell = new Cell().Add(headerParagraph);
            headerCell.SetBorder(Border.NO_BORDER);
            table.AddCell(headerCell);

            headerParagraph = new Paragraph("DESCRIPCIÓN")
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetFontSize(fontSizeSubtitle)
                .SetFont(boldFont);

            headerCell = new Cell().Add(headerParagraph);
            headerCell.SetBorder(Border.NO_BORDER);
            table.AddCell(headerCell);

            headerParagraph = new Paragraph("OBSERVACIONES")
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetFontSize(fontSizeSubtitle)
                .SetFont(boldFont);

            headerCell = new Cell().Add(headerParagraph);
            headerCell.SetBorder(Border.NO_BORDER);
            table.AddCell(headerCell);

            // Crear un nuevo párrafo para el contenido de la tabla
        }
    }
}
