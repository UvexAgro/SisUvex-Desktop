namespace SisUvex.Operacion
{
    partial class FrmCajasGranelRegistroCat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCajasGranelRegistroCat));
            btnEliminar = new Button();
            dgvCatalogo = new DataGridView();
            btnModificar = new Button();
            btnAñadir = new Button();
            dtpFecha1 = new DateTimePicker();
            btnSearch = new Button();
            dtpFecha2 = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            cboVariety = new ComboBox();
            cboLot = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            cboWorkGroup = new ComboBox();
            chbLotRemoved = new CheckBox();
            chbVarietyRemoved = new CheckBox();
            chbWorkGroupRemoved = new CheckBox();
            btnInvoice = new Button();
            txbInvoice = new TextBox();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvCatalogo).BeginInit();
            SuspendLayout();
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(171, 98);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 13;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // dgvCatalogo
            // 
            dgvCatalogo.AllowUserToAddRows = false;
            dgvCatalogo.AllowUserToDeleteRows = false;
            dgvCatalogo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCatalogo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvCatalogo.BackgroundColor = SystemColors.ControlLightLight;
            dgvCatalogo.BorderStyle = BorderStyle.Fixed3D;
            dgvCatalogo.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvCatalogo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvCatalogo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvCatalogo.EnableHeadersVisualStyles = false;
            dgvCatalogo.ImeMode = ImeMode.NoControl;
            dgvCatalogo.Location = new Point(9, 127);
            dgvCatalogo.Name = "dgvCatalogo";
            dgvCatalogo.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvCatalogo.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvCatalogo.RowHeadersVisible = false;
            dgvCatalogo.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvCatalogo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCatalogo.Size = new Size(865, 315);
            dgvCatalogo.TabIndex = 11;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(90, 98);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 23);
            btnModificar.TabIndex = 10;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnAñadir
            // 
            btnAñadir.Location = new Point(9, 98);
            btnAñadir.Name = "btnAñadir";
            btnAñadir.Size = new Size(75, 23);
            btnAñadir.TabIndex = 9;
            btnAñadir.Text = "Añadir";
            btnAñadir.UseVisualStyleBackColor = true;
            btnAñadir.Click += btnAñadir_Click;
            // 
            // dtpFecha1
            // 
            dtpFecha1.Location = new Point(9, 60);
            dtpFecha1.Name = "dtpFecha1";
            dtpFecha1.Size = new Size(217, 23);
            dtpFecha1.TabIndex = 14;
            dtpFecha1.ValueChanged += dtpFecha_ValueChanged;
            // 
            // btnSearch
            // 
            btnSearch.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnSearch.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearch.Location = new Point(457, 59);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(25, 25);
            btnSearch.TabIndex = 15;
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // dtpFecha2
            // 
            dtpFecha2.Location = new Point(240, 60);
            dtpFecha2.Name = "dtpFecha2";
            dtpFecha2.Size = new Size(217, 23);
            dtpFecha2.TabIndex = 16;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 6.75F);
            label1.Location = new Point(9, 47);
            label1.Name = "label1";
            label1.Size = new Size(26, 12);
            label1.TabIndex = 31;
            label1.Text = "Entre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 6.75F);
            label2.Location = new Point(229, 68);
            label2.Name = "label2";
            label2.Size = new Size(9, 12);
            label2.TabIndex = 32;
            label2.Text = "y";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 6.75F);
            label3.Location = new Point(254, 9);
            label3.Name = "label3";
            label3.Size = new Size(40, 12);
            label3.TabIndex = 36;
            label3.Text = "Variedad";
            // 
            // cboVariety
            // 
            cboVariety.DropDownStyle = ComboBoxStyle.DropDownList;
            cboVariety.FormattingEnabled = true;
            cboVariety.Location = new Point(254, 21);
            cboVariety.Name = "cboVariety";
            cboVariety.Size = new Size(217, 23);
            cboVariety.TabIndex = 34;
            // 
            // cboLot
            // 
            cboLot.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLot.FormattingEnabled = true;
            cboLot.Location = new Point(9, 21);
            cboLot.Name = "cboLot";
            cboLot.Size = new Size(217, 23);
            cboLot.TabIndex = 33;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 6.75F);
            label4.Location = new Point(9, 9);
            label4.Name = "label4";
            label4.Size = new Size(22, 12);
            label4.TabIndex = 35;
            label4.Text = "Lote";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 6.75F);
            label5.Location = new Point(499, 8);
            label5.Name = "label5";
            label5.Size = new Size(40, 12);
            label5.TabIndex = 38;
            label5.Text = "Cuadrilla";
            // 
            // cboWorkGroup
            // 
            cboWorkGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            cboWorkGroup.FormattingEnabled = true;
            cboWorkGroup.Location = new Point(499, 20);
            cboWorkGroup.Name = "cboWorkGroup";
            cboWorkGroup.Size = new Size(203, 23);
            cboWorkGroup.TabIndex = 37;
            // 
            // chbLotRemoved
            // 
            chbLotRemoved.Appearance = Appearance.Button;
            chbLotRemoved.Font = new Font("Segoe UI", 7.8F);
            chbLotRemoved.ForeColor = Color.DarkGray;
            chbLotRemoved.Image = Properties.Resources.removedList16;
            chbLotRemoved.ImageAlign = ContentAlignment.TopLeft;
            chbLotRemoved.Location = new Point(226, 20);
            chbLotRemoved.Margin = new Padding(1, 1, 0, 0);
            chbLotRemoved.Name = "chbLotRemoved";
            chbLotRemoved.Size = new Size(25, 25);
            chbLotRemoved.TabIndex = 39;
            chbLotRemoved.Text = "  ";
            chbLotRemoved.UseVisualStyleBackColor = true;
            // 
            // chbVarietyRemoved
            // 
            chbVarietyRemoved.Appearance = Appearance.Button;
            chbVarietyRemoved.Font = new Font("Segoe UI", 7.8F);
            chbVarietyRemoved.ForeColor = Color.DarkGray;
            chbVarietyRemoved.Image = Properties.Resources.removedList16;
            chbVarietyRemoved.Location = new Point(471, 20);
            chbVarietyRemoved.Margin = new Padding(1, 1, 0, 0);
            chbVarietyRemoved.Name = "chbVarietyRemoved";
            chbVarietyRemoved.Size = new Size(25, 25);
            chbVarietyRemoved.TabIndex = 40;
            chbVarietyRemoved.Text = "  ";
            chbVarietyRemoved.UseVisualStyleBackColor = true;
            // 
            // chbWorkGroupRemoved
            // 
            chbWorkGroupRemoved.Appearance = Appearance.Button;
            chbWorkGroupRemoved.Font = new Font("Segoe UI", 7.8F);
            chbWorkGroupRemoved.ForeColor = Color.DarkGray;
            chbWorkGroupRemoved.Image = Properties.Resources.removedList16;
            chbWorkGroupRemoved.Location = new Point(702, 19);
            chbWorkGroupRemoved.Margin = new Padding(1, 1, 0, 0);
            chbWorkGroupRemoved.Name = "chbWorkGroupRemoved";
            chbWorkGroupRemoved.Size = new Size(25, 25);
            chbWorkGroupRemoved.TabIndex = 41;
            chbWorkGroupRemoved.Text = "  ";
            chbWorkGroupRemoved.UseVisualStyleBackColor = true;
            // 
            // btnInvoice
            // 
            btnInvoice.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnInvoice.BackgroundImageLayout = ImageLayout.Stretch;
            btnInvoice.Location = new Point(582, 98);
            btnInvoice.Name = "btnInvoice";
            btnInvoice.Size = new Size(23, 23);
            btnInvoice.TabIndex = 43;
            btnInvoice.UseVisualStyleBackColor = true;
            btnInvoice.Click += btnInvoice_Click;
            // 
            // txbInvoice
            // 
            txbInvoice.Location = new Point(499, 98);
            txbInvoice.MaxLength = 5;
            txbInvoice.Name = "txbInvoice";
            txbInvoice.Size = new Size(83, 23);
            txbInvoice.TabIndex = 42;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 6.75F);
            label6.Location = new Point(499, 83);
            label6.Name = "label6";
            label6.Size = new Size(40, 12);
            label6.TabIndex = 44;
            label6.Text = "Papeleta";
            // 
            // FrmCajasGranelRegistroCat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 450);
            Controls.Add(label6);
            Controls.Add(btnInvoice);
            Controls.Add(txbInvoice);
            Controls.Add(chbWorkGroupRemoved);
            Controls.Add(chbVarietyRemoved);
            Controls.Add(chbLotRemoved);
            Controls.Add(label5);
            Controls.Add(cboWorkGroup);
            Controls.Add(label3);
            Controls.Add(cboVariety);
            Controls.Add(cboLot);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dtpFecha2);
            Controls.Add(btnSearch);
            Controls.Add(dtpFecha1);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnAñadir);
            Controls.Add(dgvCatalogo);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmCajasGranelRegistroCat";
            Text = "Registros granel";
            WindowState = FormWindowState.Maximized;
            Load += FrmCajasGranelRegistroCat_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCatalogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnEliminar;
        public DataGridView dgvCatalogo;
        private Button btnModificar;
        private Button btnAñadir;
        public DateTimePicker dtpFecha1;
        private Button btnSearch;
        public DateTimePicker dtpFecha2;
        private Label label1;
        private Label label2;
        private Label label3;
        public ComboBox cboVariety;
        public ComboBox cboLot;
        private Label label4;
        private Label label5;
        public ComboBox cboWorkGroup;
        public CheckBox chbLotRemoved;
        public CheckBox chbVarietyRemoved;
        public CheckBox chbWorkGroupRemoved;
        private Button btnInvoice;
        private TextBox txbInvoice;
        private Label label6;
    }
}