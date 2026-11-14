using System.Data.SqlClient;
using SisUvex;

namespace SisUvex.Configuracion
{
    public partial class FrmConfiguracion : AntdUI.BaseForm
    {
        private static readonly Color Morado = Color.FromArgb(122, 44, 166);
        private static readonly Color MoradoClaro = Color.FromArgb(237, 226, 250);
        private static readonly Color Verde = Color.FromArgb(72, 158, 44);
        private static readonly Color VerdeClaro = Color.FromArgb(231, 244, 226);
        private static readonly Color VerdeTexto = Color.FromArgb(47, 125, 40);

        public bool isFrmLoginScreen = true;

        private readonly ClsConfig conf = new ClsConfig();
        private bool configuracionCargada;
        private ColumnaServidor col1 = null!;
        private ColumnaServidor col2 = null!;

        public FrmConfiguracion()
        {
            InitializeComponent();
            picDb1.Image = CrearIconoBaseDatos(Color.White);
            picDb2.Image = CrearIconoBaseDatos(Color.White);
            col1 = new ColumnaServidor
            {
                Server = txbServer1,
                DbConn = txbBdConn1,
                UserConn = txbUserConn1,
                PassConn = txbPassConn1,
                DbWrite = txbBdWrite1,
                UserWrite = txbUserWrite1,
                PassWrite = txbPassWrite1,
                DbEmployees = txbDbEmployees1
            };
            col2 = new ColumnaServidor
            {
                Server = txbServer2,
                DbConn = txbBdConn2,
                UserConn = txbUserConn2,
                PassConn = txbPassConn2,
                DbWrite = txbBdWrite2,
                UserWrite = txbUserWrite2,
                PassWrite = txbPassWrite2,
                DbEmployees = txbDbEmployees2
            };
            Cargar();
            MostrarEntornoActivo();
        }

        private void Cargar()
        {
            try
            {
                ClsXmlArchivos xml = new ClsXmlArchivos();
                xml.PutInTempFile();
                conf.Leer();
                xml.DeleteXmlConTemp();
                Llenar(col1, ClsConfig.Servidor1);
                Llenar(col2, ClsConfig.Servidor2);
                configuracionCargada = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Configuración de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void Llenar(ColumnaServidor columna, ConexionServidor conexion)
        {
            columna.Server.Text = conexion.Server ?? "";
            columna.DbConn.Text = conexion.DbConn ?? "";
            columna.UserConn.Text = conexion.UserConn ?? "";
            columna.PassConn.Text = conexion.PassConn ?? "";
            columna.DbWrite.Text = conexion.DbWrite ?? "";
            columna.UserWrite.Text = conexion.UserWrite ?? "";
            columna.PassWrite.Text = conexion.PassWrite ?? "";
            columna.DbEmployees.Text = conexion.DbEmployees ?? "";
        }

        private static void Tomar(ColumnaServidor columna, ConexionServidor conexion)
        {
            conexion.Server = columna.Server.Text;
            conexion.DbConn = columna.DbConn.Text;
            conexion.UserConn = columna.UserConn.Text;
            conexion.PassConn = columna.PassConn.Text;
            conexion.DbWrite = columna.DbWrite.Text;
            conexion.UserWrite = columna.UserWrite.Text;
            conexion.PassWrite = columna.PassWrite.Text;
            conexion.DbEmployees = columna.DbEmployees.Text;
        }

        private static void CopiarPlanos(ConexionServidor conexion)
        {
            ClsConfig.Server = conexion.Server ?? "";
            ClsConfig.DbConn = conexion.DbConn ?? "";
            ClsConfig.UserConn = conexion.UserConn ?? "";
            ClsConfig.PassConn = conexion.PassConn ?? "";
            ClsConfig.DbWrite = conexion.DbWrite ?? "";
            ClsConfig.UserWrite = conexion.UserWrite ?? "";
            ClsConfig.PassWrite = conexion.PassWrite ?? "";
            ClsConfig.DbEmployees = conexion.DbEmployees ?? "";
        }

        private void MostrarEntornoActivo()
        {
            bool servidor2 = ClsConfig.CurrentServer == 2;

            tagIndicador.Text = servidor2 ? "●  Servidor 2" : "●  Servidor 1";
            tagIndicador.BackColor = servidor2 ? VerdeClaro : MoradoClaro;
            tagIndicador.ForeColor = servidor2 ? VerdeTexto : Morado;

            btnCambiar.Text = servidor2 ? "Cambiar a Servidor 1" : "Cambiar a Servidor 2";
            btnCambiar.DefaultBack = servidor2 ? MoradoClaro : VerdeClaro;
            btnCambiar.DefaultBorderColor = servidor2 ? Morado : Verde;
            btnCambiar.ForeColor = servidor2 ? Morado : VerdeTexto;

            tagEnUso1.Visible = !servidor2;
            tagEnUso2.Visible = servidor2;
        }

        private static Bitmap CrearIconoBaseDatos(Color color)
        {
            const int tam = 22;
            Bitmap bmp = new Bitmap(tam, tam);
            using Graphics g = Graphics.FromImage(bmp);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            using Pen pen = new Pen(color, 1.8F);

            float izq = 3F, der = 19F, ancho = der - izq, alto = 5F;
            float[] niveles = { 3F, 9F, 15F };

            g.DrawEllipse(pen, izq, niveles[0], ancho, alto);
            g.DrawLine(pen, izq, niveles[0] + alto / 2, izq, niveles[2] + alto / 2);
            g.DrawLine(pen, der, niveles[0] + alto / 2, der, niveles[2] + alto / 2);
            g.DrawArc(pen, izq, niveles[1], ancho, alto, 0, 180);
            g.DrawArc(pen, izq, niveles[2], ancho, alto, 0, 180);
            return bmp;
        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            if (!configuracionCargada)
            {
                MessageBox.Show("No se pudo leer la configuración de conexión.", "Configuración de conexión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int nuevo = ClsConfig.CurrentServer == 2 ? 1 : 2;
            string mensaje = HayCambiosSinGuardar()
                ? $"Hay cambios sin guardar. Se perderán y la aplicación operará en Servidor {nuevo} al reiniciar. ¿Desea continuar?"
                : $"La aplicación operará en Servidor {nuevo} y se reiniciará. ¿Desea continuar?";
            if (MessageBox.Show(mensaje, "Configuración de conexión", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            int anterior = ClsConfig.CurrentServer;
            try
            {
                ClsConfig.CurrentServer = nuevo;
                SQLControl.currentServer = nuevo;
                Persistir();
                MostrarEntornoActivo();
                Application.Restart();
            }
            catch (Exception ex)
            {
                ClsConfig.CurrentServer = anterior;
                SQLControl.currentServer = anterior;
                MostrarEntornoActivo();
                MessageBox.Show(ex.Message, "Configuración de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar1_Click(object sender, EventArgs e)
        {
            GuardarServidor(1);
        }

        private void btnGuardar2_Click(object sender, EventArgs e)
        {
            GuardarServidor(2);
        }

        private void btnLectura1_Click(object sender, EventArgs e)
        {
            Probar("Servidor 1 · Lectura", txbServer1.Text, txbBdConn1.Text, txbUserConn1.Text, txbPassConn1.Text);
        }

        private void btnEscritura1_Click(object sender, EventArgs e)
        {
            Probar("Servidor 1 · Escritura", txbServer1.Text, txbBdWrite1.Text, txbUserWrite1.Text, txbPassWrite1.Text);
        }

        private void btnEmpleados1_Click(object sender, EventArgs e)
        {
            Probar("Servidor 1 · Empleados", txbServer1.Text, txbDbEmployees1.Text, txbUserWrite1.Text, txbPassWrite1.Text);
        }

        private void btnLectura2_Click(object sender, EventArgs e)
        {
            Probar("Servidor 2 · Lectura", txbServer2.Text, txbBdConn2.Text, txbUserConn2.Text, txbPassConn2.Text);
        }

        private void btnEscritura2_Click(object sender, EventArgs e)
        {
            Probar("Servidor 2 · Escritura", txbServer2.Text, txbBdWrite2.Text, txbUserWrite2.Text, txbPassWrite2.Text);
        }

        private void btnEmpleados2_Click(object sender, EventArgs e)
        {
            Probar("Servidor 2 · Empleados", txbServer2.Text, txbDbEmployees2.Text, txbUserWrite2.Text, txbPassWrite2.Text);
        }

        private void GuardarServidor(int numero)
        {
            if (!configuracionCargada)
            {
                MessageBox.Show("No se pudo leer la configuración de conexión.", "Configuración de conexión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool esActivo = ClsConfig.CurrentServer == numero;
                Tomar(numero == 2 ? col2 : col1, numero == 2 ? ClsConfig.Servidor2 : ClsConfig.Servidor1);
                Persistir();

                if (esActivo)
                {
                    MessageBox.Show($"Servidor {numero} guardado. Se reiniciará la aplicación.", "Configuración de conexión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Restart();
                    return;
                }

                MessageBox.Show($"Servidor {numero} guardado.", "Configuración de conexión", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Configuración de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Persistir()
        {
            ClsXmlArchivos xml = new ClsXmlArchivos();
            xml.PutInTempFile();
            ConexionServidor activo = ClsConfig.CurrentServer == 2 ? ClsConfig.Servidor2 : ClsConfig.Servidor1;
            CopiarPlanos(activo);
            conf.Guardar();
            xml.PutInConfFile();
        }

        private bool HayCambiosSinGuardar()
        {
            return !Igual(col1, ClsConfig.Servidor1) || !Igual(col2, ClsConfig.Servidor2);
        }

        private static bool Igual(ColumnaServidor columna, ConexionServidor conexion)
        {
            return (conexion.Server ?? "") == columna.Server.Text
                && (conexion.DbConn ?? "") == columna.DbConn.Text
                && (conexion.UserConn ?? "") == columna.UserConn.Text
                && (conexion.PassConn ?? "") == columna.PassConn.Text
                && (conexion.DbWrite ?? "") == columna.DbWrite.Text
                && (conexion.UserWrite ?? "") == columna.UserWrite.Text
                && (conexion.PassWrite ?? "") == columna.PassWrite.Text
                && (conexion.DbEmployees ?? "") == columna.DbEmployees.Text;
        }

        private void Probar(string titulo, string svr, string bd, string user, string pass)
        {
            string cadenaConexion = $"Data Source = {svr}; Initial Catalog = {bd};TrustServerCertificate=true; Persist Security Info = True; User ID = {user}; Password = {pass}";
            using SqlConnection connection = new SqlConnection(cadenaConexion);
            try
            {
                connection.Open();
                MessageBox.Show($"Conexión exitosa a SQL Server.\n{titulo}", "Configuración de conexión", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar conectar ({titulo}): {ex.Message}", "Configuración de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmConfiguracion_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && isFrmLoginScreen)
            {
                Application.Exit();
            }
        }

        private sealed class ColumnaServidor
        {
            public AntdUI.Input Server { get; set; } = null!;
            public AntdUI.Input DbConn { get; set; } = null!;
            public AntdUI.Input UserConn { get; set; } = null!;
            public AntdUI.Input PassConn { get; set; } = null!;
            public AntdUI.Input DbWrite { get; set; } = null!;
            public AntdUI.Input UserWrite { get; set; } = null!;
            public AntdUI.Input PassWrite { get; set; } = null!;
            public AntdUI.Input DbEmployees { get; set; } = null!;
        }
    }
}
