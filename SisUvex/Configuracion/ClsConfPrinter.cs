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

        public ClsConfPrinter()
        {
        }

        public void Leer()
        {
            PrinDocuments = GetPrinterDocumentsName();
            PrintTags = GetPrinterPtiName();
            PrintPallet = GetPrinterPalletName();
            PrintCode = GetPrinterCodeName();
        }

        public void Guardar()
        {
            Properties.Settings.Default.PrinterDocuments = PrinDocuments;
            Properties.Settings.Default.PrinterPti = PrintTags;
            Properties.Settings.Default.PrinterPallet = PrintPallet;
            Properties.Settings.Default.PrinterCode = PrintCode;
            Properties.Settings.Default.Save();
        }

        public static bool ValidatePrinterName(string? printerName)
        {
            if (string.IsNullOrEmpty(printerName))
            {
                return false;
            }

            // Verifica si la impresora está instalada
            foreach (string installedPrinter in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                if (installedPrinter.Equals(printerName, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        public static void SetPrinterDocumentsName(string? printerName)
        {
            if (!ValidatePrinterName(printerName))
                printerName = string.Empty;

            Properties.Settings.Default.PrinterDocuments = printerName ;
            Properties.Settings.Default.Save();
        }

        public static void SetPrinterPtiName(string? printerName)
        {
            if (!ValidatePrinterName(printerName))
                printerName = string.Empty;
            Properties.Settings.Default.PrinterPti = printerName;
            Properties.Settings.Default.Save();
        }

        public static void SetPrinterPalletName(string? printerName)
        {
            if (!ValidatePrinterName(printerName))
                printerName = string.Empty;
            Properties.Settings.Default.PrinterPallet = printerName;
            Properties.Settings.Default.Save();
        }

        public static void SetPrinterCodeName(string? printerName)
        {
            if (!ValidatePrinterName(printerName))
                printerName = string.Empty;
            Properties.Settings.Default.PrinterCode = printerName;
            Properties.Settings.Default.Save();
        }

        public static string GetPrinterDocumentsName()
        {
            return Properties.Settings.Default.PrinterDocuments;
        }

        public static string GetPrinterPtiName()
        {
            return Properties.Settings.Default.PrinterPti;
        }

        public static string GetPrinterPalletName()
        {
            return Properties.Settings.Default.PrinterPallet;
        }

        public static string GetPrinterCodeName()
        {
            return Properties.Settings.Default.PrinterCode;
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
