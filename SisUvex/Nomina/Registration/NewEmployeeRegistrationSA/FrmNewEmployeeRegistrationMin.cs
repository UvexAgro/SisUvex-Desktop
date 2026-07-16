using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Nomina.Registration.NewEmployeeRegistrationSA
{
    public partial class FrmNewEmployeeRegistrationMin : Form
    {
        private DataSet dtsTablas = new DataSet();
        ClsNewEmployeeRegisrationMin cls;
        public FrmNewEmployeeRegistrationMin()
        {
            InitializeComponent();
        }
        private void FrmNewEmployeeRegistrationMin_Load(object sender, EventArgs e)
        {
            cls = new();
            cls.frm = this;

            dgvDatos.DataSource = cls.SetDataTableColumns();

            cboSex.SelectedIndex = 0;
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            cls.btnRegisterIndividualEmployee();
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

        private void btnRegisterMultiple_Click(object sender, EventArgs e)
        {
            if (dgvDatos.Rows.Count != 0)
            {
                cls.btnRegisterMultipleEmployee();
            }
            else
            {
                MessageBox.Show("No hay registros para registrar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}