namespace SisUvex.Nomina.Comedores.DiningReports.AbsenceReport
{
    partial class FrmAbsenceReport
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
            GroupBox groupBox2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAbsenceReport));
            dgvQuery = new DataGridView();
            dtpDate2 = new DateTimePicker();
            dtpDate1 = new DateTimePicker();
            lblY = new Label();
            lblTitle = new Label();
            dtpDate3 = new DateTimePicker();
            label1 = new Label();
            btnReport = new Button();
            label2 = new Label();
            label3 = new Label();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dgvQuery).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // dgvQuery
            // 
            dgvQuery.AllowUserToAddRows = false;
            dgvQuery.AllowUserToDeleteRows = false;
            dgvQuery.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvQuery.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvQuery.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvQuery.BackgroundColor = SystemColors.Control;
            dgvQuery.BorderStyle = BorderStyle.Fixed3D;
            dgvQuery.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvQuery.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvQuery.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvQuery.EnableHeadersVisualStyles = false;
            dgvQuery.ImeMode = ImeMode.NoControl;
            dgvQuery.Location = new Point(12, 109);
            dgvQuery.Name = "dgvQuery";
            dgvQuery.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvQuery.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvQuery.RowHeadersVisible = false;
            dgvQuery.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvQuery.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvQuery.Size = new Size(776, 329);
            dgvQuery.TabIndex = 12;
            // 
            // dtpDate2
            // 
            dtpDate2.Format = DateTimePickerFormat.Short;
            dtpDate2.Location = new Point(126, 74);
            dtpDate2.Name = "dtpDate2";
            dtpDate2.Size = new Size(80, 23);
            dtpDate2.TabIndex = 49;
            // 
            // dtpDate1
            // 
            dtpDate1.Format = DateTimePickerFormat.Short;
            dtpDate1.Location = new Point(6, 16);
            dtpDate1.Name = "dtpDate1";
            dtpDate1.Size = new Size(80, 23);
            dtpDate1.TabIndex = 48;
            // 
            // lblY
            // 
            lblY.AutoSize = true;
            lblY.Location = new Point(92, 22);
            lblY.Name = "lblY";
            lblY.Size = new Size(16, 15);
            lblY.TabIndex = 50;
            lblY.Text = "al";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial Black", 12F);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(195, 23);
            lblTitle.TabIndex = 250;
            lblTitle.Text = "Reporte de ausentes";
            // 
            // dtpDate3
            // 
            dtpDate3.Format = DateTimePickerFormat.Short;
            dtpDate3.Location = new Point(79, 16);
            dtpDate3.Name = "dtpDate3";
            dtpDate3.Size = new Size(80, 23);
            dtpDate3.TabIndex = 251;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(57, 22);
            label1.Name = "label1";
            label1.Size = new Size(16, 15);
            label1.TabIndex = 252;
            label1.Text = "al";
            // 
            // btnReport
            // 
            btnReport.Image = Properties.Resources.buscarIcon16;
            btnReport.Location = new Point(326, 74);
            btnReport.Name = "btnReport";
            btnReport.Size = new Size(24, 25);
            btnReport.TabIndex = 253;
            btnReport.UseVisualStyleBackColor = true;
            btnReport.Click += btnReport_Click;
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Location = new Point(161, 46);
            label2.Name = "label2";
            label2.Size = new Size(159, 20);
            label2.TabIndex = 254;
            label2.Text = "Rango ausente";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // label3
            // 
            label3.Location = new Point(9, 46);
            label3.Name = "label3";
            label3.Size = new Size(197, 20);
            label3.TabIndex = 255;
            label3.Text = "Rango trabajado";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.FromArgb(192, 255, 192);
            groupBox1.Controls.Add(dtpDate1);
            groupBox1.Controls.Add(lblY);
            groupBox1.Location = new Point(13, 58);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(155, 48);
            groupBox1.TabIndex = 256;
            groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            groupBox2.AccessibleRole = AccessibleRole.None;
            groupBox2.BackColor = Color.FromArgb(255, 192, 192);
            groupBox2.Controls.Add(dtpDate3);
            groupBox2.Controls.Add(label1);
            groupBox2.FlatStyle = FlatStyle.System;
            groupBox2.ImeMode = ImeMode.NoControl;
            groupBox2.Location = new Point(155, 58);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(165, 47);
            groupBox2.TabIndex = 257;
            groupBox2.TabStop = false;
            // 
            // FrmAbsenceReport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dtpDate2);
            Controls.Add(label2);
            Controls.Add(btnReport);
            Controls.Add(lblTitle);
            Controls.Add(dgvQuery);
            Controls.Add(label3);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmAbsenceReport";
            Text = "Reporte de ausentes";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)dgvQuery).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public DataGridView dgvQuery;
        public DateTimePicker dtpDate2;
        public DateTimePicker dtpDate1;
        private Label lblY;
        public Label lblTitle;
        public DateTimePicker dtpDate3;
        private Label label1;
        private Button btnReport;
        private Label label2;
        private Label label3;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
    }
}