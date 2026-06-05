/*
 * FrmEliminarPallet.cs
 * ====================================================================================
 * Formulario modal para eliminar o cambiar el status de un pallet completo.
 *
 * MODOS:
 *   - Eliminar       → solo tipos con c_activeInPallet = '0' (pallet queda inactivo).
 *   - CambiarStatus  → todos los tipos activos del catálogo (c_active 0 o 1 según el tipo).
 *
 * USO DESDE OTRO FORMULARIO:
 *   var frm = new FrmEliminarPallet(idPallet);
 *   var frm = new FrmEliminarPallet(idPallet, ModoPalletAccion.CambiarStatus);
 *   if (frm.ShowDialog() == DialogResult.OK)
 *       // frm.TipoSeleccionado contiene el tipo usado.
 * ====================================================================================
 */

namespace SisUvex.Archivo.MixtearPallets
{
    internal enum ModoPalletAccion
    {
        Eliminar,
        CambiarStatus
    }

    /// <summary>
    /// Formulario modal para eliminar o cambiar el status de un pallet.
    /// Ejecuta una reestiba completa con el tipo de motivo seleccionado por el usuario.
    /// </summary>
    internal partial class FrmEliminarPallet : Form
    {
        private PalletInfo?        _pallet;
        private readonly ClsMixtearPallets _cls;
        private readonly string    _idPallet;
        private readonly ModoPalletAccion _modo;

        /// <summary>
        /// Tipo de motivo seleccionado. Solo válido si DialogResult == OK.
        /// </summary>
        public TipoReestiba TipoSeleccionado { get; private set; } = new();

        public FrmEliminarPallet(string idPallet, ModoPalletAccion modo = ModoPalletAccion.Eliminar)
        {
            InitializeComponent();
            _cls      = new ClsMixtearPallets();
            _idPallet = _cls.FormatoCeros(idPallet.Trim(), "00000");
            _modo     = modo;
        }

        private void FrmEliminarPallet_Load(object sender, EventArgs e)
        {
            ConfigurarModo();

            _pallet = _cls.ConsultarPallet(_idPallet, incluirInactivos: _modo == ModoPalletAccion.CambiarStatus);

            if (_pallet is null)
            {
                string mensaje = _modo == ModoPalletAccion.Eliminar
                    ? $"No se encontró el pallet {_idPallet} o no está activo."
                    : $"No se encontró el pallet {_idPallet}.";

                MessageBox.Show(mensaje, "Pallet no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            ClsMixtearPallets.PopularInfoPallet(grpInfoPallet, _pallet);

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

            CargarTipos();
        }

        private void ConfigurarModo()
        {
            if (_modo == ModoPalletAccion.CambiarStatus)
            {
                Text = "Cambiar Status Pallet";
                lblTipoTxt.Text = "Cambiar status como:";
                btnConfirmar.Text = "Cambiar status";
                btnConfirmar.BackColor = Color.SteelBlue;
            }
            else
            {
                Text = "Eliminar Pallet";
                lblTipoTxt.Text = "Eliminar como (opciones que dejan el pallet inactivo):";
                btnConfirmar.Text = "Eliminar";
                btnConfirmar.BackColor = Color.FromArgb(192, 0, 0);
            }
        }

        private void CargarTipos()
        {
            List<TipoReestiba> tipos = _modo == ModoPalletAccion.CambiarStatus
                ? _cls.ObtenerTiposReestiba()
                : _cls.ObtenerTiposReestibaInactivos();

            if (tipos.Count == 0)
            {
                string sinTipos = _modo == ModoPalletAccion.CambiarStatus
                    ? "No hay tipos de status disponibles en la base de datos."
                    : "No hay tipos de eliminación disponibles en la base de datos.";

                lblTipoTxt.Text      = sinTipos;
                lblTipoTxt.ForeColor = Color.Red;
                btnConfirmar.Enabled = false;
                return;
            }

            cboTipo.DataSource    = tipos;
            cboTipo.DisplayMember = "Nombre";
            cboTipo.ValueMember   = "IdTipo";
            cboTipo.SelectedIndex = 0;

            ActualizarDescripcion();
            ActualizarAdvertencia();
        }

        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarDescripcion();
            ActualizarAdvertencia();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (cboTipo.SelectedItem is not TipoReestiba tipoElegido)
            {
                string aviso = _modo == ModoPalletAccion.CambiarStatus
                    ? "Seleccione el nuevo status antes de confirmar."
                    : "Seleccione el motivo de eliminación antes de confirmar.";

                MessageBox.Show(aviso, "Motivo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string estadoNuevo = tipoElegido.NuevoPalletActivo ? "ACTIVO" : "INACTIVO";
            string resumen = _modo == ModoPalletAccion.CambiarStatus
                ? $"¿Confirma el cambio de status del pallet {_pallet!.IdPallet}?\n\n" +
                  $"  Motivo      : {tipoElegido.Nombre}\n" +
                  $"  Cajas       : {_pallet.Cajas}\n" +
                  $"  Nuevo status: {estadoNuevo}\n\n" +
                  "No se creará ningún pallet nuevo."
                : $"¿Confirma la eliminación del pallet {_pallet!.IdPallet}?\n\n" +
                  $"  Motivo : {tipoElegido.Nombre}\n" +
                  $"  Cajas  : {_pallet.Cajas}\n\n" +
                  "El pallet quedará INACTIVO permanentemente.\n" +
                  "No se creará ningún pallet nuevo.";

            string titulo = _modo == ModoPalletAccion.CambiarStatus
                ? "Confirmar Cambio de Status"
                : "Confirmar Eliminación";

            if (MessageBox.Show(resumen, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

            ResultadoReestiba resultado = _cls.EjecutarReestibaCompleta(_pallet.IdPallet, tipoElegido);

            if (resultado.Exito)
            {
                string exito = _modo == ModoPalletAccion.CambiarStatus
                    ? $"El status del pallet {_pallet.IdPallet} fue actualizado correctamente.\n" +
                      $"Motivo asignado: {tipoElegido.Nombre}.\n" +
                      $"Status: {estadoNuevo}."
                    : $"El pallet {_pallet.IdPallet} fue eliminado correctamente.\n" +
                      $"Motivo asignado: {tipoElegido.Nombre}.";

                string tituloExito = _modo == ModoPalletAccion.CambiarStatus
                    ? "Cambio de status exitoso"
                    : "Eliminación exitosa";

                MessageBox.Show(exito, tituloExito, MessageBoxButtons.OK, MessageBoxIcon.Information);

                TipoSeleccionado = tipoElegido;
                DialogResult     = DialogResult.OK;
                Close();
            }
            else
            {
                string error = _modo == ModoPalletAccion.CambiarStatus
                    ? $"No se pudo cambiar el status del pallet {_pallet.IdPallet}."
                    : $"No se pudo eliminar el pallet {_pallet.IdPallet}.";

                MessageBox.Show(
                    $"{error}\n\n" +
                    (string.IsNullOrEmpty(resultado.Mensaje) ? "Error desconocido." : resultado.Mensaje),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ActualizarDescripcion()
        {
            if (cboTipo.SelectedItem is TipoReestiba tipo)
            {
                lblDescripcion.Text = string.IsNullOrEmpty(tipo.Descripcion)
                    ? ""
                    : $"ℹ  {tipo.Descripcion}";
            }
        }

        private void ActualizarAdvertencia()
        {
            if (cboTipo.SelectedItem is not TipoReestiba tipo)
                return;

            if (_modo == ModoPalletAccion.Eliminar)
            {
                lblAdvertencia.Text      = "⚠  El pallet quedará INACTIVO permanentemente en la base de datos.";
                lblAdvertencia.ForeColor = Color.DarkOrange;
                return;
            }

            string estado = tipo.NuevoPalletActivo ? "ACTIVO" : "INACTIVO";
            lblAdvertencia.Text      = $"ℹ  El pallet quedará {estado} en la base de datos.";
            lblAdvertencia.ForeColor = tipo.NuevoPalletActivo ? Color.ForestGreen : Color.DarkOrange;
        }
    }
}
