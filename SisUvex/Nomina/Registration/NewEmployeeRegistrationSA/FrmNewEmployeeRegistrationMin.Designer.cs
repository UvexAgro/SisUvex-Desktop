namespace SisUvex.Nomina.Registration.NewEmployeeRegistrationSA
{
    partial class FrmNewEmployeeRegistrationMin
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNewEmployeeRegistrationMin));
            txbLastNamePat = new TextBox();
            txbLastNameMat = new TextBox();
            txbName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            cboSex = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            txbIdEmployee = new TextBox();
            dtpDateRegister = new DateTimePicker();
            label7 = new Label();
            btnRegister = new Button();
            label6 = new Label();
            cboHojas = new ComboBox();
            label8 = new Label();
            btnMostrar = new Button();
            txtRuta = new TextBox();
            btnBuscar = new Button();
            dgvDatos = new DataGridView();
            btnRegisterMultiple = new Button();
            gpbMultiple = new GroupBox();
            gpbIndividual = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            gpbMultiple.SuspendLayout();
            gpbIndividual.SuspendLayout();
            SuspendLayout();
            // 
            // txbLastNamePat
            // 
            txbLastNamePat.Font = new Font("Segoe UI", 9F);
            txbLastNamePat.Location = new Point(133, 84);
            txbLastNamePat.Name = "txbLastNamePat";
            txbLastNamePat.Size = new Size(219, 23);
            txbLastNamePat.TabIndex = 2;
            // 
            // txbLastNameMat
            // 
            txbLastNameMat.Font = new Font("Segoe UI", 9F);
            txbLastNameMat.Location = new Point(133, 113);
            txbLastNameMat.Name = "txbLastNameMat";
            txbLastNameMat.Size = new Size(219, 23);
            txbLastNameMat.TabIndex = 3;
            // 
            // txbName
            // 
            txbName.Font = new Font("Segoe UI", 9F);
            txbName.Location = new Point(133, 142);
            txbName.Name = "txbName";
            txbName.Size = new Size(219, 23);
            txbName.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F);
            label1.Location = new Point(32, 87);
            label1.Name = "label1";
            label1.Size = new Size(95, 15);
            label1.TabIndex = 3;
            label1.Text = "Apellido paterno";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F);
            label2.Location = new Point(28, 116);
            label2.Name = "label2";
            label2.Size = new Size(99, 15);
            label2.TabIndex = 4;
            label2.Text = "Apellido materno";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F);
            label3.Location = new Point(76, 145);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 5;
            label3.Text = "Nombre";
            // 
            // cboSex
            // 
            cboSex.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSex.Font = new Font("Segoe UI", 9F);
            cboSex.FormattingEnabled = true;
            cboSex.Items.AddRange(new object[] { "M", "F" });
            cboSex.Location = new Point(316, 55);
            cboSex.Name = "cboSex";
            cboSex.Size = new Size(36, 23);
            cboSex.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F);
            label4.Location = new Point(281, 58);
            label4.Name = "label4";
            label4.Size = new Size(32, 15);
            label4.TabIndex = 7;
            label4.Text = "Sexo";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F);
            label5.Location = new Point(9, 58);
            label5.Name = "label5";
            label5.Size = new Size(118, 15);
            label5.TabIndex = 9;
            label5.Text = "Código de empleado";
            // 
            // txbIdEmployee
            // 
            txbIdEmployee.Font = new Font("Segoe UI", 9F);
            txbIdEmployee.Location = new Point(133, 55);
            txbIdEmployee.Name = "txbIdEmployee";
            txbIdEmployee.Size = new Size(95, 23);
            txbIdEmployee.TabIndex = 1;
            // 
            // dtpDateRegister
            // 
            dtpDateRegister.CustomFormat = "dd    'de'MMMM'de'   yyyy";
            dtpDateRegister.Font = new Font("Segoe UI", 9F);
            dtpDateRegister.Format = DateTimePickerFormat.Custom;
            dtpDateRegister.Location = new Point(133, 26);
            dtpDateRegister.Name = "dtpDateRegister";
            dtpDateRegister.Size = new Size(179, 23);
            dtpDateRegister.TabIndex = 0;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F);
            label7.Location = new Point(31, 32);
            label7.Name = "label7";
            label7.Size = new Size(96, 15);
            label7.TabIndex = 12;
            label7.Text = "Fecha de ingreso";
            // 
            // btnRegister
            // 
            btnRegister.Font = new Font("Segoe UI", 9F);
            btnRegister.Location = new Point(358, 141);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(66, 23);
            btnRegister.TabIndex = 6;
            btnRegister.Text = "Registrar";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F);
            label6.Location = new Point(5, 56);
            label6.Name = "label6";
            label6.Size = new Size(108, 15);
            label6.TabIndex = 19;
            label6.Text = "Hojas Encontradas:";
            // 
            // cboHojas
            // 
            cboHojas.DropDownStyle = ComboBoxStyle.DropDownList;
            cboHojas.Font = new Font("Segoe UI", 9F);
            cboHojas.FormattingEnabled = true;
            cboHojas.Location = new Point(120, 52);
            cboHojas.Margin = new Padding(4, 3, 4, 3);
            cboHojas.Name = "cboHojas";
            cboHojas.Size = new Size(395, 23);
            cboHojas.TabIndex = 15;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F);
            label8.Location = new Point(5, 30);
            label8.Name = "label8";
            label8.Size = new Size(34, 15);
            label8.TabIndex = 18;
            label8.Text = "Ruta:";
            // 
            // btnMostrar
            // 
            btnMostrar.Font = new Font("Segoe UI", 9F);
            btnMostrar.Location = new Point(523, 52);
            btnMostrar.Margin = new Padding(4, 3, 4, 3);
            btnMostrar.Name = "btnMostrar";
            btnMostrar.Size = new Size(66, 23);
            btnMostrar.TabIndex = 16;
            btnMostrar.Text = "Mostrar";
            btnMostrar.UseVisualStyleBackColor = true;
            btnMostrar.Click += btnMostrar_Click;
            // 
            // txtRuta
            // 
            txtRuta.Enabled = false;
            txtRuta.Font = new Font("Segoe UI", 9F);
            txtRuta.Location = new Point(46, 26);
            txtRuta.Margin = new Padding(4, 3, 4, 3);
            txtRuta.Name = "txtRuta";
            txtRuta.Size = new Size(469, 23);
            txtRuta.TabIndex = 13;
            // 
            // btnBuscar
            // 
            btnBuscar.Font = new Font("Segoe UI", 9F);
            btnBuscar.Location = new Point(523, 26);
            btnBuscar.Margin = new Padding(4, 3, 4, 3);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(66, 23);
            btnBuscar.TabIndex = 14;
            btnBuscar.Text = "Examinar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
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
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvDatos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvDatos.DefaultCellStyle = dataGridViewCellStyle2;
            dgvDatos.EnableHeadersVisualStyles = false;
            dgvDatos.Location = new Point(7, 81);
            dgvDatos.Margin = new Padding(4, 3, 4, 3);
            dgvDatos.MultiSelect = false;
            dgvDatos.Name = "dgvDatos";
            dgvDatos.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvDatos.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvDatos.RowHeadersVisible = false;
            dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDatos.ShowCellErrors = false;
            dgvDatos.ShowCellToolTips = false;
            dgvDatos.ShowEditingIcon = false;
            dgvDatos.ShowRowErrors = false;
            dgvDatos.Size = new Size(653, 349);
            dgvDatos.TabIndex = 17;
            // 
            // btnRegisterMultiple
            // 
            btnRegisterMultiple.Font = new Font("Segoe UI", 9F);
            btnRegisterMultiple.Location = new Point(596, 50);
            btnRegisterMultiple.Name = "btnRegisterMultiple";
            btnRegisterMultiple.Size = new Size(66, 23);
            btnRegisterMultiple.TabIndex = 20;
            btnRegisterMultiple.Text = "Registrar";
            btnRegisterMultiple.UseVisualStyleBackColor = true;
            btnRegisterMultiple.Click += btnRegisterMultiple_Click;
            // 
            // gpbMultiple
            // 
            gpbMultiple.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gpbMultiple.Controls.Add(btnRegisterMultiple);
            gpbMultiple.Controls.Add(btnBuscar);
            gpbMultiple.Controls.Add(label6);
            gpbMultiple.Controls.Add(dgvDatos);
            gpbMultiple.Controls.Add(cboHojas);
            gpbMultiple.Controls.Add(txtRuta);
            gpbMultiple.Controls.Add(label8);
            gpbMultiple.Controls.Add(btnMostrar);
            gpbMultiple.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            gpbMultiple.Location = new Point(8, 198);
            gpbMultiple.Name = "gpbMultiple";
            gpbMultiple.Size = new Size(668, 439);
            gpbMultiple.TabIndex = 21;
            gpbMultiple.TabStop = false;
            gpbMultiple.Text = "REGISTRAR EMPLEADOS MULTIPLES";
            // 
            // gpbIndividual
            // 
            gpbIndividual.Controls.Add(btnRegister);
            gpbIndividual.Controls.Add(txbName);
            gpbIndividual.Controls.Add(label7);
            gpbIndividual.Controls.Add(txbLastNamePat);
            gpbIndividual.Controls.Add(dtpDateRegister);
            gpbIndividual.Controls.Add(txbLastNameMat);
            gpbIndividual.Controls.Add(label5);
            gpbIndividual.Controls.Add(label1);
            gpbIndividual.Controls.Add(txbIdEmployee);
            gpbIndividual.Controls.Add(label2);
            gpbIndividual.Controls.Add(label4);
            gpbIndividual.Controls.Add(label3);
            gpbIndividual.Controls.Add(cboSex);
            gpbIndividual.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            gpbIndividual.Location = new Point(8, 4);
            gpbIndividual.Name = "gpbIndividual";
            gpbIndividual.Size = new Size(437, 188);
            gpbIndividual.TabIndex = 22;
            gpbIndividual.TabStop = false;
            gpbIndividual.Text = "REGISTRAR EMPLEADO INDIVIDUAL";
            // 
            // FrmNewEmployeeRegistrationMin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 644);
            Controls.Add(gpbMultiple);
            Controls.Add(gpbIndividual);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmNewEmployeeRegistrationMin";
            Text = "Registrar empleado";
            WindowState = FormWindowState.Maximized;
            Load += FrmNewEmployeeRegistrationMin_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            gpbMultiple.ResumeLayout(false);
            gpbMultiple.PerformLayout();
            gpbIndividual.ResumeLayout(false);
            gpbIndividual.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        public DateTimePicker dtpDateRegister;
        private Label label7;
        private Button btnRegister;
        public TextBox txbLastNamePat;
        public TextBox txbLastNameMat;
        public TextBox txbName;
        public ComboBox cboSex;
        public TextBox txbIdEmployee;
        private Label label6;
        private ComboBox cboHojas;
        private Label label8;
        private Button btnMostrar;
        private TextBox txtRuta;
        private Button btnBuscar;
        public DataGridView dgvDatos;
        private Button btnRegisterMultiple;
        private GroupBox gpbMultiple;
        private GroupBox gpbIndividual;
    }
}