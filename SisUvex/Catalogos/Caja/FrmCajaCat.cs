
using SisUvex.Catalogos.Material;

namespace SisUvex.Catalogos.Caja
{
    public partial class FrmCajaCat : Form
    {
        ClsCaja cls = new ClsCaja();
        bool _dgvStatus = true; //Verdadero vista de activos, Falso de activos e inactivos

        public FrmCajaCat()
        {
            InitializeComponent();
        }

        private void CatalogoActualizarHijo(object sender, FrmCajaAñadir.UpdateEventArgs args)
        {
            dgvCatalogo.DataSource = cls.CatalogoActualizar(_dgvStatus);
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            FrmCajaAñadir f = new FrmCajaAñadir(this);
            f.añadirModificar = true;
            f.lblTitulo.Text = "Añadir caja";
            f.Text = "Añadir caja";
            f.txbId.Text = cls.SiguienteCaja();
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
        public void FrmCajaCat_Load(object sender, EventArgs e)
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

                FrmCajaAñadir f = new FrmCajaAñadir(this);
                f.añadirModificar = false;
                f.lblTitulo.Text = "Modificar caja";
                f.Text = "Modificar caja";

                cls.LlenarFormulario(dgv.Cells["Código"].Value.ToString(), f.txbId, f.cboActivo, f.txbIdLinea, f.txbNumEco, f.txbPlacasUS, f.txbPlacasMX, f.txbModelo, f.txbMarca, f.cboTipo, f.txbTamaño);

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
                cls.EliminarCaja(dgvCatalogo.SelectedRows[0].Cells[1].Value.ToString());

                dgvCatalogo.DataSource = cls.CatalogoActualizar(_dgvStatus);
            }
        }

        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            if (dgvCatalogo.Rows.Count > 0)
            {
                cls.RecuperarCaja(dgvCatalogo.SelectedRows[0].Cells[1].Value.ToString());

                dgvCatalogo.DataSource = cls.CatalogoActualizar(_dgvStatus);
            }
        }
    }
}