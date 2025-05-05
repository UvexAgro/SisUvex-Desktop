using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Material.MaterialRegister.Entry
{
    internal partial class FrmMaterialRegisterEntryCat : Form
    {
        public ClsMaterialRegisterEntry cls;
        public FrmMaterialRegisterEntryCat()
        {
            InitializeComponent();
        }

        private void FrmMaterialRegisterEntryCat_Load(object sender, EventArgs e)
        {
            cls ??= new();
            cls._frmCat ??= this;
            cls.BeginFormCat();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cls.OpenFrmAdd();
        }
    }
}
