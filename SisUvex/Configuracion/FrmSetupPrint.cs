using DocumentFormat.OpenXml.Drawing.Diagrams;
using DocumentFormat.OpenXml.Vml;
using OfficeOpenXml.FormulaParsing.LexicalAnalysis;
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

        ClsConfPrinter confPrint = new ClsConfPrinter();
        public FrmSetupPrint()
        {
            InitializeComponent();
            LoadPrinterInCmbx();
        }

        private void FrmSetupPrinterPallet_Load(object sender, EventArgs e)
        {

        }

        private void LoadPrinterInCmbx()
        {
            cmBxSetupPrintPallet.Items.Clear();
            cmBxSetupPrintPTI.Items.Clear();
            cmBxSetupPrintDoc.Items.Clear();
            cmBxSetupPrintCode.Items.Clear();

            foreach (string printers in PrinterSettings.InstalledPrinters)
            {
                cmBxSetupPrintPallet.Items.Add(printers);
                cmBxSetupPrintDoc.Items.Add(printers);
                cmBxSetupPrintPTI.Items.Add(printers);
                cmBxSetupPrintCode.Items.Add(printers);
            }

        }

        private void btnSetupPrintPTI_Click(object sender, EventArgs e)
        {
            ReadPrinters();

            if (cmBxSetupPrintCode.Text == "")
            {
                cmBxSetupPrintCode.Text = lblCode.Text;
            }

            if (cmBxSetupPrintDoc.Text == "")
            {
                cmBxSetupPrintDoc.Text = lblDoc.Text;
            }

            if (cmBxSetupPrintPallet.Text == "")
            {
                cmBxSetupPrintPallet.Text = lblPallet.Text;
            }

            if (cmBxSetupPrintPTI.Text == "")
            {
                cmBxSetupPrintPTI.Text = lblPTI.Text;
            }

            ClsConfPrinter.PrinDocuments = cmBxSetupPrintDoc.Text;
            ClsConfPrinter.PrintTags = cmBxSetupPrintPTI.Text;
            ClsConfPrinter.PrintPallet = cmBxSetupPrintPallet.Text;
            ClsConfPrinter.PrintCode = cmBxSetupPrintCode.Text;

            confPrint.Guardar();
            ClsXmlPrinter xmlCreate = new ClsXmlPrinter();
            xmlCreate.CreateXmlConfPrinter();

            MessageBox.Show("Configuración guardada", "[Configuración]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ReadPrinters();
        }

        public void ReadPrinters()       
        {
            confPrint.Leer();
            lblPallet.Text = ClsConfPrinter.PrintPallet;
            lblPTI.Text = ClsConfPrinter.PrintTags;
            lblCode.Text = ClsConfPrinter.PrintCode;
            lblDoc.Text = ClsConfPrinter.PrinDocuments;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReadPrinters();
        }

        private void cmBxSetupPrintPallet_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }

}

