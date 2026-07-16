using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisUvex.Archivo.Etiquetas.LabelInterface
{
    internal class LabelEmployeeCode : LabelZebra
    {
        public string codeEmployee { get; set; }

        public LabelEmployeeCode()
        {
            codeEmployee = "";
        }



    }
}
