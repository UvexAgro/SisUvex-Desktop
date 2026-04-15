namespace SisUvex.Usuarios.UserCrud
{
    internal partial class FrmUserChangePass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserChangePass));
            btnAccept = new Button();
            btnCancel = new Button();
            txbEmployeeName = new TextBox();
            label18 = new Label();
            txbIdEmployee = new TextBox();
            label16 = new Label();
            txbPasswordConfirm = new TextBox();
            label4 = new Label();
            label3 = new Label();
            txbPassword = new TextBox();
            txbId = new TextBox();
            lblId = new Label();
            txbUserName = new TextBox();
            lblNombre = new Label();
            lblTitle = new Label();
            label5 = new Label();
            label6 = new Label();
            SuspendLayout();
            // 
            // btnAccept
            // 
            btnAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAccept.Location = new Point(126, 360);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(75, 29);
            btnAccept.TabIndex = 162;
            btnAccept.Text = "Aceptar";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(203, 360);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 29);
            btnCancel.TabIndex = 163;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // txbEmployeeName
            // 
            txbEmployeeName.Enabled = false;
            txbEmployeeName.Font = new Font("Segoe UI", 12F);
            txbEmployeeName.Location = new Point(12, 318);
            txbEmployeeName.Margin = new Padding(3, 0, 3, 3);
            txbEmployeeName.MaxLength = 100;
            txbEmployeeName.Name = "txbEmployeeName";
            txbEmployeeName.Size = new Size(266, 29);
            txbEmployeeName.TabIndex = 160;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 12F);
            label18.Location = new Point(12, 297);
            label18.Margin = new Padding(3, 0, 0, 0);
            label18.Name = "label18";
            label18.Size = new Size(141, 21);
            label18.TabIndex = 161;
            label18.Text = "Nombre empleado";
            // 
            // txbIdEmployee
            // 
            txbIdEmployee.Enabled = false;
            txbIdEmployee.Font = new Font("Segoe UI", 12F);
            txbIdEmployee.Location = new Point(12, 265);
            txbIdEmployee.Margin = new Padding(3, 0, 3, 3);
            txbIdEmployee.MaxLength = 6;
            txbIdEmployee.Name = "txbIdEmployee";
            txbIdEmployee.Size = new Size(89, 29);
            txbIdEmployee.TabIndex = 158;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 12F);
            label16.Location = new Point(12, 244);
            label16.Margin = new Padding(3, 0, 0, 0);
            label16.Name = "label16";
            label16.Size = new Size(101, 21);
            label16.TabIndex = 159;
            label16.Text = "N° Empleado";
            // 
            // txbPasswordConfirm
            // 
            txbPasswordConfirm.Font = new Font("Segoe UI", 12F);
            txbPasswordConfirm.Location = new Point(66, 181);
            txbPasswordConfirm.Margin = new Padding(4, 0, 4, 4);
            txbPasswordConfirm.MaxLength = 20;
            txbPasswordConfirm.Name = "txbPasswordConfirm";
            txbPasswordConfirm.Size = new Size(161, 29);
            txbPasswordConfirm.TabIndex = 155;
            txbPasswordConfirm.TextAlign = HorizontalAlignment.Center;
            txbPasswordConfirm.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(66, 160);
            label4.Margin = new Padding(3, 0, 0, 0);
            label4.Name = "label4";
            label4.Size = new Size(161, 21);
            label4.TabIndex = 154;
            label4.Text = "Confirmar contraseña";
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
            txbPassword.TabIndex = 152;
            txbPassword.TextAlign = HorizontalAlignment.Center;
            txbPassword.UseSystemPasswordChar = true;
            // 
            // txbId
            // 
            txbId.Enabled = false;
            txbId.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbId.Location = new Point(232, 265);
            txbId.Name = "txbId";
            txbId.Size = new Size(46, 29);
            txbId.TabIndex = 147;
            txbId.TextAlign = HorizontalAlignment.Center;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 12F);
            lblId.Location = new Point(232, 244);
            lblId.Name = "lblId";
            lblId.Size = new Size(23, 21);
            lblId.TabIndex = 150;
            lblId.Text = "Id";
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
            txbUserName.TabIndex = 148;
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
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(260, 31);
            lblTitle.TabIndex = 149;
            lblTitle.Text = "Cambiar contraseña";
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
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.Crimson;
            label6.Location = new Point(57, 181);
            label6.Name = "label6";
            label6.Size = new Size(12, 15);
            label6.TabIndex = 157;
            label6.Text = "*";
            // 
            // FrmUserChangePass
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(293, 401);
            Controls.Add(btnAccept);
            Controls.Add(btnCancel);
            Controls.Add(txbEmployeeName);
            Controls.Add(label18);
            Controls.Add(txbIdEmployee);
            Controls.Add(label16);
            Controls.Add(txbPasswordConfirm);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txbPassword);
            Controls.Add(txbId);
            Controls.Add(lblId);
            Controls.Add(txbUserName);
            Controls.Add(lblNombre);
            Controls.Add(lblTitle);
            Controls.Add(label5);
            Controls.Add(label6);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmUserChangePass";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cambiar contraseña de usuario";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAccept;
        private Button btnCancel;
        public TextBox txbEmployeeName;
        private Label label18;
        public TextBox txbIdEmployee;
        private Label label16;
        public TextBox txbPasswordConfirm;
        private Label label4;
        private Label label3;
        public TextBox txbPassword;
        public TextBox txbId;
        private Label lblId;
        public TextBox txbUserName;
        private Label lblNombre;
        public Label lblTitle;
        private Label label5;
        private Label label6;
    }
}