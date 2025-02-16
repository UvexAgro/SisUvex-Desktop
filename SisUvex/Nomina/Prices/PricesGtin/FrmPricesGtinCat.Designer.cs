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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPricesGtinCat));
            dgvCatalogPrices = new DataGridView();
            btnModify = new Button();
            dgvCatalogGtin = new DataGridView();
            btnSeleccionar = new Button();
            splitContainer1 = new SplitContainer();
            ((System.ComponentModel.ISupportInitialize)dgvCatalogPrices).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCatalogGtin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
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
            dgvCatalogPrices.Location = new Point(3, 3);
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
            dgvCatalogPrices.Size = new Size(369, 394);
            dgvCatalogPrices.TabIndex = 2;
            // 
            // btnModify
            // 
            btnModify.Location = new Point(96, 12);
            btnModify.Name = "btnModify";
            btnModify.Size = new Size(75, 23);
            btnModify.TabIndex = 1;
            btnModify.Text = "Modificar";
            btnModify.UseVisualStyleBackColor = true;
            btnModify.Click += btnModify_Click;
            // 
            // dgvCatalogGtin
            // 
            dgvCatalogGtin.AllowUserToAddRows = false;
            dgvCatalogGtin.AllowUserToDeleteRows = false;
            dgvCatalogGtin.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCatalogGtin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
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
            dgvCatalogGtin.Location = new Point(3, 3);
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
            dgvCatalogGtin.Size = new Size(391, 394);
            dgvCatalogGtin.TabIndex = 3;
            // 
            // btnSeleccionar
            // 
            btnSeleccionar.Location = new Point(15, 12);
            btnSeleccionar.Name = "btnSeleccionar";
            btnSeleccionar.Size = new Size(75, 23);
            btnSeleccionar.TabIndex = 0;
            btnSeleccionar.Text = "Seleccionar";
            btnSeleccionar.UseVisualStyleBackColor = true;
            btnSeleccionar.Click += btnSeleccionar_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(12, 38);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dgvCatalogPrices);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dgvCatalogGtin);
            splitContainer1.Size = new Size(776, 400);
            splitContainer1.SplitterDistance = 375;
            splitContainer1.TabIndex = 28;
            // 
            // FrmPricesGtinCat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSeleccionar);
            Controls.Add(btnModify);
            Controls.Add(splitContainer1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmPricesGtinCat";
            Text = "Catálogo precios por GTIN";
            WindowState = FormWindowState.Maximized;
            Load += FrmPricesGtinCat_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCatalogPrices).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCatalogGtin).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        public DataGridView dgvCatalogPrices;
        private Button btnModify;
        public DataGridView dgvCatalogGtin;
        private Button btnSeleccionar;
        private SplitContainer splitContainer1;
    }
}