namespace SisUvex.Catalogos.Container
{
    partial class FrmContainerAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmContainerAdd));
            chbActive = new CheckBox();
            txbId = new TextBox();
            txbName = new TextBox();
            lblName = new Label();
            lblTitle = new Label();
            lblObliName = new Label();
            label6 = new Label();
            lblId = new Label();
            label2 = new Label();
            btnAccept = new Button();
            btnCancel = new Button();
            SuspendLayout();
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
            chbActive.Location = new Point(94, 58);
            chbActive.Name = "chbActive";
            chbActive.Size = new Size(63, 31);
            chbActive.TabIndex = 0;
            chbActive.Text = "Activo";
            chbActive.TextAlign = ContentAlignment.MiddleCenter;
            chbActive.UseVisualStyleBackColor = false;
            // 
            // txbId
            // 
            txbId.Enabled = false;
            txbId.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbId.Location = new Point(358, 9);
            txbId.Name = "txbId";
            txbId.Size = new Size(46, 29);
            txbId.TabIndex = 1;
            txbId.TextAlign = HorizontalAlignment.Center;
            // 
            // txbName
            // 
            txbName.Font = new Font("Segoe UI", 12F);
            txbName.Location = new Point(94, 95);
            txbName.MaxLength = 15;
            txbName.Name = "txbName";
            txbName.Size = new Size(310, 29);
            txbName.TabIndex = 2;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 12F);
            lblName.Location = new Point(17, 98);
            lblName.Name = "lblName";
            lblName.Size = new Size(71, 21);
            lblName.TabIndex = 72;
            lblName.Text = "Nombre:";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial Black", 16F);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(242, 31);
            lblTitle.TabIndex = 71;
            lblTitle.Text = "Añadir Contenedor";
            // 
            // lblObliName
            // 
            lblObliName.AutoSize = true;
            lblObliName.ForeColor = Color.Crimson;
            lblObliName.Location = new Point(85, 98);
            lblObliName.Name = "lblObliName";
            lblObliName.Size = new Size(12, 15);
            lblObliName.TabIndex = 75;
            lblObliName.Text = "*";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.Crimson;
            label6.Location = new Point(348, 10);
            label6.Name = "label6";
            label6.Size = new Size(12, 15);
            label6.TabIndex = 78;
            label6.Text = "*";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 12F);
            lblId.Location = new Point(330, 13);
            lblId.Name = "lblId";
            lblId.Size = new Size(26, 21);
            lblId.TabIndex = 74;
            lblId.Text = "Id:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Crimson;
            label2.Location = new Point(84, 57);
            label2.Name = "label2";
            label2.Size = new Size(12, 15);
            label2.TabIndex = 76;
            label2.Text = "*";
            // 
            // btnAccept
            // 
            btnAccept.Location = new Point(248, 130);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(75, 29);
            btnAccept.TabIndex = 3;
            btnAccept.Text = "Aceptar";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(329, 130);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 29);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // FrmContainerAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(417, 175);
            Controls.Add(btnAccept);
            Controls.Add(btnCancel);
            Controls.Add(chbActive);
            Controls.Add(txbId);
            Controls.Add(txbName);
            Controls.Add(lblName);
            Controls.Add(lblTitle);
            Controls.Add(lblObliName);
            Controls.Add(label6);
            Controls.Add(lblId);
            Controls.Add(label2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmContainerAdd";
            Text = "Añadir contenedor";
            Load += FrmContainerAdd_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public CheckBox chbActive;
        public TextBox txbId;
        public TextBox txbName;
        private Label lblName;
        public Label lblTitle;
        private Label lblObliName;
        private Label label6;
        private Label lblId;
        private Label label2;
        private Button btnAccept;
        private Button btnCancel;
    }
}