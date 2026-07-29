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

        private DataTable? _dtCajasData;
        private DataTable? _dtBoletasData;

        public static class ReportTypes
        {
            public const string CajasCapturadas = "CAJAS CAPTURADAS";
            public const string BoletasPallet = "BOLETAS PALLET";
        }

        /// <summary>Nombres de columnas consulta cajas capturadas.</summary>
        internal static class Columns
        {
            public const string IdWorkGroup = "idWorkGroup";
            public const string Cuadrilla = "Cuadrilla";
            public const string Fecha = "FECHA";
            public const string IdPrice = "idPrice";
            public const string Precio = "Precio";
            public const string Cajas = "CAJAS";
        }

        /// <summary>Nombres de columnas consulta boletas pallet.</summary>
        internal static class BoletasColumns
        {
            public const string Folio = "FOLIO";
            public const string Fecha = "Fecha";
            public const string Cuadrilla = "CUADRILLA";
            public const string Contratista = "CONTRATISTA";
            public const string Lote = "LOTE";
            public const string Empaque = "EMPAQUE";
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

            frm.cboReportType.Items.Clear();
            frm.cboReportType.Items.Add(ReportTypes.CajasCapturadas);
            frm.cboReportType.Items.Add(ReportTypes.BoletasPallet);
            frm.cboReportType.SelectedIndex = 0;

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

            try
            {
                _dtCajasData = FetchCajasDataFromDb();
                _dtBoletasData = FetchBoletasDataFromDb();
                BindDgvForSelectedReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Reporte cajas por número", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CboReportTypeChanged()
        {
            if (_dtCajasData == null && _dtBoletasData == null)
                return;

            BindDgvForSelectedReport();
        }

        private void BindDgvForSelectedReport()
        {
            if (frm == null) return;

            excel ??= new ClsPayrollBoxPerNumberReportExcel();

            DataTable preview = IsBoletasReportSelected()
                ? excel.BuildBoletasPreviewDataTable(
                    _dtBoletasData,
                    frm.dtpDate1.Value.Date,
                    frm.dtpDate2.Value.Date)
                : excel.BuildPreviewDataTable(
                    _dtCajasData,
                    frm.dtpDate1.Value.Date,
                    frm.dtpDate2.Value.Date);

            frm.dgvReport.AutoGenerateColumns = true;
            frm.dgvReport.DataSource = preview;

            if (frm.dgvReport.Columns.Count > 0 && preview.Columns.Count > 0)
                ApplyDgColumnHeadersFromCaption(preview);
        }

        private bool IsBoletasReportSelected()
            => frm != null
               && string.Equals(
                   frm.cboReportType.SelectedItem?.ToString(),
                   ReportTypes.BoletasPallet,
                   StringComparison.OrdinalIgnoreCase);

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

        private DataTable FetchCajasDataFromDb()
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

            AppendWorkGroupOrContractorFilter(sb, parameters, "BOX.id_workGroup", "WGP.id_contractor");

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

        private DataTable FetchBoletasDataFromDb()
        {
            if (frm == null) return new DataTable();

            var parameters = new Dictionary<string, object>
            {
                { "@date1", frm.dtpDate1.Value.Date },
                { "@date2", frm.dtpDate2.Value.Date },
            };

            var sb = new StringBuilder();

            sb.AppendLine($@"SELECT
                                pal.v_invoice               AS [{BoletasColumns.Folio}],
                                CONVERT(DATE, pal.d_packed) AS [{BoletasColumns.Fecha}],
                                wgp.v_nameWorkGroup         AS [{BoletasColumns.Cuadrilla}],
                                con.v_nameContractor        AS [{BoletasColumns.Contratista}],
                                lot.v_nameLot               AS [{BoletasColumns.Lote}],
                                pr.v_descriptionPrice       AS [{BoletasColumns.Empaque}],
                                SUM(pal.i_boxes)            AS [{BoletasColumns.Cajas}]
                            FROM dbo.Pack_Pallet AS pal
                            LEFT JOIN dbo.Pack_WorkPlan AS wpl ON wpl.id_workPlan = pal.id_workPlan
                            LEFT JOIN dbo.Pack_GTIN AS gtn ON gtn.id_GTIN = wpl.id_GTIN
                            LEFT JOIN dbo.Pack_Lot AS lot ON lot.id_lot = wpl.id_lot AND lot.id_variety = gtn.id_variety
                            LEFT JOIN dbo.Pack_WorkGroup AS wgp ON wgp.id_workGroup = wpl.id_workGroup
                            LEFT JOIN dbo.Pack_Contractor AS con ON con.id_contractor = wgp.id_contractor
                            LEFT JOIN dbo.Pack_Size AS siz ON siz.id_size = wpl.id_size
                            LEFT JOIN dbo.Pack_Presentation AS pre ON pre.id_presentation = gtn.id_presentation
                            LEFT JOIN dbo.Pack_Container AS cnt ON cnt.id_container = gtn.id_container
                            LEFT JOIN dbo.Pack_Variety AS [var] ON [var].id_variety = gtn.id_variety
                            LEFT JOIN dbo.Pack_Distributor AS dis ON dis.id_distributor = gtn.id_distributor
                            LEFT JOIN dbo.Pack_Crop AS crop ON crop.id_crop = [var].id_crop
                            LEFT JOIN dbo.Pack_TypeBox AS box ON box.id_typeBox = wpl.id_typeBox
                            LEFT JOIN dbo.Pack_Price AS pr ON pr.id_price = gtn.id_price
                            WHERE CAST(pal.d_packed AS date) BETWEEN @date1 AND @date2
                              AND pal.c_restowing != 'ER'");

            AppendWorkGroupOrContractorFilter(sb, parameters, "wpl.id_workGroup", "wgp.id_contractor");

            sb.AppendLine($@"GROUP BY
                                pal.v_invoice,
                                pal.d_packed,
                                wgp.v_nameWorkGroup,
                                con.v_nameContractor,
                                lot.v_nameLot,
                                pr.v_descriptionPrice");

            sb.AppendLine($@"ORDER BY
                                [{BoletasColumns.Cuadrilla}],
                                [{BoletasColumns.Fecha}],
                                [{BoletasColumns.Folio}],
                                [{BoletasColumns.Empaque}];");

            return ClsQuerysDB.ExecuteParameterizedQuery(sb.ToString(), parameters);
        }

        private void AppendWorkGroupOrContractorFilter(
            StringBuilder sb,
            Dictionary<string, object> parameters,
            string workGroupColumn,
            string contractorColumn)
        {
            if (frm == null) return;

            if (frm.cboWorkGroup.SelectedIndex > 0 && frm.cboWorkGroup.SelectedValue != null)
            {
                sb.AppendLine($"  AND {workGroupColumn} = @idWorkGroup");
                parameters.Add("@idWorkGroup", frm.cboWorkGroup.SelectedValue!.ToString()!.Trim());
            }
            else if (frm.cboContractor.SelectedIndex > 0 && frm.cboContractor.SelectedValue != null)
            {
                sb.AppendLine($"  AND {contractorColumn} = @idContractor");
                parameters.Add("@idContractor", frm.cboContractor.SelectedValue!.ToString()!.Trim());
            }
        }

        public void BtnGenerateExcelReport()
        {
            if (frm == null) return;

            excel ??= new ClsPayrollBoxPerNumberReportExcel();

            bool hasCajas = _dtCajasData != null && _dtCajasData.Rows.Count > 0;
            bool hasBoletas = _dtBoletasData != null && _dtBoletasData.Rows.Count > 0;

            if (!hasCajas && !hasBoletas)
            {
                MessageBox.Show(
                    "No hay datos para generar el reporte (usa Buscar antes).",
                    "Reporte cajas por número",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            excel.GenerateExcelReport(
                _dtCajasData,
                _dtBoletasData,
                frm.dtpDate1.Value.Date,
                frm.dtpDate2.Value.Date,
                frm.lblContractor.Text,
                frm.lblWorkGroup.Text,
                frm.lblDateRange.Text);
        }
    }
}
