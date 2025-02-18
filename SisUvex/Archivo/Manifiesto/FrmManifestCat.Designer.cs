namespace SisUvex.Archivo.Manifiesto
{
    partial class FrmManifestCat
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
            dtpDate2 = new DateTimePicker();
            dtpDate1 = new DateTimePicker();
            btnSearchDate = new Button();
            lblY = new Label();
            label4 = new Label();
            btnPrint = new Button();
            btnRemoved = new Button();
            btnRemove = new Button();
            btnRecover = new Button();
            dgvCatalog = new DataGridView();
            btnModify = new Button();
            btnAdd = new Button();
            label1 = new Label();
            cboDistributor = new ComboBox();
            cboConsignee = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            cboDestination = new ComboBox();
            label5 = new Label();
            cboGrower = new ComboBox();
            btnSearchManifest = new Button();
            txbIdManifest = new TextBox();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvCatalog).BeginInit();
            SuspendLayout();
            // 
            // dtpDate2
            // 
            dtpDate2.Format = DateTimePickerFormat.Short;
            dtpDate2.Location = new Point(104, 86);
            dtpDate2.Name = "dtpDate2";
            dtpDate2.Size = new Size(80, 23);
            dtpDate2.TabIndex = 55;
            // 
            // dtpDate1
            // 
            dtpDate1.Format = DateTimePickerFormat.Short;
            dtpDate1.Location = new Point(12, 86);
            dtpDate1.Name = "dtpDate1";
            dtpDate1.Size = new Size(80, 23);
            dtpDate1.TabIndex = 54;
            // 
            // btnSearchDate
            // 
            btnSearchDate.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnSearchDate.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearchDate.Location = new Point(187, 86);
            btnSearchDate.Name = "btnSearchDate";
            btnSearchDate.Size = new Size(23, 23);
            btnSearchDate.TabIndex = 56;
            btnSearchDate.UseVisualStyleBackColor = true;
            btnSearchDate.Click += btnSearchDate_Click;
            // 
            // lblY
            // 
            lblY.AutoSize = true;
            lblY.Location = new Point(92, 92);
            lblY.Name = "lblY";
            lblY.Size = new Size(13, 15);
            lblY.TabIndex = 58;
            lblY.Text = "y";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 6.75F);
            label4.Location = new Point(12, 73);
            label4.Name = "label4";
            label4.Size = new Size(56, 12);
            label4.TabIndex = 59;
            label4.Text = "Entre fechas:";
            // 
            // btnPrint
            // 
            btnPrint.Location = new Point(417, 115);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(75, 23);
            btnPrint.TabIndex = 53;
            btnPrint.Text = "Imprimir";
            btnPrint.UseVisualStyleBackColor = true;
            btnPrint.Click += btnPrint_Click;
            // 
            // btnRemoved
            // 
            btnRemoved.Location = new Point(174, 115);
            btnRemoved.Name = "btnRemoved";
            btnRemoved.Size = new Size(75, 23);
            btnRemoved.TabIndex = 50;
            btnRemoved.Text = "Eliminados";
            btnRemoved.UseVisualStyleBackColor = true;
            btnRemoved.Click += btnRemoved_Click;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(255, 115);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(75, 23);
            btnRemove.TabIndex = 51;
            btnRemove.Text = "Eliminar";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnRecover
            // 
            btnRecover.Location = new Point(336, 115);
            btnRecover.Name = "btnRecover";
            btnRecover.Size = new Size(75, 23);
            btnRecover.TabIndex = 52;
            btnRecover.Text = "Recuperar";
            btnRecover.UseVisualStyleBackColor = true;
            btnRecover.Click += btnRecover_Click;
            // 
            // dgvCatalog
            // 
            dgvCatalog.AllowUserToAddRows = false;
            dgvCatalog.AllowUserToDeleteRows = false;
            dgvCatalog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCatalog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvCatalog.BackgroundColor = SystemColors.ControlLightLight;
            dgvCatalog.BorderStyle = BorderStyle.Fixed3D;
            dgvCatalog.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvCatalog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvCatalog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvCatalog.EnableHeadersVisualStyles = false;
            dgvCatalog.ImeMode = ImeMode.NoControl;
            dgvCatalog.Location = new Point(12, 144);
            dgvCatalog.Name = "dgvCatalog";
            dgvCatalog.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvCatalog.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvCatalog.RowHeadersVisible = false;
            dgvCatalog.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvCatalog.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCatalog.Size = new Size(776, 294);
            dgvCatalog.TabIndex = 57;
            // 
            // btnModify
            // 
            btnModify.Location = new Point(93, 115);
            btnModify.Name = "btnModify";
            btnModify.Size = new Size(75, 23);
            btnModify.TabIndex = 49;
            btnModify.Text = "Modificar";
            btnModify.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(12, 115);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 48;
            btnAdd.Text = "Añadir";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 6.75F);
            label1.Location = new Point(12, -1);
            label1.Name = "label1";
            label1.Size = new Size(50, 12);
            label1.TabIndex = 30;
            label1.Text = "Distribuidor";
            // 
            // cboDistributor
            // 
            cboDistributor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDistributor.FormattingEnabled = true;
            cboDistributor.Location = new Point(12, 11);
            cboDistributor.Name = "cboDistributor";
            cboDistributor.Size = new Size(203, 23);
            cboDistributor.TabIndex = 0;
            // 
            // cboConsignee
            // 
            cboConsignee.DropDownStyle = ComboBoxStyle.DropDownList;
            cboConsignee.FormattingEnabled = true;
            cboConsignee.Location = new Point(221, 11);
            cboConsignee.Name = "cboConsignee";
            cboConsignee.Size = new Size(203, 23);
            cboConsignee.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 6.75F);
            label2.Location = new Point(221, -1);
            label2.Name = "label2";
            label2.Size = new Size(60, 12);
            label2.TabIndex = 31;
            label2.Text = "Consignatario";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 6.75F);
            label3.Location = new Point(221, 35);
            label3.Name = "label3";
            label3.Size = new Size(35, 12);
            label3.TabIndex = 39;
            label3.Text = "Destino";
            // 
            // cboDestination
            // 
            cboDestination.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDestination.FormattingEnabled = true;
            cboDestination.Location = new Point(221, 47);
            cboDestination.Name = "cboDestination";
            cboDestination.Size = new Size(203, 23);
            cboDestination.TabIndex = 38;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 6.75F);
            label5.Location = new Point(12, 35);
            label5.Name = "label5";
            label5.Size = new Size(43, 12);
            label5.TabIndex = 41;
            label5.Text = "Productor";
            // 
            // cboGrower
            // 
            cboGrower.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGrower.FormattingEnabled = true;
            cboGrower.Location = new Point(12, 47);
            cboGrower.Name = "cboGrower";
            cboGrower.Size = new Size(203, 23);
            cboGrower.TabIndex = 1;
            // 
            // btnSearchManifest
            // 
            btnSearchManifest.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnSearchManifest.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearchManifest.Location = new Point(401, 86);
            btnSearchManifest.Name = "btnSearchManifest";
            btnSearchManifest.Size = new Size(23, 23);
            btnSearchManifest.TabIndex = 9;
            btnSearchManifest.UseVisualStyleBackColor = true;
            btnSearchManifest.Click += btnSearchManifest_Click;
            // 
            // txbIdManifest
            // 
            txbIdManifest.Location = new Point(325, 86);
            txbIdManifest.MaxLength = 5;
            txbIdManifest.Name = "txbIdManifest";
            txbIdManifest.Size = new Size(75, 23);
            txbIdManifest.TabIndex = 8;
            txbIdManifest.KeyPress += txbIdManifest_KeyPress;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 6.75F);
            label6.Location = new Point(325, 73);
            label6.Name = "label6";
            label6.Size = new Size(47, 12);
            label6.TabIndex = 33;
            label6.Text = "Manifiesto";
            // 
            // FrmManifestCat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cboGrower);
            Controls.Add(dtpDate2);
            Controls.Add(label5);
            Controls.Add(dtpDate1);
            Controls.Add(btnSearchManifest);
            Controls.Add(cboDestination);
            Controls.Add(txbIdManifest);
            Controls.Add(btnSearchDate);
            Controls.Add(label3);
            Controls.Add(lblY);
            Controls.Add(label4);
            Controls.Add(btnPrint);
            Controls.Add(btnRemoved);
            Controls.Add(label2);
            Controls.Add(btnRemove);
            Controls.Add(btnRecover);
            Controls.Add(cboConsignee);
            Controls.Add(dgvCatalog);
            Controls.Add(cboDistributor);
            Controls.Add(btnModify);
            Controls.Add(btnAdd);
            Controls.Add(label1);
            Controls.Add(label6);
            Name = "FrmManifestCat";
            Text = "FrmManifestCat";
            Load += FrmManifestCat_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCatalog).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public DateTimePicker dtpDate2;
        public DateTimePicker dtpDate1;
        private Button btnSearchDate;
        private Label lblY;
        private Label label4;
        private Button btnPrint;
        private Button btnRemove;
        private Button btnRecover;
        public DataGridView dgvCatalog;
        private Button btnModify;
        private Button btnAdd;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label5;
        private Button btnSearchManifest;
        private TextBox txbIdManifest;
        private Label label6;
        public Button btnRemoved;
        public ComboBox cboDistributor;
        public ComboBox cboConsignee;
        public ComboBox cboDestination;
        public ComboBox cboGrower;
    }
}