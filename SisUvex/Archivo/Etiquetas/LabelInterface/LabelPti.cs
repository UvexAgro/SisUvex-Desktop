using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using DocumentFormat.OpenXml.Presentation;
using Microsoft.Reporting.Map.WebForms.BingMaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisUvex.Archivo.Etiquetas.LabelInterface
{
    internal class LabelPti : LabelZebra, IPti
    {
        private string gtinZPL;
        private string distributorZPL;
        private string varietyZPL;
        private string qrcodeZPL;
        private string upcZPL;
        private string so2ZPL;
        private string voicePickCodeZPL;
        private string zplBegin;
        private string zplEnd;
        private string fontsize ="";

        public int PtiType { get; set; }
        public string Gtin { get; set; }
        public string Lote { get; set; }
        public string Workgroup { get; set; }
        public string DateShortUS { get; set; }
        public string Crop { get; set; }
        public string Variety { get; set; }
        public string Presentation { get; set; }
        public string Pounds { get; set; }
        public string Size { get; set; }
        public string Distributor { get; set; }
        public string AddresDistributor1 { get; set; }
        public string AddresDistributor2 { get; set; }
        public string DateMonthDay { get; set; }
        public string VoicePickCode1 { get; set; }
        public string VoicePickCode2 { get; set; }
        public string Qrcode { get; set; }
        public string Upc { get; set; }

        public string Program { get; set; }

        public LabelPti()
        {
            /*Variables de interface*/
            PtiType = 1;
            Gtin ="";
            Lote ="";
            Workgroup ="";
            DateShortUS ="";
            Crop ="";
            Variety ="";
            Presentation ="";
            Pounds ="";
            Size ="";
            Distributor ="";
            AddresDistributor1 ="";
            AddresDistributor2 ="";
            DateMonthDay ="";
            VoicePickCode1 ="";
            VoicePickCode2 ="";
            Qrcode ="";
            Upc ="";

            /*Variables de clase*/
            gtinZPL ="";
            distributorZPL ="";
            varietyZPL ="";
            qrcodeZPL ="";
            upcZPL ="";
            so2ZPL ="";
            voicePickCodeZPL ="";
            labelsZPLString ="";

            zplBegin ="^XA";
            zplEnd ="^XZ\n";
        }
        
        /*Sobrecarga del metodo para generar el string ZPL para la etiqueta PTI*/
        public override string SuperPrint()
        {
            GtinZPLString(Gtin, DateShortUS, Lote, Workgroup);
            VarietyCropZPLString(Crop, Variety, Pounds, Presentation, Size);
            DistributorZPLString(Distributor, AddresDistributor1, AddresDistributor2);
            GrcodeZPLString(Qrcode, Size, Program);
            UpcZPLString(Upc);
            VoicePicKCodeZPLString(VoicePickCode1, VoicePickCode2, DateMonthDay);

            labelsZPLString = zplBegin + gtinZPL + distributorZPL + varietyZPL + qrcodeZPL + upcZPL + so2ZPL + voicePickCodeZPL + zplEnd;

            return labelsZPLString;
        }


        /*Se crea el string ZPL para el código de barras GTIN*/
        private string GtinZPLString(string Gtin, string DateShortUS, string Lote, string Workgroup)
        {

            gtinZPL ="^FX GTIN\n" +
                        "^FX GTIN BARCODE\n" +
                        "^FO0,15\n" +
                        "^BRN,11,3,1,25,10^FD01" + Gtin +"13" + DateShortUS +"10" + Lote +"C"+Workgroup+"^FS\n" +
                        "^CFA,30\n" +
                        "^FX GTIN HUMAN READABLE\n" +
                        "^FO50,100^FD(01)" + Gtin +"(13)" + DateShortUS +"(10)" + Lote +"C" +Workgroup+"^FS\n";

            return gtinZPL;
        }

        /*Se crea el string ZPL para la variedad y el cultivo*/
        private string VarietyCropZPLString(string Crop, string Variety, string Weight, string Presentation, string Size)
        {
            ChangeFontSize(Variety);

            if(PtiType == 2) 
            {
                varietyZPL ="^FX VARIETY, PRESENTATION, DISTRIBUTOR\n" +
                            "^CFA," + fontsize +"\n" +
                            "^FO15,170^FDSIGNATURE SELECT" + Variety +"^FS\n" +
                            "^FO15,210^FD" + Weight +" Lbs " + Presentation + " " + Size + "^FS\n" +
                            "^FO15,250^FDProduce of Mexico^FS\n";
            }
            else if (PtiType == 3) /*Kilos*/
            {
                varietyZPL ="^FX VARIETY, PRESENTATION, DISTRIBUTOR\n" +
                            "^CFA,40,30\n" +
                            "^FO15,130^FD" + Crop +"^FS\n" +
                            "^CFA,50" + fontsize +"\n" +
                            "^FO15,170^FD" + Variety +"^FS\n" +
                            "^FO15,210^FD" + Weight +" Kgs " + Presentation +" "+Size+"^FS\n" +
                            "^FO15,250^FDProduce of Mexico^FS\n";
            }
            else
            {
                varietyZPL ="^FX VARIETY, PRESENTATION, DISTRIBUTOR\n" +
                            "^CFA,40,30\n" +
                            "^FO15,130^FD" + Crop +"^FS\n" +
                            "^CFA," + fontsize +"\n" +
                            "^FO15,170^FD" + Variety +"^FS\n" +
                            "^FO15,205^FD" + Weight +" Lbs " + Presentation + " " + Size + "^FS\n" +
                            "^FO15,230^FDProduce of Mexico^FS\n";
            }


            return varietyZPL;
        }

        private string DistributorZPLString(string Distributor, string AddresDistributor1, string AddresDistributor2)
        {
            ChangeFontSize(Distributor);

            distributorZPL ="^FX DISTRIBUTOR\n" +
                        "^CFA,30\n" +
                        "^FO15,260^FD" + Distributor +"^FS\n" +
                        "^CFA,20\n" +
                        "^FO120,300^FD" + AddresDistributor1 +"^FS\n" +
                        "^FO120,330^FD" + AddresDistributor2 +"^FS\n";

            return distributorZPL;
        }

        /* Se crea el string ZPL para el código QR de caja unica por plan de trabajo*/
        private string GrcodeZPLString(string Qrcode, string Size, string Program )
        {
            if(Qrcode.Length > 0)
            {
                qrcodeZPL ="^FX QR CODE\n" +
                        "^FO15,280^BY2^BQN,2,4,Q,7^FDQA0" +Qrcode+ " "+Program+" "+Size+"^FS\n"+
                        "^CFA,20\n" +
                        "^FO15,392^FD" + Qrcode.Substring(2,7)+"^FS\n";
            }
            else
            {
                qrcodeZPL ="";
            }

            return qrcodeZPL;
        }

        /*Se crea el string ZPL para el código de barras UPC*/
        private string UpcZPLString(string upc)
        {
            if(upc.Length > 0)
            {
                upcZPL ="^FX UPC CODE\n" +
                        "^FO390,320^BY2^BUN,60,Y,N,Y^FD" + upc +"^FS\n";
            }
            else
            {
                upcZPL ="";
            }

            return upcZPL;
        }

        /*Se crea el string ZPL para el Voice Pick Code*/
        private string VoicePicKCodeZPLString (string VPC1, string VPC2,string date)
        {
            voicePickCodeZPL ="^FX PACK DATE, VOICE PICK CODE\n" +
                        "^CFA,25\n" +
                        "^FO565,240^FDPack^FS\n" +
                        "^FO565,270^FDDate^FS\n" +
                        "^CFL,40\n" +
                        "^FO630,250^FD" + date +"^FS\n" +
                        "^FO640,235^FR^GB160,70,50^FS\n" +
                        "^CFA,40,30\n" +
                        "^FO645,350^FD" + VPC1 +"^FS\n" +
                        "^CFA,50,30\n" +
                        "^FO720,330^FD" + VPC2 +"^FS\n" +
                        "^FO640,325^FR^GB160,70,50^FS\n";

            return voicePickCodeZPL;
        }

        private void ChangeFontSize(String inputText)
        {

            fontsize ="30,20";

            if (inputText.Length > 16 && inputText.Length < 24)
            {
                fontsize ="25";
            }
            else if (inputText.Length > 24)
            {
                fontsize ="20";
            }
        }

    }

}
