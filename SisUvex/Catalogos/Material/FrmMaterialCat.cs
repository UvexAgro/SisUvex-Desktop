
using System.Windows.Forms;

namespace SisUvex.Catalogos.Material
{
    public partial class FrmMaterialCat : Form
    {
        ClsMaterial cls = new ClsMaterial();

        public FrmMaterialCat()
        {
            InitializeComponent();
        }

        private void CatalogoActualizarHijo(object sender, FrmMaterialAñadir.UpdateEventArgs args)
        {
            dgvCatalogo.DataSource = cls.CatalogoActivos();
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            FrmMaterialAñadir f = new FrmMaterialAñadir(this);
            f.lblTitulo.Text = "Añadir material";
            f.añadirModificar = true;
            f.Text = "Añadir material";
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

        public void FrmMaterialCat_Load(object sender, EventArgs e)
        {
            dgvCatalogo.DataSource = cls.CatalogoActivos();
        }

        private void CatalogoModificar()
        {
            if (dgvCatalogo.Rows.Count > 0)
            {
                DataGridViewRow dgv = dgvCatalogo.SelectedRows[0];

                FrmMaterialAñadir f = new FrmMaterialAñadir(this);
                f.añadirModificar = false;
                f.lblTitulo.Text = "Modificar material";
                f.txbId.Text = dgv.Cells["Código"].Value.ToString();
                f.txbIdTipo.Text = dgv.Cells["Código"].Value.ToString().Substring(0, 3);
                f.txbNombre.Text = dgv.Cells["Nombre"].Value.ToString();
                f.txbNombreEnEtiqueta.Text = dgv.Cells["Nombre en etiqueta"].Value.ToString();
                f.txbCantidad.Text = dgv.Cells["Cantidad"].Value.ToString();
                f.txbCantidadPorUnidad.Text = dgv.Cells["Cantidad por unidad"].Value.ToString();
                f.txbIdDistribuidor.Text = dgv.Cells["Dis"].Value.ToString();
                f.txbIdColor.Text = dgv.Cells["Col"].Value.ToString();
                f.txbIdUnidad.Text = dgv.Cells["Uni"].Value.ToString();
                f.cboTipoMat.Enabled = false;
                f.Text = "Modificar material";
                f.UpdateEventHandler += CatalogoActualizarHijo;
                f.ShowDialog();
            }
        }
    }
}

