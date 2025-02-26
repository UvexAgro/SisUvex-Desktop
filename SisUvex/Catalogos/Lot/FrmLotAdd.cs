using SisUvex.Catalogos.WorkGroup;
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
    internal partial class FrmLotAdd : Form
    {
        public ClsLot cls;
        public bool IsAddModify = true, AddIsUpdate = false;
        public string? idLotModify, idVarietyModify;
        public FrmLotAdd()
        {
            InitializeComponent();
        }

        private void FrmLotAdd_Load(object sender, EventArgs e)
        {
            cls ??= new ClsLot();
            cls._frmAdd ??= this;

            cls.BeginFormAdd();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            cls.btnAcceptAddModify();
        }

        private void btnSearchNameLot_Click(object sender, EventArgs e)
        {
            cls.btnSearchNameWithIdLot();
        }
    }
}
