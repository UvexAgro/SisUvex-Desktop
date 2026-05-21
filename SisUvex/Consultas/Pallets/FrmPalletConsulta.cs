using SisUvex.Archivo.MixtearPallets;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Nomina.Conceptos_Ingresos_Diversos;
using static SisUvex.Catalogos.Metods.ClsObject;
using static SisUvex.Catalogos.Metods.Extentions.ComboBoxExtensions;

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
            ClsComboBoxes.CboLoadActives(cboWorkGroup, ClsObject.WorkGroup.Cbo);
            ClsComboBoxes.CboLoadActives(cboFarm, ClsObject.Farm.Cbo);
            ClsComboBoxes.CboLoadActives(cboPrice, ClsObject.Price.Cbo);
            ClsComboBoxes.CboLoadActives(cboSeason, ClsObject.Season.Cbo);

            List<(ComboBox Cbo, string IdColumnFilter)> lsWGDep = new();
            lsWGDep.Add((cboSeason, Season.ColumnId));
            ClsComboBoxes.Events.CboApplyEventFilterAllForOne(cboWorkGroup, null, lsWGDep);

            ClsComboBoxes.CboSelectIndexWithTextInValueMember(cboSeason, "08"); //<-- temporada uva 2026
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

                var frm = new FrmEliminarPallet(id);

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Eliminar fila del DataGridView
                    dgvConsulta.Rows.Remove(dgv);

                    // pallet ya está inactivo en DB
                    // frm.TipoSeleccionado tiene el motivo usado
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

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            FrmPapeleta frm = new FrmPapeleta();


            if (frm.ShowDialog() == DialogResult.OK)
            {
                cls.ConsultaDisPre();
            }
        }

        private void btnWorkPlan_Click(object sender, EventArgs e)
        {
            cls.ConsultaWorkPlan(txbWorkPlan.Text);
        }

        private void txbWorkPlan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cls.ConsultaWorkPlan(txbWorkPlan.Text);
            }
        }
    }
}