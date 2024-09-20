using Extensiones;

namespace SisUvex.Catalogos.Material
{
    public partial class FrmMaterialAñadir : Form
    {

        public bool añadirModificar = true; //Verdadero para nuevo, falso para modificar
        ClsMaterial cls = new ClsMaterial();
        List<ComboBox> ComboBoxes = new List<ComboBox>();
        List<Control> Obligatorios = new List<Control>();
        public FrmMaterialAñadir(FrmMaterialCat catalogo)
        {
            InitializeComponent();
            ComboBoxes.Add(cboTipoMat);
            ComboBoxes.Add(cboDistribuidor);
            ComboBoxes.Add(cboColor);
            ComboBoxes.Add(cboUnidad);
            SetObligatorios();
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
        private void FrmMaterialAñadir_Load(object sender, EventArgs e)
        {
            if (!añadirModificar)
            {
                btnTodoMatTipo.Enabled = false;
                btnBuscarMatTipo.Enabled = false;
                DesactivarTextChanged();

                cls.CargarComboBoxes(ComboBoxes);
                cls.CboIndiceValue(cboTipoMat, txbIdTipo);
                cls.CboIndiceValue(cboDistribuidor, txbIdDistribuidor);
                cls.CboIndiceValue(cboColor, txbIdColor);
                cls.CboIndiceValue(cboUnidad, txbIdUnidad);

                ActivarTextChanged();
            }
            else
            {
                cls.CargarComboBoxes(ComboBoxes);
            }
        }
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
                    cls.AñadirMaterial(txbIdTipo.Text.ToUpper(), txbNombre.Text, txbNombreEnEtiqueta.Text, txbCantidad.Text, txbCantidadPorUnidad.Text, txbIdDistribuidor.Text, txbIdColor.Text, txbIdUnidad.Text);
                else
                    cls.ModificarMaterial(txbId.Text, txbNombre.Text, txbNombreEnEtiqueta.Text, txbCantidad.Text, txbCantidadPorUnidad.Text, txbIdDistribuidor.Text, txbIdColor.Text, txbIdUnidad.Text);

                cls.LimpiarTextBox(this);
                ActualizarCatalogoHijo();
                this.Close();
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cls.LimpiarTextBox(this);
            this.Close();
        }
        private void FrmMaterialAñadir_FormClosing(object sender, FormClosingEventArgs e)
        {
            cls.LimpiarTextBox(this);
        }
        private void txbCantidadPorunidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            cls.TxbTeclasDecimales(sender, e);
        }
        private void txbCantidadPorUnidad_TextChanged(object sender, EventArgs e)
        {
            cls.TxbFormatoNumeric((TextBox)sender, 10000);
        }
        #region TIPO MATERIAL---------------------------------------------------------------
        private void cboTipoMat_MouseClick(object sender, MouseEventArgs e)
        {
            cboTipoMat.TextChanged += cboTipoMat_TextChanged;

            cls.CboPrimerClic(cboTipoMat);
        }
        private void btnBuscarMatTipo_Click(object sender, EventArgs e)
        {
            txbIdTipo.Text = cls.BtnBuscarMatTipo(cboTipoMat);
        }

        private void btnTodoMatTipo_Click(object sender, EventArgs e)
        {
            txbIdTipo.Text = cls.BtnTodoMatTipo(cboTipoMat, cboTipoMat_TextChanged);
            txbId.Text = string.Empty;
            //pruebas con el cboTipoMat_TextChanged (tambien en la clase de ClsCatalogos)
        }

        private void cboTipoMat_TextChanged(object sender, EventArgs e)
        {
            txbIdTipo.Text = cls.CboValueDelSeleccionado(cboTipoMat);
        }

        #endregion FIN TIPO MATERIAL---------------------------------------------------------

        #region DISTRIBUIDOR-----------------------------------------------------------------
        private void cboDistribuidor_MouseClick(object sender, MouseEventArgs e)
        {
            cls.CboPrimerClic(cboDistribuidor);
        }
        private void btnBuscarDistribuidor_Click(object sender, EventArgs e)
        {
            cls.BtnBuscarDistribuidor(cboDistribuidor);
        }
        private void btnTodoDistribuidor_Click(object sender, EventArgs e)
        {
            cls.BtnTodoDistribuidor(txbIdDistribuidor, cboDistribuidor, btnTodoDistribuidor);
        }
        private void cboDistribuidor_TextChanged(object sender, EventArgs e)
        {
            txbIdDistribuidor.Text = cls.CboValueDelSeleccionado(cboDistribuidor);
        }
        #endregion FIN DISTRIBUIDOR--------------------------------------------------------
        private void cboColor_TextChanged(object sender, EventArgs e)
        {
            txbIdColor.Text = cls.CboValueDelSeleccionado(cboColor);
        }
        private void cboUnidad_TextChanged(object sender, EventArgs e)
        {
            txbIdUnidad.Text = cls.CboValueDelSeleccionado(cboUnidad);
        }
        private void SetObligatorios()
        {

            Obligatorios.Add(txbNombre);
            Obligatorios.Add(txbIdTipo);
            Obligatorios.Add(txbId);
            Obligatorios.Add(txbNombreEnEtiqueta);
            Obligatorios.Add(txbIdColor);
            Obligatorios.Add(cboUnidad);

            txbNombre.SetMensajeVacio("Nombre del Material.");
            txbNombre.SetControlRelacionado(txbNombre);
            txbIdTipo.SetMensajeVacio("Seleccionar un Tipo de material.");
            txbIdTipo.SetControlRelacionado(txbIdTipo);
            txbId.SetMensajeVacio("Seleccionar código de material.");
            txbId.SetControlRelacionado(txbId);
            txbNombreEnEtiqueta.SetMensajeVacio("Nombre en la etiqueta.");
            txbNombreEnEtiqueta.SetControlRelacionado(txbNombreEnEtiqueta);
            txbIdColor.SetMensajeVacio("Seleccionar un Color.");
            txbIdColor.SetControlRelacionado(txbIdColor);
            cboUnidad.SetMensajeVacio("Seleccionar una Unidad de material.");
            cboUnidad.SetControlRelacionado(cboUnidad);
        }
        private void txbCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            cls.TxbTeclasEnteros(e);
        }
        private void DesactivarTextChanged()
        {
            cboTipoMat.TextChanged -= cboTipoMat_TextChanged;

            cboDistribuidor.TextChanged -= cboDistribuidor_TextChanged;

            cboColor.TextChanged -= cboColor_TextChanged;

            cboUnidad.TextChanged -= cboUnidad_TextChanged;
        }
        private void ActivarTextChanged()
        {
            cboTipoMat.TextChanged += cboTipoMat_TextChanged;

            cboDistribuidor.TextChanged += cboDistribuidor_TextChanged;

            cboColor.TextChanged += cboColor_TextChanged;

            cboUnidad.TextChanged += cboUnidad_TextChanged;
        }
        private void txbIdTipo_TextChanged(object sender, EventArgs e)
        {
            if (añadirModificar && cboTipoMat.Text != string.Empty)
            {
                txbId.Text = cls.SiguienteMaterial(txbIdTipo.Text);
            }
        }

    }
}
