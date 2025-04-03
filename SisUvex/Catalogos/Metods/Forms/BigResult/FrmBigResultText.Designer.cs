namespace SisUvex.Catalogos.Metods.Forms.BigResult
{
    partial class FrmBigResultText
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBigResultText));
            txbText = new RichTextBox();
            btnAccept = new Button();
            lblTitle = new Label();
            lblDescription = new Label();
            btnCopy = new Button();
            imageListIcons = new ImageList(components);
            picIcon = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picIcon).BeginInit();
            SuspendLayout();
            // 
            // txbText
            // 
            txbText.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txbText.BackColor = SystemColors.Control;
            txbText.Location = new Point(6, 58);
            txbText.Name = "txbText";
            txbText.ScrollBars = RichTextBoxScrollBars.Vertical;
            txbText.Size = new Size(400, 71);
            txbText.TabIndex = 0;
            txbText.Text = "";
            // 
            // btnAccept
            // 
            btnAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAccept.Location = new Point(331, 134);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(75, 23);
            btnAccept.TabIndex = 1;
            btnAccept.Text = "Aceptar";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(6, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(346, 23);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "Title";
            // 
            // lblDescription
            // 
            lblDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblDescription.Location = new Point(6, 24);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(346, 30);
            lblDescription.TabIndex = 3;
            lblDescription.Text = "Text\r\nText";
            // 
            // btnCopy
            // 
            btnCopy.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCopy.Location = new Point(250, 134);
            btnCopy.Name = "btnCopy";
            btnCopy.Size = new Size(75, 23);
            btnCopy.TabIndex = 4;
            btnCopy.Text = "Copiar";
            btnCopy.UseVisualStyleBackColor = true;
            btnCopy.Click += button2_Click;
            // 
            // imageListIcons
            // 
            imageListIcons.ColorDepth = ColorDepth.Depth32Bit;
            imageListIcons.ImageStream = (ImageListStreamer)resources.GetObject("imageListIcons.ImageStream");
            imageListIcons.TransparentColor = Color.Transparent;
            imageListIcons.Images.SetKeyName(0, "pngInformationIcon48.png");
            imageListIcons.Images.SetKeyName(1, "pngExclamationIcon48.png");
            imageListIcons.Images.SetKeyName(2, "pngWarningIcon48.png");
            // 
            // picIcon
            // 
            picIcon.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            picIcon.InitialImage = null;
            picIcon.Location = new Point(358, 5);
            picIcon.Name = "picIcon";
            picIcon.Size = new Size(48, 48);
            picIcon.TabIndex = 5;
            picIcon.TabStop = false;
            // 
            // FrmBigResultText
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(412, 163);
            Controls.Add(btnCopy);
            Controls.Add(lblDescription);
            Controls.Add(lblTitle);
            Controls.Add(btnAccept);
            Controls.Add(txbText);
            Controls.Add(picIcon);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(428, 202);
            Name = "FrmBigResultText";
            SizeGripStyle = SizeGripStyle.Show;
            StartPosition = FormStartPosition.CenterParent;
            Text = "FrmBigResultText";
            ((System.ComponentModel.ISupportInitialize)picIcon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox txbText;
        private Button btnAccept;
        private Label lblTitle;
        private Label lblDescription;
        private Button btnCopy;
        private ImageList imageListIcons;
        private PictureBox picIcon;
    }
}