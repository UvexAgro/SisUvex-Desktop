
using System.Windows.Forms;

namespace SisUvex.Catalogos.Contratista
{
    partial class FrmContratistaAñadir
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmContratistaAñadir));
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
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Arial Black", 16F);
            lblTitulo.Location = new Point(9, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(235, 31);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Añadir contratista";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 12F);
            lblNombre.Location = new Point(12, 58);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(71, 21);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre:";
            // 
            // txbNombre
            // 
            txbNombre.Font = new Font("Segoe UI", 12F);
            txbNombre.Location = new Point(89, 55);
            txbNombre.MaxLength = 20;
            txbNombre.Name = "txbNombre";
            txbNombre.Size = new Size(380, 29);
            txbNombre.TabIndex = 1;
            // 
            // txbId
            // 
            txbId.Enabled = false;
            txbId.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbId.Location = new Point(423, 12);
            txbId.Name = "txbId";
            txbId.Size = new Size(46, 29);
            txbId.TabIndex = 0;
            txbId.TextAlign = HorizontalAlignment.Center;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 12F);
            lblId.Location = new Point(395, 15);
            lblId.Name = "lblId";
            lblId.Size = new Size(26, 21);
            lblId.TabIndex = 6;
            lblId.Text = "Id:";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(394, 97);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 29);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(313, 97);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 29);
            btnAceptar.TabIndex = 2;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // lblActivo
            // 
            lblActivo.AutoSize = true;
            lblActivo.Font = new Font("Segoe UI", 12F);
            lblActivo.Location = new Point(286, 15);
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
            cboActivo.Location = new Point(342, 12);
            cboActivo.Name = "cboActivo";
            cboActivo.Size = new Size(46, 29);
            cboActivo.TabIndex = 4;
            // 
            // lblObliCom
            // 
            lblObliCom.AutoSize = true;
            lblObliCom.ForeColor = Color.Crimson;
            lblObliCom.Location = new Point(466, 55);
            lblObliCom.Name = "lblObliCom";
            lblObliCom.Size = new Size(12, 15);
            lblObliCom.TabIndex = 13;
            lblObliCom.Text = "*";
            // 
            // FrmContratistaAñadir
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(481, 143);
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
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FrmContratistaAñadir";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Añadir contratista";
            FormClosing += FrmContratistaAñadir_FormClosing;
            Load += FrmContratistaAñadir_Load;
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
    }
}