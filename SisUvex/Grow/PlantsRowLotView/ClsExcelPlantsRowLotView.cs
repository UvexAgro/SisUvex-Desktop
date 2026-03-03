using ClosedXML.Excel;
using SisUvex.Catalogos.Metods.ExcelLoad;
using SisUvex.Catalogos.Metods.Querys;
using System.Data;
using System.IO;
using System.Windows.Forms;
using static SisUvex.Catalogos.Metods.ClsObject;

namespace SisUvex.Grow.PlantsRowLot
{
    internal class ClsExcelPlantsRowLotView
    {
        // Constantes para nombres de columnas
        const string cIdVariety = Variety.ColumnId;
        const string cVariety = Variety.ColumnName;
        const string cIdFormation = "idFormation";
        const string cFormation = "Tipo Formación";
        const string cIdRootStock = "idPatron";
        const string cRootStock = "Patron";
        const string cUserUpdate = "Modificó";
        const string cDateUpdate = "Última modificación";
        const string cIdLot = Lot.ColumnId;
        const string cLotName = Lot.ColumnName;
        const string cIdCultivo = Crop.ColumnId;
        const string cCultivo = Crop.ColumnName;

        // Colores para formato
        private readonly XLColor colorColumns = XLColor.FromHtml("#538DD5");
        private readonly XLColor colorSubColumns = XLColor.FromHtml("#8DB4E2");

        /// <summary>
        /// Método principal para generar el reporte Excel
        /// </summary>
        public void GenerateExcelReport(DataView dvPlants, string idLot, string lotName)
        {
            // Validar datos
            if (dvPlants == null || dvPlants.Count == 0)
            {
                MessageBox.Show("No hay datos para generar el reporte.", "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrWhiteSpace(idLot))
            {
                MessageBox.Show("Debe seleccionar un lote.", "Lote requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener ruta y nombre de archivo
            string fileName = GetFileReportName(lotName);
            string? filePath = GetFolderPath(fileName);

            if (filePath == null)
                return; // Usuario canceló

            // Verificar si el archivo está abierto
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

            // Crear workbook y hoja
            using (var workbook = new XLWorkbook())
            {
                var ws = CreateLotWorksheet(workbook, dvPlants, idLot, lotName);
                
                workbook.SaveAs(filePath);
            }

            // Mensaje de éxito y opción de abrir
            DialogResult result = MessageBox.Show(
                "Reporte en excel generado correctamente.\n\n" +
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

        /// <summary>
        /// Crea una hoja de Excel para un lote específico
        /// </summary>
        private IXLWorksheet CreateLotWorksheet(XLWorkbook workbook, DataView dvPlants, string idLot, string lotName)
        {
            // Sanitizar nombre de hoja (Excel tiene límites de caracteres y caracteres prohibidos)
            string sheetName = SanitizeSheetName(lotName);
            if (string.IsNullOrWhiteSpace(sheetName))
                sheetName = $"Lote_{idLot}";

            var ws = workbook.Worksheets.Add(sheetName);

            // Coordenadas configurables para la primera tabla
            int firstTableStartRow = 2;  // Fila 2
            int firstTableStartCol = 2; // Columna B (2)

            // Crear primera tabla (datos de plantas)
            int firstTableEndCol = CreatePlantsTable(ws, dvPlants, firstTableStartRow, firstTableStartCol, idLot, lotName);

            // Crear segunda tabla (resumen por cultivo) - 2 celdas a la derecha de la primera tabla
            int summaryTableStartCol = firstTableEndCol + 2;
            CreateSummaryTablesByCrop(ws, idLot, summaryTableStartCol, firstTableStartRow);

            // Ajustar columnas al contenido
            ws.Columns().AdjustToContents();

            return ws;
        }

        /// <summary>
        /// Crea la primera tabla con datos de plantas
        /// </summary>
        private int CreatePlantsTable(IXLWorksheet ws, DataView dvPlants, int startRow, int startCol, string idLot, string lotName)
        {
            // Obtener columnas visibles (excluir las que están en ListColumnsToHidePlantsTable)
            var columnsToHide = ListColumnsToHidePlantsTable();
            var visibleColumns = dvPlants.Table.Columns.Cast<DataColumn>()
                .Where(col => !columnsToHide.Contains(col.ColumnName))
                .ToList();

            if (visibleColumns.Count == 0)
            {
                return startCol; // No hay columnas visibles
            }

            int currentCol = startCol;
            int headerRow = startRow + 1; // Fila del título + 1 para encabezados
            int dataStartRow = headerRow + 1; // Fila donde empiezan los datos

            // Título combinado arriba de la tabla
            string title = $"{lotName} ({idLot})";
            int titleRow = startRow;
            int titleStartCol = startCol;
            int titleEndCol = startCol + visibleColumns.Count - 1;

            ws.Range(titleRow, titleStartCol, titleRow, titleEndCol).Merge();
            ws.Cell(titleRow, titleStartCol).Value = title;
            ws.Cell(titleRow, titleStartCol).Style.Font.SetBold();
            ws.Cell(titleRow, titleStartCol).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            ws.Cell(titleRow, titleStartCol).Style.Fill.SetBackgroundColor(colorColumns);

            // Escribir encabezados
            foreach (var column in visibleColumns)
            {
                ws.Cell(headerRow, currentCol).Value = column.ColumnName;
                currentCol++;
            }

            int lastCol = currentCol - 1;

            // Escribir datos
            int currentRow = dataStartRow;
            foreach (DataRowView rowView in dvPlants)
            {
                currentCol = startCol;
                foreach (var column in visibleColumns)
                {
                    object? value = rowView[column.ColumnName];
                    ClsExcel.SetCellValue(ws.Cell(currentRow, currentCol), value);
                    currentCol++;
                }
                currentRow++;
            }

            int lastRow = currentRow - 1;

            // Aplicar formato
            ApplyTableFormatting(ws, ws.Range(titleRow, titleStartCol, titleRow, titleEndCol), true, true);
            ApplyTableFormatting(ws, ws.Range(headerRow, startCol, headerRow, lastCol), true, false);
            ApplyTableFormatting(ws, ws.Range(dataStartRow, startCol, lastRow, lastCol), false, false);

            return lastCol;
        }

        /// <summary>
        /// Crea tablas de resumen agrupadas por cultivo
        /// </summary>
        private void CreateSummaryTablesByCrop(IXLWorksheet ws, string idLot, int startCol, int startRow)
        {
            // Obtener datos de resumen
            DataTable dtSummary = ClsQuerysDB.GetDataTable(GetQueryTotalLot2(idLot));

            if (dtSummary == null || dtSummary.Rows.Count == 0)
                return;

            // Obtener columnas visibles
            var columnsToHide = ListColumnsToHideSummaryTable();
            var visibleColumns = dtSummary.Columns.Cast<DataColumn>()
                .Where(col => !columnsToHide.Contains(col.ColumnName))
                .ToList();

            if (visibleColumns.Count == 0)
                return;

            // Agrupar por cultivo
            var crops = dtSummary.AsEnumerable()
                .GroupBy(r => r[cCultivo]?.ToString() ?? "")
                .Where(g => !string.IsNullOrWhiteSpace(g.Key))
                .OrderBy(g => g.Key)
                .ToList();

            if (crops.Count == 0)
                return;

            int currentStartRow = startRow;
            int tableStartCol = startCol;

            foreach (var cropGroup in crops)
            {
                string cropName = cropGroup.Key;
                var cropRows = cropGroup.ToList();

                // Título combinado para el cultivo
                int titleRow = currentStartRow;
                int titleStartCol = tableStartCol;
                int titleEndCol = tableStartCol + visibleColumns.Count - 1;

                ws.Range(titleRow, titleStartCol, titleRow, titleEndCol).Merge();
                ws.Cell(titleRow, titleStartCol).Value = cropName;
                ws.Cell(titleRow, titleStartCol).Style.Font.SetBold();
                ws.Cell(titleRow, titleStartCol).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                ws.Cell(titleRow, titleStartCol).Style.Fill.SetBackgroundColor(colorColumns);

                // Encabezados
                int headerRow = titleRow + 1;
                int currentCol = tableStartCol;
                foreach (var column in visibleColumns)
                {
                    ws.Cell(headerRow, currentCol).Value = column.ColumnName;
                    currentCol++;
                }
                int lastCol = currentCol - 1;

                // Datos
                int dataStartRow = headerRow + 1;
                int currentDataRow = dataStartRow;
                foreach (var row in cropRows)
                {
                    currentCol = tableStartCol;
                    foreach (var column in visibleColumns)
                    {
                        object? value = row[column.ColumnName];
                        // Inicio y Final como número para que MIN/MAX funcionen en la fila de totales
                        if ((column.ColumnName == "Inicio" || column.ColumnName == "Final") && value != null && value != DBNull.Value)
                        {
                            if (value is int || value is long || value is double || value is decimal || value is float)
                            {
                                ClsExcel.SetCellValue(ws.Cell(currentDataRow, currentCol), value);
                            }
                            else if (double.TryParse(value.ToString(), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double num))
                            {
                                ws.Cell(currentDataRow, currentCol).Value = num;
                            }
                            else
                            {
                                ClsExcel.SetCellValue(ws.Cell(currentDataRow, currentCol), value);
                            }
                        }
                        else
                        {
                            ClsExcel.SetCellValue(ws.Cell(currentDataRow, currentCol), value);
                        }
                        currentCol++;
                    }
                    currentDataRow++;
                }
                int lastDataRow = currentDataRow - 1;

                // Fila de totales
                int totalRow = lastDataRow + 1;
                ws.Cell(totalRow, tableStartCol).Value = "Objetivo";
                ws.Cell(totalRow, tableStartCol).Style.Font.SetBold();

                // Calcular totales para columnas numéricas; Inicio = MIN, Final = MAX
                int totalColIndex = 0;
                foreach (var column in visibleColumns)
                {
                    int colNum = tableStartCol + totalColIndex;
                    if (column.ColumnName == "Inicio")
                    {
                        ws.Cell(totalRow, colNum).FormulaA1 = $"MIN({ws.Cell(dataStartRow, colNum).Address}:{ws.Cell(lastDataRow, colNum).Address})";
                        ws.Cell(totalRow, colNum).Style.Font.SetBold();
                    }
                    else if (column.ColumnName == "Final")
                    {
                        ws.Cell(totalRow, colNum).FormulaA1 = $"MAX({ws.Cell(dataStartRow, colNum).Address}:{ws.Cell(lastDataRow, colNum).Address})";
                        ws.Cell(totalRow, colNum).Style.Font.SetBold();
                    }
                    else if (column.ColumnName == "Objetivo" || column.ColumnName == "Activas" ||
                        column.ColumnName == "Fallas" || column.ColumnName == "Formación")
                    {
                        ws.Cell(totalRow, colNum).FormulaA1 = $"SUM({ws.Cell(dataStartRow, colNum).Address}:{ws.Cell(lastDataRow, colNum).Address})";
                        ws.Cell(totalRow, colNum).Style.Font.SetBold();
                    }
                    totalColIndex++;
                }

                int lastTotalRow = totalRow;

                // Aplicar formato
                ApplyTableFormatting(ws, ws.Range(titleRow, titleStartCol, titleRow, titleEndCol), true, true);
                ApplyTableFormatting(ws, ws.Range(headerRow, tableStartCol, headerRow, lastCol), true, false);
                ApplyTableFormatting(ws, ws.Range(dataStartRow, tableStartCol, lastDataRow, lastCol), false, false);
                ApplyTableFormatting(ws, ws.Range(totalRow, tableStartCol, totalRow, lastCol), false, false);
                ws.Range(totalRow, tableStartCol, totalRow, lastCol).Style.Fill.SetBackgroundColor(colorSubColumns);

                // Actualizar posición para la siguiente tabla (2 filas de separación)
                currentStartRow = lastTotalRow + 2;
            }
        }

        /// <summary>
        /// Lista de columnas a ocultar en la primera tabla (comentar líneas para mostrar)
        /// </summary>
        private List<string> ListColumnsToHidePlantsTable()
        {
            List<string> values = new List<string>();

            values.Add(cIdFormation);
            //values.Add(cFormation);
            values.Add(cIdRootStock);
            //values.Add(cRootStock);
            values.Add(cIdVariety);
            //values.Add(cVariety);
            values.Add(cUserUpdate);
            values.Add(cDateUpdate);
            values.Add(cIdLot);
            values.Add(cLotName);
            values.Add(cIdCultivo);
            values.Add(cCultivo);

            return values;
        }

        /// <summary>
        /// Lista de columnas a ocultar en las tablas de resumen (comentar líneas para mostrar)
        /// </summary>
        private List<string> ListColumnsToHideSummaryTable()
        {
            List<string> values = new List<string>();

            // Por defecto todas las columnas son visibles, agregar aquí las que se quieran ocultar
            // Ejemplo:
            // values.Add("U. Actualización");
            // values.Add("Usuario");

            return values;
        }

        /// <summary>
        /// Aplica formato consistente a un rango de celdas
        /// </summary>
        private void ApplyTableFormatting(IXLWorksheet ws, IXLRange range, bool isHeader, bool isTitle)
        {
            // Bordes externos gruesos
            range.Style.Border.OutsideBorder = XLBorderStyleValues.Medium;
            
            // Bordes internos delgados
            range.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

            if (isHeader || isTitle)
            {
                // Negritas para encabezados y títulos
                range.Style.Font.SetBold();
                
                // Fondo más oscuro para encabezados
                if (isTitle)
                    range.Style.Fill.SetBackgroundColor(colorColumns);
                else
                    range.Style.Fill.SetBackgroundColor(colorSubColumns);
                
                // Centrar texto en encabezados
                range.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            }
        }

        /// <summary>
        /// Obtiene la consulta SQL para los totales del lote
        /// </summary>
        private string GetQueryTotalLot2(string idLot)
        {
            return @$"SELECT
                            crop.v_nameCrop                 AS [{cCultivo}],
                            vrt.v_nameComercial             AS [{cVariety}],
                            MIN(T.n_lotLine)                AS [Inicio],
                            MAX(T.n_lotLine)                AS [Final],
                            SUM(T.n_plannedPlants)          AS [Objetivo],
                            SUM(T.n_actualPlants)           AS [Activas],
                            SUM(T.n_failedPlants)           AS [Fallas],
                            SUM(T.n_formationStagePlants)   AS [Formación],
                            FORMAT(MAX(ISNULL(T.d_update, T.d_create)), 'dd-MM-yyyy') AS [U. Actualización],
                            U.LastUser                      AS [Usuario]
                        FROM Grow_PlantsRowLot T
                            LEFT JOIN Pack_Variety vrt ON vrt.id_variety = T.id_variety
                            LEFT JOIN Pack_Crop crop ON crop.id_crop = vrt.id_crop

                        --
                        OUTER APPLY
                        (
                            SELECT TOP 1 ISNULL(userUpdate, userCreate) AS LastUser
                            FROM Grow_PlantsRowLot
                            WHERE id_lot = T.id_lot
                            ORDER BY ISNULL(d_update, d_create) DESC
                        ) U

                        WHERE T.id_lot = '{idLot}'

                        GROUP BY T.id_lot, U.LastUser, crop.v_nameCrop, vrt.v_nameComercial
                        
                        ORDER BY Inicio;";
        }

        /// <summary>
        /// Obtiene el nombre del archivo para el reporte
        /// </summary>
        private string GetFileReportName(string lotName)
        {
            string reportName = "Plantas Lote ";
            if (!string.IsNullOrWhiteSpace(lotName))
            {
                // Sanitizar nombre de lote para nombre de archivo
                string safeLotName = System.Text.RegularExpressions.Regex.Replace(lotName, @"[^\w\s-]", "");
                //safeLotName = safeLotName.Replace(" ", "_");
                reportName += $" {safeLotName}";
            }
            //reportName += $"_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
            reportName += $".xlsx";
            return reportName;
        }

        /// <summary>
        /// Muestra diálogo para seleccionar ruta y nombre de archivo
        /// </summary>
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

        /// <summary>
        /// Verifica si un archivo está abierto/bloqueado
        /// </summary>
        private bool IsFileLocked(string filePath)
        {
            if (!File.Exists(filePath))
                return false;

            try
            {
                using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
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

        /// <summary>
        /// Sanitiza el nombre de la hoja para Excel (máximo 31 caracteres, sin caracteres prohibidos)
        /// </summary>
        private string SanitizeSheetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return "Hoja1";

            // Caracteres prohibidos en nombres de hojas de Excel: \ / ? * [ ]
            string sanitized = System.Text.RegularExpressions.Regex.Replace(name, @"[\\\/\?\*\[\]]", "_");
            
            // Limitar a 31 caracteres (límite de Excel)
            if (sanitized.Length > 31)
                sanitized = sanitized.Substring(0, 31);

            return sanitized.Trim();
        }
    }
}
