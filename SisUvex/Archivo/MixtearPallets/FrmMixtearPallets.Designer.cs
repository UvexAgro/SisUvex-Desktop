namespace SisUvex.Archivo.MixtearPallets
{
    partial class FrmMixtearPallets
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMixtearPallets));
            lblTitulo = new Label();
            label4 = new Label();
            lblIdPallet = new Label();
            txbIdPallet = new TextBox();
            btnAddPallet = new Button();
            btnQuitPallet = new Button();
            btnReestibar = new Button();
            btnReconfigurar = new Button();
            btnQuitarMix = new Button();
            btnAsistido = new Button();
            dgvPallets = new DataGridView();
            btnGuardar = new Button();
            txbBoxesStow = new TextBox();
            label1 = new Label();
            txbBoxesMax = new TextBox();
            label2 = new Label();
            label3 = new Label();
            btnAddToUp = new Button();
            button1 = new Button();
            btnQuitarDes = new Button();
            dgvDestibar = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvPallets).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDestibar).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Arial Black", 15F, FontStyle.Bold);
            lblTitulo.Location = new Point(12, 8);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(285, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Mixtear Pallets en Estiba";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            label4.ForeColor = Color.DimGray;
            label4.Location = new Point(12, 45);
            label4.Name = "label4";
            label4.Size = new Size(136, 15);
            label4.TabIndex = 1;
            label4.Text = "▶  PALLETS A MIXTEAR";
            // 
            // lblIdPallet
            // 
            lblIdPallet.AutoSize = true;
            lblIdPallet.Location = new Point(12, 70);
            lblIdPallet.Name = "lblIdPallet";
            lblIdPallet.Size = new Size(39, 15);
            lblIdPallet.TabIndex = 2;
            lblIdPallet.Text = "Pallet:";
            // 
            // txbIdPallet
            // 
            txbIdPallet.Location = new Point(60, 67);
            txbIdPallet.MaxLength = 5;
            txbIdPallet.Name = "txbIdPallet";
            txbIdPallet.Size = new Size(90, 23);
            txbIdPallet.TabIndex = 3;
            txbIdPallet.KeyDown += txbIdPallet_KeyDown;
            txbIdPallet.KeyPress += txbIdPallet_KeyPress;
            // 
            // btnAddPallet
            // 
            btnAddPallet.Location = new Point(157, 65);
            btnAddPallet.Name = "btnAddPallet";
            btnAddPallet.Size = new Size(75, 25);
            btnAddPallet.TabIndex = 4;
            btnAddPallet.Text = "Agregar";
            btnAddPallet.UseVisualStyleBackColor = true;
            btnAddPallet.Click += btnAddPallet_Click;
            // 
            // btnQuitPallet
            // 
            btnQuitPallet.Location = new Point(240, 65);
            btnQuitPallet.Name = "btnQuitPallet";
            btnQuitPallet.Size = new Size(140, 25);
            btnQuitPallet.TabIndex = 5;
            btnQuitPallet.Text = "↓ Mover a desestibar";
            btnQuitPallet.UseVisualStyleBackColor = true;
            btnQuitPallet.Click += btnQuitPallet_Click;
            // 
            // btnReestibar
            // 
            btnReestibar.Location = new Point(386, 65);
            btnReestibar.Name = "btnReestibar";
            btnReestibar.Size = new Size(90, 25);
            btnReestibar.TabIndex = 6;
            btnReestibar.Text = "Reestibar";
            btnReestibar.UseVisualStyleBackColor = true;
            btnReestibar.Click += btnReestibar_Click;
            // 
            // btnReconfigurar
            // 
            btnReconfigurar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnReconfigurar.Location = new Point(900, 66);
            btnReconfigurar.Name = "btnReconfigurar";
            btnReconfigurar.Size = new Size(100, 25);
            btnReconfigurar.TabIndex = 7;
            btnReconfigurar.Text = "Reconfigurar";
            btnReconfigurar.UseVisualStyleBackColor = true;
            btnReconfigurar.Click += btnReconfigurar_Click;
            // 
            // btnQuitarMix
            // 
            btnQuitarMix.ForeColor = Color.DarkRed;
            btnQuitarMix.Location = new Point(484, 65);
            btnQuitarMix.Name = "btnQuitarMix";
            btnQuitarMix.Size = new Size(90, 25);
            btnQuitarMix.TabIndex = 7;
            btnQuitarMix.Text = "✕ Quitar";
            btnQuitarMix.UseVisualStyleBackColor = true;
            btnQuitarMix.Click += btnQuitarMix_Click;
            // 
            // btnAsistido
            // 
            btnAsistido.Enabled = false;
            btnAsistido.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnAsistido.ForeColor = Color.DarkGreen;
            btnAsistido.Location = new Point(582, 65);
            btnAsistido.Name = "btnAsistido";
            btnAsistido.Size = new Size(150, 25);
            btnAsistido.TabIndex = 8;
            btnAsistido.Text = "⚙ Ajuste asistido";
            btnAsistido.UseVisualStyleBackColor = true;
            btnAsistido.Click += btnAsistido_Click;
            // 
            // dgvPallets
            // 
            dgvPallets.AllowUserToAddRows = false;
            dgvPallets.AllowUserToDeleteRows = false;
            dgvPallets.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPallets.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvPallets.BackgroundColor = SystemColors.ControlLightLight;
            dgvPallets.BorderStyle = BorderStyle.Fixed3D;
            dgvPallets.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvPallets.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvPallets.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.ControlLightLight;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = Color.SteelBlue;
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvPallets.DefaultCellStyle = dataGridViewCellStyle4;
            dgvPallets.EnableHeadersVisualStyles = false;
            dgvPallets.ImeMode = ImeMode.NoControl;
            dgvPallets.Location = new Point(12, 98);
            dgvPallets.Name = "dgvPallets";
            dgvPallets.ReadOnly = true;
            dgvPallets.RowHeadersVisible = false;
            dgvPallets.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPallets.Size = new Size(988, 195);
            dgvPallets.TabIndex = 8;
            dgvPallets.SelectionChanged += dgvPallets_SelectionChanged;
            // 
            // btnGuardar
            // 
            btnGuardar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnGuardar.BackColor = Color.FromArgb(0, 120, 215);
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(12, 300);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(120, 27);
            btnGuardar.TabIndex = 9;
            btnGuardar.Text = "Mixtear / Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // txbBoxesStow
            // 
            txbBoxesStow.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txbBoxesStow.Enabled = false;
            txbBoxesStow.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            txbBoxesStow.Location = new Point(235, 303);
            txbBoxesStow.Name = "txbBoxesStow";
            txbBoxesStow.Size = new Size(50, 23);
            txbBoxesStow.TabIndex = 11;
            txbBoxesStow.TextAlign = HorizontalAlignment.Right;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(138, 306);
            label1.Name = "label1";
            label1.Size = new Size(88, 15);
            label1.TabIndex = 10;
            label1.Text = "Cajas en estiba:";
            // 
            // txbBoxesMax
            // 
            txbBoxesMax.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txbBoxesMax.Enabled = false;
            txbBoxesMax.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            txbBoxesMax.Location = new Point(400, 303);
            txbBoxesMax.Name = "txbBoxesMax";
            txbBoxesMax.Size = new Size(50, 23);
            txbBoxesMax.TabIndex = 13;
            txbBoxesMax.TextAlign = HorizontalAlignment.Right;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new Point(300, 306);
            label2.Name = "label2";
            label2.Size = new Size(94, 15);
            label2.TabIndex = 12;
            label2.Text = "Máx. cajas GTIN:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            label3.ForeColor = Color.DimGray;
            label3.Location = new Point(12, 336);
            label3.Name = "label3";
            label3.Size = new Size(401, 15);
            label3.TabIndex = 14;
            label3.Text = "▶  PALLETS A DESESTIBAR  (use '↓ Mover a desestibar' para agregarlos)";
            // 
            // btnAddToUp
            // 
            btnAddToUp.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAddToUp.Location = new Point(12, 358);
            btnAddToUp.Name = "btnAddToUp";
            btnAddToUp.Size = new Size(130, 25);
            btnAddToUp.TabIndex = 15;
            btnAddToUp.Text = "↑ Regresar a mixtear";
            btnAddToUp.UseVisualStyleBackColor = true;
            btnAddToUp.Click += btnAddToUp_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button1.ForeColor = Color.DarkRed;
            button1.Location = new Point(150, 358);
            button1.Name = "button1";
            button1.Size = new Size(120, 25);
            button1.TabIndex = 16;
            button1.Text = "Desestibar listado";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnQuitarDes
            // 
            btnQuitarDes.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnQuitarDes.ForeColor = Color.DarkRed;
            btnQuitarDes.Location = new Point(278, 358);
            btnQuitarDes.Name = "btnQuitarDes";
            btnQuitarDes.Size = new Size(90, 25);
            btnQuitarDes.TabIndex = 18;
            btnQuitarDes.Text = "✕ Quitar";
            btnQuitarDes.UseVisualStyleBackColor = true;
            btnQuitarDes.Click += btnQuitarDes_Click;
            // 
            // dgvDestibar
            // 
            dgvDestibar.AllowUserToAddRows = false;
            dgvDestibar.AllowUserToDeleteRows = false;
            dgvDestibar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDestibar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvDestibar.BackgroundColor = SystemColors.ControlLightLight;
            dgvDestibar.BorderStyle = BorderStyle.Fixed3D;
            dgvDestibar.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvDestibar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvDestibar.EnableHeadersVisualStyles = false;
            dgvDestibar.ImeMode = ImeMode.NoControl;
            dgvDestibar.Location = new Point(12, 390);
            dgvDestibar.Name = "dgvDestibar";
            dgvDestibar.ReadOnly = true;
            dgvDestibar.RowHeadersVisible = false;
            dgvDestibar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDestibar.Size = new Size(988, 238);
            dgvDestibar.TabIndex = 17;
            // 
            // FrmMixtearPallets
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1012, 645);
            Controls.Add(lblTitulo);
            Controls.Add(label4);
            Controls.Add(lblIdPallet);
            Controls.Add(txbIdPallet);
            Controls.Add(btnAddPallet);
            Controls.Add(btnQuitPallet);
            Controls.Add(btnReestibar);
            Controls.Add(btnQuitarMix);
            Controls.Add(btnAsistido);
            Controls.Add(btnReconfigurar);
            Controls.Add(dgvPallets);
            Controls.Add(btnGuardar);
            Controls.Add(label1);
            Controls.Add(txbBoxesStow);
            Controls.Add(label2);
            Controls.Add(txbBoxesMax);
            Controls.Add(label3);
            Controls.Add(btnAddToUp);
            Controls.Add(button1);
            Controls.Add(btnQuitarDes);
            Controls.Add(dgvDestibar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(900, 680);
            Name = "FrmMixtearPallets";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mixtear Pallets en Estiba";
            Load += FrmMixtearPallets_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPallets).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDestibar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        // ── Declaraciones de controles ──────────────────────────────────────────────
        public  Label        lblTitulo;
        private Label        label4;
        private Label        lblIdPallet;
        private TextBox      txbIdPallet;
        private Button       btnAddPallet;
        private Button       btnQuitPallet;
        private Button       btnReestibar;
        private Button       btnReconfigurar;
        public  DataGridView dgvPallets;
        private Button       btnGuardar;
        private TextBox      txbBoxesStow;
        private Label        label1;
        private TextBox      txbBoxesMax;
        private Label        label2;
        private Label        label3;
        private Button       btnQuitarMix;
        private Button       btnAsistido;
        private Button       btnAddToUp;
        private Button       button1;
        private Button       btnQuitarDes;
        public  DataGridView dgvDestibar;
    }
}
