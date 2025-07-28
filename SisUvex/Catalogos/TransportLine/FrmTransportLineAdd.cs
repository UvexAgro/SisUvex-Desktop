using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Catalogos.TransportLine
{
    internal partial class FrmTransportLineAdd : Form
    {
        public ClsTransportLine cls;
        public FrmTransportLineAdd()
        {
            InitializeComponent();
        }

        private void FrmTransportLineAdd_Load(object sender, EventArgs e)
        {
            cls ??= new();
            cls._frmAdd ??= this;
            cls.BeginFormAdd();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            cls.BtnAccept();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
