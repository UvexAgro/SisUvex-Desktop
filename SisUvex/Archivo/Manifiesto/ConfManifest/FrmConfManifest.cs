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

            cls ??= new ClsConfigManifest();

            cls.GetParameters();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            cls.idSeason = txbIdSeason.Text;
            cls.market = cboMarket.Text.Substring(0,1);
            cls.temperature = (int)nudTemperature.Value;
            cls.temperatureUnit = cboTemperatureUnit.Text;
            cls.printManifest = chbPrintManifest.Checked;
            cls.printMaping = chbPrintMaping.Checked;
            cls.printPackingList = chbPrintPackingList.Checked;
            cls.transportVehicle = cboTransportVehicle.Text;
            cls.transportTransportType = cboTransportType.Text;

            cls.SetParameters();
        }

        private void FrmConfManifest_Load(object sender, EventArgs e)
        {
            txbIdSeason.Text = cls.idSeason;
            ClsComboBoxes.CboLoadActives(cboSeason, ClsObject.Season.Cbo);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(cboSeason, cls.idSeason ?? "");
            ClsComboBoxes.CboApplyTextChangedEvent(cboSeason, txbIdSeason);

            SetMarketCbo();
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(cboMarket, cls.market ?? "E");

            nudTemperature.Value = cls.temperature ?? 34;
            //ClsComboBoxes.CboSelectIndexWithTextInDisplayMember(cboTemperatureUnit, cls.temperatureUnit ?? "F");
            cboTemperatureUnit.Text = cls.temperatureUnit ?? "F";

            chbPrintManifest.Checked = cls.printManifest;
            chbPrintMaping.Checked = cls.printMaping;
            chbPrintPackingList.Checked = cls.printPackingList;
            cboTransportVehicle.Text = cls.transportVehicle;
            cboTransportType.Text = cls.transportTransportType;
        }

        private void SetMarketCbo()
        {
            DataTable dt = new();
            dt.Columns.Add(ClsObject.Column.name);
            dt.Columns.Add(ClsObject.Column.id);

            dt.Rows.Add("Extranjero", "E");
            dt.Rows.Add("Nacional", "N");

            cboMarket.DataSource = dt;
            cboMarket.DisplayMember = ClsObject.Column.name;
            cboMarket.ValueMember = ClsObject.Column.id;
        }
    }
}
