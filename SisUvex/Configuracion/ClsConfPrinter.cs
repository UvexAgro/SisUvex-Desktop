using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SisUvex.Configuracion
{
    internal class ClsConfPrinter
    {

        public static string PrinDocuments { get; set; }
        public static string PrintTags { get; set; }
        public static string PrintPallet { get; set; }
        public static string PrintCode { get; set; }

        private string path = ClsXmlPrinter.path;


        public ClsConfPrinter()
        {
        }

        //Leer el archivo XML, si no existe manda un mensaje con esa advertencia.
        public void Leer()
        {

            if(File.Exists(path))
            {
                XDocument doc = XDocument.Load(path);
                var configuracion = doc.Element("Print_setup");

                PrinDocuments = configuracion.Element("prinDocuments").Value;
                PrintTags = configuracion.Element("printTags").Value;
                PrintPallet = configuracion.Element("printPallet").Value;
                PrintCode = configuracion.Element("printCode").Value;
            }
            else
            {

                MessageBox.Show("No hay impresoras condiguradas", "[Print Config]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }   
        }

        //Guardar la configuración de las impresoras en el archivo XML

        public void Guardar()
        {
            var doc = new XDocument(
                new XElement("Print_setup",
                    new XElement("prinDocuments", PrinDocuments),
                    new XElement("printTags", PrintTags),
                    new XElement("printPallet", PrintPallet),
                    new XElement("printCode", PrintCode)
                )
            );

            //string directoryPath = Path.GetDirectoryName(path2);
            //Directory.CreateDirectory(directoryPath);
            //MessageBox.Show("Configuracion guardada en: " + path2+"\nel directory es: "+directoryPath+"\nEl path1 es:"+path1);
            doc.Save(path);
        }
        public static string GetPrinterOrientation(string printerName)
        {
            // Obtiene la configuración de la impresora
            var printerSettings = new System.Drawing.Printing.PrinterSettings();
            printerSettings.PrinterName = printerName;

            // Obtiene la orientación de la página predeterminada
            var pageSettings = new System.Drawing.Printing.PageSettings();
            pageSettings.PrinterSettings = printerSettings;
            var orientation = pageSettings.Landscape ? "Horizontal" : "Vertical";

            return orientation;
        }
    }
}
