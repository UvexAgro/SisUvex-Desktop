namespace SisUvex.Archivo.Reimprimir
{
    partial class FrmRePrintPallet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRePrintPallet));
            txbRePrintCode = new TextBox();
            lblReprintPallet = new Label();
            label1 = new Label();
            txbUpdateBoxes = new TextBox();
            label3 = new Label();
            button2 = new Button();
            chbRevesePalletTag = new CheckBox();
            SuspendLayout();
            // 
            // txbRePrintCode
            // 
            txbRePrintCode.Font = new Font("Segoe UI", 14.1F);
            txbRePrintCode.Location = new Point(166, 75);
            txbRePrintCode.Margin = new Padding(1);
            txbRePrintCode.Name = "txbRePrintCode";
            txbRePrintCode.Size = new Size(138, 33);
            txbRePrintCode.TabIndex = 0;
            // 
            // lblReprintPallet
            // 
            lblReprintPallet.AutoSize = true;
            lblReprintPallet.Font = new Font("Segoe UI Black", 15.9000006F);
            lblReprintPallet.Location = new Point(77, 20);
            lblReprintPallet.Margin = new Padding(1, 0, 1, 0);
            lblReprintPallet.Name = "lblReprintPallet";
            lblReprintPallet.Size = new Size(239, 30);
            lblReprintPallet.TabIndex = 1;
            lblReprintPallet.Text = "REIMPRIMIR PALLET";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.9000006F);
            label1.Location = new Point(63, 74);
            label1.Margin = new Padding(1, 0, 1, 0);
            label1.Name = "label1";
            label1.Size = new Size(101, 30);
            label1.TabIndex = 2;
            label1.Text = "CÓDIGO:";
            // 
            // txbUpdateBoxes
            // 
            txbUpdateBoxes.Font = new Font("Segoe UI", 14.1F);
            txbUpdateBoxes.Location = new Point(166, 137);
            txbUpdateBoxes.Margin = new Padding(1);
            txbUpdateBoxes.Name = "txbUpdateBoxes";
            txbUpdateBoxes.Size = new Size(138, 33);
            txbUpdateBoxes.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15.9000006F);
            label3.Location = new Point(84, 138);
            label3.Margin = new Padding(1, 0, 1, 0);
            label3.Name = "label3";
            label3.Size = new Size(80, 30);
            label3.TabIndex = 5;
            label3.Text = "CAJAS:";
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 14.1F);
            button2.Location = new Point(140, 246);
            button2.Margin = new Padding(1);
            button2.Name = "button2";
            button2.Size = new Size(138, 33);
            button2.TabIndex = 2;
            button2.Text = "IMPRIMIR";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // chbRevesePalletTag
            // 
            chbRevesePalletTag.AutoSize = true;
            chbRevesePalletTag.Enabled = false;
            chbRevesePalletTag.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chbRevesePalletTag.Location = new Point(141, 283);
            chbRevesePalletTag.Name = "chbRevesePalletTag";
            chbRevesePalletTag.Size = new Size(109, 19);
            chbRevesePalletTag.TabIndex = 3;
            chbRevesePalletTag.Text = "Invertir etiqueta";
            chbRevesePalletTag.UseVisualStyleBackColor = true;
            // 
            // FrmRePrintPallet
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(391, 339);
            Controls.Add(chbRevesePalletTag);
            Controls.Add(button2);
            Controls.Add(label3);
            Controls.Add(txbUpdateBoxes);
            Controls.Add(label1);
            Controls.Add(lblReprintPallet);
            Controls.Add(txbRePrintCode);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(1);
            Name = "FrmRePrintPallet";
            Text = "FrmRePrintPallet";
            Load += FrmRePrintPallet_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txbRePrintCode;
        private Label lblReprintPallet;
        private Label label1;
        private TextBox txbUpdateBoxes;
        private Label label3;
        private Button button2;
        public CheckBox chbRevesePalletTag;
    }
}