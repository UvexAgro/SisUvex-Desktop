namespace SisUvex.Nomina.Padron.SUA
{
    partial class FrmSUALoad
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            Seleccionar = new Button();
            textBox2 = new TextBox();
            label2 = new Label();
            button4 = new Button();
            comboBox1 = new ComboBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 404);
            button1.Name = "button1";
            button1.Size = new Size(54, 23);
            button1.TabIndex = 0;
            button1.Text = "Movt";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(72, 404);
            button2.Name = "button2";
            button2.Size = new Size(54, 23);
            button2.TabIndex = 1;
            button2.Text = "Afil";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(132, 404);
            button3.Name = "button3";
            button3.Size = new Size(54, 23);
            button3.TabIndex = 2;
            button3.Text = "Aseg";
            button3.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 28);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(110, 303);
            textBox1.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 4);
            label1.Name = "label1";
            label1.Size = new Size(94, 21);
            label1.TabIndex = 4;
            label1.Text = "Empleados";
            // 
            // Seleccionar
            // 
            Seleccionar.Location = new Point(12, 337);
            Seleccionar.Name = "Seleccionar";
            Seleccionar.Size = new Size(110, 23);
            Seleccionar.TabIndex = 5;
            Seleccionar.Text = "Seleccionar";
            Seleccionar.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(196, 58);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(341, 23);
            textBox2.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(196, 4);
            label2.Name = "label2";
            label2.Size = new Size(180, 21);
            label2.TabIndex = 7;
            label2.Text = "Cargar empleado por: ";
            // 
            // button4
            // 
            button4.Location = new Point(543, 28);
            button4.Name = "button4";
            button4.Size = new Size(65, 23);
            button4.TabIndex = 8;
            button4.Text = "Examinar";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(196, 29);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(341, 23);
            comboBox1.TabIndex = 9;
            // 
            // FrmSUALoad
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(comboBox1);
            Controls.Add(button4);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(Seleccionar);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "FrmSUALoad";
            Text = "FrmSUALoad";
            Load += FrmSUALoad_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private TextBox textBox1;
        private Label label1;
        private Button Seleccionar;
        private TextBox textBox2;
        private Label label2;
        private Button button4;
        private ComboBox comboBox1;
    }
}