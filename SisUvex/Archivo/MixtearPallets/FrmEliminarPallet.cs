/*
 * FrmEliminarPallet.cs
 * ====================================================================================
 * Formulario modal para eliminar (marcar como inactivo) un pallet completo.
 *
 * FUNCIONAMIENTO:
 *   - Utiliza el mecanismo de reestiba COMPLETA: todo el pallet se marca con un motivo
 *     de tipo inactivo (c_activeInPallet = '0'). No se crea ningún pallet nuevo.
 *   - Solo muestra tipos de reestiba donde el pallet queda INACTIVO (c_activeInPallet='0'):
 *     SINIESTRADO, ERROR, CORTESÍA, REEMPAQUE, etc.
 *   - No permite seleccionar tipos que dejen el pallet activo (ej. SOBRANTE).
 *
 * USO DESDE OTRO FORMULARIO:
 *   var frm = new FrmEliminarPallet(palletInfo);
 *   if (frm.ShowDialog() == DialogResult.OK)
 *   {
 *       // El pallet ya fue marcado como inactivo en DB.
 *       // frm.TipoSeleccionado contiene el tipo usado.
 *   }
 *
 * ESCALABILIDAD:
 *   → Para mostrar más información del pallet, agregar propiedades en PalletInfo
 *     y poblarlas aquí en FrmEliminarPallet_Load.
 *   → Para ejecutar lógica adicional post-eliminación, ampliar btnConfirmar_Click.
 * ====================================================================================
 */

namespace SisUvex.Archivo.MixtearPallets
{
    /// <summary>
    /// Formulario modal para eliminar (marcar como inactivo) un pallet.
    /// Ejecuta una reestiba completa con un tipo de motivo inactivo seleccionado por el usuario.
    /// </summary>
    internal partial class FrmEliminarPallet : Form
    {
        // ── Datos internos ───────────────────────────────────────────────────────────
        private PalletInfo?        _pallet;   // Se carga desde DB al abrir el formulario
        private readonly ClsMixtearPallets _cls;
        private readonly string    _idPallet; // ID ya formateado con ceros

        // ── Resultado público ────────────────────────────────────────────────────────

        /// <summary>
        /// Tipo de motivo seleccionado para la eliminación.
        /// Solo válido si DialogResult == OK.
        /// </summary>
        public TipoReestiba TipoSeleccionado { get; private set; } = new();

        // ── Constructor ──────────────────────────────────────────────────────────────

        /// <summary>
        /// Inicializa el formulario con el ID del pallet a eliminar.
        /// El ID se formatea automáticamente con ceros a la izquierda (formato "00000").
        /// La información completa del pallet se consulta desde la base de datos al cargar.
        /// </summary>
        /// <param name="idPallet">ID del pallet (con o sin ceros, ej. "123" → "00123")</param>
        public FrmEliminarPallet(string idPallet)
        {
            InitializeComponent();
            _cls      = new ClsMixtearPallets();
            _idPallet = _cls.FormatoCeros(idPallet.Trim(), "00000");
        }

        // ============================================================================
        // CARGA DEL FORMULARIO
        // ============================================================================

        private void FrmEliminarPallet_Load(object sender, EventArgs e)
        {
            // Consultar el pallet desde DB usando el ID formateado
            _pallet = _cls.ConsultarPallet(_idPallet);

            if (_pallet is null)
            {
                MessageBox.Show(
                    $"No se encontró el pallet {_idPallet} o no está activo.",
                    "Pallet no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            // ── Panel de información (dinámico, 3 columnas) ───────────────────────
            ClsMixtearPallets.PopularInfoPallet(grpInfoPallet, _pallet);

            // Reposicionar la sección "Eliminar como" y botones debajo del panel de info
            int y = grpInfoPallet.Bottom + 10;
            lblTipoTxt.Top     = y;
            y += lblTipoTxt.Height + 4;
            cboTipo.Top        = y;
            y += cboTipo.Height + 6;
            lblDescripcion.Top = y;
            y += lblDescripcion.Height + 6;
            lblAdvertencia.Top = y;
            y += lblAdvertencia.Height + 12;
            btnConfirmar.Top   = y;
            btnCancelar.Top    = y;
            ClientSize         = new Size(ClientSize.Width, y + btnCancelar.Height + 12);

            CargarTiposInactivos();
        }

        /// <summary>
        /// Carga en cboTipo únicamente los tipos con c_activeInPallet = '0'
        /// (los que dejan el pallet inactivo: ERROR, SINIESTRADO, CORTESÍA, REEMPAQUE…).
        /// Si no hay tipos disponibles, deshabilita el botón de confirmar.
        /// </summary>
        private void CargarTiposInactivos()
        {
            List<TipoReestiba> tipos = _cls.ObtenerTiposReestibaInactivos();

            if (tipos.Count == 0)
            {
                lblTipoTxt.Text     = "No hay tipos de eliminación disponibles en la base de datos.";
                lblTipoTxt.ForeColor = Color.Red;
                btnConfirmar.Enabled = false;
                return;
            }

            cboTipo.DataSource    = tipos;
            cboTipo.DisplayMember = "Nombre";
            cboTipo.ValueMember   = "IdTipo";
            cboTipo.SelectedIndex = 0;

            ActualizarDescripcion();
        }

        // ============================================================================
        // EVENTOS DE CONTROLES
        // ============================================================================

        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
            => ActualizarDescripcion();

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (cboTipo.SelectedItem is not TipoReestiba tipoElegido)
            {
                MessageBox.Show(
                    "Seleccione el motivo de eliminación antes de confirmar.",
                    "Motivo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirmación explícita antes de marcar el pallet inactivo
            string resumen =
                $"¿Confirma la eliminación del pallet {_pallet!.IdPallet}?\n\n" +
                $"  Motivo : {tipoElegido.Nombre}\n" +
                $"  Cajas  : {_pallet.Cajas}\n\n" +
                "El pallet quedará INACTIVO permanentemente.\n" +
                "No se creará ningún pallet nuevo.";

            var confirm = MessageBox.Show(
                resumen, "Confirmar Eliminación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);    // "No" como botón por defecto
            if (confirm != DialogResult.Yes) return;

            // Ejecutar reestiba completa (todo el pallet → inactivo)
            ResultadoReestiba resultado = _cls.EjecutarReestibaCompleta(_pallet.IdPallet, tipoElegido);

            if (resultado.Exito)
            {
                MessageBox.Show(
                    $"El pallet {_pallet.IdPallet} fue eliminado correctamente.\n" +
                    $"Motivo asignado: {tipoElegido.Nombre}.",
                    "Eliminación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                TipoSeleccionado = tipoElegido;
                DialogResult     = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show(
                    $"No se pudo eliminar el pallet {_pallet.IdPallet}.\n\n" +
                    (string.IsNullOrEmpty(resultado.Mensaje) ? "Error desconocido." : resultado.Mensaje),
                    "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        /// Muestra la descripción del tipo seleccionado en el label inferior.
        /// </summary>
        private void ActualizarDescripcion()
        {
            if (cboTipo.SelectedItem is TipoReestiba tipo)
            {
                lblDescripcion.Text = string.IsNullOrEmpty(tipo.Descripcion)
                    ? ""
                    : $"ℹ  {tipo.Descripcion}";
            }
        }
    }
}
