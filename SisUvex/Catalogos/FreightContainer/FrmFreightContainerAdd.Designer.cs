namespace SisUvex.Catalogos.FreightContainer
{
    partial class FrmFreightContainerAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFreightContainerAdd));
            chbTransportLineRemoved = new CheckBox();
            btnTransportLineSearch = new Button();
            txbIdTransportLine = new TextBox();
            cboTransportLine = new ComboBox();
            lblAño = new Label();
            lblTipo = new Label();
            cboTypeContainer = new ComboBox();
            lblPies = new Label();
            lblTamaño = new Label();
            txbSize = new TextBox();
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
            SuspendLayout();
            // 
            // chbTransportLineRemoved
            // 
            chbTransportLineRemoved.Appearance = Appearance.Button;
            chbTransportLineRemoved.AutoSize = true;
            chbTransportLineRemoved.BackgroundImage = Properties.Resources.Imagen6;
            chbTransportLineRemoved.BackgroundImageLayout = ImageLayout.Stretch;
            chbTransportLineRemoved.Font = new Font("Segoe UI", 10F);
            chbTransportLineRemoved.Location = new Point(498, 53);
            chbTransportLineRemoved.Name = "chbTransportLineRemoved";
            chbTransportLineRemoved.Size = new Size(39, 29);
            chbTransportLineRemoved.TabIndex = 122;
            chbTransportLineRemoved.Text = "     ";
            chbTransportLineRemoved.UseVisualStyleBackColor = true;
            // 
            // btnTransportLineSearch
            // 
            btnTransportLineSearch.BackgroundImage = Properties.Resources.buscarIcon32;
            btnTransportLineSearch.BackgroundImageLayout = ImageLayout.Stretch;
            btnTransportLineSearch.Location = new Point(540, 53);
            btnTransportLineSearch.Name = "btnTransportLineSearch";
            btnTransportLineSearch.Size = new Size(29, 29);
            btnTransportLineSearch.TabIndex = 123;
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
            txbIdTransportLine.TabIndex = 120;
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
            cboTransportLine.TabIndex = 121;
            // 
            // lblAño
            // 
            lblAño.AutoSize = true;
            lblAño.Font = new Font("Segoe UI", 12F);
            lblAño.ForeColor = SystemColors.AppWorkspace;
            lblAño.Location = new Point(182, 266);
            lblAño.Name = "lblAño";
            lblAño.Size = new Size(36, 21);
            lblAño.TabIndex = 119;
            lblAño.Text = "año";
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Font = new Font("Segoe UI", 12F);
            lblTipo.Location = new Point(10, 91);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(147, 21);
            lblTipo.TabIndex = 118;
            lblTipo.Text = "Tipo de contenedor:";
            // 
            // cboTypeContainer
            // 
            cboTypeContainer.Font = new Font("Segoe UI", 12F);
            cboTypeContainer.FormattingEnabled = true;
            cboTypeContainer.Location = new Point(163, 88);
            cboTypeContainer.Name = "cboTypeContainer";
            cboTypeContainer.Size = new Size(252, 29);
            cboTypeContainer.TabIndex = 94;
            // 
            // lblPies
            // 
            lblPies.AutoSize = true;
            lblPies.Font = new Font("Segoe UI", 12F);
            lblPies.ForeColor = SystemColors.AppWorkspace;
            lblPies.Location = new Point(182, 301);
            lblPies.Name = "lblPies";
            lblPies.Size = new Size(38, 21);
            lblPies.TabIndex = 117;
            lblPies.Text = "píes";
            // 
            // lblTamaño
            // 
            lblTamaño.AutoSize = true;
            lblTamaño.Font = new Font("Segoe UI", 12F);
            lblTamaño.Location = new Point(29, 301);
            lblTamaño.Name = "lblTamaño";
            lblTamaño.Size = new Size(67, 21);
            lblTamaño.TabIndex = 116;
            lblTamaño.Text = "Tamaño:";
            // 
            // txbSize
            // 
            txbSize.Font = new Font("Segoe UI", 12F);
            txbSize.Location = new Point(101, 298);
            txbSize.MaxLength = 3;
            txbSize.Name = "txbSize";
            txbSize.Size = new Size(80, 29);
            txbSize.TabIndex = 101;
            // 
            // lblModelo
            // 
            lblModelo.AutoSize = true;
            lblModelo.Font = new Font("Segoe UI", 12F);
            lblModelo.Location = new Point(29, 266);
            lblModelo.Name = "lblModelo";
            lblModelo.Size = new Size(66, 21);
            lblModelo.TabIndex = 115;
            lblModelo.Text = "Modelo:";
            // 
            // txbYear
            // 
            txbYear.Font = new Font("Segoe UI", 12F);
            txbYear.Location = new Point(101, 263);
            txbYear.MaxLength = 4;
            txbYear.Name = "txbYear";
            txbYear.Size = new Size(80, 29);
            txbYear.TabIndex = 100;
            // 
            // lblMarca
            // 
            lblMarca.AutoSize = true;
            lblMarca.Font = new Font("Segoe UI", 12F);
            lblMarca.Location = new Point(39, 231);
            lblMarca.Name = "lblMarca";
            lblMarca.Size = new Size(56, 21);
            lblMarca.TabIndex = 114;
            lblMarca.Text = "Marca:";
            // 
            // txbBrand
            // 
            txbBrand.Font = new Font("Segoe UI", 12F);
            txbBrand.Location = new Point(101, 228);
            txbBrand.MaxLength = 30;
            txbBrand.Name = "txbBrand";
            txbBrand.Size = new Size(392, 29);
            txbBrand.TabIndex = 99;
            // 
            // lblPlacasMX
            // 
            lblPlacasMX.AutoSize = true;
            lblPlacasMX.Font = new Font("Segoe UI", 12F);
            lblPlacasMX.Location = new Point(12, 196);
            lblPlacasMX.Name = "lblPlacasMX";
            lblPlacasMX.Size = new Size(83, 21);
            lblPlacasMX.TabIndex = 113;
            lblPlacasMX.Text = "Placas MX:";
            // 
            // txbPlateMX
            // 
            txbPlateMX.Font = new Font("Segoe UI", 12F);
            txbPlateMX.Location = new Point(101, 193);
            txbPlateMX.MaxLength = 15;
            txbPlateMX.Name = "txbPlateMX";
            txbPlateMX.Size = new Size(237, 29);
            txbPlateMX.TabIndex = 98;
            // 
            // lblPlacasUS
            // 
            lblPlacasUS.AutoSize = true;
            lblPlacasUS.Font = new Font("Segoe UI", 12F);
            lblPlacasUS.Location = new Point(15, 161);
            lblPlacasUS.Name = "lblPlacasUS";
            lblPlacasUS.Size = new Size(80, 21);
            lblPlacasUS.TabIndex = 112;
            lblPlacasUS.Text = "Placas US:";
            // 
            // txbPlateUS
            // 
            txbPlateUS.Font = new Font("Segoe UI", 12F);
            txbPlateUS.Location = new Point(101, 158);
            txbPlateUS.MaxLength = 15;
            txbPlateUS.Name = "txbPlateUS";
            txbPlateUS.Size = new Size(237, 29);
            txbPlateUS.TabIndex = 96;
            // 
            // lblNumEco
            // 
            lblNumEco.AutoSize = true;
            lblNumEco.Font = new Font("Segoe UI", 12F);
            lblNumEco.Location = new Point(6, 126);
            lblNumEco.Name = "lblNumEco";
            lblNumEco.Size = new Size(151, 21);
            lblNumEco.TabIndex = 110;
            lblNumEco.Text = "Número económico:";
            // 
            // cboActive
            // 
            cboActive.DropDownStyle = ComboBoxStyle.DropDownList;
            cboActive.Font = new Font("Segoe UI", 12F);
            cboActive.FormattingEnabled = true;
            cboActive.Items.AddRange(new object[] { "No", "Sí" });
            cboActive.Location = new Point(439, 18);
            cboActive.Name = "cboActive";
            cboActive.Size = new Size(46, 29);
            cboActive.TabIndex = 105;
            // 
            // lblObliLinea
            // 
            lblObliLinea.AutoSize = true;
            lblObliLinea.ForeColor = Color.Crimson;
            lblObliLinea.Location = new Point(154, 53);
            lblObliLinea.Name = "lblObliLinea";
            lblObliLinea.Size = new Size(12, 15);
            lblObliLinea.TabIndex = 107;
            lblObliLinea.Text = "*";
            // 
            // btnAccept
            // 
            btnAccept.Location = new Point(413, 332);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(75, 29);
            btnAccept.TabIndex = 103;
            btnAccept.Text = "Aceptar";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(494, 332);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 29);
            btnCancel.TabIndex = 102;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // txbId
            // 
            txbId.Enabled = false;
            txbId.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbId.Location = new Point(523, 18);
            txbId.Name = "txbId";
            txbId.Size = new Size(46, 29);
            txbId.TabIndex = 104;
            txbId.TextAlign = HorizontalAlignment.Center;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial Black", 16F);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(152, 31);
            lblTitle.TabIndex = 92;
            lblTitle.Text = "Añadir caja";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 12F);
            lblId.Location = new Point(491, 21);
            lblId.Name = "lblId";
            lblId.Size = new Size(26, 21);
            lblId.TabIndex = 97;
            lblId.Text = "Id:";
            // 
            // lblObliId
            // 
            lblObliId.AutoSize = true;
            lblObliId.ForeColor = Color.Crimson;
            lblObliId.Location = new Point(514, 18);
            lblObliId.Name = "lblObliId";
            lblObliId.Size = new Size(12, 15);
            lblObliId.TabIndex = 106;
            lblObliId.Text = "*";
            // 
            // txbEcoNumber
            // 
            txbEcoNumber.Font = new Font("Segoe UI", 12F);
            txbEcoNumber.Location = new Point(163, 123);
            txbEcoNumber.MaxLength = 15;
            txbEcoNumber.Name = "txbEcoNumber";
            txbEcoNumber.Size = new Size(175, 29);
            txbEcoNumber.TabIndex = 95;
            // 
            // lblObliNumEco
            // 
            lblObliNumEco.AutoSize = true;
            lblObliNumEco.ForeColor = Color.Crimson;
            lblObliNumEco.Location = new Point(155, 123);
            lblObliNumEco.Name = "lblObliNumEco";
            lblObliNumEco.Size = new Size(12, 15);
            lblObliNumEco.TabIndex = 111;
            lblObliNumEco.Text = "*";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Crimson;
            label2.Location = new Point(428, 18);
            label2.Name = "label2";
            label2.Size = new Size(12, 15);
            label2.TabIndex = 109;
            label2.Text = "*";
            // 
            // lblActivo
            // 
            lblActivo.AutoSize = true;
            lblActivo.Font = new Font("Segoe UI", 12F);
            lblActivo.Location = new Point(377, 21);
            lblActivo.Name = "lblActivo";
            lblActivo.Size = new Size(60, 21);
            lblActivo.TabIndex = 108;
            lblActivo.Text = "Activo: ";
            // 
            // lblLinea
            // 
            lblLinea.AutoSize = true;
            lblLinea.Font = new Font("Segoe UI", 12F);
            lblLinea.Location = new Point(10, 56);
            lblLinea.Name = "lblLinea";
            lblLinea.Size = new Size(147, 21);
            lblLinea.TabIndex = 93;
            lblLinea.Text = "Línea de transporte:";
            // 
            // FrmFreightContainerAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(583, 377);
            Controls.Add(chbTransportLineRemoved);
            Controls.Add(btnTransportLineSearch);
            Controls.Add(txbIdTransportLine);
            Controls.Add(cboTransportLine);
            Controls.Add(lblAño);
            Controls.Add(lblTipo);
            Controls.Add(cboTypeContainer);
            Controls.Add(lblPies);
            Controls.Add(lblTamaño);
            Controls.Add(txbSize);
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
            Name = "FrmFreightContainerAdd";
            Text = "Añadir caja";
            Load += FrmFreightContainerAdd_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public CheckBox chbTransportLineRemoved;
        public Button btnTransportLineSearch;
        public TextBox txbIdTransportLine;
        public ComboBox cboTransportLine;
        private Label lblAño;
        private Label lblTipo;
        public ComboBox cboTypeContainer;
        private Label lblPies;
        private Label lblTamaño;
        public TextBox txbSize;
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
    }
}