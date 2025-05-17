
namespace SisUvex.Catalogos.PlantillaV1
{
    public partial class FrmPlantillaV1Cat : Form
    {
        ClsPlantillaV1 cls = new ClsPlantillaV1();
        bool _dgvStatus = true; //Verdadero vista de activos, Falso de activos e inactivos

        public FrmPlantillaV1Cat()
        {
            InitializeComponent();
        }

        private void CatalogoActualizarHijo(object sender, FrmPlantillaV1Añadir.UpdateEventArgs args)
        {
            dgvCatalogo.DataSource = cls.CatalogoActualizar(_dgvStatus);
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            FrmPlantillaV1Añadir f = new FrmPlantillaV1Añadir();
            f.añadirModificar = true;
            f.lblTitulo.Text = "Añadir plantillaV1";
            f.Text = "Añadir plantillaV1";
            f.txbId.Text = cls.SiguientePlantillaV1();
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
        public void FrmPlantillaV1Cat_Load(object sender, EventArgs e)
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

                FrmPlantillaV1Añadir f = new FrmPlantillaV1Añadir();
                f.añadirModificar = false;
                f.lblTitulo.Text = "Modificar plantillaV1";
                f.Text = "Modificar plantillaV1";

                cls.LlenarFormulario(dgv.Cells["Código"].Value.ToString(), f.txbId, f.txbIdLinea);

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
                cls.EliminarPlantillaV1(dgvCatalogo.SelectedRows[0].Cells[1].Value.ToString());

                dgvCatalogo.DataSource = cls.CatalogoActualizar(_dgvStatus);
            }
        }

        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            if (dgvCatalogo.Rows.Count > 0)
            {
                cls.RecuperarPlantillaV1(dgvCatalogo.SelectedRows[0].Cells[1].Value.ToString());

                dgvCatalogo.DataSource = cls.CatalogoActualizar(_dgvStatus);
            }
        }
    }
}