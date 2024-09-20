using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisUvex.Archivo.Etiquetas.LabelInterface
{
    internal class LabelZebra
    {
        public string labelsZPLString { get; set; }
        public int quantity { get; set; }

        public LabelZebra()
        {
            labelsZPLString = "";
            quantity = 1;
        }


        public virtual string SuperPrint()
        {
            return labelsZPLString;
        }
    }
}
