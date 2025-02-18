namespace SisUvex
{
    partial class FrmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            lblUsuario = new Label();
            lblPasswor = new Label();
            txbUser = new TextBox();
            txbPassword = new TextBox();
            btnLogin = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblUsuario.Location = new Point(86, 122);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(67, 21);
            lblUsuario.TabIndex = 0;
            lblUsuario.Text = "usuario";
            // 
            // lblPasswor
            // 
            lblPasswor.AutoSize = true;
            lblPasswor.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblPasswor.Location = new Point(71, 172);
            lblPasswor.Name = "lblPasswor";
            lblPasswor.Size = new Size(94, 21);
            lblPasswor.TabIndex = 1;
            lblPasswor.Text = "contraseña";
            // 
            // txbUser
            // 
            txbUser.Location = new Point(14, 146);
            txbUser.Name = "txbUser";
            txbUser.Size = new Size(208, 23);
            txbUser.TabIndex = 2;
            txbUser.TextAlign = HorizontalAlignment.Center;
            // 
            // txbPassword
            // 
            txbPassword.Location = new Point(14, 196);
            txbPassword.Name = "txbPassword";
            txbPassword.Size = new Size(208, 23);
            txbPassword.TabIndex = 3;
            txbPassword.TextAlign = HorizontalAlignment.Center;
            txbPassword.UseSystemPasswordChar = true;
            txbPassword.KeyPress += txbPassword_KeyPress;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(128, 128, 255);
            btnLogin.FlatAppearance.BorderColor = Color.FromArgb(128, 128, 255);
            btnLogin.FlatAppearance.MouseDownBackColor = Color.MediumPurple;
            btnLogin.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 192, 255);
            btnLogin.Font = new Font("Segoe UI", 15F);
            btnLogin.Location = new Point(15, 241);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(208, 47);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Iniciar sesión";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImage = Properties.Resources.uvexvertical;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.InitialImage = Properties.Resources.uvexvertical;
            pictureBox1.Location = new Point(72, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(94, 92);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = Properties.Resources.xIcon1;
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Cursor = Cursors.Hand;
            pictureBox2.Location = new Point(210, 1);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(23, 24);
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(235, 300);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(btnLogin);
            Controls.Add(txbPassword);
            Controls.Add(txbUser);
            Controls.Add(lblPasswor);
            Controls.Add(lblUsuario);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += FrmLogin_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUsuario;
        private Label lblPasswor;
        private TextBox txbUser;
        private TextBox txbPassword;
        private Button btnLogin;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
}