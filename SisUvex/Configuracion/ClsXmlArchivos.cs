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
                        GrupoVacio("servidor1"),
                        GrupoVacio("servidor2"),
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

        private static XElement GrupoVacio(string nombre)
        {
            return new XElement(nombre,
                new XElement("server", ""),
                new XElement("dbConn", ""),
                new XElement("userConn", ""),
                new XElement("passConn", ""),
                new XElement("dbWrite", ""),
                new XElement("userWrite", ""),
                new XElement("passWrite", ""),
                new XElement("dbEmployees", "")
            );
        }
    }
}
