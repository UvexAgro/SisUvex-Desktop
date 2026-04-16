namespace SisUvex.Usuarios.UserCrud
{
    internal partial class FrmUserAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserAdd));
            cboActive = new ComboBox();
            txbId = new TextBox();
            lblTitle = new Label();
            lblId = new Label();
            lblObliId = new Label();
            txbUserName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            lblActivo = new Label();
            lblNombre = new Label();
            nudAcces = new NumericUpDown();
            txbPassword = new TextBox();
            label3 = new Label();
            label4 = new Label();
            txbPasswordConfirm = new TextBox();
            label5 = new Label();
            label6 = new Label();
            cboRole = new ComboBox();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            cboContractor = new ComboBox();
            label13 = new Label();
            cboWorkGroup = new ComboBox();
            txbIdEmployee = new TextBox();
            label16 = new Label();
            txbEmployeeName = new TextBox();
            label18 = new Label();
            btnSearchEmployee = new Button();
            btnAccept = new Button();
            btnCancel = new Button();
            label12 = new Label();
            cboSeason = new ComboBox();
            label14 = new Label();
            lblEmail = new Label();
            txbEMail = new TextBox();
            lblPhone = new Label();
            txbPhoneNumber = new TextBox();
            ((System.ComponentModel.ISupportInitialize)nudAcces).BeginInit();
            SuspendLayout();
            // 
            // cboActive
            // 
            cboActive.DropDownStyle = ComboBoxStyle.DropDownList;
            cboActive.Font = new Font("Segoe UI", 12F);
            cboActive.FormattingEnabled = true;
            cboActive.Items.AddRange(new object[] { "No", "Sí" });
            cboActive.Location = new Point(401, 12);
            cboActive.Name = "cboActive";
            cboActive.Size = new Size(46, 29);
            cboActive.TabIndex = 16;
            // 
            // txbId
            // 
            txbId.Enabled = false;
            txbId.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbId.Location = new Point(485, 12);
            txbId.MaxLength = 12;
            txbId.Name = "txbId";
            txbId.Size = new Size(45, 29);
            txbId.TabIndex = 17;
            txbId.TextAlign = HorizontalAlignment.Center;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial Black", 16F);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(268, 31);
            lblTitle.TabIndex = 109;
            lblTitle.Text = "Añadir nuevo usuario";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 12F);
            lblId.Location = new Point(453, 15);
            lblId.Name = "lblId";
            lblId.Size = new Size(26, 21);
            lblId.TabIndex = 110;
            lblId.Text = "Id:";
            // 
            // lblObliId
            // 
            lblObliId.AutoSize = true;
            lblObliId.ForeColor = Color.Crimson;
            lblObliId.Location = new Point(476, 12);
            lblObliId.Name = "lblObliId";
            lblObliId.Size = new Size(12, 15);
            lblObliId.TabIndex = 111;
            lblObliId.Text = "*";
            // 
            // txbUserName
            // 
            txbUserName.Font = new Font("Segoe UI", 12F);
            txbUserName.Location = new Point(12, 74);
            txbUserName.Margin = new Padding(3, 0, 3, 3);
            txbUserName.MaxLength = 12;
            txbUserName.Name = "txbUserName";
            txbUserName.Size = new Size(124, 29);
            txbUserName.TabIndex = 0;
            txbUserName.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Crimson;
            label1.Location = new Point(4, 74);
            label1.Name = "label1";
            label1.Size = new Size(12, 15);
            label1.TabIndex = 115;
            label1.Text = "*";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Crimson;
            label2.Location = new Point(391, 12);
            label2.Name = "label2";
            label2.Size = new Size(12, 15);
            label2.TabIndex = 113;
            label2.Text = "*";
            // 
            // lblActivo
            // 
            lblActivo.AutoSize = true;
            lblActivo.Font = new Font("Segoe UI", 12F);
            lblActivo.Location = new Point(339, 15);
            lblActivo.Name = "lblActivo";
            lblActivo.Size = new Size(60, 21);
            lblActivo.TabIndex = 112;
            lblActivo.Text = "Activo: ";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 12F);
            lblNombre.Location = new Point(12, 53);
            lblNombre.Margin = new Padding(3, 0, 0, 0);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(124, 21);
            lblNombre.TabIndex = 114;
            lblNombre.Text = "Nombre usuario";
            // 
            // nudAcces
            // 
            nudAcces.Font = new Font("Segoe UI", 12F);
            nudAcces.Location = new Point(178, 74);
            nudAcces.Maximum = new decimal(new int[] { 4, 0, 0, 0 });
            nudAcces.Name = "nudAcces";
            nudAcces.Size = new Size(44, 29);
            nudAcces.TabIndex = 4;
            // 
            // txbPassword
            // 
            txbPassword.Font = new Font("Segoe UI", 12F);
            txbPassword.Location = new Point(12, 127);
            txbPassword.Margin = new Padding(4, 0, 4, 4);
            txbPassword.MaxLength = 20;
            txbPassword.Name = "txbPassword";
            txbPassword.Size = new Size(124, 29);
            txbPassword.TabIndex = 1;
            txbPassword.TextAlign = HorizontalAlignment.Center;
            txbPassword.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(12, 106);
            label3.Margin = new Padding(3, 0, 0, 0);
            label3.Name = "label3";
            label3.Size = new Size(89, 21);
            label3.TabIndex = 122;
            label3.Text = "Contraseña";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(12, 160);
            label4.Margin = new Padding(3, 0, 0, 0);
            label4.Name = "label4";
            label4.Size = new Size(161, 21);
            label4.TabIndex = 123;
            label4.Text = "Confirmar contraseña";
            // 
            // txbPasswordConfirm
            // 
            txbPasswordConfirm.Font = new Font("Segoe UI", 12F);
            txbPasswordConfirm.Location = new Point(12, 181);
            txbPasswordConfirm.Margin = new Padding(4, 0, 4, 4);
            txbPasswordConfirm.MaxLength = 20;
            txbPasswordConfirm.Name = "txbPasswordConfirm";
            txbPasswordConfirm.Size = new Size(124, 29);
            txbPasswordConfirm.TabIndex = 2;
            txbPasswordConfirm.TextAlign = HorizontalAlignment.Center;
            txbPasswordConfirm.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.Crimson;
            label5.Location = new Point(4, 127);
            label5.Name = "label5";
            label5.Size = new Size(12, 15);
            label5.TabIndex = 125;
            label5.Text = "*";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.Crimson;
            label6.Location = new Point(4, 181);
            label6.Name = "label6";
            label6.Size = new Size(12, 15);
            label6.TabIndex = 126;
            label6.Text = "*";
            // 
            // cboRole
            // 
            cboRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRole.Font = new Font("Segoe UI", 12F);
            cboRole.FormattingEnabled = true;
            cboRole.Location = new Point(264, 73);
            cboRole.Name = "cboRole";
            cboRole.Size = new Size(266, 29);
            cboRole.TabIndex = 5;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(264, 52);
            label7.Margin = new Padding(3, 0, 0, 0);
            label7.Name = "label7";
            label7.Size = new Size(33, 21);
            label7.TabIndex = 128;
            label7.Text = "Rol";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = Color.Crimson;
            label8.Location = new Point(255, 73);
            label8.Name = "label8";
            label8.Size = new Size(12, 15);
            label8.TabIndex = 129;
            label8.Text = "*";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F);
            label9.Location = new Point(153, 52);
            label9.Margin = new Padding(3, 0, 0, 0);
            label9.Name = "label9";
            label9.Size = new Size(100, 21);
            label9.TabIndex = 130;
            label9.Text = "Accesibilidad";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.ForeColor = Color.Crimson;
            label10.Location = new Point(169, 75);
            label10.Name = "label10";
            label10.Size = new Size(12, 15);
            label10.TabIndex = 3;
            label10.Text = "*";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F);
            label11.Location = new Point(11, 291);
            label11.Margin = new Padding(3, 0, 0, 0);
            label11.Name = "label11";
            label11.Size = new Size(86, 21);
            label11.TabIndex = 133;
            label11.Text = "Contratista";
            // 
            // cboContractor
            // 
            cboContractor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboContractor.Font = new Font("Segoe UI", 12F);
            cboContractor.FormattingEnabled = true;
            cboContractor.Location = new Point(11, 312);
            cboContractor.Name = "cboContractor";
            cboContractor.Size = new Size(227, 29);
            cboContractor.TabIndex = 10;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F);
            label13.Location = new Point(264, 238);
            label13.Margin = new Padding(3, 0, 0, 0);
            label13.Name = "label13";
            label13.Size = new Size(72, 21);
            label13.TabIndex = 136;
            label13.Text = "Cuadrilla";
            // 
            // cboWorkGroup
            // 
            cboWorkGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            cboWorkGroup.Font = new Font("Segoe UI", 12F);
            cboWorkGroup.FormattingEnabled = true;
            cboWorkGroup.Location = new Point(264, 259);
            cboWorkGroup.Name = "cboWorkGroup";
            cboWorkGroup.Size = new Size(265, 29);
            cboWorkGroup.TabIndex = 11;
            // 
            // txbIdEmployee
            // 
            txbIdEmployee.Font = new Font("Segoe UI", 12F);
            txbIdEmployee.Location = new Point(264, 126);
            txbIdEmployee.Margin = new Padding(3, 0, 3, 3);
            txbIdEmployee.MaxLength = 6;
            txbIdEmployee.Name = "txbIdEmployee";
            txbIdEmployee.Size = new Size(72, 29);
            txbIdEmployee.TabIndex = 6;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 12F);
            label16.Location = new Point(264, 105);
            label16.Margin = new Padding(3, 0, 0, 0);
            label16.Name = "label16";
            label16.Size = new Size(101, 21);
            label16.TabIndex = 139;
            label16.Text = "N° Empleado";
            // 
            // txbEmployeeName
            // 
            txbEmployeeName.Font = new Font("Segoe UI", 12F);
            txbEmployeeName.Location = new Point(264, 180);
            txbEmployeeName.Margin = new Padding(3, 0, 3, 3);
            txbEmployeeName.MaxLength = 100;
            txbEmployeeName.Name = "txbEmployeeName";
            txbEmployeeName.Size = new Size(266, 29);
            txbEmployeeName.TabIndex = 8;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 12F);
            label18.Location = new Point(264, 159);
            label18.Margin = new Padding(3, 0, 0, 0);
            label18.Name = "label18";
            label18.Size = new Size(141, 21);
            label18.TabIndex = 142;
            label18.Text = "Nombre empleado";
            // 
            // btnSearchEmployee
            // 
            btnSearchEmployee.Image = Properties.Resources.BuscarLupa1;
            btnSearchEmployee.Location = new Point(342, 125);
            btnSearchEmployee.Name = "btnSearchEmployee";
            btnSearchEmployee.Size = new Size(31, 31);
            btnSearchEmployee.TabIndex = 7;
            btnSearchEmployee.UseVisualStyleBackColor = true;
            btnSearchEmployee.Click += btnSearchEmployee_Click;
            // 
            // btnAccept
            // 
            btnAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAccept.Location = new Point(378, 412);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(75, 29);
            btnAccept.TabIndex = 14;
            btnAccept.Text = "Aceptar";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(455, 412);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 29);
            btnCancel.TabIndex = 15;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F);
            label12.Location = new Point(12, 238);
            label12.Margin = new Padding(3, 0, 0, 0);
            label12.Name = "label12";
            label12.Size = new Size(87, 21);
            label12.TabIndex = 148;
            label12.Text = "Temporada";
            // 
            // cboSeason
            // 
            cboSeason.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSeason.Font = new Font("Segoe UI", 12F);
            cboSeason.FormattingEnabled = true;
            cboSeason.Location = new Point(12, 259);
            cboSeason.Name = "cboSeason";
            cboSeason.Size = new Size(227, 29);
            cboSeason.TabIndex = 9;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.ForeColor = Color.Crimson;
            label14.Location = new Point(255, 182);
            label14.Name = "label14";
            label14.Size = new Size(12, 15);
            label14.TabIndex = 149;
            label14.Text = "*";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 12F);
            lblEmail.Location = new Point(11, 348);
            lblEmail.Margin = new Padding(3, 0, 0, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(58, 21);
            lblEmail.TabIndex = 150;
            lblEmail.Text = "Correo";
            // 
            // txbEMail
            // 
            txbEMail.Font = new Font("Segoe UI", 12F);
            txbEMail.Location = new Point(11, 371);
            txbEMail.Margin = new Padding(3, 0, 3, 3);
            txbEMail.MaxLength = 50;
            txbEMail.Name = "txbEMail";
            txbEMail.Size = new Size(250, 29);
            txbEMail.TabIndex = 12;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI", 12F);
            lblPhone.Location = new Point(275, 348);
            lblPhone.Margin = new Padding(3, 0, 0, 0);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(68, 21);
            lblPhone.TabIndex = 152;
            lblPhone.Text = "Teléfono";
            // 
            // txbPhoneNumber
            // 
            txbPhoneNumber.Font = new Font("Segoe UI", 12F);
            txbPhoneNumber.Location = new Point(275, 371);
            txbPhoneNumber.Margin = new Padding(3, 0, 3, 3);
            txbPhoneNumber.MaxLength = 20;
            txbPhoneNumber.Name = "txbPhoneNumber";
            txbPhoneNumber.Size = new Size(254, 29);
            txbPhoneNumber.TabIndex = 13;
            // 
            // FrmUserAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(543, 453);
            Controls.Add(lblPhone);
            Controls.Add(txbPhoneNumber);
            Controls.Add(lblEmail);
            Controls.Add(txbEMail);
            Controls.Add(label12);
            Controls.Add(cboSeason);
            Controls.Add(btnAccept);
            Controls.Add(btnCancel);
            Controls.Add(btnSearchEmployee);
            Controls.Add(txbEmployeeName);
            Controls.Add(label18);
            Controls.Add(txbIdEmployee);
            Controls.Add(label16);
            Controls.Add(label13);
            Controls.Add(cboWorkGroup);
            Controls.Add(label11);
            Controls.Add(cboContractor);
            Controls.Add(label9);
            Controls.Add(label7);
            Controls.Add(cboRole);
            Controls.Add(txbPasswordConfirm);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(nudAcces);
            Controls.Add(txbPassword);
            Controls.Add(cboActive);
            Controls.Add(txbId);
            Controls.Add(lblId);
            Controls.Add(lblObliId);
            Controls.Add(txbUserName);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(lblActivo);
            Controls.Add(lblNombre);
            Controls.Add(lblTitle);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label8);
            Controls.Add(label10);
            Controls.Add(label14);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmUserAdd";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Añadir nuevo usuario";
            Load += FrmUserAdd_Load;
            ((System.ComponentModel.ISupportInitialize)nudAcces).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public ComboBox cboActive;
        public TextBox txbId;
        public Label lblTitle;
        private Label lblId;
        private Label lblObliId;
        public TextBox txbUserName;
        private Label label1;
        private Label label2;
        private Label lblActivo;
        private Label lblNombre;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label13;
        public TextBox txbIdEmployee;
        private Label label16;
        public TextBox txbEmployeeName;
        private Label label18;
        private Button btnSearchEmployee;
        private Button btnAccept;
        private Button btnCancel;
        public NumericUpDown nudAcces;
        public TextBox txbPassword;
        public TextBox txbPasswordConfirm;
        public ComboBox cboRole;
        public ComboBox cboContractor;
        public ComboBox cboWorkGroup;
        private Label label12;
        public ComboBox cboSeason;
        private Label label14;
        private Label lblEmail;
        public TextBox txbEMail;
        private Label lblPhone;
        public TextBox txbPhoneNumber;
    }
}