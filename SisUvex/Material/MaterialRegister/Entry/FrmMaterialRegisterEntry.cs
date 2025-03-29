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
    public partial class FrmMaterialRegisterEntry : Form
    {
        ClsMaterialRegisterEntry cls;
        public FrmMaterialRegisterEntry()
        {
            InitializeComponent();
        }

        private void FrmMaterialRegisterEntry_Load(object sender, EventArgs e)
        {
            cls ??= new ClsMaterialRegisterEntry();
            cls._frmAdd ??= this;

            cls.BeginFormAdd();
        }
    }
}
