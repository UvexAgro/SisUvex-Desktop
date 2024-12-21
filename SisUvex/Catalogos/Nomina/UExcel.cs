using ExcelDataReader;
using SisUvex.Catalogos.Nomina.LOAD;
using SisUvex.Catalogos.Nomina.LOAD.LNOMINA;
using System;
using SisUvex.Nomina;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using SisUvex.Catalogos;
using System.Diagnostics;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.TextBoxes;

namespace SisUvex.Nomina
{

    public partial class UExcel : Form
    {
        ClsNomina cls = new ClsNomina();
        private DataSet dtsTablas = new DataSet();

        public UExcel()
        {
            InitializeComponent();
            txbIDEmpleado.Leave += TxtIDEmpleado_Leave;

            ClsTextBoxes.TxbApplyKeyPressEventInt(txbIDEmpleado);
        }

        public void UpdateProgress(int value)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<int>(UpdateProgress), value);
            }
            else
            {
                if (value < 100)
                {
                    progressBar.Value = 100; // Establecer el valor de la ProgressBar en 100%
                    lblProgress.Text = "100%"; // Etiqueta para mostrar el porcentaje como 100%
                }
                else
                {
                    progressBar.Value = value;
                    lblProgress.Text = $"{value}%"; // Etiqueta para mostrar el porcentaje normal
                }
            }
        }

        private void UExcel_Load(object sender, EventArgs e)
        {
            CboIDComedor.DataSource = cls.CboIDComedor();
            CboIDComedor.DisplayMember = "Nombre";
            CboIDComedor.ValueMember = "Código";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                // Configuración de ventana para seleccionar un archivo
                OpenFileDialog oOpenFileDialog = new OpenFileDialog();
                oOpenFileDialog.Filter = "Excel Workbook|*.xlsx";

                if (oOpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    cboHojas.Items.Clear();
                    dgvDatos.DataSource = null;
                    txtRuta.Text = oOpenFileDialog.FileName;

                    FileStream fsSource = new FileStream(oOpenFileDialog.FileName, FileMode.Open, FileAccess.Read);

                    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                    IExcelDataReader reader = ExcelReaderFactory.CreateReader(fsSource);

                    // Convierte todas las hojas a un DataSet
                    dtsTablas = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });

                    // Obtenemos las tablas y añadimos sus nombres en el desplegable de hojas
                    foreach (DataTable tabla in dtsTablas.Tables)
                    {
                        cboHojas.Items.Add(tabla.TableName);
                    }
                    cboHojas.SelectedIndex = 0;

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboHojas.Items.Count == 0)
                {
                    System.Media.SystemSounds.Hand.Play();
                    return;
                }

                dgvDatos.DataSource = dtsTablas.Tables[cboHojas.SelectedIndex];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRegistrarData_Click(object sender, EventArgs e)
        {
            DataTable data = (DataTable)(dgvDatos.DataSource);

            try
            {
                if (data == null || !data.Columns.Contains("ID") || !data.Columns.Contains("COMEDOR"))
                {
                    MessageBox.Show("Se requieren las columnas 'ID' y 'COMEDOR' para registrar los datos.");
                    return;
                }

                bool resultado = new LoadData(this).DataLoad(data);

                if (resultado)
                    MessageBox.Show("Se registraron los datos correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar los datos: " + ex.ToString());
            }
        }

        private void TxtIDEmpleado_Leave(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox textBox = (System.Windows.Forms.TextBox)sender;
            if (textBox.Text.Length < 6)
            {
                textBox.Text = textBox.Text.PadLeft(6, '0');
            }
        }

        private void btnRegistroIndividual_Click(object sender, EventArgs e)
        {
            try
            {
                bool resultado = new LoadData(this).DataLoadSingleRecord(txbIDEmpleado.Text, CboIDComedor.SelectedValue.ToString());

                if (resultado)
                {
                    string id = txbIDEmpleado.Text.PadLeft(6, '0');
                    string comedor = CboIDComedor.SelectedValue.ToString().PadLeft(3, '0');
                    MessageBox.Show("Se registró el empleado " + id + " en el comedor " + comedor);
                }
                else
                {
                    MessageBox.Show("Hubo un problema al registrar los datos. Por favor, verifique los detalles.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar los datos: " + ex.ToString());
            }
        }
    }
}
