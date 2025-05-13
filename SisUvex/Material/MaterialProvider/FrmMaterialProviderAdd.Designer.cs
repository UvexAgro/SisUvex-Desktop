namespace SisUvex.Material.MaterialProvider
{
    partial class FrmMaterialProviderAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMaterialProviderAdd));
            lblTitle = new Label();
            txbId = new TextBox();
            txbName = new TextBox();
            lblObliName = new Label();
            label6 = new Label();
            lblMarket = new Label();
            label2 = new Label();
            lblName = new Label();
            lblId = new Label();
            txbCity = new TextBox();
            label3 = new Label();
            txbPhoneNumber = new TextBox();
            label5 = new Label();
            txbEmail = new TextBox();
            label8 = new Label();
            cboActive = new ComboBox();
            btnAccept = new Button();
            btnCancel = new Button();
            txbShortName = new TextBox();
            label1 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial Black", 16F);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(221, 31);
            lblTitle.TabIndex = 120;
            lblTitle.Text = "Añadir proovedor";
            // 
            // txbId
            // 
            txbId.Enabled = false;
            txbId.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbId.Location = new Point(88, 43);
            txbId.Name = "txbId";
            txbId.Size = new Size(43, 29);
            txbId.TabIndex = 111;
            txbId.TextAlign = HorizontalAlignment.Center;
            // 
            // txbName
            // 
            txbName.Font = new Font("Segoe UI", 12F);
            txbName.Location = new Point(88, 78);
            txbName.MaxLength = 50;
            txbName.Name = "txbName";
            txbName.Size = new Size(437, 29);
            txbName.TabIndex = 113;
            // 
            // lblObliName
            // 
            lblObliName.AutoSize = true;
            lblObliName.ForeColor = Color.Crimson;
            lblObliName.Location = new Point(79, 80);
            lblObliName.Margin = new Padding(0);
            lblObliName.Name = "lblObliName";
            lblObliName.Size = new Size(12, 15);
            lblObliName.TabIndex = 117;
            lblObliName.Text = "*";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.Crimson;
            label6.Location = new Point(79, 43);
            label6.Margin = new Padding(0);
            label6.Name = "label6";
            label6.Size = new Size(12, 15);
            label6.TabIndex = 119;
            label6.Text = "*";
            // 
            // lblMarket
            // 
            lblMarket.AutoSize = true;
            lblMarket.Font = new Font("Segoe UI", 12F);
            lblMarket.Location = new Point(137, 46);
            lblMarket.Name = "lblMarket";
            lblMarket.Size = new Size(56, 21);
            lblMarket.TabIndex = 116;
            lblMarket.Text = "Activo:";
            lblMarket.TextAlign = ContentAlignment.TopRight;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Crimson;
            label2.Location = new Point(190, 44);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Size = new Size(12, 15);
            label2.TabIndex = 118;
            label2.Text = "*";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 12F);
            lblName.Location = new Point(12, 81);
            lblName.Name = "lblName";
            lblName.Size = new Size(71, 21);
            lblName.TabIndex = 114;
            lblName.Text = "Nombre:";
            lblName.TextAlign = ContentAlignment.TopRight;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 12F);
            lblId.Location = new Point(57, 45);
            lblId.Name = "lblId";
            lblId.Size = new Size(26, 21);
            lblId.TabIndex = 115;
            lblId.Text = "Id:";
            lblId.TextAlign = ContentAlignment.TopRight;
            // 
            // txbCity
            // 
            txbCity.Font = new Font("Segoe UI", 12F);
            txbCity.Location = new Point(88, 148);
            txbCity.MaxLength = 50;
            txbCity.Name = "txbCity";
            txbCity.Size = new Size(437, 29);
            txbCity.TabIndex = 121;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(21, 151);
            label3.Name = "label3";
            label3.Size = new Size(62, 21);
            label3.TabIndex = 122;
            label3.Text = "Ciudad:";
            label3.TextAlign = ContentAlignment.TopRight;
            // 
            // txbPhoneNumber
            // 
            txbPhoneNumber.Font = new Font("Segoe UI", 12F);
            txbPhoneNumber.Location = new Point(88, 183);
            txbPhoneNumber.MaxLength = 13;
            txbPhoneNumber.Name = "txbPhoneNumber";
            txbPhoneNumber.Size = new Size(155, 29);
            txbPhoneNumber.TabIndex = 124;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(12, 186);
            label5.Name = "label5";
            label5.Size = new Size(71, 21);
            label5.TabIndex = 125;
            label5.Text = "Telefono:";
            label5.TextAlign = ContentAlignment.TopRight;
            // 
            // txbEmail
            // 
            txbEmail.Font = new Font("Segoe UI", 12F);
            txbEmail.Location = new Point(88, 218);
            txbEmail.MaxLength = 50;
            txbEmail.Name = "txbEmail";
            txbEmail.Size = new Size(437, 29);
            txbEmail.TabIndex = 127;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F);
            label8.Location = new Point(22, 221);
            label8.Name = "label8";
            label8.Size = new Size(61, 21);
            label8.TabIndex = 128;
            label8.Text = "Correo:";
            label8.TextAlign = ContentAlignment.TopRight;
            // 
            // cboActive
            // 
            cboActive.DropDownStyle = ComboBoxStyle.DropDownList;
            cboActive.Font = new Font("Segoe UI", 12F);
            cboActive.FormattingEnabled = true;
            cboActive.Items.AddRange(new object[] { "No", "Sí" });
            cboActive.Location = new Point(199, 43);
            cboActive.Name = "cboActive";
            cboActive.Size = new Size(46, 29);
            cboActive.TabIndex = 129;
            // 
            // btnAccept
            // 
            btnAccept.Location = new Point(369, 253);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(75, 29);
            btnAccept.TabIndex = 130;
            btnAccept.Text = "Aceptar";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(450, 253);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 29);
            btnCancel.TabIndex = 131;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // txbShortName
            // 
            txbShortName.Font = new Font("Segoe UI", 12F);
            txbShortName.Location = new Point(129, 113);
            txbShortName.MaxLength = 10;
            txbShortName.Name = "txbShortName";
            txbShortName.Size = new Size(182, 29);
            txbShortName.TabIndex = 132;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Crimson;
            label1.Location = new Point(119, 113);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(12, 15);
            label1.TabIndex = 134;
            label1.Text = "*";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(12, 116);
            label4.Name = "label4";
            label4.Size = new Size(111, 21);
            label4.TabIndex = 133;
            label4.Text = "Nombre corto:";
            label4.TextAlign = ContentAlignment.TopRight;
            // 
            // FrmMaterialProviderAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(536, 294);
            Controls.Add(label4);
            Controls.Add(txbShortName);
            Controls.Add(label1);
            Controls.Add(btnAccept);
            Controls.Add(btnCancel);
            Controls.Add(cboActive);
            Controls.Add(txbEmail);
            Controls.Add(label8);
            Controls.Add(txbPhoneNumber);
            Controls.Add(label5);
            Controls.Add(txbCity);
            Controls.Add(label3);
            Controls.Add(lblTitle);
            Controls.Add(txbId);
            Controls.Add(txbName);
            Controls.Add(lblObliName);
            Controls.Add(label6);
            Controls.Add(lblMarket);
            Controls.Add(label2);
            Controls.Add(lblName);
            Controls.Add(lblId);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmMaterialProviderAdd";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Añadir proveedor";
            Load += FrmMaterialProviderAdd_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Label lblTitle;
        public TextBox txbId;
        public TextBox txbName;
        private Label lblObliName;
        private Label label6;
        private Label lblMarket;
        private Label label2;
        private Label lblName;
        private Label lblId;
        public TextBox txbCity;
        private Label label3;
        public TextBox txbPhoneNumber;
        private Label label5;
        public TextBox txbEmail;
        private Label label8;
        public ComboBox cboActive;
        private Button btnAccept;
        private Button btnCancel;
        public TextBox txbShortName;
        private Label label1;
        private Label label4;
    }
}