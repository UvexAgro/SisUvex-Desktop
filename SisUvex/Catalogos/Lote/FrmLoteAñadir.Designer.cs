
using System.Windows.Forms;

namespace SisUvex.Catalogos.Lote
{
    partial class FrmLoteAñadir
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLoteAñadir));
            lblTitulo = new Label();
            lblNombre = new Label();
            txbNombre = new TextBox();
            lblId = new Label();
            btnCancelar = new Button();
            btnAceptar = new Button();
            lblActivo = new Label();
            cboActivo = new ComboBox();
            lblObliNom = new Label();
            sqlDataAdapter1 = new Microsoft.Data.SqlClient.SqlDataAdapter();
            txbIdVariedad = new TextBox();
            cboVariedad = new ComboBox();
            lblVariedad = new Label();
            btnTodoVariedad = new Button();
            btnBuscarVariedad = new Button();
            txbHectareas = new TextBox();
            lblHectareas = new Label();
            spnFecha = new MaskedTextBox();
            lblFecha = new Label();
            lblDíaMesAÑo = new Label();
            lblObliVar = new Label();
            lblObliHa = new Label();
            lblObliFecha = new Label();
            lblObliAct = new Label();
            lblObliId = new Label();
            spnId = new MaskedTextBox();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Arial Black", 16F);
            lblTitulo.Location = new Point(9, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(147, 31);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Añadir lote";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 12F);
            lblNombre.Location = new Point(12, 61);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(71, 21);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre:";
            // 
            // txbNombre
            // 
            txbNombre.Font = new Font("Segoe UI", 12F);
            txbNombre.Location = new Point(99, 58);
            txbNombre.MaxLength = 20;
            txbNombre.Name = "txbNombre";
            txbNombre.Size = new Size(434, 29);
            txbNombre.TabIndex = 2;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 12F);
            lblId.Location = new Point(570, 15);
            lblId.Name = "lblId";
            lblId.Size = new Size(26, 21);
            lblId.TabIndex = 6;
            lblId.Text = "Id:";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(584, 197);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 29);
            btnCancelar.TabIndex = 10;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(503, 197);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 29);
            btnAceptar.TabIndex = 9;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // lblActivo
            // 
            lblActivo.AutoSize = true;
            lblActivo.Font = new Font("Segoe UI", 12F);
            lblActivo.Location = new Point(451, 15);
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
            cboActivo.Location = new Point(517, 12);
            cboActivo.MaxDropDownItems = 10;
            cboActivo.Name = "cboActivo";
            cboActivo.Size = new Size(46, 29);
            cboActivo.TabIndex = 0;
            // 
            // lblObliNom
            // 
            lblObliNom.AutoSize = true;
            lblObliNom.ForeColor = Color.Crimson;
            lblObliNom.Location = new Point(89, 61);
            lblObliNom.Name = "lblObliNom";
            lblObliNom.Size = new Size(12, 15);
            lblObliNom.TabIndex = 13;
            lblObliNom.Text = "*";
            // 
            // txbIdVariedad
            // 
            txbIdVariedad.Enabled = false;
            txbIdVariedad.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbIdVariedad.Location = new Point(99, 93);
            txbIdVariedad.Name = "txbIdVariedad";
            txbIdVariedad.Size = new Size(46, 29);
            txbIdVariedad.TabIndex = 3;
            txbIdVariedad.TextAlign = HorizontalAlignment.Center;
            // 
            // cboVariedad
            // 
            cboVariedad.Font = new Font("Segoe UI", 12F);
            cboVariedad.FormattingEnabled = true;
            cboVariedad.ItemHeight = 21;
            cboVariedad.Location = new Point(151, 93);
            cboVariedad.MaxDropDownItems = 4;
            cboVariedad.Name = "cboVariedad";
            cboVariedad.Size = new Size(382, 29);
            cboVariedad.TabIndex = 4;
            cboVariedad.TextChanged += cboVariedad_TextChanged;
            cboVariedad.MouseClick += cboVariedad_MouseClick;
            // 
            // lblVariedad
            // 
            lblVariedad.AutoSize = true;
            lblVariedad.Font = new Font("Segoe UI", 12F);
            lblVariedad.Location = new Point(12, 96);
            lblVariedad.Name = "lblVariedad";
            lblVariedad.Size = new Size(74, 21);
            lblVariedad.TabIndex = 28;
            lblVariedad.Text = "Variedad:";
            // 
            // btnTodoVariedad
            // 
            btnTodoVariedad.Location = new Point(602, 93);
            btnTodoVariedad.Name = "btnTodoVariedad";
            btnTodoVariedad.Size = new Size(57, 29);
            btnTodoVariedad.TabIndex = 6;
            btnTodoVariedad.Text = "Activos";
            btnTodoVariedad.UseVisualStyleBackColor = true;
            btnTodoVariedad.Click += btnTodoVariedad_Click;
            // 
            // btnBuscarVariedad
            // 
            btnBuscarVariedad.Location = new Point(539, 93);
            btnBuscarVariedad.Name = "btnBuscarVariedad";
            btnBuscarVariedad.Size = new Size(57, 29);
            btnBuscarVariedad.TabIndex = 5;
            btnBuscarVariedad.Text = "Buscar";
            btnBuscarVariedad.UseVisualStyleBackColor = true;
            btnBuscarVariedad.Click += btnBuscarVariedad_Click;
            // 
            // txbHectareas
            // 
            txbHectareas.Font = new Font("Segoe UI", 12F);
            txbHectareas.Location = new Point(99, 128);
            txbHectareas.MaxLength = 7;
            txbHectareas.Name = "txbHectareas";
            txbHectareas.Size = new Size(139, 29);
            txbHectareas.TabIndex = 7;
            txbHectareas.TextChanged += txbHectareas_TextChanged;
            txbHectareas.KeyPress += txbHectareas_KeyPress;
            // 
            // lblHectareas
            // 
            lblHectareas.AutoSize = true;
            lblHectareas.Font = new Font("Segoe UI", 12F);
            lblHectareas.Location = new Point(12, 131);
            lblHectareas.Name = "lblHectareas";
            lblHectareas.Size = new Size(81, 21);
            lblHectareas.TabIndex = 41;
            lblHectareas.Text = "Hectáreas:";
            // 
            // spnFecha
            // 
            spnFecha.Font = new Font("Segoe UI", 12F);
            spnFecha.Location = new Point(168, 163);
            spnFecha.Mask = "00/00/0000";
            spnFecha.Name = "spnFecha";
            spnFecha.Size = new Size(100, 29);
            spnFecha.TabIndex = 8;
            spnFecha.ValidatingType = typeof(DateTime);
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Segoe UI", 12F);
            lblFecha.Location = new Point(12, 166);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(150, 21);
            lblFecha.TabIndex = 44;
            lblFecha.Text = "Fecha de plantación:";
            // 
            // lblDíaMesAÑo
            // 
            lblDíaMesAÑo.AutoSize = true;
            lblDíaMesAÑo.Font = new Font("Segoe UI", 12F);
            lblDíaMesAÑo.ForeColor = SystemColors.AppWorkspace;
            lblDíaMesAÑo.Location = new Point(274, 166);
            lblDíaMesAÑo.Name = "lblDíaMesAÑo";
            lblDíaMesAÑo.Size = new Size(98, 21);
            lblDíaMesAÑo.TabIndex = 45;
            lblDíaMesAÑo.Text = "mes/día/año";
            // 
            // lblObliVar
            // 
            lblObliVar.AutoSize = true;
            lblObliVar.ForeColor = Color.Crimson;
            lblObliVar.Location = new Point(89, 96);
            lblObliVar.Name = "lblObliVar";
            lblObliVar.Size = new Size(12, 15);
            lblObliVar.TabIndex = 46;
            lblObliVar.Text = "*";
            // 
            // lblObliHa
            // 
            lblObliHa.AutoSize = true;
            lblObliHa.ForeColor = Color.Crimson;
            lblObliHa.Location = new Point(89, 131);
            lblObliHa.Name = "lblObliHa";
            lblObliHa.Size = new Size(12, 15);
            lblObliHa.TabIndex = 47;
            lblObliHa.Text = "*";
            // 
            // lblObliFecha
            // 
            lblObliFecha.AutoSize = true;
            lblObliFecha.ForeColor = Color.Crimson;
            lblObliFecha.Location = new Point(159, 166);
            lblObliFecha.Name = "lblObliFecha";
            lblObliFecha.Size = new Size(12, 15);
            lblObliFecha.TabIndex = 48;
            lblObliFecha.Text = "*";
            // 
            // lblObliAct
            // 
            lblObliAct.AutoSize = true;
            lblObliAct.ForeColor = Color.Crimson;
            lblObliAct.Location = new Point(509, 15);
            lblObliAct.Name = "lblObliAct";
            lblObliAct.Size = new Size(12, 15);
            lblObliAct.TabIndex = 49;
            lblObliAct.Text = "*";
            // 
            // lblObliId
            // 
            lblObliId.AutoSize = true;
            lblObliId.ForeColor = Color.Crimson;
            lblObliId.Location = new Point(593, 15);
            lblObliId.Name = "lblObliId";
            lblObliId.Size = new Size(12, 15);
            lblObliId.TabIndex = 51;
            lblObliId.Text = "*";
            // 
            // spnId
            // 
            spnId.Font = new Font("Segoe UI", 12F);
            spnId.Location = new Point(602, 12);
            spnId.Mask = "9999";
            spnId.Name = "spnId";
            spnId.Size = new Size(57, 29);
            spnId.TabIndex = 1;
            spnId.TextAlign = HorizontalAlignment.Center;
            spnId.ValidatingType = typeof(int);
            // 
            // FrmLoteAñadir
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(671, 238);
            Controls.Add(spnFecha);
            Controls.Add(txbHectareas);
            Controls.Add(txbIdVariedad);
            Controls.Add(txbNombre);
            Controls.Add(spnId);
            Controls.Add(lblObliFecha);
            Controls.Add(lblObliHa);
            Controls.Add(lblObliVar);
            Controls.Add(lblDíaMesAÑo);
            Controls.Add(lblFecha);
            Controls.Add(lblHectareas);
            Controls.Add(btnTodoVariedad);
            Controls.Add(btnBuscarVariedad);
            Controls.Add(cboVariedad);
            Controls.Add(lblVariedad);
            Controls.Add(cboActivo);
            Controls.Add(btnAceptar);
            Controls.Add(btnCancelar);
            Controls.Add(lblTitulo);
            Controls.Add(lblId);
            Controls.Add(lblNombre);
            Controls.Add(lblObliNom);
            Controls.Add(lblObliId);
            Controls.Add(lblObliAct);
            Controls.Add(lblActivo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FrmLoteAñadir";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Añadir lote";
            FormClosing += FrmLoteAñadir_FormClosing;
            Load += FrmLoteAñadir_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblNombre;
        private Label lblId;
        private Button btnCancelar;
        private Button btnAceptar;
        private Label lblHectareas;
        private Label lblActivo;
        public Label lblTitulo;
        public TextBox txbNombre;
        public ComboBox cboActivo;
        private Label lblObliNom;
        private Microsoft.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
        public TextBox txbIdVariedad;
        private ComboBox cboVariedad;
        private Label lblVariedad;
        private Button btnTodoVariedad;
        private Button btnBuscarVariedad;
        public TextBox txbHectareas;
        private MaskedTextBox mtbFecha;
        private Label lblFecha;
        private Label lblDíaMesAÑo;
        private Label lblObliVar;
        private Label lblObliHa;
        private Label lblObliFecha;
        private Label lblObliAct;
        private Label lblObliId;
        public MaskedTextBox spnId;
        public MaskedTextBox spnFecha;
    }
}