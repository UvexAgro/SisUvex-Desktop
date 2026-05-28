namespace SisUvex.Nomina.CONTRATO.PayrollPack_BoxPerNumber.BoxPerEmployeeReport
{
    partial class FrmPayrollBoxPerEmployeeReport
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
            gpbFilters = new GroupBox();
            cboUser = new ComboBox();
            labelUser = new Label();
            dtpDate2 = new DateTimePicker();
            dtpDate1 = new DateTimePicker();
            labelDateTo = new Label();
            labelDate = new Label();
            cboSeason = new ComboBox();
            cboWorkGroup = new ComboBox();
            labelWorkGroup = new Label();
            labelSeason = new Label();
            labelContractor = new Label();
            cboContractor = new ComboBox();
            btnSearch = new Button();
            dgvReport = new DataGridView();
            bgpInfo = new GroupBox();
            lblUser = new Label();
            labelInfoUser = new Label();
            lblDateRange = new Label();
            labelInfoDates = new Label();
            lblWorkGroup = new Label();
            labelInfoWorkGroup = new Label();
            lblContractor = new Label();
            labelInfoContractor = new Label();
            lblSeason = new Label();
            labelInfoSeason = new Label();
            btnExcel = new Button();
            lblTitle = new Label();
            gpbFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReport).BeginInit();
            bgpInfo.SuspendLayout();
            SuspendLayout();
            // 
            // gpbFilters
            // 
            gpbFilters.Controls.Add(cboUser);
            gpbFilters.Controls.Add(labelUser);
            gpbFilters.Controls.Add(dtpDate2);
            gpbFilters.Controls.Add(dtpDate1);
            gpbFilters.Controls.Add(labelDateTo);
            gpbFilters.Controls.Add(labelDate);
            gpbFilters.Controls.Add(cboSeason);
            gpbFilters.Controls.Add(cboWorkGroup);
            gpbFilters.Controls.Add(labelWorkGroup);
            gpbFilters.Controls.Add(labelSeason);
            gpbFilters.Controls.Add(labelContractor);
            gpbFilters.Controls.Add(cboContractor);
            gpbFilters.Font = new Font("Segoe UI", 12F);
            gpbFilters.Location = new Point(12, 33);
            gpbFilters.Name = "gpbFilters";
            gpbFilters.Size = new Size(859, 167);
            gpbFilters.TabIndex = 51;
            gpbFilters.TabStop = false;
            gpbFilters.Text = "Filtros";
            // 
            // cboUser
            // 
            cboUser.DropDownStyle = ComboBoxStyle.DropDownList;
            cboUser.FormattingEnabled = true;
            cboUser.Location = new Point(425, 92);
            cboUser.Margin = new Padding(0, 3, 3, 3);
            cboUser.Name = "cboUser";
            cboUser.Size = new Size(360, 29);
            cboUser.TabIndex = 56;
            // 
            // labelUser
            // 
            labelUser.AutoSize = true;
            labelUser.Location = new Point(353, 95);
            labelUser.Margin = new Padding(0);
            labelUser.Name = "labelUser";
            labelUser.Size = new Size(75, 21);
            labelUser.TabIndex = 55;
            labelUser.Text = "Anotador";
            // 
            // dtpDate2
            // 
            dtpDate2.Format = DateTimePickerFormat.Short;
            dtpDate2.Location = new Point(297, 127);
            dtpDate2.Name = "dtpDate2";
            dtpDate2.Size = new Size(120, 29);
            dtpDate2.TabIndex = 53;
            // 
            // dtpDate1
            // 
            dtpDate1.Format = DateTimePickerFormat.Short;
            dtpDate1.Location = new Point(123, 127);
            dtpDate1.Name = "dtpDate1";
            dtpDate1.Size = new Size(120, 29);
            dtpDate1.TabIndex = 52;
            // 
            // labelDateTo
            // 
            labelDateTo.AutoSize = true;
            labelDateTo.Location = new Point(249, 132);
            labelDateTo.Margin = new Padding(0);
            labelDateTo.Name = "labelDateTo";
            labelDateTo.Size = new Size(22, 21);
            labelDateTo.TabIndex = 51;
            labelDateTo.Text = "al";
            // 
            // labelDate
            // 
            labelDate.AutoSize = true;
            labelDate.Location = new Point(13, 132);
            labelDate.Margin = new Padding(0);
            labelDate.Name = "labelDate";
            labelDate.Size = new Size(103, 21);
            labelDate.TabIndex = 50;
            labelDate.Text = "Rango fechas";
            // 
            // cboSeason
            // 
            cboSeason.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSeason.FormattingEnabled = true;
            cboSeason.Location = new Point(123, 26);
            cboSeason.Margin = new Padding(0, 3, 3, 3);
            cboSeason.Name = "cboSeason";
            cboSeason.Size = new Size(190, 29);
            cboSeason.TabIndex = 49;
            // 
            // cboWorkGroup
            // 
            cboWorkGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            cboWorkGroup.FormattingEnabled = true;
            cboWorkGroup.Location = new Point(425, 57);
            cboWorkGroup.Margin = new Padding(0, 3, 3, 3);
            cboWorkGroup.Name = "cboWorkGroup";
            cboWorkGroup.Size = new Size(360, 29);
            cboWorkGroup.TabIndex = 45;
            // 
            // labelWorkGroup
            // 
            labelWorkGroup.AutoSize = true;
            labelWorkGroup.Location = new Point(353, 60);
            labelWorkGroup.Margin = new Padding(0);
            labelWorkGroup.Name = "labelWorkGroup";
            labelWorkGroup.Size = new Size(72, 21);
            labelWorkGroup.TabIndex = 44;
            labelWorkGroup.Text = "Cuadrilla";
            // 
            // labelSeason
            // 
            labelSeason.AutoSize = true;
            labelSeason.Location = new Point(37, 29);
            labelSeason.Margin = new Padding(0);
            labelSeason.Name = "labelSeason";
            labelSeason.Size = new Size(87, 21);
            labelSeason.TabIndex = 48;
            labelSeason.Text = "Temporada";
            // 
            // labelContractor
            // 
            labelContractor.AutoSize = true;
            labelContractor.Location = new Point(37, 63);
            labelContractor.Margin = new Padding(0);
            labelContractor.Name = "labelContractor";
            labelContractor.Size = new Size(86, 21);
            labelContractor.TabIndex = 22;
            labelContractor.Text = "Contratista";
            // 
            // cboContractor
            // 
            cboContractor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboContractor.FormattingEnabled = true;
            cboContractor.Location = new Point(123, 58);
            cboContractor.Margin = new Padding(0, 3, 3, 3);
            cboContractor.Name = "cboContractor";
            cboContractor.Size = new Size(190, 29);
            cboContractor.TabIndex = 24;
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Segoe UI", 12F);
            btnSearch.Image = Properties.Resources.BuscarLupa1;
            btnSearch.ImageAlign = ContentAlignment.MiddleRight;
            btnSearch.Location = new Point(774, 210);
            btnSearch.Name = "btnSearch";
            btnSearch.Padding = new Padding(0, 0, 4, 0);
            btnSearch.Size = new Size(87, 31);
            btnSearch.TabIndex = 68;
            btnSearch.Text = "Buscar";
            btnSearch.TextAlign = ContentAlignment.TopLeft;
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // dgvReport
            // 
            dgvReport.AllowUserToAddRows = false;
            dgvReport.AllowUserToDeleteRows = false;
            dgvReport.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvReport.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvReport.BackgroundColor = SystemColors.Control;
            dgvReport.BorderStyle = BorderStyle.Fixed3D;
            dgvReport.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvReport.EnableHeadersVisualStyles = false;
            dgvReport.ImeMode = ImeMode.NoControl;
            dgvReport.Location = new Point(12, 353);
            dgvReport.Name = "dgvReport";
            dgvReport.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvReport.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvReport.RowHeadersVisible = false;
            dgvReport.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReport.Size = new Size(859, 302);
            dgvReport.TabIndex = 69;
            // 
            // bgpInfo
            // 
            bgpInfo.Controls.Add(lblUser);
            bgpInfo.Controls.Add(labelInfoUser);
            bgpInfo.Controls.Add(lblDateRange);
            bgpInfo.Controls.Add(labelInfoDates);
            bgpInfo.Controls.Add(lblWorkGroup);
            bgpInfo.Controls.Add(labelInfoWorkGroup);
            bgpInfo.Controls.Add(lblContractor);
            bgpInfo.Controls.Add(labelInfoContractor);
            bgpInfo.Controls.Add(lblSeason);
            bgpInfo.Controls.Add(labelInfoSeason);
            bgpInfo.Font = new Font("Segoe UI", 12F);
            bgpInfo.Location = new Point(12, 241);
            bgpInfo.Name = "bgpInfo";
            bgpInfo.Size = new Size(756, 105);
            bgpInfo.TabIndex = 70;
            bgpInfo.TabStop = false;
            bgpInfo.Text = "Detalles";
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblUser.Location = new Point(521, 46);
            lblUser.Margin = new Padding(0);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(64, 21);
            lblUser.TabIndex = 68;
            lblUser.Tag = "lotData";
            lblUser.Text = "lblUser";
            // 
            // labelInfoUser
            // 
            labelInfoUser.AutoSize = true;
            labelInfoUser.Location = new Point(444, 46);
            labelInfoUser.Margin = new Padding(0);
            labelInfoUser.Name = "labelInfoUser";
            labelInfoUser.Size = new Size(78, 21);
            labelInfoUser.TabIndex = 67;
            labelInfoUser.Text = "Anotador:";
            labelInfoUser.TextAlign = ContentAlignment.TopRight;
            // 
            // lblDateRange
            // 
            lblDateRange.AutoSize = true;
            lblDateRange.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblDateRange.Location = new Point(96, 67);
            lblDateRange.Margin = new Padding(0);
            lblDateRange.Name = "lblDateRange";
            lblDateRange.Size = new Size(114, 21);
            lblDateRange.TabIndex = 62;
            lblDateRange.Tag = "lotData";
            lblDateRange.Text = "lblDateRange";
            // 
            // labelInfoDates
            // 
            labelInfoDates.AutoSize = true;
            labelInfoDates.Location = new Point(34, 67);
            labelInfoDates.Margin = new Padding(0);
            labelInfoDates.Name = "labelInfoDates";
            labelInfoDates.Size = new Size(60, 21);
            labelInfoDates.TabIndex = 61;
            labelInfoDates.Text = "Fechas:";
            labelInfoDates.TextAlign = ContentAlignment.TopRight;
            // 
            // lblWorkGroup
            // 
            lblWorkGroup.AutoSize = true;
            lblWorkGroup.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblWorkGroup.Location = new Point(521, 25);
            lblWorkGroup.Margin = new Padding(0);
            lblWorkGroup.Name = "lblWorkGroup";
            lblWorkGroup.Size = new Size(118, 21);
            lblWorkGroup.TabIndex = 58;
            lblWorkGroup.Tag = "lotData";
            lblWorkGroup.Text = "lblWorkGroup";
            // 
            // labelInfoWorkGroup
            // 
            labelInfoWorkGroup.AutoSize = true;
            labelInfoWorkGroup.Location = new Point(446, 25);
            labelInfoWorkGroup.Margin = new Padding(0);
            labelInfoWorkGroup.Name = "labelInfoWorkGroup";
            labelInfoWorkGroup.Size = new Size(75, 21);
            labelInfoWorkGroup.TabIndex = 57;
            labelInfoWorkGroup.Text = "Cuadrilla:";
            labelInfoWorkGroup.TextAlign = ContentAlignment.TopRight;
            // 
            // lblContractor
            // 
            lblContractor.AutoSize = true;
            lblContractor.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblContractor.Location = new Point(96, 46);
            lblContractor.Margin = new Padding(0);
            lblContractor.Name = "lblContractor";
            lblContractor.Size = new Size(111, 21);
            lblContractor.TabIndex = 56;
            lblContractor.Tag = "lotData";
            lblContractor.Text = "lblContractor";
            // 
            // labelInfoContractor
            // 
            labelInfoContractor.AutoSize = true;
            labelInfoContractor.Location = new Point(5, 46);
            labelInfoContractor.Margin = new Padding(0);
            labelInfoContractor.Name = "labelInfoContractor";
            labelInfoContractor.Size = new Size(89, 21);
            labelInfoContractor.TabIndex = 55;
            labelInfoContractor.Text = "Contratista:";
            labelInfoContractor.TextAlign = ContentAlignment.TopRight;
            // 
            // lblSeason
            // 
            lblSeason.AutoSize = true;
            lblSeason.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblSeason.Location = new Point(96, 25);
            lblSeason.Margin = new Padding(0);
            lblSeason.Name = "lblSeason";
            lblSeason.Size = new Size(84, 21);
            lblSeason.TabIndex = 54;
            lblSeason.Tag = "lotData";
            lblSeason.Text = "lblSeason";
            // 
            // labelInfoSeason
            // 
            labelInfoSeason.AutoSize = true;
            labelInfoSeason.Location = new Point(5, 25);
            labelInfoSeason.Margin = new Padding(0);
            labelInfoSeason.Name = "labelInfoSeason";
            labelInfoSeason.Size = new Size(90, 21);
            labelInfoSeason.TabIndex = 53;
            labelInfoSeason.Text = "Temporada:";
            labelInfoSeason.TextAlign = ContentAlignment.TopRight;
            // 
            // btnExcel
            // 
            btnExcel.Font = new Font("Segoe UI", 12F);
            btnExcel.Image = Properties.Resources.excelIcon;
            btnExcel.ImageAlign = ContentAlignment.MiddleRight;
            btnExcel.Location = new Point(774, 315);
            btnExcel.Name = "btnExcel";
            btnExcel.Padding = new Padding(0, 0, 4, 0);
            btnExcel.Size = new Size(97, 31);
            btnExcel.TabIndex = 71;
            btnExcel.Text = "Excel";
            btnExcel.TextAlign = ContentAlignment.TopLeft;
            btnExcel.UseVisualStyleBackColor = true;
            btnExcel.Click += btnExcel_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Margin = new Padding(0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(223, 21);
            lblTitle.TabIndex = 61;
            lblTitle.Tag = "lotData";
            lblTitle.Text = "Reporte cajas por empleado";
            // 
            // FrmPayrollBoxPerEmployeeReport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoScrollMargin = new Size(10, 10);
            AutoScrollMinSize = new Size(0, 600);
            ClientSize = new Size(883, 667);
            Controls.Add(lblTitle);
            Controls.Add(btnExcel);
            Controls.Add(btnSearch);
            Controls.Add(bgpInfo);
            Controls.Add(gpbFilters);
            Controls.Add(dgvReport);
            Name = "FrmPayrollBoxPerEmployeeReport";
            Text = "Reporte cajas por empleado";
            Load += FrmPayrollBoxPerEmployeeReport_Load;
            gpbFilters.ResumeLayout(false);
            gpbFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReport).EndInit();
            bgpInfo.ResumeLayout(false);
            bgpInfo.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox gpbFilters;
        private System.Windows.Forms.Label labelContractor;
        public System.Windows.Forms.ComboBox cboContractor;
        private System.Windows.Forms.Label labelWorkGroup;
        public System.Windows.Forms.ComboBox cboWorkGroup;
        private System.Windows.Forms.Label labelSeason;
        public System.Windows.Forms.ComboBox cboSeason;
        private System.Windows.Forms.Button btnSearch;
        public System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.GroupBox bgpInfo;
        public System.Windows.Forms.Label lblWorkGroup;
        private System.Windows.Forms.Label labelInfoWorkGroup;
        public System.Windows.Forms.Label lblContractor;
        private System.Windows.Forms.Label labelInfoContractor;
        public System.Windows.Forms.Label lblSeason;
        private System.Windows.Forms.Label labelInfoSeason;
        private System.Windows.Forms.Button btnExcel;
        public System.Windows.Forms.Label lblTitle;
        public System.Windows.Forms.DateTimePicker dtpDate1;
        public System.Windows.Forms.DateTimePicker dtpDate2;
        private System.Windows.Forms.Label labelDateTo;
        private System.Windows.Forms.Label labelDate;
        public System.Windows.Forms.Label lblDateRange;
        private System.Windows.Forms.Label labelInfoDates;
        public System.Windows.Forms.ComboBox cboUser;
        private System.Windows.Forms.Label labelUser;
        public System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label labelInfoUser;
    }
}

