namespace SisUvex.Catalogos.Variedad
{
    partial class FrmVariedadAñadir
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
            lblNomCientifico = new Label();
            txbNomCientifico = new TextBox();
            lblNomComercial = new Label();
            txbNomComercial = new TextBox();
            txbId = new TextBox();
            lblId = new Label();
            btnCancelar = new Button();
            btnAceptar = new Button();
            lblActivo = new Label();
            cboActivo = new ComboBox();
            lblObliCom = new Label();
            txbIdColor = new TextBox();
            cboColor = new ComboBox();
            lblColor = new Label();
            txbIdCultivo = new TextBox();
            cboCultivo = new ComboBox();
            lblCultivo = new Label();
            label3 = new Label();
            label4 = new Label();
            txbNomCorto = new TextBox();
            lblNomCorto = new Label();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Arial Black", 16F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitulo.Location = new Point(9, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(205, 31);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Añadir variedad";
            // 
            // lblNomCientifico
            // 
            lblNomCientifico.AutoSize = true;
            lblNomCientifico.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblNomCientifico.Location = new Point(26, 50);
            lblNomCientifico.Name = "lblNomCientifico";
            lblNomCientifico.Size = new Size(137, 21);
            lblNomCientifico.TabIndex = 1;
            lblNomCientifico.Text = "Nombre cientifico:";
            // 
            // txbNomCientifico
            // 
            txbNomCientifico.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbNomCientifico.Location = new Point(169, 47);
            txbNomCientifico.MaxLength = 20;
            txbNomCientifico.Name = "txbNomCientifico";
            txbNomCientifico.Size = new Size(363, 29);
            txbNomCientifico.TabIndex = 2;
            // 
            // lblNomComercial
            // 
            lblNomComercial.AutoSize = true;
            lblNomComercial.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblNomComercial.Location = new Point(21, 85);
            lblNomComercial.Name = "lblNomComercial";
            lblNomComercial.Size = new Size(142, 21);
            lblNomComercial.TabIndex = 3;
            lblNomComercial.Text = "Nombre comercial:";
            // 
            // txbNomComercial
            // 
            txbNomComercial.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbNomComercial.Location = new Point(169, 82);
            txbNomComercial.MaxLength = 20;
            txbNomComercial.Name = "txbNomComercial";
            txbNomComercial.Size = new Size(363, 29);
            txbNomComercial.TabIndex = 4;
            // 
            // txbId
            // 
            txbId.Enabled = false;
            txbId.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txbId.Location = new Point(486, 12);
            txbId.Name = "txbId";
            txbId.Size = new Size(46, 29);
            txbId.TabIndex = 5;
            txbId.TextAlign = HorizontalAlignment.Center;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblId.Location = new Point(458, 15);
            lblId.Name = "lblId";
            lblId.Size = new Size(26, 21);
            lblId.TabIndex = 6;
            lblId.Text = "Id:";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(457, 221);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 29);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(376, 221);
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
            lblActivo.Location = new Point(349, 15);
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
            cboActivo.Location = new Point(405, 12);
            cboActivo.Name = "cboActivo";
            cboActivo.Size = new Size(46, 29);
            cboActivo.TabIndex = 11;
            // 
            // lblObliCom
            // 
            lblObliCom.AutoSize = true;
            lblObliCom.ForeColor = Color.Crimson;
            lblObliCom.Location = new Point(160, 82);
            lblObliCom.Name = "lblObliCom";
            lblObliCom.Size = new Size(12, 15);
            lblObliCom.TabIndex = 12;
            lblObliCom.Text = "*";
            // 
            // txbIdColor
            // 
            txbIdColor.Enabled = false;
            txbIdColor.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txbIdColor.Location = new Point(117, 152);
            txbIdColor.Name = "txbIdColor";
            txbIdColor.Size = new Size(46, 29);
            txbIdColor.TabIndex = 35;
            txbIdColor.TextAlign = HorizontalAlignment.Center;
            // 
            // cboColor
            // 
            cboColor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboColor.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cboColor.FormattingEnabled = true;
            cboColor.ItemHeight = 21;
            cboColor.Location = new Point(169, 152);
            cboColor.Name = "cboColor";
            cboColor.Size = new Size(206, 29);
            cboColor.TabIndex = 34;
            cboColor.TextChanged += cboColor_TextChanged;
            // 
            // lblColor
            // 
            lblColor.AutoSize = true;
            lblColor.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblColor.Location = new Point(60, 155);
            lblColor.Name = "lblColor";
            lblColor.Size = new Size(51, 21);
            lblColor.TabIndex = 33;
            lblColor.Text = "Color:";
            // 
            // txbIdCultivo
            // 
            txbIdCultivo.Enabled = false;
            txbIdCultivo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txbIdCultivo.Location = new Point(117, 187);
            txbIdCultivo.Name = "txbIdCultivo";
            txbIdCultivo.Size = new Size(46, 29);
            txbIdCultivo.TabIndex = 38;
            txbIdCultivo.TextAlign = HorizontalAlignment.Center;
            // 
            // cboCultivo
            // 
            cboCultivo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCultivo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cboCultivo.FormattingEnabled = true;
            cboCultivo.ItemHeight = 21;
            cboCultivo.Location = new Point(169, 187);
            cboCultivo.Name = "cboCultivo";
            cboCultivo.Size = new Size(206, 29);
            cboCultivo.TabIndex = 37;
            cboCultivo.TextChanged += cboCultivo_TextChanged;
            // 
            // lblCultivo
            // 
            lblCultivo.AutoSize = true;
            lblCultivo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblCultivo.Location = new Point(49, 190);
            lblCultivo.Name = "lblCultivo";
            lblCultivo.Size = new Size(62, 21);
            lblCultivo.TabIndex = 36;
            lblCultivo.Text = "Cultivo:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Crimson;
            label3.Location = new Point(108, 154);
            label3.Name = "label3";
            label3.Size = new Size(12, 15);
            label3.TabIndex = 39;
            label3.Text = "*";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Crimson;
            label4.Location = new Point(108, 190);
            label4.Name = "label4";
            label4.Size = new Size(12, 15);
            label4.TabIndex = 40;
            label4.Text = "*";
            // 
            // txbNomCorto
            // 
            txbNomCorto.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbNomCorto.Location = new Point(169, 117);
            txbNomCorto.MaxLength = 10;
            txbNomCorto.Name = "txbNomCorto";
            txbNomCorto.Size = new Size(363, 29);
            txbNomCorto.TabIndex = 42;
            // 
            // lblNomCorto
            // 
            lblNomCorto.AutoSize = true;
            lblNomCorto.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblNomCorto.Location = new Point(52, 120);
            lblNomCorto.Name = "lblNomCorto";
            lblNomCorto.Size = new Size(111, 21);
            lblNomCorto.TabIndex = 41;
            lblNomCorto.Text = "Nombre corto:";
            // 
            // FrmVariedadAñadir
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(544, 263);
            Controls.Add(txbNomCorto);
            Controls.Add(lblNomCorto);
            Controls.Add(txbIdCultivo);
            Controls.Add(cboCultivo);
            Controls.Add(lblCultivo);
            Controls.Add(txbIdColor);
            Controls.Add(cboColor);
            Controls.Add(lblColor);
            Controls.Add(cboActivo);
            Controls.Add(btnAceptar);
            Controls.Add(btnCancelar);
            Controls.Add(txbId);
            Controls.Add(txbNomComercial);
            Controls.Add(lblNomComercial);
            Controls.Add(txbNomCientifico);
            Controls.Add(lblNomCientifico);
            Controls.Add(lblTitulo);
            Controls.Add(lblId);
            Controls.Add(lblActivo);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(lblObliCom);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmVariedadAñadir";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Añadir variedad";
            FormClosing += FrmVariedadAñadir_FormClosing;
            Load += FrmVariedadAñadir_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblNomCientifico;
        private Label label2;
        private Label lblId;
        private Button btnCancelar;
        private Button btnAceptar;
        private TextBox textBox1;
        private Label label1;
        private Label lblActivo;
        public Label lblTitulo;
        public TextBox txbNomCientifico;
        public TextBox txbNomComercial;
        public TextBox txbId;
        public ComboBox cboActivo;
        private Label lblObliCom;
        private Label lblNomComercial;
        public TextBox txbIdColor;
        public ComboBox cboColor;
        private Label lblColor;
        public TextBox txbIdCultivo;
        public ComboBox cboCultivo;
        private Label lblCultivo;
        private Label label3;
        private Label label4;
        public TextBox txbNomCorto;
        private Label lblNomCorto;
    }
}