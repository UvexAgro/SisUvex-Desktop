namespace SisUvex.Catalogos.Categoría
{
    partial class FrmCategoriaAñadir
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
            txbId = new TextBox();
            txbNombre = new TextBox();
            lblNombre = new Label();
            lblTitulo = new Label();
            lblId = new Label();
            lblObliNombre = new Label();
            btnAceptar = new Button();
            btnCancelar = new Button();
            cboActivo = new ComboBox();
            lblActivo = new Label();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // txbId
            // 
            txbId.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbId.Location = new Point(91, 43);
            txbId.MaxLength = 2;
            txbId.Name = "txbId";
            txbId.Size = new Size(46, 29);
            txbId.TabIndex = 55;
            txbId.TextAlign = HorizontalAlignment.Center;
            // 
            // txbNombre
            // 
            txbNombre.Font = new Font("Segoe UI", 12F);
            txbNombre.Location = new Point(91, 78);
            txbNombre.MaxLength = 15;
            txbNombre.Name = "txbNombre";
            txbNombre.Size = new Size(294, 29);
            txbNombre.TabIndex = 52;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 12F);
            lblNombre.Location = new Point(14, 81);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(71, 21);
            lblNombre.TabIndex = 54;
            lblNombre.Text = "Nombre:";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Arial Black", 16F);
            lblTitulo.Location = new Point(12, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(220, 31);
            lblTitulo.TabIndex = 53;
            lblTitulo.Text = "Añadir Categoría";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 12F);
            lblId.Location = new Point(59, 46);
            lblId.Name = "lblId";
            lblId.Size = new Size(26, 21);
            lblId.TabIndex = 56;
            lblId.Text = "Id:";
            // 
            // lblObliNombre
            // 
            lblObliNombre.AutoSize = true;
            lblObliNombre.ForeColor = Color.Crimson;
            lblObliNombre.Location = new Point(82, 81);
            lblObliNombre.Name = "lblObliNombre";
            lblObliNombre.Size = new Size(12, 15);
            lblObliNombre.TabIndex = 61;
            lblObliNombre.Text = "*";
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(229, 118);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 29);
            btnAceptar.TabIndex = 66;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(310, 118);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 29);
            btnCancelar.TabIndex = 67;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // cboActivo
            // 
            cboActivo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboActivo.Font = new Font("Segoe UI", 12F);
            cboActivo.FormattingEnabled = true;
            cboActivo.Items.AddRange(new object[] { "No", "Sí" });
            cboActivo.Location = new Point(339, 12);
            cboActivo.Name = "cboActivo";
            cboActivo.Size = new Size(46, 29);
            cboActivo.TabIndex = 69;
            // 
            // lblActivo
            // 
            lblActivo.AutoSize = true;
            lblActivo.Font = new Font("Segoe UI", 12F);
            lblActivo.Location = new Point(277, 15);
            lblActivo.Name = "lblActivo";
            lblActivo.Size = new Size(56, 21);
            lblActivo.TabIndex = 68;
            lblActivo.Text = "Activo:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Crimson;
            label1.Location = new Point(330, 12);
            label1.Name = "label1";
            label1.Size = new Size(12, 15);
            label1.TabIndex = 70;
            label1.Text = "*";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Crimson;
            label2.Location = new Point(82, 43);
            label2.Name = "label2";
            label2.Size = new Size(12, 15);
            label2.TabIndex = 71;
            label2.Text = "*";
            // 
            // FrmCategoriaAñadir
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(396, 161);
            Controls.Add(cboActivo);
            Controls.Add(btnAceptar);
            Controls.Add(btnCancelar);
            Controls.Add(txbId);
            Controls.Add(txbNombre);
            Controls.Add(lblNombre);
            Controls.Add(lblTitulo);
            Controls.Add(lblObliNombre);
            Controls.Add(label1);
            Controls.Add(lblActivo);
            Controls.Add(label2);
            Controls.Add(lblId);
            Name = "FrmCategoriaAñadir";
            Text = "Añadir categoría";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public TextBox txbId;
        public TextBox txbNombre;
        private Label lblNombre;
        public Label lblTitulo;
        private Label lblId;
        private Label lblObliNombre;
        private Button btnAceptar;
        private Button btnCancelar;
        public ComboBox cboActivo;
        private Label lblActivo;
        private Label label1;
        private Label label2;
    }
}