
using System.Globalization;

namespace SisUvex.Catalogos.TipoMaterial
{
    public partial class FrmTipoMaterialAñadir : Form
    {
        public bool añadirModificar = true; //Verdadero para nuevo, falso para modificar
        ClsTipoMaterial cls = new ClsTipoMaterial();
        public FrmTipoMaterialAñadir(FrmTipoMaterialCat catalogo)
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
                MessageBox.Show("Debe ingresar el nombre del tipo de material.");
            }
            else
            {
                if (añadirModificar)
                    cls.AñadirTipoMaterial(txbId.Text.ToUpper(), txbNombre.Text, txbLibras.Text, cboCategoría.Text);
                else
                    cls.ModificarTipoMaterial(txbId.Text.ToUpper(), txbNombre.Text, txbLibras.Text, cboCategoría.Text);

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

        private void FrmTipoMaterialAñadir_Load(object sender, EventArgs e)
        {

        }

        private void FrmTipoMaterialAñadir_FormClosing(object sender, FormClosingEventArgs e)
        {
            cls.LimpiarTextBox(this);
        }

        private void txbLibras_KeyPress(object sender, KeyPressEventArgs e)
        {
            cls.TxbTeclasDecimales(sender, e);
        }

        private void txbLibras_TextChanged(object sender, EventArgs e)
        {
            cls.TxbFormatoNumeric((TextBox)sender, 1000);
        }
    }
}
