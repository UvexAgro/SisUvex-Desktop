using SisUvex.Catalogos.Presentacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Nomina.Comedores.DiningHall
{
    internal partial class FrmDiningHallAdd : Form
    {
        public ClsDiningHall cls;
        private FrmDiningHallCat frmCat;
        public bool IsAddModify = true, AddIsUpdate = false;
        public string? idModify;
        public FrmDiningHallAdd()
        {
            InitializeComponent();
        }

        private void FrmDiningHallAdd_Load(object sender, EventArgs e)
        {
            cls.BeginFormAdd();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            cls.btnAcceptAddModify();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
