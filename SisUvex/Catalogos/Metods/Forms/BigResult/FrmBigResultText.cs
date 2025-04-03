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
        public string TitleWindow = "";
        public string Description = "";
        public string TextInBox = "";
        public string TextTitle = "";
        public int InformationIcon = 0;
        public int ExclamationIcon = 1;
        public int WarningIcon = 2;

        /*

            MessageBox.Show("Asterisk", "asasd", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            MessageBox.Show("Error", "asasd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            MessageBox.Show("Exclamation", "asasd", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            MessageBox.Show("Hand", "asasd", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            MessageBox.Show("Information", "asasd", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MessageBox.Show("None", "asasd", MessageBoxButtons.OK, MessageBoxIcon.None);
            MessageBox.Show("Question", "asasd", MessageBoxButtons.OK, MessageBoxIcon.Question);
            MessageBox.Show("Stop", "asasd", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            MessageBox.Show("Warning", "asasd", MessageBoxButtons.OK, MessageBoxIcon.Warning);*/

        public void SetValues()
        {

            this.Text = TitleWindow;
            lblTitle.Text = TextTitle;
            lblDescription.Text = Description;
            txbText.Text = TextInBox;
        }

        public FrmBigResultText()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CopyResult = true;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            AcceptResult = true;
        }
    }
}
