namespace SisUvex.Archivo.Manifiesto.ManifestTemplates
{
    partial class FrmManifestTemplatesAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmManifestTemplatesAdd));
            btnAccept = new Button();
            btnCancel = new Button();
            txbDescription = new RichTextBox();
            txbName = new TextBox();
            lblTitle = new Label();
            chbRemovedDistributor = new CheckBox();
            chbRemovedCityDestination = new CheckBox();
            chbRemovedCityCrossPoint = new CheckBox();
            chbRemovedAgencyMX = new CheckBox();
            chbRemovedAgencyUS = new CheckBox();
            chbRemovedGrower = new CheckBox();
            chbRemovedConsignee = new CheckBox();
            cboDistributor = new ComboBox();
            cboConsignee = new ComboBox();
            cboCityDestination = new ComboBox();
            cboCityCrossPoint = new ComboBox();
            cboGrower = new ComboBox();
            cboAgencyUS = new ComboBox();
            cboAgencyMX = new ComboBox();
            label3 = new Label();
            label16 = new Label();
            lblCiudadDestino = new Label();
            lblCiudadCruce = new Label();
            lblProductor = new Label();
            lblAgenciaUS = new Label();
            lblAcenciaMX = new Label();
            label2 = new Label();
            label1 = new Label();
            txbId = new TextBox();
            label4 = new Label();
            cboActive = new ComboBox();
            label5 = new Label();
            lblActivo = new Label();
            cboCrop = new ComboBox();
            label6 = new Label();
            tglPrintPackingList = new SisUvex.Cuadro_de_herramientas.ToggleButton();
            label7 = new Label();
            tglExcelLayout = new SisUvex.Cuadro_de_herramientas.ToggleButton();
            tglMapping = new SisUvex.Cuadro_de_herramientas.ToggleButton();
            label8 = new Label();
            label9 = new Label();
            btnManifestPerFarm = new SisUvex.Cuadro_de_herramientas.ToggleButton();
            label10 = new Label();
            tglManifest = new SisUvex.Cuadro_de_herramientas.ToggleButton();
            label11 = new Label();
            tglShowSize = new SisUvex.Cuadro_de_herramientas.ToggleButton();
            label12 = new Label();
            label13 = new Label();
            SuspendLayout();
            // 
            // btnAccept
            // 
            btnAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAccept.Location = new Point(297, 512);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(64, 25);
            btnAccept.TabIndex = 457;
            btnAccept.Text = "Aceptar";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCancel.Location = new Point(363, 512);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(64, 25);
            btnCancel.TabIndex = 456;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // txbDescription
            // 
            txbDescription.Font = new Font("Microsoft Sans Serif", 9F);
            txbDescription.Location = new Point(99, 109);
            txbDescription.MaxLength = 200;
            txbDescription.Name = "txbDescription";
            txbDescription.Size = new Size(328, 96);
            txbDescription.TabIndex = 453;
            txbDescription.Text = "";
            // 
            // txbName
            // 
            txbName.Font = new Font("Microsoft Sans Serif", 9F);
            txbName.Location = new Point(99, 86);
            txbName.MaxLength = 50;
            txbName.Name = "txbName";
            txbName.Size = new Size(328, 21);
            txbName.TabIndex = 452;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial Black", 12F);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(268, 23);
            lblTitle.TabIndex = 451;
            lblTitle.Text = "Añadir plantilla de manifiesto";
            // 
            // chbRemovedDistributor
            // 
            chbRemovedDistributor.Appearance = Appearance.Button;
            chbRemovedDistributor.AutoSize = true;
            chbRemovedDistributor.Font = new Font("Segoe UI", 7.8F);
            chbRemovedDistributor.ForeColor = Color.DarkGray;
            chbRemovedDistributor.Image = Properties.Resources.removedList16;
            chbRemovedDistributor.Location = new Point(362, 213);
            chbRemovedDistributor.Name = "chbRemovedDistributor";
            chbRemovedDistributor.Size = new Size(23, 23);
            chbRemovedDistributor.TabIndex = 450;
            chbRemovedDistributor.Text = "  ";
            chbRemovedDistributor.UseVisualStyleBackColor = true;
            // 
            // chbRemovedCityDestination
            // 
            chbRemovedCityDestination.Appearance = Appearance.Button;
            chbRemovedCityDestination.AutoSize = true;
            chbRemovedCityDestination.Font = new Font("Segoe UI", 7.8F);
            chbRemovedCityDestination.ForeColor = Color.DarkGray;
            chbRemovedCityDestination.Image = Properties.Resources.removedList16;
            chbRemovedCityDestination.Location = new Point(362, 363);
            chbRemovedCityDestination.Name = "chbRemovedCityDestination";
            chbRemovedCityDestination.Size = new Size(23, 23);
            chbRemovedCityDestination.TabIndex = 449;
            chbRemovedCityDestination.Text = "  ";
            chbRemovedCityDestination.UseVisualStyleBackColor = true;
            // 
            // chbRemovedCityCrossPoint
            // 
            chbRemovedCityCrossPoint.Appearance = Appearance.Button;
            chbRemovedCityCrossPoint.AutoSize = true;
            chbRemovedCityCrossPoint.Font = new Font("Segoe UI", 7.8F);
            chbRemovedCityCrossPoint.ForeColor = Color.DarkGray;
            chbRemovedCityCrossPoint.Image = Properties.Resources.removedList16;
            chbRemovedCityCrossPoint.Location = new Point(362, 338);
            chbRemovedCityCrossPoint.Name = "chbRemovedCityCrossPoint";
            chbRemovedCityCrossPoint.Size = new Size(23, 23);
            chbRemovedCityCrossPoint.TabIndex = 448;
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
            chbRemovedAgencyMX.Location = new Point(362, 313);
            chbRemovedAgencyMX.Name = "chbRemovedAgencyMX";
            chbRemovedAgencyMX.Size = new Size(23, 23);
            chbRemovedAgencyMX.TabIndex = 447;
            chbRemovedAgencyMX.Text = "  ";
            chbRemovedAgencyMX.UseVisualStyleBackColor = true;
            // 
            // chbRemovedAgencyUS
            // 
            chbRemovedAgencyUS.Appearance = Appearance.Button;
            chbRemovedAgencyUS.AutoSize = true;
            chbRemovedAgencyUS.Font = new Font("Segoe UI", 7.8F);
            chbRemovedAgencyUS.ForeColor = Color.DarkGray;
            chbRemovedAgencyUS.Image = Properties.Resources.removedList16;
            chbRemovedAgencyUS.Location = new Point(362, 288);
            chbRemovedAgencyUS.Name = "chbRemovedAgencyUS";
            chbRemovedAgencyUS.Size = new Size(23, 23);
            chbRemovedAgencyUS.TabIndex = 446;
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
            chbRemovedGrower.Location = new Point(362, 263);
            chbRemovedGrower.Name = "chbRemovedGrower";
            chbRemovedGrower.Size = new Size(23, 23);
            chbRemovedGrower.TabIndex = 445;
            chbRemovedGrower.Text = "  ";
            chbRemovedGrower.UseVisualStyleBackColor = true;
            // 
            // chbRemovedConsignee
            // 
            chbRemovedConsignee.Appearance = Appearance.Button;
            chbRemovedConsignee.AutoSize = true;
            chbRemovedConsignee.Font = new Font("Segoe UI", 7.8F);
            chbRemovedConsignee.ForeColor = Color.DarkGray;
            chbRemovedConsignee.Image = Properties.Resources.removedList16;
            chbRemovedConsignee.Location = new Point(362, 238);
            chbRemovedConsignee.Name = "chbRemovedConsignee";
            chbRemovedConsignee.Size = new Size(23, 23);
            chbRemovedConsignee.TabIndex = 444;
            chbRemovedConsignee.Text = "  ";
            chbRemovedConsignee.UseVisualStyleBackColor = true;
            // 
            // cboDistributor
            // 
            cboDistributor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDistributor.Font = new Font("Microsoft Sans Serif", 8.25F);
            cboDistributor.FormattingEnabled = true;
            cboDistributor.ItemHeight = 13;
            cboDistributor.Location = new Point(99, 213);
            cboDistributor.Name = "cboDistributor";
            cboDistributor.Size = new Size(260, 21);
            cboDistributor.TabIndex = 440;
            // 
            // cboConsignee
            // 
            cboConsignee.DropDownStyle = ComboBoxStyle.DropDownList;
            cboConsignee.Font = new Font("Microsoft Sans Serif", 8.25F);
            cboConsignee.FormattingEnabled = true;
            cboConsignee.ItemHeight = 13;
            cboConsignee.Location = new Point(99, 238);
            cboConsignee.Name = "cboConsignee";
            cboConsignee.Size = new Size(260, 21);
            cboConsignee.TabIndex = 436;
            // 
            // cboCityDestination
            // 
            cboCityDestination.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCityDestination.Font = new Font("Microsoft Sans Serif", 8.25F);
            cboCityDestination.FormattingEnabled = true;
            cboCityDestination.ItemHeight = 13;
            cboCityDestination.Location = new Point(99, 363);
            cboCityDestination.Name = "cboCityDestination";
            cboCityDestination.Size = new Size(260, 21);
            cboCityDestination.TabIndex = 420;
            // 
            // cboCityCrossPoint
            // 
            cboCityCrossPoint.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCityCrossPoint.Font = new Font("Microsoft Sans Serif", 8.25F);
            cboCityCrossPoint.FormattingEnabled = true;
            cboCityCrossPoint.ItemHeight = 13;
            cboCityCrossPoint.Location = new Point(99, 338);
            cboCityCrossPoint.Name = "cboCityCrossPoint";
            cboCityCrossPoint.Size = new Size(260, 21);
            cboCityCrossPoint.TabIndex = 419;
            // 
            // cboGrower
            // 
            cboGrower.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGrower.Font = new Font("Microsoft Sans Serif", 8.25F);
            cboGrower.FormattingEnabled = true;
            cboGrower.ItemHeight = 13;
            cboGrower.Location = new Point(99, 263);
            cboGrower.Name = "cboGrower";
            cboGrower.Size = new Size(260, 21);
            cboGrower.TabIndex = 418;
            // 
            // cboAgencyUS
            // 
            cboAgencyUS.DropDownStyle = ComboBoxStyle.DropDownList;
            cboAgencyUS.Font = new Font("Microsoft Sans Serif", 8.25F);
            cboAgencyUS.FormattingEnabled = true;
            cboAgencyUS.ItemHeight = 13;
            cboAgencyUS.Location = new Point(99, 288);
            cboAgencyUS.Name = "cboAgencyUS";
            cboAgencyUS.Size = new Size(260, 21);
            cboAgencyUS.TabIndex = 416;
            // 
            // cboAgencyMX
            // 
            cboAgencyMX.DropDownStyle = ComboBoxStyle.DropDownList;
            cboAgencyMX.Font = new Font("Microsoft Sans Serif", 8.25F);
            cboAgencyMX.FormattingEnabled = true;
            cboAgencyMX.ItemHeight = 13;
            cboAgencyMX.Location = new Point(99, 313);
            cboAgencyMX.Name = "cboAgencyMX";
            cboAgencyMX.Size = new Size(260, 21);
            cboAgencyMX.TabIndex = 417;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 9F);
            label3.Location = new Point(29, 214);
            label3.Name = "label3";
            label3.Size = new Size(73, 15);
            label3.TabIndex = 442;
            label3.Text = "Distribuidor:";
            label3.TextAlign = ContentAlignment.TopRight;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Microsoft Sans Serif", 9F);
            label16.Location = new Point(16, 239);
            label16.Name = "label16";
            label16.Size = new Size(86, 15);
            label16.TabIndex = 438;
            label16.Text = "Consignatario:";
            label16.TextAlign = ContentAlignment.TopRight;
            // 
            // lblCiudadDestino
            // 
            lblCiudadDestino.AutoSize = true;
            lblCiudadDestino.Font = new Font("Microsoft Sans Serif", 9F);
            lblCiudadDestino.Location = new Point(10, 365);
            lblCiudadDestino.Name = "lblCiudadDestino";
            lblCiudadDestino.Size = new Size(92, 15);
            lblCiudadDestino.TabIndex = 434;
            lblCiudadDestino.Text = "Ciudad destino:";
            lblCiudadDestino.TextAlign = ContentAlignment.TopRight;
            // 
            // lblCiudadCruce
            // 
            lblCiudadCruce.AutoSize = true;
            lblCiudadCruce.Font = new Font("Microsoft Sans Serif", 9F);
            lblCiudadCruce.Location = new Point(20, 340);
            lblCiudadCruce.Name = "lblCiudadCruce";
            lblCiudadCruce.Size = new Size(82, 15);
            lblCiudadCruce.TabIndex = 432;
            lblCiudadCruce.Text = "Ciudad cruce:";
            lblCiudadCruce.TextAlign = ContentAlignment.TopRight;
            // 
            // lblProductor
            // 
            lblProductor.AutoSize = true;
            lblProductor.Font = new Font("Microsoft Sans Serif", 9F);
            lblProductor.Location = new Point(39, 265);
            lblProductor.Name = "lblProductor";
            lblProductor.Size = new Size(63, 15);
            lblProductor.TabIndex = 430;
            lblProductor.Text = "Productor:";
            lblProductor.TextAlign = ContentAlignment.TopRight;
            // 
            // lblAgenciaUS
            // 
            lblAgenciaUS.AutoSize = true;
            lblAgenciaUS.Font = new Font("Microsoft Sans Serif", 9F);
            lblAgenciaUS.Location = new Point(28, 290);
            lblAgenciaUS.Name = "lblAgenciaUS";
            lblAgenciaUS.Size = new Size(74, 15);
            lblAgenciaUS.TabIndex = 428;
            lblAgenciaUS.Text = "Agencia US:";
            lblAgenciaUS.TextAlign = ContentAlignment.TopRight;
            // 
            // lblAcenciaMX
            // 
            lblAcenciaMX.AutoSize = true;
            lblAcenciaMX.Font = new Font("Microsoft Sans Serif", 9F);
            lblAcenciaMX.Location = new Point(26, 315);
            lblAcenciaMX.Name = "lblAcenciaMX";
            lblAcenciaMX.Size = new Size(76, 15);
            lblAcenciaMX.TabIndex = 426;
            lblAcenciaMX.Text = "Agencia MX:";
            lblAcenciaMX.TextAlign = ContentAlignment.TopRight;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 9F);
            label2.Location = new Point(26, 109);
            label2.Name = "label2";
            label2.Size = new Size(75, 15);
            label2.TabIndex = 455;
            label2.Text = "Descripción:";
            label2.TextAlign = ContentAlignment.TopRight;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 9F);
            label1.Location = new Point(46, 89);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 454;
            label1.Text = "Nombre:";
            label1.TextAlign = ContentAlignment.TopRight;
            // 
            // txbId
            // 
            txbId.Enabled = false;
            txbId.Font = new Font("Microsoft Sans Serif", 9F);
            txbId.Location = new Point(99, 32);
            txbId.MaxLength = 10;
            txbId.Name = "txbId";
            txbId.Size = new Size(37, 21);
            txbId.TabIndex = 458;
            txbId.TextAlign = HorizontalAlignment.Center;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 9F);
            label4.Location = new Point(81, 35);
            label4.Name = "label4";
            label4.Size = new Size(20, 15);
            label4.TabIndex = 459;
            label4.Text = "Id:";
            label4.TextAlign = ContentAlignment.TopRight;
            // 
            // cboActive
            // 
            cboActive.DropDownStyle = ComboBoxStyle.DropDownList;
            cboActive.Font = new Font("Microsoft Sans Serif", 9F);
            cboActive.FormattingEnabled = true;
            cboActive.Items.AddRange(new object[] { "No", "Sí" });
            cboActive.Location = new Point(180, 31);
            cboActive.Name = "cboActive";
            cboActive.Size = new Size(46, 23);
            cboActive.TabIndex = 460;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 9F);
            label5.ForeColor = Color.Crimson;
            label5.Location = new Point(171, 27);
            label5.Name = "label5";
            label5.Size = new Size(12, 15);
            label5.TabIndex = 462;
            label5.Text = "*";
            // 
            // lblActivo
            // 
            lblActivo.AutoSize = true;
            lblActivo.Font = new Font("Microsoft Sans Serif", 9F);
            lblActivo.Location = new Point(139, 35);
            lblActivo.Name = "lblActivo";
            lblActivo.Size = new Size(44, 15);
            lblActivo.TabIndex = 461;
            lblActivo.Text = "Activo: ";
            // 
            // cboCrop
            // 
            cboCrop.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCrop.Font = new Font("Microsoft Sans Serif", 8.25F);
            cboCrop.FormattingEnabled = true;
            cboCrop.ItemHeight = 13;
            cboCrop.Location = new Point(99, 59);
            cboCrop.Name = "cboCrop";
            cboCrop.Size = new Size(260, 21);
            cboCrop.TabIndex = 463;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 9F);
            label6.Location = new Point(56, 60);
            label6.Name = "label6";
            label6.Size = new Size(46, 15);
            label6.TabIndex = 465;
            label6.Text = "Cultivo:";
            label6.TextAlign = ContentAlignment.TopRight;
            // 
            // tglPrintPackingList
            // 
            tglPrintPackingList.AnimationSpeed = 4;
            tglPrintPackingList.Appearance = Appearance.Button;
            tglPrintPackingList.BackColor = Color.Transparent;
            tglPrintPackingList.BorderColor = Color.Empty;
            tglPrintPackingList.FocusBackColor = Color.FromArgb(202, 167, 243);
            tglPrintPackingList.FocusBorderColor = Color.FromArgb(92, 53, 142);
            tglPrintPackingList.Font = new Font("Microsoft Sans Serif", 9F);
            tglPrintPackingList.Location = new Point(101, 519);
            tglPrintPackingList.Margin = new Padding(1);
            tglPrintPackingList.MinimumSize = new Size(20, 10);
            tglPrintPackingList.Name = "tglPrintPackingList";
            tglPrintPackingList.OffBackColor = Color.LightGray;
            tglPrintPackingList.OnBackColor = Color.FromArgb(92, 53, 142);
            tglPrintPackingList.Size = new Size(30, 18);
            tglPrintPackingList.TabIndex = 477;
            tglPrintPackingList.Text = "toggleButton6";
            tglPrintPackingList.ThumbInset = 1;
            tglPrintPackingList.ToggleColor = Color.White;
            tglPrintPackingList.ToggleShape = Cuadro_de_herramientas.ToggleButtonShape.RoundedRectangle;
            tglPrintPackingList.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 9F);
            label7.Location = new Point(132, 519);
            label7.Name = "label7";
            label7.Size = new Size(73, 15);
            label7.TabIndex = 476;
            label7.Text = "Packing List";
            // 
            // tglExcelLayout
            // 
            tglExcelLayout.AnimationSpeed = 4;
            tglExcelLayout.Appearance = Appearance.Button;
            tglExcelLayout.BackColor = Color.Transparent;
            tglExcelLayout.BorderColor = Color.Empty;
            tglExcelLayout.FocusBackColor = Color.FromArgb(202, 167, 243);
            tglExcelLayout.FocusBorderColor = Color.FromArgb(92, 53, 142);
            tglExcelLayout.Font = new Font("Microsoft Sans Serif", 9F);
            tglExcelLayout.Location = new Point(101, 497);
            tglExcelLayout.Margin = new Padding(1);
            tglExcelLayout.MinimumSize = new Size(20, 10);
            tglExcelLayout.Name = "tglExcelLayout";
            tglExcelLayout.OffBackColor = Color.LightGray;
            tglExcelLayout.OnBackColor = Color.FromArgb(92, 53, 142);
            tglExcelLayout.Size = new Size(30, 18);
            tglExcelLayout.TabIndex = 475;
            tglExcelLayout.Text = "toggleButton4";
            tglExcelLayout.ThumbInset = 1;
            tglExcelLayout.ToggleColor = Color.White;
            tglExcelLayout.ToggleShape = Cuadro_de_herramientas.ToggleButtonShape.RoundedRectangle;
            tglExcelLayout.UseVisualStyleBackColor = false;
            // 
            // tglMapping
            // 
            tglMapping.AnimationSpeed = 4;
            tglMapping.Appearance = Appearance.Button;
            tglMapping.BackColor = Color.Transparent;
            tglMapping.BorderColor = Color.Empty;
            tglMapping.FocusBackColor = Color.FromArgb(202, 167, 243);
            tglMapping.FocusBorderColor = Color.FromArgb(92, 53, 142);
            tglMapping.Font = new Font("Microsoft Sans Serif", 9F);
            tglMapping.Location = new Point(101, 475);
            tglMapping.Margin = new Padding(1);
            tglMapping.MinimumSize = new Size(20, 10);
            tglMapping.Name = "tglMapping";
            tglMapping.OffBackColor = Color.LightGray;
            tglMapping.OnBackColor = Color.FromArgb(92, 53, 142);
            tglMapping.Size = new Size(30, 18);
            tglMapping.TabIndex = 474;
            tglMapping.Text = "toggleButton5";
            tglMapping.ThumbInset = 1;
            tglMapping.ToggleColor = Color.White;
            tglMapping.ToggleShape = Cuadro_de_herramientas.ToggleButtonShape.RoundedRectangle;
            tglMapping.UseVisualStyleBackColor = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 9F);
            label8.Location = new Point(132, 475);
            label8.Name = "label8";
            label8.Size = new Size(118, 15);
            label8.TabIndex = 473;
            label8.Text = "Mapa de posiciones";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 9F);
            label9.Location = new Point(132, 497);
            label9.Name = "label9";
            label9.Size = new Size(72, 15);
            label9.TabIndex = 472;
            label9.Text = "Excel layout";
            // 
            // btnManifestPerFarm
            // 
            btnManifestPerFarm.AnimationSpeed = 4;
            btnManifestPerFarm.Appearance = Appearance.Button;
            btnManifestPerFarm.BackColor = Color.Transparent;
            btnManifestPerFarm.BorderColor = Color.Empty;
            btnManifestPerFarm.FocusBackColor = Color.FromArgb(202, 167, 243);
            btnManifestPerFarm.FocusBorderColor = Color.FromArgb(92, 53, 142);
            btnManifestPerFarm.Font = new Font("Microsoft Sans Serif", 9F);
            btnManifestPerFarm.Location = new Point(101, 453);
            btnManifestPerFarm.Margin = new Padding(1);
            btnManifestPerFarm.MinimumSize = new Size(20, 10);
            btnManifestPerFarm.Name = "btnManifestPerFarm";
            btnManifestPerFarm.OffBackColor = Color.LightGray;
            btnManifestPerFarm.OnBackColor = Color.FromArgb(92, 53, 142);
            btnManifestPerFarm.Size = new Size(30, 18);
            btnManifestPerFarm.TabIndex = 471;
            btnManifestPerFarm.Text = "toggleButton3";
            btnManifestPerFarm.ThumbInset = 1;
            btnManifestPerFarm.ToggleColor = Color.White;
            btnManifestPerFarm.ToggleShape = Cuadro_de_herramientas.ToggleButtonShape.RoundedRectangle;
            btnManifestPerFarm.UseVisualStyleBackColor = false;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 9F);
            label10.Location = new Point(132, 453);
            label10.Name = "label10";
            label10.Size = new Size(126, 15);
            label10.TabIndex = 470;
            label10.Text = "Manifiesto por campo";
            // 
            // tglManifest
            // 
            tglManifest.AnimationSpeed = 4;
            tglManifest.Appearance = Appearance.Button;
            tglManifest.BackColor = Color.Transparent;
            tglManifest.BorderColor = Color.Empty;
            tglManifest.FocusBackColor = Color.FromArgb(202, 167, 243);
            tglManifest.FocusBorderColor = Color.FromArgb(92, 53, 142);
            tglManifest.Font = new Font("Microsoft Sans Serif", 9F);
            tglManifest.Location = new Point(101, 431);
            tglManifest.Margin = new Padding(1);
            tglManifest.MinimumSize = new Size(20, 10);
            tglManifest.Name = "tglManifest";
            tglManifest.OffBackColor = Color.LightGray;
            tglManifest.OnBackColor = Color.FromArgb(92, 53, 142);
            tglManifest.Size = new Size(30, 18);
            tglManifest.TabIndex = 469;
            tglManifest.Text = "toggleButton2";
            tglManifest.ThumbInset = 1;
            tglManifest.ToggleColor = Color.White;
            tglManifest.ToggleShape = Cuadro_de_herramientas.ToggleButtonShape.RoundedRectangle;
            tglManifest.UseVisualStyleBackColor = false;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft Sans Serif", 9F);
            label11.Location = new Point(132, 431);
            label11.Name = "label11";
            label11.Size = new Size(64, 15);
            label11.TabIndex = 468;
            label11.Text = "Manifiesto";
            // 
            // tglShowSize
            // 
            tglShowSize.AnimationSpeed = 4;
            tglShowSize.Appearance = Appearance.Button;
            tglShowSize.BackColor = Color.Transparent;
            tglShowSize.BorderColor = Color.Empty;
            tglShowSize.FocusBackColor = Color.FromArgb(202, 167, 243);
            tglShowSize.FocusBorderColor = Color.FromArgb(92, 53, 142);
            tglShowSize.Font = new Font("Microsoft Sans Serif", 9F);
            tglShowSize.Location = new Point(101, 409);
            tglShowSize.Margin = new Padding(1);
            tglShowSize.MinimumSize = new Size(20, 10);
            tglShowSize.Name = "tglShowSize";
            tglShowSize.OffBackColor = Color.LightGray;
            tglShowSize.OnBackColor = Color.FromArgb(92, 53, 142);
            tglShowSize.Size = new Size(30, 18);
            tglShowSize.TabIndex = 467;
            tglShowSize.Text = "toggleButton1";
            tglShowSize.ThumbInset = 1;
            tglShowSize.ToggleColor = Color.White;
            tglShowSize.ToggleShape = Cuadro_de_herramientas.ToggleButtonShape.RoundedRectangle;
            tglShowSize.UseVisualStyleBackColor = false;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 9F);
            label12.Location = new Point(132, 409);
            label12.Name = "label12";
            label12.Size = new Size(94, 15);
            label12.TabIndex = 466;
            label12.Text = "Mostrar tamaño";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.Location = new Point(99, 392);
            label13.Name = "label13";
            label13.Size = new Size(87, 15);
            label13.TabIndex = 478;
            label13.Text = "Documentos";
            // 
            // FrmManifestTemplatesAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(441, 549);
            Controls.Add(label13);
            Controls.Add(tglPrintPackingList);
            Controls.Add(label7);
            Controls.Add(tglExcelLayout);
            Controls.Add(tglMapping);
            Controls.Add(label8);
            Controls.Add(label9);
            Controls.Add(btnManifestPerFarm);
            Controls.Add(label10);
            Controls.Add(tglManifest);
            Controls.Add(label11);
            Controls.Add(tglShowSize);
            Controls.Add(label12);
            Controls.Add(cboCrop);
            Controls.Add(label6);
            Controls.Add(cboActive);
            Controls.Add(lblActivo);
            Controls.Add(label5);
            Controls.Add(txbId);
            Controls.Add(btnAccept);
            Controls.Add(btnCancel);
            Controls.Add(txbDescription);
            Controls.Add(txbName);
            Controls.Add(lblTitle);
            Controls.Add(chbRemovedDistributor);
            Controls.Add(chbRemovedCityDestination);
            Controls.Add(chbRemovedCityCrossPoint);
            Controls.Add(chbRemovedAgencyMX);
            Controls.Add(chbRemovedAgencyUS);
            Controls.Add(chbRemovedGrower);
            Controls.Add(chbRemovedConsignee);
            Controls.Add(cboDistributor);
            Controls.Add(cboConsignee);
            Controls.Add(cboCityDestination);
            Controls.Add(cboCityCrossPoint);
            Controls.Add(cboGrower);
            Controls.Add(cboAgencyUS);
            Controls.Add(cboAgencyMX);
            Controls.Add(label3);
            Controls.Add(label16);
            Controls.Add(lblCiudadDestino);
            Controls.Add(lblCiudadCruce);
            Controls.Add(lblProductor);
            Controls.Add(lblAgenciaUS);
            Controls.Add(lblAcenciaMX);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label4);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmManifestTemplatesAdd";
            Text = "Añadir plantillas de manifiesto";
            Load += FrmManifestTemplatesAdd_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAccept;
        private Button btnCancel;
        public RichTextBox txbDescription;
        public TextBox txbName;
        public Label lblTitle;
        public CheckBox chbRemovedDistributor;
        public CheckBox chbRemovedCityDestination;
        public CheckBox chbRemovedCityCrossPoint;
        public CheckBox chbRemovedAgencyMX;
        public CheckBox chbRemovedAgencyUS;
        public CheckBox chbRemovedGrower;
        public CheckBox chbRemovedConsignee;
        public ComboBox cboDistributor;
        public ComboBox cboConsignee;
        public ComboBox cboCityDestination;
        public ComboBox cboCityCrossPoint;
        public ComboBox cboGrower;
        public ComboBox cboAgencyUS;
        public ComboBox cboAgencyMX;
        private Label label3;
        private Label label16;
        private Label lblCiudadDestino;
        private Label lblCiudadCruce;
        private Label lblProductor;
        private Label lblAgenciaUS;
        private Label lblAcenciaMX;
        private Label label2;
        private Label label1;
        public TextBox txbId;
        private Label label4;
        public ComboBox cboActive;
        private Label label5;
        private Label lblActivo;
        public ComboBox cboCrop;
        private Label label6;
        public Cuadro_de_herramientas.ToggleButton tglPrintPackingList;
        private Label label7;
        public Cuadro_de_herramientas.ToggleButton tglExcelLayout;
        public Cuadro_de_herramientas.ToggleButton tglMapping;
        private Label label8;
        private Label label9;
        public Cuadro_de_herramientas.ToggleButton btnManifestPerFarm;
        private Label label10;
        public Cuadro_de_herramientas.ToggleButton tglManifest;
        private Label label11;
        public Cuadro_de_herramientas.ToggleButton tglShowSize;
        private Label label12;
        private Label label13;
    }
}