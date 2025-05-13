using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Material.MaterialRegister.Exit
{
    internal partial class FrmMaterialRegisterExitCat : Form
    {
        public ClsMaterialRegisterExit cls;
        public FrmMaterialRegisterExitCat()
        {
            InitializeComponent();
        }

        private void FrmMaterialRegisterExitCat_Load(object sender, EventArgs e)
        {
            cls = new ClsMaterialRegisterExit();
            cls._frmCat = this;
            cls.BeginFormCat();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
