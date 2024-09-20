
namespace SisUvex.Catalogos.AgenciaAduanal
{
    public partial class FrmAgenciaAduanalCat : Form
    {
        ClsAgenciaAduanal cls = new ClsAgenciaAduanal();
        bool _dgvStatus = true; //Verdadero vista de activos, Falso de activos e inactivos
        public FrmAgenciaAduanalCat()
        {
            InitializeComponent();

            _dgvStatus = true;

        }

        private void CatalogoActualizarHijo(object sender, FrmAgenciaAduanalAñadir.UpdateEventArgs args)
        {
            dgvCatalogo.DataSource = cls.CatalogoActualizar(_dgvStatus);
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            FrmAgenciaAduanalAñadir frmAñadir = new FrmAgenciaAduanalAñadir(this);
            frmAñadir.lblTitulo.Text = "Añadir agenciaAduanal";
            frmAñadir.añadirModificar = true;
            frmAñadir.Text = "Añadir agenciaAduanal";
            frmAñadir.cboActivo.SelectedIndex = 1;
            frmAñadir.txbId.Text = cls.SiguienteAgenciaAduanal();
            frmAñadir.UpdateEventHandler += CatalogoActualizarHijo;
            frmAñadir.ShowDialog();

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
                cls.EliminarAgenciaAduanal(dgvCatalogo.SelectedRows[0].Cells[1].Value.ToString());

                dgvCatalogo.DataSource = cls.CatalogoActualizar(_dgvStatus);
            }
        }

        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            if (dgvCatalogo.Rows.Count > 0)
            {
                cls.RecuperarAgenciaAduanal(dgvCatalogo.SelectedRows[0].Cells[1].Value.ToString());

                dgvCatalogo.DataSource = cls.CatalogoActualizar(_dgvStatus);
            }
        }

        public void FrmAgenciaAduanalCat_Load(object sender, EventArgs e)
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
                FrmAgenciaAduanalAñadir frmAñadir = new FrmAgenciaAduanalAñadir(this);
                frmAñadir.lblTitulo.Text = "Modificar agenciaAduanal";
                frmAñadir.cboActivo.SelectedIndex = Int32.Parse(dgvCatalogo.SelectedRows[0].Cells[0].Value.ToString());
                frmAñadir.txbId.Text = dgvCatalogo.SelectedRows[0].Cells[1].Value.ToString();
                frmAñadir.txbNombre.Text = dgvCatalogo.SelectedRows[0].Cells[2].Value.ToString();
                frmAñadir.cboPais.Text = dgvCatalogo.SelectedRows[0].Cells[3].Value.ToString();
                frmAñadir.txbCiudad.Text = dgvCatalogo.SelectedRows[0].Cells[4].Value.ToString();
                frmAñadir.txbDireccion.Text = dgvCatalogo.SelectedRows[0].Cells[5].Value.ToString();
                frmAñadir.txbRFC.Text = dgvCatalogo.SelectedRows[0].Cells[6].Value.ToString();
                frmAñadir.añadirModificar = false;
                frmAñadir.Text = "Modificar agencia aduanal";
                frmAñadir.UpdateEventHandler += CatalogoActualizarHijo;

                frmAñadir.ShowDialog();
            }
        }
    }
}
