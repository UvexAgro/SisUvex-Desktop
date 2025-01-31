namespace SisUvex.Archivo.Desestibar
{
    partial class FrmDesestibar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDesestibar));
            lblTitulo = new Label();
            lblIdEstiba = new Label();
            txbIdEstiba = new TextBox();
            dgvEstiba = new DataGridView();
            btnBuscarEstiba = new Button();
            btnDesestibar = new Button();
            lblNota = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvEstiba).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Arial Black", 16F);
            lblTitulo.Location = new Point(12, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(226, 31);
            lblTitulo.TabIndex = 12;
            lblTitulo.Text = "Desestibar estiba";
            // 
            // lblIdEstiba
            // 
            lblIdEstiba.AutoSize = true;
            lblIdEstiba.Location = new Point(12, 46);
            lblIdEstiba.Name = "lblIdEstiba";
            lblIdEstiba.Size = new Size(41, 15);
            lblIdEstiba.TabIndex = 14;
            lblIdEstiba.Text = "Estiba:";
            // 
            // txbIdEstiba
            // 
            txbIdEstiba.Location = new Point(57, 43);
            txbIdEstiba.Name = "txbIdEstiba";
            txbIdEstiba.Size = new Size(108, 23);
            txbIdEstiba.TabIndex = 0;
            // 
            // dgvEstiba
            // 
            dgvEstiba.AllowUserToAddRows = false;
            dgvEstiba.AllowUserToDeleteRows = false;
            dgvEstiba.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvEstiba.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvEstiba.BackgroundColor = SystemColors.ControlLightLight;
            dgvEstiba.BorderStyle = BorderStyle.Fixed3D;
            dgvEstiba.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvEstiba.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvEstiba.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvEstiba.EnableHeadersVisualStyles = false;
            dgvEstiba.ImeMode = ImeMode.NoControl;
            dgvEstiba.Location = new Point(12, 72);
            dgvEstiba.Name = "dgvEstiba";
            dgvEstiba.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvEstiba.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvEstiba.RowHeadersVisible = false;
            dgvEstiba.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvEstiba.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEstiba.Size = new Size(776, 337);
            dgvEstiba.TabIndex = 2;
            // 
            // btnBuscarEstiba
            // 
            btnBuscarEstiba.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnBuscarEstiba.BackgroundImageLayout = ImageLayout.Stretch;
            btnBuscarEstiba.Location = new Point(171, 43);
            btnBuscarEstiba.Name = "btnBuscarEstiba";
            btnBuscarEstiba.Size = new Size(23, 23);
            btnBuscarEstiba.TabIndex = 1;
            btnBuscarEstiba.UseVisualStyleBackColor = true;
            btnBuscarEstiba.Click += btnBuscarEstiba_Click;
            // 
            // btnDesestibar
            // 
            btnDesestibar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDesestibar.Location = new Point(713, 415);
            btnDesestibar.Name = "btnDesestibar";
            btnDesestibar.Size = new Size(75, 23);
            btnDesestibar.TabIndex = 3;
            btnDesestibar.Text = "Desestibar";
            btnDesestibar.UseVisualStyleBackColor = true;
            btnDesestibar.Click += btnDesestibar_Click;
            // 
            // lblNota
            // 
            lblNota.AutoSize = true;
            lblNota.ForeColor = Color.Red;
            lblNota.Location = new Point(12, 419);
            lblNota.Name = "lblNota";
            lblNota.Size = new Size(701, 15);
            lblNota.TabIndex = 25;
            lblNota.Text = "Saca a TODOS los pallets en la lista de la estiba seleccionada (Si se van a volver a estibar, tome nota de cuales antes de desestibarlos).";
            // 
            // FrmDesestibar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblNota);
            Controls.Add(btnDesestibar);
            Controls.Add(btnBuscarEstiba);
            Controls.Add(dgvEstiba);
            Controls.Add(lblIdEstiba);
            Controls.Add(txbIdEstiba);
            Controls.Add(lblTitulo);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(816, 489);
            Name = "FrmDesestibar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Desestibar estiba";
            ((System.ComponentModel.ISupportInitialize)dgvEstiba).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Label lblTitulo;
        private Label lblIdEstiba;
        private TextBox txbIdEstiba;
        public DataGridView dgvEstiba;
        private Button btnBuscarEstiba;
        private Button btnDesestibar;
        private Label lblNota;
    }
}