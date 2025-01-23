namespace SisUvex.Catalogos.AgenciaAduanal
{
    partial class FrmAgenciaAduanalAñadir
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAgenciaAduanalAñadir));
            lblTitulo = new Label();
            lblNombre = new Label();
            txbNombre = new TextBox();
            txbId = new TextBox();
            lblId = new Label();
            btnCancelar = new Button();
            btnAceptar = new Button();
            lblActivo = new Label();
            cboActivo = new ComboBox();
            lblObliCom = new Label();
            lblRFC = new Label();
            txbCiudad = new TextBox();
            lblCiudad = new Label();
            txbDireccion = new TextBox();
            lblDireccion = new Label();
            txbRFC = new TextBox();
            lblPais = new Label();
            cboPais = new ComboBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Arial Black", 16F);
            lblTitulo.Location = new Point(9, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(301, 31);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Añadir agencia aduanal";
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
            txbNombre.Size = new Size(486, 29);
            txbNombre.TabIndex = 2;
            // 
            // txbId
            // 
            txbId.Enabled = false;
            txbId.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbId.Location = new Point(529, 12);
            txbId.Name = "txbId";
            txbId.Size = new Size(46, 29);
            txbId.TabIndex = 1;
            txbId.TextAlign = HorizontalAlignment.Center;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 12F);
            lblId.Location = new Point(501, 15);
            lblId.Name = "lblId";
            lblId.Size = new Size(26, 21);
            lblId.TabIndex = 6;
            lblId.Text = "Id:";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(500, 231);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 29);
            btnCancelar.TabIndex = 8;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(419, 231);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 29);
            btnAceptar.TabIndex = 7;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // lblActivo
            // 
            lblActivo.AutoSize = true;
            lblActivo.Font = new Font("Segoe UI", 12F);
            lblActivo.Location = new Point(392, 15);
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
            cboActivo.Location = new Point(448, 12);
            cboActivo.Name = "cboActivo";
            cboActivo.Size = new Size(46, 29);
            cboActivo.TabIndex = 0;
            // 
            // lblObliCom
            // 
            lblObliCom.AutoSize = true;
            lblObliCom.ForeColor = Color.Crimson;
            lblObliCom.Location = new Point(572, 55);
            lblObliCom.Name = "lblObliCom";
            lblObliCom.Size = new Size(12, 15);
            lblObliCom.TabIndex = 13;
            lblObliCom.Text = "*";
            // 
            // lblRFC
            // 
            lblRFC.AutoSize = true;
            lblRFC.Font = new Font("Segoe UI", 12F);
            lblRFC.Location = new Point(12, 199);
            lblRFC.Name = "lblRFC";
            lblRFC.Size = new Size(41, 21);
            lblRFC.TabIndex = 33;
            lblRFC.Text = "RFC:";
            // 
            // txbCiudad
            // 
            txbCiudad.Font = new Font("Segoe UI", 12F);
            txbCiudad.Location = new Point(89, 126);
            txbCiudad.MaxLength = 50;
            txbCiudad.Name = "txbCiudad";
            txbCiudad.Size = new Size(486, 29);
            txbCiudad.TabIndex = 4;
            // 
            // lblCiudad
            // 
            lblCiudad.AutoSize = true;
            lblCiudad.Font = new Font("Segoe UI", 12F);
            lblCiudad.Location = new Point(12, 129);
            lblCiudad.Name = "lblCiudad";
            lblCiudad.Size = new Size(62, 21);
            lblCiudad.TabIndex = 31;
            lblCiudad.Text = "Ciudad:";
            // 
            // txbDireccion
            // 
            txbDireccion.Font = new Font("Segoe UI", 12F);
            txbDireccion.Location = new Point(89, 161);
            txbDireccion.MaxLength = 100;
            txbDireccion.Name = "txbDireccion";
            txbDireccion.Size = new Size(486, 29);
            txbDireccion.TabIndex = 5;
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Font = new Font("Segoe UI", 12F);
            lblDireccion.Location = new Point(13, 164);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(78, 21);
            lblDireccion.TabIndex = 30;
            lblDireccion.Text = "Direccion:";
            // 
            // txbRFC
            // 
            txbRFC.Font = new Font("Segoe UI", 12F);
            txbRFC.Location = new Point(89, 196);
            txbRFC.MaxLength = 15;
            txbRFC.Name = "txbRFC";
            txbRFC.Size = new Size(486, 29);
            txbRFC.TabIndex = 6;
            // 
            // lblPais
            // 
            lblPais.AutoSize = true;
            lblPais.Font = new Font("Segoe UI", 12F);
            lblPais.Location = new Point(13, 94);
            lblPais.Name = "lblPais";
            lblPais.Size = new Size(40, 21);
            lblPais.TabIndex = 35;
            lblPais.Text = "País:";
            // 
            // cboPais
            // 
            cboPais.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPais.Font = new Font("Segoe UI", 12F);
            cboPais.FormattingEnabled = true;
            cboPais.Items.AddRange(new object[] { "MX", "US" });
            cboPais.Location = new Point(89, 91);
            cboPais.Name = "cboPais";
            cboPais.Size = new Size(67, 29);
            cboPais.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Crimson;
            label1.Location = new Point(153, 91);
            label1.Name = "label1";
            label1.Size = new Size(12, 15);
            label1.TabIndex = 37;
            label1.Text = "*";
            // 
            // FrmAgenciaAduanalAñadir
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(587, 270);
            Controls.Add(cboPais);
            Controls.Add(lblPais);
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
            Controls.Add(lblObliCom);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FrmAgenciaAduanalAñadir";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Añadir agencia aduanal";
            FormClosing += FrmAgenciaAduanalAñadir_FormClosing;
            Load += FrmAgenciaAduanalAñadir_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblNombre;
        private Label lblId;
        private Button btnCancelar;
        private Button btnAceptar;
        private Label lblPais;
        private Label lblActivo;
        public Label lblTitulo;
        public TextBox txbNombre;
        public TextBox txbId;
        public ComboBox cboActivo;
        private Label lblObliCom;
        private Label lblRFC;
        public TextBox txbCiudad;
        private Label lblCiudad;
        public TextBox txbDireccion;
        private Label lblDireccion;
        public TextBox txbRFC;
        public ComboBox cboPais;
        private Label label1;
    }
}