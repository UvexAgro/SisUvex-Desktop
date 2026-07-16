using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Archivo.Etiquetas
{
    public partial class PruebasEtiquetasTextoZPL : Form
    {
        public PruebasEtiquetasTextoZPL()
        {
            InitializeComponent();
        }

        private void PruebasEtiquetasTextoZPL_Load(object sender, EventArgs e)
        {
            LoadPrinterInCmbx();
            if (cboPrinters.Items.Count > 0)
                cboPrinters.SelectedIndex = 0;
        }

        private void LoadPrinterInCmbx()
        {
            cboPrinters.Items.Clear();

            foreach (string printers in PrinterSettings.InstalledPrinters)
            {
                cboPrinters.Items.Add(printers);
            }

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (cboPrinters.SelectedIndex > 0)
                MessageBox.Show("ERROR CBO SELECTEDINDEX");
            else
                PrintZPL(txbZPLText.Text, cboPrinters.Text);
        }


        private void PrintZPL(string superPrint, string printer)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrinterSettings = new PrinterSettings();
            pd.PrinterSettings.Copies = 2;
            pd.PrinterSettings.PrinterName = printer;

            if (!string.IsNullOrEmpty(printer))
                RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, superPrint);
            else
                MessageBox.Show("Seleccione una impresora válida", "Impresora");


        }
    }
}
