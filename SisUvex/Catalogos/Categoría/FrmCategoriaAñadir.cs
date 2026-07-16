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

namespace SisUvex.Catalogos.Categoría
{
    public partial class FrmCategoriaAñadir : Form
    {
        private ClsCategoria cls;
        private FrmCategoriaCat _frmCat;
        public bool EsAñadir = true;
        public FrmCategoriaAñadir(bool esAñadir, FrmCategoriaCat frmCat)
        {
            cls = new ClsCategoria(this);
            InitializeComponent();
            EsAñadir = esAñadir;
            cboActivo.SelectedIndex = 1;
            _frmCat = frmCat;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (EsAñadir)
            {
                if (!cls.ValidarIdCategoria(txbId.Text))
                {
                    SystemSounds.Beep.Play();
                    MessageBox.Show("El ID de la categoría ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                    cls.AñadirNuevaCategoria();
            }
            else
                cls.ModificarCategoria();

            cls.ActualizarCatalogoCategoriaSeleccionado(_frmCat.dgvCatalogo, _frmCat.btnEliminados.Text);

            this.Close();
        }

        private void lblId_Click(object sender, EventArgs e)
        {

        }
    }
}
