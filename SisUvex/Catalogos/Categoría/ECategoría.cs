using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisUvex.Catalogos.Categoría
{
    internal class ECategoría
    {
        private string idCategoría;
        private string nombreCategoría;
        public string IdCategoría
        {
            get { return idCategoría; }
            set { idCategoría = value; }
        }
        public string NombreCategoría
        {
            get { return nombreCategoría; }
            set { nombreCategoría = value; }
        }
    }
}