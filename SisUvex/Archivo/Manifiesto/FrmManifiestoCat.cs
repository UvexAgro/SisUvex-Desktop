
namespace SisUvex.Archivo.Manifiesto
{
    public partial class FrmManifiestoCat : Form
    {
        ClsManifiesto cls = new ClsManifiesto();
        bool _dgvStatus = true; //Verdadero vista de activos, Falso de activos e inactivos

        public FrmManifiestoCat()
        {
            InitializeComponent();
            cls.frmCat = this;
        }

        private void CatalogoActualizarHijo(object sender, FrmManifiestoAñadir.UpdateEventArgs args)
        {
            dgvCatalogo.DataSource = cls.CatalogoActualizar(_dgvStatus);
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            FrmManifiestoAñadir f = new FrmManifiestoAñadir(this);
            f.añadirModificar = true;
            f.lblTitulo.Text = "Añadir Manifiesto";
            f.Text = "Añadir Manifiesto";
            f.txbId.Text = cls.SiguienteManifiesto("E");
            f.cboActive.SelectedIndex = 1;
            f.cboManifestType.Text = "E";
            f.dtpDate.Value = DateTime.Now;
            f.UpdateEventHandler += CatalogoActualizarHijo;
            f.ShowDialog();
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            CatalogoModificar();
        }
        private void dgvCatalogo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            CatalogoModificar();
        }
        public void FrmManifiestoCat_Load(object sender, EventArgs e)
        {
            dgvCatalogo.DataSource = cls.CatalogoActualizar(_dgvStatus);
        }

        private void dgvCatalogo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvCatalogo.Columns[e.ColumnIndex].Name == "Activo")
            {
                if (e.Value.ToString() == "0")
                {
                    e.CellStyle.BackColor = Color.Tomato;
                    e.CellStyle.ForeColor = Color.Red;
                }
                if (e.Value.ToString() == "1")
                {
                    e.CellStyle.BackColor = Color.LightGreen;
                    e.CellStyle.ForeColor = Color.Green;
                }
            }
        }

        private void CatalogoModificar()
        {
            if (dgvCatalogo.Rows.Count > 0)
            {
                DataGridViewRow dgv = dgvCatalogo.SelectedRows[0];

                FrmManifiestoAñadir f = new FrmManifiestoAñadir(this);
                f.añadirModificar = false;
                f.cboManifestType.Enabled = false;
                f.lblTitulo.Text = "Modificar Manifiesto";
                f.Text = "Modificar Manifiesto";

                cls.LlenarFormulario(dgv.Cells["Manifiesto"].Value.ToString(), ref f.cboActive, ref f.txbId, ref f.cboManifestType, ref f.txbIdDistributor, ref f.txbIdConsignee, ref f.txbIdGrower, ref f.txbIdAgencyUS, ref f.txbIdAgencyMX, ref f.txbIdTransportLine, ref f.txbIdTruck, ref f.txbIdFreightContainer, ref f.txbIdDriver, ref f.txbIdCityCrossPoint, ref f.txbIdCityDestination, ref f.txbSeal1, ref f.txbSeal2, ref f.txbSeal3, ref f.txbTermograph, ref f.txbPurchaseOrder, ref f.txbBooking, ref f.dtpDate, ref f.spnHour, ref f.txbTemperature, ref f.cboTemperatureUnit, ref f.txbNameOperator, ref f.txbNameShipper, ref f.cboTransportVehicle, ref f.cboTransportType, ref f.chkRejected, ref f.txbObservations, ref f.txbTermoPosition, ref f.txbDieselInvoice, ref f.txbDieselLiters, ref f.txbPhytosanitary);

                f.UpdateEventHandler += CatalogoActualizarHijo;
                f.ShowDialog();
            }
        }

        private void btnEliminados_Click(object sender, EventArgs e)
        {
            _dgvStatus = !_dgvStatus;
            dgvCatalogo.DataSource = cls.CatalogoActualizar(_dgvStatus);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCatalogo.Rows.Count > 0)
            {


                cls.EliminarManifiesto(dgvCatalogo.SelectedRows[0].Cells[1].Value.ToString());

                dgvCatalogo.DataSource = cls.CatalogoActualizar(_dgvStatus);
            }
        }

        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            if (dgvCatalogo.Rows.Count > 0)
            {
                cls.RecuperarManifiesto(dgvCatalogo.SelectedRows[0].Cells[1].Value.ToString());

                dgvCatalogo.DataSource = cls.CatalogoActualizar(_dgvStatus);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            FrmManifiestoReport f = new FrmManifiestoReport();
            f.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvCatalogo.DataSource = cls.CatalogoActualizar(_dgvStatus);
        }
    }
}