
namespace SisUvex.Catalogos.AgenciaAduanal
{
    public partial class FrmAgenciaAduanalAñadir : Form
    {
        public bool añadirModificar = true; //Verdadero para nuevo, falso para modificar
        ClsAgenciaAduanal cls = new ClsAgenciaAduanal();
        public FrmAgenciaAduanalAñadir(FrmAgenciaAduanalCat catalogo)
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
                MessageBox.Show("Debe ingresar el nombre del agenciaAduanal.");
            }
            else
            {
                if (añadirModificar)
                    cls.AñadirAgenciaAduanal(txbNombre.Text, cboActivo.SelectedIndex.ToString(), cboPais.Text, txbCiudad.Text, txbDireccion.Text, txbRFC.Text);
                else
                    cls.ModificarAgenciaAduanal(txbId.Text, cboActivo.SelectedIndex.ToString(), txbNombre.Text, cboPais.Text, txbCiudad.Text, txbDireccion.Text, txbRFC.Text);
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

        private void FrmAgenciaAduanalAñadir_Load(object sender, EventArgs e)
        {

        }

        private void FrmAgenciaAduanalAñadir_FormClosing(object sender, FormClosingEventArgs e)
        {
            cls.LimpiarTextBox(this);
        }
    }
}
