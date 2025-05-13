namespace SisUvex.Material.MaterialRegister.Entry
{
    partial class FrmMaterialRegisterEntryCat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMaterialRegisterEntryCat));
            btnSearchFilters = new Button();
            cboMaterialType = new ComboBox();
            label5 = new Label();
            txbSearchBy = new TextBox();
            label2 = new Label();
            btnRemove = new Button();
            cboMaterial = new ComboBox();
            dgvCatalog = new DataGridView();
            cboDistributor = new ComboBox();
            btnModify = new Button();
            btnAdd = new Button();
            label1 = new Label();
            label6 = new Label();
            cboGrower = new ComboBox();
            label3 = new Label();
            cboProvider = new ComboBox();
            label4 = new Label();
            cboWareHouse = new ComboBox();
            label7 = new Label();
            cboTransportLine = new ComboBox();
            label8 = new Label();
            cboFreightContainer = new ComboBox();
            label9 = new Label();
            chbMaterialRemoved = new CheckBox();
            chbFreightContainerRemoved = new CheckBox();
            chbTransportLineRemoved = new CheckBox();
            chbDistributorRemoved = new CheckBox();
            chbGrowerRemoved = new CheckBox();
            chbProviderRemoved = new CheckBox();
            chbWareHouseRemoved = new CheckBox();
            dtpDate2 = new DateTimePicker();
            dtpDate1 = new DateTimePicker();
            lblY = new Label();
            label10 = new Label();
            cboSearchBy = new ComboBox();
            btnSearchBy = new Button();
            btnFreightContainerSearch = new Button();
            btnTransportLineSearch = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCatalog).BeginInit();
            SuspendLayout();
            // 
            // btnSearchFilters
            // 
            btnSearchFilters.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnSearchFilters.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearchFilters.Location = new Point(648, 97);
            btnSearchFilters.Name = "btnSearchFilters";
            btnSearchFilters.Size = new Size(25, 25);
            btnSearchFilters.TabIndex = 405;
            btnSearchFilters.UseVisualStyleBackColor = true;
            btnSearchFilters.Click += btnSearchFilters_Click;
            // 
            // cboMaterialType
            // 
            cboMaterialType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMaterialType.FormattingEnabled = true;
            cboMaterialType.Location = new Point(242, 59);
            cboMaterialType.Name = "cboMaterialType";
            cboMaterialType.Size = new Size(203, 23);
            cboMaterialType.TabIndex = 388;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 6.75F);
            label5.Location = new Point(242, 47);
            label5.Name = "label5";
            label5.Size = new Size(69, 12);
            label5.TabIndex = 395;
            label5.Text = "Tipo de material";
            // 
            // txbSearchBy
            // 
            txbSearchBy.Location = new Point(385, 135);
            txbSearchBy.MaxLength = 5;
            txbSearchBy.Name = "txbSearchBy";
            txbSearchBy.Size = new Size(203, 23);
            txbSearchBy.TabIndex = 390;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 6.75F);
            label2.Location = new Point(242, 85);
            label2.Name = "label2";
            label2.Size = new Size(38, 12);
            label2.TabIndex = 393;
            label2.Text = "Material";
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(174, 135);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(75, 23);
            btnRemove.TabIndex = 399;
            btnRemove.Text = "Eliminar";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // cboMaterial
            // 
            cboMaterial.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMaterial.FormattingEnabled = true;
            cboMaterial.Location = new Point(242, 97);
            cboMaterial.Name = "cboMaterial";
            cboMaterial.Size = new Size(203, 23);
            cboMaterial.TabIndex = 389;
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
            dgvCatalog.Location = new Point(12, 164);
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
            dgvCatalog.Size = new Size(961, 277);
            dgvCatalog.TabIndex = 402;
            // 
            // cboDistributor
            // 
            cboDistributor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDistributor.FormattingEnabled = true;
            cboDistributor.Location = new Point(12, 21);
            cboDistributor.Name = "cboDistributor";
            cboDistributor.Size = new Size(203, 23);
            cboDistributor.TabIndex = 387;
            // 
            // btnModify
            // 
            btnModify.Location = new Point(93, 135);
            btnModify.Name = "btnModify";
            btnModify.Size = new Size(75, 23);
            btnModify.TabIndex = 397;
            btnModify.Text = "Modificar";
            btnModify.UseVisualStyleBackColor = true;
            btnModify.Click += btnModify_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(12, 135);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 396;
            btnAdd.Text = "Añadir";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 6.75F);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(50, 12);
            label1.TabIndex = 392;
            label1.Text = "Distribuidor";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 6.75F);
            label6.Location = new Point(255, 123);
            label6.Name = "label6";
            label6.Size = new Size(48, 12);
            label6.TabIndex = 394;
            label6.Text = "Buscar por:";
            // 
            // cboGrower
            // 
            cboGrower.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGrower.FormattingEnabled = true;
            cboGrower.Location = new Point(12, 59);
            cboGrower.Name = "cboGrower";
            cboGrower.Size = new Size(203, 23);
            cboGrower.TabIndex = 406;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 6.75F);
            label3.Location = new Point(12, 47);
            label3.Name = "label3";
            label3.Size = new Size(43, 12);
            label3.TabIndex = 407;
            label3.Text = "Productor";
            // 
            // cboProvider
            // 
            cboProvider.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProvider.FormattingEnabled = true;
            cboProvider.Location = new Point(12, 97);
            cboProvider.Name = "cboProvider";
            cboProvider.Size = new Size(203, 23);
            cboProvider.TabIndex = 408;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 6.75F);
            label4.Location = new Point(12, 85);
            label4.Name = "label4";
            label4.Size = new Size(45, 12);
            label4.TabIndex = 409;
            label4.Text = "Proveedor";
            // 
            // cboWareHouse
            // 
            cboWareHouse.DropDownStyle = ComboBoxStyle.DropDownList;
            cboWareHouse.FormattingEnabled = true;
            cboWareHouse.Location = new Point(242, 21);
            cboWareHouse.Name = "cboWareHouse";
            cboWareHouse.Size = new Size(203, 23);
            cboWareHouse.TabIndex = 410;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 6.75F);
            label7.Location = new Point(242, 9);
            label7.Name = "label7";
            label7.Size = new Size(40, 12);
            label7.TabIndex = 411;
            label7.Text = "Almacén";
            // 
            // cboTransportLine
            // 
            cboTransportLine.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTransportLine.FormattingEnabled = true;
            cboTransportLine.Location = new Point(472, 20);
            cboTransportLine.Name = "cboTransportLine";
            cboTransportLine.Size = new Size(203, 23);
            cboTransportLine.TabIndex = 412;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 6.75F);
            label8.Location = new Point(472, 8);
            label8.Name = "label8";
            label8.Size = new Size(81, 12);
            label8.TabIndex = 413;
            label8.Text = "Línea de transporte";
            // 
            // cboFreightContainer
            // 
            cboFreightContainer.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFreightContainer.FormattingEnabled = true;
            cboFreightContainer.Location = new Point(472, 58);
            cboFreightContainer.Name = "cboFreightContainer";
            cboFreightContainer.Size = new Size(203, 23);
            cboFreightContainer.TabIndex = 414;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 6.75F);
            label9.Location = new Point(472, 46);
            label9.Name = "label9";
            label9.Size = new Size(23, 12);
            label9.TabIndex = 415;
            label9.Text = "Caja";
            // 
            // chbMaterialRemoved
            // 
            chbMaterialRemoved.Appearance = Appearance.Button;
            chbMaterialRemoved.Image = Properties.Resources.removedList16;
            chbMaterialRemoved.Location = new Point(445, 96);
            chbMaterialRemoved.Margin = new Padding(0);
            chbMaterialRemoved.Name = "chbMaterialRemoved";
            chbMaterialRemoved.Padding = new Padding(0, 1, 0, 0);
            chbMaterialRemoved.Size = new Size(24, 25);
            chbMaterialRemoved.TabIndex = 416;
            chbMaterialRemoved.TextAlign = ContentAlignment.MiddleCenter;
            chbMaterialRemoved.UseVisualStyleBackColor = true;
            // 
            // chbFreightContainerRemoved
            // 
            chbFreightContainerRemoved.Appearance = Appearance.Button;
            chbFreightContainerRemoved.Image = Properties.Resources.removedList16;
            chbFreightContainerRemoved.Location = new Point(675, 57);
            chbFreightContainerRemoved.Margin = new Padding(0);
            chbFreightContainerRemoved.Name = "chbFreightContainerRemoved";
            chbFreightContainerRemoved.Padding = new Padding(0, 1, 0, 0);
            chbFreightContainerRemoved.Size = new Size(24, 25);
            chbFreightContainerRemoved.TabIndex = 417;
            chbFreightContainerRemoved.TextAlign = ContentAlignment.MiddleCenter;
            chbFreightContainerRemoved.UseVisualStyleBackColor = true;
            // 
            // chbTransportLineRemoved
            // 
            chbTransportLineRemoved.Appearance = Appearance.Button;
            chbTransportLineRemoved.Image = Properties.Resources.removedList16;
            chbTransportLineRemoved.Location = new Point(675, 19);
            chbTransportLineRemoved.Margin = new Padding(0);
            chbTransportLineRemoved.Name = "chbTransportLineRemoved";
            chbTransportLineRemoved.Padding = new Padding(0, 1, 0, 0);
            chbTransportLineRemoved.Size = new Size(24, 25);
            chbTransportLineRemoved.TabIndex = 418;
            chbTransportLineRemoved.TextAlign = ContentAlignment.MiddleCenter;
            chbTransportLineRemoved.UseVisualStyleBackColor = true;
            // 
            // chbDistributorRemoved
            // 
            chbDistributorRemoved.Appearance = Appearance.Button;
            chbDistributorRemoved.Image = Properties.Resources.removedList16;
            chbDistributorRemoved.Location = new Point(215, 20);
            chbDistributorRemoved.Margin = new Padding(0);
            chbDistributorRemoved.Name = "chbDistributorRemoved";
            chbDistributorRemoved.Padding = new Padding(0, 1, 0, 0);
            chbDistributorRemoved.Size = new Size(24, 25);
            chbDistributorRemoved.TabIndex = 420;
            chbDistributorRemoved.TextAlign = ContentAlignment.MiddleCenter;
            chbDistributorRemoved.UseVisualStyleBackColor = true;
            // 
            // chbGrowerRemoved
            // 
            chbGrowerRemoved.Appearance = Appearance.Button;
            chbGrowerRemoved.Image = Properties.Resources.removedList16;
            chbGrowerRemoved.Location = new Point(215, 58);
            chbGrowerRemoved.Margin = new Padding(0);
            chbGrowerRemoved.Name = "chbGrowerRemoved";
            chbGrowerRemoved.Padding = new Padding(0, 1, 0, 0);
            chbGrowerRemoved.Size = new Size(24, 25);
            chbGrowerRemoved.TabIndex = 419;
            chbGrowerRemoved.TextAlign = ContentAlignment.MiddleCenter;
            chbGrowerRemoved.UseVisualStyleBackColor = true;
            // 
            // chbProviderRemoved
            // 
            chbProviderRemoved.Appearance = Appearance.Button;
            chbProviderRemoved.Image = Properties.Resources.removedList16;
            chbProviderRemoved.Location = new Point(215, 96);
            chbProviderRemoved.Margin = new Padding(0);
            chbProviderRemoved.Name = "chbProviderRemoved";
            chbProviderRemoved.Padding = new Padding(0, 1, 0, 0);
            chbProviderRemoved.Size = new Size(24, 25);
            chbProviderRemoved.TabIndex = 421;
            chbProviderRemoved.TextAlign = ContentAlignment.MiddleCenter;
            chbProviderRemoved.UseVisualStyleBackColor = true;
            // 
            // chbWareHouseRemoved
            // 
            chbWareHouseRemoved.Appearance = Appearance.Button;
            chbWareHouseRemoved.Image = Properties.Resources.removedList16;
            chbWareHouseRemoved.Location = new Point(445, 20);
            chbWareHouseRemoved.Margin = new Padding(0);
            chbWareHouseRemoved.Name = "chbWareHouseRemoved";
            chbWareHouseRemoved.Padding = new Padding(0, 1, 0, 0);
            chbWareHouseRemoved.Size = new Size(24, 25);
            chbWareHouseRemoved.TabIndex = 422;
            chbWareHouseRemoved.TextAlign = ContentAlignment.MiddleCenter;
            chbWareHouseRemoved.UseVisualStyleBackColor = true;
            // 
            // dtpDate2
            // 
            dtpDate2.Format = DateTimePickerFormat.Short;
            dtpDate2.Location = new Point(565, 98);
            dtpDate2.Name = "dtpDate2";
            dtpDate2.Size = new Size(80, 23);
            dtpDate2.TabIndex = 424;
            // 
            // dtpDate1
            // 
            dtpDate1.Format = DateTimePickerFormat.Short;
            dtpDate1.Location = new Point(473, 98);
            dtpDate1.Name = "dtpDate1";
            dtpDate1.Size = new Size(80, 23);
            dtpDate1.TabIndex = 423;
            // 
            // lblY
            // 
            lblY.AutoSize = true;
            lblY.Location = new Point(553, 104);
            lblY.Name = "lblY";
            lblY.Size = new Size(13, 15);
            lblY.TabIndex = 426;
            lblY.Text = "y";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 6.75F);
            label10.Location = new Point(473, 85);
            label10.Name = "label10";
            label10.Size = new Size(56, 12);
            label10.TabIndex = 427;
            label10.Text = "Entre fechas:";
            // 
            // cboSearchBy
            // 
            cboSearchBy.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSearchBy.FormattingEnabled = true;
            cboSearchBy.Location = new Point(255, 135);
            cboSearchBy.Name = "cboSearchBy";
            cboSearchBy.Size = new Size(124, 23);
            cboSearchBy.TabIndex = 428;
            // 
            // btnSearchBy
            // 
            btnSearchBy.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnSearchBy.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearchBy.Location = new Point(594, 135);
            btnSearchBy.Name = "btnSearchBy";
            btnSearchBy.Size = new Size(23, 23);
            btnSearchBy.TabIndex = 429;
            btnSearchBy.UseVisualStyleBackColor = true;
            btnSearchBy.Click += btnSearchBy_Click;
            // 
            // btnFreightContainerSearch
            // 
            btnFreightContainerSearch.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnFreightContainerSearch.BackgroundImageLayout = ImageLayout.Stretch;
            btnFreightContainerSearch.Location = new Point(698, 57);
            btnFreightContainerSearch.Name = "btnFreightContainerSearch";
            btnFreightContainerSearch.Size = new Size(25, 25);
            btnFreightContainerSearch.TabIndex = 430;
            btnFreightContainerSearch.UseVisualStyleBackColor = true;
            btnFreightContainerSearch.Click += btnFreightContainerSearch_Click;
            // 
            // btnTransportLineSearch
            // 
            btnTransportLineSearch.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnTransportLineSearch.BackgroundImageLayout = ImageLayout.Stretch;
            btnTransportLineSearch.Location = new Point(698, 19);
            btnTransportLineSearch.Name = "btnTransportLineSearch";
            btnTransportLineSearch.Size = new Size(25, 25);
            btnTransportLineSearch.TabIndex = 431;
            btnTransportLineSearch.UseVisualStyleBackColor = true;
            btnTransportLineSearch.Click += btnTransportLineSearch_Click;
            // 
            // FrmMaterialRegisterEntryCat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(985, 450);
            Controls.Add(btnTransportLineSearch);
            Controls.Add(btnFreightContainerSearch);
            Controls.Add(btnSearchBy);
            Controls.Add(cboSearchBy);
            Controls.Add(dtpDate2);
            Controls.Add(dtpDate1);
            Controls.Add(lblY);
            Controls.Add(label10);
            Controls.Add(chbWareHouseRemoved);
            Controls.Add(chbProviderRemoved);
            Controls.Add(chbDistributorRemoved);
            Controls.Add(chbGrowerRemoved);
            Controls.Add(chbTransportLineRemoved);
            Controls.Add(chbFreightContainerRemoved);
            Controls.Add(chbMaterialRemoved);
            Controls.Add(cboFreightContainer);
            Controls.Add(label9);
            Controls.Add(cboTransportLine);
            Controls.Add(label8);
            Controls.Add(cboWareHouse);
            Controls.Add(label7);
            Controls.Add(cboProvider);
            Controls.Add(label4);
            Controls.Add(cboGrower);
            Controls.Add(label3);
            Controls.Add(btnSearchFilters);
            Controls.Add(cboMaterialType);
            Controls.Add(label5);
            Controls.Add(txbSearchBy);
            Controls.Add(label2);
            Controls.Add(btnRemove);
            Controls.Add(cboMaterial);
            Controls.Add(dgvCatalog);
            Controls.Add(cboDistributor);
            Controls.Add(btnModify);
            Controls.Add(btnAdd);
            Controls.Add(label1);
            Controls.Add(label6);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmMaterialRegisterEntryCat";
            Text = "Registro de entradas de material";
            WindowState = FormWindowState.Maximized;
            Load += FrmMaterialRegisterEntryCat_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCatalog).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSearchFilters;
        private Button btnTemplates;
        private Button btnConfigManifest;
        public ComboBox cboMaterialType;
        private Label label5;
        private Button btnSearchManifest;
        private TextBox txbSearchBy;
        private Button btnPrint;
        private Label label2;
        private Button btnRemove;
        public ComboBox cboMaterial;
        public DataGridView dgvCatalog;
        public ComboBox cboDistributor;
        private Button btnModify;
        private Button btnAdd;
        private Label label1;
        private Label label6;
        public ComboBox cboGrower;
        private Label label3;
        public ComboBox cboProvider;
        private Label label4;
        public ComboBox cboWareHouse;
        private Label label7;
        public ComboBox cboTransportLine;
        private Label label8;
        public ComboBox cboFreightContainer;
        private Label label9;
        public CheckBox chbMaterialRemoved;
        public CheckBox chbFreightContainerRemoved;
        public CheckBox chbTransportLineRemoved;
        public CheckBox chbDistributorRemoved;
        public CheckBox chbGrowerRemoved;
        public CheckBox chbProviderRemoved;
        public CheckBox chbWareHouseRemoved;
        public DateTimePicker dtpDate2;
        public DateTimePicker dtpDate1;
        private Label lblY;
        private Label label10;
        public ComboBox cboSearchBy;
        private Button btnSearchBy;
        private Button btnFreightContainerSearch;
        private Button btnTransportLineSearch;
    }
}