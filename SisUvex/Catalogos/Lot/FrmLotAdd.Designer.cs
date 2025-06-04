namespace SisUvex.Catalogos.Lot
{
    partial class FrmLotAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLotAdd));
            lblTitle = new Label();
            chbActive = new CheckBox();
            chbActiveVariety = new CheckBox();
            txbName = new TextBox();
            btnSearchVariety = new Button();
            txbIdVariety = new TextBox();
            cboVariety = new ComboBox();
            lblObliContratista = new Label();
            lblObliId = new Label();
            lblVariety = new Label();
            lblId = new Label();
            btnAccept = new Button();
            btnCancel = new Button();
            label1 = new Label();
            lblHa = new Label();
            nudHa = new NumericUpDown();
            lblDate = new Label();
            dtpDate = new DateTimePicker();
            spnId = new MaskedTextBox();
            btnSearchNameLot = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txbIdFarm = new TextBox();
            cboFarm = new ComboBox();
            label5 = new Label();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)nudHa).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial Black", 16F);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(147, 31);
            lblTitle.TabIndex = 40;
            lblTitle.Text = "Añadir lote";
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
            chbActive.Location = new Point(168, 42);
            chbActive.Name = "chbActive";
            chbActive.Size = new Size(63, 31);
            chbActive.TabIndex = 13;
            chbActive.Text = "Activo";
            chbActive.TextAlign = ContentAlignment.MiddleCenter;
            chbActive.UseVisualStyleBackColor = false;
            // 
            // chbActiveVariety
            // 
            chbActiveVariety.Appearance = Appearance.Button;
            chbActiveVariety.AutoSize = true;
            chbActiveVariety.BackgroundImage = Properties.Resources.Imagen6;
            chbActiveVariety.BackgroundImageLayout = ImageLayout.Stretch;
            chbActiveVariety.Font = new Font("Segoe UI", 10F);
            chbActiveVariety.Location = new Point(581, 149);
            chbActiveVariety.Name = "chbActiveVariety";
            chbActiveVariety.Size = new Size(39, 29);
            chbActiveVariety.TabIndex = 5;
            chbActiveVariety.Text = "     ";
            chbActiveVariety.UseVisualStyleBackColor = true;
            // 
            // txbName
            // 
            txbName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txbName.Location = new Point(168, 114);
            txbName.MaxLength = 15;
            txbName.Name = "txbName";
            txbName.Size = new Size(275, 29);
            txbName.TabIndex = 1;
            // 
            // btnSearchVariety
            // 
            btnSearchVariety.BackgroundImage = Properties.Resources.buscarIcon32;
            btnSearchVariety.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearchVariety.Location = new Point(626, 149);
            btnSearchVariety.Name = "btnSearchVariety";
            btnSearchVariety.Size = new Size(29, 29);
            btnSearchVariety.TabIndex = 6;
            btnSearchVariety.UseVisualStyleBackColor = true;
            // 
            // txbIdVariety
            // 
            txbIdVariety.Enabled = false;
            txbIdVariety.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbIdVariety.Location = new Point(168, 149);
            txbIdVariety.Name = "txbIdVariety";
            txbIdVariety.Size = new Size(46, 29);
            txbIdVariety.TabIndex = 3;
            txbIdVariety.TextAlign = HorizontalAlignment.Center;
            // 
            // cboVariety
            // 
            cboVariety.DropDownStyle = ComboBoxStyle.DropDownList;
            cboVariety.Font = new Font("Segoe UI", 12F);
            cboVariety.FormattingEnabled = true;
            cboVariety.ItemHeight = 21;
            cboVariety.Location = new Point(220, 149);
            cboVariety.Name = "cboVariety";
            cboVariety.Size = new Size(355, 29);
            cboVariety.TabIndex = 4;
            // 
            // lblObliContratista
            // 
            lblObliContratista.AutoSize = true;
            lblObliContratista.ForeColor = Color.Crimson;
            lblObliContratista.Location = new Point(160, 149);
            lblObliContratista.Name = "lblObliContratista";
            lblObliContratista.Size = new Size(12, 15);
            lblObliContratista.TabIndex = 68;
            lblObliContratista.Text = "*";
            // 
            // lblObliId
            // 
            lblObliId.AutoSize = true;
            lblObliId.ForeColor = Color.Crimson;
            lblObliId.Location = new Point(159, 79);
            lblObliId.Name = "lblObliId";
            lblObliId.Size = new Size(12, 15);
            lblObliId.TabIndex = 67;
            lblObliId.Text = "*";
            // 
            // lblVariety
            // 
            lblVariety.AutoSize = true;
            lblVariety.Font = new Font("Segoe UI", 12F);
            lblVariety.Location = new Point(88, 152);
            lblVariety.Name = "lblVariety";
            lblVariety.Size = new Size(74, 21);
            lblVariety.TabIndex = 65;
            lblVariety.Text = "Variedad:";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 12F);
            lblId.Location = new Point(136, 82);
            lblId.Name = "lblId";
            lblId.Size = new Size(26, 21);
            lblId.TabIndex = 66;
            lblId.Text = "Id:";
            // 
            // btnAccept
            // 
            btnAccept.Location = new Point(500, 260);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(75, 29);
            btnAccept.TabIndex = 11;
            btnAccept.Text = "Aceptar";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(581, 260);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 29);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(61, 117);
            label1.Name = "label1";
            label1.Size = new Size(101, 21);
            label1.TabIndex = 69;
            label1.Text = "Nombre lote:";
            // 
            // lblHa
            // 
            lblHa.AutoSize = true;
            lblHa.Font = new Font("Segoe UI", 12F);
            lblHa.Location = new Point(81, 221);
            lblHa.Name = "lblHa";
            lblHa.Size = new Size(81, 21);
            lblHa.TabIndex = 75;
            lblHa.Text = "Hectareas:";
            // 
            // nudHa
            // 
            nudHa.DecimalPlaces = 2;
            nudHa.Font = new Font("Segoe UI", 12F);
            nudHa.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            nudHa.Location = new Point(168, 219);
            nudHa.Maximum = new decimal(new int[] { 999999, 0, 0, 131072 });
            nudHa.Name = "nudHa";
            nudHa.Size = new Size(85, 29);
            nudHa.TabIndex = 9;
            nudHa.TextAlign = HorizontalAlignment.Right;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 12F);
            lblDate.Location = new Point(12, 259);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(150, 21);
            lblDate.TabIndex = 77;
            lblDate.Text = "Fecha de plantación:";
            // 
            // dtpDate
            // 
            dtpDate.CustomFormat = " dd    'de'MMMM'de'   yyyy";
            dtpDate.Font = new Font("Segoe UI", 12F);
            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.Location = new Point(168, 253);
            dtpDate.Name = "dtpDate";
            dtpDate.RightToLeft = RightToLeft.No;
            dtpDate.Size = new Size(259, 29);
            dtpDate.TabIndex = 10;
            // 
            // spnId
            // 
            spnId.Font = new Font("Segoe UI", 12F);
            spnId.Location = new Point(168, 79);
            spnId.Mask = "9999";
            spnId.Name = "spnId";
            spnId.Size = new Size(57, 29);
            spnId.TabIndex = 0;
            spnId.Tag = "fourInts";
            spnId.TextAlign = HorizontalAlignment.Center;
            spnId.ValidatingType = typeof(int);
            // 
            // btnSearchNameLot
            // 
            btnSearchNameLot.BackgroundImage = Properties.Resources.buscarIcon32;
            btnSearchNameLot.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearchNameLot.Location = new Point(449, 114);
            btnSearchNameLot.Name = "btnSearchNameLot";
            btnSearchNameLot.Size = new Size(29, 29);
            btnSearchNameLot.TabIndex = 2;
            btnSearchNameLot.UseVisualStyleBackColor = true;
            btnSearchNameLot.Click += btnSearchNameLot_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Crimson;
            label2.Location = new Point(159, 117);
            label2.Name = "label2";
            label2.Size = new Size(12, 15);
            label2.TabIndex = 81;
            label2.Text = "*";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Crimson;
            label3.Location = new Point(159, 221);
            label3.Name = "label3";
            label3.Size = new Size(12, 15);
            label3.TabIndex = 82;
            label3.Text = "*";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Crimson;
            label4.Location = new Point(159, 255);
            label4.Name = "label4";
            label4.Size = new Size(12, 15);
            label4.TabIndex = 83;
            label4.Text = "*";
            // 
            // txbIdFarm
            // 
            txbIdFarm.Enabled = false;
            txbIdFarm.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbIdFarm.Location = new Point(168, 184);
            txbIdFarm.Name = "txbIdFarm";
            txbIdFarm.Size = new Size(46, 29);
            txbIdFarm.TabIndex = 7;
            txbIdFarm.TextAlign = HorizontalAlignment.Center;
            // 
            // cboFarm
            // 
            cboFarm.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFarm.Font = new Font("Segoe UI", 12F);
            cboFarm.FormattingEnabled = true;
            cboFarm.ItemHeight = 21;
            cboFarm.Location = new Point(220, 184);
            cboFarm.Name = "cboFarm";
            cboFarm.Size = new Size(355, 29);
            cboFarm.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.Crimson;
            label5.Location = new Point(160, 184);
            label5.Name = "label5";
            label5.Size = new Size(12, 15);
            label5.TabIndex = 89;
            label5.Text = "*";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(88, 187);
            label6.Name = "label6";
            label6.Size = new Size(63, 21);
            label6.TabIndex = 88;
            label6.Text = "Campo:";
            // 
            // FrmLotAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(663, 299);
            Controls.Add(txbIdFarm);
            Controls.Add(cboFarm);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(btnSearchNameLot);
            Controls.Add(spnId);
            Controls.Add(dtpDate);
            Controls.Add(lblDate);
            Controls.Add(nudHa);
            Controls.Add(lblHa);
            Controls.Add(btnAccept);
            Controls.Add(btnCancel);
            Controls.Add(chbActive);
            Controls.Add(chbActiveVariety);
            Controls.Add(txbName);
            Controls.Add(btnSearchVariety);
            Controls.Add(txbIdVariety);
            Controls.Add(cboVariety);
            Controls.Add(lblObliContratista);
            Controls.Add(lblObliId);
            Controls.Add(lblVariety);
            Controls.Add(lblId);
            Controls.Add(lblTitle);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(label4);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmLotAdd";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Añadir lote";
            Load += FrmLotAdd_Load;
            ((System.ComponentModel.ISupportInitialize)nudHa).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Label lblTitle;
        public CheckBox chbActive;
        public CheckBox chbActiveVariety;
        public TextBox txbName;
        public TextBox txbIdVariety;
        public ComboBox cboVariety;
        private Label lblObliContratista;
        private Label lblObliId;
        private Label lblVariety;
        private Label lblId;
        private Button btnAccept;
        private Button btnCancel;
        private Label label1;
        private Label lblHa;
        private Label lblDate;
        public NumericUpDown nudHa;
        public DateTimePicker dtpDate;
        public MaskedTextBox spnId;
        private Button btnSearchNameLot;
        private Label label2;
        private Label label3;
        private Label label4;
        public Button btnSearchVariety;
        public TextBox txbIdFarm;
        public ComboBox cboFarm;
        private Label label5;
        private Label label6;
    }
}