using System.Data;
using SisUvex.Catalogos.Distribuidor;
using System.Windows.Forms;

namespace SisUvex.Catalogos.PlanTrabajo
{
    public partial class FrmPlanTrabajoCat : Form
    {
        ClsPlanTrabajo cls = new ClsPlanTrabajo();
        bool _dgvStatus = true; //Verdadero vista de activos, Falso de activos e inactivos

        public FrmPlanTrabajoCat()
        {
            InitializeComponent();
        }
        public void FrmPlanTrabajoCat_Load(object sender, EventArgs e)
        {
            dtpFecha1.Value = DateTime.Now;
            dtpFecha2.Value = DateTime.Now;
            dgvCatalogo.DataSource = cls.CatalogoActualizar(dtpFecha1.Value.ToString("yyyy-MM-dd"), dtpFecha2.Value.ToString("yyyy-MM-dd"), _dgvStatus);
        }
        private void CatalogoActualizarHijo(object sender, FrmPlanTrabajoAñadir.UpdateEventArgs args)
        {
            dgvCatalogo.DataSource = cls.CatalogoActualizar(dtpFecha1.Value.ToString("yyyy-MM-dd"), dtpFecha2.Value.ToString("yyyy-MM-dd"), _dgvStatus);
        }
        private void btnAñadir_Click(object sender, EventArgs e)
        {
            FrmPlanTrabajoAñadir f = new FrmPlanTrabajoAñadir(this);
            f.añadirModificar = true;
            f.lblTitulo.Text = "Añadir plan de trabajo";
            f.Text = "Añadir plan de trabajo";
            f.txbId.Text = cls.SiguientePlanTrabajo();
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

                FrmPlanTrabajoAñadir f = new FrmPlanTrabajoAñadir(this);
                f.añadirModificar = false;
                f.lblTitulo.Text = "Modificar plan de trabajo";
                f.Text = "Modificar plan de trabajo";
                cls.LlenarFormulario(dgv.Cells["Plan"].Value.ToString(), ref f.txbId, ref f.txbIdLote, ref f.txbIdCuadrilla, ref f.txbIdPrograma, ref f.txbVPC, ref f.dtpFechaPlan, ref f.txbIdTamaño, ref f.txbIdTarima, ref f.txbIdContenedor);
                f.UpdateEventHandler += CatalogoActualizarHijo;
                f.ShowDialog();
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvCatalogo.DataSource = cls.CatalogoActualizar(dtpFecha1.Value.ToString("yyyy-MM-dd"), dtpFecha2.Value.ToString("yyyy-MM-dd"), _dgvStatus);
        }
        private void btnVerDetallados_Click(object sender, EventArgs e)
        {
            _dgvStatus = !_dgvStatus;
            dgvCatalogo.DataSource = cls.CatalogoActualizar(dtpFecha1.Value.ToString("yyyy-MM-dd"), dtpFecha2.Value.ToString("yyyy-MM-dd"), _dgvStatus);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            cls.EliminarPlan(dgvCatalogo.SelectedRows[0].Cells["Plan"].Value.ToString());
            dgvCatalogo.DataSource = cls.CatalogoActualizar(dtpFecha1.Value.ToString("yyyy-MM-dd"), dtpFecha2.Value.ToString("yyyy-MM-dd"), _dgvStatus);
        }

        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            cls.RecuperarPlan(dgvCatalogo.SelectedRows[0].Cells["Plan"].Value.ToString());
            dgvCatalogo.DataSource = cls.CatalogoActualizar(dtpFecha1.Value.ToString("yyyy-MM-dd"), dtpFecha2.Value.ToString("yyyy-MM-dd"), _dgvStatus);
        }

        private void dgvCatalogo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            dgvCatalogo.DataSource = cls.CatalogoActualizar(dtpFecha1.Value.ToString("yyyy-MM-dd"), dtpFecha2.Value.ToString("yyyy-MM-dd"), _dgvStatus);
        }
    }
}