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
            cmBxSetupPrintPallet = new ComboBox();
            label1 = new Label();
            btnSetupPrintPTI = new Button();
            label2 = new Label();
            cmBxSetupPrintPTI = new ComboBox();
            label3 = new Label();
            cmBxSetupPrintCode = new ComboBox();
            label4 = new Label();
            cmBxSetupPrintDoc = new ComboBox();
            lblPallet = new Label();
            lblDoc = new Label();
            lblCode = new Label();
            lblPTI = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // cmBxSetupPrintPallet
            // 
            cmBxSetupPrintPallet.Font = new Font("Segoe UI", 14F);
            cmBxSetupPrintPallet.FormattingEnabled = true;
            cmBxSetupPrintPallet.Location = new Point(21, 81);
            cmBxSetupPrintPallet.Margin = new Padding(1, 1, 1, 1);
            cmBxSetupPrintPallet.Name = "cmBxSetupPrintPallet";
            cmBxSetupPrintPallet.Size = new Size(258, 33);
            cmBxSetupPrintPallet.TabIndex = 0;
            cmBxSetupPrintPallet.SelectedIndexChanged += cmBxSetupPrintPallet_SelectedIndexChanged;
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
            btnSetupPrintPTI.Location = new Point(544, 270);
            btnSetupPrintPTI.Margin = new Padding(1, 1, 1, 1);
            btnSetupPrintPTI.Name = "btnSetupPrintPTI";
            btnSetupPrintPTI.Size = new Size(78, 30);
            btnSetupPrintPTI.TabIndex = 2;
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
            // cmBxSetupPrintPTI
            // 
            cmBxSetupPrintPTI.Font = new Font("Segoe UI", 14F);
            cmBxSetupPrintPTI.FormattingEnabled = true;
            cmBxSetupPrintPTI.Location = new Point(367, 81);
            cmBxSetupPrintPTI.Margin = new Padding(1, 1, 1, 1);
            cmBxSetupPrintPTI.Name = "cmBxSetupPrintPTI";
            cmBxSetupPrintPTI.Size = new Size(258, 33);
            cmBxSetupPrintPTI.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label3.Location = new Point(47, 145);
            label3.Margin = new Padding(1, 0, 1, 0);
            label3.Name = "label3";
            label3.Size = new Size(199, 25);
            label3.TabIndex = 7;
            label3.Text = "IMPRESORA CODIGO";
            // 
            // cmBxSetupPrintCode
            // 
            cmBxSetupPrintCode.Font = new Font("Segoe UI", 14F);
            cmBxSetupPrintCode.FormattingEnabled = true;
            cmBxSetupPrintCode.Location = new Point(21, 213);
            cmBxSetupPrintCode.Margin = new Padding(1, 1, 1, 1);
            cmBxSetupPrintCode.Name = "cmBxSetupPrintCode";
            cmBxSetupPrintCode.Size = new Size(258, 33);
            cmBxSetupPrintCode.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label4.Location = new Point(367, 141);
            label4.Margin = new Padding(1, 0, 1, 0);
            label4.Name = "label4";
            label4.Size = new Size(257, 25);
            label4.TabIndex = 10;
            label4.Text = "IMPRESORA DOCUMENTOS";
            // 
            // cmBxSetupPrintDoc
            // 
            cmBxSetupPrintDoc.Font = new Font("Segoe UI", 14F);
            cmBxSetupPrintDoc.FormattingEnabled = true;
            cmBxSetupPrintDoc.Location = new Point(367, 213);
            cmBxSetupPrintDoc.Margin = new Padding(1, 1, 1, 1);
            cmBxSetupPrintDoc.Name = "cmBxSetupPrintDoc";
            cmBxSetupPrintDoc.Size = new Size(258, 33);
            cmBxSetupPrintDoc.TabIndex = 9;
            // 
            // lblPallet
            // 
            lblPallet.AutoSize = true;
            lblPallet.Font = new Font("Segoe UI", 14F);
            lblPallet.Location = new Point(57, 49);
            lblPallet.Margin = new Padding(1, 0, 1, 0);
            lblPallet.Name = "lblPallet";
            lblPallet.Size = new Size(0, 25);
            lblPallet.TabIndex = 12;
            // 
            // lblDoc
            // 
            lblDoc.AutoSize = true;
            lblDoc.Font = new Font("Segoe UI", 14F);
            lblDoc.Location = new Point(367, 178);
            lblDoc.Margin = new Padding(1, 0, 1, 0);
            lblDoc.Name = "lblDoc";
            lblDoc.Size = new Size(0, 25);
            lblDoc.TabIndex = 13;
            // 
            // lblCode
            // 
            lblCode.AutoSize = true;
            lblCode.Font = new Font("Segoe UI", 14F);
            lblCode.Location = new Point(21, 175);
            lblCode.Margin = new Padding(1, 0, 1, 0);
            lblCode.Name = "lblCode";
            lblCode.Size = new Size(0, 25);
            lblCode.TabIndex = 14;
            // 
            // lblPTI
            // 
            lblPTI.AutoSize = true;
            lblPTI.Font = new Font("Segoe UI", 14F);
            lblPTI.Location = new Point(366, 41);
            lblPTI.Margin = new Padding(1, 0, 1, 0);
            lblPTI.Name = "lblPTI";
            lblPTI.Size = new Size(0, 25);
            lblPTI.TabIndex = 15;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 14F);
            button1.Location = new Point(388, 270);
            button1.Margin = new Padding(1, 1, 1, 1);
            button1.Name = "button1";
            button1.Size = new Size(114, 30);
            button1.TabIndex = 16;
            button1.Text = "MOSTRAR";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // FrmSetupPrint
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(668, 307);
            Controls.Add(button1);
            Controls.Add(lblPTI);
            Controls.Add(lblCode);
            Controls.Add(lblDoc);
            Controls.Add(lblPallet);
            Controls.Add(label4);
            Controls.Add(cmBxSetupPrintDoc);
            Controls.Add(label3);
            Controls.Add(cmBxSetupPrintCode);
            Controls.Add(label2);
            Controls.Add(cmBxSetupPrintPTI);
            Controls.Add(btnSetupPrintPTI);
            Controls.Add(label1);
            Controls.Add(cmBxSetupPrintPallet);
            Margin = new Padding(1, 1, 1, 1);
            Name = "FrmSetupPrint";
            Text = "FrmSetupPrinterPallet";
            Load += FrmSetupPrinterPallet_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmBxSetupPrintPallet;
        private Label label1;
        private Button btnSetupPrintPTI;
        private Label label2;
        private ComboBox cmBxSetupPrintPTI;
        private Label label3;
        private ComboBox cmBxSetupPrintCode;
        private Label label4;
        private ComboBox cmBxSetupPrintDoc;
        private Label lblPallet;
        private Label lblDoc;
        private Label lblCode;
        private Label lblPTI;
        private Button button1;
    }
}