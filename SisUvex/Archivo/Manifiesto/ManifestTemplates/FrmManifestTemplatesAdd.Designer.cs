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
            SuspendLayout();
            // 
            // btnAccept
            // 
            btnAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAccept.Location = new Point(297, 390);
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
            btnCancel.Location = new Point(363, 390);
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
            txbId.Location = new Point(390, 30);
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
            label4.Location = new Point(372, 33);
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
            cboActive.Location = new Point(320, 28);
            cboActive.Name = "cboActive";
            cboActive.Size = new Size(46, 23);
            cboActive.TabIndex = 460;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 9F);
            label5.ForeColor = Color.Crimson;
            label5.Location = new Point(311, 25);
            label5.Name = "label5";
            label5.Size = new Size(12, 15);
            label5.TabIndex = 462;
            label5.Text = "*";
            // 
            // lblActivo
            // 
            lblActivo.AutoSize = true;
            lblActivo.Font = new Font("Microsoft Sans Serif", 9F);
            lblActivo.Location = new Point(279, 33);
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
            // FrmManifestTemplatesAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(441, 427);
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
    }
}