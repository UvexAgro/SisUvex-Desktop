namespace SisUvex.Catalogos.CONTRATO.SeasonActivities
{
    partial class FrmSeasonActivitiesAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSeasonActivitiesAdd));
            txbName = new TextBox();
            btnAccept = new Button();
            btnCancel = new Button();
            txbId = new TextBox();
            lblTitle = new Label();
            lblObliName = new Label();
            lblName = new Label();
            lblId = new Label();
            txbIdSeason = new TextBox();
            cboSeason = new ComboBox();
            lblSeason = new Label();
            lblObliSeason = new Label();
            txbIdUnit = new TextBox();
            cboUnit = new ComboBox();
            lblUnit = new Label();
            lblObliUnit = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // txbName
            // 
            txbName.Font = new Font("Segoe UI", 12F);
            txbName.Location = new Point(171, 81);
            txbName.MaxLength = 25;
            txbName.Name = "txbName";
            txbName.Size = new Size(355, 29);
            txbName.TabIndex = 1;
            // 
            // btnAccept
            // 
            btnAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAccept.Location = new Point(370, 198);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(75, 29);
            btnAccept.TabIndex = 6;
            btnAccept.Text = "Aceptar";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(451, 198);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 29);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // txbId
            // 
            txbId.Enabled = false;
            txbId.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbId.Location = new Point(171, 46);
            txbId.Name = "txbId";
            txbId.Size = new Size(63, 29);
            txbId.TabIndex = 0;
            txbId.TextAlign = HorizontalAlignment.Center;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial Black", 16F);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(388, 31);
            lblTitle.TabIndex = 39;
            lblTitle.Text = "Añadir actividad de temporada";
            // 
            // lblObliName
            // 
            lblObliName.AutoSize = true;
            lblObliName.ForeColor = Color.Crimson;
            lblObliName.Location = new Point(161, 84);
            lblObliName.Name = "lblObliName";
            lblObliName.Size = new Size(12, 15);
            lblObliName.TabIndex = 49;
            lblObliName.Text = "*";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 12F);
            lblName.Location = new Point(94, 84);
            lblName.Name = "lblName";
            lblName.Size = new Size(71, 21);
            lblName.TabIndex = 51;
            lblName.Text = "Nombre:";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 12F);
            lblId.Location = new Point(15, 49);
            lblId.Name = "lblId";
            lblId.Size = new Size(150, 21);
            lblId.TabIndex = 47;
            lblId.Text = "Código de actividad:";
            // 
            // txbIdSeason
            // 
            txbIdSeason.Enabled = false;
            txbIdSeason.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbIdSeason.Location = new Point(119, 116);
            txbIdSeason.Name = "txbIdSeason";
            txbIdSeason.Size = new Size(46, 29);
            txbIdSeason.TabIndex = 2;
            txbIdSeason.TextAlign = HorizontalAlignment.Center;
            // 
            // cboSeason
            // 
            cboSeason.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSeason.Font = new Font("Segoe UI", 12F);
            cboSeason.FormattingEnabled = true;
            cboSeason.ItemHeight = 21;
            cboSeason.Location = new Point(171, 116);
            cboSeason.Name = "cboSeason";
            cboSeason.Size = new Size(355, 29);
            cboSeason.TabIndex = 3;
            // 
            // lblSeason
            // 
            lblSeason.AutoSize = true;
            lblSeason.Font = new Font("Segoe UI", 12F);
            lblSeason.Location = new Point(26, 119);
            lblSeason.Name = "lblSeason";
            lblSeason.Size = new Size(90, 21);
            lblSeason.TabIndex = 41;
            lblSeason.Text = "Temporada:";
            // 
            // lblObliSeason
            // 
            lblObliSeason.AutoSize = true;
            lblObliSeason.ForeColor = Color.Crimson;
            lblObliSeason.Location = new Point(110, 119);
            lblObliSeason.Name = "lblObliSeason";
            lblObliSeason.Size = new Size(12, 15);
            lblObliSeason.TabIndex = 50;
            lblObliSeason.Text = "*";
            // 
            // txbIdUnit
            // 
            txbIdUnit.Enabled = false;
            txbIdUnit.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbIdUnit.Location = new Point(119, 151);
            txbIdUnit.Name = "txbIdUnit";
            txbIdUnit.Size = new Size(46, 29);
            txbIdUnit.TabIndex = 4;
            txbIdUnit.TextAlign = HorizontalAlignment.Center;
            // 
            // cboUnit
            // 
            cboUnit.DropDownStyle = ComboBoxStyle.DropDownList;
            cboUnit.Font = new Font("Segoe UI", 12F);
            cboUnit.FormattingEnabled = true;
            cboUnit.ItemHeight = 21;
            cboUnit.Location = new Point(171, 151);
            cboUnit.Name = "cboUnit";
            cboUnit.Size = new Size(355, 29);
            cboUnit.TabIndex = 5;
            // 
            // lblUnit
            // 
            lblUnit.AutoSize = true;
            lblUnit.Font = new Font("Segoe UI", 12F);
            lblUnit.Location = new Point(53, 154);
            lblUnit.Name = "lblUnit";
            lblUnit.Size = new Size(63, 21);
            lblUnit.TabIndex = 52;
            lblUnit.Text = "Unidad:";
            // 
            // lblObliUnit
            // 
            lblObliUnit.AutoSize = true;
            lblObliUnit.ForeColor = Color.Crimson;
            lblObliUnit.Location = new Point(110, 154);
            lblObliUnit.Name = "lblObliUnit";
            lblObliUnit.Size = new Size(12, 15);
            lblObliUnit.TabIndex = 53;
            lblObliUnit.Text = "*";
            lblObliUnit.Click += lblObliUnit_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Crimson;
            label1.Location = new Point(161, 46);
            label1.Name = "label1";
            label1.Size = new Size(12, 15);
            label1.TabIndex = 54;
            label1.Text = "*";
            // 
            // FrmSeasonActivitiesAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(538, 239);
            Controls.Add(label1);
            Controls.Add(txbIdUnit);
            Controls.Add(cboUnit);
            Controls.Add(txbIdSeason);
            Controls.Add(cboSeason);
            Controls.Add(lblId);
            Controls.Add(txbId);
            Controls.Add(lblTitle);
            Controls.Add(btnCancel);
            Controls.Add(btnAccept);
            Controls.Add(txbName);
            Controls.Add(lblObliUnit);
            Controls.Add(lblObliSeason);
            Controls.Add(lblUnit);
            Controls.Add(lblSeason);
            Controls.Add(lblObliName);
            Controls.Add(lblName);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmSeasonActivitiesAdd";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Añadir actividad de temporada";
            Load += FrmSeasonActivitiesAdd_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public TextBox txbName;
        public Button btnAccept;
        public Button btnCancel;
        public TextBox txbId;
        public Label lblTitle;
        private Label lblObliName;
        public Label lblName;
        public Label lblId;
        public TextBox txbIdSeason;
        public ComboBox cboSeason;
        public Label lblSeason;
        private Label lblObliSeason;
        public TextBox txbIdUnit;
        public ComboBox cboUnit;
        public Label lblUnit;
        private Label lblObliUnit;
        private Label label1;
    }
}
