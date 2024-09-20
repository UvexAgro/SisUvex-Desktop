namespace SisUvex.Usuarios
{
    partial class CreacionUsuario
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
            txbUsername = new TextBox();
            txbPass = new TextBox();
            txbPassConfirm = new TextBox();
            btnCreateUser = new Button();
            lblPass = new Label();
            lblConfPass = new Label();
            lblNuevo = new Label();
            lblAccesibilidad = new Label();
            nudAccesibilidad = new NumericUpDown();
            lblUser = new Label();
            ((System.ComponentModel.ISupportInitialize)nudAccesibilidad).BeginInit();
            SuspendLayout();
            // 
            // txbUsername
            // 
            txbUsername.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbUsername.Location = new Point(14, 144);
            txbUsername.Margin = new Padding(4);
            txbUsername.Name = "txbUsername";
            txbUsername.Size = new Size(292, 61);
            txbUsername.TabIndex = 1;
            txbUsername.TextAlign = HorizontalAlignment.Center;
            txbUsername.TextChanged += txbUsername_TextChanged;
            // 
            // txbPass
            // 
            txbPass.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbPass.Location = new Point(14, 213);
            txbPass.Margin = new Padding(4);
            txbPass.Name = "txbPass";
            txbPass.Size = new Size(292, 61);
            txbPass.TabIndex = 2;
            txbPass.TextAlign = HorizontalAlignment.Center;
            txbPass.UseSystemPasswordChar = true;
            // 
            // txbPassConfirm
            // 
            txbPassConfirm.Location = new Point(13, 282);
            txbPassConfirm.Margin = new Padding(4);
            txbPassConfirm.Name = "txbPassConfirm";
            txbPassConfirm.Size = new Size(293, 61);
            txbPassConfirm.TabIndex = 3;
            txbPassConfirm.TextAlign = HorizontalAlignment.Center;
            txbPassConfirm.UseSystemPasswordChar = true;
            // 
            // btnCreateUser
            // 
            btnCreateUser.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnCreateUser.Location = new Point(273, 471);
            btnCreateUser.Margin = new Padding(4);
            btnCreateUser.Name = "btnCreateUser";
            btnCreateUser.Size = new Size(293, 68);
            btnCreateUser.TabIndex = 4;
            btnCreateUser.Text = "CREAR";
            btnCreateUser.UseVisualStyleBackColor = true;
            btnCreateUser.Click += btnCreateUser_Click;
            // 
            // lblPass
            // 
            lblPass.AutoSize = true;
            lblPass.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblPass.Location = new Point(332, 216);
            lblPass.Margin = new Padding(4, 0, 4, 0);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(275, 54);
            lblPass.TabIndex = 6;
            lblPass.Text = "CONTRASEÑA";
            // 
            // lblConfPass
            // 
            lblConfPass.AutoSize = true;
            lblConfPass.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblConfPass.Location = new Point(332, 285);
            lblConfPass.Margin = new Padding(4, 0, 4, 0);
            lblConfPass.Name = "lblConfPass";
            lblConfPass.Size = new Size(511, 54);
            lblConfPass.TabIndex = 7;
            lblConfPass.Text = "CONFIRMAR CONTRASEÑA";
            lblConfPass.Click += label2_Click;
            // 
            // lblNuevo
            // 
            lblNuevo.AutoSize = true;
            lblNuevo.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            lblNuevo.Location = new Point(94, 21);
            lblNuevo.Margin = new Padding(4, 0, 4, 0);
            lblNuevo.Name = "lblNuevo";
            lblNuevo.Size = new Size(698, 106);
            lblNuevo.TabIndex = 8;
            lblNuevo.Text = "NUEVO USUARIO";
            lblNuevo.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblAccesibilidad
            // 
            lblAccesibilidad.AutoSize = true;
            lblAccesibilidad.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblAccesibilidad.Location = new Point(347, 365);
            lblAccesibilidad.Margin = new Padding(4, 0, 4, 0);
            lblAccesibilidad.Name = "lblAccesibilidad";
            lblAccesibilidad.Size = new Size(294, 54);
            lblAccesibilidad.TabIndex = 9;
            lblAccesibilidad.Text = "ACCESIBILIDAD";
            // 
            // nudAccesibilidad
            // 
            nudAccesibilidad.Location = new Point(204, 363);
            nudAccesibilidad.Maximum = new decimal(new int[] { 4, 0, 0, 0 });
            nudAccesibilidad.Name = "nudAccesibilidad";
            nudAccesibilidad.Size = new Size(102, 61);
            nudAccesibilidad.TabIndex = 10;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblUser.Location = new Point(332, 144);
            lblUser.Margin = new Padding(4, 0, 4, 0);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(188, 54);
            lblUser.TabIndex = 11;
            lblUser.Text = "USUARIO";
            // 
            // CreacionUsuario
            // 
            AutoScaleDimensions = new SizeF(22F, 54F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(871, 567);
            Controls.Add(lblUser);
            Controls.Add(nudAccesibilidad);
            Controls.Add(lblAccesibilidad);
            Controls.Add(lblNuevo);
            Controls.Add(lblConfPass);
            Controls.Add(lblPass);
            Controls.Add(btnCreateUser);
            Controls.Add(txbPassConfirm);
            Controls.Add(txbPass);
            Controls.Add(txbUsername);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "CreacionUsuario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Creacion de usuario";
            Load += CreacionUsuario_Load;
            ((System.ComponentModel.ISupportInitialize)nudAccesibilidad).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txbUsername;
        private TextBox txbPass;
        private TextBox txbPassConfirm;
        private Button btnCreateUser;
        private Label lblPass;
        private Label lblConfPass;
        private Label lblNuevo;
        private Label lblAccesibilidad;
        private NumericUpDown nudAccesibilidad;
        private Label lblUser;
    }
}