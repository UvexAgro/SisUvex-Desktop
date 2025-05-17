using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Forms.SelectionForms;

namespace SisUvex.Catalogos.Truck
{
    internal partial class FrmTruckAdd : Form
    {
        public ClsTruck cls;
        public FrmTruckAdd()
        {
            InitializeComponent();
        }

        private void FrmTruckAdd_Load(object sender, EventArgs e)
        {
            cls ??= new();
            cls._frmAdd = this;
            cls.BeginFormAdd();
        }

        private void btnTransportLineSearch_Click(object sender, EventArgs e)
        {
            ClsSelectionForm sel = new ClsSelectionForm();

            sel.OpenSelectionForm("TransportLine", "Código");

            if (!string.IsNullOrEmpty(sel.SelectedValue))
            {
                ClsComboBoxes.CboSelectIndexWithTextInValueMember(cboTransportLine, sel.SelectedValue);
            }
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
