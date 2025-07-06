using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.PlantillaV1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
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
            if (dgvCatalogo.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvCatalogo.SelectedRows[0];

                cls.BtnDeleteSelectedRowFromDGVCatalog(selectedRow);
            }
            else
                SystemSounds.Exclamation.Play();
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            cls.OpenFrmAdd();

            if (cls.IsAddUpdate)
                cls.AddNewRowByIdInDGVCatalog();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            OpenFrmModifyFromCat();
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
        }

        private void FrmCajasGranelRegistroCat_Load(object sender, EventArgs e)
        {
            cls ??= new();
            cls.frmCat ??= this;
            cls.FrmCatLoad();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            cls.SetDgvCatalog();
        }

        private void OpenFrmModifyFromCat()
        {
            if (dgvCatalogo.SelectedRows.Count == 0)
            {
                SystemSounds.Exclamation.Play();
                return;
            }
            cls.OpenFrmModify(dgvCatalogo.Rows[dgvCatalogo.SelectedRows[0].Index].Cells[ClsObject.Column.id].Value.ToString());

            if (cls.IsModifyUpdate)
                cls.ModifyRowByIdInDGVCatalog();
        }
    }
}
