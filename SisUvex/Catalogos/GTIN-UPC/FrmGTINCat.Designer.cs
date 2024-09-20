namespace SisUvex.Catalogos.GTIN_UPC
{
    partial class FrmGtinCat
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
            dgvCatalog = new DataGridView();
            btnRemove = new Button();
            btnRecover = new Button();
            btnModify = new Button();
            btnAdd = new Button();
            cboVariety = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            cboContainer = new ComboBox();
            cboDistributor = new ComboBox();
            lblDistribuidor = new Label();
            label1 = new Label();
            cboPresentation = new ComboBox();
            btnSearch = new Button();
            chbRemoved = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dgvCatalog).BeginInit();
            SuspendLayout();
            // 
            // dgvCatalog
            // 
            dgvCatalog.AllowUserToAddRows = false;
            dgvCatalog.AllowUserToDeleteRows = false;
            dgvCatalog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCatalog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvCatalog.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
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
            dgvCatalog.Location = new Point(9, 104);
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
            dgvCatalog.RowTemplate.Height = 25;
            dgvCatalog.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCatalog.Size = new Size(783, 338);
            dgvCatalog.TabIndex = 16;
            dgvCatalog.MouseDoubleClick += dgvCatalog_MouseDoubleClick;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(247, 75);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(75, 23);
            btnRemove.TabIndex = 15;
            btnRemove.Text = "Eliminar";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnRecover
            // 
            btnRecover.Location = new Point(328, 75);
            btnRecover.Name = "btnRecover";
            btnRecover.Size = new Size(75, 23);
            btnRecover.TabIndex = 14;
            btnRecover.Text = "Recuperar";
            btnRecover.UseVisualStyleBackColor = true;
            btnRecover.Click += btnRecover_Click;
            // 
            // btnModify
            // 
            btnModify.Location = new Point(90, 75);
            btnModify.Name = "btnModify";
            btnModify.Size = new Size(75, 23);
            btnModify.TabIndex = 13;
            btnModify.Text = "Modificar";
            btnModify.UseVisualStyleBackColor = true;
            btnModify.Click += btnModify_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(9, 75);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 12;
            btnAdd.Text = "Añadir";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // cboVariety
            // 
            cboVariety.DropDownStyle = ComboBoxStyle.DropDownList;
            cboVariety.DropDownWidth = 400;
            cboVariety.FormattingEnabled = true;
            cboVariety.Location = new Point(38, 47);
            cboVariety.Name = "cboVariety";
            cboVariety.Size = new Size(203, 23);
            cboVariety.TabIndex = 44;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 6.75F);
            label2.Location = new Point(38, 35);
            label2.Name = "label2";
            label2.Size = new Size(40, 12);
            label2.TabIndex = 46;
            label2.Text = "Variedad";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 6.75F);
            label3.Location = new Point(247, 0);
            label3.Name = "label3";
            label3.Size = new Size(52, 12);
            label3.TabIndex = 47;
            label3.Text = "Contenedor";
            // 
            // cboContainer
            // 
            cboContainer.DropDownStyle = ComboBoxStyle.DropDownList;
            cboContainer.DropDownWidth = 400;
            cboContainer.FormattingEnabled = true;
            cboContainer.Location = new Point(247, 12);
            cboContainer.Name = "cboContainer";
            cboContainer.Size = new Size(203, 23);
            cboContainer.TabIndex = 45;
            // 
            // cboDistributor
            // 
            cboDistributor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDistributor.DropDownWidth = 400;
            cboDistributor.FormattingEnabled = true;
            cboDistributor.Location = new Point(38, 12);
            cboDistributor.Name = "cboDistributor";
            cboDistributor.Size = new Size(203, 23);
            cboDistributor.TabIndex = 40;
            // 
            // lblDistribuidor
            // 
            lblDistribuidor.AutoSize = true;
            lblDistribuidor.Font = new Font("Segoe UI", 6.75F);
            lblDistribuidor.Location = new Point(38, 0);
            lblDistribuidor.Name = "lblDistribuidor";
            lblDistribuidor.Size = new Size(50, 12);
            lblDistribuidor.TabIndex = 42;
            lblDistribuidor.Text = "Distribuidor";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 6.75F);
            label1.Location = new Point(247, 35);
            label1.Name = "label1";
            label1.Size = new Size(56, 12);
            label1.TabIndex = 43;
            label1.Text = "Presentación";
            // 
            // cboPresentation
            // 
            cboPresentation.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPresentation.DropDownWidth = 400;
            cboPresentation.FormattingEnabled = true;
            cboPresentation.Location = new Point(247, 47);
            cboPresentation.Name = "cboPresentation";
            cboPresentation.Size = new Size(203, 23);
            cboPresentation.TabIndex = 41;
            // 
            // btnSearch
            // 
            btnSearch.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnSearch.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearch.Location = new Point(9, 46);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(23, 23);
            btnSearch.TabIndex = 48;
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // chbRemoved
            // 
            chbRemoved.Appearance = Appearance.Button;
            chbRemoved.AutoSize = true;
            chbRemoved.FlatStyle = FlatStyle.System;
            chbRemoved.Location = new Point(169, 74);
            chbRemoved.Margin = new Padding(1);
            chbRemoved.Name = "chbRemoved";
            chbRemoved.Size = new Size(75, 25);
            chbRemoved.TabIndex = 49;
            chbRemoved.Text = "Eliminados";
            chbRemoved.TextAlign = ContentAlignment.MiddleCenter;
            chbRemoved.UseVisualStyleBackColor = true;
            chbRemoved.CheckedChanged += chbRemoved_CheckedChanged;
            // 
            // FrmGtinCat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(chbRemoved);
            Controls.Add(btnSearch);
            Controls.Add(cboVariety);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(cboContainer);
            Controls.Add(cboDistributor);
            Controls.Add(lblDistribuidor);
            Controls.Add(label1);
            Controls.Add(cboPresentation);
            Controls.Add(dgvCatalog);
            Controls.Add(btnRemove);
            Controls.Add(btnRecover);
            Controls.Add(btnModify);
            Controls.Add(btnAdd);
            Name = "FrmGtinCat";
            Text = "FrmGtinCat";
            WindowState = FormWindowState.Maximized;
            Load += FrmGtinCat_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCatalog).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        public DataGridView dgvCatalog;
        private Button btnRemove;
        private Button btnRecover;
        private Button btnModify;
        private Button btnAdd;
        public ComboBox cboVariety;
        private Label label2;
        private Label label3;
        public ComboBox cboContainer;
        public ComboBox cboDistributor;
        private Label lblDistribuidor;
        private Label label1;
        public ComboBox cboPresentation;
        private Button btnSearch;
        public CheckBox chbRemoved;
    }
}