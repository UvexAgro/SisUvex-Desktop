namespace SisUvex.Catalogos.Lot.LotCertification
{
    partial class FrmLotCertificationAdd
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLotCertificationAdd));
            lblTitle = new Label();
            txbIdVariety = new TextBox();
            chbVarietyRemoved = new CheckBox();
            lblVariety = new Label();
            cboVariety = new ComboBox();
            lblFarm = new Label();
            txbIdFarm = new TextBox();
            cboFarm = new ComboBox();
            chbFarmRemoved = new CheckBox();
            lblLot = new Label();
            txbIdLot = new TextBox();
            cboLot = new ComboBox();
            chbLotRemoved = new CheckBox();
            lblActive = new Label();
            cboActive = new ComboBox();
            btnAccept = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial Black", 16F);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(447, 31);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Añadir lote certificado por variedad";
            // 
            // txbIdVariety
            // 
            txbIdVariety.Enabled = false;
            txbIdVariety.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbIdVariety.Location = new Point(83, 89);
            txbIdVariety.Name = "txbIdVariety";
            txbIdVariety.Size = new Size(46, 29);
            txbIdVariety.TabIndex = 2;
            txbIdVariety.TextAlign = HorizontalAlignment.Center;
            // 
            // chbVarietyRemoved
            // 
            chbVarietyRemoved.Appearance = Appearance.Button;
            chbVarietyRemoved.Font = new Font("Segoe UI", 7.8F);
            chbVarietyRemoved.ForeColor = Color.DarkGray;
            chbVarietyRemoved.Image = Properties.Resources.removedList16;
            chbVarietyRemoved.Location = new Point(592, 89);
            chbVarietyRemoved.Name = "chbVarietyRemoved";
            chbVarietyRemoved.Size = new Size(29, 29);
            chbVarietyRemoved.TabIndex = 3;
            chbVarietyRemoved.Text = "  ";
            chbVarietyRemoved.UseVisualStyleBackColor = true;
            // 
            // lblVariety
            // 
            lblVariety.AutoSize = true;
            lblVariety.Font = new Font("Segoe UI", 12F);
            lblVariety.Location = new Point(12, 92);
            lblVariety.Name = "lblVariety";
            lblVariety.Size = new Size(74, 21);
            lblVariety.TabIndex = 4;
            lblVariety.Text = "Variedad:";
            // 
            // cboVariety
            // 
            cboVariety.DropDownStyle = ComboBoxStyle.DropDownList;
            cboVariety.Font = new Font("Segoe UI", 12F);
            cboVariety.FormattingEnabled = true;
            cboVariety.ItemHeight = 21;
            cboVariety.Location = new Point(135, 89);
            cboVariety.Name = "cboVariety";
            cboVariety.Size = new Size(451, 29);
            cboVariety.TabIndex = 5;
            // 
            // lblFarm
            // 
            lblFarm.AutoSize = true;
            lblFarm.Font = new Font("Segoe UI", 12F);
            lblFarm.Location = new Point(23, 133);
            lblFarm.Name = "lblFarm";
            lblFarm.Size = new Size(63, 21);
            lblFarm.TabIndex = 6;
            lblFarm.Text = "Campo:";
            // 
            // txbIdFarm
            // 
            txbIdFarm.Enabled = false;
            txbIdFarm.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbIdFarm.Location = new Point(83, 130);
            txbIdFarm.Name = "txbIdFarm";
            txbIdFarm.Size = new Size(46, 29);
            txbIdFarm.TabIndex = 7;
            txbIdFarm.TextAlign = HorizontalAlignment.Center;
            // 
            // cboFarm
            // 
            cboFarm.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFarm.Font = new Font("Segoe UI", 12F);
            cboFarm.FormattingEnabled = true;
            cboFarm.ItemHeight = 21;
            cboFarm.Location = new Point(135, 130);
            cboFarm.Name = "cboFarm";
            cboFarm.Size = new Size(451, 29);
            cboFarm.TabIndex = 8;
            // 
            // chbFarmRemoved
            // 
            chbFarmRemoved.Appearance = Appearance.Button;
            chbFarmRemoved.Font = new Font("Segoe UI", 7.8F);
            chbFarmRemoved.ForeColor = Color.DarkGray;
            chbFarmRemoved.Image = Properties.Resources.removedList16;
            chbFarmRemoved.Location = new Point(592, 130);
            chbFarmRemoved.Name = "chbFarmRemoved";
            chbFarmRemoved.Size = new Size(29, 29);
            chbFarmRemoved.TabIndex = 9;
            chbFarmRemoved.Text = "  ";
            chbFarmRemoved.UseVisualStyleBackColor = true;
            // 
            // lblLot
            // 
            lblLot.AutoSize = true;
            lblLot.Font = new Font("Segoe UI", 12F);
            lblLot.Location = new Point(43, 174);
            lblLot.Name = "lblLot";
            lblLot.Size = new Size(43, 21);
            lblLot.TabIndex = 10;
            lblLot.Text = "Lote:";
            // 
            // txbIdLot
            // 
            txbIdLot.Enabled = false;
            txbIdLot.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbIdLot.Location = new Point(83, 171);
            txbIdLot.Name = "txbIdLot";
            txbIdLot.Size = new Size(46, 29);
            txbIdLot.TabIndex = 11;
            txbIdLot.TextAlign = HorizontalAlignment.Center;
            // 
            // cboLot
            // 
            cboLot.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLot.Font = new Font("Segoe UI", 12F);
            cboLot.FormattingEnabled = true;
            cboLot.ItemHeight = 21;
            cboLot.Location = new Point(135, 171);
            cboLot.Name = "cboLot";
            cboLot.Size = new Size(534, 29);
            cboLot.TabIndex = 12;
            // 
            // chbLotRemoved
            // 
            chbLotRemoved.Appearance = Appearance.Button;
            chbLotRemoved.Font = new Font("Segoe UI", 7.8F);
            chbLotRemoved.ForeColor = Color.DarkGray;
            chbLotRemoved.Image = Properties.Resources.removedList16;
            chbLotRemoved.Location = new Point(675, 171);
            chbLotRemoved.Name = "chbLotRemoved";
            chbLotRemoved.Size = new Size(29, 29);
            chbLotRemoved.TabIndex = 13;
            chbLotRemoved.Text = "  ";
            chbLotRemoved.UseVisualStyleBackColor = true;
            // 
            // lblActive
            // 
            lblActive.AutoSize = true;
            lblActive.Font = new Font("Segoe UI", 12F);
            lblActive.Location = new Point(30, 53);
            lblActive.Name = "lblActive";
            lblActive.Size = new Size(56, 21);
            lblActive.TabIndex = 14;
            lblActive.Text = "Activo:";
            // 
            // cboActive
            // 
            cboActive.DropDownStyle = ComboBoxStyle.DropDownList;
            cboActive.Font = new Font("Segoe UI", 12F);
            cboActive.FormattingEnabled = true;
            cboActive.Items.AddRange(new object[] { "No", "Sí" });
            cboActive.Location = new Point(83, 50);
            cboActive.Name = "cboActive";
            cboActive.Size = new Size(46, 29);
            cboActive.TabIndex = 15;
            // 
            // btnAccept
            // 
            btnAccept.Location = new Point(548, 212);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(75, 29);
            btnAccept.TabIndex = 16;
            btnAccept.Text = "Aceptar";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(629, 212);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 29);
            btnCancel.TabIndex = 17;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // FrmLotCertificationAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(715, 255);
            Controls.Add(btnCancel);
            Controls.Add(btnAccept);
            Controls.Add(cboActive);
            Controls.Add(chbLotRemoved);
            Controls.Add(cboLot);
            Controls.Add(txbIdLot);
            Controls.Add(chbFarmRemoved);
            Controls.Add(cboFarm);
            Controls.Add(txbIdFarm);
            Controls.Add(cboVariety);
            Controls.Add(chbVarietyRemoved);
            Controls.Add(txbIdVariety);
            Controls.Add(lblTitle);
            Controls.Add(lblActive);
            Controls.Add(lblLot);
            Controls.Add(lblFarm);
            Controls.Add(lblVariety);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmLotCertificationAdd";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Añadir lote certificado por variedad";
            Load += FrmLotCertificationAdd_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Label lblTitle;
        public TextBox txbIdVariety;
        public CheckBox chbVarietyRemoved;
        private Label lblVariety;
        public ComboBox cboVariety;
        private Label lblFarm;
        public TextBox txbIdFarm;
        public ComboBox cboFarm;
        public CheckBox chbFarmRemoved;
        private Label lblLot;
        public TextBox txbIdLot;
        public ComboBox cboLot;
        public CheckBox chbLotRemoved;
        private Label lblActive;
        public ComboBox cboActive;
        private Button btnAccept;
        private Button btnCancel;
    }
}

