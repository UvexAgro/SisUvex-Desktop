
using Extensiones;
using SisUvex.Catalogos.Distribuidor;

namespace SisUvex.Catalogos.Cuadrilla
{
    public partial class FrmCuadrillaAñadir : Form
    {
        public bool añadirModificar = true; //Verdadero para nuevo, falso para modificar
        ClsCuadrilla cls = new ClsCuadrilla();
        List<ComboBox> ComboBoxes = new List<ComboBox>();
        List<Control> Obligatorios = new List<Control>();
        public FrmCuadrillaAñadir(FrmCuadrillaCat catalogo)
        {
            InitializeComponent();
            txbId.Enabled = añadirModificar;
            ComboBoxes.Add(cboContratista);
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
                {
                    if (cls.IdDisponible(txbId.Text))
                        cls.AñadirCuadrilla(txbId.Text, txbIdContratista.Text, txbName.Text);
                }
                else
                    cls.ModificarCuadrilla(txbId.Text, txbIdContratista.Text, txbName.Text);

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

        private void FrmCuadrillaAñadir_Load(object sender, EventArgs e)
        {
            if (!añadirModificar)
            {
                txbId.Enabled = false;
                DesactivarTextChanged();

                cls.CboCargarInicio(cboContratista, cls.CboContratista("", "*"));
                cls.CboIndiceValue(cboContratista, txbIdContratista);

                ActivarTextChanged();
            }
            else
            {
                cls.CboCargarInicio(cboContratista, cls.CboContratista("", "*"));
            }
        }

        private void FrmCuadrillaAñadir_FormClosing(object sender, FormClosingEventArgs e)
        {
            cls.LimpiarTextBox(this);
        }

        private void DesactivarTextChanged()
        {
            cboContratista.TextChanged -= cboContratista_TextChanged;
        }
        private void ActivarTextChanged()
        {
            cboContratista.TextChanged += cboContratista_TextChanged;
        }

        private void SetObligatorios()
        {
            Obligatorios.Add(txbId);
            Obligatorios.Add(txbIdContratista);

            txbId.SetMensajeVacio("Número de cuadrilla.");
            txbId.SetControlRelacionado(txbId);
            txbIdContratista.SetMensajeVacio("Seleccionar un contratista.");
            txbIdContratista.SetControlRelacionado(txbIdContratista);
        }
        private void cboContratista_MouseClick(object sender, MouseEventArgs e)
        {
            cls.CboPrimerClic(cboContratista);
        }
        private void btnBuscarContratista_Click(object sender, EventArgs e)
        {
            cls.BtnBuscarContratista(cboContratista);
        }
        private void btnTodoContratista_Click(object sender, EventArgs e)
        {
            txbIdContratista.Text = cls.BtnTodoContratista(cboContratista);
            if (cls.ActDis)
                btnTodoContratista.Text = "Activo";
            else
                btnTodoContratista.Text = "Todo";
        }
        private void cboContratista_TextChanged(object sender, EventArgs e)
        {
            txbIdContratista.Text = cls.CboValueDelSeleccionado(cboContratista);
        }
    }
}
