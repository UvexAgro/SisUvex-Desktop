using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Extentions;
using SisUvex.Catalogos.Metods.Querys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static SisUvex.Catalogos.Metods.ClsObject;

namespace SisUvex.Nomina.CONTRATO.PayrollPack_BoxPerNumber.BoxPerNumberReport
{
    internal class ClsPayrollBoxPerNumberReport
    {
        public FrmPayrollBoxPerNumberReport? frm = null;
        public ClsPayrollBoxPerNumberReportExcel? excel = null;

        /// <summary>Consulta SQL plana (origen).</summary>
        private DataTable? _dtFlat;

        /// <summary>Nombres de columnas coherentes entre SQL, rejilla pivoteada y Excel.</summary>
        internal static class Columns
        {
            public const string Fecha = "Fecha";
            public const string IdContratista = "idContratista";
            public const string Contratista = "Contratista";
            public const string IdCuadrilla = "idCuadrilla";
            public const string Cuadrilla = "Cuadrilla";
            public const string Numero = "Número";
            public const string IdEmpleado = "idEmpleado";
            public const string NombreEmpleado = "Nombre empleado";
            public const string IdPrecio = "idPrecio";
            public const string Categoria = "Categoría";
            public const string Cajas = "Cajas";
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

            ClsComboBoxes.CboLoadActives(frm.cboPeriod, Payroll_AttendancePeriod.Cbo);
            ClsComboBoxes.CboLoadActives(frm.cboPaymentPlace, PlacePayment.Cbo);
            ClsComboBoxes.CboLoadActives(frm.cboContractor, Contractor.Cbo);
            ClsComboBoxes.CboLoadActives(frm.cboSeason, Season.Cbo);
            ClsComboBoxes.CboLoadActives(frm.cboWorkGroup, WorkGroup.Cbo);

            List<(ComboBox, string)> lscboWorkGroupFilter = new List<(ComboBox, string)>();
            lscboWorkGroupFilter.Add((frm.cboContractor, Contractor.ColumnId));
            lscboWorkGroupFilter.Add((frm.cboSeason, Season.ColumnId));

            ClsComboBoxes.Events.CboApplyEventFilterAllForOne(frm.cboWorkGroup, null, lscboWorkGroupFilter);
        }

        public void CboPeriodChanged()
        {
            if (frm == null) return;
            if (frm.cboPeriod.SelectedIndex < 1) return;

            try
            {
                string cSemana = frm.cboPeriod.GetColumnValue(Payroll_AttendancePeriod.ColumnSequence).ToString() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(cSemana)) return;

                string startDateStr = ClsQuerysDB.GetData(
                    $@"SELECT TOP (1) CONVERT(varchar(10), CAST(d_startDate_per AS date), 120)
                       FROM Payroll_AttendancePeriod
                       WHERE c_sequence_per = '{cSemana.Replace("'", "''")}'
                       ORDER BY id_period DESC, d_startDate_per DESC;");

                if (DateTime.TryParse(startDateStr, out DateTime startDate))
                {
                    frm.dtpDate1.Value = startDate.Date;
                    frm.dtpDate2.Value = startDate.Date.AddDays(6);
                }
            }
            catch
            {
                // El usuario puede ajustar fechas manualmente
            }
        }

        private void ClearLabels()
        {
            if (frm == null) return;

            frm.lblPeriod.Text = string.Empty;
            frm.lblContractor.Text = string.Empty;
            frm.lblWorkGroup.Text = string.Empty;
            frm.lblPaymentPlace.Text = string.Empty;
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

            if (frm.cboPeriod.SelectedIndex > 0)
                frm.lblPeriod.Text = frm.cboPeriod.Text;

            if (frm.cboContractor.SelectedIndex > 0)
                frm.lblContractor.Text = frm.cboContractor.GetColumnValue(Contractor.ColumnName).ToString();

            if (frm.cboWorkGroup.SelectedIndex > 0)
            {
                frm.lblWorkGroup.Text = frm.cboWorkGroup.GetColumnValue(WorkGroup.ColumnName).ToString();
                frm.lblContractor.Text = frm.cboWorkGroup.GetColumnValue(Contractor.ColumnName).ToString();
            }

            if (frm.cboPaymentPlace.SelectedIndex > 0)
                frm.lblPaymentPlace.Text = frm.cboPaymentPlace.SelectedValue + " - " + frm.cboPaymentPlace.GetColumnValue(PlacePayment.ColumnName).ToString();

            frm.lblDateRange.Text = $"{frm.dtpDate1.Value:yyyy-MM-dd} al {frm.dtpDate2.Value:yyyy-MM-dd}";
        }

        private void SetDgvReport()
        {
            if (frm == null) return;

            excel ??= new ClsPayrollBoxPerNumberReportExcel();

            try
            {
                _dtFlat = FetchFlatDataFromDb();
                DataTable pivoted = excel.BuildPivotDataTable(
                    _dtFlat,
                    frm.dtpDate1.Value.Date,
                    frm.dtpDate2.Value.Date);

                frm.dgvReport.AutoGenerateColumns = true;
                frm.dgvReport.DataSource = pivoted;

                if (frm.dgvReport.Columns.Count > 0 && pivoted.Columns.Count > 0)
                    ApplyDgColumnHeadersFromCaption(pivoted);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Reporte cajas por número", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>Usa <see cref="DataColumn.Caption"/> para encabezados de día (es-MX) en la rejilla.</summary>
        private void ApplyDgColumnHeadersFromCaption(DataTable pivoted)
        {
            if (frm == null) return;

            foreach (DataGridViewColumn col in frm.dgvReport.Columns.Cast<DataGridViewColumn>())
            {
                if (!pivoted.Columns.Contains(col.DataPropertyName))
                    continue;

                DataColumn dc = pivoted.Columns[col.DataPropertyName]!;
                string header = string.IsNullOrWhiteSpace(dc.Caption) ? dc.ColumnName : dc.Caption;
                col.HeaderText = header;
            }
        }

        /// <summary>Consulta base (agrupación en BD); filtros parametrizados. Orden estable en SQL.</summary>
        private DataTable FetchFlatDataFromDb()
        {
            if (frm == null) return new DataTable();

            var parameters = new Dictionary<string, object>
            {
                { "@date1", frm.dtpDate1.Value.Date },
                { "@date2", frm.dtpDate2.Value.Date },
            };

            var sb = new StringBuilder();

            sb.AppendLine($@"SELECT
                                CAST(bpn.d_workDay AS date) AS [{Columns.Fecha}],
                                wgp.id_contractor        AS [{Columns.IdContratista}],
                                ctr.v_nameContractor    AS [{Columns.Contratista}],
                                bpn.id_workGroup        AS [{Columns.IdCuadrilla}],
                                wgp.v_nameWorkGroup      AS [{Columns.Cuadrilla}],
                                bpn.id_number            AS [{Columns.Numero}],
                                bpn.id_employee          AS [{Columns.IdEmpleado}],
                                CONCAT_WS('/', emp.v_lastNamePat, emp.v_lastNameMat, emp.v_name) AS [{Columns.NombreEmpleado}],
                                bpn.id_price             AS [{Columns.IdPrecio}],
                                pri.v_descriptionPrice   AS [{Columns.Categoria}],
                                SUM(bpn.i_boxes)         AS [{Columns.Cajas}]
                            FROM PayrollPack_BoxPerNumber bpn
                            LEFT JOIN Pack_WorkGroup   wgp ON wgp.id_workGroup  = bpn.id_workGroup
                            LEFT JOIN Pack_Contractor  ctr ON ctr.id_contractor = wgp.id_contractor
                            LEFT JOIN Pack_Price       pri ON pri.id_price      = bpn.id_price
                            LEFT JOIN Nom_Employees    emp ON emp.id_employee   = bpn.id_employee");

            sb.AppendLine("WHERE CAST(bpn.d_workDay AS date) BETWEEN @date1 AND @date2");

            if (frm.cboWorkGroup.SelectedIndex > 0 && frm.cboWorkGroup.SelectedValue != null)
            {
                sb.AppendLine(" AND bpn.id_workGroup = @idWorkGroup ");
                parameters.Add("@idWorkGroup", frm.cboWorkGroup.SelectedValue!.ToString()!.Trim());
            }

            if (frm.cboContractor.SelectedIndex > 0 && frm.cboContractor.SelectedValue != null)
            {
                sb.AppendLine(" AND wgp.id_contractor = @idContractor ");
                parameters.Add("@idContractor", frm.cboContractor.SelectedValue!.ToString()!.Trim());
            }

            //if (frm.cboSeason.SelectedIndex > 0 && frm.cboSeason.SelectedValue != null)
            //{
            //    sb.AppendLine(" AND wgp.id_season = @idSeason ");
            //    parameters.Add("@idSeason", frm.cboSeason.SelectedValue!.ToString()!.Trim());
            //}

            if (frm.cboPaymentPlace.SelectedIndex > 0 && frm.cboPaymentPlace.SelectedValue != null)
            {
                sb.AppendLine(" AND emp.id_paymentPlace = @idPaymentPlace ");
                parameters.Add("@idPaymentPlace", frm.cboPaymentPlace.SelectedValue!.ToString()!.Trim());
            }

            sb.AppendLine($@"GROUP BY
                                CAST(bpn.d_workDay AS date),
                                wgp.id_contractor,
                                ctr.v_nameContractor,
                                bpn.id_workGroup,
                                wgp.v_nameWorkGroup,
                                bpn.id_number,
                                bpn.id_employee,
                                CONCAT_WS('/', emp.v_lastNamePat, emp.v_lastNameMat, emp.v_name),
                                bpn.id_price,
                                pri.v_descriptionPrice");

            sb.AppendLine($@"ORDER BY
                                [{Columns.Contratista}],
                                [{Columns.Cuadrilla}],
                                [{Columns.Numero}],
                                [{Columns.IdEmpleado}],
                                [{Columns.NombreEmpleado}],
                                [{Columns.Categoria}],
                                [{Columns.Fecha}];");

            return ClsQuerysDB.ExecuteParameterizedQuery(sb.ToString(), parameters);
        }

        public void BtnGenerateExcelReport()
        {
            if (frm == null) return;

            excel ??= new ClsPayrollBoxPerNumberReportExcel();

            if (_dtFlat == null || _dtFlat.Rows.Count == 0)
            {
                MessageBox.Show(
                    "No hay datos para generar el reporte (usa Buscar antes).",
                    "Reporte cajas por número",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            excel.GenerateExcelReport(
                _dtFlat,
                frm.dtpDate1.Value.Date,
                frm.dtpDate2.Value.Date,
                frm.lblPeriod.Text,
                frm.lblContractor.Text,
                frm.lblWorkGroup.Text,
                frm.lblPaymentPlace.Text,
                frm.lblDateRange.Text);
        }
    }
}
