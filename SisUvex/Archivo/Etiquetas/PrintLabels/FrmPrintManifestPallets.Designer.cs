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
            txbIdManifest = new TextBox();
            lblTitle = new Label();
            lblDescription = new Label();
            cboNumPallet = new ComboBox();
            dgvPallets = new DataGridView();
            btnPrint = new Button();
            cboPrinters = new ComboBox();
            txbIdPallet = new TextBox();
            btnPalletAdd = new Button();
            btnManifestAdd = new Button();
            btnClear = new Button();
            lblPallet = new Label();
            chbAjustarColumnas = new CheckBox();
            chbSeleccionarTodo = new CheckBox();
            nudCopiasEtiquetas = new NumericUpDown();
            labelCopias = new Label();
            chbRevesePalletTag = new CheckBox();
            chbFechaOmitidaPallet = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dgvPallets).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCopiasEtiquetas).BeginInit();
            SuspendLayout();
            // 
            // txbIdManifest
            // 
            txbIdManifest.Font = new Font("Microsoft Sans Serif", 15F);
            txbIdManifest.Location = new Point(94, 55);
            txbIdManifest.MaxLength = 5;
            txbIdManifest.Name = "txbIdManifest";
            txbIdManifest.Size = new Size(92, 30);
            txbIdManifest.TabIndex = 1;
            txbIdManifest.KeyDown += txbIdManifest_KeyDown;
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
            dgvPallets.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
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
            dgvPallets.Size = new Size(1289, 596);
            dgvPallets.TabIndex = 50;
            dgvPallets.CellContentClick += dgvPallets_CellContentClick;
            dgvPallets.CellValueChanged += dgvPallets_CellValueChanged;
            dgvPallets.CurrentCellDirtyStateChanged += dgvPallets_CurrentCellDirtyStateChanged;
            // 
            // btnPrint
            // 
            btnPrint.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnPrint.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPrint.Image = Properties.Resources.imprimirIcon32;
            btnPrint.ImageAlign = ContentAlignment.MiddleLeft;
            btnPrint.Location = new Point(11, 733);
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
            cboPrinters.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cboPrinters.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPrinters.Font = new Font("Segoe UI", 15F);
            cboPrinters.FormattingEnabled = true;
            cboPrinters.Items.AddRange(new object[] { "Pallets (Grande 4x6)", "Código (Chica 2x1)" });
            cboPrinters.Location = new Point(133, 735);
            cboPrinters.Margin = new Padding(0, 3, 3, 3);
            cboPrinters.Name = "cboPrinters";
            cboPrinters.Size = new Size(250, 36);
            cboPrinters.TabIndex = 52;
            // 
            // txbIdPallet
            // 
            txbIdPallet.Font = new Font("Microsoft Sans Serif", 12F);
            txbIdPallet.Location = new Point(479, 55);
            txbIdPallet.MaxLength = 5000;
            txbIdPallet.Multiline = true;
            txbIdPallet.Name = "txbIdPallet";
            txbIdPallet.ScrollBars = ScrollBars.Vertical;
            txbIdPallet.Size = new Size(84, 60);
            txbIdPallet.TabIndex = 53;
            txbIdPallet.KeyDown += txbIdPallet_KeyDown;
            txbIdPallet.KeyPress += txbIdPallet_KeyPress;
            // 
            // btnPalletAdd
            // 
            btnPalletAdd.Font = new Font("Microsoft Sans Serif", 9F);
            btnPalletAdd.Location = new Point(569, 55);
            btnPalletAdd.Name = "btnPalletAdd";
            btnPalletAdd.Size = new Size(58, 26);
            btnPalletAdd.TabIndex = 55;
            btnPalletAdd.Text = "Agregar";
            btnPalletAdd.UseVisualStyleBackColor = true;
            btnPalletAdd.Click += btnPalletAdd_Click;
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
            btnClear.Location = new Point(569, 90);
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
            lblPallet.Location = new Point(479, 36);
            lblPallet.Name = "lblPallet";
            lblPallet.Size = new Size(43, 17);
            lblPallet.TabIndex = 59;
            lblPallet.Text = "Pallet";
            // 
            // chbAjustarColumnas
            // 
            chbAjustarColumnas.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            chbAjustarColumnas.Appearance = Appearance.Button;
            chbAjustarColumnas.Location = new Point(12, 94);
            chbAjustarColumnas.Name = "chbAjustarColumnas";
            chbAjustarColumnas.Padding = new Padding(0, 0, 0, 1);
            chbAjustarColumnas.Size = new Size(35, 25);
            chbAjustarColumnas.TabIndex = 61;
            chbAjustarColumnas.Text = ">|<";
            chbAjustarColumnas.TextAlign = ContentAlignment.MiddleRight;
            chbAjustarColumnas.UseVisualStyleBackColor = true;
            chbAjustarColumnas.CheckedChanged += chbAjustarColumnas_CheckedChanged;
            // 
            // chbSeleccionarTodo
            // 
            chbSeleccionarTodo.AutoSize = true;
            chbSeleccionarTodo.Checked = true;
            chbSeleccionarTodo.CheckState = CheckState.Checked;
            chbSeleccionarTodo.Font = new Font("Segoe UI", 9F);
            chbSeleccionarTodo.Location = new Point(53, 98);
            chbSeleccionarTodo.Name = "chbSeleccionarTodo";
            chbSeleccionarTodo.Size = new Size(114, 19);
            chbSeleccionarTodo.TabIndex = 62;
            chbSeleccionarTodo.Text = "Seleccionar todo";
            chbSeleccionarTodo.UseVisualStyleBackColor = true;
            chbSeleccionarTodo.CheckedChanged += chbSeleccionarTodo_CheckedChanged;
            // 
            // nudCopiasEtiquetas
            // 
            nudCopiasEtiquetas.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            nudCopiasEtiquetas.Font = new Font("Segoe UI", 16F);
            nudCopiasEtiquetas.Location = new Point(388, 735);
            nudCopiasEtiquetas.Maximum = new decimal(new int[] { 4, 0, 0, 0 });
            nudCopiasEtiquetas.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCopiasEtiquetas.Name = "nudCopiasEtiquetas";
            nudCopiasEtiquetas.Size = new Size(44, 36);
            nudCopiasEtiquetas.TabIndex = 63;
            nudCopiasEtiquetas.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // labelCopias
            // 
            labelCopias.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelCopias.AutoSize = true;
            labelCopias.Font = new Font("Microsoft Sans Serif", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelCopias.Location = new Point(382, 722);
            labelCopias.Name = "labelCopias";
            labelCopias.Size = new Size(59, 12);
            labelCopias.TabIndex = 64;
            labelCopias.Text = "Copias/pallet";
            // 
            // chbRevesePalletTag
            // 
            chbRevesePalletTag.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            chbRevesePalletTag.AutoSize = true;
            chbRevesePalletTag.Font = new Font("Segoe UI", 9F);
            chbRevesePalletTag.Location = new Point(438, 733);
            chbRevesePalletTag.Name = "chbRevesePalletTag";
            chbRevesePalletTag.Size = new Size(109, 19);
            chbRevesePalletTag.TabIndex = 65;
            chbRevesePalletTag.Text = "Invertir etiqueta";
            chbRevesePalletTag.UseVisualStyleBackColor = true;
            // 
            // chbFechaOmitidaPallet
            // 
            chbFechaOmitidaPallet.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            chbFechaOmitidaPallet.AutoSize = true;
            chbFechaOmitidaPallet.Font = new Font("Segoe UI", 9F);
            chbFechaOmitidaPallet.Location = new Point(438, 756);
            chbFechaOmitidaPallet.Name = "chbFechaOmitidaPallet";
            chbFechaOmitidaPallet.Size = new Size(92, 19);
            chbFechaOmitidaPallet.TabIndex = 66;
            chbFechaOmitidaPallet.Text = "Omitir fecha";
            chbFechaOmitidaPallet.UseVisualStyleBackColor = true;
            // 
            // FrmPrintManifestPallets
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1313, 782);
            Controls.Add(nudCopiasEtiquetas);
            Controls.Add(chbSeleccionarTodo);
            Controls.Add(chbAjustarColumnas);
            Controls.Add(lblPallet);
            Controls.Add(btnClear);
            Controls.Add(btnManifestAdd);
            Controls.Add(btnPalletAdd);
            Controls.Add(txbIdPallet);
            Controls.Add(cboPrinters);
            Controls.Add(btnPrint);
            Controls.Add(dgvPallets);
            Controls.Add(cboNumPallet);
            Controls.Add(lblDescription);
            Controls.Add(lblTitle);
            Controls.Add(txbIdManifest);
            Controls.Add(labelCopias);
            Controls.Add(chbFechaOmitidaPallet);
            Controls.Add(chbRevesePalletTag);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmPrintManifestPallets";
            Text = "Imprimir pallets de manifiesto";
            Load += FrmPrintManifestPallets_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPallets).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCopiasEtiquetas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txbIdManifest;
        public Label lblTitle;
        private Label lblDescription;
        public ComboBox cboNumPallet;
        public DataGridView dgvPallets;
        private Button btnPrint;
        public ComboBox cboPrinters;
        private TextBox txbIdPallet;
        private Button btnPalletAdd;
        private Button btnManifestAdd;
        private Button btnClear;
        private Label lblPallet;
        private CheckBox chbAjustarColumnas;
        private CheckBox chbSeleccionarTodo;
        private NumericUpDown nudCopiasEtiquetas;
        private Label labelCopias;
        private CheckBox chbRevesePalletTag;
        private CheckBox chbFechaOmitidaPallet;
    }
}
