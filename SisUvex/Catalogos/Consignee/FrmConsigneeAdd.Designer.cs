namespace SisUvex.Catalogos.Consignee
{
    internal partial class FrmConsigneeAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsigneeAdd));
            txbName = new TextBox();
            lblNombre = new Label();
            lblObliNombre = new Label();
            lblActivo = new Label();
            label2 = new Label();
            cboActive = new ComboBox();
            btnSearchDistributor = new Button();
            cboDistributor = new ComboBox();
            btnAccept = new Button();
            btnCancel = new Button();
            txbId = new TextBox();
            lblTitle = new Label();
            lblId = new Label();
            lblObliId = new Label();
            label1 = new Label();
            lblDistribuidor = new Label();
            txbTaxId = new TextBox();
            label5 = new Label();
            txbCountry = new TextBox();
            lblPais = new Label();
            txbPhoneNumber = new TextBox();
            lblTelefono = new Label();
            txbCityDistributor = new TextBox();
            lblCiudad = new Label();
            txbAddress = new TextBox();
            lblDireccion = new Label();
            txbRFC = new TextBox();
            lblRFC = new Label();
            chbDistributorRemoved = new CheckBox();
            SuspendLayout();
            // 
            // txbName
            // 
            txbName.Font = new Font("Segoe UI", 12F);
            txbName.Location = new Point(112, 49);
            txbName.MaxLength = 50;
            txbName.Name = "txbName";
            txbName.Size = new Size(591, 29);
            txbName.TabIndex = 56;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 12F);
            lblNombre.Location = new Point(35, 52);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(71, 21);
            lblNombre.TabIndex = 80;
            lblNombre.Text = "Nombre:";
            // 
            // lblObliNombre
            // 
            lblObliNombre.AutoSize = true;
            lblObliNombre.ForeColor = Color.Crimson;
            lblObliNombre.Location = new Point(104, 52);
            lblObliNombre.Name = "lblObliNombre";
            lblObliNombre.Size = new Size(12, 15);
            lblObliNombre.TabIndex = 81;
            lblObliNombre.Text = "*";
            // 
            // lblActivo
            // 
            lblActivo.AutoSize = true;
            lblActivo.Font = new Font("Segoe UI", 12F);
            lblActivo.Location = new Point(511, 15);
            lblActivo.Name = "lblActivo";
            lblActivo.Size = new Size(60, 21);
            lblActivo.TabIndex = 74;
            lblActivo.Text = "Activo: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Crimson;
            label2.Location = new Point(503, 15);
            label2.Name = "label2";
            label2.Size = new Size(12, 15);
            label2.TabIndex = 75;
            label2.Text = "*";
            // 
            // cboActive
            // 
            cboActive.DropDownStyle = ComboBoxStyle.DropDownList;
            cboActive.Font = new Font("Segoe UI", 12F);
            cboActive.FormattingEnabled = true;
            cboActive.Items.AddRange(new object[] { "No", "Sí" });
            cboActive.Location = new Point(573, 12);
            cboActive.Name = "cboActive";
            cboActive.Size = new Size(46, 29);
            cboActive.TabIndex = 72;
            // 
            // btnSearchDistributor
            // 
            btnSearchDistributor.Location = new Point(533, 84);
            btnSearchDistributor.Name = "btnSearchDistributor";
            btnSearchDistributor.Size = new Size(57, 29);
            btnSearchDistributor.TabIndex = 62;
            btnSearchDistributor.Text = "Buscar";
            btnSearchDistributor.UseVisualStyleBackColor = true;
            // 
            // cboDistributor
            // 
            cboDistributor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDistributor.Font = new Font("Segoe UI", 12F);
            cboDistributor.FormattingEnabled = true;
            cboDistributor.ItemHeight = 21;
            cboDistributor.Location = new Point(114, 84);
            cboDistributor.Name = "cboDistributor";
            cboDistributor.Size = new Size(413, 29);
            cboDistributor.TabIndex = 61;
            // 
            // btnAccept
            // 
            btnAccept.Location = new Point(548, 224);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(75, 29);
            btnAccept.TabIndex = 70;
            btnAccept.Text = "Aceptar";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(629, 224);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 29);
            btnCancel.TabIndex = 71;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // txbId
            // 
            txbId.Enabled = false;
            txbId.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbId.Location = new Point(657, 12);
            txbId.Name = "txbId";
            txbId.Size = new Size(46, 29);
            txbId.TabIndex = 59;
            txbId.TextAlign = HorizontalAlignment.Center;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial Black", 16F);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(267, 31);
            lblTitle.TabIndex = 57;
            lblTitle.Text = "Añadir consignatario";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 12F);
            lblId.Location = new Point(625, 15);
            lblId.Name = "lblId";
            lblId.Size = new Size(26, 21);
            lblId.TabIndex = 65;
            lblId.Text = "Id:";
            // 
            // lblObliId
            // 
            lblObliId.AutoSize = true;
            lblObliId.ForeColor = Color.Crimson;
            lblObliId.Location = new Point(648, 12);
            lblObliId.Name = "lblObliId";
            lblObliId.Size = new Size(12, 15);
            lblObliId.TabIndex = 73;
            lblObliId.Text = "*";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Crimson;
            label1.Location = new Point(106, 87);
            label1.Name = "label1";
            label1.Size = new Size(12, 15);
            label1.TabIndex = 83;
            label1.Text = "*";
            // 
            // lblDistribuidor
            // 
            lblDistribuidor.AutoSize = true;
            lblDistribuidor.Font = new Font("Segoe UI", 12F);
            lblDistribuidor.Location = new Point(12, 87);
            lblDistribuidor.Name = "lblDistribuidor";
            lblDistribuidor.Size = new Size(96, 21);
            lblDistribuidor.TabIndex = 58;
            lblDistribuidor.Text = "Distribuidor:";
            // 
            // txbTaxId
            // 
            txbTaxId.Font = new Font("Segoe UI", 12F);
            txbTaxId.Location = new Point(458, 189);
            txbTaxId.MaxLength = 20;
            txbTaxId.Name = "txbTaxId";
            txbTaxId.Size = new Size(246, 29);
            txbTaxId.TabIndex = 112;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(409, 192);
            label5.Name = "label5";
            label5.Size = new Size(51, 21);
            label5.TabIndex = 113;
            label5.Text = "Tax Id:";
            // 
            // txbCountry
            // 
            txbCountry.Font = new Font("Segoe UI", 12F);
            txbCountry.Location = new Point(114, 154);
            txbCountry.MaxLength = 50;
            txbCountry.Name = "txbCountry";
            txbCountry.Size = new Size(246, 29);
            txbCountry.TabIndex = 105;
            // 
            // lblPais
            // 
            lblPais.AutoSize = true;
            lblPais.Font = new Font("Segoe UI", 12F);
            lblPais.Location = new Point(75, 157);
            lblPais.Name = "lblPais";
            lblPais.Size = new Size(40, 21);
            lblPais.TabIndex = 111;
            lblPais.Text = "País:";
            // 
            // txbPhoneNumber
            // 
            txbPhoneNumber.Font = new Font("Segoe UI", 12F);
            txbPhoneNumber.Location = new Point(458, 154);
            txbPhoneNumber.MaxLength = 13;
            txbPhoneNumber.Name = "txbPhoneNumber";
            txbPhoneNumber.Size = new Size(246, 29);
            txbPhoneNumber.TabIndex = 107;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Font = new Font("Segoe UI", 12F);
            lblTelefono.Location = new Point(389, 157);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(71, 21);
            lblTelefono.TabIndex = 110;
            lblTelefono.Text = "Telefono:";
            // 
            // txbCityDistributor
            // 
            txbCityDistributor.Font = new Font("Segoe UI", 12F);
            txbCityDistributor.Location = new Point(114, 189);
            txbCityDistributor.MaxLength = 50;
            txbCityDistributor.Name = "txbCityDistributor";
            txbCityDistributor.Size = new Size(246, 29);
            txbCityDistributor.TabIndex = 106;
            // 
            // lblCiudad
            // 
            lblCiudad.AutoSize = true;
            lblCiudad.Font = new Font("Segoe UI", 12F);
            lblCiudad.Location = new Point(53, 192);
            lblCiudad.Name = "lblCiudad";
            lblCiudad.Size = new Size(62, 21);
            lblCiudad.TabIndex = 109;
            lblCiudad.Text = "Ciudad:";
            // 
            // txbAddress
            // 
            txbAddress.Font = new Font("Segoe UI", 12F);
            txbAddress.Location = new Point(114, 119);
            txbAddress.MaxLength = 100;
            txbAddress.Name = "txbAddress";
            txbAddress.Size = new Size(591, 29);
            txbAddress.TabIndex = 104;
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Font = new Font("Segoe UI", 12F);
            lblDireccion.Location = new Point(37, 122);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(78, 21);
            lblDireccion.TabIndex = 108;
            lblDireccion.Text = "Direccion:";
            // 
            // txbRFC
            // 
            txbRFC.Font = new Font("Segoe UI", 12F);
            txbRFC.Location = new Point(114, 224);
            txbRFC.MaxLength = 15;
            txbRFC.Name = "txbRFC";
            txbRFC.Size = new Size(246, 29);
            txbRFC.TabIndex = 114;
            // 
            // lblRFC
            // 
            lblRFC.AutoSize = true;
            lblRFC.Font = new Font("Segoe UI", 12F);
            lblRFC.Location = new Point(67, 227);
            lblRFC.Name = "lblRFC";
            lblRFC.Size = new Size(41, 21);
            lblRFC.TabIndex = 115;
            lblRFC.Text = "RFC:";
            // 
            // chbDistributorRemoved
            // 
            chbDistributorRemoved.Appearance = Appearance.Button;
            chbDistributorRemoved.BackgroundImage = Properties.Resources.Imagen6;
            chbDistributorRemoved.BackgroundImageLayout = ImageLayout.Stretch;
            chbDistributorRemoved.Font = new Font("Segoe UI", 10F);
            chbDistributorRemoved.Location = new Point(596, 83);
            chbDistributorRemoved.Name = "chbDistributorRemoved";
            chbDistributorRemoved.Size = new Size(43, 31);
            chbDistributorRemoved.TabIndex = 116;
            chbDistributorRemoved.Text = "     ";
            chbDistributorRemoved.UseVisualStyleBackColor = true;
            // 
            // FrmConsigneeAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(714, 265);
            Controls.Add(chbDistributorRemoved);
            Controls.Add(txbRFC);
            Controls.Add(lblRFC);
            Controls.Add(txbTaxId);
            Controls.Add(label5);
            Controls.Add(txbCountry);
            Controls.Add(lblPais);
            Controls.Add(txbPhoneNumber);
            Controls.Add(lblTelefono);
            Controls.Add(txbCityDistributor);
            Controls.Add(lblCiudad);
            Controls.Add(txbAddress);
            Controls.Add(lblDireccion);
            Controls.Add(txbName);
            Controls.Add(lblNombre);
            Controls.Add(lblObliNombre);
            Controls.Add(lblActivo);
            Controls.Add(label2);
            Controls.Add(cboActive);
            Controls.Add(btnSearchDistributor);
            Controls.Add(cboDistributor);
            Controls.Add(btnAccept);
            Controls.Add(btnCancel);
            Controls.Add(txbId);
            Controls.Add(lblTitle);
            Controls.Add(lblId);
            Controls.Add(lblObliId);
            Controls.Add(label1);
            Controls.Add(lblDistribuidor);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmConsigneeAdd";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Consignatario";
            Load += FrmConsigneeAdd_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        public TextBox txbName;
        private Label lblNombre;
        private Label lblObliNombre;
        private Label lblActivo;
        private Label label2;
        public ComboBox cboActive;
        private Button btnSearchDistributor;
        public ComboBox cboDistributor;
        private Button btnAccept;
        private Button btnCancel;
        public TextBox txbId;
        public Label lblTitle;
        private Label lblId;
        private Label lblObliId;
        private Label label1;
        private Label lblDistribuidor;
        public TextBox txbTaxId;
        private Label label5;
        public TextBox txbCountry;
        private Label lblPais;
        public TextBox txbPhoneNumber;
        private Label lblTelefono;
        public TextBox txbCityDistributor;
        private Label lblCiudad;
        public TextBox txbAddress;
        private Label lblDireccion;
        public TextBox txbRFC;
        private Label lblRFC;
        public CheckBox chbDistributorRemoved;
    }
}