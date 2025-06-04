namespace SisUvex.Catalogos.Presentacion
{
    partial class FrmPresentationAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPresentationAdd));
            cboMarket = new ComboBox();
            txbId = new TextBox();
            txbName = new TextBox();
            lblName = new Label();
            lblTitle = new Label();
            lblId = new Label();
            lblMarket = new Label();
            label1 = new Label();
            lblObliName = new Label();
            label2 = new Label();
            txbIdCategory = new TextBox();
            cboCategory = new ComboBox();
            lblCategory = new Label();
            txbIdCrop = new TextBox();
            cboCrop = new ComboBox();
            lblCrop = new Label();
            txbIdColor = new TextBox();
            cboColor = new ComboBox();
            lblColor = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btnAccept = new Button();
            btnCancel = new Button();
            chbActive = new CheckBox();
            label6 = new Label();
            chbActiveCategory = new CheckBox();
            SuspendLayout();
            // 
            // cboMarket
            // 
            cboMarket.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMarket.Font = new Font("Segoe UI", 12F);
            cboMarket.FormattingEnabled = true;
            cboMarket.Items.AddRange(new object[] { "E", "N" });
            cboMarket.Location = new Point(358, 60);
            cboMarket.Name = "cboMarket";
            cboMarket.Size = new Size(43, 29);
            cboMarket.TabIndex = 12;
            // 
            // txbId
            // 
            txbId.Enabled = false;
            txbId.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbId.Location = new Point(527, 9);
            txbId.Name = "txbId";
            txbId.Size = new Size(46, 29);
            txbId.TabIndex = 0;
            txbId.TextAlign = HorizontalAlignment.Center;
            // 
            // txbName
            // 
            txbName.Font = new Font("Segoe UI", 12F);
            txbName.Location = new Point(91, 95);
            txbName.MaxLength = 50;
            txbName.Name = "txbName";
            txbName.Size = new Size(310, 29);
            txbName.TabIndex = 1;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 12F);
            lblName.Location = new Point(14, 98);
            lblName.Name = "lblName";
            lblName.Size = new Size(71, 21);
            lblName.TabIndex = 42;
            lblName.Text = "Nombre:";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial Black", 16F);
            lblTitle.Location = new Point(9, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(261, 31);
            lblTitle.TabIndex = 41;
            lblTitle.Text = "Añadir Presentación";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 12F);
            lblId.Location = new Point(497, 13);
            lblId.Name = "lblId";
            lblId.Size = new Size(26, 21);
            lblId.TabIndex = 44;
            lblId.Text = "Id:";
            // 
            // lblMarket
            // 
            lblMarket.AutoSize = true;
            lblMarket.Font = new Font("Segoe UI", 12F);
            lblMarket.Location = new Point(283, 64);
            lblMarket.Name = "lblMarket";
            lblMarket.Size = new Size(78, 21);
            lblMarket.TabIndex = 47;
            lblMarket.Text = "Mercado: ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Crimson;
            label1.Location = new Point(348, 63);
            label1.Name = "label1";
            label1.Size = new Size(12, 15);
            label1.TabIndex = 50;
            label1.Text = "*";
            // 
            // lblObliName
            // 
            lblObliName.AutoSize = true;
            lblObliName.ForeColor = Color.Crimson;
            lblObliName.Location = new Point(82, 98);
            lblObliName.Name = "lblObliName";
            lblObliName.Size = new Size(12, 15);
            lblObliName.TabIndex = 49;
            lblObliName.Text = "*";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Crimson;
            label2.Location = new Point(81, 57);
            label2.Name = "label2";
            label2.Size = new Size(12, 15);
            label2.TabIndex = 51;
            label2.Text = "*";
            // 
            // txbIdCategory
            // 
            txbIdCategory.Enabled = false;
            txbIdCategory.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbIdCategory.Location = new Point(91, 130);
            txbIdCategory.Name = "txbIdCategory";
            txbIdCategory.Size = new Size(43, 29);
            txbIdCategory.TabIndex = 2;
            txbIdCategory.TextAlign = HorizontalAlignment.Center;
            // 
            // cboCategory
            // 
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory.Font = new Font("Segoe UI", 12F);
            cboCategory.FormattingEnabled = true;
            cboCategory.ItemHeight = 21;
            cboCategory.Location = new Point(140, 131);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(388, 29);
            cboCategory.TabIndex = 3;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Segoe UI", 12F);
            lblCategory.Location = new Point(5, 134);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(80, 21);
            lblCategory.TabIndex = 53;
            lblCategory.Text = "Categoría:";
            // 
            // txbIdCrop
            // 
            txbIdCrop.Enabled = false;
            txbIdCrop.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbIdCrop.Location = new Point(91, 165);
            txbIdCrop.Name = "txbIdCrop";
            txbIdCrop.Size = new Size(43, 29);
            txbIdCrop.TabIndex = 5;
            txbIdCrop.TextAlign = HorizontalAlignment.Center;
            // 
            // cboCrop
            // 
            cboCrop.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCrop.Font = new Font("Segoe UI", 12F);
            cboCrop.FormattingEnabled = true;
            cboCrop.ItemHeight = 21;
            cboCrop.Location = new Point(140, 166);
            cboCrop.Name = "cboCrop";
            cboCrop.Size = new Size(388, 29);
            cboCrop.TabIndex = 6;
            // 
            // lblCrop
            // 
            lblCrop.AutoSize = true;
            lblCrop.Font = new Font("Segoe UI", 12F);
            lblCrop.Location = new Point(23, 168);
            lblCrop.Name = "lblCrop";
            lblCrop.Size = new Size(62, 21);
            lblCrop.TabIndex = 56;
            lblCrop.Text = "Cultivo:";
            // 
            // txbIdColor
            // 
            txbIdColor.Enabled = false;
            txbIdColor.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbIdColor.Location = new Point(91, 200);
            txbIdColor.Name = "txbIdColor";
            txbIdColor.Size = new Size(43, 29);
            txbIdColor.TabIndex = 7;
            txbIdColor.TextAlign = HorizontalAlignment.Center;
            // 
            // cboColor
            // 
            cboColor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboColor.Font = new Font("Segoe UI", 12F);
            cboColor.FormattingEnabled = true;
            cboColor.ItemHeight = 21;
            cboColor.Location = new Point(140, 201);
            cboColor.Name = "cboColor";
            cboColor.Size = new Size(388, 29);
            cboColor.TabIndex = 8;
            // 
            // lblColor
            // 
            lblColor.AutoSize = true;
            lblColor.Font = new Font("Segoe UI", 12F);
            lblColor.Location = new Point(23, 203);
            lblColor.Name = "lblColor";
            lblColor.Size = new Size(51, 21);
            lblColor.TabIndex = 59;
            lblColor.Text = "Color:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Crimson;
            label3.Location = new Point(82, 131);
            label3.Name = "label3";
            label3.Size = new Size(12, 15);
            label3.TabIndex = 61;
            label3.Text = "*";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Crimson;
            label4.Location = new Point(82, 168);
            label4.Name = "label4";
            label4.Size = new Size(12, 15);
            label4.TabIndex = 62;
            label4.Text = "*";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.Crimson;
            label5.Location = new Point(82, 201);
            label5.Name = "label5";
            label5.Size = new Size(12, 15);
            label5.TabIndex = 63;
            label5.Text = "*";
            // 
            // btnAccept
            // 
            btnAccept.Location = new Point(417, 242);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(75, 29);
            btnAccept.TabIndex = 9;
            btnAccept.Text = "Aceptar";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(498, 242);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 29);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // chbActive
            // 
            chbActive.Appearance = Appearance.Button;
            chbActive.AutoSize = true;
            chbActive.BackColor = Color.FromArgb(255, 224, 192);
            chbActive.CheckAlign = ContentAlignment.MiddleCenter;
            chbActive.Checked = true;
            chbActive.CheckState = CheckState.Checked;
            chbActive.FlatAppearance.BorderColor = SystemColors.ActiveBorder;
            chbActive.FlatAppearance.CheckedBackColor = Color.FromArgb(192, 255, 192);
            chbActive.FlatAppearance.MouseDownBackColor = SystemColors.ActiveCaption;
            chbActive.FlatAppearance.MouseOverBackColor = SystemColors.ButtonFace;
            chbActive.FlatStyle = FlatStyle.Flat;
            chbActive.Font = new Font("Segoe UI", 12F);
            chbActive.Location = new Point(91, 58);
            chbActive.Name = "chbActive";
            chbActive.Size = new Size(63, 31);
            chbActive.TabIndex = 11;
            chbActive.Text = "Activo";
            chbActive.TextAlign = ContentAlignment.MiddleCenter;
            chbActive.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.Crimson;
            label6.Location = new Point(517, 10);
            label6.Name = "label6";
            label6.Size = new Size(12, 15);
            label6.TabIndex = 69;
            label6.Text = "*";
            // 
            // chbActiveCategory
            // 
            chbActiveCategory.Appearance = Appearance.Button;
            chbActiveCategory.AutoSize = true;
            chbActiveCategory.BackgroundImage = Properties.Resources.Imagen6;
            chbActiveCategory.BackgroundImageLayout = ImageLayout.Stretch;
            chbActiveCategory.Font = new Font("Segoe UI", 10F);
            chbActiveCategory.Location = new Point(534, 131);
            chbActiveCategory.Name = "chbActiveCategory";
            chbActiveCategory.Size = new Size(39, 29);
            chbActiveCategory.TabIndex = 4;
            chbActiveCategory.Text = "     ";
            chbActiveCategory.UseVisualStyleBackColor = true;
            // 
            // FrmPresentationAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(583, 283);
            Controls.Add(chbActiveCategory);
            Controls.Add(chbActive);
            Controls.Add(btnAccept);
            Controls.Add(btnCancel);
            Controls.Add(txbIdColor);
            Controls.Add(cboColor);
            Controls.Add(lblColor);
            Controls.Add(txbIdCrop);
            Controls.Add(cboCrop);
            Controls.Add(lblCrop);
            Controls.Add(txbIdCategory);
            Controls.Add(cboCategory);
            Controls.Add(lblCategory);
            Controls.Add(cboMarket);
            Controls.Add(txbId);
            Controls.Add(txbName);
            Controls.Add(lblName);
            Controls.Add(lblTitle);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(lblObliName);
            Controls.Add(label6);
            Controls.Add(lblId);
            Controls.Add(label1);
            Controls.Add(lblMarket);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmPresentationAdd";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Añadir Presentacion";
            Load += FrmPresentationAdd_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public ComboBox cboMarket;
        public TextBox txbId;
        public TextBox txbName;
        private Label lblName;
        public Label lblTitle;
        private Label lblId;
        private Label lblMarket;
        private Label label1;
        private Label lblObliName;
        private Label label2;
        public TextBox txbIdCategory;
        public ComboBox cboCategory;
        private Label lblCategory;
        public TextBox txbIdCrop;
        public ComboBox cboCrop;
        private Label lblCrop;
        public TextBox txbIdColor;
        public ComboBox cboColor;
        private Label lblColor;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnAccept;
        private Button btnCancel;
        private Label label6;
        public CheckBox chbActiveCategory;
        private CheckBox checkBox1;
        public CheckBox chbActive;
    }
}