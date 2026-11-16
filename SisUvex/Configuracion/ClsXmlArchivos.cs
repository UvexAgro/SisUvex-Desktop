using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace SisUvex.Configuracion
{
    public class ClsXmlArchivos
    {
        public static string dataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static string rutaConf = Path.Combine(dataDirectory, "configuracion.xml");
        public static string rutaTemp = Path.Combine(dataDirectory, "XmlConTemp.xml");
        private static string key = "b14ca5898a4e4133bbce2ea2315a1916";
        
        public void PutInConfFile()
        {
            EncryptXmlFile();
            DeleteXmlConTemp();
        }
        public void PutInTempFile()
        {
            CreateXmlConTemp();
            DecryptXmlFile();
        }
               
        private void CreateXmlConTemp()
        {
            if (!File.Exists(rutaTemp))
            {
                using (FileStream fileStream = File.Create(rutaTemp))
                {
                    // Realiza las operaciones necesarias en el archivo
                }
            }
        }
        public void DeleteXmlConTemp()
        {
            if (File.Exists(rutaTemp))
            {
                File.Delete(rutaTemp);
            }
        }
        private void EncryptXmlFile()
        {
            EncryptFile(rutaTemp, rutaConf);
        }
        private void DecryptXmlFile()
        {
            DecryptFile(rutaConf, rutaTemp);
        }
        private static void EncryptFile(string inputFile, string outputFile)
        {//input es el doc con el texto incriptado, output es el archivo al qye se va a llenar con los datos encriptados
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            using (Aes aes = Aes.Create())
            {
                aes.Key = keyBytes;
                byte[] iv = aes.IV;
                using (FileStream fsCrypt = new FileStream(outputFile, FileMode.Create))
                {
                    fsCrypt.Write(iv, 0, iv.Length);
                    using (CryptoStream cs = new CryptoStream(fsCrypt, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        using (FileStream fsIn = new FileStream(inputFile, FileMode.Open))
                        {
                            int data;
                            while ((data = fsIn.ReadByte()) != -1)
                                cs.WriteByte((byte)data);
                        }
                    }
                }
            }
        }

        public static void DecryptFile(string inputFile, string outputFile)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            using (Aes aes = Aes.Create())
            {
                aes.Key = keyBytes;
                byte[] iv = new byte[aes.BlockSize / 8];
                using (FileStream fsCrypt = new FileStream(inputFile, FileMode.Open))
                {
                    fsCrypt.Read(iv, 0, iv.Length);
                    using (CryptoStream cs = new CryptoStream(fsCrypt, aes.CreateDecryptor(keyBytes, iv), CryptoStreamMode.Read))
                    {
                        using (FileStream fsOut = new FileStream(outputFile, FileMode.Create))
                        {
                            int data;
                            while ((data = cs.ReadByte()) != -1)
                                fsOut.WriteByte((byte)data);
                        }
                    }
                }
            }
        }

        public static void CrearXmlInicio()
        {
            if (!File.Exists(rutaConf))
            {
                //1.- Crear xmlTemp
                XDocument doc = new XDocument(
                    new XElement("Configuracion",
                        new XElement("currentServer", "1"),
                        new XElement("servidores",
                            ClsConfig.GrupoXml("servidor", ClsConfig.NuevoServidor(1))
                        ),
                        new XElement("lastLogin", "")
                    )
                );
                doc.Save(rutaTemp);

                //2.- Crear xmlConf
                File.WriteAllText(rutaConf, "");
                EncryptFile(rutaTemp, rutaConf);

                //3.- Borrar xmlTemp
                File.Delete(rutaTemp);
            }
            
        }

        public const string ExtensionConfiguracion = ".xml";
        public const string NombreArchivoConfiguracion = "configuracion.xml";

        /// <summary>Copia el archivo de configuración (cifrado) al destino elegido por el usuario.</summary>
        public static void ExportarConfiguracion(string destino)
        {
            if (!File.Exists(rutaConf))
                throw new FileNotFoundException("No existe un archivo de configuración para exportar.");

            File.Copy(rutaConf, destino, true);
        }

        /// <summary>
        /// Verifica que el archivo sea una configuración válida de SisUvex (extensión, cifrado y estructura).
        /// Devuelve la cantidad de servidores que contiene.
        /// </summary>
        public static bool ValidarArchivoConfiguracion(string archivo, out int servidores, out string error)
        {
            servidores = 0;
            error = "";

            if (!string.Equals(Path.GetExtension(archivo), ExtensionConfiguracion, StringComparison.OrdinalIgnoreCase))
            {
                error = $"El archivo debe ser de tipo \"{ExtensionConfiguracion}\".";
                return false;
            }

            string temporal = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N") + ".tmp");
            try
            {
                DecryptFile(archivo, temporal);
                XDocument doc = XDocument.Load(temporal);
                XElement raiz = doc.Element("Configuracion");
                if (raiz == null)
                    throw new FormatException("Sin nodo Configuracion");

                XElement contenedor = raiz.Element("servidores");
                if (contenedor != null)
                    servidores = contenedor.Elements("servidor").Count();
                else if (raiz.Element("servidor1") != null || raiz.Element("servidor2") != null)
                    servidores = (raiz.Element("servidor1") != null ? 1 : 0) + (raiz.Element("servidor2") != null ? 1 : 0);
                else if (raiz.Element("server") != null && raiz.Element("dbConn") != null)
                    servidores = 1;

                if (servidores == 0)
                {
                    error = "El archivo no contiene ningún servidor configurado.";
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                error = "El archivo no es una configuración válida de SisUvex.";
                return false;
            }
            finally
            {
                try { if (File.Exists(temporal)) File.Delete(temporal); } catch (Exception) { }
            }
        }

        /// <summary>Guarda el archivo importado con el nombre y en la carpeta que corresponden (respaldando el actual).</summary>
        public static void ImportarConfiguracion(string archivo)
        {
            if (File.Exists(rutaConf))
                File.Copy(rutaConf, rutaConf + ".antes-importar.bak", true);

            File.Copy(archivo, rutaConf, true);
            DeleteTemporal();
        }

        private static void DeleteTemporal()
        {
            if (File.Exists(rutaTemp))
                File.Delete(rutaTemp);
        }
    }
}