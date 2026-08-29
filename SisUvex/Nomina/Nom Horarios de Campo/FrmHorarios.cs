using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPOI.SS.Formula.Functions;
using SisUvex.Nomina.NomCuadrillasCampo;

namespace SisUvex.Nomina.Nom_Horarios_de_Campo
{
	public partial class FrmHorarios : Form
	{
		public ClsHorarios cls;
		public FrmHorarios()
		{
			InitializeComponent();
			cls = new ClsHorarios();
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
		private void FrmHorarios_Load(object sender, EventArgs e)
		{
			HasEditCatalogsPermission();
			cls.CargarHorarios();
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			cls.OpenFrmAdd();
		}

		private void btnModify_Click(object sender, EventArgs e)
		{
			cls.OpenFrmModify();
		}

		private void btnRemove_Click(object sender, EventArgs e)
		{
			cls.Eliminar();
		}
	}
}
