namespace SisUvex.Archivo.WorkPlan.ConvertPallet
{
    partial class FrmDuplicateWorkPlan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDuplicateWorkPlan));
            txbDay = new TextBox();
            txbIdWorkPlan = new TextBox();
            txbWorkPlan = new TextBox();
            label1 = new Label();
            label6 = new Label();
            cboWorkGroup = new ComboBox();
            cboSeason = new ComboBox();
            cboContractor = new ComboBox();
            label3 = new Label();
            label2 = new Label();
            btnCancel = new Button();
            btnAccept = new Button();
            SuspendLayout();
            // 
            // txbDay
            // 
            txbDay.Enabled = false;
            txbDay.Location = new Point(142, 12);
            txbDay.MaxLength = 5;
            txbDay.Name = "txbDay";
            txbDay.Size = new Size(70, 23);
            txbDay.TabIndex = 24;
            // 
            // txbIdWorkPlan
            // 
            txbIdWorkPlan.Enabled = false;
            txbIdWorkPlan.Location = new Point(99, 12);
            txbIdWorkPlan.MaxLength = 5;
            txbIdWorkPlan.Name = "txbIdWorkPlan";
            txbIdWorkPlan.Size = new Size(41, 23);
            txbIdWorkPlan.TabIndex = 23;
            // 
            // txbWorkPlan
            // 
            txbWorkPlan.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txbWorkPlan.Enabled = false;
            txbWorkPlan.Location = new Point(99, 41);
            txbWorkPlan.MaximumSize = new Size(900, 0);
            txbWorkPlan.MaxLength = 5;
            txbWorkPlan.Name = "txbWorkPlan";
            txbWorkPlan.Size = new Size(596, 23);
            txbWorkPlan.TabIndex = 25;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 17);
            label1.Name = "label1";
            label1.Size = new Size(89, 15);
            label1.TabIndex = 26;
            label1.Text = "Plan de trabajo:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F);
            label6.Location = new Point(44, 156);
            label6.Name = "label6";
            label6.Size = new Size(57, 15);
            label6.TabIndex = 69;
            label6.Text = "Cuadrilla:";
            // 
            // cboWorkGroup
            // 
            cboWorkGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            cboWorkGroup.DropDownWidth = 400;
            cboWorkGroup.FormattingEnabled = true;
            cboWorkGroup.Location = new Point(99, 153);
            cboWorkGroup.Name = "cboWorkGroup";
            cboWorkGroup.Size = new Size(203, 23);
            cboWorkGroup.TabIndex = 68;
            // 
            // cboSeason
            // 
            cboSeason.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSeason.DropDownWidth = 400;
            cboSeason.Enabled = false;
            cboSeason.FormattingEnabled = true;
            cboSeason.Location = new Point(99, 95);
            cboSeason.Name = "cboSeason";
            cboSeason.Size = new Size(203, 23);
            cboSeason.TabIndex = 70;
            // 
            // cboContractor
            // 
            cboContractor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboContractor.DropDownWidth = 400;
            cboContractor.Enabled = false;
            cboContractor.FormattingEnabled = true;
            cboContractor.Location = new Point(99, 124);
            cboContractor.Name = "cboContractor";
            cboContractor.Size = new Size(203, 23);
            cboContractor.TabIndex = 72;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F);
            label3.ForeColor = SystemColors.HotTrack;
            label3.Location = new Point(31, 103);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 74;
            label3.Text = "Temporada:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F);
            label2.ForeColor = SystemColors.HotTrack;
            label2.Location = new Point(33, 127);
            label2.Name = "label2";
            label2.Size = new Size(68, 15);
            label2.TabIndex = 75;
            label2.Text = "Contratista:";
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(187, 182);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(82, 23);
            btnCancel.TabIndex = 77;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnAccept
            // 
            btnAccept.Location = new Point(99, 182);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(82, 23);
            btnAccept.TabIndex = 76;
            btnAccept.Text = "Crear plan";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // FrmDuplicateWorkPlan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(707, 212);
            Controls.Add(btnCancel);
            Controls.Add(btnAccept);
            Controls.Add(cboContractor);
            Controls.Add(cboSeason);
            Controls.Add(cboWorkGroup);
            Controls.Add(txbDay);
            Controls.Add(txbIdWorkPlan);
            Controls.Add(txbWorkPlan);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label6);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmDuplicateWorkPlan";
            Text = "Duplicar plan de trabajo";
            Load += FrmDuplicateWorkPlan_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public TextBox txbDay;
        public TextBox txbIdWorkPlan;
        public TextBox txbWorkPlan;
        private Label label1;
        private Label label6;
        public ComboBox cboWorkGroup;
        public ComboBox cboSeason;
        public ComboBox cboContractor;
        private Label label3;
        private Label label2;
        private Button btnCancel;
        private Button btnAccept;
    }
}