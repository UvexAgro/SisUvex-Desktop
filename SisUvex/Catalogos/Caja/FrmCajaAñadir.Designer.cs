﻿
using System.Windows.Forms;

namespace SisUvex.Catalogos.Caja
{
    partial class FrmCajaAñadir
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
            txbNumEco = new TextBox();
            lblNumEco = new Label();
            lblObliNumEco = new Label();
            lblPlacasUS = new Label();
            txbPlacasUS = new TextBox();
            lblPlacasMX = new Label();
            txbPlacasMX = new TextBox();
            lblMarca = new Label();
            txbMarca = new TextBox();
            lblModelo = new Label();
            txbModelo = new TextBox();
            lblTamaño = new Label();
            txbTamaño = new TextBox();
            lblPies = new Label();
            cboTipo = new ComboBox();
            lblTipo = new Label();
            lblAño = new Label();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Arial Black", 16F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitulo.Location = new Point(12, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(152, 31);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Añadir caja";
            // 
            // lblLinea
            // 
            lblLinea.AutoSize = true;
            lblLinea.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblLinea.Location = new Point(10, 56);
            lblLinea.Name = "lblLinea";
            lblLinea.Size = new Size(147, 21);
            lblLinea.TabIndex = 1;
            lblLinea.Text = "Línea de transporte:";
            // 
            // txbId
            // 
            txbId.Enabled = false;
            txbId.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txbId.Location = new Point(572, 12);
            txbId.Name = "txbId";
            txbId.Size = new Size(46, 29);
            txbId.TabIndex = 12;
            txbId.TextAlign = HorizontalAlignment.Center;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblId.Location = new Point(540, 15);
            lblId.Name = "lblId";
            lblId.Size = new Size(26, 21);
            lblId.TabIndex = 6;
            lblId.Text = "Id:";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(544, 333);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 29);
            btnCancelar.TabIndex = 10;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(463, 333);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 29);
            btnAceptar.TabIndex = 11;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnTodoLinea
            // 
            btnTodoLinea.Location = new Point(562, 54);
            btnTodoLinea.Name = "btnTodoLinea";
            btnTodoLinea.Size = new Size(57, 29);
            btnTodoLinea.TabIndex = 2;
            btnTodoLinea.Text = "Activos";
            btnTodoLinea.UseVisualStyleBackColor = true;
            btnTodoLinea.Click += btnTodoLinea_Click;
            // 
            // btnBuscarLinea
            // 
            btnBuscarLinea.Location = new Point(499, 54);
            btnBuscarLinea.Name = "btnBuscarLinea";
            btnBuscarLinea.Size = new Size(57, 29);
            btnBuscarLinea.TabIndex = 1;
            btnBuscarLinea.Text = "Buscar";
            btnBuscarLinea.UseVisualStyleBackColor = true;
            btnBuscarLinea.Click += btnBuscarLinea_Click;
            // 
            // txbIdLinea
            // 
            txbIdLinea.Enabled = false;
            txbIdLinea.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txbIdLinea.Location = new Point(163, 53);
            txbIdLinea.Name = "txbIdLinea";
            txbIdLinea.Size = new Size(46, 29);
            txbIdLinea.TabIndex = 14;
            txbIdLinea.TextAlign = HorizontalAlignment.Center;
            // 
            // cboLinea
            // 
            cboLinea.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cboLinea.FormattingEnabled = true;
            cboLinea.ItemHeight = 21;
            cboLinea.Location = new Point(215, 53);
            cboLinea.Name = "cboLinea";
            cboLinea.Size = new Size(278, 29);
            cboLinea.TabIndex = 0;
            cboLinea.TextChanged += cboLinea_TextChanged;
            cboLinea.MouseClick += cboLinea_MouseClick;
            // 
            // lblObliLinea
            // 
            lblObliLinea.AutoSize = true;
            lblObliLinea.ForeColor = Color.Crimson;
            lblObliLinea.Location = new Point(154, 53);
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
            cboActivo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cboActivo.FormattingEnabled = true;
            cboActivo.Items.AddRange(new object[] { "No", "Sí" });
            cboActivo.Location = new Point(488, 12);
            cboActivo.Name = "cboActivo";
            cboActivo.Size = new Size(46, 29);
            cboActivo.TabIndex = 13;
            // 
            // lblActivo
            // 
            lblActivo.AutoSize = true;
            lblActivo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
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
            // txbNumEco
            // 
            txbNumEco.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbNumEco.Location = new Point(163, 123);
            txbNumEco.MaxLength = 15;
            txbNumEco.Name = "txbNumEco";
            txbNumEco.Size = new Size(175, 29);
            txbNumEco.TabIndex = 4;
            // 
            // lblNumEco
            // 
            lblNumEco.AutoSize = true;
            lblNumEco.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblNumEco.Location = new Point(6, 126);
            lblNumEco.Name = "lblNumEco";
            lblNumEco.Size = new Size(151, 21);
            lblNumEco.TabIndex = 43;
            lblNumEco.Text = "Número económico:";
            // 
            // lblObliNumEco
            // 
            lblObliNumEco.AutoSize = true;
            lblObliNumEco.ForeColor = Color.Crimson;
            lblObliNumEco.Location = new Point(155, 123);
            lblObliNumEco.Name = "lblObliNumEco";
            lblObliNumEco.Size = new Size(12, 15);
            lblObliNumEco.TabIndex = 44;
            lblObliNumEco.Text = "*";
            // 
            // lblPlacasUS
            // 
            lblPlacasUS.AutoSize = true;
            lblPlacasUS.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblPlacasUS.Location = new Point(15, 161);
            lblPlacasUS.Name = "lblPlacasUS";
            lblPlacasUS.Size = new Size(80, 21);
            lblPlacasUS.TabIndex = 46;
            lblPlacasUS.Text = "Placas US:";
            // 
            // txbPlacasUS
            // 
            txbPlacasUS.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbPlacasUS.Location = new Point(101, 158);
            txbPlacasUS.MaxLength = 15;
            txbPlacasUS.Name = "txbPlacasUS";
            txbPlacasUS.Size = new Size(237, 29);
            txbPlacasUS.TabIndex = 5;
            // 
            // lblPlacasMX
            // 
            lblPlacasMX.AutoSize = true;
            lblPlacasMX.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblPlacasMX.Location = new Point(12, 196);
            lblPlacasMX.Name = "lblPlacasMX";
            lblPlacasMX.Size = new Size(83, 21);
            lblPlacasMX.TabIndex = 49;
            lblPlacasMX.Text = "Placas MX:";
            // 
            // txbPlacasMX
            // 
            txbPlacasMX.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbPlacasMX.Location = new Point(101, 193);
            txbPlacasMX.MaxLength = 15;
            txbPlacasMX.Name = "txbPlacasMX";
            txbPlacasMX.Size = new Size(237, 29);
            txbPlacasMX.TabIndex = 6;
            // 
            // lblMarca
            // 
            lblMarca.AutoSize = true;
            lblMarca.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblMarca.Location = new Point(39, 231);
            lblMarca.Name = "lblMarca";
            lblMarca.Size = new Size(56, 21);
            lblMarca.TabIndex = 52;
            lblMarca.Text = "Marca:";
            // 
            // txbMarca
            // 
            txbMarca.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbMarca.Location = new Point(101, 228);
            txbMarca.MaxLength = 30;
            txbMarca.Name = "txbMarca";
            txbMarca.Size = new Size(392, 29);
            txbMarca.TabIndex = 7;
            // 
            // lblModelo
            // 
            lblModelo.AutoSize = true;
            lblModelo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblModelo.Location = new Point(29, 266);
            lblModelo.Name = "lblModelo";
            lblModelo.Size = new Size(66, 21);
            lblModelo.TabIndex = 58;
            lblModelo.Text = "Modelo:";
            // 
            // txbModelo
            // 
            txbModelo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbModelo.Location = new Point(101, 263);
            txbModelo.MaxLength = 4;
            txbModelo.Name = "txbModelo";
            txbModelo.Size = new Size(80, 29);
            txbModelo.TabIndex = 8;
            txbModelo.KeyPress += txbModelo_KeyPress;
            // 
            // lblTamaño
            // 
            lblTamaño.AutoSize = true;
            lblTamaño.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblTamaño.Location = new Point(29, 301);
            lblTamaño.Name = "lblTamaño";
            lblTamaño.Size = new Size(67, 21);
            lblTamaño.TabIndex = 60;
            lblTamaño.Text = "Tamaño:";
            // 
            // txbTamaño
            // 
            txbTamaño.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbTamaño.Location = new Point(101, 298);
            txbTamaño.MaxLength = 3;
            txbTamaño.Name = "txbTamaño";
            txbTamaño.Size = new Size(80, 29);
            txbTamaño.TabIndex = 9;
            txbTamaño.KeyPress += txbTamaño_KeyPress;
            // 
            // lblPies
            // 
            lblPies.AutoSize = true;
            lblPies.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblPies.ForeColor = SystemColors.AppWorkspace;
            lblPies.Location = new Point(182, 301);
            lblPies.Name = "lblPies";
            lblPies.Size = new Size(38, 21);
            lblPies.TabIndex = 61;
            lblPies.Text = "píes";
            // 
            // cboTipo
            // 
            cboTipo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cboTipo.FormattingEnabled = true;
            cboTipo.Location = new Point(163, 88);
            cboTipo.Name = "cboTipo";
            cboTipo.Size = new Size(252, 29);
            cboTipo.TabIndex = 3;
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblTipo.Location = new Point(10, 91);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(147, 21);
            lblTipo.TabIndex = 63;
            lblTipo.Text = "Tipo de contenedor:";
            // 
            // lblAño
            // 
            lblAño.AutoSize = true;
            lblAño.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblAño.ForeColor = SystemColors.AppWorkspace;
            lblAño.Location = new Point(182, 266);
            lblAño.Name = "lblAño";
            lblAño.Size = new Size(36, 21);
            lblAño.TabIndex = 64;
            lblAño.Text = "año";
            // 
            // FrmCajaAñadir
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(629, 373);
            Controls.Add(lblAño);
            Controls.Add(lblTipo);
            Controls.Add(cboTipo);
            Controls.Add(lblPies);
            Controls.Add(lblTamaño);
            Controls.Add(txbTamaño);
            Controls.Add(lblModelo);
            Controls.Add(txbModelo);
            Controls.Add(lblMarca);
            Controls.Add(txbMarca);
            Controls.Add(lblPlacasMX);
            Controls.Add(txbPlacasMX);
            Controls.Add(lblPlacasUS);
            Controls.Add(txbPlacasUS);
            Controls.Add(lblNumEco);
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
            Controls.Add(txbNumEco);
            Controls.Add(lblObliNumEco);
            Controls.Add(label2);
            Controls.Add(lblActivo);
            Controls.Add(lblLinea);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmCajaAñadir";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Añadir caja";
            FormClosing += FrmCajaAñadir_FormClosing;
            Load += FrmCajaAñadir_Load;
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
        private Label lblNumEco;
        private Label lblObliNumEco;
        private Label lblPlacasUS;
        private Label lblPlacasMX;
        private Label lblMarca;
        public TextBox txbNumEco;
        public TextBox txbPlacasUS;
        public TextBox txbPlacasMX;
        public TextBox txbMarca;
        private Label lblModelo;
        public TextBox txbModelo;
        private Label lblTamaño;
        public TextBox txbTamaño;
        private Label lblPies;
        private Label lblTipo;
        private Label lblAño;
        public ComboBox cboTipo;
    }
}