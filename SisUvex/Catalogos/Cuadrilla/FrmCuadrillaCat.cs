
using SisUvex.Catalogos.Material;

namespace SisUvex.Catalogos.Cuadrilla
{
    public partial class FrmCuadrillaCat : Form
    {
        ClsCuadrilla cls = new ClsCuadrilla();
        public FrmCuadrillaCat()
        {
            InitializeComponent();
        }

        private void CatalogoActualizarHijo(object sender, FrmCuadrillaAñadir.UpdateEventArgs args)
        {
            dgvCatalogo.DataSource = cls.CatalogoActivos();
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            FrmCuadrillaAñadir frmAñadir = new FrmCuadrillaAñadir(this);
            frmAñadir.lblTitulo.Text = "Añadir cuadrilla";
            frmAñadir.añadirModificar = true;
            frmAñadir.Text = "Añadir cuadrilla";
            frmAñadir.txbId.Text = cls.SiguienteCuadrilla();
            frmAñadir.UpdateEventHandler += CatalogoActualizarHijo;
            frmAñadir.ShowDialog();
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            CatalogoModificar();
        }
        private void dgvCatalogo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            CatalogoModificar();
        }
        public void FrmCuadrillaCat_Load(object sender, EventArgs e)
        {
            dgvCatalogo.DataSource = cls.CatalogoActivos();
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

                FrmCuadrillaAñadir f = new FrmCuadrillaAñadir(this);
                f.añadirModificar = false;
                f.lblTitulo.Text = "Modificar cuadrilla";
                f.txbId.Text = dgv.Cells["Número cuadrilla"].Value.ToString();
                f.txbName.Text = dgv.Cells["Nombre cuadrilla"].Value.ToString();
                f.txbIdContratista.Text = dgv.Cells["con"].Value.ToString();

                f.Text = "Modificar material";
                f.UpdateEventHandler += CatalogoActualizarHijo;
                f.ShowDialog();
            }
        }
    }
}