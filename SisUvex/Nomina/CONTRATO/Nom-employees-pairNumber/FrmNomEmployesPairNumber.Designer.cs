namespace SisUvex.Nomina.CONTRATO.Nom_employees_pairNumber
{
    partial class FrmNomEmployesPairNumber
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNomEmployesPairNumber));
            gpbFilters = new GroupBox();
            cboSeason = new ComboBox();
            label4 = new Label();
            lblField = new Label();
            cboContractor = new ComboBox();
            label10 = new Label();
            cboWorkGroup = new ComboBox();
            btnSearch = new Button();
            dgvReport = new DataGridView();
            bgpInfo = new GroupBox();
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
            gpbFilters.Controls.Add(cboSeason);
            gpbFilters.Controls.Add(label4);
            gpbFilters.Controls.Add(lblField);
            gpbFilters.Controls.Add(cboContractor);
            gpbFilters.Controls.Add(label10);
            gpbFilters.Controls.Add(cboWorkGroup);
            gpbFilters.Font = new Font("Segoe UI", 12F);
            gpbFilters.Location = new Point(12, 33);
            gpbFilters.Name = "gpbFilters";
            gpbFilters.Size = new Size(756, 135);
            gpbFilters.TabIndex = 0;
            gpbFilters.TabStop = false;
            gpbFilters.Text = "Filtros";
            // 
            // cboSeason
            // 
            cboSeason.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSeason.FormattingEnabled = true;
            cboSeason.Location = new Point(123, 23);
            cboSeason.Margin = new Padding(0, 3, 3, 3);
            cboSeason.Name = "cboSeason";
            cboSeason.Size = new Size(266, 29);
            cboSeason.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(30, 26);
            label4.Name = "label4";
            label4.Size = new Size(87, 21);
            label4.TabIndex = 1;
            label4.Text = "Temporada";
            // 
            // lblField
            // 
            lblField.AutoSize = true;
            lblField.Location = new Point(34, 61);
            lblField.Name = "lblField";
            lblField.Size = new Size(86, 21);
            lblField.TabIndex = 2;
            lblField.Text = "Contratista";
            // 
            // cboContractor
            // 
            cboContractor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboContractor.FormattingEnabled = true;
            cboContractor.Location = new Point(123, 58);
            cboContractor.Margin = new Padding(0, 3, 3, 3);
            cboContractor.Name = "cboContractor";
            cboContractor.Size = new Size(266, 29);
            cboContractor.TabIndex = 1;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(45, 96);
            label10.Name = "label10";
            label10.Size = new Size(72, 21);
            label10.TabIndex = 4;
            label10.Text = "Cuadrilla";
            // 
            // cboWorkGroup
            // 
            cboWorkGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            cboWorkGroup.FormattingEnabled = true;
            cboWorkGroup.Location = new Point(123, 93);
            cboWorkGroup.Margin = new Padding(0, 3, 3, 3);
            cboWorkGroup.Name = "cboWorkGroup";
            cboWorkGroup.Size = new Size(447, 29);
            cboWorkGroup.TabIndex = 2;
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Segoe UI", 12F);
            btnSearch.Image = Properties.Resources.BuscarLupa1;
            btnSearch.ImageAlign = ContentAlignment.MiddleRight;
            btnSearch.Location = new Point(774, 184);
            btnSearch.Name = "btnSearch";
            btnSearch.Padding = new Padding(0, 0, 4, 0);
            btnSearch.Size = new Size(87, 31);
            btnSearch.TabIndex = 1;
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
            dgvReport.Location = new Point(12, 270);
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
            dgvReport.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvReport.Size = new Size(859, 385);
            dgvReport.TabIndex = 3;
            // 
            // bgpInfo
            // 
            bgpInfo.Controls.Add(lblWorkGroup);
            bgpInfo.Controls.Add(label2);
            bgpInfo.Controls.Add(lblContractor);
            bgpInfo.Controls.Add(label3);
            bgpInfo.Font = new Font("Segoe UI", 12F);
            bgpInfo.Location = new Point(12, 174);
            bgpInfo.Name = "bgpInfo";
            bgpInfo.Size = new Size(756, 90);
            bgpInfo.TabIndex = 2;
            bgpInfo.TabStop = false;
            bgpInfo.Text = "Detalles";
            // 
            // lblWorkGroup
            // 
            lblWorkGroup.AutoSize = true;
            lblWorkGroup.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblWorkGroup.Location = new Point(96, 46);
            lblWorkGroup.Name = "lblWorkGroup";
            lblWorkGroup.Size = new Size(118, 21);
            lblWorkGroup.TabIndex = 1;
            lblWorkGroup.Text = "lblWorkGroup";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 46);
            label2.Name = "label2";
            label2.Size = new Size(75, 21);
            label2.TabIndex = 0;
            label2.Text = "Cuadrilla:";
            label2.TextAlign = ContentAlignment.TopRight;
            // 
            // lblContractor
            // 
            lblContractor.AutoSize = true;
            lblContractor.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblContractor.Location = new Point(96, 25);
            lblContractor.Name = "lblContractor";
            lblContractor.Size = new Size(111, 21);
            lblContractor.TabIndex = 3;
            lblContractor.Text = "lblContractor";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(7, 25);
            label3.Name = "label3";
            label3.Size = new Size(89, 21);
            label3.TabIndex = 2;
            label3.Text = "Contratista:";
            label3.TextAlign = ContentAlignment.TopRight;
            // 
            // btnExcel
            // 
            btnExcel.Font = new Font("Segoe UI", 12F);
            btnExcel.Image = Properties.Resources.excelIcon;
            btnExcel.ImageAlign = ContentAlignment.MiddleRight;
            btnExcel.Location = new Point(774, 233);
            btnExcel.Name = "btnExcel";
            btnExcel.Padding = new Padding(0, 0, 4, 0);
            btnExcel.Size = new Size(97, 31);
            btnExcel.TabIndex = 4;
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
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(251, 21);
            lblTitle.TabIndex = 5;
            lblTitle.Text = "Empleados por número / pareja";
            // 
            // FrmNomEmployesPairNumber
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(883, 667);
            Controls.Add(lblTitle);
            Controls.Add(btnExcel);
            Controls.Add(btnSearch);
            Controls.Add(bgpInfo);
            Controls.Add(dgvReport);
            Controls.Add(gpbFilters);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmNomEmployesPairNumber";
            Text = "Empleados por número / pareja";
            Load += FrmNomEmployesPairNumber_Load;
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblField;
        public System.Windows.Forms.ComboBox cboSeason;
        public System.Windows.Forms.ComboBox cboContractor;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.ComboBox cboWorkGroup;
        private System.Windows.Forms.Button btnSearch;
        public System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.GroupBox bgpInfo;
        public System.Windows.Forms.Label lblWorkGroup;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label lblContractor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnExcel;
        public System.Windows.Forms.Label lblTitle;
    }
}
