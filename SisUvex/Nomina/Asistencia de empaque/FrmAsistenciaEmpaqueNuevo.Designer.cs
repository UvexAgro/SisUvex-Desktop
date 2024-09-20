namespace SisUvex.Nomina.Asistencia_de_empaque
{
    partial class FrmAsistenciaEmpaqueNuevo
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
            dtpDia = new DateTimePicker();
            btnMostrar = new Button();
            lblExcel = new Label();
            lblHoja = new Label();
            cboHoja = new ComboBox();
            btnExaminar = new Button();
            txbExaminar = new TextBox();
            btnCancelar = new Button();
            btnAceptar = new Button();
            dgvLista = new DataGridView();
            ofdExcel = new OpenFileDialog();
            btnInstrucciones = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvLista).BeginInit();
            SuspendLayout();
            // 
            // dtpDia
            // 
            dtpDia.Location = new Point(52, 70);
            dtpDia.Name = "dtpDia";
            dtpDia.Size = new Size(254, 23);
            dtpDia.TabIndex = 24;
            // 
            // btnMostrar
            // 
            btnMostrar.Location = new Point(393, 41);
            btnMostrar.Name = "btnMostrar";
            btnMostrar.Size = new Size(75, 23);
            btnMostrar.TabIndex = 23;
            btnMostrar.Text = "Mostrar";
            btnMostrar.UseVisualStyleBackColor = true;
            btnMostrar.Click += btnMostrar_Click;
            // 
            // lblExcel
            // 
            lblExcel.AutoSize = true;
            lblExcel.Location = new Point(11, 17);
            lblExcel.Name = "lblExcel";
            lblExcel.Size = new Size(76, 15);
            lblExcel.TabIndex = 22;
            lblExcel.Text = "Ruta archivo:";
            // 
            // lblHoja
            // 
            lblHoja.AutoSize = true;
            lblHoja.Location = new Point(11, 44);
            lblHoja.Name = "lblHoja";
            lblHoja.Size = new Size(35, 15);
            lblHoja.TabIndex = 21;
            lblHoja.Text = "Hoja:";
            // 
            // cboHoja
            // 
            cboHoja.DropDownStyle = ComboBoxStyle.DropDownList;
            cboHoja.FormattingEnabled = true;
            cboHoja.Location = new Point(52, 41);
            cboHoja.Name = "cboHoja";
            cboHoja.Size = new Size(335, 23);
            cboHoja.TabIndex = 20;
            // 
            // btnExaminar
            // 
            btnExaminar.Location = new Point(393, 12);
            btnExaminar.Name = "btnExaminar";
            btnExaminar.Size = new Size(75, 23);
            btnExaminar.TabIndex = 19;
            btnExaminar.Text = "Examinar...";
            btnExaminar.UseVisualStyleBackColor = true;
            btnExaminar.Click += btnExaminar_Click;
            // 
            // txbExaminar
            // 
            txbExaminar.Location = new Point(93, 12);
            txbExaminar.Name = "txbExaminar";
            txbExaminar.Size = new Size(294, 23);
            txbExaminar.TabIndex = 18;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(393, 70);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 17;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(312, 70);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 16;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
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
            dgvLista.Location = new Point(11, 99);
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
            dgvLista.Size = new Size(604, 339);
            dgvLista.TabIndex = 15;
            // 
            // ofdExcel
            // 
            ofdExcel.Filter = "Archivos Excel (*.xlsx, *.xls)|*.xlsx;*.xls";
            ofdExcel.Title = "Seleccionar archivo de Excel";
            // 
            // btnInstrucciones
            // 
            btnInstrucciones.Location = new Point(525, 13);
            btnInstrucciones.Name = "btnInstrucciones";
            btnInstrucciones.Size = new Size(91, 23);
            btnInstrucciones.TabIndex = 25;
            btnInstrucciones.Text = "Instrucciones";
            btnInstrucciones.UseVisualStyleBackColor = true;
            btnInstrucciones.Click += btnInstrucciones_Click;
            // 
            // FrmAsistenciaEmpaqueNuevo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(628, 450);
            Controls.Add(btnInstrucciones);
            Controls.Add(dtpDia);
            Controls.Add(btnMostrar);
            Controls.Add(lblExcel);
            Controls.Add(lblHoja);
            Controls.Add(cboHoja);
            Controls.Add(btnExaminar);
            Controls.Add(txbExaminar);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(dgvLista);
            Name = "FrmAsistenciaEmpaqueNuevo";
            Text = "Registro de asistencia de empaque";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)dgvLista).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public DateTimePicker dtpDia;
        public Button btnMostrar;
        private Label lblExcel;
        private Label lblHoja;
        public ComboBox cboHoja;
        public Button btnExaminar;
        public TextBox txbExaminar;
        public Button btnCancelar;
        public Button btnAceptar;
        public DataGridView dgvLista;
        public OpenFileDialog ofdExcel;
        public Button btnInstrucciones;
    }
}