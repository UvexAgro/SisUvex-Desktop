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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dgvEmpleados = new DataGridView();
            btnBuscar = new Button();
            txbNombreEmpleado = new TextBox();
            lblCantidad = new Label();
            btnImprimir = new Button();
            lblNombre = new Label();
            nudCantidad = new NumericUpDown();
            lblCodigoEmp = new Label();
            txbCodigoEmp = new TextBox();
            label1 = new Label();
            btnBuscarCodigo = new Button();
            btnSeleccionar = new Button();
            lblApellido = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvEmpleados).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            SuspendLayout();
            // 
            // dgvEmpleados
            // 
            dgvEmpleados.AllowUserToAddRows = false;
            dgvEmpleados.AllowUserToDeleteRows = false;
            dgvEmpleados.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dgvEmpleados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvEmpleados.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvEmpleados.BackgroundColor = SystemColors.ControlLightLight;
            dgvEmpleados.BorderStyle = BorderStyle.Fixed3D;
            dgvEmpleados.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvEmpleados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvEmpleados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvEmpleados.EnableHeadersVisualStyles = false;
            dgvEmpleados.ImeMode = ImeMode.NoControl;
            dgvEmpleados.Location = new Point(12, 180);
            dgvEmpleados.Name = "dgvEmpleados";
            dgvEmpleados.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvEmpleados.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvEmpleados.RowHeadersVisible = false;
            dgvEmpleados.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvEmpleados.RowTemplate.Height = 25;
            dgvEmpleados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmpleados.Size = new Size(466, 318);
            dgvEmpleados.TabIndex = 24;
            dgvEmpleados.CellContentDoubleClick += dgvEmpleados_CellContentDoubleClick;
            // 
            // btnBuscar
            // 
            btnBuscar.Font = new Font("Segoe UI", 9F);
            btnBuscar.Location = new Point(274, 151);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(107, 23);
            btnBuscar.TabIndex = 23;
            btnBuscar.Text = "Buscar empleado";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txbNombreEmpleado
            // 
            txbNombreEmpleado.Font = new Font("Segoe UI", 9F);
            txbNombreEmpleado.Location = new Point(12, 151);
            txbNombreEmpleado.MaxLength = 70;
            txbNombreEmpleado.Name = "txbNombreEmpleado";
            txbNombreEmpleado.Size = new Size(256, 23);
            txbNombreEmpleado.TabIndex = 22;
            txbNombreEmpleado.KeyPress += txbNombreEmpleado_KeyPress;
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
            btnBuscarCodigo.Image = Properties.Resources.BuscarLupa1;
            btnBuscarCodigo.Location = new Point(331, 62);
            btnBuscarCodigo.Name = "btnBuscarCodigo";
            btnBuscarCodigo.Size = new Size(31, 33);
            btnBuscarCodigo.TabIndex = 26;
            btnBuscarCodigo.UseVisualStyleBackColor = true;
            btnBuscarCodigo.Click += btnBuscarCodigo_Click;
            // 
            // btnSeleccionar
            // 
            btnSeleccionar.Font = new Font("Segoe UI", 9F);
            btnSeleccionar.Location = new Point(387, 151);
            btnSeleccionar.Name = "btnSeleccionar";
            btnSeleccionar.Size = new Size(91, 23);
            btnSeleccionar.TabIndex = 27;
            btnSeleccionar.Text = "Seleccionar";
            btnSeleccionar.UseVisualStyleBackColor = true;
            btnSeleccionar.Click += btnSeleccionar_Click;
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
            // FrmNombreYCodigo2x1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(490, 510);
            Controls.Add(lblApellido);
            Controls.Add(btnSeleccionar);
            Controls.Add(btnBuscarCodigo);
            Controls.Add(dgvEmpleados);
            Controls.Add(btnBuscar);
            Controls.Add(txbNombreEmpleado);
            Controls.Add(lblCantidad);
            Controls.Add(btnImprimir);
            Controls.Add(lblNombre);
            Controls.Add(nudCantidad);
            Controls.Add(lblCodigoEmp);
            Controls.Add(txbCodigoEmp);
            Controls.Add(label1);
            Name = "FrmNombreYCodigo2x1";
            Text = "Imprimir código de empleado con nombre QR";
            ((System.ComponentModel.ISupportInitialize)dgvEmpleados).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public DataGridView dgvEmpleados;
        private Button btnBuscar;
        private TextBox txbNombreEmpleado;
        private Label lblCantidad;
        private Button btnImprimir;
        private Label lblNombre;
        private NumericUpDown nudCantidad;
        private Label lblCodigoEmp;
        private TextBox txbCodigoEmp;
        private Label label1;
        private Button btnBuscarCodigo;
        private Button btnSeleccionar;
        private Label lblApellido;
    }
}