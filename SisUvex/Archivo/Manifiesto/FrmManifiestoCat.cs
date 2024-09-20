
using SisUvex.Catalogos.Material;

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
            f.cboActivo.SelectedIndex = 1;
            f.cboTipoEmbarque.Text = "E";
            f.dtpFecha.Value = DateTime.Now;
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
                f.cboTipoEmbarque.Enabled = false;
                f.lblTitulo.Text = "Modificar Manifiesto";
                f.Text = "Modificar Manifiesto";

                cls.LlenarFormulario(dgv.Cells["Manifiesto"].Value.ToString(), ref f.cboActivo, ref f.txbId, ref f.cboTipoEmbarque, ref f.txbIdDistribuidor, ref f.txbIdConsignatario, ref f.txbIdProductor, ref f.txbIdAgenciaUS, ref f.txbIdAgenciaMX, ref f.txbIdLinea, ref f.txbIdTroque, ref f.txbIdCaja, ref f.txbIdChofer, ref f.txbIdCiudadCruce, ref f.txbIdCiudadDestino, ref f.txbSello1, ref f.txbSello2, ref f.txbSello3, ref f.txbChismografo, ref f.txbOrden, ref f.txbBooking, ref f.dtpFecha, ref f.spnHoraSalida, ref f.txbGrados, ref f.cboGrados, ref f.txbOperador, ref f.txbEmbarcador, ref f.cboMedioTransporte, ref f.cboSegundoMedio, ref f.chkRechazado, ref f.txbObservaciones, ref f.txbPosicion, ref f.txbDieselInvoice, ref f.txbDieselLiters, ref f.txbFitosanitario);

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