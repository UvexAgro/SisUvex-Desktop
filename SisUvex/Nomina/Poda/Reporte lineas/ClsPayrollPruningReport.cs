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
                using (FileStream stream = new FileStream( filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
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

        private string? GetFolderPath(string fileReportName)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Guardar reporte de Excel";
                saveFileDialog.FileName = fileReportName;

                // Filtros de archivo
                saveFileDialog.Filter =
                    "Archivo de Excel (*.xlsx)|*.xlsx|" +
                    "Archivo de Excel 97-2003 (*.xls)|*.xls|" +
                    "Todos los archivos (*.*)|*.*";

                saveFileDialog.FilterIndex = 1; // Excel xlsx por defecto
                saveFileDialog.AddExtension = true;
                saveFileDialog.DefaultExt = "xlsx";
                saveFileDialog.OverwritePrompt = true;

                // Mostrar diálogo
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return saveFileDialog.FileName; // Ruta completa
                }
            }

            return null; // Usuario canceló
        }

        private string GetFileReportName()
        {
            string reportName = "Reporte_Poda";
            if (frm.cboWorkGroup.SelectedIndex > 0)
                reportName += $"_{frm.cboWorkGroup.GetColumnValue(WorkGroup.ColumnName)}";

            if (frm.cboLot.SelectedIndex > 0)
                reportName += $"_{frm.cboLot.GetColumnValue(Lot.ColumnName)}";

            return reportName += $"_{frm.dtpDate1.Value:yyyyMMdd}_a_{frm.dtpDate2.Value:yyyyMMdd}.xlsx";
        }

        public void GenerateExcelReportWithPivot()
        {
            //Cargar y verificar si hay datos del reporte
            DataTable data = GetDTDataReportQueryWithFilter();

            if (data == null || data.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para generar el reporte.");
                return;
            }

            //Escoger ruta con nombre de archivo, verificarla, sino se escogió se cancela
            string? filePath = GetFolderPath(GetFileReportName());

            if (filePath == null)
                return;

            if (IsFileLocked(filePath))
            {
                MessageBox.Show(
                    $"El archivo '{filePath}' está abierto.\n\n" +
                    "Ciérralo antes de generar el reporte.",
                    "Archivo en uso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            //Crear el objeto de excel y cada una de sus hojas; 1 hoja por método
            using (var workbook = new XLWorkbook())
            {
                var wsData = CreateDataWorksheet(workbook, data);
                var wsPivotRanges = CreatePivotLinesRangeWorksheet(workbook, wsData);
                var wsPivotLot = CreatePivotLotsWorksheet(workbook, wsData);

                workbook.SaveAs(filePath); //Crear el archivo en la ruta
            }

            //Mensaje de todo bien y abrir archivo
            DialogResult result = MessageBox.Show(
                "Reporte con tabla dinámica generado correctamente.\n\n" +
                "¿Deseas abrir el archivo?",
                "Reporte generado",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information
            );

            if (result == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = filePath,
                    UseShellExecute = true
                });
            }
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

        /////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////
        public void GenerateExcelReportFlat() // GENERAR REPORTE PLANO CON CELDAS, SIN TABLAS DINAMICAS
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, "Reporte_Poda_SinPivot.xlsx");

            if (IsFileLocked(filePath))
            {
                MessageBox.Show(
                    $"El archivo '{filePath}' está abierto.\n\nCiérralo antes de generar el reporte.",
                    "Archivo en uso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            DataTable dt = GetDTDataReportQueryWithFilter();
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos.");
                return;
            }

            using (var wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add("REPORTE");

                // =========================================
                // CONFIGURACIÓN BASE
                // =========================================
                int headerRow = 4;             // fila donde van encabezados de empleado y actividad
                int startRow = headerRow + 1;  // empleados empiezan justo abajo
                int startCol = 6;              // columna donde empiezan bloques dinámicos
                int headerCol = startCol - 1;  // columna a la izquierda del bloque (labels finales)

                // Colores
                var green = XLColor.FromHtml("#E2F0D9");  // Celdas con datos
                var blueGreen = XLColor.FromHtml("#31869B");  // Plantas activas
                var colorColumns = XLColor.FromHtml("#538DD5");
                var colorSubColumns = XLColor.FromHtml("#8DB4E2");

                #region ENCABEZADOS DATOS EMPLEADOS
                // =========================================
                // ENCABEZADOS FIJOS (EMPLEADOS)
                // =========================================
                ws.Cell(headerRow, 1).Value = "Cuadrilla";
                ws.Cell(headerRow, 2).Value = "N°";
                ws.Cell(headerRow, 3).Value = "Código";
                ws.Cell(headerRow, 4).Value = "LP";
                ws.Cell(headerRow, 5).Value = "Nombre empleado";
                #endregion

                #region BLOQUES ÚNICOS (COLUMNAS)  (Fecha/Lote/Rango/Actividad)
                // =========================================
                // BLOQUES ÚNICOS (COLUMNAS)  (Fecha/Lote/Rango/Actividad)
                // =========================================
                var bloques = dt.AsEnumerable()
                    .Select(r => new
                    {
                        Fecha = Convert.ToDateTime(r["Fecha"]).ToString("dd-MMM-yy"),
                        Lote = r["Lote"].ToString(),
                        Rango = r["Rango"].ToString(),
                        Actividad = r["Actividad"].ToString(),

                        // estos se usan al final (filas resumen)
                        PlantasTotales = r["Plantas totales"] != DBNull.Value ? Convert.ToDecimal(r["Plantas totales"]) : 0m,
                        PlantasActivas = r["Plantas activas"] != DBNull.Value ? Convert.ToDecimal(r["Plantas activas"]) : 0m
                    })
                    .Distinct()
                    .ToList();
                #endregion

                #region COLUMNAS ARRIBA fecha lote rango
                // =========================================
                // COLUMNAS DINÁMICAS (arriba: Fecha/Lote/Rango, y en headerRow: Actividad)
                // =========================================
                int col = startCol;

                foreach (var b in bloques)
                {
                    // Encabezado superior (3 filas)
                    ws.Cell(1, col).Value = b.Fecha;
                    ws.Cell(2, col).Value = b.Lote;
                    ws.Cell(3, col).Value = b.Rango;

                    // Actividad: va en la MISMA fila que los encabezados de empleado
                    ws.Cell(headerRow, col).Value = b.Actividad;

                    col++;
                }

                int lastCol = col - 1;
                //
                // TEXTO COLUMNAS PRINCIPALES
                //

                // Labels a la izquierda (columna headerCol)
                ws.Cell(1, headerCol).Value = "FECHA";
                ws.Cell(2, headerCol).Value = "LOTE";
                ws.Cell(3, headerCol).Value = "RANGO";
                #endregion

                #region FILAS EMPLEADOS 
                // =========================================
                // FILAS DE EMPLEADOS (valores de Cantidad por bloque)
                // =========================================
                int excelRow = startRow;

                var empleados = dt.AsEnumerable()
                    .GroupBy(r => new
                    {
                        Cuadrilla = r["Cuadrilla"].ToString(),
                        Numero = r["Numero/Pareja"].ToString(),
                        Id = r["idEmpleado"].ToString(),
                        LP = r["LP"].ToString(),
                        Nombre = r["Nombre empleado"].ToString()
                    });

                foreach (var emp in empleados)
                {
                    ws.Cell(excelRow, 1).Value = emp.Key.Cuadrilla;
                    ws.Cell(excelRow, 2).Value = emp.Key.Numero;
                    ws.Cell(excelRow, 3).Value = emp.Key.Id;
                    ws.Cell(excelRow, 4).Value = emp.Key.LP;
                    ws.Cell(excelRow, 5).Value = emp.Key.Nombre;

                    int actCol = startCol;

                    foreach (var b in bloques)
                    {
                        var fila = emp.FirstOrDefault(r =>
                            Convert.ToDateTime(r["Fecha"]).ToString("dd-MMM-yy") == b.Fecha && //Fecha como en la parte de arriba
                            r["Lote"].ToString() == b.Lote &&
                            r["Rango"].ToString() == b.Rango &&
                            r["Actividad"].ToString() == b.Actividad);

                        ws.Cell(excelRow, actCol).Value =
                            fila != null && fila["Cantidad"] != DBNull.Value
                            ? Convert.ToDecimal(fila["Cantidad"])
                            : 0m;

                        actCol++;
                    }

                    excelRow++;
                }

                int lastEmployeeRow = excelRow - 1;
                #endregion

                #region COLUMNAS FILAS RESUMEN FINAL
                // =========================================
                // FILAS RESUMEN AL FINAL (debajo de empleados)
                // =========================================

                int rowSumaCapturadas = lastEmployeeRow + 1;
                int rowPlantasActivas = rowSumaCapturadas + 1;
                int rowPlantasTotales = rowPlantasActivas + 1;
                int rowDiferencia = rowPlantasTotales + 1;

                // Labels a la izquierda (columna headerCol)
                ws.Cell(rowSumaCapturadas, headerCol).Value = "SUMA CAPTURADAS";
                ws.Cell(rowPlantasActivas, headerCol).Value = "PLANTAS ACTIVAS";
                ws.Cell(rowPlantasTotales, headerCol).Value = "PLANTAS TOTALES";
                ws.Cell(rowDiferencia, headerCol).Value = "DIFERENCIA";

                // Valores por columna + fórmulas
                int ccol = startCol;
                foreach (var b in bloques)
                {
                    // SUMA CAPTURADAS = suma de cantidades de empleados (columna)
                    ws.Cell(rowSumaCapturadas, ccol).FormulaA1 =
                        $"SUM({ws.Cell(startRow, ccol).Address}:{ws.Cell(lastEmployeeRow, ccol).Address})";

                    //PLANTAS ACTIVAS/ Activas (valores fijos)
                    ws.Cell(rowPlantasActivas, ccol).Value = b.PlantasActivas;

                    // DIFERENCIA = Activas - SumaCapturadas
                    ws.Cell(rowDiferencia, ccol).FormulaA1 =
                        $"{ws.Cell(rowPlantasActivas, ccol).Address}-{ws.Cell(rowSumaCapturadas, ccol).Address}";

                    // Plantas Totales / Activas (valores fijos)
                    ws.Cell(rowPlantasTotales, ccol).Value = b.PlantasTotales;

                    ccol++;
                }
                #endregion

                #region ESTÉTICA CELDAS, BORDES, AJUSTES, ETC.
                // =========================================
                // BORDES / ESTÉTICA
                //=========================================
                //Bordes interior en toda el área usada(incluye resumen final)
                int finalLastRow = rowSumaCapturadas-1;

                ////RANGO DE EMPLEADOS
                var rangeRmployeeInfo = ws.Range(startRow, 1, lastEmployeeRow, startCol - 1);
                rangeRmployeeInfo.Style.Border.OutsideBorder = XLBorderStyleValues.Medium;
                rangeRmployeeInfo.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                //RANGO DE VALORES CANTIDAD
                var rangeValues = ws.Range(startRow, startCol, lastEmployeeRow, lastCol);
                rangeValues.Style.Border.OutsideBorder = XLBorderStyleValues.Medium;
                rangeValues.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                rangeValues.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                //ENCABEZADOS EMPLEADOS
                var headerEmployee = ws.Range(headerRow, 1, headerRow, headerCol);
                headerEmployee.Style.Border.OutsideBorder = XLBorderStyleValues.Medium;
                headerEmployee.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                headerEmployee.Style.Font.SetBold()
                  .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                  .Fill.SetBackgroundColor(colorColumns);

                //ENCABEZADOS COLUMNAS FECHA/
                var headerColumns = ws.Range(1, headerCol, headerRow - 1, headerCol);
                headerColumns.Style.Border.OutsideBorder = XLBorderStyleValues.Medium;
                headerColumns.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                headerColumns.Style.Font.SetBold()
                  .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right)
                  .Fill.SetBackgroundColor(colorColumns);

                //COLUMNAS BLOQUES DINAMICOS
                var dinamicColumRange = ws.Range(1, startCol, headerRow, lastCol);
                dinamicColumRange.Style.Border.OutsideBorder = XLBorderStyleValues.Medium;
                dinamicColumRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                dinamicColumRange.Style.Font.SetBold()
                  .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                  .Fill.SetBackgroundColor(colorSubColumns);

                //TOTALES DEBAJO DE TABLA
                var totalsRange = ws.Range(rowSumaCapturadas, startCol, rowDiferencia, lastCol);
                totalsRange.Style.Border.OutsideBorder = XLBorderStyleValues.Medium;
                totalsRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                totalsRange.Style.Fill.BackgroundColor = colorSubColumns;
                

                //ENCABEZADOS COLUMNAS TOTALES DEBAJO DE TABLA
                var headerTotalsRange = ws.Range(rowSumaCapturadas, headerCol, rowDiferencia, headerCol);
                headerTotalsRange.Style.Border.OutsideBorder = XLBorderStyleValues.Medium;
                headerTotalsRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                headerTotalsRange.Style.Font.SetBold()
                  .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right)
                  .Fill.SetBackgroundColor(colorColumns);

                //COLOR VERDE AZUL EN FILA DE PLANTAS ACTIVAS PARA RESALTARLAS
                ws.Range(rowPlantasActivas, headerCol, rowPlantasActivas, lastCol).Style.Fill.BackgroundColor = blueGreen;

                // Congelar: arriba hasta el headerRow, y a la izquierda hasta Nombre empleado
                //ws.SheetView.FreezeRows(headerRow);
                //ws.SheetView.FreezeColumns(5);

                // Ajustes de columnas
                ws.Columns().AdjustToContents();
                ws.Column(2).Width = 3.43;
                ws.Column(3).Width = 6.45;

                // Color verde a celdas con cantidad > 0 (solo zona de cantidades)
                ws.Range(startRow, startCol, lastEmployeeRow, lastCol)
                  .CellsUsed(c => c.DataType == XLDataType.Number && c.GetValue<double>() > 0)
                  .Style.Fill.SetBackgroundColor(green);
                #endregion

                // =========================================
                // GUARDAR Y ABRIR
                // =========================================
                wb.SaveAs(filePath);

                MessageBox.Show("Reporte generado correctamente.");

                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = filePath,
                    UseShellExecute = true
                });
            }
        }

    }
}

