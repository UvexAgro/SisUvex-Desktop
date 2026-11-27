namespace SisUvex.Nomina.Asistencia_AS.ModifyAttendanceEmployees
{
    partial class FrmModifyAttendanceEmployees
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmModifyAttendanceEmployees));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            pnlHeader = new AntdUI.Panel();
            lblTitle = new AntdUI.Label();
            pnlPeriod = new AntdUI.Panel();
            lblPeriodo = new Label();
            lblDefaultType = new AntdUI.Label();
            cboDefaultType = new AntdComboBox();
            pnlCardApply = new AntdUI.Panel();
            lblCardApply = new AntdUI.Label();
            divTop = new AntdUI.Panel();
            lblApplyType = new AntdUI.Label();
            cboApplyType = new AntdComboBox();
            lblComments = new AntdUI.Label();
            pnlCommentsInput = new AntdUI.Panel();
            txbComments = new TextBox();
            btnApply = new AntdUI.Button();
            btnClose = new AntdUI.Button();
            btnDiscard = new AntdUI.Button();
            btnSave = new AntdUI.Button();
            lblPending = new Label();
            divBottom = new AntdUI.Panel();
            lblSelectedDaysCaption = new AntdUI.Label();
            lblSelectedDays = new Label();
            lblHint = new AntdUI.Label();
            lblHelp = new AntdUI.Label();
            pnlGrid = new AntdUI.Panel();
            dgvPivot = new DataGridView();
            toolTip = new ToolTip(components);
            pnlHeader.SuspendLayout();
            pnlPeriod.SuspendLayout();
            pnlCardApply.SuspendLayout();
            pnlCommentsInput.SuspendLayout();
            divBottom.SuspendLayout();
            pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPivot).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlHeader.Back = Color.FromArgb(122, 44, 166);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Location = new Point(12, 12);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Radius = 8;
            pnlHeader.Size = new Size(958, 40);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 12.5F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(14, 5);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(330, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Modificar asistencias";
            // 
            // pnlPeriod
            // 
            pnlPeriod.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlPeriod.Back = Color.FromArgb(240, 234, 250);
            pnlPeriod.BorderColor = Color.FromArgb(225, 215, 242);
            pnlPeriod.BorderWidth = 1F;
            pnlPeriod.Controls.Add(lblPeriodo);
            pnlPeriod.Controls.Add(lblDefaultType);
            pnlPeriod.Controls.Add(cboDefaultType);
            pnlPeriod.Location = new Point(12, 58);
            pnlPeriod.Name = "pnlPeriod";
            pnlPeriod.Radius = 8;
            pnlPeriod.Size = new Size(958, 40);
            pnlPeriod.TabIndex = 1;
            // 
            // lblPeriodo
            // 
            lblPeriodo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblPeriodo.AutoEllipsis = true;
            lblPeriodo.BackColor = Color.Transparent;
            lblPeriodo.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblPeriodo.ForeColor = Color.FromArgb(30, 41, 59);
            lblPeriodo.Location = new Point(14, 9);
            lblPeriodo.Margin = new Padding(0);
            lblPeriodo.Name = "lblPeriodo";
            lblPeriodo.Size = new Size(520, 22);
            lblPeriodo.TabIndex = 0;
            lblPeriodo.Text = "lblPeriodo";
            lblPeriodo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDefaultType
            // 
            lblDefaultType.BackColor = Color.Transparent;
            lblDefaultType.Font = new Font("Segoe UI", 9.5F);
            lblDefaultType.ForeColor = Color.FromArgb(51, 65, 85);
            lblDefaultType.Location = new Point(544, 6);
            lblDefaultType.Name = "lblDefaultType";
            lblDefaultType.Size = new Size(166, 28);
            lblDefaultType.TabIndex = 1;
            lblDefaultType.Text = "Inasistencia por defecto";
            lblDefaultType.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cboDefaultType
            // 
            cboDefaultType.BackColor = Color.White;
            cboDefaultType.BorderColorActive = Color.FromArgb(122, 44, 166);
            cboDefaultType.BorderColorNormal = Color.FromArgb(206, 212, 224);
            cboDefaultType.CornerRadius = 6;
            cboDefaultType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDefaultType.Enabled = false;
            cboDefaultType.Font = new Font("Segoe UI", 10F);
            cboDefaultType.FormattingEnabled = true;
            cboDefaultType.Location = new Point(716, 7);
            cboDefaultType.Margin = new Padding(0, 3, 3, 3);
            cboDefaultType.Name = "cboDefaultType";
            cboDefaultType.OuterColor = Color.FromArgb(240, 234, 250);
            cboDefaultType.Size = new Size(230, 25);
            cboDefaultType.TabIndex = 2;
            cboDefaultType.SelectedIndexChanged += cboDefaultType_SelectedIndexChanged;
            // 
            // pnlCardApply
            // 
            pnlCardApply.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlCardApply.Back = Color.White;
            pnlCardApply.BorderColor = Color.FromArgb(201, 184, 225);
            pnlCardApply.BorderWidth = 1F;
            pnlCardApply.Controls.Add(lblCardApply);
            pnlCardApply.Controls.Add(lblApplyType);
            pnlCardApply.Controls.Add(cboApplyType);
            pnlCardApply.Controls.Add(lblComments);
            pnlCardApply.Controls.Add(pnlCommentsInput);
            pnlCardApply.Controls.Add(btnApply);
            pnlCardApply.Controls.Add(btnClose);
            pnlCardApply.Controls.Add(btnDiscard);
            pnlCardApply.Controls.Add(btnSave);
            pnlCardApply.Controls.Add(lblPending);
            pnlCardApply.Controls.Add(divBottom);
            pnlCardApply.Controls.Add(lblHelp);
            pnlCardApply.Controls.Add(divTop);
            pnlCardApply.Location = new Point(12, 104);
            pnlCardApply.Name = "pnlCardApply";
            pnlCardApply.Radius = 10;
            pnlCardApply.Size = new Size(958, 195);
            pnlCardApply.TabIndex = 2;
            // 
            // lblCardApply
            // 
            lblCardApply.BackColor = Color.FromArgb(240, 232, 252);
            lblCardApply.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblCardApply.ForeColor = Color.FromArgb(122, 44, 166);
            lblCardApply.Location = new Point(14, 3);
            lblCardApply.Name = "lblCardApply";
            lblCardApply.Size = new Size(320, 28);
            lblCardApply.TabIndex = 0;
            lblCardApply.Text = "Aplicar a la selección de celdas";
            // 
            // divTop
            // 
            divTop.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            divTop.Back = Color.FromArgb(240, 232, 252);
            divTop.BackColor = Color.Transparent;
            divTop.Location = new Point(2, 2);
            divTop.Name = "divTop";
            divTop.Size = new Size(954, 32);
            divTop.TabIndex = 1;
            // 
            // lblApplyType
            // 
            lblApplyType.BackColor = Color.Transparent;
            lblApplyType.Font = new Font("Segoe UI", 10F);
            lblApplyType.ForeColor = Color.FromArgb(51, 65, 85);
            lblApplyType.Location = new Point(6, 40);
            lblApplyType.Name = "lblApplyType";
            lblApplyType.Size = new Size(78, 28);
            lblApplyType.TabIndex = 2;
            lblApplyType.Text = "Tipo";
            lblApplyType.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cboApplyType
            // 
            cboApplyType.BackColor = Color.White;
            cboApplyType.BorderColorActive = Color.FromArgb(122, 44, 166);
            cboApplyType.BorderColorNormal = Color.FromArgb(206, 212, 224);
            cboApplyType.CornerRadius = 6;
            cboApplyType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboApplyType.Font = new Font("Segoe UI", 10F);
            cboApplyType.FormattingEnabled = true;
            cboApplyType.Location = new Point(90, 42);
            cboApplyType.Margin = new Padding(0, 3, 3, 3);
            cboApplyType.Name = "cboApplyType";
            cboApplyType.OuterColor = Color.White;
            cboApplyType.Size = new Size(380, 25);
            cboApplyType.TabIndex = 3;
            // 
            // lblComments
            // 
            lblComments.BackColor = Color.Transparent;
            lblComments.Font = new Font("Segoe UI", 10F);
            lblComments.ForeColor = Color.FromArgb(51, 65, 85);
            lblComments.Location = new Point(6, 75);
            lblComments.Name = "lblComments";
            lblComments.Size = new Size(78, 28);
            lblComments.TabIndex = 4;
            lblComments.Text = "Comentario";
            lblComments.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pnlCommentsInput
            // 
            pnlCommentsInput.Back = Color.White;
            pnlCommentsInput.BackColor = Color.Transparent;
            pnlCommentsInput.BorderColor = Color.FromArgb(206, 212, 224);
            pnlCommentsInput.BorderWidth = 1F;
            pnlCommentsInput.Controls.Add(txbComments);
            pnlCommentsInput.Location = new Point(90, 74);
            pnlCommentsInput.Name = "pnlCommentsInput";
            pnlCommentsInput.Radius = 8;
            pnlCommentsInput.Size = new Size(380, 30);
            pnlCommentsInput.TabIndex = 5;
            // 
            // txbComments
            // 
            txbComments.BackColor = Color.White;
            txbComments.BorderStyle = BorderStyle.None;
            txbComments.Font = new Font("Segoe UI", 10F);
            txbComments.Location = new Point(9, 6);
            txbComments.Name = "txbComments";
            txbComments.Size = new Size(362, 18);
            txbComments.TabIndex = 0;
            // 
            // btnApply
            // 
            btnApply.BackActive = Color.FromArgb(98, 28, 138);
            btnApply.BackColor = Color.FromArgb(122, 44, 166);
            btnApply.BackHover = Color.FromArgb(140, 66, 186);
            btnApply.Cursor = Cursors.Hand;
            btnApply.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnApply.ForeColor = Color.White;
            btnApply.IconSize = new Size(16, 16);
            btnApply.IconSvg = "<svg viewBox=\"0 0 24 24\" xmlns=\"http://www.w3.org/2000/svg\"><path d=\"M12 2C6.48 2 2 6.48 2 12s4.48 10 10 10 10-4.48 10-10S17.52 2 12 2zm0 14l-5-5 1.41-1.41L12 13.17l3.59-3.58L17 11l-5 5z\"/></svg>";
            btnApply.Location = new Point(476, 71);
            btnApply.Name = "btnApply";
            btnApply.Radius = 8;
            btnApply.Size = new Size(163, 37);
            btnApply.TabIndex = 6;
            btnApply.Text = "Aplicar a la selección";
            btnApply.Type = AntdUI.TTypeMini.Primary;
            btnApply.Click += btnApply_Click;
            // 
            // btnClose
            // 
            btnClose.BackActive = Color.FromArgb(225, 210, 245);
            btnClose.BackHover = Color.FromArgb(240, 230, 250);
            btnClose.BorderWidth = 1.5F;
            btnClose.Cursor = Cursors.Hand;
            btnClose.DefaultBack = Color.White;
            btnClose.DefaultBorderColor = Color.FromArgb(122, 44, 166);
            btnClose.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnClose.ForeColor = Color.FromArgb(122, 44, 166);
            btnClose.IconSize = new Size(14, 14);
            btnClose.IconSvg = "<svg viewBox=\"0 0 24 24\" xmlns=\"http://www.w3.org/2000/svg\"><path d=\"M19 6.41L17.59 5 12 10.59 6.41 5 5 6.41 10.59 12 5 17.59 6.41 19 12 13.41 17.59 19 19 17.59 13.41 12z\"/></svg>";
            btnClose.Location = new Point(87, 109);
            btnClose.Name = "btnClose";
            btnClose.Radius = 8;
            btnClose.Size = new Size(81, 34);
            btnClose.TabIndex = 7;
            btnClose.Text = "Cerrar";
            btnClose.Click += btnClose_Click;
            // 
            // btnDiscard
            // 
            btnDiscard.BackActive = Color.FromArgb(225, 210, 245);
            btnDiscard.BackHover = Color.FromArgb(240, 230, 250);
            btnDiscard.BorderWidth = 1.5F;
            btnDiscard.Cursor = Cursors.Hand;
            btnDiscard.DefaultBack = Color.White;
            btnDiscard.DefaultBorderColor = Color.FromArgb(122, 44, 166);
            btnDiscard.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnDiscard.ForeColor = Color.FromArgb(122, 44, 166);
            btnDiscard.IconSize = new Size(16, 16);
            btnDiscard.IconSvg = resources.GetString("btnDiscard.IconSvg");
            btnDiscard.Location = new Point(174, 109);
            btnDiscard.Name = "btnDiscard";
            btnDiscard.Radius = 8;
            btnDiscard.Size = new Size(97, 34);
            btnDiscard.TabIndex = 8;
            btnDiscard.Text = "Descartar";
            btnDiscard.Click += btnDiscard_Click;
            // 
            // btnSave
            // 
            btnSave.BackActive = Color.FromArgb(98, 28, 138);
            btnSave.BackColor = Color.FromArgb(122, 44, 166);
            btnSave.BackHover = Color.FromArgb(140, 66, 186);
            btnSave.Cursor = Cursors.Hand;
            btnSave.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.IconSize = new Size(16, 16);
            btnSave.IconSvg = resources.GetString("btnSave.IconSvg");
            btnSave.Location = new Point(277, 109);
            btnSave.Name = "btnSave";
            btnSave.Radius = 8;
            btnSave.Size = new Size(95, 34);
            btnSave.TabIndex = 9;
            btnSave.Text = "Guardar";
            btnSave.Type = AntdUI.TTypeMini.Primary;
            btnSave.Click += btnSave_Click;
            // 
            // lblPending
            // 
            lblPending.BackColor = Color.Transparent;
            lblPending.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPending.ForeColor = Color.DarkOrange;
            lblPending.Location = new Point(375, 116);
            lblPending.Margin = new Padding(0);
            lblPending.Name = "lblPending";
            lblPending.Size = new Size(360, 20);
            lblPending.TabIndex = 10;
            lblPending.Text = "lblPending";
            lblPending.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // divBottom
            // 
            divBottom.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            divBottom.Back = Color.FromArgb(240, 232, 252);
            divBottom.BackColor = Color.Transparent;
            divBottom.Controls.Add(lblSelectedDays);
            divBottom.Controls.Add(lblSelectedDaysCaption);
            divBottom.Controls.Add(lblHint);
            divBottom.Location = new Point(8, 164);
            divBottom.Name = "divBottom";
            divBottom.Size = new Size(942, 23);
            divBottom.TabIndex = 12;
            // 
            // lblSelectedDaysCaption
            // 
            lblSelectedDaysCaption.BackColor = Color.Transparent;
            lblSelectedDaysCaption.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSelectedDaysCaption.ForeColor = Color.FromArgb(30, 41, 59);
            lblSelectedDaysCaption.Location = new Point(8, 1);
            lblSelectedDaysCaption.Name = "lblSelectedDaysCaption";
            lblSelectedDaysCaption.Size = new Size(138, 20);
            lblSelectedDaysCaption.TabIndex = 13;
            lblSelectedDaysCaption.Text = "Días seleccionados:";
            // 
            // lblSelectedDays
            // 
            lblSelectedDays.BackColor = Color.Transparent;
            lblSelectedDays.Font = new Font("Segoe UI", 11F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblSelectedDays.ForeColor = Color.FromArgb(30, 41, 59);
            lblSelectedDays.Location = new Point(136, -3);
            lblSelectedDays.Margin = new Padding(0);
            lblSelectedDays.Name = "lblSelectedDays";
            lblSelectedDays.Size = new Size(51, 26);
            lblSelectedDays.TabIndex = 14;
            lblSelectedDays.Text = "0";
            lblSelectedDays.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblHint
            // 
            lblHint.BackColor = Color.FromArgb(240, 232, 252);
            lblHint.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblHint.ForeColor = SystemColors.GrayText;
            lblHint.Location = new Point(191, 0);
            lblHint.Name = "lblHint";
            lblHint.Size = new Size(436, 22);
            lblHint.TabIndex = 15;
            lblHint.Text = "Arrastra con el mouse o usa Ctrl/Shift + clic para seleccionar varios días/empleados";
            lblHint.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblHelp
            // 
            lblHelp.BackColor = Color.Transparent;
            lblHelp.Font = new Font("Segoe UI", 8.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblHelp.ForeColor = Color.FromArgb(120, 130, 150);
            lblHelp.Location = new Point(93, 142);
            lblHelp.Name = "lblHelp";
            lblHelp.Size = new Size(420, 20);
            lblHelp.TabIndex = 11;
            lblHelp.Text = "ℹ Los cambios no se guardan hasta presionar \"Guardar\"";
            // 
            // pnlGrid
            // 
            pnlGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlGrid.Back = Color.White;
            pnlGrid.BorderColor = Color.FromArgb(201, 184, 225);
            pnlGrid.BorderWidth = 1F;
            pnlGrid.Controls.Add(dgvPivot);
            pnlGrid.Location = new Point(12, 305);
            pnlGrid.Name = "pnlGrid";
            pnlGrid.Radius = 8;
            pnlGrid.Size = new Size(958, 349);
            pnlGrid.TabIndex = 3;
            // 
            // dgvPivot
            // 
            dgvPivot.AllowUserToAddRows = false;
            dgvPivot.AllowUserToDeleteRows = false;
            dgvPivot.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPivot.BackgroundColor = Color.White;
            dgvPivot.BorderStyle = BorderStyle.None;
            dgvPivot.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(237, 228, 248);
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(48, 20, 78);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(237, 228, 248);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(48, 20, 78);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvPivot.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvPivot.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(222, 206, 244);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvPivot.DefaultCellStyle = dataGridViewCellStyle2;
            dgvPivot.EnableHeadersVisualStyles = false;
            dgvPivot.Font = new Font("Segoe UI", 10F);
            dgvPivot.GridColor = Color.FromArgb(214, 218, 230);
            dgvPivot.ImeMode = ImeMode.NoControl;
            dgvPivot.Location = new Point(4, 4);
            dgvPivot.Name = "dgvPivot";
            dgvPivot.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(237, 228, 248);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(48, 20, 78);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(237, 228, 248);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(48, 20, 78);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvPivot.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvPivot.RowHeadersVisible = false;
            dgvPivot.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvPivot.RowTemplate.Height = 30;
            dgvPivot.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvPivot.Size = new Size(950, 341);
            dgvPivot.TabIndex = 0;
            dgvPivot.CellFormatting += dgvPivot_CellFormatting;
            dgvPivot.CellPainting += dgvPivot_CellPainting;
            dgvPivot.CellToolTipTextNeeded += dgvPivot_CellToolTipTextNeeded;
            dgvPivot.SelectionChanged += dgvPivot_SelectionChanged;
            // 
            // FrmModifyAttendanceEmployees
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 245, 250);
            ClientSize = new Size(982, 666);
            Controls.Add(pnlGrid);
            Controls.Add(pnlCardApply);
            Controls.Add(pnlPeriod);
            Controls.Add(pnlHeader);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(900, 560);
            Name = "FrmModifyAttendanceEmployees";
            Text = "Modificar asistencias";
            WindowState = FormWindowState.Maximized;
            FormClosing += FrmModifyAttendanceEmployees_FormClosing;
            Load += FrmModifyAttendanceEmployees_Load;
            Shown += FrmModifyAttendanceEmployees_Shown;
            pnlHeader.ResumeLayout(false);
            pnlPeriod.ResumeLayout(false);
            pnlCardApply.ResumeLayout(false);
            pnlCommentsInput.ResumeLayout(false);
            pnlCommentsInput.PerformLayout();
            divBottom.ResumeLayout(false);
            pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPivot).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Panel pnlHeader;
        public AntdUI.Label lblTitle;
        private AntdUI.Panel pnlPeriod;
        public Label lblPeriodo;
        public Label lblPending;
        private AntdUI.Label lblDefaultType;
        public AntdComboBox cboDefaultType;
        private AntdUI.Panel pnlCardApply;
        private AntdUI.Label lblCardApply;
        private AntdUI.Panel divTop;
        private AntdUI.Panel divBottom;
        private AntdUI.Label lblHint;
        private AntdUI.Label lblHelp;
        public AntdUI.Button btnApply;
        public TextBox txbComments;
        private AntdUI.Panel pnlCommentsInput;
        private AntdUI.Label lblComments;
        public AntdComboBox cboApplyType;
        private AntdUI.Label lblApplyType;
        private AntdUI.Panel pnlGrid;
        public DataGridView dgvPivot;
        private AntdUI.Button btnClose;
        private AntdUI.Button btnDiscard;
        private AntdUI.Button btnSave;
        private AntdUI.Label lblSelectedDaysCaption;
        public Label lblSelectedDays;
        private ToolTip toolTip;
    }
}
