
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
            ComboBoxes.Add(cboDistribuidor);
            ComboBoxes.Add(cboConsignatario);
            ComboBoxes.Add(cboProductor);
            ComboBoxes.Add(cboAgenciaUS);
            ComboBoxes.Add(cboAgenciaMX);
            ComboBoxes.Add(cboCiudadCruce);
            ComboBoxes.Add(cboCiudadDestino);
            ComboBoxes.Add(cboLinea);
            ComboBoxes.Add(cboChofer);
            ComboBoxes.Add(cboTroque);
            ComboBoxes.Add(cboCaja);
            SetObligatorios();
            cls.DgvColumnas(dgvListado);
        }

        private void FrmManifiestoAñadir_Load(object sender, EventArgs e)
        {
            ClsTextBoxes.TxbApplyKeyPressEventNumericWithLimit(txbDieselLiters, 9, 2);

            if (!añadirModificar)
            {
                DesactivarTextChanged();
                cls.CargarComboBoxes(ComboBoxes);
                cls.CboIndiceValue(cboDistribuidor, txbIdDistribuidor);
                cls.CboIndiceValue(cboConsignatario, txbIdConsignatario);
                cls.CboIndiceValue(cboProductor, txbIdProductor);
                cls.CboIndiceValue(cboAgenciaMX, txbIdAgenciaMX);
                cls.CboIndiceValue(cboAgenciaUS, txbIdAgenciaUS);
                cls.CboIndiceValue(cboCiudadCruce, txbIdCiudadCruce);
                cls.CboIndiceValue(cboCiudadDestino, txbIdCiudadDestino);
                cls.CboIndiceValue(cboLinea, txbIdLinea);
                cls.CboIndiceValue(cboTroque, txbIdTroque);
                cls.CboIndiceValue(cboCaja, txbIdCaja);
                cls.CboIndiceValue(cboChofer, txbIdChofer);
                ActivarTextChanged();

                cls.AñadirPalletsManifiesto(dgvListado, txbId.Text);

                txbPosicionPal.Text = cls.ObtenerSiguientePosicion(dgvListado);
            }
            else
            {
                cls.CargarComboBoxes(ComboBoxes);

            }
            if (txbGrados.TextLength == 0) //SI EL MANIFIESTO ESTÁ VACÍO O ALGO ASÍ
            {
                txbGrados.Text = "34";
                cboGrados.SelectedIndex = 0;
                cboMedioTransporte.SelectedIndex = 1;
                cboSegundoMedio.SelectedIndex = 2;

                spnHoraSalida.Text = DateTime.Now.Minute > 45 ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 55, 0).ToString("HH:mm") : DateTime.Now.AddMinutes(15 - DateTime.Now.Minute % 15).ToString("HH:mm");
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
                    man = cls.AñadirManifiesto(cboActivo.SelectedIndex.ToString(), cboTipoEmbarque.Text, txbIdDistribuidor.Text, txbIdConsignatario.Text, txbIdProductor.Text, txbIdAgenciaUS.Text, txbIdAgenciaMX.Text, txbIdLinea.Text, txbIdTroque.Text, txbIdCaja.Text, txbIdChofer.Text, txbIdCiudadCruce.Text, txbIdCiudadDestino.Text, txbSello1.Text, txbSello2.Text, txbSello3.Text, txbChismografo.Text, txbOrden.Text, txbBooking.Text, dtpFecha.Value, spnHoraSalida.Text, txbGrados.Text, cboGrados.Text, txbOperador.Text, txbEmbarcador.Text, cboMedioTransporte.Text, cboSegundoMedio.Text, chkRechazado.Checked, txbObservaciones.Text, txbPosicion.Text, txbDieselInvoice.Text, txbDieselLiters.Text, txbFitosanitario.Text);

                    cls.ProcManifestDeletePallets(man);

                    cls.ProcManifestAddPallets(dgvListado, man);

                    MessageBox.Show("Se ha añadido el manifiesto: "+man, "Añadir manifiesto", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txbId.Text = man;
                    añadirModificar = false;
                }
                else
                {
                    cls.ModificarManifiesto(cboActivo.SelectedIndex.ToString(), txbId.Text, txbIdDistribuidor.Text, txbIdConsignatario.Text, txbIdProductor.Text, txbIdAgenciaUS.Text, txbIdAgenciaMX.Text, txbIdLinea.Text, txbIdTroque.Text, txbIdCaja.Text, txbIdChofer.Text, txbIdCiudadCruce.Text, txbIdCiudadDestino.Text, txbSello1.Text, txbSello2.Text, txbSello3.Text, txbChismografo.Text, txbOrden.Text, txbBooking.Text, dtpFecha.Value, spnHoraSalida.Text, txbGrados.Text, cboGrados.Text, txbOperador.Text, txbEmbarcador.Text, cboMedioTransporte.Text, cboSegundoMedio.Text, chkRechazado.Checked, txbObservaciones.Text, txbPosicion.Text, txbDieselInvoice.Text, txbDieselLiters.Text, txbFitosanitario.Text);

                    cls.ProcManifestDeletePallets(txbId.Text);

                    cls.ProcManifestAddPallets(dgvListado, txbId.Text);
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
            cboDistribuidor.TextChanged -= cboDistribuidor_TextChanged;
            cboConsignatario.TextChanged -= cboConsignatario_TextChanged;
            cboProductor.TextChanged -= cboProductor_TextChanged;
            cboAgenciaMX.TextChanged -= cboAgenciaMX_TextChanged;
            cboAgenciaUS.TextChanged -= cboAgenciaUS_TextChanged;
            cboCiudadCruce.TextChanged -= cboCiudadCruce_TextChanged;
            cboCiudadDestino.TextChanged -= cboCiudadDestino_TextChanged;
            cboLinea.TextChanged -= cboLinea_TextChanged;
            cboTroque.TextChanged -= cboTroque_TextChanged;
            cboCaja.TextChanged -= cboCaja_TextChanged;
            cboChofer.TextChanged -= cboChofer_TextChanged;
        }
        private void ActivarTextChanged()
        {
            cboDistribuidor.TextChanged += cboDistribuidor_TextChanged;
            cboConsignatario.TextChanged += cboConsignatario_TextChanged;
            cboProductor.TextChanged += cboProductor_TextChanged;
            cboAgenciaMX.TextChanged += cboAgenciaMX_TextChanged;
            cboAgenciaUS.TextChanged += cboAgenciaUS_TextChanged;
            cboCiudadCruce.TextChanged += cboCiudadCruce_TextChanged;
            cboCiudadDestino.TextChanged += cboCiudadDestino_TextChanged;
            cboLinea.TextChanged += cboLinea_TextChanged;
            cboTroque.TextChanged += cboTroque_TextChanged;
            cboCaja.TextChanged += cboCaja_TextChanged;
            cboChofer.TextChanged += cboChofer_TextChanged;
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
                if (!cls.PalletRepetido(dgvListado, cls.FormatoCeros(txbIdPallet.Text, "00000")))
                {
                    cls.AñadirPallet(dgvListado, cls.FormatoCeros(txbIdPallet.Text, "00000"), txbId.Text, cls.FormatoCeros(txbPosicionPal.Text, "00"));
                    txbPosicionPal.Text = cls.ObtenerSiguientePosicion(dgvListado);

                    dgvListado.Sort(dgvListado.Columns["Posicion"], ListSortDirection.Ascending);
                }
            }
            txbIdPallet.Focus();
            txbIdPallet.SelectAll();


        }
        #region LINEA -----------------------------------------------------------------------------
        private void cboLinea_MouseClick(object sender, MouseEventArgs e)
        {
            cls.CboPrimerClic(cboLinea);
        }
        private void btnBuscarLinea_Click(object sender, EventArgs e)
        {
            cls.BtnBuscarLinea(cboLinea);
        }
        private void btnTodoLinea_Click(object sender, EventArgs e)
        {
            txbIdLinea.Text = cls.BtnTodoLinea(cboLinea);
            if (cls.ActLin)
                btnTodoLinea.Text = "Activo";
            else
                btnTodoLinea.Text = "Todo";
        }
        private void cboLinea_TextChanged(object sender, EventArgs e)
        {
            txbIdLinea.Text = cls.CboValueDelSeleccionado(cboLinea);
        }
        #endregion

        private void txbIdLinea_TextChanged(object sender, EventArgs e)
        {
            cls.CboCargarEnBlanco(cboChofer, cls.CboChofer("", "0", txbIdLinea.Text));
            cls.CboCargarEnBlanco(cboTroque, cls.CboTroque("", "0", txbIdLinea.Text));
            cls.CboCargarEnBlanco(cboCaja, cls.CboCaja("", "0", txbIdLinea.Text));
        }
        private void cboChofer_TextChanged(object sender, EventArgs e)
        {
            txbIdChofer.Text = cls.CboValueDelSeleccionado(cboChofer);
        }

        private void cboTroque_TextChanged(object sender, EventArgs e)
        {
            txbIdTroque.Text = cls.CboValueDelSeleccionado(cboTroque);
        }
        private void cboCaja_TextChanged(object sender, EventArgs e)
        {
            txbIdCaja.Text = cls.CboValueDelSeleccionado(cboCaja);
        }
        private void cboDistribuidor_TextChanged(object sender, EventArgs e)
        {
            txbIdDistribuidor.Text = cls.CboValueDelSeleccionado(cboDistribuidor);
            cls.CboManifiestoDistribuidor(txbIdDistribuidor, cboConsignatario, cboProductor, cboAgenciaUS, cboAgenciaMX, cboCiudadCruce, cboCiudadDestino);
        }
        private void cboConsignatario_TextChanged(object sender, EventArgs e)
        {
            txbIdConsignatario.Text = cls.CboValueDelSeleccionado(cboConsignatario);
        }
        private void cboProductor_TextChanged(object sender, EventArgs e)
        {
            txbIdProductor.Text = cls.CboValueDelSeleccionado(cboProductor);
        }

        private void cboAgenciaUS_TextChanged(object sender, EventArgs e)
        {
            txbIdAgenciaUS.Text = cls.CboValueDelSeleccionado(cboAgenciaUS);
        }

        private void cboAgenciaMX_TextChanged(object sender, EventArgs e)
        {
            txbIdAgenciaMX.Text = cls.CboValueDelSeleccionado(cboAgenciaMX);
        }

        private void cboCiudadCruce_TextChanged(object sender, EventArgs e)
        {
            txbIdCiudadCruce.Text = cls.CboValueDelSeleccionado(cboCiudadCruce);
        }

        private void cboCiudadDestino_TextChanged(object sender, EventArgs e)
        {
            txbIdCiudadDestino.Text = cls.CboValueDelSeleccionado(cboCiudadDestino);
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
            txbId.Text = cls.SiguienteManifiesto(cboTipoEmbarque.Text);
        }



        private void dgvListado_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void btnBorrarPallet_Click(object sender, EventArgs e)
        {
            cls.BorrarPallet(dgvListado);
            txbPosicionPal.Text = cls.ObtenerSiguientePosicion(dgvListado);
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
                    if (!cls.PalletRepetido(dgvListado, cls.FormatoCeros(txbIdPallet.Text, "00000")))
                    {
                        cls.AñadirPallet(dgvListado, cls.FormatoCeros(txbIdPallet.Text, "00000"), txbId.Text, cls.FormatoCeros(txbPosicionPal.Text, "00"));
                        txbPosicionPal.Text = cls.ObtenerSiguientePosicion(dgvListado);

                        dgvListado.Sort(dgvListado.Columns["Posicion"], ListSortDirection.Ascending);
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
                ClsPDFManifiesto pdf = new ClsPDFManifiesto();
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