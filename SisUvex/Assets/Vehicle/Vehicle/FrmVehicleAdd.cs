using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Assets.Vehicle.Vehicle
{
    internal partial class FrmVehicleAdd : Form
    {
        public ClsVehicle cls;
        public FrmVehicleAdd()
        {
            InitializeComponent();
        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void FrmVehicleAdd_Load(object sender, EventArgs e)
        {
            cls ??= new();
            cls._frmAdd = this;
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
