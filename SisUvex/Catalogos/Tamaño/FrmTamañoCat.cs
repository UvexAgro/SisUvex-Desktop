
namespace SisUvex.Catalogos.Tamaño
{
    public partial class FrmTamañoCat : Form
    {
        ClsTamaño cls = new ClsTamaño();
        bool _dgvStatus = true; //Verdadero vista de activos, Falso de activos e inactivos
        public FrmTamañoCat()
        {
            InitializeComponent();

            _dgvStatus = true;

        }

        private void CatalogoActualizarHijo(object sender, FrmTamañoAñadir.UpdateEventArgs args)
        {
            dgvCatalogo.DataSource = cls.CatalogoActualizar(_dgvStatus);
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            FrmTamañoAñadir frmAñadir = new FrmTamañoAñadir(this);
            frmAñadir.lblTitulo.Text = "Añadir tamaño";
            frmAñadir.añadirModificar = true;
            frmAñadir.Text = "Añadir tamaño";
            frmAñadir.cboActivo.SelectedIndex = 1;
            frmAñadir.txbId.Text = cls.SiguienteTamaño();
            frmAñadir.UpdateEventHandler += CatalogoActualizarHijo;
            frmAñadir.ShowDialog();

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
            _dgvStatus = false;
            dgvCatalogo.DataSource = cls.CatalogoActualizar(_dgvStatus);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCatalogo.Rows.Count > 0)
            {
                cls.EliminarTamaño(dgvCatalogo.SelectedRows[0].Cells[1].Value.ToString());

                dgvCatalogo.DataSource = cls.CatalogoActualizar(_dgvStatus);
            }
        }

        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            if (dgvCatalogo.Rows.Count > 0)
            {
                cls.RecuperarTamaño(dgvCatalogo.SelectedRows[0].Cells[1].Value.ToString());

                dgvCatalogo.DataSource = cls.CatalogoActualizar(_dgvStatus);
            }
        }

        public void FrmTamañoCat_Load(object sender, EventArgs e)
        {
            dgvCatalogo.DataSource = cls.CatalogoActualizar(_dgvStatus);

            Metods.DataGridViews.ClsDGVCatalog.DgvApplyCellFormattingEvent(dgvCatalogo);
        }

        private void CatalogoModificar()
        {
            if (dgvCatalogo.Rows.Count > 0)
            {
                FrmTamañoAñadir frmAñadir = new FrmTamañoAñadir(this);
                frmAñadir.lblTitulo.Text = "Modificar tamaño";
                frmAñadir.cboActivo.SelectedIndex = Int32.Parse(dgvCatalogo.SelectedRows[0].Cells[0].Value.ToString());
                frmAñadir.txbId.Text = dgvCatalogo.SelectedRows[0].Cells[1].Value.ToString();
                frmAñadir.txbNombre.Text = dgvCatalogo.SelectedRows[0].Cells[2].Value.ToString();
                frmAñadir.añadirModificar = false;
                frmAñadir.Text = "Modificar tamaño";
                frmAñadir.UpdateEventHandler += CatalogoActualizarHijo;

                frmAñadir.ShowDialog();
            }
        }


    }
}