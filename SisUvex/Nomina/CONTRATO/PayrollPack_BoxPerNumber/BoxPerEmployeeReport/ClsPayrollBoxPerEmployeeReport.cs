using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Extentions;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Usuarios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static SisUvex.Catalogos.Metods.ClsObject;

namespace SisUvex.Nomina.CONTRATO.PayrollPack_BoxPerNumber.BoxPerEmployeeReport
{
    internal class ClsPayrollBoxPerEmployeeReport
    {
        public FrmPayrollBoxPerEmployeeReport? frm = null;
        public ClsPayrollBoxPerEmployeeReportExcel? excel = null;

        private DataTable? _dtReport;

        internal static class Columns
        {
            public const string Fecha = "FECHA";
            public const string IdPrice = "idPrice";
            public const string Empaque = "EMPAQUE";
            public const string Numero = "NUMERO";
            public const string OrdenNum = "ORDEN_NUM";
            public const string Codigo = "CODIGO";
            public const string Nombre = "NOMBRE";
            public const string Lp = "LP";
            public const string Cuadrilla = "CUADRILLA";
            public const string Contratista = "CONTRATISTA";
            public const string Cajas = "CAJAS";
            public const string IdUser = "idUser";
            public const string IdWorkGroup = "idWorkGroup";
            public const string IdContractor = "idContractor";
            public const string IdSeason = "idSeason";
            public const string Anotador = "ANOTADOR";
        }

        public void BeginFormCat()
        {
            if (frm == null) return;

            frm.WindowState = FormWindowState.Maximized;
            SetControls();
            ClearLabels();
            excel = new ClsPayrollBoxPerEmployeeReportExcel();
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

            // Temp. uva 2026 (mismo patrón que otros formularios; también aplica sus fechas al rango)
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(frm.cboSeason, "08");
        }

        public void CboSeason_SelectedIndexChanged(object? sender, EventArgs e)
            => ApplySeasonDatesToDatePickers();

        private void ApplySeasonDatesToDatePickers()
        {
            if (frm == null || frm.cboSeason.SelectedIndex < 1)
                return;

            if (!TryGetSelectedSeasonDateRange(frm.cboSeason, out DateTime start, out DateTime end))
                return;

            frm.dtpDate1.Value = start;
            frm.dtpDate2.Value = end;
        }

        private static bool TryGetSelectedSeasonDateRange(ComboBox cbo, out DateTime start, out DateTime end)
        {
            start = default;
            end = default;

            if (cbo.SelectedIndex < 1)
                return false;

            if (cbo.SelectedItem is not DataRowView drv)
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

        private void ClearLabels()
        {
            if (frm == null) return;
            frm.lblSeason.Text = string.Empty;
            frm.lblContractor.Text = string.Empty;
            frm.lblWorkGroup.Text = string.Empty;
            frm.lblUser.Text = string.Empty;
            frm.lblDateRange.Text = string.Empty;
        }

        public void BtnLoadReport()
        {
            if (frm == null) return;

            if (frm.dtpDate2.Value.Date < frm.dtpDate1.Value.Date)
            {
                MessageBox.Show("La fecha final no puede ser menor a la fecha inicial.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SetLblReportDetails();

            try
            {
                _dtReport = FetchReportFromDb();
                BindDgvReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Reporte cajas por empleado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetLblReportDetails()
        {
            if (frm == null) return;

            ClearLabels();
            frm.lblSeason.Text = GetComboLabelText(frm.cboSeason, Season.ColumnName);
            frm.lblContractor.Text = GetComboLabelText(frm.cboContractor, Contractor.ColumnName);
            frm.lblWorkGroup.Text = GetComboLabelText(frm.cboWorkGroup, WorkGroup.ColumnName);
            frm.lblUser.Text = GetComboLabelText(frm.cboUser, "Anotador");
            frm.lblDateRange.Text = $"{frm.dtpDate1.Value:dd/MM/yyyy} al {frm.dtpDate2.Value:dd/MM/yyyy}";

            if (string.IsNullOrWhiteSpace(frm.lblContractor.Text) && frm.cboWorkGroup.SelectedIndex > 0)
                frm.lblContractor.Text = SafeGetComboColumnText(frm.cboWorkGroup, Contractor.ColumnName);
        }

        private static string GetComboLabelText(ComboBox cbo, string columnName)
        {
            if (cbo.SelectedIndex < 1)
                return string.Empty;

            string columnValue = SafeGetComboColumnText(cbo, columnName);
            return string.IsNullOrWhiteSpace(columnValue) ? cbo.Text?.Trim() ?? string.Empty : columnValue;
        }

        private static string SafeGetComboColumnText(ComboBox cbo, string columnName)
        {
            try
            {
                object value = cbo.GetColumnValue(columnName);
                return value == null || value == DBNull.Value ? string.Empty : value.ToString()?.Trim() ?? string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }

        private void BindDgvReport()
        {
            if (frm == null) return;
            excel ??= new ClsPayrollBoxPerEmployeeReportExcel();

            DataTable preview = excel.BuildPreviewDataTable(
                _dtReport,
                frm.dtpDate1.Value.Date,
                frm.dtpDate2.Value.Date);

            frm.dgvReport.AutoGenerateColumns = true;
            frm.dgvReport.DataSource = preview;
        }

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

            AddFilter(sb, parameters, "@idSeason", Columns.IdSeason, frm.cboSeason.ComboValueOrNull());
            AddFilter(sb, parameters, "@idWorkGroup", Columns.IdWorkGroup, frm.cboWorkGroup.ComboValueOrNull());
            AddFilter(sb, parameters, "@idContractor", Columns.IdContractor, frm.cboContractor.ComboValueOrNull());
            AddFilter(sb, parameters, "@idUser", Columns.IdUser, frm.cboUser.ComboValueOrNull());

            sb.AppendLine($"ORDER BY [{Columns.Contratista}], [{Columns.Cuadrilla}], [{Columns.IdUser}], [{Columns.OrdenNum}], [{Columns.Numero}], [{Columns.Codigo}];");

            DataTable dt = ClsQuerysDB.ExecuteParameterizedQuery(sb.ToString(), parameters);
            AddUserNameColumn(dt);
            return dt;
        }

        private static void AddFilter(
            StringBuilder sb,
            Dictionary<string, object> parameters,
            string parameterName,
            string columnName,
            string? selectedValue)
        {
            if (string.IsNullOrWhiteSpace(selectedValue))
                return;

            sb.AppendLine($"AND [{columnName}] = {parameterName}");
            parameters[parameterName] = selectedValue.Trim();
        }

        private static void AddUserNameColumn(DataTable reportTable)
        {
            if (reportTable == null || !reportTable.Columns.Contains(Columns.IdUser))
                return;

            if (!reportTable.Columns.Contains(Columns.Anotador))
            {
                DataColumn dcUserName = reportTable.Columns.Add(Columns.Anotador, typeof(string));
                int idUserOrdinal = reportTable.Columns[Columns.IdUser].Ordinal;
                int desiredOrdinal = Math.Min(idUserOrdinal + 1, reportTable.Columns.Count - 1);
                dcUserName.SetOrdinal(desiredOrdinal);
            }

            List<string> userIds = reportTable.AsEnumerable()
                .Select(row => row[Columns.IdUser] == DBNull.Value ? string.Empty : row[Columns.IdUser].ToString()?.Trim() ?? string.Empty)
                .Where(id => !string.IsNullOrWhiteSpace(id))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();

            if (userIds.Count == 0)
                return;

            var parameters = new Dictionary<string, object>();
            var sb = new StringBuilder();

            sb.AppendLine("SELECT");
            sb.AppendLine("    CAST(usu.c_codigo_usu AS varchar(20)) AS [idUser],");
            sb.AppendLine($"    usu.v_nombre_usu AS [{Columns.Anotador}]");
            sb.AppendLine("FROM dbo.usuario usu");
            sb.Append("WHERE usu.c_codigo_usu IN (");

            for (int i = 0; i < userIds.Count; i++)
            {
                string parameterName = $"@idUser{i}";
                if (i > 0)
                    sb.Append(", ");

                sb.Append(parameterName);
                parameters[parameterName] = userIds[i];
            }

            sb.AppendLine(");");

            DataTable dtUsers = ClsQuerysUsuarios.ExecuteParameterizedQuery(sb.ToString(), parameters);
            Dictionary<string, string> namesByUserId = dtUsers.AsEnumerable()
                .ToDictionary(
                    row => row["idUser"]?.ToString()?.Trim() ?? string.Empty,
                    row => row[Columns.Anotador] == DBNull.Value ? string.Empty : row[Columns.Anotador].ToString()?.Trim() ?? string.Empty,
                    StringComparer.OrdinalIgnoreCase);

            foreach (DataRow row in reportTable.Rows)
            {
                string idUser = row[Columns.IdUser] == DBNull.Value ? string.Empty : row[Columns.IdUser].ToString()?.Trim() ?? string.Empty;
                row[Columns.Anotador] = namesByUserId.TryGetValue(idUser, out string? userName) ? userName : string.Empty;
            }
        }

        public void BtnGenerateExcelReport()
        {
            if (frm == null) return;

            excel ??= new ClsPayrollBoxPerEmployeeReportExcel();

            if (_dtReport == null || _dtReport.Rows.Count == 0)
            {
                MessageBox.Show(
                    "No hay datos para generar el reporte (usa Buscar antes).",
                    "Reporte cajas por empleado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            excel.GenerateExcelReport(
                _dtReport,
                frm.dtpDate1.Value.Date,
                frm.dtpDate2.Value.Date,
                frm.lblSeason.Text,
                frm.lblContractor.Text,
                frm.lblWorkGroup.Text,
                frm.lblUser.Text,
                frm.lblDateRange.Text);
        }
    }
}

