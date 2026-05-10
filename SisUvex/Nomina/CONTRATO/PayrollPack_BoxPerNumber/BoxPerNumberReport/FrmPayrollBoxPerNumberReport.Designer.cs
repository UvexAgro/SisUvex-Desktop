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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPayrollBoxPerNumberReport));
            gpbFilters = new System.Windows.Forms.GroupBox();
            dtpDate2 = new System.Windows.Forms.DateTimePicker();
            dtpDate1 = new System.Windows.Forms.DateTimePicker();
            labelDateTo = new System.Windows.Forms.Label();
            labelDate = new System.Windows.Forms.Label();
            cboSeason = new System.Windows.Forms.ComboBox();
            label4 = new System.Windows.Forms.Label();
            lblField = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            cboPeriod = new System.Windows.Forms.ComboBox();
            cboContractor = new System.Windows.Forms.ComboBox();
            label10 = new System.Windows.Forms.Label();
            cboPaymentPlace = new System.Windows.Forms.ComboBox();
            cboWorkGroup = new System.Windows.Forms.ComboBox();
            label11 = new System.Windows.Forms.Label();
            btnSearch = new System.Windows.Forms.Button();
            dgvReport = new System.Windows.Forms.DataGridView();
            bgpInfo = new System.Windows.Forms.GroupBox();
            lblDateRange = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            lblPaymentPlace = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            lblWorkGroup = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            lblContractor = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            lblPeriod = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            btnExcel = new System.Windows.Forms.Button();
            lblTitle = new System.Windows.Forms.Label();
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
            gpbFilters.Controls.Add(label4);
            gpbFilters.Controls.Add(lblField);
            gpbFilters.Controls.Add(label1);
            gpbFilters.Controls.Add(cboPeriod);
            gpbFilters.Controls.Add(cboContractor);
            gpbFilters.Controls.Add(label10);
            gpbFilters.Controls.Add(cboPaymentPlace);
            gpbFilters.Controls.Add(cboWorkGroup);
            gpbFilters.Controls.Add(label11);
            gpbFilters.Font = new System.Drawing.Font("Segoe UI", 12F);
            gpbFilters.Location = new System.Drawing.Point(12, 33);
            gpbFilters.Name = "gpbFilters";
            gpbFilters.Size = new System.Drawing.Size(859, 160);
            gpbFilters.TabIndex = 51;
            gpbFilters.TabStop = false;
            gpbFilters.Text = "Filtros";
            // 
            // dtpDate2
            // 
            dtpDate2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpDate2.Location = new System.Drawing.Point(297, 117);
            dtpDate2.Name = "dtpDate2";
            dtpDate2.Size = new System.Drawing.Size(120, 29);
            dtpDate2.TabIndex = 53;
            // 
            // dtpDate1
            // 
            dtpDate1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpDate1.Location = new System.Drawing.Point(123, 117);
            dtpDate1.Name = "dtpDate1";
            dtpDate1.Size = new System.Drawing.Size(120, 29);
            dtpDate1.TabIndex = 52;
            // 
            // labelDateTo
            // 
            labelDateTo.AutoSize = true;
            labelDateTo.Location = new System.Drawing.Point(249, 122);
            labelDateTo.Margin = new System.Windows.Forms.Padding(0);
            labelDateTo.Name = "labelDateTo";
            labelDateTo.Size = new System.Drawing.Size(22, 21);
            labelDateTo.TabIndex = 51;
            labelDateTo.Text = "al";
            // 
            // labelDate
            // 
            labelDate.AutoSize = true;
            labelDate.Location = new System.Drawing.Point(13, 122);
            labelDate.Margin = new System.Windows.Forms.Padding(0);
            labelDate.Name = "labelDate";
            labelDate.Size = new System.Drawing.Size(106, 21);
            labelDate.TabIndex = 50;
            labelDate.Text = "Rango fechas";
            // 
            // cboSeason
            // 
            cboSeason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboSeason.FormattingEnabled = true;
            cboSeason.Location = new System.Drawing.Point(659, 20);
            cboSeason.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            cboSeason.Name = "cboSeason";
            cboSeason.Size = new System.Drawing.Size(190, 29);
            cboSeason.TabIndex = 49;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(573, 23);
            label4.Margin = new System.Windows.Forms.Padding(0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(87, 21);
            label4.TabIndex = 48;
            label4.Text = "Temporada";
            // 
            // lblField
            // 
            lblField.AutoSize = true;
            lblField.Location = new System.Drawing.Point(573, 57);
            lblField.Margin = new System.Windows.Forms.Padding(0);
            lblField.Name = "lblField";
            lblField.Size = new System.Drawing.Size(86, 21);
            lblField.TabIndex = 22;
            lblField.Text = "Contratista";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(13, 59);
            label1.Margin = new System.Windows.Forms.Padding(0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(110, 21);
            label1.TabIndex = 26;
            label1.Text = "Lugar de pago";
            // 
            // cboPeriod
            // 
            cboPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboPeriod.FormattingEnabled = true;
            cboPeriod.Location = new System.Drawing.Point(123, 23);
            cboPeriod.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            cboPeriod.Name = "cboPeriod";
            cboPeriod.Size = new System.Drawing.Size(331, 29);
            cboPeriod.TabIndex = 47;
            cboPeriod.SelectedIndexChanged += cboPeriod_SelectedIndexChanged;
            // 
            // cboContractor
            // 
            cboContractor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboContractor.FormattingEnabled = true;
            cboContractor.Location = new System.Drawing.Point(659, 52);
            cboContractor.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            cboContractor.Name = "cboContractor";
            cboContractor.Size = new System.Drawing.Size(190, 29);
            cboContractor.TabIndex = 24;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(494, 88);
            label10.Margin = new System.Windows.Forms.Padding(0);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(72, 21);
            label10.TabIndex = 44;
            label10.Text = "Cuadrilla";
            // 
            // cboPaymentPlace
            // 
            cboPaymentPlace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboPaymentPlace.FlatStyle = System.Windows.Forms.FlatStyle.System;
            cboPaymentPlace.FormattingEnabled = true;
            cboPaymentPlace.Location = new System.Drawing.Point(123, 56);
            cboPaymentPlace.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            cboPaymentPlace.Name = "cboPaymentPlace";
            cboPaymentPlace.Size = new System.Drawing.Size(360, 29);
            cboPaymentPlace.TabIndex = 27;
            // 
            // cboWorkGroup
            // 
            cboWorkGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboWorkGroup.FormattingEnabled = true;
            cboWorkGroup.Location = new System.Drawing.Point(566, 85);
            cboWorkGroup.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            cboWorkGroup.Name = "cboWorkGroup";
            cboWorkGroup.Size = new System.Drawing.Size(283, 29);
            cboWorkGroup.TabIndex = 45;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(57, 28);
            label11.Margin = new System.Windows.Forms.Padding(0);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(66, 21);
            label11.TabIndex = 46;
            label11.Text = "Semana";
            // 
            // btnSearch
            // 
            btnSearch.Font = new System.Drawing.Font("Segoe UI", 12F);
            btnSearch.Image = Properties.Resources.BuscarLupa1;
            btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnSearch.Location = new System.Drawing.Point(774, 203);
            btnSearch.Name = "btnSearch";
            btnSearch.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            btnSearch.Size = new System.Drawing.Size(87, 31);
            btnSearch.TabIndex = 68;
            btnSearch.Text = "Buscar";
            btnSearch.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // dgvReport
            // 
            dgvReport.AllowUserToAddRows = false;
            dgvReport.AllowUserToDeleteRows = false;
            dgvReport.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dgvReport.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dgvReport.BackgroundColor = System.Drawing.SystemColors.Control;
            dgvReport.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dgvReport.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgvReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvReport.EnableHeadersVisualStyles = false;
            dgvReport.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            dgvReport.Location = new System.Drawing.Point(12, 334);
            dgvReport.Name = "dgvReport";
            dgvReport.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgvReport.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvReport.RowHeadersVisible = false;
            dgvReport.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvReport.Size = new System.Drawing.Size(859, 321);
            dgvReport.TabIndex = 69;
            // 
            // bgpInfo
            // 
            bgpInfo.Controls.Add(lblDateRange);
            bgpInfo.Controls.Add(label6);
            bgpInfo.Controls.Add(lblPaymentPlace);
            bgpInfo.Controls.Add(label5);
            bgpInfo.Controls.Add(lblWorkGroup);
            bgpInfo.Controls.Add(label2);
            bgpInfo.Controls.Add(lblContractor);
            bgpInfo.Controls.Add(label3);
            bgpInfo.Controls.Add(lblPeriod);
            bgpInfo.Controls.Add(label7);
            bgpInfo.Font = new System.Drawing.Font("Segoe UI", 12F);
            bgpInfo.Location = new System.Drawing.Point(12, 193);
            bgpInfo.Name = "bgpInfo";
            bgpInfo.Size = new System.Drawing.Size(756, 130);
            bgpInfo.TabIndex = 70;
            bgpInfo.TabStop = false;
            bgpInfo.Text = "Detalles";
            // 
            // lblDateRange
            // 
            lblDateRange.AutoSize = true;
            lblDateRange.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblDateRange.Location = new System.Drawing.Point(120, 88);
            lblDateRange.Margin = new System.Windows.Forms.Padding(0);
            lblDateRange.Name = "lblDateRange";
            lblDateRange.Size = new System.Drawing.Size(113, 21);
            lblDateRange.TabIndex = 62;
            lblDateRange.Tag = "lotData";
            lblDateRange.Text = "lblDateRange";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(34, 88);
            label6.Margin = new System.Windows.Forms.Padding(0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(86, 21);
            label6.TabIndex = 61;
            label6.Text = "Fechas:";
            label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblPaymentPlace
            // 
            lblPaymentPlace.AutoSize = true;
            lblPaymentPlace.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblPaymentPlace.Location = new System.Drawing.Point(134, 67);
            lblPaymentPlace.Margin = new System.Windows.Forms.Padding(0);
            lblPaymentPlace.Name = "lblPaymentPlace";
            lblPaymentPlace.Size = new System.Drawing.Size(139, 21);
            lblPaymentPlace.TabIndex = 60;
            lblPaymentPlace.Tag = "lotData";
            lblPaymentPlace.Text = "lblPaymentPlace";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(21, 67);
            label5.Margin = new System.Windows.Forms.Padding(0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(113, 21);
            label5.TabIndex = 59;
            label5.Text = "Lugar de pago:";
            label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblWorkGroup
            // 
            lblWorkGroup.AutoSize = true;
            lblWorkGroup.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblWorkGroup.Location = new System.Drawing.Point(96, 46);
            lblWorkGroup.Margin = new System.Windows.Forms.Padding(0);
            lblWorkGroup.Name = "lblWorkGroup";
            lblWorkGroup.Size = new System.Drawing.Size(118, 21);
            lblWorkGroup.TabIndex = 58;
            lblWorkGroup.Tag = "lotData";
            lblWorkGroup.Text = "lblWorkGroup";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(21, 46);
            label2.Margin = new System.Windows.Forms.Padding(0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(75, 21);
            label2.TabIndex = 57;
            label2.Text = "Cuadrilla:";
            label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblContractor
            // 
            lblContractor.AutoSize = true;
            lblContractor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblContractor.Location = new System.Drawing.Point(96, 25);
            lblContractor.Margin = new System.Windows.Forms.Padding(0);
            lblContractor.Name = "lblContractor";
            lblContractor.Size = new System.Drawing.Size(111, 21);
            lblContractor.TabIndex = 56;
            lblContractor.Tag = "lotData";
            lblContractor.Text = "lblContractor";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(7, 25);
            label3.Margin = new System.Windows.Forms.Padding(0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(89, 21);
            label3.TabIndex = 55;
            label3.Text = "Contratista:";
            label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblPeriod
            // 
            lblPeriod.AutoSize = true;
            lblPeriod.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblPeriod.Location = new System.Drawing.Point(96, 109);
            lblPeriod.Margin = new System.Windows.Forms.Padding(0);
            lblPeriod.Name = "lblPeriod";
            lblPeriod.Size = new System.Drawing.Size(80, 21);
            lblPeriod.TabIndex = 54;
            lblPeriod.Tag = "lotData";
            lblPeriod.Text = "lblPeriod";
            lblPeriod.Visible = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(27, 109);
            label7.Margin = new System.Windows.Forms.Padding(0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(69, 21);
            label7.TabIndex = 52;
            label7.Text = "Semana:";
            label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            label7.Visible = false;
            // 
            // btnExcel
            // 
            btnExcel.Font = new System.Drawing.Font("Segoe UI", 12F);
            btnExcel.Image = Properties.Resources.excelIcon;
            btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnExcel.Location = new System.Drawing.Point(774, 292);
            btnExcel.Name = "btnExcel";
            btnExcel.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            btnExcel.Size = new System.Drawing.Size(97, 31);
            btnExcel.TabIndex = 71;
            btnExcel.Text = "Excel";
            btnExcel.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            btnExcel.UseVisualStyleBackColor = true;
            btnExcel.Click += btnExcel_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblTitle.Location = new System.Drawing.Point(12, 9);
            lblTitle.Margin = new System.Windows.Forms.Padding(0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(247, 21);
            lblTitle.TabIndex = 61;
            lblTitle.Tag = "lotData";
            lblTitle.Text = "Reporte cajas por número";
            // 
            // FrmPayrollBoxPerNumberReport
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoScroll = true;
            AutoScrollMargin = new System.Drawing.Size(10, 10);
            AutoScrollMinSize = new System.Drawing.Size(0, 650);
            ClientSize = new System.Drawing.Size(883, 667);
            Controls.Add(lblTitle);
            Controls.Add(btnExcel);
            Controls.Add(btnSearch);
            Controls.Add(bgpInfo);
            Controls.Add(dgvReport);
            Controls.Add(gpbFilters);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
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
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cboPeriod;
        public System.Windows.Forms.ComboBox cboContractor;
        public System.Windows.Forms.ComboBox cboPaymentPlace;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.ComboBox cboWorkGroup;
        private System.Windows.Forms.Button btnSearch;
        public System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.GroupBox bgpInfo;
        public System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label lblPaymentPlace;
        private System.Windows.Forms.Label label5;
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