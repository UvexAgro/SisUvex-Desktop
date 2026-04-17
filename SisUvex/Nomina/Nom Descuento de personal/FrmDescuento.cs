using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SisUvex.Nomina.Ingresos_Diversos;

namespace SisUvex.Nomina.Nom_Descuento_de_personal
{
	public partial class FrmDescuento : Form
	{
		ClsDescuento cls;
		ClsAddDesc clsAdd;

		public FrmDescuento()
		{
			InitializeComponent();
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			cls.OpenFrmAdd();
			if (cls.IsAddUpdate)
				cls.AddNewRowByIdInDGVCatalog();
		}

		private void FrmDescuento_Load(object sender, EventArgs e)
		{
			cls ??= new();
			cls.frm = this;
			cls.BeginFormCat();
		}

		private void btnModify_Click(object sender, EventArgs e)
		{
			if (dgvCatalog.SelectedRows.Count == 0)
			{
				System.Media.SystemSounds.Exclamation.Play();
				MessageBox.Show("Seleccione un concepto");
				return;
			}

			string id = dgvCatalog.SelectedRows[0].Cells["Código"].Value.ToString();

			cls.OpenFrmModify(id);
			if (cls.IsModifyUpdate)
				cls.ModifyRowByIdInDGVCatalog();
		}

		private void btnRemove_Click(object sender, EventArgs e)
		{
			if (dgvCatalog.SelectedRows.Count == 0)
			{
				System.Media.SystemSounds.Exclamation.Play();
				MessageBox.Show("Seleccione un concepto");
				return;
			}

			string id = dgvCatalog.Rows[dgvCatalog.SelectedRows[0].Index].Cells["Código"].Value.ToString();

			cls.BtnDelete(id);
		}
	}
}
