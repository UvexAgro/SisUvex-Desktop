namespace SisUvex.Archivo.Etiquetas
{
    partial class FrmEtiquetas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEtiquetas));
            lblTagHead = new Label();
            lblTagWorkGroup = new Label();
            cmBoxWorkGroup = new ComboBox();
            lblTagContratista = new Label();
            lblTagContractorDetail = new Label();
            lblTagLotCodeDetail = new Label();
            lblTagLote = new Label();
            lblTagVarietyDetail = new Label();
            lblTagVariety = new Label();
            lblTagLoteNameDetail = new Label();
            lblFruitSize = new Label();
            label2 = new Label();
            lblTagMicroDetails = new Label();
            label4 = new Label();
            lblTagPresentacionDetail = new Label();
            lblPlresentacion = new Label();
            lblTagCajaDetail = new Label();
            lblTagCaja = new Label();
            lblTagMateriales = new Label();
            lblTagCrop = new Label();
            lblTagCliente = new Label();
            lblTagClientDetail = new Label();
            lblTagSO2 = new Label();
            lblTagWeightDetails = new Label();
            groupBox1 = new GroupBox();
            lblTagColor = new Label();
            label11 = new Label();
            lblAdress2 = new Label();
            lblAdress1 = new Label();
            label9 = new Label();
            lblUPCDetails = new Label();
            lblGtinDetails = new Label();
            lblUPC = new Label();
            lblGtin = new Label();
            groupBox2 = new GroupBox();
            lblTagPallet = new Label();
            lblTagPalletDetails = new Label();
            txbTotalBox = new TextBox();
            lblTagTotalBox = new Label();
            lblTagTotalBoxDetails = new Label();
            label5 = new Label();
            lblTagLidsDetails = new Label();
            lblTagLids = new Label();
            lblTagFoamDetails = new Label();
            lblTagFoam = new Label();
            lblSleeve = new Label();
            lblTagCinturonDetails = new Label();
            lblTagLoteDetails = new Label();
            lblTagLoteTag = new Label();
            lblTagSO2Details = new Label();
            label3 = new Label();
            copiesPTI = new NumericUpDown();
            label7 = new Label();
            label8 = new Label();
            copiesPallet = new NumericUpDown();
            button1 = new Button();
            button2 = new Button();
            chBx = new CheckBox();
            cmBoxPrograma = new ComboBox();
            lblPrograma = new Label();
            label10 = new Label();
            dTPWorkDay = new DateTimePicker();
            cmBxIdWorkPlan = new ComboBox();
            txbPaperWork = new TextBox();
            label1 = new Label();
            chBxAlbertson = new CheckBox();
            dgvLastUserPallet = new DataGridView();
            button5 = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)copiesPTI).BeginInit();
            ((System.ComponentModel.ISupportInitialize)copiesPallet).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvLastUserPallet).BeginInit();
            SuspendLayout();
            // 
            // lblTagHead
            // 
            lblTagHead.AutoSize = true;
            lblTagHead.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTagHead.Location = new Point(187, 13);
            lblTagHead.Margin = new Padding(1, 0, 1, 0);
            lblTagHead.Name = "lblTagHead";
            lblTagHead.Size = new Size(317, 32);
            lblTagHead.TabIndex = 1;
            lblTagHead.Text = "IMPRESION DE ETIQUETAS";
            // 
            // lblTagWorkGroup
            // 
            lblTagWorkGroup.AutoSize = true;
            lblTagWorkGroup.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTagWorkGroup.Location = new Point(93, 63);
            lblTagWorkGroup.Margin = new Padding(1, 0, 1, 0);
            lblTagWorkGroup.Name = "lblTagWorkGroup";
            lblTagWorkGroup.Size = new Size(116, 25);
            lblTagWorkGroup.TabIndex = 2;
            lblTagWorkGroup.Text = "CUADRILLA";
            // 
            // cmBoxWorkGroup
            // 
            cmBoxWorkGroup.Font = new Font("Segoe UI", 12F);
            cmBoxWorkGroup.FormattingEnabled = true;
            cmBoxWorkGroup.Location = new Point(223, 68);
            cmBoxWorkGroup.Margin = new Padding(1);
            cmBoxWorkGroup.Name = "cmBoxWorkGroup";
            cmBoxWorkGroup.Size = new Size(127, 29);
            cmBoxWorkGroup.TabIndex = 3;
            cmBoxWorkGroup.SelectedIndexChanged += cmBoxWorkGroup_SelectedIndexChanged;
            // 
            // lblTagContratista
            // 
            lblTagContratista.AutoSize = true;
            lblTagContratista.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTagContratista.Location = new Point(419, 63);
            lblTagContratista.Margin = new Padding(1, 0, 1, 0);
            lblTagContratista.Name = "lblTagContratista";
            lblTagContratista.Size = new Size(144, 25);
            lblTagContratista.TabIndex = 4;
            lblTagContratista.Text = "CONTRATISTA:";
            // 
            // lblTagContractorDetail
            // 
            lblTagContractorDetail.AutoSize = true;
            lblTagContractorDetail.Font = new Font("Segoe UI", 14F);
            lblTagContractorDetail.Location = new Point(511, 63);
            lblTagContractorDetail.Margin = new Padding(1, 0, 1, 0);
            lblTagContractorDetail.Name = "lblTagContractorDetail";
            lblTagContractorDetail.Size = new Size(0, 25);
            lblTagContractorDetail.TabIndex = 5;
            // 
            // lblTagLotCodeDetail
            // 
            lblTagLotCodeDetail.AutoSize = true;
            lblTagLotCodeDetail.Font = new Font("Segoe UI", 14F);
            lblTagLotCodeDetail.Location = new Point(82, 36);
            lblTagLotCodeDetail.Margin = new Padding(1, 0, 1, 0);
            lblTagLotCodeDetail.Name = "lblTagLotCodeDetail";
            lblTagLotCodeDetail.Size = new Size(45, 25);
            lblTagLotCodeDetail.TabIndex = 7;
            lblTagLotCodeDetail.Text = "###";
            // 
            // lblTagLote
            // 
            lblTagLote.AutoSize = true;
            lblTagLote.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTagLote.Location = new Point(13, 36);
            lblTagLote.Margin = new Padding(1, 0, 1, 0);
            lblTagLote.Name = "lblTagLote";
            lblTagLote.Size = new Size(61, 25);
            lblTagLote.TabIndex = 6;
            lblTagLote.Text = "LOTE:";
            // 
            // lblTagVarietyDetail
            // 
            lblTagVarietyDetail.AutoSize = true;
            lblTagVarietyDetail.Font = new Font("Segoe UI", 14F);
            lblTagVarietyDetail.Location = new Point(142, 67);
            lblTagVarietyDetail.Margin = new Padding(1, 0, 1, 0);
            lblTagVarietyDetail.Name = "lblTagVarietyDetail";
            lblTagVarietyDetail.Size = new Size(45, 25);
            lblTagVarietyDetail.TabIndex = 9;
            lblTagVarietyDetail.Text = "###";
            // 
            // lblTagVariety
            // 
            lblTagVariety.AutoSize = true;
            lblTagVariety.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTagVariety.Location = new Point(13, 67);
            lblTagVariety.Margin = new Padding(1, 0, 1, 0);
            lblTagVariety.Name = "lblTagVariety";
            lblTagVariety.Size = new Size(111, 25);
            lblTagVariety.TabIndex = 8;
            lblTagVariety.Text = "VARIEDAD:";
            // 
            // lblTagLoteNameDetail
            // 
            lblTagLoteNameDetail.AutoSize = true;
            lblTagLoteNameDetail.Font = new Font("Segoe UI", 14F);
            lblTagLoteNameDetail.Location = new Point(152, 36);
            lblTagLoteNameDetail.Margin = new Padding(1, 0, 1, 0);
            lblTagLoteNameDetail.Name = "lblTagLoteNameDetail";
            lblTagLoteNameDetail.Size = new Size(45, 25);
            lblTagLoteNameDetail.TabIndex = 10;
            lblTagLoteNameDetail.Text = "###";
            // 
            // lblFruitSize
            // 
            lblFruitSize.AutoSize = true;
            lblFruitSize.Font = new Font("Segoe UI", 14F);
            lblFruitSize.Location = new Point(142, 90);
            lblFruitSize.Margin = new Padding(1, 0, 1, 0);
            lblFruitSize.Name = "lblFruitSize";
            lblFruitSize.Size = new Size(45, 25);
            lblFruitSize.TabIndex = 12;
            lblFruitSize.Text = "###";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label2.Location = new Point(21, 90);
            label2.Margin = new Padding(1, 0, 1, 0);
            label2.Name = "label2";
            label2.Size = new Size(100, 25);
            label2.TabIndex = 11;
            label2.Text = "TAMAÑO:";
            // 
            // lblTagMicroDetails
            // 
            lblTagMicroDetails.AutoSize = true;
            lblTagMicroDetails.Font = new Font("Segoe UI", 14F);
            lblTagMicroDetails.Location = new Point(184, 225);
            lblTagMicroDetails.Margin = new Padding(1, 0, 1, 0);
            lblTagMicroDetails.Name = "lblTagMicroDetails";
            lblTagMicroDetails.Size = new Size(45, 25);
            lblTagMicroDetails.TabIndex = 19;
            lblTagMicroDetails.Text = "###";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.Control;
            label4.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label4.Location = new Point(60, 113);
            label4.Margin = new Padding(1, 0, 1, 0);
            label4.Name = "label4";
            label4.Size = new Size(64, 25);
            label4.TabIndex = 18;
            label4.Text = "PESO:";
            // 
            // lblTagPresentacionDetail
            // 
            lblTagPresentacionDetail.AutoSize = true;
            lblTagPresentacionDetail.Font = new Font("Segoe UI", 14F);
            lblTagPresentacionDetail.Location = new Point(177, 67);
            lblTagPresentacionDetail.Margin = new Padding(1, 0, 1, 0);
            lblTagPresentacionDetail.Name = "lblTagPresentacionDetail";
            lblTagPresentacionDetail.Size = new Size(45, 25);
            lblTagPresentacionDetail.TabIndex = 16;
            lblTagPresentacionDetail.Text = "###";
            // 
            // lblPlresentacion
            // 
            lblPlresentacion.AutoSize = true;
            lblPlresentacion.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblPlresentacion.Location = new Point(10, 67);
            lblPlresentacion.Margin = new Padding(1, 0, 1, 0);
            lblPlresentacion.Name = "lblPlresentacion";
            lblPlresentacion.Size = new Size(157, 25);
            lblPlresentacion.TabIndex = 15;
            lblPlresentacion.Text = "PRESENTACIÓN:";
            // 
            // lblTagCajaDetail
            // 
            lblTagCajaDetail.AutoSize = true;
            lblTagCajaDetail.Font = new Font("Segoe UI", 14F);
            lblTagCajaDetail.Location = new Point(174, 41);
            lblTagCajaDetail.Margin = new Padding(1, 0, 1, 0);
            lblTagCajaDetail.Name = "lblTagCajaDetail";
            lblTagCajaDetail.Size = new Size(45, 25);
            lblTagCajaDetail.TabIndex = 14;
            lblTagCajaDetail.Text = "###";
            // 
            // lblTagCaja
            // 
            lblTagCaja.AutoSize = true;
            lblTagCaja.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTagCaja.Location = new Point(105, 41);
            lblTagCaja.Margin = new Padding(1, 0, 1, 0);
            lblTagCaja.Name = "lblTagCaja";
            lblTagCaja.Size = new Size(63, 25);
            lblTagCaja.TabIndex = 13;
            lblTagCaja.Text = "CAJA:";
            // 
            // lblTagMateriales
            // 
            lblTagMateriales.AutoSize = true;
            lblTagMateriales.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTagMateriales.Location = new Point(110, 8);
            lblTagMateriales.Margin = new Padding(1, 0, 1, 0);
            lblTagMateriales.Name = "lblTagMateriales";
            lblTagMateriales.Size = new Size(125, 25);
            lblTagMateriales.TabIndex = 20;
            lblTagMateriales.Text = "MATERIALES";
            // 
            // lblTagCrop
            // 
            lblTagCrop.AutoSize = true;
            lblTagCrop.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTagCrop.Location = new Point(58, 8);
            lblTagCrop.Margin = new Padding(1, 0, 1, 0);
            lblTagCrop.Name = "lblTagCrop";
            lblTagCrop.Size = new Size(91, 25);
            lblTagCrop.TabIndex = 21;
            lblTagCrop.Text = "CULTIVO";
            // 
            // lblTagCliente
            // 
            lblTagCliente.AutoSize = true;
            lblTagCliente.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTagCliente.Location = new Point(58, 183);
            lblTagCliente.Margin = new Padding(1, 0, 1, 0);
            lblTagCliente.Name = "lblTagCliente";
            lblTagCliente.Size = new Size(86, 25);
            lblTagCliente.TabIndex = 22;
            lblTagCliente.Text = "CLIENTE";
            // 
            // lblTagClientDetail
            // 
            lblTagClientDetail.AutoSize = true;
            lblTagClientDetail.Font = new Font("Segoe UI", 14F);
            lblTagClientDetail.Location = new Point(13, 220);
            lblTagClientDetail.Margin = new Padding(1, 0, 1, 0);
            lblTagClientDetail.Name = "lblTagClientDetail";
            lblTagClientDetail.Size = new Size(45, 25);
            lblTagClientDetail.TabIndex = 23;
            lblTagClientDetail.Text = "###";
            // 
            // lblTagSO2
            // 
            lblTagSO2.AutoSize = true;
            lblTagSO2.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTagSO2.Location = new Point(36, 225);
            lblTagSO2.Margin = new Padding(1, 0, 1, 0);
            lblTagSO2.Name = "lblTagSO2";
            lblTagSO2.Size = new Size(137, 25);
            lblTagSO2.TabIndex = 24;
            lblTagSO2.Text = "MICRO LINER:";
            // 
            // lblTagWeightDetails
            // 
            lblTagWeightDetails.AutoSize = true;
            lblTagWeightDetails.Font = new Font("Segoe UI", 14F);
            lblTagWeightDetails.Location = new Point(142, 113);
            lblTagWeightDetails.Margin = new Padding(1, 0, 1, 0);
            lblTagWeightDetails.Name = "lblTagWeightDetails";
            lblTagWeightDetails.Size = new Size(45, 25);
            lblTagWeightDetails.TabIndex = 26;
            lblTagWeightDetails.Text = "###";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblTagColor);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(lblAdress2);
            groupBox1.Controls.Add(lblAdress1);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(lblUPCDetails);
            groupBox1.Controls.Add(lblGtinDetails);
            groupBox1.Controls.Add(lblUPC);
            groupBox1.Controls.Add(lblGtin);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(lblTagWeightDetails);
            groupBox1.Controls.Add(lblTagLote);
            groupBox1.Controls.Add(lblTagLotCodeDetail);
            groupBox1.Controls.Add(lblTagVariety);
            groupBox1.Controls.Add(lblTagClientDetail);
            groupBox1.Controls.Add(lblTagVarietyDetail);
            groupBox1.Controls.Add(lblTagCliente);
            groupBox1.Controls.Add(lblTagLoteNameDetail);
            groupBox1.Controls.Add(lblTagCrop);
            groupBox1.Controls.Add(lblFruitSize);
            groupBox1.Controls.Add(label4);
            groupBox1.Location = new Point(24, 139);
            groupBox1.Margin = new Padding(1);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(1);
            groupBox1.Size = new Size(286, 397);
            groupBox1.TabIndex = 27;
            groupBox1.TabStop = false;
            groupBox1.Text = "grBxFruit";
            // 
            // lblTagColor
            // 
            lblTagColor.AutoSize = true;
            lblTagColor.Font = new Font("Segoe UI", 14F);
            lblTagColor.Location = new Point(142, 136);
            lblTagColor.Margin = new Padding(1, 0, 1, 0);
            lblTagColor.Name = "lblTagColor";
            lblTagColor.Size = new Size(45, 25);
            lblTagColor.TabIndex = 35;
            lblTagColor.Text = "###";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = SystemColors.Control;
            label11.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label11.Location = new Point(44, 136);
            label11.Margin = new Padding(1, 0, 1, 0);
            label11.Name = "label11";
            label11.Size = new Size(79, 25);
            label11.TabIndex = 34;
            label11.Text = "COLOR:";
            // 
            // lblAdress2
            // 
            lblAdress2.AutoSize = true;
            lblAdress2.Font = new Font("Segoe UI", 14F);
            lblAdress2.Location = new Point(21, 307);
            lblAdress2.Margin = new Padding(1, 0, 1, 0);
            lblAdress2.Name = "lblAdress2";
            lblAdress2.Size = new Size(45, 25);
            lblAdress2.TabIndex = 33;
            lblAdress2.Text = "###";
            // 
            // lblAdress1
            // 
            lblAdress1.AutoSize = true;
            lblAdress1.Font = new Font("Segoe UI", 14F);
            lblAdress1.Location = new Point(21, 277);
            lblAdress1.Margin = new Padding(1, 0, 1, 0);
            lblAdress1.Name = "lblAdress1";
            lblAdress1.Size = new Size(45, 25);
            lblAdress1.TabIndex = 32;
            lblAdress1.Text = "###";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label9.Location = new Point(9, 251);
            label9.Margin = new Padding(1, 0, 1, 0);
            label9.Name = "label9";
            label9.Size = new Size(117, 25);
            label9.TabIndex = 31;
            label9.Text = "DIRECCIÓN:";
            // 
            // lblUPCDetails
            // 
            lblUPCDetails.AutoSize = true;
            lblUPCDetails.Font = new Font("Segoe UI", 14F);
            lblUPCDetails.Location = new Point(74, 363);
            lblUPCDetails.Margin = new Padding(1, 0, 1, 0);
            lblUPCDetails.Name = "lblUPCDetails";
            lblUPCDetails.Size = new Size(45, 25);
            lblUPCDetails.TabIndex = 30;
            lblUPCDetails.Text = "###";
            // 
            // lblGtinDetails
            // 
            lblGtinDetails.AutoSize = true;
            lblGtinDetails.Font = new Font("Segoe UI", 14F);
            lblGtinDetails.Location = new Point(74, 329);
            lblGtinDetails.Margin = new Padding(1, 0, 1, 0);
            lblGtinDetails.Name = "lblGtinDetails";
            lblGtinDetails.Size = new Size(45, 25);
            lblGtinDetails.TabIndex = 29;
            lblGtinDetails.Text = "###";
            // 
            // lblUPC
            // 
            lblUPC.AutoSize = true;
            lblUPC.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblUPC.Location = new Point(13, 363);
            lblUPC.Margin = new Padding(1, 0, 1, 0);
            lblUPC.Name = "lblUPC";
            lblUPC.Size = new Size(55, 25);
            lblUPC.TabIndex = 28;
            lblUPC.Text = "UPC:";
            // 
            // lblGtin
            // 
            lblGtin.AutoSize = true;
            lblGtin.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblGtin.Location = new Point(5, 329);
            lblGtin.Margin = new Padding(1, 0, 1, 0);
            lblGtin.Name = "lblGtin";
            lblGtin.Size = new Size(63, 25);
            lblGtin.TabIndex = 27;
            lblGtin.Text = "GTIN:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lblTagPallet);
            groupBox2.Controls.Add(lblTagPalletDetails);
            groupBox2.Controls.Add(txbTotalBox);
            groupBox2.Controls.Add(lblTagTotalBox);
            groupBox2.Controls.Add(lblTagTotalBoxDetails);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(lblTagLidsDetails);
            groupBox2.Controls.Add(lblTagLids);
            groupBox2.Controls.Add(lblTagFoamDetails);
            groupBox2.Controls.Add(lblTagFoam);
            groupBox2.Controls.Add(lblSleeve);
            groupBox2.Controls.Add(lblTagCinturonDetails);
            groupBox2.Controls.Add(lblTagLoteDetails);
            groupBox2.Controls.Add(lblTagLoteTag);
            groupBox2.Controls.Add(lblTagSO2Details);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(lblPlresentacion);
            groupBox2.Controls.Add(lblTagCaja);
            groupBox2.Controls.Add(lblTagCajaDetail);
            groupBox2.Controls.Add(lblTagSO2);
            groupBox2.Controls.Add(lblTagPresentacionDetail);
            groupBox2.Controls.Add(lblTagMateriales);
            groupBox2.Controls.Add(lblTagMicroDetails);
            groupBox2.Location = new Point(350, 139);
            groupBox2.Margin = new Padding(1);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(1);
            groupBox2.Size = new Size(375, 397);
            groupBox2.TabIndex = 28;
            groupBox2.TabStop = false;
            groupBox2.Text = "grBxMaterials";
            groupBox2.Enter += groupBox2_Enter;
            // 
            // lblTagPallet
            // 
            lblTagPallet.AutoSize = true;
            lblTagPallet.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTagPallet.Location = new Point(78, 90);
            lblTagPallet.Margin = new Padding(1, 0, 1, 0);
            lblTagPallet.Name = "lblTagPallet";
            lblTagPallet.Size = new Size(89, 25);
            lblTagPallet.TabIndex = 40;
            lblTagPallet.Text = "TARIMA:";
            // 
            // lblTagPalletDetails
            // 
            lblTagPalletDetails.AutoSize = true;
            lblTagPalletDetails.Font = new Font("Segoe UI", 14F);
            lblTagPalletDetails.Location = new Point(177, 90);
            lblTagPalletDetails.Margin = new Padding(1, 0, 1, 0);
            lblTagPalletDetails.Name = "lblTagPalletDetails";
            lblTagPalletDetails.Size = new Size(45, 25);
            lblTagPalletDetails.TabIndex = 41;
            lblTagPalletDetails.Text = "###";
            // 
            // txbTotalBox
            // 
            txbTotalBox.Font = new Font("Segoe UI", 12F);
            txbTotalBox.Location = new Point(273, 116);
            txbTotalBox.Margin = new Padding(1);
            txbTotalBox.Name = "txbTotalBox";
            txbTotalBox.Size = new Size(68, 29);
            txbTotalBox.TabIndex = 39;
            // 
            // lblTagTotalBox
            // 
            lblTagTotalBox.AutoSize = true;
            lblTagTotalBox.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTagTotalBox.Location = new Point(30, 116);
            lblTagTotalBox.Margin = new Padding(1, 0, 1, 0);
            lblTagTotalBox.Name = "lblTagTotalBox";
            lblTagTotalBox.Size = new Size(135, 25);
            lblTagTotalBox.TabIndex = 37;
            lblTagTotalBox.Text = "TOTAL CAJAS:";
            // 
            // lblTagTotalBoxDetails
            // 
            lblTagTotalBoxDetails.AutoSize = true;
            lblTagTotalBoxDetails.Font = new Font("Segoe UI", 14F);
            lblTagTotalBoxDetails.Location = new Point(177, 116);
            lblTagTotalBoxDetails.Margin = new Padding(1, 0, 1, 0);
            lblTagTotalBoxDetails.Name = "lblTagTotalBoxDetails";
            lblTagTotalBoxDetails.Size = new Size(0, 25);
            lblTagTotalBoxDetails.TabIndex = 38;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label5.Location = new Point(119, 174);
            label5.Margin = new Padding(1, 0, 1, 0);
            label5.Name = "label5";
            label5.Size = new Size(130, 25);
            label5.TabIndex = 34;
            label5.Text = "MISCELANEA";
            // 
            // lblTagLidsDetails
            // 
            lblTagLidsDetails.AutoSize = true;
            lblTagLidsDetails.Font = new Font("Segoe UI", 14F);
            lblTagLidsDetails.Location = new Point(182, 369);
            lblTagLidsDetails.Margin = new Padding(1, 0, 1, 0);
            lblTagLidsDetails.Name = "lblTagLidsDetails";
            lblTagLidsDetails.Size = new Size(45, 25);
            lblTagLidsDetails.TabIndex = 34;
            lblTagLidsDetails.Text = "###";
            // 
            // lblTagLids
            // 
            lblTagLids.AutoSize = true;
            lblTagLids.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTagLids.Location = new Point(119, 369);
            lblTagLids.Margin = new Padding(1, 0, 1, 0);
            lblTagLids.Name = "lblTagLids";
            lblTagLids.Size = new Size(58, 25);
            lblTagLids.TabIndex = 33;
            lblTagLids.Text = "LIDS:";
            // 
            // lblTagFoamDetails
            // 
            lblTagFoamDetails.AutoSize = true;
            lblTagFoamDetails.Font = new Font("Segoe UI", 14F);
            lblTagFoamDetails.Location = new Point(182, 340);
            lblTagFoamDetails.Margin = new Padding(1, 0, 1, 0);
            lblTagFoamDetails.Name = "lblTagFoamDetails";
            lblTagFoamDetails.Size = new Size(45, 25);
            lblTagFoamDetails.TabIndex = 32;
            lblTagFoamDetails.Text = "###";
            // 
            // lblTagFoam
            // 
            lblTagFoam.AutoSize = true;
            lblTagFoam.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTagFoam.Location = new Point(102, 340);
            lblTagFoam.Margin = new Padding(1, 0, 1, 0);
            lblTagFoam.Name = "lblTagFoam";
            lblTagFoam.Size = new Size(72, 25);
            lblTagFoam.TabIndex = 31;
            lblTagFoam.Text = "FOAM:";
            // 
            // lblSleeve
            // 
            lblSleeve.AutoSize = true;
            lblSleeve.Font = new Font("Segoe UI", 14F);
            lblSleeve.Location = new Point(184, 313);
            lblSleeve.Margin = new Padding(1, 0, 1, 0);
            lblSleeve.Name = "lblSleeve";
            lblSleeve.Size = new Size(45, 25);
            lblSleeve.TabIndex = 30;
            lblSleeve.Text = "###";
            // 
            // lblTagCinturonDetails
            // 
            lblTagCinturonDetails.AutoSize = true;
            lblTagCinturonDetails.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTagCinturonDetails.Location = new Point(58, 314);
            lblTagCinturonDetails.Margin = new Padding(1, 0, 1, 0);
            lblTagCinturonDetails.Name = "lblTagCinturonDetails";
            lblTagCinturonDetails.Size = new Size(116, 25);
            lblTagCinturonDetails.TabIndex = 29;
            lblTagCinturonDetails.Text = "CINTURON:";
            // 
            // lblTagLoteDetails
            // 
            lblTagLoteDetails.AutoSize = true;
            lblTagLoteDetails.Font = new Font("Segoe UI", 14F);
            lblTagLoteDetails.Location = new Point(184, 283);
            lblTagLoteDetails.Margin = new Padding(1, 0, 1, 0);
            lblTagLoteDetails.Name = "lblTagLoteDetails";
            lblTagLoteDetails.Size = new Size(45, 25);
            lblTagLoteDetails.TabIndex = 28;
            lblTagLoteDetails.Text = "###";
            // 
            // lblTagLoteTag
            // 
            lblTagLoteTag.AutoSize = true;
            lblTagLoteTag.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTagLoteTag.Location = new Point(17, 283);
            lblTagLoteTag.Margin = new Padding(1, 0, 1, 0);
            lblTagLoteTag.Name = "lblTagLoteTag";
            lblTagLoteTag.Size = new Size(155, 25);
            lblTagLoteTag.TabIndex = 27;
            lblTagLoteTag.Text = "ET LOTE/FECHA:";
            // 
            // lblTagSO2Details
            // 
            lblTagSO2Details.AutoSize = true;
            lblTagSO2Details.Font = new Font("Segoe UI", 14F);
            lblTagSO2Details.Location = new Point(184, 256);
            lblTagSO2Details.Margin = new Padding(1, 0, 1, 0);
            lblTagSO2Details.Name = "lblTagSO2Details";
            lblTagSO2Details.Size = new Size(45, 25);
            lblTagSO2Details.TabIndex = 26;
            lblTagSO2Details.Text = "###";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label3.Location = new Point(123, 256);
            label3.Margin = new Padding(1, 0, 1, 0);
            label3.Name = "label3";
            label3.Size = new Size(53, 25);
            label3.TabIndex = 25;
            label3.Text = "SO2:";
            // 
            // copiesPTI
            // 
            copiesPTI.Location = new Point(827, 217);
            copiesPTI.Margin = new Padding(1);
            copiesPTI.Name = "copiesPTI";
            copiesPTI.Size = new Size(124, 23);
            copiesPTI.TabIndex = 29;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label7.Location = new Point(910, 180);
            label7.Margin = new Padding(1, 0, 1, 0);
            label7.Name = "label7";
            label7.Size = new Size(41, 25);
            label7.TabIndex = 37;
            label7.Text = "PTI";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label8.Location = new Point(874, 340);
            label8.Margin = new Padding(1, 0, 1, 0);
            label8.Name = "label8";
            label8.Size = new Size(77, 25);
            label8.TabIndex = 39;
            label8.Text = "PALLET";
            // 
            // copiesPallet
            // 
            copiesPallet.Location = new Point(827, 376);
            copiesPallet.Margin = new Padding(1);
            copiesPallet.Name = "copiesPallet";
            copiesPallet.Size = new Size(124, 23);
            copiesPallet.TabIndex = 38;
            // 
            // button1
            // 
            button1.Location = new Point(873, 258);
            button1.Margin = new Padding(1);
            button1.Name = "button1";
            button1.Size = new Size(77, 21);
            button1.TabIndex = 40;
            button1.Text = "IMPRIMIR";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(880, 412);
            button2.Margin = new Padding(1);
            button2.Name = "button2";
            button2.Size = new Size(77, 21);
            button2.TabIndex = 41;
            button2.Text = "IMPRIMIR";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // chBx
            // 
            chBx.AutoSize = true;
            chBx.Location = new Point(827, 32);
            chBx.Margin = new Padding(1);
            chBx.Name = "chBx";
            chBx.Size = new Size(117, 19);
            chBx.TabIndex = 42;
            chBx.Text = "Empaque Central";
            chBx.UseVisualStyleBackColor = true;
            // 
            // cmBoxPrograma
            // 
            cmBoxPrograma.Font = new Font("Segoe UI", 12F);
            cmBoxPrograma.FormattingEnabled = true;
            cmBoxPrograma.Location = new Point(223, 104);
            cmBoxPrograma.Margin = new Padding(1);
            cmBoxPrograma.Name = "cmBoxPrograma";
            cmBoxPrograma.Size = new Size(183, 29);
            cmBoxPrograma.TabIndex = 44;
            cmBoxPrograma.SelectedIndexChanged += cmBoxPrograma_SelectedIndexChanged;
            // 
            // lblPrograma
            // 
            lblPrograma.AutoSize = true;
            lblPrograma.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblPrograma.Location = new Point(24, 99);
            lblPrograma.Margin = new Padding(1, 0, 1, 0);
            lblPrograma.Name = "lblPrograma";
            lblPrograma.Size = new Size(180, 25);
            lblPrograma.TabIndex = 43;
            lblPrograma.Text = "PLAN DE TRABAJO";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 14F);
            label10.Location = new Point(579, 63);
            label10.Margin = new Padding(1, 0, 1, 0);
            label10.Name = "label10";
            label10.Size = new Size(0, 25);
            label10.TabIndex = 45;
            // 
            // dTPWorkDay
            // 
            dTPWorkDay.CalendarFont = new Font("Segoe UI", 12F);
            dTPWorkDay.Location = new Point(560, 23);
            dTPWorkDay.Margin = new Padding(1);
            dTPWorkDay.Name = "dTPWorkDay";
            dTPWorkDay.Size = new Size(225, 23);
            dTPWorkDay.TabIndex = 47;
            dTPWorkDay.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // cmBxIdWorkPlan
            // 
            cmBxIdWorkPlan.Font = new Font("Segoe UI", 12F);
            cmBxIdWorkPlan.FormattingEnabled = true;
            cmBxIdWorkPlan.Location = new Point(428, 104);
            cmBxIdWorkPlan.Margin = new Padding(1);
            cmBxIdWorkPlan.Name = "cmBxIdWorkPlan";
            cmBxIdWorkPlan.Size = new Size(127, 29);
            cmBxIdWorkPlan.TabIndex = 48;
            cmBxIdWorkPlan.SelectedIndexChanged += cmBxIdWorkPlan_SelectedIndexChanged;
            // 
            // txbPaperWork
            // 
            txbPaperWork.Font = new Font("Segoe UI", 12F);
            txbPaperWork.Location = new Point(827, 147);
            txbPaperWork.Margin = new Padding(1);
            txbPaperWork.Name = "txbPaperWork";
            txbPaperWork.Size = new Size(126, 29);
            txbPaperWork.TabIndex = 49;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.Location = new Point(851, 124);
            label1.Margin = new Padding(1, 0, 1, 0);
            label1.Name = "label1";
            label1.Size = new Size(81, 25);
            label1.TabIndex = 50;
            label1.Text = "BOLETA";
            // 
            // chBxAlbertson
            // 
            chBxAlbertson.AutoSize = true;
            chBxAlbertson.Location = new Point(827, 57);
            chBxAlbertson.Margin = new Padding(1);
            chBxAlbertson.Name = "chBxAlbertson";
            chBxAlbertson.Size = new Size(85, 19);
            chBxAlbertson.TabIndex = 51;
            chBxAlbertson.Text = "Albertson's";
            chBxAlbertson.UseVisualStyleBackColor = true;
            // 
            // dgvLastUserPallet
            // 
            dgvLastUserPallet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvLastUserPallet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLastUserPallet.Location = new Point(750, 443);
            dgvLastUserPallet.Margin = new Padding(1);
            dgvLastUserPallet.Name = "dgvLastUserPallet";
            dgvLastUserPallet.RowHeadersWidth = 102;
            dgvLastUserPallet.RowTemplate.Height = 49;
            dgvLastUserPallet.Size = new Size(207, 143);
            dgvLastUserPallet.TabIndex = 52;
            dgvLastUserPallet.CellContentClick += dgvLastUserPallet_CellContentClick;
            // 
            // button5
            // 
            button5.Location = new Point(880, 597);
            button5.Margin = new Padding(1);
            button5.Name = "button5";
            button5.Size = new Size(77, 21);
            button5.TabIndex = 54;
            button5.Text = "RECIENTES";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // FrmEtiquetas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1022, 659);
            Controls.Add(button5);
            Controls.Add(dgvLastUserPallet);
            Controls.Add(chBxAlbertson);
            Controls.Add(label1);
            Controls.Add(txbPaperWork);
            Controls.Add(cmBxIdWorkPlan);
            Controls.Add(dTPWorkDay);
            Controls.Add(label10);
            Controls.Add(cmBoxPrograma);
            Controls.Add(lblPrograma);
            Controls.Add(chBx);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label8);
            Controls.Add(copiesPallet);
            Controls.Add(label7);
            Controls.Add(copiesPTI);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(lblTagContractorDetail);
            Controls.Add(lblTagContratista);
            Controls.Add(cmBoxWorkGroup);
            Controls.Add(lblTagWorkGroup);
            Controls.Add(lblTagHead);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(1);
            Name = "FrmEtiquetas";
            Text = "Etiquetas";
            Load += FrmEtiquetas_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)copiesPTI).EndInit();
            ((System.ComponentModel.ISupportInitialize)copiesPallet).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvLastUserPallet).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTagHead;
        private Label lblTagWorkGroup;
        private ComboBox cmBoxWorkGroup;
        private Label lblTagContratista;
        private Label lblTagContractorDetail;
        private Label lblTagLotCodeDetail;
        private Label lblTagLote;
        private Label lblTagVarietyDetail;
        private Label lblTagVariety;
        private Label lblTagLoteNameDetail;
        private Label lblFruitSize;
        private Label label2;
        private Label lblTagMicroDetails;
        private Label label4;
        private Label lblTagPresentacionDetail;
        private Label lblPlresentacion;
        private Label lblTagCajaDetail;
        private Label lblTagCaja;
        private Label lblTagMateriales;
        private Label lblTagCrop;
        private Label lblTagCliente;
        private Label lblTagClientDetail;
        private Label lblTagSO2;
        private Label lblTagWeightDetails;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label lblSleeve;
        private Label lblTagCinturonDetails;
        private Label lblTagLoteDetails;
        private Label lblTagLoteTag;
        private Label lblTagSO2Details;
        private Label label3;
        private Label lblTagLidsDetails;
        private Label lblTagLids;
        private Label lblTagFoamDetails;
        private Label lblTagFoam;
        private Label lblUPCDetails;
        private Label lblGtinDetails;
        private Label lblUPC;
        private Label lblGtin;
        private NumericUpDown copiesPTI;
        private Label label7;
        private Label label8;
        private NumericUpDown copiesPallet;
        private Button button1;
        private Button button2;
        private CheckBox chBx;
        private Label lblAdress2;
        private Label lblAdress1;
        private Label label9;
        private Label label5;
        private ComboBox cmBoxPrograma;
        private Label lblPrograma;
        private Label label10;
        private DateTimePicker dTPWorkDay;
        private TextBox txbTotalBox;
        private Label lblTagTotalBox;
        private Label lblTagTotalBoxDetails;
        private ComboBox cmBxIdWorkPlan;
        private Label lblTagPallet;
        private Label lblTagPalletDetails;
        private TextBox txbPaperWork;
        private Label label1;
        private CheckBox chBxAlbertson;
        private Label lblTagColor;
        private Label label11;
        private DataGridView dgvLastUserPallet;
        private Button button5;
    }
}