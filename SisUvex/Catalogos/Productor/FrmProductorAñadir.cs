
namespace SisUvex.Catalogos.Productor
{
    public partial class FrmProductorAñadir : Form
    {
        public bool añadirModificar = true; //Verdadero para nuevo, falso para modificar
        ClsProductor cls = new ClsProductor();
        public FrmProductorAñadir(FrmProductorCat catalogo)
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
                MessageBox.Show("Debe ingresar el nombre del productor.");
            }
            else
            {
                if (añadirModificar)
                    cls.AñadirProductor(txbNombre.Text, cboActivo.SelectedIndex.ToString(), txbDireccion.Text, txbCiudad.Text, txbRFC.Text, txbTelefono.Text);
                
                else
                    cls.ModificarProductor(txbId.Text, cboActivo.SelectedIndex.ToString(), txbNombre.Text, txbDireccion.Text, txbCiudad.Text, txbRFC.Text, txbTelefono.Text);
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

        private void FrmProductorAñadir_Load(object sender, EventArgs e)
        {
                        
        }

        private void FrmProductorAñadir_FormClosing(object sender, FormClosingEventArgs e)
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
