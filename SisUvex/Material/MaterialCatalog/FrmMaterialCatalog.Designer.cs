namespace SisUvex.Material.MaterialCatalog
{
    partial class FrmMaterialCatalog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMaterialCatalog));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            btnTemplates = new Button();
            btnConfigManifest = new Button();
            cboGrower = new ComboBox();
            label5 = new Label();
            btnSearchManifest = new Button();
            txbIdManifest = new TextBox();
            btnPrint = new Button();
            btnRemoved = new Button();
            label2 = new Label();
            btnRemove = new Button();
            btnRecover = new Button();
            cboConsignee = new ComboBox();
            dgvCatalog = new DataGridView();
            cboDistributor = new ComboBox();
            btnModify = new Button();
            btnAdd = new Button();
            label1 = new Label();
            label6 = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCatalog).BeginInit();
            SuspendLayout();
            // 
            // btnTemplates
            // 
            btnTemplates.Font = new Font("Microsoft Sans Serif", 9F);
            btnTemplates.Image = Properties.Resources.templateIcon16;
            btnTemplates.ImageAlign = ContentAlignment.BottomCenter;
            btnTemplates.Location = new Point(528, 98);
            btnTemplates.Name = "btnTemplates";
            btnTemplates.Size = new Size(24, 23);
            btnTemplates.TabIndex = 385;
            btnTemplates.TextAlign = ContentAlignment.TopRight;
            btnTemplates.UseVisualStyleBackColor = true;
            // 
            // btnConfigManifest
            // 
            btnConfigManifest.Font = new Font("Microsoft Sans Serif", 9F);
            btnConfigManifest.Image = (Image)resources.GetObject("btnConfigManifest.Image");
            btnConfigManifest.ImageAlign = ContentAlignment.BottomCenter;
            btnConfigManifest.Location = new Point(498, 98);
            btnConfigManifest.Name = "btnConfigManifest";
            btnConfigManifest.Size = new Size(24, 23);
            btnConfigManifest.TabIndex = 384;
            btnConfigManifest.TextAlign = ContentAlignment.TopRight;
            btnConfigManifest.UseVisualStyleBackColor = true;
            // 
            // cboGrower
            // 
            cboGrower.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGrower.FormattingEnabled = true;
            cboGrower.Location = new Point(221, 21);
            cboGrower.Name = "cboGrower";
            cboGrower.Size = new Size(203, 23);
            cboGrower.TabIndex = 362;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 6.75F);
            label5.Location = new Point(221, 9);
            label5.Name = "label5";
            label5.Size = new Size(44, 12);
            label5.TabIndex = 371;
            label5.Text = "Categoría";
            // 
            // btnSearchManifest
            // 
            btnSearchManifest.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnSearchManifest.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearchManifest.Location = new Point(221, 60);
            btnSearchManifest.Name = "btnSearchManifest";
            btnSearchManifest.Size = new Size(23, 23);
            btnSearchManifest.TabIndex = 365;
            btnSearchManifest.UseVisualStyleBackColor = true;
            // 
            // txbIdManifest
            // 
            txbIdManifest.Location = new Point(12, 60);
            txbIdManifest.MaxLength = 5;
            txbIdManifest.Name = "txbIdManifest";
            txbIdManifest.Size = new Size(203, 23);
            txbIdManifest.TabIndex = 364;
            // 
            // btnPrint
            // 
            btnPrint.Location = new Point(417, 98);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(75, 23);
            btnPrint.TabIndex = 377;
            btnPrint.Text = "Imprimir";
            btnPrint.UseVisualStyleBackColor = true;
            // 
            // btnRemoved
            // 
            btnRemoved.Location = new Point(174, 98);
            btnRemoved.Name = "btnRemoved";
            btnRemoved.Size = new Size(75, 23);
            btnRemoved.TabIndex = 374;
            btnRemoved.Text = "Eliminados";
            btnRemoved.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 6.75F);
            label2.Location = new Point(430, 9);
            label2.Name = "label2";
            label2.Size = new Size(26, 12);
            label2.TabIndex = 367;
            label2.Text = "Color";
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(255, 98);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(75, 23);
            btnRemove.TabIndex = 375;
            btnRemove.Text = "Eliminar";
            btnRemove.UseVisualStyleBackColor = true;
            // 
            // btnRecover
            // 
            btnRecover.Location = new Point(336, 98);
            btnRecover.Name = "btnRecover";
            btnRecover.Size = new Size(75, 23);
            btnRecover.TabIndex = 376;
            btnRecover.Text = "Recuperar";
            btnRecover.UseVisualStyleBackColor = true;
            // 
            // cboConsignee
            // 
            cboConsignee.DropDownStyle = ComboBoxStyle.DropDownList;
            cboConsignee.FormattingEnabled = true;
            cboConsignee.Location = new Point(430, 21);
            cboConsignee.Name = "cboConsignee";
            cboConsignee.Size = new Size(203, 23);
            cboConsignee.TabIndex = 363;
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
            dgvCatalog.Location = new Point(12, 127);
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
            dgvCatalog.Size = new Size(776, 314);
            dgvCatalog.TabIndex = 381;
            // 
            // cboDistributor
            // 
            cboDistributor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDistributor.FormattingEnabled = true;
            cboDistributor.Location = new Point(12, 21);
            cboDistributor.Name = "cboDistributor";
            cboDistributor.Size = new Size(203, 23);
            cboDistributor.TabIndex = 361;
            // 
            // btnModify
            // 
            btnModify.Location = new Point(93, 98);
            btnModify.Name = "btnModify";
            btnModify.Size = new Size(75, 23);
            btnModify.TabIndex = 373;
            btnModify.Text = "Modificar";
            btnModify.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(12, 98);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 372;
            btnAdd.Text = "Añadir";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 6.75F);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(50, 12);
            label1.TabIndex = 366;
            label1.Text = "Distribuidor";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 6.75F);
            label6.Location = new Point(12, 47);
            label6.Name = "label6";
            label6.Size = new Size(31, 12);
            label6.TabIndex = 368;
            label6.Text = "Buscar";
            // 
            // button1
            // 
            button1.BackgroundImage = Properties.Resources.BuscarLupa1;
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.Location = new Point(639, 21);
            button1.Name = "button1";
            button1.Size = new Size(23, 23);
            button1.TabIndex = 386;
            button1.UseVisualStyleBackColor = true;
            // 
            // FrmMaterialCatalog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(btnTemplates);
            Controls.Add(btnConfigManifest);
            Controls.Add(cboGrower);
            Controls.Add(label5);
            Controls.Add(btnSearchManifest);
            Controls.Add(txbIdManifest);
            Controls.Add(btnPrint);
            Controls.Add(btnRemoved);
            Controls.Add(label2);
            Controls.Add(btnRemove);
            Controls.Add(btnRecover);
            Controls.Add(cboConsignee);
            Controls.Add(dgvCatalog);
            Controls.Add(cboDistributor);
            Controls.Add(btnModify);
            Controls.Add(btnAdd);
            Controls.Add(label1);
            Controls.Add(label6);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmMaterialCatalog";
            Text = "Catálogo de materiales";
            ((System.ComponentModel.ISupportInitialize)dgvCatalog).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnTemplates;
        private Button btnConfigManifest;
        public ComboBox cboGrower;
        private Label label5;
        private Button btnSearchManifest;
        private TextBox txbIdManifest;
        private Button btnPrint;
        public Button btnRemoved;
        private Label label2;
        private Button btnRemove;
        private Button btnRecover;
        public ComboBox cboConsignee;
        public DataGridView dgvCatalog;
        public ComboBox cboDistributor;
        private Button btnModify;
        private Button btnAdd;
        private Label label1;
        private Label label6;
        private Button button1;
    }
}