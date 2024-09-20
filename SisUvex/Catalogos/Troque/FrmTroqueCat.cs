
namespace SisUvex.Catalogos.Troque
{
    public partial class FrmTroqueCat : Form
    {
        ClsTroque cls = new ClsTroque();
        bool _dgvStatus = true; //Verdadero vista de activos, Falso de activos e inactivos

        public FrmTroqueCat()
        {
            InitializeComponent();
        }

        private void CatalogoActualizarHijo(object sender, FrmTroqueAñadir.UpdateEventArgs args)
        {
            dgvCatalogo.DataSource = cls.CatalogoActualizar(_dgvStatus);
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            FrmTroqueAñadir f = new FrmTroqueAñadir(this);
            f.añadirModificar = true;
            f.lblTitulo.Text = "Añadir troque";
            f.Text = "Añadir troque";
            f.txbId.Text = cls.SiguienteTroque();
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
        public void FrmTroqueCat_Load(object sender, EventArgs e)
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

                FrmTroqueAñadir f = new FrmTroqueAñadir(this);
                f.añadirModificar = false;
                f.lblTitulo.Text = "Modificar troque";
                f.Text = "Modificar troque";

                cls.LlenarFormulario(dgv.Cells["Código"].Value.ToString(), f.txbId, f.cboActivo, f.txbIdLinea, f.txbNumEco, f.txbPlacasUS, f.txbPlacasMX, f.txbModelo, f.txbMarca, f.txbVIN, f.txbColor);

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
                cls.EliminarTroque(dgvCatalogo.SelectedRows[0].Cells[1].Value.ToString());

                dgvCatalogo.DataSource = cls.CatalogoActualizar(_dgvStatus);
            }
        }

        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            if (dgvCatalogo.Rows.Count > 0)
            {
                cls.RecuperarTroque(dgvCatalogo.SelectedRows[0].Cells[1].Value.ToString());

                dgvCatalogo.DataSource = cls.CatalogoActualizar(_dgvStatus);
            }
        }
    }
}