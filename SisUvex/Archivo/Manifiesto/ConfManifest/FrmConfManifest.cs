using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.ComboBoxes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Archivo.Manifiesto.ConfManifest
{
    public partial class FrmConfManifest : Form
    {
        ClsConfigManifest cls;
        public FrmConfManifest()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                cls.idSeason = txbIdSeason.Text;
                cls.idMarket = txbIdMarket.Text;
                cls.temperature = (int)nudTemperature.Value;
                cls.temperatureUnit = cboTemperatureUnit.Text;
                cls.printManifest = chbPrintManifest.Checked;
                cls.printMaping = chbPrintMaping.Checked;
                cls.printPackingList = chbPrintPackingList.Checked;
                cls.transportVehicle = cboTransportVehicle.Text;
                cls.transportTransportType = cboTransportType.Text;

                cls.SetParameters();

                cls.manifestFolderPath = txbManifestFolderPath.Text;

                if(Directory.Exists(txbManifestFolderPath.Text))
                    cls.SetManifestPath(txbManifestFolderPath.Text);
                else
                    throw new Exception("La ruta para la carpeta de los manifiestos no existe");

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmConfManifest_Load(object sender, EventArgs e)
        {

            cls ??= new ClsConfigManifest();

            cls.GetParameters();

            ClsComboBoxes.CboLoadActives(cboSeason, ClsObject.Season.Cbo);
            ClsComboBoxes.CboApplyTextChangedEvent(cboSeason, txbIdSeason);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(cboSeason, cls.idSeason);

            ClsComboBoxes.CboLoadActives(cboMarket, ClsObject.Market.Cbo);
            ClsComboBoxes.CboApplyTextChangedEvent(cboMarket, txbIdMarket);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(cboMarket, cls.idMarket);

            nudTemperature.Value = cls.temperature ?? 34;
            cboTemperatureUnit.Text = cls.temperatureUnit ?? "F";

            chbPrintManifest.Checked = cls.printManifest;
            chbPrintMaping.Checked = cls.printMaping;
            chbPrintPackingList.Checked = cls.printPackingList;
            cboTransportVehicle.Text = cls.transportVehicle;
            cboTransportType.Text = cls.transportTransportType;

            txbManifestFolderPath.Text = cls.manifestFolderPath;
        }

        private void btnManifestFolderPath_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Seleccione una carpeta";
                folderDialog.ShowNewFolderButton = true; // Permite crear nuevas carpetas

                // Mostrar el diálogo y verificar si el usuario seleccionó una carpeta
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    txbManifestFolderPath.Text = folderDialog.SelectedPath; // Mostrar la ruta en el TextBox
                }
            }
        }
    }
}
