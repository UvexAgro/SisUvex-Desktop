namespace SisUvex.Reports
{
    partial class PrintPalletBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintPalletBox));
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            button1 = new Button();
            printDialog1 = new PrintDialog();
            printPreviewDialog1 = new PrintPreviewDialog();
            button2 = new Button();
            txbVariety = new TextBox();
            lblVariety = new Label();
            lblDistributor = new Label();
            txbDistributor = new TextBox();
            lblWeight = new Label();
            txbWeight = new TextBox();
            txbPresentation = new TextBox();
            lblPresentration = new Label();
            txbAddress1 = new TextBox();
            lblAdress1 = new Label();
            lblAddress2 = new Label();
            txbAddress2 = new TextBox();
            lblDateBlack = new Label();
            txbDateBlack = new TextBox();
            txbDateNumber = new TextBox();
            lblDateNumber = new Label();
            lblLotNumber = new Label();
            txbLoteNumber = new TextBox();
            lblVPC1 = new Label();
            txbVPC1 = new TextBox();
            lblUPC = new Label();
            txbUPC = new TextBox();
            txbGtin = new TextBox();
            lblGtin = new Label();
            txtBoxNumber = new TextBox();
            lblBoxNumber = new Label();
            lblVPC2 = new Label();
            txbVPC2 = new TextBox();
            txbQty = new TextBox();
            lblQty = new Label();
            lblNoPallet = new Label();
            txtNoPallet = new TextBox();
            lblPrint = new Label();
            cbxPrint = new ComboBox();
            nudLabelsQty = new NumericUpDown();
            lblLabelsQty = new Label();
            ((System.ComponentModel.ISupportInitialize)nudLabelsQty).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(73, 1246);
            button1.Margin = new Padding(2, 3, 2, 3);
            button1.Name = "button1";
            button1.Size = new Size(330, 101);
            button1.TabIndex = 0;
            button1.Text = "PTI";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // printDialog1
            // 
            printDialog1.UseEXDialog = true;
            // 
            // printPreviewDialog1
            // 
            printPreviewDialog1.AutoScrollMargin = new Size(0, 0);
            printPreviewDialog1.AutoScrollMinSize = new Size(0, 0);
            printPreviewDialog1.ClientSize = new Size(400, 300);
            printPreviewDialog1.Enabled = true;
            printPreviewDialog1.Icon = (Icon)resources.GetObject("printPreviewDialog1.Icon");
            printPreviewDialog1.Name = "printPreviewDialog1";
            printPreviewDialog1.Visible = false;
            // 
            // button2
            // 
            button2.Location = new Point(532, 1246);
            button2.Margin = new Padding(2, 3, 2, 3);
            button2.Name = "button2";
            button2.Size = new Size(386, 101);
            button2.TabIndex = 1;
            button2.Text = "PALLET";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // txbVariety
            // 
            txbVariety.Location = new Point(294, 139);
            txbVariety.Margin = new Padding(2, 3, 2, 3);
            txbVariety.Name = "txbVariety";
            txbVariety.Size = new Size(249, 47);
            txbVariety.TabIndex = 2;
            // 
            // lblVariety
            // 
            lblVariety.AutoSize = true;
            lblVariety.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblVariety.Location = new Point(39, 145);
            lblVariety.Margin = new Padding(2, 0, 2, 0);
            lblVariety.Name = "lblVariety";
            lblVariety.Size = new Size(168, 41);
            lblVariety.TabIndex = 3;
            lblVariety.Text = "VARIEDAD";
            // 
            // lblDistributor
            // 
            lblDistributor.AutoSize = true;
            lblDistributor.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblDistributor.Location = new Point(39, 219);
            lblDistributor.Margin = new Padding(2, 0, 2, 0);
            lblDistributor.Name = "lblDistributor";
            lblDistributor.Size = new Size(136, 41);
            lblDistributor.TabIndex = 4;
            lblDistributor.Text = "CLIENTE";
            // 
            // txbDistributor
            // 
            txbDistributor.Location = new Point(294, 210);
            txbDistributor.Margin = new Padding(2, 3, 2, 3);
            txbDistributor.Name = "txbDistributor";
            txbDistributor.Size = new Size(249, 47);
            txbDistributor.TabIndex = 5;
            // 
            // lblWeight
            // 
            lblWeight.AutoSize = true;
            lblWeight.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblWeight.Location = new Point(39, 298);
            lblWeight.Margin = new Padding(2, 0, 2, 0);
            lblWeight.Name = "lblWeight";
            lblWeight.Size = new Size(92, 41);
            lblWeight.TabIndex = 6;
            lblWeight.Text = "PESO";
            // 
            // txbWeight
            // 
            txbWeight.Location = new Point(294, 295);
            txbWeight.Margin = new Padding(2, 3, 2, 3);
            txbWeight.Name = "txbWeight";
            txbWeight.Size = new Size(249, 47);
            txbWeight.TabIndex = 7;
            // 
            // txbPresentation
            // 
            txbPresentation.Location = new Point(294, 380);
            txbPresentation.Margin = new Padding(2, 3, 2, 3);
            txbPresentation.Name = "txbPresentation";
            txbPresentation.Size = new Size(249, 47);
            txbPresentation.TabIndex = 8;
            // 
            // lblPresentration
            // 
            lblPresentration.AutoSize = true;
            lblPresentration.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblPresentration.Location = new Point(39, 383);
            lblPresentration.Margin = new Padding(2, 0, 2, 0);
            lblPresentration.Name = "lblPresentration";
            lblPresentration.Size = new Size(242, 41);
            lblPresentration.TabIndex = 9;
            lblPresentration.Text = "PRESENTACION";
            // 
            // txbAddress1
            // 
            txbAddress1.Location = new Point(294, 473);
            txbAddress1.Margin = new Padding(2, 3, 2, 3);
            txbAddress1.Name = "txbAddress1";
            txbAddress1.Size = new Size(249, 47);
            txbAddress1.TabIndex = 10;
            // 
            // lblAdress1
            // 
            lblAdress1.AutoSize = true;
            lblAdress1.Location = new Point(39, 473);
            lblAdress1.Margin = new Padding(2, 0, 2, 0);
            lblAdress1.Name = "lblAdress1";
            lblAdress1.Size = new Size(194, 41);
            lblAdress1.TabIndex = 11;
            lblAdress1.Text = "DIRECCION 1";
            // 
            // lblAddress2
            // 
            lblAddress2.AutoSize = true;
            lblAddress2.Location = new Point(39, 547);
            lblAddress2.Margin = new Padding(2, 0, 2, 0);
            lblAddress2.Name = "lblAddress2";
            lblAddress2.Size = new Size(194, 41);
            lblAddress2.TabIndex = 12;
            lblAddress2.Text = "DIRECCION 2";
            // 
            // txbAddress2
            // 
            txbAddress2.Location = new Point(294, 547);
            txbAddress2.Margin = new Padding(2, 3, 2, 3);
            txbAddress2.Name = "txbAddress2";
            txbAddress2.Size = new Size(249, 47);
            txbAddress2.TabIndex = 13;
            // 
            // lblDateBlack
            // 
            lblDateBlack.AutoSize = true;
            lblDateBlack.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblDateBlack.Location = new Point(39, 629);
            lblDateBlack.Margin = new Padding(2, 0, 2, 0);
            lblDateBlack.Name = "lblDateBlack";
            lblDateBlack.Size = new Size(244, 41);
            lblDateBlack.TabIndex = 14;
            lblDateBlack.Text = "FECHA MES DIA";
            // 
            // txbDateBlack
            // 
            txbDateBlack.Location = new Point(294, 629);
            txbDateBlack.Margin = new Padding(2, 3, 2, 3);
            txbDateBlack.Name = "txbDateBlack";
            txbDateBlack.Size = new Size(249, 47);
            txbDateBlack.TabIndex = 15;
            // 
            // txbDateNumber
            // 
            txbDateNumber.Location = new Point(294, 702);
            txbDateNumber.Margin = new Padding(2, 3, 2, 3);
            txbDateNumber.Name = "txbDateNumber";
            txbDateNumber.Size = new Size(249, 47);
            txbDateNumber.TabIndex = 16;
            // 
            // lblDateNumber
            // 
            lblDateNumber.AutoSize = true;
            lblDateNumber.Location = new Point(39, 711);
            lblDateNumber.Margin = new Padding(2, 0, 2, 0);
            lblDateNumber.Name = "lblDateNumber";
            lblDateNumber.Size = new Size(241, 41);
            lblDateNumber.TabIndex = 17;
            lblDateNumber.Text = "FECHA NUMERO";
            // 
            // lblLotNumber
            // 
            lblLotNumber.AutoSize = true;
            lblLotNumber.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblLotNumber.Location = new Point(39, 787);
            lblLotNumber.Margin = new Padding(2, 0, 2, 0);
            lblLotNumber.Name = "lblLotNumber";
            lblLotNumber.Size = new Size(143, 41);
            lblLotNumber.TabIndex = 19;
            lblLotNumber.Text = "NO LOTE";
            // 
            // txbLoteNumber
            // 
            txbLoteNumber.Location = new Point(294, 782);
            txbLoteNumber.Margin = new Padding(2, 3, 2, 3);
            txbLoteNumber.Name = "txbLoteNumber";
            txbLoteNumber.Size = new Size(249, 47);
            txbLoteNumber.TabIndex = 18;
            // 
            // lblVPC1
            // 
            lblVPC1.AutoSize = true;
            lblVPC1.Location = new Point(39, 1102);
            lblVPC1.Margin = new Padding(2, 0, 2, 0);
            lblVPC1.Name = "lblVPC1";
            lblVPC1.Size = new Size(89, 41);
            lblVPC1.TabIndex = 27;
            lblVPC1.Text = "VPC1";
            // 
            // txbVPC1
            // 
            txbVPC1.Location = new Point(294, 1096);
            txbVPC1.Margin = new Padding(2, 3, 2, 3);
            txbVPC1.Name = "txbVPC1";
            txbVPC1.Size = new Size(249, 47);
            txbVPC1.TabIndex = 26;
            // 
            // lblUPC
            // 
            lblUPC.AutoSize = true;
            lblUPC.Location = new Point(39, 1022);
            lblUPC.Margin = new Padding(2, 0, 2, 0);
            lblUPC.Name = "lblUPC";
            lblUPC.Size = new Size(75, 41);
            lblUPC.TabIndex = 25;
            lblUPC.Text = "UPC";
            // 
            // txbUPC
            // 
            txbUPC.Location = new Point(294, 1017);
            txbUPC.Margin = new Padding(2, 3, 2, 3);
            txbUPC.Name = "txbUPC";
            txbUPC.Size = new Size(249, 47);
            txbUPC.TabIndex = 24;
            // 
            // txbGtin
            // 
            txbGtin.Location = new Point(294, 940);
            txbGtin.Margin = new Padding(2, 3, 2, 3);
            txbGtin.Name = "txbGtin";
            txbGtin.Size = new Size(249, 47);
            txbGtin.TabIndex = 23;
            // 
            // lblGtin
            // 
            lblGtin.AutoSize = true;
            lblGtin.Location = new Point(39, 940);
            lblGtin.Margin = new Padding(2, 0, 2, 0);
            lblGtin.Name = "lblGtin";
            lblGtin.Size = new Size(84, 41);
            lblGtin.TabIndex = 22;
            lblGtin.Text = "GTIN";
            // 
            // txtBoxNumber
            // 
            txtBoxNumber.Location = new Point(294, 861);
            txtBoxNumber.Margin = new Padding(2, 3, 2, 3);
            txtBoxNumber.Name = "txtBoxNumber";
            txtBoxNumber.Size = new Size(249, 47);
            txtBoxNumber.TabIndex = 21;
            // 
            // lblBoxNumber
            // 
            lblBoxNumber.AutoSize = true;
            lblBoxNumber.Location = new Point(39, 861);
            lblBoxNumber.Margin = new Padding(2, 0, 2, 0);
            lblBoxNumber.Name = "lblBoxNumber";
            lblBoxNumber.Size = new Size(139, 41);
            lblBoxNumber.TabIndex = 20;
            lblBoxNumber.Text = "NO CAJA";
            // 
            // lblVPC2
            // 
            lblVPC2.AutoSize = true;
            lblVPC2.Location = new Point(39, 1175);
            lblVPC2.Margin = new Padding(2, 0, 2, 0);
            lblVPC2.Name = "lblVPC2";
            lblVPC2.Size = new Size(89, 41);
            lblVPC2.TabIndex = 29;
            lblVPC2.Text = "VPC2";
            // 
            // txbVPC2
            // 
            txbVPC2.Location = new Point(294, 1170);
            txbVPC2.Margin = new Padding(2, 3, 2, 3);
            txbVPC2.Name = "txbVPC2";
            txbVPC2.Size = new Size(249, 47);
            txbVPC2.TabIndex = 28;
            // 
            // txbQty
            // 
            txbQty.Location = new Point(843, 210);
            txbQty.Margin = new Padding(2, 3, 2, 3);
            txbQty.Name = "txbQty";
            txbQty.Size = new Size(249, 47);
            txbQty.TabIndex = 33;
            // 
            // lblQty
            // 
            lblQty.AutoSize = true;
            lblQty.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblQty.Location = new Point(590, 219);
            lblQty.Margin = new Padding(2, 0, 2, 0);
            lblQty.Name = "lblQty";
            lblQty.Size = new Size(77, 41);
            lblQty.TabIndex = 32;
            lblQty.Text = "QTY";
            // 
            // lblNoPallet
            // 
            lblNoPallet.AutoSize = true;
            lblNoPallet.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblNoPallet.Location = new Point(590, 145);
            lblNoPallet.Margin = new Padding(2, 0, 2, 0);
            lblNoPallet.Name = "lblNoPallet";
            lblNoPallet.Size = new Size(174, 41);
            lblNoPallet.TabIndex = 31;
            lblNoPallet.Text = "NO PALLET";
            // 
            // txtNoPallet
            // 
            txtNoPallet.Location = new Point(843, 139);
            txtNoPallet.Margin = new Padding(2, 3, 2, 3);
            txtNoPallet.Name = "txtNoPallet";
            txtNoPallet.Size = new Size(249, 47);
            txtNoPallet.TabIndex = 30;
            // 
            // lblPrint
            // 
            lblPrint.AutoSize = true;
            lblPrint.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblPrint.Location = new Point(39, 52);
            lblPrint.Margin = new Padding(2, 0, 2, 0);
            lblPrint.Name = "lblPrint";
            lblPrint.Size = new Size(192, 41);
            lblPrint.TabIndex = 34;
            lblPrint.Text = "IMPRESORA";
            // 
            // cbxPrint
            // 
            cbxPrint.FormattingEnabled = true;
            cbxPrint.Location = new Point(231, 44);
            cbxPrint.Margin = new Padding(7, 8, 7, 8);
            cbxPrint.Name = "cbxPrint";
            cbxPrint.Size = new Size(861, 49);
            cbxPrint.TabIndex = 35;
            cbxPrint.SelectedIndexChanged += cbxPrint_SelectedIndexChanged;
            // 
            // nudLabelsQty
            // 
            nudLabelsQty.Location = new Point(916, 525);
            nudLabelsQty.Margin = new Padding(7, 8, 7, 8);
            nudLabelsQty.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudLabelsQty.Name = "nudLabelsQty";
            nudLabelsQty.Size = new Size(112, 47);
            nudLabelsQty.TabIndex = 36;
            nudLabelsQty.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblLabelsQty
            // 
            lblLabelsQty.AutoSize = true;
            lblLabelsQty.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblLabelsQty.Location = new Point(750, 473);
            lblLabelsQty.Margin = new Padding(2, 0, 2, 0);
            lblLabelsQty.Name = "lblLabelsQty";
            lblLabelsQty.Size = new Size(305, 41);
            lblLabelsQty.TabIndex = 37;
            lblLabelsQty.Text = "Etiquetas a imprimir";
            // 
            // PrintPalletBox
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1139, 1394);
            Controls.Add(lblLabelsQty);
            Controls.Add(nudLabelsQty);
            Controls.Add(cbxPrint);
            Controls.Add(lblPrint);
            Controls.Add(txbQty);
            Controls.Add(lblQty);
            Controls.Add(lblNoPallet);
            Controls.Add(txtNoPallet);
            Controls.Add(lblVPC2);
            Controls.Add(txbVPC2);
            Controls.Add(lblVPC1);
            Controls.Add(txbVPC1);
            Controls.Add(lblUPC);
            Controls.Add(txbUPC);
            Controls.Add(txbGtin);
            Controls.Add(lblGtin);
            Controls.Add(txtBoxNumber);
            Controls.Add(lblBoxNumber);
            Controls.Add(lblLotNumber);
            Controls.Add(txbLoteNumber);
            Controls.Add(lblDateNumber);
            Controls.Add(txbDateNumber);
            Controls.Add(txbDateBlack);
            Controls.Add(lblDateBlack);
            Controls.Add(txbAddress2);
            Controls.Add(lblAddress2);
            Controls.Add(lblAdress1);
            Controls.Add(txbAddress1);
            Controls.Add(lblPresentration);
            Controls.Add(txbPresentation);
            Controls.Add(txbWeight);
            Controls.Add(lblWeight);
            Controls.Add(txbDistributor);
            Controls.Add(lblDistributor);
            Controls.Add(lblVariety);
            Controls.Add(txbVariety);
            Controls.Add(button2);
            Controls.Add(button1);
            Margin = new Padding(2, 3, 2, 3);
            Name = "PrintPalletBox";
            Text = "PTI";
            Load += PrintPalletBox_Load;
            ((System.ComponentModel.ISupportInitialize)nudLabelsQty).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Drawing.Printing.PrintDocument printDocument1;
        private Button button1;
        private PrintDialog printDialog1;
        private PrintPreviewDialog printPreviewDialog1;
        private Button button2;
        private TextBox txbVariety;
        private Label lblVariety;
        private Label lblDistributor;
        private TextBox txbDistributor;
        private Label lblWeight;
        private TextBox txbWeight;
        private TextBox txbPresentation;
        private Label lblPresentration;
        private TextBox txbAddress1;
        private Label lblAdress1;
        private Label lblAddress2;
        private TextBox txbAddress2;
        private Label lblDateBlack;
        private TextBox txbDateBlack;
        private TextBox txbDateNumber;
        private Label lblDateNumber;
        private Label lblLotNumber;
        private TextBox txbLoteNumber;
        private Label lblVPC1;
        private TextBox txbVPC1;
        private Label lblUPC;
        private TextBox txbUPC;
        private TextBox txbGtin;
        private Label lblGtin;
        private TextBox txtBoxNumber;
        private Label lblBoxNumber;
        private Label lblVPC2;
        private TextBox txbVPC2;
        private TextBox txbQty;
        private Label lblQty;
        private Label lblNoPallet;
        private TextBox txtNoPallet;
        private Label lblPrint;
        private ComboBox cbxPrint;
        private NumericUpDown nudLabelsQty;
        private Label lblLabelsQty;
    }
}