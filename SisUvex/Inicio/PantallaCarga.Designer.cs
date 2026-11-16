namespace SisUvex.Inicio
{
    partial class PantallaCarga
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PantallaCarga));
            picLogo = new PictureBox();
            btnAjustes = new BotonIconoLinea();
            btnCerrar = new BotonIconoLinea();
            pnlUsuario = new PanelPildora();
            txbUser = new TextBoxMarcador();
            pnlPassword = new PanelPildora();
            txbPassword = new TextBoxMarcador();
            btnLogin = new BotonDegradado();
            pnlImagen = new PanelImagenFondo();
            lblServidorActivo = new Label();
            lblCadenaConexion = new Label();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            pnlUsuario.SuspendLayout();
            pnlPassword.SuspendLayout();
            pnlImagen.SuspendLayout();
            SuspendLayout();
            // 
            // picLogo
            // 
            picLogo.BackColor = Color.Transparent;
            picLogo.Image = Properties.Resources.uvexvertical;
            picLogo.Location = new Point(121, 14);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(113, 122);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 5;
            picLogo.TabStop = false;
            picLogo.MouseDown += Arrastrar_MouseDown;
            // 
            // btnAjustes
            // 
            btnAjustes.Cursor = Cursors.Hand;
            btnAjustes.Location = new Point(288, 6);
            btnAjustes.Name = "btnAjustes";
            btnAjustes.Size = new Size(30, 24);
            btnAjustes.TabIndex = 6;
            btnAjustes.Tipo = TipoIconoLinea.Menu;
            btnAjustes.Click += btnAjustes_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.ColorEncima = Color.FromArgb(214, 48, 49);
            btnCerrar.Cursor = Cursors.Hand;
            btnCerrar.Location = new Point(322, 6);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(28, 24);
            btnCerrar.TabIndex = 7;
            btnCerrar.Tipo = TipoIconoLinea.Cerrar;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // pnlUsuario
            // 
            pnlUsuario.BackColor = Color.White;
            pnlUsuario.Controls.Add(txbUser);
            pnlUsuario.Location = new Point(30, 148);
            pnlUsuario.Name = "pnlUsuario";
            pnlUsuario.Size = new Size(295, 52);
            pnlUsuario.TabIndex = 0;
            // 
            // txbUser
            // 
            txbUser.BackColor = Color.White;
            txbUser.BorderStyle = BorderStyle.None;
            txbUser.Font = new Font("Segoe UI", 15F);
            txbUser.ForeColor = Color.FromArgb(51, 51, 56);
            txbUser.Location = new Point(22, 12);
            txbUser.Marcador = "Usuario";
            txbUser.Name = "txbUser";
            txbUser.Size = new Size(251, 28);
            txbUser.TabIndex = 0;
            txbUser.TextAlign = HorizontalAlignment.Center;
            // 
            // pnlPassword
            // 
            pnlPassword.BackColor = Color.White;
            pnlPassword.Controls.Add(txbPassword);
            pnlPassword.Location = new Point(30, 210);
            pnlPassword.Name = "pnlPassword";
            pnlPassword.Size = new Size(295, 52);
            pnlPassword.TabIndex = 1;
            // 
            // txbPassword
            // 
            txbPassword.BackColor = Color.White;
            txbPassword.BorderStyle = BorderStyle.None;
            txbPassword.Font = new Font("Segoe UI", 15F);
            txbPassword.ForeColor = Color.FromArgb(51, 51, 56);
            txbPassword.Location = new Point(22, 12);
            txbPassword.Marcador = "Contraseña";
            txbPassword.Name = "txbPassword";
            txbPassword.Size = new Size(251, 28);
            txbPassword.TabIndex = 0;
            txbPassword.TextAlign = HorizontalAlignment.Center;
            txbPassword.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            btnLogin.Font = new Font("Segoe UI", 15F);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(30, 272);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(295, 52);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Iniciar sesión";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // pnlImagen
            // 
            pnlImagen.Controls.Add(lblServidorActivo);
            pnlImagen.Controls.Add(lblCadenaConexion);
            pnlImagen.Imagen = Properties.Resources.imgPantallaCarga;
            pnlImagen.Location = new Point(355, 0);
            pnlImagen.Name = "pnlImagen";
            pnlImagen.Size = new Size(669, 340);
            pnlImagen.TabIndex = 8;
            pnlImagen.MouseDown += Arrastrar_MouseDown;
            // 
            // lblServidorActivo
            // 
            lblServidorActivo.BackColor = Color.Transparent;
            lblServidorActivo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblServidorActivo.ForeColor = Color.White;
            lblServidorActivo.Location = new Point(14, 272);
            lblServidorActivo.Name = "lblServidorActivo";
            lblServidorActivo.Size = new Size(640, 26);
            lblServidorActivo.TabIndex = 0;
            lblServidorActivo.Text = "Servidor 1";
            lblServidorActivo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCadenaConexion
            // 
            lblCadenaConexion.AutoEllipsis = true;
            lblCadenaConexion.BackColor = Color.Transparent;
            lblCadenaConexion.Font = new Font("Consolas", 10.5F);
            lblCadenaConexion.ForeColor = Color.FromArgb(224, 224, 224);
            lblCadenaConexion.Location = new Point(14, 300);
            lblCadenaConexion.Name = "lblCadenaConexion";
            lblCadenaConexion.Size = new Size(640, 24);
            lblCadenaConexion.TabIndex = 1;
            lblCadenaConexion.Text = "Cadena de conexión";
            lblCadenaConexion.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // PantallaCarga
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1024, 340);
            Controls.Add(pnlImagen);
            Controls.Add(btnLogin);
            Controls.Add(pnlPassword);
            Controls.Add(pnlUsuario);
            Controls.Add(btnCerrar);
            Controls.Add(btnAjustes);
            Controls.Add(picLogo);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "PantallaCarga";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SisUvex";
            Load += PantallaCarga_Load;
            Shown += PantallaCarga_Shown;
            MouseDown += Arrastrar_MouseDown;
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            pnlUsuario.ResumeLayout(false);
            pnlUsuario.PerformLayout();
            pnlPassword.ResumeLayout(false);
            pnlPassword.PerformLayout();
            pnlImagen.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private PictureBox picLogo;
        private BotonIconoLinea btnAjustes;
        private BotonIconoLinea btnCerrar;
        private PanelPildora pnlUsuario;
        private TextBoxMarcador txbUser;
        private PanelPildora pnlPassword;
        private TextBoxMarcador txbPassword;
        private BotonDegradado btnLogin;
        private PanelImagenFondo pnlImagen;
        private Label lblServidorActivo;
        private Label lblCadenaConexion;
    }
}
