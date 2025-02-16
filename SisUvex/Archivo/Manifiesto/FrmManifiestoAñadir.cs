
using Extensiones;
using SisUvex.Catalogos;
using SisUvex.Catalogos.Metods.TextBoxes;
using System.ComponentModel;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace SisUvex.Archivo.Manifiesto
{
    public partial class FrmManifiestoAñadir : Form
    {
        public bool añadirModificar = true; //Verdadero para nuevo, falso para modificar
        ClsManifiesto cls = new ClsManifiesto();
        List<ComboBox> ComboBoxes = new List<ComboBox>();
        List<Control> Obligatorios = new List<Control>();
        public FrmManifiestoAñadir(FrmManifiestoCat catalogo)
        {
            InitializeComponent();
            ComboBoxes.Add(cboDistributor);
            ComboBoxes.Add(cboConsignee);
            ComboBoxes.Add(cboGrower);
            ComboBoxes.Add(cboAgencyUS);
            ComboBoxes.Add(cboAgencyMX);
            ComboBoxes.Add(cboCityCrossPoint);
            ComboBoxes.Add(cboCityDestination);
            ComboBoxes.Add(cboTransportLine);
            ComboBoxes.Add(cboDriver);
            ComboBoxes.Add(cboTruck);
            ComboBoxes.Add(cboFreightContainer);
            SetObligatorios();
            cls.DgvColumnas(dgvPalletList);
        }

        private void FrmManifiestoAñadir_Load(object sender, EventArgs e)
        {
            ClsTextBoxes.TxbApplyKeyPressEventNumericWithLimit(txbDieselLiters, 9, 2);

            if (!añadirModificar)
            {
                DesactivarTextChanged();
                cls.CargarComboBoxes(ComboBoxes);
                cls.CboIndiceValue(cboDistributor, txbIdDistributor);
                cls.CboIndiceValue(cboConsignee, txbIdConsignee);
                cls.CboIndiceValue(cboGrower, txbIdGrower);
                cls.CboIndiceValue(cboAgencyMX, txbIdAgencyMX);
                cls.CboIndiceValue(cboAgencyUS, txbIdAgencyUS);
                cls.CboIndiceValue(cboCityCrossPoint, txbIdCityCrossPoint);
                cls.CboIndiceValue(cboCityDestination, txbIdCityDestination);
                cls.CboIndiceValue(cboTransportLine, txbIdTransportLine);
                cls.CboIndiceValue(cboTruck, txbIdTruck);
                cls.CboIndiceValue(cboFreightContainer, txbIdFreightContainer);
                cls.CboIndiceValue(cboDriver, txbIdDriver);
                ActivarTextChanged();

                cls.AñadirPalletsManifiesto(dgvPalletList, txbId.Text);

                txbPalletPosition.Text = cls.ObtenerSiguientePosicion(dgvPalletList);
            }
            else
            {
                cls.CargarComboBoxes(ComboBoxes);

            }
            if (txbTemperature.TextLength == 0) //SI EL MANIFIESTO ESTÁ VACÍO O ALGO ASÍ
            {
                txbTemperature.Text = "34";
                cboTemperatureUnit.SelectedIndex = 0;
                cboTransportVehicle.SelectedIndex = 1;
                cboTransportType.SelectedIndex = 2;

                spnHour.Text = DateTime.Now.Minute > 45 ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 55, 0).ToString("HH:mm") : DateTime.Now.AddMinutes(15 - DateTime.Now.Minute % 15).ToString("HH:mm");
            }

        }
        #region CATALOGOHIJO
        public delegate void UpdateDelegate(object sender, UpdateEventArgs args);
        public event UpdateDelegate UpdateEventHandler;
        public class UpdateEventArgs : EventArgs
        {
            public string Data { get; set; }
        }
        protected void ActualizarCatalogoHijo()
        {
            UpdateEventArgs args = new UpdateEventArgs();
            UpdateEventHandler.Invoke(this, args);
        }
        #endregion FIN CATALOGOHIJO
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string vacios = "";
            foreach (Control control in Obligatorios)
            {
                if (control.Text == string.Empty)
                {
                    vacios = vacios + control.GetMensajeVacio() + "\r\n";
                    control.GetControlRelacionado().Focus();
                }
            }
            if (vacios != "")
                MessageBox.Show("Debe ingresar:\n\n" + vacios, "Añadir distribuidor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                string man = string.Empty;
                if (añadirModificar)
                {
                    man = cls.AñadirManifiesto(cboActive.SelectedIndex.ToString(), cboManifestType.Text, txbIdDistributor.Text, txbIdConsignee.Text, txbIdGrower.Text, txbIdAgencyUS.Text, txbIdAgencyMX.Text, txbIdTransportLine.Text, txbIdTruck.Text, txbIdFreightContainer.Text, txbIdDriver.Text, txbIdCityCrossPoint.Text, txbIdCityDestination.Text, txbSeal1.Text, txbSeal2.Text, txbSeal3.Text, txbTermograph.Text, txbPurchaseOrder.Text, txbBooking.Text, dtpDate.Value, spnHour.Text, txbTemperature.Text, cboTemperatureUnit.Text, txbNameOperator.Text, txbNameShipper.Text, cboTransportVehicle.Text, cboTransportType.Text, chkRejected.Checked, txbObservations.Text, txbTermoPosition.Text, txbDieselInvoice.Text, txbDieselLiters.Text, txbPhytosanitary.Text);

                    cls.ProcManifestDeletePallets(man);

                    cls.ProcManifestAddPallets(dgvPalletList, man);

                    MessageBox.Show("Se ha añadido el manifiesto: "+man, "Añadir manifiesto", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txbId.Text = man;
                    añadirModificar = false;
                }
                else
                {
                    cls.ModificarManifiesto(cboActive.SelectedIndex.ToString(), txbId.Text, txbIdDistributor.Text, txbIdConsignee.Text, txbIdGrower.Text, txbIdAgencyUS.Text, txbIdAgencyMX.Text, txbIdTransportLine.Text, txbIdTruck.Text, txbIdFreightContainer.Text, txbIdDriver.Text, txbIdCityCrossPoint.Text, txbIdCityDestination.Text, txbSeal1.Text, txbSeal2.Text, txbSeal3.Text, txbTermograph.Text, txbPurchaseOrder.Text, txbBooking.Text, dtpDate.Value, spnHour.Text, txbTemperature.Text, cboTemperatureUnit.Text, txbNameOperator.Text, txbNameShipper.Text, cboTransportVehicle.Text, cboTransportType.Text, chkRejected.Checked, txbObservations.Text, txbTermoPosition.Text, txbDieselInvoice.Text, txbDieselLiters.Text, txbPhytosanitary.Text);

                    cls.ProcManifestDeletePallets(txbId.Text);

                    cls.ProcManifestAddPallets(dgvPalletList, txbId.Text);
                    MessageBox.Show("Se ha modificado el manifiesto: " + txbId.Text, "Añadir manifiesto", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                //cls.LimpiarTextBox(this);
                ActualizarCatalogoHijo();
                //this.Close();
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cls.LimpiarTextBox(this);
            this.Close();
        }
        private void FrmManifiestoAñadir_FormClosing(object sender, FormClosingEventArgs e)
        {
            cls.LimpiarTextBox(this);
        }

        private void HacerModificarElFormularioDeAñadir()
        {

        }
        private void DesactivarTextChanged()
        {
            cboDistributor.TextChanged -= cboDistribuidor_TextChanged;
            cboConsignee.TextChanged -= cboConsignatario_TextChanged;
            cboGrower.TextChanged -= cboProductor_TextChanged;
            cboAgencyMX.TextChanged -= cboAgenciaMX_TextChanged;
            cboAgencyUS.TextChanged -= cboAgenciaUS_TextChanged;
            cboCityCrossPoint.TextChanged -= cboCiudadCruce_TextChanged;
            cboCityDestination.TextChanged -= cboCiudadDestino_TextChanged;
            cboTransportLine.TextChanged -= cboLinea_TextChanged;
            cboTruck.TextChanged -= cboTroque_TextChanged;
            cboFreightContainer.TextChanged -= cboCaja_TextChanged;
            cboDriver.TextChanged -= cboChofer_TextChanged;
        }
        private void ActivarTextChanged()
        {
            cboDistributor.TextChanged += cboDistribuidor_TextChanged;
            cboConsignee.TextChanged += cboConsignatario_TextChanged;
            cboGrower.TextChanged += cboProductor_TextChanged;
            cboAgencyMX.TextChanged += cboAgenciaMX_TextChanged;
            cboAgencyUS.TextChanged += cboAgenciaUS_TextChanged;
            cboCityCrossPoint.TextChanged += cboCiudadCruce_TextChanged;
            cboCityDestination.TextChanged += cboCiudadDestino_TextChanged;
            cboTransportLine.TextChanged += cboLinea_TextChanged;
            cboTruck.TextChanged += cboTroque_TextChanged;
            cboFreightContainer.TextChanged += cboCaja_TextChanged;
            cboDriver.TextChanged += cboChofer_TextChanged;
        }
        private void SetObligatorios()
        {
            Obligatorios.Add(txbId);
            txbId.SetMensajeVacio("Nombre de Manifiesto.");
            txbId.SetControlRelacionado(txbId);
        }
        private void btnAñadirPallet_Click(object sender, EventArgs e)
        {
            if (txbIdPallet.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar número de pallet.");
            }
            else
            {
                if (!cls.PalletRepetido(dgvPalletList, cls.FormatoCeros(txbIdPallet.Text, "00000")))
                {
                    cls.AñadirPallet(dgvPalletList, cls.FormatoCeros(txbIdPallet.Text, "00000"), txbId.Text, cls.FormatoCeros(txbPalletPosition.Text, "00"));
                    txbPalletPosition.Text = cls.ObtenerSiguientePosicion(dgvPalletList);

                    dgvPalletList.Sort(dgvPalletList.Columns["Posicion"], ListSortDirection.Ascending);
                }
            }
            txbIdPallet.Focus();
            txbIdPallet.SelectAll();


        }
        #region LINEA -----------------------------------------------------------------------------
        private void cboLinea_MouseClick(object sender, MouseEventArgs e)
        {
            cls.CboPrimerClic(cboTransportLine);
        }
        private void btnBuscarLinea_Click(object sender, EventArgs e)
        {
            cls.BtnBuscarLinea(cboTransportLine);
        }
        private void btnTodoLinea_Click(object sender, EventArgs e)
        {
            txbIdTransportLine.Text = cls.BtnTodoLinea(cboTransportLine);
            if (cls.ActLin)
                btnRemovedTransportLine.Text = "Activo";
            else
                btnRemovedTransportLine.Text = "Todo";
        }
        private void cboLinea_TextChanged(object sender, EventArgs e)
        {
            txbIdTransportLine.Text = cls.CboValueDelSeleccionado(cboTransportLine);
        }
        #endregion

        private void txbIdLinea_TextChanged(object sender, EventArgs e)
        {
            cls.CboCargarEnBlanco(cboDriver, cls.CboChofer("", "0", txbIdTransportLine.Text));
            cls.CboCargarEnBlanco(cboTruck, cls.CboTroque("", "0", txbIdTransportLine.Text));
            cls.CboCargarEnBlanco(cboFreightContainer, cls.CboCaja("", "0", txbIdTransportLine.Text));
        }
        private void cboChofer_TextChanged(object sender, EventArgs e)
        {
            txbIdDriver.Text = cls.CboValueDelSeleccionado(cboDriver);
        }

        private void cboTroque_TextChanged(object sender, EventArgs e)
        {
            txbIdTruck.Text = cls.CboValueDelSeleccionado(cboTruck);
        }
        private void cboCaja_TextChanged(object sender, EventArgs e)
        {
            txbIdFreightContainer.Text = cls.CboValueDelSeleccionado(cboFreightContainer);
        }
        private void cboDistribuidor_TextChanged(object sender, EventArgs e)
        {
            txbIdDistributor.Text = cls.CboValueDelSeleccionado(cboDistributor);
            cls.CboManifiestoDistribuidor(txbIdDistributor, cboConsignee, cboGrower, cboAgencyUS, cboAgencyMX, cboCityCrossPoint, cboCityDestination);
        }
        private void cboConsignatario_TextChanged(object sender, EventArgs e)
        {
            txbIdConsignee.Text = cls.CboValueDelSeleccionado(cboConsignee);
        }
        private void cboProductor_TextChanged(object sender, EventArgs e)
        {
            txbIdGrower.Text = cls.CboValueDelSeleccionado(cboGrower);
        }

        private void cboAgenciaUS_TextChanged(object sender, EventArgs e)
        {
            txbIdAgencyUS.Text = cls.CboValueDelSeleccionado(cboAgencyUS);
        }

        private void cboAgenciaMX_TextChanged(object sender, EventArgs e)
        {
            txbIdAgencyMX.Text = cls.CboValueDelSeleccionado(cboAgencyMX);
        }

        private void cboCiudadCruce_TextChanged(object sender, EventArgs e)
        {
            txbIdCityCrossPoint.Text = cls.CboValueDelSeleccionado(cboCityCrossPoint);
        }

        private void cboCiudadDestino_TextChanged(object sender, EventArgs e)
        {
            txbIdCityDestination.Text = cls.CboValueDelSeleccionado(cboCityDestination);
        }

        private void txbPosicion_KeyPress(object sender, KeyPressEventArgs e)
        {
            cls.TxbTeclasEnteros(e);
        }

        private void txbGrados_KeyPress(object sender, KeyPressEventArgs e)
        {
            cls.TxbTeclasEnteros(e);
        }

        private void cboTipoEmbarque_TextChanged(object sender, EventArgs e)
        {
            txbId.Text = cls.SiguienteManifiesto(cboManifestType.Text);
        }



        private void dgvListado_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void btnBorrarPallet_Click(object sender, EventArgs e)
        {
            cls.BorrarPallet(dgvPalletList);
            txbPalletPosition.Text = cls.ObtenerSiguientePosicion(dgvPalletList);
        }

        private void txbIdPallet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (txbIdPallet.Text == string.Empty)
                {
                    MessageBox.Show("Debe ingresar número de pallet.");
                }
                else
                {
                    if (!cls.PalletRepetido(dgvPalletList, cls.FormatoCeros(txbIdPallet.Text, "00000")))
                    {
                        cls.AñadirPallet(dgvPalletList, cls.FormatoCeros(txbIdPallet.Text, "00000"), txbId.Text, cls.FormatoCeros(txbPalletPosition.Text, "00"));
                        txbPalletPosition.Text = cls.ObtenerSiguientePosicion(dgvPalletList);

                        dgvPalletList.Sort(dgvPalletList.Columns["Posicion"], ListSortDirection.Ascending);
                    }
                }
                txbIdPallet.Focus();
                txbIdPallet.SelectAll();
            }
        }

        private void printManifestBtn_Click(object sender, EventArgs e)
        {
            if(txbId.Text != "")
            {
                //ClsPDFManifiesto pdf = new ClsPDFManifiesto();
                ClsPruebaManifiesto pdf = new ClsPruebaManifiesto();
                pdf.CreatePDFManifest(txbId.Text);
                ClsPDFLoadingMap pdfMap = new ClsPDFLoadingMap();
                pdfMap.CreatePDFMaping(txbId.Text);
                if(chkBoxPackingList.Checked)
                {
                    ClsPDFPackingList pdfPackingList = new ClsPDFPackingList();
                    pdfPackingList.CreatePDFPackingList(txbId.Text);
                }
            }
            else
            {
                MessageBox.Show("Debe guardar el manifiesto antes de imprimirlo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}