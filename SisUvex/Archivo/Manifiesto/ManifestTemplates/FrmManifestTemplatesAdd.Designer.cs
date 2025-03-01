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
            btnSearchDistributor = new Button();
            txbIdDistributor = new TextBox();
            cboDistributor = new ComboBox();
            btnSearchConsignee = new Button();
            txbIdConsignee = new TextBox();
            cboConsignee = new ComboBox();
            btnSearchCityDestination = new Button();
            btnSearchCityCrossPoint = new Button();
            btnSearchGrower = new Button();
            btnSearchAgencyMX = new Button();
            btnSearchAgencyUS = new Button();
            txbIdCityDestination = new TextBox();
            cboCityDestination = new ComboBox();
            txbIdCityCrossPoint = new TextBox();
            cboCityCrossPoint = new ComboBox();
            txbIdGrower = new TextBox();
            cboGrower = new ComboBox();
            txbIdAgencyUS = new TextBox();
            cboAgencyUS = new ComboBox();
            txbIdAgencyMX = new TextBox();
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
            SuspendLayout();
            // 
            // btnAccept
            // 
            btnAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAccept.Location = new Point(297, 347);
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
            btnCancel.Location = new Point(363, 347);
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
            txbDescription.Location = new Point(99, 58);
            txbDescription.MaxLength = 200;
            txbDescription.Name = "txbDescription";
            txbDescription.Size = new Size(328, 96);
            txbDescription.TabIndex = 453;
            txbDescription.Text = "";
            // 
            // txbName
            // 
            txbName.Font = new Font("Microsoft Sans Serif", 9F);
            txbName.Location = new Point(99, 35);
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
            lblTitle.Size = new Size(207, 23);
            lblTitle.TabIndex = 451;
            lblTitle.Text = "Plantilla de manifiesto";
            // 
            // chbRemovedDistributor
            // 
            chbRemovedDistributor.Appearance = Appearance.Button;
            chbRemovedDistributor.AutoSize = true;
            chbRemovedDistributor.Font = new Font("Segoe UI", 7.8F);
            chbRemovedDistributor.ForeColor = Color.DarkGray;
            chbRemovedDistributor.Image = Properties.Resources.removedList16;
            chbRemovedDistributor.Location = new Point(404, 161);
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
            chbRemovedCityDestination.Location = new Point(404, 311);
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
            chbRemovedCityCrossPoint.Location = new Point(404, 286);
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
            chbRemovedAgencyMX.Location = new Point(404, 261);
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
            chbRemovedAgencyUS.Location = new Point(404, 236);
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
            chbRemovedGrower.Location = new Point(404, 211);
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
            chbRemovedConsignee.Location = new Point(404, 186);
            chbRemovedConsignee.Name = "chbRemovedConsignee";
            chbRemovedConsignee.Size = new Size(23, 23);
            chbRemovedConsignee.TabIndex = 444;
            chbRemovedConsignee.Text = "  ";
            chbRemovedConsignee.UseVisualStyleBackColor = true;
            // 
            // btnSearchDistributor
            // 
            btnSearchDistributor.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnSearchDistributor.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearchDistributor.Enabled = false;
            btnSearchDistributor.Font = new Font("Microsoft Sans Serif", 9F);
            btnSearchDistributor.Location = new Point(379, 161);
            btnSearchDistributor.Name = "btnSearchDistributor";
            btnSearchDistributor.Size = new Size(23, 23);
            btnSearchDistributor.TabIndex = 441;
            btnSearchDistributor.UseVisualStyleBackColor = true;
            // 
            // txbIdDistributor
            // 
            txbIdDistributor.Enabled = false;
            txbIdDistributor.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdDistributor.Location = new Point(99, 161);
            txbIdDistributor.Name = "txbIdDistributor";
            txbIdDistributor.Size = new Size(37, 21);
            txbIdDistributor.TabIndex = 443;
            txbIdDistributor.TextAlign = HorizontalAlignment.Center;
            // 
            // cboDistributor
            // 
            cboDistributor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDistributor.Font = new Font("Microsoft Sans Serif", 8.25F);
            cboDistributor.FormattingEnabled = true;
            cboDistributor.ItemHeight = 13;
            cboDistributor.Location = new Point(141, 161);
            cboDistributor.Name = "cboDistributor";
            cboDistributor.Size = new Size(235, 21);
            cboDistributor.TabIndex = 440;
            // 
            // btnSearchConsignee
            // 
            btnSearchConsignee.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnSearchConsignee.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearchConsignee.Enabled = false;
            btnSearchConsignee.Font = new Font("Microsoft Sans Serif", 9F);
            btnSearchConsignee.Location = new Point(379, 186);
            btnSearchConsignee.Name = "btnSearchConsignee";
            btnSearchConsignee.Size = new Size(23, 23);
            btnSearchConsignee.TabIndex = 437;
            btnSearchConsignee.UseVisualStyleBackColor = true;
            // 
            // txbIdConsignee
            // 
            txbIdConsignee.Enabled = false;
            txbIdConsignee.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdConsignee.Location = new Point(99, 186);
            txbIdConsignee.Name = "txbIdConsignee";
            txbIdConsignee.Size = new Size(37, 21);
            txbIdConsignee.TabIndex = 439;
            txbIdConsignee.TextAlign = HorizontalAlignment.Center;
            // 
            // cboConsignee
            // 
            cboConsignee.DropDownStyle = ComboBoxStyle.DropDownList;
            cboConsignee.Font = new Font("Microsoft Sans Serif", 8.25F);
            cboConsignee.FormattingEnabled = true;
            cboConsignee.ItemHeight = 13;
            cboConsignee.Location = new Point(141, 186);
            cboConsignee.Name = "cboConsignee";
            cboConsignee.Size = new Size(235, 21);
            cboConsignee.TabIndex = 436;
            // 
            // btnSearchCityDestination
            // 
            btnSearchCityDestination.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnSearchCityDestination.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearchCityDestination.Enabled = false;
            btnSearchCityDestination.Font = new Font("Microsoft Sans Serif", 9F);
            btnSearchCityDestination.Location = new Point(379, 311);
            btnSearchCityDestination.Name = "btnSearchCityDestination";
            btnSearchCityDestination.Size = new Size(23, 23);
            btnSearchCityDestination.TabIndex = 425;
            btnSearchCityDestination.UseVisualStyleBackColor = true;
            // 
            // btnSearchCityCrossPoint
            // 
            btnSearchCityCrossPoint.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnSearchCityCrossPoint.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearchCityCrossPoint.Enabled = false;
            btnSearchCityCrossPoint.Font = new Font("Microsoft Sans Serif", 9F);
            btnSearchCityCrossPoint.Location = new Point(379, 286);
            btnSearchCityCrossPoint.Name = "btnSearchCityCrossPoint";
            btnSearchCityCrossPoint.Size = new Size(23, 23);
            btnSearchCityCrossPoint.TabIndex = 424;
            btnSearchCityCrossPoint.UseVisualStyleBackColor = true;
            // 
            // btnSearchGrower
            // 
            btnSearchGrower.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnSearchGrower.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearchGrower.Enabled = false;
            btnSearchGrower.Font = new Font("Microsoft Sans Serif", 9F);
            btnSearchGrower.Location = new Point(379, 211);
            btnSearchGrower.Name = "btnSearchGrower";
            btnSearchGrower.Size = new Size(23, 23);
            btnSearchGrower.TabIndex = 423;
            btnSearchGrower.UseVisualStyleBackColor = true;
            // 
            // btnSearchAgencyMX
            // 
            btnSearchAgencyMX.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnSearchAgencyMX.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearchAgencyMX.Enabled = false;
            btnSearchAgencyMX.Font = new Font("Microsoft Sans Serif", 9F);
            btnSearchAgencyMX.Location = new Point(379, 261);
            btnSearchAgencyMX.Name = "btnSearchAgencyMX";
            btnSearchAgencyMX.Size = new Size(23, 23);
            btnSearchAgencyMX.TabIndex = 422;
            btnSearchAgencyMX.UseVisualStyleBackColor = true;
            // 
            // btnSearchAgencyUS
            // 
            btnSearchAgencyUS.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnSearchAgencyUS.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearchAgencyUS.Enabled = false;
            btnSearchAgencyUS.Font = new Font("Microsoft Sans Serif", 9F);
            btnSearchAgencyUS.Location = new Point(379, 236);
            btnSearchAgencyUS.Name = "btnSearchAgencyUS";
            btnSearchAgencyUS.Size = new Size(23, 23);
            btnSearchAgencyUS.TabIndex = 421;
            btnSearchAgencyUS.UseVisualStyleBackColor = true;
            // 
            // txbIdCityDestination
            // 
            txbIdCityDestination.Enabled = false;
            txbIdCityDestination.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdCityDestination.Location = new Point(99, 311);
            txbIdCityDestination.Name = "txbIdCityDestination";
            txbIdCityDestination.Size = new Size(37, 21);
            txbIdCityDestination.TabIndex = 435;
            txbIdCityDestination.TextAlign = HorizontalAlignment.Center;
            // 
            // cboCityDestination
            // 
            cboCityDestination.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCityDestination.Font = new Font("Microsoft Sans Serif", 8.25F);
            cboCityDestination.FormattingEnabled = true;
            cboCityDestination.ItemHeight = 13;
            cboCityDestination.Location = new Point(141, 311);
            cboCityDestination.Name = "cboCityDestination";
            cboCityDestination.Size = new Size(235, 21);
            cboCityDestination.TabIndex = 420;
            // 
            // txbIdCityCrossPoint
            // 
            txbIdCityCrossPoint.Enabled = false;
            txbIdCityCrossPoint.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdCityCrossPoint.Location = new Point(99, 286);
            txbIdCityCrossPoint.Name = "txbIdCityCrossPoint";
            txbIdCityCrossPoint.Size = new Size(37, 21);
            txbIdCityCrossPoint.TabIndex = 433;
            txbIdCityCrossPoint.TextAlign = HorizontalAlignment.Center;
            // 
            // cboCityCrossPoint
            // 
            cboCityCrossPoint.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCityCrossPoint.Font = new Font("Microsoft Sans Serif", 8.25F);
            cboCityCrossPoint.FormattingEnabled = true;
            cboCityCrossPoint.ItemHeight = 13;
            cboCityCrossPoint.Location = new Point(141, 286);
            cboCityCrossPoint.Name = "cboCityCrossPoint";
            cboCityCrossPoint.Size = new Size(235, 21);
            cboCityCrossPoint.TabIndex = 419;
            // 
            // txbIdGrower
            // 
            txbIdGrower.Enabled = false;
            txbIdGrower.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdGrower.Location = new Point(99, 211);
            txbIdGrower.Name = "txbIdGrower";
            txbIdGrower.Size = new Size(37, 21);
            txbIdGrower.TabIndex = 431;
            txbIdGrower.TextAlign = HorizontalAlignment.Center;
            // 
            // cboGrower
            // 
            cboGrower.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGrower.Font = new Font("Microsoft Sans Serif", 8.25F);
            cboGrower.FormattingEnabled = true;
            cboGrower.ItemHeight = 13;
            cboGrower.Location = new Point(141, 211);
            cboGrower.Name = "cboGrower";
            cboGrower.Size = new Size(235, 21);
            cboGrower.TabIndex = 418;
            // 
            // txbIdAgencyUS
            // 
            txbIdAgencyUS.Enabled = false;
            txbIdAgencyUS.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdAgencyUS.Location = new Point(99, 236);
            txbIdAgencyUS.Name = "txbIdAgencyUS";
            txbIdAgencyUS.Size = new Size(37, 21);
            txbIdAgencyUS.TabIndex = 429;
            txbIdAgencyUS.TextAlign = HorizontalAlignment.Center;
            // 
            // cboAgencyUS
            // 
            cboAgencyUS.DropDownStyle = ComboBoxStyle.DropDownList;
            cboAgencyUS.Font = new Font("Microsoft Sans Serif", 8.25F);
            cboAgencyUS.FormattingEnabled = true;
            cboAgencyUS.ItemHeight = 13;
            cboAgencyUS.Location = new Point(141, 236);
            cboAgencyUS.Name = "cboAgencyUS";
            cboAgencyUS.Size = new Size(235, 21);
            cboAgencyUS.TabIndex = 416;
            // 
            // txbIdAgencyMX
            // 
            txbIdAgencyMX.Enabled = false;
            txbIdAgencyMX.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdAgencyMX.Location = new Point(99, 261);
            txbIdAgencyMX.Name = "txbIdAgencyMX";
            txbIdAgencyMX.Size = new Size(37, 21);
            txbIdAgencyMX.TabIndex = 427;
            txbIdAgencyMX.TextAlign = HorizontalAlignment.Center;
            // 
            // cboAgencyMX
            // 
            cboAgencyMX.DropDownStyle = ComboBoxStyle.DropDownList;
            cboAgencyMX.Font = new Font("Microsoft Sans Serif", 8.25F);
            cboAgencyMX.FormattingEnabled = true;
            cboAgencyMX.ItemHeight = 13;
            cboAgencyMX.Location = new Point(141, 261);
            cboAgencyMX.Name = "cboAgencyMX";
            cboAgencyMX.Size = new Size(235, 21);
            cboAgencyMX.TabIndex = 417;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 9F);
            label3.Location = new Point(29, 163);
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
            label16.Location = new Point(16, 188);
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
            lblCiudadDestino.Location = new Point(10, 314);
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
            lblCiudadCruce.Location = new Point(20, 289);
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
            lblProductor.Location = new Point(39, 214);
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
            lblAgenciaUS.Location = new Point(28, 239);
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
            lblAcenciaMX.Location = new Point(26, 264);
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
            label2.Location = new Point(26, 58);
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
            label1.Location = new Point(46, 38);
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
            txbId.Location = new Point(392, 12);
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
            label4.Location = new Point(374, 15);
            label4.Name = "label4";
            label4.Size = new Size(20, 15);
            label4.TabIndex = 459;
            label4.Text = "Id:";
            label4.TextAlign = ContentAlignment.TopRight;
            // 
            // FrmManifestTemplatesAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(441, 384);
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
            Name = "FrmManifestTemplatesAdd";
            Text = "FrmManifestTemplatesAdd";
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
        public Button btnSearchDistributor;
        public TextBox txbIdDistributor;
        public ComboBox cboDistributor;
        public Button btnSearchConsignee;
        public TextBox txbIdConsignee;
        public ComboBox cboConsignee;
        public Button btnSearchCityDestination;
        public Button btnSearchCityCrossPoint;
        public Button btnSearchGrower;
        public Button btnSearchAgencyMX;
        public Button btnSearchAgencyUS;
        public TextBox txbIdCityDestination;
        public ComboBox cboCityDestination;
        public TextBox txbIdCityCrossPoint;
        public ComboBox cboCityCrossPoint;
        public TextBox txbIdGrower;
        public ComboBox cboGrower;
        public TextBox txbIdAgencyUS;
        public ComboBox cboAgencyUS;
        public TextBox txbIdAgencyMX;
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
    }
}