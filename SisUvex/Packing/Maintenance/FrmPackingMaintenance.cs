using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SisUvex.Catalogos.Metods.Querys;

namespace SisUvex.Packing.Maintenance
{
    public partial class FrmPackingMaintenance : Form
    {
        public FrmPackingMaintenance()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCleanPackingBoxes_Click(object sender, EventArgs e)
        {
            bool result = ClsQuerysDB.ExecuteQuery("sp_PackPackedUniqueBoxBackUp");

            if (result)
                MessageBox.Show("Cajas limpiadas correctamente.", "Limpieza de cajas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Error al limpiar cajas.", "Limpieza de cajas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
