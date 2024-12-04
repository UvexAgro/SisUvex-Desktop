using System;
using System.Collections.Generic;
using SisUvex.Configuracion;

namespace SisUvex.Inicio
{
    public partial class PantallaCarga : Form
    {
       //SQLControl sql = new SQLControl();
        public PantallaCarga()
        {
            InitializeComponent();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            calis();
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.Show();
        }

        private void PantallaCarga_Load(object sender, EventArgs e)
        {
            timer1.Start();

            ClsXmlArchivos.CrearXmlInicio();

            ClsXmlArchivos xml = new ClsXmlArchivos();
            xml.PutInTempFile();
            ClsConfig conf = new ClsConfig();
            conf.Leer();
            xml.DeleteXmlConTemp(); ;
            lblCadenaConexion.Text += ClsConfig.Server + "\\" + ClsConfig.DbConn + " && " + ClsConfig.DbWrite;
        }

        public void calis()
        {
            timer1.Stop();
            SQLControl sql = new SQLControl();
            try
            {
                sql.OpenConectionWrite();
                sql.CloseConectionWrite();

                sql.OpenConectionRead();

                if (sql.ValidateConnection())
                {
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("No se pudo conectar a la base de datos.", "Error conexión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                sql.ChangeConectionSettingsMessege();
                this.Hide();
            }
            finally
            {
                sql.CloseConectionRead();
            }
        }
    }//class
}//namespace
