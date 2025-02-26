using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Catalogos.Lot
{
    public partial class FrmLotCat : Form
    {
        ClsLot cls;
        public FrmLotCat()
        {
            InitializeComponent();
        }

        private void FrmLotCat_Load(object sender, EventArgs e)
        {
            cls ??= new ClsLot();
            cls._frmCat ??= this;

            cls.BeginFormCat();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            cls.BtnRemove();
        }

        private void btnRecover_Click(object sender, EventArgs e)
        {
            cls.BtnRecover();
        }
        private void chbRemoved_CheckedChanged(object sender, EventArgs e)
        {
            cls.BtnRemoved();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cls.OpenFrmAdd();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            cls.OpenFrmModify();
        }

        private void btnSearchVariety_Click(object sender, EventArgs e)
        {

        }

        private void cboVariety_SelectedIndexChanged(object sender, EventArgs e)
        {
            cls.BtnRemoved();
        }
    }
}
