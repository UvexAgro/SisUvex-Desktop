namespace SisUvex.Catalogos.TransportLine
{
    partial class FrmTransportLineAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTransportLineAdd));
            lblRFC = new Label();
            txbSCAAT = new TextBox();
            lblSCAAT = new Label();
            txbSCAC = new TextBox();
            lblSCAC = new Label();
            lblTelefono = new Label();
            txbPhoneNumber = new TextBox();
            txbRFC = new TextBox();
            lblCiudad = new Label();
            txbCity = new TextBox();
            txbAddress = new TextBox();
            lblDireccion = new Label();
            cboActive = new ComboBox();
            btnAccept = new Button();
            btnCancel = new Button();
            txbId = new TextBox();
            txbName = new TextBox();
            lblNombre = new Label();
            lblTitle = new Label();
            lblId = new Label();
            lblActivo = new Label();
            lblObliCom = new Label();
            SuspendLayout();
            // 
            // lblRFC
            // 
            lblRFC.AutoSize = true;
            lblRFC.Font = new Font("Segoe UI", 12F);
            lblRFC.Location = new Point(15, 163);
            lblRFC.Name = "lblRFC";
            lblRFC.Size = new Size(41, 21);
            lblRFC.TabIndex = 47;
            lblRFC.Text = "RFC:";
            // 
            // txbSCAAT
            // 
            txbSCAAT.Font = new Font("Segoe UI", 12F);
            txbSCAAT.Location = new Point(447, 233);
            txbSCAAT.MaxLength = 4;
            txbSCAAT.Name = "txbSCAAT";
            txbSCAAT.Size = new Size(131, 29);
            txbSCAAT.TabIndex = 37;
            // 
            // lblSCAAT
            // 
            lblSCAAT.AutoSize = true;
            lblSCAAT.Font = new Font("Segoe UI", 12F);
            lblSCAAT.Location = new Point(370, 236);
            lblSCAAT.Name = "lblSCAAT";
            lblSCAAT.Size = new Size(59, 21);
            lblSCAAT.TabIndex = 46;
            lblSCAAT.Text = "SCAAT:";
            // 
            // txbSCAC
            // 
            txbSCAC.Font = new Font("Segoe UI", 12F);
            txbSCAC.Location = new Point(92, 230);
            txbSCAC.MaxLength = 4;
            txbSCAC.Name = "txbSCAC";
            txbSCAC.Size = new Size(129, 29);
            txbSCAC.TabIndex = 36;
            // 
            // lblSCAC
            // 
            lblSCAC.AutoSize = true;
            lblSCAC.Font = new Font("Segoe UI", 12F);
            lblSCAC.Location = new Point(15, 233);
            lblSCAC.Name = "lblSCAC";
            lblSCAC.Size = new Size(52, 21);
            lblSCAC.TabIndex = 45;
            lblSCAC.Text = "SCAC:";
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Font = new Font("Segoe UI", 12F);
            lblTelefono.Location = new Point(15, 198);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(71, 21);
            lblTelefono.TabIndex = 44;
            lblTelefono.Text = "Telefono:";
            // 
            // txbPhoneNumber
            // 
            txbPhoneNumber.Font = new Font("Segoe UI", 12F);
            txbPhoneNumber.Location = new Point(92, 195);
            txbPhoneNumber.MaxLength = 13;
            txbPhoneNumber.Name = "txbPhoneNumber";
            txbPhoneNumber.Size = new Size(486, 29);
            txbPhoneNumber.TabIndex = 35;
            // 
            // txbRFC
            // 
            txbRFC.Font = new Font("Segoe UI", 12F);
            txbRFC.Location = new Point(92, 160);
            txbRFC.MaxLength = 15;
            txbRFC.Name = "txbRFC";
            txbRFC.Size = new Size(486, 29);
            txbRFC.TabIndex = 33;
            // 
            // lblCiudad
            // 
            lblCiudad.AutoSize = true;
            lblCiudad.Font = new Font("Segoe UI", 12F);
            lblCiudad.Location = new Point(15, 128);
            lblCiudad.Name = "lblCiudad";
            lblCiudad.Size = new Size(62, 21);
            lblCiudad.TabIndex = 43;
            lblCiudad.Text = "Ciudad:";
            // 
            // txbCity
            // 
            txbCity.Font = new Font("Segoe UI", 12F);
            txbCity.Location = new Point(92, 125);
            txbCity.MaxLength = 50;
            txbCity.Name = "txbCity";
            txbCity.Size = new Size(486, 29);
            txbCity.TabIndex = 32;
            // 
            // txbAddress
            // 
            txbAddress.Font = new Font("Segoe UI", 12F);
            txbAddress.Location = new Point(92, 90);
            txbAddress.MaxLength = 100;
            txbAddress.Name = "txbAddress";
            txbAddress.Size = new Size(486, 29);
            txbAddress.TabIndex = 31;
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Font = new Font("Segoe UI", 12F);
            lblDireccion.Location = new Point(15, 93);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(78, 21);
            lblDireccion.TabIndex = 42;
            lblDireccion.Text = "Direccion:";
            // 
            // cboActive
            // 
            cboActive.DropDownStyle = ComboBoxStyle.DropDownList;
            cboActive.Font = new Font("Segoe UI", 12F);
            cboActive.FormattingEnabled = true;
            cboActive.Items.AddRange(new object[] { "No", "Sí", "DL" });
            cboActive.Location = new Point(451, 9);
            cboActive.Name = "cboActive";
            cboActive.Size = new Size(46, 29);
            cboActive.TabIndex = 27;
            // 
            // btnAccept
            // 
            btnAccept.Location = new Point(422, 268);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(75, 29);
            btnAccept.TabIndex = 38;
            btnAccept.Text = "Aceptar";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(503, 268);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 29);
            btnCancel.TabIndex = 40;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // txbId
            // 
            txbId.Enabled = false;
            txbId.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbId.Location = new Point(532, 9);
            txbId.Name = "txbId";
            txbId.Size = new Size(46, 29);
            txbId.TabIndex = 29;
            txbId.TextAlign = HorizontalAlignment.Center;
            // 
            // txbName
            // 
            txbName.Font = new Font("Segoe UI", 12F);
            txbName.Location = new Point(92, 55);
            txbName.MaxLength = 50;
            txbName.Name = "txbName";
            txbName.Size = new Size(486, 29);
            txbName.TabIndex = 30;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 12F);
            lblNombre.Location = new Point(15, 58);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(71, 21);
            lblNombre.TabIndex = 28;
            lblNombre.Text = "Nombre:";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial Black", 16F);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(332, 31);
            lblTitle.TabIndex = 26;
            lblTitle.Text = "Añadir línea de transporte";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 12F);
            lblId.Location = new Point(504, 12);
            lblId.Name = "lblId";
            lblId.Size = new Size(26, 21);
            lblId.TabIndex = 34;
            lblId.Text = "Id:";
            // 
            // lblActivo
            // 
            lblActivo.AutoSize = true;
            lblActivo.Font = new Font("Segoe UI", 12F);
            lblActivo.Location = new Point(395, 12);
            lblActivo.Name = "lblActivo";
            lblActivo.Size = new Size(60, 21);
            lblActivo.TabIndex = 39;
            lblActivo.Text = "Activo: ";
            // 
            // lblObliCom
            // 
            lblObliCom.AutoSize = true;
            lblObliCom.ForeColor = Color.Crimson;
            lblObliCom.Location = new Point(83, 55);
            lblObliCom.Name = "lblObliCom";
            lblObliCom.Size = new Size(12, 15);
            lblObliCom.TabIndex = 41;
            lblObliCom.Text = "*";
            // 
            // FrmTransportLineAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(593, 309);
            Controls.Add(lblRFC);
            Controls.Add(txbSCAAT);
            Controls.Add(lblSCAAT);
            Controls.Add(txbSCAC);
            Controls.Add(lblSCAC);
            Controls.Add(lblTelefono);
            Controls.Add(txbPhoneNumber);
            Controls.Add(txbRFC);
            Controls.Add(lblCiudad);
            Controls.Add(txbCity);
            Controls.Add(txbAddress);
            Controls.Add(lblDireccion);
            Controls.Add(cboActive);
            Controls.Add(btnAccept);
            Controls.Add(btnCancel);
            Controls.Add(txbId);
            Controls.Add(txbName);
            Controls.Add(lblNombre);
            Controls.Add(lblTitle);
            Controls.Add(lblId);
            Controls.Add(lblActivo);
            Controls.Add(lblObliCom);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmTransportLineAdd";
            Text = "Añadir línea de transporte";
            Load += FrmTransportLineAdd_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblRFC;
        public TextBox txbSCAAT;
        private Label lblSCAAT;
        public TextBox txbSCAC;
        private Label lblSCAC;
        private Label lblTelefono;
        public TextBox txbPhoneNumber;
        public TextBox txbRFC;
        private Label lblCiudad;
        public TextBox txbCity;
        public TextBox txbAddress;
        private Label lblDireccion;
        public ComboBox cboActive;
        private Button btnAccept;
        private Button btnCancel;
        public TextBox txbId;
        public TextBox txbName;
        private Label lblNombre;
        public Label lblTitle;
        private Label lblId;
        private Label lblActivo;
        private Label lblObliCom;
    }
}