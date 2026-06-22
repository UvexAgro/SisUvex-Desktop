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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPayrollBoxPerEmployeeReport));
            gpbFilters = new GroupBox();
            btnAddList = new Button();
            cboUser = new ComboBox();
            labelUser = new Label();
            cboSeason = new ComboBox();
            cboWorkGroup = new ComboBox();
            labelWorkGroup = new Label();
            labelSeason = new Label();
            labelContractor = new Label();
            cboContractor = new ComboBox();
            dgvReport = new DataGridView();
            lblTitle = new Label();
            gpbExcelSheets = new GroupBox();
            chbSheetResumen = new CheckBox();
            chbSheetConcentrado = new CheckBox();
            chbSheetCuadrilla = new CheckBox();
            chbSheetAnotador = new CheckBox();
            groupBox1 = new GroupBox();
            btnClearList = new Button();
            chbShowReport = new CheckBox();
            chbShowEmployees = new CheckBox();
            btnExcel = new Button();
            bgpInfo = new GroupBox();
            lblSobrantesInfo = new Label();
            dtpDate1 = new DateTimePicker();
            labelDate = new Label();
            labelDateTo = new Label();
            dtpDate2 = new DateTimePicker();
            btnLoadReport = new Button();
            lblEmployeeAdvice = new Label();
            btnAddEmployee = new Button();
            btnSearchEmployee = new Button();
            label1 = new Label();
            txbIdEmployee = new RichTextBox();
            gpbFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReport).BeginInit();
            gpbExcelSheets.SuspendLayout();
            groupBox1.SuspendLayout();
            bgpInfo.SuspendLayout();
            SuspendLayout();
            // 
            // gpbFilters
            // 
            gpbFilters.Controls.Add(btnAddList);
            gpbFilters.Controls.Add(cboUser);
            gpbFilters.Controls.Add(labelUser);
            gpbFilters.Controls.Add(cboSeason);
            gpbFilters.Controls.Add(cboWorkGroup);
            gpbFilters.Controls.Add(labelWorkGroup);
            gpbFilters.Controls.Add(labelSeason);
            gpbFilters.Controls.Add(labelContractor);
            gpbFilters.Controls.Add(cboContractor);
            gpbFilters.Font = new Font("Segoe UI", 12F);
            gpbFilters.Location = new Point(12, 33);
            gpbFilters.Name = "gpbFilters";
            gpbFilters.Size = new Size(1001, 93);
            gpbFilters.TabIndex = 51;
            gpbFilters.TabStop = false;
            gpbFilters.Text = "Filtros";
            // 
            // btnAddList
            // 
            btnAddList.Font = new Font("Segoe UI", 12F);
            btnAddList.Image = Properties.Resources.mas_16;
            btnAddList.ImageAlign = ContentAlignment.MiddleLeft;
            btnAddList.Location = new Point(735, 53);
            btnAddList.Name = "btnAddList";
            btnAddList.Padding = new Padding(5, 0, 0, 0);
            btnAddList.Size = new Size(147, 31);
            btnAddList.TabIndex = 88;
            btnAddList.Text = "Agregar listado";
            btnAddList.TextAlign = ContentAlignment.MiddleRight;
            btnAddList.UseVisualStyleBackColor = true;
            // 
            // cboUser
            // 
            cboUser.DropDownStyle = ComboBoxStyle.DropDownList;
            cboUser.FormattingEnabled = true;
            cboUser.Location = new Point(369, 54);
            cboUser.Margin = new Padding(0, 3, 3, 3);
            cboUser.Name = "cboUser";
            cboUser.Size = new Size(360, 29);
            cboUser.TabIndex = 56;
            // 
            // labelUser
            // 
            labelUser.AutoSize = true;
            labelUser.Location = new Point(297, 57);
            labelUser.Margin = new Padding(0);
            labelUser.Name = "labelUser";
            labelUser.Size = new Size(75, 21);
            labelUser.TabIndex = 55;
            labelUser.Text = "Anotador";
            // 
            // cboSeason
            // 
            cboSeason.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSeason.FormattingEnabled = true;
            cboSeason.Location = new Point(94, 22);
            cboSeason.Margin = new Padding(0, 3, 3, 3);
            cboSeason.Name = "cboSeason";
            cboSeason.Size = new Size(190, 29);
            cboSeason.TabIndex = 49;
            // 
            // cboWorkGroup
            // 
            cboWorkGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            cboWorkGroup.FormattingEnabled = true;
            cboWorkGroup.Location = new Point(369, 19);
            cboWorkGroup.Margin = new Padding(0, 3, 3, 3);
            cboWorkGroup.Name = "cboWorkGroup";
            cboWorkGroup.Size = new Size(360, 29);
            cboWorkGroup.TabIndex = 45;
            // 
            // labelWorkGroup
            // 
            labelWorkGroup.AutoSize = true;
            labelWorkGroup.Location = new Point(297, 22);
            labelWorkGroup.Margin = new Padding(0);
            labelWorkGroup.Name = "labelWorkGroup";
            labelWorkGroup.Size = new Size(72, 21);
            labelWorkGroup.TabIndex = 44;
            labelWorkGroup.Text = "Cuadrilla";
            // 
            // labelSeason
            // 
            labelSeason.AutoSize = true;
            labelSeason.Location = new Point(8, 25);
            labelSeason.Margin = new Padding(0);
            labelSeason.Name = "labelSeason";
            labelSeason.Size = new Size(87, 21);
            labelSeason.TabIndex = 48;
            labelSeason.Text = "Temporada";
            // 
            // labelContractor
            // 
            labelContractor.AutoSize = true;
            labelContractor.Location = new Point(8, 59);
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
            cboContractor.Location = new Point(94, 54);
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
            dgvReport.Location = new Point(12, 260);
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
            dgvReport.Size = new Size(1001, 311);
            dgvReport.TabIndex = 69;
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
            // gpbExcelSheets
            // 
            gpbExcelSheets.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gpbExcelSheets.Controls.Add(chbSheetResumen);
            gpbExcelSheets.Controls.Add(chbSheetConcentrado);
            gpbExcelSheets.Controls.Add(chbSheetCuadrilla);
            gpbExcelSheets.Controls.Add(chbSheetAnotador);
            gpbExcelSheets.Font = new Font("Segoe UI", 10F);
            gpbExcelSheets.Location = new Point(666, 579);
            gpbExcelSheets.Name = "gpbExcelSheets";
            gpbExcelSheets.Size = new Size(346, 76);
            gpbExcelSheets.TabIndex = 72;
            gpbExcelSheets.TabStop = false;
            gpbExcelSheets.Text = "Hojas Excel";
            // 
            // chbSheetResumen
            // 
            chbSheetResumen.AutoSize = true;
            chbSheetResumen.Checked = true;
            chbSheetResumen.CheckState = CheckState.Checked;
            chbSheetResumen.Location = new Point(198, 53);
            chbSheetResumen.Name = "chbSheetResumen";
            chbSheetResumen.Size = new Size(15, 14);
            chbSheetResumen.TabIndex = 3;
            chbSheetResumen.UseVisualStyleBackColor = true;
            // 
            // chbSheetConcentrado
            // 
            chbSheetConcentrado.AutoSize = true;
            chbSheetConcentrado.Checked = true;
            chbSheetConcentrado.CheckState = CheckState.Checked;
            chbSheetConcentrado.Location = new Point(6, 53);
            chbSheetConcentrado.Name = "chbSheetConcentrado";
            chbSheetConcentrado.Size = new Size(15, 14);
            chbSheetConcentrado.TabIndex = 2;
            chbSheetConcentrado.UseVisualStyleBackColor = true;
            // 
            // chbSheetCuadrilla
            // 
            chbSheetCuadrilla.AutoSize = true;
            chbSheetCuadrilla.Checked = true;
            chbSheetCuadrilla.CheckState = CheckState.Checked;
            chbSheetCuadrilla.Location = new Point(198, 29);
            chbSheetCuadrilla.Name = "chbSheetCuadrilla";
            chbSheetCuadrilla.Size = new Size(15, 14);
            chbSheetCuadrilla.TabIndex = 1;
            chbSheetCuadrilla.UseVisualStyleBackColor = true;
            // 
            // chbSheetAnotador
            // 
            chbSheetAnotador.AutoSize = true;
            chbSheetAnotador.Checked = true;
            chbSheetAnotador.CheckState = CheckState.Checked;
            chbSheetAnotador.Location = new Point(6, 29);
            chbSheetAnotador.Name = "chbSheetAnotador";
            chbSheetAnotador.Size = new Size(15, 14);
            chbSheetAnotador.TabIndex = 0;
            chbSheetAnotador.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(lblEmployeeAdvice);
            groupBox1.Controls.Add(btnAddEmployee);
            groupBox1.Controls.Add(btnSearchEmployee);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txbIdEmployee);
            groupBox1.Font = new Font("Segoe UI", 10F);
            groupBox1.Location = new Point(12, 132);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1000, 85);
            groupBox1.TabIndex = 73;
            groupBox1.TabStop = false;
            groupBox1.Text = "Agregar por empleado";
            // 
            // btnClearList
            // 
            btnClearList.Font = new Font("Segoe UI", 12F);
            btnClearList.Image = Properties.Resources.limpiarIcon16;
            btnClearList.ImageAlign = ContentAlignment.MiddleLeft;
            btnClearList.Location = new Point(12, 223);
            btnClearList.Name = "btnClearList";
            btnClearList.Padding = new Padding(5, 0, 0, 0);
            btnClearList.Size = new Size(96, 31);
            btnClearList.TabIndex = 86;
            btnClearList.Text = "Limpiar";
            btnClearList.TextAlign = ContentAlignment.MiddleRight;
            btnClearList.UseVisualStyleBackColor = true;
            // 
            // chbShowReport
            // 
            chbShowReport.Appearance = Appearance.Button;
            chbShowReport.Font = new Font("Segoe UI", 12F);
            chbShowReport.Image = Properties.Resources.verIcon16;
            chbShowReport.ImageAlign = ContentAlignment.MiddleLeft;
            chbShowReport.Location = new Point(211, 223);
            chbShowReport.Name = "chbShowReport";
            chbShowReport.Padding = new Padding(4, 0, 0, 0);
            chbShowReport.Size = new Size(95, 31);
            chbShowReport.TabIndex = 85;
            chbShowReport.Text = "Reporte";
            chbShowReport.TextAlign = ContentAlignment.MiddleRight;
            chbShowReport.UseVisualStyleBackColor = true;
            // 
            // chbShowEmployees
            // 
            chbShowEmployees.Appearance = Appearance.Button;
            chbShowEmployees.Font = new Font("Segoe UI", 12F);
            chbShowEmployees.Image = Properties.Resources.verIcon16;
            chbShowEmployees.ImageAlign = ContentAlignment.MiddleLeft;
            chbShowEmployees.Location = new Point(114, 223);
            chbShowEmployees.Name = "chbShowEmployees";
            chbShowEmployees.Padding = new Padding(4, 0, 0, 0);
            chbShowEmployees.Size = new Size(91, 31);
            chbShowEmployees.TabIndex = 84;
            chbShowEmployees.Text = "Listado";
            chbShowEmployees.TextAlign = ContentAlignment.MiddleRight;
            chbShowEmployees.UseVisualStyleBackColor = true;
            // 
            // btnExcel
            // 
            btnExcel.Font = new Font("Segoe UI", 12F);
            btnExcel.Image = Properties.Resources.excelIcon;
            btnExcel.ImageAlign = ContentAlignment.MiddleRight;
            btnExcel.Location = new Point(543, 19);
            btnExcel.Name = "btnExcel";
            btnExcel.Padding = new Padding(0, 0, 4, 0);
            btnExcel.Size = new Size(97, 31);
            btnExcel.TabIndex = 71;
            btnExcel.Text = "Excel";
            btnExcel.TextAlign = ContentAlignment.TopLeft;
            btnExcel.UseVisualStyleBackColor = true;
            btnExcel.Click += btnExcel_Click;
            // 
            // bgpInfo
            // 
            bgpInfo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            bgpInfo.Controls.Add(lblSobrantesInfo);
            bgpInfo.Controls.Add(dtpDate1);
            bgpInfo.Controls.Add(btnExcel);
            bgpInfo.Controls.Add(labelDate);
            bgpInfo.Controls.Add(labelDateTo);
            bgpInfo.Controls.Add(dtpDate2);
            bgpInfo.Controls.Add(btnLoadReport);
            bgpInfo.Font = new Font("Segoe UI", 12F);
            bgpInfo.Location = new Point(12, 577);
            bgpInfo.Name = "bgpInfo";
            bgpInfo.Size = new Size(648, 78);
            bgpInfo.TabIndex = 87;
            bgpInfo.TabStop = false;
            bgpInfo.Text = "Reporte";
            // 
            // lblSobrantesInfo
            // 
            lblSobrantesInfo.AutoSize = true;
            lblSobrantesInfo.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblSobrantesInfo.ForeColor = Color.Gray;
            lblSobrantesInfo.Location = new Point(15, 52);
            lblSobrantesInfo.Name = "lblSobrantesInfo";
            lblSobrantesInfo.Size = new Size(545, 15);
            lblSobrantesInfo.TabIndex = 72;
            lblSobrantesInfo.Text = "ℹ Si no hay empleados en el listado se generará de todos los empleados en la temporada seleccionada";
            // 
            // dtpDate1
            // 
            dtpDate1.Format = DateTimePickerFormat.Short;
            dtpDate1.Location = new Point(116, 20);
            dtpDate1.Name = "dtpDate1";
            dtpDate1.Size = new Size(120, 29);
            dtpDate1.TabIndex = 52;
            // 
            // labelDate
            // 
            labelDate.AutoSize = true;
            labelDate.Location = new Point(10, 25);
            labelDate.Margin = new Padding(0);
            labelDate.Name = "labelDate";
            labelDate.Size = new Size(103, 21);
            labelDate.TabIndex = 50;
            labelDate.Text = "Rango fechas";
            // 
            // labelDateTo
            // 
            labelDateTo.AutoSize = true;
            labelDateTo.Location = new Point(242, 25);
            labelDateTo.Margin = new Padding(0);
            labelDateTo.Name = "labelDateTo";
            labelDateTo.Size = new Size(22, 21);
            labelDateTo.TabIndex = 51;
            labelDateTo.Text = "al";
            // 
            // dtpDate2
            // 
            dtpDate2.Format = DateTimePickerFormat.Short;
            dtpDate2.Location = new Point(267, 20);
            dtpDate2.Name = "dtpDate2";
            dtpDate2.Size = new Size(120, 29);
            dtpDate2.TabIndex = 53;
            // 
            // btnLoadReport
            // 
            btnLoadReport.Font = new Font("Segoe UI", 12F);
            btnLoadReport.Image = Properties.Resources.BuscarLupa1;
            btnLoadReport.ImageAlign = ContentAlignment.MiddleRight;
            btnLoadReport.Location = new Point(393, 19);
            btnLoadReport.Name = "btnLoadReport";
            btnLoadReport.Padding = new Padding(0, 0, 4, 0);
            btnLoadReport.Size = new Size(142, 31);
            btnLoadReport.TabIndex = 68;
            btnLoadReport.Text = "Cargar reporte";
            btnLoadReport.TextAlign = ContentAlignment.TopLeft;
            btnLoadReport.UseVisualStyleBackColor = true;
            // 
            // lblEmployeeAdvice
            // 
            lblEmployeeAdvice.AutoSize = true;
            lblEmployeeAdvice.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblEmployeeAdvice.ForeColor = Color.Gray;
            lblEmployeeAdvice.Location = new Point(244, 57);
            lblEmployeeAdvice.Name = "lblEmployeeAdvice";
            lblEmployeeAdvice.Size = new Size(105, 15);
            lblEmployeeAdvice.TabIndex = 89;
            lblEmployeeAdvice.Text = "lblEmployeeAdvice";
            // 
            // btnAddEmployee
            // 
            btnAddEmployee.Font = new Font("Segoe UI", 12F);
            btnAddEmployee.Image = Properties.Resources.mas_16;
            btnAddEmployee.ImageAlign = ContentAlignment.MiddleLeft;
            btnAddEmployee.Location = new Point(244, 23);
            btnAddEmployee.Name = "btnAddEmployee";
            btnAddEmployee.Padding = new Padding(5, 0, 0, 0);
            btnAddEmployee.Size = new Size(168, 31);
            btnAddEmployee.TabIndex = 88;
            btnAddEmployee.Text = "Agregar empleado";
            btnAddEmployee.TextAlign = ContentAlignment.MiddleRight;
            btnAddEmployee.UseVisualStyleBackColor = true;
            // 
            // btnSearchEmployee
            // 
            btnSearchEmployee.Font = new Font("Segoe UI", 12F);
            btnSearchEmployee.Image = Properties.Resources.BuscarLupa1;
            btnSearchEmployee.ImageAlign = ContentAlignment.MiddleRight;
            btnSearchEmployee.Location = new Point(116, 24);
            btnSearchEmployee.Name = "btnSearchEmployee";
            btnSearchEmployee.Padding = new Padding(0, 0, 4, 0);
            btnSearchEmployee.Size = new Size(33, 31);
            btnSearchEmployee.TabIndex = 87;
            btnSearchEmployee.TextAlign = ContentAlignment.TopLeft;
            btnSearchEmployee.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 28);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(83, 38);
            label1.TabIndex = 86;
            label1.Text = "Código(s)\r\nempleado(s)";
            // 
            // txbIdEmployee
            // 
            txbIdEmployee.Font = new Font("Segoe UI", 10F);
            txbIdEmployee.Location = new Point(155, 24);
            txbIdEmployee.Name = "txbIdEmployee";
            txbIdEmployee.ScrollBars = RichTextBoxScrollBars.Vertical;
            txbIdEmployee.Size = new Size(83, 48);
            txbIdEmployee.TabIndex = 85;
            txbIdEmployee.Text = "";
            // 
            // FrmPayrollBoxPerEmployeeReport
            // 
            btnLoadReport.Click                += btnLoadReport_Click;
            btnAddEmployee.Click               += btnAddEmployee_Click;
            btnSearchEmployee.Click            += btnSearchEmployee_Click;
            btnAddList.Click                   += btnAddList_Click;
            btnClearList.Click                 += btnClearList_Click;
            chbShowEmployees.CheckedChanged    += chbShowEmployees_CheckedChanged;
            chbShowReport.CheckedChanged       += chbShowReport_CheckedChanged;
            txbIdEmployee.KeyDown              += txbIdEmployee_KeyDown;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoScrollMargin = new Size(10, 10);
            AutoScrollMinSize = new Size(0, 650);
            ClientSize = new Size(1025, 667);
            Controls.Add(bgpInfo);
            Controls.Add(btnClearList);
            Controls.Add(chbShowReport);
            Controls.Add(chbShowEmployees);
            Controls.Add(groupBox1);
            Controls.Add(lblTitle);
            Controls.Add(gpbFilters);
            Controls.Add(dgvReport);
            Controls.Add(gpbExcelSheets);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmPayrollBoxPerEmployeeReport";
            Text = "Reporte cajas por empleado";
            Load += FrmPayrollBoxPerEmployeeReport_Load;
            gpbFilters.ResumeLayout(false);
            gpbFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReport).EndInit();
            gpbExcelSheets.ResumeLayout(false);
            gpbExcelSheets.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
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
        public System.Windows.Forms.DataGridView dgvReport;
        public System.Windows.Forms.Label lblTitle;
        public System.Windows.Forms.ComboBox cboUser;
        private System.Windows.Forms.Label labelUser;
        public System.Windows.Forms.GroupBox gpbExcelSheets;
        public System.Windows.Forms.CheckBox chbSheetAnotador;
        public System.Windows.Forms.CheckBox chbSheetCuadrilla;
        public System.Windows.Forms.CheckBox chbSheetConcentrado;
        public System.Windows.Forms.CheckBox chbSheetResumen;
        public GroupBox groupBox1;
        private Button btnClearList;
        public CheckBox chbShowReport;
        public CheckBox chbShowEmployees;
        private Button btnExcel;
        private GroupBox bgpInfo;
        private Label lblSobrantesInfo;
        public DateTimePicker dtpDate1;
        private Label labelDate;
        private Label labelDateTo;
        public DateTimePicker dtpDate2;
        private Button btnLoadReport;
        private Button btnAddList;
        public Label lblEmployeeAdvice;
        private Button btnAddEmployee;
        private Button btnSearchEmployee;
        private Label label1;
        public RichTextBox txbIdEmployee;
    }
}

