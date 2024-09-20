
namespace SisUvex.Catalogos.PlanTrabajo
{
    partial class FrmPlanTrabajoCat
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
            btnAñadir = new Button();
            btnModificar = new Button();
            dgvCatalogo = new DataGridView();
            btnEliminados = new Button();
            btnRecuperar = new Button();
            btnEliminar = new Button();
            dtpFecha2 = new DateTimePicker();
            btnBuscar = new Button();
            dtpFecha1 = new DateTimePicker();
            lblY = new Label();
            lblEntre = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvCatalogo).BeginInit();
            SuspendLayout();
            // 
            // btnAñadir
            // 
            btnAñadir.Location = new Point(9, 9);
            btnAñadir.Name = "btnAñadir";
            btnAñadir.Size = new Size(75, 23);
            btnAñadir.TabIndex = 0;
            btnAñadir.Text = "Añadir";
            btnAñadir.UseVisualStyleBackColor = true;
            btnAñadir.Click += btnAñadir_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(90, 9);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 23);
            btnModificar.TabIndex = 1;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // dgvCatalogo
            // 
            dgvCatalogo.AllowUserToAddRows = false;
            dgvCatalogo.AllowUserToDeleteRows = false;
            dgvCatalogo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCatalogo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvCatalogo.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvCatalogo.BackgroundColor = SystemColors.ControlLightLight;
            dgvCatalogo.BorderStyle = BorderStyle.Fixed3D;
            dgvCatalogo.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvCatalogo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvCatalogo.ColumnHeadersHeight = 58;
            dgvCatalogo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvCatalogo.EnableHeadersVisualStyles = false;
            dgvCatalogo.ImeMode = ImeMode.NoControl;
            dgvCatalogo.Location = new Point(5, 38);
            dgvCatalogo.Name = "dgvCatalogo";
            dgvCatalogo.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvCatalogo.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvCatalogo.RowHeadersVisible = false;
            dgvCatalogo.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvCatalogo.RowTemplate.Height = 25;
            dgvCatalogo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCatalogo.Size = new Size(783, 505);
            dgvCatalogo.TabIndex = 6;
            dgvCatalogo.CellContentClick += dgvCatalogo_CellContentClick;
            dgvCatalogo.CellFormatting += dgvCatalogo_CellFormatting;
            dgvCatalogo.MouseDoubleClick += dgvCatalogo_MouseDoubleClick;
            // 
            // btnEliminados
            // 
            btnEliminados.Location = new Point(174, 9);
            btnEliminados.Margin = new Padding(1);
            btnEliminados.Name = "btnEliminados";
            btnEliminados.Size = new Size(70, 23);
            btnEliminados.TabIndex = 2;
            btnEliminados.Text = "Eliminados";
            btnEliminados.UseVisualStyleBackColor = true;
            btnEliminados.Click += btnVerDetallados_Click;
            // 
            // btnRecuperar
            // 
            btnRecuperar.Location = new Point(337, 9);
            btnRecuperar.Margin = new Padding(1);
            btnRecuperar.Name = "btnRecuperar";
            btnRecuperar.Size = new Size(80, 23);
            btnRecuperar.TabIndex = 11;
            btnRecuperar.Text = "Recuperar";
            btnRecuperar.UseVisualStyleBackColor = true;
            btnRecuperar.Click += btnRecuperar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(252, 9);
            btnEliminar.Margin = new Padding(1);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 10;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // dtpFecha2
            // 
            dtpFecha2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpFecha2.Format = DateTimePickerFormat.Short;
            dtpFecha2.Location = new Point(658, 9);
            dtpFecha2.MaxDate = new DateTime(2050, 1, 1, 0, 0, 0, 0);
            dtpFecha2.MinDate = new DateTime(2010, 1, 1, 0, 0, 0, 0);
            dtpFecha2.Name = "dtpFecha2";
            dtpFecha2.Size = new Size(95, 23);
            dtpFecha2.TabIndex = 12;
            dtpFecha2.Value = new DateTime(2023, 6, 18, 0, 0, 0, 0);
            // 
            // btnBuscar
            // 
            btnBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBuscar.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnBuscar.BackgroundImageLayout = ImageLayout.Stretch;
            btnBuscar.Location = new Point(758, 10);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(22, 22);
            btnBuscar.TabIndex = 13;
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click_1;
            // 
            // dtpFecha1
            // 
            dtpFecha1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpFecha1.Format = DateTimePickerFormat.Short;
            dtpFecha1.Location = new Point(548, 9);
            dtpFecha1.MaxDate = new DateTime(2050, 1, 1, 0, 0, 0, 0);
            dtpFecha1.MinDate = new DateTime(2010, 1, 1, 0, 0, 0, 0);
            dtpFecha1.Name = "dtpFecha1";
            dtpFecha1.Size = new Size(95, 23);
            dtpFecha1.TabIndex = 14;
            dtpFecha1.Value = new DateTime(2023, 6, 18, 0, 0, 0, 0);
            // 
            // lblY
            // 
            lblY.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblY.AutoSize = true;
            lblY.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblY.Location = new Point(642, 10);
            lblY.Name = "lblY";
            lblY.Size = new Size(18, 21);
            lblY.TabIndex = 16;
            lblY.Text = "y";
            // 
            // lblEntre
            // 
            lblEntre.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblEntre.AutoSize = true;
            lblEntre.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblEntre.Location = new Point(493, 9);
            lblEntre.Name = "lblEntre";
            lblEntre.Size = new Size(49, 21);
            lblEntre.TabIndex = 15;
            lblEntre.Text = "Entre:";
            // 
            // FrmPlanTrabajoCat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(792, 555);
            Controls.Add(dtpFecha2);
            Controls.Add(btnBuscar);
            Controls.Add(dtpFecha1);
            Controls.Add(lblY);
            Controls.Add(lblEntre);
            Controls.Add(btnRecuperar);
            Controls.Add(btnEliminar);
            Controls.Add(btnEliminados);
            Controls.Add(dgvCatalogo);
            Controls.Add(btnModificar);
            Controls.Add(btnAñadir);
            Name = "FrmPlanTrabajoCat";
            Text = "Catálogo PlanTrabajo";
            WindowState = FormWindowState.Maximized;
            Load += FrmPlanTrabajoCat_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCatalogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAñadir;
        private Button btnModificar;
        public DataGridView dgvCatalogo;
        private Button btnEliminados;
        private Button btnRecuperar;
        private Button btnEliminar;
        private DateTimePicker dtpFecha2;
        private Button btnBuscar;
        private DateTimePicker dtpFecha1;
        private Label lblY;
        private Label lblEntre;
    }
}