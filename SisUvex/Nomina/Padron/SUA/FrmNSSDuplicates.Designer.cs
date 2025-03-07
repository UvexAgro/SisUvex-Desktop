namespace SisUvex.Nomina.Padron.SUA
{
    partial class FrmNSSDuplicates
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
            dgvDuplicatesEmployees = new DataGridView();
            btnAccept = new Button();
            btnIgnore = new Button();
            lblTitle = new Label();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvDuplicatesEmployees).BeginInit();
            SuspendLayout();
            // 
            // dgvDuplicatesEmployees
            // 
            dgvDuplicatesEmployees.AllowUserToAddRows = false;
            dgvDuplicatesEmployees.AllowUserToDeleteRows = false;
            dgvDuplicatesEmployees.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDuplicatesEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvDuplicatesEmployees.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvDuplicatesEmployees.BackgroundColor = SystemColors.ControlLightLight;
            dgvDuplicatesEmployees.BorderStyle = BorderStyle.Fixed3D;
            dgvDuplicatesEmployees.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvDuplicatesEmployees.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvDuplicatesEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDuplicatesEmployees.EnableHeadersVisualStyles = false;
            dgvDuplicatesEmployees.ImeMode = ImeMode.NoControl;
            dgvDuplicatesEmployees.Location = new Point(12, 53);
            dgvDuplicatesEmployees.Name = "dgvDuplicatesEmployees";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvDuplicatesEmployees.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvDuplicatesEmployees.RowHeadersVisible = false;
            dgvDuplicatesEmployees.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvDuplicatesEmployees.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvDuplicatesEmployees.Size = new Size(606, 356);
            dgvDuplicatesEmployees.TabIndex = 27;
            // 
            // btnAccept
            // 
            btnAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAccept.Location = new Point(12, 415);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(64, 23);
            btnAccept.TabIndex = 28;
            btnAccept.Text = "Aceptar";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnIgnore
            // 
            btnIgnore.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnIgnore.Location = new Point(82, 415);
            btnIgnore.Name = "btnIgnore";
            btnIgnore.Size = new Size(64, 23);
            btnIgnore.TabIndex = 29;
            btnIgnore.Text = "Ignorar";
            btnIgnore.UseVisualStyleBackColor = true;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(10, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(391, 21);
            lblTitle.TabIndex = 33;
            lblTitle.Text = "Empleados con el mismo número de seguro social";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 35);
            label6.Name = "label6";
            label6.Size = new Size(318, 15);
            label6.TabIndex = 34;
            label6.Text = "Seleccione solo un empleado por número de seguro social.";
            // 
            // FrmNSSDuplicates
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(630, 450);
            Controls.Add(label6);
            Controls.Add(lblTitle);
            Controls.Add(btnAccept);
            Controls.Add(btnIgnore);
            Controls.Add(dgvDuplicatesEmployees);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmNSSDuplicates";
            Text = "FrmNSSDuplicates";
            Load += FrmNSSDuplicates_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDuplicatesEmployees).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public DataGridView dgvDuplicatesEmployees;
        private Button btnAccept;
        private Button btnIgnore;
        public Label lblTitle;
        private Label label6;
    }
}