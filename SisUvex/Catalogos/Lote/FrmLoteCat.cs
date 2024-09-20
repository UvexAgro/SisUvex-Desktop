
namespace SisUvex.Catalogos.Lote
{
    public partial class FrmLoteCat : Form
    {
        ClsLote cls = new ClsLote();
        bool _dgvStatus = true; //Verdadero vista de activos, Falso de activos e inactivos
        public FrmLoteCat()
        {
            InitializeComponent();

            _dgvStatus = true;

        }

        private void CatalogoActualizarHijo(object sender, FrmLoteAñadir.UpdateEventArgs args)
        {
            dgvCatalogo.DataSource = cls.CatalogoActualizar(_dgvStatus);
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            FrmLoteAñadir f = new FrmLoteAñadir(this);
            f.lblTitulo.Text = "Añadir lote";
            f.añadirModificar = true;
            f.Text = "Añadir lote";
            f.cboActivo.SelectedIndex = 1;
            f.spnId.Text = cls.SiguienteLote();
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
        private void btnEliminados_Click(object sender, EventArgs e)
        {
            _dgvStatus = false;
            dgvCatalogo.DataSource = cls.CatalogoActualizar(_dgvStatus);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCatalogo.Rows.Count > 0)
            {
                cls.EliminarLote(dgvCatalogo.SelectedRows[0].Cells[1].Value.ToString());

                dgvCatalogo.DataSource = cls.CatalogoActualizar(_dgvStatus);
            }
        }

        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            if (dgvCatalogo.Rows.Count > 0)
            {
                cls.RecuperarLote(dgvCatalogo.SelectedRows[0].Cells[1].Value.ToString());

                dgvCatalogo.DataSource = cls.CatalogoActualizar(_dgvStatus);
            }
        }

        public void FrmLoteCat_Load(object sender, EventArgs e)
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
                FrmLoteAñadir f = new FrmLoteAñadir(this);
                f.lblTitulo.Text = "Modificar lote";
                f.cboActivo.SelectedIndex = Int32.Parse(dgvCatalogo.SelectedRows[0].Cells[0].Value.ToString());
                f.spnId.Text = dgvCatalogo.SelectedRows[0].Cells[1].Value.ToString();
                f.txbNombre.Text = dgvCatalogo.SelectedRows[0].Cells[2].Value.ToString();
                f.txbIdVariedad.Text = dgvCatalogo.SelectedRows[0].Cells[3].Value.ToString();
                f.txbHectareas.Text = dgvCatalogo.SelectedRows[0].Cells[5].Value.ToString();
                f.spnFecha.Text = dgvCatalogo.SelectedRows[0].Cells[6].Value.ToString();
                f.añadirModificar = false;
                f.spnId.Enabled = false;
                f.Text = "Modificar lote";
                f.UpdateEventHandler += CatalogoActualizarHijo;

                f.ShowDialog();
            }
        }


    }
}