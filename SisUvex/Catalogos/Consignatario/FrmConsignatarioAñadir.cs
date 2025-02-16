
using Extensiones;

namespace SisUvex.Catalogos.Consignatario
{
    public partial class FrmConsignatarioAñadir : Form
    {
        public bool añadirModificar = true; //Verdadero para nuevo, falso para modificar
        ClsConsignatario cls = new ClsConsignatario();
        List<Control> Obligatorios = new List<Control>();
        public FrmConsignatarioAñadir(FrmConsignatarioCat catalogo)
        {
            InitializeComponent();
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
                    cls.AñadirConsignatario(cboActivo.SelectedIndex.ToString(), txbNombre.Text, txbIdDistribuidor.Text, txbDireccion.Text, txbCiudad.Text, txbPais.Text, txbRFC.Text, txbTelefono.Text);

                else
                    cls.ModificarConsignatario(txbId.Text, cboActivo.SelectedIndex.ToString(), txbNombre.Text, txbIdDistribuidor.Text, txbDireccion.Text, txbCiudad.Text, txbPais.Text, txbRFC.Text, txbTelefono.Text);

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

        private void FrmConsignatarioAñadir_Load(object sender, EventArgs e)
        {
            if (!añadirModificar)
            {
                txbId.Enabled = false;
                DesactivarTextChanged();

                cls.CboCargarInicio(cboDistribuidor, cls.CboDistribuidor("", "*"));
                cls.CboIndiceValue(cboDistribuidor, txbIdDistribuidor);

                ActivarTextChanged();
            }
            else
            {
                cls.CboCargarInicio(cboDistribuidor, cls.CboDistribuidor("", "*"));
            }
        }

        private void FrmConsignatarioAñadir_FormClosing(object sender, FormClosingEventArgs e)
        {
            cls.LimpiarTextBox(this);
        }

        private void DesactivarTextChanged()
        {
            cboDistribuidor.TextChanged -= cboDistribuidor_TextChanged;
        }
        private void ActivarTextChanged()
        {
            cboDistribuidor.TextChanged += cboDistribuidor_TextChanged;
        }

        private void SetObligatorios()
        {
            Obligatorios.Add(txbNombre);
            Obligatorios.Add(txbIdDistribuidor);

            txbNombre.SetMensajeVacio("Nombre de consignatario.");
            txbNombre.SetControlRelacionado(txbNombre);
            txbIdDistribuidor.SetMensajeVacio("Seleccionar distribuidor.");
            txbIdDistribuidor.SetControlRelacionado(txbIdDistribuidor);
        }
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
            cls.BtnTodoDistribuidor(txbIdDistribuidor,cboDistribuidor,btnTodoDistribuidor);
        }
        
        private void cboDistribuidor_TextChanged(object sender, EventArgs e)
        {
            txbIdDistribuidor.Text = cls.CboValueDelSeleccionado(cboDistribuidor);
        }
    }
}