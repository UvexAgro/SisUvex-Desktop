using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Extentions;
using SisUvex.Catalogos.Metods.Querys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using static SisUvex.Catalogos.Metods.ClsObject;

namespace SisUvex.Nomina.CONTRATO.Nom_employees_pairNumber
{
    internal class ClsNomEmployesPairNumber
    {
        public FrmNomEmployesPairNumber? frm;
        public ClsExcelNomEmployesPairNumber? excel;

        private DataTable? _dtReport;

        public void BeginForm()
        {
            if (frm == null) return;

            frm.WindowState = FormWindowState.Maximized;
            SetControls();
            ClearLabels();
            excel = new ClsExcelNomEmployesPairNumber();
        }

        private void SetControls()
        {
            if (frm == null) return;

            ClsComboBoxes.CboLoadActives(frm.cboSeason, Season.Cbo);
            ClsComboBoxes.CboLoadActives(frm.cboContractor, Contractor.Cbo);
            ClsComboBoxes.CboLoadActives(frm.cboWorkGroup, WorkGroup.Cbo);

            var workGroupFilters = new List<(ComboBox, string)>
            {
                (frm.cboContractor, Contractor.ColumnId),
                (frm.cboSeason, Season.ColumnId),
            };

            ClsComboBoxes.Events.CboApplyEventFilterAllForOne(frm.cboWorkGroup, null, workGroupFilters);
        }

        private void ClearLabels()
        {
            if (frm == null) return;

            frm.lblContractor.Text = string.Empty;
            frm.lblWorkGroup.Text = string.Empty;
        }

        public void BtnLoadReport()
        {
            if (frm == null) return;

            if (frm.cboWorkGroup.SelectedIndex < 1 || frm.cboWorkGroup.SelectedValue == null)
            {
                MessageBox.Show(
                    "Seleccione una cuadrilla.",
                    "Empleados por número",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            SetLblReportDetails();
            SetDgvReport();
        }

        private void SetLblReportDetails()
        {
            if (frm == null) return;

            ClearLabels();

            if (frm.cboContractor.SelectedIndex > 0)
                frm.lblContractor.Text = frm.cboContractor.GetColumnValue(Contractor.ColumnName).ToString();

            if (frm.cboWorkGroup.SelectedIndex > 0)
            {
                frm.lblWorkGroup.Text = frm.cboWorkGroup.GetColumnValue(WorkGroup.ColumnName).ToString();
                frm.lblContractor.Text = frm.cboWorkGroup.GetColumnValue(Contractor.ColumnName).ToString();
            }
        }

        private void SetDgvReport()
        {
            if (frm == null) return;

            excel ??= new ClsExcelNomEmployesPairNumber();

            try
            {
                _dtReport = FetchEmployeesWorkGroupFromDb();
                frm.dgvReport.AutoGenerateColumns = true;
                frm.dgvReport.DataSource = _dtReport;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Empleados por número", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Origen: dbo.fn_Nom_Employees_WorkGroup — solo parámetro id de cuadrilla.
        /// </summary>
        private DataTable FetchEmployeesWorkGroupFromDb()
        {
            if (frm == null) return new DataTable();

            string idWorkGroup = frm.cboWorkGroup.SelectedValue!.ToString()!.Trim();

            var parameters = new Dictionary<string, object>
            {
                { "@idWorkGroup", idWorkGroup },
            };

            var sb = new StringBuilder();
            sb.AppendLine("SELECT *");
            sb.AppendLine("FROM dbo.fn_Nom_Employees_WorkGroup(@idWorkGroup)");
            sb.AppendLine("ORDER BY CUADRILLA, NUMERO, PAREJA;");

            return ClsQuerysDB.ExecuteParameterizedQuery(sb.ToString(), parameters);
        }

        public void BtnGenerateExcelReport()
        {
            if (frm == null) return;

            excel ??= new ClsExcelNomEmployesPairNumber();

            if (_dtReport == null || _dtReport.Rows.Count == 0)
            {
                MessageBox.Show(
                    "No hay datos para generar el reporte (usa Buscar antes).",
                    "Empleados por número",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            excel.GenerateExcelReport(
                _dtReport,
                frm.lblContractor.Text,
                frm.lblWorkGroup.Text);
        }
    }
}
