namespace SisUvex.Grow.PlantsLotTotals
{
    partial class FrmPlantsLotTotals
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPlantsLotTotals));
            btnLoadPlantsLot = new Button();
            gpbFilters = new GroupBox();
            chbVarietyActives = new CheckBox();
            button1 = new Button();
            lblField = new Label();
            cboCrop = new ComboBox();
            cboFarm = new ComboBox();
            label11 = new Label();
            label10 = new Label();
            cboVariety = new ComboBox();
            lblTitle = new Label();
            dgvLotTotals = new DataGridView();
            gpbFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLotTotals).BeginInit();
            SuspendLayout();
            // 
            // btnLoadPlantsLot
            // 
            btnLoadPlantsLot.Font = new Font("Segoe UI", 12F);
            btnLoadPlantsLot.Image = Properties.Resources.BuscarLupa1;
            btnLoadPlantsLot.ImageAlign = ContentAlignment.MiddleRight;
            btnLoadPlantsLot.Location = new Point(725, 53);
            btnLoadPlantsLot.Name = "btnLoadPlantsLot";
            btnLoadPlantsLot.Padding = new Padding(0, 0, 4, 0);
            btnLoadPlantsLot.Size = new Size(87, 31);
            btnLoadPlantsLot.TabIndex = 69;
            btnLoadPlantsLot.Text = "Buscar";
            btnLoadPlantsLot.TextAlign = ContentAlignment.TopLeft;
            btnLoadPlantsLot.UseVisualStyleBackColor = true;
            btnLoadPlantsLot.Click += btnLoadPlantsLot_Click;
            // 
            // gpbFilters
            // 
            gpbFilters.Controls.Add(chbVarietyActives);
            gpbFilters.Controls.Add(button1);
            gpbFilters.Controls.Add(btnLoadPlantsLot);
            gpbFilters.Controls.Add(lblField);
            gpbFilters.Controls.Add(cboCrop);
            gpbFilters.Controls.Add(cboFarm);
            gpbFilters.Controls.Add(label11);
            gpbFilters.Controls.Add(label10);
            gpbFilters.Controls.Add(cboVariety);
            gpbFilters.Font = new Font("Segoe UI", 12F);
            gpbFilters.Location = new Point(12, 37);
            gpbFilters.Name = "gpbFilters";
            gpbFilters.Size = new Size(817, 90);
            gpbFilters.TabIndex = 68;
            gpbFilters.TabStop = false;
            gpbFilters.Text = "Filtros";
            // 
            // chbVarietyActives
            // 
            chbVarietyActives.Appearance = Appearance.Button;
            chbVarietyActives.BackgroundImage = Properties.Resources.Imagen6;
            chbVarietyActives.BackgroundImageLayout = ImageLayout.Stretch;
            chbVarietyActives.Font = new Font("Segoe UI", 10F);
            chbVarietyActives.Location = new Point(773, 15);
            chbVarietyActives.Name = "chbVarietyActives";
            chbVarietyActives.Size = new Size(39, 31);
            chbVarietyActives.TabIndex = 65;
            chbVarietyActives.Text = "     ";
            chbVarietyActives.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F);
            button1.Image = Properties.Resources.BuscarLupa1;
            button1.Location = new Point(742, 15);
            button1.Name = "button1";
            button1.Size = new Size(31, 31);
            button1.TabIndex = 64;
            button1.UseVisualStyleBackColor = true;
            // 
            // lblField
            // 
            lblField.AutoSize = true;
            lblField.Location = new Point(12, 57);
            lblField.Margin = new Padding(0);
            lblField.Name = "lblField";
            lblField.Size = new Size(60, 21);
            lblField.TabIndex = 22;
            lblField.Text = "Campo";
            // 
            // cboCrop
            // 
            cboCrop.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCrop.FormattingEnabled = true;
            cboCrop.Location = new Point(72, 16);
            cboCrop.Margin = new Padding(0, 3, 3, 3);
            cboCrop.Name = "cboCrop";
            cboCrop.Size = new Size(245, 29);
            cboCrop.TabIndex = 47;
            // 
            // cboFarm
            // 
            cboFarm.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFarm.FormattingEnabled = true;
            cboFarm.Location = new Point(72, 53);
            cboFarm.Margin = new Padding(0, 3, 3, 3);
            cboFarm.Name = "cboFarm";
            cboFarm.Size = new Size(245, 29);
            cboFarm.TabIndex = 24;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(13, 20);
            label11.Margin = new Padding(0);
            label11.Name = "label11";
            label11.Size = new Size(59, 21);
            label11.TabIndex = 46;
            label11.Text = "Cultivo";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(320, 19);
            label10.Margin = new Padding(0);
            label10.Name = "label10";
            label10.Size = new Size(71, 21);
            label10.TabIndex = 44;
            label10.Text = "Variedad";
            // 
            // cboVariety
            // 
            cboVariety.DropDownStyle = ComboBoxStyle.DropDownList;
            cboVariety.FormattingEnabled = true;
            cboVariety.Location = new Point(391, 16);
            cboVariety.Margin = new Padding(0, 3, 3, 3);
            cboVariety.Name = "cboVariety";
            cboVariety.Size = new Size(350, 29);
            cboVariety.TabIndex = 45;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(9, 9);
            lblTitle.Margin = new Padding(0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(302, 25);
            lblTitle.TabIndex = 70;
            lblTitle.Tag = "";
            lblTitle.Text = "Reporte total de plantas por lote";
            // 
            // dgvLotTotals
            // 
            dgvLotTotals.AllowUserToAddRows = false;
            dgvLotTotals.AllowUserToDeleteRows = false;
            dgvLotTotals.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvLotTotals.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvLotTotals.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvLotTotals.BackgroundColor = SystemColors.ButtonFace;
            dgvLotTotals.BorderStyle = BorderStyle.Fixed3D;
            dgvLotTotals.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvLotTotals.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvLotTotals.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvLotTotals.EnableHeadersVisualStyles = false;
            dgvLotTotals.ImeMode = ImeMode.NoControl;
            dgvLotTotals.Location = new Point(12, 133);
            dgvLotTotals.Name = "dgvLotTotals";
            dgvLotTotals.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvLotTotals.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvLotTotals.RowHeadersVisible = false;
            dgvLotTotals.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvLotTotals.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvLotTotals.Size = new Size(817, 313);
            dgvLotTotals.TabIndex = 73;
            // 
            // FrmPlantsLotTotals
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(839, 458);
            Controls.Add(dgvLotTotals);
            Controls.Add(lblTitle);
            Controls.Add(gpbFilters);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmPlantsLotTotals";
            Text = "Reporte total de plantas por lote";
            Load += FrmPlantsLotTotals_Load;
            gpbFilters.ResumeLayout(false);
            gpbFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLotTotals).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLoadPlantsLot;
        private GroupBox gpbFilters;
        public CheckBox chbVarietyActives;
        private Button button1;
        private Label lblField;
        public ComboBox cboCrop;
        public ComboBox cboFarm;
        private Label label11;
        private Label label10;
        public ComboBox cboVariety;
        private Label lblTitle;
        public DataGridView dgvLotTotals;
    }
}