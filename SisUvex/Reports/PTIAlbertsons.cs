using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisUvex.Reports
{
    internal class PTIAlbertsons
    {
        string PTItag, variety, distributor, presentation, weight, adress1, adress2, date, GTINFull;
        string boxNumber, gtin, dateNumber, lotNumber, UPC, VPC1, VPC2;


        public string PtiUpcQR(string variety, string distributor, string presentation, string weight, string adress1, string adress2, string date, string boxNumber, string gtin, string dateNumber, string lotNumber, string UPC, string VPC1, string VPC2)
        {

            string PTItag = "^XA  ^FX GTIN\n" +
                           "^FO0,15\n" +
                           "^BRN,11,3,1,25,10^FD01" + gtin + "13" + dateNumber + "10" + lotNumber + " ^FS\n" +

                           "^CFE,20\n" +
                           "^FO20,100^FD(01)" + gtin + "(13)" + dateNumber + "(10)" + lotNumber + " ^FS\n" +
                           "^FX SEGUNDA LINEA\n" +

                           "^FX CODEBOX QR\n" +
                           "^FO710,125\n" +
                           "^BQN,2,4^FDQA," + boxNumber + "^FS\n" +


                           "^FX VARIETY, PRESENTATION, DISTRIBUTOR\n" +
                           "^CFE,40\n" +
                           "^FO20,150^FD" + variety + "^FS\n" +
                           "^CFE,35\n" +
                           "^FO20,220^FD" + weight + " Lbs " + presentation + " ^FS\n" +
                           "^FO20,260^FDProduct of Mexico^FS\n" +
                           "^FO20,300^FD" + distributor + "^FS\n" +
                           "^CFF,25\n" +
                           "^FO20,340^FD" + adress1 + "^FS\n" +
                           "^FO20,370^FD" + adress2 + "^FS\n" +

                           "^FX UPC CODE\n" +
                           "^FO380,320^BY2^BUN,60,Y,N,Y^FD" + UPC + "^FS\n" +


                           "^FX PACK DATE, VOICE PICK CODE\n" +
                           "^CFE,35\n" +
                           "^FO530,230^FDJulian^FS\n" +
                           "^FO530,270^FDDate^FS\n" +
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

        public string PtiUpc(string variety, string distributor, string presentation, string weight, string adress1, string adress2, string date, string gtin, string dateNumber, string lotNumber, string UPC, string VPC1, string VPC2)
        {

            string PTItag = "^XA  ^FX GTIN\n" +
                           "^FO0,15\n" +
                           "^BRN,11,3,1,25,10^FD01" + gtin + "13" + dateNumber + "10" + lotNumber + " ^FS\n" +

                           "^CFE,20\n" +
                           "^FO20,100^FD(01)" + gtin + "(13)" + dateNumber + "(10)" + lotNumber + " ^FS\n" +
                           "^FX SEGUNDA LINEA\n" +

                           "^FX VARIETY, PRESENTATION, DISTRIBUTOR\n" +
                           "^CFE,40\n" +
                           "^FO20,150^FD" + variety + "^FS\n" +
                           "^CFE,35\n" +
                           "^FO20,220^FD" + weight + " Lbs " + presentation + " ^FS\n" +
                           "^FO20,260^FDProduce of Mexico^FS\n" +
                           "^CFF,25\n" +
                           "^FO20,300^FD" + distributor + "^FS\n" +
                           "^FO20,340^FD" + adress1 + "^FS\n" +
                           "^FO20,370^FD" + adress2 + "^FS\n" +

                           "^FX UPC CODE\n" +
                           "^FO380,320^BY2^BUN,60,Y,N,Y^FD" + UPC + "^FS\n" +


                           "^FX PACK DATE, VOICE PICK CODE\n" +
                           "^CFE,35\n" +
                           "^FO490,230^FDJulian^FS\n" +
                           "^FO530,270^FDDate^FS\n" +
                           "^CFL,40\n" +
                           "^FO665,250^FD" + date + "^FS\n" +
                           "^FO625,225^FR^GB170,80,40^FS\n" +
                           "^CFE,45\n" +
                           "^FO630,360^FD" + VPC1 + "^FS\n" +
                           "^CFE,65\n" +
                           "^FO715,345^FD" + VPC2 + "^FS\n" +
                           "^FO625,325^FR^GB170,80,40^FS\n" +
                           "^XZ";

            return PTItag;
        }

        public string PtiQr(string variety, string distributor, string presentation, string weight, string adress1, string adress2, string date, string boxNumber, string gtin, string dateNumber, string lotNumber, string VPC1, string VPC2)
        {

            string PTItag = "^XA  ^FX GTIN\n" +
                           "^FO0,15\n" +
                           "^BRN,11,3,1,25,10^FD01" + gtin + "13" + dateNumber + "10" + lotNumber + " ^FS\n" +

                           "^CFE,20\n" +
                           "^FO20,100^FD(01)" + gtin + "(13)" + dateNumber + "(10)" + lotNumber + " ^FS\n" +
                           "^FX SEGUNDA LINEA\n" +

                           "^FX CODEBOX QR\n" +
                           "^FO710,125\n" +
                           "^BQN,2,4^FDQA," + boxNumber + "^FS\n" +


                           "^FX VARIETY, PRESENTATION, DISTRIBUTOR\n" +
                           "^CFE,40\n" +
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
                           "^FO530,230^FDJulian^FS\n" +
                           "^FO530,270^FDDate^FS\n" +
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



            string PTItag = "^XA  ^FX GTIN\n" +
                           "^FO0,15\n" +
                           "^BRN,11,3,1,25,10^FD01" + gtin + "13" + dateNumber + "10" + lotNumber + " ^FS\n" +

                           "^CFE,20\n" +
                           "^FO20,100^FD(01)" + gtin + "(13)" + dateNumber + "(10)" + lotNumber + " ^FS\n" +
                           "^FX SEGUNDA LINEA\n" +

                           "^FX VARIETY, PRESENTATION, DISTRIBUTOR\n" +
                           "^CFE,40\n" +
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
                           "^FO530,230^FDJulian^FS\n" +
                           "^FO530,270^FDDate^FS\n" +
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

        public string PtiUpcQRQty(string variety, string distributor, string presentation, string weight, string adress1, string adress2, string date, string boxNumber, string gtin, string dateNumber, string lotNumber, string UPC, string VPC1, string VPC2, int QtyBoxes)
        {
            string superPTItag = "";

            for (int i = 0; i < QtyBoxes; i++)
            {
                int boxNumberInt = Convert.ToInt32(boxNumber) + i;

                string PTItag = "^XA  ^FX GTIN\n" +
                               "^FO0,15\n" +
                               "^BRN,11,3,1,25,10^FD01" + gtin + "13" + dateNumber + "10" + lotNumber + " ^FS\n" +

                               "^CFE,20\n" +
                               "^FO20,100^FD(01)" + gtin + "(13)" + dateNumber + "(10)" + lotNumber + " ^FS\n" +
                               "^FX SEGUNDA LINEA\n" +


                               "^FX VARIETY, PRESENTATION, DISTRIBUTOR\n" +
                               "^CFE,40\n" +
                               "^FO20,150^FD" + variety + "^FS\n" +
                               "^CFE,35\n" +
                               "^FO20,220^FD" + weight + " Lbs" + presentation + " ^FS\n" +
                               "^FO20,260^FDProduct of Mexico^FS\n" +
                               "^FO20,300^FD" + distributor + "^FS\n" +
                               "^CFF,25\n" +
                               "^FO20,340^FD" + adress1 + "^FS\n" +
                               "^FO20,370^FD" + adress2 + "^FS\n" +

                               "^FX UPC CODE\n" +
                               "^FO380,320^BY2^BUN,60,Y,N,Y^FD" + UPC + "^FS\n" +


                               "^FX PACK DATE, VOICE PICK CODE\n" +
                               "^CFE,35\n" +
                               "^FO530,230^FDPack^FS\n" +
                               "^FO530,270^FDDate^FS\n" +
                               "^CFL,40\n" +
                               "^FO625,250^FD" + date + "^FS\n" +
                               "^FO625,225^FR^GB170,80,40^FS\n" +
                               "^CFE,45\n" +
                               "^FO630,360^FD" + VPC1 + "^FS\n" +
                               "^CFE,65\n" +
                               "^FO715,345^FD" + VPC2 + "^FS\n" +
                               "^FO625,325^FR^GB170,80,40^FS\n" +

                               "^FX CODEBOX QR\n" +
                               "^FO710,125\n" +
                               "^BQN,2,4^FDQA," + boxNumberInt.ToString() + "^FS\n" +

                               "^XZ";

                superPTItag = superPTItag + PTItag;
            }

            return superPTItag;
        }
    
    }
}
