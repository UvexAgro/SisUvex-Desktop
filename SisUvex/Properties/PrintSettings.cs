using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisUvex.Properties
{
    internal class PrintSettings
    {
        StreamReader leer;
        List<string> lista = new List<string>();
        string[] separador = { Environment.NewLine, "=" };
        public string cadenaTexto, printDocuments, printTags, printPallet, printCode;
        public void ReadSvr(string printerOpt, string printerSelect)
        {
            try
            {
                leer = File.OpenText("C:\\Program Files\\SisUvex\\config.txt");
                cadenaTexto = leer.ReadToEnd();
                lista = cadenaTexto.Split(separador, StringSplitOptions.RemoveEmptyEntries).ToList();

                for (int i = 0; i < lista.Count - 1; i++)
                {
                    Console.WriteLine(lista[i]);
                    switch (lista[i].Trim())
                    {
                        case "printDocuments": printDocuments = lista[i + 1]; break;
                        case "printTags": printTags = lista[i + 1]; break;
                        case "printPallet": printPallet = lista[i + 1]; break;
                        case "printCode": printCode = lista[i + 1]; break;
                        default:; break;
                    }
                }

            }
            catch (Exception e)

            {
                MessageBox.Show(e.Message, "[Error : Cadena de conexión]");
            }

        }
    }
}
