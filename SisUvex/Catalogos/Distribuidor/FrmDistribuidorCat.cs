
namespace SisUvex.Catalogos.Distribuidor
{
    public partial class FrmDistribuidorCat : Form
    {
        ClsDistribuidor cls = new ClsDistribuidor();
        bool _dgvStatus = true; //Verdadero vista de activos, Falso de activos e inactivos
        public FrmDistribuidorCat()
        {
            InitializeComponent();

            _dgvStatus = true;

        }

        private void CatalogoActualizarHijo(object sender, FrmDistribuidorAñadir.UpdateEventArgs args)
        {
            dgvCatalogo.DataSource = cls.CatalogoActualizar(_dgvStatus);
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            FrmDistribuidorAñadir F = new FrmDistribuidorAñadir(this);
            F.añadirModificar = true;
            F.lblTitulo.Text = "Añadir distribuidor";
            F.cboActivo.SelectedIndex = 1;
            F.cboMercado.SelectedIndex = 0;
            F.Text = "Añadir distribuidor";
            F.txbId.Text = cls.SiguienteDistribuidor();
            F.UpdateEventHandler += CatalogoActualizarHijo;
            F.ShowDialog();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            CatalogoModificar();
        }

        private void dgvCatalogo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            CatalogoModificar();

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
                DataGridViewRow dgv = dgvCatalogo.SelectedRows[0];
                cls.EliminarDistribuidor(dgv.Cells["Código"].Value.ToString());

                dgvCatalogo.DataSource = cls.CatalogoActualizar(_dgvStatus);
            }
        }

        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            if (dgvCatalogo.Rows.Count > 0)
            {
                DataGridViewRow dgv = dgvCatalogo.SelectedRows[0];
                cls.RecuperarDistribuidor(dgv.Cells["Código"].Value.ToString());

                dgvCatalogo.DataSource = cls.CatalogoActualizar(_dgvStatus);
            }
        }
        public void FrmDistribuidorCat_Load(object sender, EventArgs e)
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

                FrmDistribuidorAñadir f = new FrmDistribuidorAñadir(this);
                f.añadirModificar = false;
                f.lblTitulo.Text = "Modificar distribuidor";
                f.Text = "Modificar distribuidor";

                cls.LlenarFormulario(dgv.Cells["Código"].Value.ToString(), f.txbId, f.cboActivo, f.cboMercado, f.txbNombre, f.txbDireccion, f.txbCiudad, f.txbRFC, f.txbTelefono, f.txbIdAgenciaUS, f.txbIdAgenciaMX, f.txbIdProductor, f.txbIdCiudadCruce, f.txbIdCiudadDestino, f.txbNombreCorto, f.txbPais);

                f.UpdateEventHandler += CatalogoActualizarHijo;
                f.ShowDialog();
            }
        }
    }
}