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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCredentials));
            txbCodigoEmpleado = new TextBox();
            cboLP = new ComboBox();
            btnGenerarListado = new Button();
            lblCodigoEmpleado = new Label();
            btnAgregarListado = new Button();
            lblIngresoEntre = new Label();
            lblLP = new Label();
            btnFrmSearchEmployeeId = new Button();
            lblY = new Label();
            dtpFechaIngreso2 = new DateTimePicker();
            dtpFechaIngreso1 = new DateTimePicker();
            btnRegisterAsPrinterCards = new Button();
            btnCargarCredenciales = new Button();
            chbSelectAll = new CheckBox();
            pnlPrincipal = new Panel();
            dataGridView1 = new DataGridView();
            btnShowList = new Button();
            pnlPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // txbCodigoEmpleado
            // 
            txbCodigoEmpleado.Font = new Font("Segoe UI", 9.25F);
            txbCodigoEmpleado.Location = new Point(135, 72);
            txbCodigoEmpleado.Margin = new Padding(1);
            txbCodigoEmpleado.MaxLength = 3000;
            txbCodigoEmpleado.Multiline = true;
            txbCodigoEmpleado.Name = "txbCodigoEmpleado";
            txbCodigoEmpleado.ScrollBars = ScrollBars.Vertical;
            txbCodigoEmpleado.Size = new Size(96, 25);
            txbCodigoEmpleado.TabIndex = 4;
            // 
            // cboLP
            // 
            cboLP.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLP.FormattingEnabled = true;
            cboLP.Location = new Point(135, 6);
            cboLP.Name = "cboLP";
            cboLP.Size = new Size(309, 23);
            cboLP.TabIndex = 0;
            // 
            // btnGenerarListado
            // 
            btnGenerarListado.Location = new Point(343, 35);
            btnGenerarListado.Name = "btnGenerarListado";
            btnGenerarListado.Size = new Size(101, 23);
            btnGenerarListado.TabIndex = 3;
            btnGenerarListado.Text = "Generar listado";
            btnGenerarListado.UseVisualStyleBackColor = true;
            btnGenerarListado.Click += btnGenerarListado_Click;
            // 
            // lblCodigoEmpleado
            // 
            lblCodigoEmpleado.AutoSize = true;
            lblCodigoEmpleado.Location = new Point(8, 75);
            lblCodigoEmpleado.Name = "lblCodigoEmpleado";
            lblCodigoEmpleado.Size = new Size(121, 15);
            lblCodigoEmpleado.TabIndex = 2;
            lblCodigoEmpleado.Text = "Código de empleado:";
            // 
            // btnAgregarListado
            // 
            btnAgregarListado.Image = Properties.Resources.mas_16;
            btnAgregarListado.Location = new Point(233, 72);
            btnAgregarListado.Margin = new Padding(1);
            btnAgregarListado.Name = "btnAgregarListado";
            btnAgregarListado.Size = new Size(25, 25);
            btnAgregarListado.TabIndex = 5;
            btnAgregarListado.UseVisualStyleBackColor = true;
            btnAgregarListado.Click += btnAgregarListado_Click;
            // 
            // lblIngresoEntre
            // 
            lblIngresoEntre.AutoSize = true;
            lblIngresoEntre.Location = new Point(50, 37);
            lblIngresoEntre.Name = "lblIngresoEntre";
            lblIngresoEntre.Size = new Size(79, 15);
            lblIngresoEntre.TabIndex = 1;
            lblIngresoEntre.Text = "Ingreso entre:";
            // 
            // lblLP
            // 
            lblLP.AutoSize = true;
            lblLP.Location = new Point(43, 9);
            lblLP.Name = "lblLP";
            lblLP.Size = new Size(86, 15);
            lblLP.TabIndex = 0;
            lblLP.Text = "Lugar de pago:";
            // 
            // btnFrmSearchEmployeeId
            // 
            btnFrmSearchEmployeeId.BackgroundImageLayout = ImageLayout.Stretch;
            btnFrmSearchEmployeeId.Image = Properties.Resources.buscarIcon16;
            btnFrmSearchEmployeeId.ImageAlign = ContentAlignment.BottomRight;
            btnFrmSearchEmployeeId.Location = new Point(260, 72);
            btnFrmSearchEmployeeId.Margin = new Padding(1);
            btnFrmSearchEmployeeId.Name = "btnFrmSearchEmployeeId";
            btnFrmSearchEmployeeId.Size = new Size(25, 25);
            btnFrmSearchEmployeeId.TabIndex = 6;
            btnFrmSearchEmployeeId.UseVisualStyleBackColor = true;
            btnFrmSearchEmployeeId.Click += btnFrmSearchEmployeeId_Click;
            // 
            // lblY
            // 
            lblY.AutoSize = true;
            lblY.Location = new Point(230, 41);
            lblY.Name = "lblY";
            lblY.Size = new Size(13, 15);
            lblY.TabIndex = 3;
            lblY.Text = "y";
            // 
            // dtpFechaIngreso2
            // 
            dtpFechaIngreso2.Format = DateTimePickerFormat.Short;
            dtpFechaIngreso2.Location = new Point(242, 35);
            dtpFechaIngreso2.Name = "dtpFechaIngreso2";
            dtpFechaIngreso2.Size = new Size(95, 23);
            dtpFechaIngreso2.TabIndex = 2;
            // 
            // dtpFechaIngreso1
            // 
            dtpFechaIngreso1.Format = DateTimePickerFormat.Short;
            dtpFechaIngreso1.Location = new Point(135, 35);
            dtpFechaIngreso1.Name = "dtpFechaIngreso1";
            dtpFechaIngreso1.Size = new Size(95, 23);
            dtpFechaIngreso1.TabIndex = 1;
            // 
            // btnRegisterAsPrinterCards
            // 
            btnRegisterAsPrinterCards.Image = Properties.Resources.editIcon16;
            btnRegisterAsPrinterCards.ImageAlign = ContentAlignment.MiddleLeft;
            btnRegisterAsPrinterCards.Location = new Point(204, 112);
            btnRegisterAsPrinterCards.Name = "btnRegisterAsPrinterCards";
            btnRegisterAsPrinterCards.Size = new Size(133, 23);
            btnRegisterAsPrinterCards.TabIndex = 9;
            btnRegisterAsPrinterCards.Text = "Registrar impresión";
            btnRegisterAsPrinterCards.TextAlign = ContentAlignment.MiddleRight;
            btnRegisterAsPrinterCards.UseVisualStyleBackColor = true;
            btnRegisterAsPrinterCards.Click += btnRegisterAsPrinterCards_Click;
            // 
            // btnCargarCredenciales
            // 
            btnCargarCredenciales.Image = Properties.Resources.credencial16;
            btnCargarCredenciales.ImageAlign = ContentAlignment.MiddleLeft;
            btnCargarCredenciales.Location = new Point(132, 112);
            btnCargarCredenciales.Name = "btnCargarCredenciales";
            btnCargarCredenciales.Size = new Size(66, 23);
            btnCargarCredenciales.TabIndex = 8;
            btnCargarCredenciales.Text = "Cargar";
            btnCargarCredenciales.TextAlign = ContentAlignment.MiddleRight;
            btnCargarCredenciales.UseVisualStyleBackColor = true;
            btnCargarCredenciales.Click += btnCargarCredenciales_Click;
            // 
            // chbSelectAll
            // 
            chbSelectAll.AutoSize = true;
            chbSelectAll.Location = new Point(12, 116);
            chbSelectAll.Name = "chbSelectAll";
            chbSelectAll.Size = new Size(114, 19);
            chbSelectAll.TabIndex = 7;
            chbSelectAll.Text = "Seleccionar todo";
            chbSelectAll.UseVisualStyleBackColor = true;
            chbSelectAll.CheckedChanged += chbSelectAll_CheckedChanged;
            // 
            // pnlPrincipal
            // 
            pnlPrincipal.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlPrincipal.BackColor = SystemColors.ActiveCaption;
            pnlPrincipal.BorderStyle = BorderStyle.Fixed3D;
            pnlPrincipal.Controls.Add(dataGridView1);
            pnlPrincipal.Location = new Point(12, 141);
            pnlPrincipal.Name = "pnlPrincipal";
            pnlPrincipal.Size = new Size(661, 351);
            pnlPrincipal.TabIndex = 11;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView1.Size = new Size(657, 347);
            dataGridView1.TabIndex = 0;
            // 
            // btnShowList
            // 
            btnShowList.BackgroundImageLayout = ImageLayout.Stretch;
            btnShowList.Image = Properties.Resources.reiniciarMini;
            btnShowList.ImageAlign = ContentAlignment.BottomRight;
            btnShowList.Location = new Point(341, 112);
            btnShowList.Margin = new Padding(1);
            btnShowList.Name = "btnShowList";
            btnShowList.Size = new Size(23, 23);
            btnShowList.TabIndex = 10;
            btnShowList.UseVisualStyleBackColor = true;
            btnShowList.Click += btnShowList_Click;
            // 
            // FrmCredentials
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(685, 504);
            Controls.Add(btnShowList);
            Controls.Add(pnlPrincipal);
            Controls.Add(dtpFechaIngreso1);
            Controls.Add(chbSelectAll);
            Controls.Add(btnRegisterAsPrinterCards);
            Controls.Add(btnCargarCredenciales);
            Controls.Add(dtpFechaIngreso2);
            Controls.Add(lblLP);
            Controls.Add(lblY);
            Controls.Add(txbCodigoEmpleado);
            Controls.Add(cboLP);
            Controls.Add(btnAgregarListado);
            Controls.Add(btnFrmSearchEmployeeId);
            Controls.Add(lblIngresoEntre);
            Controls.Add(btnGenerarListado);
            Controls.Add(lblCodigoEmpleado);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmCredentials";
            Text = "Impresión de credenciales";
            WindowState = FormWindowState.Maximized;
            FormClosing += FrmCredentials_FormClosing;
            Load += FrmCredentials_Load;
            pnlPrincipal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public TextBox txbCodigoEmpleado;
        public ComboBox cboLP;
        private Button btnGenerarListado;
        private Label lblCodigoEmpleado;
        private Button btnAgregarListado;
        private Label lblIngresoEntre;
        private Label lblLP;
        private Button btnFrmSearchEmployeeId;
        private Label lblY;
        public DateTimePicker dtpFechaIngreso2;
        public DateTimePicker dtpFechaIngreso1;
        public Button btnRegisterAsPrinterCards;
        public Button btnCargarCredenciales;
        private CheckBox chbSelectAll;
        public Panel pnlPrincipal;
        public DataGridView dataGridView1;
        private Button btnShowList;
    }
}