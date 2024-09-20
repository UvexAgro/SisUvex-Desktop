
using SisUvex.Archivo.RegistroMaterial;
using SisUvex.Catalogos.Material;

namespace SisUvex.Catalogos.RegistroMaterial
{
    public partial class FrmRegistroMaterialCat : Form
    {
        ClsRegistroMaterial cls = new ClsRegistroMaterial();
        string _dgvStatus = "T"; //Verdadero vista de activos, Falso de activos e inactivos

        public FrmRegistroMaterialCat()
        {
            InitializeComponent();
        }

        private void CatalogoActualizarHijo(object sender, FrmRegistroMaterial.UpdateEventArgs args)
        {
            dgvCatalogo.DataSource = cls.CatalogoActualizar(_dgvStatus, dtpEntreFecha1.Value, dtpEntreFecha2.Value);
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            FrmRegistroMaterial f = new FrmRegistroMaterial(this);
            f.añadirModificar = true;
            f.lblTitulo.Text = "Entrada material";
            f.Text = "Entrada material";
            f.txbId.Text = cls.SiguienteRegistroMaterial("E"); //*
            f.UpdateEventHandler += CatalogoActualizarHijo;
            f.ShowDialog();
        }
        private void btnAgregarSalida_Click(object sender, EventArgs e)
        {
            FrmRegistroMaterial f = new FrmRegistroMaterial(this);
            f.añadirModificar = true;
            f.lblTitulo.Text = "Salida material";
            f.Text = "Salida material";
            f.txbId.Text = cls.SiguienteRegistroMaterial("S"); //*
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
        public void FrmRegistroMaterialCat_Load(object sender, EventArgs e)
        {
            dgvCatalogo.DataSource = cls.CatalogoActualizar(_dgvStatus, dtpEntreFecha1.Value, dtpEntreFecha2.Value);
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
                string id = dgv.Cells["Código"].Value.ToString();
                string inOut = id.Substring(0, 1);

                FrmRegistroMaterial f = new FrmRegistroMaterial(this);
                f.añadirModificar = false;

                if (inOut == "E")
                {
                    f.lblTitulo.Text = "Modificar entrada";
                    f.Text = "Modificar entrada";
                }
                else
                {
                    f.lblTitulo.Text = "Modificar salida";
                    f.Text = "Modificar salida";
                }
                f.txbId.Text = id;
                cls.LlenarDTGMateriales(id, f.dgvMateriales, ref f.usrCreador, ref f.fechaCreacion);
                f.UpdateEventHandler += CatalogoActualizarHijo;
                f.ShowDialog();
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCatalogo.Rows.Count > 0)
            {
                DataGridViewRow dgv = dgvCatalogo.SelectedRows[0];
                string id = dgv.Cells["Código"].Value.ToString();

                DialogResult EliminarSN = MessageBox.Show("Desea eliminar el registro " + id, "Eliminar registro de material.", MessageBoxButtons.YesNo);
                if (EliminarSN == DialogResult.Yes)
                {
                    cls.EliminarRegistroMaterial(id);
                    dgvCatalogo.DataSource = cls.CatalogoActualizar(_dgvStatus, dtpEntreFecha1.Value, dtpEntreFecha2.Value);
                }
                else if (EliminarSN == DialogResult.No)
                {
                }
            }
        }

        private void btnEntradas_Click(object sender, EventArgs e)
        {
            dgvCatalogo.DataSource = cls.CatalogoActualizar(_dgvStatus = "E", dtpEntreFecha1.Value, dtpEntreFecha2.Value);
        }

        private void btnSalidas_Click(object sender, EventArgs e)
        {
            dgvCatalogo.DataSource = cls.CatalogoActualizar(_dgvStatus = "S", dtpEntreFecha1.Value, dtpEntreFecha2.Value);
        }

        private void btnTodo_Click(object sender, EventArgs e)
        {
            dgvCatalogo.DataSource = cls.CatalogoActualizar(_dgvStatus = "T", dtpEntreFecha1.Value, dtpEntreFecha2.Value);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvCatalogo.DataSource = cls.CatalogoActivosFechas(_dgvStatus, dtpEntreFecha1.Value, dtpEntreFecha2.Value);
        }


    }
}