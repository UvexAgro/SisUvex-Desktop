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
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 6.75F);
            label6.Location = new Point(12, 74);
            label6.Name = "label6";
            label6.Size = new Size(40, 12);
            label6.TabIndex = 47;
            label6.Text = "Cuadrilla";
            // 
            // cboWorkGroup
            // 
            cboWorkGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            cboWorkGroup.DropDownWidth = 400;
            cboWorkGroup.FormattingEnabled = true;
            cboWorkGroup.Location = new Point(12, 86);
            cboWorkGroup.Name = "cboWorkGroup";
            cboWorkGroup.Size = new Size(239, 23);
            cboWorkGroup.TabIndex = 44;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 6.75F);
            label7.Location = new Point(12, 112);
            label7.Name = "label7";
            label7.Size = new Size(22, 12);
            label7.TabIndex = 46;
            label7.Text = "Lote";
            // 
            // cboLot
            // 
            cboLot.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLot.DropDownWidth = 400;
            cboLot.FormattingEnabled = true;
            cboLot.Location = new Point(12, 124);
            cboLot.Name = "cboLot";
            cboLot.Size = new Size(239, 23);
            cboLot.TabIndex = 45;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 6.75F);
            label5.Location = new Point(12, 36);
            label5.Name = "label5";
            label5.Size = new Size(26, 12);
            label5.TabIndex = 50;
            label5.Text = "Entre";
            // 
            // dtpDate2
            // 
            dtpDate2.Format = DateTimePickerFormat.Short;
            dtpDate2.Location = new Point(105, 48);
            dtpDate2.Name = "dtpDate2";
            dtpDate2.Size = new Size(80, 23);
            dtpDate2.TabIndex = 49;
            // 
            // dtpDate1
            // 
            dtpDate1.Format = DateTimePickerFormat.Short;
            dtpDate1.Location = new Point(12, 48);
            dtpDate1.Name = "dtpDate1";
            dtpDate1.Size = new Size(80, 23);
            dtpDate1.TabIndex = 48;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 6.75F);
            label4.Location = new Point(94, 59);
            label4.Name = "label4";
            label4.Size = new Size(9, 12);
            label4.TabIndex = 51;
            label4.Text = "y";
            // 
            // btnDownload
            // 
            btnDownload.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDownload.BackgroundImageLayout = ImageLayout.Stretch;
            btnDownload.Image = Properties.Resources.excelIcon16;
            btnDownload.ImageAlign = ContentAlignment.MiddleRight;
            btnDownload.Location = new Point(135, 158);
            btnDownload.Name = "btnDownload";
            btnDownload.Padding = new Padding(0, 0, 2, 0);
            btnDownload.Size = new Size(116, 26);
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
            // FrmPayrollPruningReport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(263, 196);
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
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmPayrollPruningReport";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Generar reporte de poda en Excel";
            Load += FrmPayrollPruningReport_Load;
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
    }
}