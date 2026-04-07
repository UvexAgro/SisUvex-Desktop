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
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Forms.SelectionForms;
using SisUvex.Catalogos.Metods;



namespace SisUvex.Catalogos.FechasFestivas
{
	public partial class FrmCatFestivo : Form
	{
		public ClsCatFestivo cls;

		public FrmCatFestivo()
		{
			InitializeComponent();
		}

		private void FrmCatFestivo_Load(object sender, EventArgs e)
		{
			cls ??= new();
			cls.frmCat = this;
			cls.BeginFormCat();
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			cls.OpenFrmDia();
			if (cls.IsAddUpdate)
				cls.AddNewRowByIdInDGVCatalog();
		}

		private void btnModify_Click(object sender, EventArgs e)
		{
			if (dgvCatalog.SelectedRows.Count == 0)
			{
				System.Media.SystemSounds.Exclamation.Play();
				MessageBox.Show("Selecciona una Fecha");
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
				MessageBox.Show("Selecciona una fecha");
				return;
			}

			string id = dgvCatalog.Rows[dgvCatalog.SelectedRows[0].Index].Cells["Código"].Value.ToString();

			cls.BtnDelete(id);
		}
	}
}
