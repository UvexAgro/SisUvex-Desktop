namespace SisUvex.Nomina.Padron.SUA
{
    partial class FrmSUALoad
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            btnErrors = new Button();
            label6 = new Label();
            txbComputer = new TextBox();
            label4 = new Label();
            txbSUAType = new TextBox();
            label3 = new Label();
            label1 = new Label();
            txbSUAPath = new TextBox();
            label2 = new Label();
            txbRegPatGrower = new TextBox();
            lblid = new Label();
            dgvQuery = new DataGridView();
            cboIdSUAConfig = new ComboBox();
            btnAddSUAConfig = new Button();
            btnModifySUAConfig = new Button();
            btnDeleteSUAConfig = new Button();
            txbGrower = new TextBox();
            lblTitle = new Label();
            chbAfil = new CheckBox();
            chbAseg = new CheckBox();
            btnDocs = new Button();
            label5 = new Label();
            dtpHireDate = new DateTimePicker();
            label7 = new Label();
            txbIntegratedDaylyWage = new TextBox();
            groupBox1 = new GroupBox();
            button1 = new Button();
            btnOpenFolderFiles = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvQuery).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnErrors
            // 
            btnErrors.Image = Properties.Resources.guardarIcon16;
            btnErrors.ImageAlign = ContentAlignment.MiddleLeft;
            btnErrors.Location = new Point(11, 213);
            btnErrors.Name = "btnErrors";
            btnErrors.Size = new Size(105, 23);
            btnErrors.TabIndex = 5;
            btnErrors.Text = "Cargar errores";
            btnErrors.TextAlign = ContentAlignment.MiddleRight;
            btnErrors.UseVisualStyleBackColor = true;
            btnErrors.Click += btnErrors_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(13, 76);
            label6.Name = "label6";
            label6.Size = new Size(44, 15);
            label6.TabIndex = 21;
            label6.Text = "Equipo";
            // 
            // txbComputer
            // 
            txbComputer.Enabled = false;
            txbComputer.Location = new Point(63, 73);
            txbComputer.Name = "txbComputer";
            txbComputer.Size = new Size(188, 23);
            txbComputer.TabIndex = 14;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 134);
            label4.Name = "label4";
            label4.Size = new Size(56, 15);
            label4.TabIndex = 20;
            label4.Text = "Tipo SUA";
            // 
            // txbSUAType
            // 
            txbSUAType.Enabled = false;
            txbSUAType.Location = new Point(75, 131);
            txbSUAType.MaxLength = 20;
            txbSUAType.Name = "txbSUAType";
            txbSUAType.Size = new Size(187, 23);
            txbSUAType.TabIndex = 19;
            txbSUAType.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 105);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 18;
            label3.Text = "Razón social";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(257, 76);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 15;
            label1.Text = "Ruta SUA";
            // 
            // txbSUAPath
            // 
            txbSUAPath.Enabled = false;
            txbSUAPath.Location = new Point(318, 73);
            txbSUAPath.MaxLength = 200;
            txbSUAPath.Name = "txbSUAPath";
            txbSUAPath.Size = new Size(333, 23);
            txbSUAPath.TabIndex = 16;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(395, 105);
            label2.Name = "label2";
            label2.Size = new Size(97, 15);
            label2.TabIndex = 23;
            label2.Text = "Registro patronal";
            // 
            // txbRegPatGrower
            // 
            txbRegPatGrower.Enabled = false;
            txbRegPatGrower.Location = new Point(498, 102);
            txbRegPatGrower.Name = "txbRegPatGrower";
            txbRegPatGrower.Size = new Size(97, 23);
            txbRegPatGrower.TabIndex = 24;
            txbRegPatGrower.TextAlign = HorizontalAlignment.Center;
            // 
            // lblid
            // 
            lblid.AutoSize = true;
            lblid.Location = new Point(13, 48);
            lblid.Name = "lblid";
            lblid.Size = new Size(17, 15);
            lblid.TabIndex = 25;
            lblid.Text = "Id";
            // 
            // dgvQuery
            // 
            dgvQuery.AllowUserToAddRows = false;
            dgvQuery.AllowUserToDeleteRows = false;
            dgvQuery.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvQuery.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvQuery.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvQuery.BackgroundColor = SystemColors.ControlLightLight;
            dgvQuery.BorderStyle = BorderStyle.Fixed3D;
            dgvQuery.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvQuery.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvQuery.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvQuery.EnableHeadersVisualStyles = false;
            dgvQuery.ImeMode = ImeMode.NoControl;
            dgvQuery.Location = new Point(12, 242);
            dgvQuery.Name = "dgvQuery";
            dgvQuery.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvQuery.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvQuery.RowHeadersVisible = false;
            dgvQuery.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvQuery.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvQuery.Size = new Size(639, 375);
            dgvQuery.TabIndex = 26;
            // 
            // cboIdSUAConfig
            // 
            cboIdSUAConfig.DropDownStyle = ComboBoxStyle.DropDownList;
            cboIdSUAConfig.FormattingEnabled = true;
            cboIdSUAConfig.Location = new Point(36, 44);
            cboIdSUAConfig.Name = "cboIdSUAConfig";
            cboIdSUAConfig.Size = new Size(399, 23);
            cboIdSUAConfig.TabIndex = 27;
            // 
            // btnAddSUAConfig
            // 
            btnAddSUAConfig.Image = Properties.Resources.addFileIcon16;
            btnAddSUAConfig.Location = new Point(441, 43);
            btnAddSUAConfig.Name = "btnAddSUAConfig";
            btnAddSUAConfig.Size = new Size(24, 24);
            btnAddSUAConfig.TabIndex = 28;
            btnAddSUAConfig.UseVisualStyleBackColor = true;
            btnAddSUAConfig.Click += btnAddSUAConfig_Click;
            // 
            // btnModifySUAConfig
            // 
            btnModifySUAConfig.Image = Properties.Resources.modifyFileIcon16;
            btnModifySUAConfig.Location = new Point(467, 43);
            btnModifySUAConfig.Name = "btnModifySUAConfig";
            btnModifySUAConfig.Size = new Size(24, 24);
            btnModifySUAConfig.TabIndex = 29;
            btnModifySUAConfig.UseVisualStyleBackColor = true;
            btnModifySUAConfig.Click += btnModifySUAConfig_Click;
            // 
            // btnDeleteSUAConfig
            // 
            btnDeleteSUAConfig.Image = Properties.Resources.basuraIcon16;
            btnDeleteSUAConfig.Location = new Point(493, 43);
            btnDeleteSUAConfig.Name = "btnDeleteSUAConfig";
            btnDeleteSUAConfig.Size = new Size(24, 24);
            btnDeleteSUAConfig.TabIndex = 30;
            btnDeleteSUAConfig.UseVisualStyleBackColor = true;
            btnDeleteSUAConfig.Click += btnDeleteSUAConfig_Click;
            // 
            // txbGrower
            // 
            txbGrower.Enabled = false;
            txbGrower.Location = new Point(91, 102);
            txbGrower.MaxLength = 200;
            txbGrower.Name = "txbGrower";
            txbGrower.Size = new Size(299, 23);
            txbGrower.TabIndex = 31;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(11, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(174, 21);
            lblTitle.TabIndex = 32;
            lblTitle.Text = "Generar archivos SUA";
            // 
            // chbAfil
            // 
            chbAfil.AutoSize = true;
            chbAfil.Checked = true;
            chbAfil.CheckState = CheckState.Checked;
            chbAfil.Location = new Point(399, 216);
            chbAfil.Name = "chbAfil";
            chbAfil.Size = new Size(49, 19);
            chbAfil.TabIndex = 33;
            chbAfil.Text = "AFIL";
            chbAfil.UseVisualStyleBackColor = true;
            // 
            // chbAseg
            // 
            chbAseg.AutoSize = true;
            chbAseg.Checked = true;
            chbAseg.CheckState = CheckState.Checked;
            chbAseg.Location = new Point(449, 216);
            chbAseg.Name = "chbAseg";
            chbAseg.Size = new Size(54, 19);
            chbAseg.TabIndex = 34;
            chbAseg.Text = "ASEG";
            chbAseg.UseVisualStyleBackColor = true;
            // 
            // btnDocs
            // 
            btnDocs.Image = Properties.Resources.fileTextIcon16;
            btnDocs.ImageAlign = ContentAlignment.MiddleLeft;
            btnDocs.Location = new Point(504, 210);
            btnDocs.Name = "btnDocs";
            btnDocs.Size = new Size(119, 25);
            btnDocs.TabIndex = 0;
            btnDocs.Text = "Generar archivos";
            btnDocs.TextAlign = ContentAlignment.MiddleRight;
            btnDocs.UseVisualStyleBackColor = true;
            btnDocs.Click += btnDocs_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 19);
            label5.Name = "label5";
            label5.Size = new Size(96, 15);
            label5.TabIndex = 35;
            label5.Text = "Fecha de ingreso";
            // 
            // dtpHireDate
            // 
            dtpHireDate.Format = DateTimePickerFormat.Short;
            dtpHireDate.Location = new Point(103, 15);
            dtpHireDate.Name = "dtpHireDate";
            dtpHireDate.Size = new Size(95, 23);
            dtpHireDate.TabIndex = 36;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(209, 19);
            label7.Name = "label7";
            label7.Size = new Size(42, 15);
            label7.TabIndex = 37;
            label7.Text = "Salario";
            // 
            // txbIntegratedDaylyWage
            // 
            txbIntegratedDaylyWage.Enabled = false;
            txbIntegratedDaylyWage.Location = new Point(252, 15);
            txbIntegratedDaylyWage.Name = "txbIntegratedDaylyWage";
            txbIntegratedDaylyWage.Size = new Size(64, 23);
            txbIntegratedDaylyWage.TabIndex = 38;
            txbIntegratedDaylyWage.TextAlign = HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(dtpHireDate);
            groupBox1.Controls.Add(txbIntegratedDaylyWage);
            groupBox1.Location = new Point(13, 160);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(355, 47);
            groupBox1.TabIndex = 39;
            groupBox1.TabStop = false;
            groupBox1.Text = "ASEG";
            // 
            // button1
            // 
            button1.Image = Properties.Resources.editPencilIcon16;
            button1.Location = new Point(321, 14);
            button1.Name = "button1";
            button1.Padding = new Padding(1, 1, 0, 0);
            button1.Size = new Size(25, 25);
            button1.TabIndex = 40;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnOpenFolderFiles
            // 
            btnOpenFolderFiles.Image = Properties.Resources.fileIcon16;
            btnOpenFolderFiles.Location = new Point(626, 210);
            btnOpenFolderFiles.Name = "btnOpenFolderFiles";
            btnOpenFolderFiles.Padding = new Padding(1, 1, 0, 0);
            btnOpenFolderFiles.Size = new Size(26, 25);
            btnOpenFolderFiles.TabIndex = 40;
            btnOpenFolderFiles.UseVisualStyleBackColor = true;
            btnOpenFolderFiles.Click += btnOpenFolderFiles_Click;
            // 
            // FrmSUALoad
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(661, 629);
            Controls.Add(btnOpenFolderFiles);
            Controls.Add(groupBox1);
            Controls.Add(lblTitle);
            Controls.Add(txbGrower);
            Controls.Add(btnDeleteSUAConfig);
            Controls.Add(btnModifySUAConfig);
            Controls.Add(btnAddSUAConfig);
            Controls.Add(cboIdSUAConfig);
            Controls.Add(dgvQuery);
            Controls.Add(label2);
            Controls.Add(txbRegPatGrower);
            Controls.Add(lblid);
            Controls.Add(label6);
            Controls.Add(txbComputer);
            Controls.Add(label4);
            Controls.Add(txbSUAType);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(txbSUAPath);
            Controls.Add(btnErrors);
            Controls.Add(btnDocs);
            Controls.Add(chbAseg);
            Controls.Add(chbAfil);
            Name = "FrmSUALoad";
            Text = "FrmSUALoad";
            Load += FrmSUALoad_Load;
            ((System.ComponentModel.ISupportInitialize)dgvQuery).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnErrors;
        private Label label6;
        public TextBox txbComputer;
        private Label label4;
        public TextBox txbSUAType;
        private Label label3;
        private Label label1;
        public TextBox txbSUAPath;
        private Label label2;
        public TextBox txbRegPatGrower;
        private Label lblid;
        public DataGridView dgvQuery;
        public ComboBox cboIdSUAConfig;
        private Button btnAddSUAConfig;
        private Button btnModifySUAConfig;
        private Button btnDeleteSUAConfig;
        public TextBox txbGrower;
        public Label lblTitle;
        private Button btnDocs;
        public CheckBox chbAfil;
        public CheckBox chbAseg;
        private Label label5;
        private DateTimePicker dateTimePicker1;
        private Label label7;
        public TextBox txbIntegratedDaylyWage;
        public DateTimePicker dtpHireDate;
        private GroupBox groupBox1;
        private Button button1;
        private Button btnOpenFolderFiles;
    }
}