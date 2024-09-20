namespace SisUvex.Nomina.Asistencia_de_empaque
{
    partial class FrmInstruccionesExcelAsistencia
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
            pbxImagen = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbxImagen).BeginInit();
            SuspendLayout();
            // 
            // pbxImagen
            // 
            pbxImagen.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pbxImagen.Image = Properties.Resources.Instrucciones_cargar_excel_asistencia_de_empaque;
            pbxImagen.Location = new Point(12, 12);
            pbxImagen.Name = "pbxImagen";
            pbxImagen.Size = new Size(592, 358);
            pbxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxImagen.TabIndex = 0;
            pbxImagen.TabStop = false;
            // 
            // FrmInstruccionesExcelAsistencia
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(616, 382);
            Controls.Add(pbxImagen);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmInstruccionesExcelAsistencia";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Instrucciones cargar archivo excel de asistencia de empaque";
            ((System.ComponentModel.ISupportInitialize)pbxImagen).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbxImagen;
    }
}