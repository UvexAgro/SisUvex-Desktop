namespace SisUvex.Nomina.Poda.Reporte_lineas
{
    partial class FrmPayrollPruningReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPayrollPruningReport));
            label6 = new Label();
            cboWorkGroup = new ComboBox();
            label7 = new Label();
            cboLot = new ComboBox();
            label5 = new Label();
            dtpDate2 = new DateTimePicker();
            dtpDate1 = new DateTimePicker();
            label4 = new Label();
            btnDownload = new Button();
            lblTitle = new Label();
            label1 = new Label();
            cboContractor = new ComboBox();
            label2 = new Label();
            cboSeason = new ComboBox();
            groupBox1 = new GroupBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label6.Location = new Point(22, 228);
            label6.Margin = new Padding(3);
            label6.Name = "label6";
            label6.Size = new Size(79, 21);
            label6.TabIndex = 47;
            label6.Text = "Cuadrilla";
            // 
            // cboWorkGroup
            // 
            cboWorkGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            cboWorkGroup.DropDownWidth = 400;
            cboWorkGroup.Font = new Font("Microsoft Sans Serif", 12F);
            cboWorkGroup.FormattingEnabled = true;
            cboWorkGroup.Location = new Point(26, 251);
            cboWorkGroup.Name = "cboWorkGroup";
            cboWorkGroup.Size = new Size(264, 28);
            cboWorkGroup.TabIndex = 44;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label7.Location = new Point(22, 285);
            label7.Margin = new Padding(3);
            label7.Name = "label7";
            label7.Size = new Size(43, 21);
            label7.TabIndex = 46;
            label7.Text = "Lote";
            // 
            // cboLot
            // 
            cboLot.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLot.DropDownWidth = 400;
            cboLot.Font = new Font("Microsoft Sans Serif", 12F);
            cboLot.FormattingEnabled = true;
            cboLot.Location = new Point(26, 308);
            cboLot.Name = "cboLot";
            cboLot.Size = new Size(264, 28);
            cboLot.TabIndex = 45;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.Location = new Point(12, 36);
            label5.Name = "label5";
            label5.Size = new Size(50, 21);
            label5.TabIndex = 50;
            label5.Text = "Entre";
            // 
            // dtpDate2
            // 
            dtpDate2.Font = new Font("Microsoft Sans Serif", 12F);
            dtpDate2.Format = DateTimePickerFormat.Short;
            dtpDate2.Location = new Point(162, 59);
            dtpDate2.Name = "dtpDate2";
            dtpDate2.Size = new Size(118, 26);
            dtpDate2.TabIndex = 49;
            // 
            // dtpDate1
            // 
            dtpDate1.Font = new Font("Microsoft Sans Serif", 12F);
            dtpDate1.Format = DateTimePickerFormat.Short;
            dtpDate1.Location = new Point(16, 59);
            dtpDate1.Name = "dtpDate1";
            dtpDate1.Size = new Size(118, 26);
            dtpDate1.TabIndex = 48;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.Location = new Point(140, 65);
            label4.Name = "label4";
            label4.Size = new Size(19, 21);
            label4.TabIndex = 51;
            label4.Text = "y";
            // 
            // btnDownload
            // 
            btnDownload.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDownload.BackgroundImageLayout = ImageLayout.Stretch;
            btnDownload.Font = new Font("Microsoft Sans Serif", 12F);
            btnDownload.Image = Properties.Resources.excelIcon;
            btnDownload.ImageAlign = ContentAlignment.MiddleRight;
            btnDownload.Location = new Point(106, 358);
            btnDownload.Margin = new Padding(3, 3, 3, 0);
            btnDownload.Name = "btnDownload";
            btnDownload.Size = new Size(183, 31);
            btnDownload.TabIndex = 52;
            btnDownload.Text = "Descargar excel";
            btnDownload.TextAlign = ContentAlignment.MiddleLeft;
            btnDownload.UseVisualStyleBackColor = true;
            btnDownload.Click += btnDownload_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(241, 20);
            lblTitle.TabIndex = 53;
            lblTitle.Text = "Generar reporte de poda en Excel";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(6, 72);
            label1.Margin = new Padding(3);
            label1.Name = "label1";
            label1.Size = new Size(94, 21);
            label1.TabIndex = 55;
            label1.Text = "Contratista";
            // 
            // cboContractor
            // 
            cboContractor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboContractor.DropDownWidth = 400;
            cboContractor.Font = new Font("Microsoft Sans Serif", 12F);
            cboContractor.FormattingEnabled = true;
            cboContractor.Location = new Point(10, 95);
            cboContractor.Name = "cboContractor";
            cboContractor.Size = new Size(264, 28);
            cboContractor.TabIndex = 54;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(6, 15);
            label2.Margin = new Padding(3);
            label2.Name = "label2";
            label2.Size = new Size(96, 21);
            label2.TabIndex = 57;
            label2.Text = "Temporada";
            // 
            // cboSeason
            // 
            cboSeason.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSeason.DropDownWidth = 400;
            cboSeason.Font = new Font("Microsoft Sans Serif", 12F);
            cboSeason.FormattingEnabled = true;
            cboSeason.Location = new Point(10, 38);
            cboSeason.Name = "cboSeason";
            cboSeason.Size = new Size(264, 28);
            cboSeason.TabIndex = 56;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(cboSeason);
            groupBox1.Controls.Add(cboContractor);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(16, 91);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(284, 135);
            groupBox1.TabIndex = 58;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filtros para cuadrilla";
            // 
            // FrmPayrollPruningReport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(301, 401);
            Controls.Add(lblTitle);
            Controls.Add(btnDownload);
            Controls.Add(label5);
            Controls.Add(dtpDate2);
            Controls.Add(dtpDate1);
            Controls.Add(label4);
            Controls.Add(label6);
            Controls.Add(cboWorkGroup);
            Controls.Add(label7);
            Controls.Add(cboLot);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmPayrollPruningReport";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Generar reporte de poda en Excel";
            Load += FrmPayrollPruningReport_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public ComboBox cboVariety;
        private Label label2;
        private Label label6;
        public ComboBox cboWorkGroup;
        private Label label7;
        public ComboBox cboLot;
        private Label label5;
        public DateTimePicker dtpDate2;
        public DateTimePicker dtpDate1;
        private Label label4;
        private Button btnDownload;
        private Label lblTitle;
        private Label label1;
        public ComboBox cboContractor;
        public ComboBox cboSeason;
        private GroupBox groupBox1;
    }
}