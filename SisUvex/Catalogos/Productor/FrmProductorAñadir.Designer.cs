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
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Arial Black", 16F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitulo.Location = new Point(9, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(220, 31);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Añadir productor";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblNombre.Location = new Point(12, 58);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(71, 21);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre:";
            // 
            // txbNombre
            // 
            txbNombre.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbNombre.Location = new Point(89, 55);
            txbNombre.MaxLength = 50;
            txbNombre.Name = "txbNombre";
            txbNombre.Size = new Size(528, 29);
            txbNombre.TabIndex = 1;
            // 
            // txbId
            // 
            txbId.Enabled = false;
            txbId.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txbId.Location = new Point(571, 12);
            txbId.Name = "txbId";
            txbId.Size = new Size(46, 29);
            txbId.TabIndex = 8;
            txbId.TextAlign = HorizontalAlignment.Center;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblId.Location = new Point(543, 15);
            lblId.Name = "lblId";
            lblId.Size = new Size(26, 21);
            lblId.TabIndex = 6;
            lblId.Text = "Id:";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(542, 230);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 29);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(461, 230);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 29);
            btnAceptar.TabIndex = 6;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // lblActivo
            // 
            lblActivo.AutoSize = true;
            lblActivo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblActivo.Location = new Point(434, 15);
            lblActivo.Name = "lblActivo";
            lblActivo.Size = new Size(60, 21);
            lblActivo.TabIndex = 10;
            lblActivo.Text = "Activo: ";
            // 
            // cboActivo
            // 
            cboActivo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboActivo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cboActivo.FormattingEnabled = true;
            cboActivo.Items.AddRange(new object[] { "No", "Sí" });
            cboActivo.Location = new Point(490, 12);
            cboActivo.MaxDropDownItems = 9;
            cboActivo.Name = "cboActivo";
            cboActivo.Size = new Size(46, 29);
            cboActivo.TabIndex = 8;
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblDireccion.Location = new Point(12, 93);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(78, 21);
            lblDireccion.TabIndex = 12;
            lblDireccion.Text = "Dirección:";
            // 
            // txbDireccion
            // 
            txbDireccion.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbDireccion.Location = new Point(89, 90);
            txbDireccion.MaxLength = 100;
            txbDireccion.Name = "txbDireccion";
            txbDireccion.Size = new Size(528, 29);
            txbDireccion.TabIndex = 2;
            // 
            // lblCiudad
            // 
            lblCiudad.AutoSize = true;
            lblCiudad.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblCiudad.Location = new Point(12, 128);
            lblCiudad.Name = "lblCiudad";
            lblCiudad.Size = new Size(62, 21);
            lblCiudad.TabIndex = 14;
            lblCiudad.Text = "Ciudad:";
            // 
            // txbCiudad
            // 
            txbCiudad.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbCiudad.Location = new Point(89, 125);
            txbCiudad.MaxLength = 50;
            txbCiudad.Name = "txbCiudad";
            txbCiudad.Size = new Size(528, 29);
            txbCiudad.TabIndex = 3;
            // 
            // lblRFC
            // 
            lblRFC.AutoSize = true;
            lblRFC.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblRFC.Location = new Point(12, 163);
            lblRFC.Name = "lblRFC";
            lblRFC.Size = new Size(41, 21);
            lblRFC.TabIndex = 16;
            lblRFC.Text = "RFC:";
            // 
            // txbRFC
            // 
            txbRFC.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbRFC.Location = new Point(89, 160);
            txbRFC.MaxLength = 15;
            txbRFC.Name = "txbRFC";
            txbRFC.Size = new Size(248, 29);
            txbRFC.TabIndex = 4;
            // 
            // txbTelefono
            // 
            txbTelefono.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbTelefono.Location = new Point(89, 195);
            txbTelefono.MaxLength = 13;
            txbTelefono.Name = "txbTelefono";
            txbTelefono.Size = new Size(248, 29);
            txbTelefono.TabIndex = 5;
            txbTelefono.KeyPress += txbTelefono_KeyPress;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblTelefono.Location = new Point(12, 198);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(71, 21);
            lblTelefono.TabIndex = 19;
            lblTelefono.Text = "Teléfono:";
            // 
            // lblObliNom
            // 
            lblObliNom.AutoSize = true;
            lblObliNom.ForeColor = Color.Crimson;
            lblObliNom.Location = new Point(615, 55);
            lblObliNom.Name = "lblObliNom";
            lblObliNom.Size = new Size(12, 15);
            lblObliNom.TabIndex = 20;
            lblObliNom.Text = "*";
            // 
            // FrmProductorAñadir
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(629, 270);
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
    }
}