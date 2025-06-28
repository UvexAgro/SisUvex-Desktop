namespace SisUvex.Material.MaterialReports.Inventory
{
    partial class FrmMaterialReportInventory
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            dgvQuery = new DataGridView();
            cboMaterialType = new ComboBox();
            label5 = new Label();
            label2 = new Label();
            cboMaterial = new ComboBox();
            btnSearchFilters = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvQuery).BeginInit();
            SuspendLayout();
            // 
            // dgvQuery
            // 
            dgvQuery.AllowUserToAddRows = false;
            dgvQuery.AllowUserToDeleteRows = false;
            dgvQuery.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvQuery.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvQuery.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvQuery.BackgroundColor = SystemColors.ControlLightLight;
            dgvQuery.BorderStyle = BorderStyle.Fixed3D;
            dgvQuery.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvQuery.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvQuery.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvQuery.EnableHeadersVisualStyles = false;
            dgvQuery.ImeMode = ImeMode.NoControl;
            dgvQuery.Location = new Point(12, 50);
            dgvQuery.Name = "dgvQuery";
            dgvQuery.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvQuery.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvQuery.RowHeadersVisible = false;
            dgvQuery.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvQuery.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvQuery.Size = new Size(776, 388);
            dgvQuery.TabIndex = 11;
            // 
            // cboMaterialType
            // 
            cboMaterialType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMaterialType.FormattingEnabled = true;
            cboMaterialType.Location = new Point(12, 21);
            cboMaterialType.Name = "cboMaterialType";
            cboMaterialType.Size = new Size(203, 23);
            cboMaterialType.TabIndex = 440;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 6.75F);
            label5.Location = new Point(12, 9);
            label5.Name = "label5";
            label5.Size = new Size(69, 12);
            label5.TabIndex = 443;
            label5.Text = "Tipo de material";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 6.75F);
            label2.Location = new Point(221, 9);
            label2.Name = "label2";
            label2.Size = new Size(38, 12);
            label2.TabIndex = 442;
            label2.Text = "Material";
            // 
            // cboMaterial
            // 
            cboMaterial.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMaterial.FormattingEnabled = true;
            cboMaterial.Location = new Point(221, 21);
            cboMaterial.Name = "cboMaterial";
            cboMaterial.Size = new Size(203, 23);
            cboMaterial.TabIndex = 441;
            // 
            // btnSearchFilters
            // 
            btnSearchFilters.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearchFilters.Image = Properties.Resources.filterIcon16;
            btnSearchFilters.Location = new Point(429, 20);
            btnSearchFilters.Name = "btnSearchFilters";
            btnSearchFilters.Size = new Size(25, 25);
            btnSearchFilters.TabIndex = 444;
            btnSearchFilters.UseVisualStyleBackColor = true;
            // 
            // FrmMaterialReportInventory
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSearchFilters);
            Controls.Add(cboMaterialType);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(cboMaterial);
            Controls.Add(dgvQuery);
            Name = "FrmMaterialReportInventory";
            Text = "FrmMaterialReportInventory";
            Load += FrmMaterialReportInventory_Load;
            ((System.ComponentModel.ISupportInitialize)dgvQuery).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public DataGridView dgvQuery;
        public ComboBox cboMaterialType;
        private Label label5;
        private Label label2;
        public ComboBox cboMaterial;
        private Button btnSearchFilters;
    }
}