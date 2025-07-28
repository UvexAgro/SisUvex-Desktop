namespace SisUvex.Catalogos.Driver
{
    partial class FrmDriverCat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDriverCat));
            chbRemoved = new CheckBox();
            dgvCatalog = new DataGridView();
            btnRemove = new Button();
            btnRecover = new Button();
            btnModify = new Button();
            btnAdd = new Button();
            cboTransportLine = new ComboBox();
            label8 = new Label();
            btnTransportLineSearch = new Button();
            chbTransportLineRemoved = new CheckBox();
            btnTransportLineFilter = new Button();
            chbDriverTransportLineRemoved = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dgvCatalog).BeginInit();
            SuspendLayout();
            // 
            // chbRemoved
            // 
            chbRemoved.Appearance = Appearance.Button;
            chbRemoved.Location = new Point(174, 13);
            chbRemoved.Name = "chbRemoved";
            chbRemoved.Size = new Size(75, 23);
            chbRemoved.TabIndex = 2;
            chbRemoved.Text = "Eliminados";
            chbRemoved.TextAlign = ContentAlignment.MiddleCenter;
            chbRemoved.UseVisualStyleBackColor = true;
            chbRemoved.CheckedChanged += chbRemoved_CheckedChanged;
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
            dgvCatalog.Location = new Point(12, 71);
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
            dgvCatalog.Size = new Size(851, 363);
            dgvCatalog.TabIndex = 10;
            dgvCatalog.CellMouseDoubleClick += dgvCatalog_CellMouseDoubleClick;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(255, 13);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(75, 23);
            btnRemove.TabIndex = 3;
            btnRemove.Text = "Eliminar";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnRecover
            // 
            btnRecover.Location = new Point(336, 13);
            btnRecover.Name = "btnRecover";
            btnRecover.Size = new Size(75, 23);
            btnRecover.TabIndex = 4;
            btnRecover.Text = "Recuperar";
            btnRecover.UseVisualStyleBackColor = true;
            btnRecover.Click += btnRecover_Click;
            // 
            // btnModify
            // 
            btnModify.Location = new Point(93, 13);
            btnModify.Name = "btnModify";
            btnModify.Size = new Size(75, 23);
            btnModify.TabIndex = 1;
            btnModify.Text = "Modificar";
            btnModify.UseVisualStyleBackColor = true;
            btnModify.Click += btnModify_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(12, 13);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Añadir";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // cboTransportLine
            // 
            cboTransportLine.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTransportLine.FormattingEnabled = true;
            cboTransportLine.Location = new Point(336, 41);
            cboTransportLine.Name = "cboTransportLine";
            cboTransportLine.Size = new Size(203, 23);
            cboTransportLine.TabIndex = 6;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 6.75F);
            label8.Location = new Point(253, 47);
            label8.Name = "label8";
            label8.Size = new Size(81, 12);
            label8.TabIndex = 415;
            label8.Text = "Línea de transporte";
            // 
            // btnTransportLineSearch
            // 
            btnTransportLineSearch.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnTransportLineSearch.BackgroundImageLayout = ImageLayout.Stretch;
            btnTransportLineSearch.Location = new Point(562, 40);
            btnTransportLineSearch.Name = "btnTransportLineSearch";
            btnTransportLineSearch.Size = new Size(25, 25);
            btnTransportLineSearch.TabIndex = 8;
            btnTransportLineSearch.UseVisualStyleBackColor = true;
            btnTransportLineSearch.Click += btnTransportLineSearch_Click;
            // 
            // chbTransportLineRemoved
            // 
            chbTransportLineRemoved.Appearance = Appearance.Button;
            chbTransportLineRemoved.Image = Properties.Resources.removedList16;
            chbTransportLineRemoved.Location = new Point(539, 40);
            chbTransportLineRemoved.Margin = new Padding(0);
            chbTransportLineRemoved.Name = "chbTransportLineRemoved";
            chbTransportLineRemoved.Padding = new Padding(0, 1, 0, 0);
            chbTransportLineRemoved.Size = new Size(24, 25);
            chbTransportLineRemoved.TabIndex = 7;
            chbTransportLineRemoved.TextAlign = ContentAlignment.MiddleCenter;
            chbTransportLineRemoved.UseVisualStyleBackColor = true;
            // 
            // btnTransportLineFilter
            // 
            btnTransportLineFilter.BackgroundImage = (Image)resources.GetObject("btnTransportLineFilter.BackgroundImage");
            btnTransportLineFilter.BackgroundImageLayout = ImageLayout.Stretch;
            btnTransportLineFilter.Location = new Point(586, 40);
            btnTransportLineFilter.Name = "btnTransportLineFilter";
            btnTransportLineFilter.Size = new Size(25, 25);
            btnTransportLineFilter.TabIndex = 9;
            btnTransportLineFilter.UseVisualStyleBackColor = true;
            btnTransportLineFilter.Click += btnTransportLineFilter_Click;
            // 
            // chbDriverTransportLineRemoved
            // 
            chbDriverTransportLineRemoved.Appearance = Appearance.Button;
            chbDriverTransportLineRemoved.Location = new Point(12, 41);
            chbDriverTransportLineRemoved.Name = "chbDriverTransportLineRemoved";
            chbDriverTransportLineRemoved.Size = new Size(111, 23);
            chbDriverTransportLineRemoved.TabIndex = 5;
            chbDriverTransportLineRemoved.Text = "Líneas eliminadas";
            chbDriverTransportLineRemoved.TextAlign = ContentAlignment.MiddleCenter;
            chbDriverTransportLineRemoved.UseVisualStyleBackColor = true;
            chbDriverTransportLineRemoved.CheckedChanged += chbDriverTransportLineRemoved_CheckedChanged;
            // 
            // FrmDriverCat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(875, 447);
            Controls.Add(chbDriverTransportLineRemoved);
            Controls.Add(btnTransportLineFilter);
            Controls.Add(btnTransportLineSearch);
            Controls.Add(chbTransportLineRemoved);
            Controls.Add(cboTransportLine);
            Controls.Add(label8);
            Controls.Add(chbRemoved);
            Controls.Add(dgvCatalog);
            Controls.Add(btnRemove);
            Controls.Add(btnRecover);
            Controls.Add(btnModify);
            Controls.Add(btnAdd);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmDriverCat";
            Text = "Catálogo de choferes";
            WindowState = FormWindowState.Maximized;
            Load += FrmDriverCat_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCatalog).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public CheckBox chbRemoved;
        public DataGridView dgvCatalog;
        private Button btnRemove;
        private Button btnRecover;
        private Button btnModify;
        private Button btnAdd;
        public ComboBox cboTransportLine;
        private Label label8;
        private Button btnTransportLineSearch;
        public CheckBox chbTransportLineRemoved;
        private Button btnTransportLineFilter;
        public CheckBox chbDriverTransportLineRemoved;
    }
}