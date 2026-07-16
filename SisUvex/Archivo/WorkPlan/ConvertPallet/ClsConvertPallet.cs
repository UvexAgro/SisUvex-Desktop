using Microsoft.IdentityModel.Tokens;
using SisUvex.Archivo.Etiquetas.PrintLabels;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.DataGridViews;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Catalogos.Metods.TextBoxes;
using SisUvex.Catalogos.Metods.Values;
using SisUvex.Nomina.Conceptos_Ingresos_Diversos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Media;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SisUvex.Catalogos.Metods.ClsObject;

namespace SisUvex.Archivo.WorkPlan.ConvertPallet
{
    internal class ClsConvertPallet
    {
        SQLControl sql = new SQLControl();
        public FrmConvertPallet frm;
        DataTable? dtCboWorkPlan = null;
        DataTable? dtPalletList = null;
        bool palletGridConditionalFormatApplied;
        /// <summary>Coincide con el ValueMember del combo Lote (id_lote|id_variedad).</summary>
        const string ColumnLotCboKey = "lotCboKey";
        const string dateQuery = " REPLACE(FORMAT(wpl.d_workDay, 'MMM-dd', 'es-ES'), '.', '') ";
        /// <summary>Consulta base de planes; el rango por temporada se agrega en <see cref="BuildWorkPlanQuery"/>.</summary>
        const string queryCboWorkPlanBase = $" SELECT [Activo], [Código], CONCAT_WS(' ', Código, '|', {dateQuery},'|', Cuadrilla, '|', dis.v_nameDistShort, Lote, Variedad, Tamaño, CONCAT(Contenedor, CAST(Libras AS float)),[Pre etiqueta], Presentación, [Post etiqueta]) AS [Nombre], Fecha AS [Fecha], gtn.id_distributor AS [{ClsObject.Distributor.ColumnId}], wpl.id_lot AS [{ClsObject.Lot.ColumnId}],gtn.id_variety AS [{ClsObject.Variety.ColumnId}], gtn.id_presentation AS [{ClsObject.Presentation.ColumnId}], gtn.id_container  AS [{ClsObject.Container.ColumnId}], wpl.id_workGroup AS [{ClsObject.WorkGroup.ColumnId}], CONCAT(wpl.id_lot, '|', gtn.id_variety) AS [{ColumnLotCboKey}] FROM vw_PackWorkPlanCat cat JOIN Pack_WorkPlan wpl ON wpl.id_workPlan = cat.Código  JOIN Pack_GTIN gtn ON gtn.id_GTIN = cat.GTIN join Pack_Distributor dis ON dis.id_distributor = gtn.id_distributor WHERE [Activo] = '1' ";
        const string queryPallet = Pallet.QuerySelectBaseWithStowage;

        /// <summary>
        /// Columnas (IDs) que NO se permiten cambiar al convertir pallets en manifiesto.
        /// Para agregar/quitar reglas, modificar esta lista.
        /// </summary>
        static readonly List<(string Label, string ColumnId)> validateInManifest =
        [
            ("Distribuidor", Distributor.ColumnId),
            ("Presentación", Presentation.ColumnId),
            ("Contenedor", Container.ColumnId),
            ("Variedad", Variety.ColumnId),
        ];

        public ClsConvertPallet()
        {
            frm = new FrmConvertPallet();
            frm.cls = this;
        }
        public void BeginForm()
        {
            ClsComboBoxes.CboLoadActives(frm.cboSeason, Season.CboWithDates);
            ClsComboBoxes.CboLoadActives(frm.cboDistribuidor, ClsObject.Distributor.Cbo);
            ClsComboBoxes.CboLoadActives(frm.cboPresentacion, Presentation.Cbo);
            ClsComboBoxes.CboLoadActives(frm.cboVariety, Variety.Cbo);
            ClsComboBoxes.CboLoadActives(frm.cboContainer, Container.Cbo);
            ClsComboBoxes.CboLoadActives(frm.cboWorkGroup, WorkGroup.Cbo);
            ClsComboBoxes.CboLoadActives(frm.cboWorkGroupDuplicate, WorkGroup.Cbo);
            ClsComboBoxes.CboLoadActives(frm.cboLot, Lot.Cbo);

            List<(ComboBox Cbo, string IdColumnFilter)> lsWGDep = new();
            lsWGDep.Add((frm.cboSeason, Season.ColumnId));
            ClsComboBoxes.Events.CboApplyEventFilterAllForOne(frm.cboWorkGroup, null, lsWGDep);

            ClsComboBoxes.Events.CboApplyEventFilterAllForOne(frm.cboWorkGroupDuplicate, null, lsWGDep); //<-- cboWorkGroup de duplicar 

            List<(ComboBox Cbo, string IdColumnFilter)> lsLotDep = new();
            lsLotDep.Add((frm.cboVariety, Variety.ColumnId));
            ClsComboBoxes.Events.CboApplyEventFilterAllForOne(frm.cboLot, null, lsLotDep);

            ClsTextBoxes.TxbApplyKeyPressEventInt(frm.txbIdPallet);

            ClsComboBoxes.CboSelectIndexWithTextInValueMember(frm.cboSeason, "08"); // Temporada por defecto

            ReloadWorkPlanDataFromDatabase(); // primera carga según temporada (rango d_seasonBegins / d_seasonEnds)

            frm.cboSeason.SelectedValueChanged += CboSeason_WorkPlanReload;

            AttachWorkPlanDependentFiltersHandlers();

            frm.cboWorkGroupDuplicate.SelectedIndexChanged += (s, e) => MetodcboWorkGroupDuplicateSelectedIndexChanged();

            InitPalletDataGridSchema();
        }

        /// <summary>Carga el esquema del grid sin filas (WHERE 1=0) para tener columnas desde el inicio y poder aplicar formato.</summary>
        void InitPalletDataGridSchema()
        {
            dtPalletList = ClsQuerysDB.GetDataTable($"{queryPallet.Trim()} WHERE 1 = 0");
            frm.dgvPallet.DataSource = dtPalletList;
            ApplyPalletGridPresentation();
        }

        void EnsurePalletGridConditionalFormat()
        {
            if (palletGridConditionalFormatApplied)
                return;
            if (!frm.dgvPallet.Columns.Contains(Pallet.ColumnActive))
                return;

            ClsDGVCatalog.DgvApplyConditionalRowFormat(
                frm.dgvPallet,
                Pallet.ColumnActive,
                "0",
                ClsDGVCatalog.CellFormat.soft_inactive);
            palletGridConditionalFormatApplied = true;
        }

        void ApplyPalletGridPresentation()
        {
            Pallet.HideJoinedIdColumns(frm.dgvPallet);
            EnsurePalletGridConditionalFormat();
        }

        bool TryGetSelectedSeasonDateRange(out DateTime start, out DateTime end)
        {
            start = default;
            end = default;

            if (frm.cboSeason.SelectedIndex < 1)
                return false;

            if (frm.cboSeason.SelectedItem is not DataRowView drv)
                return false;

            DataTable tbl = drv.Row.Table;
            if (!tbl.Columns.Contains(Season.ColumnStartDate) || !tbl.Columns.Contains(Season.ColumnEndDate))
                return false;

            if (drv.Row[Season.ColumnStartDate] is DBNull || drv.Row[Season.ColumnEndDate] is DBNull)
                return false;

            start = Convert.ToDateTime(drv.Row[Season.ColumnStartDate]).Date;
            end = Convert.ToDateTime(drv.Row[Season.ColumnEndDate]).Date;
            return true;
        }

        string BuildWorkPlanQuery()
        {
            string q = queryCboWorkPlanBase;
            if (TryGetSelectedSeasonDateRange(out DateTime desde, out DateTime hasta))
                q += $" AND CAST([Fecha] AS date) >= '{desde:yyyy-MM-dd}' AND CAST([Fecha] AS date) <= '{hasta:yyyy-MM-dd}' ";
            return q;
        }

        void ReloadWorkPlanDataFromDatabase()
        {
            dtCboWorkPlan = ClsQuerysDB.GetDataTable(BuildWorkPlanQuery());
            ClsComboBoxes.LoadComboBoxDataSource(frm.cboWorkPlan, dtCboWorkPlan);
            ApplyWorkPlanRowFilter();
        }

        void CboSeason_WorkPlanReload(object? sender, EventArgs e) =>
            ReloadWorkPlanDataFromDatabase(); // LoadComboBoxDataSource deja plan de trabajo en ---Seleccionar---

        /// <summary>Si el plan no está en <see cref="dtCboWorkPlan"/> (p. ej. fuera del rango de temporada), lo consulta y lo agrega sin cambiar <c>cboSeason</c>.</summary>
        void EnsureWorkPlanLoaded(string planId)
        {
            if (dtCboWorkPlan == null || string.IsNullOrWhiteSpace(planId))
                return;

            bool exists = dtCboWorkPlan.Rows.Cast<DataRow>().Any(r =>
                r.Table.Columns.Contains(Column.id) &&
                string.Equals(r[Column.id]?.ToString(), planId, StringComparison.OrdinalIgnoreCase));

            if (exists)
                return;

            string safePlan = EscapeRowFilterValue(planId);
            DataTable dtOne = ClsQuerysDB.GetDataTable($"{queryCboWorkPlanBase} AND [Código] = '{safePlan}' ");
            if (dtOne.Rows.Count == 0)
                return;

            DataRow newRow = dtCboWorkPlan.NewRow();
            foreach (DataColumn col in dtOne.Columns)
            {
                if (dtCboWorkPlan.Columns.Contains(col.ColumnName))
                    newRow[col.ColumnName] = dtOne.Rows[0][col.ColumnName];
            }
            dtCboWorkPlan.Rows.Add(newRow);
        }

        string GetWorkPlanNameOrFallback(string planId)
        {
            if (dtCboWorkPlan == null || string.IsNullOrEmpty(planId))
                return planId;

            DataRow? row = dtCboWorkPlan.Rows.Cast<DataRow>()
                .FirstOrDefault(r =>
                    r.Table.Columns.Contains(Column.id) &&
                    string.Equals(r[Column.id]?.ToString(), planId, StringComparison.OrdinalIgnoreCase));

            if (row == null)
                return planId;

            if (!row.Table.Columns.Contains(Column.name))
                return planId;

            return row[Column.name]?.ToString() ?? planId;
        }

        /// <summary>Filtro local sobre dtCboWorkPlan al cambiar distribuidor, presentación, variedad, contenedor, cuadrilla o lote (sin nueva consulta).</summary>
        void AttachWorkPlanDependentFiltersHandlers()
        {
            frm.cboDistribuidor.SelectedValueChanged += WorkPlanDependents_FilterChanged;
            frm.cboPresentacion.SelectedValueChanged += WorkPlanDependents_FilterChanged;
            frm.cboVariety.SelectedValueChanged += WorkPlanDependents_FilterChanged;
            frm.cboContainer.SelectedValueChanged += WorkPlanDependents_FilterChanged;
            frm.cboWorkGroup.SelectedValueChanged += WorkPlanDependents_FilterChanged;
            frm.cboLot.SelectedValueChanged += WorkPlanDependents_FilterChanged;
        }

        static string EscapeRowFilterValue(string s) => (s ?? "").Replace("'", "''");

        void ApplyWorkPlanRowFilter()
        {
            if (dtCboWorkPlan == null)
                return;

            List<(ComboBox cbo, string col)> filtroPorColumna =
            [
                (frm.cboDistribuidor, Distributor.ColumnId),
                (frm.cboPresentacion, Presentation.ColumnId),
                (frm.cboVariety, Variety.ColumnId),
                (frm.cboContainer, Container.ColumnId),
                (frm.cboWorkGroup, WorkGroup.ColumnId),
                (frm.cboLot, ColumnLotCboKey),
            ];

            StringBuilder sb = new();
            foreach (var (cbo, col) in filtroPorColumna)
            {
                if (cbo.SelectedIndex < 1 || !dtCboWorkPlan.Columns.Contains(col))
                    continue;

                object? sv = cbo.SelectedValue;
                if (sv is null || sv is DBNull)
                    continue;

                string val = sv.ToString() ?? "";
                if (string.IsNullOrEmpty(val))
                    continue;

                if (sb.Length > 0)
                    sb.Append(" AND ");
                sb.Append($"[{col}] = '{EscapeRowFilterValue(val)}'");
            }

            if (!string.IsNullOrWhiteSpace(frm.txbDay.Text))
            {
                try
                {
                    string fecha = DateTime.Parse(frm.txbDay.Text).ToString("yyyy-MM-dd");
                    if (sb.Length > 0)
                        sb.Append(" AND ");
                    sb.Append($"[Fecha] = '{EscapeRowFilterValue(fecha)}'");
                }
                catch { /* ignorar fecha inválida */ }
            }

            string filterCore = sb.ToString();
            if (!string.IsNullOrEmpty(filterCore))
            {
                string sel = EscapeRowFilterValue(ClsComboBoxes.textSelect);
                filterCore = $"({filterCore}) OR [{Column.name}] = '{sel}'";
            }

            dtCboWorkPlan.DefaultView.RowFilter = string.IsNullOrEmpty(filterCore) ? null : filterCore;
        }

        void WorkPlanDependents_FilterChanged(object? sender, EventArgs e)
        {
            ApplyWorkPlanRowFilter();
            if (frm.cboWorkPlan.Items.Count > 0)
                frm.cboWorkPlan.SelectedIndex = 0;
        }

        void EnsureWorkPlanCodeVisibleInFilter(string planId)
        {
            if (dtCboWorkPlan == null || string.IsNullOrEmpty(planId))
                return;

            string vm = Column.id;
            bool visible = dtCboWorkPlan.DefaultView.Cast<DataRowView>().Any(r => r[vm].ToString() == planId);
            if (visible)
                return;

            string f = dtCboWorkPlan.DefaultView.RowFilter ?? "";
            string planCond = $"[{vm}] = '{EscapeRowFilterValue(planId)}'";
            if (string.IsNullOrEmpty(f))
            {
                string sel = EscapeRowFilterValue(ClsComboBoxes.textSelect);
                dtCboWorkPlan.DefaultView.RowFilter = $"{planCond} OR [{Column.name}] = '{sel}'";
            }
            else
                dtCboWorkPlan.DefaultView.RowFilter = $"({f}) OR ({planCond})";
        }

        bool SelectWorkPlanInCombo(string planId)
        {
            if (dtCboWorkPlan == null || string.IsNullOrEmpty(planId))
            {
                if (frm.cboWorkPlan.Items.Count > 0)
                    frm.cboWorkPlan.SelectedIndex = 0;
                return false;
            }

            string vm = frm.cboWorkPlan.ValueMember;
            foreach (DataRowView drv in dtCboWorkPlan.DefaultView)
            {
                if (drv.Row[vm].ToString() != planId)
                    continue;

                string display = drv.Row[frm.cboWorkPlan.DisplayMember].ToString();
                int idx = frm.cboWorkPlan.FindStringExact(display);
                if (idx >= 0)
                {
                    frm.cboWorkPlan.SelectedIndex = idx;
                    return true;
                }
            }

            if (frm.cboWorkPlan.Items.Count > 0)
                frm.cboWorkPlan.SelectedIndex = 0;
            return false;
        }


        public void BtnAddPallet()
        {
            string idPallet = ClsValues.FormatZeros(frm.txbIdPallet.Text,"00000");
            if (frm.dgvPallet.Rows.Cast<DataGridViewRow>().Any(row => row.Cells["Pallet"].Value?.ToString() == idPallet))
            {
                SystemSounds.Exclamation.Play();
                return;
            }

            DataTable dtPallet = ClsQuerysDB.GetDataTable(queryPallet + " WHERE vw.Pallet = '" + idPallet + "' ");

            if (dtPallet.Rows.Count < 1)
            {
                SystemSounds.Exclamation.Play();
                return;
            }

            string idPlanTxb = frm.txbIdWorkPlan.Text;

            string estiba = dtPallet.Rows[0]["Estiba"].ToString();

            //if (!string.IsNullOrEmpty(estiba))
            //{
            //    SystemSounds.Exclamation.Play();

            //    MessageBox.Show($"El pallet pertenece a la estiba {estiba}. \n Se necesita desestibar ", "Convertir pallet", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //    return;
            //}
            //else
            //{
                string plan = dtPallet.Rows[0]["Plan de Trabajo"].ToString();

                if (idPlanTxb.IsNullOrEmpty())
                {
                    string fecha = DateTime.Parse(dtPallet.Rows[0]["Fecha"].ToString()).ToString("yyyy-MM-dd");
                    dtPalletList = dtPallet;
                    frm.dgvPallet.DataSource = dtPallet;
                    ApplyPalletGridPresentation();
                    frm.txbIdWorkPlan.Text = plan;
                    frm.txbDay.Text = fecha;

                    EnsureWorkPlanLoaded(plan);
                    frm.txbWorkPlan.Text = GetWorkPlanNameOrFallback(plan);
                    ApplyWorkPlanRowFilter();
                    EnsureWorkPlanCodeVisibleInFilter(plan);
                    SelectWorkPlanInCombo(plan);

                }
                else if (plan == idPlanTxb)
                {
                    if (dtPallet.Rows.Count > 0)
                    {
                        DataRow newRow = dtPalletList.NewRow();
                        newRow.ItemArray = dtPallet.Rows[0].ItemArray;
                        dtPalletList.Rows.InsertAt(newRow, 0);
                    }
                }
                else
                {
                    SystemSounds.Exclamation.Play();

                    MessageBox.Show($"El pallet pertenece a un plan de trabajo diferente.", "Convertir pallet", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }
            //}

            frm.txbIdPallet.Focus();
            frm.txbIdPallet.SelectAll();
        }

        /// <summary>Etiqueta de pallet con datos actuales en BD (<see cref="ClsReprintPallet.ReprintPalletTag"/>); no modifica cajas.</summary>
        public void BtnImprimirPalletEtiquetaSeleccionado()
        {
            if (frm.dgvPallet.SelectedRows.Count == 0)
            {
                SystemSounds.Exclamation.Play();
                return;
            }

            object? palletVal = frm.dgvPallet.SelectedRows[0].Cells["Pallet"].Value;
            string raw = palletVal?.ToString() ?? "";
            if (string.IsNullOrWhiteSpace(raw))
                return;

            string idPallet = ClsValues.FormatZeros(raw, "00000");

            int copias = Convert.ToInt32(frm.nudCopiasEtiqueta.Value);
            if (copias < 1)
                copias = 1;

            bool invertir = frm.chkInvertirEtiqueta.Checked;
            // showDate=true: igual que en otros flujos de reimpresión; Cajas viene siempre de vw_PackPalletCon dentro de ReprintPalletTag (sin actualizar registros).
            ClsReprintPallet.ReprintPalletTag(idPallet, copias, invertir, showDate: true);
        }

        public void BtnQuitPallet()
        {
            if (frm.dgvPallet.SelectedRows.Count > 0)
            {
                dtPalletList.Rows.RemoveAt(frm.dgvPallet.SelectedRows[0].Index);

                if (dtPalletList.Rows.Count == 0)
                {
                    ClearFields();
                }
            }
        }

        public void BtnClear() => ClearFields();

        private void ClearFields()
        {
            frm.txbIdPallet.Text = string.Empty;
            frm.txbIdWorkPlan.Text = string.Empty;
            frm.txbWorkPlan.Text = string.Empty;
            frm.txbDay.Text = string.Empty;
            ApplyWorkPlanRowFilter();
            InitPalletDataGridSchema();
        }

        public void BtnAccept()
        {
            if (frm.dgvPallet.Rows.Count > 0)
            {
                if (frm.txbIdWorkPlan.Text != frm.cboWorkPlan.SelectedValue.ToString())
                {
                    if (!ValidateManifestRestrictionsBeforeConvert())
                        return;

                    DialogResult result = MessageBox.Show("¿Está seguro de aceptar los cambios?", "Aceptar cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        if (UpdatePalletWorkPlan())
                        {
                            RefreshPalletsInDataGridFromDatabase();
                            MessageBox.Show("Los pallets se convirtieron correctamente.", "Convertir pallet", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Está seleccionado el mismo plan de trabajo.", "Convertir pallet", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                SystemSounds.Exclamation.Play();
            }
        }

        /// <summary>Vacía las filas del listado del grid y las repuebla consultando <see cref="queryPallet"/> por cada pallet.</summary>
        void RefreshPalletsInDataGridFromDatabase()
        {
            if (dtPalletList == null || !dtPalletList.Columns.Contains("Pallet"))
                return;

            List<string> palletIds = dtPalletList.AsEnumerable()
                .Select(r => ClsValues.FormatZeros(r["Pallet"]?.ToString() ?? "", "00000"))
                .Where(static id => !string.IsNullOrWhiteSpace(id))
                .ToList();

            if (palletIds.Count == 0)
                return;

            dtPalletList.Rows.Clear();

            foreach (string palletId in palletIds)
            {
                string safeId = palletId.Replace("'", "''");
                DataTable dtOne = ClsQuerysDB.GetDataTable($"{queryPallet.Trim()} WHERE vw.Pallet = '{safeId}' ");
                if (dtOne.Rows.Count == 0)
                    continue;

                DataRow nueva = dtPalletList.NewRow();
                nueva.ItemArray = dtOne.Rows[0].ItemArray;
                dtPalletList.Rows.Add(nueva);
            }

            ApplyPalletGridPresentation();
        }

        bool ValidateManifestRestrictionsBeforeConvert()
        {
            if (dtPalletList == null || dtPalletList.Rows.Count == 0 || dtCboWorkPlan == null)
                return true;

            string? selectedWorkPlan = frm.cboWorkPlan.SelectedValue?.ToString();
            if (string.IsNullOrEmpty(selectedWorkPlan))
                return true;

            DataRow? wpRow = dtCboWorkPlan.Rows.Cast<DataRow>()
                .FirstOrDefault(r => r.Table.Columns.Contains(Column.id) && r[Column.id]?.ToString() == selectedWorkPlan);
            if (wpRow == null)
                return true;

            bool hasManifestId = dtPalletList.Columns.Contains(Pallet.ColumnManifestId);
            bool hasManifestText = dtPalletList.Columns.Contains("Manifiesto");

            List<string> diffs = new();

            foreach (DataRow palRow in dtPalletList.Rows)
            {
                string palletId = palRow.Table.Columns.Contains("Pallet") ? palRow["Pallet"]?.ToString() ?? "" : "";
                bool inManifest =
                    (hasManifestId && !string.IsNullOrWhiteSpace(palRow[Pallet.ColumnManifestId]?.ToString())) ||
                    (hasManifestText && !string.IsNullOrWhiteSpace(palRow["Manifiesto"]?.ToString()));

                if (!inManifest)
                    continue;

                foreach (var (label, colId) in validateInManifest)
                {
                    if (!dtPalletList.Columns.Contains(colId) || !wpRow.Table.Columns.Contains(colId))
                        continue;

                    string palVal = palRow[colId]?.ToString() ?? "";
                    string wpVal = wpRow[colId]?.ToString() ?? "";

                    if (!string.Equals(palVal, wpVal, StringComparison.OrdinalIgnoreCase))
                        diffs.Add($"{palletId}: {label}");
                }
            }

            if (diffs.Count == 0)
                return true;

            string detalle = string.Join("\n", diffs.Distinct());
            MessageBox.Show(
                "No se puede convertir porque hay pallets en manifiesto,\nEl plan nuevo cambia columnas no permitidas.\n\n" +
                "Diferencias detectadas (Pallet: columna):\n" + detalle,
                "Validación manifiesto",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            return false;
        }

        private bool UpdatePalletWorkPlan()
        {
            try
            {
                string userUpdate = User.GetUserName();
                string selectedWorkPlan = frm.cboWorkPlan.SelectedValue.ToString();

                sql.BeginTransaction();

                SqlCommand cmd = new SqlCommand("sp_PackPalletConvert", sql.cnn, sql.transaction);
                cmd.CommandType = CommandType.StoredProcedure;

                foreach (DataGridViewRow row in frm.dgvPallet.Rows)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@idPallet", row.Cells["Pallet"].Value.ToString());
                    cmd.Parameters.AddWithValue("@idWorkPlanNew", selectedWorkPlan);
                    cmd.Parameters.AddWithValue("@user", userUpdate);

                    cmd.ExecuteNonQuery();
                }

                sql.CommitTransaction();
                return true;
            }
            catch (Exception ex)
            {
                sql.RollbackTransaction();
                MessageBox.Show(ex.ToString(), "Error al añadir materiales de salida");
                return false;
            }
        }

        private void ClearCboFilters()
        {
            frm.cboDistribuidor.SelectedIndex = -1;
            frm.cboPresentacion.SelectedIndex = -1;
            frm.cboVariety.SelectedIndex = -1;
            frm.cboContainer.SelectedIndex = -1;
            frm.cboWorkGroup.SelectedIndex = -1;
            frm.cboLot.SelectedIndex = -1;
        }

        private void MetodcboWorkGroupDuplicateSelectedIndexChanged()
        {
            if (frm.cboWorkGroupDuplicate.SelectedIndex > 0 && !string.IsNullOrEmpty(frm.txbWorkPlan.Text))
            {
                string idWorkPlan = frm.txbIdWorkPlan.Text;
                string nameWorkPlan = frm.txbWorkPlan.Text;
                string idWorkGroup = frm.cboWorkGroupDuplicate.SelectedValue.ToString();
                string nameWorkGroup = frm.cboWorkGroupDuplicate.Text;

                bool result = MessageBox.Show($"¿Desea duplicar el plan de trabajo:\n{nameWorkPlan}\nPara la cuadrilla: {nameWorkGroup}?", "Duplicar Plan de Trabajo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
                string idNewWorkPlan = string.Empty;

                if (result)
                    idNewWorkPlan = EworkPlan.DuplicateWorkPlan(idWorkPlan, idWorkGroup);

                ClearCbosAndSelectPlan(idNewWorkPlan);
            }
        }

        public void BtnCloneWorkPlan()
        {
            string idWP = frm.txbIdWorkPlan.Text;
            if (string.IsNullOrEmpty(idWP))
            {
                System.Media.SystemSounds.Beep.Play();
                return;
            }

            ClsWorkPlan cls = new();
            cls.OpenFrmClone(idWP);
            string? idNewWorkPlan = cls.idAddModify;

            if (string.IsNullOrEmpty(idNewWorkPlan))
                return;

            ClearCbosAndSelectPlan(idNewWorkPlan);
        }

        private void ClearCbosAndSelectPlan(string? planId)
        {
            if (!string.IsNullOrEmpty(planId))
            {
                ClearCboFilters();
                ReloadWorkPlanDataFromDatabase();
                ClsComboBoxes.CboSelectIndexWithTextInValueMemberKeepingFilter(frm.cboWorkPlan, planId);
            }
        }
    }
}
