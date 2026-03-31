using Microsoft.ReportingServices.ReportProcessing.OnDemandReportObjectModel;
using NPOI.Util;
using SisUvex.Archivo.Etiquetas.PrintLabels;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Values;
using SisUvex.Configuracion;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static SisUvex.Catalogos.Metods.ClsObject;

namespace SisUvex.Archivo.Reimprimir
{
    public partial class FrmRePrintPallet : Form
    {
       
        public FrmRePrintPallet()
        {
            InitializeComponent();
        }
        private ClsPalletCreate palletCreate;
        public DataTable? dtWorkPlan;

        private void button2_Click(object sender, EventArgs e)
        {
            ClsPrintLabelsPtiPallets printPalletLabe = new ClsPrintLabelsPtiPallets();
            bool reverseOrientation = chbRevesePalletTag.Checked;
            string idPallet = txbRePrintCode.Text.PadLeft(5,'0');
            bool showDate = !chbFechaOmitidaPallet.Checked; //MOSTRAR U OCULTAR FECHA DEL PALLET

            if (txbUpdateBoxes.Text == "")
            {

            }
            else
            {
                int palletBoxes = Convert.ToInt32(txbUpdateBoxes.Text);
                ClsPalletCreate.UpdatePallet(idPallet, palletBoxes);
            }

            ClsReprintPallet.ReprintPalletTag(idPallet, 2, reverseOrientation, showDate);
        }

        private void FrmRePrintPallet_Load(object sender, EventArgs e)
        {
        }

    }
}
