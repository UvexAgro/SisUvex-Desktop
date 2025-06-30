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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmManifestCat));
            dtpDate2 = new DateTimePicker();
            dtpDate1 = new DateTimePicker();
            btnSearchDate = new Button();
            lblY = new Label();
            label4 = new Label();
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
            btnConfigManifest = new Button();
            btnTemplates = new Button();
            chbPrintManifestPerField = new CheckBox();
            btnPrintManifest = new Button();
            chbExcelLayout = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dgvCatalog).BeginInit();
            SuspendLayout();
            // 
            // dtpDate2
            // 
            dtpDate2.Format = DateTimePickerFormat.Short;
            dtpDate2.Location = new Point(104, 91);
            dtpDate2.Name = "dtpDate2";
            dtpDate2.Size = new Size(80, 23);
            dtpDate2.TabIndex = 55;
            // 
            // dtpDate1
            // 
            dtpDate1.Format = DateTimePickerFormat.Short;
            dtpDate1.Location = new Point(12, 91);
            dtpDate1.Name = "dtpDate1";
            dtpDate1.Size = new Size(80, 23);
            dtpDate1.TabIndex = 54;
            // 
            // btnSearchDate
            // 
            btnSearchDate.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnSearchDate.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearchDate.Location = new Point(187, 91);
            btnSearchDate.Name = "btnSearchDate";
            btnSearchDate.Size = new Size(23, 23);
            btnSearchDate.TabIndex = 56;
            btnSearchDate.UseVisualStyleBackColor = true;
            btnSearchDate.Click += btnSearchDate_Click;
            // 
            // lblY
            // 
            lblY.AutoSize = true;
            lblY.Location = new Point(92, 97);
            lblY.Name = "lblY";
            lblY.Size = new Size(13, 15);
            lblY.TabIndex = 58;
            lblY.Text = "y";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 6.75F);
            label4.Location = new Point(12, 78);
            label4.Name = "label4";
            label4.Size = new Size(56, 12);
            label4.TabIndex = 59;
            label4.Text = "Entre fechas:";
            // 
            // btnRemoved
            // 
            btnRemoved.Location = new Point(174, 120);
            btnRemoved.Name = "btnRemoved";
            btnRemoved.Size = new Size(75, 23);
            btnRemoved.TabIndex = 50;
            btnRemoved.Text = "Eliminados";
            btnRemoved.UseVisualStyleBackColor = true;
            btnRemoved.Click += btnRemoved_Click;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(255, 120);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(75, 23);
            btnRemove.TabIndex = 51;
            btnRemove.Text = "Eliminar";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnRecover
            // 
            btnRecover.Location = new Point(336, 120);
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
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvCatalog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvCatalog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvCatalog.EnableHeadersVisualStyles = false;
            dgvCatalog.ImeMode = ImeMode.NoControl;
            dgvCatalog.Location = new Point(12, 149);
            dgvCatalog.Name = "dgvCatalog";
            dgvCatalog.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvCatalog.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvCatalog.RowHeadersVisible = false;
            dgvCatalog.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvCatalog.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCatalog.Size = new Size(776, 289);
            dgvCatalog.TabIndex = 57;
            dgvCatalog.CellMouseDoubleClick += dgvCatalog_CellMouseDoubleClick;
            // 
            // btnModify
            // 
            btnModify.Location = new Point(93, 120);
            btnModify.Name = "btnModify";
            btnModify.Size = new Size(75, 23);
            btnModify.TabIndex = 49;
            btnModify.Text = "Modificar";
            btnModify.UseVisualStyleBackColor = true;
            btnModify.Click += btnModify_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(12, 120);
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
            label1.Location = new Point(12, 6);
            label1.Name = "label1";
            label1.Size = new Size(50, 12);
            label1.TabIndex = 30;
            label1.Text = "Distribuidor";
            // 
            // cboDistributor
            // 
            cboDistributor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDistributor.FormattingEnabled = true;
            cboDistributor.Location = new Point(12, 18);
            cboDistributor.Name = "cboDistributor";
            cboDistributor.Size = new Size(203, 23);
            cboDistributor.TabIndex = 0;
            // 
            // cboConsignee
            // 
            cboConsignee.DropDownStyle = ComboBoxStyle.DropDownList;
            cboConsignee.FormattingEnabled = true;
            cboConsignee.Location = new Point(221, 18);
            cboConsignee.Name = "cboConsignee";
            cboConsignee.Size = new Size(203, 23);
            cboConsignee.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 6.75F);
            label2.Location = new Point(221, 6);
            label2.Name = "label2";
            label2.Size = new Size(60, 12);
            label2.TabIndex = 31;
            label2.Text = "Consignatario";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 6.75F);
            label3.Location = new Point(221, 42);
            label3.Name = "label3";
            label3.Size = new Size(35, 12);
            label3.TabIndex = 39;
            label3.Text = "Destino";
            // 
            // cboDestination
            // 
            cboDestination.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDestination.FormattingEnabled = true;
            cboDestination.Location = new Point(221, 54);
            cboDestination.Name = "cboDestination";
            cboDestination.Size = new Size(203, 23);
            cboDestination.TabIndex = 38;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 6.75F);
            label5.Location = new Point(12, 42);
            label5.Name = "label5";
            label5.Size = new Size(43, 12);
            label5.TabIndex = 41;
            label5.Text = "Productor";
            // 
            // cboGrower
            // 
            cboGrower.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGrower.FormattingEnabled = true;
            cboGrower.Location = new Point(12, 54);
            cboGrower.Name = "cboGrower";
            cboGrower.Size = new Size(203, 23);
            cboGrower.TabIndex = 1;
            // 
            // btnSearchManifest
            // 
            btnSearchManifest.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnSearchManifest.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearchManifest.Location = new Point(401, 91);
            btnSearchManifest.Name = "btnSearchManifest";
            btnSearchManifest.Size = new Size(23, 23);
            btnSearchManifest.TabIndex = 9;
            btnSearchManifest.UseVisualStyleBackColor = true;
            btnSearchManifest.Click += btnSearchManifest_Click;
            // 
            // txbIdManifest
            // 
            txbIdManifest.Location = new Point(325, 91);
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
            label6.Location = new Point(325, 78);
            label6.Name = "label6";
            label6.Size = new Size(47, 12);
            label6.TabIndex = 33;
            label6.Text = "Manifiesto";
            // 
            // btnConfigManifest
            // 
            btnConfigManifest.Font = new Font("Microsoft Sans Serif", 9F);
            btnConfigManifest.Image = (Image)resources.GetObject("btnConfigManifest.Image");
            btnConfigManifest.ImageAlign = ContentAlignment.BottomCenter;
            btnConfigManifest.Location = new Point(417, 120);
            btnConfigManifest.Name = "btnConfigManifest";
            btnConfigManifest.Size = new Size(24, 23);
            btnConfigManifest.TabIndex = 359;
            btnConfigManifest.TextAlign = ContentAlignment.TopRight;
            btnConfigManifest.UseVisualStyleBackColor = true;
            btnConfigManifest.Click += btnConfigManifest_Click;
            // 
            // btnTemplates
            // 
            btnTemplates.Font = new Font("Microsoft Sans Serif", 9F);
            btnTemplates.Image = Properties.Resources.templateIcon16;
            btnTemplates.ImageAlign = ContentAlignment.BottomCenter;
            btnTemplates.Location = new Point(447, 120);
            btnTemplates.Name = "btnTemplates";
            btnTemplates.Size = new Size(24, 23);
            btnTemplates.TabIndex = 360;
            btnTemplates.TextAlign = ContentAlignment.TopRight;
            btnTemplates.UseVisualStyleBackColor = true;
            btnTemplates.Click += btnTemplates_Click;
            // 
            // chbPrintManifestPerField
            // 
            chbPrintManifestPerField.AutoSize = true;
            chbPrintManifestPerField.Font = new Font("Microsoft Sans Serif", 9F);
            chbPrintManifestPerField.Location = new Point(531, 123);
            chbPrintManifestPerField.Name = "chbPrintManifestPerField";
            chbPrintManifestPerField.Size = new Size(116, 19);
            chbPrintManifestPerField.TabIndex = 384;
            chbPrintManifestPerField.Text = "Man. por campo";
            chbPrintManifestPerField.UseVisualStyleBackColor = true;
            // 
            // btnPrintManifest
            // 
            btnPrintManifest.Image = Properties.Resources.imprimirIcon16;
            btnPrintManifest.Location = new Point(499, 119);
            btnPrintManifest.Name = "btnPrintManifest";
            btnPrintManifest.Size = new Size(26, 25);
            btnPrintManifest.TabIndex = 383;
            btnPrintManifest.UseVisualStyleBackColor = true;
            btnPrintManifest.Click += btnPrintManifest_Click;
            // 
            // chbExcelLayout
            // 
            chbExcelLayout.AutoSize = true;
            chbExcelLayout.Font = new Font("Microsoft Sans Serif", 9F);
            chbExcelLayout.Location = new Point(653, 124);
            chbExcelLayout.Name = "chbExcelLayout";
            chbExcelLayout.Size = new Size(91, 19);
            chbExcelLayout.TabIndex = 385;
            chbExcelLayout.Text = "Excel layout";
            chbExcelLayout.UseVisualStyleBackColor = true;
            // 
            // FrmManifestCat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(chbExcelLayout);
            Controls.Add(chbPrintManifestPerField);
            Controls.Add(btnPrintManifest);
            Controls.Add(btnTemplates);
            Controls.Add(btnConfigManifest);
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
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmManifestCat";
            Text = "Catálogo manifiesto";
            WindowState = FormWindowState.Maximized;
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
        private Button btnConfigManifest;
        private Button btnTemplates;
        public CheckBox chbPrintManifestPerField;
        private Button btnPrintManifest;
        public CheckBox chbExcelLayout;
    }
}