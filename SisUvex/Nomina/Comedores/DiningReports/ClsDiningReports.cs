using ClosedXML.Excel;
using DocumentFormat.OpenXml.Presentation;
using Microsoft.IdentityModel.Tokens;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Catalogos.Metods.TextBoxes;
using SisUvex.Catalogos.Metods.Values;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Nomina.Comedores.DiningReports
{
    internal class ClsDiningReports
    {
        public FrmDiningReport frm;
        public DataTable? dtReport1, dtResume1, dtReportColumnDays;
        string queryReport1 = " DECLARE @DesayunoHora TIME, @ComidaHora TIME, @CenaHora TIME;\r\n\r\n-- Obtener los horarios desde Conf_Parameters\r\nSELECT @DesayunoHora = v_valueParameters \r\nFROM Conf_Parameters \r\nWHERE id_typeParameter = '01' AND id_parameter = '011';\r\n\r\nSELECT @ComidaHora = v_valueParameters \r\nFROM Conf_Parameters \r\nWHERE id_typeParameter = '01' AND id_parameter = '012';\r\n\r\nSELECT @CenaHora = v_valueParameters \r\nFROM Conf_Parameters \r\nWHERE id_typeParameter = '01' AND id_parameter = '013';\r\n\r\n-- Consulta principal con lógica ajustada\r\nSELECT \r\n    fdr.c_codigo_emp AS 'ID', \r\n    CONCAT_WS(' ', emp.v_lastNamePat, emp.v_lastNameMat, emp.v_name) AS 'Nombre', \r\n    lp.id_placePayment AS 'LP', \r\n    dpr.v_nameDinerProvider AS 'Comedor', \r\n    FORMAT(fdr.d_datetime, 'yyyy-MM-dd') AS 'Fecha', \r\n    COUNT(fdr.c_servedAgain) AS 'Total', \r\n    SUM(CASE \r\n            WHEN fdr.d_time >= @DesayunoHora \r\n             AND fdr.d_time < @ComidaHora THEN 1 \r\n            ELSE 0 \r\n        END) AS 'Desayuno',\r\n    SUM(CASE \r\n            WHEN fdr.d_time >= @ComidaHora \r\n             AND fdr.d_time < @CenaHora THEN 1 \r\n            ELSE 0 \r\n        END) AS 'Comida',\r\n    SUM(CASE \r\n            WHEN fdr.d_time >= @CenaHora \r\n             OR fdr.d_time < @DesayunoHora THEN 1  -- Si es después de la Cena o antes del Desayuno, es Cena\r\n            ELSE 0 \r\n        END) AS 'Cena'\r\nFROM Nom_FoodRegister fdr\r\nLEFT JOIN Nom_Employees emp ON emp.id_employee = fdr.c_codigo_emp \r\nLEFT JOIN Nom_DiningHall dhl ON dhl.id_dinningHall = fdr.id_dinningHall \r\nLEFT JOIN Nom_DinerProvider dpr ON dpr.id_dinerProvider = fdr.id_dinerProvider \r\nLEFT JOIN Nom_PlacePayment lp ON lp.id_placePayment = emp.id_paymentPlace ";
        string groupByReport1 = " GROUP BY fdr.c_codigo_emp, emp.v_lastNamePat, emp.v_lastNameMat, emp.v_name, lp.id_placePayment, fdr.d_datetime, dpr.v_nameDinerProvider ";
        string whereQuery1 = " WHERE ";

        string queryReportResume = @" DECLARE @DesayunoHora TIME, @ComidaHora TIME, @CenaHora TIME; SELECT @DesayunoHora = v_valueParameters  FROM Conf_Parameters  WHERE id_typeParameter = '01' AND id_parameter = '011';  SELECT @ComidaHora = v_valueParameters  FROM Conf_Parameters  WHERE id_typeParameter = '01' AND id_parameter = '012';  SELECT @CenaHora = v_valueParameters  FROM Conf_Parameters  WHERE id_typeParameter = '01' AND id_parameter = '013'; SELECT  dpr.v_nameDinerProvider AS 'COMEDOR', FORMAT(fdr.d_datetime, 'yyyy-MM-dd, dddd', 'es-ES') AS 'Fecha', lp.id_placePayment AS 'LP', CASE  WHEN fdr.d_time >= @DesayunoHora AND fdr.d_time < @ComidaHora THEN 'Desayuno' WHEN fdr.d_time >= @ComidaHora AND fdr.d_time < @CenaHora THEN 'Comida' WHEN fdr.d_time >= @CenaHora OR fdr.d_time < @DesayunoHora THEN 'Cena'     END AS 'T. Comida',     COUNT(fdr.c_codigo_emp) AS 'Trabajadores' FROM Nom_FoodRegister fdr LEFT JOIN Nom_Employees emp ON emp.id_employee = fdr.c_codigo_emp LEFT JOIN Nom_DiningHall dhl ON dhl.id_dinningHall = fdr.id_dinningHall LEFT JOIN Nom_DinerProvider dpr ON dpr.id_dinerProvider = fdr.id_dinerProvider LEFT JOIN Nom_PlacePayment lp ON lp.id_placePayment = emp.id_paymentPlace ";
        string groupByResume = " GROUP BY \r\n    dpr.v_nameDinerProvider, \r\n    lp.id_placePayment, \r\n    FORMAT(fdr.d_datetime, 'yyyy-MM-dd, dddd', 'es-ES'),\r\n    CASE \r\n        WHEN fdr.d_time >= @DesayunoHora AND fdr.d_time < @ComidaHora THEN 'Desayuno'\r\n        WHEN fdr.d_time >= @ComidaHora AND fdr.d_time < @CenaHora THEN 'Comida'\r\n        WHEN fdr.d_time >= @CenaHora OR fdr.d_time < @DesayunoHora THEN 'Cena'\r\n    END; ";


        string? breakfastTime = null, lunchTime = null, dinnerTime = null;

        public void LoadForm()
        {
            DataTable dtPlacePayment = ClsQuerysDB.GetDataTable(ClsObject.PlacePayment.QueryCbo);

            if (dtPlacePayment == null || dtPlacePayment.Rows.Count == 0)
                return;

            // Insertar la fila especial en el índice 1 (PARA QUE SE PUEDAN SELECCIONAR LOS EMPLEADOS QUE AUN NO SE LE HA ASIGNADO UN LUGAR DE TRABAJO)
            DataRow newRow = dtPlacePayment.NewRow();
            newRow[ClsObject.Column.id] = null;
            newRow[ClsObject.Column.active] = "1";
            newRow[ClsObject.Column.name] = "*Sin lugar de pago*";
            dtPlacePayment.Rows.InsertAt(newRow, 0);

            dtPlacePayment.DefaultView.RowFilter = $"{ClsObject.Column.active} = '1'";
            ClsComboBoxes.LoadComboBoxDataSource(frm.cboPaymentPlace, dtPlacePayment);

            DataTable dtProvider = ClsQuerysDB.GetDataTable(ClsObject.DinerProvider.QueryCbo);
            dtProvider.DefaultView.RowFilter = $"{ClsObject.Column.active} = '1'";
            ClsComboBoxes.LoadComboBoxDataSource(frm.cboDinerProvider, dtProvider);
        }

        public void SetDGVReportBeetweenDays()
        {
            Dictionary<string, object?> dicDateTables = new();

            string where = " WHERE fdr.d_datetime BETWEEN @Day1 AND @Day2 ";
            dicDateTables.Add("@Day1", frm.dtpDate1.Value.ToString("yyyy-MM-dd"));
            dicDateTables.Add("@Day2", frm.dtpDate2.Value.ToString("yyyy-MM-dd"));

            if (frm.cboDinerProvider.SelectedIndex > 0)
            {
                where += " AND fdr.id_dinerProvider = @DinerProvider ";
                dicDateTables.Add("@DinerProvider", frm.cboDinerProvider.SelectedValue);
            }

            if (frm.cboPaymentPlace.SelectedIndex > 0)
            {
                if (frm.cboPaymentPlace.SelectedValue.ToString().IsNullOrEmpty())
                {
                    where += " AND emp.id_paymentPlace IS NULL ";
                }
                else
                {
                    where += " AND emp.id_paymentPlace = @PaymentPlace ";
                    dicDateTables.Add("@PaymentPlace", frm.cboPaymentPlace.SelectedValue);
                }
            }

            dtReport1 = ClsQuerysDB.ExecuteParameterizedQuery(queryReport1 + where + groupByReport1, dicDateTables);
        }

        public void SetDGVEmployeeReportBeetweenDays()
        {
            string where = whereQuery1 + $" fdr.d_datetime BETWEEN '{GetDay1()}' AND '{GetDay2()}' AND fdr.c_codigo_emp = '{frm.txbIdEmployee.Text}' ";

            dtReport1 = ClsQuerysDB.GetDataTable(queryReport1 + where + groupByReport1);
        }
        public void SetDGVResume()
        {
            Dictionary<string, object?> dicDateTables = new();

            string where = " WHERE fdr.d_datetime BETWEEN @Day1 AND @Day2 ";
            dicDateTables.Add("@Day1", frm.dtpDate1.Value.ToString("yyyy-MM-dd"));
            dicDateTables.Add("@Day2", frm.dtpDate2.Value.ToString("yyyy-MM-dd"));

            if (frm.cboDinerProvider.SelectedIndex > 0)
            {
                where += " AND fdr.id_dinerProvider = @DinerProvider ";
                dicDateTables.Add("@DinerProvider", frm.cboDinerProvider.SelectedValue);
            }

            if (frm.cboPaymentPlace.SelectedIndex > 0)
            {
                if (frm.cboPaymentPlace.SelectedValue.ToString().IsNullOrEmpty())
                {
                    where += " AND emp.id_paymentPlace IS NULL ";
                }
                else
                {
                    where += " AND emp.id_paymentPlace = @PaymentPlace ";
                    dicDateTables.Add("@PaymentPlace", frm.cboPaymentPlace.SelectedValue);
                }
            }

            dtResume1 = ClsQuerysDB.ExecuteParameterizedQuery(queryReportResume + where + groupByResume, dicDateTables);
        }

        public void SetDGVEmployeeResume()
        {
            string where = whereQuery1 + $" fdr.d_datetime BETWEEN '{GetDay1()}' AND '{GetDay2()}' AND fdr.c_codigo_emp = '{frm.txbIdEmployee.Text}' ";

            dtResume1 = ClsQuerysDB.GetDataTable(queryReportResume + where + groupByResume);
        }

        private string GetDay1()
        {
            return frm.dtpDate1.Value.ToString("yyyy-MM-dd");
        }
        private string GetDay2()
        {
            return frm.dtpDate2.Value.ToString("yyyy-MM-dd");
        }

        public void BtnSearchEmployee()
        {
            if (!frm.txbIdEmployee.Text.IsNullOrEmpty())
            {
                ClsValues.FormatZeros(frm.txbIdEmployee.Text, "000000");
                SetDGVEmployeeReportBeetweenDays();
                SetDGVEmployeeResume();
                SetDGVReportBetweenDaysColumnDaysIdEmployee(frm.txbIdEmployee.Text);
                frm.dgvQuery.DataSource = dtReport1;

                frm.txbIdEmployee.SelectAll();
            }
            else
            {
                System.Media.SystemSounds.Hand.Play();
            }
        }
        public void ExportDataGridViewExcel(DataGridView dataGridView)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivos de Excel (*.xlsx)|*.xlsx";
            saveFileDialog.FileName = "ReporteComedor.xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (XLWorkbook workbook = new XLWorkbook())
                    {
                        DataTable dataTableW = GetDataTableFromDataTable(dtReport1);
                        workbook.Worksheets.Add(dataTableW, "Trabajador");

                        DataTable dataTableDC = GetDataTableFromDataTable(dtReportColumnDays);
                        workbook.Worksheets.Add(dataTableDC, "Columnas dia");

                        DataTable dataTablePP = GetDataTableFromDataTable(dtResume1);
                        workbook.Worksheets.Add(dataTablePP, "Lugar de pago");

                        workbook.SaveAs(saveFileDialog.FileName);
                    }

                    MessageBox.Show("El archivo se ha exportado exitosamente.", "Exportación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al exportar el archivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private DataTable GetDataTableFromDataTable(DataTable dataTable)
        {
            DataTable resultTable = new DataTable();

            // Agregar las columnas al DataTable con los tipos de datos personalizados
            foreach (DataColumn column in dataTable.Columns)
            {
                Type columnType = typeof(string); // Por defecto, texto

                // Configurar el tipo de datos basado en el nombre de la columna
                if (column.ColumnName == "Total" || column.ColumnName == "Desayuno" || column.ColumnName == "Comida" || column.ColumnName == "Cena")
                {
                    columnType = typeof(decimal); // Tipo numérico (puede usar int si son enteros)
                }
                else if (column.ColumnName == "Fecha")
                {
                    columnType = typeof(DateTime); // Tipo fecha
                }
                else if (column.DataType != null)
                {
                    columnType = column.DataType; // Detectar el tipo original
                }

                resultTable.Columns.Add(column.ColumnName, columnType);
            }

            // Agregar las filas al DataTable
            foreach (DataRow row in dataTable.Rows)
            {
                DataRow dataRow = resultTable.NewRow();
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    object cellValue = row[i] ?? DBNull.Value;

                    // Validar y convertir valores al tipo especificado si es necesario
                    if (resultTable.Columns[i].DataType == typeof(decimal) && cellValue is string strValue)
                    {
                        if (decimal.TryParse(strValue, out decimal parsedDecimal))
                        {
                            cellValue = parsedDecimal;
                        }
                    }
                    else if (resultTable.Columns[i].DataType == typeof(DateTime) && cellValue is string dateStr)
                    {
                        if (DateTime.TryParse(dateStr, out DateTime parsedDate))
                        {
                            cellValue = parsedDate;
                        }
                    }

                    dataRow[i] = cellValue;
                }
                resultTable.Rows.Add(dataRow);
            }

            return resultTable;
        }

        public void SetDGVReportBetweenDaysColumnDays()
        {
            SetDGVReportBetweenDaysColumnDaysIdEmployee(null);
        }

        public void SetDGVReportBetweenDaysColumnDaysIdEmployee(string? idEmployee)
        {
            Dictionary<string, object?> dicDateTables = new();

            // Construcción del WHERE dinámico
            string where = " WHERE fdr.d_datetime BETWEEN @Day1 AND @Day2 ";
            dicDateTables.Add("@Day1", frm.dtpDate1.Value.ToString("yyyy-MM-dd"));
            dicDateTables.Add("@Day2", frm.dtpDate2.Value.ToString("yyyy-MM-dd"));

            if (!string.IsNullOrEmpty(idEmployee))
            {
                where += " AND fdr.c_codigo_emp = @IdEmployee ";
                dicDateTables.Add("@IdEmployee", idEmployee);
            }
            else
            {
                if (frm.cboDinerProvider.SelectedIndex > 0)
                {
                    where += " AND fdr.id_dinerProvider = @DinerProvider ";
                    dicDateTables.Add("@DinerProvider", frm.cboDinerProvider.SelectedValue);
                }

                if (frm.cboPaymentPlace.SelectedIndex > 0)
                {
                    if (frm.cboPaymentPlace.SelectedValue.ToString().IsNullOrEmpty())
                    {
                        where += " AND emp.id_paymentPlace IS NULL ";
                    }
                    else
                    {
                        where += " AND emp.id_paymentPlace = @PaymentPlace ";
                        dicDateTables.Add("@PaymentPlace", frm.cboPaymentPlace.SelectedValue);
                    }
                }
            }

            // Obtener las fechas disponibles en el rango de búsqueda
            string queryDates = @" SELECT DISTINCT FORMAT(fdr.d_datetime, 'yyyy-MM-dd') AS Fecha 
                                   FROM Nom_FoodRegister fdr 
                                   LEFT JOIN Nom_Employees emp ON emp.id_employee = fdr.c_codigo_emp
                                   " + where;

            DataTable dtDates = ClsQuerysDB.ExecuteParameterizedQuery(queryDates, dicDateTables);

            List<string> fechas = new List<string>();
            foreach (DataRow row in dtDates.Rows)
            {
                fechas.Add("[" + row["Fecha"].ToString() + "]");
            }

            string columnas = string.Join(",", fechas);

            if (columnas.IsNullOrEmpty())
            {
                dtReportColumnDays = null;
                return;
            }

            // Construcción de la consulta PIVOT con horarios dinámicos desde Conf_Parameters
            string queryReport = $@"
                                DECLARE @DesayunoHora TIME, @ComidaHora TIME, @CenaHora TIME;

                                -- Obtener los horarios desde la tabla Conf_Parameters
                                SELECT @DesayunoHora = v_valueParameters 
                                FROM Conf_Parameters WHERE id_typeParameter = '01' AND id_parameter = '011';

                                SELECT @ComidaHora = v_valueParameters 
                                FROM Conf_Parameters WHERE id_typeParameter = '01' AND id_parameter = '012';

                                SELECT @CenaHora = v_valueParameters 
                                FROM Conf_Parameters WHERE id_typeParameter = '01' AND id_parameter = '013';

                                -- Consulta principal con PIVOT
                                SELECT ID, Nombre, LP, Comedor, {columnas}
                                FROM (
                                    SELECT 
                                        fdr.c_codigo_emp AS ID, 
                                        CONCAT_WS(' ', emp.v_lastNamePat, emp.v_lastNameMat, emp.v_name) AS Nombre, 
                                        lp.id_placePayment AS LP, 
                                        dpr.v_nameDinerProvider AS Comedor, 
                                        FORMAT(fdr.d_datetime, 'yyyy-MM-dd') AS Fecha,
                                        -- Sumar todas las comidas sin separarlas por tipo
                                        COUNT(*) AS Total
                                    FROM Nom_FoodRegister fdr 
                                    LEFT JOIN Nom_Employees emp ON emp.id_employee = fdr.c_codigo_emp 
                                    LEFT JOIN Nom_DiningHall dhl ON dhl.id_dinningHall = fdr.id_dinningHall 
                                    LEFT JOIN Nom_DinerProvider dpr ON dpr.id_dinerProvider = fdr.id_dinerProvider 
                                    LEFT JOIN Nom_PlacePayment lp ON lp.id_placePayment = emp.id_paymentPlace
                                    {where}
                                    GROUP BY fdr.c_codigo_emp, emp.v_lastNamePat, emp.v_lastNameMat, emp.v_name, lp.id_placePayment, fdr.d_datetime, dpr.v_nameDinerProvider
                                ) AS SourceTable
                                PIVOT (
                                    SUM(Total) FOR Fecha IN ({columnas})
                                ) AS PivotTable
                                ORDER BY ID;";

            //Clipboard.SetText(queryReport);
            dtReportColumnDays = ClsQuerysDB.ExecuteParameterizedQuery(queryReport, dicDateTables);
        }

    }
}
