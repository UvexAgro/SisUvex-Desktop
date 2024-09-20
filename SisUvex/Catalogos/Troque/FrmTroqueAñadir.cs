
using Extensiones;

namespace SisUvex.Catalogos.Troque
{
    public partial class FrmTroqueAñadir : Form
    {
        public bool añadirModificar = true; //Verdadero para nuevo, falso para modificar
        ClsTroque cls = new ClsTroque();
        List<ComboBox> ComboBoxes = new List<ComboBox>();
        List<Control> Obligatorios = new List<Control>();
        public FrmTroqueAñadir(FrmTroqueCat catalogo)
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
            if (vacios != "")
                MessageBox.Show("Debe ingresar:\n\n" + vacios, "Añadir Troque", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                if (añadirModificar)
                    cls.AñadirTroque(cboActivo.SelectedIndex.ToString(), txbIdLinea.Text, txbNumEco.Text, txbPlacasUS.Text, txbPlacasMX.Text, txbModelo.Text, txbMarca.Text, txbVIN.Text, txbColor.Text);

                else
                    cls.ModificarTroque(txbId.Text, cboActivo.SelectedIndex.ToString(), txbIdLinea.Text, txbNumEco.Text, txbPlacasUS.Text, txbPlacasMX.Text, txbModelo.Text, txbMarca.Text, txbVIN.Text, txbColor.Text);

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

        private void FrmTroqueAñadir_Load(object sender, EventArgs e)
        {
            if (!añadirModificar)
            {
                txbId.Enabled = false;
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

        private void FrmTroqueAñadir_FormClosing(object sender, FormClosingEventArgs e)
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
            Obligatorios.Add(txbNumEco);

            txbId.SetMensajeVacio("Código del troque.");
            txbId.SetControlRelacionado(txbId);
            txbIdLinea.SetMensajeVacio("Seleccionar una Línea de transporte.");
            txbIdLinea.SetControlRelacionado(txbIdLinea);
            txbNumEco.SetMensajeVacio("Número económico del troque.");
            txbNumEco.SetControlRelacionado(txbNumEco);
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

        private void txbModelo_KeyPress(object sender, KeyPressEventArgs e)
        {
            cls.TxbTeclasEnteros(e);
        }
    }
}