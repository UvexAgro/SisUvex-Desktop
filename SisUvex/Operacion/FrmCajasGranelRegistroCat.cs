using SisUvex.Catalogos.PlantillaV1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Operacion
{
    internal partial class FrmCajasGranelRegistroCat : Form
    {
        public ClsCajasGranelRegistro cls;
        FrmCajasGranelRegistro formAdd;
        public FrmCajasGranelRegistroCat()
        {
            InitializeComponent();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCatalogo.Rows.Count > 0)
            {
                DialogResult = MessageBox.Show("¿Está seguro de eliminar el registro seleccionado?", "Eliminar", MessageBoxButtons.YesNo);
                if (DialogResult == DialogResult.Yes)
                {
                    string id = dgvCatalogo.SelectedRows[0].Cells["Código"].Value.ToString();

                    cls.EliminarRegistroSeleccionado(id);

                    dgvCatalogo.DataSource = cls.CatalogoActivos();
                }
            }
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            cls.OpenAddForm();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            cls.OpenModifyForm();
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            dgvCatalogo.DataSource = cls.CatalogoActivos();
        }

        private void FrmCajasGranelRegistroCat_Load(object sender, EventArgs e)
        {
            dgvCatalogo.DataSource = cls.CatalogoActivos();
        }
    }
}
