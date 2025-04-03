using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using ExcelDataReader.Log;
using iText.Layout.Element;
using Microsoft.IdentityModel.Tokens;
using SisUvex.Catalogos;
using SisUvex.Catalogos.Metods.ExcelLoad;
using SisUvex.Catalogos.Metods.Forms.BigResult;
using SisUvex.Configuracion;
using System.Data;
using System.Data.SqlClient;
using System.Media;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;


namespace SisUvex.Nomina.Actualizar_datos_empelado
{
    public partial class FrmActualizarDatosEmpleados : Form
    {
        SQLControl sql = new SQLControl();
        ClsCatalogos cls = new ClsCatalogos();
        private string titulo = "Actualizar datos empleados";
        private ClsExcel excel;

        public FrmActualizarDatosEmpleados()
        {
            InitializeComponent();
        }
        private void btnExaminar_Click(object sender, EventArgs e)
        {
            excel = new();

            excel.OpenFileDialog();

            cboSheets.DataSource = null;
            dgvEmployees.DataSource = null;

            if (!excel.path.IsNullOrEmpty())
            {
                ClearControls();

                txbExcelPath.Text = excel.path;
                excel.LoadSheetsIntoComboBox(cboSheets);

                if (cboSheets.Items.Count > 0)
                    cboSheets.SelectedIndex = 0;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void ClearControls()
        {
            txbExcelPath.Text = string.Empty;
            dgvEmployees.DataSource = null;
            dgvEmployees.Rows.Clear();
            cboSheets.Items.Clear();
            btnNSS.Enabled = false;
            btnRFC.Enabled = false;
            btnCURP.Enabled = false;
            btnLP.Enabled = false;
            btnCP.Enabled = false;
        }

        private void ProcedureChangeCells(string columna)
        {
            if (!dgvEmployees.Columns.Contains(columna))
                MessageBox.Show("La columna " + columna + " no se encuentra en el documento.", titulo);
            else if (!dgvEmployees.Columns.Contains("CODIGO"))
                MessageBox.Show("La columna CODIGO no se encuentra en el documento.", titulo);
            else
                try
                {
                    sql.OpenConectionWrite();

                    List<string> empleadosNoCumplen = new List<string>();
                    List<string> empleadosSiCumplen = new List<string>();

                    foreach (DataGridViewRow fila in dgvEmployees.Rows)
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
                    txbExcelPath.Text = ex.Message;
                    MessageBox.Show(ex.ToString(), titulo);
                }
                finally
                {
                    sql.CloseConectionWrite();
                }

        }

        private void btnNSS_Click(object sender, EventArgs e)
        {
            ProcedureChangeCells("NSS");//11 NUMEROS
            //btnCURP.Enabled = dgvEmployees.Columns.Contains("NSS");
            //btnLP.Enabled = dgvEmployees.Columns.Contains("LP");
            //btnNSS.Enabled = false;
            //btnRFC.Enabled = dgvEmployees.Columns.Contains("RFC");
            //btnCP.Enabled = dgvEmployees.Columns.Contains("CP");
        }

        private void btnRFC_Click(object sender, EventArgs e)
        {
            ProcedureChangeCells("RFC");//13
            //btnCURP.Enabled = dgvEmployees.Columns.Contains("CURP");
            //btnLP.Enabled = dgvEmployees.Columns.Contains("LP");
            //btnNSS.Enabled = dgvEmployees.Columns.Contains("NSS");
            //btnRFC.Enabled = false;
            //btnCP.Enabled = dgvEmployees.Columns.Contains("CP");
        }

        private void btnLP_Click(object sender, EventArgs e)
        {
            ProcedureChangeCells("LP");//NUMEROS
            //btnCURP.Enabled = dgvEmployees.Columns.Contains("CURP");
            //btnLP.Enabled = false;
            //btnNSS.Enabled = dgvEmployees.Columns.Contains("NSS");
            //btnRFC.Enabled = dgvEmployees.Columns.Contains("RFC");
            //btnCP.Enabled = dgvEmployees.Columns.Contains("CP");
        }

        private void btnCURP_Click(object sender, EventArgs e)
        {
            ProcedureChangeCells("CURP");//18
            //btnCURP.Enabled = dgvEmployees.Columns.Contains("CURP");
            //btnLP.Enabled = dgvEmployees.Columns.Contains("LP");
            //btnNSS.Enabled = dgvEmployees.Columns.Contains("NSS");
            //btnRFC.Enabled = dgvEmployees.Columns.Contains("RFC");
            //btnCP.Enabled = dgvEmployees.Columns.Contains("CP");
        }
        private void btnCP_Click(object sender, EventArgs e)
        {
            ProcedureChangeCells("CP");//5 NUMEROS
            //btnCURP.Enabled = dgvEmployees.Columns.Contains("CURP");
            //btnLP.Enabled = dgvEmployees.Columns.Contains("LP");
            //btnNSS.Enabled = dgvEmployees.Columns.Contains("NSS");
            //btnRFC.Enabled = dgvEmployees.Columns.Contains("RFC");
            //btnCP.Enabled = false;
        }
        public bool EvaluarNSS(ref string NSS)
        {
            if (string.IsNullOrEmpty(NSS))
                return false;

            if (NSS.Length != 11)
                return false;

            long numero;
            if (!long.TryParse(NSS, out numero) || numero == 0)
                return false;

            NSS = cls.FormatoCeros(NSS, "00000000000");

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
            if (!int.TryParse(LP, out numero) || numero == 0)
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
            if (!long.TryParse(CP, out numero) || numero == 0)
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

                FrmBigResultText MesBox = new FrmBigResultText();
                MesBox.TitleWindow = "Actualizar datos empleados";
                MesBox.TextTitle = "Empleados que no cumplen";
                MesBox.Description = "Los siguientes empleados no cumplen con los parámetros:";
                MesBox.TextInBox = string.Join("\n", empleadosNoCumplen);
                MesBox.SetValues();
                MesBox.ShowDialog();

                if (MesBox.CopyResult)
                    Clipboard.SetText(MesBox.TextInBox);
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

        private void btnSheets_Click(object sender, EventArgs e)
        {
            if (excel == null || excel.path.IsNullOrEmpty() || cboSheets.Items.Count == 0)
                SystemSounds.Exclamation.Play();
            else
                dgvEmployees.DataSource = excel.LoadSheetData(cboSheets);

            btnCP.Enabled = dgvEmployees.Columns.Contains("CP");
            btnCURP.Enabled = dgvEmployees.Columns.Contains("CURP");
            btnLP.Enabled = dgvEmployees.Columns.Contains("LP");
            btnNSS.Enabled = dgvEmployees.Columns.Contains("NSS");
            btnRFC.Enabled = dgvEmployees.Columns.Contains("RFC");
        }
    }

}
