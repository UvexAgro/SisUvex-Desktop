namespace SisUvex.Usuarios.UserCrud
{
    internal partial class FrmUserConfirmPass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserConfirmPass));
            btnAccept = new Button();
            btnCancel = new Button();
            label3 = new Label();
            txbPassword = new TextBox();
            txbUserName = new TextBox();
            lblNombre = new Label();
            lblTitle = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // btnAccept
            // 
            btnAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAccept.Location = new Point(126, 180);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(75, 29);
            btnAccept.TabIndex = 2;
            btnAccept.Text = "Aceptar";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(203, 180);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 29);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(102, 106);
            label3.Margin = new Padding(3, 0, 0, 0);
            label3.Name = "label3";
            label3.Size = new Size(89, 21);
            label3.TabIndex = 153;
            label3.Text = "Contraseña";
            // 
            // txbPassword
            // 
            txbPassword.Font = new Font("Segoe UI", 12F);
            txbPassword.Location = new Point(66, 127);
            txbPassword.Margin = new Padding(4, 0, 4, 4);
            txbPassword.MaxLength = 20;
            txbPassword.Name = "txbPassword";
            txbPassword.Size = new Size(161, 29);
            txbPassword.TabIndex = 1;
            txbPassword.TextAlign = HorizontalAlignment.Center;
            txbPassword.UseSystemPasswordChar = true;
            txbPassword.KeyPress += txbPassword_KeyPress;
            // 
            // txbUserName
            // 
            txbUserName.Enabled = false;
            txbUserName.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txbUserName.Location = new Point(84, 74);
            txbUserName.Margin = new Padding(3, 0, 3, 3);
            txbUserName.MaxLength = 12;
            txbUserName.Name = "txbUserName";
            txbUserName.Size = new Size(124, 29);
            txbUserName.TabIndex = 0;
            txbUserName.TextAlign = HorizontalAlignment.Center;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 12F);
            lblNombre.Location = new Point(84, 53);
            lblNombre.Margin = new Padding(3, 0, 0, 0);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(124, 21);
            lblNombre.TabIndex = 151;
            lblNombre.Text = "Nombre usuario";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial Black", 16F);
            lblTitle.Location = new Point(7, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(280, 31);
            lblTitle.TabIndex = 149;
            lblTitle.Text = "Confirmar contraseña";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.Crimson;
            label5.Location = new Point(57, 127);
            label5.Name = "label5";
            label5.Size = new Size(12, 15);
            label5.TabIndex = 156;
            label5.Text = "*";
            // 
            // FrmUserConfirmPass
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(293, 221);
            Controls.Add(btnAccept);
            Controls.Add(btnCancel);
            Controls.Add(label3);
            Controls.Add(txbPassword);
            Controls.Add(txbUserName);
            Controls.Add(lblNombre);
            Controls.Add(lblTitle);
            Controls.Add(label5);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmUserConfirmPass";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Confirmar contraseña";
            Load += FrmUserConfirmPass_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAccept;
        private Button btnCancel;
        private Label label3;
        public TextBox txbPassword;
        public TextBox txbUserName;
        private Label lblNombre;
        public Label lblTitle;
        private Label label5;
    }
}