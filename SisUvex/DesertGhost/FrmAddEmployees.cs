using System.Data;
using System.Data.SqlClient;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using SisUvex.Catalogos;
using SisUvex.Catalogos.Metods.Values;
using SisUvex.Catalogos.Metods.TextBoxes;


namespace SisUvex.DesertGhost
{
    public partial class FrmAddEmployees : Form
    {
        SQLControl sql = new SQLControl();
        ClsCatalogos cls = new ClsCatalogos();
        private string titulo = "Actualizar datos empleados";

        List<string> empleadosNoCumplen;
        List<string> empleadosSiCumplen;
        List<string> empleadosRepetidos;
        public FrmAddEmployees()
        {
            InitializeComponent();
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            if (ofdExcel.ShowDialog() == DialogResult.OK)
                textBox1.Text = ofdExcel.FileName;

            CargarExcel();
        }

        private void btnCargarArchivos_Click(object sender, EventArgs e)
        {
            
        }
        private void btnGuardarEmpleados_Click(object sender, EventArgs e)
        {
            guardar();
        }
        public void CargarExcel()
        {// Crear una aplicación de Excel
            try
            {
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
                        columnName = (range.Cells[1, j] as Excel.Range).Value2.ToString().ToUpper();

                        switch (columnName)
                        {
                            case "CODIGO":
                            case "CÓDIGO":
                                dt.Columns.Add("CÓDIGO");
                                break;
                            case "NOMBRE":
                                dt.Columns.Add("NOMBRE");
                                break;
                            case "APELLIDO PATERNO":
                                dt.Columns.Add("APELLIDO PATERNO");
                                break;
                            case "APELLIDO MATERNO":
                                dt.Columns.Add("APELLIDO MATERNO");
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

                if (!dt.Columns.Contains("CÓDIGO") || !dt.Columns.Contains("NOMBRE") || !dt.Columns.Contains("APELLIDO PATERNO") || !dt.Columns.Contains("APELLIDO MATERNO"))
                {
                    textBox1.Enabled = true;
                    btnExaminar.Enabled = true;
                    MessageBox.Show("Debe de contener las columnas CODIGO, NOMBRE, APELLIDO PATERNO y APELLIDO MATERNO en la primera fila de la hoja.", titulo);
                }
                else
                    dataGridView.DataSource = dt;
            }
            catch
            {
                textBox1.Enabled = true;
                btnExaminar.Enabled = true;
            }
            finally
            {
            }
        }
        private void guardar()
        {
            if (!dataGridView.Columns.Contains("CÓDIGO") || !dataGridView.Columns.Contains("NOMBRE") || !dataGridView.Columns.Contains("APELLIDO PATERNO") || !dataGridView.Columns.Contains("APELLIDO MATERNO"))
            {
                MessageBox.Show("Debe de contener las columnas CODIGO, NOMBRE, APELLIDO PATERNO y APELLIDO MATERNO en la primera fila de la hoja.", titulo);
            }
            else
                try
                {
                    empleadosNoCumplen = new List<string>();
                    empleadosSiCumplen = new List<string>();
                    empleadosRepetidos = new List<string>();

                    foreach (DataGridViewRow fila in dataGridView.Rows)
                    {
                        if (!fila.IsNewRow)
                        {
                            // Extraer los datos de la fila del DataGridView
                            string? codigo = ClsValues.FormatZeros(fila.Cells["CÓDIGO"].Value.ToString(), "000000");

                            if (EsCodigoValido(codigo))
                            {
                                string? nombre = fila.Cells["NOMBRE"].Value.ToString();

                                string? apellidoPaterno = fila.Cells["APELLIDO PATERNO"].Value.ToString();

                                string? apellidoMaterno = fila.Cells["APELLIDO MATERNO"].Value.ToString();

                                string query = "IF (SELECT COUNT(id_employee) FROM Nom_Employees WHERE id_employee = @codigo) = 0 BEGIN INSERT INTO Nom_Employees (id_employee, v_lastNamePat, v_lastNameMat, v_name) VALUES (@codigo, @apellidoPaterno, @apellidoMaterno, @nombre) END ELSE UPDATE Nom_Employees SET v_lastNamePat = @apellidoPaterno, v_lastNameMat = @apellidoMaterno, v_name = @nombre WHERE id_employee = @codigo";

                                sql.OpenConectionWrite();

                                SqlCommand cdm = new SqlCommand(query, sql.cnn);
                                cdm.Parameters.AddWithValue("@codigo", codigo);
                                cdm.Parameters.AddWithValue("@apellidoPaterno", ClsValues.IfEmptyToDBNull(apellidoPaterno));
                                cdm.Parameters.AddWithValue("@apellidoMaterno", ClsValues.IfEmptyToDBNull(apellidoMaterno));
                                cdm.Parameters.AddWithValue("@nombre", ClsValues.IfEmptyToDBNull(nombre));

                                cdm.ExecuteNonQuery();

                                empleadosSiCumplen.Add(codigo);
                            }
                        }
                    }//for

                    MostrarMensajeEmpleadosSiCumplen();
                    MostrarMensajeEmpleadosNoCumplen();
                    MostrarMensajeEmpleadosRepetidos();

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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox1.Enabled = true;
            btnExaminar.Enabled = true;
            dataGridView.DataSource = null;
            dataGridView.Rows.Clear();
        }

        public bool EsCodigoValido(string codigo)
        {
            try
            {
                if (empleadosNoCumplen.Contains(codigo))
                {
                    return false;
                }
                if (codigo.Length > 6)
                {
                    empleadosNoCumplen.Add(codigo);
                    return false;
                }
                else if (!int.TryParse(codigo, out int noSirve))
                {
                    empleadosNoCumplen.Add(codigo);
                    return false;
                }
                else if (empleadosSiCumplen.Contains(codigo))
                {
                    empleadosRepetidos.Add(codigo);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                empleadosNoCumplen.Add(codigo);
                return false;
            }
        }
        private void MostrarMensajeEmpleadosNoCumplen()
        {
            if (empleadosNoCumplen.Count > 0)
            {
                string mensaje = "Los siguientes códigos de empleado no cumplen con los parámetros: " + string.Join(", ", empleadosNoCumplen);
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarMensajeEmpleadosSiCumplen()
        {
            if (empleadosSiCumplen.Count > 0)
            {
                string mensaje = "Se actualizaron correctamente los empleados: " + string.Join(", ", empleadosSiCumplen);
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void MostrarMensajeEmpleadosRepetidos()
        {
            if (empleadosRepetidos.Count > 0)
            {
                string mensaje = "Los siguientes códigos de empleado están repetidos: " + string.Join(", ", empleadosRepetidos);
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
