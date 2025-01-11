
namespace SisUvex.Catalogos.LineaTransporte
{
    public partial class FrmLineaTransporteCat : Form
    {
        ClsLineaTransporte cls = new ClsLineaTransporte();
        bool _dgvStatus = true; //Verdadero vista de activos, Falso de activos e inactivos
        public FrmLineaTransporteCat()
        {
            InitializeComponent();

            _dgvStatus = true;

        }

        private void CatalogoActualizarHijo(object sender, FrmLineaTransporteAñadir.UpdateEventArgs args)
        {
            dgvCatalogo.DataSource = cls.CatalogoActualizar(_dgvStatus);
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            FrmLineaTransporteAñadir frmAñadir = new FrmLineaTransporteAñadir(this);
            frmAñadir.lblTitulo.Text = "Añadir lineaTransporte";
            frmAñadir.añadirModificar = true;
            frmAñadir.Text = "Añadir lineaTransporte";
            frmAñadir.cboActivo.SelectedIndex = 1;
            frmAñadir.UpdateEventHandler += CatalogoActualizarHijo;
            frmAñadir.txbId.Text = cls.SiguienteLineaTransporte();
            frmAñadir.ShowDialog();
        }

        private void btnModificar_Click(object sender, EventArgs e)
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
                cls.EliminarLineaTransporte(dgvCatalogo.SelectedRows[0].Cells[1].Value.ToString());

                dgvCatalogo.DataSource = cls.CatalogoActualizar(_dgvStatus);
            }
        }

        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            if (dgvCatalogo.Rows.Count > 0)
            {
                cls.RecuperarLineaTransporte(dgvCatalogo.SelectedRows[0].Cells[1].Value.ToString());

                dgvCatalogo.DataSource = cls.CatalogoActualizar(_dgvStatus);
            }
        }

        public void FrmLineaTransporteCat_Load(object sender, EventArgs e)
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

        private void dgvCatalogo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            CatalogoModificar();
        }
        private void CatalogoModificar()
        {
            if (dgvCatalogo.Rows.Count > 0)
            {
                FrmLineaTransporteAñadir frmAñadir = new FrmLineaTransporteAñadir(this);
                frmAñadir.lblTitulo.Text = "Modificar productor";
                frmAñadir.cboActivo.SelectedIndex = Int32.Parse(dgvCatalogo.SelectedRows[0].Cells[0].Value.ToString());
                frmAñadir.txbId.Text = dgvCatalogo.SelectedRows[0].Cells[1].Value.ToString();
                frmAñadir.txbNombre.Text = dgvCatalogo.SelectedRows[0].Cells[2].Value.ToString();
                frmAñadir.txbDireccion.Text = dgvCatalogo.SelectedRows[0].Cells[3].Value.ToString();
                frmAñadir.txbCiudad.Text = dgvCatalogo.SelectedRows[0].Cells[4].Value.ToString();
                frmAñadir.txbRFC.Text = dgvCatalogo.SelectedRows[0].Cells[5].Value.ToString();
                frmAñadir.txbTelefono.Text = dgvCatalogo.SelectedRows[0].Cells[6].Value.ToString();
                frmAñadir.txbSCAC.Text = dgvCatalogo.SelectedRows[0].Cells[7].Value.ToString();
                frmAñadir.txbSCAAT.Text = dgvCatalogo.SelectedRows[0].Cells[8].Value.ToString();
                frmAñadir.añadirModificar = false;
                frmAñadir.Text = "Modificar productor";
                frmAñadir.UpdateEventHandler += CatalogoActualizarHijo;

                frmAñadir.ShowDialog();
            }
        }

    }
}
