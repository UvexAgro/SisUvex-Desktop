using DocumentFormat.OpenXml.Bibliography;
using Microsoft.IdentityModel.Tokens;
using SisUvex.Catalogos.Metods.Forms.SelectionForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Nomina.Comedores.EmployeeDiningHallAssignment
{
    public partial class FrmEmployeeDiningHallAsingment : Form
    {
        ClsEmployeeDiningHallAssignment cls;

        public FrmEmployeeDiningHallAsingment()
        {
            InitializeComponent();

            cls = new();
            cls.frm = this;
        }

        private void FrmEmployeeDiningHallAsingment_Load(object sender, EventArgs e)
        {
            cls.LoadForm();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            cls.SetDGVReport();
        }

        private void btnSearchEmployee_Click(object sender, EventArgs e)
        {
            ClsSelectionForm sel = new ClsSelectionForm();

            sel.OpenSelectionForm("EmployeeBasic", "Código");

            if (!sel.SelectedValue.IsNullOrEmpty())
                txbIdEmployee.Text = sel.SelectedValue;

            txbIdEmployee.Focus();

            txbIdEmployee.SelectAll();
        }

        private void btnFrmSearchEmployeeId_Click(object sender, EventArgs e)
        {
            cls.SetDGVReportEmployee();
        }

        private void txbIdEmployee_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cls.SetDGVReportEmployee();
                e.Handled = true;
            }
        }
    }
}
