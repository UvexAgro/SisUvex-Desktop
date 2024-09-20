
using Extensiones;

namespace SisUvex.Catalogos.Chofer
{
    public partial class FrmChoferAñadir : Form
    {
        public bool añadirModificar = true; //Verdadero para nuevo, falso para modificar
        ClsChofer cls = new ClsChofer();
        List<ComboBox> ComboBoxes = new List<ComboBox>();
        List<Control> Obligatorios = new List<Control>();
        public FrmChoferAñadir(FrmChoferCat catalogo)
        {
            InitializeComponent();
            ComboBoxes.Add(cboLinea);
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
            vacios = vacios + cls.SpnEsFecha(spnFecha);
            if (vacios != "")
                MessageBox.Show("Debe ingresar:\n\n" + vacios, "Añadir Chofer", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                if (añadirModificar)
                    cls.AñadirChofer(cboActivo.SelectedIndex.ToString(), txbIdLinea.Text, txbNombre.Text, txbApellidos.Text, txbLicencia.Text, txbVisa.Text, spnFecha.Text);

                else
                    cls.ModificarChofer(txbId.Text, cboActivo.SelectedIndex.ToString(), txbIdLinea.Text, txbNombre.Text, txbApellidos.Text, txbLicencia.Text, txbVisa.Text, spnFecha.Text);

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

        private void FrmChoferAñadir_Load(object sender, EventArgs e)
        {
            if (!añadirModificar)
            {
                DesactivarTextChanged();

                cls.CboCargarInicio(cboLinea, cls.CboLinea("", "*"));
                cls.CboIndiceValue(cboLinea, txbIdLinea);

                ActivarTextChanged();
            }
            else
            {
                cls.CboCargarInicio(cboLinea, cls.CboLinea("", "*"));
            }
        }

        private void FrmChoferAñadir_FormClosing(object sender, FormClosingEventArgs e)
        {
            cls.LimpiarTextBox(this);
        }

        private void DesactivarTextChanged()
        {
            cboLinea.TextChanged -= cboLinea_TextChanged;
        }
        private void ActivarTextChanged()
        {
            cboLinea.TextChanged += cboLinea_TextChanged;
        }

        private void SetObligatorios()
        {
            Obligatorios.Add(txbId);
            Obligatorios.Add(txbIdLinea);
            Obligatorios.Add(txbNombre);
            Obligatorios.Add(txbApellidos);

            txbId.SetMensajeVacio("Código del chofer.");
            txbId.SetControlRelacionado(txbId);
            txbIdLinea.SetMensajeVacio("Seleccionar una Línea de transporte.");
            txbIdLinea.SetControlRelacionado(txbIdLinea);
            txbNombre.SetMensajeVacio("Nombre del chofer.");
            txbNombre.SetControlRelacionado(txbNombre);
            txbApellidos.SetMensajeVacio("Apellidos del chofer.");
            txbApellidos.SetControlRelacionado(txbApellidos);
        }
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
            if (cls.ActCho)
                btnTodoLinea.Text = "Activo";
            else
                btnTodoLinea.Text = "Todo";
        }
        private void cboLinea_TextChanged(object sender, EventArgs e)
        {
            txbIdLinea.Text = cls.CboValueDelSeleccionado(cboLinea);
        }
    }
}