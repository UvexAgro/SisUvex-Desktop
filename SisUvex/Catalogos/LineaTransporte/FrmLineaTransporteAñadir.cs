
namespace SisUvex.Catalogos.LineaTransporte
{
    public partial class FrmLineaTransporteAñadir : Form
    {
        public bool añadirModificar = true; //Verdadero para nuevo, falso para modificar
        ClsLineaTransporte cls = new ClsLineaTransporte();
        public FrmLineaTransporteAñadir(FrmLineaTransporteCat catalogo)
        {
            InitializeComponent();
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
            if (txbNombre.Text == string.Empty)
            {
                txbNombre.Focus();
                MessageBox.Show("Debe ingresar el nombre del línea de transporte.");
            }
            else
            {
                if (añadirModificar)
                    cls.AñadirLineaTransporte(txbNombre.Text, cboActivo.SelectedIndex.ToString(), txbDireccion.Text, txbCiudad.Text, txbRFC.Text, txbTelefono.Text, txbSCAC.Text, txbSCAAT.Text);

                else
                    cls.ModificarLineaTransporte(txbId.Text, cboActivo.SelectedIndex.ToString(), txbNombre.Text, txbDireccion.Text, txbCiudad.Text, txbRFC.Text, txbTelefono.Text, txbSCAC.Text, txbSCAAT.Text);
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

        private void FrmLineaTransporteAñadir_Load(object sender, EventArgs e)
        {

        }

        private void FrmLineaTransporteAñadir_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
