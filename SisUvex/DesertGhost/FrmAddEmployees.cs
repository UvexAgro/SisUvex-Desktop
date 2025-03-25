using System.Data;
using System.Data.SqlClient;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using SisUvex.Catalogos;
using SisUvex.Catalogos.Metods.Values;
using SisUvex.Catalogos.Metods.TextBoxes;
using SisUvex.Catalogos.Metods.ExcelLoad;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.IdentityModel.Tokens;
using System.Media;


namespace SisUvex.DesertGhost
{
    public partial class FrmAddEmployees : Form
    {
        SQLControl sql = new SQLControl();
        ClsCatalogos cls = new ClsCatalogos();
        private string titulo = "Actualizar datos empleados";
        private ClsExcel excel;

        List<string> empleadosNoCumplen;
        List<string> empleadosSiCumplen;
        List<string> empleadosRepetidos;
        public FrmAddEmployees()
        {
            InitializeComponent();
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            excel = new();

            excel.OpenFileDialog();

            if (!excel.path.IsNullOrEmpty())
            {
                txbExcelPath.Text = excel.path;
                excel.LoadSheetsIntoComboBox(cboSheets);
            }
            else
            {
                cboSheets.DataSource = null;
            }
        }
        private void btnSheets_Click(object sender, EventArgs e)
        {
            if (excel.path.IsNullOrEmpty() || cboSheets.Items.Count == 0)
                SystemSounds.Exclamation.Play();
            else
                dgvEmployees.DataSource = excel.LoadSheetData(cboSheets);
        }
        private void btnCargarArchivos_Click(object sender, EventArgs e)
        {

        }
        private void btnGuardarEmpleados_Click(object sender, EventArgs e)
        {
            if (!dgvEmployees.Columns.Contains("CODIGO") || !dgvEmployees.Columns.Contains("NOMBRE") || !dgvEmployees.Columns.Contains("APELLIDO PATERNO") || !dgvEmployees.Columns.Contains("APELLIDO MATERNO"))
            {
                txbExcelPath.Enabled = true;
                btnExaminar.Enabled = true;
                MessageBox.Show("Debe de contener las columnas CODIGO, NOMBRE, APELLIDO PATERNO y APELLIDO MATERNO en la primera fila de la hoja.", titulo);
            }
            else
            {
                guardar();
            }
        }

        private void guardar()
        {
            if (!dgvEmployees.Columns.Contains("CODIGO") || !dgvEmployees.Columns.Contains("NOMBRE") || !dgvEmployees.Columns.Contains("APELLIDO PATERNO") || !dgvEmployees.Columns.Contains("APELLIDO MATERNO"))
            {
                MessageBox.Show("Debe de contener las columnas CODIGO, NOMBRE, APELLIDO PATERNO y APELLIDO MATERNO en la primera fila de la hoja.", titulo);
            }
            else
            {
                try
                {
                    empleadosNoCumplen = new List<string>();
                    empleadosSiCumplen = new List<string>();
                    empleadosRepetidos = new List<string>();

                    foreach (DataGridViewRow fila in dgvEmployees.Rows)
                    {
                        if (!fila.IsNewRow)
                        {
                            string? codigo = ClsValues.FormatZeros(fila.Cells["CODIGO"].Value.ToString(), "000000");

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
                    txbExcelPath.Text = ex.Message;
                    MessageBox.Show(ex.ToString(), titulo);
                }
                finally
                {
                    sql.CloseConectionWrite();
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txbExcelPath.Text = string.Empty;
            txbExcelPath.Enabled = true;
            btnExaminar.Enabled = true;
            cboSheets.DataSource = null;
            dgvEmployees.DataSource = null;
            dgvEmployees.Rows.Clear();
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
