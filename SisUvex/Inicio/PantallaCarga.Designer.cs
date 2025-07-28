namespace SisUvex.Inicio
{
    partial class PantallaCarga
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PantallaCarga));
            lblCadenaConexion = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // lblCadenaConexion
            // 
            lblCadenaConexion.AutoSize = true;
            lblCadenaConexion.BackColor = Color.Transparent;
            lblCadenaConexion.Font = new Font("Consolas", 12.75F);
            lblCadenaConexion.ForeColor = Color.FromArgb(224, 224, 224);
            lblCadenaConexion.Location = new Point(1, 293);
            lblCadenaConexion.Name = "lblCadenaConexion";
            lblCadenaConexion.Size = new Size(189, 20);
            lblCadenaConexion.TabIndex = 1;
            lblCadenaConexion.Text = "Cadena de conexión: ";
            // 
            // timer1
            // 
            timer1.Interval = 1;
            timer1.Tick += timer1_Tick;
            // 
            // PantallaCarga
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            BackgroundImage = Properties.Resources.screenload1;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(714, 315);
            Controls.Add(lblCadenaConexion);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "PantallaCarga";
            SizeGripStyle = SizeGripStyle.Show;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PantallaCarga";
            Load += PantallaCarga_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblCadenaConexion;
        private System.Windows.Forms.Timer timer1;
    }
}