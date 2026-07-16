namespace SisUvex.Archivo.Etiquetas
{
    partial class PruebasEtiquetasTextoZPL
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
            txbZPLText = new RichTextBox();
            btnPrint = new Button();
            lblPTI = new Label();
            label2 = new Label();
            cboPrinters = new ComboBox();
            SuspendLayout();
            // 
            // txbZPLText
            // 
            txbZPLText.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txbZPLText.Location = new Point(12, 52);
            txbZPLText.Name = "txbZPLText";
            txbZPLText.Size = new Size(658, 386);
            txbZPLText.TabIndex = 0;
            txbZPLText.Text = "";
            // 
            // btnPrint
            // 
            btnPrint.Location = new Point(676, 415);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(112, 23);
            btnPrint.TabIndex = 1;
            btnPrint.Text = "Imprimir";
            btnPrint.UseVisualStyleBackColor = true;
            btnPrint.Click += btnPrint_Click;
            // 
            // lblPTI
            // 
            lblPTI.AutoSize = true;
            lblPTI.Font = new Font("Segoe UI", 14F);
            lblPTI.Location = new Point(271, 201);
            lblPTI.Margin = new Padding(1, 0, 1, 0);
            lblPTI.Name = "lblPTI";
            lblPTI.Size = new Size(0, 25);
            lblPTI.TabIndex = 18;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label2.Location = new Point(12, 14);
            label2.Margin = new Padding(1, 0, 1, 0);
            label2.Name = "label2";
            label2.Size = new Size(120, 25);
            label2.TabIndex = 17;
            label2.Text = "IMPRESORA";
            // 
            // cboPrinters
            // 
            cboPrinters.Font = new Font("Segoe UI", 14F);
            cboPrinters.FormattingEnabled = true;
            cboPrinters.Location = new Point(134, 11);
            cboPrinters.Margin = new Padding(1);
            cboPrinters.Name = "cboPrinters";
            cboPrinters.Size = new Size(258, 33);
            cboPrinters.TabIndex = 16;
            // 
            // PruebasEtiquetasTextoZPL
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblPTI);
            Controls.Add(label2);
            Controls.Add(cboPrinters);
            Controls.Add(btnPrint);
            Controls.Add(txbZPLText);
            Name = "PruebasEtiquetasTextoZPL";
            Text = "PruebasEtiquetasTextoZPL";
            Load += PruebasEtiquetasTextoZPL_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox txbZPLText;
        private Button btnPrint;
        private Label lblPTI;
        private Label label2;
        private ComboBox cboPrinters;
    }
}