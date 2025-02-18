using iText.IO.Image;
using iText.Kernel.Pdf;
using iText.Kernel.Font;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Borders;
using iText.Layout.Properties;
using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Pdf.Canvas.Draw;
using System.Data;
using DocumentFormat.OpenXml.Drawing.Charts;
namespace SisUvex.Archivo.Manifiesto
{
    internal class ClsPruebaManifiesto
    {
        ClsQueryManifest queryManifest = new ClsQueryManifest();
        PdfFont font = PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN);
        PdfFont boldFont = PdfFontFactory.CreateFont(StandardFonts.TIMES_BOLD);
        Paragraph separator = new Paragraph("\n");
        string logoPath = "";
        DeviceRgb lightGreen = new DeviceRgb(190, 215, 219);

        int fontSizeHeader = 14;
        int fontSizeTitle = 12;
        int fontSizeSubtitle = 11;
        int fontSizeBody = 10;
        int heightCell = 75;
        int heightCellDetail = 120;
        int heigthCarrier = 120;
        float maxWidthLogo = 72;



        public void CreatePDFManifest(string manifestNumber)
        {
            queryManifest.GetManifestData(manifestNumber);
            queryManifest.GetManifestDetailData(manifestNumber);
            queryManifest.GetManifestTotalData(manifestNumber);

            // Crear un nuevo documento PDF
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string manifestDirectory = Path.Combine(desktopPath, "Manifiestos", queryManifest.distributorShortName, $"{manifestNumber}");
            if (!Directory.Exists(manifestDirectory))
            {
                Directory.CreateDirectory(manifestDirectory);
            }

            string manifestPath = Path.Combine(manifestDirectory, $"MAN {manifestNumber}.pdf");
            PdfWriter writer = new PdfWriter(manifestPath);
            PdfDocument pdf = new PdfDocument(writer);
            iText.Layout.Document document = new iText.Layout.Document(pdf);

            //Metodos que componen el diseño del PDF
            DesignPDFManifestHeader(document, manifestNumber);
            DesignPDFManifestClientAndConsigne(document, manifestNumber);
            DesignPDFManifestCustoms(document, manifestNumber);
            DesignPDFManifestTransport(document, manifestNumber);
            DesignPDFManifestDetails(document, manifestNumber);
            DesignPDFManifestRemisionTable(document, manifestNumber);

            // Cerrar el documento
            document.Close();

            MessageBox.Show($"Manifiesto generado correctamente en: \n {manifestPath}", "Manifiesto", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void DesignPDFManifestHeader(iText.Layout.Document document, string manifestNumber)
        {
            // Crear una tabla con 3 columnas
            Table table = new Table(3);
            table.SetWidth(UnitValue.CreatePercentValue(100));
            table.SetBorder(Border.NO_BORDER);


            // Cargar el logo
            if (queryManifest.shipperLogo != null)
            {
                //string dataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                logoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", queryManifest.shipperLogo + "Logo.png");
                iText.Layout.Element.Image logo = new iText.Layout.Element.Image(ImageDataFactory.Create(logoPath));

                float scale = maxWidthLogo / logo.GetImageScaledHeight();
                logo.ScaleToFit(maxWidthLogo, logo.GetImageScaledHeight() * scale);

                logo.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.LEFT);

                // Agregar el logo a la primera celda de la tabla
                Cell logoCell = new Cell().Add(logo);
                logoCell.SetBorder(Border.NO_BORDER);
                logoCell.SetPaddingRight(0);
                table.AddCell(logoCell);

            }
            else
            {
                // Crear una celda vacía para mantener la alineación de la tabla
                Cell emptyCell = new Cell();
                emptyCell.SetBorder(Border.NO_BORDER);
                table.AddCell(emptyCell);
            }

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
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetFontSize(fontSizeBody) // Cambiar el tamaño de la fuente a 10
                .SetFont(font);

            Paragraph shipperRFCParagraph = new Paragraph("RFC: " + queryManifest.shipperRFC)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetFontSize(fontSizeBody) // Cambiar el tamaño de la fuente a 10
                .SetFont(font);

            Paragraph shipperGGNParagraph = new Paragraph("GGN: " + queryManifest.shipperGGN)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetFontSize(fontSizeBody) // Cambiar el tamaño de la fuente a 10
                .SetFont(font);

            // Agregar los párrafos a la celda
            Cell shipperCell = new Cell();
            shipperCell.Add(shipperNameParagraph);
            shipperCell.Add(shipperAddressParagraph);
            shipperCell.Add(shipperCityParagraph);
            shipperCell.Add(shipperRFCParagraph);
            shipperCell.Add(shipperGGNParagraph);
            shipperCell.SetBorder(Border.NO_BORDER);
            shipperCell.SetPaddingLeft(25); // Agregar relleno a la izquierda para separar el texto del margen
            shipperCell.SetPaddingRight(0);
            table.AddCell(shipperCell);


            // Crear un nuevo párrafo para el número de manifiesto
            Paragraph manifestParagraph = new Paragraph("MANIFIESTO: ")
                .Add(new Text(queryManifest.manifestNumber).SetFontColor(ColorConstants.RED).SetFont(boldFont))
                .Add("\n")
                .Add(queryManifest.manifestDate?.ToString("dd 'de' MMMM 'de' yyyy"))
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
            table.AddCell(manifestCell);

            // Agregar la tabla al documento
            document.Add(table);


            /*
            // Crear un separador de línea
            LineSeparator ls = new LineSeparator(new SolidLine());
            document.Add(ls);

            // Crear un párrafo vacío para agregar un espacio en blanco
            Paragraph separator = new Paragraph("\n");
            document.Add(separator);
            */
        }

        public void DesignPDFManifestClientAndConsigne(iText.Layout.Document document, string manifestNumber)
        {
            // Crear una tabla con 2 columnas
            Table tableOriginDestiny = new Table(new float[] { 1, 1 });
            tableOriginDestiny.SetWidth(UnitValue.CreatePercentValue(100));

            // Crear un nuevo párrafo para el nombre del embarcador con un tamaño de fuente mayor
            Paragraph distributorCellTitle = new Paragraph("DISTRIBUIDOR")
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetFontSize(fontSizeTitle) // Cambiar el tamaño de la fuente a 14
                .SetFont(boldFont);

            // Crear una celda para el título del distribuidor y agregarle un borde
            Cell distributorTitleCell = new Cell();
            distributorTitleCell.Add(distributorCellTitle);
            distributorTitleCell.SetBorder(new SolidBorder(1));
            distributorTitleCell.SetBackgroundColor(lightGreen); // Establecer el color de fondo a gris claro
            tableOriginDestiny.AddCell(distributorTitleCell);

            // Crear un nuevo párrafo para el nombre del embarcador con un tamaño de fuente mayor
            Paragraph consigneTitleParagraph = new Paragraph("CONSIGNATARIO")
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetFontSize(fontSizeTitle) // Cambiar el tamaño de la fuente a 14
                .SetFont(boldFont);

            // Crear una celda para el título del consignatario y agregarle un borde
            Cell consigneTitleCell = new Cell();
            consigneTitleCell.Add(consigneTitleParagraph);
            consigneTitleCell.SetBorder(new SolidBorder(1));
            consigneTitleCell.SetBackgroundColor(lightGreen); // Establecer el color de fondo a gris claro
            tableOriginDestiny.AddCell(consigneTitleCell);


            // Crear un nuevo párrafo para el nombre del embarcador con un tamaño de fuente mayor
            Paragraph distributorNameParagraph = new Paragraph(queryManifest.distributorName)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                .SetFontSize(fontSizeBody) // Cambiar el tamaño de la fuente a 14
                .SetFont(boldFont);

            // Crear nuevos párrafos para la dirección, la ciudad y el RFC del embarcador con un tamaño de fuente menor
            Paragraph distributorAddressParagraph = new Paragraph(queryManifest.distributorAddress)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                .SetFontSize(fontSizeBody) // Cambiar el tamaño de la fuente a 10
                .SetFont(font);

            Paragraph distributorCityParagraph = new Paragraph(queryManifest.distributorCity)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                .SetFontSize(fontSizeBody) // Cambiar el tamaño de la fuente a 10
                .SetFont(font);

            Paragraph distributorCountryParagraph = new Paragraph(queryManifest.distributorCountry)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                .SetFontSize(fontSizeBody) // Cambiar el tamaño de la fuente a 10
                .SetFont(font);

            Paragraph distributorRFCParagraph = new Paragraph(queryManifest.distributorTAXID)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                .SetFontSize(fontSizeBody) // Cambiar el tamaño de la fuente a 10
                .SetFont(font);


            // Agregar los párrafos a la celda
            Cell distributorCell = new Cell();
            distributorCell.Add(distributorNameParagraph);
            distributorCell.Add(distributorAddressParagraph);
            distributorCell.Add(distributorCityParagraph);
            distributorCell.Add(distributorCountryParagraph);
            distributorCell.Add(distributorRFCParagraph);
            distributorCell.SetPaddingLeft(5); // Agregar relleno a la izquierda para separar el texto del margen
            distributorCell.SetPaddingRight(0);
            distributorCell.SetWidth(UnitValue.CreatePercentValue(50)); // Establecer el ancho de la celda al 50% del ancho de la tabla
            distributorCell.SetHeight(heightCell); // Establecer la altura de la celda a 1.5 pulgadas (1 pulgada = 72 puntos)
            tableOriginDestiny.AddCell(distributorCell);




            // Crear un nuevo párrafo para el nombre del embarcador con un tamaño de fuente mayor
            Paragraph consigneNameParagraph = new Paragraph(queryManifest.consigneeName ?? "")
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                .SetFontSize(fontSizeBody) // Cambiar el tamaño de la fuente a 14
                .SetFont(boldFont);

            // Crear nuevos párrafos para la dirección, la ciudad y el RFC del embarcador con un tamaño de fuente menor
            Paragraph consigneAddressParagraph = new Paragraph(queryManifest.consigneeAddress ?? "")
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                .SetFontSize(fontSizeBody) // Cambiar el tamaño de la fuente a 10
                .SetFont(font);

            Paragraph consigneCityParagraph = new Paragraph(queryManifest.consigneeCity ?? "")
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                .SetFontSize(fontSizeBody) // Cambiar el tamaño de la fuente a 10
                .SetFont(font);

            Paragraph consigneCountryParagraph = new Paragraph(queryManifest.consigneeCountry ?? "")
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                .SetFontSize(fontSizeBody) // Cambiar el tamaño de la fuente a 10
                .SetFont(font);


            Paragraph consigneRFCParagraph = new Paragraph(queryManifest.consigneeTAXID ?? "")
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                .SetFontSize(fontSizeBody) // Cambiar el tamaño de la fuente a 10
                .SetFont(font);


            // Agregar los párrafos a la celda
            Cell consigneCell = new Cell();
            consigneCell.Add(consigneNameParagraph);
            consigneCell.Add(consigneAddressParagraph);
            consigneCell.Add(consigneCityParagraph);
            consigneCell.Add(consigneCountryParagraph);
            consigneCell.Add(consigneRFCParagraph);
            consigneCell.SetPaddingLeft(5); // Agregar relleno a la izquierda para separar el texto del margen
            consigneCell.SetPaddingRight(0);
            consigneCell.SetWidth(UnitValue.CreatePercentValue(50)); // Establecer el ancho de la celda al 50% del ancho de la tabla
            consigneCell.SetHeight(heightCell); // Establecer la altura de la celda a 1.5 pulgadas (1 pulgada = 72 puntos)
            tableOriginDestiny.AddCell(consigneCell);


            // Agregar la tabla al documento
            document.Add(tableOriginDestiny);

            // Crear un párrafo vacío para agregar un espacio en blanco
            /*
            Paragraph separator = new Paragraph("\n");
            document.Add(separator);
            */



        }

        public void DesignPDFManifestCustoms(iText.Layout.Document document, string manifestNumber)
        {
            // Crear una tabla con 2 columnas
            Table tableCustoms = new Table(new float[] { 1, 1 });
            tableCustoms.SetWidth(UnitValue.CreatePercentValue(100));

            // Crear un nuevo párrafo para el nombre del embarcador con un tamaño de fuente mayor
            Paragraph customMXCellTitle = new Paragraph("ADUANA MEXICANA")
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetFontSize(fontSizeTitle) // Cambiar el tamaño de la fuente a 14
                .SetFont(boldFont);

            // Crear una celda para el título del distribuidor y agregarle un borde
            Cell customMXTitleCell = new Cell();
            customMXTitleCell.Add(customMXCellTitle);
            customMXTitleCell.SetBorder(new SolidBorder(1));
            customMXTitleCell.SetBackgroundColor(lightGreen); // Establecer el color de fondo a gris claro
            tableCustoms.AddCell(customMXTitleCell);

            // Crear un nuevo párrafo para el nombre del embarcador con un tamaño de fuente mayor
            Paragraph customUSTitleParagraph = new Paragraph("US CUSTOM")
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetFontSize(fontSizeTitle) // Cambiar el tamaño de la fuente a 14
                .SetFont(boldFont);

            // Crear una celda para el título del consignatario y agregarle un borde
            Cell customUSTitleCell = new Cell();
            customUSTitleCell.Add(customUSTitleParagraph);
            customUSTitleCell.SetBorder(new SolidBorder(1));
            customUSTitleCell.SetBackgroundColor(lightGreen); // Establecer el color de fondo a gris claro
            tableCustoms.AddCell(customUSTitleCell);

            // Crear un nuevo párrafo para el nombre del embarcador con un tamaño de fuente mayor
            Paragraph customMXNameParagraph = new Paragraph(queryManifest.customMXName ?? "")
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                .SetFontSize(fontSizeBody) // Cambiar el tamaño de la fuente a 14
                .SetFont(boldFont);

            // Crear nuevos párrafos para la dirección, la ciudad y el RFC del embarcador con un tamaño de fuente menor
            Paragraph customMXAddressParagraph = new Paragraph(queryManifest.customMXAddress ?? "")
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                .SetFontSize(fontSizeBody) // Cambiar el tamaño de la fuente a 10
                .SetFont(font);

            string MXCity = $"{queryManifest.customMXCity}, {queryManifest.customMXCountry}".Trim(',', ' ') ?? "";
            Paragraph customMXCityParagraph = new Paragraph(MXCity)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                .SetFontSize(fontSizeBody) // Cambiar el tamaño de la fuente a 10
                .SetFont(font);

            //Paragraph customMXCountryParagraph = new Paragraph(queryManifest.customMXCountry)
            //    .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
            //    .SetFontSize(fontSizeBody) // Cambiar el tamaño de la fuente a 10
            //    .SetFont(font);

            Paragraph customMXRFCParagraph = new Paragraph(queryManifest.customMXRFC ?? "")
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                .SetFontSize(fontSizeBody) // Cambiar el tamaño de la fuente a 10
                .SetFont(font);

            // Agregar los párrafos a la celda
            Cell customMXCell = new Cell();
            customMXCell.Add(customMXNameParagraph);
            customMXCell.Add(customMXAddressParagraph);
            customMXCell.Add(customMXCityParagraph);
            //customMXCell.Add(customMXCountryParagraph);
            customMXCell.Add(customMXRFCParagraph);
            customMXCell.SetPaddingLeft(5); // Agregar relleno a la izquierda para separar el texto del margen
            customMXCell.SetPaddingRight(0);
            customMXCell.SetWidth(UnitValue.CreatePercentValue(50)); // Establecer el ancho de la celda al 50% del ancho de la tabla
            customMXCell.SetHeight(heightCell); // Establecer la altura de la celda a 1.5 pulgadas (1 pulgada = 72 puntos)
            tableCustoms.AddCell(customMXCell);

            // Crear un nuevo párrafo para el nombre del embarcador con un tamaño de fuente mayor
            Paragraph customUSNameParagraph = new Paragraph(queryManifest.customUSName ?? "")
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                .SetFontSize(fontSizeBody) // Cambiar el tamaño de la fuente a 14
                .SetFont(boldFont);

            // Crear nuevos párrafos para la dirección, la ciudad y el RFC del embarcador con un tamaño de fuente menor
            Paragraph customUSAddressParagraph = new Paragraph(queryManifest.customUSAddress ?? "")
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                .SetFontSize(fontSizeBody) // Cambiar el tamaño de la fuente a 10
                .SetFont(font);

            string USCity = $"{queryManifest.customUSCity}, {queryManifest.customUSCountry}".Trim(',', ' ') ?? "";

            Paragraph customUSCityParagraph = new Paragraph(USCity)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                .SetFontSize(fontSizeBody) // Cambiar el tamaño de la fuente a 10
                .SetFont(font);

            //Paragraph customUSCountryParagraph = new Paragraph(queryManifest.customUSCountry)
            //    .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
            //    .SetFontSize(fontSizeBody) // Cambiar el tamaño de la fuente a 10
            //    .SetFont(font);

            Paragraph customUSRFCParagraph = new Paragraph(queryManifest.customUSRFC ?? "")
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                .SetFontSize(fontSizeBody) // Cambiar el tamaño de la fuente a 10
                .SetFont(font);

            // Agregar los párrafos a la celda
            Cell customUSCell = new Cell();
            customUSCell.Add(customUSNameParagraph);
            customUSCell.Add(customUSAddressParagraph);
            customUSCell.Add(customUSCityParagraph);
            //customUSCell.Add(customUSCountryParagraph);
            customUSCell.Add(customUSRFCParagraph);
            customUSCell.SetPaddingLeft(5); // Agregar relleno a la izquierda para separar el texto del margen
            customUSCell.SetPaddingRight(0);
            customUSCell.SetWidth(UnitValue.CreatePercentValue(50)); // Establecer el ancho de la celda al 50% del ancho de la tabla
            customUSCell.SetHeight(heightCell); // Establecer la altura de la celda a 1.5 pulgadas (1 pulgada = 72 puntos)
            tableCustoms.AddCell(customUSCell);

            // Agregar la tabla al documento
            document.Add(tableCustoms);
        }

        public void DesignPDFManifestTransport(iText.Layout.Document document, string manifestNumber)
        {
            // Crear una tabla con 2 columnas
            Table tableTransport = new Table(1);
            tableTransport.SetWidth(UnitValue.CreatePercentValue(100));

            // Crear un nuevo párrafo para el nombre del embarcador con un tamaño de fuente mayor
            Paragraph transportCellTitle = new Paragraph("DATOS DE TRANSPORTE")
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetFontSize(fontSizeTitle) // Cambiar el tamaño de la fuente a 14
                .SetFont(boldFont);

            // Crear una celda para el título del distribuidor y agregarle un borde
            Cell transportTitleCell = new Cell();
            transportTitleCell.Add(transportCellTitle);
            transportTitleCell.SetBorder(new SolidBorder(1));
            transportTitleCell.SetBackgroundColor(lightGreen); // Establecer el color de fondo a gris claro
            tableTransport.AddCell(transportTitleCell);

            // Crear una tabla con 3 columnas
            Table tableDetailedTransport = new Table(3);
            tableDetailedTransport.SetWidth(UnitValue.CreatePercentValue(100));
            tableDetailedTransport.SetBorder(Border.NO_BORDER);

            Cell carrierCell = new Cell(); //Añadir celda izquierda y sus carácteristicas
            carrierCell.SetPaddingLeft(5); // Agregar relleno a la izquierda para separar el texto del margen
            carrierCell.SetPaddingRight(0);
            carrierCell.SetPaddingBottom(0);
            carrierCell.SetBorder(Border.NO_BORDER);
            carrierCell.SetWidth(UnitValue.CreatePercentValue(40)); // Establecer el ancho de la celda al 50% del ancho de la tabla
            carrierCell.SetHeight(heigthCarrier); // Establecer la altura de la celda a 1.5 pulgadas (1 pulgada = 72 puntos)

            // Crear un nuevo párrafo para el nombre del embarcador con un tamaño de fuente mayor
            Paragraph carrierNameParagraph = new Paragraph("Linea: ")
                .Add(queryManifest.carrierName)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                .SetFontSize(fontSizeBody) // Cambiar el tamaño de la fuente a 14
                .SetFont(boldFont);
            carrierCell.Add(carrierNameParagraph);

            // Crear nuevos párrafos para la dirección, la ciudad y el RFC del embarcador con un tamaño de fuente menor
            Paragraph carrierSCACParagraph = new Paragraph("SCAC: ")
                .Add(queryManifest.carrierSCAC)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                .SetFontSize(fontSizeBody) // Cambiar el tamaño de la fuente a 10
                .SetFont(font); 
            carrierCell.Add(carrierSCACParagraph);

            Paragraph carrierSCAATParagraph = new Paragraph("SCAAT: ")
                .Add(queryManifest.carrierSCAAT)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                .SetFontSize(fontSizeBody) // Cambiar el tamaño de la fuente a 10
                .SetFont(font);
            carrierCell.Add(carrierSCAATParagraph);

            Paragraph carrierTransportParagraph = new Paragraph("Medio: ")
                .Add(queryManifest.manifestVehiculeType)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                .SetFontSize(fontSizeBody) // Cambiar el tamaño de la fuente a 10
                .SetFont(font);
            carrierCell.Add(carrierTransportParagraph);

            Paragraph carrierDriverParagraph = new Paragraph("Chofer: ")
                .Add(queryManifest.driverName)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                .SetFontSize(fontSizeBody) // Cambiar el tamaño de la fuente a 10
                .SetFont(boldFont);
            carrierCell.Add(carrierDriverParagraph);

            if (!string.IsNullOrEmpty(queryManifest.driverLicense))
            {
                Paragraph carrierDriverLicenseParagraph = new Paragraph("Licencia: ");
                carrierDriverLicenseParagraph
                .Add(queryManifest.driverLicense)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                .SetFontSize(fontSizeBody) // Cambiar el tamaño de la fuente a 10
                .SetFont(font);
                carrierCell.Add(carrierDriverLicenseParagraph);
            }

            if (!string.IsNullOrEmpty(queryManifest.driverVisa))
            {
                Paragraph carrierDriverVisaParagraph = new Paragraph("VISA: ");
                carrierDriverVisaParagraph
                    .Add(queryManifest.driverVisa)
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                    .SetFontSize(fontSizeBody) // Cambiar el tamaño de la fuente a 10
                    .SetFont(font);
                carrierCell.Add(carrierDriverVisaParagraph);
            }

            if (queryManifest.driverBirthday != null)
            {
                Paragraph carrierDriverBirthdayParagraph = new Paragraph("Fecha de nacimiento: ");
                carrierDriverBirthdayParagraph
                    .Add(queryManifest.driverBirthday?.ToString("yyyy-MMMM-dd"))
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                    .SetFontSize(fontSizeBody) // Cambiar el tamaño de la fuente a 10
                    .SetFont(font);
                carrierCell.Add(carrierDriverBirthdayParagraph);
            }

            tableDetailedTransport.AddCell(carrierCell);

            Paragraph truckNoEcoParagraph = new Paragraph("Troque: ")
                .Add(queryManifest.truckNoEco)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                .SetFontSize(fontSizeBody) // Cambiar el tamaño de la fuente a 14
                .SetFont(boldFont);

            Paragraph truckBrandParagraph = new Paragraph("Marca: ")
                .Add(queryManifest.truckBrand)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                .SetFontSize(fontSizeBody) // Cambiar el tamaño de la fuente a 14
                .SetFont(font);


            Paragraph truckUSPlateParagraph = new Paragraph("Placas US: ")
                .Add(queryManifest.truckPlateUS)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                .SetFontSize(fontSizeBody) // Cambiar el tamaño de la fuente a 10
                .SetFont(font);

            Paragraph truckMXPlateParagraph = new Paragraph("Placas MX: ")
                .Add(queryManifest.truckPlateMX)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                .SetFontSize(fontSizeBody) // Cambiar el tamaño de la fuente a 10
                .SetFont(font);

            // Agregar los párrafos a la celda
            Cell truckCell = new Cell();
            truckCell.Add(truckNoEcoParagraph);
            truckCell.Add(truckBrandParagraph);
            truckCell.Add(truckUSPlateParagraph);
            truckCell.Add(truckMXPlateParagraph);
            truckCell.SetPaddingLeft(5); // Agregar relleno a la izquierda para separar el texto del margen
            truckCell.SetPaddingRight(0);
            truckCell.SetPaddingBottom(0);
            truckCell.SetBorder(Border.NO_BORDER);
            truckCell.SetWidth(UnitValue.CreatePercentValue(30)); // Establecer el ancho de la celda al 50% del ancho de la tabla
            truckCell.SetHeight(heigthCarrier); // Establecer la altura de la celda a 1.5 pulgadas (1 pulgada = 72 puntos)
            tableDetailedTransport.AddCell(truckCell);


            Paragraph thermoNoEcoParagraph = new Paragraph("Caja: ")
                .Add(queryManifest.thermoNoEco)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                .SetFontSize(fontSizeBody) // Cambiar el tamaño de la fuente a 14
                .SetFont(boldFont);

            Paragraph thermoBrandParagraph = new Paragraph("Tipo: ")
                .Add(queryManifest.thermoType)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                .SetFontSize(fontSizeBody) // Cambiar el tamaño de la fuente a 14
                .SetFont(font);

            Paragraph thermoUSPlateParagraph = new Paragraph("Placas US: ")
                .Add(queryManifest.thermoPlateUS)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                .SetFontSize(fontSizeBody) // Cambiar el tamaño de la fuente a 10
                .SetFont(font);

            Paragraph thermoMXPlateParagraph = new Paragraph("Placas MX: ")
                .Add(queryManifest.thermoPlateMX)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                .SetFontSize(fontSizeBody) // Cambiar el tamaño de la fuente a 10
                .SetFont(font);

            Paragraph thermoLenghtParagraph = new Paragraph("Longitud: ")
                .Add(queryManifest.thermoLength)
                .Add(" pies")
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                .SetFontSize(fontSizeBody) // Cambiar el tamaño de la fuente a 10
                .SetFont(font);

            // Agregar los párrafos a la celda
            Cell fcoCell = new Cell();
            fcoCell.Add(thermoNoEcoParagraph);
            fcoCell.Add(thermoBrandParagraph);
            fcoCell.Add(thermoUSPlateParagraph);
            fcoCell.Add(thermoMXPlateParagraph);
            fcoCell.Add(thermoLenghtParagraph);
            fcoCell.SetPaddingLeft(5); // Agregar relleno a la izquierda para separar el texto del margen
            fcoCell.SetPaddingRight(0);
            fcoCell.SetPaddingBottom(0);
            fcoCell.SetBorder(Border.NO_BORDER);
            fcoCell.SetWidth(UnitValue.CreatePercentValue(30)); // Establecer el ancho de la celda al 50% del ancho de la tabla
            fcoCell.SetHeight(heigthCarrier); // Establecer la altura de la celda a 1.5 pulgadas (1 pulgada = 72 puntos)
            tableDetailedTransport.AddCell(fcoCell);

            Cell trasnsportDetailedCell = new Cell();
            trasnsportDetailedCell.Add(tableDetailedTransport);
            tableTransport.AddCell(trasnsportDetailedCell);

            // Agregar la tabla al documento
            document.Add(tableTransport);
        }

        public void DesignPDFManifestRemisionTable(iText.Layout.Document document, string manifestNumber)
        {
            Table tableRemisionDetailed = new Table(5).SetBorder(new SolidBorder(1)).SetWidth(UnitValue.CreatePercentValue(100));

            // Agregar los encabezados de la tabla
            AddCellToTable(tableRemisionDetailed, "Variedad", 36, iText.Layout.Properties.TextAlignment.CENTER, fontSizeSubtitle, boldFont, Border.NO_BORDER, lightGreen);
            AddCellToTable(tableRemisionDetailed, "Descripción", 36, iText.Layout.Properties.TextAlignment.CENTER, fontSizeSubtitle, boldFont, Border.NO_BORDER, lightGreen);
            AddCellToTable(tableRemisionDetailed, "Tamaño", 8, iText.Layout.Properties.TextAlignment.CENTER, fontSizeSubtitle, boldFont, Border.NO_BORDER, lightGreen);
            AddCellToTable(tableRemisionDetailed, "Bultos", 8, iText.Layout.Properties.TextAlignment.CENTER, fontSizeSubtitle, boldFont, Border.NO_BORDER, lightGreen);
            AddCellToTable(tableRemisionDetailed, "Kilos", 12, iText.Layout.Properties.TextAlignment.CENTER, fontSizeSubtitle, boldFont, Border.NO_BORDER, lightGreen);

            // Iterar sobre las filas de DetalleCarga
            foreach (DataRow detalle in queryManifest.DetalleCarga.Rows)
            {
                // Agregar cada columna de la fila a la tabla del PDF
                AddCellToTable(tableRemisionDetailed, detalle["Variedad"].ToString(), 36, iText.Layout.Properties.TextAlignment.CENTER, fontSizeBody, font);
                AddCellToTable(tableRemisionDetailed, detalle["Descripción"].ToString(), 36, iText.Layout.Properties.TextAlignment.CENTER, fontSizeBody, font);
                AddCellToTable(tableRemisionDetailed, detalle["Tamaño"].ToString(), 8, iText.Layout.Properties.TextAlignment.CENTER, fontSizeBody, font);
                AddCellToTable(tableRemisionDetailed, detalle["Bultos"].ToString(), 8, iText.Layout.Properties.TextAlignment.CENTER, fontSizeBody, font);
                AddCellToTable(tableRemisionDetailed, detalle["Kilos"].ToString(), 12, iText.Layout.Properties.TextAlignment.CENTER, fontSizeBody, font);
            }

            Table tableRemisionTotal = new Table(5).SetBorder(Border.NO_BORDER).SetWidth(UnitValue.CreatePercentValue(100));

            if (queryManifest.TotalesCarga.Rows.Count == 0)
                return;

            DataRow remisionTotalDT = queryManifest.TotalesCarga.Rows[0];

            AddCellToTable(tableRemisionTotal, "", 36, iText.Layout.Properties.TextAlignment.CENTER, fontSizeSubtitle, boldFont, Border.NO_BORDER);
            AddCellToTable(tableRemisionTotal, "", 33, iText.Layout.Properties.TextAlignment.CENTER, fontSizeSubtitle, boldFont, Border.NO_BORDER);
            AddCellToTable(tableRemisionTotal, "TOTALES:", 8, iText.Layout.Properties.TextAlignment.RIGHT, fontSizeSubtitle, boldFont, Border.NO_BORDER);
            AddCellToTable(tableRemisionTotal, remisionTotalDT["Bultos"].ToString(), 8, iText.Layout.Properties.TextAlignment.CENTER, fontSizeSubtitle, boldFont, Border.NO_BORDER);
            AddCellToTable(tableRemisionTotal, remisionTotalDT["Kilos"].ToString(), 12, iText.Layout.Properties.TextAlignment.CENTER, fontSizeSubtitle, boldFont, Border.NO_BORDER);

            // Agregar la tabla al documento
            document.Add(tableRemisionDetailed);
            document.Add(tableRemisionTotal);
        }

        private void DesignPDFManifestDetails(iText.Layout.Document document, string manifestNumber)
        {
            Table tableManifestDetailHeader = new Table(1);
            tableManifestDetailHeader.SetWidth(UnitValue.CreatePercentValue(100));

            Paragraph manifestDetailHeaderParagraph = new Paragraph("DETALLES DE MANIFIESTO")
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetFontSize(fontSizeTitle) // Cambiar el tamaño de la fuente a 14
                .SetFont(boldFont);

            Cell manifestDetailTitleCell = new Cell();
            manifestDetailTitleCell.Add(manifestDetailHeaderParagraph);
            manifestDetailTitleCell.SetBorder(new SolidBorder(1));
            manifestDetailTitleCell.SetBackgroundColor(lightGreen);

            tableManifestDetailHeader.AddCell(manifestDetailTitleCell);

            // Crear una tabla con 3 columnas
            Table tableDetailedManifest = new Table(3);
            tableDetailedManifest.SetWidth(UnitValue.CreatePercentValue(100));
            tableDetailedManifest.SetBorder(Border.NO_BORDER);

            // CALDA DE LA IZQUIERDA
            Cell leftCell = new Cell();
            leftCell.SetPaddingLeft(5);
            leftCell.SetPaddingRight(0);
            leftCell.SetPaddingBottom(0);
            leftCell.SetBorder(Border.NO_BORDER);
            leftCell.SetWidth(UnitValue.CreatePercentValue(33));
            
                Paragraph manifestDetailTemperatureParagraph = new Paragraph("TEMPERATURA: ")
                    .Add(queryManifest.thermoTemperature)
                    .Add(" F°")
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                    .SetFontSize(fontSizeBody)
                    .SetFont(font);

                Paragraph manifestDetailSeal1Paragraph = new Paragraph("SELLO 1: ")
                    .Add(queryManifest.manifestSeal1)
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                    .SetFontSize(fontSizeBody)
                .SetFont(font);

                leftCell.Add(manifestDetailTemperatureParagraph);
                leftCell.Add(manifestDetailSeal1Paragraph);
                tableDetailedManifest.AddCell(leftCell);

            // CELDA DE EN MEDIO
            Cell centerCell = new Cell();
            centerCell.SetPaddingLeft(5);
            centerCell.SetPaddingRight(0);
            centerCell.SetPaddingBottom(0);
            centerCell.SetBorder(Border.NO_BORDER);
            centerCell.SetWidth(UnitValue.CreatePercentValue(33));

                Paragraph manifestDetailThermometerParagraph = new Paragraph("TERMOGRAFO: ")
                    .Add(queryManifest.manifestThermometer)
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                    .SetFontSize(fontSizeBody)
                    .SetFont(font);

                Paragraph manifestDetailSeal2Paragraph = new Paragraph("SELLO 2: ")
                    .Add(queryManifest.manifestSeal2)
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                    .SetFontSize(fontSizeBody)
                    .SetFont(font);

                centerCell.Add(manifestDetailThermometerParagraph);
                centerCell.Add(manifestDetailSeal2Paragraph);
                tableDetailedManifest.AddCell(centerCell);

            //CELDA DE LA DERECHA
            Cell rightCell = new Cell();
            rightCell.SetPaddingLeft(5);
            rightCell.SetPaddingRight(0);
            rightCell.SetPaddingBottom(0);
            rightCell.SetBorder(Border.NO_BORDER);
            rightCell.SetWidth(UnitValue.CreatePercentValue(33));

                Paragraph manifestDetailPositionParagraph = new Paragraph("POSICION: ")
                    .Add(queryManifest.manifestThermometerPosition)
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                    .SetFontSize(fontSizeBody)
                    .SetFont(font);

                Paragraph manifestDetailSeal3Paragraph = new Paragraph("SELLO 3: ")
                    .Add(queryManifest.manifestSeal3)
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                    .SetFontSize(fontSizeBody)
                    .SetFont(font);

                rightCell.Add(manifestDetailPositionParagraph);
                rightCell.Add(manifestDetailSeal3Paragraph);
            tableDetailedManifest.AddCell(rightCell);

            //CELDA INFERIOR
            Cell ObsCell = new Cell();
            ObsCell.SetPaddingLeft(5);
            ObsCell.SetPaddingTop(0);
            ObsCell.SetPaddingRight(0);
            ObsCell.SetBorder(Border.NO_BORDER);
            ObsCell.SetWidth(UnitValue.CreatePercentValue(100));

                Paragraph manifestDetailComentsParagraph = new Paragraph("OBSERVACIONES: ")
                    .Add(queryManifest.manifestComments)
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                    .SetFontSize(fontSizeBody)
                    .SetFont(font);

                ObsCell.Add(manifestDetailComentsParagraph);

            // JUNTAR TODAS LAS CELDAS
            Cell manifestALLDetailCell = new Cell();
            manifestALLDetailCell.Add(tableDetailedManifest);
            manifestALLDetailCell.Add(ObsCell);

            tableManifestDetailHeader.AddCell(manifestALLDetailCell);

            document.Add(tableManifestDetailHeader);
        }

        private void AddCellToTable(Table table, string text, float widthPercent, iText.Layout.Properties.TextAlignment alignment, int? fontSize = null, PdfFont font = null, Border border = null, iText.Kernel.Colors.Color backgroundColor = null)
        {
            Cell cell = new Cell()
                .Add(new Paragraph(text))
                .SetBorder(border ?? Border.NO_BORDER)
                .SetWidth(UnitValue.CreatePercentValue(widthPercent))
                .SetTextAlignment(alignment);

            if (fontSize.HasValue)
            {
                cell.SetFontSize(fontSize.Value);
            }

            if (font != null)
            {
                cell.SetFont(font);
            }

            if (backgroundColor != null)
            {
                cell.SetBackgroundColor(backgroundColor);
            }

            table.AddCell(cell);
        }




        public void DesignPDFManifestFooter()
        {
            // Create PDF Total
        }


    }

}
