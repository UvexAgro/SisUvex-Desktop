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
        public FrmPrintLabelsPtiPallets()
        {
            InitializeComponent();
        }

        private void FrmPrintLabelsPtiPallets_Load(object sender, EventArgs e)
        {
            cls ??= new();
            cls.frm = this;

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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cls.ReprintSelectedPallet();
        }
    }
}