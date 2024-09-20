
using Extensiones;
using SisUvex.Archivo.Impresoras;
using SisUvex.Configuracion;

namespace SisUvex.Catalogos.PlantillaV1
{
    public partial class FrmPlantillaV1Añadir : Form
    {
        public bool añadirModificar = true; //Verdadero para nuevo, falso para modificar
        ClsPlantillaV1 cls = new ClsPlantillaV1();
        List<ComboBox> ComboBoxes = new List<ComboBox>();
        List<Control> Obligatorios = new List<Control>();
        public FrmPlantillaV1Añadir()
        {
            InitializeComponent();
            txbId.Enabled = añadirModificar;
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
            ClsConfPrinter confPrinter = new ClsConfPrinter();
            confPrinter.Leer();
            MessageBox.Show(ClsPrinter.GetPrinterOrientation(ClsConfPrinter.PrintPallet));
            //string vacios = "";
            //foreach (Control control in Obligatorios)
            //{
            //    if (control.Text == string.Empty)
            //    {
            //        vacios = vacios + control.GetMensajeVacio() + "\r\n";
            //        control.GetControlRelacionado().Focus();
            //    }
            //}
            //if (vacios != "")
            //    MessageBox.Show("Debe ingresar:\n\n" + vacios, "Añadir distribuidor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //else
            //{
            //    if (añadirModificar)
            //        cls.AñadirPlantillaV1(txbId.Text, txbIdLinea.Text);

            //    else
            //        cls.ModificarPlantillaV1(txbId.Text, txbIdLinea.Text);

            //    cls.LimpiarTextBox(this);
            //    ActualizarCatalogoHijo();
            //    this.Close();
            //}
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cls.LimpiarTextBox(this);
            this.Close();
        }

        private void FrmPlantillaV1Añadir_Load(object sender, EventArgs e)
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

        private void FrmPlantillaV1Añadir_FormClosing(object sender, FormClosingEventArgs e)
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

            txbId.SetMensajeVacio("Nombre de plantillaV1.");
            txbId.SetControlRelacionado(txbId);
            txbIdLinea.SetMensajeVacio("Seleccionar una Línea de transporte.");
            txbIdLinea.SetControlRelacionado(txbIdLinea);
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