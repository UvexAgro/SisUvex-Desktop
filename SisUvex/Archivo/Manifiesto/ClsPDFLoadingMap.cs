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

namespace SisUvex.Archivo.Manifiesto
{
    internal class ClsPDFLoadingMap
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
        int fontSizeBody = 10; //10
        int fontPosition =8;
        int fontMixSize = 6;
        int heightCell = 50;
        int heigthCarrier = 120;
        float maxWidthLogo = 72;
        float cellHeight = 68;
        int thermoPos = 0;

        public void CreatePDFMaping(string manifestNumber)
        {
            queryManifest.GetManifestData(manifestNumber);
            queryManifest.GetManifestDetailData(manifestNumber);
            queryManifest.GetManifestTotalData(manifestNumber);
            queryLoadingMap.GetLoadingMapData(manifestNumber);

            // Crear un nuevo documento PDF
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string manifestDirectory = Path.Combine(desktopPath, "Manifiestos",queryManifest.distributorShortName, $"{manifestNumber}");
            if (!Directory.Exists(manifestDirectory))
            {
                Directory.CreateDirectory(manifestDirectory);
            }

            string manifestPath = Path.Combine(manifestDirectory, $"MAPING {manifestNumber}.pdf");
            PdfWriter writer = new PdfWriter(manifestPath);
            PdfDocument pdf = new PdfDocument(writer);
            iText.Layout.Document document = new iText.Layout.Document(pdf);

            //Metodos que componen el diseño del PDF
            DesignPDFMapingHeader(document, manifestNumber);
            LoadingMapTable(document, manifestNumber);
            DesignPDFManifestRemisionTable(document, manifestNumber);
            // Cerrar el documento
            document.Close();
        }

        public void DesignPDFMapingHeader(iText.Layout.Document document, string manifestNumber)
        {
            // Crear una tabla con 3 columnas
            Table table = new Table(3);
            table.SetWidth(UnitValue.CreatePercentValue(100));
            table.SetBorder(Border.NO_BORDER);

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
            table.AddCell(logoCell);

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
                .Add(" - RFC: " + queryManifest.shipperRFC)
                .Add(" - GGN: " + queryManifest.shipperGGN)
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
            table.AddCell(shipperCell);

            // Crear un nuevo párrafo para el número de manifiesto
            Paragraph manifestParagraph = new Paragraph("MAPEO: ")
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

            // Crear un separador de línea
            LineSeparator ls = new LineSeparator(new SolidLine());
            document.Add(ls);
        }

        public void LoadingMapTable(iText.Layout.Document document, string manifestNumber)
        {
            //Crear una tabla con 2 columnas
            Table bigTable = new Table(4);
            bigTable.SetWidth(UnitValue.CreatePercentValue(100));
            bigTable.SetBorder(Border.NO_BORDER);

            //
            // Crear una tabla con 2 columnas
            Table tableLeftExtreme = new Table(1);
            tableLeftExtreme.SetWidth(UnitValue.CreatePercentValue(100));
            tableLeftExtreme.SetBorder(Border.NO_BORDER);

            Table tableLeftInner = new Table(1);
            tableLeftInner.SetWidth(UnitValue.CreatePercentValue(100));
            tableLeftInner.SetBorder(Border.NO_BORDER);

            Table tableRIghtInner = new Table(1);
            tableRIghtInner.SetWidth(UnitValue.CreatePercentValue(100));
            tableRIghtInner.SetBorder(Border.NO_BORDER);

            Table tableRightExtreme = new Table(1);
            tableRightExtreme.SetWidth(UnitValue.CreatePercentValue(100));
            tableRightExtreme.SetBorder(Border.NO_BORDER);

            if (queryManifest.manifestThermometerPosition != null)
            {
                if (int.TryParse(queryManifest.manifestThermometerPosition, out int temp))
                {
                    thermoPos = temp;
                }
            }

            for (int i = 0; i < queryLoadingMap.dtLaodingMap.Rows.Count; i++)
            {
                DataRow row = queryLoadingMap.dtLaodingMap.Rows[i];
                int pos = Convert.ToInt32(row["Pos"]);
                string pallet = row["Pallet"].ToString();
                string description = row["Descripción"].ToString();
                string bultos = row["Bultos"].ToString();
                string contenedor = row["Cont"].ToString();
                string variety = row["Variedad"].ToString();
                string estiba = row["Estiba"].ToString();
                string tamanio = row["Tamaño"].ToString();
                string libras = row["Libras"].ToString();
                int mix = 0;
                Paragraph positionPalletParagraph = new Paragraph();
                Paragraph paragraph = new Paragraph();
                Paragraph nextParagraph = new Paragraph();
                Paragraph varietyParagraph = new Paragraph();

                positionPalletParagraph
                    .Add(new Text(pos.ToString() + " ").SetFont(boldFont).SetFontSize(fontSizeBody).SetFontColor(ColorConstants.RED))
                    .Add(pallet)
                    .SetFont(font)
                    .SetFontSize(fontPosition)
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT);

                paragraph
                    .Add(new Text(bultos).SetUnderline().SetFont(boldFont))
                    .Add(" " + contenedor + libras + " " + tamanio + " " + description)
                    .SetFont(font)
                    .SetFontSize(fontPosition)
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT);

                varietyParagraph
                    .Add(variety)
                    .SetFont(font)
                    .SetFontSize(fontPosition)
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT);

                Cell cell = new Cell().SetHeight(cellHeight);

                // Add the paragraphs to the cell.
                cell.Add(positionPalletParagraph);
                if (pos == thermoPos && thermoPos > 0)
                {
                    cell.Add(new Paragraph("THERMOMETER").SetFont(font).SetFontColor(ColorConstants.RED).SetFontSize(fontPosition).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));
                    cell.SetBackgroundColor(ColorConstants.YELLOW);
                }
                cell.Add(varietyParagraph);
                cell.Add(paragraph);

                // If the current row's Estiba value is the same as the next row's, add the next row's paragraph to the current cell.
                //if (i < queryLoadingMap.dtLaodingMap.Rows.Count - 1 && estiba == queryLoadingMap.dtLaodingMap.Rows[i + 1]["Estiba"].ToString()
                //   && pos == Convert.ToInt32(queryLoadingMap.dtLaodingMap.Rows[i + 1]["Pos"]))
                //{
                while (i < queryLoadingMap.dtLaodingMap.Rows.Count - 1 && pos == Convert.ToInt32(queryLoadingMap.dtLaodingMap.Rows[i + 1]["Pos"]))
                {
                    DataRow nextRow = queryLoadingMap.dtLaodingMap.Rows[i+1];
                    string nextPallet = nextRow["Pallet"].ToString();
                    string nextDescription = nextRow["Descripción"].ToString();
                    string nextBultos = nextRow["Bultos"].ToString();
                    string nextContenedor = nextRow["Cont"].ToString();
                    string nextVariety = nextRow["Variedad"].ToString();
                    string nextTamanio = row["Tamaño"].ToString();
                    string nextLibras = row["Libras"].ToString();

                    positionPalletParagraph
                        .Add(" - ")
                        .Add(nextPallet)
                        .SetFont(font)
                        .SetFontSize(fontPosition)
                        .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT);

                    nextParagraph
                        .Add(new Text(nextBultos).SetUnderline().SetFont(boldFont))
                        .Add(" " + nextContenedor + nextLibras + " " + nextTamanio + " " + nextDescription+"\n")
                        .SetFont(font)
                        .SetFontSize(fontPosition)
                        .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT);
                                     
                    mix++;
                    i++;
                }

                if (mix > 0)
                {
                    cell.Add(nextParagraph);
                }

                if (pos <= 16)
                {
                    if (pos % 2 == 0)
                    {
                        tableLeftInner.AddCell(cell);
                    }
                    else
                    {
                        tableLeftExtreme.AddCell(cell);
                    }
                }
                else
                {
                    if (pos % 2 == 0)
                    {
                        tableRightExtreme.AddCell(cell);
                    }
                    else
                    {
                        tableRIghtInner.AddCell(cell);
                    }
                }
            }

            bigTable.AddCell(new Cell().Add(tableLeftExtreme).SetBorder(Border.NO_BORDER));
            bigTable.AddCell(new Cell().Add(tableLeftInner).SetBorder(Border.NO_BORDER));
            bigTable.AddCell(new Cell().Add(tableRIghtInner).SetBorder(Border.NO_BORDER));
            bigTable.AddCell(new Cell().Add(tableRightExtreme).SetBorder(Border.NO_BORDER));

            document.Add(bigTable);
        }

        public void DesignPDFManifestRemisionTable(iText.Layout.Document document, string manifestNumber)
        {
            // Crear una tabla con 3 columnas que ocupa todo el ancho de la página
            Table tableRemisionDetailed = new Table(5).SetBorder(Border.NO_BORDER).SetWidth(UnitValue.CreatePercentValue(100));

            // Agregar los encabezados de la tabla
            AddCellToTable(tableRemisionDetailed, "Variedad", 25, iText.Layout.Properties.TextAlignment.CENTER, fontSizeBody, boldFont, Border.NO_BORDER, lightGreen);
            AddCellToTable(tableRemisionDetailed, "Descripción", 20, iText.Layout.Properties.TextAlignment.CENTER, fontSizeBody, boldFont, Border.NO_BORDER, lightGreen);
            AddCellToTable(tableRemisionDetailed, "Tamaño", 10, iText.Layout.Properties.TextAlignment.CENTER, fontSizeBody, boldFont, Border.NO_BORDER, lightGreen);
            AddCellToTable(tableRemisionDetailed, "Bultos", 10, iText.Layout.Properties.TextAlignment.CENTER, fontSizeBody, boldFont, Border.NO_BORDER, lightGreen);
            AddCellToTable(tableRemisionDetailed, "Kilos", 10, iText.Layout.Properties.TextAlignment.CENTER, fontSizeBody, boldFont, Border.NO_BORDER, lightGreen);
            
            // Iterar sobre las filas de DetalleCarga
            foreach (DataRow detalle in queryManifest.DetalleCarga.Rows)
            {
                // Agregar cada columna de la fila a la tabla del PDF
                AddCellToTable(tableRemisionDetailed, detalle["Variedad"].ToString(), 25,
                  iText.Layout.Properties.TextAlignment.CENTER, fontSizeBody, font); 
                AddCellToTable(tableRemisionDetailed, detalle["Descripción"].ToString(), 20, iText.Layout.Properties.TextAlignment.CENTER, fontSizeBody, font);
                AddCellToTable(tableRemisionDetailed, detalle["Tamaño"].ToString(), 10, iText.Layout.Properties.TextAlignment.CENTER, fontSizeBody, font);
                AddCellToTable(tableRemisionDetailed, detalle["Bultos"].ToString(), 10, iText.Layout.Properties.TextAlignment.CENTER, fontSizeBody, font);
                AddCellToTable(tableRemisionDetailed, detalle["Kilos"].ToString(), 10, iText.Layout.Properties.TextAlignment.CENTER, fontSizeBody, font);
            }

            Table tableRemisionTotal = new Table(5).SetBorderTop(new SolidBorder(1)).SetWidth(UnitValue.CreatePercentValue(100));

            if(queryManifest.TotalesCarga.Rows.Count == 0)
            {
                AddCellToTable(tableRemisionTotal, "", 25, iText.Layout.Properties.TextAlignment.CENTER, fontSizeBody, boldFont, Border.NO_BORDER);
                AddCellToTable(tableRemisionTotal, "", 20, iText.Layout.Properties.TextAlignment.CENTER, fontSizeBody, boldFont, Border.NO_BORDER);
                AddCellToTable(tableRemisionTotal, "TOTALES:", 10, iText.Layout.Properties.TextAlignment.RIGHT, fontSizeBody, boldFont, Border.NO_BORDER);
                AddCellToTable(tableRemisionTotal, "0", 10, iText.Layout.Properties.TextAlignment.CENTER, fontSizeBody, boldFont, Border.NO_BORDER);
                AddCellToTable(tableRemisionTotal, "0", 10, iText.Layout.Properties.TextAlignment.CENTER, fontSizeBody, boldFont, Border.NO_BORDER);
            }
            else
            {
                DataRow remisionTotalDT = queryManifest.TotalesCarga.Rows[0];

                AddCellToTable(tableRemisionTotal, "", 25, iText.Layout.Properties.TextAlignment.CENTER, fontSizeBody, boldFont, Border.NO_BORDER);
                AddCellToTable(tableRemisionTotal, "", 20, iText.Layout.Properties.TextAlignment.CENTER, fontSizeBody, boldFont, Border.NO_BORDER);
                AddCellToTable(tableRemisionTotal, "TOTALES:".ToString(), 10, iText.Layout.Properties.TextAlignment.RIGHT, fontSizeBody, boldFont, Border.NO_BORDER); 
                AddCellToTable(tableRemisionTotal, remisionTotalDT["Bultos"].ToString(), 10, iText.Layout.Properties.TextAlignment.CENTER, fontSizeBody, boldFont, Border.NO_BORDER);
                AddCellToTable(tableRemisionTotal, remisionTotalDT["Kilos"].ToString(), 10, iText.Layout.Properties.TextAlignment.CENTER, fontSizeBody, boldFont, Border.NO_BORDER);
            }

            // Agregar la tabla al documento
            document.Add(tableRemisionDetailed);
            document.Add(tableRemisionTotal);
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
    }
}