using SisUvex.Configuracion;
using System.Drawing.Printing;

namespace SisUvex.Archivo.Etiquetas.PrintLabels
{
    internal class ClsPrintPtiTag
    {
        ClsGenerateSuperStringTagPti GenPti = new ClsGenerateSuperStringTagPti();
        ClsGenerateStringZplPalletTag GenPallet = new ClsGenerateStringZplPalletTag();
        ClsPrintLabelsPtiPallets printPalletPTI = new ClsPrintLabelsPtiPallets();

        public void SendToPrintPtiTag(ETagInfo eTagInfo, int copies, bool reverseOrientation)
        {
            string printerName = ClsConfPrinter.GetPrinterPtiName();
            if (!string.IsNullOrEmpty(printerName))
            {
                string SuperString = GenPti.GenerateSuperStringTag(eTagInfo, copies, reverseOrientation);
                PrintZPL(SuperString, printerName);
                //Clipboard.SetText(SuperString);
            }
            else
                MessageBox.Show("Seleccione una impresora válida", "Impresora");
        }

        public void SetTagInfo(string workPlan)
        {
            printPalletPTI.SetTagInfo(workPlan, printPalletPTI.eTagInfo);
        }

        public void SendToPrintPalletTag(string idPallet, ETagInfo eTagInfo, int copies, int palletBoxes, bool reverseOrientation, bool isReprint)
        {
            string printerName = ClsConfPrinter.GetPrinterPalletName();
            if (!string.IsNullOrEmpty(printerName))
            {
                string SuperString = GenPallet.GenerateSuperStringTag(idPallet, eTagInfo, copies, palletBoxes, reverseOrientation, isReprint);
                PrintZPL(SuperString, printerName);
            }
            else
                MessageBox.Show("Seleccione una impresora válida", "Impresora");
        }

        public void SendToPrintSmallPalletCodeTag(string zpl)
        {
            string printerName = ClsConfPrinter.GetPrinterCodeName();
            if (!string.IsNullOrEmpty(printerName))
                PrintZPL(zpl, printerName);
            else
                MessageBox.Show("Seleccione una impresora válida para código (2x1)", "Impresora");
        }

        private void PrintZPL(string superPrint, string printer)
        {//VERIFICAR SI LA IMPRESORA ESTÁ INSTALADA A ESTE PUNTO PARA EVITAR ERRORES
                RawPrinterHelper.SendStringToPrinter(printer, superPrint);
        }
    }
}