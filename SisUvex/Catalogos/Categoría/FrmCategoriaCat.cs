using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using SisUvex.Catalogos.Metods.DataGridViews;

namespace SisUvex.Catalogos.Categoría
{
    public partial class FrmCategoriaCat : Form
    {
        ClsCategoria cls;
        public FrmCategoriaCat()
        {
            InitializeComponent();

            cls = new ClsCategoria(this);
            ClsDataGridViewCatalogs.DgvApplyCellFormattingEvent(dgvCatalogo);
        }

        private void FrmCategoriaCat_Load(object sender, EventArgs e)
        {
            dgvCatalogo.DataSource = cls.ObtenerCatalogoActivosCategoriaDataGridView();
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            cls.AbrirFrmCategoriaAñadir();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            cls.AbrirFrmCategoriaModificar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            cls.EliminarCategoria();
        }

        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            cls.RecuperarCategoria();
        }

        private void btnEliminados_Click(object sender, EventArgs e)
        {
            cls.ActualizarCatalogoCategoriaBotonActivosEliminados();
        }
    }
}
