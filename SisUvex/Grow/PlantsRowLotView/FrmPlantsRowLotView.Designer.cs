namespace SisUvex.Grow.PlantsRowLot
{
    partial class FrmPlantsRowLotView
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
            label9 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            cboLot = new ComboBox();
            label1 = new Label();
            cboFarm = new ComboBox();
            lblField = new Label();
            cboVariety = new ComboBox();
            label10 = new Label();
            cboCrop = new ComboBox();
            label11 = new Label();
            label12 = new Label();
            gpbFilters = new GroupBox();
            chbLotActives = new CheckBox();
            chbVarietyActives = new CheckBox();
            button1 = new Button();
            button2 = new Button();
            bgpLotInfo = new GroupBox();
            lblFinal = new Label();
            lblStart = new Label();
            label17 = new Label();
            label18 = new Label();
            lblFormation = new Label();
            label15 = new Label();
            lblUserUpdate = new Label();
            lblPlantsFail = new Label();
            lblPlantsTotal = new Label();
            lblLastUpdate = new Label();
            lblPlantsEfective = new Label();
            lblIdLot = new Label();
            lblNameLot = new Label();
            label8 = new Label();
            label7 = new Label();
            label13 = new Label();
            lblTitle = new Label();
            btnExcel = new Button();
            btnLoadPlantsLot = new Button();
            chbShowOrHideColumns = new CheckBox();
            dgvPlants = new DataGridView();
            gpbFilters.SuspendLayout();
            bgpLotInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPlants).BeginInit();
            SuspendLayout();
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F);
            label9.Location = new Point(530, 25);
            label9.Margin = new Padding(0);
            label9.Name = "label9";
            label9.Size = new Size(152, 21);
            label9.TabIndex = 42;
            label9.Text = "Última actualización:";
            label9.TextAlign = ContentAlignment.TopRight;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(388, 88);
            label5.Margin = new Padding(0);
            label5.Name = "label5";
            label5.Size = new Size(51, 21);
            label5.TabIndex = 34;
            label5.Text = "Fallas:";
            label5.TextAlign = ContentAlignment.TopRight;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(312, 25);
            label4.Margin = new Padding(0);
            label4.Name = "label4";
            label4.Size = new Size(127, 21);
            label4.TabIndex = 32;
            label4.Text = "Plantas efectivas:";
            label4.TextAlign = ContentAlignment.TopRight;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(326, 55);
            label3.Margin = new Padding(0);
            label3.Name = "label3";
            label3.Size = new Size(113, 21);
            label3.TabIndex = 30;
            label3.Text = "Plantas totales:";
            label3.TextAlign = ContentAlignment.TopRight;
            // 
            // cboLot
            // 
            cboLot.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLot.FlatStyle = FlatStyle.System;
            cboLot.FormattingEnabled = true;
            cboLot.Location = new Point(391, 59);
            cboLot.Margin = new Padding(0, 3, 3, 3);
            cboLot.Name = "cboLot";
            cboLot.Size = new Size(350, 29);
            cboLot.TabIndex = 27;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(351, 63);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(40, 21);
            label1.TabIndex = 26;
            label1.Text = "Lote";
            // 
            // cboFarm
            // 
            cboFarm.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFarm.FormattingEnabled = true;
            cboFarm.Location = new Point(72, 59);
            cboFarm.Margin = new Padding(0, 3, 3, 3);
            cboFarm.Name = "cboFarm";
            cboFarm.Size = new Size(245, 29);
            cboFarm.TabIndex = 24;
            cboFarm.SelectedIndexChanged += cboField_SelectedIndexChanged;
            // 
            // lblField
            // 
            lblField.AutoSize = true;
            lblField.Location = new Point(12, 63);
            lblField.Margin = new Padding(0);
            lblField.Name = "lblField";
            lblField.Size = new Size(60, 21);
            lblField.TabIndex = 22;
            lblField.Text = "Campo";
            // 
            // cboVariety
            // 
            cboVariety.DropDownStyle = ComboBoxStyle.DropDownList;
            cboVariety.FormattingEnabled = true;
            cboVariety.Location = new Point(391, 21);
            cboVariety.Margin = new Padding(0, 3, 3, 3);
            cboVariety.Name = "cboVariety";
            cboVariety.Size = new Size(350, 29);
            cboVariety.TabIndex = 45;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(320, 25);
            label10.Margin = new Padding(0);
            label10.Name = "label10";
            label10.Size = new Size(71, 21);
            label10.TabIndex = 44;
            label10.Text = "Variedad";
            // 
            // cboCrop
            // 
            cboCrop.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCrop.FormattingEnabled = true;
            cboCrop.Location = new Point(72, 22);
            cboCrop.Margin = new Padding(0, 3, 3, 3);
            cboCrop.Name = "cboCrop";
            cboCrop.Size = new Size(245, 29);
            cboCrop.TabIndex = 47;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(13, 26);
            label11.Margin = new Padding(0);
            label11.Name = "label11";
            label11.Size = new Size(59, 21);
            label11.TabIndex = 46;
            label11.Text = "Cultivo";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F);
            label12.Location = new Point(606, 55);
            label12.Margin = new Padding(0);
            label12.Name = "label12";
            label12.Size = new Size(76, 21);
            label12.TabIndex = 49;
            label12.Text = "Actualizó:";
            label12.TextAlign = ContentAlignment.TopRight;
            // 
            // gpbFilters
            // 
            gpbFilters.Controls.Add(chbLotActives);
            gpbFilters.Controls.Add(chbVarietyActives);
            gpbFilters.Controls.Add(button1);
            gpbFilters.Controls.Add(button2);
            gpbFilters.Controls.Add(lblField);
            gpbFilters.Controls.Add(label1);
            gpbFilters.Controls.Add(cboCrop);
            gpbFilters.Controls.Add(cboFarm);
            gpbFilters.Controls.Add(cboLot);
            gpbFilters.Controls.Add(label11);
            gpbFilters.Controls.Add(label10);
            gpbFilters.Controls.Add(cboVariety);
            gpbFilters.Font = new Font("Segoe UI", 12F);
            gpbFilters.Location = new Point(12, 37);
            gpbFilters.Name = "gpbFilters";
            gpbFilters.Size = new Size(820, 100);
            gpbFilters.TabIndex = 50;
            gpbFilters.TabStop = false;
            gpbFilters.Text = "Filtros";
            // 
            // chbLotActives
            // 
            chbLotActives.Appearance = Appearance.Button;
            chbLotActives.BackgroundImage = Properties.Resources.Imagen6;
            chbLotActives.BackgroundImageLayout = ImageLayout.Stretch;
            chbLotActives.Font = new Font("Segoe UI", 10F);
            chbLotActives.Location = new Point(773, 58);
            chbLotActives.Name = "chbLotActives";
            chbLotActives.Size = new Size(39, 31);
            chbLotActives.TabIndex = 66;
            chbLotActives.Text = "     ";
            chbLotActives.UseVisualStyleBackColor = true;
            // 
            // chbVarietyActives
            // 
            chbVarietyActives.Appearance = Appearance.Button;
            chbVarietyActives.BackgroundImage = Properties.Resources.Imagen6;
            chbVarietyActives.BackgroundImageLayout = ImageLayout.Stretch;
            chbVarietyActives.Font = new Font("Segoe UI", 10F);
            chbVarietyActives.Location = new Point(773, 20);
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
            button1.Location = new Point(742, 20);
            button1.Name = "button1";
            button1.Size = new Size(31, 31);
            button1.TabIndex = 64;
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 12F);
            button2.Image = Properties.Resources.BuscarLupa1;
            button2.Location = new Point(742, 58);
            button2.Name = "button2";
            button2.Size = new Size(31, 31);
            button2.TabIndex = 63;
            button2.UseVisualStyleBackColor = true;
            // 
            // bgpLotInfo
            // 
            bgpLotInfo.Controls.Add(lblFinal);
            bgpLotInfo.Controls.Add(lblStart);
            bgpLotInfo.Controls.Add(label17);
            bgpLotInfo.Controls.Add(label18);
            bgpLotInfo.Controls.Add(lblFormation);
            bgpLotInfo.Controls.Add(label15);
            bgpLotInfo.Controls.Add(lblUserUpdate);
            bgpLotInfo.Controls.Add(lblPlantsFail);
            bgpLotInfo.Controls.Add(lblPlantsTotal);
            bgpLotInfo.Controls.Add(lblLastUpdate);
            bgpLotInfo.Controls.Add(lblPlantsEfective);
            bgpLotInfo.Controls.Add(lblIdLot);
            bgpLotInfo.Controls.Add(lblNameLot);
            bgpLotInfo.Controls.Add(label8);
            bgpLotInfo.Controls.Add(label7);
            bgpLotInfo.Controls.Add(label3);
            bgpLotInfo.Controls.Add(label9);
            bgpLotInfo.Controls.Add(label12);
            bgpLotInfo.Controls.Add(label4);
            bgpLotInfo.Controls.Add(label5);
            bgpLotInfo.Font = new Font("Segoe UI", 12F);
            bgpLotInfo.Location = new Point(12, 170);
            bgpLotInfo.Name = "bgpLotInfo";
            bgpLotInfo.Size = new Size(820, 156);
            bgpLotInfo.TabIndex = 51;
            bgpLotInfo.TabStop = false;
            bgpLotInfo.Text = "Datos del lote";
            // 
            // lblFinal
            // 
            lblFinal.AutoSize = true;
            lblFinal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblFinal.Location = new Point(78, 118);
            lblFinal.Margin = new Padding(0);
            lblFinal.Name = "lblFinal";
            lblFinal.Size = new Size(67, 21);
            lblFinal.TabIndex = 66;
            lblFinal.Tag = "lotData";
            lblFinal.Text = "lblFinal";
            // 
            // lblStart
            // 
            lblStart.AutoSize = true;
            lblStart.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblStart.Location = new Point(78, 88);
            lblStart.Margin = new Padding(0);
            lblStart.Name = "lblStart";
            lblStart.Size = new Size(66, 21);
            lblStart.TabIndex = 65;
            lblStart.Tag = "lotData";
            lblStart.Text = "lblStart";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(32, 118);
            label17.Margin = new Padding(0);
            label17.Name = "label17";
            label17.Size = new Size(46, 21);
            label17.TabIndex = 64;
            label17.Text = "Final:";
            label17.TextAlign = ContentAlignment.TopRight;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(25, 88);
            label18.Margin = new Padding(0);
            label18.Name = "label18";
            label18.Size = new Size(53, 21);
            label18.TabIndex = 63;
            label18.Text = "Inicial:";
            label18.TextAlign = ContentAlignment.TopRight;
            // 
            // lblFormation
            // 
            lblFormation.AutoSize = true;
            lblFormation.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblFormation.Location = new Point(439, 121);
            lblFormation.Margin = new Padding(0);
            lblFormation.Name = "lblFormation";
            lblFormation.Size = new Size(109, 21);
            lblFormation.TabIndex = 62;
            lblFormation.Tag = "lotData";
            lblFormation.Text = "lblFormation";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(351, 121);
            label15.Margin = new Padding(0);
            label15.Name = "label15";
            label15.Size = new Size(87, 21);
            label15.TabIndex = 61;
            label15.Text = "Formación:";
            label15.TextAlign = ContentAlignment.TopRight;
            // 
            // lblUserUpdate
            // 
            lblUserUpdate.AutoSize = true;
            lblUserUpdate.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblUserUpdate.Location = new Point(682, 55);
            lblUserUpdate.Margin = new Padding(0);
            lblUserUpdate.Name = "lblUserUpdate";
            lblUserUpdate.Size = new Size(120, 21);
            lblUserUpdate.TabIndex = 60;
            lblUserUpdate.Tag = "lotData";
            lblUserUpdate.Text = "lblUserUpdate";
            // 
            // lblPlantsFail
            // 
            lblPlantsFail.AutoSize = true;
            lblPlantsFail.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblPlantsFail.Location = new Point(439, 88);
            lblPlantsFail.Margin = new Padding(0);
            lblPlantsFail.Name = "lblPlantsFail";
            lblPlantsFail.Size = new Size(57, 21);
            lblPlantsFail.TabIndex = 58;
            lblPlantsFail.Tag = "lotData";
            lblPlantsFail.Text = "lblFail";
            // 
            // lblPlantsTotal
            // 
            lblPlantsTotal.AutoSize = true;
            lblPlantsTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblPlantsTotal.Location = new Point(439, 55);
            lblPlantsTotal.Margin = new Padding(0);
            lblPlantsTotal.Name = "lblPlantsTotal";
            lblPlantsTotal.Size = new Size(68, 21);
            lblPlantsTotal.TabIndex = 57;
            lblPlantsTotal.Tag = "lotData";
            lblPlantsTotal.Text = "lblTotal";
            // 
            // lblLastUpdate
            // 
            lblLastUpdate.AutoSize = true;
            lblLastUpdate.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblLastUpdate.Location = new Point(682, 25);
            lblLastUpdate.Margin = new Padding(0);
            lblLastUpdate.Name = "lblLastUpdate";
            lblLastUpdate.Size = new Size(116, 21);
            lblLastUpdate.TabIndex = 59;
            lblLastUpdate.Tag = "lotData";
            lblLastUpdate.Text = "lblLastUpdate";
            // 
            // lblPlantsEfective
            // 
            lblPlantsEfective.AutoSize = true;
            lblPlantsEfective.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblPlantsEfective.Location = new Point(439, 25);
            lblPlantsEfective.Margin = new Padding(0);
            lblPlantsEfective.Name = "lblPlantsEfective";
            lblPlantsEfective.Size = new Size(91, 21);
            lblPlantsEfective.TabIndex = 56;
            lblPlantsEfective.Tag = "lotData";
            lblPlantsEfective.Text = "lblEfective";
            // 
            // lblIdLot
            // 
            lblIdLot.AutoSize = true;
            lblIdLot.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblIdLot.Location = new Point(78, 55);
            lblIdLot.Margin = new Padding(0);
            lblIdLot.Name = "lblIdLot";
            lblIdLot.Size = new Size(69, 21);
            lblIdLot.TabIndex = 55;
            lblIdLot.Tag = "lotData";
            lblIdLot.Text = "lblIdLot";
            // 
            // lblNameLot
            // 
            lblNameLot.AutoSize = true;
            lblNameLot.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblNameLot.Location = new Point(78, 25);
            lblNameLot.Margin = new Padding(0);
            lblNameLot.Name = "lblNameLot";
            lblNameLot.Size = new Size(100, 21);
            lblNameLot.TabIndex = 54;
            lblNameLot.Tag = "lotData";
            lblNameLot.Text = "lblNameLot";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(15, 55);
            label8.Margin = new Padding(0);
            label8.Name = "label8";
            label8.Size = new Size(63, 21);
            label8.TabIndex = 53;
            label8.Text = "Código:";
            label8.TextAlign = ContentAlignment.TopRight;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(7, 25);
            label7.Margin = new Padding(0);
            label7.Name = "label7";
            label7.Size = new Size(71, 21);
            label7.TabIndex = 52;
            label7.Text = "Nombre:";
            label7.TextAlign = ContentAlignment.TopRight;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F);
            label13.Location = new Point(12, 329);
            label13.Name = "label13";
            label13.Size = new Size(109, 21);
            label13.TabIndex = 61;
            label13.Text = "Líneas del lote";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Margin = new Padding(0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(215, 25);
            lblTitle.TabIndex = 61;
            lblTitle.Tag = "";
            lblTitle.Text = "Reporte líneas por lote";
            // 
            // btnExcel
            // 
            btnExcel.Font = new Font("Segoe UI", 12F);
            btnExcel.Image = Properties.Resources.excelIcon16;
            btnExcel.Location = new Point(127, 327);
            btnExcel.Name = "btnExcel";
            btnExcel.Padding = new Padding(0, 0, 1, 0);
            btnExcel.Size = new Size(23, 23);
            btnExcel.TabIndex = 62;
            btnExcel.UseVisualStyleBackColor = true;
            btnExcel.Click += btnExcel_Click;
            // 
            // btnLoadPlantsLot
            // 
            btnLoadPlantsLot.Font = new Font("Segoe UI", 12F);
            btnLoadPlantsLot.Image = Properties.Resources.BuscarLupa1;
            btnLoadPlantsLot.ImageAlign = ContentAlignment.MiddleRight;
            btnLoadPlantsLot.Location = new Point(745, 143);
            btnLoadPlantsLot.Name = "btnLoadPlantsLot";
            btnLoadPlantsLot.Padding = new Padding(0, 0, 4, 0);
            btnLoadPlantsLot.Size = new Size(87, 31);
            btnLoadPlantsLot.TabIndex = 67;
            btnLoadPlantsLot.Text = "Buscar";
            btnLoadPlantsLot.TextAlign = ContentAlignment.TopLeft;
            btnLoadPlantsLot.UseVisualStyleBackColor = true;
            btnLoadPlantsLot.Click += btnLoadPlantsLot_Click;
            // 
            // chbShowOrHideColumns
            // 
            chbShowOrHideColumns.AutoSize = true;
            chbShowOrHideColumns.BackColor = Color.Transparent;
            chbShowOrHideColumns.CheckAlign = ContentAlignment.MiddleRight;
            chbShowOrHideColumns.Location = new Point(670, 337);
            chbShowOrHideColumns.Margin = new Padding(0);
            chbShowOrHideColumns.Name = "chbShowOrHideColumns";
            chbShowOrHideColumns.Size = new Size(163, 19);
            chbShowOrHideColumns.TabIndex = 68;
            chbShowOrHideColumns.Text = "Mostrar columnas ocultas";
            chbShowOrHideColumns.TextAlign = ContentAlignment.TopRight;
            chbShowOrHideColumns.UseVisualStyleBackColor = false;
            chbShowOrHideColumns.CheckedChanged += chbHideOrShowColumns_CheckedChanged;
            // 
            // dgvPlants
            // 
            dgvPlants.AllowUserToAddRows = false;
            dgvPlants.AllowUserToDeleteRows = false;
            dgvPlants.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPlants.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvPlants.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvPlants.BackgroundColor = SystemColors.ButtonFace;
            dgvPlants.BorderStyle = BorderStyle.Fixed3D;
            dgvPlants.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvPlants.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvPlants.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvPlants.EnableHeadersVisualStyles = false;
            dgvPlants.ImeMode = ImeMode.NoControl;
            dgvPlants.Location = new Point(12, 353);
            dgvPlants.Name = "dgvPlants";
            dgvPlants.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvPlants.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvPlants.RowHeadersVisible = false;
            dgvPlants.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvPlants.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPlants.Size = new Size(819, 194);
            dgvPlants.TabIndex = 69;
            // 
            // FrmPlantsRowLotView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(843, 559);
            Controls.Add(dgvPlants);
            Controls.Add(btnLoadPlantsLot);
            Controls.Add(btnExcel);
            Controls.Add(lblTitle);
            Controls.Add(label13);
            Controls.Add(bgpLotInfo);
            Controls.Add(gpbFilters);
            Controls.Add(chbShowOrHideColumns);
            Name = "FrmPlantsRowLotView";
            Text = "FrmPlantsRowLotView";
            Load += FrmPlantsRowLotView_Load;
            gpbFilters.ResumeLayout(false);
            gpbFilters.PerformLayout();
            bgpLotInfo.ResumeLayout(false);
            bgpLotInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPlants).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label9;
        private TextBox textBox8;
        private Label label6;
        private TextBox textBox5;
        private Label label5;
        private TextBox textBox4;
        private Label label4;
        private TextBox textBox3;
        private Label label3;
        private TextBox textBox2;
        private Label label2;
        private Label label1;
        private TextBox textBox1;
        private Label lblField;
        private Label label10;
        private Label label11;
        private Button button1;
        private Label label12;
        private TextBox textBox9;
        private GroupBox gpbFilters;
        private GroupBox bgpLotInfo;
        private Label label8;
        private Label label7;
        private Label label13;
        private Label lblTitle;
        private Button btnExcel;
        public Label lblIdLot;
        public Label lblUserUpdate;
        public Label lblLastUpdate;
        public Label lblPlantsFail;
        public Label lblPlantsTotal;
        public Label lblPlantsEfective;
        public ComboBox cboLot;
        public ComboBox cboFarm;
        public ComboBox cboVariety;
        public ComboBox cboCrop;
        public Label lblNameLot;
        private Button button2;
        public CheckBox chbLotActives;
        public CheckBox chbVarietyActives;
        private Button btnLoadPlantsLot;
        public Label lblFinal;
        public Label lblStart;
        private Label label17;
        private Label label18;
        public Label lblFormation;
        private Label label15;
        public CheckBox chbShowOrHideColumns;
        public DataGridView dgvPlants;
    }
}