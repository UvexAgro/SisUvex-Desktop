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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAsistenciaASConsulta));
            pnlHeader = new AntdUI.Panel();
            lblTitle = new AntdUI.Label();
            btnOpenFrmAttendanceType = new AntdUI.Button();
            pnlCardEmployees = new AntdUI.Panel();
            lblCardEmployees = new AntdUI.Label();
            label1 = new AntdUI.Label();
            btnSearchEmployee = new AntdUI.Button();
            pnlEmployeeInput = new AntdUI.Panel();
            txbIdEmployee = new RichTextBox();
            cmsIdEmployee = new ContextMenuStrip(components);
            tsmiUndo = new ToolStripMenuItem();
            tssIdEmployee1 = new ToolStripSeparator();
            tsmiCut = new ToolStripMenuItem();
            tsmiCopy = new ToolStripMenuItem();
            tsmiPaste = new ToolStripMenuItem();
            tsmiDelete = new ToolStripMenuItem();
            tssIdEmployee2 = new ToolStripSeparator();
            tsmiSelectAll = new ToolStripMenuItem();
            btnAddEmployee = new AntdUI.Button();
            lblEmployeeAdvice = new Label();
            labelLP = new AntdUI.Label();
            cboLP = new AntdMultiSelectComboBox();
            btnAddList = new AntdUI.Button();
            label3 = new AntdUI.Label();
            cboNomWorkGroup = new AntdMultiSelectComboBox();
            btnAddNomWorkGroup = new AntdUI.Button();
            pnlCardDates = new AntdUI.Panel();
            lblCardDates = new AntdUI.Label();
            label4 = new AntdUI.Label();
            cboAgriculturalCycle = new AntdComboBox();
            labelSeason = new AntdUI.Label();
            cboSeason = new AntdComboBox();
            label5 = new AntdUI.Label();
            cboWeek1 = new AntdComboBox();
            label6 = new AntdUI.Label();
            cboWeek2 = new AntdComboBox();
            labelDate = new AntdUI.Label();
            dtpDate1 = new AntdDatePicker();
            labelDateTo = new AntdUI.Label();
            dtpDate2 = new AntdDatePicker();
            pnlCardActions = new AntdUI.Panel();
            lblCardActions = new AntdUI.Label();
            btnLoadReport = new AntdUI.Button();
            btnClearList = new AntdUI.Button();
            btnModifyAttendance = new AntdUI.Button();
            btnExcel = new AntdUI.Button();
            lblLastDays = new AntdUI.Label();
            pnlLastDaysInput = new AntdUI.Panel();
            txbLastDays = new TextBox();
            label2 = new AntdUI.Label();
            cboAttendenceType = new AntdComboBox();
            lblSobrantesInfo = new AntdUI.Label();
            pnlCardView = new AntdUI.Panel();
            lblCardView = new AntdUI.Label();
            chbShowEmployees = new AntdToggleButton();
            chbShowReport = new AntdToggleButton();
            chbShowReportCalendar = new AntdToggleButton();
            lblSelectedDaysCaption = new AntdUI.Label();
            lblSelectedDays = new Label();
            pgrReport = new AntdProgressBar();
            pnlGrid = new AntdUI.Panel();
            dgvReport = new DataGridView();
            toolTip = new ToolTip(components);
            pnlHeader.SuspendLayout();
            pnlCardEmployees.SuspendLayout();
            pnlEmployeeInput.SuspendLayout();
            cmsIdEmployee.SuspendLayout();
            pnlCardDates.SuspendLayout();
            pnlCardActions.SuspendLayout();
            pnlLastDaysInput.SuspendLayout();
            pnlCardView.SuspendLayout();
            pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReport).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlHeader.Back = Color.FromArgb(122, 44, 166);
            pnlHeader.BorderWidth = 0F;
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(btnOpenFrmAttendanceType);
            pnlHeader.Location = new Point(12, 10);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Radius = 8;
            pnlHeader.Size = new Size(909, 40);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 12.5F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(14, 5);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(420, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Tag = "lotData";
            lblTitle.Text = "Configurar reporte";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnOpenFrmAttendanceType
            // 
            btnOpenFrmAttendanceType.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnOpenFrmAttendanceType.BorderWidth = 0F;
            btnOpenFrmAttendanceType.Cursor = Cursors.Hand;
            btnOpenFrmAttendanceType.DefaultBack = Color.White;
            btnOpenFrmAttendanceType.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnOpenFrmAttendanceType.ForeColor = Color.FromArgb(122, 44, 166);
            btnOpenFrmAttendanceType.IconSize = new Size(15, 15);
            btnOpenFrmAttendanceType.IconSvg = AntdIcons.Settings;
            btnOpenFrmAttendanceType.Location = new Point(731, 5);
            btnOpenFrmAttendanceType.Name = "btnOpenFrmAttendanceType";
            btnOpenFrmAttendanceType.Radius = 8;
            btnOpenFrmAttendanceType.Size = new Size(168, 30);
            btnOpenFrmAttendanceType.TabIndex = 1;
            btnOpenFrmAttendanceType.Text = "Tipo de asistencia";
            btnOpenFrmAttendanceType.Click += btnOpenFrmAttendanceType_Click;
            // 
            // pnlCardEmployees
            // 
            pnlCardEmployees.Back = Color.White;
            pnlCardEmployees.BorderColor = Color.FromArgb(228, 228, 238);
            pnlCardEmployees.BorderWidth = 1F;
            pnlCardEmployees.Controls.Add(lblCardEmployees);
            pnlCardEmployees.Controls.Add(label1);
            pnlCardEmployees.Controls.Add(btnSearchEmployee);
            pnlCardEmployees.Controls.Add(pnlEmployeeInput);
            pnlCardEmployees.Controls.Add(btnAddEmployee);
            pnlCardEmployees.Controls.Add(lblEmployeeAdvice);
            pnlCardEmployees.Controls.Add(labelLP);
            pnlCardEmployees.Controls.Add(cboLP);
            pnlCardEmployees.Controls.Add(btnAddList);
            pnlCardEmployees.Controls.Add(label3);
            pnlCardEmployees.Controls.Add(cboNomWorkGroup);
            pnlCardEmployees.Controls.Add(btnAddNomWorkGroup);
            pnlCardEmployees.Location = new Point(12, 58);
            pnlCardEmployees.Name = "pnlCardEmployees";
            pnlCardEmployees.Radius = 10;
            pnlCardEmployees.Size = new Size(452, 196);
            pnlCardEmployees.TabIndex = 1;
            // 
            // lblCardEmployees
            // 
            lblCardEmployees.BackColor = Color.Transparent;
            lblCardEmployees.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblCardEmployees.ForeColor = Color.FromArgb(30, 41, 59);
            lblCardEmployees.Location = new Point(16, 8);
            lblCardEmployees.Name = "lblCardEmployees";
            lblCardEmployees.Size = new Size(300, 28);
            lblCardEmployees.TabIndex = 0;
            lblCardEmployees.Text = "Seleccionar empleados";
            lblCardEmployees.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 9.5F);
            label1.ForeColor = Color.FromArgb(51, 65, 85);
            label1.Location = new Point(16, 46);
            label1.Name = "label1";
            label1.Size = new Size(92, 28);
            label1.TabIndex = 1;
            label1.Text = "Empleado(s):";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnSearchEmployee
            // 
            btnSearchEmployee.BorderWidth = 1F;
            btnSearchEmployee.Cursor = Cursors.Hand;
            btnSearchEmployee.DefaultBack = Color.White;
            btnSearchEmployee.DefaultBorderColor = Color.FromArgb(206, 212, 224);
            btnSearchEmployee.ForeColor = Color.FromArgb(122, 44, 166);
            btnSearchEmployee.IconSize = new Size(18, 18);
            btnSearchEmployee.IconSvg = AntdIcons.Search;
            btnSearchEmployee.Location = new Point(108, 43);
            btnSearchEmployee.Name = "btnSearchEmployee";
            btnSearchEmployee.Radius = 8;
            btnSearchEmployee.Size = new Size(34, 34);
            btnSearchEmployee.TabIndex = 2;
            btnSearchEmployee.Click += btnSearchEmployee_Click;
            // 
            // pnlEmployeeInput
            // 
            pnlEmployeeInput.Back = Color.White;
            pnlEmployeeInput.BorderColor = Color.FromArgb(206, 212, 224);
            pnlEmployeeInput.BorderWidth = 1F;
            pnlEmployeeInput.Controls.Add(txbIdEmployee);
            pnlEmployeeInput.Location = new Point(148, 43);
            pnlEmployeeInput.Name = "pnlEmployeeInput";
            pnlEmployeeInput.Radius = 8;
            pnlEmployeeInput.Size = new Size(248, 34);
            pnlEmployeeInput.TabIndex = 3;
            // 
            // txbIdEmployee
            // 
            txbIdEmployee.BackColor = Color.White;
            txbIdEmployee.BorderStyle = BorderStyle.None;
            txbIdEmployee.ContextMenuStrip = cmsIdEmployee;
            txbIdEmployee.Font = new Font("Segoe UI", 10F);
            txbIdEmployee.Location = new Point(9, 6);
            txbIdEmployee.Name = "txbIdEmployee";
            txbIdEmployee.ScrollBars = RichTextBoxScrollBars.Vertical;
            txbIdEmployee.Size = new Size(230, 22);
            txbIdEmployee.TabIndex = 0;
            txbIdEmployee.Text = "";
            txbIdEmployee.KeyDown += txbIdEmployee_KeyDown;
            // 
            // cmsIdEmployee
            // 
            cmsIdEmployee.Items.AddRange(new ToolStripItem[] { tsmiUndo, tssIdEmployee1, tsmiCut, tsmiCopy, tsmiPaste, tsmiDelete, tssIdEmployee2, tsmiSelectAll });
            cmsIdEmployee.Name = "cmsIdEmployee";
            cmsIdEmployee.Size = new Size(163, 148);
            cmsIdEmployee.Opening += cmsIdEmployee_Opening;
            // 
            // tsmiUndo
            // 
            tsmiUndo.Name = "tsmiUndo";
            tsmiUndo.Size = new Size(162, 22);
            tsmiUndo.Text = "Deshacer";
            tsmiUndo.Click += tsmiUndo_Click;
            // 
            // tssIdEmployee1
            // 
            tssIdEmployee1.Name = "tssIdEmployee1";
            tssIdEmployee1.Size = new Size(159, 6);
            // 
            // tsmiCut
            // 
            tsmiCut.Name = "tsmiCut";
            tsmiCut.Size = new Size(162, 22);
            tsmiCut.Text = "Cortar";
            tsmiCut.Click += tsmiCut_Click;
            // 
            // tsmiCopy
            // 
            tsmiCopy.Name = "tsmiCopy";
            tsmiCopy.Size = new Size(162, 22);
            tsmiCopy.Text = "Copiar";
            tsmiCopy.Click += tsmiCopy_Click;
            // 
            // tsmiPaste
            // 
            tsmiPaste.Name = "tsmiPaste";
            tsmiPaste.Size = new Size(162, 22);
            tsmiPaste.Text = "Pegar";
            tsmiPaste.Click += tsmiPaste_Click;
            // 
            // tsmiDelete
            // 
            tsmiDelete.Name = "tsmiDelete";
            tsmiDelete.Size = new Size(162, 22);
            tsmiDelete.Text = "Eliminar";
            tsmiDelete.Click += tsmiDelete_Click;
            // 
            // tssIdEmployee2
            // 
            tssIdEmployee2.Name = "tssIdEmployee2";
            tssIdEmployee2.Size = new Size(159, 6);
            // 
            // tsmiSelectAll
            // 
            tsmiSelectAll.Name = "tsmiSelectAll";
            tsmiSelectAll.Size = new Size(162, 22);
            tsmiSelectAll.Text = "Seleccionar todo";
            tsmiSelectAll.Click += tsmiSelectAll_Click;
            // 
            // btnAddEmployee
            // 
            btnAddEmployee.BorderWidth = 0F;
            btnAddEmployee.Cursor = Cursors.Hand;
            btnAddEmployee.DefaultBack = Color.FromArgb(240, 230, 250);
            btnAddEmployee.ForeColor = Color.FromArgb(122, 44, 166);
            btnAddEmployee.IconSize = new Size(18, 18);
            btnAddEmployee.IconSvg = AntdIcons.Add;
            btnAddEmployee.Location = new Point(404, 43);
            btnAddEmployee.Name = "btnAddEmployee";
            btnAddEmployee.Radius = 8;
            btnAddEmployee.Size = new Size(34, 34);
            btnAddEmployee.TabIndex = 4;
            btnAddEmployee.Click += btnAddEmployee_Click;
            // 
            // lblEmployeeAdvice
            // 
            lblEmployeeAdvice.BackColor = Color.Transparent;
            lblEmployeeAdvice.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblEmployeeAdvice.ForeColor = Color.Gray;
            lblEmployeeAdvice.Location = new Point(108, 81);
            lblEmployeeAdvice.Name = "lblEmployeeAdvice";
            lblEmployeeAdvice.Size = new Size(330, 30);
            lblEmployeeAdvice.TabIndex = 5;
            lblEmployeeAdvice.Text = "lblEmployeeAdvice";
            // 
            // labelLP
            // 
            labelLP.BackColor = Color.Transparent;
            labelLP.Font = new Font("Segoe UI", 9.5F);
            labelLP.ForeColor = Color.FromArgb(51, 65, 85);
            labelLP.Location = new Point(16, 116);
            labelLP.Name = "labelLP";
            labelLP.Size = new Size(92, 28);
            labelLP.TabIndex = 6;
            labelLP.Text = "Lugar de pago:";
            labelLP.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cboLP
            // 
            cboLP.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLP.Font = new Font("Segoe UI", 10F);
            cboLP.FormattingEnabled = true;
            cboLP.Location = new Point(108, 117);
            cboLP.Margin = new Padding(0, 3, 3, 3);
            cboLP.Name = "cboLP";
            cboLP.Size = new Size(288, 26);
            cboLP.TabIndex = 7;
            // 
            // btnAddList
            // 
            btnAddList.BorderWidth = 0F;
            btnAddList.Cursor = Cursors.Hand;
            btnAddList.DefaultBack = Color.FromArgb(240, 230, 250);
            btnAddList.ForeColor = Color.FromArgb(122, 44, 166);
            btnAddList.IconSize = new Size(18, 18);
            btnAddList.IconSvg = AntdIcons.Add;
            btnAddList.Location = new Point(404, 113);
            btnAddList.Name = "btnAddList";
            btnAddList.Radius = 8;
            btnAddList.Size = new Size(34, 34);
            btnAddList.TabIndex = 8;
            btnAddList.Click += btnAddList_Click;
            // 
            // label3
            // 
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 9.5F);
            label3.ForeColor = Color.FromArgb(51, 65, 85);
            label3.Location = new Point(16, 156);
            label3.Name = "label3";
            label3.Size = new Size(92, 28);
            label3.TabIndex = 9;
            label3.Text = "Cuadrilla:";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cboNomWorkGroup
            // 
            cboNomWorkGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNomWorkGroup.Font = new Font("Segoe UI", 10F);
            cboNomWorkGroup.FormattingEnabled = true;
            cboNomWorkGroup.Location = new Point(108, 157);
            cboNomWorkGroup.Margin = new Padding(0, 3, 3, 3);
            cboNomWorkGroup.Name = "cboNomWorkGroup";
            cboNomWorkGroup.Size = new Size(288, 26);
            cboNomWorkGroup.TabIndex = 10;
            // 
            // btnAddNomWorkGroup
            // 
            btnAddNomWorkGroup.BorderWidth = 0F;
            btnAddNomWorkGroup.Cursor = Cursors.Hand;
            btnAddNomWorkGroup.DefaultBack = Color.FromArgb(240, 230, 250);
            btnAddNomWorkGroup.ForeColor = Color.FromArgb(122, 44, 166);
            btnAddNomWorkGroup.IconSize = new Size(18, 18);
            btnAddNomWorkGroup.IconSvg = AntdIcons.Add;
            btnAddNomWorkGroup.Location = new Point(404, 153);
            btnAddNomWorkGroup.Name = "btnAddNomWorkGroup";
            btnAddNomWorkGroup.Radius = 8;
            btnAddNomWorkGroup.Size = new Size(34, 34);
            btnAddNomWorkGroup.TabIndex = 11;
            // 
            // pnlCardDates
            // 
            pnlCardDates.Back = Color.White;
            pnlCardDates.BorderColor = Color.FromArgb(228, 228, 238);
            pnlCardDates.BorderWidth = 1F;
            pnlCardDates.Controls.Add(lblCardDates);
            pnlCardDates.Controls.Add(label4);
            pnlCardDates.Controls.Add(cboAgriculturalCycle);
            pnlCardDates.Controls.Add(labelSeason);
            pnlCardDates.Controls.Add(cboSeason);
            pnlCardDates.Controls.Add(label5);
            pnlCardDates.Controls.Add(cboWeek1);
            pnlCardDates.Controls.Add(label6);
            pnlCardDates.Controls.Add(cboWeek2);
            pnlCardDates.Controls.Add(labelDate);
            pnlCardDates.Controls.Add(dtpDate1);
            pnlCardDates.Controls.Add(labelDateTo);
            pnlCardDates.Controls.Add(dtpDate2);
            pnlCardDates.Location = new Point(474, 58);
            pnlCardDates.Name = "pnlCardDates";
            pnlCardDates.Radius = 10;
            pnlCardDates.Size = new Size(447, 196);
            pnlCardDates.TabIndex = 2;
            // 
            // lblCardDates
            // 
            lblCardDates.BackColor = Color.Transparent;
            lblCardDates.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblCardDates.ForeColor = Color.FromArgb(30, 41, 59);
            lblCardDates.Location = new Point(16, 8);
            lblCardDates.Name = "lblCardDates";
            lblCardDates.Size = new Size(300, 28);
            lblCardDates.TabIndex = 0;
            lblCardDates.Text = "Rango de fechas";
            lblCardDates.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 9.5F);
            label4.ForeColor = Color.FromArgb(51, 65, 85);
            label4.Location = new Point(16, 46);
            label4.Name = "label4";
            label4.Size = new Size(52, 28);
            label4.TabIndex = 1;
            label4.Text = "Ciclo:";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cboAgriculturalCycle
            // 
            cboAgriculturalCycle.DropDownStyle = ComboBoxStyle.DropDownList;
            cboAgriculturalCycle.Font = new Font("Segoe UI", 10F);
            cboAgriculturalCycle.FormattingEnabled = true;
            cboAgriculturalCycle.Location = new Point(70, 47);
            cboAgriculturalCycle.Margin = new Padding(0, 3, 3, 3);
            cboAgriculturalCycle.Name = "cboAgriculturalCycle";
            cboAgriculturalCycle.Size = new Size(122, 26);
            cboAgriculturalCycle.TabIndex = 2;
            // 
            // labelSeason
            // 
            labelSeason.BackColor = Color.Transparent;
            labelSeason.Font = new Font("Segoe UI", 9.5F);
            labelSeason.ForeColor = Color.FromArgb(51, 65, 85);
            labelSeason.Location = new Point(206, 46);
            labelSeason.Name = "labelSeason";
            labelSeason.Size = new Size(80, 28);
            labelSeason.TabIndex = 3;
            labelSeason.Text = "Temporada:";
            labelSeason.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cboSeason
            // 
            cboSeason.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSeason.Font = new Font("Segoe UI", 10F);
            cboSeason.FormattingEnabled = true;
            cboSeason.Location = new Point(290, 47);
            cboSeason.Margin = new Padding(0, 3, 3, 3);
            cboSeason.Name = "cboSeason";
            cboSeason.Size = new Size(141, 26);
            cboSeason.TabIndex = 4;
            // 
            // label5
            // 
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 9.5F);
            label5.ForeColor = Color.FromArgb(51, 65, 85);
            label5.Location = new Point(16, 96);
            label5.Name = "label5";
            label5.Size = new Size(52, 28);
            label5.TabIndex = 5;
            label5.Text = "Semana:";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cboWeek1
            // 
            cboWeek1.DropDownStyle = ComboBoxStyle.DropDown;
            cboWeek1.Font = new Font("Segoe UI", 10F);
            cboWeek1.FormattingEnabled = true;
            cboWeek1.Location = new Point(70, 97);
            cboWeek1.Margin = new Padding(0, 3, 3, 3);
            cboWeek1.Name = "cboWeek1";
            cboWeek1.Size = new Size(80, 26);
            cboWeek1.TabIndex = 6;
            // 
            // label6
            // 
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 9.5F);
            label6.ForeColor = Color.FromArgb(51, 65, 85);
            label6.Location = new Point(158, 96);
            label6.Name = "label6";
            label6.Size = new Size(16, 28);
            label6.TabIndex = 7;
            label6.Text = "a";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cboWeek2
            // 
            cboWeek2.DropDownStyle = ComboBoxStyle.DropDown;
            cboWeek2.Font = new Font("Segoe UI", 10F);
            cboWeek2.FormattingEnabled = true;
            cboWeek2.Location = new Point(182, 97);
            cboWeek2.Margin = new Padding(0, 3, 3, 3);
            cboWeek2.Name = "cboWeek2";
            cboWeek2.Size = new Size(80, 26);
            cboWeek2.TabIndex = 8;
            // 
            // labelDate
            // 
            labelDate.BackColor = Color.Transparent;
            labelDate.Font = new Font("Segoe UI", 9.5F);
            labelDate.ForeColor = Color.FromArgb(51, 65, 85);
            labelDate.Location = new Point(16, 146);
            labelDate.Name = "labelDate";
            labelDate.Size = new Size(52, 28);
            labelDate.TabIndex = 9;
            labelDate.Text = "Rango:";
            labelDate.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dtpDate1
            // 
            dtpDate1.BorderActive = Color.FromArgb(122, 44, 166);
            dtpDate1.BorderColor = Color.FromArgb(206, 212, 224);
            dtpDate1.BorderHover = Color.FromArgb(140, 66, 186);
            dtpDate1.Font = new Font("Segoe UI", 10F);
            dtpDate1.Format = "dd/MM/yyyy";
            dtpDate1.Location = new Point(70, 143);
            dtpDate1.Name = "dtpDate1";
            dtpDate1.Radius = 6;
            dtpDate1.Size = new Size(146, 34);
            dtpDate1.TabIndex = 10;
            // 
            // labelDateTo
            // 
            labelDateTo.BackColor = Color.Transparent;
            labelDateTo.Font = new Font("Segoe UI", 9.5F);
            labelDateTo.ForeColor = Color.FromArgb(51, 65, 85);
            labelDateTo.Location = new Point(222, 146);
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
            dtpDate2.Location = new Point(244, 143);
            dtpDate2.Name = "dtpDate2";
            dtpDate2.Radius = 6;
            dtpDate2.Size = new Size(146, 34);
            dtpDate2.TabIndex = 12;
            // 
            // pnlCardActions
            // 
            pnlCardActions.Back = Color.White;
            pnlCardActions.BorderColor = Color.FromArgb(228, 228, 238);
            pnlCardActions.BorderWidth = 1F;
            pnlCardActions.Controls.Add(lblCardActions);
            pnlCardActions.Controls.Add(btnLoadReport);
            pnlCardActions.Controls.Add(btnClearList);
            pnlCardActions.Controls.Add(btnModifyAttendance);
            pnlCardActions.Controls.Add(btnExcel);
            pnlCardActions.Controls.Add(lblLastDays);
            pnlCardActions.Controls.Add(pnlLastDaysInput);
            pnlCardActions.Controls.Add(label2);
            pnlCardActions.Controls.Add(cboAttendenceType);
            pnlCardActions.Controls.Add(lblSobrantesInfo);
            pnlCardActions.Location = new Point(12, 262);
            pnlCardActions.Name = "pnlCardActions";
            pnlCardActions.Radius = 10;
            pnlCardActions.Size = new Size(500, 148);
            pnlCardActions.TabIndex = 3;
            // 
            // lblCardActions
            // 
            lblCardActions.BackColor = Color.Transparent;
            lblCardActions.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblCardActions.ForeColor = Color.FromArgb(30, 41, 59);
            lblCardActions.Location = new Point(16, 6);
            lblCardActions.Name = "lblCardActions";
            lblCardActions.Size = new Size(300, 28);
            lblCardActions.TabIndex = 0;
            lblCardActions.Text = "Acciones";
            lblCardActions.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnLoadReport
            // 
            btnLoadReport.BackActive = Color.FromArgb(98, 28, 138);
            btnLoadReport.BackColor = Color.FromArgb(122, 44, 166);
            btnLoadReport.BackHover = Color.FromArgb(140, 66, 186);
            btnLoadReport.BorderWidth = 0F;
            btnLoadReport.Cursor = Cursors.Hand;
            btnLoadReport.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnLoadReport.ForeColor = Color.White;
            btnLoadReport.IconSize = new Size(16, 16);
            btnLoadReport.IconSvg = AntdIcons.Play;
            btnLoadReport.Location = new Point(16, 40);
            btnLoadReport.Name = "btnLoadReport";
            btnLoadReport.Radius = 8;
            btnLoadReport.Size = new Size(142, 36);
            btnLoadReport.TabIndex = 1;
            btnLoadReport.Text = "Cargar reporte";
            btnLoadReport.Type = AntdUI.TTypeMini.Primary;
            btnLoadReport.Click += btnLoadReport_Click;
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
            btnClearList.IconSvg = AntdIcons.Clear;
            btnClearList.Location = new Point(166, 40);
            btnClearList.Name = "btnClearList";
            btnClearList.Radius = 8;
            btnClearList.Size = new Size(98, 36);
            btnClearList.TabIndex = 2;
            btnClearList.Text = "Limpiar";
            btnClearList.Click += btnClearList_Click;
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
            btnModifyAttendance.IconSvg = AntdIcons.Edit;
            btnModifyAttendance.Location = new Point(272, 40);
            btnModifyAttendance.Name = "btnModifyAttendance";
            btnModifyAttendance.Radius = 8;
            btnModifyAttendance.Size = new Size(116, 36);
            btnModifyAttendance.TabIndex = 3;
            btnModifyAttendance.Text = "Modificar";
            btnModifyAttendance.Click += btnModifyAttendance_Click;
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
            btnExcel.IconSvg = AntdIcons.Table;
            btnExcel.Location = new Point(396, 40);
            btnExcel.Name = "btnExcel";
            btnExcel.Radius = 8;
            btnExcel.Size = new Size(88, 36);
            btnExcel.TabIndex = 4;
            btnExcel.Text = "Excel";
            btnExcel.Click += btnExcel_Click;
            // 
            // lblLastDays
            // 
            lblLastDays.BackColor = Color.Transparent;
            lblLastDays.Font = new Font("Segoe UI", 9.5F);
            lblLastDays.ForeColor = Color.FromArgb(51, 65, 85);
            lblLastDays.Location = new Point(16, 91);
            lblLastDays.Name = "lblLastDays";
            lblLastDays.Size = new Size(82, 28);
            lblLastDays.TabIndex = 5;
            lblLastDays.Text = "Últimos días:";
            lblLastDays.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlLastDaysInput
            // 
            pnlLastDaysInput.Back = Color.White;
            pnlLastDaysInput.BorderColor = Color.FromArgb(206, 212, 224);
            pnlLastDaysInput.BorderWidth = 1F;
            pnlLastDaysInput.Controls.Add(txbLastDays);
            pnlLastDaysInput.Location = new Point(100, 90);
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
            txbLastDays.Size = new Size(40, 19);
            txbLastDays.TabIndex = 0;
            txbLastDays.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 9.5F);
            label2.ForeColor = Color.FromArgb(51, 65, 85);
            label2.Location = new Point(166, 91);
            label2.Name = "label2";
            label2.Size = new Size(146, 28);
            label2.TabIndex = 7;
            label2.Text = "Inasistencia por defecto:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cboAttendenceType
            // 
            cboAttendenceType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboAttendenceType.Enabled = false;
            cboAttendenceType.Font = new Font("Segoe UI", 10F);
            cboAttendenceType.FormattingEnabled = true;
            cboAttendenceType.Location = new Point(316, 92);
            cboAttendenceType.Margin = new Padding(0, 3, 3, 3);
            cboAttendenceType.Name = "cboAttendenceType";
            cboAttendenceType.Size = new Size(168, 26);
            cboAttendenceType.TabIndex = 8;
            // 
            // lblSobrantesInfo
            // 
            lblSobrantesInfo.BackColor = Color.Transparent;
            lblSobrantesInfo.Font = new Font("Segoe UI", 8.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblSobrantesInfo.ForeColor = Color.FromArgb(120, 130, 150);
            lblSobrantesInfo.Location = new Point(16, 122);
            lblSobrantesInfo.Name = "lblSobrantesInfo";
            lblSobrantesInfo.Size = new Size(470, 20);
            lblSobrantesInfo.TabIndex = 9;
            lblSobrantesInfo.Text = "ℹ Sin listado: indica Últimos días (empleados con importe). Vacío = sin ese límite";
            lblSobrantesInfo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlCardView
            // 
            pnlCardView.Back = Color.White;
            pnlCardView.BorderColor = Color.FromArgb(228, 228, 238);
            pnlCardView.BorderWidth = 1F;
            pnlCardView.Controls.Add(lblCardView);
            pnlCardView.Controls.Add(chbShowEmployees);
            pnlCardView.Controls.Add(chbShowReport);
            pnlCardView.Controls.Add(chbShowReportCalendar);
            pnlCardView.Controls.Add(lblSelectedDaysCaption);
            pnlCardView.Controls.Add(lblSelectedDays);
            pnlCardView.Location = new Point(522, 262);
            pnlCardView.Name = "pnlCardView";
            pnlCardView.Radius = 10;
            pnlCardView.Size = new Size(399, 148);
            pnlCardView.TabIndex = 4;
            // 
            // lblCardView
            // 
            lblCardView.BackColor = Color.Transparent;
            lblCardView.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblCardView.ForeColor = Color.FromArgb(30, 41, 59);
            lblCardView.Location = new Point(16, 6);
            lblCardView.Name = "lblCardView";
            lblCardView.Size = new Size(300, 28);
            lblCardView.TabIndex = 0;
            lblCardView.Text = "Visualizar";
            lblCardView.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // chbShowEmployees
            // 
            chbShowEmployees.BackHover = Color.FromArgb(240, 230, 250);
            chbShowEmployees.BorderWidth = 1.5F;
            chbShowEmployees.Cursor = Cursors.Hand;
            chbShowEmployees.DefaultBack = Color.White;
            chbShowEmployees.DefaultBorderColor = Color.FromArgb(206, 212, 224);
            chbShowEmployees.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            chbShowEmployees.ForeColor = Color.FromArgb(122, 44, 166);
            chbShowEmployees.IconSize = new Size(16, 16);
            chbShowEmployees.IconSvg = AntdIcons.List;
            chbShowEmployees.Location = new Point(16, 40);
            chbShowEmployees.Name = "chbShowEmployees";
            chbShowEmployees.Radius = 8;
            chbShowEmployees.Size = new Size(108, 36);
            chbShowEmployees.TabIndex = 1;
            chbShowEmployees.Text = "Listado";
            chbShowEmployees.ToggleBack = Color.FromArgb(122, 44, 166);
            chbShowEmployees.ToggleIconSvg = AntdIcons.List;
            chbShowEmployees.ToggleType = AntdUI.TTypeMini.Primary;
            chbShowEmployees.ToggleText = "Listado";
            chbShowEmployees.ToggleBackActive = Color.FromArgb(98, 28, 138);
            chbShowEmployees.ToggleBackHover = Color.FromArgb(140, 66, 186);
            chbShowEmployees.ToggleFore = Color.White;
            chbShowEmployees.ToggleForeActive = Color.White;
            chbShowEmployees.ToggleForeHover = Color.White;
            chbShowEmployees.CheckedChanged += chbShowEmployees_CheckedChanged;
            // 
            // chbShowReport
            // 
            chbShowReport.BackHover = Color.FromArgb(240, 230, 250);
            chbShowReport.BorderWidth = 1.5F;
            chbShowReport.Cursor = Cursors.Hand;
            chbShowReport.DefaultBack = Color.White;
            chbShowReport.DefaultBorderColor = Color.FromArgb(206, 212, 224);
            chbShowReport.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            chbShowReport.ForeColor = Color.FromArgb(122, 44, 166);
            chbShowReport.IconSize = new Size(16, 16);
            chbShowReport.IconSvg = AntdIcons.Document;
            chbShowReport.Location = new Point(132, 40);
            chbShowReport.Name = "chbShowReport";
            chbShowReport.Radius = 8;
            chbShowReport.Size = new Size(108, 36);
            chbShowReport.TabIndex = 2;
            chbShowReport.Text = "Reporte";
            chbShowReport.ToggleBack = Color.FromArgb(122, 44, 166);
            chbShowReport.ToggleIconSvg = AntdIcons.Document;
            chbShowReport.ToggleType = AntdUI.TTypeMini.Primary;
            chbShowReport.ToggleText = "Reporte";
            chbShowReport.ToggleBackActive = Color.FromArgb(98, 28, 138);
            chbShowReport.ToggleBackHover = Color.FromArgb(140, 66, 186);
            chbShowReport.ToggleFore = Color.White;
            chbShowReport.ToggleForeActive = Color.White;
            chbShowReport.ToggleForeHover = Color.White;
            chbShowReport.CheckedChanged += chbShowReport_CheckedChanged;
            // 
            // chbShowReportCalendar
            // 
            chbShowReportCalendar.BackHover = Color.FromArgb(240, 230, 250);
            chbShowReportCalendar.BorderWidth = 1.5F;
            chbShowReportCalendar.Cursor = Cursors.Hand;
            chbShowReportCalendar.DefaultBack = Color.White;
            chbShowReportCalendar.DefaultBorderColor = Color.FromArgb(206, 212, 224);
            chbShowReportCalendar.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            chbShowReportCalendar.ForeColor = Color.FromArgb(122, 44, 166);
            chbShowReportCalendar.IconSize = new Size(16, 16);
            chbShowReportCalendar.IconSvg = AntdIcons.Calendar;
            chbShowReportCalendar.Location = new Point(248, 40);
            chbShowReportCalendar.Name = "chbShowReportCalendar";
            chbShowReportCalendar.Radius = 8;
            chbShowReportCalendar.Size = new Size(124, 36);
            chbShowReportCalendar.TabIndex = 3;
            chbShowReportCalendar.Text = "Calendario";
            chbShowReportCalendar.ToggleBack = Color.FromArgb(122, 44, 166);
            chbShowReportCalendar.ToggleIconSvg = AntdIcons.Calendar;
            chbShowReportCalendar.ToggleType = AntdUI.TTypeMini.Primary;
            chbShowReportCalendar.ToggleText = "Calendario";
            chbShowReportCalendar.ToggleBackActive = Color.FromArgb(98, 28, 138);
            chbShowReportCalendar.ToggleBackHover = Color.FromArgb(140, 66, 186);
            chbShowReportCalendar.ToggleFore = Color.White;
            chbShowReportCalendar.ToggleForeActive = Color.White;
            chbShowReportCalendar.ToggleForeHover = Color.White;
            chbShowReportCalendar.CheckedChanged += chbShowReportCalendar_CheckedChanged;
            // 
            // lblSelectedDaysCaption
            // 
            lblSelectedDaysCaption.BackColor = Color.Transparent;
            lblSelectedDaysCaption.Font = new Font("Segoe UI", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblSelectedDaysCaption.ForeColor = Color.FromArgb(120, 130, 150);
            lblSelectedDaysCaption.Location = new Point(16, 94);
            lblSelectedDaysCaption.Name = "lblSelectedDaysCaption";
            lblSelectedDaysCaption.Size = new Size(140, 26);
            lblSelectedDaysCaption.TabIndex = 4;
            lblSelectedDaysCaption.Text = "Días seleccionados:";
            lblSelectedDaysCaption.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblSelectedDays
            // 
            lblSelectedDays.BackColor = Color.Transparent;
            lblSelectedDays.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblSelectedDays.ForeColor = Color.FromArgb(120, 130, 150);
            lblSelectedDays.Location = new Point(158, 94);
            lblSelectedDays.Margin = new Padding(0);
            lblSelectedDays.Name = "lblSelectedDays";
            lblSelectedDays.Size = new Size(70, 26);
            lblSelectedDays.TabIndex = 5;
            lblSelectedDays.Text = "0";
            lblSelectedDays.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pgrReport
            // 
            pgrReport.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pgrReport.Location = new Point(12, 418);
            pgrReport.Maximum = 1000;
            pgrReport.Name = "pgrReport";
            pgrReport.Size = new Size(909, 8);
            pgrReport.Style = ProgressBarStyle.Continuous;
            pgrReport.TabIndex = 5;
            // 
            // pnlGrid
            // 
            pnlGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlGrid.Back = Color.White;
            pnlGrid.BorderColor = Color.FromArgb(201, 184, 225);
            pnlGrid.BorderWidth = 1F;
            pnlGrid.Controls.Add(dgvReport);
            pnlGrid.Location = new Point(12, 434);
            pnlGrid.Name = "pnlGrid";
            pnlGrid.Radius = 8;
            pnlGrid.Size = new Size(909, 254);
            pnlGrid.TabIndex = 6;
            // 
            // dgvReport
            // 
            dgvReport.AllowUserToAddRows = false;
            dgvReport.AllowUserToDeleteRows = false;
            dgvReport.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvReport.BackgroundColor = Color.White;
            dgvReport.BorderStyle = BorderStyle.None;
            dgvReport.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(237, 228, 248);
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(48, 20, 78);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(237, 228, 248);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(48, 20, 78);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvReport.ColumnHeadersHeight = 30;
            dgvReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(222, 206, 244);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(30, 41, 59);
            dgvReport.DefaultCellStyle = dataGridViewCellStyle3;
            dgvReport.EnableHeadersVisualStyles = false;
            dgvReport.GridColor = Color.FromArgb(214, 218, 230);
            dgvReport.ImeMode = ImeMode.NoControl;
            dgvReport.Location = new Point(3, 3);
            dgvReport.Name = "dgvReport";
            dgvReport.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(237, 228, 248);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(48, 20, 78);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(237, 228, 248);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(48, 20, 78);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvReport.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvReport.RowHeadersVisible = false;
            dgvReport.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReport.Size = new Size(903, 248);
            dgvReport.TabIndex = 0;
            dgvReport.CellFormatting += dgvReport_CellFormatting;
            dgvReport.CellPainting += dgvReport_CellPainting;
            dgvReport.CellToolTipTextNeeded += dgvReport_CellToolTipTextNeeded;
            dgvReport.CellValueChanged += dgvReport_CellValueChanged;
            dgvReport.ColumnHeaderMouseClick += dgvReport_ColumnHeaderMouseClick;
            dgvReport.CurrentCellDirtyStateChanged += dgvReport_CurrentCellDirtyStateChanged;
            dgvReport.SelectionChanged += dgvReport_SelectionChanged;
            // 
            // FrmAsistenciaASConsulta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 245, 250);
            ClientSize = new Size(933, 700);
            Controls.Add(pnlGrid);
            Controls.Add(pgrReport);
            Controls.Add(pnlCardView);
            Controls.Add(pnlCardActions);
            Controls.Add(pnlCardDates);
            Controls.Add(pnlCardEmployees);
            Controls.Add(pnlHeader);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmAsistenciaASConsulta";
            Text = "Reporte de asistencias";
            Load += FrmAsistenciaASConsulta_Load;
            pnlHeader.ResumeLayout(false);
            pnlCardEmployees.ResumeLayout(false);
            pnlEmployeeInput.ResumeLayout(false);
            cmsIdEmployee.ResumeLayout(false);
            pnlCardDates.ResumeLayout(false);
            pnlCardActions.ResumeLayout(false);
            pnlLastDaysInput.ResumeLayout(false);
            pnlCardView.ResumeLayout(false);
            pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvReport).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Panel pnlHeader;
        public AntdUI.Label lblTitle;
        private AntdUI.Button btnOpenFrmAttendanceType;
        private AntdUI.Panel pnlCardEmployees;
        private AntdUI.Label lblCardEmployees;
        private AntdUI.Label label1;
        private AntdUI.Button btnSearchEmployee;
        private AntdUI.Panel pnlEmployeeInput;
        public RichTextBox txbIdEmployee;
        private ContextMenuStrip cmsIdEmployee;
        private ToolStripMenuItem tsmiUndo;
        private ToolStripSeparator tssIdEmployee1;
        private ToolStripMenuItem tsmiCut;
        private ToolStripMenuItem tsmiCopy;
        private ToolStripMenuItem tsmiPaste;
        private ToolStripMenuItem tsmiDelete;
        private ToolStripSeparator tssIdEmployee2;
        private ToolStripMenuItem tsmiSelectAll;
        private AntdUI.Button btnAddEmployee;
        public Label lblEmployeeAdvice;
        private AntdUI.Label labelLP;
        public AntdMultiSelectComboBox cboLP;
        private AntdUI.Button btnAddList;
        private AntdUI.Label label3;
        public AntdMultiSelectComboBox cboNomWorkGroup;
        private AntdUI.Button btnAddNomWorkGroup;
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
        private AntdUI.Panel pnlCardView;
        private AntdUI.Label lblCardView;
        public AntdToggleButton chbShowEmployees;
        public AntdToggleButton chbShowReport;
        public AntdToggleButton chbShowReportCalendar;
        private AntdUI.Label lblSelectedDaysCaption;
        public Label lblSelectedDays;
        public AntdProgressBar pgrReport;
        private AntdUI.Panel pnlGrid;
        public DataGridView dgvReport;
        private ToolTip toolTip;
    }
}
