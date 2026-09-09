namespace SisUvex.Assets.Vehicle.VehicleType
{
    partial class FrmVehicleTypeAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVehicleTypeAdd));
            btnAccept = new Button();
            btnCancel = new Button();
            lblTitle = new Label();
            txbId = new TextBox();
            txbName = new TextBox();
            lblObliName = new Label();
            label6 = new Label();
            lblName = new Label();
            lblId = new Label();
            txbImplements = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txbPrefix = new TextBox();
            lblPrefix = new Label();
            lblObliPrefix = new Label();
            cboMeterType = new ComboBox();
            lblMeterType = new Label();
            SuspendLayout();
            // 
            // btnAccept
            // 
            btnAccept.Location = new Point(242, 218);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(75, 29);
            btnAccept.TabIndex = 6;
            btnAccept.Text = "Aceptar";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(323, 218);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 29);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial Black", 16F);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(292, 31);
            lblTitle.TabIndex = 147;
            lblTitle.Text = "Añadir tipo de vehículo";
            // 
            // txbId
            // 
            txbId.Enabled = false;
            txbId.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbId.Location = new Point(122, 43);
            txbId.MaxLength = 10;
            txbId.Name = "txbId";
            txbId.Size = new Size(43, 29);
            txbId.TabIndex = 0;
            txbId.TextAlign = HorizontalAlignment.Center;
            // 
            // txbName
            // 
            txbName.Font = new Font("Segoe UI", 12F);
            txbName.Location = new Point(122, 78);
            txbName.MaxLength = 20;
            txbName.Name = "txbName";
            txbName.Size = new Size(276, 29);
            txbName.TabIndex = 1;
            // 
            // lblObliName
            // 
            lblObliName.AutoSize = true;
            lblObliName.ForeColor = Color.Crimson;
            lblObliName.Location = new Point(113, 80);
            lblObliName.Margin = new Padding(0);
            lblObliName.Name = "lblObliName";
            lblObliName.Size = new Size(12, 15);
            lblObliName.TabIndex = 145;
            lblObliName.Text = "*";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.Crimson;
            label6.Location = new Point(113, 43);
            label6.Margin = new Padding(0);
            label6.Name = "label6";
            label6.Size = new Size(12, 15);
            label6.TabIndex = 146;
            label6.Text = "*";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 12F);
            lblName.Location = new Point(46, 81);
            lblName.Name = "lblName";
            lblName.Size = new Size(71, 21);
            lblName.TabIndex = 143;
            lblName.Text = "Nombre:";
            lblName.TextAlign = ContentAlignment.TopRight;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 12F);
            lblId.Location = new Point(91, 45);
            lblId.Name = "lblId";
            lblId.Size = new Size(26, 21);
            lblId.TabIndex = 144;
            lblId.Text = "Id:";
            lblId.TextAlign = ContentAlignment.TopRight;
            // 
            // txbPrefix
            // 
            txbPrefix.Font = new Font("Segoe UI", 12F);
            txbPrefix.Location = new Point(122, 113);
            txbPrefix.MaxLength = 8;
            txbPrefix.Name = "txbPrefix";
            txbPrefix.Size = new Size(80, 29);
            txbPrefix.TabIndex = 2;
            // 
            // lblPrefix
            // 
            lblPrefix.AutoSize = true;
            lblPrefix.Font = new Font("Segoe UI", 12F);
            lblPrefix.Location = new Point(57, 116);
            lblPrefix.Name = "lblPrefix";
            lblPrefix.Size = new Size(58, 21);
            lblPrefix.TabIndex = 153;
            lblPrefix.Text = "Prefijo:";
            lblPrefix.TextAlign = ContentAlignment.TopRight;
            // 
            // lblObliPrefix
            // 
            lblObliPrefix.AutoSize = true;
            lblObliPrefix.ForeColor = Color.Crimson;
            lblObliPrefix.Location = new Point(113, 115);
            lblObliPrefix.Margin = new Padding(0);
            lblObliPrefix.Name = "lblObliPrefix";
            lblObliPrefix.Size = new Size(12, 15);
            lblObliPrefix.TabIndex = 154;
            lblObliPrefix.Text = "*";
            // 
            // cboMeterType
            // 
            cboMeterType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMeterType.Font = new Font("Segoe UI", 12F);
            cboMeterType.FormattingEnabled = true;
            cboMeterType.Location = new Point(280, 113);
            cboMeterType.Name = "cboMeterType";
            cboMeterType.Size = new Size(118, 29);
            cboMeterType.TabIndex = 3;
            // 
            // lblMeterType
            // 
            lblMeterType.AutoSize = true;
            lblMeterType.Font = new Font("Segoe UI", 12F);
            lblMeterType.Location = new Point(208, 116);
            lblMeterType.Name = "lblMeterType";
            lblMeterType.Size = new Size(70, 21);
            lblMeterType.TabIndex = 155;
            lblMeterType.Text = "Medidor:";
            lblMeterType.TextAlign = ContentAlignment.TopRight;
            // 
            // txbImplements
            // 
            txbImplements.Font = new Font("Segoe UI", 12F);
            txbImplements.Location = new Point(122, 148);
            txbImplements.MaxLength = 15;
            txbImplements.Name = "txbImplements";
            txbImplements.Size = new Size(276, 29);
            txbImplements.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Crimson;
            label1.Location = new Point(113, 150);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(12, 15);
            label1.TabIndex = 152;
            label1.Text = "*";
            label1.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(12, 151);
            label2.Name = "label2";
            label2.Size = new Size(104, 21);
            label2.TabIndex = 151;
            label2.Text = "Implementos:";
            label2.TextAlign = ContentAlignment.TopRight;
            // 
            // FrmVehicleTypeAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(412, 259);
            Controls.Add(cboMeterType);
            Controls.Add(lblMeterType);
            Controls.Add(txbPrefix);
            Controls.Add(lblPrefix);
            Controls.Add(lblObliPrefix);
            Controls.Add(txbImplements);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(btnAccept);
            Controls.Add(btnCancel);
            Controls.Add(lblTitle);
            Controls.Add(txbId);
            Controls.Add(txbName);
            Controls.Add(lblObliName);
            Controls.Add(label6);
            Controls.Add(lblName);
            Controls.Add(lblId);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmVehicleTypeAdd";
            Text = "Añadir tipo de vehículo";
            Load += FrmVehicleTypeAdd_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAccept;
        private Button btnCancel;
        public Label lblTitle;
        public TextBox txbId;
        public TextBox txbName;
        private Label lblObliName;
        private Label label6;
        private Label lblName;
        private Label lblId;
        public TextBox txbImplements;
        private Label label1;
        private Label label2;
        public TextBox txbPrefix;
        private Label lblPrefix;
        private Label lblObliPrefix;
        public ComboBox cboMeterType;
        private Label lblMeterType;
    }
}
