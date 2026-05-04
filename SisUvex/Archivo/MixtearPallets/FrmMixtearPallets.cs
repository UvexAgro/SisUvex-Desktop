/*
 * FrmMixtearPallets.cs
 * ====================================================================================
 * Formulario principal del módulo "Mixtear Pallets en Estiba".
 *
 * FUNCIONALIDADES:
 *   ── SECCIÓN SUPERIOR (dgvPallets) ─────────────────────────────────────────────
 *   • Agregar pallets por ID con validaciones previas (cajas GTIN, diferencias).
 *   • Mover el pallet seleccionado al listado inferior (↓ Mover a desestibar).
 *   • Quitar un pallet del formulario (✕ Quitar) — elimina de ambas grillas.
 *   • Reestibar (DEFERRED): la reestiba se almacena en _reesibasDeferred y no
 *     se ejecuta en DB hasta que se confirme el mixteo (Guardar) o se revierta
 *     (Reconfigurar). El pallet sobrante aparece con ID "Res_XXXXX" en dgvDestibar.
 *   • Mixtear: ejecuta primero las reestibas pendientes y luego crea la estiba.
 *   • Reconfigurar: revierte las reestibas pendientes sin tocar la DB.
 *
 *   ── SECCIÓN INFERIOR (dgvDestibar) ────────────────────────────────────────────
 *   • Recibe pallets vía "↓ Mover" o como sobrantes de reestibas diferidas.
 *   • Regresar al listado superior (↑ Regresar a mixtear).
 *   • Desestiba SOLO los pallets del listado (no por ID de estiba).
 *     — Si hay pallets deferred (Res_) en dgvDestibar, bloquea a menos que
 *       sus originales también estén en dgvDestibar (ejecuta deferreds + desestiba).
 *
 * RELACIONES:
 *   - ClsMixtearPallets → lógica de negocio y acceso a datos.
 *   - FrmReestibaPallet → diálogo modal que SOLO recopila datos (no ejecuta en DB).
 *   - EMixtearPallets   → modelos de datos incl. ReestibaDeferred.
 *
 * ESCALABILIDAD:
 *   → PermitirSobrepasoMaxGtin: cambiar a true para relajar restricción de cajas.
 *   → Para encadenar más grids al flujo deferred, extender RevertirTodosLosDeferreds.
 * ====================================================================================
 */

namespace SisUvex.Archivo.MixtearPallets
{
    public partial class FrmMixtearPallets : Form
    {
        /// <summary>Instancia de la clase de negocio.</summary>
        private readonly ClsMixtearPallets cls = new();

        // ── Estado de reestibas diferidas ───────────────────────────────────────────

        /// <summary>
        /// Lista de reestibas pendientes de ejecutarse en DB.
        /// Se llenan en btnReestibar_Click y se consumen en btnGuardar_Click.
        /// Al Reconfigurar se revierten en orden inverso sin tocar la DB.
        /// </summary>
        private readonly List<ReestibaDeferred> _reesibasDeferred = new();

        /// <summary>Contador global de orden para los deferred (garantiza secuencia).</summary>
        private int _nextDeferredOrd = 1;

        /// <summary>
        /// false → guarda bloqueado si cajas > máximo GTIN (recomendado).
        /// true  → solo advierte. Cambiar si se decide permitirlo en el futuro.
        /// </summary>
        private const bool PermitirSobrepasoMaxGtin = false;

        public FrmMixtearPallets()
        {
            InitializeComponent();
        }

        // ============================================================================
        // CARGA DEL FORMULARIO
        // ============================================================================

        private void FrmMixtearPallets_Load(object sender, EventArgs e)
        {
            cls.InicializarColumnas(dgvPallets);
            cls.InicializarColumnas(dgvDestibar);
            ActualizarTotales();
        }

        // ============================================================================
        // SECCIÓN SUPERIOR: PALLETS A MIXTEAR
        // ============================================================================

        // ── Agregar pallet ──────────────────────────────────────────────────────────

        private void btnAddPallet_Click(object sender, EventArgs e)
            => AgregarPalletPorTexto(txbIdPallet.Text.Trim());

        private void txbIdPallet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            AgregarPalletPorTexto(txbIdPallet.Text.Trim());
            e.SuppressKeyPress = true;
        }

        private void txbIdPallet_KeyPress(object sender, KeyPressEventArgs e)
            => cls.TxbTeclasEnteros(e);

        /// <summary>
        /// Flujo completo para agregar un pallet al grid de mixteo con validaciones previas:
        ///   1. Verificar duplicado en dgvPallets y dgvDestibar.
        ///   2. Consultar pallet en DB.
        ///   3. Si tiene estiba → ofrecer agregar estiba completa.
        ///   4. Validar cajas vs. máximo GTIN.
        ///   5. Validar diferencias de producto.
        ///   6. Agregar al grid.
        /// En cualquier rechazo: mantiene el texto del TextBox (focus + SelectAll).
        /// Solo se limpia al agregar exitosamente.
        /// </summary>
        private void AgregarPalletPorTexto(string textoId)
        {
            if (string.IsNullOrEmpty(textoId))
            {
                System.Media.SystemSounds.Beep.Play();
                return;
            }

            string idPallet = cls.FormatoCeros(textoId, "00000");

            if (cls.ExistePalletEnGrid(dgvPallets, idPallet))
            {
                MostrarAviso($"El pallet {idPallet} ya está en la lista de mixteo.", "Agregar Pallet");
                FocarYSeleccionar(txbIdPallet);
                return;
            }

            // Si está en dgvDestibar lo regresamos directamente (sin validaciones extra)
            if (cls.ExistePalletEnGrid(dgvDestibar, idPallet))
            {
                RegresarPalletDesdeDestibar(idPallet);
                LimpiarYFocar(txbIdPallet);
                return;
            }

            PalletInfo? pallet = cls.ConsultarPallet(idPallet);
            if (pallet is null)
            {
                MostrarAviso($"No se encontró el pallet {idPallet} o no está activo.", "Agregar Pallet");
                FocarYSeleccionar(txbIdPallet);
                return;
            }

            // Pallet con estiba → ofrecer agregar toda la estiba
            if (!string.IsNullOrEmpty(pallet.Estiba))
            {
                var resp = MessageBox.Show(
                    $"El pallet {idPallet} ya pertenece a la estiba {pallet.Estiba}.\n" +
                    "¿Desea agregar todos los pallets de esa estiba a la lista?",
                    "Pallet con estiba asignada",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resp == DialogResult.Yes)
                {
                    AgregarEstibaCompletaAlMix(pallet.Estiba);
                    LimpiarYFocar(txbIdPallet);
                }
                else
                {
                    FocarYSeleccionar(txbIdPallet);
                }
                return;
            }

            // ── Validación 1: cajas vs. máximo GTIN ─────────────────────────────────
            if (dgvPallets.Rows.Count > 0)
            {
                int maxGtin    = cls.ObtenerCajasPorPalletMinimo(dgvPallets);
                int totalNuevo = cls.SumarCajas(dgvPallets) + pallet.Cajas;

                if (maxGtin > 0 && totalNuevo > maxGtin)
                {
                    var resp = MessageBox.Show(
                        $"Al agregar el pallet {idPallet} ({pallet.Cajas} cjs.), el total quedaría " +
                        $"en {totalNuevo} cajas, superando el máximo del GTIN ({maxGtin} cjs.).\n\n" +
                        "¿Desea agregarlo de todas formas?",
                        "Exceso de cajas",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (resp != DialogResult.Yes)
                    {
                        FocarYSeleccionar(txbIdPallet);
                        return;
                    }
                }
            }

            // ── Validación 2: diferencias de producto ─────────────────────────────────
            List<string> diferencias = cls.ObtenerDiferenciasPallet(dgvPallets, pallet);
            if (diferencias.Count > 0)
            {
                var encabezados = diferencias
                    .Select(col => dgvPallets.Columns.Contains(col)
                        ? dgvPallets.Columns[col]!.HeaderText : col)
                    .ToList();

                var resp = MessageBox.Show(
                    $"El pallet {idPallet} difiere del resto en la lista en:\n" +
                    $"\n  •  {string.Join("\n  •  ", encabezados)}\n\n" +
                    "¿Desea agregarlo de todas formas?",
                    "Pallet con diferencias de producto",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (resp != DialogResult.Yes)
                {
                    FocarYSeleccionar(txbIdPallet);
                    return;
                }
            }

            cls.AgregarPalletAlGrid(dgvPallets, pallet);
            cls.SeleccionarUltimaFila(dgvPallets);
            ActualizarTotales();
            cls.AplicarColorAdvertencias(dgvPallets);
            LimpiarYFocar(txbIdPallet);
        }

        private void AgregarEstibaCompletaAlMix(string idEstiba)
        {
            var pallets  = cls.ConsultarEstiba(idEstiba);
            int agregados = pallets.Count(p => cls.AgregarPalletAlGrid(dgvPallets, p));
            cls.SeleccionarUltimaFila(dgvPallets);
            ActualizarTotales();
            cls.AplicarColorAdvertencias(dgvPallets);

            if (agregados == 0)
                MostrarAviso($"Todos los pallets de la estiba {idEstiba} ya están en la lista.",
                    "Estiba completa");
        }

        // ── Mover pallet al listado inferior ────────────────────────────────────────

        private void btnQuitPallet_Click(object sender, EventArgs e)
        {
            if (dgvPallets.SelectedRows.Count == 0)
            {
                System.Media.SystemSounds.Beep.Play();
                return;
            }
            cls.MoverPalletSeleccionadoAGrid(dgvPallets, dgvDestibar);
            ActualizarTotales();
            cls.AplicarColorAdvertencias(dgvPallets);
        }

        // ── Quitar pallet del formulario (ingresado por error) ───────────────────────

        private void btnQuitarMix_Click(object sender, EventArgs e)
        {
            if (dgvPallets.SelectedRows.Count == 0)
            {
                System.Media.SystemSounds.Beep.Play();
                return;
            }
            cls.QuitarPalletDeAmbosGrids(dgvPallets, dgvDestibar, dgvPallets.SelectedRows[0]);
            ActualizarTotales();
            cls.AplicarColorAdvertencias(dgvPallets);
        }

        private void btnQuitarDes_Click(object sender, EventArgs e)
        {
            if (dgvDestibar.SelectedRows.Count == 0)
            {
                System.Media.SystemSounds.Beep.Play();
                return;
            }

            DataGridViewRow fila   = dgvDestibar.SelectedRows[0];
            string          idSel  = fila.Cells["Pallet"].Value?.ToString() ?? "";

            // Si es un pallet deferred (Res_), revertir ese deferred específico
            if (ClsMixtearPallets.EsIdDeferred(idSel))
            {
                RevertirDeferredPorTempId(idSel);
                return;
            }

            cls.QuitarPalletDeAmbosGrids(dgvPallets, dgvDestibar, fila);
            ActualizarTotales();
            cls.AplicarColorAdvertencias(dgvPallets);
        }

        // ── Reestibar pallet seleccionado (MODO DEFERRED) ───────────────────────────

        /// <summary>
        /// En el contexto del formulario de mixteo, la reestiba es SIEMPRE DIFERIDA:
        /// no se ejecuta en DB inmediatamente. Se almacena en _reesibasDeferred y el
        /// pallet sobrante aparece visualmente como "Res_XXXXX" en dgvDestibar.
        ///
        /// Los deferreds se ejecutan en orden cuando el usuario confirma el mixteo
        /// (btnGuardar_Click), soportando encadenamiento de reestibas.
        ///
        /// El diálogo FrmReestibaPallet NO cambia: sigue recibiendo un PalletInfo y
        /// retornando NuevasCajas + TipoSeleccionado. La lógica de ejecución diferida
        /// vive aquí, en el form de mixteo.
        /// </summary>
        private void btnReestibar_Click(object sender, EventArgs e)
        {
            if (dgvPallets.SelectedRows.Count == 0)
            {
                System.Media.SystemSounds.Beep.Play();
                return;
            }

            DataGridViewRow filaOrig = dgvPallets.SelectedRows[0];
            string idRef  = filaOrig.Cells["Pallet"].Value?.ToString() ?? "";
            int    cajas  = int.TryParse(filaOrig.Cells["Cajas"].Value?.ToString(), out int c) ? c : 0;

            if (cajas <= 1)
            {
                MostrarAviso(
                    $"El pallet {idRef} solo tiene {cajas} caja(s).\n" +
                    "Se requiere más de 1 caja para poder reestibar.",
                    "Reestibar");
                return;
            }

            List<TipoReestiba> tipos = cls.ObtenerTiposReestiba();
            if (tipos.Count == 0)
            {
                MostrarAviso("No se encontraron tipos de reestiba activos en la base de datos.",
                    "Reestibar – Sin tipos");
                return;
            }

            // Construir PalletInfo desde la fila (válido tanto para real como para Res_)
            PalletInfo palletParaDlg = cls.ObtenerPalletSeleccionado(dgvPallets)
                ?? new PalletInfo { IdPallet = idRef, Cajas = cajas };

            using FrmReestibaPallet dlg = new(palletParaDlg, tipos);
            if (dlg.ShowDialog(this) != DialogResult.OK) return;

            bool esReal = !ClsMixtearPallets.EsIdDeferred(idRef);

            if (dlg.EsReestibaCompleta)
            {
                // ── Deferred COMPLETA: motivo al original, sin nuevo pallet ─────────
                var def = new ReestibaDeferred
                {
                    Orden               = _nextDeferredOrd++,
                    IdPalletOriginalRef = idRef,
                    OriginalEsReal      = esReal,
                    CajasAntes          = cajas,
                    NuevasCajasOriginal = cajas,
                    IdPalletTemporal    = string.Empty,
                    CajasNuevoPallet    = 0,
                    Tipo                = dlg.TipoSeleccionado,
                    EsCompleta          = true,
                };
                _reesibasDeferred.Add(def);

                // Quitar de la lista (será inactivado al guardar)
                cls.QuitarPalletPorId(dgvPallets, idRef);
                ActualizarTotales();
                cls.AplicarColorAdvertencias(dgvPallets);

                MessageBox.Show(
                    $"Reestiba completa del pallet {idRef} registrada como pendiente.\n" +
                    $"Tipo: {dlg.TipoSeleccionado.Nombre}.\n\n" +
                    "Se aplicará al confirmar el mixteo (Guardar).",
                    "Reestiba Pendiente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // ── Deferred PARCIAL: divide el pallet ─────────────────────────────
                int    nuevas  = dlg.NuevasCajas;
                int    nCajas  = cajas - nuevas;
                string idTemp  = GenerarIdDeferred(idRef);

                var def = new ReestibaDeferred
                {
                    Orden               = _nextDeferredOrd++,
                    IdPalletOriginalRef = idRef,
                    OriginalEsReal      = esReal,
                    CajasAntes          = cajas,
                    NuevasCajasOriginal = nuevas,
                    IdPalletTemporal    = idTemp,
                    CajasNuevoPallet    = nCajas,
                    Tipo                = dlg.TipoSeleccionado,
                    EsCompleta          = false,
                };
                _reesibasDeferred.Add(def);

                // Actualizar cajas del original en el grid (sin tocar DB)
                filaOrig.Cells["Cajas"].Value = nuevas;

                // Agregar pallet temporal a dgvDestibar (con fondo cyan = pendiente)
                AgregarFilaDeferredADestibar(def, filaOrig);

                ActualizarTotales();
                cls.AplicarColorAdvertencias(dgvPallets);

                MessageBox.Show(
                    $"Reestiba del pallet {idRef} registrada como pendiente.\n" +
                    $"  • Original: {nuevas} cjs.\n" +
                    $"  • Sobrante temporal ({idTemp}): {nCajas} cjs. → listado de desestibar.\n\n" +
                    "Se aplicará al confirmar el mixteo (Guardar).",
                    "Reestiba Pendiente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ── Guardar / Mixtear ───────────────────────────────────────────────────────

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // ── Caso especial: solo 1 pallet en la lista ───────────────────────────
            if (dgvPallets.Rows.Count == 1)
            {
                string estiba   = dgvPallets.Rows[0].Cells["Estiba"].Value?.ToString() ?? "";
                string idPallet = dgvPallets.Rows[0].Cells["Pallet"].Value?.ToString() ?? "";

                if (!string.IsNullOrEmpty(estiba) && !string.IsNullOrEmpty(idPallet))
                {
                    string notaDeferred = _reesibasDeferred.Count > 0
                        ? $"\n\nNota: hay {_reesibasDeferred.Count} reestiba(s) pendiente(s) " +
                          "que también se ejecutarán."
                        : "";

                    var conf = MessageBox.Show(
                        $"Solo hay 1 pallet en la lista y ya pertenece a la estiba {estiba}.\n" +
                        $"¿Desea remover el pallet {idPallet} de esa estiba?" + notaDeferred,
                        "Desestibar Pallet",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (conf != DialogResult.Yes) return;

                    // Ejecutar deferreds pendientes antes de desestibar
                    EjecutarYAplicarDeferreds();

                    if (cls.EjecutarDesestibarPallet(idPallet))
                    {
                        dgvPallets.Rows[0].Cells["Estiba"].Value = string.Empty;
                        dgvPallets.Rows[0].Cells["Mix"].Value    = string.Empty;
                        ActualizarTotales();
                        MessageBox.Show(
                            $"El pallet {idPallet} fue removido de la estiba {estiba}.",
                            "Desestibar Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    System.Media.SystemSounds.Beep.Play();
                }
                return;
            }

            int totalCajas = cls.SumarCajas(dgvPallets);

            if (!cls.ValidarParaMixtear(dgvPallets, totalCajas,
                    out string error, out string advertencia))
            {
                MessageBox.Show(error, "Mixtear – No permitido",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!string.IsNullOrEmpty(advertencia))
            {
                var confirmar = MessageBox.Show(
                    advertencia + "\n\n¿Desea continuar con el mixteo de todas formas?",
                    "Mixtear – Advertencias",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmar != DialogResult.Yes) return;
            }

            // ── Validación de límite GTIN ──────────────────────────────────────────
            int cajasMaxGtin = cls.ObtenerCajasPorPalletMinimo(dgvPallets);
            if (cajasMaxGtin > 0 && totalCajas > cajasMaxGtin && !PermitirSobrepasoMaxGtin)
            {
                MessageBox.Show(
                    $"Las cajas totales ({totalCajas} cjs.) superan el máximo del GTIN " +
                    $"({cajasMaxGtin} cjs.).\n\nQuite pallets hasta ajustar el total.",
                    "Cajas excedidas – Guardado bloqueado",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ── Ejecutar reestibas diferidas ANTES de crear la estiba ──────────────
            EjecutarYAplicarDeferreds();

            string nuevaEstiba = cls.EjecutarMixtear(dgvPallets);
            if (string.IsNullOrEmpty(nuevaEstiba))
            {
                txbIdPallet.Focus();
                return;
            }

            // Actualizar columnas Estiba/Mix en el grid (no limpiar filas)
            for (int i = 0; i < dgvPallets.Rows.Count; i++)
            {
                dgvPallets.Rows[i].Cells["Estiba"].Value = nuevaEstiba;
                dgvPallets.Rows[i].Cells["Mix"].Value    = (i + 1).ToString("00");
            }

            cls.AplicarColorAdvertencias(dgvPallets);
            ActualizarTotales();

            MessageBox.Show(
                $"Los pallets fueron mixteados correctamente.\nNueva estiba: {nuevaEstiba}",
                "Mixteo Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txbIdPallet.Focus();
        }

        // ── Reconfigurar ────────────────────────────────────────────────────────────

        private void btnReconfigurar_Click(object sender, EventArgs e)
        {
            if (_reesibasDeferred.Count > 0)
            {
                // Hay reestibas pendientes → revertirlas sin tocar DB
                int n = _reesibasDeferred.Count;
                var conf = MessageBox.Show(
                    $"Hay {n} reestiba(s) pendiente(s) sin guardar.\n\n" +
                    "Al reconfigurar:\n" +
                    "  • Los pallets temporales (Res_...) serán quitados de ambas listas.\n" +
                    "  • Los pallets originales volverán a sus cajas previas.\n\n" +
                    "¿Desea revertir las reestibas pendientes?",
                    "Reconfigurar – Reestibas pendientes",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (conf != DialogResult.Yes) return;

                RevertirTodosLosDeferreds();
                ActualizarTotales();
                cls.AplicarColorAdvertencias(dgvPallets);
                // No limpiar los grids: el usuario conserva los pallets originales
                return;
            }

            // Sin deferreds → limpiar grids (comportamiento original)
            if (dgvPallets.Rows.Count > 0 || dgvDestibar.Rows.Count > 0)
            {
                var conf = MessageBox.Show(
                    "¿Desea limpiar ambas listas de pallets?",
                    "Reconfigurar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (conf != DialogResult.Yes) return;
            }

            dgvPallets.Rows.Clear();
            dgvDestibar.Rows.Clear();
            txbIdPallet.Clear();
            ActualizarTotales();
            txbIdPallet.Focus();
        }

        private void dgvPallets_SelectionChanged(object sender, EventArgs e)
            => cls.AplicarColorAdvertencias(dgvPallets);

        // ============================================================================
        // SECCIÓN INFERIOR: PALLETS A DESESTIBAR
        // ============================================================================

        private void btnAddToUp_Click(object sender, EventArgs e)
        {
            if (dgvDestibar.Rows.Count == 0)
            {
                System.Media.SystemSounds.Beep.Play();
                return;
            }

            var filas = dgvDestibar.SelectedRows.Count > 0
                ? dgvDestibar.SelectedRows.Cast<DataGridViewRow>().ToList()
                : dgvDestibar.Rows.Cast<DataGridViewRow>().ToList();

            int regresados = 0;
            var aRemover   = new List<DataGridViewRow>();

            foreach (DataGridViewRow row in filas)
            {
                string idPallet = row.Cells["Pallet"].Value?.ToString() ?? "";
                if (string.IsNullOrEmpty(idPallet)) continue;
                if (cls.ExistePalletEnGrid(dgvPallets, idPallet)) continue;

                object[] vals = new object[row.Cells.Count];
                for (int i = 0; i < row.Cells.Count; i++) vals[i] = row.Cells[i].Value!;
                dgvPallets.Rows.Add(vals);

                // Quitar color deferred al pasar al grid superior
                dgvPallets.Rows[dgvPallets.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Empty;

                aRemover.Add(row);
                regresados++;
            }

            foreach (var r in aRemover) dgvDestibar.Rows.Remove(r);

            ActualizarTotales();
            cls.AplicarColorAdvertencias(dgvPallets);
            cls.SeleccionarUltimaFila(dgvPallets);
        }

        /// <summary>
        /// Desestiba los pallets del listado inferior.
        /// Si hay pallets deferred (Res_) en dgvDestibar:
        ///   - Sus originales deben estar también en dgvDestibar → ejecuta deferreds primero.
        ///   - Si algún original NO está en dgvDestibar → bloquea con aviso.
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvDestibar.Rows.Count == 0)
            {
                System.Media.SystemSounds.Beep.Play();
                return;
            }

            // Identificar pallets deferred en dgvDestibar
            var idsEnDestibar = dgvDestibar.Rows.Cast<DataGridViewRow>()
                .Select(r => r.Cells["Pallet"].Value?.ToString() ?? "")
                .Where(id => !string.IsNullOrEmpty(id))
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            var deferredsEnDestibar = _reesibasDeferred
                .Where(d => !d.EsCompleta && idsEnDestibar.Contains(d.IdPalletTemporal))
                .ToList();

            if (deferredsEnDestibar.Count > 0)
            {
                // Verificar que los originales también estén en dgvDestibar
                var originalesAusentes = deferredsEnDestibar
                    .Where(d => !idsEnDestibar.Contains(d.IdPalletOriginalRef))
                    .Select(d => $"  •  {d.IdPalletTemporal}  (original: {d.IdPalletOriginalRef})")
                    .ToList();

                if (originalesAusentes.Count > 0)
                {
                    MessageBox.Show(
                        "No se pueden desestibar pallets provenientes de una reestiba pendiente\n" +
                        "sin que su pallet original también esté en el listado:\n\n" +
                        string.Join("\n", originalesAusentes) + "\n\n" +
                        "Opciones:\n" +
                        "  1. Mueva también el pallet original al listado de desestibar.\n" +
                        "  2. Guarde primero el mixteo (Guardar/Mixtear).",
                        "Desestibar – Reestibas pendientes",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Todos los originales están → ejecutar esos deferreds y actualizar grids
                var mapping = cls.EjecutarReesibasDeferred(deferredsEnDestibar);
                foreach (var (idTemp, idReal) in mapping)
                {
                    ClsMixtearPallets.ActualizarIdEnGrid(dgvPallets, idTemp, idReal);
                    ClsMixtearPallets.ActualizarIdEnGrid(dgvDestibar, idTemp, idReal);
                }
                foreach (var def in deferredsEnDestibar) _reesibasDeferred.Remove(def);
            }

            // Desestibar solo los que tienen estiba asignada
            var conEstiba = dgvDestibar.Rows.Cast<DataGridViewRow>()
                .Where(r => !string.IsNullOrEmpty(r.Cells["Estiba"].Value?.ToString()))
                .ToList();

            if (conEstiba.Count == 0)
            {
                MostrarAviso(
                    "Los pallets en el listado no tienen estiba asignada.\nNo hay nada que desestibar.",
                    "Desestibar");
                return;
            }

            var confirmar = MessageBox.Show(
                $"¿Confirma desestibar {conEstiba.Count} pallet(s) del listado?\n\n" +
                "Se removerá la asignación de estiba de cada uno.",
                "Confirmar Desestibar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmar != DialogResult.Yes) return;

            int exitosos = 0;
            foreach (DataGridViewRow row in conEstiba)
            {
                string idPallet = row.Cells["Pallet"].Value?.ToString() ?? "";
                if (!string.IsNullOrEmpty(idPallet) && cls.EjecutarDesestibarPallet(idPallet))
                {
                    row.Cells["Estiba"].Value = string.Empty;
                    row.Cells["Mix"].Value    = string.Empty;
                    exitosos++;
                }
            }

            MessageBox.Show(
                $"{exitosos} de {conEstiba.Count} pallet(s) desestibados correctamente.",
                "Desestibar Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ============================================================================
        // GESTIÓN DE REESTIBAS DIFERIDAS
        // ============================================================================

        /// <summary>
        /// Genera un ID temporal único para el pallet sobrante de una reestiba deferred.
        /// Formato: "Res_" + idPalletOriginalRef (con sufijo numérico si ya existe).
        /// </summary>
        private string GenerarIdDeferred(string idPalletOriginalRef)
        {
            string candidato = "Res_" + idPalletOriginalRef;
            int    n         = 2;
            while (_reesibasDeferred.Any(r => r.IdPalletTemporal == candidato))
                candidato = "Res_" + idPalletOriginalRef + "_" + n++;
            return candidato;
        }

        /// <summary>
        /// Agrega una fila virtual de pallet deferred al dgvDestibar.
        /// Copia todas las celdas de la fila original y sobrescribe Pallet, Cajas,
        /// Estiba y Mix. El fondo cyan indica que es un pallet pendiente (no en DB).
        /// </summary>
        private void AgregarFilaDeferredADestibar(ReestibaDeferred def, DataGridViewRow filaOriginal)
        {
            object[] vals = new object[filaOriginal.Cells.Count];
            for (int i = 0; i < filaOriginal.Cells.Count; i++)
                vals[i] = filaOriginal.Cells[i].Value!;

            dgvDestibar.Rows.Add(vals);

            DataGridViewRow fila = dgvDestibar.Rows[dgvDestibar.Rows.Count - 1];
            fila.Cells["Pallet"].Value = def.IdPalletTemporal;
            fila.Cells["Cajas"].Value  = def.CajasNuevoPallet;
            fila.Cells["Estiba"].Value = string.Empty;
            fila.Cells["Mix"].Value    = string.Empty;

            // Fondo cyan para distinguir pallets pendientes de los reales
            fila.DefaultCellStyle.BackColor = Color.LightCyan;
        }

        /// <summary>
        /// Ejecuta todos los deferreds pendientes y actualiza ambas grillas con los
        /// IDs reales asignados por la DB. Limpia _reesibasDeferred al terminar.
        /// </summary>
        private void EjecutarYAplicarDeferreds()
        {
            if (_reesibasDeferred.Count == 0) return;

            var mapping = cls.EjecutarReesibasDeferred(_reesibasDeferred);
            foreach (var (idTemp, idReal) in mapping)
            {
                ClsMixtearPallets.ActualizarIdEnGrid(dgvPallets, idTemp, idReal);
                ClsMixtearPallets.ActualizarIdEnGrid(dgvDestibar, idTemp, idReal);
            }
            _reesibasDeferred.Clear();
            _nextDeferredOrd = 1;
        }

        /// <summary>
        /// Revierte TODOS los deferreds pendientes en orden inverso (del más reciente
        /// al más antiguo), restaurando el estado visual sin tocar la DB.
        /// </summary>
        private void RevertirTodosLosDeferreds()
        {
            foreach (var def in _reesibasDeferred.OrderByDescending(r => r.Orden))
            {
                // Quitar el pallet temporal de ambas grillas
                if (!string.IsNullOrEmpty(def.IdPalletTemporal))
                {
                    cls.QuitarPalletPorId(dgvPallets, def.IdPalletTemporal);
                    cls.QuitarPalletPorId(dgvDestibar, def.IdPalletTemporal);
                }

                // Restaurar cajas del pallet original (en ambas grillas por si se movió)
                cls.ActualizarCajasEnGrid(dgvPallets, def.IdPalletOriginalRef, def.CajasAntes);
                cls.ActualizarCajasEnGrid(dgvDestibar, def.IdPalletOriginalRef, def.CajasAntes);

                // Si era reestiba completa el pallet fue quitado → re-consultar y re-agregar
                if (def.EsCompleta && def.OriginalEsReal)
                {
                    PalletInfo? p = cls.ConsultarPallet(def.IdPalletOriginalRef);
                    if (p is not null) cls.AgregarPalletAlGrid(dgvPallets, p);
                }
            }
            _reesibasDeferred.Clear();
            _nextDeferredOrd = 1;
        }

        /// <summary>
        /// Revierte el deferred identificado por su idPalletTemporal, así como
        /// todos los deferreds que dependan de él (anidados), en orden inverso.
        /// </summary>
        private void RevertirDeferredPorTempId(string idTemp)
        {
            var aRevertir = new List<ReestibaDeferred>();
            RecolectarDependientes(idTemp, aRevertir);

            if (aRevertir.Count == 0) return;

            var conf = MessageBox.Show(
                $"¿Quitar el pallet temporal {idTemp} y revertir " +
                $"{aRevertir.Count} reestiba(s) pendiente(s) relacionada(s)?",
                "Revertir reestiba", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (conf != DialogResult.Yes) return;

            foreach (var def in aRevertir.OrderByDescending(r => r.Orden))
            {
                if (!string.IsNullOrEmpty(def.IdPalletTemporal))
                {
                    cls.QuitarPalletPorId(dgvPallets, def.IdPalletTemporal);
                    cls.QuitarPalletPorId(dgvDestibar, def.IdPalletTemporal);
                }
                cls.ActualizarCajasEnGrid(dgvPallets, def.IdPalletOriginalRef, def.CajasAntes);
                cls.ActualizarCajasEnGrid(dgvDestibar, def.IdPalletOriginalRef, def.CajasAntes);
                _reesibasDeferred.Remove(def);
            }

            ActualizarTotales();
            cls.AplicarColorAdvertencias(dgvPallets);
        }

        /// <summary>
        /// Recolecta de forma recursiva todos los deferreds que dependan de idTemp
        /// (incluyendo el propio deferred con ese IdPalletTemporal).
        /// </summary>
        private void RecolectarDependientes(string idTemp, List<ReestibaDeferred> resultado)
        {
            var def = _reesibasDeferred.FirstOrDefault(d => d.IdPalletTemporal == idTemp);
            if (def is null || resultado.Contains(def)) return;

            resultado.Add(def);

            // Buscar deferreds que usan este temp como su original (hijos)
            foreach (var hijo in _reesibasDeferred.Where(d => d.IdPalletOriginalRef == idTemp))
                RecolectarDependientes(hijo.IdPalletTemporal, resultado);
        }

        // ============================================================================
        // UTILIDADES INTERNAS
        // ============================================================================

        /// <summary>
        /// Mueve un pallet de dgvDestibar a dgvPallets copiando la fila directamente.
        /// Solo se mueve ese pallet (aunque pertenezca a una estiba), sin consulta a DB
        /// y sin pasar por validaciones.
        /// </summary>
        private void RegresarPalletDesdeDestibar(string idPallet)
        {
            DataGridViewRow? fila = dgvDestibar.Rows.Cast<DataGridViewRow>()
                .FirstOrDefault(r => r.Cells["Pallet"].Value?.ToString() == idPallet);

            if (fila is null) return;

            object[] vals = new object[fila.Cells.Count];
            for (int i = 0; i < fila.Cells.Count; i++) vals[i] = fila.Cells[i].Value!;

            dgvPallets.Rows.Add(vals);
            // Limpiar color deferred al pasar al grid de mixteo
            dgvPallets.Rows[dgvPallets.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Empty;

            dgvDestibar.Rows.Remove(fila);

            cls.SeleccionarUltimaFila(dgvPallets);
            ActualizarTotales();
            cls.AplicarColorAdvertencias(dgvPallets);
        }

        private void ActualizarTotales()
        {
            int totalCajas   = cls.SumarCajas(dgvPallets);
            int cajasMaxGtin = cls.ObtenerCajasPorPalletMinimo(dgvPallets);

            txbBoxesStow.Text = totalCajas   > 0 ? totalCajas.ToString()   : string.Empty;
            txbBoxesMax.Text  = cajasMaxGtin > 0 ? cajasMaxGtin.ToString() : string.Empty;
        }

        private static void LimpiarYFocar(TextBox txb)
        {
            txb.Clear();
            txb.Focus();
        }

        /// <summary>
        /// Enfoca el TextBox y selecciona todo el texto sin borrarlo.
        /// Usado cuando se rechaza agregar un pallet para permitir corrección rápida.
        /// </summary>
        private static void FocarYSeleccionar(TextBox txb)
        {
            txb.Focus();
            txb.SelectAll();
        }

        private static void MostrarAviso(string mensaje, string titulo)
            => MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
