using SisUvex.Archivo.Etiquetas.PrintLabels;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Catalogos.Metods.TextBoxes;
using SisUvex.Catalogos.Metods.Values;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;
using static SisUvex.Catalogos.Metods.ClsObject;

namespace SisUvex.Archivo.WorkPlan.ChangeDistributorPallet
{
    internal class ClsChangeDistributorPallet
    {
        SQLControl sql = new SQLControl();
        public FrmChangeDistributorPallet frm;
        DataTable? dtPalletList = null;
        bool palletGridConditionalFormatApplied;

        const string queryPallet = Pallet.QuerySelectBaseWithStowage;

        // Estado de la última ejecución de BtnAccept
        Dictionary<string, DataRow> _gtinData = new();
        Dictionary<string, DataRow?> _newGtinByOriginal = new();
        HashSet<string> _updatedPalletIds = new();

        // ─────────────────────────────────────────────────────────────────────
        // Inicialización
        // ─────────────────────────────────────────────────────────────────────

        public void BeginForm()
        {
            ClsComboBoxes.CboLoadActives(frm.cboSeason, Season.CboWithDates);
            ClsComboBoxes.CboLoadActives(frm.cboDistribuidor, ClsObject.Distributor.Cbo);

            ClsTextBoxes.TxbApplyKeyPressEventInt(frm.txbIdPallet);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(frm.cboSeason, "08");

            InitPalletDataGridSchema();
        }

        // ─────────────────────────────────────────────────────────────────────
        // Agregar / quitar pallets
        // ─────────────────────────────────────────────────────────────────────

        public void BtnAddPallet(string idPal)
        {
            if (string.IsNullOrWhiteSpace(idPal)) return;

            string idPallet = ClsValues.FormatZeros(idPal, "00000");

            if (PalletAlreadyInGrid(idPallet))
            {
                SystemSounds.Exclamation.Play();
                return;
            }

            DataTable dtPallet = ClsQuerysDB.GetDataTable(queryPallet + $" WHERE vw.Pallet = '{idPallet}' ");

            if (dtPallet.Rows.Count < 1)
            {
                SystemSounds.Exclamation.Play();
                return;
            }

            string estiba = dtPallet.Rows[0]["Estiba"]?.ToString() ?? "";

            if (!string.IsNullOrWhiteSpace(estiba))
            {
                // Agregar todos los pallets de la misma estiba
                DataTable dtEstiba = ClsQuerysDB.GetDataTable(
                    queryPallet + $" WHERE vw.Estiba = '{estiba.Replace("'", "''")}' ");

                foreach (DataRow row in dtEstiba.Rows)
                {
                    string pid = row["Pallet"]?.ToString() ?? "";
                    if (string.IsNullOrEmpty(pid) || PalletAlreadyInGrid(pid)) continue;

                    DataRow newRow = dtPalletList!.NewRow();
                    newRow.ItemArray = row.ItemArray;
                    dtPalletList.Rows.InsertAt(newRow, 0);
                }
            }
            else
            {
                DataRow newRow = dtPalletList!.NewRow();
                newRow.ItemArray = dtPallet.Rows[0].ItemArray;
                dtPalletList.Rows.InsertAt(newRow, 0);
            }

            frm.txbIdPallet.Focus();
            frm.txbIdPallet.SelectAll();
        }

        public void BtnQuitPallet()
        {
            if (frm.dgvPallet.SelectedRows.Count > 0)
                dtPalletList!.Rows.RemoveAt(frm.dgvPallet.SelectedRows[0].Index);
        }

        /// <summary>
        /// Procesa texto pegado desde el portapapeles que puede contener múltiples IDs
        /// separados por saltos de línea, tabulaciones o comas (ej. copiado de Excel).
        /// Solo se procesan los tokens que sean puramente numéricos.
        /// </summary>
        public void PasteMultiplePallets(string rawText)
        {
            if (string.IsNullOrWhiteSpace(rawText)) return;

            string[] tokens = rawText.Split(
                new[] { '\n', '\r', '\t', ',', ';' },
                StringSplitOptions.RemoveEmptyEntries);

            foreach (string token in tokens)
            {
                string trimmed = token.Trim();
                if (trimmed.Length == 0) continue;

                // Solo enteros
                if (!trimmed.All(char.IsDigit)) continue;

                BtnAddPallet(trimmed);
            }

            frm.txbIdPallet.Clear();
            frm.txbIdPallet.Focus();
        }

        public void BtnLimpiar()
        {
            _updatedPalletIds.Clear();
            _gtinData.Clear();
            _newGtinByOriginal.Clear();
            InitPalletDataGridSchema();
        }

        // ─────────────────────────────────────────────────────────────────────
        // Imprimir
        // ─────────────────────────────────────────────────────────────────────

        public void BtnImprimir()
        {
            if (frm.dgvPallet.SelectedRows.Count == 0)
            {
                SystemSounds.Exclamation.Play();
                return;
            }

            string raw = frm.dgvPallet.SelectedRows[0].Cells["Pallet"].Value?.ToString() ?? "";
            if (string.IsNullOrWhiteSpace(raw)) return;

            string idPallet = ClsValues.FormatZeros(raw, "00000");
            int copias = Math.Max(1, Convert.ToInt32(frm.nudCopiasEtiqueta.Value));
            bool invertir = frm.chkInvertirEtiqueta.Checked;

            ClsReprintPallet.ReprintPalletTag(idPallet, copias, invertir, showDate: true);
        }

        // ─────────────────────────────────────────────────────────────────────
        // Aceptar – flujo completo de cambio de distribuidor
        // ─────────────────────────────────────────────────────────────────────

        public void BtnAccept()
        {
            if (frm.dgvPallet.Rows.Count == 0)
            {
                SystemSounds.Exclamation.Play();
                return;
            }

            if (frm.cboDistribuidor.SelectedIndex < 1)
            {
                MessageBox.Show("Seleccione un distribuidor nuevo.", "Cambiar distribuidor",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                frm.cboDistribuidor.Focus();
                return;
            }

            string idNewDistributor = frm.cboDistribuidor.SelectedValue?.ToString() ?? "";
            if (string.IsNullOrEmpty(idNewDistributor)) return;

            // ── 1. Recolectar IDs de pallet del grid ────────────────────────
            List<string> palletIds = GetPalletIdsFromGrid();

            // ── 2. Consultar id_workPlan e id_GTIN por pallet ───────────────
            DataTable dtPalletInfo = GetPalletWorkPlanInfo(palletIds);

            // ── 3. GTINs únicos y sus datos en Pack_GTIN ────────────────────
            List<string> uniqueGtins = dtPalletInfo.AsEnumerable()
                .Select(r => r["id_GTIN"]?.ToString() ?? "")
                .Where(g => !string.IsNullOrEmpty(g))
                .Distinct()
                .ToList();

            _gtinData = LoadGtinData(uniqueGtins);

            // ── 4. Buscar GTIN equivalente con el nuevo distribuidor ─────────
            _newGtinByOriginal = new Dictionary<string, DataRow?>();
            foreach (string gtinId in uniqueGtins)
            {
                if (!_gtinData.TryGetValue(gtinId, out DataRow? originalGtin))
                {
                    _newGtinByOriginal[gtinId] = null;
                    continue;
                }
                _newGtinByOriginal[gtinId] = FindNewGtinForDistributor(originalGtin, idNewDistributor);
            }

            // ── 5. Validar que TODOS los pallets tengan GTIN equivalente ────
            Dictionary<string, string> palletGtinMap = BuildPalletGtinMap(dtPalletInfo);

            List<string> palletsWithoutGtin = palletIds
                .Where(p => palletGtinMap.TryGetValue(p, out string? g)
                            && _newGtinByOriginal.TryGetValue(g, out DataRow? ng)
                            && ng == null)
                .ToList();

            if (palletsWithoutGtin.Count > 0)
            {
                // Agrupar pallets por su GTIN original para un mensaje compacto
                var byGtin = palletsWithoutGtin
                    .GroupBy(p => palletGtinMap.GetValueOrDefault(p, "?"))
                    .OrderBy(g => g.Key);

                StringBuilder msg = new();
                msg.AppendLine("Los siguientes pallets no tienen un GTIN válido para el distribuidor seleccionado:");
                msg.AppendLine();
                foreach (var grp in byGtin)
                {
                    msg.AppendLine($"GTIN: {grp.Key}");
                    msg.AppendLine($"Pallets: {string.Join(", ", grp)}");
                    msg.AppendLine();
                }
                msg.AppendLine("Debe ser igual en:");
                msg.Append("Variedad, Presentación, Contenedor, Libras, Cajas por pallet, Precio, Pre y Post Etiqueta, UPC.");

                MessageBox.Show(msg.ToString(), "GTIN no encontrado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // TODO (futuro): permitir continuar solo con los pallets que sí tienen GTIN equivalente
                return;
            }

            // ── 6. WorkPlans únicos y sus datos en Pack_WorkPlan ────────────
            List<string> uniqueWorkPlans = dtPalletInfo.AsEnumerable()
                .Select(r => r["id_workPlan"]?.ToString() ?? "")
                .Where(w => !string.IsNullOrEmpty(w))
                .Distinct()
                .ToList();

            Dictionary<string, DataRow> workPlanData = LoadWorkPlanData(uniqueWorkPlans);

            // ── 7. Verificar si ya existen WorkPlans para el nuevo GTIN ─────
            Dictionary<string, string> newWorkPlanByOriginal = new();
            List<(string OriginalWpId, string NewGtinId, DataRow WpRow)> workPlansToCreate = new();

            foreach (string wpId in uniqueWorkPlans)
            {
                if (!workPlanData.TryGetValue(wpId, out DataRow? wpRow)) continue;

                string originalGtinId = wpRow["id_GTIN"]?.ToString() ?? "";
                if (!_newGtinByOriginal.TryGetValue(originalGtinId, out DataRow? newGtinRow) || newGtinRow == null)
                    continue;

                string newGtinId = newGtinRow["id_GTIN"]?.ToString() ?? "";
                string? existingWpId = FindExistingWorkPlan(wpRow, newGtinId);

                if (!string.IsNullOrEmpty(existingWpId))
                    newWorkPlanByOriginal[wpId] = existingWpId;
                else
                    workPlansToCreate.Add((wpId, newGtinId, wpRow));
            }

            // ── 8. Preguntar al usuario si desea crear los WorkPlans faltantes
            if (workPlansToCreate.Count > 0)
            {
                IEnumerable<string> wpLines = workPlansToCreate.Select(x =>
                    $"  • Plan {x.OriginalWpId}  →  nuevo GTIN: {x.NewGtinId}");

                DialogResult createResult = MessageBox.Show(
                    "Se necesitan crear los siguientes planes de trabajo para el nuevo distribuidor:\n\n"
                    + string.Join("\n", wpLines)
                    + "\n\n¿Desea crearlos ahora?",
                    "Crear planes de trabajo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (createResult == DialogResult.Yes)
                {
                    foreach (var (originalWpId, newGtinId, wpRow) in workPlansToCreate)
                    {
                        string? newWpId = CreateWorkPlan(wpRow, newGtinId);
                        if (!string.IsNullOrEmpty(newWpId))
                        {
                            newWorkPlanByOriginal[originalWpId] = newWpId;
                        }
                        else
                        {
                            MessageBox.Show(
                                $"No se pudo crear el plan de trabajo para el plan {originalWpId}.\nSe cancela el proceso.",
                                "Error al crear plan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
                else
                {
                    // TODO (futuro): continuar solo con los pallets cuyos WorkPlans ya existen
                    return;
                }
            }

            // ── 9. Confirmación final ────────────────────────────────────────
            DialogResult confirm = MessageBox.Show(
                $"¿Confirma cambiar el distribuidor a '{frm.cboDistribuidor.Text}' para {palletIds.Count} pallet(s)?",
                "Confirmar cambio de distribuidor",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            // ── 10. Construir mapa pallet → nuevo WorkPlan ───────────────────
            Dictionary<string, string> palletNewWpMap = BuildPalletNewWpMap(dtPalletInfo, newWorkPlanByOriginal);

            // ── 11. Actualizar pallets en transacción ────────────────────────
            if (UpdatePalletsWorkPlan(palletNewWpMap))
            {
                _updatedPalletIds = new HashSet<string>(palletNewWpMap.Keys);
                RefreshPalletsInDataGridFromDatabase();
                HighlightUpdatedPallets();
                MessageBox.Show(
                    $"Se cambió el distribuidor correctamente a {palletIds.Count} pallet(s).",
                    "Cambio de distribuidor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ─────────────────────────────────────────────────────────────────────
        // Helpers – consultas
        // ─────────────────────────────────────────────────────────────────────

        List<string> GetPalletIdsFromGrid() =>
            frm.dgvPallet.Rows.Cast<DataGridViewRow>()
                .Select(r => r.Cells["Pallet"].Value?.ToString() ?? "")
                .Where(p => !string.IsNullOrEmpty(p))
                .ToList();

        bool PalletAlreadyInGrid(string idPallet) =>
            frm.dgvPallet.Rows.Cast<DataGridViewRow>()
                .Any(r => r.Cells["Pallet"].Value?.ToString() == idPallet);

        DataTable GetPalletWorkPlanInfo(List<string> palletIds)
        {
            string ids = string.Join("','", palletIds.Select(p => p.Replace("'", "''")));
            return ClsQuerysDB.GetDataTable(
                $@"SELECT PAL.id_pallet, PAL.id_workPlan, WPL.id_GTIN
                   FROM Pack_Pallet PAL
                   LEFT JOIN Pack_WorkPlan WPL ON WPL.id_workPlan = PAL.id_workPlan
                   WHERE PAL.id_pallet IN ('{ids}')");
        }

        Dictionary<string, string> BuildPalletGtinMap(DataTable dtPalletInfo)
        {
            var map = new Dictionary<string, string>();
            foreach (DataRow row in dtPalletInfo.Rows)
            {
                string palletId = row["id_pallet"]?.ToString() ?? "";
                string gtinId   = row["id_GTIN"]?.ToString() ?? "";
                if (!string.IsNullOrEmpty(palletId) && !string.IsNullOrEmpty(gtinId))
                    map[palletId] = gtinId;
            }
            return map;
        }

        Dictionary<string, DataRow> LoadGtinData(List<string> gtinIds)
        {
            var result = new Dictionary<string, DataRow>();
            if (gtinIds.Count == 0) return result;

            string ids = string.Join("','", gtinIds.Select(g => g.Replace("'", "''")));
            DataTable dt = ClsQuerysDB.GetDataTable($"SELECT * FROM Pack_GTIN WHERE id_GTIN IN ('{ids}')");

            foreach (DataRow row in dt.Rows)
            {
                string id = row["id_GTIN"]?.ToString() ?? "";
                if (!string.IsNullOrEmpty(id)) result[id] = row;
            }
            return result;
        }

        Dictionary<string, DataRow> LoadWorkPlanData(List<string> workPlanIds)
        {
            var result = new Dictionary<string, DataRow>();
            foreach (string wpId in workPlanIds)
            {
                DataTable dt = ClsQuerysDB.GetDataTable(
                    $"SELECT * FROM Pack_WorkPlan WHERE id_workPlan = '{wpId.Replace("'", "''")}'");
                if (dt.Rows.Count > 0)
                    result[wpId] = dt.Rows[0];
            }
            return result;
        }

        DataRow? FindNewGtinForDistributor(DataRow originalGtin, string idNewDistributor)
        {
            StringBuilder sb = new();
            sb.Append($"SELECT * FROM Pack_GTIN WHERE id_distributor = '{idNewDistributor.Replace("'", "''")}'");
            sb.Append($" AND {NullSafeCondition("id_variety",     originalGtin["id_variety"])}");
            sb.Append($" AND {NullSafeCondition("id_presentation",originalGtin["id_presentation"])}");
            sb.Append($" AND {NullSafeCondition("id_container",   originalGtin["id_container"])}");
            sb.Append($" AND {NullSafeCondition("n_lbs",          originalGtin["n_lbs"],          isNumeric: true)}");
            sb.Append($" AND {NullSafeCondition("i_palletBoxes",  originalGtin["i_palletBoxes"],  isNumeric: true)}");
            sb.Append($" AND {NullSafeCondition("v_preLabel",     originalGtin["v_preLabel"])}");
            sb.Append($" AND {NullSafeCondition("v_postLabel",    originalGtin["v_postLabel"])}");
            sb.Append($" AND {NullSafeCondition("id_price",       originalGtin["id_price"])}");
            sb.Append($" AND {NullSafeCondition("id_pti",         originalGtin["id_pti"])}");
            sb.Append($" AND {NullSafeCondition("v_UPC",          originalGtin["v_UPC"])}");

            DataTable dt = ClsQuerysDB.GetDataTable(sb.ToString());
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        /// <summary>Busca un WorkPlan existente con el nuevo GTIN y las mismas columnas llave del original.</summary>
        string? FindExistingWorkPlan(DataRow wpRow, string newGtinId)
        {
            string workDay = SafeDateString(wpRow["d_workDay"]);
            if (string.IsNullOrEmpty(workDay)) return null;

            StringBuilder sb = new();
            sb.Append("SELECT id_workPlan FROM Pack_WorkPlan WHERE 1=1");
            sb.Append($" AND {NullSafeCondition("id_lot",       wpRow["id_lot"])}");
            sb.Append($" AND {NullSafeCondition("id_workGroup", wpRow["id_workGroup"])}");
            sb.Append($" AND CAST(d_workDay AS date) = '{workDay}'");
            sb.Append($" AND {NullSafeCondition("id_size",      wpRow["id_size"])}");
            sb.Append($" AND id_GTIN = '{newGtinId.Replace("'", "''")}'");
            sb.Append($" AND {NullSafeCondition("id_typeBox",    wpRow["id_typeBox"])}");
            sb.Append($" AND {NullSafeCondition("id_labelLegend",wpRow["id_labelLegend"])}");

            string result = ClsQuerysDB.GetData(sb.ToString());
            return string.IsNullOrEmpty(result) ? null : result;
        }

        /// <summary>
        /// Crea un nuevo WorkPlan usando los datos del original con el nuevo GTIN.
        /// Usa <see cref="EworkPlan.AddProcedure"/> para que el SP maneje la generación del ID
        /// y cualquier lógica adicional, garantizando compatibilidad ante futuros cambios en la tabla.
        /// </summary>
        string? CreateWorkPlan(DataRow wpRow, string newGtinId)
        {
            EworkPlan e = new();
            e.IdLot          = wpRow["id_lot"]?.ToString() ?? "";
            e.IdWorkGroup    = wpRow["id_workGroup"]?.ToString() ?? "";
            e.VPC            = IsDbNull(wpRow["c_voicePickCode"]) ? "" : wpRow["c_voicePickCode"]!.ToString()!;
            e.WorkDay        = Convert.ToDateTime(wpRow["d_workDay"]);
            e.Size           = wpRow["id_size"]?.ToString() ?? "";
            e.Active         = 1;
            e.IdGtin         = newGtinId;
            e.IdTypeBox      = IsDbNull(wpRow["id_typeBox"])    ? "" : wpRow["id_typeBox"]!.ToString()!;
            e.IdLabelLegend  = IsDbNull(wpRow["id_labelLegend"])? null : wpRow["id_labelLegend"]!.ToString();

            var result = e.AddProcedure();
            return result.success ? result.id : null;
        }

        Dictionary<string, string> BuildPalletNewWpMap(
            DataTable dtPalletInfo,
            Dictionary<string, string> newWorkPlanByOriginal)
        {
            var map = new Dictionary<string, string>();
            foreach (DataRow row in dtPalletInfo.Rows)
            {
                string palletId    = row["id_pallet"]?.ToString() ?? "";
                string originalWpId = row["id_workPlan"]?.ToString() ?? "";
                if (string.IsNullOrEmpty(palletId) || string.IsNullOrEmpty(originalWpId)) continue;
                if (newWorkPlanByOriginal.TryGetValue(originalWpId, out string? newWpId) && !string.IsNullOrEmpty(newWpId))
                    map[palletId] = newWpId;
            }
            return map;
        }

        bool UpdatePalletsWorkPlan(Dictionary<string, string> palletNewWpMap)
        {
            try
            {
                string user = User.GetUserName();
                sql.BeginTransaction();

                foreach (KeyValuePair<string, string> kvp in palletNewWpMap)
                {
                    SqlCommand cmd = new(
                        "UPDATE Pack_Pallet SET id_workPlan = @idNewWorkPlan, userUpdate = @user, d_update = GETDATE() WHERE id_pallet = @idPallet",
                        sql.cnn, sql.transaction);
                    cmd.Parameters.AddWithValue("@idNewWorkPlan", kvp.Value);
                    cmd.Parameters.AddWithValue("@user",          user);
                    cmd.Parameters.AddWithValue("@idPallet",      kvp.Key);
                    cmd.ExecuteNonQuery();
                }

                sql.CommitTransaction();
                return true;
            }
            catch (Exception ex)
            {
                sql.RollbackTransaction();
                MessageBox.Show(ex.ToString(), "Error al actualizar pallets");
                return false;
            }
        }

        // ─────────────────────────────────────────────────────────────────────
        // Grid – presentación
        // ─────────────────────────────────────────────────────────────────────

        void RefreshPalletsInDataGridFromDatabase()
        {
            if (dtPalletList == null || !dtPalletList.Columns.Contains("Pallet")) return;

            List<string> palletIds = dtPalletList.AsEnumerable()
                .Select(r => ClsValues.FormatZeros(r["Pallet"]?.ToString() ?? "", "00000"))
                .Where(id => !string.IsNullOrWhiteSpace(id))
                .ToList();

            if (palletIds.Count == 0) return;

            dtPalletList.Rows.Clear();

            foreach (string palletId in palletIds)
            {
                string safeId = palletId.Replace("'", "''");
                DataTable dtOne = ClsQuerysDB.GetDataTable($"{queryPallet.Trim()} WHERE vw.Pallet = '{safeId}'");
                if (dtOne.Rows.Count == 0) continue;
                DataRow nueva = dtPalletList.NewRow();
                nueva.ItemArray = dtOne.Rows[0].ItemArray;
                dtPalletList.Rows.Add(nueva);
            }

            ApplyPalletGridPresentation();
        }

        void HighlightUpdatedPallets()
        {
            if (_updatedPalletIds.Count == 0) return;

            foreach (DataGridViewRow row in frm.dgvPallet.Rows)
            {
                string palletId = row.Cells["Pallet"].Value?.ToString() ?? "";
                if (_updatedPalletIds.Contains(palletId))
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
            }
        }

        void InitPalletDataGridSchema()
        {
            dtPalletList = ClsQuerysDB.GetDataTable($"{queryPallet.Trim()} WHERE 1 = 0");
            frm.dgvPallet.DataSource = dtPalletList;
            ApplyPalletGridPresentation();
        }

        void EnsurePalletGridConditionalFormat()
        {
            if (palletGridConditionalFormatApplied) return;
            if (!frm.dgvPallet.Columns.Contains(Pallet.ColumnActive)) return;
            palletGridConditionalFormatApplied = true;
        }

        void ApplyPalletGridPresentation()
        {
            Pallet.HideJoinedIdColumns(frm.dgvPallet);
            EnsurePalletGridConditionalFormat();
        }

        // ─────────────────────────────────────────────────────────────────────
        // Utilidades estáticas
        // ─────────────────────────────────────────────────────────────────────

        /// <summary>
        /// Genera una condición SQL null-safe para un campo.
        /// Si el valor es nulo/DBNull/vacío devuelve <c>column IS NULL</c>;
        /// de lo contrario devuelve <c>column = 'value'</c> (o sin comillas si <paramref name="isNumeric"/>).
        /// </summary>
        static string NullSafeCondition(string column, object? value, bool isNumeric = false)
        {
            if (IsDbNull(value) || string.IsNullOrEmpty(value?.ToString()))
                return $"{column} IS NULL";

            if (isNumeric)
            {
                // Formato invariante para evitar problemas de separador decimal por cultura
                if (decimal.TryParse(value.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal num))
                    return $"{column} = {num.ToString(CultureInfo.InvariantCulture)}";
                // Fallback: usar el valor tal cual sin comillas
                return $"{column} = {value.ToString()!.Replace("'", "''")}";
            }

            return $"{column} = '{value.ToString()!.Replace("'", "''")}'";
        }

        static bool IsDbNull(object? value) => value == null || value is DBNull;

        static string SafeDateString(object? value)
        {
            if (IsDbNull(value)) return string.Empty;
            if (DateTime.TryParse(value!.ToString(), out DateTime dt))
                return dt.ToString("yyyy-MM-dd");
            return string.Empty;
        }
    }
}
