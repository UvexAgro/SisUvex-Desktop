using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Nomina.Work_time
{
    internal partial class FrmBoxesPackedPerEmployee : Form
    {
        public ClsWorkTime cls;
        public string idProductionLine = string.Empty;
        public string dWorkTime = string.Empty;
        public int reportType = 1; //IGUAL SE LE CAMBIA AL ABRIR EL FRM EN LA CLASE
        public FrmBoxesPackedPerEmployee()
        {
            InitializeComponent();
        }

        private void FrmBoxesPackedPerEmployee_Load(object sender, EventArgs e)
        {
            cls.BeginFrmReport(reportType);
        }

        private void dgvCatalog_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
