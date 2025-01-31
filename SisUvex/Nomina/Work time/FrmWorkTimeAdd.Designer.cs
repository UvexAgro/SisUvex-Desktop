namespace SisUvex.Nomina.Work_time
{
    partial class FrmWorkTimeAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWorkTimeAdd));
            lblTitle = new Label();
            gpbNormal = new GroupBox();
            dtpEndExtra = new DateTimePicker();
            lblEndExtra = new Label();
            dtpEndNormal = new DateTimePicker();
            lblEndNormal = new Label();
            dtpBeginNormal = new DateTimePicker();
            lblBeginNormal = new Label();
            ldlDate = new Label();
            dtpDay = new DateTimePicker();
            btnCancel = new Button();
            lblWorkGroup = new Label();
            cboProductionLine = new ComboBox();
            chbActiveProductionLine = new CheckBox();
            btnAcept = new Button();
            txbWorkers = new TextBox();
            lblWorkers = new Label();
            gpbNormal.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial Black", 12F);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(135, 23);
            lblTitle.TabIndex = 147;
            lblTitle.Text = "Añadir horario";
            // 
            // gpbNormal
            // 
            gpbNormal.Controls.Add(dtpEndExtra);
            gpbNormal.Controls.Add(lblEndExtra);
            gpbNormal.Controls.Add(dtpEndNormal);
            gpbNormal.Controls.Add(lblEndNormal);
            gpbNormal.Controls.Add(dtpBeginNormal);
            gpbNormal.Controls.Add(lblBeginNormal);
            gpbNormal.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gpbNormal.Location = new Point(10, 131);
            gpbNormal.Name = "gpbNormal";
            gpbNormal.Size = new Size(295, 218);
            gpbNormal.TabIndex = 148;
            gpbNormal.TabStop = false;
            // 
            // dtpEndExtra
            // 
            dtpEndExtra.Format = DateTimePickerFormat.Custom;
            dtpEndExtra.Location = new Point(10, 183);
            dtpEndExtra.Name = "dtpEndExtra";
            dtpEndExtra.Size = new Size(273, 23);
            dtpEndExtra.TabIndex = 6;
            // 
            // lblEndExtra
            // 
            lblEndExtra.AutoSize = true;
            lblEndExtra.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEndExtra.Location = new Point(10, 165);
            lblEndExtra.Name = "lblEndExtra";
            lblEndExtra.Size = new Size(111, 15);
            lblEndExtra.TabIndex = 161;
            lblEndExtra.Text = "Final tiempo extra:";
            // 
            // dtpEndNormal
            // 
            dtpEndNormal.Format = DateTimePickerFormat.Custom;
            dtpEndNormal.Location = new Point(10, 110);
            dtpEndNormal.Name = "dtpEndNormal";
            dtpEndNormal.Size = new Size(273, 23);
            dtpEndNormal.TabIndex = 5;
            dtpEndNormal.ValueChanged += dtpEndNormal_ValueChanged;
            // 
            // lblEndNormal
            // 
            lblEndNormal.AutoSize = true;
            lblEndNormal.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEndNormal.Location = new Point(10, 92);
            lblEndNormal.Name = "lblEndNormal";
            lblEndNormal.Size = new Size(120, 15);
            lblEndNormal.TabIndex = 153;
            lblEndNormal.Text = "Final horario normal:";
            // 
            // dtpBeginNormal
            // 
            dtpBeginNormal.Format = DateTimePickerFormat.Custom;
            dtpBeginNormal.Location = new Point(10, 37);
            dtpBeginNormal.Name = "dtpBeginNormal";
            dtpBeginNormal.Size = new Size(273, 23);
            dtpBeginNormal.TabIndex = 4;
            dtpBeginNormal.ValueChanged += dtpBeginNormal_ValueChanged;
            // 
            // lblBeginNormal
            // 
            lblBeginNormal.AutoSize = true;
            lblBeginNormal.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBeginNormal.Location = new Point(10, 19);
            lblBeginNormal.Name = "lblBeginNormal";
            lblBeginNormal.Size = new Size(125, 15);
            lblBeginNormal.TabIndex = 151;
            lblBeginNormal.Text = "Inicio horario normal:";
            // 
            // ldlDate
            // 
            ldlDate.AutoSize = true;
            ldlDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ldlDate.Location = new Point(12, 40);
            ldlDate.Name = "ldlDate";
            ldlDate.Size = new Size(28, 15);
            ldlDate.TabIndex = 149;
            ldlDate.Text = "Día:";
            // 
            // dtpDay
            // 
            dtpDay.Location = new Point(42, 35);
            dtpDay.Name = "dtpDay";
            dtpDay.Size = new Size(216, 23);
            dtpDay.TabIndex = 0;
            dtpDay.ValueChanged += dtpDay_ValueChanged;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(230, 357);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblWorkGroup
            // 
            lblWorkGroup.AutoSize = true;
            lblWorkGroup.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWorkGroup.Location = new Point(20, 74);
            lblWorkGroup.Name = "lblWorkGroup";
            lblWorkGroup.Size = new Size(44, 15);
            lblWorkGroup.TabIndex = 158;
            lblWorkGroup.Text = "Banda:";
            // 
            // cboProductionLine
            // 
            cboProductionLine.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProductionLine.FormattingEnabled = true;
            cboProductionLine.Location = new Point(69, 70);
            cboProductionLine.Name = "cboProductionLine";
            cboProductionLine.Size = new Size(189, 23);
            cboProductionLine.TabIndex = 1;
            // 
            // chbActiveProductionLine
            // 
            chbActiveProductionLine.Appearance = Appearance.Button;
            chbActiveProductionLine.AutoSize = true;
            chbActiveProductionLine.BackgroundImage = Properties.Resources.Imagen6;
            chbActiveProductionLine.BackgroundImageLayout = ImageLayout.Stretch;
            chbActiveProductionLine.Font = new Font("Segoe UI", 9F);
            chbActiveProductionLine.Location = new Point(263, 69);
            chbActiveProductionLine.Name = "chbActiveProductionLine";
            chbActiveProductionLine.Size = new Size(32, 25);
            chbActiveProductionLine.TabIndex = 2;
            chbActiveProductionLine.Text = "     ";
            chbActiveProductionLine.UseVisualStyleBackColor = true;
            // 
            // btnAcept
            // 
            btnAcept.Location = new Point(149, 357);
            btnAcept.Name = "btnAcept";
            btnAcept.Size = new Size(75, 23);
            btnAcept.TabIndex = 7;
            btnAcept.Text = "Aceptar";
            btnAcept.UseVisualStyleBackColor = true;
            btnAcept.Click += btnAcept_Click;
            // 
            // txbWorkers
            // 
            txbWorkers.Location = new Point(158, 103);
            txbWorkers.MaxLength = 4;
            txbWorkers.Name = "txbWorkers";
            txbWorkers.Size = new Size(100, 23);
            txbWorkers.TabIndex = 3;
            // 
            // lblWorkers
            // 
            lblWorkers.AutoSize = true;
            lblWorkers.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWorkers.Location = new Point(6, 107);
            lblWorkers.Name = "lblWorkers";
            lblWorkers.Size = new Size(151, 15);
            lblWorkers.TabIndex = 160;
            lblWorkers.Text = "Trabajadores por cuadrilla:";
            // 
            // FrmWorkTimeAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(317, 395);
            Controls.Add(txbWorkers);
            Controls.Add(chbActiveProductionLine);
            Controls.Add(cboProductionLine);
            Controls.Add(lblWorkGroup);
            Controls.Add(btnAcept);
            Controls.Add(btnCancel);
            Controls.Add(dtpDay);
            Controls.Add(ldlDate);
            Controls.Add(gpbNormal);
            Controls.Add(lblTitle);
            Controls.Add(lblWorkers);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FrmWorkTimeAdd";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Añadir horario de empaque";
            Load += FrmWorkTimeAdd_Load;
            gpbNormal.ResumeLayout(false);
            gpbNormal.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Label lblTitle;
        private GroupBox gpbNormal;
        private Label ldlDate;
        private Label lblBeginNormal;
        private Label lblEndNormal;
        private Button btnCancel;
        private Label lblWorkGroup;
        public CheckBox chbActiveProductionLine;
        private Label lblEndExtra;
        private Button btnAcept;
        public ComboBox cboProductionLine;
        public DateTimePicker dtpDay;
        public DateTimePicker dtpBeginNormal;
        public DateTimePicker dtpEndNormal;
        public DateTimePicker dtpEndExtra;
        public TextBox txbWorkers;
        private Label lblWorkers;
    }
}