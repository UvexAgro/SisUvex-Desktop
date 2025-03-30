namespace SisUvex.Material.MaterialProvider
{
    partial class FrmMaterialProviderCat
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
            btnRemoved = new Button();
            dgvCatalog = new DataGridView();
            btnRemove = new Button();
            btnRecover = new Button();
            btnModify = new Button();
            btnAdd = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCatalog).BeginInit();
            SuspendLayout();
            // 
            // btnRemoved
            // 
            btnRemoved.Location = new Point(174, 12);
            btnRemoved.Name = "btnRemoved";
            btnRemoved.Size = new Size(75, 23);
            btnRemoved.TabIndex = 14;
            btnRemoved.Text = "Eliminados";
            btnRemoved.UseVisualStyleBackColor = true;
            btnRemoved.Click += btnRemoved_Click;
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
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvCatalog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvCatalog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvCatalog.EnableHeadersVisualStyles = false;
            dgvCatalog.ImeMode = ImeMode.NoControl;
            dgvCatalog.Location = new Point(12, 41);
            dgvCatalog.Name = "dgvCatalog";
            dgvCatalog.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvCatalog.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvCatalog.RowHeadersVisible = false;
            dgvCatalog.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvCatalog.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCatalog.Size = new Size(776, 395);
            dgvCatalog.TabIndex = 17;
            dgvCatalog.CellMouseDoubleClick += dgvCatalog_CellMouseDoubleClick;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(255, 12);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(75, 23);
            btnRemove.TabIndex = 15;
            btnRemove.Text = "Eliminar";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnRecover
            // 
            btnRecover.Location = new Point(336, 12);
            btnRecover.Name = "btnRecover";
            btnRecover.Size = new Size(75, 23);
            btnRecover.TabIndex = 16;
            btnRecover.Text = "Recuperar";
            btnRecover.UseVisualStyleBackColor = true;
            btnRecover.Click += btnRecover_Click;
            // 
            // btnModify
            // 
            btnModify.Location = new Point(93, 12);
            btnModify.Name = "btnModify";
            btnModify.Size = new Size(75, 23);
            btnModify.TabIndex = 13;
            btnModify.Text = "Modificar";
            btnModify.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(12, 12);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 12;
            btnAdd.Text = "Añadir";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // FrmMaterialProviderCat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRemoved);
            Controls.Add(dgvCatalog);
            Controls.Add(btnRemove);
            Controls.Add(btnRecover);
            Controls.Add(btnModify);
            Controls.Add(btnAdd);
            Name = "FrmMaterialProviderCat";
            Text = "FrmMaterialProviderCat";
            Load += FrmMaterialProviderCat_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCatalog).EndInit();
            ResumeLayout(false);
        }

        #endregion

        public Button btnRemoved;
        public DataGridView dgvCatalog;
        private Button btnRemove;
        private Button btnRecover;
        private Button btnModify;
        private Button btnAdd;
    }
}