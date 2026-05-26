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

namespace SisUvex.Nomina.CONTRATO.Nom_employees_pairNumber_WorkGroup
{
    internal class ClsNomEmployesPairNumberWgp
    {
        private const string UserColumnName = "Anotador";
        private const string ColIdSeason = "idSeason";
        private const string ColIdWorkGroup = "idWorkGroup";
        private const string ColIdContractor = "idContractor";
        private const string ColIdUser = "idUser";
        private const string ColUserName = "ANOTADOR";

        private readonly List<string> _columnsToHide = new()
        {
            ColIdWorkGroup,
            ColIdContractor,
            ColIdUser,
            ColIdSeason,
        };

        public FrmNomEmployesPairNumberWgp? frm;
        public ClsExcelNomEmployesPairNumberWgp? excel;

        private DataTable? _dtReport;

        public void BeginForm()
        {
            if (frm == null) return;

            frm.WindowState = FormWindowState.Maximized;
            SetControls();
            ClearLabels();
            excel = new ClsExcelNomEmployesPairNumberWgp();
        }

        private void SetControls()
        {
            if (frm == null) return;

            ClsComboBoxes.CboLoadActives(frm.cboSeason, Season.Cbo);
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
        }

        private void ClearLabels()
        {
            if (frm == null) return;

            frm.lblSeason.Text = string.Empty;
            frm.lblContractor.Text = string.Empty;
            frm.lblWorkGroup.Text = string.Empty;
            frm.lblUser.Text = string.Empty;
        }

        public void BtnLoadReport()
        {
            if (frm == null) return;

            SetLblReportDetails();
            SetDgvReport();
        }

        private void SetLblReportDetails()
        {
            if (frm == null) return;

            ClearLabels();

            frm.lblSeason.Text = GetComboLabelText(frm.cboSeason, Season.ColumnName);
            frm.lblContractor.Text = GetComboLabelText(frm.cboContractor, Contractor.ColumnName);
            frm.lblWorkGroup.Text = GetComboLabelText(frm.cboWorkGroup, WorkGroup.ColumnName);
            frm.lblUser.Text = GetComboLabelText(frm.cboUser, UserColumnName);

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

        private void SetDgvReport()
        {
            if (frm == null) return;

            excel ??= new ClsExcelNomEmployesPairNumberWgp();

            try
            {
                _dtReport = FetchEmployeesWorkGroupFromDb();
                frm.dgvReport.AutoGenerateColumns = true;
                frm.dgvReport.DataSource = _dtReport;
                HideColumnsInDgv();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Empleados por número / pareja", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HideColumnsInDgv()
        {
            if (frm == null) return;

            foreach (string columnName in _columnsToHide)
            {
                if (frm.dgvReport.Columns.Contains(columnName))
                    frm.dgvReport.Columns[columnName].Visible = false;
            }
        }

        private DataTable FetchEmployeesWorkGroupFromDb()
        {
            if (frm == null) return new DataTable();

            var parameters = new Dictionary<string, object>();
            var sb = new StringBuilder();

            sb.AppendLine("SELECT *");
            sb.AppendLine("FROM dbo.vw_Nom_EmployeeWorkGroupPair");
            sb.AppendLine("WHERE 1 = 1");

            AddFilter(sb, parameters, "@idSeason", ColIdSeason, frm.cboSeason.ComboValueOrNull());
            AddFilter(sb, parameters, "@idWorkGroup", ColIdWorkGroup, frm.cboWorkGroup.ComboValueOrNull());
            AddFilter(sb, parameters, "@idContractor", ColIdContractor, frm.cboContractor.ComboValueOrNull());
            AddFilter(sb, parameters, "@idUser", ColIdUser, frm.cboUser.ComboValueOrNull());

            sb.AppendLine("ORDER BY CUADRILLA, NUMERO, PAREJA, CODIGO;");

            DataTable dtReport = ClsQuerysDB.ExecuteParameterizedQuery(sb.ToString(), parameters);
            AddUserNameColumn(dtReport);
            return dtReport;
        }

        private static void AddUserNameColumn(DataTable reportTable)
        {
            if (reportTable == null || !reportTable.Columns.Contains(ColIdUser))
                return;

            if (!reportTable.Columns.Contains(ColUserName))
            {
                DataColumn dcUserName = reportTable.Columns.Add(ColUserName, typeof(string));

                int idUserOrdinal = reportTable.Columns[ColIdUser].Ordinal;
                int desiredOrdinal = Math.Min(idUserOrdinal + 1, reportTable.Columns.Count - 1);
                dcUserName.SetOrdinal(desiredOrdinal);
            }

            List<string> userIds = reportTable.AsEnumerable()
                .Select(row => row[ColIdUser] == DBNull.Value ? string.Empty : row[ColIdUser].ToString()?.Trim() ?? string.Empty)
                .Where(id => !string.IsNullOrWhiteSpace(id))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();

            if (userIds.Count == 0)
                return;

            var parameters = new Dictionary<string, object>();
            var sb = new StringBuilder();

            sb.AppendLine("SELECT");
            sb.AppendLine("    CAST(usu.c_codigo_usu AS varchar(20)) AS [idUser],");
            sb.AppendLine("    usu.v_nombre_usu AS [ANOTADOR]");
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
                    row => row[ColUserName] == DBNull.Value ? string.Empty : row[ColUserName].ToString()?.Trim() ?? string.Empty,
                    StringComparer.OrdinalIgnoreCase);

            foreach (DataRow row in reportTable.Rows)
            {
                string idUser = row[ColIdUser] == DBNull.Value ? string.Empty : row[ColIdUser].ToString()?.Trim() ?? string.Empty;
                row[ColUserName] = namesByUserId.TryGetValue(idUser, out string? userName) ? userName : string.Empty;
            }
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

        public void BtnGenerateExcelReport()
        {
            if (frm == null) return;

            excel ??= new ClsExcelNomEmployesPairNumberWgp();

            if (_dtReport == null || _dtReport.Rows.Count == 0)
            {
                MessageBox.Show(
                    "No hay datos para generar el reporte (usa Buscar antes).",
                    "Empleados por número / pareja",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            excel.GenerateExcelReport(
                _dtReport,
                frm.lblSeason.Text,
                frm.lblContractor.Text,
                frm.lblWorkGroup.Text,
                frm.lblUser.Text,
                _columnsToHide);
        }
    }
}
