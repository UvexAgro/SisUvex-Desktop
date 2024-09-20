
using SisUvex.Catalogos.Material;

namespace SisUvex.Catalogos.Consignatario
{
    public partial class FrmConsignatarioCat : Form
    {
        ClsConsignatario cls = new ClsConsignatario();
        bool _dgvStatus = true; //Verdadero vista de activos, Falso de activos e inactivos

        public FrmConsignatarioCat()
        {
            InitializeComponent();
        }

        private void CatalogoActualizarHijo(object sender, FrmConsignatarioAñadir.UpdateEventArgs args)
        {
            dgvCatalogo.DataSource = cls.CatalogoActualizar(_dgvStatus);
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            FrmConsignatarioAñadir f = new FrmConsignatarioAñadir(this);
            f.añadirModificar = true;
            f.lblTitulo.Text = "Añadir consignatario";
            f.Text = "Añadir consignatario";
            f.txbId.Text = cls.SiguienteConsignatario();
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
        public void FrmConsignatarioCat_Load(object sender, EventArgs e)
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

                FrmConsignatarioAñadir f = new FrmConsignatarioAñadir(this);
                f.añadirModificar = false;
                f.lblTitulo.Text = "Modificar consignatario";
                f.Text = "Modificar consignatario";

                cls.LlenarFormulario(dgv.Cells["Código"].Value.ToString(), f.txbId, f.cboActivo, f.txbNombre, f.txbIdDistribuidor, f.txbDireccion, f.txbCiudad, f.txbPais, f.txbRFC, f.txbTelefono);

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
                DataGridViewRow dgv = dgvCatalogo.SelectedRows[0];
                cls.EliminarConsignatario(dgv.Cells["Código"].Value.ToString());

                dgvCatalogo.DataSource = cls.CatalogoActualizar(_dgvStatus);
            }
        }

        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            if (dgvCatalogo.Rows.Count > 0)
            {
                DataGridViewRow dgv = dgvCatalogo.SelectedRows[0];
                cls.RecuperarConsignatario(dgv.Cells["Código"].Value.ToString());

                dgvCatalogo.DataSource = cls.CatalogoActualizar(_dgvStatus);
            }
        }
    }
}