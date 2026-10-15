namespace SisUvex.Nomina.CONTRATO.PayrollPack_BoxPerNumber.BoxPerEmployeeReport
{
    partial class FrmPayrollBoxPerEmployeeDetailReport
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPayrollBoxPerEmployeeDetailReport));
            lblTitle = new Label();
            gpbFilters = new GroupBox();
            lblEmployeeAdvice = new Label();
            btnAddList = new Button();
            btnAddEmployee = new Button();
            btnSearchEmployee = new Button();
            label1 = new Label();
            txbIdEmployee = new RichTextBox();
            cboSeason = new ComboBox();
            cboWorkGroup = new ComboBox();
            labelWorkGroup = new Label();
            labelSeason = new Label();
            labelContractor = new Label();
            cboContractor = new ComboBox();
            bgpInfo = new GroupBox();
            lblSobrantesInfo = new Label();
            dtpDate1 = new DateTimePicker();
            btnExcel = new Button();
            labelDate = new Label();
            labelDateTo = new Label();
            dtpDate2 = new DateTimePicker();
            btnLoadReport = new Button();
            btnClearList = new Button();
            pgrReport = new ProgressBar();
            tabReport = new TabControl();
            tabPageListado = new TabPage();
            dgvListado = new DataGridView();
            tabPageDetalle = new TabPage();
            dgvDetalle = new DataGridView();
            tabPageResumen = new TabPage();
            dgvResumen = new DataGridView();
            tabPageCajasEmp = new TabPage();
            dgvCajasEmpleado = new DataGridView();
            gpbFilters.SuspendLayout();
            bgpInfo.SuspendLayout();
            tabReport.SuspendLayout();
            tabPageListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListado).BeginInit();
            tabPageDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).BeginInit();
            tabPageResumen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResumen).BeginInit();
            tabPageCajasEmp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCajasEmpleado).BeginInit();
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
            lblTitle.TabIndex = 0;
            lblTitle.Tag = "lotData";
            lblTitle.Text = "Reporte cajas por cada empleado detallado";
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
            gpbFilters.Controls.Add(cboWorkGroup);
            gpbFilters.Controls.Add(labelWorkGroup);
            gpbFilters.Controls.Add(labelSeason);
            gpbFilters.Controls.Add(labelContractor);
            gpbFilters.Controls.Add(cboContractor);
            gpbFilters.Font = new Font("Segoe UI", 12F);
            gpbFilters.Location = new Point(12, 33);
            gpbFilters.Name = "gpbFilters";
            gpbFilters.Size = new Size(859, 177);
            gpbFilters.TabIndex = 0;
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
            btnAddList.Location = new Point(421, 56);
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
            // bgpInfo
            // 
            bgpInfo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            bgpInfo.Controls.Add(btnClearList);
            bgpInfo.Controls.Add(lblSobrantesInfo);
            bgpInfo.Controls.Add(dtpDate1);
            bgpInfo.Controls.Add(btnExcel);
            bgpInfo.Controls.Add(labelDate);
            bgpInfo.Controls.Add(labelDateTo);
            bgpInfo.Controls.Add(dtpDate2);
            bgpInfo.Controls.Add(btnLoadReport);
            bgpInfo.Font = new Font("Segoe UI", 12F);
            bgpInfo.Location = new Point(12, 216);
            bgpInfo.Name = "bgpInfo";
            bgpInfo.Size = new Size(859, 78);
            bgpInfo.TabIndex = 76;
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
            // btnClearList
            // 
            btnClearList.Font = new Font("Segoe UI", 12F);
            btnClearList.Image = Properties.Resources.limpiarIcon16;
            btnClearList.ImageAlign = ContentAlignment.MiddleLeft;
            btnClearList.Location = new Point(543, 19);
            btnClearList.Name = "btnClearList";
            btnClearList.Padding = new Padding(5, 0, 0, 0);
            btnClearList.Size = new Size(96, 31);
            btnClearList.TabIndex = 20;
            btnClearList.Text = "Limpiar";
            btnClearList.TextAlign = ContentAlignment.MiddleRight;
            btnClearList.UseVisualStyleBackColor = true;
            btnClearList.Click += btnClearList_Click;
            // 
            // pgrReport
            // 
            pgrReport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pgrReport.Location = new Point(12, 300);
            pgrReport.Maximum = 1000;
            pgrReport.Name = "pgrReport";
            pgrReport.Size = new Size(859, 12);
            pgrReport.Style = ProgressBarStyle.Marquee;
            pgrReport.TabIndex = 30;
            pgrReport.Visible = false;
            // 
            // tabReport
            // 
            tabReport.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabReport.Controls.Add(tabPageListado);
            tabReport.Controls.Add(tabPageDetalle);
            tabReport.Controls.Add(tabPageResumen);
            tabReport.Controls.Add(tabPageCajasEmp);
            tabReport.Location = new Point(12, 318);
            tabReport.Name = "tabReport";
            tabReport.SelectedIndex = 0;
            tabReport.Size = new Size(858, 354);
            tabReport.TabIndex = 40;
            tabReport.SelectedIndexChanged += tabReport_SelectedIndexChanged;
            // 
            // tabPageListado
            // 
            tabPageListado.Controls.Add(dgvListado);
            tabPageListado.Location = new Point(4, 24);
            tabPageListado.Name = "tabPageListado";
            tabPageListado.Padding = new Padding(3);
            tabPageListado.Size = new Size(850, 326);
            tabPageListado.TabIndex = 0;
            tabPageListado.Text = "Listado";
            tabPageListado.UseVisualStyleBackColor = true;
            // 
            // dgvListado
            // 
            dgvListado.Location = new Point(0, 0);
            dgvListado.Name = "dgvListado";
            dgvListado.Size = new Size(240, 150);
            dgvListado.TabIndex = 0;
            dgvListado.CellContentClick += dgvListado_CellContentClick;
            dgvListado.CellFormatting += dgvListado_CellFormatting;
            // 
            // tabPageDetalle
            // 
            tabPageDetalle.Controls.Add(dgvDetalle);
            tabPageDetalle.Location = new Point(4, 24);
            tabPageDetalle.Name = "tabPageDetalle";
            tabPageDetalle.Padding = new Padding(3);
            tabPageDetalle.Size = new Size(850, 295);
            tabPageDetalle.TabIndex = 1;
            tabPageDetalle.Text = "Reporte Detalle";
            tabPageDetalle.UseVisualStyleBackColor = true;
            // 
            // dgvDetalle
            // 
            dgvDetalle.Location = new Point(0, 0);
            dgvDetalle.Name = "dgvDetalle";
            dgvDetalle.Size = new Size(240, 150);
            dgvDetalle.TabIndex = 0;
            dgvDetalle.CellFormatting += dgvDetalle_CellFormatting;
            dgvDetalle.RowPostPaint += dgvDetalle_RowPostPaint;
            // 
            // tabPageResumen
            // 
            tabPageResumen.Controls.Add(dgvResumen);
            tabPageResumen.Location = new Point(4, 24);
            tabPageResumen.Name = "tabPageResumen";
            tabPageResumen.Padding = new Padding(3);
            tabPageResumen.Size = new Size(850, 295);
            tabPageResumen.TabIndex = 2;
            tabPageResumen.Text = "RESUMEN";
            tabPageResumen.UseVisualStyleBackColor = true;
            // 
            // dgvResumen
            // 
            dgvResumen.Location = new Point(0, 0);
            dgvResumen.Name = "dgvResumen";
            dgvResumen.Size = new Size(240, 150);
            dgvResumen.TabIndex = 0;
            dgvResumen.CellFormatting += dgvResumen_CellFormatting;
            // 
            // tabPageCajasEmp
            // 
            tabPageCajasEmp.Controls.Add(dgvCajasEmpleado);
            tabPageCajasEmp.Location = new Point(4, 24);
            tabPageCajasEmp.Name = "tabPageCajasEmp";
            tabPageCajasEmp.Padding = new Padding(3);
            tabPageCajasEmp.Size = new Size(850, 295);
            tabPageCajasEmp.TabIndex = 3;
            tabPageCajasEmp.Text = "Cajas empleado";
            tabPageCajasEmp.UseVisualStyleBackColor = true;
            // 
            // dgvCajasEmpleado
            // 
            dgvCajasEmpleado.Location = new Point(0, 0);
            dgvCajasEmpleado.Name = "dgvCajasEmpleado";
            dgvCajasEmpleado.Size = new Size(240, 150);
            dgvCajasEmpleado.TabIndex = 0;
            dgvCajasEmpleado.CellFormatting += dgvCajasEmpleado_CellFormatting;
            // 
            // FrmPayrollBoxPerEmployeeDetailReport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 684);
            Controls.Add(pgrReport);
            Controls.Add(tabReport);
            Controls.Add(bgpInfo);
            Controls.Add(gpbFilters);
            Controls.Add(lblTitle);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmPayrollBoxPerEmployeeDetailReport";
            Text = "Reporte cajas por cada empleado detallado";
            Load += FrmPayrollBoxPerEmployeeDetailReport_Load;
            gpbFilters.ResumeLayout(false);
            gpbFilters.PerformLayout();
            bgpInfo.ResumeLayout(false);
            bgpInfo.PerformLayout();
            tabReport.ResumeLayout(false);
            tabPageListado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvListado).EndInit();
            tabPageDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).EndInit();
            tabPageResumen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvResumen).EndInit();
            tabPageCajasEmp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCajasEmpleado).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        /// <summary>Configura las propiedades comunes de un DataGridView del reporte.</summary>
        private static void ConfigureDgv(
            DataGridView dgv,
            DataGridViewCellStyle headerStyle,
            DataGridViewCellStyle rowStyle,
            bool readOnly)
        {
            DataGridViewCellStyle hs = new DataGridViewCellStyle
            {
                Alignment          = DataGridViewContentAlignment.MiddleCenter,
                BackColor          = SystemColors.Control,
                Font               = new Font("Segoe UI Semibold", 9F, FontStyle.Bold),
                ForeColor          = SystemColors.WindowText,
                SelectionBackColor = SystemColors.Control,
                SelectionForeColor = SystemColors.WindowText,
                WrapMode           = DataGridViewTriState.True,
            };
            DataGridViewCellStyle rs = new DataGridViewCellStyle
            {
                Alignment          = DataGridViewContentAlignment.MiddleLeft,
                BackColor          = SystemColors.Control,
                Font               = new Font("Segoe UI", 9F),
                ForeColor          = SystemColors.WindowText,
                SelectionBackColor = SystemColors.Control,
                SelectionForeColor = SystemColors.WindowText,
                WrapMode           = DataGridViewTriState.True,
            };

            dgv.AllowUserToAddRows    = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.Anchor                = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgv.BackgroundColor       = SystemColors.Control;
            dgv.BorderStyle           = BorderStyle.Fixed3D;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.ColumnHeadersDefaultCellStyle = hs;
            dgv.ColumnHeadersHeightSizeMode   = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.EnableHeadersVisualStyles     = false;
            dgv.ImeMode               = ImeMode.NoControl;
            dgv.Location              = new Point(0, 0);
            dgv.ReadOnly              = readOnly;
            dgv.RowHeadersDefaultCellStyle = rs;
            dgv.RowHeadersVisible     = false;
            dgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgv.SelectionMode         = DataGridViewSelectionMode.FullRowSelect;
            dgv.Size                  = new Size(850, 295);
            dgv.Dock                  = DockStyle.Fill;
            dgv.TabIndex              = 0;
        }

        #endregion

        // ── Campos del designer ───────────────────────────────────────────────
        public  Label         lblTitle;
        private GroupBox      bgpInfo;
        private Button        btnExcel;
        private GroupBox      gpbFilters;
        private Button        btnLoadReport;
        public  DateTimePicker dtpDate2;
        public  DateTimePicker dtpDate1;
        private Label         labelDateTo;
        private Label         labelDate;
        public  ComboBox      cboSeason;
        public  ComboBox      cboWorkGroup;
        private Label         labelWorkGroup;
        private Label         labelSeason;
        private Label         labelContractor;
        public  ComboBox      cboContractor;
        private Label         label1;
        public  RichTextBox   txbIdEmployee;
        private Button        btnAddEmployee;
        private Button        btnSearchEmployee;
        private Button        btnClearList;
        private Button        btnAddList;
        private Label         lblSobrantesInfo;
        public  Label         lblEmployeeAdvice;
        public  ProgressBar   pgrReport;
        public  TabControl    tabReport;
        private TabPage       tabPageListado;
        private TabPage       tabPageDetalle;
        private TabPage       tabPageResumen;
        private TabPage       tabPageCajasEmp;
        public  DataGridView  dgvListado;
        public  DataGridView  dgvDetalle;
        public  DataGridView  dgvResumen;
        public  DataGridView  dgvCajasEmpleado;
    }
}
