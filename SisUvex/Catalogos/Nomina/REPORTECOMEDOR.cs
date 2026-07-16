using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using ClosedXML.Excel;
using SisUvex.Catalogos.Nomina.LOAD;

namespace SisUvex.Catalogos.Nomina
{
    public partial class REPORTECOMEDOR : Form
    {
        LoadRepCom cls = new LoadRepCom();

        public REPORTECOMEDOR()
        {
            InitializeComponent();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            ExportarDataGridViewExcel(dataGridView1);
        }

        private void ExportarDataGridViewExcel(DataGridView dataGridView)
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
                        DataTable dataTable = GetDataTableFromDataGridView(dataGridView);
                        workbook.Worksheets.Add(dataTable, "Sheet1");
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

        private DataTable GetDataTableFromDataGridView(DataGridView dataGridView)
        {
            DataTable dataTable = new DataTable();

            // Agregar las columnas al DataTable
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                dataTable.Columns.Add(column.HeaderText);
            }

            // Agregar las filas al DataTable
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                DataRow dataRow = dataTable.NewRow();
                for (int i = 0; i < dataGridView.Columns.Count; i++)
                {
                    dataRow[i] = row.Cells[i].Value;
                }
                dataTable.Rows.Add(dataRow);
            }

            return dataTable;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = cls.TablaRepCom(dateTimePickerInicio.Value.Date, dateTimePickerFin.Value.Date);
        }
    }
}
