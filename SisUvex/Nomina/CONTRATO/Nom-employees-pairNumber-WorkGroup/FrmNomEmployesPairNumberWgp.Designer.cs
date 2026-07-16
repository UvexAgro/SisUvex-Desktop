namespace SisUvex.Nomina.CONTRATO.Nom_employees_pairNumber_WorkGroup
{
    partial class FrmNomEmployesPairNumberWgp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNomEmployesPairNumberWgp));
            lblTitle = new Label();
            btnExcel = new Button();
            btnSearch = new Button();
            bgpInfo = new GroupBox();
            lblSeason = new Label();
            label8 = new Label();
            lblUser = new Label();
            label6 = new Label();
            lblWorkGroup = new Label();
            label2 = new Label();
            lblContractor = new Label();
            label3 = new Label();
            dgvReport = new DataGridView();
            gpbFilters = new GroupBox();
            cboUser = new ComboBox();
            cboSeason = new ComboBox();
            label4 = new Label();
            lblField = new Label();
            cboContractor = new ComboBox();
            cboWorkGroup = new ComboBox();
            label1 = new Label();
            label10 = new Label();
            bgpInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReport).BeginInit();
            gpbFilters.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(391, 21);
            lblTitle.TabIndex = 11;
            lblTitle.Text = "Empleados por número / pareja (POR ANOTADOR)";
            // 
            // btnExcel
            // 
            btnExcel.Font = new Font("Segoe UI", 12F);
            btnExcel.Image = Properties.Resources.excelIcon;
            btnExcel.ImageAlign = ContentAlignment.MiddleRight;
            btnExcel.Location = new Point(775, 188);
            btnExcel.Name = "btnExcel";
            btnExcel.Padding = new Padding(0, 0, 4, 0);
            btnExcel.Size = new Size(97, 31);
            btnExcel.TabIndex = 10;
            btnExcel.Text = "Excel";
            btnExcel.TextAlign = ContentAlignment.TopLeft;
            btnExcel.UseVisualStyleBackColor = true;
            btnExcel.Click += btnExcel_Click;
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Segoe UI", 12F);
            btnSearch.Image = Properties.Resources.BuscarLupa1;
            btnSearch.ImageAlign = ContentAlignment.MiddleRight;
            btnSearch.Location = new Point(774, 151);
            btnSearch.Name = "btnSearch";
            btnSearch.Padding = new Padding(0, 0, 4, 0);
            btnSearch.Size = new Size(87, 31);
            btnSearch.TabIndex = 7;
            btnSearch.Text = "Buscar";
            btnSearch.TextAlign = ContentAlignment.TopLeft;
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // bgpInfo
            // 
            bgpInfo.Controls.Add(lblSeason);
            bgpInfo.Controls.Add(label8);
            bgpInfo.Controls.Add(lblUser);
            bgpInfo.Controls.Add(label6);
            bgpInfo.Controls.Add(lblWorkGroup);
            bgpInfo.Controls.Add(label2);
            bgpInfo.Controls.Add(lblContractor);
            bgpInfo.Controls.Add(label3);
            bgpInfo.Font = new Font("Segoe UI", 12F);
            bgpInfo.Location = new Point(12, 141);
            bgpInfo.Name = "bgpInfo";
            bgpInfo.Size = new Size(756, 78);
            bgpInfo.TabIndex = 8;
            bgpInfo.TabStop = false;
            bgpInfo.Text = "Detalles";
            // 
            // lblSeason
            // 
            lblSeason.AutoSize = true;
            lblSeason.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblSeason.Location = new Point(95, 25);
            lblSeason.Name = "lblSeason";
            lblSeason.Size = new Size(84, 21);
            lblSeason.TabIndex = 7;
            lblSeason.Text = "lblSeason";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 25);
            label8.Name = "label8";
            label8.Size = new Size(90, 21);
            label8.TabIndex = 6;
            label8.Text = "Temporada:";
            label8.TextAlign = ContentAlignment.TopRight;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblUser.Location = new Point(468, 46);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(64, 21);
            lblUser.TabIndex = 5;
            lblUser.Text = "lblUser";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(393, 46);
            label6.Name = "label6";
            label6.Size = new Size(78, 21);
            label6.TabIndex = 4;
            label6.Text = "Anotador:";
            label6.TextAlign = ContentAlignment.TopRight;
            // 
            // lblWorkGroup
            // 
            lblWorkGroup.AutoSize = true;
            lblWorkGroup.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblWorkGroup.Location = new Point(468, 25);
            lblWorkGroup.Name = "lblWorkGroup";
            lblWorkGroup.Size = new Size(118, 21);
            lblWorkGroup.TabIndex = 1;
            lblWorkGroup.Text = "lblWorkGroup";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(393, 25);
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
            lblContractor.Location = new Point(95, 46);
            lblContractor.Name = "lblContractor";
            lblContractor.Size = new Size(111, 21);
            lblContractor.TabIndex = 3;
            lblContractor.Text = "lblContractor";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 46);
            label3.Name = "label3";
            label3.Size = new Size(89, 21);
            label3.TabIndex = 2;
            label3.Text = "Contratista:";
            label3.TextAlign = ContentAlignment.TopRight;
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
            dgvReport.Location = new Point(12, 225);
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
            dgvReport.Size = new Size(859, 208);
            dgvReport.TabIndex = 9;
            // 
            // gpbFilters
            // 
            gpbFilters.Controls.Add(cboUser);
            gpbFilters.Controls.Add(cboSeason);
            gpbFilters.Controls.Add(label4);
            gpbFilters.Controls.Add(lblField);
            gpbFilters.Controls.Add(cboContractor);
            gpbFilters.Controls.Add(cboWorkGroup);
            gpbFilters.Controls.Add(label1);
            gpbFilters.Controls.Add(label10);
            gpbFilters.Font = new Font("Segoe UI", 12F);
            gpbFilters.Location = new Point(12, 33);
            gpbFilters.Name = "gpbFilters";
            gpbFilters.Size = new Size(756, 102);
            gpbFilters.TabIndex = 6;
            gpbFilters.TabStop = false;
            gpbFilters.Text = "Filtros";
            // 
            // cboUser
            // 
            cboUser.DropDownStyle = ComboBoxStyle.DropDownList;
            cboUser.FormattingEnabled = true;
            cboUser.Location = new Point(468, 58);
            cboUser.Margin = new Padding(0, 3, 3, 3);
            cboUser.Name = "cboUser";
            cboUser.Size = new Size(282, 29);
            cboUser.TabIndex = 5;
            // 
            // cboSeason
            // 
            cboSeason.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSeason.FormattingEnabled = true;
            cboSeason.Location = new Point(119, 23);
            cboSeason.Margin = new Padding(0, 3, 3, 3);
            cboSeason.Name = "cboSeason";
            cboSeason.Size = new Size(266, 29);
            cboSeason.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(32, 26);
            label4.Name = "label4";
            label4.Size = new Size(87, 21);
            label4.TabIndex = 1;
            label4.Text = "Temporada";
            // 
            // lblField
            // 
            lblField.AutoSize = true;
            lblField.Location = new Point(33, 61);
            lblField.Name = "lblField";
            lblField.Size = new Size(86, 21);
            lblField.TabIndex = 2;
            lblField.Text = "Contratista";
            // 
            // cboContractor
            // 
            cboContractor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboContractor.FormattingEnabled = true;
            cboContractor.Location = new Point(119, 58);
            cboContractor.Margin = new Padding(0, 3, 3, 3);
            cboContractor.Name = "cboContractor";
            cboContractor.Size = new Size(266, 29);
            cboContractor.TabIndex = 1;
            // 
            // cboWorkGroup
            // 
            cboWorkGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            cboWorkGroup.FormattingEnabled = true;
            cboWorkGroup.Location = new Point(468, 23);
            cboWorkGroup.Margin = new Padding(0, 3, 3, 3);
            cboWorkGroup.Name = "cboWorkGroup";
            cboWorkGroup.Size = new Size(282, 29);
            cboWorkGroup.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(394, 61);
            label1.Name = "label1";
            label1.Size = new Size(75, 21);
            label1.TabIndex = 6;
            label1.Text = "Anotador";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(397, 26);
            label10.Name = "label10";
            label10.Size = new Size(72, 21);
            label10.TabIndex = 4;
            label10.Text = "Cuadrilla";
            // 
            // FrmNomEmployesPairNumberWgp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 445);
            Controls.Add(lblTitle);
            Controls.Add(btnExcel);
            Controls.Add(btnSearch);
            Controls.Add(bgpInfo);
            Controls.Add(dgvReport);
            Controls.Add(gpbFilters);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmNomEmployesPairNumberWgp";
            Text = "Empleados por número / pareja";
            Load += FrmNomEmployesPairNumberWgp_Load;
            bgpInfo.ResumeLayout(false);
            bgpInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReport).EndInit();
            gpbFilters.ResumeLayout(false);
            gpbFilters.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Label lblTitle;
        private Button btnExcel;
        private Button btnSearch;
        private GroupBox bgpInfo;
        public Label lblWorkGroup;
        private Label label2;
        public Label lblContractor;
        private Label label3;
        public DataGridView dgvReport;
        private GroupBox gpbFilters;
        public ComboBox cboSeason;
        private Label label4;
        private Label lblField;
        public ComboBox cboContractor;
        private Label label10;
        public ComboBox cboWorkGroup;
        private Label label1;
        public ComboBox cboUser;
        public Label lblSeason;
        private Label label8;
        public Label lblUser;
        private Label label6;
    }
}