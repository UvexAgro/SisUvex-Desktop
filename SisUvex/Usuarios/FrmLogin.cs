using SisUvex.Inicio;
using System.Data;
using System.Data.SqlClient;
using SisUvex.Usuarios;
using System.Security.Cryptography;
using SisUvex.Configuracion;
using System.ServiceModel.Security;

namespace SisUvex
{
    public partial class FrmLogin : Form
    {
        SQLControl sql = new SQLControl();
        public FrmLogin()
        {
            InitializeComponent();

            validateFirstConnectionTry();

            this.FormClosed += ExitApplication;
            pictureBox2.MouseClick += ExitApplication;
        }

        private void ExitApplication(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            IniciarSesion();
        }

        public void IniciarSesion()
        {
            string userLogin = txbUser.Text.ToUpper();

            //if (sql.Login(userLogin, txbPassword.Text))
            if (User.ValidateUserPassword(userLogin, txbPassword.Text))
            {
                User.SetLastUser(userLogin);
                User.SetUserInfo(userLogin);

                //User.SetProductDay();

                this.Hide();
                FrmMenu menu = new FrmMenu();
                //menu.tsslFecha.Text = "Fecha de producción: " + User.GetDate().ToString("dddd, yyyy-MM-dd");
                menu.tsslUsuario.Text = "Usuario: " + User.GetUserName();
                menu.Show();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrecta.", "Iniciar sesión");
            }
        }

        private void txbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                IniciarSesion();
            }
        }
        public void validateFirstConnectionTry()
        {
            try
            {
                sql.OpenConectionWrite();
                sql.CloseConectionWrite();

                sql.OpenConectionRead();

                if (sql.ValidateConnection())
                {
                    //string cadena = "Servidor:" + sql.server + " Database:" + sql.dbConn;
                    //lblCadenaConexion.Text = cadena;
                    //timer1.Start();
                    PantallaCarga pantalla = new PantallaCarga();
                    pantalla.Hide();
                }
                else
                {
                    //timer1.Stop();
                    MessageBox.Show("No se pudo conectar a la base de datos.", "Error conexión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                sql.ChangeConectionSettingsMessege();

            }
            finally
            {
                sql.CloseConectionRead();
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            txbUser.Text = User.GetLastUser();
        }
    }
}