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
using ZXing;
using ZXing.Common;
using ZXing.Windows.Compatibility;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Globalization;
//using OfficeOpenXml.FormulaParsing.LexicalAnalysis;

namespace SisUvex.Reports
{
    public partial class PrintPalletBox : Form
    {
        PrintDocument printDocument = new PrintDocument();
        


        string print, superPrint;

        int jlDate;

        JulianCalendar julian = new JulianCalendar();

        public PrintPalletBox()
        {
            print = "";
            InitializeComponent();

            CargarImpresoras();

        }

        private void button1_Click(object sender, EventArgs e)
        {


            //txbDateBlack.Text = Convert.ToString(julian.GetDayOfYear(DateTime.Now));

            PTITag pti = new PTITag();

            if (txbUPC.Text.Length > 0 && txtBoxNumber.Text.Length == 0)
            {
                print = pti.PtiUpc(txbVariety.Text, txbDistributor.Text, txbPresentation.Text, txbWeight.Text, txbAddress1.Text, txbAddress2.Text, txbDateBlack.Text, txbGtin.Text, txbDateNumber.Text, txbLoteNumber.Text, txbUPC.Text, txbVPC1.Text, txbVPC2.Text);
            }
            else
            {
                print = pti.Pti(txbVariety.Text, txbDistributor.Text, txbPresentation.Text, txbWeight.Text, txbAddress1.Text, txbAddress2.Text, txbDateBlack.Text, txbGtin.Text, txbDateNumber.Text, txbLoteNumber.Text, txbVPC1.Text, txbVPC2.Text);
            }


            PrintDialog pd = new PrintDialog();
            pd.PrinterSettings = new PrinterSettings();


            try
            {
                if (DialogResult.OK == pd.ShowDialog(this))
                {
                    for (int i = 0; i < pd.PrinterSettings.Copies; i++)
                    {
                        superPrint = superPrint + print;
                    }

                    if (cbxPrint.Text.Length > 0)
                    {
                        RawPrinterHelper.SendStringToPrinter(cbxPrint.Text, superPrint);
                    }
                    else
                    {
                        MessageBox.Show("Seleccione una impresora válida", "Impresora");
                    }
                    superPrint = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        public double ToJulianDate()
        {
            double julianDate;

            DateTime dt = DateTime.Now;

            julianDate = dt.ToOADate() + 2415018.5;

            return julianDate;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            palletTag pallet = new palletTag();

            print = pallet.PrintPalletString(txtNoPallet.Text, txbVariety.Text, txbDistributor.Text, txbWeight.Text, txbPresentation.Text, txbDateBlack.Text, txbLoteNumber.Text, txbQty.Text);

            // Allow the user to select a printer.
            PrintDialog pd = new PrintDialog();
            pd.PrinterSettings = new PrinterSettings();
            if (DialogResult.OK == pd.ShowDialog(this))
            {
                // Send a printer-specific to the printer.
                RawPrinterHelper.SendStringToPrinter(cbxPrint.Text, print);
            }
        }

        private void PrintPalletBox_Load(object sender, EventArgs e)
        {

        }

        private void CargarImpresoras()
        {
            cbxPrint.Items.Clear();

            foreach (string printers in PrinterSettings.InstalledPrinters)
            {
                cbxPrint.Items.Add(printers);
            }

            cbxPrint.Text = printDocument.PrinterSettings.PrinterName;
        }

        private void cbxPrint_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
