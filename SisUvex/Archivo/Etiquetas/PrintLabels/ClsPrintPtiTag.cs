using SisUvex.Configuracion;
using System.Drawing.Printing;

namespace SisUvex.Archivo.Etiquetas.PrintLabels
{
    internal class ClsPrintPtiTag
    {
        ClsConfPrinter ClsConfPrinter = new ClsConfPrinter();
        PrintDocument pd = new PrintDocument();
        ClsGenerateSuperStringTagPti GenPti = new ClsGenerateSuperStringTagPti();
        ClsGenerateStringZplPalletTag GenPallet = new ClsGenerateStringZplPalletTag();
        ClsPrintLabelsPtiPallets printPalletPTI = new ClsPrintLabelsPtiPallets();

        public void SendToPrintPtiTag(ETagInfo eTagInfo, int copies, bool reverseOrientation)
        {
            string SuperString = GenPti.GenerateSuperStringTag(eTagInfo, copies, reverseOrientation);

            PrintZPL(SuperString, ClsConfPrinter.PrintTags);

            //Clipboard.SetText(SuperString);
        }

        public void SetTagInfo(string workPlan)
        {
            printPalletPTI.SetTagInfo(workPlan, printPalletPTI.eTagInfo);
        }

        public void SendToPrintPalletTag(string idPallet, ETagInfo eTagInfo, int copies, int palletBoxes, bool reverseOrientation)
        {
            string SuperString = GenPallet.GenerateSuperStringTag(idPallet, eTagInfo, copies, palletBoxes, reverseOrientation);
            PrintZPL(SuperString, ClsConfPrinter.PrintPallet);
            //Clipboard.SetText(SuperString);
        }

        private void PrintZPL(string superPrint, string printer)
        {
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