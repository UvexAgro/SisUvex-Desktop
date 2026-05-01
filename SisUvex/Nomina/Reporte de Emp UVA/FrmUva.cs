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
using static SisUvex.Catalogos.Metods.ClsObject;

namespace SisUvex.Nomina.Reporte_de_Emp_UVA
{
	public partial class FrmUva : Form
	{
		public ClsUva cls;
		public bool cargando = false;
		public FrmUva()
		{
			InitializeComponent();
		}

		private void FrmUva_Load(object sender, EventArgs e)
		{

			cls ??= new();
			cls.frm ??= this;
			HasEditCatalogsPermission();
		}
		private void HasEditCatalogsPermission() //metodo para dar permisos al usuario 
		{
			if (User.HasEditCatalogsPermission())
				return;

			btnCargar.Enabled = false;
			btnExcel.Enabled = false;
		}

		private void btnCargar_Click(object sender, EventArgs e)
		{
			cls.CargarHorasInicial();
		}

		private void btnExcel_Click(object sender, EventArgs e)
		{
			cls.ExportarExcel((DataTable)dgvHoras.DataSource);
		}
	}
}
