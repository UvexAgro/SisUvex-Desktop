namespace SisUvex.Nomina.Comedores.DiningHall
{
    partial class FrmDiningHallAdd
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
            chbProvider = new CheckBox();
            chbActive = new CheckBox();
            btnAccept = new Button();
            btnCancel = new Button();
            txbIdProvider = new TextBox();
            cboProvider = new ComboBox();
            lblProvider = new Label();
            txbId = new TextBox();
            txbName = new TextBox();
            lblName = new Label();
            lblTitle = new Label();
            label3 = new Label();
            lblObliName = new Label();
            label6 = new Label();
            lblId = new Label();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // chbProvider
            // 
            chbProvider.Appearance = Appearance.Button;
            chbProvider.AutoSize = true;
            chbProvider.BackgroundImage = Properties.Resources.Imagen6;
            chbProvider.BackgroundImageLayout = ImageLayout.Stretch;
            chbProvider.Font = new Font("Segoe UI", 10F);
            chbProvider.Location = new Point(533, 130);
            chbProvider.Name = "chbProvider";
            chbProvider.Size = new Size(39, 29);
            chbProvider.TabIndex = 97;
            chbProvider.Text = "     ";
            chbProvider.UseVisualStyleBackColor = true;
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
            chbActive.Location = new Point(94, 58);
            chbActive.Name = "chbActive";
            chbActive.Size = new Size(63, 31);
            chbActive.TabIndex = 95;
            chbActive.Text = "Activo";
            chbActive.TextAlign = ContentAlignment.MiddleCenter;
            chbActive.UseVisualStyleBackColor = false;
            // 
            // btnAccept
            // 
            btnAccept.Location = new Point(416, 166);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(75, 29);
            btnAccept.TabIndex = 93;
            btnAccept.Text = "Aceptar";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(497, 166);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 29);
            btnCancel.TabIndex = 94;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // txbIdProvider
            // 
            txbIdProvider.Enabled = false;
            txbIdProvider.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbIdProvider.Location = new Point(94, 130);
            txbIdProvider.Name = "txbIdProvider";
            txbIdProvider.Size = new Size(43, 29);
            txbIdProvider.TabIndex = 83;
            txbIdProvider.TextAlign = HorizontalAlignment.Center;
            // 
            // cboProvider
            // 
            cboProvider.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProvider.Font = new Font("Segoe UI", 12F);
            cboProvider.FormattingEnabled = true;
            cboProvider.ItemHeight = 21;
            cboProvider.Location = new Point(143, 131);
            cboProvider.Name = "cboProvider";
            cboProvider.Size = new Size(381, 29);
            cboProvider.TabIndex = 81;
            // 
            // lblProvider
            // 
            lblProvider.AutoSize = true;
            lblProvider.Font = new Font("Segoe UI", 12F);
            lblProvider.Location = new Point(3, 134);
            lblProvider.Name = "lblProvider";
            lblProvider.Size = new Size(85, 21);
            lblProvider.TabIndex = 82;
            lblProvider.Text = "Proveedor:";
            // 
            // txbId
            // 
            txbId.Enabled = false;
            txbId.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbId.Location = new Point(526, 12);
            txbId.Name = "txbId";
            txbId.Size = new Size(46, 29);
            txbId.TabIndex = 74;
            txbId.TextAlign = HorizontalAlignment.Center;
            // 
            // txbName
            // 
            txbName.Font = new Font("Segoe UI", 12F);
            txbName.Location = new Point(94, 95);
            txbName.MaxLength = 30;
            txbName.Name = "txbName";
            txbName.Size = new Size(430, 29);
            txbName.TabIndex = 71;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 12F);
            lblName.Location = new Point(17, 98);
            lblName.Name = "lblName";
            lblName.Size = new Size(71, 21);
            lblName.TabIndex = 73;
            lblName.Text = "Nombre:";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial Black", 16F);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(218, 31);
            lblTitle.TabIndex = 72;
            lblTitle.Text = "Añadir ventanilla";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Crimson;
            label3.Location = new Point(85, 131);
            label3.Name = "label3";
            label3.Size = new Size(12, 15);
            label3.TabIndex = 90;
            label3.Text = "*";
            // 
            // lblObliName
            // 
            lblObliName.AutoSize = true;
            lblObliName.ForeColor = Color.Crimson;
            lblObliName.Location = new Point(85, 98);
            lblObliName.Name = "lblObliName";
            lblObliName.Size = new Size(12, 15);
            lblObliName.TabIndex = 78;
            lblObliName.Text = "*";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.Crimson;
            label6.Location = new Point(516, 13);
            label6.Name = "label6";
            label6.Size = new Size(12, 15);
            label6.TabIndex = 96;
            label6.Text = "*";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 12F);
            lblId.Location = new Point(498, 16);
            lblId.Name = "lblId";
            lblId.Size = new Size(26, 21);
            lblId.TabIndex = 75;
            lblId.Text = "Id:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Crimson;
            label2.Location = new Point(84, 57);
            label2.Name = "label2";
            label2.Size = new Size(12, 15);
            label2.TabIndex = 80;
            label2.Text = "*";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Crimson;
            label1.Location = new Point(85, 131);
            label1.Name = "label1";
            label1.Size = new Size(12, 15);
            label1.TabIndex = 98;
            label1.Text = "*";
            // 
            // FrmDiningHallAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 207);
            Controls.Add(txbIdProvider);
            Controls.Add(label3);
            Controls.Add(chbProvider);
            Controls.Add(chbActive);
            Controls.Add(btnAccept);
            Controls.Add(btnCancel);
            Controls.Add(cboProvider);
            Controls.Add(txbId);
            Controls.Add(txbName);
            Controls.Add(lblName);
            Controls.Add(lblTitle);
            Controls.Add(lblObliName);
            Controls.Add(label6);
            Controls.Add(lblId);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblProvider);
            Name = "FrmDiningHallAdd";
            Text = "Añadir ventanilla";
            Load += FrmDiningHallAdd_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public CheckBox chbProvider;
        public CheckBox chbActive;
        private Button btnAccept;
        private Button btnCancel;
        public TextBox txbIdProvider;
        public ComboBox cboProvider;
        private Label lblProvider;
        public TextBox txbId;
        public TextBox txbName;
        private Label lblName;
        public Label lblTitle;
        private Label label3;
        private Label lblObliName;
        private Label label6;
        private Label lblId;
        private Label label2;
        private Label label1;
    }
}