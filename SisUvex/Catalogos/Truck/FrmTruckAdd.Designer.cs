namespace SisUvex.Catalogos.Truck
{
    partial class FrmTruckAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTruckAdd));
            lblColor = new Label();
            txbColor = new TextBox();
            lblVIN = new Label();
            txbVinNumber = new TextBox();
            lblAño = new Label();
            lblModelo = new Label();
            txbYear = new TextBox();
            lblMarca = new Label();
            txbBrand = new TextBox();
            lblPlacasMX = new Label();
            txbPlateMX = new TextBox();
            lblPlacasUS = new Label();
            txbPlateUS = new TextBox();
            lblNumEco = new Label();
            cboActive = new ComboBox();
            lblObliLinea = new Label();
            btnAccept = new Button();
            btnCancel = new Button();
            txbId = new TextBox();
            lblTitle = new Label();
            lblId = new Label();
            lblObliId = new Label();
            txbEcoNumber = new TextBox();
            lblObliNumEco = new Label();
            label2 = new Label();
            lblActivo = new Label();
            lblLinea = new Label();
            chbTransportLineRemoved = new CheckBox();
            btnTransportLineSearch = new Button();
            txbIdTransportLine = new TextBox();
            cboTransportLine = new ComboBox();
            SuspendLayout();
            // 
            // lblColor
            // 
            lblColor.AutoSize = true;
            lblColor.Font = new Font("Segoe UI", 12F);
            lblColor.Location = new Point(44, 301);
            lblColor.Name = "lblColor";
            lblColor.Size = new Size(51, 21);
            lblColor.TabIndex = 99;
            lblColor.Text = "Color:";
            // 
            // txbColor
            // 
            txbColor.Font = new Font("Segoe UI", 12F);
            txbColor.Location = new Point(101, 298);
            txbColor.MaxLength = 30;
            txbColor.Name = "txbColor";
            txbColor.Size = new Size(237, 29);
            txbColor.TabIndex = 84;
            // 
            // lblVIN
            // 
            lblVIN.AutoSize = true;
            lblVIN.Font = new Font("Segoe UI", 12F);
            lblVIN.Location = new Point(56, 266);
            lblVIN.Name = "lblVIN";
            lblVIN.Size = new Size(39, 21);
            lblVIN.TabIndex = 98;
            lblVIN.Text = "VIN:";
            // 
            // txbVinNumber
            // 
            txbVinNumber.Font = new Font("Segoe UI", 12F);
            txbVinNumber.Location = new Point(101, 263);
            txbVinNumber.MaxLength = 30;
            txbVinNumber.Name = "txbVinNumber";
            txbVinNumber.Size = new Size(392, 29);
            txbVinNumber.TabIndex = 83;
            // 
            // lblAño
            // 
            lblAño.AutoSize = true;
            lblAño.Font = new Font("Segoe UI", 12F);
            lblAño.ForeColor = SystemColors.AppWorkspace;
            lblAño.Location = new Point(182, 231);
            lblAño.Name = "lblAño";
            lblAño.Size = new Size(36, 21);
            lblAño.TabIndex = 97;
            lblAño.Text = "año";
            // 
            // lblModelo
            // 
            lblModelo.AutoSize = true;
            lblModelo.Font = new Font("Segoe UI", 12F);
            lblModelo.Location = new Point(29, 231);
            lblModelo.Name = "lblModelo";
            lblModelo.Size = new Size(66, 21);
            lblModelo.TabIndex = 96;
            lblModelo.Text = "Modelo:";
            // 
            // txbYear
            // 
            txbYear.Font = new Font("Segoe UI", 12F);
            txbYear.Location = new Point(101, 228);
            txbYear.MaxLength = 4;
            txbYear.Name = "txbYear";
            txbYear.Size = new Size(80, 29);
            txbYear.TabIndex = 82;
            // 
            // lblMarca
            // 
            lblMarca.AutoSize = true;
            lblMarca.Font = new Font("Segoe UI", 12F);
            lblMarca.Location = new Point(39, 196);
            lblMarca.Name = "lblMarca";
            lblMarca.Size = new Size(56, 21);
            lblMarca.TabIndex = 95;
            lblMarca.Text = "Marca:";
            // 
            // txbBrand
            // 
            txbBrand.Font = new Font("Segoe UI", 12F);
            txbBrand.Location = new Point(101, 193);
            txbBrand.MaxLength = 30;
            txbBrand.Name = "txbBrand";
            txbBrand.Size = new Size(392, 29);
            txbBrand.TabIndex = 81;
            // 
            // lblPlacasMX
            // 
            lblPlacasMX.AutoSize = true;
            lblPlacasMX.Font = new Font("Segoe UI", 12F);
            lblPlacasMX.Location = new Point(12, 161);
            lblPlacasMX.Name = "lblPlacasMX";
            lblPlacasMX.Size = new Size(83, 21);
            lblPlacasMX.TabIndex = 94;
            lblPlacasMX.Text = "Placas MX:";
            // 
            // txbPlateMX
            // 
            txbPlateMX.Font = new Font("Segoe UI", 12F);
            txbPlateMX.Location = new Point(101, 158);
            txbPlateMX.MaxLength = 15;
            txbPlateMX.Name = "txbPlateMX";
            txbPlateMX.Size = new Size(237, 29);
            txbPlateMX.TabIndex = 80;
            // 
            // lblPlacasUS
            // 
            lblPlacasUS.AutoSize = true;
            lblPlacasUS.Font = new Font("Segoe UI", 12F);
            lblPlacasUS.Location = new Point(15, 126);
            lblPlacasUS.Name = "lblPlacasUS";
            lblPlacasUS.Size = new Size(80, 21);
            lblPlacasUS.TabIndex = 93;
            lblPlacasUS.Text = "Placas US:";
            // 
            // txbPlateUS
            // 
            txbPlateUS.Font = new Font("Segoe UI", 12F);
            txbPlateUS.Location = new Point(101, 123);
            txbPlateUS.MaxLength = 15;
            txbPlateUS.Name = "txbPlateUS";
            txbPlateUS.Size = new Size(237, 29);
            txbPlateUS.TabIndex = 79;
            // 
            // lblNumEco
            // 
            lblNumEco.AutoSize = true;
            lblNumEco.Font = new Font("Segoe UI", 12F);
            lblNumEco.Location = new Point(6, 91);
            lblNumEco.Name = "lblNumEco";
            lblNumEco.Size = new Size(151, 21);
            lblNumEco.TabIndex = 91;
            lblNumEco.Text = "Número económico:";
            // 
            // cboActive
            // 
            cboActive.DropDownStyle = ComboBoxStyle.DropDownList;
            cboActive.Font = new Font("Segoe UI", 12F);
            cboActive.FormattingEnabled = true;
            cboActive.Items.AddRange(new object[] { "No", "Sí" });
            cboActive.Location = new Point(440, 12);
            cboActive.Name = "cboActive";
            cboActive.Size = new Size(46, 29);
            cboActive.TabIndex = 70;
            // 
            // lblObliLinea
            // 
            lblObliLinea.AutoSize = true;
            lblObliLinea.ForeColor = Color.Crimson;
            lblObliLinea.Location = new Point(154, 53);
            lblObliLinea.Name = "lblObliLinea";
            lblObliLinea.Size = new Size(12, 15);
            lblObliLinea.TabIndex = 88;
            lblObliLinea.Text = "*";
            // 
            // btnAccept
            // 
            btnAccept.Location = new Point(414, 337);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(75, 29);
            btnAccept.TabIndex = 86;
            btnAccept.Text = "Aceptar";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(495, 337);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 29);
            btnCancel.TabIndex = 87;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // txbId
            // 
            txbId.Enabled = false;
            txbId.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbId.Location = new Point(524, 12);
            txbId.Name = "txbId";
            txbId.Size = new Size(46, 29);
            txbId.TabIndex = 72;
            txbId.TextAlign = HorizontalAlignment.Center;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial Black", 16F);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(180, 31);
            lblTitle.TabIndex = 69;
            lblTitle.Text = "Añadir troque";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 12F);
            lblId.Location = new Point(492, 15);
            lblId.Name = "lblId";
            lblId.Size = new Size(26, 21);
            lblId.TabIndex = 78;
            lblId.Text = "Id:";
            // 
            // lblObliId
            // 
            lblObliId.AutoSize = true;
            lblObliId.ForeColor = Color.Crimson;
            lblObliId.Location = new Point(515, 12);
            lblObliId.Name = "lblObliId";
            lblObliId.Size = new Size(12, 15);
            lblObliId.TabIndex = 85;
            lblObliId.Text = "*";
            // 
            // txbEcoNumber
            // 
            txbEcoNumber.Font = new Font("Segoe UI", 12F);
            txbEcoNumber.Location = new Point(163, 88);
            txbEcoNumber.MaxLength = 15;
            txbEcoNumber.Name = "txbEcoNumber";
            txbEcoNumber.Size = new Size(175, 29);
            txbEcoNumber.TabIndex = 77;
            // 
            // lblObliNumEco
            // 
            lblObliNumEco.AutoSize = true;
            lblObliNumEco.ForeColor = Color.Crimson;
            lblObliNumEco.Location = new Point(155, 88);
            lblObliNumEco.Name = "lblObliNumEco";
            lblObliNumEco.Size = new Size(12, 15);
            lblObliNumEco.TabIndex = 92;
            lblObliNumEco.Text = "*";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Crimson;
            label2.Location = new Point(429, 12);
            label2.Name = "label2";
            label2.Size = new Size(12, 15);
            label2.TabIndex = 90;
            label2.Text = "*";
            // 
            // lblActivo
            // 
            lblActivo.AutoSize = true;
            lblActivo.Font = new Font("Segoe UI", 12F);
            lblActivo.Location = new Point(378, 15);
            lblActivo.Name = "lblActivo";
            lblActivo.Size = new Size(60, 21);
            lblActivo.TabIndex = 89;
            lblActivo.Text = "Activo: ";
            // 
            // lblLinea
            // 
            lblLinea.AutoSize = true;
            lblLinea.Font = new Font("Segoe UI", 12F);
            lblLinea.Location = new Point(10, 56);
            lblLinea.Name = "lblLinea";
            lblLinea.Size = new Size(147, 21);
            lblLinea.TabIndex = 71;
            lblLinea.Text = "Línea de transporte:";
            // 
            // chbTransportLineRemoved
            // 
            chbTransportLineRemoved.Appearance = Appearance.Button;
            chbTransportLineRemoved.AutoSize = true;
            chbTransportLineRemoved.BackgroundImage = Properties.Resources.Imagen6;
            chbTransportLineRemoved.BackgroundImageLayout = ImageLayout.Stretch;
            chbTransportLineRemoved.Font = new Font("Segoe UI", 10F);
            chbTransportLineRemoved.Location = new Point(499, 53);
            chbTransportLineRemoved.Name = "chbTransportLineRemoved";
            chbTransportLineRemoved.Size = new Size(39, 29);
            chbTransportLineRemoved.TabIndex = 100;
            chbTransportLineRemoved.Text = "     ";
            chbTransportLineRemoved.UseVisualStyleBackColor = true;
            // 
            // btnTransportLineSearch
            // 
            btnTransportLineSearch.BackgroundImage = Properties.Resources.buscarIcon32;
            btnTransportLineSearch.BackgroundImageLayout = ImageLayout.Stretch;
            btnTransportLineSearch.Location = new Point(541, 53);
            btnTransportLineSearch.Name = "btnTransportLineSearch";
            btnTransportLineSearch.Size = new Size(29, 29);
            btnTransportLineSearch.TabIndex = 101;
            btnTransportLineSearch.UseVisualStyleBackColor = true;
            btnTransportLineSearch.Click += btnTransportLineSearch_Click;
            // 
            // txbIdTransportLine
            // 
            txbIdTransportLine.Enabled = false;
            txbIdTransportLine.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbIdTransportLine.Location = new Point(163, 53);
            txbIdTransportLine.Name = "txbIdTransportLine";
            txbIdTransportLine.Size = new Size(46, 29);
            txbIdTransportLine.TabIndex = 102;
            txbIdTransportLine.TextAlign = HorizontalAlignment.Center;
            // 
            // cboTransportLine
            // 
            cboTransportLine.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTransportLine.Font = new Font("Segoe UI", 12F);
            cboTransportLine.FormattingEnabled = true;
            cboTransportLine.ItemHeight = 21;
            cboTransportLine.Location = new Point(215, 53);
            cboTransportLine.Name = "cboTransportLine";
            cboTransportLine.Size = new Size(278, 29);
            cboTransportLine.TabIndex = 103;
            // 
            // FrmTruckAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(581, 378);
            Controls.Add(txbIdTransportLine);
            Controls.Add(cboTransportLine);
            Controls.Add(chbTransportLineRemoved);
            Controls.Add(btnTransportLineSearch);
            Controls.Add(lblColor);
            Controls.Add(txbColor);
            Controls.Add(lblVIN);
            Controls.Add(txbVinNumber);
            Controls.Add(lblAño);
            Controls.Add(lblModelo);
            Controls.Add(txbYear);
            Controls.Add(lblMarca);
            Controls.Add(txbBrand);
            Controls.Add(lblPlacasMX);
            Controls.Add(txbPlateMX);
            Controls.Add(lblPlacasUS);
            Controls.Add(txbPlateUS);
            Controls.Add(lblNumEco);
            Controls.Add(cboActive);
            Controls.Add(lblObliLinea);
            Controls.Add(btnAccept);
            Controls.Add(btnCancel);
            Controls.Add(txbId);
            Controls.Add(lblTitle);
            Controls.Add(lblId);
            Controls.Add(lblObliId);
            Controls.Add(txbEcoNumber);
            Controls.Add(lblObliNumEco);
            Controls.Add(label2);
            Controls.Add(lblActivo);
            Controls.Add(lblLinea);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmTruckAdd";
            Text = "Añadir troque";
            Load += FrmTruckAdd_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblColor;
        public TextBox txbColor;
        private Label lblVIN;
        public TextBox txbVinNumber;
        private Label lblAño;
        private Label lblModelo;
        public TextBox txbYear;
        private Label lblMarca;
        public TextBox txbBrand;
        private Label lblPlacasMX;
        public TextBox txbPlateMX;
        private Label lblPlacasUS;
        public TextBox txbPlateUS;
        private Label lblNumEco;
        public ComboBox cboActive;
        private Label lblObliLinea;
        private Button btnAccept;
        private Button btnCancel;
        public TextBox txbId;
        public Label lblTitle;
        private Label lblId;
        private Label lblObliId;
        public TextBox txbEcoNumber;
        private Label lblObliNumEco;
        private Label label2;
        private Label lblActivo;
        private Label lblLinea;
        public CheckBox chbTransportLineRemoved;
        public Button btnTransportLineSearch;
        public TextBox txbIdTransportLine;
        public ComboBox cboTransportLine;
    }
}