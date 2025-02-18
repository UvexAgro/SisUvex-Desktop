namespace SisUvex.Archivo.Etiquetas.FrmNombreYCodigo2x1
{
    partial class FrmNombreYCodigo2x1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNombreYCodigo2x1));
            lblCantidad = new Label();
            btnImprimir = new Button();
            lblNombre = new Label();
            nudCantidad = new NumericUpDown();
            lblCodigoEmp = new Label();
            txbCodigoEmp = new TextBox();
            label1 = new Label();
            btnBuscarCodigo = new Button();
            lblApellido = new Label();
            btnSelectEmployeeFrm = new Button();
            lblApellido2 = new Label();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            SuspendLayout();
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Font = new Font("Segoe UI", 14F);
            lblCantidad.Location = new Point(12, 191);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(200, 25);
            lblCantidad.TabIndex = 21;
            lblCantidad.Text = "Cantidad de etiquetas:";
            // 
            // btnImprimir
            // 
            btnImprimir.BackgroundImageLayout = ImageLayout.Stretch;
            btnImprimir.Font = new Font("Segoe UI", 14F);
            btnImprimir.Image = Properties.Resources.imprimirIcon321;
            btnImprimir.Location = new Point(297, 183);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(40, 40);
            btnImprimir.TabIndex = 4;
            btnImprimir.UseVisualStyleBackColor = true;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            lblNombre.Location = new Point(186, 14);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(17, 25);
            lblNombre.TabIndex = 19;
            lblNombre.Text = ".";
            // 
            // nudCantidad
            // 
            nudCantidad.Font = new Font("Segoe UI", 17F);
            nudCantidad.Location = new Point(220, 184);
            nudCantidad.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            nudCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(71, 38);
            nudCantidad.TabIndex = 3;
            nudCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nudCantidad.Enter += nudCantidad_Enter;
            nudCantidad.KeyPress += nudCantidad_KeyPress;
            // 
            // lblCodigoEmp
            // 
            lblCodigoEmp.AutoSize = true;
            lblCodigoEmp.Font = new Font("Segoe UI", 14F);
            lblCodigoEmp.Location = new Point(14, 107);
            lblCodigoEmp.Name = "lblCodigoEmp";
            lblCodigoEmp.Size = new Size(166, 25);
            lblCodigoEmp.TabIndex = 17;
            lblCodigoEmp.Text = "Código empleado:";
            // 
            // txbCodigoEmp
            // 
            txbCodigoEmp.Font = new Font("Segoe UI", 17F);
            txbCodigoEmp.Location = new Point(186, 100);
            txbCodigoEmp.MaxLength = 6;
            txbCodigoEmp.Name = "txbCodigoEmp";
            txbCodigoEmp.Size = new Size(105, 38);
            txbCodigoEmp.TabIndex = 0;
            txbCodigoEmp.Enter += txbCodigoEmp_Enter;
            txbCodigoEmp.KeyPress += txbCodigoEmp_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(14, 14);
            label1.Name = "label1";
            label1.Size = new Size(174, 25);
            label1.TabIndex = 25;
            label1.Text = "Nombre empleado:";
            // 
            // btnBuscarCodigo
            // 
            btnBuscarCodigo.Font = new Font("Segoe UI", 14F);
            btnBuscarCodigo.Image = Properties.Resources.buscarIcon32;
            btnBuscarCodigo.Location = new Point(334, 99);
            btnBuscarCodigo.Name = "btnBuscarCodigo";
            btnBuscarCodigo.Size = new Size(40, 40);
            btnBuscarCodigo.TabIndex = 2;
            btnBuscarCodigo.UseVisualStyleBackColor = true;
            btnBuscarCodigo.Click += btnBuscarCodigo_Click;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            lblApellido.Location = new Point(186, 39);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(17, 25);
            lblApellido.TabIndex = 28;
            lblApellido.Text = ".";
            // 
            // btnSelectEmployeeFrm
            // 
            btnSelectEmployeeFrm.BackgroundImageLayout = ImageLayout.None;
            btnSelectEmployeeFrm.Font = new Font("Segoe UI", 14F);
            btnSelectEmployeeFrm.Image = Properties.Resources.guardarIcon321;
            btnSelectEmployeeFrm.Location = new Point(289, 99);
            btnSelectEmployeeFrm.Name = "btnSelectEmployeeFrm";
            btnSelectEmployeeFrm.Size = new Size(40, 40);
            btnSelectEmployeeFrm.TabIndex = 1;
            btnSelectEmployeeFrm.UseVisualStyleBackColor = true;
            btnSelectEmployeeFrm.Click += btnSelectEmployeeFrm_Click;
            // 
            // lblApellido2
            // 
            lblApellido2.AutoSize = true;
            lblApellido2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            lblApellido2.Location = new Point(186, 65);
            lblApellido2.Name = "lblApellido2";
            lblApellido2.Size = new Size(17, 25);
            lblApellido2.TabIndex = 29;
            lblApellido2.Text = ".";
            // 
            // FrmNombreYCodigo2x1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 255, 192);
            ClientSize = new Size(525, 244);
            Controls.Add(lblApellido2);
            Controls.Add(lblApellido);
            Controls.Add(lblCantidad);
            Controls.Add(btnImprimir);
            Controls.Add(lblNombre);
            Controls.Add(nudCantidad);
            Controls.Add(lblCodigoEmp);
            Controls.Add(txbCodigoEmp);
            Controls.Add(label1);
            Controls.Add(btnSelectEmployeeFrm);
            Controls.Add(btnBuscarCodigo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(541, 283);
            Name = "FrmNombreYCodigo2x1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Espárrago - Imprimir código de empleado con nombre QR";
            Load += FrmNombreYCodigo2x1_Load;
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblCantidad;
        private Button btnImprimir;
        private Label lblNombre;
        private NumericUpDown nudCantidad;
        private Label lblCodigoEmp;
        private TextBox txbCodigoEmp;
        private Label label1;
        private Button btnBuscarCodigo;
        private Label lblApellido;
        private Button button1;
        private Button btnSelectEmployeeFrm;
        private Label lblApellido2;
    }
}