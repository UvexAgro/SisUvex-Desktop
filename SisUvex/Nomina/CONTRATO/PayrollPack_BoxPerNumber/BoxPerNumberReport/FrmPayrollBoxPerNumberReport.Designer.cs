namespace SisUvex.Nomina.CONTRATO.PayrollPack_BoxPerNumber.BoxPerNumberReport
{
    partial class FrmPayrollBoxPerNumberReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPayrollBoxPerNumberReport));
            gpbFilters = new GroupBox();
            dtpDate2 = new DateTimePicker();
            dtpDate1 = new DateTimePicker();
            labelDateTo = new Label();
            labelDate = new Label();
            cboSeason = new ComboBox();
            cboWorkGroup = new ComboBox();
            label10 = new Label();
            label4 = new Label();
            lblField = new Label();
            cboContractor = new ComboBox();
            cboReportType = new ComboBox();
            labelReportType = new Label();
            btnSearch = new Button();
            dgvReport = new DataGridView();
            bgpInfo = new GroupBox();
            lblDateRange = new Label();
            label6 = new Label();
            lblWorkGroup = new Label();
            label2 = new Label();
            lblContractor = new Label();
            label3 = new Label();
            btnExcel = new Button();
            lblTitle = new Label();
            gpbFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReport).BeginInit();
            bgpInfo.SuspendLayout();
            SuspendLayout();
            // 
            // gpbFilters
            // 
            gpbFilters.Controls.Add(dtpDate2);
            gpbFilters.Controls.Add(dtpDate1);
            gpbFilters.Controls.Add(labelDateTo);
            gpbFilters.Controls.Add(labelDate);
            gpbFilters.Controls.Add(cboSeason);
            gpbFilters.Controls.Add(cboWorkGroup);
            gpbFilters.Controls.Add(label10);
            gpbFilters.Controls.Add(label4);
            gpbFilters.Controls.Add(lblField);
            gpbFilters.Controls.Add(cboContractor);
            gpbFilters.Controls.Add(cboReportType);
            gpbFilters.Controls.Add(labelReportType);
            gpbFilters.Font = new Font("Segoe UI", 12F);
            gpbFilters.Location = new Point(12, 33);
            gpbFilters.Name = "gpbFilters";
            gpbFilters.Size = new Size(859, 130);
            gpbFilters.TabIndex = 51;
            gpbFilters.TabStop = false;
            gpbFilters.Text = "Filtros";
            // 
            // dtpDate2
            // 
            dtpDate2.Format = DateTimePickerFormat.Short;
            dtpDate2.Location = new Point(297, 87);
            dtpDate2.Name = "dtpDate2";
            dtpDate2.Size = new Size(120, 29);
            dtpDate2.TabIndex = 53;
            // 
            // dtpDate1
            // 
            dtpDate1.Format = DateTimePickerFormat.Short;
            dtpDate1.Location = new Point(123, 87);
            dtpDate1.Name = "dtpDate1";
            dtpDate1.Size = new Size(120, 29);
            dtpDate1.TabIndex = 52;
            // 
            // labelDateTo
            // 
            labelDateTo.AutoSize = true;
            labelDateTo.Location = new Point(249, 92);
            labelDateTo.Margin = new Padding(0);
            labelDateTo.Name = "labelDateTo";
            labelDateTo.Size = new Size(22, 21);
            labelDateTo.TabIndex = 51;
            labelDateTo.Text = "al";
            // 
            // labelDate
            // 
            labelDate.AutoSize = true;
            labelDate.Location = new Point(13, 92);
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
            cboSeason.Location = new Point(123, 20);
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
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(353, 55);
            label10.Margin = new Padding(0);
            label10.Name = "label10";
            label10.Size = new Size(72, 21);
            label10.TabIndex = 44;
            label10.Text = "Cuadrilla";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(37, 23);
            label4.Margin = new Padding(0);
            label4.Name = "label4";
            label4.Size = new Size(87, 21);
            label4.TabIndex = 48;
            label4.Text = "Temporada";
            // 
            // lblField
            // 
            lblField.AutoSize = true;
            lblField.Location = new Point(37, 57);
            lblField.Margin = new Padding(0);
            lblField.Name = "lblField";
            lblField.Size = new Size(86, 21);
            lblField.TabIndex = 22;
            lblField.Text = "Contratista";
            // 
            // cboContractor
            // 
            cboContractor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboContractor.FormattingEnabled = true;
            cboContractor.Location = new Point(123, 52);
            cboContractor.Margin = new Padding(0, 3, 3, 3);
            cboContractor.Name = "cboContractor";
            cboContractor.Size = new Size(190, 29);
            cboContractor.TabIndex = 24;
            // 
            // cboReportType
            // 
            cboReportType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboReportType.FormattingEnabled = true;
            cboReportType.Location = new Point(425, 20);
            cboReportType.Name = "cboReportType";
            cboReportType.Size = new Size(360, 29);
            cboReportType.TabIndex = 54;
            cboReportType.SelectedIndexChanged += cboReportType_SelectedIndexChanged;
            // 
            // labelReportType
            // 
            labelReportType.AutoSize = true;
            labelReportType.Location = new Point(353, 23);
            labelReportType.Name = "labelReportType";
            labelReportType.Size = new Size(68, 21);
            labelReportType.TabIndex = 55;
            labelReportType.Text = "Consulta";
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Segoe UI", 12F);
            btnSearch.Image = Properties.Resources.BuscarLupa1;
            btnSearch.ImageAlign = ContentAlignment.MiddleRight;
            btnSearch.Location = new Point(774, 173);
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
            dgvReport.Location = new Point(12, 286);
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
            dgvReport.Size = new Size(859, 369);
            dgvReport.TabIndex = 69;
            // 
            // bgpInfo
            // 
            bgpInfo.Controls.Add(lblDateRange);
            bgpInfo.Controls.Add(label6);
            bgpInfo.Controls.Add(lblWorkGroup);
            bgpInfo.Controls.Add(label2);
            bgpInfo.Controls.Add(lblContractor);
            bgpInfo.Controls.Add(label3);
            bgpInfo.Font = new Font("Segoe UI", 12F);
            bgpInfo.Location = new Point(12, 163);
            bgpInfo.Name = "bgpInfo";
            bgpInfo.Size = new Size(756, 110);
            bgpInfo.TabIndex = 70;
            bgpInfo.TabStop = false;
            bgpInfo.Text = "Detalles";
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
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(34, 67);
            label6.Margin = new Padding(0);
            label6.Name = "label6";
            label6.Size = new Size(60, 21);
            label6.TabIndex = 61;
            label6.Text = "Fechas:";
            label6.TextAlign = ContentAlignment.TopRight;
            // 
            // lblWorkGroup
            // 
            lblWorkGroup.AutoSize = true;
            lblWorkGroup.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblWorkGroup.Location = new Point(96, 46);
            lblWorkGroup.Margin = new Padding(0);
            lblWorkGroup.Name = "lblWorkGroup";
            lblWorkGroup.Size = new Size(118, 21);
            lblWorkGroup.TabIndex = 58;
            lblWorkGroup.Tag = "lotData";
            lblWorkGroup.Text = "lblWorkGroup";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 46);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Size = new Size(75, 21);
            label2.TabIndex = 57;
            label2.Text = "Cuadrilla:";
            label2.TextAlign = ContentAlignment.TopRight;
            // 
            // lblContractor
            // 
            lblContractor.AutoSize = true;
            lblContractor.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblContractor.Location = new Point(96, 25);
            lblContractor.Margin = new Padding(0);
            lblContractor.Name = "lblContractor";
            lblContractor.Size = new Size(111, 21);
            lblContractor.TabIndex = 56;
            lblContractor.Tag = "lotData";
            lblContractor.Text = "lblContractor";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(7, 25);
            label3.Margin = new Padding(0);
            label3.Name = "label3";
            label3.Size = new Size(89, 21);
            label3.TabIndex = 55;
            label3.Text = "Contratista:";
            label3.TextAlign = ContentAlignment.TopRight;
            // 
            // btnExcel
            // 
            btnExcel.Font = new Font("Segoe UI", 12F);
            btnExcel.Image = Properties.Resources.excelIcon;
            btnExcel.ImageAlign = ContentAlignment.MiddleRight;
            btnExcel.Location = new Point(774, 242);
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
            lblTitle.Size = new Size(206, 21);
            lblTitle.TabIndex = 61;
            lblTitle.Tag = "lotData";
            lblTitle.Text = "Reporte cajas por número";
            // 
            // FrmPayrollBoxPerNumberReport
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
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmPayrollBoxPerNumberReport";
            Text = "Reporte cajas por número";
            Load += FrmPayrollBoxPerNumberReport_Load;
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
        private System.Windows.Forms.Label lblField;
        public System.Windows.Forms.ComboBox cboContractor;
        public System.Windows.Forms.ComboBox cboReportType;
        private System.Windows.Forms.Label labelReportType;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.ComboBox cboWorkGroup;
        private System.Windows.Forms.Button btnSearch;
        public System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.GroupBox bgpInfo;
        public System.Windows.Forms.Label lblWorkGroup;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label lblContractor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox cboSeason;
        private System.Windows.Forms.Button btnExcel;
        public System.Windows.Forms.Label lblTitle;
        public System.Windows.Forms.DateTimePicker dtpDate1;
        public System.Windows.Forms.DateTimePicker dtpDate2;
        private System.Windows.Forms.Label labelDateTo;
        private System.Windows.Forms.Label labelDate;
        public System.Windows.Forms.Label lblDateRange;
        private System.Windows.Forms.Label label6;
    }
}
