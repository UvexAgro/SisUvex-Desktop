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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmModifyAttendanceEmployees));
            lblTitle = new Label();
            lblPeriodo = new Label();
            lblPending = new Label();
            lblDefaultType = new Label();
            cboDefaultType = new ComboBox();
            gpbApply = new GroupBox();
            label1 = new Label();
            btnApply = new Button();
            txbComments = new TextBox();
            lblComments = new Label();
            cboApplyType = new ComboBox();
            lblApplyType = new Label();
            dgvPivot = new DataGridView();
            btnClose = new Button();
            btnDiscard = new Button();
            btnSave = new Button();
            lblHelp = new Label();
            gpbApply.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPivot).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Margin = new Padding(0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(170, 21);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Modificar asistencias";
            // 
            // lblPeriodo
            // 
            lblPeriodo.AutoSize = true;
            lblPeriodo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblPeriodo.ForeColor = Color.Gray;
            lblPeriodo.Location = new Point(14, 39);
            lblPeriodo.Margin = new Padding(0);
            lblPeriodo.Name = "lblPeriodo";
            lblPeriodo.Size = new Size(104, 25);
            lblPeriodo.TabIndex = 1;
            lblPeriodo.Text = "lblPeriodo";
            // 
            // lblPending
            // 
            lblPending.AutoSize = true;
            lblPending.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblPending.ForeColor = Color.DarkOrange;
            lblPending.Location = new Point(490, 64);
            lblPending.Margin = new Padding(0);
            lblPending.Name = "lblPending";
            lblPending.Size = new Size(90, 21);
            lblPending.TabIndex = 2;
            lblPending.Text = "lblPending";
            // 
            // lblDefaultType
            // 
            lblDefaultType.AutoSize = true;
            lblDefaultType.Location = new Point(618, 66);
            lblDefaultType.Margin = new Padding(0);
            lblDefaultType.Name = "lblDefaultType";
            lblDefaultType.Size = new Size(132, 15);
            lblDefaultType.TabIndex = 10;
            lblDefaultType.Text = "Inasistencia por defecto";
            // 
            // cboDefaultType
            // 
            cboDefaultType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDefaultType.FormattingEnabled = true;
            cboDefaultType.Location = new Point(750, 63);
            cboDefaultType.Margin = new Padding(0, 3, 3, 3);
            cboDefaultType.Name = "cboDefaultType";
            cboDefaultType.Size = new Size(220, 23);
            cboDefaultType.TabIndex = 11;
            cboDefaultType.SelectedIndexChanged += cboDefaultType_SelectedIndexChanged;
            // 
            // gpbApply
            // 
            gpbApply.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gpbApply.Controls.Add(label1);
            gpbApply.Controls.Add(btnApply);
            gpbApply.Controls.Add(txbComments);
            gpbApply.Controls.Add(lblComments);
            gpbApply.Controls.Add(cboApplyType);
            gpbApply.Controls.Add(lblApplyType);
            gpbApply.Controls.Add(lblPending);
            gpbApply.Font = new Font("Segoe UI", 10F);
            gpbApply.Location = new Point(12, 92);
            gpbApply.Name = "gpbApply";
            gpbApply.Size = new Size(958, 93);
            gpbApply.TabIndex = 3;
            gpbApply.TabStop = false;
            gpbApply.Text = "Aplicar a la selección de celdas";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            label1.ForeColor = Color.Gray;
            label1.Location = new Point(0, 69);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(445, 15);
            label1.TabIndex = 12;
            label1.Text = " (arrastra con el mouse o usa Ctrl/Shift+clic para seleccionar varios días/empleados)";
            // 
            // btnApply
            // 
            btnApply.Font = new Font("Segoe UI", 11F);
            btnApply.Image = Properties.Resources.downIcon16;
            btnApply.ImageAlign = ContentAlignment.MiddleLeft;
            btnApply.Location = new Point(806, 29);
            btnApply.Name = "btnApply";
            btnApply.Padding = new Padding(4, 0, 1, 0);
            btnApply.Size = new Size(96, 29);
            btnApply.TabIndex = 4;
            btnApply.Text = "Aplicar a selección";
            btnApply.TextAlign = ContentAlignment.MiddleRight;
            btnApply.UseVisualStyleBackColor = true;
            btnApply.Click += btnApply_Click;
            // 
            // txbComments
            // 
            txbComments.Font = new Font("Segoe UI", 11F);
            txbComments.Location = new Point(490, 30);
            txbComments.Margin = new Padding(0, 3, 3, 3);
            txbComments.Name = "txbComments";
            txbComments.Size = new Size(300, 27);
            txbComments.TabIndex = 3;
            // 
            // lblComments
            // 
            lblComments.AutoSize = true;
            lblComments.Font = new Font("Segoe UI", 11F);
            lblComments.Location = new Point(403, 33);
            lblComments.Margin = new Padding(0);
            lblComments.Name = "lblComments";
            lblComments.Size = new Size(87, 20);
            lblComments.TabIndex = 2;
            lblComments.Text = "Comentario";
            // 
            // cboApplyType
            // 
            cboApplyType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboApplyType.Font = new Font("Segoe UI", 11F);
            cboApplyType.FormattingEnabled = true;
            cboApplyType.Location = new Point(56, 29);
            cboApplyType.Margin = new Padding(0, 3, 3, 3);
            cboApplyType.Name = "cboApplyType";
            cboApplyType.Size = new Size(310, 28);
            cboApplyType.TabIndex = 1;
            // 
            // lblApplyType
            // 
            lblApplyType.AutoSize = true;
            lblApplyType.Font = new Font("Segoe UI", 11F);
            lblApplyType.Location = new Point(17, 33);
            lblApplyType.Margin = new Padding(0);
            lblApplyType.Name = "lblApplyType";
            lblApplyType.Size = new Size(39, 20);
            lblApplyType.TabIndex = 0;
            lblApplyType.Text = "Tipo";
            // 
            // dgvPivot
            // 
            dgvPivot.AllowUserToAddRows = false;
            dgvPivot.AllowUserToDeleteRows = false;
            dgvPivot.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPivot.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvPivot.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvPivot.BackgroundColor = SystemColors.Control;
            dgvPivot.BorderStyle = BorderStyle.Fixed3D;
            dgvPivot.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvPivot.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvPivot.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPivot.EnableHeadersVisualStyles = false;
            dgvPivot.ImeMode = ImeMode.NoControl;
            dgvPivot.Location = new Point(12, 191);
            dgvPivot.Name = "dgvPivot";
            dgvPivot.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvPivot.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvPivot.RowHeadersVisible = false;
            dgvPivot.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvPivot.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvPivot.Size = new Size(958, 420);
            dgvPivot.TabIndex = 5;
            dgvPivot.CellFormatting += dgvPivot_CellFormatting;
            dgvPivot.CellPainting += dgvPivot_CellPainting;
            dgvPivot.CellToolTipTextNeeded += dgvPivot_CellToolTipTextNeeded;
            dgvPivot.SelectionChanged += dgvPivot_SelectionChanged;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.Font = new Font("Segoe UI", 11F);
            btnClose.Location = new Point(895, 623);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 31);
            btnClose.TabIndex = 8;
            btnClose.Text = "Cerrar";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnDiscard
            // 
            btnDiscard.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDiscard.Font = new Font("Segoe UI", 11F);
            btnDiscard.Location = new Point(769, 623);
            btnDiscard.Name = "btnDiscard";
            btnDiscard.Size = new Size(120, 31);
            btnDiscard.TabIndex = 7;
            btnDiscard.Text = "Descartar";
            btnDiscard.UseVisualStyleBackColor = true;
            btnDiscard.Click += btnDiscard_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSave.Location = new Point(639, 623);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(124, 31);
            btnSave.TabIndex = 6;
            btnSave.Text = "Guardar";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // lblHelp
            // 
            lblHelp.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblHelp.AutoSize = true;
            lblHelp.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblHelp.ForeColor = Color.Gray;
            lblHelp.Location = new Point(14, 629);
            lblHelp.Margin = new Padding(0);
            lblHelp.Name = "lblHelp";
            lblHelp.Size = new Size(304, 15);
            lblHelp.TabIndex = 9;
            lblHelp.Text = "ℹ Los cambios no se guardan hasta presionar \"Guardar\"";
            // 
            // FrmModifyAttendanceEmployees
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 666);
            Controls.Add(lblHelp);
            Controls.Add(btnClose);
            Controls.Add(btnDiscard);
            Controls.Add(btnSave);
            Controls.Add(dgvPivot);
            Controls.Add(gpbApply);
            Controls.Add(cboDefaultType);
            Controls.Add(lblDefaultType);
            Controls.Add(lblPeriodo);
            Controls.Add(lblTitle);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(700, 400);
            Name = "FrmModifyAttendanceEmployees";
            Text = "Modificar asistencias";
            WindowState = FormWindowState.Maximized;
            FormClosing += FrmModifyAttendanceEmployees_FormClosing;
            Load += FrmModifyAttendanceEmployees_Load;
            Shown += FrmModifyAttendanceEmployees_Shown;
            gpbApply.ResumeLayout(false);
            gpbApply.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPivot).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Label lblTitle;
        public Label lblPeriodo;
        public Label lblPending;
        private Label lblDefaultType;
        public ComboBox cboDefaultType;
        private GroupBox gpbApply;
        public Button btnApply;
        public TextBox txbComments;
        private Label lblComments;
        public ComboBox cboApplyType;
        private Label lblApplyType;
        public DataGridView dgvPivot;
        private Button btnClose;
        private Button btnDiscard;
        private Button btnSave;
        private Label lblHelp;
        public Label label1;
    }
}
