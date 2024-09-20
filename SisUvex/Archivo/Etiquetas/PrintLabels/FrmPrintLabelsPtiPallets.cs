using SisUvex.Configuracion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Archivo.Etiquetas.PrintLabels
{
    internal partial class FrmPrintLabelsPtiPallets : Form
    {
        ClsConfPrinter confPrinter = new ClsConfPrinter();

        ClsPrintLabelsPtiPallets cls;
        ClsPrintPtiTag print;
        public FrmPrintLabelsPtiPallets(ClsPrintLabelsPtiPallets cls)
        {
            InitializeComponent();
            this.cls = cls;
        }

        private void FrmPrintLabelsPtiPallets_Load(object sender, EventArgs e)
        {
            cls.LoadFormPrintLabels();

            confPrinter.Leer();
        }

        private void btnPrintPtiTag_Click(object sender, EventArgs e)
        {
            cls.BtnPrintPtiTag();
        }

        private void btnPrintPalletTag_Click(object sender, EventArgs e)
        {
            cls.BtnPrintPalletTag();
        }

        private void btnLastPallets_Click(object sender, EventArgs e)
        {
            cls.LoadDgvLastPallets();
            //MessageBox.Show(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            //string STRINGPRINT = "^XA\r\n^FX GTIN\r\n^FX GTIN BARCODE\r\n^FO0,15\r\n^BRN,11,3,1,25,10^FD011084043715002513240530102230C01^FS\r\n^CFF,30,10\r\n^FX GTIN HUMAN READABLE\r\n^FO100,95^FD(01)10840437150025(13)240530(10)2230C01^FS\r\n\r\n^FX DISTRIBUTOR\r\n^CFF,30,10\r\n^FO25,300^FDDayka & Hackett LLC^FS\r\n^CFF,30,10\r\n^FO23,335^FD42874 Road 64^FS\r\n^FO23,365^FDReedley, CA 93654^FS\r\n\r\n^FX VARIETY, PRESENTATION, DISTRIBUTOR\r\n^CFF,60,10\r\n^FO25,130^FDTable Grapes 99 IFG TRHEE SWEET CELEBTRATION TM^FS\r\n^CFF,60,10\r\n^FO25,190^FDCT-BAG#18 F&D SO2 6X3 SUGRAONE SSSSSSSSSSSS^FS\r\n^CFF,30,10\r\n^FO25,255^FDProduce of Mexico^FS\r\n\r\n^FX PACK DATE, VOICE PICK CODE\r\n^CFF,30,10\r\n^FO570,245^FDPack^FS\r\n^FO570,275^FDDate^FS\r\n^CFD,37\r\n^FO650,255^FDmay.^FS\r\n^FO745,255^FD30^FS\r\n^FO640,235^FR^GB160,70,50^FS\r\n^CFE,40,30\r\n^FO645,355^FD25^FS\r\n^CFE,50,30\r\n^FO720,335^FD29^FS\r\n^FO640,325^FR^GB160,70,50^FS\r\n^XZ";
            //RawPrinterHelper.SendStringToPrinter(ClsConfPrinter.PrintPallet, STRINGPRINT);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cls.ReprintSelectedPallet();
        }
    }
}