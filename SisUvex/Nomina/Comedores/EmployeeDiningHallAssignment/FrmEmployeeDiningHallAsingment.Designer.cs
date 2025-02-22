namespace SisUvex.Nomina.Comedores.EmployeeDiningHallAssignment
{
    partial class FrmEmployeeDiningHallAsingment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEmployeeDiningHallAsingment));
            dgvLista = new DataGridView();
            btnFrmSearchEmployeeId = new Button();
            cboPaymentPlace = new ComboBox();
            lblPaymentPlace = new Label();
            btnSearchEmployee = new Button();
            lblIdEmployee = new Label();
            txbIdEmployee = new TextBox();
            cboDinerProvider = new ComboBox();
            btnSearch = new Button();
            lblDistribuidor = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvLista).BeginInit();
            SuspendLayout();
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
            dgvLista.Location = new Point(12, 95);
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
            dgvLista.Size = new Size(776, 343);
            dgvLista.TabIndex = 3;
            // 
            // btnFrmSearchEmployeeId
            // 
            btnFrmSearchEmployeeId.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnFrmSearchEmployeeId.BackgroundImageLayout = ImageLayout.Stretch;
            btnFrmSearchEmployeeId.Location = new Point(120, 66);
            btnFrmSearchEmployeeId.Name = "btnFrmSearchEmployeeId";
            btnFrmSearchEmployeeId.Size = new Size(23, 23);
            btnFrmSearchEmployeeId.TabIndex = 65;
            btnFrmSearchEmployeeId.UseVisualStyleBackColor = true;
            btnFrmSearchEmployeeId.Click += btnFrmSearchEmployeeId_Click;
            // 
            // cboPaymentPlace
            // 
            cboPaymentPlace.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPaymentPlace.FormattingEnabled = true;
            cboPaymentPlace.Location = new Point(192, 23);
            cboPaymentPlace.Name = "cboPaymentPlace";
            cboPaymentPlace.Size = new Size(329, 23);
            cboPaymentPlace.TabIndex = 61;
            // 
            // lblPaymentPlace
            // 
            lblPaymentPlace.AutoSize = true;
            lblPaymentPlace.Font = new Font("Segoe UI", 6.75F);
            lblPaymentPlace.Location = new Point(192, 11);
            lblPaymentPlace.Name = "lblPaymentPlace";
            lblPaymentPlace.Size = new Size(61, 12);
            lblPaymentPlace.TabIndex = 68;
            lblPaymentPlace.Text = "Lugar de pago";
            // 
            // btnSearchEmployee
            // 
            btnSearchEmployee.BackgroundImage = Properties.Resources.personIcon16;
            btnSearchEmployee.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearchEmployee.Location = new Point(95, 66);
            btnSearchEmployee.Name = "btnSearchEmployee";
            btnSearchEmployee.Size = new Size(23, 23);
            btnSearchEmployee.TabIndex = 64;
            btnSearchEmployee.UseVisualStyleBackColor = true;
            btnSearchEmployee.Click += btnSearchEmployee_Click;
            // 
            // lblIdEmployee
            // 
            lblIdEmployee.AutoSize = true;
            lblIdEmployee.Font = new Font("Segoe UI", 6.75F);
            lblIdEmployee.Location = new Point(12, 53);
            lblIdEmployee.Name = "lblIdEmployee";
            lblIdEmployee.Size = new Size(87, 12);
            lblIdEmployee.TabIndex = 67;
            lblIdEmployee.Text = "Código de empleado";
            // 
            // txbIdEmployee
            // 
            txbIdEmployee.Location = new Point(12, 65);
            txbIdEmployee.MaxLength = 6;
            txbIdEmployee.Name = "txbIdEmployee";
            txbIdEmployee.Size = new Size(80, 23);
            txbIdEmployee.TabIndex = 63;
            txbIdEmployee.KeyPress += txbIdEmployee_KeyPress;
            // 
            // cboDinerProvider
            // 
            cboDinerProvider.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDinerProvider.FormattingEnabled = true;
            cboDinerProvider.Location = new Point(12, 23);
            cboDinerProvider.Name = "cboDinerProvider";
            cboDinerProvider.Size = new Size(174, 23);
            cboDinerProvider.TabIndex = 60;
            // 
            // btnSearch
            // 
            btnSearch.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnSearch.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearch.Location = new Point(527, 23);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(23, 23);
            btnSearch.TabIndex = 62;
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // lblDistribuidor
            // 
            lblDistribuidor.AutoSize = true;
            lblDistribuidor.Font = new Font("Segoe UI", 6.75F);
            lblDistribuidor.Location = new Point(12, 11);
            lblDistribuidor.Name = "lblDistribuidor";
            lblDistribuidor.Size = new Size(45, 12);
            lblDistribuidor.TabIndex = 66;
            lblDistribuidor.Text = "Proveedor";
            // 
            // FrmEmployeeDiningHallAsingment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnFrmSearchEmployeeId);
            Controls.Add(cboPaymentPlace);
            Controls.Add(lblPaymentPlace);
            Controls.Add(btnSearchEmployee);
            Controls.Add(lblIdEmployee);
            Controls.Add(txbIdEmployee);
            Controls.Add(cboDinerProvider);
            Controls.Add(btnSearch);
            Controls.Add(lblDistribuidor);
            Controls.Add(dgvLista);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmEmployeeDiningHallAsingment";
            Text = "Relación empleados - comedor";
            WindowState = FormWindowState.Maximized;
            Load += FrmEmployeeDiningHallAsingment_Load;
            ((System.ComponentModel.ISupportInitialize)dgvLista).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public DataGridView dgvLista;
        private Button btnFrmSearchEmployeeId;
        public ComboBox cboPaymentPlace;
        private Label lblPaymentPlace;
        private Button btnSearchEmployee;
        private Label lblIdEmployee;
        public TextBox txbIdEmployee;
        public ComboBox cboDinerProvider;
        private Button btnSearch;
        private Label lblDistribuidor;
    }
}