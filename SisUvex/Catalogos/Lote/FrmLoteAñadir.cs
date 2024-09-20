using Extensiones;

namespace SisUvex.Catalogos.Lote
{
    public partial class FrmLoteAñadir : Form
    {
        public bool añadirModificar = true; //Verdadero para nuevo, falso para modificar
        ClsLote cls = new ClsLote();
        List<Control> Obligatorios = new List<Control>();
        public FrmLoteAñadir(FrmLoteCat catalogo)
        {
            InitializeComponent();
            SetObligatorios();
        }
        private void FrmLoteAñadir_Load(object sender, EventArgs e)
        {
            if (!añadirModificar)
            {
                DesactivarTextChanged();

                cls.CboCargarInicio(cboVariedad, cls.CboVariedad("", "*",""));
                cls.CboIndiceValue(cboVariedad, txbIdVariedad);
                ActivarTextChanged();
            }
            else
            {
                cls.CboCargarInicio(cboVariedad, cls.CboVariedad("", "*", ""));
            }
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
                vacios = vacios + cls.SpnEsFechaObligatoria(spnFecha);
                if (vacios != "")
                    MessageBox.Show("Debe ingresar:\n\n" + vacios, "Añadir distribuidor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    if (añadirModificar)
                    {
                        if (cls.ComprobarId(spnId.Text, txbIdVariedad.Text))
                        {
                            MessageBox.Show($"El código de lote {spnId.Text} con la variedad ({cboVariedad.Text}) ya existe.", "Añadir distribuidor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        }
                        else
                        {
                            cls.AñadirLote(spnId.Text, txbNombre.Text, cboActivo.SelectedIndex.ToString(), txbIdVariedad.Text, txbHectareas.Text, spnFecha.Text);
                        }
                    }
                    else
                        cls.ModificarLote(spnId.Text, txbNombre.Text, cboActivo.SelectedIndex.ToString(), txbIdVariedad.Text, float.Parse(txbHectareas.Text), spnFecha.Text);
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

        private void FrmLoteAñadir_FormClosing(object sender, FormClosingEventArgs e)
        {
            cls.LimpiarTextBox(this);
        }
        private void SetObligatorios()
        {
            Obligatorios.Add(txbNombre);
            Obligatorios.Add(spnId);
            Obligatorios.Add(txbIdVariedad);
            Obligatorios.Add(txbHectareas);

            txbNombre.SetMensajeVacio("Nombre del lote.");
            txbNombre.SetControlRelacionado(txbNombre);
            spnId.SetMensajeVacio("Id del lote.");
            spnId.SetControlRelacionado(spnId);
            txbIdVariedad.SetMensajeVacio("Seleccionar una variedad.");
            txbIdVariedad.SetControlRelacionado(txbIdVariedad);
            txbHectareas.SetMensajeVacio("Hectareas.");
            txbHectareas.SetControlRelacionado(txbHectareas);
        }
        private void DesactivarTextChanged()
        {
            cboVariedad.TextChanged -= cboVariedad_TextChanged;
        }
        private void ActivarTextChanged()
        {
            cboVariedad.TextChanged += cboVariedad_TextChanged;
        }

        #region VARIEDAD ----------------------------------------------------------------
        private void cboVariedad_MouseClick(object sender, MouseEventArgs e)
        {
            cls.CboPrimerClic(cboVariedad);
        }
        private void btnBuscarVariedad_Click(object sender, EventArgs e)
        {
            cls.BtnBuscarVariedad(cboVariedad, "00");
        }

        private void btnTodoVariedad_Click(object sender, EventArgs e)
        {
            txbIdVariedad.Text = cls.BtnTodoVariedad(cboVariedad, "00");
            if (cls.ActVar)
                btnTodoVariedad.Text = "Activo";
            else
                btnTodoVariedad.Text = "Todo";
        }
        private void cboVariedad_TextChanged(object sender, EventArgs e)
        {
            txbIdVariedad.Text = cls.CboValueDelSeleccionado(cboVariedad);
        }

        #endregion FIN VARIEDAD ---------------------------------------------------------

        private void txbHectareas_KeyPress(object sender, KeyPressEventArgs e)
        {
            cls.TxbTeclasDecimales(sender, e);
        }

        private void txbHectareas_TextChanged(object sender, EventArgs e)
        {
            cls.TxbFormatoNumeric((TextBox)sender, 10000);
        }
    }
}
