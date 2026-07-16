using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisUvex.Reports
{
    internal class palletTag
    {

        string PalletString, palletNumber, variety, distributor, weight, presentation, date, lot, qty;

        public string PrintPalletString (string palletNumber, string variety, string distributor, string weight, string presentation, string date, string lot, string qty)
        {

            string PalletString = "^XA ^PW812\n" +
                "^FX BARCODE AND PALLET NUMBER\n" +
                "^BY5,2,90\n" +
                "^FO181,40^BC^FD"+palletNumber+"^FS\n" +

                "^FX BIG INFO SECTION.\n" +
                "^CFE,60\n" +
                "^FO50,250^FD"+variety+"^FS\n" +
                "^CFE,60\n" +
                "^FO50,350^FD"+ distributor + "^FS\n" +
                "^CFE,50\n" +
                "^FO50,450^FD"+weight+" "+ presentation + "^FS\n" +
                "^FO50,530^FD"+date+"^FS\n" +
                "^FO50,610^FD"+lot+"^FS\n" +
                "^FO500,610^FDQTY: "+qty+"^FS\n" +
                "^FO50,690^GB700,3,3^FS\n" +

                "^FX CUADRICULA DE STICKERS.\n" +
                "^FO117,768^GB611,183,3^FS\n" +
                "^FO117,768^GB611,359,3^FS\n" +
                "^FO420,768^GB3,359,3^FS\n" +

                "^FX TEXTO EN CUADRICULA\n" +
                "^FX 1rst Box\n" +
                "^BY3,3,10\n" +
                "^FO130,785^BCN,35,Y,N,N,A^FD"+palletNumber+"^FS\n" +
                "^CF0,25\n" +
                "^FO130,852^FD"+variety+"^FS\n" +
                "^FO130,877^FD"+ presentation + "^FS\n" +
                "^CF0,15\n" +
                "^FO130,902^FD"+weight+" "+ distributor + "^FS\n" +
                "^FO130,917^FD"+date+"^FS\n" +
                "^FO280,917^FDQTY: "+qty+"^FS\n" +
                "^FO350,917^FD"+lot+"^FS\n" +

                "^FX 2nd Box\n" +
                "^BY3,3,10\n" +
                "^FO435,785^BC,35,Y,N,N,A^FD"+palletNumber+"^FS\n" +
                "^CF0,25\n" +
                "^FO435,852^FD"+variety+"^FS\n" +
                "^FO435,877^FD"+presentation +"^FS\n" +
                "^CF0,15\n" +
                "^FO435,902^FD"+weight+" "+distributor +"^FS\n" +
                "^FO435,917^FD"+date+"^FS\n" +
                "^FO585,917^FDQTY: "+qty+"^FS\n" +
                "^FO655,917^FD"+lot+"^FS\n" +


                "^FX 3rd Box\n" +
                "^BY3,3,10\n" +
                "^FO130,960^BC,35,Y,N,N,A^FD"+palletNumber+"^FS\n" +
                "^CF0,25\n" +
                "^FO130,1027^FD"+variety+"^FS\n" +
                "^FO130,1052^FD"+presentation +"^FS\n" +
                "^CF0,15\n" +
                "^FO130,1077^FD"+weight+" "+distributor +"^FS\n" +
                "^FO130,1092^FD"+date+"^FS\n" +
                "^FO280,1092^FDQTY: "+qty+"^FS\n" +
                "^FO350,1092^FD"+lot+"^FS\n" +

                "^FX 4rd Box\n" +
                "^BY3,3,10\n" +
                "^FO435,960^BC,35,Y,N,N,A^FD"+palletNumber+"^FS\n" +
                "^CF0,25\n" +
                "^FO435,1027^FD"+variety+"^FS\n" +
                "^FO435,1052^FD"+presentation +"^FS\n" +
                "^CF0,15\n" +
                "^FO435,1077^FD"+weight+" "+distributor +"^FS\n" +
                "^FO435,1092^FD"+date+"^FS\n" +
                "^FO580,1092^FDQTY: "+qty+"^FS\n" +
                "^FO655,1092^FD"+lot+"^FS\n" +
                "^XZ";

            return PalletString;
        }
    }
}
