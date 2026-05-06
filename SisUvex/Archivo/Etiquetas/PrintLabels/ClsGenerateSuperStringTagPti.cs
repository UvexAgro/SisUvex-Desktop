using Azure;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Microsoft.ReportingServices.ReportProcessing.OnDemandReportObjectModel;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Catalogos.Metods.Values;
using SisUvex.Configuracion.Parameters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing.QrCode.Internal;
using static SisUvex.Catalogos.Metods.ClsObject;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            reverseLabelOrientationZPL = ReverseLabelOrientation(reverseOrientation);
            eTag = eTagInfo;

            string? idPti = string.IsNullOrEmpty(eTag.idPti) ? GetIdPtiDefaultLabelPtiParameter() : eTag.idPti;
            string kgs = (double.Parse(eTag.Lbs) * 0.453592).ToString("0.0");
            string? fullPresentation = CONCAT_WS(" ", eTag.preLabel, eTag.namePresentation, eTag.postLabel);
            string? left2WGroup = eTag.workGroupName?.Substring(0,2);

            switch (idPti)
            {
                case
                    "01":
                    //ESTANDAR (2026)                  -->se cambió en 28-abril-2026 la de dayka-walmart como standar para todas las demás, el standar viejo ahora es la "09" standar 2025
                    SetStringPtiStandar2026ColorBoldColorVarietyLbsZPL(eTag.nameGenericColor + " GRAPE", eTag.nameVariety, $"{eTag.Lbs}lb / {kgs}kg CASE {fullPresentation}"); //DISTRIBUIDOR STANDAR
                    SetStringPtiStandar2026PackedByDistributedByNameAndProductOfMexicoZPL("Grown/Packed by:", "Uvex Agro Internacional", "Distributed by:", eTag.nameDistributor); //PRESENTACION STANDAR
                    break;
                case
                    "02":
                    //ALBERTONS
                    return SetStringAlbertonsPtiLabel(copies);
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
                    SetStringPresentationZPL(" " + kgs + " Kg", eTag.namePresentation, eTag.nameContainer, eTag.preLabel, eTag.postLabel); //PRESENTACION KILOS
                    SetStringDistributorZPL(eTag.nameDistributor, eTag.addressDistributor, eTag.cityDistributor); //DISTRIBUIDOR STANDAR
                    break;
                case
                    "05":
                    //FOUR STARS
                    SetStringCropVarietyZPL(eTag.nameCrop, eTag.nameVariety); //VARIEDAD  STANDAR
                    SetStringPresentationZPL(eTag.Lbs + " LB Bags", string.Empty, string.Empty, string.Empty, string.Empty);//PRESENTACION FOUR STARS
                    SetStringDistributorZPL(eTag.nameDistributor, eTag.addressDistributor, eTag.cityDistributor); //DISTRIBUIDOR STANDAR
                    break;
                case
                    "06":
                    //QR ESPARRAGO
                    SetStringCropVarietySizeZPL(eTag.nameCrop, eTag.nameVariety, eTag.nameSize); //VARIEDAD  STANDAR
                    SetStringPresentationZPL(eTag.Lbs, eTag.namePresentation, eTag.nameContainer, eTag.preLabel, eTag.postLabel); //PRESENTACION STANDAR
                    SetStringQrSpaceDistributorZPL(eTag.nameDistributor, eTag.addressDistributor, eTag.cityDistributor); //DISTRIBUIDOR CON ESPACIO QR
                    break;
                case
                    "07":
                    //QR CANADA
                    SetStringGtinZPL(eTag.valueGTIN, eTag.dateWorkPlan, eTag.showDate, eTag.idLot, left2WGroup);
                    SetStringDistributorZPL(eTag.nameDistributor, eTag.addressDistributor, eTag.cityDistributor); //DISTRIBUIDOR STANDAR
                    return SetStringCanadaPtiLabel(copies);
                case
                    "08":
                    //NOMBRE CIENTIFICO (ESTANDAR PARA VARIEDADES CON NOMBRE CIENTIFICO)
                    string scientificName = string.IsNullOrEmpty(eTag.scientisVarierty) ? eTag.nameVariety : eTag.scientisVarierty; //En caso de que no tenga científico que use el nombre normal (comercial)

                    //SetStringCropVarietySizeZPL(eTag.nameCrop, eTag.scientisVarierty, eTag.nameSize); //VARIEDAD CON NOMBRE CIENTIFICO
                    //SetStringPresentationZPL(eTag.Lbs, eTag.namePresentation, eTag.nameContainer, eTag.preLabel, eTag.postLabel); //PRESENTACION STANDAR
                    //SetStringDistributorZPL(eTag.nameDistributor, eTag.addressDistributor, eTag.cityDistributor); //DISTRIBUIDOR STANDAR
                    SetStringPtiStandar2026ColorBoldColorVarietyLbsZPL(eTag.nameGenericColor + " GRAPE", scientificName, $"{eTag.Lbs}lb / {kgs}kg CASE {fullPresentation}"); //DISTRIBUIDOR STANDAR
                    SetStringPtiStandar2026PackedByDistributedByNameAndProductOfMexicoZPL("Grown/Packed by:", "Uvex Agro Internacional", "Distributed by:", eTag.nameDistributor); //PRESENTACION STANDAR
                    
                    break;
                case
                    "09":
                    //STANDAR 2025
                    SetStringCropVarietySizeZPL2025(eTag.nameCrop, eTag.nameVariety, eTag.nameSize); //VARIEDAD  STANDAR
                    SetStringPresentationZPL2025(eTag.Lbs, eTag.namePresentation, eTag.nameContainer, eTag.preLabel, eTag.postLabel); //PRESENTACION STANDAR
                    SetStringDistributorZPL2025(eTag.nameDistributor, eTag.addressDistributor, eTag.cityDistributor); //DISTRIBUIDOR STANDAR
                    break;
                default:
                    SetStringCropVarietySizeZPL(eTag.nameCrop, eTag.nameVariety, eTag.nameSize); //VARIEDAD  STANDAR
                    SetStringDistributorZPL(eTag.nameDistributor, eTag.addressDistributor, eTag.cityDistributor); //DISTRIBUIDOR STANDAR
                    SetStringPresentationZPL(eTag.Lbs, string.Empty, string.Empty, string.Empty, string.Empty); //PRESENTACION STANDAR
                    break;
            }

            SetStringGtinZPL(eTag.valueGTIN, eTag.dateWorkPlan, eTag.showDate, eTag.idLot, left2WGroup);
            SetStringUpcZPL(eTag.upcGTIN);
            SetStringVoicePicKCodeAndPackDateZPL(eTag.voicePickCode, eTag.dateWorkPlan, eTag.showDate);

            if (idPti == "06") //QR ESPARRAGO
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
        private string SetStringAlbertonsPtiLabel(int copies)
        {

            string zplAlbertons = $"\n^CF0,30,30" +
                                    $"\n^FT32,47^FD8/2 lb Clams^FS" +
                                    $"\n^FT565,47^FD{textUPCAlbertons(eTag.upcGTIN)}^FS" +
                                    $"\n^FT178,98^FDSignature Select {ClsValues.ToTitleCase(eTag.nameGenericColor)} Grapes^FS" +
                                    $"\n^FT321,132^FDPack Date: {Juliana(eTag.dateWorkPlan)}^FS" +
                                    $"\n^FT292,162^FDProduce of Mexico^FS" +
                                    $"\n^FT173,210^FDDistributed by Better Living Brands, LLC^FS" +
                                    $"\n^FT166,246^FD P.O. Box 99, Pleasanton, CA 94566-0009^FS" +
                                    $"\n^FO165,290^B3N,N,70,Y^FD{eTag.valueGTIN}^FS";
            labelsZPLString = zplBegin + zplAlbertons + reverseLabelOrientationZPL + zplEnd;
            string superString = string.Empty;
            for (int i = 0; i < copies; i++)
            {
                superString += "\n" + labelsZPLString;
            }

            return superString;
        }
        private string SetStringCanadaPtiLabel(int copies)
        {
            string stringPresentation = eTag.nameContainer;
            if (!string.IsNullOrEmpty(eTag.preLabel)) stringPresentation += " " + eTag.preLabel;
            stringPresentation += " " + eTag.namePresentation;
            if (!string.IsNullOrEmpty(eTag.postLabel)) stringPresentation += " " + eTag.postLabel;

            string VPC1 = eTag.voicePickCode.Substring(0, 2);
            string VPC2 = eTag.voicePickCode.Substring(2, 2);
            string DateMonth = eTag.dateWorkPlan?.ToString("MMM") ?? DateTime.Now.ToString("MMM");
            string DateDay = eTag.dateWorkPlan?.ToString("dd") ?? DateTime.Now.ToString("dd");

            string zplAlbertons = $"\n^CFF,10,0 ^FO10,130^FD {eTag.nameColorCanEn}/{eTag.nameColorCanFr} ^FS" +
                                    $"\n^CFF,10,0 ^FO25,160^FD{eTag.nameVariety} ({eTag.nameSize})^FS" +
                                    $"\n^CFF,10,0 ^FO25,210^FD{stringPresentation}^FS" +
                                    $"\n^CFF,10,0 ^FO25,240^FDNet Weight / Poids Net: {eTag.Lbs} lb^FS" +
                                    $"\n^CFF,10,0 ^FO25,270^FDProduce of / Produit de Mexique^FS" +
                                    $"\n^CFF,30,10^FO635,175^FDPack date^FS" +
                                    $"\n^CFF,30,10^FO605,205^FDDate d'emballage^FS" +
                                    $"\n^CFD,37^FO650,255^FD{DateMonth}^FS" +
                                    $"\n^CFD,37^FO745,255^FD{DateDay}^FS" +
                                    $"\n^FO640,235^FR^GB160,70,50^FS" +
                                    $"\n^CFE,40,30^FO645,355^FD{VPC1}^FS" +
                                    $"\n^CFE,50,30^FO720,335^FD{VPC2}^FS" +
                                    $"\n^FO640,325^FR^GB160,70,50^FS";

            labelsZPLString = zplBegin + zplAlbertons + gtinZPL + distributorZPL + upcZPL + reverseLabelOrientationZPL + zplEnd;
            string superString = string.Empty;
            for (int i = 0; i < copies; i++)
            {
                superString += "\n" + labelsZPLString;
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

        private void SetStringGtinZPL(string Gtin, DateTime? Date, bool? showDate, string Lote, string Workgroup)
        {
            string DateShortUS = Date?.ToString("yyMMdd") ?? DateTime.Now.ToString("yyMMdd");

            gtinZPL = "^FX GTIN\n" +
                        "^FX GTIN BARCODE\n" +
                        "^FO0,15\n" +
                        "^BRN,11,3,1,20,10^FD01" + Gtin + "13" + DateShortUS + "10" + Lote + "C" + Workgroup + "^FS\n" +
                        "^CFF,30,10\n" +
                        "^FX GTIN HUMAN READABLE\n";
            if (showDate == true || showDate == null)
            {
                gtinZPL += "^FO100,80^FD(01)" + Gtin;
                gtinZPL += "(13)" + DateShortUS;
                gtinZPL += "(10)" + Lote + "C" + Workgroup + "^FS\n";
            }
            else
            {
                gtinZPL += "^FO170,80^FD(01)" + Gtin;
                gtinZPL += "(10)" + Lote + "C" + Workgroup + "^FS\n";
            }

        }

        private void SetStringCropVarietySizeZPL(string Crop, string Variety, string Size)
        {//2026
            varietyZPL = "^FX CROP, SIZE AND VARIETY\n" +
                        $"^CFF,60,10 ^FO25,130^FD{Crop} ({Size}) {Variety}^FS\n";
        }
        private void SetStringCropVarietySizeZPL2025(string Crop, string Variety, string Size)
        {
            varietyZPL = "^FX CROP, SIZE AND VARIETY\n" +
                        $"^CFF,60,10 ^FO25,130^FD{Crop} ({Size}) {Variety}^FS\n";
        }
        private void SetStringCropVarietyZPL(string Crop, string Variety)
        {
            varietyZPL = "^FX CROP, VARIETY\n" +
                        $"^CFF,60,10 ^FO25,130^FD{Crop} {Variety}^FS\n";
        }
        private void SetStringAlbertonsSignatureSelect(string colorGenericName)
        {
            //EN LA BASE DE DATOS LA TABLA DE PACK_COLOR TIENE LA COLUMNA DE v_genericName y se suele poner como COLOR SEEDLESS
            varietyZPL = "^FX VARIETY, PRESENTATION, DISTRIBUTOR\n" +
                        $"^CFF,60,10 ^FO170,130^FDSIGNATURE SELECT {colorGenericName}^FS\n";
        }

        private void SetStringPresentationZPL(string Weight, string Presentation, string container, string preLabel, string postLabel)
        {//2026
            string stringPresentation = container + Weight;
            if (!string.IsNullOrEmpty(preLabel)) stringPresentation += " " + preLabel;
            stringPresentation += " " + Presentation;
            if (!string.IsNullOrEmpty(postLabel)) stringPresentation += " " + postLabel;

            presentationZPL = "^FX PRESENTATION\n" +
                        $"^CFF,60,10 ^FO25,190^FD" + stringPresentation + "^FS\n" +
                         "^CFF,30,10 ^FO25,255^FDProduce of Mexico^FS\n";
        }
        private void SetStringPresentationZPL2025(string Weight, string Presentation, string container, string preLabel, string postLabel)
        {
            string stringPresentation = container + Weight;
            if (!string.IsNullOrEmpty(preLabel)) stringPresentation += " " + preLabel;
            stringPresentation += " " + Presentation;
            if (!string.IsNullOrEmpty(postLabel)) stringPresentation += " " + postLabel;

            presentationZPL = "^FX PRESENTATION\n" +
                        $"^CFF,60,10 ^FO25,190^FD" + stringPresentation + "^FS\n" +
                         "^CFF,30,10 ^FO25,255^FDProduce of Mexico^FS\n";
        }

        private string SetStringDistributorZPL(string Distributor, string AddresDistributor1, string AddresDistributor2)
        {
            distributorZPL = "^FX DISTRIBUTOR\n" +
                        "^CFF,30,10\n" +
                        "^FO25,300^FD" + Distributor + "^FS\n" +
                        "^CFF,30,10\n" +
                        "^FO23,335^FD" + AddresDistributor1 + "^FS\n" +
                        "^FO23,365^FD" + AddresDistributor2 + "^FS\n";

            return distributorZPL;
        }
        private string SetStringDistributorZPL2025(string Distributor, string AddresDistributor1, string AddresDistributor2)
        {
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
            }
            else if (upc.Length == 8)
            {
                upcZPL = "^FX UPC CODE\n" +
                        "^FO390,320^BY2^B8,60,Y,N,Y^FD" + upc + "^FS\n";
            }
            else
            {
                upcZPL = "";
            }
        }

        /*Se crea el string ZPL para el Voice Pick Code*/
        private void SetStringVoicePicKCodeAndPackDateZPL(string VPC, DateTime? Date, bool? showDate) //Y FECHA EN CUADRO NEGRO
        {
            string VPC1 = VPC.Substring(0, 2);
            string VPC2 = VPC.Substring(2, 2);
            string DateMonth = Date?.ToString("MMM") ?? DateTime.Now.ToString("MMM");
            string DateDay = Date?.ToString("dd") ?? DateTime.Now.ToString("dd");


            voicePickCodeZPL = "^FX PACK DATE, VOICE PICK CODE\n" +
                        "^CFE,40,30\n" +
                        "^FO645,355^FD" + VPC1 + "^FS\n" +
                        "^CFE,50,30\n" +
                        "^FO720,335^FD" + VPC2 + "^FS\n" +
                        "^FO640,325^FR^GB160,70,50^FS\n";


            if (showDate == true || showDate == null)
            {
                voicePickCodeZPL += "^CFF,30,10\n" +
                        "^FO570,245^FDPack^FS\n" +
                        "^FO570,275^FDDate^FS\n" +
                        "^CFD,37\n" +
                        "^FO650,255^FD" + DateMonth + "^FS\n" +
                        "^FO745,255^FD" + DateDay + "^FS\n" +
                        "^FO640,235^GB160,70,3^FS"; //RECTANGULO BLANCO CON BORDES NEGROS
                                                    //"^FO640,235^FR^GB160,70,50^FS\n"; //RECTANGULO NEGRO
            }
            else
            {// de momento solo no muestra la fecha y su cuadro negro
            }
        }
        /// <summary>
        /// (2026-STANDAR) EJ: BLACK SEEDLESS GRAPE, /n MIDNIGHT BEAUTY, /n 18Lb / 8.2Kg CASE, /n Product of Mexico
        /// </summary>
        /// <param name="Crop"></param>
        /// <param name="Variety"></param>
        private void SetStringPtiStandar2026ColorBoldColorVarietyLbsZPL(string? ColorLine1, string? VarietyLine2, string? WeightLine3)
        {
            //labelsZPLString = zplBegin + gtinZPL + distributorZPL + varietyZPL + presentationZPL + qrcodeZPL + upcZPL + voicePickCodeZPL + reverseLabelOrientationZPL + zplEnd;
            varietyZPL = "^FX COLOR\n" +
                        $"^CF0,30,35 ^FO25,110^FD{ColorLine1}^FS\n"
                        + "^FX VARIETY\n" +
                        $"^CF0,30,35 ^FO25,145^FD{VarietyLine2}^FS\n"
                        + "^FX WEIGHT\n" +
                        $"^CF0,30,40 ^FO23,180^FD{WeightLine3}^FS\n";
        }
        private void SetStringPtiStandar2026PackedByDistributedByNameAndProductOfMexicoZPL(string? GrownBy1, string? GrowerLine2, string? DistributedBy3, string? DistributorLine4)
        {
            distributorZPL = "^FX  PRODUCTO DE\n" +
                        $"^CF0,30,50^FO22,220^FDProduct of Mexico^FS\n"
                        + "^FX GROWER\n" +
                        $"^CFF,30,10^FO23,260^FD{GrownBy1}^FS\n" +
                        $"^FO25,290^FD{GrowerLine2}^FS\n"
                        + "^FX DISTRIBUIDOR\n" +
                        $"^CFF,30,10^FO25,330^FD{DistributedBy3}^FS\n" +
                        $"^FO25,360^FD{DistributorLine4}^FS\n";
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
        private static string textUPCAlbertons(string? upc)
        {
            if (string.IsNullOrEmpty(upc) || upc.Length != 12)
                return string.Empty;

            return $"{upc[0]}-{upc.Substring(1, 5)}-{upc.Substring(6, 5)}-{upc[11]}";
        }

        public static string Juliana(DateTime? date)
        {
            if (date == null)
                return string.Empty;
            else
                return date.Value.DayOfYear.ToString("D3");
        }

        private string? GetIdPtiDefaultLabelPtiParameter()
        {
            return EParameters.GetValue("019", "02");
        }

        private string? CONCAT_WS(string separator, params string[] values)
        {
            return string.Join(separator, values.Where(v => !string.IsNullOrEmpty(v)));
        }
    }
}
