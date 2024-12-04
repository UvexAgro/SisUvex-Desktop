namespace SisUvex.Nomina.Actualizar_empleados
{
    partial class FrmActualizarEmpleados
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
            btnActualizar = new Button();
            lblTexto = new Label();
            SuspendLayout();
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(205, 14);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(68, 23);
            btnActualizar.TabIndex = 0;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += button1_Click;
            // 
            // lblTexto
            // 
            lblTexto.AutoSize = true;
            lblTexto.Location = new Point(12, 18);
            lblTexto.Name = "lblTexto";
            lblTexto.Size = new Size(165, 15);
            lblTexto.TabIndex = 1;
            lblTexto.Text = "Actualizar tabla de empleados";
            // 
            // FrmActualizarEmpleados
            // 
            AcceptButton = btnActualizar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(285, 49);
            Controls.Add(lblTexto);
            Controls.Add(btnActualizar);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmActualizarEmpleados";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Actualizar empleados";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnActualizar;
        private Label lblTexto;
    }
}