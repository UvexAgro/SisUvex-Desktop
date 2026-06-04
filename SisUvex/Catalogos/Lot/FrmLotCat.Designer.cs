namespace SisUvex.Catalogos.Lot
{
    partial class FrmLotCat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLotCat));
            btnRemove = new Button();
            btnRecover = new Button();
            dgvCatalog = new DataGridView();
            btnModify = new Button();
            btnAdd = new Button();
            label2 = new Label();
            cboVariety = new ComboBox();
            chbRemovedVariety = new CheckBox();
            chbRemoved = new CheckBox();
            btnOpenLotCertification = new Button();
            label1 = new Label();
            cboFarm = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvCatalog).BeginInit();
            SuspendLayout();
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(255, 53);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(75, 23);
            btnRemove.TabIndex = 3;
            btnRemove.Text = "Eliminar";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnRecover
            // 
            btnRecover.Location = new Point(336, 53);
            btnRecover.Name = "btnRecover";
            btnRecover.Size = new Size(75, 23);
            btnRecover.TabIndex = 4;
            btnRecover.Text = "Recuperar";
            btnRecover.UseVisualStyleBackColor = true;
            btnRecover.Click += btnRecover_Click;
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
            dgvCatalog.Location = new Point(12, 82);
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
            dgvCatalog.Size = new Size(1131, 356);
            dgvCatalog.TabIndex = 7;
            // 
            // btnModify
            // 
            btnModify.Location = new Point(93, 53);
            btnModify.Name = "btnModify";
            btnModify.Size = new Size(75, 23);
            btnModify.TabIndex = 1;
            btnModify.Text = "Modificar";
            btnModify.UseVisualStyleBackColor = true;
            btnModify.Click += btnModify_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(12, 53);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Añadir";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 6.75F);
            label2.Location = new Point(11, 2);
            label2.Name = "label2";
            label2.Size = new Size(40, 12);
            label2.TabIndex = 66;
            label2.Text = "Variedad";
            // 
            // cboVariety
            // 
            cboVariety.DropDownStyle = ComboBoxStyle.DropDownList;
            cboVariety.Font = new Font("Segoe UI", 8F);
            cboVariety.FormattingEnabled = true;
            cboVariety.Location = new Point(12, 14);
            cboVariety.Name = "cboVariety";
            cboVariety.Size = new Size(203, 21);
            cboVariety.TabIndex = 5;
            cboVariety.SelectedIndexChanged += cboVariety_SelectedIndexChanged;
            // 
            // chbRemovedVariety
            // 
            chbRemovedVariety.Appearance = Appearance.Button;
            chbRemovedVariety.AutoSize = true;
            chbRemovedVariety.Font = new Font("Segoe UI", 7.8F);
            chbRemovedVariety.ForeColor = Color.DarkGray;
            chbRemovedVariety.Image = Properties.Resources.removedList16;
            chbRemovedVariety.Location = new Point(215, 13);
            chbRemovedVariety.Name = "chbRemovedVariety";
            chbRemovedVariety.Size = new Size(23, 23);
            chbRemovedVariety.TabIndex = 6;
            chbRemovedVariety.Text = "  ";
            chbRemovedVariety.UseVisualStyleBackColor = true;
            // 
            // chbRemoved
            // 
            chbRemoved.Appearance = Appearance.Button;
            chbRemoved.Location = new Point(174, 53);
            chbRemoved.Name = "chbRemoved";
            chbRemoved.Size = new Size(75, 23);
            chbRemoved.TabIndex = 2;
            chbRemoved.Text = "Eliminados";
            chbRemoved.UseVisualStyleBackColor = true;
            chbRemoved.CheckedChanged += chbRemoved_CheckedChanged;
            // 
            // btnOpenLotCertification
            // 
            btnOpenLotCertification.Location = new Point(488, 12);
            btnOpenLotCertification.Name = "btnOpenLotCertification";
            btnOpenLotCertification.Size = new Size(117, 23);
            btnOpenLotCertification.TabIndex = 67;
            btnOpenLotCertification.Text = "Lotes certificados";
            btnOpenLotCertification.UseVisualStyleBackColor = true;
            btnOpenLotCertification.Click += btnOpenLotCertification_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 6.75F);
            label1.Location = new Point(254, 2);
            label1.Name = "label1";
            label1.Size = new Size(34, 12);
            label1.TabIndex = 69;
            label1.Text = "Campo";
            // 
            // cboFarm
            // 
            cboFarm.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFarm.Font = new Font("Segoe UI", 8F);
            cboFarm.FormattingEnabled = true;
            cboFarm.Location = new Point(255, 14);
            cboFarm.Name = "cboFarm";
            cboFarm.Size = new Size(203, 21);
            cboFarm.TabIndex = 68;
            // 
            // FrmLotCat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1155, 450);
            Controls.Add(label1);
            Controls.Add(cboFarm);
            Controls.Add(btnOpenLotCertification);
            Controls.Add(chbRemoved);
            Controls.Add(chbRemovedVariety);
            Controls.Add(label2);
            Controls.Add(cboVariety);
            Controls.Add(btnRemove);
            Controls.Add(btnRecover);
            Controls.Add(dgvCatalog);
            Controls.Add(btnModify);
            Controls.Add(btnAdd);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmLotCat";
            Text = "Catálogo de lotes";
            WindowState = FormWindowState.Maximized;
            Load += FrmLotCat_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCatalog).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnRemove;
        private Button btnRecover;
        public DataGridView dgvCatalog;
        private Button btnModify;
        private Button btnAdd;
        private Label label2;
        public ComboBox cboVariety;
        public CheckBox chbRemovedVariety;
        public CheckBox chbRemoved;
        private Button btnOpenLotCertification;
        private Label label1;
        public ComboBox cboFarm;
    }
}