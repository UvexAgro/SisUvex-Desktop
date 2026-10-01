using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Nomina.Cat_Departamentos
{
	public partial class FrmDepartamento : Form
	{
		public ClsDepartamento cls;
		public FrmDepartamento()
		{
			InitializeComponent();

			cls ??= new();
			cls.frm = this;
		}
		private void HasEditCatalogsPermission() //metodo para dar permisos al usuario 
		{
			if (User.HasEditCatalogsPermission())
				return;

			btnAdd.Enabled = false;
			btnModify.Enabled = false;
			btnRemove.Enabled = false;
		}
		private void FrmDepartamento_Load(object sender, EventArgs e)
		{
			cls.BeginFormCat();
			HasEditCatalogsPermission();
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			cls.OpenFrmAdd();
			if (cls.IsAddUpdate)
				cls.AddNewRowByIdInDGVCatalog();
		}

		private void btnModify_Click(object sender, EventArgs e)
		{
			if (dgvDepartamento.SelectedRows.Count == 0)
			{
				System.Media.SystemSounds.Exclamation.Play();
				MessageBox.Show("Seleccione una Cuadrilla");
				return;
			}

			string id = dgvDepartamento.SelectedRows[0].Cells["Código"].Value.ToString();

			cls.OpenFrmModify(id);
			if (cls.IsModifyUpdate)
				cls.ModifyRowByIdInDGVCatalog();
		}

		private void btnRemove_Click(object sender, EventArgs e)
		{
			if (dgvDepartamento.SelectedRows.Count == 0)
			{
				System.Media.SystemSounds.Exclamation.Play();
				MessageBox.Show("Seleccione un concepto");
				return;
			}

			string id = dgvDepartamento.Rows[dgvDepartamento.SelectedRows[0].Index].Cells["Código"].Value.ToString();

			cls.BtnDelete(id);
		}
	}
}
