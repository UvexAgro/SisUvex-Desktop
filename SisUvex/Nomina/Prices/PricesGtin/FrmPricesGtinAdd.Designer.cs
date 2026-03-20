namespace SisUvex.Nomina.Prices.PricesGtin
{
    partial class FrmPricesGtinAdd
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPricesGtinAdd));
            lblTitle = new Label();
            txbId = new TextBox();
            lblPrice = new Label();
            txbDescription = new TextBox();
            gpbField = new GroupBox();
            txbFieldOver = new TextBox();
            txbFieldNormal = new TextBox();
            label1 = new Label();
            lblFieldNormal = new Label();
            gpbFacility = new GroupBox();
            txbFacilityOver = new TextBox();
            txbFacilityNormal = new TextBox();
            label2 = new Label();
            label3 = new Label();
            dgvPricesLeft = new DataGridView();
            btnAccept = new Button();
            btnCancel = new Button();
            dgvPricesRight = new DataGridView();
            btnAddToRigt = new Button();
            btnQuitRight = new Button();
            label8 = new Label();
            txbLbs = new TextBox();
            label7 = new Label();
            label6 = new Label();
            cboCrop = new ComboBox();
            btnSearch = new Button();
            cboVariety = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            cboContainer = new ComboBox();
            cboDistributor = new ComboBox();
            lblDistribuidor = new Label();
            label9 = new Label();
            cboPresentation = new ComboBox();
            Filtros = new GroupBox();
            cboSize = new ComboBox();
            lblSize = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            panel3 = new Panel();
            panel2 = new Panel();
            gpbField.SuspendLayout();
            gpbFacility.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPricesLeft).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPricesRight).BeginInit();
            Filtros.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial Black", 16F);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(333, 31);
            lblTitle.TabIndex = 28;
            lblTitle.Text = "Precios por Gtin y Tamaño";
            // 
            // txbId
            // 
            txbId.Font = new Font("Microsoft Sans Serif", 11.25F);
            txbId.Location = new Point(73, 46);
            txbId.Name = "txbId";
            txbId.ReadOnly = true;
            txbId.Size = new Size(29, 24);
            txbId.TabIndex = 0;
            txbId.TabStop = false;
            txbId.TextAlign = HorizontalAlignment.Center;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Microsoft Sans Serif", 11.25F);
            lblPrice.Location = new Point(12, 49);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(55, 18);
            lblPrice.TabIndex = 30;
            lblPrice.Text = "Precio:";
            // 
            // txbDescription
            // 
            txbDescription.Font = new Font("Microsoft Sans Serif", 11.25F);
            txbDescription.Location = new Point(108, 46);
            txbDescription.MaxLength = 25;
            txbDescription.Name = "txbDescription";
            txbDescription.ReadOnly = true;
            txbDescription.Size = new Size(622, 24);
            txbDescription.TabIndex = 1;
            txbDescription.TabStop = false;
            // 
            // gpbField
            // 
            gpbField.Controls.Add(txbFieldOver);
            gpbField.Controls.Add(txbFieldNormal);
            gpbField.Controls.Add(label1);
            gpbField.Controls.Add(lblFieldNormal);
            gpbField.Font = new Font("Microsoft Sans Serif", 11.25F);
            gpbField.Location = new Point(12, 76);
            gpbField.Name = "gpbField";
            gpbField.Size = new Size(356, 55);
            gpbField.TabIndex = 33;
            gpbField.TabStop = false;
            gpbField.Text = "Precios en campo";
            // 
            // txbFieldOver
            // 
            txbFieldOver.Font = new Font("Microsoft Sans Serif", 11.25F);
            txbFieldOver.Location = new Point(286, 19);
            txbFieldOver.MaxLength = 25;
            txbFieldOver.Name = "txbFieldOver";
            txbFieldOver.ReadOnly = true;
            txbFieldOver.Size = new Size(61, 24);
            txbFieldOver.TabIndex = 3;
            txbFieldOver.TabStop = false;
            // 
            // txbFieldNormal
            // 
            txbFieldNormal.Font = new Font("Microsoft Sans Serif", 11.25F);
            txbFieldNormal.Location = new Point(118, 19);
            txbFieldNormal.MaxLength = 25;
            txbFieldNormal.Name = "txbFieldNormal";
            txbFieldNormal.ReadOnly = true;
            txbFieldNormal.Size = new Size(61, 24);
            txbFieldNormal.TabIndex = 2;
            txbFieldNormal.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(185, 20);
            label1.Name = "label1";
            label1.Size = new Size(104, 21);
            label1.TabIndex = 27;
            label1.Text = "Horario extra:";
            // 
            // lblFieldNormal
            // 
            lblFieldNormal.AutoSize = true;
            lblFieldNormal.Font = new Font("Segoe UI", 12F);
            lblFieldNormal.Location = new Point(2, 20);
            lblFieldNormal.Name = "lblFieldNormal";
            lblFieldNormal.Size = new Size(120, 21);
            lblFieldNormal.TabIndex = 25;
            lblFieldNormal.Text = "Horario normal:";
            // 
            // gpbFacility
            // 
            gpbFacility.Controls.Add(txbFacilityOver);
            gpbFacility.Controls.Add(txbFacilityNormal);
            gpbFacility.Controls.Add(label2);
            gpbFacility.Controls.Add(label3);
            gpbFacility.Font = new Font("Microsoft Sans Serif", 11.25F);
            gpbFacility.Location = new Point(374, 76);
            gpbFacility.Name = "gpbFacility";
            gpbFacility.Size = new Size(356, 55);
            gpbFacility.TabIndex = 36;
            gpbFacility.TabStop = false;
            gpbFacility.Text = "Precios en empaque";
            // 
            // txbFacilityOver
            // 
            txbFacilityOver.Font = new Font("Microsoft Sans Serif", 11.25F);
            txbFacilityOver.Location = new Point(286, 19);
            txbFacilityOver.MaxLength = 25;
            txbFacilityOver.Name = "txbFacilityOver";
            txbFacilityOver.ReadOnly = true;
            txbFacilityOver.Size = new Size(61, 24);
            txbFacilityOver.TabIndex = 5;
            txbFacilityOver.TabStop = false;
            // 
            // txbFacilityNormal
            // 
            txbFacilityNormal.Font = new Font("Microsoft Sans Serif", 11.25F);
            txbFacilityNormal.Location = new Point(118, 19);
            txbFacilityNormal.MaxLength = 25;
            txbFacilityNormal.Name = "txbFacilityNormal";
            txbFacilityNormal.ReadOnly = true;
            txbFacilityNormal.Size = new Size(61, 24);
            txbFacilityNormal.TabIndex = 4;
            txbFacilityNormal.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(185, 20);
            label2.Name = "label2";
            label2.Size = new Size(104, 21);
            label2.TabIndex = 27;
            label2.Text = "Horario extra:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(2, 20);
            label3.Name = "label3";
            label3.Size = new Size(120, 21);
            label3.TabIndex = 25;
            label3.Text = "Horario normal:";
            // 
            // dgvPricesLeft
            // 
            dgvPricesLeft.AllowUserToAddRows = false;
            dgvPricesLeft.AllowUserToDeleteRows = false;
            dgvPricesLeft.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
            dgvPricesLeft.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvPricesLeft.BackgroundColor = SystemColors.ControlLightLight;
            dgvPricesLeft.BorderStyle = BorderStyle.Fixed3D;
            dgvPricesLeft.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvPricesLeft.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvPricesLeft.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvPricesLeft.Dock = DockStyle.Fill;
            dgvPricesLeft.EnableHeadersVisualStyles = false;
            dgvPricesLeft.ImeMode = ImeMode.NoControl;
            dgvPricesLeft.Location = new Point(0, 0);
            dgvPricesLeft.Name = "dgvPricesLeft";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvPricesLeft.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvPricesLeft.RowHeadersVisible = false;
            dgvPricesLeft.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvPricesLeft.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPricesLeft.Size = new Size(311, 399);
            dgvPricesLeft.TabIndex = 0;
            // 
            // btnAccept
            // 
            btnAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAccept.Location = new Point(12, 644);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(75, 29);
            btnAccept.TabIndex = 0;
            btnAccept.Text = "Aceptar";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCancel.Location = new Point(93, 644);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 29);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // dgvPricesRight
            // 
            dgvPricesRight.AllowUserToAddRows = false;
            dgvPricesRight.AllowUserToDeleteRows = false;
            dgvPricesRight.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
            dgvPricesRight.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvPricesRight.BackgroundColor = SystemColors.ControlLightLight;
            dgvPricesRight.BorderStyle = BorderStyle.Fixed3D;
            dgvPricesRight.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvPricesRight.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvPricesRight.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvPricesRight.Dock = DockStyle.Fill;
            dgvPricesRight.EnableHeadersVisualStyles = false;
            dgvPricesRight.ImeMode = ImeMode.NoControl;
            dgvPricesRight.Location = new Point(0, 0);
            dgvPricesRight.Name = "dgvPricesRight";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvPricesRight.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvPricesRight.RowHeadersVisible = false;
            dgvPricesRight.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvPricesRight.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPricesRight.Size = new Size(312, 399);
            dgvPricesRight.TabIndex = 0;
            // 
            // btnAddToRigt
            // 
            btnAddToRigt.Anchor = AnchorStyles.Top;
            btnAddToRigt.Location = new Point(0, 115);
            btnAddToRigt.Name = "btnAddToRigt";
            btnAddToRigt.Size = new Size(75, 41);
            btnAddToRigt.TabIndex = 1;
            btnAddToRigt.Text = "Agregar\r\n--->";
            btnAddToRigt.UseVisualStyleBackColor = true;
            btnAddToRigt.Click += btnAddToRigt_Click;
            // 
            // btnQuitRight
            // 
            btnQuitRight.Anchor = AnchorStyles.Top;
            btnQuitRight.Location = new Point(0, 201);
            btnQuitRight.Name = "btnQuitRight";
            btnQuitRight.Size = new Size(75, 41);
            btnQuitRight.TabIndex = 2;
            btnQuitRight.Text = "Quitar\r\n<---";
            btnQuitRight.UseVisualStyleBackColor = true;
            btnQuitRight.Click += btnQuitRight_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 6.75F);
            label8.Location = new Point(466, 45);
            label8.Name = "label8";
            label8.Size = new Size(28, 12);
            label8.TabIndex = 75;
            label8.Text = "Libras";
            // 
            // txbLbs
            // 
            txbLbs.Location = new Point(466, 57);
            txbLbs.MaxLength = 6;
            txbLbs.Name = "txbLbs";
            txbLbs.Size = new Size(86, 23);
            txbLbs.TabIndex = 5;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 6.75F);
            label7.Location = new Point(642, 45);
            label7.Name = "label7";
            label7.Size = new Size(27, 12);
            label7.TabIndex = 73;
            label7.Text = "Filtrar";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 6.75F);
            label6.Location = new Point(48, 10);
            label6.Name = "label6";
            label6.Size = new Size(32, 12);
            label6.TabIndex = 72;
            label6.Text = "Cultivo";
            // 
            // cboCrop
            // 
            cboCrop.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCrop.DropDownWidth = 400;
            cboCrop.FormattingEnabled = true;
            cboCrop.Location = new Point(48, 22);
            cboCrop.Name = "cboCrop";
            cboCrop.Size = new Size(203, 23);
            cboCrop.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnSearch.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearch.Location = new Point(646, 57);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(23, 23);
            btnSearch.TabIndex = 6;
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // cboVariety
            // 
            cboVariety.DropDownStyle = ComboBoxStyle.DropDownList;
            cboVariety.DropDownWidth = 400;
            cboVariety.FormattingEnabled = true;
            cboVariety.Location = new Point(48, 57);
            cboVariety.Name = "cboVariety";
            cboVariety.Size = new Size(203, 23);
            cboVariety.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 6.75F);
            label4.Location = new Point(48, 45);
            label4.Name = "label4";
            label4.Size = new Size(40, 12);
            label4.TabIndex = 69;
            label4.Text = "Variedad";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 6.75F);
            label5.Location = new Point(257, 10);
            label5.Name = "label5";
            label5.Size = new Size(52, 12);
            label5.TabIndex = 70;
            label5.Text = "Contenedor";
            // 
            // cboContainer
            // 
            cboContainer.DropDownStyle = ComboBoxStyle.DropDownList;
            cboContainer.DropDownWidth = 400;
            cboContainer.FormattingEnabled = true;
            cboContainer.Location = new Point(257, 22);
            cboContainer.Name = "cboContainer";
            cboContainer.Size = new Size(203, 23);
            cboContainer.TabIndex = 1;
            // 
            // cboDistributor
            // 
            cboDistributor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDistributor.DropDownWidth = 400;
            cboDistributor.FormattingEnabled = true;
            cboDistributor.Location = new Point(466, 22);
            cboDistributor.Name = "cboDistributor";
            cboDistributor.Size = new Size(203, 23);
            cboDistributor.TabIndex = 2;
            // 
            // lblDistribuidor
            // 
            lblDistribuidor.AutoSize = true;
            lblDistribuidor.Font = new Font("Segoe UI", 6.75F);
            lblDistribuidor.Location = new Point(466, 10);
            lblDistribuidor.Name = "lblDistribuidor";
            lblDistribuidor.Size = new Size(50, 12);
            lblDistribuidor.TabIndex = 67;
            lblDistribuidor.Text = "Distribuidor";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 6.75F);
            label9.Location = new Point(257, 45);
            label9.Name = "label9";
            label9.Size = new Size(56, 12);
            label9.TabIndex = 68;
            label9.Text = "Presentación";
            // 
            // cboPresentation
            // 
            cboPresentation.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPresentation.DropDownWidth = 400;
            cboPresentation.FormattingEnabled = true;
            cboPresentation.Location = new Point(257, 57);
            cboPresentation.Name = "cboPresentation";
            cboPresentation.Size = new Size(203, 23);
            cboPresentation.TabIndex = 4;
            // 
            // Filtros
            // 
            Filtros.Controls.Add(cboCrop);
            Filtros.Controls.Add(label8);
            Filtros.Controls.Add(cboPresentation);
            Filtros.Controls.Add(txbLbs);
            Filtros.Controls.Add(label9);
            Filtros.Controls.Add(label7);
            Filtros.Controls.Add(lblDistribuidor);
            Filtros.Controls.Add(label6);
            Filtros.Controls.Add(cboDistributor);
            Filtros.Controls.Add(cboContainer);
            Filtros.Controls.Add(btnSearch);
            Filtros.Controls.Add(label5);
            Filtros.Controls.Add(cboVariety);
            Filtros.Controls.Add(label4);
            Filtros.Location = new Point(14, 137);
            Filtros.Name = "Filtros";
            Filtros.Size = new Size(716, 90);
            Filtros.TabIndex = 76;
            Filtros.TabStop = false;
            Filtros.Text = "Filtros";
            // 
            // cboSize
            // 
            cboSize.Anchor = AnchorStyles.Top;
            cboSize.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSize.DropDownWidth = 400;
            cboSize.FormattingEnabled = true;
            cboSize.Location = new Point(0, 86);
            cboSize.Name = "cboSize";
            cboSize.Size = new Size(75, 23);
            cboSize.TabIndex = 0;
            // 
            // lblSize
            // 
            lblSize.Anchor = AnchorStyles.Top;
            lblSize.AutoSize = true;
            lblSize.Font = new Font("Segoe UI", 12F);
            lblSize.Location = new Point(6, 66);
            lblSize.Name = "lblSize";
            lblSize.Size = new Size(64, 21);
            lblSize.TabIndex = 28;
            lblSize.Text = "Tamaño";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 81F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(panel1, 1, 0);
            tableLayoutPanel1.Controls.Add(panel3, 0, 0);
            tableLayoutPanel1.Controls.Add(panel2, 2, 0);
            tableLayoutPanel1.Location = new Point(14, 233);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(716, 405);
            tableLayoutPanel1.TabIndex = 80;
            // 
            // panel1
            // 
            panel1.Controls.Add(cboSize);
            panel1.Controls.Add(btnQuitRight);
            panel1.Controls.Add(btnAddToRigt);
            panel1.Controls.Add(lblSize);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(320, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(75, 399);
            panel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(dgvPricesLeft);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(311, 399);
            panel3.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(dgvPricesRight);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(401, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(312, 399);
            panel2.TabIndex = 1;
            // 
            // FrmPricesGtinAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(741, 685);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(Filtros);
            Controls.Add(btnAccept);
            Controls.Add(btnCancel);
            Controls.Add(gpbFacility);
            Controls.Add(gpbField);
            Controls.Add(txbDescription);
            Controls.Add(txbId);
            Controls.Add(lblPrice);
            Controls.Add(lblTitle);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmPricesGtinAdd";
            Text = "Precios por Gtin y Tamaño";
            Load += FrmPricesGtinAdd_Load;
            gpbField.ResumeLayout(false);
            gpbField.PerformLayout();
            gpbFacility.ResumeLayout(false);
            gpbFacility.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPricesLeft).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPricesRight).EndInit();
            Filtros.ResumeLayout(false);
            Filtros.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        public Label lblTitle;
        public TextBox txbId;
        private Label lblPrice;
        public TextBox txbDescription;
        private GroupBox gpbField;
        private Label label1;
        private Label lblFieldNormal;
        public TextBox txbFieldOver;
        public TextBox txbFieldNormal;
        private GroupBox gpbFacility;
        public TextBox txbFacilityOver;
        public TextBox txbFacilityNormal;
        private Label label2;
        private Label label3;
        public DataGridView dgvPricesLeft;
        private Button btnAccept;
        private Button btnCancel;
        public DataGridView dgvPricesRight;
        private Button btnAddToRigt;
        private Button btnQuitRight;
        private Label label8;
        public TextBox txbLbs;
        private Label label7;
        private Label label6;
        public ComboBox cboCrop;
        private Button btnSearch;
        public ComboBox cboVariety;
        private Label label4;
        private Label label5;
        public ComboBox cboContainer;
        public ComboBox cboDistributor;
        private Label lblDistribuidor;
        private Label label9;
        public ComboBox cboPresentation;
        private GroupBox Filtros;
        public ComboBox cboSize;
        private Label lblSize;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Panel panel3;
        private Panel panel2;
    }
}