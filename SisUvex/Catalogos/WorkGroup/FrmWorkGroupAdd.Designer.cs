namespace SisUvex.Catalogos.WorkGroup
{
    partial class FrmWorkGroupAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWorkGroupAdd));
            txbName = new TextBox();
            btnSearchContractor = new Button();
            txbIdContractor = new TextBox();
            cboContractor = new ComboBox();
            lblObliContratista = new Label();
            btnAccept = new Button();
            btnCancel = new Button();
            txbId = new TextBox();
            lblTitle = new Label();
            lblObliId = new Label();
            lblContractor = new Label();
            label1 = new Label();
            lblId = new Label();
            txbIdSeason = new TextBox();
            cboSeason = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            chbActiveContractor = new CheckBox();
            chbActive = new CheckBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // txbName
            // 
            txbName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txbName.Location = new Point(171, 117);
            txbName.MaxLength = 15;
            txbName.Name = "txbName";
            txbName.Size = new Size(275, 29);
            txbName.TabIndex = 1;
            // 
            // btnSearchContractor
            // 
            btnSearchContractor.BackgroundImage = Properties.Resources.buscarIcon32;
            btnSearchContractor.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearchContractor.Location = new Point(497, 152);
            btnSearchContractor.Name = "btnSearchContractor";
            btnSearchContractor.Size = new Size(29, 29);
            btnSearchContractor.TabIndex = 5;
            btnSearchContractor.UseVisualStyleBackColor = true;
            btnSearchContractor.Click += btnSearchContractor_Click;
            // 
            // txbIdContractor
            // 
            txbIdContractor.Enabled = false;
            txbIdContractor.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbIdContractor.Location = new Point(119, 152);
            txbIdContractor.Name = "txbIdContractor";
            txbIdContractor.Size = new Size(46, 29);
            txbIdContractor.TabIndex = 2;
            txbIdContractor.TextAlign = HorizontalAlignment.Center;
            // 
            // cboContractor
            // 
            cboContractor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboContractor.Font = new Font("Segoe UI", 12F);
            cboContractor.FormattingEnabled = true;
            cboContractor.ItemHeight = 21;
            cboContractor.Location = new Point(171, 152);
            cboContractor.Name = "cboContractor";
            cboContractor.Size = new Size(275, 29);
            cboContractor.TabIndex = 3;
            // 
            // lblObliContratista
            // 
            lblObliContratista.AutoSize = true;
            lblObliContratista.ForeColor = Color.Crimson;
            lblObliContratista.Location = new Point(111, 152);
            lblObliContratista.Name = "lblObliContratista";
            lblObliContratista.Size = new Size(12, 15);
            lblObliContratista.TabIndex = 50;
            lblObliContratista.Text = "*";
            // 
            // btnAccept
            // 
            btnAccept.Location = new Point(370, 238);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(75, 29);
            btnAccept.TabIndex = 8;
            btnAccept.Text = "Aceptar";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(451, 238);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 29);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // txbId
            // 
            txbId.Enabled = false;
            txbId.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbId.Location = new Point(171, 82);
            txbId.Name = "txbId";
            txbId.Size = new Size(46, 29);
            txbId.TabIndex = 0;
            txbId.TextAlign = HorizontalAlignment.Center;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial Black", 16F);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(206, 31);
            lblTitle.TabIndex = 39;
            lblTitle.Text = "Añadir cuadrilla";
            // 
            // lblObliId
            // 
            lblObliId.AutoSize = true;
            lblObliId.ForeColor = Color.Crimson;
            lblObliId.Location = new Point(162, 82);
            lblObliId.Name = "lblObliId";
            lblObliId.Size = new Size(12, 15);
            lblObliId.TabIndex = 49;
            lblObliId.Text = "*";
            // 
            // lblContractor
            // 
            lblContractor.AutoSize = true;
            lblContractor.Font = new Font("Segoe UI", 12F);
            lblContractor.Location = new Point(28, 155);
            lblContractor.Name = "lblContractor";
            lblContractor.Size = new Size(89, 21);
            lblContractor.TabIndex = 41;
            lblContractor.Text = "Contratista:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(33, 120);
            label1.Name = "label1";
            label1.Size = new Size(134, 21);
            label1.TabIndex = 51;
            label1.Text = "Nombre cuadrilla:";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 12F);
            lblId.Location = new Point(12, 85);
            lblId.Name = "lblId";
            lblId.Size = new Size(155, 21);
            lblId.TabIndex = 47;
            lblId.Text = "Número de cuadrilla:";
            // 
            // txbIdSeason
            // 
            txbIdSeason.Enabled = false;
            txbIdSeason.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbIdSeason.Location = new Point(119, 187);
            txbIdSeason.Name = "txbIdSeason";
            txbIdSeason.Size = new Size(46, 29);
            txbIdSeason.TabIndex = 6;
            txbIdSeason.TextAlign = HorizontalAlignment.Center;
            // 
            // cboSeason
            // 
            cboSeason.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSeason.Font = new Font("Segoe UI", 12F);
            cboSeason.FormattingEnabled = true;
            cboSeason.ItemHeight = 21;
            cboSeason.Location = new Point(171, 187);
            cboSeason.Name = "cboSeason";
            cboSeason.Size = new Size(275, 29);
            cboSeason.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Crimson;
            label2.Location = new Point(111, 187);
            label2.Name = "label2";
            label2.Size = new Size(12, 15);
            label2.TabIndex = 55;
            label2.Text = "*";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(23, 190);
            label3.Name = "label3";
            label3.Size = new Size(90, 21);
            label3.TabIndex = 52;
            label3.Text = "Temporada:";
            // 
            // chbActiveContractor
            // 
            chbActiveContractor.Appearance = Appearance.Button;
            chbActiveContractor.AutoSize = true;
            chbActiveContractor.BackgroundImage = Properties.Resources.Imagen6;
            chbActiveContractor.BackgroundImageLayout = ImageLayout.Stretch;
            chbActiveContractor.Font = new Font("Segoe UI", 10F);
            chbActiveContractor.Location = new Point(452, 152);
            chbActiveContractor.Name = "chbActiveContractor";
            chbActiveContractor.Size = new Size(39, 29);
            chbActiveContractor.TabIndex = 4;
            chbActiveContractor.Text = "     ";
            chbActiveContractor.UseVisualStyleBackColor = true;
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
            chbActive.Location = new Point(171, 45);
            chbActive.Name = "chbActive";
            chbActive.Size = new Size(63, 31);
            chbActive.TabIndex = 10;
            chbActive.Text = "Activo";
            chbActive.TextAlign = ContentAlignment.MiddleCenter;
            chbActive.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Crimson;
            label4.Location = new Point(161, 44);
            label4.Name = "label4";
            label4.Size = new Size(12, 15);
            label4.TabIndex = 58;
            label4.Text = "*";
            // 
            // FrmWorkGroupAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(535, 279);
            Controls.Add(chbActive);
            Controls.Add(label4);
            Controls.Add(chbActiveContractor);
            Controls.Add(txbIdSeason);
            Controls.Add(cboSeason);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(txbName);
            Controls.Add(btnSearchContractor);
            Controls.Add(txbIdContractor);
            Controls.Add(cboContractor);
            Controls.Add(lblObliContratista);
            Controls.Add(btnAccept);
            Controls.Add(btnCancel);
            Controls.Add(txbId);
            Controls.Add(lblTitle);
            Controls.Add(lblObliId);
            Controls.Add(lblContractor);
            Controls.Add(label1);
            Controls.Add(lblId);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FrmWorkGroupAdd";
            Text = "Añadir cuadrilla";
            Load += FrmWorkGroupAdd_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public TextBox txbName;
        private Button btnSearchContractor;
        public TextBox txbIdContractor;
        private Label lblObliContratista;
        private Button btnAccept;
        private Button btnCancel;
        public TextBox txbId;
        public Label lblTitle;
        private Label lblObliId;
        private Label lblContractor;
        private Label label1;
        private Label lblId;
        public TextBox txbIdSeason;
        private Label label2;
        private Label label3;
        public CheckBox chbActiveContractor;
        public CheckBox chbActive;
        private Label label4;
        public ComboBox cboContractor;
        public ComboBox cboSeason;
    }
}