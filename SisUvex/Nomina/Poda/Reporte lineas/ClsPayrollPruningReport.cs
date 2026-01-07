//-----
using ClosedXML.Excel;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Querys;
using System.Data;
using static SisUvex.Catalogos.Metods.ClsObject;
using SisUvex.Catalogos.Metods.Extentions;

namespace SisUvex.Nomina.Poda.Reporte_lineas
{
    internal class ClsPayrollPruningReport
    {
        string queryReport1 = $" SELECT * FROM vw_PayrollPiece_BoxPerNumber_Info "; 
        string queryReport1Order = $" ORDER BY Cuadrilla, [Numero/Pareja], Fecha ";

        public FrmPayrollPruningReport frm;

        public void BeginFormCat()
        {
            frm.dtpDate1.Value = DateTime.Now;
            frm.dtpDate2.Value = DateTime.Now;

            ClsComboBoxes.CboLoadActives(frm.cboWorkGroup, WorkGroup.Cbo);
            ClsComboBoxes.CboLoadActives(frm.cboLot, Lot.CboOnlyNameLot);
        }

        private DataTable GetDTDataReportQueryWithFilter()
        {
            Dictionary<string, object> parameters = new();

            string qry = queryReport1 + $" WHERE Fecha BETWEEN @date1 AND @date2 ";

            parameters.Add("@date1", frm.dtpDate1.Value.ToString("yyyy-MM-dd"));
            parameters.Add("@date2", frm.dtpDate2.Value.ToString("yyyy-MM-dd"));


            if (frm.cboLot.SelectedIndex > 0)
            {
                qry += " AND idLote = @idLot ";
                parameters.Add("@idLot", frm.cboLot.GetColumnValue(Column.id));
            }

            if (frm.cboWorkGroup.SelectedIndex > 0)
            {
                qry += " AND idCuadrilla = @idWorkGroup ";
                parameters.Add("@idWorkGroup", frm.cboWorkGroup.SelectedValue.ToString());
            }

            qry += queryReport1Order;

            Clipboard.SetText(qry);

            return ClsQuerysDB.ExecuteParameterizedQuery(qry, parameters);
        }

        // =============================
        // METODO DE EJEMPLO (QUERY)
        // =============================

        private bool IsFileLocked(string filePath)
        {
            if (!File.Exists(filePath))
                return false;

            try
            {
                using (FileStream stream = new FileStream(
                    filePath,
                    FileMode.Open,
                    FileAccess.ReadWrite,
                    FileShare.None))
                {
                    stream.Close();
                }
            }
            catch (IOException)
            {
                return true;
            }

            return false;
        }

        //
        public void GenerateExcelReportWithPivot()
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, "Reporte_Poda_Pivot.xlsx");

            if (IsFileLocked(filePath))
            {
                MessageBox.Show(
                    "El archivo 'Reporte_Poda.xlsx' está abierto.\n\n" +
                    "Ciérralo antes de generar el reporte.",
                    "Archivo en uso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            DataTable data = GetDTDataReportQueryWithFilter();

            if (data == null || data.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para generar el reporte.");
                return;
            }

            using (var workbook = new XLWorkbook())
            {
                var wsData = CreateDataWorksheet(workbook, data);
                var wsPivotRanges = CreatePivotLinesRangeWorksheet(workbook, wsData);
                var wsPivotLot = CreatePivotLotsWorksheet(workbook, wsData);

                workbook.SaveAs(filePath);
            }

            MessageBox.Show(
                "Reporte con tabla dinámica generado correctamente.",
                "Éxito",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private IXLWorksheet CreateDataWorksheet(XLWorkbook workbook, DataTable data)
        {
            var wsData = workbook.Worksheets.Add(data, "DATOS");

            wsData.Tables.First().ShowAutoFilter = true;
            wsData.Columns().AdjustToContents();

            return wsData;
        }

        private IXLWorksheet CreatePivotLinesRangeWorksheet(XLWorkbook workbook, IXLWorksheet wsData)
        {
            var wsPivotRanges = workbook.Worksheets.Add("POR RANGO LINEAS");

            var dataRange = wsData.RangeUsed();

            var pivot = wsPivotRanges.PivotTables.Add(
                "Pivot_Poda",
                wsPivotRanges.Cell("A3"),
                dataRange
            );

            // FILAS =============================
            pivot.RowLabels.Add("Cuadrilla");
            pivot.RowLabels.Add("Numero/Pareja");
            pivot.RowLabels.Add("idEmpleado");
            pivot.RowLabels.Add("LP");
            pivot.RowLabels.Add("Nombre empleado");

            // COLUMNAS =============================
            pivot.ColumnLabels.Add("Fecha");
            pivot.ColumnLabels.Add("Lote");
            pivot.ColumnLabels.Add("Rango");
            pivot.ColumnLabels.Add("Plantas totales");
            pivot.ColumnLabels.Add("Plantas activas");
            pivot.ColumnLabels.Add("Actividad");

            // VALORES =============================
            pivot.Values.Add("Cantidad").SetSummaryFormula(XLPivotSummary.Sum);
            pivot.SetLayout(XLPivotLayout.Tabular); //formato tabular
            pivot.ShowExpandCollapseButtons = false; //quitar botones de expandir y contraer

            wsPivotRanges.Columns().Width = 10.14;
            wsPivotRanges.Column("A").Width = 16.50;
            wsPivotRanges.Column("B").Width = 3.86;
            wsPivotRanges.Column("C").Width = 7.14;
            wsPivotRanges.Column("D").Width = 4.57;
            wsPivotRanges.Column("E").Width = 36.71;

            return wsPivotRanges;
        }

        private IXLWorksheet CreatePivotLotsWorksheet(XLWorkbook workbook, IXLWorksheet wsData)
        {
            var wsPivotLot = workbook.Worksheets.Add("POR LOTES");

            var dataRange = wsData.RangeUsed();

            var pivot = wsPivotLot.PivotTables.Add(
                "Pivot_Lote",
                wsPivotLot.Cell("A3"),
                dataRange
            );

            // FILAS =============================
            pivot.RowLabels.Add("Cuadrilla");
            pivot.RowLabels.Add("Numero/Pareja");
            pivot.RowLabels.Add("idEmpleado");
            pivot.RowLabels.Add("LP");
            pivot.RowLabels.Add("Nombre empleado");

            // COLUMNAS =============================
            pivot.ColumnLabels.Add("Fecha");
            pivot.ColumnLabels.Add("Lote");
            pivot.ColumnLabels.Add("Actividad");

            // VALORES =============================
            pivot.Values.Add("Cantidad").SetSummaryFormula(XLPivotSummary.Sum);
            pivot.SetLayout(XLPivotLayout.Tabular); //formato tabular
            pivot.ShowExpandCollapseButtons = false; //quitar botones de expandir y contraer

            wsPivotLot.Columns().Width = 10.14;
            wsPivotLot.Column("A").Width = 16.50;
            wsPivotLot.Column("B").Width = 3.86;
            wsPivotLot.Column("C").Width = 7.14;
            wsPivotLot.Column("D").Width = 4.57;
            wsPivotLot.Column("E").Width = 36.71;

            return wsPivotLot;
        }
    }
}
