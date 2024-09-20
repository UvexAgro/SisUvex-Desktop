using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisUvex.Configuracion
{
    public class ClsXmlPrinter
    {
        //Definicion de la ruta del archivo XML
        public static string dataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static string path = Path.Combine(dataDirectory, "configprinters.xml");


        //Creación del archivo XML para impresoras
        public void CreateXmlConfPrinter()
        {
            if (!File.Exists(path))
            {        
                string basicSetupXML = "<Print setup>\r\n\t<prinDocuments></prinDocuments>\r\n\t<printTags></printTags>\r\n\t<printPallet></printPallet>\r\n\t<printCode></printCode>\r\n\t<Print setup>\r\n";

                File.WriteAllText(path, basicSetupXML);


            }

        }
    }

}
