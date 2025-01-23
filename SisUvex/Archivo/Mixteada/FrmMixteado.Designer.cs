namespace SisUvex.Archivo.Mixteada
{
    partial class FrmMixteado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMixteado));
            txbIdPallet = new TextBox();
            lblIdPallet = new Label();
            dgvPallet = new DataGridView();
            btnAgregar = new Button();
            btnQuitar = new Button();
            btnGuardar = new Button();
            lblCajas = new Label();
            txbCajas = new TextBox();
            lblTitulo = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvPallet).BeginInit();
            SuspendLayout();
            // 
            // txbIdPallet
            // 
            txbIdPallet.Location = new Point(57, 43);
            txbIdPallet.MaxLength = 5;
            txbIdPallet.Name = "txbIdPallet";
            txbIdPallet.Size = new Size(108, 23);
            txbIdPallet.TabIndex = 0;
            txbIdPallet.KeyPress += txbIdPallet_KeyPress;
            // 
            // lblIdPallet
            // 
            lblIdPallet.AutoSize = true;
            lblIdPallet.Location = new Point(12, 46);
            lblIdPallet.Name = "lblIdPallet";
            lblIdPallet.Size = new Size(39, 15);
            lblIdPallet.TabIndex = 1;
            lblIdPallet.Text = "Pallet:";
            // 
            // dgvPallet
            // 
            dgvPallet.AllowUserToAddRows = false;
            dgvPallet.AllowUserToDeleteRows = false;
            dgvPallet.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPallet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
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
            dgvPallet.Location = new Point(12, 72);
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
            dgvPallet.Size = new Size(776, 337);
            dgvPallet.TabIndex = 3;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(171, 43);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnQuitar
            // 
            btnQuitar.Location = new Point(252, 43);
            btnQuitar.Name = "btnQuitar";
            btnQuitar.Size = new Size(129, 23);
            btnQuitar.TabIndex = 2;
            btnQuitar.Text = "Quitar seleeccionado";
            btnQuitar.UseVisualStyleBackColor = true;
            btnQuitar.Click += btnQuitar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnGuardar.Location = new Point(12, 415);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(65, 23);
            btnGuardar.TabIndex = 4;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click_1;
            // 
            // lblCajas
            // 
            lblCajas.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblCajas.AutoSize = true;
            lblCajas.Location = new Point(130, 419);
            lblCajas.Name = "lblCajas";
            lblCajas.Size = new Size(35, 15);
            lblCajas.TabIndex = 9;
            lblCajas.Text = "Cajas";
            // 
            // txbCajas
            // 
            txbCajas.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txbCajas.Enabled = false;
            txbCajas.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            txbCajas.Location = new Point(83, 416);
            txbCajas.Name = "txbCajas";
            txbCajas.Size = new Size(42, 23);
            txbCajas.TabIndex = 5;
            txbCajas.TextAlign = HorizontalAlignment.Right;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Arial Black", 16F);
            lblTitulo.Location = new Point(12, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(216, 31);
            lblTitulo.TabIndex = 11;
            lblTitulo.Text = "Mixteado pallets";
            // 
            // FrmMixteado
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblTitulo);
            Controls.Add(txbCajas);
            Controls.Add(lblCajas);
            Controls.Add(btnGuardar);
            Controls.Add(btnQuitar);
            Controls.Add(btnAgregar);
            Controls.Add(dgvPallet);
            Controls.Add(lblIdPallet);
            Controls.Add(txbIdPallet);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(816, 489);
            Name = "FrmMixteado";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mixteado pallets";
            ((System.ComponentModel.ISupportInitialize)dgvPallet).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txbIdPallet;
        private Label lblIdPallet;
        public DataGridView dgvPallet;
        private Button btnAgregar;
        private Button btnQuitar;
        private Button btnGuardar;
        private Label lblCajas;
        private TextBox txbCajas;
        public Label lblTitulo;
    }
}