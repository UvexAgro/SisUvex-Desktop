namespace SisUvex.Nomina.Prices.PricesGtin
{
    partial class FrmPricesGtinCat
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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPricesGtinCat));
            dgvCatalogPrices = new DataGridView();
            btnModifyGtin = new Button();
            dgvCatalogGtin = new DataGridView();
            splitContainer1 = new SplitContainer();
            btnSeleccionar = new Button();
            label9 = new Label();
            btnModifySize = new Button();
            splitContainer2 = new SplitContainer();
            label1 = new Label();
            btnSearchSize = new Button();
            cboSize = new ComboBox();
            dgvCatalogSize = new DataGridView();
            label2 = new Label();
            btnSearch = new Button();
            cboVariety = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            cboContainer = new ComboBox();
            cboDistributor = new ComboBox();
            lblDistribuidor = new Label();
            label5 = new Label();
            cboPresentation = new ComboBox();
            label6 = new Label();
            cboCrop = new ComboBox();
            label7 = new Label();
            txbLbs = new TextBox();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvCatalogPrices).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCatalogGtin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCatalogSize).BeginInit();
            SuspendLayout();
            // 
            // dgvCatalogPrices
            // 
            dgvCatalogPrices.AllowUserToAddRows = false;
            dgvCatalogPrices.AllowUserToDeleteRows = false;
            dgvCatalogPrices.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCatalogPrices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvCatalogPrices.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvCatalogPrices.BackgroundColor = SystemColors.ControlLightLight;
            dgvCatalogPrices.BorderStyle = BorderStyle.Fixed3D;
            dgvCatalogPrices.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvCatalogPrices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvCatalogPrices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvCatalogPrices.EnableHeadersVisualStyles = false;
            dgvCatalogPrices.ImeMode = ImeMode.NoControl;
            dgvCatalogPrices.Location = new Point(3, 29);
            dgvCatalogPrices.Name = "dgvCatalogPrices";
            dgvCatalogPrices.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvCatalogPrices.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvCatalogPrices.RowHeadersVisible = false;
            dgvCatalogPrices.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvCatalogPrices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCatalogPrices.Size = new Size(448, 570);
            dgvCatalogPrices.TabIndex = 2;
            // 
            // btnModifyGtin
            // 
            btnModifyGtin.Location = new Point(156, 4);
            btnModifyGtin.Name = "btnModifyGtin";
            btnModifyGtin.Size = new Size(98, 23);
            btnModifyGtin.TabIndex = 1;
            btnModifyGtin.Text = "Modificar GTIN";
            btnModifyGtin.UseVisualStyleBackColor = true;
            btnModifyGtin.Click += btnModify_Click;
            // 
            // dgvCatalogGtin
            // 
            dgvCatalogGtin.AllowUserToAddRows = false;
            dgvCatalogGtin.AllowUserToDeleteRows = false;
            dgvCatalogGtin.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCatalogGtin.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvCatalogGtin.BackgroundColor = SystemColors.ControlLightLight;
            dgvCatalogGtin.BorderStyle = BorderStyle.Fixed3D;
            dgvCatalogGtin.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvCatalogGtin.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvCatalogGtin.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvCatalogGtin.EnableHeadersVisualStyles = false;
            dgvCatalogGtin.ImeMode = ImeMode.NoControl;
            dgvCatalogGtin.Location = new Point(3, 29);
            dgvCatalogGtin.Name = "dgvCatalogGtin";
            dgvCatalogGtin.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvCatalogGtin.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvCatalogGtin.RowHeadersVisible = false;
            dgvCatalogGtin.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvCatalogGtin.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCatalogGtin.Size = new Size(712, 260);
            dgvCatalogGtin.TabIndex = 3;
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(12, 86);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dgvCatalogPrices);
            splitContainer1.Panel1.Controls.Add(btnSeleccionar);
            splitContainer1.Panel1.Controls.Add(btnModifyGtin);
            splitContainer1.Panel1.Controls.Add(label9);
            splitContainer1.Panel1.Controls.Add(btnModifySize);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new Size(1176, 602);
            splitContainer1.SplitterDistance = 454;
            splitContainer1.TabIndex = 28;
            // 
            // btnSeleccionar
            // 
            btnSeleccionar.Location = new Point(96, 4);
            btnSeleccionar.Name = "btnSeleccionar";
            btnSeleccionar.Size = new Size(59, 23);
            btnSeleccionar.TabIndex = 0;
            btnSeleccionar.Text = "Mostrar";
            btnSeleccionar.UseVisualStyleBackColor = true;
            btnSeleccionar.Click += btnSeleccionar_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(3, 6);
            label9.Name = "label9";
            label9.Size = new Size(75, 21);
            label9.TabIndex = 30;
            label9.Text = "PRECIOS";
            // 
            // btnModifySize
            // 
            btnModifySize.Location = new Point(255, 4);
            btnModifySize.Name = "btnModifySize";
            btnModifySize.Size = new Size(118, 23);
            btnModifySize.TabIndex = 4;
            btnModifySize.Text = "Modificar tamaños";
            btnModifySize.UseVisualStyleBackColor = true;
            btnModifySize.Click += btnSize_Click;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(dgvCatalogGtin);
            splitContainer2.Panel1.Controls.Add(label1);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(btnSearchSize);
            splitContainer2.Panel2.Controls.Add(cboSize);
            splitContainer2.Panel2.Controls.Add(dgvCatalogSize);
            splitContainer2.Panel2.Controls.Add(label2);
            splitContainer2.Size = new Size(718, 602);
            splitContainer2.SplitterDistance = 292;
            splitContainer2.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 6);
            label1.Name = "label1";
            label1.Size = new Size(48, 21);
            label1.TabIndex = 29;
            label1.Text = "GTIN";
            // 
            // btnSearchSize
            // 
            btnSearchSize.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnSearchSize.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearchSize.Location = new Point(287, 5);
            btnSearchSize.Name = "btnSearchSize";
            btnSearchSize.Size = new Size(23, 23);
            btnSearchSize.TabIndex = 62;
            btnSearchSize.UseVisualStyleBackColor = true;
            btnSearchSize.Click += btnSearchSize_Click;
            // 
            // cboSize
            // 
            cboSize.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSize.DropDownWidth = 400;
            cboSize.FormattingEnabled = true;
            cboSize.Location = new Point(81, 5);
            cboSize.Name = "cboSize";
            cboSize.Size = new Size(203, 23);
            cboSize.TabIndex = 62;
            // 
            // dgvCatalogSize
            // 
            dgvCatalogSize.AllowUserToAddRows = false;
            dgvCatalogSize.AllowUserToDeleteRows = false;
            dgvCatalogSize.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCatalogSize.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvCatalogSize.BackgroundColor = SystemColors.ControlLightLight;
            dgvCatalogSize.BorderStyle = BorderStyle.Fixed3D;
            dgvCatalogSize.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            dataGridViewCellStyle5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvCatalogSize.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvCatalogSize.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvCatalogSize.EnableHeadersVisualStyles = false;
            dgvCatalogSize.ImeMode = ImeMode.NoControl;
            dgvCatalogSize.Location = new Point(3, 29);
            dgvCatalogSize.Name = "dgvCatalogSize";
            dgvCatalogSize.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Control;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dgvCatalogSize.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dgvCatalogSize.RowHeadersVisible = false;
            dgvCatalogSize.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvCatalogSize.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCatalogSize.Size = new Size(712, 274);
            dgvCatalogSize.TabIndex = 30;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(3, 6);
            label2.Name = "label2";
            label2.Size = new Size(80, 21);
            label2.TabIndex = 30;
            label2.Text = "TAMAÑO";
            // 
            // btnSearch
            // 
            btnSearch.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnSearch.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearch.Location = new Point(610, 47);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(23, 23);
            btnSearch.TabIndex = 52;
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // cboVariety
            // 
            cboVariety.DropDownStyle = ComboBoxStyle.DropDownList;
            cboVariety.DropDownWidth = 400;
            cboVariety.FormattingEnabled = true;
            cboVariety.Location = new Point(12, 47);
            cboVariety.Name = "cboVariety";
            cboVariety.Size = new Size(203, 23);
            cboVariety.TabIndex = 50;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 6.75F);
            label3.Location = new Point(12, 35);
            label3.Name = "label3";
            label3.Size = new Size(40, 12);
            label3.TabIndex = 55;
            label3.Text = "Variedad";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 6.75F);
            label4.Location = new Point(221, 0);
            label4.Name = "label4";
            label4.Size = new Size(52, 12);
            label4.TabIndex = 56;
            label4.Text = "Contenedor";
            // 
            // cboContainer
            // 
            cboContainer.DropDownStyle = ComboBoxStyle.DropDownList;
            cboContainer.DropDownWidth = 400;
            cboContainer.FormattingEnabled = true;
            cboContainer.Location = new Point(221, 12);
            cboContainer.Name = "cboContainer";
            cboContainer.Size = new Size(203, 23);
            cboContainer.TabIndex = 49;
            // 
            // cboDistributor
            // 
            cboDistributor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDistributor.DropDownWidth = 400;
            cboDistributor.FormattingEnabled = true;
            cboDistributor.Location = new Point(430, 12);
            cboDistributor.Name = "cboDistributor";
            cboDistributor.Size = new Size(203, 23);
            cboDistributor.TabIndex = 48;
            // 
            // lblDistribuidor
            // 
            lblDistribuidor.AutoSize = true;
            lblDistribuidor.Font = new Font("Segoe UI", 6.75F);
            lblDistribuidor.Location = new Point(430, 0);
            lblDistribuidor.Name = "lblDistribuidor";
            lblDistribuidor.Size = new Size(50, 12);
            lblDistribuidor.TabIndex = 53;
            lblDistribuidor.Text = "Distribuidor";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 6.75F);
            label5.Location = new Point(221, 35);
            label5.Name = "label5";
            label5.Size = new Size(56, 12);
            label5.TabIndex = 54;
            label5.Text = "Presentación";
            // 
            // cboPresentation
            // 
            cboPresentation.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPresentation.DropDownWidth = 400;
            cboPresentation.FormattingEnabled = true;
            cboPresentation.Location = new Point(221, 47);
            cboPresentation.Name = "cboPresentation";
            cboPresentation.Size = new Size(203, 23);
            cboPresentation.TabIndex = 51;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 6.75F);
            label6.Location = new Point(12, 0);
            label6.Name = "label6";
            label6.Size = new Size(32, 12);
            label6.TabIndex = 58;
            label6.Text = "Cultivo";
            // 
            // cboCrop
            // 
            cboCrop.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCrop.DropDownWidth = 400;
            cboCrop.FormattingEnabled = true;
            cboCrop.Location = new Point(12, 12);
            cboCrop.Name = "cboCrop";
            cboCrop.Size = new Size(203, 23);
            cboCrop.TabIndex = 57;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 6.75F);
            label7.Location = new Point(606, 35);
            label7.Name = "label7";
            label7.Size = new Size(27, 12);
            label7.TabIndex = 59;
            label7.Text = "Filtrar";
            // 
            // txbLbs
            // 
            txbLbs.Location = new Point(430, 47);
            txbLbs.MaxLength = 6;
            txbLbs.Name = "txbLbs";
            txbLbs.Size = new Size(86, 23);
            txbLbs.TabIndex = 60;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 6.75F);
            label8.Location = new Point(430, 35);
            label8.Name = "label8";
            label8.Size = new Size(28, 12);
            label8.TabIndex = 61;
            label8.Text = "Libras";
            // 
            // FrmPricesGtinCat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoScrollMinSize = new Size(1200, 700);
            ClientSize = new Size(1184, 661);
            Controls.Add(label8);
            Controls.Add(txbLbs);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(cboCrop);
            Controls.Add(btnSearch);
            Controls.Add(cboVariety);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(cboContainer);
            Controls.Add(cboDistributor);
            Controls.Add(lblDistribuidor);
            Controls.Add(label5);
            Controls.Add(cboPresentation);
            Controls.Add(splitContainer1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmPricesGtinCat";
            Text = "Catálogo precios por GTIN";
            WindowState = FormWindowState.Maximized;
            Load += FrmPricesGtinCat_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCatalogPrices).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCatalogGtin).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel1.PerformLayout();
            splitContainer2.Panel2.ResumeLayout(false);
            splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCatalogSize).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public DataGridView dgvCatalogPrices;
        private Button btnModifyGtin;
        public DataGridView dgvCatalogGtin;
        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private Button btnModifySize;
        private Label label1;
        public DataGridView dgvCatalogSize;
        private Label label2;
        private Button btnSearch;
        public ComboBox cboVariety;
        private Label label3;
        private Label label4;
        public ComboBox cboContainer;
        public ComboBox cboDistributor;
        private Label lblDistribuidor;
        private Label label5;
        public ComboBox cboPresentation;
        private Label label6;
        public ComboBox cboCrop;
        private Label label7;
        private Label label8;
        public TextBox txbLbs;
        private Button btnSeleccionar;
        private Label label9;
        private Button btnSearchSize;
        public ComboBox cboSize;
    }
}