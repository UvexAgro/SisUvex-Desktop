
using DocumentFormat.OpenXml.Vml.Spreadsheet;
using Extensiones;
using SisUvex.Catalogos.Distribuidor;

namespace SisUvex.Catalogos.Variedad
{
    public partial class FrmVariedadAñadir : Form
    {
        public bool añadirModificar = true; //Verdadero para nuevo, falso para modificar
        ClsVariedad cls = new ClsVariedad();
        List<Control> Obligatorios = new List<Control>();

        public FrmVariedadAñadir(FrmVariedadCat catalogo)
        {
            InitializeComponent();
            cls.CboCargarInicio(cboColor, cls.CboColor(""));
            cls.CboCargarInicio(cboCultivo, cls.CboCultivo());

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
                    cls.AñadirVariedad(cboActivo.SelectedIndex.ToString(), txbNomCientifico.Text, txbNomComercial.Text, txbIdColor.Text, txbIdCultivo.Text, txbNomCorto.Text);
                else
                    cls.ModificarVariedad(txbId.Text, cboActivo.SelectedIndex.ToString(), txbNomCientifico.Text, txbNomComercial.Text, txbIdColor.Text, txbIdCultivo.Text, txbNomCorto.Text);
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

        private void FrmVariedadAñadir_Load(object sender, EventArgs e)
        {
            if (!añadirModificar)
            {
                DesactivarTextChanged();

                cls.CboCargarInicio(cboColor, cls.CboColor(""));
                cls.CboIndiceValue(cboColor, txbIdColor);
                cls.CboCargarInicio(cboCultivo, cls.CboCultivo());
                cls.CboIndiceValue(cboCultivo, txbIdCultivo);

                ActivarTextChanged();
            }
            else
            {
                cls.CboCargarEnBlanco(cboColor, cls.CboColor(""));
                cls.CboCargarEnBlanco(cboCultivo, cls.CboCultivo());
            }
        }

        private void FrmVariedadAñadir_FormClosing(object sender, FormClosingEventArgs e)
        {
            cls.LimpiarTextBox(this);
        }

        private void cboColor_TextChanged(object sender, EventArgs e)
        {
            txbIdColor.Text = cls.CboValueDelSeleccionado(cboColor);
        }
        private void SetObligatorios()
        {
            Obligatorios.Add(txbNomComercial);
            Obligatorios.Add(txbIdColor);
            Obligatorios.Add(txbIdCultivo);

            txbNomComercial.SetMensajeVacio("Nombre comercial.");
            txbNomComercial.SetControlRelacionado(txbNomComercial);
            txbIdColor.SetMensajeVacio("Seleccionar un Color.");
            txbIdColor.SetControlRelacionado(txbIdColor);
            txbIdCultivo.SetMensajeVacio("Seleccionar un Cultivo.");
            txbIdCultivo.SetControlRelacionado(txbIdCultivo);

        }
        private void DesactivarTextChanged()
        {
            cboColor.TextChanged -= cboColor_TextChanged;
            cboCultivo.TextChanged -= cboCultivo_TextChanged;

        }
        private void ActivarTextChanged()
        {
            cboColor.TextChanged += cboColor_TextChanged;
            cboCultivo.TextChanged += cboCultivo_TextChanged;
        }

        private void cboCultivo_TextChanged(object sender, EventArgs e)
        {
            txbIdCultivo.Text = cls.CboValueDelSeleccionado(cboCultivo);
        }
    }
}
