using iText.StyledXmlParser.Node;
using SisUvex.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SisUvex.Archivo.Reestibado
{
    internal class ClsReestibado : ClsCatalogos
    {
        SQLControl sql = new SQLControl();
        public bool EnManifiesto(string idMan, string idPal)
        {
            bool EnMan = false;
            if (idMan.Length > 0)
            {
                DialogResult result = MessageBox.Show($"El pallet: {idPal} está en el manifiesto {idMan} ¿Desea reestibarlo aún así?", "Reestibar pallet", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                {
                    EnMan = true;

                }
                else
                {

                }
            }
            return EnMan;
        }

        
    }
}
