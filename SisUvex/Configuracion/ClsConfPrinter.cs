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

        // ── Almacenamiento persistente entre actualizaciones ──────────────────
        // Archivo fijo en AppData\Roaming\SisUvex\ — no depende de la versión.
        private static readonly string AppDataFolder =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SisUvex");
        private static readonly string PrintersConfigFile =
            Path.Combine(AppDataFolder, "printers_config.txt");

        private const string KeyDocuments = "PrinterDocuments";
        private const string KeyPti       = "PrinterPti";
        private const string KeyPallet    = "PrinterPallet";
        private const string KeyCode      = "PrinterCode";
        // ─────────────────────────────────────────────────────────────────────

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
            SetPrinterDocumentsName(PrinDocuments);
            SetPrinterPtiName(PrintTags);
            SetPrinterPalletName(PrintPallet);
            SetPrinterCodeName(PrintCode);
        }

        // ── Helpers de archivo persistente ────────────────────────────────────

        /// <summary>
        /// Lee el archivo printers_config.txt y devuelve un diccionario clave=valor.
        /// Si no existe, intenta migrar los valores desde Properties.Settings.
        /// </summary>
        private static Dictionary<string, string> LoadConfig()
        {
            var config = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                [KeyDocuments] = string.Empty,
                [KeyPti]       = string.Empty,
                [KeyPallet]    = string.Empty,
                [KeyCode]      = string.Empty,
            };

            if (File.Exists(PrintersConfigFile))
            {
                foreach (string line in File.ReadAllLines(PrintersConfigFile))
                {
                    int sep = line.IndexOf('=');
                    if (sep > 0)
                    {
                        string key   = line[..sep].Trim();
                        string value = line[(sep + 1)..].Trim();
                        if (config.ContainsKey(key))
                            config[key] = value;
                    }
                }
            }
            else
            {
                // Primera vez: migrar desde Properties.Settings
                config[KeyDocuments] = Properties.Settings.Default.PrinterDocuments ?? string.Empty;
                config[KeyPti]       = Properties.Settings.Default.PrinterPti       ?? string.Empty;
                config[KeyPallet]    = Properties.Settings.Default.PrinterPallet     ?? string.Empty;
                config[KeyCode]      = Properties.Settings.Default.PrinterCode       ?? string.Empty;
                SaveConfig(config);
            }

            return config;
        }

        private static void SaveConfig(Dictionary<string, string> config)
        {
            try
            {
                Directory.CreateDirectory(AppDataFolder);
                File.WriteAllLines(PrintersConfigFile,
                    config.Select(kv => $"{kv.Key}={kv.Value}"));
            }
            catch { }

            // Mantener Properties.Settings sincronizado (compatibilidad)
            try
            {
                Properties.Settings.Default.PrinterDocuments = config[KeyDocuments];
                Properties.Settings.Default.PrinterPti       = config[KeyPti];
                Properties.Settings.Default.PrinterPallet    = config[KeyPallet];
                Properties.Settings.Default.PrinterCode      = config[KeyCode];
                Properties.Settings.Default.Save();
            }
            catch { }
        }

        private static string ReadValue(string key)
        {
            var config = LoadConfig();
            return config.TryGetValue(key, out string? val) ? val : string.Empty;
        }

        private static void WriteValue(string key, string value)
        {
            var config = LoadConfig();
            config[key] = value;
            SaveConfig(config);
        }

        // ─────────────────────────────────────────────────────────────────────

        public static bool ValidatePrinterName(string? printerName)
        {
            if (string.IsNullOrEmpty(printerName))
                return false;

            foreach (string installedPrinter in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                if (installedPrinter.Equals(printerName, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }

        public static void SetPrinterDocumentsName(string? printerName)
        {
            if (!ValidatePrinterName(printerName)) printerName = string.Empty;
            WriteValue(KeyDocuments, printerName!);
        }

        public static void SetPrinterPtiName(string? printerName)
        {
            if (!ValidatePrinterName(printerName)) printerName = string.Empty;
            WriteValue(KeyPti, printerName!);
        }

        public static void SetPrinterPalletName(string? printerName)
        {
            if (!ValidatePrinterName(printerName)) printerName = string.Empty;
            WriteValue(KeyPallet, printerName!);
        }

        public static void SetPrinterCodeName(string? printerName)
        {
            if (!ValidatePrinterName(printerName)) printerName = string.Empty;
            WriteValue(KeyCode, printerName!);
        }

        public static string GetPrinterDocumentsName()
        {
            string name = ReadValue(KeyDocuments);
            return ValidatePrinterName(name) ? name : string.Empty;
        }

        public static string GetPrinterPtiName()
        {
            string name = ReadValue(KeyPti);
            return ValidatePrinterName(name) ? name : string.Empty;
        }

        public static string GetPrinterPalletName()
        {
            string name = ReadValue(KeyPallet);
            return ValidatePrinterName(name) ? name : string.Empty;
        }

        public static string GetPrinterCodeName()
        {
            string name = ReadValue(KeyCode);
            return ValidatePrinterName(name) ? name : string.Empty;
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
