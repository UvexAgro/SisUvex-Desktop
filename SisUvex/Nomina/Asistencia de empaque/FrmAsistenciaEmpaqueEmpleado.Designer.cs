namespace SisUvex.Nomina.Asistencia_de_empaque
{
    partial class FrmAsistenciaEmpaqueEmpleado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAsistenciaEmpaqueEmpleado));
            btnBuscar = new Button();
            dgvLista = new DataGridView();
            txbIdEmpleado = new TextBox();
            txbNombreEmpleado = new TextBox();
            btnBuscarAsistencias = new Button();
            lblCodigo = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvLista).BeginInit();
            SuspendLayout();
            // 
            // btnBuscar
            // 
            btnBuscar.Enabled = false;
            btnBuscar.Location = new Point(512, 12);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(113, 23);
            btnBuscar.TabIndex = 5;
            btnBuscar.Text = "Buscar empleado";
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // dgvLista
            // 
            dgvLista.AllowUserToAddRows = false;
            dgvLista.AllowUserToDeleteRows = false;
            dgvLista.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvLista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvLista.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvLista.BackgroundColor = SystemColors.ControlLightLight;
            dgvLista.BorderStyle = BorderStyle.Fixed3D;
            dgvLista.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvLista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvLista.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvLista.EnableHeadersVisualStyles = false;
            dgvLista.ImeMode = ImeMode.NoControl;
            dgvLista.Location = new Point(12, 70);
            dgvLista.Name = "dgvLista";
            dgvLista.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvLista.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvLista.RowHeadersVisible = false;
            dgvLista.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvLista.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLista.Size = new Size(613, 368);
            dgvLista.TabIndex = 5;
            // 
            // txbIdEmpleado
            // 
            txbIdEmpleado.Location = new Point(139, 12);
            txbIdEmpleado.MaxLength = 6;
            txbIdEmpleado.Name = "txbIdEmpleado";
            txbIdEmpleado.Size = new Size(60, 23);
            txbIdEmpleado.TabIndex = 0;
            txbIdEmpleado.KeyPress += txbIdEmpleado_KeyPress;
            // 
            // txbNombreEmpleado
            // 
            txbNombreEmpleado.Enabled = false;
            txbNombreEmpleado.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txbNombreEmpleado.Location = new Point(205, 12);
            txbNombreEmpleado.Name = "txbNombreEmpleado";
            txbNombreEmpleado.Size = new Size(301, 23);
            txbNombreEmpleado.TabIndex = 4;
            // 
            // btnBuscarAsistencias
            // 
            btnBuscarAsistencias.Location = new Point(12, 41);
            btnBuscarAsistencias.Name = "btnBuscarAsistencias";
            btnBuscarAsistencias.Size = new Size(117, 23);
            btnBuscarAsistencias.TabIndex = 4;
            btnBuscarAsistencias.Text = "Buscar asistencias";
            btnBuscarAsistencias.UseVisualStyleBackColor = true;
            btnBuscarAsistencias.Click += btnBuscarAsistencias_Click;
            // 
            // lblCodigo
            // 
            lblCodigo.AutoSize = true;
            lblCodigo.Location = new Point(12, 16);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(121, 15);
            lblCodigo.TabIndex = 33;
            lblCodigo.Text = "Código de empleado:";
            // 
            // FrmAsistenciaEmpaqueEmpleado
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(637, 450);
            Controls.Add(lblCodigo);
            Controls.Add(btnBuscarAsistencias);
            Controls.Add(txbNombreEmpleado);
            Controls.Add(txbIdEmpleado);
            Controls.Add(btnBuscar);
            Controls.Add(dgvLista);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmAsistenciaEmpaqueEmpleado";
            Text = "Consulta de asistencias por empleado";
            WindowState = FormWindowState.Maximized;
            Load += FrmAsistenciaEmpaqueEmpleado_Load;
            ((System.ComponentModel.ISupportInitialize)dgvLista).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Button btnBuscar;
        public DataGridView dgvLista;
        public Button btnBuscarAsistencias;
        public TextBox txbIdEmpleado;
        public TextBox txbNombreEmpleado;
        private Label lblCodigo;
    }
}