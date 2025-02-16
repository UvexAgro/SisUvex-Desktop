namespace SisUvex.Archivo.WorkPlan
{
    partial class FrmWorkPlanCat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWorkPlanCat));
            dgvCatalog = new DataGridView();
            btnRemove = new Button();
            btnRecover = new Button();
            btnModify = new Button();
            btnAdd = new Button();
            dtpDate2 = new DateTimePicker();
            btnSearch = new Button();
            dtpDate1 = new DateTimePicker();
            chbRemoved = new CheckBox();
            label5 = new Label();
            label4 = new Label();
            cboVariety = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            cboContainer = new ComboBox();
            cboDistribuidor = new ComboBox();
            lblDistribuidor = new Label();
            label1 = new Label();
            cboPresentacion = new ComboBox();
            label6 = new Label();
            cboWorkGroup = new ComboBox();
            label7 = new Label();
            cboLot = new ComboBox();
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
            dgvCatalog.Location = new Point(9, 105);
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
            dgvCatalog.Size = new Size(783, 337);
            dgvCatalog.TabIndex = 14;
            dgvCatalog.MouseDoubleClick += dgvCatalog_MouseDoubleClick;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(231, 76);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(61, 23);
            btnRemove.TabIndex = 12;
            btnRemove.Text = "Eliminar";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnRecover
            // 
            btnRecover.Location = new Point(298, 76);
            btnRecover.Name = "btnRecover";
            btnRecover.Size = new Size(75, 23);
            btnRecover.TabIndex = 13;
            btnRecover.Text = "Recuperar";
            btnRecover.UseVisualStyleBackColor = true;
            btnRecover.Click += btnRecover_Click;
            // 
            // btnModify
            // 
            btnModify.Location = new Point(82, 75);
            btnModify.Name = "btnModify";
            btnModify.Size = new Size(67, 23);
            btnModify.TabIndex = 10;
            btnModify.Text = "Modificar";
            btnModify.UseVisualStyleBackColor = true;
            btnModify.Click += btnModify_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(9, 75);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(67, 23);
            btnAdd.TabIndex = 9;
            btnAdd.Text = "Añadir";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // dtpDate2
            // 
            dtpDate2.Format = DateTimePickerFormat.Short;
            dtpDate2.Location = new Point(38, 46);
            dtpDate2.MaxDate = new DateTime(2050, 1, 1, 0, 0, 0, 0);
            dtpDate2.MinDate = new DateTime(2010, 1, 1, 0, 0, 0, 0);
            dtpDate2.Name = "dtpDate2";
            dtpDate2.Size = new Size(95, 23);
            dtpDate2.TabIndex = 1;
            dtpDate2.Value = new DateTime(2024, 5, 16, 0, 0, 0, 0);
            // 
            // btnSearch
            // 
            btnSearch.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnSearch.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearch.Location = new Point(9, 46);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(23, 23);
            btnSearch.TabIndex = 8;
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // dtpDate1
            // 
            dtpDate1.Format = DateTimePickerFormat.Short;
            dtpDate1.Location = new Point(38, 12);
            dtpDate1.MaxDate = new DateTime(2050, 1, 1, 0, 0, 0, 0);
            dtpDate1.MinDate = new DateTime(2010, 1, 1, 0, 0, 0, 0);
            dtpDate1.Name = "dtpDate1";
            dtpDate1.Size = new Size(95, 23);
            dtpDate1.TabIndex = 0;
            dtpDate1.Value = new DateTime(2024, 5, 16, 0, 0, 0, 0);
            // 
            // chbRemoved
            // 
            chbRemoved.Appearance = Appearance.Button;
            chbRemoved.AutoSize = true;
            chbRemoved.FlatStyle = FlatStyle.System;
            chbRemoved.Location = new Point(152, 74);
            chbRemoved.Margin = new Padding(1);
            chbRemoved.Name = "chbRemoved";
            chbRemoved.Size = new Size(75, 25);
            chbRemoved.TabIndex = 11;
            chbRemoved.Text = "Eliminados";
            chbRemoved.TextAlign = ContentAlignment.MiddleCenter;
            chbRemoved.UseVisualStyleBackColor = true;
            chbRemoved.CheckedChanged += chbRemoved_CheckedChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 6.75F);
            label5.Location = new Point(38, 1);
            label5.Name = "label5";
            label5.Size = new Size(26, 12);
            label5.TabIndex = 30;
            label5.Text = "Entre";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 6.75F);
            label4.Location = new Point(41, 32);
            label4.Name = "label4";
            label4.Size = new Size(9, 12);
            label4.TabIndex = 31;
            label4.Text = "y";
            // 
            // cboVariety
            // 
            cboVariety.DropDownStyle = ComboBoxStyle.DropDownList;
            cboVariety.DropDownWidth = 400;
            cboVariety.FormattingEnabled = true;
            cboVariety.Location = new Point(139, 47);
            cboVariety.Name = "cboVariety";
            cboVariety.Size = new Size(203, 23);
            cboVariety.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 6.75F);
            label2.Location = new Point(139, 35);
            label2.Name = "label2";
            label2.Size = new Size(40, 12);
            label2.TabIndex = 38;
            label2.Text = "Variedad";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 6.75F);
            label3.Location = new Point(348, 0);
            label3.Name = "label3";
            label3.Size = new Size(52, 12);
            label3.TabIndex = 39;
            label3.Text = "Contenedor";
            // 
            // cboContainer
            // 
            cboContainer.DropDownStyle = ComboBoxStyle.DropDownList;
            cboContainer.DropDownWidth = 400;
            cboContainer.FormattingEnabled = true;
            cboContainer.Location = new Point(348, 12);
            cboContainer.Name = "cboContainer";
            cboContainer.Size = new Size(203, 23);
            cboContainer.TabIndex = 4;
            // 
            // cboDistribuidor
            // 
            cboDistribuidor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDistribuidor.DropDownWidth = 400;
            cboDistribuidor.FormattingEnabled = true;
            cboDistribuidor.Location = new Point(139, 12);
            cboDistribuidor.Name = "cboDistribuidor";
            cboDistribuidor.Size = new Size(203, 23);
            cboDistribuidor.TabIndex = 2;
            // 
            // lblDistribuidor
            // 
            lblDistribuidor.AutoSize = true;
            lblDistribuidor.Font = new Font("Segoe UI", 6.75F);
            lblDistribuidor.Location = new Point(139, 0);
            lblDistribuidor.Name = "lblDistribuidor";
            lblDistribuidor.Size = new Size(50, 12);
            lblDistribuidor.TabIndex = 34;
            lblDistribuidor.Text = "Distribuidor";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 6.75F);
            label1.Location = new Point(348, 35);
            label1.Name = "label1";
            label1.Size = new Size(56, 12);
            label1.TabIndex = 35;
            label1.Text = "Presentación";
            // 
            // cboPresentacion
            // 
            cboPresentacion.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPresentacion.DropDownWidth = 400;
            cboPresentacion.FormattingEnabled = true;
            cboPresentacion.Location = new Point(348, 47);
            cboPresentacion.Name = "cboPresentacion";
            cboPresentacion.Size = new Size(203, 23);
            cboPresentacion.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 6.75F);
            label6.Location = new Point(557, 0);
            label6.Name = "label6";
            label6.Size = new Size(40, 12);
            label6.TabIndex = 43;
            label6.Text = "Cuadrilla";
            // 
            // cboWorkGroup
            // 
            cboWorkGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            cboWorkGroup.DropDownWidth = 400;
            cboWorkGroup.FormattingEnabled = true;
            cboWorkGroup.Location = new Point(557, 12);
            cboWorkGroup.Name = "cboWorkGroup";
            cboWorkGroup.Size = new Size(203, 23);
            cboWorkGroup.TabIndex = 6;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 6.75F);
            label7.Location = new Point(557, 35);
            label7.Name = "label7";
            label7.Size = new Size(22, 12);
            label7.TabIndex = 41;
            label7.Text = "Lote";
            // 
            // cboLot
            // 
            cboLot.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLot.DropDownWidth = 400;
            cboLot.FormattingEnabled = true;
            cboLot.Location = new Point(557, 47);
            cboLot.Name = "cboLot";
            cboLot.Size = new Size(203, 23);
            cboLot.TabIndex = 7;
            // 
            // FrmWorkPlanCat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label6);
            Controls.Add(cboWorkGroup);
            Controls.Add(label7);
            Controls.Add(cboLot);
            Controls.Add(cboVariety);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(cboContainer);
            Controls.Add(cboDistribuidor);
            Controls.Add(lblDistribuidor);
            Controls.Add(label1);
            Controls.Add(cboPresentacion);
            Controls.Add(chbRemoved);
            Controls.Add(dtpDate2);
            Controls.Add(btnSearch);
            Controls.Add(dtpDate1);
            Controls.Add(dgvCatalog);
            Controls.Add(btnRemove);
            Controls.Add(btnRecover);
            Controls.Add(btnModify);
            Controls.Add(btnAdd);
            Controls.Add(label5);
            Controls.Add(label4);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmWorkPlanCat";
            Text = "Catálogo plan de trabajo";
            Load += FrmWorkPlanCat_Load;
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
        private Button btnSearch;
        public DateTimePicker dtpDate2;
        public DateTimePicker dtpDate1;
        public CheckBox chbRemoved;
        private Label label5;
        private Label label4;
        public ComboBox cboVariety;
        private Label label2;
        private Label label3;
        public ComboBox cboContainer;
        public ComboBox cboDistribuidor;
        private Label lblDistribuidor;
        private Label label1;
        public ComboBox cboPresentacion;
        private Label label6;
        public ComboBox cboWorkGroup;
        private Label label7;
        public ComboBox cboLot;
    }
}