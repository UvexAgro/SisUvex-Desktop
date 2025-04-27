using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Material.MaterialType
{
    internal partial class FrmMaterialTypeAdd : Form
    {
        public ClsMaterialType cls;
        public FrmMaterialTypeAdd()
        {
            InitializeComponent();
        }

        private void FrmMaterialTypeAdd_Load(object sender, EventArgs e)
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