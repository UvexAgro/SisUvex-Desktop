using DocumentFormat.OpenXml.Vml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Configuracion
{
    public partial class FrmConfiguracion : Form
    {
        public FrmConfiguracion()
        {
            InitializeComponent();
            ClsXmlArchivos xml = new ClsXmlArchivos();
            xml.PutInTempFile();
            ClsConfig conf = new ClsConfig();
            conf.Leer();
            txbServer.Text = ClsConfig.Server;
            txbBdConn.Text = ClsConfig.DbConn;
            txbUserConn.Text = ClsConfig.UserConn;
            txbPassConn.Text = ClsConfig.PassConn;
            txbBdWrite.Text = ClsConfig.DbWrite;
            txbUserWrite.Text = ClsConfig.UserWrite;
            txbPassWrite.Text = ClsConfig.PassWrite;
            xml.DeleteXmlConTemp();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ClsXmlArchivos xml = new ClsXmlArchivos();
            xml.PutInTempFile();
            ClsConfig conf = new ClsConfig();
            ClsConfig.DbConn = txbBdConn.Text;
            ClsConfig.Server = txbServer.Text;
            ClsConfig.UserConn = txbUserConn.Text;
            ClsConfig.PassConn = txbPassConn.Text;
            ClsConfig.DbWrite = txbBdWrite.Text;
            ClsConfig.UserWrite = txbUserWrite.Text;
            ClsConfig.PassWrite = txbPassWrite.Text;
            conf.Guardar();
            xml.PutInConfFile();

            MessageBox.Show("Configuración guardada, se reiniciará la aplicación.", "[Configuración]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Restart();
        }

        private void btnLectura_Click(object sender, EventArgs e)
        {
            ConnectionTry(txbServer.Text, txbBdConn.Text, txbUserConn.Text, txbPassConn.Text);
        }

        private void btnEscritura_Click(object sender, EventArgs e)
        {
            ConnectionTry(txbServer.Text, txbBdWrite.Text, txbUserWrite.Text, txbPassWrite.Text);
        }
        public void ConnectionTry(string svr, string bd, string user, string pass)
        {
            string cadenaConexion = $"Data Source = {svr}; Initial Catalog = {bd};TrustServerCertificate=true; Persist Security Info = True; User ID = {user}; Password = {pass}";
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = cadenaConexion;
            try
            {
                connection.Open();

                MessageBox.Show("Conexión exitosa a SQL Server.", "Configuración de conexión", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar conectar a SQL Server: " + ex.Message, "Configuración de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void FrmConfiguracion_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }
    }
}
