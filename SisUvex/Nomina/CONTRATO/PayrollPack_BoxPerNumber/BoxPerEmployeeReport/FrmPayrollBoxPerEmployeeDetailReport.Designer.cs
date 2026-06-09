namespace SisUvex.Nomina.CONTRATO.PayrollPack_BoxPerNumber.BoxPerEmployeeReport
{
    partial class FrmPayrollBoxPerEmployeeDetailReport
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
            lblTitle = new Label();
            bgpInfo = new GroupBox();
            btnExcel = new Button();
            gpbFilters = new GroupBox();
            btnLoadReport = new Button();
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
            dgvReport = new DataGridView();
            chbShowEmployees = new CheckBox();
            chbShowReport = new CheckBox();
            txbIdEmployee = new TextBox();
            label1 = new Label();
            btnSearchEmployee = new Button();
            btnAddEmployee = new Button();
            btnClearList = new Button();
            btnAddList = new Button();
            lblSobrantesInfo = new Label();
            lblEmployeeAdvice = new Label();
            bgpInfo.SuspendLayout();
            gpbFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReport).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.Location = new Point(9, 9);
            lblTitle.Margin = new Padding(0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(340, 21);
            lblTitle.TabIndex = 73;
            lblTitle.Tag = "lotData";
            lblTitle.Text = "Reporte cajas por cada empleado detallado";
            // 
            // bgpInfo
            // 
            bgpInfo.Controls.Add(lblSobrantesInfo);
            bgpInfo.Controls.Add(dtpDate1);
            bgpInfo.Controls.Add(btnExcel);
            bgpInfo.Controls.Add(labelDate);
            bgpInfo.Controls.Add(labelDateTo);
            bgpInfo.Controls.Add(dtpDate2);
            bgpInfo.Controls.Add(btnLoadReport);
            bgpInfo.Font = new Font("Segoe UI", 12F);
            bgpInfo.Location = new Point(12, 550);
            bgpInfo.Name = "bgpInfo";
            bgpInfo.Size = new Size(859, 78);
            bgpInfo.TabIndex = 76;
            bgpInfo.TabStop = false;
            bgpInfo.Text = "Reporte";
            // 
            // btnExcel
            // 
            btnExcel.Font = new Font("Segoe UI", 12F);
            btnExcel.Image = Properties.Resources.excelIcon;
            btnExcel.ImageAlign = ContentAlignment.MiddleRight;
            btnExcel.Location = new Point(753, 18);
            btnExcel.Name = "btnExcel";
            btnExcel.Padding = new Padding(0, 0, 4, 0);
            btnExcel.Size = new Size(97, 31);
            btnExcel.TabIndex = 71;
            btnExcel.Text = "Excel";
            btnExcel.TextAlign = ContentAlignment.TopLeft;
            btnExcel.UseVisualStyleBackColor = true;
            // 
            // gpbFilters
            // 
            gpbFilters.Controls.Add(lblEmployeeAdvice);
            gpbFilters.Controls.Add(btnAddList);
            gpbFilters.Controls.Add(btnAddEmployee);
            gpbFilters.Controls.Add(btnSearchEmployee);
            gpbFilters.Controls.Add(label1);
            gpbFilters.Controls.Add(txbIdEmployee);
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
            gpbFilters.TabIndex = 74;
            gpbFilters.TabStop = false;
            gpbFilters.Text = "Filtros";
            // 
            // btnLoadReport
            // 
            btnLoadReport.Font = new Font("Segoe UI", 12F);
            btnLoadReport.Image = Properties.Resources.BuscarLupa1;
            btnLoadReport.ImageAlign = ContentAlignment.MiddleRight;
            btnLoadReport.Location = new Point(395, 19);
            btnLoadReport.Name = "btnLoadReport";
            btnLoadReport.Padding = new Padding(0, 0, 4, 0);
            btnLoadReport.Size = new Size(142, 31);
            btnLoadReport.TabIndex = 68;
            btnLoadReport.Text = "Cargar reporte";
            btnLoadReport.TextAlign = ContentAlignment.TopLeft;
            btnLoadReport.UseVisualStyleBackColor = true;
            // 
            // dtpDate2
            // 
            dtpDate2.Format = DateTimePickerFormat.Short;
            dtpDate2.Location = new Point(269, 20);
            dtpDate2.Name = "dtpDate2";
            dtpDate2.Size = new Size(120, 29);
            dtpDate2.TabIndex = 53;
            // 
            // dtpDate1
            // 
            dtpDate1.Format = DateTimePickerFormat.Short;
            dtpDate1.Location = new Point(118, 20);
            dtpDate1.Name = "dtpDate1";
            dtpDate1.Size = new Size(120, 29);
            dtpDate1.TabIndex = 52;
            // 
            // labelDateTo
            // 
            labelDateTo.AutoSize = true;
            labelDateTo.Location = new Point(244, 25);
            labelDateTo.Margin = new Padding(0);
            labelDateTo.Name = "labelDateTo";
            labelDateTo.Size = new Size(22, 21);
            labelDateTo.TabIndex = 51;
            labelDateTo.Text = "al";
            // 
            // labelDate
            // 
            labelDate.AutoSize = true;
            labelDate.Location = new Point(12, 25);
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
            cboWorkGroup.Location = new Point(421, 26);
            cboWorkGroup.Margin = new Padding(0, 3, 3, 3);
            cboWorkGroup.Name = "cboWorkGroup";
            cboWorkGroup.Size = new Size(360, 29);
            cboWorkGroup.TabIndex = 45;
            // 
            // labelWorkGroup
            // 
            labelWorkGroup.AutoSize = true;
            labelWorkGroup.Location = new Point(349, 29);
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
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvReport.EnableHeadersVisualStyles = false;
            dgvReport.ImeMode = ImeMode.NoControl;
            dgvReport.Location = new Point(12, 247);
            dgvReport.Name = "dgvReport";
            dgvReport.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvReport.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvReport.RowHeadersVisible = false;
            dgvReport.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReport.Size = new Size(859, 297);
            dgvReport.TabIndex = 75;
            // 
            // chbShowEmployees
            // 
            chbShowEmployees.Appearance = Appearance.Button;
            chbShowEmployees.Font = new Font("Segoe UI", 12F);
            chbShowEmployees.Image = Properties.Resources.verIcon16;
            chbShowEmployees.ImageAlign = ContentAlignment.MiddleLeft;
            chbShowEmployees.Location = new Point(114, 206);
            chbShowEmployees.Name = "chbShowEmployees";
            chbShowEmployees.Padding = new Padding(4, 0, 0, 0);
            chbShowEmployees.Size = new Size(91, 31);
            chbShowEmployees.TabIndex = 77;
            chbShowEmployees.Text = "Listado";
            chbShowEmployees.TextAlign = ContentAlignment.MiddleRight;
            chbShowEmployees.UseVisualStyleBackColor = true;
            // 
            // chbShowReport
            // 
            chbShowReport.Appearance = Appearance.Button;
            chbShowReport.Font = new Font("Segoe UI", 12F);
            chbShowReport.Image = Properties.Resources.verIcon16;
            chbShowReport.ImageAlign = ContentAlignment.MiddleLeft;
            chbShowReport.Location = new Point(211, 206);
            chbShowReport.Name = "chbShowReport";
            chbShowReport.Padding = new Padding(4, 0, 0, 0);
            chbShowReport.Size = new Size(95, 31);
            chbShowReport.TabIndex = 78;
            chbShowReport.Text = "Reporte";
            chbShowReport.TextAlign = ContentAlignment.MiddleRight;
            chbShowReport.UseVisualStyleBackColor = true;
            // 
            // txbIdEmployee
            // 
            txbIdEmployee.Font = new Font("Segoe UI", 12F);
            txbIdEmployee.Location = new Point(181, 127);
            txbIdEmployee.Name = "txbIdEmployee";
            txbIdEmployee.Size = new Size(79, 29);
            txbIdEmployee.TabIndex = 79;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 131);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(133, 21);
            label1.TabIndex = 80;
            label1.Text = "Código empleado";
            // 
            // btnSearchEmployee
            // 
            btnSearchEmployee.Font = new Font("Segoe UI", 12F);
            btnSearchEmployee.Image = Properties.Resources.BuscarLupa1;
            btnSearchEmployee.ImageAlign = ContentAlignment.MiddleRight;
            btnSearchEmployee.Location = new Point(147, 126);
            btnSearchEmployee.Name = "btnSearchEmployee";
            btnSearchEmployee.Padding = new Padding(0, 0, 4, 0);
            btnSearchEmployee.Size = new Size(33, 31);
            btnSearchEmployee.TabIndex = 81;
            btnSearchEmployee.TextAlign = ContentAlignment.TopLeft;
            btnSearchEmployee.UseVisualStyleBackColor = true;
            // 
            // btnAddEmployee
            // 
            btnAddEmployee.Font = new Font("Segoe UI", 12F);
            btnAddEmployee.Image = Properties.Resources.mas_16;
            btnAddEmployee.ImageAlign = ContentAlignment.MiddleLeft;
            btnAddEmployee.Location = new Point(261, 126);
            btnAddEmployee.Name = "btnAddEmployee";
            btnAddEmployee.Padding = new Padding(5, 0, 0, 0);
            btnAddEmployee.Size = new Size(168, 31);
            btnAddEmployee.TabIndex = 82;
            btnAddEmployee.Text = "Agregar empleado";
            btnAddEmployee.TextAlign = ContentAlignment.MiddleRight;
            btnAddEmployee.UseVisualStyleBackColor = true;
            // 
            // btnClearList
            // 
            btnClearList.Font = new Font("Segoe UI", 12F);
            btnClearList.Image = Properties.Resources.limpiarIcon16;
            btnClearList.ImageAlign = ContentAlignment.MiddleLeft;
            btnClearList.Location = new Point(12, 206);
            btnClearList.Name = "btnClearList";
            btnClearList.Padding = new Padding(5, 0, 0, 0);
            btnClearList.Size = new Size(96, 31);
            btnClearList.TabIndex = 83;
            btnClearList.Text = "Limpiar";
            btnClearList.TextAlign = ContentAlignment.MiddleRight;
            btnClearList.UseVisualStyleBackColor = true;
            // 
            // btnAddList
            // 
            btnAddList.Font = new Font("Segoe UI", 12F);
            btnAddList.Image = Properties.Resources.mas_16;
            btnAddList.ImageAlign = ContentAlignment.MiddleLeft;
            btnAddList.Location = new Point(421, 56);
            btnAddList.Name = "btnAddList";
            btnAddList.Padding = new Padding(5, 0, 0, 0);
            btnAddList.Size = new Size(147, 31);
            btnAddList.TabIndex = 83;
            btnAddList.Text = "Agregar listado";
            btnAddList.TextAlign = ContentAlignment.MiddleRight;
            btnAddList.UseVisualStyleBackColor = true;
            // 
            // lblSobrantesInfo
            // 
            lblSobrantesInfo.AutoSize = true;
            lblSobrantesInfo.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblSobrantesInfo.ForeColor = Color.Gray;
            lblSobrantesInfo.Location = new Point(17, 52);
            lblSobrantesInfo.Name = "lblSobrantesInfo";
            lblSobrantesInfo.Size = new Size(545, 15);
            lblSobrantesInfo.TabIndex = 72;
            lblSobrantesInfo.Text = "ℹ Si no hay empleados en el listado se generará de todos los empleados en la temporada seleccionada";
            // 
            // lblEmployeeAdvice
            // 
            lblEmployeeAdvice.AutoSize = true;
            lblEmployeeAdvice.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblEmployeeAdvice.ForeColor = Color.Gray;
            lblEmployeeAdvice.Location = new Point(435, 136);
            lblEmployeeAdvice.Name = "lblEmployeeAdvice";
            lblEmployeeAdvice.Size = new Size(105, 15);
            lblEmployeeAdvice.TabIndex = 84;
            lblEmployeeAdvice.Text = "lblEmployeeAdvice";
            // 
            // FrmPayrollBoxPerEmployeeDetailReport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1667, 906);
            Controls.Add(btnClearList);
            Controls.Add(chbShowReport);
            Controls.Add(chbShowEmployees);
            Controls.Add(bgpInfo);
            Controls.Add(gpbFilters);
            Controls.Add(dgvReport);
            Controls.Add(lblTitle);
            Name = "FrmPayrollBoxPerEmployeeDetailReport";
            Text = "FrmPayrollBoxPerEmployeeDetailReport";
            bgpInfo.ResumeLayout(false);
            bgpInfo.PerformLayout();
            gpbFilters.ResumeLayout(false);
            gpbFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReport).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Label lblTitle;
        private GroupBox bgpInfo;
        private Button btnExcel;
        private GroupBox gpbFilters;
        private Button btnLoadReport;
        public DateTimePicker dtpDate2;
        public DateTimePicker dtpDate1;
        private Label labelDateTo;
        private Label labelDate;
        public ComboBox cboSeason;
        public ComboBox cboWorkGroup;
        private Label labelWorkGroup;
        private Label labelSeason;
        private Label labelContractor;
        public ComboBox cboContractor;
        public DataGridView dgvReport;
        private CheckBox chbShowEmployees;
        private Label label1;
        private TextBox txbIdEmployee;
        private CheckBox chbShowReport;
        private Button btnAddEmployee;
        private Button btnSearchEmployee;
        private Button btnClearList;
        private Button btnAddList;
        private Label lblSobrantesInfo;
        private Label lblEmployeeAdvice;
    }
}