namespace SisUvex.Archivo.Etiquetas.PrintLabels
{
    partial class FrmPrintManifestPallets
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrintManifestPallets));
            btnPrintPallets = new Button();
            txbIdManifest = new TextBox();
            lblTitle = new Label();
            lblDescription = new Label();
            cboNumPallet = new ComboBox();
            dgvPallets = new DataGridView();
            btnPrint = new Button();
            cboPrinters = new ComboBox();
            txbIdPallet = new TextBox();
            txbIdStow = new TextBox();
            btnPalletAdd = new Button();
            btnStowAdd = new Button();
            btnManifestAdd = new Button();
            btnClear = new Button();
            lblPallet = new Label();
            lblStow = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvPallets).BeginInit();
            SuspendLayout();
            // 
            // btnPrintPallets
            // 
            btnPrintPallets.Font = new Font("Microsoft Sans Serif", 12F);
            btnPrintPallets.Image = Properties.Resources.BuscarLupa1;
            btnPrintPallets.Location = new Point(376, 55);
            btnPrintPallets.Name = "btnPrintPallets";
            btnPrintPallets.Size = new Size(31, 31);
            btnPrintPallets.TabIndex = 0;
            btnPrintPallets.UseVisualStyleBackColor = true;
            btnPrintPallets.Click += btnManifestAdd_Click;
            // 
            // txbIdManifest
            // 
            txbIdManifest.Font = new Font("Microsoft Sans Serif", 15F);
            txbIdManifest.Location = new Point(94, 55);
            txbIdManifest.MaxLength = 5;
            txbIdManifest.Name = "txbIdManifest";
            txbIdManifest.Size = new Size(92, 30);
            txbIdManifest.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial Black", 16F);
            lblTitle.Location = new Point(7, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(377, 31);
            lblTitle.TabIndex = 29;
            lblTitle.Text = "Imprimir pallets de manifiesto";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Microsoft Sans Serif", 12F);
            lblDescription.Location = new Point(9, 60);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(82, 20);
            lblDescription.TabIndex = 31;
            lblDescription.Text = "Manifiesto";
            // 
            // cboNumPallet
            // 
            cboNumPallet.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNumPallet.Font = new Font("Segoe UI", 12F);
            cboNumPallet.FormattingEnabled = true;
            cboNumPallet.Items.AddRange(new object[] { "1 Pallet por estiba", "Todos los pallets" });
            cboNumPallet.Location = new Point(189, 56);
            cboNumPallet.Margin = new Padding(0, 3, 3, 3);
            cboNumPallet.Name = "cboNumPallet";
            cboNumPallet.Size = new Size(185, 29);
            cboNumPallet.TabIndex = 49;
            // 
            // dgvPallets
            // 
            dgvPallets.AllowUserToAddRows = false;
            dgvPallets.AllowUserToDeleteRows = false;
            dgvPallets.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPallets.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvPallets.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvPallets.BackgroundColor = SystemColors.ControlLightLight;
            dgvPallets.BorderStyle = BorderStyle.Fixed3D;
            dgvPallets.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvPallets.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvPallets.ColumnHeadersHeight = 58;
            dgvPallets.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvPallets.EnableHeadersVisualStyles = false;
            dgvPallets.ImeMode = ImeMode.NoControl;
            dgvPallets.Location = new Point(12, 125);
            dgvPallets.Name = "dgvPallets";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvPallets.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvPallets.RowHeadersVisible = false;
            dgvPallets.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvPallets.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPallets.Size = new Size(776, 269);
            dgvPallets.TabIndex = 50;
            dgvPallets.CellContentClick += dgvPallets_CellContentClick;
            // 
            // btnPrint
            // 
            btnPrint.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnPrint.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPrint.Image = Properties.Resources.imprimirIcon32;
            btnPrint.ImageAlign = ContentAlignment.MiddleLeft;
            btnPrint.Location = new Point(11, 401);
            btnPrint.Name = "btnPrint";
            btnPrint.Padding = new Padding(5, 0, 0, 0);
            btnPrint.Size = new Size(119, 38);
            btnPrint.TabIndex = 51;
            btnPrint.Text = "Imprimir";
            btnPrint.TextAlign = ContentAlignment.MiddleRight;
            btnPrint.UseVisualStyleBackColor = true;
            btnPrint.Click += btnPrint_Click;
            // 
            // cboPrinters
            // 
            cboPrinters.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPrinters.Font = new Font("Segoe UI", 15F);
            cboPrinters.FormattingEnabled = true;
            cboPrinters.Items.AddRange(new object[] { "Pallets (4x6)", "Código (2x1)" });
            cboPrinters.Location = new Point(133, 402);
            cboPrinters.Margin = new Padding(0, 3, 3, 3);
            cboPrinters.Name = "cboPrinters";
            cboPrinters.Size = new Size(132, 36);
            cboPrinters.TabIndex = 52;
            // 
            // txbIdPallet
            // 
            txbIdPallet.Font = new Font("Microsoft Sans Serif", 12F);
            txbIdPallet.Location = new Point(420, 55);
            txbIdPallet.MaxLength = 20;
            txbIdPallet.Name = "txbIdPallet";
            txbIdPallet.Size = new Size(80, 26);
            txbIdPallet.TabIndex = 53;
            // 
            // txbIdStow
            // 
            txbIdStow.Font = new Font("Microsoft Sans Serif", 12F);
            txbIdStow.Location = new Point(570, 55);
            txbIdStow.MaxLength = 20;
            txbIdStow.Name = "txbIdStow";
            txbIdStow.Size = new Size(80, 26);
            txbIdStow.TabIndex = 54;
            // 
            // btnPalletAdd
            // 
            btnPalletAdd.Font = new Font("Microsoft Sans Serif", 9F);
            btnPalletAdd.Location = new Point(505, 55);
            btnPalletAdd.Name = "btnPalletAdd";
            btnPalletAdd.Size = new Size(58, 26);
            btnPalletAdd.TabIndex = 55;
            btnPalletAdd.Text = "Agregar";
            btnPalletAdd.UseVisualStyleBackColor = true;
            btnPalletAdd.Click += btnPalletAdd_Click;
            // 
            // btnStowAdd
            // 
            btnStowAdd.Font = new Font("Microsoft Sans Serif", 9F);
            btnStowAdd.Location = new Point(655, 55);
            btnStowAdd.Name = "btnStowAdd";
            btnStowAdd.Size = new Size(58, 26);
            btnStowAdd.TabIndex = 56;
            btnStowAdd.Text = "Agregar";
            btnStowAdd.UseVisualStyleBackColor = true;
            btnStowAdd.Click += btnStowAdd_Click;
            // 
            // btnManifestAdd
            // 
            btnManifestAdd.Font = new Font("Microsoft Sans Serif", 9F);
            btnManifestAdd.Location = new Point(316, 90);
            btnManifestAdd.Name = "btnManifestAdd";
            btnManifestAdd.Size = new Size(58, 26);
            btnManifestAdd.TabIndex = 57;
            btnManifestAdd.Text = "Agregar";
            btnManifestAdd.UseVisualStyleBackColor = true;
            btnManifestAdd.Click += btnManifestAdd_Click;
            // 
            // btnClear
            // 
            btnClear.Font = new Font("Microsoft Sans Serif", 9F);
            btnClear.Location = new Point(478, 90);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(58, 26);
            btnClear.TabIndex = 58;
            btnClear.Text = "Limpiar";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // lblPallet
            // 
            lblPallet.AutoSize = true;
            lblPallet.Font = new Font("Microsoft Sans Serif", 10F);
            lblPallet.Location = new Point(420, 35);
            lblPallet.Name = "lblPallet";
            lblPallet.Size = new Size(43, 17);
            lblPallet.TabIndex = 59;
            lblPallet.Text = "Pallet";
            // 
            // lblStow
            // 
            lblStow.AutoSize = true;
            lblStow.Font = new Font("Microsoft Sans Serif", 10F);
            lblStow.Location = new Point(570, 35);
            lblStow.Name = "lblStow";
            lblStow.Size = new Size(38, 17);
            lblStow.TabIndex = 60;
            lblStow.Text = "Stow";
            // 
            // FrmPrintManifestPallets
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblStow);
            Controls.Add(lblPallet);
            Controls.Add(btnClear);
            Controls.Add(btnManifestAdd);
            Controls.Add(btnStowAdd);
            Controls.Add(btnPalletAdd);
            Controls.Add(txbIdStow);
            Controls.Add(txbIdPallet);
            Controls.Add(cboPrinters);
            Controls.Add(btnPrint);
            Controls.Add(dgvPallets);
            Controls.Add(cboNumPallet);
            Controls.Add(lblDescription);
            Controls.Add(lblTitle);
            Controls.Add(txbIdManifest);
            Controls.Add(btnPrintPallets);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmPrintManifestPallets";
            Text = "FrmPrintManifestPallets";
            Load += FrmPrintManifestPallets_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPallets).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPrintPallets;
        private TextBox txbIdManifest;
        public Label lblTitle;
        private Label lblDescription;
        public ComboBox cboNumPallet;
        public DataGridView dgvPallets;
        private Button btnPrint;
        public ComboBox cboPrinters;
        private TextBox txbIdPallet;
        private TextBox txbIdStow;
        private Button btnPalletAdd;
        private Button btnStowAdd;
        private Button btnManifestAdd;
        private Button btnClear;
        private Label lblPallet;
        private Label lblStow;
    }
}