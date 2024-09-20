﻿namespace SisUvex.Nomina.Work_time
{
    partial class FrmWorkTimeCat
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
            dgvCatalog = new DataGridView();
            btnModify = new Button();
            btnAdd = new Button();
            cboProductionLine = new ComboBox();
            lblProductionLine = new Label();
            chbActiveProductionLine = new CheckBox();
            btnSearch = new Button();
            btnReportField = new Button();
            btnReportFacility = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvCatalog).BeginInit();
            SuspendLayout();
            // 
            // dgvCatalog
            // 
            dgvCatalog.AllowUserToAddRows = false;
            dgvCatalog.AllowUserToDeleteRows = false;
            dgvCatalog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCatalog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvCatalog.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvCatalog.BackgroundColor = SystemColors.ControlLightLight;
            dgvCatalog.BorderStyle = BorderStyle.Fixed3D;
            dgvCatalog.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvCatalog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvCatalog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvCatalog.EnableHeadersVisualStyles = false;
            dgvCatalog.ImeMode = ImeMode.NoControl;
            dgvCatalog.Location = new Point(12, 36);
            dgvCatalog.Name = "dgvCatalog";
            dgvCatalog.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvCatalog.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvCatalog.RowHeadersVisible = false;
            dgvCatalog.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvCatalog.RowTemplate.Height = 25;
            dgvCatalog.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCatalog.Size = new Size(776, 402);
            dgvCatalog.TabIndex = 23;
            dgvCatalog.DoubleClick += dgvCatalog_DoubleClick;
            // 
            // btnModify
            // 
            btnModify.Location = new Point(76, 8);
            btnModify.Name = "btnModify";
            btnModify.Size = new Size(75, 23);
            btnModify.TabIndex = 2;
            btnModify.Text = "Modificar";
            btnModify.UseVisualStyleBackColor = true;
            btnModify.Click += btnModify_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(12, 8);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(58, 23);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Añadir";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // cboProductionLine
            // 
            cboProductionLine.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProductionLine.FormattingEnabled = true;
            cboProductionLine.ItemHeight = 15;
            cboProductionLine.Location = new Point(236, 8);
            cboProductionLine.Name = "cboProductionLine";
            cboProductionLine.Size = new Size(194, 23);
            cboProductionLine.TabIndex = 4;
            // 
            // lblProductionLine
            // 
            lblProductionLine.AutoSize = true;
            lblProductionLine.Location = new Point(162, 12);
            lblProductionLine.Name = "lblProductionLine";
            lblProductionLine.Size = new Size(43, 15);
            lblProductionLine.TabIndex = 27;
            lblProductionLine.Text = "Banda:";
            // 
            // chbActiveProductionLine
            // 
            chbActiveProductionLine.Appearance = Appearance.Button;
            chbActiveProductionLine.AutoSize = true;
            chbActiveProductionLine.BackgroundImage = Properties.Resources.Imagen6;
            chbActiveProductionLine.BackgroundImageLayout = ImageLayout.Stretch;
            chbActiveProductionLine.Font = new Font("Segoe UI", 9F);
            chbActiveProductionLine.Location = new Point(203, 7);
            chbActiveProductionLine.Name = "chbActiveProductionLine";
            chbActiveProductionLine.Size = new Size(32, 25);
            chbActiveProductionLine.TabIndex = 3;
            chbActiveProductionLine.Text = "     ";
            chbActiveProductionLine.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            btnSearch.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearch.Font = new Font("Segoe UI", 14F);
            btnSearch.Image = Properties.Resources.BuscarLupa1;
            btnSearch.Location = new Point(431, 7);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(25, 25);
            btnSearch.TabIndex = 5;
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnReportField
            // 
            btnReportField.Location = new Point(543, 8);
            btnReportField.Name = "btnReportField";
            btnReportField.Size = new Size(70, 23);
            btnReportField.TabIndex = 28;
            btnReportField.Text = "Campo";
            btnReportField.UseVisualStyleBackColor = true;
            btnReportField.Click += btnReportField_Click;
            // 
            // btnReportFacility
            // 
            btnReportFacility.Location = new Point(619, 8);
            btnReportFacility.Name = "btnReportFacility";
            btnReportFacility.Size = new Size(70, 23);
            btnReportFacility.TabIndex = 29;
            btnReportFacility.Text = "Empaque";
            btnReportFacility.UseVisualStyleBackColor = true;
            btnReportFacility.Click += btnReportFacility_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(491, 12);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 30;
            label1.Text = "Reporte:";
            // 
            // FrmWorkTimeCat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnReportFacility);
            Controls.Add(btnReportField);
            Controls.Add(btnSearch);
            Controls.Add(chbActiveProductionLine);
            Controls.Add(lblProductionLine);
            Controls.Add(cboProductionLine);
            Controls.Add(btnModify);
            Controls.Add(btnAdd);
            Controls.Add(dgvCatalog);
            Controls.Add(label1);
            Name = "FrmWorkTimeCat";
            Text = "Horarios de empaque";
            WindowState = FormWindowState.Maximized;
            Load += FrmWorkTimeCat_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCatalog).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public DataGridView dgvCatalog;
        private Button btnModify;
        private Button btnAdd;
        private Label lblProductionLine;
        public CheckBox chbActiveProductionLine;
        public ComboBox cboProductionLine;
        private Button btnSearch;
        private Button btnReportField;
        private Button btnReportFacility;
        private Label label1;
    }
}