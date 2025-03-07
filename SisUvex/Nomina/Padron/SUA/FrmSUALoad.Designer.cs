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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
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
            ((System.ComponentModel.ISupportInitialize)dgvQuery).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 594);
            button1.Name = "button1";
            button1.Size = new Size(54, 23);
            button1.TabIndex = 0;
            button1.Text = "Movt";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(72, 594);
            button2.Name = "button2";
            button2.Size = new Size(54, 23);
            button2.TabIndex = 1;
            button2.Text = "Afil";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(132, 594);
            button3.Name = "button3";
            button3.Size = new Size(54, 23);
            button3.TabIndex = 2;
            button3.Text = "Aseg";
            button3.UseVisualStyleBackColor = true;
            // 
            // btnErrors
            // 
            btnErrors.Location = new Point(13, 174);
            btnErrors.Name = "btnErrors";
            btnErrors.Size = new Size(110, 23);
            btnErrors.TabIndex = 5;
            btnErrors.Text = "Cargar errores";
            btnErrors.UseVisualStyleBackColor = true;
            btnErrors.Click += btnErrors_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(13, 90);
            label6.Name = "label6";
            label6.Size = new Size(44, 15);
            label6.TabIndex = 21;
            label6.Text = "Equipo";
            // 
            // txbComputer
            // 
            txbComputer.Enabled = false;
            txbComputer.Location = new Point(61, 87);
            txbComputer.Name = "txbComputer";
            txbComputer.Size = new Size(190, 23);
            txbComputer.TabIndex = 14;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 148);
            label4.Name = "label4";
            label4.Size = new Size(56, 15);
            label4.TabIndex = 20;
            label4.Text = "Tipo SUA";
            // 
            // txbSUAType
            // 
            txbSUAType.Enabled = false;
            txbSUAType.Location = new Point(73, 145);
            txbSUAType.MaxLength = 20;
            txbSUAType.Name = "txbSUAType";
            txbSUAType.Size = new Size(189, 23);
            txbSUAType.TabIndex = 19;
            txbSUAType.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 119);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 18;
            label3.Text = "Razón social";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(257, 90);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 15;
            label1.Text = "Ruta SUA";
            // 
            // txbSUAPath
            // 
            txbSUAPath.Enabled = false;
            txbSUAPath.Location = new Point(318, 87);
            txbSUAPath.MaxLength = 200;
            txbSUAPath.Name = "txbSUAPath";
            txbSUAPath.Size = new Size(332, 23);
            txbSUAPath.TabIndex = 16;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(395, 119);
            label2.Name = "label2";
            label2.Size = new Size(97, 15);
            label2.TabIndex = 23;
            label2.Text = "Registro patronal";
            // 
            // txbRegPatGrower
            // 
            txbRegPatGrower.Enabled = false;
            txbRegPatGrower.Location = new Point(498, 116);
            txbRegPatGrower.Name = "txbRegPatGrower";
            txbRegPatGrower.Size = new Size(97, 23);
            txbRegPatGrower.TabIndex = 24;
            txbRegPatGrower.TextAlign = HorizontalAlignment.Center;
            // 
            // lblid
            // 
            lblid.AutoSize = true;
            lblid.Location = new Point(13, 62);
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
            dgvQuery.Location = new Point(13, 203);
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
            dgvQuery.Size = new Size(638, 385);
            dgvQuery.TabIndex = 26;
            // 
            // cboIdSUAConfig
            // 
            cboIdSUAConfig.DropDownStyle = ComboBoxStyle.DropDownList;
            cboIdSUAConfig.FormattingEnabled = true;
            cboIdSUAConfig.Location = new Point(42, 58);
            cboIdSUAConfig.Name = "cboIdSUAConfig";
            cboIdSUAConfig.Size = new Size(393, 23);
            cboIdSUAConfig.TabIndex = 27;
            // 
            // btnAddSUAConfig
            // 
            btnAddSUAConfig.Image = Properties.Resources.addFileIcon16;
            btnAddSUAConfig.Location = new Point(441, 57);
            btnAddSUAConfig.Name = "btnAddSUAConfig";
            btnAddSUAConfig.Size = new Size(24, 24);
            btnAddSUAConfig.TabIndex = 28;
            btnAddSUAConfig.UseVisualStyleBackColor = true;
            btnAddSUAConfig.Click += btnAddSUAConfig_Click;
            // 
            // btnModifySUAConfig
            // 
            btnModifySUAConfig.Image = Properties.Resources.modifyFileIcon16;
            btnModifySUAConfig.Location = new Point(467, 57);
            btnModifySUAConfig.Name = "btnModifySUAConfig";
            btnModifySUAConfig.Size = new Size(24, 24);
            btnModifySUAConfig.TabIndex = 29;
            btnModifySUAConfig.UseVisualStyleBackColor = true;
            btnModifySUAConfig.Click += btnModifySUAConfig_Click;
            // 
            // btnDeleteSUAConfig
            // 
            btnDeleteSUAConfig.Image = Properties.Resources.basuraIcon16;
            btnDeleteSUAConfig.Location = new Point(493, 57);
            btnDeleteSUAConfig.Name = "btnDeleteSUAConfig";
            btnDeleteSUAConfig.Size = new Size(24, 24);
            btnDeleteSUAConfig.TabIndex = 30;
            btnDeleteSUAConfig.UseVisualStyleBackColor = true;
            btnDeleteSUAConfig.Click += btnDeleteSUAConfig_Click;
            // 
            // txbGrower
            // 
            txbGrower.Enabled = false;
            txbGrower.Location = new Point(92, 116);
            txbGrower.MaxLength = 200;
            txbGrower.Name = "txbGrower";
            txbGrower.Size = new Size(298, 23);
            txbGrower.TabIndex = 31;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(11, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(143, 21);
            lblTitle.TabIndex = 32;
            lblTitle.Text = "Añadir datos SUA";
            // 
            // FrmSUALoad
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(661, 629);
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
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "FrmSUALoad";
            Text = "FrmSUALoad";
            Load += FrmSUALoad_Load;
            ((System.ComponentModel.ISupportInitialize)dgvQuery).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
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
    }
}