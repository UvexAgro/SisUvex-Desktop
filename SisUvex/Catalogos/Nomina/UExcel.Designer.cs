namespace SisUvex.Nomina
{
    partial class UExcel
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UExcel));
            btnBuscar = new Button();
            btnMostrar = new Button();
            btnRegistrarData = new Button();
            dgvDatos = new DataGridView();
            cboHojas = new ComboBox();
            progressBar = new ProgressBar();
            lblProgress = new Label();
            txtRuta = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label4 = new Label();
            CboIDComedor = new ComboBox();
            label3 = new Label();
            label6 = new Label();
            label7 = new Label();
            btnRegistroIndividual = new Button();
            txbIDEmpleado = new TextBox();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // btnBuscar
            // 
            btnBuscar.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            btnBuscar.Location = new Point(588, 41);
            btnBuscar.Margin = new Padding(4, 3, 4, 3);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(84, 23);
            btnBuscar.TabIndex = 4;
            btnBuscar.Text = "Examinar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnMostrar
            // 
            btnMostrar.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            btnMostrar.Location = new Point(588, 67);
            btnMostrar.Margin = new Padding(4, 3, 4, 3);
            btnMostrar.Name = "btnMostrar";
            btnMostrar.Size = new Size(84, 23);
            btnMostrar.TabIndex = 6;
            btnMostrar.Text = "Mostrar";
            btnMostrar.UseVisualStyleBackColor = true;
            btnMostrar.Click += btnMostrar_Click;
            // 
            // btnRegistrarData
            // 
            btnRegistrarData.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnRegistrarData.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            btnRegistrarData.Location = new Point(7, 483);
            btnRegistrarData.Margin = new Padding(4, 3, 4, 3);
            btnRegistrarData.Name = "btnRegistrarData";
            btnRegistrarData.Size = new Size(144, 27);
            btnRegistrarData.TabIndex = 8;
            btnRegistrarData.Text = "Registrar Data";
            btnRegistrarData.UseVisualStyleBackColor = true;
            btnRegistrarData.Click += btnRegistrarData_Click;
            // 
            // dgvDatos
            // 
            dgvDatos.AllowUserToAddRows = false;
            dgvDatos.AllowUserToDeleteRows = false;
            dgvDatos.AllowUserToResizeRows = false;
            dgvDatos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvDatos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvDatos.BackgroundColor = SystemColors.ControlLight;
            dgvDatos.BorderStyle = BorderStyle.Fixed3D;
            dgvDatos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.EnableHeadersVisualStyles = false;
            dgvDatos.Location = new Point(19, 225);
            dgvDatos.Margin = new Padding(4, 3, 4, 3);
            dgvDatos.MultiSelect = false;
            dgvDatos.Name = "dgvDatos";
            dgvDatos.ReadOnly = true;
            dgvDatos.RowHeadersVisible = false;
            dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDatos.ShowCellErrors = false;
            dgvDatos.ShowCellToolTips = false;
            dgvDatos.ShowEditingIcon = false;
            dgvDatos.ShowRowErrors = false;
            dgvDatos.Size = new Size(709, 367);
            dgvDatos.TabIndex = 7;
            // 
            // cboHojas
            // 
            cboHojas.FormattingEnabled = true;
            cboHojas.Location = new Point(173, 67);
            cboHojas.Margin = new Padding(4, 3, 4, 3);
            cboHojas.Name = "cboHojas";
            cboHojas.Size = new Size(407, 23);
            cboHojas.TabIndex = 5;
            // 
            // progressBar
            // 
            progressBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            progressBar.ForeColor = Color.Blue;
            progressBar.Location = new Point(157, 483);
            progressBar.Margin = new Padding(4, 3, 4, 3);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(340, 27);
            progressBar.TabIndex = 5;
            // 
            // lblProgress
            // 
            lblProgress.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblProgress.AutoSize = true;
            lblProgress.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            lblProgress.Location = new Point(505, 487);
            lblProgress.Margin = new Padding(4, 0, 4, 0);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new Size(31, 18);
            lblProgress.TabIndex = 6;
            lblProgress.Text = "0%";
            // 
            // txtRuta
            // 
            txtRuta.Location = new Point(68, 41);
            txtRuta.Margin = new Padding(4, 3, 4, 3);
            txtRuta.Name = "txtRuta";
            txtRuta.Size = new Size(512, 23);
            txtRuta.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            label1.Location = new Point(9, 43);
            label1.Name = "label1";
            label1.Size = new Size(48, 18);
            label1.TabIndex = 8;
            label1.Text = "Ruta:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            label2.Location = new Point(9, 67);
            label2.Name = "label2";
            label2.Size = new Size(157, 18);
            label2.TabIndex = 9;
            label2.Text = "Hojas Encontradas:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            label4.Location = new Point(262, 42);
            label4.Name = "label4";
            label4.Size = new Size(83, 18);
            label4.TabIndex = 19;
            label4.Text = "Comedor:";
            // 
            // CboIDComedor
            // 
            CboIDComedor.DropDownStyle = ComboBoxStyle.DropDownList;
            CboIDComedor.FormattingEnabled = true;
            CboIDComedor.Location = new Point(351, 40);
            CboIDComedor.Name = "CboIDComedor";
            CboIDComedor.Size = new Size(207, 23);
            CboIDComedor.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            label3.Location = new Point(9, 42);
            label3.Name = "label3";
            label3.Size = new Size(109, 18);
            label3.TabIndex = 17;
            label3.Text = "ID Empleado:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold);
            label6.Location = new Point(227, -3);
            label6.Name = "label6";
            label6.Size = new Size(293, 29);
            label6.TabIndex = 22;
            label6.Text = "REGISTRO INDIVIDUAL";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold);
            label7.Location = new Point(248, -5);
            label7.Name = "label7";
            label7.Size = new Size(250, 29);
            label7.TabIndex = 23;
            label7.Text = "REGISTRO MASIVO";
            // 
            // btnRegistroIndividual
            // 
            btnRegistroIndividual.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            btnRegistroIndividual.Location = new Point(562, 39);
            btnRegistroIndividual.Name = "btnRegistroIndividual";
            btnRegistroIndividual.Size = new Size(146, 25);
            btnRegistroIndividual.TabIndex = 2;
            btnRegistroIndividual.Text = "REGISTRAR";
            btnRegistroIndividual.UseVisualStyleBackColor = true;
            btnRegistroIndividual.Click += btnRegistroIndividual_Click;
            // 
            // txbIDEmpleado
            // 
            txbIDEmpleado.Location = new Point(124, 40);
            txbIDEmpleado.MaxLength = 6;
            txbIDEmpleado.Name = "txbIDEmpleado";
            txbIDEmpleado.Size = new Size(100, 23);
            txbIDEmpleado.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txbIDEmpleado);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(btnRegistroIndividual);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(CboIDComedor);
            groupBox1.Controls.Add(label4);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(723, 84);
            groupBox1.TabIndex = 24;
            groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(progressBar);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(cboHojas);
            groupBox2.Controls.Add(btnRegistrarData);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(btnMostrar);
            groupBox2.Controls.Add(txtRuta);
            groupBox2.Controls.Add(lblProgress);
            groupBox2.Controls.Add(btnBuscar);
            groupBox2.Location = new Point(12, 115);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(723, 516);
            groupBox2.TabIndex = 25;
            groupBox2.TabStop = false;
            // 
            // UExcel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(747, 643);
            Controls.Add(dgvDatos);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MinimumSize = new Size(625, 395);
            Name = "UExcel";
            Text = "Asignar comedor a empleados";
            WindowState = FormWindowState.Maximized;
            Load += UExcel_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        private void txtRuta_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Button btnBuscar;
        private Button btnMostrar;
        private Button btnRegistrarData;
        private ComboBox cboHojas;
        private ProgressBar progressBar;
        private Label lblProgress;
        private TextBox txtRuta;
        private Label label1;
        private Label label2;
        private Label label4;
        private ComboBox CboIDComedor;
        private Label label3;
        private Label label6;
        private Label label7;
        private Button btnRegistroIndividual;
        private TextBox txbIDEmpleado;
        public DataGridView dgvDatos;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
    }
}
