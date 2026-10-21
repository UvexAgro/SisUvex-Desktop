namespace SisUvex.Catalogos
{
    partial class Form1
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
            checkBox1 = new CheckBox();
            dataGridView1 = new DataGridView();
            triMarkEmpty = new SisUvex.Cuadro_de_herramientas.TriMarkBox();
            triMarkCheck = new SisUvex.Cuadro_de_herramientas.TriMarkBox();
            triMarkCross = new SisUvex.Cuadro_de_herramientas.TriMarkBox();
            triMarkPrueba = new SisUvex.Cuadro_de_herramientas.TriMarkBox();
            lblEmpty = new Label();
            lblCheck = new Label();
            lblCross = new Label();
            lblPrueba = new Label();
            triMarkBox1 = new SisUvex.Cuadro_de_herramientas.TriMarkBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(278, 31);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(82, 19);
            checkBox1.TabIndex = 0;
            checkBox1.Text = "checkBox1";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(51, 120);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(440, 242);
            dataGridView1.TabIndex = 1;
            // 
            // triMarkEmpty
            // 
            triMarkEmpty.AccessibleDescription = "Vacío";
            triMarkEmpty.AccessibleRole = AccessibleRole.CheckButton;
            triMarkEmpty.CheckBackColor = Color.FromArgb(34, 160, 70);
            triMarkEmpty.CrossBackColor = Color.FromArgb(198, 48, 48);
            triMarkEmpty.EmptyBackColor = Color.FromArgb(232, 232, 232);
            triMarkEmpty.EmptyBorderColor = Color.FromArgb(150, 150, 150);
            triMarkEmpty.Location = new Point(40, 24);
            triMarkEmpty.MarkColor = Color.White;
            triMarkEmpty.MinimumSize = new Size(16, 12);
            triMarkEmpty.Name = "triMarkEmpty";
            triMarkEmpty.ReadOnly = true;
            triMarkEmpty.Size = new Size(16, 16);
            triMarkEmpty.TabIndex = 2;
            // 
            // triMarkCheck
            // 
            triMarkCheck.AccessibleDescription = "Paloma";
            triMarkCheck.AccessibleRole = AccessibleRole.CheckButton;
            triMarkCheck.CheckBackColor = Color.FromArgb(34, 160, 70);
            triMarkCheck.CrossBackColor = Color.FromArgb(198, 48, 48);
            triMarkCheck.EmptyBackColor = Color.FromArgb(232, 232, 232);
            triMarkCheck.EmptyBorderColor = Color.FromArgb(150, 150, 150);
            triMarkCheck.Location = new Point(140, 24);
            triMarkCheck.MarkColor = Color.White;
            triMarkCheck.MinimumSize = new Size(16, 12);
            triMarkCheck.Name = "triMarkCheck";
            triMarkCheck.ReadOnly = true;
            triMarkCheck.Size = new Size(16, 16);
            triMarkCheck.TabIndex = 4;
            triMarkCheck.Value = Cuadro_de_herramientas.TriMarkValue.Check;
            // 
            // triMarkCross
            // 
            triMarkCross.AccessibleDescription = "Equis";
            triMarkCross.AccessibleRole = AccessibleRole.CheckButton;
            triMarkCross.CheckBackColor = Color.FromArgb(34, 160, 70);
            triMarkCross.CrossBackColor = Color.FromArgb(198, 48, 48);
            triMarkCross.EmptyBackColor = Color.FromArgb(232, 232, 232);
            triMarkCross.EmptyBorderColor = Color.FromArgb(150, 150, 150);
            triMarkCross.Location = new Point(40, 64);
            triMarkCross.MarkColor = Color.White;
            triMarkCross.MinimumSize = new Size(16, 12);
            triMarkCross.Name = "triMarkCross";
            triMarkCross.ReadOnly = true;
            triMarkCross.Size = new Size(16, 16);
            triMarkCross.TabIndex = 6;
            triMarkCross.Value = Cuadro_de_herramientas.TriMarkValue.Cross;
            // 
            // triMarkPrueba
            // 
            triMarkPrueba.AccessibleDescription = "Vacío";
            triMarkPrueba.AccessibleRole = AccessibleRole.CheckButton;
            triMarkPrueba.CheckBackColor = Color.FromArgb(34, 160, 70);
            triMarkPrueba.CrossBackColor = Color.FromArgb(198, 48, 48);
            triMarkPrueba.EmptyBackColor = Color.FromArgb(232, 232, 232);
            triMarkPrueba.EmptyBorderColor = Color.FromArgb(150, 150, 150);
            triMarkPrueba.Location = new Point(140, 64);
            triMarkPrueba.MarkColor = Color.White;
            triMarkPrueba.MinimumSize = new Size(16, 12);
            triMarkPrueba.Name = "triMarkPrueba";
            triMarkPrueba.Size = new Size(16, 16);
            triMarkPrueba.TabIndex = 8;
            triMarkPrueba.ValueChanged += triMarkPrueba_ValueChanged;
            // 
            // lblEmpty
            // 
            lblEmpty.AutoSize = true;
            lblEmpty.Location = new Point(72, 25);
            lblEmpty.Name = "lblEmpty";
            lblEmpty.Size = new Size(35, 15);
            lblEmpty.TabIndex = 3;
            lblEmpty.Text = "Vacío";
            // 
            // lblCheck
            // 
            lblCheck.AutoSize = true;
            lblCheck.Location = new Point(172, 25);
            lblCheck.Name = "lblCheck";
            lblCheck.Size = new Size(47, 15);
            lblCheck.TabIndex = 5;
            lblCheck.Text = "Paloma";
            // 
            // lblCross
            // 
            lblCross.AutoSize = true;
            lblCross.Location = new Point(72, 65);
            lblCross.Name = "lblCross";
            lblCross.Size = new Size(35, 15);
            lblCross.TabIndex = 7;
            lblCross.Text = "Equis";
            // 
            // lblPrueba
            // 
            lblPrueba.AutoSize = true;
            lblPrueba.Location = new Point(172, 65);
            lblPrueba.Name = "lblPrueba";
            lblPrueba.Size = new Size(61, 15);
            lblPrueba.TabIndex = 9;
            lblPrueba.Text = "Clic: vacío";
            // 
            // triMarkBox1
            // 
            triMarkBox1.AccessibleDescription = "Vacío";
            triMarkBox1.AccessibleRole = AccessibleRole.CheckButton;
            triMarkBox1.CheckBackColor = Color.FromArgb(34, 160, 70);
            triMarkBox1.CrossBackColor = Color.FromArgb(198, 48, 48);
            triMarkBox1.EmptyBackColor = Color.FromArgb(232, 232, 232);
            triMarkBox1.EmptyBorderColor = Color.FromArgb(150, 150, 150);
            triMarkBox1.Location = new Point(140, 98);
            triMarkBox1.MarkColor = Color.White;
            triMarkBox1.MinimumSize = new Size(16, 12);
            triMarkBox1.Name = "triMarkBox1";
            triMarkBox1.Size = new Size(16, 16);
            triMarkBox1.TabIndex = 10;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(triMarkBox1);
            Controls.Add(lblPrueba);
            Controls.Add(triMarkPrueba);
            Controls.Add(lblCross);
            Controls.Add(triMarkCross);
            Controls.Add(lblCheck);
            Controls.Add(triMarkCheck);
            Controls.Add(lblEmpty);
            Controls.Add(triMarkEmpty);
            Controls.Add(dataGridView1);
            Controls.Add(checkBox1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox checkBox1;
        private DataGridView dataGridView1;
        private Cuadro_de_herramientas.TriMarkBox triMarkEmpty;
        private Cuadro_de_herramientas.TriMarkBox triMarkCheck;
        private Cuadro_de_herramientas.TriMarkBox triMarkCross;
        private Cuadro_de_herramientas.TriMarkBox triMarkPrueba;
        private Label lblEmpty;
        private Label lblCheck;
        private Label lblCross;
        private Label lblPrueba;
        private Cuadro_de_herramientas.TriMarkBox triMarkBox1;
    }
}