namespace SisUvex.Material.MaterialRegister.Entry
{
    partial class FrmMaterialRegisterEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMaterialRegisterEntry));
            lblTitle = new Label();
            txbId = new TextBox();
            lblId = new Label();
            chbDistributorRemoved = new CheckBox();
            btnSearchDistributor = new Button();
            txbIdDistributor = new TextBox();
            cboDistributor = new ComboBox();
            label3 = new Label();
            chbFreightContainerRemoved = new CheckBox();
            chbDriverRemoved = new CheckBox();
            chbTransportLineRemoved = new CheckBox();
            btnFreightContainerSearch = new Button();
            btnDriverSearch = new Button();
            txbIdFreightContainer = new TextBox();
            cboFreightContainer = new ComboBox();
            txbIdDriver = new TextBox();
            cboDriver = new ComboBox();
            btnTransportLineSearch = new Button();
            txbIdTransportLine = new TextBox();
            cboTransportLine = new ComboBox();
            label5 = new Label();
            label8 = new Label();
            lblLinea = new Label();
            dtpDate = new DateTimePicker();
            label17 = new Label();
            txbInvoice = new TextBox();
            label11 = new Label();
            btnMaterialTypeSearch = new Button();
            txbIdMaterialType = new TextBox();
            cboMaterialType = new ComboBox();
            label1 = new Label();
            chbMaterialRemoved = new CheckBox();
            btnMaterialSearch = new Button();
            txbIdMaterial = new TextBox();
            cboMaterial = new ComboBox();
            label2 = new Label();
            chbProviderRemoved = new CheckBox();
            btnProviderSearch = new Button();
            txbIdProvider = new TextBox();
            cboProvider = new ComboBox();
            label4 = new Label();
            txbQuant = new TextBox();
            label7 = new Label();
            txbUnit = new TextBox();
            txbMXN = new TextBox();
            label9 = new Label();
            label10 = new Label();
            txbUSD = new TextBox();
            label12 = new Label();
            label13 = new Label();
            chbWarehouseRemoved = new CheckBox();
            btnWarehouseSearch = new Button();
            txbIdWarehouse = new TextBox();
            cboWarehouse = new ComboBox();
            label14 = new Label();
            label15 = new Label();
            pbxMaterial = new PictureBox();
            dgvMaterialList = new DataGridView();
            btnAddMaterial = new Button();
            btnModifyMaterial = new Button();
            btnRemoveMaterial = new Button();
            btnSave = new Button();
            btnCancel = new Button();
            btnFreightContainerAdd = new Button();
            btnDriverAdd = new Button();
            btnTransportLineAdd = new Button();
            btnProviderAdd = new Button();
            btnMaterialAdd = new Button();
            btnMaterialImageAdd = new Button();
            chbGrowerRemoved = new CheckBox();
            btnGrowerSearch = new Button();
            txbIdGrower = new TextBox();
            cboGrower = new ComboBox();
            label6 = new Label();
            btnEmployeeSearch = new Button();
            cboEmployee = new ComboBox();
            txbIdEmployee = new TextBox();
            txbObs = new TextBox();
            label16 = new Label();
            chbImageFront = new CheckBox();
            chbImageBack = new CheckBox();
            chbImageDown = new CheckBox();
            chbImageUp = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pbxMaterial).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMaterialList).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial Black", 12F);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(185, 23);
            lblTitle.TabIndex = 250;
            lblTitle.Text = "Registro de entrada";
            // 
            // txbId
            // 
            txbId.Enabled = false;
            txbId.Font = new Font("Arial", 9F, FontStyle.Bold);
            txbId.ForeColor = Color.SteelBlue;
            txbId.Location = new Point(67, 44);
            txbId.Margin = new Padding(1, 1, 0, 0);
            txbId.Name = "txbId";
            txbId.Size = new Size(126, 21);
            txbId.TabIndex = 253;
            txbId.TextAlign = HorizontalAlignment.Center;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Microsoft Sans Serif", 9F);
            lblId.Location = new Point(16, 46);
            lblId.Margin = new Padding(1, 1, 0, 0);
            lblId.Name = "lblId";
            lblId.Size = new Size(53, 15);
            lblId.TabIndex = 254;
            lblId.Text = "Entrada:";
            // 
            // chbDistributorRemoved
            // 
            chbDistributorRemoved.Appearance = Appearance.Button;
            chbDistributorRemoved.AutoSize = true;
            chbDistributorRemoved.Font = new Font("Segoe UI", 7.8F);
            chbDistributorRemoved.ForeColor = Color.DarkGray;
            chbDistributorRemoved.Image = Properties.Resources.removedList16;
            chbDistributorRemoved.Location = new Point(726, 154);
            chbDistributorRemoved.Margin = new Padding(1, 1, 0, 0);
            chbDistributorRemoved.Name = "chbDistributorRemoved";
            chbDistributorRemoved.Size = new Size(23, 23);
            chbDistributorRemoved.TabIndex = 378;
            chbDistributorRemoved.Text = "  ";
            chbDistributorRemoved.UseVisualStyleBackColor = true;
            // 
            // btnSearchDistributor
            // 
            btnSearchDistributor.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnSearchDistributor.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearchDistributor.Font = new Font("Microsoft Sans Serif", 9F);
            btnSearchDistributor.Location = new Point(704, 154);
            btnSearchDistributor.Margin = new Padding(1, 1, 0, 0);
            btnSearchDistributor.Name = "btnSearchDistributor";
            btnSearchDistributor.Size = new Size(23, 23);
            btnSearchDistributor.TabIndex = 375;
            btnSearchDistributor.UseVisualStyleBackColor = true;
            btnSearchDistributor.Click += btnSearchDistributor_Click;
            // 
            // txbIdDistributor
            // 
            txbIdDistributor.Enabled = false;
            txbIdDistributor.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdDistributor.Location = new Point(430, 155);
            txbIdDistributor.Margin = new Padding(1, 1, 0, 0);
            txbIdDistributor.Name = "txbIdDistributor";
            txbIdDistributor.Size = new Size(38, 21);
            txbIdDistributor.TabIndex = 377;
            txbIdDistributor.TextAlign = HorizontalAlignment.Center;
            // 
            // cboDistributor
            // 
            cboDistributor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDistributor.Font = new Font("Microsoft Sans Serif", 8.25F);
            cboDistributor.FormattingEnabled = true;
            cboDistributor.ItemHeight = 13;
            cboDistributor.Location = new Point(469, 155);
            cboDistributor.Margin = new Padding(1, 1, 0, 0);
            cboDistributor.Name = "cboDistributor";
            cboDistributor.Size = new Size(235, 21);
            cboDistributor.TabIndex = 374;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 9F);
            label3.Location = new Point(359, 157);
            label3.Margin = new Padding(1, 1, 0, 0);
            label3.Name = "label3";
            label3.Size = new Size(73, 15);
            label3.TabIndex = 376;
            label3.Text = "Distribuidor:";
            label3.TextAlign = ContentAlignment.TopRight;
            // 
            // chbFreightContainerRemoved
            // 
            chbFreightContainerRemoved.Appearance = Appearance.Button;
            chbFreightContainerRemoved.AutoSize = true;
            chbFreightContainerRemoved.Font = new Font("Segoe UI", 7.8F);
            chbFreightContainerRemoved.ForeColor = Color.DarkGray;
            chbFreightContainerRemoved.Image = Properties.Resources.removedList16;
            chbFreightContainerRemoved.Location = new Point(300, 153);
            chbFreightContainerRemoved.Margin = new Padding(1, 1, 0, 0);
            chbFreightContainerRemoved.Name = "chbFreightContainerRemoved";
            chbFreightContainerRemoved.Size = new Size(23, 23);
            chbFreightContainerRemoved.TabIndex = 398;
            chbFreightContainerRemoved.Text = "  ";
            chbFreightContainerRemoved.UseVisualStyleBackColor = true;
            // 
            // chbDriverRemoved
            // 
            chbDriverRemoved.Appearance = Appearance.Button;
            chbDriverRemoved.AutoSize = true;
            chbDriverRemoved.Font = new Font("Segoe UI", 7.8F);
            chbDriverRemoved.ForeColor = Color.DarkGray;
            chbDriverRemoved.Image = Properties.Resources.removedList16;
            chbDriverRemoved.Location = new Point(300, 131);
            chbDriverRemoved.Margin = new Padding(1, 1, 0, 0);
            chbDriverRemoved.Name = "chbDriverRemoved";
            chbDriverRemoved.Size = new Size(23, 23);
            chbDriverRemoved.TabIndex = 396;
            chbDriverRemoved.Text = "  ";
            chbDriverRemoved.UseVisualStyleBackColor = true;
            // 
            // chbTransportLineRemoved
            // 
            chbTransportLineRemoved.Appearance = Appearance.Button;
            chbTransportLineRemoved.AutoSize = true;
            chbTransportLineRemoved.Font = new Font("Segoe UI", 7.8F);
            chbTransportLineRemoved.ForeColor = Color.DarkGray;
            chbTransportLineRemoved.Image = Properties.Resources.removedList16;
            chbTransportLineRemoved.Location = new Point(300, 109);
            chbTransportLineRemoved.Margin = new Padding(1, 1, 0, 0);
            chbTransportLineRemoved.Name = "chbTransportLineRemoved";
            chbTransportLineRemoved.Size = new Size(23, 23);
            chbTransportLineRemoved.TabIndex = 395;
            chbTransportLineRemoved.Text = "  ";
            chbTransportLineRemoved.UseVisualStyleBackColor = true;
            // 
            // btnFreightContainerSearch
            // 
            btnFreightContainerSearch.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnFreightContainerSearch.BackgroundImageLayout = ImageLayout.Stretch;
            btnFreightContainerSearch.Font = new Font("Microsoft Sans Serif", 9F);
            btnFreightContainerSearch.Location = new Point(278, 153);
            btnFreightContainerSearch.Margin = new Padding(1, 1, 0, 0);
            btnFreightContainerSearch.Name = "btnFreightContainerSearch";
            btnFreightContainerSearch.Size = new Size(23, 23);
            btnFreightContainerSearch.TabIndex = 388;
            btnFreightContainerSearch.UseVisualStyleBackColor = true;
            btnFreightContainerSearch.Click += btnFreightContainerSearch_Click;
            // 
            // btnDriverSearch
            // 
            btnDriverSearch.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnDriverSearch.BackgroundImageLayout = ImageLayout.Stretch;
            btnDriverSearch.Font = new Font("Microsoft Sans Serif", 9F);
            btnDriverSearch.Location = new Point(278, 131);
            btnDriverSearch.Margin = new Padding(1, 1, 0, 0);
            btnDriverSearch.Name = "btnDriverSearch";
            btnDriverSearch.Size = new Size(23, 23);
            btnDriverSearch.TabIndex = 386;
            btnDriverSearch.UseVisualStyleBackColor = true;
            btnDriverSearch.Click += btnDriverSearch_Click;
            // 
            // txbIdFreightContainer
            // 
            txbIdFreightContainer.Enabled = false;
            txbIdFreightContainer.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdFreightContainer.Location = new Point(67, 154);
            txbIdFreightContainer.Margin = new Padding(1, 1, 0, 0);
            txbIdFreightContainer.Name = "txbIdFreightContainer";
            txbIdFreightContainer.Size = new Size(37, 21);
            txbIdFreightContainer.TabIndex = 394;
            txbIdFreightContainer.TextAlign = HorizontalAlignment.Center;
            // 
            // cboFreightContainer
            // 
            cboFreightContainer.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFreightContainer.Font = new Font("Microsoft Sans Serif", 8.25F);
            cboFreightContainer.FormattingEnabled = true;
            cboFreightContainer.ItemHeight = 13;
            cboFreightContainer.Location = new Point(105, 154);
            cboFreightContainer.Margin = new Padding(1, 1, 0, 0);
            cboFreightContainer.Name = "cboFreightContainer";
            cboFreightContainer.Size = new Size(173, 21);
            cboFreightContainer.TabIndex = 385;
            // 
            // txbIdDriver
            // 
            txbIdDriver.Enabled = false;
            txbIdDriver.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdDriver.Location = new Point(67, 132);
            txbIdDriver.Margin = new Padding(1, 1, 0, 0);
            txbIdDriver.Name = "txbIdDriver";
            txbIdDriver.Size = new Size(37, 21);
            txbIdDriver.TabIndex = 390;
            txbIdDriver.TextAlign = HorizontalAlignment.Center;
            // 
            // cboDriver
            // 
            cboDriver.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDriver.Font = new Font("Microsoft Sans Serif", 8.25F);
            cboDriver.FormattingEnabled = true;
            cboDriver.ItemHeight = 13;
            cboDriver.Location = new Point(105, 132);
            cboDriver.Margin = new Padding(1, 1, 0, 0);
            cboDriver.Name = "cboDriver";
            cboDriver.Size = new Size(173, 21);
            cboDriver.TabIndex = 383;
            // 
            // btnTransportLineSearch
            // 
            btnTransportLineSearch.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnTransportLineSearch.BackgroundImageLayout = ImageLayout.Stretch;
            btnTransportLineSearch.Font = new Font("Microsoft Sans Serif", 9F);
            btnTransportLineSearch.Location = new Point(278, 109);
            btnTransportLineSearch.Margin = new Padding(1, 1, 0, 0);
            btnTransportLineSearch.Name = "btnTransportLineSearch";
            btnTransportLineSearch.Size = new Size(23, 23);
            btnTransportLineSearch.TabIndex = 381;
            btnTransportLineSearch.UseVisualStyleBackColor = true;
            btnTransportLineSearch.Click += btnTransportLineSearch_Click;
            // 
            // txbIdTransportLine
            // 
            txbIdTransportLine.Enabled = false;
            txbIdTransportLine.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdTransportLine.Location = new Point(67, 110);
            txbIdTransportLine.Margin = new Padding(1, 1, 0, 0);
            txbIdTransportLine.Name = "txbIdTransportLine";
            txbIdTransportLine.Size = new Size(37, 21);
            txbIdTransportLine.TabIndex = 382;
            txbIdTransportLine.TextAlign = HorizontalAlignment.Center;
            // 
            // cboTransportLine
            // 
            cboTransportLine.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTransportLine.Font = new Font("Microsoft Sans Serif", 8.25F);
            cboTransportLine.FormattingEnabled = true;
            cboTransportLine.ItemHeight = 13;
            cboTransportLine.Location = new Point(105, 110);
            cboTransportLine.Margin = new Padding(1, 1, 0, 0);
            cboTransportLine.Name = "cboTransportLine";
            cboTransportLine.Size = new Size(173, 21);
            cboTransportLine.TabIndex = 380;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 9F);
            label5.Location = new Point(34, 157);
            label5.Margin = new Padding(1, 1, 0, 0);
            label5.Name = "label5";
            label5.Size = new Size(35, 15);
            label5.TabIndex = 393;
            label5.Text = "Caja:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 9F);
            label8.Location = new Point(23, 134);
            label8.Margin = new Padding(1, 1, 0, 0);
            label8.Name = "label8";
            label8.Size = new Size(46, 15);
            label8.TabIndex = 389;
            label8.Text = "Chofer:";
            label8.TextAlign = ContentAlignment.TopRight;
            // 
            // lblLinea
            // 
            lblLinea.AutoSize = true;
            lblLinea.Font = new Font("Microsoft Sans Serif", 9F);
            lblLinea.Location = new Point(10, 113);
            lblLinea.Margin = new Padding(1, 1, 0, 0);
            lblLinea.Name = "lblLinea";
            lblLinea.Size = new Size(54, 15);
            lblLinea.TabIndex = 379;
            lblLinea.Text = "Línea T.:";
            lblLinea.TextAlign = ContentAlignment.TopRight;
            // 
            // dtpDate
            // 
            dtpDate.Font = new Font("Microsoft Sans Serif", 9F);
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.Location = new Point(239, 44);
            dtpDate.MaxDate = new DateTime(2050, 12, 31, 0, 0, 0, 0);
            dtpDate.MinDate = new DateTime(2000, 1, 1, 0, 0, 0, 0);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(84, 21);
            dtpDate.TabIndex = 400;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Microsoft Sans Serif", 9F);
            label17.Location = new Point(196, 46);
            label17.Name = "label17";
            label17.Size = new Size(44, 15);
            label17.TabIndex = 399;
            label17.Text = "Fecha:";
            // 
            // txbInvoice
            // 
            txbInvoice.Font = new Font("Microsoft Sans Serif", 9F);
            txbInvoice.Location = new Point(431, 23);
            txbInvoice.Margin = new Padding(1, 1, 0, 0);
            txbInvoice.MaxLength = 20;
            txbInvoice.Name = "txbInvoice";
            txbInvoice.Size = new Size(201, 21);
            txbInvoice.TabIndex = 401;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft Sans Serif", 9F);
            label11.Location = new Point(395, 27);
            label11.Margin = new Padding(1, 1, 0, 0);
            label11.Name = "label11";
            label11.Size = new Size(37, 15);
            label11.TabIndex = 402;
            label11.Text = "Folio:";
            label11.TextAlign = ContentAlignment.TopRight;
            // 
            // btnMaterialTypeSearch
            // 
            btnMaterialTypeSearch.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnMaterialTypeSearch.BackgroundImageLayout = ImageLayout.Stretch;
            btnMaterialTypeSearch.Font = new Font("Microsoft Sans Serif", 9F);
            btnMaterialTypeSearch.Location = new Point(703, 44);
            btnMaterialTypeSearch.Margin = new Padding(1, 1, 0, 0);
            btnMaterialTypeSearch.Name = "btnMaterialTypeSearch";
            btnMaterialTypeSearch.Size = new Size(23, 23);
            btnMaterialTypeSearch.TabIndex = 404;
            btnMaterialTypeSearch.UseVisualStyleBackColor = true;
            btnMaterialTypeSearch.Click += btnMaterialTypeSearch_Click;
            // 
            // txbIdMaterialType
            // 
            txbIdMaterialType.Enabled = false;
            txbIdMaterialType.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdMaterialType.Location = new Point(431, 45);
            txbIdMaterialType.Margin = new Padding(1, 1, 0, 0);
            txbIdMaterialType.Name = "txbIdMaterialType";
            txbIdMaterialType.Size = new Size(37, 21);
            txbIdMaterialType.TabIndex = 406;
            txbIdMaterialType.TextAlign = HorizontalAlignment.Center;
            // 
            // cboMaterialType
            // 
            cboMaterialType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMaterialType.Font = new Font("Microsoft Sans Serif", 8.25F);
            cboMaterialType.FormattingEnabled = true;
            cboMaterialType.ItemHeight = 13;
            cboMaterialType.Location = new Point(469, 45);
            cboMaterialType.Margin = new Padding(1, 1, 0, 0);
            cboMaterialType.Name = "cboMaterialType";
            cboMaterialType.Size = new Size(234, 21);
            cboMaterialType.TabIndex = 403;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 9F);
            label1.Location = new Point(350, 48);
            label1.Margin = new Padding(1, 1, 0, 0);
            label1.Name = "label1";
            label1.Size = new Size(82, 15);
            label1.TabIndex = 405;
            label1.Text = "Tipo material:";
            label1.TextAlign = ContentAlignment.TopRight;
            // 
            // chbMaterialRemoved
            // 
            chbMaterialRemoved.Appearance = Appearance.Button;
            chbMaterialRemoved.AutoSize = true;
            chbMaterialRemoved.Font = new Font("Segoe UI", 7.8F);
            chbMaterialRemoved.ForeColor = Color.DarkGray;
            chbMaterialRemoved.Image = Properties.Resources.removedList16;
            chbMaterialRemoved.Location = new Point(725, 66);
            chbMaterialRemoved.Margin = new Padding(1, 1, 0, 0);
            chbMaterialRemoved.Name = "chbMaterialRemoved";
            chbMaterialRemoved.Size = new Size(23, 23);
            chbMaterialRemoved.TabIndex = 412;
            chbMaterialRemoved.Text = "  ";
            chbMaterialRemoved.UseVisualStyleBackColor = true;
            // 
            // btnMaterialSearch
            // 
            btnMaterialSearch.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnMaterialSearch.BackgroundImageLayout = ImageLayout.Stretch;
            btnMaterialSearch.Font = new Font("Microsoft Sans Serif", 9F);
            btnMaterialSearch.Location = new Point(703, 66);
            btnMaterialSearch.Margin = new Padding(1, 1, 0, 0);
            btnMaterialSearch.Name = "btnMaterialSearch";
            btnMaterialSearch.Size = new Size(23, 23);
            btnMaterialSearch.TabIndex = 409;
            btnMaterialSearch.UseVisualStyleBackColor = true;
            btnMaterialSearch.Click += btnMaterialSearch_Click;
            // 
            // txbIdMaterial
            // 
            txbIdMaterial.Enabled = false;
            txbIdMaterial.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdMaterial.Location = new Point(431, 67);
            txbIdMaterial.Margin = new Padding(1, 1, 0, 0);
            txbIdMaterial.Name = "txbIdMaterial";
            txbIdMaterial.Size = new Size(53, 21);
            txbIdMaterial.TabIndex = 411;
            txbIdMaterial.TextAlign = HorizontalAlignment.Center;
            // 
            // cboMaterial
            // 
            cboMaterial.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMaterial.Font = new Font("Microsoft Sans Serif", 8.25F);
            cboMaterial.FormattingEnabled = true;
            cboMaterial.ItemHeight = 13;
            cboMaterial.Location = new Point(485, 67);
            cboMaterial.Margin = new Padding(1, 1, 0, 0);
            cboMaterial.Name = "cboMaterial";
            cboMaterial.Size = new Size(218, 21);
            cboMaterial.TabIndex = 408;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 9F);
            label2.Location = new Point(377, 70);
            label2.Margin = new Padding(1, 1, 0, 0);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 410;
            label2.Text = "Material:";
            label2.TextAlign = ContentAlignment.TopRight;
            // 
            // chbProviderRemoved
            // 
            chbProviderRemoved.Appearance = Appearance.Button;
            chbProviderRemoved.AutoSize = true;
            chbProviderRemoved.Font = new Font("Segoe UI", 7.8F);
            chbProviderRemoved.ForeColor = Color.DarkGray;
            chbProviderRemoved.Image = Properties.Resources.removedList16;
            chbProviderRemoved.Location = new Point(726, 132);
            chbProviderRemoved.Margin = new Padding(1, 1, 0, 0);
            chbProviderRemoved.Name = "chbProviderRemoved";
            chbProviderRemoved.Size = new Size(23, 23);
            chbProviderRemoved.TabIndex = 417;
            chbProviderRemoved.Text = "  ";
            chbProviderRemoved.UseVisualStyleBackColor = true;
            // 
            // btnProviderSearch
            // 
            btnProviderSearch.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnProviderSearch.BackgroundImageLayout = ImageLayout.Stretch;
            btnProviderSearch.Font = new Font("Microsoft Sans Serif", 9F);
            btnProviderSearch.Location = new Point(704, 132);
            btnProviderSearch.Margin = new Padding(1, 1, 0, 0);
            btnProviderSearch.Name = "btnProviderSearch";
            btnProviderSearch.Size = new Size(23, 23);
            btnProviderSearch.TabIndex = 414;
            btnProviderSearch.UseVisualStyleBackColor = true;
            btnProviderSearch.Click += btnProviderSearch_Click;
            // 
            // txbIdProvider
            // 
            txbIdProvider.Enabled = false;
            txbIdProvider.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdProvider.Location = new Point(431, 133);
            txbIdProvider.Margin = new Padding(1, 1, 0, 0);
            txbIdProvider.Name = "txbIdProvider";
            txbIdProvider.Size = new Size(37, 21);
            txbIdProvider.TabIndex = 416;
            txbIdProvider.TextAlign = HorizontalAlignment.Center;
            // 
            // cboProvider
            // 
            cboProvider.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProvider.Font = new Font("Microsoft Sans Serif", 8.25F);
            cboProvider.FormattingEnabled = true;
            cboProvider.ItemHeight = 13;
            cboProvider.Location = new Point(469, 133);
            cboProvider.Margin = new Padding(1, 1, 0, 0);
            cboProvider.Name = "cboProvider";
            cboProvider.Size = new Size(235, 21);
            cboProvider.TabIndex = 413;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 9F);
            label4.Location = new Point(367, 135);
            label4.Margin = new Padding(1, 1, 0, 0);
            label4.Name = "label4";
            label4.Size = new Size(66, 15);
            label4.TabIndex = 415;
            label4.Text = "Proveedor:";
            label4.TextAlign = ContentAlignment.TopRight;
            // 
            // txbQuant
            // 
            txbQuant.Font = new Font("Microsoft Sans Serif", 9F);
            txbQuant.Location = new Point(430, 89);
            txbQuant.Margin = new Padding(1, 1, 0, 0);
            txbQuant.Name = "txbQuant";
            txbQuant.Size = new Size(97, 21);
            txbQuant.TabIndex = 418;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 9F);
            label7.Location = new Point(373, 92);
            label7.Margin = new Padding(1, 1, 0, 0);
            label7.Name = "label7";
            label7.Size = new Size(59, 15);
            label7.TabIndex = 419;
            label7.Text = "Cantidad:";
            label7.TextAlign = ContentAlignment.TopRight;
            // 
            // txbUnit
            // 
            txbUnit.Enabled = false;
            txbUnit.Font = new Font("Microsoft Sans Serif", 9F);
            txbUnit.Location = new Point(574, 89);
            txbUnit.Margin = new Padding(1, 1, 0, 0);
            txbUnit.Name = "txbUnit";
            txbUnit.Size = new Size(129, 21);
            txbUnit.TabIndex = 420;
            // 
            // txbMXN
            // 
            txbMXN.Font = new Font("Microsoft Sans Serif", 9F);
            txbMXN.Location = new Point(469, 111);
            txbMXN.Margin = new Padding(1, 1, 0, 0);
            txbMXN.Name = "txbMXN";
            txbMXN.Size = new Size(58, 21);
            txbMXN.TabIndex = 421;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 9F);
            label9.Location = new Point(381, 114);
            label9.Margin = new Padding(1, 1, 0, 0);
            label9.Name = "label9";
            label9.Size = new Size(51, 15);
            label9.TabIndex = 422;
            label9.Text = "Precios:";
            label9.TextAlign = ContentAlignment.TopRight;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 9F);
            label10.Location = new Point(435, 114);
            label10.Margin = new Padding(1, 1, 0, 0);
            label10.Name = "label10";
            label10.Size = new Size(38, 15);
            label10.TabIndex = 423;
            label10.Text = "MXN:";
            label10.TextAlign = ContentAlignment.TopRight;
            // 
            // txbUSD
            // 
            txbUSD.Font = new Font("Microsoft Sans Serif", 9F);
            txbUSD.Location = new Point(574, 111);
            txbUSD.Margin = new Padding(1, 1, 0, 0);
            txbUSD.Name = "txbUSD";
            txbUSD.Size = new Size(58, 21);
            txbUSD.TabIndex = 424;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 9F);
            label12.Location = new Point(541, 114);
            label12.Margin = new Padding(1, 1, 0, 0);
            label12.Name = "label12";
            label12.Size = new Size(36, 15);
            label12.TabIndex = 425;
            label12.Text = "USD:";
            label12.TextAlign = ContentAlignment.TopRight;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Microsoft Sans Serif", 9F);
            label13.Location = new Point(528, 92);
            label13.Margin = new Padding(1, 1, 0, 0);
            label13.Name = "label13";
            label13.Size = new Size(50, 15);
            label13.TabIndex = 426;
            label13.Text = "Unidad:";
            label13.TextAlign = ContentAlignment.TopRight;
            // 
            // chbWarehouseRemoved
            // 
            chbWarehouseRemoved.Appearance = Appearance.Button;
            chbWarehouseRemoved.AutoSize = true;
            chbWarehouseRemoved.Font = new Font("Segoe UI", 7.8F);
            chbWarehouseRemoved.ForeColor = Color.DarkGray;
            chbWarehouseRemoved.Image = Properties.Resources.removedList16;
            chbWarehouseRemoved.Location = new Point(300, 65);
            chbWarehouseRemoved.Margin = new Padding(1, 1, 0, 0);
            chbWarehouseRemoved.Name = "chbWarehouseRemoved";
            chbWarehouseRemoved.Size = new Size(23, 23);
            chbWarehouseRemoved.TabIndex = 431;
            chbWarehouseRemoved.Text = "  ";
            chbWarehouseRemoved.UseVisualStyleBackColor = true;
            // 
            // btnWarehouseSearch
            // 
            btnWarehouseSearch.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnWarehouseSearch.BackgroundImageLayout = ImageLayout.Stretch;
            btnWarehouseSearch.Font = new Font("Microsoft Sans Serif", 9F);
            btnWarehouseSearch.Location = new Point(278, 65);
            btnWarehouseSearch.Margin = new Padding(1, 1, 0, 0);
            btnWarehouseSearch.Name = "btnWarehouseSearch";
            btnWarehouseSearch.Size = new Size(23, 23);
            btnWarehouseSearch.TabIndex = 428;
            btnWarehouseSearch.UseVisualStyleBackColor = true;
            btnWarehouseSearch.Click += btnWarehouseSearch_Click;
            // 
            // txbIdWarehouse
            // 
            txbIdWarehouse.Enabled = false;
            txbIdWarehouse.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdWarehouse.Location = new Point(67, 66);
            txbIdWarehouse.Margin = new Padding(1, 1, 0, 0);
            txbIdWarehouse.Name = "txbIdWarehouse";
            txbIdWarehouse.Size = new Size(37, 21);
            txbIdWarehouse.TabIndex = 430;
            txbIdWarehouse.TextAlign = HorizontalAlignment.Center;
            // 
            // cboWarehouse
            // 
            cboWarehouse.DropDownStyle = ComboBoxStyle.DropDownList;
            cboWarehouse.Font = new Font("Microsoft Sans Serif", 8.25F);
            cboWarehouse.FormattingEnabled = true;
            cboWarehouse.ItemHeight = 13;
            cboWarehouse.Location = new Point(105, 66);
            cboWarehouse.Margin = new Padding(1, 1, 0, 0);
            cboWarehouse.Name = "cboWarehouse";
            cboWarehouse.Size = new Size(173, 21);
            cboWarehouse.TabIndex = 427;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Microsoft Sans Serif", 9F);
            label14.Location = new Point(10, 69);
            label14.Margin = new Padding(1, 1, 0, 0);
            label14.Name = "label14";
            label14.Size = new Size(58, 15);
            label14.TabIndex = 429;
            label14.Text = "Almacén:";
            label14.TextAlign = ContentAlignment.TopRight;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Microsoft Sans Serif", 9F);
            label15.Location = new Point(16, 91);
            label15.Margin = new Padding(1, 1, 0, 0);
            label15.Name = "label15";
            label15.Size = new Size(52, 15);
            label15.TabIndex = 433;
            label15.Text = "Recibió:";
            label15.TextAlign = ContentAlignment.TopRight;
            // 
            // pbxMaterial
            // 
            pbxMaterial.BackgroundImageLayout = ImageLayout.Stretch;
            pbxMaterial.BorderStyle = BorderStyle.Fixed3D;
            pbxMaterial.Location = new Point(775, 43);
            pbxMaterial.Name = "pbxMaterial";
            pbxMaterial.Size = new Size(132, 132);
            pbxMaterial.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxMaterial.TabIndex = 440;
            pbxMaterial.TabStop = false;
            // 
            // dgvMaterialList
            // 
            dgvMaterialList.AllowUserToAddRows = false;
            dgvMaterialList.AllowUserToDeleteRows = false;
            dgvMaterialList.AllowUserToOrderColumns = true;
            dgvMaterialList.AllowUserToResizeRows = false;
            dgvMaterialList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMaterialList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvMaterialList.BackgroundColor = SystemColors.ControlLightLight;
            dgvMaterialList.BorderStyle = BorderStyle.Fixed3D;
            dgvMaterialList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvMaterialList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvMaterialList.EnableHeadersVisualStyles = false;
            dgvMaterialList.ImeMode = ImeMode.NoControl;
            dgvMaterialList.Location = new Point(11, 224);
            dgvMaterialList.MultiSelect = false;
            dgvMaterialList.Name = "dgvMaterialList";
            dgvMaterialList.ReadOnly = true;
            dgvMaterialList.RightToLeft = RightToLeft.No;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvMaterialList.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvMaterialList.RowHeadersVisible = false;
            dgvMaterialList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMaterialList.Size = new Size(948, 268);
            dgvMaterialList.TabIndex = 441;
            // 
            // btnAddMaterial
            // 
            btnAddMaterial.BackColor = Color.GreenYellow;
            btnAddMaterial.BackgroundImageLayout = ImageLayout.Stretch;
            btnAddMaterial.Font = new Font("Microsoft Sans Serif", 9F);
            btnAddMaterial.Location = new Point(600, 198);
            btnAddMaterial.Margin = new Padding(1, 1, 0, 0);
            btnAddMaterial.Name = "btnAddMaterial";
            btnAddMaterial.Size = new Size(69, 23);
            btnAddMaterial.TabIndex = 442;
            btnAddMaterial.Text = "Agregar";
            btnAddMaterial.UseVisualStyleBackColor = false;
            btnAddMaterial.Click += btnAddMaterial_Click;
            // 
            // btnModifyMaterial
            // 
            btnModifyMaterial.BackColor = Color.FromArgb(255, 255, 128);
            btnModifyMaterial.BackgroundImageLayout = ImageLayout.Stretch;
            btnModifyMaterial.Font = new Font("Microsoft Sans Serif", 9F);
            btnModifyMaterial.Location = new Point(670, 198);
            btnModifyMaterial.Margin = new Padding(1, 1, 0, 0);
            btnModifyMaterial.Name = "btnModifyMaterial";
            btnModifyMaterial.Size = new Size(69, 23);
            btnModifyMaterial.TabIndex = 443;
            btnModifyMaterial.Text = "Modificar";
            btnModifyMaterial.UseVisualStyleBackColor = false;
            btnModifyMaterial.Click += btnModifyMaterial_Click;
            // 
            // btnRemoveMaterial
            // 
            btnRemoveMaterial.BackColor = Color.Salmon;
            btnRemoveMaterial.BackgroundImageLayout = ImageLayout.Stretch;
            btnRemoveMaterial.Font = new Font("Microsoft Sans Serif", 9F);
            btnRemoveMaterial.Location = new Point(740, 198);
            btnRemoveMaterial.Margin = new Padding(1, 1, 0, 0);
            btnRemoveMaterial.Name = "btnRemoveMaterial";
            btnRemoveMaterial.Size = new Size(69, 23);
            btnRemoveMaterial.TabIndex = 444;
            btnRemoveMaterial.Text = "Eliminar";
            btnRemoveMaterial.UseVisualStyleBackColor = false;
            btnRemoveMaterial.Click += btnRemoveMaterial_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSave.BackColor = SystemColors.ControlLightLight;
            btnSave.BackgroundImageLayout = ImageLayout.Stretch;
            btnSave.Font = new Font("Microsoft Sans Serif", 9F);
            btnSave.Location = new Point(10, 496);
            btnSave.Margin = new Padding(1, 1, 0, 0);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(69, 23);
            btnSave.TabIndex = 446;
            btnSave.Text = "Guardar";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCancel.BackColor = SystemColors.ControlLightLight;
            btnCancel.BackgroundImageLayout = ImageLayout.Stretch;
            btnCancel.Font = new Font("Microsoft Sans Serif", 9F);
            btnCancel.Location = new Point(80, 496);
            btnCancel.Margin = new Padding(1, 1, 0, 0);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(69, 23);
            btnCancel.TabIndex = 447;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnFreightContainerAdd
            // 
            btnFreightContainerAdd.BackgroundImageLayout = ImageLayout.Stretch;
            btnFreightContainerAdd.Font = new Font("Microsoft Sans Serif", 9F);
            btnFreightContainerAdd.Image = Properties.Resources.AddRowIcon16;
            btnFreightContainerAdd.Location = new Point(322, 153);
            btnFreightContainerAdd.Margin = new Padding(1, 1, 0, 0);
            btnFreightContainerAdd.Name = "btnFreightContainerAdd";
            btnFreightContainerAdd.Size = new Size(24, 23);
            btnFreightContainerAdd.TabIndex = 450;
            btnFreightContainerAdd.UseVisualStyleBackColor = true;
            btnFreightContainerAdd.Click += btnFreightContainerAdd_Click;
            // 
            // btnDriverAdd
            // 
            btnDriverAdd.BackgroundImageLayout = ImageLayout.Stretch;
            btnDriverAdd.Font = new Font("Microsoft Sans Serif", 9F);
            btnDriverAdd.Image = Properties.Resources.AddRowIcon16;
            btnDriverAdd.Location = new Point(322, 131);
            btnDriverAdd.Margin = new Padding(1, 1, 0, 0);
            btnDriverAdd.Name = "btnDriverAdd";
            btnDriverAdd.Size = new Size(24, 23);
            btnDriverAdd.TabIndex = 449;
            btnDriverAdd.UseVisualStyleBackColor = true;
            btnDriverAdd.Click += btnDriverAdd_Click;
            // 
            // btnTransportLineAdd
            // 
            btnTransportLineAdd.BackgroundImageLayout = ImageLayout.Stretch;
            btnTransportLineAdd.Font = new Font("Microsoft Sans Serif", 9F);
            btnTransportLineAdd.Image = Properties.Resources.AddRowIcon16;
            btnTransportLineAdd.Location = new Point(322, 109);
            btnTransportLineAdd.Margin = new Padding(1, 1, 0, 0);
            btnTransportLineAdd.Name = "btnTransportLineAdd";
            btnTransportLineAdd.Size = new Size(24, 23);
            btnTransportLineAdd.TabIndex = 448;
            btnTransportLineAdd.UseVisualStyleBackColor = true;
            btnTransportLineAdd.Click += btnTransportLineAdd_Click;
            // 
            // btnProviderAdd
            // 
            btnProviderAdd.BackgroundImageLayout = ImageLayout.Stretch;
            btnProviderAdd.Font = new Font("Microsoft Sans Serif", 9F);
            btnProviderAdd.Image = Properties.Resources.AddRowIcon16;
            btnProviderAdd.Location = new Point(748, 132);
            btnProviderAdd.Margin = new Padding(1, 1, 0, 0);
            btnProviderAdd.Name = "btnProviderAdd";
            btnProviderAdd.Size = new Size(24, 23);
            btnProviderAdd.TabIndex = 451;
            btnProviderAdd.UseVisualStyleBackColor = true;
            btnProviderAdd.Click += btnProviderAdd_Click;
            // 
            // btnMaterialAdd
            // 
            btnMaterialAdd.BackgroundImageLayout = ImageLayout.Stretch;
            btnMaterialAdd.Font = new Font("Microsoft Sans Serif", 9F);
            btnMaterialAdd.Image = Properties.Resources.AddRowIcon16;
            btnMaterialAdd.Location = new Point(747, 66);
            btnMaterialAdd.Margin = new Padding(1, 1, 0, 0);
            btnMaterialAdd.Name = "btnMaterialAdd";
            btnMaterialAdd.Size = new Size(24, 23);
            btnMaterialAdd.TabIndex = 452;
            btnMaterialAdd.UseVisualStyleBackColor = true;
            btnMaterialAdd.Click += btnMaterialAdd_Click;
            // 
            // btnMaterialImageAdd
            // 
            btnMaterialImageAdd.BackgroundImageLayout = ImageLayout.Stretch;
            btnMaterialImageAdd.Font = new Font("Microsoft Sans Serif", 9F);
            btnMaterialImageAdd.Image = Properties.Resources.addImageIcon16;
            btnMaterialImageAdd.Location = new Point(885, 18);
            btnMaterialImageAdd.Margin = new Padding(1, 1, 0, 0);
            btnMaterialImageAdd.Name = "btnMaterialImageAdd";
            btnMaterialImageAdd.Size = new Size(22, 22);
            btnMaterialImageAdd.TabIndex = 453;
            btnMaterialImageAdd.UseVisualStyleBackColor = true;
            // 
            // chbGrowerRemoved
            // 
            chbGrowerRemoved.Appearance = Appearance.Button;
            chbGrowerRemoved.AutoSize = true;
            chbGrowerRemoved.Font = new Font("Segoe UI", 7.8F);
            chbGrowerRemoved.ForeColor = Color.DarkGray;
            chbGrowerRemoved.Image = Properties.Resources.removedList16;
            chbGrowerRemoved.Location = new Point(726, 176);
            chbGrowerRemoved.Margin = new Padding(1, 1, 0, 0);
            chbGrowerRemoved.Name = "chbGrowerRemoved";
            chbGrowerRemoved.Size = new Size(23, 23);
            chbGrowerRemoved.TabIndex = 458;
            chbGrowerRemoved.Text = "  ";
            chbGrowerRemoved.UseVisualStyleBackColor = true;
            // 
            // btnGrowerSearch
            // 
            btnGrowerSearch.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnGrowerSearch.BackgroundImageLayout = ImageLayout.Stretch;
            btnGrowerSearch.Font = new Font("Microsoft Sans Serif", 9F);
            btnGrowerSearch.Location = new Point(704, 176);
            btnGrowerSearch.Margin = new Padding(1, 1, 0, 0);
            btnGrowerSearch.Name = "btnGrowerSearch";
            btnGrowerSearch.Size = new Size(23, 23);
            btnGrowerSearch.TabIndex = 455;
            btnGrowerSearch.UseVisualStyleBackColor = true;
            btnGrowerSearch.Click += btnGrowerSearch_Click;
            // 
            // txbIdGrower
            // 
            txbIdGrower.Enabled = false;
            txbIdGrower.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdGrower.Location = new Point(431, 177);
            txbIdGrower.Margin = new Padding(1, 1, 0, 0);
            txbIdGrower.Name = "txbIdGrower";
            txbIdGrower.Size = new Size(37, 21);
            txbIdGrower.TabIndex = 457;
            txbIdGrower.TextAlign = HorizontalAlignment.Center;
            // 
            // cboGrower
            // 
            cboGrower.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGrower.Font = new Font("Microsoft Sans Serif", 8.25F);
            cboGrower.FormattingEnabled = true;
            cboGrower.ItemHeight = 13;
            cboGrower.Location = new Point(469, 177);
            cboGrower.Margin = new Padding(1, 1, 0, 0);
            cboGrower.Name = "cboGrower";
            cboGrower.Size = new Size(235, 21);
            cboGrower.TabIndex = 454;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 9F);
            label6.Location = new Point(368, 178);
            label6.Margin = new Padding(1, 1, 0, 0);
            label6.Name = "label6";
            label6.Size = new Size(63, 15);
            label6.TabIndex = 456;
            label6.Text = "Productor:";
            label6.TextAlign = ContentAlignment.TopRight;
            // 
            // btnEmployeeSearch
            // 
            btnEmployeeSearch.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnEmployeeSearch.BackgroundImageLayout = ImageLayout.Stretch;
            btnEmployeeSearch.Font = new Font("Microsoft Sans Serif", 9F);
            btnEmployeeSearch.Location = new Point(323, 87);
            btnEmployeeSearch.Margin = new Padding(1, 1, 0, 0);
            btnEmployeeSearch.Name = "btnEmployeeSearch";
            btnEmployeeSearch.Size = new Size(23, 23);
            btnEmployeeSearch.TabIndex = 460;
            btnEmployeeSearch.UseVisualStyleBackColor = true;
            btnEmployeeSearch.Click += btnEmployeeSearch_Click;
            // 
            // cboEmployee
            // 
            cboEmployee.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEmployee.Font = new Font("Microsoft Sans Serif", 8.25F);
            cboEmployee.FormattingEnabled = true;
            cboEmployee.ItemHeight = 13;
            cboEmployee.Location = new Point(128, 88);
            cboEmployee.Margin = new Padding(1, 1, 0, 0);
            cboEmployee.Name = "cboEmployee";
            cboEmployee.Size = new Size(195, 21);
            cboEmployee.TabIndex = 461;
            // 
            // txbIdEmployee
            // 
            txbIdEmployee.Enabled = false;
            txbIdEmployee.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdEmployee.Location = new Point(67, 88);
            txbIdEmployee.Margin = new Padding(1, 1, 0, 0);
            txbIdEmployee.Name = "txbIdEmployee";
            txbIdEmployee.Size = new Size(60, 21);
            txbIdEmployee.TabIndex = 462;
            txbIdEmployee.TextAlign = HorizontalAlignment.Center;
            // 
            // txbObs
            // 
            txbObs.Font = new Font("Microsoft Sans Serif", 9F);
            txbObs.Location = new Point(430, 199);
            txbObs.Margin = new Padding(1, 1, 0, 0);
            txbObs.MaxLength = 20;
            txbObs.Name = "txbObs";
            txbObs.Size = new Size(169, 21);
            txbObs.TabIndex = 463;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Microsoft Sans Serif", 9F);
            label16.Location = new Point(394, 202);
            label16.Margin = new Padding(1, 1, 0, 0);
            label16.Name = "label16";
            label16.Size = new Size(35, 15);
            label16.TabIndex = 464;
            label16.Text = "Obs.:";
            label16.TextAlign = ContentAlignment.TopRight;
            // 
            // chbImageFront
            // 
            chbImageFront.Appearance = Appearance.Button;
            chbImageFront.Font = new Font("Segoe UI", 8F);
            chbImageFront.ForeColor = Color.Black;
            chbImageFront.Location = new Point(797, 18);
            chbImageFront.Margin = new Padding(0);
            chbImageFront.Name = "chbImageFront";
            chbImageFront.Padding = new Padding(1, 0, 0, 0);
            chbImageFront.Size = new Size(22, 22);
            chbImageFront.TabIndex = 465;
            chbImageFront.Text = "1";
            chbImageFront.TextAlign = ContentAlignment.MiddleCenter;
            chbImageFront.UseVisualStyleBackColor = true;
            chbImageFront.Click += chbImageFront_Click;
            // 
            // chbImageBack
            // 
            chbImageBack.Appearance = Appearance.Button;
            chbImageBack.Font = new Font("Segoe UI", 8F);
            chbImageBack.ForeColor = Color.Black;
            chbImageBack.Location = new Point(819, 18);
            chbImageBack.Margin = new Padding(0);
            chbImageBack.Name = "chbImageBack";
            chbImageBack.Padding = new Padding(1, 0, 0, 0);
            chbImageBack.Size = new Size(22, 22);
            chbImageBack.TabIndex = 466;
            chbImageBack.Text = "2";
            chbImageBack.TextAlign = ContentAlignment.MiddleCenter;
            chbImageBack.UseVisualStyleBackColor = true;
            chbImageBack.Click += chbImageBack_Click;
            // 
            // chbImageDown
            // 
            chbImageDown.Appearance = Appearance.Button;
            chbImageDown.Font = new Font("Segoe UI", 8F);
            chbImageDown.ForeColor = Color.Black;
            chbImageDown.Location = new Point(841, 18);
            chbImageDown.Margin = new Padding(0);
            chbImageDown.Name = "chbImageDown";
            chbImageDown.Padding = new Padding(1, 0, 0, 0);
            chbImageDown.Size = new Size(22, 22);
            chbImageDown.TabIndex = 467;
            chbImageDown.Text = "3";
            chbImageDown.TextAlign = ContentAlignment.MiddleCenter;
            chbImageDown.UseVisualStyleBackColor = true;
            chbImageDown.Click += chbImageDown_Click;
            // 
            // chbImageUp
            // 
            chbImageUp.Appearance = Appearance.Button;
            chbImageUp.Font = new Font("Segoe UI", 8F);
            chbImageUp.ForeColor = Color.Black;
            chbImageUp.Location = new Point(863, 18);
            chbImageUp.Margin = new Padding(0);
            chbImageUp.Name = "chbImageUp";
            chbImageUp.Padding = new Padding(1, 0, 0, 0);
            chbImageUp.Size = new Size(22, 22);
            chbImageUp.TabIndex = 468;
            chbImageUp.Text = "4";
            chbImageUp.TextAlign = ContentAlignment.MiddleCenter;
            chbImageUp.UseVisualStyleBackColor = true;
            chbImageUp.Click += chbImageUp_Click;
            // 
            // FrmMaterialRegisterEntry
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(971, 523);
            Controls.Add(chbImageUp);
            Controls.Add(chbImageDown);
            Controls.Add(chbImageBack);
            Controls.Add(chbImageFront);
            Controls.Add(txbObs);
            Controls.Add(label16);
            Controls.Add(txbIdEmployee);
            Controls.Add(cboEmployee);
            Controls.Add(btnEmployeeSearch);
            Controls.Add(chbGrowerRemoved);
            Controls.Add(btnGrowerSearch);
            Controls.Add(txbIdGrower);
            Controls.Add(cboGrower);
            Controls.Add(label6);
            Controls.Add(btnMaterialImageAdd);
            Controls.Add(btnMaterialAdd);
            Controls.Add(btnProviderAdd);
            Controls.Add(btnFreightContainerAdd);
            Controls.Add(btnDriverAdd);
            Controls.Add(btnTransportLineAdd);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(btnRemoveMaterial);
            Controls.Add(btnModifyMaterial);
            Controls.Add(btnAddMaterial);
            Controls.Add(dgvMaterialList);
            Controls.Add(pbxMaterial);
            Controls.Add(label15);
            Controls.Add(chbWarehouseRemoved);
            Controls.Add(btnWarehouseSearch);
            Controls.Add(txbIdWarehouse);
            Controls.Add(cboWarehouse);
            Controls.Add(label14);
            Controls.Add(txbUSD);
            Controls.Add(label12);
            Controls.Add(txbMXN);
            Controls.Add(label9);
            Controls.Add(txbUnit);
            Controls.Add(txbQuant);
            Controls.Add(chbProviderRemoved);
            Controls.Add(btnProviderSearch);
            Controls.Add(txbIdProvider);
            Controls.Add(cboProvider);
            Controls.Add(label4);
            Controls.Add(chbMaterialRemoved);
            Controls.Add(btnMaterialSearch);
            Controls.Add(txbIdMaterial);
            Controls.Add(cboMaterial);
            Controls.Add(label2);
            Controls.Add(btnMaterialTypeSearch);
            Controls.Add(txbIdMaterialType);
            Controls.Add(cboMaterialType);
            Controls.Add(label1);
            Controls.Add(txbInvoice);
            Controls.Add(label11);
            Controls.Add(dtpDate);
            Controls.Add(label17);
            Controls.Add(chbFreightContainerRemoved);
            Controls.Add(chbDriverRemoved);
            Controls.Add(chbTransportLineRemoved);
            Controls.Add(btnFreightContainerSearch);
            Controls.Add(btnDriverSearch);
            Controls.Add(txbIdFreightContainer);
            Controls.Add(cboFreightContainer);
            Controls.Add(txbIdDriver);
            Controls.Add(cboDriver);
            Controls.Add(btnTransportLineSearch);
            Controls.Add(txbIdTransportLine);
            Controls.Add(cboTransportLine);
            Controls.Add(label5);
            Controls.Add(label8);
            Controls.Add(lblLinea);
            Controls.Add(chbDistributorRemoved);
            Controls.Add(btnSearchDistributor);
            Controls.Add(txbIdDistributor);
            Controls.Add(cboDistributor);
            Controls.Add(label3);
            Controls.Add(txbId);
            Controls.Add(lblId);
            Controls.Add(lblTitle);
            Controls.Add(label7);
            Controls.Add(label10);
            Controls.Add(label13);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmMaterialRegisterEntry";
            Text = "Registro de entrada de material";
            Load += FrmMaterialRegisterEntry_Load;
            ((System.ComponentModel.ISupportInitialize)pbxMaterial).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMaterialList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Label lblTitle;
        public TextBox txbId;
        private Label lblId;
        public CheckBox chbDistributorRemoved;
        public Button btnSearchDistributor;
        public TextBox txbIdDistributor;
        public ComboBox cboDistributor;
        private Label label3;
        public CheckBox chbFreightContainerRemoved;
        public CheckBox chbDriverRemoved;
        public CheckBox chbTransportLineRemoved;
        public Button btnFreightContainerSearch;
        public Button btnDriverSearch;
        public TextBox txbIdFreightContainer;
        public ComboBox cboFreightContainer;
        public TextBox txbIdDriver;
        public ComboBox cboDriver;
        public Button btnTransportLineSearch;
        public TextBox txbIdTransportLine;
        public ComboBox cboTransportLine;
        private Label label5;
        private Label label8;
        private Label lblLinea;
        public DateTimePicker dtpDate;
        private Label label17;
        public TextBox txbInvoice;
        private Label label11;
        public Button btnMaterialTypeSearch;
        public TextBox txbIdMaterialType;
        public ComboBox cboMaterialType;
        private Label label1;
        public CheckBox chbMaterialRemoved;
        public Button btnMaterialSearch;
        public TextBox txbIdMaterial;
        public ComboBox cboMaterial;
        private Label label2;
        public CheckBox chbProviderRemoved;
        public Button btnProviderSearch;
        public TextBox txbIdProvider;
        public ComboBox cboProvider;
        private Label label4;
        public TextBox txbQuant;
        private Label label7;
        public TextBox txbUnit;
        public TextBox txbMXN;
        private Label label9;
        private Label label10;
        public TextBox txbUSD;
        private Label label12;
        private Label label13;
        public CheckBox chbWarehouseRemoved;
        public Button btnWarehouseSearch;
        public TextBox txbIdWarehouse;
        public ComboBox cboWarehouse;
        private Label label14;
        private Label label15;
        public DataGridView dgvMaterialList;
        public Button btnAddMaterial;
        public Button btnModifyMaterial;
        public Button btnRemoveMaterial;
        public CheckBox checkBox11;
        public Button btnCancel;
        public Button btnSave;
        private DataGridViewTextBoxColumn Categoría;
        private DataGridViewTextBoxColumn Código;
        private DataGridViewTextBoxColumn Cantidad;
        private DataGridViewTextBoxColumn Unidad;
        private DataGridViewTextBoxColumn Concepto;
        private DataGridViewTextBoxColumn Precio_USD;
        private DataGridViewTextBoxColumn Precio_MXN;
        private DataGridViewTextBoxColumn Proveedor;
        private DataGridViewTextBoxColumn Distribuidor;
        public Button btnFreightContainerAdd;
        public Button btnDriverAdd;
        public Button btnTransportLineAdd;
        public Button btnProviderAdd;
        public Button btnMaterialAdd;
        public Button btnMaterialImageAdd;
        public CheckBox chbGrowerRemoved;
        public Button btnGrowerSearch;
        public TextBox txbIdGrower;
        public ComboBox cboGrower;
        private Label label6;
        public Button btnEmployeeSearch;
        public ComboBox cboEmployee;
        public TextBox txbIdEmployee;
        public TextBox textBox2;
        private Label label16;
        public TextBox txbObs;
        public CheckBox chbImageFront;
        public CheckBox chbImageBack;
        public CheckBox chbImageDown;
        public CheckBox chbImageUp;
        public PictureBox pbxMaterial;
    }
}