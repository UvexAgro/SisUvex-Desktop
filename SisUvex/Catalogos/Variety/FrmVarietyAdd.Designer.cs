namespace SisUvex.Catalogos.Variety;

partial class FrmVarietyAdd
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVarietyAdd));
        lblTitulo = new Label();
        lblNameScientis = new Label();
        txbNameScientis = new TextBox();
        lblNameComercial = new Label();
        txbNameComercial = new TextBox();
        txbId = new TextBox();
        lblId = new Label();
        btnCancelar = new Button();
        btnAceptar = new Button();
        lblActivo = new Label();
        cboActive = new ComboBox();
        lblObliCom = new Label();
        cboColor = new ComboBox();
        lblColor = new Label();
        cboCrop = new ComboBox();
        lblCrop = new Label();
        lblObliColor = new Label();
        lblObliCrop = new Label();
        txbShortName = new TextBox();
        lblShortName = new Label();
        txbPatentLegend = new TextBox();
        lblPatentLegend = new Label();
        txbTrademark = new TextBox();
        lblTrademark = new Label();
        cboGrower = new ComboBox();
        label2 = new Label();
        label3 = new Label();
        tglUseFacility = new SisUvex.Cuadro_de_herramientas.ToggleButton();
        SuspendLayout();
        // 
        // lblTitulo
        // 
        lblTitulo.AutoSize = true;
        lblTitulo.Font = new Font("Arial Black", 16F);
        lblTitulo.Location = new Point(9, 9);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Size = new Size(205, 31);
        lblTitulo.TabIndex = 0;
        lblTitulo.Text = "Añadir variedad";
        // 
        // lblNameScientis
        // 
        lblNameScientis.AutoSize = true;
        lblNameScientis.Font = new Font("Segoe UI", 12F);
        lblNameScientis.Location = new Point(27, 50);
        lblNameScientis.Name = "lblNameScientis";
        lblNameScientis.Size = new Size(137, 21);
        lblNameScientis.TabIndex = 1;
        lblNameScientis.Text = "Nombre cientifico:";
        // 
        // txbNameScientis
        // 
        txbNameScientis.Font = new Font("Segoe UI", 12F);
        txbNameScientis.Location = new Point(169, 47);
        txbNameScientis.MaxLength = 20;
        txbNameScientis.Name = "txbNameScientis";
        txbNameScientis.Size = new Size(363, 29);
        txbNameScientis.TabIndex = 3;
        // 
        // lblNameComercial
        // 
        lblNameComercial.AutoSize = true;
        lblNameComercial.Font = new Font("Segoe UI", 12F);
        lblNameComercial.Location = new Point(22, 85);
        lblNameComercial.Name = "lblNameComercial";
        lblNameComercial.Size = new Size(142, 21);
        lblNameComercial.TabIndex = 3;
        lblNameComercial.Text = "Nombre comercial:";
        // 
        // txbNameComercial
        // 
        txbNameComercial.Font = new Font("Segoe UI", 12F);
        txbNameComercial.Location = new Point(169, 82);
        txbNameComercial.MaxLength = 60;
        txbNameComercial.Name = "txbNameComercial";
        txbNameComercial.Size = new Size(363, 29);
        txbNameComercial.TabIndex = 4;
        // 
        // txbId
        // 
        txbId.Enabled = false;
        txbId.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        txbId.Location = new Point(486, 12);
        txbId.Name = "txbId";
        txbId.Size = new Size(46, 29);
        txbId.TabIndex = 1;
        txbId.TextAlign = HorizontalAlignment.Center;
        // 
        // lblId
        // 
        lblId.AutoSize = true;
        lblId.Font = new Font("Segoe UI", 12F);
        lblId.Location = new Point(458, 15);
        lblId.Name = "lblId";
        lblId.Size = new Size(26, 21);
        lblId.TabIndex = 6;
        lblId.Text = "Id:";
        // 
        // btnCancelar
        // 
        btnCancelar.Location = new Point(458, 386);
        btnCancelar.Name = "btnCancelar";
        btnCancelar.Size = new Size(75, 29);
        btnCancelar.TabIndex = 11;
        btnCancelar.Text = "Cancelar";
        btnCancelar.UseVisualStyleBackColor = true;
        btnCancelar.Click += btnCancelar_Click;
        // 
        // btnAceptar
        // 
        btnAceptar.Location = new Point(377, 386);
        btnAceptar.Name = "btnAceptar";
        btnAceptar.Size = new Size(75, 29);
        btnAceptar.TabIndex = 10;
        btnAceptar.Text = "Aceptar";
        btnAceptar.UseVisualStyleBackColor = true;
        btnAceptar.Click += btnAceptar_Click;
        // 
        // lblActivo
        // 
        lblActivo.AutoSize = true;
        lblActivo.Font = new Font("Segoe UI", 12F);
        lblActivo.Location = new Point(349, 15);
        lblActivo.Name = "lblActivo";
        lblActivo.Size = new Size(60, 21);
        lblActivo.TabIndex = 10;
        lblActivo.Text = "Activo: ";
        // 
        // cboActive
        // 
        cboActive.DropDownStyle = ComboBoxStyle.DropDownList;
        cboActive.Font = new Font("Segoe UI", 12F);
        cboActive.FormattingEnabled = true;
        cboActive.Items.AddRange(new object[] { "No", "Sí" });
        cboActive.Location = new Point(405, 12);
        cboActive.Name = "cboActive";
        cboActive.Size = new Size(46, 29);
        cboActive.TabIndex = 0;
        // 
        // lblObliCom
        // 
        lblObliCom.AutoSize = true;
        lblObliCom.ForeColor = Color.Crimson;
        lblObliCom.Location = new Point(160, 82);
        lblObliCom.Name = "lblObliCom";
        lblObliCom.Size = new Size(12, 15);
        lblObliCom.TabIndex = 12;
        lblObliCom.Text = "*";
        // 
        // cboColor
        // 
        cboColor.DropDownStyle = ComboBoxStyle.DropDownList;
        cboColor.Font = new Font("Segoe UI", 12F);
        cboColor.FormattingEnabled = true;
        cboColor.Location = new Point(169, 222);
        cboColor.Name = "cboColor";
        cboColor.Size = new Size(363, 29);
        cboColor.TabIndex = 7;
        // 
        // lblColor
        // 
        lblColor.AutoSize = true;
        lblColor.Font = new Font("Segoe UI", 12F);
        lblColor.Location = new Point(115, 227);
        lblColor.Name = "lblColor";
        lblColor.Size = new Size(51, 21);
        lblColor.TabIndex = 33;
        lblColor.Text = "Color:";
        // 
        // cboCrop
        // 
        cboCrop.DropDownStyle = ComboBoxStyle.DropDownList;
        cboCrop.Font = new Font("Segoe UI", 12F);
        cboCrop.FormattingEnabled = true;
        cboCrop.Location = new Point(169, 257);
        cboCrop.Name = "cboCrop";
        cboCrop.Size = new Size(363, 29);
        cboCrop.TabIndex = 8;
        // 
        // lblCrop
        // 
        lblCrop.AutoSize = true;
        lblCrop.Font = new Font("Segoe UI", 12F);
        lblCrop.Location = new Point(104, 262);
        lblCrop.Name = "lblCrop";
        lblCrop.Size = new Size(62, 21);
        lblCrop.TabIndex = 36;
        lblCrop.Text = "Cultivo:";
        // 
        // lblObliColor
        // 
        lblObliColor.AutoSize = true;
        lblObliColor.ForeColor = Color.Crimson;
        lblObliColor.Location = new Point(160, 229);
        lblObliColor.Name = "lblObliColor";
        lblObliColor.Size = new Size(12, 15);
        lblObliColor.TabIndex = 39;
        lblObliColor.Text = "*";
        // 
        // lblObliCrop
        // 
        lblObliCrop.AutoSize = true;
        lblObliCrop.ForeColor = Color.Crimson;
        lblObliCrop.Location = new Point(160, 265);
        lblObliCrop.Name = "lblObliCrop";
        lblObliCrop.Size = new Size(12, 15);
        lblObliCrop.TabIndex = 40;
        lblObliCrop.Text = "*";
        // 
        // txbShortName
        // 
        txbShortName.Font = new Font("Segoe UI", 12F);
        txbShortName.Location = new Point(169, 117);
        txbShortName.MaxLength = 10;
        txbShortName.Name = "txbShortName";
        txbShortName.Size = new Size(363, 29);
        txbShortName.TabIndex = 5;
        // 
        // lblShortName
        // 
        lblShortName.AutoSize = true;
        lblShortName.Font = new Font("Segoe UI", 12F);
        lblShortName.Location = new Point(53, 120);
        lblShortName.Name = "lblShortName";
        lblShortName.Size = new Size(111, 21);
        lblShortName.TabIndex = 41;
        lblShortName.Text = "Nombre corto:";
        // 
        // txbPatentLegend
        // 
        txbPatentLegend.Font = new Font("Segoe UI", 12F);
        txbPatentLegend.Location = new Point(169, 152);
        txbPatentLegend.MaxLength = 50;
        txbPatentLegend.Name = "txbPatentLegend";
        txbPatentLegend.Size = new Size(363, 29);
        txbPatentLegend.TabIndex = 5;
        // 
        // lblPatentLegend
        // 
        lblPatentLegend.AutoSize = true;
        lblPatentLegend.Font = new Font("Segoe UI", 12F);
        lblPatentLegend.Location = new Point(37, 155);
        lblPatentLegend.Name = "lblPatentLegend";
        lblPatentLegend.Size = new Size(127, 21);
        lblPatentLegend.TabIndex = 41;
        lblPatentLegend.Text = "Leyenda patente:";
        // 
        // txbTrademark
        // 
        txbTrademark.Font = new Font("Segoe UI", 12F);
        txbTrademark.Location = new Point(169, 187);
        txbTrademark.MaxLength = 20;
        txbTrademark.Name = "txbTrademark";
        txbTrademark.Size = new Size(363, 29);
        txbTrademark.TabIndex = 6;
        // 
        // lblTrademark
        // 
        lblTrademark.AutoSize = true;
        lblTrademark.Font = new Font("Segoe UI", 12F);
        lblTrademark.Location = new Point(34, 190);
        lblTrademark.Name = "lblTrademark";
        lblTrademark.Size = new Size(130, 21);
        lblTrademark.TabIndex = 41;
        lblTrademark.Text = "Marca registrada:";
        // 
        // cboGrower
        // 
        cboGrower.DropDownStyle = ComboBoxStyle.DropDownList;
        cboGrower.Font = new Font("Segoe UI", 12F);
        cboGrower.FormattingEnabled = true;
        cboGrower.Location = new Point(169, 351);
        cboGrower.Name = "cboGrower";
        cboGrower.Size = new Size(363, 29);
        cboGrower.TabIndex = 42;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Font = new Font("Segoe UI", 12F);
        label2.Location = new Point(84, 354);
        label2.Name = "label2";
        label2.Size = new Size(82, 21);
        label2.TabIndex = 43;
        label2.Text = "Productor:";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Font = new Font("Segoe UI", 12F);
        label3.Location = new Point(214, 390);
        label3.Name = "label3";
        label3.Size = new Size(126, 21);
        label3.TabIndex = 45;
        label3.Text = "Empaque central";
        // 
        // tglUseFacility
        // 
        tglUseFacility.AnimationSpeed = 4;
        tglUseFacility.Appearance = Appearance.Button;
        tglUseFacility.BackColor = Color.Transparent;
        tglUseFacility.FocusBackColor = Color.FromArgb(202, 167, 243);
        tglUseFacility.FocusBorderColor = Color.FromArgb(92, 53, 142);
        tglUseFacility.Location = new Point(169, 386);
        tglUseFacility.MinimumSize = new Size(20, 10);
        tglUseFacility.Name = "tglUseFacility";
        tglUseFacility.OffBackColor = Color.LightGray;
        tglUseFacility.OnBackColor = Color.FromArgb(92, 53, 142);
        tglUseFacility.Size = new Size(45, 29);
        tglUseFacility.TabIndex = 46;
        tglUseFacility.Text = "toggleButton1";
        tglUseFacility.ToggleColor = Color.White;
        tglUseFacility.UseVisualStyleBackColor = false;
        // 
        // FrmVarietyAdd
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(544, 427);
        Controls.Add(tglUseFacility);
        Controls.Add(label3);
        Controls.Add(cboGrower);
        Controls.Add(label2);
        Controls.Add(txbTrademark);
        Controls.Add(txbPatentLegend);
        Controls.Add(txbShortName);
        Controls.Add(cboCrop);
        Controls.Add(cboColor);
        Controls.Add(cboActive);
        Controls.Add(btnAceptar);
        Controls.Add(btnCancelar);
        Controls.Add(txbId);
        Controls.Add(txbNameComercial);
        Controls.Add(txbNameScientis);
        Controls.Add(lblTitulo);
        Controls.Add(lblId);
        Controls.Add(lblActivo);
        Controls.Add(lblObliCom);
        Controls.Add(lblObliColor);
        Controls.Add(lblObliCrop);
        Controls.Add(lblTrademark);
        Controls.Add(lblPatentLegend);
        Controls.Add(lblShortName);
        Controls.Add(lblCrop);
        Controls.Add(lblColor);
        Controls.Add(lblNameComercial);
        Controls.Add(lblNameScientis);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Icon = (Icon)resources.GetObject("$this.Icon");
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "FrmVarietyAdd";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Añadir variedad";
        Load += FrmVarietyAdd_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    public Label lblTitulo;
        private Label lblNameScientis;
        public TextBox txbNameScientis;
        private Label lblNameComercial;
        public TextBox txbNameComercial;
        public TextBox txbId;
        private Label lblId;
        private Button btnCancelar;
        private Button btnAceptar;
        private Label lblActivo;
        public ComboBox cboActive;
        private Label lblObliCom;
        public ComboBox cboColor;
        private Label lblColor;
        public ComboBox cboCrop;
        private Label lblCrop;
        private Label lblObliColor;
        private Label lblObliCrop;
        public TextBox txbShortName;
        private Label lblShortName;
        public TextBox txbPatentLegend;
        private Label lblPatentLegend;
        public TextBox txbTrademark;
        private Label lblTrademark;
    public ComboBox cboGrower;
    private Label label2;
    private Label label3;
    public Cuadro_de_herramientas.ToggleButton tglUseFacility;
}
