
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

                EMaterial e = new EMaterial();
                e.SetMaterial(dgv.Cells["Código"].Value.ToString());

                FrmMaterialAñadir f = new FrmMaterialAñadir(this);
                f.añadirModificar = false;
                f.lblTitulo.Text = "Modificar material";
                f.txbId.Text = e.IdMaterial;
                f.txbIdTipo.Text = e.IdMatType;
                f.txbNombre.Text = e.NameMat;
                f.txbNombreEnEtiqueta.Text = e.NameMatLabel;
                f.txbCantidad.Text = e.QuantMat.ToString();
                f.txbCantidadPorUnidad.Text = e.QuantMatPerUnit.ToString();
                f.txbIdDistribuidor.Text = e.IdDistributor;
                f.txbIdColor.Text = e.IdColor;
                f.txbIdUnidad.Text = e.IdUnit;
                f.cboTipoMat.Enabled = false;
                f.Text = "Modificar material";
                f.UpdateEventHandler += CatalogoActualizarHijo;
                f.ShowDialog();
            }
        }
    }
}

