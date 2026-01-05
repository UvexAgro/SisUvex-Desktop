using SisUvex.Catalogos.Metods.Querys;
using System;
using System.Data;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.XSSF.UserModel.Helpers;

namespace SisUvex.Nomina.Poda.Reporte_lineas
{
    internal class ClsPayrollPruningReport
    {
        string queryReport1 = @"SELECT * FROM vw_PayrollPiece_BoxPerNumber_Info ORDER BY FECHA";

        // =============================
        // METODO DE EJEMPLO (QUERY)
        // =============================
        private DataTable GetDataReport()
        {
            // AQUÍ VA TU QUERY REAL A SQL SERVER
            // return ClsQuerysDB.ExecuteParameterizedQuery(queryReport1);
            return ClsQuerysDB.GetDataTable(queryReport1);

            // EJEMPLO TEMPORAL
            DataTable dt = new DataTable();
            dt.Columns.Add("Empleado");
            dt.Columns.Add("Linea");
            dt.Columns.Add("Cantidad", typeof(int));

            dt.Rows.Add("Juan", "L-01", 120);
            dt.Rows.Add("Maria", "L-02", 95);
            dt.Rows.Add("Pedro", "L-03", 110);

            return dt;
        }

        // =============================
        // CREAR WORKBOOK Y HOJA
        // =============================
        private XSSFWorkbook CreateWorkbookWithData(DataTable data)
        {
            XSSFWorkbook workbook = new XSSFWorkbook();
            XSSFSheet sheet = (XSSFSheet)workbook.CreateSheet("DATOS");


            var styles = CreateStyles(workbook);


            CreateHeader(sheet, data);
            FillData(sheet, data, styles);
            CreateExcelTable(sheet, data);
            AutoSizeColumns(sheet, data.Columns.Count);


            return workbook;
        }

        // =============================
        // CREAR ESTILOS
        // =============================
        private (ICellStyle DateStyle, ICellStyle NumberStyle) CreateStyles(XSSFWorkbook workbook)
        {
            IDataFormat dataFormat = workbook.CreateDataFormat();


            ICellStyle dateStyle = workbook.CreateCellStyle();
            dateStyle.DataFormat = dataFormat.GetFormat("dd/MM/yyyy");


            ICellStyle numberStyle = workbook.CreateCellStyle();
            numberStyle.DataFormat = dataFormat.GetFormat("#,##0.############;0");


            return (dateStyle, numberStyle);
        }

        // =============================
        // ENCABEZADOS
        // =============================
        private void CreateHeader(ISheet sheet, DataTable data)
        {
            IRow headerRow = sheet.CreateRow(0);


            for (int col = 0; col < data.Columns.Count; col++)
            {
                headerRow.CreateCell(col).SetCellValue(data.Columns[col].ColumnName);
            }
        }

        // =============================
        // LLENAR DATOS
        // =============================
        private void FillData(ISheet sheet, DataTable data,
        (ICellStyle DateStyle, ICellStyle NumberStyle) styles)
        {
            for (int row = 0; row < data.Rows.Count; row++)
            {
                IRow excelRow = sheet.CreateRow(row + 1);


                for (int col = 0; col < data.Columns.Count; col++)
                {
                    string columnName = data.Columns[col].ColumnName;
                    object value = data.Rows[row][col];


                    ICell cell = excelRow.CreateCell(col);


                    if (value == DBNull.Value)
                    {
                        cell.SetCellValue(string.Empty);
                        continue;
                    }


                    if (columnName == "Fecha" && DateTime.TryParse(value.ToString(), out DateTime fecha))
                    {
                        cell.SetCellValue(fecha);
                        cell.CellStyle = styles.DateStyle;
                    }
                    else if (
                        columnName == "Cantidad" ||
                        columnName == "Plantas disponibles x linea" ||
                        columnName == "Plantas totales" ||
                        columnName == "Plantas activas"
                    )
                    {
                        if (double.TryParse(value.ToString(), out double numero))
                        {
                            cell.SetCellValue(numero);
                            //cell.CellStyle = styles.NumberStyle;
                        }
                        else
                        {
                            cell.SetCellValue(value.ToString());
                        }
                    }
                    else
                    {
                        cell.SetCellValue(value.ToString());
                    }
                }
            }
        }

        // =============================
        // TABLA DE EXCEL
        // =============================
        private void CreateExcelTable(XSSFSheet sheet, DataTable data)
        {
            var table = sheet.CreateTable();
            table.DisplayName = "DATOS_TABLE";
            table.Name = "DATOS_TABLE";


            var ctTable = table.GetCTTable();
            ctTable.@ref = $"A1:{(char)('A' + data.Columns.Count - 1)}{data.Rows.Count + 1}";


            ctTable.tableColumns = new NPOI.OpenXmlFormats.Spreadsheet.CT_TableColumns
            {
                count = (uint)data.Columns.Count,
                tableColumn = new List<NPOI.OpenXmlFormats.Spreadsheet.CT_TableColumn>()
            };


            for (uint i = 0; i < data.Columns.Count; i++)
            {
                ctTable.tableColumns.tableColumn.Add(new NPOI.OpenXmlFormats.Spreadsheet.CT_TableColumn
                {
                    id = i + 1,
                    name = data.Columns[(int)i].ColumnName
                });
            }


            ctTable.tableStyleInfo = new NPOI.OpenXmlFormats.Spreadsheet.CT_TableStyleInfo
            {
                name = "TableStyleMedium2",
                showRowStripes = true,
                showColumnStripes = false
            };
        }

        // =============================
        // AUTO AJUSTE DE COLUMNAS
        // =============================
        private void AutoSizeColumns(ISheet sheet, int columnCount)
        {
            for (int i = 0; i < columnCount; i++)
            {
                sheet.AutoSizeColumn(i);
            }
        }

        // =============================
        // GUARDAR EXCEL EN ESCRITORIO
        // =============================
        public void GenerateExcelReport()
        {
            try
            {

                // =============================
                // VALIDAR SI EL ARCHIVO ESTÁ EN USO ANTES QUE OTRAS COSAS
                // =============================

                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string filePath = Path.Combine(desktopPath, "Reporte_Poda.xlsx");

                if (IsFileLocked(filePath))
                {
                    System.Windows.Forms.MessageBox.Show(
                        "El archivo 'Reporte_Poda.xlsx' está abierto.\n\n" +
                        "Ciérralo antes de generar el reporte.",
                        "Archivo en uso",
                        System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Warning
                    );
                    return;
                }

                DataTable data = GetDataReport();

                if (data == null || data.Rows.Count == 0)
                {
                    System.Windows.Forms.MessageBox.Show(
                        "No hay datos para generar el reporte.",
                        "Reporte vacío",
                        System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Warning
                    );
                    return;
                }

                XSSFWorkbook workbook = CreateWorkbookWithData(data);

                //CREAR EL ARCHIVO
                using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    workbook.Write(fs);
                }

                // =============================
                // MENSAJE DE ÉXITO
                // =============================
                System.Windows.Forms.MessageBox.Show(
                    "El reporte se generó correctamente en el Escritorio.",
                    "Reporte generado",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                // =============================
                // MENSAJE DE ERROR GENERAL
                // =============================
                System.Windows.Forms.MessageBox.Show(
                    $"Ocurrió un error al generar el reporte:\n\n{ex.Message}",
                    "Error",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error
                );
            }
        }
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

    }
}
