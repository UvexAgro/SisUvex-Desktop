using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.IdentityModel.Tokens;
using SisUvex.Catalogos.Metods.Forms.SelectionForms;
using SisUvex.Catalogos.Metods.Values;
using SisUvex.Material.MaterialWarehouses;

namespace SisUvex.Material.Warehouses
{
    internal partial class FrmMaterialWarehousesAdd : Form
    {
        public ClsMaterialWareHouses cls;
        public FrmMaterialWarehousesAdd()
        {
            InitializeComponent();
        }

        private void FrmMaterialWarehousesAdd_Load(object sender, EventArgs e)
        {
            cls ??= new ClsMaterialWareHouses();
            cls._frmAdd ??= this;
            cls.BeginFormAdd();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (!txbIdEmployee.Text.IsNullOrEmpty())
            {
                cls.GetEmployeeName(txbIdEmployee.Text);

                if (!txbEmployeeName.Text.IsNullOrEmpty())
                {
                    cls.BtnAccept();
                }
            }
            else
                cls.BtnAccept();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearchEmployee_Click(object sender, EventArgs e)
        {
            ClsSelectionForm sel = new ClsSelectionForm();

            sel.OpenSelectionForm("EmployeeBasic", "Código");

            if (!sel.SelectedValue.IsNullOrEmpty())
            {
                txbIdEmployee.Text = sel.SelectedValue;

                cls.GetEmployeeName(txbIdEmployee.Text);
            }
        }

        private void btnLoadEmployee_Click(object sender, EventArgs e)
        {
            cls.GetEmployeeName(txbIdEmployee.Text);
        }

        private void txbIdEmployee_TextChanged(object sender, EventArgs e)
        {
            if (!long.TryParse(txbIdEmployee.Text, out _))
            {
                txbIdEmployee.Text = string.Empty; // Clear the text if it's not a valid long integer
            }
            txbEmployeeName.Text = string.Empty;
        }

        private void txbIdEmployee_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Only allow numeric input
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                cls.GetEmployeeName(txbIdEmployee.Text);
                e.Handled = true; // Prevents the beep sound on enter key press
            }
        }
    }
}
