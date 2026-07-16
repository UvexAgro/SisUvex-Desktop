using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisUvex.Reports
{
    internal class PTITag
    {
        string PTItag, variety, distributor, presentation, weight, adress1, adress2, date, GTINFull;
        string boxNumber, gtin, dateNumber, lotNumber, UPC, VPC1, VPC2, fontsize;

        
        int dayOfYear = DateTime.Today.DayOfYear;



        public string PtiUpc(string variety, string distributor, string presentation, string weight, string adress1, string adress2, string date, string gtin, string dateNumber, string lotNumber, string UPC, string VPC1, string VPC2)
        {
            

            ChangeFontSize(variety);

            string PTItag = "^XA  ^FX GTIN\n" +
                           "^FO0,15\n" +
                           "^BRN,11,3,1,25,10^FD01" + gtin + "13" + dateNumber + "10" + lotNumber + " ^FS\n" +

                           "^CFE,20\n" +
                           "^FO10,100^FD(01)" + gtin + "(13)" + dateNumber + "(10)" + lotNumber + " ^FS\n" +
                           "^FX SEGUNDA LINEA\n" +

                           "^FX VARIETY, PRESENTATION, DISTRIBUTOR\n" +
                           "^CFE,"+fontsize+"\n" +
                           "^FO20,150^FD" + variety + "^FS\n" +
                           "^CFE,35\n" +
                           "^FO20,220^FD" + weight + " Lbs " + presentation + " ^FS\n" +
                           "^FO20,260^FDProduce of Mexico^FS\n" +
                           "^CFF,25\n" +
                           "^FO20,300^FD" + distributor + "^FS\n" +
                           "^FO20,340^FD" + adress1 + "^FS\n" +
                           "^FO20,370^FD" + adress2 + "^FS\n" +

                           "^FX UPC CODE\n" +
                           "^FO390,320^BY2^BUN,60,Y,N,Y^FD" + UPC + "^FS\n" +


                           "^FX PACK DATE, VOICE PICK CODE\n" +
                           "^CFE,35\n" +
                           "^FO630,150^FDPack^FS\n" +
                           "^FO630,200^FDDate^FS\n" +
                           "^CFL,40\n" +
                           "^FO625,250^FD" + date + "^FS\n" +
                           "^FO625,225^FR^GB170,80,40^FS\n" +
                           "^CFE,45\n" +
                           "^FO630,360^FD" + VPC1 + "^FS\n" +
                           "^CFE,65\n" +
                           "^FO715,345^FD" + VPC2 + "^FS\n" +
                           "^FO625,325^FR^GB170,80,40^FS\n" +
                           "^XZ";

            return PTItag;
        }

        public string Pti(string variety, string distributor, string presentation, string weight, string adress1, string adress2, string date, string gtin, string dateNumber, string lotNumber, string VPC1, string VPC2)
        {

            ChangeFontSize(variety);


            string PTItag = "^XA  ^FX GTIN\n" +
                           "^FO0,15\n" +
                           "^BRN,11,3,1,25,10^FD01" + gtin + "13" + dateNumber + "10" + lotNumber + " ^FS\n" +

                           "^CFE,20\n" +
                           "^FO10,100^FD(01)" + gtin + "(13)" + dateNumber + "(10)" + lotNumber + " ^FS\n" +
                           "^FX SEGUNDA LINEA\n" +

                           "^FX VARIETY, PRESENTATION, DISTRIBUTOR\n" +
                           "^CFE,"+fontsize+"\n" +
                           "^FO20,150^FD" + variety + "^FS\n" +
                           "^CFE,35\n" +
                           "^FO20,220^FD" + weight + " Lbs " + presentation + " ^FS\n" +
                           "^FO20,260^FDProduct of Mexico^FS\n" +
                           "^FO20,300^FD" + distributor + "^FS\n" +
                           "^CFF,25\n" +
                           "^FO20,340^FD" + adress1 + "^FS\n" +
                           "^FO20,370^FD" + adress2 + "^FS\n" +


                           "^FX PACK DATE, VOICE PICK CODE\n" +
                           "^CFE,35\n" +
                           "^FO630,150^FDPack^FS\n" +
                           "^FO630,200^FDDate^FS\n" +
                           "^CFL,40\n" +
                           "^FO625,250^FD" + date + "^FS\n" +
                           "^FO625,225^FR^GB170,80,40^FS\n" +
                           "^CFE,45\n" +
                           "^FO630,360^FD" + VPC1 + "^FS\n" +
                           "^CFE,65\n" +
                           "^FO715,345^FD" + VPC2 + "^FS\n" +
                           "^FO625,325^FR^GB170,80,40^FS\n" +
                           "^XZ";

            return PTItag;
        }

        public string PtiAlbertsons(string color,string distributor, string presentation, string weight, string adress1, string adress2, string date, string gtin, string dateNumber, string lotNumber, string UPC, string VPC1, string VPC2)
        {
  

            string PTItag = "^XA  ^FX GTIN\n" +
                           "^FO0,15\n" +
                           "^BRN,11,3,1,25,10^FD01" + gtin + "13" + dateNumber + "10" + lotNumber + " ^FS\n" +

                           "^CFE,20\n" +
                           "^FO10,100^FD(01)" + gtin + "(13)" + dateNumber + "(10)" + lotNumber + " ^FS\n" +
                           "^FX SEGUNDA LINEA\n" +

                           "^FX VARIETY, PRESENTATION, DISTRIBUTOR\n" +
                           "^CFE,30\n" +
                           "^FO20,150^FD SIGNATURE SELECT "+color+" SEEDLESS GRAPE^FS\n" +
                           "^CFE,35\n" +
                           "^FO20,220^FD 8 / 2 Lbs ^FS\n" +
                           "^FO20,260^FDProduce of Mexico^FS\n" +
                           "^CFF,25\n" +
                           "^FO20,300^FD" + distributor + "^FS\n" +
                           "^FO20,340^FD" + adress1 + "^FS\n" +
                           "^FO20,370^FD" + adress2 + "^FS\n" +

                           "^FX UPC CODE\n" +
                           "^FO390,320^BY2^BUN,60,Y,N,Y^FD" + UPC + "^FS\n" +


                           "^FX PACK DATE, VOICE PICK CODE\n" +
                           "^CFE,35\n" +
                           "^FO500,230^FDJulian^FS\n" +
                           "^FO520,280^FDDate^FS\n" +
                           "^CFL,40\n" +
                           "^FO645,250^FD" + dayOfYear + "^FS\n" +
                           "^FO625,225^FR^GB170,80,40^FS\n" +
                           "^CFE,45\n" +
                           "^FO630,360^FD" + VPC1 + "^FS\n" +
                           "^CFE,65\n" +
                           "^FO715,345^FD" + VPC2 + "^FS\n" +
                           "^FO625,325^FR^GB170,80,40^FS\n" +
                           "^XZ";

            return PTItag;
        }

        private void ChangeFontSize(String variety)
        {

            fontsize = "50";

            if (variety.Length > 16 && variety.Length < 24)
            {
                fontsize = "40";
            }
            else if (variety.Length > 24)
            {
                fontsize = "30";
            }
        }
    }
}
