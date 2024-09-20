
namespace SisUvex.Catalogos.Variedad
{
    public partial class FrmVariedadCat : Form
    {
        ClsVariedad cls = new ClsVariedad();
        bool _dgvStatus = true; //Verdadero vista de activos, Falso de activos e inactivos
        public FrmVariedadCat()
        {
            InitializeComponent();
            _dgvStatus = true;
        }
        private void CatalogoActualizarHijo(object sender, FrmVariedadAñadir.UpdateEventArgs args)
        {
            dgvCatalogo.DataSource = cls.CatalogoActualizar(_dgvStatus);
        }
        private void btnAñadir_Click(object sender, EventArgs e)
        {
            FrmVariedadAñadir f = new FrmVariedadAñadir(this);
            f.lblTitulo.Text = "Añadir variedad";
            f.cboActivo.SelectedIndex = 1;
            f.añadirModificar = true;
            f.Text = "Añadir variedad";
            f.txbId.Text = cls.SiguienteVariedad();
            f.UpdateEventHandler += CatalogoActualizarHijo;
            f.ShowDialog();

        }
        private void btnModificar_Click(object sender, EventArgs e)
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
                cls.EliminarVariedad(dgvCatalogo.SelectedRows[0].Cells[1].Value.ToString());

                dgvCatalogo.DataSource = cls.CatalogoActualizar(_dgvStatus);
            }
        }
        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            if (dgvCatalogo.Rows.Count > 0)
            {
                cls.RecuperarVariedad(dgvCatalogo.SelectedRows[0].Cells[1].Value.ToString());

                dgvCatalogo.DataSource = cls.CatalogoActualizar(_dgvStatus);
            }
        }
        private void FrmVariedadCat_Load(object sender, EventArgs e)
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
                DataGridViewRow dgv = dgvCatalogo.SelectedRows[0];

                FrmVariedadAñadir f = new FrmVariedadAñadir(this);
                f.añadirModificar = false;
                f.lblTitulo.Text = "Modificar variedad";
                cls.LlenarFormulario(dgv.Cells["Código"].Value.ToString(),ref f.txbId,ref f.cboActivo, ref f.txbNomCientifico, ref f.txbNomComercial, ref f.txbIdColor, ref f.txbIdCultivo, ref f.txbNomCorto);
                f.Text = "Modificar variedad";
                f.UpdateEventHandler += CatalogoActualizarHijo;
                f.ShowDialog();
            }
        }
    }
}
