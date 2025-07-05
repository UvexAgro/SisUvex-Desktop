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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCajasGranelRegistroCat));
            btnEliminar = new Button();
            dgvCatalogo = new DataGridView();
            btnModificar = new Button();
            btnAñadir = new Button();
            dtpFecha1 = new DateTimePicker();
            btnSearch = new Button();
            dtpFecha2 = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvCatalogo).BeginInit();
            SuspendLayout();
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(171, 49);
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
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvCatalogo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvCatalogo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvCatalogo.EnableHeadersVisualStyles = false;
            dgvCatalogo.ImeMode = ImeMode.NoControl;
            dgvCatalogo.Location = new Point(9, 78);
            dgvCatalogo.Name = "dgvCatalogo";
            dgvCatalogo.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvCatalogo.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvCatalogo.RowHeadersVisible = false;
            dgvCatalogo.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvCatalogo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCatalogo.Size = new Size(783, 364);
            dgvCatalogo.TabIndex = 11;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(90, 49);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 23);
            btnModificar.TabIndex = 10;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnAñadir
            // 
            btnAñadir.Location = new Point(9, 49);
            btnAñadir.Name = "btnAñadir";
            btnAñadir.Size = new Size(75, 23);
            btnAñadir.TabIndex = 9;
            btnAñadir.Text = "Añadir";
            btnAñadir.UseVisualStyleBackColor = true;
            btnAñadir.Click += btnAñadir_Click;
            // 
            // dtpFecha1
            // 
            dtpFecha1.Location = new Point(9, 20);
            dtpFecha1.Name = "dtpFecha1";
            dtpFecha1.Size = new Size(217, 23);
            dtpFecha1.TabIndex = 14;
            dtpFecha1.ValueChanged += dtpFecha_ValueChanged;
            // 
            // btnSearch
            // 
            btnSearch.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnSearch.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearch.Location = new Point(460, 19);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(25, 25);
            btnSearch.TabIndex = 15;
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // dtpFecha2
            // 
            dtpFecha2.Location = new Point(240, 20);
            dtpFecha2.Name = "dtpFecha2";
            dtpFecha2.Size = new Size(217, 23);
            dtpFecha2.TabIndex = 16;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 6.75F);
            label1.Location = new Point(9, 7);
            label1.Name = "label1";
            label1.Size = new Size(26, 12);
            label1.TabIndex = 31;
            label1.Text = "Entre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 6.75F);
            label2.Location = new Point(229, 28);
            label2.Name = "label2";
            label2.Size = new Size(9, 12);
            label2.TabIndex = 32;
            label2.Text = "y";
            // 
            // FrmCajasGranelRegistroCat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dtpFecha2);
            Controls.Add(btnSearch);
            Controls.Add(dtpFecha1);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnAñadir);
            Controls.Add(dgvCatalogo);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmCajasGranelRegistroCat";
            Text = "Registros granel";
            WindowState = FormWindowState.Maximized;
            Load += FrmCajasGranelRegistroCat_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCatalogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnEliminar;
        public DataGridView dgvCatalogo;
        private Button btnModificar;
        private Button btnAñadir;
        public DateTimePicker dtpFecha1;
        private Button btnSearch;
        public DateTimePicker dtpFecha2;
        private Label label1;
        private Label label2;
    }
}