namespace SisUvex.Archivo.Etiquetas.CajaEmpleado
{
    partial class FrmCajaEmpleado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCajaEmpleado));
            btnImprimir = new Button();
            lblNombre = new Label();
            nudCantidad = new NumericUpDown();
            lblCodigoEmp = new Label();
            txbCodigoEmp = new TextBox();
            lblCantidad = new Label();
            btnBuscarCodigo = new Button();
            lblLastNameMat = new Label();
            lblLastNamePat = new Label();
            lblName = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            SuspendLayout();
            // 
            // btnImprimir
            // 
            btnImprimir.Font = new Font("Segoe UI", 14F);
            btnImprimir.Image = Properties.Resources.imprimirIcon32;
            btnImprimir.Location = new Point(299, 171);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(40, 40);
            btnImprimir.TabIndex = 3;
            btnImprimir.UseVisualStyleBackColor = true;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 14F);
            lblNombre.Location = new Point(12, 9);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(174, 25);
            lblNombre.TabIndex = 9;
            lblNombre.Text = "Nombre empleado:";
            // 
            // nudCantidad
            // 
            nudCantidad.Font = new Font("Segoe UI", 17F);
            nudCantidad.Location = new Point(215, 172);
            nudCantidad.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            nudCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(78, 38);
            nudCantidad.TabIndex = 2;
            nudCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nudCantidad.Enter += nudCantidad_Enter;
            nudCantidad.KeyPress += nudCantidad_KeyPress;
            // 
            // lblCodigoEmp
            // 
            lblCodigoEmp.AutoSize = true;
            lblCodigoEmp.Font = new Font("Segoe UI", 14F);
            lblCodigoEmp.Location = new Point(12, 106);
            lblCodigoEmp.Name = "lblCodigoEmp";
            lblCodigoEmp.Size = new Size(166, 25);
            lblCodigoEmp.TabIndex = 7;
            lblCodigoEmp.Text = "Código empleado:";
            // 
            // txbCodigoEmp
            // 
            txbCodigoEmp.Font = new Font("Segoe UI", 17F);
            txbCodigoEmp.Location = new Point(184, 103);
            txbCodigoEmp.MaxLength = 6;
            txbCodigoEmp.Name = "txbCodigoEmp";
            txbCodigoEmp.Size = new Size(109, 38);
            txbCodigoEmp.TabIndex = 0;
            txbCodigoEmp.Enter += txbCodigoEmp_Enter;
            txbCodigoEmp.KeyPress += txbCodigoEmp_KeyPress;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Font = new Font("Segoe UI", 14F);
            lblCantidad.Location = new Point(9, 174);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(200, 25);
            lblCantidad.TabIndex = 11;
            lblCantidad.Text = "Cantidad de etiquetas:";
            // 
            // btnBuscarCodigo
            // 
            btnBuscarCodigo.Font = new Font("Segoe UI", 14F);
            btnBuscarCodigo.Image = Properties.Resources.guardarIcon321;
            btnBuscarCodigo.Location = new Point(290, 102);
            btnBuscarCodigo.Name = "btnBuscarCodigo";
            btnBuscarCodigo.Size = new Size(40, 40);
            btnBuscarCodigo.TabIndex = 1;
            btnBuscarCodigo.UseVisualStyleBackColor = true;
            btnBuscarCodigo.Click += btnBuscarCodigo_Click;
            // 
            // lblLastNameMat
            // 
            lblLastNameMat.AutoSize = true;
            lblLastNameMat.Font = new Font("Segoe UI", 14F);
            lblLastNameMat.Location = new Point(184, 59);
            lblLastNameMat.Name = "lblLastNameMat";
            lblLastNameMat.Size = new Size(16, 25);
            lblLastNameMat.TabIndex = 34;
            lblLastNameMat.Text = ".";
            // 
            // lblLastNamePat
            // 
            lblLastNamePat.AutoSize = true;
            lblLastNamePat.Font = new Font("Segoe UI", 14F);
            lblLastNamePat.Location = new Point(184, 34);
            lblLastNamePat.Name = "lblLastNamePat";
            lblLastNamePat.Size = new Size(16, 25);
            lblLastNamePat.TabIndex = 33;
            lblLastNamePat.Text = ".";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 14F);
            lblName.Location = new Point(184, 9);
            lblName.Name = "lblName";
            lblName.Size = new Size(16, 25);
            lblName.TabIndex = 32;
            lblName.Text = ".";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 14F);
            button1.Image = Properties.Resources.buscarIcon32;
            button1.Location = new Point(345, 102);
            button1.Name = "button1";
            button1.Size = new Size(40, 40);
            button1.TabIndex = 35;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // FrmCajaEmpleado
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 192, 255);
            ClientSize = new Size(485, 237);
            Controls.Add(button1);
            Controls.Add(lblLastNameMat);
            Controls.Add(lblLastNamePat);
            Controls.Add(lblName);
            Controls.Add(lblCantidad);
            Controls.Add(btnImprimir);
            Controls.Add(lblNombre);
            Controls.Add(nudCantidad);
            Controls.Add(lblCodigoEmp);
            Controls.Add(txbCodigoEmp);
            Controls.Add(btnBuscarCodigo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FrmCajaEmpleado";
            Text = "Imprimir caja por código de empleado";
            Load += FrmCajaEmpleado_Load;
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnImprimir;
        private Label lblNombre;
        private NumericUpDown nudCantidad;
        private Label lblCodigoEmp;
        private TextBox txbCodigoEmp;
        private Label lblCantidad;
        private TextBox txbNombreEmpleado;
        private Button btnBuscar;
        public DataGridView dgvEmpleados;
        private Button btnBuscarCodigo;
        private Button btnSeleccionar;
        private Label lblLastNameMat;
        private Label lblLastNamePat;
        private Label lblName;
        private Button button1;
    }
}