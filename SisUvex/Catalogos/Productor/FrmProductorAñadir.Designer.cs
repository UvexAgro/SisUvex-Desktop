namespace SisUvex.Catalogos.Productor
{
    partial class FrmProductorAñadir
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProductorAñadir));
            lblTitulo = new Label();
            lblNombre = new Label();
            txbNombre = new TextBox();
            txbId = new TextBox();
            lblId = new Label();
            btnCancelar = new Button();
            btnAceptar = new Button();
            lblActivo = new Label();
            cboActivo = new ComboBox();
            lblDireccion = new Label();
            txbDireccion = new TextBox();
            lblCiudad = new Label();
            txbCiudad = new TextBox();
            lblRFC = new Label();
            txbRFC = new TextBox();
            txbTelefono = new TextBox();
            lblTelefono = new Label();
            lblObliNom = new Label();
            lblGGN = new Label();
            txbGGN = new TextBox();
            lblRegPat = new Label();
            txbRegPat = new TextBox();
            lblLogo = new Label();
            txbLogo = new TextBox();
            lblShortName = new Label();
            txbShortName = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Arial Black", 16F);
            lblTitulo.Location = new Point(9, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(220, 31);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Añadir productor";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 12F);
            lblNombre.Location = new Point(12, 58);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(71, 21);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre:";
            // 
            // txbNombre
            // 
            txbNombre.Font = new Font("Segoe UI", 12F);
            txbNombre.Location = new Point(89, 55);
            txbNombre.MaxLength = 50;
            txbNombre.Name = "txbNombre";
            txbNombre.Size = new Size(528, 29);
            txbNombre.TabIndex = 2;
            // 
            // txbId
            // 
            txbId.Enabled = false;
            txbId.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbId.Location = new Point(571, 12);
            txbId.Name = "txbId";
            txbId.Size = new Size(46, 29);
            txbId.TabIndex = 1;
            txbId.TextAlign = HorizontalAlignment.Center;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 12F);
            lblId.Location = new Point(543, 15);
            lblId.Name = "lblId";
            lblId.Size = new Size(26, 21);
            lblId.TabIndex = 6;
            lblId.Text = "Id:";
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.Location = new Point(542, 367);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 29);
            btnCancelar.TabIndex = 12;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAceptar.Location = new Point(461, 367);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 29);
            btnAceptar.TabIndex = 11;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // lblActivo
            // 
            lblActivo.AutoSize = true;
            lblActivo.Font = new Font("Segoe UI", 12F);
            lblActivo.Location = new Point(434, 15);
            lblActivo.Name = "lblActivo";
            lblActivo.Size = new Size(60, 21);
            lblActivo.TabIndex = 10;
            lblActivo.Text = "Activo: ";
            // 
            // cboActivo
            // 
            cboActivo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboActivo.Font = new Font("Segoe UI", 12F);
            cboActivo.FormattingEnabled = true;
            cboActivo.Items.AddRange(new object[] { "No", "Sí" });
            cboActivo.Location = new Point(490, 12);
            cboActivo.MaxDropDownItems = 9;
            cboActivo.Name = "cboActivo";
            cboActivo.Size = new Size(46, 29);
            cboActivo.TabIndex = 0;
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Font = new Font("Segoe UI", 12F);
            lblDireccion.Location = new Point(12, 128);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(78, 21);
            lblDireccion.TabIndex = 12;
            lblDireccion.Text = "Dirección:";
            // 
            // txbDireccion
            // 
            txbDireccion.Font = new Font("Segoe UI", 12F);
            txbDireccion.Location = new Point(89, 125);
            txbDireccion.MaxLength = 100;
            txbDireccion.Name = "txbDireccion";
            txbDireccion.Size = new Size(528, 29);
            txbDireccion.TabIndex = 4;
            // 
            // lblCiudad
            // 
            lblCiudad.AutoSize = true;
            lblCiudad.Font = new Font("Segoe UI", 12F);
            lblCiudad.Location = new Point(12, 163);
            lblCiudad.Name = "lblCiudad";
            lblCiudad.Size = new Size(62, 21);
            lblCiudad.TabIndex = 14;
            lblCiudad.Text = "Ciudad:";
            // 
            // txbCiudad
            // 
            txbCiudad.Font = new Font("Segoe UI", 12F);
            txbCiudad.Location = new Point(89, 160);
            txbCiudad.MaxLength = 50;
            txbCiudad.Name = "txbCiudad";
            txbCiudad.Size = new Size(528, 29);
            txbCiudad.TabIndex = 5;
            // 
            // lblRFC
            // 
            lblRFC.AutoSize = true;
            lblRFC.Font = new Font("Segoe UI", 12F);
            lblRFC.Location = new Point(12, 198);
            lblRFC.Name = "lblRFC";
            lblRFC.Size = new Size(41, 21);
            lblRFC.TabIndex = 16;
            lblRFC.Text = "RFC:";
            // 
            // txbRFC
            // 
            txbRFC.Font = new Font("Segoe UI", 12F);
            txbRFC.Location = new Point(89, 195);
            txbRFC.MaxLength = 15;
            txbRFC.Name = "txbRFC";
            txbRFC.Size = new Size(248, 29);
            txbRFC.TabIndex = 6;
            // 
            // txbTelefono
            // 
            txbTelefono.Font = new Font("Segoe UI", 12F);
            txbTelefono.Location = new Point(89, 230);
            txbTelefono.MaxLength = 13;
            txbTelefono.Name = "txbTelefono";
            txbTelefono.Size = new Size(248, 29);
            txbTelefono.TabIndex = 7;
            txbTelefono.KeyPress += txbTelefono_KeyPress;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Font = new Font("Segoe UI", 12F);
            lblTelefono.Location = new Point(12, 233);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(71, 21);
            lblTelefono.TabIndex = 19;
            lblTelefono.Text = "Teléfono:";
            // 
            // lblObliNom
            // 
            lblObliNom.AutoSize = true;
            lblObliNom.BackColor = Color.Transparent;
            lblObliNom.ForeColor = Color.Crimson;
            lblObliNom.Location = new Point(80, 55);
            lblObliNom.Name = "lblObliNom";
            lblObliNom.Size = new Size(12, 15);
            lblObliNom.TabIndex = 20;
            lblObliNom.Text = "*";
            // 
            // lblGGN
            // 
            lblGGN.AutoSize = true;
            lblGGN.Font = new Font("Segoe UI", 12F);
            lblGGN.Location = new Point(12, 268);
            lblGGN.Name = "lblGGN";
            lblGGN.Size = new Size(47, 21);
            lblGGN.TabIndex = 22;
            lblGGN.Text = "GGN:";
            // 
            // txbGGN
            // 
            txbGGN.Font = new Font("Segoe UI", 12F);
            txbGGN.Location = new Point(89, 265);
            txbGGN.MaxLength = 13;
            txbGGN.Name = "txbGGN";
            txbGGN.Size = new Size(248, 29);
            txbGGN.TabIndex = 8;
            // 
            // lblRegPat
            // 
            lblRegPat.AutoSize = true;
            lblRegPat.Font = new Font("Segoe UI", 12F);
            lblRegPat.Location = new Point(12, 303);
            lblRegPat.Name = "lblRegPat";
            lblRegPat.Size = new Size(133, 21);
            lblRegPat.TabIndex = 24;
            lblRegPat.Text = "Registro patronal:";
            // 
            // txbRegPat
            // 
            txbRegPat.Font = new Font("Segoe UI", 12F);
            txbRegPat.Location = new Point(151, 300);
            txbRegPat.MaxLength = 30;
            txbRegPat.Name = "txbRegPat";
            txbRegPat.Size = new Size(307, 29);
            txbRegPat.TabIndex = 9;
            // 
            // lblLogo
            // 
            lblLogo.AutoSize = true;
            lblLogo.Font = new Font("Segoe UI", 12F);
            lblLogo.Location = new Point(12, 338);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(48, 21);
            lblLogo.TabIndex = 26;
            lblLogo.Text = "Logo:";
            // 
            // txbLogo
            // 
            txbLogo.Font = new Font("Segoe UI", 12F);
            txbLogo.Location = new Point(89, 335);
            txbLogo.MaxLength = 15;
            txbLogo.Name = "txbLogo";
            txbLogo.Size = new Size(248, 29);
            txbLogo.TabIndex = 10;
            // 
            // lblShortName
            // 
            lblShortName.AutoSize = true;
            lblShortName.Font = new Font("Segoe UI", 12F);
            lblShortName.Location = new Point(12, 93);
            lblShortName.Name = "lblShortName";
            lblShortName.Size = new Size(111, 21);
            lblShortName.TabIndex = 28;
            lblShortName.Text = "Nombre corto:";
            // 
            // txbShortName
            // 
            txbShortName.Font = new Font("Segoe UI", 12F);
            txbShortName.Location = new Point(129, 90);
            txbShortName.MaxLength = 6;
            txbShortName.Name = "txbShortName";
            txbShortName.Size = new Size(121, 29);
            txbShortName.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.Crimson;
            label1.Location = new Point(121, 90);
            label1.Name = "label1";
            label1.Size = new Size(12, 15);
            label1.TabIndex = 29;
            label1.Text = "*";
            // 
            // FrmProductorAñadir
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(629, 408);
            Controls.Add(txbShortName);
            Controls.Add(label1);
            Controls.Add(lblShortName);
            Controls.Add(lblLogo);
            Controls.Add(txbLogo);
            Controls.Add(lblRegPat);
            Controls.Add(txbRegPat);
            Controls.Add(lblGGN);
            Controls.Add(txbGGN);
            Controls.Add(lblTelefono);
            Controls.Add(txbTelefono);
            Controls.Add(txbRFC);
            Controls.Add(lblRFC);
            Controls.Add(txbCiudad);
            Controls.Add(lblCiudad);
            Controls.Add(txbDireccion);
            Controls.Add(lblDireccion);
            Controls.Add(cboActivo);
            Controls.Add(btnAceptar);
            Controls.Add(btnCancelar);
            Controls.Add(txbId);
            Controls.Add(txbNombre);
            Controls.Add(lblNombre);
            Controls.Add(lblTitulo);
            Controls.Add(lblId);
            Controls.Add(lblActivo);
            Controls.Add(lblObliNom);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FrmProductorAñadir";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Añadir productor";
            FormClosing += FrmProductorAñadir_FormClosing;
            Load += FrmProductorAñadir_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblNombre;
        private Label lblId;
        private Button btnCancelar;
        private Button btnAceptar;
        private Label lblDireccion;
        private Label lblActivo;
        public Label lblTitulo;
        public TextBox txbNombre;
        public TextBox txbId;
        public ComboBox cboActivo;
        public TextBox txbDireccion;
        private Label lblCiudad;
        public TextBox txbCiudad;
        private Label lblRFC;
        public TextBox txbRFC;
        public TextBox txbTelefono;
        private Label lblTelefono;
        private Label lblObliNom;
        private Label lblGGN;
        public TextBox txbGGN;
        private Label lblRegPat;
        public TextBox txbRegPat;
        private Label lblLogo;
        public TextBox txbLogo;
        private Label lblShortName;
        public TextBox txbShortName;
        private Label label1;
    }
}