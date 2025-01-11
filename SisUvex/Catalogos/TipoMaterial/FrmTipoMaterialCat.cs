
using System.Data;

namespace SisUvex.Catalogos.TipoMaterial
{
    public partial class FrmTipoMaterialCat : Form
    {
        ClsTipoMaterial cls = new ClsTipoMaterial();
        public FrmTipoMaterialCat()
        {
            InitializeComponent();

        }

        private void CatalogoActualizarHijo(object sender, FrmTipoMaterialAñadir.UpdateEventArgs args)
        {
            dgvCatalogo.DataSource = cls.CatalogoActivos();
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            FrmTipoMaterialAñadir f = new FrmTipoMaterialAñadir(this);
            f.lblTitulo.Text = "Añadir tipo de material";
            f.añadirModificar = true;
            f.Text = "Añadir tipo de material";
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

        public void FrmTipoMaterialCat_Load(object sender, EventArgs e)
        {
            dgvCatalogo.DataSource = cls.CatalogoActivos();
        }

        private void CatalogoModificar()
        {
            if (dgvCatalogo.Rows.Count > 0)
            {
                DataGridViewRow dgv = dgvCatalogo.SelectedRows[0];
                FrmTipoMaterialAñadir f = new FrmTipoMaterialAñadir(this);
                f.añadirModificar = false;
                f.lblTitulo.Text = "Modificar tipo de material";
                f.txbId.Text = dgv.Cells["Código"].Value.ToString();
                f.txbNombre.Text = dgv.Cells["Nombre"].Value.ToString();
                f.txbLibras.Text = dgv.Cells["Libras"].Value.ToString();
                cls.CboCategoria(dgv.Cells["Categoría"].Value.ToString(), f.cboCategoría);
                f.Text = "Modificar tipo de material";
                f.UpdateEventHandler += CatalogoActualizarHijo;
                f.txbId.Enabled = false;


                f.ShowDialog();
            }
        }

    }
}