﻿namespace SisUvex.Archivo.Manifiesto
{
    partial class FrmManifestAdd
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmManifestAdd));
            btnPrintManifest = new Button();
            btnAccept = new Button();
            btnCancel = new Button();
            label1 = new Label();
            txbPhytosanitary = new TextBox();
            txbDieselLiters = new TextBox();
            lblDieselInvoice = new Label();
            txbDieselInvoice = new TextBox();
            txbPalletPosition = new TextBox();
            lblPosicionPal = new Label();
            dgvPalletList = new DataGridView();
            chbRejected = new CheckBox();
            txbNameOperator = new TextBox();
            label7 = new Label();
            txbNameShipper = new TextBox();
            Mercado = new Label();
            dtpDate = new DateTimePicker();
            lblObservaciones = new Label();
            txbObservations = new RichTextBox();
            btnRemovePallet = new Button();
            btnAddPallet = new Button();
            txbIdPallet = new TextBox();
            txbSeal3 = new TextBox();
            txbSeal2 = new TextBox();
            label14 = new Label();
            txbSeal1 = new TextBox();
            cboTemperatureUnit = new ComboBox();
            txbTemperature = new TextBox();
            label12 = new Label();
            label11 = new Label();
            txbTermograph = new TextBox();
            label10 = new Label();
            cboTransportType = new ComboBox();
            label9 = new Label();
            cboTransportVehicle = new ComboBox();
            btnSearchFreightContainer = new Button();
            btnSearchTruck = new Button();
            btnSearchDriver = new Button();
            txbIdFreightContainer = new TextBox();
            cboFreightContainer = new ComboBox();
            label5 = new Label();
            txbIdTruck = new TextBox();
            cboTruck = new ComboBox();
            label6 = new Label();
            txbIdDriver = new TextBox();
            cboDriver = new ComboBox();
            label8 = new Label();
            label4 = new Label();
            txbPurchaseOrder = new TextBox();
            lblVisa = new Label();
            txbBooking = new TextBox();
            spnHour = new MaskedTextBox();
            btnSearchDistributor = new Button();
            txbIdDistributor = new TextBox();
            cboDistributor = new ComboBox();
            label3 = new Label();
            btnSearchConsignee = new Button();
            txbIdConsignee = new TextBox();
            cboConsignee = new ComboBox();
            label16 = new Label();
            btnSearchCityDestination = new Button();
            btnSearchCityCrossPoint = new Button();
            btnSearchGrower = new Button();
            btnSearchAgencyMX = new Button();
            btnSearchAgencyUS = new Button();
            txbIdCityDestination = new TextBox();
            cboCityDestination = new ComboBox();
            lblCiudadDestino = new Label();
            txbIdCityCrossPoint = new TextBox();
            cboCityCrossPoint = new ComboBox();
            lblCiudadCruce = new Label();
            txbIdGrower = new TextBox();
            cboGrower = new ComboBox();
            lblProductor = new Label();
            txbIdAgencyUS = new TextBox();
            cboAgencyUS = new ComboBox();
            lblAgenciaUS = new Label();
            txbIdAgencyMX = new TextBox();
            cboAgencyMX = new ComboBox();
            lblAcenciaMX = new Label();
            label17 = new Label();
            label18 = new Label();
            cboMarket = new ComboBox();
            cboActive = new ComboBox();
            lblLinea = new Label();
            btnSearchTransportLine = new Button();
            txbIdTransportLine = new TextBox();
            cboTransportLine = new ComboBox();
            txbId = new TextBox();
            lblTitle = new Label();
            lblId = new Label();
            label15 = new Label();
            label19 = new Label();
            lblDieselLiters = new Label();
            label13 = new Label();
            btnConfManifest = new Button();
            cboSeason = new ComboBox();
            label2 = new Label();
            label20 = new Label();
            chbRemovedConsignee = new CheckBox();
            chbRemovedAgencyUS = new CheckBox();
            chbRemovedGrower = new CheckBox();
            chbRemovedCityCrossPoint = new CheckBox();
            chbRemovedAgencyMX = new CheckBox();
            chbRemovedCityDestination = new CheckBox();
            chbRemovedFreightContainer = new CheckBox();
            chbRemovedTruck = new CheckBox();
            chbRemovedDriver = new CheckBox();
            chbRemovedTransportLine = new CheckBox();
            chbRemovedDistributor = new CheckBox();
            txbTermoPosition = new TextBox();
            btnMovePalletDown = new Button();
            btnMovePalletUp = new Button();
            txbIdSeason = new TextBox();
            cboTemplate = new ComboBox();
            txbIdTemplate = new TextBox();
            label21 = new Label();
            txbIdMarket = new TextBox();
            chbPrintManifestPerField = new CheckBox();
            chbExcelLayout = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dgvPalletList).BeginInit();
            SuspendLayout();
            // 
            // btnPrintManifest
            // 
            btnPrintManifest.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnPrintManifest.Image = Properties.Resources.imprimirIcon16;
            btnPrintManifest.Location = new Point(638, 569);
            btnPrintManifest.Name = "btnPrintManifest";
            btnPrintManifest.Size = new Size(26, 25);
            btnPrintManifest.TabIndex = 350;
            btnPrintManifest.UseVisualStyleBackColor = true;
            btnPrintManifest.Click += btnPrintManifest_Click;
            // 
            // btnAccept
            // 
            btnAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAccept.Location = new Point(446, 569);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(64, 25);
            btnAccept.TabIndex = 254;
            btnAccept.Text = "Aceptar";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCancel.Location = new Point(512, 569);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(64, 25);
            btnCancel.TabIndex = 253;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 9F);
            label1.Location = new Point(41, 319);
            label1.Name = "label1";
            label1.Size = new Size(77, 15);
            label1.TabIndex = 357;
            label1.Text = "Fitosanitario:";
            label1.TextAlign = ContentAlignment.TopRight;
            // 
            // txbPhytosanitary
            // 
            txbPhytosanitary.Font = new Font("Microsoft Sans Serif", 9F);
            txbPhytosanitary.Location = new Point(115, 316);
            txbPhytosanitary.MaxLength = 30;
            txbPhytosanitary.Name = "txbPhytosanitary";
            txbPhytosanitary.Size = new Size(211, 21);
            txbPhytosanitary.TabIndex = 356;
            // 
            // txbDieselLiters
            // 
            txbDieselLiters.Font = new Font("Microsoft Sans Serif", 9F);
            txbDieselLiters.Location = new Point(327, 564);
            txbDieselLiters.MaxLength = 15;
            txbDieselLiters.Name = "txbDieselLiters";
            txbDieselLiters.Size = new Size(102, 21);
            txbDieselLiters.TabIndex = 353;
            txbDieselLiters.TextAlign = HorizontalAlignment.Center;
            txbDieselLiters.KeyPress += txbDieselLiters_KeyPress;
            // 
            // lblDieselInvoice
            // 
            lblDieselInvoice.AutoSize = true;
            lblDieselInvoice.Font = new Font("Microsoft Sans Serif", 9F);
            lblDieselInvoice.Location = new Point(45, 569);
            lblDieselInvoice.Name = "lblDieselInvoice";
            lblDieselInvoice.Size = new Size(73, 15);
            lblDieselInvoice.TabIndex = 352;
            lblDieselInvoice.Text = "Folio diesel:";
            lblDieselInvoice.TextAlign = ContentAlignment.TopRight;
            // 
            // txbDieselInvoice
            // 
            txbDieselInvoice.Font = new Font("Microsoft Sans Serif", 9F);
            txbDieselInvoice.Location = new Point(115, 564);
            txbDieselInvoice.MaxLength = 15;
            txbDieselInvoice.Name = "txbDieselInvoice";
            txbDieselInvoice.Size = new Size(102, 21);
            txbDieselInvoice.TabIndex = 351;
            txbDieselInvoice.TextAlign = HorizontalAlignment.Center;
            // 
            // txbPalletPosition
            // 
            txbPalletPosition.Font = new Font("Microsoft Sans Serif", 9F);
            txbPalletPosition.Location = new Point(496, 29);
            txbPalletPosition.MaxLength = 2;
            txbPalletPosition.Name = "txbPalletPosition";
            txbPalletPosition.Size = new Size(26, 21);
            txbPalletPosition.TabIndex = 349;
            txbPalletPosition.KeyPress += txbPalletPosition_KeyPress;
            // 
            // lblPosicionPal
            // 
            lblPosicionPal.AutoSize = true;
            lblPosicionPal.Font = new Font("Microsoft Sans Serif", 8.25F);
            lblPosicionPal.Location = new Point(494, 16);
            lblPosicionPal.Name = "lblPosicionPal";
            lblPosicionPal.Size = new Size(28, 13);
            lblPosicionPal.TabIndex = 348;
            lblPosicionPal.Text = "Pos:";
            // 
            // dgvPalletList
            // 
            dgvPalletList.AllowUserToAddRows = false;
            dgvPalletList.AllowUserToDeleteRows = false;
            dgvPalletList.AllowUserToOrderColumns = true;
            dgvPalletList.AllowUserToResizeRows = false;
            dgvPalletList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPalletList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            dgvPalletList.BackgroundColor = SystemColors.ControlLightLight;
            dgvPalletList.BorderStyle = BorderStyle.Fixed3D;
            dgvPalletList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvPalletList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvPalletList.EnableHeadersVisualStyles = false;
            dgvPalletList.ImeMode = ImeMode.NoControl;
            dgvPalletList.Location = new Point(446, 55);
            dgvPalletList.MultiSelect = false;
            dgvPalletList.Name = "dgvPalletList";
            dgvPalletList.ReadOnly = true;
            dgvPalletList.RightToLeft = RightToLeft.No;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvPalletList.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvPalletList.RowHeadersVisible = false;
            dgvPalletList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPalletList.Size = new Size(347, 508);
            dgvPalletList.TabIndex = 347;
            // 
            // chbRejected
            // 
            chbRejected.AutoSize = true;
            chbRejected.Font = new Font("Microsoft Sans Serif", 9F);
            chbRejected.Location = new Point(706, 30);
            chbRejected.Name = "chbRejected";
            chbRejected.Size = new Size(89, 19);
            chbRejected.TabIndex = 346;
            chbRejected.Text = "Rechazado";
            chbRejected.UseVisualStyleBackColor = true;
            // 
            // txbNameOperator
            // 
            txbNameOperator.Font = new Font("Microsoft Sans Serif", 9F);
            txbNameOperator.Location = new Point(327, 586);
            txbNameOperator.MaxLength = 20;
            txbNameOperator.Name = "txbNameOperator";
            txbNameOperator.Size = new Size(102, 21);
            txbNameOperator.TabIndex = 344;
            txbNameOperator.TextAlign = HorizontalAlignment.Center;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 9F);
            label7.Location = new Point(40, 589);
            label7.Name = "label7";
            label7.Size = new Size(78, 15);
            label7.TabIndex = 343;
            label7.Text = "Embarcador:";
            // 
            // txbNameShipper
            // 
            txbNameShipper.Font = new Font("Microsoft Sans Serif", 9F);
            txbNameShipper.Location = new Point(115, 586);
            txbNameShipper.MaxLength = 20;
            txbNameShipper.Name = "txbNameShipper";
            txbNameShipper.Size = new Size(102, 21);
            txbNameShipper.TabIndex = 342;
            txbNameShipper.TextAlign = HorizontalAlignment.Center;
            // 
            // Mercado
            // 
            Mercado.AutoSize = true;
            Mercado.Font = new Font("Microsoft Sans Serif", 9F);
            Mercado.Location = new Point(178, 32);
            Mercado.Name = "Mercado";
            Mercado.Size = new Size(41, 15);
            Mercado.TabIndex = 341;
            Mercado.Text = "Activo:";
            // 
            // dtpDate
            // 
            dtpDate.Font = new Font("Microsoft Sans Serif", 9F);
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.Location = new Point(304, 30);
            dtpDate.MaxDate = new DateTime(2050, 12, 31, 0, 0, 0, 0);
            dtpDate.MinDate = new DateTime(2000, 1, 1, 0, 0, 0, 0);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(84, 21);
            dtpDate.TabIndex = 340;
            // 
            // lblObservaciones
            // 
            lblObservaciones.AutoSize = true;
            lblObservaciones.Font = new Font("Microsoft Sans Serif", 9F);
            lblObservaciones.Location = new Point(27, 515);
            lblObservaciones.Name = "lblObservaciones";
            lblObservaciones.Size = new Size(91, 15);
            lblObservaciones.TabIndex = 339;
            lblObservaciones.Text = "Observaciones:";
            lblObservaciones.TextAlign = ContentAlignment.TopRight;
            // 
            // txbObservations
            // 
            txbObservations.BorderStyle = BorderStyle.FixedSingle;
            txbObservations.Font = new Font("Microsoft Sans Serif", 9F);
            txbObservations.Location = new Point(115, 515);
            txbObservations.MaxLength = 200;
            txbObservations.Name = "txbObservations";
            txbObservations.Size = new Size(314, 48);
            txbObservations.TabIndex = 338;
            txbObservations.Text = "";
            // 
            // btnRemovePallet
            // 
            btnRemovePallet.Font = new Font("Microsoft Sans Serif", 8.25F);
            btnRemovePallet.Image = Properties.Resources.basuraIcon16;
            btnRemovePallet.ImageAlign = ContentAlignment.MiddleRight;
            btnRemovePallet.Location = new Point(600, 28);
            btnRemovePallet.Name = "btnRemovePallet";
            btnRemovePallet.Size = new Size(23, 23);
            btnRemovePallet.TabIndex = 337;
            btnRemovePallet.TextAlign = ContentAlignment.TopCenter;
            btnRemovePallet.UseVisualStyleBackColor = true;
            btnRemovePallet.Click += btnRemovePallet_Click;
            // 
            // btnAddPallet
            // 
            btnAddPallet.Font = new Font("Microsoft Sans Serif", 9F);
            btnAddPallet.Image = Properties.Resources.mas_16;
            btnAddPallet.ImageAlign = ContentAlignment.BottomRight;
            btnAddPallet.Location = new Point(523, 28);
            btnAddPallet.Name = "btnAddPallet";
            btnAddPallet.Size = new Size(23, 23);
            btnAddPallet.TabIndex = 336;
            btnAddPallet.TextAlign = ContentAlignment.TopRight;
            btnAddPallet.UseVisualStyleBackColor = true;
            btnAddPallet.Click += btnAddPallet_Click;
            // 
            // txbIdPallet
            // 
            txbIdPallet.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdPallet.Location = new Point(448, 29);
            txbIdPallet.MaxLength = 5;
            txbIdPallet.Name = "txbIdPallet";
            txbIdPallet.Size = new Size(47, 21);
            txbIdPallet.TabIndex = 334;
            txbIdPallet.KeyPress += txbIdPallet_KeyPress;
            // 
            // txbSeal3
            // 
            txbSeal3.Font = new Font("Microsoft Sans Serif", 9F);
            txbSeal3.Location = new Point(327, 492);
            txbSeal3.MaxLength = 10;
            txbSeal3.Name = "txbSeal3";
            txbSeal3.Size = new Size(102, 21);
            txbSeal3.TabIndex = 333;
            txbSeal3.TextAlign = HorizontalAlignment.Center;
            // 
            // txbSeal2
            // 
            txbSeal2.Font = new Font("Microsoft Sans Serif", 9F);
            txbSeal2.Location = new Point(222, 492);
            txbSeal2.MaxLength = 10;
            txbSeal2.Name = "txbSeal2";
            txbSeal2.Size = new Size(102, 21);
            txbSeal2.TabIndex = 332;
            txbSeal2.TextAlign = HorizontalAlignment.Center;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Microsoft Sans Serif", 9F);
            label14.Location = new Point(74, 495);
            label14.Name = "label14";
            label14.Size = new Size(44, 15);
            label14.TabIndex = 331;
            label14.Text = "Sellos:";
            label14.TextAlign = ContentAlignment.TopRight;
            // 
            // txbSeal1
            // 
            txbSeal1.Font = new Font("Microsoft Sans Serif", 9F);
            txbSeal1.Location = new Point(115, 492);
            txbSeal1.MaxLength = 10;
            txbSeal1.Name = "txbSeal1";
            txbSeal1.Size = new Size(102, 21);
            txbSeal1.TabIndex = 330;
            txbSeal1.TextAlign = HorizontalAlignment.Center;
            // 
            // cboTemperatureUnit
            // 
            cboTemperatureUnit.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTemperatureUnit.Font = new Font("Microsoft Sans Serif", 9F);
            cboTemperatureUnit.FormattingEnabled = true;
            cboTemperatureUnit.Items.AddRange(new object[] { "F", "C", "K" });
            cboTemperatureUnit.Location = new Point(391, 469);
            cboTemperatureUnit.Name = "cboTemperatureUnit";
            cboTemperatureUnit.Size = new Size(33, 23);
            cboTemperatureUnit.TabIndex = 329;
            // 
            // txbTemperature
            // 
            txbTemperature.Font = new Font("Microsoft Sans Serif", 9F);
            txbTemperature.Location = new Point(358, 470);
            txbTemperature.MaxLength = 3;
            txbTemperature.Name = "txbTemperature";
            txbTemperature.Size = new Size(28, 21);
            txbTemperature.TabIndex = 327;
            txbTemperature.TextAlign = HorizontalAlignment.Center;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 9F);
            label12.Location = new Point(220, 473);
            label12.Name = "label12";
            label12.Size = new Size(57, 15);
            label12.TabIndex = 326;
            label12.Text = "Posición:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft Sans Serif", 9F);
            label11.Location = new Point(38, 473);
            label11.Name = "label11";
            label11.Size = new Size(80, 15);
            label11.TabIndex = 324;
            label11.Text = "Chismógrafo:";
            label11.TextAlign = ContentAlignment.TopRight;
            // 
            // txbTermograph
            // 
            txbTermograph.Font = new Font("Microsoft Sans Serif", 9F);
            txbTermograph.Location = new Point(115, 470);
            txbTermograph.MaxLength = 20;
            txbTermograph.Name = "txbTermograph";
            txbTermograph.Size = new Size(102, 21);
            txbTermograph.TabIndex = 323;
            txbTermograph.TextAlign = HorizontalAlignment.Center;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 9F);
            label10.Location = new Point(20, 450);
            label10.Name = "label10";
            label10.Size = new Size(98, 15);
            label10.TabIndex = 322;
            label10.Text = "Segundo medio:";
            label10.TextAlign = ContentAlignment.TopRight;
            // 
            // cboTransportType
            // 
            cboTransportType.Font = new Font("Microsoft Sans Serif", 8.25F);
            cboTransportType.FormattingEnabled = true;
            cboTransportType.Items.AddRange(new object[] { "", "TRAILER", "CAJA REFRIGERADA", "CONTENEDOR", "TRACTO CAMION", "CAMIONETA", "BARCO", "AVION", "TERRESTRE AEREO", "MARITIMO AEREO", "TERRESTRE MARITIMO" });
            cboTransportType.Location = new Point(115, 448);
            cboTransportType.Name = "cboTransportType";
            cboTransportType.Size = new Size(211, 21);
            cboTransportType.TabIndex = 321;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 9F);
            label9.Location = new Point(-2, 428);
            label9.Name = "label9";
            label9.Size = new Size(120, 15);
            label9.TabIndex = 320;
            label9.Text = "Medio de transporte:";
            label9.TextAlign = ContentAlignment.TopRight;
            // 
            // cboTransportVehicle
            // 
            cboTransportVehicle.Font = new Font("Microsoft Sans Serif", 8.25F);
            cboTransportVehicle.FormattingEnabled = true;
            cboTransportVehicle.Items.AddRange(new object[] { "", "TRAILER", "CONTENEDOR", "CAJA REFRIGERADA", "TRACTO CAMION", "CAMIONETA", "BARCO", "AVION", "TERRESTRE AEREO", "MARITIMO AEREO", "TERRESTRE MARITIMO" });
            cboTransportVehicle.Location = new Point(115, 426);
            cboTransportVehicle.Name = "cboTransportVehicle";
            cboTransportVehicle.Size = new Size(211, 21);
            cboTransportVehicle.TabIndex = 319;
            // 
            // btnSearchFreightContainer
            // 
            btnSearchFreightContainer.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnSearchFreightContainer.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearchFreightContainer.Font = new Font("Microsoft Sans Serif", 9F);
            btnSearchFreightContainer.Location = new Point(388, 403);
            btnSearchFreightContainer.Name = "btnSearchFreightContainer";
            btnSearchFreightContainer.Size = new Size(23, 23);
            btnSearchFreightContainer.TabIndex = 311;
            btnSearchFreightContainer.UseVisualStyleBackColor = true;
            btnSearchFreightContainer.Click += btnSearchFreightContainer_Click;
            // 
            // btnSearchTruck
            // 
            btnSearchTruck.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnSearchTruck.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearchTruck.Font = new Font("Microsoft Sans Serif", 9F);
            btnSearchTruck.Location = new Point(388, 381);
            btnSearchTruck.Name = "btnSearchTruck";
            btnSearchTruck.Size = new Size(23, 23);
            btnSearchTruck.TabIndex = 309;
            btnSearchTruck.UseVisualStyleBackColor = true;
            btnSearchTruck.Click += btnSearchTruck_Click;
            // 
            // btnSearchDriver
            // 
            btnSearchDriver.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnSearchDriver.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearchDriver.Font = new Font("Microsoft Sans Serif", 9F);
            btnSearchDriver.Location = new Point(388, 359);
            btnSearchDriver.Name = "btnSearchDriver";
            btnSearchDriver.Size = new Size(23, 23);
            btnSearchDriver.TabIndex = 307;
            btnSearchDriver.UseVisualStyleBackColor = true;
            btnSearchDriver.Click += btnSearchDriver_Click;
            // 
            // txbIdFreightContainer
            // 
            txbIdFreightContainer.Enabled = false;
            txbIdFreightContainer.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdFreightContainer.Location = new Point(115, 404);
            txbIdFreightContainer.Name = "txbIdFreightContainer";
            txbIdFreightContainer.Size = new Size(37, 21);
            txbIdFreightContainer.TabIndex = 318;
            txbIdFreightContainer.TextAlign = HorizontalAlignment.Center;
            // 
            // cboFreightContainer
            // 
            cboFreightContainer.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFreightContainer.Font = new Font("Microsoft Sans Serif", 8.25F);
            cboFreightContainer.FormattingEnabled = true;
            cboFreightContainer.ItemHeight = 13;
            cboFreightContainer.Location = new Point(153, 404);
            cboFreightContainer.Name = "cboFreightContainer";
            cboFreightContainer.Size = new Size(235, 21);
            cboFreightContainer.TabIndex = 306;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 9F);
            label5.Location = new Point(83, 407);
            label5.Name = "label5";
            label5.Size = new Size(35, 15);
            label5.TabIndex = 317;
            label5.Text = "Caja:";
            // 
            // txbIdTruck
            // 
            txbIdTruck.Enabled = false;
            txbIdTruck.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdTruck.Location = new Point(115, 382);
            txbIdTruck.Name = "txbIdTruck";
            txbIdTruck.Size = new Size(37, 21);
            txbIdTruck.TabIndex = 316;
            txbIdTruck.TextAlign = HorizontalAlignment.Center;
            // 
            // cboTruck
            // 
            cboTruck.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTruck.Font = new Font("Microsoft Sans Serif", 8.25F);
            cboTruck.FormattingEnabled = true;
            cboTruck.ItemHeight = 13;
            cboTruck.Location = new Point(153, 382);
            cboTruck.Name = "cboTruck";
            cboTruck.Size = new Size(235, 21);
            cboTruck.TabIndex = 305;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 9F);
            label6.Location = new Point(69, 385);
            label6.Name = "label6";
            label6.Size = new Size(49, 15);
            label6.TabIndex = 315;
            label6.Text = "Troque:";
            label6.TextAlign = ContentAlignment.TopRight;
            // 
            // txbIdDriver
            // 
            txbIdDriver.Enabled = false;
            txbIdDriver.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdDriver.Location = new Point(115, 360);
            txbIdDriver.Name = "txbIdDriver";
            txbIdDriver.Size = new Size(37, 21);
            txbIdDriver.TabIndex = 314;
            txbIdDriver.TextAlign = HorizontalAlignment.Center;
            // 
            // cboDriver
            // 
            cboDriver.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDriver.Font = new Font("Microsoft Sans Serif", 8.25F);
            cboDriver.FormattingEnabled = true;
            cboDriver.ItemHeight = 13;
            cboDriver.Location = new Point(153, 360);
            cboDriver.Name = "cboDriver";
            cboDriver.Size = new Size(235, 21);
            cboDriver.TabIndex = 304;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 9F);
            label8.Location = new Point(72, 362);
            label8.Name = "label8";
            label8.Size = new Size(46, 15);
            label8.TabIndex = 313;
            label8.Text = "Chofer:";
            label8.TextAlign = ContentAlignment.TopRight;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 9F);
            label4.Location = new Point(12, 297);
            label4.Name = "label4";
            label4.Size = new Size(106, 15);
            label4.TabIndex = 303;
            label4.Text = "Orden de compra:";
            label4.TextAlign = ContentAlignment.TopRight;
            // 
            // txbPurchaseOrder
            // 
            txbPurchaseOrder.Font = new Font("Microsoft Sans Serif", 9F);
            txbPurchaseOrder.Location = new Point(115, 294);
            txbPurchaseOrder.MaxLength = 30;
            txbPurchaseOrder.Name = "txbPurchaseOrder";
            txbPurchaseOrder.Size = new Size(211, 21);
            txbPurchaseOrder.TabIndex = 302;
            // 
            // lblVisa
            // 
            lblVisa.AutoSize = true;
            lblVisa.Font = new Font("Microsoft Sans Serif", 9F);
            lblVisa.Location = new Point(63, 275);
            lblVisa.Name = "lblVisa";
            lblVisa.Size = new Size(55, 15);
            lblVisa.TabIndex = 301;
            lblVisa.Text = "Booking:";
            lblVisa.TextAlign = ContentAlignment.TopRight;
            // 
            // txbBooking
            // 
            txbBooking.Font = new Font("Microsoft Sans Serif", 9F);
            txbBooking.Location = new Point(115, 272);
            txbBooking.MaxLength = 30;
            txbBooking.Name = "txbBooking";
            txbBooking.Size = new Size(211, 21);
            txbBooking.TabIndex = 300;
            // 
            // spnHour
            // 
            spnHour.Font = new Font("Microsoft Sans Serif", 9F);
            spnHour.Location = new Point(350, 52);
            spnHour.Mask = "00:00";
            spnHour.Name = "spnHour";
            spnHour.Size = new Size(38, 21);
            spnHour.TabIndex = 299;
            spnHour.ValidatingType = typeof(DateTime);
            // 
            // btnSearchDistributor
            // 
            btnSearchDistributor.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnSearchDistributor.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearchDistributor.Enabled = false;
            btnSearchDistributor.Font = new Font("Microsoft Sans Serif", 9F);
            btnSearchDistributor.Location = new Point(388, 117);
            btnSearchDistributor.Name = "btnSearchDistributor";
            btnSearchDistributor.Size = new Size(23, 23);
            btnSearchDistributor.TabIndex = 295;
            btnSearchDistributor.UseVisualStyleBackColor = true;
            // 
            // txbIdDistributor
            // 
            txbIdDistributor.Enabled = false;
            txbIdDistributor.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdDistributor.Location = new Point(115, 118);
            txbIdDistributor.Name = "txbIdDistributor";
            txbIdDistributor.Size = new Size(37, 21);
            txbIdDistributor.TabIndex = 298;
            txbIdDistributor.TextAlign = HorizontalAlignment.Center;
            // 
            // cboDistributor
            // 
            cboDistributor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDistributor.Font = new Font("Microsoft Sans Serif", 8.25F);
            cboDistributor.FormattingEnabled = true;
            cboDistributor.ItemHeight = 13;
            cboDistributor.Location = new Point(153, 118);
            cboDistributor.Name = "cboDistributor";
            cboDistributor.Size = new Size(235, 21);
            cboDistributor.TabIndex = 294;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 9F);
            label3.Location = new Point(45, 120);
            label3.Name = "label3";
            label3.Size = new Size(73, 15);
            label3.TabIndex = 297;
            label3.Text = "Distribuidor:";
            label3.TextAlign = ContentAlignment.TopRight;
            // 
            // btnSearchConsignee
            // 
            btnSearchConsignee.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnSearchConsignee.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearchConsignee.Enabled = false;
            btnSearchConsignee.Font = new Font("Microsoft Sans Serif", 9F);
            btnSearchConsignee.Location = new Point(388, 139);
            btnSearchConsignee.Name = "btnSearchConsignee";
            btnSearchConsignee.Size = new Size(23, 23);
            btnSearchConsignee.TabIndex = 290;
            btnSearchConsignee.UseVisualStyleBackColor = true;
            // 
            // txbIdConsignee
            // 
            txbIdConsignee.Enabled = false;
            txbIdConsignee.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdConsignee.Location = new Point(115, 140);
            txbIdConsignee.Name = "txbIdConsignee";
            txbIdConsignee.Size = new Size(37, 21);
            txbIdConsignee.TabIndex = 293;
            txbIdConsignee.TextAlign = HorizontalAlignment.Center;
            // 
            // cboConsignee
            // 
            cboConsignee.DropDownStyle = ComboBoxStyle.DropDownList;
            cboConsignee.Font = new Font("Microsoft Sans Serif", 8.25F);
            cboConsignee.FormattingEnabled = true;
            cboConsignee.ItemHeight = 13;
            cboConsignee.Location = new Point(153, 140);
            cboConsignee.Name = "cboConsignee";
            cboConsignee.Size = new Size(235, 21);
            cboConsignee.TabIndex = 289;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Microsoft Sans Serif", 9F);
            label16.Location = new Point(32, 142);
            label16.Name = "label16";
            label16.Size = new Size(86, 15);
            label16.TabIndex = 292;
            label16.Text = "Consignatario:";
            label16.TextAlign = ContentAlignment.TopRight;
            // 
            // btnSearchCityDestination
            // 
            btnSearchCityDestination.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnSearchCityDestination.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearchCityDestination.Enabled = false;
            btnSearchCityDestination.Font = new Font("Microsoft Sans Serif", 9F);
            btnSearchCityDestination.Location = new Point(388, 249);
            btnSearchCityDestination.Name = "btnSearchCityDestination";
            btnSearchCityDestination.Size = new Size(23, 23);
            btnSearchCityDestination.TabIndex = 277;
            btnSearchCityDestination.UseVisualStyleBackColor = true;
            // 
            // btnSearchCityCrossPoint
            // 
            btnSearchCityCrossPoint.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnSearchCityCrossPoint.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearchCityCrossPoint.Enabled = false;
            btnSearchCityCrossPoint.Font = new Font("Microsoft Sans Serif", 9F);
            btnSearchCityCrossPoint.Location = new Point(388, 227);
            btnSearchCityCrossPoint.Name = "btnSearchCityCrossPoint";
            btnSearchCityCrossPoint.Size = new Size(23, 23);
            btnSearchCityCrossPoint.TabIndex = 275;
            btnSearchCityCrossPoint.UseVisualStyleBackColor = true;
            // 
            // btnSearchGrower
            // 
            btnSearchGrower.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnSearchGrower.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearchGrower.Enabled = false;
            btnSearchGrower.Font = new Font("Microsoft Sans Serif", 9F);
            btnSearchGrower.Location = new Point(388, 161);
            btnSearchGrower.Name = "btnSearchGrower";
            btnSearchGrower.Size = new Size(23, 23);
            btnSearchGrower.TabIndex = 273;
            btnSearchGrower.UseVisualStyleBackColor = true;
            // 
            // btnSearchAgencyMX
            // 
            btnSearchAgencyMX.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnSearchAgencyMX.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearchAgencyMX.Enabled = false;
            btnSearchAgencyMX.Font = new Font("Microsoft Sans Serif", 9F);
            btnSearchAgencyMX.Location = new Point(388, 205);
            btnSearchAgencyMX.Name = "btnSearchAgencyMX";
            btnSearchAgencyMX.Size = new Size(23, 23);
            btnSearchAgencyMX.TabIndex = 270;
            btnSearchAgencyMX.UseVisualStyleBackColor = true;
            // 
            // btnSearchAgencyUS
            // 
            btnSearchAgencyUS.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnSearchAgencyUS.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearchAgencyUS.Enabled = false;
            btnSearchAgencyUS.Font = new Font("Microsoft Sans Serif", 9F);
            btnSearchAgencyUS.Location = new Point(388, 183);
            btnSearchAgencyUS.Name = "btnSearchAgencyUS";
            btnSearchAgencyUS.Size = new Size(23, 23);
            btnSearchAgencyUS.TabIndex = 269;
            btnSearchAgencyUS.UseVisualStyleBackColor = true;
            // 
            // txbIdCityDestination
            // 
            txbIdCityDestination.Enabled = false;
            txbIdCityDestination.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdCityDestination.Location = new Point(115, 250);
            txbIdCityDestination.Name = "txbIdCityDestination";
            txbIdCityDestination.Size = new Size(37, 21);
            txbIdCityDestination.TabIndex = 288;
            txbIdCityDestination.TextAlign = HorizontalAlignment.Center;
            // 
            // cboCityDestination
            // 
            cboCityDestination.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCityDestination.Font = new Font("Microsoft Sans Serif", 8.25F);
            cboCityDestination.FormattingEnabled = true;
            cboCityDestination.ItemHeight = 13;
            cboCityDestination.Location = new Point(153, 250);
            cboCityDestination.Name = "cboCityDestination";
            cboCityDestination.Size = new Size(235, 21);
            cboCityDestination.TabIndex = 268;
            // 
            // lblCiudadDestino
            // 
            lblCiudadDestino.AutoSize = true;
            lblCiudadDestino.Font = new Font("Microsoft Sans Serif", 9F);
            lblCiudadDestino.Location = new Point(26, 253);
            lblCiudadDestino.Name = "lblCiudadDestino";
            lblCiudadDestino.Size = new Size(92, 15);
            lblCiudadDestino.TabIndex = 287;
            lblCiudadDestino.Text = "Ciudad destino:";
            lblCiudadDestino.TextAlign = ContentAlignment.TopRight;
            // 
            // txbIdCityCrossPoint
            // 
            txbIdCityCrossPoint.Enabled = false;
            txbIdCityCrossPoint.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdCityCrossPoint.Location = new Point(115, 228);
            txbIdCityCrossPoint.Name = "txbIdCityCrossPoint";
            txbIdCityCrossPoint.Size = new Size(37, 21);
            txbIdCityCrossPoint.TabIndex = 286;
            txbIdCityCrossPoint.TextAlign = HorizontalAlignment.Center;
            // 
            // cboCityCrossPoint
            // 
            cboCityCrossPoint.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCityCrossPoint.Font = new Font("Microsoft Sans Serif", 8.25F);
            cboCityCrossPoint.FormattingEnabled = true;
            cboCityCrossPoint.ItemHeight = 13;
            cboCityCrossPoint.Location = new Point(153, 228);
            cboCityCrossPoint.Name = "cboCityCrossPoint";
            cboCityCrossPoint.Size = new Size(235, 21);
            cboCityCrossPoint.TabIndex = 267;
            // 
            // lblCiudadCruce
            // 
            lblCiudadCruce.AutoSize = true;
            lblCiudadCruce.Font = new Font("Microsoft Sans Serif", 9F);
            lblCiudadCruce.Location = new Point(36, 231);
            lblCiudadCruce.Name = "lblCiudadCruce";
            lblCiudadCruce.Size = new Size(82, 15);
            lblCiudadCruce.TabIndex = 285;
            lblCiudadCruce.Text = "Ciudad cruce:";
            lblCiudadCruce.TextAlign = ContentAlignment.TopRight;
            // 
            // txbIdGrower
            // 
            txbIdGrower.Enabled = false;
            txbIdGrower.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdGrower.Location = new Point(115, 162);
            txbIdGrower.Name = "txbIdGrower";
            txbIdGrower.Size = new Size(37, 21);
            txbIdGrower.TabIndex = 284;
            txbIdGrower.TextAlign = HorizontalAlignment.Center;
            // 
            // cboGrower
            // 
            cboGrower.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGrower.Font = new Font("Microsoft Sans Serif", 8.25F);
            cboGrower.FormattingEnabled = true;
            cboGrower.ItemHeight = 13;
            cboGrower.Location = new Point(153, 162);
            cboGrower.Name = "cboGrower";
            cboGrower.Size = new Size(235, 21);
            cboGrower.TabIndex = 266;
            // 
            // lblProductor
            // 
            lblProductor.AutoSize = true;
            lblProductor.Font = new Font("Microsoft Sans Serif", 9F);
            lblProductor.Location = new Point(55, 165);
            lblProductor.Name = "lblProductor";
            lblProductor.Size = new Size(63, 15);
            lblProductor.TabIndex = 283;
            lblProductor.Text = "Productor:";
            lblProductor.TextAlign = ContentAlignment.TopRight;
            // 
            // txbIdAgencyUS
            // 
            txbIdAgencyUS.Enabled = false;
            txbIdAgencyUS.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdAgencyUS.Location = new Point(115, 184);
            txbIdAgencyUS.Name = "txbIdAgencyUS";
            txbIdAgencyUS.Size = new Size(37, 21);
            txbIdAgencyUS.TabIndex = 282;
            txbIdAgencyUS.TextAlign = HorizontalAlignment.Center;
            // 
            // cboAgencyUS
            // 
            cboAgencyUS.DropDownStyle = ComboBoxStyle.DropDownList;
            cboAgencyUS.Font = new Font("Microsoft Sans Serif", 8.25F);
            cboAgencyUS.FormattingEnabled = true;
            cboAgencyUS.ItemHeight = 13;
            cboAgencyUS.Location = new Point(153, 184);
            cboAgencyUS.Name = "cboAgencyUS";
            cboAgencyUS.Size = new Size(235, 21);
            cboAgencyUS.TabIndex = 264;
            // 
            // lblAgenciaUS
            // 
            lblAgenciaUS.AutoSize = true;
            lblAgenciaUS.Font = new Font("Microsoft Sans Serif", 9F);
            lblAgenciaUS.Location = new Point(44, 187);
            lblAgenciaUS.Name = "lblAgenciaUS";
            lblAgenciaUS.Size = new Size(74, 15);
            lblAgenciaUS.TabIndex = 281;
            lblAgenciaUS.Text = "Agencia US:";
            lblAgenciaUS.TextAlign = ContentAlignment.TopRight;
            // 
            // txbIdAgencyMX
            // 
            txbIdAgencyMX.Enabled = false;
            txbIdAgencyMX.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdAgencyMX.Location = new Point(115, 206);
            txbIdAgencyMX.Name = "txbIdAgencyMX";
            txbIdAgencyMX.Size = new Size(37, 21);
            txbIdAgencyMX.TabIndex = 280;
            txbIdAgencyMX.TextAlign = HorizontalAlignment.Center;
            // 
            // cboAgencyMX
            // 
            cboAgencyMX.DropDownStyle = ComboBoxStyle.DropDownList;
            cboAgencyMX.Font = new Font("Microsoft Sans Serif", 8.25F);
            cboAgencyMX.FormattingEnabled = true;
            cboAgencyMX.ItemHeight = 13;
            cboAgencyMX.Location = new Point(153, 206);
            cboAgencyMX.Name = "cboAgencyMX";
            cboAgencyMX.Size = new Size(235, 21);
            cboAgencyMX.TabIndex = 265;
            // 
            // lblAcenciaMX
            // 
            lblAcenciaMX.AutoSize = true;
            lblAcenciaMX.Font = new Font("Microsoft Sans Serif", 9F);
            lblAcenciaMX.Location = new Point(42, 209);
            lblAcenciaMX.Name = "lblAcenciaMX";
            lblAcenciaMX.Size = new Size(76, 15);
            lblAcenciaMX.TabIndex = 279;
            lblAcenciaMX.Text = "Agencia MX:";
            lblAcenciaMX.TextAlign = ContentAlignment.TopRight;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Microsoft Sans Serif", 9F);
            label17.Location = new Point(263, 32);
            label17.Name = "label17";
            label17.Size = new Size(44, 15);
            label17.TabIndex = 263;
            label17.Text = "Fecha:";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Microsoft Sans Serif", 9F);
            label18.Location = new Point(317, 54);
            label18.Name = "label18";
            label18.Size = new Size(37, 15);
            label18.TabIndex = 262;
            label18.Text = "Hora:";
            // 
            // cboMarket
            // 
            cboMarket.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMarket.Font = new Font("Microsoft Sans Serif", 8.5F);
            cboMarket.FormattingEnabled = true;
            cboMarket.Location = new Point(153, 52);
            cboMarket.Name = "cboMarket";
            cboMarket.Size = new Size(137, 21);
            cboMarket.TabIndex = 261;
            // 
            // cboActive
            // 
            cboActive.DropDownStyle = ComboBoxStyle.DropDownList;
            cboActive.Font = new Font("Microsoft Sans Serif", 8.5F);
            cboActive.FormattingEnabled = true;
            cboActive.Items.AddRange(new object[] { "No", "Sí" });
            cboActive.Location = new Point(216, 30);
            cboActive.Name = "cboActive";
            cboActive.Size = new Size(37, 21);
            cboActive.TabIndex = 260;
            // 
            // lblLinea
            // 
            lblLinea.AutoSize = true;
            lblLinea.Font = new Font("Microsoft Sans Serif", 9F);
            lblLinea.Location = new Point(2, 340);
            lblLinea.Name = "lblLinea";
            lblLinea.Size = new Size(116, 15);
            lblLinea.TabIndex = 250;
            lblLinea.Text = "Línea de transporte:";
            lblLinea.TextAlign = ContentAlignment.TopRight;
            // 
            // btnSearchTransportLine
            // 
            btnSearchTransportLine.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnSearchTransportLine.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearchTransportLine.Font = new Font("Microsoft Sans Serif", 9F);
            btnSearchTransportLine.Location = new Point(388, 337);
            btnSearchTransportLine.Name = "btnSearchTransportLine";
            btnSearchTransportLine.Size = new Size(23, 23);
            btnSearchTransportLine.TabIndex = 257;
            btnSearchTransportLine.UseVisualStyleBackColor = true;
            btnSearchTransportLine.Click += btnSearchTransportLine_Click;
            // 
            // txbIdTransportLine
            // 
            txbIdTransportLine.Enabled = false;
            txbIdTransportLine.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdTransportLine.Location = new Point(115, 338);
            txbIdTransportLine.Name = "txbIdTransportLine";
            txbIdTransportLine.Size = new Size(37, 21);
            txbIdTransportLine.TabIndex = 259;
            txbIdTransportLine.TextAlign = HorizontalAlignment.Center;
            // 
            // cboTransportLine
            // 
            cboTransportLine.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTransportLine.Font = new Font("Microsoft Sans Serif", 8.25F);
            cboTransportLine.FormattingEnabled = true;
            cboTransportLine.ItemHeight = 13;
            cboTransportLine.Location = new Point(153, 338);
            cboTransportLine.Name = "cboTransportLine";
            cboTransportLine.Size = new Size(235, 21);
            cboTransportLine.TabIndex = 256;
            // 
            // txbId
            // 
            txbId.Enabled = false;
            txbId.Font = new Font("Arial", 9F, FontStyle.Bold);
            txbId.ForeColor = Color.SteelBlue;
            txbId.Location = new Point(115, 30);
            txbId.Name = "txbId";
            txbId.Size = new Size(50, 21);
            txbId.TabIndex = 251;
            txbId.TextAlign = HorizontalAlignment.Center;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial Black", 12F);
            lblTitle.Location = new Point(3, 2);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(164, 23);
            lblTitle.TabIndex = 249;
            lblTitle.Text = "Añadir Manifiesto";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Microsoft Sans Serif", 9F);
            lblId.Location = new Point(97, 34);
            lblId.Name = "lblId";
            lblId.Size = new Size(20, 15);
            lblId.TabIndex = 252;
            lblId.Text = "Id:";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Microsoft Sans Serif", 8.25F);
            label15.Location = new Point(446, 16);
            label15.Name = "label15";
            label15.Size = new Size(38, 13);
            label15.TabIndex = 335;
            label15.Text = "N. pal:";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Microsoft Sans Serif", 9F);
            label19.Location = new Point(268, 589);
            label19.Name = "label19";
            label19.Size = new Size(62, 15);
            label19.TabIndex = 345;
            label19.Text = "Operador:";
            // 
            // lblDieselLiters
            // 
            lblDieselLiters.AutoSize = true;
            lblDieselLiters.Font = new Font("Microsoft Sans Serif", 9F);
            lblDieselLiters.Location = new Point(254, 567);
            lblDieselLiters.Name = "lblDieselLiters";
            lblDieselLiters.Size = new Size(76, 15);
            lblDieselLiters.TabIndex = 354;
            lblDieselLiters.Text = "Litros diesel:";
            lblDieselLiters.TextAlign = ContentAlignment.TopRight;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Microsoft Sans Serif", 9F);
            label13.Location = new Point(309, 473);
            label13.Name = "label13";
            label13.Size = new Size(50, 15);
            label13.TabIndex = 328;
            label13.Text = "Grados:";
            // 
            // btnConfManifest
            // 
            btnConfManifest.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnConfManifest.Font = new Font("Microsoft Sans Serif", 9F);
            btnConfManifest.Image = (Image)resources.GetObject("btnConfManifest.Image");
            btnConfManifest.ImageAlign = ContentAlignment.BottomRight;
            btnConfManifest.Location = new Point(771, 2);
            btnConfManifest.Name = "btnConfManifest";
            btnConfManifest.Size = new Size(24, 24);
            btnConfManifest.TabIndex = 358;
            btnConfManifest.TextAlign = ContentAlignment.TopRight;
            btnConfManifest.UseVisualStyleBackColor = true;
            btnConfManifest.Click += btnConfManifest_Click;
            // 
            // cboSeason
            // 
            cboSeason.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSeason.Font = new Font("Microsoft Sans Serif", 8.25F);
            cboSeason.FormattingEnabled = true;
            cboSeason.Items.AddRange(new object[] { "E", "N" });
            cboSeason.Location = new Point(153, 74);
            cboSeason.Name = "cboSeason";
            cboSeason.Size = new Size(193, 21);
            cboSeason.TabIndex = 359;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 9F);
            label2.Location = new Point(44, 76);
            label2.Name = "label2";
            label2.Size = new Size(74, 15);
            label2.TabIndex = 360;
            label2.Text = "Temporada:";
            label2.TextAlign = ContentAlignment.TopRight;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Microsoft Sans Serif", 9F);
            label20.Location = new Point(59, 55);
            label20.Name = "label20";
            label20.Size = new Size(59, 15);
            label20.TabIndex = 361;
            label20.Text = "Mercado:";
            // 
            // chbRemovedConsignee
            // 
            chbRemovedConsignee.Appearance = Appearance.Button;
            chbRemovedConsignee.AutoSize = true;
            chbRemovedConsignee.Font = new Font("Segoe UI", 7.8F);
            chbRemovedConsignee.ForeColor = Color.DarkGray;
            chbRemovedConsignee.Image = Properties.Resources.removedList16;
            chbRemovedConsignee.Location = new Point(410, 139);
            chbRemovedConsignee.Name = "chbRemovedConsignee";
            chbRemovedConsignee.Size = new Size(23, 23);
            chbRemovedConsignee.TabIndex = 363;
            chbRemovedConsignee.Text = "  ";
            chbRemovedConsignee.UseVisualStyleBackColor = true;
            // 
            // chbRemovedAgencyUS
            // 
            chbRemovedAgencyUS.Appearance = Appearance.Button;
            chbRemovedAgencyUS.AutoSize = true;
            chbRemovedAgencyUS.Font = new Font("Segoe UI", 7.8F);
            chbRemovedAgencyUS.ForeColor = Color.DarkGray;
            chbRemovedAgencyUS.Image = Properties.Resources.removedList16;
            chbRemovedAgencyUS.Location = new Point(410, 183);
            chbRemovedAgencyUS.Name = "chbRemovedAgencyUS";
            chbRemovedAgencyUS.Size = new Size(23, 23);
            chbRemovedAgencyUS.TabIndex = 365;
            chbRemovedAgencyUS.Text = "  ";
            chbRemovedAgencyUS.UseVisualStyleBackColor = true;
            // 
            // chbRemovedGrower
            // 
            chbRemovedGrower.Appearance = Appearance.Button;
            chbRemovedGrower.AutoSize = true;
            chbRemovedGrower.Font = new Font("Segoe UI", 7.8F);
            chbRemovedGrower.ForeColor = Color.DarkGray;
            chbRemovedGrower.Image = Properties.Resources.removedList16;
            chbRemovedGrower.Location = new Point(410, 161);
            chbRemovedGrower.Name = "chbRemovedGrower";
            chbRemovedGrower.Size = new Size(23, 23);
            chbRemovedGrower.TabIndex = 364;
            chbRemovedGrower.Text = "  ";
            chbRemovedGrower.UseVisualStyleBackColor = true;
            // 
            // chbRemovedCityCrossPoint
            // 
            chbRemovedCityCrossPoint.Appearance = Appearance.Button;
            chbRemovedCityCrossPoint.AutoSize = true;
            chbRemovedCityCrossPoint.Font = new Font("Segoe UI", 7.8F);
            chbRemovedCityCrossPoint.ForeColor = Color.DarkGray;
            chbRemovedCityCrossPoint.Image = Properties.Resources.removedList16;
            chbRemovedCityCrossPoint.Location = new Point(410, 227);
            chbRemovedCityCrossPoint.Name = "chbRemovedCityCrossPoint";
            chbRemovedCityCrossPoint.Size = new Size(23, 23);
            chbRemovedCityCrossPoint.TabIndex = 367;
            chbRemovedCityCrossPoint.Text = "  ";
            chbRemovedCityCrossPoint.UseVisualStyleBackColor = true;
            // 
            // chbRemovedAgencyMX
            // 
            chbRemovedAgencyMX.Appearance = Appearance.Button;
            chbRemovedAgencyMX.AutoSize = true;
            chbRemovedAgencyMX.Font = new Font("Segoe UI", 7.8F);
            chbRemovedAgencyMX.ForeColor = Color.DarkGray;
            chbRemovedAgencyMX.Image = Properties.Resources.removedList16;
            chbRemovedAgencyMX.Location = new Point(410, 205);
            chbRemovedAgencyMX.Name = "chbRemovedAgencyMX";
            chbRemovedAgencyMX.Size = new Size(23, 23);
            chbRemovedAgencyMX.TabIndex = 366;
            chbRemovedAgencyMX.Text = "  ";
            chbRemovedAgencyMX.UseVisualStyleBackColor = true;
            // 
            // chbRemovedCityDestination
            // 
            chbRemovedCityDestination.Appearance = Appearance.Button;
            chbRemovedCityDestination.AutoSize = true;
            chbRemovedCityDestination.Font = new Font("Segoe UI", 7.8F);
            chbRemovedCityDestination.ForeColor = Color.DarkGray;
            chbRemovedCityDestination.Image = Properties.Resources.removedList16;
            chbRemovedCityDestination.Location = new Point(410, 249);
            chbRemovedCityDestination.Name = "chbRemovedCityDestination";
            chbRemovedCityDestination.Size = new Size(23, 23);
            chbRemovedCityDestination.TabIndex = 372;
            chbRemovedCityDestination.Text = "  ";
            chbRemovedCityDestination.UseVisualStyleBackColor = true;
            // 
            // chbRemovedFreightContainer
            // 
            chbRemovedFreightContainer.Appearance = Appearance.Button;
            chbRemovedFreightContainer.AutoSize = true;
            chbRemovedFreightContainer.Font = new Font("Segoe UI", 7.8F);
            chbRemovedFreightContainer.ForeColor = Color.DarkGray;
            chbRemovedFreightContainer.Image = Properties.Resources.removedList16;
            chbRemovedFreightContainer.Location = new Point(410, 403);
            chbRemovedFreightContainer.Name = "chbRemovedFreightContainer";
            chbRemovedFreightContainer.Size = new Size(23, 23);
            chbRemovedFreightContainer.TabIndex = 371;
            chbRemovedFreightContainer.Text = "  ";
            chbRemovedFreightContainer.UseVisualStyleBackColor = true;
            // 
            // chbRemovedTruck
            // 
            chbRemovedTruck.Appearance = Appearance.Button;
            chbRemovedTruck.AutoSize = true;
            chbRemovedTruck.Font = new Font("Segoe UI", 7.8F);
            chbRemovedTruck.ForeColor = Color.DarkGray;
            chbRemovedTruck.Image = Properties.Resources.removedList16;
            chbRemovedTruck.Location = new Point(410, 381);
            chbRemovedTruck.Name = "chbRemovedTruck";
            chbRemovedTruck.Size = new Size(23, 23);
            chbRemovedTruck.TabIndex = 370;
            chbRemovedTruck.Text = "  ";
            chbRemovedTruck.UseVisualStyleBackColor = true;
            // 
            // chbRemovedDriver
            // 
            chbRemovedDriver.Appearance = Appearance.Button;
            chbRemovedDriver.AutoSize = true;
            chbRemovedDriver.Font = new Font("Segoe UI", 7.8F);
            chbRemovedDriver.ForeColor = Color.DarkGray;
            chbRemovedDriver.Image = Properties.Resources.removedList16;
            chbRemovedDriver.Location = new Point(410, 359);
            chbRemovedDriver.Name = "chbRemovedDriver";
            chbRemovedDriver.Size = new Size(23, 23);
            chbRemovedDriver.TabIndex = 369;
            chbRemovedDriver.Text = "  ";
            chbRemovedDriver.UseVisualStyleBackColor = true;
            // 
            // chbRemovedTransportLine
            // 
            chbRemovedTransportLine.Appearance = Appearance.Button;
            chbRemovedTransportLine.AutoSize = true;
            chbRemovedTransportLine.Font = new Font("Segoe UI", 7.8F);
            chbRemovedTransportLine.ForeColor = Color.DarkGray;
            chbRemovedTransportLine.Image = Properties.Resources.removedList16;
            chbRemovedTransportLine.Location = new Point(410, 337);
            chbRemovedTransportLine.Name = "chbRemovedTransportLine";
            chbRemovedTransportLine.Size = new Size(23, 23);
            chbRemovedTransportLine.TabIndex = 368;
            chbRemovedTransportLine.Text = "  ";
            chbRemovedTransportLine.UseVisualStyleBackColor = true;
            // 
            // chbRemovedDistributor
            // 
            chbRemovedDistributor.Appearance = Appearance.Button;
            chbRemovedDistributor.AutoSize = true;
            chbRemovedDistributor.Font = new Font("Segoe UI", 7.8F);
            chbRemovedDistributor.ForeColor = Color.DarkGray;
            chbRemovedDistributor.Image = Properties.Resources.removedList16;
            chbRemovedDistributor.Location = new Point(410, 117);
            chbRemovedDistributor.Name = "chbRemovedDistributor";
            chbRemovedDistributor.Size = new Size(23, 23);
            chbRemovedDistributor.TabIndex = 373;
            chbRemovedDistributor.Text = "  ";
            chbRemovedDistributor.UseVisualStyleBackColor = true;
            // 
            // txbTermoPosition
            // 
            txbTermoPosition.Font = new Font("Microsoft Sans Serif", 9F);
            txbTermoPosition.Location = new Point(275, 470);
            txbTermoPosition.MaxLength = 2;
            txbTermoPosition.Name = "txbTermoPosition";
            txbTermoPosition.Size = new Size(32, 21);
            txbTermoPosition.TabIndex = 325;
            txbTermoPosition.TextAlign = HorizontalAlignment.Center;
            // 
            // btnMovePalletDown
            // 
            btnMovePalletDown.Font = new Font("Microsoft Sans Serif", 9F);
            btnMovePalletDown.Image = Properties.Resources.downIcon16;
            btnMovePalletDown.ImageAlign = ContentAlignment.TopLeft;
            btnMovePalletDown.Location = new Point(577, 28);
            btnMovePalletDown.Name = "btnMovePalletDown";
            btnMovePalletDown.Size = new Size(23, 23);
            btnMovePalletDown.TabIndex = 375;
            btnMovePalletDown.TextAlign = ContentAlignment.TopRight;
            btnMovePalletDown.UseVisualStyleBackColor = true;
            btnMovePalletDown.Click += btnMovePalletDown_Click;
            // 
            // btnMovePalletUp
            // 
            btnMovePalletUp.Font = new Font("Microsoft Sans Serif", 9F);
            btnMovePalletUp.Image = Properties.Resources.upIcon16;
            btnMovePalletUp.ImageAlign = ContentAlignment.TopLeft;
            btnMovePalletUp.Location = new Point(555, 28);
            btnMovePalletUp.Name = "btnMovePalletUp";
            btnMovePalletUp.Size = new Size(23, 23);
            btnMovePalletUp.TabIndex = 376;
            btnMovePalletUp.TextAlign = ContentAlignment.TopRight;
            btnMovePalletUp.UseVisualStyleBackColor = true;
            btnMovePalletUp.Click += btnMovePalletUp_Click;
            // 
            // txbIdSeason
            // 
            txbIdSeason.Enabled = false;
            txbIdSeason.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdSeason.Location = new Point(115, 74);
            txbIdSeason.Name = "txbIdSeason";
            txbIdSeason.Size = new Size(37, 21);
            txbIdSeason.TabIndex = 377;
            txbIdSeason.TextAlign = HorizontalAlignment.Center;
            // 
            // cboTemplate
            // 
            cboTemplate.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTemplate.Font = new Font("Microsoft Sans Serif", 8.25F);
            cboTemplate.FormattingEnabled = true;
            cboTemplate.ItemHeight = 13;
            cboTemplate.Location = new Point(153, 96);
            cboTemplate.Name = "cboTemplate";
            cboTemplate.Size = new Size(235, 21);
            cboTemplate.TabIndex = 378;
            // 
            // txbIdTemplate
            // 
            txbIdTemplate.Enabled = false;
            txbIdTemplate.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdTemplate.Location = new Point(115, 96);
            txbIdTemplate.Name = "txbIdTemplate";
            txbIdTemplate.Size = new Size(37, 21);
            txbIdTemplate.TabIndex = 379;
            txbIdTemplate.TextAlign = HorizontalAlignment.Center;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Microsoft Sans Serif", 9F);
            label21.Location = new Point(64, 97);
            label21.Name = "label21";
            label21.Size = new Size(54, 15);
            label21.TabIndex = 380;
            label21.Text = "Plantilla:";
            label21.TextAlign = ContentAlignment.TopRight;
            // 
            // txbIdMarket
            // 
            txbIdMarket.Enabled = false;
            txbIdMarket.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdMarket.Location = new Point(115, 52);
            txbIdMarket.Name = "txbIdMarket";
            txbIdMarket.Size = new Size(37, 21);
            txbIdMarket.TabIndex = 381;
            txbIdMarket.TextAlign = HorizontalAlignment.Center;
            txbIdMarket.TextChanged += txbIdMarket_TextChanged;
            // 
            // chbPrintManifestPerField
            // 
            chbPrintManifestPerField.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            chbPrintManifestPerField.AutoSize = true;
            chbPrintManifestPerField.Font = new Font("Microsoft Sans Serif", 9F);
            chbPrintManifestPerField.Location = new Point(670, 587);
            chbPrintManifestPerField.Name = "chbPrintManifestPerField";
            chbPrintManifestPerField.Size = new Size(116, 19);
            chbPrintManifestPerField.TabIndex = 382;
            chbPrintManifestPerField.Text = "Man. por campo";
            chbPrintManifestPerField.UseVisualStyleBackColor = true;
            // 
            // chbExcelLayout
            // 
            chbExcelLayout.AutoSize = true;
            chbExcelLayout.Font = new Font("Microsoft Sans Serif", 9F);
            chbExcelLayout.Location = new Point(670, 568);
            chbExcelLayout.Name = "chbExcelLayout";
            chbExcelLayout.Size = new Size(91, 19);
            chbExcelLayout.TabIndex = 386;
            chbExcelLayout.Text = "Excel layout";
            chbExcelLayout.UseVisualStyleBackColor = true;
            // 
            // FrmManifestAdd
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoScroll = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(797, 613);
            Controls.Add(chbExcelLayout);
            Controls.Add(chbPrintManifestPerField);
            Controls.Add(txbIdMarket);
            Controls.Add(txbIdTemplate);
            Controls.Add(cboTemplate);
            Controls.Add(txbIdSeason);
            Controls.Add(btnMovePalletUp);
            Controls.Add(btnMovePalletDown);
            Controls.Add(chbRemovedDistributor);
            Controls.Add(chbRemovedCityDestination);
            Controls.Add(chbRemovedFreightContainer);
            Controls.Add(chbRemovedTruck);
            Controls.Add(chbRemovedDriver);
            Controls.Add(chbRemovedTransportLine);
            Controls.Add(chbRemovedCityCrossPoint);
            Controls.Add(chbRemovedAgencyMX);
            Controls.Add(chbRemovedAgencyUS);
            Controls.Add(chbRemovedGrower);
            Controls.Add(chbRemovedConsignee);
            Controls.Add(cboSeason);
            Controls.Add(btnPrintManifest);
            Controls.Add(btnConfManifest);
            Controls.Add(btnAccept);
            Controls.Add(btnCancel);
            Controls.Add(txbPhytosanitary);
            Controls.Add(txbDieselLiters);
            Controls.Add(txbDieselInvoice);
            Controls.Add(txbPalletPosition);
            Controls.Add(lblPosicionPal);
            Controls.Add(txbTermoPosition);
            Controls.Add(dgvPalletList);
            Controls.Add(chbRejected);
            Controls.Add(txbNameOperator);
            Controls.Add(txbNameShipper);
            Controls.Add(txbObservations);
            Controls.Add(btnRemovePallet);
            Controls.Add(btnAddPallet);
            Controls.Add(txbIdPallet);
            Controls.Add(txbSeal3);
            Controls.Add(txbSeal2);
            Controls.Add(txbSeal1);
            Controls.Add(cboTemperatureUnit);
            Controls.Add(txbTemperature);
            Controls.Add(label12);
            Controls.Add(txbTermograph);
            Controls.Add(cboTransportType);
            Controls.Add(cboTransportVehicle);
            Controls.Add(btnSearchFreightContainer);
            Controls.Add(btnSearchTruck);
            Controls.Add(btnSearchDriver);
            Controls.Add(txbIdFreightContainer);
            Controls.Add(cboFreightContainer);
            Controls.Add(txbIdTruck);
            Controls.Add(cboTruck);
            Controls.Add(txbIdDriver);
            Controls.Add(cboDriver);
            Controls.Add(txbPurchaseOrder);
            Controls.Add(txbBooking);
            Controls.Add(spnHour);
            Controls.Add(btnSearchDistributor);
            Controls.Add(txbIdDistributor);
            Controls.Add(cboDistributor);
            Controls.Add(btnSearchConsignee);
            Controls.Add(txbIdConsignee);
            Controls.Add(cboConsignee);
            Controls.Add(btnSearchCityDestination);
            Controls.Add(btnSearchCityCrossPoint);
            Controls.Add(btnSearchGrower);
            Controls.Add(btnSearchAgencyMX);
            Controls.Add(btnSearchAgencyUS);
            Controls.Add(txbIdCityDestination);
            Controls.Add(cboCityDestination);
            Controls.Add(txbIdCityCrossPoint);
            Controls.Add(cboCityCrossPoint);
            Controls.Add(txbIdGrower);
            Controls.Add(cboGrower);
            Controls.Add(txbIdAgencyUS);
            Controls.Add(cboAgencyUS);
            Controls.Add(txbIdAgencyMX);
            Controls.Add(cboAgencyMX);
            Controls.Add(label18);
            Controls.Add(cboMarket);
            Controls.Add(cboActive);
            Controls.Add(btnSearchTransportLine);
            Controls.Add(txbIdTransportLine);
            Controls.Add(cboTransportLine);
            Controls.Add(txbId);
            Controls.Add(lblTitle);
            Controls.Add(label15);
            Controls.Add(label13);
            Controls.Add(lblId);
            Controls.Add(Mercado);
            Controls.Add(label1);
            Controls.Add(lblObservaciones);
            Controls.Add(label14);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label8);
            Controls.Add(label4);
            Controls.Add(lblVisa);
            Controls.Add(label3);
            Controls.Add(label16);
            Controls.Add(lblCiudadDestino);
            Controls.Add(lblCiudadCruce);
            Controls.Add(lblProductor);
            Controls.Add(lblAgenciaUS);
            Controls.Add(lblAcenciaMX);
            Controls.Add(lblLinea);
            Controls.Add(dtpDate);
            Controls.Add(label17);
            Controls.Add(label20);
            Controls.Add(label2);
            Controls.Add(lblDieselInvoice);
            Controls.Add(label7);
            Controls.Add(label19);
            Controls.Add(lblDieselLiters);
            Controls.Add(label21);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmManifestAdd";
            Text = "Añadir manifiesto";
            Load += FrmManifestAdd_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPalletList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnPrintManifest;
        private Button btnAccept;
        private Button btnCancel;
        private Label label1;
        public TextBox txbPhytosanitary;
        public TextBox txbDieselLiters;
        private Label lblDieselInvoice;
        public TextBox txbDieselInvoice;
        public TextBox txbPalletPosition;
        private Label lblPosicionPal;
        public DataGridView dgvPalletList;
        public CheckBox chbRejected;
        public TextBox txbNameOperator;
        private Label label7;
        public TextBox txbNameShipper;
        private Label Mercado;
        public DateTimePicker dtpDate;
        private Label lblObservaciones;
        public RichTextBox txbObservations;
        private Button btnRemovePallet;
        private Button btnAddPallet;
        public TextBox txbIdPallet;
        public TextBox txbSeal3;
        public TextBox txbSeal2;
        private Label label14;
        public TextBox txbSeal1;
        public ComboBox cboTemperatureUnit;
        public TextBox txbTemperature;
        private Label label12;
        private Label label11;
        public TextBox txbTermograph;
        private Label label10;
        public ComboBox cboTransportType;
        private Label label9;
        public ComboBox cboTransportVehicle;
        public TextBox txbIdFreightContainer;
        private Label label5;
        public TextBox txbIdTruck;
        private Label label6;
        public TextBox txbIdDriver;
        public ComboBox cboDriver;
        private Label label8;
        private Label label4;
        public TextBox txbPurchaseOrder;
        private Label lblVisa;
        public TextBox txbBooking;
        public MaskedTextBox spnHour;
        public TextBox txbIdDistributor;
        private Label label3;
        public TextBox txbIdConsignee;
        private Label label16;
        public TextBox txbIdCityDestination;
        private Label lblCiudadDestino;
        public TextBox txbIdCityCrossPoint;
        private Label lblCiudadCruce;
        public TextBox txbIdGrower;
        private Label lblProductor;
        public TextBox txbIdAgencyUS;
        public ComboBox cboAgencyUS;
        private Label lblAgenciaUS;
        public TextBox txbIdAgencyMX;
        public ComboBox cboAgencyMX;
        private Label lblAcenciaMX;
        private Label label17;
        private Label label18;
        public ComboBox cboMarket;
        public ComboBox cboActive;
        private Label lblLinea;
        public TextBox txbIdTransportLine;
        public TextBox txbId;
        public Label lblTitle;
        private Label lblId;
        private Label label15;
        private Label label19;
        private Label lblDieselLiters;
        private Label label13;
        private Button btnConfManifest;
        public ComboBox cboFreightContainer;
        public ComboBox cboTruck;
        public ComboBox cboDistributor;
        public ComboBox cboConsignee;
        public ComboBox cboCityDestination;
        public ComboBox cboCityCrossPoint;
        public ComboBox cboGrower;
        public ComboBox cboTransportLine;
        public ComboBox cboSeason;
        private Label label2;
        private Label label20;
        public Button btnSearchFreightContainer;
        public Button btnSearchTruck;
        public Button btnSearchDriver;
        public Button btnSearchDistributor;
        public Button btnSearchConsignee;
        public Button btnSearchCityDestination;
        public Button btnSearchCityCrossPoint;
        public Button btnSearchGrower;
        public Button btnSearchAgencyMX;
        public Button btnSearchAgencyUS;
        public Button btnSearchTransportLine;
        public CheckBox chbRemovedConsignee;
        public CheckBox chbRemovedAgencyUS;
        public CheckBox chbRemovedGrower;
        public CheckBox chbRemovedCityCrossPoint;
        public CheckBox chbRemovedAgencyMX;
        public CheckBox chbRemovedCityDestination;
        public CheckBox chbRemovedFreightContainer;
        public CheckBox chbRemovedTruck;
        public CheckBox chbRemovedDriver;
        public CheckBox chbRemovedTransportLine;
        public CheckBox chbRemovedDistributor;
        public TextBox txbTermoPosition;
        private Button btnMovePalletDown;
        private Button btnMovePalletUp;
        public TextBox txbIdSeason;
        public ComboBox cboTemplate;
        public TextBox txbIdTemplate;
        private Label label21;
        public TextBox txbIdMarket;
        public CheckBox chbPrintManifestPerField;
        public CheckBox chbExcelLayout;
    }
}