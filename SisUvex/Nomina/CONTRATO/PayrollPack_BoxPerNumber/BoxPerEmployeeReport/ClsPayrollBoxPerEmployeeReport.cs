using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Extentions;
using SisUvex.Catalogos.Metods.Forms.SelectionForms;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Usuarios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;
using static SisUvex.Catalogos.Metods.ClsObject;

namespace SisUvex.Nomina.CONTRATO.PayrollPack_BoxPerNumber.BoxPerEmployeeReport
{
    internal class ClsPayrollBoxPerEmployeeReport
    {
        public FrmPayrollBoxPerEmployeeReport? frm = null;
        public ClsPayrollBoxPerEmployeeReportExcel? excel = null;

        // ── Columnas de la vista de reporte ───────────────────────────────────
        internal static class Columns
        {
            public const string Fecha       = "FECHA";
            public const string IdPrice     = "idPrice";
            public const string Empaque     = "EMPAQUE";
            public const string Numero      = "NUMERO";
            public const string OrdenNum    = "ORDEN_NUM";
            public const string Codigo      = "CODIGO";
            public const string Nombre      = "NOMBRE";
            public const string Lp          = "LP";
            public const string Cuadrilla   = "CUADRILLA";
            public const string Contratista = "CONTRATISTA";
            public const string Cajas       = "CAJAS";
            public const string IdUser      = "idUser";
            public const string IdWorkGroup  = "idWorkGroup";
            public const string IdContractor = "idContractor";
            public const string IdSeason     = "idSeason";
            public const string Anotador     = "ANOTADOR";
        }

        // ── Columnas de vw_Nom_EmployeeWorkGroupPair ──────────────────────────
        private const string ColSel         = "Sel.";
        private const string ColCodigo      = "CODIGO";
        private const string ColIdSeason    = "idSeason";
        private const string ColIdWorkGroup  = "idWorkGroup";
        private const string ColIdContractor = "idContractor";

        // ── Columnas ocultas en el DGV del listado ────────────────────────────
        private readonly List<string> _columnsToHideInDgv = new()
        {
            "ORDEN_NUM", "idWorkGroup", "idContractor", "idUser", "idSeason",
        };

        // ── Estado interno ────────────────────────────────────────────────────
        private DataTable _dtEmployeeList = BuildEmptyEmployeeListTable();
        private DataTable? _dtReport;
        private bool _showingReport = false;

        // ── Inicio del formulario ─────────────────────────────────────────────

        public void BeginFormCat()
        {
            if (frm == null) return;

            frm.WindowState = FormWindowState.Maximized;
            SetControls();
            excel = new ClsPayrollBoxPerEmployeeReportExcel();
            ShowEmployeeList();
        }

        private void SetControls()
        {
            if (frm == null) return;

            ClsComboBoxes.CboLoadActives(frm.cboSeason, Season.CboWithDates);
            ClsComboBoxes.CboLoadActives(frm.cboContractor, Contractor.Cbo);
            ClsComboBoxes.CboLoadActives(frm.cboWorkGroup, WorkGroup.Cbo);
            UserFilter.SetCboAnotadores(frm.cboUser);

            var workGroupFilters = new List<(ComboBox, string)>
            {
                (frm.cboContractor, Contractor.ColumnId),
                (frm.cboSeason, Season.ColumnId),
            };
            var userFilters = new List<(ComboBox, string)>
            {
                (frm.cboContractor, Contractor.ColumnId),
                (frm.cboWorkGroup, WorkGroup.ColumnId),
            };

            ClsComboBoxes.Events.CboApplyEventFilterAllForOne(frm.cboWorkGroup, null, workGroupFilters);
            ClsComboBoxes.Events.CboApplyEventFilterAllForOne(frm.cboUser, null, userFilters);

            frm.cboSeason.SelectedIndexChanged += CboSeason_SelectedIndexChanged;
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(frm.cboSeason, "08");

            SetupExcelSheetCheckboxes();
        }

        // ── Checkboxes de hojas Excel ─────────────────────────────────────────

        private void SetupExcelSheetCheckboxes()
        {
            if (frm == null) return;

            var items = new (CheckBox, string)[]
            {
                (frm.chbSheetAnotador,    ClsExcelReportPorAnotador.SheetName),
                (frm.chbSheetCuadrilla,   ClsExcelReportPorCuadrilla.SheetName),
                (frm.chbSheetConcentrado, ClsExcelReportConcentradoCuadrillas.SheetName),
                (frm.chbSheetResumen,     ClsPayrollBoxPerEmployeeResumeExcel.SheetName),
            };

            foreach (var (cb, name) in items)
            {
                cb.Text    = name;
                cb.Checked = true;
                cb.CheckedChanged -= ExcelSheetCheckbox_CheckedChanged;
                cb.CheckedChanged += ExcelSheetCheckbox_CheckedChanged;
            }
        }

        public void ExcelSheetCheckbox_CheckedChanged(object? sender, EventArgs e)
        {
            if (frm == null || GetExcelSheetSelection().HasAnyReportSheet) return;
            if (sender is CheckBox cb)
            {
                cb.Checked = true;
                SystemSounds.Exclamation.Play();
            }
        }

        private ExcelSheetSelection GetExcelSheetSelection()
        {
            if (frm == null) return new ExcelSheetSelection();
            return new ExcelSheetSelection
            {
                PorAnotador           = frm.chbSheetAnotador.Checked,
                PorCuadrilla          = frm.chbSheetCuadrilla.Checked,
                ConcentradoCuadrillas = frm.chbSheetConcentrado.Checked,
                Resumen               = frm.chbSheetResumen.Checked,
            };
        }

        // ── Evento temporada → fechas ─────────────────────────────────────────

        public void CboSeason_SelectedIndexChanged(object? sender, EventArgs e)
            => ApplySeasonDatesToDatePickers();

        private void ApplySeasonDatesToDatePickers()
        {
            if (frm == null || frm.cboSeason.SelectedIndex < 1) return;
            if (frm.cboSeason.SelectedItem is not DataRowView drv) return;

            DataTable tbl = drv.Row.Table;
            if (!tbl.Columns.Contains(Season.ColumnStartDate) ||
                !tbl.Columns.Contains(Season.ColumnEndDate)) return;
            if (drv.Row[Season.ColumnStartDate] is DBNull ||
                drv.Row[Season.ColumnEndDate]   is DBNull) return;

            DateTime seasonStart = Convert.ToDateTime(drv.Row[Season.ColumnStartDate]).Date;
            DateTime seasonEnd   = Convert.ToDateTime(drv.Row[Season.ColumnEndDate]).Date;
            DateTime today       = DateTime.Today;

            frm.dtpDate1.Value = seasonStart;
            frm.dtpDate2.Value = today <= seasonEnd ? today : seasonEnd;
        }

        // ── Buscar empleado ───────────────────────────────────────────────────

        public void BtnSearchEmployee()
        {
            ClsSelectionForm sel = new ClsSelectionForm();

            sel.OpenSelectionForm("EmployeeBasic", "Código");

            if (!string.IsNullOrEmpty(sel.SelectedValue))
                frm.txbIdEmployee.Text = sel.SelectedValue;

            frm.txbIdEmployee.Focus();

            frm.txbIdEmployee.SelectAll();
        }

        // ── Agregar empleado(s) ───────────────────────────────────────────────

        public void BtnAddEmployee()
        {
            if (frm == null) return;

            List<string> codes = ParseEmployeeCodes(frm.txbIdEmployee.Text).ToList();
            if (codes.Count == 0)
            {
                SetAdvice("Ingresa o pega uno o más códigos de empleado.", isError: true);
                return;
            }

            if (codes.Count == 1)
                AddSingleEmployee(codes[0]);
            else
                AddMultipleEmployees(codes);
        }

        private void AddSingleEmployee(string id)
        {
            DataRow? existing = FindEmployeeInList(id);
            if (existing != null)
            {
                existing[ColSel] = "1";
                RefreshEmployeeDgv();
                SetAdvice($"⚠ El empleado {id} ya está en el listado.", isError: true);
                return;
            }

            try
            {
                DataTable dt = FetchEmployeeByCode(id);
                if (dt.Rows.Count == 0)
                {
                    SetAdvice($"No se encontró el empleado {id}.", isError: true);
                    return;
                }
                AddRowsToEmployeeList(dt);
                RefreshEmployeeDgv();
                SetAdvice($"Empleado {id} agregado correctamente.", isError: false);
                frm!.txbIdEmployee.Clear();
                ShowEmployeeList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al agregar empleado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddMultipleEmployees(List<string> codes)
        {
            int added = 0, repeated = 0;
            var notFound = new List<string>();

            foreach (string id in codes)
            {
                try
                {
                    DataRow? existing = FindEmployeeInList(id);
                    if (existing != null) { existing[ColSel] = "1"; repeated++; continue; }

                    DataTable dt = FetchEmployeeByCode(id);
                    if (dt.Rows.Count == 0) { notFound.Add(id); continue; }

                    AddRowsToEmployeeList(dt);
                    added++;
                }
                catch { notFound.Add(id); }
            }

            RefreshEmployeeDgv();
            ShowEmployeeList();

            var sb = new StringBuilder();
            sb.Append($"{added} agregado(s)");
            if (repeated > 0)      sb.Append($",  {repeated} ya existía(n)");
            if (notFound.Count > 0) sb.Append($",  no encontrado(s): {string.Join(", ", notFound)}");
            SetAdvice(sb.ToString(), isError: notFound.Count > 0);
            frm!.txbIdEmployee.Clear();
        }

        public void TxbIdEmployee_KeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                e.SuppressKeyPress = true;
                BtnAddEmployee();
            }
        }

        private static IEnumerable<string> ParseEmployeeCodes(string input)
            => input
                .Split(new[] { '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Trim())
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Distinct(StringComparer.OrdinalIgnoreCase);

        private DataTable FetchEmployeeByCode(string codigo)
        {
            string? selectedSeason = frm?.cboSeason.ComboValueOrNull();

            if (!string.IsNullOrWhiteSpace(selectedSeason))
            {
                var pSeason = new Dictionary<string, object>
                {
                    ["@codigo"]   = codigo,
                    ["@idSeason"] = selectedSeason,
                };
                DataTable dtSeason = ClsQuerysDB.ExecuteParameterizedQuery(
                    $"SELECT '1' AS [{ColSel}], * FROM dbo.vw_Nom_EmployeeWorkGroupPair " +
                    $"WHERE CODIGO = @codigo AND [{ColIdSeason}] = @idSeason " +
                    $"ORDER BY CUADRILLA, NUMERO, ORDEN_NUM;",
                    pSeason);

                if (dtSeason.Rows.Count > 0) return dtSeason;
            }

            var pAll = new Dictionary<string, object> { ["@codigo"] = codigo };
            return ClsQuerysDB.ExecuteParameterizedQuery(
                $"SELECT '1' AS [{ColSel}], * FROM dbo.vw_Nom_EmployeeWorkGroupPair " +
                $"WHERE CODIGO = @codigo ORDER BY CUADRILLA, NUMERO, ORDEN_NUM;",
                pAll);
        }

        // ── Agregar listado por filtros ────────────────────────────────────────

        public void BtnAddList()
        {
            if (frm == null) return;

            string? idSeason = frm.cboSeason.ComboValueOrNull();
            if (string.IsNullOrWhiteSpace(idSeason))
            {
                SetAdvice("⚠ Selecciona una temporada antes de agregar el listado.", isError: true);
                return;
            }

            try
            {
                var parameters = new Dictionary<string, object>();
                var sb = new StringBuilder();
                sb.AppendLine($"SELECT '1' AS [{ColSel}], * FROM dbo.vw_Nom_EmployeeWorkGroupPair WHERE 1 = 1");

                sb.AppendLine($"AND [{ColIdSeason}] = @idSeason");
                parameters["@idSeason"] = idSeason;
                AppendCboFilter(sb, parameters, "@idContractor", ColIdContractor, frm.cboContractor.ComboValueOrNull());
                AppendCboFilter(sb, parameters, "@idWorkGroup",  ColIdWorkGroup,  frm.cboWorkGroup.ComboValueOrNull());
                sb.AppendLine("ORDER BY CUADRILLA, NUMERO, ORDEN_NUM, CODIGO;");

                DataTable dt = ClsQuerysDB.ExecuteParameterizedQuery(sb.ToString(), parameters);
                if (dt.Rows.Count == 0)
                {
                    SetAdvice("No se encontraron empleados con los filtros seleccionados.", isError: true);
                    return;
                }

                int added = AddRowsToEmployeeList(dt);
                RefreshEmployeeDgv();
                SetAdvice($"{added} empleado(s) agregado(s) al listado.", isError: false);
                ShowEmployeeList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al agregar listado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Limpiar listado ───────────────────────────────────────────────────

        public void BtnClearList()
        {
            _dtEmployeeList = BuildEmptyEmployeeListTable();
            _dtReport = null;
            if (frm != null) frm.lblEmployeeAdvice.Text = string.Empty;
            RefreshEmployeeDgv();
            ShowEmployeeList();
        }

        // ── Cargar reporte ────────────────────────────────────────────────────

        public void BtnLoadReport()
        {
            if (frm == null) return;

            if (frm.dtpDate2.Value.Date < frm.dtpDate1.Value.Date)
            {
                MessageBox.Show("La fecha final no puede ser menor a la fecha inicial.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _dtReport = FetchReportFromDb();
                if (_dtReport.Rows.Count == 0)
                {
                    SystemSounds.Exclamation.Play();
                    SetAdvice("No se encontraron datos para el reporte con los filtros seleccionados.", isError: true);
                    return;
                }
                SetAdvice(string.Empty, isError: false);
                ShowReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Reporte cajas por empleado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Generar Excel ─────────────────────────────────────────────────────

        public void BtnGenerateExcelReport()
        {
            if (frm == null) return;

            excel ??= new ClsPayrollBoxPerEmployeeReportExcel();

            if (_dtReport == null || _dtReport.Rows.Count == 0)
            {
                MessageBox.Show(
                    "No hay datos para generar el reporte (usa \"Cargar reporte\" antes).",
                    "Reporte cajas por empleado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            ExcelSheetSelection sheetSelection = GetExcelSheetSelection();
            if (!sheetSelection.HasAnyReportSheet)
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show(
                    "Selecciona al menos una hoja de reporte para generar el Excel.",
                    "Reporte cajas por empleado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Construir texto de filtros desde combos (sin depender de etiquetas)
            string season      = GetComboText(frm.cboSeason);
            string contratista = GetComboText(frm.cboContractor);
            string workGroup   = GetComboText(frm.cboWorkGroup);
            string user        = GetComboText(frm.cboUser);
            string dateRange   = $"{frm.dtpDate1.Value:dd/MM/yyyy} al {frm.dtpDate2.Value:dd/MM/yyyy}";

            excel.GenerateExcelReport(
                _dtReport,
                frm.dtpDate1.Value.Date,
                frm.dtpDate2.Value.Date,
                season,
                contratista,
                workGroup,
                user,
                dateRange,
                sheetSelection);
        }

        // ── Alternar vista DGV ────────────────────────────────────────────────

        public void ChbShowEmployees_CheckedChanged()
        {
            if (frm == null) return;
            if (frm.chbShowEmployees.Checked) ShowEmployeeList();
        }

        public void ChbShowReport_CheckedChanged()
        {
            if (frm == null) return;
            if (!frm.chbShowReport.Checked) return;

            if (_dtReport == null || _dtReport.Rows.Count == 0)
            {
                SystemSounds.Exclamation.Play();
                frm.chbShowReport.Checked    = false;
                frm.chbShowEmployees.Checked = true;
                SetAdvice("No hay reporte cargado. Usa \"Cargar reporte\" primero.", isError: true);
                return;
            }

            ShowReport();
        }

        // ── Helpers DGV ──────────────────────────────────────────────────────

        private void ShowEmployeeList()
        {
            if (frm == null) return;

            _showingReport = false;

            frm.dgvReport.ReadOnly          = false;
            frm.dgvReport.AutoGenerateColumns = true;
            frm.dgvReport.DataSource        = null;
            frm.dgvReport.DataSource        = _dtEmployeeList;
            ApplyCheckBoxColumnToSel();
            HideColumnsInDgv(_columnsToHideInDgv);

            frm.chbShowEmployees.Checked = true;
            frm.chbShowReport.Checked    = false;
        }

        private void ShowReport()
        {
            if (frm == null || _dtReport == null) return;

            _showingReport = true;
            excel ??= new ClsPayrollBoxPerEmployeeReportExcel();

            DataTable preview = excel.BuildPreviewDataTable(
                _dtReport,
                frm.dtpDate1.Value.Date,
                frm.dtpDate2.Value.Date);

            frm.dgvReport.ReadOnly          = true;
            frm.dgvReport.AutoGenerateColumns = true;
            frm.dgvReport.DataSource        = null;
            frm.dgvReport.DataSource        = preview;

            frm.chbShowReport.Checked    = true;
            frm.chbShowEmployees.Checked = false;
        }

        private void RefreshEmployeeDgv()
        {
            if (frm == null || _showingReport) return;
            ShowEmployeeList();
        }

        private void ApplyCheckBoxColumnToSel()
        {
            if (frm == null || !frm.dgvReport.Columns.Contains(ColSel)) return;

            var col = frm.dgvReport.Columns[ColSel];
            if (col is DataGridViewCheckBoxColumn) return;

            int ordinal = col.Index;
            frm.dgvReport.Columns.Remove(col);

            var chkCol = new DataGridViewCheckBoxColumn
            {
                Name             = ColSel,
                HeaderText       = ColSel,
                DataPropertyName = ColSel,
                TrueValue        = "1",
                FalseValue       = "0",
                Width            = 45,
                DisplayIndex     = ordinal,
            };
            frm.dgvReport.Columns.Insert(ordinal, chkCol);
        }

        private void HideColumnsInDgv(IEnumerable<string> colsToHide)
        {
            if (frm == null) return;
            foreach (string col in colsToHide)
                if (frm.dgvReport.Columns.Contains(col))
                    frm.dgvReport.Columns[col].Visible = false;
        }

        // ── Helpers listado de empleados ──────────────────────────────────────

        private static DataTable BuildEmptyEmployeeListTable()
        {
            var dt = new DataTable();
            dt.Columns.Add(ColSel, typeof(string));
            return dt;
        }

        private DataRow? FindEmployeeInList(string codigo)
        {
            if (!_dtEmployeeList.Columns.Contains(ColCodigo)) return null;
            return _dtEmployeeList.AsEnumerable()
                .FirstOrDefault(r => string.Equals(
                    r[ColCodigo]?.ToString()?.Trim(),
                    codigo,
                    StringComparison.OrdinalIgnoreCase));
        }

        private int AddRowsToEmployeeList(DataTable source)
        {
            foreach (DataColumn col in source.Columns)
                if (!_dtEmployeeList.Columns.Contains(col.ColumnName))
                    _dtEmployeeList.Columns.Add(col.ColumnName, col.DataType);

            int count = 0;
            foreach (DataRow srcRow in source.Rows)
            {
                string codigo = source.Columns.Contains(ColCodigo)
                    ? srcRow[ColCodigo]?.ToString()?.Trim() ?? string.Empty
                    : string.Empty;

                DataRow? existing = string.IsNullOrWhiteSpace(codigo) ? null : FindEmployeeInList(codigo);
                if (existing != null) { existing[ColSel] = "1"; continue; }

                DataRow newRow = _dtEmployeeList.NewRow();
                foreach (DataColumn col in source.Columns)
                    if (_dtEmployeeList.Columns.Contains(col.ColumnName))
                        newRow[col.ColumnName] = srcRow[col.ColumnName];

                newRow[ColSel] = "1";
                _dtEmployeeList.Rows.Add(newRow);
                count++;
            }

            return count;
        }

        private List<string> GetSelectedCodigos()
        {
            if (!_dtEmployeeList.Columns.Contains(ColSel) ||
                !_dtEmployeeList.Columns.Contains(ColCodigo))
                return new List<string>();

            return _dtEmployeeList.AsEnumerable()
                .Where(r => r[ColSel]?.ToString() == "1")
                .Select(r => r[ColCodigo]?.ToString()?.Trim() ?? string.Empty)
                .Where(c => !string.IsNullOrWhiteSpace(c))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();
        }

        // ── Consulta principal del reporte ────────────────────────────────────

        private DataTable FetchReportFromDb()
        {
            if (frm == null) return new DataTable();

            var parameters = new Dictionary<string, object>
            {
                ["@date1"] = frm.dtpDate1.Value.Date,
                ["@date2"] = frm.dtpDate2.Value.Date,
            };

            var sb = new StringBuilder();
            sb.AppendLine("SELECT *");
            sb.AppendLine("FROM dbo.vw_PayrollPack_BoxPerNumberReport");
            sb.AppendLine("WHERE 1 = 1");
            sb.AppendLine($"  AND CAST([{Columns.Fecha}] AS date) BETWEEN @date1 AND @date2");

            // Filtro por empleados seleccionados en el listado (si hay alguno)
            List<string> selectedCodigos = GetSelectedCodigos();
            if (selectedCodigos.Count > 0)
            {
                sb.Append($"  AND [{Columns.Codigo}] IN (");
                for (int i = 0; i < selectedCodigos.Count; i++)
                {
                    string pname = $"@emp{i}";
                    if (i > 0) sb.Append(", ");
                    sb.Append(pname);
                    parameters[pname] = selectedCodigos[i];
                }
                sb.AppendLine(")");
            }

            sb.AppendLine($"ORDER BY [{Columns.Contratista}], [{Columns.Cuadrilla}], [{Columns.IdUser}], [{Columns.OrdenNum}], [{Columns.Numero}], [{Columns.Codigo}];");

            DataTable dt = ClsQuerysDB.ExecuteParameterizedQuery(sb.ToString(), parameters);
            AddUserNameColumn(dt);
            return dt;
        }

        // ── Helpers de consulta ───────────────────────────────────────────────

        private static void AppendCboFilter(
            StringBuilder sb,
            Dictionary<string, object> parameters,
            string paramName, string colName, string? value)
        {
            if (string.IsNullOrWhiteSpace(value)) return;
            sb.AppendLine($"AND [{colName}] = {paramName}");
            parameters[paramName] = value.Trim();
        }

        private static void AddUserNameColumn(DataTable reportTable)
        {
            if (reportTable == null || !reportTable.Columns.Contains(Columns.IdUser)) return;

            if (!reportTable.Columns.Contains(Columns.Anotador))
            {
                DataColumn dcUserName = reportTable.Columns.Add(Columns.Anotador, typeof(string));
                int idUserOrdinal = reportTable.Columns[Columns.IdUser].Ordinal;
                dcUserName.SetOrdinal(Math.Min(idUserOrdinal + 1, reportTable.Columns.Count - 1));
            }

            List<string> userIds = reportTable.AsEnumerable()
                .Select(row => row[Columns.IdUser] == DBNull.Value
                    ? string.Empty : row[Columns.IdUser].ToString()?.Trim() ?? string.Empty)
                .Where(id => !string.IsNullOrWhiteSpace(id))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();

            if (userIds.Count == 0) return;

            var parameters = new Dictionary<string, object>();
            var sb = new StringBuilder();
            sb.AppendLine("SELECT CAST(usu.c_codigo_usu AS varchar(20)) AS [idUser],");
            sb.AppendLine($"       usu.v_nombre_usu AS [{Columns.Anotador}]");
            sb.AppendLine("FROM dbo.usuario usu");
            sb.Append("WHERE usu.c_codigo_usu IN (");

            for (int i = 0; i < userIds.Count; i++)
            {
                string pname = $"@idUser{i}";
                if (i > 0) sb.Append(", ");
                sb.Append(pname);
                parameters[pname] = userIds[i];
            }
            sb.AppendLine(");");

            DataTable dtUsers = ClsQuerysUsuarios.ExecuteParameterizedQuery(sb.ToString(), parameters);
            var namesByUserId = dtUsers.AsEnumerable()
                .ToDictionary(
                    r => r["idUser"]?.ToString()?.Trim() ?? string.Empty,
                    r => r[Columns.Anotador] == DBNull.Value
                        ? string.Empty : r[Columns.Anotador].ToString()?.Trim() ?? string.Empty,
                    StringComparer.OrdinalIgnoreCase);

            foreach (DataRow row in reportTable.Rows)
            {
                string idUser = row[Columns.IdUser] == DBNull.Value
                    ? string.Empty : row[Columns.IdUser].ToString()?.Trim() ?? string.Empty;
                row[Columns.Anotador] = namesByUserId.TryGetValue(idUser, out string? name) ? name : string.Empty;
            }
        }

        // ── Texto de filtros para el Excel ────────────────────────────────────

        private static string GetComboText(ComboBox cbo)
        {
            if (cbo.SelectedIndex < 1) return string.Empty;
            return cbo.Text?.Trim() ?? string.Empty;
        }

        private void SetAdvice(string text, bool isError)
        {
            if (frm == null) return;
            frm.lblEmployeeAdvice.Text      = text;
            frm.lblEmployeeAdvice.ForeColor = isError ? System.Drawing.Color.Red : System.Drawing.Color.Gray;
        }
    }
}
