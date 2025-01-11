
using SisUvex.Catalogos.Metods.Querys;
using System.Data;

namespace SisUvex.Catalogos.Productor
{
    public partial class FrmProductorCat : Form
    {
        ClsProductor cls = new ClsProductor();
        bool _dgvStatus = true; //Verdadero vista de activos, Falso de activos e inactivos
        public FrmProductorCat()
        {
            InitializeComponent();

            _dgvStatus = true;

        }

        private void CatalogoActualizarHijo(object sender, FrmProductorAñadir.UpdateEventArgs args)
        {
            dgvCatalogo.DataSource = cls.CatalogoActualizar(_dgvStatus);
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            FrmProductorAñadir frmAñadir = new FrmProductorAñadir(this);
            frmAñadir.lblTitulo.Text = "Añadir productor";
            frmAñadir.añadirModificar = true;
            frmAñadir.Text = "Añadir productor";
            frmAñadir.cboActivo.SelectedIndex = 1;
            frmAñadir.txbId.Text = cls.SiguienteProductor();
            frmAñadir.UpdateEventHandler += CatalogoActualizarHijo;
            frmAñadir.ShowDialog();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            CatalogoModificar();
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
                cls.EliminarProductor(dgvCatalogo.SelectedRows[0].Cells[1].Value.ToString());

                dgvCatalogo.DataSource = cls.CatalogoActualizar(_dgvStatus);
            }
        }

        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            if (dgvCatalogo.Rows.Count > 0)
            {
                cls.RecuperarProductor(dgvCatalogo.SelectedRows[0].Cells[1].Value.ToString());

                dgvCatalogo.DataSource = cls.CatalogoActualizar(_dgvStatus);
            }
        }

        public void FrmProductorCat_Load(object sender, EventArgs e)
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
                FrmProductorAñadir frmAñadir = new FrmProductorAñadir(this);
                frmAñadir.lblTitulo.Text = "Modificar productor";
                frmAñadir.Text = "Modificar productor";
                frmAñadir.añadirModificar = false;
                frmAñadir.UpdateEventHandler += CatalogoActualizarHijo;


                //frmAñadir.cboActivo.SelectedIndex = Int32.Parse(dgvCatalogo.SelectedRows[0].Cells[0].Value.ToString());
                //frmAñadir.txbId.Text = dgvCatalogo.SelectedRows[0].Cells[1].Value.ToString();
                //frmAñadir.txbNombre.Text = dgvCatalogo.SelectedRows[0].Cells[2].Value.ToString();
                //frmAñadir.txbDireccion.Text = dgvCatalogo.SelectedRows[0].Cells[3].Value.ToString();
                //frmAñadir.txbCiudad.Text = dgvCatalogo.SelectedRows[0].Cells[4].Value.ToString();
                //frmAñadir.txbRFC.Text = dgvCatalogo.SelectedRows[0].Cells[5].Value.ToString();
                //frmAñadir.txbTelefono.Text = dgvCatalogo.SelectedRows[0].Cells[6].Value.ToString();

                DataTable dtProductor = ClsQuerysDB.GetDataTable("SELECT * FROM Pack_Grower WHERE id_grower = '" + dgvCatalogo.SelectedRows[0].Cells[1].Value.ToString() + "'");

                frmAñadir.cboActivo.SelectedIndex = Int32.Parse(dtProductor.Rows[0]["c_active"].ToString());
                frmAñadir.txbId.Text = dtProductor.Rows[0]["id_grower"].ToString();
                frmAñadir.txbNombre.Text = dtProductor.Rows[0]["v_nameGrower"].ToString();
                frmAñadir.txbDireccion.Text = dtProductor.Rows[0]["v_address"].ToString();
                frmAñadir.txbCiudad.Text = dtProductor.Rows[0]["v_city"].ToString();
                frmAñadir.txbRFC.Text = dtProductor.Rows[0]["v_RFC"].ToString();
                frmAñadir.txbTelefono.Text = dtProductor.Rows[0]["c_phoneNumber"].ToString();
                frmAñadir.txbGGN.Text = dtProductor.Rows[0]["v_GGN"].ToString();
                frmAñadir.txbLogo.Text = dtProductor.Rows[0]["v_logo"].ToString();
                frmAñadir.txbShortName.Text = dtProductor.Rows[0]["v_shortName"].ToString();
                frmAñadir.txbRegPat.Text = dtProductor.Rows[0]["v_regPat"].ToString();

                frmAñadir.ShowDialog();
            }
        }
    }
}
