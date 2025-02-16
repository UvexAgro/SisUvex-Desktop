namespace SisUvex.Nomina.Comedores.Registers.SyncRegisters
{
    partial class FrmSyncRegisters
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSyncRegisters));
            btnActualizar = new Button();
            lblTexto = new Label();
            SuspendLayout();
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(196, 15);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(77, 23);
            btnActualizar.TabIndex = 0;
            btnActualizar.Text = "Sincronizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // lblTexto
            // 
            lblTexto.AutoSize = true;
            lblTexto.Location = new Point(12, 18);
            lblTexto.Name = "lblTexto";
            lblTexto.Size = new Size(164, 15);
            lblTexto.TabIndex = 1;
            lblTexto.Text = "Sincronizar registros comedor";
            // 
            // FrmSyncRegisters
            // 
            AcceptButton = btnActualizar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(285, 49);
            Controls.Add(lblTexto);
            Controls.Add(btnActualizar);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmSyncRegisters";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sincronizar registros comedor";
            Load += FrmSyncRegisters_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnActualizar;
        private Label lblTexto;
    }
}