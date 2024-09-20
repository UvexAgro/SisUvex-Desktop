using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;

namespace SisUvex.Catalogos.Material
{
    partial class FrmMaterialAñadir
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
            lblIdTipo = new Label();
            btnCancelar = new Button();
            btnAceptar = new Button();
            lblObliCom = new Label();
            txbCantidadPorUnidad = new TextBox();
            lblCantidadPorUnidad = new Label();
            lblObliNombre = new Label();
            cboTipoMat = new ComboBox();
            txbIdTipo = new TextBox();
            btnBuscarMatTipo = new Button();
            lblObliTipoMaterial = new Label();
            txbCantidad = new TextBox();
            lblCantidad = new Label();
            btnBuscarDistribuidor = new Button();
            txbIdDistribuidor = new TextBox();
            cboDistribuidor = new ComboBox();
            lblDistribuidor = new Label();
            lblObliDistribuidor = new Label();
            txbIdColor = new TextBox();
            cboColor = new ComboBox();
            lblColor = new Label();
            lblObliColor = new Label();
            lblObliNombreEtiqueta = new Label();
            txbNombreEnEtiqueta = new TextBox();
            lblNombreEtiqueta = new Label();
            btnTodoMatTipo = new Button();
            btnTodoDistribuidor = new Button();
            txbId = new TextBox();
            lblId = new Label();
            txbIdUnidad = new TextBox();
            cboUnidad = new ComboBox();
            lblUnidad = new Label();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Arial Black", 16F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitulo.Location = new Point(9, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(201, 31);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Añadir material";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblNombre.Location = new Point(12, 93);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(71, 21);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre:";
            // 
            // txbNombre
            // 
            txbNombre.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbNombre.Location = new Point(90, 90);
            txbNombre.MaxLength = 20;
            txbNombre.Name = "txbNombre";
            txbNombre.Size = new Size(466, 29);
            txbNombre.TabIndex = 3;
            // 
            // lblIdTipo
            // 
            lblIdTipo.AutoSize = true;
            lblIdTipo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblIdTipo.Location = new Point(13, 58);
            lblIdTipo.Name = "lblIdTipo";
            lblIdTipo.Size = new Size(57, 21);
            lblIdTipo.TabIndex = 6;
            lblIdTipo.Text = "Id tipo:";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(611, 335);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 29);
            btnCancelar.TabIndex = 12;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(530, 335);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 29);
            btnAceptar.TabIndex = 13;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // lblObliCom
            // 
            lblObliCom.AutoSize = true;
            lblObliCom.ForeColor = Color.Crimson;
            lblObliCom.Location = new Point(231, 55);
            lblObliCom.Name = "lblObliCom";
            lblObliCom.Size = new Size(12, 15);
            lblObliCom.TabIndex = 13;
            lblObliCom.Text = "*";
            // 
            // txbCantidadPorUnidad
            // 
            txbCantidadPorUnidad.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbCantidadPorUnidad.Location = new Point(173, 195);
            txbCantidadPorUnidad.MaxLength = 7;
            txbCantidadPorUnidad.Name = "txbCantidadPorUnidad";
            txbCantidadPorUnidad.Size = new Size(175, 29);
            txbCantidadPorUnidad.TabIndex = 6;
            txbCantidadPorUnidad.TextChanged += txbCantidadPorUnidad_TextChanged;
            txbCantidadPorUnidad.KeyPress += txbCantidadPorunidad_KeyPress;
            // 
            // lblCantidadPorUnidad
            // 
            lblCantidadPorUnidad.AutoSize = true;
            lblCantidadPorUnidad.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblCantidadPorUnidad.Location = new Point(12, 198);
            lblCantidadPorUnidad.Name = "lblCantidadPorUnidad";
            lblCantidadPorUnidad.Size = new Size(155, 21);
            lblCantidadPorUnidad.TabIndex = 15;
            lblCantidadPorUnidad.Text = "Cantidad por unidad:";
            // 
            // lblObliNombre
            // 
            lblObliNombre.AutoSize = true;
            lblObliNombre.ForeColor = Color.Crimson;
            lblObliNombre.Location = new Point(4, 93);
            lblObliNombre.Name = "lblObliNombre";
            lblObliNombre.Size = new Size(12, 15);
            lblObliNombre.TabIndex = 16;
            lblObliNombre.Text = "*";
            // 
            // cboTipoMat
            // 
            cboTipoMat.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cboTipoMat.FormattingEnabled = true;
            cboTipoMat.ItemHeight = 21;
            cboTipoMat.Location = new Point(142, 55);
            cboTipoMat.Name = "cboTipoMat";
            cboTipoMat.Size = new Size(414, 29);
            cboTipoMat.TabIndex = 0;
            cboTipoMat.TextChanged += cboTipoMat_TextChanged;
            cboTipoMat.MouseClick += cboTipoMat_MouseClick;
            // 
            // txbIdTipo
            // 
            txbIdTipo.Enabled = false;
            txbIdTipo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txbIdTipo.Location = new Point(90, 55);
            txbIdTipo.Name = "txbIdTipo";
            txbIdTipo.Size = new Size(46, 29);
            txbIdTipo.TabIndex = 20;
            txbIdTipo.TextAlign = HorizontalAlignment.Center;
            txbIdTipo.TextChanged += txbIdTipo_TextChanged;
            // 
            // btnBuscarMatTipo
            // 
            btnBuscarMatTipo.Location = new Point(566, 55);
            btnBuscarMatTipo.Name = "btnBuscarMatTipo";
            btnBuscarMatTipo.Size = new Size(57, 29);
            btnBuscarMatTipo.TabIndex = 1;
            btnBuscarMatTipo.Text = "Buscar";
            btnBuscarMatTipo.UseVisualStyleBackColor = true;
            btnBuscarMatTipo.Click += btnBuscarMatTipo_Click;
            // 
            // lblObliTipoMaterial
            // 
            lblObliTipoMaterial.AutoSize = true;
            lblObliTipoMaterial.ForeColor = Color.Crimson;
            lblObliTipoMaterial.Location = new Point(4, 58);
            lblObliTipoMaterial.Name = "lblObliTipoMaterial";
            lblObliTipoMaterial.Size = new Size(12, 15);
            lblObliTipoMaterial.TabIndex = 22;
            lblObliTipoMaterial.Text = "*";
            // 
            // txbCantidad
            // 
            txbCantidad.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbCantidad.Location = new Point(94, 160);
            txbCantidad.MaxLength = 8;
            txbCantidad.Name = "txbCantidad";
            txbCantidad.Size = new Size(153, 29);
            txbCantidad.TabIndex = 5;
            txbCantidad.KeyPress += txbCantidad_KeyPress;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblCantidad.Location = new Point(12, 163);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(75, 21);
            lblCantidad.TabIndex = 24;
            lblCantidad.Text = "Cantidad:";
            // 
            // btnBuscarDistribuidor
            // 
            btnBuscarDistribuidor.Location = new Point(566, 265);
            btnBuscarDistribuidor.Name = "btnBuscarDistribuidor";
            btnBuscarDistribuidor.Size = new Size(57, 29);
            btnBuscarDistribuidor.TabIndex = 9;
            btnBuscarDistribuidor.Text = "Buscar";
            btnBuscarDistribuidor.UseVisualStyleBackColor = true;
            btnBuscarDistribuidor.Click += btnBuscarDistribuidor_Click;
            // 
            // txbIdDistribuidor
            // 
            txbIdDistribuidor.Enabled = false;
            txbIdDistribuidor.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txbIdDistribuidor.Location = new Point(111, 265);
            txbIdDistribuidor.Name = "txbIdDistribuidor";
            txbIdDistribuidor.Size = new Size(46, 29);
            txbIdDistribuidor.TabIndex = 27;
            txbIdDistribuidor.TextAlign = HorizontalAlignment.Center;
            // 
            // cboDistribuidor
            // 
            cboDistribuidor.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cboDistribuidor.FormattingEnabled = true;
            cboDistribuidor.ItemHeight = 21;
            cboDistribuidor.Location = new Point(163, 265);
            cboDistribuidor.Name = "cboDistribuidor";
            cboDistribuidor.Size = new Size(393, 29);
            cboDistribuidor.TabIndex = 8;
            cboDistribuidor.TextChanged += cboDistribuidor_TextChanged;
            cboDistribuidor.MouseClick += cboDistribuidor_MouseClick;
            // 
            // lblDistribuidor
            // 
            lblDistribuidor.AutoSize = true;
            lblDistribuidor.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblDistribuidor.Location = new Point(13, 268);
            lblDistribuidor.Name = "lblDistribuidor";
            lblDistribuidor.Size = new Size(96, 21);
            lblDistribuidor.TabIndex = 25;
            lblDistribuidor.Text = "Distribuidor:";
            // 
            // lblObliDistribuidor
            // 
            lblObliDistribuidor.AutoSize = true;
            lblObliDistribuidor.ForeColor = Color.Crimson;
            lblObliDistribuidor.Location = new Point(4, 266);
            lblObliDistribuidor.Name = "lblObliDistribuidor";
            lblObliDistribuidor.Size = new Size(12, 15);
            lblObliDistribuidor.TabIndex = 29;
            lblObliDistribuidor.Text = "*";
            // 
            // txbIdColor
            // 
            txbIdColor.Enabled = false;
            txbIdColor.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txbIdColor.Location = new Point(90, 300);
            txbIdColor.Name = "txbIdColor";
            txbIdColor.Size = new Size(46, 29);
            txbIdColor.TabIndex = 32;
            txbIdColor.TextAlign = HorizontalAlignment.Center;
            // 
            // cboColor
            // 
            cboColor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboColor.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cboColor.FormattingEnabled = true;
            cboColor.ItemHeight = 21;
            cboColor.Location = new Point(142, 300);
            cboColor.Name = "cboColor";
            cboColor.Size = new Size(206, 29);
            cboColor.TabIndex = 11;
            cboColor.TextChanged += cboColor_TextChanged;
            // 
            // lblColor
            // 
            lblColor.AutoSize = true;
            lblColor.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblColor.Location = new Point(13, 303);
            lblColor.Name = "lblColor";
            lblColor.Size = new Size(51, 21);
            lblColor.TabIndex = 30;
            lblColor.Text = "Color:";
            // 
            // lblObliColor
            // 
            lblObliColor.AutoSize = true;
            lblObliColor.ForeColor = Color.Crimson;
            lblObliColor.Location = new Point(4, 303);
            lblObliColor.Name = "lblObliColor";
            lblObliColor.Size = new Size(12, 15);
            lblObliColor.TabIndex = 33;
            lblObliColor.Text = "*";
            // 
            // lblObliNombreEtiqueta
            // 
            lblObliNombreEtiqueta.AutoSize = true;
            lblObliNombreEtiqueta.ForeColor = Color.Crimson;
            lblObliNombreEtiqueta.Location = new Point(4, 128);
            lblObliNombreEtiqueta.Name = "lblObliNombreEtiqueta";
            lblObliNombreEtiqueta.Size = new Size(12, 15);
            lblObliNombreEtiqueta.TabIndex = 36;
            lblObliNombreEtiqueta.Text = "*";
            // 
            // txbNombreEnEtiqueta
            // 
            txbNombreEnEtiqueta.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbNombreEnEtiqueta.Location = new Point(170, 125);
            txbNombreEnEtiqueta.MaxLength = 20;
            txbNombreEnEtiqueta.Name = "txbNombreEnEtiqueta";
            txbNombreEnEtiqueta.Size = new Size(332, 29);
            txbNombreEnEtiqueta.TabIndex = 4;
            // 
            // lblNombreEtiqueta
            // 
            lblNombreEtiqueta.AutoSize = true;
            lblNombreEtiqueta.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblNombreEtiqueta.Location = new Point(12, 128);
            lblNombreEtiqueta.Name = "lblNombreEtiqueta";
            lblNombreEtiqueta.Size = new Size(152, 21);
            lblNombreEtiqueta.TabIndex = 35;
            lblNombreEtiqueta.Text = "Nombre en etiqueta:";
            // 
            // btnTodoMatTipo
            // 
            btnTodoMatTipo.Location = new Point(629, 55);
            btnTodoMatTipo.Name = "btnTodoMatTipo";
            btnTodoMatTipo.Size = new Size(57, 29);
            btnTodoMatTipo.TabIndex = 2;
            btnTodoMatTipo.Text = "Activos";
            btnTodoMatTipo.UseVisualStyleBackColor = true;
            btnTodoMatTipo.Click += btnTodoMatTipo_Click;
            // 
            // btnTodoDistribuidor
            // 
            btnTodoDistribuidor.Location = new Point(629, 265);
            btnTodoDistribuidor.Name = "btnTodoDistribuidor";
            btnTodoDistribuidor.Size = new Size(57, 29);
            btnTodoDistribuidor.TabIndex = 10;
            btnTodoDistribuidor.Text = "Activos";
            btnTodoDistribuidor.UseVisualStyleBackColor = true;
            btnTodoDistribuidor.Click += btnTodoDistribuidor_Click;
            // 
            // txbId
            // 
            txbId.Enabled = false;
            txbId.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txbId.Location = new Point(590, 12);
            txbId.Name = "txbId";
            txbId.Size = new Size(96, 29);
            txbId.TabIndex = 39;
            txbId.TextAlign = HorizontalAlignment.Center;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblId.Location = new Point(558, 15);
            lblId.Name = "lblId";
            lblId.Size = new Size(26, 21);
            lblId.TabIndex = 40;
            lblId.Text = "Id:";
            // 
            // txbIdUnidad
            // 
            txbIdUnidad.Enabled = false;
            txbIdUnidad.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txbIdUnidad.Location = new Point(432, 195);
            txbIdUnidad.Name = "txbIdUnidad";
            txbIdUnidad.Size = new Size(46, 29);
            txbIdUnidad.TabIndex = 43;
            txbIdUnidad.TextAlign = HorizontalAlignment.Center;
            // 
            // cboUnidad
            // 
            cboUnidad.DropDownStyle = ComboBoxStyle.DropDownList;
            cboUnidad.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cboUnidad.FormattingEnabled = true;
            cboUnidad.ItemHeight = 21;
            cboUnidad.Location = new Point(487, 195);
            cboUnidad.Name = "cboUnidad";
            cboUnidad.Size = new Size(199, 29);
            cboUnidad.TabIndex = 7;
            cboUnidad.TextChanged += cboUnidad_TextChanged;
            // 
            // lblUnidad
            // 
            lblUnidad.AutoSize = true;
            lblUnidad.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblUnidad.Location = new Point(354, 198);
            lblUnidad.Name = "lblUnidad";
            lblUnidad.Size = new Size(63, 21);
            lblUnidad.TabIndex = 41;
            lblUnidad.Text = "Unidad:";
            // 
            // FrmMaterialAñadir
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(697, 375);
            Controls.Add(txbIdUnidad);
            Controls.Add(cboUnidad);
            Controls.Add(lblUnidad);
            Controls.Add(lblId);
            Controls.Add(txbId);
            Controls.Add(btnTodoDistribuidor);
            Controls.Add(btnTodoMatTipo);
            Controls.Add(txbNombreEnEtiqueta);
            Controls.Add(lblNombreEtiqueta);
            Controls.Add(txbIdColor);
            Controls.Add(cboColor);
            Controls.Add(lblColor);
            Controls.Add(btnBuscarDistribuidor);
            Controls.Add(txbIdDistribuidor);
            Controls.Add(cboDistribuidor);
            Controls.Add(lblDistribuidor);
            Controls.Add(txbCantidad);
            Controls.Add(lblCantidad);
            Controls.Add(btnBuscarMatTipo);
            Controls.Add(txbIdTipo);
            Controls.Add(cboTipoMat);
            Controls.Add(txbCantidadPorUnidad);
            Controls.Add(lblCantidadPorUnidad);
            Controls.Add(btnAceptar);
            Controls.Add(btnCancelar);
            Controls.Add(txbNombre);
            Controls.Add(lblNombre);
            Controls.Add(lblTitulo);
            Controls.Add(lblIdTipo);
            Controls.Add(lblObliCom);
            Controls.Add(lblObliNombreEtiqueta);
            Controls.Add(lblObliDistribuidor);
            Controls.Add(lblObliColor);
            Controls.Add(lblObliNombre);
            Controls.Add(lblObliTipoMaterial);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmMaterialAñadir";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Añadir de material";
            FormClosing += FrmMaterialAñadir_FormClosing;
            Load += FrmMaterialAñadir_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblNombre;
        private Label lblIdTipo;
        private Button btnCancelar;
        private Button btnAceptar;
        private Label lblCantidadPorUnidad;
        public Label lblTitulo;
        public TextBox txbNombre;
        private Label lblObliCom;
        public TextBox txbCantidadPorUnidad;
        private Label lblObliNombre;
        public TextBox txbIdTipo;
        private Label lblObliTipoMaterial;
        public TextBox txbCantidad;
        private Label lblCantidad;
        private Button btnBuscarDistribuidor;
        public TextBox txbIdDistribuidor;
        private ComboBox cboDistribuidor;
        private Label lblDistribuidor;
        private Label lblObliDistribuidor;
        public TextBox txbIdColor;
        private Label lblColor;
        private Label lblObliColor;
        private Label lblObliNombreEtiqueta;
        public TextBox txbNombreEnEtiqueta;
        private Label lblNombreEtiqueta;
        private Button btnTodoDistribuidor;
        public ComboBox cboColor;
        public TextBox txbId;
        private Label lblId;
        public ComboBox cboTipoMat;
        private Button btnBuscarMatTipo;
        private Button btnTodoMatTipo;
        public TextBox txbIdUnidad;
        public ComboBox cboUnidad;
        private Label lblUnidad;
    }
}