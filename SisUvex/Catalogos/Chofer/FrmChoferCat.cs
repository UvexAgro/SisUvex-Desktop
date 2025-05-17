
namespace SisUvex.Catalogos.Chofer
{
    public partial class FrmChoferCat : Form
    {
        ClsChofer cls = new ClsChofer();
        bool _dgvStatus = true; //Verdadero vista de activos, Falso de activos e inactivos

        public FrmChoferCat()
        {
            InitializeComponent();
        }

        private void CatalogoActualizarHijo(object sender, FrmChoferAñadir.UpdateEventArgs args)
        {
            dgvCatalogo.DataSource = cls.CatalogoActualizar(_dgvStatus);
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            FrmChoferAñadir f = new FrmChoferAñadir(this);
            f.añadirModificar = true;
            f.lblTitulo.Text = "Añadir chofer";
            f.Text = "Añadir chofer";
            f.txbId.Text = cls.SiguienteChofer();
            f.cboActivo.SelectedIndex = 1;
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
        public void FrmChoferCat_Load(object sender, EventArgs e)
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

                FrmChoferAñadir f = new FrmChoferAñadir(this);
                f.añadirModificar = false;
                f.lblTitulo.Text = "Modificar chofer";
                f.Text = "Modificar chofer";

                cls.LlenarFormulario(dgv.Cells["Código"].Value.ToString(), f.txbId, f.cboActivo, f.txbIdLinea, f.txbNombre, f.txbApellidos, f.txbLicencia, f.txbVisa, f.spnFecha);

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
                cls.EliminarChofer(dgvCatalogo.SelectedRows[0].Cells[1].Value.ToString());

                dgvCatalogo.DataSource = cls.CatalogoActualizar(_dgvStatus);
            }
        }

        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            if (dgvCatalogo.Rows.Count > 0)
            {
                cls.RecuperarChofer(dgvCatalogo.SelectedRows[0].Cells[1].Value.ToString());

                dgvCatalogo.DataSource = cls.CatalogoActualizar(_dgvStatus);
            }
        }
    }
}