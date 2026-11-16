using System.Runtime.InteropServices;
using SisUvex.Configuracion;

namespace SisUvex.Inicio
{
    public partial class PantallaCarga : Form
    {
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        public PantallaCarga()
        {
            InitializeComponent();
            CentrarVerticalmente(txbUser, pnlUsuario);
            CentrarVerticalmente(txbPassword, pnlPassword);
        }

        private static void CentrarVerticalmente(Control campo, Control contenedor)
        {
            campo.Top = Math.Max((contenedor.Height - campo.Height) / 2, 0);
        }

        private void PantallaCarga_Load(object sender, EventArgs e)
        {
            ClsXmlArchivos.CrearXmlInicio();

            ClsXmlArchivos xml = new ClsXmlArchivos();
            xml.PutInTempFile();
            ClsConfig conf = new ClsConfig();
            conf.Leer();
            xml.DeleteXmlConTemp();

            MostrarServidorActivo();
            txbUser.Text = User.GetLastUser();
        }

        private void PantallaCarga_Shown(object sender, EventArgs e)
        {
            ValidarConexion();

            if (string.IsNullOrEmpty(txbUser.Text))
                txbUser.Focus();
            else
                txbPassword.Focus();
        }

        /// <summary>
        /// Muestra qué servidor está en uso: su nombre, el texto de conexión y, salvo el servidor 1,
        /// la imagen teñida con el color del servidor.
        /// </summary>
        private void MostrarServidorActivo()
        {
            ConexionServidor activo = ClsConfig.ServidorActivo;

            lblServidorActivo.Text = string.IsNullOrWhiteSpace(activo.Nombre)
                ? $"Servidor {ClsConfig.NumeroServidorActivo}"
                : activo.Nombre;
            lblCadenaConexion.Text = $"{ClsConfig.Server}\\{ClsConfig.DbConn} && {ClsConfig.DbWrite}";
            pnlImagen.ColorFiltro = ClsConfig.NumeroServidorActivo == 1 ? null : activo.ObtenerColor();
        }

        public void ValidarConexion()
        {
            SQLControl sql = new SQLControl();
            try
            {
                sql.OpenConectionWrite();
                sql.CloseConectionWrite();

                sql.OpenConectionRead();

                if (!sql.ValidateConnection())
                {
                    MessageBox.Show("No se pudo conectar a la base de datos.", "Error conexión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                }
            }
            catch (Exception)
            {
                sql.ChangeConectionSettingsMessege();
            }
            finally
            {
                sql.CloseConectionRead();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            IniciarSesion();
        }

        public void IniciarSesion()
        {
            string userLogin = txbUser.Text.ToUpper();

            if (User.ValidateUserPassword(userLogin, txbPassword.Text))
            {
                User.SetLastUser(userLogin);
                User.SetUserInfo(userLogin);

                Hide();
                FrmMenu menu = new FrmMenu();
                menu.tsslUsuario.Text = "Usuario: " + User.GetUserName();
                menu.Show();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrecta.", "Iniciar sesión");
            }
        }

        private void btnAjustes_Click(object sender, EventArgs e)
        {
            using FrmConfiguracion configuracion = new FrmConfiguracion();
            configuracion.isFrmLoginScreen = false;
            configuracion.ShowDialog(this);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Arrastrar_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }
    }//class
}//namespace
