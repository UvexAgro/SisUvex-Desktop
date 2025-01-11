using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using SisUvex.Catalogos.Variedad;

namespace SisUvex.Catalogos.Ciudad
{
    public partial class FrmCiudadCat : Form
    {
        ClsCiudad cls = new ClsCiudad();
        bool _dgvStatus = true; //Verdadero vista de activos, Falso de activos e inactivos
        public FrmCiudadCat()
        {
            InitializeComponent();
            _dgvStatus = true;
        }
        private void CatalogoActualizarHijo(object sender, FrmCiudadAñadir.UpdateEventArgs args)
        {
            dgvCatalogo.DataSource = cls.CatalogoActualizar(_dgvStatus);
        }
        private void btnAñadir_Click(object sender, EventArgs e)
        {
            FrmCiudadAñadir frmAñadir = new FrmCiudadAñadir(this);
            frmAñadir.lblTitulo.Text = "Añadir ciudad";
            frmAñadir.cboActivo.SelectedIndex = 1;
            frmAñadir.añadirModificar = true;
            frmAñadir.Text = "Añadir ciudad";
            frmAñadir.txbId.Text = cls.SiguienteCiudad();
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
                cls.EliminarCiudad(dgvCatalogo.SelectedRows[0].Cells[1].Value.ToString());

                dgvCatalogo.DataSource = cls.CatalogoActualizar(_dgvStatus);
            }
        }
        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            if (dgvCatalogo.Rows.Count > 0)
            {
                cls.RecuperarCiudad(dgvCatalogo.SelectedRows[0].Cells[1].Value.ToString());

                dgvCatalogo.DataSource = cls.CatalogoActualizar(_dgvStatus);
            }

        }
        public void FrmCiudadCat_Load(object sender, EventArgs e)
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
                FrmCiudadAñadir frmAñadir = new FrmCiudadAñadir(this);
                frmAñadir.lblTitulo.Text = "Modificar ciudad";
                frmAñadir.cboActivo.SelectedIndex = Int32.Parse(dgvCatalogo.SelectedRows[0].Cells[0].Value.ToString());
                frmAñadir.txbId.Text = dgvCatalogo.SelectedRows[0].Cells[1].Value.ToString();
                frmAñadir.txbNomCiudad.Text = dgvCatalogo.SelectedRows[0].Cells[2].Value.ToString();
                frmAñadir.txbNomEstado.Text = dgvCatalogo.SelectedRows[0].Cells[3].Value.ToString();
                frmAñadir.txbNomPais.Text = dgvCatalogo.SelectedRows[0].Cells[4].Value.ToString();
                frmAñadir.añadirModificar = false;
                frmAñadir.Text = "Modificar ciudad";
                frmAñadir.UpdateEventHandler += CatalogoActualizarHijo;
                frmAñadir.ShowDialog();
            }
        }
    }
}
