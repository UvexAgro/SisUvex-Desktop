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

namespace SisUvex.Nomina
{

    public partial class UExcel : Form
    {
        ClsCatalogos cat = new ClsCatalogos();
        ClsNomina cls = new ClsNomina();
        // Un DataSet es un objeto que almacena n número de DataTables, estas tablas pueden estar conectadas dentro del dataset.
        private DataSet dtsTablas = new DataSet();

        public UExcel()
        {
            InitializeComponent();
            txtIDEmpleado.KeyPress += TxtIDEmpleado_KeyPress;
            txtIDEmpleado.Leave += TxtIDEmpleado_Leave;
        }

        public System.Windows.Forms.ProgressBar ProgressBar
        {
            get { return progressBar; }
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
            InitialDesign();
            CboIDComedor.DataSource = cls.CboIDComedor();
            CboIDComedor.DisplayMember = "id_dinerProvider";
            /*
            // Llenar el ComboBox CboStatus con los valores 0 y 1
            DataTable dtStatus = new DataTable();
            dtStatus.Columns.Add("StatusValue", typeof(int));
            dtStatus.Rows.Add(0);
            dtStatus.Rows.Add(1);
            CboStatus.DataSource = dtStatus;
            CboStatus.DisplayMember = "StatusValue";

            */
        }



        private void InitialDesign()
        {
            btnBuscar.Cursor = Cursors.Hand;
            btnMostrar.Cursor = Cursors.Hand;
            btnRegistrarData.Cursor = Cursors.Hand;

            dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDatos.MultiSelect = false;
            dgvDatos.ReadOnly = true;
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDatos.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
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


                    // FileStream nos permite leer, escribir, abrir y cerrar archivos en un sistema de archivos, como matrices de bytes
                    FileStream fsSource = new FileStream(oOpenFileDialog.FileName, FileMode.Open, FileAccess.Read);


                    // ExcelReaderFactory.CreateBinaryReader = formato XLS
                    //ExcelReaderFactory.CreateOpenXmlReader = formato XLSX
                    // ExcelReaderFactory.CreateReader = XLS o XLSX
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
                bool resultado = new LoadData(this).DataLoad(data);

                if (resultado)
                {
                    MessageBox.Show("Se registró la data correctamente");
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


        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void TxtIDEmpleado_KeyPress(object sender, KeyPressEventArgs e)
        {
            System.Windows.Forms.TextBox textBox = (System.Windows.Forms.TextBox)sender;
            if (e.KeyChar != '\b' && textBox.Text.Length >= 6)
            {
                e.Handled = true;
            }
        }


        private void TxtIDEmpleado_TextChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox textBox = (System.Windows.Forms.TextBox)sender;
            string input = textBox.Text;

            if (!int.TryParse(input, out _))
            {
                textBox.Text = "";
            }
            else if (input.Length > 6)
            {
                input = input.Substring(0, 6);
                textBox.Text = input;
                textBox.SelectionStart = input.Length;
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

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
