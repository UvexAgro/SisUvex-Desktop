using DocumentFormat.OpenXml.Drawing.Diagrams;
using DocumentFormat.OpenXml.Vml;
//using OfficeOpenXml.FormulaParsing.LexicalAnalysis;
using SisUvex.Catalogos.Metods.ComboBoxes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Configuracion
{
    public partial class FrmSetupPrint : Form
    {
        private const string _noPrinter = "Sin impresora";
        ClsConfPrinter confPrint = new ClsConfPrinter();
        public FrmSetupPrint()
        {
            InitializeComponent();
        }

        private void FrmSetupPrinterPallet_Load(object sender, EventArgs e)
        {
            LoadPrintersInCbos();
            ReadPrinters();
        }

        private void LoadPrintersInCbos()
        {
            cboPrinterPallet.Items.Clear();
            cboPrinterPTI.Items.Clear();
            cboPrinterDoc.Items.Clear();
            cboPrinterCode.Items.Clear();

            foreach (string printers in PrinterSettings.InstalledPrinters)
            {
                cboPrinterPallet.Items.Add(printers);
                cboPrinterDoc.Items.Add(printers);
                cboPrinterPTI.Items.Add(printers);
                cboPrinterCode.Items.Add(printers);
            }
        }

        private void ValidateLabelPrinterName(Label lblPrinterName, string printerName)
        {
            if (ClsConfPrinter.ValidatePrinterName(printerName)) //VALIDACION SOLO PARA CAMBIAR DE COLOR
            {
                lblPrinterName.Text = printerName;
                lblPrinterName.ForeColor = Color.Black;
            }
            else
            {
                lblPrinterName.Text = _noPrinter;
                lblPrinterName.ForeColor = Color.Red;
            }
        }

        private void btnSetupPrintPTI_Click(object sender, EventArgs e)
        {
            ClsConfPrinter.SetPrinterDocumentsName(cboPrinterDoc.Text);
            ClsConfPrinter.SetPrinterPtiName(cboPrinterPTI.Text);
            ClsConfPrinter.SetPrinterPalletName(cboPrinterPallet.Text);
            ClsConfPrinter.SetPrinterCodeName(cboPrinterCode.Text);

            MessageBox.Show("Configuración guardada", "[Configuración]", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadPrintersInCbos();
            ReadPrinters();
        }

        public void ReadPrinters()       
        {
            ValidateLabelPrinterName(lblDoc, ClsConfPrinter.GetPrinterDocumentsName());
            ValidateLabelPrinterName(lblPTI, ClsConfPrinter.GetPrinterPtiName());
            ValidateLabelPrinterName(lblPallet, ClsConfPrinter.GetPrinterPalletName());
            ValidateLabelPrinterName(lblCode, ClsConfPrinter.GetPrinterCodeName());

            SelectIndexWithPrinterName(cboPrinterPallet, lblPallet.Text);
            SelectIndexWithPrinterName(cboPrinterPTI, lblPTI.Text);
            SelectIndexWithPrinterName(cboPrinterCode, lblCode.Text);
            SelectIndexWithPrinterName(cboPrinterDoc, lblDoc.Text);
        }

        private void SelectIndexWithPrinterName(ComboBox cbo, string printerName)
        {
            int index = cbo.FindString(printerName);
            if (index != -1)
            {
                cbo.SelectedIndex = index;
            }
            else
            {
                cbo.SelectedIndex = -1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void cmBxSetupPrintPallet_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }

}

