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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            lblTitle = new Label();
            txbId = new TextBox();
            lblId = new Label();
            chbRemovedDistributor = new CheckBox();
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
            chbCategoryRemoved = new CheckBox();
            btnCategorySearch = new Button();
            txbIdCategory = new TextBox();
            cboCategory = new ComboBox();
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
            txbReceiver = new TextBox();
            label15 = new Label();
            picMaterialImage = new PictureBox();
            dgvMaterialList = new DataGridView();
            Categoría = new DataGridViewTextBoxColumn();
            Código = new DataGridViewTextBoxColumn();
            Cantidad = new DataGridViewTextBoxColumn();
            Unidad = new DataGridViewTextBoxColumn();
            Concepto = new DataGridViewTextBoxColumn();
            Precio_USD = new DataGridViewTextBoxColumn();
            Precio_MXN = new DataGridViewTextBoxColumn();
            Proveedor = new DataGridViewTextBoxColumn();
            Distribuidor = new DataGridViewTextBoxColumn();
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
            ((System.ComponentModel.ISupportInitialize)picMaterialImage).BeginInit();
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
            txbId.Location = new Point(69, 37);
            txbId.Margin = new Padding(1, 1, 0, 0);
            txbId.Name = "txbId";
            txbId.Size = new Size(50, 21);
            txbId.TabIndex = 253;
            txbId.TextAlign = HorizontalAlignment.Center;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Microsoft Sans Serif", 9F);
            lblId.Location = new Point(18, 39);
            lblId.Margin = new Padding(1, 1, 0, 0);
            lblId.Name = "lblId";
            lblId.Size = new Size(53, 15);
            lblId.TabIndex = 254;
            lblId.Text = "Entrada:";
            // 
            // chbRemovedDistributor
            // 
            chbRemovedDistributor.Appearance = Appearance.Button;
            chbRemovedDistributor.AutoSize = true;
            chbRemovedDistributor.Font = new Font("Segoe UI", 7.8F);
            chbRemovedDistributor.ForeColor = Color.DarkGray;
            chbRemovedDistributor.Image = Properties.Resources.removedList16;
            chbRemovedDistributor.Location = new Point(377, 131);
            chbRemovedDistributor.Margin = new Padding(1, 1, 0, 0);
            chbRemovedDistributor.Name = "chbRemovedDistributor";
            chbRemovedDistributor.Size = new Size(23, 23);
            chbRemovedDistributor.TabIndex = 378;
            chbRemovedDistributor.Text = "  ";
            chbRemovedDistributor.UseVisualStyleBackColor = true;
            // 
            // btnSearchDistributor
            // 
            btnSearchDistributor.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnSearchDistributor.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearchDistributor.Enabled = false;
            btnSearchDistributor.Font = new Font("Microsoft Sans Serif", 9F);
            btnSearchDistributor.Location = new Point(355, 131);
            btnSearchDistributor.Margin = new Padding(1, 1, 0, 0);
            btnSearchDistributor.Name = "btnSearchDistributor";
            btnSearchDistributor.Size = new Size(23, 23);
            btnSearchDistributor.TabIndex = 375;
            btnSearchDistributor.UseVisualStyleBackColor = true;
            // 
            // txbIdDistributor
            // 
            txbIdDistributor.Enabled = false;
            txbIdDistributor.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdDistributor.Location = new Point(82, 132);
            txbIdDistributor.Margin = new Padding(1, 1, 0, 0);
            txbIdDistributor.Name = "txbIdDistributor";
            txbIdDistributor.Size = new Size(37, 21);
            txbIdDistributor.TabIndex = 377;
            txbIdDistributor.TextAlign = HorizontalAlignment.Center;
            // 
            // cboDistributor
            // 
            cboDistributor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDistributor.Font = new Font("Microsoft Sans Serif", 8.25F);
            cboDistributor.FormattingEnabled = true;
            cboDistributor.ItemHeight = 13;
            cboDistributor.Location = new Point(120, 132);
            cboDistributor.Margin = new Padding(1, 1, 0, 0);
            cboDistributor.Name = "cboDistributor";
            cboDistributor.Size = new Size(235, 21);
            cboDistributor.TabIndex = 374;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 9F);
            label3.Location = new Point(11, 134);
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
            chbFreightContainerRemoved.Location = new Point(378, 219);
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
            chbDriverRemoved.Location = new Point(378, 197);
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
            chbTransportLineRemoved.Location = new Point(378, 175);
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
            btnFreightContainerSearch.Location = new Point(356, 219);
            btnFreightContainerSearch.Margin = new Padding(1, 1, 0, 0);
            btnFreightContainerSearch.Name = "btnFreightContainerSearch";
            btnFreightContainerSearch.Size = new Size(23, 23);
            btnFreightContainerSearch.TabIndex = 388;
            btnFreightContainerSearch.UseVisualStyleBackColor = true;
            // 
            // btnDriverSearch
            // 
            btnDriverSearch.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnDriverSearch.BackgroundImageLayout = ImageLayout.Stretch;
            btnDriverSearch.Font = new Font("Microsoft Sans Serif", 9F);
            btnDriverSearch.Location = new Point(356, 197);
            btnDriverSearch.Margin = new Padding(1, 1, 0, 0);
            btnDriverSearch.Name = "btnDriverSearch";
            btnDriverSearch.Size = new Size(23, 23);
            btnDriverSearch.TabIndex = 386;
            btnDriverSearch.UseVisualStyleBackColor = true;
            // 
            // txbIdFreightContainer
            // 
            txbIdFreightContainer.Enabled = false;
            txbIdFreightContainer.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdFreightContainer.Location = new Point(83, 220);
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
            cboFreightContainer.Location = new Point(121, 220);
            cboFreightContainer.Margin = new Padding(1, 1, 0, 0);
            cboFreightContainer.Name = "cboFreightContainer";
            cboFreightContainer.Size = new Size(235, 21);
            cboFreightContainer.TabIndex = 385;
            // 
            // txbIdDriver
            // 
            txbIdDriver.Enabled = false;
            txbIdDriver.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdDriver.Location = new Point(83, 198);
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
            cboDriver.Location = new Point(121, 198);
            cboDriver.Margin = new Padding(1, 1, 0, 0);
            cboDriver.Name = "cboDriver";
            cboDriver.Size = new Size(235, 21);
            cboDriver.TabIndex = 383;
            // 
            // btnTransportLineSearch
            // 
            btnTransportLineSearch.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnTransportLineSearch.BackgroundImageLayout = ImageLayout.Stretch;
            btnTransportLineSearch.Font = new Font("Microsoft Sans Serif", 9F);
            btnTransportLineSearch.Location = new Point(356, 175);
            btnTransportLineSearch.Margin = new Padding(1, 1, 0, 0);
            btnTransportLineSearch.Name = "btnTransportLineSearch";
            btnTransportLineSearch.Size = new Size(23, 23);
            btnTransportLineSearch.TabIndex = 381;
            btnTransportLineSearch.UseVisualStyleBackColor = true;
            // 
            // txbIdTransportLine
            // 
            txbIdTransportLine.Enabled = false;
            txbIdTransportLine.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdTransportLine.Location = new Point(83, 176);
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
            cboTransportLine.Location = new Point(121, 176);
            cboTransportLine.Margin = new Padding(1, 1, 0, 0);
            cboTransportLine.Name = "cboTransportLine";
            cboTransportLine.Size = new Size(235, 21);
            cboTransportLine.TabIndex = 380;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 9F);
            label5.Location = new Point(50, 223);
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
            label8.Location = new Point(39, 200);
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
            lblLinea.Location = new Point(44, 179);
            lblLinea.Margin = new Padding(1, 1, 0, 0);
            lblLinea.Name = "lblLinea";
            lblLinea.Size = new Size(41, 15);
            lblLinea.TabIndex = 379;
            lblLinea.Text = "Línea:";
            lblLinea.TextAlign = ContentAlignment.TopRight;
            // 
            // dtpDate
            // 
            dtpDate.Font = new Font("Microsoft Sans Serif", 9F);
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.Location = new Point(312, 37);
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
            label17.Location = new Point(269, 41);
            label17.Name = "label17";
            label17.Size = new Size(44, 15);
            label17.TabIndex = 399;
            label17.Text = "Fecha:";
            // 
            // txbInvoice
            // 
            txbInvoice.Font = new Font("Microsoft Sans Serif", 9F);
            txbInvoice.Location = new Point(161, 37);
            txbInvoice.Margin = new Padding(1, 1, 0, 0);
            txbInvoice.MaxLength = 20;
            txbInvoice.Name = "txbInvoice";
            txbInvoice.Size = new Size(102, 21);
            txbInvoice.TabIndex = 401;
            txbInvoice.TextAlign = HorizontalAlignment.Center;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft Sans Serif", 9F);
            label11.Location = new Point(125, 41);
            label11.Margin = new Padding(1, 1, 0, 0);
            label11.Name = "label11";
            label11.Size = new Size(37, 15);
            label11.TabIndex = 402;
            label11.Text = "Folio:";
            label11.TextAlign = ContentAlignment.TopRight;
            // 
            // chbCategoryRemoved
            // 
            chbCategoryRemoved.Appearance = Appearance.Button;
            chbCategoryRemoved.AutoSize = true;
            chbCategoryRemoved.Font = new Font("Segoe UI", 7.8F);
            chbCategoryRemoved.ForeColor = Color.DarkGray;
            chbCategoryRemoved.Image = Properties.Resources.removedList16;
            chbCategoryRemoved.Location = new Point(786, 127);
            chbCategoryRemoved.Margin = new Padding(1, 1, 0, 0);
            chbCategoryRemoved.Name = "chbCategoryRemoved";
            chbCategoryRemoved.Size = new Size(23, 23);
            chbCategoryRemoved.TabIndex = 407;
            chbCategoryRemoved.Text = "  ";
            chbCategoryRemoved.UseVisualStyleBackColor = true;
            // 
            // btnCategorySearch
            // 
            btnCategorySearch.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnCategorySearch.BackgroundImageLayout = ImageLayout.Stretch;
            btnCategorySearch.Enabled = false;
            btnCategorySearch.Font = new Font("Microsoft Sans Serif", 9F);
            btnCategorySearch.Location = new Point(764, 127);
            btnCategorySearch.Margin = new Padding(1, 1, 0, 0);
            btnCategorySearch.Name = "btnCategorySearch";
            btnCategorySearch.Size = new Size(23, 23);
            btnCategorySearch.TabIndex = 404;
            btnCategorySearch.UseVisualStyleBackColor = true;
            // 
            // txbIdCategory
            // 
            txbIdCategory.Enabled = false;
            txbIdCategory.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdCategory.Location = new Point(491, 128);
            txbIdCategory.Margin = new Padding(1, 1, 0, 0);
            txbIdCategory.Name = "txbIdCategory";
            txbIdCategory.Size = new Size(37, 21);
            txbIdCategory.TabIndex = 406;
            txbIdCategory.TextAlign = HorizontalAlignment.Center;
            // 
            // cboCategory
            // 
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory.Font = new Font("Microsoft Sans Serif", 8.25F);
            cboCategory.FormattingEnabled = true;
            cboCategory.ItemHeight = 13;
            cboCategory.Location = new Point(529, 128);
            cboCategory.Margin = new Padding(1, 1, 0, 0);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(234, 21);
            cboCategory.TabIndex = 403;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 9F);
            label1.Location = new Point(429, 131);
            label1.Margin = new Padding(1, 1, 0, 0);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 405;
            label1.Text = "Categoria:";
            label1.TextAlign = ContentAlignment.TopRight;
            // 
            // chbMaterialRemoved
            // 
            chbMaterialRemoved.Appearance = Appearance.Button;
            chbMaterialRemoved.AutoSize = true;
            chbMaterialRemoved.Font = new Font("Segoe UI", 7.8F);
            chbMaterialRemoved.ForeColor = Color.DarkGray;
            chbMaterialRemoved.Image = Properties.Resources.removedList16;
            chbMaterialRemoved.Location = new Point(786, 149);
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
            btnMaterialSearch.Enabled = false;
            btnMaterialSearch.Font = new Font("Microsoft Sans Serif", 9F);
            btnMaterialSearch.Location = new Point(764, 149);
            btnMaterialSearch.Margin = new Padding(1, 1, 0, 0);
            btnMaterialSearch.Name = "btnMaterialSearch";
            btnMaterialSearch.Size = new Size(23, 23);
            btnMaterialSearch.TabIndex = 409;
            btnMaterialSearch.UseVisualStyleBackColor = true;
            // 
            // txbIdMaterial
            // 
            txbIdMaterial.Enabled = false;
            txbIdMaterial.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdMaterial.Location = new Point(491, 150);
            txbIdMaterial.Margin = new Padding(1, 1, 0, 0);
            txbIdMaterial.Name = "txbIdMaterial";
            txbIdMaterial.Size = new Size(37, 21);
            txbIdMaterial.TabIndex = 411;
            txbIdMaterial.TextAlign = HorizontalAlignment.Center;
            // 
            // cboMaterial
            // 
            cboMaterial.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMaterial.Font = new Font("Microsoft Sans Serif", 8.25F);
            cboMaterial.FormattingEnabled = true;
            cboMaterial.ItemHeight = 13;
            cboMaterial.Location = new Point(529, 150);
            cboMaterial.Margin = new Padding(1, 1, 0, 0);
            cboMaterial.Name = "cboMaterial";
            cboMaterial.Size = new Size(234, 21);
            cboMaterial.TabIndex = 408;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 9F);
            label2.Location = new Point(437, 153);
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
            chbProviderRemoved.Location = new Point(377, 109);
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
            btnProviderSearch.Enabled = false;
            btnProviderSearch.Font = new Font("Microsoft Sans Serif", 9F);
            btnProviderSearch.Location = new Point(355, 109);
            btnProviderSearch.Margin = new Padding(1, 1, 0, 0);
            btnProviderSearch.Name = "btnProviderSearch";
            btnProviderSearch.Size = new Size(23, 23);
            btnProviderSearch.TabIndex = 414;
            btnProviderSearch.UseVisualStyleBackColor = true;
            // 
            // txbIdProvider
            // 
            txbIdProvider.Enabled = false;
            txbIdProvider.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdProvider.Location = new Point(82, 110);
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
            cboProvider.Location = new Point(120, 110);
            cboProvider.Margin = new Padding(1, 1, 0, 0);
            cboProvider.Name = "cboProvider";
            cboProvider.Size = new Size(235, 21);
            cboProvider.TabIndex = 413;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 9F);
            label4.Location = new Point(18, 112);
            label4.Margin = new Padding(1, 1, 0, 0);
            label4.Name = "label4";
            label4.Size = new Size(66, 15);
            label4.TabIndex = 415;
            label4.Text = "Proveedor:";
            label4.TextAlign = ContentAlignment.TopRight;
            // 
            // txbQuant
            // 
            txbQuant.Enabled = false;
            txbQuant.Font = new Font("Microsoft Sans Serif", 9F);
            txbQuant.Location = new Point(490, 172);
            txbQuant.Margin = new Padding(1, 1, 0, 0);
            txbQuant.Name = "txbQuant";
            txbQuant.Size = new Size(97, 21);
            txbQuant.TabIndex = 418;
            txbQuant.TextAlign = HorizontalAlignment.Center;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 9F);
            label7.Location = new Point(433, 175);
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
            txbUnit.Location = new Point(634, 172);
            txbUnit.Margin = new Padding(1, 1, 0, 0);
            txbUnit.Name = "txbUnit";
            txbUnit.Size = new Size(129, 21);
            txbUnit.TabIndex = 420;
            txbUnit.TextAlign = HorizontalAlignment.Center;
            // 
            // txbMXN
            // 
            txbMXN.Enabled = false;
            txbMXN.Font = new Font("Microsoft Sans Serif", 9F);
            txbMXN.Location = new Point(529, 194);
            txbMXN.Margin = new Padding(1, 1, 0, 0);
            txbMXN.Name = "txbMXN";
            txbMXN.Size = new Size(58, 21);
            txbMXN.TabIndex = 421;
            txbMXN.TextAlign = HorizontalAlignment.Center;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 9F);
            label9.Location = new Point(441, 197);
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
            label10.Location = new Point(495, 197);
            label10.Margin = new Padding(1, 1, 0, 0);
            label10.Name = "label10";
            label10.Size = new Size(38, 15);
            label10.TabIndex = 423;
            label10.Text = "MXN:";
            label10.TextAlign = ContentAlignment.TopRight;
            // 
            // txbUSD
            // 
            txbUSD.Enabled = false;
            txbUSD.Font = new Font("Microsoft Sans Serif", 9F);
            txbUSD.Location = new Point(634, 194);
            txbUSD.Margin = new Padding(1, 1, 0, 0);
            txbUSD.Name = "txbUSD";
            txbUSD.Size = new Size(58, 21);
            txbUSD.TabIndex = 424;
            txbUSD.TextAlign = HorizontalAlignment.Center;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 9F);
            label12.Location = new Point(601, 197);
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
            label13.Location = new Point(588, 175);
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
            chbWarehouseRemoved.Location = new Point(376, 65);
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
            btnWarehouseSearch.Enabled = false;
            btnWarehouseSearch.Font = new Font("Microsoft Sans Serif", 9F);
            btnWarehouseSearch.Location = new Point(354, 65);
            btnWarehouseSearch.Margin = new Padding(1, 1, 0, 0);
            btnWarehouseSearch.Name = "btnWarehouseSearch";
            btnWarehouseSearch.Size = new Size(23, 23);
            btnWarehouseSearch.TabIndex = 428;
            btnWarehouseSearch.UseVisualStyleBackColor = true;
            // 
            // txbIdWarehouse
            // 
            txbIdWarehouse.Enabled = false;
            txbIdWarehouse.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdWarehouse.Location = new Point(81, 66);
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
            cboWarehouse.Location = new Point(119, 66);
            cboWarehouse.Margin = new Padding(1, 1, 0, 0);
            cboWarehouse.Name = "cboWarehouse";
            cboWarehouse.Size = new Size(234, 21);
            cboWarehouse.TabIndex = 427;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Microsoft Sans Serif", 9F);
            label14.Location = new Point(24, 69);
            label14.Margin = new Padding(1, 1, 0, 0);
            label14.Name = "label14";
            label14.Size = new Size(58, 15);
            label14.TabIndex = 429;
            label14.Text = "Almacén:";
            label14.TextAlign = ContentAlignment.TopRight;
            // 
            // txbReceiver
            // 
            txbReceiver.Font = new Font("Microsoft Sans Serif", 9F);
            txbReceiver.Location = new Point(81, 88);
            txbReceiver.Margin = new Padding(1, 1, 0, 0);
            txbReceiver.MaxLength = 20;
            txbReceiver.Name = "txbReceiver";
            txbReceiver.Size = new Size(147, 21);
            txbReceiver.TabIndex = 432;
            txbReceiver.TextAlign = HorizontalAlignment.Center;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Microsoft Sans Serif", 9F);
            label15.Location = new Point(30, 91);
            label15.Margin = new Padding(1, 1, 0, 0);
            label15.Name = "label15";
            label15.Size = new Size(52, 15);
            label15.TabIndex = 433;
            label15.Text = "Recibió:";
            label15.TextAlign = ContentAlignment.TopRight;
            // 
            // picMaterialImage
            // 
            picMaterialImage.Location = new Point(490, -8);
            picMaterialImage.Name = "picMaterialImage";
            picMaterialImage.Size = new Size(132, 132);
            picMaterialImage.TabIndex = 440;
            picMaterialImage.TabStop = false;
            // 
            // dgvMaterialList
            // 
            dgvMaterialList.AllowUserToAddRows = false;
            dgvMaterialList.AllowUserToDeleteRows = false;
            dgvMaterialList.AllowUserToOrderColumns = true;
            dgvMaterialList.AllowUserToResizeRows = false;
            dgvMaterialList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMaterialList.BackgroundColor = SystemColors.ControlLightLight;
            dgvMaterialList.BorderStyle = BorderStyle.Fixed3D;
            dgvMaterialList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvMaterialList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvMaterialList.Columns.AddRange(new DataGridViewColumn[] { Categoría, Código, Cantidad, Unidad, Concepto, Precio_USD, Precio_MXN, Proveedor, Distribuidor });
            dgvMaterialList.EnableHeadersVisualStyles = false;
            dgvMaterialList.ImeMode = ImeMode.NoControl;
            dgvMaterialList.Location = new Point(11, 244);
            dgvMaterialList.MultiSelect = false;
            dgvMaterialList.Name = "dgvMaterialList";
            dgvMaterialList.ReadOnly = true;
            dgvMaterialList.RightToLeft = RightToLeft.No;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvMaterialList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvMaterialList.RowHeadersVisible = false;
            dgvMaterialList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMaterialList.Size = new Size(817, 159);
            dgvMaterialList.TabIndex = 441;
            // 
            // Categoría
            // 
            Categoría.HeaderText = "Categoría";
            Categoría.Name = "Categoría";
            Categoría.ReadOnly = true;
            // 
            // Código
            // 
            Código.HeaderText = "Código";
            Código.Name = "Código";
            Código.ReadOnly = true;
            Código.Width = 50;
            // 
            // Cantidad
            // 
            Cantidad.HeaderText = "Cantidad";
            Cantidad.Name = "Cantidad";
            Cantidad.ReadOnly = true;
            Cantidad.Width = 50;
            // 
            // Unidad
            // 
            Unidad.HeaderText = "Unidad";
            Unidad.Name = "Unidad";
            Unidad.ReadOnly = true;
            Unidad.Width = 50;
            // 
            // Concepto
            // 
            Concepto.HeaderText = "Concepto";
            Concepto.Name = "Concepto";
            Concepto.ReadOnly = true;
            // 
            // Precio_USD
            // 
            Precio_USD.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Precio_USD.HeaderText = "$USD";
            Precio_USD.Name = "Precio_USD";
            Precio_USD.ReadOnly = true;
            Precio_USD.Width = 50;
            // 
            // Precio_MXN
            // 
            Precio_MXN.HeaderText = "$MXN";
            Precio_MXN.Name = "Precio_MXN";
            Precio_MXN.ReadOnly = true;
            Precio_MXN.Width = 50;
            // 
            // Proveedor
            // 
            Proveedor.HeaderText = "Proveedor";
            Proveedor.Name = "Proveedor";
            Proveedor.ReadOnly = true;
            // 
            // Distribuidor
            // 
            Distribuidor.HeaderText = "Distribuidor";
            Distribuidor.Name = "Distribuidor";
            Distribuidor.ReadOnly = true;
            // 
            // btnAddMaterial
            // 
            btnAddMaterial.BackColor = Color.GreenYellow;
            btnAddMaterial.BackgroundImageLayout = ImageLayout.Stretch;
            btnAddMaterial.Enabled = false;
            btnAddMaterial.Font = new Font("Microsoft Sans Serif", 9F);
            btnAddMaterial.Location = new Point(481, 218);
            btnAddMaterial.Margin = new Padding(1, 1, 0, 0);
            btnAddMaterial.Name = "btnAddMaterial";
            btnAddMaterial.Size = new Size(69, 23);
            btnAddMaterial.TabIndex = 442;
            btnAddMaterial.Text = "Agregar";
            btnAddMaterial.UseVisualStyleBackColor = false;
            // 
            // btnModifyMaterial
            // 
            btnModifyMaterial.BackColor = Color.FromArgb(255, 255, 128);
            btnModifyMaterial.BackgroundImageLayout = ImageLayout.Stretch;
            btnModifyMaterial.Enabled = false;
            btnModifyMaterial.Font = new Font("Microsoft Sans Serif", 9F);
            btnModifyMaterial.Location = new Point(551, 218);
            btnModifyMaterial.Margin = new Padding(1, 1, 0, 0);
            btnModifyMaterial.Name = "btnModifyMaterial";
            btnModifyMaterial.Size = new Size(69, 23);
            btnModifyMaterial.TabIndex = 443;
            btnModifyMaterial.Text = "Modificar";
            btnModifyMaterial.UseVisualStyleBackColor = false;
            // 
            // btnRemoveMaterial
            // 
            btnRemoveMaterial.BackColor = Color.Salmon;
            btnRemoveMaterial.BackgroundImageLayout = ImageLayout.Stretch;
            btnRemoveMaterial.Enabled = false;
            btnRemoveMaterial.Font = new Font("Microsoft Sans Serif", 9F);
            btnRemoveMaterial.Location = new Point(621, 218);
            btnRemoveMaterial.Margin = new Padding(1, 1, 0, 0);
            btnRemoveMaterial.Name = "btnRemoveMaterial";
            btnRemoveMaterial.Size = new Size(69, 23);
            btnRemoveMaterial.TabIndex = 444;
            btnRemoveMaterial.Text = "Eliminar";
            btnRemoveMaterial.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.ControlLightLight;
            btnSave.BackgroundImageLayout = ImageLayout.Stretch;
            btnSave.Enabled = false;
            btnSave.Font = new Font("Microsoft Sans Serif", 9F);
            btnSave.Location = new Point(10, 407);
            btnSave.Margin = new Padding(1, 1, 0, 0);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(69, 23);
            btnSave.TabIndex = 446;
            btnSave.Text = "Guardar";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = SystemColors.ControlLightLight;
            btnCancel.BackgroundImageLayout = ImageLayout.Stretch;
            btnCancel.Enabled = false;
            btnCancel.Font = new Font("Microsoft Sans Serif", 9F);
            btnCancel.Location = new Point(80, 407);
            btnCancel.Margin = new Padding(1, 1, 0, 0);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(69, 23);
            btnCancel.TabIndex = 447;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnFreightContainerAdd
            // 
            btnFreightContainerAdd.BackgroundImageLayout = ImageLayout.Stretch;
            btnFreightContainerAdd.Font = new Font("Microsoft Sans Serif", 9F);
            btnFreightContainerAdd.Image = Properties.Resources.AddRowIcon16;
            btnFreightContainerAdd.Location = new Point(400, 219);
            btnFreightContainerAdd.Margin = new Padding(1, 1, 0, 0);
            btnFreightContainerAdd.Name = "btnFreightContainerAdd";
            btnFreightContainerAdd.Size = new Size(24, 23);
            btnFreightContainerAdd.TabIndex = 450;
            btnFreightContainerAdd.UseVisualStyleBackColor = true;
            // 
            // btnDriverAdd
            // 
            btnDriverAdd.BackgroundImageLayout = ImageLayout.Stretch;
            btnDriverAdd.Font = new Font("Microsoft Sans Serif", 9F);
            btnDriverAdd.Image = Properties.Resources.AddRowIcon16;
            btnDriverAdd.Location = new Point(400, 197);
            btnDriverAdd.Margin = new Padding(1, 1, 0, 0);
            btnDriverAdd.Name = "btnDriverAdd";
            btnDriverAdd.Size = new Size(24, 23);
            btnDriverAdd.TabIndex = 449;
            btnDriverAdd.UseVisualStyleBackColor = true;
            // 
            // btnTransportLineAdd
            // 
            btnTransportLineAdd.BackgroundImageLayout = ImageLayout.Stretch;
            btnTransportLineAdd.Font = new Font("Microsoft Sans Serif", 9F);
            btnTransportLineAdd.Image = Properties.Resources.AddRowIcon16;
            btnTransportLineAdd.Location = new Point(400, 175);
            btnTransportLineAdd.Margin = new Padding(1, 1, 0, 0);
            btnTransportLineAdd.Name = "btnTransportLineAdd";
            btnTransportLineAdd.Size = new Size(24, 23);
            btnTransportLineAdd.TabIndex = 448;
            btnTransportLineAdd.UseVisualStyleBackColor = true;
            // 
            // btnProviderAdd
            // 
            btnProviderAdd.BackgroundImageLayout = ImageLayout.Stretch;
            btnProviderAdd.Enabled = false;
            btnProviderAdd.Font = new Font("Microsoft Sans Serif", 9F);
            btnProviderAdd.Image = Properties.Resources.AddRowIcon16;
            btnProviderAdd.Location = new Point(399, 109);
            btnProviderAdd.Margin = new Padding(1, 1, 0, 0);
            btnProviderAdd.Name = "btnProviderAdd";
            btnProviderAdd.Size = new Size(24, 23);
            btnProviderAdd.TabIndex = 451;
            btnProviderAdd.UseVisualStyleBackColor = true;
            // 
            // btnMaterialAdd
            // 
            btnMaterialAdd.BackgroundImageLayout = ImageLayout.Stretch;
            btnMaterialAdd.Enabled = false;
            btnMaterialAdd.Font = new Font("Microsoft Sans Serif", 9F);
            btnMaterialAdd.Image = Properties.Resources.AddRowIcon16;
            btnMaterialAdd.Location = new Point(808, 149);
            btnMaterialAdd.Margin = new Padding(1, 1, 0, 0);
            btnMaterialAdd.Name = "btnMaterialAdd";
            btnMaterialAdd.Size = new Size(24, 23);
            btnMaterialAdd.TabIndex = 452;
            btnMaterialAdd.UseVisualStyleBackColor = true;
            // 
            // btnMaterialImageAdd
            // 
            btnMaterialImageAdd.BackgroundImageLayout = ImageLayout.Stretch;
            btnMaterialImageAdd.Enabled = false;
            btnMaterialImageAdd.Font = new Font("Microsoft Sans Serif", 9F);
            btnMaterialImageAdd.Image = Properties.Resources.addImageIcon16;
            btnMaterialImageAdd.Location = new Point(626, 102);
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
            chbGrowerRemoved.Location = new Point(378, 153);
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
            btnGrowerSearch.Enabled = false;
            btnGrowerSearch.Font = new Font("Microsoft Sans Serif", 9F);
            btnGrowerSearch.Location = new Point(356, 153);
            btnGrowerSearch.Margin = new Padding(1, 1, 0, 0);
            btnGrowerSearch.Name = "btnGrowerSearch";
            btnGrowerSearch.Size = new Size(23, 23);
            btnGrowerSearch.TabIndex = 455;
            btnGrowerSearch.UseVisualStyleBackColor = true;
            // 
            // txbIdGrower
            // 
            txbIdGrower.Enabled = false;
            txbIdGrower.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdGrower.Location = new Point(83, 154);
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
            cboGrower.Location = new Point(121, 154);
            cboGrower.Margin = new Padding(1, 1, 0, 0);
            cboGrower.Name = "cboGrower";
            cboGrower.Size = new Size(235, 21);
            cboGrower.TabIndex = 454;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 9F);
            label6.Location = new Point(20, 155);
            label6.Margin = new Padding(1, 1, 0, 0);
            label6.Name = "label6";
            label6.Size = new Size(63, 15);
            label6.TabIndex = 456;
            label6.Text = "Productor:";
            label6.TextAlign = ContentAlignment.TopRight;
            // 
            // FrmMaterialRegisterEntry
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(840, 434);
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
            Controls.Add(picMaterialImage);
            Controls.Add(txbReceiver);
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
            Controls.Add(chbCategoryRemoved);
            Controls.Add(btnCategorySearch);
            Controls.Add(txbIdCategory);
            Controls.Add(cboCategory);
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
            Controls.Add(chbRemovedDistributor);
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
            Name = "FrmMaterialRegisterEntry";
            Text = "FrmMaterialRegisterEntry";
            Load += FrmMaterialRegisterEntry_Load;
            ((System.ComponentModel.ISupportInitialize)picMaterialImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMaterialList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Label lblTitle;
        public TextBox txbId;
        private Label lblId;
        public CheckBox chbRemovedDistributor;
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
        public CheckBox chbCategoryRemoved;
        public Button btnCategorySearch;
        public TextBox txbIdCategory;
        public ComboBox cboCategory;
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
        public TextBox txbReceiver;
        private Label label15;
        private PictureBox picMaterialImage;
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
    }
}