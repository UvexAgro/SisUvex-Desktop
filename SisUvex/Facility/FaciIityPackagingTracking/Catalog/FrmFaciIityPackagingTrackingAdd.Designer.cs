namespace SisUvex.Facility.FaciIityPackagingTracking.Catalog
{
    partial class FrmFaciIityPackagingTrackingAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFaciIityPackagingTrackingAdd));
            cboActive = new ComboBox();
            label4 = new Label();
            lblActivo = new Label();
            txbName = new TextBox();
            btnAccept = new Button();
            btnCancel = new Button();
            txbId = new TextBox();
            lblTitle = new Label();
            lblObliId = new Label();
            label1 = new Label();
            lblId = new Label();
            label5 = new Label();
            flpColorsControls = new FlowLayoutPanel();
            label6 = new Label();
            SuspendLayout();
            // 
            // cboActive
            // 
            cboActive.DropDownStyle = ComboBoxStyle.DropDownList;
            cboActive.Font = new Font("Segoe UI", 12F);
            cboActive.FormattingEnabled = true;
            cboActive.Items.AddRange(new object[] { "No", "Sí" });
            cboActive.Location = new Point(311, 51);
            cboActive.Name = "cboActive";
            cboActive.Size = new Size(46, 29);
            cboActive.TabIndex = 112;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Crimson;
            label4.Location = new Point(300, 51);
            label4.Name = "label4";
            label4.Size = new Size(12, 15);
            label4.TabIndex = 114;
            label4.Text = "*";
            // 
            // lblActivo
            // 
            lblActivo.AutoSize = true;
            lblActivo.Font = new Font("Segoe UI", 12F);
            lblActivo.Location = new Point(249, 54);
            lblActivo.Name = "lblActivo";
            lblActivo.Size = new Size(60, 21);
            lblActivo.TabIndex = 113;
            lblActivo.Text = "Activo: ";
            // 
            // txbName
            // 
            txbName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txbName.Location = new Point(82, 83);
            txbName.MaxLength = 15;
            txbName.Name = "txbName";
            txbName.Size = new Size(275, 29);
            txbName.TabIndex = 95;
            // 
            // btnAccept
            // 
            btnAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAccept.Location = new Point(241, 373);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(75, 29);
            btnAccept.TabIndex = 102;
            btnAccept.Text = "Aceptar";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(322, 373);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 29);
            btnCancel.TabIndex = 103;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // txbId
            // 
            txbId.Enabled = false;
            txbId.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbId.Location = new Point(82, 48);
            txbId.Name = "txbId";
            txbId.Size = new Size(38, 29);
            txbId.TabIndex = 94;
            txbId.TextAlign = HorizontalAlignment.Center;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial Black", 13F);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(362, 26);
            lblTitle.TabIndex = 104;
            lblTitle.Text = "Añadir relación de tipo de empaque";
            // 
            // lblObliId
            // 
            lblObliId.AutoSize = true;
            lblObliId.ForeColor = Color.Crimson;
            lblObliId.Location = new Point(71, 48);
            lblObliId.Name = "lblObliId";
            lblObliId.Size = new Size(12, 15);
            lblObliId.TabIndex = 107;
            lblObliId.Text = "*";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(9, 86);
            label1.Name = "label1";
            label1.Size = new Size(71, 21);
            label1.TabIndex = 109;
            label1.Text = "Nombre:";
            label1.TextAlign = ContentAlignment.TopRight;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 12F);
            lblId.Location = new Point(54, 54);
            lblId.Name = "lblId";
            lblId.Size = new Size(26, 21);
            lblId.TabIndex = 106;
            lblId.Text = "Id:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(78, 117);
            label5.Name = "label5";
            label5.Size = new Size(132, 21);
            label5.TabIndex = 116;
            label5.Text = "Colores aplicados";
            label5.TextAlign = ContentAlignment.TopRight;
            // 
            // flpColorsControls
            // 
            flpColorsControls.AutoScroll = true;
            flpColorsControls.AutoSize = true;
            flpColorsControls.FlowDirection = FlowDirection.TopDown;
            flpColorsControls.Font = new Font("Segoe UI", 12F);
            flpColorsControls.Location = new Point(82, 145);
            flpColorsControls.Name = "flpColorsControls";
            flpColorsControls.Size = new Size(290, 217);
            flpColorsControls.TabIndex = 117;
            flpColorsControls.WrapContents = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(274, 117);
            label6.Name = "label6";
            label6.Size = new Size(87, 21);
            label6.TabIndex = 118;
            label6.Text = "Proporción";
            label6.TextAlign = ContentAlignment.TopRight;
            // 
            // FrmFaciIityPackagingTrackingAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(409, 414);
            Controls.Add(label6);
            Controls.Add(flpColorsControls);
            Controls.Add(cboActive);
            Controls.Add(label4);
            Controls.Add(lblActivo);
            Controls.Add(txbName);
            Controls.Add(btnAccept);
            Controls.Add(btnCancel);
            Controls.Add(txbId);
            Controls.Add(lblTitle);
            Controls.Add(lblObliId);
            Controls.Add(label1);
            Controls.Add(lblId);
            Controls.Add(label5);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmFaciIityPackagingTrackingAdd";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Añadir relación de tipo de empaque";
            Load += FrmFaciIityPackagingTrackingAdd_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public ComboBox cboActive;
        private Label label4;
        private Label lblActivo;
        public CheckBox chbActiveContractor;
        public TextBox txbIdSeason;
        public ComboBox cboSeason;
        private Label label2;
        private Label label3;
        public TextBox txbName;
        private Button btnSearchContractor;
        public TextBox txbIdContractor;
        private Button btnAccept;
        private Button btnCancel;
        public TextBox txbId;
        public Label lblTitle;
        private Label lblObliId;
        private Label label1;
        private Label lblId;
        private Label label5;
        private FlowLayoutPanel flpColorsControls;
        private Label label6;
    }
}