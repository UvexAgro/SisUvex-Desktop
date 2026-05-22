using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Extentions;
using SisUvex.Catalogos.Metods.Querys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using static SisUvex.Catalogos.Metods.ClsObject;

namespace SisUvex.Nomina.CONTRATO.PayrollPack_BoxPerNumber.BoxPerNumberReport
{
    internal class ClsPayrollBoxPerNumberReport
    {
        public FrmPayrollBoxPerNumberReport? frm = null;
        public ClsPayrollBoxPerNumberReportExcel? excel = null;

        /// <summary>Resultado de la consulta principal (hoja DATA).</summary>
        private DataTable? _dtData;

        /// <summary>Nombres de columnas coherentes entre SQL, rejilla y Excel.</summary>
        internal static class Columns
        {
            public const string IdWorkGroup = "idWorkGroup";
            public const string Cuadrilla = "Cuadrilla";
            public const string Fecha = "FECHA";
            public const string IdPrice = "idPrice";
            public const string Precio = "Precio";
            public const string Cajas = "CAJAS";
        }

        public void BeginFormCat()
        {
            if (frm == null) return;

            frm.WindowState = FormWindowState.Maximized;
            SetControls();
            ClearLabels();
            excel = new ClsPayrollBoxPerNumberReportExcel();
        }

        private void SetControls()
        {
            if (frm == null) return;

            ClsComboBoxes.CboLoadActives(frm.cboContractor, Contractor.Cbo);
            ClsComboBoxes.CboLoadActives(frm.cboSeason, Season.Cbo);
            ClsComboBoxes.CboLoadActives(frm.cboWorkGroup, WorkGroup.Cbo);

            var lscboWorkGroupFilter = new List<(ComboBox, string)>
            {
                (frm.cboContractor, Contractor.ColumnId),
                (frm.cboSeason, Season.ColumnId),
            };

            ClsComboBoxes.Events.CboApplyEventFilterAllForOne(frm.cboWorkGroup, null, lscboWorkGroupFilter);

            ClsComboBoxes.CboSelectIndexWithTextInValueMember(frm.cboSeason, "08"); //<-- Temp. uva 2026
        }

        private void ClearLabels()
        {
            if (frm == null) return;

            frm.lblContractor.Text = string.Empty;
            frm.lblWorkGroup.Text = string.Empty;
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

            frm.lblDateRange.Text = $"{frm.dtpDate1.Value:dd/MM/yyyy} al {frm.dtpDate2.Value:dd/MM/yyyy}";
        }

        private void SetDgvReport()
        {
            if (frm == null) return;

            excel ??= new ClsPayrollBoxPerNumberReportExcel();

            try
            {
                _dtData = FetchDataFromDb();
                DataTable preview = excel.BuildPreviewDataTable(
                    _dtData,
                    frm.dtpDate1.Value.Date,
                    frm.dtpDate2.Value.Date);

                frm.dgvReport.AutoGenerateColumns = true;
                frm.dgvReport.DataSource = preview;

                if (frm.dgvReport.Columns.Count > 0 && preview.Columns.Count > 0)
                    ApplyDgColumnHeadersFromCaption(preview);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Reporte cajas por número", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyDgColumnHeadersFromCaption(DataTable table)
        {
            if (frm == null) return;

            foreach (DataGridViewColumn col in frm.dgvReport.Columns)
            {
                if (!table.Columns.Contains(col.DataPropertyName))
                    continue;

                DataColumn dc = table.Columns[col.DataPropertyName]!;
                col.HeaderText = string.IsNullOrWhiteSpace(dc.Caption) ? dc.ColumnName : dc.Caption;
            }
        }

        /// <summary>Consulta por cuadrilla; filtros: fechas, contratista y/o cuadrilla.</summary>
        private DataTable FetchDataFromDb()
        {
            if (frm == null) return new DataTable();

            var parameters = new Dictionary<string, object>
            {
                { "@date1", frm.dtpDate1.Value.Date },
                { "@date2", frm.dtpDate2.Value.Date },
            };

            var sb = new StringBuilder();

            sb.AppendLine($@"SELECT
                                BOX.id_workGroup        AS [{Columns.IdWorkGroup}],
                                wgp.v_nameWorkGroup     AS [{Columns.Cuadrilla}],
                                CAST(BOX.d_workDay AS date) AS [{Columns.Fecha}],
                                BOX.id_price            AS [{Columns.IdPrice}],
                                pri.v_descriptionPrice  AS [{Columns.Precio}],
                                SUM(BOX.i_boxes)        AS [{Columns.Cajas}]
                            FROM PayrollPack_BoxPerNumber BOX
                            LEFT JOIN Nom_Employees EMP ON EMP.id_employee = BOX.id_employee
                            LEFT JOIN Pack_WorkGroup WGP ON WGP.id_workGroup = BOX.id_workGroup
                            LEFT JOIN Pack_Price pri ON pri.id_price = BOX.id_price
                            WHERE BOX.c_status = 'A'
                              AND CAST(BOX.d_workDay AS date) BETWEEN @date1 AND @date2");

            if (frm.cboWorkGroup.SelectedIndex > 0 && frm.cboWorkGroup.SelectedValue != null)
            {
                sb.AppendLine("  AND BOX.id_workGroup = @idWorkGroup");
                parameters.Add("@idWorkGroup", frm.cboWorkGroup.SelectedValue!.ToString()!.Trim());
            }
            else if (frm.cboContractor.SelectedIndex > 0 && frm.cboContractor.SelectedValue != null)
            {
                sb.AppendLine("  AND WGP.id_contractor = @idContractor");
                parameters.Add("@idContractor", frm.cboContractor.SelectedValue!.ToString()!.Trim());
            }

            sb.AppendLine($@"GROUP BY
                                BOX.d_workDay,
                                BOX.id_workGroup,
                                wgp.v_nameWorkGroup,
                                BOX.id_price,
                                pri.v_descriptionPrice");

            sb.AppendLine($@"ORDER BY
                                [{Columns.Cuadrilla}],
                                [{Columns.Fecha}],
                                [{Columns.Precio}];");

            return ClsQuerysDB.ExecuteParameterizedQuery(sb.ToString(), parameters);
        }

        public void BtnGenerateExcelReport()
        {
            if (frm == null) return;

            excel ??= new ClsPayrollBoxPerNumberReportExcel();

            if (_dtData == null || _dtData.Rows.Count == 0)
            {
                MessageBox.Show(
                    "No hay datos para generar el reporte (usa Buscar antes).",
                    "Reporte cajas por número",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            excel.GenerateExcelReport(
                _dtData,
                frm.dtpDate1.Value.Date,
                frm.dtpDate2.Value.Date,
                frm.lblContractor.Text,
                frm.lblWorkGroup.Text,
                frm.lblDateRange.Text);
        }
    }
}
