using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;

namespace SisUvex.Catalogos.Cuadrilla
{
    partial class FrmCuadrillaAñadir
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
            lblContratista = new Label();
            txbId = new TextBox();
            lblId = new Label();
            btnCancelar = new Button();
            btnAceptar = new Button();
            btnTodoContratista = new Button();
            btnBuscarContratista = new Button();
            txbIdContratista = new TextBox();
            cboContratista = new ComboBox();
            lblObliContratista = new Label();
            lblObliId = new Label();
            txbName = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Arial Black", 16F);
            lblTitulo.Location = new Point(9, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(206, 31);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Añadir cuadrilla";
            // 
            // lblContratista
            // 
            lblContratista.AutoSize = true;
            lblContratista.Font = new Font("Segoe UI", 12F);
            lblContratista.Location = new Point(16, 122);
            lblContratista.Name = "lblContratista";
            lblContratista.Size = new Size(89, 21);
            lblContratista.TabIndex = 1;
            lblContratista.Text = "Contratista:";
            // 
            // txbId
            // 
            txbId.Enabled = false;
            txbId.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbId.Location = new Point(159, 49);
            txbId.Name = "txbId";
            txbId.Size = new Size(46, 29);
            txbId.TabIndex = 5;
            txbId.TextAlign = HorizontalAlignment.Center;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 12F);
            lblId.Location = new Point(0, 52);
            lblId.Name = "lblId";
            lblId.Size = new Size(155, 21);
            lblId.TabIndex = 6;
            lblId.Text = "Número de cuadrilla:";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(485, 155);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 29);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(404, 155);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 29);
            btnAceptar.TabIndex = 8;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnTodoContratista
            // 
            btnTodoContratista.Location = new Point(503, 120);
            btnTodoContratista.Name = "btnTodoContratista";
            btnTodoContratista.Size = new Size(57, 29);
            btnTodoContratista.TabIndex = 32;
            btnTodoContratista.Text = "Activos";
            btnTodoContratista.UseVisualStyleBackColor = true;
            btnTodoContratista.Click += btnTodoContratista_Click;
            // 
            // btnBuscarContratista
            // 
            btnBuscarContratista.Location = new Point(440, 120);
            btnBuscarContratista.Name = "btnBuscarContratista";
            btnBuscarContratista.Size = new Size(57, 29);
            btnBuscarContratista.TabIndex = 31;
            btnBuscarContratista.Text = "Buscar";
            btnBuscarContratista.UseVisualStyleBackColor = true;
            btnBuscarContratista.Click += btnBuscarContratista_Click;
            // 
            // txbIdContratista
            // 
            txbIdContratista.Enabled = false;
            txbIdContratista.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbIdContratista.Location = new Point(107, 119);
            txbIdContratista.Name = "txbIdContratista";
            txbIdContratista.Size = new Size(46, 29);
            txbIdContratista.TabIndex = 34;
            txbIdContratista.TextAlign = HorizontalAlignment.Center;
            // 
            // cboContratista
            // 
            cboContratista.Font = new Font("Segoe UI", 12F);
            cboContratista.FormattingEnabled = true;
            cboContratista.ItemHeight = 21;
            cboContratista.Location = new Point(159, 119);
            cboContratista.Name = "cboContratista";
            cboContratista.Size = new Size(275, 29);
            cboContratista.TabIndex = 30;
            cboContratista.TextChanged += cboContratista_TextChanged;
            cboContratista.MouseClick += cboContratista_MouseClick;
            // 
            // lblObliContratista
            // 
            lblObliContratista.AutoSize = true;
            lblObliContratista.ForeColor = Color.Crimson;
            lblObliContratista.Location = new Point(99, 119);
            lblObliContratista.Name = "lblObliContratista";
            lblObliContratista.Size = new Size(12, 15);
            lblObliContratista.TabIndex = 35;
            lblObliContratista.Text = "*";
            // 
            // lblObliId
            // 
            lblObliId.AutoSize = true;
            lblObliId.ForeColor = Color.Crimson;
            lblObliId.Location = new Point(150, 49);
            lblObliId.Name = "lblObliId";
            lblObliId.Size = new Size(12, 15);
            lblObliId.TabIndex = 13;
            lblObliId.Text = "*";
            // 
            // txbName
            // 
            txbName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbName.Location = new Point(159, 84);
            txbName.MaxLength = 15;
            txbName.Name = "txbName";
            txbName.Size = new Size(275, 29);
            txbName.TabIndex = 36;
            txbName.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(21, 87);
            label1.Name = "label1";
            label1.Size = new Size(134, 21);
            label1.TabIndex = 37;
            label1.Text = "Nombre cuadrilla:";
            // 
            // FrmCuadrillaAñadir
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(572, 196);
            Controls.Add(txbName);
            Controls.Add(btnTodoContratista);
            Controls.Add(btnBuscarContratista);
            Controls.Add(txbIdContratista);
            Controls.Add(cboContratista);
            Controls.Add(lblObliContratista);
            Controls.Add(btnAceptar);
            Controls.Add(btnCancelar);
            Controls.Add(txbId);
            Controls.Add(lblTitulo);
            Controls.Add(lblObliId);
            Controls.Add(lblContratista);
            Controls.Add(label1);
            Controls.Add(lblId);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmCuadrillaAñadir";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Añadir cuadrilla";
            FormClosing += FrmCuadrillaAñadir_FormClosing;
            Load += FrmCuadrillaAñadir_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblContratista;
        private Label lblId;
        private Button btnCancelar;
        private Button btnAceptar;
        public Label lblTitulo;
        public TextBox txbId;
        private Button btnTodoContratista;
        private Button btnBuscarContratista;
        public TextBox txbIdContratista;
        private ComboBox cboContratista;
        private Label lblObliContratista;
        private Label lblObliId;
        public TextBox txbName;
        private Label label1;
    }
}