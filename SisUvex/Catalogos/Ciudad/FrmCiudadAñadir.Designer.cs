
using System.Windows.Forms;

namespace SisUvex.Catalogos.Ciudad
{
    partial class FrmCiudadAñadir
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
            lblNomCiudad = new Label();
            txbNomCiudad = new TextBox();
            txbId = new TextBox();
            lblId = new Label();
            btnCancelar = new Button();
            btnAceptar = new Button();
            lblActivo = new Label();
            cboActivo = new ComboBox();
            lblNomEstado = new Label();
            txbNomEstado = new TextBox();
            txbNomPais = new TextBox();
            lblNomPais = new Label();
            lblObliCiudad = new Label();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Arial Black", 16F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitulo.Location = new Point(9, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(182, 31);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Añadir ciudad";
            // 
            // lblNomCiudad
            // 
            lblNomCiudad.AutoSize = true;
            lblNomCiudad.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblNomCiudad.Location = new Point(12, 58);
            lblNomCiudad.Name = "lblNomCiudad";
            lblNomCiudad.Size = new Size(121, 21);
            lblNomCiudad.TabIndex = 1;
            lblNomCiudad.Text = "Nombre ciudad:";
            // 
            // txbNomCiudad
            // 
            txbNomCiudad.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbNomCiudad.Location = new Point(139, 55);
            txbNomCiudad.MaxLength = 50;
            txbNomCiudad.Name = "txbNomCiudad";
            txbNomCiudad.Size = new Size(357, 29);
            txbNomCiudad.TabIndex = 2;
            // 
            // txbId
            // 
            txbId.Enabled = false;
            txbId.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txbId.Location = new Point(450, 12);
            txbId.Name = "txbId";
            txbId.Size = new Size(46, 29);
            txbId.TabIndex = 5;
            txbId.TextAlign = HorizontalAlignment.Center;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblId.Location = new Point(422, 15);
            lblId.Name = "lblId";
            lblId.Size = new Size(26, 21);
            lblId.TabIndex = 6;
            lblId.Text = "Id:";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(422, 160);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 29);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(341, 160);
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
            lblActivo.Location = new Point(313, 15);
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
            cboActivo.Location = new Point(369, 12);
            cboActivo.Name = "cboActivo";
            cboActivo.Size = new Size(46, 29);
            cboActivo.TabIndex = 11;
            // 
            // lblNomEstado
            // 
            lblNomEstado.AutoSize = true;
            lblNomEstado.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblNomEstado.Location = new Point(12, 93);
            lblNomEstado.Name = "lblNomEstado";
            lblNomEstado.Size = new Size(121, 21);
            lblNomEstado.TabIndex = 12;
            lblNomEstado.Text = "Nombre estado:";
            // 
            // txbNomEstado
            // 
            txbNomEstado.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbNomEstado.Location = new Point(139, 90);
            txbNomEstado.MaxLength = 30;
            txbNomEstado.Name = "txbNomEstado";
            txbNomEstado.Size = new Size(357, 29);
            txbNomEstado.TabIndex = 13;
            // 
            // txbNomPais
            // 
            txbNomPais.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbNomPais.Location = new Point(139, 125);
            txbNomPais.MaxLength = 30;
            txbNomPais.Name = "txbNomPais";
            txbNomPais.Size = new Size(357, 29);
            txbNomPais.TabIndex = 14;
            // 
            // lblNomPais
            // 
            lblNomPais.AutoSize = true;
            lblNomPais.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblNomPais.Location = new Point(12, 128);
            lblNomPais.Name = "lblNomPais";
            lblNomPais.Size = new Size(103, 21);
            lblNomPais.TabIndex = 15;
            lblNomPais.Text = "Nombre país:";
            // 
            // lblObliCiudad
            // 
            lblObliCiudad.AutoSize = true;
            lblObliCiudad.ForeColor = Color.Crimson;
            lblObliCiudad.Location = new Point(494, 58);
            lblObliCiudad.Name = "lblObliCiudad";
            lblObliCiudad.Size = new Size(12, 15);
            lblObliCiudad.TabIndex = 16;
            lblObliCiudad.Text = "*";
            // 
            // FrmCiudadAñadir
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(508, 195);
            Controls.Add(lblNomPais);
            Controls.Add(txbNomPais);
            Controls.Add(txbNomEstado);
            Controls.Add(lblNomEstado);
            Controls.Add(cboActivo);
            Controls.Add(btnAceptar);
            Controls.Add(btnCancelar);
            Controls.Add(txbId);
            Controls.Add(txbNomCiudad);
            Controls.Add(lblNomCiudad);
            Controls.Add(lblTitulo);
            Controls.Add(lblId);
            Controls.Add(lblActivo);
            Controls.Add(lblObliCiudad);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmCiudadAñadir";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Añadir ciudad";
            FormClosing += FrmCiudadAñadir_FormClosing;
            Load += FrmCiudadAñadir_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblNomCiudad;
        private Label lblId;
        private Button btnCancelar;
        private Button btnAceptar;
        private TextBox textBox1;
        private Label lblNomPais;
        private Label lblActivo;
        public Label lblTitulo;
        public TextBox txbNomCiudad;
        public TextBox txbId;
        public ComboBox cboActivo;
        private Label lblNomEstado;
        public TextBox txbNomEstado;
        public TextBox txbNomPais;
        private Label lblObliCiudad;
    }
}