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
            cboVariety = new ComboBox();
            label2 = new Label();
            label6 = new Label();
            cboWorkGroup = new ComboBox();
            label7 = new Label();
            cboLot = new ComboBox();
            label5 = new Label();
            dtpFecha2 = new DateTimePicker();
            dtpFecha1 = new DateTimePicker();
            label4 = new Label();
            btnDownload = new Button();
            SuspendLayout();
            // 
            // cboVariety
            // 
            cboVariety.DropDownStyle = ComboBoxStyle.DropDownList;
            cboVariety.FormattingEnabled = true;
            cboVariety.Location = new Point(454, 59);
            cboVariety.Name = "cboVariety";
            cboVariety.Size = new Size(203, 23);
            cboVariety.TabIndex = 27;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 6.75F);
            label2.Location = new Point(454, 47);
            label2.Name = "label2";
            label2.Size = new Size(40, 12);
            label2.TabIndex = 28;
            label2.Text = "Variedad";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 6.75F);
            label6.Location = new Point(36, 47);
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
            cboWorkGroup.Location = new Point(36, 59);
            cboWorkGroup.Name = "cboWorkGroup";
            cboWorkGroup.Size = new Size(203, 23);
            cboWorkGroup.TabIndex = 44;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 6.75F);
            label7.Location = new Point(245, 47);
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
            cboLot.Location = new Point(245, 59);
            cboLot.Name = "cboLot";
            cboLot.Size = new Size(203, 23);
            cboLot.TabIndex = 45;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 6.75F);
            label5.Location = new Point(12, 9);
            label5.Name = "label5";
            label5.Size = new Size(26, 12);
            label5.TabIndex = 50;
            label5.Text = "Entre";
            // 
            // dtpFecha2
            // 
            dtpFecha2.Format = DateTimePickerFormat.Short;
            dtpFecha2.Location = new Point(105, 21);
            dtpFecha2.Name = "dtpFecha2";
            dtpFecha2.Size = new Size(80, 23);
            dtpFecha2.TabIndex = 49;
            // 
            // dtpFecha1
            // 
            dtpFecha1.Format = DateTimePickerFormat.Short;
            dtpFecha1.Location = new Point(12, 21);
            dtpFecha1.Name = "dtpFecha1";
            dtpFecha1.Size = new Size(80, 23);
            dtpFecha1.TabIndex = 48;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 6.75F);
            label4.Location = new Point(94, 32);
            label4.Name = "label4";
            label4.Size = new Size(9, 12);
            label4.TabIndex = 51;
            label4.Text = "y";
            // 
            // btnDownload
            // 
            btnDownload.BackgroundImageLayout = ImageLayout.Stretch;
            btnDownload.Image = Properties.Resources.guardarIcon16;
            btnDownload.Location = new Point(11, 59);
            btnDownload.Name = "btnDownload";
            btnDownload.Padding = new Padding(0, 0, 0, 1);
            btnDownload.Size = new Size(23, 23);
            btnDownload.TabIndex = 52;
            btnDownload.UseVisualStyleBackColor = true;
            btnDownload.Click += btnDownload_Click;
            // 
            // FrmPayrollPruningReport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDownload);
            Controls.Add(label5);
            Controls.Add(dtpFecha2);
            Controls.Add(dtpFecha1);
            Controls.Add(label4);
            Controls.Add(label6);
            Controls.Add(cboWorkGroup);
            Controls.Add(label7);
            Controls.Add(cboLot);
            Controls.Add(cboVariety);
            Controls.Add(label2);
            Name = "FrmPayrollPruningReport";
            Text = "FrmPayrollPruningReport";
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
        public DateTimePicker dtpFecha2;
        public DateTimePicker dtpFecha1;
        private Label label4;
        private Button btnDownload;
    }
}