using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using DocumentFormat.OpenXml.Presentation;
using DocumentFormat.OpenXml.VariantTypes;
using iText.Commons.Utils;
using iText.Kernel.Pdf;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Office.Interop.Excel;
using Org.BouncyCastle.Bcpg;
using SisUvex.Archivo.Etiquetas.LabelInterface;
using SisUvex.Catalogos.Metods.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static SisUvex.Catalogos.Metods.ClsObject;

namespace SisUvex.Archivo.Etiquetas.PrintLabels
{
    internal class ClsGenerateStringZplPalletTag
    {
        ETagInfo eTag;
        private string idPal = string.Empty;
        private string qty = string.Empty;
        private string zplBegin = "^XA";
        private string zplEnd = "^XZ\n";
        private string fontsize = "30,20";
        private string datePal = string.Empty;
        private string presentationZPL = string.Empty;
        private string distribuidorZPL = string.Empty;
        private string farmName = string.Empty; // Added for grow farm name
        private bool reverseLabelOrientation = false;


        private string labelsZPLString = string.Empty;
        public string GenerateSuperStringTag(string idPallet, ETagInfo eTagInfo, int copies, int boxes, bool reverseOrientation)
        {
            eTag = eTagInfo;
            idPal = idPallet;
            qty = boxes.ToString();
            datePal = eTag.dateWorkPlan?.ToString("MMM-dd");
            reverseLabelOrientation = reverseOrientation;

            if (!string.IsNullOrEmpty(eTag.preLabel)) presentationZPL += " " + eTag.preLabel + " ";
            presentationZPL += eTag.namePresentation;
            if (!string.IsNullOrEmpty(eTag.postLabel)) presentationZPL += " " + eTag.postLabel;

            //**Que no jale el nombre corto (si no hay) hasta que se cambie el procedimiento almacenado en hermosillo
            distribuidorZPL = eTag.shortNameDistributor;
            if (distribuidorZPL.IsNullOrEmpty()) distribuidorZPL = eTag.nameDistributor;
            //todo esto
            farmName = eTag.growFarmName;


            return SuperPrintPalletTag(copies);
        }
        
        public string SuperPrintPalletTag(int copies)
        {
            labelsZPLString = PrintPalletString();
            string superSring = string.Empty;

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

            if(farmName.IsNullOrEmpty())
            {
                farmName = " ";
            }
            int farmIndentationValue = baseIndent - (farmName.Length - 1) * step;



            string farmIndentation = farmIndentationValue.ToString();

            string PalletString = "^XA^PW812"
                                //+ "^POI" //Orientacion de impresion
                                + "^FX BARCODE AND PALLET NUMBER\n"
                                + "^BY5,2,90\n"
                                + $"^FO181,20^BC^FD{idPal}^FS\n"

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
                                + BoxPalletZPL(1)
                                + BoxPalletZPL(2)
                                + BoxPalletZPL(3)
                                + BoxPalletZPL(4)
                                + ReverseLabelOrientation(reverseLabelOrientation)
                                + "^XZ";

            return PalletString;
        }

        private string BoxPalletZPL(int boxNumber)
        {
            int X = 117, Y = 768;

            switch (boxNumber) { case 1: X = 117; Y = 768; break; case 2: X = 425; Y = 768; break; case 3: X = 117; Y = 950; break; case 4: X = 425; Y = 950; break; }

            string presentationShort = presentationZPL.Length > 22 ? presentationZPL.Substring(0, 22) : presentationZPL;
            string varietyShort = eTag.nameVariety.Length > 22 ? eTag.nameVariety.Substring(0, 22) : eTag.nameVariety;
            string distributorShort = distribuidorZPL.Length > 13 ? distribuidorZPL.Substring(0, 13) : distribuidorZPL;

            string textZPL = "^FX TEXTO EN CUADRICULA\n"
                            + $"^FX {boxNumber}rst Box\n"
                            + "^BY3,3,10\n"
                            + $"^FO{28  + X},{17  + Y}^BCN,35,Y,N,N,A^FD{idPal}^FS\n"
                            + "^CF0,25\n"
                            + $"^FO{13  + X},{84  + Y}^FD{varietyShort}^FS\n"
                            + $"^FO{13  + X},{109 + Y}^FD{presentationShort}^FS\n"
                            + "^CF0,15"
                            + $"^FO{13  + X},{134 + Y}^FD{eTag.nameContainer}{eTag.Lbs} {eTag.nameSize}^FS\n"
                            + $"^FO{163 + X},{134 + Y}^FD{distributorShort}^FS\n"
                            + $"^FO{13  + X},{149 + Y}^FD{datePal}^FS\n"
                            + $"^FO{163 + X},{149 + Y}^FDQTY: {qty}^FS\n"
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
