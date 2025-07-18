namespace SisUvex.Archivo.WorkPlan.ConvertPallet
{
    partial class FrmConvertPallet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConvertPallet));
            lblTitulo = new Label();
            btnQuit = new Button();
            btnAddPallet = new Button();
            dgvPallet = new DataGridView();
            lblIdPallet = new Label();
            txbIdPallet = new TextBox();
            txbWorkPlan = new TextBox();
            label1 = new Label();
            label2 = new Label();
            cboWorkPlan = new ComboBox();
            txbIdWorkPlan = new TextBox();
            btnAccept = new Button();
            btnCancel = new Button();
            txbDay = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvPallet).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Arial Black", 16F);
            lblTitulo.Location = new Point(12, 10);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(201, 31);
            lblTitulo.TabIndex = 20;
            lblTitulo.Text = "Convertir pallet";
            // 
            // btnQuit
            // 
            btnQuit.Location = new Point(280, 47);
            btnQuit.Name = "btnQuit";
            btnQuit.Size = new Size(129, 23);
            btnQuit.TabIndex = 3;
            btnQuit.Text = "Quitar seleeccionado";
            btnQuit.UseVisualStyleBackColor = true;
            btnQuit.Click += btnQuit_Click;
            // 
            // btnAddPallet
            // 
            btnAddPallet.Location = new Point(213, 47);
            btnAddPallet.Name = "btnAddPallet";
            btnAddPallet.Size = new Size(61, 23);
            btnAddPallet.TabIndex = 2;
            btnAddPallet.Text = "Agregar";
            btnAddPallet.UseVisualStyleBackColor = true;
            btnAddPallet.Click += btnAddPallet_Click;
            // 
            // dgvPallet
            // 
            dgvPallet.AllowUserToAddRows = false;
            dgvPallet.AllowUserToDeleteRows = false;
            dgvPallet.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPallet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            dgvPallet.BackgroundColor = SystemColors.ControlLightLight;
            dgvPallet.BorderStyle = BorderStyle.Fixed3D;
            dgvPallet.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvPallet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvPallet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvPallet.EnableHeadersVisualStyles = false;
            dgvPallet.ImeMode = ImeMode.NoControl;
            dgvPallet.Location = new Point(12, 129);
            dgvPallet.Name = "dgvPallet";
            dgvPallet.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvPallet.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvPallet.RowHeadersVisible = false;
            dgvPallet.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvPallet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPallet.Size = new Size(776, 246);
            dgvPallet.TabIndex = 7;
            // 
            // lblIdPallet
            // 
            lblIdPallet.AutoSize = true;
            lblIdPallet.Location = new Point(100, 50);
            lblIdPallet.Name = "lblIdPallet";
            lblIdPallet.Size = new Size(39, 15);
            lblIdPallet.TabIndex = 13;
            lblIdPallet.Text = "Pallet:";
            // 
            // txbIdPallet
            // 
            txbIdPallet.Location = new Point(141, 47);
            txbIdPallet.MaxLength = 5;
            txbIdPallet.Name = "txbIdPallet";
            txbIdPallet.Size = new Size(66, 23);
            txbIdPallet.TabIndex = 0;
            txbIdPallet.KeyPress += txbIdPallet_KeyPress;
            // 
            // txbWorkPlan
            // 
            txbWorkPlan.Enabled = false;
            txbWorkPlan.Location = new Point(230, 73);
            txbWorkPlan.MaxLength = 5;
            txbWorkPlan.Name = "txbWorkPlan";
            txbWorkPlan.Size = new Size(558, 23);
            txbWorkPlan.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 78);
            label1.Name = "label1";
            label1.Size = new Size(89, 15);
            label1.TabIndex = 22;
            label1.Text = "Plan de trabajo:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 103);
            label2.Name = "label2";
            label2.Size = new Size(125, 15);
            label2.TabIndex = 23;
            label2.Text = "Plan de trabajo nuevo:";
            // 
            // cboWorkPlan
            // 
            cboWorkPlan.DropDownStyle = ComboBoxStyle.DropDownList;
            cboWorkPlan.Font = new Font("Segoe UI", 9F);
            cboWorkPlan.FormattingEnabled = true;
            cboWorkPlan.Location = new Point(134, 100);
            cboWorkPlan.Margin = new Padding(1);
            cboWorkPlan.Name = "cboWorkPlan";
            cboWorkPlan.Size = new Size(654, 23);
            cboWorkPlan.TabIndex = 6;
            // 
            // txbIdWorkPlan
            // 
            txbIdWorkPlan.Enabled = false;
            txbIdWorkPlan.Location = new Point(98, 73);
            txbIdWorkPlan.MaxLength = 5;
            txbIdWorkPlan.Name = "txbIdWorkPlan";
            txbIdWorkPlan.Size = new Size(41, 23);
            txbIdWorkPlan.TabIndex = 3;
            // 
            // btnAccept
            // 
            btnAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAccept.Location = new Point(12, 381);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(127, 23);
            btnAccept.TabIndex = 8;
            btnAccept.Text = "Convertir pallets";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCancel.Location = new Point(147, 381);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(127, 23);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // txbDay
            // 
            txbDay.Enabled = false;
            txbDay.Location = new Point(141, 73);
            txbDay.MaxLength = 5;
            txbDay.Name = "txbDay";
            txbDay.Size = new Size(87, 23);
            txbDay.TabIndex = 4;
            // 
            // FrmConvertPallet
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 416);
            Controls.Add(txbDay);
            Controls.Add(btnCancel);
            Controls.Add(btnAccept);
            Controls.Add(txbIdWorkPlan);
            Controls.Add(cboWorkPlan);
            Controls.Add(txbWorkPlan);
            Controls.Add(lblTitulo);
            Controls.Add(btnQuit);
            Controls.Add(btnAddPallet);
            Controls.Add(dgvPallet);
            Controls.Add(txbIdPallet);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblIdPallet);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmConvertPallet";
            Text = "Convertir pallet";
            Load += FrmConvertPallet_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPallet).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Label lblTitulo;
        private Button btnQuit;
        private Button btnAddPallet;
        public DataGridView dgvPallet;
        private Label lblIdPallet;
        private Label label1;
        private Label label2;
        public ComboBox cboWorkPlan;
        public TextBox txbIdPallet;
        public TextBox txbIdWorkPlan;
        public TextBox txbWorkPlan;
        private Button btnAccept;
        private Button btnCancel;
        public TextBox txbDay;
    }
}