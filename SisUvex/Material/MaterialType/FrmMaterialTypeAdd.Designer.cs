namespace SisUvex.Material.MaterialType
{
    partial class FrmMaterialTypeAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMaterialTypeAdd));
            lblTitle = new Label();
            txbId = new TextBox();
            txbName = new TextBox();
            lblObliName = new Label();
            label6 = new Label();
            lblName = new Label();
            lblId = new Label();
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
            lblTitle.Size = new Size(292, 31);
            lblTitle.TabIndex = 138;
            lblTitle.Text = "Añadir tipo de material";
            // 
            // txbId
            // 
            txbId.Enabled = false;
            txbId.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbId.Location = new Point(88, 43);
            txbId.MaxLength = 2;
            txbId.Name = "txbId";
            txbId.Size = new Size(43, 29);
            txbId.TabIndex = 130;
            txbId.TextAlign = HorizontalAlignment.Center;
            // 
            // txbName
            // 
            txbName.Font = new Font("Segoe UI", 12F);
            txbName.Location = new Point(88, 78);
            txbName.MaxLength = 20;
            txbName.Name = "txbName";
            txbName.Size = new Size(276, 29);
            txbName.TabIndex = 131;
            // 
            // lblObliName
            // 
            lblObliName.AutoSize = true;
            lblObliName.ForeColor = Color.Crimson;
            lblObliName.Location = new Point(79, 80);
            lblObliName.Margin = new Padding(0);
            lblObliName.Name = "lblObliName";
            lblObliName.Size = new Size(12, 15);
            lblObliName.TabIndex = 135;
            lblObliName.Text = "*";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.Crimson;
            label6.Location = new Point(79, 43);
            label6.Margin = new Padding(0);
            label6.Name = "label6";
            label6.Size = new Size(12, 15);
            label6.TabIndex = 137;
            label6.Text = "*";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 12F);
            lblName.Location = new Point(12, 81);
            lblName.Name = "lblName";
            lblName.Size = new Size(71, 21);
            lblName.TabIndex = 132;
            lblName.Text = "Nombre:";
            lblName.TextAlign = ContentAlignment.TopRight;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 12F);
            lblId.Location = new Point(57, 45);
            lblId.Name = "lblId";
            lblId.Size = new Size(26, 21);
            lblId.TabIndex = 133;
            lblId.Text = "Id:";
            lblId.TextAlign = ContentAlignment.TopRight;
            // 
            // btnAccept
            // 
            btnAccept.Location = new Point(208, 114);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(75, 29);
            btnAccept.TabIndex = 139;
            btnAccept.Text = "Aceptar";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(289, 114);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 29);
            btnCancel.TabIndex = 140;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // FrmMaterialTypeAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(374, 155);
            Controls.Add(btnAccept);
            Controls.Add(btnCancel);
            Controls.Add(lblTitle);
            Controls.Add(txbId);
            Controls.Add(txbName);
            Controls.Add(lblObliName);
            Controls.Add(label6);
            Controls.Add(lblName);
            Controls.Add(lblId);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmMaterialTypeAdd";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Añadir tipo de material";
            Load += FrmMaterialTypeAdd_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Label lblTitle;
        public TextBox txbId;
        public TextBox txbName;
        private Label lblObliName;
        private Label label6;
        private Label lblName;
        private Label lblId;
        private Button btnAccept;
        private Button btnCancel;
    }
}