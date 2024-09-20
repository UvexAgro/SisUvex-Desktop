using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;

namespace SisUvex.Catalogos.TipoMaterial
{
    partial class FrmTipoMaterialAñadir
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
            txbId = new TextBox();
            lblId = new Label();
            btnCancelar = new Button();
            btnAceptar = new Button();
            lblObliCom = new Label();
            txbLibras = new TextBox();
            lblLibras = new Label();
            label1 = new Label();
            cboCategoría = new ComboBox();
            lblCategoría = new Label();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Arial Black", 16F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitulo.Location = new Point(9, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(292, 31);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Añadir tipo de material";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblNombre.Location = new Point(12, 128);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(71, 21);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre:";
            // 
            // txbNombre
            // 
            txbNombre.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbNombre.Location = new Point(89, 125);
            txbNombre.MaxLength = 20;
            txbNombre.Name = "txbNombre";
            txbNombre.Size = new Size(332, 29);
            txbNombre.TabIndex = 0;
            // 
            // txbId
            // 
            txbId.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txbId.Location = new Point(89, 55);
            txbId.MaxLength = 3;
            txbId.Name = "txbId";
            txbId.Size = new Size(100, 29);
            txbId.TabIndex = 4;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblId.Location = new Point(57, 58);
            lblId.Name = "lblId";
            lblId.Size = new Size(26, 21);
            lblId.TabIndex = 6;
            lblId.Text = "Id:";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(367, 196);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 29);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(286, 196);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 29);
            btnAceptar.TabIndex = 2;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // lblObliCom
            // 
            lblObliCom.AutoSize = true;
            lblObliCom.ForeColor = Color.Crimson;
            lblObliCom.Location = new Point(80, 55);
            lblObliCom.Name = "lblObliCom";
            lblObliCom.Size = new Size(12, 15);
            lblObliCom.TabIndex = 13;
            lblObliCom.Text = "*";
            // 
            // txbLibras
            // 
            txbLibras.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbLibras.Location = new Point(89, 160);
            txbLibras.MaxLength = 8;
            txbLibras.Name = "txbLibras";
            txbLibras.Size = new Size(138, 29);
            txbLibras.TabIndex = 1;
            txbLibras.TextChanged += txbLibras_TextChanged;
            txbLibras.KeyPress += txbLibras_KeyPress;
            // 
            // lblLibras
            // 
            lblLibras.AutoSize = true;
            lblLibras.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblLibras.Location = new Point(28, 163);
            lblLibras.Name = "lblLibras";
            lblLibras.Size = new Size(55, 21);
            lblLibras.TabIndex = 15;
            lblLibras.Text = "Libras:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Crimson;
            label1.Location = new Point(80, 128);
            label1.Name = "label1";
            label1.Size = new Size(12, 15);
            label1.TabIndex = 16;
            label1.Text = "*";
            // 
            // cboCategoría
            // 
            cboCategoría.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategoría.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cboCategoría.FormattingEnabled = true;
            cboCategoría.Items.AddRange(new object[] { "OTRO", "PRESENTACIÓN", "CONTENEDOR", "MISCELÁNEA", "TARIMA" });
            cboCategoría.Location = new Point(89, 90);
            cboCategoría.Name = "cboCategoría";
            cboCategoría.Size = new Size(168, 29);
            cboCategoría.TabIndex = 1;
            // 
            // lblCategoría
            // 
            lblCategoría.AutoSize = true;
            lblCategoría.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblCategoría.Location = new Point(3, 93);
            lblCategoría.Name = "lblCategoría";
            lblCategoría.Size = new Size(80, 21);
            lblCategoría.TabIndex = 17;
            lblCategoría.Text = "Categoría:";
            // 
            // FrmTipoMaterialAñadir
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(455, 239);
            Controls.Add(lblCategoría);
            Controls.Add(cboCategoría);
            Controls.Add(txbLibras);
            Controls.Add(lblLibras);
            Controls.Add(btnAceptar);
            Controls.Add(btnCancelar);
            Controls.Add(txbId);
            Controls.Add(txbNombre);
            Controls.Add(lblNombre);
            Controls.Add(lblTitulo);
            Controls.Add(lblId);
            Controls.Add(label1);
            Controls.Add(lblObliCom);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmTipoMaterialAñadir";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Añadir tipo de material";
            FormClosing += FrmTipoMaterialAñadir_FormClosing;
            Load += FrmTipoMaterialAñadir_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblNombre;
        private Label lblId;
        private Button btnCancelar;
        private Button btnAceptar;
        private Label lblLibras;
        public Label lblTitulo;
        public TextBox txbNombre;
        public TextBox txbId;
        private Label lblObliCom;
        public TextBox txbLibras;
        private Label label1;
        private Label lblCategoría;
        public ComboBox cboCategoría;
    }
}