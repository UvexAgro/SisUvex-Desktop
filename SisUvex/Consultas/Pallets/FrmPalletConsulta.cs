using SisUvex.Archivo.MixtearPallets;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.DataGridViews;
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

            // Cuando viene vw_PackPalletConWithShrinkage (chbRestowing=true) normalmente existe la columna "Activo".
            // Aplicamos un formato suave (casi rosa) a toda la fila para los que están inactivos (Activo=0).
            dgvConsulta.DataBindingComplete += dgvConsulta_DataBindingComplete;
        }

        private void dgvConsulta_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (!chbRestowing.Checked)
                return;

            if (!dgvConsulta.Columns.Contains(Column.active))
                return;

            var format = ClsDGVCatalog.CellFormat.soft_inactive;

            foreach (DataGridViewRow row in dgvConsulta.Rows)
            {
                if (row.IsNewRow)
                    continue;

                object? v = row.Cells[Column.active].Value;
                bool isInactive =
                    v != null && v != DBNull.Value &&
                    (v.ToString() == "0" || v.ToString()?.Equals("false", StringComparison.OrdinalIgnoreCase) == true);

                if (!isInactive)
                    continue;

                foreach (DataGridViewCell cell in row.Cells)
                {
                    // Solo colores (sin tocar fuentes), para respetar estilos existentes del proyecto.
                    format.Apply(cell.Style, dgvConsulta.Font);
                }
            }
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
            => AbrirCambioStatusPallet(ModoPalletAccion.Eliminar);

        private void btnCambiarStatus_Click(object sender, EventArgs e)
            => AbrirCambioStatusPallet(ModoPalletAccion.CambiarStatus);

        private void AbrirCambioStatusPallet(ModoPalletAccion modo)
        {
            if (dgvConsulta.SelectedRows.Count == 0)
            {
                System.Media.SystemSounds.Hand.Play();
                return;
            }

            DataGridViewRow dgv = dgvConsulta.SelectedRows[0];
            string id = dgv.Cells["Pallet"].Value.ToString();

            var frm = new FrmEliminarPallet(id, modo);

            if (frm.ShowDialog() == DialogResult.OK)
                ActualizarFilaPalletTrasStatus(dgv, frm.TipoSeleccionado);
        }

        private void ActualizarFilaPalletTrasStatus(DataGridViewRow dgv, TipoReestiba tipo)
        {
            string activoPallet = tipo.NuevoPalletActivo ? "1" : "0";

            if (dgvConsulta.Columns.Contains(Column.active))
            {
                dgv.Cells[Column.active].Value = activoPallet;

                if (dgvConsulta.Columns.Contains("Tipo"))
                    dgv.Cells["Tipo"].Value = tipo.Prefijo;
            }
            else if (!tipo.NuevoPalletActivo)
                dgvConsulta.Rows.Remove(dgv);
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

        private void btnAjustarColumnas_Click(object sender, EventArgs e)
        {
        }

        private void chbAjustarColumnas_CheckedChanged(object sender, EventArgs e)
        {
            if (chbAjustarColumnas.Checked)
                dgvConsulta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            else
                dgvConsulta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }
    }
}