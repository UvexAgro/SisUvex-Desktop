using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using SisUvex.Archivo.Etiquetas.LabelInterface;
using SisUvex.Catalogos.Metods.Querys;
using System.Data;
using static SisUvex.Catalogos.Metods.ClsObject;

namespace SisUvex.Archivo.Etiquetas.PrintLabels
{
    internal class ClsGenerateStringZplPalletTag
    {
        ETagInfo eTag;
        private string idPal = string.Empty;
        private string qty = string.Empty;
        private string qtyOriginal = string.Empty;
        private string zplBegin = "^XA\n^CI28 ^FX soporte de caracteres especiales\n";
        private string zplEnd = "^XZ\n";
        private string fontsize = "30,20";
        private string datePal = string.Empty;
        private string presentationZPL = string.Empty;
        private string distribuidorZPL = string.Empty;
        private string farmName = string.Empty; // Added for grow farm name
        private bool reverseLabelOrientation = false;
        private bool isReprint = false;
        private bool stowage = false;

        private string labelsZPLString = string.Empty;
        public string GenerateSuperStringTag(string idPallet, ETagInfo eTagInfo, int copies, int boxes, bool reverseOrientation, bool isReprint)
        {
            PreparePalletTagFields(idPallet, eTagInfo, boxes, reverseOrientation, isReprint);
            return SuperPrintPalletTag(copies);
        }

        /// <summary>
        /// Genera una tira 4x1 con hasta dos códigos 2x1 (izquierda y derecha).
        /// </summary>
        public string GenerateSmallCodeStrip(
            string idPallet1, ETagInfo eTagInfo1, int boxes1,
            string? idPallet2, ETagInfo? eTagInfo2, int boxes2,
            bool reverseOrientation,
            bool isReprint)
        {
            const int stripY = 10;
            int[] stripX = { 10, 416 };

            string zpl = "^XA\n^CI28 ^FX soporte de caracteres especiales\n"
                       + "^PW812\n";

            PreparePalletTagFields(idPallet1, eTagInfo1, boxes1, reverseOrientation, isReprint);
            zpl += BoxPalletZPLAt(stripX[0], stripY, qtyOriginal);

            if (!string.IsNullOrWhiteSpace(idPallet2) && eTagInfo2 != null)
            {
                PreparePalletTagFields(idPallet2, eTagInfo2, boxes2, reverseOrientation, isReprint);
                zpl += BoxPalletZPLAt(stripX[1], stripY, qtyOriginal);
            }

            zpl += ReverseLabelOrientation(reverseLabelOrientation);
            zpl += "^XZ\n";
            Clipboard.SetText(zpl);
            return zpl;
        }

        private void PreparePalletTagFields(string idPallet, ETagInfo eTagInfo, int boxes, bool reverseOrientation, bool isReprint)
        {
            eTag = eTagInfo;
            idPal = idPallet;
            qty = boxes.ToString();
            presentationZPL = string.Empty;

            if (eTag.showDate == true || eTag.showDate == null)
                datePal = eTag.dateWorkPlan?.ToString("MMM-dd");
            else
                datePal = string.Empty;

            reverseLabelOrientation = reverseOrientation;
            this.isReprint = isReprint;

            if (!string.IsNullOrEmpty(eTag.preLabel)) presentationZPL += " " + eTag.preLabel + " ";
            presentationZPL += eTag.namePresentation;
            if (!string.IsNullOrEmpty(eTag.postLabel)) presentationZPL += " " + eTag.postLabel;
            presentationZPL += " " + eTag.shortNameTypeBox;

            distribuidorZPL = eTag.shortNameDistributor;
            if (string.IsNullOrEmpty(distribuidorZPL)) distribuidorZPL = eTag.nameDistributor;

            farmName = eTag.growFarmName;

            PalletInfoExtraWithQuery(idPallet); //cajas estiba
        }
        private string PalletInfoExtraWithQuery(string idPallet)
        {
            string zplExtra = string.Empty;
            string q = @"SELECT pal.*, wgp.v_nameWorkGroup, leg.v_labelLegend FROM Pack_Pallet pal LEFT JOIN Pack_WorkPlan wpl ON wpl.id_workPlan = pal.id_workPlan LEFT JOIN Pack_WorkGroup wgp ON wgp.id_workGroup = wpl.id_workGroup LEFT JOIN Pack_LabelLegend leg ON leg.id_labelLegend = wpl.id_labelLegend WHERE id_pallet = @idPallet OR ( c_stowage IS NOT NULL AND c_stowage = ( SELECT c_stowage  FROM Pack_Pallet  WHERE id_pallet = @idPallet ) )";
            string idStow = string.Empty;
            string boxesOriginal = string.Empty;
            string invoice = string.Empty;
            string idWorkGroup = string.Empty;
            string labelLegend = string.Empty;
            Dictionary<string, object> p = new();
            p.Add("@idPallet", idPallet);
            List<(string, string, string)>? stowageList = new();

            DataTable dt = ClsQuerysDB.ExecuteParameterizedQuery(q, p);

            if (dt != null && dt.Rows.Count > 0)
            {
                int count = 0;
                foreach (DataRow row in dt.Rows)
                {
                    count++;
                    string palletId = row["id_pallet"].ToString() ?? string.Empty;
                    string palletBoxes = row["i_boxes"].ToString() ?? string.Empty;
                    string invoiceStow = row["v_invoice"].ToString() ?? string.Empty;
                    stowageList.Add((palletId, palletBoxes, invoiceStow));

                    if (palletId == idPallet)
                    {
                        invoice = invoiceStow; // Asigna la papeleta del pallet principal
                        idWorkGroup = row["v_nameWorkGroup"].ToString() ?? string.Empty;
                        labelLegend = row["v_labelLegend"].ToString() ?? string.Empty;
                        boxesOriginal = row["i_boxes"].ToString() ?? string.Empty; // Asigna la cantidad original de cajas del pallet principal
                    }
                }

                if (count > 1)
                {
                    idStow = dt.Rows[0]["c_stowage"].ToString() ?? string.Empty;
                    qtyOriginal = boxesOriginal; // Asigna la cantidad original de cajas del pallet principal
                }

            }
            else
                return string.Empty;

            //AGREGAR ESTIBA EN ZPL:
            string zplStowage = StringStowageList(idStow, stowageList);
            string zplInvoiceWorkGroup = ZPLInvoiceWorkGroup(invoice, idWorkGroup);
            string zplLabelLegend = ZPLLabelLegend(labelLegend);

            zplExtra = zplStowage + zplInvoiceWorkGroup + zplLabelLegend;
            return zplExtra; 
        }
        private string ZPLLabelLegend(string labelLegend)
        {
            string zplInvoice = string.Empty;
            if (!string.IsNullOrEmpty(labelLegend))
                zplInvoice += $"^CF0,40 ^FO30,1160 ^FD{labelLegend}^FS ^FXLabel Legend\n";

            return zplInvoice;
        }
        private string ZPLInvoiceWorkGroup(string invoice, string idWorkGroup)
        {
            string zplInvoice = string.Empty;
            if (!string.IsNullOrEmpty(invoice))
                zplInvoice += $"^CF0,30 ^FO30,240 ^FD{invoice}/{idWorkGroup}^FS ^FXINVOICE/WORKGROUP\n";

            return zplInvoice;
        }
        private string StringStowageList(string idStow, List<(string, string, string)>? stowageList)
        {
            string zplStowage = string.Empty;

            if (stowageList.Count > 1)
            {
                int totalBoxesStowage = 0;
                int yBegin = 20;
                zplStowage += $"^FX STOW AND PALLETS\n"
                           + $"^CF0,40^FO635,{yBegin}^FD*{idStow}*^FS\n";

                foreach ((string palletId, string palletBoxes, string invoice) in stowageList)
                {
                    totalBoxesStowage += int.TryParse(palletBoxes, out int boxes) ? boxes : 0;
                    yBegin += 40; // Incrementa la posición Y para cada pallet
                    zplStowage += $"^CF0,30 ^FO635,{yBegin} ^FD{palletId}({palletBoxes})^FS\n";

                    if (idPal == palletId)
                    {
                        zplStowage += $"^CF0,20^FO685,720^FD({palletBoxes})^FS\n"; // Muestra la cantidad de cajas del pallet principal en la etiqueta
                        qtyOriginal = palletBoxes; // Asigna la cantidad original de cajas del pallet principal
                    }
                }

                qty = totalBoxesStowage.ToString(); // Actualiza la cantidad total de cajas en la etiqueta

                return zplStowage;
            }

            return string.Empty;
        }

        public string SuperPrintPalletTag(int copies)
        {
            labelsZPLString = PrintPalletString();
            string superSring = string.Empty;
            Clipboard.SetText(labelsZPLString);
            for (int i = 0; i < copies; i++)
            {
                superSring += "\n" + labelsZPLString;
            }

            return superSring;
        }
        public string PrintPalletString()
        {
            string lenghtPresentation = "60";
            if (presentationZPL.Length > 25)
                lenghtPresentation = "50";
            if (presentationZPL.Length < 21)
                lenghtPresentation = "70";
            if (presentationZPL.Length < 17)
                lenghtPresentation = "90";
            if (presentationZPL.Length < 12)
                lenghtPresentation = "120";

            // Convierte farmIndentation a int para poder operar
            int baseIndent = 400;
            int step = 20;

            if(string.IsNullOrEmpty(farmName))
            {
                farmName = " ";
            }
            int farmIndentationValue = baseIndent - (farmName.Length - 1) * step;

            string reprint = string.Empty;
            if (isReprint)
                reprint = $"^CF0,80^FO472,115^FD*^FS\n";

            string farmIndentation = farmIndentationValue.ToString();

            string zplPalletInfoExtra = PalletInfoExtraWithQuery(idPal);

            string PalletString = "^XA^PW812\n"
                                + "^XA\n^CI28 ^FX soporte de caracteres especiales\n"
                                //+ "^POI" //Orientacion de impresion
                                + "^FX BARCODE AND PALLET NUMBER\n"
                                + "^BY5,2,90\n"
                                + $"^FO181,20^BC^FD{idPal}^FS\n"
                                + reprint
                                + zplPalletInfoExtra
                                + "^FX BIG INFO SECTION.\n"
                                + "^CF0,80\n"
                                + $"^FO{farmIndentation},170^FD{farmName}^FS\n"
                                + "^CF0,150\n"
                                + $"^FO20,270^FD{distribuidorZPL}^FS\n"
                                + "^CF0,130,50\n"
                                + $"^FO25,420^FD{eTag.nameVariety}^FS\n"
                                + $"^CF0,130,{lenghtPresentation}\n"
                                + $"^FO25,540^FD{presentationZPL}^FS\n"
                                + "^FO100,570^FD^FS\n"
                                + "^CF0,50\n"
                                + $"^FO50,650^FD{eTag.nameContainer}{eTag.Lbs} {eTag.nameSize}^FS\n"
                                + $"^FO500,650^FD{datePal}^FS\n"
                                + $"^FO50,700^FD{eTag.nameLot}^FS\n"
                                + $"^FO500,700^FDQTY: {qty}^FS\n"

                                + "^FO50,750^GB700,3,3^FS\n"

                                + "^FX CUADRICULA DE STICKERS.\n"
                                + "^FO117,768^GB611,183,3^FS\n"
                                + "^FO117,768^GB611,359,3^FS\n"
                                + "^FO420,768^GB3,359,3^FS\n"

                                + "^FX TEXTO EN CUADRICULA\n"
                                + BoxPalletZPLAt(117, 768, qtyOriginal)
                                + BoxPalletZPLAt(425, 768, qtyOriginal)
                                + BoxPalletZPLAt(117, 950, qtyOriginal)
                                + BoxPalletZPLAt(425, 950, qtyOriginal)
                                + ReverseLabelOrientation(reverseLabelOrientation)
                                + "^XZ";

            return PalletString;
        }

        private string BoxPalletZPLAt(int offsetX, int offsetY, string qtyOriginal)
        {
            int X = offsetX;
            int Y = offsetY;

            string presentationShort = presentationZPL.Length > 22 ? presentationZPL.Substring(0, 22) : presentationZPL;
            string varietyShort = eTag.nameVariety.Length > 22 ? eTag.nameVariety.Substring(0, 22) : eTag.nameVariety;
            string distributorShort = distribuidorZPL.Length > 13 ? distribuidorZPL.Substring(0, 13) : distribuidorZPL;
            if (!string.IsNullOrEmpty(qtyOriginal)) qtyOriginal = "(" + qtyOriginal + ")";
            string reprint = string.Empty;
            if (isReprint)
                reprint = $"^CF0,30^FO{188 + X},{57 + Y}^FD*^FS \n";

            string textZPL = "^FX TEXTO EN CUADRICULA\n"
                            + "^BY3,3,10\n"
                            + $"^FO{28  + X},{17  + Y}^BCN,35,Y,N,N,A^FD{idPal}^FS\n"
                            + reprint
                            + "^CF0,25\n"
                            + $"^FO{13  + X},{84  + Y}^FD{varietyShort}^FS\n"
                            + $"^FO{13  + X},{109 + Y}^FD{presentationShort}^FS\n"
                            + "^CF0,15"
                            + $"^FO{13  + X},{134 + Y}^FD{eTag.nameContainer}{eTag.Lbs} {eTag.nameSize}^FS\n"
                            + $"^FO{163 + X},{134 + Y}^FD{distributorShort}^FS\n"
                            + $"^FO{13  + X},{149 + Y}^FD{datePal}^FS\n"
                            + $"^FO{133 + X},{149 + Y}^FDQTY: {qty} {qtyOriginal}^FS\n"
                            + $"^FO{233 + X},{149 + Y}^FD{eTag.nameLot}^FS\n";

            return textZPL;
        }

        public string PrintPalletStringFirstFormat()
        {
            string PalletString = "^XA ^PW812\n" +
                "^FX BARCODE AND PALLET NUMBER\n" +
                "^BY5,2,90\n" +
                "^FO181,40^BC^FD" + idPal + "^FS\n" +

                "^FX BIG INFO SECTION.\n" +
                "^CFE,60\n" +
                "^FO50,250^FD" + eTag.nameVariety + "^FS\n" +
                "^CFE,60\n" +
                "^FO50,350^FD" + eTag.nameDistributor + "^FS\n" +
                "^CFE,50\n" +
                "^FO50,450^FD" + eTag.nameContainer + eTag.Lbs + presentationZPL + "^FS\n" +
                "^FO50,530^FD" + datePal + "^FS\n" +
                "^FO50,610^FD" + eTag.nameLot + "^FS\n" +
                "^FO500,610^FDQTY: " + qty + "^FS\n" +
                "^FO50,690^GB700,3,3^FS\n" +

                "^FX CUADRICULA DE STICKERS.\n" +
                "^FO117,768^GB611,183,3^FS\n" +
                "^FO117,768^GB611,359,3^FS\n" +
                "^FO420,768^GB3,359,3^FS\n" +

                "^FX TEXTO EN CUADRICULA\n" +

                "^FX 1rst Box\n" +
                "^BY3,3,10\n" +
                "^FO130,785^BCN,35,Y,N,N,A^FD" + idPal + "^FS\n" +
                "^CF0,25\n" +
                "^FO130,852^FD" + eTag.nameVariety + "^FS\n" +
                "^FO130,877^FD" + presentationZPL + "^FS\n" +
                "^CF0,15\n" +
                "^FO130,902^FD" + eTag.nameContainer + eTag.Lbs + " " + eTag.nameDistributor + "^FS\n" +
                "^FO130,917^FD" + datePal + "^FS\n" +
                "^FO280,917^FDQTY: " + qty + "^FS\n" +
                "^FO350,917^FD" + eTag.nameLot + "^FS\n" +

                "^FX 2nd Box\n" +
                "^BY3,3,10\n" +
                "^FO435,785^BC,35,Y,N,N,A^FD" + idPal + "^FS\n" +
                "^CF0,25\n" +
                "^FO435,852^FD" + eTag.nameVariety + "^FS\n" +
                "^FO435,877^FD" + presentationZPL + "^FS\n" +
                "^CF0,15\n" +
                "^FO435,902^FD" + eTag.nameContainer + eTag.Lbs + " " + eTag.nameDistributor + "^FS\n" +
                "^FO435,917^FD" + datePal + "^FS\n" +
                "^FO585,917^FDQTY: " + qty + "^FS\n" +
                "^FO655,917^FD" + eTag.nameLot + "^FS\n" +


                "^FX 3rd Box\n" +
                "^BY3,3,10\n" +
                "^FO130,960^BC,35,Y,N,N,A^FD" + idPal + "^FS\n" +
                "^CF0,25\n" +
                "^FO130,1027^FD" + eTag.nameVariety + "^FS\n" +
                "^FO130,1052^FD" + presentationZPL + "^FS\n" +
                "^CF0,15\n" +
                "^FO130,1077^FD" + eTag.nameContainer + eTag.Lbs + " " + eTag.nameDistributor + "^FS\n" +
                "^FO130,1092^FD" + datePal + "^FS\n" +
                "^FO280,1092^FDQTY: " + qty + "^FS\n" +
                "^FO350,1092^FD" + eTag.nameLot + "^FS\n" +

                "^FX 4rd Box\n" +
                "^BY3,3,10\n" +
                "^FO435,960^BC,35,Y,N,N,A^FD" + idPal + "^FS\n" +
                "^CF0,25\n" +
                "^FO435,1027^FD" + eTag.nameVariety + "^FS\n" +
                "^FO435,1052^FD" + presentationZPL + "^FS\n" +
                "^CF0,15\n" +
                "^FO435,1077^FD" + eTag.nameContainer + eTag.Lbs + " " + eTag.nameDistributor + "^FS\n" +
                "^FO435,1092^FD" + datePal + "^FS\n" +
                "^FO580,1092^FDQTY: " + qty + "^FS\n" +
                "^FO655,1092^FD" + eTag.nameLot + "^FS\n" +
            "^XZ";

            return PalletString;
        }
 
        private string ReverseLabelOrientation(bool reverse)
        {
            string orientation = string.Empty;

            if (reverse)
                orientation = "\n^POI\n";

            return orientation;
        }
    }
}
