using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisUvex.Archivo.Etiquetas.LabelInterface
{
    interface IPallet
    {
        public string PalletCode { get; set; }
        public string DateShortUS { get; set; }
        public string Crop { get; set; }
        public string Variety { get; set; }
        public string Presentation { get; set; }
        public string Pounds { get; set; }
        public string Distributor { get; set; }
        public string quantityBoxes { get; set; }
    }
}
