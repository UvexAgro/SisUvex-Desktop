using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Nomina.Padron.SUA
{
    internal partial class FrmSuaConfigCat : Form
    {
        public ClsSuaConfig cls;
        public bool IsAddModify = true, IsFrmUpdate = false;
        public string idModify;

        public FrmSuaConfigCat()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            cls.BtnAccept();
        }

        private void FrmSuaConfigCat_Load(object sender, EventArgs e)
        {
            cls ??= new ClsSuaConfig();
            cls._frmCat ??= this;

            cls.BeginCat();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            cls.BtnSearchSUAPath();
        }
    }
}
