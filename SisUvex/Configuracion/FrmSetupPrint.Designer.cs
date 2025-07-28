namespace SisUvex.Configuracion
{
    partial class FrmSetupPrint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSetupPrint));
            cboPrinterPallet = new ComboBox();
            label1 = new Label();
            btnSetupPrintPTI = new Button();
            label2 = new Label();
            cboPrinterPTI = new ComboBox();
            label3 = new Label();
            cboPrinterCode = new ComboBox();
            label4 = new Label();
            cboPrinterDoc = new ComboBox();
            lblPallet = new Label();
            lblDoc = new Label();
            lblCode = new Label();
            lblPTI = new Label();
            SuspendLayout();
            // 
            // cboPrinterPallet
            // 
            cboPrinterPallet.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPrinterPallet.Font = new Font("Segoe UI", 14F);
            cboPrinterPallet.FormattingEnabled = true;
            cboPrinterPallet.Location = new Point(21, 81);
            cboPrinterPallet.Margin = new Padding(1);
            cboPrinterPallet.Name = "cboPrinterPallet";
            cboPrinterPallet.Size = new Size(258, 33);
            cboPrinterPallet.TabIndex = 0;
            cboPrinterPallet.SelectedIndexChanged += cmBxSetupPrintPallet_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.Location = new Point(57, 17);
            label1.Margin = new Padding(1, 0, 1, 0);
            label1.Name = "label1";
            label1.Size = new Size(190, 25);
            label1.TabIndex = 1;
            label1.Text = "IMPRESORA PALLET";
            // 
            // btnSetupPrintPTI
            // 
            btnSetupPrintPTI.Font = new Font("Segoe UI", 14F);
            btnSetupPrintPTI.Location = new Point(547, 289);
            btnSetupPrintPTI.Margin = new Padding(1);
            btnSetupPrintPTI.Name = "btnSetupPrintPTI";
            btnSetupPrintPTI.Size = new Size(78, 33);
            btnSetupPrintPTI.TabIndex = 5;
            btnSetupPrintPTI.Text = "FIJAR";
            btnSetupPrintPTI.UseVisualStyleBackColor = true;
            btnSetupPrintPTI.Click += btnSetupPrintPTI_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label2.Location = new Point(424, 17);
            label2.Margin = new Padding(1, 0, 1, 0);
            label2.Name = "label2";
            label2.Size = new Size(154, 25);
            label2.TabIndex = 4;
            label2.Text = "IMPRESORA PTI";
            // 
            // cboPrinterPTI
            // 
            cboPrinterPTI.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPrinterPTI.Font = new Font("Segoe UI", 14F);
            cboPrinterPTI.FormattingEnabled = true;
            cboPrinterPTI.Location = new Point(367, 81);
            cboPrinterPTI.Margin = new Padding(1);
            cboPrinterPTI.Name = "cboPrinterPTI";
            cboPrinterPTI.Size = new Size(258, 33);
            cboPrinterPTI.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label3.Location = new Point(47, 167);
            label3.Margin = new Padding(1, 0, 1, 0);
            label3.Name = "label3";
            label3.Size = new Size(199, 25);
            label3.TabIndex = 7;
            label3.Text = "IMPRESORA CODIGO";
            // 
            // cboPrinterCode
            // 
            cboPrinterCode.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPrinterCode.Font = new Font("Segoe UI", 14F);
            cboPrinterCode.FormattingEnabled = true;
            cboPrinterCode.Location = new Point(21, 235);
            cboPrinterCode.Margin = new Padding(1);
            cboPrinterCode.Name = "cboPrinterCode";
            cboPrinterCode.Size = new Size(258, 33);
            cboPrinterCode.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label4.Location = new Point(367, 163);
            label4.Margin = new Padding(1, 0, 1, 0);
            label4.Name = "label4";
            label4.Size = new Size(257, 25);
            label4.TabIndex = 10;
            label4.Text = "IMPRESORA DOCUMENTOS";
            // 
            // cboPrinterDoc
            // 
            cboPrinterDoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPrinterDoc.Font = new Font("Segoe UI", 14F);
            cboPrinterDoc.FormattingEnabled = true;
            cboPrinterDoc.Location = new Point(367, 235);
            cboPrinterDoc.Margin = new Padding(1);
            cboPrinterDoc.Name = "cboPrinterDoc";
            cboPrinterDoc.Size = new Size(258, 33);
            cboPrinterDoc.TabIndex = 3;
            // 
            // lblPallet
            // 
            lblPallet.AutoSize = true;
            lblPallet.Font = new Font("Segoe UI", 14F);
            lblPallet.Location = new Point(24, 52);
            lblPallet.Margin = new Padding(1, 0, 1, 0);
            lblPallet.Name = "lblPallet";
            lblPallet.Size = new Size(0, 25);
            lblPallet.TabIndex = 12;
            // 
            // lblDoc
            // 
            lblDoc.AutoSize = true;
            lblDoc.Font = new Font("Segoe UI", 14F);
            lblDoc.Location = new Point(370, 206);
            lblDoc.Margin = new Padding(1, 0, 1, 0);
            lblDoc.Name = "lblDoc";
            lblDoc.Size = new Size(0, 25);
            lblDoc.TabIndex = 13;
            // 
            // lblCode
            // 
            lblCode.AutoSize = true;
            lblCode.Font = new Font("Segoe UI", 14F);
            lblCode.Location = new Point(24, 206);
            lblCode.Margin = new Padding(1, 0, 1, 0);
            lblCode.Name = "lblCode";
            lblCode.Size = new Size(0, 25);
            lblCode.TabIndex = 14;
            // 
            // lblPTI
            // 
            lblPTI.AutoSize = true;
            lblPTI.Font = new Font("Segoe UI", 14F);
            lblPTI.Location = new Point(370, 52);
            lblPTI.Margin = new Padding(1, 0, 1, 0);
            lblPTI.Name = "lblPTI";
            lblPTI.Size = new Size(0, 25);
            lblPTI.TabIndex = 15;
            // 
            // FrmSetupPrint
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(649, 343);
            Controls.Add(lblPTI);
            Controls.Add(lblCode);
            Controls.Add(lblDoc);
            Controls.Add(lblPallet);
            Controls.Add(label4);
            Controls.Add(cboPrinterDoc);
            Controls.Add(label3);
            Controls.Add(cboPrinterCode);
            Controls.Add(label2);
            Controls.Add(cboPrinterPTI);
            Controls.Add(btnSetupPrintPTI);
            Controls.Add(label1);
            Controls.Add(cboPrinterPallet);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmSetupPrint";
            Text = "Configurar impresoras";
            Load += FrmSetupPrinterPallet_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboPrinterPallet;
        private Label label1;
        private Button btnSetupPrintPTI;
        private Label label2;
        private ComboBox cboPrinterPTI;
        private Label label3;
        private ComboBox cboPrinterCode;
        private Label label4;
        private ComboBox cboPrinterDoc;
        private Label lblPallet;
        private Label lblDoc;
        private Label lblCode;
        private Label lblPTI;
    }
}