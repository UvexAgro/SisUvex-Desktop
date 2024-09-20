﻿namespace SisUvex.Catalogos.Categoría
{
    partial class FrmCategoriaCat
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
            dgvCatalogo = new DataGridView();
            btnModificar = new Button();
            btnAñadir = new Button();
            btnEliminados = new Button();
            btnEliminar = new Button();
            btnRecuperar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCatalogo).BeginInit();
            SuspendLayout();
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
            dgvCatalogo.RowTemplate.Height = 25;
            dgvCatalogo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCatalogo.Size = new Size(783, 404);
            dgvCatalogo.TabIndex = 10;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(90, 9);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 23);
            btnModificar.TabIndex = 7;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnAñadir
            // 
            btnAñadir.Location = new Point(9, 9);
            btnAñadir.Name = "btnAñadir";
            btnAñadir.Size = new Size(75, 23);
            btnAñadir.TabIndex = 6;
            btnAñadir.Text = "Añadir";
            btnAñadir.UseVisualStyleBackColor = true;
            btnAñadir.Click += btnAñadir_Click;
            // 
            // btnEliminados
            // 
            btnEliminados.Location = new Point(333, 9);
            btnEliminados.Name = "btnEliminados";
            btnEliminados.Size = new Size(75, 23);
            btnEliminados.TabIndex = 12;
            btnEliminados.Text = "Eliminados";
            btnEliminados.UseVisualStyleBackColor = true;
            btnEliminados.Click += btnEliminados_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(171, 9);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 11;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnRecuperar
            // 
            btnRecuperar.Location = new Point(252, 9);
            btnRecuperar.Name = "btnRecuperar";
            btnRecuperar.Size = new Size(75, 23);
            btnRecuperar.TabIndex = 13;
            btnRecuperar.Text = "Recuperar";
            btnRecuperar.UseVisualStyleBackColor = true;
            btnRecuperar.Click += btnRecuperar_Click;
            // 
            // FrmCategoriaCat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRecuperar);
            Controls.Add(btnEliminados);
            Controls.Add(btnEliminar);
            Controls.Add(dgvCatalogo);
            Controls.Add(btnModificar);
            Controls.Add(btnAñadir);
            Name = "FrmCategoriaCat";
            Text = "Catálogo categoría";
            WindowState = FormWindowState.Maximized;
            Load += FrmCategoriaCat_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCatalogo).EndInit();
            ResumeLayout(false);
        }

        #endregion
        public DataGridView dgvCatalogo;
        private Button btnModificar;
        private Button btnAñadir;
        private Button btnEliminar;
        private Button btnRecuperar;
        public Button btnEliminados;
    }
}