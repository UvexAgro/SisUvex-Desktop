namespace SisUvex.Catalogos.LabelLegend
{
    partial class FrmLabelLegendAdd
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLabelLegendAdd));
            txbLabelLegend2 = new TextBox();
            label3 = new Label();
            txbLabelLegend = new TextBox();
            lblNombre = new Label();
            lblTitulo = new Label();
            lblObliNombre = new Label();
            txbId = new TextBox();
            lblId = new Label();
            cboActive = new ComboBox();
            lblActivo = new Label();
            label2 = new Label();
            label1 = new Label();
            txbDescription = new RichTextBox();
            btnAceptar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // txbLabelLegend2
            // 
            txbLabelLegend2.Font = new Font("Segoe UI", 12F);
            txbLabelLegend2.Location = new Point(105, 90);
            txbLabelLegend2.MaxLength = 200;
            txbLabelLegend2.Name = "txbLabelLegend2";
            txbLabelLegend2.Size = new Size(591, 29);
            txbLabelLegend2.TabIndex = 100;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(15, 93);
            label3.Name = "label3";
            label3.Size = new Size(84, 21);
            label3.TabIndex = 102;
            label3.Text = "Leyenda 2:";
            // 
            // txbLabelLegend
            // 
            txbLabelLegend.Font = new Font("Segoe UI", 12F);
            txbLabelLegend.Location = new Point(105, 55);
            txbLabelLegend.MaxLength = 200;
            txbLabelLegend.Name = "txbLabelLegend";
            txbLabelLegend.Size = new Size(591, 29);
            txbLabelLegend.TabIndex = 99;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 12F);
            lblNombre.Location = new Point(28, 58);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(71, 21);
            lblNombre.TabIndex = 98;
            lblNombre.Text = "Leyenda:";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Arial Black", 16F);
            lblTitulo.Location = new Point(12, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(341, 31);
            lblTitulo.TabIndex = 97;
            lblTitulo.Text = "Añadir leyenda de etiqueta";
            // 
            // lblObliNombre
            // 
            lblObliNombre.AutoSize = true;
            lblObliNombre.ForeColor = Color.Crimson;
            lblObliNombre.Location = new Point(96, 55);
            lblObliNombre.Name = "lblObliNombre";
            lblObliNombre.Size = new Size(12, 15);
            lblObliNombre.TabIndex = 101;
            lblObliNombre.Text = "*";
            // 
            // txbId
            // 
            txbId.Enabled = false;
            txbId.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbId.Location = new Point(650, 20);
            txbId.Name = "txbId";
            txbId.Size = new Size(46, 29);
            txbId.TabIndex = 103;
            txbId.TextAlign = HorizontalAlignment.Center;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 12F);
            lblId.Location = new Point(622, 23);
            lblId.Name = "lblId";
            lblId.Size = new Size(26, 21);
            lblId.TabIndex = 104;
            lblId.Text = "Id:";
            // 
            // cboActive
            // 
            cboActive.DropDownStyle = ComboBoxStyle.DropDownList;
            cboActive.Font = new Font("Segoe UI", 12F);
            cboActive.FormattingEnabled = true;
            cboActive.Items.AddRange(new object[] { "No", "Sí" });
            cboActive.Location = new Point(569, 20);
            cboActive.Name = "cboActive";
            cboActive.Size = new Size(46, 29);
            cboActive.TabIndex = 106;
            // 
            // lblActivo
            // 
            lblActivo.AutoSize = true;
            lblActivo.Font = new Font("Segoe UI", 12F);
            lblActivo.Location = new Point(508, 23);
            lblActivo.Name = "lblActivo";
            lblActivo.Size = new Size(56, 21);
            lblActivo.TabIndex = 105;
            lblActivo.Text = "Activo:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.ForeColor = Color.Crimson;
            label2.Location = new Point(561, 20);
            label2.Name = "label2";
            label2.Size = new Size(12, 15);
            label2.TabIndex = 107;
            label2.Text = "*";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(5, 132);
            label1.Name = "label1";
            label1.Size = new Size(94, 21);
            label1.TabIndex = 108;
            label1.Text = "Descripción:";
            // 
            // txbDescription
            // 
            txbDescription.Location = new Point(105, 131);
            txbDescription.Name = "txbDescription";
            txbDescription.Size = new Size(591, 96);
            txbDescription.TabIndex = 109;
            txbDescription.Text = "";
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(540, 237);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 29);
            btnAceptar.TabIndex = 110;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(621, 237);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 29);
            btnCancelar.TabIndex = 111;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FrmLabelLegendAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(711, 278);
            Controls.Add(btnAceptar);
            Controls.Add(btnCancelar);
            Controls.Add(txbDescription);
            Controls.Add(label1);
            Controls.Add(txbId);
            Controls.Add(lblId);
            Controls.Add(cboActive);
            Controls.Add(lblActivo);
            Controls.Add(label2);
            Controls.Add(txbLabelLegend2);
            Controls.Add(label3);
            Controls.Add(txbLabelLegend);
            Controls.Add(lblNombre);
            Controls.Add(lblTitulo);
            Controls.Add(lblObliNombre);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmLabelLegendAdd";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Añadir leyenda de etiqueta";
            Load += FrmLabelLegendAdd_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public TextBox txbLabelLegend2;
        private Label label3;
        public TextBox txbLabelLegend;
        private Label lblNombre;
        public Label lblTitulo;
        private Label lblObliNombre;
        public TextBox txbId;
        private Label lblId;
        public ComboBox cboActive;
        private Label lblActivo;
        private Label label2;
        private Label label1;
        public RichTextBox txbDescription;
        private Button btnAceptar;
        private Button btnCancelar;
    }
}
