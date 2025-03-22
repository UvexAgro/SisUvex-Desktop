namespace SisUvex.Packing.Maintenance
{
    partial class FrmPackingMaintenance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPackingMaintenance));
            lblTitle = new Label();
            label6 = new Label();
            btnCleanPackingBoxes = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(228, 21);
            lblTitle.TabIndex = 33;
            lblTitle.Text = "Mantenimiento de empaque";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(87, 50);
            label6.Margin = new Padding(0, 0, 3, 0);
            label6.Name = "label6";
            label6.Size = new Size(155, 15);
            label6.TabIndex = 34;
            label6.Text = "Limpieza de cajas sin utilizar";
            // 
            // btnCleanPackingBoxes
            // 
            btnCleanPackingBoxes.Image = Properties.Resources.limpiarIcon16;
            btnCleanPackingBoxes.ImageAlign = ContentAlignment.MiddleLeft;
            btnCleanPackingBoxes.Location = new Point(12, 46);
            btnCleanPackingBoxes.Margin = new Padding(3, 3, 0, 3);
            btnCleanPackingBoxes.Name = "btnCleanPackingBoxes";
            btnCleanPackingBoxes.Size = new Size(75, 23);
            btnCleanPackingBoxes.TabIndex = 35;
            btnCleanPackingBoxes.Text = "Limpiar";
            btnCleanPackingBoxes.TextAlign = ContentAlignment.TopRight;
            btnCleanPackingBoxes.UseVisualStyleBackColor = true;
            btnCleanPackingBoxes.Click += btnCleanPackingBoxes_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancel.Location = new Point(296, 75);
            btnCancel.Margin = new Padding(3, 3, 0, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(65, 23);
            btnCancel.TabIndex = 36;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // FrmPackingMaintenance
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(370, 110);
            Controls.Add(btnCancel);
            Controls.Add(btnCleanPackingBoxes);
            Controls.Add(label6);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmPackingMaintenance";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mantenimiento de empaque";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Label lblTitle;
        private Label label6;
        private Button btnCleanPackingBoxes;
        private Button btnCancel;
    }
}