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
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            SuspendLayout();
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Font = new Font("Segoe UI", 14F);
            lblCantidad.Location = new Point(14, 104);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(200, 25);
            lblCantidad.TabIndex = 21;
            lblCantidad.Text = "Cantidad de etiquetas:";
            // 
            // btnImprimir
            // 
            btnImprimir.Font = new Font("Segoe UI", 14F);
            btnImprimir.Location = new Point(274, 101);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(96, 33);
            btnImprimir.TabIndex = 20;
            btnImprimir.Text = "Imprimir";
            btnImprimir.UseVisualStyleBackColor = true;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            lblNombre.Location = new Point(186, 9);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(0, 25);
            lblNombre.TabIndex = 19;
            // 
            // nudCantidad
            // 
            nudCantidad.Font = new Font("Segoe UI", 14F);
            nudCantidad.Location = new Point(220, 102);
            nudCantidad.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            nudCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(48, 32);
            nudCantidad.TabIndex = 18;
            nudCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nudCantidad.KeyPress += nudCantidad_KeyPress;
            // 
            // lblCodigoEmp
            // 
            lblCodigoEmp.AutoSize = true;
            lblCodigoEmp.Font = new Font("Segoe UI", 14F);
            lblCodigoEmp.Location = new Point(14, 65);
            lblCodigoEmp.Name = "lblCodigoEmp";
            lblCodigoEmp.Size = new Size(166, 25);
            lblCodigoEmp.TabIndex = 17;
            lblCodigoEmp.Text = "Código empleado:";
            // 
            // txbCodigoEmp
            // 
            txbCodigoEmp.Font = new Font("Segoe UI", 14F);
            txbCodigoEmp.Location = new Point(186, 62);
            txbCodigoEmp.MaxLength = 6;
            txbCodigoEmp.Name = "txbCodigoEmp";
            txbCodigoEmp.Size = new Size(139, 32);
            txbCodigoEmp.TabIndex = 16;
            txbCodigoEmp.KeyPress += txbCodigoEmp_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(14, 9);
            label1.Name = "label1";
            label1.Size = new Size(174, 25);
            label1.TabIndex = 25;
            label1.Text = "Nombre empleado:";
            // 
            // btnBuscarCodigo
            // 
            btnBuscarCodigo.Font = new Font("Segoe UI", 14F);
            btnBuscarCodigo.Location = new Point(371, 61);
            btnBuscarCodigo.Name = "btnBuscarCodigo";
            btnBuscarCodigo.Size = new Size(34, 33);
            btnBuscarCodigo.TabIndex = 26;
            btnBuscarCodigo.Text = "...";
            btnBuscarCodigo.UseVisualStyleBackColor = true;
            btnBuscarCodigo.Click += btnBuscarCodigo_Click;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            lblApellido.Location = new Point(186, 34);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(0, 25);
            lblApellido.TabIndex = 28;
            // 
            // btnSelectEmployeeFrm
            // 
            btnSelectEmployeeFrm.Font = new Font("Segoe UI", 14F);
            btnSelectEmployeeFrm.Image = Properties.Resources.BuscarLupa1;
            btnSelectEmployeeFrm.Location = new Point(331, 61);
            btnSelectEmployeeFrm.Name = "btnSelectEmployeeFrm";
            btnSelectEmployeeFrm.Size = new Size(34, 33);
            btnSelectEmployeeFrm.TabIndex = 29;
            btnSelectEmployeeFrm.UseVisualStyleBackColor = true;
            btnSelectEmployeeFrm.Click += btnSelectEmployeeFrm_Click;
            // 
            // FrmNombreYCodigo2x1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(525, 148);
            Controls.Add(btnSelectEmployeeFrm);
            Controls.Add(lblApellido);
            Controls.Add(btnBuscarCodigo);
            Controls.Add(lblCantidad);
            Controls.Add(btnImprimir);
            Controls.Add(lblNombre);
            Controls.Add(nudCantidad);
            Controls.Add(lblCodigoEmp);
            Controls.Add(txbCodigoEmp);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(541, 187);
            MinimumSize = new Size(541, 187);
            Name = "FrmNombreYCodigo2x1";
            Text = "Imprimir código de empleado con nombre QR";
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
    }
}