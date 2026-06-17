using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SisUvex.Catalogos.Metods.ClsObject;

namespace SisUvex.Archivo.WorkPlan.ChangeDistributorPallet
{
    public partial class FrmChangeDistributorPallet : Form
    {
        ClsChangeDistributorPallet cls = null!;
        public FrmChangeDistributorPallet()
        {
            InitializeComponent();
        }

        private void FrmChangeDistributorPallet_Load(object sender, EventArgs e)
        {
            cls ??= new();
            cls.frm = this;

            cls.BeginForm();


            cls.BtnAddPallet("34528");
            cls.BtnAddPallet("34552");
            cls.BtnAddPallet("34559");
            cls.BtnAddPallet("34567");
            cls.BtnAddPallet("34563");
            cls.BtnAddPallet("34564");
            cls.BtnAddPallet("34565");
            cls.BtnAddPallet("34566");
            cls.BtnAddPallet("34556");
            cls.BtnAddPallet("34618");

        }

        private void btnAddPallet_Click(object sender, EventArgs e)
        {
            cls.BtnAddPallet(txbIdPallet.Text);
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            cls.BtnQuitPallet();
        }

        private void chbAjustarColumnas_CheckedChanged(object sender, EventArgs e)
        {
            if (chbAjustarColumnas.Checked)
                dgvPallet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            else
                dgvPallet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        private void txbIdPallet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                cls.BtnAddPallet(txbIdPallet.Text);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            cls.pruebaGTIN();
        }
    }
}
