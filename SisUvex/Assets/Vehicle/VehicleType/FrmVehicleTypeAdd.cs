using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Assets.Vehicle.VehicleType
{
    internal partial class FrmVehicleTypeAdd : Form
    {
        public ClsVehicleType cls;
        public FrmVehicleTypeAdd()
        {
            InitializeComponent();
        }

        private void FrmVehicleTypeAdd_Load(object sender, EventArgs e)
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
