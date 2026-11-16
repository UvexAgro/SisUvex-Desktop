namespace SisUvex.Configuracion
{
    partial class FrmConfiguracion
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfiguracion));
            pnlBarra = new AntdUI.Panel();
            lblEntorno = new AntdUI.Label();
            tagIndicador = new AntdUI.Tag();
            btnImportar = new AntdUI.Button();
            btnExportar = new AntdUI.Button();
            lblSeleccionado = new AntdUI.Label();
            cmbServidores = new SelectorServidores();
            btnAgregar = new AntdUI.Button();
            pnlServidor = new AntdUI.Panel();
            txbServer = new AntdUI.Input();
            txbNombre = new AntdUI.Input();
            btnEliminar = new AntdUI.Button();
            tagEnUso = new AntdUI.Tag();
            pnlColor = new AntdUI.Panel();
            lblColorTitulo = new AntdUI.Label();
            colorServidor = new AntdUI.ColorPicker();
            lblColorAyuda = new AntdUI.Label();
            btnUsar = new AntdUI.Button();
            pnlEmpleados = new AntdUI.Panel();
            txbDbEmployees = new AntdUI.Input();
            lblEmpleados = new AntdUI.Label();
            lblBdEmp = new AntdUI.Label();
            btnEmpleados = new AntdUI.Button();
            pnlEscritura = new AntdUI.Panel();
            txbBdWrite = new AntdUI.Input();
            txbUserWrite = new AntdUI.Input();
            txbPassWrite = new AntdUI.Input();
            lblEscritura = new AntdUI.Label();
            lblBdWrite = new AntdUI.Label();
            lblUserWrite = new AntdUI.Label();
            lblPassWrite = new AntdUI.Label();
            btnEscritura = new AntdUI.Button();
            pnlLectura = new AntdUI.Panel();
            txbBdConn = new AntdUI.Input();
            txbUserConn = new AntdUI.Input();
            txbPassConn = new AntdUI.Input();
            lblLectura = new AntdUI.Label();
            lblBdConn = new AntdUI.Label();
            lblUserConn = new AntdUI.Label();
            lblPassConn = new AntdUI.Label();
            btnLectura = new AntdUI.Button();
            btnGuardar = new AntdUI.Button();
            lblNombre = new AntdUI.Label();
            pnlHead = new AntdUI.Panel();
            picDb = new PictureBox();
            pnlSep = new AntdUI.Panel();
            lblTitulo = new AntdUI.Label();
            lblServer = new AntdUI.Label();
            pnlBarra.SuspendLayout();
            pnlServidor.SuspendLayout();
            pnlColor.SuspendLayout();
            pnlEmpleados.SuspendLayout();
            pnlEscritura.SuspendLayout();
            pnlLectura.SuspendLayout();
            pnlHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picDb).BeginInit();
            SuspendLayout();
            // 
            // pnlBarra
            // 
            pnlBarra.Back = Color.White;
            pnlBarra.BorderColor = Color.FromArgb(228, 228, 238);
            pnlBarra.BorderWidth = 1F;
            pnlBarra.Controls.Add(tagIndicador);
            pnlBarra.Controls.Add(lblEntorno);
            pnlBarra.Controls.Add(btnImportar);
            pnlBarra.Controls.Add(btnExportar);
            pnlBarra.Location = new Point(16, 12);
            pnlBarra.Name = "pnlBarra";
            pnlBarra.Radius = 10;
            pnlBarra.Size = new Size(668, 48);
            pnlBarra.TabIndex = 0;
            // 
            // lblEntorno
            // 
            lblEntorno.BackColor = Color.Transparent;
            lblEntorno.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblEntorno.ForeColor = Color.FromArgb(30, 41, 59);
            lblEntorno.Location = new Point(16, 10);
            lblEntorno.Name = "lblEntorno";
            lblEntorno.Size = new Size(130, 28);
            lblEntorno.TabIndex = 0;
            lblEntorno.Text = "Servidor activo";
            // 
            // tagIndicador
            // 
            tagIndicador.BackColor = Color.FromArgb(232, 246, 229);
            tagIndicador.BorderWidth = 0F;
            tagIndicador.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            tagIndicador.ForeColor = Color.FromArgb(47, 125, 40);
            tagIndicador.Location = new Point(129, 10);
            tagIndicador.Name = "tagIndicador";
            tagIndicador.Radius = 14;
            tagIndicador.Size = new Size(168, 28);
            tagIndicador.TabIndex = 1;
            tagIndicador.Text = "●  Servidor 1";
            // 
            // btnImportar
            // 
            btnImportar.BorderWidth = 1.5F;
            btnImportar.Cursor = Cursors.Hand;
            btnImportar.DefaultBack = Color.White;
            btnImportar.DefaultBorderColor = Color.FromArgb(122, 44, 166);
            btnImportar.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnImportar.ForeColor = Color.FromArgb(122, 44, 166);
            btnImportar.Location = new Point(452, 8);
            btnImportar.Name = "btnImportar";
            btnImportar.Radius = 16;
            btnImportar.Size = new Size(98, 32);
            btnImportar.TabIndex = 2;
            btnImportar.Text = "Importar";
            btnImportar.Click += btnImportar_Click;
            // 
            // btnExportar
            // 
            btnExportar.BorderWidth = 1.5F;
            btnExportar.Cursor = Cursors.Hand;
            btnExportar.DefaultBack = Color.White;
            btnExportar.DefaultBorderColor = Color.FromArgb(122, 44, 166);
            btnExportar.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnExportar.ForeColor = Color.FromArgb(122, 44, 166);
            btnExportar.Location = new Point(558, 8);
            btnExportar.Name = "btnExportar";
            btnExportar.Radius = 16;
            btnExportar.Size = new Size(98, 32);
            btnExportar.TabIndex = 3;
            btnExportar.Text = "Exportar";
            btnExportar.Click += btnExportar_Click;
            // 
            // lblSeleccionado
            // 
            lblSeleccionado.BackColor = Color.Transparent;
            lblSeleccionado.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblSeleccionado.ForeColor = Color.FromArgb(30, 41, 59);
            lblSeleccionado.Location = new Point(18, 71);
            lblSeleccionado.Name = "lblSeleccionado";
            lblSeleccionado.Size = new Size(180, 36);
            lblSeleccionado.TabIndex = 1;
            lblSeleccionado.Text = "Servidor seleccionado";
            // 
            // cmbServidores
            // 
            cmbServidores.BorderColor = Color.FromArgb(206, 212, 224);
            cmbServidores.Font = new Font("Segoe UI", 10.5F);
            cmbServidores.Location = new Point(164, 72);
            cmbServidores.Name = "cmbServidores";
            cmbServidores.Size = new Size(357, 36);
            cmbServidores.TabIndex = 2;
            cmbServidores.UseContextMenu = false;
            cmbServidores.SelectedIndexChanged += cmbServidores_SelectedIndexChanged;
            // 
            // btnAgregar
            // 
            btnAgregar.BorderWidth = 1.5F;
            btnAgregar.Cursor = Cursors.Hand;
            btnAgregar.DefaultBack = Color.FromArgb(237, 226, 250);
            btnAgregar.DefaultBorderColor = Color.FromArgb(122, 44, 166);
            btnAgregar.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnAgregar.ForeColor = Color.FromArgb(122, 44, 166);
            btnAgregar.Location = new Point(527, 70);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Radius = 10;
            btnAgregar.Size = new Size(157, 40);
            btnAgregar.TabIndex = 3;
            btnAgregar.Text = "+  Agregar servidor";
            btnAgregar.Click += btnAgregar_Click;
            // 
            // pnlServidor
            // 
            pnlServidor.Back = Color.White;
            pnlServidor.BorderColor = Color.FromArgb(228, 228, 238);
            pnlServidor.BorderWidth = 1F;
            pnlServidor.Controls.Add(txbServer);
            pnlServidor.Controls.Add(txbNombre);
            pnlServidor.Controls.Add(btnEliminar);
            pnlServidor.Controls.Add(tagEnUso);
            pnlServidor.Controls.Add(pnlColor);
            pnlServidor.Controls.Add(btnUsar);
            pnlServidor.Controls.Add(pnlEmpleados);
            pnlServidor.Controls.Add(pnlEscritura);
            pnlServidor.Controls.Add(pnlLectura);
            pnlServidor.Controls.Add(btnGuardar);
            pnlServidor.Controls.Add(lblNombre);
            pnlServidor.Controls.Add(pnlHead);
            pnlServidor.Controls.Add(lblServer);
            pnlServidor.Location = new Point(16, 124);
            pnlServidor.Name = "pnlServidor";
            pnlServidor.Radius = 10;
            pnlServidor.Size = new Size(668, 453);
            pnlServidor.TabIndex = 4;
            // 
            // txbServer
            // 
            txbServer.BorderColor = Color.FromArgb(206, 212, 224);
            txbServer.Font = new Font("Segoe UI", 9F);
            txbServer.Location = new Point(110, 96);
            txbServer.Name = "txbServer";
            txbServer.Size = new Size(256, 30);
            txbServer.TabIndex = 4;
            // 
            // txbNombre
            // 
            txbNombre.BorderColor = Color.FromArgb(206, 212, 224);
            txbNombre.Font = new Font("Segoe UI", 9F);
            txbNombre.Location = new Point(110, 60);
            txbNombre.Name = "txbNombre";
            txbNombre.Size = new Size(256, 30);
            txbNombre.TabIndex = 2;
            // 
            // btnEliminar
            // 
            btnEliminar.BorderWidth = 1F;
            btnEliminar.Cursor = Cursors.Hand;
            btnEliminar.DefaultBack = Color.White;
            btnEliminar.DefaultBorderColor = Color.FromArgb(214, 48, 49);
            btnEliminar.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnEliminar.ForeColor = Color.FromArgb(214, 48, 49);
            btnEliminar.Location = new Point(16, 410);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(170, 36);
            btnEliminar.TabIndex = 9;
            btnEliminar.Text = "Eliminar servidor";
            btnEliminar.Click += btnEliminar_Click;
            // 
            // tagEnUso
            // 
            tagEnUso.BackColor = Color.FromArgb(240, 230, 250);
            tagEnUso.BorderWidth = 0F;
            tagEnUso.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            tagEnUso.ForeColor = Color.FromArgb(122, 44, 166);
            tagEnUso.Location = new Point(572, 55);
            tagEnUso.Name = "tagEnUso";
            tagEnUso.Radius = 12;
            tagEnUso.Size = new Size(84, 26);
            tagEnUso.TabIndex = 3;
            tagEnUso.Text = "En uso";
            // 
            // pnlColor
            // 
            pnlColor.Back = Color.FromArgb(250, 250, 254);
            pnlColor.BorderColor = Color.FromArgb(228, 228, 238);
            pnlColor.BorderWidth = 1F;
            pnlColor.Controls.Add(lblColorTitulo);
            pnlColor.Controls.Add(colorServidor);
            pnlColor.Controls.Add(lblColorAyuda);
            pnlColor.Location = new Point(334, 306);
            pnlColor.Name = "pnlColor";
            pnlColor.Radius = 8;
            pnlColor.Size = new Size(318, 98);
            pnlColor.TabIndex = 8;
            // 
            // lblColorTitulo
            // 
            lblColorTitulo.BackColor = Color.Transparent;
            lblColorTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblColorTitulo.ForeColor = Color.FromArgb(122, 44, 166);
            lblColorTitulo.Location = new Point(12, 6);
            lblColorTitulo.Name = "lblColorTitulo";
            lblColorTitulo.Size = new Size(153, 22);
            lblColorTitulo.TabIndex = 0;
            lblColorTitulo.Text = "Color del servidor";
            // 
            // colorServidor
            // 
            colorServidor.Location = new Point(12, 34);
            colorServidor.Name = "colorServidor";
            colorServidor.ShowText = true;
            colorServidor.Size = new Size(150, 32);
            colorServidor.TabIndex = 1;
            // 
            // lblColorAyuda
            // 
            lblColorAyuda.BackColor = Color.Transparent;
            lblColorAyuda.Font = new Font("Segoe UI", 8.25F);
            lblColorAyuda.ForeColor = Color.FromArgb(100, 116, 139);
            lblColorAyuda.Location = new Point(12, 68);
            lblColorAyuda.Name = "lblColorAyuda";
            lblColorAyuda.Size = new Size(150, 24);
            lblColorAyuda.TabIndex = 2;
            lblColorAyuda.Text = "Identifica este servidor.";
            // 
            // btnUsar
            // 
            btnUsar.BorderWidth = 1.5F;
            btnUsar.Cursor = Cursors.Hand;
            btnUsar.DefaultBack = Color.FromArgb(150, 84, 190);
            btnUsar.DefaultBorderColor = Color.FromArgb(214, 188, 236);
            btnUsar.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnUsar.ForeColor = Color.White;
            btnUsar.Location = new Point(476, 52);
            btnUsar.Name = "btnUsar";
            btnUsar.Radius = 10;
            btnUsar.Size = new Size(180, 32);
            btnUsar.TabIndex = 4;
            btnUsar.Text = "Usar este servidor";
            btnUsar.Click += btnUsar_Click;
            // 
            // pnlEmpleados
            // 
            pnlEmpleados.Back = Color.FromArgb(250, 250, 254);
            pnlEmpleados.BorderColor = Color.FromArgb(228, 228, 238);
            pnlEmpleados.BorderWidth = 1F;
            pnlEmpleados.Controls.Add(txbDbEmployees);
            pnlEmpleados.Controls.Add(lblEmpleados);
            pnlEmpleados.Controls.Add(lblBdEmp);
            pnlEmpleados.Controls.Add(btnEmpleados);
            pnlEmpleados.Location = new Point(16, 306);
            pnlEmpleados.Name = "pnlEmpleados";
            pnlEmpleados.Radius = 8;
            pnlEmpleados.Size = new Size(312, 98);
            pnlEmpleados.TabIndex = 7;
            // 
            // txbDbEmployees
            // 
            txbDbEmployees.BorderColor = Color.FromArgb(206, 212, 224);
            txbDbEmployees.Font = new Font("Segoe UI", 9F);
            txbDbEmployees.Location = new Point(99, 30);
            txbDbEmployees.Name = "txbDbEmployees";
            txbDbEmployees.Size = new Size(201, 30);
            txbDbEmployees.TabIndex = 2;
            // 
            // lblEmpleados
            // 
            lblEmpleados.BackColor = Color.Transparent;
            lblEmpleados.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblEmpleados.ForeColor = Color.FromArgb(122, 44, 166);
            lblEmpleados.Location = new Point(12, 6);
            lblEmpleados.Name = "lblEmpleados";
            lblEmpleados.Size = new Size(288, 22);
            lblEmpleados.TabIndex = 0;
            lblEmpleados.Text = "Base de datos de empleados";
            // 
            // lblBdEmp
            // 
            lblBdEmp.BackColor = Color.Transparent;
            lblBdEmp.Font = new Font("Segoe UI", 9F);
            lblBdEmp.ForeColor = Color.FromArgb(51, 65, 85);
            lblBdEmp.Location = new Point(12, 32);
            lblBdEmp.Name = "lblBdEmp";
            lblBdEmp.Size = new Size(108, 26);
            lblBdEmp.TabIndex = 1;
            lblBdEmp.Text = "Base de datos:";
            // 
            // btnEmpleados
            // 
            btnEmpleados.BorderWidth = 1F;
            btnEmpleados.Cursor = Cursors.Hand;
            btnEmpleados.DefaultBack = Color.White;
            btnEmpleados.DefaultBorderColor = Color.FromArgb(206, 212, 224);
            btnEmpleados.ForeColor = Color.FromArgb(51, 65, 85);
            btnEmpleados.Location = new Point(178, 64);
            btnEmpleados.Name = "btnEmpleados";
            btnEmpleados.Size = new Size(122, 30);
            btnEmpleados.TabIndex = 3;
            btnEmpleados.Text = "Probar conexión";
            btnEmpleados.Click += btnEmpleados_Click;
            // 
            // pnlEscritura
            // 
            pnlEscritura.Back = Color.FromArgb(250, 250, 254);
            pnlEscritura.BorderColor = Color.FromArgb(228, 228, 238);
            pnlEscritura.BorderWidth = 1F;
            pnlEscritura.Controls.Add(txbBdWrite);
            pnlEscritura.Controls.Add(txbUserWrite);
            pnlEscritura.Controls.Add(txbPassWrite);
            pnlEscritura.Controls.Add(lblEscritura);
            pnlEscritura.Controls.Add(lblBdWrite);
            pnlEscritura.Controls.Add(lblUserWrite);
            pnlEscritura.Controls.Add(lblPassWrite);
            pnlEscritura.Controls.Add(btnEscritura);
            pnlEscritura.Location = new Point(334, 138);
            pnlEscritura.Name = "pnlEscritura";
            pnlEscritura.Radius = 8;
            pnlEscritura.Size = new Size(318, 162);
            pnlEscritura.TabIndex = 6;
            // 
            // txbBdWrite
            // 
            txbBdWrite.BorderColor = Color.FromArgb(206, 212, 224);
            txbBdWrite.Font = new Font("Segoe UI", 9F);
            txbBdWrite.Location = new Point(99, 30);
            txbBdWrite.Name = "txbBdWrite";
            txbBdWrite.Size = new Size(207, 30);
            txbBdWrite.TabIndex = 2;
            // 
            // txbUserWrite
            // 
            txbUserWrite.BorderColor = Color.FromArgb(206, 212, 224);
            txbUserWrite.Font = new Font("Segoe UI", 9F);
            txbUserWrite.Location = new Point(99, 62);
            txbUserWrite.Name = "txbUserWrite";
            txbUserWrite.Size = new Size(207, 30);
            txbUserWrite.TabIndex = 4;
            // 
            // txbPassWrite
            // 
            txbPassWrite.BorderColor = Color.FromArgb(206, 212, 224);
            txbPassWrite.Font = new Font("Segoe UI", 9F);
            txbPassWrite.Location = new Point(99, 94);
            txbPassWrite.Name = "txbPassWrite";
            txbPassWrite.Size = new Size(207, 30);
            txbPassWrite.TabIndex = 6;
            txbPassWrite.UseSystemPasswordChar = true;
            // 
            // lblEscritura
            // 
            lblEscritura.BackColor = Color.Transparent;
            lblEscritura.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblEscritura.ForeColor = Color.FromArgb(122, 44, 166);
            lblEscritura.Location = new Point(12, 6);
            lblEscritura.Name = "lblEscritura";
            lblEscritura.Size = new Size(612, 22);
            lblEscritura.TabIndex = 0;
            lblEscritura.Text = "Escritura";
            // 
            // lblBdWrite
            // 
            lblBdWrite.BackColor = Color.Transparent;
            lblBdWrite.Font = new Font("Segoe UI", 9F);
            lblBdWrite.ForeColor = Color.FromArgb(51, 65, 85);
            lblBdWrite.Location = new Point(12, 32);
            lblBdWrite.Name = "lblBdWrite";
            lblBdWrite.Size = new Size(108, 26);
            lblBdWrite.TabIndex = 1;
            lblBdWrite.Text = "Base de datos:";
            // 
            // lblUserWrite
            // 
            lblUserWrite.BackColor = Color.Transparent;
            lblUserWrite.Font = new Font("Segoe UI", 9F);
            lblUserWrite.ForeColor = Color.FromArgb(51, 65, 85);
            lblUserWrite.Location = new Point(12, 64);
            lblUserWrite.Name = "lblUserWrite";
            lblUserWrite.Size = new Size(108, 26);
            lblUserWrite.TabIndex = 3;
            lblUserWrite.Text = "Usuario:";
            // 
            // lblPassWrite
            // 
            lblPassWrite.BackColor = Color.Transparent;
            lblPassWrite.Font = new Font("Segoe UI", 9F);
            lblPassWrite.ForeColor = Color.FromArgb(51, 65, 85);
            lblPassWrite.Location = new Point(12, 96);
            lblPassWrite.Name = "lblPassWrite";
            lblPassWrite.Size = new Size(108, 26);
            lblPassWrite.TabIndex = 5;
            lblPassWrite.Text = "Contraseña:";
            // 
            // btnEscritura
            // 
            btnEscritura.BorderWidth = 1F;
            btnEscritura.Cursor = Cursors.Hand;
            btnEscritura.DefaultBack = Color.White;
            btnEscritura.DefaultBorderColor = Color.FromArgb(206, 212, 224);
            btnEscritura.ForeColor = Color.FromArgb(51, 65, 85);
            btnEscritura.Location = new Point(184, 128);
            btnEscritura.Name = "btnEscritura";
            btnEscritura.Size = new Size(122, 30);
            btnEscritura.TabIndex = 7;
            btnEscritura.Text = "Probar conexión";
            btnEscritura.Click += btnEscritura_Click;
            // 
            // pnlLectura
            // 
            pnlLectura.Back = Color.FromArgb(250, 250, 254);
            pnlLectura.BorderColor = Color.FromArgb(228, 228, 238);
            pnlLectura.BorderWidth = 1F;
            pnlLectura.Controls.Add(txbBdConn);
            pnlLectura.Controls.Add(txbUserConn);
            pnlLectura.Controls.Add(txbPassConn);
            pnlLectura.Controls.Add(lblLectura);
            pnlLectura.Controls.Add(lblBdConn);
            pnlLectura.Controls.Add(lblUserConn);
            pnlLectura.Controls.Add(lblPassConn);
            pnlLectura.Controls.Add(btnLectura);
            pnlLectura.Location = new Point(16, 138);
            pnlLectura.Name = "pnlLectura";
            pnlLectura.Radius = 8;
            pnlLectura.Size = new Size(312, 162);
            pnlLectura.TabIndex = 5;
            // 
            // txbBdConn
            // 
            txbBdConn.BorderColor = Color.FromArgb(206, 212, 224);
            txbBdConn.Font = new Font("Segoe UI", 9F);
            txbBdConn.Location = new Point(99, 30);
            txbBdConn.Name = "txbBdConn";
            txbBdConn.Size = new Size(201, 30);
            txbBdConn.TabIndex = 2;
            // 
            // txbUserConn
            // 
            txbUserConn.BorderColor = Color.FromArgb(206, 212, 224);
            txbUserConn.Font = new Font("Segoe UI", 9F);
            txbUserConn.Location = new Point(99, 62);
            txbUserConn.Name = "txbUserConn";
            txbUserConn.Size = new Size(201, 30);
            txbUserConn.TabIndex = 4;
            // 
            // txbPassConn
            // 
            txbPassConn.BorderColor = Color.FromArgb(206, 212, 224);
            txbPassConn.Font = new Font("Segoe UI", 9F);
            txbPassConn.Location = new Point(99, 94);
            txbPassConn.Name = "txbPassConn";
            txbPassConn.Size = new Size(201, 30);
            txbPassConn.TabIndex = 6;
            txbPassConn.UseSystemPasswordChar = true;
            // 
            // lblLectura
            // 
            lblLectura.BackColor = Color.Transparent;
            lblLectura.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblLectura.ForeColor = Color.FromArgb(122, 44, 166);
            lblLectura.Location = new Point(12, 6);
            lblLectura.Name = "lblLectura";
            lblLectura.Size = new Size(612, 22);
            lblLectura.TabIndex = 0;
            lblLectura.Text = "Lectura";
            // 
            // lblBdConn
            // 
            lblBdConn.BackColor = Color.Transparent;
            lblBdConn.Font = new Font("Segoe UI", 9F);
            lblBdConn.ForeColor = Color.FromArgb(51, 65, 85);
            lblBdConn.Location = new Point(12, 32);
            lblBdConn.Name = "lblBdConn";
            lblBdConn.Size = new Size(108, 26);
            lblBdConn.TabIndex = 1;
            lblBdConn.Text = "Base de datos:";
            // 
            // lblUserConn
            // 
            lblUserConn.BackColor = Color.Transparent;
            lblUserConn.Font = new Font("Segoe UI", 9F);
            lblUserConn.ForeColor = Color.FromArgb(51, 65, 85);
            lblUserConn.Location = new Point(12, 64);
            lblUserConn.Name = "lblUserConn";
            lblUserConn.Size = new Size(108, 26);
            lblUserConn.TabIndex = 3;
            lblUserConn.Text = "Usuario:";
            // 
            // lblPassConn
            // 
            lblPassConn.BackColor = Color.Transparent;
            lblPassConn.Font = new Font("Segoe UI", 9F);
            lblPassConn.ForeColor = Color.FromArgb(51, 65, 85);
            lblPassConn.Location = new Point(12, 96);
            lblPassConn.Name = "lblPassConn";
            lblPassConn.Size = new Size(108, 26);
            lblPassConn.TabIndex = 5;
            lblPassConn.Text = "Contraseña:";
            // 
            // btnLectura
            // 
            btnLectura.BorderWidth = 1F;
            btnLectura.Cursor = Cursors.Hand;
            btnLectura.DefaultBack = Color.White;
            btnLectura.DefaultBorderColor = Color.FromArgb(206, 212, 224);
            btnLectura.ForeColor = Color.FromArgb(51, 65, 85);
            btnLectura.Location = new Point(178, 128);
            btnLectura.Name = "btnLectura";
            btnLectura.Size = new Size(122, 30);
            btnLectura.TabIndex = 7;
            btnLectura.Text = "Probar conexión";
            btnLectura.Click += btnLectura_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackActive = Color.FromArgb(100, 34, 146);
            btnGuardar.BackColor = Color.FromArgb(122, 44, 166);
            btnGuardar.BackHover = Color.FromArgb(140, 66, 186);
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(438, 410);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(210, 36);
            btnGuardar.TabIndex = 10;
            btnGuardar.Text = "Guardar cambios";
            btnGuardar.Type = AntdUI.TTypeMini.Primary;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // lblNombre
            // 
            lblNombre.BackColor = Color.Transparent;
            lblNombre.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNombre.ForeColor = Color.FromArgb(51, 65, 85);
            lblNombre.Location = new Point(28, 60);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(80, 30);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre:";
            // 
            // pnlHead
            // 
            pnlHead.Back = Color.FromArgb(122, 44, 166);
            pnlHead.BackColor = Color.Transparent;
            pnlHead.Controls.Add(picDb);
            pnlHead.Controls.Add(pnlSep);
            pnlHead.Controls.Add(lblTitulo);
            pnlHead.Location = new Point(0, 0);
            pnlHead.Name = "pnlHead";
            pnlHead.Radius = 10;
            pnlHead.RadiusAlign = AntdUI.TAlignRound.Top;
            pnlHead.Size = new Size(668, 46);
            pnlHead.TabIndex = 0;
            // 
            // picDb
            // 
            picDb.BackColor = Color.Transparent;
            picDb.Location = new Point(12, 10);
            picDb.Name = "picDb";
            picDb.Size = new Size(30, 26);
            picDb.SizeMode = PictureBoxSizeMode.CenterImage;
            picDb.TabIndex = 0;
            picDb.TabStop = false;
            // 
            // pnlSep
            // 
            pnlSep.Back = Color.FromArgb(255, 255, 255);
            pnlSep.Location = new Point(50, 13);
            pnlSep.Name = "pnlSep";
            pnlSep.Size = new Size(1, 20);
            pnlSep.TabIndex = 1;
            // 
            // lblTitulo
            // 
            lblTitulo.BackColor = Color.Transparent;
            lblTitulo.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(62, 8);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(400, 30);
            lblTitulo.TabIndex = 2;
            lblTitulo.Text = "Servidor 1";
            // 
            // lblServer
            // 
            lblServer.BackColor = Color.Transparent;
            lblServer.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblServer.ForeColor = Color.FromArgb(51, 65, 85);
            lblServer.Location = new Point(28, 96);
            lblServer.Name = "lblServer";
            lblServer.Size = new Size(80, 30);
            lblServer.TabIndex = 3;
            lblServer.Text = "Instancia:";
            // 
            // FrmConfiguracion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 245, 250);
            ClientSize = new Size(700, 594);
            Controls.Add(cmbServidores);
            Controls.Add(pnlBarra);
            Controls.Add(lblSeleccionado);
            Controls.Add(btnAgregar);
            Controls.Add(pnlServidor);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Mode = AntdUI.TAMode.Light;
            Name = "FrmConfiguracion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Configuración de conexiones";
            FormClosing += FrmConfiguracion_FormClosing;
            pnlBarra.ResumeLayout(false);
            pnlServidor.ResumeLayout(false);
            pnlColor.ResumeLayout(false);
            pnlEmpleados.ResumeLayout(false);
            pnlEscritura.ResumeLayout(false);
            pnlLectura.ResumeLayout(false);
            pnlHead.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picDb).EndInit();
            ResumeLayout(false);
        }

        private AntdUI.Panel pnlBarra;
        private AntdUI.Label lblEntorno;
        private AntdUI.Tag tagIndicador;
        private AntdUI.Button btnImportar;
        private AntdUI.Button btnExportar;
        private AntdUI.Label lblSeleccionado;
        private SelectorServidores cmbServidores;
        private AntdUI.Button btnAgregar;
        private AntdUI.Panel pnlServidor;
        private AntdUI.Panel pnlHead;
        private PictureBox picDb;
        private AntdUI.Panel pnlSep;
        private AntdUI.Label lblTitulo;
        private AntdUI.Tag tagEnUso;
        private AntdUI.Button btnUsar;
        private AntdUI.Label lblNombre;
        private AntdUI.Input txbNombre;
        private AntdUI.Label lblServer;
        private AntdUI.Input txbServer;
        private AntdUI.Panel pnlLectura;
        private AntdUI.Label lblLectura;
        private AntdUI.Label lblBdConn;
        private AntdUI.Input txbBdConn;
        private AntdUI.Label lblUserConn;
        private AntdUI.Input txbUserConn;
        private AntdUI.Label lblPassConn;
        private AntdUI.Input txbPassConn;
        private AntdUI.Button btnLectura;
        private AntdUI.Panel pnlEscritura;
        private AntdUI.Label lblEscritura;
        private AntdUI.Label lblBdWrite;
        private AntdUI.Input txbBdWrite;
        private AntdUI.Label lblUserWrite;
        private AntdUI.Input txbUserWrite;
        private AntdUI.Label lblPassWrite;
        private AntdUI.Input txbPassWrite;
        private AntdUI.Button btnEscritura;
        private AntdUI.Panel pnlEmpleados;
        private AntdUI.Label lblEmpleados;
        private AntdUI.Label lblBdEmp;
        private AntdUI.Input txbDbEmployees;
        private AntdUI.Button btnEmpleados;
        private AntdUI.Panel pnlColor;
        private AntdUI.Label lblColorTitulo;
        private AntdUI.ColorPicker colorServidor;
        private AntdUI.Label lblColorAyuda;
        private AntdUI.Button btnEliminar;
        private AntdUI.Button btnGuardar;
    }
}
