namespace SisUvex.Material.MaterialForeignDest
{
    partial class FrmMaterialForeignDestAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMaterialForeignDestAdd));
            lblTitle = new Label();
            txbId = new TextBox();
            txbName = new TextBox();
            lblObliName = new Label();
            label6 = new Label();
            lblName = new Label();
            lblId = new Label();
            label1 = new Label();
            txbCity = new TextBox();
            label3 = new Label();
            txbState = new TextBox();
            btnAccept = new Button();
            btnCancel = new Button();
            label5 = new Label();
            txbPostalCode = new TextBox();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial Black", 16F);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(292, 31);
            lblTitle.TabIndex = 113;
            lblTitle.Text = "Añadir destino externo";
            // 
            // txbId
            // 
            txbId.Enabled = false;
            txbId.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbId.Location = new Point(97, 43);
            txbId.Name = "txbId";
            txbId.Size = new Size(70, 29);
            txbId.TabIndex = 107;
            txbId.TextAlign = HorizontalAlignment.Center;
            // 
            // txbName
            // 
            txbName.Font = new Font("Segoe UI", 12F);
            txbName.Location = new Point(97, 78);
            txbName.MaxLength = 30;
            txbName.Name = "txbName";
            txbName.Size = new Size(437, 29);
            txbName.TabIndex = 108;
            // 
            // lblObliName
            // 
            lblObliName.AutoSize = true;
            lblObliName.ForeColor = Color.Crimson;
            lblObliName.Location = new Point(88, 80);
            lblObliName.Margin = new Padding(0);
            lblObliName.Name = "lblObliName";
            lblObliName.Size = new Size(12, 15);
            lblObliName.TabIndex = 111;
            lblObliName.Text = "*";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.Crimson;
            label6.Location = new Point(88, 43);
            label6.Margin = new Padding(0);
            label6.Name = "label6";
            label6.Size = new Size(12, 15);
            label6.TabIndex = 112;
            label6.Text = "*";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 12F);
            lblName.Location = new Point(12, 81);
            lblName.Name = "lblName";
            lblName.Size = new Size(78, 21);
            lblName.TabIndex = 109;
            lblName.Text = "Dirección:";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 12F);
            lblId.Location = new Point(66, 45);
            lblId.Name = "lblId";
            lblId.Size = new Size(26, 21);
            lblId.TabIndex = 110;
            lblId.Text = "Id:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(28, 116);
            label1.Name = "label1";
            label1.Size = new Size(62, 21);
            label1.TabIndex = 115;
            label1.Text = "Ciudad:";
            // 
            // txbCity
            // 
            txbCity.Font = new Font("Segoe UI", 12F);
            txbCity.Location = new Point(97, 113);
            txbCity.MaxLength = 50;
            txbCity.Name = "txbCity";
            txbCity.Size = new Size(437, 29);
            txbCity.TabIndex = 114;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(31, 151);
            label3.Name = "label3";
            label3.Size = new Size(59, 21);
            label3.TabIndex = 118;
            label3.Text = "Estado:";
            // 
            // txbState
            // 
            txbState.Font = new Font("Segoe UI", 12F);
            txbState.Location = new Point(97, 148);
            txbState.MaxLength = 30;
            txbState.Name = "txbState";
            txbState.Size = new Size(437, 29);
            txbState.TabIndex = 117;
            // 
            // btnAccept
            // 
            btnAccept.Location = new Point(381, 229);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(75, 29);
            btnAccept.TabIndex = 120;
            btnAccept.Text = "Aceptar";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(462, 229);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 29);
            btnCancel.TabIndex = 121;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(31, 186);
            label5.Name = "label5";
            label5.Size = new Size(109, 21);
            label5.TabIndex = 123;
            label5.Text = "Código postal:";
            // 
            // txbPostalCode
            // 
            txbPostalCode.Font = new Font("Segoe UI", 12F);
            txbPostalCode.Location = new Point(146, 183);
            txbPostalCode.MaxLength = 5;
            txbPostalCode.Name = "txbPostalCode";
            txbPostalCode.Size = new Size(97, 29);
            txbPostalCode.TabIndex = 122;
            // 
            // FrmMaterialForeignDestAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(549, 270);
            Controls.Add(label5);
            Controls.Add(txbPostalCode);
            Controls.Add(btnAccept);
            Controls.Add(btnCancel);
            Controls.Add(label3);
            Controls.Add(txbState);
            Controls.Add(label1);
            Controls.Add(txbCity);
            Controls.Add(lblTitle);
            Controls.Add(txbId);
            Controls.Add(label6);
            Controls.Add(lblName);
            Controls.Add(lblId);
            Controls.Add(txbName);
            Controls.Add(lblObliName);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmMaterialForeignDestAdd";
            Text = "Añadir destino externo";
            Load += FrmMaterialForeignDestAdd_Load;
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
        private Label label1;
        public TextBox txbCity;
        private Label label3;
        public TextBox txbState;
        private Button btnAccept;
        private Button btnCancel;
        private Label label5;
        public TextBox txbPostalCode;
    }
}