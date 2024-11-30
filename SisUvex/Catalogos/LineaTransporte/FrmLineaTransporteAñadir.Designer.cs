

namespace SisUvex.Catalogos.LineaTransporte
{
    partial class FrmLineaTransporteAñadir
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
            lblObliCom = new Label();
            lblDireccion = new Label();
            txbDireccion = new TextBox();
            txbCiudad = new TextBox();
            lblCiudad = new Label();
            txbRFC = new TextBox();
            txbTelefono = new TextBox();
            lblTelefono = new Label();
            lblSCAC = new Label();
            txbSCAC = new TextBox();
            txbSCAAT = new TextBox();
            lblSCAAT = new Label();
            lblRFC = new Label();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Arial Black", 16F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitulo.Location = new Point(9, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(293, 31);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Añadir lineaTransporte";
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
            txbNombre.Size = new Size(486, 29);
            txbNombre.TabIndex = 1;
            // 
            // txbId
            // 
            txbId.Enabled = false;
            txbId.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txbId.Location = new Point(514, 9);
            txbId.Name = "txbId";
            txbId.Size = new Size(46, 29);
            txbId.TabIndex = 10;
            txbId.TextAlign = HorizontalAlignment.Center;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblId.Location = new Point(486, 12);
            lblId.Name = "lblId";
            lblId.Size = new Size(26, 21);
            lblId.TabIndex = 6;
            lblId.Text = "Id:";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(500, 268);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 29);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(419, 268);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 29);
            btnAceptar.TabIndex = 8;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // lblActivo
            // 
            lblActivo.AutoSize = true;
            lblActivo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblActivo.Location = new Point(377, 12);
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
            cboActivo.Items.AddRange(new object[] { "No", "Sí", "DL" });
            cboActivo.Location = new Point(433, 9);
            cboActivo.Name = "cboActivo";
            cboActivo.Size = new Size(46, 29);
            cboActivo.TabIndex = 11;
            // 
            // lblObliCom
            // 
            lblObliCom.AutoSize = true;
            lblObliCom.ForeColor = Color.Crimson;
            lblObliCom.Location = new Point(80, 55);
            lblObliCom.Name = "lblObliCom";
            lblObliCom.Size = new Size(12, 15);
            lblObliCom.TabIndex = 13;
            lblObliCom.Text = "*";
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblDireccion.Location = new Point(12, 93);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(78, 21);
            lblDireccion.TabIndex = 14;
            lblDireccion.Text = "Direccion:";
            // 
            // txbDireccion
            // 
            txbDireccion.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbDireccion.Location = new Point(89, 90);
            txbDireccion.MaxLength = 100;
            txbDireccion.Name = "txbDireccion";
            txbDireccion.Size = new Size(486, 29);
            txbDireccion.TabIndex = 2;
            // 
            // txbCiudad
            // 
            txbCiudad.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbCiudad.Location = new Point(89, 125);
            txbCiudad.MaxLength = 50;
            txbCiudad.Name = "txbCiudad";
            txbCiudad.Size = new Size(486, 29);
            txbCiudad.TabIndex = 3;
            // 
            // lblCiudad
            // 
            lblCiudad.AutoSize = true;
            lblCiudad.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblCiudad.Location = new Point(12, 128);
            lblCiudad.Name = "lblCiudad";
            lblCiudad.Size = new Size(62, 21);
            lblCiudad.TabIndex = 17;
            lblCiudad.Text = "Ciudad:";
            // 
            // txbRFC
            // 
            txbRFC.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbRFC.Location = new Point(89, 160);
            txbRFC.MaxLength = 15;
            txbRFC.Name = "txbRFC";
            txbRFC.Size = new Size(486, 29);
            txbRFC.TabIndex = 4;
            // 
            // txbTelefono
            // 
            txbTelefono.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbTelefono.Location = new Point(89, 195);
            txbTelefono.MaxLength = 13;
            txbTelefono.Name = "txbTelefono";
            txbTelefono.Size = new Size(486, 29);
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
            lblTelefono.TabIndex = 21;
            lblTelefono.Text = "Telefono:";
            // 
            // lblSCAC
            // 
            lblSCAC.AutoSize = true;
            lblSCAC.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblSCAC.Location = new Point(12, 233);
            lblSCAC.Name = "lblSCAC";
            lblSCAC.Size = new Size(52, 21);
            lblSCAC.TabIndex = 22;
            lblSCAC.Text = "SCAC:";
            // 
            // txbSCAC
            // 
            txbSCAC.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbSCAC.Location = new Point(89, 230);
            txbSCAC.MaxLength = 4;
            txbSCAC.Name = "txbSCAC";
            txbSCAC.Size = new Size(129, 29);
            txbSCAC.TabIndex = 6;
            // 
            // txbSCAAT
            // 
            txbSCAAT.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbSCAAT.Location = new Point(444, 233);
            txbSCAAT.MaxLength = 4;
            txbSCAAT.Name = "txbSCAAT";
            txbSCAAT.Size = new Size(131, 29);
            txbSCAAT.TabIndex = 7;
            // 
            // lblSCAAT
            // 
            lblSCAAT.AutoSize = true;
            lblSCAAT.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblSCAAT.Location = new Point(367, 236);
            lblSCAAT.Name = "lblSCAAT";
            lblSCAAT.Size = new Size(59, 21);
            lblSCAAT.TabIndex = 24;
            lblSCAAT.Text = "SCAAT:";
            // 
            // lblRFC
            // 
            lblRFC.AutoSize = true;
            lblRFC.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblRFC.Location = new Point(12, 163);
            lblRFC.Name = "lblRFC";
            lblRFC.Size = new Size(41, 21);
            lblRFC.TabIndex = 25;
            lblRFC.Text = "RFC:";
            // 
            // FrmLineaTransporteAñadir
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(587, 311);
            Controls.Add(lblRFC);
            Controls.Add(txbSCAAT);
            Controls.Add(lblSCAAT);
            Controls.Add(txbSCAC);
            Controls.Add(lblSCAC);
            Controls.Add(lblTelefono);
            Controls.Add(txbTelefono);
            Controls.Add(txbRFC);
            Controls.Add(lblCiudad);
            Controls.Add(txbCiudad);
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
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmLineaTransporteAñadir";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Añadir lineaTransporte";
            FormClosing += FrmLineaTransporteAñadir_FormClosing;
            Load += FrmLineaTransporteAñadir_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblNombre;
        private Label lblId;
        private Button btnCancelar;
        private Button btnAceptar;
        private TextBox textBox1;
        private Label label1;
        private Label lblActivo;
        public Label lblTitulo;
        public TextBox txbNombre;
        public TextBox txbId;
        public ComboBox cboActivo;
        private Label lblObliCom;
        private Label lblDireccion;
        public TextBox txbDireccion;
        public TextBox txbCiudad;
        private Label lblCiudad;
        public TextBox txbRFC;
        public TextBox txbTelefono;
        private Label lblTelefono;
        private Label lblSCAC;
        public TextBox txbSCAC;
        public TextBox txbSCAAT;
        private Label lblSCAAT;
        private Label lblRFC;
    }
}