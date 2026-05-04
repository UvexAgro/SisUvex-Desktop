/*
 * FrmMixtearPallets.cs
 * ====================================================================================
 * Formulario principal del módulo "Mixtear Pallets en Estiba".
 *
 * FUNCIONALIDADES:
 *   ── SECCIÓN SUPERIOR (dgvPallets) ─────────────────────────────────────────────
 *   • Agregar pallets por ID con validaciones previas:
 *       - Si el pallet pertenece a una estiba → ofrecerla completa.
 *       - Si las cajas superan el máximo GTIN → advertencia + confirmación.
 *       - Si el pallet difiere en campos clave → advertencia detallada + confirmación.
 *   • Mover el pallet seleccionado al listado inferior (dgvDestibar).
 *   • Reestibar (dividir/clasificar) un pallet:
 *       - Reestiba parcial: crea nuevo pallet con las cajas sobrantes.
 *       - Reestiba completa: asigna el motivo al pallet original sin crear uno nuevo.
 *   • Mixtear: crea la estiba en DB; actualiza columnas Estiba/Mix en la grilla
 *     (NO limpia los pallets, el usuario puede seguir viendo el resultado).
 *   • Reconfigurar: limpia la lista con confirmación.
 *   • Totales dinámicos: cajas en estiba y capacidad máxima GTIN.
 *   • Coloreo automático: fila amarilla + celdas rojas donde hay diferencias de producto.
 *
 *   ── SECCIÓN INFERIOR (dgvDestibar) ────────────────────────────────────────────
 *   • Recibe pallets movidos desde dgvPallets con el botón "↓ Mover a desestibar".
 *   • Regresa pallets al dgvPallets con el botón "↑ Regresar a mixtear".
 *   • Desestiba SOLO los pallets que se encuentran en dgvDestibar (no por ID de estiba).
 *
 * RELACIONES:
 *   - ClsMixtearPallets → toda la lógica de negocio y acceso a datos.
 *   - FrmReestibaPallet → diálogo modal para configurar y ejecutar una reestiba.
 *   - EMixtearPallets   → modelos de datos (PalletInfo, TipoReestiba, ResultadoReestiba).
 *
 * ESCALABILIDAD:
 *   → Para menú contextual o doble clic en grids: agregar eventos en Designer.
 *   → Para filtros/exportación: extender con nuevos controles y métodos aquí.
 * ====================================================================================
 */

namespace SisUvex.Archivo.MixtearPallets
{
    public partial class FrmMixtearPallets : Form
    {
        /// <summary>Instancia de la clase de negocio.</summary>
        private readonly ClsMixtearPallets cls = new();

        /// <summary>
        /// Controla si se permite GUARDAR una estiba cuando las cajas totales superan
        /// el máximo por GTIN definido en el grid.
        ///   false → el guardado se BLOQUEA (comportamiento actual / recomendado).
        ///   true  → solo muestra advertencia pero permite guardar.
        /// Los pallets siempre se pueden seguir agregando al listado; la restricción
        /// aplica únicamente en el momento del guardado.
        /// ESCALABILIDAD: cambiar a true si se decide permitirlo en el futuro.
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
        ///   1. Formatear ID y verificar duplicado.
        ///   2. Consultar pallet en DB.
        ///   3. Si tiene estiba → ofrecer agregar estiba completa.
        ///   4. Validar cajas (¿supera máximo GTIN con el nuevo pallet?).
        ///   5. Validar diferencias de producto vs. pallets ya en lista.
        ///   6. Agregar al grid y actualizar totales/colores.
        /// IMPORTANTE: en cualquier rechazo (no encontrado, validación rechazada, etc.)
        /// se mantiene el texto del TextBox, se enfoca y se selecciona todo para corrección rápida.
        /// Solo se limpia el TextBox al agregar exitosamente.
        /// </summary>
        private void AgregarPalletPorTexto(string textoId)
        {
            if (string.IsNullOrEmpty(textoId))
            {
                MostrarAviso("Ingrese el número de pallet.", "Agregar Pallet");
                return;
            }

            string idPallet = cls.FormatoCeros(textoId, "00000");

            if (cls.ExistePalletEnGrid(dgvPallets, idPallet))
            {
                MostrarAviso($"El pallet {idPallet} ya está en la lista de mixteo.", "Agregar Pallet");
                FocarYSeleccionar(txbIdPallet);
                return;
            }

            // Si el pallet está en el listado de desestibar, regresarlo directamente
            // (sin validaciones adicionales, ya pasó por ellas antes de ser movido)
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

            // Si el pallet ya pertenece a una estiba, ofrecer agregar toda la estiba
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

            // ── Validación 1: ¿supera el máximo de cajas por GTIN? ─────────────────
            if (dgvPallets.Rows.Count > 0)
            {
                int maxGtin    = cls.ObtenerCajasPorPalletMinimo(dgvPallets);
                int totalNuevo = cls.SumarCajas(dgvPallets) + pallet.Cajas;

                if (maxGtin > 0 && totalNuevo > maxGtin)
                {
                    var resp = MessageBox.Show(
                        $"Al agregar el pallet {idPallet} ({pallet.Cajas} cjs.), el total en la lista " +
                        $"quedaría en {totalNuevo} cajas, superando el máximo del GTIN ({maxGtin} cjs.).\n\n" +
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

            // ── Validación 2: ¿el pallet difiere de los demás en campos de producto? ─
            List<string> diferencias = cls.ObtenerDiferenciasPallet(dgvPallets, pallet);
            if (diferencias.Count > 0)
            {
                var encabezados = diferencias
                    .Select(col => dgvPallets.Columns.Contains(col)
                        ? dgvPallets.Columns[col]!.HeaderText
                        : col)
                    .ToList();

                var resp = MessageBox.Show(
                    $"El pallet {idPallet} difiere del resto de los pallets en la lista en:\n" +
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

            // ── Agregar al grid ────────────────────────────────────────────────────
            cls.AgregarPalletAlGrid(dgvPallets, pallet);
            cls.SeleccionarUltimaFila(dgvPallets);
            ActualizarTotales();
            cls.AplicarColorAdvertencias(dgvPallets);
            LimpiarYFocar(txbIdPallet);
        }

        /// <summary>
        /// Consulta todos los pallets de una estiba y los agrega al dgvPallets (sin duplicados).
        /// </summary>
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
                MostrarAviso("Seleccione un pallet para moverlo al listado de desestibar.", "Mover Pallet");
                return;
            }
            cls.MoverPalletSeleccionadoAGrid(dgvPallets, dgvDestibar);
            ActualizarTotales();
            cls.AplicarColorAdvertencias(dgvPallets);
        }

        // ── Quitar pallet del formulario (ingresado por error) ───────────────────────

        /// <summary>
        /// Elimina el pallet seleccionado (o toda su estiba) del formulario completo.
        /// Sin estiba  → solo ese pallet del grid de mixteo.
        /// Con estiba  → todos los pallets de esa estiba de AMBOS grids.
        /// </summary>
        private void btnQuitarMix_Click(object sender, EventArgs e)
        {
            if (dgvPallets.SelectedRows.Count == 0)
            {
                MostrarAviso("Seleccione un pallet para quitar.", "Quitar");
                return;
            }
            cls.QuitarPalletDeAmbosGrids(dgvPallets, dgvDestibar, dgvPallets.SelectedRows[0]);
            ActualizarTotales();
            cls.AplicarColorAdvertencias(dgvPallets);
        }

        /// <summary>
        /// Elimina el pallet seleccionado (o toda su estiba) del formulario completo.
        /// Sin estiba  → solo ese pallet del listado de desestibar.
        /// Con estiba  → todos los pallets de esa estiba de AMBOS grids.
        /// </summary>
        private void btnQuitarDes_Click(object sender, EventArgs e)
        {
            if (dgvDestibar.SelectedRows.Count == 0)
            {
                MostrarAviso("Seleccione un pallet para quitar.", "Quitar");
                return;
            }
            cls.QuitarPalletDeAmbosGrids(dgvPallets, dgvDestibar, dgvDestibar.SelectedRows[0]);
            ActualizarTotales();
            cls.AplicarColorAdvertencias(dgvPallets);
        }

        // ── Reestibar pallet seleccionado ───────────────────────────────────────────

        private void btnReestibar_Click(object sender, EventArgs e)
        {
            PalletInfo? pallet = cls.ObtenerPalletSeleccionado(dgvPallets);
            if (pallet is null)
            {
                MostrarAviso("Seleccione un pallet en la lista para reestibar.", "Reestibar");
                return;
            }

            if (pallet.Cajas <= 1)
            {
                MostrarAviso(
                    $"El pallet {pallet.IdPallet} solo tiene {pallet.Cajas} caja(s).\n" +
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

            using FrmReestibaPallet dlg = new(pallet, tipos);
            if (dlg.ShowDialog(this) != DialogResult.OK) return;

            // ── Reestiba COMPLETA: asigna motivo al pallet original, sin crear uno nuevo ─
            if (dlg.EsReestibaCompleta)
            {
                ResultadoReestiba resultado = cls.EjecutarReestibaCompleta(
                    pallet.IdPallet, dlg.TipoSeleccionado);

                if (!resultado.Exito) return;

                // El pallet fue procesado → quitarlo del grid
                cls.QuitarPalletPorId(dgvPallets, pallet.IdPallet);
                ActualizarTotales();
                cls.AplicarColorAdvertencias(dgvPallets);
                MessageBox.Show(resultado.Mensaje, "Reestiba Completa",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // ── Reestiba PARCIAL: divide el pallet ──────────────────────────────────
            ResultadoReestiba resultadoParcial = cls.EjecutarReestiba(
                pallet.IdPallet, dlg.NuevasCajas, dlg.TipoSeleccionado);

            if (!resultadoParcial.Exito) return;

            // Actualizar cajas del pallet original en dgvPallets
            cls.ActualizarCajasEnGrid(dgvPallets, resultadoParcial.IdPalletOriginal,
                resultadoParcial.CajasOriginal);

            // El pallet sobrante siempre se envía al dgvDestibar (sin preguntar)
            if (!string.IsNullOrEmpty(resultadoParcial.IdPalletNuevo))
            {
                PalletInfo? sobrante = cls.ConsultarPallet(resultadoParcial.IdPalletNuevo);
                if (sobrante is not null)
                    cls.AgregarPalletAlGrid(dgvDestibar, sobrante);
            }

            ActualizarTotales();
            cls.AplicarColorAdvertencias(dgvPallets);

            // Aviso con mención de dónde quedó el sobrante
            string msgSobrante = !string.IsNullOrEmpty(resultadoParcial.IdPalletNuevo)
                ? $"\nEl pallet sobrante {resultadoParcial.IdPalletNuevo} " +
                  $"({resultadoParcial.CajasNuevo} cjs.) fue enviado al listado de desestibar."
                : string.Empty;

            MessageBox.Show(resultadoParcial.Mensaje + msgSobrante,
                "Reestiba Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    // Tiene estiba: ofrecer sacarlo de ella sin eliminar la fila del grid
                    var conf = MessageBox.Show(
                        $"Solo hay 1 pallet en la lista y ya pertenece a la estiba {estiba}.\n" +
                        $"¿Desea remover el pallet {idPallet} de esa estiba?",
                        "Desestibar Pallet",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (conf != DialogResult.Yes) return;

                    if (cls.EjecutarDesestibarPallet(idPallet))
                    {
                        // Limpiar columnas Estiba y Mix en la fila pero dejarla visible
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
                    // Sin estiba: no hay nada que mixear/desestibar → solo pitido
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

            // ── Validación de límite GTIN (controlada por PermitirSobrepasoMaxGtin) ──
            int cajasMaxGtin = cls.ObtenerCajasPorPalletMinimo(dgvPallets);
            if (cajasMaxGtin > 0 && totalCajas > cajasMaxGtin)
            {
                if (!PermitirSobrepasoMaxGtin)
                {
                    MessageBox.Show(
                        $"Las cajas totales ({totalCajas} cjs.) superan el máximo permitido " +
                        $"del GTIN ({cajasMaxGtin} cjs.).\n\n" +
                        "No se puede guardar la mixteada. Quite pallets hasta ajustar el total.",
                        "Cajas excedidas – Guardado bloqueado",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Si PermitirSobrepasoMaxGtin = true, la advertencia ya se mostró arriba
            }

            string nuevaEstiba = cls.EjecutarMixtear(dgvPallets);
            if (string.IsNullOrEmpty(nuevaEstiba))
            {
                txbIdPallet.Focus();
                return;
            }

            // ── Actualizar columnas en el grid sin limpiar las filas ────────────────
            // El usuario puede seguir viendo los pallets con su nueva estiba asignada.
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

        // ── Reconfigurar (limpiar lista superior) ───────────────────────────────────

        private void btnReconfigurar_Click(object sender, EventArgs e)
        {
            if (dgvPallets.Rows.Count > 0)
            {
                var confirmar = MessageBox.Show(
                    "¿Desea limpiar la lista de pallets a mixtear?",
                    "Reconfigurar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmar != DialogResult.Yes) return;
            }
            dgvPallets.Rows.Clear();
            txbIdPallet.Clear();
            ActualizarTotales();
            txbIdPallet.Focus();
        }

        private void dgvPallets_SelectionChanged(object sender, EventArgs e)
            => cls.AplicarColorAdvertencias(dgvPallets);

        // ============================================================================
        // SECCIÓN INFERIOR: PALLETS A DESESTIBAR
        // ============================================================================

        // ── Regresar pallet al listado superior (↑) ─────────────────────────────────

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

            // Mover: si hay selección solo esas filas, si no todas
            var filas = dgvDestibar.SelectedRows.Count > 0
                ? dgvDestibar.SelectedRows.Cast<DataGridViewRow>().ToList()
                : dgvDestibar.Rows.Cast<DataGridViewRow>().ToList();

            int regresados = 0;
            var filasARemover = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in filas)
            {
                string idPallet = row.Cells["Pallet"].Value?.ToString() ?? "";
                if (string.IsNullOrEmpty(idPallet)) continue;

                if (cls.ExistePalletEnGrid(dgvPallets, idPallet)) continue;

                // Copiar fila directamente (ya tiene todos los datos, sin re-consulta a DB)
                object[] vals = new object[row.Cells.Count];
                for (int i = 0; i < row.Cells.Count; i++)
                    vals[i] = row.Cells[i].Value!;

                dgvPallets.Rows.Add(vals);
                filasARemover.Add(row);
                regresados++;
            }

            foreach (var r in filasARemover)
                dgvDestibar.Rows.Remove(r);

            ActualizarTotales();
            cls.AplicarColorAdvertencias(dgvPallets);
            cls.SeleccionarUltimaFila(dgvPallets);
        }

        // ── Desestibar los pallets del listado inferior ──────────────────────────────

        private void button1_Click(object sender, EventArgs e) // btnDesestibar
        {
            if (dgvDestibar.Rows.Count == 0)
            {
                MostrarAviso(
                    "No hay pallets en el listado de desestibar.\n" +
                    "Mueva los pallets que desea desestibar usando '↓ Mover a desestibar'.",
                    "Desestibar");
                return;
            }

            // Solo desestibar los que tienen estiba asignada
            var conEstiba = dgvDestibar.Rows.Cast<DataGridViewRow>()
                .Where(r => !string.IsNullOrEmpty(r.Cells["Estiba"].Value?.ToString()))
                .ToList();

            if (conEstiba.Count == 0)
            {
                MostrarAviso(
                    "Los pallets en el listado no tienen estiba asignada.\n" +
                    "No hay nada que desestibar.",
                    "Desestibar");
                return;
            }

            var confirmar = MessageBox.Show(
                $"¿Confirma desestibar {conEstiba.Count} pallet(s) del listado?\n\n" +
                "Se removerá la asignación de estiba de cada uno.\n" +
                "Esta acción no se puede deshacer desde aquí.",
                "Confirmar Desestibar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmar != DialogResult.Yes) return;

            int exitosos = 0;
            foreach (DataGridViewRow row in conEstiba)
            {
                string idPallet = row.Cells["Pallet"].Value?.ToString() ?? "";
                if (!string.IsNullOrEmpty(idPallet) && cls.EjecutarDesestibarPallet(idPallet))
                {
                    // Limpiar solo las columnas de estiba/mix en la fila, sin eliminarla
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
        // UTILIDADES INTERNAS
        // ============================================================================

        private void ActualizarTotales()
        {
            int totalCajas   = cls.SumarCajas(dgvPallets);
            int cajasMaxGtin = cls.ObtenerCajasPorPalletMinimo(dgvPallets);

            txbBoxesStow.Text = totalCajas   > 0 ? totalCajas.ToString()   : string.Empty;
            txbBoxesMax.Text  = cajasMaxGtin > 0 ? cajasMaxGtin.ToString() : string.Empty;
        }

        /// <summary>
        /// Mueve un pallet específico de dgvDestibar a dgvPallets copiando la fila directamente.
        /// Solo se mueve ese pallet (aunque pertenezca a una estiba), sin consulta a DB
        /// y sin pasar por validaciones (ya las superó cuando fue agregado originalmente).
        /// </summary>
        private void RegresarPalletDesdeDestibar(string idPallet)
        {
            DataGridViewRow? fila = dgvDestibar.Rows.Cast<DataGridViewRow>()
                .FirstOrDefault(r => r.Cells["Pallet"].Value?.ToString() == idPallet);

            if (fila is null) return;

            object[] vals = new object[fila.Cells.Count];
            for (int i = 0; i < fila.Cells.Count; i++)
                vals[i] = fila.Cells[i].Value!;

            dgvPallets.Rows.Add(vals);
            dgvDestibar.Rows.Remove(fila);

            cls.SeleccionarUltimaFila(dgvPallets);
            ActualizarTotales();
            cls.AplicarColorAdvertencias(dgvPallets);
        }

        private static void LimpiarYFocar(TextBox txb)
        {
            txb.Clear();
            txb.Focus();
        }

        /// <summary>
        /// Enfoca el TextBox y selecciona todo el texto sin borrarlo.
        /// Usado cuando se rechaza agregar un pallet para permitir corrección rápida del ID.
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
