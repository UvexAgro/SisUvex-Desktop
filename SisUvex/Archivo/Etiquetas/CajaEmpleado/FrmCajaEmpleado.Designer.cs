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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            btnImprimir = new Button();
            lblNombre = new Label();
            nudCantidad = new NumericUpDown();
            lblCodigoEmp = new Label();
            txbCodigoEmp = new TextBox();
            lblCantidad = new Label();
            txbNombreEmpleado = new TextBox();
            btnBuscar = new Button();
            dgvEmpleados = new DataGridView();
            btnBuscarCodigo = new Button();
            btnSeleccionar = new Button();
            lblLastNameMat = new Label();
            lblLastNamePat = new Label();
            lblName = new Label();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvEmpleados).BeginInit();
            SuspendLayout();
            // 
            // btnImprimir
            // 
            btnImprimir.Font = new Font("Segoe UI", 14F);
            btnImprimir.Location = new Point(272, 129);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(96, 33);
            btnImprimir.TabIndex = 10;
            btnImprimir.Text = "Imprimir";
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
            nudCantidad.Font = new Font("Segoe UI", 14F);
            nudCantidad.Location = new Point(218, 129);
            nudCantidad.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            nudCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(48, 32);
            nudCantidad.TabIndex = 8;
            nudCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nudCantidad.KeyPress += nudCantidad_KeyPress;
            // 
            // lblCodigoEmp
            // 
            lblCodigoEmp.AutoSize = true;
            lblCodigoEmp.Font = new Font("Segoe UI", 14F);
            lblCodigoEmp.Location = new Point(12, 90);
            lblCodigoEmp.Name = "lblCodigoEmp";
            lblCodigoEmp.Size = new Size(166, 25);
            lblCodigoEmp.TabIndex = 7;
            lblCodigoEmp.Text = "Código empleado:";
            // 
            // txbCodigoEmp
            // 
            txbCodigoEmp.Font = new Font("Segoe UI", 14F);
            txbCodigoEmp.Location = new Point(184, 87);
            txbCodigoEmp.MaxLength = 6;
            txbCodigoEmp.Name = "txbCodigoEmp";
            txbCodigoEmp.Size = new Size(173, 32);
            txbCodigoEmp.TabIndex = 6;
            txbCodigoEmp.KeyPress += txbCodigoEmp_KeyPress;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Font = new Font("Segoe UI", 14F);
            lblCantidad.Location = new Point(12, 131);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(200, 25);
            lblCantidad.TabIndex = 11;
            lblCantidad.Text = "Cantidad de etiquetas:";
            // 
            // txbNombreEmpleado
            // 
            txbNombreEmpleado.Font = new Font("Segoe UI", 9F);
            txbNombreEmpleado.Location = new Point(12, 168);
            txbNombreEmpleado.MaxLength = 6;
            txbNombreEmpleado.Name = "txbNombreEmpleado";
            txbNombreEmpleado.Size = new Size(325, 23);
            txbNombreEmpleado.TabIndex = 13;
            // 
            // btnBuscar
            // 
            btnBuscar.Font = new Font("Segoe UI", 9F);
            btnBuscar.Location = new Point(343, 167);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(107, 23);
            btnBuscar.TabIndex = 14;
            btnBuscar.Text = "Buscar empleado";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
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
            dgvEmpleados.Location = new Point(12, 197);
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
            dgvEmpleados.Size = new Size(534, 238);
            dgvEmpleados.TabIndex = 15;
            dgvEmpleados.MouseDoubleClick += dgvEmpleados_MouseDoubleClick;
            // 
            // btnBuscarCodigo
            // 
            btnBuscarCodigo.Font = new Font("Segoe UI", 14F);
            btnBuscarCodigo.Image = Properties.Resources.BuscarLupa1;
            btnBuscarCodigo.Location = new Point(363, 87);
            btnBuscarCodigo.Name = "btnBuscarCodigo";
            btnBuscarCodigo.Size = new Size(31, 33);
            btnBuscarCodigo.TabIndex = 27;
            btnBuscarCodigo.UseVisualStyleBackColor = true;
            btnBuscarCodigo.Click += btnBuscarCodigo_Click;
            // 
            // btnSeleccionar
            // 
            btnSeleccionar.Font = new Font("Segoe UI", 9F);
            btnSeleccionar.Location = new Point(454, 168);
            btnSeleccionar.Name = "btnSeleccionar";
            btnSeleccionar.Size = new Size(91, 23);
            btnSeleccionar.TabIndex = 28;
            btnSeleccionar.Text = "Seleccionar";
            btnSeleccionar.UseVisualStyleBackColor = true;
            btnSeleccionar.Click += btnSeleccionar_Click;
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
            // FrmCajaEmpleado
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(557, 447);
            Controls.Add(lblLastNameMat);
            Controls.Add(lblLastNamePat);
            Controls.Add(lblName);
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
            MinimumSize = new Size(573, 486);
            Name = "FrmCajaEmpleado";
            Text = "Imprimir caja por código de empleado";
            Load += FrmCajaEmpleado_Load;
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvEmpleados).EndInit();
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
    }
}