namespace SisUvex.Nomina.Padron.SUA
{
    partial class FrmSuaConfigCat
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
            txbSUAPath = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txbRegPatGrower = new TextBox();
            cboGrower = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            txbSUAType = new TextBox();
            lblTitle = new Label();
            btnCancel = new Button();
            btnAccept = new Button();
            btnSearch = new Button();
            label6 = new Label();
            txbPC = new TextBox();
            lblid = new Label();
            txbId = new TextBox();
            SuspendLayout();
            // 
            // txbSUAPath
            // 
            txbSUAPath.Enabled = false;
            txbSUAPath.Location = new Point(13, 100);
            txbSUAPath.MaxLength = 200;
            txbSUAPath.Name = "txbSUAPath";
            txbSUAPath.Size = new Size(332, 23);
            txbSUAPath.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 84);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 1;
            label1.Text = "Ruta SUA";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(318, 126);
            label2.Name = "label2";
            label2.Size = new Size(97, 15);
            label2.TabIndex = 3;
            label2.Text = "Registro patronal";
            // 
            // txbRegPatGrower
            // 
            txbRegPatGrower.Enabled = false;
            txbRegPatGrower.Location = new Point(318, 142);
            txbRegPatGrower.Name = "txbRegPatGrower";
            txbRegPatGrower.Size = new Size(97, 23);
            txbRegPatGrower.TabIndex = 5;
            txbRegPatGrower.TextAlign = HorizontalAlignment.Center;
            // 
            // cboGrower
            // 
            cboGrower.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGrower.FormattingEnabled = true;
            cboGrower.Location = new Point(13, 142);
            cboGrower.Name = "cboGrower";
            cboGrower.Size = new Size(299, 23);
            cboGrower.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 126);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 5;
            label3.Text = "Razón social";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 168);
            label4.Name = "label4";
            label4.Size = new Size(56, 15);
            label4.TabIndex = 7;
            label4.Text = "Tipo SUA";
            // 
            // txbSUAType
            // 
            txbSUAType.Location = new Point(13, 184);
            txbSUAType.MaxLength = 20;
            txbSUAType.Name = "txbSUAType";
            txbSUAType.Size = new Size(189, 23);
            txbSUAType.TabIndex = 6;
            txbSUAType.TabStop = false;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(208, 21);
            lblTitle.TabIndex = 8;
            lblTitle.Text = "Añadir configuración SUA";
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(351, 184);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(64, 23);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnAccept
            // 
            btnAccept.Location = new Point(281, 184);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(64, 23);
            btnAccept.TabIndex = 7;
            btnAccept.Text = "Aceptar";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(351, 100);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(64, 23);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Examinar";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 42);
            label6.Name = "label6";
            label6.Size = new Size(44, 15);
            label6.TabIndex = 13;
            label6.Text = "Equipo";
            // 
            // txbPC
            // 
            txbPC.Enabled = false;
            txbPC.Location = new Point(12, 58);
            txbPC.Name = "txbPC";
            txbPC.Size = new Size(190, 23);
            txbPC.TabIndex = 1;
            // 
            // lblid
            // 
            lblid.AutoSize = true;
            lblid.Location = new Point(374, 15);
            lblid.Name = "lblid";
            lblid.Size = new Size(17, 15);
            lblid.TabIndex = 15;
            lblid.Text = "Id";
            // 
            // txbId
            // 
            txbId.Enabled = false;
            txbId.Location = new Point(388, 12);
            txbId.Name = "txbId";
            txbId.Size = new Size(27, 23);
            txbId.TabIndex = 0;
            txbId.TextAlign = HorizontalAlignment.Center;
            // 
            // FrmSuaConfigCat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(427, 222);
            Controls.Add(txbId);
            Controls.Add(label6);
            Controls.Add(txbPC);
            Controls.Add(btnSearch);
            Controls.Add(btnAccept);
            Controls.Add(btnCancel);
            Controls.Add(lblTitle);
            Controls.Add(label4);
            Controls.Add(txbSUAType);
            Controls.Add(label3);
            Controls.Add(cboGrower);
            Controls.Add(label2);
            Controls.Add(txbRegPatGrower);
            Controls.Add(label1);
            Controls.Add(txbSUAPath);
            Controls.Add(lblid);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmSuaConfigCat";
            Text = "FrmSuaConfigCat";
            Load += FrmSuaConfigCat_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnCancel;
        private Button btnAccept;
        private Button btnSearch;
        private Label label6;
        public TextBox txbSUAPath;
        public TextBox txbRegPatGrower;
        public ComboBox cboGrower;
        public TextBox txbSUAType;
        public TextBox txbPC;
        private Label lblid;
        public TextBox txbId;
        public Label lblTitle;
    }
}