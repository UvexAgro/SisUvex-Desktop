using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;

namespace SisUvex.Catalogos.RegistroMaterial
{
    partial class FrmRegistroMaterialCat
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
            btnEliminar = new Button();
            btnAgregarSalida = new Button();
            dtpEntreFecha1 = new DateTimePicker();
            btnBuscar = new Button();
            lblY = new Label();
            lblRegistros = new Label();
            dtpEntreFecha2 = new DateTimePicker();
            btnEntradas = new Button();
            btnSalidas = new Button();
            btnTodo = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCatalogo).BeginInit();
            SuspendLayout();
            // 
            // btnAñadir
            // 
            btnAñadir.Location = new Point(12, 9);
            btnAñadir.Name = "btnAñadir";
            btnAñadir.Size = new Size(102, 23);
            btnAñadir.TabIndex = 0;
            btnAñadir.Text = "Agregar entrada";
            btnAñadir.UseVisualStyleBackColor = true;
            btnAñadir.Click += btnAñadir_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(231, 9);
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
            dgvCatalogo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvCatalogo.EnableHeadersVisualStyles = false;
            dgvCatalogo.ImeMode = ImeMode.NoControl;
            dgvCatalogo.Location = new Point(12, 38);
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
            dgvCatalogo.Size = new Size(986, 601);
            dgvCatalogo.TabIndex = 4;
            dgvCatalogo.CellFormatting += dgvCatalogo_CellFormatting;
            dgvCatalogo.MouseDoubleClick += dgvCatalogo_MouseDoubleClick;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(312, 9);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 7;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnAgregarSalida
            // 
            btnAgregarSalida.Location = new Point(120, 9);
            btnAgregarSalida.Name = "btnAgregarSalida";
            btnAgregarSalida.Size = new Size(105, 23);
            btnAgregarSalida.TabIndex = 8;
            btnAgregarSalida.Text = "Agregar salida";
            btnAgregarSalida.UseVisualStyleBackColor = true;
            btnAgregarSalida.Click += btnAgregarSalida_Click;
            // 
            // dtpEntreFecha1
            // 
            dtpEntreFecha1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dtpEntreFecha1.Format = DateTimePickerFormat.Short;
            dtpEntreFecha1.Location = new Point(752, 8);
            dtpEntreFecha1.MaxDate = new DateTime(2050, 12, 31, 0, 0, 0, 0);
            dtpEntreFecha1.MinDate = new DateTime(2010, 1, 1, 0, 0, 0, 0);
            dtpEntreFecha1.Name = "dtpEntreFecha1";
            dtpEntreFecha1.Size = new Size(82, 23);
            dtpEntreFecha1.TabIndex = 143;
            // 
            // btnBuscar
            // 
            btnBuscar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnBuscar.Location = new Point(944, 9);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(54, 23);
            btnBuscar.TabIndex = 142;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // lblY
            // 
            lblY.AutoSize = true;
            lblY.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblY.Location = new Point(840, 14);
            lblY.Name = "lblY";
            lblY.Size = new Size(13, 15);
            lblY.TabIndex = 141;
            lblY.Text = "y";
            // 
            // lblRegistros
            // 
            lblRegistros.AutoSize = true;
            lblRegistros.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblRegistros.Location = new Point(658, 12);
            lblRegistros.Name = "lblRegistros";
            lblRegistros.Size = new Size(88, 15);
            lblRegistros.TabIndex = 140;
            lblRegistros.Text = "Registros entre:";
            // 
            // dtpEntreFecha2
            // 
            dtpEntreFecha2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dtpEntreFecha2.Format = DateTimePickerFormat.Short;
            dtpEntreFecha2.Location = new Point(858, 8);
            dtpEntreFecha2.MaxDate = new DateTime(2050, 12, 31, 0, 0, 0, 0);
            dtpEntreFecha2.MinDate = new DateTime(2010, 1, 1, 0, 0, 0, 0);
            dtpEntreFecha2.Name = "dtpEntreFecha2";
            dtpEntreFecha2.Size = new Size(82, 23);
            dtpEntreFecha2.TabIndex = 144;
            // 
            // btnEntradas
            // 
            btnEntradas.Location = new Point(393, 9);
            btnEntradas.Name = "btnEntradas";
            btnEntradas.Size = new Size(75, 23);
            btnEntradas.TabIndex = 145;
            btnEntradas.Text = "Entradas";
            btnEntradas.UseVisualStyleBackColor = true;
            btnEntradas.Click += btnEntradas_Click;
            // 
            // btnSalidas
            // 
            btnSalidas.Location = new Point(474, 9);
            btnSalidas.Name = "btnSalidas";
            btnSalidas.Size = new Size(75, 23);
            btnSalidas.TabIndex = 146;
            btnSalidas.Text = "Salidas";
            btnSalidas.UseVisualStyleBackColor = true;
            btnSalidas.Click += btnSalidas_Click;
            // 
            // btnTodo
            // 
            btnTodo.Location = new Point(555, 9);
            btnTodo.Name = "btnTodo";
            btnTodo.Size = new Size(75, 23);
            btnTodo.TabIndex = 147;
            btnTodo.Text = "Todas";
            btnTodo.UseVisualStyleBackColor = true;
            btnTodo.Click += btnTodo_Click;
            // 
            // FrmRegistroMaterialCat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1010, 650);
            Controls.Add(btnTodo);
            Controls.Add(btnSalidas);
            Controls.Add(btnEntradas);
            Controls.Add(dtpEntreFecha2);
            Controls.Add(dtpEntreFecha1);
            Controls.Add(btnBuscar);
            Controls.Add(lblY);
            Controls.Add(lblRegistros);
            Controls.Add(btnAgregarSalida);
            Controls.Add(btnEliminar);
            Controls.Add(dgvCatalogo);
            Controls.Add(btnModificar);
            Controls.Add(btnAñadir);
            Name = "FrmRegistroMaterialCat";
            Text = "Catálogo registro de material";
            WindowState = FormWindowState.Maximized;
            Load += FrmRegistroMaterialCat_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCatalogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAñadir;
        private Button btnModificar;
        public DataGridView dgvCatalogo;
        private Button btnEliminar;
        private Button btnAgregarSalida;
        private DateTimePicker dtpEntreFecha1;
        private Button btnBuscar;
        private Label lblY;
        private Label lblRegistros;
        private DateTimePicker dtpEntreFecha2;
        private Button btnEntradas;
        private Button btnSalidas;
        private Button btnTodo;
    }
}