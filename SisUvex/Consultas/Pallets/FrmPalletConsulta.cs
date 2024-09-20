using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.ComboBoxes;

namespace SisUvex.Consultas.Pallets
{
    public partial class FrmPalletConsulta : Form
    {
        ClsPalletConsulta cls = new ClsPalletConsulta();
        string idDis = null;
        public FrmPalletConsulta()
        {
            InitializeComponent();
            cls.frm = this;
        }
        private void FrmPalletConsulta_Load(object sender, EventArgs e)
        {
            ClsComboBoxes.CboLoadActives(cboDistribuidor, ClsObject.Distributor.Cbo);
            ClsComboBoxes.CboLoadActives(cboPresentacion, ClsObject.Presentation.Cbo);
            ClsComboBoxes.CboLoadActives(cboVariety, ClsObject.Variety.Cbo);
            ClsComboBoxes.CboLoadActives(cboContainer, ClsObject.Container.Cbo);
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            cls.ConsultaDisPre();
        }
        private void btnPallet_Click(object sender, EventArgs e)
        {
            cls.ConsultaPallet(txbPallet.Text);
        }
        private void btnManifiesto_Click(object sender, EventArgs e)
        {
            cls.ConsultaManifiesto(txbManifiesto.Text);
        }
        private void txbPallet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cls.ConsultaPallet(txbPallet.Text);
            }
            else
            {
                cls.TxbTeclasEnteros(e);
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvConsulta.Rows.Count > 0)
            {
                DataGridViewRow dgv = dgvConsulta.SelectedRows[0];
                string id = dgv.Cells["Pallet"].Value.ToString();

                DialogResult EliminarSN = MessageBox.Show("¿Desea eliminar el palet " + id + "?", "Eliminar palet.", MessageBoxButtons.YesNo);
                if (EliminarSN == DialogResult.Yes)
                {
                    cls.EliminarPallet(id);
                }
            }
            else
                System.Media.SystemSounds.Hand.Play();
        }



        private void btnInvoice_Click(object sender, EventArgs e)
        {
            cls.ConsultaPapeleta(txbInvoice.Text);
        }

        private void txbManifiesto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cls.ConsultaManifiesto(txbManifiesto.Text);
            }
        }

        private void txbInvoice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cls.ConsultaPapeleta(txbInvoice.Text);
            }
        }
    }
}