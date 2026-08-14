namespace SisUvex.Nomina.Asistencia_AS
{
    partial class FrmAsistenciaASConsulta
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
            btnClearList = new Button();
            chbShowReport = new CheckBox();
            chbShowEmployees = new CheckBox();
            bgpInfo = new GroupBox();
            lblSobrantesInfo = new Label();
            dtpDate1 = new DateTimePicker();
            btnExcel = new Button();
            labelDate = new Label();
            labelDateTo = new Label();
            dtpDate2 = new DateTimePicker();
            btnLoadReport = new Button();
            gpbFilters = new GroupBox();
            lblEmployeeAdvice = new Label();
            btnAddList = new Button();
            btnAddEmployee = new Button();
            btnSearchEmployee = new Button();
            label1 = new Label();
            txbIdEmployee = new RichTextBox();
            cboSeason = new ComboBox();
            cboLP = new ComboBox();
            labelLP = new Label();
            labelSeason = new Label();
            dgvReport = new DataGridView();
            lblTitle = new Label();
            cboAttendenceType = new ComboBox();
            label2 = new Label();
            bgpInfo.SuspendLayout();
            gpbFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReport).BeginInit();
            SuspendLayout();
            // 
            // btnClearList
            // 
            btnClearList.Font = new Font("Segoe UI", 12F);
            btnClearList.Image = Properties.Resources.limpiarIcon16;
            btnClearList.ImageAlign = ContentAlignment.MiddleLeft;
            btnClearList.Location = new Point(12, 216);
            btnClearList.Name = "btnClearList";
            btnClearList.Padding = new Padding(5, 0, 0, 0);
            btnClearList.Size = new Size(96, 31);
            btnClearList.TabIndex = 90;
            btnClearList.Text = "Limpiar";
            btnClearList.TextAlign = ContentAlignment.MiddleRight;
            btnClearList.UseVisualStyleBackColor = true;
            btnClearList.Click += btnClearList_Click;
            // 
            // chbShowReport
            // 
            chbShowReport.Appearance = Appearance.Button;
            chbShowReport.Font = new Font("Segoe UI", 12F);
            chbShowReport.Image = Properties.Resources.verIcon16;
            chbShowReport.ImageAlign = ContentAlignment.MiddleLeft;
            chbShowReport.Location = new Point(211, 216);
            chbShowReport.Name = "chbShowReport";
            chbShowReport.Padding = new Padding(4, 0, 0, 0);
            chbShowReport.Size = new Size(95, 31);
            chbShowReport.TabIndex = 89;
            chbShowReport.Text = "Reporte";
            chbShowReport.TextAlign = ContentAlignment.MiddleRight;
            chbShowReport.UseVisualStyleBackColor = true;
            chbShowReport.CheckedChanged += chbShowReport_CheckedChanged;
            // 
            // chbShowEmployees
            // 
            chbShowEmployees.Appearance = Appearance.Button;
            chbShowEmployees.Font = new Font("Segoe UI", 12F);
            chbShowEmployees.Image = Properties.Resources.verIcon16;
            chbShowEmployees.ImageAlign = ContentAlignment.MiddleLeft;
            chbShowEmployees.Location = new Point(114, 216);
            chbShowEmployees.Name = "chbShowEmployees";
            chbShowEmployees.Padding = new Padding(4, 0, 0, 0);
            chbShowEmployees.Size = new Size(91, 31);
            chbShowEmployees.TabIndex = 88;
            chbShowEmployees.Text = "Listado";
            chbShowEmployees.TextAlign = ContentAlignment.MiddleRight;
            chbShowEmployees.UseVisualStyleBackColor = true;
            chbShowEmployees.CheckedChanged += chbShowEmployees_CheckedChanged;
            // 
            // bgpInfo
            // 
            bgpInfo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            bgpInfo.Controls.Add(lblSobrantesInfo);
            bgpInfo.Controls.Add(dtpDate1);
            bgpInfo.Controls.Add(btnExcel);
            bgpInfo.Controls.Add(labelDate);
            bgpInfo.Controls.Add(labelDateTo);
            bgpInfo.Controls.Add(dtpDate2);
            bgpInfo.Controls.Add(btnLoadReport);
            bgpInfo.Font = new Font("Segoe UI", 12F);
            bgpInfo.Location = new Point(12, 499);
            bgpInfo.Name = "bgpInfo";
            bgpInfo.Size = new Size(858, 78);
            bgpInfo.TabIndex = 87;
            bgpInfo.TabStop = false;
            bgpInfo.Text = "Reporte";
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
            // dtpDate1
            // 
            dtpDate1.Format = DateTimePickerFormat.Short;
            dtpDate1.Location = new Point(118, 20);
            dtpDate1.Name = "dtpDate1";
            dtpDate1.Size = new Size(120, 29);
            dtpDate1.TabIndex = 52;
            // 
            // btnExcel
            // 
            btnExcel.Font = new Font("Segoe UI", 12F);
            btnExcel.Image = Properties.Resources.excelIcon;
            btnExcel.ImageAlign = ContentAlignment.MiddleRight;
            btnExcel.Location = new Point(753, 19);
            btnExcel.Name = "btnExcel";
            btnExcel.Padding = new Padding(0, 0, 4, 0);
            btnExcel.Size = new Size(97, 31);
            btnExcel.TabIndex = 71;
            btnExcel.Text = "Excel";
            btnExcel.TextAlign = ContentAlignment.TopLeft;
            btnExcel.UseVisualStyleBackColor = true;
            btnExcel.Click += btnExcel_Click;
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
            // dtpDate2
            // 
            dtpDate2.Format = DateTimePickerFormat.Short;
            dtpDate2.Location = new Point(269, 20);
            dtpDate2.Name = "dtpDate2";
            dtpDate2.Size = new Size(120, 29);
            dtpDate2.TabIndex = 53;
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
            btnLoadReport.Click += btnLoadReport_Click;
            // 
            // gpbFilters
            // 
            gpbFilters.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gpbFilters.Controls.Add(lblEmployeeAdvice);
            gpbFilters.Controls.Add(btnAddList);
            gpbFilters.Controls.Add(btnAddEmployee);
            gpbFilters.Controls.Add(btnSearchEmployee);
            gpbFilters.Controls.Add(label1);
            gpbFilters.Controls.Add(txbIdEmployee);
            gpbFilters.Controls.Add(cboSeason);
            gpbFilters.Controls.Add(cboLP);
            gpbFilters.Controls.Add(labelLP);
            gpbFilters.Controls.Add(labelSeason);
            gpbFilters.Font = new Font("Segoe UI", 12F);
            gpbFilters.Location = new Point(12, 33);
            gpbFilters.Name = "gpbFilters";
            gpbFilters.Size = new Size(858, 177);
            gpbFilters.TabIndex = 85;
            gpbFilters.TabStop = false;
            gpbFilters.Text = "Filtros";
            // 
            // lblEmployeeAdvice
            // 
            lblEmployeeAdvice.AutoSize = true;
            lblEmployeeAdvice.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblEmployeeAdvice.ForeColor = Color.Gray;
            lblEmployeeAdvice.Location = new Point(244, 153);
            lblEmployeeAdvice.Name = "lblEmployeeAdvice";
            lblEmployeeAdvice.Size = new Size(105, 15);
            lblEmployeeAdvice.TabIndex = 84;
            lblEmployeeAdvice.Text = "lblEmployeeAdvice";
            // 
            // btnAddList
            // 
            btnAddList.Font = new Font("Segoe UI", 12F);
            btnAddList.Image = Properties.Resources.mas_16;
            btnAddList.ImageAlign = ContentAlignment.MiddleLeft;
            btnAddList.Location = new Point(422, 52);
            btnAddList.Name = "btnAddList";
            btnAddList.Padding = new Padding(5, 0, 0, 0);
            btnAddList.Size = new Size(147, 31);
            btnAddList.TabIndex = 83;
            btnAddList.Text = "Agregar listado";
            btnAddList.TextAlign = ContentAlignment.MiddleRight;
            btnAddList.UseVisualStyleBackColor = true;
            btnAddList.Click += btnAddList_Click;
            // 
            // btnAddEmployee
            // 
            btnAddEmployee.Font = new Font("Segoe UI", 12F);
            btnAddEmployee.Image = Properties.Resources.mas_16;
            btnAddEmployee.ImageAlign = ContentAlignment.MiddleLeft;
            btnAddEmployee.Location = new Point(244, 119);
            btnAddEmployee.Name = "btnAddEmployee";
            btnAddEmployee.Padding = new Padding(5, 0, 0, 0);
            btnAddEmployee.Size = new Size(168, 31);
            btnAddEmployee.TabIndex = 82;
            btnAddEmployee.Text = "Agregar empleado";
            btnAddEmployee.TextAlign = ContentAlignment.MiddleRight;
            btnAddEmployee.UseVisualStyleBackColor = true;
            btnAddEmployee.Click += btnAddEmployee_Click;
            // 
            // btnSearchEmployee
            // 
            btnSearchEmployee.Font = new Font("Segoe UI", 12F);
            btnSearchEmployee.Image = Properties.Resources.BuscarLupa1;
            btnSearchEmployee.ImageAlign = ContentAlignment.MiddleRight;
            btnSearchEmployee.Location = new Point(116, 120);
            btnSearchEmployee.Name = "btnSearchEmployee";
            btnSearchEmployee.Padding = new Padding(0, 0, 4, 0);
            btnSearchEmployee.Size = new Size(33, 31);
            btnSearchEmployee.TabIndex = 81;
            btnSearchEmployee.TextAlign = ContentAlignment.TopLeft;
            btnSearchEmployee.UseVisualStyleBackColor = true;
            btnSearchEmployee.Click += btnSearchEmployee_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 124);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(96, 42);
            label1.TabIndex = 80;
            label1.Text = "Código(s)\r\nempleado(s)";
            // 
            // txbIdEmployee
            // 
            txbIdEmployee.Font = new Font("Segoe UI", 10F);
            txbIdEmployee.Location = new Point(155, 120);
            txbIdEmployee.Name = "txbIdEmployee";
            txbIdEmployee.ScrollBars = RichTextBoxScrollBars.Vertical;
            txbIdEmployee.Size = new Size(83, 48);
            txbIdEmployee.TabIndex = 79;
            txbIdEmployee.Text = "";
            txbIdEmployee.KeyDown += txbIdEmployee_KeyDown;
            // 
            // cboSeason
            // 
            cboSeason.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSeason.FormattingEnabled = true;
            cboSeason.Location = new Point(89, 22);
            cboSeason.Margin = new Padding(0, 3, 3, 3);
            cboSeason.Name = "cboSeason";
            cboSeason.Size = new Size(190, 29);
            cboSeason.TabIndex = 49;
            // 
            // cboLP
            // 
            cboLP.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLP.FormattingEnabled = true;
            cboLP.Location = new Point(423, 22);
            cboLP.Margin = new Padding(0, 3, 3, 3);
            cboLP.Name = "cboLP";
            cboLP.Size = new Size(360, 29);
            cboLP.TabIndex = 45;
            // 
            // labelLP
            // 
            labelLP.AutoSize = true;
            labelLP.Location = new Point(315, 25);
            labelLP.Margin = new Padding(0);
            labelLP.Name = "labelLP";
            labelLP.Size = new Size(110, 21);
            labelLP.TabIndex = 44;
            labelLP.Text = "Lugar de pago";
            // 
            // labelSeason
            // 
            labelSeason.AutoSize = true;
            labelSeason.Location = new Point(3, 25);
            labelSeason.Margin = new Padding(0);
            labelSeason.Name = "labelSeason";
            labelSeason.Size = new Size(87, 21);
            labelSeason.TabIndex = 48;
            labelSeason.Text = "Temporada";
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
            dgvReport.Location = new Point(12, 253);
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
            dgvReport.Size = new Size(858, 240);
            dgvReport.TabIndex = 86;
            dgvReport.CellFormatting += dgvReport_CellFormatting;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.Location = new Point(9, 9);
            lblTitle.Margin = new Padding(0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(149, 21);
            lblTitle.TabIndex = 84;
            lblTitle.Tag = "lotData";
            lblTitle.Text = "Reporte asistencia";
            // 
            // cboAttendenceType
            // 
            cboAttendenceType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboAttendenceType.FormattingEnabled = true;
            cboAttendenceType.Location = new Point(680, 224);
            cboAttendenceType.Margin = new Padding(0, 3, 3, 3);
            cboAttendenceType.Name = "cboAttendenceType";
            cboAttendenceType.Size = new Size(190, 23);
            cboAttendenceType.TabIndex = 92;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(541, 227);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Size = new Size(139, 15);
            label2.TabIndex = 91;
            label2.Text = "Innasistencia por defecto";
            // 
            // FrmAsistenciaASConsulta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 589);
            Controls.Add(cboAttendenceType);
            Controls.Add(label2);
            Controls.Add(btnClearList);
            Controls.Add(chbShowReport);
            Controls.Add(chbShowEmployees);
            Controls.Add(bgpInfo);
            Controls.Add(gpbFilters);
            Controls.Add(dgvReport);
            Controls.Add(lblTitle);
            Name = "FrmAsistenciaASConsulta";
            Text = "FrmAsistenciaASConsulta";
            Load += FrmAsistenciaASConsulta_Load;
            bgpInfo.ResumeLayout(false);
            bgpInfo.PerformLayout();
            gpbFilters.ResumeLayout(false);
            gpbFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReport).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnClearList;
        public CheckBox chbShowReport;
        public CheckBox chbShowEmployees;
        private GroupBox bgpInfo;
        private Label lblSobrantesInfo;
        public DateTimePicker dtpDate1;
        private Button btnExcel;
        private Label labelDate;
        private Label labelDateTo;
        public DateTimePicker dtpDate2;
        private Button btnLoadReport;
        private GroupBox gpbFilters;
        public Label lblEmployeeAdvice;
        private Button btnAddList;
        private Button btnAddEmployee;
        private Button btnSearchEmployee;
        private Label label1;
        public RichTextBox txbIdEmployee;
        public ComboBox cboSeason;
        public ComboBox cboLP;
        private Label labelLP;
        private Label labelSeason;
        public DataGridView dgvReport;
        public Label lblTitle;
        public ComboBox cboAttendenceType;
        private Label label2;
    }
}