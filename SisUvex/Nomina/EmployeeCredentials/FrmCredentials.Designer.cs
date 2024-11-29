namespace SisUvex.Nomina.EmployeeCredentials
{
    partial class FrmCredentials
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
            lblLP = new Label();
            lblIngresoEntre = new Label();
            lblCodigoEmpleado = new Label();
            lblY = new Label();
            cboLP = new ComboBox();
            dtpFechaIngreso1 = new DateTimePicker();
            dtpFechaIngreso2 = new DateTimePicker();
            txbCodigoEmpleado = new TextBox();
            btnGenerarListado = new Button();
            btnAgregarListado = new Button();
            btnCargarCredenciales = new Button();
            pnlPrincipal = new Panel();
            dataGridView1 = new DataGridView();
            btnRegisterAsPrinterCards = new Button();
            chbSelectAll = new CheckBox();
            pnlPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // lblLP
            // 
            lblLP.AutoSize = true;
            lblLP.Location = new Point(47, 12);
            lblLP.Name = "lblLP";
            lblLP.Size = new Size(86, 15);
            lblLP.TabIndex = 0;
            lblLP.Text = "Lugar de pago:";
            // 
            // lblIngresoEntre
            // 
            lblIngresoEntre.AutoSize = true;
            lblIngresoEntre.Location = new Point(54, 40);
            lblIngresoEntre.Name = "lblIngresoEntre";
            lblIngresoEntre.Size = new Size(79, 15);
            lblIngresoEntre.TabIndex = 1;
            lblIngresoEntre.Text = "Ingreso entre:";
            // 
            // lblCodigoEmpleado
            // 
            lblCodigoEmpleado.AutoSize = true;
            lblCodigoEmpleado.Location = new Point(12, 71);
            lblCodigoEmpleado.Name = "lblCodigoEmpleado";
            lblCodigoEmpleado.Size = new Size(121, 15);
            lblCodigoEmpleado.TabIndex = 2;
            lblCodigoEmpleado.Text = "Código de empleado:";
            // 
            // lblY
            // 
            lblY.AutoSize = true;
            lblY.Location = new Point(426, 281);
            lblY.Name = "lblY";
            lblY.Size = new Size(13, 15);
            lblY.TabIndex = 3;
            lblY.Text = "y";
            // 
            // cboLP
            // 
            cboLP.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLP.FormattingEnabled = true;
            cboLP.Location = new Point(139, 9);
            cboLP.Name = "cboLP";
            cboLP.Size = new Size(303, 23);
            cboLP.TabIndex = 4;
            // 
            // dtpFechaIngreso1
            // 
            dtpFechaIngreso1.Format = DateTimePickerFormat.Short;
            dtpFechaIngreso1.Location = new Point(139, 38);
            dtpFechaIngreso1.Name = "dtpFechaIngreso1";
            dtpFechaIngreso1.Size = new Size(95, 23);
            dtpFechaIngreso1.TabIndex = 5;
            // 
            // dtpFechaIngreso2
            // 
            dtpFechaIngreso2.Format = DateTimePickerFormat.Short;
            dtpFechaIngreso2.Location = new Point(240, 38);
            dtpFechaIngreso2.Name = "dtpFechaIngreso2";
            dtpFechaIngreso2.Size = new Size(95, 23);
            dtpFechaIngreso2.TabIndex = 6;
            // 
            // txbCodigoEmpleado
            // 
            txbCodigoEmpleado.Location = new Point(139, 67);
            txbCodigoEmpleado.MaxLength = 6;
            txbCodigoEmpleado.Name = "txbCodigoEmpleado";
            txbCodigoEmpleado.Size = new Size(96, 23);
            txbCodigoEmpleado.TabIndex = 7;
            txbCodigoEmpleado.KeyPress += txbCodigoEmpleado_KeyPress;
            // 
            // btnGenerarListado
            // 
            btnGenerarListado.Location = new Point(341, 38);
            btnGenerarListado.Name = "btnGenerarListado";
            btnGenerarListado.Size = new Size(101, 23);
            btnGenerarListado.TabIndex = 8;
            btnGenerarListado.Text = "Generar listado";
            btnGenerarListado.UseVisualStyleBackColor = true;
            btnGenerarListado.Click += btnGenerarListado_Click;
            // 
            // btnAgregarListado
            // 
            btnAgregarListado.Location = new Point(239, 66);
            btnAgregarListado.Name = "btnAgregarListado";
            btnAgregarListado.Size = new Size(113, 23);
            btnAgregarListado.TabIndex = 9;
            btnAgregarListado.Text = "Agregar al listado";
            btnAgregarListado.UseVisualStyleBackColor = true;
            btnAgregarListado.Click += btnAgregarListado_Click;
            // 
            // btnCargarCredenciales
            // 
            btnCargarCredenciales.Location = new Point(139, 111);
            btnCargarCredenciales.Name = "btnCargarCredenciales";
            btnCargarCredenciales.Size = new Size(55, 23);
            btnCargarCredenciales.TabIndex = 10;
            btnCargarCredenciales.Text = "Cargar";
            btnCargarCredenciales.UseVisualStyleBackColor = true;
            btnCargarCredenciales.Click += btnCargarCredenciales_Click;
            // 
            // pnlPrincipal
            // 
            pnlPrincipal.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlPrincipal.BackColor = SystemColors.ActiveCaption;
            pnlPrincipal.BorderStyle = BorderStyle.Fixed3D;
            pnlPrincipal.Controls.Add(dataGridView1);
            pnlPrincipal.Location = new Point(12, 140);
            pnlPrincipal.Name = "pnlPrincipal";
            pnlPrincipal.Size = new Size(858, 352);
            pnlPrincipal.TabIndex = 11;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(-2, -2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView1.Size = new Size(858, 357);
            dataGridView1.TabIndex = 0;
            // 
            // btnRegisterAsPrinterCards
            // 
            btnRegisterAsPrinterCards.Location = new Point(200, 111);
            btnRegisterAsPrinterCards.Name = "btnRegisterAsPrinterCards";
            btnRegisterAsPrinterCards.Size = new Size(125, 23);
            btnRegisterAsPrinterCards.TabIndex = 12;
            btnRegisterAsPrinterCards.Text = "Registrar impresión";
            btnRegisterAsPrinterCards.UseVisualStyleBackColor = true;
            btnRegisterAsPrinterCards.Click += btnRegisterAsPrinterCards_Click;
            // 
            // chbSelectAll
            // 
            chbSelectAll.AutoSize = true;
            chbSelectAll.Location = new Point(19, 115);
            chbSelectAll.Name = "chbSelectAll";
            chbSelectAll.Size = new Size(114, 19);
            chbSelectAll.TabIndex = 13;
            chbSelectAll.Text = "Seleccionar todo";
            chbSelectAll.UseVisualStyleBackColor = true;
            chbSelectAll.CheckedChanged += chbSelectAll_CheckedChanged;
            // 
            // FrmCredentials
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 504);
            Controls.Add(chbSelectAll);
            Controls.Add(btnRegisterAsPrinterCards);
            Controls.Add(pnlPrincipal);
            Controls.Add(btnCargarCredenciales);
            Controls.Add(btnAgregarListado);
            Controls.Add(btnGenerarListado);
            Controls.Add(txbCodigoEmpleado);
            Controls.Add(dtpFechaIngreso2);
            Controls.Add(dtpFechaIngreso1);
            Controls.Add(cboLP);
            Controls.Add(lblY);
            Controls.Add(lblCodigoEmpleado);
            Controls.Add(lblIngresoEntre);
            Controls.Add(lblLP);
            Name = "FrmCredentials";
            Text = "Impresión de credenciales";
            WindowState = FormWindowState.Maximized;
            Load += FrmCredentials_Load;
            pnlPrincipal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblLP;
        private Label lblIngresoEntre;
        private Label lblCodigoEmpleado;
        private Label lblY;
        private Button btnGenerarListado;
        private Button btnAgregarListado;
        public ComboBox cboLP;
        public Panel pnlPrincipal;
        public DataGridView dataGridView1;
        public DateTimePicker dtpFechaIngreso1;
        public DateTimePicker dtpFechaIngreso2;
        public TextBox txbCodigoEmpleado;
        public Button btnCargarCredenciales;
        public Button btnRegisterAsPrinterCards;
        private CheckBox chbSelectAll;
    }
}