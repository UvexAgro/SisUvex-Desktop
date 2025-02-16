
using System.Windows.Forms;

namespace SisUvex.Catalogos.Chofer
{
    partial class FrmChoferAñadir
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChoferAñadir));
            lblTitulo = new Label();
            lblLinea = new Label();
            txbId = new TextBox();
            lblId = new Label();
            btnCancelar = new Button();
            btnAceptar = new Button();
            btnTodoLinea = new Button();
            btnBuscarLinea = new Button();
            txbIdLinea = new TextBox();
            cboLinea = new ComboBox();
            lblObliLinea = new Label();
            lblObliId = new Label();
            cboActivo = new ComboBox();
            lblActivo = new Label();
            label2 = new Label();
            txbNombre = new TextBox();
            lblNombre = new Label();
            label1 = new Label();
            label3 = new Label();
            lblApellido = new Label();
            txbApellidos = new TextBox();
            lblLicencia = new Label();
            txbLicencia = new TextBox();
            lblVisa = new Label();
            txbVisa = new TextBox();
            spnFecha = new MaskedTextBox();
            lblDíaMesAÑo = new Label();
            lblFecha = new Label();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Arial Black", 16F);
            lblTitulo.Location = new Point(12, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(179, 31);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Añadir chofer";
            // 
            // lblLinea
            // 
            lblLinea.AutoSize = true;
            lblLinea.Font = new Font("Segoe UI", 12F);
            lblLinea.Location = new Point(12, 51);
            lblLinea.Name = "lblLinea";
            lblLinea.Size = new Size(147, 21);
            lblLinea.TabIndex = 1;
            lblLinea.Text = "Línea de transporte:";
            // 
            // txbId
            // 
            txbId.Enabled = false;
            txbId.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbId.Location = new Point(572, 12);
            txbId.Name = "txbId";
            txbId.Size = new Size(46, 29);
            txbId.TabIndex = 1;
            txbId.TextAlign = HorizontalAlignment.Center;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 12F);
            lblId.Location = new Point(540, 15);
            lblId.Name = "lblId";
            lblId.Size = new Size(26, 21);
            lblId.TabIndex = 6;
            lblId.Text = "Id:";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(545, 256);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 29);
            btnCancelar.TabIndex = 12;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(464, 256);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 29);
            btnAceptar.TabIndex = 11;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnTodoLinea
            // 
            btnTodoLinea.Location = new Point(564, 49);
            btnTodoLinea.Name = "btnTodoLinea";
            btnTodoLinea.Size = new Size(57, 29);
            btnTodoLinea.TabIndex = 5;
            btnTodoLinea.Text = "Activos";
            btnTodoLinea.UseVisualStyleBackColor = true;
            btnTodoLinea.Click += btnTodoLinea_Click;
            // 
            // btnBuscarLinea
            // 
            btnBuscarLinea.Location = new Point(501, 49);
            btnBuscarLinea.Name = "btnBuscarLinea";
            btnBuscarLinea.Size = new Size(57, 29);
            btnBuscarLinea.TabIndex = 4;
            btnBuscarLinea.Text = "Buscar";
            btnBuscarLinea.UseVisualStyleBackColor = true;
            btnBuscarLinea.Click += btnBuscarLinea_Click;
            // 
            // txbIdLinea
            // 
            txbIdLinea.Enabled = false;
            txbIdLinea.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbIdLinea.Location = new Point(165, 48);
            txbIdLinea.Name = "txbIdLinea";
            txbIdLinea.Size = new Size(46, 29);
            txbIdLinea.TabIndex = 2;
            txbIdLinea.TextAlign = HorizontalAlignment.Center;
            // 
            // cboLinea
            // 
            cboLinea.Font = new Font("Segoe UI", 12F);
            cboLinea.FormattingEnabled = true;
            cboLinea.ItemHeight = 21;
            cboLinea.Location = new Point(217, 48);
            cboLinea.Name = "cboLinea";
            cboLinea.Size = new Size(278, 29);
            cboLinea.TabIndex = 3;
            cboLinea.TextChanged += cboLinea_TextChanged;
            cboLinea.MouseClick += cboLinea_MouseClick;
            // 
            // lblObliLinea
            // 
            lblObliLinea.AutoSize = true;
            lblObliLinea.ForeColor = Color.Crimson;
            lblObliLinea.Location = new Point(156, 48);
            lblObliLinea.Name = "lblObliLinea";
            lblObliLinea.Size = new Size(12, 15);
            lblObliLinea.TabIndex = 35;
            lblObliLinea.Text = "*";
            // 
            // lblObliId
            // 
            lblObliId.AutoSize = true;
            lblObliId.ForeColor = Color.Crimson;
            lblObliId.Location = new Point(563, 12);
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
            cboActivo.Location = new Point(488, 12);
            cboActivo.Name = "cboActivo";
            cboActivo.Size = new Size(46, 29);
            cboActivo.TabIndex = 0;
            // 
            // lblActivo
            // 
            lblActivo.AutoSize = true;
            lblActivo.Font = new Font("Segoe UI", 12F);
            lblActivo.Location = new Point(426, 15);
            lblActivo.Name = "lblActivo";
            lblActivo.Size = new Size(60, 21);
            lblActivo.TabIndex = 40;
            lblActivo.Text = "Activo: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Crimson;
            label2.Location = new Point(477, 12);
            label2.Name = "label2";
            label2.Size = new Size(12, 15);
            label2.TabIndex = 41;
            label2.Text = "*";
            // 
            // txbNombre
            // 
            txbNombre.Font = new Font("Segoe UI", 12F);
            txbNombre.Location = new Point(89, 83);
            txbNombre.MaxLength = 30;
            txbNombre.Name = "txbNombre";
            txbNombre.Size = new Size(406, 29);
            txbNombre.TabIndex = 6;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 12F);
            lblNombre.Location = new Point(12, 86);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(71, 21);
            lblNombre.TabIndex = 43;
            lblNombre.Text = "Nombre:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Crimson;
            label1.Location = new Point(81, 83);
            label1.Name = "label1";
            label1.Size = new Size(12, 15);
            label1.TabIndex = 44;
            label1.Text = "*";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Crimson;
            label3.Location = new Point(81, 118);
            label3.Name = "label3";
            label3.Size = new Size(12, 15);
            label3.TabIndex = 47;
            label3.Text = "*";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Font = new Font("Segoe UI", 12F);
            lblApellido.Location = new Point(6, 121);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(77, 21);
            lblApellido.TabIndex = 46;
            lblApellido.Text = "Apellidos:";
            // 
            // txbApellidos
            // 
            txbApellidos.Font = new Font("Segoe UI", 12F);
            txbApellidos.Location = new Point(89, 118);
            txbApellidos.MaxLength = 30;
            txbApellidos.Name = "txbApellidos";
            txbApellidos.Size = new Size(406, 29);
            txbApellidos.TabIndex = 7;
            // 
            // lblLicencia
            // 
            lblLicencia.AutoSize = true;
            lblLicencia.Font = new Font("Segoe UI", 12F);
            lblLicencia.Location = new Point(15, 156);
            lblLicencia.Name = "lblLicencia";
            lblLicencia.Size = new Size(68, 21);
            lblLicencia.TabIndex = 49;
            lblLicencia.Text = "Licencia:";
            // 
            // txbLicencia
            // 
            txbLicencia.Font = new Font("Segoe UI", 12F);
            txbLicencia.Location = new Point(89, 153);
            txbLicencia.MaxLength = 20;
            txbLicencia.Name = "txbLicencia";
            txbLicencia.Size = new Size(406, 29);
            txbLicencia.TabIndex = 8;
            // 
            // lblVisa
            // 
            lblVisa.AutoSize = true;
            lblVisa.Font = new Font("Segoe UI", 12F);
            lblVisa.Location = new Point(41, 191);
            lblVisa.Name = "lblVisa";
            lblVisa.Size = new Size(42, 21);
            lblVisa.TabIndex = 52;
            lblVisa.Text = "Visa:";
            // 
            // txbVisa
            // 
            txbVisa.Font = new Font("Segoe UI", 12F);
            txbVisa.Location = new Point(89, 188);
            txbVisa.MaxLength = 30;
            txbVisa.Name = "txbVisa";
            txbVisa.Size = new Size(406, 29);
            txbVisa.TabIndex = 9;
            // 
            // spnFecha
            // 
            spnFecha.Font = new Font("Segoe UI", 12F);
            spnFecha.Location = new Point(170, 223);
            spnFecha.Mask = "00/00/0000";
            spnFecha.Name = "spnFecha";
            spnFecha.Size = new Size(100, 29);
            spnFecha.TabIndex = 10;
            spnFecha.ValidatingType = typeof(DateTime);
            // 
            // lblDíaMesAÑo
            // 
            lblDíaMesAÑo.AutoSize = true;
            lblDíaMesAÑo.Font = new Font("Segoe UI", 12F);
            lblDíaMesAÑo.ForeColor = SystemColors.AppWorkspace;
            lblDíaMesAÑo.Location = new Point(276, 226);
            lblDíaMesAÑo.Name = "lblDíaMesAÑo";
            lblDíaMesAÑo.Size = new Size(98, 21);
            lblDíaMesAÑo.TabIndex = 56;
            lblDíaMesAÑo.Text = "mes/día/año";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Segoe UI", 12F);
            lblFecha.Location = new Point(9, 226);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(155, 21);
            lblFecha.TabIndex = 55;
            lblFecha.Text = "Fecha de nacimiento:";
            // 
            // FrmChoferAñadir
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(637, 297);
            Controls.Add(spnFecha);
            Controls.Add(lblDíaMesAÑo);
            Controls.Add(lblFecha);
            Controls.Add(lblVisa);
            Controls.Add(txbVisa);
            Controls.Add(lblLicencia);
            Controls.Add(txbLicencia);
            Controls.Add(lblApellido);
            Controls.Add(txbApellidos);
            Controls.Add(lblNombre);
            Controls.Add(cboActivo);
            Controls.Add(btnTodoLinea);
            Controls.Add(btnBuscarLinea);
            Controls.Add(txbIdLinea);
            Controls.Add(cboLinea);
            Controls.Add(lblObliLinea);
            Controls.Add(btnAceptar);
            Controls.Add(btnCancelar);
            Controls.Add(txbId);
            Controls.Add(lblTitulo);
            Controls.Add(lblId);
            Controls.Add(lblObliId);
            Controls.Add(txbNombre);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(lblActivo);
            Controls.Add(lblLinea);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FrmChoferAñadir";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Añadir chofer";
            FormClosing += FrmChoferAñadir_FormClosing;
            Load += FrmChoferAñadir_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblLinea;
        private Label lblId;
        private Button btnCancelar;
        private Button btnAceptar;
        public Label lblTitulo;
        public TextBox txbId;
        private Button btnTodoLinea;
        private Button btnBuscarLinea;
        public TextBox txbIdLinea;
        private ComboBox cboLinea;
        private Label lblObliLinea;
        private Label lblObliId;
        public ComboBox cboActivo;
        private Label lblActivo;
        private Label label2;
        private Label lblNombre;
        private Label label1;
        private Label label3;
        private Label lblApellido;
        private Label lblLicencia;
        private Label lblVisa;
        public MaskedTextBox spnFecha;
        private Label lblDíaMesAÑo;
        private Label lblFecha;
        public TextBox txbNombre;
        public TextBox txbApellidos;
        public TextBox txbLicencia;
        public TextBox txbVisa;
    }
}