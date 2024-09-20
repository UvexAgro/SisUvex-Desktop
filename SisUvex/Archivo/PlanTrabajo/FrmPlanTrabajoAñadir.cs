
using Extensiones;
using Microsoft.CodeAnalysis;
using SisUvex.Archivo.PlanTrabajo;

namespace SisUvex.Catalogos.PlanTrabajo
{
    public partial class FrmPlanTrabajoAñadir : Form
    {
        public bool añadirModificar = true; //Verdadero para nuevo, falso para modificar
        ClsPlanTrabajo cls = new ClsPlanTrabajo();
        List<ComboBox> ComboBoxes = new List<ComboBox>();
        List<Control> Obligatorios = new List<Control>();
        public FrmPlanTrabajoAñadir(FrmPlanTrabajoCat catalogo)
        {
            InitializeComponent();

            ComboBoxes.Add(cboLote);
            ComboBoxes.Add(cboCuadrilla);
            ComboBoxes.Add(cboTamaño);
            ComboBoxes.Add(cboTarima);
            ComboBoxes.Add(cboContenedor);
            ComboBoxes.Add(cboTipoContenedor);
            SetObligatorios();
        }
        private void FrmPlanTrabajoAñadir_Load(object sender, EventArgs e)
        {
            dgvPrograma.DataSource = cls.CatalogoPrograma("", "");

            if (!añadirModificar)
            {
                DesactivarTextChanged();
                cls.CargarComboBoxes(ComboBoxes);
                cls.CboIndiceValue(cboCuadrilla, txbIdCuadrilla);
                cls.CboIndiceValue(cboLote, txbIdLote);
                cls.CboIndiceValue(cboTamaño, txbIdTamaño);
                cls.CboIndiceValue(cboTarima, txbIdTarima);
                cls.CboIndiceValue(cboContenedor, txbIdContenedor);
                ActivarTextChanged();
            }
            else
            {
                DesactivarTextChanged();
                cls.CargarComboBoxes(ComboBoxes);
                ActivarTextChanged();
            }
        }
        #region ACTUALIZARHIJO
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

        #endregion FIN ACTUALIZARHIJO
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
                MessageBox.Show("Debe ingresar:\n\n" + vacios, "Añadir plan de trabajo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                if (cls.PlanDisponible(txbIdLote.Text, txbIdPrograma.Text, txbIdCuadrilla.Text, txbIdTamaño.Text, dtpFechaPlan.Value))
                {
                    if (añadirModificar)
                        cls.AñadirPlanTrabajo(txbIdLote.Text, txbIdCuadrilla.Text, txbIdPrograma.Text, txbVPC.Text, dtpFechaPlan.Value.ToString("yyyy-MM-dd"), txbIdTamaño.Text, txbIdTarima.Text, txbIdContenedor.Text);

                    else
                        cls.ModificarPlanTrabajo(txbId.Text, txbIdLote.Text, txbIdCuadrilla.Text, txbIdPrograma.Text, txbVPC.Text, dtpFechaPlan.Value.ToString("yyyy-MM-dd"), txbIdTamaño.Text, txbIdTarima.Text, txbIdContenedor.Text);

                    cls.LimpiarTextBox(this);
                    ActualizarCatalogoHijo();
                    this.Close();
                }
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cls.LimpiarTextBox(this);
            this.Close();
        }
        private void FrmPlanTrabajoAñadir_FormClosing(object sender, FormClosingEventArgs e)
        {
            cls.LimpiarTextBox(this);
        }
        private void DesactivarTextChanged()
        {
            cboCuadrilla.TextChanged -= cboCuadrilla_TextChanged;
            cboLote.TextChanged -= cboLote_TextChanged;
            cboTamaño.TextChanged -= cboTamaño_TextChanged;
            cboTarima.TextChanged -= cboTarima_TextUpdate;
            cboContenedor.TextChanged -= cboContenedor_TextUpdate;
        }
        private void ActivarTextChanged()
        {
            cboCuadrilla.TextChanged += cboCuadrilla_TextChanged;
            cboLote.TextChanged += cboLote_TextChanged;
            cboTamaño.TextChanged += cboTamaño_TextChanged;
            cboTarima.TextChanged += cboTarima_TextUpdate;
            cboContenedor.TextChanged += cboContenedor_TextUpdate;
        }
        private void SetObligatorios()
        {
            Obligatorios.Add(txbId);
            txbId.SetMensajeVacio("Número de plan de trabajo.");
            txbId.SetControlRelacionado(txbId);
            Obligatorios.Add(txbIdLote);
            txbIdLote.SetMensajeVacio("Seleccionar lote.");
            txbIdLote.SetControlRelacionado(txbIdLote);
            Obligatorios.Add(txbIdCuadrilla);
            txbIdCuadrilla.SetMensajeVacio("Seleccionar cuadrilla.");
            txbIdCuadrilla.SetControlRelacionado(txbIdCuadrilla);
            Obligatorios.Add(txbIdPrograma);
            txbIdPrograma.SetMensajeVacio("Seleccionar programa.");
            txbIdPrograma.SetControlRelacionado(txbIdPrograma);
            Obligatorios.Add(txbIdTamaño);
            txbIdTamaño.SetMensajeVacio("Seleccionar tamaño.");
            txbIdTamaño.SetControlRelacionado(txbIdTamaño);
            Obligatorios.Add(txbVPC);
            txbVPC.SetMensajeVacio("VOICE PICK CODE: Debe seleccionar Lote, Fecha y Programa.");
            txbVPC.SetControlRelacionado(txbVPC);
            Obligatorios.Add(txbIdTarima);
            txbIdTarima.SetMensajeVacio("Seleccionar tarima.");
            txbIdTarima.SetControlRelacionado(txbIdTarima);
            Obligatorios.Add(txbIdContenedor);
            txbIdContenedor.SetMensajeVacio("Seleccionar contenedor.");
            txbIdContenedor.SetControlRelacionado(txbIdContenedor);
        }
        private void cboCuadrilla_TextChanged(object sender, EventArgs e)
        {
            txbIdCuadrilla.Text = cls.CboValueDelSeleccionado(cboCuadrilla);
        }
        private void cboLote_TextChanged(object sender, EventArgs e)
        {
            txbIdLote.Text = cls.CboValueDelSeleccionado(cboLote);
            dgvPrograma.DataSource = cls.CatalogoPrograma(txbIdLote.Text, txbIdTipoContenedor.Text);

            if (cls.ProgramaEnListado(txbIdPrograma.Text, dgvPrograma))
            {
                txbVPC.Text = cls.GenerarVoicePickCode(txbIdPrograma.Text, txbIdLote.Text, dtpFechaPlan.Value);
            }
            else
            {
                txbIdPrograma.Text = string.Empty;
                txbVPC.Text = string.Empty;

                cls.CboCargarInicio(cboContenedor, cls.CboMaterialContenedor(txbIdTipoContenedor.Text));
            }
        }
        private void SeleccionarPrograma()
        {
            if (dgvPrograma.Rows.Count > 0)
            {
                DataGridViewRow dgv = dgvPrograma.SelectedRows[0];
                string idPrograma = dgv.Cells["Programa"].Value.ToString();
                txbIdPrograma.Text = idPrograma;


                cls.contenedorSeleccionado(idPrograma, ref cboContenedor);
            }
        }
        private void dgvPrograma_DoubleClick(object sender, EventArgs e)
        {
            SeleccionarPrograma();
            txbVPC.Text = cls.GenerarVoicePickCode(txbIdPrograma.Text, txbIdLote.Text, dtpFechaPlan.Value);
        }
        private void btnIdProgramaSel_Click(object sender, EventArgs e)
        {
            SeleccionarPrograma();
            txbVPC.Text = cls.GenerarVoicePickCode(txbIdPrograma.Text, txbIdLote.Text, dtpFechaPlan.Value);
        }
        private void dtpFechaPlan_ValueChanged(object sender, EventArgs e)
        {
            txbVPC.Text = cls.GenerarVoicePickCode(txbIdPrograma.Text, txbIdLote.Text, dtpFechaPlan.Value);
        }
        private void cboTamaño_TextChanged(object sender, EventArgs e)
        {
            txbIdTamaño.Text = cls.CboValueDelSeleccionado(cboTamaño);
        }

        private void cboContenedor_TextUpdate(object sender, EventArgs e)
        {
            txbIdContenedor.Text = cls.CboValueDelSeleccionado(cboContenedor);
        }

        private void cboTarima_TextUpdate(object sender, EventArgs e)
        {
            txbIdTarima.Text = cls.CboValueDelSeleccionado(cboTarima);
        }

        private void cboTipoContenedor_TextChanged(object sender, EventArgs e)
        {
            txbIdTipoContenedor.Text = cls.CboValueDelSeleccionado(cboTipoContenedor);

            string idProg = txbIdPrograma.Text;
            string idCon = txbIdContenedor.Text;
            string idTipoCon = txbIdTipoContenedor.Text;

            dgvPrograma.DataSource = cls.CatalogoPrograma(txbIdLote.Text, idTipoCon);

            if (cls.ProgramaEnListado(idProg, dgvPrograma))
            {
                txbVPC.Text = cls.GenerarVoicePickCode(idProg, txbIdLote.Text, dtpFechaPlan.Value);
            }
            else
            {
                txbIdPrograma.Text = string.Empty;
                txbVPC.Text = string.Empty;
            }

            cls.CboCargarInicio(cboContenedor, cls.CboMaterialContenedor(idTipoCon));

            if (cls.CboPertenece(cboContenedor, idCon))
            {
                cls.CboIndiceValueTexto(cboContenedor, idCon);
            }
        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            txbIdPrograma.Text = string.Empty;
            cboTipoContenedor.SelectedIndex = -1;
            cls.CboCargarInicio(cboContenedor, cls.CboMaterialContenedor(""));
            dgvPrograma.DataSource = cls.CatalogoPrograma(txbIdLote.Text, "");
        }
    }
}