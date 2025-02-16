namespace SisUvex.Operacion
{
    partial class FrmCajasGranelRegistroCat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCajasGranelRegistroCat));
            btnEliminar = new Button();
            dgvCatalogo = new DataGridView();
            btnModificar = new Button();
            btnAñadir = new Button();
            dtpFecha = new DateTimePicker();
            btnSearch = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCatalogo).BeginInit();
            SuspendLayout();
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(434, 9);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 13;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // dgvCatalogo
            // 
            dgvCatalogo.AllowUserToAddRows = false;
            dgvCatalogo.AllowUserToDeleteRows = false;
            dgvCatalogo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCatalogo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvCatalogo.BackgroundColor = SystemColors.ControlLightLight;
            dgvCatalogo.BorderStyle = BorderStyle.Fixed3D;
            dgvCatalogo.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvCatalogo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvCatalogo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvCatalogo.EnableHeadersVisualStyles = false;
            dgvCatalogo.ImeMode = ImeMode.NoControl;
            dgvCatalogo.Location = new Point(9, 38);
            dgvCatalogo.Name = "dgvCatalogo";
            dgvCatalogo.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvCatalogo.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvCatalogo.RowHeadersVisible = false;
            dgvCatalogo.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvCatalogo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCatalogo.Size = new Size(783, 404);
            dgvCatalogo.TabIndex = 11;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(353, 9);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 23);
            btnModificar.TabIndex = 10;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnAñadir
            // 
            btnAñadir.Location = new Point(272, 9);
            btnAñadir.Name = "btnAñadir";
            btnAñadir.Size = new Size(75, 23);
            btnAñadir.TabIndex = 9;
            btnAñadir.Text = "Añadir";
            btnAñadir.UseVisualStyleBackColor = true;
            btnAñadir.Click += btnAñadir_Click;
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(9, 9);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(217, 23);
            dtpFecha.TabIndex = 14;
            dtpFecha.ValueChanged += dtpFecha_ValueChanged;
            // 
            // btnSearch
            // 
            btnSearch.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnSearch.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearch.Location = new Point(232, 9);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(23, 23);
            btnSearch.TabIndex = 15;
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // FrmCajasGranelRegistroCat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSearch);
            Controls.Add(dtpFecha);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnAñadir);
            Controls.Add(dgvCatalogo);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmCajasGranelRegistroCat";
            Text = "Registros granel";
            WindowState = FormWindowState.Minimized;
            Load += FrmCajasGranelRegistroCat_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCatalogo).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button btnEliminar;
        public DataGridView dgvCatalogo;
        private Button btnModificar;
        private Button btnAñadir;
        public DateTimePicker dtpFecha;
        private Button btnSearch;
    }
}