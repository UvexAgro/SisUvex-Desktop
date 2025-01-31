
using System.Windows.Forms;

namespace SisUvex.Catalogos.Consignatario
{
    partial class FrmConsignatarioAñadir
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
            lblDistribuidor = new Label();
            txbId = new TextBox();
            lblId = new Label();
            btnCancelar = new Button();
            btnAceptar = new Button();
            btnTodoDistribuidor = new Button();
            btnBuscarDistribuidor = new Button();
            txbIdDistribuidor = new TextBox();
            cboDistribuidor = new ComboBox();
            lblObliContratista = new Label();
            lblObliId = new Label();
            cboActivo = new ComboBox();
            lblActivo = new Label();
            label2 = new Label();
            txbTelefono = new TextBox();
            lblTelefono = new Label();
            txbRFC = new TextBox();
            lblRFC = new Label();
            txbCiudad = new TextBox();
            lblCiudad = new Label();
            txbDireccion = new TextBox();
            lblDireccion = new Label();
            txbNombre = new TextBox();
            lblNombre = new Label();
            lblObliNombre = new Label();
            txbPais = new TextBox();
            lblPais = new Label();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Arial Black", 16F);
            lblTitulo.Location = new Point(9, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(267, 31);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Añadir consignatario";
            // 
            // lblDistribuidor
            // 
            lblDistribuidor.AutoSize = true;
            lblDistribuidor.Font = new Font("Segoe UI", 12F);
            lblDistribuidor.Location = new Point(9, 87);
            lblDistribuidor.Name = "lblDistribuidor";
            lblDistribuidor.Size = new Size(96, 21);
            lblDistribuidor.TabIndex = 1;
            lblDistribuidor.Text = "Distribuidor:";
            // 
            // txbId
            // 
            txbId.Enabled = false;
            txbId.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbId.Location = new Point(654, 12);
            txbId.Name = "txbId";
            txbId.Size = new Size(46, 29);
            txbId.TabIndex = 1;
            txbId.TextAlign = HorizontalAlignment.Center;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 12F);
            lblId.Location = new Point(622, 15);
            lblId.Name = "lblId";
            lblId.Size = new Size(26, 21);
            lblId.TabIndex = 6;
            lblId.Text = "Id:";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(627, 297);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 29);
            btnCancelar.TabIndex = 13;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(546, 297);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 29);
            btnAceptar.TabIndex = 12;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnTodoDistribuidor
            // 
            btnTodoDistribuidor.Location = new Point(645, 84);
            btnTodoDistribuidor.Name = "btnTodoDistribuidor";
            btnTodoDistribuidor.Size = new Size(57, 29);
            btnTodoDistribuidor.TabIndex = 6;
            btnTodoDistribuidor.Text = "Activos";
            btnTodoDistribuidor.UseVisualStyleBackColor = true;
            btnTodoDistribuidor.Click += btnTodoDistribuidor_Click;
            // 
            // btnBuscarDistribuidor
            // 
            btnBuscarDistribuidor.Location = new Point(582, 84);
            btnBuscarDistribuidor.Name = "btnBuscarDistribuidor";
            btnBuscarDistribuidor.Size = new Size(57, 29);
            btnBuscarDistribuidor.TabIndex = 5;
            btnBuscarDistribuidor.Text = "Buscar";
            btnBuscarDistribuidor.UseVisualStyleBackColor = true;
            btnBuscarDistribuidor.Click += btnBuscarDistribuidor_Click;
            // 
            // txbIdDistribuidor
            // 
            txbIdDistribuidor.Enabled = false;
            txbIdDistribuidor.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbIdDistribuidor.Location = new Point(111, 84);
            txbIdDistribuidor.Name = "txbIdDistribuidor";
            txbIdDistribuidor.Size = new Size(46, 29);
            txbIdDistribuidor.TabIndex = 3;
            txbIdDistribuidor.TextAlign = HorizontalAlignment.Center;
            // 
            // cboDistribuidor
            // 
            cboDistribuidor.Font = new Font("Segoe UI", 12F);
            cboDistribuidor.FormattingEnabled = true;
            cboDistribuidor.ItemHeight = 21;
            cboDistribuidor.Location = new Point(163, 84);
            cboDistribuidor.MaxLength = 100;
            cboDistribuidor.Name = "cboDistribuidor";
            cboDistribuidor.Size = new Size(413, 29);
            cboDistribuidor.TabIndex = 4;
            cboDistribuidor.TextChanged += cboDistribuidor_TextChanged;
            cboDistribuidor.MouseClick += cboDistribuidor_MouseClick;
            // 
            // lblObliContratista
            // 
            lblObliContratista.AutoSize = true;
            lblObliContratista.ForeColor = Color.Crimson;
            lblObliContratista.Location = new Point(95, 84);
            lblObliContratista.Name = "lblObliContratista";
            lblObliContratista.Size = new Size(12, 15);
            lblObliContratista.TabIndex = 35;
            lblObliContratista.Text = "*";
            // 
            // lblObliId
            // 
            lblObliId.AutoSize = true;
            lblObliId.ForeColor = Color.Crimson;
            lblObliId.Location = new Point(645, 12);
            lblObliId.Name = "lblObliId";
            lblObliId.Size = new Size(12, 15);
            lblObliId.TabIndex = 13;
            lblObliId.Text = "*";
            // 
            // cboActivo
            // 
            cboActivo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboActivo.Font = new Font("Segoe UI", 12F);
            cboActivo.FormattingEnabled = true;
            cboActivo.Items.AddRange(new object[] { "No", "Sí" });
            cboActivo.Location = new Point(570, 12);
            cboActivo.Name = "cboActivo";
            cboActivo.Size = new Size(46, 29);
            cboActivo.TabIndex = 0;
            // 
            // lblActivo
            // 
            lblActivo.AutoSize = true;
            lblActivo.Font = new Font("Segoe UI", 12F);
            lblActivo.Location = new Point(508, 15);
            lblActivo.Name = "lblActivo";
            lblActivo.Size = new Size(60, 21);
            lblActivo.TabIndex = 40;
            lblActivo.Text = "Activo: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Crimson;
            label2.Location = new Point(500, 15);
            label2.Name = "label2";
            label2.Size = new Size(12, 15);
            label2.TabIndex = 41;
            label2.Text = "*";
            // 
            // txbTelefono
            // 
            txbTelefono.Font = new Font("Segoe UI", 12F);
            txbTelefono.Location = new Point(109, 262);
            txbTelefono.MaxLength = 13;
            txbTelefono.Name = "txbTelefono";
            txbTelefono.Size = new Size(268, 29);
            txbTelefono.TabIndex = 11;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Font = new Font("Segoe UI", 12F);
            lblTelefono.Location = new Point(32, 265);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(71, 21);
            lblTelefono.TabIndex = 49;
            lblTelefono.Text = "Telefono:";
            // 
            // txbRFC
            // 
            txbRFC.Font = new Font("Segoe UI", 12F);
            txbRFC.Location = new Point(109, 227);
            txbRFC.MaxLength = 15;
            txbRFC.Name = "txbRFC";
            txbRFC.Size = new Size(268, 29);
            txbRFC.TabIndex = 10;
            // 
            // lblRFC
            // 
            lblRFC.AutoSize = true;
            lblRFC.Font = new Font("Segoe UI", 12F);
            lblRFC.Location = new Point(62, 230);
            lblRFC.Name = "lblRFC";
            lblRFC.Size = new Size(41, 21);
            lblRFC.TabIndex = 48;
            lblRFC.Text = "RFC:";
            // 
            // txbCiudad
            // 
            txbCiudad.Font = new Font("Segoe UI", 12F);
            txbCiudad.Location = new Point(111, 155);
            txbCiudad.MaxLength = 50;
            txbCiudad.Name = "txbCiudad";
            txbCiudad.Size = new Size(471, 29);
            txbCiudad.TabIndex = 8;
            // 
            // lblCiudad
            // 
            lblCiudad.AutoSize = true;
            lblCiudad.Font = new Font("Segoe UI", 12F);
            lblCiudad.Location = new Point(43, 158);
            lblCiudad.Name = "lblCiudad";
            lblCiudad.Size = new Size(62, 21);
            lblCiudad.TabIndex = 47;
            lblCiudad.Text = "Ciudad:";
            // 
            // txbDireccion
            // 
            txbDireccion.Font = new Font("Segoe UI", 12F);
            txbDireccion.Location = new Point(111, 120);
            txbDireccion.MaxLength = 100;
            txbDireccion.Name = "txbDireccion";
            txbDireccion.Size = new Size(591, 29);
            txbDireccion.TabIndex = 7;
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Font = new Font("Segoe UI", 12F);
            lblDireccion.Location = new Point(27, 123);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(78, 21);
            lblDireccion.TabIndex = 46;
            lblDireccion.Text = "Direccion:";
            // 
            // txbNombre
            // 
            txbNombre.Font = new Font("Segoe UI", 12F);
            txbNombre.Location = new Point(109, 49);
            txbNombre.MaxLength = 50;
            txbNombre.Name = "txbNombre";
            txbNombre.Size = new Size(591, 29);
            txbNombre.TabIndex = 2;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 12F);
            lblNombre.Location = new Point(32, 52);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(71, 21);
            lblNombre.TabIndex = 51;
            lblNombre.Text = "Nombre:";
            // 
            // lblObliNombre
            // 
            lblObliNombre.AutoSize = true;
            lblObliNombre.ForeColor = Color.Crimson;
            lblObliNombre.Location = new Point(24, 52);
            lblObliNombre.Name = "lblObliNombre";
            lblObliNombre.Size = new Size(12, 15);
            lblObliNombre.TabIndex = 52;
            lblObliNombre.Text = "*";
            // 
            // txbPais
            // 
            txbPais.Font = new Font("Segoe UI", 12F);
            txbPais.Location = new Point(109, 190);
            txbPais.MaxLength = 15;
            txbPais.Name = "txbPais";
            txbPais.Size = new Size(268, 29);
            txbPais.TabIndex = 9;
            // 
            // lblPais
            // 
            lblPais.AutoSize = true;
            lblPais.Font = new Font("Segoe UI", 12F);
            lblPais.Location = new Point(63, 193);
            lblPais.Name = "lblPais";
            lblPais.Size = new Size(40, 21);
            lblPais.TabIndex = 54;
            lblPais.Text = "País:";
            // 
            // FrmConsignatarioAñadir
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(712, 339);
            Controls.Add(txbPais);
            Controls.Add(lblPais);
            Controls.Add(txbNombre);
            Controls.Add(lblNombre);
            Controls.Add(lblObliNombre);
            Controls.Add(txbTelefono);
            Controls.Add(lblTelefono);
            Controls.Add(txbRFC);
            Controls.Add(lblRFC);
            Controls.Add(txbCiudad);
            Controls.Add(lblCiudad);
            Controls.Add(txbDireccion);
            Controls.Add(lblDireccion);
            Controls.Add(lblActivo);
            Controls.Add(label2);
            Controls.Add(cboActivo);
            Controls.Add(lblDistribuidor);
            Controls.Add(btnTodoDistribuidor);
            Controls.Add(btnBuscarDistribuidor);
            Controls.Add(txbIdDistribuidor);
            Controls.Add(cboDistribuidor);
            Controls.Add(lblObliContratista);
            Controls.Add(btnAceptar);
            Controls.Add(btnCancelar);
            Controls.Add(txbId);
            Controls.Add(lblTitulo);
            Controls.Add(lblId);
            Controls.Add(lblObliId);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmConsignatarioAñadir";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Añadir consignatario";
            FormClosing += FrmConsignatarioAñadir_FormClosing;
            Load += FrmConsignatarioAñadir_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblDistribuidor;
        private Label lblId;
        private Button btnCancelar;
        private Button btnAceptar;
        public Label lblTitulo;
        public TextBox txbId;
        private Button btnTodoDistribuidor;
        private Button btnBuscarDistribuidor;
        public TextBox txbIdDistribuidor;
        private ComboBox cboDistribuidor;
        private Label lblObliContratista;
        private Label lblObliId;
        public ComboBox cboActivo;
        private Label lblActivo;
        private Label label2;
        public TextBox txbTelefono;
        private Label lblTelefono;
        public TextBox txbRFC;
        private Label lblRFC;
        public TextBox txbCiudad;
        private Label lblCiudad;
        public TextBox txbDireccion;
        private Label lblDireccion;
        public TextBox txbNombre;
        private Label lblNombre;
        private Label lblObliNombre;
        public TextBox txbPais;
        private Label lblPais;
    }
}