using ClosedXML.Excel;
using DocumentFormat.OpenXml.Presentation;
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
        public DataTable? dtReport1, dtResume1;
        string queryReport1 = " SELECT fdr.c_codigo_emp AS 'ID', CONCAT_WS(' ', emp.v_lastNamePat, emp.v_lastNameMat, emp.v_name) AS 'Nombre', lp.id_placePayment AS 'LP', dpr.v_nameDinerProvider AS 'Comedor', FORMAT(fdr.d_datetime, 'yyyy-MM-dd') AS 'Fecha', COUNT(fdr.c_servedAgain) AS 'Total', CASE WHEN fdr.c_dinnerType = '1' THEN 1 ELSE 0 END AS 'Desayuno', CASE WHEN fdr.c_dinnerType = '2' THEN 1 ELSE 0 END AS 'Comida', CASE WHEN fdr.c_dinnerType = '3' THEN 1 ELSE 0 END AS 'Cena' FROM Nom_FoodRegister fdr LEFT JOIN Nom_Employees emp ON emp.id_employee = fdr.c_codigo_emp LEFT JOIN Nom_DiningHall dhl ON dhl.id_dinningHall = fdr.id_dinningHall LEFT JOIN Nom_DinerProvider dpr ON dpr.id_dinerProvider = fdr.id_dinerProvider LEFT JOIN Nom_PlacePayment lp ON lp.id_placePayment = emp.id_paymentPlace ";
        string groupByReport1 = " GROUP BY fdr.c_codigo_emp, emp.v_lastNamePat, emp.v_lastNameMat, emp.v_name, lp.id_placePayment, fdr.d_datetime, fdr.c_dinnertype, dpr.v_nameDinerProvider ";
        string whereQuery1 = " WHERE ";

        string queryReportResume = " SELECT \r\n\tdpr.v_nameDinerProvider AS 'COMEDOR',\r\n    FORMAT(fdr.d_datetime, 'yyyy-MM-dd, dddd', 'es-ES') AS 'Fecha',\r\n    COUNT(fdr.c_codigo_emp) AS 'Trabajadores',\r\n    lp.id_placePayment AS 'LP',\r\n    CASE \r\n        WHEN fdr.c_dinnerType = '1' THEN 'Desayuno'\r\n        WHEN fdr.c_dinnerType = '2' THEN 'Comida'\r\n        WHEN fdr.c_dinnerType = '3' THEN 'Cena'\r\n    END AS 'T. Comida'\r\nFROM Nom_FoodRegister fdr\r\nLEFT JOIN Nom_Employees emp ON emp.id_employee = fdr.c_codigo_emp\r\nLEFT JOIN Nom_DiningHall dhl ON dhl.id_dinningHall = fdr.id_dinningHall\r\nLEFT JOIN Nom_DinerProvider dpr ON dpr.id_dinerProvider = fdr.id_dinerProvider\r\nLEFT JOIN Nom_PlacePayment lp ON lp.id_placePayment = emp.id_paymentPlace ";
        string groupByResume = " GROUP BY dpr.v_nameDinerProvider, lp.id_placePayment, fdr.d_datetime, fdr.c_dinnertype ";


        string? breakfastTime = null, lunchTime = null, dinnerTime = null;

        public void LoadForm()
        {
            DataTable dtPlacePayment = ClsQuerysDB.GetDataTable(ClsObject.PlacePayment.QueryCbo);

            if (dtPlacePayment == null || dtPlacePayment.Rows.Count == 0)
                return;

            dtPlacePayment.DefaultView.RowFilter = $"{ClsObject.Column.active} = '1'";
            ClsComboBoxes.LoadComboBoxDataSource(frm.cboPaymentPlace, dtPlacePayment);


            DataTable dtProvider = ClsQuerysDB.GetDataTable(ClsObject.DinerProvider.QueryCbo);
            dtProvider.DefaultView.RowFilter = $"{ClsObject.Column.active} = '1'";
            ClsComboBoxes.LoadComboBoxDataSource(frm.cboDinerProvider, dtProvider);

            ClsTextBoxes.TxbApplyKeyPressEventInt(frm.txbIdEmployee);

            frm.txbIdEmployee.KeyPress += (sender, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
                else if (e.KeyChar == (char)Keys.Enter)
                {
                    BtnSearchEmployee();
                }
            };
        }

        public void SetDGVReportBeetweenDays()
        {
            string where = whereQuery1 + $" fdr.d_datetime BETWEEN '{GetDay1()}' AND '{GetDay2()}' ";
            if (frm.cboDinerProvider.SelectedIndex > 0)
                where += " AND fdr.id_dinerProvider = '" + frm.cboDinerProvider.SelectedValue + "' ";

            if (frm.cboPaymentPlace.SelectedIndex > 0)
                where += " AND emp.id_paymentPlace = '" + frm.cboDinerProvider.SelectedValue + "' ";

            dtReport1 = ClsQuerysDB.GetDataTable(queryReport1 + where + groupByReport1);
        }

        public void SetDGVEmployeeReportBeetweenDays()
        {
            string where = whereQuery1 + $" fdr.d_datetime BETWEEN '{GetDay1()}' AND '{GetDay2()}' AND fdr.c_codigo_emp = '{frm.txbIdEmployee.Text}' ";

            dtReport1 = ClsQuerysDB.GetDataTable(queryReport1 + where + groupByReport1);
        }
        public void SetDGVResume()
        {
            string where = whereQuery1 + " fdr.d_datetime BETWEEN '" + GetDay1() + "' AND '" + GetDay2() + "' ";

            if (frm.cboDinerProvider.SelectedIndex > 0)
                where += " AND fdr.id_dinerProvider = '" + frm.cboDinerProvider.SelectedValue + "' ";

            if (frm.cboPaymentPlace.SelectedIndex > 0)
                where += " AND emp.id_paymentPlace = '" + frm.cboDinerProvider.SelectedValue + "' ";

            dtResume1 = ClsQuerysDB.GetDataTable(queryReportResume + where + groupByResume);
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
            if (int.TryParse(frm.txbIdEmployee.Text, out _))
            {
                ClsValues.FormatZeros(frm.txbIdEmployee.Text, "000000");
                SetDGVEmployeeReportBeetweenDays();
                SetDGVEmployeeResume();
                frm.dgvQuery.DataSource = dtReport1;
            }
            else
            {
                System.Media.SystemSounds.Hand.Play();
                frm.txbIdEmployee.SelectAll();
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

        //private DataTable GetDataTableFromDataGridView(DataGridView dataGridView)
        //{
        //    DataTable dataTable = new DataTable();

        //    // Agregar las columnas al DataTable
        //    foreach (DataGridViewColumn column in dataGridView.Columns)
        //    {
        //        dataTable.Columns.Add(column.HeaderText);
        //    }

        //    // Agregar las filas al DataTable
        //    foreach (DataGridViewRow row in dataGridView.Rows)
        //    {
        //        DataRow dataRow = dataTable.NewRow();
        //        for (int i = 0; i < dataGridView.Columns.Count; i++)
        //        {
        //            dataRow[i] = row.Cells[i].Value;
        //        }
        //        dataTable.Rows.Add(dataRow);
        //    }

        //    return dataTable;
        //}
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

        //private DataTable GetDataTableFromDataGridView(DataGridView dataGridView)
        //{
        //    DataTable dataTable = new DataTable();

        //    // Agregar las columnas al DataTable con los tipos de datos personalizados
        //    foreach (DataGridViewColumn column in dataGridView.Columns)
        //    {
        //        Type columnType = typeof(string); // Por defecto, texto

        //        // Configurar el tipo de datos basado en el nombre de la columna
        //        if (column.HeaderText == "Total" || column.HeaderText == "Desayuno" || column.HeaderText == "Comida" || column.HeaderText == "Cena")
        //        {
        //            columnType = typeof(decimal); // Tipo numérico (puede usar int si son enteros)
        //        }
        //        else if (column.HeaderText == "Fecha")
        //        {
        //            columnType = typeof(DateTime); // Tipo fecha
        //        }
        //        else if (column.ValueType != null)
        //        {
        //            columnType = column.ValueType; // Detectar el tipo original
        //        }

        //        dataTable.Columns.Add(column.HeaderText, columnType);
        //    }

        //    // Agregar las filas al DataTable
        //    foreach (DataGridViewRow row in dataGridView.Rows)
        //    {
        //        if (!row.IsNewRow) // Ignorar la fila nueva
        //        {
        //            DataRow dataRow = dataTable.NewRow();
        //            for (int i = 0; i < dataGridView.Columns.Count; i++)
        //            {
        //                object cellValue = row.Cells[i].Value ?? DBNull.Value;

        //                // Validar y convertir valores al tipo especificado si es necesario
        //                if (dataTable.Columns[i].DataType == typeof(decimal) && cellValue is string strValue)
        //                {
        //                    if (decimal.TryParse(strValue, out decimal parsedDecimal))
        //                    {
        //                        cellValue = parsedDecimal;
        //                    }
        //                }
        //                else if (dataTable.Columns[i].DataType == typeof(DateTime) && cellValue is string dateStr)
        //                {
        //                    if (DateTime.TryParse(dateStr, out DateTime parsedDate))
        //                    {
        //                        cellValue = parsedDate;
        //                    }
        //                }

        //                dataRow[i] = cellValue;
        //            }
        //            dataTable.Rows.Add(dataRow);
        //        }
        //    }

        //    return dataTable;
        //}
    }
}
