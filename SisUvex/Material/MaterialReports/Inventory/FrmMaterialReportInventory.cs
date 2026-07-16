using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Material.MaterialReports.Inventory
{
    internal partial class FrmMaterialReportInventory : Form
    {
        ClsMaterialReportInventory cls;

        public FrmMaterialReportInventory()
        {
            InitializeComponent();
        }

        private void FrmMaterialReportInventory_Load(object sender, EventArgs e)
        {
            cls ??= new();
            cls.frm ??= this;
        }
    }
}
