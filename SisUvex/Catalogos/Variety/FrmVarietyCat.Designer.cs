namespace SisUvex.Catalogos.Variety;

partial class FrmVarietyCat
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVarietyCat));
        btnRemove = new Button();
        dgvCatalog = new DataGridView();
        btnModify = new Button();
        btnAdd = new Button();
        chbRemoved = new CheckBox();
        btnRecover = new Button();
        cboCrop = new ComboBox();
        lblCrop = new Label();
        cboColor = new ComboBox();
        lblColor = new Label();
        ((System.ComponentModel.ISupportInitialize)dgvCatalog).BeginInit();
        SuspendLayout();
        // 
        // btnRemove
        // 
        btnRemove.Location = new Point(255, 50);
        btnRemove.Name = "btnRemove";
        btnRemove.Size = new Size(75, 23);
        btnRemove.TabIndex = 363;
        btnRemove.Text = "Eliminar";
        btnRemove.UseVisualStyleBackColor = true;
        btnRemove.Click += btnRemove_Click;
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
        dgvCatalog.Location = new Point(12, 79);
        dgvCatalog.MultiSelect = false;
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
        dgvCatalog.Size = new Size(900, 359);
        dgvCatalog.TabIndex = 366;
        dgvCatalog.CellMouseDoubleClick += dgvCatalog_CellMouseDoubleClick;
        // 
        // btnModify
        // 
        btnModify.Location = new Point(93, 50);
        btnModify.Name = "btnModify";
        btnModify.Size = new Size(75, 23);
        btnModify.TabIndex = 361;
        btnModify.Text = "Modificar";
        btnModify.UseVisualStyleBackColor = true;
        btnModify.Click += btnModify_Click;
        // 
        // btnAdd
        // 
        btnAdd.Location = new Point(12, 50);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new Size(75, 23);
        btnAdd.TabIndex = 360;
        btnAdd.Text = "Añadir";
        btnAdd.UseVisualStyleBackColor = true;
        btnAdd.Click += btnAdd_Click;
        // 
        // chbRemoved
        // 
        chbRemoved.Appearance = Appearance.Button;
        chbRemoved.Location = new Point(174, 50);
        chbRemoved.Name = "chbRemoved";
        chbRemoved.Size = new Size(75, 23);
        chbRemoved.TabIndex = 367;
        chbRemoved.Text = "Eliminados";
        chbRemoved.TextAlign = ContentAlignment.MiddleCenter;
        chbRemoved.UseVisualStyleBackColor = true;
        chbRemoved.CheckedChanged += chbRemoved_CheckedChanged;
        // 
        // btnRecover
        // 
        btnRecover.Location = new Point(336, 50);
        btnRecover.Name = "btnRecover";
        btnRecover.Size = new Size(75, 23);
        btnRecover.TabIndex = 369;
        btnRecover.Text = "Recuperar";
        btnRecover.UseVisualStyleBackColor = true;
        btnRecover.Click += btnRecover_Click;
        // 
        // cboCrop
        // 
        cboCrop.DropDownStyle = ComboBoxStyle.DropDownList;
        cboCrop.DropDownWidth = 400;
        cboCrop.FormattingEnabled = true;
        cboCrop.Location = new Point(12, 21);
        cboCrop.Name = "cboCrop";
        cboCrop.Size = new Size(203, 23);
        cboCrop.TabIndex = 385;
        // 
        // lblCrop
        // 
        lblCrop.AutoSize = true;
        lblCrop.Font = new Font("Segoe UI", 6.75F);
        lblCrop.Location = new Point(12, 9);
        lblCrop.Name = "lblCrop";
        lblCrop.Size = new Size(32, 12);
        lblCrop.TabIndex = 386;
        lblCrop.Text = "Cultivo";
        // 
        // cboColor
        // 
        cboColor.DropDownStyle = ComboBoxStyle.DropDownList;
        cboColor.DropDownWidth = 400;
        cboColor.FormattingEnabled = true;
        cboColor.Location = new Point(221, 21);
        cboColor.Name = "cboColor";
        cboColor.Size = new Size(190, 23);
        cboColor.TabIndex = 383;
        // 
        // lblColor
        // 
        lblColor.AutoSize = true;
        lblColor.Font = new Font("Segoe UI", 6.75F);
        lblColor.Location = new Point(221, 9);
        lblColor.Name = "lblColor";
        lblColor.Size = new Size(26, 12);
        lblColor.TabIndex = 384;
        lblColor.Text = "Color";
        // 
        // FrmVarietyCat
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(924, 450);
        Controls.Add(cboColor);
        Controls.Add(lblColor);
        Controls.Add(cboCrop);
        Controls.Add(lblCrop);
        Controls.Add(chbRemoved);
        Controls.Add(btnRecover);
        Controls.Add(btnRemove);
        Controls.Add(btnModify);
        Controls.Add(btnAdd);
        Controls.Add(dgvCatalog);
        Icon = (Icon)resources.GetObject("$this.Icon");
        Name = "FrmVarietyCat";
        Text = "Catálogo de variedades";
        WindowState = FormWindowState.Maximized;
        Load += FrmVarietyCat_Load;
        ((System.ComponentModel.ISupportInitialize)dgvCatalog).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button btnRemove;
        public DataGridView dgvCatalog;
        private Button btnModify;
        private Button btnAdd;
        public CheckBox chbRemoved;
        private Button btnRecover;
        public ComboBox cboCrop;
        private Label lblCrop;
        public ComboBox cboColor;
        private Label lblColor;
    }
