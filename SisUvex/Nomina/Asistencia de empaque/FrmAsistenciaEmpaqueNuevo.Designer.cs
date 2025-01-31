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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAsistenciaEmpaqueNuevo));
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
            dtpDia.TabIndex = 4;
            // 
            // btnMostrar
            // 
            btnMostrar.Location = new Point(393, 41);
            btnMostrar.Name = "btnMostrar";
            btnMostrar.Size = new Size(75, 23);
            btnMostrar.TabIndex = 3;
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
            cboHoja.TabIndex = 2;
            // 
            // btnExaminar
            // 
            btnExaminar.Location = new Point(393, 12);
            btnExaminar.Name = "btnExaminar";
            btnExaminar.Size = new Size(75, 23);
            btnExaminar.TabIndex = 1;
            btnExaminar.Text = "Examinar...";
            btnExaminar.UseVisualStyleBackColor = true;
            btnExaminar.Click += btnExaminar_Click;
            // 
            // txbExaminar
            // 
            txbExaminar.Location = new Point(93, 12);
            txbExaminar.Name = "txbExaminar";
            txbExaminar.Size = new Size(294, 23);
            txbExaminar.TabIndex = 0;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(393, 70);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(312, 70);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 5;
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
            dgvLista.Location = new Point(11, 99);
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
            dgvLista.Size = new Size(604, 339);
            dgvLista.TabIndex = 8;
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
            btnInstrucciones.TabIndex = 7;
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
            Icon = (Icon)resources.GetObject("$this.Icon");
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