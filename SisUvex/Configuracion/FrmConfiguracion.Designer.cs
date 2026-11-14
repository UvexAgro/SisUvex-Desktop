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
            btnCambiar = new AntdUI.Button();
            pnlServidor1 = new AntdUI.Panel();
            lblServer1 = new AntdUI.Label();
            txbServer1 = new AntdUI.Input();
            pnlLectura1 = new AntdUI.Panel();
            lblLectura1 = new AntdUI.Label();
            lblBdConn1 = new AntdUI.Label();
            txbBdConn1 = new AntdUI.Input();
            lblUserConn1 = new AntdUI.Label();
            txbUserConn1 = new AntdUI.Input();
            lblPassConn1 = new AntdUI.Label();
            txbPassConn1 = new AntdUI.Input();
            btnLectura1 = new AntdUI.Button();
            pnlEscritura1 = new AntdUI.Panel();
            lblEscritura1 = new AntdUI.Label();
            lblBdWrite1 = new AntdUI.Label();
            txbBdWrite1 = new AntdUI.Input();
            lblUserWrite1 = new AntdUI.Label();
            txbUserWrite1 = new AntdUI.Input();
            lblPassWrite1 = new AntdUI.Label();
            txbPassWrite1 = new AntdUI.Input();
            btnEscritura1 = new AntdUI.Button();
            pnlEmpleados1 = new AntdUI.Panel();
            lblEmpleados1 = new AntdUI.Label();
            lblBdEmp1 = new AntdUI.Label();
            txbDbEmployees1 = new AntdUI.Input();
            btnEmpleados1 = new AntdUI.Button();
            btnGuardar1 = new AntdUI.Button();
            pnlServidor2 = new AntdUI.Panel();
            pnlHead2 = new AntdUI.Panel();
            picDb2 = new PictureBox();
            pnlSep2 = new AntdUI.Panel();
            lblTitulo2 = new AntdUI.Label();
            tagEnUso2 = new AntdUI.Tag();
            lblServer2 = new AntdUI.Label();
            txbServer2 = new AntdUI.Input();
            pnlLectura2 = new AntdUI.Panel();
            lblLectura2 = new AntdUI.Label();
            lblBdConn2 = new AntdUI.Label();
            txbBdConn2 = new AntdUI.Input();
            lblUserConn2 = new AntdUI.Label();
            txbUserConn2 = new AntdUI.Input();
            lblPassConn2 = new AntdUI.Label();
            txbPassConn2 = new AntdUI.Input();
            btnLectura2 = new AntdUI.Button();
            pnlEscritura2 = new AntdUI.Panel();
            lblEscritura2 = new AntdUI.Label();
            lblBdWrite2 = new AntdUI.Label();
            txbBdWrite2 = new AntdUI.Input();
            lblUserWrite2 = new AntdUI.Label();
            txbUserWrite2 = new AntdUI.Input();
            lblPassWrite2 = new AntdUI.Label();
            txbPassWrite2 = new AntdUI.Input();
            btnEscritura2 = new AntdUI.Button();
            pnlEmpleados2 = new AntdUI.Panel();
            lblEmpleados2 = new AntdUI.Label();
            lblBdEmp2 = new AntdUI.Label();
            txbDbEmployees2 = new AntdUI.Input();
            btnEmpleados2 = new AntdUI.Button();
            btnGuardar2 = new AntdUI.Button();
            tagEnUso1 = new AntdUI.Tag();
            lblTitulo1 = new AntdUI.Label();
            pnlSep1 = new AntdUI.Panel();
            picDb1 = new PictureBox();
            pnlHead1 = new AntdUI.Panel();
            pnlBarra.SuspendLayout();
            pnlServidor1.SuspendLayout();
            pnlLectura1.SuspendLayout();
            pnlEscritura1.SuspendLayout();
            pnlEmpleados1.SuspendLayout();
            pnlServidor2.SuspendLayout();
            pnlHead2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picDb2).BeginInit();
            pnlLectura2.SuspendLayout();
            pnlEscritura2.SuspendLayout();
            pnlEmpleados2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picDb1).BeginInit();
            pnlHead1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBarra
            // 
            pnlBarra.Back = Color.White;
            pnlBarra.BorderColor = Color.FromArgb(228, 228, 238);
            pnlBarra.BorderWidth = 1F;
            pnlBarra.Controls.Add(tagIndicador);
            pnlBarra.Controls.Add(lblEntorno);
            pnlBarra.Controls.Add(btnCambiar);
            pnlBarra.Location = new Point(16, 12);
            pnlBarra.Name = "pnlBarra";
            pnlBarra.Radius = 10;
            pnlBarra.Size = new Size(930, 48);
            pnlBarra.TabIndex = 0;
            // 
            // lblEntorno
            // 
            lblEntorno.BackColor = Color.Transparent;
            lblEntorno.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblEntorno.ForeColor = Color.FromArgb(30, 41, 59);
            lblEntorno.Location = new Point(16, 10);
            lblEntorno.Name = "lblEntorno";
            lblEntorno.Size = new Size(130, 26);
            lblEntorno.TabIndex = 0;
            lblEntorno.Text = "Entorno activo";
            // 
            // tagIndicador
            // 
            tagIndicador.BackColor = Color.FromArgb(237, 226, 250);
            tagIndicador.BorderWidth = 0F;
            tagIndicador.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            tagIndicador.ForeColor = Color.FromArgb(122, 44, 166);
            tagIndicador.Location = new Point(115, 10);
            tagIndicador.Name = "tagIndicador";
            tagIndicador.Radius = 14;
            tagIndicador.Size = new Size(110, 28);
            tagIndicador.TabIndex = 1;
            tagIndicador.Text = "●  Servidor 1";
            // 
            // btnCambiar
            // 
            btnCambiar.BorderWidth = 1F;
            btnCambiar.Cursor = Cursors.Hand;
            btnCambiar.DefaultBack = Color.FromArgb(232, 246, 229);
            btnCambiar.DefaultBorderColor = Color.FromArgb(72, 158, 44);
            btnCambiar.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnCambiar.ForeColor = Color.FromArgb(47, 125, 40);
            btnCambiar.Location = new Point(760, 8);
            btnCambiar.Name = "btnCambiar";
            btnCambiar.Size = new Size(162, 32);
            btnCambiar.TabIndex = 2;
            btnCambiar.Text = "Cambiar a Servidor 2";
            btnCambiar.Click += btnCambiar_Click;
            // 
            // pnlServidor1
            // 
            pnlServidor1.Back = Color.White;
            pnlServidor1.BorderColor = Color.FromArgb(228, 228, 238);
            pnlServidor1.BorderWidth = 1F;
            pnlServidor1.Controls.Add(txbServer1);
            pnlServidor1.Controls.Add(pnlHead1);
            pnlServidor1.Controls.Add(lblServer1);
            pnlServidor1.Controls.Add(pnlLectura1);
            pnlServidor1.Controls.Add(pnlEscritura1);
            pnlServidor1.Controls.Add(pnlEmpleados1);
            pnlServidor1.Controls.Add(btnGuardar1);
            pnlServidor1.Location = new Point(16, 72);
            pnlServidor1.Name = "pnlServidor1";
            pnlServidor1.Radius = 10;
            pnlServidor1.Size = new Size(462, 582);
            pnlServidor1.TabIndex = 1;
            // 
            // lblServer1
            // 
            lblServer1.BackColor = Color.Transparent;
            lblServer1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblServer1.ForeColor = Color.FromArgb(51, 65, 85);
            lblServer1.Location = new Point(28, 48);
            lblServer1.Name = "lblServer1";
            lblServer1.Size = new Size(90, 26);
            lblServer1.TabIndex = 1;
            lblServer1.Text = "Servidor:";
            // 
            // txbServer1
            // 
            txbServer1.BorderColor = Color.FromArgb(206, 212, 224);
            txbServer1.Font = new Font("Segoe UI", 9F);
            txbServer1.Location = new Point(83, 47);
            txbServer1.Name = "txbServer1";
            txbServer1.Size = new Size(368, 30);
            txbServer1.TabIndex = 2;
            // 
            // pnlLectura1
            // 
            pnlLectura1.Back = Color.FromArgb(250, 250, 254);
            pnlLectura1.BorderColor = Color.FromArgb(228, 228, 238);
            pnlLectura1.BorderWidth = 1F;
            pnlLectura1.Controls.Add(txbBdConn1);
            pnlLectura1.Controls.Add(txbUserConn1);
            pnlLectura1.Controls.Add(txbPassConn1);
            pnlLectura1.Controls.Add(btnLectura1);
            pnlLectura1.Controls.Add(lblLectura1);
            pnlLectura1.Controls.Add(lblBdConn1);
            pnlLectura1.Controls.Add(lblUserConn1);
            pnlLectura1.Controls.Add(lblPassConn1);
            pnlLectura1.Location = new Point(16, 84);
            pnlLectura1.Name = "pnlLectura1";
            pnlLectura1.Radius = 8;
            pnlLectura1.Size = new Size(430, 162);
            pnlLectura1.TabIndex = 3;
            // 
            // lblLectura1
            // 
            lblLectura1.BackColor = Color.Transparent;
            lblLectura1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblLectura1.ForeColor = Color.FromArgb(122, 44, 166);
            lblLectura1.Location = new Point(12, 6);
            lblLectura1.Name = "lblLectura1";
            lblLectura1.Size = new Size(300, 22);
            lblLectura1.TabIndex = 0;
            lblLectura1.Text = "Lectura";
            // 
            // lblBdConn1
            // 
            lblBdConn1.BackColor = Color.Transparent;
            lblBdConn1.Font = new Font("Segoe UI", 9F);
            lblBdConn1.ForeColor = Color.FromArgb(51, 65, 85);
            lblBdConn1.Location = new Point(12, 32);
            lblBdConn1.Name = "lblBdConn1";
            lblBdConn1.Size = new Size(108, 26);
            lblBdConn1.TabIndex = 1;
            lblBdConn1.Text = "Base de datos:";
            // 
            // txbBdConn1
            // 
            txbBdConn1.BorderColor = Color.FromArgb(206, 212, 224);
            txbBdConn1.Font = new Font("Segoe UI", 9F);
            txbBdConn1.Location = new Point(99, 30);
            txbBdConn1.Name = "txbBdConn1";
            txbBdConn1.Size = new Size(324, 30);
            txbBdConn1.TabIndex = 2;
            // 
            // lblUserConn1
            // 
            lblUserConn1.BackColor = Color.Transparent;
            lblUserConn1.Font = new Font("Segoe UI", 9F);
            lblUserConn1.ForeColor = Color.FromArgb(51, 65, 85);
            lblUserConn1.Location = new Point(12, 64);
            lblUserConn1.Name = "lblUserConn1";
            lblUserConn1.Size = new Size(108, 26);
            lblUserConn1.TabIndex = 3;
            lblUserConn1.Text = "Usuario:";
            // 
            // txbUserConn1
            // 
            txbUserConn1.BorderColor = Color.FromArgb(206, 212, 224);
            txbUserConn1.Font = new Font("Segoe UI", 9F);
            txbUserConn1.Location = new Point(99, 62);
            txbUserConn1.Name = "txbUserConn1";
            txbUserConn1.Size = new Size(324, 30);
            txbUserConn1.TabIndex = 4;
            // 
            // lblPassConn1
            // 
            lblPassConn1.BackColor = Color.Transparent;
            lblPassConn1.Font = new Font("Segoe UI", 9F);
            lblPassConn1.ForeColor = Color.FromArgb(51, 65, 85);
            lblPassConn1.Location = new Point(12, 96);
            lblPassConn1.Name = "lblPassConn1";
            lblPassConn1.Size = new Size(108, 26);
            lblPassConn1.TabIndex = 5;
            lblPassConn1.Text = "Contraseña:";
            // 
            // txbPassConn1
            // 
            txbPassConn1.BorderColor = Color.FromArgb(206, 212, 224);
            txbPassConn1.Font = new Font("Segoe UI", 9F);
            txbPassConn1.Location = new Point(99, 94);
            txbPassConn1.Name = "txbPassConn1";
            txbPassConn1.Size = new Size(324, 30);
            txbPassConn1.TabIndex = 6;
            txbPassConn1.UseSystemPasswordChar = true;
            // 
            // btnLectura1
            // 
            btnLectura1.BorderWidth = 1F;
            btnLectura1.Cursor = Cursors.Hand;
            btnLectura1.DefaultBack = Color.White;
            btnLectura1.DefaultBorderColor = Color.FromArgb(206, 212, 224);
            btnLectura1.ForeColor = Color.FromArgb(51, 65, 85);
            btnLectura1.Location = new Point(301, 126);
            btnLectura1.Name = "btnLectura1";
            btnLectura1.Size = new Size(122, 30);
            btnLectura1.TabIndex = 7;
            btnLectura1.Text = "Probar conexión";
            btnLectura1.Click += btnLectura1_Click;
            // 
            // pnlEscritura1
            // 
            pnlEscritura1.Back = Color.FromArgb(250, 250, 254);
            pnlEscritura1.BorderColor = Color.FromArgb(228, 228, 238);
            pnlEscritura1.BorderWidth = 1F;
            pnlEscritura1.Controls.Add(txbBdWrite1);
            pnlEscritura1.Controls.Add(txbUserWrite1);
            pnlEscritura1.Controls.Add(txbPassWrite1);
            pnlEscritura1.Controls.Add(btnEscritura1);
            pnlEscritura1.Controls.Add(lblEscritura1);
            pnlEscritura1.Controls.Add(lblBdWrite1);
            pnlEscritura1.Controls.Add(lblUserWrite1);
            pnlEscritura1.Controls.Add(lblPassWrite1);
            pnlEscritura1.Location = new Point(16, 254);
            pnlEscritura1.Name = "pnlEscritura1";
            pnlEscritura1.Radius = 8;
            pnlEscritura1.Size = new Size(430, 162);
            pnlEscritura1.TabIndex = 4;
            // 
            // lblEscritura1
            // 
            lblEscritura1.BackColor = Color.Transparent;
            lblEscritura1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblEscritura1.ForeColor = Color.FromArgb(122, 44, 166);
            lblEscritura1.Location = new Point(12, 6);
            lblEscritura1.Name = "lblEscritura1";
            lblEscritura1.Size = new Size(300, 22);
            lblEscritura1.TabIndex = 0;
            lblEscritura1.Text = "Escritura";
            // 
            // lblBdWrite1
            // 
            lblBdWrite1.BackColor = Color.Transparent;
            lblBdWrite1.Font = new Font("Segoe UI", 9F);
            lblBdWrite1.ForeColor = Color.FromArgb(51, 65, 85);
            lblBdWrite1.Location = new Point(12, 32);
            lblBdWrite1.Name = "lblBdWrite1";
            lblBdWrite1.Size = new Size(108, 26);
            lblBdWrite1.TabIndex = 1;
            lblBdWrite1.Text = "Base de datos:";
            // 
            // txbBdWrite1
            // 
            txbBdWrite1.BorderColor = Color.FromArgb(206, 212, 224);
            txbBdWrite1.Font = new Font("Segoe UI", 9F);
            txbBdWrite1.Location = new Point(99, 30);
            txbBdWrite1.Name = "txbBdWrite1";
            txbBdWrite1.Size = new Size(324, 30);
            txbBdWrite1.TabIndex = 2;
            // 
            // lblUserWrite1
            // 
            lblUserWrite1.BackColor = Color.Transparent;
            lblUserWrite1.Font = new Font("Segoe UI", 9F);
            lblUserWrite1.ForeColor = Color.FromArgb(51, 65, 85);
            lblUserWrite1.Location = new Point(12, 64);
            lblUserWrite1.Name = "lblUserWrite1";
            lblUserWrite1.Size = new Size(108, 26);
            lblUserWrite1.TabIndex = 3;
            lblUserWrite1.Text = "Usuario:";
            // 
            // txbUserWrite1
            // 
            txbUserWrite1.BorderColor = Color.FromArgb(206, 212, 224);
            txbUserWrite1.Font = new Font("Segoe UI", 9F);
            txbUserWrite1.Location = new Point(99, 62);
            txbUserWrite1.Name = "txbUserWrite1";
            txbUserWrite1.Size = new Size(324, 30);
            txbUserWrite1.TabIndex = 4;
            // 
            // lblPassWrite1
            // 
            lblPassWrite1.BackColor = Color.Transparent;
            lblPassWrite1.Font = new Font("Segoe UI", 9F);
            lblPassWrite1.ForeColor = Color.FromArgb(51, 65, 85);
            lblPassWrite1.Location = new Point(12, 96);
            lblPassWrite1.Name = "lblPassWrite1";
            lblPassWrite1.Size = new Size(108, 26);
            lblPassWrite1.TabIndex = 5;
            lblPassWrite1.Text = "Contraseña:";
            // 
            // txbPassWrite1
            // 
            txbPassWrite1.BorderColor = Color.FromArgb(206, 212, 224);
            txbPassWrite1.Font = new Font("Segoe UI", 9F);
            txbPassWrite1.Location = new Point(99, 94);
            txbPassWrite1.Name = "txbPassWrite1";
            txbPassWrite1.Size = new Size(324, 30);
            txbPassWrite1.TabIndex = 6;
            txbPassWrite1.UseSystemPasswordChar = true;
            // 
            // btnEscritura1
            // 
            btnEscritura1.BorderWidth = 1F;
            btnEscritura1.Cursor = Cursors.Hand;
            btnEscritura1.DefaultBack = Color.White;
            btnEscritura1.DefaultBorderColor = Color.FromArgb(206, 212, 224);
            btnEscritura1.ForeColor = Color.FromArgb(51, 65, 85);
            btnEscritura1.Location = new Point(301, 126);
            btnEscritura1.Name = "btnEscritura1";
            btnEscritura1.Size = new Size(122, 30);
            btnEscritura1.TabIndex = 7;
            btnEscritura1.Text = "Probar conexión";
            btnEscritura1.Click += btnEscritura1_Click;
            // 
            // pnlEmpleados1
            // 
            pnlEmpleados1.Back = Color.FromArgb(250, 250, 254);
            pnlEmpleados1.BorderColor = Color.FromArgb(228, 228, 238);
            pnlEmpleados1.BorderWidth = 1F;
            pnlEmpleados1.Controls.Add(txbDbEmployees1);
            pnlEmpleados1.Controls.Add(btnEmpleados1);
            pnlEmpleados1.Controls.Add(lblEmpleados1);
            pnlEmpleados1.Controls.Add(lblBdEmp1);
            pnlEmpleados1.Location = new Point(16, 424);
            pnlEmpleados1.Name = "pnlEmpleados1";
            pnlEmpleados1.Radius = 8;
            pnlEmpleados1.Size = new Size(430, 98);
            pnlEmpleados1.TabIndex = 5;
            // 
            // lblEmpleados1
            // 
            lblEmpleados1.BackColor = Color.Transparent;
            lblEmpleados1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblEmpleados1.ForeColor = Color.FromArgb(122, 44, 166);
            lblEmpleados1.Location = new Point(12, 6);
            lblEmpleados1.Name = "lblEmpleados1";
            lblEmpleados1.Size = new Size(300, 22);
            lblEmpleados1.TabIndex = 0;
            lblEmpleados1.Text = "Base de datos de empleados";
            // 
            // lblBdEmp1
            // 
            lblBdEmp1.BackColor = Color.Transparent;
            lblBdEmp1.Font = new Font("Segoe UI", 9F);
            lblBdEmp1.ForeColor = Color.FromArgb(51, 65, 85);
            lblBdEmp1.Location = new Point(12, 32);
            lblBdEmp1.Name = "lblBdEmp1";
            lblBdEmp1.Size = new Size(108, 26);
            lblBdEmp1.TabIndex = 1;
            lblBdEmp1.Text = "Base de datos:";
            // 
            // txbDbEmployees1
            // 
            txbDbEmployees1.BorderColor = Color.FromArgb(206, 212, 224);
            txbDbEmployees1.Font = new Font("Segoe UI", 9F);
            txbDbEmployees1.Location = new Point(99, 30);
            txbDbEmployees1.Name = "txbDbEmployees1";
            txbDbEmployees1.Size = new Size(324, 30);
            txbDbEmployees1.TabIndex = 2;
            // 
            // btnEmpleados1
            // 
            btnEmpleados1.BorderWidth = 1F;
            btnEmpleados1.Cursor = Cursors.Hand;
            btnEmpleados1.DefaultBack = Color.White;
            btnEmpleados1.DefaultBorderColor = Color.FromArgb(206, 212, 224);
            btnEmpleados1.ForeColor = Color.FromArgb(51, 65, 85);
            btnEmpleados1.Location = new Point(301, 62);
            btnEmpleados1.Name = "btnEmpleados1";
            btnEmpleados1.Size = new Size(122, 30);
            btnEmpleados1.TabIndex = 3;
            btnEmpleados1.Text = "Probar conexión";
            btnEmpleados1.Click += btnEmpleados1_Click;
            // 
            // btnGuardar1
            // 
            btnGuardar1.BackActive = Color.FromArgb(100, 34, 146);
            btnGuardar1.BackColor = Color.FromArgb(122, 44, 166);
            btnGuardar1.BackHover = Color.FromArgb(140, 66, 186);
            btnGuardar1.Cursor = Cursors.Hand;
            btnGuardar1.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnGuardar1.ForeColor = Color.White;
            btnGuardar1.Location = new Point(239, 534);
            btnGuardar1.Name = "btnGuardar1";
            btnGuardar1.Size = new Size(210, 36);
            btnGuardar1.TabIndex = 6;
            btnGuardar1.Text = "Guardar Servidor 1";
            btnGuardar1.Type = AntdUI.TTypeMini.Primary;
            btnGuardar1.Click += btnGuardar1_Click;
            // 
            // pnlServidor2
            // 
            pnlServidor2.Back = Color.White;
            pnlServidor2.BorderColor = Color.FromArgb(228, 228, 238);
            pnlServidor2.BorderWidth = 1F;
            pnlServidor2.Controls.Add(txbServer2);
            pnlServidor2.Controls.Add(pnlHead2);
            pnlServidor2.Controls.Add(lblServer2);
            pnlServidor2.Controls.Add(pnlLectura2);
            pnlServidor2.Controls.Add(pnlEscritura2);
            pnlServidor2.Controls.Add(pnlEmpleados2);
            pnlServidor2.Controls.Add(btnGuardar2);
            pnlServidor2.Location = new Point(484, 72);
            pnlServidor2.Name = "pnlServidor2";
            pnlServidor2.Radius = 10;
            pnlServidor2.Size = new Size(462, 582);
            pnlServidor2.TabIndex = 2;
            // 
            // pnlHead2
            // 
            pnlHead2.Back = Color.FromArgb(72, 158, 44);
            pnlHead2.Controls.Add(picDb2);
            pnlHead2.Controls.Add(pnlSep2);
            pnlHead2.Controls.Add(lblTitulo2);
            pnlHead2.Controls.Add(tagEnUso2);
            pnlHead2.Location = new Point(0, 0);
            pnlHead2.Name = "pnlHead2";
            pnlHead2.Radius = 10;
            pnlHead2.RadiusAlign = AntdUI.TAlignRound.Top;
            pnlHead2.Size = new Size(462, 40);
            pnlHead2.TabIndex = 0;
            // 
            // picDb2
            // 
            picDb2.BackColor = Color.Transparent;
            picDb2.InitialImage = Properties.Resources.database_50;
            picDb2.Location = new Point(12, 7);
            picDb2.Name = "picDb2";
            picDb2.Size = new Size(30, 26);
            picDb2.SizeMode = PictureBoxSizeMode.CenterImage;
            picDb2.TabIndex = 0;
            picDb2.TabStop = false;
            // 
            // pnlSep2
            // 
            pnlSep2.Back = Color.FromArgb(110, 255, 255, 255);
            pnlSep2.Location = new Point(50, 10);
            pnlSep2.Name = "pnlSep2";
            pnlSep2.Size = new Size(1, 20);
            pnlSep2.TabIndex = 1;
            // 
            // lblTitulo2
            // 
            lblTitulo2.BackColor = Color.FromArgb(72, 158, 44);
            lblTitulo2.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitulo2.ForeColor = Color.White;
            lblTitulo2.Location = new Point(62, 5);
            lblTitulo2.Name = "lblTitulo2";
            lblTitulo2.Size = new Size(200, 30);
            lblTitulo2.TabIndex = 2;
            lblTitulo2.Text = "Servidor 2";
            // 
            // tagEnUso2
            // 
            tagEnUso2.BackColor = Color.FromArgb(231, 244, 226);
            tagEnUso2.BorderWidth = 0F;
            tagEnUso2.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            tagEnUso2.ForeColor = Color.FromArgb(72, 158, 44);
            tagEnUso2.Location = new Point(375, 8);
            tagEnUso2.Name = "tagEnUso2";
            tagEnUso2.Radius = 12;
            tagEnUso2.Size = new Size(72, 24);
            tagEnUso2.TabIndex = 3;
            tagEnUso2.Text = "En uso";
            tagEnUso2.Visible = false;
            // 
            // lblServer2
            // 
            lblServer2.BackColor = Color.Transparent;
            lblServer2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblServer2.ForeColor = Color.FromArgb(51, 65, 85);
            lblServer2.Location = new Point(27, 48);
            lblServer2.Name = "lblServer2";
            lblServer2.Size = new Size(90, 26);
            lblServer2.TabIndex = 1;
            lblServer2.Text = "Servidor:";
            // 
            // txbServer2
            // 
            txbServer2.BorderColor = Color.FromArgb(206, 212, 224);
            txbServer2.Font = new Font("Segoe UI", 9F);
            txbServer2.Location = new Point(82, 48);
            txbServer2.Name = "txbServer2";
            txbServer2.Size = new Size(368, 30);
            txbServer2.TabIndex = 2;
            // 
            // pnlLectura2
            // 
            pnlLectura2.Back = Color.FromArgb(250, 250, 254);
            pnlLectura2.BorderColor = Color.FromArgb(228, 228, 238);
            pnlLectura2.BorderWidth = 1F;
            pnlLectura2.Controls.Add(txbBdConn2);
            pnlLectura2.Controls.Add(txbUserConn2);
            pnlLectura2.Controls.Add(txbPassConn2);
            pnlLectura2.Controls.Add(btnLectura2);
            pnlLectura2.Controls.Add(lblLectura2);
            pnlLectura2.Controls.Add(lblBdConn2);
            pnlLectura2.Controls.Add(lblUserConn2);
            pnlLectura2.Controls.Add(lblPassConn2);
            pnlLectura2.Location = new Point(16, 84);
            pnlLectura2.Name = "pnlLectura2";
            pnlLectura2.Radius = 8;
            pnlLectura2.Size = new Size(430, 162);
            pnlLectura2.TabIndex = 3;
            // 
            // lblLectura2
            // 
            lblLectura2.BackColor = Color.Transparent;
            lblLectura2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblLectura2.ForeColor = Color.FromArgb(72, 158, 44);
            lblLectura2.Location = new Point(12, 6);
            lblLectura2.Name = "lblLectura2";
            lblLectura2.Size = new Size(300, 22);
            lblLectura2.TabIndex = 0;
            lblLectura2.Text = "Lectura";
            // 
            // lblBdConn2
            // 
            lblBdConn2.BackColor = Color.Transparent;
            lblBdConn2.Font = new Font("Segoe UI", 9F);
            lblBdConn2.ForeColor = Color.FromArgb(51, 65, 85);
            lblBdConn2.Location = new Point(12, 32);
            lblBdConn2.Name = "lblBdConn2";
            lblBdConn2.Size = new Size(108, 26);
            lblBdConn2.TabIndex = 1;
            lblBdConn2.Text = "Base de datos:";
            // 
            // txbBdConn2
            // 
            txbBdConn2.BorderColor = Color.FromArgb(206, 212, 224);
            txbBdConn2.Font = new Font("Segoe UI", 9F);
            txbBdConn2.Location = new Point(99, 30);
            txbBdConn2.Name = "txbBdConn2";
            txbBdConn2.Size = new Size(324, 30);
            txbBdConn2.TabIndex = 2;
            // 
            // lblUserConn2
            // 
            lblUserConn2.BackColor = Color.Transparent;
            lblUserConn2.Font = new Font("Segoe UI", 9F);
            lblUserConn2.ForeColor = Color.FromArgb(51, 65, 85);
            lblUserConn2.Location = new Point(12, 64);
            lblUserConn2.Name = "lblUserConn2";
            lblUserConn2.Size = new Size(108, 26);
            lblUserConn2.TabIndex = 3;
            lblUserConn2.Text = "Usuario:";
            // 
            // txbUserConn2
            // 
            txbUserConn2.BorderColor = Color.FromArgb(206, 212, 224);
            txbUserConn2.Font = new Font("Segoe UI", 9F);
            txbUserConn2.Location = new Point(99, 62);
            txbUserConn2.Name = "txbUserConn2";
            txbUserConn2.Size = new Size(324, 30);
            txbUserConn2.TabIndex = 4;
            // 
            // lblPassConn2
            // 
            lblPassConn2.BackColor = Color.Transparent;
            lblPassConn2.Font = new Font("Segoe UI", 9F);
            lblPassConn2.ForeColor = Color.FromArgb(51, 65, 85);
            lblPassConn2.Location = new Point(12, 96);
            lblPassConn2.Name = "lblPassConn2";
            lblPassConn2.Size = new Size(108, 26);
            lblPassConn2.TabIndex = 5;
            lblPassConn2.Text = "Contraseña:";
            // 
            // txbPassConn2
            // 
            txbPassConn2.BorderColor = Color.FromArgb(206, 212, 224);
            txbPassConn2.Font = new Font("Segoe UI", 9F);
            txbPassConn2.Location = new Point(99, 94);
            txbPassConn2.Name = "txbPassConn2";
            txbPassConn2.Size = new Size(324, 30);
            txbPassConn2.TabIndex = 6;
            txbPassConn2.UseSystemPasswordChar = true;
            // 
            // btnLectura2
            // 
            btnLectura2.BorderWidth = 1F;
            btnLectura2.Cursor = Cursors.Hand;
            btnLectura2.DefaultBack = Color.White;
            btnLectura2.DefaultBorderColor = Color.FromArgb(206, 212, 224);
            btnLectura2.ForeColor = Color.FromArgb(51, 65, 85);
            btnLectura2.Location = new Point(301, 126);
            btnLectura2.Name = "btnLectura2";
            btnLectura2.Size = new Size(122, 30);
            btnLectura2.TabIndex = 7;
            btnLectura2.Text = "Probar conexión";
            btnLectura2.Click += btnLectura2_Click;
            // 
            // pnlEscritura2
            // 
            pnlEscritura2.Back = Color.FromArgb(250, 250, 254);
            pnlEscritura2.BorderColor = Color.FromArgb(228, 228, 238);
            pnlEscritura2.BorderWidth = 1F;
            pnlEscritura2.Controls.Add(txbBdWrite2);
            pnlEscritura2.Controls.Add(txbUserWrite2);
            pnlEscritura2.Controls.Add(txbPassWrite2);
            pnlEscritura2.Controls.Add(btnEscritura2);
            pnlEscritura2.Controls.Add(lblEscritura2);
            pnlEscritura2.Controls.Add(lblBdWrite2);
            pnlEscritura2.Controls.Add(lblUserWrite2);
            pnlEscritura2.Controls.Add(lblPassWrite2);
            pnlEscritura2.Location = new Point(16, 254);
            pnlEscritura2.Name = "pnlEscritura2";
            pnlEscritura2.Radius = 8;
            pnlEscritura2.Size = new Size(430, 162);
            pnlEscritura2.TabIndex = 4;
            // 
            // lblEscritura2
            // 
            lblEscritura2.BackColor = Color.Transparent;
            lblEscritura2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblEscritura2.ForeColor = Color.FromArgb(72, 158, 44);
            lblEscritura2.Location = new Point(12, 6);
            lblEscritura2.Name = "lblEscritura2";
            lblEscritura2.Size = new Size(300, 22);
            lblEscritura2.TabIndex = 0;
            lblEscritura2.Text = "Escritura";
            // 
            // lblBdWrite2
            // 
            lblBdWrite2.BackColor = Color.Transparent;
            lblBdWrite2.Font = new Font("Segoe UI", 9F);
            lblBdWrite2.ForeColor = Color.FromArgb(51, 65, 85);
            lblBdWrite2.Location = new Point(12, 32);
            lblBdWrite2.Name = "lblBdWrite2";
            lblBdWrite2.Size = new Size(108, 26);
            lblBdWrite2.TabIndex = 1;
            lblBdWrite2.Text = "Base de datos:";
            // 
            // txbBdWrite2
            // 
            txbBdWrite2.BorderColor = Color.FromArgb(206, 212, 224);
            txbBdWrite2.Font = new Font("Segoe UI", 9F);
            txbBdWrite2.Location = new Point(99, 30);
            txbBdWrite2.Name = "txbBdWrite2";
            txbBdWrite2.Size = new Size(324, 30);
            txbBdWrite2.TabIndex = 2;
            // 
            // lblUserWrite2
            // 
            lblUserWrite2.BackColor = Color.Transparent;
            lblUserWrite2.Font = new Font("Segoe UI", 9F);
            lblUserWrite2.ForeColor = Color.FromArgb(51, 65, 85);
            lblUserWrite2.Location = new Point(12, 64);
            lblUserWrite2.Name = "lblUserWrite2";
            lblUserWrite2.Size = new Size(108, 26);
            lblUserWrite2.TabIndex = 3;
            lblUserWrite2.Text = "Usuario:";
            // 
            // txbUserWrite2
            // 
            txbUserWrite2.BorderColor = Color.FromArgb(206, 212, 224);
            txbUserWrite2.Font = new Font("Segoe UI", 9F);
            txbUserWrite2.Location = new Point(99, 62);
            txbUserWrite2.Name = "txbUserWrite2";
            txbUserWrite2.Size = new Size(324, 30);
            txbUserWrite2.TabIndex = 4;
            // 
            // lblPassWrite2
            // 
            lblPassWrite2.BackColor = Color.Transparent;
            lblPassWrite2.Font = new Font("Segoe UI", 9F);
            lblPassWrite2.ForeColor = Color.FromArgb(51, 65, 85);
            lblPassWrite2.Location = new Point(12, 96);
            lblPassWrite2.Name = "lblPassWrite2";
            lblPassWrite2.Size = new Size(108, 26);
            lblPassWrite2.TabIndex = 5;
            lblPassWrite2.Text = "Contraseña:";
            // 
            // txbPassWrite2
            // 
            txbPassWrite2.BorderColor = Color.FromArgb(206, 212, 224);
            txbPassWrite2.Font = new Font("Segoe UI", 9F);
            txbPassWrite2.Location = new Point(99, 94);
            txbPassWrite2.Name = "txbPassWrite2";
            txbPassWrite2.Size = new Size(324, 30);
            txbPassWrite2.TabIndex = 6;
            txbPassWrite2.UseSystemPasswordChar = true;
            // 
            // btnEscritura2
            // 
            btnEscritura2.BorderWidth = 1F;
            btnEscritura2.Cursor = Cursors.Hand;
            btnEscritura2.DefaultBack = Color.White;
            btnEscritura2.DefaultBorderColor = Color.FromArgb(206, 212, 224);
            btnEscritura2.ForeColor = Color.FromArgb(51, 65, 85);
            btnEscritura2.Location = new Point(301, 126);
            btnEscritura2.Name = "btnEscritura2";
            btnEscritura2.Size = new Size(122, 30);
            btnEscritura2.TabIndex = 7;
            btnEscritura2.Text = "Probar conexión";
            btnEscritura2.Click += btnEscritura2_Click;
            // 
            // pnlEmpleados2
            // 
            pnlEmpleados2.Back = Color.FromArgb(250, 250, 254);
            pnlEmpleados2.BorderColor = Color.FromArgb(228, 228, 238);
            pnlEmpleados2.BorderWidth = 1F;
            pnlEmpleados2.Controls.Add(txbDbEmployees2);
            pnlEmpleados2.Controls.Add(btnEmpleados2);
            pnlEmpleados2.Controls.Add(lblEmpleados2);
            pnlEmpleados2.Controls.Add(lblBdEmp2);
            pnlEmpleados2.Location = new Point(16, 424);
            pnlEmpleados2.Name = "pnlEmpleados2";
            pnlEmpleados2.Radius = 8;
            pnlEmpleados2.Size = new Size(430, 98);
            pnlEmpleados2.TabIndex = 5;
            // 
            // lblEmpleados2
            // 
            lblEmpleados2.BackColor = Color.Transparent;
            lblEmpleados2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblEmpleados2.ForeColor = Color.FromArgb(72, 158, 44);
            lblEmpleados2.Location = new Point(12, 6);
            lblEmpleados2.Name = "lblEmpleados2";
            lblEmpleados2.Size = new Size(300, 22);
            lblEmpleados2.TabIndex = 0;
            lblEmpleados2.Text = "Base de datos de empleados";
            // 
            // lblBdEmp2
            // 
            lblBdEmp2.BackColor = Color.Transparent;
            lblBdEmp2.Font = new Font("Segoe UI", 9F);
            lblBdEmp2.ForeColor = Color.FromArgb(51, 65, 85);
            lblBdEmp2.Location = new Point(12, 32);
            lblBdEmp2.Name = "lblBdEmp2";
            lblBdEmp2.Size = new Size(108, 26);
            lblBdEmp2.TabIndex = 1;
            lblBdEmp2.Text = "Base de datos:";
            // 
            // txbDbEmployees2
            // 
            txbDbEmployees2.BorderColor = Color.FromArgb(206, 212, 224);
            txbDbEmployees2.Font = new Font("Segoe UI", 9F);
            txbDbEmployees2.Location = new Point(99, 30);
            txbDbEmployees2.Name = "txbDbEmployees2";
            txbDbEmployees2.Size = new Size(324, 30);
            txbDbEmployees2.TabIndex = 2;
            // 
            // btnEmpleados2
            // 
            btnEmpleados2.BorderWidth = 1F;
            btnEmpleados2.Cursor = Cursors.Hand;
            btnEmpleados2.DefaultBack = Color.White;
            btnEmpleados2.DefaultBorderColor = Color.FromArgb(206, 212, 224);
            btnEmpleados2.ForeColor = Color.FromArgb(51, 65, 85);
            btnEmpleados2.Location = new Point(301, 62);
            btnEmpleados2.Name = "btnEmpleados2";
            btnEmpleados2.Size = new Size(122, 30);
            btnEmpleados2.TabIndex = 3;
            btnEmpleados2.Text = "Probar conexión";
            btnEmpleados2.Click += btnEmpleados2_Click;
            // 
            // btnGuardar2
            // 
            btnGuardar2.BackActive = Color.FromArgb(58, 136, 34);
            btnGuardar2.BackColor = Color.FromArgb(72, 158, 44);
            btnGuardar2.BackHover = Color.FromArgb(90, 176, 60);
            btnGuardar2.Cursor = Cursors.Hand;
            btnGuardar2.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnGuardar2.ForeColor = Color.White;
            btnGuardar2.Location = new Point(239, 534);
            btnGuardar2.Name = "btnGuardar2";
            btnGuardar2.Size = new Size(210, 36);
            btnGuardar2.TabIndex = 6;
            btnGuardar2.Text = "Guardar Servidor 2";
            btnGuardar2.Type = AntdUI.TTypeMini.Primary;
            btnGuardar2.Click += btnGuardar2_Click;
            // 
            // tagEnUso1
            // 
            tagEnUso1.BackColor = Color.FromArgb(240, 230, 250);
            tagEnUso1.BorderWidth = 0F;
            tagEnUso1.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            tagEnUso1.ForeColor = Color.FromArgb(122, 44, 166);
            tagEnUso1.Location = new Point(374, 8);
            tagEnUso1.Name = "tagEnUso1";
            tagEnUso1.Radius = 12;
            tagEnUso1.Size = new Size(72, 24);
            tagEnUso1.TabIndex = 3;
            tagEnUso1.Text = "En uso";
            // 
            // lblTitulo1
            // 
            lblTitulo1.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitulo1.ForeColor = Color.White;
            lblTitulo1.Location = new Point(62, 5);
            lblTitulo1.Name = "lblTitulo1";
            lblTitulo1.Size = new Size(200, 30);
            lblTitulo1.TabIndex = 2;
            lblTitulo1.Text = "Servidor 1";
            // 
            // pnlSep1
            // 
            pnlSep1.Back = Color.FromArgb(110, 255, 255, 255);
            pnlSep1.Location = new Point(50, 10);
            pnlSep1.Name = "pnlSep1";
            pnlSep1.Size = new Size(1, 20);
            pnlSep1.TabIndex = 1;
            // 
            // picDb1
            // 
            picDb1.BackColor = Color.Transparent;
            picDb1.Location = new Point(12, 7);
            picDb1.Name = "picDb1";
            picDb1.Size = new Size(30, 26);
            picDb1.SizeMode = PictureBoxSizeMode.CenterImage;
            picDb1.TabIndex = 0;
            picDb1.TabStop = false;
            // 
            // pnlHead1
            // 
            pnlHead1.Back = Color.FromArgb(122, 44, 166);
            pnlHead1.BackColor = Color.Transparent;
            pnlHead1.Controls.Add(picDb1);
            pnlHead1.Controls.Add(pnlSep1);
            pnlHead1.Controls.Add(lblTitulo1);
            pnlHead1.Controls.Add(tagEnUso1);
            pnlHead1.Location = new Point(0, 0);
            pnlHead1.Name = "pnlHead1";
            pnlHead1.Radius = 10;
            pnlHead1.RadiusAlign = AntdUI.TAlignRound.Top;
            pnlHead1.Size = new Size(462, 40);
            pnlHead1.TabIndex = 0;
            // 
            // FrmConfiguracion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 245, 250);
            CancelButton = btnLectura1;
            ClientSize = new Size(960, 670);
            Controls.Add(pnlBarra);
            Controls.Add(pnlServidor1);
            Controls.Add(pnlServidor2);
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
            pnlServidor1.ResumeLayout(false);
            pnlLectura1.ResumeLayout(false);
            pnlEscritura1.ResumeLayout(false);
            pnlEmpleados1.ResumeLayout(false);
            pnlServidor2.ResumeLayout(false);
            pnlHead2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picDb2).EndInit();
            pnlLectura2.ResumeLayout(false);
            pnlEscritura2.ResumeLayout(false);
            pnlEmpleados2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picDb1).EndInit();
            pnlHead1.ResumeLayout(false);
            ResumeLayout(false);
        }

        private AntdUI.Panel pnlBarra;
        private AntdUI.Label lblEntorno;
        private AntdUI.Tag tagIndicador;
        private AntdUI.Button btnCambiar;
        private AntdUI.Panel pnlServidor1;
        private AntdUI.Label lblServer1;
        private AntdUI.Input txbServer1;
        private AntdUI.Panel pnlLectura1;
        private AntdUI.Label lblLectura1;
        private AntdUI.Label lblBdConn1;
        private AntdUI.Input txbBdConn1;
        private AntdUI.Label lblUserConn1;
        private AntdUI.Input txbUserConn1;
        private AntdUI.Label lblPassConn1;
        private AntdUI.Input txbPassConn1;
        private AntdUI.Button btnLectura1;
        private AntdUI.Panel pnlEscritura1;
        private AntdUI.Label lblEscritura1;
        private AntdUI.Label lblBdWrite1;
        private AntdUI.Input txbBdWrite1;
        private AntdUI.Label lblUserWrite1;
        private AntdUI.Input txbUserWrite1;
        private AntdUI.Label lblPassWrite1;
        private AntdUI.Input txbPassWrite1;
        private AntdUI.Button btnEscritura1;
        private AntdUI.Panel pnlEmpleados1;
        private AntdUI.Label lblEmpleados1;
        private AntdUI.Label lblBdEmp1;
        private AntdUI.Input txbDbEmployees1;
        private AntdUI.Button btnEmpleados1;
        private AntdUI.Button btnGuardar1;
        private AntdUI.Panel pnlServidor2;
        private AntdUI.Panel pnlHead2;
        private PictureBox picDb2;
        private AntdUI.Panel pnlSep2;
        private AntdUI.Label lblTitulo2;
        private AntdUI.Tag tagEnUso2;
        private AntdUI.Label lblServer2;
        private AntdUI.Input txbServer2;
        private AntdUI.Panel pnlLectura2;
        private AntdUI.Label lblLectura2;
        private AntdUI.Label lblBdConn2;
        private AntdUI.Input txbBdConn2;
        private AntdUI.Label lblUserConn2;
        private AntdUI.Input txbUserConn2;
        private AntdUI.Label lblPassConn2;
        private AntdUI.Input txbPassConn2;
        private AntdUI.Button btnLectura2;
        private AntdUI.Panel pnlEscritura2;
        private AntdUI.Label lblEscritura2;
        private AntdUI.Label lblBdWrite2;
        private AntdUI.Input txbBdWrite2;
        private AntdUI.Label lblUserWrite2;
        private AntdUI.Input txbUserWrite2;
        private AntdUI.Label lblPassWrite2;
        private AntdUI.Input txbPassWrite2;
        private AntdUI.Button btnEscritura2;
        private AntdUI.Panel pnlEmpleados2;
        private AntdUI.Label lblEmpleados2;
        private AntdUI.Label lblBdEmp2;
        private AntdUI.Input txbDbEmployees2;
        private AntdUI.Button btnEmpleados2;
        private AntdUI.Button btnGuardar2;
        private AntdUI.Panel pnlHead1;
        private PictureBox picDb1;
        private AntdUI.Panel pnlSep1;
        private AntdUI.Label lblTitulo1;
        private AntdUI.Tag tagEnUso1;
    }
}
