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
            label5 = new Label();
            CboStatus = new ComboBox();
            label4 = new Label();
            CboIDComedor = new ComboBox();
            label3 = new Label();
            label6 = new Label();
            label7 = new Label();
            button1 = new Button();
            txtIDEmpleado = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            SuspendLayout();
            // 
            // btnBuscar
            // 
            btnBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBuscar.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            btnBuscar.Location = new Point(445, 141);
            btnBuscar.Margin = new Padding(4, 3, 4, 3);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(66, 23);
            btnBuscar.TabIndex = 6;
            btnBuscar.Text = "...";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnMostrar
            // 
            btnMostrar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMostrar.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            btnMostrar.Location = new Point(609, 182);
            btnMostrar.Margin = new Padding(4, 3, 4, 3);
            btnMostrar.Name = "btnMostrar";
            btnMostrar.Size = new Size(84, 23);
            btnMostrar.TabIndex = 8;
            btnMostrar.Text = "Mostrar";
            btnMostrar.UseVisualStyleBackColor = true;
            btnMostrar.Click += btnMostrar_Click;
            // 
            // btnRegistrarData
            // 
            btnRegistrarData.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRegistrarData.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            btnRegistrarData.Location = new Point(547, 418);
            btnRegistrarData.Margin = new Padding(4, 3, 4, 3);
            btnRegistrarData.Name = "btnRegistrarData";
            btnRegistrarData.Size = new Size(144, 27);
            btnRegistrarData.TabIndex = 9;
            btnRegistrarData.Text = "Registrar Data";
            btnRegistrarData.UseVisualStyleBackColor = true;
            btnRegistrarData.Click += btnRegistrarData_Click;
            // 
            // dgvDatos
            // 
            dgvDatos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.Location = new Point(16, 220);
            dgvDatos.Margin = new Padding(4, 3, 4, 3);
            dgvDatos.Name = "dgvDatos";
            dgvDatos.Size = new Size(677, 192);
            dgvDatos.TabIndex = 9;
            dgvDatos.CellContentClick += dgvDatos_CellContentClick;
            // 
            // cboHojas
            // 
            cboHojas.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboHojas.FormattingEnabled = true;
            cboHojas.Location = new Point(173, 182);
            cboHojas.Margin = new Padding(4, 3, 4, 3);
            cboHojas.Name = "cboHojas";
            cboHojas.Size = new Size(428, 23);
            cboHojas.TabIndex = 7;
            // 
            // progressBar
            // 
            progressBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            progressBar.ForeColor = Color.Blue;
            progressBar.Location = new Point(13, 422);
            progressBar.Margin = new Padding(4, 3, 4, 3);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(354, 23);
            progressBar.TabIndex = 5;
            // 
            // lblProgress
            // 
            lblProgress.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblProgress.AutoSize = true;
            lblProgress.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            lblProgress.Location = new Point(375, 427);
            lblProgress.Margin = new Padding(4, 0, 4, 0);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new Size(31, 18);
            lblProgress.TabIndex = 6;
            lblProgress.Text = "0%";
            // 
            // txtRuta
            // 
            txtRuta.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtRuta.Location = new Point(75, 141);
            txtRuta.Margin = new Padding(4, 3, 4, 3);
            txtRuta.Name = "txtRuta";
            txtRuta.Size = new Size(350, 23);
            txtRuta.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            label1.Location = new Point(16, 143);
            label1.Name = "label1";
            label1.Size = new Size(48, 18);
            label1.TabIndex = 8;
            label1.Text = "Ruta:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            label2.Location = new Point(16, 182);
            label2.Name = "label2";
            label2.Size = new Size(157, 18);
            label2.TabIndex = 9;
            label2.Text = "Hojas Encontradas:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            label5.Location = new Point(385, 56);
            label5.Name = "label5";
            label5.Size = new Size(61, 18);
            label5.TabIndex = 21;
            label5.Text = "Status:";
            // 
            // CboStatus
            // 
            CboStatus.FormattingEnabled = true;
            CboStatus.Location = new Point(452, 53);
            CboStatus.Name = "CboStatus";
            CboStatus.Size = new Size(54, 23);
            CboStatus.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            label4.Location = new Point(231, 56);
            label4.Name = "label4";
            label4.Size = new Size(83, 18);
            label4.TabIndex = 19;
            label4.Text = "Comedor:";
            // 
            // CboIDComedor
            // 
            CboIDComedor.FormattingEnabled = true;
            CboIDComedor.Location = new Point(320, 53);
            CboIDComedor.Name = "CboIDComedor";
            CboIDComedor.Size = new Size(56, 23);
            CboIDComedor.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            label3.Location = new Point(16, 56);
            label3.Name = "label3";
            label3.Size = new Size(109, 18);
            label3.TabIndex = 17;
            label3.Text = "ID Empleado:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold);
            label6.Location = new Point(213, 9);
            label6.Name = "label6";
            label6.Size = new Size(293, 29);
            label6.TabIndex = 22;
            label6.Text = "REGISTRO INDIVIDUAL";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold);
            label7.Location = new Point(231, 99);
            label7.Name = "label7";
            label7.Size = new Size(250, 29);
            label7.TabIndex = 23;
            label7.Text = "REGISTRO MASIVO";
            // 
            // button1
            // 
            button1.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            button1.Location = new Point(533, 53);
            button1.Name = "button1";
            button1.Size = new Size(146, 25);
            button1.TabIndex = 4;
            button1.Text = "REGISTRAR";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txtIDEmpleado
            // 
            txtIDEmpleado.Location = new Point(131, 53);
            txtIDEmpleado.Name = "txtIDEmpleado";
            txtIDEmpleado.Size = new Size(100, 23);
            txtIDEmpleado.TabIndex = 1;
            txtIDEmpleado.TextChanged += TxtIDEmpleado_TextChanged;
            txtIDEmpleado.KeyPress += TxtIDEmpleado_KeyPress;
            // 
            // UExcel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(704, 457);
            Controls.Add(txtIDEmpleado);
            Controls.Add(button1);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(CboStatus);
            Controls.Add(label4);
            Controls.Add(CboIDComedor);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtRuta);
            Controls.Add(lblProgress);
            Controls.Add(progressBar);
            Controls.Add(cboHojas);
            Controls.Add(dgvDatos);
            Controls.Add(btnRegistrarData);
            Controls.Add(btnMostrar);
            Controls.Add(btnBuscar);
            Margin = new Padding(4, 3, 4, 3);
            MinimumSize = new Size(625, 395);
            Name = "UExcel";
            Text = "UExcel";
            Load += UExcel_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void txtRuta_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Button btnBuscar;
        private Button btnMostrar;
        private Button btnRegistrarData;
        private DataGridView dgvDatos;
        private ComboBox cboHojas;
        private ProgressBar progressBar;
        private Label lblProgress;
        private TextBox txtRuta;
        private Label label1;
        private Label label2;
        private Label label5;
        private ComboBox CboStatus;
        private Label label4;
        private ComboBox CboIDComedor;
        private Label label3;
        private Label label6;
        private Label label7;
        private Button button1;
        private TextBox txtIDEmpleado;
    }
}
