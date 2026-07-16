using SisUvex.Nomina;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace SisUvex.Grow.PlantsRowLotLoadExcel
{
    public partial class FrmPlantsRowLotLoadExcel : Form
    {
        string title = "Cargar Excel de conteo de plantas.";
        public FrmPlantsRowLotLoadExcel()
        {
            InitializeComponent();
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            if (ofdExcel.ShowDialog() == DialogResult.OK)
                txbFile.Text = ofdExcel.FileName;
        }



        public void CargarExcel()
        {
            try
            {
                btnCargarArchivos.Enabled = false;
                txbFile.Enabled = false;
                btnExaminar.Enabled = false;

                Excel.Application excelApp = new Excel.Application();
                Excel.Workbook workbook = excelApp.Workbooks.Open(txbFile.Text);
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];
                Excel.Range range = worksheet.UsedRange;

                int rowCount = range.Rows.Count;
                int colCount = range.Columns.Count;

                DataTable dt = new DataTable();

                for (int j = 1; j <= colCount; j++)
                {
                    Excel.Range cell = range.Cells[1, j] as Excel.Range;
                    string columnName = cell?.Value2?.ToString();
                    if (columnName != null)
                    {
                        dt.Columns.Add(columnName);
                    }
                }

                progressBar1.Minimum = 0;
                progressBar1.Maximum = rowCount - 1;
                progressBar1.Value = 0;

                for (int i = 2; i <= rowCount; i++)
                {
                    DataRow row = dt.NewRow();
                    for (int j = 1; j <= colCount; j++)
                    {
                        Excel.Range cell = range.Cells[i, j] as Excel.Range;
                        string cellValue = cell?.Value2?.ToString();
                        if (cellValue != null)
                        {
                            row[j - 1] = cellValue;
                        }
                    }
                    dt.Rows.Add(row);
                    progressBar1.Value = i - 1;
                }

                workbook.Close(false);
                excelApp.Quit();

                dataGridView.DataSource = dt;
            }
            catch
            {
                txbFile.Enabled = true;
                btnExaminar.Enabled = true;
                btnCargarArchivos.Enabled = true;
            }
        }

        private void btnCargarArchivos_Click(object sender, EventArgs e)
        {
            CargarExcel();

            VerificarColumnasRequeridas();
        }

        private void VerificarColumnasRequeridas()
        {
            bool columnasRequeridas = true;

            List<string> columnList = new List<string> { "LOTE", "VARIEDAD", "SURCO", "TOTALES", "EFECTIVAS", "FALLAS", "FORMACION", "PATRON", "INJERTO" };
            HashSet<string> columnsDataGrid = new HashSet<string>(dataGridView.Columns.Cast<DataGridViewColumn>().Select(c => c.HeaderText.ToUpperInvariant()));

            foreach (string column in columnList)
            {
                if (!columnsDataGrid.Contains(column.ToUpperInvariant()))
                {
                    columnasRequeridas = false;
                }
            }

            if (!columnasRequeridas)
            {
                MessageBox.Show("El archivo debe de contener las columnas:\n\n  -LOTE\n  -VARIEDAD\n  -SURCO\n  -TOTALES\n  -EFECTIVAS\n  -FALLAS\n  -FORMACION\n  -PATRON\n  -INJERTO.", title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdatePlants_Click(object sender, EventArgs e)
        {
            VerificarColumnasRequeridas();
        }
    }
}
