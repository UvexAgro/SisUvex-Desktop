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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
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
            btnBuscar.TabIndex = 29;
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
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvLista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvLista.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvLista.EnableHeadersVisualStyles = false;
            dgvLista.ImeMode = ImeMode.NoControl;
            dgvLista.Location = new Point(12, 70);
            dgvLista.Name = "dgvLista";
            dgvLista.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvLista.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvLista.RowHeadersVisible = false;
            dgvLista.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvLista.RowTemplate.Height = 25;
            dgvLista.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLista.Size = new Size(613, 368);
            dgvLista.TabIndex = 28;
            // 
            // txbIdEmpleado
            // 
            txbIdEmpleado.Location = new Point(139, 12);
            txbIdEmpleado.MaxLength = 6;
            txbIdEmpleado.Name = "txbIdEmpleado";
            txbIdEmpleado.Size = new Size(60, 23);
            txbIdEmpleado.TabIndex = 30;
            txbIdEmpleado.KeyPress += txbIdEmpleado_KeyPress;
            // 
            // txbNombreEmpleado
            // 
            txbNombreEmpleado.Enabled = false;
            txbNombreEmpleado.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txbNombreEmpleado.Location = new Point(205, 12);
            txbNombreEmpleado.Name = "txbNombreEmpleado";
            txbNombreEmpleado.Size = new Size(301, 23);
            txbNombreEmpleado.TabIndex = 31;
            // 
            // btnBuscarAsistencias
            // 
            btnBuscarAsistencias.Location = new Point(12, 41);
            btnBuscarAsistencias.Name = "btnBuscarAsistencias";
            btnBuscarAsistencias.Size = new Size(117, 23);
            btnBuscarAsistencias.TabIndex = 32;
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