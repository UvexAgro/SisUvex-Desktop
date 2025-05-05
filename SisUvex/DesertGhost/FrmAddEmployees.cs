using System.Data.SqlClient;
using SisUvex.Catalogos;
using SisUvex.Catalogos.Metods.Values;
using SisUvex.Catalogos.Metods.ExcelLoad;
using Microsoft.IdentityModel.Tokens;
using System.Media;
using SisUvex.Catalogos.Metods.Querys;


namespace SisUvex.DesertGhost
{
    public partial class FrmAddEmployees : Form
    {
        SQLControl sql = new SQLControl();
        private string titulo = "Actualizar datos empleados";
        private ClsExcel excel;

        List<string> empleadosSiCumplen, empleadosNoCumplen, empleadosRepetidos;
        List<string?> workGroups, productionLines;
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

                if(cboSheets.Items.Count > 0)
                    cboSheets.SelectedIndex = 0;
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
            if (!dgvEmployees.Columns.Contains("CODIGO") || !dgvEmployees.Columns.Contains("NOMBRE") || !dgvEmployees.Columns.Contains("APELLIDO PATERNO") || !dgvEmployees.Columns.Contains("APELLIDO MATERNO") || !dgvEmployees.Columns.Contains("CUADRILLA") || !dgvEmployees.Columns.Contains("BANDA"))
            {
                MessageBox.Show("Debe de contener las columnas CODIGO, NOMBRE, APELLIDO PATERNO APELLIDO MATERNO, CUADRILLA Y BANDA en la primera fila de la hoja.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                LoadEmployeesInDB();
            }
        }

        private void LoadEmployeesInDB()
        {
            try
            {
                empleadosNoCumplen = new List<string>();
                empleadosSiCumplen = new List<string>();
                empleadosRepetidos = new List<string>();

                workGroups = ClsQuerysDB.GetListFromQuery("SELECT id_workGroup FROM Pack_WorkGroup");

                productionLines = ClsQuerysDB.GetListFromQuery("SELECT id_productionLine FROM Nom_ProductionLine");

                foreach (DataGridViewRow fila in dgvEmployees.Rows)
                {
                    if (!fila.IsNewRow)
                    {
                        string? idEmployee = ClsValues.FormatZeros(fila.Cells["CODIGO"].Value.ToString(), "000000");

                        string? idWorkGroup = ClsValues.FormatZeros(fila.Cells["CUADRILLA"].Value.ToString(),"00");

                        string? idProductionLine = ClsValues.FormatZeros(fila.Cells["BANDA"].Value.ToString(), "000");


                        //MessageBox.Show($"EMP:-{idEmployee}-\nCUA:-{idWorkGroup}")
                        if (IsEmployeeValid(idEmployee, idWorkGroup, idProductionLine))
                        {
                            string? name = fila.Cells["NOMBRE"].Value.ToString();

                            string? lastNamePat = fila.Cells["APELLIDO PATERNO"].Value.ToString();

                            string? lastNameMat = fila.Cells["APELLIDO MATERNO"].Value.ToString();

                            string query = "IF (SELECT COUNT(id_employee) FROM Nom_Employees WHERE id_employee = @idEmployee) = 0 BEGIN INSERT INTO Nom_Employees (id_employee, v_lastNamePat, v_lastNameMat, v_name, id_workGroup, id_productionLine) VALUES (@idEmployee, @lastNamePat, @lastNameMat, @name, @idWorkGroup, @idProductionLine) END ELSE UPDATE Nom_Employees SET v_lastNamePat = @lastNamePat, v_lastNameMat = @lastNameMat, v_name = @name, id_workGroup = @idWorkGroup, id_productionLine = @idProductionLine WHERE id_employee = @idEmployee";

                            sql.OpenConectionWrite();

                            SqlCommand cdm = new SqlCommand(query, sql.cnn);
                            cdm.Parameters.AddWithValue("@idEmployee", idEmployee);
                            cdm.Parameters.AddWithValue("@lastNamePat", ClsValues.IfEmptyToDBNull(lastNamePat));
                            cdm.Parameters.AddWithValue("@lastNameMat", ClsValues.IfEmptyToDBNull(lastNameMat));
                            cdm.Parameters.AddWithValue("@name", ClsValues.IfEmptyToDBNull(name));
                            cdm.Parameters.AddWithValue("@idWorkGroup", ClsValues.IfEmptyToDBNull(idWorkGroup));
                            cdm.Parameters.AddWithValue("@idProductionLine", ClsValues.IfEmptyToDBNull(idProductionLine));

                            cdm.ExecuteNonQuery();

                            empleadosSiCumplen.Add(idEmployee);
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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txbExcelPath.Text = string.Empty;
            txbExcelPath.Enabled = true;
            btnExaminar.Enabled = true;
            cboSheets.DataSource = null;
            dgvEmployees.DataSource = null;
            dgvEmployees.Rows.Clear();
        }

        public bool IsEmployeeValid(string idEmployee, string idWorkGroup, string idProductionLine)
        {
            try
            {
                if (empleadosNoCumplen.Contains(idEmployee))
                {
                    return false;
                }
                if (idEmployee.Length > 6)
                {
                    empleadosNoCumplen.Add(idEmployee);
                    return false;
                }
                else if (!int.TryParse(idEmployee, out int noSirve))
                {
                    empleadosNoCumplen.Add(idEmployee);
                    return false;
                }
                else if (empleadosSiCumplen.Contains(idEmployee))
                {
                    empleadosRepetidos.Add(idEmployee);
                    return false;
                }
                else if (!workGroups.Contains(idWorkGroup) || !productionLines.Contains(idProductionLine))
                {
                    empleadosNoCumplen.Add(idEmployee);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                empleadosNoCumplen.Add(idEmployee);
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
