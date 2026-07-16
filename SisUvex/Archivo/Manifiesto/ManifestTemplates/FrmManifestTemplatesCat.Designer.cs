namespace SisUvex.Archivo.Manifiesto.ManifestTemplates
{
    partial class FrmManifestTemplatesCat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmManifestTemplatesCat));
            btnRemove = new Button();
            dgvCatalog = new DataGridView();
            btnModify = new Button();
            btnAdd = new Button();
            chbRemoved = new CheckBox();
            btnRecover = new Button();
            cboDistributor = new ComboBox();
            lblDistribuidor = new Label();
            cboGrower = new ComboBox();
            label1 = new Label();
            cboAgencyUS = new ComboBox();
            label2 = new Label();
            cboAgencyMX = new ComboBox();
            label3 = new Label();
            cboCityDestiny = new ComboBox();
            label4 = new Label();
            cboCityCross = new ComboBox();
            label5 = new Label();
            btnSearchManifest = new Button();
            cboConsignee = new ComboBox();
            label6 = new Label();
            cboCrop = new ComboBox();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvCatalog).BeginInit();
            SuspendLayout();
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(255, 93);
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
            dgvCatalog.Location = new Point(12, 122);
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
            dgvCatalog.Size = new Size(1115, 316);
            dgvCatalog.TabIndex = 366;
            dgvCatalog.CellMouseDoubleClick += dgvCatalog_CellMouseDoubleClick;
            // 
            // btnModify
            // 
            btnModify.Location = new Point(93, 93);
            btnModify.Name = "btnModify";
            btnModify.Size = new Size(75, 23);
            btnModify.TabIndex = 361;
            btnModify.Text = "Modificar";
            btnModify.UseVisualStyleBackColor = true;
            btnModify.Click += btnModify_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(12, 93);
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
            chbRemoved.Location = new Point(174, 93);
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
            btnRecover.Location = new Point(336, 93);
            btnRecover.Name = "btnRecover";
            btnRecover.Size = new Size(75, 23);
            btnRecover.TabIndex = 369;
            btnRecover.Text = "Recuperar";
            btnRecover.UseVisualStyleBackColor = true;
            btnRecover.Click += btnRecover_Click;
            // 
            // cboDistributor
            // 
            cboDistributor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDistributor.DropDownWidth = 400;
            cboDistributor.FormattingEnabled = true;
            cboDistributor.Location = new Point(252, 21);
            cboDistributor.Name = "cboDistributor";
            cboDistributor.Size = new Size(203, 23);
            cboDistributor.TabIndex = 370;
            // 
            // lblDistribuidor
            // 
            lblDistribuidor.AutoSize = true;
            lblDistribuidor.Font = new Font("Segoe UI", 6.75F);
            lblDistribuidor.Location = new Point(252, 9);
            lblDistribuidor.Name = "lblDistribuidor";
            lblDistribuidor.Size = new Size(50, 12);
            lblDistribuidor.TabIndex = 371;
            lblDistribuidor.Text = "Distribuidor";
            // 
            // cboGrower
            // 
            cboGrower.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGrower.DropDownWidth = 400;
            cboGrower.FormattingEnabled = true;
            cboGrower.Location = new Point(43, 60);
            cboGrower.Name = "cboGrower";
            cboGrower.Size = new Size(203, 23);
            cboGrower.TabIndex = 372;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 6.75F);
            label1.Location = new Point(43, 48);
            label1.Name = "label1";
            label1.Size = new Size(43, 12);
            label1.TabIndex = 373;
            label1.Text = "Productor";
            // 
            // cboAgencyUS
            // 
            cboAgencyUS.DropDownStyle = ComboBoxStyle.DropDownList;
            cboAgencyUS.DropDownWidth = 400;
            cboAgencyUS.FormattingEnabled = true;
            cboAgencyUS.Location = new Point(461, 21);
            cboAgencyUS.Name = "cboAgencyUS";
            cboAgencyUS.Size = new Size(203, 23);
            cboAgencyUS.TabIndex = 374;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 6.75F);
            label2.Location = new Point(461, 9);
            label2.Name = "label2";
            label2.Size = new Size(50, 12);
            label2.TabIndex = 375;
            label2.Text = "Agencia US";
            // 
            // cboAgencyMX
            // 
            cboAgencyMX.DropDownStyle = ComboBoxStyle.DropDownList;
            cboAgencyMX.DropDownWidth = 400;
            cboAgencyMX.FormattingEnabled = true;
            cboAgencyMX.Location = new Point(670, 21);
            cboAgencyMX.Name = "cboAgencyMX";
            cboAgencyMX.Size = new Size(203, 23);
            cboAgencyMX.TabIndex = 376;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 6.75F);
            label3.Location = new Point(670, 9);
            label3.Name = "label3";
            label3.Size = new Size(52, 12);
            label3.TabIndex = 377;
            label3.Text = "Agencia MX";
            // 
            // cboCityDestiny
            // 
            cboCityDestiny.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCityDestiny.DropDownWidth = 400;
            cboCityDestiny.FormattingEnabled = true;
            cboCityDestiny.Location = new Point(670, 60);
            cboCityDestiny.Name = "cboCityDestiny";
            cboCityDestiny.Size = new Size(203, 23);
            cboCityDestiny.TabIndex = 380;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 6.75F);
            label4.Location = new Point(670, 48);
            label4.Name = "label4";
            label4.Size = new Size(64, 12);
            label4.TabIndex = 381;
            label4.Text = "Ciudad destino";
            // 
            // cboCityCross
            // 
            cboCityCross.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCityCross.DropDownWidth = 400;
            cboCityCross.FormattingEnabled = true;
            cboCityCross.Location = new Point(461, 60);
            cboCityCross.Name = "cboCityCross";
            cboCityCross.Size = new Size(203, 23);
            cboCityCross.TabIndex = 378;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 6.75F);
            label5.Location = new Point(461, 48);
            label5.Name = "label5";
            label5.Size = new Size(68, 12);
            label5.TabIndex = 379;
            label5.Text = "Ciudad de cruce";
            // 
            // btnSearchManifest
            // 
            btnSearchManifest.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnSearchManifest.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearchManifest.Location = new Point(12, 60);
            btnSearchManifest.Name = "btnSearchManifest";
            btnSearchManifest.Size = new Size(25, 25);
            btnSearchManifest.TabIndex = 382;
            btnSearchManifest.UseVisualStyleBackColor = true;
            btnSearchManifest.Click += btnSearchManifest_Click;
            // 
            // cboConsignee
            // 
            cboConsignee.DropDownStyle = ComboBoxStyle.DropDownList;
            cboConsignee.DropDownWidth = 400;
            cboConsignee.FormattingEnabled = true;
            cboConsignee.Location = new Point(252, 60);
            cboConsignee.Name = "cboConsignee";
            cboConsignee.Size = new Size(203, 23);
            cboConsignee.TabIndex = 383;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 6.75F);
            label6.Location = new Point(252, 48);
            label6.Name = "label6";
            label6.Size = new Size(60, 12);
            label6.TabIndex = 384;
            label6.Text = "Consignatario";
            // 
            // cboCrop
            // 
            cboCrop.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCrop.DropDownWidth = 400;
            cboCrop.FormattingEnabled = true;
            cboCrop.Location = new Point(43, 21);
            cboCrop.Name = "cboCrop";
            cboCrop.Size = new Size(203, 23);
            cboCrop.TabIndex = 385;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 6.75F);
            label7.Location = new Point(43, 9);
            label7.Name = "label7";
            label7.Size = new Size(32, 12);
            label7.TabIndex = 386;
            label7.Text = "Cultivo";
            // 
            // FrmManifestTemplatesCat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1139, 450);
            Controls.Add(cboCrop);
            Controls.Add(label7);
            Controls.Add(cboConsignee);
            Controls.Add(label6);
            Controls.Add(btnSearchManifest);
            Controls.Add(cboCityDestiny);
            Controls.Add(label4);
            Controls.Add(cboCityCross);
            Controls.Add(label5);
            Controls.Add(cboAgencyMX);
            Controls.Add(label3);
            Controls.Add(cboAgencyUS);
            Controls.Add(label2);
            Controls.Add(cboGrower);
            Controls.Add(label1);
            Controls.Add(cboDistributor);
            Controls.Add(lblDistribuidor);
            Controls.Add(chbRemoved);
            Controls.Add(btnRecover);
            Controls.Add(btnRemove);
            Controls.Add(btnModify);
            Controls.Add(btnAdd);
            Controls.Add(dgvCatalog);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmManifestTemplatesCat";
            Text = "Catálogo plantillas de manifiesto";
            WindowState = FormWindowState.Maximized;
            Load += FrmManifestTemplatesCat_Load;
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
        public ComboBox cboDistributor;
        private Label lblDistribuidor;
        public ComboBox cboGrower;
        private Label label1;
        public ComboBox cboAgencyUS;
        private Label label2;
        public ComboBox cboAgencyMX;
        private Label label3;
        public ComboBox cboCityDestiny;
        private Label label4;
        public ComboBox cboCityCross;
        private Label label5;
        private Button btnSearchManifest;
        public ComboBox cboConsignee;
        private Label label6;
        public ComboBox cboCrop;
        private Label label7;
    }
}