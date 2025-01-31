namespace SisUvex.Consultas.Manifest
{
    partial class FrmManifestQuery
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmManifestQuery));
            btnManifest = new Button();
            lblManifiesto = new Label();
            txbManifest = new TextBox();
            label1 = new Label();
            btnAll = new Button();
            cboPresentation = new ComboBox();
            cboDistributor = new ComboBox();
            lblY = new Label();
            dtpDate2 = new DateTimePicker();
            dtpDate1 = new DateTimePicker();
            dgvQuery = new DataGridView();
            btnSearch = new Button();
            lblDistribuidor = new Label();
            cboVariety = new ComboBox();
            label2 = new Label();
            cboGrower = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvQuery).BeginInit();
            SuspendLayout();
            // 
            // btnManifest
            // 
            btnManifest.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnManifest.BackgroundImageLayout = ImageLayout.Stretch;
            btnManifest.Location = new Point(564, 74);
            btnManifest.Name = "btnManifest";
            btnManifest.Size = new Size(23, 23);
            btnManifest.TabIndex = 9;
            btnManifest.UseVisualStyleBackColor = true;
            btnManifest.Click += btnManifest_Click;
            // 
            // lblManifiesto
            // 
            lblManifiesto.AutoSize = true;
            lblManifiesto.Font = new Font("Segoe UI", 6.75F);
            lblManifiesto.Location = new Point(488, 61);
            lblManifiesto.Name = "lblManifiesto";
            lblManifiesto.Size = new Size(47, 12);
            lblManifiesto.TabIndex = 33;
            lblManifiesto.Text = "Manifiesto";
            // 
            // txbManifest
            // 
            txbManifest.Location = new Point(488, 73);
            txbManifest.MaxLength = 5;
            txbManifest.Name = "txbManifest";
            txbManifest.Size = new Size(75, 23);
            txbManifest.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 6.75F);
            label1.Location = new Point(221, 0);
            label1.Name = "label1";
            label1.Size = new Size(56, 12);
            label1.TabIndex = 31;
            label1.Text = "Presentación";
            // 
            // btnAll
            // 
            btnAll.Location = new Point(384, 74);
            btnAll.Name = "btnAll";
            btnAll.Size = new Size(41, 23);
            btnAll.TabIndex = 7;
            btnAll.Text = "Todo";
            btnAll.UseVisualStyleBackColor = true;
            btnAll.Click += btnAll_Click;
            // 
            // cboPresentation
            // 
            cboPresentation.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPresentation.FormattingEnabled = true;
            cboPresentation.Location = new Point(221, 12);
            cboPresentation.Name = "cboPresentation";
            cboPresentation.Size = new Size(203, 23);
            cboPresentation.TabIndex = 2;
            // 
            // cboDistributor
            // 
            cboDistributor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDistributor.FormattingEnabled = true;
            cboDistributor.Location = new Point(12, 12);
            cboDistributor.Name = "cboDistributor";
            cboDistributor.Size = new Size(203, 23);
            cboDistributor.TabIndex = 0;
            // 
            // lblY
            // 
            lblY.AutoSize = true;
            lblY.Location = new Point(265, 80);
            lblY.Name = "lblY";
            lblY.Size = new Size(13, 15);
            lblY.TabIndex = 26;
            lblY.Text = "y";
            // 
            // dtpDate2
            // 
            dtpDate2.Format = DateTimePickerFormat.Short;
            dtpDate2.Location = new Point(277, 74);
            dtpDate2.Name = "dtpDate2";
            dtpDate2.Size = new Size(80, 23);
            dtpDate2.TabIndex = 5;
            // 
            // dtpDate1
            // 
            dtpDate1.Format = DateTimePickerFormat.Short;
            dtpDate1.Location = new Point(185, 74);
            dtpDate1.Name = "dtpDate1";
            dtpDate1.Size = new Size(80, 23);
            dtpDate1.TabIndex = 4;
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
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvQuery.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvQuery.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvQuery.EnableHeadersVisualStyles = false;
            dgvQuery.ImeMode = ImeMode.NoControl;
            dgvQuery.Location = new Point(12, 101);
            dgvQuery.Name = "dgvQuery";
            dgvQuery.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvQuery.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvQuery.RowHeadersVisible = false;
            dgvQuery.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvQuery.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvQuery.Size = new Size(573, 337);
            dgvQuery.TabIndex = 10;
            // 
            // btnSearch
            // 
            btnSearch.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnSearch.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearch.Location = new Point(360, 74);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(23, 23);
            btnSearch.TabIndex = 6;
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnBuscar_Click;
            // 
            // lblDistribuidor
            // 
            lblDistribuidor.AutoSize = true;
            lblDistribuidor.Font = new Font("Segoe UI", 6.75F);
            lblDistribuidor.Location = new Point(12, 0);
            lblDistribuidor.Name = "lblDistribuidor";
            lblDistribuidor.Size = new Size(50, 12);
            lblDistribuidor.TabIndex = 30;
            lblDistribuidor.Text = "Distribuidor";
            // 
            // cboVariety
            // 
            cboVariety.DropDownStyle = ComboBoxStyle.DropDownList;
            cboVariety.FormattingEnabled = true;
            cboVariety.Location = new Point(221, 48);
            cboVariety.Name = "cboVariety";
            cboVariety.Size = new Size(203, 23);
            cboVariety.TabIndex = 38;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 6.75F);
            label2.Location = new Point(221, 36);
            label2.Name = "label2";
            label2.Size = new Size(40, 12);
            label2.TabIndex = 39;
            label2.Text = "Variedad";
            // 
            // cboGrower
            // 
            cboGrower.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGrower.FormattingEnabled = true;
            cboGrower.Location = new Point(12, 48);
            cboGrower.Name = "cboGrower";
            cboGrower.Size = new Size(203, 23);
            cboGrower.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 6.75F);
            label3.Location = new Point(12, 36);
            label3.Name = "label3";
            label3.Size = new Size(43, 12);
            label3.TabIndex = 41;
            label3.Text = "Productor";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 6.75F);
            label4.Location = new Point(129, 82);
            label4.Name = "label4";
            label4.Size = new Size(56, 12);
            label4.TabIndex = 42;
            label4.Text = "Entre fechas:";
            // 
            // FrmManifestQuery
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(597, 450);
            Controls.Add(cboGrower);
            Controls.Add(label3);
            Controls.Add(cboVariety);
            Controls.Add(label2);
            Controls.Add(btnManifest);
            Controls.Add(lblManifiesto);
            Controls.Add(txbManifest);
            Controls.Add(label1);
            Controls.Add(btnAll);
            Controls.Add(cboPresentation);
            Controls.Add(cboDistributor);
            Controls.Add(dtpDate2);
            Controls.Add(dtpDate1);
            Controls.Add(dgvQuery);
            Controls.Add(btnSearch);
            Controls.Add(lblDistribuidor);
            Controls.Add(lblY);
            Controls.Add(label4);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmManifestQuery";
            Text = "Consulta de cajas totales embarcadas por día";
            WindowState = FormWindowState.Maximized;
            Load += FrmManifestQuery_Load;
            ((System.ComponentModel.ISupportInitialize)dgvQuery).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnManifest;
        private Label lblManifiesto;
        private Label label1;
        private Button btnAll;
        private Label lblY;
        public DataGridView dgvQuery;
        private Button btnSearch;
        private Label lblDistribuidor;
        public TextBox txbManifest;
        public ComboBox cboPresentation;
        public ComboBox cboDistributor;
        public DateTimePicker dtpDate2;
        public DateTimePicker dtpDate1;
        public ComboBox cboVariety;
        private Label label2;
        public ComboBox cboGrower;
        private Label label3;
        private Label label4;
    }
}