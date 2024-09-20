using DocumentFormat.OpenXml.Office2016.Drawing.Charts;

namespace SisUvex.Archivo.Etiquetas.PrintLabels
{
    partial class FrmPrintLabelsPtiPallets
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            btnLastPallets = new Button();
            label1 = new Label();
            txbInvoice = new TextBox();
            cboWorkPlan = new ComboBox();
            dtpWorkDay = new DateTimePicker();
            label10 = new Label();
            lblPrograma = new Label();
            chBx = new CheckBox();
            btnPrintPtiTag = new Button();
            nudPalletTotal = new NumericUpDown();
            label7 = new Label();
            nudPtiTotal = new NumericUpDown();
            grbTag = new GroupBox();
            lblPluNumber = new Label();
            label23 = new Label();
            lable = new Label();
            label21 = new Label();
            lblGtinNumber = new Label();
            lblPtiName = new Label();
            lblUpcNumber = new Label();
            label12 = new Label();
            lblPtiId = new Label();
            grbCrop = new GroupBox();
            lblColorName = new Label();
            label11 = new Label();
            lblTagLote = new Label();
            lblLotId = new Label();
            lblTagVariety = new Label();
            lblVarietyName = new Label();
            lblLotName = new Label();
            lblDistributorCity = new Label();
            lblDistributorAddress = new Label();
            label9 = new Label();
            lblDistributorName = new Label();
            lblTagContractorDetail = new Label();
            cboWorkGroup = new ComboBox();
            lblTagWorkGroup = new Label();
            lblTagHead = new Label();
            grbProduct = new GroupBox();
            txbBoxesTotaL = new TextBox();
            label14 = new Label();
            label16 = new Label();
            label17 = new Label();
            lblLbsNum = new Label();
            label20 = new Label();
            label22 = new Label();
            lblContainerName = new Label();
            lblPresentationName = new Label();
            lblSizeName = new Label();
            label27 = new Label();
            grbDistributor = new GroupBox();
            lblWorkDay = new Label();
            btnPrintPalletTag = new Button();
            grbPrint = new GroupBox();
            chbReversePtiTag = new CheckBox();
            gpbLastPallets = new GroupBox();
            chbReverseReprintPallet = new CheckBox();
            btnReprintPallet = new Button();
            dgvLastUserPallet = new DataGridView();
            groupBox1 = new GroupBox();
            chbRevesePalletTag = new CheckBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)nudPalletTotal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPtiTotal).BeginInit();
            grbTag.SuspendLayout();
            grbCrop.SuspendLayout();
            grbProduct.SuspendLayout();
            grbDistributor.SuspendLayout();
            grbPrint.SuspendLayout();
            gpbLastPallets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLastUserPallet).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnLastPallets
            // 
            btnLastPallets.BackColor = Color.Transparent;
            btnLastPallets.BackgroundImage = Properties.Resources.reiniciarMini;
            btnLastPallets.BackgroundImageLayout = ImageLayout.Center;
            btnLastPallets.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLastPallets.Location = new Point(4, 24);
            btnLastPallets.Margin = new Padding(0);
            btnLastPallets.Name = "btnLastPallets";
            btnLastPallets.Size = new Size(29, 29);
            btnLastPallets.TabIndex = 79;
            btnLastPallets.UseVisualStyleBackColor = false;
            btnLastPallets.Click += btnLastPallets_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.Location = new Point(5, 35);
            label1.Margin = new Padding(1, 0, 1, 0);
            label1.Name = "label1";
            label1.Size = new Size(81, 25);
            label1.TabIndex = 76;
            label1.Text = "BOLETA";
            // 
            // txbInvoice
            // 
            txbInvoice.Font = new Font("Segoe UI", 12F);
            txbInvoice.Location = new Point(83, 34);
            txbInvoice.Margin = new Padding(1);
            txbInvoice.MaxLength = 4;
            txbInvoice.Name = "txbInvoice";
            txbInvoice.Size = new Size(123, 29);
            txbInvoice.TabIndex = 75;
            // 
            // cboWorkPlan
            // 
            cboWorkPlan.DropDownStyle = ComboBoxStyle.DropDownList;
            cboWorkPlan.Font = new Font("Segoe UI", 12F);
            cboWorkPlan.FormattingEnabled = true;
            cboWorkPlan.Location = new Point(192, 74);
            cboWorkPlan.Margin = new Padding(1);
            cboWorkPlan.Name = "cboWorkPlan";
            cboWorkPlan.Size = new Size(614, 29);
            cboWorkPlan.TabIndex = 74;
            // 
            // dtpWorkDay
            // 
            dtpWorkDay.CalendarFont = new Font("Segoe UI", 12F);
            dtpWorkDay.Font = new Font("Segoe UI", 12F);
            dtpWorkDay.Location = new Point(525, 43);
            dtpWorkDay.Margin = new Padding(1);
            dtpWorkDay.Name = "dtpWorkDay";
            dtpWorkDay.Size = new Size(281, 29);
            dtpWorkDay.TabIndex = 73;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 14F);
            label10.Location = new Point(564, 59);
            label10.Margin = new Padding(1, 0, 1, 0);
            label10.Name = "label10";
            label10.Size = new Size(0, 25);
            label10.TabIndex = 71;
            // 
            // lblPrograma
            // 
            lblPrograma.AutoSize = true;
            lblPrograma.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblPrograma.Location = new Point(10, 74);
            lblPrograma.Margin = new Padding(1, 0, 1, 0);
            lblPrograma.Name = "lblPrograma";
            lblPrograma.Size = new Size(180, 25);
            lblPrograma.TabIndex = 69;
            lblPrograma.Text = "PLAN DE TRABAJO";
            // 
            // chBx
            // 
            chBx.AutoSize = true;
            chBx.Enabled = false;
            chBx.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            chBx.Location = new Point(666, 10);
            chBx.Margin = new Padding(1);
            chBx.Name = "chBx";
            chBx.Size = new Size(142, 23);
            chBx.TabIndex = 68;
            chBx.Text = "Empaque Central";
            chBx.TextAlign = ContentAlignment.TopLeft;
            chBx.UseVisualStyleBackColor = true;
            // 
            // btnPrintPtiTag
            // 
            btnPrintPtiTag.BackgroundImage = Properties.Resources.PrintIcon;
            btnPrintPtiTag.BackgroundImageLayout = ImageLayout.Stretch;
            btnPrintPtiTag.Location = new Point(177, 30);
            btnPrintPtiTag.Margin = new Padding(1);
            btnPrintPtiTag.Name = "btnPrintPtiTag";
            btnPrintPtiTag.Size = new Size(29, 29);
            btnPrintPtiTag.TabIndex = 67;
            btnPrintPtiTag.UseVisualStyleBackColor = true;
            btnPrintPtiTag.Click += btnPrintPtiTag_Click;
            // 
            // nudPalletTotal
            // 
            nudPalletTotal.Font = new Font("Segoe UI", 12F);
            nudPalletTotal.Location = new Point(110, 73);
            nudPalletTotal.Margin = new Padding(1);
            nudPalletTotal.Maximum = new decimal(new int[] { 8, 0, 0, 0 });
            nudPalletTotal.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudPalletTotal.Name = "nudPalletTotal";
            nudPalletTotal.Size = new Size(55, 29);
            nudPalletTotal.TabIndex = 64;
            nudPalletTotal.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label7.Location = new Point(12, 30);
            label7.Margin = new Padding(1, 0, 1, 0);
            label7.Name = "label7";
            label7.Size = new Size(97, 25);
            label7.TabIndex = 63;
            label7.Text = "Cantidad:";
            // 
            // nudPtiTotal
            // 
            nudPtiTotal.Font = new Font("Segoe UI", 12F);
            nudPtiTotal.Location = new Point(112, 30);
            nudPtiTotal.Margin = new Padding(1);
            nudPtiTotal.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudPtiTotal.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudPtiTotal.Name = "nudPtiTotal";
            nudPtiTotal.Size = new Size(55, 29);
            nudPtiTotal.TabIndex = 62;
            nudPtiTotal.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // grbTag
            // 
            grbTag.Controls.Add(lblPluNumber);
            grbTag.Controls.Add(label23);
            grbTag.Controls.Add(lable);
            grbTag.Controls.Add(label21);
            grbTag.Controls.Add(lblGtinNumber);
            grbTag.Controls.Add(lblPtiName);
            grbTag.Controls.Add(lblUpcNumber);
            grbTag.Controls.Add(label12);
            grbTag.Controls.Add(lblPtiId);
            grbTag.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            grbTag.Location = new Point(10, 537);
            grbTag.Margin = new Padding(1);
            grbTag.Name = "grbTag";
            grbTag.Padding = new Padding(1);
            grbTag.Size = new Size(336, 140);
            grbTag.TabIndex = 61;
            grbTag.TabStop = false;
            grbTag.Text = "ETIQUETA";
            // 
            // lblPluNumber
            // 
            lblPluNumber.AutoSize = true;
            lblPluNumber.Font = new Font("Segoe UI", 14F);
            lblPluNumber.Location = new Point(156, 103);
            lblPluNumber.Margin = new Padding(1, 0, 1, 0);
            lblPluNumber.Name = "lblPluNumber";
            lblPluNumber.Size = new Size(45, 25);
            lblPluNumber.TabIndex = 43;
            lblPluNumber.Text = "###";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label23.Location = new Point(91, 53);
            label23.Margin = new Padding(1, 0, 1, 0);
            label23.Name = "label23";
            label23.Size = new Size(63, 25);
            label23.TabIndex = 27;
            label23.Text = "GTIN:";
            label23.TextAlign = ContentAlignment.TopRight;
            // 
            // lable
            // 
            lable.AutoSize = true;
            lable.BackColor = SystemColors.Control;
            lable.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lable.Location = new Point(101, 103);
            lable.Margin = new Padding(1, 0, 1, 0);
            lable.Name = "lable";
            lable.Size = new Size(53, 25);
            lable.TabIndex = 36;
            lable.Text = "PLU:";
            lable.TextAlign = ContentAlignment.TopRight;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label21.Location = new Point(99, 78);
            label21.Margin = new Padding(1, 0, 1, 0);
            label21.Name = "label21";
            label21.Size = new Size(55, 25);
            label21.TabIndex = 28;
            label21.Text = "UPC:";
            label21.TextAlign = ContentAlignment.TopRight;
            // 
            // lblGtinNumber
            // 
            lblGtinNumber.AutoSize = true;
            lblGtinNumber.Font = new Font("Segoe UI", 14F);
            lblGtinNumber.Location = new Point(156, 53);
            lblGtinNumber.Margin = new Padding(1, 0, 1, 0);
            lblGtinNumber.Name = "lblGtinNumber";
            lblGtinNumber.Size = new Size(45, 25);
            lblGtinNumber.TabIndex = 29;
            lblGtinNumber.Text = "###";
            // 
            // lblPtiName
            // 
            lblPtiName.AutoSize = true;
            lblPtiName.Font = new Font("Segoe UI", 14F);
            lblPtiName.Location = new Point(185, 28);
            lblPtiName.Margin = new Padding(1, 0, 1, 0);
            lblPtiName.Name = "lblPtiName";
            lblPtiName.Size = new Size(45, 25);
            lblPtiName.TabIndex = 42;
            lblPtiName.Text = "###";
            // 
            // lblUpcNumber
            // 
            lblUpcNumber.AutoSize = true;
            lblUpcNumber.Font = new Font("Segoe UI", 14F);
            lblUpcNumber.Location = new Point(156, 78);
            lblUpcNumber.Margin = new Padding(1, 0, 1, 0);
            lblUpcNumber.Name = "lblUpcNumber";
            lblUpcNumber.Size = new Size(45, 25);
            lblUpcNumber.TabIndex = 30;
            lblUpcNumber.Text = "###";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label12.Location = new Point(13, 28);
            label12.Margin = new Padding(1, 0, 1, 0);
            label12.Name = "label12";
            label12.Size = new Size(141, 25);
            label12.TabIndex = 40;
            label12.Text = "FORMATO PTI:";
            label12.TextAlign = ContentAlignment.TopRight;
            // 
            // lblPtiId
            // 
            lblPtiId.AutoSize = true;
            lblPtiId.Font = new Font("Segoe UI", 14F);
            lblPtiId.Location = new Point(156, 28);
            lblPtiId.Margin = new Padding(1, 0, 1, 0);
            lblPtiId.Name = "lblPtiId";
            lblPtiId.Size = new Size(34, 25);
            lblPtiId.TabIndex = 41;
            lblPtiId.Text = "##";
            // 
            // grbCrop
            // 
            grbCrop.Controls.Add(lblColorName);
            grbCrop.Controls.Add(label11);
            grbCrop.Controls.Add(lblTagLote);
            grbCrop.Controls.Add(lblLotId);
            grbCrop.Controls.Add(lblTagVariety);
            grbCrop.Controls.Add(lblVarietyName);
            grbCrop.Controls.Add(lblLotName);
            grbCrop.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grbCrop.Location = new Point(10, 278);
            grbCrop.Margin = new Padding(1);
            grbCrop.Name = "grbCrop";
            grbCrop.Padding = new Padding(1);
            grbCrop.Size = new Size(564, 115);
            grbCrop.TabIndex = 60;
            grbCrop.TabStop = false;
            grbCrop.Text = "CULTIVO";
            // 
            // lblColorName
            // 
            lblColorName.AutoSize = true;
            lblColorName.Font = new Font("Segoe UI", 14F);
            lblColorName.Location = new Point(161, 76);
            lblColorName.Margin = new Padding(1, 0, 1, 0);
            lblColorName.Name = "lblColorName";
            lblColorName.Size = new Size(45, 25);
            lblColorName.TabIndex = 35;
            lblColorName.Text = "###";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = SystemColors.Control;
            label11.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label11.Location = new Point(82, 76);
            label11.Margin = new Padding(1, 0, 1, 0);
            label11.Name = "label11";
            label11.Size = new Size(79, 25);
            label11.TabIndex = 34;
            label11.Text = "COLOR:";
            // 
            // lblTagLote
            // 
            lblTagLote.AutoSize = true;
            lblTagLote.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTagLote.Location = new Point(50, 26);
            lblTagLote.Margin = new Padding(1, 0, 1, 0);
            lblTagLote.Name = "lblTagLote";
            lblTagLote.Size = new Size(61, 25);
            lblTagLote.TabIndex = 6;
            lblTagLote.Text = "LOTE:";
            // 
            // lblLotId
            // 
            lblLotId.AutoSize = true;
            lblLotId.Font = new Font("Segoe UI", 14F);
            lblLotId.Location = new Point(105, 26);
            lblLotId.Margin = new Padding(1, 0, 1, 0);
            lblLotId.Name = "lblLotId";
            lblLotId.Size = new Size(56, 25);
            lblLotId.TabIndex = 7;
            lblLotId.Text = "####";
            // 
            // lblTagVariety
            // 
            lblTagVariety.AutoSize = true;
            lblTagVariety.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTagVariety.Location = new Point(50, 51);
            lblTagVariety.Margin = new Padding(1, 0, 1, 0);
            lblTagVariety.Name = "lblTagVariety";
            lblTagVariety.Size = new Size(111, 25);
            lblTagVariety.TabIndex = 8;
            lblTagVariety.Text = "VARIEDAD:";
            // 
            // lblVarietyName
            // 
            lblVarietyName.AutoSize = true;
            lblVarietyName.Font = new Font("Segoe UI", 14F);
            lblVarietyName.Location = new Point(161, 51);
            lblVarietyName.Margin = new Padding(1, 0, 1, 0);
            lblVarietyName.Name = "lblVarietyName";
            lblVarietyName.Size = new Size(45, 25);
            lblVarietyName.TabIndex = 9;
            lblVarietyName.Text = "###";
            // 
            // lblLotName
            // 
            lblLotName.AutoSize = true;
            lblLotName.Font = new Font("Segoe UI", 14F);
            lblLotName.Location = new Point(161, 26);
            lblLotName.Margin = new Padding(1, 0, 1, 0);
            lblLotName.Name = "lblLotName";
            lblLotName.Size = new Size(45, 25);
            lblLotName.TabIndex = 10;
            lblLotName.Text = "###";
            // 
            // lblDistributorCity
            // 
            lblDistributorCity.AutoSize = true;
            lblDistributorCity.Font = new Font("Segoe UI", 14F);
            lblDistributorCity.Location = new Point(11, 109);
            lblDistributorCity.Margin = new Padding(1, 0, 1, 0);
            lblDistributorCity.Name = "lblDistributorCity";
            lblDistributorCity.Size = new Size(45, 25);
            lblDistributorCity.TabIndex = 33;
            lblDistributorCity.Text = "###";
            // 
            // lblDistributorAddress
            // 
            lblDistributorAddress.AutoSize = true;
            lblDistributorAddress.Font = new Font("Segoe UI", 14F);
            lblDistributorAddress.Location = new Point(11, 79);
            lblDistributorAddress.Margin = new Padding(1, 0, 1, 0);
            lblDistributorAddress.Name = "lblDistributorAddress";
            lblDistributorAddress.Size = new Size(45, 25);
            lblDistributorAddress.TabIndex = 32;
            lblDistributorAddress.Text = "###";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label9.Location = new Point(11, 53);
            label9.Margin = new Padding(1, 0, 1, 0);
            label9.Name = "label9";
            label9.Size = new Size(117, 25);
            label9.TabIndex = 31;
            label9.Text = "DIRECCIÓN:";
            // 
            // lblDistributorName
            // 
            lblDistributorName.AutoSize = true;
            lblDistributorName.Font = new Font("Segoe UI", 14F);
            lblDistributorName.Location = new Point(11, 28);
            lblDistributorName.Margin = new Padding(1, 0, 1, 0);
            lblDistributorName.Name = "lblDistributorName";
            lblDistributorName.Size = new Size(45, 25);
            lblDistributorName.TabIndex = 23;
            lblDistributorName.Text = "###";
            // 
            // lblTagContractorDetail
            // 
            lblTagContractorDetail.AutoSize = true;
            lblTagContractorDetail.Font = new Font("Segoe UI", 14F);
            lblTagContractorDetail.Location = new Point(525, 43);
            lblTagContractorDetail.Margin = new Padding(1, 0, 1, 0);
            lblTagContractorDetail.Name = "lblTagContractorDetail";
            lblTagContractorDetail.Size = new Size(0, 25);
            lblTagContractorDetail.TabIndex = 59;
            // 
            // cboWorkGroup
            // 
            cboWorkGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            cboWorkGroup.Font = new Font("Segoe UI", 12F);
            cboWorkGroup.FormattingEnabled = true;
            cboWorkGroup.Location = new Point(192, 43);
            cboWorkGroup.Margin = new Padding(1);
            cboWorkGroup.Name = "cboWorkGroup";
            cboWorkGroup.Size = new Size(183, 29);
            cboWorkGroup.TabIndex = 57;
            // 
            // lblTagWorkGroup
            // 
            lblTagWorkGroup.AutoSize = true;
            lblTagWorkGroup.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTagWorkGroup.Location = new Point(74, 43);
            lblTagWorkGroup.Margin = new Padding(1, 0, 1, 0);
            lblTagWorkGroup.Name = "lblTagWorkGroup";
            lblTagWorkGroup.Size = new Size(116, 25);
            lblTagWorkGroup.TabIndex = 56;
            lblTagWorkGroup.Text = "CUADRILLA";
            // 
            // lblTagHead
            // 
            lblTagHead.AutoSize = true;
            lblTagHead.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTagHead.Location = new Point(10, 9);
            lblTagHead.Margin = new Padding(1, 0, 1, 0);
            lblTagHead.Name = "lblTagHead";
            lblTagHead.Size = new Size(317, 32);
            lblTagHead.TabIndex = 55;
            lblTagHead.Text = "IMPRESIÓN DE ETIQUETAS";
            // 
            // grbProduct
            // 
            grbProduct.Controls.Add(txbBoxesTotaL);
            grbProduct.Controls.Add(label14);
            grbProduct.Controls.Add(label16);
            grbProduct.Controls.Add(label17);
            grbProduct.Controls.Add(lblLbsNum);
            grbProduct.Controls.Add(label20);
            grbProduct.Controls.Add(label22);
            grbProduct.Controls.Add(lblContainerName);
            grbProduct.Controls.Add(lblPresentationName);
            grbProduct.Controls.Add(lblSizeName);
            grbProduct.Controls.Add(label27);
            grbProduct.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            grbProduct.Location = new Point(10, 105);
            grbProduct.Margin = new Padding(1);
            grbProduct.Name = "grbProduct";
            grbProduct.Padding = new Padding(1);
            grbProduct.Size = new Size(564, 171);
            grbProduct.TabIndex = 61;
            grbProduct.TabStop = false;
            grbProduct.Text = "PRODUCTO";
            // 
            // txbBoxesTotaL
            // 
            txbBoxesTotaL.Font = new Font("Segoe UI", 12F);
            txbBoxesTotaL.Location = new Point(165, 126);
            txbBoxesTotaL.Margin = new Padding(1);
            txbBoxesTotaL.MaxLength = 6;
            txbBoxesTotaL.Name = "txbBoxesTotaL";
            txbBoxesTotaL.Size = new Size(68, 29);
            txbBoxesTotaL.TabIndex = 39;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label14.Location = new Point(26, 127);
            label14.Margin = new Padding(1, 0, 1, 0);
            label14.Name = "label14";
            label14.Size = new Size(135, 25);
            label14.TabIndex = 37;
            label14.Text = "TOTAL CAJAS:";
            label14.TextAlign = ContentAlignment.TopRight;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 14F);
            label16.Location = new Point(168, 126);
            label16.Margin = new Padding(1, 0, 1, 0);
            label16.Name = "label16";
            label16.Size = new Size(0, 25);
            label16.TabIndex = 38;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label17.Location = new Point(61, 102);
            label17.Margin = new Padding(1, 0, 1, 0);
            label17.Name = "label17";
            label17.Size = new Size(100, 25);
            label17.TabIndex = 11;
            label17.Text = "TAMAÑO:";
            label17.TextAlign = ContentAlignment.TopRight;
            // 
            // lblLbsNum
            // 
            lblLbsNum.AutoSize = true;
            lblLbsNum.Font = new Font("Segoe UI", 14F);
            lblLbsNum.Location = new Point(161, 77);
            lblLbsNum.Margin = new Padding(1, 0, 1, 0);
            lblLbsNum.Name = "lblLbsNum";
            lblLbsNum.Size = new Size(45, 25);
            lblLbsNum.TabIndex = 26;
            lblLbsNum.Text = "###";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label20.Location = new Point(4, 54);
            label20.Margin = new Padding(1, 0, 1, 0);
            label20.Name = "label20";
            label20.Size = new Size(157, 25);
            label20.TabIndex = 15;
            label20.Text = "PRESENTACIÓN:";
            label20.TextAlign = ContentAlignment.TopRight;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label22.Location = new Point(98, 28);
            label22.Margin = new Padding(1, 0, 1, 0);
            label22.Name = "label22";
            label22.Size = new Size(63, 25);
            label22.TabIndex = 13;
            label22.Text = "CAJA:";
            label22.TextAlign = ContentAlignment.TopRight;
            // 
            // lblContainerName
            // 
            lblContainerName.AutoSize = true;
            lblContainerName.Font = new Font("Segoe UI", 14F);
            lblContainerName.Location = new Point(161, 27);
            lblContainerName.Margin = new Padding(1, 0, 1, 0);
            lblContainerName.Name = "lblContainerName";
            lblContainerName.Size = new Size(45, 25);
            lblContainerName.TabIndex = 14;
            lblContainerName.Text = "###";
            // 
            // lblPresentationName
            // 
            lblPresentationName.AutoSize = true;
            lblPresentationName.Font = new Font("Segoe UI", 14F);
            lblPresentationName.Location = new Point(161, 53);
            lblPresentationName.Margin = new Padding(1, 0, 1, 0);
            lblPresentationName.Name = "lblPresentationName";
            lblPresentationName.Size = new Size(45, 25);
            lblPresentationName.TabIndex = 16;
            lblPresentationName.Text = "###";
            // 
            // lblSizeName
            // 
            lblSizeName.AutoSize = true;
            lblSizeName.Font = new Font("Segoe UI", 14F);
            lblSizeName.Location = new Point(161, 102);
            lblSizeName.Margin = new Padding(1, 0, 1, 0);
            lblSizeName.Name = "lblSizeName";
            lblSizeName.Size = new Size(45, 25);
            lblSizeName.TabIndex = 12;
            lblSizeName.Text = "###";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.BackColor = SystemColors.Control;
            label27.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label27.Location = new Point(97, 78);
            label27.Margin = new Padding(1, 0, 1, 0);
            label27.Name = "label27";
            label27.Size = new Size(64, 25);
            label27.TabIndex = 18;
            label27.Text = "PESO:";
            label27.TextAlign = ContentAlignment.TopRight;
            // 
            // grbDistributor
            // 
            grbDistributor.Controls.Add(lblDistributorName);
            grbDistributor.Controls.Add(label9);
            grbDistributor.Controls.Add(lblDistributorCity);
            grbDistributor.Controls.Add(lblDistributorAddress);
            grbDistributor.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            grbDistributor.Location = new Point(10, 395);
            grbDistributor.Margin = new Padding(1);
            grbDistributor.Name = "grbDistributor";
            grbDistributor.Padding = new Padding(1);
            grbDistributor.Size = new Size(336, 140);
            grbDistributor.TabIndex = 62;
            grbDistributor.TabStop = false;
            grbDistributor.Text = "CLIENTE";
            // 
            // lblWorkDay
            // 
            lblWorkDay.AutoSize = true;
            lblWorkDay.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblWorkDay.Location = new Point(446, 43);
            lblWorkDay.Margin = new Padding(1, 0, 1, 0);
            lblWorkDay.Name = "lblWorkDay";
            lblWorkDay.Size = new Size(77, 25);
            lblWorkDay.TabIndex = 80;
            lblWorkDay.Text = "FECHA:";
            // 
            // btnPrintPalletTag
            // 
            btnPrintPalletTag.BackgroundImage = Properties.Resources.PrintIcon;
            btnPrintPalletTag.BackgroundImageLayout = ImageLayout.Stretch;
            btnPrintPalletTag.Location = new Point(175, 73);
            btnPrintPalletTag.Margin = new Padding(1);
            btnPrintPalletTag.Name = "btnPrintPalletTag";
            btnPrintPalletTag.Size = new Size(29, 29);
            btnPrintPalletTag.TabIndex = 81;
            btnPrintPalletTag.UseVisualStyleBackColor = true;
            btnPrintPalletTag.Click += btnPrintPalletTag_Click;
            // 
            // grbPrint
            // 
            grbPrint.Controls.Add(chbReversePtiTag);
            grbPrint.Controls.Add(label7);
            grbPrint.Controls.Add(nudPtiTotal);
            grbPrint.Controls.Add(btnPrintPtiTag);
            grbPrint.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            grbPrint.Location = new Point(588, 278);
            grbPrint.Margin = new Padding(1);
            grbPrint.Name = "grbPrint";
            grbPrint.Padding = new Padding(1);
            grbPrint.Size = new Size(223, 115);
            grbPrint.TabIndex = 62;
            grbPrint.TabStop = false;
            grbPrint.Text = "CAJA / PTI";
            // 
            // chbReversePtiTag
            // 
            chbReversePtiTag.AutoSize = true;
            chbReversePtiTag.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chbReversePtiTag.Location = new Point(12, 63);
            chbReversePtiTag.Name = "chbReversePtiTag";
            chbReversePtiTag.Size = new Size(109, 19);
            chbReversePtiTag.TabIndex = 83;
            chbReversePtiTag.Text = "Invertir etiqueta";
            chbReversePtiTag.UseVisualStyleBackColor = true;
            // 
            // gpbLastPallets
            // 
            gpbLastPallets.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gpbLastPallets.Controls.Add(btnReprintPallet);
            gpbLastPallets.Controls.Add(btnLastPallets);
            gpbLastPallets.Controls.Add(dgvLastUserPallet);
            gpbLastPallets.Controls.Add(chbReverseReprintPallet);
            gpbLastPallets.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            gpbLastPallets.Location = new Point(359, 395);
            gpbLastPallets.Margin = new Padding(1);
            gpbLastPallets.Name = "gpbLastPallets";
            gpbLastPallets.Padding = new Padding(1);
            gpbLastPallets.Size = new Size(452, 282);
            gpbLastPallets.TabIndex = 82;
            gpbLastPallets.TabStop = false;
            gpbLastPallets.Text = "ÚLTIMOS PALLETS";
            // 
            // chbReverseReprintPallet
            // 
            chbReverseReprintPallet.AutoSize = true;
            chbReverseReprintPallet.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chbReverseReprintPallet.Location = new Point(67, 36);
            chbReverseReprintPallet.Name = "chbReverseReprintPallet";
            chbReverseReprintPallet.Size = new Size(109, 19);
            chbReverseReprintPallet.TabIndex = 83;
            chbReverseReprintPallet.Text = "Invertir etiqueta";
            chbReverseReprintPallet.UseVisualStyleBackColor = true;
            // 
            // btnReprintPallet
            // 
            btnReprintPallet.BackgroundImage = Properties.Resources.PrintIcon;
            btnReprintPallet.BackgroundImageLayout = ImageLayout.Stretch;
            btnReprintPallet.Location = new Point(34, 24);
            btnReprintPallet.Margin = new Padding(1);
            btnReprintPallet.Name = "btnReprintPallet";
            btnReprintPallet.Size = new Size(29, 29);
            btnReprintPallet.TabIndex = 84;
            btnReprintPallet.UseVisualStyleBackColor = true;
            btnReprintPallet.Click += button1_Click;
            // 
            // dgvLastUserPallet
            // 
            dgvLastUserPallet.AllowUserToAddRows = false;
            dgvLastUserPallet.AllowUserToDeleteRows = false;
            dgvLastUserPallet.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvLastUserPallet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            dgvLastUserPallet.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvLastUserPallet.BackgroundColor = SystemColors.ButtonFace;
            dgvLastUserPallet.BorderStyle = BorderStyle.Fixed3D;
            dgvLastUserPallet.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvLastUserPallet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvLastUserPallet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Window;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dgvLastUserPallet.DefaultCellStyle = dataGridViewCellStyle5;
            dgvLastUserPallet.EnableHeadersVisualStyles = false;
            dgvLastUserPallet.ImeMode = ImeMode.NoControl;
            dgvLastUserPallet.Location = new Point(4, 53);
            dgvLastUserPallet.Name = "dgvLastUserPallet";
            dgvLastUserPallet.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Control;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dgvLastUserPallet.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dgvLastUserPallet.RowHeadersVisible = false;
            dgvLastUserPallet.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvLastUserPallet.RowTemplate.Height = 25;
            dgvLastUserPallet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLastUserPallet.Size = new Size(444, 225);
            dgvLastUserPallet.TabIndex = 80;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(chbRevesePalletTag);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(nudPalletTotal);
            groupBox1.Controls.Add(txbInvoice);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnPrintPalletTag);
            groupBox1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            groupBox1.Location = new Point(588, 105);
            groupBox1.Margin = new Padding(1);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(1);
            groupBox1.Size = new Size(223, 171);
            groupBox1.TabIndex = 68;
            groupBox1.TabStop = false;
            groupBox1.Text = "PALLET";
            // 
            // chbRevesePalletTag
            // 
            chbRevesePalletTag.AutoSize = true;
            chbRevesePalletTag.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chbRevesePalletTag.Location = new Point(10, 106);
            chbRevesePalletTag.Name = "chbRevesePalletTag";
            chbRevesePalletTag.Size = new Size(109, 19);
            chbRevesePalletTag.TabIndex = 82;
            chbRevesePalletTag.Text = "Invertir etiqueta";
            chbRevesePalletTag.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label2.Location = new Point(10, 73);
            label2.Margin = new Padding(1, 0, 1, 0);
            label2.Name = "label2";
            label2.Size = new Size(97, 25);
            label2.TabIndex = 68;
            label2.Text = "Cantidad:";
            // 
            // FrmPrintLabelsPtiPallets
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(822, 687);
            Controls.Add(groupBox1);
            Controls.Add(gpbLastPallets);
            Controls.Add(grbPrint);
            Controls.Add(lblWorkDay);
            Controls.Add(grbDistributor);
            Controls.Add(cboWorkPlan);
            Controls.Add(grbProduct);
            Controls.Add(dtpWorkDay);
            Controls.Add(label10);
            Controls.Add(chBx);
            Controls.Add(lblPrograma);
            Controls.Add(grbTag);
            Controls.Add(grbCrop);
            Controls.Add(lblTagContractorDetail);
            Controls.Add(cboWorkGroup);
            Controls.Add(lblTagWorkGroup);
            Controls.Add(lblTagHead);
            Name = "FrmPrintLabelsPtiPallets";
            Text = "Impresión de etiquetas PTI y Pallet";
            WindowState = FormWindowState.Maximized;
            Load += FrmPrintLabelsPtiPallets_Load;
            ((System.ComponentModel.ISupportInitialize)nudPalletTotal).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPtiTotal).EndInit();
            grbTag.ResumeLayout(false);
            grbTag.PerformLayout();
            grbCrop.ResumeLayout(false);
            grbCrop.PerformLayout();
            grbProduct.ResumeLayout(false);
            grbProduct.PerformLayout();
            grbDistributor.ResumeLayout(false);
            grbDistributor.PerformLayout();
            grbPrint.ResumeLayout(false);
            grbPrint.PerformLayout();
            gpbLastPallets.ResumeLayout(false);
            gpbLastPallets.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLastUserPallet).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLastPallets;
        private Label label1;
        private Label label10;
        private Label lblPrograma;
        private CheckBox chBx;
        private Button btnPrintPtiTag;
        private Label label7;
        private GroupBox grbTag;
        private GroupBox grbCrop;
        private Label label11;
        private Label label9;
        private Label lblTagLote;
        private Label lblTagVariety;
        private Label lblTagContractorDetail;
        private Label lblTagContratista;
        private Label lblTagWorkGroup;
        private Label lblTagHead;
        public ComboBox cboWorkPlan;
        public ComboBox cboWorkGroup;
        public DateTimePicker dtpWorkDay;
        private GroupBox grbProduct;
        public Label lblPtiId;
        private Label label12;
        public Label lblUpcNumber;
        public Label lblGtinNumber;
        private Label label21;
        private Label label23;
        public Label lblColorName;
        public Label lblDistributorCity;
        public Label lblDistributorAddress;
        public Label lblLotId;
        public Label lblDistributorName;
        public Label lblVarietyName;
        public Label lblLotName;
        public Label lblPtiName;
        private Label lable;
        public Label lblPluNumber;
        public NumericUpDown nudPtiTotal;
        public TextBox txbBoxesTotaL;
        private Label label14;
        private Label label16;
        private Label label17;
        public Label lblLbsNum;
        private Label label20;
        private Label label22;
        public Label lblContainerName;
        public Label lblPresentationName;
        public Label lblSizeName;
        private Label label27;
        private GroupBox grbDistributor;
        private Label lblWorkDay;
        private Button btnPrintPalletTag;
        private GroupBox grbPrint;
        private GroupBox gpbLastPallets;
        public NumericUpDown nudPalletTotal;
        public TextBox txbInvoice;
        private GroupBox groupBox1;
        private Label label2;
        public DataGridView dgvLastUserPallet;
        private Button btnReprintPallet;
        public CheckBox chbRevesePalletTag;
        public CheckBox chbReversePtiTag;
        public CheckBox chbReverseReprintPallet;
    }
}