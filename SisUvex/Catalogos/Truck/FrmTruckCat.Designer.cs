namespace SisUvex.Catalogos.Truck
{
    partial class FrmTruckCat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTruckCat));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            chbTruckTransportLineRemoved = new CheckBox();
            btnTransportLineFilter = new Button();
            btnTransportLineSearch = new Button();
            chbTransportLineRemoved = new CheckBox();
            cboTransportLine = new ComboBox();
            label8 = new Label();
            chbRemoved = new CheckBox();
            dgvCatalog = new DataGridView();
            btnRemove = new Button();
            btnRecover = new Button();
            btnModify = new Button();
            btnAdd = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCatalog).BeginInit();
            SuspendLayout();
            // 
            // chbTruckTransportLineRemoved
            // 
            chbTruckTransportLineRemoved.Appearance = Appearance.Button;
            chbTruckTransportLineRemoved.Location = new Point(12, 40);
            chbTruckTransportLineRemoved.Name = "chbTruckTransportLineRemoved";
            chbTruckTransportLineRemoved.Size = new Size(111, 23);
            chbTruckTransportLineRemoved.TabIndex = 447;
            chbTruckTransportLineRemoved.Text = "Líneas eliminadas";
            chbTruckTransportLineRemoved.TextAlign = ContentAlignment.MiddleCenter;
            chbTruckTransportLineRemoved.UseVisualStyleBackColor = true;
            chbTruckTransportLineRemoved.CheckedChanged += chbTruckTransportLineRemoved_CheckedChanged;
            // 
            // btnTransportLineFilter
            // 
            btnTransportLineFilter.BackgroundImage = (Image)resources.GetObject("btnTransportLineFilter.BackgroundImage");
            btnTransportLineFilter.BackgroundImageLayout = ImageLayout.Stretch;
            btnTransportLineFilter.Location = new Point(586, 39);
            btnTransportLineFilter.Name = "btnTransportLineFilter";
            btnTransportLineFilter.Size = new Size(25, 25);
            btnTransportLineFilter.TabIndex = 446;
            btnTransportLineFilter.UseVisualStyleBackColor = true;
            btnTransportLineFilter.Click += btnTransportLineFilter_Click;
            // 
            // btnTransportLineSearch
            // 
            btnTransportLineSearch.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnTransportLineSearch.BackgroundImageLayout = ImageLayout.Stretch;
            btnTransportLineSearch.Location = new Point(562, 39);
            btnTransportLineSearch.Name = "btnTransportLineSearch";
            btnTransportLineSearch.Size = new Size(25, 25);
            btnTransportLineSearch.TabIndex = 445;
            btnTransportLineSearch.UseVisualStyleBackColor = true;
            btnTransportLineSearch.Click += btnTransportLineSearch_Click;
            // 
            // chbTransportLineRemoved
            // 
            chbTransportLineRemoved.Appearance = Appearance.Button;
            chbTransportLineRemoved.Image = Properties.Resources.removedList16;
            chbTransportLineRemoved.Location = new Point(539, 39);
            chbTransportLineRemoved.Margin = new Padding(0);
            chbTransportLineRemoved.Name = "chbTransportLineRemoved";
            chbTransportLineRemoved.Padding = new Padding(0, 1, 0, 0);
            chbTransportLineRemoved.Size = new Size(24, 25);
            chbTransportLineRemoved.TabIndex = 444;
            chbTransportLineRemoved.TextAlign = ContentAlignment.MiddleCenter;
            chbTransportLineRemoved.UseVisualStyleBackColor = true;
            // 
            // cboTransportLine
            // 
            cboTransportLine.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTransportLine.FormattingEnabled = true;
            cboTransportLine.Location = new Point(336, 40);
            cboTransportLine.Name = "cboTransportLine";
            cboTransportLine.Size = new Size(203, 23);
            cboTransportLine.TabIndex = 442;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 6.75F);
            label8.Location = new Point(253, 46);
            label8.Name = "label8";
            label8.Size = new Size(81, 12);
            label8.TabIndex = 443;
            label8.Text = "Línea de transporte";
            // 
            // chbRemoved
            // 
            chbRemoved.Appearance = Appearance.Button;
            chbRemoved.Location = new Point(174, 12);
            chbRemoved.Name = "chbRemoved";
            chbRemoved.Size = new Size(75, 23);
            chbRemoved.TabIndex = 441;
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
            dgvCatalog.Location = new Point(12, 70);
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
            dgvCatalog.Size = new Size(776, 363);
            dgvCatalog.TabIndex = 440;
            dgvCatalog.CellMouseDoubleClick += dgvCatalog_CellMouseDoubleClick;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(255, 12);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(75, 23);
            btnRemove.TabIndex = 438;
            btnRemove.Text = "Eliminar";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnRecover
            // 
            btnRecover.Location = new Point(336, 12);
            btnRecover.Name = "btnRecover";
            btnRecover.Size = new Size(75, 23);
            btnRecover.TabIndex = 439;
            btnRecover.Text = "Recuperar";
            btnRecover.UseVisualStyleBackColor = true;
            btnRecover.Click += btnRecover_Click;
            // 
            // btnModify
            // 
            btnModify.Location = new Point(93, 12);
            btnModify.Name = "btnModify";
            btnModify.Size = new Size(75, 23);
            btnModify.TabIndex = 437;
            btnModify.Text = "Modificar";
            btnModify.UseVisualStyleBackColor = true;
            btnModify.Click += btnModify_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(12, 12);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 436;
            btnAdd.Text = "Añadir";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // FrmTruckCat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(chbTruckTransportLineRemoved);
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
            Name = "FrmTruckCat";
            Text = "Catálogo de troques";
            WindowState = FormWindowState.Maximized;
            Load += FrmTruckCat_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCatalog).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public CheckBox chbTruckTransportLineRemoved;
        private Button btnTransportLineFilter;
        private Button btnTransportLineSearch;
        public CheckBox chbTransportLineRemoved;
        public ComboBox cboTransportLine;
        private Label label8;
        public CheckBox chbRemoved;
        public DataGridView dgvCatalog;
        private Button btnRemove;
        private Button btnRecover;
        private Button btnModify;
        private Button btnAdd;
    }
}