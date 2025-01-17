using Azure;
using DocumentFormat.OpenXml.Drawing.Charts;
using Microsoft.IdentityModel.Tokens;
using SisUvex.Catalogos.Metods.Values;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing.QrCode.Internal;
using static SisUvex.Catalogos.Metods.ClsObject;

namespace SisUvex.Archivo.Etiquetas.PrintLabels
{
    internal class ClsGenerateSuperStringTagPti
    {
        ETagInfo eTag;

        private string zplBegin = "^XA";
        private string zplEnd = "^XZ\n";
        private string fontsize = "30,20";

        private string labelsZPLString = string.Empty;

        private string gtinZPL = string.Empty;
        private string distributorZPL = string.Empty;
        private string varietyZPL = string.Empty;
        private string presentationZPL = string.Empty;
        private string qrcodeZPL = string.Empty;
        private string upcZPL = string.Empty;
        private string voicePickCodeZPL = string.Empty;
        private string reverseLabelOrientationZPL = string.Empty;

        public string GenerateSuperStringTag(ETagInfo eTagInfo, int copies, bool reverseOrientation)
        {
            eTag = eTagInfo;
            switch (eTag.idPti)
            {
                case
                    "01":
                    //ESTANDAR
                    SetStringCropVarietySizeZPL(eTag.nameCrop, eTag.nameVariety, eTag.nameSize); //VARIEDAD  STANDAR
                    SetStringPresentationZPL(eTag.Lbs, eTag.namePresentation, eTag.nameContainer, eTag.preLabel, eTag.postLabel); //PRESENTACION STANDAR
                    SetStringDistributorZPL(eTag.nameDistributor, eTag.addressDistributor, eTag.cityDistributor); //DISTRIBUIDOR STANDAR
                    break;
                case
                    "02":
                    //ALBERTONS
                    SetStringDistributorZPL("Better Living Brands LLC", "P.O. Box 99", "Pleasanton CA 94566");
                    SetStringAlbertonsSignatureSelect(eTag.nameGenericColor); //VARIEDAD GENERICA
                    SetStringPresentationZPL("8/2", string.Empty, string.Empty, string.Empty, string.Empty); //PRESENTACION STANDAR
                    break;
                case
                    "03":
                    //DISTRIBUIDOR UVEX
                    SetStringDistributorZPL("Uvex Agro Internacional", "Rafael Muñoz Espinoza", "469 Caborca 83640 MX"); //DISTRIBUIDOR UVEX
                    SetStringCropVarietySizeZPL(eTag.nameCrop, eTag.nameVariety, eTag.nameSize); //VARIEDAD  STANDAR
                    SetStringPresentationZPL(eTag.Lbs, eTag.namePresentation, eTag.nameContainer, eTag.preLabel, eTag.postLabel); //PRESENTACION STANDAR
                    break;
                case
                    "04":
                    //AUSTRALIA
                    SetStringCropVarietySizeZPL(eTag.nameCrop, eTag.nameVariety, eTag.nameSize); //VARIEDAD  STANDAR
                    string kg = (double.Parse(eTag.Lbs) * 0.453592).ToString("0.0");
                    SetStringPresentationZPL(" "+kg + " Kg", eTag.namePresentation, eTag.nameContainer, eTag.preLabel, eTag.postLabel); //PRESENTACION KILOS
                    SetStringDistributorZPL(eTag.nameDistributor, eTag.addressDistributor, eTag.cityDistributor); //DISTRIBUIDOR STANDAR
                    break;
                case
                    "05":
                    //FOUR STARS
                    SetStringCropVarietyZPL(eTag.nameCrop, eTag.nameVariety); //VARIEDAD  STANDAR
                    SetStringPresentationZPL(eTag.Lbs+" LB Bags", string.Empty, string.Empty, string.Empty, string.Empty);//PRESENTACION FOUR STARS
                    SetStringDistributorZPL(eTag.nameDistributor, eTag.addressDistributor, eTag.cityDistributor); //DISTRIBUIDOR STANDAR
                    break;
                case
                    "06":
                    //QR ESPARRAGO
                    SetStringCropVarietySizeZPL(eTag.nameCrop, eTag.nameVariety, eTag.nameSize); //VARIEDAD  STANDAR
                    SetStringPresentationZPL(eTag.Lbs, eTag.namePresentation, eTag.nameContainer, eTag.preLabel, eTag.postLabel); //PRESENTACION STANDAR
                    SetStringQrSpaceDistributorZPL(eTag.nameDistributor, eTag.addressDistributor, eTag.cityDistributor); //DISTRIBUIDOR CON ESPACIO QR

                    break;
                default:
                    SetStringCropVarietySizeZPL(eTag.nameCrop, eTag.nameVariety, eTag.nameSize); //VARIEDAD  STANDAR
                    SetStringDistributorZPL(eTag.nameDistributor, eTag.addressDistributor, eTag.cityDistributor); ; //DISTRIBUIDOR STANDAR
                    SetStringPresentationZPL(eTag.Lbs, string.Empty, string.Empty, string.Empty, string.Empty); //PRESENTACION STANDAR; //PRESENTACION STANDAR
                    break;
            }
            SetStringGtinZPL(eTag.valueGTIN, eTag.dateWorkPlan, eTag.idLot, eTag.idWorkGroup);
            SetStringUpcZPL(eTag.upcGTIN);
            SetStringVoicePicKCodeZPL(eTag.voicePickCode, eTag.dateWorkPlan);

            reverseLabelOrientationZPL = ReverseLabelOrientation(reverseOrientation);

            if (eTag.idPti == "06") //QR ESPARRAGO
                return SuperPrintPtiTagWithQrUniqueBox(copies);
            else
                return SuperPrintPtiTag(copies);
        }

        /*Sobrecarga del metodo para generar el string ZPL para la etiqueta PTI*/
        private string SuperPrintPtiTag(int copies)
        {
            labelsZPLString = zplBegin + gtinZPL + distributorZPL + varietyZPL + presentationZPL + qrcodeZPL + upcZPL + voicePickCodeZPL + reverseLabelOrientationZPL + zplEnd;
            string superString = string.Empty;
            for (int i = 0; i < copies; i++)
            {
                superString += "\n" + labelsZPLString;
            }

            return superString;
        }

        private string SuperPrintPtiTagWithQrUniqueBox(int copies)
        {
            labelsZPLString = zplBegin + gtinZPL + distributorZPL + varietyZPL + presentationZPL + upcZPL + voicePickCodeZPL + reverseLabelOrientationZPL;

            string superString = string.Empty;

            for (int i = 0; i < copies; i++)
            {
                string idUniqueBox = ClsUniqueBox.CreateNewBox(eTag.idWorkPlan);

                qrcodeZPL = SetStringQrcodeEsparragoZPL(idUniqueBox, eTag.nameSize, eTag.idGTIN);

                superString += "\n" + labelsZPLString + qrcodeZPL + zplEnd;

                qrcodeZPL = string.Empty;
            }
            return superString;
        }
        private string SetStringQrcodeEsparragoZPL(string Qrcode, string sizeValue, string idGtin)
        {
            if (Qrcode.Length > 0)
                qrcodeZPL = "\n^FX QR CODE\n" +
                        "^FO24,280^BY2^BQN,2,4,Q,7^FDQA0" + Qrcode + " " + idGtin + " " + sizeValue + "^FS\n" +
                        "^CFC,15\n" +
                        "^FO32,392^FD" + Qrcode.Substring(2, 7) + "^FS\n";
            else
                qrcodeZPL = string.Empty;

            return qrcodeZPL;
        }

        private void SetStringGtinZPL(string Gtin, DateTime? Date, string Lote, string Workgroup)
        {
            string DateShortUS = Date?.ToString("yyMMdd") ?? DateTime.Now.ToString("yyMMdd");

            gtinZPL = "^FX GTIN\n" +
                        "^FX GTIN BARCODE\n" +
                        "^FO0,15\n" +
                        "^BRN,11,3,1,25,10^FD01" + Gtin + "13" + DateShortUS + "10" + Lote + "C" + Workgroup + "^FS\n" +
                        "^CFF,30,10\n" +
                        "^FX GTIN HUMAN READABLE\n" +
                        "^FO100,95^FD(01)" + Gtin + "(13)" + DateShortUS + "(10)" + Lote + "C" + Workgroup + "^FS\n";
        }

        private void SetStringCropVarietySizeZPL(string Crop, string Variety, string Size)
        {
            //ChangeFontSize(Variety);

            varietyZPL = "^FX CROP, SIZE AND VARIETY\n" +
                        $"^CFF,60,10 ^FO25,130^FD{Crop} ({Size}) {Variety}^FS\n";
            //else if (PtiType == 3) /*Kilos*/
            //{
            //varietyZPL = "^FX VARIETY, PRESENTATION, DISTRIBUTOR\n" +
            //            "^CFE,40,30\n" +
            //            "^FO15,130^FD" + Crop + "^FS\n" +
            //            "^CFE,50" + fontsize + "\n" +
            //            "^FO15,170^FD" + Variety + "^FS\n" +
            //            "^FO15,210^FD" + Weight + " Kgs " + Presentation + " " + Size + "^FS\n" +
            //            "^FO15,250^FDProduce of Mexico^FS\n";
            //}
            //else
            //{//GENERAL ESPARRAGO / BÁSICO
            //    varietyZPL = "^FX VARIETY, PRESENTATION, DISTRIBUTOR\n" +
            //                "^CFE,40,30\n" +
            //                "^FO15,130^FD" + Crop + "^FS\n" +
            //                "^CFE," + fontsize + "\n" +
            //                "^FO15,170^FD" + Variety + "^FS\n" +
            //                "^FO15,205^FD" + Weight + " Lbs " + Presentation + " " + Size + "^FS\n" +
            //                "^FO15,230^FDProduce of Mexico^FS\n";
            //}
        }
        private void SetStringCropVarietyZPL(string Crop, string Variety)
        {
            //ChangeFontSize(Variety);

            varietyZPL = "^FX CROP, VARIETY\n" +
                        $"^CFF,60,10 ^FO25,130^FD{Crop} {Variety}^FS\n";
            //else if (PtiType == 3) /*Kilos*/
            //{
            //varietyZPL = "^FX VARIETY, PRESENTATION, DISTRIBUTOR\n" +
            //            "^CFE,40,30\n" +
            //            "^FO15,130^FD" + Crop + "^FS\n" +
            //            "^CFE,50" + fontsize + "\n" +
            //            "^FO15,170^FD" + Variety + "^FS\n" +
            //            "^FO15,210^FD" + Weight + " Kgs " + Presentation + " " + Size + "^FS\n" +
            //            "^FO15,250^FDProduce of Mexico^FS\n";
            //}
            //else
            //{//GENERAL ESPARRAGO / BÁSICO
            //    varietyZPL = "^FX VARIETY, PRESENTATION, DISTRIBUTOR\n" +
            //                "^CFE,40,30\n" +
            //                "^FO15,130^FD" + Crop + "^FS\n" +
            //                "^CFE," + fontsize + "\n" +
            //                "^FO15,170^FD" + Variety + "^FS\n" +
            //                "^FO15,205^FD" + Weight + " Lbs " + Presentation + " " + Size + "^FS\n" +
            //                "^FO15,230^FDProduce of Mexico^FS\n";
            //}
        }
        private void SetStringAlbertonsSignatureSelect(string colorGenericName)
        {
            //EN LA BASE DE DATOS LA TABLA DE PACK_COLOR TIENE LA COLUMNA DE v_genericName y se suele poner como COLOR SEEDLESS
            varietyZPL = "^FX VARIETY, PRESENTATION, DISTRIBUTOR\n" +
                        $"^CFF,60,10 ^FO170,130^FDSIGNATURE SELECT {colorGenericName}^FS\n";
        }
        private void SetStringPresentationZPL(string Weight, string Presentation, string container, string preLabel, string postLabel)
        {
            string stringPresentation = container + Weight;
            if (!preLabel.IsNullOrEmpty()) stringPresentation += " " + preLabel;
            stringPresentation += " " + Presentation;
            if (!postLabel.IsNullOrEmpty()) stringPresentation += " " + postLabel;

            presentationZPL = "^FX PRESENTATION\n" +
                        $"^CFF,60,10 ^FO25,190^FD" + stringPresentation + "^FS\n" +
                         "^CFF,30,10 ^FO25,255^FDProduce of Mexico^FS\n";
        }

        private string SetStringDistributorZPL(string Distributor, string AddresDistributor1, string AddresDistributor2)
        {
            //ChangeFontSize(Distributor);

            distributorZPL = "^FX DISTRIBUTOR\n" +
                        "^CFF,30,10\n" +
                        "^FO25,300^FD" + Distributor + "^FS\n" +
                        "^CFF,30,10\n" +
                        "^FO23,335^FD" + AddresDistributor1 + "^FS\n" +
                        "^FO23,365^FD" + AddresDistributor2 + "^FS\n";

            return distributorZPL;
        }
        private string SetStringQrSpaceDistributorZPL(string Distributor, string AddresDistributor1, string AddresDistributor2)
        {
            //ChangeFontSize(Distributor);

            distributorZPL = "^FX DISTRIBUTOR\n" +
                        "^CFF,30,10\n" +
                        "^FO133,300^FD" + Distributor + "^FS\n" +
                        "^CFF,30,10\n" +
                        "^FO133,335^FD" + AddresDistributor1 + "^FS\n" +
                        "^FO133,365^FD" + AddresDistributor2 + "^FS\n";

            return distributorZPL;
        }

        /* Se crea el string ZPL para el código QR de caja unica por plan de trabajo*/
        private string SetStringGrcodeZPL(string Qrcode, string Size, string Program)
        {
            if (Qrcode.Length > 0)
            {
                qrcodeZPL = "^FX QR CODE\n" +
                        "^FO15,280^BY2^BQN,2,4,Q,7^FDQA0" + Qrcode + " " + Program + " " + Size + "^FS\n" +
                        "^CFE,20\n" +
                        "^FO15,392^FD" + Qrcode.Substring(2, 7) + "^FS\n";
            }
            else
            {
                qrcodeZPL = "";
            }

            return qrcodeZPL;
        }

        /*Se crea el string ZPL para el código de barras UPC*/
        private void SetStringUpcZPL(string upc)
        {
            if (upc.Length == 12)
            {
                upcZPL = "^FX UPC CODE\n" +
                        "^FO390,320^BY2^BUN,60,Y,N,Y^FD" + upc + "^FS\n";
            }
            else if (upc.Length == 13)
            {
                upcZPL = "^FX UPC CODE\n" +
                        "^FO390,320^BY2^BEN,60,Y,N,Y^FD" + upc + "^FS\n";
            }else
            {
                upcZPL = "";
            }
        }

        /*Se crea el string ZPL para el Voice Pick Code*/
        private void SetStringVoicePicKCodeZPL(string VPC, DateTime? Date)
        {
            string VPC1 = VPC.Substring(0, 2);
            string VPC2 = VPC.Substring(2, 2);
            string DateMonth = Date?.ToString("MMM") ?? DateTime.Now.ToString("MMM");
            string DateDay = Date?.ToString("dd") ?? DateTime.Now.ToString("dd");


            voicePickCodeZPL = "^FX PACK DATE, VOICE PICK CODE\n" +
                        "^CFF,30,10\n" +
                        "^FO570,245^FDPack^FS\n" +
                        "^FO570,275^FDDate^FS\n" +
                        "^CFD,37\n" +
                        "^FO650,255^FD" + DateMonth + "^FS\n" +
                        "^FO745,255^FD" + DateDay + "^FS\n" +
                        "^FO640,235^FR^GB160,70,50^FS\n" +
                        "^CFE,40,30\n" +
                        "^FO645,355^FD" + VPC1 + "^FS\n" +
                        "^CFE,50,30\n" +
                        "^FO720,335^FD" + VPC2 + "^FS\n" +
                        "^FO640,325^FR^GB160,70,50^FS\n";
        }

        private void ChangeFontSize(string inputText)
        {

            fontsize = "30,20";

            if (inputText.Length > 16 && inputText.Length < 24)
            {
                fontsize = "25";
            }
            else if (inputText.Length > 24)
            {
                fontsize = "20";
            }
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
