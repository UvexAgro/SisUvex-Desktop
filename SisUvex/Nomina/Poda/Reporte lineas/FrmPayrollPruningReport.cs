using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Nomina.Poda.Reporte_lineas
{
    public partial class FrmPayrollPruningReport : Form
    {
        public FrmPayrollPruningReport()
        {
            InitializeComponent();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            ClsPayrollPruningReport reportGenerator = new ClsPayrollPruningReport();
            reportGenerator.GenerateExcelReport();
        }
    }
}
