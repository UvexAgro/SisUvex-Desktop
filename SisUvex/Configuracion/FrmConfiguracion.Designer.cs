namespace SisUvex.Configuracion
{
    partial class FrmConfiguracion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblbdConn = new Label();
            lblUserConn = new Label();
            lblPassConn = new Label();
            gpbConn = new GroupBox();
            btnLectura = new Button();
            txbPassConn = new TextBox();
            txbUserConn = new TextBox();
            txbBdConn = new TextBox();
            txbServer = new TextBox();
            gpbEscritura = new GroupBox();
            btnEscritura = new Button();
            txbPassWrite = new TextBox();
            txbUserWrite = new TextBox();
            txbBdWrite = new TextBox();
            lblBdWrite = new Label();
            lblPassWrite = new Label();
            lblUserWrite = new Label();
            btnGuardar = new Button();
            lblServidor = new Label();
            gpbConn.SuspendLayout();
            gpbEscritura.SuspendLayout();
            SuspendLayout();
            // 
            // lblbdConn
            // 
            lblbdConn.AutoSize = true;
            lblbdConn.Location = new Point(6, 22);
            lblbdConn.Name = "lblbdConn";
            lblbdConn.Size = new Size(82, 15);
            lblbdConn.TabIndex = 1;
            lblbdConn.Text = "Base de datos:";
            // 
            // lblUserConn
            // 
            lblUserConn.AutoSize = true;
            lblUserConn.Location = new Point(6, 51);
            lblUserConn.Name = "lblUserConn";
            lblUserConn.Size = new Size(50, 15);
            lblUserConn.TabIndex = 2;
            lblUserConn.Text = "Usuario:";
            // 
            // lblPassConn
            // 
            lblPassConn.AutoSize = true;
            lblPassConn.Location = new Point(6, 80);
            lblPassConn.Name = "lblPassConn";
            lblPassConn.Size = new Size(70, 15);
            lblPassConn.TabIndex = 3;
            lblPassConn.Text = "Contraseña:";
            // 
            // gpbConn
            // 
            gpbConn.Controls.Add(btnLectura);
            gpbConn.Controls.Add(txbPassConn);
            gpbConn.Controls.Add(txbUserConn);
            gpbConn.Controls.Add(txbBdConn);
            gpbConn.Controls.Add(lblbdConn);
            gpbConn.Controls.Add(lblPassConn);
            gpbConn.Controls.Add(lblUserConn);
            gpbConn.Location = new Point(12, 43);
            gpbConn.Name = "gpbConn";
            gpbConn.Size = new Size(403, 140);
            gpbConn.TabIndex = 4;
            gpbConn.TabStop = false;
            gpbConn.Text = "Lectura";
            // 
            // btnLectura
            // 
            btnLectura.Location = new Point(280, 108);
            btnLectura.Name = "btnLectura";
            btnLectura.Size = new Size(110, 23);
            btnLectura.TabIndex = 12;
            btnLectura.Text = "Probar conexión";
            btnLectura.UseVisualStyleBackColor = true;
            btnLectura.Click += btnLectura_Click;
            // 
            // txbPassConn
            // 
            txbPassConn.Location = new Point(96, 77);
            txbPassConn.Name = "txbPassConn";
            txbPassConn.Size = new Size(294, 23);
            txbPassConn.TabIndex = 9;
            txbPassConn.UseSystemPasswordChar = true;
            // 
            // txbUserConn
            // 
            txbUserConn.Location = new Point(96, 48);
            txbUserConn.Name = "txbUserConn";
            txbUserConn.Size = new Size(294, 23);
            txbUserConn.TabIndex = 8;
            // 
            // txbBdConn
            // 
            txbBdConn.Location = new Point(96, 19);
            txbBdConn.Name = "txbBdConn";
            txbBdConn.Size = new Size(294, 23);
            txbBdConn.TabIndex = 7;
            // 
            // txbServer
            // 
            txbServer.Location = new Point(108, 14);
            txbServer.Name = "txbServer";
            txbServer.Size = new Size(292, 23);
            txbServer.TabIndex = 6;
            // 
            // gpbEscritura
            // 
            gpbEscritura.Controls.Add(btnEscritura);
            gpbEscritura.Controls.Add(txbPassWrite);
            gpbEscritura.Controls.Add(txbUserWrite);
            gpbEscritura.Controls.Add(txbBdWrite);
            gpbEscritura.Controls.Add(lblBdWrite);
            gpbEscritura.Controls.Add(lblPassWrite);
            gpbEscritura.Controls.Add(lblUserWrite);
            gpbEscritura.Location = new Point(12, 189);
            gpbEscritura.Name = "gpbEscritura";
            gpbEscritura.Size = new Size(403, 139);
            gpbEscritura.TabIndex = 10;
            gpbEscritura.TabStop = false;
            gpbEscritura.Text = "Escritura";
            // 
            // btnEscritura
            // 
            btnEscritura.Location = new Point(280, 106);
            btnEscritura.Name = "btnEscritura";
            btnEscritura.Size = new Size(110, 23);
            btnEscritura.TabIndex = 13;
            btnEscritura.Text = "Probar conexión";
            btnEscritura.UseVisualStyleBackColor = true;
            btnEscritura.Click += btnEscritura_Click;
            // 
            // txbPassWrite
            // 
            txbPassWrite.Location = new Point(96, 77);
            txbPassWrite.Name = "txbPassWrite";
            txbPassWrite.Size = new Size(294, 23);
            txbPassWrite.TabIndex = 9;
            txbPassWrite.UseSystemPasswordChar = true;
            // 
            // txbUserWrite
            // 
            txbUserWrite.Location = new Point(96, 48);
            txbUserWrite.Name = "txbUserWrite";
            txbUserWrite.Size = new Size(294, 23);
            txbUserWrite.TabIndex = 8;
            // 
            // txbBdWrite
            // 
            txbBdWrite.Location = new Point(96, 19);
            txbBdWrite.Name = "txbBdWrite";
            txbBdWrite.Size = new Size(294, 23);
            txbBdWrite.TabIndex = 7;
            // 
            // lblBdWrite
            // 
            lblBdWrite.AutoSize = true;
            lblBdWrite.Location = new Point(6, 22);
            lblBdWrite.Name = "lblBdWrite";
            lblBdWrite.Size = new Size(82, 15);
            lblBdWrite.TabIndex = 1;
            lblBdWrite.Text = "Base de datos:";
            // 
            // lblPassWrite
            // 
            lblPassWrite.AutoSize = true;
            lblPassWrite.Location = new Point(6, 80);
            lblPassWrite.Name = "lblPassWrite";
            lblPassWrite.Size = new Size(70, 15);
            lblPassWrite.TabIndex = 3;
            lblPassWrite.Text = "Contraseña:";
            // 
            // lblUserWrite
            // 
            lblUserWrite.AutoSize = true;
            lblUserWrite.Location = new Point(6, 51);
            lblUserWrite.Name = "lblUserWrite";
            lblUserWrite.Size = new Size(50, 15);
            lblUserWrite.TabIndex = 2;
            lblUserWrite.Text = "Usuario:";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(340, 338);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 11;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // lblServidor
            // 
            lblServidor.AutoSize = true;
            lblServidor.Location = new Point(18, 17);
            lblServidor.Name = "lblServidor";
            lblServidor.Size = new Size(42, 15);
            lblServidor.TabIndex = 13;
            lblServidor.Text = "Server:";
            // 
            // FrmConfiguracion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(427, 373);
            Controls.Add(lblServidor);
            Controls.Add(btnGuardar);
            Controls.Add(gpbEscritura);
            Controls.Add(txbServer);
            Controls.Add(gpbConn);
            Name = "FrmConfiguracion";
            Text = "Configuracion de conexión";
            FormClosing += FrmConfiguracion_FormClosing;
            gpbConn.ResumeLayout(false);
            gpbConn.PerformLayout();
            gpbEscritura.ResumeLayout(false);
            gpbEscritura.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblServidor;
        private Label lblbdConn;
        private Label lblUserConn;
        private Label lblPassConn;
        private GroupBox gpbConn;
        private TextBox txbServer;
        private TextBox txbPassConn;
        private TextBox txbUserConn;
        private TextBox txbBdConn;
        private GroupBox gpbEscritura;
        private TextBox txbPassWrite;
        private TextBox txbUserWrite;
        private TextBox txbBdWrite;
        private Label lblBdWrite;
        private Label lblPassWrite;
        private Label lblUserWrite;
        private Button btnGuardar;
        private Button btnLectura;
        private Button btnEscritura;
    }
}