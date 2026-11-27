namespace SisUvex.Nomina.Asistencia_AS
{
    partial class Form1
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            pnlGrid = new AntdUI.Panel();
            dataGridView1 = new DataGridView();
            dgvReport = new DataGridView();
            pgrReport = new AntdProgressBar();
            pnlCardView = new AntdUI.Panel();
            lblCardView = new AntdUI.Label();
            chbShowReport = new AntdToggleButton();
            chbShowReportCalendar = new AntdToggleButton();
            lblSelectedDaysCaption = new AntdUI.Label();
            lblEmployeeAdvice = new Label();
            lblSelectedDays = new Label();
            pnlCardActions = new AntdUI.Panel();
            lblCardActions = new AntdUI.Label();
            btnModifyAttendance = new AntdUI.Button();
            btnExcel = new AntdUI.Button();
            lblLastDays = new AntdUI.Label();
            pnlLastDaysInput = new AntdUI.Panel();
            txbLastDays = new TextBox();
            label2 = new AntdUI.Label();
            cboAttendenceType = new AntdComboBox();
            lblSobrantesInfo = new AntdUI.Label();
            btnLoadReport = new AntdUI.Button();
            btnClearList = new AntdUI.Button();
            pnlCardDates = new AntdUI.Panel();
            lblCardDates = new AntdUI.Label();
            cboAgriculturalCycle = new AntdComboBox();
            cboSeason = new AntdComboBox();
            label5 = new AntdUI.Label();
            cboWeek1 = new AntdComboBox();
            label6 = new AntdUI.Label();
            cboWeek2 = new AntdComboBox();
            labelDate = new AntdUI.Label();
            dtpDate1 = new AntdDatePicker();
            labelDateTo = new AntdUI.Label();
            dtpDate2 = new AntdDatePicker();
            label4 = new AntdUI.Label();
            labelSeason = new AntdUI.Label();
            pnlCardEmployees = new AntdUI.Panel();
            pnlListEmployees = new AntdUI.Panel();
            dgvPruebasListado = new DataGridView();
            colListSel = new DataGridViewCheckBoxColumn();
            colListCodigo = new DataGridViewTextBoxColumn();
            colListNombre = new DataGridViewTextBoxColumn();
            colListEdad = new DataGridViewTextBoxColumn();
            colListNacimiento = new DataGridViewTextBoxColumn();
            colListEstado = new DataGridViewTextBoxColumn();
            colListCURP = new DataGridViewTextBoxColumn();
            colListNSS = new DataGridViewTextBoxColumn();
            colListRFC = new DataGridViewTextBoxColumn();
            colListRPatronal = new DataGridViewTextBoxColumn();
            colListPatron = new DataGridViewTextBoxColumn();
            colListLugarDePago = new DataGridViewTextBoxColumn();
            colListContratista = new DataGridViewTextBoxColumn();
            colListIngreso = new DataGridViewTextBoxColumn();
            colListReingreso = new DataGridViewTextBoxColumn();
            btnSearchEmployee = new AntdUI.Button();
            pnlEmployeeInput = new AntdUI.Panel();
            txbIdEmployee = new RichTextBox();
            btnAddEmployee = new AntdUI.Button();
            cboLP = new AntdMultiSelectComboBox();
            btnAddList = new AntdUI.Button();
            cboNomWorkGroup = new AntdMultiSelectComboBox();
            btnAddNomWorkGroup = new AntdUI.Button();
            label1 = new AntdUI.Label();
            lblCardEmployees = new AntdUI.Label();
            label3 = new AntdUI.Label();
            labelLP = new AntdUI.Label();
            pnlHeader = new AntdUI.Panel();
            lblTitle = new AntdUI.Label();
            btnOpenFrmAttendanceType = new AntdUI.Button();
            btnEmployeesMinExp = new AntdUI.Button();
            panel1 = new AntdUI.Panel();
            pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvReport).BeginInit();
            pnlCardView.SuspendLayout();
            pnlCardActions.SuspendLayout();
            pnlLastDaysInput.SuspendLayout();
            pnlCardDates.SuspendLayout();
            pnlCardEmployees.SuspendLayout();
            pnlListEmployees.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPruebasListado).BeginInit();
            pnlEmployeeInput.SuspendLayout();
            pnlHeader.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlGrid
            // 
            pnlGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlGrid.Back = Color.White;
            pnlGrid.BorderColor = Color.FromArgb(201, 184, 225);
            pnlGrid.BorderWidth = 1F;
            pnlGrid.Controls.Add(dataGridView1);
            pnlGrid.Controls.Add(dgvReport);
            pnlGrid.Location = new Point(12, 532);
            pnlGrid.Name = "pnlGrid";
            pnlGrid.Radius = 8;
            pnlGrid.Size = new Size(1209, 213);
            pnlGrid.TabIndex = 13;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(237, 228, 248);
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(48, 20, 78);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(237, 228, 248);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(48, 20, 78);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeight = 30;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(222, 206, 244);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = Color.FromArgb(214, 218, 230);
            dataGridView1.ImeMode = ImeMode.NoControl;
            dataGridView1.Location = new Point(11, 11);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(237, 228, 248);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(48, 20, 78);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(237, 228, 248);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(48, 20, 78);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1194, 198);
            dataGridView1.TabIndex = 1;
            // 
            // dgvReport
            // 
            dgvReport.AllowUserToAddRows = false;
            dgvReport.AllowUserToDeleteRows = false;
            dgvReport.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvReport.BackgroundColor = Color.White;
            dgvReport.BorderStyle = BorderStyle.None;
            dgvReport.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(237, 228, 248);
            dataGridViewCellStyle4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(48, 20, 78);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(237, 228, 248);
            dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(48, 20, 78);
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvReport.ColumnHeadersHeight = 30;
            dgvReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(222, 206, 244);
            dataGridViewCellStyle5.SelectionForeColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dgvReport.DefaultCellStyle = dataGridViewCellStyle5;
            dgvReport.EnableHeadersVisualStyles = false;
            dgvReport.GridColor = Color.FromArgb(214, 218, 230);
            dgvReport.ImeMode = ImeMode.NoControl;
            dgvReport.Location = new Point(3, 3);
            dgvReport.Name = "dgvReport";
            dgvReport.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(237, 228, 248);
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(48, 20, 78);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(237, 228, 248);
            dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(48, 20, 78);
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dgvReport.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dgvReport.RowHeadersVisible = false;
            dgvReport.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReport.Size = new Size(1146, 206);
            dgvReport.TabIndex = 0;
            // 
            // pgrReport
            // 
            pgrReport.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pgrReport.Location = new Point(12, 518);
            pgrReport.Maximum = 1000;
            pgrReport.Name = "pgrReport";
            pgrReport.Size = new Size(1209, 10);
            pgrReport.Style = ProgressBarStyle.Continuous;
            pgrReport.TabIndex = 12;
            // 
            // pnlCardView
            // 
            pnlCardView.Back = Color.White;
            pnlCardView.BorderColor = Color.FromArgb(228, 228, 238);
            pnlCardView.BorderWidth = 1F;
            pnlCardView.Controls.Add(lblCardView);
            pnlCardView.Controls.Add(chbShowReport);
            pnlCardView.Controls.Add(chbShowReportCalendar);
            pnlCardView.Location = new Point(12, 467);
            pnlCardView.Name = "pnlCardView";
            pnlCardView.Radius = 10;
            pnlCardView.Size = new Size(351, 45);
            pnlCardView.TabIndex = 11;
            // 
            // lblCardView
            // 
            lblCardView.BackColor = Color.Transparent;
            lblCardView.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblCardView.ForeColor = Color.FromArgb(30, 41, 59);
            lblCardView.Location = new Point(16, 8);
            lblCardView.Name = "lblCardView";
            lblCardView.Size = new Size(74, 28);
            lblCardView.TabIndex = 0;
            lblCardView.Text = "Visualizar";
            // 
            // chbShowReport
            // 
            chbShowReport.AutoToggle = true;
            chbShowReport.BackHover = Color.FromArgb(240, 230, 250);
            chbShowReport.BorderWidth = 1.5F;
            chbShowReport.Cursor = Cursors.Hand;
            chbShowReport.DefaultBack = Color.White;
            chbShowReport.DefaultBorderColor = Color.FromArgb(206, 212, 224);
            chbShowReport.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            chbShowReport.ForeColor = Color.FromArgb(122, 44, 166);
            chbShowReport.IconSize = new Size(16, 16);
            chbShowReport.IconSvg = resources.GetString("chbShowReport.IconSvg");
            chbShowReport.Location = new Point(96, 5);
            chbShowReport.Name = "chbShowReport";
            chbShowReport.Radius = 8;
            chbShowReport.Size = new Size(108, 36);
            chbShowReport.TabIndex = 2;
            chbShowReport.Text = "Reporte";
            chbShowReport.ToggleBack = Color.FromArgb(122, 44, 166);
            chbShowReport.ToggleBackActive = Color.FromArgb(98, 28, 138);
            chbShowReport.ToggleBackHover = Color.FromArgb(140, 66, 186);
            chbShowReport.ToggleFore = Color.White;
            chbShowReport.ToggleForeActive = Color.White;
            chbShowReport.ToggleForeHover = Color.White;
            chbShowReport.ToggleIconSvg = resources.GetString("chbShowReport.ToggleIconSvg");
            chbShowReport.ToggleText = "Reporte";
            chbShowReport.ToggleType = AntdUI.TTypeMini.Primary;
            // 
            // chbShowReportCalendar
            // 
            chbShowReportCalendar.AutoToggle = true;
            chbShowReportCalendar.BackHover = Color.FromArgb(240, 230, 250);
            chbShowReportCalendar.BorderWidth = 1.5F;
            chbShowReportCalendar.Cursor = Cursors.Hand;
            chbShowReportCalendar.DefaultBack = Color.White;
            chbShowReportCalendar.DefaultBorderColor = Color.FromArgb(206, 212, 224);
            chbShowReportCalendar.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            chbShowReportCalendar.ForeColor = Color.FromArgb(122, 44, 166);
            chbShowReportCalendar.IconSize = new Size(16, 16);
            chbShowReportCalendar.IconSvg = resources.GetString("chbShowReportCalendar.IconSvg");
            chbShowReportCalendar.Location = new Point(212, 5);
            chbShowReportCalendar.Name = "chbShowReportCalendar";
            chbShowReportCalendar.Radius = 8;
            chbShowReportCalendar.Size = new Size(124, 36);
            chbShowReportCalendar.TabIndex = 3;
            chbShowReportCalendar.Text = "Calendario";
            chbShowReportCalendar.ToggleBack = Color.FromArgb(122, 44, 166);
            chbShowReportCalendar.ToggleBackActive = Color.FromArgb(98, 28, 138);
            chbShowReportCalendar.ToggleBackHover = Color.FromArgb(140, 66, 186);
            chbShowReportCalendar.ToggleFore = Color.White;
            chbShowReportCalendar.ToggleForeActive = Color.White;
            chbShowReportCalendar.ToggleForeHover = Color.White;
            chbShowReportCalendar.ToggleIconSvg = resources.GetString("chbShowReportCalendar.ToggleIconSvg");
            chbShowReportCalendar.ToggleText = "Calendario";
            chbShowReportCalendar.ToggleType = AntdUI.TTypeMini.Primary;
            // 
            // lblSelectedDaysCaption
            // 
            lblSelectedDaysCaption.BackColor = Color.Transparent;
            lblSelectedDaysCaption.Font = new Font("Segoe UI", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblSelectedDaysCaption.ForeColor = Color.FromArgb(120, 130, 150);
            lblSelectedDaysCaption.Location = new Point(315, 10);
            lblSelectedDaysCaption.Name = "lblSelectedDaysCaption";
            lblSelectedDaysCaption.Size = new Size(129, 26);
            lblSelectedDaysCaption.TabIndex = 4;
            lblSelectedDaysCaption.Text = "Días seleccionados:";
            // 
            // lblEmployeeAdvice
            // 
            lblEmployeeAdvice.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblEmployeeAdvice.BackColor = Color.Transparent;
            lblEmployeeAdvice.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblEmployeeAdvice.ForeColor = Color.Gray;
            lblEmployeeAdvice.Location = new Point(4, 6);
            lblEmployeeAdvice.Name = "lblEmployeeAdvice";
            lblEmployeeAdvice.Size = new Size(343, 35);
            lblEmployeeAdvice.TabIndex = 5;
            lblEmployeeAdvice.Text = "lblEmployeeAdvice";
            // 
            // lblSelectedDays
            // 
            lblSelectedDays.BackColor = Color.Transparent;
            lblSelectedDays.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblSelectedDays.ForeColor = Color.FromArgb(120, 130, 150);
            lblSelectedDays.Location = new Point(445, 9);
            lblSelectedDays.Margin = new Padding(0);
            lblSelectedDays.Name = "lblSelectedDays";
            lblSelectedDays.Size = new Size(52, 26);
            lblSelectedDays.TabIndex = 5;
            lblSelectedDays.Text = "0";
            lblSelectedDays.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlCardActions
            // 
            pnlCardActions.Back = Color.White;
            pnlCardActions.BorderColor = Color.FromArgb(228, 228, 238);
            pnlCardActions.BorderWidth = 1F;
            pnlCardActions.Controls.Add(lblCardActions);
            pnlCardActions.Controls.Add(btnModifyAttendance);
            pnlCardActions.Controls.Add(btnExcel);
            pnlCardActions.Controls.Add(lblSelectedDaysCaption);
            pnlCardActions.Controls.Add(lblSelectedDays);
            pnlCardActions.Location = new Point(369, 467);
            pnlCardActions.Name = "pnlCardActions";
            pnlCardActions.Radius = 10;
            pnlCardActions.Size = new Size(497, 45);
            pnlCardActions.TabIndex = 10;
            // 
            // lblCardActions
            // 
            lblCardActions.BackColor = Color.Transparent;
            lblCardActions.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblCardActions.ForeColor = Color.FromArgb(30, 41, 59);
            lblCardActions.Location = new Point(16, 8);
            lblCardActions.Name = "lblCardActions";
            lblCardActions.Size = new Size(74, 28);
            lblCardActions.TabIndex = 0;
            lblCardActions.Text = "Acciones";
            // 
            // btnModifyAttendance
            // 
            btnModifyAttendance.BackActive = Color.FromArgb(225, 210, 245);
            btnModifyAttendance.BackHover = Color.FromArgb(240, 230, 250);
            btnModifyAttendance.BorderWidth = 1.5F;
            btnModifyAttendance.Cursor = Cursors.Hand;
            btnModifyAttendance.DefaultBack = Color.White;
            btnModifyAttendance.DefaultBorderColor = Color.FromArgb(122, 44, 166);
            btnModifyAttendance.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnModifyAttendance.ForeColor = Color.FromArgb(122, 44, 166);
            btnModifyAttendance.IconSize = new Size(16, 16);
            btnModifyAttendance.IconSvg = resources.GetString("btnModifyAttendance.IconSvg");
            btnModifyAttendance.Location = new Point(93, 5);
            btnModifyAttendance.Name = "btnModifyAttendance";
            btnModifyAttendance.Radius = 8;
            btnModifyAttendance.Size = new Size(116, 36);
            btnModifyAttendance.TabIndex = 3;
            btnModifyAttendance.Text = "Modificar";
            // 
            // btnExcel
            // 
            btnExcel.BackActive = Color.FromArgb(225, 210, 245);
            btnExcel.BackHover = Color.FromArgb(240, 230, 250);
            btnExcel.BorderWidth = 1.5F;
            btnExcel.Cursor = Cursors.Hand;
            btnExcel.DefaultBack = Color.White;
            btnExcel.DefaultBorderColor = Color.FromArgb(122, 44, 166);
            btnExcel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnExcel.ForeColor = Color.FromArgb(122, 44, 166);
            btnExcel.IconSize = new Size(16, 16);
            btnExcel.IconSvg = resources.GetString("btnExcel.IconSvg");
            btnExcel.Location = new Point(210, 5);
            btnExcel.Name = "btnExcel";
            btnExcel.Radius = 8;
            btnExcel.Size = new Size(88, 36);
            btnExcel.TabIndex = 4;
            btnExcel.Text = "Excel";
            // 
            // lblLastDays
            // 
            lblLastDays.BackColor = Color.Transparent;
            lblLastDays.Font = new Font("Segoe UI", 9.5F);
            lblLastDays.ForeColor = Color.FromArgb(51, 65, 85);
            lblLastDays.Location = new Point(736, 7);
            lblLastDays.Name = "lblLastDays";
            lblLastDays.Size = new Size(82, 28);
            lblLastDays.TabIndex = 5;
            lblLastDays.Text = "Últimos días:";
            // 
            // pnlLastDaysInput
            // 
            pnlLastDaysInput.Back = Color.White;
            pnlLastDaysInput.BackColor = Color.Transparent;
            pnlLastDaysInput.BorderColor = Color.FromArgb(206, 212, 224);
            pnlLastDaysInput.BorderWidth = 1F;
            pnlLastDaysInput.Controls.Add(txbLastDays);
            pnlLastDaysInput.Location = new Point(680, 6);
            pnlLastDaysInput.Name = "pnlLastDaysInput";
            pnlLastDaysInput.Radius = 8;
            pnlLastDaysInput.Size = new Size(54, 30);
            pnlLastDaysInput.TabIndex = 6;
            // 
            // txbLastDays
            // 
            txbLastDays.BackColor = Color.White;
            txbLastDays.BorderStyle = BorderStyle.None;
            txbLastDays.Font = new Font("Segoe UI", 10F);
            txbLastDays.Location = new Point(6, 5);
            txbLastDays.MaxLength = 4;
            txbLastDays.Name = "txbLastDays";
            txbLastDays.Size = new Size(40, 18);
            txbLastDays.TabIndex = 0;
            txbLastDays.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 9.5F);
            label2.ForeColor = Color.FromArgb(51, 65, 85);
            label2.Location = new Point(850, 9);
            label2.Name = "label2";
            label2.Size = new Size(146, 28);
            label2.TabIndex = 7;
            label2.Text = "Inasistencia por defecto:";
            // 
            // cboAttendenceType
            // 
            cboAttendenceType.BackColor = Color.White;
            cboAttendenceType.BorderColorActive = Color.FromArgb(122, 44, 166);
            cboAttendenceType.BorderColorNormal = Color.FromArgb(206, 212, 224);
            cboAttendenceType.CornerRadius = 6;
            cboAttendenceType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboAttendenceType.Enabled = false;
            cboAttendenceType.Font = new Font("Segoe UI", 10F);
            cboAttendenceType.FormattingEnabled = true;
            cboAttendenceType.Location = new Point(1000, 10);
            cboAttendenceType.Margin = new Padding(0, 3, 3, 3);
            cboAttendenceType.Name = "cboAttendenceType";
            cboAttendenceType.OuterColor = Color.White;
            cboAttendenceType.Size = new Size(168, 25);
            cboAttendenceType.TabIndex = 8;
            // 
            // lblSobrantesInfo
            // 
            lblSobrantesInfo.BackColor = Color.Transparent;
            lblSobrantesInfo.Font = new Font("Segoe UI", 8.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblSobrantesInfo.ForeColor = Color.FromArgb(120, 130, 150);
            lblSobrantesInfo.Location = new Point(680, 42);
            lblSobrantesInfo.Name = "lblSobrantesInfo";
            lblSobrantesInfo.Size = new Size(242, 31);
            lblSobrantesInfo.TabIndex = 9;
            lblSobrantesInfo.Text = "ℹ Sin listado: indica Últimos días (empleados con importe). Vacío = sin ese límite";
            // 
            // btnLoadReport
            // 
            btnLoadReport.BackActive = Color.FromArgb(98, 28, 138);
            btnLoadReport.BackColor = Color.FromArgb(122, 44, 166);
            btnLoadReport.BackHover = Color.FromArgb(140, 66, 186);
            btnLoadReport.Cursor = Cursors.Hand;
            btnLoadReport.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnLoadReport.ForeColor = Color.White;
            btnLoadReport.IconSize = new Size(16, 16);
            btnLoadReport.IconSvg = "<svg viewBox=\"0 0 24 24\" xmlns=\"http://www.w3.org/2000/svg\"><path d=\"M8 5v14l11-7z\"/></svg>";
            btnLoadReport.Location = new Point(556, 68);
            btnLoadReport.Name = "btnLoadReport";
            btnLoadReport.Radius = 8;
            btnLoadReport.Size = new Size(98, 36);
            btnLoadReport.TabIndex = 1;
            btnLoadReport.Text = "Cargar";
            btnLoadReport.Type = AntdUI.TTypeMini.Primary;
            // 
            // btnClearList
            // 
            btnClearList.BackActive = Color.FromArgb(225, 210, 245);
            btnClearList.BackHover = Color.FromArgb(240, 230, 250);
            btnClearList.BorderWidth = 1.5F;
            btnClearList.Cursor = Cursors.Hand;
            btnClearList.DefaultBack = Color.White;
            btnClearList.DefaultBorderColor = Color.FromArgb(122, 44, 166);
            btnClearList.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnClearList.ForeColor = Color.FromArgb(122, 44, 166);
            btnClearList.IconSize = new Size(16, 16);
            btnClearList.IconSvg = "<svg viewBox=\"0 0 24 24\" xmlns=\"http://www.w3.org/2000/svg\"><path d=\"M15 16h4v2h-4zm0-8h7v2h-7zm0 4h6v2h-6zM3 18c0 1.1.9 2 2 2h6c1.1 0 2-.9 2-2V8H3v10zM14 5h-3l-1-1H6L5 5H2v2h12z\"/></svg>";
            btnClearList.Location = new Point(32, 22);
            btnClearList.Name = "btnClearList";
            btnClearList.Radius = 8;
            btnClearList.Size = new Size(98, 36);
            btnClearList.TabIndex = 2;
            btnClearList.Text = "Limpiar";
            // 
            // pnlCardDates
            // 
            pnlCardDates.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlCardDates.Back = Color.White;
            pnlCardDates.BorderColor = Color.FromArgb(228, 228, 238);
            pnlCardDates.BorderWidth = 1F;
            pnlCardDates.Controls.Add(lblCardDates);
            pnlCardDates.Controls.Add(btnLoadReport);
            pnlCardDates.Controls.Add(cboAgriculturalCycle);
            pnlCardDates.Controls.Add(cboSeason);
            pnlCardDates.Controls.Add(label2);
            pnlCardDates.Controls.Add(cboAttendenceType);
            pnlCardDates.Controls.Add(label5);
            pnlCardDates.Controls.Add(pnlLastDaysInput);
            pnlCardDates.Controls.Add(cboWeek1);
            pnlCardDates.Controls.Add(lblSobrantesInfo);
            pnlCardDates.Controls.Add(label6);
            pnlCardDates.Controls.Add(cboWeek2);
            pnlCardDates.Controls.Add(labelDate);
            pnlCardDates.Controls.Add(dtpDate1);
            pnlCardDates.Controls.Add(labelDateTo);
            pnlCardDates.Controls.Add(dtpDate2);
            pnlCardDates.Controls.Add(label4);
            pnlCardDates.Controls.Add(labelSeason);
            pnlCardDates.Controls.Add(lblLastDays);
            pnlCardDates.Location = new Point(12, 349);
            pnlCardDates.Name = "pnlCardDates";
            pnlCardDates.Radius = 10;
            pnlCardDates.Size = new Size(1208, 112);
            pnlCardDates.TabIndex = 9;
            // 
            // lblCardDates
            // 
            lblCardDates.BackColor = Color.Transparent;
            lblCardDates.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblCardDates.ForeColor = Color.FromArgb(30, 41, 59);
            lblCardDates.Location = new Point(11, 4);
            lblCardDates.Name = "lblCardDates";
            lblCardDates.Size = new Size(126, 28);
            lblCardDates.TabIndex = 0;
            lblCardDates.Text = "Rango de fechas";
            // 
            // cboAgriculturalCycle
            // 
            cboAgriculturalCycle.BackColor = Color.White;
            cboAgriculturalCycle.BorderColorActive = Color.FromArgb(122, 44, 166);
            cboAgriculturalCycle.BorderColorNormal = Color.FromArgb(206, 212, 224);
            cboAgriculturalCycle.CornerRadius = 6;
            cboAgriculturalCycle.DropDownStyle = ComboBoxStyle.DropDownList;
            cboAgriculturalCycle.Font = new Font("Segoe UI", 10F);
            cboAgriculturalCycle.FormattingEnabled = true;
            cboAgriculturalCycle.Location = new Point(229, 9);
            cboAgriculturalCycle.Margin = new Padding(0, 3, 3, 3);
            cboAgriculturalCycle.Name = "cboAgriculturalCycle";
            cboAgriculturalCycle.OuterColor = Color.White;
            cboAgriculturalCycle.Size = new Size(122, 25);
            cboAgriculturalCycle.TabIndex = 2;
            // 
            // cboSeason
            // 
            cboSeason.BackColor = Color.White;
            cboSeason.BorderColorActive = Color.FromArgb(122, 44, 166);
            cboSeason.BorderColorNormal = Color.FromArgb(206, 212, 224);
            cboSeason.CornerRadius = 6;
            cboSeason.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSeason.Font = new Font("Segoe UI", 10F);
            cboSeason.FormattingEnabled = true;
            cboSeason.Location = new Point(510, 9);
            cboSeason.Margin = new Padding(0, 3, 3, 3);
            cboSeason.Name = "cboSeason";
            cboSeason.OuterColor = Color.White;
            cboSeason.Size = new Size(141, 25);
            cboSeason.TabIndex = 4;
            // 
            // label5
            // 
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 9.5F);
            label5.ForeColor = Color.FromArgb(51, 65, 85);
            label5.Location = new Point(171, 41);
            label5.Name = "label5";
            label5.Size = new Size(52, 28);
            label5.TabIndex = 5;
            label5.Text = "Semana";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cboWeek1
            // 
            cboWeek1.BackColor = Color.White;
            cboWeek1.BorderColorActive = Color.FromArgb(122, 44, 166);
            cboWeek1.BorderColorNormal = Color.FromArgb(206, 212, 224);
            cboWeek1.CornerRadius = 6;
            cboWeek1.Font = new Font("Segoe UI", 10F);
            cboWeek1.FormattingEnabled = true;
            cboWeek1.Location = new Point(229, 43);
            cboWeek1.Margin = new Padding(0, 3, 3, 3);
            cboWeek1.Name = "cboWeek1";
            cboWeek1.OuterColor = Color.White;
            cboWeek1.Size = new Size(80, 25);
            cboWeek1.TabIndex = 6;
            // 
            // label6
            // 
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 9.5F);
            label6.ForeColor = Color.FromArgb(51, 65, 85);
            label6.Location = new Point(317, 41);
            label6.Name = "label6";
            label6.Size = new Size(16, 28);
            label6.TabIndex = 7;
            label6.Text = "a";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cboWeek2
            // 
            cboWeek2.BackColor = Color.White;
            cboWeek2.BorderColorActive = Color.FromArgb(122, 44, 166);
            cboWeek2.BorderColorNormal = Color.FromArgb(206, 212, 224);
            cboWeek2.CornerRadius = 6;
            cboWeek2.Font = new Font("Segoe UI", 10F);
            cboWeek2.FormattingEnabled = true;
            cboWeek2.Location = new Point(341, 43);
            cboWeek2.Margin = new Padding(0, 3, 3, 3);
            cboWeek2.Name = "cboWeek2";
            cboWeek2.OuterColor = Color.White;
            cboWeek2.Size = new Size(80, 25);
            cboWeek2.TabIndex = 8;
            // 
            // labelDate
            // 
            labelDate.BackColor = Color.Transparent;
            labelDate.Font = new Font("Segoe UI", 9.5F);
            labelDate.ForeColor = Color.FromArgb(51, 65, 85);
            labelDate.Location = new Point(171, 73);
            labelDate.Name = "labelDate";
            labelDate.Size = new Size(52, 28);
            labelDate.TabIndex = 9;
            labelDate.Text = "Rango";
            labelDate.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dtpDate1
            // 
            dtpDate1.BorderActive = Color.FromArgb(122, 44, 166);
            dtpDate1.BorderColor = Color.FromArgb(206, 212, 224);
            dtpDate1.BorderHover = Color.FromArgb(140, 66, 186);
            dtpDate1.Font = new Font("Segoe UI", 10F);
            dtpDate1.Format = "dd/MM/yyyy";
            dtpDate1.Location = new Point(225, 70);
            dtpDate1.Name = "dtpDate1";
            dtpDate1.Size = new Size(146, 34);
            dtpDate1.TabIndex = 10;
            // 
            // labelDateTo
            // 
            labelDateTo.BackColor = Color.Transparent;
            labelDateTo.Font = new Font("Segoe UI", 9.5F);
            labelDateTo.ForeColor = Color.FromArgb(51, 65, 85);
            labelDateTo.Location = new Point(377, 73);
            labelDateTo.Name = "labelDateTo";
            labelDateTo.Size = new Size(16, 28);
            labelDateTo.TabIndex = 11;
            labelDateTo.Text = "a";
            labelDateTo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dtpDate2
            // 
            dtpDate2.BorderActive = Color.FromArgb(122, 44, 166);
            dtpDate2.BorderColor = Color.FromArgb(206, 212, 224);
            dtpDate2.BorderHover = Color.FromArgb(140, 66, 186);
            dtpDate2.Font = new Font("Segoe UI", 10F);
            dtpDate2.Format = "dd/MM/yyyy";
            dtpDate2.Location = new Point(399, 70);
            dtpDate2.Name = "dtpDate2";
            dtpDate2.Size = new Size(146, 34);
            dtpDate2.TabIndex = 12;
            // 
            // label4
            // 
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 9.5F);
            label4.ForeColor = Color.FromArgb(51, 65, 85);
            label4.Location = new Point(180, 7);
            label4.Name = "label4";
            label4.Size = new Size(43, 28);
            label4.TabIndex = 1;
            label4.Text = "Ciclo";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelSeason
            // 
            labelSeason.BackColor = Color.Transparent;
            labelSeason.Font = new Font("Segoe UI", 9.5F);
            labelSeason.ForeColor = Color.FromArgb(51, 65, 85);
            labelSeason.Location = new Point(437, 7);
            labelSeason.Name = "labelSeason";
            labelSeason.Size = new Size(80, 28);
            labelSeason.TabIndex = 3;
            labelSeason.Text = "Temporada:";
            // 
            // pnlCardEmployees
            // 
            pnlCardEmployees.Back = Color.White;
            pnlCardEmployees.BorderColor = Color.FromArgb(228, 228, 238);
            pnlCardEmployees.BorderWidth = 1F;
            pnlCardEmployees.Controls.Add(pnlListEmployees);
            pnlCardEmployees.Controls.Add(btnSearchEmployee);
            pnlCardEmployees.Controls.Add(btnClearList);
            pnlCardEmployees.Controls.Add(pnlEmployeeInput);
            pnlCardEmployees.Controls.Add(btnAddEmployee);
            pnlCardEmployees.Controls.Add(cboLP);
            pnlCardEmployees.Controls.Add(btnAddList);
            pnlCardEmployees.Controls.Add(cboNomWorkGroup);
            pnlCardEmployees.Controls.Add(btnAddNomWorkGroup);
            pnlCardEmployees.Controls.Add(label1);
            pnlCardEmployees.Controls.Add(lblCardEmployees);
            pnlCardEmployees.Controls.Add(label3);
            pnlCardEmployees.Controls.Add(labelLP);
            pnlCardEmployees.Location = new Point(12, 60);
            pnlCardEmployees.Name = "pnlCardEmployees";
            pnlCardEmployees.Radius = 10;
            pnlCardEmployees.Size = new Size(1208, 283);
            pnlCardEmployees.TabIndex = 8;
            // 
            // pnlListEmployees
            // 
            pnlListEmployees.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlListEmployees.Back = Color.White;
            pnlListEmployees.BorderColor = Color.FromArgb(201, 184, 225);
            pnlListEmployees.BorderWidth = 1F;
            pnlListEmployees.Controls.Add(dgvPruebasListado);
            pnlListEmployees.Location = new Point(7, 61);
            pnlListEmployees.Name = "pnlListEmployees";
            pnlListEmployees.Radius = 8;
            pnlListEmployees.Size = new Size(1197, 214);
            pnlListEmployees.TabIndex = 14;
            // 
            // dgvPruebasListado
            // 
            dgvPruebasListado.AllowUserToAddRows = false;
            dgvPruebasListado.AllowUserToDeleteRows = false;
            dgvPruebasListado.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPruebasListado.BackgroundColor = Color.White;
            dgvPruebasListado.BorderStyle = BorderStyle.None;
            dgvPruebasListado.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = Color.FromArgb(237, 228, 248);
            dataGridViewCellStyle7.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dataGridViewCellStyle7.ForeColor = Color.FromArgb(48, 20, 78);
            dataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(237, 228, 248);
            dataGridViewCellStyle7.SelectionForeColor = Color.FromArgb(48, 20, 78);
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dgvPruebasListado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dgvPruebasListado.ColumnHeadersHeight = 30;
            dgvPruebasListado.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvPruebasListado.Columns.AddRange(new DataGridViewColumn[] { colListSel, colListCodigo, colListNombre, colListEdad, colListNacimiento, colListEstado, colListCURP, colListNSS, colListRFC, colListRPatronal, colListPatron, colListLugarDePago, colListContratista, colListIngreso, colListReingreso });
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.White;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle8.ForeColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(222, 206, 244);
            dataGridViewCellStyle8.SelectionForeColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            dgvPruebasListado.DefaultCellStyle = dataGridViewCellStyle8;
            dgvPruebasListado.EnableHeadersVisualStyles = false;
            dgvPruebasListado.GridColor = Color.FromArgb(214, 218, 230);
            dgvPruebasListado.ImeMode = ImeMode.NoControl;
            dgvPruebasListado.Location = new Point(4, 4);
            dgvPruebasListado.Name = "dgvPruebasListado";
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = Color.FromArgb(237, 228, 248);
            dataGridViewCellStyle9.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle9.ForeColor = Color.FromArgb(48, 20, 78);
            dataGridViewCellStyle9.SelectionBackColor = Color.FromArgb(237, 228, 248);
            dataGridViewCellStyle9.SelectionForeColor = Color.FromArgb(48, 20, 78);
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
            dgvPruebasListado.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dgvPruebasListado.RowHeadersVisible = false;
            dgvPruebasListado.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvPruebasListado.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPruebasListado.Size = new Size(1189, 206);
            dgvPruebasListado.TabIndex = 1;
            // 
            // colListSel
            // 
            colListSel.FalseValue = "0";
            colListSel.HeaderText = "Sel.";
            colListSel.Name = "colListSel";
            colListSel.TrueValue = "1";
            colListSel.Width = 36;
            // 
            // colListCodigo
            // 
            colListCodigo.HeaderText = "Código";
            colListCodigo.Name = "colListCodigo";
            colListCodigo.ReadOnly = true;
            colListCodigo.Width = 70;
            // 
            // colListNombre
            // 
            colListNombre.HeaderText = "Nombre";
            colListNombre.Name = "colListNombre";
            colListNombre.ReadOnly = true;
            colListNombre.Width = 260;
            // 
            // colListEdad
            // 
            colListEdad.HeaderText = "Edad";
            colListEdad.Name = "colListEdad";
            colListEdad.ReadOnly = true;
            colListEdad.Width = 45;
            // 
            // colListNacimiento
            // 
            colListNacimiento.HeaderText = "Nacimiento";
            colListNacimiento.Name = "colListNacimiento";
            colListNacimiento.ReadOnly = true;
            colListNacimiento.Width = 90;
            // 
            // colListEstado
            // 
            colListEstado.HeaderText = "Estado";
            colListEstado.Name = "colListEstado";
            colListEstado.ReadOnly = true;
            colListEstado.Width = 130;
            // 
            // colListCURP
            // 
            colListCURP.HeaderText = "CURP";
            colListCURP.Name = "colListCURP";
            colListCURP.ReadOnly = true;
            colListCURP.Width = 170;
            // 
            // colListNSS
            // 
            colListNSS.HeaderText = "NSS";
            colListNSS.Name = "colListNSS";
            colListNSS.ReadOnly = true;
            // 
            // colListRFC
            // 
            colListRFC.HeaderText = "RFC";
            colListRFC.Name = "colListRFC";
            colListRFC.ReadOnly = true;
            colListRFC.Width = 120;
            // 
            // colListRPatronal
            // 
            colListRPatronal.HeaderText = "RPatronal";
            colListRPatronal.Name = "colListRPatronal";
            colListRPatronal.ReadOnly = true;
            // 
            // colListPatron
            // 
            colListPatron.HeaderText = "Patron";
            colListPatron.Name = "colListPatron";
            colListPatron.ReadOnly = true;
            colListPatron.Width = 260;
            // 
            // colListLugarDePago
            // 
            colListLugarDePago.HeaderText = "LugarDePago";
            colListLugarDePago.Name = "colListLugarDePago";
            colListLugarDePago.ReadOnly = true;
            colListLugarDePago.Width = 120;
            // 
            // colListContratista
            // 
            colListContratista.HeaderText = "Contratista";
            colListContratista.Name = "colListContratista";
            colListContratista.ReadOnly = true;
            colListContratista.Width = 90;
            // 
            // colListIngreso
            // 
            colListIngreso.HeaderText = "Ingreso";
            colListIngreso.Name = "colListIngreso";
            colListIngreso.ReadOnly = true;
            colListIngreso.Width = 80;
            // 
            // colListReingreso
            // 
            colListReingreso.HeaderText = "Reingreso";
            colListReingreso.Name = "colListReingreso";
            colListReingreso.ReadOnly = true;
            colListReingreso.Width = 80;
            // 
            // btnSearchEmployee
            // 
            btnSearchEmployee.BorderWidth = 1F;
            btnSearchEmployee.Cursor = Cursors.Hand;
            btnSearchEmployee.DefaultBack = Color.White;
            btnSearchEmployee.DefaultBorderColor = Color.FromArgb(206, 212, 224);
            btnSearchEmployee.ForeColor = Color.FromArgb(122, 44, 166);
            btnSearchEmployee.IconSize = new Size(18, 18);
            btnSearchEmployee.IconSvg = resources.GetString("btnSearchEmployee.IconSvg");
            btnSearchEmployee.Location = new Point(195, 24);
            btnSearchEmployee.Name = "btnSearchEmployee";
            btnSearchEmployee.Radius = 8;
            btnSearchEmployee.Size = new Size(34, 34);
            btnSearchEmployee.TabIndex = 2;
            // 
            // pnlEmployeeInput
            // 
            pnlEmployeeInput.Back = Color.White;
            pnlEmployeeInput.BackColor = Color.Transparent;
            pnlEmployeeInput.BorderColor = Color.FromArgb(206, 212, 224);
            pnlEmployeeInput.BorderWidth = 1F;
            pnlEmployeeInput.Controls.Add(txbIdEmployee);
            pnlEmployeeInput.Location = new Point(229, 27);
            pnlEmployeeInput.Name = "pnlEmployeeInput";
            pnlEmployeeInput.Radius = 8;
            pnlEmployeeInput.Size = new Size(248, 28);
            pnlEmployeeInput.TabIndex = 3;
            // 
            // txbIdEmployee
            // 
            txbIdEmployee.BackColor = Color.White;
            txbIdEmployee.BorderStyle = BorderStyle.None;
            txbIdEmployee.Font = new Font("Segoe UI", 10F);
            txbIdEmployee.Location = new Point(9, 4);
            txbIdEmployee.Name = "txbIdEmployee";
            txbIdEmployee.ScrollBars = RichTextBoxScrollBars.Vertical;
            txbIdEmployee.Size = new Size(230, 20);
            txbIdEmployee.TabIndex = 0;
            txbIdEmployee.Text = "";
            // 
            // btnAddEmployee
            // 
            btnAddEmployee.Cursor = Cursors.Hand;
            btnAddEmployee.DefaultBack = Color.FromArgb(240, 230, 250);
            btnAddEmployee.ForeColor = Color.FromArgb(122, 44, 166);
            btnAddEmployee.IconSize = new Size(18, 18);
            btnAddEmployee.IconSvg = "<svg viewBox=\"0 0 24 24\" xmlns=\"http://www.w3.org/2000/svg\"><path d=\"M19 13h-6v6h-2v-6H5v-2h6V5h2v6h6v2z\"/></svg>";
            btnAddEmployee.Location = new Point(478, 24);
            btnAddEmployee.Name = "btnAddEmployee";
            btnAddEmployee.Radius = 8;
            btnAddEmployee.Size = new Size(34, 34);
            btnAddEmployee.TabIndex = 4;
            // 
            // cboLP
            // 
            cboLP.BackColor = Color.White;
            cboLP.BorderColorActive = Color.FromArgb(122, 44, 166);
            cboLP.BorderColorNormal = Color.FromArgb(206, 212, 224);
            cboLP.CornerRadius = 6;
            cboLP.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLP.Font = new Font("Segoe UI", 10F);
            cboLP.FormattingEnabled = true;
            cboLP.Location = new Point(530, 29);
            cboLP.Margin = new Padding(0, 3, 3, 3);
            cboLP.Name = "cboLP";
            cboLP.OuterColor = Color.White;
            cboLP.SearchPlaceholder = "Buscar";
            cboLP.Size = new Size(288, 25);
            cboLP.TabIndex = 7;
            // 
            // btnAddList
            // 
            btnAddList.Cursor = Cursors.Hand;
            btnAddList.DefaultBack = Color.FromArgb(240, 230, 250);
            btnAddList.ForeColor = Color.FromArgb(122, 44, 166);
            btnAddList.IconSize = new Size(18, 18);
            btnAddList.IconSvg = "<svg viewBox=\"0 0 24 24\" xmlns=\"http://www.w3.org/2000/svg\"><path d=\"M19 13h-6v6h-2v-6H5v-2h6V5h2v6h6v2z\"/></svg>";
            btnAddList.Location = new Point(820, 24);
            btnAddList.Name = "btnAddList";
            btnAddList.Radius = 8;
            btnAddList.Size = new Size(34, 34);
            btnAddList.TabIndex = 8;
            // 
            // cboNomWorkGroup
            // 
            cboNomWorkGroup.BackColor = Color.White;
            cboNomWorkGroup.BorderColorActive = Color.FromArgb(122, 44, 166);
            cboNomWorkGroup.BorderColorNormal = Color.FromArgb(206, 212, 224);
            cboNomWorkGroup.CornerRadius = 6;
            cboNomWorkGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNomWorkGroup.Font = new Font("Segoe UI", 10F);
            cboNomWorkGroup.FormattingEnabled = true;
            cboNomWorkGroup.Location = new Point(872, 29);
            cboNomWorkGroup.Margin = new Padding(0, 3, 3, 3);
            cboNomWorkGroup.Name = "cboNomWorkGroup";
            cboNomWorkGroup.OuterColor = Color.White;
            cboNomWorkGroup.SearchPlaceholder = "Buscar";
            cboNomWorkGroup.Size = new Size(288, 25);
            cboNomWorkGroup.TabIndex = 10;
            // 
            // btnAddNomWorkGroup
            // 
            btnAddNomWorkGroup.Cursor = Cursors.Hand;
            btnAddNomWorkGroup.DefaultBack = Color.FromArgb(240, 230, 250);
            btnAddNomWorkGroup.ForeColor = Color.FromArgb(122, 44, 166);
            btnAddNomWorkGroup.IconSize = new Size(18, 18);
            btnAddNomWorkGroup.IconSvg = "<svg viewBox=\"0 0 24 24\" xmlns=\"http://www.w3.org/2000/svg\"><path d=\"M19 13h-6v6h-2v-6H5v-2h6V5h2v6h6v2z\"/></svg>";
            btnAddNomWorkGroup.Location = new Point(1162, 24);
            btnAddNomWorkGroup.Name = "btnAddNomWorkGroup";
            btnAddNomWorkGroup.Radius = 8;
            btnAddNomWorkGroup.Size = new Size(34, 34);
            btnAddNomWorkGroup.TabIndex = 11;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 9.5F);
            label1.ForeColor = Color.FromArgb(51, 65, 85);
            label1.Location = new Point(201, 3);
            label1.Name = "label1";
            label1.Size = new Size(92, 28);
            label1.TabIndex = 1;
            label1.Text = "Empleado(s)";
            // 
            // lblCardEmployees
            // 
            lblCardEmployees.BackColor = Color.Transparent;
            lblCardEmployees.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblCardEmployees.ForeColor = Color.FromArgb(30, 41, 59);
            lblCardEmployees.Location = new Point(7, -1);
            lblCardEmployees.Name = "lblCardEmployees";
            lblCardEmployees.Size = new Size(168, 28);
            lblCardEmployees.TabIndex = 0;
            lblCardEmployees.Text = "Seleccionar empleados";
            // 
            // label3
            // 
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 9.5F);
            label3.ForeColor = Color.FromArgb(51, 65, 85);
            label3.Location = new Point(872, 5);
            label3.Name = "label3";
            label3.Size = new Size(92, 28);
            label3.TabIndex = 9;
            label3.Text = "Cuadrilla";
            // 
            // labelLP
            // 
            labelLP.BackColor = Color.Transparent;
            labelLP.Font = new Font("Segoe UI", 9.5F);
            labelLP.ForeColor = Color.FromArgb(51, 65, 85);
            labelLP.Location = new Point(530, 5);
            labelLP.Name = "labelLP";
            labelLP.Size = new Size(92, 28);
            labelLP.TabIndex = 6;
            labelLP.Text = "Lugar de pago";
            // 
            // pnlHeader
            // 
            pnlHeader.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlHeader.Back = Color.FromArgb(122, 44, 166);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(btnOpenFrmAttendanceType);
            pnlHeader.Location = new Point(12, 12);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Radius = 8;
            pnlHeader.Size = new Size(1209, 40);
            pnlHeader.TabIndex = 7;
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 12.5F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(14, 5);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(206, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Tag = "lotData";
            lblTitle.Text = "Reporte de asistencias";
            // 
            // btnOpenFrmAttendanceType
            // 
            btnOpenFrmAttendanceType.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnOpenFrmAttendanceType.Cursor = Cursors.Hand;
            btnOpenFrmAttendanceType.DefaultBack = Color.White;
            btnOpenFrmAttendanceType.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnOpenFrmAttendanceType.ForeColor = Color.FromArgb(122, 44, 166);
            btnOpenFrmAttendanceType.IconSize = new Size(15, 15);
            btnOpenFrmAttendanceType.IconSvg = resources.GetString("btnOpenFrmAttendanceType.IconSvg");
            btnOpenFrmAttendanceType.Location = new Point(1940, 5);
            btnOpenFrmAttendanceType.Name = "btnOpenFrmAttendanceType";
            btnOpenFrmAttendanceType.Radius = 8;
            btnOpenFrmAttendanceType.Size = new Size(168, 30);
            btnOpenFrmAttendanceType.TabIndex = 1;
            btnOpenFrmAttendanceType.Text = "Tipo de asistencia";
            // 
            // btnEmployeesMinExp
            // 
            btnEmployeesMinExp.Cursor = Cursors.Hand;
            btnEmployeesMinExp.DefaultBack = Color.FromArgb(240, 230, 250);
            btnEmployeesMinExp.ForeColor = Color.FromArgb(122, 44, 166);
            btnEmployeesMinExp.IconPosition = AntdUI.TAlignMini.None;
            btnEmployeesMinExp.IconSize = new Size(18, 18);
            btnEmployeesMinExp.IconSvg = "";
            btnEmployeesMinExp.Location = new Point(1, 83);
            btnEmployeesMinExp.Name = "btnEmployeesMinExp";
            btnEmployeesMinExp.Radius = 15;
            btnEmployeesMinExp.Size = new Size(34, 34);
            btnEmployeesMinExp.TabIndex = 15;
            btnEmployeesMinExp.Text = "V";
            btnEmployeesMinExp.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Back = Color.White;
            panel1.BorderColor = Color.FromArgb(228, 228, 238);
            panel1.BorderWidth = 1F;
            panel1.Controls.Add(lblEmployeeAdvice);
            panel1.Location = new Point(869, 467);
            panel1.Name = "panel1";
            panel1.Radius = 10;
            panel1.Size = new Size(351, 45);
            panel1.TabIndex = 11;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1233, 757);
            Controls.Add(panel1);
            Controls.Add(btnEmployeesMinExp);
            Controls.Add(pnlGrid);
            Controls.Add(pgrReport);
            Controls.Add(pnlCardView);
            Controls.Add(pnlCardActions);
            Controls.Add(pnlCardDates);
            Controls.Add(pnlHeader);
            Controls.Add(pnlCardEmployees);
            Name = "Form1";
            Text = "Form1";
            pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvReport).EndInit();
            pnlCardView.ResumeLayout(false);
            pnlCardActions.ResumeLayout(false);
            pnlLastDaysInput.ResumeLayout(false);
            pnlLastDaysInput.PerformLayout();
            pnlCardDates.ResumeLayout(false);
            pnlCardEmployees.ResumeLayout(false);
            pnlListEmployees.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPruebasListado).EndInit();
            pnlEmployeeInput.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Panel pnlGrid;
        public DataGridView dgvReport;
        public AntdProgressBar pgrReport;
        private AntdUI.Panel pnlCardView;
        private AntdUI.Label lblCardView;
        public AntdToggleButton chbShowReport;
        public AntdToggleButton chbShowReportCalendar;
        private AntdUI.Label lblSelectedDaysCaption;
        public Label lblEmployeeAdvice;
        public Label lblSelectedDays;
        private AntdUI.Panel pnlCardActions;
        private AntdUI.Label lblCardActions;
        private AntdUI.Button btnLoadReport;
        private AntdUI.Button btnClearList;
        private AntdUI.Button btnModifyAttendance;
        private AntdUI.Button btnExcel;
        private AntdUI.Label lblLastDays;
        private AntdUI.Panel pnlLastDaysInput;
        public TextBox txbLastDays;
        private AntdUI.Label label2;
        public AntdComboBox cboAttendenceType;
        private AntdUI.Label lblSobrantesInfo;
        private AntdUI.Panel pnlCardDates;
        private AntdUI.Label lblCardDates;
        private AntdUI.Label label4;
        public AntdComboBox cboAgriculturalCycle;
        private AntdUI.Label labelSeason;
        public AntdComboBox cboSeason;
        private AntdUI.Label label5;
        public AntdComboBox cboWeek1;
        private AntdUI.Label label6;
        public AntdComboBox cboWeek2;
        private AntdUI.Label labelDate;
        public AntdDatePicker dtpDate1;
        private AntdUI.Label labelDateTo;
        public AntdDatePicker dtpDate2;
        private AntdUI.Panel pnlCardEmployees;
        private AntdUI.Button btnSearchEmployee;
        private AntdUI.Panel pnlEmployeeInput;
        public RichTextBox txbIdEmployee;
        private AntdUI.Button btnAddEmployee;
        public AntdMultiSelectComboBox cboLP;
        private AntdUI.Button btnAddList;
        public AntdMultiSelectComboBox cboNomWorkGroup;
        private AntdUI.Button btnAddNomWorkGroup;
        private AntdUI.Label label1;
        private AntdUI.Label lblCardEmployees;
        private AntdUI.Label label3;
        private AntdUI.Label labelLP;
        private AntdUI.Panel pnlHeader;
        public AntdUI.Label lblTitle;
        private AntdUI.Button btnOpenFrmAttendanceType;
        public DataGridView dataGridView1;
        private AntdUI.Panel pnlListEmployees;
        public DataGridView dgvPruebasListado;
        private DataGridViewCheckBoxColumn colListSel;
        private DataGridViewTextBoxColumn colListCodigo;
        private DataGridViewTextBoxColumn colListNombre;
        private DataGridViewTextBoxColumn colListEdad;
        private DataGridViewTextBoxColumn colListNacimiento;
        private DataGridViewTextBoxColumn colListEstado;
        private DataGridViewTextBoxColumn colListCURP;
        private DataGridViewTextBoxColumn colListNSS;
        private DataGridViewTextBoxColumn colListRFC;
        private DataGridViewTextBoxColumn colListRPatronal;
        private DataGridViewTextBoxColumn colListPatron;
        private DataGridViewTextBoxColumn colListLugarDePago;
        private DataGridViewTextBoxColumn colListContratista;
        private DataGridViewTextBoxColumn colListIngreso;
        private DataGridViewTextBoxColumn colListReingreso;
        private AntdUI.Button btnEmployeesMinExp;
        private AntdUI.Panel panel1;
    }
}