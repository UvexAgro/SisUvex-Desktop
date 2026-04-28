namespace SisUvex.Catalogos.Distributor
{
    partial class FrmDistributorAdd
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
            txbShortName = new TextBox();
            label4 = new Label();
            txbCountry = new TextBox();
            lblPais = new Label();
            label3 = new Label();
            cboCityDestination = new ComboBox();
            lblCiudadDestino = new Label();
            cboCityCross = new ComboBox();
            lblCiudadCruce = new Label();
            cboGrower = new ComboBox();
            lblProductor = new Label();
            cboAgencyUS = new ComboBox();
            lblAgenciaUS = new Label();
            cboAgencyMX = new ComboBox();
            lblAcenciaMX = new Label();
            txbPhoneNumber = new TextBox();
            lblTelefono = new Label();
            txbRFC = new TextBox();
            lblRFC = new Label();
            txbCityDistributor = new TextBox();
            lblCiudad = new Label();
            txbAddress = new TextBox();
            lblDireccion = new Label();
            btnAceptar = new Button();
            btnCancelar = new Button();
            txbId = new TextBox();
            txbName = new TextBox();
            lblNombre = new Label();
            lblTitulo = new Label();
            lblId = new Label();
            lblObliNombre = new Label();
            cboMarket = new ComboBox();
            cboActive = new ComboBox();
            lblActivo = new Label();
            lblMercado = new Label();
            label1 = new Label();
            label2 = new Label();
            chbAgencyUSRemoved = new CheckBox();
            chbAgencyMXRemoved = new CheckBox();
            chbCityCrossRemoved = new CheckBox();
            chbGrowerRemoved = new CheckBox();
            chbCityDestinationRemoved = new CheckBox();
            SuspendLayout();
            // 
            // txbShortName
            // 
            txbShortName.Font = new Font("Segoe UI", 12F);
            txbShortName.Location = new Point(132, 90);
            txbShortName.MaxLength = 10;
            txbShortName.Name = "txbShortName";
            txbShortName.Size = new Size(229, 29);
            txbShortName.TabIndex = 49;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Crimson;
            label4.Location = new Point(123, 90);
            label4.Name = "label4";
            label4.Size = new Size(12, 15);
            label4.TabIndex = 96;
            label4.Text = "*";
            // 
            // txbCountry
            // 
            txbCountry.Font = new Font("Segoe UI", 12F);
            txbCountry.Location = new Point(93, 160);
            txbCountry.MaxLength = 50;
            txbCountry.Name = "txbCountry";
            txbCountry.Size = new Size(268, 29);
            txbCountry.TabIndex = 51;
            // 
            // lblPais
            // 
            lblPais.AutoSize = true;
            lblPais.Font = new Font("Segoe UI", 12F);
            lblPais.Location = new Point(16, 163);
            lblPais.Name = "lblPais";
            lblPais.Size = new Size(40, 21);
            lblPais.TabIndex = 95;
            lblPais.Text = "País:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(15, 93);
            label3.Name = "label3";
            label3.Size = new Size(111, 21);
            label3.TabIndex = 94;
            label3.Text = "Nombre corto:";
            // 
            // cboCityDestination
            // 
            cboCityDestination.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCityDestination.Font = new Font("Segoe UI", 12F);
            cboCityDestination.FormattingEnabled = true;
            cboCityDestination.ItemHeight = 21;
            cboCityDestination.Location = new Point(139, 440);
            cboCityDestination.Name = "cboCityDestination";
            cboCityDestination.Size = new Size(388, 29);
            cboCityDestination.TabIndex = 80;
            // 
            // lblCiudadDestino
            // 
            lblCiudadDestino.AutoSize = true;
            lblCiudadDestino.Font = new Font("Segoe UI", 12F);
            lblCiudadDestino.Location = new Point(24, 443);
            lblCiudadDestino.Name = "lblCiudadDestino";
            lblCiudadDestino.Size = new Size(117, 21);
            lblCiudadDestino.TabIndex = 90;
            lblCiudadDestino.Text = "Ciudad destino:";
            // 
            // cboCityCross
            // 
            cboCityCross.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCityCross.Font = new Font("Segoe UI", 12F);
            cboCityCross.FormattingEnabled = true;
            cboCityCross.ItemHeight = 21;
            cboCityCross.Location = new Point(139, 405);
            cboCityCross.Name = "cboCityCross";
            cboCityCross.Size = new Size(388, 29);
            cboCityCross.TabIndex = 75;
            // 
            // lblCiudadCruce
            // 
            lblCiudadCruce.AutoSize = true;
            lblCiudadCruce.Font = new Font("Segoe UI", 12F);
            lblCiudadCruce.Location = new Point(38, 407);
            lblCiudadCruce.Name = "lblCiudadCruce";
            lblCiudadCruce.Size = new Size(103, 21);
            lblCiudadCruce.TabIndex = 88;
            lblCiudadCruce.Text = "Ciudad cruce:";
            // 
            // cboGrower
            // 
            cboGrower.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGrower.Font = new Font("Segoe UI", 12F);
            cboGrower.FormattingEnabled = true;
            cboGrower.ItemHeight = 21;
            cboGrower.Location = new Point(139, 370);
            cboGrower.Name = "cboGrower";
            cboGrower.Size = new Size(388, 29);
            cboGrower.TabIndex = 69;
            // 
            // lblProductor
            // 
            lblProductor.AutoSize = true;
            lblProductor.Font = new Font("Segoe UI", 12F);
            lblProductor.Location = new Point(59, 374);
            lblProductor.Name = "lblProductor";
            lblProductor.Size = new Size(82, 21);
            lblProductor.TabIndex = 84;
            lblProductor.Text = "Productor:";
            // 
            // cboAgencyUS
            // 
            cboAgencyUS.DropDownStyle = ComboBoxStyle.DropDownList;
            cboAgencyUS.Font = new Font("Segoe UI", 12F);
            cboAgencyUS.FormattingEnabled = true;
            cboAgencyUS.ItemHeight = 21;
            cboAgencyUS.Location = new Point(139, 300);
            cboAgencyUS.Name = "cboAgencyUS";
            cboAgencyUS.Size = new Size(388, 29);
            cboAgencyUS.TabIndex = 57;
            // 
            // lblAgenciaUS
            // 
            lblAgenciaUS.AutoSize = true;
            lblAgenciaUS.Font = new Font("Segoe UI", 12F);
            lblAgenciaUS.Location = new Point(49, 304);
            lblAgenciaUS.Name = "lblAgenciaUS";
            lblAgenciaUS.Size = new Size(92, 21);
            lblAgenciaUS.TabIndex = 81;
            lblAgenciaUS.Text = "Agencia US:";
            // 
            // cboAgencyMX
            // 
            cboAgencyMX.DropDownStyle = ComboBoxStyle.DropDownList;
            cboAgencyMX.Font = new Font("Segoe UI", 12F);
            cboAgencyMX.FormattingEnabled = true;
            cboAgencyMX.ItemHeight = 21;
            cboAgencyMX.Location = new Point(139, 335);
            cboAgencyMX.Name = "cboAgencyMX";
            cboAgencyMX.Size = new Size(388, 29);
            cboAgencyMX.TabIndex = 63;
            // 
            // lblAcenciaMX
            // 
            lblAcenciaMX.AutoSize = true;
            lblAcenciaMX.Font = new Font("Segoe UI", 12F);
            lblAcenciaMX.Location = new Point(46, 338);
            lblAcenciaMX.Name = "lblAcenciaMX";
            lblAcenciaMX.Size = new Size(95, 21);
            lblAcenciaMX.TabIndex = 76;
            lblAcenciaMX.Text = "Agencia MX:";
            // 
            // txbPhoneNumber
            // 
            txbPhoneNumber.Font = new Font("Segoe UI", 12F);
            txbPhoneNumber.Location = new Point(93, 265);
            txbPhoneNumber.MaxLength = 13;
            txbPhoneNumber.Name = "txbPhoneNumber";
            txbPhoneNumber.Size = new Size(268, 29);
            txbPhoneNumber.TabIndex = 55;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Font = new Font("Segoe UI", 12F);
            lblTelefono.Location = new Point(16, 268);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(71, 21);
            lblTelefono.TabIndex = 70;
            lblTelefono.Text = "Telefono:";
            // 
            // txbRFC
            // 
            txbRFC.Font = new Font("Segoe UI", 12F);
            txbRFC.Location = new Point(93, 230);
            txbRFC.MaxLength = 15;
            txbRFC.Name = "txbRFC";
            txbRFC.Size = new Size(268, 29);
            txbRFC.TabIndex = 54;
            // 
            // lblRFC
            // 
            lblRFC.AutoSize = true;
            lblRFC.Font = new Font("Segoe UI", 12F);
            lblRFC.Location = new Point(16, 233);
            lblRFC.Name = "lblRFC";
            lblRFC.Size = new Size(41, 21);
            lblRFC.TabIndex = 67;
            lblRFC.Text = "RFC:";
            // 
            // txbCityDistributor
            // 
            txbCityDistributor.Font = new Font("Segoe UI", 12F);
            txbCityDistributor.Location = new Point(93, 195);
            txbCityDistributor.MaxLength = 50;
            txbCityDistributor.Name = "txbCityDistributor";
            txbCityDistributor.Size = new Size(471, 29);
            txbCityDistributor.TabIndex = 52;
            // 
            // lblCiudad
            // 
            lblCiudad.AutoSize = true;
            lblCiudad.Font = new Font("Segoe UI", 12F);
            lblCiudad.Location = new Point(16, 198);
            lblCiudad.Name = "lblCiudad";
            lblCiudad.Size = new Size(62, 21);
            lblCiudad.TabIndex = 64;
            lblCiudad.Text = "Ciudad:";
            // 
            // txbAddress
            // 
            txbAddress.Font = new Font("Segoe UI", 12F);
            txbAddress.Location = new Point(93, 125);
            txbAddress.MaxLength = 100;
            txbAddress.Name = "txbAddress";
            txbAddress.Size = new Size(591, 29);
            txbAddress.TabIndex = 50;
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Font = new Font("Segoe UI", 12F);
            lblDireccion.Location = new Point(16, 128);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(78, 21);
            lblDireccion.TabIndex = 61;
            lblDireccion.Text = "Direccion:";
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(530, 479);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 29);
            btnAceptar.TabIndex = 85;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(611, 479);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 29);
            btnCancelar.TabIndex = 86;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // txbId
            // 
            txbId.Enabled = false;
            txbId.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbId.Location = new Point(638, 12);
            txbId.Name = "txbId";
            txbId.Size = new Size(46, 29);
            txbId.TabIndex = 46;
            txbId.TextAlign = HorizontalAlignment.Center;
            // 
            // txbName
            // 
            txbName.Font = new Font("Segoe UI", 12F);
            txbName.Location = new Point(92, 55);
            txbName.MaxLength = 50;
            txbName.Name = "txbName";
            txbName.Size = new Size(591, 29);
            txbName.TabIndex = 48;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 12F);
            lblNombre.Location = new Point(15, 58);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(71, 21);
            lblNombre.TabIndex = 47;
            lblNombre.Text = "Nombre:";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Arial Black", 16F);
            lblTitulo.Location = new Point(12, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(239, 31);
            lblTitulo.TabIndex = 45;
            lblTitulo.Text = "Añadir distribuidor";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 12F);
            lblId.Location = new Point(610, 15);
            lblId.Name = "lblId";
            lblId.Size = new Size(26, 21);
            lblId.TabIndex = 53;
            lblId.Text = "Id:";
            // 
            // lblObliNombre
            // 
            lblObliNombre.AutoSize = true;
            lblObliNombre.ForeColor = Color.Crimson;
            lblObliNombre.Location = new Point(83, 55);
            lblObliNombre.Name = "lblObliNombre";
            lblObliNombre.Size = new Size(12, 15);
            lblObliNombre.TabIndex = 91;
            lblObliNombre.Text = "*";
            // 
            // cboMarket
            // 
            cboMarket.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMarket.Font = new Font("Segoe UI", 12F);
            cboMarket.FormattingEnabled = true;
            cboMarket.Items.AddRange(new object[] { "E", "N" });
            cboMarket.Location = new Point(452, 12);
            cboMarket.Name = "cboMarket";
            cboMarket.Size = new Size(43, 29);
            cboMarket.TabIndex = 89;
            // 
            // cboActive
            // 
            cboActive.DropDownStyle = ComboBoxStyle.DropDownList;
            cboActive.Font = new Font("Segoe UI", 12F);
            cboActive.FormattingEnabled = true;
            cboActive.Items.AddRange(new object[] { "No", "Sí" });
            cboActive.Location = new Point(557, 12);
            cboActive.Name = "cboActive";
            cboActive.Size = new Size(46, 29);
            cboActive.TabIndex = 87;
            // 
            // lblActivo
            // 
            lblActivo.AutoSize = true;
            lblActivo.Font = new Font("Segoe UI", 12F);
            lblActivo.Location = new Point(496, 15);
            lblActivo.Name = "lblActivo";
            lblActivo.Size = new Size(56, 21);
            lblActivo.TabIndex = 59;
            lblActivo.Text = "Activo:";
            // 
            // lblMercado
            // 
            lblMercado.AutoSize = true;
            lblMercado.Font = new Font("Segoe UI", 12F);
            lblMercado.Location = new Point(373, 15);
            lblMercado.Name = "lblMercado";
            lblMercado.Size = new Size(74, 21);
            lblMercado.TabIndex = 74;
            lblMercado.Text = "Mercado:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.Crimson;
            label1.Location = new Point(444, 12);
            label1.Name = "label1";
            label1.Size = new Size(12, 15);
            label1.TabIndex = 92;
            label1.Text = "*";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.ForeColor = Color.Crimson;
            label2.Location = new Point(549, 12);
            label2.Name = "label2";
            label2.Size = new Size(12, 15);
            label2.TabIndex = 93;
            label2.Text = "*";
            // 
            // chbAgencyUSRemoved
            // 
            chbAgencyUSRemoved.Appearance = Appearance.Button;
            chbAgencyUSRemoved.BackgroundImage = Properties.Resources.Imagen6;
            chbAgencyUSRemoved.BackgroundImageLayout = ImageLayout.Stretch;
            chbAgencyUSRemoved.Font = new Font("Segoe UI", 10F);
            chbAgencyUSRemoved.Location = new Point(533, 299);
            chbAgencyUSRemoved.Name = "chbAgencyUSRemoved";
            chbAgencyUSRemoved.Size = new Size(43, 31);
            chbAgencyUSRemoved.TabIndex = 97;
            chbAgencyUSRemoved.Text = "     ";
            chbAgencyUSRemoved.UseVisualStyleBackColor = true;
            // 
            // chbAgencyMXRemoved
            // 
            chbAgencyMXRemoved.Appearance = Appearance.Button;
            chbAgencyMXRemoved.BackgroundImage = Properties.Resources.Imagen6;
            chbAgencyMXRemoved.BackgroundImageLayout = ImageLayout.Stretch;
            chbAgencyMXRemoved.Font = new Font("Segoe UI", 10F);
            chbAgencyMXRemoved.Location = new Point(533, 334);
            chbAgencyMXRemoved.Name = "chbAgencyMXRemoved";
            chbAgencyMXRemoved.Size = new Size(43, 31);
            chbAgencyMXRemoved.TabIndex = 98;
            chbAgencyMXRemoved.Text = "     ";
            chbAgencyMXRemoved.UseVisualStyleBackColor = true;
            // 
            // chbCityCrossRemoved
            // 
            chbCityCrossRemoved.Appearance = Appearance.Button;
            chbCityCrossRemoved.BackgroundImage = Properties.Resources.Imagen6;
            chbCityCrossRemoved.BackgroundImageLayout = ImageLayout.Stretch;
            chbCityCrossRemoved.Font = new Font("Segoe UI", 10F);
            chbCityCrossRemoved.Location = new Point(533, 404);
            chbCityCrossRemoved.Name = "chbCityCrossRemoved";
            chbCityCrossRemoved.Size = new Size(43, 31);
            chbCityCrossRemoved.TabIndex = 100;
            chbCityCrossRemoved.Text = "     ";
            chbCityCrossRemoved.UseVisualStyleBackColor = true;
            // 
            // chbGrowerRemoved
            // 
            chbGrowerRemoved.Appearance = Appearance.Button;
            chbGrowerRemoved.BackgroundImage = Properties.Resources.Imagen6;
            chbGrowerRemoved.BackgroundImageLayout = ImageLayout.Stretch;
            chbGrowerRemoved.Font = new Font("Segoe UI", 10F);
            chbGrowerRemoved.Location = new Point(533, 369);
            chbGrowerRemoved.Name = "chbGrowerRemoved";
            chbGrowerRemoved.Size = new Size(43, 31);
            chbGrowerRemoved.TabIndex = 99;
            chbGrowerRemoved.Text = "     ";
            chbGrowerRemoved.UseVisualStyleBackColor = true;
            // 
            // chbCityDestinationRemoved
            // 
            chbCityDestinationRemoved.Appearance = Appearance.Button;
            chbCityDestinationRemoved.BackgroundImage = Properties.Resources.Imagen6;
            chbCityDestinationRemoved.BackgroundImageLayout = ImageLayout.Stretch;
            chbCityDestinationRemoved.Font = new Font("Segoe UI", 10F);
            chbCityDestinationRemoved.Location = new Point(533, 439);
            chbCityDestinationRemoved.Name = "chbCityDestinationRemoved";
            chbCityDestinationRemoved.Size = new Size(43, 31);
            chbCityDestinationRemoved.TabIndex = 101;
            chbCityDestinationRemoved.Text = "     ";
            chbCityDestinationRemoved.UseVisualStyleBackColor = true;
            // 
            // FrmDistributorAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 522);
            Controls.Add(chbCityDestinationRemoved);
            Controls.Add(chbCityCrossRemoved);
            Controls.Add(chbGrowerRemoved);
            Controls.Add(chbAgencyMXRemoved);
            Controls.Add(chbAgencyUSRemoved);
            Controls.Add(txbShortName);
            Controls.Add(label4);
            Controls.Add(txbCountry);
            Controls.Add(lblPais);
            Controls.Add(label3);
            Controls.Add(cboCityDestination);
            Controls.Add(lblCiudadDestino);
            Controls.Add(cboCityCross);
            Controls.Add(lblCiudadCruce);
            Controls.Add(cboGrower);
            Controls.Add(lblProductor);
            Controls.Add(cboAgencyUS);
            Controls.Add(lblAgenciaUS);
            Controls.Add(cboAgencyMX);
            Controls.Add(lblAcenciaMX);
            Controls.Add(txbPhoneNumber);
            Controls.Add(lblTelefono);
            Controls.Add(txbRFC);
            Controls.Add(lblRFC);
            Controls.Add(txbCityDistributor);
            Controls.Add(lblCiudad);
            Controls.Add(txbAddress);
            Controls.Add(lblDireccion);
            Controls.Add(btnAceptar);
            Controls.Add(btnCancelar);
            Controls.Add(txbId);
            Controls.Add(txbName);
            Controls.Add(lblNombre);
            Controls.Add(lblTitulo);
            Controls.Add(lblId);
            Controls.Add(lblObliNombre);
            Controls.Add(cboMarket);
            Controls.Add(cboActive);
            Controls.Add(lblActivo);
            Controls.Add(lblMercado);
            Controls.Add(label1);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmDistributorAdd";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Distribuidor";
            Load += FrmDistributorAdd_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public TextBox txbShortName;
        private Label label4;
        public TextBox txbCountry;
        private Label lblPais;
        private Label label3;
        public ComboBox cboCityDestination;
        private Label lblCiudadDestino;
        public ComboBox cboCityCross;
        private Label lblCiudadCruce;
        public ComboBox cboGrower;
        private Label lblProductor;
        public ComboBox cboAgencyUS;
        private Label lblAgenciaUS;
        public ComboBox cboAgencyMX;
        private Label lblAcenciaMX;
        public TextBox txbPhoneNumber;
        private Label lblTelefono;
        public TextBox txbRFC;
        private Label lblRFC;
        public TextBox txbCityDistributor;
        private Label lblCiudad;
        public TextBox txbAddress;
        private Label lblDireccion;
        private Button btnAceptar;
        private Button btnCancelar;
        public TextBox txbId;
        public TextBox txbName;
        private Label lblNombre;
        public Label lblTitulo;
        private Label lblId;
        private Label lblObliNombre;
        public ComboBox cboMarket;
        public ComboBox cboActive;
        private Label lblActivo;
        private Label lblMercado;
        private Label label1;
        private Label label2;
        public CheckBox chbAgencyUSRemoved;
        public CheckBox chbAgencyMXRemoved;
        public CheckBox chbCityCrossRemoved;
        public CheckBox chbGrowerRemoved;
        public CheckBox chbCityDestinationRemoved;
    }
}