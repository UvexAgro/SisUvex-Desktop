using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using System.Security.Cryptography;
namespace SisUvex.Configuracion
{
    internal class ClsXmlCreate
    {
        //public static string  dataDirectory = AppContext.BaseDirectory;
        public static string dataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static string xmlFilePath = Path.Combine(dataDirectory, "configuracion.xml");

        public static void CreateXml()
        {
            if (!File.Exists(xmlFilePath))
            {
                // Crear un nuevo archivo XML con la plantilla predefinida
                XDocument doc = new XDocument(
                    new XElement("Configuracion",
                        new XElement("Elemento1", "Valor1"),
                        new XElement("Elemento2", "Valor2")
                    )
                );

                // Guardar el archivo XML en la ruta de instalación de la aplicación
                doc.Save(xmlFilePath);
            }
        }

        public static void PruebaCreateXml()
        {
            if (!File.Exists(xmlFilePath))
            {
                // Crear un nuevo archivo XML con un solo elemento y texto personalizado
                XDocument doc = new XDocument(
                    new XElement("Configuracion",
                        new XElement("Texto", "PRUEBA DE SOLO TEXTO")
                    )
                );

                // Guardar el archivo XML en la ruta de instalación de la aplicación
                doc.Save(xmlFilePath);
            }
        }
    }
}
