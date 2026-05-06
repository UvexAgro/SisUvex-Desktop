/*
 * FrmMixtearPallets.cs
 * ====================================================================================
 * Formulario principal del módulo "Mixtear Pallets en Estiba".
 *
 * FUNCIONALIDADES:
 *   ── SECCIÓN SUPERIOR (dgvPallets) ─────────────────────────────────────────────
 *   • Agregar pallets por ID con validaciones previas (manifiesto, cajas GTIN, diffs).
 *   • Mover el pallet seleccionado al listado inferior (↓ Mover a desestibar).
 *   • Quitar un pallet del formulario (✕ Quitar) — elimina de ambas grillas.
 *   • Reestibar (DEFERRED): la reestiba se almacena y no se ejecuta en DB hasta
 *     confirmar el mixteo (Guardar) o revertir (Reconfigurar).
 *     Comportamiento actual: el sobrante (pallet nuevo) QUEDA en dgvPallets,
 *     el original (con cajas reducidas) VA a dgvDestibar.
 *   • Ajuste asistido (⚙): calcula automáticamente qué pallets mantener/mover/dividir
 *     para que la suma coincida con el máximo de cajas GTIN. Se activa solo cuando
 *     el total supera el máximo.
 *   • Mixtear: ejecuta reestibas pendientes y luego crea la estiba en DB.
 *   • Reconfigurar: revierte reestibas pendientes sin tocar la DB.
 *
 *   ── SECCIÓN INFERIOR (dgvDestibar) ────────────────────────────────────────────
 *   • Recibe pallets vía "↓ Mover" o como originales de reestibas diferidas.
 *   • Regresar al listado superior (↑ Regresar a mixtear).
 *   • Desestiba SOLO los pallets del listado.
 *     — Con pallets deferred (Res_): bloquea a menos que sus originales también
 *       estén en dgvDestibar (ejecuta deferreds + desestiba).
 *
 * RELACIONES:
 *   - ClsMixtearPallets → lógica de negocio y acceso a datos.
 *   - FrmReestibaPallet → diálogo que recopila datos (no ejecuta en DB).
 *   - EMixtearPallets   → modelos de datos incl. ReestibaDeferred.
 *
 * ESCALABILIDAD:
 *   → PermitirSobrepasoMaxGtin: cambiar a true para relajar restricción de cajas.
 *   → Para cambiar el destino del sobrante/original: modificar EjecutarReestibaDeferredEnFila.
 * ====================================================================================
 */

using SisUvex.Catalogos.Metods.Values;

namespace SisUvex.Archivo.MixtearPallets
{
    public partial class FrmMixtearPallets : Form
    {
        private readonly ClsMixtearPallets cls = new();

        // ── Estado de reestibas diferidas ───────────────────────────────────────────

        /// <summary>
        /// Reestibas pendientes de ejecutarse en DB.
        /// Se llenan en btnReestibar_Click y se consumen en btnGuardar_Click.
        /// Al reconfigurar, se revierten en orden inverso.
        /// </summary>
        private readonly List<ReestibaDeferred> _reesibasDeferred = new();

        private int _nextDeferredOrd = 1;

        /// <summary>
        /// Tag aplicado a filas de dgvDestibar que representan pallets inactivos
        /// (reestibas completas o sobrantes de tipos inactivos).
        /// Estos pallets NO pueden regresar a dgvPallets porque serán inactivados en DB.
        /// </summary>
        private const string TAG_INACTIVO = "INACTIVO";

        /// <summary>Color de fondo para pallets pendientes de inactivar.</summary>
        private static readonly Color ColorInactivo = Color.LightSalmon;

        /// <summary>
        /// false → guardado bloqueado si cajas > máximo GTIN.
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

            // Estilo de selección personalizado: fondo transparente + texto negrita azul marino
            dgvPallets.CellPainting  += DgvSeleccion_CellPainting;
            dgvDestibar.CellPainting += DgvSeleccion_CellPainting;

            // Para activar la herramienta de ajuste de columnas, descomentar la siguiente línea:
            // DebugCargarColumnas();
        }

        // ============================================================================
        // CONTROLES DE PRUEBA – ajuste de anchos de columna
        // Para activar: descomentar la llamada a DebugCargarColumnas() en FrmMixtearPallets_Load.
        // ============================================================================

        /// <summary>
        /// Crea los controles de prueba en tiempo de ejecución, los agrega al formulario y conecta sus eventos.
        /// No existe ninguna traza de estos controles en el designer; todo vive aquí.
        /// Llamar desde FrmMixtearPallets_Load para activar la herramienta de ajuste de columnas.
        /// </summary>
        private void DebugCargarColumnas()
        {
            var lbl = new Label
            {
                Text      = "Col:",
                AutoSize  = true,
                Font      = new Font("Segoe UI", 8F, FontStyle.Italic),
                ForeColor = Color.Gray,
                Location  = new Point(658, 13),
                Anchor    = AnchorStyles.Top | AnchorStyles.Right,
            };

            var cbo = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font          = new Font("Segoe UI", 8F),
                Location      = new Point(685, 9),
                Size          = new Size(195, 23),
                Anchor        = AnchorStyles.Top | AnchorStyles.Right,
            };

            var nud = new NumericUpDown
            {
                Minimum  = 30,
                Maximum  = 600,
                Font     = new Font("Segoe UI", 8F),
                Location = new Point(885, 10),
                Size     = new Size(65, 23),
                Anchor   = AnchorStyles.Top | AnchorStyles.Right,
            };

            // Llenar combobox con los nombres de columna del dgvPallets
            foreach (DataGridViewColumn col in dgvPallets.Columns)
                cbo.Items.Add(col.Name);

            // Al seleccionar columna → mostrar su ancho actual en nud
            cbo.SelectedIndexChanged += (s, e) =>
            {
                if (cbo.SelectedItem is not string colName) return;
                if (!dgvPallets.Columns.Contains(colName)) return;

                nud.ValueChanged -= DebugNudAncho;
                nud.Value = dgvPallets.Columns[colName].Width;
                nud.ValueChanged += DebugNudAncho;

                void DebugNudAncho(object? _, EventArgs __)
                {
                    int ancho = (int)nud.Value;
                    if (dgvPallets.Columns.Contains(colName))
                    {
                        dgvPallets.Columns[colName].MinimumWidth = ancho;
                        dgvPallets.Columns[colName].Width        = ancho;
                    }
                    if (dgvDestibar.Columns.Contains(colName))
                    {
                        dgvDestibar.Columns[colName].MinimumWidth = ancho;
                        dgvDestibar.Columns[colName].Width        = ancho;
                    }
                }
            };

            Controls.Add(lbl);
            Controls.Add(cbo);
            Controls.Add(nud);

            if (cbo.Items.Count > 0)
                cbo.SelectedIndex = 0;
        }

        // ============================================================================
        // SECCIÓN SUPERIOR: PALLETS A MIXTEAR
        // ============================================================================

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
        /// Flujo para agregar un pallet al grid de mixteo con validaciones:
        ///   1. Duplicado en dgvPallets / en dgvDestibar (regresa directamente).
        ///   2. Pallet en manifiesto → bloquear.
        ///   3. Pallet con estiba → ofrecer toda la estiba.
        ///   4. Cajas vs. máximo GTIN.
        ///   5. Diferencias de producto.
        /// En rechazo: mantiene texto del TextBox (focus + SelectAll).
        /// </summary>
        private void AgregarPalletPorTexto(string textoId)
        {
            if (string.IsNullOrEmpty(textoId))
            {
                MostrarAviso("Ingrese el número de pallet.", "Agregar Pallet");
                return;
            }

            string idPallet = ClsValues.FormatZeros(textoId, "00000");

            if (cls.ExistePalletEnGrid(dgvPallets, idPallet))
            {
                MostrarAviso($"El pallet {idPallet} ya está en la lista de mixteo.", "Agregar Pallet");
                FocarYSeleccionar(txbIdPallet);
                return;
            }

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

            // ── Validación 0: pallet en manifiesto → bloquear ─────────────────────
            if (!string.IsNullOrEmpty(pallet.Manifiesto))
            {
                MostrarAviso(
                    $"El pallet {idPallet} no se puede agregar al mix porque ya está " +
                    $"incluido en un manifiesto.\n\n" +
                    $"  Manifiesto: {pallet.Manifiesto}",
                    "Pallet en manifiesto");
                FocarYSeleccionar(txbIdPallet);
                return;
            }

            // ── Validación 1: pallet con estiba → ofrecer toda la estiba ──────────
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
                else FocarYSeleccionar(txbIdPallet);
                return;
            }

            // ── Validación 2: cajas vs. máximo GTIN ─────────────────────────────
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

                    if (resp != DialogResult.Yes) { FocarYSeleccionar(txbIdPallet); return; }
                }
            }

            // ── Validación 3: diferencias de producto ─────────────────────────────
            List<string> diferencias = cls.ObtenerDiferenciasPallet(dgvPallets, pallet);
            if (diferencias.Count > 0)
            {
                var encabezados = diferencias
                    .Select(col => dgvPallets.Columns.Contains(col)
                        ? dgvPallets.Columns[col]!.HeaderText : col)
                    .ToList();

                var resp = MessageBox.Show(
                    $"El pallet {idPallet} difiere del resto en:\n" +
                    $"\n  •  {string.Join("\n  •  ", encabezados)}\n\n" +
                    "¿Desea agregarlo de todas formas?",
                    "Pallet con diferencias de producto",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (resp != DialogResult.Yes) { FocarYSeleccionar(txbIdPallet); return; }
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

        // ── Mover / Quitar ───────────────────────────────────────────────────────────

        private void btnQuitPallet_Click(object sender, EventArgs e)
        {
            if (dgvPallets.SelectedRows.Count == 0) { System.Media.SystemSounds.Beep.Play(); return; }
            cls.MoverPalletSeleccionadoAGrid(dgvPallets, dgvDestibar);
            ActualizarTotales();
            cls.AplicarColorAdvertencias(dgvPallets);
        }

        private void btnQuitarMix_Click(object sender, EventArgs e)
        {
            if (dgvPallets.SelectedRows.Count == 0) { System.Media.SystemSounds.Beep.Play(); return; }
            cls.QuitarPalletDeAmbosGrids(dgvPallets, dgvDestibar, dgvPallets.SelectedRows[0]);
            ActualizarTotales();
            cls.AplicarColorAdvertencias(dgvPallets);
        }

        private void btnQuitarDes_Click(object sender, EventArgs e)
        {
            if (dgvDestibar.SelectedRows.Count == 0) { System.Media.SystemSounds.Beep.Play(); return; }

            DataGridViewRow fila  = dgvDestibar.SelectedRows[0];
            string          idSel = fila.Cells["Pallet"].Value?.ToString() ?? "";

            if (ClsMixtearPallets.EsIdDeferred(idSel))
            {
                RevertirDeferredPorTempId(idSel);
                return;
            }

            // Fila inactiva (reestiba completa pendiente) → revertir el deferred
            if (fila.Tag?.ToString() == TAG_INACTIVO)
            {
                var defCompleto = _reesibasDeferred
                    .FirstOrDefault(d => d.EsCompleta && d.IdPalletOriginalRef == idSel);

                if (defCompleto is not null)
                {
                    var conf = MessageBox.Show(
                        $"¿Cancelar la reestiba pendiente del pallet {idSel} ({defCompleto.Tipo.Nombre})\n" +
                        "y devolverlo al listado de mixtear?",
                        "Revertir reestiba", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (conf != DialogResult.Yes) return;

                    cls.QuitarPalletPorId(dgvDestibar, idSel);
                    _reesibasDeferred.Remove(defCompleto);
                    PalletInfo? p = cls.ConsultarPallet(idSel);
                    if (p is not null) cls.AgregarPalletAlGrid(dgvPallets, p);
                    ActualizarTotales();
                    cls.AplicarColorAdvertencias(dgvPallets);
                    return;
                }
            }

            cls.QuitarPalletDeAmbosGrids(dgvPallets, dgvDestibar, fila);
            ActualizarTotales();
            cls.AplicarColorAdvertencias(dgvPallets);
        }

        // ── Reestibar pallet seleccionado (MODO DEFERRED) ───────────────────────────

        private void btnReestibar_Click(object sender, EventArgs e)
        {
            if (dgvPallets.SelectedRows.Count == 0) { System.Media.SystemSounds.Beep.Play(); return; }

            DataGridViewRow fila  = dgvPallets.SelectedRows[0];
            string          idRef = fila.Cells["Pallet"].Value?.ToString() ?? "";
            int             cajas = GetCajasDeFilaGrid(fila);

            if (cajas <= 1)
            {
                MostrarAviso(
                    $"El pallet {idRef} solo tiene {cajas} caja(s).\n" +
                    "Se requiere más de 1 caja para poder reestibar.", "Reestibar");
                return;
            }

            List<TipoReestiba> tipos = cls.ObtenerTiposReestiba();
            if (tipos.Count == 0)
            {
                MostrarAviso("No se encontraron tipos de reestiba activos.", "Reestibar – Sin tipos");
                return;
            }

            PalletInfo palletDlg = cls.ObtenerPalletSeleccionado(dgvPallets)
                ?? new PalletInfo { IdPallet = idRef, Cajas = cajas };

            using FrmReestibaPallet dlg = new(palletDlg, tipos);
            if (dlg.ShowDialog(this) != DialogResult.OK) return;

            EjecutarReestibaDeferredEnFila(fila, dlg.NuevasCajas, dlg.TipoSeleccionado, dlg.EsReestibaCompleta);

            ActualizarTotales();
            cls.AplicarColorAdvertencias(dgvPallets);
        }

        // ── Guardar / Mixtear ───────────────────────────────────────────────────────

        private void btnGuardar_Click(object sender, EventArgs e)
        {
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
                        "Desestibar Pallet", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (conf != DialogResult.Yes) return;

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
                else System.Media.SystemSounds.Beep.Play();
                return;
            }

            int totalCajas = cls.SumarCajas(dgvPallets);

            if (!cls.ValidarParaMixtear(dgvPallets, totalCajas, out string error, out string advertencia))
            {
                MessageBox.Show(error, "Mixtear – No permitido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!string.IsNullOrEmpty(advertencia))
            {
                var conf = MessageBox.Show(advertencia + "\n\n¿Desea continuar?",
                    "Mixtear – Advertencias", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (conf != DialogResult.Yes) return;
            }

            int cajasMaxGtin = cls.ObtenerCajasPorPalletMinimo(dgvPallets);
            if (cajasMaxGtin > 0 && totalCajas > cajasMaxGtin && !PermitirSobrepasoMaxGtin)
            {
                MessageBox.Show(
                    $"Las cajas totales ({totalCajas} cjs.) superan el máximo del GTIN " +
                    $"({cajasMaxGtin} cjs.).\n\nQuite pallets hasta ajustar el total.",
                    "Cajas excedidas – Guardado bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            EjecutarYAplicarDeferreds();

            string nuevaEstiba = cls.EjecutarMixtear(dgvPallets);
            if (string.IsNullOrEmpty(nuevaEstiba)) { txbIdPallet.Focus(); return; }

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
                var conf = MessageBox.Show(
                    $"Hay {_reesibasDeferred.Count} reestiba(s) pendiente(s) sin guardar.\n\n" +
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
                return;
            }

            if (dgvPallets.Rows.Count > 0 || dgvDestibar.Rows.Count > 0)
            {
                var conf = MessageBox.Show("¿Desea limpiar ambas listas de pallets?",
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
        // AJUSTE ASISTIDO AL GTIN
        // ============================================================================

        /// <summary>
        /// Calcula el plan óptimo para ajustar los pallets en dgvPallets al máximo
        /// de cajas GTIN y lo propone al usuario, ejecutándolo si confirma.
        ///
        /// ALGORITMO:
        ///   1. Agrupa pallets por estiba (pallets sin estiba = grupo individual).
        ///   2. Ordena grupos por total de cajas, mayor primero.
        ///   3. Llena greedy hasta el máximo; el grupo que desborda se parte:
        ///      • Pallet/estiba que sobra completamente → MOVER a dgvDestibar.
        ///      • Pallet que llega exactamente al límite → DIVIDIR (reestiba).
        ///   4. Todos los grupos posteriores → MOVER a dgvDestibar.
        /// </summary>
        private void btnAsistido_Click(object sender, EventArgs e)
        {
            int totalCajas = cls.SumarCajas(dgvPallets);
            int cajasMax   = cls.ObtenerCajasPorPalletMinimo(dgvPallets);

            if (cajasMax <= 0 || totalCajas <= cajasMax) return; // Botón debería estar disabled

            List<PalletPlan> plan = CalcularPlanAsistido(cajasMax);

            var mantener = plan.Where(p => p.Accion == AccionAsistida.Mantener).ToList();
            var dividir  = plan.Where(p => p.Accion == AccionAsistida.Dividir).ToList();
            var mover    = plan.Where(p => p.Accion == AccionAsistida.Mover).ToList();

            string GetId(PalletPlan p)   => p.Fila.Cells["Pallet"].Value?.ToString() ?? "?";
            int    GetCajas(PalletPlan p) => GetCajasDeFilaGrid(p.Fila);

            var sb = new System.Text.StringBuilder();
            sb.AppendLine($"Plan de ajuste al máximo GTIN ({cajasMax} cjs.):");
            sb.AppendLine();

            if (mantener.Count > 0)
            {
                sb.AppendLine("Sin cambios (quedan en el mix):");
                foreach (var p in mantener)
                    sb.AppendLine($"  •  {GetId(p)}  ({GetCajas(p)} cjs.)");
                sb.AppendLine();
            }

            if (dividir.Count > 0)
            {
                sb.AppendLine("Reestibar (dividir):");
                foreach (var p in dividir)
                {
                    int tot = GetCajas(p);
                    sb.AppendLine($"  •  {GetId(p)} ({tot} cjs.)  →  " +
                        $"{p.CajasNuevasSobrante} cjs. quedan en mix | " +
                        $"{tot - p.CajasNuevasSobrante} cjs. al desestibar");
                }
                sb.AppendLine();
            }

            if (mover.Count > 0)
            {
                sb.AppendLine("Mover al desestibar (completo):");
                foreach (var p in mover)
                    sb.AppendLine($"  •  {GetId(p)}  ({GetCajas(p)} cjs.)");
                sb.AppendLine();
            }

            int resultante = mantener.Sum(p => GetCajas(p)) + dividir.Sum(p => p.CajasNuevasSobrante);
            sb.AppendLine($"Total resultante en mix: {resultante} / {cajasMax} cjs.");

            if (dividir.Count > 0)
                sb.AppendLine("\nSe abrirá el diálogo de reestiba para cada pallet a dividir.");

            sb.AppendLine("\n¿Desea aplicar este ajuste?");

            var confirmar = MessageBox.Show(sb.ToString(), "⚙ Ajuste asistido",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmar != DialogResult.Yes) return;

            List<TipoReestiba> tipos = cls.ObtenerTiposReestiba();
            if (tipos.Count == 0)
            {
                MostrarAviso("No se encontraron tipos de reestiba activos.", "Ajuste asistido");
                return;
            }

            // ── DIVIDIR: abrir diálogo pre-relleno para cada uno ────────────────────
            foreach (var accion in dividir)
            {
                if (!dgvPallets.Rows.Contains(accion.Fila)) continue;

                int    cajas      = GetCajas(accion);
                string idRef      = GetId(accion);
                int    cajasOrigRec = cajas - accion.CajasNuevasSobrante; // Lo que queda en el original

                PalletInfo palletDlg = new PalletInfo
                {
                    IdPallet = idRef,
                    Cajas    = cajas,
                    Programa = dgvPallets.Columns.Contains("GTIN") ? accion.Fila.Cells["GTIN"].Value?.ToString() ?? "" : "",
                    Estiba   = dgvPallets.Columns.Contains("Estiba")   ? accion.Fila.Cells["Estiba"].Value?.ToString()   ?? "" : "",
                };

                using FrmReestibaPallet dlg = new(palletDlg, tipos, cajasOrigRec);
                if (dlg.ShowDialog(this) != DialogResult.OK) continue;

                EjecutarReestibaDeferredEnFila(accion.Fila, dlg.NuevasCajas, dlg.TipoSeleccionado, dlg.EsReestibaCompleta);
            }

            // ── MOVER: copiar fila a dgvDestibar y quitar de dgvPallets ─────────────
            foreach (var accion in mover)
            {
                if (!dgvPallets.Rows.Contains(accion.Fila)) continue;

                object[] vals = new object[accion.Fila.Cells.Count];
                for (int i = 0; i < accion.Fila.Cells.Count; i++)
                    vals[i] = accion.Fila.Cells[i].Value!;

                dgvDestibar.Rows.Add(vals);
                dgvPallets.Rows.Remove(accion.Fila);
            }

            ActualizarTotales();
            cls.AplicarColorAdvertencias(dgvPallets);
        }

        /// <summary>
        /// Calcula el plan de ajuste asistido respetando las reglas:
        ///   A) Sin estiba: pallets individuales ordenados por cajas desc.
        ///   B) Con estiba: se considera la estiba completa como una unidad;
        ///      si no cabe entera, se va pallet por pallet dentro de ella.
        /// Retorna una lista con la acción asignada a cada fila de dgvPallets.
        /// </summary>
        private List<PalletPlan> CalcularPlanAsistido(int cajasMax)
        {
            var plan  = new List<PalletPlan>();
            var filas = dgvPallets.Rows.Cast<DataGridViewRow>().ToList();

            // Agrupar por estiba (sin estiba → clave única por índice de fila)
            var grupos = filas
                .GroupBy(r =>
                {
                    string est = r.Cells["Estiba"].Value?.ToString() ?? "";
                    return string.IsNullOrEmpty(est) ? $"\0{r.Index}" : est;
                })
                .Select(g => new
                {
                    EsEstiba = !g.Key.StartsWith('\0'),
                    Filas    = g.ToList(),
                    Total    = g.Sum(r => GetCajasDeFilaGrid(r)),
                })
                .OrderByDescending(g => g.Total)
                .ToList();

            int remaining = cajasMax;

            foreach (var grupo in grupos)
            {
                if (remaining <= 0)
                {
                    // Sin capacidad → mover todo el grupo
                    foreach (var f in grupo.Filas) plan.Add(new PalletPlan(f, AccionAsistida.Mover));
                    continue;
                }

                if (grupo.Total <= remaining)
                {
                    // Cabe completo → mantener
                    foreach (var f in grupo.Filas) plan.Add(new PalletPlan(f, AccionAsistida.Mantener));
                    remaining -= grupo.Total;
                }
                else
                {
                    // Desborda → procesar pallet por pallet (mayor a menor)
                    var palletsOrden = grupo.Filas
                        .OrderByDescending(r => GetCajasDeFilaGrid(r))
                        .ToList();

                    foreach (var f in palletsOrden)
                    {
                        int cajas = GetCajasDeFilaGrid(f);

                        if (remaining <= 0)
                        {
                            plan.Add(new PalletPlan(f, AccionAsistida.Mover));
                        }
                        else if (cajas <= remaining)
                        {
                            plan.Add(new PalletPlan(f, AccionAsistida.Mantener));
                            remaining -= cajas;
                        }
                        else
                        {
                            // Este pallet es el que se divide
                            plan.Add(new PalletPlan(f, AccionAsistida.Dividir, remaining));
                            remaining = 0;
                        }
                    }
                }
            }

            return plan;
        }

        // ============================================================================
        // SECCIÓN INFERIOR: PALLETS A DESESTIBAR
        // ============================================================================

        private void btnAddToUp_Click(object sender, EventArgs e)
        {
            if (dgvDestibar.Rows.Count == 0)
            {
                MostrarAviso(
                    "No hay pallets en el listado de desestibar.\n" +
                    "Use '↓ Mover a desestibar' para enviarlos desde la lista superior.",
                    "Regresar");
                return;
            }

            var filas = dgvDestibar.SelectedRows.Count > 0
                ? dgvDestibar.SelectedRows.Cast<DataGridViewRow>().ToList()
                : dgvDestibar.Rows.Cast<DataGridViewRow>().ToList();

            var aRemover = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in filas)
            {
                string idPallet = row.Cells["Pallet"].Value?.ToString() ?? "";
                if (string.IsNullOrEmpty(idPallet)) continue;
                if (cls.ExistePalletEnGrid(dgvPallets, idPallet)) continue;

                // Los pallets inactivos (reestibas completas / sobrantes inactivos) no pueden
                // regresar a dgvPallets porque serán inactivados en DB al confirmar.
                if (row.Tag?.ToString() == TAG_INACTIVO) continue;

                object[] vals = new object[row.Cells.Count];
                for (int i = 0; i < row.Cells.Count; i++) vals[i] = row.Cells[i].Value!;
                dgvPallets.Rows.Add(vals);
                // Quitar color deferred si lo tenía
                dgvPallets.Rows[dgvPallets.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Empty;
                aRemover.Add(row);
            }

            foreach (var r in aRemover) dgvDestibar.Rows.Remove(r);

            ActualizarTotales();
            cls.AplicarColorAdvertencias(dgvPallets);
            cls.SeleccionarUltimaFila(dgvPallets);
        }

        /// <summary>
        /// Desestiba los pallets del listado inferior.
        /// Con pallets deferred (Res_): bloquea si su original no está también en el listado.
        /// Excepción: si original + todos sus deferred están en dgvDestibar →
        /// ejecuta los deferreds y desestiba todos.
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvDestibar.Rows.Count == 0)
            {
                MostrarAviso(
                    "No hay pallets en el listado de desestibar.\n" +
                    "Mueva los pallets usando '↓ Mover a desestibar'.",
                    "Desestibar");
                return;
            }

            var idsEnDestibar = dgvDestibar.Rows.Cast<DataGridViewRow>()
                .Select(r => r.Cells["Pallet"].Value?.ToString() ?? "")
                .Where(id => !string.IsNullOrEmpty(id))
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            var deferredsEnDestibar = _reesibasDeferred
                .Where(d => !d.EsCompleta && idsEnDestibar.Contains(d.IdPalletTemporal))
                .ToList();

            // ── Ejecutar reestibas COMPLETAS pendientes cuyos pallets están en el listado ──
            var completasEnDestibar = _reesibasDeferred
                .Where(d => d.EsCompleta && idsEnDestibar.Contains(d.IdPalletOriginalRef))
                .ToList();

            int completasEjecutadas = 0;
            foreach (var def in completasEnDestibar)
            {
                string idPalletInac = def.IdPalletOriginalRef;

                var filaInac = dgvDestibar.Rows.Cast<DataGridViewRow>()
                    .FirstOrDefault(r => r.Cells["Pallet"].Value?.ToString() == idPalletInac);

                // Desestibarlo siempre: si no tenía estiba el UPDATE es un no-op seguro
                cls.EjecutarDesestibarPallet(idPalletInac);

                // Ejecutar la reestiba completa (inactiva el pallet en DB)
                cls.EjecutarReestibaCompleta(idPalletInac, def.Tipo);
                _reesibasDeferred.Remove(def);
                completasEjecutadas++;

                // Quitar la fila del grid: el pallet ya está inactivado, no queda nada pendiente
                if (filaInac is not null)
                    dgvDestibar.Rows.Remove(filaInac);
            }

            // Si solo había reestibas completas y no queda más nada, avisar y salir
            if (completasEjecutadas > 0 && dgvDestibar.Rows.Count == 0)
            {
                MessageBox.Show(
                    $"{completasEjecutadas} pallet(s) procesados correctamente con reestiba completa.",
                    "Reestiba completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // ── Ejecutar reestibas PARCIALES pendientes (Res_) cuyo original también está ──
            if (deferredsEnDestibar.Count > 0)
            {
                // Solo los de tipo activo (SOBRANTE) requieren que el original
                // esté en dgvDestibar; los de tipo inactivo tienen su original en dgvPallets.
                var originalesAusentes = deferredsEnDestibar
                    .Where(d => d.Tipo.NuevoPalletActivo && !idsEnDestibar.Contains(d.IdPalletOriginalRef))
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

                // Todos los originales presentes → ejecutar esos deferreds
                var mapping = cls.EjecutarReesibasDeferred(deferredsEnDestibar);
                foreach (var (idTemp, idReal) in mapping)
                {
                    ClsMixtearPallets.ActualizarIdEnGrid(dgvPallets, idTemp, idReal);
                    ClsMixtearPallets.ActualizarIdEnGrid(dgvDestibar, idTemp, idReal);
                }
                foreach (var def in deferredsEnDestibar) _reesibasDeferred.Remove(def);
            }

            var conEstiba = dgvDestibar.Rows.Cast<DataGridViewRow>()
                .Where(r => !string.IsNullOrEmpty(r.Cells["Estiba"].Value?.ToString()))
                .ToList();

            if (conEstiba.Count == 0)
            {
                string msgCompletas = completasEjecutadas > 0
                    ? $"{completasEjecutadas} pallet(s) con reestiba completa procesados.\n\n"
                    : string.Empty;
                MostrarAviso(
                    msgCompletas + "Los pallets restantes del listado no tienen estiba asignada. No hay nada que desestibar.",
                    "Desestibar");
                return;
            }

            var conf = MessageBox.Show(
                $"¿Confirma desestibar {conEstiba.Count} pallet(s) del listado?",
                "Confirmar Desestibar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (conf != DialogResult.Yes) return;

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
        /// Registra una reestiba diferida para la fila dada y actualiza ambas grillas.
        ///
        /// COMPORTAMIENTO ACTUAL (configurable aquí):
        ///   • Reestiba COMPLETA: quita el pallet de dgvPallets (se inactiva al guardar).
        ///   • Reestiba PARCIAL:
        ///       - El ORIGINAL (con cajas reducidas) → se mueve a dgvDestibar.
        ///       - El SOBRANTE (pallet nuevo Res_XXXXX) → se agrega a dgvPallets.
        ///
        /// Muestra un MessageBox informativo al terminar.
        /// </summary>
        private void EjecutarReestibaDeferredEnFila(
            DataGridViewRow filaOrig, int nuevasCajas, TipoReestiba tipo, bool esCompleta)
        {
            string idRef  = filaOrig.Cells["Pallet"].Value?.ToString() ?? "";
            int    cajas  = GetCajasDeFilaGrid(filaOrig);
            bool   esReal = !ClsMixtearPallets.EsIdDeferred(idRef);

            if (esCompleta)
            {
                // ── Reestiba COMPLETA: asignar motivo + inactivar el pallet ────────
                var def = new ReestibaDeferred
                {
                    Orden               = _nextDeferredOrd++,
                    IdPalletOriginalRef = idRef,
                    OriginalEsReal      = esReal,
                    CajasAntes          = cajas,
                    NuevasCajasOriginal = cajas,
                    Tipo                = tipo,
                    EsCompleta          = true,
                };
                _reesibasDeferred.Add(def);

                // Mover el pallet a dgvDestibar con indicador visual (no desaparece)
                object[] valsOrig = CopiarCeldas(filaOrig);
                dgvDestibar.Rows.Add(valsOrig);
                DataGridViewRow filaInac = dgvDestibar.Rows[dgvDestibar.Rows.Count - 1];
                filaInac.Cells["Estiba"].Value      = string.Empty;    // Ya no pertenece a estiba
                filaInac.Cells["Mix"].Value          = $"{tipo.Nombre}"; // Indicador de motivo
                filaInac.DefaultCellStyle.BackColor  = ColorInactivo;
                filaInac.Tag                         = TAG_INACTIVO;
                dgvPallets.Rows.Remove(filaOrig);

                MessageBox.Show(
                    $"Reestiba completa del pallet {idRef} registrada como pendiente.\n" +
                    $"  Tipo: {tipo.Nombre}\n\n" +
                    "El pallet aparece en el listado inferior en rojo salmón.\n" +
                    "Se ejecutará al confirmar (Guardar o Desestibar listado).",
                    "Reestiba Pendiente – Pallet Inactivo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // ── Reestiba PARCIAL: divide el pallet ──────────────────────────────
                int    nCajas    = cajas - nuevasCajas;
                string idTemp    = GenerarIdDeferred(idRef);
                bool   sobActivo = tipo.NuevoPalletActivo; // Solo SOBRANTE crea pallet activo

                var def = new ReestibaDeferred
                {
                    Orden               = _nextDeferredOrd++,
                    IdPalletOriginalRef = idRef,
                    OriginalEsReal      = esReal,
                    CajasAntes          = cajas,
                    NuevasCajasOriginal = nuevasCajas,
                    IdPalletTemporal    = idTemp,
                    CajasNuevoPallet    = nCajas,
                    Tipo                = tipo,
                    EsCompleta          = false,
                };
                _reesibasDeferred.Add(def);

                // Capturar valores base del original ANTES de modificar cajas
                object[] valsBase = CopiarCeldas(filaOrig);

                if (sobActivo)
                {
                    // ── Tipo ACTIVO (SOBRANTE): original → dgvDestibar, sobrante → dgvPallets ──
                    filaOrig.Cells["Cajas"].Value = nuevasCajas;
                    object[] valsOrigMod = CopiarCeldas(filaOrig);
                    dgvDestibar.Rows.Add(valsOrigMod);
                    dgvPallets.Rows.Remove(filaOrig);

                    dgvPallets.Rows.Add(valsBase);
                    DataGridViewRow filaRes = dgvPallets.Rows[dgvPallets.Rows.Count - 1];
                    filaRes.Cells["Pallet"].Value      = idTemp;
                    filaRes.Cells["Cajas"].Value       = nCajas;
                    filaRes.Cells["Estiba"].Value      = string.Empty;
                    filaRes.Cells["Mix"].Value         = string.Empty;
                    filaRes.DefaultCellStyle.BackColor = Color.LightCyan;

                    MessageBox.Show(
                        $"Reestiba del pallet {idRef} registrada como pendiente.\n" +
                        $"  • Original ({nuevasCajas} cjs.) → listado de desestibar.\n" +
                        $"  • Sobrante temporal ({idTemp}, {nCajas} cjs.) → listado de mixtear.\n\n" +
                        "Se aplicará al confirmar (Guardar o Desestibar listado).",
                        "Reestiba Pendiente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // ── Tipo INACTIVO (ERROR, SINIESTRADO, etc.):
                    //    original permanece en dgvPallets con cajas reducidas,
                    //    pallet reestibado (inactivo) → dgvDestibar ─────────────────────────
                    filaOrig.Cells["Cajas"].Value = nuevasCajas; // actualizar cajas, sin mover

                    // Pallet reestibado inactivo → dgvDestibar
                    dgvPallets.Rows.Add(valsBase); // temporal para obtener referencia de fila
                    DataGridViewRow filaRes = dgvPallets.Rows[dgvPallets.Rows.Count - 1];
                    filaRes.Cells["Pallet"].Value  = idTemp;
                    filaRes.Cells["Cajas"].Value   = nCajas;
                    filaRes.Cells["Estiba"].Value  = string.Empty;
                    filaRes.Cells["Mix"].Value     = tipo.Nombre;
                    dgvPallets.Rows.Remove(filaRes);
                    dgvDestibar.Rows.Add(CopiarCeldas(filaRes));
                    DataGridViewRow filaInacSob = dgvDestibar.Rows[dgvDestibar.Rows.Count - 1];
                    filaInacSob.DefaultCellStyle.BackColor = ColorInactivo;
                    filaInacSob.Tag                        = TAG_INACTIVO;

                    MessageBox.Show(
                        $"Reestiba del pallet {idRef} registrada como pendiente.\n" +
                        $"  • Original ({nuevasCajas} cjs.) → permanece en listado de mixtear.\n" +
                        $"  • Reestibado temporal ({idTemp}, {nCajas} cjs., {tipo.Nombre}) → listado de desestibar (inactivo).\n\n" +
                        "Se aplicará al confirmar (Guardar o Desestibar listado).",
                        "Reestiba Pendiente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// Ejecuta todos los deferreds y actualiza ambas grillas con los IDs reales.
        /// Llama antes de EjecutarMixtear o de cualquier operación que requiera DB.
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
        /// Revierte TODOS los deferreds en orden inverso sin tocar la DB.
        /// Para parciales: quita el Res_ de ambas grillas y devuelve el original
        ///   desde dgvDestibar a dgvPallets con sus cajas originales.
        /// Para completas: re-consulta el pallet de DB y lo vuelve a agregar.
        /// </summary>
        private void RevertirTodosLosDeferreds()
        {
            foreach (var def in _reesibasDeferred.OrderByDescending(r => r.Orden))
            {
                if (def.EsCompleta)
                {
                    // El pallet está en dgvDestibar (fue movido allí al crear el deferred)
                    cls.QuitarPalletPorId(dgvDestibar, def.IdPalletOriginalRef);

                    if (def.OriginalEsReal)
                    {
                        PalletInfo? p = cls.ConsultarPallet(def.IdPalletOriginalRef);
                        if (p is not null) cls.AgregarPalletAlGrid(dgvPallets, p);
                    }
                }
                else
                {
                    // Quitar sobrante (Res_) de ambas grillas
                    cls.QuitarPalletPorId(dgvPallets, def.IdPalletTemporal);
                    cls.QuitarPalletPorId(dgvDestibar, def.IdPalletTemporal);

                    // Devolver original a dgvPallets con cajas previas
                    if (def.OriginalEsReal)
                    {
                        bool estaEnDes = GridContieneId(dgvDestibar, def.IdPalletOriginalRef);
                        cls.QuitarPalletPorId(dgvDestibar, def.IdPalletOriginalRef);
                        cls.QuitarPalletPorId(dgvPallets,  def.IdPalletOriginalRef);

                        PalletInfo? p = cls.ConsultarPallet(def.IdPalletOriginalRef);
                        if (p is not null)
                            cls.AgregarPalletAlGrid(dgvPallets, p);
                        else if (estaEnDes)
                        {
                            // Fallback: restaurar cajas manualmente si la DB no devuelve datos
                            cls.ActualizarCajasEnGrid(dgvPallets, def.IdPalletOriginalRef, def.CajasAntes);
                        }
                    }
                    else
                    {
                        // Original deferred (Res_): mover de dgvDestibar a dgvPallets con CajasAntes
                        if (GridContieneId(dgvDestibar, def.IdPalletOriginalRef))
                            MoverPalletConCajasEntrGrids(dgvDestibar, dgvPallets,
                                def.IdPalletOriginalRef, def.CajasAntes);
                        else
                            cls.ActualizarCajasEnGrid(dgvPallets, def.IdPalletOriginalRef, def.CajasAntes);
                    }
                }
            }

            _reesibasDeferred.Clear();
            _nextDeferredOrd = 1;
        }

        /// <summary>
        /// Revierte solo el deferred identificado por su IdPalletTemporal,
        /// más todos los descendientes (deferreds que dependen de él).
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
                cls.QuitarPalletPorId(dgvPallets, def.IdPalletTemporal);
                cls.QuitarPalletPorId(dgvDestibar, def.IdPalletTemporal);

                if (!def.EsCompleta)
                {
                    if (def.OriginalEsReal)
                    {
                        cls.QuitarPalletPorId(dgvDestibar, def.IdPalletOriginalRef);
                        cls.QuitarPalletPorId(dgvPallets,  def.IdPalletOriginalRef);
                        PalletInfo? p = cls.ConsultarPallet(def.IdPalletOriginalRef);
                        if (p is not null) cls.AgregarPalletAlGrid(dgvPallets, p);
                    }
                    else
                    {
                        if (GridContieneId(dgvDestibar, def.IdPalletOriginalRef))
                            MoverPalletConCajasEntrGrids(dgvDestibar, dgvPallets,
                                def.IdPalletOriginalRef, def.CajasAntes);
                        else
                            cls.ActualizarCajasEnGrid(dgvPallets, def.IdPalletOriginalRef, def.CajasAntes);
                    }
                }

                _reesibasDeferred.Remove(def);
            }

            ActualizarTotales();
            cls.AplicarColorAdvertencias(dgvPallets);
        }

        private void RecolectarDependientes(string idTemp, List<ReestibaDeferred> resultado)
        {
            var def = _reesibasDeferred.FirstOrDefault(d => d.IdPalletTemporal == idTemp);
            if (def is null || resultado.Contains(def)) return;
            resultado.Add(def);
            foreach (var hijo in _reesibasDeferred.Where(d => d.IdPalletOriginalRef == idTemp))
                RecolectarDependientes(hijo.IdPalletTemporal, resultado);
        }

        // ============================================================================
        // UTILIDADES INTERNAS
        // ============================================================================

        /// <summary>
        /// Mueve el pallet identificado por idPallet de 'origen' a 'destino',
        /// actualizando su columna Cajas con cajasOriginales y quitando el color deferred.
        /// </summary>
        private static void MoverPalletConCajasEntrGrids(
            DataGridView origen, DataGridView destino, string idPallet, int cajasOriginales)
        {
            DataGridViewRow? fila = origen.Rows.Cast<DataGridViewRow>()
                .FirstOrDefault(r => r.Cells["Pallet"].Value?.ToString() == idPallet);
            if (fila is null) return;

            object[] vals = CopiarCeldas(fila);
            destino.Rows.Add(vals);
            DataGridViewRow nueva = destino.Rows[destino.Rows.Count - 1];
            nueva.Cells["Cajas"].Value = cajasOriginales;
            nueva.DefaultCellStyle.BackColor = Color.Empty;

            origen.Rows.Remove(fila);
        }

        /// <summary>
        /// Mueve un pallet de dgvDestibar a dgvPallets copiando la fila directamente
        /// (sin re-consultar la DB ni pasar por validaciones).
        /// </summary>
        private void RegresarPalletDesdeDestibar(string idPallet)
        {
            DataGridViewRow? fila = dgvDestibar.Rows.Cast<DataGridViewRow>()
                .FirstOrDefault(r => r.Cells["Pallet"].Value?.ToString() == idPallet);
            if (fila is null) return;

            dgvPallets.Rows.Add(CopiarCeldas(fila));
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

            // Habilitar "Ajuste asistido" solo cuando hay exceso de cajas
            btnAsistido.Enabled = cajasMaxGtin > 0 && totalCajas > cajasMaxGtin;
        }

        private static object[] CopiarCeldas(DataGridViewRow fila)
        {
            object[] vals = new object[fila.Cells.Count];
            for (int i = 0; i < fila.Cells.Count; i++) vals[i] = fila.Cells[i].Value!;
            return vals;
        }

        private static int GetCajasDeFilaGrid(DataGridViewRow fila)
            => int.TryParse(fila.Cells["Cajas"].Value?.ToString(), out int c) ? c : 0;

        private static bool GridContieneId(DataGridView dgv, string id)
            => dgv.Rows.Cast<DataGridViewRow>()
               .Any(r => r.Cells["Pallet"].Value?.ToString() == id);

        // ── Estilo de selección personalizado ───────────────────────────────────────

        /// <summary>
        /// Pinta las celdas seleccionadas manteniendo el color de fondo original de la celda
        /// (amarillo, rojo, cyan, etc.) y aplicando texto en negrita azul marino al texto,
        /// para que las diferencias de producto sigan siendo visibles aunque la fila esté seleccionada.
        /// </summary>
        private static void DgvSeleccion_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (sender is not DataGridView dgv) return;
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            DataGridViewRow row = dgv.Rows[e.RowIndex];
            if (!row.Selected) return;

            e.Handled = true; // Anular el pintado por defecto

            // ── 1. Fondo: usar el color real de la celda, no el azul de selección ──
            // Prioridad: estilo específico de celda > estilo de fila > estilo por defecto
            Color bg = e.CellStyle.BackColor;
            if (bg.IsEmpty || bg == Color.Empty)
                bg = dgv.DefaultCellStyle.BackColor;
            if (bg.IsEmpty || bg == Color.Empty)
                bg = SystemColors.ControlLightLight;

            e.Graphics.FillRectangle(new SolidBrush(bg), e.CellBounds);

            // ── 2. Líneas de cuadrícula ────────────────────────────────────────────
            using var penGrid = new Pen(dgv.GridColor);
            // Línea inferior
            e.Graphics.DrawLine(penGrid,
                e.CellBounds.Left,              e.CellBounds.Bottom - 1,
                e.CellBounds.Right - 1,         e.CellBounds.Bottom - 1);
            // Línea derecha
            e.Graphics.DrawLine(penGrid,
                e.CellBounds.Right - 1,         e.CellBounds.Top,
                e.CellBounds.Right - 1,         e.CellBounds.Bottom - 1);

            // ── 3. Texto: negrita + azul marino (mismo tono que el fondo de selección) ──
            string texto = e.FormattedValue?.ToString() ?? "";
            if (texto.Length > 0)
            {
                // SystemColors.Highlight = azul del resaltado de Windows (igual al acento del sistema)
                using Font boldFont    = new Font(e.CellStyle.Font ?? dgv.Font, FontStyle.Bold);
                using var textBrush    = new SolidBrush(SystemColors.Highlight);

                // Margen interior de la celda
                int pad = 3;
                var textRect = new RectangleF(
                    e.CellBounds.Left   + pad,
                    e.CellBounds.Top    + pad,
                    e.CellBounds.Width  - pad * 2,
                    e.CellBounds.Height - pad * 2);

                // Alineación horizontal según el estilo configurado en la columna
                StringAlignment hAlign = e.CellStyle.Alignment switch
                {
                    DataGridViewContentAlignment.MiddleRight  or
                    DataGridViewContentAlignment.TopRight     or
                    DataGridViewContentAlignment.BottomRight  => StringAlignment.Far,

                    DataGridViewContentAlignment.MiddleCenter or
                    DataGridViewContentAlignment.TopCenter    or
                    DataGridViewContentAlignment.BottomCenter => StringAlignment.Center,

                    _ => StringAlignment.Near,
                };

                using var sf = new StringFormat
                {
                    Alignment     = hAlign,
                    LineAlignment = StringAlignment.Center,
                    Trimming      = StringTrimming.EllipsisCharacter,
                    FormatFlags   = StringFormatFlags.NoWrap,
                };

                e.Graphics.DrawString(texto, boldFont, textBrush, textRect, sf);
            }
        }

        private static void LimpiarYFocar(TextBox txb) { txb.Clear(); txb.Focus(); }

        private static void FocarYSeleccionar(TextBox txb) { txb.Focus(); txb.SelectAll(); }

        private static void MostrarAviso(string mensaje, string titulo)
            => MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);

        // ── Tipos locales para el plan de ajuste asistido ───────────────────────────

        private enum AccionAsistida { Mantener, Mover, Dividir }

        private record PalletPlan(DataGridViewRow Fila, AccionAsistida Accion, int CajasNuevasSobrante = 0);
    }
}
