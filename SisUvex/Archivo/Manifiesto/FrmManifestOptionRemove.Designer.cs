namespace SisUvex.Archivo.Manifiesto
{
    partial class FrmManifestOptionRemove
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
            radioButton1 = new RadioButton();
            label1 = new Label();
            label2 = new Label();
            radioButton2 = new RadioButton();
            btnAceptar = new Button();
            btnCancelar = new Button();
            radioButton3 = new RadioButton();
            SuspendLayout();
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(12, 76);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(362, 19);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "Eliminar los pallets y que sigan permaneciendo en el manifiesto.";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(16, 9);
            label1.Name = "label1";
            label1.Size = new Size(238, 21);
            label1.TabIndex = 1;
            label1.Text = "Eliminar pallets de manifiesto";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(9, 41);
            label2.Name = "label2";
            label2.Size = new Size(343, 21);
            label2.TabIndex = 2;
            label2.Text = "¿Qué desea hacer con los pallets del manifiesto?";
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(12, 101);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(258, 19);
            radioButton2.TabIndex = 3;
            radioButton2.TabStop = true;
            radioButton2.Text = "Eliminar los pallets y sacarlos del manifiesto.";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            btnAceptar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAceptar.Location = new Point(250, 160);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(64, 25);
            btnAceptar.TabIndex = 10;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.Location = new Point(320, 160);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(64, 25);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(12, 126);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(336, 19);
            radioButton3.TabIndex = 11;
            radioButton3.TabStop = true;
            radioButton3.Text = "Solo eliminar el manifiesto y sacar los pallets como activos.";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // FrmManifestOptionRemove
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(396, 197);
            Controls.Add(radioButton3);
            Controls.Add(btnAceptar);
            Controls.Add(btnCancelar);
            Controls.Add(radioButton2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(radioButton1);
            Name = "FrmManifestOptionRemove";
            Text = "Eliminar manifiesto";
            Load += FrmManifestOptionRemove_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton radioButton1;
        private Label label1;
        private Label label2;
        private RadioButton radioButton2;
        private Button btnAceptar;
        private Button btnCancelar;
        private RadioButton radioButton3;
    }
}