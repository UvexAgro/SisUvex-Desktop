using Microsoft.ReportingServices.ReportProcessing.OnDemandReportObjectModel;
using NPOI.SS.Formula.Functions;
using SisUvex.Archivo.Etiquetas.LabelInterface;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Configuracion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SisUvex.Catalogos.Metods.ClsObject;

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

            //ClsComboBoxes.CboSelectIndexWithTextInValueMember(cboWorkGroup, "0029");
            //tpWorkDay.Value = new DateTime(2026, 4, 22);

            txbIdPtiChange.Visible = User.HasSysAdminPermission();
            btnZplPtiCopy.Visible = User.HasSysAdminPermission();
            btnZplPalletCopy.Visible = User.HasSysAdminPermission();
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

        private void btnZplPalletCopy_Click(object sender, EventArgs e)
        {//Toma los valores mínimos para imprimir sin crear el pallet, cls.BtnPrintPalletTag();, solo que en lugar de imprimir, copia el ZPL al portapapeles
         //Para mostrár un idPallet se puso "X00001" para que no se pueda leer en otra parte
            if (cls.IsInformationNeededToUpdate())
                return;

            if (cboWorkPlan.SelectedIndex == 0)
            {   SystemSounds.Exclamation.Play();
                return;
            }

            int cantityPallets = (int)nudPalletTotal.Value;

            ClsGenerateStringZplPalletTag GenPallet = new();
            string ZplPtiTag = GenPallet.GenerateSuperStringTag("X00001", cls.eTagInfo, 1, cantityPallets, chbRevesePalletTag.Checked, false);
            Clipboard.SetText(ZplPtiTag);
        }

        private void btnZplPtiCopy_Click(object sender, EventArgs e)
        {//Está igual que el método cls.BtnPrintPtiTag();, solo que en lugar de imprimir, copia el ZPL al portapapeles
            if (cls.IsInformationNeededToUpdate())
                return;

            if (cboWorkPlan.SelectedIndex == 0)
            {   SystemSounds.Exclamation.Play();
                return;
            }

            ClsGenerateSuperStringTagPti GenPti = new();
            cls.eTagInfo.idPti = txbIdPtiChange.Text;
            cls.eTagInfo.showDate = !chbFechaOmitidaPti.Checked;
            string ZplPtiTag = GenPti.GenerateSuperStringTag(cls.eTagInfo, 1, chbReversePtiTag.Checked);
            Clipboard.SetText(ZplPtiTag);
        }
    }
}