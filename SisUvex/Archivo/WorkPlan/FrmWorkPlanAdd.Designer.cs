namespace SisUvex.Archivo.WorkPlan
{
    partial class FrmWorkPlanAdd
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
            txbIdSize = new TextBox();
            cboSize = new ComboBox();
            label1 = new Label();
            lblSize = new Label();
            dtpDateWorkPlan = new DateTimePicker();
            lblVPC = new Label();
            txbVPC = new TextBox();
            dgvGTIN = new DataGridView();
            btnIdGTINSelect = new Button();
            lblWorkGroup = new Label();
            txbIdWorkGroup = new TextBox();
            cboWorkGroup = new ComboBox();
            lblLot = new Label();
            txbIdLot = new TextBox();
            cboLot = new ComboBox();
            lblIdGTIN = new Label();
            txbIdGTIN = new TextBox();
            txbId = new TextBox();
            lblTitle = new Label();
            lblId = new Label();
            lblObliId = new Label();
            label5 = new Label();
            label8 = new Label();
            label2 = new Label();
            chbLotActives = new CheckBox();
            chbSizeActives = new CheckBox();
            lblDateWorkPlan = new Label();
            label4 = new Label();
            btnAccept = new Button();
            btnCancel = new Button();
            chbActive = new CheckBox();
            label7 = new Label();
            chbWorkGroupActives = new CheckBox();
            chbGtinActives = new CheckBox();
            chbVarietyActives = new CheckBox();
            lblVariety = new Label();
            txbIdVariety = new TextBox();
            cboVariety = new ComboBox();
            chbDistributorActives = new CheckBox();
            lblDistributor = new Label();
            txbIdDistributor = new TextBox();
            cboDistributor = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvGTIN).BeginInit();
            SuspendLayout();
            // 
            // txbIdSize
            // 
            txbIdSize.Enabled = false;
            txbIdSize.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbIdSize.Location = new Point(91, 155);
            txbIdSize.Name = "txbIdSize";
            txbIdSize.Size = new Size(46, 29);
            txbIdSize.TabIndex = 167;
            txbIdSize.TextAlign = HorizontalAlignment.Center;
            // 
            // cboSize
            // 
            cboSize.DropDownHeight = 300;
            cboSize.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSize.DropDownWidth = 100;
            cboSize.Font = new Font("Segoe UI", 12F);
            cboSize.FormattingEnabled = true;
            cboSize.IntegralHeight = false;
            cboSize.ItemHeight = 21;
            cboSize.Items.AddRange(new object[] { "11", "22", "33", "44", "55", "66", "77", "88", "99" });
            cboSize.Location = new Point(143, 155);
            cboSize.Name = "cboSize";
            cboSize.Size = new Size(244, 29);
            cboSize.TabIndex = 142;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Crimson;
            label1.Location = new Point(83, 158);
            label1.Name = "label1";
            label1.Size = new Size(12, 15);
            label1.TabIndex = 168;
            label1.Text = "*";
            // 
            // lblSize
            // 
            lblSize.AutoSize = true;
            lblSize.Font = new Font("Segoe UI", 12F);
            lblSize.ForeColor = SystemColors.ControlText;
            lblSize.Location = new Point(20, 157);
            lblSize.Name = "lblSize";
            lblSize.Size = new Size(67, 21);
            lblSize.TabIndex = 164;
            lblSize.Text = "Tamaño:";
            // 
            // dtpDateWorkPlan
            // 
            dtpDateWorkPlan.Font = new Font("Segoe UI", 12F);
            dtpDateWorkPlan.Location = new Point(91, 85);
            dtpDateWorkPlan.Name = "dtpDateWorkPlan";
            dtpDateWorkPlan.Size = new Size(341, 29);
            dtpDateWorkPlan.TabIndex = 146;
            // 
            // lblVPC
            // 
            lblVPC.AutoSize = true;
            lblVPC.Font = new Font("Segoe UI", 12F);
            lblVPC.ForeColor = SystemColors.ControlDark;
            lblVPC.Location = new Point(247, 54);
            lblVPC.Name = "lblVPC";
            lblVPC.Size = new Size(119, 21);
            lblVPC.TabIndex = 162;
            lblVPC.Text = "Voice pick code:";
            // 
            // txbVPC
            // 
            txbVPC.Enabled = false;
            txbVPC.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbVPC.Location = new Point(368, 51);
            txbVPC.Name = "txbVPC";
            txbVPC.Size = new Size(64, 29);
            txbVPC.TabIndex = 163;
            txbVPC.TextAlign = HorizontalAlignment.Center;
            // 
            // dgvGTIN
            // 
            dgvGTIN.AllowUserToAddRows = false;
            dgvGTIN.AllowUserToDeleteRows = false;
            dgvGTIN.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvGTIN.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvGTIN.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvGTIN.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvGTIN.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvGTIN.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvGTIN.EnableHeadersVisualStyles = false;
            dgvGTIN.ImeMode = ImeMode.NoControl;
            dgvGTIN.Location = new Point(12, 335);
            dgvGTIN.Name = "dgvGTIN";
            dgvGTIN.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvGTIN.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvGTIN.RowHeadersVisible = false;
            dgvGTIN.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvGTIN.RowTemplate.Height = 25;
            dgvGTIN.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGTIN.Size = new Size(636, 177);
            dgvGTIN.TabIndex = 161;
            dgvGTIN.MouseDoubleClick += dgvGTIN_MouseDoubleClick;
            // 
            // btnIdGTINSelect
            // 
            btnIdGTINSelect.Location = new Point(133, 300);
            btnIdGTINSelect.Name = "btnIdGTINSelect";
            btnIdGTINSelect.Size = new Size(115, 29);
            btnIdGTINSelect.TabIndex = 144;
            btnIdGTINSelect.Text = "Seleccionar GTIN";
            btnIdGTINSelect.UseVisualStyleBackColor = true;
            btnIdGTINSelect.Click += btnIdGTINSelect_Click;
            // 
            // lblWorkGroup
            // 
            lblWorkGroup.AutoSize = true;
            lblWorkGroup.Font = new Font("Segoe UI", 12F);
            lblWorkGroup.ForeColor = SystemColors.ControlText;
            lblWorkGroup.Location = new Point(10, 123);
            lblWorkGroup.Name = "lblWorkGroup";
            lblWorkGroup.Size = new Size(75, 21);
            lblWorkGroup.TabIndex = 154;
            lblWorkGroup.Text = "Cuadrilla:";
            // 
            // txbIdWorkGroup
            // 
            txbIdWorkGroup.Enabled = false;
            txbIdWorkGroup.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbIdWorkGroup.Location = new Point(91, 120);
            txbIdWorkGroup.Name = "txbIdWorkGroup";
            txbIdWorkGroup.Size = new Size(46, 29);
            txbIdWorkGroup.TabIndex = 157;
            txbIdWorkGroup.TextAlign = HorizontalAlignment.Center;
            // 
            // cboWorkGroup
            // 
            cboWorkGroup.DropDownHeight = 300;
            cboWorkGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            cboWorkGroup.DropDownWidth = 464;
            cboWorkGroup.Font = new Font("Segoe UI", 12F);
            cboWorkGroup.FormattingEnabled = true;
            cboWorkGroup.IntegralHeight = false;
            cboWorkGroup.ItemHeight = 21;
            cboWorkGroup.Location = new Point(143, 120);
            cboWorkGroup.Name = "cboWorkGroup";
            cboWorkGroup.Size = new Size(244, 29);
            cboWorkGroup.TabIndex = 140;
            // 
            // lblLot
            // 
            lblLot.AutoSize = true;
            lblLot.Font = new Font("Segoe UI", 12F);
            lblLot.ForeColor = SystemColors.ControlText;
            lblLot.Location = new Point(10, 257);
            lblLot.Name = "lblLot";
            lblLot.Size = new Size(43, 21);
            lblLot.TabIndex = 150;
            lblLot.Text = "Lote:";
            // 
            // txbIdLot
            // 
            txbIdLot.Enabled = false;
            txbIdLot.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbIdLot.Location = new Point(62, 254);
            txbIdLot.Name = "txbIdLot";
            txbIdLot.Size = new Size(75, 29);
            txbIdLot.TabIndex = 153;
            txbIdLot.TextAlign = HorizontalAlignment.Center;
            // 
            // cboLot
            // 
            cboLot.DropDownHeight = 300;
            cboLot.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLot.DropDownWidth = 500;
            cboLot.Font = new Font("Segoe UI", 12F);
            cboLot.FormattingEnabled = true;
            cboLot.IntegralHeight = false;
            cboLot.ItemHeight = 21;
            cboLot.Location = new Point(143, 254);
            cboLot.Name = "cboLot";
            cboLot.Size = new Size(460, 29);
            cboLot.TabIndex = 141;
            // 
            // lblIdGTIN
            // 
            lblIdGTIN.AutoSize = true;
            lblIdGTIN.Font = new Font("Segoe UI", 12F);
            lblIdGTIN.Location = new Point(13, 303);
            lblIdGTIN.Name = "lblIdGTIN";
            lblIdGTIN.Size = new Size(48, 21);
            lblIdGTIN.TabIndex = 149;
            lblIdGTIN.Text = "GTIN:";
            // 
            // txbIdGTIN
            // 
            txbIdGTIN.Enabled = false;
            txbIdGTIN.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbIdGTIN.Location = new Point(67, 300);
            txbIdGTIN.MaxLength = 20;
            txbIdGTIN.Name = "txbIdGTIN";
            txbIdGTIN.ReadOnly = true;
            txbIdGTIN.Size = new Size(60, 29);
            txbIdGTIN.TabIndex = 148;
            txbIdGTIN.TextAlign = HorizontalAlignment.Center;
            // 
            // txbId
            // 
            txbId.Enabled = false;
            txbId.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbId.Location = new Point(368, 14);
            txbId.Name = "txbId";
            txbId.Size = new Size(64, 29);
            txbId.TabIndex = 143;
            txbId.TextAlign = HorizontalAlignment.Center;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial Black", 16F);
            lblTitle.Location = new Point(10, 11);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(283, 31);
            lblTitle.TabIndex = 139;
            lblTitle.Text = "Añadir plan de trabajo";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 12F);
            lblId.Location = new Point(336, 17);
            lblId.Name = "lblId";
            lblId.Size = new Size(26, 21);
            lblId.TabIndex = 145;
            lblId.Text = "Id:";
            // 
            // lblObliId
            // 
            lblObliId.AutoSize = true;
            lblObliId.ForeColor = Color.Crimson;
            lblObliId.Location = new Point(359, 14);
            lblObliId.Name = "lblObliId";
            lblObliId.Size = new Size(12, 15);
            lblObliId.TabIndex = 147;
            lblObliId.Text = "*";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.Crimson;
            label5.Location = new Point(59, 301);
            label5.Name = "label5";
            label5.Size = new Size(12, 15);
            label5.TabIndex = 158;
            label5.Text = "*";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = Color.Crimson;
            label8.Location = new Point(54, 258);
            label8.Name = "label8";
            label8.Size = new Size(12, 15);
            label8.TabIndex = 160;
            label8.Text = "*";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Crimson;
            label2.Location = new Point(83, 124);
            label2.Name = "label2";
            label2.Size = new Size(12, 15);
            label2.TabIndex = 159;
            label2.Text = "*";
            // 
            // chbLotActives
            // 
            chbLotActives.Appearance = Appearance.Button;
            chbLotActives.AutoSize = true;
            chbLotActives.BackgroundImage = Properties.Resources.Imagen6;
            chbLotActives.BackgroundImageLayout = ImageLayout.Stretch;
            chbLotActives.Font = new Font("Segoe UI", 10F);
            chbLotActives.Location = new Point(609, 254);
            chbLotActives.Name = "chbLotActives";
            chbLotActives.Size = new Size(39, 29);
            chbLotActives.TabIndex = 175;
            chbLotActives.Text = "     ";
            chbLotActives.UseVisualStyleBackColor = true;
            // 
            // chbSizeActives
            // 
            chbSizeActives.Appearance = Appearance.Button;
            chbSizeActives.AutoSize = true;
            chbSizeActives.BackgroundImage = Properties.Resources.Imagen6;
            chbSizeActives.BackgroundImageLayout = ImageLayout.Stretch;
            chbSizeActives.Font = new Font("Segoe UI", 10F);
            chbSizeActives.Location = new Point(393, 154);
            chbSizeActives.Name = "chbSizeActives";
            chbSizeActives.Size = new Size(39, 29);
            chbSizeActives.TabIndex = 177;
            chbSizeActives.Text = "     ";
            chbSizeActives.UseVisualStyleBackColor = true;
            // 
            // lblDateWorkPlan
            // 
            lblDateWorkPlan.AutoSize = true;
            lblDateWorkPlan.Font = new Font("Segoe UI", 12F);
            lblDateWorkPlan.ForeColor = SystemColors.ControlText;
            lblDateWorkPlan.Location = new Point(32, 91);
            lblDateWorkPlan.Name = "lblDateWorkPlan";
            lblDateWorkPlan.Size = new Size(53, 21);
            lblDateWorkPlan.TabIndex = 178;
            lblDateWorkPlan.Text = "Fecha:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Crimson;
            label4.Location = new Point(83, 88);
            label4.Name = "label4";
            label4.Size = new Size(12, 15);
            label4.TabIndex = 179;
            label4.Text = "*";
            // 
            // btnAccept
            // 
            btnAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAccept.Location = new Point(492, 518);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(75, 29);
            btnAccept.TabIndex = 181;
            btnAccept.Text = "Aceptar";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(573, 518);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 29);
            btnCancel.TabIndex = 180;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // chbActive
            // 
            chbActive.Appearance = Appearance.Button;
            chbActive.AutoSize = true;
            chbActive.BackColor = Color.FromArgb(255, 224, 192);
            chbActive.CheckAlign = ContentAlignment.MiddleCenter;
            chbActive.Checked = true;
            chbActive.CheckState = CheckState.Checked;
            chbActive.FlatAppearance.BorderColor = SystemColors.ActiveBorder;
            chbActive.FlatAppearance.CheckedBackColor = Color.FromArgb(192, 255, 192);
            chbActive.FlatAppearance.MouseDownBackColor = SystemColors.ActiveCaption;
            chbActive.FlatAppearance.MouseOverBackColor = SystemColors.ButtonFace;
            chbActive.FlatStyle = FlatStyle.Flat;
            chbActive.Font = new Font("Segoe UI", 12F);
            chbActive.Location = new Point(91, 48);
            chbActive.Name = "chbActive";
            chbActive.Size = new Size(63, 31);
            chbActive.TabIndex = 183;
            chbActive.Text = "Activo";
            chbActive.TextAlign = ContentAlignment.MiddleCenter;
            chbActive.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = Color.Crimson;
            label7.Location = new Point(81, 51);
            label7.Name = "label7";
            label7.Size = new Size(12, 15);
            label7.TabIndex = 182;
            label7.Text = "*";
            // 
            // chbWorkGroupActives
            // 
            chbWorkGroupActives.Appearance = Appearance.Button;
            chbWorkGroupActives.AutoSize = true;
            chbWorkGroupActives.BackgroundImage = Properties.Resources.Imagen6;
            chbWorkGroupActives.BackgroundImageLayout = ImageLayout.Stretch;
            chbWorkGroupActives.Font = new Font("Segoe UI", 10F);
            chbWorkGroupActives.Location = new Point(393, 120);
            chbWorkGroupActives.Name = "chbWorkGroupActives";
            chbWorkGroupActives.Size = new Size(39, 29);
            chbWorkGroupActives.TabIndex = 184;
            chbWorkGroupActives.Text = "     ";
            chbWorkGroupActives.UseVisualStyleBackColor = true;
            // 
            // chbGtinActives
            // 
            chbGtinActives.Appearance = Appearance.Button;
            chbGtinActives.AutoSize = true;
            chbGtinActives.BackgroundImage = Properties.Resources.Imagen6;
            chbGtinActives.BackgroundImageLayout = ImageLayout.Stretch;
            chbGtinActives.Font = new Font("Segoe UI", 10F);
            chbGtinActives.Location = new Point(254, 300);
            chbGtinActives.Name = "chbGtinActives";
            chbGtinActives.Size = new Size(39, 29);
            chbGtinActives.TabIndex = 185;
            chbGtinActives.Text = "     ";
            chbGtinActives.UseVisualStyleBackColor = true;
            // 
            // chbVarietyActives
            // 
            chbVarietyActives.Appearance = Appearance.Button;
            chbVarietyActives.AutoSize = true;
            chbVarietyActives.BackgroundImage = Properties.Resources.Imagen6;
            chbVarietyActives.BackgroundImageLayout = ImageLayout.Stretch;
            chbVarietyActives.Font = new Font("Segoe UI", 10F);
            chbVarietyActives.Location = new Point(609, 218);
            chbVarietyActives.Name = "chbVarietyActives";
            chbVarietyActives.Size = new Size(39, 29);
            chbVarietyActives.TabIndex = 190;
            chbVarietyActives.Text = "     ";
            chbVarietyActives.UseVisualStyleBackColor = true;
            // 
            // lblVariety
            // 
            lblVariety.AutoSize = true;
            lblVariety.Font = new Font("Segoe UI", 10F);
            lblVariety.ForeColor = SystemColors.Highlight;
            lblVariety.Location = new Point(20, 213);
            lblVariety.Name = "lblVariety";
            lblVariety.Size = new Size(65, 38);
            lblVariety.TabIndex = 186;
            lblVariety.Text = "Filtro por\r\nvariedad:";
            // 
            // txbIdVariety
            // 
            txbIdVariety.Enabled = false;
            txbIdVariety.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbIdVariety.ForeColor = SystemColors.ActiveCaption;
            txbIdVariety.Location = new Point(91, 218);
            txbIdVariety.Name = "txbIdVariety";
            txbIdVariety.Size = new Size(46, 29);
            txbIdVariety.TabIndex = 188;
            txbIdVariety.TextAlign = HorizontalAlignment.Center;
            // 
            // cboVariety
            // 
            cboVariety.DropDownHeight = 300;
            cboVariety.DropDownStyle = ComboBoxStyle.DropDownList;
            cboVariety.DropDownWidth = 500;
            cboVariety.Font = new Font("Segoe UI", 12F);
            cboVariety.ForeColor = SystemColors.MenuHighlight;
            cboVariety.FormattingEnabled = true;
            cboVariety.IntegralHeight = false;
            cboVariety.ItemHeight = 21;
            cboVariety.Location = new Point(143, 218);
            cboVariety.Name = "cboVariety";
            cboVariety.Size = new Size(460, 29);
            cboVariety.TabIndex = 187;
            // 
            // chbDistributorActives
            // 
            chbDistributorActives.Appearance = Appearance.Button;
            chbDistributorActives.AutoSize = true;
            chbDistributorActives.BackgroundImage = Properties.Resources.Imagen6;
            chbDistributorActives.BackgroundImageLayout = ImageLayout.Stretch;
            chbDistributorActives.Font = new Font("Segoe UI", 10F);
            chbDistributorActives.Location = new Point(609, 300);
            chbDistributorActives.Name = "chbDistributorActives";
            chbDistributorActives.Size = new Size(39, 29);
            chbDistributorActives.TabIndex = 194;
            chbDistributorActives.Text = "     ";
            chbDistributorActives.UseVisualStyleBackColor = true;
            // 
            // lblDistributor
            // 
            lblDistributor.AutoSize = true;
            lblDistributor.Font = new Font("Segoe UI", 10F);
            lblDistributor.ForeColor = SystemColors.Highlight;
            lblDistributor.Location = new Point(316, 292);
            lblDistributor.Name = "lblDistributor";
            lblDistributor.Size = new Size(82, 38);
            lblDistributor.TabIndex = 191;
            lblDistributor.Text = "Filtro por\r\ndistribuidor:";
            // 
            // txbIdDistributor
            // 
            txbIdDistributor.Enabled = false;
            txbIdDistributor.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbIdDistributor.ForeColor = SystemColors.ActiveCaption;
            txbIdDistributor.Location = new Point(404, 300);
            txbIdDistributor.Name = "txbIdDistributor";
            txbIdDistributor.Size = new Size(35, 29);
            txbIdDistributor.TabIndex = 193;
            txbIdDistributor.TextAlign = HorizontalAlignment.Center;
            // 
            // cboDistributor
            // 
            cboDistributor.DropDownHeight = 300;
            cboDistributor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDistributor.DropDownWidth = 500;
            cboDistributor.Font = new Font("Segoe UI", 12F);
            cboDistributor.ForeColor = SystemColors.MenuHighlight;
            cboDistributor.FormattingEnabled = true;
            cboDistributor.IntegralHeight = false;
            cboDistributor.ItemHeight = 21;
            cboDistributor.Location = new Point(445, 300);
            cboDistributor.Name = "cboDistributor";
            cboDistributor.Size = new Size(158, 29);
            cboDistributor.TabIndex = 192;
            // 
            // FrmWorkPlanAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(660, 555);
            Controls.Add(chbDistributorActives);
            Controls.Add(lblDistributor);
            Controls.Add(txbIdDistributor);
            Controls.Add(cboDistributor);
            Controls.Add(chbVarietyActives);
            Controls.Add(lblVariety);
            Controls.Add(txbIdVariety);
            Controls.Add(cboVariety);
            Controls.Add(chbGtinActives);
            Controls.Add(chbWorkGroupActives);
            Controls.Add(chbActive);
            Controls.Add(label7);
            Controls.Add(btnAccept);
            Controls.Add(btnCancel);
            Controls.Add(lblDateWorkPlan);
            Controls.Add(chbSizeActives);
            Controls.Add(chbLotActives);
            Controls.Add(txbIdSize);
            Controls.Add(cboSize);
            Controls.Add(label1);
            Controls.Add(lblSize);
            Controls.Add(dtpDateWorkPlan);
            Controls.Add(lblVPC);
            Controls.Add(txbVPC);
            Controls.Add(dgvGTIN);
            Controls.Add(btnIdGTINSelect);
            Controls.Add(lblWorkGroup);
            Controls.Add(txbIdWorkGroup);
            Controls.Add(cboWorkGroup);
            Controls.Add(lblLot);
            Controls.Add(txbIdLot);
            Controls.Add(cboLot);
            Controls.Add(lblIdGTIN);
            Controls.Add(txbIdGTIN);
            Controls.Add(txbId);
            Controls.Add(lblTitle);
            Controls.Add(lblId);
            Controls.Add(lblObliId);
            Controls.Add(label5);
            Controls.Add(label8);
            Controls.Add(label2);
            Controls.Add(label4);
            Name = "FrmWorkPlanAdd";
            Text = "Añadir plan de trabajo";
            Load += FrmWorkPlanAdd_Load;
            ((System.ComponentModel.ISupportInitialize)dgvGTIN).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTipoContenedor;

        public TextBox txbIdTipoContenedor;
        private ComboBox cboTipoContenedor;
        private Label lblObligatorioTipoContenedor;
        public TextBox txbIdTamaño;
        private ComboBox cboTamaño;
        private Label label1;
        private Label label9;
        public DateTimePicker dtpDateWorkPlan;
        private Label lblVPC;
        public TextBox txbVPC;
        public DataGridView dgvGTIN;
        private Button btnIdProgramaSel;
        private Label lblWorkGroup;
        public TextBox txbIdWorkGroup;
        private Label lblLot;
        public TextBox txbIdLot;
        private Label lblIdPrograma;
        public TextBox txbIdPrograma;
        public TextBox txbId;
        public Label lblTitle;
        private Label lblId;
        private Label lblObliId;
        private Label label5;
        private Label label8;
        private Label label2;
        public CheckBox chbActiveVariety;
        public CheckBox chbLotActives;
        public CheckBox checkBox2;
        public CheckBox chbSizeActives;
        private Label lblDateWorkPlan;
        private Label label4;
        public TextBox txbIdGTIN;
        private Label lblSize;
        public TextBox txbIdSize;
        public TextBox txbIdWorkPlan;
        private ComboBox cboWorkPlan;
        private Label lblIdGTIN;
        public Button btnIdGTINSelect;
        private Button btnAccept;
        private Button btnCancel;
        public ComboBox cboWorkGroup;
        public ComboBox cboLot;
        public ComboBox cboSize;
        public CheckBox chbActive;
        private Label label7;
        public CheckBox chbWorkGroupActives;
        public CheckBox chbGtinActives;
        private Label lblVariety;
        public TextBox txbIdVariety;
        public ComboBox cboVariety;
        public CheckBox chbVarietyActives;
        public CheckBox chbDistributorActives;
        private Label lblDistributor;
        public TextBox txbIdDistributor;
        public ComboBox cboDistributor;
    }
}