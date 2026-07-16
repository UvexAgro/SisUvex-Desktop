
namespace SisUvex.Catalogos.Tamaño
{
    public partial class FrmTamañoAñadir : Form
    {
        public bool añadirModificar = true; //Verdadero para nuevo, falso para modificar
        ClsTamaño cls = new ClsTamaño();
        public FrmTamañoAñadir(FrmTamañoCat catalogo)
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
                MessageBox.Show("Debe ingresar el nombre del tamaño.");
            }
            else
            {
                if (añadirModificar)
                    cls.AñadirTamaño(txbNombre.Text, cboActivo.SelectedIndex.ToString());

                else
                    cls.ModificarTamaño(txbId.Text, cboActivo.SelectedIndex.ToString(), txbNombre.Text);
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

        private void FrmTamañoAñadir_Load(object sender, EventArgs e)
        {

        }

        private void FrmTamañoAñadir_FormClosing(object sender, FormClosingEventArgs e)
        {
            cls.LimpiarTextBox(this);
        }
    }
}
