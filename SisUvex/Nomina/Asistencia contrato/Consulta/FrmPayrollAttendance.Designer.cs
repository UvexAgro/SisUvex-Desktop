namespace SisUvex.Nomina.Asistencia_contrato.Consulta
{
    partial class FrmPayrollAttendance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPayrollAttendance));
            gpbFilters = new GroupBox();
            lblField = new Label();
            label1 = new Label();
            cboPeriod = new ComboBox();
            cboContractor = new ComboBox();
            label10 = new Label();
            cboPaymentPlace = new ComboBox();
            cboWorkGroup = new ComboBox();
            label11 = new Label();
            btnLoadPlantsLot = new Button();
            dgvAttendence = new DataGridView();
            bgpLotInfo = new GroupBox();
            lblPaymentPlace = new Label();
            label5 = new Label();
            lblWorkGroup = new Label();
            label2 = new Label();
            lblContractor = new Label();
            label3 = new Label();
            lblPeriod = new Label();
            label7 = new Label();
            gpbFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAttendence).BeginInit();
            bgpLotInfo.SuspendLayout();
            SuspendLayout();
            // 
            // gpbFilters
            // 
            gpbFilters.Controls.Add(lblField);
            gpbFilters.Controls.Add(label1);
            gpbFilters.Controls.Add(cboPeriod);
            gpbFilters.Controls.Add(cboContractor);
            gpbFilters.Controls.Add(label10);
            gpbFilters.Controls.Add(cboPaymentPlace);
            gpbFilters.Controls.Add(cboWorkGroup);
            gpbFilters.Controls.Add(label11);
            gpbFilters.Font = new Font("Segoe UI", 12F);
            gpbFilters.Location = new Point(12, 12);
            gpbFilters.Name = "gpbFilters";
            gpbFilters.Size = new Size(855, 100);
            gpbFilters.TabIndex = 51;
            gpbFilters.TabStop = false;
            gpbFilters.Text = "Filtros";
            // 
            // lblField
            // 
            lblField.AutoSize = true;
            lblField.Location = new Point(565, 26);
            lblField.Margin = new Padding(0);
            lblField.Name = "lblField";
            lblField.Size = new Size(86, 21);
            lblField.TabIndex = 22;
            lblField.Text = "Contratista";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 59);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(110, 21);
            label1.TabIndex = 26;
            label1.Text = "Lugar de pago";
            // 
            // cboPeriod
            // 
            cboPeriod.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPeriod.FormattingEnabled = true;
            cboPeriod.Location = new Point(123, 23);
            cboPeriod.Margin = new Padding(0, 3, 3, 3);
            cboPeriod.Name = "cboPeriod";
            cboPeriod.Size = new Size(331, 29);
            cboPeriod.TabIndex = 47;
            // 
            // cboContractor
            // 
            cboContractor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboContractor.FormattingEnabled = true;
            cboContractor.Location = new Point(651, 21);
            cboContractor.Margin = new Padding(0, 3, 3, 3);
            cboContractor.Name = "cboContractor";
            cboContractor.Size = new Size(190, 29);
            cboContractor.TabIndex = 24;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(486, 59);
            label10.Margin = new Padding(0);
            label10.Name = "label10";
            label10.Size = new Size(72, 21);
            label10.TabIndex = 44;
            label10.Text = "Cuadrilla";
            // 
            // cboPaymentPlace
            // 
            cboPaymentPlace.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPaymentPlace.FlatStyle = FlatStyle.System;
            cboPaymentPlace.FormattingEnabled = true;
            cboPaymentPlace.Location = new Point(123, 56);
            cboPaymentPlace.Margin = new Padding(0, 3, 3, 3);
            cboPaymentPlace.Name = "cboPaymentPlace";
            cboPaymentPlace.Size = new Size(360, 29);
            cboPaymentPlace.TabIndex = 27;
            // 
            // cboWorkGroup
            // 
            cboWorkGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            cboWorkGroup.FormattingEnabled = true;
            cboWorkGroup.Location = new Point(558, 56);
            cboWorkGroup.Margin = new Padding(0, 3, 3, 3);
            cboWorkGroup.Name = "cboWorkGroup";
            cboWorkGroup.Size = new Size(283, 29);
            cboWorkGroup.TabIndex = 45;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(57, 28);
            label11.Margin = new Padding(0);
            label11.Name = "label11";
            label11.Size = new Size(66, 21);
            label11.TabIndex = 46;
            label11.Text = "Semana";
            // 
            // btnLoadPlantsLot
            // 
            btnLoadPlantsLot.Font = new Font("Segoe UI", 12F);
            btnLoadPlantsLot.Image = Properties.Resources.BuscarLupa1;
            btnLoadPlantsLot.ImageAlign = ContentAlignment.MiddleRight;
            btnLoadPlantsLot.Location = new Point(782, 120);
            btnLoadPlantsLot.Name = "btnLoadPlantsLot";
            btnLoadPlantsLot.Padding = new Padding(0, 0, 4, 0);
            btnLoadPlantsLot.Size = new Size(87, 31);
            btnLoadPlantsLot.TabIndex = 68;
            btnLoadPlantsLot.Text = "Buscar";
            btnLoadPlantsLot.TextAlign = ContentAlignment.TopLeft;
            btnLoadPlantsLot.UseVisualStyleBackColor = true;
            btnLoadPlantsLot.Click += btnLoadPlantsLot_Click;
            // 
            // dgvAttendence
            // 
            dgvAttendence.AllowUserToAddRows = false;
            dgvAttendence.AllowUserToDeleteRows = false;
            dgvAttendence.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvAttendence.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvAttendence.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvAttendence.BackgroundColor = SystemColors.Control;
            dgvAttendence.BorderStyle = BorderStyle.Fixed3D;
            dgvAttendence.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvAttendence.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvAttendence.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvAttendence.EnableHeadersVisualStyles = false;
            dgvAttendence.ImeMode = ImeMode.NoControl;
            dgvAttendence.Location = new Point(12, 247);
            dgvAttendence.Name = "dgvAttendence";
            dgvAttendence.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvAttendence.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvAttendence.RowHeadersVisible = false;
            dgvAttendence.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvAttendence.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAttendence.Size = new Size(857, 377);
            dgvAttendence.TabIndex = 69;
            // 
            // bgpLotInfo
            // 
            bgpLotInfo.Controls.Add(lblPaymentPlace);
            bgpLotInfo.Controls.Add(label5);
            bgpLotInfo.Controls.Add(lblWorkGroup);
            bgpLotInfo.Controls.Add(label2);
            bgpLotInfo.Controls.Add(lblContractor);
            bgpLotInfo.Controls.Add(label3);
            bgpLotInfo.Controls.Add(lblPeriod);
            bgpLotInfo.Controls.Add(label7);
            bgpLotInfo.Font = new Font("Segoe UI", 12F);
            bgpLotInfo.Location = new Point(12, 111);
            bgpLotInfo.Name = "bgpLotInfo";
            bgpLotInfo.Size = new Size(761, 130);
            bgpLotInfo.TabIndex = 70;
            bgpLotInfo.TabStop = false;
            bgpLotInfo.Text = "Detalles";
            // 
            // lblPaymentPlace
            // 
            lblPaymentPlace.AutoSize = true;
            lblPaymentPlace.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblPaymentPlace.Location = new Point(134, 88);
            lblPaymentPlace.Margin = new Padding(0);
            lblPaymentPlace.Name = "lblPaymentPlace";
            lblPaymentPlace.Size = new Size(139, 21);
            lblPaymentPlace.TabIndex = 60;
            lblPaymentPlace.Tag = "lotData";
            lblPaymentPlace.Text = "lblPaymentPlace";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(21, 88);
            label5.Margin = new Padding(0);
            label5.Name = "label5";
            label5.Size = new Size(113, 21);
            label5.TabIndex = 59;
            label5.Text = "Lugar de pago:";
            label5.TextAlign = ContentAlignment.TopRight;
            // 
            // lblWorkGroup
            // 
            lblWorkGroup.AutoSize = true;
            lblWorkGroup.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblWorkGroup.Location = new Point(96, 67);
            lblWorkGroup.Margin = new Padding(0);
            lblWorkGroup.Name = "lblWorkGroup";
            lblWorkGroup.Size = new Size(118, 21);
            lblWorkGroup.TabIndex = 58;
            lblWorkGroup.Tag = "lotData";
            lblWorkGroup.Text = "lblWorkGroup";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 67);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Size = new Size(75, 21);
            label2.TabIndex = 57;
            label2.Text = "Cuadrilla:";
            label2.TextAlign = ContentAlignment.TopRight;
            // 
            // lblContractor
            // 
            lblContractor.AutoSize = true;
            lblContractor.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblContractor.Location = new Point(96, 46);
            lblContractor.Margin = new Padding(0);
            lblContractor.Name = "lblContractor";
            lblContractor.Size = new Size(111, 21);
            lblContractor.TabIndex = 56;
            lblContractor.Tag = "lotData";
            lblContractor.Text = "lblContractor";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(7, 46);
            label3.Margin = new Padding(0);
            label3.Name = "label3";
            label3.Size = new Size(89, 21);
            label3.TabIndex = 55;
            label3.Text = "Contratista:";
            label3.TextAlign = ContentAlignment.TopRight;
            // 
            // lblPeriod
            // 
            lblPeriod.AutoSize = true;
            lblPeriod.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblPeriod.Location = new Point(96, 25);
            lblPeriod.Margin = new Padding(0);
            lblPeriod.Name = "lblPeriod";
            lblPeriod.Size = new Size(80, 21);
            lblPeriod.TabIndex = 54;
            lblPeriod.Tag = "lotData";
            lblPeriod.Text = "lblPeriod";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(27, 25);
            label7.Margin = new Padding(0);
            label7.Name = "label7";
            label7.Size = new Size(69, 21);
            label7.TabIndex = 52;
            label7.Text = "Semana:";
            label7.TextAlign = ContentAlignment.TopRight;
            // 
            // FrmPayrollAttendance
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(881, 636);
            Controls.Add(btnLoadPlantsLot);
            Controls.Add(bgpLotInfo);
            Controls.Add(dgvAttendence);
            Controls.Add(gpbFilters);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmPayrollAttendance";
            Text = "Asistencia de contrato";
            Load += FrmPayrollAttendance_Load;
            gpbFilters.ResumeLayout(false);
            gpbFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAttendence).EndInit();
            bgpLotInfo.ResumeLayout(false);
            bgpLotInfo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gpbFilters;
        private Label lblField;
        private Label label1;
        public ComboBox cboPeriod;
        public ComboBox cboContractor;
        public ComboBox cboPaymentPlace;
        private Label label11;
        private Label label10;
        public ComboBox cboWorkGroup;
        private Button btnLoadPlantsLot;
        public DataGridView dgvAttendence;
        private GroupBox bgpLotInfo;
        public Label lblPeriod;
        private Label label7;
        public Label lblPaymentPlace;
        private Label label5;
        public Label lblWorkGroup;
        private Label label2;
        public Label lblContractor;
        private Label label3;
    }
}