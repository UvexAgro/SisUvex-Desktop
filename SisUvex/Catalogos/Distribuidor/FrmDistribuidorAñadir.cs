using Extensiones;
namespace SisUvex.Catalogos.Distribuidor
{

    public partial class FrmDistribuidorAñadir : Form
    {


        public bool añadirModificar = true; //Verdadero para nuevo, falso para modificar
        ClsDistribuidor cls = new ClsDistribuidor();
        List<ComboBox> ComboBoxes = new List<ComboBox>();

        private string agMX, cdDe, cdCr, pr;



        public FrmDistribuidorAñadir(FrmDistribuidorCat catalogo)
        {
            InitializeComponent();
            ComboBoxes.Add(cboAgenciaUS);
            ComboBoxes.Add(cboAgenciaMX);
            ComboBoxes.Add(cboProductor);
            ComboBoxes.Add(cboCiudadCruce);
            ComboBoxes.Add(cboCiudadDestino);
            SetObligatorios();
        }
        #region VACIOS
        List<Control> Obligatorios = new List<Control>();

        public void SetObligatorios()
        {
            Obligatorios.Add(txbNombre);
            Obligatorios.Add(txbNombreCorto);

            txbNombre.SetMensajeVacio("Nombre del distribuidor.");
            txbNombre.SetControlRelacionado(txbNombre);

            txbNombreCorto.SetMensajeVacio("Nombre corto del distribuidor.");
            txbNombreCorto.SetControlRelacionado(txbNombreCorto);
        }
        #endregion
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
                if (añadirModificar)
                    cls.AñadirDistribuidor(txbNombre.Text, cboActivo.SelectedIndex.ToString(), cboMercado.Text, txbDireccion.Text, txbCiudad.Text, txbRFC.Text, txbTelefono.Text, txbIdAgenciaUS.Text, txbIdAgenciaMX.Text, txbIdProductor.Text, txbIdCiudadCruce.Text, txbIdCiudadDestino.Text, txbNombreCorto.Text, txbPais.Text);
                else
                    cls.ModificarDistribuidor(txbId.Text, cboActivo.SelectedIndex.ToString(), txbNombre.Text, cboMercado.Text, txbDireccion.Text, txbCiudad.Text, txbRFC.Text, txbTelefono.Text, txbIdAgenciaUS.Text, txbIdAgenciaMX.Text, txbIdProductor.Text, txbIdCiudadCruce.Text, txbIdCiudadDestino.Text, txbNombreCorto.Text, txbPais.Text);

                cls.LimpiarTextBox(this);
                ActualizarCatalogoHijo();
                this.Close();
            }
        }
        private void FrmDistribuidorAñadir_Load(object sender, EventArgs e)
        {
            if (!añadirModificar)
            {
                DesactivarActualizar();
                cls.CargarComboBoxes(ComboBoxes);
                cls.CboIndiceValue(cboAgenciaUS, txbIdAgenciaUS);
                cls.CboIndiceValue(cboAgenciaMX, txbIdAgenciaMX);
                cls.CboIndiceValue(cboProductor, txbIdProductor);
                cls.CboIndiceValue(cboCiudadCruce, txbIdCiudadCruce);
                cls.CboIndiceValue(cboCiudadDestino, txbIdCiudadDestino);
                ActivarActualizar();
            }
            else
                cls.CargarComboBoxes(ComboBoxes);
        }
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


        public static class ControlExtensions
        {
            public static string MensajeVacio { get; set; }
            public static Control ControlRelacionado { get; set; }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cls.LimpiarTextBox(this);
            this.Close();
        }
        private void FrmDistribuidorAñadir_FormClosing(object sender, FormClosingEventArgs e)
        {
            cls.LimpiarTextBox(this);
        }
        private void txbTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Tab) && (e.KeyChar != (char)Keys.Oemplus))
            {
                e.Handled = true;
            }
        }

        #region AGENCIA US
        private void cboAgenciaUS_MouseClick(object sender, MouseEventArgs e)
        {
            cls.CboPrimerClic(cboAgenciaUS);

        }
        private void btnBuscarAgenciaUS_Click(object sender, EventArgs e)
        {
            cls.BtnBuscarAgenciaUS(cboAgenciaUS);

        }
        private void btnTodoAgenciaUS_Click(object sender, EventArgs e)
        {
            cls.BtnTodoAgenciaUS(txbIdAgenciaUS, cboAgenciaUS, btnTodoAgenciaUS);

        }
        private void cboAgenciaUS_TextChanged(object sender, EventArgs e)
        {
            txbIdAgenciaUS.Text = cls.CboValueDelSeleccionado(cboAgenciaUS);
        }
        #endregion
        #region AGENCIA MX
        private void btnBuscarAgenciaMX_Click(object sender, EventArgs e)
        {
            cls.BtnBuscarAgenciaMX(cboAgenciaMX);
        }

        private void btnTodoAgenciaMX_Click(object sender, EventArgs e)
        {
            cls.BtnTodoAgenciaMX(txbIdAgenciaMX, cboAgenciaMX, btnTodoAgenciaMX);
        }

        private void cboAgenciaMX_MouseClick(object sender, MouseEventArgs e)
        {
            cls.CboPrimerClic(cboAgenciaMX);
        }

        private void cboAgenciaMX_TextChanged(object sender, EventArgs e)
        {
            txbIdAgenciaMX.Text = cls.CboValueDelSeleccionado(cboAgenciaMX);

        }
        #endregion
        #region PRODUCTOR
        private void btnBuscarProductor_Click(object sender, EventArgs e)
        {
            cls.BtnBuscarProductor(cboProductor);
        }

        private void btnTodoProductor_Click(object sender, EventArgs e)
        {
            cls.BtnTodoProductor(txbIdProductor, cboProductor, btnTodoProductor);
        }

        private void cboProductor_MouseClick(object sender, MouseEventArgs e)
        {
            cls.CboPrimerClic(cboProductor);
        }

        private void cboProductor_TextChanged(object sender, EventArgs e)
        {
            txbIdProductor.Text = cls.CboValueDelSeleccionado(cboProductor);
        }
        #endregion
        #region CIUDAD CRUCE
        private void btnBuscarCiudadCruce_Click(object sender, EventArgs e)
        {
            cls.BtnBuscarCiudad(cboCiudadCruce);
        }

        private void btnTodoCiudadCruce_Click(object sender, EventArgs e)
        {

            cls.BtnTodoCiudad(txbIdCiudadCruce, cboCiudadCruce, btnTodoCiudadCruce);
        }

        private void cboCiudadCruce_MouseClick(object sender, MouseEventArgs e)
        {
            cls.CboPrimerClic(cboCiudadCruce);
        }

        private void cboCiudadCruce_TextChanged(object sender, EventArgs e)
        {
            txbIdCiudadCruce.Text = cls.CboValueDelSeleccionado(cboCiudadCruce);
        }

        #endregion
        #region CIUDAD DESTINO
        private void btnBuscarCiudadDestino_Click(object sender, EventArgs e)
        {
            cls.BtnBuscarCiudad(cboCiudadDestino);

        }

        private void btnTodoCiudadDestino_Click(object sender, EventArgs e)
        {
            cls.BtnTodoCiudad(txbIdCiudadDestino, cboCiudadDestino, btnTodoCiudadDestino);
        }

        private void cboCiudadDestino_MouseClick(object sender, MouseEventArgs e)
        {
            cls.CboPrimerClic(cboCiudadDestino);

        }

        private void cboCiudadDestino_TextChanged(object sender, EventArgs e)
        {
            txbIdCiudadDestino.Text = cls.CboValueDelSeleccionado(cboCiudadDestino);
        }
        #endregion

        public void DesactivarActualizar()
        {
            cboAgenciaUS.TextChanged -= cboAgenciaUS_TextChanged;

            cboAgenciaMX.TextChanged -= cboAgenciaMX_TextChanged;

            cboProductor.TextChanged -= cboProductor_TextChanged;

            cboCiudadCruce.TextChanged -= cboCiudadCruce_TextChanged;

            cboCiudadDestino.TextChanged -= cboCiudadDestino_TextChanged;
        }

        public void ActivarActualizar()
        {
            cboAgenciaUS.TextChanged += cboAgenciaUS_TextChanged;

            cboAgenciaMX.TextChanged += cboAgenciaMX_TextChanged;

            cboProductor.TextChanged += cboProductor_TextChanged;

            cboCiudadCruce.TextChanged += cboCiudadCruce_TextChanged;

            cboCiudadDestino.TextChanged += cboCiudadDestino_TextChanged;
        }
    }
    public static class ControlExtensions
    {
        public static string MensajeVacio { get; set; }
        public static Control ControlRelacionado { get; set; }
    }


}
