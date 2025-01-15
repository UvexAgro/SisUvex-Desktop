using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using ExcelDataReader.Log;
using iText.Layout.Element;
using SisUvex.Catalogos;
using SisUvex.Configuracion;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;


namespace SisUvex.Nomina.Actualizar_datos_empelado
{
    public partial class FrmActualizarDatosEmpleados : Form
    {
        SQLControl sql = new SQLControl();
        ClsCatalogos cls = new ClsCatalogos();
        private string titulo = "Actualizar datos empleados";
        public FrmActualizarDatosEmpleados()
        {
            InitializeComponent();
        }
        private void btnExaminar_Click(object sender, EventArgs e)
        {
            if (ofdExcel.ShowDialog() == DialogResult.OK)
                textBox1.Text = ofdExcel.FileName;
        }
        private void btnAbrirArchivos_Click(object sender, EventArgs e)
        {
            CargarExcel();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox1.Enabled = true;
            btnExaminar.Enabled = true;
            btnCargarArchivos.Enabled = true;
            dataGridView.DataSource = null;
            dataGridView.Rows.Clear();
            btnNSS.Enabled = false;
            btnRFC.Enabled = false;
            btnCURP.Enabled = false;
            btnLP.Enabled = false;
            btnCP.Enabled = false;
        }

        public void CargarExcel()
        {// Crear una aplicación de Excel
            try
            {
                btnCargarArchivos.Enabled = false;
                textBox1.Enabled = false;
                btnExaminar.Enabled = false;


                Excel.Application excelApp = new Excel.Application();
                Excel.Workbook workbook = excelApp.Workbooks.Open(textBox1.Text);
                Excel.Worksheet worksheet = workbook.Sheets[1];
                Excel.Range range = worksheet.UsedRange;

                // Obtener el número de filas y columnas
                int rowCount = range.Rows.Count;
                int colCount = range.Columns.Count;

                // Crear una tabla de datos para almacenar los datos del archivo de Excel
                DataTable dt = new DataTable();

                // Iterar a través de las celdas y agregar los valores a la tabla de datos
                for (int j = 1; j <= colCount; j++)
                {
                    Excel.Range cell = range.Cells[1, j] as Excel.Range;
                    string columnName = cell?.Value2?.ToString();
                    if (columnName != null)
                    {
                        columnName = (range.Cells[1, j] as Excel.Range).Value2.ToString();

                        switch (columnName)
                        {
                            case "CODIGO":
                                dt.Columns.Add(columnName);
                                break;
                            case "NSS":
                                dt.Columns.Add(columnName);
                                btnNSS.Enabled = true;
                                break;
                            case "RFC":
                                dt.Columns.Add(columnName);
                                btnRFC.Enabled = true;
                                break;
                            case "CURP":
                                dt.Columns.Add(columnName);
                                btnCURP.Enabled = true;

                                break;
                            case "LP":
                                dt.Columns.Add(columnName);
                                btnLP.Enabled = true;
                                break;
                            case "CP":
                                dt.Columns.Add(columnName);
                                btnCP.Enabled = true;
                                break;
                            default:
                                break;
                        }
                    }
                }

                for (int i = 2; i <= rowCount; i++)
                {
                    DataRow row = dt.NewRow();
                    for (int j = 1; j <= dt.Columns.Count; j++)
                    {
                        Excel.Range cell = range.Cells[i, j] as Excel.Range;
                        string cellValue = cell?.Value2?.ToString();
                        if (cellValue != null)
                        {
                            row[j - 1] = cellValue;
                        }
                    }
                    dt.Rows.Add(row);
                }



                // Cerrar la aplicación de Excel
                workbook.Close(false);
                excelApp.Quit();

                if (!dt.Columns.Contains("CODIGO"))
                {
                    textBox1.Enabled = true;
                    btnExaminar.Enabled = true;
                    btnCargarArchivos.Enabled = true;
                    MessageBox.Show("La columna CODIGO no se encuentra en el documento.", titulo);
                }
                else
                    dataGridView.DataSource = dt;


            }
            catch
            {
                textBox1.Enabled = true;
                btnExaminar.Enabled = true;
                btnCargarArchivos.Enabled = true;
            }
            finally
            {
            }
        }

        private void guardar(string columna)
        {
            if (!dataGridView.Columns.Contains(columna))
                MessageBox.Show("La columna " + columna + " no se encuentra en el documento.", titulo);
            else if (!dataGridView.Columns.Contains("CODIGO"))
                MessageBox.Show("La columna CODIGO no se encuentra en el documento.", titulo);
            else
                try
                {
                    sql.OpenConectionWrite();

                    List<string> empleadosNoCumplen = new List<string>();
                    List<string> empleadosSiCumplen = new List<string>();

                    foreach (DataGridViewRow fila in dataGridView.Rows)
                    {
                        if (!fila.IsNewRow)
                        {
                            // Extraer los datos de la fila del DataGridView
                            string? codigo = fila.Cells["CODIGO"].Value.ToString();

                            string? celda = fila.Cells[columna].Value.ToString();

                            if ((celda?.Length ?? 0) != 0 && (codigo?.Length ?? 0) != 0)
                            {
                                codigo = cls.FormatoCeros(codigo, "000000");
                                bool valido = true;
                                string query = $"USE {ClsConfig.DbEmployees} UPDATE nomempleados SET ";

                                //elegir que columna de la bd modificar
                                switch (columna)
                                {
                                    case "NSS":

                                        query += " c_numimss_emp";
                                        valido = EvaluarNSS(ref celda);
                                        break;
                                    case "RFC":
                                        query += " v_rfc_emp";
                                        valido = EvaluarRFC(ref celda);
                                        break;
                                    case "CURP":
                                        query += " v_curp_emp";
                                        valido = EvaluarCURP(ref celda);

                                        break;
                                    case "LP":
                                        query += " c_codigo_lug";
                                        valido = EvaluarLP(ref celda);
                                        break;
                                    case "CP":
                                        query += " n_cpostal_emp";
                                        valido = EvaluarCP(ref celda);
                                        break;
                                    default:
                                        valido = false;
                                        break;
                                }

                                if (valido)
                                {
                                    query += $" = '{celda}' WHERE c_codigo_emp = '{codigo}'";

                                    SqlCommand cdm = new SqlCommand(query, sql.cnn);
                                    cdm.ExecuteNonQuery();
                                    empleadosSiCumplen.Add(codigo);
                                }
                                else
                                {
                                    empleadosNoCumplen.Add(codigo);
                                }
                            }//if vacio
                        }//if newrow
                    }//for
                    MostrarMensajeEmpleadosNoCumplen(empleadosNoCumplen);
                    MostrarMensajeEmpleadosSiCumplen(empleadosSiCumplen);
                }//try
                catch (Exception ex)
                {
                    textBox1.Text = ex.Message;
                    MessageBox.Show(ex.ToString(), titulo);
                }
                finally
                {
                    sql.CloseConectionWrite();
                }

        }

        private void btnNSS_Click(object sender, EventArgs e)
        {
            guardar("NSS");//11 NUMEROS
            btnCURP.Enabled = dataGridView.Columns.Contains("NSS");
            btnLP.Enabled = dataGridView.Columns.Contains("LP");
            btnNSS.Enabled = false;
            btnRFC.Enabled = dataGridView.Columns.Contains("RFC");
            btnCP.Enabled = dataGridView.Columns.Contains("CP");
        }

        private void btnRFC_Click(object sender, EventArgs e)
        {
            guardar("RFC");//13
            btnCURP.Enabled = dataGridView.Columns.Contains("CURP");
            btnLP.Enabled = dataGridView.Columns.Contains("LP");
            btnNSS.Enabled = dataGridView.Columns.Contains("NSS");
            btnRFC.Enabled = false;
            btnCP.Enabled = dataGridView.Columns.Contains("CP");
        }

        private void btnLP_Click(object sender, EventArgs e)
        {
            guardar("LP");//NUMEROS
            btnCURP.Enabled = dataGridView.Columns.Contains("CURP");
            btnLP.Enabled = false;
            btnNSS.Enabled = dataGridView.Columns.Contains("NSS");
            btnRFC.Enabled = dataGridView.Columns.Contains("RFC");
            btnCP.Enabled = dataGridView.Columns.Contains("CP");
        }

        private void btnCURP_Click(object sender, EventArgs e)
        {
            guardar("CURP");//18
            btnCURP.Enabled = dataGridView.Columns.Contains("CURP");
            btnLP.Enabled = dataGridView.Columns.Contains("LP");
            btnNSS.Enabled = dataGridView.Columns.Contains("NSS");
            btnRFC.Enabled = dataGridView.Columns.Contains("RFC");
            btnCP.Enabled = dataGridView.Columns.Contains("CP");
        }
        private void btnCP_Click(object sender, EventArgs e)
        {
            guardar("CP");//5 NUMEROS
            btnCURP.Enabled = dataGridView.Columns.Contains("CURP");
            btnLP.Enabled = dataGridView.Columns.Contains("LP");
            btnNSS.Enabled = dataGridView.Columns.Contains("NSS");
            btnRFC.Enabled = dataGridView.Columns.Contains("RFC");
            btnCP.Enabled = false;
        }
        public bool EvaluarNSS(ref string NSS)
        {
            if (string.IsNullOrEmpty(NSS))
                return false;

            if (NSS.Length != 11)
                return false;

            long numero;
            if (!long.TryParse(NSS, out numero))
                return false;

            return true;
        }

        public bool EvaluarRFC(ref string RFC)
        {
            if (string.IsNullOrEmpty(RFC))
                return false;

            if (RFC.Length != 13)
                return false;

            RFC = RFC.ToUpper();

            string pattern = @"^[A-Z]{4}\d{6}[A-Z0-9]{3}$";
            return System.Text.RegularExpressions.Regex.IsMatch(RFC, pattern);
        }

        public bool EvaluarLP(ref string LP)
        {
            if (string.IsNullOrEmpty(LP))
                return false;

            int numero;
            if (!int.TryParse(LP, out numero))
                return false;

            if (numero > 9999)
                return false;

            LP = cls.FormatoCeros(LP, "0000");
            return true;
        }

        public bool EvaluarCURP(ref string CURP)
        {
            if (string.IsNullOrEmpty(CURP))
                return false;

            if (CURP.Length != 18)
                return false;

            CURP = CURP.ToUpper();

            string pattern = @"^[A-Z]{4}\d{6}[A-Z]{6}[A-Z0-9]{2}$";
            return System.Text.RegularExpressions.Regex.IsMatch(CURP, pattern);
        }
        public bool EvaluarCP(ref string CP)
        {
            if (string.IsNullOrEmpty(CP))
                return false;

            if (CP.Length != 5)
                return false;

            long numero;
            if (!long.TryParse(CP, out numero))
                return false;

            CP = cls.FormatoCeros(CP, "00000");

            return true;
        }

        private void MostrarMensajeEmpleadosNoCumplen(List<string> empleadosNoCumplen)
        {
            if (empleadosNoCumplen.Count > 0)
            {
                string mensaje = "Los siguientes empleados no cumplen con los parámetros: " + string.Join(", ", empleadosNoCumplen);
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void MostrarMensajeEmpleadosSiCumplen(List<string> empleadosCumplen)
        {
            if (empleadosCumplen.Count > 0)
            {
                string mensaje = "Se actualizaron correctamente los empleados: " + string.Join(", ", empleadosCumplen);
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        
    }

}
