using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisUvex.Archivo.Etiquetas.LabelInterface
{
    internal interface IPti
    {
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
        public string Upc { get; set; }



    }
}
