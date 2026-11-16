using System.Data.SqlClient;
using SisUvex;
using SisUvex.Inicio;

namespace SisUvex.Configuracion
{
    public partial class FrmConfiguracion : AntdUI.BaseForm
    {
        private const string Titulo = "Configuración de conexión";

        public bool isFrmLoginScreen = true;

        private readonly ClsConfig conf = new ClsConfig();
        private bool configuracionCargada;
        private bool cargandoUI;
        private int indiceSeleccionado;   // posición (desde 0) del servidor que se muestra en la tarjeta

        public FrmConfiguracion()
        {
            InitializeComponent();
            picDb.Image = CrearIconoBaseDatos(Color.White);
            colorServidor.ValueChanged += colorServidor_ValueChanged;

            Cargar();
            LlenarCombo(ClsConfig.NumeroServidorActivo - 1);
        }

        // ------------------------------------------------------------------ carga / pantalla

        private void Cargar()
        {
            try
            {
                ClsXmlArchivos xml = new ClsXmlArchivos();
                xml.PutInTempFile();
                conf.Leer();
                xml.DeleteXmlConTemp();
                configuracionCargada = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static string NombreVisible(ConexionServidor s, int indice)
        {
            return string.IsNullOrWhiteSpace(s.Nombre) ? $"Servidor {indice + 1}" : s.Nombre.Trim();
        }

        private static string ColorAHex(Color c)
        {
            return $"#{c.R:X2}{c.G:X2}{c.B:X2}";
        }

        /// <summary>Recarga el combobox con los servidores guardados y muestra el indicado.</summary>
        private void LlenarCombo(int seleccionar)
        {
            cargandoUI = true;
            try
            {
                cmbServidores.Items.Clear();
                for (int i = 0; i < ClsConfig.Servidores.Count; i++)
                    cmbServidores.Items.Add(NombreVisible(ClsConfig.Servidores[i], i));

                seleccionar = Math.Min(Math.Max(seleccionar, 0), ClsConfig.Servidores.Count - 1);
                cmbServidores.SelectedIndex = seleccionar;
                indiceSeleccionado = seleccionar;
            }
            finally
            {
                cargandoUI = false;
            }

            MostrarServidor(indiceSeleccionado);
            MostrarServidorActivo();
        }

        /// <summary>Muestra en la tarjeta los parámetros del servidor indicado.</summary>
        private void MostrarServidor(int indice)
        {
            ConexionServidor s = ClsConfig.Servidores[indice];
            bool esActivo = indice + 1 == ClsConfig.NumeroServidorActivo;

            txbNombre.Text = NombreVisible(s, indice);
            txbServer.Text = s.Server ?? "";
            txbBdConn.Text = s.DbConn ?? "";
            txbUserConn.Text = s.UserConn ?? "";
            txbPassConn.Text = s.PassConn ?? "";
            txbBdWrite.Text = s.DbWrite ?? "";
            txbUserWrite.Text = s.UserWrite ?? "";
            txbPassWrite.Text = s.PassWrite ?? "";
            txbDbEmployees.Text = s.DbEmployees ?? "";

            colorServidor.Value = s.ObtenerColor();
            pnlHead.Back = s.ObtenerColor();
            lblTitulo.Text = NombreVisible(s, indice);
            lblColorAyuda.Text = indice == 0
                ? "Servidor 1: la imagen de inicio no se tiñe."
                : "Tiñe la imagen de la pantalla de inicio.";

            tagEnUso.Visible = esActivo;
            btnUsar.Visible = !esActivo;
            btnEliminar.Enabled = ClsConfig.Servidores.Count > 1;
        }

        /// <summary>Indicador superior: nombre y color del servidor en uso.</summary>
        private void MostrarServidorActivo()
        {
            ConexionServidor activo = ClsConfig.ServidorActivo;
            Color color = activo.ObtenerColor();
            string texto = "●  " + NombreVisible(activo, ClsConfig.NumeroServidorActivo - 1);

            tagIndicador.Text = texto;
            tagIndicador.BackColor = GraficosLogin.Mezclar(color, Color.White, 0.85F);
            tagIndicador.ForeColor = GraficosLogin.Mezclar(color, Color.Black, 0.30F);

            int ancho = TextRenderer.MeasureText(texto, tagIndicador.Font).Width + 36;
            tagIndicador.Width = Math.Min(Math.Max(ancho, 120), 290);
        }

        private void colorServidor_ValueChanged(object? sender, EventArgs e)
        {
            if (cargandoUI)
                return;
            pnlHead.Back = colorServidor.Value;
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

        // ------------------------------------------------------------------ edición

        private bool Igual(ConexionServidor s, int indice)
        {
            return NombreVisible(s, indice) == txbNombre.Text.Trim()
                && (s.Server ?? "") == txbServer.Text
                && (s.DbConn ?? "") == txbBdConn.Text
                && (s.UserConn ?? "") == txbUserConn.Text
                && (s.PassConn ?? "") == txbPassConn.Text
                && (s.DbWrite ?? "") == txbBdWrite.Text
                && (s.UserWrite ?? "") == txbUserWrite.Text
                && (s.PassWrite ?? "") == txbPassWrite.Text
                && (s.DbEmployees ?? "") == txbDbEmployees.Text
                && string.Equals(ColorAHex(s.ObtenerColor()), ColorAHex(colorServidor.Value), StringComparison.OrdinalIgnoreCase);
        }

        private bool HayCambiosSinGuardar()
        {
            if (indiceSeleccionado < 0 || indiceSeleccionado >= ClsConfig.Servidores.Count)
                return false;
            return !Igual(ClsConfig.Servidores[indiceSeleccionado], indiceSeleccionado);
        }

        private bool ConfirmarDescartarCambios()
        {
            if (!HayCambiosSinGuardar())
                return true;

            return MessageBox.Show("Hay cambios sin guardar en el servidor seleccionado. ¿Desea descartarlos?",
                Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private bool VerificarCargada()
        {
            if (configuracionCargada)
                return true;

            MessageBox.Show("No se pudo leer la configuración de conexión.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        private void cmbServidores_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cargandoUI)
                return;

            int nuevo = cmbServidores.SelectedIndex;
            if (nuevo < 0 || nuevo == indiceSeleccionado)
                return;

            // Se pregunta fuera del evento para no interferir con el cierre de la lista desplegable.
            BeginInvoke(new Action(() =>
            {
                if (!ConfirmarDescartarCambios())
                {
                    cargandoUI = true;
                    cmbServidores.SelectedIndex = indiceSeleccionado;
                    cargandoUI = false;
                    return;
                }

                indiceSeleccionado = nuevo;
                MostrarServidor(nuevo);
            }));
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!VerificarCargada() || !ConfirmarDescartarCambios())
                return;

            ConexionServidor nuevo = ClsConfig.NuevoServidor(ClsConfig.Servidores.Count + 1);

            // El nombre debe ser único.
            int numero = ClsConfig.Servidores.Count + 1;
            while (ClsConfig.Servidores.Any((s) => string.Equals(s.Nombre, nuevo.Nombre, StringComparison.OrdinalIgnoreCase)))
                nuevo.Nombre = $"Servidor {++numero}";

            ClsConfig.Servidores.Add(nuevo);
            try
            {
                Persistir();
            }
            catch (Exception ex)
            {
                ClsConfig.Servidores.Remove(nuevo);
                MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LlenarCombo(ClsConfig.Servidores.Count - 1);
            txbNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!VerificarCargada())
                return;

            string nombre = txbNombre.Text.Trim();
            if (nombre.Length == 0)
            {
                MessageBox.Show("Escriba un nombre para identificar el servidor.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txbNombre.Focus();
                return;
            }

            for (int i = 0; i < ClsConfig.Servidores.Count; i++)
            {
                if (i != indiceSeleccionado && string.Equals(NombreVisible(ClsConfig.Servidores[i], i), nombre, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show($"Ya existe otro servidor llamado \"{nombre}\". Use un nombre distinto.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txbNombre.Focus();
                    return;
                }
            }

            try
            {
                bool esActivo = indiceSeleccionado + 1 == ClsConfig.NumeroServidorActivo;
                ConexionServidor s = ClsConfig.Servidores[indiceSeleccionado];
                s.Nombre = nombre;
                s.Color = ColorAHex(colorServidor.Value);
                s.Server = txbServer.Text;
                s.DbConn = txbBdConn.Text;
                s.UserConn = txbUserConn.Text;
                s.PassConn = txbPassConn.Text;
                s.DbWrite = txbBdWrite.Text;
                s.UserWrite = txbUserWrite.Text;
                s.PassWrite = txbPassWrite.Text;
                s.DbEmployees = txbDbEmployees.Text;
                Persistir();

                if (esActivo)
                {
                    MessageBox.Show($"Servidor \"{nombre}\" guardado. Se reiniciará la aplicación.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Restart();
                    return;
                }

                MessageBox.Show($"Servidor \"{nombre}\" guardado.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                LlenarCombo(indiceSeleccionado);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUsar_Click(object sender, EventArgs e)
        {
            if (!VerificarCargada())
                return;

            int nuevo = indiceSeleccionado + 1;
            if (nuevo == ClsConfig.NumeroServidorActivo)
                return;

            string nombre = NombreVisible(ClsConfig.Servidores[indiceSeleccionado], indiceSeleccionado);
            string mensaje = HayCambiosSinGuardar()
                ? $"Hay cambios sin guardar. Se perderán y la aplicación operará en \"{nombre}\" al reiniciar. ¿Desea continuar?"
                : $"La aplicación operará en \"{nombre}\" y se reiniciará. ¿Desea continuar?";
            if (MessageBox.Show(mensaje, Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            int anterior = ClsConfig.NumeroServidorActivo;
            try
            {
                ClsConfig.CurrentServer = nuevo;
                SQLControl.currentServer = nuevo;
                Persistir();
                Application.Restart();
            }
            catch (Exception ex)
            {
                ClsConfig.CurrentServer = anterior;
                SQLControl.currentServer = anterior;
                ClsConfig.AplicarServidorActivo();
                MostrarServidorActivo();
                MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!VerificarCargada())
                return;

            if (ClsConfig.Servidores.Count <= 1)
            {
                MessageBox.Show("Debe existir al menos un servidor configurado.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (indiceSeleccionado + 1 == ClsConfig.NumeroServidorActivo)
            {
                MessageBox.Show("No se puede eliminar el servidor que está en uso. Seleccione otro y use \"Usar este servidor\" primero.",
                    Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ConexionServidor s = ClsConfig.Servidores[indiceSeleccionado];
            string nombre = NombreVisible(s, indiceSeleccionado);
            if (MessageBox.Show($"¿Eliminar el servidor \"{nombre}\"? Esta acción no se puede deshacer.",
                Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            int indice = indiceSeleccionado;
            int activo = ClsConfig.NumeroServidorActivo;
            try
            {
                ClsConfig.Servidores.RemoveAt(indice);
                if (indice + 1 < activo)
                    ClsConfig.CurrentServer = activo - 1;      // el servidor en uso se recorre una posición
                SQLControl.currentServer = ClsConfig.NumeroServidorActivo;
                Persistir();
                LlenarCombo(Math.Min(indice, ClsConfig.Servidores.Count - 1));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cargar();
                LlenarCombo(ClsConfig.NumeroServidorActivo - 1);
            }
        }

        /// <summary>Escribe en el archivo cifrado de configuración toda la lista de servidores.</summary>
        private void Persistir()
        {
            ClsXmlArchivos xml = new ClsXmlArchivos();
            xml.PutInTempFile();
            ClsConfig.AplicarServidorActivo();
            conf.Guardar();
            xml.PutInConfFile();
        }

        // ------------------------------------------------------------------ exportar / importar

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (HayCambiosSinGuardar() &&
                MessageBox.Show("Hay cambios sin guardar que no se incluirán en el archivo exportado. ¿Desea continuar?",
                    Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            using SaveFileDialog dialogo = new SaveFileDialog
            {
                Title = "Exportar configuración de conexiones",
                Filter = "Archivo de configuración SisUvex (*.xml)|*.xml",
                DefaultExt = "xml",
                AddExtension = true,
                OverwritePrompt = true,
                FileName = ClsXmlArchivos.NombreArchivoConfiguracion,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            };

            if (dialogo.ShowDialog(this) != DialogResult.OK)
                return;

            try
            {
                ClsXmlArchivos.ExportarConfiguracion(dialogo.FileName);
                MessageBox.Show($"Configuración exportada correctamente:\n{dialogo.FileName}", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo exportar la configuración.\n{ex.Message}", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dialogo = new OpenFileDialog
            {
                Title = "Importar configuración de conexiones",
                Filter = "Archivo de configuración SisUvex (*.xml)|*.xml",
                CheckFileExists = true,
                Multiselect = false,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            };

            if (dialogo.ShowDialog(this) != DialogResult.OK)
                return;

            if (!ClsXmlArchivos.ValidarArchivoConfiguracion(dialogo.FileName, out int servidores, out string error))
            {
                MessageBox.Show(error, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string mensaje = $"El archivo contiene {servidores} servidor(es). Reemplazará la configuración actual de este equipo " +
                             $"(se conserva una copia de respaldo) y la aplicación se reiniciará.\n\n¿Desea continuar?";
            if (MessageBox.Show(mensaje, Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                ClsXmlArchivos.ImportarConfiguracion(dialogo.FileName);
                MessageBox.Show("Configuración importada correctamente. Se reiniciará la aplicación.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Restart();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo importar la configuración.\n{ex.Message}", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ------------------------------------------------------------------ pruebas de conexión (no guardan ni cierran)

        private void btnLectura_Click(object sender, EventArgs e)
        {
            Probar("Lectura", txbServer.Text, txbBdConn.Text, txbUserConn.Text, txbPassConn.Text);
        }

        private void btnEscritura_Click(object sender, EventArgs e)
        {
            Probar("Escritura", txbServer.Text, txbBdWrite.Text, txbUserWrite.Text, txbPassWrite.Text);
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            Probar("Empleados", txbServer.Text, txbDbEmployees.Text, txbUserWrite.Text, txbPassWrite.Text);
        }

        private void Probar(string baseDatos, string svr, string bd, string user, string pass)
        {
            string titulo = $"{txbNombre.Text.Trim()} · {baseDatos}";
            string cadenaConexion = $"Data Source = {svr}; Initial Catalog = {bd};TrustServerCertificate=true; Persist Security Info = True; User ID = {user}; Password = {pass}";
            using SqlConnection connection = new SqlConnection(cadenaConexion);
            try
            {
                connection.Open();
                MessageBox.Show($"Conexión exitosa a SQL Server.\n{titulo}", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar conectar ({titulo}): {ex.Message}", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmConfiguracion_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && isFrmLoginScreen)
            {
                Application.Exit();
            }
        }
    }
}
