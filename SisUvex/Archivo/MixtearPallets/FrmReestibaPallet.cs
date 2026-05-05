/*
 * FrmReestibaPallet.cs
 * ====================================================================================
 * Diálogo modal para ejecutar una reestiba (división) de un pallet
 * directamente desde el formulario FrmMixtearPallets, sin salir del flujo.
 *
 * FLUJO DE USO:
 *   1. FrmMixtearPallets.btnReestibar_Click() instancia este diálogo con
 *      el PalletInfo del pallet seleccionado y la lista de TipoReestiba.
 *   2. El usuario configura:
 *        • NuevasCajas: cuántas cajas quedarán en el pallet ORIGINAL.
 *        • TipoSeleccionado: tipo de reestiba (SOBRANTE, SINIESTRADO, etc.).
 *   3. Al confirmar (DialogResult.OK), FrmMixtearPallets lee las propiedades
 *      públicas NuevasCajas, TipoSeleccionado y EsReestibaCompleta.
 *      - Si EsReestibaCompleta == true  → ClsMixtearPallets.EjecutarReestibaCompleta()
 *      - Si EsReestibaCompleta == false → ClsMixtearPallets.EjecutarReestiba()
 *
 * PROPIEDADES PÚBLICAS (resultado):
 *   NuevasCajas        → int: cajas configuradas para el pallet original.
 *   TipoSeleccionado   → TipoReestiba: tipo elegido.
 *   EsReestibaCompleta → bool: true si se seleccionaron TODAS las cajas del pallet
 *                        (no se creará pallet nuevo, solo se asigna el motivo).
 *
 * ESCALABILIDAD:
 *   → Para agregar opciones adicionales (ej. motivo, observaciones), agregar
 *     controles en el Designer y propiedades públicas aquí.
 * ====================================================================================
 */

namespace SisUvex.Archivo.MixtearPallets
{
    /// <summary>
    /// Diálogo modal para configurar y confirmar la reestiba de un pallet.
    /// Instanciar con el PalletInfo del pallet a dividir y los tipos disponibles.
    /// </summary>
    internal partial class FrmReestibaPallet : Form
    {
        // ── Datos de entrada ────────────────────────────────────────────────────────
        private readonly PalletInfo         _pallet;           // Pallet seleccionado
        private readonly List<TipoReestiba> _tipos;            // Tipos activos de Pack_PalletUnstowType
        private readonly int?               _cajasIniciales;   // Pre-selección para modo asistido

        // ── Resultado accesible por el formulario padre ─────────────────────────────

        /// <summary>
        /// Número de cajas que quedarán en el pallet ORIGINAL.
        /// Si EsReestibaCompleta == true, este valor == _pallet.Cajas.
        /// </summary>
        public int NuevasCajas { get; private set; }

        /// <summary>
        /// Tipo de reestiba seleccionado.
        /// </summary>
        public TipoReestiba TipoSeleccionado { get; private set; } = new();

        /// <summary>
        /// Indica que se seleccionaron TODAS las cajas: no se crea pallet nuevo,
        /// el motivo se asigna directamente al pallet original.
        /// </summary>
        public bool EsReestibaCompleta { get; private set; }

        /// <param name="pallet">PalletInfo del pallet a dividir</param>
        /// <param name="tipos">Lista de tipos activos de Pack_PalletUnstowType</param>
        /// <param name="cajasIniciales">
        /// Si se provee, pre-selecciona numCajas con este valor (cajas que quedan en el original).
        /// Usado por "Ajuste asistido" para recomendar la división óptima.
        /// Si es null, se usa el valor por defecto (pallet.Cajas - 1).
        /// </param>
        public FrmReestibaPallet(PalletInfo pallet, List<TipoReestiba> tipos, int? cajasIniciales = null)
        {
            InitializeComponent();
            _pallet         = pallet;
            _tipos          = tipos;
            _cajasIniciales = cajasIniciales;
        }

        // ============================================================================
        // CARGA DEL FORMULARIO
        // ============================================================================

        private void FrmReestibaPallet_Load(object sender, EventArgs e)
        {
            // ── Información del pallet ────────────────────────────────────────────
            lblPalletVal.Text   = _pallet.IdPallet;
            lblCajasActVal.Text = _pallet.Cajas.ToString();
            lblProgramaVal.Text = string.IsNullOrEmpty(_pallet.Programa) ? "(sin programa)" : _pallet.Programa;
            lblEstibaVal.Text   = string.IsNullOrEmpty(_pallet.Estiba)   ? "(sin estiba)"   : _pallet.Estiba;

            // ── Rango del NumericUpDown ───────────────────────────────────────────
            // Mínimo: 1 caja.  Máximo: TODAS las cajas (permite reestiba completa).
            numCajas.Minimum = 1;
            numCajas.Maximum = Math.Max(1, _pallet.Cajas);
            // Si se recibió una recomendación, usarla; si no, el default es conservar casi todo
            numCajas.Value = _cajasIniciales.HasValue
                ? Math.Max(1, Math.Min(_pallet.Cajas, _cajasIniciales.Value))
                : Math.Max(1, _pallet.Cajas - 1);

            // ── Tipos de reestiba ─────────────────────────────────────────────────
            cboTipo.DataSource    = _tipos;
            cboTipo.DisplayMember = "Nombre";
            cboTipo.ValueMember   = "IdTipo";
            if (_tipos.Count > 0) cboTipo.SelectedIndex = 0;

            ActualizarSobrantesYDescripcion();
        }

        // ============================================================================
        // EVENTOS DE CONTROLES
        // ============================================================================

        private void numCajas_ValueChanged(object sender, EventArgs e)
            => ActualizarSobrantesYDescripcion();

        /// <summary>
        /// Se dispara en cada pulsación de tecla en el NumericUpDown.
        /// Garantiza que las cajas sobrantes se actualicen sin necesidad de usar las flechas.
        /// </summary>
        private void numCajas_TextChanged(object sender, EventArgs e)
            => ActualizarSobrantesYDescripcion();

        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
            => ActualizarSobrantesYDescripcion();

        // ── Confirmar reestiba ──────────────────────────────────────────────────────

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (cboTipo.SelectedItem is not TipoReestiba tipoElegido)
            {
                MessageBox.Show("Seleccione el tipo de reestiba antes de confirmar.",
                    "Tipo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Leer valor actual (funciona tanto con teclado como con flechas)
            int nuevas = int.TryParse(numCajas.Text, out int v) ? v : (int)numCajas.Value;
            nuevas     = Math.Max((int)numCajas.Minimum, Math.Min((int)numCajas.Maximum, nuevas));

            bool completa   = nuevas == _pallet.Cajas;
            int  sobrantes  = _pallet.Cajas - nuevas;

            string resumen;
            if (completa)
            {
                resumen =
                    $"¿Confirma la reestiba COMPLETA del pallet {_pallet.IdPallet}?\n\n" +
                    $"  Tipo/Motivo: {tipoElegido.Nombre}\n" +
                    $"  Cajas: {_pallet.Cajas} (TODAS)\n\n" +
                    "No se creará un pallet nuevo.\n" +
                    (tipoElegido.NuevoPalletActivo
                        ? "El pallet PERMANECERÁ ACTIVO."
                        : "El pallet quedará INACTIVO.");
            }
            else
            {
                if (sobrantes <= 0)
                {
                    MessageBox.Show(
                        "Las cajas sobrantes deben ser mayor a 0.\n" +
                        "Ajuste el número de cajas para el pallet original.",
                        "Configuración inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                resumen =
                    $"¿Confirma la reestiba?\n\n" +
                    $"  Pallet original {_pallet.IdPallet}: {nuevas} caja(s).\n" +
                    $"  Nuevo pallet ({tipoElegido.Nombre}): {sobrantes} caja(s).\n\n" +
                    (tipoElegido.NuevoPalletActivo
                        ? "El nuevo pallet quedará ACTIVO (sobrante disponible)."
                        : "El nuevo pallet quedará INACTIVO.");
            }

            var confirm = MessageBox.Show(resumen, "Confirmar Reestiba",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            NuevasCajas        = nuevas;
            TipoSeleccionado   = tipoElegido;
            EsReestibaCompleta = completa;
            DialogResult       = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        // ============================================================================
        // UTILIDADES INTERNAS
        // ============================================================================

        /// <summary>
        /// Recalcula cajas sobrantes en tiempo real.
        /// Lee numCajas.Text para capturar también valores escritos con teclado.
        /// Cuando se seleccionan TODAS las cajas, muestra aviso de "Reestiba Completa".
        /// </summary>
        private void ActualizarSobrantesYDescripcion()
        {
            // Guardia: TextChanged puede dispararse durante InitializeComponent, antes de que
            // _pallet esté asignado (en Load). Ignorar si aún no hay datos.
            if (_pallet is null) return;

            // Leer desde el texto para actualizarse al tipear (no solo al perder foco)
            int cajas     = int.TryParse(numCajas.Text, out int v) ? v : (int)numCajas.Value;
            cajas         = Math.Max((int)numCajas.Minimum, Math.Min((int)numCajas.Maximum, cajas));
            int sobrantes = _pallet.Cajas - cajas;

            if (sobrantes == 0)
            {
                // Reestiba completa: no habrá nuevo pallet
                txbCajasSobrantes.Text      = "0";
                txbCajasSobrantes.ForeColor = Color.DarkOrange;
                lblSobrantesInfo.Text       = "           ⚠ REESTIBA COMPLETA\n–  No se creará un pallet nuevo";
                lblSobrantesInfo.ForeColor  = Color.DarkOrange;
            }
            else
            {
                txbCajasSobrantes.Text      = sobrantes.ToString();
                txbCajasSobrantes.ForeColor = Color.DarkGreen;
                lblSobrantesInfo.Text       = "           (calculado)";
                lblSobrantesInfo.ForeColor  = Color.Gray;
            }

            // Descripción del tipo seleccionado
            if (cboTipo.SelectedItem is TipoReestiba tipo)
            {
                lblDescripcion.Text = string.IsNullOrEmpty(tipo.Descripcion)
                    ? ""
                    : $"ℹ {tipo.Descripcion}";
            }
        }
    }
}
