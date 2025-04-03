using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Catalogos.Metods.Forms.BigResult
{
    
    public partial class FrmBigResultText : Form
    {
        public bool AcceptResult = false, CopyResult = false;
        public string TitleWindow = string.Empty;
        public string Description = string.Empty;
        public string TextInBox = string.Empty;
        public string TextTitle = string.Empty;
        public int ImageIcon = FrmBigResultTextIcon.None;
        

        public void SetValues()
        {
            this.Text = TitleWindow;
            lblTitle.Text = TextTitle;
            lblDescription.Text = Description;
            txbText.Text = TextInBox;
            if (ImageIcon != FrmBigResultTextIcon.None )
                picIcon.Image = imageListIcons.Images[ImageIcon];
        }
        public FrmBigResultText()
        {
            InitializeComponent();
        }
        public FrmBigResultText(string TextInBox, string TextTitle, string Descroption, string TitleWindow, int Icon)
        {
            InitializeComponent();

            this.TitleWindow = TitleWindow;
            this.Description = Descroption;
            this.TextInBox = TextInBox;
            this.TextTitle = TextTitle;
            this.ImageIcon = Icon;
            SetValues();

            this.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CopyResult = true;
            Clipboard.SetText(TextInBox);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            AcceptResult = true;
            this.Close();
        }
    }

    static class FrmBigResultTextIcon
    {
        public const int Asterisk = 0;      //[i circulo azul]
        public const int Error = 1;         //[x circulo rojo]
        public const int Exclamation = 2;   //[! triangulo amarillo]
        public const int Hand = 3;          //[x circulo rojo]
        public const int Information = 4;   //[i circulo azul]
        public const int Question = 5;      //[? circulo azul]
        public const int Stop = 6;          //[x circulo rojo]
        public const int Warning = 7;       //[! triangulo amarillo]
        public const int Correct = 8;       //[v circulo verde]
        public const int None = 100;        //[sin icono]
    }
}
