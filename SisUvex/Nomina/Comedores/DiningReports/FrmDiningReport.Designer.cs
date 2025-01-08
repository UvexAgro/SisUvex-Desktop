namespace SisUvex.Nomina.Comedores.DiningReports
{
    partial class FrmDiningReport
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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDiningReport));
            cboPaymentPlace = new ComboBox();
            lblPaymentPlace = new Label();
            btnSearchEmployee = new Button();
            lblIdEmployee = new Label();
            txbIdEmployee = new TextBox();
            cboDinerProvider = new ComboBox();
            dtpDate2 = new DateTimePicker();
            dtpDate1 = new DateTimePicker();
            dgvQuery = new DataGridView();
            btnSearch = new Button();
            lblDistribuidor = new Label();
            lblY = new Label();
            label4 = new Label();
            btnReport1 = new Button();
            btnResume = new Button();
            btnExcel = new Button();
            btnFrmSearchEmployeeId = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvQuery).BeginInit();
            SuspendLayout();
            // 
            // cboPaymentPlace
            // 
            cboPaymentPlace.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPaymentPlace.FormattingEnabled = true;
            cboPaymentPlace.Location = new Point(5, 50);
            cboPaymentPlace.Name = "cboPaymentPlace";
            cboPaymentPlace.Size = new Size(356, 23);
            cboPaymentPlace.TabIndex = 58;
            // 
            // lblPaymentPlace
            // 
            lblPaymentPlace.AutoSize = true;
            lblPaymentPlace.Font = new Font("Segoe UI", 6.75F);
            lblPaymentPlace.Location = new Point(5, 38);
            lblPaymentPlace.Name = "lblPaymentPlace";
            lblPaymentPlace.Size = new Size(61, 12);
            lblPaymentPlace.TabIndex = 59;
            lblPaymentPlace.Text = "Lugar de pago";
            // 
            // btnSearchEmployee
            // 
            btnSearchEmployee.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnSearchEmployee.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearchEmployee.Location = new Point(88, 89);
            btnSearchEmployee.Name = "btnSearchEmployee";
            btnSearchEmployee.Size = new Size(23, 23);
            btnSearchEmployee.TabIndex = 55;
            btnSearchEmployee.UseVisualStyleBackColor = true;
            btnSearchEmployee.Click += btnSearchEmployee_Click;
            // 
            // lblIdEmployee
            // 
            lblIdEmployee.AutoSize = true;
            lblIdEmployee.Font = new Font("Segoe UI", 6.75F);
            lblIdEmployee.Location = new Point(5, 76);
            lblIdEmployee.Name = "lblIdEmployee";
            lblIdEmployee.Size = new Size(87, 12);
            lblIdEmployee.TabIndex = 54;
            lblIdEmployee.Text = "Código de empleado";
            // 
            // txbIdEmployee
            // 
            txbIdEmployee.Location = new Point(5, 88);
            txbIdEmployee.MaxLength = 6;
            txbIdEmployee.Name = "txbIdEmployee";
            txbIdEmployee.Size = new Size(80, 23);
            txbIdEmployee.TabIndex = 53;
            txbIdEmployee.KeyPress += txbIdEmployee_KeyPress;
            // 
            // cboDinerProvider
            // 
            cboDinerProvider.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDinerProvider.FormattingEnabled = true;
            cboDinerProvider.Location = new Point(187, 12);
            cboDinerProvider.Name = "cboDinerProvider";
            cboDinerProvider.Size = new Size(174, 23);
            cboDinerProvider.TabIndex = 48;
            // 
            // dtpDate2
            // 
            dtpDate2.Format = DateTimePickerFormat.Short;
            dtpDate2.Location = new Point(101, 12);
            dtpDate2.Name = "dtpDate2";
            dtpDate2.Size = new Size(80, 23);
            dtpDate2.TabIndex = 46;
            // 
            // dtpDate1
            // 
            dtpDate1.Format = DateTimePickerFormat.Short;
            dtpDate1.Location = new Point(5, 12);
            dtpDate1.Name = "dtpDate1";
            dtpDate1.Size = new Size(80, 23);
            dtpDate1.TabIndex = 45;
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
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            dataGridViewCellStyle5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvQuery.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvQuery.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvQuery.EnableHeadersVisualStyles = false;
            dgvQuery.ImeMode = ImeMode.NoControl;
            dgvQuery.Location = new Point(5, 156);
            dgvQuery.Name = "dgvQuery";
            dgvQuery.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Control;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dgvQuery.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dgvQuery.RowHeadersVisible = false;
            dgvQuery.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvQuery.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvQuery.Size = new Size(585, 282);
            dgvQuery.TabIndex = 44;
            // 
            // btnSearch
            // 
            btnSearch.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnSearch.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearch.Location = new Point(363, 50);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(23, 23);
            btnSearch.TabIndex = 43;
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // lblDistribuidor
            // 
            lblDistribuidor.AutoSize = true;
            lblDistribuidor.Font = new Font("Segoe UI", 6.75F);
            lblDistribuidor.Location = new Point(187, 0);
            lblDistribuidor.Name = "lblDistribuidor";
            lblDistribuidor.Size = new Size(45, 12);
            lblDistribuidor.TabIndex = 51;
            lblDistribuidor.Text = "Proveedor";
            // 
            // lblY
            // 
            lblY.AutoSize = true;
            lblY.Location = new Point(85, 18);
            lblY.Name = "lblY";
            lblY.Size = new Size(16, 15);
            lblY.TabIndex = 47;
            lblY.Text = "al";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 6.75F);
            label4.Location = new Point(5, 0);
            label4.Name = "label4";
            label4.Size = new Size(56, 12);
            label4.TabIndex = 60;
            label4.Text = "Entre fechas:";
            // 
            // btnReport1
            // 
            btnReport1.Location = new Point(5, 127);
            btnReport1.Name = "btnReport1";
            btnReport1.Size = new Size(75, 23);
            btnReport1.TabIndex = 61;
            btnReport1.Text = "Trabajador";
            btnReport1.UseVisualStyleBackColor = true;
            btnReport1.Click += btnReport1_Click;
            // 
            // btnResume
            // 
            btnResume.Location = new Point(85, 127);
            btnResume.Name = "btnResume";
            btnResume.Size = new Size(92, 23);
            btnResume.TabIndex = 62;
            btnResume.Text = "Lugar de pago";
            btnResume.UseVisualStyleBackColor = true;
            btnResume.Click += btnResume_Click;
            // 
            // btnExcel
            // 
            btnExcel.BackgroundImageLayout = ImageLayout.Stretch;
            btnExcel.Image = (Image)resources.GetObject("btnExcel.Image");
            btnExcel.ImageAlign = ContentAlignment.MiddleRight;
            btnExcel.Location = new Point(183, 127);
            btnExcel.Name = "btnExcel";
            btnExcel.Size = new Size(56, 23);
            btnExcel.TabIndex = 63;
            btnExcel.Text = "Excel";
            btnExcel.TextAlign = ContentAlignment.BottomLeft;
            btnExcel.UseVisualStyleBackColor = true;
            btnExcel.Click += btnExcel_Click;
            // 
            // btnFrmSearchEmployeeId
            // 
            btnFrmSearchEmployeeId.BackgroundImageLayout = ImageLayout.Stretch;
            btnFrmSearchEmployeeId.Location = new Point(113, 89);
            btnFrmSearchEmployeeId.Name = "btnFrmSearchEmployeeId";
            btnFrmSearchEmployeeId.Size = new Size(26, 23);
            btnFrmSearchEmployeeId.TabIndex = 64;
            btnFrmSearchEmployeeId.Text = "...";
            btnFrmSearchEmployeeId.UseVisualStyleBackColor = true;
            btnFrmSearchEmployeeId.Click += btnFrmSearchEmployeeId_Click;
            // 
            // FrmDiningReport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(602, 450);
            Controls.Add(btnFrmSearchEmployeeId);
            Controls.Add(btnExcel);
            Controls.Add(btnResume);
            Controls.Add(btnReport1);
            Controls.Add(cboPaymentPlace);
            Controls.Add(lblPaymentPlace);
            Controls.Add(btnSearchEmployee);
            Controls.Add(lblIdEmployee);
            Controls.Add(txbIdEmployee);
            Controls.Add(cboDinerProvider);
            Controls.Add(dtpDate2);
            Controls.Add(dtpDate1);
            Controls.Add(dgvQuery);
            Controls.Add(btnSearch);
            Controls.Add(lblDistribuidor);
            Controls.Add(lblY);
            Controls.Add(label4);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmDiningReport";
            Text = "Reportes comedor";
            Load += FrmDiningReport_Load;
            ((System.ComponentModel.ISupportInitialize)dgvQuery).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public ComboBox cboPaymentPlace;
        private Label lblPaymentPlace;
        private Button btnSearchEmployee;
        private Label lblIdEmployee;
        public TextBox txbIdEmployee;
        public ComboBox cboDinerProvider;
        public DateTimePicker dtpDate2;
        public DateTimePicker dtpDate1;
        public DataGridView dgvQuery;
        private Button btnSearch;
        private Label lblDistribuidor;
        private Label lblY;
        private Label label4;
        private Button btnReport1;
        private Button btnResume;
        private Button btnExcel;
        private Button btnFrmSearchEmployeeId;
    }
}