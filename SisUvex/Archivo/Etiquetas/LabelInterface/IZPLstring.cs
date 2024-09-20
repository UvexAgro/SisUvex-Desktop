using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisUvex.Archivo.Etiquetas.LabelInterface
{
    internal interface IZPLstring
    {
        public void CreatePtiZplString(string Gtin, string Lote, string WorkGroup, string DateShortUS, string Crop, string Variety, string Presentation, string Pounds, string Size, string Distributor, string AddresDistributor1, string AddresDistributor2, string DateMonthDay, string VoicePickCode);
    }
}
