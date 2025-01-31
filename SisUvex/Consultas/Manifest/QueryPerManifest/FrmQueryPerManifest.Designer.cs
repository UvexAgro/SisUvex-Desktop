namespace SisUvex.Consultas.Manifest.QueryPerManifest
{
    partial class FrmQueryPerManifest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmQueryPerManifest));
            cboGrower = new ComboBox();
            label3 = new Label();
            cboVariety = new ComboBox();
            label2 = new Label();
            btnManifest = new Button();
            lblManifiesto = new Label();
            txbManifest = new TextBox();
            label1 = new Label();
            btnAll = new Button();
            cboContainer = new ComboBox();
            cboDistributor = new ComboBox();
            dtpDate2 = new DateTimePicker();
            dtpDate1 = new DateTimePicker();
            dgvQuery = new DataGridView();
            btnSearch = new Button();
            lblDistribuidor = new Label();
            lblY = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvQuery).BeginInit();
            SuspendLayout();
            // 
            // cboGrower
            // 
            cboGrower.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGrower.FormattingEnabled = true;
            cboGrower.Location = new Point(12, 47);
            cboGrower.Name = "cboGrower";
            cboGrower.Size = new Size(203, 23);
            cboGrower.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 6.75F);
            label3.Location = new Point(12, 35);
            label3.Name = "label3";
            label3.Size = new Size(43, 12);
            label3.TabIndex = 61;
            label3.Text = "Productor";
            // 
            // cboVariety
            // 
            cboVariety.DropDownStyle = ComboBoxStyle.DropDownList;
            cboVariety.FormattingEnabled = true;
            cboVariety.Location = new Point(221, 47);
            cboVariety.Name = "cboVariety";
            cboVariety.Size = new Size(203, 23);
            cboVariety.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 6.75F);
            label2.Location = new Point(221, 35);
            label2.Name = "label2";
            label2.Size = new Size(40, 12);
            label2.TabIndex = 59;
            label2.Text = "Variedad";
            // 
            // btnManifest
            // 
            btnManifest.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnManifest.BackgroundImageLayout = ImageLayout.Stretch;
            btnManifest.Location = new Point(567, 73);
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
            lblManifiesto.Location = new Point(491, 60);
            lblManifiesto.Name = "lblManifiesto";
            lblManifiesto.Size = new Size(47, 12);
            lblManifiesto.TabIndex = 53;
            lblManifiesto.Text = "Manifiesto";
            // 
            // txbManifest
            // 
            txbManifest.Location = new Point(491, 72);
            txbManifest.MaxLength = 5;
            txbManifest.Name = "txbManifest";
            txbManifest.Size = new Size(75, 23);
            txbManifest.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 6.75F);
            label1.Location = new Point(221, -1);
            label1.Name = "label1";
            label1.Size = new Size(78, 12);
            label1.TabIndex = 51;
            label1.Text = "Contenedor (Caja)";
            // 
            // btnAll
            // 
            btnAll.BackgroundImage = Properties.Resources.reiniciarMini;
            btnAll.BackgroundImageLayout = ImageLayout.Stretch;
            btnAll.Location = new Point(397, 73);
            btnAll.Name = "btnAll";
            btnAll.Size = new Size(27, 23);
            btnAll.TabIndex = 7;
            btnAll.UseVisualStyleBackColor = true;
            btnAll.Click += btnAll_Click;
            // 
            // cboContainer
            // 
            cboContainer.DropDownStyle = ComboBoxStyle.DropDownList;
            cboContainer.FormattingEnabled = true;
            cboContainer.Location = new Point(221, 11);
            cboContainer.Name = "cboContainer";
            cboContainer.Size = new Size(203, 23);
            cboContainer.TabIndex = 1;
            // 
            // cboDistributor
            // 
            cboDistributor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDistributor.FormattingEnabled = true;
            cboDistributor.Location = new Point(12, 11);
            cboDistributor.Name = "cboDistributor";
            cboDistributor.Size = new Size(203, 23);
            cboDistributor.TabIndex = 0;
            // 
            // dtpDate2
            // 
            dtpDate2.Format = DateTimePickerFormat.Short;
            dtpDate2.Location = new Point(277, 73);
            dtpDate2.Name = "dtpDate2";
            dtpDate2.Size = new Size(80, 23);
            dtpDate2.TabIndex = 5;
            // 
            // dtpDate1
            // 
            dtpDate1.Format = DateTimePickerFormat.Short;
            dtpDate1.Location = new Point(185, 73);
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
            dgvQuery.Location = new Point(12, 100);
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
            dgvQuery.Size = new Size(576, 337);
            dgvQuery.TabIndex = 10;
            dgvQuery.CellFormatting += dgvQuery_CellFormatting;
            // 
            // btnSearch
            // 
            btnSearch.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnSearch.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearch.Location = new Point(360, 73);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(23, 23);
            btnSearch.TabIndex = 6;
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // lblDistribuidor
            // 
            lblDistribuidor.AutoSize = true;
            lblDistribuidor.Font = new Font("Segoe UI", 6.75F);
            lblDistribuidor.Location = new Point(12, -1);
            lblDistribuidor.Name = "lblDistribuidor";
            lblDistribuidor.Size = new Size(50, 12);
            lblDistribuidor.TabIndex = 50;
            lblDistribuidor.Text = "Distribuidor";
            // 
            // lblY
            // 
            lblY.AutoSize = true;
            lblY.Location = new Point(265, 79);
            lblY.Name = "lblY";
            lblY.Size = new Size(13, 15);
            lblY.TabIndex = 46;
            lblY.Text = "y";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 6.75F);
            label4.Location = new Point(129, 81);
            label4.Name = "label4";
            label4.Size = new Size(56, 12);
            label4.TabIndex = 62;
            label4.Text = "Entre fechas:";
            // 
            // FrmQueryPerManifest
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(600, 450);
            Controls.Add(label4);
            Controls.Add(cboGrower);
            Controls.Add(label3);
            Controls.Add(cboVariety);
            Controls.Add(label2);
            Controls.Add(btnManifest);
            Controls.Add(lblManifiesto);
            Controls.Add(txbManifest);
            Controls.Add(label1);
            Controls.Add(btnAll);
            Controls.Add(cboContainer);
            Controls.Add(cboDistributor);
            Controls.Add(dtpDate2);
            Controls.Add(dtpDate1);
            Controls.Add(dgvQuery);
            Controls.Add(btnSearch);
            Controls.Add(lblDistribuidor);
            Controls.Add(lblY);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmQueryPerManifest";
            Text = "Detalles manifiesto";
            WindowState = FormWindowState.Maximized;
            Load += FrmQueryPerManifest_Load;
            ((System.ComponentModel.ISupportInitialize)dgvQuery).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public ComboBox cboGrower;
        private Label label3;
        public ComboBox cboVariety;
        private Label label2;
        private Button btnManifest;
        private Label lblManifiesto;
        public TextBox txbManifest;
        private Label label1;
        private Button btnAll;
        public ComboBox cboContainer;
        public ComboBox cboDistributor;
        public DateTimePicker dtpDate2;
        public DateTimePicker dtpDate1;
        public DataGridView dgvQuery;
        private Button btnSearch;
        private Label lblDistribuidor;
        private Label lblY;
        private Label label4;
    }
}