namespace SisUvex.Consultas.Pallets
{
    partial class FrmPalletConsulta
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
            dgvConsulta = new DataGridView();
            btnBuscar = new Button();
            dtpFecha1 = new DateTimePicker();
            dtpFecha2 = new DateTimePicker();
            cboDistribuidor = new ComboBox();
            cboPresentacion = new ComboBox();
            lblDistribuidor = new Label();
            label1 = new Label();
            txbManifiesto = new TextBox();
            lblManifiesto = new Label();
            lblPallet = new Label();
            txbPallet = new TextBox();
            btnManifiesto = new Button();
            btnPallet = new Button();
            btnImprimir = new Button();
            btnEliminar = new Button();
            cboVariety = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            cboContainer = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            btnInvoice = new Button();
            label6 = new Label();
            txbInvoice = new TextBox();
            chbShipped = new CheckBox();
            chbRestowing = new CheckBox();
            chbRacked = new CheckBox();
            chbRegected = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dgvConsulta).BeginInit();
            SuspendLayout();
            // 
            // dgvConsulta
            // 
            dgvConsulta.AllowUserToAddRows = false;
            dgvConsulta.AllowUserToDeleteRows = false;
            dgvConsulta.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvConsulta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvConsulta.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvConsulta.BackgroundColor = SystemColors.ControlLightLight;
            dgvConsulta.BorderStyle = BorderStyle.Fixed3D;
            dgvConsulta.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvConsulta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvConsulta.ColumnHeadersHeight = 58;
            dgvConsulta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvConsulta.EnableHeadersVisualStyles = false;
            dgvConsulta.ImeMode = ImeMode.NoControl;
            dgvConsulta.Location = new Point(12, 74);
            dgvConsulta.Name = "dgvConsulta";
            dgvConsulta.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvConsulta.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvConsulta.RowHeadersVisible = false;
            dgvConsulta.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvConsulta.RowTemplate.Height = 25;
            dgvConsulta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvConsulta.Size = new Size(929, 270);
            dgvConsulta.TabIndex = 7;
            // 
            // btnBuscar
            // 
            btnBuscar.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnBuscar.BackgroundImageLayout = ImageLayout.Stretch;
            btnBuscar.Location = new Point(12, 46);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(23, 23);
            btnBuscar.TabIndex = 5;
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // dtpFecha1
            // 
            dtpFecha1.Format = DateTimePickerFormat.Short;
            dtpFecha1.Location = new Point(41, 12);
            dtpFecha1.Name = "dtpFecha1";
            dtpFecha1.Size = new Size(80, 23);
            dtpFecha1.TabIndex = 8;
            // 
            // dtpFecha2
            // 
            dtpFecha2.Format = DateTimePickerFormat.Short;
            dtpFecha2.Location = new Point(41, 46);
            dtpFecha2.Name = "dtpFecha2";
            dtpFecha2.Size = new Size(80, 23);
            dtpFecha2.TabIndex = 9;
            // 
            // cboDistribuidor
            // 
            cboDistribuidor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDistribuidor.FormattingEnabled = true;
            cboDistribuidor.Location = new Point(127, 11);
            cboDistribuidor.Name = "cboDistribuidor";
            cboDistribuidor.Size = new Size(203, 23);
            cboDistribuidor.TabIndex = 11;
            // 
            // cboPresentacion
            // 
            cboPresentacion.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPresentacion.FormattingEnabled = true;
            cboPresentacion.Location = new Point(336, 46);
            cboPresentacion.Name = "cboPresentacion";
            cboPresentacion.Size = new Size(203, 23);
            cboPresentacion.TabIndex = 12;
            // 
            // lblDistribuidor
            // 
            lblDistribuidor.AutoSize = true;
            lblDistribuidor.Font = new Font("Segoe UI", 6.75F);
            lblDistribuidor.Location = new Point(127, -1);
            lblDistribuidor.Name = "lblDistribuidor";
            lblDistribuidor.Size = new Size(50, 12);
            lblDistribuidor.TabIndex = 14;
            lblDistribuidor.Text = "Distribuidor";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 6.75F);
            label1.Location = new Point(336, 34);
            label1.Name = "label1";
            label1.Size = new Size(56, 12);
            label1.TabIndex = 15;
            label1.Text = "Presentación";
            // 
            // txbManifiesto
            // 
            txbManifiesto.Location = new Point(660, 12);
            txbManifiesto.MaxLength = 5;
            txbManifiesto.Name = "txbManifiesto";
            txbManifiesto.Size = new Size(75, 23);
            txbManifiesto.TabIndex = 16;
            txbManifiesto.KeyPress += txbManifiesto_KeyPress;
            // 
            // lblManifiesto
            // 
            lblManifiesto.AutoSize = true;
            lblManifiesto.Font = new Font("Segoe UI", 6.75F);
            lblManifiesto.Location = new Point(660, 0);
            lblManifiesto.Name = "lblManifiesto";
            lblManifiesto.Size = new Size(47, 12);
            lblManifiesto.TabIndex = 17;
            lblManifiesto.Text = "Manifiesto";
            // 
            // lblPallet
            // 
            lblPallet.AutoSize = true;
            lblPallet.Font = new Font("Segoe UI", 6.75F);
            lblPallet.Location = new Point(660, 33);
            lblPallet.Name = "lblPallet";
            lblPallet.Size = new Size(27, 12);
            lblPallet.TabIndex = 19;
            lblPallet.Text = "Pallet";
            // 
            // txbPallet
            // 
            txbPallet.Location = new Point(660, 45);
            txbPallet.MaxLength = 5;
            txbPallet.Name = "txbPallet";
            txbPallet.Size = new Size(75, 23);
            txbPallet.TabIndex = 18;
            txbPallet.KeyPress += txbPallet_KeyPress;
            // 
            // btnManifiesto
            // 
            btnManifiesto.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnManifiesto.BackgroundImageLayout = ImageLayout.Stretch;
            btnManifiesto.Location = new Point(737, 13);
            btnManifiesto.Name = "btnManifiesto";
            btnManifiesto.Size = new Size(23, 23);
            btnManifiesto.TabIndex = 20;
            btnManifiesto.UseVisualStyleBackColor = true;
            btnManifiesto.Click += btnManifiesto_Click;
            // 
            // btnPallet
            // 
            btnPallet.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnPallet.BackgroundImageLayout = ImageLayout.Stretch;
            btnPallet.Location = new Point(737, 45);
            btnPallet.Name = "btnPallet";
            btnPallet.Size = new Size(23, 23);
            btnPallet.TabIndex = 21;
            btnPallet.UseVisualStyleBackColor = true;
            btnPallet.Click += btnPallet_Click;
            // 
            // btnImprimir
            // 
            btnImprimir.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnImprimir.Location = new Point(12, 350);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(66, 23);
            btnImprimir.TabIndex = 22;
            btnImprimir.Text = "Imprimir";
            btnImprimir.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnEliminar.Location = new Point(120, 350);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(66, 23);
            btnEliminar.TabIndex = 23;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // cboVariety
            // 
            cboVariety.DropDownStyle = ComboBoxStyle.DropDownList;
            cboVariety.FormattingEnabled = true;
            cboVariety.Location = new Point(127, 46);
            cboVariety.Name = "cboVariety";
            cboVariety.Size = new Size(203, 23);
            cboVariety.TabIndex = 24;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 6.75F);
            label2.Location = new Point(127, 34);
            label2.Name = "label2";
            label2.Size = new Size(40, 12);
            label2.TabIndex = 26;
            label2.Text = "Variedad";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 6.75F);
            label3.Location = new Point(336, -1);
            label3.Name = "label3";
            label3.Size = new Size(52, 12);
            label3.TabIndex = 27;
            label3.Text = "Contenedor";
            // 
            // cboContainer
            // 
            cboContainer.DropDownStyle = ComboBoxStyle.DropDownList;
            cboContainer.FormattingEnabled = true;
            cboContainer.Location = new Point(336, 11);
            cboContainer.Name = "cboContainer";
            cboContainer.Size = new Size(203, 23);
            cboContainer.TabIndex = 25;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 6.75F);
            label4.Location = new Point(42, 33);
            label4.Name = "label4";
            label4.Size = new Size(9, 12);
            label4.TabIndex = 29;
            label4.Text = "y";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 6.75F);
            label5.Location = new Point(41, 0);
            label5.Name = "label5";
            label5.Size = new Size(26, 12);
            label5.TabIndex = 28;
            label5.Text = "Entre";
            // 
            // btnInvoice
            // 
            btnInvoice.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnInvoice.BackgroundImageLayout = ImageLayout.Stretch;
            btnInvoice.Location = new Point(859, 12);
            btnInvoice.Name = "btnInvoice";
            btnInvoice.Size = new Size(23, 23);
            btnInvoice.TabIndex = 32;
            btnInvoice.UseVisualStyleBackColor = true;
            btnInvoice.Click += btnInvoice_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 6.75F);
            label6.Location = new Point(782, -1);
            label6.Name = "label6";
            label6.Size = new Size(40, 12);
            label6.TabIndex = 31;
            label6.Text = "Papeleta";
            // 
            // txbInvoice
            // 
            txbInvoice.Location = new Point(782, 11);
            txbInvoice.MaxLength = 5;
            txbInvoice.Name = "txbInvoice";
            txbInvoice.Size = new Size(75, 23);
            txbInvoice.TabIndex = 30;
            txbInvoice.KeyPress += txbInvoice_KeyPress;
            // 
            // chbShipped
            // 
            chbShipped.AutoSize = true;
            chbShipped.Checked = true;
            chbShipped.CheckState = CheckState.Checked;
            chbShipped.Location = new Point(545, 7);
            chbShipped.Name = "chbShipped";
            chbShipped.Size = new Size(91, 19);
            chbShipped.TabIndex = 33;
            chbShipped.Text = "Embarcados";
            chbShipped.UseVisualStyleBackColor = true;
            // 
            // chbRestowing
            // 
            chbRestowing.AutoSize = true;
            chbRestowing.Location = new Point(545, 23);
            chbRestowing.Name = "chbRestowing";
            chbRestowing.Size = new Size(89, 19);
            chbRestowing.TabIndex = 34;
            chbRestowing.Text = "Reestibados";
            chbRestowing.UseVisualStyleBackColor = true;
            // 
            // chbRacked
            // 
            chbRacked.AutoSize = true;
            chbRacked.Checked = true;
            chbRacked.CheckState = CheckState.Checked;
            chbRacked.Location = new Point(545, 39);
            chbRacked.Name = "chbRacked";
            chbRacked.Size = new Size(112, 19);
            chbRacked.TabIndex = 35;
            chbRacked.Text = "En conservación";
            chbRacked.UseVisualStyleBackColor = true;
            // 
            // chbRegected
            // 
            chbRegected.AutoSize = true;
            chbRegected.Location = new Point(545, 55);
            chbRegected.Name = "chbRegected";
            chbRegected.Size = new Size(88, 19);
            chbRegected.TabIndex = 36;
            chbRegected.Text = "Rechazados";
            chbRegected.UseVisualStyleBackColor = true;
            // 
            // FrmPalletConsulta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(953, 383);
            Controls.Add(chbRegected);
            Controls.Add(chbRacked);
            Controls.Add(chbRestowing);
            Controls.Add(chbShipped);
            Controls.Add(btnInvoice);
            Controls.Add(label6);
            Controls.Add(txbInvoice);
            Controls.Add(label5);
            Controls.Add(cboVariety);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(cboContainer);
            Controls.Add(btnEliminar);
            Controls.Add(btnImprimir);
            Controls.Add(btnPallet);
            Controls.Add(btnManifiesto);
            Controls.Add(lblManifiesto);
            Controls.Add(txbManifiesto);
            Controls.Add(cboDistribuidor);
            Controls.Add(dtpFecha2);
            Controls.Add(dtpFecha1);
            Controls.Add(dgvConsulta);
            Controls.Add(btnBuscar);
            Controls.Add(lblDistribuidor);
            Controls.Add(label1);
            Controls.Add(cboPresentacion);
            Controls.Add(lblPallet);
            Controls.Add(txbPallet);
            Controls.Add(label4);
            Name = "FrmPalletConsulta";
            Text = "Consulta de pallets";
            WindowState = FormWindowState.Maximized;
            Load += FrmPalletConsulta_Load;
            ((System.ComponentModel.ISupportInitialize)dgvConsulta).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public DataGridView dgvConsulta;
        private Button btnBuscar;
        private Label lblDistribuidor;
        private Label label1;
        private Label lblManifiesto;
        private Label lblPallet;
        private Button btnManifiesto;
        private Button btnPallet;
        private Button btnImprimir;
        private Button btnEliminar;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnInvoice;
        private Label label6;
        public DateTimePicker dtpFecha1;
        public DateTimePicker dtpFecha2;
        public ComboBox cboDistribuidor;
        public ComboBox cboPresentacion;
        public TextBox txbManifiesto;
        public TextBox txbPallet;
        public ComboBox cboVariety;
        public ComboBox cboContainer;
        public TextBox txbInvoice;
        public CheckBox chbShipped;
        public CheckBox chbRestowing;
        public CheckBox chbRacked;
        public CheckBox chbRegected;
    }
}