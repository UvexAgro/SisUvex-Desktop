namespace SisUvex.Nomina.Asistencia_de_empaque
{
    partial class FrmAsistenciaEmpaque
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
            btnNuevo = new Button();
            lblNuevo = new Label();
            lblEmpleado = new Label();
            btnEmpleado = new Button();
            txbEmpleado = new TextBox();
            lblDia = new Label();
            btnDia = new Button();
            dtpDia = new DateTimePicker();
            btnSeleccionar = new Button();
            SuspendLayout();
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(12, 27);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(75, 23);
            btnNuevo.TabIndex = 0;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // lblNuevo
            // 
            lblNuevo.AutoSize = true;
            lblNuevo.Location = new Point(12, 9);
            lblNuevo.Name = "lblNuevo";
            lblNuevo.Size = new Size(126, 15);
            lblNuevo.TabIndex = 1;
            lblNuevo.Text = "Cargar excel asistencia";
            // 
            // lblEmpleado
            // 
            lblEmpleado.AutoSize = true;
            lblEmpleado.Location = new Point(12, 165);
            lblEmpleado.Name = "lblEmpleado";
            lblEmpleado.Size = new Size(84, 15);
            lblEmpleado.TabIndex = 3;
            lblEmpleado.Text = "Por empleado:";
            // 
            // btnEmpleado
            // 
            btnEmpleado.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnEmpleado.BackgroundImageLayout = ImageLayout.Stretch;
            btnEmpleado.Location = new Point(204, 186);
            btnEmpleado.Name = "btnEmpleado";
            btnEmpleado.Size = new Size(23, 23);
            btnEmpleado.TabIndex = 2;
            btnEmpleado.UseVisualStyleBackColor = true;
            btnEmpleado.Click += btnEmpleado_Click;
            // 
            // txbEmpleado
            // 
            txbEmpleado.Location = new Point(93, 187);
            txbEmpleado.Name = "txbEmpleado";
            txbEmpleado.Size = new Size(105, 23);
            txbEmpleado.TabIndex = 4;
            // 
            // lblDia
            // 
            lblDia.AutoSize = true;
            lblDia.Location = new Point(12, 83);
            lblDia.Name = "lblDia";
            lblDia.Size = new Size(47, 15);
            lblDia.TabIndex = 6;
            lblDia.Text = "Por día:";
            // 
            // btnDia
            // 
            btnDia.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnDia.BackgroundImageLayout = ImageLayout.Stretch;
            btnDia.Location = new Point(242, 101);
            btnDia.Name = "btnDia";
            btnDia.Size = new Size(23, 23);
            btnDia.TabIndex = 5;
            btnDia.UseVisualStyleBackColor = true;
            btnDia.Click += btnDia_Click;
            // 
            // dtpDia
            // 
            dtpDia.Location = new Point(12, 101);
            dtpDia.Name = "dtpDia";
            dtpDia.Size = new Size(224, 23);
            dtpDia.TabIndex = 7;
            // 
            // btnSeleccionar
            // 
            btnSeleccionar.Location = new Point(12, 186);
            btnSeleccionar.Name = "btnSeleccionar";
            btnSeleccionar.Size = new Size(75, 23);
            btnSeleccionar.TabIndex = 8;
            btnSeleccionar.Text = "Seleccionar";
            btnSeleccionar.UseVisualStyleBackColor = true;
            // 
            // FrmAsistenciaEmpaque
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(279, 221);
            Controls.Add(btnSeleccionar);
            Controls.Add(dtpDia);
            Controls.Add(lblDia);
            Controls.Add(btnDia);
            Controls.Add(txbEmpleado);
            Controls.Add(lblEmpleado);
            Controls.Add(btnEmpleado);
            Controls.Add(lblNuevo);
            Controls.Add(btnNuevo);
            Name = "FrmAsistenciaEmpaque";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Asistencia de empaque";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnNuevo;
        private Label lblNuevo;
        private Label lblEmpleado;
        private Button btnEmpleado;
        private Label lblDia;
        private Button btnDia;
        public DateTimePicker dtpDia;
        private Button btnSeleccionar;
        public TextBox txbEmpleado;
    }
}